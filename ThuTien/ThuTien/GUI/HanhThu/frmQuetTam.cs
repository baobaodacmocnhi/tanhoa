using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.HanhThu;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.BaoCao;
using ThuTien.GUI.BaoCao;
using ThuTien.BaoCao.ChuyenKhoan;
using System.Globalization;
using ThuTien.BaoCao.DongNuoc;

namespace ThuTien.GUI.HanhThu
{
    public partial class frmQuetTam : Form
    {
        string _mnu = "mnuQuetTam";
        CHoaDon _cHoaDon = new CHoaDon();
        CQuetTam _cQuetTam = new CQuetTam();

        public frmQuetTam()
        {
            InitializeComponent();
        }

        private void frmQuetTam_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            dateTu.Value = DateTime.Now;

            btnXem.PerformClick();
        }

        public void CountdgvHDTuGia()
        {
            int TongCong = 0;
            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    TongCong += int.Parse(item.Cells["TongCong_TG"].Value.ToString());
                }
                txtTongHD_TG.Text = dgvHDTuGia.RowCount.ToString();
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        public void CountdgvHDCoQuan()
        {
            int TongCong = 0;
            if (dgvHDCoQuan.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    TongCong += int.Parse(item.Cells["TongCong_CQ"].Value.ToString());
                }
                txtTongHD_CQ.Text = dgvHDCoQuan.RowCount.ToString();
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
            {
                foreach (string item in txtSoHoaDon.Lines)
                    if (!string.IsNullOrEmpty(item.Trim().ToUpper()) && item.ToString().Length == 13 && lstHD.FindItemWithText(item.Trim().ToUpper()) == null)
                    {
                        lstHD.Items.Add(item.Trim().ToUpper());
                        lstHD.EnsureVisible(lstHD.Items.Count - 1);
                    }
                txtSoLuong.Text = lstHD.Items.Count.ToString();
                txtSoHoaDon.Text = "";
            }
        }

        private void lstHD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstHD.Items.Count > 0 && e.Button == MouseButtons.Left)
            {
                foreach (ListViewItem item in lstHD.SelectedItems)
                {
                    lstHD.Items.Remove(item);
                }
                txtSoLuong.Text = lstHD.Items.Count.ToString();
            }
        }

        private void lstHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoLuong.Text = lstHD.Items.Count.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                foreach (ListViewItem item in lstHD.Items)
                {
                    if (!_cHoaDon.CheckBySoHoaDon(item.Text))
                    {
                        MessageBox.Show("Hóa Đơn sai: " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        item.Selected = true;
                        item.Focused = true;
                        return;
                    }
                    //if (!_cQuetTam.CheckExistByID(item.ToString(),CNguoiDung.MaND))
                    //{
                    //    MessageBox.Show("Hóa Đơn đã Quét Tạm " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    lstHD.SelectedItem = item;
                    //    return;
                    //}
                }
                try
                {
                    _cQuetTam.BeginTransaction();
                    foreach (ListViewItem item in lstHD.Items)
                        if (!_cQuetTam.CheckExist(item.Text, CNguoiDung.MaND, DateTime.Now))
                        {
                            TT_QuetTam quettam = new TT_QuetTam();
                            quettam.SoHoaDon = item.Text;
                            if (!_cQuetTam.Them(quettam))
                            {
                                _cQuetTam.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    _cQuetTam.CommitTransaction();
                    lstHD.Items.Clear();
                    btnXem.PerformClick();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    _cQuetTam.Rollback();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (tabControl.SelectedTab.Name == "tabTuGia")
                    {
                        try
                        {
                            _cQuetTam.BeginTransaction();
                            foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                            {
                                TT_QuetTam quettam = _cQuetTam.GetByID(int.Parse(item.Cells["MaQT_TG"].Value.ToString()));
                                if (!_cQuetTam.Xoa(quettam))
                                {
                                    _cQuetTam.Rollback();
                                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            _cQuetTam.CommitTransaction();
                            lstHD.Items.Clear();
                            btnXem.PerformClick();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            _cQuetTam.Rollback();
                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        if (tabControl.SelectedTab.Name == "tabCoQuan")
                        {
                            try
                            {
                                _cQuetTam.BeginTransaction();
                                foreach (DataGridViewRow item in dgvHDCoQuan.SelectedRows)
                                {
                                    TT_QuetTam quettam = _cQuetTam.GetByID(int.Parse(item.Cells["MaQT_CQ"].Value.ToString()));
                                    if (!_cQuetTam.Xoa(quettam))
                                    {
                                        _cQuetTam.Rollback();
                                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                _cQuetTam.CommitTransaction();
                                lstHD.Items.Clear();
                                btnXem.PerformClick();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception)
                            {
                                _cQuetTam.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                    dr["LoaiBaoCao"] = "TƯ GIA";
                    dr["DanhBo"] = item.Cells["DanhBo_TG"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["Ky"] = item.Cells["Ky_TG"].Value;
                    dr["MLT"] = item.Cells["MLT_TG"].Value;
                    dr["TongCong"] = item.Cells["TongCong_TG"].Value;
                    dr["SoPhatHanh"] = item.Cells["SoPhatHanh_TG"].Value;
                    dr["SoHoaDon"] = item.Cells["SoHoaDon_TG"].Value;
                    dr["NhanVien"] = CNguoiDung.HoTen;
                    ds.Tables["DSHoaDon"].Rows.Add(dr);
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                    {
                        DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                        dr["LoaiBaoCao"] = "CƠ QUAN";
                        dr["DanhBo"] = item.Cells["DanhBo_CQ"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["Ky"] = item.Cells["Ky_CQ"].Value;
                        dr["MLT"] = item.Cells["MLT_CQ"].Value;
                        dr["TongCong"] = item.Cells["TongCong_CQ"].Value;
                        dr["SoPhatHanh"] = item.Cells["SoPhatHanh_CQ"].Value;
                        dr["SoHoaDon"] = item.Cells["SoHoaDon_CQ"].Value;
                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["DSHoaDon"].Rows.Add(dr);
                    }
                }
            rptDSHoaDon rpt = new rptDSHoaDon();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                dgvHDTuGia.DataSource = _cQuetTam.GetDSByMaNVCreatedDate("TG", CNguoiDung.MaND);
                CountdgvHDTuGia();
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    dgvHDCoQuan.DataSource = _cQuetTam.GetDSByMaNVCreatedDate("CQ", CNguoiDung.MaND);
                    CountdgvHDCoQuan();
                }
        }

        private void dgvHDTuGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "DanhBo_TG" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCong_TG" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDTuGia_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDTuGia.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHDCoQuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "DanhBo_CQ" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCong_CQ" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDCoQuan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDCoQuan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnInDSDiaChi_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                    dr["DanhBo"] = item.Cells["DanhBo_TG"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["HoTen"] = item.Cells["HoTen_TG"].Value;
                    dr["DiaChi"] = item.Cells["DiaChi_TG"].Value;
                    dr["NhanVien"] = CNguoiDung.HoTen;
                    ds.Tables["DSHoaDon"].Rows.Add(dr);
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                    {
                        DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                        dr["DanhBo"] = item.Cells["DanhBo_CQ"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["HoTen"] = item.Cells["HoTen_CQ"].Value;
                        dr["DiaChi"] = item.Cells["DiaChi_CQ"].Value;
                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["DSHoaDon"].Rows.Add(dr);
                    }
                }
            rptDSHoaDon_DiaChi rpt = new rptDSHoaDon_DiaChi();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnInDSPhanTo_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                    dr["LoaiBaoCao"] = "HÓA ĐƠN TƯ GIA";
                    dr["DanhBo"] = item.Cells["DanhBo_TG"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["HoTen"] = item.Cells["HoTen_TG"].Value.ToString();
                    dr["MLT"] = item.Cells["MLT_TG"].Value.ToString();
                    dr["Ky"] = item.Cells["Ky_TG"].Value.ToString();
                    dr["TongCong"] = item.Cells["TongCong_TG"].Value.ToString();
                    dr["NhanVien"] = item.Cells["HanhThu_TG"].Value.ToString();
                    dr["To"] = item.Cells["To_TG"].Value.ToString();
                    if (int.Parse(item.Cells["GiaBieu_TG"].Value.ToString()) > 20)
                        dr["Loai"] = "CQ";
                    else
                        dr["Loai"] = "TG";
                    ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                    {
                        DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                        dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                        dr["LoaiBaoCao"] = "HÓA ĐƠN CƠ QUAN";
                        dr["DanhBo"] = item.Cells["DanhBo_CQ"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["HoTen"] = item.Cells["HoTen_CQ"].Value.ToString();
                        dr["MLT"] = item.Cells["MLT_CQ"].Value.ToString();
                        dr["Ky"] = item.Cells["Ky_CQ"].Value.ToString();
                        dr["TongCong"] = item.Cells["TongCong_CQ"].Value.ToString();
                        dr["NhanVien"] = item.Cells["HanhThu_CQ"].Value.ToString();
                        dr["To"] = item.Cells["To_CQ"].Value.ToString();
                        if (int.Parse(item.Cells["GiaBieu_CQ"].Value.ToString()) > 20)
                            dr["Loai"] = "CQ";
                        else
                            dr["Loai"] = "TG";
                        ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                    }
                }
            
            rptDSTamThuChuyenKhoan rpt = new rptDSTamThuChuyenKhoan();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnInTBTienNuoc_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                dsBaoCao ds = new dsBaoCao();
                DataTable dt = new DataTable();
                if (tabControl.SelectedTab.Name == "tabTuGia")
                {
                    dt = (DataTable)dgvHDTuGia.DataSource;
                }
                else
                    if (tabControl.SelectedTab.Name == "tabCoQuan")
                    {
                        dt = (DataTable)dgvHDCoQuan.DataSource;
                    }

                ds.Tables["TBDongNuoc"].PrimaryKey = new DataColumn[] { ds.Tables["TBDongNuoc"].Columns["DanhBo"] };
                foreach (DataRow item in dt.Rows)
                    if (!ds.Tables["TBDongNuoc"].Rows.Contains(item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ")))
                    {
                        DataRow[] drTemp = dt.Select("DanhBo like '" + item["DanhBo"].ToString() + "'");

                        string Ky = "";
                        string SoTien = "";
                        int TongCong = 0;
                        foreach (DataRow itemChild in drTemp)
                        {
                            Ky += itemChild["Ky"] + "\n";
                            SoTien += String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", itemChild["TongCong"]) + "\n";
                            TongCong += int.Parse(itemChild["TongCong"].ToString());
                        }

                        DataRow dr = ds.Tables["TBDongNuoc"].NewRow();
                        dr["HoTen"] = item["HoTen"];
                        dr["DiaChi"] = item["DiaChi"];
                        if (!string.IsNullOrEmpty(item["DanhBo"].ToString()))
                            dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["MLT"] = item["MLT"];
                        dr["Ky"] = Ky;
                        dr["SoTien"] = SoTien;
                        dr["TongCong"] = TongCong;

                        ds.Tables["TBDongNuoc"].Rows.Add(dr);
                    }

                rptTBTienNuocPhoto rpt = new rptTBTienNuocPhoto();
                rpt.SetDataSource(ds);
                //frmBaoCao frm = new frmBaoCao(rpt);
                //frm.ShowDialog();
                printDialog.AllowSomePages = true;
                printDialog.ShowHelp = true;

                rpt.PrintOptions.PaperOrientation = rpt.PrintOptions.PaperOrientation;
                rpt.PrintOptions.PaperSize = rpt.PrintOptions.PaperSize;
                rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

                rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, false, 1, 1);
            }
        }

        private void btnInTBCatOng_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                dsBaoCao ds = new dsBaoCao();
                DataTable dt = new DataTable();
                if (tabControl.SelectedTab.Name == "tabTuGia")
                {
                    dt = (DataTable)dgvHDTuGia.DataSource;
                }
                else
                    if (tabControl.SelectedTab.Name == "tabCoQuan")
                    {
                        dt = (DataTable)dgvHDCoQuan.DataSource;
                    }

                int stt = 1;
                ds.Tables["TBDongNuoc"].PrimaryKey = new DataColumn[] { ds.Tables["TBDongNuoc"].Columns["DanhBo"] };
                foreach (DataRow item in dt.Rows)
                    if (!ds.Tables["TBDongNuoc"].Rows.Contains(item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ")))
                    {
                        DataRow[] drTemp = dt.Select("DanhBo like '" + item["DanhBo"].ToString() + "'");

                        string Ky = "";
                        int TongCong = 0;
                        foreach (DataRow itemChild in drTemp)
                        {
                            Ky += itemChild["Ky"] + "  Số tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", itemChild["TongCong"]) + "\n";
                            TongCong += int.Parse(itemChild["TongCong"].ToString());
                        }

                        DataRow dr = ds.Tables["TBDongNuoc"].NewRow();
                        dr["MaDN"] = stt++;
                        dr["HoTen"] = item["HoTen"];
                        dr["DiaChi"] = item["DiaChi"];
                        if (!string.IsNullOrEmpty(item["DanhBo"].ToString()))
                            dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["MLT"] = item["MLT"];
                        dr["HopDong"] = item["HopDong"];
                        dr["Ky"] = Ky;
                        dr["TongCong"] = TongCong;

                        ds.Tables["TBDongNuoc"].Rows.Add(dr);
                    }

                rptTBCatOngPhoto rpt = new rptTBCatOngPhoto();
                rpt.SetDataSource(ds);
                //frmBaoCao frm = new frmBaoCao(rpt);
                //frm.ShowDialog();
                printDialog.AllowSomePages = true;
                printDialog.ShowHelp = true;

                rpt.PrintOptions.PaperOrientation = rpt.PrintOptions.PaperOrientation;
                rpt.PrintOptions.PaperSize = rpt.PrintOptions.PaperSize;
                rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

                rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, false, 1, 1);
            }
        }

    }
}

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
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.DAL;
using ThuTien.DAL.TongHop;

namespace ThuTien.GUI.HanhThu
{
    public partial class frmQuetTam : Form
    {
        string _mnu = "mnuQuetTam";
        CHoaDon _cHoaDon = new CHoaDon();
        CQuetTam _cQuetTam = new CQuetTam();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CDHN _cDocSo = new CDHN();

        public frmQuetTam()
        {
            InitializeComponent();
        }

        private void frmQuetTam_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            if (CNguoiDung.ToTruong)
            {
                lbNhanVien.Visible = true;
                cmbNhanVien.Visible = true;

                cmbNhanVien.DataSource = _cNguoiDung.GetDSByMaTo(CNguoiDung.MaTo);
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaND";

                cmbNhanVien.SelectedValue = CNguoiDung.MaND;
            }

            tabTuGia.Text = "Hóa Đơn";
            tabControl.TabPages.Remove(tabCoQuan);

            btnXem.PerformClick();
        }

        public void CountdgvHDTuGia()
        {
            long TongCong = 0;
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
            long TongCong = 0;
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
                    if (!string.IsNullOrEmpty(item.Trim().ToUpper()) && item.ToString().Length == 13)
                    {
                        if (lstHD.FindItemWithText(item.Trim().ToUpper()) == null)
                        {
                            lstHD.Items.Add(item.Trim().ToUpper());
                            lstHD.EnsureVisible(lstHD.Items.Count - 1);
                        }
                    }
                    else
                        ///Trung An thêm 'K' phía cuối liên hóa đơn
                        if (!string.IsNullOrEmpty(item.Trim().ToUpper()) && item.ToString().Length == 14)
                        {
                            if (lstHD.FindItemWithText(item.Trim().ToUpper().Replace("K", "")) == null)
                            {
                                lstHD.Items.Add(item.Trim().ToUpper().Replace("K", ""));
                                lstHD.EnsureVisible(lstHD.Items.Count - 1);
                            }
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
                    if (!_cHoaDon.CheckExist(item.Text))
                    {
                        MessageBox.Show("Hóa Đơn sai: " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstHD.Focus();
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
                            quettam.MaHD = _cHoaDon.Get(item.Text).ID_HOADON;
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
                                TT_QuetTam quettam = _cQuetTam.Get(int.Parse(item.Cells["ID_TG"].Value.ToString()));
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
                                    TT_QuetTam quettam = _cQuetTam.Get(int.Parse(item.Cells["ID_CQ"].Value.ToString()));
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
                    dr["LoaiBaoCao"] = "";
                    dr["DanhBo"] = item.Cells["DanhBo_TG"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["Ky"] = item.Cells["Ky_TG"].Value;
                    dr["MLT"] = item.Cells["MLT_TG"].Value.ToString().Insert(4, " ").Insert(2, " ");
                    dr["TongCong"] = item.Cells["TongCong_TG"].Value;
                    dr["SoPhatHanh"] = item.Cells["SoPhatHanh_TG"].Value;
                    dr["SoHoaDon"] = item.Cells["SoHoaDon_TG"].Value;
                    if (int.Parse(item.Cells["GiaBieu_TG"].Value.ToString()) > 20)
                        dr["Loai"] = "CQ";
                    else
                        dr["Loai"] = "TG";
                    if (CNguoiDung.ToTruong)
                        dr["NhanVien"] = ((TT_NguoiDung)cmbNhanVien.SelectedItem).HoTen;
                    else
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
                        dr["MLT"] = item.Cells["MLT_CQ"].Value.ToString().Insert(4, " ").Insert(2, " ");
                        dr["TongCong"] = item.Cells["TongCong_CQ"].Value;
                        dr["SoPhatHanh"] = item.Cells["SoPhatHanh_CQ"].Value;
                        dr["SoHoaDon"] = item.Cells["SoHoaDon_CQ"].Value;
                        if (CNguoiDung.ToTruong)
                            dr["NhanVien"] = ((TT_NguoiDung)cmbNhanVien.SelectedItem).HoTen;
                        else
                            dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["DSHoaDon"].Rows.Add(dr);
                    }
                }
            rptDSHoaDon rpt = new rptDSHoaDon();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if (CNguoiDung.ToTruong)
                    dgvHDTuGia.DataSource = _cQuetTam.GetDSByMaNVCreatedDate("", int.Parse(cmbNhanVien.SelectedValue.ToString()));
                else
                    dgvHDTuGia.DataSource = _cQuetTam.GetDSByMaNVCreatedDate("", CNguoiDung.MaND);
                CountdgvHDTuGia();
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    if (CNguoiDung.ToTruong)
                        dgvHDCoQuan.DataSource = _cQuetTam.GetDSByMaNVCreatedDate("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()));
                    else
                        dgvHDCoQuan.DataSource = _cQuetTam.GetDSByMaNVCreatedDate("CQ", CNguoiDung.MaND);
                    CountdgvHDCoQuan();
                }
        }

        private void dgvHDTuGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "MLT_TG" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
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
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "MLT_CQ" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
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
            dsBaoCao dsBaoCao = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["DSHoaDon"].NewRow();
                    dr["DanhBo"] = item.Cells["DanhBo_TG"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["HoTen"] = item.Cells["HoTen_TG"].Value;
                    dr["DiaChi"] = item.Cells["DiaChi_TG"].Value;
                    dr["MLT"] = item.Cells["MLT_TG"].Value.ToString().Insert(4, " ").Insert(2, " ");
                    if (CNguoiDung.ToTruong)
                        dr["NhanVien"] = ((TT_NguoiDung)cmbNhanVien.SelectedItem).HoTen;
                    else
                        dr["NhanVien"] = CNguoiDung.HoTen;
                    dsBaoCao.Tables["DSHoaDon"].Rows.Add(dr);
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                    {
                        DataRow dr = dsBaoCao.Tables["DSHoaDon"].NewRow();
                        dr["DanhBo"] = item.Cells["DanhBo_CQ"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["HoTen"] = item.Cells["HoTen_CQ"].Value;
                        dr["DiaChi"] = item.Cells["DiaChi_CQ"].Value;
                        dr["MLT"] = item.Cells["MLT_CQ"].Value.ToString().Insert(4, " ").Insert(2, " ");
                        if (CNguoiDung.ToTruong)
                            dr["NhanVien"] = ((TT_NguoiDung)cmbNhanVien.SelectedItem).HoTen;
                        else
                            dr["NhanVien"] = CNguoiDung.HoTen;
                        dsBaoCao.Tables["DSHoaDon"].Rows.Add(dr);
                    }
                }
            rptDSHoaDon_DiaChi rpt = new rptDSHoaDon_DiaChi();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnInDSPhanTo_Click(object sender, EventArgs e)
        {
            dsBaoCao dsBaoCao = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["TuNgay"] = DateTime.Now.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = DateTime.Now.ToString("dd/MM/yyyy");
                    dr["LoaiBaoCao"] = "HÓA ĐƠN";
                    dr["DanhBo"] = item.Cells["DanhBo_TG"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["HoTen"] = item.Cells["HoTen_TG"].Value.ToString();
                    dr["MLT"] = item.Cells["MLT_TG"].Value.ToString().ToString().Insert(4, " ").Insert(2, " ");
                    dr["Ky"] = item.Cells["Ky_TG"].Value.ToString();
                    dr["TongCong"] = item.Cells["TongCong_TG"].Value.ToString();
                    dr["HanhThu"] = item.Cells["HanhThu_TG"].Value.ToString();
                    dr["To"] = item.Cells["To_TG"].Value.ToString();
                    if (int.Parse(item.Cells["GiaBieu_TG"].Value.ToString()) > 20)
                        dr["Loai"] = "CQ";
                    else
                        dr["Loai"] = "TG";
                    dsBaoCao.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                    {
                        DataRow dr = dsBaoCao.Tables["TamThuChuyenKhoan"].NewRow();
                        dr["TuNgay"] = DateTime.Now.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = DateTime.Now.ToString("dd/MM/yyyy");
                        dr["LoaiBaoCao"] = "HÓA ĐƠN CƠ QUAN";
                        dr["DanhBo"] = item.Cells["DanhBo_CQ"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["HoTen"] = item.Cells["HoTen_CQ"].Value.ToString();
                        dr["MLT"] = item.Cells["MLT_CQ"].Value.ToString().ToString().Insert(4, " ").Insert(2, " ");
                        dr["Ky"] = item.Cells["Ky_CQ"].Value.ToString();
                        dr["TongCong"] = item.Cells["TongCong_CQ"].Value.ToString();
                        dr["HanhThu"] = item.Cells["HanhThu_CQ"].Value.ToString();
                        dr["To"] = item.Cells["To_CQ"].Value.ToString();
                        if (int.Parse(item.Cells["GiaBieu_CQ"].Value.ToString()) > 20)
                            dr["Loai"] = "CQ";
                        else
                            dr["Loai"] = "TG";
                        dsBaoCao.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                    }
                }

            rptDSTamThuChuyenKhoan rpt = new rptDSTamThuChuyenKhoan();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnInTBTienNuoc_Click(object sender, EventArgs e)
        {
            //PrintDialog printDialog = new PrintDialog();
            //if (printDialog.ShowDialog() == DialogResult.OK)
            //{
            dsBaoCao dsBaoCao = new dsBaoCao();
            DataTable dt = new DataTable();
            dsBaoCao.Tables["TBDongNuoc"].PrimaryKey = new DataColumn[] { dsBaoCao.Tables["TBDongNuoc"].Columns["DanhBo"] };

            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                dt = (DataTable)dgvHDTuGia.DataSource;
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                    if (!dsBaoCao.Tables["TBDongNuoc"].Rows.Contains(item.Cells["DanhBo_TG"].Value.ToString().Insert(4, " ").Insert(8, " ")))
                    {
                        DataRow[] drTemp = dt.Select("DanhBo like '" + item.Cells["DanhBo_TG"].Value.ToString() + "'");

                        string Ky = "";
                        string SoTien = "";
                        int TongCong = 0;
                        int SoPhieu = 0;
                        foreach (DataRow itemChild in drTemp)
                        {
                            Ky += itemChild["Ky"] + "\n";
                            SoTien += String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", itemChild["TongCong"]) + "\n";
                            TongCong += int.Parse(itemChild["TongCong"].ToString());
                            if (string.IsNullOrEmpty(itemChild["SoPhieu"].ToString()) == true)
                            {
                                SoPhieu = _cQuetTam.GetNextSoPhieu();
                                TT_QuetTam entity = _cQuetTam.Get(int.Parse(itemChild["ID"].ToString()));
                                entity.SoPhieu = SoPhieu;
                                _cQuetTam.SubmitChanges();
                            }
                        }

                        DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                        if (SoPhieu == 0)
                            dr["MaDN"] = item.Cells["SoPhieu_TG"].Value.ToString().Insert(item.Cells["SoPhieu_TG"].Value.ToString().Length - 2, "-");
                        else
                            dr["MaDN"] = SoPhieu.ToString().Insert(SoPhieu.ToString().Length - 2, "-");
                        dr["HoTen"] = item.Cells["HoTen_TG"].Value;
                        dr["DiaChi"] = item.Cells["DiaChi_TG"].Value;
                        if (!string.IsNullOrEmpty(item.Cells["DanhBo_TG"].Value.ToString()))
                        {
                            dr["DanhBo"] = item.Cells["DanhBo_TG"].Value.ToString().Insert(7, " ").Insert(4, " ");
                            dr["DienThoai"] = _cDocSo.GetDienThoai(item.Cells["DanhBo_TG"].Value.ToString());
                        }
                        dr["MLT"] = item.Cells["MLT_TG"].Value.ToString().Insert(4, " ").Insert(2, " ");
                        dr["Ky"] = Ky;
                        dr["SoTien"] = SoTien;
                        dr["TongCong"] = TongCong;
                        if (chkChuKy.Checked)
                        {
                            dr["ChuKy"] = true;
                            dr["ChuKyImage"] = Application.StartupPath.ToString() + @"\Resources\chuky.png";
                        }
                        if (chkCoTenNguoiKy.Checked)
                            dr["NguoiKy"] = "Nguyễn Ngọc Ẩn";

                        dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                    }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    dt = (DataTable)dgvHDCoQuan.DataSource;
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                        if (!dsBaoCao.Tables["TBDongNuoc"].Rows.Contains(item.Cells["DanhBo_CQ"].Value.ToString().Insert(4, " ").Insert(8, " ")))
                        {
                            DataRow[] drTemp = dt.Select("DanhBo like '" + item.Cells["DanhBo_CQ"].Value.ToString() + "'");

                            string Ky = "";
                            string SoTien = "";
                            int TongCong = 0;
                            int SoPhieu = 0;
                            foreach (DataRow itemChild in drTemp)
                            {
                                Ky += itemChild["Ky"] + "\n";
                                SoTien += String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", itemChild["TongCong"]) + "\n";
                                TongCong += int.Parse(itemChild["TongCong"].ToString());
                                if (string.IsNullOrEmpty(itemChild["SoPhieu"].ToString()) == true)
                                {
                                    SoPhieu = _cQuetTam.GetNextSoPhieu();
                                    TT_QuetTam entity = _cQuetTam.Get(int.Parse(itemChild["ID"].ToString()));
                                    entity.SoPhieu = SoPhieu;
                                    _cQuetTam.SubmitChanges();
                                }
                            }

                            DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                            if (SoPhieu == 0)
                                dr["MaDN"] = item.Cells["SoPhieu_CQ"].Value.ToString().Insert(item.Cells["SoPhieu_CQ"].Value.ToString().Length - 2, "-");
                            else
                                dr["MaDN"] = SoPhieu.ToString().Insert(SoPhieu.ToString().Length - 2, "-");
                            dr["HoTen"] = item.Cells["HoTen_CQ"].Value;
                            dr["DiaChi"] = item.Cells["DiaChi_CQ"].Value;
                            if (!string.IsNullOrEmpty(item.Cells["DanhBo_CQ"].Value.ToString()))
                            {
                                dr["DanhBo"] = item.Cells["DanhBo_CQ"].Value.ToString().Insert(7, " ").Insert(4, " ");
                                dr["DienThoai"] = _cDocSo.GetDienThoai(item.Cells["DanhBo_CQ"].Value.ToString());
                            }
                            dr["MLT"] = item.Cells["MLT_CQ"].Value.ToString().Insert(4, " ").Insert(2, " ");
                            dr["Ky"] = Ky;
                            dr["SoTien"] = SoTien;
                            dr["TongCong"] = TongCong;
                            if (chkChuKy.Checked)
                            {
                                dr["ChuKy"] = true;
                                dr["ChuKyImage"] = Application.StartupPath.ToString() + @"\Resources\chuky.png";
                            }
                            if (chkCoTenNguoiKy.Checked)
                                dr["NguoiKy"] = "Nguyễn Ngọc Ẩn";

                            dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                        }
                }

            rptTBTienNuocPhoto rpt = new rptTBTienNuocPhoto();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();

            //foreach (DataRow item in ds.Tables["TBDongNuoc"].Rows)
            //{
            //    dsBaoCao dsTemp = new dsBaoCao();
            //    DataRow dr = dsTemp.Tables["TBDongNuoc"].NewRow();
            //    dr["HoTen"] = item["HoTen"];
            //    dr["DiaChi"] = item["DiaChi"];
            //    if (!string.IsNullOrEmpty(item["DanhBo"].ToString()))
            //        dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
            //    dr["MLT"] = item["MLT"];
            //    dr["Ky"] = item["Ky"];
            //    dr["SoTien"] = item["SoTien"];
            //    dr["TongCong"] = item["TongCong"];

            //    dsTemp.Tables["TBDongNuoc"].Rows.Add(dr);

            //    rptTBTienNuocPhoto rpt = new rptTBTienNuocPhoto();
            //    rpt.SetDataSource(dsTemp);
            //    //frmBaoCao frm = new frmBaoCao(rpt);
            //    //frm.ShowDialog();
            //    printDialog.AllowSomePages = true;
            //    printDialog.ShowHelp = true;

            //    rpt.PrintOptions.PaperOrientation = rpt.PrintOptions.PaperOrientation;
            //    rpt.PrintOptions.PaperSize = rpt.PrintOptions.PaperSize;
            //    rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

            //    rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, false, 1, 1);
            //}
            //}
        }

        private void btnInTBCatOng_Click(object sender, EventArgs e)
        {
            //PrintDialog printDialog = new PrintDialog();
            //if (printDialog.ShowDialog() == DialogResult.OK)
            //{
            dsBaoCao dsBaoCao = new dsBaoCao();
            DataTable dt = new DataTable();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                dt = (DataTable)dgvHDTuGia.DataSource;

                dsBaoCao.Tables["TBDongNuoc"].PrimaryKey = new DataColumn[] { dsBaoCao.Tables["TBDongNuoc"].Columns["DanhBo"] };
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                    if (!dsBaoCao.Tables["TBDongNuoc"].Rows.Contains(item.Cells["DanhBo_TG"].Value.ToString().Insert(4, " ").Insert(8, " ")))
                    {
                        DataRow[] drTemp = dt.Select("DanhBo like '" + item.Cells["DanhBo_TG"].Value.ToString() + "'");

                        string Ky = "";
                        int TongCong = 0;
                        int SoPhieu = 0;
                        foreach (DataRow itemChild in drTemp)
                        {
                            Ky += itemChild["Ky"] + "  Số tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", itemChild["TongCong"]) + "\n";
                            TongCong += int.Parse(itemChild["TongCong"].ToString());
                            if (string.IsNullOrEmpty(itemChild["SoPhieu"].ToString()) == true)
                            {
                                SoPhieu = _cQuetTam.GetNextSoPhieu();
                                TT_QuetTam entity = _cQuetTam.Get(int.Parse(itemChild["ID"].ToString()));
                                entity.SoPhieu = SoPhieu;
                                _cQuetTam.SubmitChanges();
                            }
                        }

                        DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                        if (SoPhieu == 0)
                            dr["MaDN"] = item.Cells["SoPhieu_TG"].Value.ToString().Insert(item.Cells["SoPhieu_TG"].Value.ToString().Length - 2, "-");
                        else
                            dr["MaDN"] = SoPhieu.ToString().Insert(SoPhieu.ToString().Length - 2, "-");
                        dr["HoTen"] = item.Cells["HoTen_TG"].Value;
                        dr["DiaChi"] = item.Cells["DiaChi_TG"].Value;
                        if (!string.IsNullOrEmpty(item.Cells["DanhBo_TG"].Value.ToString()))
                            dr["DanhBo"] = item.Cells["DanhBo_TG"].Value.ToString().Insert(7, " ").Insert(4, " ");
                        dr["MLT"] = item.Cells["MLT_TG"].Value.ToString().Insert(4, " ").Insert(2, " ");
                        dr["HopDong"] = item.Cells["HopDong_TG"].Value;
                        dr["HanhThu"] = item.Cells["HanhThu_TG"].Value;
                        dr["Ky"] = Ky;
                        dr["TongCong"] = TongCong;
                        if (chkChuKy.Checked)
                        {
                            dr["ChuKy"] = true;
                            dr["ChuKyImage"] = Application.StartupPath.ToString() + @"\Resources\chuky.png";
                        }
                        if (chkCoTenNguoiKy.Checked)
                            dr["NguoiKy"] = CNguoiKy.getNguoiKy();

                        dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                    }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    dt = (DataTable)dgvHDCoQuan.DataSource;

                    dsBaoCao.Tables["TBDongNuoc"].PrimaryKey = new DataColumn[] { dsBaoCao.Tables["TBDongNuoc"].Columns["DanhBo"] };
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                        if (!dsBaoCao.Tables["TBDongNuoc"].Rows.Contains(item.Cells["DanhBo_CQ"].Value.ToString().Insert(4, " ").Insert(8, " ")))
                        {
                            DataRow[] drTemp = dt.Select("DanhBo like '" + item.Cells["DanhBo_CQ"].Value.ToString() + "'");

                            string Ky = "";
                            int TongCong = 0;
                            int SoPhieu = 0;
                            foreach (DataRow itemChild in drTemp)
                            {
                                Ky += itemChild["Ky"] + "  Số tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", itemChild["TongCong"]) + "\n";
                                TongCong += int.Parse(itemChild["TongCong"].ToString());
                                if (string.IsNullOrEmpty(itemChild["SoPhieu"].ToString()) == true)
                                {
                                    SoPhieu = _cQuetTam.GetNextSoPhieu();
                                    TT_QuetTam entity = _cQuetTam.Get(int.Parse(itemChild["ID"].ToString()));
                                    entity.SoPhieu = SoPhieu;
                                    _cQuetTam.SubmitChanges();
                                }
                            }

                            DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                            if (SoPhieu == 0)
                                dr["MaDN"] = item.Cells["SoPhieu_CQ"].Value.ToString().Insert(item.Cells["SoPhieu_CQ"].Value.ToString().Length - 2, "-");
                            else
                                dr["MaDN"] = SoPhieu.ToString().Insert(SoPhieu.ToString().Length - 2, "-");
                            dr["HoTen"] = item.Cells["HoTen_CQ"].Value;
                            dr["DiaChi"] = item.Cells["DiaChi_CQ"].Value;
                            if (!string.IsNullOrEmpty(item.Cells["DanhBo_CQ"].Value.ToString()))
                                dr["DanhBo"] = item.Cells["DanhBo_CQ"].Value.ToString().Insert(7, " ").Insert(4, " ");
                            dr["MLT"] = item.Cells["MLT_CQ"].Value.ToString().Insert(4, " ").Insert(2, " ");
                            dr["HopDong"] = item.Cells["HopDong_CQ"].Value;
                            dr["Ky"] = Ky;
                            dr["TongCong"] = TongCong;
                            if (chkChuKy.Checked)
                            {
                                dr["ChuKy"] = true;
                                dr["ChuKyImage"] = Application.StartupPath.ToString() + @"\Resources\chuky.png";
                            }
                            if (chkCoTenNguoiKy.Checked)
                                dr["NguoiKy"] = CNguoiKy.getNguoiKy();

                            dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                        }
                }

            rptTBCatOngPhoto rpt = new rptTBCatOngPhoto();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();

            //    foreach (DataRow item in ds.Tables["TBDongNuoc"].Rows)
            //    {
            //        dsBaoCao dsTemp = new dsBaoCao();
            //        DataRow dr = dsTemp.Tables["TBDongNuoc"].NewRow();
            //        dr["MaDN"] = dr["MaDN"];
            //        dr["HoTen"] = item["HoTen"];
            //        dr["DiaChi"] = item["DiaChi"];
            //        if (!string.IsNullOrEmpty(item["DanhBo"].ToString()))
            //            dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
            //        dr["MLT"] = item["MLT"];
            //        dr["HopDong"] = item["HopDong"];
            //        dr["Ky"] = item["Ky"];
            //        dr["TongCong"] = item["TongCong"];

            //        dsTemp.Tables["TBDongNuoc"].Rows.Add(dr);

            //        rptTBCatOngPhoto rpt = new rptTBCatOngPhoto();
            //        rpt.SetDataSource(dsTemp);
            //        //frmBaoCao frm = new frmBaoCao(rpt);
            //        //frm.ShowDialog();
            //        printDialog.AllowSomePages = true;
            //        printDialog.ShowHelp = true;

            //        rpt.PrintOptions.PaperOrientation = rpt.PrintOptions.PaperOrientation;
            //        rpt.PrintOptions.PaperSize = rpt.PrintOptions.PaperSize;
            //        rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

            //        rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, false, 1, 1);
            //    }
            //}
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (ListViewItem item in lstHD.Items)
            {
                str += item.Text + "\n";
            }
            Clipboard.SetText(str);
        }

        private void btnInGiayXN_Click(object sender, EventArgs e)
        {
            dsBaoCao dsBaoCao = new dsBaoCao();
            DataTable dt = new DataTable();
            dsBaoCao.Tables["TBDongNuoc"].PrimaryKey = new DataColumn[] { dsBaoCao.Tables["TBDongNuoc"].Columns["DanhBo"] };

            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                dt = (DataTable)dgvHDTuGia.DataSource;
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                    if (!dsBaoCao.Tables["TBDongNuoc"].Rows.Contains(item.Cells["DanhBo_TG"].Value.ToString().Insert(7, " ").Insert(4, " ")))
                    {
                        string Ky = "";
                        int TongCong = 0;
                        DataRow[] drTemp = dt.Select("DanhBo like '" + item.Cells["DanhBo_TG"].Value.ToString() + "'");

                        foreach (DataRow itemChild in drTemp)
                        {
                            if (string.IsNullOrEmpty(Ky))
                                Ky += itemChild["Ky"];
                            else
                                Ky += ", " + itemChild["Ky"];
                            TongCong += int.Parse(itemChild["TongCong"].ToString());
                        }

                        DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                        dr["DiaChi"] = item.Cells["DiaChi_TG"].Value.ToString();
                        if (!string.IsNullOrEmpty(item.Cells["DanhBo_TG"].Value.ToString()))
                            dr["DanhBo"] = item.Cells["DanhBo_TG"].Value.ToString().Insert(7, " ").Insert(4, " ");
                        dr["MLT"] = item.Cells["MLT_TG"].Value.ToString().Insert(4, " ").Insert(2, " ");
                        dr["Ky"] = Ky;
                        dr["SoTien"] = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);

                        dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                    }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    dt = (DataTable)dgvHDCoQuan.DataSource;
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                        if (!dsBaoCao.Tables["TBDongNuoc"].Rows.Contains(item.Cells["DanhBo_CQ"].Value.ToString().Insert(7, " ").Insert(4, " ")))
                        {
                            string Ky = "";
                            int TongCong = 0;
                            DataRow[] drTemp = dt.Select("DanhBo like '" + item.Cells["DanhBo_CQ"].Value.ToString() + "'");

                            foreach (DataRow itemChild in drTemp)
                            {
                                if (string.IsNullOrEmpty(Ky))
                                    Ky += itemChild["Ky"];
                                else
                                    Ky += ", " + itemChild["Ky"];
                                TongCong += int.Parse(itemChild["TongCong"].ToString());
                            }

                            DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                            dr["DiaChi"] = item.Cells["DiaChi_CQ"].Value.ToString();
                            if (!string.IsNullOrEmpty(item.Cells["DanhBo_CQ"].Value.ToString()))
                                dr["DanhBo"] = item.Cells["DanhBo_CQ"].Value.ToString().Insert(7, " ").Insert(4, " ");
                            dr["MLT"] = item.Cells["MLT_CQ"].Value.ToString().Insert(4, " ").Insert(2, " ");
                            dr["Ky"] = Ky;
                            dr["SoTien"] = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);

                            dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                        }
                }

            rptGiayXacNhanNoKhoDoi rpt = new rptGiayXacNhanNoKhoDoi();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dialog.ShowDialog() == DialogResult.OK)
                        if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            CExcel fileExcel = new CExcel(dialog.FileName);
                            DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");

                            foreach (DataRow item in dtExcel.Rows)
                                if (item[0].ToString().Trim().Replace(" ", "").Length == 11)
                                {
                                    HOADON hoadon = _cHoaDon.GetMoiNhat(item[0].ToString().Trim().Replace(" ", ""));
                                    if (hoadon != null && !_cQuetTam.CheckExist(hoadon.SOHOADON, CNguoiDung.MaND, DateTime.Now))
                                    {
                                        TT_QuetTam quettam = new TT_QuetTam();
                                        quettam.MaHD = hoadon.ID_HOADON;
                                        quettam.SoHoaDon = hoadon.SOHOADON;
                                        _cQuetTam.Them(quettam);
                                    }
                                }
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXem.PerformClick();
                        }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                //Tạo các đối tượng Excel
                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbooks oBooks;
                Microsoft.Office.Interop.Excel.Sheets oSheets;
                Microsoft.Office.Interop.Excel.Workbook oBook;
                Microsoft.Office.Interop.Excel.Worksheet oSheet;
                //Microsoft.Office.Interop.Excel.Worksheet oSheetCQ;

                //Tạo mới một Excel WorkBook 
                oExcel.Visible = true;
                oExcel.DisplayAlerts = false;
                //khai báo số lượng sheet
                oExcel.Application.SheetsInNewWorkbook = 1;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;
                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

                XuatExcel((DataTable)dgvHDTuGia.DataSource, oSheet, "HÓA ĐƠN");
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    //Tạo các đối tượng Excel
                    Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbooks oBooks;
                    Microsoft.Office.Interop.Excel.Sheets oSheets;
                    Microsoft.Office.Interop.Excel.Workbook oBook;
                    Microsoft.Office.Interop.Excel.Worksheet oSheet;
                    //Microsoft.Office.Interop.Excel.Worksheet oSheetCQ;

                    //Tạo mới một Excel WorkBook 
                    oExcel.Visible = true;
                    oExcel.DisplayAlerts = false;
                    //khai báo số lượng sheet
                    oExcel.Application.SheetsInNewWorkbook = 1;
                    oBooks = oExcel.Workbooks;

                    oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                    oSheets = oBook.Worksheets;
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

                    XuatExcel((DataTable)dgvHDCoQuan.DataSource, oSheet, "CƠ QUAN");
                }
        }

        private void XuatExcel(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName)
        {
            string Phuong, Quan;

            oSheet.Name = SheetName;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
            cl1.Value2 = "Số Hóa Đơn";
            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
            cl2.Value2 = "Kỳ";
            cl2.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
            cl3.Value2 = "Danh Bộ";
            cl3.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
            cl4.Value2 = "Khách Hàng";
            cl4.ColumnWidth = 25;

            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("E1", "E1");
            cl12.Value2 = "Địa Chỉ";
            cl12.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("F1", "F1");
            cl5.Value2 = "MLT";
            cl5.ColumnWidth = 10;


            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("G1", "G1");
            cl9.Value2 = "Tổng Cộng";
            cl9.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("H1", "H1");
            cl10.Value2 = "Phường";
            cl10.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("I1", "I1");
            cl11.Value2 = "Quận";
            cl11.ColumnWidth = 10;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 9];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = dr["SoHoaDon"].ToString();
                arr[i, 1] = dr["Ky"].ToString();
                arr[i, 2] = dr["DanhBo"].ToString();
                arr[i, 3] = dr["HoTen"].ToString();
                arr[i, 4] = dr["DiaChi"].ToString();
                arr[i, 5] = dr["MLT"].ToString();
                arr[i, 6] = dr["TongCong"].ToString();
                _cDocSo.GetPhuongQuan(dr["DanhBo"].ToString(), out Phuong, out Quan);
                arr[i, 7] = Phuong;
                arr[i, 8] = Quan;
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 9;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            c3b.NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
            Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
            Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
            c3d.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }

        private void btnInDSTon_Click(object sender, EventArgs e)
        {
            dsBaoCao dsBaoCao = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                    if (item.Cells["NgayGiaiTrach_TG"].Value == null || item.Cells["NgayGiaiTrach_TG"].Value.ToString() == "")
                    {
                        DataRow dr = dsBaoCao.Tables["TamThuChuyenKhoan"].NewRow();
                        dr["TuNgay"] = DateTime.Now.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = DateTime.Now.ToString("dd/MM/yyyy");
                        dr["LoaiBaoCao"] = "HÓA ĐƠN TỒN";
                        dr["DanhBo"] = item.Cells["DanhBo_TG"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["HoTen"] = item.Cells["HoTen_TG"].Value.ToString();
                        dr["MLT"] = item.Cells["MLT_TG"].Value.ToString().ToString().Insert(4, " ").Insert(2, " ");
                        dr["Ky"] = item.Cells["Ky_TG"].Value.ToString();
                        dr["TongCong"] = item.Cells["TongCong_TG"].Value.ToString();
                        dr["HanhThu"] = item.Cells["HanhThu_TG"].Value.ToString();
                        dr["To"] = item.Cells["To_TG"].Value.ToString();
                        if (int.Parse(item.Cells["GiaBieu_TG"].Value.ToString()) > 20)
                            dr["Loai"] = "CQ";
                        else
                            dr["Loai"] = "TG";
                        dsBaoCao.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                    }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                    {
                        DataRow dr = dsBaoCao.Tables["TamThuChuyenKhoan"].NewRow();
                        dr["TuNgay"] = DateTime.Now.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = DateTime.Now.ToString("dd/MM/yyyy");
                        dr["LoaiBaoCao"] = "HÓA ĐƠN CƠ QUAN";
                        dr["DanhBo"] = item.Cells["DanhBo_CQ"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["HoTen"] = item.Cells["HoTen_CQ"].Value.ToString();
                        dr["MLT"] = item.Cells["MLT_CQ"].Value.ToString().ToString().Insert(4, " ").Insert(2, " ");
                        dr["Ky"] = item.Cells["Ky_CQ"].Value.ToString();
                        dr["TongCong"] = item.Cells["TongCong_CQ"].Value.ToString();
                        dr["HanhThu"] = item.Cells["HanhThu_CQ"].Value.ToString();
                        dr["To"] = item.Cells["To_CQ"].Value.ToString();
                        if (int.Parse(item.Cells["GiaBieu_CQ"].Value.ToString()) > 20)
                            dr["Loai"] = "CQ";
                        else
                            dr["Loai"] = "TG";
                        dsBaoCao.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                    }
                }

            rptDSTamThuChuyenKhoan rpt = new rptDSTamThuChuyenKhoan();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnInDSCodeF2_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                    if (item.Cells["NgayGiaiTrach_TG"].Value == null || item.Cells["NgayGiaiTrach_TG"].Value.ToString() == "")
                    {
                        DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                        dr["LoaiBaoCao"] = item.Cells["MLT_TG"].Value.ToString().Substring(0, 2);
                        dr["DanhBo"] = item.Cells["DanhBo_TG"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["Ky"] = item.Cells["Ky_TG"].Value;
                        dr["MLT"] = item.Cells["MLT_TG"].Value.ToString().Insert(4, " ").Insert(2, " ");
                        dr["TongCong"] = item.Cells["TongCong_TG"].Value;
                        dr["SoPhatHanh"] = item.Cells["SoPhatHanh_TG"].Value;
                        dr["SoHoaDon"] = item.Cells["SoHoaDon_TG"].Value;
                        if (int.Parse(item.Cells["GiaBieu_TG"].Value.ToString()) > 20)
                            dr["Loai"] = "CQ";
                        else
                            dr["Loai"] = "TG";
                        //if (CNguoiDung.ToTruong)
                        //    dr["NhanVien"] = ((TT_NguoiDung)cmbNhanVien.SelectedItem).HoTen;
                        //else
                        //    dr["NhanVien"] = CNguoiDung.HoTen;
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
                        dr["MLT"] = item.Cells["MLT_CQ"].Value.ToString().Insert(4, " ").Insert(2, " ");
                        dr["TongCong"] = item.Cells["TongCong_CQ"].Value;
                        dr["SoPhatHanh"] = item.Cells["SoPhatHanh_CQ"].Value;
                        dr["SoHoaDon"] = item.Cells["SoHoaDon_CQ"].Value;
                        //if (CNguoiDung.ToTruong)
                        //    dr["NhanVien"] = ((TT_NguoiDung)cmbNhanVien.SelectedItem).HoTen;
                        //else
                        //    dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["DSHoaDon"].Rows.Add(dr);
                    }
                }
            rptDSHoaDonCodeF2 rpt = new rptDSHoaDonCodeF2();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnInTieuDe_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                    dr["LoaiBaoCao"] = txtTieuDe.Text.Trim();
                    dr["DanhBo"] = item.Cells["DanhBo_TG"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["Ky"] = item.Cells["Ky_TG"].Value;
                    dr["MLT"] = item.Cells["MLT_TG"].Value.ToString().Insert(4, " ").Insert(2, " ");
                    dr["TongCong"] = item.Cells["TongCong_TG"].Value;
                    dr["GiaBieu"] = item.Cells["GiaBieu"].Value;
                    dr["DinhMuc"] = item.Cells["DinhMuc"].Value;
                    dr["DinhMucHN"] = item.Cells["DinhMucHN"].Value;
                    dr["TieuThu"] = item.Cells["TieuThu"].Value;
                    if (int.Parse(item.Cells["GiaBieu_TG"].Value.ToString()) > 20)
                        dr["Loai"] = "CQ";
                    else
                        dr["Loai"] = "TG";
                    dr["NhanVien"] = CNguoiDung.HoTen;
                    ds.Tables["DSHoaDon"].Rows.Add(dr);
                }
            }

            rptDSHoaDon_TieuDe rpt = new rptDSHoaDon_TieuDe();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnChuyenCodeF2toDCHD_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDCHD", "Them"))
            {
                if (MessageBox.Show("Bạn có chắc chắn chuyển?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    CDCHD _cDCHD = new CDCHD();
                    foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                        if (item.Cells["NgayGiaiTrach_TG"].Value == null || item.Cells["NgayGiaiTrach_TG"].Value.ToString() == "")
                        {
                            HOADON hd = _cHoaDon.GetMoiNhat(item.Cells["DanhBo_TG"].Value.ToString());
                            if (_cDCHD.CheckExist(hd.ID_HOADON) == false)
                            {
                                DIEUCHINH_HD dchd = new DIEUCHINH_HD();
                                dchd.FK_HOADON = hd.ID_HOADON;
                                dchd.SoHoaDon = hd.SOHOADON;
                                dchd.GiaBieu = hd.GB;
                                if (hd.DM != null)
                                    dchd.DinhMuc = (int)hd.DM;
                                dchd.TIEUTHU_BD = (int)hd.TIEUTHU;
                                dchd.GIABAN_BD = hd.GIABAN;
                                dchd.PHI_BD = hd.PHI;
                                dchd.THUE_BD = hd.THUE;
                                dchd.TONGCONG_BD = hd.TONGCONG;
                                dchd.NGAY_DC = DateTime.Now;
                                dchd.CodeF2 = true;

                                if (_cDCHD.Them(dchd))
                                {

                                }
                            }
                        }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}

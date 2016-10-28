using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.Doi;
using ThuTien.DAL.Quay;
using ThuTien.LinQ;
using ThuTien.BaoCao;
using ThuTien.BaoCao.ChuyenKhoan;
using ThuTien.GUI.BaoCao;
using ThuTien.BaoCao.Quay;

namespace ThuTien.GUI.Quay
{
    public partial class frmQuetGiaoTon : Form
    {
        string _mnu = "mnuQuetGiaoTon";
        CHoaDon _cHoaDon = new CHoaDon();
        CQuetGiaoTon _cQuetGiaoTon = new CQuetGiaoTon();
        CTo _cTo = new CTo();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        bool _flagLoadFirst = false;

        public frmQuetGiaoTon()
        {
            InitializeComponent();
        }

        private void frmQuetGiaoTon_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            List<TT_To> _lstTo = _cTo.GetDSHanhThu();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            _lstTo.Insert(0, to);
            cmbTo.DataSource = _lstTo;
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";

            _flagLoadFirst = true;
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

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (ListViewItem item in lstHD.Items)
            {
                str += item.Text + "\n";
            }
            Clipboard.SetText(str);
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
                        item.Selected = true;
                        item.Focused = true;
                        return;
                    }
                }
                try
                {
                    foreach (ListViewItem item in lstHD.Items)
                        if (!_cQuetGiaoTon.CheckExist(item.Text, DateTime.Now))
                        {
                            TT_QuetGiaoTon quetgiaoton = new TT_QuetGiaoTon();
                            quetgiaoton.MaHD = _cHoaDon.Get(item.Text).ID_HOADON;
                            quetgiaoton.SoHoaDon = item.Text;
                            _cQuetGiaoTon.Them(quetgiaoton);
                        }
                    lstHD.Items.Clear();
                    btnXem.PerformClick();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
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
                            foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                            {
                                TT_QuetGiaoTon quetgiaoton = _cQuetGiaoTon.Get(int.Parse(item.Cells["ID_TG"].Value.ToString()));
                                _cQuetGiaoTon.Xoa(quetgiaoton);
                            }
                            lstHD.Items.Clear();
                            btnXem.PerformClick();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        if (tabControl.SelectedTab.Name == "tabCoQuan")
                        {
                            try
                            {
                                foreach (DataGridViewRow item in dgvHDCoQuan.SelectedRows)
                                {
                                    TT_QuetGiaoTon quetgiaoton = _cQuetGiaoTon.Get(int.Parse(item.Cells["ID_CQ"].Value.ToString()));
                                    _cQuetGiaoTon.Xoa(quetgiaoton);
                                }
                                lstHD.Items.Clear();
                                btnXem.PerformClick();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnInPhieuBao_Click(object sender, EventArgs e)
        {
            dsBaoCao dsBaoCao = new dsBaoCao();
            //if (tabControl.SelectedTab.Name == "tabTuGia")
            //{
            //    foreach (DataGridViewRow item in dgvHDTuGia.Rows)
            //    {
            //        DataRow dr = dsBaoCao.Tables["DSHoaDon"].NewRow();
            //        dr["LoaiBaoCao"] = "TƯ GIA";
            //        dr["Dot"] = item.Cells["MLT_TG"].Value.ToString().Substring(0, 2);
            //        dr["SoHoaDon"] = item.Cells["SoHoaDon_TG"].Value.ToString();
            //        dr["TongCong"] = item.Cells["TongCong_TG"].Value.ToString();
            //        dr["HanhThu"] = item.Cells["HanhThu_TG"].Value.ToString();
            //        dr["To"] = item.Cells["To_TG"].Value.ToString();
            //        dr["NgayLap"] = dateLap.Value.ToString("dd/MM/yyyy");
            //        dsBaoCao.Tables["DSHoaDon"].Rows.Add(dr);
            //    }
            //}
            //else
            //    if (tabControl.SelectedTab.Name == "tabCoQuan")
            //    {
            //        foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
            //        {
            //            DataRow dr = dsBaoCao.Tables["DSHoaDon"].NewRow();
            //            dr["LoaiBaoCao"] = "CƠ QUAN";
            //            dr["Dot"] = item.Cells["MLT_CQ"].Value.ToString().Substring(0, 2);
            //            dr["SoHoaDon"] = item.Cells["SoHoaDon_CQ"].Value.ToString();
            //            dr["TongCong"] = item.Cells["TongCong_CQ"].Value.ToString();
            //            dr["HanhThu"] = item.Cells["HanhThu_CQ"].Value.ToString();
            //            dr["To"] = item.Cells["To_CQ"].Value.ToString();
            //            dr["NgayLap"] = dateLap.Value.ToString("dd/MM/yyyy");
            //            dsBaoCao.Tables["DSHoaDon"].Rows.Add(dr);
            //        }
            //    }

            DataTable dt = new DataTable();
            ///chọn tất cả các tổ
            if (cmbTo.SelectedIndex == 0)
            {
                dt = _cQuetGiaoTon.GetDS("TG",dateLap.Value.Date);
                dt.Merge(_cQuetGiaoTon.GetDS("CQ", dateLap.Value.Date));
            }
            else
                ///chọn 1 tổ cụ thể
                if (cmbTo.SelectedIndex > 0)
                    ///chọn tất cả nhân viên
                    if (cmbNhanVien.SelectedIndex == 0)
                    {
                        dt = _cQuetGiaoTon.GetDSByMaTo("TG", int.Parse(cmbTo.SelectedValue.ToString()), dateLap.Value.Date);
                        dt.Merge(_cQuetGiaoTon.GetDSByMaTo("CQ", int.Parse(cmbTo.SelectedValue.ToString()), dateLap.Value.Date));
                    }
                    else
                        ///chọn 1 nhân viên cụ thể
                        if (cmbNhanVien.SelectedIndex > 0)
                        {
                            dt = _cQuetGiaoTon.GetDSByMaNV("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), dateLap.Value.Date);
                            dt.Merge(_cQuetGiaoTon.GetDSByMaNV("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), dateLap.Value.Date));
                        }

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSHoaDon"].NewRow();
                dr["LoaiBaoCao"] = item["Loai"].ToString();
                dr["Dot"] = item["MLT"].ToString().Substring(0, 2);
                dr["SoHoaDon"] = item["SoHoaDon"].ToString();
                dr["TongCong"] = item["TongCong"].ToString();
                dr["HanhThu"] = item["HanhThu"].ToString();
                dr["To"] = item["To"].ToString();
                dr["NgayLap"] = dateLap.Value.ToString("dd/MM/yyyy");
                dsBaoCao.Tables["DSHoaDon"].Rows.Add(dr);
            }

            rptPhieuBaoGiaoTon rpt = new rptPhieuBaoGiaoTon();
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
                    dr["LoaiBaoCao"] = "HÓA ĐƠN TƯ GIA";
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

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagLoadFirst == true && cmbTo.SelectedIndex > 0)
            {
                List<TT_NguoiDung> _lstND = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
                if ((_cTo.CheckHanhThu(int.Parse(cmbTo.SelectedValue.ToString()))))
                    _lstND = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbTo.SelectedValue.ToString()));
                else
                    _lstND = _cNguoiDung.GetDSByToVanPhong(int.Parse(cmbTo.SelectedValue.ToString()));

                TT_NguoiDung nguoidung = new TT_NguoiDung();
                nguoidung.MaND = 0;
                nguoidung.HoTen = "Tất Cả";
                _lstND.Insert(0, nguoidung);
                cmbNhanVien.DataSource = _lstND;
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaND";
            }
            else
                cmbNhanVien.DataSource = null;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                ///chọn tất cả các tổ
                if (cmbTo.SelectedIndex == 0)
                    dgvHDTuGia.DataSource = _cQuetGiaoTon.GetDS("TG", dateLap.Value.Date);
                else
                    ///chọn 1 tổ cụ thể
                    if (cmbTo.SelectedIndex > 0)
                        ///chọn tất cả nhân viên
                        if (cmbNhanVien.SelectedIndex == 0)
                            dgvHDTuGia.DataSource = _cQuetGiaoTon.GetDSByMaTo("TG", int.Parse(cmbTo.SelectedValue.ToString()), dateLap.Value.Date);
                        else
                            ///chọn 1 nhân viên cụ thể
                            if (cmbNhanVien.SelectedIndex > 0)
                                dgvHDTuGia.DataSource = _cQuetGiaoTon.GetDSByMaNV("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), dateLap.Value.Date);
                CountdgvHDTuGia();
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    ///chọn tất cả các tổ
                    if (cmbTo.SelectedIndex == 0)
                        dgvHDCoQuan.DataSource = _cQuetGiaoTon.GetDS("CQ", dateLap.Value.Date);
                    else
                        ///chọn 1 tổ cụ thể
                        if (cmbTo.SelectedIndex > 0)
                            ///chọn tất cả nhân viên
                            if (cmbNhanVien.SelectedIndex == 0)
                                dgvHDCoQuan.DataSource = _cQuetGiaoTon.GetDSByMaTo("CQ", int.Parse(cmbTo.SelectedValue.ToString()), dateLap.Value.Date);
                            else
                                ///chọn 1 nhân viên cụ thể
                                if (cmbNhanVien.SelectedIndex > 0)
                                    dgvHDCoQuan.DataSource = _cQuetGiaoTon.GetDSByMaNV("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), dateLap.Value.Date);
                    CountdgvHDCoQuan();
                }
            
        }

        private void btnInDS_Click(object sender, EventArgs e)
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
                    dr["MLT"] = item.Cells["MLT_TG"].Value.ToString().Insert(4, " ").Insert(2, " ");
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
                        dr["MLT"] = item.Cells["MLT_CQ"].Value.ToString().Insert(4, " ").Insert(2, " ");
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
            frm.Show();
        }

        

    }
}

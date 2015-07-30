using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.QuanTri;
using System.Globalization;
using ThuTien.BaoCao;
using ThuTien.BaoCao.ToTruong;
using KTKS_DonKH.GUI.BaoCao;
using ThuTien.LinQ;
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL.Quay;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmHDTienLonTo : Form
    {
        //string _mnu = "mnuHDTienLon";
        CHoaDon _cHoaDon = new CHoaDon();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CHoaDon _cHoaNuoc = new CHoaDon();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CLenhHuy _cLenhHuy = new CLenhHuy();

        List<TT_NguoiDung> _lst;

        public frmHDTienLonTo()
        {
            InitializeComponent();
        }

        private void frmHDTienLon_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";

            _lst = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
            TT_NguoiDung nguoidung = new TT_NguoiDung();
            nguoidung.MaND = 0;
            nguoidung.HoTen = "Tất Cả";
            _lst.Insert(0, nguoidung);
            cmbNhanVien.DataSource = _lst;
            cmbNhanVien.DisplayMember = "HoTen";
            cmbNhanVien.ValueMember = "MaND";

            lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                ///chọn tất cả các kỳ
                if (cmbKy.SelectedIndex == 0)
                {
                    if (cmbNhanVien.SelectedIndex == 0)
                    {
                        DataTable dt = new DataTable();
                        foreach (TT_NguoiDung item in _lst)
                        {
                            dt.Merge(_cHoaDon.GetDSByTienLon_To("TG", item.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                        }
                        dgvHDTuGia.DataSource = dt;
                    }
                    else
                        if (cmbNhanVien.SelectedIndex > 0)
                            dgvHDTuGia.DataSource = _cHoaDon.GetDSByTienLon_To("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                }
                ///chọn 1 kỳ cụ thể
                else
                    if (cmbKy.SelectedIndex > 0)
                        ///chọn tất cả các đợt
                        if (cmbDot.SelectedIndex == 0)
                        {
                            if (cmbNhanVien.SelectedIndex == 0)
                            {
                                DataTable dt = new DataTable();
                                foreach (TT_NguoiDung item in _lst)
                                {
                                    dt.Merge(_cHoaDon.GetDSByTienLon_To("TG", item.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                                }
                                dgvHDTuGia.DataSource = dt;
                            }
                            else
                                if (cmbNhanVien.SelectedIndex > 0)
                                    dgvHDTuGia.DataSource = _cHoaDon.GetDSByTienLon_To("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                        }
                        ///chọn 1 đợt cụ thể
                        else
                            if (cmbDot.SelectedIndex > 0)
                            {
                                if (cmbNhanVien.SelectedIndex == 0)
                                {
                                    DataTable dt = new DataTable();
                                    foreach (TT_NguoiDung item in _lst)
                                    {
                                        dt.Merge(_cHoaDon.GetDSByTienLon_To("TG", item.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                                    }
                                    dgvHDTuGia.DataSource = dt;
                                }
                                else
                                    if (cmbNhanVien.SelectedIndex > 0)
                                        dgvHDTuGia.DataSource = _cHoaDon.GetDSByTienLon_To("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                            }
                dgvHDTuGia.Sort(dgvHDTuGia.Columns["NgayGiaiTrach_TG"], ListSortDirection.Ascending);
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    if (_cDongNuoc.CheckCTDongNuocBySoHoaDon(item.Cells["SoHoaDon_TG"].Value.ToString()))
                        item.DefaultCellStyle.BackColor = Color.Yellow;
                    if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon_TG"].Value.ToString()))
                        item.DefaultCellStyle.BackColor = Color.Red;
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    ///chọn tất cả các kỳ
                    if (cmbKy.SelectedIndex == 0)
                    {
                        if (cmbNhanVien.SelectedIndex == 0)
                        {
                            DataTable dt = new DataTable();
                            foreach (TT_NguoiDung item in _lst)
                            {
                                dt.Merge(_cHoaDon.GetDSByTienLon_To("CQ", item.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                            }
                            dgvHDCoQuan.DataSource = dt;
                        }
                        else
                            if (cmbNhanVien.SelectedIndex > 0)
                                dgvHDCoQuan.DataSource = _cHoaDon.GetDSByTienLon_To("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                    }
                    ///chọn 1 kỳ cụ thể
                    else
                        if (cmbKy.SelectedIndex > 0)
                            ///chọn tất cả các đợt
                            if (cmbDot.SelectedIndex == 0)
                            {
                                if (cmbNhanVien.SelectedIndex == 0)
                                {
                                    DataTable dt = new DataTable();
                                    foreach (TT_NguoiDung item in _lst)
                                    {
                                        dt.Merge(_cHoaDon.GetDSByTienLon_To("CQ", item.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                                    }
                                    dgvHDCoQuan.DataSource = dt;
                                }
                                else
                                    if (cmbNhanVien.SelectedIndex > 0)
                                        dgvHDCoQuan.DataSource = _cHoaDon.GetDSByTienLon_To("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                            }
                            ///chọn 1 đợt cụ thể
                            else
                                if (cmbDot.SelectedIndex > 0)
                                {
                                    if (cmbNhanVien.SelectedIndex == 0)
                                    {
                                        DataTable dt = new DataTable();
                                        foreach (TT_NguoiDung item in _lst)
                                        {
                                            dt.Merge(_cHoaDon.GetDSByTienLon_To("CQ", item.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                                        }
                                        dgvHDCoQuan.DataSource = dt;
                                    }
                                    else
                                        if (cmbNhanVien.SelectedIndex > 0)
                                            dgvHDCoQuan.DataSource = _cHoaDon.GetDSByTienLon_To("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                                }
                    dgvHDCoQuan.Sort(dgvHDCoQuan.Columns["NgayGiaiTrach_CQ"], ListSortDirection.Ascending);
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                    {
                        if (_cDongNuoc.CheckCTDongNuocBySoHoaDon(item.Cells["SoHoaDon_CQ"].Value.ToString()))
                            item.DefaultCellStyle.BackColor = Color.Yellow;
                        if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon_CQ"].Value.ToString()))
                            item.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                btnXem.PerformClick();
        }

        private void txtSoTien_Leave(object sender, EventArgs e)
        {
            txtSoTien.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
        }

        private void dgvHDTuGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TieuThu_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "GiaBan_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "ThueGTGT_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "PhiBVMT_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCong_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
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
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TieuThu_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "GiaBan_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "ThueGTGT_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "PhiBVMT_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCong_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDCoQuan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDCoQuan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnInDSTon_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                    if(string.IsNullOrEmpty(item.Cells["NgayGiaiTrach_TG"].Value.ToString()))
                {
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["LoaiBaoCao"] = "TƯ GIA";
                    dr["DanhBo"] = item.Cells["DanhBo_TG"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["DiaChi"] = item.Cells["DiaChi_TG"].Value;
                    dr["Ky"] = item.Cells["Ky_TG"].Value;
                    dr["TongCong"] = item.Cells["TongCong_TG"].Value;
                    dr["SoHoaDon"] = item.Cells["SoHoaDon_TG"].Value;
                    dr["NhanVien"] = item.Cells["HanhThu_TG"].Value.ToString();
                    dr["To"] = CNguoiDung.TenTo;
                    ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                        if (string.IsNullOrEmpty(item.Cells["NgayGiaiTrach_CQ"].Value.ToString()))
                    {
                        DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                        dr["LoaiBaoCao"] = "CƠ QUAN";
                        dr["DanhBo"] = item.Cells["DanhBo_CQ"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["DiaChi"] = item.Cells["DiaChi_CQ"].Value;
                        dr["Ky"] = item.Cells["Ky_CQ"].Value;
                        dr["TongCong"] = item.Cells["TongCong_CQ"].Value;
                        dr["SoHoaDon"] = item.Cells["SoHoaDon_CQ"].Value;
                        dr["NhanVien"] = item.Cells["HanhThu_CQ"].Value.ToString();
                        dr["To"] = CNguoiDung.TenTo;
                        ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                    }
                }
            rptDSHoaDonTienLon rpt = new rptDSHoaDonTienLon();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }
 
    }
}

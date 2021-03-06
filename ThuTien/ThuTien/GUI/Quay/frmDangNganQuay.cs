﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.Quay;
using System.Globalization;
using ThuTien.DAL.TongHop;
using ThuTien.BaoCao;
using ThuTien.BaoCao.NhanVien;
using ThuTien.GUI.BaoCao;
using ThuTien.GUI.TimKiem;
using ThuTien.BaoCao.Quay;

namespace ThuTien.GUI.Quay
{
    public partial class frmDangNganQuay : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();
        string _mnu = "mnuDangNganQuay";
        CTamThu _cTamThu = new CTamThu();
        CDCHD _cDCHD = new CDCHD();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CChotDangNgan _cChotDangNgan = new CChotDangNgan();

        public frmDangNganQuay()
        {
            InitializeComponent();
        }

        private void frmDangNganQuay_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "ID";
            cmbNam.ValueMember = "Nam";

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;

            tabTuGia.Text = "Hóa Đơn";
            tabControl.TabPages.Remove(tabCoQuan);
        }

        public void CountdgvHDTuGia()
        {
            long TongGiaBan = 0;
            long TongThueGTGT = 0;
            long TongPhiBVMT = 0;
            long TongCong = 0;
            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    TongGiaBan += long.Parse(item.Cells["GiaBan_TG"].Value.ToString());
                    TongThueGTGT += long.Parse(item.Cells["ThueGTGT_TG"].Value.ToString());
                    TongPhiBVMT += long.Parse(item.Cells["PhiBVMT_TG"].Value.ToString());
                    TongCong += long.Parse(item.Cells["TongCong_TG"].Value.ToString());
                }
                txtTongHD_TG.Text = dgvHDTuGia.RowCount.ToString();
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHDTuGia.RowCount);
                txtTongGiaBan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        public void CountdgvHDCoQuan()
        {
            long TongGiaBan = 0;
            long TongThueGTGT = 0;
            long TongPhiBVMT = 0;
            long TongCong = 0;
            if (dgvHDCoQuan.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    TongGiaBan += long.Parse(item.Cells["GiaBan_CQ"].Value.ToString());
                    TongThueGTGT += long.Parse(item.Cells["ThueGTGT_CQ"].Value.ToString());
                    TongPhiBVMT += long.Parse(item.Cells["PhiBVMT_CQ"].Value.ToString());
                    TongCong += long.Parse(item.Cells["TongCong_CQ"].Value.ToString());
                }
                txtTongHD_CQ.Text = dgvHDCoQuan.RowCount.ToString();
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHDCoQuan.RowCount);
                txtTongGiaBan_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
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

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                dgvHDTuGia.DataSource = _cHoaDon.GetDSDangNganQuay("", dateTu.Value, dateDen.Value);
                CountdgvHDTuGia();
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon_TG"].Value.ToString()))
                        item.DefaultCellStyle.BackColor = Color.Red;
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    dgvHDCoQuan.DataSource = _cHoaDon.GetDSDangNganQuay("CQ", dateTu.Value, dateDen.Value);
                    CountdgvHDCoQuan();
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                    {
                        if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon_CQ"].Value.ToString()))
                            item.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (_cChotDangNgan.checkExist_ChotDangNgan(DateTime.Now) == true)
                {
                    MessageBox.Show("Ngày Đăng Ngân đã Chốt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (ListViewItem item in lstHD.Items)
                {
                    //if (_cHoaDon.CheckDangNganBySoHoaDon(item.ToString()))
                    //{
                    //    MessageBox.Show("Hóa Đơn đã Đăng Ngân: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    lstHD.SelectedItem = item;
                    //    return;
                    //}
                    //string loai;
                    //if (!_cTamThu.CheckBySoHoaDon(item.ToString(),out loai))
                    //{
                    //    MessageBox.Show("Hóa Đơn không có Tạm Thu: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    lstHD.SelectedItem = item;
                    //    return;
                    //}
                    //if (loai == "Chuyển Khoản")
                    //{
                    //    MessageBox.Show("Hóa Đơn có Tạm Thu(Chuyển Khoản): " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    lstHD.SelectedItem = item;
                    //    return;
                    //}
                    //if (_cDCHD.CheckExistByDangRutDC(item.ToString()))
                    //{
                    //    MessageBox.Show("Hóa Đơn đã Rút đi Điều Chỉnh: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    lstHD.SelectedItem = item;
                    //    return;
                    //}
                    if (_cHoaDon.CheckKhoaTienDuBySoHoaDon(item.Text))
                    {
                        MessageBox.Show("Hóa Đơn đã Khóa Tiền Dư " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstHD.Focus();
                        item.Selected = true;
                        item.Focused = true;
                        return;
                    }
                    if (_cHoaDon.CheckDCHDTienDuBySoHoaDon(item.Text))
                    {
                        MessageBox.Show("Hóa Đơn đã ĐCHĐ Tiền Dư " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstHD.Focus();
                        item.Selected = true;
                        item.Focused = true;
                        return;
                    }
                    string DanhBo = "";
                    if (_cDCHD.CheckExist_UpdatedHDDT(item.Text, ref DanhBo) == false)
                    {
                        MessageBox.Show("Hóa Đơn có Điều Chỉnh nhưng chưa update HĐĐT " + DanhBo, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstHD.Focus();
                        item.Selected = true;
                        item.Focused = true;
                        return;
                    }
                }
                try
                {
                    //_cHoaDon.SqlBeginTransaction();
                    foreach (ListViewItem item in lstHD.Items)
                        if (_cHoaDon.DangNgan("Quay", item.Text, CNguoiDung.MaND))
                        {
                            //if (_cLenhHuy.CheckExist(item.ToString()))
                            //    if (!_cLenhHuy.Xoa(item.ToString()))
                            //    {
                            //        _cHoaDon.SqlRollbackTransaction();
                            //        MessageBox.Show("Lỗi Xóa Lệnh Hủy, Vui lòng thử lại \r\n" + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //        return;
                            //    }
                        }
                        else
                        {
                            //_cHoaDon.SqlRollbackTransaction();
                            //MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                    //_cHoaDon.SqlCommitTransaction();
                    lstHD.Items.Clear();
                    btnXem.PerformClick();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    //_cHoaDon.SqlRollbackTransaction();
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
                        foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                        {
                            if (_cChotDangNgan.checkExist_ChotDangNgan(_cHoaDon.GetNgayGiaiTrach(item.Cells["SoHoaDon_TG"].Value.ToString())) == true)
                            {
                                MessageBox.Show("Ngày Đăng Ngân đã Chốt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (_cHoaDon.GetNgayGiaiTrach(item.Cells["SoHoaDon_TG"].Value.ToString()).Date != DateTime.Now.Date)
                            {
                                MessageBox.Show("Chỉ được Điều Chỉnh Đăng Ngân trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else
                        if (tabControl.SelectedTab.Name == "tabCoQuan")
                        {
                            foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                            {
                                if (_cHoaDon.GetNgayGiaiTrach(item.Cells["SoHoaDon_CQ"].Value.ToString()).Date != DateTime.Now.Date)
                                {
                                    MessageBox.Show("Chỉ được Điều Chỉnh Đăng Ngân trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }

                    try
                    {
                        //_cHoaDon.SqlBeginTransaction();
                        if (tabControl.SelectedTab.Name == "tabTuGia")
                        {
                            foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                            {
                                if (!_cHoaDon.XoaDangNgan("Quay", item.Cells["SoHoaDon_TG"].Value.ToString(), CNguoiDung.MaND))
                                {
                                    //_cHoaDon.SqlRollbackTransaction();
                                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                        else
                            if (tabControl.SelectedTab.Name == "tabCoQuan")
                            {
                                foreach (DataGridViewRow item in dgvHDCoQuan.SelectedRows)
                                {
                                    if (!_cHoaDon.XoaDangNgan("Quay", item.Cells["SoHoaDon_CQ"].Value.ToString(), CNguoiDung.MaND))
                                    {
                                        //_cHoaDon.SqlRollbackTransaction();
                                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                        //_cHoaDon.SqlCommitTransaction();
                        btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        //_cHoaDon.SqlRollbackTransaction();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            dsBaoCao dsPhanKyLon = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if (chkPhanKy.Checked == false)
                {
                    DataTable dt = _cHoaDon.GetTongDangNgan("", CNguoiDung.MaND, dateDen.Value);
                    foreach (DataRow item in dt.Rows)
                    {
                        DataRow dr = ds.Tables["PhieuDangNgan"].NewRow();
                        dr["To"] = CNguoiDung.TenTo;
                        dr["Loai"] = "";
                        dr["LoaiHoaDon"] = item["LoaiHoaDon"].ToString();
                        dr["NgayDangNgan"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                        dr["TongHD"] = item["TongHD"].ToString();
                        dr["TongGiaBan"] = item["TongGiaBan"].ToString();
                        dr["TongThueGTGT"] = item["TongThueGTGT"].ToString();
                        dr["TongPhiBVMT"] = item["TongPhiBVMT"].ToString();
                        dr["TongCong"] = item["TongCong"].ToString();
                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["PhieuDangNgan"].Rows.Add(dr);
                    }
                }
                else
                {
                    DataTable dt1 = _cHoaDon.GetTongDangNgan_PhanKyNho(CNguoiDung.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateDen.Value);
                    foreach (DataRow item in dt1.Rows)
                    {
                        DataRow dr = ds.Tables["PhieuDangNgan"].NewRow();
                        dr["To"] = CNguoiDung.TenTo;
                        dr["Loai"] = "Kỳ <" + cmbKy.SelectedItem.ToString();
                        dr["LoaiHoaDon"] = item["LoaiHoaDon"].ToString();
                        dr["NgayDangNgan"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                        dr["TongHD"] = item["TongHD"].ToString();
                        dr["TongGiaBan"] = item["TongGiaBan"].ToString();
                        dr["TongThueGTGT"] = item["TongThueGTGT"].ToString();
                        dr["TongPhiBVMT"] = item["TongPhiBVMT"].ToString();
                        dr["TongCong"] = item["TongCong"].ToString();
                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["PhieuDangNgan"].Rows.Add(dr);
                    }

                    DataTable dt2 = _cHoaDon.GetTongDangNgan_PhanKyLon(CNguoiDung.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateDen.Value);
                    foreach (DataRow item in dt2.Rows)
                    {
                        DataRow dr = dsPhanKyLon.Tables["PhieuDangNgan"].NewRow();
                        dr["To"] = CNguoiDung.TenTo;
                        dr["Loai"] = "Kỳ " + cmbKy.SelectedItem.ToString();
                        dr["LoaiHoaDon"] = item["LoaiHoaDon"].ToString();
                        dr["NgayDangNgan"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                        dr["TongHD"] = item["TongHD"].ToString();
                        dr["TongGiaBan"] = item["TongGiaBan"].ToString();
                        dr["TongThueGTGT"] = item["TongThueGTGT"].ToString();
                        dr["TongPhiBVMT"] = item["TongPhiBVMT"].ToString();
                        dr["TongCong"] = item["TongCong"].ToString();
                        dr["NhanVien"] = CNguoiDung.HoTen;
                        dsPhanKyLon.Tables["PhieuDangNgan"].Rows.Add(dr);
                    }
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    DataTable dt = _cHoaDon.GetTongDangNgan("CQ", CNguoiDung.MaND, dateDen.Value);
                    foreach (DataRow item in dt.Rows)
                    {
                        DataRow dr = ds.Tables["PhieuDangNgan"].NewRow();
                        dr["To"] = CNguoiDung.TenTo;
                        dr["Loai"] = "Cơ Quan";
                        dr["NgayDangNgan"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                        dr["TongHD"] = item["TongHD"].ToString();
                        dr["TongGiaBan"] = item["TongGiaBan"].ToString();
                        dr["TongThueGTGT"] = item["TongThueGTGT"].ToString();
                        dr["TongPhiBVMT"] = item["TongPhiBVMT"].ToString();
                        dr["TongCong"] = item["TongCong"].ToString();
                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["PhieuDangNgan"].Rows.Add(dr);
                    }
                }
            if (chkPhanKy.Checked == false)
            {
                rptPhieuDangNgan rpt = new rptPhieuDangNgan();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
            else
            {
                rptPhieuDangNgan rpt1 = new rptPhieuDangNgan();
                rpt1.SetDataSource(ds);
                frmBaoCao frm1 = new frmBaoCao(rpt1);
                frm1.Show();

                rptPhieuDangNgan rpt2 = new rptPhieuDangNgan();
                rpt2.SetDataSource(dsPhanKyLon);
                frmBaoCao frm2 = new frmBaoCao(rpt2);
                frm2.Show();
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {

        }

        private int _searchIndex = -1;
        private string _searchNoiDung = "";

        private void GetNoiDungfrmTimKiem(string NoiDung)
        {
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if (_searchNoiDung != NoiDung)
                    _searchIndex = -1;

                for (int i = 0; i < dgvHDTuGia.Rows.Count; i++)
                {
                    if (_searchNoiDung != NoiDung)
                        _searchNoiDung = NoiDung;

                    _searchIndex = (_searchIndex + 1) % dgvHDTuGia.Rows.Count;
                    DataGridViewRow row = dgvHDTuGia.Rows[_searchIndex];
                    if (row.Cells["DanhBo_TG"].Value == null)
                    {
                        continue;
                    }
                    if (row.Cells["DanhBo_TG"].Value.ToString() == NoiDung)
                    {
                        dgvHDTuGia.CurrentCell = row.Cells["DanhBo_TG"];
                        dgvHDTuGia.Rows[_searchIndex].Selected = true;
                        return;
                    }
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    if (_searchNoiDung != NoiDung)
                        _searchIndex = -1;

                    for (int i = 0; i < dgvHDCoQuan.Rows.Count; i++)
                    {
                        if (_searchNoiDung != NoiDung)
                            _searchNoiDung = NoiDung;

                        _searchIndex = (_searchIndex + 1) % dgvHDCoQuan.Rows.Count;
                        DataGridViewRow row = dgvHDCoQuan.Rows[_searchIndex];
                        if (row.Cells["DanhBo_CQ"].Value == null)
                        {
                            continue;
                        }
                        if (row.Cells["DanhBo_CQ"].Value.ToString() == NoiDung)
                        {
                            dgvHDCoQuan.CurrentCell = row.Cells["DanhBo_CQ"];
                            dgvHDCoQuan.Rows[_searchIndex].Selected = true;
                            return;
                        }
                    }
                }
        }

        private void frmDangNganQuay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                frmTimKiemForm frm = new frmTimKiemForm();
                bool flag = false;
                foreach (var item in this.OwnedForms)
                    if (item.Name == frm.Name)
                    {
                        item.Activate();
                        flag = true;
                    }
                if (flag == false)
                {
                    frm.MyGetNoiDung = new frmTimKiemForm.GetNoiDung(GetNoiDungfrmTimKiem);
                    frm.Owner = this;
                    frm.Show();
                }
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
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "MLT_CQ" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "DanhBo_CQ" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TieuThu_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "GiaBan_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "ThueGTGT_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "PhiBVMT_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCong_CQ" && e.Value != null)
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

        private void btnInDS_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["LoaiBaoCao"] = "QUẦY";
                    dr["DanhBo"] = item.Cells["DanhBo_TG"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["HoTen"] = item.Cells["HoTen_TG"].Value;
                    dr["Ky"] = item.Cells["Ky_TG"].Value;
                    dr["MLT"] = item.Cells["MLT_TG"].Value.ToString().Insert(4, " ").Insert(2, " ");
                    dr["TongCong"] = item.Cells["TongCong_TG"].Value;
                    dr["SoHoaDon"] = item.Cells["SoHoaDon_TG"].Value;
                    dr["HanhThu"] = item.Cells["HanhThu_TG"].Value.ToString();
                    dr["To"] = item.Cells["To_TG"].Value.ToString();
                    dr["Loai"] = "";
                    ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                    {
                        DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                        dr["LoaiBaoCao"] = "QUẦY CƠ QUAN";
                        dr["DanhBo"] = item.Cells["DanhBo_CQ"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["HoTen"] = item.Cells["HoTen_CQ"].Value;
                        dr["Ky"] = item.Cells["Ky_CQ"].Value;
                        dr["MLT"] = item.Cells["MLT_CQ"].Value.ToString().Insert(4, " ").Insert(2, " ");
                        dr["TongCong"] = item.Cells["TongCong_CQ"].Value;
                        dr["SoHoaDon"] = item.Cells["SoHoaDon_CQ"].Value;
                        dr["HanhThu"] = item.Cells["HanhThu_CQ"].Value.ToString();
                        dr["To"] = item.Cells["To_CQ"].Value.ToString();
                        dr["Loai"] = "CQ";
                        ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                    }
                }
            rptDSDangNganQuay rpt = new rptDSDangNganQuay();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
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

        private void chkPhanKy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPhanKy.Checked)
            {
                cmbNam.Enabled = true;
                cmbKy.Enabled = true;
            }
            else
            {
                cmbNam.Enabled = false;
                cmbKy.Enabled = false;
            }
        }
    }
}

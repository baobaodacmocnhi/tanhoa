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
using ThuTien.DAL.TongHop;
using System.Globalization;
using ThuTien.BaoCao;
using ThuTien.BaoCao.NhanVien;
using ThuTien.GUI.BaoCao;
using System.Transactions;

namespace ThuTien.GUI.HanhThu
{
    public partial class frmDangNganTon : Form
    {
        string _mnu = "mnuDangNganTon";
        CHoaDon _cHoaDon = new CHoaDon();
        CTamThu _cTamThu = new CTamThu();
        CDCHD _cDCHD = new CDCHD();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CTienDuQuay _cTienDuQuay = new CTienDuQuay();
        CChotDangNgan _cChotDangNgan = new CChotDangNgan();

        public frmDangNganTon()
        {
            InitializeComponent();
        }

        private void frmDangNganTon_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "ID";
            cmbNam.ValueMember = "Nam";

            dateGiaiTrach.Value = DateTime.Now;

            tabTuGia.Text = "Hóa Đơn";
            //tabControl.TabPages.Remove(tabTienDu);
        }

        public void CountdgvHDTuGia()
        {
            long TongGiaBan = 0;
            long TongThueGTGT = 0;
            long TongPhiBVMT = 0;
            long TongPhiBVMT_Thue = 0;
            long TongCong = 0;
            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    TongGiaBan += long.Parse(item.Cells["GiaBan_TG"].Value.ToString());
                    TongThueGTGT += long.Parse(item.Cells["ThueGTGT_TG"].Value.ToString());
                    TongPhiBVMT += long.Parse(item.Cells["PhiBVMT_TG"].Value.ToString());
                    if (item.Cells["PhiBVMT_Thue_TG"].Value.ToString() != "")
                        TongPhiBVMT_Thue += long.Parse(item.Cells["PhiBVMT_Thue_TG"].Value.ToString());
                    TongCong += long.Parse(item.Cells["TongCong_TG"].Value.ToString());
                }
                txtTongHD_TG.Text = dgvHDTuGia.RowCount.ToString();
                txtTongGiaBan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongPhiBVMT_Thue_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT_Thue);
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        public void CountdgvHDCoQuan()
        {
            long TongGiaBan = 0;
            long TongThueGTGT = 0;
            long TongPhiBVMT = 0;
            long TongCong = 0;
            long TongTienDu = 0;
            long TongTienMat = 0;
            if (dgvHDCoQuan.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    TongGiaBan += long.Parse(item.Cells["GiaBan_CQ"].Value.ToString());
                    TongThueGTGT += long.Parse(item.Cells["ThueGTGT_CQ"].Value.ToString());
                    TongPhiBVMT += long.Parse(item.Cells["PhiBVMT_CQ"].Value.ToString());
                    TongCong += long.Parse(item.Cells["TongCong_CQ"].Value.ToString());
                    TongTienDu += long.Parse(item.Cells["TienDu_CQ"].Value.ToString());
                    TongTienMat += long.Parse(item.Cells["TienMat_CQ"].Value.ToString());
                }
                txtTongHD_CQ.Text = dgvHDCoQuan.RowCount.ToString();
                txtTongGiaBan_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongTienDu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongTienDu);
                txtTongTienMat_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongTienMat);
            }
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
            {
                foreach (string item in txtSoHoaDon.Lines)
                    if (!string.IsNullOrEmpty(item.Trim().ToUpper()))
                    {
                        if (lstHD.FindItemWithText(item.Trim().ToUpper()) == null)
                        {
                            lstHD.Items.Add(item.Trim().ToUpper());
                            lstHD.EnsureVisible(lstHD.Items.Count - 1);
                        }
                    }
                    //else
                    //    ///Trung An thêm 'K' phía cuối liên hóa đơn
                    //    if (!string.IsNullOrEmpty(item.Trim().ToUpper()) && item.ToString().Length == 14)
                    //    {
                    //        if (lstHD.FindItemWithText(item.Trim().ToUpper().Replace("K", "")) == null)
                    //        {
                    //            lstHD.Items.Add(item.Trim().ToUpper().Replace("K", ""));
                    //            lstHD.EnsureVisible(lstHD.Items.Count - 1);
                    //        }
                    //    }
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
                dgvHDTuGia.DataSource = _cHoaDon.GetDSDangNganTonByMaNVDate("", CNguoiDung.MaND, dateGiaiTrach.Value);
                CountdgvHDTuGia();
            }
            else
                if (tabControl.SelectedTab.Name == "tabTienDu")
                {
                    dgvHDCoQuan.DataSource = _cHoaDon.getDSDangNgan_DieuChinhTienDu(CNguoiDung.MaND, dateGiaiTrach.Value);
                    CountdgvHDCoQuan();
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
                if (lstHD.Items.Count > 0)
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
                        //if (!_cHoaDon.CheckGiaoTonBySoHoaDonMaNV(item.ToString(),CNguoiDung.MaND))
                        //{
                        //    MessageBox.Show("Hóa Đơn không được giao cho bạn: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    lstHD.SelectedItem = item;
                        //    return;
                        //}
                        //if (_cHoaDon.CheckDangNganBySoHoaDon(item.ToString()))
                        //{
                        //    MessageBox.Show("Hóa Đơn đã Đăng Ngân: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    lstHD.SelectedItem = item;
                        //    return;
                        //}
                        //if (_cTamThu.CheckBySoHoaDon(item.ToString(), out loai))
                        //{
                        //    MessageBox.Show("Hóa Đơn đã được Tạm Thu(" + loai + "): " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    lstHD.SelectedItem = item;
                        //    return;
                        //}
                        //if (_cDCHD.CheckExistByDangRutDC(item.ToString()))
                        //{
                        //    MessageBox.Show("Hóa Đơn đã rút đi Điều Chỉnh: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    lstHD.SelectedItem = item;
                        //    return;
                        //}
                        if (_cHoaDon.CheckKhoaTienDuBySoHoaDon(item.Text))
                        {
                            MessageBox.Show("Hóa Đơn đã Khóa Tiền Dư " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lstHD.Focus();
                            item.Selected = true;
                            item.Focused = true;
                            return;
                        }
                        if (_cHoaDon.CheckDCHDTienDuBySoHoaDon(item.Text))
                        {
                            MessageBox.Show("Hóa Đơn đã Điều Chỉnh Tiền Dư " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        foreach (ListViewItem item in lstHD.Items)
                        {
                            ///ưu tiên đăng ngân hành thu, tự động xóa tạm thu chuyển qua thu 2 lần
                            bool ChuyenKhoan = false;
                            if (_cTamThu.CheckExist_Quay(item.Text))
                            {
                                var transactionOptions = new TransactionOptions();
                                transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                                {
                                    if (_cHoaDon.DangNgan("Ton", item.Text, CNguoiDung.MaND))
                                        if (_cHoaDon.Thu2Lan(item.Text, ChuyenKhoan))
                                        {
                                            if (_cTamThu.XoaAn(item.Text))
                                                if (_cTienDuQuay.UpdateXoa(item.Text, "Thu 2 Lần", "Thêm"))
                                                { scope.Complete(); scope.Dispose(); }
                                        }
                                        else
                                            MessageBox.Show("Lỗi thu 2 lần, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                _cHoaDon.DangNgan("Ton", item.Text, CNguoiDung.MaND);
                            }
                        }
                        //if (_cLenhHuy.CheckExist(item.ToString()))
                        //    if (!_cLenhHuy.Xoa(item.ToString()))
                        //    {
                        //        _cHoaDon.SqlRollbackTransaction();
                        //        MessageBox.Show("Lỗi Xóa Lệnh Hủy, Vui lòng thử lại \r\n" + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        return;
                        //    }
                        btnXem.PerformClick();
                        lstHD.Items.Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                                if (!_cHoaDon.XoaDangNgan("Ton", item.Cells["SoHoaDon_TG"].Value.ToString(), CNguoiDung.MaND))
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
                                    if (!_cHoaDon.XoaDangNgan("Ton", item.Cells["SoHoaDon_CQ"].Value.ToString(), CNguoiDung.MaND))
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
            if (_cHoaDon.checkExist_DangNganCoDCHD(CNguoiDung.MaND, dateGiaiTrach.Value) == true)
            {
                MessageBox.Show("Hóa Đơn đã Điều Chỉnh Tiền Dư,\nVui lòng chuyển cho Chuyển Khoản đăng ngân", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dtTCT;
            if (_cHoaDon.checkExist_DangNganCoDCHDTongChuaCapNhat(CNguoiDung.MaND, dateGiaiTrach.Value, out dtTCT) == true)
            {
                dsBaoCao dsTCT = new dsBaoCao();
                foreach (DataRow item in dtTCT.Rows)
                {
                    DataRow dr = dsTCT.Tables["DSHoaDon"].NewRow();
                    dr["LoaiBaoCao"] = "ĐIỀU CHỈNH TCT CHƯA CẬP NHẬT";
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                    dr["Ky"] = item["Ky"];
                    dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                    dr["TongCong"] = item["TongCong"];
                    dr["SoPhatHanh"] = item["SoPhatHanh"];
                    dr["SoHoaDon"] = item["SoHoaDon"];
                    dr["NhanVien"] = CNguoiDung.HoTen;
                    dsTCT.Tables["DSHoaDon"].Rows.Add(dr);
                }
                rptDSHoaDon rptTCT = new rptDSHoaDon();
                rptTCT.SetDataSource(dsTCT);
                frmBaoCao frmTCT = new frmBaoCao(rptTCT);
                frmTCT.Show();
                MessageBox.Show("Hóa Đơn đã Điều Chỉnh (TCT chưa cập nhật),\nVui lòng chuyển cho Tổ Trưởng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dsBaoCao ds = new dsBaoCao();
            dsBaoCao dsPhanKyLon = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if (chkPhanKy.Checked == false)
                {
                    DataTable dt = _cHoaDon.GetTongDangNgan("", CNguoiDung.MaND, dateGiaiTrach.Value);
                    foreach (DataRow item in dt.Rows)
                    {
                        DataRow dr = ds.Tables["PhieuDangNgan"].NewRow();
                        dr["To"] = CNguoiDung.TenTo;
                        dr["Loai"] = "";
                        dr["LoaiHoaDon"] = item["LoaiHoaDon"].ToString();
                        dr["NgayDangNgan"] = dateGiaiTrach.Value.Date.ToString("dd/MM/yyyy");
                        dr["TongHD"] = item["TongHD"].ToString();
                        dr["TongGiaBan"] = item["TongGiaBan"].ToString();
                        dr["TongThueGTGT"] = item["TongThueGTGT"].ToString();
                        dr["TongPhiBVMT"] = item["TongPhiBVMT"].ToString();
                        if (item["TongPhiBVMT_Thue"].ToString() != "")
                            dr["TongPhiBVMT_Thue"] = item["TongPhiBVMT_Thue"].ToString();
                        dr["TongCong"] = item["TongCong"].ToString();
                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["PhieuDangNgan"].Rows.Add(dr);
                    }
                }
                else
                {
                    DataTable dt1 = _cHoaDon.GetTongDangNgan_PhanKyNho(CNguoiDung.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                    foreach (DataRow item in dt1.Rows)
                    {
                        DataRow dr = ds.Tables["PhieuDangNgan"].NewRow();
                        dr["To"] = CNguoiDung.TenTo;
                        dr["Loai"] = "Kỳ <" + cmbKy.SelectedItem.ToString();
                        dr["LoaiHoaDon"] = item["LoaiHoaDon"].ToString();
                        dr["NgayDangNgan"] = dateGiaiTrach.Value.Date.ToString("dd/MM/yyyy");
                        dr["TongHD"] = item["TongHD"].ToString();
                        dr["TongGiaBan"] = item["TongGiaBan"].ToString();
                        dr["TongThueGTGT"] = item["TongThueGTGT"].ToString();
                        dr["TongPhiBVMT"] = item["TongPhiBVMT"].ToString();
                        dr["TongPhiBVMT_Thue"] = item["TongPhiBVMT_Thue"].ToString();
                        dr["TongCong"] = item["TongCong"].ToString();
                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["PhieuDangNgan"].Rows.Add(dr);
                    }

                    DataTable dt2 = _cHoaDon.GetTongDangNgan_PhanKyLon(CNguoiDung.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                    foreach (DataRow item in dt2.Rows)
                    {
                        DataRow dr = dsPhanKyLon.Tables["PhieuDangNgan"].NewRow();
                        dr["To"] = CNguoiDung.TenTo;
                        dr["Loai"] = "Kỳ " + cmbKy.SelectedItem.ToString();
                        dr["LoaiHoaDon"] = item["LoaiHoaDon"].ToString();
                        dr["NgayDangNgan"] = dateGiaiTrach.Value.Date.ToString("dd/MM/yyyy");
                        dr["TongHD"] = item["TongHD"].ToString();
                        dr["TongGiaBan"] = item["TongGiaBan"].ToString();
                        dr["TongThueGTGT"] = item["TongThueGTGT"].ToString();
                        dr["TongPhiBVMT"] = item["TongPhiBVMT"].ToString();
                        if (item["TongPhiBVMT_Thue"].ToString() != "")
                            dr["TongPhiBVMT_Thue"] = item["TongPhiBVMT_Thue"].ToString();
                        dr["TongCong"] = item["TongCong"].ToString();
                        dr["NhanVien"] = CNguoiDung.HoTen;
                        dsPhanKyLon.Tables["PhieuDangNgan"].Rows.Add(dr);
                    }
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    DataTable dt = _cHoaDon.GetTongDangNgan("CQ", CNguoiDung.MaND, dateGiaiTrach.Value);
                    foreach (DataRow item in dt.Rows)
                    {
                        DataRow dr = ds.Tables["PhieuDangNgan"].NewRow();
                        dr["To"] = CNguoiDung.TenTo;
                        dr["Loai"] = "Cơ Quan";
                        dr["NgayDangNgan"] = dateGiaiTrach.Value.Date.ToString("dd/MM/yyyy");
                        dr["TongHD"] = item["TongHD"].ToString();
                        dr["TongGiaBan"] = item["TongGiaBan"].ToString();
                        dr["TongThueGTGT"] = item["TongThueGTGT"].ToString();
                        dr["TongPhiBVMT"] = item["TongPhiBVMT"].ToString();
                        if (item["TongPhiBVMT_Thue"].ToString() != "")
                            dr["TongPhiBVMT_Thue"] = item["TongPhiBVMT_Thue"].ToString();
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                    dr["LoaiBaoCao"] = "TỒN TƯ GIA ĐÃ THU";
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
                        dr["LoaiBaoCao"] = "TỒN CƠ QUAN ĐÃ THU";
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
                    //if (CNguoiDung.ToTruong)
                    //    dr["NhanVien"] = ((TT_NguoiDung)cmbNhanVien.SelectedItem).HoTen;
                    //else
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
                        //if (CNguoiDung.ToTruong)
                        //    dr["NhanVien"] = ((TT_NguoiDung)cmbNhanVien.SelectedItem).HoTen;
                        //else
                        dr["NhanVien"] = CNguoiDung.HoTen;
                        dsBaoCao.Tables["DSHoaDon"].Rows.Add(dr);
                    }
                }
            rptDSHoaDon_DiaChi rpt = new rptDSHoaDon_DiaChi();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
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
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "PhiBVMT_Thue_TG" && e.Value != null)
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

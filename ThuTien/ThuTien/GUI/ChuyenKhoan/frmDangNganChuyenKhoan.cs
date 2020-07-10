using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.Quay;
using ThuTien.DAL.QuanTri;
using System.Globalization;
using ThuTien.DAL.TongHop;
using ThuTien.BaoCao;
using ThuTien.BaoCao.NhanVien;
using ThuTien.GUI.BaoCao;
using ThuTien.GUI.TimKiem;
using ThuTien.LinQ;
using ThuTien.BaoCao.ChuyenKhoan;
using ThuTien.BaoCao.Quay;
using ThuTien.DAL.ChuyenKhoan;
using System.Transactions;
using ThuTien.DAL.DongNuoc;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmDangNganChuyenKhoan : Form
    {
        string _mnu = "mnuDangNganChuyenKhoan";
        CHoaDon _cHoaDon = new CHoaDon();
        CTamThu _cTamThu = new CTamThu();
        CDCHD _cDCHD = new CDCHD();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CTienDu _cTienDu = new CTienDu();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CBangKe _cBangKe = new CBangKe();
        CDichVuThu _cDichVuThu = new CDichVuThu();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CChotDangNgan _cChotDangNgan = new CChotDangNgan();

        public frmDangNganChuyenKhoan()
        {
            InitializeComponent();
        }

        private void frmDangNganChuyenKhoan_Load(object sender, EventArgs e)
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
                dgvHDTuGia.DataSource = _cHoaDon.GetDSDangNganChuyenKhoan("", dateTu.Value, dateDen.Value);
                CountdgvHDTuGia();
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    dgvHDCoQuan.DataSource = _cHoaDon.GetDSDangNganChuyenKhoan("CQ", dateTu.Value, dateDen.Value);
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
                foreach (ListViewItem item in lstHD.Items)
                {
                    //if (!_cHoaDon.CheckBySoHoaDon(item.ToString()))
                    //{
                    //    MessageBox.Show("Hóa Đơn sai: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    lstHD.SelectedItem = item;
                    //    return;
                    //}
                    //if (_cHoaDon.CheckDangNganBySoHoaDon(item.ToString()))
                    //{
                    //    MessageBox.Show("Hóa Đơn đã Đăng Ngân: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    lstHD.SelectedItem = item;
                    //    return;
                    //}
                    //if (!_cTamThu.CheckBySoHoaDon(item.ToString(), out loai))
                    //{
                    //    MessageBox.Show("Hóa Đơn không có Tạm Thu: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    lstHD.SelectedItem = item;
                    //    return;
                    //}
                    //if (loai == "Quầy")
                    //{
                    //    MessageBox.Show("Hóa Đơn có Tạm Thu(Quầy): " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (_cDCHD.CheckExist_UpdatedHDDT(item.Text)==false)
                    {
                        MessageBox.Show("Hóa Đơn có Điều Chỉnh nhưng chưa update HĐĐT " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstHD.Focus();
                        item.Selected = true;
                        item.Focused = true;
                        return;
                    }
                }
                try
                {
                    foreach (ListViewItem item in lstHD.Items)
                        using (var scope = new TransactionScope())
                        {
                            if (_cHoaDon.DangNgan("ChuyenKhoan", item.Text, CNguoiDung.MaND))
                                if (_cTienDu.UpdateThem(item.Text))
                                {
                                    scope.Complete();
                                    scope.Dispose();
                                }
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
                        if (tabControl.SelectedTab.Name == "tabTuGia")
                        {
                            foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                                using (var scope = new TransactionScope())
                                {
                                    if (_cTienDu.UpdateXoa(item.Cells["SoHoaDon_TG"].Value.ToString()))
                                        if (_cHoaDon.XoaDangNgan("ChuyenKhoan", item.Cells["SoHoaDon_TG"].Value.ToString(), CNguoiDung.MaND))
                                        {
                                            scope.Complete();
                                            scope.Dispose();
                                        }
                                }
                        }
                        else
                            if (tabControl.SelectedTab.Name == "tabCoQuan")
                            {
                                foreach (DataGridViewRow item in dgvHDCoQuan.SelectedRows)
                                    using (var scope = new TransactionScope())
                                    {
                                        if (_cTienDu.UpdateXoa(item.Cells["SoHoaDon_CQ"].Value.ToString()))
                                            if (_cHoaDon.XoaDangNgan("ChuyenKhoan", item.Cells["SoHoaDon_CQ"].Value.ToString(), CNguoiDung.MaND))
                                            {
                                                scope.Complete();
                                                scope.Dispose();
                                            }
                                    }
                            }
                        btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
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
                        if (!string.IsNullOrEmpty(item["TongTienMat"].ToString()))
                            dr["TongTienMat"] = item["TongTienMat"].ToString();
                        //else
                        //    dr["TongTienMat"] = 0;
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
                        dr["NgayDangNgan"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                        dr["TongHD"] = item["TongHD"].ToString();
                        dr["TongGiaBan"] = item["TongGiaBan"].ToString();
                        dr["TongThueGTGT"] = item["TongThueGTGT"].ToString();
                        dr["TongPhiBVMT"] = item["TongPhiBVMT"].ToString();
                        dr["TongCong"] = item["TongCong"].ToString();
                        if (!string.IsNullOrEmpty(item["TongTienMat"].ToString()))
                            dr["TongTienMat"] = item["TongTienMat"].ToString();
                        //else
                        //    dr["TongTienMat"] = 0;
                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["PhieuDangNgan"].Rows.Add(dr);
                    }

                    DataTable dt2 = _cHoaDon.GetTongDangNgan_PhanKyLon(CNguoiDung.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateDen.Value);
                    foreach (DataRow item in dt2.Rows)
                    {
                        DataRow dr = dsPhanKyLon.Tables["PhieuDangNgan"].NewRow();
                        dr["To"] = CNguoiDung.TenTo;
                        dr["Loai"] = "Kỳ " + cmbKy.SelectedItem.ToString();
                        dr["NgayDangNgan"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                        dr["TongHD"] = item["TongHD"].ToString();
                        dr["TongGiaBan"] = item["TongGiaBan"].ToString();
                        dr["TongThueGTGT"] = item["TongThueGTGT"].ToString();
                        dr["TongPhiBVMT"] = item["TongPhiBVMT"].ToString();
                        dr["TongCong"] = item["TongCong"].ToString();
                        if (!string.IsNullOrEmpty(item["TongTienMat"].ToString()))
                            dr["TongTienMat"] = item["TongTienMat"].ToString();
                        //else
                        //    dr["TongTienMat"] = 0;
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
                        if (!string.IsNullOrEmpty(item["TongTienMat"].ToString()))
                            dr["TongTienMat"] = item["TongTienMat"].ToString();
                        //else
                        //    dr["TongTienMat"] = 0;
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

        private void btnInDS_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["LoaiBaoCao"] = "CHUYỂN KHOẢN";
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
                        dr["LoaiBaoCao"] = "CHUYỂN KHOẢN CƠ QUAN";
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

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            //if (tabControl.SelectedTab.Name == "tabTuGia")
            //{
            //    if (dgvHDTuGia.RowCount > 0)
            //    {
            //        CTo _cTo = new CTo();
            //        List<TT_To> lstTo = _cTo.GetDSHanhThu();
            //        DataTable[] dtTos = new DataTable[lstTo.Count];
            //        DataTable dt = (DataTable)dgvHDTuGia.DataSource;

            //        for (int i = 0; i < dtTos.Length; i++)
            //        {
            //            dtTos[i] = new DataTable();
            //        }

            //        for (int i = 0; i < lstTo.Count; i++)
            //        {
            //            foreach (DataColumn item in dt.Columns)
            //            {
            //                dtTos[i].Columns.Add(new DataColumn(item.ColumnName, item.DataType));
            //            }
            //        }

            //        foreach (DataRow item in dt.Rows)
            //            for (int i = 0; i < lstTo.Count; i++)
            //                if (item["To"].ToString() == lstTo[i].TenTo)
            //                {
            //                    dtTos[i].ImportRow(item);
            //                }

            //        //Tạo các đối tượng Excel
            //        Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            //        Microsoft.Office.Interop.Excel.Workbooks oBooks;
            //        //Microsoft.Office.Interop.Excel.Sheets oSheets;
            //        Microsoft.Office.Interop.Excel.Workbook oBook;
            //        Microsoft.Office.Interop.Excel.Worksheet[] oSheets = new Microsoft.Office.Interop.Excel.Worksheet[lstTo.Count];

            //        //Tạo mới một Excel WorkBook 
            //        oExcel.Visible = true;
            //        oExcel.DisplayAlerts = false;
            //        //khai báo số lượng sheet
            //        oExcel.Application.SheetsInNewWorkbook = lstTo.Count;
            //        oBooks = oExcel.Workbooks;

            //        oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            //        //oSheets = oBook.Worksheets;
            //        //oSheetTG = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            //        //oSheetCQ = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(2);

            //        for (int i = 0; i < lstTo.Count; i++)
            //        {
            //            oSheets[i] = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.get_Item(i + 1);
            //            XuatExcel(dtTos[i], oSheets[i], lstTo[i].TenTo);
            //        }
            //        //XuatExcel(dtTG, oSheetTG, "Tư Gia");
            //        //XuatExcel(dtCQ, oSheetCQ, "Cơ Quan");
            //    }
            //}
            //else
            //    if (tabControl.SelectedTab.Name == "tabCoQuan")
            //    {
            //        if (dgvHDCoQuan.RowCount > 0)
            //        {
            //            CTo _cTo = new CTo();
            //            List<TT_To> lstTo = _cTo.GetDSHanhThu();
            //            DataTable[] dtTos = new DataTable[lstTo.Count];
            //            DataTable dt = (DataTable)dgvHDCoQuan.DataSource;

            //            for (int i = 0; i < dtTos.Length; i++)
            //            {
            //                dtTos[i] = new DataTable();
            //            }

            //            for (int i = 0; i < lstTo.Count; i++)
            //            {
            //                foreach (DataColumn item in dt.Columns)
            //                {
            //                    dtTos[i].Columns.Add(new DataColumn(item.ColumnName, item.DataType));
            //                }
            //            }

            //            foreach (DataRow item in dt.Rows)
            //                for (int i = 0; i < lstTo.Count; i++)
            //                    if (item["To"].ToString() == lstTo[i].TenTo)
            //                    {
            //                        dtTos[i].ImportRow(item);
            //                    }

            //            //Tạo các đối tượng Excel
            //            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            //            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            //            //Microsoft.Office.Interop.Excel.Sheets oSheets;
            //            Microsoft.Office.Interop.Excel.Workbook oBook;
            //            Microsoft.Office.Interop.Excel.Worksheet[] oSheets = new Microsoft.Office.Interop.Excel.Worksheet[lstTo.Count];

            //            //Tạo mới một Excel WorkBook 
            //            oExcel.Visible = true;
            //            oExcel.DisplayAlerts = false;
            //            //khai báo số lượng sheet
            //            oExcel.Application.SheetsInNewWorkbook = lstTo.Count;
            //            oBooks = oExcel.Workbooks;

            //            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            //            //oSheets = oBook.Worksheets;
            //            //oSheetTG = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            //            //oSheetCQ = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(2);

            //            for (int i = 0; i < lstTo.Count; i++)
            //            {
            //                oSheets[i] = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.get_Item(i + 1);
            //                XuatExcel(dtTos[i], oSheets[i], lstTo[i].TenTo);
            //            }
            //            //XuatExcel(dtTG, oSheetTG, "Tư Gia");
            //            //XuatExcel(dtCQ, oSheetCQ, "Cơ Quan");
            //        }
            //    }

            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                DataTable dt = (DataTable)dgvHDTuGia.DataSource;

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

                XuatExcel(dt, oSheet, "ĐĂNG NGÂN");
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    DataTable dt = (DataTable)dgvHDCoQuan.DataSource;

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

                    XuatExcel(dt, oSheet, "ĐĂNG NGÂN CƠ QUAN");
                }
        }

        private void XuatExcel(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName)
        {
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
            cl4.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E1", "E1");
            cl5.Value2 = "MLT";
            cl5.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F1", "F1");
            cl6.Value2 = "Giá Bán";
            cl6.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G1", "G1");
            cl7.Value2 = "Thuế GTGT";
            cl7.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H1", "H1");
            cl8.Value2 = "Phí BVMT";
            cl8.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I1", "I1");
            cl9.Value2 = "Tổng Cộng";
            cl9.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J1", "J1");
            cl10.Value2 = "Hành Thu";
            cl10.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K1", "K1");
            cl11.Value2 = "Tổ";
            cl11.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L1", "L1");
            cl12.Value2 = "Ngân Hàng";
            cl12.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M1", "M1");
            cl13.Value2 = "Loại";
            cl13.ColumnWidth = 5;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 13];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = dr["SoHoaDon"].ToString();
                arr[i, 1] = dr["Ky"].ToString();
                arr[i, 2] = dr["DanhBo"].ToString();
                arr[i, 3] = dr["HoTen"].ToString();
                arr[i, 4] = dr["MLT"].ToString();
                arr[i, 5] = dr["GiaBan"].ToString();
                arr[i, 6] = dr["ThueGTGT"].ToString();
                arr[i, 7] = dr["PhiBVMT"].ToString();
                arr[i, 8] = dr["TongCong"].ToString();
                arr[i, 9] = dr["HanhThu"].ToString();
                arr[i, 10] = dr["To"].ToString();
                arr[i, 11] = _cTamThu.GetTenNganHang(dr["SoHoaDon"].ToString());
                if (int.Parse(dr["GiaBieu"].ToString()) > 20)
                    arr[i, 12] = "CQ";
                else
                    arr[i, 12] = "TG";
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 13;

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

        private void btnInDSKhongTamThu_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                    if (!_cTamThu.CheckExist(item.Cells["SoHoaDon_TG"].Value.ToString(), true))
                    {
                        DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                        dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                        dr["LoaiBaoCao"] = "ĐĂNG NGÂN KHÔNG CÓ TẠM THU";
                        dr["DanhBo"] = item.Cells["DanhBo_TG"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["HoTen"] = item.Cells["HoTen_TG"].Value.ToString();
                        dr["MLT"] = item.Cells["MLT_TG"].Value.ToString().Insert(4, " ").Insert(2, " ");
                        dr["Ky"] = item.Cells["Ky_TG"].Value.ToString();
                        dr["TongCong"] = item.Cells["TongCong_TG"].Value.ToString();
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
                        if (!_cTamThu.CheckExist(item.Cells["SoHoaDon_CQ"].Value.ToString(), true))
                        {
                            DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                            dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                            dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                            dr["LoaiBaoCao"] = "ĐĂNG NGÂN KHÔNG CÓ TẠM THU CƠ QUAN";
                            dr["DanhBo"] = item.Cells["DanhBo_CQ"].Value.ToString().Insert(4, " ").Insert(8, " ");
                            dr["HoTen"] = item.Cells["HoTen_CQ"].Value.ToString();
                            dr["MLT"] = item.Cells["MLT_CQ"].Value.ToString().Insert(4, " ").Insert(2, " ");
                            dr["Ky"] = item.Cells["Ky_CQ"].Value.ToString();
                            dr["TongCong"] = item.Cells["TongCong_CQ"].Value.ToString();
                            dr["HanhThu"] = item.Cells["HanhThu_CQ"].Value.ToString();
                            dr["To"] = item.Cells["To_CQ"].Value.ToString();
                            dr["Loai"] = "CQ";
                            ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                        }
                }
            rptDSTamThuChuyenKhoan rpt = new rptDSTamThuChuyenKhoan();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
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

        private void frmDangNganChuyenKhoan_KeyDown(object sender, KeyEventArgs e)
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

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (ListViewItem item in lstHD.Items)
            {
                str += item.Text + "\n";
            }
            Clipboard.SetText(str);
        }

        private void btnInDSThieuTienMoNuoc_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                    if (ds.Tables["TamThuChuyenKhoan"].Select("DanhBo='" + item.Cells["DanhBo_TG"].Value.ToString() + "'").Length == 0
                        && _cDongNuoc.CheckPhiMoNuoc(item.Cells["DanhBo_TG"].Value.ToString()) == true && _cTienDu.GetTienDu(item.Cells["DanhBo_TG"].Value.ToString()) <= _cDongNuoc.GetPhiMoNuoc(item.Cells["DanhBo_TG"].Value.ToString()))
                    {
                        DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                        dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                        dr["LoaiBaoCao"] = "ĐĂNG NGÂN THIẾU TIỀN MỞ NƯỚC";
                        dr["DanhBo"] = item.Cells["DanhBo_TG"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["HoTen"] = item.Cells["HoTen_TG"].Value.ToString();
                        dr["MLT"] = item.Cells["MLT_TG"].Value.ToString().Insert(4, " ").Insert(2, " ");
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
                        if (ds.Tables["TamThuChuyenKhoan"].Select("DanhBo='" + item.Cells["DanhBo_CQ"].Value.ToString() + "'").Length == 0
                            && _cDongNuoc.CheckPhiMoNuoc(item.Cells["DanhBo_CQ"].Value.ToString()) == true && _cTienDu.GetTienDu(item.Cells["DanhBo_CQ"].Value.ToString()) <= _cDongNuoc.GetPhiMoNuoc(item.Cells["DanhBo_CQ"].Value.ToString()))
                        {
                            DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                            dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                            dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                            dr["LoaiBaoCao"] = "ĐĂNG NGÂN THIẾU TIỀN MỞ NƯỚC";
                            dr["DanhBo"] = item.Cells["DanhBo_CQ"].Value.ToString().Insert(4, " ").Insert(8, " ");
                            dr["HoTen"] = item.Cells["HoTen_CQ"].Value.ToString();
                            dr["MLT"] = item.Cells["MLT_CQ"].Value.ToString().Insert(4, " ").Insert(2, " ");
                            dr["HanhThu"] = item.Cells["HanhThu_CQ"].Value.ToString();
                            dr["To"] = item.Cells["To_CQ"].Value.ToString();
                            dr["Loai"] = "CQ";
                            ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                        }
                }
            rptDSTamThuChuyenKhoan rpt = new rptDSTamThuChuyenKhoan();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
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

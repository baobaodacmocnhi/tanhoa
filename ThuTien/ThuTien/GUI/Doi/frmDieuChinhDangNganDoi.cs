using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using System.Globalization;
using ThuTien.DAL.Doi;
using ThuTien.DAL.Quay;
using ThuTien.DAL.TongHop;
using ThuTien.DAL.ChuyenKhoan;
using System.Transactions;
using ThuTien.LinQ;

namespace ThuTien.GUI.Doi
{
    public partial class frmDieuChinhDangNganDoi : Form
    {
        string _mnu = "mnuDieuChinhDangNganDoi";
        CTo _cTo = new CTo();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CHoaDon _cHoaDon = new CHoaDon();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CDCHD _cDCHD = new CDCHD();
        CTienDu _cTienDu = new CTienDu();
        CTamThu _cTamThu = new CTamThu();
        CTienDuQuay _cTienDuQuay = new CTienDuQuay();
        CChotDangNgan _cChotDangNgan = new CChotDangNgan();
        bool _flagLoadFirst = false;

        public frmDieuChinhDangNganDoi()
        {
            InitializeComponent();
        }

        private void frmDieuChinhDangNganDoi_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;
            dgvChotDangNgan.AutoGenerateColumns = false;

            //cmbTo.DataSource = _cTo.GetDS();
            //cmbTo.DisplayMember = "TenTo";
            //cmbTo.ValueMember = "MaTo";
            //cmbTo.SelectedIndex = -1;
            List<TT_To> lst = _cTo.getDS();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            lst.Insert(0, to);
            cmbTo.DataSource = lst;
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";

            dateGiaiTrach.Value = DateTime.Now;

            tabTuGia.Text = "Hóa Đơn";
            tabControl.TabPages.Remove(tabChotDangNgan);
            _flagLoadFirst = true;
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagLoadFirst == true && cmbTo.SelectedIndex != -1)
            {
                if (_cTo.checkHanhThu(int.Parse(cmbTo.SelectedValue.ToString())) || _cTo.checkDongNuoc(int.Parse(cmbTo.SelectedValue.ToString())))
                    cmbNhanVien.DataSource = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbTo.SelectedValue.ToString()));
                else
                    cmbNhanVien.DataSource = _cNguoiDung.GetDSByToVanPhong(int.Parse(cmbTo.SelectedValue.ToString()));
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaND";
            }
            else
                cmbNhanVien.DataSource = null;
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
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHDTuGia.RowCount);
                txtTongGiaBan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongPhiBVMT_Thue_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT_Thue);
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        public void CoungdgvHDCoQuan()
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
                    if (item.Cells["TienDu_CQ"].Value.ToString() != "")
                        TongTienDu += long.Parse(item.Cells["TienDu_CQ"].Value.ToString());
                    if (item.Cells["TienMat_CQ"].Value.ToString() != "")
                        TongTienMat += long.Parse(item.Cells["TienMat_CQ"].Value.ToString());
                }
                txtTongHD_CQ.Text = dgvHDCoQuan.RowCount.ToString();
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHDCoQuan.RowCount);
                txtTongGiaBan_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongTienDu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongTienDu);
                txtTongTienMat_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongTienMat);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbNhanVien.Items.Count > 0 && cmbNhanVien.SelectedIndex >= 0)
                if (tabControl.SelectedTab.Name == "tabTuGia")
                {
                    dgvHDTuGia.DataSource = _cHoaDon.GetDSDangNgan("", (int)cmbNhanVien.SelectedValue, dateGiaiTrach.Value);
                    CountdgvHDTuGia();
                }
                else
                    if (tabControl.SelectedTab.Name == "tabTienDu")
                    {
                        if (cmbTo.SelectedIndex == 0)
                            dgvHDCoQuan.DataSource = _cHoaDon.getDSDangNgan_DieuChinhTienDu(dateGiaiTrach.Value);
                        else
                            if (cmbTo.SelectedIndex > 0)
                                dgvHDCoQuan.DataSource = _cHoaDon.getDSDangNgan_DieuChinhTienDu((int)cmbTo.SelectedValue, dateGiaiTrach.Value);
                        CoungdgvHDCoQuan();
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
                if (_cChotDangNgan.checkExist_ChotDangNgan(dateGiaiTrachSua.Value) == true)
                {
                    MessageBox.Show("Ngày Đăng Ngân đã Chốt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (lstHD.Items.Count > 0)
                {
                    foreach (ListViewItem item in lstHD.Items)
                    {
                        //if (_cHoaDon.CheckDangNganBySoHoaDon(item.ToString()))
                        //{
                        //    MessageBox.Show("Hóa Đơn đã Đăng Ngân: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("Hóa Đơn đã Khóa Tiền Dư " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lstHD.Focus();
                            item.Selected = true;
                            item.Focused = true;
                            return;
                        }
                        if (_cHoaDon.CheckDCHDTienDuBySoHoaDon(item.Text))
                        {
                            MessageBox.Show("Hóa Đơn đã Điều Chỉnh Tiền Dư " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (int.Parse(cmbNhanVien.SelectedValue.ToString()) == 52 && chkChuyenKhoanBinhThuong.Checked == false && chkChuyenKhoanTienMat.Checked == false)
                        {
                            MessageBox.Show("Bạn chưa chọn Chuyển Khoản Bình Thường hay Tiền Mặt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (int.Parse(cmbNhanVien.SelectedValue.ToString()) == 52)
                        {
                            if (chkChuyenKhoanBinhThuong.Checked)
                                foreach (ListViewItem item in lstHD.Items)
                                {
                                    var transactionOptions = new TransactionOptions();
                                    transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                                    {
                                        if (_cHoaDon.DangNgan("ChuyenKhoan", item.Text, int.Parse(cmbNhanVien.SelectedValue.ToString()), dateGiaiTrachSua.Value))
                                            if (_cTienDu.UpdateThem_Doi(item.Text, dateGiaiTrachSua.Value))
                                                scope.Complete();
                                    }
                                }
                            else
                                if (chkChuyenKhoanTienMat.Checked)
                                    foreach (ListViewItem item in lstHD.Items)
                                        if (_cTienDu.GetTienDu_SoHoaDon(item.Text) > 0)
                                        {
                                            var transactionOptions = new TransactionOptions();
                                            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                                            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                                            {
                                                if (_cHoaDon.DangNganTienMatChuyenKhoan(item.Text, int.Parse(cmbNhanVien.SelectedValue.ToString()), dateGiaiTrachSua.Value))
                                                    if (_cTienDu.UpdateThemTienMat_Doi(item.Text, dateGiaiTrachSua.Value))
                                                        scope.Complete();
                                            }
                                        }
                                        else
                                            MessageBox.Show("Lỗi, Danh Bộ không có Tiền Dư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            if (int.Parse(cmbNhanVien.SelectedValue.ToString()) == 51)
                            {
                                foreach (ListViewItem item in lstHD.Items)
                                {
                                    _cHoaDon.DangNgan("Quay", item.Text, int.Parse(cmbNhanVien.SelectedValue.ToString()), dateGiaiTrachSua.Value);
                                }
                            }
                            else
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
                                            if (_cHoaDon.DangNgan("Ton", item.Text, int.Parse(cmbNhanVien.SelectedValue.ToString()), dateGiaiTrachSua.Value))
                                                if (_cHoaDon.Thu2Lan(item.Text, ChuyenKhoan))
                                                    if (_cTamThu.XoaAn(item.Text))
                                                        if (_cTienDuQuay.UpdateXoa(item.Text, "Thu 2 Lần", "Thêm"))
                                                            scope.Complete();
                                        }
                                    }
                                    else
                                    {
                                        _cHoaDon.DangNgan("Ton", item.Text, int.Parse(cmbNhanVien.SelectedValue.ToString()), dateGiaiTrachSua.Value);
                                    }
                                }
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
                    try
                    {
                        if (tabControl.SelectedTab.Name == "tabTuGia")
                        {
                            foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                                if (_cChotDangNgan.checkExist_ChotDangNgan(_cHoaDon.GetNgayGiaiTrach(item.Cells["SoHoaDon_TG"].Value.ToString())) == true)
                                {
                                    MessageBox.Show("Ngày Đăng Ngân đã Chốt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            if (int.Parse(cmbNhanVien.SelectedValue.ToString()) == 52)
                                foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                                    ///đăng ngân tiền mặt
                                    if (_cHoaDon.CheckDangNganChuyenKhoanTienMat(item.Cells["SoHoaDon_TG"].Value.ToString()))
                                    {
                                        var transactionOptions = new TransactionOptions();
                                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                                        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                                        {
                                            if (_cTienDu.UpdateXoaTienMat_Doi(item.Cells["SoHoaDon_TG"].Value.ToString(), dateGiaiTrach.Value))
                                                if (_cHoaDon.XoaDangNganTienMatChuyenKhoan(item.Cells["SoHoaDon_TG"].Value.ToString(), int.Parse(cmbNhanVien.SelectedValue.ToString())))
                                                    scope.Complete();
                                        }
                                    }
                                    ///đăng ngân bình thường
                                    else
                                    {
                                        var transactionOptions = new TransactionOptions();
                                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                                        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                                        {
                                            if (_cHoaDon.XoaDangNgan("", item.Cells["SoHoaDon_TG"].Value.ToString(), int.Parse(cmbNhanVien.SelectedValue.ToString())))
                                                if (_cTienDu.UpdateXoa_Doi(item.Cells["SoHoaDon_TG"].Value.ToString(), dateGiaiTrach.Value))
                                                    scope.Complete();
                                        }
                                    }
                            ///nhân viên khác
                            else
                                foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                                    if (!_cHoaDon.XoaDangNgan("", item.Cells["SoHoaDon_TG"].Value.ToString(), int.Parse(cmbNhanVien.SelectedValue.ToString())))
                                    {
                                    }
                        }
                        else
                            if (tabControl.SelectedTab.Name == "tabCoQuan")
                            {
                                if (int.Parse(cmbNhanVien.SelectedValue.ToString()) == 52)
                                    foreach (DataGridViewRow item in dgvHDCoQuan.SelectedRows)
                                        ///đăng ngân tiền mặt
                                        if (_cHoaDon.CheckDangNganChuyenKhoanTienMat(item.Cells["SoHoaDon_CQ"].Value.ToString()))
                                        {
                                            var transactionOptions = new TransactionOptions();
                                            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                                            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                                            {
                                                if (_cTienDu.UpdateXoaTienMat(item.Cells["SoHoaDon_CQ"].Value.ToString()))
                                                    if (_cHoaDon.XoaDangNganTienMatChuyenKhoan(item.Cells["SoHoaDon_CQ"].Value.ToString(), int.Parse(cmbNhanVien.SelectedValue.ToString())))
                                                        scope.Complete();
                                            }
                                        }
                                        ///đăng ngân bình thường
                                        else
                                        {
                                            var transactionOptions = new TransactionOptions();
                                            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                                            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                                            {
                                                if (_cHoaDon.XoaDangNgan("", item.Cells["SoHoaDon_CQ"].Value.ToString(), int.Parse(cmbNhanVien.SelectedValue.ToString())))
                                                    if (_cTienDu.UpdateXoa(item.Cells["SoHoaDon_CQ"].Value.ToString()))
                                                        scope.Complete();
                                            }
                                        }
                                else
                                    foreach (DataGridViewRow item in dgvHDCoQuan.SelectedRows)
                                        if (!_cHoaDon.XoaDangNgan("", item.Cells["SoHoaDon_CQ"].Value.ToString(), int.Parse(cmbNhanVien.SelectedValue.ToString())))
                                        {
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

        private void dgvHDTuGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
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
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TienDu_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TienMat_CQ" && e.Value != null)
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

        private void chkChuyenKhoanBinhThuong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenKhoanBinhThuong.Checked)
                chkChuyenKhoanTienMat.Checked = false;
        }

        private void chkChuyenKhoanTienMat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenKhoanTienMat.Checked)
                chkChuyenKhoanBinhThuong.Checked = false;
        }

        private void btnXemChot_Click(object sender, EventArgs e)
        {
            try
            {
                dgvChotDangNgan.DataSource = _cChotDangNgan.getDS(dateTu.Value, dateDen.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemChot_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (_cChotDangNgan.checkExist(dateTu.Value) == true)
                    {
                        MessageBox.Show("Ngày Chốt đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    TT_ChotDangNgan en = new TT_ChotDangNgan();
                    en.NgayChot = dateTu.Value;
                    en.Chot = false;
                    if (_cChotDangNgan.them(en) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnXemChot.PerformClick();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChotDangNgan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "Chot")
                    {
                        TT_ChotDangNgan en = _cChotDangNgan.get(int.Parse(dgvChotDangNgan["ID", e.RowIndex].Value.ToString()));
                        en.Chot = bool.Parse(dgvChotDangNgan["Chot", e.RowIndex].Value.ToString());
                        if (_cChotDangNgan.sua(en) == true)
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChotDangNgan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "SyncNopTien")
                {
                    if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                    {
                        if (MessageBox.Show("Bạn có chắc chắn Nộp Tiền?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            TT_ChotDangNgan en = _cChotDangNgan.get(int.Parse(dgvChotDangNgan["ID", e.RowIndex].Value.ToString()));
                            if (_cChotDangNgan.checkExist_ChotDangNgan(en.NgayChot.Value) == true)
                            {
                                MessageBox.Show("Ngày Đăng Ngân đã Chốt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            wsThuTien.wsThuTien wsThuTien = new wsThuTien.wsThuTien();
                            wsThuTien.syncNopTienLo(en.NgayChot.Value.ToString("dd/MM/yyyy"));
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChotDangNgan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "SLDangNgan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "TCDangNgan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "SLHDDT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "SLThanhToan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "TCThanhToan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "SLNopTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "TCNopTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvChotDangNgan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvChotDangNgan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnChuyenNgayGiaiTrach_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn chuyển?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        try
                        {
                            if (tabControl.SelectedTab.Name == "tabTuGia")
                            {
                                foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                                {
                                    if (_cChotDangNgan.checkExist_ChotDangNgan(_cHoaDon.GetNgayGiaiTrach(item.Cells["SoHoaDon_TG"].Value.ToString())) == true)
                                    {
                                        MessageBox.Show("Ngày Đăng Ngân Sửa đã Chốt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    if (_cChotDangNgan.checkExist_ChotDangNgan(dateGiaiTrachSua.Value) == true)
                                    {
                                        MessageBox.Show("Ngày Đăng Ngân Sửa đã Chốt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    _cHoaDon.ExecuteNonQuery("update HOADON set NGAYGIAITRACH='" + dateGiaiTrachSua.Value.ToString("yyyyMMdd HH:mm:ss") + "' where SoHoaDon='" + item.Cells["SoHoaDon_TG"].Value.ToString() + "'");
                                }
                            }
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXem.PerformClick();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}

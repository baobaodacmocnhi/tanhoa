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
        bool _flagLoadFirst = false;

        public frmDieuChinhDangNganDoi()
        {
            InitializeComponent();
        }

        private void frmDieuChinhDangNganDoi_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            cmbTo.DataSource = _cTo.GetDS();
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";
            cmbTo.SelectedIndex = -1;

            dateGiaiTrach.Value = DateTime.Now;

            _flagLoadFirst = true;
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagLoadFirst == true && cmbTo.SelectedIndex != -1)
            {
                if ((_cTo.CheckHanhThu(int.Parse(cmbTo.SelectedValue.ToString()))))
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
            int TongGiaBan = 0;
            int TongThueGTGT = 0;
            int TongPhiBVMT = 0;
            int TongCong = 0;

            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    TongGiaBan += int.Parse(item.Cells["GiaBan_TG"].Value.ToString());
                    TongThueGTGT += int.Parse(item.Cells["ThueGTGT_TG"].Value.ToString());
                    TongPhiBVMT += int.Parse(item.Cells["PhiBVMT_TG"].Value.ToString());
                    TongCong += int.Parse(item.Cells["TongCong_TG"].Value.ToString());
                }
                txtTongHD_TG.Text = dgvHDTuGia.RowCount.ToString();
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHDTuGia.RowCount);
                txtTongGiaBan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        public void CoungdgvHDCoQuan()
        {
            int TongGiaBan = 0;
            int TongThueGTGT = 0;
            int TongPhiBVMT = 0;
            int TongCong = 0;

            if (dgvHDCoQuan.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    TongGiaBan += int.Parse(item.Cells["GiaBan_CQ"].Value.ToString());
                    TongThueGTGT += int.Parse(item.Cells["ThueGTGT_CQ"].Value.ToString());
                    TongPhiBVMT += int.Parse(item.Cells["PhiBVMT_CQ"].Value.ToString());
                    TongCong += int.Parse(item.Cells["TongCong_CQ"].Value.ToString());
                }
                txtTongHD_CQ.Text = dgvHDCoQuan.RowCount.ToString();
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHDCoQuan.RowCount);
                txtTongGiaBan_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbNhanVien.Items.Count > 0 && cmbNhanVien.SelectedIndex >= 0)
                if (tabControl.SelectedTab.Name == "tabTuGia")
                {
                    dgvHDTuGia.DataSource = _cHoaDon.GetDSDangNganByMaNVNgayGiaiTrach("TG", (int)cmbNhanVien.SelectedValue, dateGiaiTrach.Value);
                    CountdgvHDTuGia();
                }
                else
                    if (tabControl.SelectedTab.Name == "tabCoQuan")
                    {
                        dgvHDCoQuan.DataSource = _cHoaDon.GetDSDangNganByMaNVNgayGiaiTrach("CQ", (int)cmbNhanVien.SelectedValue, dateGiaiTrach.Value);
                        CoungdgvHDCoQuan();
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
                    }
                    try
                    {
                        if (int.Parse(cmbNhanVien.SelectedValue.ToString()) == 52 && chkChuyenKhoanBinhThuong.Checked == false && chkChuyenKhoanTienMat.Checked == false)
                        {
                            MessageBox.Show("Bạn chưa chọn Chuyển Khoản Bình Thường hay Tiền Mặt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        _cHoaDon.BeginTransaction();
                        if (int.Parse(cmbNhanVien.SelectedValue.ToString()) == 52)
                        {
                            if (chkChuyenKhoanBinhThuong.Checked)
                                foreach (ListViewItem item in lstHD.Items)
                                    if (_cHoaDon.DangNgan("", item.Text, int.Parse(cmbNhanVien.SelectedValue.ToString()), dateGiaiTrachSua.Value))
                                    {
                                        if (!_cTienDu.UpdateThem(item.Text))
                                        {
                                            _cHoaDon.Rollback();
                                            MessageBox.Show("Lỗi Update Tiền Dư, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        _cHoaDon.Rollback();
                                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                            else
                                if (chkChuyenKhoanTienMat.Checked)
                                    foreach (ListViewItem item in lstHD.Items)
                                        if (_cHoaDon.DangNganTienMatChuyenKhoan(item.Text, int.Parse(cmbNhanVien.SelectedValue.ToString()), dateGiaiTrachSua.Value))
                                        {
                                            if (!_cTienDu.UpdateThemTienMat(item.Text))
                                            {
                                                _cHoaDon.Rollback();
                                                MessageBox.Show("Lỗi Update Tiền Dư, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            _cHoaDon.Rollback();
                                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                        }
                        else
                            foreach (ListViewItem item in lstHD.Items)
                                if (_cHoaDon.DangNgan("", item.Text, int.Parse(cmbNhanVien.SelectedValue.ToString()), dateGiaiTrachSua.Value))
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
                                    _cHoaDon.Rollback();
                                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                        _cHoaDon.SubmitChanges();
                        _cHoaDon.CommitTransaction();
                        btnXem.PerformClick();
                        lstHD.Items.Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        _cHoaDon.Rollback();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        _cHoaDon.NullTransaction();
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
                        _cHoaDon.BeginTransaction();
                        if (tabControl.SelectedTab.Name == "tabTuGia")
                        {
                            if (int.Parse(cmbNhanVien.SelectedValue.ToString()) == 52)
                                foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                                    ///đăng ngân tiền mặt
                                    if (_cHoaDon.CheckDangNganChuyenKhoanTienMat(item.Cells["SoHoaDon_TG"].Value.ToString()))
                                        if (_cTienDu.UpdateXoaTienMat(item.Cells["SoHoaDon_TG"].Value.ToString()))
                                        {
                                            if (!_cHoaDon.XoaDangNganTienMatChuyenKhoan(item.Cells["SoHoaDon_TG"].Value.ToString(), CNguoiDung.MaND))
                                            {
                                                _cHoaDon.Rollback();
                                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            _cHoaDon.Rollback();
                                            MessageBox.Show("Lỗi Update Tiền Dư, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    ///đăng ngân bình thường
                                    else
                                        if (_cHoaDon.XoaDangNgan("", item.Cells["SoHoaDon_TG"].Value.ToString(), CNguoiDung.MaND))
                                        {
                                            if (!_cTienDu.UpdateXoa(item.Cells["SoHoaDon_TG"].Value.ToString()))
                                            {
                                                _cHoaDon.Rollback();
                                                MessageBox.Show("Lỗi Update Tiền Dư, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            _cHoaDon.Rollback();
                                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                            ///nhân viên khác
                            else
                            {
                                foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                                    if (!_cHoaDon.XoaDangNgan("", item.Cells["SoHoaDon_TG"].Value.ToString(), int.Parse(cmbNhanVien.SelectedValue.ToString())))
                                    {
                                        _cHoaDon.Rollback();
                                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                            }
                        }
                        else
                            if (tabControl.SelectedTab.Name == "tabCoQuan")
                            {
                                if (int.Parse(cmbNhanVien.SelectedValue.ToString()) == 52)
                                    foreach (DataGridViewRow item in dgvHDCoQuan.SelectedRows)
                                        ///đăng ngân tiền mặt
                                        if (_cHoaDon.CheckDangNganChuyenKhoanTienMat(item.Cells["SoHoaDon_CQ"].Value.ToString()))
                                            if (_cTienDu.UpdateXoaTienMat(item.Cells["SoHoaDon_CQ"].Value.ToString()))
                                            {
                                                if (_cHoaDon.XoaDangNganTienMatChuyenKhoan(item.Cells["SoHoaDon_CQ"].Value.ToString(), CNguoiDung.MaND))
                                                {
                                                    _cHoaDon.Rollback();
                                                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                _cHoaDon.Rollback();
                                                MessageBox.Show("Lỗi Update Tiền Dư, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                        ///đăng ngân bình thường
                                        else
                                            if (_cHoaDon.XoaDangNgan("", item.Cells["SoHoaDon_CQ"].Value.ToString(), CNguoiDung.MaND))
                                            {
                                                if (!_cTienDu.UpdateXoa(item.Cells["SoHoaDon_CQ"].Value.ToString()))
                                                {
                                                    _cHoaDon.Rollback();
                                                    MessageBox.Show("Lỗi Update Tiền Dư, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                _cHoaDon.Rollback();
                                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                else
                                    foreach (DataGridViewRow item in dgvHDCoQuan.SelectedRows)
                                        if (!_cHoaDon.XoaDangNgan("", item.Cells["SoHoaDon_CQ"].Value.ToString(), int.Parse(cmbNhanVien.SelectedValue.ToString())))
                                        {
                                            _cHoaDon.Rollback();
                                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                            }
                        _cHoaDon.SubmitChanges();
                        _cHoaDon.CommitTransaction();
                        btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        _cHoaDon.Rollback();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        _cHoaDon.NullTransaction();
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
    }
}

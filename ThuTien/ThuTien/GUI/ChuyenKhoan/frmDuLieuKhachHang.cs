﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using System.Globalization;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.LinQ;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmDuLieuKhachHang : Form
    {
        string _mnu = "mnuDuLieuKhachHang";
        CHoaDon _cHoaDon = new CHoaDon();
        CDuLieuKhachHang _cDLKH = new CDuLieuKhachHang();

        public frmDuLieuKhachHang()
        {
            InitializeComponent();
        }

        private void frmDuLieuKhachHang_Load(object sender, EventArgs e)
        {
            dgvHDDaThu.AutoGenerateColumns = false;
            dgvHDChuaThu.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
        }

        public void LoadDanhSachHD()
        {
            dgvHDDaThu.DataSource = _cDLKH.GetDSDangNgan(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
            dgvHDChuaThu.DataSource = _cDLKH.GetDSTon(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
            int TongCong = 0;
            if (dgvHDDaThu.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDDaThu.Rows)
                {
                    TongCong += int.Parse(item.Cells["TongCong_DT"].Value.ToString());
                }
                if (TongCong == 0)
                    txtTongCong_DT.Text = "0";
                else
                    txtTongCong_DT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
            TongCong = 0;
            if (dgvHDChuaThu.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDChuaThu.Rows)
                {
                    TongCong += int.Parse(item.Cells["TongCong_CT"].Value.ToString());
                }
                if (TongCong == 0)
                    txtTongCong_CT.Text = "0";
                else
                    txtTongCong_CT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbNam.SelectedIndex != -1 && cmbKy.SelectedIndex != -1)
            {
                LoadDanhSachHD();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (cmbKy.SelectedIndex == -1)
                    {
                        MessageBox.Show("Vui lòng chọn Kỳ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _cDLKH.BeginTransaction();
                    foreach (string item in txtDanhBo.Lines)
                        if (item.Length == 11)
                        {
                            TT_DuLieuKhachHang dlkh = new TT_DuLieuKhachHang();
                            dlkh.Nam = (int)cmbNam.SelectedValue;
                            dlkh.Ky = int.Parse(cmbKy.SelectedItem.ToString());
                            dlkh.DanhBo = item;
                            if (!_cDLKH.Them(dlkh))
                            {
                                _cDLKH.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    _cDLKH.CommitTransaction();
                    LoadDanhSachHD();
                    txtDanhBo.Text = "";
                    cmbKy.SelectedIndex = -1;
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    _cDLKH.Rollback();
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
                try
                {
                    _cDLKH.BeginTransaction();
                    if (tabControl.SelectedTab.Name == "tabDaThu")
                    {
                        foreach (DataGridViewRow item in dgvHDDaThu.SelectedRows)
                        {
                            TT_DuLieuKhachHang dlkh = _cDLKH.GetByNamKyDanhBo(int.Parse(item.Cells["Nam_DT"].Value.ToString()), int.Parse(item.Cells["Ky_DT"].Value.ToString()), item.Cells["DanhBo_DT"].Value.ToString());
                            if (!_cDLKH.Xoa(dlkh))
                            {
                                _cDLKH.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else
                        if (tabControl.SelectedTab.Name == "tabChuaThu")
                        {
                            foreach (DataGridViewRow item in dgvHDChuaThu.SelectedRows)
                            {
                                TT_DuLieuKhachHang dlkh = _cDLKH.GetByNamKyDanhBo(int.Parse(item.Cells["Nam_CT"].Value.ToString()), int.Parse(item.Cells["Ky_CT"].Value.ToString()), item.Cells["DanhBo_CT"].Value.ToString());
                                if (!_cDLKH.Xoa(dlkh))
                                {
                                    _cDLKH.Rollback();
                                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                    _cDLKH.CommitTransaction();
                    LoadDanhSachHD();
                    txtDanhBo.Text = "";
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    _cDLKH.Rollback();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvHDDaThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "DanhBo_DT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "TieuThu_DT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "GiaBan_DT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "ThueGTGT_DT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "PhiBVMT_DT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "TongCong_DT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDDaThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDDaThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHDChuaThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "DanhBo_CT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "TieuThu_CT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "GiaBan_CT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "ThueGTGT_CT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "PhiBVMT_CT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "TongCong_CT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDChuaThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDChuaThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
            {
                foreach (string item in txtSoHoaDon.Lines)
                    if (!string.IsNullOrEmpty(item.Trim()) && !lstHD.Items.Contains(item.Trim()))
                    {
                        lstHD.Items.Add(item.Trim());
                    }
                txtSoLuong.Text = lstHD.Items.Count.ToString();
                txtSoHoaDon.Text = "";
            }
        }

        private void lstHD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstHD.Items.Count > 0 && lstHD.SelectedIndex != -1)
                lstHD.Items.RemoveAt(lstHD.SelectedIndex);
        }

        private void lstHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoLuong.Text = lstHD.Items.Count.ToString();
        }

        private void btnXem2_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = _cDLKH.GetDS2(dateLap.Value);
        }

        private void btnThem2_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                foreach (var item in lstHD.Items)
                {
                    if (!_cHoaDon.CheckBySoHoaDon(item.ToString()))
                    {
                        MessageBox.Show("Hóa Đơn sai: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstHD.SelectedItem = item;
                        return;
                    }
                }
                try
                {
                    _cDLKH.BeginTransaction();
                    foreach (var item in lstHD.Items)
                    {
                        TT_DuLieuKhachHang_SoHoaDon dlkh = new TT_DuLieuKhachHang_SoHoaDon();
                        dlkh.SoHoaDon = item.ToString();
                        if (!_cDLKH.Them2(dlkh))
                        {
                            _cDLKH.Rollback();
                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    _cDLKH.CommitTransaction();
                    lstHD.Items.Clear();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    _cDLKH.Rollback();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa2_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    _cDLKH.BeginTransaction();
                    foreach (DataGridViewRow item in dgvHoaDon.Rows)
                    {
                        TT_DuLieuKhachHang_SoHoaDon dlkh = _cDLKH.GetBySoHoaDon2(item.Cells["SoHoaDon"].Value.ToString());
                        if (!_cDLKH.Xoa2(dlkh))
                        {
                            _cDLKH.Rollback();
                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    _cDLKH.CommitTransaction();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    _cDLKH.Rollback();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

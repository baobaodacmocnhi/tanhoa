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

namespace ThuTien.GUI.Quay
{
    public partial class frmDangNganQuay : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();
        string _mnu = "mnuDangNganQuay";
        CTamThu _cTamThu = new CTamThu();
        CDCHD _cDCHD = new CDCHD();

        public frmDangNganQuay()
        {
            InitializeComponent();
        }

        private void frmDangNganQuay_Load(object sender, EventArgs e)
        {
            dgvHDDaThu.AutoGenerateColumns = false;
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
                if (!lstHD.Items.Contains(txtSoHoaDon.Text.Trim()))
                {
                    lstHD.Items.Add(txtSoHoaDon.Text.Trim());
                    txtSoHoaDon.Text = "";
                }
                else
                    txtSoHoaDon.Text = "";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dateTu.Value <= dateDen.Value)
            {
                dgvHDDaThu.DataSource = _cHoaDon.GetDSDangNganQuayByMaNVNgayGiaiTrachs(CNguoiDung.MaND, dateTu.Value, dateDen.Value);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                foreach (var item in lstHD.Items)
                {
                    string loai;
                    if (!_cTamThu.CheckBySoHoaDon(item.ToString(),out loai))
                    {
                        MessageBox.Show("Hóa Đơn không có Tạm Thu: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstHD.SelectedItem = item;
                        return;
                    }
                    if (loai == "Chuyển Khoản")
                    {
                        MessageBox.Show("Hóa Đơn có Tạm Thu(Chuyển Khoản): " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstHD.SelectedItem = item;
                        return;
                    }
                    if (_cDCHD.CheckBySoHoaDon(item.ToString()))
                    {
                        MessageBox.Show("Hóa Đơn đã Rút đi Điều Chỉnh: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstHD.SelectedItem = item;
                        return;
                    }
                }
                try
                {
                    _cHoaDon.SqlBeginTransaction();
                    foreach (var item in lstHD.Items)
                        if (!_cHoaDon.DangNgan("Quay", item.ToString(), CNguoiDung.MaND))
                        {
                            _cHoaDon.SqlRollbackTransaction();
                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    _cHoaDon.SqlCommitTransaction();
                    lstHD.Items.Clear();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    _cHoaDon.SqlRollbackTransaction();
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
                if (dgvHDDaThu.RowCount > 0)
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        foreach (DataGridViewRow item in dgvHDDaThu.SelectedRows)
                        {
                            if (_cHoaDon.XoaDangNgan("Quay", item.Cells["SoHoaDon"].Value.ToString(), CNguoiDung.MaND))
                            {

                            }
                        }
                        if (dgvHDDaThu.RowCount > 0)
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void lstHD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstHD.Items.Count > 0)
                lstHD.Items.RemoveAt(lstHD.SelectedIndex);
        }

        private void dgvHDDaThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "GiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "ThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "PhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
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

    }
}

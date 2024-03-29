﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;

namespace DocSo_PC.GUI.QuanTri
{
    public partial class frmTo : Form
    {
        CTo _cTo = new CTo();
        int _selectedindex = -1;
        string _mnu = "mnuTo";

        public frmTo()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            _selectedindex = -1;
            txtTenTo.Text = "";
            chkHanhThu.Checked = false;
            txtTuMay.Text = "";
            txtDenMay.Text = "";
            loaddgv();
        }

        public void loaddgv()
        {
            if (CNguoiDung.Admin)
                dgvTo.DataSource = _cTo.getDS(((Phong)cmbPhong.SelectedItem).ID);
            else
                dgvTo.DataSource = _cTo.getDS();
        }

        private void frmTo_Load(object sender, EventArgs e)
        {
            dgvTo.AutoGenerateColumns = false;
            if (CNguoiDung.Admin)
            {
                panel1.Visible = true;
                cmbPhong.DataSource = _cTo.getDS_Phong();
                cmbPhong.DisplayMember = "Name";
                cmbPhong.ValueMember = "ID";
            }
            else
            {
                panel1.Visible = false;
            }
            loaddgv();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (txtTenTo.Text.Trim() != "")
                {
                    To to = new To();
                    to.TenTo = txtTenTo.Text.Trim();
                    to.HanhThu = chkHanhThu.Checked;
                    if (!string.IsNullOrEmpty(txtTuMay.Text.Trim()))
                        to.TuMay = int.Parse(txtTuMay.Text.Trim());
                    if (!string.IsNullOrEmpty(txtDenMay.Text.Trim()))
                        to.DenMay = int.Parse(txtDenMay.Text.Trim());
                    to.IDPhong = CNguoiDung.IDPhong;
                    _cTo.Them(to);
                    Clear();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (_selectedindex != -1)
                {
                    To to = _cTo.get(int.Parse(dgvTo["MaTo", _selectedindex].Value.ToString()));
                    to.TenTo = txtTenTo.Text.Trim();
                    to.HanhThu = chkHanhThu.Checked;
                    if (!string.IsNullOrEmpty(txtTuMay.Text.Trim()))
                        to.TuMay = int.Parse(txtTuMay.Text.Trim());
                    else
                        to.TuMay = null;
                    if (!string.IsNullOrEmpty(txtDenMay.Text.Trim()))
                        to.DenMay = int.Parse(txtDenMay.Text.Trim());
                    else
                        to.DenMay = null;
                    _cTo.Sua(to);
                    Clear();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (_selectedindex != -1)
                    {
                        To to = _cTo.get(int.Parse(dgvTo["MaTo", _selectedindex].Value.ToString()));
                        _cTo.Xoa(to);
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Lỗi, Vui lòng chọn Tổ cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvTo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindex = e.RowIndex;
                txtTenTo.Text = dgvTo["TenTo", e.RowIndex].Value.ToString();
                chkHanhThu.Checked = bool.Parse(dgvTo["HanhThu", e.RowIndex].Value.ToString());
                txtTuMay.Text = dgvTo["TuMay", e.RowIndex].Value.ToString();
                txtDenMay.Text = dgvTo["DenMay", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void dgvTo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }

        }

        private void txtCuonGCS_From_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtCuonGCS_To_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            loaddgv();
        }



    }
}

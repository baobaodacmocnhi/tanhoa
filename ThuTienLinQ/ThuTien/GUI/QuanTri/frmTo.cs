﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;

namespace ThuTien.GUI.QuanTri
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
            txtTuCuonGCS.Text = "";
            txtDenCuonGCS.Text = "";
            dgvTo.DataSource = _cTo.GetDS();
        }

        private void frmTo_Load(object sender, EventArgs e)
        {
            dgvTo.AutoGenerateColumns = false;
            dgvTo.DataSource = _cTo.GetDS();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (txtTenTo.Text.Trim() != "")
                {
                    TT_To to = new TT_To();
                    to.TenTo = txtTenTo.Text.Trim();
                    to.HanhThu = chkHanhThu.Checked;
                    if (!string.IsNullOrEmpty(txtTuCuonGCS.Text.Trim()))
                        to.TuCuonGCS = int.Parse(txtTuCuonGCS.Text.Trim());
                    if (!string.IsNullOrEmpty(txtDenCuonGCS.Text.Trim()))
                        to.DenCuonGCS = int.Parse(txtDenCuonGCS.Text.Trim());
                    _cTo.Them(to);
                    Clear();
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
                    TT_To to = _cTo.GetByMaTo(int.Parse(dgvTo["MaTo", _selectedindex].Value.ToString()));
                    to.TenTo = txtTenTo.Text.Trim();
                    to.HanhThu = chkHanhThu.Checked;
                    if (!string.IsNullOrEmpty(txtTuCuonGCS.Text.Trim()))
                        to.TuCuonGCS = int.Parse(txtTuCuonGCS.Text.Trim());
                    if (!string.IsNullOrEmpty(txtDenCuonGCS.Text.Trim()))
                        to.DenCuonGCS = int.Parse(txtDenCuonGCS.Text.Trim());
                    _cTo.Sua(to);
                    Clear();
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (_selectedindex != -1)
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        TT_To to = _cTo.GetByMaTo(int.Parse(dgvTo["MaTo", _selectedindex].Value.ToString()));
                        _cTo.Xoa(to);
                        Clear();
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvTo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindex = e.RowIndex;
                txtTenTo.Text = dgvTo["TenTo", e.RowIndex].Value.ToString();
                chkHanhThu.Checked = bool.Parse(dgvTo["HanhThu", e.RowIndex].Value.ToString());
                txtTuCuonGCS.Text = dgvTo["TuCuonGCS", e.RowIndex].Value.ToString();
                txtDenCuonGCS.Text = dgvTo["DenCuonGCS", e.RowIndex].Value.ToString();
            }
            catch(Exception)
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


    }
}

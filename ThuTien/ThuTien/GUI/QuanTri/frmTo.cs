using System;
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
            chkDongNuoc.Checked = false;
            chkAn.Checked = false;
            txtTuCuonGCS.Text = "";
            txtDenCuonGCS.Text = "";
            loaddgv();
        }

        public void loaddgv()
        {
            if (CNguoiDung.Admin)
                dgvTo.DataSource = _cTo.getDS(((Phong)cmbPhong.SelectedItem).ID);
            else
                dgvTo.DataSource = _cTo.getDS(CNguoiDung.IDPhong);
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
                    TT_To to = new TT_To();
                    to.TenTo = txtTenTo.Text.Trim();
                    to.HanhThu = chkHanhThu.Checked;
                    to.DongNuoc = chkDongNuoc.Checked;
                    to.An = chkAn.Checked;
                    if (!string.IsNullOrEmpty(txtTuCuonGCS.Text.Trim()))
                        to.TuCuonGCS = int.Parse(txtTuCuonGCS.Text.Trim());
                    if (!string.IsNullOrEmpty(txtDenCuonGCS.Text.Trim()))
                        to.DenCuonGCS = int.Parse(txtDenCuonGCS.Text.Trim());
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
                    TT_To to = _cTo.get(int.Parse(dgvTo["MaTo", _selectedindex].Value.ToString()));
                    to.TenTo = txtTenTo.Text.Trim();
                    to.HanhThu = chkHanhThu.Checked;
                    to.DongNuoc = chkDongNuoc.Checked;
                    to.An = chkAn.Checked;
                    if (!string.IsNullOrEmpty(txtTuCuonGCS.Text.Trim()))
                        to.TuCuonGCS = int.Parse(txtTuCuonGCS.Text.Trim());
                    else
                        to.TuCuonGCS = null;
                    if (!string.IsNullOrEmpty(txtDenCuonGCS.Text.Trim()))
                        to.DenCuonGCS = int.Parse(txtDenCuonGCS.Text.Trim());
                    else
                        to.DenCuonGCS = null;
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
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (_selectedindex != -1)
                    {
                        TT_To to = _cTo.get(int.Parse(dgvTo["MaTo", _selectedindex].Value.ToString()));
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
                chkDongNuoc.Checked = bool.Parse(dgvTo["DongNuoc", e.RowIndex].Value.ToString());
                chkAn.Checked = bool.Parse(dgvTo["An", e.RowIndex].Value.ToString());
                txtTuCuonGCS.Text = dgvTo["TuCuonGCS", e.RowIndex].Value.ToString();
                txtDenCuonGCS.Text = dgvTo["DenCuonGCS", e.RowIndex].Value.ToString();
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

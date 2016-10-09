using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.QuanTri
{
    public partial class frmTo : Form
    {
        string _mnu = "mnuTo";
        CTo _cTo = new CTo();
        int _selectedindex = -1;

        public frmTo()
        {
            InitializeComponent();
        }

        private void frmTo_Load(object sender, EventArgs e)
        {
            dgvTo.AutoGenerateColumns = false;
            dgvTo.DataSource = _cTo.GetDS();
        }

        public void Clear()
        {
            _selectedindex = -1;
            txtTenTo.Text = "";
            dgvTo.DataSource = _cTo.GetDS();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                if (txtTenTo.Text.Trim() != "")
                {
                    To to = new To();
                    to.TenTo = txtTenTo.Text.Trim();
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
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                if (_selectedindex != -1)
                {
                    To to = _cTo.GetByMaTo(int.Parse(dgvTo["MaTo", _selectedindex].Value.ToString()));
                    to.TenTo = txtTenTo.Text.Trim();
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
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (_selectedindex != -1)
                    {
                        To to = _cTo.GetByMaTo(int.Parse(dgvTo["MaTo", _selectedindex].Value.ToString()));
                        to.An = true;
                        _cTo.Sua(to);
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Lỗi, Vui lòng chọn Tổ cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}

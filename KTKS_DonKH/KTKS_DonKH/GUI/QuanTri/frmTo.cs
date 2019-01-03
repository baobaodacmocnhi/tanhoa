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
        To _to = null;

        public frmTo()
        {
            InitializeComponent();
        }

        private void frmTo_Load(object sender, EventArgs e)
        {
            dgvTo.AutoGenerateColumns = false;
            Clear();
        }

        public void Clear()
        {
            _to = null;
            txtTenTo.Text = "";
            txtKyHieu.Text = "";
            dgvTo.DataSource = _cTo.getDS();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                if (txtTenTo.Text.Trim() != "")
                {
                    To to = new To();
                    to.TenTo = txtTenTo.Text.Trim();
                    to.KyHieu = txtKyHieu.Text.Trim();
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
                if (_to != null)
                {
                    _to.TenTo = txtTenTo.Text.Trim();
                    _to.KyHieu = txtKyHieu.Text.Trim();
                    _cTo.Sua(_to);
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
                    if (_to != null)
                    {
                        _to.An = true;
                        _cTo.Sua(_to);
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Lỗi, Vui lòng chọn Tổ cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvTo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _to = _cTo.get(int.Parse(dgvTo.CurrentRow.Cells["MaTo"].Value.ToString()));
            if (_to != null)
            {
                txtTenTo.Text = _to.TenTo;
                txtKyHieu.Text = _to.KyHieu;
            }
        }

    }
}

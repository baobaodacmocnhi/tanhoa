using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.LinQ;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmNganHang : Form
    {
        string _mnu = "mnuNganHang";
        CNganHang _cNganHang = new CNganHang();
        int _selectedindex = -1;

        public frmNganHang()
        {
            InitializeComponent();
        }

        private void frmNganHang_Load(object sender, EventArgs e)
        {
            dgvNganHang.AutoGenerateColumns = false;
            dgvNganHang.DataSource = _cNganHang.GetDS();
        }

        public void Clear()
        {
            txtTenNH.Text = "";
            _selectedindex = -1;
            dgvNganHang.DataSource = _cNganHang.GetDS();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if(!string.IsNullOrEmpty(txtTenNH.Text.Trim()))
                {
                    NGANHANG nganhang = new NGANHANG();
                    nganhang.KyHieu = txtKyHieu.Text.Trim();
                    nganhang.NGANHANG1 = txtTenNH.Text.Trim();
                    if (_cNganHang.Them(nganhang))
                    {
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
                    NGANHANG nganhang = _cNganHang.GetByMaNH(int.Parse(dgvNganHang["MaNH", _selectedindex].Value.ToString()));
                    nganhang.KyHieu = txtKyHieu.Text.Trim();
                    nganhang.NGANHANG1 = txtTenNH.Text.Trim();
                    if (_cNganHang.Sua(nganhang))
                    {
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
                {
                    NGANHANG nganhang = _cNganHang.GetByMaNH(int.Parse(dgvNganHang["MaNH", _selectedindex].Value.ToString()));
                    if (_cNganHang.Xoa(nganhang))
                    {
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvNganHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindex = e.RowIndex;
                txtKyHieu.Text = dgvNganHang["KyHieu", e.RowIndex].Value.ToString();
                txtTenNH.Text = dgvNganHang["TenNH", e.RowIndex].Value.ToString();
            }
            catch
            {
            }
        }
    }
}

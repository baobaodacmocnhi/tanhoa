using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KeToan.DAL.QuanTri;
using KeToan.LinQ;
using KeToan.DAL.CapNhat;

namespace KeToan.GUI.CapNhat
{
    public partial class frmNganHang : Form
    {
        string _mnu = "mnuNganHang";
        CNganHang _cNganHang = new CNganHang();
        NganHang _nganhang = null;

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
            txtKyHieu.Text = "";
            txtSoTK_Co.Text = "";
            txtSoTK_No.Text = "";
            _nganhang = null;
            dgvNganHang.DataSource = _cNganHang.GetDS();
        }

        public void LoadEntity(NganHang entity)
        {
            txtKyHieu.Text = entity.KyHieu;
            txtTenNH.Text = entity.Name;
            if (entity.SoTK_No != null)
                txtSoTK_No.Text = entity.SoTK_No.Value.ToString();
            if (entity.SoTK_Co != null)
                txtSoTK_Co.Text = entity.SoTK_Co.Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Them"))
                {
                    if (!string.IsNullOrEmpty(txtKyHieu.Text.Trim()) && !string.IsNullOrEmpty(txtTenNH.Text.Trim()))
                    {
                        NganHang nganhang = new NganHang();
                        nganhang.KyHieu = txtKyHieu.Text.Trim();
                        nganhang.Name = txtTenNH.Text.Trim();
                        if (txtSoTK_Co.Text.Trim() != "")
                            nganhang.SoTK_Co = int.Parse(txtSoTK_Co.Text.Trim());
                        if (txtSoTK_No.Text.Trim() != "")
                            nganhang.SoTK_No = int.Parse(txtSoTK_No.Text.Trim());
                        if (_cNganHang.Them(nganhang))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Sua"))
                {
                    if (_nganhang != null)
                    {
                        _nganhang.KyHieu = txtKyHieu.Text.Trim();
                        _nganhang.Name = txtTenNH.Text.Trim();
                        if (txtSoTK_Co.Text.Trim() != "")
                            _nganhang.SoTK_Co = int.Parse(txtSoTK_Co.Text.Trim());
                        if (txtSoTK_No.Text.Trim() != "")
                            _nganhang.SoTK_No = int.Parse(txtSoTK_No.Text.Trim());
                        if (_cNganHang.Sua(_nganhang))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                    else
                        MessageBox.Show("Lỗi, Vui lòng chọn Đối Tượng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (_nganhang != null)
                        {
                            if (_cNganHang.Xoa(_nganhang))
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
                            }
                        }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNganHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _nganhang = _cNganHang.Get(int.Parse(dgvNganHang.CurrentRow.Cells["ID"].Value.ToString()));
                LoadEntity(_nganhang);
            }
            catch
            {
            }
        }
    }
}

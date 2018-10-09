using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmKhuCongNghiep : Form
    {
        string _mnu = "mnuKhuCongNghiep";
        CKhuCongNghiep _cKCN = new CKhuCongNghiep();

        public frmKhuCongNghiep()
        {
            InitializeComponent();
        }

        private void frmKhuCongNghiep_Load(object sender, EventArgs e)
        {
            dgvDanhBo.AutoGenerateColumns = false;

            loaddgvDanhBo();
        }

        public void loaddgvDanhBo()
        {
            dgvDanhBo.DataSource = _cKCN.getDS();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (txtDanhBo.Text.Trim().Replace(" ", "") == ""||txtDinhMuc.Text.Trim().Replace(" ", "") == "")
                    {
                        MessageBox.Show("Thông tin thiếu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_cKCN.checkExist(txtDanhBo.Text.Trim().Replace(" ", "")) == true)
                    {
                        MessageBox.Show("Danh Bộ đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    KhuCongNghiep en = new KhuCongNghiep();
                    en.DanhBo=txtDanhBo.Text.Trim().Replace(" ", "");
                    en.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                    if (_cKCN.Them(en) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loaddgvDanhBo();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (txtDanhBo.Text.Trim().Replace(" ", "") == "")
                    {
                        MessageBox.Show("Thông tin thiếu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    KhuCongNghiep en = _cKCN.get(txtDanhBo.Text.Trim().Replace(" ", ""));
                    if (en != null)
                        if (_cKCN.Xoa(en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loaddgvDanhBo();
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvDanhBo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtDanhBo.Text = dgvDanhBo.CurrentRow.Cells["DanhBo"].Value.ToString();
                txtDinhMuc.Text = dgvDanhBo.CurrentRow.Cells["DinhMuc"].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        
    }
}

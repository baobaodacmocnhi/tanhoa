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
            dgvKhauTru.AutoGenerateColumns = false;
            dgvKhauTruLichSu.AutoGenerateColumns = false;
            loaddgvDanhBo();
            loaddgvKhauTru();
        }

        public void loaddgvDanhBo()
        {
            dgvDanhBo.DataSource = _cKCN.getDS();
        }

        public void loaddgvKhauTru()
        {
            dgvKhauTru.DataSource = _cKCN.getDS_KhauTru();
            dgvKhauTruLichSu.DataSource = null;
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

        private void dgvDanhBo_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void btnThem_KhauTru_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (txtDanhBo_KhauTru.Text.Trim().Replace(" ", "") == "" || txtSoTien_KhauTru.Text.Trim().Replace(" ", "") == "")
                    {
                        MessageBox.Show("Thông tin thiếu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_cKCN.checkExist_KhauTru(txtDanhBo.Text.Trim().Replace(" ", "")) == true)
                    {
                        MessageBox.Show("Danh Bộ còn tồn Khấu Trừ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DCBD_KhauTru en = new DCBD_KhauTru();
                    en.DanhBo = txtDanhBo_KhauTru.Text.Trim().Replace(" ", "");
                    en.SoTien = int.Parse(txtSoTien_KhauTru.Text.Trim());
                    if (_cKCN.Them_KhauTru(en) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loaddgvKhauTru();
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

        private void btnSua_KhauTru_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_KhauTru_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    DCBD_KhauTru en = _cKCN.get_KhauTru(txtDanhBo_KhauTru.Text.Trim().Replace(" ", ""));
                    if (en != null)
                        if (_cKCN.Xoa_KhauTru(en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loaddgvKhauTru();
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

        private void dgvKhauTru_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtDanhBo_KhauTru.Text = dgvKhauTru.CurrentRow.Cells["DanhBo_KhauTru"].Value.ToString();
                txtSoTien_KhauTru.Text = dgvKhauTru.CurrentRow.Cells["SoTien_KhauTru"].Value.ToString();
                dgvKhauTruLichSu.DataSource = _cKCN.getDS_KhauTruLichSu(int.Parse(dgvKhauTru["ID", e.RowIndex].Value.ToString()));
            }
            catch (Exception)
            {
            }
        }

        private void dgvKhauTru_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKhauTru.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvKhauTruLichSu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKhauTruLichSu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvKhauTru_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKhauTru.Columns[e.ColumnIndex].Name == "TatToan")
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    try
                    {
                        DCBD_KhauTru en = _cKCN.get_KhauTru(txtDanhBo_KhauTru.Text.Trim().Replace(" ", ""));
                        if (en != null)
                        {
                            en.TatToan = bool.Parse(dgvKhauTru["TatToan", e.RowIndex].Value.ToString());
                            if (_cKCN.Sua_KhauTru(en) == true)
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loaddgvKhauTru();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.PhongKhachHang
{
    public partial class frmCapNhatDienThoai : Form
    {
        string _mnu = "mnuCapNhatDienThoai";
        CDHN _cDHN = new CDHN();
        SDT_DHN _en = null;

        public frmCapNhatDienThoai()
        {
            InitializeComponent();
        }

        private void frmCapNhatDienThoai_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Replace("-", "").Replace(" ", "").Length == 11)
                {
                    TB_DULIEUKHACHHANG ttkh = _cDHN.GetTTKH(txtDanhBo.Text.Trim().Replace("-", "").Replace(" ", ""));
                    if (ttkh != null)
                        dgvDanhSach.DataSource = _cDHN.getDS_DienThoai(txtDanhBo.Text.Trim().Replace("-", "").Replace(" ", ""));
                    else
                        MessageBox.Show("Danh Bộ không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    TB_DULIEUKHACHHANG ttkh = _cDHN.GetTTKH(txtDanhBo.Text.Trim().Replace("-", "").Replace(" ", ""));
                    if (ttkh != null)
                    {
                        if (txtDienThoai.Text.Trim().Replace("-", "").Replace(" ", "").Length != 10)
                        {
                            MessageBox.Show("Điện Thoại phải là 10 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (_cDHN.checkExists_DienThoai(ttkh.DANHBO, txtDienThoai.Text.Trim().Replace("-", "").Replace(" ", "")))
                        {
                            MessageBox.Show("Điện Thoại đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        SDT_DHN en = new SDT_DHN();
                        en.DanhBo = ttkh.DANHBO;
                        en.DienThoai = txtDienThoai.Text.Trim().Replace("-", "").Replace(" ", "");
                        en.SoChinh = true;
                        en.GhiChu = "P. KH";
                        if (_cDHN.them_DienThoai(en))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _en = null;
                            dgvDanhSach.DataSource = _cDHN.getDS_DienThoai(ttkh.DANHBO);
                        }
                    }
                    else
                        MessageBox.Show("Danh Bộ không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_en != null)
                        {
                            if (_en.GhiChu != "P. KH")
                            {
                                MessageBox.Show("Điện Thoại không thuộc P. KH nên xóa không được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (_cDHN.xoa_DienThoai(_en))
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _en = null;
                                dgvDanhSach.DataSource = _cDHN.getDS_DienThoai(txtDanhBo.Text.Trim().Replace("-", "").Replace(" ", ""));
                            }
                        }
                        else
                            MessageBox.Show("Điện Thoại chưa chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _en = _cDHN.get_DienThoai(dgvDanhSach["DanhBo", e.RowIndex].Value.ToString(), dgvDanhSach["DienThoai", e.RowIndex].Value.ToString());
                txtDanhBo.Text = _en.DanhBo;
                txtDienThoai.Text = _en.DienThoai;
            }
            catch
            {

            }
        }
    }
}

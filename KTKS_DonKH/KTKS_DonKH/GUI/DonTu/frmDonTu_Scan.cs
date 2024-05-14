using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.wrThuongVu;
using KTKS_DonKH.DAL;

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmDonTu_Scan : Form
    {
        string _mnu = "mnuScanDonTu";
        CDonTu _cDonTu = new CDonTu();
        CThuTien _cThuTien = new CThuTien();
        DonTu_Scan _scan = null;
        HOADON _hoadon = null;
        wsThuongVu _wsThuongVu = new wsThuongVu();
        public frmDonTu_Scan()
        {
            InitializeComponent();
        }

        private void frmDonTu_Scan_Load(object sender, EventArgs e)
        {
            dgvScan.AutoGenerateColumns = false;
            dgvHinh.AutoGenerateColumns = false;
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtNguoiBao.Text = "";
            _scan = null;
            _hoadon = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    DonTu_Scan en = new DonTu_Scan();
                    en.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", "");
                    en.DienThoai = txtDienThoai.Text.Trim();
                    en.NguoiBao = txtNguoiBao.Text.Trim();
                    if (_cDonTu.Them_Scan(en))
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (_scan != null && MessageBox.Show("Bạn chắc chắn???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_cDonTu.Xoa_Scan(_scan))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", ""));
                if (_hoadon != null)
                {
                    txtHoTen.Text = _hoadon.TENKH;
                    txtDiaChi.Text = _hoadon.SO + " " + _hoadon.DUONG;
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvScan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _scan = _cDonTu.get_Scan(int.Parse(dgvScan.CurrentRow.Cells["ID"].Value.ToString()));
            }
            catch { }
        }

        private void dgvScan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvScan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHinh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHinh.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvScan.DataSource = _cDonTu.getDS_Scan(dateTu.Value, dateDen.Value);
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {

        }

        private void dgvHinh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvHinh_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dgvHinh_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}

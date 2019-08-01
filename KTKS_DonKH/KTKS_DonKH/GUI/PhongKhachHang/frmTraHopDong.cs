using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.PhongKhachHang;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL;

namespace KTKS_DonKH.GUI.PhongKhachHang
{
    public partial class frmTraHopDong : Form
    {
        string _mnu = "mnuTraHopDong";
        CTraHopDong _cTHD = new CTraHopDong();
        KH_HopDong _en = new KH_HopDong();
        CDHN _cDHN = new CDHN();

        public frmTraHopDong()
        {
            InitializeComponent();
        }

        private void frmTraHopDong_Load(object sender, EventArgs e)
        {
            dgvDanhBo.AutoGenerateColumns = false;
            Clear();
        }

        public void LoadEntity(KH_HopDong en)
        {
            txtID.Text = en.ID.ToString();
            txtDanhBo.Text = en.DanhBo;
        }

        public void Clear()
        {
            txtID.Text = "";
            txtDanhBo.Text = "";
            _en = null;

            dgvDanhBo.DataSource = _cTHD.getDS();

            txtDanhBo.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    if (_cDHN.CheckExist(txtDanhBo.Text.Trim().Replace(" ", "")) == false)
                    {
                        MessageBox.Show("Danh Bộ không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    KH_HopDong en = new KH_HopDong();
                    en.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                    if (_cTHD.them(en) == true)
                    {
                        MessageBox.Show("Thành công STT: " + en.ID, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
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
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {

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
                if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_en != null && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_cTHD.xoa(_en) == true)
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

        private void dgvDanhBo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(7," ").Insert(4," ");
            }
        }

        private void dgvDanhBo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhBo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhBo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _en = _cTHD.get(int.Parse(dgvDanhBo.CurrentRow.Cells["ID"].Value.ToString()));
                LoadEntity(_en);
            }
            catch (Exception)
            {
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Replace(" ", "").Length == 11)
                btnThem.PerformClick();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvDanhBo.DataSource = _cTHD.getDS(txtDanhBo.Text.Trim().Replace(" ", ""));
        }
    }
}

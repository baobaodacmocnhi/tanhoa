using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.CapNhat
{
    public partial class frmLoaiChungTu : Form
    {
        int selectedindex = -1;
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();

        public frmLoaiChungTu()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        public void Clear()
        {
            txtKyHieuLCT.Text = "";
            txtTenLCT.Text = "";
            txtThoiHan.Text = "";
            selectedindex = -1;
            dgvDSChungTu.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu();
        }

        private void frmCapNhatChungTu_Load(object sender, EventArgs e)
        {
            dgvDSChungTu.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtKyHieuLCT.Text.Trim() != "" && txtTenLCT.Text.Trim() != "")
            {
                LoaiChungTu loaichungtu = new LoaiChungTu();
                loaichungtu.KyHieuLCT = txtKyHieuLCT.Text.Trim();
                loaichungtu.TenLCT = txtTenLCT.Text.Trim();
                if (txtThoiHan.Text.Trim() != "")
                    loaichungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                else
                    loaichungtu.ThoiHan = null;

                _cLoaiChungTu.ThemLoaiChungTu(loaichungtu);
                Clear();
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedindex != -1)
            {
                if (txtKyHieuLCT.Text.Trim() != "" && txtTenLCT.Text.Trim() != "")
                {
                    LoaiChungTu loaichungtu = _cLoaiChungTu.getLoaiChungTubyID(int.Parse(dgvDSChungTu["MaLCT", selectedindex].Value.ToString()));
                    loaichungtu.KyHieuLCT = txtKyHieuLCT.Text.Trim();
                    loaichungtu.TenLCT = txtTenLCT.Text.Trim();
                    if (txtThoiHan.Text.Trim() != "")
                        loaichungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                    else
                        loaichungtu.ThoiHan = null;

                    _cLoaiChungTu.SuaLoaiChungTu(loaichungtu);
                    Clear();
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDSChungTu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedindex = e.RowIndex;
                txtKyHieuLCT.Text = dgvDSChungTu["KyHieuLCT", e.RowIndex].Value.ToString();
                txtTenLCT.Text = dgvDSChungTu["TenLCT", e.RowIndex].Value.ToString();
                txtThoiHan.Text = dgvDSChungTu["ThoiHan", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void dgvDSChungTu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSChungTu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtThoiHan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true; 
        }
    }
}

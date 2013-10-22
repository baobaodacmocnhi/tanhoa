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
    public partial class frmChungTu : Form
    {
        int selectedindex = -1;
        CChungTu _cCapNhatChungTu = new CChungTu();

        public frmChungTu()
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
            txtKyHieuCT.Text = "";
            txtTenCT.Text = "";
            txtThoiHan.Text = "";
            selectedindex = -1;
            dgvDSChungTu.DataSource = _cCapNhatChungTu.LoadDSChungTu().DataSource;
        }

        private void frmCapNhatChungTu_Load(object sender, EventArgs e)
        {
            dgvDSChungTu.DataSource = _cCapNhatChungTu.LoadDSChungTu().DataSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtKyHieuCT.Text.Trim() != "" && txtTenCT.Text.Trim() != "" && txtThoiHan.Text.Trim() != "")
            {
                ChungTu chungtu = new ChungTu();
                chungtu.KyHieuCT = txtKyHieuCT.Text.Trim();
                chungtu.TenCT = txtTenCT.Text.Trim();
                chungtu.ThoiHan = txtThoiHan.Text.Trim();

                _cCapNhatChungTu.ThemChungTu(chungtu);

                Clear();
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedindex != -1)
            {
                if (txtKyHieuCT.Text.Trim() != "" && txtTenCT.Text.Trim() != "" && txtThoiHan.Text.Trim() != "")
                {
                    ChungTu chungtu = _cCapNhatChungTu.getChungTubyID(int.Parse(dgvDSChungTu["MaCT", selectedindex].Value.ToString()));
                    chungtu.KyHieuCT = txtKyHieuCT.Text.Trim();
                    chungtu.TenCT = txtTenCT.Text.Trim();
                    chungtu.ThoiHan = txtThoiHan.Text.Trim();

                    _cCapNhatChungTu.SuaChungTu(chungtu);

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
                txtKyHieuCT.Text = dgvDSChungTu["KyHieuCT", e.RowIndex].Value.ToString();
                txtTenCT.Text = dgvDSChungTu["TenCT", e.RowIndex].Value.ToString();
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
    }
}

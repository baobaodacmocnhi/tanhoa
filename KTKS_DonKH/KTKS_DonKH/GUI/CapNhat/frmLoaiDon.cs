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
    public partial class frmLoaiDon : Form
    {
        int selectedindex = -1;
        CLoaiDon _cCapNhatLoaiDon = new CLoaiDon();

        public frmLoaiDon()
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
            txtKyHieuLD.Text = "";
            txtTenLD.Text = "";
            selectedindex = -1;
            dgvDSLoaiDon.DataSource = _cCapNhatLoaiDon.LoadDSLoaiDon();
        }

        private void frmCapNhatLoaiDon_Load(object sender, EventArgs e)
        {
            dgvDSLoaiDon.AutoGenerateColumns = false;
            dgvDSLoaiDon.DataSource = _cCapNhatLoaiDon.LoadDSLoaiDon();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtKyHieuLD.Text.Trim() != "" && txtTenLD.Text.Trim() != "")
            {
                LoaiDon loaidon = new LoaiDon();
                loaidon.KyHieuLD = txtKyHieuLD.Text.Trim();
                loaidon.TenLD = txtTenLD.Text.Trim();

                if (_cCapNhatLoaiDon.ThemLoaiDon(loaidon))
                    Clear();
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedindex != -1)
            {
                if (txtKyHieuLD.Text.Trim() != "" && txtTenLD.Text.Trim() != "")
                {
                    LoaiDon loaidon = _cCapNhatLoaiDon.getLoaiDonbyID(int.Parse(dgvDSLoaiDon["MaLD", selectedindex].Value.ToString()));
                    loaidon.KyHieuLD = txtKyHieuLD.Text.Trim();
                    loaidon.TenLD = txtTenLD.Text.Trim();

                    if (_cCapNhatLoaiDon.SuaLoaiDon(loaidon))
                        Clear();
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDSLoaiDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedindex = e.RowIndex;
                txtKyHieuLD.Text = dgvDSLoaiDon["KyHieuLD", e.RowIndex].Value.ToString();
                txtTenLD.Text = dgvDSLoaiDon["TenLD", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void dgvDSLoaiDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSLoaiDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }


    }
}

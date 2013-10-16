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
    public partial class frmCapNhatLoaiDon : Form
    {
        int selectedindex = -1;
        CCapNhatLoaiDon _cCapNhatLoaiDon = new CCapNhatLoaiDon();

        public frmCapNhatLoaiDon()
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
            dgvDSLoaiDon.DataSource = _cCapNhatLoaiDon.LoadDSLoaiDon().DataSource;
        }

        private void frmCapNhatLoaiDon_Load(object sender, EventArgs e)
        {
            dgvDSLoaiDon.DataSource = _cCapNhatLoaiDon.LoadDSLoaiDon().DataSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtKyHieuLD.Text.Trim() != "" && txtTenLD.Text.Trim() != "")
            {
                LoaiDon loaidon = new LoaiDon();
                loaidon.KyHieuLD = txtKyHieuLD.Text.Trim();
                loaidon.TenLD = txtTenLD.Text.Trim();

                _cCapNhatLoaiDon.ThemLoaiDon(loaidon);

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

                    _cCapNhatLoaiDon.SuaLoaiDon(loaidon);

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


    }
}

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
    public partial class frmChiNhanh : Form
    {
        CChiNhanh _cChiNhanh = new CChiNhanh();
        int selectedindex = -1;

        public frmChiNhanh()
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
            txtTenCN.Text = "";
            selectedindex = -1;
            dgvDSChiNhanh.DataSource = _cChiNhanh.LoadDSChiNhanh();
        }

        private void frmChiNhanh_Load(object sender, EventArgs e)
        {
            dgvDSChiNhanh.AutoGenerateColumns = false;
            dgvDSChiNhanh.DataSource = _cChiNhanh.LoadDSChiNhanh();
        }

        private void dgvDSChiNhanh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSChiNhanh.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSChiNhanh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedindex = e.RowIndex;
                txtTenCN.Text = dgvDSChiNhanh["TenCN", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenCN.Text.Trim() != "")
            {
                ChiNhanh chinhanh = new ChiNhanh();
                chinhanh.TenCN = txtTenCN.Text.Trim();

                _cChiNhanh.ThemChiNhanh(chinhanh);
                Clear();
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedindex != -1)
                if (txtTenCN.Text.Trim() != "")
                {
                    ChiNhanh chinhanh = _cChiNhanh.getChiNhanhbyID(int.Parse(dgvDSChiNhanh["MaCN", selectedindex].Value.ToString()));
                    chinhanh.TenCN = txtTenCN.Text.Trim();

                    _cChiNhanh.SuaChiNhanh(chinhanh);
                    Clear();
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

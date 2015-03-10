using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ThaoThuTraLoi;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.CapNhat
{
    public partial class frmVeViecTTTL : Form
    {
        CVeViecTTTL _cVeViecTTTL = new CVeViecTTTL();
        int selectedindex = -1;

        public frmVeViecTTTL()
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

        private void frmVeViecTTTL_Load(object sender, EventArgs e)
        {
            dgvDSVeViecTTTL.AutoGenerateColumns = false;
            dgvDSVeViecTTTL.DataSource = _cVeViecTTTL.LoadDS();
        }

        public void Clear()
        {
            txtVeViec.Text = "";
            txtNoiDung.Text = "";
            txtNoiNhan.Text = "";
            selectedindex = -1;
            dgvDSVeViecTTTL.DataSource = _cVeViecTTTL.LoadDS();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtVeViec.Text.Trim() != "" && txtNoiDung.Text.Trim() != "" && txtNoiNhan.Text.Trim() != "")
            {
                VeViecTTTL vv = new VeViecTTTL();
                vv.TenVV = txtVeViec.Text.Trim();
                vv.NoiDung = txtNoiDung.Text.Trim();
                vv.NoiNhan = txtNoiNhan.Text.Trim();

                if (_cVeViecTTTL.Them(vv))
                    Clear();
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedindex != -1)
                if (txtVeViec.Text.Trim() != "" && txtNoiDung.Text.Trim() != "" && txtNoiNhan.Text.Trim() != "")
                {
                    VeViecTTTL vv = _cVeViecTTTL.getVeViecTTTLbyID(int.Parse(dgvDSVeViecTTTL["MaVV", selectedindex].Value.ToString()));
                    vv.TenVV = txtVeViec.Text.Trim();
                    vv.NoiDung = txtNoiDung.Text.Trim();
                    vv.NoiNhan = txtNoiNhan.Text.Trim();

                    if (_cVeViecTTTL.Sua(vv))
                        Clear();
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvDSVeViecTTTL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedindex = e.RowIndex;
                txtVeViec.Text = dgvDSVeViecTTTL["TenVV", e.RowIndex].Value.ToString();
                txtNoiDung.Text = dgvDSVeViecTTTL["NoiDung", e.RowIndex].Value.ToString();
                txtNoiNhan.Text = dgvDSVeViecTTTL["NoiNhan", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }
    }
}

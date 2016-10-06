using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmVeViecCHDB : Form
    {
        CVeViecCHDB _cVeViecCHDB = new CVeViecCHDB();
        int selectedindex = -1;

        public frmVeViecCHDB()
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

        private void frmVeViecCHDB_Load(object sender, EventArgs e)
        {
            dgvDSVeViecTTTL.AutoGenerateColumns = false;
            dgvDSVeViecTTTL.DataSource = _cVeViecCHDB.LoadDS();
        }

        public void Clear()
        {
            txtVeViec.Text = "";
            txtNoiDung.Text = "";
            txtNoiNhan.Text = "";
            selectedindex = -1;
            dgvDSVeViecTTTL.DataSource = _cVeViecCHDB.LoadDS();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtVeViec.Text.Trim() != "" && txtNoiDung.Text.Trim() != "")
            {
                VeViecCHDB vv = new VeViecCHDB();
                vv.TenVV = txtVeViec.Text.Trim();
                vv.NoiDung = txtNoiDung.Text;
                vv.NoiNhan = txtNoiNhan.Text.Trim();

                if (_cVeViecCHDB.Them(vv))
                    Clear();
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedindex != -1)
                if (txtVeViec.Text.Trim() != "" && txtNoiDung.Text.Trim() != "")
                {
                    VeViecCHDB vv = _cVeViecCHDB.getVeViecCHDBbyID(int.Parse(dgvDSVeViecTTTL["MaVV", selectedindex].Value.ToString()));
                    vv.TenVV = txtVeViec.Text.Trim();
                    vv.NoiDung = txtNoiDung.Text;
                    vv.NoiNhan = txtNoiNhan.Text.Trim();

                    if (_cVeViecCHDB.Sua(vv))
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

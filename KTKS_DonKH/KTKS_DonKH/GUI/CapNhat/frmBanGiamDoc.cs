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
    public partial class frmBanGiamDoc : Form
    {
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        int selectedindex = -1;

        public frmBanGiamDoc()
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
            txtChucVu.Text = "";
            txtHoTen.Text = "";
            selectedindex = -1;
            dgvDSBanGiamDoc.DataSource = _cBanGiamDoc.LoadDSBanGiamDoc();
        }

        private void frmBanGiamDoc_Load(object sender, EventArgs e)
        {
            dgvDSBanGiamDoc.AutoGenerateColumns = false;
            dgvDSBanGiamDoc.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSBanGiamDoc.Font, FontStyle.Bold);
            dgvDSBanGiamDoc.DataSource = _cBanGiamDoc.LoadDSBanGiamDoc();
        }

        private void dgvDSBanGiamDoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSBanGiamDoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSBanGiamDoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedindex = e.RowIndex;
                txtChucVu.Text = dgvDSBanGiamDoc["ChucVu", e.RowIndex].Value.ToString();
                txtHoTen.Text = dgvDSBanGiamDoc["HoTen", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtChucVu.Text.Trim() != "" && txtHoTen.Text.Trim() != "")
            {
                BanGiamDoc bangiamdoc = new BanGiamDoc();
                bangiamdoc.ChucVu = txtChucVu.Text.Trim();
                bangiamdoc.HoTen = txtHoTen.Text.Trim();

                if (_cBanGiamDoc.ThemBanGiamDoc(bangiamdoc))
                    Clear();
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedindex != -1)
                if (txtChucVu.Text.Trim() != "" && txtHoTen.Text.Trim() != "")
                {
                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBanGiamDocbyID(int.Parse(dgvDSBanGiamDoc["MaBGD", selectedindex].Value.ToString()));
                    bangiamdoc.ChucVu = txtChucVu.Text.Trim();
                    bangiamdoc.HoTen = txtHoTen.Text.Trim();

                    if (_cBanGiamDoc.SuaBanGiamDoc(bangiamdoc))
                        Clear();
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvDSBanGiamDoc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBanGiamDocbyID(int.Parse(dgvDSBanGiamDoc["MaBGD", selectedindex].Value.ToString()));
            if (bool.Parse(dgvDSBanGiamDoc["KyTen", e.RowIndex].Value.ToString()) == true)
                bangiamdoc.KyTen = true;
            else
                bangiamdoc.KyTen = false;
            _cBanGiamDoc.SuaBanGiamDoc(bangiamdoc);
        }


    }
}

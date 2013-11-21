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
    public partial class frmGiaNuoc : Form
    {
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();
        int selectedindex = -1;

        public frmGiaNuoc()
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
            txtDoiTuong.Text = "";
            txtGiaNuoc.Text = "";
            selectedindex = -1;
            dgvDSGiaNuoc.DataSource = _cGiaNuoc.LoadDSGiaNuoc();
        }

        private void frmGiaNuoc_Load(object sender, EventArgs e)
        {
            dgvDSGiaNuoc.AutoGenerateColumns = false;
            dgvDSGiaNuoc.DataSource = _cGiaNuoc.LoadDSGiaNuoc();
        }

        private void dgvDSGiaNuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedindex = e.RowIndex;
                txtDoiTuong.Text = dgvDSGiaNuoc["TenGN", e.RowIndex].Value.ToString();
                txtGiaNuoc.Text = dgvDSGiaNuoc["DonGia", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
        
            }     
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtGiaNuoc.Text.Trim() != "" && txtGiaNuoc.Text.Trim() != "0")
            {
                GiaNuoc gianuoc = new GiaNuoc();
                gianuoc.TenGN = txtDoiTuong.Text.Trim();
                gianuoc.DonGia = int.Parse(txtGiaNuoc.Text.Trim());

                if (_cGiaNuoc.ThemGiaNuoc(gianuoc))
                    Clear();
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedindex != -1)
            {
                if (txtGiaNuoc.Text.Trim() != "" && txtGiaNuoc.Text.Trim() != "0")
                {
                    GiaNuoc gianuoc = _cGiaNuoc.getGiaNuocbyID(int.Parse(dgvDSGiaNuoc["MaGN", selectedindex].Value.ToString()));
                    gianuoc.DonGia = int.Parse(txtGiaNuoc.Text.Trim());

                    if (_cGiaNuoc.SuaGiaNuoc(gianuoc))
                        Clear();
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtGiaNuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true; 
        }

        private void dgvDSGiaNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSGiaNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSGiaNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSGiaNuoc.Columns[e.ColumnIndex].Name == "DonGia" && e.Value != null)
            {
                ///9.500
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
                ///5,500
                //e.Value = String.Format("{0:0,0}", e.Value);
                //e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-US"), "{0:#,##}", e.Value);
            }
        }

    }
}

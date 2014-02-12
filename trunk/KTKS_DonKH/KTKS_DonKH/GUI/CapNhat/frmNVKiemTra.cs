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
    public partial class frmNVKiemTra : Form
    {
        CNhanVien _cNhanVien = new CNhanVien();
        int selectedindex = -1;

        public frmNVKiemTra()
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
            txtHoTenNV.Text = "";
            selectedindex = -1;
            dgvDSNVKiemTra.DataSource = _cNhanVien.LoadDSNhanVien();
        }

        private void frmNVKiemTra_Load(object sender, EventArgs e)
        {
            dgvDSNVKiemTra.AutoGenerateColumns = false;
            dgvDSNVKiemTra.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSNVKiemTra.Font, FontStyle.Bold);
            dgvDSNVKiemTra.DataSource = _cNhanVien.LoadDSNhanVien();
        }

        private void dgvDSNVKiemTra_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSNVKiemTra.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSNVKiemTra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedindex = e.RowIndex;
                txtHoTenNV.Text = dgvDSNVKiemTra["HoTen", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTenNV.Text.Trim() != "")
            {
                NhanVien nhanvien = new NhanVien();
                nhanvien.HoTen = txtHoTenNV.Text.Trim();

                if (_cNhanVien.ThemNhanVien(nhanvien))
                    Clear();
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedindex != -1)
                if (txtHoTenNV.Text.Trim() != "")
                {
                    NhanVien nhanvien = _cNhanVien.getNhanVienbyID(int.Parse(dgvDSNVKiemTra["MaNV", selectedindex].Value.ToString()));
                    nhanvien.HoTen = txtHoTenNV.Text.Trim();

                    if (_cNhanVien.SuaNhanVien(nhanvien))
                        Clear();
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}

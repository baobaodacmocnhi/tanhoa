using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using System.Globalization;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.ChuyenKhoan;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmDuLieuKhachHang : Form
    {
        string _mnu = "mnuDuLieuKhachHang";
        CHoaDon _cHoaDon = new CHoaDon();
        CDuLieuKhachHang _cDLKH = new CDuLieuKhachHang();

        public frmDuLieuKhachHang()
        {
            InitializeComponent();
        }

        private void frmDuLieuKhachHang_Load(object sender, EventArgs e)
        {
            dgvHDDaThu.AutoGenerateColumns = false;
            dgvHDChuaThu.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
        }

        public void LoadDanhSachHD()
        {
            dgvHDDaThu.DataSource = _cDLKH.GetDSDangNgan(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
            dgvHDChuaThu.DataSource = _cDLKH.GetDSTon(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
            int TongCong = 0;
            if (dgvHDDaThu.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDDaThu.Rows)
                {
                    TongCong += int.Parse(item.Cells["TongCong_DT"].Value.ToString());
                }
                txtTongCong_DT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
            TongCong = 0;
            if (dgvHDChuaThu.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDChuaThu.Rows)
                {
                    TongCong += int.Parse(item.Cells["TongCong_CT"].Value.ToString());
                }
                txtTongCong_CT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbNam.SelectedIndex != -1 && cmbKy.SelectedIndex != -1)
            {
                LoadDanhSachHD();
            }
        }
    }
}

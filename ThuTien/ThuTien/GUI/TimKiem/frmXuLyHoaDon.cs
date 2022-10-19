using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.LinQ;

namespace ThuTien.GUI.TimKiem
{
    public partial class frmXuLyHoaDon : Form
    {
        int _MaHD = 0;
        CHoaDon _cHoaDon = new CHoaDon();

        public frmXuLyHoaDon(int MaHD)
        {
            _MaHD = MaHD;
            InitializeComponent();
        }

        private void frmDoiSoHoaDon_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            dgvDanhSach.DataSource = _cHoaDon.getDS_LichSuDangNgan(_MaHD);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            HOADON hoadon = _cHoaDon.Get(_MaHD);
            if (hoadon.SoHoaDonCu == null)
                hoadon.SoHoaDonCu = hoadon.SOHOADON;
            hoadon.SOHOADON = txtSoHoaDonMoi.Text.Trim().ToUpper();
            if (_cHoaDon.Sua(hoadon))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnResetThanhToan_Click(object sender, EventArgs e)
        {
            HOADON hoadon = _cHoaDon.Get(_MaHD);
            hoadon.SyncThanhToan = false;
            hoadon.SyncThanhToan_Ngay = null;
            if (_cHoaDon.Sua(hoadon))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnRestNopTien_Click(object sender, EventArgs e)
        {
            HOADON hoadon = _cHoaDon.Get(_MaHD);
            hoadon.SyncNopTien = false;
            hoadon.SyncNopTien_Ngay = null;
            if (_cHoaDon.Sua(hoadon))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            wrThuTien.wsThuTien wsThuTien = new wrThuTien.wsThuTien();
            string result = "";
            if (chkTruoc01072022.Checked)
                result = wsThuTien.syncThanhToan_01072022(_MaHD, true, 0);
            else
                result = wsThuTien.syncThanhToan(_MaHD, true, 0);
            string[] results = result.Split(';');
            if (bool.Parse(results[0]) == true)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnNopTien_Click(object sender, EventArgs e)
        {
            wrThuTien.wsThuTien wsThuTien = new wrThuTien.wsThuTien();
            string result = "";
            if (chkTruoc01072022.Checked)
                result = wsThuTien.syncNopTien_01072022(_MaHD);
            else
                result = wsThuTien.syncNopTien(_MaHD);
            string[] results = result.Split(';');
            if (bool.Parse(results[0]) == true)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}

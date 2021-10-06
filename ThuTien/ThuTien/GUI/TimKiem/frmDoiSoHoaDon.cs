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
    public partial class frmDoiSoHoaDon : Form
    {
        int _MaHD = 0;
        CHoaDon _cHoaDon = new CHoaDon();

        public frmDoiSoHoaDon(int MaHD)
        {
            _MaHD = MaHD;
            InitializeComponent();
        }

        private void frmDoiSoHoaDon_Load(object sender, EventArgs e)
        {
           
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
            wsThuTien.wsThuTien wsThuTien = new wsThuTien.wsThuTien();
            string result = wsThuTien.syncThanhToan(_MaHD, true, 0);
            string[] results = result.Split(';');
            if (bool.Parse(results[0]) == true)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnNopTien_Click(object sender, EventArgs e)
        {
            wsThuTien.wsThuTien wsThuTien = new wsThuTien.wsThuTien();
            string result = wsThuTien.syncNopTien(_MaHD);
            string[] results = result.Split(';');
            if (bool.Parse(results[0]) == true)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}

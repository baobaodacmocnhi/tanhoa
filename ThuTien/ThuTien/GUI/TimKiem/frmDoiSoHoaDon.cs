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
            this.Location = new Point(100, 100);
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
    }
}

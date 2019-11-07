using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DieuChinhBienDong;

namespace KTKS_DonKH.GUI
{
    public partial class frmTinhTienNuoc : Form
    {
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();

        public frmTinhTienNuoc()
        {
            InitializeComponent();
        }

        private void frmTinhTienNuoc_Load(object sender, EventArgs e)
        {
            //_cGiaNuoc.TinhTienNuoc_Tang_Ky122019("", 16, 44, 120);
        }

        private void btnTinhTienNuoc_Click(object sender, EventArgs e)
        {
            double TyLe = Math.Round(double.Parse(txtDinhMucHN.Text.Trim()) / (int.Parse(txtDinhMucHN.Text.Trim()) + int.Parse(txtDinhMucDC.Text.Trim())), 2);
            int TieuThuHN = 0, TieuThuDC = 0;
            TieuThuHN = (int)Math.Round(int.Parse(txtTieuThu.Text.Trim()) * TyLe, 0, MidpointRounding.AwayFromZero);
            TieuThuDC = int.Parse(txtTieuThu.Text.Trim()) - TieuThuHN;
            txtTieuThuHN.Text = TieuThuHN.ToString();
            txtTieuThuDC.Text = TieuThuDC.ToString();
            string ChiTietHN;
            int TienNuocHN = _cGiaNuoc.TinhTienNuoc(10, int.Parse(txtDinhMucHN.Text.Trim()), 0, TieuThuHN, out  ChiTietHN);
            txtThanhTienHN.Text = TienNuocHN.ToString();
            txtChiTietHN.Text = ChiTietHN;
            string ChiTietDC;
            int TienNuocDC = _cGiaNuoc.TinhTienNuoc(11, 0, int.Parse(txtDinhMucDC.Text.Trim()), TieuThuDC, out  ChiTietDC);
            txtThanhTienDC.Text = TienNuocDC.ToString();
            txtChiTietDC.Text = ChiTietDC;
            txtTongCong.Text = (TienNuocHN + TienNuocDC).ToString();
        }
    }
}

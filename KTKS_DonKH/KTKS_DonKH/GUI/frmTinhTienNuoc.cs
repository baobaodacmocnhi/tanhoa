using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI
{
    public partial class frmTinhTienNuoc : Form
    {
        CThuTien _cThuTien = new CThuTien();
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();
        HOADON _hoadon = null;

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
            int GiaBanCu = 0, GiaBanMoi = 0, ThueGTGT = 0, PhiBVMT = 0, TongCong = 0;
            string ChiTietCu,ChiTietMoi;
            _cGiaNuoc.TinhTienNuoc(txtDanhBo.Text.Trim(), int.Parse(txtKy.Text.Trim()), int.Parse(txtNam.Text.Trim()), dateTu.Value, dateDen.Value, int.Parse(txtGiaBieu.Text.Trim()), int.Parse(txtDinhMucHN.Text.Trim()), int.Parse(txtDinhMucDC.Text.Trim()), int.Parse(txtTieuThu.Text.Trim()), out GiaBanCu, out ChiTietCu, out GiaBanMoi, out ChiTietMoi);
            ThueGTGT = (GiaBanCu + GiaBanMoi) * 5 / 100;
            PhiBVMT = (GiaBanCu + GiaBanMoi) * 10 / 100;
            TongCong = (GiaBanCu + GiaBanMoi) + ThueGTGT + PhiBVMT;
            txtGiaBanCu.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaBanCu);
            txtGiaBanMoi.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaBanMoi);
            txtGiaBan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaBanCu + GiaBanMoi));
            txtThueGTGT.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ThueGTGT);
            txtPhiBVMT.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", PhiBVMT);
            txtTongCong.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            txtChiTietCu.Text = ChiTietCu;
            txtChiTietMoi.Text = ChiTietMoi;
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                _hoadon = _cThuTien.Get(txtDanhBo.Text.Trim(), int.Parse(txtKy.Text.Trim()), int.Parse(txtNam.Text.Trim()));
                if (_hoadon != null)
                {
                    dateTu.Value = _hoadon.TUNGAY.Value;
                    dateDen.Value = _hoadon.DENNGAY.Value;
                    txtGiaBieu.Text = _hoadon.GB.Value.ToString();
                    txtDinhMucHN.Text = _hoadon.DinhMucHN.Value.ToString();
                    txtDinhMucDC.Text = _hoadon.DM.Value.ToString();
                    txtTieuThu.Text = _hoadon.TIEUTHU.Value.ToString();
                }
            }
        }
    }
}

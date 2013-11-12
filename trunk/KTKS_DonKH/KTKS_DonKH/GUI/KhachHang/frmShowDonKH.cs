using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.CapNhat;

namespace KTKS_DonKH.GUI.KhachHang
{
    public partial class frmShowDonKH : Form
    {
        CLoaiDon _cLoaiDon = new CLoaiDon();
        DonKH _donkh = new DonKH();

        public frmShowDonKH()
        {
            InitializeComponent();
        }

        public frmShowDonKH(DonKH donkh)
        {
            _donkh = donkh;
            InitializeComponent();
        }

        private void frmShowDonKH_Load(object sender, EventArgs e)
        {
            cmbLD.DataSource = _cLoaiDon.LoadDSLoaiDon(true);
            cmbLD.DisplayMember = "TenLD";
            cmbLD.ValueMember = "MaLD";

            cmbLD.SelectedValue = _donkh.MaLD.Value;
            txtSoCongVan.Text = _donkh.SoCongVan;
            txtMaDon.Text = _donkh.MaDon.ToString();
            txtNgayNhan.Text = _donkh.CreateDate.Value.ToString("dd/MM/yyyy");
            txtNoiDung.Text = _donkh.NoiDung;

            if (_donkh.KiemTraDHN.Value)
                chkKiemTraDHN.Checked = true;
            if (_donkh.TienNuoc.Value)
                chkTienNuoc.Checked = true;
            if (_donkh.ChiSoNuoc.Value)
                chkChiSoNuoc.Checked = true;
            if (_donkh.DonGiaNuoc.Value)
                chkDonGiaNuoc.Checked = true;
            if (_donkh.SangTen.Value)
                chkSangTen.Checked = true;
            if (_donkh.DangKyDM.Value)
                chkDangKyDM.Checked = true;
            if (_donkh.CatChuyenDM.Value)
                chkCatChuyenDM.Checked = true;
            if (_donkh.NuocDuc.Value)
                chkNuocDuc.Checked = true;
            if (_donkh.LoaiKhac.Value)
                chkLyDoKhac.Checked = true;

            txtLyDoKhac.Text = _donkh.LyDoLoaiKhac;
            txtDanhBo.Text = _donkh.DanhBo;
            txtHopDong.Text = _donkh.HopDong;
            txtDienThoai.Text = _donkh.DienThoai;
            txtKhachHang.Text = _donkh.HoTen;
            txtDiaChi.Text = _donkh.DiaChi;
            txtMSThue.Text = _donkh.MSThue;
            txtGiaBieu.Text = _donkh.GiaBieu;
            txtDinhMuc.Text = _donkh.DinhMuc;
            txtGhiChu.Text = _donkh.GhiChu;

            if (_donkh.CT_HoaDon.Value)
                chkCT_HoaDon.Checked = true;
            if (_donkh.CT_HK_KT3.Value)
                chkCT_HK_KT3.Checked = true;
            if (_donkh.CT_STT_GXNTT.Value)
                chkCT_STT_GXNTT.Checked = true;
            if (_donkh.CT_HDTN_CQN.Value)
                chkCT_HDTN_CQN.Checked = true;
            if (_donkh.CT_GC_SDSN.Value)
                chkCT_GC_SDSN.Checked = true;
            if (_donkh.CT_GXN2SN.Value)
                chkCT_GXN2SN.Checked = true;
            if (_donkh.CT_GDKKD.Value)
                chkCT_GDKKD.Checked = true;
            if (_donkh.CT_GCNDTDHN.Value)
                chkCT_GCNDTDHN.Checked = true;

            txtDinhMucSau.Text = _donkh.DinhMucSau;
            txtHieuLucTuKy.Text = _donkh.HieuLucTuKy;

            btnInBienNhan.Enabled = false;
        }
    }
}

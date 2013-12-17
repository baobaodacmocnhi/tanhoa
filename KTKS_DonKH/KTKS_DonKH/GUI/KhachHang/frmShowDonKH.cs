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
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.DAL.HeThong;
using KTKS_DonKH.BaoCao.KhachHang;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.KhachHang
{
    public partial class frmShowDonKH : Form
    {
        CLoaiDon _cLoaiDon = new CLoaiDon();
        DonKH _donkh = null;

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
            txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
            txtNgayNhan.Text = _donkh.CreateDate.Value.ToString("dd/MM/yyyy");
            txtNoiDung.Text = _donkh.NoiDung;

            if (_donkh.KiemTraDHN)
                chkKiemTraDHN.Checked = true;
            if (_donkh.TienNuoc)
                chkTienNuoc.Checked = true;
            if (_donkh.ChiSoNuoc)
                chkChiSoNuoc.Checked = true;
            if (_donkh.DonGiaNuoc)
                chkDonGiaNuoc.Checked = true;
            if (_donkh.SangTen)
                chkSangTen.Checked = true;
            if (_donkh.DangKyDM)
                chkDangKyDM.Checked = true;
            if (_donkh.CatChuyenDM)
                chkCatChuyenDM.Checked = true;
            if (_donkh.NuocDuc)
                chkNuocDuc.Checked = true;
            if (_donkh.LoaiKhac)
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

            if (_donkh.CT_HoaDon)
                chkCT_HoaDon.Checked = true;
            if (_donkh.CT_HK_KT3)
                chkCT_HK_KT3.Checked = true;
            if (_donkh.CT_STT_GXNTT)
                chkCT_STT_GXNTT.Checked = true;
            if (_donkh.CT_HDTN_CQN)
                chkCT_HDTN_CQN.Checked = true;
            if (_donkh.CT_GC_SDSN)
                chkCT_GC_SDSN.Checked = true;
            if (_donkh.CT_GXN2SN)
                chkCT_GXN2SN.Checked = true;
            if (_donkh.CT_GDKKD)
                chkCT_GDKKD.Checked = true;
            if (_donkh.CT_GCNDTDHN)
                chkCT_GCNDTDHN.Checked = true;

            txtDinhMucSau.Text = _donkh.DinhMucSau;
            txtHieuLucTuKy.Text = _donkh.HieuLucTuKy;
        }

        private void btnInBienNhan_Click(object sender, EventArgs e)
        {
            if (_donkh != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                dr["MaDon"] = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                dr["TenLD"] = _donkh.LoaiDon.TenLD;
                dr["KhachHang"] = _donkh.HoTen;
                if (_donkh.DanhBo != "")
                    dr["DanhBo"] = _donkh.DanhBo.Insert(4, ".").Insert(8, ".");
                dr["DiaChi"] = _donkh.DiaChi;
                dr["HopDong"] = _donkh.HopDong;
                dr["DienThoai"] = _donkh.DienThoai;

                #region CheckBox
                if (_donkh.KiemTraDHN)
                {
                    dr["KiemTraDHN"] = true;
                }
                else
                {
                    dr["KiemTraDHN"] = false;
                }

                if (_donkh.TienNuoc)
                {
                    dr["TienNuoc"] = true;
                }
                else
                {
                    dr["TienNuoc"] = false;
                }

                if (_donkh.ChiSoNuoc)
                {
                    dr["ChiSoNuoc"] = true;
                }
                else
                {
                    dr["ChiSoNuoc"] = false;
                }

                if (_donkh.DonGiaNuoc)
                {
                    dr["DonGiaNuoc"] = true;
                }
                else
                {
                    dr["DonGiaNuoc"] = false;
                }

                if (_donkh.SangTen)
                {
                    dr["SangTen"] = true;
                }
                else
                {
                    dr["SangTen"] = false;
                }

                if (_donkh.DangKyDM)
                {
                    dr["DangKyDM"] = true;
                }
                else
                {
                    dr["DangKyDM"] = false;
                }

                if (_donkh.CatChuyenDM)
                {
                    dr["CatChuyenDM"] = true;
                }
                else
                {
                    dr["CatChuyenDM"] = false;
                }

                if (_donkh.NuocDuc)
                {
                    dr["NuocDuc"] = true;
                }
                else
                {
                    dr["NuocDuc"] = false;
                }

                if (_donkh.LoaiKhac)
                {
                    dr["LoaiKhac"] = true;
                    dr["LyDoLoaiKhac"] = _donkh.LyDoLoaiKhac;
                }
                else
                {
                    dr["LoaiKhac"] = false;
                }

                if (_donkh.CT_HoaDon)
                {
                    dr["CT_HoaDon"] = true;
                }
                else
                {
                    dr["CT_HoaDon"] = false;
                }

                if (_donkh.CT_HK_KT3)
                {
                    dr["CT_HK_KT3"] = true;
                }
                else
                {
                    dr["CT_HK_KT3"] = false;
                }

                if (_donkh.CT_STT_GXNTT)
                {
                    dr["CT_STT_GXNTT"] = true;
                }
                else
                {
                    dr["CT_STT_GXNTT"] = false;
                }

                if (_donkh.CT_HDTN_CQN)
                {
                    dr["CT_HDTN_CQN"] = true;
                }
                else
                {
                    dr["CT_HDTN_CQN"] = false;
                }

                if (_donkh.CT_GC_SDSN)
                {
                    dr["CT_GC_SDSN"] = true;
                }
                else
                {
                    dr["CT_GC_SDSN"] = false;
                }

                if (_donkh.CT_GXN2SN)
                {
                    dr["CT_GXN2SN"] = true;
                }
                else
                {
                    dr["CT_GXN2SN"] = false;
                }

                if (_donkh.CT_GDKKD)
                {
                    dr["CT_GDKKD"] = true;
                }
                else
                {
                    dr["CT_GDKKD"] = false;
                }

                if (_donkh.CT_GCNDTDHN)
                {
                    dr["CT_GCNDTDHN"] = true;
                }
                else
                {
                    dr["CT_GCNDTDHN"] = false;
                }
                #endregion

                dr["DinhMucSau"] = _donkh.DinhMucSau;
                dr["HieuLucTuKy"] = _donkh.HieuLucTuKy;
                CTaiKhoan _cTaiKhoan = new CTaiKhoan();
                dr["HoTenNV"] = _cTaiKhoan.getHoTenUserbyTaiKhoan(_donkh.CreateBy);
                
                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(dr);
                rptBienNhanDonKH rpt = new rptBienNhanDonKH();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
        }
    }
}

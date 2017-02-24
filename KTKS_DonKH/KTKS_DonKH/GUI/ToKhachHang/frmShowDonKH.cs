﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ToKhachHang;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.ToKhachHang
{
    public partial class frmShowDonKH : Form
    {
        CLoaiDon _cLoaiDon = new CLoaiDon();
        DonKH _donkh = null;
        Dictionary<string, string> _source = new Dictionary<string, string>();
        CDonKH _cDonKH = new CDonKH();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();
        CDonTXL _cDonTXL = new CDonTXL();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CLichSuDonTu _cLichSuDonTu = new CLichSuDonTu();
        string Dot = "", Ky = "", Nam = "";

        public frmShowDonKH()
        {
            InitializeComponent();
        }

        public frmShowDonKH(Dictionary<string, string> source)
        {
            _source = source;
            InitializeComponent();  
        }

        private void frmShowDonKH_Load(object sender, EventArgs e)
        {
            if (_cDonKH.getDonKHbyID(decimal.Parse(_source["MaDon"])) != null)
            {
                this.Location = new Point(-20, 70);
                _donkh = _cDonKH.getDonKHbyID(decimal.Parse(_source["MaDon"]));
                cmbLD.DataSource = _cLoaiDon.LoadDSLoaiDon();
                cmbLD.DisplayMember = "TenLD";
                cmbLD.ValueMember = "MaLD";

                cmbNguoiDi.DataSource = _cTaiKhoan.LoadDSTaiKhoanTKH();
                cmbNguoiDi.DisplayMember = "HoTen";
                cmbNguoiDi.ValueMember = "MaU";
                cmbNguoiDi.SelectedIndex = -1;

                cmbLD.SelectedValue = _donkh.MaLD.Value;
                txtSoCongVan.Text = _donkh.SoCongVan;
                if (_donkh.MaDon.ToString().Length > 2)
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
                    chkThayDoiGiaNuoc.Checked = true;
                if (_donkh.SangTen)
                    chkThayDoiTenHopDong.Checked = true;
                if (_donkh.DangKyDM)
                    chkCapDM.Checked = true;
                if (_donkh.CatChuyenDM)
                    chkCatChuyenDM.Checked = true;
                if (_donkh.GiamDM)
                    chkGiamDM.Checked = true;
                if (_donkh.DCSoNha)
                    chkDieuChinhSoNha.Checked = true;
                if (_donkh.MatDHN)
                    chkMatDHN.Checked = true;
                if (_donkh.HuHongDHN)
                    chkHuHongDHN.Checked = true;
                if (_donkh.ChiNiem)
                    chkChiNiem.Checked = true;
                if (_donkh.ThayDoiMST)
                    chkThayDoiMST.Checked = true;
                if (_donkh.TamNgung)
                    chkTamNgung.Checked = true;
                if (_donkh.HuyHopDong)
                    chkHuyHopDong.Checked = true;
                if (_donkh.LoaiKhac)
                    chkLyDoKhac.Checked = true;

                txtLyDoKhac.Text = _donkh.LyDoLoaiKhac;
                txtDanhBo.Text = _donkh.DanhBo;
                txtHopDong.Text = _donkh.HopDong;
                txtDienThoai.Text = _donkh.DienThoai;
                txtHoTen.Text = _donkh.HoTen;
                txtDiaChi.Text = _donkh.DiaChi;
                txtGiaBieu.Text = _donkh.GiaBieu;
                txtDinhMuc.Text = _donkh.DinhMuc;
                //cmbNVKiemTra.Text = _donkh.GhiChuNguoiDi;

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
                ///
                dgvLichSuChuyenKT.DataSource = _cDonTXL.LoadDSLichSuChuyenKTbyMaDonTKH(_donkh.MaDon);
                ///
                if (_donkh.ChuyenKT)
                {
                    chkChuyenKT.Checked = true;
                    dateChuyenKT.Value = _donkh.NgayChuyenKT.Value;
                    cmbNguoiDi.SelectedValue = _donkh.NguoiDi;
                    txtGhiChuChuyenKT.Text = _donkh.GhiChuChuyenKT;
                }
                if (_donkh.ChuyenBanDoiKhac)
                {
                    chkChuyenBanDoiKhac.Checked = true;
                    dateChuyenBanDoiKhac.Value = _donkh.NgayChuyenBanDoiKhac.Value;
                    txtGhiChuChuyenBanDoiKhac.Text = _donkh.GhiChuChuyenBanDoiKhac;
                }
                if (_donkh.ChuyenToXuLy)
                {
                    chkChuyenToXuLy.Checked = true;
                    dateChuyenToXuLy.Value = _donkh.NgayChuyenToXuLy.Value;
                    txtGhiChuChuyenToXuLy.Text = _donkh.GhiChuChuyenToXuLy;
                }
                if (_donkh.ChuyenKhac)
                {
                    chkChuyenKhac.Checked = true;
                    dateChuyenKhac.Value = _donkh.NgayChuyenKhac.Value;
                    txtGhiChuChuyenKhac.Text = _donkh.GhiChuChuyenKhac;
                }

                if (_source["Action"] == "Cập Nhật")
                {
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }

                if (_source["Action"].ToString() == "Tìm Kiếm")
                {
                    btnInBienNhan.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }
            }

        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                HOADON hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                if (hoadon != null)
                {
                    txtHopDong.Text = hoadon.HOPDONG;
                    txtHoTen.Text = hoadon.TENKH;
                    txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.getPhuongQuanByID(hoadon.Quan, hoadon.Phuong);
                    txtGiaBieu.Text = hoadon.GB.ToString();
                    txtDinhMuc.Text = hoadon.DM.ToString();
                    Dot = hoadon.DOT.ToString();
                    Ky = hoadon.KY.ToString();
                    Nam = hoadon.NAM.ToString();
                }
                else
                {
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDanhBo.Text = "";
                    txtHopDong.Text = "";
                    txtDienThoai.Text = "";
                    txtHoTen.Text = "";
                    txtDiaChi.Text = "";
                    txtGiaBieu.Text = "";
                    txtDinhMuc.Text = "";
                    Dot = Ky = Nam = "";
                }
            }
        }

        private void chkLyDoKhac_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnInBienNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (_donkh != null)
                {
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    DataRow dr = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                    //dr["MaDon"] = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-") + "/" + _cLoaiDon.getKyHieuLDubyID(int.Parse(cmbLD.SelectedValue.ToString()));
                    dr["MaDon"] = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                    //dr["MaXepDon"] = _cLoaiDon.getKyHieuLDubyID(int.Parse(cmbLD.SelectedValue.ToString()));
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
                        dr["Ngay"] = "5";
                    }
                    else
                    {
                        dr["KiemTraDHN"] = false;
                    }

                    if (_donkh.TienNuoc)
                    {
                        dr["TienNuoc"] = true;
                        dr["Ngay"] = "5";
                    }
                    else
                    {
                        dr["TienNuoc"] = false;
                    }

                    if (_donkh.ChiSoNuoc)
                    {
                        dr["ChiSoNuoc"] = true;
                        dr["Ngay"] = "5";
                    }
                    else
                    {
                        dr["ChiSoNuoc"] = false;
                    }

                    if (_donkh.DonGiaNuoc)
                    {
                        dr["DonGiaNuoc"] = true;
                        dr["Ngay"] = "5";
                    }
                    else
                    {
                        dr["DonGiaNuoc"] = false;
                    }

                    if (_donkh.DangKyDM)
                    {
                        dr["DangKyDM"] = true;
                        dr["Ngay"] = "5";
                    }
                    else
                    {
                        dr["DangKyDM"] = false;
                    }

                    if (_donkh.CatChuyenDM)
                    {
                        dr["CatChuyenDM"] = true;
                        dr["Ngay"] = "5";
                    }
                    else
                    {
                        dr["CatChuyenDM"] = false;
                    }

                    if (_donkh.GiamDM)
                    {
                        dr["GiamDM"] = true;
                        dr["Ngay"] = "5";
                    }
                    else
                    {
                        dr["GiamDM"] = false;
                    }

                    if (_donkh.DCSoNha)
                    {
                        dr["DCSoNha"] = true;
                        dr["Ngay"] = "5";
                    }
                    else
                    {
                        dr["DCSoNha"] = false;
                    }

                    if (_donkh.MatDHN)
                    {
                        dr["MatDHN"] = true;
                        dr["Ngay"] = "5";
                    }
                    else
                    {
                        dr["MatDHN"] = false;
                    }

                    if (_donkh.HuHongDHN)
                    {
                        dr["HuHongDHN"] = true;
                        dr["Ngay"] = "5";
                    }
                    else
                    {
                        dr["HuHongDHN"] = false;
                    }

                    if (_donkh.ChiNiem)
                    {
                        dr["ChiNiem"] = true;
                        dr["Ngay"] = "5";
                    }
                    else
                    {
                        dr["ChiNiem"] = false;
                    }

                    if (_donkh.ThayDoiMST)
                    {
                        dr["ThayDoiMST"] = true;
                        dr["Ngay"] = "5";
                    }
                    else
                    {
                        dr["ThayDoiMST"] = false;
                    }

                    if (_donkh.TamNgung)
                    {
                        dr["TamNgung"] = true;
                        dr["Ngay"] = "5";
                    }
                    else
                    {
                        dr["TamNgung"] = false;
                    }

                    if (_donkh.HuyHopDong)
                    {
                        dr["HuyHopDong"] = true;
                        dr["Ngay"] = "5";
                    }
                    else
                    {
                        dr["HuyHopDong"] = false;
                    }

                    if (_donkh.MoNuoc)
                    {
                        dr["MoNuoc"] = true;
                        dr["Ngay"] = "5";
                    }
                    else
                    {
                        dr["MoNuoc"] = false;
                    }

                    if (_donkh.LoaiKhac)
                    {
                        dr["LoaiKhac"] = true;
                        dr["LyDoLoaiKhac"] = _donkh.LyDoLoaiKhac;
                        dr["Ngay"] = "5";
                    }
                    else
                    {
                        dr["LoaiKhac"] = false;
                    }

                    if (_donkh.SangTen)
                    {
                        dr["SangTen"] = true;
                        dr["Ngay"] = "30";
                    }
                    else
                    {
                        dr["SangTen"] = false;
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
                    dr["HoTenNV"] = _cTaiKhoan.getHoTenUserbyID(_donkh.CreateBy.Value);

                    dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(dr);
                    rptBienNhanDonKH rpt = new rptBienNhanDonKH();
                    rpt.SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_donkh != null)
            {
                _donkh.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                _donkh.SoCongVan = txtSoCongVan.Text.Trim();
                if (_donkh.DanhBo != txtDanhBo.Text.Trim())
                {
                    _donkh.Dot = Dot;
                    _donkh.Ky = Ky;
                    _donkh.Nam = Nam;
                }
                _donkh.DanhBo = txtDanhBo.Text.Trim();
                _donkh.HopDong = txtHopDong.Text.Trim();
                _donkh.HoTen = txtHoTen.Text.Trim();
                _donkh.DiaChi = txtDiaChi.Text.Trim();
                _donkh.DienThoai = txtDienThoai.Text.Trim();
                _donkh.GiaBieu = txtGiaBieu.Text.Trim();
                _donkh.DinhMuc = txtDinhMuc.Text.Trim();
                //donkh.SH = SH;
                //donkh.SX = SX;
                //donkh.DV = DV;
                //donkh.HCSN = HCSN;
                
                _donkh.NoiDung = txtNoiDung.Text.Trim();
                //_donkh.GhiChuNguoiDi = cmbNVKiemTra.SelectedValue.ToString();
                _donkh.DinhMucSau = txtDinhMucSau.Text.Trim();
                _donkh.HieuLucTuKy = txtHieuLucTuKy.Text.Trim();

                #region CheckBox
                if (chkKiemTraDHN.Checked)
                    _donkh.KiemTraDHN = true;
                else
                    _donkh.KiemTraDHN = false;

                if (chkTienNuoc.Checked)
                    _donkh.TienNuoc = true;
                else
                    _donkh.TienNuoc = false;

                if (chkChiSoNuoc.Checked)
                    _donkh.ChiSoNuoc = true;
                else
                    _donkh.ChiSoNuoc = false;

                if (chkThayDoiGiaNuoc.Checked)
                    _donkh.DonGiaNuoc = true;
                else
                    _donkh.DonGiaNuoc = false;

                if (chkThayDoiTenHopDong.Checked)
                    _donkh.SangTen = true;
                else
                    _donkh.SangTen = false;

                if (chkCapDM.Checked)
                    _donkh.DangKyDM = true;
                else
                    _donkh.DangKyDM = false;

                if (chkCatChuyenDM.Checked)
                    _donkh.CatChuyenDM = true;
                else
                    _donkh.CatChuyenDM = false;

                if (chkGiamDM.Checked)
                    _donkh.GiamDM = true;
                else
                    _donkh.GiamDM = false;

                if (chkDieuChinhSoNha.Checked)
                    _donkh.DCSoNha = true;
                else
                    _donkh.DCSoNha = false;

                if (chkMatDHN.Checked)
                    _donkh.MatDHN = true;
                else
                    _donkh.MatDHN = false;

                if (chkHuHongDHN.Checked)
                    _donkh.HuHongDHN = true;
                else
                    _donkh.HuHongDHN = false;

                if (chkChiNiem.Checked)
                    _donkh.ChiNiem = true;
                else
                    _donkh.ChiNiem = false;

                if (chkThayDoiMST.Checked)
                    _donkh.ThayDoiMST = true;
                else
                    _donkh.ThayDoiMST = false;

                if (chkTamNgung.Checked)
                    _donkh.TamNgung = true;
                else
                    _donkh.TamNgung = false;

                if (chkHuyHopDong.Checked)
                    _donkh.HuyHopDong = true;
                else
                    _donkh.HuyHopDong = false;

                if (chkMoNuoc.Checked)
                    _donkh.MoNuoc = true;
                else
                    _donkh.MoNuoc = false;

                if (chkLyDoKhac.Checked)
                {
                    _donkh.LoaiKhac = true;
                    _donkh.LyDoLoaiKhac = txtLyDoKhac.Text.Trim();
                }
                else
                {
                    _donkh.LoaiKhac = false;
                    _donkh.LyDoLoaiKhac = null;
                }

                if (chkCT_HoaDon.Checked)
                    _donkh.CT_HoaDon = true;
                else
                    _donkh.CT_HoaDon = false;

                if (chkCT_HK_KT3.Checked)
                    _donkh.CT_HK_KT3 = true;
                else
                    _donkh.CT_HK_KT3 = false;

                if (chkCT_STT_GXNTT.Checked)
                    _donkh.CT_STT_GXNTT = true;
                else
                    _donkh.CT_STT_GXNTT = false;

                if (chkCT_HDTN_CQN.Checked)
                    _donkh.CT_HDTN_CQN = true;
                else
                    _donkh.CT_HDTN_CQN = false;

                if (chkCT_GC_SDSN.Checked)
                    _donkh.CT_GC_SDSN = true;
                else
                    _donkh.CT_GC_SDSN = false;

                if (chkCT_GXN2SN.Checked)
                    _donkh.CT_GXN2SN = true;
                else
                    _donkh.CT_GXN2SN = false;

                if (chkCT_GDKKD.Checked)
                    _donkh.CT_GDKKD = true;
                else
                    _donkh.CT_GDKKD = false;

                if (chkCT_GCNDTDHN.Checked)
                    _donkh.CT_GCNDTDHN = true;
                else
                    _donkh.CT_GCNDTDHN = false;

                #endregion

                bool flagSuaChuyenKT = false;
                if (chkChuyenKT.Checked)
                {
                    _donkh.ChuyenKT = true;
                    if (_donkh.NgayChuyenKT != dateChuyenKT.Value || _donkh.NguoiDi != int.Parse(cmbNguoiDi.SelectedValue.ToString()) || _donkh.GhiChuChuyenKT != txtGhiChuChuyenKT.Text.Trim())
                        flagSuaChuyenKT = true;
                    _donkh.NgayChuyenKT = dateChuyenKT.Value;
                    if (cmbNguoiDi.SelectedIndex != -1)
                        _donkh.NguoiDi = int.Parse(cmbNguoiDi.SelectedValue.ToString());
                    _donkh.GhiChuChuyenKT = txtGhiChuChuyenKT.Text.Trim();
                }
                else
                {
                    _donkh.ChuyenKT = false;
                    _donkh.NgayChuyenKT = null;
                    _donkh.NguoiDi = null;
                    _donkh.GhiChuChuyenKT = null;
                }

                if (chkChuyenBanDoiKhac.Checked)
                {
                    _donkh.ChuyenBanDoiKhac = true;
                    _donkh.NgayChuyenBanDoiKhac = dateChuyenBanDoiKhac.Value;
                    _donkh.GhiChuChuyenBanDoiKhac = txtGhiChuChuyenBanDoiKhac.Text.Trim();
                }
                else
                {
                    _donkh.ChuyenBanDoiKhac = false;
                    _donkh.NgayChuyenBanDoiKhac = null;
                    _donkh.GhiChuChuyenBanDoiKhac = null;
                }

                if (chkChuyenToXuLy.Checked)
                {
                    _donkh.ChuyenToXuLy = true;
                    _donkh.NgayChuyenToXuLy = dateChuyenToXuLy.Value;
                    _donkh.GhiChuChuyenToXuLy = txtGhiChuChuyenToXuLy.Text.Trim();
                }
                else
                {
                    _donkh.ChuyenToXuLy = false;
                    _donkh.NgayChuyenToXuLy = null;
                    _donkh.GhiChuChuyenToXuLy = null;
                }

                if (chkChuyenKhac.Checked)
                {
                    _donkh.ChuyenKhac = true;
                    _donkh.NgayChuyenKhac = dateChuyenKhac.Value;
                    _donkh.GhiChuChuyenKhac = txtGhiChuChuyenKhac.Text.Trim();
                }
                else
                {
                    _donkh.ChuyenKhac = false;
                    _donkh.NgayChuyenKhac = null;
                    _donkh.GhiChuChuyenKhac = null;
                }

                if (_cDonKH.SuaDonKH(_donkh))
                {
                    if (flagSuaChuyenKT)
                    {
                        LichSuChuyenKT lichsuchuyenkt = new LichSuChuyenKT();
                        lichsuchuyenkt.NgayChuyen = _donkh.NgayChuyenKT;
                        lichsuchuyenkt.NguoiDi = _donkh.NguoiDi;
                        lichsuchuyenkt.GhiChuChuyen = _donkh.GhiChuChuyenKT;
                        lichsuchuyenkt.MaDon = _donkh.MaDon;
                        _cLichSuDonTu.Them(lichsuchuyenkt);
                        flagSuaChuyenKT = false;
                    }
                    MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                #region if SuaDonKH
                //if (_cDonKH.SuaDonKH(_donkh))
                //{
                //    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                //    DataRow dr = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                //    dr["MaDon"] = txtMaDon.Text.Trim();
                //    dr["TenLD"] = cmbLD.Text;
                //    dr["KhachHang"] = txtKhachHang.Text.Trim();
                //    if (txtDanhBo.Text.Trim() != "")
                //        dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, ".").Insert(4, ".");
                //    dr["DiaChi"] = txtDiaChi.Text.Trim();
                //    dr["HopDong"] = txtHopDong.Text.Trim();
                //    dr["DienThoai"] = txtDienThoai.Text.Trim();

                //    #region CheckBox
                //    if (_donkh.KiemTraDHN)
                //    {
                //        dr["KiemTraDHN"] = true;
                //    }
                //    else
                //    {
                //        dr["KiemTraDHN"] = false;
                //    }

                //    if (_donkh.TienNuoc)
                //    {
                //        dr["TienNuoc"] = true;
                //    }
                //    else
                //    {
                //        dr["TienNuoc"] = false;
                //    }

                //    if (_donkh.ChiSoNuoc)
                //    {
                //        dr["ChiSoNuoc"] = true;
                //    }
                //    else
                //    {
                //        dr["ChiSoNuoc"] = false;
                //    }

                //    if (_donkh.DonGiaNuoc)
                //    {
                //        dr["DonGiaNuoc"] = true;
                //    }
                //    else
                //    {
                //        dr["DonGiaNuoc"] = false;
                //    }

                //    if (_donkh.SangTen)
                //    {
                //        dr["SangTen"] = true;
                //    }
                //    else
                //    {
                //        dr["SangTen"] = false;
                //    }

                //    if (_donkh.DangKyDM)
                //    {
                //        dr["DangKyDM"] = true;
                //    }
                //    else
                //    {
                //        dr["DangKyDM"] = false;
                //    }

                //    if (_donkh.CatChuyenDM)
                //    {
                //        dr["CatChuyenDM"] = true;
                //    }
                //    else
                //    {
                //        dr["CatChuyenDM"] = false;
                //    }

                //    if (_donkh.NuocDuc)
                //    {
                //        dr["NuocDuc"] = true;
                //    }
                //    else
                //    {
                //        dr["NuocDuc"] = false;
                //    }

                //    if (_donkh.LoaiKhac)
                //    {
                //        dr["LoaiKhac"] = true;
                //        dr["LyDoLoaiKhac"] = _donkh.LyDoLoaiKhac;
                //    }
                //    else
                //    {
                //        dr["LoaiKhac"] = false;
                //    }

                //    if (_donkh.CT_HoaDon)
                //    {
                //        dr["CT_HoaDon"] = true;
                //    }
                //    else
                //    {
                //        dr["CT_HoaDon"] = false;
                //    }

                //    if (_donkh.CT_HK_KT3)
                //    {
                //        dr["CT_HK_KT3"] = true;
                //    }
                //    else
                //    {
                //        dr["CT_HK_KT3"] = false;
                //    }

                //    if (_donkh.CT_STT_GXNTT)
                //    {
                //        dr["CT_STT_GXNTT"] = true;
                //    }
                //    else
                //    {
                //        dr["CT_STT_GXNTT"] = false;
                //    }

                //    if (_donkh.CT_HDTN_CQN)
                //    {
                //        dr["CT_HDTN_CQN"] = true;
                //    }
                //    else
                //    {
                //        dr["CT_HDTN_CQN"] = false;
                //    }

                //    if (_donkh.CT_GC_SDSN)
                //    {
                //        dr["CT_GC_SDSN"] = true;
                //    }
                //    else
                //    {
                //        dr["CT_GC_SDSN"] = false;
                //    }

                //    if (_donkh.CT_GXN2SN)
                //    {
                //        dr["CT_GXN2SN"] = true;
                //    }
                //    else
                //    {
                //        dr["CT_GXN2SN"] = false;
                //    }

                //    if (_donkh.CT_GDKKD)
                //    {
                //        dr["CT_GDKKD"] = true;
                //    }
                //    else
                //    {
                //        dr["CT_GDKKD"] = false;
                //    }

                //    if (_donkh.CT_GCNDTDHN)
                //    {
                //        dr["CT_GCNDTDHN"] = true;
                //    }
                //    else
                //    {
                //        dr["CT_GCNDTDHN"] = false;
                //    }
                //    #endregion

                //    dr["DinhMucSau"] = txtDinhMucSau.Text.Trim();
                //    dr["HieuLucTuKy"] = txtHieuLucTuKy.Text.Trim();
                //    dr["HoTenNV"] = CTaiKhoan.HoTen;
                //    dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(dr);
                //    rptBienNhanDonKH rpt = new rptBienNhanDonKH();
                //    rpt.SetDataSource(dsBaoCao);
                //    frmBaoCao frm = new frmBaoCao(rpt);
                //    frm.ShowDialog();
                //}
                #endregion
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_donkh != null)
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (_cDonKH.XoaDonKH(_donkh))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }

        }

        private void frmShowDonKH_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtTongSoDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                if (_cLichSuDonTu.Xoa(_cLichSuDonTu.Get(decimal.Parse(dgvLichSuChuyenKT.CurrentRow.Cells["MaLSChuyenKT"].Value.ToString()))))
                {
                    dgvLichSuChuyenKT.DataSource = _cDonTXL.LoadDSLichSuChuyenKTbyMaDonTKH(_donkh.MaDon);
                }
        }

        private void dgvLichSuChuyenKT_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvLichSuChuyenKT.CurrentCell = dgvLichSuChuyenKT.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvLichSuChuyenKT_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && (_donkh != null))
            {
                contextMenuStrip1.Show(dgvLichSuChuyenKT, new Point(e.X, e.Y));
            }
        }

        private void chkChuyenKT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenKT.Checked)
            {
                groupBoxChuyenKTXM.Enabled = true;
                cmbNguoiDi.SelectedIndex = 0;
            }
            else
            {
                groupBoxChuyenKTXM.Enabled = false;
            }
        }

        private void chkChuyenBanDoiKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenBanDoiKhac.Checked)
            {
                groupBoxChuyenBanDoiKhac.Enabled = true;
            }
            else
            {
                groupBoxChuyenBanDoiKhac.Enabled = false;
            }
        }

        private void chkChuyenToXuLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenToXuLy.Checked)
            {
                groupBoxChuyenToXuLy.Enabled = true;
            }
            else
            {
                groupBoxChuyenToXuLy.Enabled = false;
            }
        }

        private void chkChuyenKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenKhac.Checked)
            {
                groupBoxChuyenKhac.Enabled = true;
            }
            else
            {
                groupBoxChuyenKhac.Enabled = false;
            }
        }

       
    }
}
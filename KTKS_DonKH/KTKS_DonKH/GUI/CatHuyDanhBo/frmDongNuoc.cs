using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.DongNuoc;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DongNuoc;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.BamChi;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.DongNuoc
{
    public partial class frmDongNuoc : Form
    {
        string _mnu = "mnuDongNuoc";
        CDonTu _cDonTu = new CDonTu();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CBamChi _cBamChi = new CBamChi();

        DonTu_ChiTiet _dontu_ChiTiet = null;
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        DongNuoc_ChiTiet _ctdongnuoc = null;
        decimal _MaCTDN = -1;

        public frmDongNuoc()
        {
            InitializeComponent();
        }

        public frmDongNuoc(decimal MaCTDN)
        {
            _MaCTDN = MaCTDN;
            InitializeComponent();
        }

        private void frmDongNuoc_Load(object sender, EventArgs e)
        {
            dgvDSBamChi.AutoGenerateColumns = false;

            if (_MaCTDN != -1)
            {
                txtMaThongBao_DN.Text = _MaCTDN.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtMaThongBao_DN_KeyPress(sender, arg);
            }
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHopDong.Text = hoadon.HOPDONG;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChiDHN.Text = txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
        }

        public void LoadDongNuoc(DongNuoc_ChiTiet ctdongnuoc)
        {
            if (ctdongnuoc.DongNuoc.MaDonMoi != null)
            {
                _dontu_ChiTiet = _cDonTu.getDonTu_ChiTiet(ctdongnuoc.DongNuoc.MaDonMoi.Value, ctdongnuoc.STT.Value);
                txtMaDonMoi.Text = ctdongnuoc.DongNuoc.MaDonMoi.ToString();
                dgvDSBamChi.DataSource = _cBamChi.getDS(ctdongnuoc.DongNuoc.MaDonMoi.Value, ctdongnuoc.DanhBo);
            }
            else
            if (ctdongnuoc.DongNuoc.MaDon != null)
            {
                _dontkh = _cDonKH.Get(ctdongnuoc.DongNuoc.MaDon.Value);
                txtMaDonCu.Text = ctdongnuoc.DongNuoc.MaDon.ToString().Insert(ctdongnuoc.DongNuoc.MaDon.ToString().Length - 2, "-");
                dgvDSBamChi.DataSource = _cBamChi.GetDS("TKH", ctdongnuoc.DongNuoc.MaDon.Value, ctdongnuoc.DanhBo);
            }
            else
                if (ctdongnuoc.DongNuoc.MaDonTXL != null)
                {
                    _dontxl = _cDonTXL.Get(ctdongnuoc.DongNuoc.MaDonTXL.Value);
                    txtMaDonCu.Text = "TXL" + ctdongnuoc.DongNuoc.MaDonTXL.ToString().Insert(ctdongnuoc.DongNuoc.MaDonTXL.ToString().Length - 2, "-");
                    dgvDSBamChi.DataSource = _cBamChi.GetDS("TXL", ctdongnuoc.DongNuoc.MaDonTXL.Value, ctdongnuoc.DanhBo);
                }
                else
                    if (ctdongnuoc.DongNuoc.MaDonTBC != null)
                    {
                        _dontbc = _cDonTBC.Get(ctdongnuoc.DongNuoc.MaDonTBC.Value);
                        txtMaDonCu.Text = "TBC" + ctdongnuoc.DongNuoc.MaDonTBC.ToString().Insert(ctdongnuoc.DongNuoc.MaDonTBC.ToString().Length - 2, "-");
                        dgvDSBamChi.DataSource = _cBamChi.GetDS("TBC", ctdongnuoc.DongNuoc.MaDonTBC.Value, ctdongnuoc.DanhBo);
                    }
            txtMaThongBao_DN.Text = ctdongnuoc.MaCTDN.ToString().Insert(ctdongnuoc.MaCTDN.ToString().Length - 2, "-");

            if (!string.IsNullOrEmpty(ctdongnuoc.MaCTMN.ToString()))
                txtMaThongBao_MN.Text = ctdongnuoc.MaCTMN.ToString().Insert(ctdongnuoc.MaCTMN.ToString().Length - 2, "-");
            ///
            txtDanhBo.Text = ctdongnuoc.DanhBo;
            txtHopDong.Text = ctdongnuoc.HopDong;
            txtHoTen.Text = ctdongnuoc.HoTen;
            txtDiaChi.Text = ctdongnuoc.DiaChi;
            txtDiaChiDHN.Text = ctdongnuoc.DiaChiDHN;
            ///
            dateDongNuoc.Value = ctdongnuoc.NgayDN.Value;
            //txtSoCongVan_DN.Text = ctdongnuoc.SoCongVan_DN;
            //dateCongVan_DN.Value = ctdongnuoc.NgayCongVan_DN.Value;
            //txtPhuong_DN.Text = ctdongnuoc.Phuong;
            //txtQuan_DN.Text = ctdongnuoc.Quan;
            txtLyDo.Text = ctdongnuoc.LyDoDN;
            txtNoiDung.Text = ctdongnuoc.NoiDungDN;
            ///
            if (ctdongnuoc.MoNuoc)
            {
                dateMoNuoc.Value = ctdongnuoc.NgayMN.Value;
                txtSoCongVan_MN.Text = ctdongnuoc.SoCongVan_MN;
                dateCongVan_MN.Value = ctdongnuoc.NgayCongVan_MN.Value;
                txtLyDoDN.Text = ctdongnuoc.LyDo_DN;
                txtHinhThucDN.Text = ctdongnuoc.HinhThuc_DN;
                btnLapTBMoNuoc.Enabled = false;
            }
            else
            {
                dateMoNuoc.Value = DateTime.Now;
                txtSoCongVan_MN.Text = "";
                dateCongVan_MN.Value = DateTime.Now;
                txtLyDoDN.Text = "";
                txtHinhThucDN.Text = "";
                btnLapTBMoNuoc.Enabled = true;
            }
        }

        public void Clear()
        {
            txtMaDonCu.Text="";
            txtMaDonMoi.Text = "";
            txtMaThongBao_DN.Text = "";
            txtMaThongBao_MN.Text = "";
            ///
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtDiaChiDHN.Text = "";
            ///
            dateDongNuoc.Value = DateTime.Now;
            txtSoCongVan_DN.Text = "";
            dateCongVan_DN.Value = DateTime.Now;
            txtPhuong_DN.Text = "";
            txtQuan_DN.Text = "";
            ///
            dateMoNuoc.Value = DateTime.Now;
            txtSoCongVan_MN.Text = "";
            dateCongVan_MN.Value = DateTime.Now;
            txtPhuong_MN.Text = "";
            txtQuan_MN.Text = "";
            txtLyDoDN.Text = "";
            txtHinhThucDN.Text = "";
            ///
            _dontkh = null;
            _dontxl = null;
            _hoadon = null;
            _ctdongnuoc = null;
            _MaCTDN = -1;
            ///
            dgvDSBamChi.DataSource = null;
        }

        private void txtMaDonCu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDonCu.Text.Trim() != "")
            {
                string MaDon = txtMaDonCu.Text.Trim();
                Clear();
                txtMaDonCu.Text = MaDon;
                ///Đơn Tổ Xử Lý
                if (txtMaDonCu.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_cDonTXL.CheckExist(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", ""))) == true)
                    {
                        _dontxl = _cDonTXL.Get(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDonCu.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");

                        if (_cThuTien.GetMoiNhat(_dontxl.DanhBo) != null)
                        {
                            _hoadon = _cThuTien.GetMoiNhat(_dontxl.DanhBo);
                            LoadTTKH(_hoadon);
                        }
                        else
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    if (txtMaDonCu.Text.Trim().ToUpper().Contains("TBC"))
                    {
                        if (_cDonTBC.CheckExist(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", ""))) == true)
                        {
                            _dontbc = _cDonTBC.Get(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                            txtMaDonCu.Text = "TBC" + _dontbc.MaDon.ToString().Insert(_dontbc.MaDon.ToString().Length - 2, "-");

                            if (_cThuTien.GetMoiNhat(_dontbc.DanhBo) != null)
                            {
                                _hoadon = _cThuTien.GetMoiNhat(_dontbc.DanhBo);
                                LoadTTKH(_hoadon);
                            }
                            else
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ///Đơn Tổ Khách Hàng
                    else
                        if (_cDonKH.CheckExist(decimal.Parse(txtMaDonCu.Text.Trim().Replace("-", ""))) == true)
                        {
                            _dontkh = _cDonKH.Get(decimal.Parse(txtMaDonCu.Text.Trim().Replace("-", "")));
                            txtMaDonCu.Text = _dontkh.MaDon.ToString().Insert(_dontkh.MaDon.ToString().Length - 2, "-");

                            if (_cThuTien.GetMoiNhat(_dontkh.DanhBo) != null)
                            {
                                _hoadon = _cThuTien.GetMoiNhat(_dontkh.DanhBo);
                                LoadTTKH(_hoadon);
                            }
                            else
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaDonMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDonMoi.Text.Trim() != "")
            {
                string MaDon = txtMaDonMoi.Text.Trim();
                Clear();
                if (MaDon.Contains(".") == true)
                {
                    string[] MaDons = MaDon.Split('.');
                    _dontu_ChiTiet = _cDonTu.getDonTu_ChiTiet(int.Parse(MaDons[0]), int.Parse(MaDons[1]));
                }
                else
                {
                    _dontu_ChiTiet = _cDonTu.getDonTu(int.Parse(MaDon)).DonTu_ChiTiets.SingleOrDefault();
                }
                //
                if (_dontu_ChiTiet != null)
                {
                    txtMaDonMoi.Text = _dontu_ChiTiet.MaDon.Value.ToString();

                    _hoadon = _cThuTien.GetMoiNhat(_dontu_ChiTiet.DanhBo);
                    if (_hoadon != null)
                    {
                        LoadTTKH(_hoadon);
                    }
                    else
                        MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cThuTien.GetMoiNhat(txtDanhBo.Text.Trim()) != null)
                {
                    _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                    LoadTTKH(_hoadon);
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaThongBao_DN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cDongNuoc.GetCTByMaCTDN(decimal.Parse(txtMaThongBao_DN.Text.Trim().Replace("-", ""))) != null)
                {
                    _ctdongnuoc = _cDongNuoc.GetCTByMaCTDN(decimal.Parse(txtMaThongBao_DN.Text.Trim().Replace("-", "")));
                    LoadDongNuoc(_ctdongnuoc);
                }
                else
                    MessageBox.Show("Mã Thông Báo này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaThongBao_MN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cDongNuoc.GetCTByMaCTMN(decimal.Parse(txtMaThongBao_MN.Text.Trim().Replace("-", ""))) != null)
                {
                    _ctdongnuoc = _cDongNuoc.GetCTByMaCTMN(decimal.Parse(txtMaThongBao_MN.Text.Trim().Replace("-", "")));
                    LoadDongNuoc(_ctdongnuoc);
                }
                else
                    MessageBox.Show("Mã Thông Báo này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLapTBDongNuoc_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    ///Thêm
                    if (_ctdongnuoc == null)
                    {
                        DongNuoc_ChiTiet ctdongnuoc = new DongNuoc_ChiTiet();

                        if (_dontu_ChiTiet != null)
                        {
                            if (_cDongNuoc.checkExist(_dontu_ChiTiet.MaDon.Value) == false)
                            {
                                LinQ.DongNuoc dongnuoc = new LinQ.DongNuoc();
                                dongnuoc.MaDonMoi = _dontu_ChiTiet.MaDon.Value;
                                _cDongNuoc.Them(dongnuoc);
                            }
                            if (_cDongNuoc.checkExist_ChiTiet(_dontu_ChiTiet.MaDon.Value, txtDanhBo.Text.Trim()))
                            {
                                MessageBox.Show("Danh Bộ này đã được Lập Đóng Nước", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            ctdongnuoc.MaDN = _cDongNuoc.get(_dontu_ChiTiet.MaDon.Value).MaDN;
                            ctdongnuoc.STT = _dontu_ChiTiet.STT.Value;
                        }
                        else
                        if (_dontkh != null)
                        {
                            if (_cDongNuoc.CheckExist("TKH", _dontkh.MaDon) == false)
                            {
                                LinQ.DongNuoc dongnuoc = new LinQ.DongNuoc();
                                dongnuoc.MaDon = _dontkh.MaDon;
                                _cDongNuoc.Them(dongnuoc);
                            }
                            if (_cDongNuoc.CheckExist_CT("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim()))
                            {
                                MessageBox.Show("Danh Bộ này đã được Lập Đóng Nước", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            ctdongnuoc.MaDN = _cDongNuoc.Get("TKH", _dontkh.MaDon).MaDN;
                        }
                        else
                            if (_dontxl != null)
                            {
                                if (_cDongNuoc.CheckExist("TXL", _dontxl.MaDon) == false)
                                {
                                    LinQ.DongNuoc dongnuoc = new LinQ.DongNuoc();
                                    dongnuoc.MaDonTXL = _dontxl.MaDon;
                                    _cDongNuoc.Them(dongnuoc);
                                }
                                if (_cDongNuoc.CheckExist_CT("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim()))
                                {
                                    MessageBox.Show("Danh Bộ này đã được Lập Đóng Nước", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                ctdongnuoc.MaDN = _cDongNuoc.Get("TXL", _dontxl.MaDon).MaDN;
                            }
                            else
                                if (_dontbc != null)
                                {
                                    if (_cDongNuoc.CheckExist("TBC", _dontbc.MaDon) == false)
                                    {
                                        LinQ.DongNuoc dongnuoc = new LinQ.DongNuoc();
                                        dongnuoc.MaDonTBC = _dontbc.MaDon;
                                        _cDongNuoc.Them(dongnuoc);
                                    }
                                    if (_cDongNuoc.CheckExist_CT("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim()))
                                    {
                                        MessageBox.Show("Danh Bộ này đã được Lập Đóng Nước", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    ctdongnuoc.MaDN = _cDongNuoc.Get("TBC", _dontbc.MaDon).MaDN;
                                }
                                else
                                {
                                    MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                        ctdongnuoc.DanhBo = txtDanhBo.Text.Trim();
                        ctdongnuoc.HopDong = txtHopDong.Text.Trim();
                        ctdongnuoc.HoTen = txtHoTen.Text.Trim();
                        ctdongnuoc.DiaChi = txtDiaChi.Text.Trim();
                        if (_hoadon != null)
                        {
                            ctdongnuoc.Dot = _hoadon.DOT.ToString();
                            ctdongnuoc.Ky = _hoadon.KY.ToString();
                            ctdongnuoc.Nam = _hoadon.NAM.ToString();
                            ctdongnuoc.Phuong = _hoadon.Phuong;
                            ctdongnuoc.Quan = _hoadon.Quan;
                        }
                        ctdongnuoc.DiaChiDHN = txtDiaChiDHN.Text.Trim();
                        ctdongnuoc.NgayDN = dateDongNuoc.Value;
                        //ctdongnuoc.SoCongVan_DN = txtSoCongVan_DN.Text.Trim();
                        //ctdongnuoc.NgayCongVan_DN = dateCongVan_DN.Value;
                        //ctdongnuoc.Phuong = txtPhuong_DN.Text.Trim();
                        //ctdongnuoc.Quan = txtQuan_DN.Text.Trim();
                        ctdongnuoc.LyDoDN = txtLyDo.Text.Trim();
                        ctdongnuoc.NoiDungDN = txtNoiDung.Text;
                        ///Ký Tên
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            ctdongnuoc.ChucVu_DN = "GIÁM ĐỐC";
                        else
                            ctdongnuoc.ChucVu_DN = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        ctdongnuoc.NguoiKy_DN = bangiamdoc.HoTen.ToUpper();
                        ctdongnuoc.ThongBaoDuocKy_DN = true;

                        if (_cDongNuoc.ThemCT(ctdongnuoc))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMaDonCu.Focus();
                        }
                    }
                    ///Sữa
                    else
                    {
                        _ctdongnuoc.DanhBo = txtDanhBo.Text.Trim();
                        _ctdongnuoc.HopDong = txtHopDong.Text.Trim();
                        _ctdongnuoc.HoTen = txtHoTen.Text.Trim();
                        _ctdongnuoc.DiaChi = txtDiaChi.Text.Trim();
                        if (_hoadon != null)
                        {
                            _ctdongnuoc.Dot = _hoadon.DOT.ToString();
                            _ctdongnuoc.Ky = _hoadon.KY.ToString();
                            _ctdongnuoc.Nam = _hoadon.NAM.ToString();
                            _ctdongnuoc.Phuong = _hoadon.Phuong;
                            _ctdongnuoc.Quan = _hoadon.Quan;
                        }
                        _ctdongnuoc.DiaChiDHN = txtDiaChiDHN.Text.Trim();
                        _ctdongnuoc.NgayDN = dateDongNuoc.Value;
                        //_ctdongnuoc.SoCongVan_DN = txtSoCongVan_DN.Text.Trim();
                        //_ctdongnuoc.NgayCongVan_DN = dateCongVan_DN.Value;
                        //_ctdongnuoc.Phuong = txtPhuong_DN.Text.Trim();
                        //_ctdongnuoc.Quan = txtQuan_DN.Text.Trim();
                        _ctdongnuoc.LyDoDN = txtLyDo.Text.Trim();
                        _ctdongnuoc.NoiDungDN = txtNoiDung.Text;

                        if (_cDongNuoc.SuaCT(_ctdongnuoc))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMaDonCu.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnLapTBMoNuoc_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                ///Thêm
                if (_ctdongnuoc != null && _ctdongnuoc.MoNuoc == false)
                {
                    if (txtSoCongVan_MN.Text.Trim() != "")
                    {
                        _ctdongnuoc.MoNuoc = true;
                        _ctdongnuoc.MaCTMN = _cDongNuoc.getMaxNextMaCTMN();
                        _ctdongnuoc.NgayMN = dateMoNuoc.Value;
                        _ctdongnuoc.SoCongVan_MN = txtSoCongVan_MN.Text.Trim();
                        _ctdongnuoc.NgayCongVan_MN = dateCongVan_MN.Value;
                        _ctdongnuoc.LyDo_DN = txtLyDoDN.Text.Trim();
                        _ctdongnuoc.HinhThuc_DN = txtHinhThucDN.Text.Trim();

                        ///Ký Tên
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            _ctdongnuoc.ChucVu_MN = "GIÁM ĐỐC";
                        else
                            _ctdongnuoc.ChucVu_MN = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        _ctdongnuoc.NguoiKy_MN = bangiamdoc.HoTen.ToUpper();
                        _ctdongnuoc.ThongBaoDuocKy_MN = true;

                        if (_cDongNuoc.SuaCT(_ctdongnuoc))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMaDonCu.Focus();
                        }
                    }
                }
                else
                    ///Sửa
                    if (_ctdongnuoc != null && _ctdongnuoc.MoNuoc == true)
                    {
                        _ctdongnuoc.NgayMN = dateMoNuoc.Value;
                        _ctdongnuoc.SoCongVan_MN = txtSoCongVan_MN.Text.Trim();
                        _ctdongnuoc.NgayCongVan_MN = dateCongVan_MN.Value;
                        _ctdongnuoc.LyDo_DN = txtLyDoDN.Text.Trim();
                        _ctdongnuoc.HinhThuc_DN = txtHinhThucDN.Text.Trim();

                        if (_cDongNuoc.SuaCT(_ctdongnuoc))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMaDonCu.Focus();
                        }
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInTBDongNuoc_Click(object sender, EventArgs e)
        {
            if (_ctdongnuoc != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThongBaoDongNuoc"].NewRow();

                dr["SoPhieu"] = _ctdongnuoc.MaCTDN.ToString().Insert(_ctdongnuoc.MaCTDN.ToString().Length - 2, "-");
                dr["HoTen"] = _ctdongnuoc.HoTen;
                dr["DiaChi"] = _ctdongnuoc.DiaChi;
                dr["DanhBo"] = _ctdongnuoc.DanhBo;
                dr["HopDong"] = _ctdongnuoc.HopDong;
                dr["DiaChiDHN"] = _ctdongnuoc.DiaChiDHN;
                ///
                dr["NgayXuLy"] = _ctdongnuoc.NgayDN.Value.ToString("dd/MM/yyyy");
                //dr["SoCongVan"] = _ctdongnuoc.SoCongVan_DN;
                //dr["NgayCongVan"] = _ctdongnuoc.NgayCongVan_DN.Value.ToString("dd/MM/yyyy");
                //dr["Phuong"] = _ctdongnuoc.Phuong;
                //dr["Quan"] = _ctdongnuoc.Quan;
                dr["LyDo"] = _ctdongnuoc.LyDoDN;
                dr["NoiDung"] = _ctdongnuoc.NoiDungDN;
                ///
                dr["ChucVu"] = _ctdongnuoc.ChucVu_DN;
                dr["NguoiKy"] = _ctdongnuoc.NguoiKy_DN;

                dsBaoCao.Tables["ThongBaoDongNuoc"].Rows.Add(dr);

                rptThongBaoDN rpt = new rptThongBaoDN();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Chưa có Thông Báo Đóng Nước", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInTBMoNuoc_Click(object sender, EventArgs e)
        {
            if (_ctdongnuoc != null && _ctdongnuoc.MoNuoc == true)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThongBaoDongNuoc"].NewRow();

                dr["SoPhieu"] = _ctdongnuoc.MaCTMN.ToString().Insert(_ctdongnuoc.MaCTMN.ToString().Length - 2, "-");
                dr["HoTen"] = _ctdongnuoc.HoTen;
                dr["DiaChi"] = _ctdongnuoc.DiaChi;
                dr["DanhBo"] = _ctdongnuoc.DanhBo;
                dr["HopDong"] = _ctdongnuoc.HopDong;
                dr["DiaChiDHN"] = _ctdongnuoc.DiaChiDHN;
                ///
                dr["NgayXuLy"] = _ctdongnuoc.NgayMN.Value.ToString("dd/MM/yyyy");
                dr["SoCongVan"] = _ctdongnuoc.SoCongVan_MN;
                dr["NgayCongVan"] = _ctdongnuoc.NgayCongVan_MN.Value.ToString("dd/MM/yyyy");
                dr["Phuong"] = _ctdongnuoc.TenPhuong;
                dr["Quan"] = _ctdongnuoc.TenQuan;
                dr["LyDo"] = _ctdongnuoc.LyDo_DN;
                dr["HinhThuc"] = _ctdongnuoc.HinhThuc_DN;
                dr["SoPhieuDN"] = _ctdongnuoc.MaCTDN.ToString().Insert(_ctdongnuoc.MaCTDN.ToString().Length - 2, "-");
                ///
                dr["ChucVu"] = _ctdongnuoc.ChucVu_MN;
                dr["NguoiKy"] = _ctdongnuoc.NguoiKy_MN;

                dsBaoCao.Tables["ThongBaoDongNuoc"].Rows.Add(dr);

                rptThongBaoMN rpt = new rptThongBaoMN();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Chưa có Thông Báo Đóng Nước/Nội Dung Mở Nước", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        

    }
}

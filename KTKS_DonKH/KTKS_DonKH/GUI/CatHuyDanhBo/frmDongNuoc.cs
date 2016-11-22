using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.DongNuoc;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DongNuoc;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.BamChi;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL;

namespace KTKS_DonKH.GUI.DongNuoc
{
    public partial class frmDongNuoc : Form
    {
        string _mnu = "mnuDongNuoc";
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        HOADON _hoadon = null;
        CTDongNuoc _ctdongnuoc = null;
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CBamChi _cBamChi = new CBamChi();
        decimal _MaCTDN = 0;

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

            if (_MaCTDN != 0)
            {
                txtMaThongBao_DN.Text = _MaCTDN.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtMaThongBao_DN_KeyPress(sender, arg);
            }
        }

        /// <summary>
        /// Nhận Entity TTKhachHang để điền vào textbox
        /// </summary>
        /// <param name="ttkhachhang"></param>
        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHopDong.Text = hoadon.HOPDONG;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChiDHN.Text = txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.getPhuongQuanByID(hoadon.Quan, hoadon.Phuong);
        }

        public void Clear()
        {
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
            _donkh = null;
            _dontxl = null;
            _hoadon = null;
            _ctdongnuoc = null;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                string MaDon = txtMaDon.Text.Trim();
                Clear();
                txtMaDon.Text = MaDon;
                ///Đơn Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", ""))) != null)
                    {
                        _dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDon.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");
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
                ///Đơn Tổ Khách Hàng
                else
                    if (_cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) != null)
                    {
                        _donkh = _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                        txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                        if (_cThuTien.GetMoiNhat(_donkh.DanhBo) != null)
                        {
                            _hoadon = _cThuTien.GetMoiNhat(_donkh.DanhBo);
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
                    if (!string.IsNullOrEmpty(_ctdongnuoc.DongNuoc.MaDonTXL.ToString()))
                    {
                        txtMaDon.Text = "TXL" + _ctdongnuoc.DongNuoc.MaDonTXL.ToString().Insert(_ctdongnuoc.DongNuoc.MaDonTXL.ToString().Length - 2, "-");
                        dgvDSBamChi.DataSource = _cBamChi.LoadDSCTBamChi_TXL(_ctdongnuoc.DongNuoc.MaDonTXL.Value, _ctdongnuoc.DanhBo);
                    }
                    else
                        if (!string.IsNullOrEmpty(_ctdongnuoc.DongNuoc.MaDon.ToString()))
                        {
                            txtMaDon.Text = _ctdongnuoc.DongNuoc.MaDon.ToString().Insert(_ctdongnuoc.DongNuoc.MaDon.ToString().Length - 2, "-");
                            dgvDSBamChi.DataSource = _cBamChi.LoadDSCTBamChi(_ctdongnuoc.DongNuoc.MaDon.Value, _ctdongnuoc.DanhBo);
                        }

                    txtMaThongBao_DN.Text = _ctdongnuoc.MaCTDN.ToString().Insert(_ctdongnuoc.MaCTDN.ToString().Length - 2, "-");

                    if (!string.IsNullOrEmpty(_ctdongnuoc.MaCTMN.ToString()))
                        txtMaThongBao_MN.Text = _ctdongnuoc.MaCTMN.ToString().Insert(_ctdongnuoc.MaCTMN.ToString().Length - 2, "-");
                    ///
                    txtDanhBo.Text = _ctdongnuoc.DanhBo;
                    txtHopDong.Text = _ctdongnuoc.HopDong;
                    txtHoTen.Text = _ctdongnuoc.HoTen;
                    txtDiaChi.Text = _ctdongnuoc.DiaChi;
                    txtDiaChiDHN.Text = _ctdongnuoc.DiaChiDHN;
                    ///
                    dateDongNuoc.Value = _ctdongnuoc.NgayDN.Value;
                    txtSoCongVan_DN.Text = _ctdongnuoc.SoCongVan_DN;
                    dateCongVan_DN.Value = _ctdongnuoc.NgayCongVan_DN.Value;
                    txtPhuong_DN.Text = _ctdongnuoc.Phuong;
                    txtQuan_DN.Text = _ctdongnuoc.Quan;
                    ///
                    if (_ctdongnuoc.MoNuoc)
                    {
                        dateMoNuoc.Value = _ctdongnuoc.NgayMN.Value;
                        txtSoCongVan_MN.Text = _ctdongnuoc.SoCongVan_MN;
                        dateCongVan_MN.Value = _ctdongnuoc.NgayCongVan_MN.Value;
                        txtLyDoDN.Text = _ctdongnuoc.LyDo_DN;
                        txtHinhThucDN.Text = _ctdongnuoc.HinhThuc_DN;
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
                    if (!string.IsNullOrEmpty(_ctdongnuoc.DongNuoc.MaDonTXL.ToString()))
                    {
                        txtMaDon.Text = "TXL" + _ctdongnuoc.DongNuoc.MaDonTXL.ToString().Insert(_ctdongnuoc.DongNuoc.MaDonTXL.ToString().Length - 2, "-");
                        dgvDSBamChi.DataSource = _cBamChi.LoadDSCTBamChi_TXL(_ctdongnuoc.DongNuoc.MaDonTXL.Value, _ctdongnuoc.DanhBo);
                    }
                    else
                        if (!string.IsNullOrEmpty(_ctdongnuoc.DongNuoc.MaDon.ToString()))
                        {
                            txtMaDon.Text = _ctdongnuoc.DongNuoc.MaDon.ToString().Insert(_ctdongnuoc.DongNuoc.MaDon.ToString().Length - 2, "-");
                            dgvDSBamChi.DataSource = _cBamChi.LoadDSCTBamChi(_ctdongnuoc.DongNuoc.MaDon.Value, _ctdongnuoc.DanhBo);
                        }

                    txtMaThongBao_DN.Text = _ctdongnuoc.MaCTDN.ToString().Insert(_ctdongnuoc.MaCTDN.ToString().Length - 2, "-");
                    txtMaThongBao_MN.Text = _ctdongnuoc.MaCTMN.ToString().Insert(_ctdongnuoc.MaCTMN.ToString().Length - 2, "-");
                    ///
                    txtDanhBo.Text = _ctdongnuoc.DanhBo;
                    txtHopDong.Text = _ctdongnuoc.HopDong;
                    txtHoTen.Text = _ctdongnuoc.HoTen;
                    txtDiaChi.Text = _ctdongnuoc.DiaChi;
                    txtDiaChiDHN.Text = _ctdongnuoc.DiaChiDHN;
                    ///
                    dateDongNuoc.Value = _ctdongnuoc.NgayDN.Value;
                    txtSoCongVan_DN.Text = _ctdongnuoc.SoCongVan_DN;
                    dateCongVan_DN.Value = _ctdongnuoc.NgayCongVan_DN.Value;
                    txtPhuong_DN.Text = _ctdongnuoc.Phuong;
                    txtQuan_DN.Text = _ctdongnuoc.Quan;
                    ///
                    if (_ctdongnuoc.MoNuoc)
                    {
                        dateMoNuoc.Value = _ctdongnuoc.NgayMN.Value;
                        txtSoCongVan_MN.Text = _ctdongnuoc.SoCongVan_MN;
                        dateCongVan_MN.Value = _ctdongnuoc.NgayCongVan_MN.Value;
                        txtLyDoDN.Text = _ctdongnuoc.LyDo_DN;
                        txtHinhThucDN.Text = _ctdongnuoc.HinhThuc_DN;
                    }
                    else
                    {
                        dateMoNuoc.Value = DateTime.Now;
                        txtSoCongVan_MN.Text = "";
                        dateCongVan_MN.Value = DateTime.Now;
                        txtLyDoDN.Text = "";
                        txtHinhThucDN.Text = "";
                    }
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
                        ///Nếu đơn thuộc Tổ Xử Lý
                        if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                        {
                            if (_dontxl != null && txtSoCongVan_DN.Text.Trim() != "")
                            {
                                if (!_cDongNuoc.CheckByMaDon_TXL(_dontxl.MaDon))
                                {
                                    LinQ.DongNuoc dongnuoc = new LinQ.DongNuoc();
                                    dongnuoc.ToXuLy = true;
                                    dongnuoc.MaDonTXL = _dontxl.MaDon;
                                    if (_cDongNuoc.Them(dongnuoc))
                                    {
                                        _dontxl.DaGiaiQuyet = true;
                                    }
                                }
                                if (_cDongNuoc.CheckCTByMaDonDanhBo_TXL(_dontxl.MaDon, txtDanhBo.Text.Trim()))
                                {
                                    MessageBox.Show("Danh Bộ này đã được Lập Cắt Hủy Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                CTDongNuoc ctdongnuoc = new CTDongNuoc();
                                ctdongnuoc.MaDN = _cDongNuoc.GetByMaDon_TXL(_dontxl.MaDon).MaDN;
                                ctdongnuoc.DanhBo = txtDanhBo.Text.Trim();
                                ctdongnuoc.HopDong = txtHopDong.Text.Trim();
                                ctdongnuoc.HoTen = txtHoTen.Text.Trim();
                                ctdongnuoc.DiaChi = txtDiaChi.Text.Trim();
                                if (_hoadon != null)
                                {
                                    ctdongnuoc.Dot = _hoadon.DOT.ToString();
                                    ctdongnuoc.Ky = _hoadon.KY.ToString();
                                    ctdongnuoc.Nam = _hoadon.NAM.ToString();
                                }
                                ctdongnuoc.DiaChiDHN = txtDiaChiDHN.Text.Trim();
                                ctdongnuoc.NgayDN = dateDongNuoc.Value;
                                ctdongnuoc.SoCongVan_DN = txtSoCongVan_DN.Text.Trim();
                                ctdongnuoc.NgayCongVan_DN = dateCongVan_DN.Value;
                                ctdongnuoc.Phuong = txtPhuong_DN.Text.Trim();
                                ctdongnuoc.Quan = txtQuan_DN.Text.Trim();
                                ///Ký Tên
                                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                    ctdongnuoc.ChucVu_DN = "GIÁM ĐỐC";
                                else
                                    ctdongnuoc.ChucVu_DN = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                ctdongnuoc.NguoiKy_DN = bangiamdoc.HoTen.ToUpper();
                                ctdongnuoc.ThongBaoDuocKy_DN = true;

                                if (_cDongNuoc.ThemCTDongNuoc(ctdongnuoc))
                                {
                                    Clear();
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtMaDon.Focus();
                                }
                            }
                            else
                                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ///Nếu đơn thuộc Tổ Khách Hàng
                        else
                            if (_donkh != null && txtSoCongVan_DN.Text.Trim() != "")
                            {
                                if (!_cDongNuoc.CheckByMaDon(_donkh.MaDon))
                                {
                                    LinQ.DongNuoc dongnuoc = new LinQ.DongNuoc();
                                    dongnuoc.MaDon = _donkh.MaDon;
                                    if (_cDongNuoc.Them(dongnuoc))
                                    {
                                        _donkh.DaGiaiQuyet = true;
                                    }
                                }
                                if (_cDongNuoc.CheckCTByMaDonDanhBo(_donkh.MaDon, txtDanhBo.Text.Trim()))
                                {
                                    MessageBox.Show("Danh Bộ này đã được Lập Cắt Hủy Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                CTDongNuoc ctdongnuoc = new CTDongNuoc();
                                ctdongnuoc.MaDN = _cDongNuoc.GetByMaDon(_donkh.MaDon).MaDN;
                                ctdongnuoc.DanhBo = txtDanhBo.Text.Trim();
                                ctdongnuoc.HopDong = txtHopDong.Text.Trim();
                                ctdongnuoc.HoTen = txtHoTen.Text.Trim();
                                ctdongnuoc.DiaChi = txtDiaChi.Text.Trim();
                                if (_hoadon != null)
                                {
                                    ctdongnuoc.Dot = _hoadon.DOT.ToString();
                                    ctdongnuoc.Ky = _hoadon.KY.ToString();
                                    ctdongnuoc.Nam = _hoadon.NAM.ToString();
                                }
                                ctdongnuoc.DiaChiDHN = txtDiaChiDHN.Text.Trim();
                                ctdongnuoc.NgayDN = dateDongNuoc.Value;
                                ctdongnuoc.SoCongVan_DN = txtSoCongVan_DN.Text.Trim();
                                ctdongnuoc.NgayCongVan_DN = dateCongVan_DN.Value;
                                ctdongnuoc.Phuong = txtPhuong_DN.Text.Trim();
                                ctdongnuoc.Quan = txtQuan_DN.Text.Trim();
                                ///Ký Tên
                                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                    ctdongnuoc.ChucVu_DN = "GIÁM ĐỐC";
                                else
                                    ctdongnuoc.ChucVu_DN = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                ctdongnuoc.NguoiKy_DN = bangiamdoc.HoTen.ToUpper();
                                ctdongnuoc.ThongBaoDuocKy_DN = true;

                                if (_cDongNuoc.ThemCTDongNuoc(ctdongnuoc))
                                {
                                    Clear();
                                    MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtMaDon.Focus();
                                }
                            }
                            else
                                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        }
                        _ctdongnuoc.DiaChiDHN = txtDiaChiDHN.Text.Trim();
                        _ctdongnuoc.NgayDN = dateDongNuoc.Value;
                        _ctdongnuoc.SoCongVan_DN = txtSoCongVan_DN.Text.Trim();
                        _ctdongnuoc.NgayCongVan_DN = dateCongVan_DN.Value;
                        _ctdongnuoc.Phuong = txtPhuong_DN.Text.Trim();
                        _ctdongnuoc.Quan = txtQuan_DN.Text.Trim();

                        if (_cDongNuoc.SuaCT(_ctdongnuoc))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMaDon.Focus();
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
                            txtMaDon.Focus();
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
                            txtMaDon.Focus();
                        }
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInTBDongNuoc_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
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
                    dr["SoCongVan"] = _ctdongnuoc.SoCongVan_DN;
                    dr["NgayCongVan"] = _ctdongnuoc.NgayCongVan_DN.Value.ToString("dd/MM/yyyy");
                    dr["Phuong"] = _ctdongnuoc.Phuong;
                    dr["Quan"] = _ctdongnuoc.Quan;
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
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInTBMoNuoc_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
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
                    dr["Phuong"] = _ctdongnuoc.Phuong;
                    dr["Quan"] = _ctdongnuoc.Quan;
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
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



    }
}

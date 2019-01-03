using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.ThuTraLoi;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ThuTraLoi;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.ThuTraLoi
{
    public partial class frmTTTL : Form
    {
        string _mnu = "mnuTTTL";
        CDonTu _cDonTu = new CDonTu();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CTTTL _cTTTL = new CTTTL();
        CTTTL_GhiChu _cGhiChuCTTTTL = new CTTTL_GhiChu();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CTTTL_VeViec _cVeViecTTTL = new CTTTL_VeViec();

        DonTu_ChiTiet _dontu_ChiTiet = null;
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        TTTL_ChiTiet _cttttl = null;
        decimal _MaCTTTTL = -1;

        public frmTTTL()
        {
            InitializeComponent();
        }

        public frmTTTL(decimal MaCTTTTL)
        {
            _MaCTTTTL = MaCTTTTL;
            InitializeComponent();
        }

        private void frmTTTL_Load(object sender, EventArgs e)
        {
            dgvLichSuTTTL.AutoGenerateColumns = false;
            dgvGhiChu.AutoGenerateColumns = false;

            cmbVeViec.DataSource = _cVeViecTTTL.GetDS();
            cmbVeViec.DisplayMember = "TenVV";
            cmbVeViec.SelectedIndex = -1;

            if (_MaCTTTTL != -1)
            {
                txtMaCTTTTL.Text = _MaCTTTTL.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtMaCTTTTL_KeyPress(sender, arg);
            }
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHopDong.Text = hoadon.HOPDONG;
            txtLoTrinh.Text = hoadon.DOT + hoadon.MAY + hoadon.STT;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
            txtGiaBieu.Text = hoadon.GB.ToString();
            txtDinhMuc.Text = hoadon.DM.ToString();

            dgvLichSuTTTL.DataSource = _cTTTL.GetLichSuCTByDanhBo(_hoadon.DANHBA);
        }

        public void LoadTTTL(TTTL_ChiTiet cttttl)
        {
            if (cttttl.TTTL.MaDonMoi != null)
            {
                _dontu_ChiTiet = _cDonTu.get_ChiTiet(cttttl.TTTL.MaDonMoi.Value, cttttl.STT.Value);
                txtMaDonMoi.Text = cttttl.TTTL.MaDonMoi.Value.ToString();
            }
            else
            if (cttttl.TTTL.MaDon != null)
            {
                _dontkh = _cDonKH.Get(cttttl.TTTL.MaDon.Value);
                txtMaDonCu.Text = cttttl.TTTL.MaDon.Value.ToString().Insert(cttttl.TTTL.MaDon.Value.ToString().Length - 2, "-");
            }
            else
                if (cttttl.TTTL.MaDonTXL != null)
                {
                    _dontxl = _cDonTXL.Get(cttttl.TTTL.MaDonTXL.Value);
                    txtMaDonCu.Text = "TXL" + cttttl.TTTL.MaDonTXL.Value.ToString().Insert(cttttl.TTTL.MaDonTXL.Value.ToString().Length - 2, "-");
                }
                else
                    if (cttttl.TTTL.MaDonTBC != null)
                    {
                        _dontbc = _cDonTBC.Get(cttttl.TTTL.MaDonTBC.Value);
                        txtMaDonCu.Text = "TBC" + cttttl.TTTL.MaDonTBC.Value.ToString().Insert(cttttl.TTTL.MaDonTBC.Value.ToString().Length - 2, "-");
                    }
            txtMaCTTTTL.Text = cttttl.MaCTTTTL.ToString().Insert(cttttl.MaCTTTTL.ToString().Length - 2, "-");
            txtTCHC.Text = cttttl.TCHC;

            txtDanhBo.Text = cttttl.DanhBo;
            txtHopDong.Text = cttttl.HopDong;
            txtLoTrinh.Text = cttttl.LoTrinh;
            txtHoTen.Text = cttttl.HoTen;
            txtDiaChi.Text = cttttl.DiaChi;
            txtGiaBieu.Text = cttttl.GiaBieu;
            txtDinhMuc.Text = cttttl.DinhMuc;
            txtVeViec.Text = cttttl.VeViec;
            txtNoiDung.Text = cttttl.NoiDung;
            txtNoiNhan.Text = cttttl.NoiNhan;

            dgvLichSuTTTL.DataSource = _cTTTL.GetLichSuCTByDanhBo(cttttl.DanhBo);
            dgvGhiChu.DataSource = _cGhiChuCTTTTL.GetDS(cttttl.MaCTTTTL);
        }

        public void Clear()
        {
            txtMaDonCu.Text = "";
            txtMaCTTTTL.Text = "";
            txtTCHC.Text = "";
            ///
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            ///
            txtVeViec.Text = "";
            txtNoiDung.Text = "";
            txtNoiNhan.Text = "";

            _dontu_ChiTiet = null;
            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            _cttttl = null;
            _MaCTTTTL = -1;
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
                        {
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            txtDanhBo.Text = _dontxl.DanhBo;
                            txtHopDong.Text =_dontxl.HopDong;
                            txtLoTrinh.Text = _dontxl.MLT;
                            txtHoTen.Text = _dontxl.HoTen;
                            txtDiaChi.Text = _dontxl.DiaChi;
                            txtGiaBieu.Text = _dontxl.GiaBieu;
                            txtDinhMuc.Text = _dontxl.DinhMuc;
                        }
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
                            {
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                txtDanhBo.Text = _dontbc.DanhBo;
                                txtHopDong.Text = _dontbc.HopDong;
                                txtLoTrinh.Text = _dontbc.MLT;
                                txtHoTen.Text = _dontbc.HoTen;
                                txtDiaChi.Text = _dontbc.DiaChi;
                                txtGiaBieu.Text = _dontbc.GiaBieu;
                                txtDinhMuc.Text = _dontbc.DinhMuc;
                            }
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
                            {
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                txtDanhBo.Text = _dontkh.DanhBo;
                                txtHopDong.Text = _dontkh.HopDong;
                                txtLoTrinh.Text = _dontkh.MLT;
                                txtHoTen.Text = _dontkh.HoTen;
                                txtDiaChi.Text = _dontkh.DiaChi;
                                txtGiaBieu.Text = _dontkh.GiaBieu;
                                txtDinhMuc.Text = _dontkh.DinhMuc;
                            }
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
                    _dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(MaDons[0]), int.Parse(MaDons[1]));
                }
                else
                {
                    _dontu_ChiTiet = _cDonTu.get(int.Parse(MaDon)).DonTu_ChiTiets.SingleOrDefault();
                }
                //
                if (_dontu_ChiTiet != null)
                {
                    if (_dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count() == 1)
                        txtMaDonMoi.Text = _dontu_ChiTiet.MaDon.Value.ToString();
                    else
                        txtMaDonMoi.Text = _dontu_ChiTiet.MaDon.Value.ToString() + "." + _dontu_ChiTiet.STT.Value.ToString();

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
                _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                if (_hoadon != null)
                {
                    LoadTTKH(_hoadon);
                }
                else
                {
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtMaCTTTTL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && _cTTTL.CheckExist_CT(decimal.Parse(txtMaCTTTTL.Text.Trim().Replace("-", ""))) == true)
            {
                _cttttl = _cTTTL.GetCT(decimal.Parse(txtMaCTTTTL.Text.Trim().Replace("-", "")));
                LoadTTTL(_cttttl);
            }
        }

        private void cmbVeViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVeViec.SelectedIndex != -1)
            {
                TTTL_VeViec vv = (TTTL_VeViec)cmbVeViec.SelectedItem;
                txtVeViec.Text = vv.TenVV;
                txtNoiDung.Text = vv.NoiDung;
                if (txtMaDonMoi.Text.Trim() != "")
                    txtNoiNhan.Text = vv.NoiNhan + " (" + txtMaDonMoi.Text.Trim() + ")";
                else
                if (txtMaDonCu.Text.Trim() != "")
                    txtNoiNhan.Text = vv.NoiNhan + " (" + txtMaDonCu.Text.Trim() + ")";
                else
                    if (txtMaDonMoi.Text.Trim() != "")
                        txtNoiNhan.Text = vv.NoiNhan + " (" + txtMaDonMoi.Text.Trim() + ")";
            }
            else
            {
                txtVeViec.Text = "";
                txtNoiDung.Text = "";
                txtNoiNhan.Text = "";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (txtVeViec.Text.Trim() == "" || txtNoiDung.Text.Trim() == "" || txtNoiNhan.Text.Trim() == "")
                    {
                        MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    TTTL_ChiTiet cttttl = new TTTL_ChiTiet();

                    if (_dontu_ChiTiet != null)
                    {
                        if (_cTTTL.checkExist(_dontu_ChiTiet.MaDon.Value) == false)
                        {
                            TTTL tttl = new TTTL();
                            tttl.MaDonMoi = _dontu_ChiTiet.MaDon.Value;
                            _cTTTL.Them(tttl);
                        }
                        if (_cTTTL.checkExist_ChiTiet(_dontu_ChiTiet.MaDon.Value, txtDanhBo.Text.Trim(), DateTime.Now) == true)
                        {
                            if (MessageBox.Show("Danh Bộ này đã được Lập Thư\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                return;
                        }
                        cttttl.MaTTTL = _cTTTL.get(_dontu_ChiTiet.MaDon.Value).MaTTTL;
                    }
                    else
                        if (_dontkh != null)
                        {
                            if (_cTTTL.CheckExist("TKH", _dontkh.MaDon) == false)
                            {
                                TTTL tttl = new TTTL();
                                tttl.MaDon = _dontkh.MaDon;
                                _cTTTL.Them(tttl);
                            }
                            if (_cTTTL.CheckExist_CT("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim(), DateTime.Now) == true)
                            {
                                if (MessageBox.Show("Danh Bộ này đã được Lập Thư\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    return;
                            }
                            cttttl.MaTTTL = _cTTTL.Get("TKH", _dontkh.MaDon).MaTTTL;
                        }
                        else
                            if (_dontxl != null)
                            {
                                if (_cTTTL.CheckExist("TXL", _dontxl.MaDon) == false)
                                {
                                    TTTL tttl = new TTTL();
                                    tttl.MaDonTXL = _dontxl.MaDon;
                                    _cTTTL.Them(tttl);
                                }
                                if (_cTTTL.CheckExist_CT("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim(), DateTime.Now) == true)
                                {
                                    if (MessageBox.Show("Danh Bộ này đã được Lập Thư\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                        return;
                                }
                                cttttl.MaTTTL = _cTTTL.Get("TXL", _dontxl.MaDon).MaTTTL;
                            }
                            else
                                if (_dontbc != null)
                                {
                                    if (_cTTTL.CheckExist("TBC", _dontbc.MaDon) == false)
                                    {
                                        TTTL tttl = new TTTL();
                                        tttl.MaDonTBC = _dontbc.MaDon;
                                        _cTTTL.Them(tttl);
                                    }
                                    if (_cTTTL.CheckExist_CT("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim(), DateTime.Now) == true)
                                    {
                                        if (MessageBox.Show("Danh Bộ này đã được Lập Thư\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                            return;
                                    }
                                    cttttl.MaTTTL = _cTTTL.Get("TBC", _dontbc.MaDon).MaTTTL;
                                }
                                else
                                {
                                    MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                    cttttl.DanhBo = txtDanhBo.Text.Trim();
                    cttttl.HopDong = txtHopDong.Text.Trim();
                    cttttl.LoTrinh = txtLoTrinh.Text.Trim();
                    cttttl.HoTen = txtHoTen.Text.Trim();
                    cttttl.DiaChi = txtDiaChi.Text.Trim();
                    cttttl.GiaBieu = txtGiaBieu.Text.Trim();
                    cttttl.DinhMuc = txtDinhMuc.Text.Trim();
                    if (_hoadon != null)
                    {
                        cttttl.Dot = _hoadon.DOT.ToString();
                        cttttl.Ky = _hoadon.KY.ToString();
                        cttttl.Nam = _hoadon.NAM.ToString();
                        cttttl.Phuong = _hoadon.Phuong;
                        cttttl.Quan = _hoadon.Quan;
                    }
                    cttttl.VeViec = txtVeViec.Text.Trim();
                    cttttl.NoiDung = txtNoiDung.Text;
                    cttttl.NoiNhan = txtNoiNhan.Text.Trim();

                    ///Ký Tên
                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                        cttttl.ChucVu = "GIÁM ĐỐC";
                    else
                        cttttl.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                    cttttl.NguoiKy = bangiamdoc.HoTen.ToUpper();
                    cttttl.ThuDuocKy = true;

                    if (_cTTTL.ThemCT(cttttl))
                    {
                        if (_dontu_ChiTiet != null)
                            _cDonTu.Them_LichSu("TTTL", "Đã Gửi Thư Trả Lời, "+cttttl.VeViec, _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value);
                        MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        txtMaDonCu.Focus();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (_cttttl != null)
                    {
                        _cttttl.TCHC = txtTCHC.Text.Trim();
                        _cttttl.DanhBo = txtDanhBo.Text.Trim();
                        _cttttl.HopDong = txtHopDong.Text.Trim();
                        _cttttl.LoTrinh = txtLoTrinh.Text.Trim();
                        _cttttl.HoTen = txtHoTen.Text.Trim();
                        _cttttl.DiaChi = txtDiaChi.Text.Trim();
                        _cttttl.GiaBieu = txtGiaBieu.Text.Trim();
                        _cttttl.DinhMuc = txtDinhMuc.Text.Trim();
                        if (_hoadon != null)
                        {
                            _cttttl.Dot = _hoadon.DOT.ToString();
                            _cttttl.Ky = _hoadon.KY.ToString();
                            _cttttl.Nam = _hoadon.NAM.ToString();
                            _cttttl.Phuong = _hoadon.Phuong;
                            _cttttl.Quan = _hoadon.Quan;
                        }
                        _cttttl.VeViec = txtVeViec.Text.Trim();
                        _cttttl.NoiDung = txtNoiDung.Text;
                        _cttttl.NoiNhan = txtNoiNhan.Text.Trim();

                        ///Ký Tên
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            _cttttl.ChucVu = "GIÁM ĐỐC";
                        else
                            _cttttl.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        _cttttl.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        _cttttl.ThuDuocKy = true;

                        if (_cTTTL.SuaCT(_cttttl))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
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
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (_cttttl != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_cTTTL.XoaCT(_cttttl))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
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
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCapNhatGhiChu_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (_cttttl != null)
                    {
                        TTTL_GhiChu ghichu = new TTTL_GhiChu();
                        ghichu.NgayGhiChu = dateGhiChu.Value;
                        ghichu.GhiChu = txtGhiChu.Text.Trim();
                        ghichu.MaCTTTTL = _cttttl.MaCTTTTL;
                        if (_cGhiChuCTTTTL.Them(ghichu))
                            dgvGhiChu.DataSource = _cGhiChuCTTTTL.GetDS(_cttttl.MaCTTTTL);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvGhiChu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvGhiChu.CurrentCell = dgvGhiChu.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvGhiChu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && (_dontkh != null))
            {
                contextMenuStrip1.Show(dgvGhiChu, new Point(e.X, e.Y));
            }
        }

        private void dgvLichSuTTTL_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLichSuTTTL.Columns[e.ColumnIndex].Name == "MaCTTTTL" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvLichSuTTTL.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null && e.Value.ToString().Length > 2)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (_cGhiChuCTTTTL.Xoa(_cGhiChuCTTTTL.Get(int.Parse(dgvGhiChu.CurrentRow.Cells["ID"].Value.ToString()))))
                        {
                            dgvGhiChu.DataSource = _cGhiChuCTTTTL.GetDS(_cttttl.MaCTTTTL);
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_cttttl != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                //dr["SoPhieu"] = _cttttl.MaCTTTTL.ToString().Insert(_cttttl.MaCTTTTL.ToString().Length - 2, "-");
                dr["LoTrinh"] = _cttttl.LoTrinh;
                dr["HoTen"] = _cttttl.HoTen;
                dr["DiaChi"] = _cttttl.DiaChi;
                if (!string.IsNullOrEmpty(_cttttl.DanhBo)&&_cttttl.DanhBo.Length==11)
                    dr["DanhBo"] = _cttttl.DanhBo.Insert(7, " ").Insert(4, " ");

                dr["HopDong"] = _cttttl.HopDong;
                dr["GiaBieu"] = _cttttl.GiaBieu;
                dr["DinhMuc"] = _cttttl.DinhMuc;
                if (_cttttl.TTTL.MaDonMoi != null)
                    dr["NgayNhanDon"] = _cDonTu.get(_cttttl.TTTL.MaDonMoi.Value).CreateDate.Value.ToString("dd/MM/yyyy");
                else
                if (_cttttl.TTTL.MaDon != null)
                    dr["NgayNhanDon"] = _cttttl.TTTL.DonKH.CreateDate.Value.ToString("dd/MM/yyyy");
                else
                    if (_cttttl.TTTL.MaDonTXL != null)
                        dr["NgayNhanDon"] = _cttttl.TTTL.DonTXL.CreateDate.Value.ToString("dd/MM/yyyy");
                    else
                        if (_cttttl.TTTL.MaDonTBC != null)
                            dr["NgayNhanDon"] = _cttttl.TTTL.DonTBC.CreateDate.Value.ToString("dd/MM/yyyy");

                dr["VeViec"] = _cttttl.VeViec;
                dr["NoiDung"] = _cttttl.NoiDung;
                dr["NoiNhan"] = _cttttl.NoiNhan + "\r\nTTL" + _cttttl.MaCTTTTL.ToString().Insert(_cttttl.MaCTTTTL.ToString().Length - 2, "-");
                dr["ChucVu"] = _cttttl.ChucVu;
                dr["NguoiKy"] = _cttttl.NguoiKy;

                dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                if (!string.IsNullOrEmpty(_cttttl.DanhBo))
                {
                    rptThaoThuTraLoi rpt = new rptThaoThuTraLoi();
                    rpt.SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.Show();
                }
                else
                {
                    rptThaoThuTraLoi_KhongDanhBo rpt = new rptThaoThuTraLoi_KhongDanhBo();
                    rpt.SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.Show();
                }
            }
        }

        


    }
}

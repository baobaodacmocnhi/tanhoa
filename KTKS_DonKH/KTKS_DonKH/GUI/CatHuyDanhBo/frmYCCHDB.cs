using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.CatHuyDanhBo;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmYCCHDB : Form
    {
        string _mnu = "mnuPhieuCHDB";
        CDonTu _cDonTu = new CDonTu();
        CThuTien _cThuTien = new CThuTien();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CDocSo _cDocSo = new CDocSo();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CCHDB _cCHDB = new CCHDB();
        CCHDB_LyDo _cLyDoCHDB = new CCHDB_LyDo();

        DonTu_ChiTiet _dontu_ChiTiet = null;
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        CHDB_Phieu _ycchdb = null;
        decimal _MaYCCHDB = -1;

        public frmYCCHDB()
        {
            InitializeComponent();
        }

        public frmYCCHDB(decimal MaYCCHDB)
        {
            _MaYCCHDB = MaYCCHDB;
            InitializeComponent();
        }

        private void frmYCCHDB_Load(object sender, EventArgs e)
        {
            cmbLyDo.DataSource = _cLyDoCHDB.GetDS();
            cmbLyDo.DisplayMember = "LyDo";
            cmbLyDo.ValueMember = "LyDo";
            cmbLyDo.SelectedIndex = -1;

            if (_MaYCCHDB !=-1)
            {
                txtMaYCCHDB.Text = _MaYCCHDB.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtMaYCCHDB_KeyPress(sender, arg);
            }
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHopDong.Text = hoadon.HOPDONG;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
        }

        public void LoadPhieuCHDB(CHDB_Phieu phieuCHDB)
        {
            if (phieuCHDB.CHDB.MaDonMoi != null)
            {
                _dontu_ChiTiet = _cDonTu.get_ChiTiet(phieuCHDB.CHDB.MaDonMoi.Value, phieuCHDB.STT.Value);
                txtMaDonMoi.Text = phieuCHDB.CHDB.MaDonMoi.ToString();
            }
            else
            if (phieuCHDB.CHDB.MaDon != null)
            {
                _dontkh = _cDonKH.Get(phieuCHDB.CHDB.MaDon.Value);
                txtMaDonCu.Text = phieuCHDB.CHDB.MaDon.ToString().Insert(phieuCHDB.CHDB.MaDon.ToString().Length - 2, "-");
            }
            else
                if (phieuCHDB.CHDB.MaDonTXL != null)
            {
                _dontxl = _cDonTXL.Get(phieuCHDB.CHDB.MaDonTXL.Value);
                txtMaDonCu.Text = "TXL" + phieuCHDB.CHDB.MaDonTXL.ToString().Insert(phieuCHDB.CHDB.MaDonTXL.ToString().Length - 2, "-");
            }
            else
                    if (phieuCHDB.CHDB.MaDonTBC != null)
                {
                    _dontbc = _cDonTBC.Get(phieuCHDB.CHDB.MaDonTBC.Value);
                    txtMaDonCu.Text = "TBC" + phieuCHDB.CHDB.MaDonTBC.ToString().Insert(phieuCHDB.CHDB.MaDonTBC.ToString().Length - 2, "-");
                }

            txtMaYCCHDB.Text = phieuCHDB.MaYCCHDB.ToString().Insert(phieuCHDB.MaYCCHDB.ToString().Length - 2, "-");
            txtTCHC.Text = phieuCHDB.TCHC;
            ///
            txtDanhBo.Text = phieuCHDB.DanhBo;
            txtHopDong.Text = phieuCHDB.HopDong;
            txtHoTen.Text = phieuCHDB.HoTen;
            txtDiaChi.Text = phieuCHDB.DiaChi;
            ///
            cmbLyDo.SelectedValue = phieuCHDB.LyDo;
            txtSoTien.Text = phieuCHDB.SoTien.ToString();
            txtHieuLucKy.Text = phieuCHDB.HieuLucKy;
            txtGhiChu.Text = phieuCHDB.GhiChuLyDo;
            ///
            if (phieuCHDB.CatTamNutBit)
            {
                chkCatTamNutBit.Checked = true;
                dateCatTamNutBit.Value = phieuCHDB.NgayCatTamNutBit.Value;
            }
            else
            {
                chkCatTamNutBit.Checked = false;
                dateCatTamNutBit.Value = DateTime.Now;
            }
            ///
            if (phieuCHDB.NoiDungTroNgai != null)
            {
                chkTroNgai.Checked = true;
                dateTroNgai.Value = phieuCHDB.NgayTroNgai.Value;
                cmbNoiDung.SelectedItem = phieuCHDB.NoiDungTroNgai;
            }
            else
            {
                chkTroNgai.Checked = false;
                dateTroNgai.Value = DateTime.Now;
                cmbNoiDung.SelectedIndex = -1;
            }
        }

        public void Clear()
        {
            txtMaDonCu.Text = "";
            txtMaYCCHDB.Text = "";
            txtTCHC.Text = "";
            ///
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            ///
            cmbLyDo.SelectedIndex = -1;
            txtSoTien.Text = "";
            txtGhiChu.Text = "";
            txtHieuLucKy.Text = "";
            ///
            chkCatTamNutBit.Checked = false;
            chkTroNgai.Checked = false;
            ///
            _dontu_ChiTiet = null;
            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            _ycchdb = null;
            _MaYCCHDB = -1;
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
                    _dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(MaDons[0]), int.Parse(MaDons[1]));
                }
                else
                {
                    _dontu_ChiTiet = _cDonTu.get(int.Parse(MaDon)).DonTu_ChiTiets.SingleOrDefault();
                }
                //
                if (_dontu_ChiTiet != null)
                {
                    if (_dontu_ChiTiet.DonTu.SoCongVan == "")
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
                    //string ThongTin;
                    //if (_cCHDB.CheckCHDBbyDanhBo(_hoadon.DANHBA, out ThongTin))
                    //    MessageBox.Show("Danh Bộ này đã lập " + ThongTin, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaYCCHDB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaYCCHDB.Text.Trim() != "")
            {
                _ycchdb = _cCHDB.GetPhieuHuy(decimal.Parse(txtMaYCCHDB.Text.Trim().Replace("-", "")));
                if (_ycchdb != null)
                {
                    LoadPhieuCHDB(_ycchdb);
                }
                else
                    MessageBox.Show("Số Phiếu này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbLyDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLyDo.SelectedIndex != -1)
            {
                if (cmbLyDo.SelectedValue.ToString() == "Nợ Tiền Gian Lận Nước" || cmbLyDo.SelectedValue.ToString() == "Không Thanh Toán Tiền Bồi Thường ĐHN")
                    txtSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", 1283641);
            }
            else
            {
                txtSoTien.Text = "";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    CHDB_Phieu ycchdb = new CHDB_Phieu();

                    if (_dontu_ChiTiet != null)
                    {
                        if (_cCHDB.checkExist(_dontu_ChiTiet.MaDon.Value) == false)
                        {
                            CHDB chdb = new CHDB();
                            chdb.MaDonMoi = _dontu_ChiTiet.MaDon.Value;
                            _cCHDB.ThemCHDB(chdb);
                        }
                        if (_cCHDB.checkExist_PhieuHuy(_dontu_ChiTiet.MaDon.Value, txtDanhBo.Text.Trim()) == true)
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Phiếu Hủy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ycchdb.MaCHDB = _cCHDB.get(_dontu_ChiTiet.MaDon.Value).MaCHDB;
                        ycchdb.STT = _dontu_ChiTiet.STT;
                    }
                    else
                        if (_dontkh != null)
                        {
                            if (_cCHDB.CheckExist_CHDB("TKH", _dontkh.MaDon) == false)
                            {
                                CHDB chdb = new CHDB();
                                chdb.MaDon = _dontkh.MaDon;
                                _cCHDB.ThemCHDB(chdb);
                            }
                            if (_cCHDB.CheckExist_PhieuHuy("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim()) == true)
                            {
                                MessageBox.Show("Danh Bộ này đã được Lập Phiếu Hủy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            ycchdb.MaCHDB = _cCHDB.GetCHDB("TKH", _dontkh.MaDon).MaCHDB;
                        }
                        else
                            if (_dontxl != null)
                            {
                                if (_cCHDB.CheckExist_CHDB("TXL", _dontxl.MaDon) == false)
                                {
                                    CHDB chdb = new CHDB();
                                    chdb.MaDonTXL = _dontxl.MaDon;
                                    _cCHDB.ThemCHDB(chdb);
                                }
                                if (_cCHDB.CheckExist_PhieuHuy("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim()) == true)
                                {
                                    MessageBox.Show("Danh Bộ này đã được Lập Phiếu Hủy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                ycchdb.MaCHDB = _cCHDB.GetCHDB("TXL", _dontxl.MaDon).MaCHDB;
                            }
                            else
                                if (_dontbc != null)
                                {
                                    if (_cCHDB.CheckExist_CHDB("TBC", _dontbc.MaDon) == false)
                                    {
                                        CHDB chdb = new CHDB();
                                        chdb.MaDonTBC = _dontbc.MaDon;
                                        _cCHDB.ThemCHDB(chdb);
                                    }
                                    if (_cCHDB.CheckExist_PhieuHuy("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim()) == true)
                                    {
                                        MessageBox.Show("Danh Bộ này đã được Lập Phiếu Hủy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    ycchdb.MaCHDB = _cCHDB.GetCHDB("TBC", _dontbc.MaDon).MaCHDB;
                                }
                                else
                                {
                                    MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                    ycchdb.DanhBo = txtDanhBo.Text.Trim();
                    ycchdb.HopDong = txtHopDong.Text.Trim();
                    ycchdb.HoTen = txtHoTen.Text.Trim();
                    ycchdb.DiaChi = txtDiaChi.Text.Trim();
                    if (_hoadon != null)
                    {
                        ycchdb.Dot = _hoadon.DOT.ToString();
                        ycchdb.Ky = _hoadon.KY.ToString();
                        ycchdb.Nam = _hoadon.NAM.ToString();
                        ycchdb.Phuong = _hoadon.Phuong;
                        ycchdb.Quan = _hoadon.Quan;
                    }
                    ycchdb.LyDo = cmbLyDo.SelectedValue.ToString();
                    ycchdb.GhiChuLyDo = txtGhiChu.Text.Trim();
                    if (txtSoTien.Text.Trim() != "")
                        ycchdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                    ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                    ///Ký Tên
                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                        ycchdb.ChucVu = "GIÁM ĐỐC";
                    else
                        ycchdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                    ycchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                    ycchdb.PhieuDuocKy = true;

                    if (_cCHDB.ThemPhieuHuy(ycchdb))
                    {
                        if (_dontu_ChiTiet != null)
                            _cDonTu.Them_LichSu("Cắt Hủy", "Đã Lập Phiếu Hủy", _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value);
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (_ycchdb != null)
                    {
                        _ycchdb.TCHC = txtTCHC.Text.Trim();
                        _ycchdb.DanhBo = txtDanhBo.Text.Trim();
                        _ycchdb.HopDong = txtHopDong.Text.Trim();
                        _ycchdb.HoTen = txtHoTen.Text.Trim();
                        _ycchdb.DiaChi = txtDiaChi.Text.Trim();
                        if (_hoadon != null)
                        {
                            _ycchdb.Dot = _hoadon.DOT.ToString();
                            _ycchdb.Ky = _hoadon.KY.ToString();
                            _ycchdb.Nam = _hoadon.NAM.ToString();
                            _ycchdb.Phuong = _hoadon.Phuong;
                            _ycchdb.Quan = _hoadon.Quan;
                        }

                        _ycchdb.LyDo = cmbLyDo.SelectedValue.ToString();
                        _ycchdb.GhiChuLyDo = txtGhiChu.Text.Trim();
                        if (txtSoTien.Text.Trim() != "")
                            _ycchdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                        else
                            _ycchdb.SoTien = null;
                        _ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                        ///
                        if (chkCatTamNutBit.Checked)
                        {
                            _ycchdb.CatTamNutBit = true;
                            _ycchdb.NgayCatTamNutBit = dateCatTamNutBit.Value;
                        }
                        else
                        {
                            _ycchdb.CatTamNutBit = false;
                            _ycchdb.NgayCatTamNutBit = null;
                        }
                        ///
                        if (chkTroNgai.Checked)
                        {
                            _ycchdb.NgayTroNgai = dateTroNgai.Value;
                            _ycchdb.NoiDungTroNgai = cmbNoiDung.SelectedItem.ToString();
                            _ycchdb.CreateDate_NgayTroNgai = DateTime.Now;
                        }
                        else
                        {
                            _ycchdb.NgayTroNgai = null;
                            _ycchdb.NoiDungTroNgai = null;
                            _ycchdb.CreateDate_NgayTroNgai = null;
                        }
                        if (_cCHDB.SuaPhieuHuy(_ycchdb))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMaDonCu.Focus();
                        }
                    }
                    else
                        MessageBox.Show("Chưa chọn Phiếu YCCHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (_ycchdb != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_cCHDB.XoaPhieuHuy(_ycchdb))
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
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                if (_ycchdb != null)
                {
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    DataRow dr = dsBaoCao.Tables["CHDB_Phieu"].NewRow();

                    dr["SoPhieu"] = _ycchdb.MaYCCHDB.ToString().Insert(_ycchdb.MaYCCHDB.ToString().Length - 2, "-");
                    dr["HieuLucKy"] = _ycchdb.HieuLucKy;
                    dr["Dot"] = _ycchdb.Dot;
                    dr["HoTen"] = _ycchdb.HoTen;
                    dr["DiaChi"] = _ycchdb.DiaChi;
                    dr["DanhBo"] = _ycchdb.DanhBo.Insert(7, " ").Insert(4, " ");
                    dr["HopDong"] = _ycchdb.HopDong;

                    if (_ycchdb.LyDo == "Vấn Đề Khác")
                        dr["LyDo"] = "";
                    else
                        dr["LyDo"] = _ycchdb.LyDo + ". ";

                    if (_ycchdb.GhiChuLyDo != "")
                        dr["LyDo"] += _ycchdb.GhiChuLyDo + ". ";
                    if (_ycchdb.SoTien.ToString() != "")
                        dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", _ycchdb.SoTien);

                    dr["ChucVu"] = _ycchdb.ChucVu;
                    dr["NguoiKy"] = _ycchdb.NguoiKy;

                    if (_ycchdb.CHDB.MaDonMoi != null)
                        dr["MaDon"] = _ycchdb.CHDB.MaDonMoi.ToString();
                    else
                    if (_ycchdb.CHDB.MaDon != null)
                        dr["MaDon"] = "TKH" + _ycchdb.CHDB.MaDon.ToString().Insert(_ycchdb.CHDB.MaDon.ToString().Length - 2, "-");
                    else
                        if (_ycchdb.CHDB.MaDonTXL != null)
                            dr["MaDon"] = "TXL" + _ycchdb.CHDB.MaDonTXL.ToString().Insert(_ycchdb.CHDB.MaDonTXL.ToString().Length - 2, "-");
                        else
                            if (_ycchdb.CHDB.MaDonTBC != null)
                                dr["MaDon"] = "TBC" + _ycchdb.CHDB.MaDonTBC.ToString().Insert(_ycchdb.CHDB.MaDonTBC.ToString().Length - 2, "-");

                    dsBaoCao.Tables["CHDB_Phieu"].Rows.Add(dr);

                    //rptPhieuCHDBx2 rpt = new rptPhieuCHDBx2();
                    //for (int j = 0; j < rpt.Subreports.Count; j++)
                    //{
                    //    rpt.Subreports[j].SetDataSource(dsBaoCao);
                    //}
                    rptPhieuCHDB rpt = new rptPhieuCHDB();
                    rpt.SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.ShowDialog();
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoTien_Leave(object sender, EventArgs e)
        {
            if (txtSoTien.Text.Trim() != "")
                txtSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
        }

        private void chkCatTamNutBit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCatTamNutBit.Checked)
            {
                groupBoxCatTamNutBit.Enabled = true;
            }
            else
            {
                groupBoxCatTamNutBit.Enabled = false;
            }
        }

        private void chkNgayXuLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTroNgai.Checked)
            {
                dateTroNgai.Enabled = true;
                cmbNoiDung.Enabled = true;
            }
            else
            {
                dateTroNgai.Enabled = false;
                cmbNoiDung.Enabled = false;
            }
        }

       

    }
}

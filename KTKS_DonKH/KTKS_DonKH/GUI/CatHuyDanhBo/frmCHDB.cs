using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.CatHuyDanhBo;
using KTKS_DonKH.GUI.BaoCao;
using System.Globalization;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmCHDB : Form
    {
        string _mnu = "mnuCHDB";
        CDonTu _cDonTu = new CDonTu();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CCHDB _cCHDB = new CCHDB();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CCHDB_LyDo _cLyDoCHDB = new CCHDB_LyDo();
        CCHDB_NoiDungXuLy _cNoiDungXuLyCHDB = new CCHDB_NoiDungXuLy();
        CKTXM _cKTXM = new CKTXM();

        DonTu_ChiTiet _dontu_ChiTiet = null;
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        CHDB_ChiTietCatHuy _ctchdb = null;
        CHDB_ChiTietCatTam _ctctdb = null;
        decimal _MaCTCHDB = -1;

        public frmCHDB()
        {
            InitializeComponent();
        }

        public frmCHDB(decimal MaCTCHDB)
        {
            _MaCTCHDB = MaCTCHDB;
            InitializeComponent();
        }

        private void frmCHDB_Load(object sender, EventArgs e)
        {
            dgvGhiChu.AutoGenerateColumns = false;
            dgvLichSuCHDB.AutoGenerateColumns = false;
            dgvGhiChuDocSo.AutoGenerateColumns = false;

            cmbLyDo.DataSource = _cLyDoCHDB.GetDS();
            cmbLyDo.DisplayMember = "LyDo";
            cmbLyDo.ValueMember = "LyDo";
            cmbLyDo.SelectedIndex = -1;

            DataTable dt1 = _cCHDB.GetDSNoiDungGhiChu();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (DataRow item in dt1.Rows)
            {
                auto1.Add(item["NoiDung"].ToString());
            }
            txtNoiDungGhiChu.AutoCompleteCustomSource = auto1;

            //DataTable dt2 = _cCHDB.GetDSNoiNhanGhiChu();
            //AutoCompleteStringCollection auto2 = new AutoCompleteStringCollection();
            //foreach (DataRow item in dt2.Rows)
            //{
            //    auto2.Add(item["NoiNhan"].ToString());
            //}
            //txtNoiNhanXuLy.AutoCompleteCustomSource = auto2;

            cmbNoiDung.DataSource = _cNoiDungXuLyCHDB.GetDS();
            cmbNoiDung.DisplayMember = "NoiDung";
            cmbNoiDung.ValueMember = "NoiDung";
            cmbNoiDung.SelectedIndex = -1;

            if (_MaCTCHDB != -1)
            {
                txtMaThongBaoCH.Text = _MaCTCHDB.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtMaThongBaoCH_KeyPress(sender, arg);
            }
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHopDong.Text = hoadon.HOPDONG;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
            dgvLichSuCHDB.DataSource = _cCHDB.GetLichSuCHDB(hoadon.DANHBA);
            CheckLichSuCHDB();
            dgvGhiChuDocSo.DataSource = _cDocSo.GetDSGhiChu(hoadon.DANHBA);

            KTXM_ChiTiet ctktxm = null;
            if (_dontu_ChiTiet != null)
            {
                ctktxm = _cKTXM.get_ChiTiet(_dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.DanhBo);
            }
            else
                if (_dontkh != null)
                {
                    ctktxm = _cKTXM.GetCT("TKH", _dontkh.MaDon, _dontkh.DanhBo);
                }
                else
                    if (_dontxl != null)
                    {
                        ctktxm = _cKTXM.GetCT("TXL", _dontxl.MaDon, _dontxl.DanhBo);
                    }
                    else
                        if (_dontbc != null)
                        {
                            ctktxm = _cKTXM.GetCT("TBC", _dontbc.MaDon, _dontbc.DanhBo);
                        }
            if (ctktxm != null)
            {
                cmbViTriDHN1.SelectedItem = ctktxm.ViTriDHN1;
                cmbViTriDHN2.SelectedItem = ctktxm.ViTriDHN2;
            }
        }

        public void LoadCHDB(CHDB_ChiTietCatHuy ctchdb)
        {
            if (ctchdb.CHDB.MaDonMoi != null)
            {
                _dontu_ChiTiet = _cDonTu.get_ChiTiet(ctchdb.CHDB.MaDonMoi.Value, ctchdb.STT.Value);
                txtMaDonMoi.Text = ctchdb.CHDB.MaDonMoi.Value.ToString();
            }
            else
            if (ctchdb.CHDB.MaDon != null)
            {
                _dontkh = _cDonKH.Get(ctchdb.CHDB.MaDon.Value);
                txtMaDonCu.Text = ctchdb.CHDB.MaDon.ToString().Insert(ctchdb.CHDB.MaDon.ToString().Length - 2, "-");
            }
            else
                if (ctchdb.CHDB.MaDonTXL != null)
                {
                    _dontxl = _cDonTXL.Get(ctchdb.CHDB.MaDonTXL.Value);
                    txtMaDonCu.Text = "TXL" + ctchdb.CHDB.MaDonTXL.ToString().Insert(ctchdb.CHDB.MaDonTXL.ToString().Length - 2, "-");
                }
                else
                    if (ctchdb.CHDB.MaDonTBC != null)
                    {
                        _dontbc = _cDonTBC.Get(ctchdb.CHDB.MaDonTBC.Value);
                        txtMaDonCu.Text = "TBC" + ctchdb.CHDB.MaDonTBC.ToString().Insert(ctchdb.CHDB.MaDonTBC.ToString().Length - 2, "-");
                    }
            txtMaThongBaoCH.Text = ctchdb.MaCTCHDB.ToString().Insert(ctchdb.MaCTCHDB.ToString().Length - 2, "-");
            txtTCHC.Text = ctchdb.TCHC;

            if (!string.IsNullOrEmpty(ctchdb.MaCTCTDB.ToString()))
                txtMaThongBaoCT.Text = ctchdb.MaCTCTDB.ToString().Insert(ctchdb.MaCTCTDB.ToString().Length - 2, "-");
            ///
            txtDanhBo.Text = ctchdb.DanhBo;
            txtHopDong.Text = ctchdb.HopDong;
            txtHoTen.Text = ctchdb.HoTen;
            txtDiaChi.Text = ctchdb.DiaChi;

            ///Nội Dung Xử Lý
            cmbLyDo.SelectedValue = ctchdb.LyDo;
            txtNoiDung.Text = ctchdb.NoiDung;
            txtGhiChu.Text = ctchdb.GhiChuLyDo;
            if (ctchdb.SoTien != null)
                txtSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctchdb.SoTien.Value);
            else
                txtSoTien.Text = "";
            txtNoiNhan.Text = ctchdb.NoiNhan;
            cmbViTriDHN1.SelectedItem = ctchdb.ViTriDHN1;
            cmbViTriDHN2.SelectedItem = ctchdb.ViTriDHN2;
            if (ctchdb.NgayXuLy != null)
            {
                chkNgayXuLy.Checked = true;
                dateXuLy.Value = ctchdb.NgayXuLy.Value;
                cmbNoiDung.SelectedValue = ctchdb.NoiDungXuLy;
            }
            else
            {
                chkNgayXuLy.Checked = false;
                dateXuLy.Value = DateTime.Now;
                cmbNoiDung.SelectedIndex = -1;
            }

            dgvGhiChu.DataSource = _cCHDB.GetDSGhiChuByMaCTCHDB(ctchdb.MaCTCHDB);
            dgvLichSuCHDB.DataSource = _cCHDB.GetLichSuCHDB(ctchdb.DanhBo);
            CheckLichSuCHDB();

            ///Đã lấp Phiếu Yêu Cầu CHDB
            if (_cCHDB.CheckExist_PhieuHuyByMaCTCHDB(ctchdb.MaCTCHDB))
            {
                txtHieuLucKy.Text = ctchdb.CHDB_Phieus.Where(itemYCCHDB => itemYCCHDB.MaCTCHDB == ctchdb.MaCTCHDB).OrderByDescending(item => item.CreateDate).First().HieuLucKy;
            }
            else
            {
                txtHieuLucKy.Text = "";
            }
        }

        public void LoadCTDB(CHDB_ChiTietCatTam ctctdb)
        {
            if (ctctdb.CHDB.MaDonMoi != null)
            {
                _dontu_ChiTiet = _cDonTu.get_ChiTiet(ctctdb.CHDB.MaDonMoi.Value, ctctdb.STT.Value);
                txtMaDonMoi.Text = ctctdb.CHDB.MaDonMoi.ToString();
            }
            else
            if (ctctdb.CHDB.MaDon != null)
            {
                _dontkh = _cDonKH.Get(ctctdb.CHDB.MaDon.Value);
                txtMaDonCu.Text = ctctdb.CHDB.MaDon.ToString().Insert(ctctdb.CHDB.MaDon.ToString().Length - 2, "-");
            }
            else
                if (ctctdb.CHDB.MaDonTXL != null)
                {
                    _dontxl = _cDonTXL.Get(ctctdb.CHDB.MaDonTXL.Value);
                    txtMaDonCu.Text = "TXL" + ctctdb.CHDB.MaDonTXL.ToString().Insert(ctctdb.CHDB.MaDonTXL.ToString().Length - 2, "-");
                }
                else
                    if (ctctdb.CHDB.MaDonTBC != null)
                    {
                        _dontbc = _cDonTBC.Get(ctctdb.CHDB.MaDonTBC.Value);
                        txtMaDonCu.Text = "TBC" + ctctdb.CHDB.MaDonTBC.ToString().Insert(ctctdb.CHDB.MaDonTBC.ToString().Length - 2, "-");
                    }
            txtMaThongBaoCT.Text = ctctdb.MaCTCTDB.ToString().Insert(ctctdb.MaCTCTDB.ToString().Length - 2, "-");

            txtDanhBo.Text = ctctdb.DanhBo;
            txtHopDong.Text = ctctdb.HopDong;
            txtHoTen.Text = ctctdb.HoTen;
            txtDiaChi.Text = ctctdb.DiaChi;

            ///Nguyên Nhân Xử Lý
            cmbLyDo.SelectedValue = ctctdb.LyDo;
            txtGhiChu.Text = ctctdb.GhiChuLyDo;
            if (ctctdb.SoTien != null)
                txtSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctctdb.SoTien.Value);
            else
                txtSoTien.Text = "";
        }

        public void Clear()
        {
            txtMaDonCu.Text = "";
            txtMaDonMoi.Text = "";
            txtMaThongBaoCH.Text = "";
            txtMaThongBaoCT.Text = "";
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
            cmbNoiDung.SelectedIndex = -1;
            txtNoiNhan.Text = "";
            dateXuLy.Value = DateTime.Now;
            chkNgayXuLy.Checked = false;
            ///
            dateLap.Value = DateTime.Now;
            txtNoiDungGhiChu.Text = "";
            ///
            txtHieuLucKy.Text = "";
            _dontu_ChiTiet = null;
            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            _ctchdb = null;
            _ctctdb = null;
            _MaCTCHDB = -1;
            dgvGhiChu.DataSource = null;
            dgvLichSuCHDB.DataSource = null;
        }

        public void CheckLichSuCHDB()
        {
            foreach (DataGridViewRow item in dgvLichSuCHDB.Rows)
                if (item.Cells["Loai"].Value.ToString() != "Phiếu Hủy" && (item.Cells["NgayXuLy"].Value == null || string.IsNullOrEmpty(item.Cells["NgayXuLy"].Value.ToString())))
                    MessageBox.Show("Có Thông Báo chưa xử lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaThongBaoCH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaThongBaoCH.Text.Trim() != "")
            {
                _ctchdb = _cCHDB.GetCTCHDB(decimal.Parse(txtMaThongBaoCH.Text.Trim().Replace("-", "")));
                if (_ctchdb != null)
                {
                    LoadCHDB(_ctchdb);
                }
                else
                    MessageBox.Show("Mã Thông Báo này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaThongBaoCT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                _ctctdb = _cCHDB.GetCTCTDB(decimal.Parse(txtMaThongBaoCT.Text.Trim().Replace("-", "")));
                if (_ctctdb != null)
                {
                    LoadCTDB(_ctctdb);
                }
                else
                    MessageBox.Show("Mã Thông Báo này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cmbLyDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLyDo.SelectedIndex != -1)
            {
                CHDB_LyDo vv = (CHDB_LyDo)cmbLyDo.SelectedItem;
                txtNoiDung.Text = vv.NoiDung;
                if (txtMaDonMoi.Text.Trim() != "")
                    txtNoiNhan.Text = vv.NoiNhan + "\r\n(" + txtMaDonMoi.Text.Trim() + ")";
                else
                    if (txtMaDonCu.Text.Trim() != "")
                        txtNoiNhan.Text = vv.NoiNhan + "\r\n(" + txtMaDonCu.Text.Trim() + ")";

                if (vv.SoTien != null)
                    txtSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", vv.SoTien);
            }
            else
            {
                txtNoiDung.Text = "";
                txtNoiNhan.Text = "";
                txtSoTien.Text = "";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (cmbLyDo.SelectedIndex == -1)
                    {
                        MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    CHDB_ChiTietCatHuy ctchdb = new CHDB_ChiTietCatHuy();

                    if (_dontu_ChiTiet != null)
                    {
                        if (_cCHDB.checkExist(_dontu_ChiTiet.MaDon.Value) == false)
                        {
                            CHDB chdb = new CHDB();
                            chdb.MaDonMoi = _dontu_ChiTiet.MaDon.Value;
                            _cCHDB.ThemCHDB(chdb);
                        }
                        if (_cCHDB.checkExist_CatHuy(_dontu_ChiTiet.MaDon.Value, txtDanhBo.Text.Trim()) == true)
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Cắt Hủy Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ctchdb.MaCHDB = _cCHDB.get(_dontu_ChiTiet.MaDon.Value).MaCHDB;
                        ctchdb.STT = _dontu_ChiTiet.STT;
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
                            if (_cCHDB.CheckExist_CTCHDB("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim()) == true)
                            {
                                MessageBox.Show("Danh Bộ này đã được Lập Cắt Hủy Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            ctchdb.MaCHDB = _cCHDB.GetCHDB("TKH", _dontkh.MaDon).MaCHDB;
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
                                if (_cCHDB.CheckExist_CTCHDB("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim()) == true)
                                {
                                    MessageBox.Show("Danh Bộ này đã được Lập Cắt Hủy Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                ctchdb.MaCHDB = _cCHDB.GetCHDB("TXL", _dontxl.MaDon).MaCHDB;
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
                                    if (_cCHDB.CheckExist_CTCHDB("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim()) == true)
                                    {
                                        MessageBox.Show("Danh Bộ này đã được Lập Cắt Hủy Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    ctchdb.MaCHDB = _cCHDB.GetCHDB("TBC", _dontbc.MaDon).MaCHDB;
                                }
                                else
                                {
                                    MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                    if (txtMaThongBaoCT.Text.Trim().Replace("-", "") != "")
                        ctchdb.MaCTCTDB = decimal.Parse(txtMaThongBaoCT.Text.Trim().Replace("-", ""));
                    ctchdb.DanhBo = txtDanhBo.Text.Trim();
                    ctchdb.HopDong = txtHopDong.Text.Trim();
                    ctchdb.HoTen = txtHoTen.Text.Trim();
                    ctchdb.DiaChi = txtDiaChi.Text.Trim();
                    if (_hoadon != null)
                    {
                        ctchdb.Dot = _hoadon.DOT.ToString();
                        ctchdb.Ky = _hoadon.KY.ToString();
                        ctchdb.Nam = _hoadon.NAM.ToString();
                        ctchdb.Phuong = _hoadon.Phuong;
                        ctchdb.Quan = _hoadon.Quan;
                    }
                    ctchdb.LyDo = cmbLyDo.SelectedValue.ToString();
                    ctchdb.GhiChuLyDo = txtGhiChu.Text.Trim();
                    ctchdb.NoiDung = txtNoiDung.Text;
                    if (txtSoTien.Text.Trim() != "")
                        ctchdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                    if (cmbViTriDHN1.SelectedItem != null)
                        ctchdb.ViTriDHN1 = cmbViTriDHN1.SelectedItem.ToString();
                    if (cmbViTriDHN2.SelectedItem != null)
                        ctchdb.ViTriDHN2 = cmbViTriDHN2.SelectedItem.ToString();
                    ctchdb.NoiNhan = txtNoiNhan.Text.Trim();

                    ///Đã lập Cắt Tạm
                    if (_ctctdb != null)
                    {
                        ctchdb.DaLapCatTam = true;
                        ctchdb.MaCTCTDB = decimal.Parse(txtMaThongBaoCT.Text.Trim().Replace("-", ""));

                        if (_ctctdb.NgayXuLy != null && _ctctdb.NoiDungXuLy != "Lập Thông báo Cắt Hủy")
                        {
                            CHDB_GhiChu ghichu = new CHDB_GhiChu();
                            ghichu.NgayLap = _ctctdb.NgayXuLy;
                            ghichu.NoiDung = _ctctdb.NoiDungXuLy;
                            ghichu.MaCTCTDB = _ctctdb.MaCTCTDB;
                            if (_cCHDB.ThemGhiChu(ghichu))
                            {
                            }
                        }
                        _ctctdb.NgayXuLy = DateTime.Now;
                        _ctctdb.NoiDungXuLy = "Lập Thông báo Cắt Hủy";
                        _ctctdb.CreateDate_NgayXuLy = DateTime.Now;
                        _cCHDB.SuaCTCTDB(_ctctdb);
                    }
                    ///Ký Tên
                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                        ctchdb.ChucVu = "GIÁM ĐỐC";
                    else
                        ctchdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                    ctchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                    ctchdb.ThongBaoDuocKy = true;

                    if (_cCHDB.ThemCTCHDB(ctchdb))
                    {
                        if (_dontu_ChiTiet != null)
                            _cDonTu.Them_LichSu("Cắt Hủy", "Đã Thông Báo Cắt Hủy", _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value);   
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
                    if (_ctchdb != null)
                    {
                        _ctchdb.TCHC = txtTCHC.Text.Trim();
                        _ctchdb.DanhBo = txtDanhBo.Text.Trim();
                        _ctchdb.HopDong = txtHopDong.Text.Trim();
                        _ctchdb.HoTen = txtHoTen.Text.Trim();
                        _ctchdb.DiaChi = txtDiaChi.Text.Trim();
                        if (_hoadon != null)
                        {
                            _ctchdb.Dot = _hoadon.DOT.ToString();
                            _ctchdb.Ky = _hoadon.KY.ToString();
                            _ctchdb.Nam = _hoadon.NAM.ToString();
                            _ctchdb.Phuong = _hoadon.Phuong;
                            _ctchdb.Quan = _hoadon.Quan;
                        }

                        if (txtMaThongBaoCT.Text.Trim().Replace("-", "") != "")
                            _ctchdb.MaCTCTDB = decimal.Parse(txtMaThongBaoCT.Text.Trim().Replace("-", ""));

                        if (!string.IsNullOrEmpty(cmbLyDo.SelectedValue.ToString()))
                            _ctchdb.LyDo = cmbLyDo.SelectedValue.ToString();
                        _ctchdb.GhiChuLyDo = txtGhiChu.Text.Trim();
                        _ctchdb.NoiDung = txtNoiDung.Text;
                        if (txtSoTien.Text.Trim() != "")
                            _ctchdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                        else
                            _ctchdb.SoTien = null;
                        if (cmbViTriDHN1.SelectedItem != null)
                            _ctchdb.ViTriDHN1 = cmbViTriDHN1.SelectedItem.ToString();
                        if (cmbViTriDHN2.SelectedItem != null)
                            _ctchdb.ViTriDHN2 = cmbViTriDHN2.SelectedItem.ToString();
                        ///
                        if (chkNgayXuLy.Checked)
                        {
                            if (_ctchdb.NgayXuLy != null && _ctchdb.NgayXuLy != dateXuLy.Value)
                            {
                                CHDB_GhiChu ghichu = new CHDB_GhiChu();
                                ghichu.NgayLap = _ctchdb.NgayXuLy;
                                ghichu.NoiDung = _ctchdb.NoiDungXuLy;
                                ghichu.MaCTCHDB = _ctchdb.MaCTCHDB;
                                if (_cCHDB.ThemGhiChu(ghichu))
                                {
                                    dgvGhiChu.DataSource = _cCHDB.GetDSGhiChuByMaCTCHDB(_ctchdb.MaCTCHDB);
                                }
                            }
                            _ctchdb.NgayXuLy = dateXuLy.Value;
                            _ctchdb.NoiDungXuLy = cmbNoiDung.SelectedValue.ToString();
                            _ctchdb.CreateDate_NgayXuLy = DateTime.Now;
                        }
                        else
                        {
                            _ctchdb.NgayXuLy = null;
                            _ctchdb.NoiDungXuLy = null;
                            _ctchdb.CreateDate_NgayXuLy = null;
                        }

                        _ctchdb.NoiNhan = txtNoiNhan.Text.Trim();

                        //if (_ctchdb.DaLapPhieu && _ctchdb.CHDB_Phieus.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaCTCHDB == _ctchdb.MaCTCHDB).HieuLucKy != txtHieuLucKy.Text.Trim())
                        //{
                        //    CHDB_Phieu ycchdb = _ctchdb.CHDB_Phieus.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaCTCHDB == _ctchdb.MaCTCHDB);
                        //    ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                        //    _cCHDB.SuaYeuCauCHDB(ycchdb);
                        //}

                        if (_cCHDB.SuaCTCHDB(_ctchdb))
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
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (_ctchdb != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_ctchdb.DaLapPhieu == true)
                        {
                            MessageBox.Show("Đã Lập Phiếu Hủy, Không xóa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (_cCHDB.XoaCTCHDB(_ctchdb))
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

        private void btnGhiChu_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (_ctchdb != null)
                    {
                        CHDB_GhiChu item = new CHDB_GhiChu();
                        item.NgayLap = dateLap.Value;
                        item.NoiDung = txtNoiDungGhiChu.Text.Trim();
                        //item.NoiNhan = txtNoiNhanXuLy.Text.Trim();
                        //item.GhiChu = txtGhiChu.Text.Trim();
                        item.MaCTCHDB = _ctchdb.MaCTCHDB;
                        if (_cCHDB.ThemGhiChu(item))
                        {
                            dateLap.Value = DateTime.Now;
                            txtNoiDungGhiChu.Text = "";
                            dgvGhiChu.DataSource = _cCHDB.GetDSGhiChuByMaCTCHDB(_ctchdb.MaCTCHDB);
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

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (_ctchdb != null)
                    {
                        ///Nếu Chưa Lập Phiếu
                        if (!_cCHDB.CheckExist_PhieuHuyByMaCTCHDB(_ctchdb.MaCTCHDB))
                        {
                            if (txtHieuLucKy.Text.Trim() != "")
                            {
                                CHDB_Phieu ycchdb = new CHDB_Phieu();
                                //if (_ctchdb.CHDB.MaDon != null)
                                //    ycchdb.MaDon = _ctchdb.CHDB.MaDon;
                                //else
                                //    if (_ctchdb.CHDB.MaDonTXL != null)
                                //        ycchdb.MaDonTXL = _ctchdb.CHDB.MaDonTXL;
                                //    else
                                //        if (_ctchdb.CHDB.MaDonTBC != null)
                                //            ycchdb.MaDonTBC = _ctchdb.CHDB.MaDonTBC;
                                ycchdb.MaCHDB = _ctchdb.MaCHDB;
                                ycchdb.TBCHDB = true;
                                ycchdb.MaCTCHDB = _ctchdb.MaCTCHDB;
                                ycchdb.DanhBo = _ctchdb.DanhBo;
                                ycchdb.HopDong = _ctchdb.HopDong;
                                ycchdb.HoTen = _ctchdb.HoTen;
                                ycchdb.DiaChi = _ctchdb.DiaChi;
                                ycchdb.LyDo = _ctchdb.LyDo;
                                ycchdb.GhiChuLyDo = _ctchdb.GhiChuLyDo;
                                ycchdb.SoTien = _ctchdb.SoTien;
                                ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                                HOADON hoadon = _cThuTien.GetMoiNhat(_ctchdb.DanhBo);
                                if (hoadon != null)
                                {
                                    ycchdb.Dot = hoadon.DOT.ToString();
                                    ycchdb.Ky = hoadon.KY.ToString();
                                    ycchdb.Nam = hoadon.NAM.ToString();
                                }
                                ///Ký Tên
                                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                    ycchdb.ChucVu = "GIÁM ĐỐC";
                                else
                                    ycchdb.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                ycchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                ycchdb.PhieuDuocKy = true;

                                if (_cCHDB.ThemPhieuHuy(ycchdb))
                                {
                                    _ctchdb.DaLapPhieu = true;
                                    _ctchdb.SoPhieu = ycchdb.MaYCCHDB;
                                    _ctchdb.NgayLapPhieu = ycchdb.CreateDate;
                                    _ctchdb.HieuLucKy = ycchdb.HieuLucKy;
                                    _ctchdb.PhieuDuocKy = true;
                                    ///
                                    _ctchdb.NgayXuLy = DateTime.Now;
                                    _ctchdb.NoiDungXuLy = "Lập phiếu hủy DB";
                                    _ctchdb.CreateDate_NgayXuLy = DateTime.Now;
                                    _cCHDB.SuaCTCHDB(_ctchdb);

                                    CHDB_GhiChu ghichu = new CHDB_GhiChu();
                                    ghichu.NgayLap = _ctchdb.NgayXuLy;
                                    ghichu.NoiDung = _ctchdb.NoiDungXuLy;
                                    ghichu.MaCTCHDB = _ctchdb.MaCTCHDB;
                                    if (_cCHDB.ThemGhiChu(ghichu))
                                    {
                                        dgvGhiChu.DataSource = _cCHDB.GetDSGhiChuByMaCTCHDB(_ctchdb.MaCTCHDB);
                                    }

                                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                    DataRow dr = dsBaoCao.Tables["PhieuCHDB"].NewRow();

                                    dr["SoPhieu"] = ycchdb.MaYCCHDB.ToString().Insert(ycchdb.MaYCCHDB.ToString().Length - 2, "-");
                                    dr["HieuLucKy"] = ycchdb.HieuLucKy;
                                    dr["Dot"] = ycchdb.Dot;
                                    dr["HoTen"] = ycchdb.HoTen;
                                    dr["DiaChi"] = ycchdb.DiaChi;
                                    dr["DanhBo"] = ycchdb.DanhBo.Insert(7, " ").Insert(4, " ");
                                    dr["HopDong"] = ycchdb.HopDong;

                                    if (ycchdb.LyDo == "Vấn Đề Khác")
                                        dr["LyDo"] = "";
                                    else
                                        dr["LyDo"] = ycchdb.LyDo + ". ";

                                    if (ycchdb.GhiChuLyDo != "")
                                        dr["LyDo"] += ycchdb.GhiChuLyDo + ". ";
                                    if (ycchdb.SoTien.ToString() != "")
                                        dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ycchdb.SoTien);

                                    dr["ChucVu"] = ycchdb.ChucVu;
                                    dr["NguoiKy"] = ycchdb.NguoiKy;

                                    if (ycchdb.CHDB.MaDonMoi != null)
                                        dr["MaDon"] = ycchdb.CHDB.MaDon.ToString();
                                    else
                                        if (ycchdb.CHDB.MaDon != null)
                                            dr["MaDon"] = ycchdb.CHDB.MaDon.ToString().Insert(ycchdb.CHDB.MaDon.ToString().Length - 2, "-");
                                    else
                                            if (ycchdb.CHDB.MaDonTXL != null)
                                                dr["MaDon"] = "TXL" + ycchdb.CHDB.MaDonTXL.ToString().Insert(ycchdb.CHDB.MaDonTXL.ToString().Length - 2, "-");
                                        else
                                                if (ycchdb.CHDB.MaDonTBC != null)
                                                    dr["MaDon"] = "TBC" + ycchdb.CHDB.MaDonTBC.ToString().Insert(ycchdb.CHDB.MaDonTBC.ToString().Length - 2, "-");

                                    dsBaoCao.Tables["PhieuCHDB"].Rows.Add(dr);

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
                                MessageBox.Show("Chưa có Hiệu Lực Kỳ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ///Nếu Đã Lập Phiếu
                        else
                            ///lập phiếu mới
                            if (MessageBox.Show("Đã Lập Phiếu, Bạn có muốn Lấp Phiếu Mới?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (txtHieuLucKy.Text.Trim() != "")
                                {
                                    CHDB_Phieu ycchdb = new CHDB_Phieu();
                                    //if (_ctchdb.CHDB.MaDon != null)
                                    //    ycchdb.MaDon = _ctchdb.CHDB.MaDon;
                                    //else
                                    //    if (_ctchdb.CHDB.MaDonTXL != null)
                                    //        ycchdb.MaDonTXL = _ctchdb.CHDB.MaDonTXL;
                                    //    else
                                    //        if (_ctchdb.CHDB.MaDonTBC != null)
                                    //            ycchdb.MaDonTBC = _ctchdb.CHDB.MaDonTBC;
                                    ycchdb.MaCHDB = _ctchdb.MaCHDB;
                                    ycchdb.TBCHDB = true;
                                    ycchdb.MaCTCHDB = _ctchdb.MaCTCHDB;
                                    ycchdb.DanhBo = _ctchdb.DanhBo;
                                    ycchdb.HopDong = _ctchdb.HopDong;
                                    ycchdb.HoTen = _ctchdb.HoTen;
                                    ycchdb.DiaChi = _ctchdb.DiaChi;
                                    ycchdb.LyDo = _ctchdb.LyDo;
                                    ycchdb.GhiChuLyDo = _ctchdb.GhiChuLyDo;
                                    ycchdb.SoTien = _ctchdb.SoTien;
                                    ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();

                                    HOADON hoadon = _cThuTien.GetMoiNhat(_ctchdb.DanhBo);
                                    if (hoadon != null)
                                    {
                                        ycchdb.Dot = hoadon.DOT.ToString();
                                        ycchdb.Ky = hoadon.KY.ToString();
                                        ycchdb.Nam = hoadon.NAM.ToString();
                                    }
                                    ///Ký Tên
                                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                        ycchdb.ChucVu = "GIÁM ĐỐC";
                                    else
                                        ycchdb.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                    ycchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                    ycchdb.PhieuDuocKy = true;

                                    if (_cCHDB.ThemPhieuHuy(ycchdb))
                                    {
                                        _ctchdb.DaLapPhieu = true;
                                        _ctchdb.SoPhieu = ycchdb.MaYCCHDB;
                                        _ctchdb.HieuLucKy = ycchdb.HieuLucKy;
                                        _ctchdb.NgayLapPhieu = ycchdb.CreateDate;
                                        _ctchdb.PhieuDuocKy = true;
                                        _cCHDB.SuaCTCHDB(_ctchdb);

                                        DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                        DataRow dr = dsBaoCao.Tables["PhieuCHDB"].NewRow();

                                        dr["SoPhieu"] = ycchdb.MaYCCHDB.ToString().Insert(ycchdb.MaYCCHDB.ToString().Length - 2, "-");
                                        dr["HieuLucKy"] = ycchdb.HieuLucKy;
                                        dr["Dot"] = ycchdb.Dot;
                                        dr["HoTen"] = ycchdb.HoTen;
                                        dr["DiaChi"] = ycchdb.DiaChi;
                                        dr["DanhBo"] = ycchdb.DanhBo.Insert(7, " ").Insert(4, " ");
                                        dr["HopDong"] = ycchdb.HopDong;

                                        if (ycchdb.LyDo == "Vấn Đề Khác")
                                            dr["LyDo"] = "";
                                        else
                                            dr["LyDo"] = ycchdb.LyDo + ". ";

                                        if (ycchdb.GhiChuLyDo != "")
                                            dr["LyDo"] += ycchdb.GhiChuLyDo + ". ";
                                        if (ycchdb.SoTien.ToString() != "")
                                            dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ycchdb.SoTien);

                                        dr["ChucVu"] = ycchdb.ChucVu;
                                        dr["NguoiKy"] = ycchdb.NguoiKy;

                                        if (ycchdb.CHDB.MaDonMoi != null)
                                            dr["MaDon"] = ycchdb.CHDB.MaDonMoi.ToString();
                                        else
                                        if (ycchdb.CHDB.MaDon != null)
                                            dr["MaDon"] = ycchdb.CHDB.MaDon.ToString().Insert(ycchdb.CHDB.MaDon.ToString().Length - 2, "-");
                                        else
                                            if (ycchdb.CHDB.MaDonTXL != null)
                                                dr["MaDon"] = "TXL" + ycchdb.CHDB.MaDonTXL.ToString().Insert(ycchdb.CHDB.MaDonTXL.ToString().Length - 2, "-");
                                            else
                                                if (ycchdb.CHDB.MaDonTBC != null)
                                                    dr["MaDon"] = "TBC" + ycchdb.CHDB.MaDonTBC.ToString().Insert(ycchdb.CHDB.MaDonTBC.ToString().Length - 2, "-");

                                        dsBaoCao.Tables["PhieuCHDB"].Rows.Add(dr);

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
                                    MessageBox.Show("Chưa có Hiệu Lực Kỳ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            ///lấy lại phiếu cũ
                            else
                            {
                                CHDB_Phieu ycchdb = _cCHDB.GetPhieuHuyByMaCTCHDB(_ctchdb.MaCTCHDB);
                                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                DataRow dr = dsBaoCao.Tables["PhieuCHDB"].NewRow();

                                dr["SoPhieu"] = ycchdb.MaYCCHDB.ToString().Insert(ycchdb.MaYCCHDB.ToString().Length - 2, "-");
                                dr["HieuLucKy"] = ycchdb.HieuLucKy;
                                dr["Dot"] = ycchdb.Dot;
                                dr["HoTen"] = ycchdb.HoTen;
                                dr["DiaChi"] = ycchdb.DiaChi;
                                dr["DanhBo"] = ycchdb.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["HopDong"] = ycchdb.HopDong;

                                if (ycchdb.LyDo == "Vấn Đề Khác")
                                    dr["LyDo"] = "";
                                else
                                    dr["LyDo"] = ycchdb.LyDo + ". ";

                                if (ycchdb.GhiChuLyDo != "")
                                    dr["LyDo"] += ycchdb.GhiChuLyDo + ". ";
                                if (ycchdb.SoTien.ToString() != "")
                                    dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ycchdb.SoTien);

                                dr["ChucVu"] = ycchdb.ChucVu;
                                dr["NguoiKy"] = ycchdb.NguoiKy;

                                if (ycchdb.CHDB.MaDonMoi != null)
                                    dr["MaDon"] = ycchdb.CHDB.MaDonMoi.ToString();
                                else
                                if (ycchdb.CHDB.MaDon != null)
                                    dr["MaDon"] = ycchdb.CHDB.MaDon.ToString().Insert(ycchdb.CHDB.MaDon.ToString().Length - 2, "-");
                                else
                                    if (ycchdb.CHDB.MaDonTXL != null)
                                        dr["MaDon"] = "TXL" + ycchdb.CHDB.MaDonTXL.ToString().Insert(ycchdb.CHDB.MaDonTXL.ToString().Length - 2, "-");
                                    else
                                        if (ycchdb.CHDB.MaDonTBC != null)
                                            dr["MaDon"] = "TBC" + ycchdb.CHDB.MaDonTBC.ToString().Insert(ycchdb.CHDB.MaDonTBC.ToString().Length - 2, "-");

                                dsBaoCao.Tables["PhieuCHDB"].Rows.Add(dr);

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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_cCHDB.XoaGhiChu(_cCHDB.GetGhiChuByID(decimal.Parse(dgvGhiChu.CurrentRow.Cells["ID"].Value.ToString()))))
                        {
                            dgvGhiChu.DataSource = _cCHDB.GetDSGhiChuByMaCTCHDB(_ctchdb.MaCTCHDB);
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

        private void dgvGhiChu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvGhiChu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
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
            if (e.Button == MouseButtons.Right && (_ctchdb != null))
            {
                contextMenuStrip1.Show(dgvGhiChu, new Point(e.X, e.Y));
            }
        }

        private void txtSoTien_Leave(object sender, EventArgs e)
        {
            if (txtSoTien.Text.Trim() != "")
                txtSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
        }

        private void chkNgayXuLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgayXuLy.Checked)
            {
                dateXuLy.Enabled = true;
                cmbNoiDung.Enabled = true;
            }
            else
            {
                dateXuLy.Enabled = false;
                cmbNoiDung.Enabled = false;
            }
        }

        private void txtDenMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTuMa.Text.Trim().Replace("-", "").Length > 2 && txtDenMa.Text.Trim().Replace("-", "").Length > 2 && e.KeyChar == 13)
                if (txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2) == txtDenMa.Text.Trim().Replace("-", "").Substring(txtDenMa.Text.Trim().Replace("-", "").Length - 2, 2))
                {
                    int TuMa = int.Parse(txtTuMa.Text.Trim().Replace("-", "").Substring(0, txtTuMa.Text.Trim().Replace("-", "").Length - 2));
                    int DenMa = int.Parse(txtDenMa.Text.Trim().Replace("-", "").Substring(0, txtDenMa.Text.Trim().Replace("-", "").Length - 2));
                    while (TuMa <= DenMa)
                    {
                        lstMa.Items.Add(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2));
                        TuMa++;
                    }
                }
                else
                {
                    MessageBox.Show("Từ Mã, Đến Mã phải cùng 1 năm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void btnLuuNhieu_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (radToKH.Checked)
                        foreach (ListViewItem itemMa in lstMa.Items)
                        {
                            DonKH donkh = _cDonKH.Get(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));

                            if (!_cCHDB.CheckExist_CHDB("TKH", donkh.MaDon))
                            {
                                CHDB chdb = new CHDB();
                                chdb.MaDon = donkh.MaDon;
                                _cCHDB.ThemCHDB(chdb);

                                HOADON hoadon = _cThuTien.GetMoiNhat(donkh.DanhBo);

                                CHDB_ChiTietCatHuy ctchdb = new CHDB_ChiTietCatHuy();
                                ctchdb.MaCHDB = chdb.MaCHDB;
                                ctchdb.DanhBo = hoadon.DANHBA;
                                ctchdb.HopDong = hoadon.HOPDONG;
                                ctchdb.HoTen = hoadon.TENKH;
                                ctchdb.DiaChi = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);

                                if (hoadon != null)
                                {
                                    ctchdb.Dot = hoadon.DOT.ToString();
                                    ctchdb.Ky = hoadon.KY.ToString();
                                    ctchdb.Nam = hoadon.NAM.ToString();
                                }
                                ctchdb.LyDo = cmbLyDo.SelectedValue.ToString();
                                ctchdb.GhiChuLyDo = txtGhiChu.Text.Trim();
                                if (txtSoTien.Text.Trim() != "")
                                    ctchdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                                ctchdb.NoiDung = ((CHDB_LyDo)cmbLyDo.SelectedItem).NoiDung;
                                ctchdb.NoiNhan = ((CHDB_LyDo)cmbLyDo.SelectedItem).NoiNhan + "\r\n(" + itemMa.Text.Insert(itemMa.Text.Length - 2, "-") + ")";

                                ///Ký Tên
                                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                    ctchdb.ChucVu = "GIÁM ĐỐC";
                                else
                                    ctchdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                ctchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                ctchdb.ThongBaoDuocKy = true;

                                _cCHDB.ThemCTCHDB(ctchdb);
                                lstMa.Items.Remove(itemMa);
                            }
                        }
                    else
                        if (radTXL.Checked)
                            foreach (ListViewItem itemMa in lstMa.Items)
                            {
                                DonTXL dontxl = _cDonTXL.Get(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));

                                if (!_cCHDB.CheckExist_CHDB("TXL", dontxl.MaDon))
                                {
                                    CHDB chdb = new CHDB();
                                    chdb.MaDonTXL = dontxl.MaDon;
                                    _cCHDB.ThemCHDB(chdb);

                                    HOADON hoadon = _cThuTien.GetMoiNhat(dontxl.DanhBo);

                                    CHDB_ChiTietCatHuy ctchdb = new CHDB_ChiTietCatHuy();
                                    ctchdb.MaCHDB = chdb.MaCHDB;
                                    ctchdb.DanhBo = hoadon.DANHBA;
                                    ctchdb.HopDong = hoadon.HOPDONG;
                                    ctchdb.HoTen = hoadon.TENKH;
                                    ctchdb.DiaChi = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);

                                    if (hoadon != null)
                                    {
                                        ctchdb.Dot = hoadon.DOT.ToString();
                                        ctchdb.Ky = hoadon.KY.ToString();
                                        ctchdb.Nam = hoadon.NAM.ToString();
                                    }
                                    ctchdb.LyDo = cmbLyDo.SelectedValue.ToString();
                                    ctchdb.GhiChuLyDo = txtGhiChu.Text.Trim();
                                    if (txtSoTien.Text.Trim() != "")
                                        ctchdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                                    ctchdb.NoiDung = ((CHDB_LyDo)cmbLyDo.SelectedItem).NoiDung;
                                    ctchdb.NoiNhan = ((CHDB_LyDo)cmbLyDo.SelectedItem).NoiNhan + "\r\n(TXL" + itemMa.Text.Insert(itemMa.Text.Length - 2, "-") + ")";

                                    ///Ký Tên
                                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                        ctchdb.ChucVu = "GIÁM ĐỐC";
                                    else
                                        ctchdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                    ctchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                    ctchdb.ThongBaoDuocKy = true;

                                    _cCHDB.ThemCTCHDB(ctchdb);
                                    lstMa.Items.Remove(itemMa);
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

        private void lstMa_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstMa.Items.Count > 0 && e.Button == MouseButtons.Left)
            {
                foreach (ListViewItem item in lstMa.SelectedItems)
                {
                    lstMa.Items.Remove(item);
                }
            }
        }

        private void lstMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMa.SelectedItems.Count == 0)
                return;

            if (radToKH.Checked)
            {
                DonKH donkh = _cDonKH.Get(decimal.Parse(lstMa.SelectedItems[0].Text.Trim().Replace("-", "")));
                dgvLichSuCHDB.DataSource = _cCHDB.GetLichSuCHDB(donkh.DanhBo);
            }
            else
                if (radTXL.Checked)
                {
                    DonTXL dontxl = _cDonTXL.Get(decimal.Parse(lstMa.SelectedItems[0].Text.Trim().Replace("-", "")));
                    dgvLichSuCHDB.DataSource = _cCHDB.GetLichSuCHDB(dontxl.DanhBo);
                }
        }

        private void dgvLichSuCHDB_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvLichSuCHDB.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvLichSuCHDB_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLichSuCHDB.Columns[e.ColumnIndex].Name == "Ma" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvLichSuCHDB.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void btnInThongBao_Click(object sender, EventArgs e)
        {
            if (_ctchdb != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                //dr["SoPhieu"] = _ctchdb.MaCTCHDB.ToString().Insert(_ctchdb.MaCTCHDB.ToString().Length - 2, "-");
                dr["HoTen"] = _ctchdb.HoTen;
                dr["DiaChi"] = _ctchdb.DiaChi;
                if (!string.IsNullOrEmpty(_ctchdb.DanhBo))
                    dr["DanhBo"] = _ctchdb.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["HopDong"] = _ctchdb.HopDong;

                dr["ViTriDHN"] = "Vị trí ĐHN lắp đặt: " + _ctchdb.ViTriDHN1 + ", " + _ctchdb.ViTriDHN2;

                if (_ctchdb.LyDo != "Vấn Đề Khác")
                    dr["LyDo"] = _ctchdb.LyDo + ". ";
                if (_ctchdb.GhiChuLyDo != "")
                    dr["LyDo"] += _ctchdb.GhiChuLyDo + ". ";
                if (_ctchdb.SoTien.ToString() != "")
                    dr["LyDo"] += "Tổng Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", _ctchdb.SoTien);
                dr["NoiDung"] = _ctchdb.NoiDung;

                dr["NoiNhan"] = _ctchdb.NoiNhan + "\r\nTB" + _ctchdb.MaCTCHDB.ToString().Insert(_ctchdb.MaCTCHDB.ToString().Length - 2, "-");

                if (_ctchdb.NgayXuLy!=null)
                    dr["NgayXuLy"] = _ctchdb.NgayXuLy.Value.ToString("dd/MM/yyyy") + " : " + _ctchdb.NoiDungXuLy;

                dr["ChucVu"] = _ctchdb.ChucVu;
                dr["NguoiKy"] = _ctchdb.NguoiKy;

                dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                rptThongBaoCHDB rpt = new rptThongBaoCHDB();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void frmCHDB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Add)
                btnThem.PerformClick();
        }

        
    }
}

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

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmCTDB : Form
    {
        string _mnu = "mnuCTDB";
        CThuTien _cThuTien = new CThuTien();
        CCHDB _cCHDB = new CCHDB();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CDocSo _cDocSo = new CDocSo();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CLyDoCHDB _cLyDoCHDB = new CLyDoCHDB();
        CNoiDungXuLyCHDB _cNoiDungXuLyCHDB = new CNoiDungXuLyCHDB();
        CKTXM _cKTXM = new CKTXM();

        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        CTCTDB _ctctdb = null;
        decimal _MaCTCTDB = -1;

        public frmCTDB()
        {
            InitializeComponent();
        }

        public frmCTDB(decimal MaCTCTDB)
        {
            _MaCTCTDB = MaCTCTDB;
            InitializeComponent();
        }

        private void frmCTDB_Load(object sender, EventArgs e)
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

            if (_MaCTCTDB != -1)
            {
                txtMaThongBao.Text = _MaCTCTDB.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtMaThongBao_KeyPress(sender, arg);
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

            CTKTXM ctktxm = null;
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

        public void LoadCTDB(CTCTDB ctctdb)
        {
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
            txtMaThongBao.Text = ctctdb.MaCTCTDB.ToString().Insert(ctctdb.MaCTCTDB.ToString().Length - 2, "-");
            txtTCHC.Text = ctctdb.TCHC;
            ///
            txtDanhBo.Text = ctctdb.DanhBo;
            txtHopDong.Text = ctctdb.HopDong;
            txtHoTen.Text = ctctdb.HoTen;
            txtDiaChi.Text = ctctdb.DiaChi;

            ///Nội Dung Xử Lý
            cmbLyDo.SelectedValue = ctctdb.LyDo;
            txtNoiDung.Text = ctctdb.NoiDung;
            txtGhiChu.Text = ctctdb.GhiChuLyDo;
            if (ctctdb.SoTien != null)
                txtSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctctdb.SoTien.Value);
            else
                txtSoTien.Text = "";
            cmbViTriDHN1.SelectedItem = ctctdb.ViTriDHN1;
            cmbViTriDHN2.SelectedItem = ctctdb.ViTriDHN2;
            txtNoiNhan.Text = ctctdb.NoiNhan;

            if (ctctdb.NoiDungXuLy != null)
            {
                chkNgayXuLy.Checked = true;
                dateXuLy.Value = ctctdb.NgayXuLy.Value;
                cmbNoiDung.SelectedValue = ctctdb.NoiDungXuLy;
            }
            else
            {
                chkNgayXuLy.Checked = false;
                dateXuLy.Value = DateTime.Now;
                cmbNoiDung.SelectedIndex = -1;
            }

            dgvGhiChu.DataSource = _cCHDB.GetDSGhiChuByMaCTCTDB(ctctdb.MaCTCTDB);
            dgvLichSuCHDB.DataSource = _cCHDB.GetLichSuCHDB(ctctdb.DanhBo);
            CheckLichSuCHDB();

            ///Đã lấp Phiếu Yêu Cầu CHDB
            if (_cCHDB.CheckExist_PhieuHuyByMaCTCTDB(ctctdb.MaCTCTDB))
            {
                txtHieuLucKy.Text = ctctdb.PhieuCHDBs.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaCTCTDB == ctctdb.MaCTCTDB).HieuLucKy;
            }
            else
            {
                txtHieuLucKy.Text = "";
            }
        }

        public void Clear()
        {
            txtMaDonCu.Text = "";
            txtMaDonMoi.Text = "";
            txtMaThongBao.Text = "";
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
            txtNoiNhan.Text = "";
            cmbNoiDung.SelectedIndex = -1;
            dateXuLy.Value = DateTime.Now;
            chkNgayXuLy.Checked = false;
            ///
            dateLap.Value = DateTime.Now;
            txtNoiDungGhiChu.Text = "";
            ///
            txtHieuLucKy.Text = "";
            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            _ctctdb = null;
            _MaCTCTDB = -1;
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
                    ///Nếu đơn thuộc Tổ Khách Hàng
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
                txtMaDonMoi.Text = MaDon;
                ///Đơn Tổ Xử Lý
                if (txtMaDonMoi.Text.Trim().ToUpper().Contains("XL"))
                {
                    if (_cDonTXL.CheckExist(txtMaDonMoi.Text.Trim()) == true)
                    {
                        _dontxl = _cDonTXL.Get(txtMaDonMoi.Text.Trim());
                        txtMaDonMoi.Text =  _dontxl.MaDonMoi;

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
                    if (txtMaDonMoi.Text.Trim().ToUpper().Contains("BC"))
                    {
                        if (_cDonTBC.CheckExist(txtMaDonMoi.Text.Trim()) == true)
                        {
                            _dontbc = _cDonTBC.Get(txtMaDonMoi.Text.Trim());
                            txtMaDonMoi.Text = _dontbc.MaDonMoi;

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
                    ///Nếu đơn thuộc Tổ Khách Hàng
                    else
                        if (txtMaDonMoi.Text.Trim().ToUpper().Contains("BC"))
                        {
                            if (_cDonKH.CheckExist(txtMaDonMoi.Text.Trim()) == true)
                            {
                                _dontkh = _cDonKH.Get(txtMaDonMoi.Text.Trim());
                                txtMaDonMoi.Text = _dontkh.MaDonMoi;

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

        private void txtMaThongBao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cCHDB.CheckExist_CTCTDB(decimal.Parse(txtMaThongBao.Text.Trim().Replace("-", ""))) == true)
                {
                    _ctctdb = _cCHDB.GetCTCTDB(decimal.Parse(txtMaThongBao.Text.Trim().Replace("-", "")));
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
                LyDoCHDB vv = (LyDoCHDB)cmbLyDo.SelectedItem;
                txtNoiDung.Text = vv.NoiDung;
                if (txtMaDonCu.Text.Trim() != "")
                    txtNoiNhan.Text = vv.NoiNhan + "\r\n(" + txtMaDonCu.Text.Trim() + ")";
                else
                    if (txtMaDonMoi.Text.Trim() != "")
                        txtNoiNhan.Text = vv.NoiNhan + "\r\n(" + txtMaDonMoi.Text.Trim() + ")";

                if (cmbLyDo.SelectedValue.ToString() == "Nợ Tiền Gian Lận Nước")
                    txtSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", 1283641);
                else
                    if (cmbLyDo.SelectedValue.ToString() == "Không Thanh Toán Tiền Bồi Thường ĐHN")
                        txtSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", 1329053);
                    else
                        if (cmbLyDo.SelectedValue.ToString() == "Không Thanh Toán Phí Bấm Chì Góc")
                            txtSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", 112000);
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

                    CTCTDB ctctdb = new CTCTDB();

                    if (_dontkh != null)
                    {
                        if (_cCHDB.CheckExist_CHDB("TKH", _dontkh.MaDon) == false)
                        {
                            CHDB chdb = new CHDB();
                            chdb.MaDon = _dontkh.MaDon;
                            _cCHDB.ThemCHDB(chdb);
                        }
                        if (_cCHDB.CheckExist_CTCTDB("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim()))
                        {
                            if (MessageBox.Show("Danh Bộ này đã được Lập Cắt Tạm Danh Bộ\nBạn có chắc muốn LẬP THÔNG BÁO MỚI???", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                                return;
                        }
                        ctctdb.MaCHDB = _cCHDB.GetCHDB("TKH", _dontkh.MaDon).MaCHDB;
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
                            if (_cCHDB.CheckExist_CTCTDB("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim()))
                            {
                                if (MessageBox.Show("Danh Bộ này đã được Lập Cắt Tạm Danh Bộ\nBạn có chắc muốn LẬP THÔNG BÁO MỚI???", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                                    return;
                            }
                            ctctdb.MaCHDB = _cCHDB.GetCHDB("TXL", _dontxl.MaDon).MaCHDB;
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
                                if (_cCHDB.CheckExist_CTCTDB("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim()))
                                {
                                    if (MessageBox.Show("Danh Bộ này đã được Lập Cắt Tạm Danh Bộ\nBạn có chắc muốn LẬP THÔNG BÁO MỚI???", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                                        return;
                                }
                                ctctdb.MaCHDB = _cCHDB.GetCHDB("TBC", _dontbc.MaDon).MaCHDB;
                            }
                            else
                            {
                                MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                    ctctdb.DanhBo = txtDanhBo.Text.Trim();
                    ctctdb.HopDong = txtHopDong.Text.Trim();
                    ctctdb.HoTen = txtHoTen.Text.Trim();
                    ctctdb.DiaChi = txtDiaChi.Text.Trim();
                    if (_hoadon != null)
                    {
                        ctctdb.Dot = _hoadon.DOT.ToString();
                        ctctdb.Ky = _hoadon.KY.ToString();
                        ctctdb.Nam = _hoadon.NAM.ToString();
                        ctctdb.Phuong = _hoadon.Phuong;
                        ctctdb.Quan = _hoadon.Quan;
                    }
                    ctctdb.LyDo = cmbLyDo.SelectedValue.ToString();
                    ctctdb.GhiChuLyDo = txtGhiChu.Text.Trim();
                    ctctdb.NoiDung = txtNoiDung.Text;
                    if (txtSoTien.Text.Trim() != "")
                        ctctdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                    if (cmbViTriDHN1.SelectedItem != null)
                        ctctdb.ViTriDHN1 = cmbViTriDHN1.SelectedItem.ToString();
                    if (cmbViTriDHN2.SelectedItem != null)
                        ctctdb.ViTriDHN2 = cmbViTriDHN2.SelectedItem.ToString();
                    ctctdb.NoiNhan = txtNoiNhan.Text.Trim();

                    ///Ký Tên
                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                        ctctdb.ChucVu = "GIÁM ĐỐC";
                    else
                        ctctdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                    ctctdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                    ctctdb.ThongBaoDuocKy = true;

                    if (_cCHDB.ThemCTCTDB(ctctdb))
                    {
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (_ctctdb != null)
                    {
                        _ctctdb.TCHC = txtTCHC.Text.Trim();
                        _ctctdb.DanhBo = txtDanhBo.Text.Trim();
                        _ctctdb.HopDong = txtHopDong.Text.Trim();
                        _ctctdb.HoTen = txtHoTen.Text.Trim();
                        _ctctdb.DiaChi = txtDiaChi.Text.Trim();
                        if (_hoadon != null)
                        {
                            _ctctdb.Dot = _hoadon.DOT.ToString();
                            _ctctdb.Ky = _hoadon.KY.ToString();
                            _ctctdb.Nam = _hoadon.NAM.ToString();
                            _ctctdb.Phuong = _hoadon.Phuong;
                            _ctctdb.Quan = _hoadon.Quan;
                        }

                        if (!string.IsNullOrEmpty(cmbLyDo.SelectedValue.ToString()))
                            _ctctdb.LyDo = cmbLyDo.SelectedValue.ToString();
                        _ctctdb.GhiChuLyDo = txtGhiChu.Text.Trim();
                        _ctctdb.NoiDung = txtNoiDung.Text;
                        if (txtSoTien.Text.Trim() != "")
                            _ctctdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                        else
                            _ctctdb.SoTien = null;
                        if (cmbViTriDHN1.SelectedItem != null)
                            _ctctdb.ViTriDHN1 = cmbViTriDHN1.SelectedItem.ToString();
                        if (cmbViTriDHN2.SelectedItem != null)
                            _ctctdb.ViTriDHN2 = cmbViTriDHN2.SelectedItem.ToString();
                        ///
                        if (chkNgayXuLy.Checked)
                        {
                            if (_ctctdb.NgayXuLy != null && _ctctdb.NgayXuLy != dateXuLy.Value)
                            {
                                GhiChuCHDB ghichu = new GhiChuCHDB();
                                ghichu.NgayLap = _ctctdb.NgayXuLy;
                                ghichu.NoiDung = _ctctdb.NoiDungXuLy;
                                ghichu.MaCTCTDB = _ctctdb.MaCTCTDB;
                                if (_cCHDB.ThemGhiChu(ghichu))
                                {
                                    dgvGhiChu.DataSource = _cCHDB.GetDSGhiChuByMaCTCTDB(_ctctdb.MaCTCTDB);
                                }
                            }
                            _ctctdb.NgayXuLy = dateXuLy.Value;
                            _ctctdb.NoiDungXuLy = cmbNoiDung.SelectedValue.ToString();
                            _ctctdb.CreateDate_NgayXuLy = DateTime.Now;
                        }
                        else
                        {
                            _ctctdb.NgayXuLy = null;
                            _ctctdb.NoiDungXuLy = null;
                            _ctctdb.CreateDate_NgayXuLy = null;
                        }

                        _ctctdb.NoiNhan = txtNoiNhan.Text.Trim();

                        //if (_ctctdb.DaLapPhieu && _ctctdb.PhieuCHDBs.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaCTCTDB == _ctctdb.MaCTCTDB).HieuLucKy != txtHieuLucKy.Text.Trim())
                        //{
                        //    PhieuCHDB ycchdb = _ctctdb.PhieuCHDBs.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaCTCTDB == _ctctdb.MaCTCTDB);
                        //    ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                        //    _cCHDB.SuaYeuCauCHDB(ycchdb);
                        //}

                        if (_cCHDB.SuaCTCTDB(_ctctdb))
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
                if (_ctctdb != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (_ctctdb.DaLapPhieu == true)
                    {
                        MessageBox.Show("Đã Lập Phiếu Hủy, Không xóa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_cCHDB.XoaCTCTDB(_ctctdb))
                    {
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaDonCu.Focus();
                    }
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
                    if (_ctctdb != null)
                    {
                        GhiChuCHDB ghichu = new GhiChuCHDB();
                        ghichu.NgayLap = dateLap.Value;
                        ghichu.NoiDung = txtNoiDungGhiChu.Text.Trim();
                        ghichu.MaCTCTDB = _ctctdb.MaCTCTDB;
                        if (_cCHDB.ThemGhiChu(ghichu))
                        {
                            dateLap.Value = DateTime.Now;
                            txtNoiDungGhiChu.Text = "";
                            dgvGhiChu.DataSource = _cCHDB.GetDSGhiChuByMaCTCTDB(_ctctdb.MaCTCTDB);
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
                if (_ctctdb != null)
                {
                    ///Nếu Chưa Lập Phiếu
                    if (!_cCHDB.CheckExist_PhieuHuyByMaCTCTDB(_ctctdb.MaCTCTDB))
                    {
                        if (txtHieuLucKy.Text.Trim() != "")
                        {
                            PhieuCHDB ycchdb = new PhieuCHDB();
                            if (_ctctdb.CHDB.MaDon != null)
                                ycchdb.MaDon = _ctctdb.CHDB.MaDon;
                            else
                                if (_ctctdb.CHDB.MaDonTXL != null)
                                    ycchdb.MaDonTXL = _ctctdb.CHDB.MaDonTXL;
                                else
                                    if (_ctctdb.CHDB.MaDonTBC != null)
                                        ycchdb.MaDonTBC = _ctctdb.CHDB.MaDonTBC;

                            ycchdb.TBCTDB = true;
                            ycchdb.MaCTCTDB = _ctctdb.MaCTCTDB;
                            ycchdb.DanhBo = _ctctdb.DanhBo;
                            ycchdb.HopDong = _ctctdb.HopDong;
                            ycchdb.HoTen = _ctctdb.HoTen;
                            ycchdb.DiaChi = _ctctdb.DiaChi;
                            ycchdb.LyDo = _ctctdb.LyDo;
                            ycchdb.GhiChuLyDo = _ctctdb.GhiChuLyDo;
                            ycchdb.SoTien = _ctctdb.SoTien;
                            ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                            HOADON hoadon = _cThuTien.GetMoiNhat(_ctctdb.DanhBo);
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
                                _ctctdb.DaLapPhieu = true;
                                _ctctdb.SoPhieu = ycchdb.MaYCCHDB;
                                _ctctdb.NgayLapPhieu = ycchdb.CreateDate;
                                _ctctdb.HieuLucKy = ycchdb.HieuLucKy;
                                _ctctdb.PhieuDuocKy = true;
                                ///
                                _ctctdb.NgayXuLy = DateTime.Now;
                                _ctctdb.NoiDungXuLy = "Lập phiếu hủy DB";
                                _ctctdb.CreateDate_NgayXuLy = DateTime.Now;
                                _cCHDB.SuaCTCTDB(_ctctdb);

                                GhiChuCHDB ghichu = new GhiChuCHDB();
                                ghichu.NgayLap = _ctctdb.NgayXuLy;
                                ghichu.NoiDung = _ctctdb.NoiDungXuLy;
                                ghichu.MaCTCTDB = _ctctdb.MaCTCTDB;
                                if (_cCHDB.ThemGhiChu(ghichu))
                                {
                                    dgvGhiChu.DataSource = _cCHDB.GetDSGhiChuByMaCTCTDB(_ctctdb.MaCTCTDB);
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

                                if (ycchdb.MaDon != null)
                                    dr["MaDon"] = ycchdb.MaDon.ToString().Insert(ycchdb.MaDon.ToString().Length - 2, "-");
                                else
                                    if (ycchdb.MaDonTXL != null)
                                        dr["MaDon"] = "TXL" + ycchdb.MaDonTXL.ToString().Insert(ycchdb.MaDonTXL.ToString().Length - 2, "-");
                                    else
                                        if (ycchdb.MaDonTBC != null)
                                            dr["MaDon"] = "TBC" + ycchdb.MaDonTBC.ToString().Insert(ycchdb.MaDonTBC.ToString().Length - 2, "-");

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
                                PhieuCHDB ycchdb = new PhieuCHDB();
                                if (_ctctdb.CHDB.MaDon != null)
                                    ycchdb.MaDon = _ctctdb.CHDB.MaDon;
                                else
                                    if (_ctctdb.CHDB.MaDonTXL != null)
                                        ycchdb.MaDonTXL = _ctctdb.CHDB.MaDonTXL;
                                    else
                                        if (_ctctdb.CHDB.MaDonTBC != null)
                                            ycchdb.MaDonTBC = _ctctdb.CHDB.MaDonTBC;

                                ycchdb.TBCTDB = true;
                                ycchdb.MaCTCTDB = _ctctdb.MaCTCTDB;
                                ycchdb.DanhBo = _ctctdb.DanhBo;
                                ycchdb.HopDong = _ctctdb.HopDong;
                                ycchdb.HoTen = _ctctdb.HoTen;
                                ycchdb.DiaChi = _ctctdb.DiaChi;
                                ycchdb.LyDo = _ctctdb.LyDo;
                                ycchdb.GhiChuLyDo = _ctctdb.GhiChuLyDo;
                                ycchdb.SoTien = _ctctdb.SoTien;
                                ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                                HOADON hoadon = _cThuTien.GetMoiNhat(_ctctdb.DanhBo);
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
                                    _ctctdb.DaLapPhieu = true;
                                    _ctctdb.SoPhieu = ycchdb.MaYCCHDB;
                                    _ctctdb.HieuLucKy = ycchdb.HieuLucKy;
                                    _ctctdb.NgayLapPhieu = ycchdb.CreateDate;
                                    _ctctdb.PhieuDuocKy = true;
                                    _cCHDB.SuaCTCTDB(_ctctdb);

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

                                    if (ycchdb.MaDon != null)
                                        dr["MaDon"] = ycchdb.MaDon.ToString().Insert(ycchdb.MaDon.ToString().Length - 2, "-");
                                    else
                                        if (ycchdb.MaDonTXL != null)
                                            dr["MaDon"] = "TXL" + ycchdb.MaDonTXL.ToString().Insert(ycchdb.MaDonTXL.ToString().Length - 2, "-");
                                        else
                                            if (ycchdb.MaDonTBC != null)
                                                dr["MaDon"] = "TBC" + ycchdb.MaDonTBC.ToString().Insert(ycchdb.MaDonTBC.ToString().Length - 2, "-");

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
                            PhieuCHDB ycchdb = _cCHDB.GetPhieuHuyByMaCTCTDB(_ctctdb.MaCTCTDB);
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

                            if (ycchdb.MaDon != null)
                                dr["MaDon"] = ycchdb.MaDon.ToString().Insert(ycchdb.MaDon.ToString().Length - 2, "-");
                            else
                                if (ycchdb.MaDonTXL != null)
                                    dr["MaDon"] = "TXL" + ycchdb.MaDonTXL.ToString().Insert(ycchdb.MaDonTXL.ToString().Length - 2, "-");
                                else
                                    if (ycchdb.MaDonTBC != null)
                                        dr["MaDon"] = "TBC" + ycchdb.MaDonTBC.ToString().Insert(ycchdb.MaDonTBC.ToString().Length - 2, "-");

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
                            dgvGhiChu.DataSource = _cCHDB.GetDSGhiChuByMaCTCTDB(_ctctdb.MaCTCTDB);
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

        private void dgvLichSuXuLy_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvGhiChu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvLichSuXuLy_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvGhiChu.CurrentCell = dgvGhiChu.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvLichSuXuLy_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && (_ctctdb != null))
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

                                CTCTDB ctctdb = new CTCTDB();
                                ctctdb.MaCHDB = chdb.MaCHDB;
                                txtDanhBo.Text = hoadon.DANHBA;
                                txtHopDong.Text = hoadon.HOPDONG;
                                txtHoTen.Text = hoadon.TENKH;
                                txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);

                                if (hoadon != null)
                                {
                                    ctctdb.Dot = hoadon.DOT.ToString();
                                    ctctdb.Ky = hoadon.KY.ToString();
                                    ctctdb.Nam = hoadon.NAM.ToString();
                                }
                                ctctdb.LyDo = cmbLyDo.SelectedValue.ToString();
                                ctctdb.GhiChuLyDo = txtGhiChu.Text.Trim();
                                if (txtSoTien.Text.Trim() != "")
                                    ctctdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                                ctctdb.NoiDung = ((LyDoCHDB)cmbLyDo.SelectedItem).NoiDung;
                                ctctdb.NoiNhan = ((LyDoCHDB)cmbLyDo.SelectedItem).NoiNhan + "\r\n(" + itemMa.Text.Insert(itemMa.Text.Length - 2, "-") + ")";

                                ///Ký Tên
                                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                    ctctdb.ChucVu = "GIÁM ĐỐC";
                                else
                                    ctctdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                ctctdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                ctctdb.ThongBaoDuocKy = true;

                                _cCHDB.ThemCTCTDB(ctctdb);
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

                                    CTCTDB ctctdb = new CTCTDB();
                                    ctctdb.MaCHDB = chdb.MaCHDB;
                                    txtDanhBo.Text = hoadon.DANHBA;
                                    txtHopDong.Text = hoadon.HOPDONG;
                                    txtHoTen.Text = hoadon.TENKH;
                                    txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);

                                    if (hoadon != null)
                                    {
                                        ctctdb.Dot = hoadon.DOT.ToString();
                                        ctctdb.Ky = hoadon.KY.ToString();
                                        ctctdb.Nam = hoadon.NAM.ToString();
                                    }
                                    ctctdb.LyDo = cmbLyDo.SelectedValue.ToString();
                                    ctctdb.GhiChuLyDo = txtGhiChu.Text.Trim();
                                    if (txtSoTien.Text.Trim() != "")
                                        ctctdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                                    ctctdb.NoiDung = ((LyDoCHDB)cmbLyDo.SelectedItem).NoiDung;
                                    ctctdb.NoiNhan = ((LyDoCHDB)cmbLyDo.SelectedItem).NoiNhan + "\r\n(TXL" + itemMa.Text.Insert(itemMa.Text.Length - 2, "-") + ")";

                                    ///Ký Tên
                                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                        ctctdb.ChucVu = "GIÁM ĐỐC";
                                    else
                                        ctctdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                    ctctdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                    ctctdb.ThongBaoDuocKy = true;

                                    _cCHDB.ThemCTCTDB(ctctdb);
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
            if (_ctctdb != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                //dr["SoPhieu"] = _ctctdb.MaCTCTDB.ToString().Insert(_ctctdb.MaCTCTDB.ToString().Length - 2, "-");
                dr["HoTen"] = _ctctdb.HoTen;
                dr["DiaChi"] = _ctctdb.DiaChi;
                if (!string.IsNullOrEmpty(_ctctdb.DanhBo))
                    dr["DanhBo"] = _ctctdb.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["HopDong"] = _ctctdb.HopDong;

                dr["ViTriDHN"] = "Vị trí ĐHN lắp đặt: " + _ctctdb.ViTriDHN1 + ", " + _ctctdb.ViTriDHN2;

                if (_ctctdb.LyDo != "Vấn Đề Khác")
                    dr["LyDo"] = _ctctdb.LyDo + ". ";
                if (_ctctdb.GhiChuLyDo != "")
                    dr["LyDo"] += _ctctdb.GhiChuLyDo + ". ";
                if (_ctctdb.SoTien.ToString() != "")
                    dr["LyDo"] += "Tổng Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", _ctctdb.SoTien);
                dr["NoiDung"] = _ctctdb.NoiDung;

                dr["NoiNhan"] = _ctctdb.NoiNhan + "\r\nTB" + _ctctdb.MaCTCTDB.ToString().Insert(_ctctdb.MaCTCTDB.ToString().Length - 2, "-");

                if (_ctctdb.NgayXuLy!=null)
                    dr["NgayXuLy"] = _ctctdb.NgayXuLy.Value.ToString("dd/MM/yyyy") + " : " + _ctctdb.NoiDungXuLy;

                dr["ChucVu"] = _ctctdb.ChucVu;
                dr["NguoiKy"] = _ctctdb.NguoiKy;

                dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                rptThongBaoCTDB rpt = new rptThongBaoCTDB();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        

    }
}

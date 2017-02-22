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

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmCHDB : Form
    {
        string _mnu = "mnuCHDB";
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        HOADON _hoadon = null;
        CTCHDB _ctchdb = null;
        CTCTDB _ctctdb = null;
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CCHDB _cCHDB = new CCHDB();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CLyDoCHDB _cLyDoCHDB = new CLyDoCHDB();
        CNoiDungXuLyCHDB _cNoiDungXuLyCHDB = new CNoiDungXuLyCHDB();
        CKTXM _cKTXM = new CKTXM();
        decimal _MaCTCHDB = 0;

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

            if (_MaCTCHDB != 0)
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
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.getPhuongQuanByID(hoadon.Quan, hoadon.Phuong);
            dgvLichSuCHDB.DataSource = _cCHDB.GetLichSuCHDB(hoadon.DANHBA);
            CheckLichSuCHDB();
            CTKTXM ctktxm = null;
            if (_dontxl != null)
            {
                ctktxm = _cKTXM.getCTKTXMbyMaDonTXLDanhBo(_dontxl.MaDon, _dontxl.DanhBo);
            }
            else
                if (_donkh != null)
                {
                    ctktxm = _cKTXM.getCTKTXMbyMaDonKHDanhBo(_donkh.MaDon, _donkh.DanhBo);
                }
            if (ctktxm != null)
            {
                cmbViTriDHN1.SelectedItem = ctktxm.ViTriDHN1;
                cmbViTriDHN2.SelectedItem = ctktxm.ViTriDHN2;
            }
        }

        public void LoadCHDB(CTCHDB ctchdb)
        {
            if (!string.IsNullOrEmpty(ctchdb.CHDB.MaDonTXL.ToString()))
                txtMaDon.Text = "TXL" + ctchdb.CHDB.MaDonTXL.ToString().Insert(ctchdb.CHDB.MaDonTXL.ToString().Length - 2, "-");
            else
                if (!string.IsNullOrEmpty(ctchdb.CHDB.MaDon.ToString()))
                    txtMaDon.Text = ctchdb.CHDB.MaDon.ToString().Insert(ctchdb.CHDB.MaDon.ToString().Length - 2, "-");

            txtMaThongBaoCH.Text = ctchdb.MaCTCHDB.ToString().Insert(ctchdb.MaCTCHDB.ToString().Length - 2, "-");

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
            if (_cCHDB.CheckYeuCauCHDBbyMaCTCHDB(ctchdb.MaCTCHDB))
            {
                txtHieuLucKy.Text = ctchdb.PhieuCHDBs.LastOrDefault(itemYCCHDB => itemYCCHDB.MaCTCHDB == ctchdb.MaCTCHDB).HieuLucKy;
            }
            else
            {
                txtHieuLucKy.Text = "";
            }
        }

        public void LoadCTDB(CTCTDB ctctdb)
        {
            if (!string.IsNullOrEmpty(ctctdb.CHDB.MaDonTXL.ToString()))
            {
                _dontxl = _cDonTXL.getDonTXLbyID(ctctdb.CHDB.MaDonTXL.Value);
                txtMaDon.Text = "TXL" + ctctdb.CHDB.MaDonTXL.ToString().Insert(ctctdb.CHDB.MaDonTXL.ToString().Length - 2, "-");
            }
            else
                if (!string.IsNullOrEmpty(ctctdb.CHDB.MaDon.ToString()))
                {
                    _donkh = _cDonKH.getDonKHbyID(ctctdb.CHDB.MaDon.Value);
                    txtMaDon.Text = ctctdb.CHDB.MaDon.ToString().Insert(ctctdb.CHDB.MaDon.ToString().Length - 2, "-");
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
            txtMaDon.Text = "";
            txtMaThongBaoCH.Text = "";
            txtMaThongBaoCT.Text = "";
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
            _donkh = null;
            _dontxl = null;
            _hoadon = null;
            _ctchdb = null;
            _ctctdb = null;
            dgvGhiChu.DataSource = null;
            dgvLichSuCHDB.DataSource = null;
        }

        public void CheckLichSuCHDB()
        {
            foreach (DataGridViewRow item in dgvLichSuCHDB.Rows)
                if (item.Cells["Loai"].Value.ToString() != "Phiếu Hủy" && (item.Cells["NgayXuLy"].Value == null || string.IsNullOrEmpty(item.Cells["NgayXuLy"].Value.ToString())))
                    MessageBox.Show("Có Thông Báo chưa xử lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            //string ThongTin;
                            //if (_cCHDB.CheckCHDBbyDanhBo(_hoadon.DANHBA, out ThongTin))
                            //    MessageBox.Show("Danh Bộ này đã lập " + ThongTin, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            //string ThongTin;
                            //if (_cCHDB.CheckCHDBbyDanhBo(_hoadon.DANHBA, out ThongTin))
                            //    MessageBox.Show("Danh Bộ này đã lập " + ThongTin, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    //string ThongTin;
                    //if (_cCHDB.CheckCHDBbyDanhBo(_hoadon.DANHBA, out ThongTin))
                    //    MessageBox.Show("Danh Bộ này đã lập " + ThongTin, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaThongBaoCH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cCHDB.getCTCHDBbyID(decimal.Parse(txtMaThongBaoCH.Text.Trim().Replace("-", ""))) != null)
                {
                    _ctchdb = _cCHDB.getCTCHDBbyID(decimal.Parse(txtMaThongBaoCH.Text.Trim().Replace("-", "")));
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
                if (_cCHDB.getCTCTDBbyID(decimal.Parse(txtMaThongBaoCT.Text.Trim().Replace("-", ""))) != null)
                {
                    _ctctdb = _cCHDB.getCTCTDBbyID(decimal.Parse(txtMaThongBaoCT.Text.Trim().Replace("-", "")));
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
                txtNoiNhan.Text = vv.NoiNhan + "\r\n(" + txtMaDon.Text.Trim() + ")";

                if (cmbLyDo.SelectedValue.ToString() == "Nợ Tiền Gian Lận Nước" || cmbLyDo.SelectedValue.ToString() == "Không Thanh Toán Tiền Bồi Thường ĐHN")
                    txtSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", 1283641);
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
                    ///Nếu đơn thuộc Tổ Xử Lý
                    if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                    {
                        if (_dontxl != null && cmbLyDo.SelectedIndex != -1)
                        {
                            if (!_cCHDB.CheckCHDBbyMaDon_TXL(_dontxl.MaDon))
                            {
                                CHDB chdb = new CHDB();
                                chdb.ToXuLy = true;
                                chdb.MaDonTXL = _dontxl.MaDon;
                                if (_cCHDB.ThemCHDB(chdb))
                                {
                                }
                            }
                            if (_cCHDB.CheckCTCHDBbyMaDonDanhBo_TXL(_dontxl.MaDon, txtDanhBo.Text.Trim()))
                            {
                                MessageBox.Show("Danh Bộ này đã được Lập Cắt Hủy Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            CTCHDB ctchdb = new CTCHDB();
                            ctchdb.MaCHDB = _cCHDB.getCHDBbyMaDon_TXL(_dontxl.MaDon).MaCHDB;
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
                                    GhiChuCHDB ghichu = new GhiChuCHDB();
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
                        if (_donkh != null && cmbLyDo.SelectedIndex != -1)
                        {
                            if (!_cCHDB.CheckCHDBbyMaDon(_donkh.MaDon))
                            {
                                CHDB chdb = new CHDB();
                                chdb.MaDon = _donkh.MaDon;
                                if (_cCHDB.ThemCHDB(chdb))
                                {
                                }
                            }
                            if (_cCHDB.CheckCTCHDBbyMaDonDanhBo(_donkh.MaDon, txtDanhBo.Text.Trim()))
                            {
                                MessageBox.Show("Danh Bộ này đã được Lập Cắt Hủy Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            CTCHDB ctchdb = new CTCHDB();
                            ctchdb.MaCHDB = _cCHDB.getCHDBbyMaDon(_donkh.MaDon).MaCHDB;
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
                                    GhiChuCHDB ghichu = new GhiChuCHDB();
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
                                Clear();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtMaDon.Focus();
                            }
                        }
                        else
                            MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (_ctchdb != null)
                    try
                    {
                        _ctchdb.DanhBo = txtDanhBo.Text.Trim();
                        _ctchdb.HopDong = txtHopDong.Text.Trim();
                        _ctchdb.HoTen = txtHoTen.Text.Trim();
                        _ctchdb.DiaChi = txtDiaChi.Text.Trim();
                        if (_hoadon != null)
                        {
                            _ctchdb.Dot = _hoadon.DOT.ToString();
                            _ctchdb.Ky = _hoadon.KY.ToString();
                            _ctchdb.Nam = _hoadon.NAM.ToString();
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
                                GhiChuCHDB ghichu = new GhiChuCHDB();
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

                        //if (_ctchdb.DaLapPhieu && _ctchdb.PhieuCHDBs.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaCTCHDB == _ctchdb.MaCTCHDB).HieuLucKy != txtHieuLucKy.Text.Trim())
                        //{
                        //    PhieuCHDB ycchdb = _ctchdb.PhieuCHDBs.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaCTCHDB == _ctchdb.MaCTCHDB);
                        //    ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                        //    _cCHDB.SuaYeuCauCHDB(ycchdb);
                        //}

                        if (_cCHDB.SuaCTCHDB(_ctchdb))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMaDon.Focus();
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
                if(_ctchdb != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (_ctchdb.DaLapPhieu == true)
                    {
                        MessageBox.Show("Đã Lập Phiếu Hủy, Không xóa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if(_cCHDB.XoaCTCHDB(_ctchdb))
                    {
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaDon.Focus();
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
                    if (_ctchdb != null)
                    {
                        GhiChuCHDB item = new GhiChuCHDB();
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
                if (_ctchdb != null)
                {
                    ///Nếu Chưa Lập Phiếu
                    if (!_cCHDB.CheckYeuCauCHDBbyMaCTCHDB(_ctchdb.MaCTCHDB))
                    {
                        if (txtHieuLucKy.Text.Trim() != "")
                        {
                            PhieuCHDB ycchdb = new PhieuCHDB();
                            if (_ctchdb.CHDB.ToXuLy)
                            {
                                ycchdb.ToXuLy = true;
                                ycchdb.MaDonTXL = _ctchdb.CHDB.MaDonTXL;
                            }
                            else
                                ycchdb.MaDon = _ctchdb.CHDB.MaDon;
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

                            if (_cCHDB.ThemYeuCauCHDB(ycchdb))
                            {
                                _ctchdb.DaLapPhieu = true;
                                _ctchdb.SoPhieu = ycchdb.MaYCCHDB;
                                _ctchdb.NgayLapPhieu = ycchdb.CreateDate;
                                _ctchdb.HieuLucKy = ycchdb.HieuLucKy;
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

                                if (!string.IsNullOrEmpty(ycchdb.MaDonTXL.ToString()))
                                    dr["MaDon"] = "TXL" + ycchdb.MaDonTXL.ToString().Insert(ycchdb.MaDonTXL.ToString().Length - 2, "-");
                                else
                                    if (!string.IsNullOrEmpty(ycchdb.MaDon.ToString()))
                                        dr["MaDon"] = ycchdb.MaDon.ToString().Insert(ycchdb.MaDon.ToString().Length - 2, "-");

                                dsBaoCao.Tables["PhieuCHDB"].Rows.Add(dr);

                                rptPhieuCHDBx2 rpt = new rptPhieuCHDBx2();
                                for (int j = 0; j < rpt.Subreports.Count; j++)
                                {
                                    rpt.Subreports[j].SetDataSource(dsBaoCao);
                                }
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
                                if (_ctchdb.CHDB.ToXuLy)
                                {
                                    ycchdb.ToXuLy = true;
                                    ycchdb.MaDonTXL = _ctchdb.CHDB.MaDonTXL;
                                }
                                else
                                    ycchdb.MaDon = _ctchdb.CHDB.MaDon;
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

                                if (_cCHDB.ThemYeuCauCHDB(ycchdb))
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

                                    if (!string.IsNullOrEmpty(ycchdb.MaDonTXL.ToString()))
                                        dr["MaDon"] = "TXL" + ycchdb.MaDonTXL.ToString().Insert(ycchdb.MaDonTXL.ToString().Length - 2, "-");
                                    else
                                        if (!string.IsNullOrEmpty(ycchdb.MaDon.ToString()))
                                            dr["MaDon"] = ycchdb.MaDon.ToString().Insert(ycchdb.MaDon.ToString().Length - 2, "-");

                                    dsBaoCao.Tables["PhieuCHDB"].Rows.Add(dr);

                                    rptPhieuCHDBx2 rpt = new rptPhieuCHDBx2();
                                    for (int j = 0; j < rpt.Subreports.Count; j++)
                                    {
                                        rpt.Subreports[j].SetDataSource(dsBaoCao);
                                    }
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
                            PhieuCHDB ycchdb = _cCHDB.getYeuCauCHDBbyMaCTCHDB(_ctchdb.MaCTCHDB);
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

                            if (!string.IsNullOrEmpty(ycchdb.MaDonTXL.ToString()))
                                dr["MaDon"] = "TXL" + ycchdb.MaDonTXL.ToString().Insert(ycchdb.MaDonTXL.ToString().Length - 2, "-");
                            else
                                if (!string.IsNullOrEmpty(ycchdb.MaDon.ToString()))
                                    dr["MaDon"] = ycchdb.MaDon.ToString().Insert(ycchdb.MaDon.ToString().Length - 2, "-");

                            dsBaoCao.Tables["PhieuCHDB"].Rows.Add(dr);

                            rptPhieuCHDBx2 rpt = new rptPhieuCHDBx2();
                            for (int j = 0; j < rpt.Subreports.Count; j++)
                            {
                                rpt.Subreports[j].SetDataSource(dsBaoCao);
                            }
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
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (_cCHDB.XoaGhiChu(_cCHDB.GetGhiChuByID(decimal.Parse(dgvGhiChu.CurrentRow.Cells["ID"].Value.ToString()))))
                {
                    dgvGhiChu.DataSource = _cCHDB.GetDSGhiChuByMaCTCHDB(_ctchdb.MaCTCHDB);
                }
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
                if (radToKH.Checked)
                    foreach (ListViewItem itemMa in lstMa.Items)
                    {
                        DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));

                        if (!_cCHDB.CheckCHDBbyMaDon(donkh.MaDon))
                        {
                            CHDB chdb = new CHDB();
                            chdb.MaDon = donkh.MaDon;
                            _cCHDB.ThemCHDB(chdb);

                            HOADON hoadon = _cThuTien.GetMoiNhat(donkh.DanhBo);

                            CTCHDB ctchdb = new CTCHDB();
                            ctchdb.MaCHDB = chdb.MaCHDB;
                            ctchdb.DanhBo = hoadon.DANHBA;
                            ctchdb.HopDong = hoadon.HOPDONG;
                            ctchdb.HoTen = hoadon.TENKH;
                            ctchdb.DiaChi = hoadon.SO + " " + hoadon.DUONG + _cDocSo.getPhuongQuanByID(hoadon.Quan, hoadon.Phuong);

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
                            ctchdb.NoiDung = ((LyDoCHDB)cmbLyDo.SelectedItem).NoiDung;
                            ctchdb.NoiNhan = ((LyDoCHDB)cmbLyDo.SelectedItem).NoiNhan + "\r\n(" + itemMa.Text.Insert(itemMa.Text.Length - 2, "-") + ")";

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
                            DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));

                            if (!_cCHDB.CheckCHDBbyMaDon_TXL(dontxl.MaDon))
                            {
                                CHDB chdb = new CHDB();
                                chdb.ToXuLy = true;
                                chdb.MaDonTXL = dontxl.MaDon;
                                _cCHDB.ThemCHDB(chdb);

                                HOADON hoadon = _cThuTien.GetMoiNhat(dontxl.DanhBo);

                                CTCHDB ctchdb = new CTCHDB();
                                ctchdb.MaCHDB = chdb.MaCHDB;
                                ctchdb.DanhBo = hoadon.DANHBA;
                                ctchdb.HopDong = hoadon.HOPDONG;
                                ctchdb.HoTen = hoadon.TENKH;
                                ctchdb.DiaChi = hoadon.SO + " " + hoadon.DUONG + _cDocSo.getPhuongQuanByID(hoadon.Quan, hoadon.Phuong);

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
                                ctchdb.NoiDung = ((LyDoCHDB)cmbLyDo.SelectedItem).NoiDung;
                                ctchdb.NoiNhan = ((LyDoCHDB)cmbLyDo.SelectedItem).NoiNhan + "\r\n(TXL" + itemMa.Text.Insert(itemMa.Text.Length - 2, "-") + ")";

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
                DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(lstMa.SelectedItems[0].Text.Trim().Replace("-", "")));
                dgvLichSuCHDB.DataSource = _cCHDB.GetLichSuCHDB(donkh.DanhBo);
            }
            else
                if (radTXL.Checked)
                {
                    DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(lstMa.SelectedItems[0].Text.Trim().Replace("-", "")));
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

                dr["SoPhieu"] = _ctchdb.MaCTCHDB.ToString().Insert(_ctchdb.MaCTCHDB.ToString().Length - 2, "-");
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
                    dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", _ctchdb.SoTien);
                dr["NoiDung"] = _ctchdb.NoiDung;

                dr["NoiNhan"] = _ctchdb.NoiNhan;

                if (chkNgayXuLy.Checked)
                    dr["NgayXuLy"] = dateXuLy.Value.ToString("dd/MM/yyyy") + " : " + cmbNoiDung.SelectedItem.ToString();

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

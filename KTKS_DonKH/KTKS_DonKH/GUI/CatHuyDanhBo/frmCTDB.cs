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
using KTKS_DonKH.GUI.DonTu;
using System.Transactions;
using CrystalDecisions.CrystalReports.Engine;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmCTDB : Form
    {
        string _mnu = "mnuCTDB";
        CDonTu _cDonTu = new CDonTu();
        CThuTien _cThuTien = new CThuTien();
        CCHDB _cCHDB = new CCHDB();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CDHN _cDocSo = new CDHN();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CCHDB_LyDo _cLyDoCHDB = new CCHDB_LyDo();
        CCHDB_NoiDungXuLy _cNoiDungXuLyCHDB = new CCHDB_NoiDungXuLy();
        CKTXM _cKTXM = new CKTXM();

        DonTu_ChiTiet _dontu_ChiTiet = null;
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        CHDB_ChiTietCatTam _ctctdb = null;
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
            dgvHinh.AutoGenerateColumns = false;

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

        public void LoadCTDB(CHDB_ChiTietCatTam ctctdb)
        {
            if (ctctdb.CHDB.MaDonMoi != null)
            {
                _dontu_ChiTiet = _cDonTu.get_ChiTiet(ctctdb.CHDB.MaDonMoi.Value, ctctdb.STT.Value);
                if (_dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count == 1)
                    txtMaDonMoi.Text = ctctdb.CHDB.MaDonMoi.ToString();
                else
                    txtMaDonMoi.Text = ctctdb.CHDB.MaDonMoi.Value.ToString() + "." + ctctdb.STT.Value.ToString();
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
            txtMaThongBao.Text = ctctdb.MaCTCTDB.ToString().Insert(ctctdb.MaCTCTDB.ToString().Length - 2, "-");
            txtTCHC.Text = ctctdb.TCHC;
            ///
            txtDanhBo.Text = ctctdb.DanhBo;
            txtHopDong.Text = ctctdb.HopDong;
            txtHoTen.Text = ctctdb.HoTen;
            txtDiaChi.Text = ctctdb.DiaChi;

            ///Nội Dung Xử Lý
            chkCode68.Checked = ctctdb.Code68;
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

            ///Đã lấp Phiếu Yêu Cầu CHDB
            if (_cCHDB.CheckExist_PhieuHuyByMaCTCTDB(ctctdb.MaCTCTDB))
            {
                txtHieuLucKy.Text = ctctdb.CHDB_Phieus.Where(itemYCCHDB => itemYCCHDB.MaCTCTDB == ctctdb.MaCTCTDB).OrderByDescending(item=>item.CreateDate).First().HieuLucKy;
            }
            else
            {
                txtHieuLucKy.Text = "";
            }

            dgvHinh.Rows.Clear();
            foreach (CHDB_ChiTietCatTam_Hinh item in ctctdb.CHDB_ChiTietCatTam_Hinhs.ToList())
            {
                var index = dgvHinh.Rows.Add();
                dgvHinh.Rows[index].Cells["ID_Hinh"].Value = item.ID;
                dgvHinh.Rows[index].Cells["Name_Hinh"].Value = item.Name;
                dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(item.Hinh.ToArray());
            }

            dgvGhiChu.DataSource = _cCHDB.GetDSGhiChuByMaCTCTDB(ctctdb.MaCTCTDB);
            dgvLichSuCHDB.DataSource = _cCHDB.GetLichSuCHDB(ctctdb.DanhBo);
            CheckLichSuCHDB();
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
            chkCode68.Checked = false;
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
            _dontu_ChiTiet = null;
            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            _ctctdb = null;
            _MaCTCTDB = -1;
            dgvGhiChu.DataSource = null;
            dgvLichSuCHDB.DataSource = null;
            dgvHinh.Rows.Clear();
            txtMaDonMoi.Focus();
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
                if (MaDon.Contains(".") == true)
                {
                    string[] MaDons = MaDon.Split('.');
                    _dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(MaDons[0]), int.Parse(MaDons[1]));
                }
                else
                {
                    LinQ.DonTu dt = _cDonTu.get(int.Parse(MaDon));
                    if (dt != null)
                        _dontu_ChiTiet = dt.DonTu_ChiTiets.SingleOrDefault();
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
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaThongBao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaThongBao.Text.Trim() != "")
            {
                string MaDon = txtMaThongBao.Text.Trim();
                Clear();
                txtMaThongBao.Text = MaDon;
                _ctctdb = _cCHDB.GetCTCTDB(decimal.Parse(txtMaThongBao.Text.Trim().Replace("-", "")));
                if (_ctctdb!=null)
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
                if(txtMaDonMoi.Text.Trim()!="")
                    txtNoiNhan.Text = vv.NoiNhan + "\r\n(" + txtMaDonMoi.Text.Trim() + ")";
                else
                if (txtMaDonCu.Text.Trim() != "")
                    txtNoiNhan.Text = vv.NoiNhan + "\r\n(" + txtMaDonCu.Text.Trim() + ")";

                if (vv.SoTien!=null)
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

                    CHDB_ChiTietCatTam ctctdb = new CHDB_ChiTietCatTam();

                    if (_dontu_ChiTiet != null)
                    {
                        if (_cCHDB.checkExist(_dontu_ChiTiet.MaDon.Value) == false)
                        {
                            CHDB chdb = new CHDB();
                            chdb.MaDonMoi = _dontu_ChiTiet.MaDon.Value;
                            _cCHDB.ThemCHDB(chdb);
                        }
                        if (_cCHDB.checkExist_CatTam(_dontu_ChiTiet.MaDon.Value, txtDanhBo.Text.Trim()))
                        {
                            if (MessageBox.Show("Danh Bộ này đã được Lập Cắt Tạm Danh Bộ\nBạn có chắc muốn LẬP THÔNG BÁO MỚI???", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                                return;
                        }
                        ctctdb.MaCHDB = _cCHDB.get(_dontu_ChiTiet.MaDon.Value).MaCHDB;
                        ctctdb.STT = _dontu_ChiTiet.STT;
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
                        ctctdb.MLT = _hoadon.MALOTRINH;
                        ctctdb.Dot = _hoadon.DOT.ToString();
                        ctctdb.Ky = _hoadon.KY.ToString();
                        ctctdb.Nam = _hoadon.NAM.ToString();
                        ctctdb.Phuong = _hoadon.Phuong;
                        ctctdb.Quan = _hoadon.Quan;
                        ctctdb.Hieu = _hoadon.HIEUDH;
                        ctctdb.Co = _hoadon.CoDH;
                        ctctdb.SoThan = _hoadon.SoThanDHN;
                    }
                    ctctdb.Code68 = chkCode68.Checked;
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

                    using (TransactionScope scope = new TransactionScope())
                    if (_cCHDB.ThemCTCTDB(ctctdb))
                    {
                        foreach (DataGridViewRow item in dgvHinh.Rows)
                        {
                            CHDB_ChiTietCatTam_Hinh en = new CHDB_ChiTietCatTam_Hinh();
                            en.IDCHDB_ChiTietCatTam = ctctdb.MaCTCTDB;
                            en.Name = item.Cells["Name_Hinh"].Value.ToString();
                            en.Hinh = Convert.FromBase64String(item.Cells["Bytes_Hinh"].Value.ToString());
                            _cCHDB.Them_Hinh(en);
                        }
                        if (_dontu_ChiTiet != null)
                        {
                            if(_cDonTu.Them_LichSu(ctctdb.CreateDate.Value, "CTDB", "Đã Lập Thông Báo Đóng Nước, " + ctctdb.LyDo, (int)ctctdb.MaCTCTDB, _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value)==true)
                                scope.Complete();
                        }
                        else
                            scope.Complete();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    
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
                            _ctctdb.MLT = _hoadon.MALOTRINH;
                            _ctctdb.Dot = _hoadon.DOT.ToString();
                            _ctctdb.Ky = _hoadon.KY.ToString();
                            _ctctdb.Nam = _hoadon.NAM.ToString();
                            _ctctdb.Phuong = _hoadon.Phuong;
                            _ctctdb.Quan = _hoadon.Quan;
                            _ctctdb.Hieu = _hoadon.HIEUDH;
                            _ctctdb.Co = _hoadon.CoDH;
                            _ctctdb.SoThan = _hoadon.SoThanDHN;
                        }

                        _ctctdb.Code68 = chkCode68.Checked;
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
                                CHDB_GhiChu ghichu = new CHDB_GhiChu();
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
                            if (_dontu_ChiTiet != null)
                                _cDonTu.Them_LichSu(_ctctdb.NgayXuLy.Value, "CTDB", _ctctdb.NoiDungXuLy, (int)_ctctdb.MaCTCTDB, _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value);   
                        }
                        else
                        {
                            _ctctdb.NgayXuLy = null;
                            _ctctdb.NoiDungXuLy = null;
                            _ctctdb.CreateDate_NgayXuLy = null;
                        }

                        _ctctdb.NoiNhan = txtNoiNhan.Text.Trim();

                        //if (_ctctdb.DaLapPhieu && _ctctdb.CHDB_Phieus.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaCTCTDB == _ctctdb.MaCTCTDB).HieuLucKy != txtHieuLucKy.Text.Trim())
                        //{
                        //    CHDB_Phieu ycchdb = _ctctdb.CHDB_Phieus.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaCTCTDB == _ctctdb.MaCTCTDB);
                        //    ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                        //    _cCHDB.SuaYeuCauCHDB(ycchdb);
                        //}

                        if (_cCHDB.SuaCTCTDB(_ctctdb))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
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
                     var transactionOptions = new TransactionOptions();
                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                        {
                            DonTu_LichSu dtls = _cDonTu.get_LichSu("CHDB_ChiTietCatTam", (int)_ctctdb.MaCTCTDB);
                            if (dtls != null)
                            {
                                _cDonTu.Xoa_LichSu(dtls, true);
                            }
                            if (_cCHDB.XoaCTCTDB(_ctctdb))
                            {
                                scope.Complete();
                                scope.Dispose();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
                            }
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
                    if (_ctctdb != null && _dontu_ChiTiet == null)
                    {
                        CHDB_GhiChu ghichu = new CHDB_GhiChu();
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
                            CHDB_Phieu ycchdb = new CHDB_Phieu();
                            //if (_ctctdb.CHDB.MaDon != null)
                            //    ycchdb.MaDon = _ctctdb.CHDB.MaDon;
                            //else
                            //    if (_ctctdb.CHDB.MaDonTXL != null)
                            //        ycchdb.MaDonTXL = _ctctdb.CHDB.MaDonTXL;
                            //    else
                            //        if (_ctctdb.CHDB.MaDonTBC != null)
                            //            ycchdb.MaDonTBC = _ctctdb.CHDB.MaDonTBC;
                            ycchdb.MaCHDB = _ctctdb.MaCHDB;
                            ycchdb.STT = _ctctdb.STT;
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
                                ycchdb.Phuong = hoadon.Phuong;
                                ycchdb.Quan = hoadon.Quan;
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
                                if (_dontu_ChiTiet != null)
                                    _cDonTu.Them_LichSu(ycchdb.CreateDate.Value,"PhieuCHDB", "Đã Lập Phiếu Hủy, " + ycchdb.LyDo, (int)ycchdb.MaYCCHDB, _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value);

                                _ctctdb.DaLapPhieu = true;
                                _ctctdb.SoPhieu = ycchdb.MaYCCHDB;
                                _ctctdb.NgayLapPhieu = ycchdb.CreateDate;
                                _ctctdb.HieuLucKy = ycchdb.HieuLucKy;
                                _ctctdb.PhieuDuocKy = true;
                                ///
                                CHDB_GhiChu ghichu = new CHDB_GhiChu();
                                ghichu.NgayLap = _ctctdb.NgayXuLy;
                                ghichu.NoiDung = _ctctdb.NoiDungXuLy;
                                ghichu.MaCTCTDB = _ctctdb.MaCTCTDB;
                                if (_cCHDB.ThemGhiChu(ghichu))
                                {
                                    dgvGhiChu.DataSource = _cCHDB.GetDSGhiChuByMaCTCTDB(_ctctdb.MaCTCTDB);
                                }
                                _ctctdb.NgayXuLy = DateTime.Now;
                                _ctctdb.NoiDungXuLy = "Lập phiếu hủy DB";
                                _ctctdb.CreateDate_NgayXuLy = DateTime.Now;
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
                                dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;

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

                                DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                                dsBaoCao.Tables["DSHoaDon"].Rows.Add(drLogo);

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
                                //if (_ctctdb.CHDB.MaDon != null)
                                //    ycchdb.MaDon = _ctctdb.CHDB.MaDon;
                                //else
                                //    if (_ctctdb.CHDB.MaDonTXL != null)
                                //        ycchdb.MaDonTXL = _ctctdb.CHDB.MaDonTXL;
                                //    else
                                //        if (_ctctdb.CHDB.MaDonTBC != null)
                                //            ycchdb.MaDonTBC = _ctctdb.CHDB.MaDonTBC;
                                ycchdb.MaCHDB = _ctctdb.MaCHDB;
                                ycchdb.STT = _ctctdb.STT;
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
                                    ycchdb.Phuong = hoadon.Phuong;
                                    ycchdb.Quan = hoadon.Quan;
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
                                        dr["LyDo"] += "Tổng Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ycchdb.SoTien);

                                    dr["ChucVu"] = ycchdb.ChucVu;
                                    dr["NguoiKy"] = ycchdb.NguoiKy;
                                    dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;

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
                                    DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                                    drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                                    dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(drLogo);

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
                            CHDB_Phieu ycchdb = _cCHDB.GetPhieuHuyByMaCTCTDB(_ctctdb.MaCTCTDB);
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
                            dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;

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
                            DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                            drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                            dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(drLogo);

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

                                CHDB_ChiTietCatTam ctctdb = new CHDB_ChiTietCatTam();
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
                                ctctdb.Code68 = chkCode68.Checked;
                                ctctdb.LyDo = cmbLyDo.SelectedValue.ToString();
                                ctctdb.GhiChuLyDo = txtGhiChu.Text.Trim();
                                if (txtSoTien.Text.Trim() != "")
                                    ctctdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                                ctctdb.NoiDung = ((CHDB_LyDo)cmbLyDo.SelectedItem).NoiDung;
                                ctctdb.NoiNhan = ((CHDB_LyDo)cmbLyDo.SelectedItem).NoiNhan + "\r\n(" + itemMa.Text.Insert(itemMa.Text.Length - 2, "-") + ")";

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

                                    CHDB_ChiTietCatTam ctctdb = new CHDB_ChiTietCatTam();
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
                                    ctctdb.NoiDung = ((CHDB_LyDo)cmbLyDo.SelectedItem).NoiDung;
                                    ctctdb.NoiNhan = ((CHDB_LyDo)cmbLyDo.SelectedItem).NoiNhan + "\r\n(TXL" + itemMa.Text.Insert(itemMa.Text.Length - 2, "-") + ")";

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
                dr["Quan"] = _cCHDB.getTenQuan(int.Parse(_ctctdb.Quan));
                dr["Phuong"] = _cCHDB.getTenPhuong(int.Parse(_ctctdb.Quan), int.Parse(_ctctdb.Phuong));

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
                dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;

                dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(drLogo);

                rptThongBaoCTDB rpt = new rptThongBaoCTDB();
                rpt.SetDataSource(dsBaoCao);
                rpt.Subreports[0].SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void frmCTDB_KeyUp(object sender, KeyEventArgs e)
        {
            if (_dontu_ChiTiet != null && e.Control && e.KeyCode == Keys.T)
            {
                frmCapNhatDonTu_Thumbnail frm = new frmCapNhatDonTu_Thumbnail(_dontu_ChiTiet);
                frm.ShowDialog();
            }
        }

        //add file
        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //ListViewItem item = new ListViewItem();
                    //item.ImageKey = "file";
                    //item.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    //item.SubItems.Add(Convert.ToBase64String(bytes));
                    //lstVFile.Items.Add(item);
                    byte[] bytes = System.IO.File.ReadAllBytes(dialog.FileName);
                    if (_ctctdb == null)
                    {
                        var index = dgvHinh.Rows.Add();
                        dgvHinh.Rows[index].Cells["Name_Hinh"].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(bytes);
                    }
                    else
                    {
                        if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                        {
                            CHDB_ChiTietCatTam_Hinh en = new CHDB_ChiTietCatTam_Hinh();
                            en.IDCHDB_ChiTietCatTam = _ctctdb.MaCTCTDB;
                            en.Name = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            en.Hinh = bytes;
                            if (_cCHDB.Them_Hinh(en) == true)
                            {
                                _cCHDB.Refresh();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                var index = dgvHinh.Rows.Add();
                                dgvHinh.Rows[index].Cells["Name_Hinh"].Value = en.Name;
                                dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(bytes);
                            }
                        }
                        else
                            MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvHinh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                dgvHinh.CurrentCell = dgvHinh.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvHinh_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Show(dgvHinh, new Point(e.X, e.Y));
            }
        }

        private void dgvHinh_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _cCHDB.LoadImageView(Convert.FromBase64String(dgvHinh.CurrentRow.Cells["Bytes_Hinh"].Value.ToString()));
        }

        private void xoaFile_dgvHinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctctdb == null)
                    dgvHinh.Rows.RemoveAt(dgvHinh.CurrentRow.Index);
                else
                    if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (dgvHinh.CurrentRow.Cells["ID_Hinh"].Value != null)
                                if (_cCHDB.Xoa_Hinh(_cCHDB.get_CatTam_Hinh(int.Parse(dgvHinh.CurrentRow.Cells["ID_Hinh"].Value.ToString()))))
                                {
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgvHinh.Rows.RemoveAt(dgvHinh.CurrentRow.Index);
                                }
                                else
                                    MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInThongBaoMoi_Click(object sender, EventArgs e)
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
                dr["MLT"] = _ctctdb.MLT;
                dr["Quan"] = _cCHDB.getTenQuan(int.Parse(_ctctdb.Quan));
                dr["Phuong"] = _cCHDB.getTenPhuong(int.Parse(_ctctdb.Quan), int.Parse(_ctctdb.Phuong));

                dr["ViTriDHN"] = "Vị trí ĐHN lắp đặt: " + _ctctdb.ViTriDHN1 + ", " + _ctctdb.ViTriDHN2;

                if (_ctctdb.LyDo != "Vấn Đề Khác")
                    dr["LyDo"] = _ctctdb.LyDo + ". ";
                if (_ctctdb.GhiChuLyDo != "")
                    dr["LyDo"] += _ctctdb.GhiChuLyDo + ". ";
                if (_ctctdb.SoTien.ToString() != "")
                    dr["LyDo"] += "Tổng Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", _ctctdb.SoTien);
                dr["NoiDung"] = _ctctdb.NoiDung;

                dr["NoiNhan"] = _ctctdb.NoiNhan + "\r\nTB" + _ctctdb.MaCTCTDB.ToString().Insert(_ctctdb.MaCTCTDB.ToString().Length - 2, "-");

                dr["NgayXuLy"] = _cDonTu.GetToDate(_ctctdb.CreateDate.Value, 10).ToString("dd/MM/yyyy");

                dr["ChucVu"] = _ctctdb.ChucVu;
                dr["NguoiKy"] = _ctctdb.NguoiKy;
                dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;

                dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(drLogo);

                ReportDocument rpt;
                //if (_ctctdb.LyDo.Contains("Nhiều Kỳ") == true)
                //    rpt = new rptThongBaoCHDB_NoNhieuKy();
                //else
                    rpt = new rptThongBaoCTDB_PHT();
                rpt.SetDataSource(dsBaoCao);
                rpt.Subreports[0].SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void btnInThongBaoMoi_BoQuan_Click(object sender, EventArgs e)
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
                dr["MLT"] = _ctctdb.MLT;
                dr["Quan"] = _cCHDB.getTenQuan(int.Parse(_ctctdb.Quan));
                dr["Phuong"] = _cCHDB.getTenPhuong(int.Parse(_ctctdb.Quan), int.Parse(_ctctdb.Phuong));

                dr["ViTriDHN"] = "Vị trí ĐHN lắp đặt: " + _ctctdb.ViTriDHN1 + ", " + _ctctdb.ViTriDHN2;

                if (_ctctdb.LyDo != "Vấn Đề Khác")
                    dr["LyDo"] = _ctctdb.LyDo + ". ";
                if (_ctctdb.GhiChuLyDo != "")
                    dr["LyDo"] += _ctctdb.GhiChuLyDo + ". ";
                if (_ctctdb.SoTien.ToString() != "")
                    dr["LyDo"] += "Tổng Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", _ctctdb.SoTien);
                dr["NoiDung"] = _ctctdb.NoiDung;

                dr["NoiNhan"] = _ctctdb.NoiNhan + "\r\nTB" + _ctctdb.MaCTCTDB.ToString().Insert(_ctctdb.MaCTCTDB.ToString().Length - 2, "-");

                dr["NgayXuLy"] = _cDonTu.GetToDate(_ctctdb.CreateDate.Value, 10).ToString("dd/MM/yyyy");

                dr["ChucVu"] = _ctctdb.ChucVu;
                dr["NguoiKy"] = _ctctdb.NguoiKy;
                dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;

                dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(drLogo);

                ReportDocument rpt;
                //if (_ctctdb.LyDo.Contains("Nhiều Kỳ") == true)
                //    rpt = new rptThongBaoCHDB_NoNhieuKy();
                //else
                rpt = new rptThongBaoCTDB_PHT_BoQuan();
                rpt.SetDataSource(dsBaoCao);
                rpt.Subreports[0].SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        

    }
}

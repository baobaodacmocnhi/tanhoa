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
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.GUI.HeThong;
using System.Transactions;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmKTXM : Form
    {
        string _mnu = "mnuNhapKQKTXM";
        CDonTu _cDonTu = new CDonTu();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CThuTien _cThuTien = new CThuTien();
        CKTXM _cKTXM = new CKTXM();
        CDocSo _cDocSo = new CDocSo();
        CHienTrangKiemTra _cHienTrangKiemTra = new CHienTrangKiemTra();

        DonTu_ChiTiet _dontu_ChiTiet = null;
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        KTXM_ChiTiet _ctktxm = null;
        bool _flagFirst = true;
        decimal _MaCTKTXM = -1;

        public frmKTXM()
        {
            InitializeComponent();
        }

        public frmKTXM(decimal MaCTKTXM)
        {
            _MaCTKTXM = MaCTKTXM;
            InitializeComponent();
        }

        private void frmKTXM_Load(object sender, EventArgs e)
        {
            //add image file to listview
            //ImageList imageList = new ImageList();
            //imageList.Images.Add("file", (Image)Properties.Resources.file_24x24);
            //lstVFile.SmallImageList = imageList;

            dgvDSKetQuaKiemTra.AutoGenerateColumns = false;
            dgvBangGia.AutoGenerateColumns = false;
            dgvHinh.AutoGenerateColumns = false;
            string To = "";
            if (CTaiKhoan.ToTB == true)
                To = "ToTB";
            else if (CTaiKhoan.ToTP == true)
                To = "ToTP";
            else if (CTaiKhoan.ToBC == true)
                To = "ToBC";
            cmbHienTrangKiemTra.DataSource = _cHienTrangKiemTra.getDS(To);
            cmbHienTrangKiemTra.DisplayMember = "TenHTKT";
            cmbHienTrangKiemTra.ValueMember = "TenHTKT";
            cmbHienTrangKiemTra.SelectedIndex = -1;

            DataTable dt1 = _cKTXM.getDS_DonGia();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (DataRow item in dt1.Rows)
            {
                auto1.Add(item["Name"].ToString() + " : " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(item["SoTien"].ToString())));
            }
            txtDonGia.AutoCompleteCustomSource = auto1;

            _flagFirst = false;

            if (_MaCTKTXM != -1)
            {
                _ctktxm = _cKTXM.GetCT(_MaCTKTXM);
                LoadCTKTXM(_ctktxm);
            }
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHopDong.Text = hoadon.HOPDONG;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG;
            //txtDienThoai.Text = _donkh.DienThoai;
            txtGiaBieu.Text = hoadon.GB.ToString();
            txtDinhMuc.Text = hoadon.DM.ToString();
            string a, b, c;
            _cDocSo.GetDHN(txtDanhBo.Text.Trim(), out a, out b, out c);
            txtHieu.Text = a;
            txtCo.Text = b;
            txtSoThan.Text = c;
        }

        public void LoadCTKTXM(KTXM_ChiTiet ctktxm)
        {
            if (ctktxm.KTXM.MaDonMoi != null)
            {
                _dontu_ChiTiet = _cDonTu.get_ChiTiet(ctktxm.KTXM.MaDonMoi.Value, ctktxm.STT.Value);
                if (_dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count == 1)
                    txtMaDonMoi.Text = ctktxm.KTXM.MaDonMoi.ToString();
                else
                    txtMaDonMoi.Text = ctktxm.KTXM.MaDonMoi.Value.ToString() + "." + ctktxm.STT.Value.ToString();
            }
            else
                if (ctktxm.KTXM.MaDon != null)
                {
                    _dontkh = _cDonKH.Get(ctktxm.KTXM.MaDon.Value);
                    txtMaDonCu.Text = ctktxm.KTXM.MaDon.ToString().Insert(ctktxm.KTXM.MaDon.ToString().Length - 2, "-");
                }
                else
                    if (ctktxm.KTXM.MaDonTXL != null)
                    {
                        _dontxl = _cDonTXL.Get(ctktxm.KTXM.MaDonTXL.Value);
                        txtMaDonCu.Text = "TXL" + ctktxm.KTXM.MaDonTXL.ToString().Insert(ctktxm.KTXM.MaDonTXL.ToString().Length - 2, "-");
                    }
                    else
                        if (ctktxm.KTXM.MaDonTBC != null)
                        {
                            _dontbc = _cDonTBC.Get(ctktxm.KTXM.MaDonTBC.Value);
                            txtMaDonCu.Text = "TBC" + ctktxm.KTXM.MaDonTBC.ToString().Insert(ctktxm.KTXM.MaDonTBC.ToString().Length - 2, "-");
                        }
            txtDanhBo.Text = ctktxm.DanhBo;
            txtHopDong.Text = ctktxm.HopDong;
            txtHoTen.Text = ctktxm.HoTen;
            txtDiaChi.Text = ctktxm.DiaChi;
            txtGiaBieu.Text = ctktxm.GiaBieu;
            txtDinhMuc.Text = ctktxm.DinhMuc;
            if (ctktxm.DinhMucMoi != null)
                txtDinhMucMoi.Text = ctktxm.DinhMucMoi.Value.ToString();
            ///
            chkNgayKTXMTruocNgayGiao.Checked = ctktxm.NgayKTXM_Truoc_NgayGiao;
            dateKTXM.Value = ctktxm.NgayKTXM.Value;
            if (ctktxm.HienTrangKiemTra != null)
                cmbHienTrangKiemTra.SelectedValue = ctktxm.HienTrangKiemTra;
            cmbViTriDHN1.SelectedItem = ctktxm.ViTriDHN1;
            cmbViTriDHN2.SelectedItem = ctktxm.ViTriDHN2;
            ///
            txtHieu.Text = ctktxm.Hieu;
            txtCo.Text = ctktxm.Co;
            txtSoThan.Text = ctktxm.SoThan;
            txtChiSo.Text = ctktxm.ChiSo;
            cmbTinhTrangChiSo.SelectedItem = ctktxm.TinhTrangChiSo;
            cmbChiMatSo.SelectedItem = ctktxm.ChiMatSo;
            cmbChiKhoaGoc.SelectedItem = ctktxm.ChiKhoaGoc;
            txtMucDichSuDung.Text = ctktxm.MucDichSuDung;
            txtDienThoai.Text = ctktxm.DienThoai;
            txtHoTenKHKy.Text = ctktxm.HoTenKHKy;
            txtTheoYeuCau.Text = ctktxm.TheoYeuCau;
            txtNoiDungKiemTra.Text = ctktxm.NoiDungKiemTra;
            if (ctktxm.TieuThuTrungBinh != null)
                txtTieuThuTrungBinh.Text = ctktxm.TieuThuTrungBinh.Value.ToString();
            if (ctktxm.NoiDungBaoThay != null)
            {
                cmbNoiDungBaoThay.SelectedText = ctktxm.NoiDungBaoThay;
                txtGhiChuNoiDungBaoThay.Text = ctktxm.GhiChuNoiDungBaoThay;
            }
            dgvBangGia.Rows.Clear();
            foreach (KTXM_BangGia item in ctktxm.KTXM_BangGias.ToList())
            {
                var index = dgvBangGia.Rows.Add();
                dgvBangGia.Rows[index].Cells["IDCTKTXM"].Value = item.IDCTKTXM;
                dgvBangGia.Rows[index].Cells["IDDonGia"].Value = item.IDDonGia;
                dgvBangGia.Rows[index].Cells["Namee"].Value = item.KTXM_DonGia.Name;
                dgvBangGia.Rows[index].Cells["SoTien"].Value = item.KTXM_DonGia.SoTien;
            }
            LoaddgvBangGia();
            dgvHinh.Rows.Clear();
            foreach (KTXM_ChiTiet_Hinh item in ctktxm.KTXM_ChiTiet_Hinhs.ToList())
            {
                var index = dgvHinh.Rows.Add();
                dgvHinh.Rows[index].Cells["ID_Hinh"].Value = item.ID;
                dgvHinh.Rows[index].Cells["Name_Hinh"].Value = item.Name;
                dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(item.Hinh.ToArray());
            }
        }

        public void Clear()
        {
            txtMaDonCu.Text = "";
            txtMaDonMoi.Text = "";
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDinhMucMoi.Text = "";
            ///
            chkNgayKTXMTruocNgayGiao.Checked = false;
            //dateKTXM.Value = DateTime.Now;
            //cmbTinhTrangKiemTra.SelectedIndex = -1;
            cmbViTriDHN1.SelectedIndex = -1;
            cmbViTriDHN2.SelectedIndex = -1;
            txtHieu.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            txtChiSo.Text = "";
            cmbTinhTrangChiSo.SelectedIndex = -1;
            //cmbChiMatSo.SelectedIndex = -1;
            //cmbChiKhoaGoc.SelectedIndex = -1;
            txtMucDichSuDung.Text = "";
            txtDienThoai.Text = "";
            txtHoTenKHKy.Text = "";
            txtNoiDungKiemTra.Text = "";
            txtTheoYeuCau.Text = "";
            txtTieuThuTrungBinh.Text = "0";
            cmbNoiDungBaoThay.SelectedIndex = -1;
            txtGhiChuNoiDungBaoThay.Text = "";

            _MaCTKTXM = -1;
            _ctktxm = null;
            _dontu_ChiTiet = null;
            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            dgvDSKetQuaKiemTra.DataSource = null;
            dgvBangGia.Rows.Clear();
            dgvHinh.Rows.Clear();
            txtMaDonMoi.Focus();
        }

        public void Clear_LoadDSKTXM()
        {
            txtMaDonCu.Text = "";
            txtMaDonMoi.Text = "";
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDinhMucMoi.Text = "";
            ///
            //dateKTXM.Value = DateTime.Now;
            //cmbTinhTrangKiemTra.SelectedIndex = -1;
            cmbViTriDHN1.SelectedIndex = -1;
            cmbViTriDHN2.SelectedIndex = -1;
            txtHieu.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            txtChiSo.Text = "";
            cmbTinhTrangChiSo.SelectedIndex = -1;
            //cmbChiMatSo.SelectedIndex = -1;
            //cmbChiKhoaGoc.SelectedIndex = -1;
            txtMucDichSuDung.Text = "";
            txtDienThoai.Text = "";
            txtHoTenKHKy.Text = "";
            txtNoiDungKiemTra.Text = "";
            txtTheoYeuCau.Text = "";
            txtTieuThuTrungBinh.Text = "0";
            cmbNoiDungBaoThay.SelectedIndex = -1;
            txtGhiChuNoiDungBaoThay.Text = "";

            _MaCTKTXM = -1;
            _ctktxm = null;
            _hoadon = null;
            
            dgvBangGia.Rows.Clear();
            dgvHinh.Rows.Clear();
            txtMaDonMoi.Focus();
        }

        public void LoadDSKTXM()
        {
            if (_dontu_ChiTiet != null)
                dgvDSKetQuaKiemTra.DataSource = _cKTXM.getDS("", _dontu_ChiTiet.MaDon.Value);
            else
                if (_dontkh != null)
                    dgvDSKetQuaKiemTra.DataSource = _cKTXM.getDS("TKH", _dontkh.MaDon);
                else
                    if (_dontxl != null)
                        dgvDSKetQuaKiemTra.DataSource = _cKTXM.getDS("TXL", _dontxl.MaDon);
                    else
                        if (_dontbc != null)
                            dgvDSKetQuaKiemTra.DataSource = _cKTXM.getDS("TBC", _dontbc.MaDon);
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

                        LoadDSKTXM();

                        MessageBox.Show("Mã Đơn TXL này có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDanhBo.Focus();
                    }
                    else
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    ///Đơn Tổ Bấm Chì
                    if (txtMaDonCu.Text.Trim().ToUpper().Contains("TBC"))
                    {
                        if (_cDonTBC.CheckExist(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", ""))) == true)
                        {
                            _dontbc = _cDonTBC.Get(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                            txtMaDonCu.Text = "TBC" + _dontbc.MaDon.ToString().Insert(_dontbc.MaDon.ToString().Length - 2, "-");

                            LoadDSKTXM();

                            MessageBox.Show("Mã Đơn TBC này có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDanhBo.Focus();
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

                            LoadDSKTXM();

                            MessageBox.Show("Mã Đơn TKH này có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDanhBo.Focus();
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
                    _dontu_ChiTiet = _cDonTu.get(int.Parse(MaDon)).DonTu_ChiTiets.SingleOrDefault();
                }
                //
                if (_dontu_ChiTiet != null)
                {
                    if (_dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count() == 1)
                        txtMaDonMoi.Text = _dontu_ChiTiet.MaDon.Value.ToString();
                    else
                        txtMaDonMoi.Text = _dontu_ChiTiet.MaDon.Value.ToString() + "." + _dontu_ChiTiet.STT.Value.ToString();
                    LoadDSKTXM();
                    MessageBox.Show("Mã Đơn này có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDanhBo.Focus();
                    //_hoadon = _cThuTien.GetMoiNhat(_dontu_ChiTiet.DanhBo);
                    //if (_hoadon != null)
                    //{
                    //    LoadTTKH(_hoadon);
                    //}
                    //else
                    //    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    if (!txtDanhBo.Text.Trim().Contains("GM"))
                        if ((txtDanhBo.Text.Trim().Length > 0 && txtDanhBo.Text.Trim().Length < 11) || txtDanhBo.Text.Trim().Length > 11)
                        {
                            MessageBox.Show("Lỗi Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    //if ((cmbHienTrangKiemTra.SelectedValue.ToString().Contains("BB") && cmbHienTrangKiemTra.SelectedValue.ToString() != "BB tái lập Danh Bộ") || cmbHienTrangKiemTra.SelectedValue.ToString() == "Hóa Đơn = 0")
                    //    if (txtHoTenKHKy.Text.Trim() == "")
                    //    {
                    //        MessageBox.Show("Thiếu Tên Khách Hàng Ký", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //    }
                    if (txtHoTen.Text.Trim() == "" || txtDiaChi.Text.Trim() == "" || txtNoiDungKiemTra.Text.Trim() == "")
                    {
                        MessageBox.Show("Chưa đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //if (CTaiKhoan.ToXL == true && txtDienThoai.Text.Trim() == "")
                    //{
                    //    MessageBox.Show("Thiếu điện thoại Khách Hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}

                    KTXM_ChiTiet ctktxm = new KTXM_ChiTiet();

                    if (_dontu_ChiTiet != null)
                    {
                        if (_cKTXM.checkExist(_dontu_ChiTiet.MaDon.Value) == false)
                        {
                            KTXM ktxm = new KTXM();
                            ktxm.MaDonMoi = _dontu_ChiTiet.MaDon.Value;
                            _cKTXM.Them(ktxm);
                        }
                        if (txtDanhBo.Text.Trim() != "" && _cKTXM.checkExist_ChiTiet(CTaiKhoan.MaUser, _dontu_ChiTiet.MaDon.Value, txtDanhBo.Text.Trim(), dateKTXM.Value) == true)
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Nội Dung Kiểm Tra", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ctktxm.MaKTXM = _cKTXM.get(_dontu_ChiTiet.MaDon.Value).MaKTXM;
                        ctktxm.STT = _dontu_ChiTiet.STT;
                    }
                    else
                        if (_dontkh != null)
                        {
                            if (_cKTXM.CheckExist("TKH", _dontkh.MaDon) == false)
                            {
                                KTXM ktxm = new KTXM();
                                ktxm.MaDon = _dontkh.MaDon;
                                _cKTXM.Them(ktxm);
                            }
                            if (txtDanhBo.Text.Trim() != "" && _cKTXM.CheckExist_CT("TKH", CTaiKhoan.MaUser, _dontkh.MaDon, txtDanhBo.Text.Trim(), dateKTXM.Value) == true)
                            {
                                MessageBox.Show("Danh Bộ này đã được Lập Nội Dung Kiểm Tra", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            ctktxm.MaKTXM = _cKTXM.Get("TKH", _dontkh.MaDon).MaKTXM;
                        }
                        else
                            if (_dontxl != null)
                            {
                                if (_cKTXM.CheckExist("TXL", _dontxl.MaDon) == false)
                                {
                                    KTXM ktxm = new KTXM();
                                    ktxm.MaDonTXL = _dontxl.MaDon;
                                    _cKTXM.Them(ktxm);
                                }
                                if (txtDanhBo.Text.Trim() != "" && _cKTXM.CheckExist_CT("TXL", CTaiKhoan.MaUser, _dontxl.MaDon, txtDanhBo.Text.Trim(), dateKTXM.Value) == true)
                                {
                                    MessageBox.Show("Danh Bộ này đã được Lập Nội Dung Kiểm Tra", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                ctktxm.MaKTXM = _cKTXM.Get("TXL", _dontxl.MaDon).MaKTXM;
                            }
                            else
                                if (_dontbc != null)
                                {
                                    if (_cKTXM.CheckExist("TBC", _dontbc.MaDon) == false)
                                    {
                                        KTXM ktxm = new KTXM();
                                        ktxm.MaDonTBC = _dontbc.MaDon;
                                        _cKTXM.Them(ktxm);
                                    }
                                    if (txtDanhBo.Text.Trim() != "" && _cKTXM.CheckExist_CT("TBC", CTaiKhoan.MaUser, _dontbc.MaDon, txtDanhBo.Text.Trim(), dateKTXM.Value) == true)
                                    {
                                        MessageBox.Show("Danh Bộ này đã được Lập Nội Dung Kiểm Tra", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    ctktxm.MaKTXM = _cKTXM.Get("TBC", _dontbc.MaDon).MaKTXM;
                                }
                                else
                                {
                                    MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                    ctktxm.DanhBo = txtDanhBo.Text.Trim();
                    ctktxm.HopDong = txtHopDong.Text.Trim();
                    ctktxm.HoTen = txtHoTen.Text.Trim().ToUpper();
                    ctktxm.DiaChi = txtDiaChi.Text.Trim().ToUpper();
                    ctktxm.GiaBieu = txtGiaBieu.Text.Trim();
                    ctktxm.DinhMuc = txtDinhMuc.Text.Trim();
                    if (txtDinhMucMoi.Text.Trim() != "")
                        ctktxm.DinhMucMoi = int.Parse(txtDinhMucMoi.Text.Trim());
                    if (_hoadon != null)
                    {
                        ctktxm.Dot = _hoadon.DOT.ToString();
                        ctktxm.Ky = _hoadon.KY.ToString();
                        ctktxm.Nam = _hoadon.NAM.ToString();
                        ctktxm.Phuong = _hoadon.Phuong;
                        ctktxm.Quan = _hoadon.Quan;
                    }
                    ///
                    ctktxm.NgayKTXM_Truoc_NgayGiao = chkNgayKTXMTruocNgayGiao.Checked;
                    ctktxm.NgayKTXM = dateKTXM.Value;

                    if (cmbHienTrangKiemTra.SelectedValue != null)
                        ctktxm.HienTrangKiemTra = cmbHienTrangKiemTra.SelectedValue.ToString();

                    if (cmbViTriDHN1.SelectedItem != null)
                        ctktxm.ViTriDHN1 = cmbViTriDHN1.SelectedItem.ToString();

                    if (cmbViTriDHN2.SelectedItem != null)
                        ctktxm.ViTriDHN2 = cmbViTriDHN2.SelectedItem.ToString();

                    ctktxm.Hieu = txtHieu.Text.Trim();
                    ctktxm.Co = txtCo.Text.Trim();
                    ctktxm.SoThan = txtSoThan.Text.Trim();
                    ctktxm.ChiSo = txtChiSo.Text.Trim();

                    if (cmbTinhTrangChiSo.SelectedItem != null)
                        ctktxm.TinhTrangChiSo = cmbTinhTrangChiSo.SelectedItem.ToString();

                    if (cmbChiMatSo.SelectedItem != null)
                        ctktxm.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();

                    if (cmbChiKhoaGoc.SelectedItem != null)
                        ctktxm.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();

                    ctktxm.MucDichSuDung = txtMucDichSuDung.Text.Trim();
                    ctktxm.DienThoai = txtDienThoai.Text.Trim();
                    ctktxm.HoTenKHKy = txtHoTenKHKy.Text.Trim().ToUpper();

                    ctktxm.NoiDungKiemTra = txtNoiDungKiemTra.Text.Trim();
                    ctktxm.TheoYeuCau = txtTheoYeuCau.Text.Trim().ToUpper();
                    ctktxm.TieuThuTrungBinh = int.Parse(txtTieuThuTrungBinh.Text.Trim());
                    if (cmbNoiDungBaoThay.SelectedIndex != -1 && string.IsNullOrEmpty(cmbNoiDungBaoThay.SelectedItem.ToString()) == false)
                    {
                        ctktxm.NoiDungBaoThay = cmbNoiDungBaoThay.SelectedItem.ToString();
                        if (txtGhiChuNoiDungBaoThay.Text.Trim() != "")
                            ctktxm.GhiChuNoiDungBaoThay = txtGhiChuNoiDungBaoThay.Text.Trim();
                    }
                    ctktxm.SoTienDongTien = txtTongSoTien.Text.Trim();
                    using (TransactionScope scope = new TransactionScope())
                        if (_cKTXM.ThemCT(ctktxm) == true)
                        {
                            foreach (DataGridViewRow item in dgvBangGia.Rows)
                            {
                                KTXM_BangGia banggia = new KTXM_BangGia();
                                banggia.IDCTKTXM = ctktxm.MaCTKTXM;
                                banggia.IDDonGia = int.Parse(item.Cells["IDDonGia"].Value.ToString());
                                _cKTXM.Them_BangGia(banggia);
                            }
                            foreach (DataGridViewRow item in dgvHinh.Rows)
                            {
                                KTXM_ChiTiet_Hinh en = new KTXM_ChiTiet_Hinh();
                                en.IDKTXM_ChiTiet = ctktxm.MaCTKTXM;
                                en.Hinh = Convert.FromBase64String(item.Cells["Bytes"].Value.ToString());
                                _cKTXM.Them_Hinh(en);
                            }
                            if (_dontu_ChiTiet != null)
                            {
                                if (_cDonTu.Them_LichSu(ctktxm.NgayKTXM.Value,"KTXM", "Đã Kiểm Tra, " + ctktxm.NoiDungKiemTra, (int)ctktxm.MaCTKTXM, _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value) == true)
                                    scope.Complete();
                            }
                            else
                                scope.Complete();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear_LoadDSKTXM();
                            txtMaDonMoi.Focus();
                        }
                    LoadDSKTXM();
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (_ctktxm != null)
                    {
                        if (CTaiKhoan.ToTruong == false && CTaiKhoan.ThuKy == false)
                            if (_ctktxm.CreateBy != CTaiKhoan.MaUser)
                            {
                                MessageBox.Show("Bạn không phải người lập nên không được phép điều chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        if (!txtDanhBo.Text.Trim().Contains("GM"))
                            if ((txtDanhBo.Text.Trim().Length > 0 && txtDanhBo.Text.Trim().Length < 11) || txtDanhBo.Text.Trim().Length > 11)
                            {
                                MessageBox.Show("Lỗi Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        if ((cmbHienTrangKiemTra.SelectedValue.ToString().Contains("BB") && cmbHienTrangKiemTra.SelectedValue.ToString() != "BB tái lập Danh Bộ") || cmbHienTrangKiemTra.SelectedValue.ToString() == "Hóa Đơn = 0")
                            if (txtHoTenKHKy.Text.Trim() == "")
                            {
                                MessageBox.Show("Thiếu Tên Khách Hàng Ký", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                        _ctktxm.DanhBo = txtDanhBo.Text.Trim();
                        _ctktxm.HopDong = txtHopDong.Text.Trim();
                        _ctktxm.HoTen = txtHoTen.Text.Trim();
                        _ctktxm.DiaChi = txtDiaChi.Text.Trim();
                        _ctktxm.GiaBieu = txtGiaBieu.Text.Trim();
                        _ctktxm.DinhMuc = txtDinhMuc.Text.Trim();
                        if (txtDinhMucMoi.Text.Trim() != "")
                            _ctktxm.DinhMucMoi = int.Parse(txtDinhMucMoi.Text.Trim());
                        if (_hoadon != null)
                        {
                            _ctktxm.Dot = _hoadon.DOT.ToString();
                            _ctktxm.Ky = _hoadon.KY.ToString();
                            _ctktxm.Nam = _hoadon.NAM.ToString();
                            _ctktxm.Phuong = _hoadon.Phuong;
                            _ctktxm.Quan = _hoadon.Quan;
                        }
                        ///
                        _ctktxm.NgayKTXM_Truoc_NgayGiao = chkNgayKTXMTruocNgayGiao.Checked;
                        _ctktxm.NgayKTXM = dateKTXM.Value;

                        if (cmbHienTrangKiemTra.SelectedValue != null && cmbHienTrangKiemTra.SelectedValue.ToString() != "")
                            _ctktxm.HienTrangKiemTra = cmbHienTrangKiemTra.SelectedValue.ToString();

                        if (cmbViTriDHN1.SelectedItem != null)
                            _ctktxm.ViTriDHN1 = cmbViTriDHN1.SelectedItem.ToString();

                        if (cmbViTriDHN2.SelectedItem != null)
                            _ctktxm.ViTriDHN2 = cmbViTriDHN2.SelectedItem.ToString();

                        _ctktxm.Hieu = txtHieu.Text.Trim();
                        _ctktxm.Co = txtCo.Text.Trim();
                        _ctktxm.SoThan = txtSoThan.Text.Trim();
                        _ctktxm.ChiSo = txtChiSo.Text.Trim();

                        if (cmbTinhTrangChiSo.SelectedItem != null)
                            _ctktxm.TinhTrangChiSo = cmbTinhTrangChiSo.SelectedItem.ToString();

                        if (cmbChiMatSo.SelectedItem != null)
                            _ctktxm.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();

                        if (cmbChiKhoaGoc.SelectedItem != null)
                            _ctktxm.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();

                        _ctktxm.MucDichSuDung = txtMucDichSuDung.Text.Trim();
                        _ctktxm.DienThoai = txtDienThoai.Text.Trim();
                        _ctktxm.HoTenKHKy = txtHoTenKHKy.Text.Trim();

                        _ctktxm.NoiDungKiemTra = txtNoiDungKiemTra.Text.Trim();
                        _ctktxm.TheoYeuCau = txtTheoYeuCau.Text.Trim().ToUpper();
                        _ctktxm.TieuThuTrungBinh = int.Parse(txtTieuThuTrungBinh.Text.Trim());
                        if (cmbNoiDungBaoThay.SelectedIndex != -1 && string.IsNullOrEmpty(cmbNoiDungBaoThay.SelectedItem.ToString()) == false)
                        {
                            _ctktxm.NoiDungBaoThay = cmbNoiDungBaoThay.SelectedItem.ToString();
                            if (txtGhiChuNoiDungBaoThay.Text.Trim() != "")
                                _ctktxm.GhiChuNoiDungBaoThay = txtGhiChuNoiDungBaoThay.Text.Trim();
                        }
                        _ctktxm.SoTienDongTien = txtTongSoTien.Text.Trim();
                        if (_cKTXM.SuaCT(_ctktxm))
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_ctktxm != null && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (CTaiKhoan.ToTruong == false && CTaiKhoan.ThuKy == false)
                            if (_ctktxm.CreateBy != CTaiKhoan.MaUser)
                            {
                                MessageBox.Show("Bạn không phải người lập nên không được phép điều chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        if (_cKTXM.XoaCT(_ctktxm))
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDSKetQuaKiemTra_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSKetQuaKiemTra.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSKetQuaKiemTra_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dgvDSKetQuaKiemTra.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            //{
            //    e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            //}
        }

        private void dgvDSKetQuaKiemTra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvDSKetQuaKiemTra.Rows[e.RowIndex].Selected = true;
                _ctktxm = _cKTXM.GetCT(decimal.Parse(dgvDSKetQuaKiemTra.SelectedRows[0].Cells["MaCTKTXM"].Value.ToString()));
                LoadCTKTXM(_ctktxm);
            }
            catch (Exception)
            {
            }
        }

        private void cmbTinhTrangKiemTra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagFirst)
            {

            }
            else
                switch (((KTXM_HienTrang)cmbHienTrangKiemTra.SelectedItem).TenHTKT)
                {
                    case "Nhà đóng cửa":
                        txtChiSo.Enabled = false;
                        cmbTinhTrangChiSo.Enabled = false;
                        cmbChiMatSo.Enabled = false;
                        cmbChiKhoaGoc.Enabled = false;
                        txtHieu.Enabled = false;
                        txtCo.Enabled = false;
                        txtSoThan.Enabled = false;
                        txtMucDichSuDung.Enabled = false;
                        txtDienThoai.Enabled = false;
                        txtHoTenKHKy.Enabled = false;
                        ///
                        cmbViTriDHN1.SelectedIndex = -1;
                        cmbViTriDHN2.SelectedIndex = -1;
                        txtChiSo.Text = "";
                        cmbTinhTrangChiSo.SelectedIndex = -1;
                        cmbChiMatSo.SelectedIndex = -1;
                        cmbChiKhoaGoc.SelectedIndex = -1;
                        //txtHieu.Text = "";
                        //txtCo.Text = "";
                        //txtSoThan.Text = "";
                        txtMucDichSuDung.Text = "";
                        txtDienThoai.Text = "";
                        txtHoTenKHKy.Text = "";
                        break;
                    case "BB mất ĐHN bồi thường":
                    case "BB mất ĐHN không bồi thường":
                        txtChiSo.Enabled = false;
                        cmbTinhTrangChiSo.Enabled = false;
                        cmbChiMatSo.Enabled = false;
                        cmbChiKhoaGoc.Enabled = false;
                        txtHieu.Enabled = false;
                        txtCo.Enabled = false;
                        txtSoThan.Enabled = false;
                        txtDienThoai.Enabled = true;
                        txtHoTenKHKy.Enabled = true;
                        ///
                        cmbViTriDHN1.SelectedIndex = -1;
                        cmbViTriDHN2.SelectedIndex = -1;
                        txtChiSo.Text = "";
                        cmbTinhTrangChiSo.SelectedIndex = -1;
                        cmbChiMatSo.SelectedIndex = -1;
                        cmbChiKhoaGoc.SelectedIndex = -1;
                        //txtHieu.Text = "";
                        //txtCo.Text = "";
                        //txtSoThan.Text = "";
                        txtMucDichSuDung.Text = "";
                        txtDienThoai.Text = "";
                        txtHoTenKHKy.Text = "";
                        break;
                    default:
                        txtChiSo.Enabled = true;
                        cmbTinhTrangChiSo.Enabled = true;
                        cmbChiMatSo.Enabled = true;
                        cmbChiKhoaGoc.Enabled = true;
                        txtHieu.Enabled = true;
                        txtCo.Enabled = true;
                        txtSoThan.Enabled = true;
                        txtMucDichSuDung.Enabled = true;
                        txtDienThoai.Enabled = true;
                        txtHoTenKHKy.Enabled = true;
                        ///
                        cmbViTriDHN1.SelectedIndex = -1;
                        cmbViTriDHN2.SelectedIndex = -1;
                        txtChiSo.Text = "";
                        cmbTinhTrangChiSo.SelectedIndex = -1;
                        cmbChiMatSo.SelectedIndex = -1;
                        cmbChiKhoaGoc.SelectedIndex = -1;
                        //txtHieu.Text = "";
                        //txtCo.Text = "";
                        //txtSoThan.Text = "";
                        txtMucDichSuDung.Text = "";
                        txtDienThoai.Text = "";
                        txtHoTenKHKy.Text = "";
                        break;
                }

        }

        //bảng giá
        private void txtDonGia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                try
                {
                    string[] NoiDung = txtDonGia.Text.Trim().Split(':');
                    KTXM_DonGia dongia = _cKTXM.get_DonGia(NoiDung[0].ToString().Trim(), int.Parse(NoiDung[1].ToString().Trim().Replace(".", "")));
                    bool flagExist = false;
                    foreach (DataGridViewRow item in dgvBangGia.Rows)
                        if (item.Cells["Namee"].Value.ToString() == dongia.Name && int.Parse(item.Cells["SoTien"].Value.ToString()) == dongia.SoTien)
                        {
                            flagExist = true;
                        }
                    if (flagExist == false)
                    {
                        if (_ctktxm == null)
                        {
                            var index = dgvBangGia.Rows.Add();
                            dgvBangGia.Rows[index].Cells["IDDonGia"].Value = dongia.ID;
                            dgvBangGia.Rows[index].Cells["Namee"].Value = dongia.Name;
                            dgvBangGia.Rows[index].Cells["SoTien"].Value = dongia.SoTien;
                            txtDonGia.Text = "";
                            LoaddgvBangGia();
                        }
                        else
                        {
                            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                            {
                                if (CTaiKhoan.ToTruong == false && CTaiKhoan.ThuKy == false)
                                    if (_ctktxm.CreateBy != CTaiKhoan.MaUser)
                                    {
                                        MessageBox.Show("Bạn không phải người lập nên không được phép điều chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                KTXM_BangGia banggia = new KTXM_BangGia();
                                banggia.IDCTKTXM = _ctktxm.MaCTKTXM;
                                banggia.IDDonGia = dongia.ID;
                                if (_cKTXM.Them_BangGia(banggia) == true)
                                {
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    var index = dgvBangGia.Rows.Add();
                                    dgvBangGia.Rows[index].Cells["IDDonGia"].Value = dongia.ID;
                                    dgvBangGia.Rows[index].Cells["Namee"].Value = dongia.Name;
                                    dgvBangGia.Rows[index].Cells["SoTien"].Value = dongia.SoTien;
                                    txtDonGia.Text = "";
                                    LoaddgvBangGia();
                                }
                            }
                            else
                                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void LoaddgvBangGia()
        {
            int TongSoTien = 0;
            foreach (DataGridViewRow item in dgvBangGia.Rows)
            {
                TongSoTien += int.Parse(item.Cells["SoTien"].Value.ToString());
            }
            if (TongSoTien == 0)
                txtTongSoTien.Text = "0";
            else
                txtTongSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongSoTien);
        }

        private void dgvBangGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBangGia.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(e.Value.ToString()));
            }
        }

        private void dgvBangGia_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvBangGia.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void xoaFile_dgvBangGia_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctktxm == null)
                    dgvBangGia.Rows.RemoveAt(dgvBangGia.CurrentRow.Index);
                else
                    if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (CTaiKhoan.ToTruong == false && CTaiKhoan.ThuKy == false)
                                if (_ctktxm.CreateBy != CTaiKhoan.MaUser)
                                {
                                    MessageBox.Show("Bạn không phải người lập nên không được phép điều chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            if (dgvBangGia.CurrentRow.Cells["IDCTKTXM"].Value != null)
                                if (_cKTXM.Xoa_BangGia(_cKTXM.get_BangGia(int.Parse(dgvBangGia.CurrentRow.Cells["IDCTKTXM"].Value.ToString()), int.Parse(dgvBangGia.CurrentRow.Cells["IDDonGia"].Value.ToString()))))
                                {
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgvBangGia.Rows.RemoveAt(dgvBangGia.CurrentRow.Index);
                                }
                                else
                                    MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBangGia_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                dgvBangGia.CurrentCell = dgvBangGia.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvBangGia_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dgvBangGia, new Point(e.X, e.Y));
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
                    if (_ctktxm == null)
                    {
                        var index = dgvHinh.Rows.Add();
                        dgvHinh.Rows[index].Cells["Name_Hinh"].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(bytes);
                    }
                    else
                    {
                        if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                        {
                            if (CTaiKhoan.ToTruong == false && CTaiKhoan.ThuKy == false)
                                if (_ctktxm.CreateBy != CTaiKhoan.MaUser)
                                {
                                    MessageBox.Show("Bạn không phải người lập nên không được phép điều chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            KTXM_ChiTiet_Hinh en = new KTXM_ChiTiet_Hinh();
                            en.IDKTXM_ChiTiet = _ctktxm.MaCTKTXM;
                            en.Hinh = bytes;
                            if (_cKTXM.Them_Hinh(en) == true)
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                var index = dgvHinh.Rows.Add();
                                dgvHinh.Rows[index].Cells["Name_Hinh"].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
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
            _cKTXM.LoadImageView(Convert.FromBase64String(dgvHinh.CurrentRow.Cells["Bytes_Hinh"].Value.ToString()));
        }

        private void xoaFile_dgvHinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctktxm == null)
                    dgvHinh.Rows.RemoveAt(dgvHinh.CurrentRow.Index);
                else
                    if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (CTaiKhoan.ToTruong == false && CTaiKhoan.ThuKy == false)
                                if (_ctktxm.CreateBy != CTaiKhoan.MaUser)
                                {
                                    MessageBox.Show("Bạn không phải người lập nên không được phép điều chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            if (dgvHinh.CurrentRow.Cells["ID_Hinh"].Value != null)
                                if (_cKTXM.Xoa_Hinh(_cKTXM.get_Hinh(int.Parse(dgvHinh.CurrentRow.Cells["ID_Hinh"].Value.ToString()))))
                                {
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgvHinh.Rows.RemoveAt(dgvHinh.CurrentRow.Index);
                                }
                                else
                                    MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

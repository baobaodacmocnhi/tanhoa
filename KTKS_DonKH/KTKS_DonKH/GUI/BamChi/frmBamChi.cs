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
using KTKS_DonKH.DAL.BamChi;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.DAL.DonTu;
using System.Transactions;
using KTKS_DonKH.wrThuongVu;
using KTKS_DonKH.GUI.DonTu;

namespace KTKS_DonKH.GUI.BamChi
{
    public partial class frmBamChi : Form
    {
        string _mnu = "mnuNhapKQBamChi";
        CDonTu _cDonTu = new CDonTu();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CThuTien _cThuTien = new CThuTien();
        CBamChi _cBamChi = new CBamChi();
        CDHN _cDHN = new CDHN();
        CTrangThaiBamChi _cTrangThaiBamChi = new CTrangThaiBamChi();
        CNiemChi _cNiemChi = new CNiemChi();
        wsThuongVu _wsThuongVu = new wsThuongVu();

        DonTu_ChiTiet _dontu_ChiTiet = null;
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        BamChi_ChiTiet _ctbamchi = null;
        bool _flagFirst = true;
        decimal _MaCTBamChi = -1;

        public frmBamChi()
        {
            InitializeComponent();
        }

        public frmBamChi(decimal MaCTBamChi)
        {
            _MaCTBamChi = MaCTBamChi;
            InitializeComponent();
        }

        private void frmNhapBamChi_Load(object sender, EventArgs e)
        {
            dgvDSNhapBamChi.AutoGenerateColumns = false;
            dgvHinh.AutoGenerateColumns = false;

            cmbTrangThaiBC.DataSource = _cTrangThaiBamChi.GetDS();
            cmbTrangThaiBC.DisplayMember = "TenTTBC";
            cmbTrangThaiBC.ValueMember = "TenTTBC";
            cmbTrangThaiBC.SelectedIndex = -1;
            _flagFirst = false;

            //txtMaSoBC.Text = CTaiKhoan.MaKiemBamChi;

            if (_MaCTBamChi != -1)
            {
                _ctbamchi = _cBamChi.GetCT(_MaCTBamChi);
                LoadCTBamChi(_ctbamchi);
            }
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHopDong.Text = hoadon.HOPDONG;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG;
            txtGiaBieu.Text = hoadon.GB.ToString();
            if (hoadon.DM != null)
                txtDinhMuc.Text = hoadon.DM.Value.ToString();
            else
                txtDinhMuc.Text = "";
            if (hoadon.DinhMucHN != null)
                txtDinhMucHN.Text = hoadon.DinhMucHN.Value.ToString();
            else
                txtDinhMucHN.Text = "";
            string a, b, c;
            _cDHN.GetDHN(txtDanhBo.Text.Trim(), out a, out b, out c);
            txtHieu.Text = a;
            txtCo.Text = b;
            txtSoThan.Text = c;
            if (_cDHN.CheckExist(hoadon.DANHBA) == false)
                MessageBox.Show("Danh Bộ Hủy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void LoadCTBamChi(BamChi_ChiTiet ctbamchi)
        {
            if (ctbamchi.BamChi.MaDonMoi != null)
            {
                _dontu_ChiTiet = _cDonTu.get_ChiTiet(ctbamchi.BamChi.MaDonMoi.Value, ctbamchi.STT.Value);
                if (_dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count == 1)
                    txtMaDonMoi.Text = ctbamchi.BamChi.MaDonMoi.ToString();
                else
                    txtMaDonMoi.Text = ctbamchi.BamChi.MaDonMoi.Value.ToString() + "." + ctbamchi.STT.Value.ToString();
            }
            else
                if (ctbamchi.BamChi.MaDon != null)
                {
                    _dontkh = _cDonKH.Get(ctbamchi.BamChi.MaDon.Value);
                    txtMaDonCu.Text = ctbamchi.BamChi.MaDon.ToString().Insert(ctbamchi.BamChi.MaDon.ToString().Length - 2, "-");
                }
                else
                    if (ctbamchi.BamChi.MaDonTXL != null)
                    {
                        _dontxl = _cDonTXL.Get(ctbamchi.BamChi.MaDonTXL.Value);
                        txtMaDonCu.Text = "TXL" + ctbamchi.BamChi.MaDonTXL.ToString().Insert(ctbamchi.BamChi.MaDonTXL.ToString().Length - 2, "-");
                    }
                    else
                        if (ctbamchi.BamChi.MaDonTBC != null)
                        {
                            _dontbc = _cDonTBC.Get(ctbamchi.BamChi.MaDonTBC.Value);
                            txtMaDonCu.Text = "TBC" + ctbamchi.BamChi.MaDonTBC.ToString().Insert(ctbamchi.BamChi.MaDonTBC.ToString().Length - 2, "-");
                        }
            txtDanhBo.Text = ctbamchi.DanhBo;
            txtHopDong.Text = ctbamchi.HopDong;
            txtHoTen.Text = ctbamchi.HoTen;
            txtDiaChi.Text = ctbamchi.DiaChi;
            txtGiaBieu.Text = ctbamchi.GiaBieu.ToString();
            if (ctbamchi.DinhMuc != null)
                txtDinhMuc.Text = ctbamchi.DinhMuc.Value.ToString();
            if (ctbamchi.DinhMucHN != null)
                txtDinhMucHN.Text = ctbamchi.DinhMucHN.Value.ToString();
            ///
            chkNgayBCTruocNgayGiao.Checked = ctbamchi.NgayBC_Truoc_NgayGiao;
            dateBamChi.Value = ctbamchi.NgayBC.Value;
            cmbHienTrangKiemTra.SelectedItem = ctbamchi.HienTrangKiemTra;
            txtHieu.Text = ctbamchi.Hieu;
            txtCo.Text = ctbamchi.Co.ToString();
            txtSoThan.Text = ctbamchi.SoThan;
            cmbChiMatSo.SelectedItem = ctbamchi.ChiMatSo;
            cmbChiKhoaGoc.SelectedItem = ctbamchi.ChiKhoaGoc;
            txtMucDichSuDung.Text = ctbamchi.MucDichSuDung;
            txtChiSo.Text = ctbamchi.ChiSo.ToString();
            if (ctbamchi.NiemChi != null)
            {
                txtNiemChi.Text = ctbamchi.NiemChi;
            }
            if (ctbamchi.MauSac != null)
            {
                cmbMauSac.SelectedItem = ctbamchi.MauSac;
            }
            cmbTinhTrangChiSo.SelectedItem = ctbamchi.TinhTrangChiSo;
            cmbTrangThaiBC.SelectedValue = ctbamchi.TrangThaiBC;
            txtVienChi.Text = ctbamchi.VienChi.ToString();
            txtDayChi.Text = ctbamchi.DayChi.ToString();

            txtGhiChu.Text = ctbamchi.GhiChu;
            txtMaSoBC.Text = ctbamchi.MaSoBC;
            txtTheoYeuCau.Text = ctbamchi.TheoYeuCau;
            dgvHinh.Rows.Clear();
            foreach (BamChi_ChiTiet_Hinh item in ctbamchi.BamChi_ChiTiet_Hinhs.ToList())
            {
                var index = dgvHinh.Rows.Add();
                dgvHinh.Rows[index].Cells["ID_Hinh"].Value = item.ID;
                dgvHinh.Rows[index].Cells["Name_Hinh"].Value = item.Name;
                if (item.Hinh != null)
                    dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(item.Hinh.ToArray());
                dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = item.Loai;
            }
        }

        //public void Clear()
        //{
        //    txtMaDonCu.Text = "";
        //    txtMaDonMoi.Text = "";
        //    txtDanhBo.Text = "";
        //    txtHopDong.Text = "";
        //    txtHoTen.Text = "";
        //    txtDiaChi.Text = "";
        //    txtGiaBieu.Text = "";
        //    txtDinhMuc.Text = "";
        //    ///
        //    //dateBamChi.Value = DateTime.Now;
        //    //cmbHienTrangKiemTra.SelectedIndex = -1;
        //    txtHieu.Text = "";
        //    txtCo.Text = "";
        //    txtSoThan.Text = "";
        //    txtChiSo.Text = "";
        //    cmbTinhTrangChiSo.SelectedIndex = -1;
        //    cmbChiMatSo.SelectedIndex = -1;
        //    cmbChiKhoaGoc.SelectedIndex = -1;
        //    //txtMucDichSuDung.Text = "";
        //    //txtVienChi.Text = "";
        //    //txtDayChi.Text = "";
        //    //cmbTrangThaiBC.SelectedIndex = -1;
        //    //txtMaSoBC.Text = "";
        //    //txtTheoYeuCau.Text = "";
        //    txtGhiChu.Text = "";

        //    _MaCTBamChi = -1;
        //    _ctbamchi = null;
        //    _dontu_ChiTiet = null;
        //    _dontkh = null;
        //    _dontxl = null;
        //    _dontbc = null;
        //    _hoadon = null;
        //    dgvDSNhapBamChi.DataSource = null;
        //    dgvHinh.Rows.Clear();
        //}

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
            txtDinhMucHN.Text = "";
            ///
            //dateBamChi.Value = DateTime.Now;
            //cmbHienTrangKiemTra.SelectedIndex = -1;
            txtHieu.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            txtChiSo.Text = "";
            cmbTinhTrangChiSo.SelectedIndex = -1;
            cmbChiMatSo.SelectedIndex = -1;
            cmbChiKhoaGoc.SelectedIndex = -1;
            //txtMucDichSuDung.Text = "";
            //txtVienChi.Text = "";
            //txtDayChi.Text = "";
            //cmbTrangThaiBC.SelectedIndex = -1;
            //txtMaSoBC.Text = "";
            //txtTheoYeuCau.Text = "";
            txtGhiChu.Text = "";

            _MaCTBamChi = -1;
            _ctbamchi = null;
            _hoadon = null;
            dgvHinh.Rows.Clear();

            txtMaDonMoi.Focus();
        }

        public void GetDataGridView()
        {
            if (_dontu_ChiTiet != null)
                dgvDSNhapBamChi.DataSource = _cBamChi.getDS("", _dontu_ChiTiet.MaDon.Value);
            else
                if (_dontkh != null)
                    dgvDSNhapBamChi.DataSource = _cBamChi.getDS("TKH", _dontkh.MaDon);
                else
                    if (_dontxl != null)
                        dgvDSNhapBamChi.DataSource = _cBamChi.getDS("TXL", _dontxl.MaDon);
                    else
                        if (_dontbc != null)
                            dgvDSNhapBamChi.DataSource = _cBamChi.getDS("TBC", _dontbc.MaDon);
        }

        public void Clear2()
        {
            txtMaDonCu.Text = "";
            txtMaDonMoi.Text = "";
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDinhMucHN.Text = "";
            ///
            dateBamChi.Value = DateTime.Now;
            //cmbHienTrangKiemTra.SelectedIndex = -1;
            txtHieu.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            txtChiSo.Text = "";
            cmbTinhTrangChiSo.SelectedIndex = -1;
            cmbChiMatSo.SelectedIndex = -1;
            cmbChiKhoaGoc.SelectedIndex = -1;
            txtMucDichSuDung.Text = "";
            txtVienChi.Text = "";
            txtDayChi.Text = "";
            cmbTrangThaiBC.SelectedIndex = 0;
            txtMaSoBC.Text = "";
            txtTheoYeuCau.Text = "";
            txtGhiChu.Text = "";

            _MaCTBamChi = -1;
            _ctbamchi = null;
            _dontu_ChiTiet = null;
            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            dgvDSNhapBamChi.DataSource = null;
            dgvHinh.Rows.Clear();
        }

        private void txtMaDonCu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDonCu.Text.Trim() != "")
            {
                string MaDon = txtMaDonCu.Text.Trim();
                Clear();
                txtMaSoBC.Text = CTaiKhoan.MaKiemBamChi;
                txtMaDonCu.Text = MaDon;
                ///Đơn Tổ Xử Lý
                if (txtMaDonCu.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_cDonTXL.CheckExist(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", ""))) == true)
                    {
                        _dontxl = _cDonTXL.Get(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDonCu.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");

                        GetDataGridView();

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
                    ///Đơn Tổ Bấm Chì
                    if (txtMaDonCu.Text.Trim().ToUpper().Contains("TBC"))
                    {
                        if (_cDonTBC.CheckExist(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", ""))) == true)
                        {
                            _dontbc = _cDonTBC.Get(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                            txtMaDonCu.Text = "TBC" + _dontbc.MaDon.ToString().Insert(_dontbc.MaDon.ToString().Length - 2, "-");

                            GetDataGridView();

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

                            GetDataGridView();

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
                    GetDataGridView();
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    if ((txtDanhBo.Text.Trim().Length > 0 && txtDanhBo.Text.Trim().Length < 11) || txtDanhBo.Text.Trim().Length > 11)
                    {
                        MessageBox.Show("Lỗi Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (txtHoTen.Text.Trim() == "" || txtDiaChi.Text.Trim() == "" || txtTheoYeuCau.Text.Trim() == "")
                    {
                        MessageBox.Show("Chưa đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //if (!string.IsNullOrEmpty(txtNiemChi.Text.Trim()))
                    //{
                    //    if (_cNiemChi.checkExist(int.Parse(txtNiemChi.Text.Trim())) == false)
                    //    {
                    //        MessageBox.Show("Số Niêm Chì không Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //    }
                    //    if (_cNiemChi.checkGiao_MaNV(int.Parse(txtNiemChi.Text.Trim()), CTaiKhoan.MaUser) == false)
                    //    {
                    //        MessageBox.Show("Số Niêm Chì này không được Giao Cho Bạn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //    }
                    //    if (_cNiemChi.checkSuDung(int.Parse(txtNiemChi.Text.Trim())) == true)
                    //    {
                    //        MessageBox.Show("Số Niêm Chì đã Sử Dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //    }
                    //}

                    DateTime NgayQuyetToan = _cBamChi.getMaxNgayQuyetToan();
                    if (dateBamChi.Value.Date <= NgayQuyetToan.Date)
                    {
                        MessageBox.Show("Ngày Bấm Chì đã được Quết Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    BamChi_ChiTiet ctbamchi = new BamChi_ChiTiet();

                    if (_dontu_ChiTiet != null)
                    {
                        if (_cBamChi.checkExist(_dontu_ChiTiet.MaDon.Value) == false)
                        {
                            LinQ.BamChi bamchi = new LinQ.BamChi();
                            bamchi.MaDonMoi = _dontu_ChiTiet.MaDon.Value;
                            _cBamChi.Them(bamchi);
                        }
                        if (txtDanhBo.Text.Trim() != "" && _cBamChi.checkExist_ChiTiet(_dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value, txtDanhBo.Text.Trim(), dateBamChi.Value, cmbTrangThaiBC.SelectedValue.ToString(), cmbMauSac.Text))
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Bấm Chì", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ctbamchi.MaBC = _cBamChi.get(_dontu_ChiTiet.MaDon.Value).MaBC;
                        ctbamchi.STT = _dontu_ChiTiet.STT;
                    }
                    else
                        if (_dontkh != null)
                        {
                            if (_cBamChi.CheckExist_BamChi("TKH", _dontkh.MaDon) == false)
                            {
                                LinQ.BamChi bamchi = new LinQ.BamChi();
                                bamchi.MaDon = _dontkh.MaDon;
                                _cBamChi.Them(bamchi);
                            }
                            if (txtDanhBo.Text.Trim() != "" && _cBamChi.CheckExist_CTBamChi("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim(), dateBamChi.Value, cmbTrangThaiBC.SelectedValue.ToString()))
                            {
                                MessageBox.Show("Danh Bộ này đã được Lập Bấm Chì", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            ctbamchi.MaBC = _cBamChi.Get("TKH", _dontkh.MaDon).MaBC;
                            ctbamchi.STT = _dontu_ChiTiet.STT;
                        }
                        else
                            if (_dontxl != null)
                            {
                                if (_cBamChi.CheckExist_BamChi("TXL", _dontxl.MaDon) == false)
                                {
                                    LinQ.BamChi bamchi = new LinQ.BamChi();
                                    bamchi.MaDonTXL = _dontxl.MaDon;
                                    _cBamChi.Them(bamchi);
                                }
                                if (txtDanhBo.Text.Trim() != "" && _cBamChi.CheckExist_CTBamChi("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim(), dateBamChi.Value, cmbTrangThaiBC.SelectedValue.ToString()))
                                {
                                    MessageBox.Show("Danh Bộ này đã được Lập Bấm Chì", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                ctbamchi.MaBC = _cBamChi.Get("TXL", _dontxl.MaDon).MaBC;
                            }
                            else
                                if (_dontbc != null)
                                {
                                    if (_cBamChi.CheckExist_BamChi("TBC", _dontbc.MaDon) == false)
                                    {
                                        LinQ.BamChi bamchi = new LinQ.BamChi();
                                        bamchi.MaDonTBC = _dontbc.MaDon;
                                        _cBamChi.Them(bamchi);
                                    }
                                    if (txtDanhBo.Text.Trim() != "" && _cBamChi.CheckExist_CTBamChi("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim(), dateBamChi.Value, cmbTrangThaiBC.SelectedValue.ToString()))
                                    {
                                        MessageBox.Show("Danh Bộ này đã được Lập Bấm Chì", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    ctbamchi.MaBC = _cBamChi.Get("TBC", _dontbc.MaDon).MaBC;
                                }
                                else
                                {
                                    MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                    ctbamchi.DanhBo = txtDanhBo.Text.Trim();
                    ctbamchi.HopDong = txtHopDong.Text.Trim();
                    ctbamchi.HoTen = txtHoTen.Text.Trim().ToUpper();
                    ctbamchi.DiaChi = txtDiaChi.Text.Trim().ToUpper();
                    if (!string.IsNullOrEmpty(txtGiaBieu.Text.Trim()))
                        ctbamchi.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                    if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                        ctbamchi.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                    if (!string.IsNullOrEmpty(txtDinhMucHN.Text.Trim()))
                        ctbamchi.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                    if (_hoadon != null)
                    {
                        ctbamchi.Dot = _hoadon.DOT.ToString();
                        ctbamchi.Ky = _hoadon.KY.ToString();
                        ctbamchi.Nam = _hoadon.NAM.ToString();
                        ctbamchi.Phuong = _hoadon.Phuong;
                        ctbamchi.Quan = _hoadon.Quan;
                    }
                    ///
                    ctbamchi.NgayBC_Truoc_NgayGiao = chkNgayBCTruocNgayGiao.Checked;
                    ctbamchi.NgayBC = dateBamChi.Value;

                    if (cmbHienTrangKiemTra.SelectedItem != null)
                        ctbamchi.HienTrangKiemTra = cmbHienTrangKiemTra.SelectedItem.ToString();

                    ctbamchi.Hieu = txtHieu.Text.Trim();

                    if (!string.IsNullOrEmpty(txtCo.Text.Trim()))
                        ctbamchi.Co = int.Parse(txtCo.Text.Trim());

                    ctbamchi.SoThan = txtSoThan.Text.Trim();

                    if (!string.IsNullOrEmpty(txtChiSo.Text.Trim()))
                        ctbamchi.ChiSo = int.Parse(txtChiSo.Text.Trim());


                    if (txtNiemChi.Text.Trim() == "" && cmbMauSac.SelectedIndex == -1)
                    {
                        MessageBox.Show("Thiếu Số Niêm Chì - Màu sắc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!string.IsNullOrEmpty(txtNiemChi.Text.Trim()))
                    {

                        if (_cNiemChi.checkExist(txtNiemChi.Text.Trim().ToUpper()) == false)
                        {
                            MessageBox.Show("Số Niêm Chì không Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (_cNiemChi.checkGiao_MaNV(txtNiemChi.Text.Trim().ToUpper(), CTaiKhoan.MaUser) == false)
                        {
                            MessageBox.Show("Số Niêm Chì này không được Giao Cho Bạn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (_cNiemChi.checkSuDung(txtNiemChi.Text.Trim().ToUpper()) == true)
                        {
                            MessageBox.Show("Số Niêm Chì đã Sử Dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ctbamchi.NiemChi = txtNiemChi.Text.Trim().ToUpper();
                        ctbamchi.MauSac = cmbMauSac.Text;
                        //_cNiemChi.suDung(int.Parse(txtNiemChi.Text.Trim()));
                    }

                    if (cmbTinhTrangChiSo.SelectedItem != null)
                        ctbamchi.TinhTrangChiSo = cmbTinhTrangChiSo.SelectedItem.ToString();

                    if (cmbChiMatSo.SelectedItem != null)
                        ctbamchi.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();

                    if (cmbChiKhoaGoc.SelectedItem != null)
                        ctbamchi.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();

                    ctbamchi.MucDichSuDung = txtMucDichSuDung.Text.Trim();

                    if (cmbTrangThaiBC.SelectedValue != null)
                        ctbamchi.TrangThaiBC = cmbTrangThaiBC.SelectedValue.ToString();

                    ctbamchi.GhiChu = txtGhiChu.Text.Trim();
                    ctbamchi.MaSoBC = txtMaSoBC.Text.Trim();

                    if (!string.IsNullOrEmpty(txtVienChi.Text.Trim()))
                        ctbamchi.VienChi = int.Parse(txtVienChi.Text.Trim());

                    if (!string.IsNullOrEmpty(txtDayChi.Text.Trim()))
                        ctbamchi.DayChi = _cBamChi.convertToDouble(txtDayChi.Text.Trim());

                    ctbamchi.TheoYeuCau = txtTheoYeuCau.Text.Trim().ToUpper();

                    using (TransactionScope scope = new TransactionScope())
                        if (_cBamChi.ThemCT(ctbamchi))
                        {
                            _cNiemChi.suDung(txtNiemChi.Text.Trim().ToUpper());
                            foreach (DataGridViewRow item in dgvHinh.Rows)
                            {
                                BamChi_ChiTiet_Hinh en = new BamChi_ChiTiet_Hinh();
                                en.IDBamChi_ChiTiet = ctbamchi.MaCTBC;
                                en.Name = item.Cells["Name_Hinh"].Value.ToString();
                                //en.Hinh = Convert.FromBase64String(item.Cells["Bytes_Hinh"].Value.ToString());
                                en.Loai = item.Cells["Loai_Hinh"].Value.ToString();
                                if (_wsThuongVu.ghi_Hinh("BamChi_ChiTiet_Hinh", en.IDBamChi_ChiTiet.Value.ToString(), en.Name + en.Loai, Convert.FromBase64String(item.Cells["Bytes_Hinh"].Value.ToString())) == true)
                                    _cBamChi.Them_Hinh(en);
                            }
                            if (_dontu_ChiTiet != null)
                            {
                                if (_cDonTu.Them_LichSu(ctbamchi.NgayBC.Value, "BamChi", "Đã Bấm Chì, " + ctbamchi.TrangThaiBC, (int)ctbamchi.MaCTBC, _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value) == true)
                                    scope.Complete();
                            }
                            else
                                scope.Complete();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    GetDataGridView();
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
                    if (_ctbamchi != null)
                    {
                        if (_ctbamchi.NgayQuyetToan != null)
                        {
                            MessageBox.Show("Biên bản bấm chì đã được Chốt Quyết Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (CTaiKhoan.Admin == false && CTaiKhoan.ToTruong == false && CTaiKhoan.ThuKy == false)
                            if (_ctbamchi.CreateBy != CTaiKhoan.MaUser)
                            {
                                MessageBox.Show("Bạn không phải người lập nên không được phép điều chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        if ((txtDanhBo.Text.Trim().Length > 0 && txtDanhBo.Text.Trim().Length < 11) || txtDanhBo.Text.Trim().Length > 11)
                        {
                            MessageBox.Show("Lỗi Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (txtHoTen.Text.Trim() == "" || txtDiaChi.Text.Trim() == "" || txtTheoYeuCau.Text.Trim() == "" || txtNiemChi.Text.Trim() == "")
                        {
                            MessageBox.Show("Chưa đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        _ctbamchi.DanhBo = txtDanhBo.Text.Trim();
                        _ctbamchi.HopDong = txtHopDong.Text.Trim();
                        _ctbamchi.HoTen = txtHoTen.Text.Trim();
                        _ctbamchi.DiaChi = txtDiaChi.Text.Trim();
                        if (!string.IsNullOrEmpty(txtGiaBieu.Text.Trim()))
                            _ctbamchi.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                            _ctbamchi.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        else
                            _ctbamchi.DinhMuc = null;
                        if (!string.IsNullOrEmpty(txtDinhMucHN.Text.Trim()))
                            _ctbamchi.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                        else
                            _ctbamchi.DinhMucHN = null;
                        if (_hoadon != null)
                        {
                            _ctbamchi.Dot = _hoadon.DOT.ToString();
                            _ctbamchi.Ky = _hoadon.KY.ToString();
                            _ctbamchi.Nam = _hoadon.NAM.ToString();
                            _ctbamchi.Phuong = _hoadon.Phuong;
                            _ctbamchi.Quan = _hoadon.Quan;
                        }
                        ///
                        _ctbamchi.NgayBC_Truoc_NgayGiao = chkNgayBCTruocNgayGiao.Checked;
                        //cập nhật lại thời gian bên lịch sử chuyển đơn
                        if (_ctbamchi.NgayBC.Value.Date != dateBamChi.Value.Date)
                        {
                            DonTu_LichSu dtls = _cDonTu.get_LichSu("BamChi_ChiTiet", (int)_ctbamchi.MaCTBC);
                            if (dtls != null)
                            {
                                dtls.NgayChuyen = dateBamChi.Value;
                                _cDonTu.SubmitChanges();
                            }
                        }
                        _ctbamchi.NgayBC = dateBamChi.Value;

                        if (cmbHienTrangKiemTra.SelectedItem != null)
                            _ctbamchi.HienTrangKiemTra = cmbHienTrangKiemTra.SelectedItem.ToString();

                        _ctbamchi.Hieu = txtHieu.Text.Trim();

                        if (!string.IsNullOrEmpty(txtCo.Text.Trim()))
                            _ctbamchi.Co = int.Parse(txtCo.Text.Trim());

                        _ctbamchi.SoThan = txtSoThan.Text.Trim();

                        if (!string.IsNullOrEmpty(txtChiSo.Text.Trim()))
                            _ctbamchi.ChiSo = int.Parse(txtChiSo.Text.Trim());


                        if (txtNiemChi.Text.Trim() == "" && cmbMauSac.SelectedIndex == -1)
                        {
                            MessageBox.Show("Thiếu Số Niêm Chì - Màu sắc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (!string.IsNullOrEmpty(txtNiemChi.Text.Trim()) && (_ctbamchi.NiemChi == null || _ctbamchi.NiemChi != txtNiemChi.Text.Trim().ToUpper()))
                        {
                            if (_cNiemChi.checkExist(txtNiemChi.Text.Trim().ToUpper()) == false)
                            {
                                MessageBox.Show("Số Niêm Chì không Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (CTaiKhoan.ToTruong == false)
                                if (_cNiemChi.checkGiao_MaNV(txtNiemChi.Text.Trim().ToUpper(), CTaiKhoan.MaUser) == false)
                                {
                                    MessageBox.Show("Số Niêm Chì này không được Giao Cho Bạn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            if (_cNiemChi.checkSuDung(txtNiemChi.Text.Trim().ToUpper()) == true)
                            {
                                MessageBox.Show("Số Niêm Chì đã Sử Dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (_ctbamchi.NiemChi != null)
                                _cNiemChi.traSuDung(_ctbamchi.NiemChi);
                            _ctbamchi.NiemChi = txtNiemChi.Text.Trim().ToUpper();
                            _cNiemChi.suDung(txtNiemChi.Text.Trim().ToUpper());
                        }
                        _ctbamchi.MauSac = cmbMauSac.Text;
                        if (cmbTinhTrangChiSo.SelectedItem != null)
                            _ctbamchi.TinhTrangChiSo = cmbTinhTrangChiSo.SelectedItem.ToString();

                        if (cmbChiMatSo.SelectedItem != null)
                            _ctbamchi.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();

                        if (cmbChiKhoaGoc.SelectedItem != null)
                            _ctbamchi.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();

                        _ctbamchi.MucDichSuDung = txtMucDichSuDung.Text.Trim();

                        if (cmbTrangThaiBC.SelectedValue != null)
                            _ctbamchi.TrangThaiBC = cmbTrangThaiBC.SelectedValue.ToString();

                        _ctbamchi.GhiChu = txtGhiChu.Text.Trim();
                        _ctbamchi.MaSoBC = txtMaSoBC.Text.Trim();

                        if (!string.IsNullOrEmpty(txtVienChi.Text.Trim()))
                            _ctbamchi.VienChi = int.Parse(txtVienChi.Text.Trim());

                        if (!string.IsNullOrEmpty(txtDayChi.Text.Trim()))
                            _ctbamchi.DayChi = _cBamChi.convertToDouble(txtDayChi.Text.Trim());

                        _ctbamchi.TheoYeuCau = txtTheoYeuCau.Text.Trim();

                        if (_cBamChi.SuaCT(_ctbamchi))
                        {
                            Clear2();
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
                    if (_ctbamchi != null && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_ctbamchi.NgayQuyetToan != null)
                        {
                            MessageBox.Show("Biên bản bấm chì đã được Chốt Quyết Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (CTaiKhoan.ToTruong == false && CTaiKhoan.ThuKy == false)
                            if (_ctbamchi.CreateBy != CTaiKhoan.MaUser)
                            {
                                MessageBox.Show("Bạn không phải người lập nên không được phép điều chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        if (_ctbamchi.NiemChi != null)
                            _cNiemChi.traSuDung(_ctbamchi.NiemChi);
                        string flagID = _ctbamchi.MaCTBC.ToString();
                        var transactionOptions = new TransactionOptions();
                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                        {
                            DonTu_LichSu dtls = _cDonTu.get_LichSu("BamChi_ChiTiet", (int)_ctbamchi.MaCTBC);
                            if (dtls != null)
                            {
                                _cDonTu.Xoa_LichSu(dtls, true);
                            }
                            if (_cBamChi.XoaCT(_ctbamchi))
                            {
                                _wsThuongVu.xoa_Folder_Hinh("BamChi_ChiTiet_Hinh", flagID);
                                scope.Complete();
                                scope.Dispose();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear2();
                                txtMaDonCu.Focus();
                            }
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

        private void dgvDSNhapBamChi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvDSNhapBamChi.Rows[e.RowIndex].Selected = true;
                _ctbamchi = _cBamChi.GetCT(decimal.Parse(dgvDSNhapBamChi["MaCTBC", e.RowIndex].Value.ToString()));
                LoadCTBamChi(_ctbamchi);
            }
            catch (Exception)
            {
            }
        }

        private void dgvDSNhapBamChi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSNhapBamChi.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSNhapBamChi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dgvDSNhapBamChi.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            //{
            //    e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            //}
        }

        private void cmbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagFirst)
            {

            }
            else
                switch (((BamChi_TrangThai)cmbTrangThaiBC.SelectedItem).TenTTBC)
                {
                    case "Bấm Chì Thân":
                    case "Đóng Cửa":
                    case "Lấp Chừa MS":
                    case "Còn Chì":
                    case "Hầm Sâu":
                    case "Trở Ngại Khác":
                        txtVienChi.Text = "";
                        txtDayChi.Text = "";
                        break;
                    case "Bấm Chì Góc-Chì Thân":
                        txtVienChi.Text = "2";
                        txtDayChi.Text = "1,2";
                        break;
                    default:
                        txtVienChi.Text = "1";
                        txtDayChi.Text = "0,6";
                        break;
                }
        }

        private void cmbTinhTrangKiemTra_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbHienTrangKiemTra.SelectedItem.ToString())
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
                    txtVienChi.Enabled = false;
                    txtDayChi.Enabled = false;
                    cmbTrangThaiBC.Enabled = false;
                    txtMaSoBC.Enabled = false;
                    txtTheoYeuCau.Enabled = false;
                    ///
                    txtChiSo.Text = "";
                    cmbTinhTrangChiSo.SelectedIndex = -1;
                    cmbChiMatSo.SelectedIndex = -1;
                    cmbChiKhoaGoc.SelectedIndex = -1;
                    txtHieu.Text = "";
                    txtCo.Text = "";
                    txtSoThan.Text = "";
                    txtMucDichSuDung.Text = "";
                    txtVienChi.Text = "";
                    txtDayChi.Text = "";
                    cmbTrangThaiBC.SelectedIndex = -1;
                    txtMaSoBC.Text = "";
                    txtTheoYeuCau.Text = "";
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
                    txtMucDichSuDung.Enabled = false;
                    txtVienChi.Enabled = false;
                    txtDayChi.Enabled = false;
                    cmbTrangThaiBC.Enabled = false;
                    ///
                    txtChiSo.Text = "";
                    cmbTinhTrangChiSo.SelectedIndex = -1;
                    cmbChiMatSo.SelectedIndex = -1;
                    cmbChiKhoaGoc.SelectedIndex = -1;
                    txtHieu.Text = "";
                    txtCo.Text = "";
                    txtSoThan.Text = "";
                    txtMucDichSuDung.Text = "";
                    txtVienChi.Text = "";
                    txtDayChi.Text = "";
                    cmbTrangThaiBC.SelectedIndex = -1;
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
                    txtVienChi.Enabled = true;
                    txtDayChi.Enabled = true;
                    cmbTrangThaiBC.Enabled = true;
                    txtMaSoBC.Enabled = true;
                    txtTheoYeuCau.Enabled = true;
                    break;
            }
        }


        //add file
        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png|PDF files (*.pdf) | *.pdf";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] bytes;
                    if (dialog.FileName.ToLower().Contains("pdf"))
                        bytes = _cBamChi.scanFile(dialog.FileName);
                    else
                        bytes = _cBamChi.scanImage(dialog.FileName);
                    if (_ctbamchi == null)
                    {
                        var index = dgvHinh.Rows.Add();
                        dgvHinh.Rows[index].Cells["Name_Hinh"].Value = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                        dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(bytes);
                        dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = System.IO.Path.GetExtension(dialog.FileName);
                    }
                    else
                    {
                        if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                        {
                            if (CTaiKhoan.Admin == false && CTaiKhoan.ToTruong == false && CTaiKhoan.ThuKy == false)
                                if (_ctbamchi.CreateBy != CTaiKhoan.MaUser)
                                {
                                    MessageBox.Show("Bạn không phải người lập nên không được phép điều chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            BamChi_ChiTiet_Hinh en = new BamChi_ChiTiet_Hinh();
                            en.IDBamChi_ChiTiet = _ctbamchi.MaCTBC;
                            en.Name = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                            en.Loai = System.IO.Path.GetExtension(dialog.FileName);
                            if (_wsThuongVu.ghi_Hinh("BamChi_ChiTiet_Hinh", en.IDBamChi_ChiTiet.Value.ToString(), en.Name + en.Loai, bytes) == true)
                                if (_cBamChi.Them_Hinh(en) == true)
                                {
                                    _cBamChi.Refresh();
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    var index = dgvHinh.Rows.Add();
                                    dgvHinh.Rows[index].Cells["Name_Hinh"].Value = en.Name;
                                    dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(bytes);
                                    dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = System.IO.Path.GetExtension(dialog.FileName);
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
                contextMenuStrip1.Show(dgvHinh, new Point(e.X, e.Y));
            }
        }

        private void dgvHinh_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            byte[] file = _wsThuongVu.get_Hinh("BamChi_ChiTiet_Hinh", _ctbamchi.MaCTBC.ToString(), dgvHinh.CurrentRow.Cells["Name_Hinh"].Value.ToString() + dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString());
            if (file != null)
                if (dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString().ToLower().Contains("pdf"))
                    _cBamChi.viewPDF(file);
                else
                    _cBamChi.viewImage(file);
            else
                MessageBox.Show("File không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void xoaFile_dgvHinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctbamchi == null)
                    dgvHinh.Rows.RemoveAt(dgvHinh.CurrentRow.Index);
                else
                    if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                    {
                        if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (CTaiKhoan.ToTruong == false && CTaiKhoan.ThuKy == false)
                                if (_ctbamchi.CreateBy != CTaiKhoan.MaUser)
                                {
                                    MessageBox.Show("Bạn không phải người lập nên không được phép điều chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            if (dgvHinh.CurrentRow.Cells["ID_Hinh"].Value != null)
                                if (_wsThuongVu.xoa_Hinh("BamChi_ChiTiet_Hinh", _ctbamchi.MaCTBC.ToString(), dgvHinh.CurrentRow.Cells["Name_Hinh"].Value.ToString() + dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString()) == true)
                                    if (_cBamChi.Xoa_Hinh(_cBamChi.get_Hinh(int.Parse(dgvHinh.CurrentRow.Cells["ID_Hinh"].Value.ToString()))))
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

        private void frmBamChi_KeyUp(object sender, KeyEventArgs e)
        {
            if (_dontu_ChiTiet != null && e.Control && e.KeyCode == Keys.T)
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    frmCapNhatDonTu_Thumbnail frm = new frmCapNhatDonTu_Thumbnail(_dontu_ChiTiet, "BamChi_ChiTiet", (int)_ctbamchi.MaCTBC);
                    frm.ShowDialog();
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

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

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmKTXM : Form
    {
        string _mnu = "mnuNhapKQKTXM";
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        CTKTXM _ctktxm = null;
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CThuTien _cThuTien = new CThuTien();
        CKTXM _cKTXM = new CKTXM();
        CDocSo _cDocSo = new CDocSo();
        CHienTrangKiemTra _cHienTrangKiemTra = new CHienTrangKiemTra();
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
            dgvDSKetQuaKiemTra.AutoGenerateColumns = false;

            cmbHienTrangKiemTra.DataSource = _cHienTrangKiemTra.LoadDSHienTrangKiemTra(true);
            cmbHienTrangKiemTra.DisplayMember = "TenHTKT";
            cmbHienTrangKiemTra.ValueMember = "TenHTKT";
            cmbHienTrangKiemTra.SelectedIndex = -1;
            _flagFirst = false;

            if (_MaCTKTXM != -1)
            {
                _ctktxm = _cKTXM.getCTKTXMbyID(_MaCTKTXM);
                if (_ctktxm.KTXM.MaDon != null)
                    txtMaDon.Text = _ctktxm.KTXM.MaDon.ToString().Insert(_ctktxm.KTXM.MaDon.ToString().Length - 2, "-");
                else
                    if (_ctktxm.KTXM.MaDonTXL != null)
                        txtMaDon.Text = "TXL" + _ctktxm.KTXM.MaDonTXL.ToString().Insert(_ctktxm.KTXM.MaDonTXL.ToString().Length - 2, "-");
                    else
                        if (_ctktxm.KTXM.MaDonTBC != null)
                            txtMaDon.Text = "TBC" + _ctktxm.KTXM.MaDonTBC.ToString().Insert(_ctktxm.KTXM.MaDonTBC.ToString().Length - 2, "-");
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
            _cDocSo.getTTDHNbyID(txtDanhBo.Text.Trim(), out a, out b, out c);
            txtHieu.Text = a;
            txtCo.Text = b;
            txtSoThan.Text = c;
        }

        public void LoadCTKTXM(CTKTXM ctktxm)
        {
            txtDanhBo.Text = ctktxm.DanhBo;
            txtHopDong.Text = ctktxm.HopDong;
            txtHoTen.Text = ctktxm.HoTen;
            txtDiaChi.Text = ctktxm.DiaChi;
            txtGiaBieu.Text = ctktxm.GiaBieu;
            txtDinhMuc.Text = ctktxm.DinhMuc;
            ///
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
            txtTieuThuTrungBinh.Text = ctktxm.TieuThuTrungBinh.Value.ToString();
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
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

            _MaCTKTXM = -1;
            _ctktxm = null;
            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            dgvDSKetQuaKiemTra.DataSource = null;
        }

        public void Clear_GetDataGridView()
        {
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
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

            _MaCTKTXM = -1;
            _ctktxm = null;
            _hoadon = null;

            GetDataGridView();
        }

        public void GetDataGridView()
        {
            if (_dontkh != null)
                dgvDSKetQuaKiemTra.DataSource = _cKTXM.GetDS("TKH",  _dontkh.MaDon);
            else
                if (_dontxl != null)
                    dgvDSKetQuaKiemTra.DataSource = _cKTXM.GetDS("TXL",  _dontxl.MaDon);
                else
                    if (_dontbc != null)
                        dgvDSKetQuaKiemTra.DataSource = _cKTXM.GetDS("TBC",  _dontbc.MaDon);
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
                    if (CTaiKhoan.ToXL == true && _cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", ""))) != null)
                    {
                        _dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDon.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");

                        GetDataGridView();

                        MessageBox.Show("Mã Đơn TXL này có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDanhBo.Focus();
                    }
                    else
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    ///Đơn Tổ Bấm Chì
                    if (txtMaDon.Text.Trim().ToUpper().Contains("TBC"))
                    {
                        if (CTaiKhoan.ToBC == true && _cDonTBC.Get(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", ""))) != null)
                        {
                            _dontbc = _cDonTBC.Get(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", "")));
                            txtMaDon.Text = "TBC" + _dontbc.MaDon.ToString().Insert(_dontbc.MaDon.ToString().Length - 2, "-");

                            GetDataGridView();

                            MessageBox.Show("Mã Đơn TBC này có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDanhBo.Focus();
                        }
                        else
                            MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ///Đơn Tổ Khách Hàng
                    else
                        if (CTaiKhoan.ToKH == true && _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) != null)
                        {
                            _dontkh = _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                            txtMaDon.Text = _dontkh.MaDon.ToString().Insert(_dontkh.MaDon.ToString().Length - 2, "-");

                            GetDataGridView();

                            MessageBox.Show("Mã Đơn TKH này có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDanhBo.Focus();
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
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
                    if (txtHoTen.Text.Trim() == "" || txtDiaChi.Text.Trim() == "" || txtNoiDungKiemTra.Text.Trim() == "")
                    {
                        MessageBox.Show("Chưa đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    CTKTXM ctktxm = new CTKTXM();

                    if (_dontkh != null)
                    {
                        if (_cKTXM.CheckExist("TKH", _dontkh.MaDon) == false)
                        {
                            KTXM ktxm = new KTXM();
                            ktxm.MaDon = _dontkh.MaDon;
                            _cKTXM.Them(ktxm);
                        }
                        if (txtDanhBo.Text.Trim() != "" && _cKTXM.CheckExistCT("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim(), dateKTXM.Value)==true)
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
                            if (txtDanhBo.Text.Trim() != "" && _cKTXM.CheckExistCT("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim(), dateKTXM.Value)==true)
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
                                if (txtDanhBo.Text.Trim() != "" && _cKTXM.CheckExistCT("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim(), dateKTXM.Value)==true)
                                {
                                    MessageBox.Show("Danh Bộ này đã được Lập Nội Dung Kiểm Tra", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                ctktxm.MaKTXM = _cKTXM.Get("TBC", _dontbc.MaDon).MaKTXM;
                            }

                    ctktxm.DanhBo = txtDanhBo.Text.Trim();
                    ctktxm.HopDong = txtHopDong.Text.Trim();
                    ctktxm.HoTen = txtHoTen.Text.Trim().ToUpper();
                    ctktxm.DiaChi = txtDiaChi.Text.Trim().ToUpper();
                    ctktxm.GiaBieu = txtGiaBieu.Text.Trim();
                    ctktxm.DinhMuc = txtDinhMuc.Text.Trim();
                    if (_hoadon != null)
                    {
                        ctktxm.Dot = _hoadon.DOT.ToString();
                        ctktxm.Ky = _hoadon.KY.ToString();
                        ctktxm.Nam = _hoadon.NAM.ToString();
                    }
                    ///
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

                    if (_cKTXM.ThemCT(ctktxm))
                    {
                        Clear_GetDataGridView();
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
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (_ctktxm != null)
                    {
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
                        if (_hoadon != null)
                        {
                            _ctktxm.Dot = _hoadon.DOT.ToString();
                            _ctktxm.Ky = _hoadon.KY.ToString();
                            _ctktxm.Nam = _hoadon.NAM.ToString();
                        }
                        ///
                        _ctktxm.NgayKTXM = dateKTXM.Value;

                        if (cmbHienTrangKiemTra.SelectedValue != null)
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

                        if (_cKTXM.SuaCT(_ctktxm))
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
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (_ctktxm != null && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_ctktxm.CreateBy != CTaiKhoan.MaUser)
                        {
                            MessageBox.Show("Bạn không phải người lập nên không được phép điều chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (_cKTXM.XoaCT(_ctktxm))
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
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dgvDSKetQuaKiemTra.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvDSKetQuaKiemTra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvDSKetQuaKiemTra.Rows[e.RowIndex].Selected = true;
                _ctktxm = _cKTXM.getCTKTXMbyID(decimal.Parse(dgvDSKetQuaKiemTra.SelectedRows[0].Cells["MaCTKTXM"].Value.ToString()));
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
                switch (((HienTrangKiemTra)cmbHienTrangKiemTra.SelectedItem).TenHTKT)
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

        

    }
}

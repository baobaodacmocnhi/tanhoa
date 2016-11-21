﻿using System;
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
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmKTXM : Form
    {
        //Dictionary<string, string> _source = new Dictionary<string, string>();
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        HOADON _hoadon = null;
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CThuTien _cThuTien = new CThuTien();
        CKTXM _cKTXM = new CKTXM();
        CDocSo _cDocSo = new CDocSo();
        int selectedindex = -1;
        CHienTrangKiemTra _cHienTrangKiemTra = new CHienTrangKiemTra();
        bool _flagFirst = true;

        public frmKTXM()
        {
            InitializeComponent();
        }

        private void frmKTXM_Load(object sender, EventArgs e)
        {
            dgvDSKetQuaKiemTra.AutoGenerateColumns = false;
            dgvDSKetQuaKiemTra.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSKetQuaKiemTra.Font, FontStyle.Bold);

            cmbHienTrangKiemTra.DataSource = _cHienTrangKiemTra.LoadDSHienTrangKiemTra(true);
            cmbHienTrangKiemTra.DisplayMember = "TenHTKT";
            cmbHienTrangKiemTra.ValueMember = "TenHTKT";
            cmbHienTrangKiemTra.SelectedIndex = -1;
            _flagFirst = false;

                lbTheoYeuCau.Visible = true;
                txtTheoYeuCau.Visible = true;
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
            cmbTinhTrangDHN.SelectedItem = ctktxm.TinhTrangDHN;
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
            //cmbTinhTrangDHN.SelectedIndex = -1;
            txtNoiDungKiemTra.Text = "";
            txtTieuThuTrungBinh.Text = "0";

            selectedindex = -1;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clear();
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                ///Đơn Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", ""))) != null)
                    {
                        _dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDon.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");
                        dgvDSKetQuaKiemTra.DataSource = _cKTXM.LoadDSCTKTXM_TXL(_dontxl.MaDon, CTaiKhoan.MaUser);
                        MessageBox.Show("Mã Đơn TXL này có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDanhBo.Focus();
                    }
                    else
                    {
                        _dontxl = null;
                        dgvDSKetQuaKiemTra.DataSource = null;
                        Clear();
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ///Đơn Tổ Khách Hàng
                else
                    if (_cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) != null)
                    {
                        _donkh = _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                        txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                        //txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                        //if (_cTTKH.getTTKHbyID(_donkh.DanhBo) != null)
                        //{
                        //    _ttkhachhang = _cTTKH.getTTKHbyID(_donkh.DanhBo);
                        //    LoadTTKH(_ttkhachhang);
                        //}
                        //else
                        //{
                        //    _ttkhachhang = null;
                        //    Clear();
                        //    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                        dgvDSKetQuaKiemTra.DataSource = _cKTXM.LoadDSCTKTXM(_donkh.MaDon, CTaiKhoan.MaUser);
                        MessageBox.Show("Mã Đơn KH này có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDanhBo.Focus();
                    }
                    else
                    {
                        _donkh = null;
                        dgvDSKetQuaKiemTra.DataSource = null;
                        Clear();
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
                    cmbChiMatSo.SelectedIndex = 0;
                    cmbChiKhoaGoc.SelectedIndex = 0;
                }
                else
                {
                    _hoadon = null;
                    Clear();
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            if (dgvDSKetQuaKiemTra.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvDSKetQuaKiemTra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedindex = e.RowIndex;
                LoadCTKTXM(_cKTXM.getCTKTXMbyID(decimal.Parse(dgvDSKetQuaKiemTra["MaCTKTXM", e.RowIndex].Value.ToString())));
            }
            catch (Exception)
            {
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
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
                ///Nếu đơn thuộc Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_dontxl != null && txtHoTen.Text.Trim() != "" && txtDiaChi.Text.Trim() != "" && txtNoiDungKiemTra.Text.Trim() != "")
                    {
                        if (!_cKTXM.CheckKTMXbyMaDon_TXL(_dontxl.MaDon))
                        {
                            KTXM ktxm = new KTXM();
                            ktxm.ToXuLy = true;
                            ktxm.MaDonTXL = _dontxl.MaDon;

                            if (_cKTXM.ThemKTXM(ktxm))
                            {
                            }
                        }
                        if (txtDanhBo.Text.Trim()!="" &&_cKTXM.CheckCTKTXMbyMaDonDanhBo_TXL(_dontxl.MaDon, txtDanhBo.Text.Trim(), dateKTXM.Value))
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Nội Dung Kiểm Tra", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        CTKTXM ctktxm = new CTKTXM();
                        ctktxm.MaKTXM = _cKTXM.getKTXMbyMaDon_TXL(_dontxl.MaDon).MaKTXM;
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

                        if (cmbTinhTrangDHN.SelectedItem != null)
                            ctktxm.TinhTrangDHN = cmbTinhTrangDHN.SelectedItem.ToString();

                        ctktxm.NoiDungKiemTra = txtNoiDungKiemTra.Text.Trim();
                        ctktxm.TheoYeuCau = txtTheoYeuCau.Text.Trim().ToUpper();
                        ctktxm.TieuThuTrungBinh = int.Parse(txtTieuThuTrungBinh.Text.Trim());

                        if (_cKTXM.ThemCTKTXM(ctktxm))
                        {
                            MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvDSKetQuaKiemTra.DataSource = _cKTXM.LoadDSCTKTXM_TXL(_dontxl.MaDon, CTaiKhoan.MaUser);
                            _hoadon = null;
                            Clear();
                        }
                    }
                    else
                        MessageBox.Show("Đơn này không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ///Nếu đơn thuộc Tổ Khách Hàng
                else
                    if (_donkh != null && txtHoTen.Text.Trim() != "" && txtDiaChi.Text.Trim() != "" && txtNoiDungKiemTra.Text.Trim() != "")
                    //if (_donkh != null && txtNoiDungKiemTra.Text.Trim() != "")
                    {
                        if (!_cKTXM.CheckKTMXbyMaDon(_donkh.MaDon))
                        {
                            KTXM ktxm = new KTXM();
                            ktxm.MaDon = _donkh.MaDon;
                            //string MaNoiChuyenDen, NoiChuyenDen, LyDoChuyenDen;
                            //_cKTXM.GetInfobyMaDon(_donkh.MaDon, out MaNoiChuyenDen, out NoiChuyenDen, out LyDoChuyenDen);
                            //ktxm.MaNoiChuyenDen = decimal.Parse(MaNoiChuyenDen);
                            //ktxm.NoiChuyenDen = NoiChuyenDen;
                            //ktxm.LyDoChuyenDen = LyDoChuyenDen;
                            if (_cKTXM.ThemKTXM(ktxm))
                            {
                                ///Báo cho bảng DonKH là đơn này đã được nơi nhận xử lý
                                //DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(MaNoiChuyenDen));
                                //donkh.Chuyen = true;
                                //donkh.MaChuyen = "KTXM";
                            }
                        }
                        if (_cKTXM.CheckCTKTXMbyMaDonDanhBo(_donkh.MaDon, txtDanhBo.Text.Trim(), dateKTXM.Value))
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Nội Dung Kiểm Tra", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        CTKTXM ctktxm = new CTKTXM();
                        ctktxm.MaKTXM = _cKTXM.getKTXMbyMaDon(_donkh.MaDon).MaKTXM;
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

                        if (cmbTinhTrangDHN.SelectedItem != null)
                            ctktxm.TinhTrangDHN = cmbTinhTrangDHN.SelectedItem.ToString();

                        ctktxm.NoiDungKiemTra = txtNoiDungKiemTra.Text.Trim();
                        ctktxm.TheoYeuCau = txtTheoYeuCau.Text.Trim().ToUpper();
                        ctktxm.TieuThuTrungBinh = int.Parse(txtTieuThuTrungBinh.Text.Trim());

                        if (_cKTXM.ThemCTKTXM(ctktxm))
                        {
                            MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvDSKetQuaKiemTra.DataSource = _cKTXM.LoadDSCTKTXM(_donkh.MaDon, CTaiKhoan.MaUser);
                            _hoadon = null;
                            Clear();
                        }
                    }
                    else
                        MessageBox.Show("Đơn này không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (selectedindex != -1)
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

                    CTKTXM ctktxm = new CTKTXM();
                    ctktxm = _cKTXM.getCTKTXMbyID(decimal.Parse(dgvDSKetQuaKiemTra["MaCTKTXM", selectedindex].Value.ToString()));
                    ctktxm.DanhBo = txtDanhBo.Text.Trim();
                    ctktxm.HopDong = txtHopDong.Text.Trim();
                    ctktxm.HoTen = txtHoTen.Text.Trim();
                    ctktxm.DiaChi = txtDiaChi.Text.Trim();
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
                    ctktxm.HoTenKHKy = txtHoTenKHKy.Text.Trim();

                    if (cmbTinhTrangDHN.SelectedItem != null)
                        ctktxm.TinhTrangDHN = cmbTinhTrangDHN.SelectedItem.ToString();

                    ctktxm.NoiDungKiemTra = txtNoiDungKiemTra.Text.Trim();
                    ctktxm.TheoYeuCau = txtTheoYeuCau.Text.Trim().ToUpper();
                    ctktxm.TieuThuTrungBinh = int.Parse(txtTieuThuTrungBinh.Text.Trim());

                    ///Nếu Đơn thuộc Tổ Xử Lý
                    if (ctktxm.KTXM.ToXuLy)
                    {
                        if (_dontxl != null && txtHoTen.Text.Trim() != "" && txtDiaChi.Text.Trim() != "" && txtNoiDungKiemTra.Text.Trim() != "")
                        {
                            if (_cKTXM.SuaCTKTXM(ctktxm))
                            {
                                MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvDSKetQuaKiemTra.DataSource = _cKTXM.LoadDSCTKTXM_TXL(_dontxl.MaDon, CTaiKhoan.MaUser);
                                Clear();
                            }
                        }
                        else
                            MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        ///Nếu Đơn thuộc Tổ Khách Hàng
                        if (_donkh != null && txtHoTen.Text.Trim() != "" && txtDiaChi.Text.Trim() != "" && txtNoiDungKiemTra.Text.Trim() != "")
                        {
                            if (_cKTXM.SuaCTKTXM(ctktxm))
                            {
                                MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvDSKetQuaKiemTra.DataSource = _cKTXM.LoadDSCTKTXM(_donkh.MaDon, CTaiKhoan.MaUser);
                                Clear();
                            }
                        }
                        else
                            MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtCo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtChiSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

    }
}

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
using KTKS_DonKH.DAL.HeThong;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.BamChi;

namespace KTKS_DonKH.GUI.BamChi
{
    public partial class frmBamChi : Form
    {
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        TTKhachHang _ttkhachhang = null;
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CTTKH _cTTKH = new CTTKH();
        CBamChi _cBamChi = new CBamChi();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        int selectedindex = -1;
        CTrangThaiBamChi _cTrangThaiBamChi = new CTrangThaiBamChi();
        bool _flagFirst = true;

        public frmBamChi()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        public void LoadTTKH(TTKhachHang ttkhachhang)
        {
            txtDanhBo.Text = ttkhachhang.DanhBo;
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2;
            txtGiaBieu.Text = ttkhachhang.GB;
            txtDinhMuc.Text = ttkhachhang.TGDM;
            string a, b, c;
            _cPhuongQuan.getTTDHNbyID(txtDanhBo.Text.Trim(), out a, out b, out c);
            txtHieu.Text = a;
            txtCo.Text = b;
            txtSoThan.Text = c;
        }

        public void LoadCTBamChi(CTBamChi ctbamchi)
        {
            txtDanhBo.Text = ctbamchi.DanhBo;
            txtHopDong.Text = ctbamchi.HopDong;
            txtHoTen.Text = ctbamchi.HoTen;
            txtDiaChi.Text = ctbamchi.DiaChi;
            txtGiaBieu.Text = ctbamchi.GiaBieu.ToString();
            txtDinhMuc.Text = ctbamchi.DinhMuc.ToString();
            ///
            dateBamChi.Value = ctbamchi.NgayBC.Value;
            cmbHienTrangKiemTra.SelectedItem = ctbamchi.HienTrangKiemTra;
            txtHieu.Text = ctbamchi.Hieu;
            txtCo.Text = ctbamchi.Co.ToString();
            txtSoThan.Text = ctbamchi.SoThan;
            cmbChiMatSo.SelectedItem = ctbamchi.ChiMatSo;
            cmbChiKhoaGoc.SelectedItem = ctbamchi.ChiKhoaGoc;
            txtMucDichSuDung.Text = ctbamchi.MucDichSuDung;
            txtChiSo.Text = ctbamchi.ChiSo.ToString();
            cmbTinhTrangChiSo.SelectedItem = ctbamchi.TinhTrangChiSo;
            txtVienChi.Text = ctbamchi.VienChi.ToString();
            txtDayChi.Text = ctbamchi.DayChi.ToString();
            cmbTrangThaiBC.SelectedValue = ctbamchi.TrangThaiBC;
            txtMaSoBC.Text = ctbamchi.MaSoBC;
            txtTheoYeuCau.Text = ctbamchi.TheoYeuCau;
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
            dateBamChi.Value = DateTime.Now;
            cmbHienTrangKiemTra.SelectedIndex = -1;
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
            cmbTrangThaiBC.SelectedIndex = -1;
            txtMaSoBC.Text = "";
            txtTheoYeuCau.Text = "";

            selectedindex = -1;
        }

        private void frmNhapBamChi_Load(object sender, EventArgs e)
        {
            dgvDSNhapBamChi.AutoGenerateColumns = false;
            dgvDSNhapBamChi.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSNhapBamChi.Font, FontStyle.Bold);

            cmbTrangThaiBC.DataSource = _cTrangThaiBamChi.LoadDSTrangThaiBamChi(true);
            cmbTrangThaiBC.DisplayMember = "TenTTBC";
            cmbTrangThaiBC.ValueMember = "TenTTBC";
            cmbTrangThaiBC.SelectedIndex = -1;
            _flagFirst = false;

            txtMaSoBC.Text = CTaiKhoan.MaKiemBamChi;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                ///Đơn Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", ""))) != null)
                    {
                        _dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDon.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");
                        dgvDSNhapBamChi.DataSource = _cBamChi.LoadDSCTBamChi_TXL(_dontxl.MaDon, CTaiKhoan.MaUser);
                        MessageBox.Show("Mã Đơn TXL này có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDanhBo.Focus();
                    }
                    else
                    {
                        _dontxl = null;
                        dgvDSNhapBamChi.DataSource = null;
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
                        dgvDSNhapBamChi.DataSource = _cBamChi.LoadDSCTBamChi(_donkh.MaDon, CTaiKhoan.MaUser);
                        MessageBox.Show("Mã Đơn KH này có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDanhBo.Focus();
                    }
                    else
                    {
                        _donkh = null;
                        dgvDSNhapBamChi.DataSource = null;
                        Clear();
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cTTKH.getTTKHbyID(txtDanhBo.Text.Trim()) != null)
                {
                    _ttkhachhang = _cTTKH.getTTKHbyID(txtDanhBo.Text.Trim());
                    LoadTTKH(_ttkhachhang);
                    cmbChiMatSo.SelectedIndex = 0;
                    cmbChiKhoaGoc.SelectedIndex = 0;
                }
                else
                {
                    _ttkhachhang = null;
                    Clear();
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                ///Nếu đơn thuộc Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_dontxl != null && (txtDanhBo.Text.Trim() != "" || txtHoTen.Text.Trim() != "" || txtDiaChi.Text.Trim() != ""))
                    {
                        if (!_cBamChi.CheckBamChibyMaDon_TXL(_dontxl.MaDon))
                        {
                            LinQ.BamChi bamchi = new LinQ.BamChi();
                            bamchi.ToXuLy = true;
                            bamchi.MaDonTXL = _dontxl.MaDon;

                            if (_cBamChi.ThemBamChi(bamchi))
                            {
                                if (string.IsNullOrEmpty(_dontxl.TienTrinh))
                                    _dontxl.TienTrinh = "BamChi";
                                else
                                    _dontxl.TienTrinh += ",BamChi";
                                _dontxl.Nhan = true;
                                _cDonTXL.SuaDonTXL(_dontxl, true);
                            }
                        }
                        if (_cBamChi.CheckCTBamChibyMaDonDanhBo_TXL(_dontxl.MaDon, txtDanhBo.Text.Trim(),dateBamChi.Value))
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Bấm Chì", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        CTBamChi ctbamchi = new CTBamChi();
                        ctbamchi.MaBC = _cBamChi.getBamChibyMaDon_TXL(_dontxl.MaDon).MaBC;
                        ctbamchi.DanhBo = txtDanhBo.Text.Trim();
                        ctbamchi.HopDong = txtHopDong.Text.Trim();
                        ctbamchi.HoTen = txtHoTen.Text.Trim().ToUpper();
                        ctbamchi.DiaChi = txtDiaChi.Text.Trim().ToUpper();
                        if (!string.IsNullOrEmpty(txtGiaBieu.Text.Trim()))
                            ctbamchi.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                            ctbamchi.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        if (_ttkhachhang != null)
                        {
                            ctbamchi.Dot = _ttkhachhang.Dot;
                            ctbamchi.Ky = _ttkhachhang.Ky;
                            ctbamchi.Nam = _ttkhachhang.Nam;
                        }
                        ///
                        ctbamchi.NgayBC = dateBamChi.Value;

                        if (cmbHienTrangKiemTra.SelectedItem != null)
                            ctbamchi.HienTrangKiemTra = cmbHienTrangKiemTra.SelectedItem.ToString();

                        ctbamchi.Hieu = txtHieu.Text.Trim();

                        if (!string.IsNullOrEmpty(txtCo.Text.Trim()))
                            ctbamchi.Co = int.Parse(txtCo.Text.Trim());

                        ctbamchi.SoThan = txtSoThan.Text.Trim();

                        if (!string.IsNullOrEmpty(txtChiSo.Text.Trim()))
                            ctbamchi.ChiSo = int.Parse(txtChiSo.Text.Trim());

                        if (cmbTinhTrangChiSo.SelectedItem != null)
                        ctbamchi.TinhTrangChiSo = cmbTinhTrangChiSo.SelectedItem.ToString();

                        if (cmbChiMatSo.SelectedItem != null)
                        ctbamchi.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();

                        if (cmbChiKhoaGoc.SelectedItem != null)
                        ctbamchi.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();

                        ctbamchi.MucDichSuDung = txtMucDichSuDung.Text.Trim();

                        if (cmbTrangThaiBC.SelectedValue != null)
                            ctbamchi.TrangThaiBC = cmbTrangThaiBC.SelectedValue.ToString();

                        ctbamchi.MaSoBC = txtMaSoBC.Text.Trim();

                        if (!string.IsNullOrEmpty(txtVienChi.Text.Trim()))
                            ctbamchi.VienChi = int.Parse(txtVienChi.Text.Trim());

                        if (!string.IsNullOrEmpty(txtDayChi.Text.Trim()))
                            ctbamchi.DayChi = double.Parse(txtDayChi.Text.Trim());

                        ctbamchi.TheoYeuCau = txtTheoYeuCau.Text.Trim().ToUpper();

                        if (_cBamChi.ThemCTBamChi(ctbamchi))
                        {
                            MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvDSNhapBamChi.DataSource = _cBamChi.LoadDSCTBamChi_TXL(_dontxl.MaDon, CTaiKhoan.MaUser);
                            _ttkhachhang = null;
                            txtDanhBo.Text = "";
                            txtHopDong.Text = "";
                            txtHoTen.Text = "";
                            txtDiaChi.Text = "";
                            txtGiaBieu.Text = "";
                            txtDinhMuc.Text = "";
                            ///
                            txtChiSo.Text = "";
                            cmbTinhTrangChiSo.SelectedIndex = -1;
                        }
                    }
                    else
                        MessageBox.Show("Đơn này không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ///Nếu đơn thuộc Tổ Khách Hàng
                else
                    if (_donkh != null && (txtDanhBo.Text.Trim() != "" || txtHoTen.Text.Trim() != "" || txtDiaChi.Text.Trim() != ""))
                    {
                        if (!_cBamChi.CheckBamChibyMaDon(_donkh.MaDon))
                        {
                            LinQ.BamChi bamchi = new LinQ.BamChi();
                            bamchi.MaDon = _donkh.MaDon;

                            if (_cBamChi.ThemBamChi(bamchi))
                            {
                                if (string.IsNullOrEmpty(_donkh.TienTrinh))
                                    _donkh.TienTrinh = "BamChi";
                                else
                                    _donkh.TienTrinh += ",BamChi";
                                _donkh.Nhan = true;
                                _cDonKH.SuaDonKH(_donkh, true);
                            }
                        }
                        if (_cBamChi.CheckCTBamChibyMaDonDanhBo(_donkh.MaDon, txtDanhBo.Text.Trim(),dateBamChi.Value))
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Bấm Chì", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        CTBamChi ctbamchi = new CTBamChi();
                        ctbamchi.MaBC = _cBamChi.getBamChibyMaDon(_donkh.MaDon).MaBC;
                        ctbamchi.DanhBo = txtDanhBo.Text.Trim();
                        ctbamchi.HopDong = txtHopDong.Text.Trim();
                        ctbamchi.HoTen = txtHoTen.Text.Trim().ToUpper();
                        ctbamchi.DiaChi = txtDiaChi.Text.Trim().ToUpper();
                        if (!string.IsNullOrEmpty(txtGiaBieu.Text.Trim()))
                            ctbamchi.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                            ctbamchi.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        if (_ttkhachhang != null)
                        {
                            ctbamchi.Dot = _ttkhachhang.Dot;
                            ctbamchi.Ky = _ttkhachhang.Ky;
                            ctbamchi.Nam = _ttkhachhang.Nam;
                        }
                        ///
                        ctbamchi.NgayBC = dateBamChi.Value;

                        if (cmbHienTrangKiemTra.SelectedItem != null)
                            ctbamchi.HienTrangKiemTra = cmbHienTrangKiemTra.SelectedItem.ToString();

                        ctbamchi.Hieu = txtHieu.Text.Trim();

                        if (!string.IsNullOrEmpty(txtCo.Text.Trim()))
                            ctbamchi.Co = int.Parse(txtCo.Text.Trim());

                        ctbamchi.SoThan = txtSoThan.Text.Trim();

                        if (!string.IsNullOrEmpty(txtChiSo.Text.Trim()))
                            ctbamchi.ChiSo = int.Parse(txtChiSo.Text.Trim());

                        if (cmbTinhTrangChiSo.SelectedItem != null)
                        ctbamchi.TinhTrangChiSo = cmbTinhTrangChiSo.SelectedItem.ToString();

                        if (cmbChiMatSo.SelectedItem != null)
                        ctbamchi.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();

                        if (cmbChiKhoaGoc.SelectedItem != null)
                        ctbamchi.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();

                        ctbamchi.MucDichSuDung = txtMucDichSuDung.Text.Trim();

                        if (cmbTrangThaiBC.SelectedValue != null)
                            ctbamchi.TrangThaiBC = cmbTrangThaiBC.SelectedValue.ToString();

                        ctbamchi.MaSoBC = txtMaSoBC.Text.Trim();

                        if (!string.IsNullOrEmpty(txtVienChi.Text.Trim()))
                            ctbamchi.VienChi = int.Parse(txtVienChi.Text.Trim());

                        if (!string.IsNullOrEmpty(txtDayChi.Text.Trim()))
                            ctbamchi.DayChi = double.Parse(txtDayChi.Text.Trim(), System.Globalization.NumberStyles.Float);

                        ctbamchi.TheoYeuCau = txtTheoYeuCau.Text.Trim().ToUpper();

                        if (_cBamChi.ThemCTBamChi(ctbamchi))
                        {
                            MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvDSNhapBamChi.DataSource = _cBamChi.LoadDSCTBamChi(_donkh.MaDon, CTaiKhoan.MaUser);
                            _ttkhachhang = null;
                            txtDanhBo.Text = "";
                            txtHopDong.Text = "";
                            txtHoTen.Text = "";
                            txtDiaChi.Text = "";
                            txtGiaBieu.Text = "";
                            txtDinhMuc.Text = "";
                            ///
                            txtChiSo.Text = "";
                            cmbTinhTrangChiSo.SelectedIndex = -1;
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
                    CTBamChi ctbamchi = new CTBamChi();
                    ctbamchi = _cBamChi.getCTBamChibyID(decimal.Parse(dgvDSNhapBamChi["MaCTBC", selectedindex].Value.ToString()));
                    ctbamchi.DanhBo = txtDanhBo.Text.Trim();
                    ctbamchi.HopDong = txtHopDong.Text.Trim();
                    ctbamchi.HoTen = txtHoTen.Text.Trim();
                    ctbamchi.DiaChi = txtDiaChi.Text.Trim();
                    if (!string.IsNullOrEmpty(txtGiaBieu.Text.Trim()))
                        ctbamchi.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                    if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                        ctbamchi.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                    if (_ttkhachhang != null)
                    {
                        ctbamchi.Dot = _ttkhachhang.Dot;
                        ctbamchi.Ky = _ttkhachhang.Ky;
                        ctbamchi.Nam = _ttkhachhang.Nam;
                    }
                    ///
                    ctbamchi.NgayBC = dateBamChi.Value;

                    if (cmbHienTrangKiemTra.SelectedItem != null)
                        ctbamchi.HienTrangKiemTra = cmbHienTrangKiemTra.SelectedItem.ToString();

                    ctbamchi.Hieu = txtHieu.Text.Trim();

                    if (!string.IsNullOrEmpty(txtCo.Text.Trim()))
                        ctbamchi.Co = int.Parse(txtCo.Text.Trim());

                    ctbamchi.SoThan = txtSoThan.Text.Trim();

                    if (!string.IsNullOrEmpty(txtChiSo.Text.Trim()))
                        ctbamchi.ChiSo = int.Parse(txtChiSo.Text.Trim());

                    if (cmbTinhTrangChiSo.SelectedItem != null)
                    ctbamchi.TinhTrangChiSo = cmbTinhTrangChiSo.SelectedItem.ToString();

                    if (cmbChiMatSo.SelectedItem != null)
                    ctbamchi.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();

                    if (cmbChiKhoaGoc.SelectedItem != null)
                    ctbamchi.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();

                    ctbamchi.MucDichSuDung = txtMucDichSuDung.Text.Trim();

                    if (cmbTrangThaiBC.SelectedValue != null)
                        ctbamchi.TrangThaiBC = cmbTrangThaiBC.SelectedValue.ToString();

                    ctbamchi.MaSoBC = txtMaSoBC.Text.Trim();

                    if (!string.IsNullOrEmpty(txtVienChi.Text.Trim()))
                        ctbamchi.VienChi = int.Parse(txtVienChi.Text.Trim());

                    if (!string.IsNullOrEmpty(txtDayChi.Text.Trim()))
                        ctbamchi.DayChi = double.Parse(txtDayChi.Text.Trim());

                    ctbamchi.TheoYeuCau = txtTheoYeuCau.Text.Trim();

                    ///Nếu Đơn thuộc Tổ Xử Lý
                    if (ctbamchi.BamChi.ToXuLy)
                    {
                        if (_dontxl != null && (txtDanhBo.Text.Trim() != "" || txtHoTen.Text.Trim() != "" || txtDiaChi.Text.Trim() != ""))
                        {
                            if (_cBamChi.SuaCTBamChi(ctbamchi))
                            {
                                MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvDSNhapBamChi.DataSource = _cBamChi.LoadDSCTBamChi_TXL(_dontxl.MaDon, CTaiKhoan.MaUser);
                                Clear();
                            }
                        }
                        else
                            MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        ///Nếu Đơn thuộc Tổ Khách Hàng
                        if (_donkh != null && (txtDanhBo.Text.Trim() != "" || txtHoTen.Text.Trim() != "" || txtDiaChi.Text.Trim() != ""))
                        {
                            if (_cBamChi.SuaCTBamChi(ctbamchi))
                            {
                                MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvDSNhapBamChi.DataSource = _cBamChi.LoadDSCTBamChi(_donkh.MaDon, CTaiKhoan.MaUser);
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

        private void dgvDSNhapBamChi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedindex = e.RowIndex;
                LoadCTBamChi(_cBamChi.getCTBamChibyID(decimal.Parse(dgvDSNhapBamChi["MaCTBC", e.RowIndex].Value.ToString())));
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
            if (dgvDSNhapBamChi.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void txtVienChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDayChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != Char.Parse("."))
                e.Handled = true;
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

        private void cmbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagFirst)
            {

            }
            else
                switch (((TrangThaiBamChi)cmbTrangThaiBC.SelectedItem).TenTTBC)
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
                    default:
                        txtVienChi.Text = "1";
                        txtDayChi.Text = "0.6";
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
    }
}

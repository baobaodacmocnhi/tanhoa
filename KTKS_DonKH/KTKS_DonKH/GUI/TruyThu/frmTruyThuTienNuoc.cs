﻿using System;
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
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ToXuLy;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.DAL.TruyThu;
using KTKS_DonKH.BaoCao.TruyThu;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.BaoCao.ThuMoi;
using KTKS_DonKH.GUI.DonTu;

namespace KTKS_DonKH.GUI.TruyThu
{
    public partial class frmTruyThuTienNuoc : Form
    {
        string _mnu = "mnuTruyThuDMNuoc";
        CDonTu _cDonTu = new CDonTu();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();
        CTruyThuTienNuoc _cTTTN = new CTruyThuTienNuoc();

        DonTu_ChiTiet _dontu_ChiTiet = null;
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        TruyThuTienNuoc_ChiTiet _cttttn = null;
        int _IDCT = -1;

        public frmTruyThuTienNuoc()
        {
            InitializeComponent();
        }

        public frmTruyThuTienNuoc(int IDCT)
        {
            _IDCT = IDCT;
            InitializeComponent();
        }

        private void frmTruyThuTienNuoc_Load(object sender, EventArgs e)
        {
            dgvTruyThuTienNuoc.AutoGenerateColumns = false;
            dgvThanhToanTruyThuTienNuoc.AutoGenerateColumns = false;
            dgvThuMoi.AutoGenerateColumns = false;

            DataTable dt1 = _cTTTN.GetDSNoiDung();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (DataRow item in dt1.Rows)
            {
                auto1.Add(item["NoiDung"].ToString());
            }
            txtNoiDung.AutoCompleteCustomSource = auto1;

            if (_IDCT != -1)
            {
                txtMaCTTTTN.Text = _IDCT.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtMaCTTTTN_KeyPress(sender, arg);
            }
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHopDong.Text = hoadon.HOPDONG;
            txtLoTrinh.Text = hoadon.DOT + hoadon.MAY + hoadon.STT;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
            txtGiaBieu.Text = hoadon.GB.ToString();
            txtDinhMuc.Text = hoadon.DM.ToString();
        }

        public void LoadTTTN(TruyThuTienNuoc_ChiTiet cttttn)
        {
            if (cttttn.TruyThuTienNuoc.MaDonMoi != null)
            {
                _dontu_ChiTiet = _cDonTu.get_ChiTiet(cttttn.TruyThuTienNuoc.MaDonMoi.Value, cttttn.STT.Value);
                if (_dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count == 1)
                    txtMaDonMoi.Text = cttttn.TruyThuTienNuoc.MaDonMoi.ToString();
                else
                    txtMaDonMoi.Text = cttttn.TruyThuTienNuoc.MaDonMoi.Value.ToString() + "." + cttttn.STT.Value.ToString();
            }
            else
            if (cttttn.TruyThuTienNuoc.MaDon != null)
            {
                _dontkh = _cDonKH.Get(cttttn.TruyThuTienNuoc.MaDon.Value);
                txtMaDonCu.Text = cttttn.TruyThuTienNuoc.MaDon.Value.ToString().Insert(cttttn.TruyThuTienNuoc.MaDon.Value.ToString().Length - 2, "-");
            }
            else
                if (cttttn.TruyThuTienNuoc.MaDonTXL != null)
                {
                    _dontxl = _cDonTXL.Get(cttttn.TruyThuTienNuoc.MaDonTXL.Value);
                    txtMaDonCu.Text = "TXL" + cttttn.TruyThuTienNuoc.MaDonTXL.Value.ToString().Insert(cttttn.TruyThuTienNuoc.MaDonTXL.Value.ToString().Length - 2, "-");
                }
                else
                    if (cttttn.TruyThuTienNuoc.MaDonTBC != null)
                    {
                        _dontbc = _cDonTBC.Get(cttttn.TruyThuTienNuoc.MaDonTBC.Value);
                        txtMaDonCu.Text = "TBC" + cttttn.TruyThuTienNuoc.MaDonTBC.Value.ToString().Insert(cttttn.TruyThuTienNuoc.MaDonTBC.Value.ToString().Length - 2, "-");
                    }
            txtMaCTTTTN.Text = cttttn.IDCT.ToString().Insert(cttttn.IDCT.ToString().Length - 2, "-");
            //chkXepDon.Checked = cttttn.XepDon;
            if (cttttn.NgayTinhTrang != null)
                dateTinhTrang.Value = cttttn.NgayTinhTrang.Value;
            cmbTinhTrang.SelectedItem = cttttn.TinhTrang;
            txtDanhBo.Text = cttttn.DanhBo;
            txtHopDong.Text = cttttn.HopDong;
            txtLoTrinh.Text = cttttn.LoTrinh;
            txtGiaBieu.Text = cttttn.GiaBieu.Value.ToString();
            if (cttttn.DinhMuc != null)
                txtDinhMuc.Text = cttttn.DinhMuc.Value.ToString();
            txtHoTen.Text = cttttn.HoTen;
            txtDiaChi.Text = cttttn.DiaChi;
            txtDienThoai.Text = cttttn.DienThoai;
            txtNoiDung.Text = cttttn.NoiDung;

            foreach (TruyThuTienNuoc_HoaDon item in cttttn.TruyThuTienNuoc_HoaDons.ToList())
            {
                dgvTruyThuTienNuoc.Rows.Insert(dgvTruyThuTienNuoc.RowCount - 1, 1);

                dgvTruyThuTienNuoc["ID_HoaDon", dgvTruyThuTienNuoc.RowCount - 2].Value = item.ID;
                dgvTruyThuTienNuoc["Ky", dgvTruyThuTienNuoc.RowCount - 2].Value = item.Ky;
                dgvTruyThuTienNuoc["Nam", dgvTruyThuTienNuoc.RowCount - 2].Value = item.Nam;
                dgvTruyThuTienNuoc["GiaBieu_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.GiaBieuCu;
                dgvTruyThuTienNuoc["DinhMuc_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.DinhMucCu;
                dgvTruyThuTienNuoc["TieuThu_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.TieuThuCu;
                dgvTruyThuTienNuoc["TongCong_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.TongCongCu;
                dgvTruyThuTienNuoc["GiaBieu_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.GiaBieuMoi;
                dgvTruyThuTienNuoc["DinhMuc_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.DinhMucMoi;
                dgvTruyThuTienNuoc["TieuThu_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.TieuThuMoi;
                dgvTruyThuTienNuoc["GiaBan_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.GiaBanMoi;
                dgvTruyThuTienNuoc["ThueGTGT_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.ThueGTGTMoi;
                dgvTruyThuTienNuoc["PhiBVMT_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.PhiBVMTMoi;
                dgvTruyThuTienNuoc["TongCong_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.TongCongMoi;
            }

            LoadDSThanhToan(cttttn.IDCT);
            LoadDSThuMoi(cttttn.IDCT);

            int Tongm3HoaDon = 0;
            int Tongm3ThucTe = 0;
            int GiaBan = 0;
            int ThueGTGT = 0;
            int PhiBVMT = 0;
            int TongCongCu = 0;
            int TongCongMoi = 0;
            foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                if (item.Cells["Ky"].Value != null)
                {
                    Tongm3HoaDon += int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                    Tongm3ThucTe += int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                    GiaBan += int.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                    ThueGTGT += int.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                    PhiBVMT += int.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                    TongCongMoi += int.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                    TongCongCu += int.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                }
            txtSoKy.Text = (dgvTruyThuTienNuoc.RowCount - 1).ToString();
            txtTongm3HoaDon.Text = Tongm3HoaDon.ToString();
            txtTongm3ThucTe.Text = Tongm3ThucTe.ToString();
            txtTongm3TruyThu.Text = (Tongm3ThucTe - Tongm3HoaDon).ToString();
            txtGiaBan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaBan);
            txtThueGTGT.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ThueGTGT);
            txtPhiBVMT.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", PhiBVMT);
            txtTongCongMoi.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongMoi);
            txtTongCongCu.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongCu);
            txtTongThanhToan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongMoi - TongCongCu);
        }

        public void Clear()
        {
            txtMaDonCu.Text = "";
            txtMaCTTTTN.Text = "";
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtLoTrinh.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDienThoai.Text = "";
            txtNoiDung.Text = "";
            cmbTinhTrang.SelectedIndex = -1;
            ///
            dateDongTien.Value = DateTime.Now;
            txtSoTien.Text = "";
            ///
            txtVaoLuc.Text = "";
            txtVeViec.Text = "";
            ///
            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            _cttttn = null;
            _IDCT = -1;
            ///
            //dgvTruyThuTienNuoc.DataSource = null;
            dgvTruyThuTienNuoc.Rows.Clear();
            dgvThanhToanTruyThuTienNuoc.DataSource = null;
            dgvThuMoi.DataSource = null;
        }

        public void ClearThanhToan()
        {
            dateDongTien.Value = DateTime.Now;
            txtSoTien.Text = "";
        }

        public void ClearThuMoi()
        {
            txtVaoLuc.Text = "";
            txtVeViec.Text = "";
        }

        public void LoadDSThanhToan(int IDCT)
        {
            dgvThanhToanTruyThuTienNuoc.DataSource = _cTTTN.getDS_ThanhToan(IDCT);
        }

        public void LoadDSThuMoi(int IDCT)
        {
            dgvThuMoi.DataSource = _cTTTN.getDS_ThuMoi(IDCT);
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
                        _cttttn = _cTTTN.get_ChiTiet("TXL", decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                        if (_cttttn != null)
                        {
                            LoadTTTN(_cttttn);
                        }
                        else
                        {
                            _dontxl = _cDonTXL.Get(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                            txtMaDonCu.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");

                            _hoadon = _cThuTien.GetMoiNhat(_dontxl.DanhBo);
                            if (_hoadon != null)
                            {
                                LoadTTKH(_hoadon);
                            }
                            else
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    if (txtMaDonCu.Text.Trim().ToUpper().Contains("TBC"))
                    {
                        if (_cDonTBC.CheckExist(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", ""))) == true)
                        {
                            _cttttn = _cTTTN.get_ChiTiet("TBC", decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                            if (_cttttn != null)
                            {
                                LoadTTTN(_cttttn);
                            }
                            else
                            {
                                _dontbc = _cDonTBC.Get(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                                txtMaDonCu.Text = "TBC" + _dontbc.MaDon.ToString().Insert(_dontbc.MaDon.ToString().Length - 2, "-");

                                _hoadon = _cThuTien.GetMoiNhat(_dontbc.DanhBo);
                                if (_hoadon != null)
                                {
                                    LoadTTKH(_hoadon);
                                }
                                else
                                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ///Đơn Tổ Khách Hàng
                    else
                        if (_cDonKH.CheckExist(decimal.Parse(txtMaDonCu.Text.Trim().Replace("-", ""))) == true)
                        {
                            _cttttn = _cTTTN.get_ChiTiet("TKH", decimal.Parse(txtMaDonCu.Text.Trim().Replace("-", "")));
                            if (_cttttn != null)
                            {
                                LoadTTTN(_cttttn);
                            }
                            else
                            {
                                _dontkh = _cDonKH.Get(decimal.Parse(txtMaDonCu.Text.Trim().Replace("-", "")));
                                txtMaDonCu.Text = _dontkh.MaDon.ToString().Insert(_dontkh.MaDon.ToString().Length - 2, "-");

                                _hoadon = _cThuTien.GetMoiNhat(_dontkh.DanhBo);
                                if (_hoadon != null)
                                {
                                    LoadTTKH(_hoadon);
                                }
                                else
                                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Length == 11)
            {
                _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                LoadTTKH(_hoadon);
            }
        }

        private void txtMaCTTTTN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaCTTTTN.Text.Trim() != "")
            {
                string IDCT = txtMaCTTTTN.Text.Trim().Replace("-","");
                Clear();
                _cttttn = _cTTTN.get_ChiTiet(int.Parse(IDCT));
                if (_cttttn != null)
                    LoadTTTN(_cttttn);
                else
                    MessageBox.Show("Không có Mã Truy Thu này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTruyThuTienNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTruyThuTienNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvTruyThuTienNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TongCong_Cu" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "GiaBan_Moi" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "ThueGTGT_Moi" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "PhiBVMT_Moi" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TongCong_Moi" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTruyThuTienNuoc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTruyThuTienNuoc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "GiaBieu_Cu")
            {
                dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value = dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value;

                int DinhMuc = 0;
                int TieuThu = 0;
                if (dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString()))
                    DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString());
                if (dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString()))
                    TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString());

                string ChiTietCu = "";
                int TongTienCu = _cGiaNuoc.TinhTienNuoc(txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString()), DinhMuc, TieuThu, out ChiTietCu);
                int PhiBVMT = _cGiaNuoc.TinhPhiBMVT(int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString()), DinhMuc, TieuThu);

                dgvTruyThuTienNuoc["GiaBan_Cu", e.RowIndex].Value = TongTienCu;
                dgvTruyThuTienNuoc["ThueGTGT_Cu", e.RowIndex].Value = Math.Round((double)TongTienCu * 5 / 100);
                if (PhiBVMT == 0)
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", e.RowIndex].Value = TongTienCu * 10 / 100;
                    dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + (TongTienCu * 10 / 100);
                }
                else
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", e.RowIndex].Value = PhiBVMT;
                    dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + PhiBVMT;
                }
                if (dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value != null)
                    if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) < int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                        dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Tăng";
                    else
                        if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) > int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Giảm";
                        else
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "";
            }

            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "DinhMuc_Cu")
            {
                dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value = dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value;

                int GiaBieu = 0;
                int TieuThu = 0;
                if (dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString()))
                    GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString());
                if (dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString()))
                    TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString());

                string ChiTietCu = "";
                int TongTienCu = _cGiaNuoc.TinhTienNuoc( txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, int.Parse(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString()), TieuThu, out ChiTietCu);
                int PhiBVMT = _cGiaNuoc.TinhPhiBMVT(int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, int.Parse(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString()), TieuThu);

                dgvTruyThuTienNuoc["GiaBan_Cu", e.RowIndex].Value = TongTienCu;
                dgvTruyThuTienNuoc["ThueGTGT_Cu", e.RowIndex].Value = Math.Round((double)TongTienCu * 5 / 100);
                if (PhiBVMT == 0)
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", e.RowIndex].Value = TongTienCu * 10 / 100;
                    dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + (TongTienCu * 10 / 100);
                }
                else
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", e.RowIndex].Value = PhiBVMT;
                    dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + PhiBVMT;
                }
                if (dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value != null)
                    if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) < int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                        dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Tăng";
                    else
                        if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) > int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Giảm";
                        else
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "";
            }

            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TieuThu_Cu")
            {
                dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value = dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value;

                int GiaBieu = 0;
                int DinhMuc = 0;
                if (dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString()))
                    GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString());
                if (dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString()))
                    DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString());

                string ChiTietCu = "";
                int TongTienCu = _cGiaNuoc.TinhTienNuoc(txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, int.Parse(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString()), out ChiTietCu);
                int PhiBVMT = _cGiaNuoc.TinhPhiBMVT(int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, int.Parse(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString()));

                dgvTruyThuTienNuoc["GiaBan_Cu", e.RowIndex].Value = TongTienCu;
                dgvTruyThuTienNuoc["ThueGTGT_Cu", e.RowIndex].Value = Math.Round((double)TongTienCu * 5 / 100);
                if (PhiBVMT == 0)
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", e.RowIndex].Value = TongTienCu * 10 / 100;
                    dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + (TongTienCu * 10 / 100);
                }
                else
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", e.RowIndex].Value = PhiBVMT;
                    dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + PhiBVMT;
                }
                if (dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value != null)
                    if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) < int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                        dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Tăng";
                    else
                        if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) > int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Giảm";
                        else
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "";
            }
            ////////////////////////////////////////////

            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "GiaBieu_Moi")
            {
                int DinhMuc = 0;
                int TieuThu = 0;
                if (dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString()))
                    DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString());
                if (dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString()))
                    TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString());

                string ChiTietMoi = "";
                int TongTienMoi = _cGiaNuoc.TinhTienNuoc( txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString()), DinhMuc, TieuThu, out ChiTietMoi);
                int PhiBVMT = _cGiaNuoc.TinhPhiBMVT(int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString()), DinhMuc, TieuThu);

                dgvTruyThuTienNuoc["GiaBan_Moi", e.RowIndex].Value = TongTienMoi;
                dgvTruyThuTienNuoc["ThueGTGT_Moi", e.RowIndex].Value = Math.Round((double)TongTienMoi * 5 / 100);
                if (PhiBVMT == 0)
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = TongTienMoi * 10 / 100;
                    dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + (TongTienMoi * 10 / 100);
                }
                else
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = PhiBVMT;
                    dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + PhiBVMT;
                }
                if (dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value != null)
                    if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) < int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                        dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Tăng";
                    else
                        if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) > int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Giảm";
                        else
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "";
            }

            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "DinhMuc_Moi")
            {
                int GiaBieu = 0;
                int TieuThu = 0;
                if (dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString()))
                    GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString());
                if (dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString()))
                    TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString());

                string ChiTietMoi = "";
                int TongTienMoi = _cGiaNuoc.TinhTienNuoc( txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, int.Parse(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString()), TieuThu, out ChiTietMoi);
                int PhiBVMT = _cGiaNuoc.TinhPhiBMVT(int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, int.Parse(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString()), TieuThu);

                dgvTruyThuTienNuoc["GiaBan_Moi", e.RowIndex].Value = TongTienMoi;
                dgvTruyThuTienNuoc["ThueGTGT_Moi", e.RowIndex].Value = Math.Round((double)TongTienMoi * 5 / 100);
                if (PhiBVMT == 0)
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = TongTienMoi * 10 / 100;
                    dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + (TongTienMoi * 10 / 100);
                }
                else
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = PhiBVMT;
                    dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + PhiBVMT;
                }
                if (dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value != null)
                    if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) < int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                        dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Tăng";
                    else
                        if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) > int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Giảm";
                        else
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "";
            }

            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TieuThu_Moi")
            {
                int GiaBieu = 0;
                int DinhMuc = 0;
                if (dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString()))
                    GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString());
                if (dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString()))
                    DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString());

                string ChiTietMoi = "";
                int TongTienMoi = _cGiaNuoc.TinhTienNuoc( txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, int.Parse(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString()), out ChiTietMoi);
                int PhiBVMT = _cGiaNuoc.TinhPhiBMVT(int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, int.Parse(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString()));

                dgvTruyThuTienNuoc["GiaBan_Moi", e.RowIndex].Value = TongTienMoi;
                dgvTruyThuTienNuoc["ThueGTGT_Moi", e.RowIndex].Value = Math.Round((double)TongTienMoi * 5 / 100);
                if (PhiBVMT == 0)
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = TongTienMoi * 10 / 100;
                    dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + (TongTienMoi * 10 / 100);
                }
                else
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = PhiBVMT;
                    dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + PhiBVMT;
                }
                if (dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value != null)
                    if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) < int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                        dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Tăng";
                    else
                        if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) > int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Giảm";
                        else
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "";
            }
        }

        private void dgvTruyThuTienNuoc_Leave(object sender, EventArgs e)
        {
            int Tongm3HoaDon = 0;
            int Tongm3ThucTe = 0;
            int GiaBan = 0;
            int ThueGTGT = 0;
            int PhiBVMT = 0;
            int TongCongCu = 0;
            int TongCongMoi = 0;
            foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                if (item.Cells["Ky"].Value != null)
                {
                    Tongm3HoaDon += int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                    Tongm3ThucTe += int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                    GiaBan += int.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                    ThueGTGT += int.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                    PhiBVMT += int.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                    TongCongMoi += int.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                    TongCongCu += int.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                }
            txtSoKy.Text = (dgvTruyThuTienNuoc.RowCount - 1).ToString();
            txtTongm3HoaDon.Text = Tongm3HoaDon.ToString();
            txtTongm3ThucTe.Text = Tongm3ThucTe.ToString();
            txtTongm3TruyThu.Text = (Tongm3ThucTe - Tongm3HoaDon).ToString();
            txtGiaBan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaBan);
            txtThueGTGT.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ThueGTGT);
            txtPhiBVMT.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", PhiBVMT);
            txtTongCongMoi.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongMoi);
            txtTongCongCu.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongCu);
            txtTongThanhToan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongMoi - TongCongCu);
        }

        private void dgvTruyThuTienNuoc_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < dgvTruyThuTienNuoc.RowCount - 1)
            {
                dgvTruyThuTienNuoc["Nam", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["Nam", e.RowIndex].Value;
                dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value;
                dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value;
                dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value;
                dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value;
            }
        }

        private void dgvTruyThuTienNuoc_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            //    {
            //        try
            //        {                
            //        if (dgvTruyThuTienNuoc.SelectedRows[0].Cells["ID_HoaDon"].Value != null)
            //        {
            //            TruyThuTienNuoc_HoaDon cttttn_hoadon = _cTTTN.get_HoaDon(int.Parse(dgvTruyThuTienNuoc.SelectedRows[0].Cells["ID_HoaDon"].Value.ToString()));
            //            _cTTTN.Xoa_HoaDon(cttttn_hoadon);
            //        }
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    else
            //        MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    TruyThuTienNuoc_ChiTiet cttttn = new TruyThuTienNuoc_ChiTiet();

                    if (_dontu_ChiTiet != null)
                    {
                        if (_cTTTN.checkExist(_dontu_ChiTiet.MaDon.Value) == false)
                        {
                            TruyThuTienNuoc tttn = new TruyThuTienNuoc();
                            tttn.MaDonMoi = _dontu_ChiTiet.MaDon.Value;
                            _cTTTN.Them(tttn);
                        }
                        if (_cTTTN.checkExist_ChiTiet(_dontu_ChiTiet.MaDon.Value, txtDanhBo.Text.Trim()) == true)
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Truy Thu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        cttttn.ID = _cTTTN.get(_dontu_ChiTiet.MaDon.Value).ID;
                        cttttn.STT = _dontu_ChiTiet.STT.Value;
                    }
                    else
                        if (_dontkh != null)
                        {
                            if (_cTTTN.checkExist("TKH", _dontkh.MaDon) == false)
                            {
                                TruyThuTienNuoc tttn = new TruyThuTienNuoc();
                                tttn.MaDon = _dontkh.MaDon;
                                _cTTTN.Them(tttn);
                            }
                            if (_cTTTN.checkExist_ChiTiet("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim()) == true)
                            {
                                MessageBox.Show("Danh Bộ này đã được Lập Truy Thu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            cttttn.ID = _cTTTN.get("TKH", _dontkh.MaDon).ID;
                        }
                        else
                            if (_dontxl != null)
                            {
                                if (_cTTTN.checkExist("TXL", _dontxl.MaDon) == false)
                                {
                                    TruyThuTienNuoc tttn = new TruyThuTienNuoc();
                                    tttn.MaDonTXL = _dontxl.MaDon;
                                    _cTTTN.Them(tttn);
                                }
                                if (_cTTTN.checkExist_ChiTiet("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim()) == true)
                                {
                                    MessageBox.Show("Danh Bộ này đã được Lập Truy Thu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                cttttn.ID = _cTTTN.get("TXL", _dontxl.MaDon).ID;
                            }
                            else
                                if (_dontbc != null)
                                {
                                    if (_cTTTN.checkExist("TBC", _dontbc.MaDon) == false)
                                    {
                                        TruyThuTienNuoc tttn = new TruyThuTienNuoc();
                                        tttn.MaDonTBC = _dontbc.MaDon;
                                        _cTTTN.Them(tttn);
                                    }
                                    if (_cTTTN.checkExist_ChiTiet("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim()) == true)
                                    {
                                        MessageBox.Show("Danh Bộ này đã được Lập Truy Thu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    cttttn.ID = _cTTTN.get("TBC", _dontbc.MaDon).ID;
                                }
                                else
                                {
                                    MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                    cttttn.DanhBo = txtDanhBo.Text.Trim();
                    cttttn.HopDong = txtHopDong.Text.Trim();
                    cttttn.LoTrinh = txtLoTrinh.Text.Trim();
                    cttttn.HoTen = txtHoTen.Text.Trim();
                    cttttn.DiaChi = txtDiaChi.Text.Trim();
                    if (!string.IsNullOrEmpty(txtGiaBieu.Text.Trim()))
                        cttttn.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                    if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                        cttttn.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                    cttttn.DienThoai = txtDienThoai.Text.Trim();
                    cttttn.NoiDung = txtNoiDung.Text.Trim();
                    if (cmbTinhTrang.SelectedIndex != -1)
                    {
                        cttttn.NgayTinhTrang = dateTinhTrang.Value;
                        cttttn.TinhTrang = cmbTinhTrang.SelectedItem.ToString();
                    }
                    else
                        cttttn.TinhTrang = "";
                    if (_hoadon != null)
                    {
                        cttttn.Dot = _hoadon.DOT.ToString();
                        cttttn.Ky = _hoadon.KY.ToString();
                        cttttn.Nam = _hoadon.NAM.ToString();
                        cttttn.Phuong = _hoadon.Phuong;
                        cttttn.Quan = _hoadon.Quan;
                    }

                    _cTTTN.Them_ChiTiet(cttttn);
                    int IDCT = cttttn.IDCT;

                    /////thêm chi tiết
                    //foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                    //    if (item.Cells["Ky"].Value != null)
                    //    {
                    //        if (_cTTTN.CheckExist_CT(IDCT, item.Cells["Ky"].Value.ToString(), item.Cells["Nam"].Value.ToString()))
                    //        {
                    //            MessageBox.Show("Kỳ " + item.Cells["Ky"].Value.ToString() + "/" + item.Cells["Nam"].Value.ToString() + " đã có \rVui lòng xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //            return;
                    //        }
                    //    }

                    foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                        if (item.Cells["Ky"].Value != null && item.Cells["Ky"].ToString() != "")
                            if (_cTTTN.CheckExist_HoaDon(IDCT, item.Cells["Ky"].Value.ToString(), item.Cells["Nam"].Value.ToString()) == false)
                            {
                                TruyThuTienNuoc_HoaDon cttttn_hoadon = new TruyThuTienNuoc_HoaDon();
                                cttttn_hoadon.IDCT = IDCT;
                                cttttn_hoadon.Ky = item.Cells["Ky"].Value.ToString();
                                cttttn_hoadon.Nam = item.Cells["Nam"].Value.ToString();
                                cttttn_hoadon.GiaBieuCu = int.Parse(item.Cells["GiaBieu_Cu"].Value.ToString());
                                cttttn_hoadon.DinhMucCu = int.Parse(item.Cells["DinhMuc_Cu"].Value.ToString());
                                cttttn_hoadon.TieuThuCu = int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                                cttttn_hoadon.GiaBanCu = int.Parse(item.Cells["GiaBan_Cu"].Value.ToString());
                                cttttn_hoadon.ThueGTGTCu = int.Parse(item.Cells["ThueGTGT_Cu"].Value.ToString());
                                cttttn_hoadon.PhiBVMTCu = int.Parse(item.Cells["PhiBVMT_Cu"].Value.ToString());
                                cttttn_hoadon.TongCongCu = int.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                                ///
                                cttttn_hoadon.GiaBieuMoi = int.Parse(item.Cells["GiaBieu_Moi"].Value.ToString());
                                cttttn_hoadon.DinhMucMoi = int.Parse(item.Cells["DinhMuc_Moi"].Value.ToString());
                                cttttn_hoadon.TieuThuMoi = int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                                cttttn_hoadon.GiaBanMoi = int.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                                cttttn_hoadon.ThueGTGTMoi = int.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                                cttttn_hoadon.PhiBVMTMoi = int.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                                cttttn_hoadon.TongCongMoi = int.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                                cttttn_hoadon.TangGiam = item.Cells["TangGiam"].Value.ToString();

                                _cTTTN.Them_HoaDon(cttttn_hoadon);
                                //cttttn_hoadon.CreateBy = CTaiKhoan.MaUser;
                                //cttttn_hoadon.CreateDate = DateTime.Now;
                                //cttttn_hoadon.TruyThuTienNuoc_HoaDons.Add(cttttn_hoadon);
                            }
                    _cTTTN.Refresh();

                    cttttn = _cTTTN.get_ChiTiet(cttttn.IDCT);
                    cttttn.TongTien = cttttn.TruyThuTienNuoc_HoaDons.Sum(item => item.TongCongMoi.Value) - cttttn.TruyThuTienNuoc_HoaDons.Sum(item => item.TongCongCu.Value);
                    cttttn.Tongm3BinhQuan = (int)Math.Round((double)cttttn.TongTien / cttttn.SoTien1m3);
                    _cTTTN.SubmitChanges();

                    if (_dontu_ChiTiet != null)
                        _cDonTu.Them_LichSu("TruyThu", "Đã Lập Truy Thu, "+cttttn.NoiDung, _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value);
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    txtMaDonCu.Focus();
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
                    if (_cttttn != null)
                    {
                        //_cttttn.XepDon = chkXepDon.Checked;
                        if (cmbTinhTrang.SelectedIndex != -1)
                        {
                            _cttttn.NgayTinhTrang = dateTinhTrang.Value;
                            _cttttn.TinhTrang = cmbTinhTrang.SelectedItem.ToString();
                        }
                        else
                            _cttttn.TinhTrang = "";
                        _cttttn.DanhBo = txtDanhBo.Text.Trim();
                        _cttttn.HopDong = txtHopDong.Text.Trim();
                        _cttttn.LoTrinh = txtLoTrinh.Text.Trim();
                        _cttttn.HoTen = txtHoTen.Text.Trim();
                        _cttttn.DiaChi = txtDiaChi.Text.Trim();
                        if (!string.IsNullOrEmpty(txtGiaBieu.Text.Trim()))
                            _cttttn.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                            _cttttn.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        _cttttn.NoiDung = txtNoiDung.Text.Trim();
                        _cttttn.DienThoai = txtDienThoai.Text.Trim();
                        if (cmbTinhTrang.SelectedIndex != -1)
                        {
                            _cttttn.NgayTinhTrang = dateTinhTrang.Value;
                            _cttttn.TinhTrang = cmbTinhTrang.SelectedItem.ToString();
                        }
                        else
                            _cttttn.TinhTrang = "";
                        if (_hoadon != null && _hoadon.DANHBA != txtDanhBo.Text.Trim())
                        {
                            _cttttn.Dot = _hoadon.DOT.ToString();
                            _cttttn.Ky = _hoadon.KY.ToString();
                            _cttttn.Nam = _hoadon.NAM.ToString();
                            _cttttn.Phuong = _hoadon.Phuong;
                            _cttttn.Quan = _hoadon.Quan;
                        }

                        foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                            if (item.Cells["Ky"].Value != null && item.Cells["Ky"].ToString() != "")
                                if (_cTTTN.CheckExist_HoaDon(_cttttn.IDCT, item.Cells["Ky"].Value.ToString(), item.Cells["Nam"].Value.ToString()) == false)
                                //if (item.Cells["IDCT"].Value == null || item.Cells["IDCT"].Value.ToString()=="")
                                {
                                    TruyThuTienNuoc_HoaDon cttttn_hoadon = new TruyThuTienNuoc_HoaDon();

                                    cttttn_hoadon.IDCT = _cttttn.IDCT;
                                    cttttn_hoadon.Ky = item.Cells["Ky"].Value.ToString();
                                    cttttn_hoadon.Nam = item.Cells["Nam"].Value.ToString();
                                    cttttn_hoadon.GiaBieuCu = int.Parse(item.Cells["GiaBieu_Cu"].Value.ToString());
                                    cttttn_hoadon.DinhMucCu = int.Parse(item.Cells["DinhMuc_Cu"].Value.ToString());
                                    cttttn_hoadon.TieuThuCu = int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                                    cttttn_hoadon.GiaBanCu = int.Parse(item.Cells["GiaBan_Cu"].Value.ToString());
                                    cttttn_hoadon.ThueGTGTCu = int.Parse(item.Cells["ThueGTGT_Cu"].Value.ToString());
                                    cttttn_hoadon.PhiBVMTCu = int.Parse(item.Cells["PhiBVMT_Cu"].Value.ToString());
                                    cttttn_hoadon.TongCongCu = int.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                                    ///
                                    cttttn_hoadon.GiaBieuMoi = int.Parse(item.Cells["GiaBieu_Moi"].Value.ToString());
                                    cttttn_hoadon.DinhMucMoi = int.Parse(item.Cells["DinhMuc_Moi"].Value.ToString());
                                    cttttn_hoadon.TieuThuMoi = int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                                    cttttn_hoadon.GiaBanMoi = int.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                                    cttttn_hoadon.ThueGTGTMoi = int.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                                    cttttn_hoadon.PhiBVMTMoi = int.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                                    cttttn_hoadon.TongCongMoi = int.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                                    cttttn_hoadon.TangGiam = item.Cells["TangGiam"].Value.ToString();

                                    _cTTTN.Them_HoaDon(cttttn_hoadon);
                                    //cttttn_hoadon.CreateBy = CTaiKhoan.MaUser;
                                    //cttttn_hoadon.CreateDate = DateTime.Now;
                                    //_cttttn.TruyThuTienNuoc_HoaDons.Add(cttttn_hoadon);
                                }
                                else
                                {
                                    TruyThuTienNuoc_HoaDon cttttn_hoadon = _cTTTN.get_HoaDon(_cttttn.IDCT, item.Cells["Ky"].Value.ToString(), item.Cells["Nam"].Value.ToString());
                                    //TruyThuTienNuoc_HoaDon cttttn_hoadon = _cTTTN.GetCT(int.Parse(item.Cells["IDCT"].Value.ToString()));

                                    cttttn_hoadon.Ky = item.Cells["Ky"].Value.ToString();
                                    cttttn_hoadon.Nam = item.Cells["Nam"].Value.ToString();
                                    cttttn_hoadon.GiaBieuCu = int.Parse(item.Cells["GiaBieu_Cu"].Value.ToString());
                                    cttttn_hoadon.DinhMucCu = int.Parse(item.Cells["DinhMuc_Cu"].Value.ToString());
                                    cttttn_hoadon.TieuThuCu = int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                                    cttttn_hoadon.GiaBanCu = int.Parse(item.Cells["GiaBan_Cu"].Value.ToString());
                                    cttttn_hoadon.ThueGTGTCu = int.Parse(item.Cells["ThueGTGT_Cu"].Value.ToString());
                                    cttttn_hoadon.PhiBVMTCu = int.Parse(item.Cells["PhiBVMT_Cu"].Value.ToString());
                                    cttttn_hoadon.TongCongCu = int.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                                    ///
                                    cttttn_hoadon.GiaBieuMoi = int.Parse(item.Cells["GiaBieu_Moi"].Value.ToString());
                                    cttttn_hoadon.DinhMucMoi = int.Parse(item.Cells["DinhMuc_Moi"].Value.ToString());
                                    cttttn_hoadon.TieuThuMoi = int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                                    cttttn_hoadon.GiaBanMoi = int.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                                    cttttn_hoadon.ThueGTGTMoi = int.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                                    cttttn_hoadon.PhiBVMTMoi = int.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                                    cttttn_hoadon.TongCongMoi = int.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                                    cttttn_hoadon.TangGiam = item.Cells["TangGiam"].Value.ToString();

                                    _cTTTN.Sua_HoaDon(cttttn_hoadon);
                                }
                        _cTTTN.SubmitChanges();
                        _cTTTN.Refresh();

                        _cttttn = _cTTTN.get_ChiTiet(_cttttn.IDCT);
                        _cttttn.TongTien = _cttttn.TruyThuTienNuoc_HoaDons.Sum(item => item.TongCongMoi.Value) - _cttttn.TruyThuTienNuoc_HoaDons.Sum(item => item.TongCongCu.Value);
                        _cttttn.Tongm3BinhQuan = (int)Math.Round((double)_cttttn.TongTien / _cttttn.SoTien1m3);
                        _cTTTN.SubmitChanges();

                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (_cttttn != null && MessageBox.Show("Bạn có chắc chắn xóa Toàn Bộ Truy Thu?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_cTTTN.Xoa_ChiTiet(_cttttn))
                        {
                            _cTTTN.Refresh();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                if (item.Cells["Ky"].Value != null)
                {
                    DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                    dr["MaDon"] = txtMaDonCu.Text.Trim();
                    dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = txtHoTen.Text.Trim();
                    dr["DiaChi"] = txtDiaChi.Text.Trim();
                    dr["HopDong"] = txtHopDong.Text.Trim();
                    dr["GiaBieu"] = txtGiaBieu.Text.Trim();
                    dr["DinhMuc"] = txtDinhMuc.Text.Trim();

                    dr["Ky"] = item.Cells["Ky"].Value.ToString();
                    dr["Nam"] = item.Cells["Nam"].Value.ToString();
                    dr["GiaBieuCu"] = item.Cells["GiaBieu_Cu"].Value.ToString();
                    dr["DinhMucCu"] = item.Cells["DinhMuc_Cu"].Value.ToString();
                    dr["TieuThuCu"] = item.Cells["TieuThu_Cu"].Value.ToString();
                    dr["GiaBanCu"] = item.Cells["GiaBan_Cu"].Value.ToString();
                    dr["ThueGTGTCu"] = item.Cells["ThueGTGT_Cu"].Value.ToString();
                    dr["PhiBVMTCu"] = item.Cells["PhiBVMT_Cu"].Value.ToString();
                    dr["TongCongCu"] = item.Cells["TongCong_Cu"].Value.ToString();
                    dr["GiaBieuMoi"] = item.Cells["GiaBieu_Moi"].Value.ToString();
                    dr["DinhMucMoi"] = item.Cells["DinhMuc_Moi"].Value.ToString();
                    dr["TieuThuMoi"] = item.Cells["TieuThu_Moi"].Value.ToString();
                    dr["GiaBanMoi"] = item.Cells["GiaBan_Moi"].Value.ToString();
                    dr["ThueGTGTMoi"] = item.Cells["ThueGTGT_Moi"].Value.ToString();
                    dr["PhiBVMTMoi"] = item.Cells["PhiBVMT_Moi"].Value.ToString();
                    dr["TongCongMoi"] = item.Cells["TongCong_Moi"].Value.ToString();
                    dr["TangGiam"] = item.Cells["TangGiam"].Value.ToString();
                    dr["NhanVien"] = CTaiKhoan.HoTen;
                    TruyThuTienNuoc_ChiTiet cttttn = new TruyThuTienNuoc_ChiTiet();
                    if (_dontu_ChiTiet != null)
                        cttttn = _cTTTN.get_ChiTiet(_dontu_ChiTiet.MaDon.Value);
                    else
                        if (_dontkh != null)
                            cttttn = _cTTTN.get_ChiTiet("TKH", _dontkh.MaDon);
                        else
                            if (_dontxl != null)
                                cttttn = _cTTTN.get_ChiTiet("TXL", _dontxl.MaDon);
                            else
                                if (_dontbc != null)
                                    cttttn = _cTTTN.get_ChiTiet("TBC", _dontbc.MaDon);
                    if (cttttn != null)
                        dr["SoTien1m3"] = cttttn.SoTien1m3;

                    dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
                }

            rptTruyThuTienNuoc rpt = new rptTruyThuTienNuoc();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnInChiTiet_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                if (item.Cells["Ky"].Value != null)
                {
                    DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                    if(txtMaDonMoi.Text.Trim()!="")
                        dr["MaDon"] = txtMaDonMoi.Text.Trim();
                    else
                    dr["MaDon"] = txtMaDonCu.Text.Trim();
                    dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = txtHoTen.Text.Trim();
                    dr["DiaChi"] = txtDiaChi.Text.Trim();
                    dr["HopDong"] = txtHopDong.Text.Trim();
                    dr["GiaBieu"] = txtGiaBieu.Text.Trim();
                    dr["DinhMuc"] = txtDinhMuc.Text.Trim();

                    dr["Ky"] = item.Cells["Ky"].Value.ToString();
                    dr["Nam"] = item.Cells["Nam"].Value.ToString();
                    dr["GiaBieuCu"] = item.Cells["GiaBieu_Cu"].Value.ToString();
                    if (item.Cells["DinhMuc_Cu"].Value != null)
                        dr["DinhMucCu"] = item.Cells["DinhMuc_Cu"].Value.ToString();
                    dr["TieuThuCu"] = item.Cells["TieuThu_Cu"].Value.ToString();
                    dr["GiaBanCu"] = item.Cells["GiaBan_Cu"].Value.ToString();
                    dr["ThueGTGTCu"] = item.Cells["ThueGTGT_Cu"].Value.ToString();
                    dr["PhiBVMTCu"] = item.Cells["PhiBVMT_Cu"].Value.ToString();
                    dr["TongCongCu"] = item.Cells["TongCong_Cu"].Value.ToString();
                    dr["GiaBieuMoi"] = item.Cells["GiaBieu_Moi"].Value.ToString();
                    if (item.Cells["DinhMuc_Moi"].Value != null)
                        dr["DinhMucMoi"] = item.Cells["DinhMuc_Moi"].Value.ToString();
                    dr["TieuThuMoi"] = item.Cells["TieuThu_Moi"].Value.ToString();
                    dr["GiaBanMoi"] = item.Cells["GiaBan_Moi"].Value.ToString();
                    dr["ThueGTGTMoi"] = item.Cells["ThueGTGT_Moi"].Value.ToString();
                    dr["PhiBVMTMoi"] = item.Cells["PhiBVMT_Moi"].Value.ToString();
                    dr["TongCongMoi"] = item.Cells["TongCong_Moi"].Value.ToString();
                    if (item.Cells["TangGiam"].Value != null)
                        dr["TangGiam"] = item.Cells["TangGiam"].Value.ToString();
                    dr["NhanVien"] = CTaiKhoan.HoTen;
                    dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
                }

            rptTruyThuTienNuocChiTiet rpt = new rptTruyThuTienNuocChiTiet();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnThemThanhToan_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (_cttttn != null)
                    {
                        TruyThuTienNuoc_ThanhToan entity = new TruyThuTienNuoc_ThanhToan();

                        entity.IDCT = _cttttn.IDCT;
                        entity.NgayDong = dateDongTien.Value;
                        entity.SoTien = int.Parse(txtSoTien.Text.Trim());

                        if (_cTTTN.Them_ThanhToan(entity))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearThanhToan();
                            LoadDSThanhToan(_cttttn.IDCT);
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

        private void btnSuaThanhToan_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (_cttttn != null)
                    {
                        TruyThuTienNuoc_ThanhToan entity = _cTTTN.get_ThanhToan(int.Parse(dgvThanhToanTruyThuTienNuoc.SelectedRows[0].Cells["MaTTTTTN"].Value.ToString()));

                        entity.NgayDong = dateDongTien.Value;
                        entity.SoTien = int.Parse(txtSoTien.Text.Trim());

                        if (_cTTTN.Sua_ThanhToan(entity))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearThanhToan();
                            LoadDSThanhToan(_cttttn.IDCT);
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

        private void btnXoaThanhToan_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (_cttttn != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        TruyThuTienNuoc_ThanhToan entity = _cTTTN.get_ThanhToan(int.Parse(dgvThanhToanTruyThuTienNuoc.SelectedRows[0].Cells["MaTTTTTN"].Value.ToString()));

                        if (_cTTTN.Xoa_ThanhToan(entity))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearThanhToan();
                            LoadDSThanhToan(_cttttn.IDCT);
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

        private void dgvThanhToanTruyThuTienNuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvThanhToanTruyThuTienNuoc.Rows[e.RowIndex].Selected = true;
                dateDongTien.Value = DateTime.Parse(dgvThanhToanTruyThuTienNuoc.SelectedRows[0].Cells["NgayDong"].Value.ToString());
                txtSoTien.Text = dgvThanhToanTruyThuTienNuoc.SelectedRows[0].Cells["SoTien"].Value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvThanhToanTruyThuTienNuoc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvThanhToanTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "DaThanhToan")
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    try
                    {
                        if (_cttttn != null)
                        {
                            TruyThuTienNuoc_ThanhToan entity = _cTTTN.get_ThanhToan(int.Parse(dgvThanhToanTruyThuTienNuoc.SelectedRows[0].Cells["MaTTTTTN"].Value.ToString()));

                            entity.DaThanhToan = bool.Parse(dgvThanhToanTruyThuTienNuoc.SelectedRows[0].Cells["DaThanhToan"].Value.ToString());

                            if (_cTTTN.Sua_ThanhToan(entity))
                            {
                                ClearThanhToan();
                                LoadDSThanhToan(_cttttn.IDCT);
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
        }

        private void dgvThanhToanTruyThuTienNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvThanhToanTruyThuTienNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvThanhToanTruyThuTienNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvThanhToanTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void btnThemThuMoi_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (_cttttn != null)
                    {
                        TruyThuTienNuoc_ThuMoi entity = new TruyThuTienNuoc_ThuMoi();

                        entity.IDCT = _cttttn.IDCT;
                        entity.VaoLuc = txtVaoLuc.Text.Trim();
                        entity.VeViec = txtVeViec.Text.Trim();

                        if (_cTTTN.Them_ThuMoi(entity))
                        {
                            _cttttn.NgayTinhTrang = DateTime.Now;
                            _cttttn.TinhTrang = "Đang gửi thư mời";
                            _cTTTN.SubmitChanges();
                            if (_dontu_ChiTiet != null)
                                _cDonTu.Them_LichSu("Truy Thu", "Đã Gửi Thư Mời", _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value);
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearThuMoi();
                            LoadDSThuMoi(_cttttn.IDCT);
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

        private void btnSuaThuMoi_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (_cttttn != null)
                    {
                        TruyThuTienNuoc_ThuMoi entity = _cTTTN.get_ThuMoi(int.Parse(dgvThuMoi.SelectedRows[0].Cells["ID"].Value.ToString()));

                        entity.VaoLuc = txtVaoLuc.Text.Trim();
                        entity.VeViec = txtVeViec.Text.Trim();

                        if (_cTTTN.Sua_ThuMoi(entity))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearThuMoi();
                            LoadDSThuMoi(_cttttn.IDCT);
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

        private void btnXoaThuMoi_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (_cttttn != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        TruyThuTienNuoc_ThuMoi entity = _cTTTN.get_ThuMoi(int.Parse(dgvThuMoi.SelectedRows[0].Cells["ID"].Value.ToString()));

                        if (_cTTTN.Xoa_ThuMoi(entity))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearThuMoi();
                            LoadDSThuMoi(_cttttn.IDCT);
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

        private void btnInThuMoi_Click(object sender, EventArgs e)
        {
            if (_cttttn != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                dr["MaDon"] = txtMaDonCu.Text.Trim();
                dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = txtHoTen.Text.Trim();
                dr["DiaChi"] = txtDiaChi.Text.Trim();
                dr["VaoLuc"] = dgvThuMoi.SelectedRows[0].Cells["VaoLuc"].Value;
                dr["VeViec"] = dgvThuMoi.SelectedRows[0].Cells["VeViec"].Value;
                dr["Lan"] = dgvThuMoi.SelectedRows[0].Cells["Lan"].Value;

                dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);

                rptThuMoiTruyThu rpt = new rptThuMoiTruyThu();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();

                //DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                //DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                //if (_cttttn.TruyThuTienNuoc.MaDonMoi != null)
                //    dr["SoPhieu"] = _cttttn.TruyThuTienNuoc.MaDonMoi.ToString();
                //else
                //    if (_cttttn.TruyThuTienNuoc.MaDon != null)
                //        dr["SoPhieu"] = _cttttn.TruyThuTienNuoc.MaDon.ToString().Insert(_cttttn.TruyThuTienNuoc.MaDon.ToString().Length - 2, "-");
                //    else
                //        if (_cttttn.TruyThuTienNuoc.MaDonTXL != null)
                //            dr["SoPhieu"] = _cttttn.TruyThuTienNuoc.MaDonTXL.ToString().Insert(_cttttn.TruyThuTienNuoc.MaDonTXL.ToString().Length - 2, "-");
                //        else
                //            if (_cttttn.TruyThuTienNuoc.MaDonTBC != null)
                //                dr["SoPhieu"] = _cttttn.TruyThuTienNuoc.MaDonTBC.ToString().Insert(_cttttn.TruyThuTienNuoc.MaDonTBC.ToString().Length - 2, "-");

                //dr["HoTen"] = _cttttn.HoTen;
                //dr["DiaChi"] = _cttttn.DiaChi;
                //if (!string.IsNullOrEmpty(_cttttn.DanhBo) && _cttttn.DanhBo.Length == 11)
                //    dr["DanhBo"] = _cttttn.DanhBo.Insert(7, " ").Insert(4, " ");
                //dr["GiaBieu"] = _cttttn.GiaBieu.Value.ToString();
                //dr["DinhMuc"] = _cttttn.DinhMuc.Value.ToString();
                //dr["VaoLuc"] = dgvThuMoi.SelectedRows[0].Cells["VaoLuc"].Value;
                //dr["VeViec"] = dgvThuMoi.SelectedRows[0].Cells["VeViec"].Value;
                //dr["Lan"] = dgvThuMoi.SelectedRows[0].Cells["Lan"].Value;

                //dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                //rptThuMoiChuyenDe rpt = new rptThuMoiChuyenDe();
                //rpt.SetDataSource(dsBaoCao);
                //frmShowBaoCao frm = new frmShowBaoCao(rpt);
                //frm.Show();
            }
        }

        private void dgvThuMoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvThuMoi.Rows[e.RowIndex].Selected = true;
                txtVaoLuc.Text = dgvThuMoi.SelectedRows[0].Cells["VaoLuc"].Value.ToString();
                txtVeViec.Text = dgvThuMoi.SelectedRows[0].Cells["VeViec"].Value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvTruyThuTienNuoc_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                if (_cttttn != null)
                {
                    try
                    {
                        TruyThuTienNuoc_HoaDon cttttn_hoadon = _cTTTN.get_HoaDon(_cttttn.IDCT, e.Row.Cells["Ky"].Value.ToString(), e.Row.Cells["Nam"].Value.ToString());
                        if (_cTTTN.Xoa_HoaDon(cttttn_hoadon))
                        {
                            _cttttn = _cTTTN.get_ChiTiet(_cttttn.IDCT);
                            _cttttn.TongTien = _cttttn.TruyThuTienNuoc_HoaDons.Sum(item => item.TongCongMoi.Value) - _cttttn.TruyThuTienNuoc_HoaDons.Sum(item => item.TongCongCu.Value);
                            _cttttn.Tongm3BinhQuan = (int)Math.Round((double)_cttttn.TongTien / _cttttn.SoTien1m3);
                            _cTTTN.SubmitChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInBia_Click(object sender, EventArgs e)
        {
            if (_cttttn != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();
                if (_cttttn.TruyThuTienNuoc.MaDonMoi != null)
                {
                    if (_cttttn.TruyThuTienNuoc.DonTu.DonTu_ChiTiets.Count == 1)
                        dr["MaDon"] = _cttttn.TruyThuTienNuoc.MaDonMoi.Value.ToString();
                    else
                        dr["MaDon"] = _cttttn.TruyThuTienNuoc.MaDonMoi.Value.ToString() + "." + _cttttn.STT.Value.ToString();
                }
                else
                    if (_cttttn.TruyThuTienNuoc.MaDon != null)
                        dr["MaDon"] = "TKH" + _cttttn.TruyThuTienNuoc.MaDon.Value.ToString().Insert(_cttttn.TruyThuTienNuoc.MaDon.Value.ToString().Length - 2, "-");
                    else
                        if (_cttttn.TruyThuTienNuoc.MaDonTXL != null)
                            dr["MaDon"] = "TXL" + _cttttn.TruyThuTienNuoc.MaDonTXL.Value.ToString().Insert(_cttttn.TruyThuTienNuoc.MaDonTXL.Value.ToString().Length - 2, "-");
                        else
                            if (_cttttn.TruyThuTienNuoc.MaDonTBC != null)
                                dr["MaDon"] = "TBC" + _cttttn.TruyThuTienNuoc.MaDonTBC.Value.ToString().Insert(_cttttn.TruyThuTienNuoc.MaDonTBC.Value.ToString().Length - 2, "-");
                dr["ID"] = _cttttn.IDCT.ToString().Insert(_cttttn.IDCT.ToString().Length - 2, "-");
                dr["DanhBo"] = _cttttn.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["DiaChi"] = _cttttn.DiaChi;
                dr["HopDong"] = _cttttn.DienThoai;
                dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
                rptTruyThuTienNuoc_Bia rpt = new rptTruyThuTienNuoc_Bia();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }
        }

        private void frmTruyThuTienNuoc_KeyUp(object sender, KeyEventArgs e)
        {
            if (_dontu_ChiTiet != null && e.Control && e.KeyCode == Keys.T)
            {
                frmCapNhatDonTu_Thumbnail frm = new frmCapNhatDonTu_Thumbnail(_dontu_ChiTiet);
                frm.ShowDialog();
            }
        }

    }
}

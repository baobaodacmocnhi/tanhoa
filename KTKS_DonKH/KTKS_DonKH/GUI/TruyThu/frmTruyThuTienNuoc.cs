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
using System.Transactions;
using KTKS_DonKH.wrThuongVu;

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
        CDHN _cDHN = new CDHN();
        CDocSo _cDocSo = new CDocSo();
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();
        CTruyThuTienNuoc _cTTTN = new CTruyThuTienNuoc();
        wsThuongVu _wsThuongVu = new wsThuongVu();

        DonTu_ChiTiet _dontu_ChiTiet = null;
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        TruyThuTienNuoc_ChiTiet _cttttn = null;
        int _IDCT = -1;
        bool _flagLoad = false;
        //long _GiaBanCu = 0, _GiaBanMoi = 0;

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
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDHN.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
            txtGiaBieu.Text = hoadon.GB.ToString();
            if (hoadon.DM != null)
                txtDinhMuc.Text = hoadon.DM.ToString();
            if (hoadon.DinhMucHN != null)
                txtDinhMucHN.Text = hoadon.DinhMucHN.Value.ToString();
            //if (MessageBox.Show("Bạn có muốn chạy tự động nhập Kỳ", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //{
            //    DataTable dt = _cThuTien.getDSAll(hoadon.DANHBA);
            //    foreach (DataRow item in dt.Rows)
            //    {
            //        var index = dgvTruyThuTienNuoc.Rows.Add();
            //        dgvTruyThuTienNuoc.Rows[index].Cells["Nam"].Value = item["Nam"];
            //        dgvTruyThuTienNuoc.Rows[index].Cells["Ky"].Value = item["Ky"];
            //    }
            //}
            if (_cDHN.CheckExist(hoadon.DANHBA) == false)
                MessageBox.Show("Danh Bộ Hủy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void LoadTTTN(TruyThuTienNuoc_ChiTiet cttttn)
        {
            try
            {
                _flagLoad = true;
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
                txtSoTien1m3.Text = cttttn.SoTien1m3.ToString();
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
                if (cttttn.DinhMucHN != null)
                    txtDinhMucHN.Text = cttttn.DinhMucHN.Value.ToString();
                txtHoTen.Text = cttttn.HoTen;
                txtDiaChi.Text = cttttn.DiaChi;
                txtDienThoai.Text = cttttn.DienThoai;
                txtNoiDung.Text = cttttn.NoiDung;

                foreach (TruyThuTienNuoc_HoaDon item in cttttn.TruyThuTienNuoc_HoaDons.OrderBy(itemA => itemA.Nam).ThenBy(itemA => itemA.Ky).ToList())
                {
                    dgvTruyThuTienNuoc.Rows.Insert(dgvTruyThuTienNuoc.RowCount - 1, 1);

                    dgvTruyThuTienNuoc["ID_HoaDon", dgvTruyThuTienNuoc.RowCount - 2].Value = item.ID;
                    dgvTruyThuTienNuoc["Ky", dgvTruyThuTienNuoc.RowCount - 2].Value = item.Ky;
                    dgvTruyThuTienNuoc["Nam", dgvTruyThuTienNuoc.RowCount - 2].Value = item.Nam;
                    dgvTruyThuTienNuoc["TuNgay", dgvTruyThuTienNuoc.RowCount - 2].Value = item.TuNgay;
                    dgvTruyThuTienNuoc["DenNgay", dgvTruyThuTienNuoc.RowCount - 2].Value = item.DenNgay;
                    dgvTruyThuTienNuoc["GiaBieu_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.GiaBieuCu;
                    dgvTruyThuTienNuoc["DinhMucHN_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.DinhMucHNCu;
                    dgvTruyThuTienNuoc["DinhMuc_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.DinhMucCu;
                    dgvTruyThuTienNuoc["TieuThu_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.TieuThuCu;
                    dgvTruyThuTienNuoc["GiaBan_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.GiaBanCu;
                    dgvTruyThuTienNuoc["ThueGTGT_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.ThueGTGTCu;
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.PhiBVMTCu;
                    if (item.PhiBVMT_ThueCu != null)
                        dgvTruyThuTienNuoc["PhiBVMT_Thue_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.PhiBVMT_ThueCu;
                    dgvTruyThuTienNuoc["TongCong_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.TongCongCu;
                    dgvTruyThuTienNuoc["GiaBieu_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.GiaBieuMoi;
                    dgvTruyThuTienNuoc["DinhMucHN_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.DinhMucHNMoi;
                    dgvTruyThuTienNuoc["DinhMuc_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.DinhMucMoi;
                    dgvTruyThuTienNuoc["TieuThu_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.TieuThuMoi;
                    dgvTruyThuTienNuoc["GiaBan_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.GiaBanMoi;
                    dgvTruyThuTienNuoc["ThueGTGT_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.ThueGTGTMoi;
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.PhiBVMTMoi;
                    if (item.PhiBVMT_ThueMoi != null)
                        dgvTruyThuTienNuoc["PhiBVMT_Thue_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.PhiBVMT_ThueMoi;
                    dgvTruyThuTienNuoc["TongCong_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.TongCongMoi;
                    dgvTruyThuTienNuoc["TangGiam", dgvTruyThuTienNuoc.RowCount - 2].Value = item.TangGiam;
                    dgvTruyThuTienNuoc["SoTien1m3", dgvTruyThuTienNuoc.RowCount - 2].Value = item.SoTien1m3;
                    dgvTruyThuTienNuoc["m3BinhQuan", dgvTruyThuTienNuoc.RowCount - 2].Value = item.m3BinhQuan;
                }

                LoadDSThanhToan(cttttn.IDCT);
                LoadDSThuMoi(cttttn.IDCT);

                int Tongm3HoaDon = 0;
                int Tongm3ThucTe = 0;
                long GiaBan = 0;
                long ThueGTGT = 0;
                long PhiBVMT = 0;
                long PhiBVMT_Thue = 0;
                long TongCongCu = 0;
                long TongCongMoi = 0;
                foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                    if (item.Cells["Ky"].Value != null)
                    {
                        Tongm3HoaDon += int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                        Tongm3ThucTe += int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                        GiaBan += long.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                        ThueGTGT += long.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                        PhiBVMT += long.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                        if (item.Cells["PhiBVMT_Thue_Moi"].Value != null && item.Cells["PhiBVMT_Thue_Moi"].Value.ToString() != "")
                            PhiBVMT_Thue += long.Parse(item.Cells["PhiBVMT_Thue_Moi"].Value.ToString());
                        TongCongMoi += long.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                        TongCongCu += long.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                    }
                txtSoKy.Text = (dgvTruyThuTienNuoc.RowCount - 1).ToString();
                txtTongm3HoaDon.Text = Tongm3HoaDon.ToString();
                txtTongm3ThucTe.Text = Tongm3ThucTe.ToString();
                txtTongm3TruyThu.Text = (Tongm3ThucTe - Tongm3HoaDon).ToString();
                txtGiaBan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaBan);
                txtThueGTGT.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ThueGTGT);
                txtPhiBVMT.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", PhiBVMT);
                txtPhiBVMT_Thue.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", PhiBVMT_Thue);
                txtTongCongMoi.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongMoi);
                txtTongCongCu.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongCu);
                txtTongThanhToan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongMoi - TongCongCu);
                _flagLoad = false;

                dgvHinh.Rows.Clear();
                foreach (TruyThuTienNuoc_ChiTiet_Hinh item in cttttn.TruyThuTienNuoc_ChiTiet_Hinhs.ToList())
                {
                    var index = dgvHinh.Rows.Add();
                    dgvHinh.Rows[index].Cells["ID_Hinh"].Value = item.ID;
                    dgvHinh.Rows[index].Cells["Name_Hinh"].Value = item.Name;
                    if (item.Hinh != null)
                        dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(item.Hinh.ToArray());
                    dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = item.Loai;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Clear()
        {
            txtMaDonCu.Text = "";
            txtMaCTTTTN.Text = "";
            txtSoTien1m3.Text = "";
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtLoTrinh.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMucHN.Text = "";
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

            dgvHinh.Rows.Clear();

            txtMaDonMoi.Focus();
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
                string IDCT = txtMaCTTTTN.Text.Trim().Replace("-", "");
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
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "PhiBVMT_Thue_Moi" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TongCong_Moi" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTruyThuTienNuoc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_flagLoad == false)
            {
                int GiaBieu = 0, DinhMucHN = 0, DinhMuc = 0, TieuThu = 0;
                DateTime TuNgay = DateTime.Now, DenNgay = DateTime.Now;

                if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "Ky" && dgvTruyThuTienNuoc["Nam", e.RowIndex].Value != null && dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString() != "" && int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()) >= 2011)
                {
                    HOADON hd = _cThuTien.Get(txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Ky", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()));

                    if (hd != null)
                    {
                        if (hd.TUNGAY != null)
                            TuNgay = hd.TUNGAY.Value;
                        if (hd.DENNGAY != null)
                            DenNgay = hd.DENNGAY.Value;
                        if (hd.DinhMucHN != null)
                            dgvTruyThuTienNuoc["DinhMucHN_Cu", e.RowIndex].Value = hd.DinhMucHN.Value;
                        else
                            dgvTruyThuTienNuoc["DinhMucHN_Cu", e.RowIndex].Value = 0;
                        if (hd.DM != null)
                            dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value = hd.DM.Value;
                        if (hd.TIEUTHU != null)
                            dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value = hd.TIEUTHU.Value;
                        //if (hd.GB != null)
                        dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value = hd.GB;
                        dgvTruyThuTienNuoc["TuNgay", e.RowIndex].Value = TuNgay.ToString("dd/MM/yyyy");
                        dgvTruyThuTienNuoc["DenNgay", e.RowIndex].Value = DenNgay.ToString("dd/MM/yyyy");
                    }
                }
                else
                    if (e.RowIndex >= 0)
                    {
                        if (dgvTruyThuTienNuoc["TuNgay", e.RowIndex].Value == null)
                            dgvTruyThuTienNuoc["TuNgay", e.RowIndex].Value = TuNgay.ToString("dd/MM/yyyy");
                        if (dgvTruyThuTienNuoc["DenNgay", e.RowIndex].Value == null)
                            dgvTruyThuTienNuoc["DenNgay", e.RowIndex].Value = DenNgay.ToString("dd/MM/yyyy");
                    }

                if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "GiaBieu_Cu")
                {
                    dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value = dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value;

                    if (dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString()))
                        GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["DinhMucHN_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMucHN_Cu", e.RowIndex].Value.ToString()))
                        DinhMucHN = int.Parse(dgvTruyThuTienNuoc["DinhMucHN_Cu", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString()))
                        DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString()))
                        TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString());

                    if (dgvTruyThuTienNuoc["Ky", e.RowIndex].Value != null)
                    {
                        tinhTienNuocTruoc(e.RowIndex, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Ky", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, DinhMucHN, TieuThu, DateTime.Parse(dgvTruyThuTienNuoc["TuNgay", e.RowIndex].Value.ToString()), DateTime.Parse(dgvTruyThuTienNuoc["DenNgay", e.RowIndex].Value.ToString()));
                    }
                }

                if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "DinhMucHN_Cu")
                {
                    dgvTruyThuTienNuoc["DinhMucHN_Moi", e.RowIndex].Value = dgvTruyThuTienNuoc["DinhMucHN_Cu", e.RowIndex].Value;

                    if (dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString()))
                        GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["DinhMucHN_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMucHN_Cu", e.RowIndex].Value.ToString()))
                        DinhMucHN = int.Parse(dgvTruyThuTienNuoc["DinhMucHN_Cu", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString()))
                        DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString()))
                        TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString());

                    if (dgvTruyThuTienNuoc["Ky", e.RowIndex].Value != null)
                    {
                        tinhTienNuocTruoc(e.RowIndex, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Ky", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, DinhMucHN, TieuThu, DateTime.Parse(dgvTruyThuTienNuoc["TuNgay", e.RowIndex].Value.ToString()), DateTime.Parse(dgvTruyThuTienNuoc["DenNgay", e.RowIndex].Value.ToString()));
                    }
                }

                if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "DinhMuc_Cu")
                {
                    dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value = dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value;

                    if (dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString()))
                        GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["DinhMucHN_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMucHN_Cu", e.RowIndex].Value.ToString()))
                        DinhMucHN = int.Parse(dgvTruyThuTienNuoc["DinhMucHN_Cu", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString()))
                        DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString()))
                        TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString());

                    if (dgvTruyThuTienNuoc["Ky", e.RowIndex].Value != null)
                    {
                        tinhTienNuocTruoc(e.RowIndex, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Ky", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, DinhMucHN, TieuThu, DateTime.Parse(dgvTruyThuTienNuoc["TuNgay", e.RowIndex].Value.ToString()), DateTime.Parse(dgvTruyThuTienNuoc["DenNgay", e.RowIndex].Value.ToString()));
                    }
                }

                if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TieuThu_Cu")
                {
                    dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value = dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value;

                    if (dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString()))
                        GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["DinhMucHN_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMucHN_Cu", e.RowIndex].Value.ToString()))
                        DinhMucHN = int.Parse(dgvTruyThuTienNuoc["DinhMucHN_Cu", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString()))
                        DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString()))
                        TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString());

                    if (dgvTruyThuTienNuoc["Ky", e.RowIndex].Value != null)
                    {
                        tinhTienNuocTruoc(e.RowIndex, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Ky", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, DinhMucHN, TieuThu, DateTime.Parse(dgvTruyThuTienNuoc["TuNgay", e.RowIndex].Value.ToString()), DateTime.Parse(dgvTruyThuTienNuoc["DenNgay", e.RowIndex].Value.ToString()));
                    }
                }
                ////////////////////////////////////////////

                if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "GiaBieu_Moi")
                {
                    if (dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString()))
                        GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["DinhMucHN_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMucHN_Moi", e.RowIndex].Value.ToString()))
                        DinhMucHN = int.Parse(dgvTruyThuTienNuoc["DinhMucHN_Moi", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString()))
                        DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString()))
                        TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString());

                    if (dgvTruyThuTienNuoc["Ky", e.RowIndex].Value != null)
                    {
                        tinhTienNuocSau(e.RowIndex, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Ky", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, DinhMucHN, TieuThu, DateTime.Parse(dgvTruyThuTienNuoc["TuNgay", e.RowIndex].Value.ToString()), DateTime.Parse(dgvTruyThuTienNuoc["DenNgay", e.RowIndex].Value.ToString()));
                    }
                }

                if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "DinhMucHN_Moi")
                {
                    if (dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString()))
                        GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["DinhMucHN_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMucHN_Moi", e.RowIndex].Value.ToString()))
                        DinhMucHN = int.Parse(dgvTruyThuTienNuoc["DinhMucHN_Moi", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString()))
                        DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString()))
                        TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString());

                    if (dgvTruyThuTienNuoc["Ky", e.RowIndex].Value != null)
                    {
                        tinhTienNuocSau(e.RowIndex, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Ky", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, DinhMucHN, TieuThu, DateTime.Parse(dgvTruyThuTienNuoc["TuNgay", e.RowIndex].Value.ToString()), DateTime.Parse(dgvTruyThuTienNuoc["DenNgay", e.RowIndex].Value.ToString()));
                    }
                }

                if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "DinhMuc_Moi")
                {
                    if (dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString()))
                        GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["DinhMucHN_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMucHN_Moi", e.RowIndex].Value.ToString()))
                        DinhMucHN = int.Parse(dgvTruyThuTienNuoc["DinhMucHN_Moi", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString()))
                        DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString()))
                        TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString());

                    if (dgvTruyThuTienNuoc["Ky", e.RowIndex].Value != null)
                    {
                        tinhTienNuocSau(e.RowIndex, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Ky", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, DinhMucHN, TieuThu, DateTime.Parse(dgvTruyThuTienNuoc["TuNgay", e.RowIndex].Value.ToString()), DateTime.Parse(dgvTruyThuTienNuoc["DenNgay", e.RowIndex].Value.ToString()));
                    }
                }

                if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TieuThu_Moi")
                {
                    if (dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString()))
                        GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["DinhMucHN_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMucHN_Moi", e.RowIndex].Value.ToString()))
                        DinhMucHN = int.Parse(dgvTruyThuTienNuoc["DinhMucHN_Moi", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString()))
                        DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString());
                    if (dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString()))
                        TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString());

                    if (dgvTruyThuTienNuoc["Ky", e.RowIndex].Value != null)
                    {
                        tinhTienNuocSau(e.RowIndex, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Ky", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, DinhMucHN, TieuThu, DateTime.Parse(dgvTruyThuTienNuoc["TuNgay", e.RowIndex].Value.ToString()), DateTime.Parse(dgvTruyThuTienNuoc["DenNgay", e.RowIndex].Value.ToString()));
                    }
                }
            }
        }

        private void tinhTienNuocTruoc(int RowIndex, string DanhBo, int Ky, int Nam, int GiaBieu, int DinhMuc, int DinhMucHN, int TieuThu, DateTime TuNgay, DateTime DenNgay)
        {
            HOADON hd = _cThuTien.Get(DanhBo, Ky, Nam);
            int TyleSH = 0, TyLeSX = 0, TyLeDV = 0, TyLeHCSN = 0;
            int TienNuocNamCu, TienNuocNamMoi, TieuThu_DieuChinhGia, PhiBVMTNamCu, PhiBVMTNamMoi, TienNuoc, ThueGTGT, TDVTN, ThueTDVTN, ThueTDVTN_VAT = 0;
            string ChiTietNamCu, ChiTietNamMoi, ChiTietPhiBVMTNamCu, ChiTietPhiBVMTNamMoi;
            //DateTime TuNgay = DateTime.Now, DenNgay = DateTime.Now;
            if (hd != null)
            {
                if (hd.TILESH != null && hd.TILESH.Value != 0)
                    TyleSH = hd.TILESH.Value;
                if (hd.TILESX != null && hd.TILESX.Value != 0)
                    TyLeSX = hd.TILESX.Value;
                if (hd.TILEDV != null && hd.TILEDV.Value != 0)
                    TyLeDV = hd.TILEDV.Value;
                if (hd.TILEHCSN != null && hd.TILEHCSN.Value != 0)
                    TyLeHCSN = hd.TILEHCSN.Value;
                if (hd.TUNGAY != null)
                    TuNgay = hd.TUNGAY.Value;
                else
                {
                    DocSo ds = _cDocSo.get(DanhBo, Ky, Nam);
                    TuNgay = ds.TuNgay.Value;
                }
                DenNgay = hd.DENNGAY.Value;
            }
            else
            {
                DocSo ds = _cDocSo.get(DanhBo, Ky, Nam);
                if (ds != null)
                {
                    TuNgay = ds.TuNgay.Value;
                    DenNgay = ds.DenNgay.Value;
                }
            }
            _cGiaNuoc.TinhTienNuoc(false, false, false, 0, DanhBo, Ky, Nam, TuNgay, DenNgay, GiaBieu, TyleSH, TyLeSX, TyLeDV, TyLeHCSN, DinhMuc, DinhMucHN, TieuThu, out  TienNuocNamCu, out ChiTietNamCu, out  TienNuocNamMoi, out  ChiTietNamMoi, out  TieuThu_DieuChinhGia, out PhiBVMTNamCu, out ChiTietPhiBVMTNamCu, out PhiBVMTNamMoi, out ChiTietPhiBVMTNamMoi, out TienNuoc, out ThueGTGT, out TDVTN, out ThueTDVTN, out ThueTDVTN_VAT);
            int PhiBVMT = _cGiaNuoc.TinhPhiBMVT2010(Nam, GiaBieu, DinhMuc, TieuThu);

            dgvTruyThuTienNuoc["GiaBan_Cu", RowIndex].Value = TienNuoc;
            dgvTruyThuTienNuoc["ThueGTGT_Cu", RowIndex].Value = ThueGTGT;
            dgvTruyThuTienNuoc["PhiBVMT_Cu", RowIndex].Value = TDVTN;
            if (PhiBVMT == 0)
            {
                //int ThueGTGTTDVTN = 0, TongCong = 0;
                ////Từ 2022 Phí BVMT -> Tiền Dịch Vụ Thoát Nước
                //if ((TuNgay.Year < 2021) || (TuNgay.Year == 2021 && DenNgay.Year == 2021))
                //{
                //    ThueGTGTTDVTN = 0;
                //    TongCong = (int)((TienNuocNamCu + TienNuocNamMoi) + Math.Round((double)(TienNuocNamCu + TienNuocNamMoi) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (PhiBVMTNamCu + PhiBVMTNamMoi));
                //}
                //else
                //    if (TuNgay.Year == 2021 && DenNgay.Year == 2022)
                //    {
                //        ThueGTGTTDVTN = (int)Math.Round((double)(PhiBVMTNamMoi) * 10 / 100, 0, MidpointRounding.AwayFromZero);
                //        TongCong = (int)((TienNuocNamCu + TienNuocNamMoi) + Math.Round((double)(TienNuocNamCu + TienNuocNamMoi) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (PhiBVMTNamCu + PhiBVMTNamMoi) + ThueGTGTTDVTN);
                //    }
                //    else
                //        if (TuNgay.Year >= 2022)
                //        {
                //            ThueGTGTTDVTN = (int)Math.Round((double)(PhiBVMTNamCu + PhiBVMTNamMoi) * 10 / 100, 0, MidpointRounding.AwayFromZero);
                //            TongCong = (int)((TienNuocNamCu + TienNuocNamMoi) + Math.Round((double)(TienNuocNamCu + TienNuocNamMoi) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (PhiBVMTNamCu + PhiBVMTNamMoi) + ThueGTGTTDVTN);
                //        }
                dgvTruyThuTienNuoc["PhiBVMT_Thue_Cu", RowIndex].Value = ThueTDVTN;
                dgvTruyThuTienNuoc["TongCong_Cu", RowIndex].Value = TienNuoc + ThueGTGT + TDVTN + ThueTDVTN;
            }
            else
            {
                dgvTruyThuTienNuoc["PhiBVMT_Cu", RowIndex].Value = PhiBVMT;
                dgvTruyThuTienNuoc["TongCong_Cu", RowIndex].Value = TienNuoc + ThueGTGT + PhiBVMT;
            }
            if (dgvTruyThuTienNuoc["TongCong_Cu", RowIndex].Value != null && dgvTruyThuTienNuoc["TongCong_Moi", RowIndex].Value != null)
                if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", RowIndex].Value.ToString()) < int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", RowIndex].Value.ToString()))
                    dgvTruyThuTienNuoc["TangGiam", RowIndex].Value = "Tăng";
                else
                    if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", RowIndex].Value.ToString()) > int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", RowIndex].Value.ToString()))
                        dgvTruyThuTienNuoc["TangGiam", RowIndex].Value = "Giảm";
                    else
                        dgvTruyThuTienNuoc["TangGiam", RowIndex].Value = "";
        }

        private void tinhTienNuocSau(int RowIndex, string DanhBo, int Ky, int Nam, int GiaBieu, int DinhMuc, int DinhMucHN, int TieuThu, DateTime TuNgay, DateTime DenNgay)
        {
            HOADON hd = _cThuTien.Get(DanhBo, Ky, Nam);
            DocSo ds = null;
            int TyleSH = 0, TyLeSX = 0, TyLeDV = 0, TyLeHCSN = 0;
            int TienNuocNamCu, TienNuocNamMoi, TieuThu_DieuChinhGia, PhiBVMTNamCu, PhiBVMTNamMoi, TienNuoc, ThueGTGT, TDVTN, ThueTDVTN, ThueTDVTN_VAT = 0;
            string ChiTietNamCu, ChiTietNamMoi, ChiTietPhiBVMTNamCu, ChiTietPhiBVMTNamMoi;
            //DateTime TuNgay = DateTime.Now, DenNgay = DateTime.Now;
            if (hd != null)
            {
                if (hd.TILESH != null && hd.TILESH.Value != 0)
                    TyleSH = hd.TILESH.Value;
                if (hd.TILESX != null && hd.TILESX.Value != 0)
                    TyLeSX = hd.TILESX.Value;
                if (hd.TILEDV != null && hd.TILEDV.Value != 0)
                    TyLeDV = hd.TILEDV.Value;
                if (hd.TILEHCSN != null && hd.TILEHCSN.Value != 0)
                    TyLeHCSN = hd.TILEHCSN.Value;
                if (hd.TUNGAY != null)
                    TuNgay = hd.TUNGAY.Value;
                else
                {
                    ds = _cDocSo.get(DanhBo, Ky, Nam);
                    if (ds != null)
                    {
                        TuNgay = ds.TuNgay.Value;
                    }
                }
                DenNgay = hd.DENNGAY.Value;
            }
            else
            {
                ds = _cDocSo.get(DanhBo, Ky, Nam);
                if (ds != null)
                {
                    TuNgay = ds.TuNgay.Value;
                    DenNgay = ds.DenNgay.Value;
                }
            }
            _cGiaNuoc.TinhTienNuoc(false, false, false, 0, DanhBo, Ky, Nam, TuNgay, DenNgay, GiaBieu, TyleSH, TyLeSX, TyLeDV, TyLeHCSN, DinhMuc, DinhMucHN, TieuThu, out  TienNuocNamCu, out ChiTietNamCu, out  TienNuocNamMoi, out  ChiTietNamMoi, out  TieuThu_DieuChinhGia, out PhiBVMTNamCu, out ChiTietPhiBVMTNamCu, out PhiBVMTNamMoi, out ChiTietPhiBVMTNamMoi, out TienNuoc, out ThueGTGT, out TDVTN, out ThueTDVTN, out ThueTDVTN_VAT);
            if (hd == null && ds == null)
                dgvTruyThuTienNuoc["SoTien1m3", RowIndex].Value = _cGiaNuoc.getDonGiaCaoNhat(Ky, Nam, GiaBieu);
            else
                dgvTruyThuTienNuoc["SoTien1m3", RowIndex].Value = _cGiaNuoc.getDonGiaCaoNhat(TuNgay, DenNgay, GiaBieu);
            int PhiBVMT = _cGiaNuoc.TinhPhiBMVT2010(Nam, GiaBieu, DinhMuc, TieuThu);

            dgvTruyThuTienNuoc["GiaBan_Moi", RowIndex].Value = TienNuoc;
            dgvTruyThuTienNuoc["ThueGTGT_Moi", RowIndex].Value = ThueGTGT;
            dgvTruyThuTienNuoc["PhiBVMT_Moi", RowIndex].Value = TDVTN;
            if (PhiBVMT == 0)
            {
                //int ThueGTGTTDVTN = 0, TongCong = 0;
                ////Từ 2022 Phí BVMT -> Tiền Dịch Vụ Thoát Nước
                //if ((TuNgay.Year < 2021) || (TuNgay.Year == 2021 && DenNgay.Year == 2021))
                //{
                //    ThueGTGTTDVTN = 0;
                //    TongCong = (int)((TienNuocNamCu + TienNuocNamMoi) + Math.Round((double)(TienNuocNamCu + TienNuocNamMoi) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (PhiBVMTNamCu + PhiBVMTNamMoi));
                //}
                //else
                //    if (TuNgay.Year == 2021 && DenNgay.Year == 2022)
                //    {
                //        ThueGTGTTDVTN = (int)Math.Round((double)(PhiBVMTNamMoi) * 10 / 100, 0, MidpointRounding.AwayFromZero);
                //        TongCong = (int)((TienNuocNamCu + TienNuocNamMoi) + Math.Round((double)(TienNuocNamCu + TienNuocNamMoi) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (PhiBVMTNamCu + PhiBVMTNamMoi) + ThueGTGTTDVTN);
                //    }
                //    else
                //        if (TuNgay.Year >= 2022)
                //        {
                //            ThueGTGTTDVTN = (int)Math.Round((double)(PhiBVMTNamCu + PhiBVMTNamMoi) * 10 / 100, 0, MidpointRounding.AwayFromZero);
                //            TongCong = (int)((TienNuocNamCu + TienNuocNamMoi) + Math.Round((double)(TienNuocNamCu + TienNuocNamMoi) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (PhiBVMTNamCu + PhiBVMTNamMoi) + ThueGTGTTDVTN);
                //        }
                dgvTruyThuTienNuoc["PhiBVMT_Thue_Moi", RowIndex].Value = ThueTDVTN;
                dgvTruyThuTienNuoc["TongCong_Moi", RowIndex].Value = TienNuoc + ThueGTGT + TDVTN + ThueTDVTN;
            }
            else
            {
                dgvTruyThuTienNuoc["PhiBVMT_Moi", RowIndex].Value = PhiBVMT;
                dgvTruyThuTienNuoc["TongCong_Moi", RowIndex].Value = TienNuoc + ThueGTGT + PhiBVMT;
            }
            if (dgvTruyThuTienNuoc["TongCong_Cu", RowIndex].Value != null && dgvTruyThuTienNuoc["TongCong_Moi", RowIndex].Value != null)
                if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", RowIndex].Value.ToString()) < int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", RowIndex].Value.ToString()))
                    dgvTruyThuTienNuoc["TangGiam", RowIndex].Value = "Tăng";
                else
                    if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", RowIndex].Value.ToString()) > int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", RowIndex].Value.ToString()))
                        dgvTruyThuTienNuoc["TangGiam", RowIndex].Value = "Giảm";
                    else
                        dgvTruyThuTienNuoc["TangGiam", RowIndex].Value = "";
        }

        private void dgvTruyThuTienNuoc_Leave(object sender, EventArgs e)
        {
            if (_flagLoad == false)
            {
                int Tongm3HoaDon = 0;
                int Tongm3ThucTe = 0;
                int GiaBan = 0;
                int ThueGTGT = 0;
                int PhiBVMT = 0;
                int TongCongCu = 0;
                int TongCongMoi = 0;
                foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                    if (item.Cells["Ky"].Value != null && item.Cells["TieuThu_Cu"].Value != null)
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
        }

        private void dgvTruyThuTienNuoc_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_flagLoad == false && dgvTruyThuTienNuoc["ID_HoaDon", e.RowIndex].Value == null)
                if (e.RowIndex < dgvTruyThuTienNuoc.RowCount - 1)
                {
                    if (dgvTruyThuTienNuoc["Nam", e.RowIndex + 1].Value == null)
                        dgvTruyThuTienNuoc["Nam", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["Nam", e.RowIndex].Value;
                    dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value;
                    dgvTruyThuTienNuoc["DinhMucHN_Cu", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["DinhMucHN_Cu", e.RowIndex].Value;
                    dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value;
                    dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value;
                    dgvTruyThuTienNuoc["DinhMucHN_Moi", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["DinhMucHN_Moi", e.RowIndex].Value;
                    dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value;
                }
            if (dgvTruyThuTienNuoc["Ky", e.RowIndex].Value != null)
                dgvTruyThuTienNuoc["SoTien1m3", e.RowIndex].Value = _cGiaNuoc.getDonGiaCaoNhat(int.Parse(dgvTruyThuTienNuoc["Ky", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString()));
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
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    TruyThuTienNuoc_ChiTiet cttttn = new TruyThuTienNuoc_ChiTiet();

                    if (_dontu_ChiTiet != null)
                    {
                        //kiểm tra tình trạng tồn
                        string str = _cTTTN.check_TinhTrang_Ton(_dontu_ChiTiet.DanhBo);
                        if (str != "")
                        {
                            if (MessageBox.Show(str + "\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                return;
                        }
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
                    if (!string.IsNullOrEmpty(txtDinhMucHN.Text.Trim()))
                        cttttn.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
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

                    if (_cTTTN.Them_ChiTiet(cttttn) == true)
                    {
                        foreach (DataGridViewRow item in dgvHinh.Rows)
                        {
                            TruyThuTienNuoc_ChiTiet_Hinh en = new TruyThuTienNuoc_ChiTiet_Hinh();
                            en.IDTruyThuTienNuoc_ChiTiet = cttttn.IDCT;
                            en.Name = item.Cells["Name_Hinh"].Value.ToString();
                            //en.Hinh = Convert.FromBase64String(item.Cells["Bytes_Hinh"].Value.ToString());
                            en.Loai = item.Cells["Loai_Hinh"].Value.ToString();
                            if (_wsThuongVu.ghi_Hinh("TruyThuTienNuoc_ChiTiet_Hinh", en.IDTruyThuTienNuoc_ChiTiet.Value.ToString(), en.Name + en.Loai, Convert.FromBase64String(item.Cells["Bytes_Hinh"].Value.ToString())) == true)
                                _cTTTN.Them_Hinh(en);
                        }
                    }
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
                    long GiaBanCu = 0, GiaBanMoi = 0;
                    foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                        if (item.Cells["Ky"].Value != null && item.Cells["Ky"].ToString() != "")
                            if (_cTTTN.CheckExist_HoaDon(IDCT, int.Parse(item.Cells["Ky"].Value.ToString()), int.Parse(item.Cells["Nam"].Value.ToString())) == false)
                            {
                                TruyThuTienNuoc_HoaDon cttttn_hoadon = new TruyThuTienNuoc_HoaDon();
                                cttttn_hoadon.IDCT = IDCT;
                                cttttn_hoadon.Ky = int.Parse(item.Cells["Ky"].Value.ToString());
                                cttttn_hoadon.Nam = int.Parse(item.Cells["Nam"].Value.ToString());
                                cttttn_hoadon.TuNgay = item.Cells["TuNgay"].Value.ToString();
                                cttttn_hoadon.DenNgay = item.Cells["TuNgay"].Value.ToString();
                                cttttn_hoadon.GiaBieuCu = int.Parse(item.Cells["GiaBieu_Cu"].Value.ToString());
                                if (item.Cells["DinhMucHN_Cu"].Value != null)
                                    cttttn_hoadon.DinhMucHNCu = int.Parse(item.Cells["DinhMucHN_Cu"].Value.ToString());
                                cttttn_hoadon.DinhMucCu = int.Parse(item.Cells["DinhMuc_Cu"].Value.ToString());
                                cttttn_hoadon.TieuThuCu = int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                                cttttn_hoadon.GiaBanCu = int.Parse(item.Cells["GiaBan_Cu"].Value.ToString());
                                cttttn_hoadon.ThueGTGTCu = int.Parse(item.Cells["ThueGTGT_Cu"].Value.ToString());
                                cttttn_hoadon.PhiBVMTCu = int.Parse(item.Cells["PhiBVMT_Cu"].Value.ToString());
                                cttttn_hoadon.PhiBVMT_ThueCu = int.Parse(item.Cells["PhiBVMT_Thue_Cu"].Value.ToString());
                                cttttn_hoadon.TongCongCu = int.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                                GiaBanCu += cttttn_hoadon.GiaBanCu.Value;
                                ///
                                cttttn_hoadon.GiaBieuMoi = int.Parse(item.Cells["GiaBieu_Moi"].Value.ToString());
                                if (item.Cells["DinhMucHN_Moi"].Value != null)
                                    cttttn_hoadon.DinhMucHNMoi = int.Parse(item.Cells["DinhMucHN_Moi"].Value.ToString());
                                cttttn_hoadon.DinhMucMoi = int.Parse(item.Cells["DinhMuc_Moi"].Value.ToString());
                                cttttn_hoadon.TieuThuMoi = int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                                cttttn_hoadon.GiaBanMoi = int.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                                cttttn_hoadon.ThueGTGTMoi = int.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                                cttttn_hoadon.PhiBVMTMoi = int.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                                cttttn_hoadon.PhiBVMT_ThueMoi = int.Parse(item.Cells["PhiBVMT_Thue_Moi"].Value.ToString());
                                cttttn_hoadon.TongCongMoi = int.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                                GiaBanMoi += cttttn_hoadon.GiaBanMoi.Value;
                                cttttn_hoadon.TangGiam = item.Cells["TangGiam"].Value.ToString();
                                cttttn_hoadon.SoTien1m3 = int.Parse(item.Cells["SoTien1m3"].Value.ToString());
                                if (cttttn_hoadon.SoTien1m3 == 0)
                                    cttttn_hoadon.m3BinhQuan = 0;
                                else
                                    cttttn_hoadon.m3BinhQuan = (int)Math.Round((double)(cttttn_hoadon.GiaBanMoi.Value - cttttn_hoadon.GiaBanCu.Value) / (cttttn_hoadon.SoTien1m3), 0, MidpointRounding.AwayFromZero);

                                _cTTTN.Them_HoaDon(cttttn_hoadon);
                                //cttttn_hoadon.CreateBy = CTaiKhoan.MaUser;
                                //cttttn_hoadon.CreateDate = DateTime.Now;
                                //cttttn_hoadon.TruyThuTienNuoc_HoaDons.Add(cttttn_hoadon);
                            }
                    _cTTTN.Refresh();

                    cttttn = _cTTTN.get_ChiTiet(cttttn.IDCT);
                    cttttn.TongTien = GiaBanMoi - GiaBanCu;
                    //cttttn.TongTien = cttttn.TruyThuTienNuoc_HoaDons.Sum(item => item.TongCongMoi.Value) - cttttn.TruyThuTienNuoc_HoaDons.Sum(item => item.TongCongCu.Value);
                    cttttn.Tongm3BinhQuan = (int)Math.Round((double)cttttn.TongTien / (cttttn.SoTien1m3));
                    //cttttn.Tongm3BinhQuan = cttttn.TruyThuTienNuoc_HoaDons.Sum(item => item.m3BinhQuan);
                    _cTTTN.SubmitChanges();

                    if (_dontu_ChiTiet != null)
                        _cDonTu.Them_LichSu(cttttn.CreateDate.Value, "TruyThu", "Đã Lập Truy Thu, " + cttttn.NoiDung, cttttn.IDCT, _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value);
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
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
            //string ky = "";
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (_cttttn != null)
                    {
                        _cttttn.SoTien1m3 = int.Parse(txtSoTien1m3.Text.Trim());
                        //_cttttn.XepDon = chkXepDon.Checked;
                        _cttttn.DanhBo = txtDanhBo.Text.Trim();
                        _cttttn.HopDong = txtHopDong.Text.Trim();
                        _cttttn.LoTrinh = txtLoTrinh.Text.Trim();
                        _cttttn.HoTen = txtHoTen.Text.Trim();
                        _cttttn.DiaChi = txtDiaChi.Text.Trim();
                        if (!string.IsNullOrEmpty(txtGiaBieu.Text.Trim()))
                            _cttttn.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if (!string.IsNullOrEmpty(txtDinhMucHN.Text.Trim()))
                            _cttttn.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                        if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                            _cttttn.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        _cttttn.NoiDung = txtNoiDung.Text.Trim();
                        _cttttn.DienThoai = txtDienThoai.Text.Trim();

                        if (_cttttn.TinhTrang != cmbTinhTrang.SelectedItem.ToString())
                            if (_cttttn.TruyThuTienNuoc.MaDonMoi != null)
                                _cDonTu.runUpdateTinhTrang(_cttttn.TruyThuTienNuoc.MaDonMoi.Value, _cttttn.STT.Value);
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
                        long GiaBanCu = 0, GiaBanMoi = 0;
                        foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                            if (item.Cells["Ky"].Value != null && item.Cells["Ky"].ToString() != "")
                                if (_cTTTN.CheckExist_HoaDon(_cttttn.IDCT, int.Parse(item.Cells["Ky"].Value.ToString()), int.Parse(item.Cells["Nam"].Value.ToString())) == false)
                                //if (item.Cells["IDCT"].Value == null || item.Cells["IDCT"].Value.ToString()=="")
                                {
                                    TruyThuTienNuoc_HoaDon cttttn_hoadon = new TruyThuTienNuoc_HoaDon();

                                    cttttn_hoadon.IDCT = _cttttn.IDCT;
                                    cttttn_hoadon.Ky = int.Parse(item.Cells["Ky"].Value.ToString());
                                    cttttn_hoadon.Nam = int.Parse(item.Cells["Nam"].Value.ToString());
                                    if (item.Cells["TuNgay"].Value != null)
                                        cttttn_hoadon.TuNgay = item.Cells["TuNgay"].Value.ToString();
                                    if (item.Cells["DenNgay"].Value != null)
                                        cttttn_hoadon.DenNgay = item.Cells["DenNgay"].Value.ToString();
                                    cttttn_hoadon.GiaBieuCu = int.Parse(item.Cells["GiaBieu_Cu"].Value.ToString());
                                    cttttn_hoadon.DinhMucHNCu = int.Parse(item.Cells["DinhMucHN_Cu"].Value.ToString());
                                    cttttn_hoadon.DinhMucCu = int.Parse(item.Cells["DinhMuc_Cu"].Value.ToString());
                                    cttttn_hoadon.TieuThuCu = int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                                    cttttn_hoadon.GiaBanCu = int.Parse(item.Cells["GiaBan_Cu"].Value.ToString());
                                    cttttn_hoadon.ThueGTGTCu = int.Parse(item.Cells["ThueGTGT_Cu"].Value.ToString());
                                    cttttn_hoadon.PhiBVMTCu = int.Parse(item.Cells["PhiBVMT_Cu"].Value.ToString());
                                    if (item.Cells["PhiBVMT_Thue_Cu"].Value != null && item.Cells["PhiBVMT_Thue_Cu"].Value.ToString() != "")
                                        cttttn_hoadon.PhiBVMT_ThueCu = int.Parse(item.Cells["PhiBVMT_Thue_Cu"].Value.ToString());
                                    cttttn_hoadon.TongCongCu = int.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                                    GiaBanCu += cttttn_hoadon.GiaBanCu.Value;
                                    ///
                                    cttttn_hoadon.GiaBieuMoi = int.Parse(item.Cells["GiaBieu_Moi"].Value.ToString());
                                    cttttn_hoadon.DinhMucHNMoi = int.Parse(item.Cells["DinhMucHN_Moi"].Value.ToString());
                                    cttttn_hoadon.DinhMucMoi = int.Parse(item.Cells["DinhMuc_Moi"].Value.ToString());
                                    cttttn_hoadon.TieuThuMoi = int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                                    cttttn_hoadon.GiaBanMoi = int.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                                    cttttn_hoadon.ThueGTGTMoi = int.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                                    cttttn_hoadon.PhiBVMTMoi = int.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                                    if (item.Cells["PhiBVMT_Thue_Moi"].Value != null && item.Cells["PhiBVMT_Thue_Moi"].Value.ToString() != "")
                                        cttttn_hoadon.PhiBVMT_ThueMoi = int.Parse(item.Cells["PhiBVMT_Thue_Moi"].Value.ToString());
                                    cttttn_hoadon.TongCongMoi = int.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                                    GiaBanMoi += cttttn_hoadon.GiaBanMoi.Value;
                                    cttttn_hoadon.TangGiam = item.Cells["TangGiam"].Value.ToString();
                                    cttttn_hoadon.SoTien1m3 = int.Parse(item.Cells["SoTien1m3"].Value.ToString());
                                    if (cttttn_hoadon.SoTien1m3 == 0)
                                        cttttn_hoadon.m3BinhQuan = 0;
                                    else
                                        cttttn_hoadon.m3BinhQuan = (int)Math.Round((double)(cttttn_hoadon.TongCongMoi.Value - cttttn_hoadon.TongCongCu.Value) / (cttttn_hoadon.SoTien1m3), 0, MidpointRounding.AwayFromZero);

                                    _cTTTN.Them_HoaDon(cttttn_hoadon);
                                    //cttttn_hoadon.CreateBy = CTaiKhoan.MaUser;
                                    //cttttn_hoadon.CreateDate = DateTime.Now;
                                    //_cttttn.TruyThuTienNuoc_HoaDons.Add(cttttn_hoadon);
                                }
                                else
                                {
                                    TruyThuTienNuoc_HoaDon cttttn_hoadon = _cTTTN.get_HoaDon(_cttttn.IDCT, int.Parse(item.Cells["Ky"].Value.ToString()), int.Parse(item.Cells["Nam"].Value.ToString()));
                                    //TruyThuTienNuoc_HoaDon cttttn_hoadon = _cTTTN.GetCT(int.Parse(item.Cells["IDCT"].Value.ToString()));

                                    cttttn_hoadon.Ky = int.Parse(item.Cells["Ky"].Value.ToString());
                                    cttttn_hoadon.Nam = int.Parse(item.Cells["Nam"].Value.ToString());
                                    if (item.Cells["TuNgay"].Value != null)
                                        cttttn_hoadon.TuNgay = item.Cells["TuNgay"].Value.ToString();
                                    if (item.Cells["DenNgay"].Value != null)
                                        cttttn_hoadon.DenNgay = item.Cells["DenNgay"].Value.ToString();
                                    cttttn_hoadon.GiaBieuCu = int.Parse(item.Cells["GiaBieu_Cu"].Value.ToString());
                                    cttttn_hoadon.DinhMucHNCu = int.Parse(item.Cells["DinhMucHN_Cu"].Value.ToString());
                                    cttttn_hoadon.DinhMucCu = int.Parse(item.Cells["DinhMuc_Cu"].Value.ToString());
                                    cttttn_hoadon.TieuThuCu = int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                                    cttttn_hoadon.GiaBanCu = int.Parse(item.Cells["GiaBan_Cu"].Value.ToString());
                                    cttttn_hoadon.ThueGTGTCu = int.Parse(item.Cells["ThueGTGT_Cu"].Value.ToString());
                                    cttttn_hoadon.PhiBVMTCu = int.Parse(item.Cells["PhiBVMT_Cu"].Value.ToString());
                                    if (item.Cells["PhiBVMT_Thue_Cu"].Value != null && item.Cells["PhiBVMT_Thue_Cu"].Value.ToString() != "")
                                        cttttn_hoadon.PhiBVMT_ThueCu = int.Parse(item.Cells["PhiBVMT_Thue_Cu"].Value.ToString());
                                    cttttn_hoadon.TongCongCu = int.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                                    GiaBanCu += cttttn_hoadon.GiaBanCu.Value;
                                    ///
                                    cttttn_hoadon.GiaBieuMoi = int.Parse(item.Cells["GiaBieu_Moi"].Value.ToString());
                                    cttttn_hoadon.DinhMucHNMoi = int.Parse(item.Cells["DinhMucHN_Moi"].Value.ToString());
                                    cttttn_hoadon.DinhMucMoi = int.Parse(item.Cells["DinhMuc_Moi"].Value.ToString());
                                    cttttn_hoadon.TieuThuMoi = int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                                    cttttn_hoadon.GiaBanMoi = int.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                                    cttttn_hoadon.ThueGTGTMoi = int.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                                    cttttn_hoadon.PhiBVMTMoi = int.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                                    if (item.Cells["PhiBVMT_Thue_Moi"].Value != null && item.Cells["PhiBVMT_Thue_Moi"].Value.ToString() != "")
                                        cttttn_hoadon.PhiBVMT_ThueMoi = int.Parse(item.Cells["PhiBVMT_Thue_Moi"].Value.ToString());
                                    cttttn_hoadon.TongCongMoi = int.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                                    GiaBanMoi += cttttn_hoadon.GiaBanMoi.Value;
                                    cttttn_hoadon.TangGiam = item.Cells["TangGiam"].Value.ToString();
                                    if (item.Cells["SoTien1m3"].Value == null || item.Cells["SoTien1m3"].Value.ToString() == "" || item.Cells["SoTien1m3"].Value.ToString() == "0")
                                    {
                                        HOADON hd = _cThuTien.Get(txtDanhBo.Text.Trim(), int.Parse(item.Cells["Ky"].Value.ToString()), int.Parse(item.Cells["Nam"].Value.ToString()));
                                        DocSo ds = null;
                                        int TyleSH = 0, TyLeSX = 0, TyLeDV = 0, TyLeHCSN = 0;
                                        DateTime TuNgay = DateTime.Now, DenNgay = DateTime.Now;
                                        if (hd != null)
                                        {
                                            if (hd.TILESH != null && hd.TILESH.Value != 0)
                                                TyleSH = hd.TILESH.Value;
                                            if (hd.TILESX != null && hd.TILESX.Value != 0)
                                                TyLeSX = hd.TILESX.Value;
                                            if (hd.TILEDV != null && hd.TILEDV.Value != 0)
                                                TyLeDV = hd.TILEDV.Value;
                                            if (hd.TILEHCSN != null && hd.TILEHCSN.Value != 0)
                                                TyLeHCSN = hd.TILEHCSN.Value;
                                            TuNgay = hd.TUNGAY.Value;
                                            DenNgay = hd.DENNGAY.Value;
                                        }
                                        else
                                        {
                                            ds = _cDocSo.get(txtDanhBo.Text.Trim(), int.Parse(item.Cells["Ky"].Value.ToString()), int.Parse(item.Cells["Nam"].Value.ToString()));
                                            if (ds != null)
                                            {
                                                TuNgay = ds.TuNgay.Value;
                                                DenNgay = ds.DenNgay.Value;
                                            }
                                        }
                                        if (hd == null && ds == null)
                                            cttttn_hoadon.SoTien1m3 = _cGiaNuoc.getDonGiaCaoNhat(int.Parse(item.Cells["Ky"].Value.ToString()), int.Parse(item.Cells["Nam"].Value.ToString()), int.Parse(item.Cells["GiaBieu_Moi"].Value.ToString()));
                                        else
                                            cttttn_hoadon.SoTien1m3 = _cGiaNuoc.getDonGiaCaoNhat(TuNgay, DenNgay, int.Parse(item.Cells["GiaBieu_Moi"].Value.ToString()));
                                    }
                                    else
                                        cttttn_hoadon.SoTien1m3 = int.Parse(item.Cells["SoTien1m3"].Value.ToString());
                                    if (cttttn_hoadon.SoTien1m3 == 0)
                                        cttttn_hoadon.m3BinhQuan = 0;
                                    else
                                        cttttn_hoadon.m3BinhQuan = (int)Math.Round((double)(cttttn_hoadon.TongCongMoi.Value - cttttn_hoadon.TongCongCu.Value) / (cttttn_hoadon.SoTien1m3), 0, MidpointRounding.AwayFromZero);

                                    _cTTTN.Sua_HoaDon(cttttn_hoadon);
                                }
                        _cTTTN.SubmitChanges();
                        _cTTTN.Refresh();

                        _cttttn = _cTTTN.get_ChiTiet(_cttttn.IDCT);
                        _cttttn.TongTien = GiaBanMoi - GiaBanCu;
                        //_cttttn.TongTien = _cttttn.TruyThuTienNuoc_HoaDons.Sum(item => item.TongCongMoi.Value) - _cttttn.TruyThuTienNuoc_HoaDons.Sum(item => item.TongCongCu.Value);
                        _cttttn.Tongm3BinhQuan = (int)Math.Round((double)_cttttn.TongTien / (_cttttn.SoTien1m3));
                        //_cttttn.Tongm3BinhQuan = _cttttn.TruyThuTienNuoc_HoaDons.Sum(item => item.m3BinhQuan);
                        _cTTTN.SubmitChanges();

                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (_cttttn != null && MessageBox.Show("Bạn có chắc chắn xóa Toàn Bộ Truy Thu?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        string flagID = _cttttn.IDCT.ToString();
                        var transactionOptions = new TransactionOptions();
                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                        {
                            DonTu_LichSu dtls = _cDonTu.get_LichSu("TruyThuTienNuoc_ChiTiet", (int)_cttttn.IDCT,_cttttn.CreateBy.Value);
                            if (dtls != null)
                            {
                                _cDonTu.Xoa_LichSu(dtls, true);
                            }
                            if (_cTTTN.Xoa_ChiTiet(_cttttn))
                            {
                                _wsThuongVu.xoa_Folder_Hinh("TruyThuTienNuoc_ChiTiet_Hinh", flagID);
                                scope.Complete();
                                scope.Dispose();
                                _cTTTN.Refresh();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            if (_cttttn != null)
            {
                foreach (TruyThuTienNuoc_HoaDon item in _cttttn.TruyThuTienNuoc_HoaDons.OrderBy(itemA => itemA.Nam).ThenBy(itemA => itemA.Ky).ToList())
                {
                    DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                    //if (txtMaDonMoi.Text.Trim() != "")
                    //    dr["MaDon"] = txtMaDonMoi.Text.Trim();
                    //else
                    //    dr["MaDon"] = txtMaDonCu.Text.Trim();
                    dr["ID"] = _cttttn.IDCT.ToString().Insert(_cttttn.IDCT.ToString().Length - 2, "-");
                    dr["DanhBo"] = _cttttn.DanhBo.ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = _cttttn.HoTen;
                    dr["DiaChi"] = _cttttn.DiaChi;
                    dr["HopDong"] = _cttttn.HopDong;
                    dr["GiaBieu"] = _cttttn.GiaBieu;
                    dr["DinhMucHN"] = _cttttn.DinhMucHN;
                    dr["DinhMuc"] = _cttttn.DinhMuc;
                    dr["m3BinhQuan"] = _cttttn.Tongm3BinhQuan;

                    dr["Ky"] = item.Ky;
                    dr["Nam"] = item.Nam;
                    dr["GiaBieuCu"] = item.GiaBieuCu;
                    dr["DinhMucHNCu"] = item.DinhMucHNCu;
                    dr["DinhMucCu"] = item.DinhMucCu;
                    dr["TieuThuCu"] = item.TieuThuCu;
                    dr["GiaBanCu"] = item.GiaBanCu;
                    dr["ThueGTGTCu"] = item.ThueGTGTCu;
                    dr["PhiBVMTCu"] = item.PhiBVMTCu;
                    if (item.PhiBVMT_ThueCu != null)
                        dr["PhiBVMT_ThueCu"] = item.PhiBVMT_ThueCu;
                    else
                        dr["PhiBVMT_ThueCu"] = 0;
                    dr["TongCongCu"] = item.TongCongCu;
                    dr["GiaBieuMoi"] = item.GiaBieuMoi;
                    dr["DinhMucHNMoi"] = item.DinhMucHNMoi;
                    dr["DinhMucMoi"] = item.DinhMucMoi;
                    dr["TieuThuMoi"] = item.TieuThuMoi;
                    dr["GiaBanMoi"] = item.GiaBanMoi;
                    dr["ThueGTGTMoi"] = item.ThueGTGTMoi;
                    dr["PhiBVMTMoi"] = item.PhiBVMTMoi;
                    if (item.PhiBVMT_ThueMoi != null)
                        dr["PhiBVMT_ThueMoi"] = item.PhiBVMT_ThueMoi;
                    else
                        dr["PhiBVMT_ThueMoi"] = 0;
                    dr["TongCongMoi"] = item.TongCongMoi;
                    dr["TangGiam"] = item.TangGiam;

                    //dr["SoTien1m3"] = _cttttn.SoTien1m3;
                    //dr["m3BinhQuan"] = item.m3BinhQuan;
                    dr["NhanVien"] = CTaiKhoan.HoTen;
                    dr["NguoiKy"] = CTaiKhoan.NguoiKy;

                    dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
                }
            }
            else
            {
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
                        dr["DinhMucHN"] = txtDinhMucHN.Text.Trim();
                        dr["DinhMuc"] = txtDinhMuc.Text.Trim();
                        //dr["m3BinhQuan"] = txtSoTien1m3.Text.Trim();

                        dr["Ky"] = item.Cells["Ky"].Value.ToString();
                        dr["Nam"] = item.Cells["Nam"].Value.ToString();
                        dr["GiaBieuCu"] = item.Cells["GiaBieu_Cu"].Value.ToString();
                        dr["DinhMucHNCu"] = item.Cells["DinhMucHN_Cu"].Value.ToString();
                        dr["DinhMucCu"] = item.Cells["DinhMuc_Cu"].Value.ToString();
                        dr["TieuThuCu"] = item.Cells["TieuThu_Cu"].Value.ToString();
                        dr["GiaBanCu"] = item.Cells["GiaBan_Cu"].Value.ToString();
                        dr["ThueGTGTCu"] = item.Cells["ThueGTGT_Cu"].Value.ToString();
                        dr["PhiBVMTCu"] = item.Cells["PhiBVMT_Cu"].Value.ToString();
                        dr["PhiBVMT_ThueCu"] = item.Cells["PhiBVMT_Thue_Cu"].Value.ToString();
                        dr["TongCongCu"] = item.Cells["TongCong_Cu"].Value.ToString();
                        dr["GiaBieuMoi"] = item.Cells["GiaBieu_Moi"].Value.ToString();
                        dr["DinhMucHNMoi"] = item.Cells["DinhMucHN_Moi"].Value.ToString();
                        dr["DinhMucMoi"] = item.Cells["DinhMuc_Moi"].Value.ToString();
                        dr["TieuThuMoi"] = item.Cells["TieuThu_Moi"].Value.ToString();
                        dr["GiaBanMoi"] = item.Cells["GiaBan_Moi"].Value.ToString();
                        dr["ThueGTGTMoi"] = item.Cells["ThueGTGT_Moi"].Value.ToString();
                        dr["PhiBVMTMoi"] = item.Cells["PhiBVMT_Moi"].Value.ToString();
                        dr["PhiBVMT_ThueMoi"] = item.Cells["PhiBVMT_Thue_Moi"].Value.ToString();
                        dr["TongCongMoi"] = item.Cells["TongCong_Moi"].Value.ToString();
                        dr["TangGiam"] = item.Cells["TangGiam"].Value.ToString();
                        dr["NhanVien"] = CTaiKhoan.HoTen;
                        dr["NguoiKy"] = CTaiKhoan.NguoiKy;
                        //TruyThuTienNuoc_ChiTiet cttttn = new TruyThuTienNuoc_ChiTiet();
                        //if (_dontu_ChiTiet != null)
                        //    cttttn = _cTTTN.get_ChiTiet(_dontu_ChiTiet.MaDon.Value);
                        //else
                        //    if (_dontkh != null)
                        //        cttttn = _cTTTN.get_ChiTiet("TKH", _dontkh.MaDon);
                        //    else
                        //        if (_dontxl != null)
                        //            cttttn = _cTTTN.get_ChiTiet("TXL", _dontxl.MaDon);
                        //        else
                        //            if (_dontbc != null)
                        //                cttttn = _cTTTN.get_ChiTiet("TBC", _dontbc.MaDon);
                        //if (cttttn != null)
                        //    dr["SoTien1m3"] = cttttn.SoTien1m3;

                        dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
                    }
            }
            rptTruyThuTienNuoc rpt = new rptTruyThuTienNuoc();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnInChiTiet_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            if (_cttttn != null)
            {
                foreach (TruyThuTienNuoc_HoaDon item in _cttttn.TruyThuTienNuoc_HoaDons.OrderBy(itemA => itemA.Nam).ThenBy(itemA => itemA.Ky).ToList())
                {
                    DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                    //if (txtMaDonMoi.Text.Trim() != "")
                    //    dr["MaDon"] = txtMaDonMoi.Text.Trim();
                    //else
                    //    dr["MaDon"] = txtMaDonCu.Text.Trim();
                    dr["ID"] = _cttttn.IDCT.ToString().Insert(_cttttn.IDCT.ToString().Length - 2, "-");
                    dr["DanhBo"] = _cttttn.DanhBo.ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = _cttttn.HoTen;
                    dr["DiaChi"] = _cttttn.DiaChi;
                    dr["HopDong"] = _cttttn.HopDong;
                    dr["GiaBieu"] = _cttttn.GiaBieu;
                    dr["DinhMucHN"] = _cttttn.DinhMucHN;
                    dr["DinhMuc"] = _cttttn.DinhMuc;

                    dr["Ky"] = item.Ky;
                    dr["Nam"] = item.Nam;
                    dr["GiaBieuCu"] = item.GiaBieuCu;
                    dr["DinhMucHNCu"] = item.DinhMucHNCu;
                    dr["DinhMucCu"] = item.DinhMucCu;
                    dr["TieuThuCu"] = item.TieuThuCu;
                    dr["GiaBanCu"] = item.GiaBanCu;
                    dr["ThueGTGTCu"] = item.ThueGTGTCu;
                    dr["PhiBVMTCu"] = item.PhiBVMTCu;
                    if (item.PhiBVMT_ThueCu != null)
                        dr["PhiBVMT_ThueCu"] = item.PhiBVMT_ThueCu;
                    else
                        dr["PhiBVMT_ThueCu"] = 0;
                    dr["TongCongCu"] = item.TongCongCu;
                    dr["GiaBieuMoi"] = item.GiaBieuMoi;
                    dr["DinhMucHNMoi"] = item.DinhMucHNMoi;
                    dr["DinhMucMoi"] = item.DinhMucMoi;
                    dr["TieuThuMoi"] = item.TieuThuMoi;
                    dr["GiaBanMoi"] = item.GiaBanMoi;
                    dr["ThueGTGTMoi"] = item.ThueGTGTMoi;
                    dr["PhiBVMTMoi"] = item.PhiBVMTMoi;
                    if (item.PhiBVMT_ThueMoi != null)
                        dr["PhiBVMT_ThueMoi"] = item.PhiBVMT_ThueMoi;
                    else
                        dr["PhiBVMT_ThueMoi"] = 0;
                    dr["TongCongMoi"] = item.TongCongMoi;
                    dr["TangGiam"] = item.TangGiam;
                    dr["SoTien1m3"] = item.TruyThuTienNuoc_ChiTiet.SoTien1m3;

                    dr["NhanVien"] = CTaiKhoan.HoTen;
                    dr["NguoiKy"] = CTaiKhoan.NguoiKy;
                    dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
                }
            }
            else
            {
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
                        dr["DinhMucHN"] = txtDinhMucHN.Text.Trim();
                        dr["DinhMuc"] = txtDinhMuc.Text.Trim();

                        dr["Ky"] = item.Cells["Ky"].Value.ToString();
                        dr["Nam"] = item.Cells["Nam"].Value.ToString();
                        dr["GiaBieuCu"] = item.Cells["GiaBieu_Cu"].Value.ToString();
                        if (item.Cells["DinhMucHN_Cu"].Value != null)
                            dr["DinhMucHNCu"] = item.Cells["DinhMucHN_Cu"].Value.ToString();
                        if (item.Cells["DinhMuc_Cu"].Value != null)
                            dr["DinhMucCu"] = item.Cells["DinhMuc_Cu"].Value.ToString();
                        dr["TieuThuCu"] = item.Cells["TieuThu_Cu"].Value.ToString();
                        dr["GiaBanCu"] = item.Cells["GiaBan_Cu"].Value.ToString();
                        dr["ThueGTGTCu"] = item.Cells["ThueGTGT_Cu"].Value.ToString();
                        dr["PhiBVMTCu"] = item.Cells["PhiBVMT_Cu"].Value.ToString();
                        dr["TongCongCu"] = item.Cells["TongCong_Cu"].Value.ToString();
                        dr["GiaBieuMoi"] = item.Cells["GiaBieu_Moi"].Value.ToString();
                        if (item.Cells["DinhMucHN_Moi"].Value != null)
                            dr["DinhMucHNMoi"] = item.Cells["DinhMucHN_Moi"].Value.ToString();
                        if (item.Cells["DinhMuc_Moi"].Value != null)
                            dr["DinhMucMoi"] = item.Cells["DinhMuc_Moi"].Value.ToString();
                        dr["TieuThuMoi"] = item.Cells["TieuThu_Moi"].Value.ToString();
                        dr["GiaBanMoi"] = item.Cells["GiaBan_Moi"].Value.ToString();
                        dr["ThueGTGTMoi"] = item.Cells["ThueGTGT_Moi"].Value.ToString();
                        dr["PhiBVMTMoi"] = item.Cells["PhiBVMT_Moi"].Value.ToString();
                        dr["TongCongMoi"] = item.Cells["TongCong_Moi"].Value.ToString();
                        if (item.Cells["TangGiam"].Value != null)
                            dr["TangGiam"] = item.Cells["TangGiam"].Value.ToString();
                        //if (item.Cells["SoTien1m3"].Value != null)
                        //    dr["SoTien1m3"] = item.Cells["SoTien1m3"].Value.ToString();
                        dr["NhanVien"] = CTaiKhoan.HoTen;
                        dr["NguoiKy"] = CTaiKhoan.NguoiKy;
                        dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
                    }
            }
            rptTruyThuTienNuocChiTiet rpt = new rptTruyThuTienNuocChiTiet();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnInKTTC_Click(object sender, EventArgs e)
        {
            try
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                if (_cttttn != null)
                {
                    foreach (TruyThuTienNuoc_HoaDon item in _cttttn.TruyThuTienNuoc_HoaDons.OrderBy(itemA => itemA.Nam).ThenBy(itemA => itemA.Ky).ToList())
                    {
                        DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                        //if (txtMaDonMoi.Text.Trim() != "")
                        //    dr["MaDon"] = txtMaDonMoi.Text.Trim();
                        //else
                        //    dr["MaDon"] = txtMaDonCu.Text.Trim();
                        dr["ID"] = _cttttn.IDCT.ToString().Insert(_cttttn.IDCT.ToString().Length - 2, "-");
                        dr["DanhBo"] = _cttttn.DanhBo.ToString().Insert(7, " ").Insert(4, " ");
                        dr["HoTen"] = _cttttn.HoTen;
                        dr["DiaChi"] = _cttttn.DiaChi;
                        dr["HopDong"] = _cttttn.HopDong;
                        dr["GiaBieu"] = _cttttn.GiaBieu;
                        dr["DinhMucHN"] = _cttttn.DinhMucHN;
                        dr["DinhMuc"] = _cttttn.DinhMuc;

                        dr["Ky"] = item.Ky;
                        dr["Nam"] = item.Nam;
                        dr["TieuThuCu"] = item.TieuThuCu;
                        dr["TieuThuMoi"] = item.TieuThuMoi;
                        dr["DinhMucCu"] = item.TongCongCu;
                        dr["DinhMucMoi"] = item.TongCongMoi;
                        dr["m3BinhQuan"] = item.TruyThuTienNuoc_ChiTiet.Tongm3BinhQuan;
                        HOADON hd = _cThuTien.Get(_cttttn.DanhBo, item.Ky.Value, item.Nam.Value);
                        int TyleSH = 0, TyLeSX = 0, TyLeDV = 0, TyLeHCSN = 0;
                        int TienNuocNamCu_Truoc, TienNuocNamMoi_Truoc, TieuThu_DieuChinhGia_Truoc, PhiBVMTNamCu_Truoc, PhiBVMTNamMoi_Truoc, TienNuoc_Truoc, ThueGTGT_Truoc, TDVTN_Truoc, ThueTDVTN_Truoc;
                        string ChiTietNamCu_Truoc, ChiTietNamMoi_Truoc, ChiTietPhiBVMTNamCu_Truoc, ChiTietPhiBVMTNamMoi_Truoc;
                        if (hd != null)
                        {
                            if (hd.TILESH != null && hd.TILESH.Value != 0)
                                TyleSH = hd.TILESH.Value;
                            if (hd.TILESX != null && hd.TILESX.Value != 0)
                                TyLeSX = hd.TILESX.Value;
                            if (hd.TILEDV != null && hd.TILEDV.Value != 0)
                                TyLeDV = hd.TILEDV.Value;
                            if (hd.TILEHCSN != null && hd.TILEHCSN.Value != 0)
                                TyLeHCSN = hd.TILEHCSN.Value;
                        }
                        int ThueTDVTN_VAT = 0;
                        _cGiaNuoc.TinhTienNuoc(false, false, false, 0, _cttttn.DanhBo, item.Ky.Value, item.Nam.Value, DateTime.Parse(item.TuNgay), DateTime.Parse(item.DenNgay), item.GiaBieuCu.Value, TyleSH, TyLeSX, TyLeDV, TyLeHCSN, item.DinhMucCu.Value, item.DinhMucHNCu.Value, item.TieuThuCu.Value, out  TienNuocNamCu_Truoc, out ChiTietNamCu_Truoc, out  TienNuocNamMoi_Truoc, out  ChiTietNamMoi_Truoc, out  TieuThu_DieuChinhGia_Truoc, out PhiBVMTNamCu_Truoc, out ChiTietPhiBVMTNamCu_Truoc, out PhiBVMTNamMoi_Truoc, out ChiTietPhiBVMTNamMoi_Truoc, out TienNuoc_Truoc, out ThueGTGT_Truoc, out TDVTN_Truoc, out ThueTDVTN_Truoc, out ThueTDVTN_VAT);

                        int TienNuocNamCu_Sau, TienNuocNamMoi_Sau, TieuThu_DieuChinhGia_Sau, PhiBVMTNamCu_Sau, PhiBVMTNamMoi_Sau, TienNuoc_Sau, ThueGTGT_Sau, TDVTN_Sau, ThueTDVTN_Sau;
                        string ChiTietNamCu_Sau, ChiTietNamMoi_Sau, ChiTietPhiBVMTNamCu_Sau, ChiTietPhiBVMTNamMoi_Sau;
                        _cGiaNuoc.TinhTienNuoc(false, false, false, 0, _cttttn.DanhBo, item.Ky.Value, item.Nam.Value, DateTime.Parse(item.TuNgay), DateTime.Parse(item.DenNgay), item.GiaBieuMoi.Value, TyleSH, TyLeSX, TyLeDV, TyLeHCSN, item.DinhMucMoi.Value, item.DinhMucHNMoi.Value, item.TieuThuMoi.Value, out  TienNuocNamCu_Sau, out ChiTietNamCu_Sau, out  TienNuocNamMoi_Sau, out  ChiTietNamMoi_Sau, out  TieuThu_DieuChinhGia_Sau, out PhiBVMTNamCu_Sau, out ChiTietPhiBVMTNamCu_Sau, out PhiBVMTNamMoi_Sau, out ChiTietPhiBVMTNamMoi_Sau, out TienNuoc_Sau, out ThueGTGT_Sau, out TDVTN_Sau, out ThueTDVTN_Sau, out ThueTDVTN_VAT);
                        if (TienNuocNamMoi_Truoc > 0 || TienNuocNamMoi_Sau > 0)
                        {
                            dr["GiaBanCu"] = TienNuocNamCu_Sau - TienNuocNamCu_Truoc;
                            dr["GiaBanMoi"] = TienNuocNamMoi_Sau - TienNuocNamMoi_Truoc;
                            dr["ThueGTGTCu"] = (int)Math.Round((double)(TienNuocNamCu_Sau - TienNuocNamCu_Truoc) * 5 / 100, 1, MidpointRounding.ToEven);
                            dr["ThueGTGTMoi"] = (int)Math.Round((double)(TienNuocNamMoi_Sau - TienNuocNamMoi_Truoc) * 5 / 100, 1, MidpointRounding.ToEven);
                            if (item.Nam.Value < 2022)
                            {
                                dr["PhiBVMTCu1"] = PhiBVMTNamCu_Sau - PhiBVMTNamCu_Truoc;
                                dr["PhiBVMTCu"] = 0;
                                dr["PhiBVMTMoi1"] = PhiBVMTNamMoi_Sau - PhiBVMTNamMoi_Truoc;
                                dr["PhiBVMTMoi"] = 0;
                                dr["PhiBVMT_ThueCu"] = 0;
                                dr["PhiBVMT_ThueMoi"] = 0;
                            }
                            else
                            {
                                if (item.Nam.Value == 2022 && (item.Ky.Value == 1 || item.Ky.Value == 2))
                                {
                                    dr["PhiBVMTCu1"] = PhiBVMTNamCu_Sau - PhiBVMTNamCu_Truoc;
                                    dr["PhiBVMTCu"] = 0;
                                    dr["PhiBVMTMoi"] = PhiBVMTNamMoi_Sau - PhiBVMTNamMoi_Truoc;
                                    dr["PhiBVMTMoi1"] = 0;
                                    dr["PhiBVMT_ThueCu"] = 0;
                                    if ((PhiBVMTNamMoi_Sau - PhiBVMTNamMoi_Truoc) > 0)
                                    {
                                        dr["PhiBVMT_ThueMoi"] = (int)Math.Round((double)(PhiBVMTNamMoi_Sau - PhiBVMTNamMoi_Truoc) * ThueTDVTN_VAT / 100, 1, MidpointRounding.ToEven);
                                        //dr["PhiBVMT_ThueMoi"] = (PhiBVMTNamMoi_Sau - PhiBVMTNamMoi_Truoc) * ThueTDVTN_VAT / 100;
                                    }
                                    else
                                        dr["PhiBVMT_ThueMoi"] = 0;
                                }
                                else
                                {
                                    dr["PhiBVMTCu1"] = 0;
                                    dr["PhiBVMTCu"] = PhiBVMTNamCu_Sau - PhiBVMTNamCu_Truoc;
                                    dr["PhiBVMTMoi1"] = 0;
                                    dr["PhiBVMTMoi"] = PhiBVMTNamMoi_Sau - PhiBVMTNamMoi_Truoc;

                                    if ((PhiBVMTNamCu_Sau - PhiBVMTNamCu_Truoc) > 0)
                                        dr["PhiBVMT_ThueCu"] = (int)Math.Round((double)(PhiBVMTNamCu_Sau - PhiBVMTNamCu_Truoc) * ThueTDVTN_VAT / 100, 1, MidpointRounding.ToEven);
                                    else
                                        dr["PhiBVMT_ThueCu"] = 0;
                                    if ((PhiBVMTNamMoi_Sau - PhiBVMTNamMoi_Truoc) > 0)
                                        dr["PhiBVMT_ThueMoi"] = (int)Math.Round((double)(PhiBVMTNamMoi_Sau - PhiBVMTNamMoi_Truoc) * ThueTDVTN_VAT / 100, 1, MidpointRounding.ToEven);
                                    else
                                        dr["PhiBVMT_ThueMoi"] = 0;
                                }
                            }
                            dr["TongCongCu"] = (int)dr["GiaBanCu"] + (int)dr["ThueGTGTCu"] + (int)dr["PhiBVMTCu1"] + (int)dr["PhiBVMTCu"] + (int)dr["PhiBVMT_ThueCu"];
                            dr["TongCongMoi"] = (int)dr["GiaBanMoi"] + (int)dr["ThueGTGTMoi"] + (int)dr["PhiBVMTMoi1"] + (int)dr["PhiBVMTMoi"] + (int)dr["PhiBVMT_ThueMoi"];
                        }
                        else
                        {
                            if (item.Nam.Value == 2022 && (item.Ky.Value == 1 || item.Ky.Value == 2) && DateTime.Parse(item.TuNgay).Year != DateTime.Parse(item.DenNgay).Year)
                            {
                                dr["GiaBanMoi"] = 0;
                                dr["ThueGTGTMoi"] = 0;
                                dr["PhiBVMTMoi1"] = 0;
                                dr["PhiBVMTMoi"] = 0;
                                dr["PhiBVMT_ThueMoi"] = 0;
                                dr["TongCongMoi"] = 0;
                            }
                            dr["GiaBanCu"] = item.GiaBanMoi - item.GiaBanCu;
                            dr["ThueGTGTCu"] = item.ThueGTGTMoi - item.ThueGTGTCu;
                            if (item.Nam.Value < 2022 || (item.Nam.Value == 2022 && (item.Ky.Value == 1 || item.Ky.Value == 2) && TienNuocNamCu_Sau > 0 && TienNuocNamMoi_Sau > 0))
                            {
                                dr["PhiBVMTCu1"] = item.PhiBVMTMoi - item.PhiBVMTCu;
                                dr["PhiBVMTCu"] = 0;
                            }
                            else
                            {
                                if (item.PhiBVMT_ThueCu != null && item.PhiBVMT_ThueCu > 0)
                                {
                                    dr["PhiBVMTCu1"] = 0;
                                    dr["PhiBVMTCu"] = item.PhiBVMTMoi - item.PhiBVMTCu;
                                }
                                else
                                {
                                    dr["PhiBVMTCu1"] = item.PhiBVMTMoi - item.PhiBVMTCu;
                                    dr["PhiBVMTCu"] = 0;
                                }
                            }
                            if (item.PhiBVMT_ThueCu != null)
                                dr["PhiBVMT_ThueCu"] = item.PhiBVMT_ThueMoi - item.PhiBVMT_ThueCu;
                            else
                                dr["PhiBVMT_ThueCu"] = 0;
                            dr["TongCongCu"] = item.TongCongMoi - item.TongCongCu;
                        }
                        dr["NhanVien"] = CTaiKhoan.HoTen;
                        dr["NguoiKy"] = CTaiKhoan.NguoiKy;
                        dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
                    }
                    rptTruyThuTienNuocKTTC rpt = new rptTruyThuTienNuocKTTC();
                    rpt.SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        entity.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));

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
                        TruyThuTienNuoc_ThanhToan entity = _cTTTN.get_ThanhToan(int.Parse(dgvThanhToanTruyThuTienNuoc.SelectedRows[0].Cells["ID_ThanhToan"].Value.ToString()));

                        entity.NgayDong = dateDongTien.Value;
                        entity.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));

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
                    if (_cttttn != null && MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        TruyThuTienNuoc_ThanhToan entity = _cTTTN.get_ThanhToan(int.Parse(dgvThanhToanTruyThuTienNuoc.SelectedRows[0].Cells["ID_ThanhToan"].Value.ToString()));

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
                            //if (_dontu_ChiTiet != null)
                            //    _cDonTu.Them_LichSu("TruyThuThuMoi", "Đã Gửi Thư Mời, " +entity.VaoLuc, entity.ID, _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value);
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
                        TruyThuTienNuoc_ThuMoi entity = _cTTTN.get_ThuMoi(int.Parse(dgvThuMoi.SelectedRows[0].Cells["ID_ThuMoi"].Value.ToString()));

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
                    if (_cttttn != null && MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        TruyThuTienNuoc_ThuMoi entity = _cTTTN.get_ThuMoi(int.Parse(dgvThuMoi.SelectedRows[0].Cells["ID_ThuMoi"].Value.ToString()));
                        var transactionOptions = new TransactionOptions();
                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                        {
                            DonTu_LichSu dtls = _cDonTu.get_LichSu("TruyThuTienNuoc_ThuMoi", (int)entity.IDCT,entity.CreateBy.Value);
                            if (dtls != null)
                            {
                                _cDonTu.Xoa_LichSu(dtls, true);
                            }
                            if (_cTTTN.Xoa_ThuMoi(entity))
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearThuMoi();
                                LoadDSThuMoi(_cttttn.IDCT);
                            }
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
                dr["NguoiKy"] = CTaiKhoan.NguoiKy;

                dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);

                DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(drLogo);

                rptThuMoiTruyThu rpt = new rptThuMoiTruyThu();
                rpt.SetDataSource(dsBaoCao);
                rpt.Subreports[0].SetDataSource(dsBaoCao);
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
            try
            {
                if (_cttttn != null)
                {
                    if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                    {
                        TruyThuTienNuoc_HoaDon cttttn_hoadon = _cTTTN.get_HoaDon(_cttttn.IDCT, int.Parse(e.Row.Cells["Ky"].Value.ToString()), int.Parse(e.Row.Cells["Nam"].Value.ToString()));
                        if (_cTTTN.Xoa_HoaDon(cttttn_hoadon))
                        {
                            _cttttn = _cTTTN.get_ChiTiet(_cttttn.IDCT);
                            _cttttn.TongTien = _cttttn.TruyThuTienNuoc_HoaDons.Sum(item => item.TongCongMoi.Value) - _cttttn.TruyThuTienNuoc_HoaDons.Sum(item => item.TongCongCu.Value);
                            _cttttn.Tongm3BinhQuan = (int)Math.Round((double)_cttttn.TongTien / (_cttttn.SoTien1m3));
                            _cTTTN.SubmitChanges();
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    frmCapNhatDonTu_Thumbnail frm = new frmCapNhatDonTu_Thumbnail(_dontu_ChiTiet, "TruyThuTienNuoc_ChiTiet", _cttttn.IDCT);
                    frm.ShowDialog();
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        bytes = _cTTTN.scanFile(dialog.FileName);
                    else
                        bytes = _cTTTN.scanImage(dialog.FileName);
                    if (_cttttn == null)
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
                            TruyThuTienNuoc_ChiTiet_Hinh en = new TruyThuTienNuoc_ChiTiet_Hinh();
                            en.IDTruyThuTienNuoc_ChiTiet = _cttttn.IDCT;
                            en.Name = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                            en.Loai = System.IO.Path.GetExtension(dialog.FileName);
                            if (_wsThuongVu.ghi_Hinh("TruyThuTienNuoc_ChiTiet_Hinh", en.IDTruyThuTienNuoc_ChiTiet.Value.ToString(), en.Name + en.Loai, bytes) == true)
                                if (_cTTTN.Them_Hinh(en) == true)
                                {
                                    _cTTTN.Refresh();
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
                contextMenuStrip2.Show(dgvHinh, new Point(e.X, e.Y));
            }
        }

        private void dgvHinh_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            byte[] file = _wsThuongVu.get_Hinh("TruyThuTienNuoc_ChiTiet_Hinh", _cttttn.IDCT.ToString(), dgvHinh.CurrentRow.Cells["Name_Hinh"].Value.ToString() + dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString());
            if (file != null)
                if (dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString().ToLower().Contains("pdf"))
                    _cTTTN.viewPDF(1,file);
                else
                    _cTTTN.viewImage(file);
            else
                MessageBox.Show("File không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void xoaFile_dgvHinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (_cttttn == null)
                    dgvHinh.Rows.RemoveAt(dgvHinh.CurrentRow.Index);
                else
                    if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                    {
                        if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (dgvHinh.CurrentRow.Cells["ID_Hinh"].Value != null)
                                if (_wsThuongVu.xoa_Hinh("TruyThuTienNuoc_ChiTiet_Hinh", _cttttn.IDCT.ToString(), dgvHinh.CurrentRow.Cells["Name_Hinh"].Value.ToString() + dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString()) == true)
                                    if (_cTTTN.Xoa_Hinh(_cTTTN.get_Hinh(int.Parse(dgvHinh.CurrentRow.Cells["ID_Hinh"].Value.ToString()))))
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

        private void btnAutoTaiHoaDon_Click(object sender, EventArgs e)
        {
            DataTable dt = _cThuTien.getDS(txtDanhBo.Text.Trim(), int.Parse(txtTuKy.Text.Trim()), int.Parse(txtTuNam.Text.Trim()), int.Parse(txtDenKy.Text.Trim()), int.Parse(txtDenNam.Text.Trim()));
            foreach (DataRow item in dt.Rows)
            {
                var index = dgvTruyThuTienNuoc.Rows.Add();
                dgvTruyThuTienNuoc.Rows[index].Cells["Nam"].Value = item["Nam"];
                dgvTruyThuTienNuoc.Rows[index].Cells["Ky"].Value = item["Ky"];
            }

        }






    }
}

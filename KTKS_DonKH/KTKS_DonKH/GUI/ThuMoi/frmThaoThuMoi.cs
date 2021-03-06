﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.DAL.ThuMoi;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ThuMoi;
using KTKS_DonKH.GUI.BaoCao;
using CrystalDecisions.CrystalReports.Engine;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.GUI.DonTu;
using System.Transactions;

namespace KTKS_DonKH.GUI.ThuMoi
{
    public partial class frmThaoThuMoi : Form
    {
        string _mnu = "mnuThaoThuMoi";
        CDonTu _cDonTu = new CDonTu();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CThuMoi _cThuMoi = new CThuMoi();
        CDHN _cDocSo = new CDHN();
        CThuTien _cThuTien = new CThuTien();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();

        DonTu_ChiTiet _dontu_ChiTiet = null;
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        LinQ.ThuMoi_ChiTiet _thumoi = null;
        int _IDCT = -1;

        public frmThaoThuMoi()
        {
            InitializeComponent();
        }

        public frmThaoThuMoi(int SoPhieu)
        {
            _IDCT = SoPhieu;
            InitializeComponent();
        }

        private void frmThaoThuMoi_Load(object sender, EventArgs e)
        {
            dgvDSThu.AutoGenerateColumns = false;
            dgvHinh.AutoGenerateColumns = false;

            DataTable dt1 = _cThuMoi.getCanCu();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (DataRow item in dt1.Rows)
            {
                auto1.Add(item["CanCu"].ToString());
            }
            txtCanCu.AutoCompleteCustomSource = auto1;

            DataTable dt2 = _cThuMoi.getVeViec();
            AutoCompleteStringCollection auto2 = new AutoCompleteStringCollection();
            foreach (DataRow item in dt2.Rows)
            {
                auto2.Add(item["VeViec"].ToString());
            }
            txtVeViec.AutoCompleteCustomSource = auto2;
            txtNoiNhan.Text = CTaiKhoan.HoTen;
            if (_IDCT != -1)
            {
                txtIDCT.Text = _IDCT.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtIDCT_KeyPress(sender, arg);
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
            if (hoadon.DM != null)
                txtDinhMuc.Text = hoadon.DM.Value.ToString();
            else
                txtDinhMuc.Text = "";
            if (hoadon.DinhMucHN != null)
                txtDinhMucHN.Text = hoadon.DinhMucHN.Value.ToString();
            else
                txtDinhMucHN.Text = "";
        }

        public void LoadEntity(LinQ.ThuMoi_ChiTiet en)
        {
            if (en.ThuMoi.MaDonMoi != null)
            {
                _dontu_ChiTiet = _cDonTu.get_ChiTiet(en.ThuMoi.MaDonMoi.Value, en.STT.Value);
                if (_dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count == 1)
                    txtMaDonMoi.Text = en.ThuMoi.MaDonMoi.ToString();
                else
                    txtMaDonMoi.Text = en.ThuMoi.MaDonMoi.Value.ToString() + "." + en.STT.Value.ToString();
            }
            else
                if (en.ThuMoi.MaDonTKH != null)
                {
                    _dontkh = _cDonKH.Get(en.ThuMoi.MaDonTKH.Value);
                    txtMaDonCu.Text = en.ThuMoi.MaDonTKH.Value.ToString().Insert(en.ThuMoi.MaDonTKH.Value.ToString().Length - 2, "-");
                }
                else
                    if (en.ThuMoi.MaDonTXL != null)
                    {
                        _dontxl = _cDonTXL.Get(en.ThuMoi.MaDonTXL.Value);
                        txtMaDonCu.Text = "TXL" + en.ThuMoi.MaDonTXL.Value.ToString().Insert(en.ThuMoi.MaDonTXL.Value.ToString().Length - 2, "-");
                    }
                    else
                        if (en.ThuMoi.MaDonTBC != null)
                        {
                            _dontbc = _cDonTBC.Get(en.ThuMoi.MaDonTBC.Value);
                            txtMaDonCu.Text = "TBC" + en.ThuMoi.MaDonTBC.Value.ToString().Insert(en.ThuMoi.MaDonTBC.Value.ToString().Length - 2, "-");
                        }
            txtIDCT.Text = en.IDCT.ToString().Insert(en.IDCT.ToString().Length - 2, "-");
            txtDanhBo.Text = en.DanhBo;
            //txtHopDong.Text = en.HopDong;
            //txtLoTrinh.Text = en.LoTrinh;
            txtHoTen.Text = en.HoTen;
            txtDiaChi.Text = en.DiaChi;
            txtGiaBieu.Text = en.GiaBieu.Value.ToString();
            if (en.DinhMuc != null)
                txtDinhMuc.Text = en.DinhMuc.Value.ToString();
            if (en.DinhMucHN != null)
                txtDinhMucHN.Text = en.DinhMucHN.Value.ToString();
            txtCanCu.Text = en.CanCu;
            if (en.TuNgay != null)
                dateTu.Value = en.TuNgay.Value;
            if (en.DenNgay != null)
                dateDen.Value = en.DenNgay.Value;
            txtVaoLuc.Text = en.VaoLuc;
            txtVeViec.Text = en.VeViec;
            txtLuuy.Text = en.Luuy;
            txtNoiNhan.Text = en.NoiNhan;
            chkCanKhachHangLienHe.Checked = en.CanKhachHangLienHe;

            dgvHinh.Rows.Clear();
            foreach (ThuMoi_ChiTiet_Hinh item in en.ThuMoi_ChiTiet_Hinhs.ToList())
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
            ///
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtLoTrinh.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDinhMucHN.Text = "";
            ///
            //txtCanCu.Text = "Theo biên bản kiểm tra sử dụng nước";
            txtCanCu.Text = "";
            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
            txtVaoLuc.Text = "";
            //txtVeViec.Text = "Thanh toán chi phí (đồng hồ nước) đứt chì góc theo biên bản số";
            txtVeViec.Text = "";
            txtLuuy.Text = "Nếu quá thời hạn trên, Ông (Bà) không đến liên hệ. Công ty Cổ phần Cấp nước Tân Hòa sẽ giải quyết theo quy định: điều chỉnh định mức = 0 và tạm ngưng cung cấp nước.";
            txtNoiNhan.Text = CTaiKhoan.HoTen;
            chkCanKhachHangLienHe.Checked = false;

            dgvDSThu.DataSource = null;
            _dontu_ChiTiet = null;
            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            _thumoi = null;

            dgvHinh.Rows.Clear();

            txtMaDonMoi.Focus();
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
                        dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet("TXL", _dontxl.MaDon);

                        _hoadon = _cThuTien.GetMoiNhat(_dontxl.DanhBo);
                        if (_hoadon != null)
                        {
                            LoadTTKH(_hoadon);
                        }
                        else
                        {
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            //txtDanhBo.Text = _dontxl.DanhBo;
                            //txtHopDong.Text = _dontxl.HopDong;
                            //txtLoTrinh.Text = _dontxl.MLT;
                            //txtHoTen.Text = _dontxl.HoTen;
                            //txtDiaChi.Text = _dontxl.DiaChi;
                            //txtGiaBieu.Text = _dontxl.GiaBieu;
                            //txtDinhMuc.Text = _dontxl.DinhMuc;
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
                            _dontbc = _cDonTBC.Get(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                            txtMaDonCu.Text = "TBC" + _dontbc.MaDon.ToString().Insert(_dontbc.MaDon.ToString().Length - 2, "-");
                            dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet("TBC", _dontbc.MaDon);

                            _hoadon = _cThuTien.GetMoiNhat(_dontbc.DanhBo);
                            if (_hoadon != null)
                            {
                                LoadTTKH(_hoadon);
                            }
                            else
                            {
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                //txtDanhBo.Text = _dontbc.DanhBo;
                                //txtHopDong.Text = _dontbc.HopDong;
                                //txtLoTrinh.Text = _dontbc.MLT;
                                //txtHoTen.Text = _dontbc.HoTen;
                                //txtDiaChi.Text = _dontbc.DiaChi;
                                //txtGiaBieu.Text = _dontbc.GiaBieu;
                                //txtDinhMuc.Text = _dontbc.DinhMuc;
                            }
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
                            dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet("TKH", _dontkh.MaDon);

                            _hoadon = _cThuTien.GetMoiNhat(_dontkh.DanhBo);
                            if (_hoadon != null)
                            {
                                LoadTTKH(_hoadon);
                            }
                            else
                            {
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                //txtDanhBo.Text = _dontkh.DanhBo;
                                //txtHopDong.Text = _dontkh.HopDong;
                                //txtLoTrinh.Text = _dontkh.MLT;
                                //txtHoTen.Text = _dontkh.HoTen;
                                //txtDiaChi.Text = _dontkh.DiaChi;
                                //txtGiaBieu.Text = _dontkh.GiaBieu;
                                //txtDinhMuc.Text = _dontkh.DinhMuc;
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
                    dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet(_dontu_ChiTiet.MaDon.Value,_dontu_ChiTiet.STT.Value);

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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    LinQ.ThuMoi_ChiTiet entity = new LinQ.ThuMoi_ChiTiet();

                    if (_dontu_ChiTiet != null)
                    {
                        if (_cThuMoi.checkExist(_dontu_ChiTiet.MaDon.Value) == false)
                        {
                            LinQ.ThuMoi tm = new LinQ.ThuMoi();
                            tm.MaDonMoi = _dontu_ChiTiet.MaDon;
                            _cThuMoi.them(tm);
                        }
                        if (_cThuMoi.checkExist_ChiTiet(_dontu_ChiTiet.MaDon.Value, txtDanhBo.Text.Trim()) == true)
                        {
                            if (MessageBox.Show("Danh Bộ này đã được Lập Thư\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                return;
                            else
                                entity.Lan = _cThuMoi.maxLan_ChiTiet(_dontu_ChiTiet.MaDon.Value, txtDanhBo.Text.Trim()) + 1;
                        }
                        else
                            entity.Lan = 2;
                        entity.ID = _cThuMoi.get(_dontu_ChiTiet.MaDon.Value).ID;
                        entity.STT = _dontu_ChiTiet.STT.Value;
                    }
                    else
                        if (_dontkh != null)
                        {
                            if (_cThuMoi.checkExist("TKH", _dontkh.MaDon) == false)
                            {
                                LinQ.ThuMoi tm = new LinQ.ThuMoi();
                                tm.MaDonTKH = _dontkh.MaDon;
                                _cThuMoi.them(tm);
                            }
                            if (_cThuMoi.checkExist_ChiTiet("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim()) == true)
                            {
                                if (MessageBox.Show("Danh Bộ này đã được Lập Thư\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    return;
                                else
                                    entity.Lan = _cThuMoi.maxLan_ChiTiet("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim()) + 1;
                            }
                            else
                                entity.Lan = 2;
                            entity.ID = _cThuMoi.get("TKH", _dontkh.MaDon).ID;
                        }
                        else
                            if (_dontxl != null)
                            {
                                if (_cThuMoi.checkExist("TXL", _dontxl.MaDon) == false)
                                {
                                    LinQ.ThuMoi tm = new LinQ.ThuMoi();
                                    tm.MaDonTXL = _dontxl.MaDon;
                                    _cThuMoi.them(tm);
                                }
                                if (_cThuMoi.checkExist_ChiTiet("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim()) == true)
                                {
                                    if (MessageBox.Show("Danh Bộ này đã được Lập Thư\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                        return;
                                    else
                                        entity.Lan = _cThuMoi.maxLan_ChiTiet("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim()) + 1;
                                }
                                else
                                    entity.Lan = 2;
                                entity.ID = _cThuMoi.get("TXL", _dontxl.MaDon).ID;
                            }
                            else
                                if (_dontbc != null)
                                {
                                    if (_cThuMoi.checkExist("TBC", _dontbc.MaDon) == false)
                                    {
                                        LinQ.ThuMoi tm = new LinQ.ThuMoi();
                                        tm.MaDonTBC = _dontbc.MaDon;
                                        _cThuMoi.them(tm);
                                    }
                                    if (_cThuMoi.checkExist_ChiTiet("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim()) == true)
                                    {
                                        if (MessageBox.Show("Danh Bộ này đã được Lập Thư\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                            return;
                                        else
                                            entity.Lan = _cThuMoi.maxLan_ChiTiet("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim()) + 1;
                                    }
                                    else
                                        entity.Lan = 2;
                                    entity.ID = _cThuMoi.get("TBC", _dontbc.MaDon).ID;
                                }
                                else
                                {
                                    MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                    entity.DanhBo = txtDanhBo.Text.Trim();
                    entity.HoTen = txtHoTen.Text.Trim();
                    entity.DiaChi = txtDiaChi.Text.Trim();
                    if (string.IsNullOrEmpty(txtGiaBieu.Text.Trim()) == false)
                        entity.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                    if (string.IsNullOrEmpty(txtDinhMuc.Text.Trim()) == false)
                        entity.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                    if (string.IsNullOrEmpty(txtDinhMucHN.Text.Trim()) == false)
                        entity.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                    if (_hoadon != null)
                    {
                        entity.Nam = _hoadon.NAM;
                        entity.Ky = _hoadon.KY;
                        entity.Dot = _hoadon.DOT;
                        entity.Quan = _hoadon.Quan;
                        entity.Phuong = _hoadon.Phuong;
                    }
                    entity.CanCu = txtCanCu.Text.Trim();
                    entity.TuNgay = dateTu.Value;
                    entity.DenNgay = dateDen.Value;
                    entity.VaoLuc = txtVaoLuc.Text.Trim();
                    entity.VeViec = txtVeViec.Text.Trim();
                    entity.Luuy = txtLuuy.Text.Trim();
                    entity.NoiNhan = txtNoiNhan.Text.Trim();
                    entity.CanKhachHangLienHe = true;

                    using (TransactionScope scope = new TransactionScope())
                        if (_cThuMoi.them_ChiTiet(entity))
                        {
                            foreach (DataGridViewRow item in dgvHinh.Rows)
                            {
                                ThuMoi_ChiTiet_Hinh en = new ThuMoi_ChiTiet_Hinh();
                                en.IDThuMoi_ChiTiet = entity.IDCT;
                                en.Name = item.Cells["Name_Hinh"].Value.ToString();
                                en.Hinh = Convert.FromBase64String(item.Cells["Bytes_Hinh"].Value.ToString());
                                _cThuMoi.Them_Hinh(en);
                            }
                            if (_dontu_ChiTiet != null)
                            {
                                if (_cDonTu.Them_LichSu(entity.CreateDate.Value, "ThuMoi", "Đã Gửi Thư Mời, " + entity.VeViec, entity.IDCT, _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value) == true)
                                    scope.Complete();
                            }
                            else
                                scope.Complete();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
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
                    if (_thumoi != null)
                    {
                        _thumoi.DanhBo = txtDanhBo.Text.Trim();
                        _thumoi.HoTen = txtHoTen.Text.Trim();
                        _thumoi.DiaChi = txtDiaChi.Text.Trim();
                        _thumoi.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if (string.IsNullOrEmpty(txtDinhMuc.Text.Trim()) == false)
                            _thumoi.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        else
                            _thumoi.DinhMuc = null;
                        if (string.IsNullOrEmpty(txtDinhMucHN.Text.Trim()) == false)
                            _thumoi.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                        else
                            _thumoi.DinhMucHN = null;
                        if (_hoadon != null)
                        {
                            _thumoi.Nam = _hoadon.NAM;
                            _thumoi.Ky = _hoadon.KY;
                            _thumoi.Dot = _hoadon.DOT;
                            _thumoi.Quan = _hoadon.Quan;
                            _thumoi.Phuong = _hoadon.Phuong;
                        }
                        _thumoi.CanCu = txtCanCu.Text.Trim();
                        _thumoi.TuNgay = dateTu.Value;
                        _thumoi.DenNgay = dateDen.Value;
                        _thumoi.VaoLuc = txtVaoLuc.Text.Trim();
                        _thumoi.VeViec = txtVeViec.Text.Trim();
                        _thumoi.Luuy = txtLuuy.Text.Trim();
                        _thumoi.NoiNhan = txtNoiNhan.Text.Trim();
                        _thumoi.CanKhachHangLienHe = chkCanKhachHangLienHe.Checked;

                        if (_cThuMoi.sua_ChiTiet(_thumoi))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                    else
                        MessageBox.Show("Chưa chọn thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (_thumoi != null && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var transactionOptions = new TransactionOptions();
                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                        {
                            DonTu_LichSu dtls = _cDonTu.get_LichSu("ThuMoi_ChiTiet", (int)_thumoi.IDCT);
                            if (dtls != null)
                            {
                                _cDonTu.Xoa_LichSu(dtls, true);
                            }
                            if (_cThuMoi.xoa_ChiTiet(_thumoi))
                            {
                                scope.Complete();
                                scope.Dispose();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
                            }
                        }
                    }
                    else
                        MessageBox.Show("Chưa chọn thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (_thumoi != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;
                if (_thumoi.ThuMoi.MaDonMoi != null)
                {
                    if (_thumoi.ThuMoi.DonTu.DonTu_ChiTiets.Count == 1)
                        dr["SoPhieu"] = _thumoi.ThuMoi.MaDonMoi.ToString();
                    else
                        dr["SoPhieu"] = _thumoi.ThuMoi.MaDonMoi.ToString() + "." + _thumoi.STT;
                }
                else
                    if (_thumoi.ThuMoi.MaDonTKH != null)
                        dr["SoPhieu"] = "TKH" + _thumoi.ThuMoi.MaDonTKH.ToString().Insert(_thumoi.ThuMoi.MaDonTKH.ToString().Length - 2, "-");
                    else
                        if (_thumoi.ThuMoi.MaDonTXL != null)
                            dr["SoPhieu"] = "TXL" + _thumoi.ThuMoi.MaDonTXL.ToString().Insert(_thumoi.ThuMoi.MaDonTXL.ToString().Length - 2, "-");
                        else
                            if (_thumoi.ThuMoi.MaDonTBC != null)
                                dr["SoPhieu"] = "TBC" + _thumoi.ThuMoi.MaDonTBC.ToString().Insert(_thumoi.ThuMoi.MaDonTBC.ToString().Length - 2, "-");

                dr["HoTen"] = _thumoi.HoTen;
                dr["DiaChi"] = _thumoi.DiaChi;
                if (!string.IsNullOrEmpty(_thumoi.DanhBo) && _thumoi.DanhBo.Length == 11)
                    dr["DanhBo"] = _thumoi.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["GiaBieu"] = _thumoi.GiaBieu.Value.ToString();
                if (_thumoi.DinhMuc != null)
                    dr["DinhMuc"] = _thumoi.DinhMuc.Value.ToString();
                if (_thumoi.DinhMucHN != null)
                    dr["DinhMucHN"] = _thumoi.DinhMucHN.Value.ToString();
                dr["CanCu"] = _thumoi.CanCu;
                dr["VaoLuc"] = _thumoi.VaoLuc;
                dr["VeViec"] = _thumoi.VeViec;
                dr["Lan"] = _thumoi.Lan;
                dr["Luuy"] = _thumoi.Luuy;
                dr["NoiNhan"] = _thumoi.NoiNhan + "(" + _thumoi.IDCT + ")";
                dr["TenPhong"] = CTaiKhoan.TenPhong;
                dr["NguoiKy"] = CTaiKhoan.NguoiKy;

                dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(drLogo);

                ReportDocument rpt = new ReportDocument();
                if (radDutChi.Checked == true)
                    rpt = new rptThuMoiDutChi();
                else
                    if (radCDDM.Checked == true)
                        rpt = new rptThuMoiChuyenDe();
                    else
                        if (radRong.Checked == true)
                            rpt = new rptThuMoiChuyenDe_Rong();
                rpt.SetDataSource(dsBaoCao);
                rpt.Subreports[0].SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }
            else
                MessageBox.Show("Chưa chọn thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvDSThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _thumoi = _cThuMoi.get_ChiTiet(int.Parse(dgvDSThu.CurrentRow.Cells["IDCT"].Value.ToString()));
                LoadEntity(_thumoi);
            }
            catch (Exception)
            {

                throw;
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
                {
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtIDCT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtIDCT.Text.Trim() != "")
            {
                string MaDon = txtIDCT.Text.Trim();
                Clear();
                txtIDCT.Text = MaDon;
                _thumoi = _cThuMoi.get_ChiTiet(int.Parse(txtIDCT.Text.Trim().Replace("-", "")));
                if (_thumoi != null)
                    LoadEntity(_thumoi);
                else
                    MessageBox.Show("Mã này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmThaoThuMoi_KeyUp(object sender, KeyEventArgs e)
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
                    if (_thumoi == null)
                    {
                        var index = dgvHinh.Rows.Add();
                        dgvHinh.Rows[index].Cells["Name_Hinh"].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(bytes);
                    }
                    else
                    {
                        if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                        {
                            ThuMoi_ChiTiet_Hinh en = new ThuMoi_ChiTiet_Hinh();
                            en.IDThuMoi_ChiTiet = _thumoi.IDCT;
                            en.Name = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            en.Hinh = bytes;
                            if (_cThuMoi.Them_Hinh(en) == true)
                            {
                                _cThuMoi.Refresh();
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
            _cThuMoi.LoadImageView(Convert.FromBase64String(dgvHinh.CurrentRow.Cells["Bytes_Hinh"].Value.ToString()));
        }

        private void xoaFile_dgvHinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (_thumoi == null)
                    dgvHinh.Rows.RemoveAt(dgvHinh.CurrentRow.Index);
                else
                    if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (dgvHinh.CurrentRow.Cells["ID_Hinh"].Value != null)
                                if (_cThuMoi.Xoa_Hinh(_cThuMoi.get_Hinh(int.Parse(dgvHinh.CurrentRow.Cells["ID_Hinh"].Value.ToString()))))
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

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            txtVaoLuc.Text = "9 giờ 00 từ ngày " + dateTu.Value.ToString("dd/MM/yyyy") + " đến ngày " + dateDen.Value.ToString("dd/MM/yyyy");
        }

    }
}

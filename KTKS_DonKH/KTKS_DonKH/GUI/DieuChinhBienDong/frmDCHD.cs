﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDCHD : Form
    {
        string _mnu = "mnuDCHD";
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        HOADON _hoadon = null;
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDCBD _cDCBD = new CDCBD();
        CKTXM _cKTXM = new CKTXM();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CDocSo _cDocSo = new CDocSo();
        CThuTien _cThuTien = new CThuTien();
        int _TieuThu_DieuChinhGia = 0;
        List<GiaNuoc> lstGiaNuoc;

        public frmDCHD()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            txtSoVB.Text = "";
            dateNgayKy.Value = DateTime.Now;
            txtKyHD.Text = "";
            txtSoHD.Text = "";
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            ///
            txtGiaBieu_Cu.Text = "0";
            txtDinhMuc_Cu.Text = "0";
            txtTieuThu_Cu.Text = "0";
            txtChiTietCu.Text = "";
            chkDieuChinhGia.Checked = false;
            ///
            txtGiaBieu_Moi.Text = "0";
            txtDinhMuc_Moi.Text = "0";
            txtTieuThu_Moi.Text = "0";
            txtChiTietMoi.Text = "";
            _donkh = null;
            _dontxl = null;
            _hoadon = null;
            ///
            chkDieuChinhGia2.Checked = false;
            chkTyLe.Checked = false;
        }

        private void frmDCHDN_Load(object sender, EventArgs e)
        {
            lstGiaNuoc = _cGiaNuoc.LoadDSGiaNuoc();
            dgvLichSu.AutoGenerateColumns = false;
            this.KeyPreview = true;
            //if (_direct)
            //{
            //}
            //else
            //{
            //    this.Location = new Point(70, 70);
            //    if (_cDonKH.getDonKHbyID(decimal.Parse(_source["MaDon"])) != null)
            //    {
            //        _donkh = _cDonKH.getDonKHbyID(decimal.Parse(_source["MaDon"]));
            //        txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
            //    }
            //    if (_cThuTien.GetMoiNhat(_source["DanhBo"]) != null)
            //    {
            //        _hoadon = _cThuTien.GetMoiNhat(_source["DanhBo"]);
            //        txtDanhBo.Text = _hoadon.DANHBA;
            //        txtHoTen.Text = _hoadon.TENKH;
            //        txtGiaBieu_Cu.Text = txtGiaBieu_Moi.Text = _hoadon.GB.ToString();
            //        txtDinhMuc_Cu.Text = txtDinhMuc_Moi.Text = _hoadon.DM.ToString();
            //    }
            //}
        }

        private void frmDCHDN_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void txtGiaBieu_Cu_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaBieu_Cu.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtTieuThu_Cu_TextChanged(object sender, EventArgs e)
        {
            if (txtTieuThu_Cu.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtDinhMuc_Cu_TextChanged(object sender, EventArgs e)
        {
            if (txtDinhMuc_Cu.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void chkGiaDieuChinh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDieuChinhGia.Checked)
            {
                txtGiaDieuChinh.ReadOnly = false;
                //TinhTienNuoc();
            }
            else
            {
                txtGiaDieuChinh.Text = "0";
                txtGiaDieuChinh.ReadOnly = true;
                //TinhTienNuoc();
            }
        }

        private void txtGiaDieuChinh_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaDieuChinh.Text.Trim() != "")
            {
                TinhTienNuoc();
            }
        }

        private void txtGiaBieu_Moi_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaBieu_Moi.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtDinhMuc_Moi_TextChanged(object sender, EventArgs e)
        {
            if (txtDinhMuc_Moi.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtTieuThu_Moi_TextChanged(object sender, EventArgs e)
        {
            if (txtTieuThu_Moi.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void TinhTienNuoc()
        {
            string ChiTietCu = "";
            string ChiTietMoi = "";
            int TieuThu_DieuChinhGia = 0;
            int TongTienCu = 0;
            int TongTienMoi = 0;
            TongTienCu = _cGiaNuoc.TinhTienNuoc(false, int.Parse(txtGiaDieuChinh.Text.Trim()), txtDanhBo.Text.Trim(), int.Parse(txtGiaBieu_Cu.Text.Trim()), int.Parse(txtDinhMuc_Cu.Text.Trim()), int.Parse(txtTieuThu_Cu.Text.Trim()), out ChiTietCu, out TieuThu_DieuChinhGia);
            if (chkDieuChinhGia2.Checked)
            {
                TongTienMoi = _cGiaNuoc.TinhTienNuoc(chkDieuChinhGia.Checked, int.Parse(txtGiaDieuChinh.Text.Trim()), txtDanhBo.Text.Trim(), int.Parse(txtGiaBieu_Moi.Text.Trim()), int.Parse(txtDinhMuc_Moi.Text.Trim()), int.Parse(txtTieuThu_Moi.Text.Trim()) - int.Parse(txtTieuThu_DieuChinhGia2.Text.Trim()), int.Parse(txtTieuThu_DieuChinhGia2.Text.Trim()), int.Parse(txtGiaDieuChinh2.Text.Trim()), out ChiTietMoi);
            }
            else
                if (chkTyLe.Checked)
                {
                    TongTienMoi = _cGiaNuoc.TinhTienNuoc(chkDieuChinhGia.Checked, int.Parse(txtGiaDieuChinh.Text.Trim()), txtDanhBo.Text.Trim(), int.Parse(txtGiaBieu_Moi.Text.Trim()), int.Parse(txtDinhMuc_Moi.Text.Trim()), int.Parse(txtTieuThu_Moi.Text.Trim()), int.Parse(txtSH.Text.Trim()), int.Parse(txtSX.Text.Trim()), int.Parse(txtDV.Text.Trim()), int.Parse(txtHCSN.Text.Trim()), out ChiTietMoi);
                }
                else
                {
                    TongTienMoi = _cGiaNuoc.TinhTienNuoc(chkDieuChinhGia.Checked, int.Parse(txtGiaDieuChinh.Text.Trim()), txtDanhBo.Text.Trim(), int.Parse(txtGiaBieu_Moi.Text.Trim()), int.Parse(txtDinhMuc_Moi.Text.Trim()), int.Parse(txtTieuThu_Moi.Text.Trim()), out ChiTietMoi, out _TieuThu_DieuChinhGia);
                }
            ///Chi Tiết
            txtChiTietCu.Text = ChiTietCu;
            txtChiTietMoi.Text = ChiTietMoi;
            ///Tiêu Thụ
            txtTieuThu_Start.Text = txtTieuThu_Cu.Text.Trim();
            txtTieuThu_BD.Text = (int.Parse(txtTieuThu_Moi.Text.Trim()) - int.Parse(txtTieuThu_Cu.Text.Trim())).ToString();
            txtTieuThu_End.Text = txtTieuThu_Moi.Text.Trim();
            ///Tiền Nước
            if (TongTienCu != 0)
                txtTienNuoc_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongTienCu);
            else
                txtTienNuoc_Start.Text = "0";

            if (TongTienMoi - TongTienCu != 0)
                txtTienNuoc_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongTienMoi - TongTienCu);
            else
                txtTienNuoc_BD.Text = "0";

            if (TongTienMoi != 0)
                txtTienNuoc_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongTienMoi);
            else
                txtTienNuoc_End.Text = "0";

            ///Thuế GTGT
            if (TongTienCu != 0)
                txtThueGTGT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", Math.Round((double)TongTienCu * 5 / 100 + 0.1));
            else
                txtThueGTGT_Start.Text = "0";

            if (TongTienMoi - TongTienCu != 0)
                txtThueGTGT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (Math.Round((double)TongTienMoi * 5 / 100 + 0.1) - Math.Round((double)TongTienCu * 5 / 100 + 0.1)));
            else
                txtThueGTGT_BD.Text = "0";

            if (TongTienMoi != 0)
                txtThueGTGT_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", Math.Round((double)TongTienMoi * 5 / 100 + 0.1));
            else
                txtThueGTGT_End.Text = "0";

            ///Phí BVMT
            if (TongTienCu != 0)
                txtPhiBVMT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (TongTienCu * 10 / 100));
            else
                txtPhiBVMT_Start.Text = "0";

            if (TongTienMoi - TongTienCu != 0)
                txtPhiBVMT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ((TongTienMoi * 10 / 100) - (TongTienCu * 10 / 100)));
            else
                txtPhiBVMT_BD.Text = "0";

            if (TongTienMoi != 0)
                txtPhiBVMT_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (TongTienMoi * 10 / 100));
            else
                txtPhiBVMT_End.Text = "0";

            ///Tổng Cộng
            if (TongTienCu != 0)
                txtTongCong_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (TongTienCu + Math.Round((double)TongTienCu * 5 / 100 + 0.1) + (TongTienCu * 10 / 100)));
            else
                txtTongCong_Start.Text = "0";

            if (TongTienMoi - TongTienCu != 0)
                txtTongCong_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ((TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100 + 0.1) + (TongTienMoi * 10 / 100)) - (TongTienCu + Math.Round((double)TongTienCu * 5 / 100 + 0.1) + (TongTienCu * 10 / 100))));
            else
                txtTongCong_BD.Text = "0";

            if (TongTienMoi != 0)
                txtTongCong_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100 + 0.1) + (TongTienMoi * 10 / 100)));
            else
                txtTongCong_End.Text = "0";

            ///
            if (TongTienMoi - TongTienCu == 0)
                lbTangGiam.Text = "";
            else
                if (TongTienMoi - TongTienCu > 0)
                    lbTangGiam.Text = "Tăng:";
                else
                    lbTangGiam.Text = "Giảm:";
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
                        if (_dontxl != null && txtDanhBo.Text.Trim() != "" && txtKyHD.Text.Trim() != "" && txtSoHD.Text.Trim() != "")
                        {
                            if (!_cDCBD.CheckDCBDbyMaDon_TXL(_dontxl.MaDon))
                            {
                                DCBD dcbd = new DCBD();
                                dcbd.ToXuLy = true;
                                dcbd.MaDonTXL = _dontxl.MaDon;
                                if (_cDCBD.ThemDCBD(dcbd))
                                {
                                    _dontxl.DaGiaiQuyet = true;
                                }
                            }
                            if (_cDCBD.CheckCTDCHDbyMaDonDanhBo_TXL(_dontxl.MaDon, txtDanhBo.Text.Trim(),txtKyHD.Text.Trim()))
                            {
                                MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            CTDCHD ctdchd = new CTDCHD();
                            ctdchd.MaDCBD = _cDCBD.getDCBDbyMaDon_TXL(_dontxl.MaDon).MaDCBD;
                            ctdchd.DanhBo = txtDanhBo.Text.Trim();
                            ctdchd.HoTen = txtHoTen.Text.Trim();
                            ctdchd.DiaChi = txtDiaChi.Text.Trim();
                            //ctdchd.SoVB = txtSoVB.Text.Trim();
                            ctdchd.NgayKy = dateNgayKy.Value;

                            ctdchd.KyHD = txtKyHD.Text.Trim();
                            string[] KyHD = txtKyHD.Text.Trim().Split('/');
                            ctdchd.Ky = int.Parse(KyHD[0]);
                            ctdchd.Nam = int.Parse(KyHD[1]);

                            ctdchd.SoHD = txtSoHD.Text.Trim();
                            ///
                            ctdchd.GiaBieu = int.Parse(txtGiaBieu_Cu.Text.Trim().Replace(".", ""));
                            ctdchd.DinhMuc = int.Parse(txtDinhMuc_Cu.Text.Trim().Replace(".", ""));
                            ctdchd.TieuThu = int.Parse(txtTieuThu_Cu.Text.Trim().Replace(".", ""));
                            ///
                            ctdchd.GiaBieu_BD = int.Parse(txtGiaBieu_Moi.Text.Trim().Replace(".", ""));
                            ctdchd.DinhMuc_BD = int.Parse(txtDinhMuc_Moi.Text.Trim().Replace(".", ""));
                            ctdchd.TieuThu_BD = int.Parse(txtTieuThu_Moi.Text.Trim().Replace(".", ""));
                            ///
                            ctdchd.TienNuoc_Start = int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", ""));
                            ctdchd.ThueGTGT_Start = int.Parse(txtThueGTGT_Start.Text.Trim().Replace(".", ""));
                            ctdchd.PhiBVMT_Start = int.Parse(txtPhiBVMT_Start.Text.Trim().Replace(".", ""));
                            ctdchd.TongCong_Start = int.Parse(txtTongCong_Start.Text.Trim().Replace(".", ""));
                            ctdchd.ChiTietCu = txtChiTietCu.Text.Trim();
                            ///
                            if (chkDieuChinhGia.Checked)
                            {
                                ctdchd.DieuChinhGia = true;
                                ctdchd.TieuThu_DieuChinhGia = _TieuThu_DieuChinhGia;
                                ctdchd.GiaDieuChinh = int.Parse(txtGiaDieuChinh.Text.Trim().Replace(".", ""));
                            }
                            ///
                            if (chkKhauTru.Checked)
                            {
                                ctdchd.KhauTru = true;
                                ctdchd.SoTienKhauTru = int.Parse(txtSoTienKhauTru.Text.Trim().Replace(".", ""));
                            }
                            ///
                            if (chkDieuChinhGia2.Checked)
                            {
                                ctdchd.DieuChinhGia2 = true;
                                ctdchd.TieuThu_DieuChinhGia2 = int.Parse(txtTieuThu_DieuChinhGia2.Text.Trim().Replace(".", ""));
                                ctdchd.GiaDieuChinh2 = int.Parse(txtGiaDieuChinh2.Text.Trim().Replace(".", ""));
                            }
                            ///
                            if (chkTyLe.Checked)
                            {
                                ctdchd.TyLe = true;
                                ctdchd.SH = int.Parse(txtSH.Text.Trim().Replace(".", ""));
                                ctdchd.SX = int.Parse(txtSX.Text.Trim().Replace(".", ""));
                                ctdchd.DV = int.Parse(txtDV.Text.Trim().Replace(".", ""));
                                ctdchd.HCSN = int.Parse(txtHCSN.Text.Trim().Replace(".", ""));
                            }
                            ctdchd.TienNuoc_BD = int.Parse(txtTienNuoc_BD.Text.Trim().Replace(".", ""));
                            ctdchd.ThueGTGT_BD = int.Parse(txtThueGTGT_BD.Text.Trim().Replace(".", ""));
                            ctdchd.PhiBVMT_BD = int.Parse(txtPhiBVMT_BD.Text.Trim().Replace(".", ""));
                            ctdchd.TongCong_BD = int.Parse(txtTongCong_BD.Text.Trim().Replace(".", ""));
                            ///
                            ctdchd.TienNuoc_End = int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", ""));
                            ctdchd.ThueGTGT_End = int.Parse(txtThueGTGT_End.Text.Trim().Replace(".", ""));
                            ctdchd.PhiBVMT_End = int.Parse(txtPhiBVMT_End.Text.Trim().Replace(".", ""));
                            ctdchd.TongCong_End = int.Parse(txtTongCong_End.Text.Trim().Replace(".", ""));
                            ctdchd.ChiTietMoi = txtChiTietMoi.Text.Trim();

                            if (ctdchd.TienNuoc_End - ctdchd.TienNuoc_Start == 0)
                                ctdchd.TangGiam = "";
                            else
                                if (ctdchd.TienNuoc_End - ctdchd.TienNuoc_Start > 0)
                                    ctdchd.TangGiam = "Tăng";
                                else
                                    ctdchd.TangGiam = "Giảm";

                            ///Ký Tên
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctdchd.ChucVu = "GIÁM ĐỐC";
                            else
                                ctdchd.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctdchd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            ctdchd.PhieuDuocKy = true;

                            if (_cDCBD.ThemCTDCHD(ctdchd))
                            {
                                Clear();
                                MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtMaDon.Focus();
                            }
                        }
                        else
                            MessageBox.Show("Chưa có Mã Đơn/Danh Bộ/Số Văn Bản/Kỳ Hóa Đơn/Số Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ///Nếu đơn thuộc Tổ Khách Hàng
                    else
                        if (_donkh != null && txtDanhBo.Text.Trim() != "" && txtKyHD.Text.Trim() != "" && txtSoHD.Text.Trim() != "")
                        {
                            if (!_cDCBD.CheckDCBDbyMaDon(_donkh.MaDon))
                            {
                                DCBD dcbd = new DCBD();
                                dcbd.MaDon = _donkh.MaDon;
                                if (_cDCBD.ThemDCBD(dcbd))
                                {
                                    _donkh.DaGiaiQuyet = true;
                                }
                            }
                            if (_cDCBD.CheckCTDCHDbyMaDonDanhBo(_donkh.MaDon, txtDanhBo.Text.Trim(), txtKyHD.Text.Trim()))
                            {
                                MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            CTDCHD ctdchd = new CTDCHD();
                            ctdchd.MaDCBD = _cDCBD.getDCBDbyMaDon(_donkh.MaDon).MaDCBD;
                            ctdchd.DanhBo = txtDanhBo.Text.Trim();
                            ctdchd.HoTen = txtHoTen.Text.Trim();
                            ctdchd.DiaChi = txtDiaChi.Text.Trim();
                            //ctdchd.SoVB = txtSoVB.Text.Trim();
                            ctdchd.NgayKy = dateNgayKy.Value;

                            ctdchd.KyHD = txtKyHD.Text.Trim();
                            string[] KyHD = txtKyHD.Text.Trim().Split('/');
                            ctdchd.Ky = int.Parse(KyHD[0]);
                            ctdchd.Nam = int.Parse(KyHD[1]);

                            ctdchd.SoHD = txtSoHD.Text.Trim();
                            ///
                            ctdchd.GiaBieu = int.Parse(txtGiaBieu_Cu.Text.Trim().Replace(".", ""));
                            ctdchd.DinhMuc = int.Parse(txtDinhMuc_Cu.Text.Trim().Replace(".", ""));
                            ctdchd.TieuThu = int.Parse(txtTieuThu_Cu.Text.Trim().Replace(".", ""));
                            ///
                            ctdchd.GiaBieu_BD = int.Parse(txtGiaBieu_Moi.Text.Trim().Replace(".", ""));
                            ctdchd.DinhMuc_BD = int.Parse(txtDinhMuc_Moi.Text.Trim().Replace(".", ""));
                            ctdchd.TieuThu_BD = int.Parse(txtTieuThu_Moi.Text.Trim().Replace(".", ""));
                            ///
                            ctdchd.TienNuoc_Start = int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", ""));
                            ctdchd.ThueGTGT_Start = int.Parse(txtThueGTGT_Start.Text.Trim().Replace(".", ""));
                            ctdchd.PhiBVMT_Start = int.Parse(txtPhiBVMT_Start.Text.Trim().Replace(".", ""));
                            ctdchd.TongCong_Start = int.Parse(txtTongCong_Start.Text.Trim().Replace(".", ""));
                            ctdchd.ChiTietCu = txtChiTietCu.Text.Trim();
                            ///
                            if (chkDieuChinhGia.Checked)
                            {
                                ctdchd.DieuChinhGia = true;
                                ctdchd.TieuThu_DieuChinhGia = _TieuThu_DieuChinhGia;
                                ctdchd.GiaDieuChinh = int.Parse(txtGiaDieuChinh.Text.Trim().Replace(".", ""));
                            }
                            ///
                            if (chkKhauTru.Checked)
                            {
                                ctdchd.KhauTru = true;
                                ctdchd.SoTienKhauTru = int.Parse(txtSoTienKhauTru.Text.Trim().Replace(".", ""));
                            }
                            ///
                            if (chkDieuChinhGia2.Checked)
                            {
                                ctdchd.DieuChinhGia2 = true;
                                ctdchd.TieuThu_DieuChinhGia2 = int.Parse(txtTieuThu_DieuChinhGia2.Text.Trim().Replace(".", ""));
                                ctdchd.GiaDieuChinh2 = int.Parse(txtGiaDieuChinh2.Text.Trim().Replace(".", ""));
                            }
                            ///
                            if (chkTyLe.Checked)
                            {
                                ctdchd.TyLe = true;
                                ctdchd.SH = int.Parse(txtSH.Text.Trim().Replace(".", ""));
                                ctdchd.SX = int.Parse(txtSX.Text.Trim().Replace(".", ""));
                                ctdchd.DV = int.Parse(txtDV.Text.Trim().Replace(".", ""));
                                ctdchd.HCSN = int.Parse(txtHCSN.Text.Trim().Replace(".", ""));
                            }
                            ///
                            ctdchd.TienNuoc_BD = int.Parse(txtTienNuoc_BD.Text.Trim().Replace(".", ""));
                            ctdchd.ThueGTGT_BD = int.Parse(txtThueGTGT_BD.Text.Trim().Replace(".", ""));
                            ctdchd.PhiBVMT_BD = int.Parse(txtPhiBVMT_BD.Text.Trim().Replace(".", ""));
                            ctdchd.TongCong_BD = int.Parse(txtTongCong_BD.Text.Trim().Replace(".", ""));
                            ///
                            ctdchd.TienNuoc_End = int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", ""));
                            ctdchd.ThueGTGT_End = int.Parse(txtThueGTGT_End.Text.Trim().Replace(".", ""));
                            ctdchd.PhiBVMT_End = int.Parse(txtPhiBVMT_End.Text.Trim().Replace(".", ""));
                            ctdchd.TongCong_End = int.Parse(txtTongCong_End.Text.Trim().Replace(".", ""));
                            ctdchd.ChiTietMoi = txtChiTietMoi.Text.Trim();

                            if (ctdchd.TienNuoc_End - ctdchd.TienNuoc_Start == 0)
                                ctdchd.TangGiam = "";
                            else
                                if (ctdchd.TienNuoc_End - ctdchd.TienNuoc_Start > 0)
                                    ctdchd.TangGiam = "Tăng";
                                else
                                    ctdchd.TangGiam = "Giảm";

                            ///Ký Tên
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctdchd.ChucVu = "GIÁM ĐỐC";
                            else
                                ctdchd.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctdchd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            ctdchd.PhieuDuocKy = true;

                            if (_cDCBD.ThemCTDCHD(ctdchd))
                            {
                                Clear();
                                MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtMaDon.Focus();
                            }
                        }
                        else
                            MessageBox.Show("Chưa có Mã Đơn/Danh Bộ/Số Văn Bản/Kỳ Hóa Đơn/Số Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (_cThuTien.GetMoiNhat(_dontxl.DanhBo) != null)
                        {
                            _hoadon = _cThuTien.GetMoiNhat(_dontxl.DanhBo);

                            txtDanhBo.Text = _hoadon.DANHBA;
                            txtHoTen.Text = _hoadon.TENKH;
                            txtDiaChi.Text = _hoadon.SO + " " + _hoadon.DUONG + _cDocSo.getPhuongQuanByID(_hoadon.Quan, _hoadon.Phuong);
                            if (_hoadon.GB != null)
                                txtGiaBieu_Cu.Text = txtGiaBieu_Moi.Text = _hoadon.GB.ToString();
                            else
                                txtGiaBieu_Cu.Text = txtGiaBieu_Moi.Text = "0";
                            if (_hoadon.DM != null)
                                txtDinhMuc_Cu.Text = txtDinhMuc_Moi.Text = _hoadon.DM.ToString();
                            else
                                txtDinhMuc_Cu.Text = txtDinhMuc_Moi.Text = "0";
                            dateNgayKy.Focus();
                        }
                        else
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        _dontxl = null;
                        MessageBox.Show("Mã Đơn TXL này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

                            txtDanhBo.Text = _hoadon.DANHBA;
                            txtHoTen.Text = _hoadon.TENKH;
                            txtDiaChi.Text = _hoadon.SO + " " + _hoadon.DUONG + _cDocSo.getPhuongQuanByID(_hoadon.Quan, _hoadon.Phuong);
                            if (_hoadon.GB != null)
                                txtGiaBieu_Cu.Text = txtGiaBieu_Moi.Text = _hoadon.GB.ToString();
                            else
                                txtGiaBieu_Cu.Text = txtGiaBieu_Moi.Text = "0";
                            if (_hoadon.DM != null)
                                txtDinhMuc_Cu.Text = txtDinhMuc_Moi.Text = _hoadon.DM.ToString();
                            else
                                txtDinhMuc_Cu.Text = txtDinhMuc_Moi.Text = "0";
                            dateNgayKy.Focus();
                        }
                        else
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        _donkh = null;
                        MessageBox.Show("Mã Đơn KH này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

            }
        }

        #region Configure TextBox

        private void txtGiaBieu_Cu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDinhMuc_Cu.Focus();
        }

        private void txtDinhMuc_Cu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtTieuThu_Cu.Focus();
        }

        private void txtTieuThu_Cu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                chkDieuChinhGia.Focus();
        }

        private void chkGiaDieuChinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGiaDieuChinh.Focus();
        }

        private void txtGiaDieuChinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGiaBieu_Moi.Focus();
        }

        private void txtGiaBieu_Moi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDinhMuc_Moi.Focus();
        }

        private void txtDinhMuc_Moi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtTieuThu_Moi.Focus();
        }

        private void txtTieuThu_Moi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnThem.Focus();
        }

        private void dateNgayKy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtKyHD.Focus();
        }

        private void txtKyHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtSoHD.Focus();
        }

        private void txtSoHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGiaBieu_Cu.Focus();
        }

        #endregion

        private void frmDCHD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Add)
                btnThem.PerformClick();
        }

        private void chkKhauTru_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKhauTru.Checked)
            {
                txtSoTienKhauTru.ReadOnly = false;
                //TinhTienNuoc();
            }
            else
            {
                txtSoTienKhauTru.Text = "0";
                txtSoTienKhauTru.ReadOnly = true;
                //TinhTienNuoc();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();

                dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " "); ;
                dr["HoTen"] = txtHoTen.Text.Trim();
                dr["DiaChi"] = txtDiaChi.Text.Trim();
                ///
                dr["GiaBieuStart"] = txtGiaBieu_Cu.Text.Trim();
                dr["DinhMucStart"] = txtDinhMuc_Cu.Text.Trim();
                dr["TieuThuStart"] = txtTieuThu_Start.Text.Trim();
                dr["TienNuocStart"] = txtChiTietCu.Text.Trim() + "\n=  " + txtTienNuoc_Start.Text.Trim();
                dr["ThueGTGTStart"] = txtTienNuoc_Start.Text.Trim() + " x 5% \n=  " + txtThueGTGT_Start.Text.Trim();
                dr["PhiBVMTStart"] = txtTienNuoc_Start.Text.Trim() + " x 10% \n=  " + txtPhiBVMT_Start.Text.Trim();
                dr["TongCongStart"] = txtTongCong_Start.Text.Trim();
                ///
                dr["TangGiam"] = lbTangGiam.Text;
                ///
                //dr["GiaBieuBD"] = int.Parse(txtGiaBieu_Moi.Text.Trim()) - int.Parse(txtGiaBieu_Cu.Text.Trim());
                dr["DinhMucBD"] = int.Parse(txtDinhMuc_Moi.Text.Trim()) - int.Parse(txtDinhMuc_Cu.Text.Trim());
                dr["TieuThuBD"] = txtTieuThu_BD.Text.Trim();
                dr["TienNuocBD"] = txtTienNuoc_BD.Text.Trim();
                dr["ThueGTGTBD"] = txtThueGTGT_BD.Text.Trim();
                dr["PhiBVMTBD"] = txtPhiBVMT_BD.Text.Trim();
                dr["TongCongBD"] = txtTongCong_BD.Text.Trim();
                ///
                dr["GiaBieuEnd"] = txtGiaBieu_Moi.Text.Trim();
                dr["DinhMucEnd"] = txtDinhMuc_Moi.Text.Trim();
                dr["TieuThuEnd"] = txtTieuThu_End.Text.Trim();
                if (!string.IsNullOrEmpty(txtTienNuoc_End.Text.Trim()))
                    dr["TienNuocEnd"] = txtChiTietMoi.Text.Trim() + "\n=  " + txtTienNuoc_End.Text.Trim();
                if (!string.IsNullOrEmpty(txtThueGTGT_End.Text.Trim()))
                    dr["ThueGTGTEnd"] = txtTienNuoc_End.Text.Trim() + " x 5% \n=  " + txtThueGTGT_End.Text.Trim();
                if (!string.IsNullOrEmpty(txtPhiBVMT_End.Text.Trim()))
                    dr["PhiBVMTEnd"] = txtTienNuoc_End.Text.Trim() + " x 10% \n=  " + txtPhiBVMT_End.Text.Trim();
                if (!string.IsNullOrEmpty(txtTongCong_End.Text.Trim()))
                    dr["TongCongEnd"] = txtTongCong_End.Text.Trim();
                ///
                if (txtSH.Text.Trim() != "0")
                    dr["SH"] = "SH: " + txtSH.Text.Trim();
                if (txtSX.Text.Trim() != "0")
                    dr["SX"] = "SX: " + txtSX.Text.Trim();
                if (txtDV.Text.Trim() != "0")
                    dr["DV"] = "DV: " + txtDV.Text.Trim();
                if (txtHCSN.Text.Trim() != "0")
                    dr["HCSN"] = "HCSN: " + txtHCSN.Text.Trim();
                dsBaoCao.Tables["DCHD"].Rows.Add(dr);

                rptChiTietDCHD rpt = new rptChiTietDCHD();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

        private void chkGiaDieuChinh2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDieuChinhGia2.Checked)
            {
                chkTyLe.Checked = false;
                txtTieuThu_DieuChinhGia2.ReadOnly = false;
                txtGiaDieuChinh2.ReadOnly = false;
            }
            else
            {
                txtTieuThu_DieuChinhGia2.Text = "0";
                txtTieuThu_DieuChinhGia2.ReadOnly = true;
                txtGiaDieuChinh2.Text = "0";
                txtGiaDieuChinh2.ReadOnly = true;
            }
        }

        private void chkTyLe_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTyLe.Checked)
            {
                chkDieuChinhGia2.Checked = false;
                txtSH.ReadOnly = false;
                txtSX.ReadOnly = false;
                txtDV.ReadOnly = false;
                txtHCSN.ReadOnly = false;
            }
            else
            {
                txtSH.Text = "0";
                txtSH.ReadOnly = true;
                txtSX.Text = "0";
                txtSX.ReadOnly = true;
                txtDV.Text = "0";
                txtDV.ReadOnly = true;
                txtHCSN.Text = "0";
                txtHCSN.ReadOnly = true;
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Length == 11)
            {
                HOADON hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());

                txtDanhBo.Text = hoadon.DANHBA;
                txtHoTen.Text = hoadon.TENKH;
                txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.getPhuongQuanByID(hoadon.Quan, hoadon.Phuong);
                if (hoadon.GB != null)
                    txtGiaBieu_Cu.Text = txtGiaBieu_Moi.Text = hoadon.GB.ToString();
                else
                    txtGiaBieu_Cu.Text = txtGiaBieu_Moi.Text = "0";
                if (hoadon.DM != null)
                    txtDinhMuc_Cu.Text = txtDinhMuc_Moi.Text = hoadon.DM.ToString();
                else
                    txtDinhMuc_Cu.Text = txtDinhMuc_Moi.Text = "0";
            }
        }

        private void txtTieuThu_GiaDieuChinh2_TextChanged(object sender, EventArgs e)
        {
            if (txtTieuThu_DieuChinhGia2.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtGiaTien_GiaDieuChinh2_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaDieuChinh2.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtSH_TextChanged(object sender, EventArgs e)
        {
            if (txtSH.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtSX_TextChanged(object sender, EventArgs e)
        {
            if (txtSX.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtDV_TextChanged(object sender, EventArgs e)
        {
            if (txtDV.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtHCSN_TextChanged(object sender, EventArgs e)
        {
            if (txtHCSN.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void btnInA4_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();

            dr["SoPhieu"] = "";
            dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " "); ;
            dr["HoTen"] = txtHoTen.Text.Trim();
            dr["DiaChi"] = txtDiaChi.Text.Trim();
            dr["SoDon"] = txtMaDon.Text.Trim();
            dr["NgayKy"] = dateNgayKy.Value.ToString("dd/MM/yyyy");
            dr["KyHD"] = txtKyHD.Text.Trim();
            dr["SoHD"] = txtSoHD.Text.Trim();
            ///
            dr["DieuChinh"] = "";
            if (txtGiaBieu_Cu.Text.Trim() != txtGiaBieu_Moi.Text.Trim())
                dr["DieuChinh"] = "Giá Biểu từ " + txtGiaBieu_Cu.Text.Trim() + " -> " + txtGiaBieu_Moi.Text.Trim();
            if (txtDinhMuc_Cu.Text.Trim() != txtDinhMuc_Moi.Text.Trim())
                if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                    dr["DieuChinh"] = "Định Mức từ " + txtDinhMuc_Cu.Text.Trim() + " -> " + txtDinhMuc_Moi.Text.Trim();
                else
                    dr["DieuChinh"] = dr["DieuChinh"] + ", Định Mức từ " + txtDinhMuc_Cu.Text.Trim() + " -> " + txtDinhMuc_Moi.Text.Trim();
            if (txtTieuThu_Cu.Text.Trim() != txtTieuThu_Moi.Text.Trim())
                if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                    dr["DieuChinh"] = "Tiêu Thụ từ " + txtTieuThu_Cu.Text.Trim() + " -> " + txtTieuThu_Moi.Text.Trim();
                else
                    dr["DieuChinh"] = dr["DieuChinh"] + ", Tiêu Thụ từ " + txtTieuThu_Cu.Text.Trim() + " -> " + txtTieuThu_Moi.Text.Trim();
            if (chkDieuChinhGia.Checked == true)
            {
                switch (int.Parse(txtGiaBieu_Moi.Text.Trim()))
                {
                    case 51:
                    case 52:
                    case 53:
                    case 54:
                    case 59:
                    case 68:
                        if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                            if (_TieuThu_DieuChinhGia == int.Parse(txtTieuThu_Moi.Text.Trim()))
                                dr["DieuChinh"] = _TieuThu_DieuChinhGia + "m3 Áp giá " + (int.Parse(txtGiaDieuChinh.Text.Trim()) - int.Parse(txtGiaDieuChinh.Text.Trim()) * CTaiKhoan.GiamTienNuoc / 100).ToString();
                            else
                                dr["DieuChinh"] = txtDinhMuc_Moi.Text.Trim() + "m3 Áp giá " + (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100).ToString() + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + (int.Parse(txtGiaDieuChinh.Text.Trim()) - int.Parse(txtGiaDieuChinh.Text.Trim()) * CTaiKhoan.GiamTienNuoc / 100).ToString();
                        else
                            if (_TieuThu_DieuChinhGia == int.Parse(txtTieuThu_Moi.Text.Trim()))
                                dr["DieuChinh"] = dr["DieuChinh"] + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + (int.Parse(txtGiaDieuChinh.Text.Trim()) - int.Parse(txtGiaDieuChinh.Text.Trim()) * CTaiKhoan.GiamTienNuoc / 100).ToString();
                            else
                                dr["DieuChinh"] = dr["DieuChinh"] + ", " + txtDinhMuc_Moi.Text.Trim() + "m3 Áp giá " + (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100).ToString() + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + (int.Parse(txtGiaDieuChinh.Text.Trim()) - int.Parse(txtGiaDieuChinh.Text.Trim()) * CTaiKhoan.GiamTienNuoc / 100).ToString();
                        break;
                    default:
                        if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                            if (_TieuThu_DieuChinhGia == int.Parse(txtTieuThu_Moi.Text.Trim()))
                                dr["DieuChinh"] = _TieuThu_DieuChinhGia + "m3 Áp giá " + txtGiaDieuChinh.Text.Trim();
                            else
                                dr["DieuChinh"] = txtDinhMuc_Moi.Text.Trim() + "m3 Áp giá " + lstGiaNuoc[0].DonGia.Value + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + txtGiaDieuChinh.Text.Trim();
                        else
                            if (_TieuThu_DieuChinhGia == int.Parse(txtTieuThu_Moi.Text.Trim()))
                                dr["DieuChinh"] = dr["DieuChinh"] + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + txtGiaDieuChinh.Text.Trim();
                            else
                                dr["DieuChinh"] = dr["DieuChinh"] + ", " + txtDinhMuc_Moi.Text.Trim() + "m3 Áp giá " + lstGiaNuoc[0].DonGia.Value + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + txtGiaDieuChinh.Text.Trim();
                        break;
                }

                dr["ChiTietCu"] = txtChiTietCu.Text.Trim();
                dr["ChiTietMoi"] = txtChiTietMoi.Text.Trim();
            }
            if (chkTyLe.Checked == true)
            {
                if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                    dr["DieuChinh"] = "Tỷ lệ";
                else
                    dr["DieuChinh"] = dr["DieuChinh"] + ", Tỷ lệ";
                if (txtSH.Text.Trim() != "0")
                    dr["DieuChinh"] = dr["DieuChinh"] + " SH: " + txtSH.Text.Trim() + "%";
                if (txtSX.Text.Trim() != "0")
                    dr["DieuChinh"] = dr["DieuChinh"] + " SX: " + txtSX.Text.Trim() + "%";
                if (txtDV.Text.Trim() != "0")
                    dr["DieuChinh"] = dr["DieuChinh"] + " DV: " + txtDV.Text.Trim() + "%";
                if (txtHCSN.Text.Trim() != "0")
                    dr["DieuChinh"] = dr["DieuChinh"] + " HCSN: " + txtHCSN.Text.Trim() + "%";
                dr["ChiTietCu"] = txtChiTietCu.Text.Trim();
                dr["ChiTietMoi"] = txtChiTietMoi.Text.Trim();
            }
            ///
            dr["GiaBieuStart"] = txtGiaBieu_Cu.Text.Trim();
            dr["GiaBieuEnd"] = txtGiaBieu_Moi.Text.Trim();
            dr["DinhMucStart"] = txtDinhMuc_Cu.Text.Trim();
            dr["DinhMucEnd"] = txtDinhMuc_Moi.Text.Trim();
            dr["TieuThuStart"] = txtTieuThu_Cu.Text.Trim(); ;
            if (txtTienNuoc_Start.Text.Trim() == "0")
                dr["TienNuocStart"] = "0";
            else
                dr["TienNuocStart"] = txtTienNuoc_Start.Text.Trim();
            if (txtThueGTGT_Start.Text.Trim() == "0")
                dr["ThueGTGTStart"] = 0;
            else
                dr["ThueGTGTStart"] = txtThueGTGT_Start.Text.Trim();
            if (txtPhiBVMT_Start.Text.Trim() == "0")
                dr["PhiBVMTStart"] = 0;
            else
                dr["PhiBVMTStart"] = txtPhiBVMT_Start.Text.Trim();
            if (txtTongCong_Start.Text.Trim() == "0")
                dr["TongCongStart"] = 0;
            else
                dr["TongCongStart"] = txtTongCong_Start.Text.Trim();
            ///
            if (int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", "")) - int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", "")) == 0)
                dr["TangGiam"] = "";
            else
                if (int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", "")) - int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", "")) > 0)
                    dr["TangGiam"] = "Tăng";
                else
                    dr["TangGiam"] = "Giảm";
            ///
            dr["TieuThuBD"] = int.Parse(txtTieuThu_Moi.Text.Trim().Replace(".", "")) - int.Parse(txtTieuThu_Cu.Text.Trim().Replace(".", ""));
            if (txtTienNuoc_BD.Text.Trim() == "0")
                dr["TienNuocBD"] = 0;
            else
                dr["TienNuocBD"] = txtTienNuoc_BD.Text.Trim();
            if (txtThueGTGT_BD.Text.Trim() == "0")
                dr["ThueGTGTBD"] = 0;
            else
                dr["ThueGTGTBD"] = txtThueGTGT_BD.Text.Trim();
            if (txtPhiBVMT_BD.Text.Trim() == "0")
                dr["PhiBVMTBD"] = 0;
            else
                dr["PhiBVMTBD"] = txtPhiBVMT_BD.Text.Trim();
            if (txtTongCong_BD.Text.Trim() == "0")
                dr["TongCongBD"] = 0;
            else
                dr["TongCongBD"] = txtTongCong_BD.Text.Trim();
            ///
            dr["TieuThuEnd"] = txtTieuThu_Moi.Text.Trim();
            if (txtTienNuoc_End.Text.Trim() == "0")
                dr["TienNuocEnd"] = 0;
            else
                dr["TienNuocEnd"] = txtTienNuoc_End.Text.Trim();
            if (txtThueGTGT_End.Text.Trim() == "0")
                dr["ThueGTGTEnd"] = 0;
            else
                dr["ThueGTGTEnd"] = txtThueGTGT_End.Text.Trim();
            if (txtPhiBVMT_End.Text.Trim() == "0")
                dr["PhiBVMTEnd"] = 0;
            else
                dr["PhiBVMTEnd"] = txtPhiBVMT_End.Text.Trim();
            if (txtTongCong_End.Text.Trim() == "0")
                dr["TongCongEnd"] = 0;
            else
                dr["TongCongEnd"] = txtTongCong_End.Text.Trim();

            //dr["ChucVu"] = ctdchd.ChucVu;
            //dr["NguoiKy"] = ctdchd.NguoiKy;

            dsBaoCao.Tables["DCHD"].Rows.Add(dr);

            rptThongBaoDCHD rpt = new rptThongBaoDCHD();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void txtTienNuoc_Start_TextChanged(object sender, EventArgs e)
        {
            if (txtTienNuoc_Start.Text.Length > 0 && txtTienNuoc_End.Text.Length > 0)
                txtTienNuoc_BD.Text = (int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", "")) - int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", ""))).ToString();
        }

        private void txtThueGTGT_Start_TextChanged(object sender, EventArgs e)
        {
            if (txtThueGTGT_Start.Text.Length > 0 && txtThueGTGT_End.Text.Length > 0)
                txtThueGTGT_BD.Text = (int.Parse(txtThueGTGT_End.Text.Trim().Replace(".", "")) - int.Parse(txtThueGTGT_Start.Text.Trim().Replace(".", ""))).ToString();
        }

        private void txtPhiBVMT_Start_TextChanged(object sender, EventArgs e)
        {
            if (txtPhiBVMT_Start.Text.Length > 0 && txtPhiBVMT_End.Text.Length > 0)
                txtPhiBVMT_BD.Text = (int.Parse(txtPhiBVMT_End.Text.Trim().Replace(".", "")) - int.Parse(txtPhiBVMT_Start.Text.Trim().Replace(".", ""))).ToString();
        }

        private void txtTongCong_Start_TextChanged(object sender, EventArgs e)
        {
            if (txtTongCong_Start.Text.Length > 0 && txtTongCong_End.Text.Length > 0)
                txtTongCong_BD.Text = (int.Parse(txtTongCong_End.Text.Trim().Replace(".", "")) - int.Parse(txtTongCong_Start.Text.Trim().Replace(".", ""))).ToString();
        }

        private void txtTienNuoc_BD_TextChanged(object sender, EventArgs e)
        {
            if (txtTienNuoc_BD.Text.Length > 0)
                txtTienNuoc_End.Text = (int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", "")) + int.Parse(txtTienNuoc_BD.Text.Trim().Replace(".", ""))).ToString();
        }

        private void txtThueGTGT_BD_TextChanged(object sender, EventArgs e)
        {
            if (txtThueGTGT_BD.Text.Length > 0)
                txtThueGTGT_End.Text = (int.Parse(txtThueGTGT_Start.Text.Trim().Replace(".", "")) + int.Parse(txtThueGTGT_BD.Text.Trim().Replace(".", ""))).ToString();
        }

        private void txtPhiBVMT_BD_TextChanged(object sender, EventArgs e)
        {
            if (txtPhiBVMT_BD.Text.Length > 0)
                txtPhiBVMT_End.Text = (int.Parse(txtPhiBVMT_Start.Text.Trim().Replace(".", "")) + int.Parse(txtPhiBVMT_BD.Text.Trim().Replace(".", ""))).ToString();
        }

        private void txtTongCong_BD_TextChanged(object sender, EventArgs e)
        {
            if (txtTongCong_BD.Text.Length > 0)
                txtTongCong_End.Text = (int.Parse(txtTongCong_Start.Text.Trim().Replace(".", "")) + int.Parse(txtTongCong_BD.Text.Trim().Replace(".", ""))).ToString();
        }

        private void txtTienNuoc_End_TextChanged(object sender, EventArgs e)
        {
            if (txtTienNuoc_End.Text.Length > 0)
                txtTienNuoc_BD.Text = (int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", "")) - int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", ""))).ToString();
        }

        private void txtThueGTGT_End_TextChanged(object sender, EventArgs e)
        {
            if (txtThueGTGT_End.Text.Length > 0)
                txtThueGTGT_BD.Text = (int.Parse(txtThueGTGT_End.Text.Trim().Replace(".", "")) - int.Parse(txtThueGTGT_Start.Text.Trim().Replace(".", ""))).ToString();
        }

        private void txtPhiBVMT_End_TextChanged(object sender, EventArgs e)
        {
            if (txtPhiBVMT_End.Text.Length > 0)
                txtPhiBVMT_BD.Text = (int.Parse(txtPhiBVMT_End.Text.Trim().Replace(".", "")) - int.Parse(txtPhiBVMT_Start.Text.Trim().Replace(".", ""))).ToString();
        }

        private void txtTongCong_End_TextChanged(object sender, EventArgs e)
        {
            if (txtTongCong_End.Text.Length > 0)
                txtTongCong_BD.Text = (int.Parse(txtTongCong_End.Text.Trim().Replace(".", "")) - int.Parse(txtTongCong_Start.Text.Trim().Replace(".", ""))).ToString();
        }

        private void txtKyHD_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtKyHD.Text.Trim()))
            {
                string[] KyHD = txtKyHD.Text.Trim().Split('/');
                HOADON hoadon = _cThuTien.Get(txtDanhBo.Text.Trim(), int.Parse(KyHD[0]), int.Parse(KyHD[1]));
                if (hoadon != null)
                {
                    txtGiaBieu_Cu.Text = hoadon.GB.Value.ToString();
                    if(hoadon.DM!=null)
                    txtDinhMuc_Cu.Text = hoadon.DM.Value.ToString();
                    txtTieuThu_Cu.Text = hoadon.TIEUTHU.Value.ToString();
                    txtTienNuoc_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", hoadon.GIABAN.Value);
                    txtThueGTGT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", hoadon.THUE.Value);
                    txtPhiBVMT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", hoadon.PHI.Value);
                    txtTongCong_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", hoadon.TONGCONG.Value);
                }
                if (txtDanhBo.Text.Trim().Length == 11 && txtKyHD.Text.Trim() != "")
                {
                    dgvLichSu.DataSource = _cDCBD.LoadDSCTDCHD(txtDanhBo.Text.Trim(), int.Parse(KyHD[1]), int.Parse(KyHD[0]));
                }
            }
        }

        private void txtDanhBo_Leave(object sender, EventArgs e)
        {
            if (txtDanhBo.Text.Trim().Length == 11 && txtKyHD.Text.Trim() != "")
            {
                string[] KyHD = txtKyHD.Text.Trim().Split('/');

                dgvLichSu.DataSource = _cDCBD.LoadDSCTDCHD(txtDanhBo.Text.Trim(), int.Parse(KyHD[1]), int.Parse(KyHD[0]));
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {

            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                //if (_cttttl != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

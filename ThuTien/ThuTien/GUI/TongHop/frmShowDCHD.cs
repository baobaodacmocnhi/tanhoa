using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.TongHop;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.Doi;
using System.Globalization;
using ThuTien.DAL.Quay;
using ThuTien.DAL;

namespace ThuTien.GUI.TongHop
{
    public partial class frmShowDCHD : Form
    {
        int _MaHD;
        string _SoHoaDon;
        DIEUCHINH_HD _dchd = null;
        DCBD_ChiTietHoaDon _ctdchd;
        HOADON _hoadon = null;
        CDCHD _cDCHD = new CDCHD();
        CHoaDon _cHoaDon = new CHoaDon();
        CTamThu _cTamThu = new CTamThu();
        CKinhDoanh _cKinhDoanh = new CKinhDoanh();

        public frmShowDCHD(int MaHD, string SoHoaDon)
        {
            InitializeComponent();
            _MaHD = MaHD;
            _SoHoaDon = SoHoaDon;
        }

        private void frmShowDCHD_Load(object sender, EventArgs e)
        {
            Location = new Point(100, 100);
            //_hoadon = _cHoaDon.Get(_SoHoaDon);
            _dchd = _cDCHD.Get(_MaHD);
            ///đã có điều chỉnh
            if (_dchd != null)
            {
                HOADON hd = _cHoaDon.Get(_dchd.FK_HOADON);

                txtSoHoaDon.Text = hd.SOHOADON;
                txtSoPhatHanh.Text = hd.SOPHATHANH.ToString();
                txtKy.Text = hd.KY + "/" + hd.NAM;

                textBox1.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchd.TIEUTHU_BD.Value);
                textBox2.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchd.GIABAN_BD.Value);
                textBox3.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchd.THUE_BD.Value);
                textBox4.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchd.PHI_BD.Value);
                textBox5.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchd.TONGCONG_BD.Value);

                chkChuanThu1.Checked = _dchd.ChuanThu1;
                chkBaoCaoThue.Checked = _dchd.BaoCaoThue;

                if (_dchd.PHIEU_DC != null)
                    if (!_dchd.TXL)
                    {
                        txtMaDon.Text = _dchd.PHIEU_DC.ToString().Insert(_dchd.PHIEU_DC.ToString().Length - 2, "-");
                        dateLap.Value = _dchd.NGAY_VB.Value;
                    }
                    else
                    {
                        txtMaDon.Text = "TXL" + _dchd.PHIEU_DC.ToString().Insert(_dchd.PHIEU_DC.ToString().Length - 2, "-");
                        dateLap.Value = _dchd.NGAY_VB.Value;
                    }

                if (_dchd.TangGiam != null)
                {
                    if (_dchd.SoPhieu != null)
                    {
                        txtSoPhieu.Text = _dchd.SoPhieu.ToString().Insert(_dchd.SoPhieu.ToString().Length - 2, "-");
                        _ctdchd = _cKinhDoanh.GetCTDCHDBySoPhieu(_dchd.SoPhieu.Value);
                    }
                    ///
                    lbTangGiam.Text = _dchd.TangGiam;
                    txtTienNuoc_Start.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchd.GIABAN_BD.Value);
                    txtTienNuoc_BD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchd.GIABAN_DC.Value);
                    txtTienNuoc_End.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchd.GIABAN_END.Value);

                    txtThueGTGT_Start.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchd.THUE_BD.Value);
                    txtThueGTGT_BD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchd.THUE_DC.Value);
                    txtThueGTGT_End.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchd.THUE_END.Value);

                    txtPhiBVMT_Start.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchd.PHI_BD.Value);
                    txtPhiBVMT_BD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchd.PHI_DC.Value);
                    txtPhiBVMT_End.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchd.PHI_END.Value);

                    txtTongCong_Start.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchd.TONGCONG_BD.Value);
                    txtTongCong_BD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchd.TONGCONG_DC.Value);
                    txtTongCong_End.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchd.TONGCONG_END.Value);
                }
            }
            ///chưa có điều chỉnh
            else
            {
                _hoadon = _cHoaDon.Get(_MaHD);

                txtSoHoaDon.Text = _hoadon.SOHOADON;
                txtSoPhatHanh.Text = _hoadon.SOPHATHANH.ToString();
                txtKy.Text = _hoadon.KY + "/" + _hoadon.NAM;

                textBox1.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _hoadon.TIEUTHU.Value);
                textBox2.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _hoadon.GIABAN.Value);
                textBox3.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _hoadon.THUE.Value);
                textBox4.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _hoadon.PHI.Value);
                textBox5.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _hoadon.TONGCONG.Value);
            }
        }

        private void txtSoPhieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSoPhieu.Text.Trim()) && e.KeyChar == 13)
            {
                _ctdchd = _cKinhDoanh.GetCTDCHDBySoPhieu(decimal.Parse(txtSoPhieu.Text.Trim().Replace("-", "")));

                if (_ctdchd.DCBD.MaDon != null)
                {
                    txtMaDon.Text = _ctdchd.DCBD.MaDon.ToString().Insert(_ctdchd.DCBD.MaDon.ToString().Length - 2, "-");
                    dateLap.Value = _ctdchd.DCBD.DonKH.CreateDate.Value;
                }
                if (_ctdchd.DCBD.MaDonTXL != null)
                {
                    txtMaDon.Text = "TXL" + _ctdchd.DCBD.MaDonTXL.ToString().Insert(_ctdchd.DCBD.MaDonTXL.ToString().Length - 2, "-");
                    dateLap.Value = _ctdchd.DCBD.DonTXL.CreateDate.Value;
                }
                else
                    if (_ctdchd.DCBD.MaDonTBC != null)
                    {
                        txtMaDon.Text = "TBC" + _ctdchd.DCBD.MaDonTBC.ToString().Insert(_ctdchd.DCBD.MaDonTBC.ToString().Length - 2, "-");
                        dateLap.Value = _ctdchd.DCBD.DonTBC.CreateDate.Value;
                    }

                //if (_dchd.TXL)
                //{
                //    if (_dchd.PHIEU_DC.Value != _ctdchd.DCBD.MaDonTXL)
                //        MessageBox.Show("Mã Đơn lúc Rút & nhập Kết Quả có khác nhau \nVui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else
                //{
                //    if (_dchd.PHIEU_DC.Value != _ctdchd.DCBD.MaDon)
                //        MessageBox.Show("Mã Đơn lúc Rút & nhập Kết Quả có khác nhau \nVui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

                txtSoPhieu.Text = _ctdchd.MaCTDCHD.ToString().Insert(_ctdchd.MaCTDCHD.ToString().Length - 2, "-");

                lbTangGiam.Text = _ctdchd.TangGiam;

                txtTienNuoc_Start.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_Start.Value);
                txtTienNuoc_BD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_BD.Value);
                txtTienNuoc_End.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_End.Value);

                txtThueGTGT_Start.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_Start.Value);
                txtThueGTGT_BD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_BD.Value);
                txtThueGTGT_End.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_End.Value);

                txtPhiBVMT_Start.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_Start.Value);
                txtPhiBVMT_BD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_BD.Value);
                txtPhiBVMT_End.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_End.Value);

                txtTongCong_Start.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TongCong_Start.Value);
                txtTongCong_BD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TongCong_BD.Value);
                txtTongCong_End.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TongCong_End.Value);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen("mnuDCHD", "Sua"))
                {
                    if (_cHoaDon.CheckDangNganBySoHoaDon(_SoHoaDon))
                    {
                        MessageBox.Show("Hóa đơn đã đăng ngân", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_cHoaDon.CheckDCHDTienDuBySoHoaDon(_SoHoaDon))
                    {
                        MessageBox.Show("Hóa Đơn này đã ĐCHĐ Tiền Dư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    try
                    {
                        _cDCHD.BeginTransaction();
                        ///đã có điều chỉnh
                        if (_dchd != null)
                        {
                            ///sửa số hóa đơn
                            HOADON hd = _cHoaDon.Get(_dchd.FK_HOADON);
                            if (!string.IsNullOrEmpty(txtSoHoaDonMoi.Text.Trim()) && txtSoHoaDon.Text.Trim() != txtSoHoaDonMoi.Text.Trim())
                            {
                                if (hd.SoHoaDonCu == null)
                                    hd.SoHoaDonCu = txtSoHoaDon.Text.Trim();
                                hd.SOHOADON = txtSoHoaDonMoi.Text.Trim().ToUpper();
                                _cHoaDon.Sua(hd);
                                //
                                _dchd.UpdatedHDDT = true;
                                _dchd.SoHoaDonMoi = txtSoHoaDonMoi.Text.Trim().ToUpper();
                                _cDCHD.Sua(_dchd);
                                //_cDCHD.Refresh(_dchd);
                            }
                            _dchd.ChuanThu1 = chkChuanThu1.Checked;
                            _dchd.BaoCaoThue = chkBaoCaoThue.Checked;
                            hd.BaoCaoThue = chkBaoCaoThue.Checked;
                            if (chkBaoCaoThue.Checked == true)
                                _dchd.UpdatedHDDT = chkUpdatedHDDT.Checked;

                            if (_ctdchd != null)
                            {
                                if (_ctdchd.DCBD.MaDon != null)
                                    _dchd.PHIEU_DC = (int)_ctdchd.DCBD.MaDon;
                                else
                                    if (_ctdchd.DCBD.MaDonTXL != null)
                                        _dchd.PHIEU_DC = (int)_ctdchd.DCBD.MaDonTXL;
                                    else
                                        if (_ctdchd.DCBD.MaDonTBC != null)
                                            _dchd.PHIEU_DC = (int)_ctdchd.DCBD.MaDonTBC;

                                _dchd.NGAY_VB = dateLap.Value;
                                _dchd.NGAY_DC = DateTime.Now;

                                if (_dchd.SoPhieu != _ctdchd.MaCTDCHD)
                                {
                                    _dchd.GIABAN_BD = hd.GIABAN;
                                    _dchd.THUE_BD = hd.THUE;
                                    _dchd.PHI_BD = hd.PHI;
                                    _dchd.TONGCONG_BD = hd.TONGCONG;
                                }

                                _dchd.SoPhieu = _ctdchd.MaCTDCHD;
                                _dchd.TangGiam = _ctdchd.TangGiam;

                                _dchd.GIABAN_DC = _ctdchd.TienNuoc_BD.Value;
                                _dchd.GIABAN_END = _ctdchd.TienNuoc_End.Value;

                                _dchd.THUE_DC = _ctdchd.ThueGTGT_BD.Value;
                                _dchd.THUE_END = _ctdchd.ThueGTGT_End.Value;

                                _dchd.PHI_DC = _ctdchd.PhiBVMT_BD.Value;
                                _dchd.PHI_END = _ctdchd.PhiBVMT_End.Value;

                                _dchd.TONGCONG_DC = _ctdchd.TongCong_BD.Value;
                                _dchd.TONGCONG_END = _ctdchd.TongCong_End.Value;

                                _dchd.GB_DC = _ctdchd.GiaBieu_BD;
                                _dchd.DM_DC = _ctdchd.DinhMuc_BD;
                                _dchd.TIEUTHU_DC = _ctdchd.TieuThu_BD;
                            }
                            ///không có phiếu điều chỉnh hóa đơn bên P.Kinh Doanh
                            ///hóa đơn điện tử k áp dụng
                            else
                            {
                                _dchd.GIABAN_DC = decimal.Parse(txtTienNuoc_BD.Text.Trim().Replace(".", ""));
                                _dchd.GIABAN_END = decimal.Parse(txtTienNuoc_End.Text.Trim().Replace(".", ""));

                                _dchd.THUE_DC = decimal.Parse(txtThueGTGT_BD.Text.Trim().Replace(".", ""));
                                _dchd.THUE_END = decimal.Parse(txtThueGTGT_End.Text.Trim().Replace(".", ""));

                                _dchd.PHI_DC = decimal.Parse(txtPhiBVMT_BD.Text.Trim().Replace(".", ""));
                                _dchd.PHI_END = decimal.Parse(txtPhiBVMT_End.Text.Trim().Replace(".", ""));

                                _dchd.TONGCONG_DC = decimal.Parse(txtTongCong_BD.Text.Trim().Replace(".", ""));
                                _dchd.TONGCONG_END = decimal.Parse(txtTongCong_End.Text.Trim().Replace(".", ""));

                                if (_dchd.TONGCONG_BD.Value > _dchd.TONGCONG_END.Value)
                                    _dchd.TangGiam = "Giảm";
                                else
                                    if (_dchd.TONGCONG_BD.Value < _dchd.TONGCONG_END.Value)
                                        _dchd.TangGiam = "Tăng";
                            }

                            if (_cDCHD.Sua(_dchd))
                            {
                                ///lưu lịch sử
                                LuuLichSuDC(_dchd);

                                hd.GB = _dchd.GB_DC.Value;
                                hd.DM = _dchd.DM_DC;
                                hd.TIEUTHU = _dchd.TIEUTHU_DC;
                                hd.GIABAN = _dchd.GIABAN_END;
                                hd.THUE = _dchd.THUE_END;
                                hd.PHI = _dchd.PHI_END;
                                hd.TONGCONG = _dchd.TONGCONG_END;
                                if (_cHoaDon.Sua(hd))
                                {
                                    //_cDCHD.CommitTransaction();
                                    //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                    //Close();
                                }
                            }
                        }
                        ///chưa có điều chỉnh
                        else
                        //if (!_cDCHD.CheckExist(_SoHoaDon))
                        {
                            string loai;
                            if (_cTamThu.CheckExist(_SoHoaDon, out loai))
                            {
                                MessageBox.Show("Hóa Đơn này đã Tạm Thu(" + loai + ")", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            DIEUCHINH_HD dchd = new DIEUCHINH_HD();
                            ///sửa số hóa đơn
                            if (!string.IsNullOrEmpty(txtSoHoaDonMoi.Text.Trim()) && txtSoHoaDon.Text.Trim() != txtSoHoaDonMoi.Text.Trim())
                            {
                                if (_hoadon.SoHoaDonCu == null)
                                    _hoadon.SoHoaDonCu = txtSoHoaDon.Text.Trim();
                                _hoadon.SOHOADON = txtSoHoaDonMoi.Text.Trim().ToUpper();
                                _cHoaDon.Sua(_hoadon);
                                //
                                dchd.UpdatedHDDT = true;
                                dchd.SoHoaDonMoi = txtSoHoaDonMoi.Text.Trim().ToUpper();
                                _cDCHD.Sua(dchd);
                            }

                            dchd.FK_HOADON = _hoadon.ID_HOADON;
                            dchd.SoHoaDon = _hoadon.SOHOADON;
                            dchd.GiaBieu = _hoadon.GB;
                            if (_hoadon.DM != null)
                                dchd.DinhMuc = (int)_hoadon.DM;
                            dchd.TIEUTHU_BD = (int)_hoadon.TIEUTHU;
                            dchd.GIABAN_BD = _hoadon.GIABAN;
                            dchd.PHI_BD = _hoadon.PHI;
                            dchd.THUE_BD = _hoadon.THUE;
                            dchd.TONGCONG_BD = _hoadon.TONGCONG;
                            dchd.NGAY_DC = DateTime.Now;
                            dchd.ChuanThu1 = chkChuanThu1.Checked;
                            dchd.BaoCaoThue = chkBaoCaoThue.Checked;
                            _hoadon.BaoCaoThue = chkBaoCaoThue.Checked;
                            if (chkBaoCaoThue.Checked == true)
                                dchd.UpdatedHDDT = chkUpdatedHDDT.Checked;
                            if (_ctdchd != null)
                            {
                                if (_ctdchd.DCBD.MaDonMoi != null)
                                    dchd.PHIEU_DC = _ctdchd.DCBD.MaDonMoi;
                                else
                                    if (_ctdchd.DCBD.MaDon != null)
                                        dchd.PHIEU_DC = (int)_ctdchd.DCBD.MaDon;
                                    else
                                        if (_ctdchd.DCBD.MaDonTXL != null)
                                            dchd.PHIEU_DC = (int)_ctdchd.DCBD.MaDonTXL;
                                        else
                                            if (_ctdchd.DCBD.MaDonTBC != null)
                                                dchd.PHIEU_DC = (int)_ctdchd.DCBD.MaDonTBC;

                                dchd.NGAY_VB = dateLap.Value;
                                dchd.SoPhieu = _ctdchd.MaCTDCHD;
                                dchd.TangGiam = _ctdchd.TangGiam;

                                //_dchd.GIABAN_BD = _ctdchd.TienNuoc_Start.Value;
                                dchd.GIABAN_DC = _ctdchd.TienNuoc_BD.Value;
                                dchd.GIABAN_END = _ctdchd.TienNuoc_End.Value;

                                //_dchd.THUE_BD = _ctdchd.ThueGTGT_Start.Value;
                                dchd.THUE_DC = _ctdchd.ThueGTGT_BD.Value;
                                dchd.THUE_END = _ctdchd.ThueGTGT_End.Value;

                                //_dchd.PHI_BD = _ctdchd.PhiBVMT_Start.Value;
                                dchd.PHI_DC = _ctdchd.PhiBVMT_BD.Value;
                                dchd.PHI_END = _ctdchd.PhiBVMT_End.Value;

                                //_dchd.TONGCONG_BD = _ctdchd.TongCong_Start.Value;
                                dchd.TONGCONG_DC = _ctdchd.TongCong_BD.Value;
                                dchd.TONGCONG_END = _ctdchd.TongCong_End.Value;

                                dchd.GB_DC = _ctdchd.GiaBieu_BD;
                                dchd.DM_DC = _ctdchd.DinhMuc_BD;
                                dchd.TIEUTHU_DC = _ctdchd.TieuThu_BD;
                            }
                            ///không có phiếu điều chỉnh hóa đơn bên P.Kinh Doanh
                            ///hóa đơn điện tử k áp dụng
                            else
                            {
                                //dchd.GIABAN_DC = decimal.Parse(txtTienNuoc_BD.Text.Trim().Replace(".", ""));
                                //dchd.GIABAN_END = decimal.Parse(txtTienNuoc_End.Text.Trim().Replace(".", ""));

                                //dchd.THUE_DC = decimal.Parse(txtThueGTGT_BD.Text.Trim().Replace(".", ""));
                                //dchd.THUE_END = decimal.Parse(txtThueGTGT_End.Text.Trim().Replace(".", ""));

                                //dchd.PHI_DC = decimal.Parse(txtPhiBVMT_BD.Text.Trim().Replace(".", ""));
                                //dchd.PHI_END = decimal.Parse(txtPhiBVMT_End.Text.Trim().Replace(".", ""));

                                //dchd.TONGCONG_DC = decimal.Parse(txtTongCong_BD.Text.Trim().Replace(".", ""));
                                //dchd.TONGCONG_END = decimal.Parse(txtTongCong_End.Text.Trim().Replace(".", ""));

                                //if (dchd.TONGCONG_BD.Value > dchd.TONGCONG_END.Value)
                                //    dchd.TangGiam = "Giảm";
                                //else
                                //    if (dchd.TONGCONG_BD.Value < dchd.TONGCONG_END.Value)
                                //        dchd.TangGiam = "Tăng";
                                MessageBox.Show("Liên hệ Bảo Bảo", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            if (_cDCHD.Them(dchd))
                            {
                                ///lưu lịch sử
                                LuuLichSuDC(dchd);

                                _hoadon.GB = dchd.GB_DC.Value;
                                _hoadon.DM = dchd.DM_DC;
                                _hoadon.TIEUTHU = dchd.TIEUTHU_DC;
                                _hoadon.GIABAN = dchd.GIABAN_END;
                                _hoadon.THUE = dchd.THUE_END;
                                _hoadon.PHI = dchd.PHI_END;
                                _hoadon.TONGCONG = dchd.TONGCONG_END;
                                if (_cHoaDon.Sua(_hoadon))
                                {
                                    //_cDCHD.CommitTransaction();
                                    //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                    //Close();
                                }
                            }
                        }
                        //else
                        //    MessageBox.Show("Hóa Đơn này đã Điều Chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _cDCHD.CommitTransaction();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        _cDCHD.Rollback();
                        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void LuuLichSuDC(DIEUCHINH_HD dchd)
        {
            TT_LichSuDieuChinhHD lsdc = new TT_LichSuDieuChinhHD();

            lsdc.FK_HOADON = dchd.FK_HOADON;
            lsdc.SoHoaDon = dchd.SoHoaDon;
            lsdc.GiaBieu = dchd.GiaBieu;
            lsdc.DinhMuc = dchd.DinhMuc;
            lsdc.TIEUTHU_BD = dchd.TIEUTHU_BD;
            lsdc.GIABAN_BD = dchd.GIABAN_BD;
            lsdc.PHI_BD = dchd.PHI_BD;
            lsdc.THUE_BD = dchd.THUE_BD;
            lsdc.TONGCONG_BD = dchd.TONGCONG_BD;

            lsdc.PHIEU_DC = dchd.PHIEU_DC;
            lsdc.NGAY_VB = dchd.NGAY_VB;
            lsdc.NGAY_DC = dchd.NGAY_DC;
            lsdc.SoPhieu = dchd.SoPhieu;
            lsdc.TangGiam = dchd.TangGiam;

            lsdc.GIABAN_DC = dchd.GIABAN_DC;
            lsdc.GIABAN_END = dchd.GIABAN_END;

            lsdc.THUE_DC = dchd.THUE_DC;
            lsdc.THUE_END = dchd.THUE_END;

            lsdc.PHI_DC = dchd.PHI_DC;
            lsdc.PHI_END = dchd.PHI_END;

            lsdc.TONGCONG_DC = dchd.TONGCONG_DC;
            lsdc.TONGCONG_END = dchd.TONGCONG_END;

            lsdc.GB_DC = dchd.GB_DC;
            lsdc.DM_DC = dchd.DM_DC;
            lsdc.TIEUTHU_DC = dchd.TIEUTHU_DC;

            _cDCHD.ThemLSDC(lsdc);
        }

        private void frmShowDCHD_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen("mnuDCHD", "Them"))
                {
                    if (_cHoaDon.CheckDangNganBySoHoaDon(_SoHoaDon))
                    {
                        MessageBox.Show("Hóa đơn đã đăng ngân", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string loai;
                    if (_cTamThu.CheckExist(_SoHoaDon, out loai))
                    {
                        MessageBox.Show("Hóa Đơn này đã Tạm Thu(" + loai + ")", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_cHoaDon.CheckDCHDTienDuBySoHoaDon(_SoHoaDon))
                    {
                        MessageBox.Show("Hóa Đơn này đã ĐCHĐ Tiền Dư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_dchd != null)
                    {
                        if (MessageBox.Show("Hóa Đơn này đã có Điều Chỉnh\nBạn có muốn chặn tiếp không?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            _dchd.UpdatedHDDT = false;

                            if (_cDCHD.Sua(_dchd))
                            {
                                ///lưu lịch sử
                                LuuLichSuDC(_dchd);

                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                Close();
                            }
                        }
                    }
                    else
                    {
                        DIEUCHINH_HD dchd = new DIEUCHINH_HD();
                        dchd.FK_HOADON = _hoadon.ID_HOADON;
                        dchd.SoHoaDon = _hoadon.SOHOADON;
                        dchd.GiaBieu = _hoadon.GB;
                        if (_hoadon.DM != null)
                            dchd.DinhMuc = (int)_hoadon.DM;
                        dchd.TIEUTHU_BD = (int)_hoadon.TIEUTHU;
                        dchd.GIABAN_BD = _hoadon.GIABAN;
                        dchd.PHI_BD = _hoadon.PHI;
                        dchd.THUE_BD = _hoadon.THUE;
                        dchd.TONGCONG_BD = _hoadon.TONGCONG;
                        dchd.NGAY_DC = DateTime.Now;

                        if (_cDCHD.Them(dchd))
                        {
                            ///lưu lịch sử
                            LuuLichSuDC(dchd);

                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            Close();
                        }
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

    }

}

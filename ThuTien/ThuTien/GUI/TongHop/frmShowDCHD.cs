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

namespace ThuTien.GUI.TongHop
{
    public partial class frmShowDCHD : Form
    {
        int _MaDCHD;
        DIEUCHINH_HD _dchd;
        CTDCHD _ctdchd;
        HOADON _hoadon;
        CDCHD _cDCHD = new CDCHD();
        CHoaDon _cHoaDon = new CHoaDon();

        public frmShowDCHD(int MaDCHD)
        {
            InitializeComponent();
            _MaDCHD = MaDCHD;
        }

        private void frmShowDCHD_Load(object sender, EventArgs e)
        {
            Location = new Point(100, 100);
            _dchd = _cDCHD.GetByMaDCHD(_MaDCHD);

            _hoadon = _cHoaDon.GetBySoHoaDon(_dchd.SoHoaDon);
            txtSoHoaDon.Text = _hoadon.SOHOADON;
            txtSoPhatHanh.Text = _hoadon.SOPHATHANH.ToString();
            txtKy.Text = _hoadon.KY + "/" + _hoadon.NAM;

            textBox1.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_dchd.TIEUTHU_BD.Value);
            textBox2.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_dchd.GIABAN_BD.Value);
            textBox3.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_dchd.THUE_BD.Value);
            textBox4.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_dchd.PHI_BD.Value);
            textBox5.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_dchd.TONGCONG_BD.Value);

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
                txtSoPhieu.Text = _dchd.SoPhieu.ToString().Insert(_dchd.SoPhieu.ToString().Length - 2, "-");
                ///
                lbTangGiam.Text = _dchd.TangGiam;
                txtTienNuoc_Start.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_dchd.GIABAN_BD.Value);
                txtTienNuoc_BD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_dchd.GIABAN_DC.Value);
                txtTienNuoc_End.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_dchd.GIABAN_END.Value);

                txtThueGTGT_Start.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_dchd.THUE_BD.Value);
                txtThueGTGT_BD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_dchd.THUE_DC.Value);
                txtThueGTGT_End.Text =String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_dchd.THUE_END.Value);

                txtPhiBVMT_Start.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_dchd.PHI_BD.Value);
                txtPhiBVMT_BD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_dchd.PHI_DC.Value);
                txtPhiBVMT_End.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_dchd.PHI_END.Value);

                txtTongCong_Start.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_dchd.TONGCONG_BD.Value);
                txtTongCong_BD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_dchd.TONGCONG_DC.Value);
                txtTongCong_End.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_dchd.TONGCONG_END.Value);
            }

        }

        private void txtSoPhieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSoPhieu.Text.Trim()) && e.KeyChar == 13)
            {
                _ctdchd = _cDCHD.GetCTDCHDBySoPhieu(decimal.Parse(txtSoPhieu.Text.Trim().Replace("-", "")));

                if (_dchd.PHIEU_DC == null)
                {
                    if (_ctdchd.DCBD.ToXuLy)
                    {
                        txtMaDon.Text = "TXL" + _ctdchd.DCBD.MaDonTXL.ToString().Insert(_ctdchd.DCBD.MaDonTXL.ToString().Length - 2, "-");
                        dateLap.Value = _ctdchd.DCBD.DonTXL.CreateDate.Value;
                    }
                    else
                    {
                        txtMaDon.Text = _ctdchd.DCBD.MaDon.ToString().Insert(_ctdchd.DCBD.MaDon.ToString().Length - 2, "-");
                        dateLap.Value = _ctdchd.DCBD.DonKH.CreateDate.Value;
                    }
                }
                else
                    if (_dchd.TXL)
                    {
                        if (_dchd.PHIEU_DC.Value != _ctdchd.DCBD.MaDonTXL)
                            MessageBox.Show("Mã Đơn lúc Rút & nhập Kết Quả có khác nhau \nVui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (_dchd.PHIEU_DC.Value != _ctdchd.DCBD.MaDon)
                            MessageBox.Show("Mã Đơn lúc Rút & nhập Kết Quả có khác nhau \nVui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                txtSoPhieu.Text = _ctdchd.MaCTDCHD.ToString().Insert(_ctdchd.MaCTDCHD.ToString().Length - 2, "-");

                lbTangGiam.Text = _ctdchd.TangGiam;

                txtTienNuoc_Start.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_Start.Value);
                txtTienNuoc_BD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_BD.Value);
                txtTienNuoc_End.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_End.Value);

                txtThueGTGT_Start.Text =  String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_Start.Value);
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
            if (CNguoiDung.CheckQuyen("mnuDCHD", "Sua"))
            {
                if (_dchd.PHIEU_DC == null)
                {
                    if (_ctdchd.DCBD.ToXuLy)
                    {
                        _dchd.PHIEU_DC = (int)_ctdchd.DCBD.MaDonTXL;
                        _dchd.NGAY_VB = _ctdchd.DCBD.DonTXL.CreateDate;
                    }
                    else
                    {
                        _dchd.PHIEU_DC = (int)_ctdchd.DCBD.MaDon;
                        _dchd.NGAY_VB = _ctdchd.DCBD.DonKH.CreateDate;
                    }
                }

                _dchd.SoPhieu = _ctdchd.MaCTDCHD;
                _dchd.TangGiam = _ctdchd.TangGiam;

                //_dchd.GIABAN_BD = _ctdchd.TienNuoc_Start.Value;
                _dchd.GIABAN_DC = _ctdchd.TienNuoc_BD.Value;
                _dchd.GIABAN_END = _ctdchd.TienNuoc_End.Value;

                //_dchd.THUE_BD = _ctdchd.ThueGTGT_Start.Value;
                _dchd.THUE_DC = _ctdchd.ThueGTGT_BD.Value;
                _dchd.THUE_END = _ctdchd.ThueGTGT_End.Value;

                //_dchd.PHI_BD = _ctdchd.PhiBVMT_Start.Value;
                _dchd.PHI_DC = _ctdchd.PhiBVMT_BD.Value;
                _dchd.PHI_END = _ctdchd.PhiBVMT_End.Value;

                //_dchd.TONGCONG_BD = _ctdchd.TongCong_Start.Value;
                _dchd.TONGCONG_DC = _ctdchd.TongCong_BD.Value;
                _dchd.TONGCONG_END = _ctdchd.TongCong_End.Value;

                //_dchd.GB_DC = _ctdchd.GiaBieu_BD;
                _dchd.DM_DC = _ctdchd.DinhMuc_BD;
                _dchd.TIEUTHU_DC = _ctdchd.TieuThu_BD;

                if (_cDCHD.Sua(_dchd))
                {
                    _hoadon.GIABAN = _ctdchd.TienNuoc_End.Value;
                    _hoadon.THUE = _ctdchd.ThueGTGT_End.Value;
                    _hoadon.PHI = _ctdchd.PhiBVMT_End.Value;
                    _hoadon.TONGCONG = _ctdchd.TongCong_End.Value;
                    if (_cHoaDon.Sua(_hoadon))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmShowDCHD : Form
    {
        decimal _MaCTDCHD = 0;
        CDCBD _cDCBD = new CDCBD();
        CTDCHD _ctdchd = null;
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();
        bool _flag = false;
        int _TieuThu_DieuChinhGia = 0;
        List<GiaNuoc> lstGiaNuoc;

        public frmShowDCHD()
        {
            InitializeComponent();
        }

        public frmShowDCHD(decimal MaCTDCHD)
        {
            InitializeComponent();
            _MaCTDCHD = MaCTDCHD;
        }

        public frmShowDCHD(decimal MaCTDCHD, bool TimKiem)
        {
            InitializeComponent();
            _MaCTDCHD = MaCTDCHD;
            if (TimKiem)
            {
                btnIn.Enabled = false;
                btnSua.Enabled = false;
            }
        }

        private void frmShowDCHD_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmShowDCHD_Load(object sender, EventArgs e)
        {
            lstGiaNuoc = _cGiaNuoc.LoadDSGiaNuoc();
            if (_cDCBD.getCTDCHDbyID(_MaCTDCHD) != null)
            {
                this.Location = new Point(70, 70);
                _ctdchd = _cDCBD.getCTDCHDbyID(_MaCTDCHD);
                if (_ctdchd.DCBD.ToXuLy)
                    txtMaDon.Text = "TXL" + _ctdchd.DCBD.MaDonTXL.ToString().Insert(_ctdchd.DCBD.MaDonTXL.ToString().Length - 2, "-");
                else
                    txtMaDon.Text = _ctdchd.DCBD.MaDon.ToString().Insert(_ctdchd.DCBD.MaDon.ToString().Length - 2, "-");
                txtSoVB.Text = _ctdchd.SoVB;
                dateNgayKy.Value = _ctdchd.NgayKy.Value;
                txtKyHD.Text = _ctdchd.KyHD;
                txtSoHD.Text = _ctdchd.SoHD;
                txtDanhBo.Text = _ctdchd.DanhBo;
                txtHoTen.Text = _ctdchd.HoTen;
                txtDiaChi.Text = _ctdchd.DiaChi;
                ///
                txtGiaBieu_Cu.Text = _ctdchd.GiaBieu.Value.ToString();
                txtDinhMuc_Cu.Text = _ctdchd.DinhMuc.Value.ToString();
                txtTieuThu_Cu.Text = _ctdchd.TieuThu.Value.ToString();
                txtGiaBieu_Moi.Text = _ctdchd.GiaBieu_BD.Value.ToString();
                txtDinhMuc_Moi.Text = _ctdchd.DinhMuc_BD.Value.ToString();
                txtTieuThu_Moi.Text = _ctdchd.TieuThu_BD.Value.ToString();
                ///
                txtTieuThu_Start.Text = _ctdchd.TieuThu.Value.ToString();
                txtTienNuoc_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_Start);
                txtThueGTGT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_Start);
                txtPhiBVMT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_Start);
                txtTongCong_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TongCong_Start);
                txtChiTietCu.Text = _ctdchd.ChiTietCu;
                ///
                if (_ctdchd.DieuChinhGia)
                {
                    chkDieuChinhGia.Checked = true;
                    txtGiaDieuChinh.Text = _ctdchd.GiaDieuChinh.Value.ToString();
                }
                ///
                if (_ctdchd.KhauTru)
                {
                    chkKhauTru.Checked = true;
                    txtSoTienKhauTru.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.SoTienKhauTru.Value);
                }
                ///
                if (_ctdchd.DieuChinhGia2)
                {
                    chkDieuChinhGia2.Checked = true;
                    txtTieuThu_DieuChinhGia2.Text = _ctdchd.TieuThu_DieuChinhGia2.Value.ToString();
                    txtGiaDieuChinh2.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.GiaDieuChinh2.Value);
                }
                ///
                if (_ctdchd.TyLe)
                {
                    chkTyLe.Checked = true;
                    txtSH.Text = _ctdchd.SH.Value.ToString();
                    txtSX.Text = _ctdchd.SX.Value.ToString();
                    txtDV.Text = _ctdchd.DV.Value.ToString();
                    txtHCSN.Text = _ctdchd.HCSN.Value.ToString();
                }
                lbTangGiam.Text = _ctdchd.TangGiam;
                txtTieuThu_BD.Text = (_ctdchd.TieuThu_BD - _ctdchd.TieuThu).Value.ToString();

                txtTienNuoc_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_BD);
                txtThueGTGT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_BD);
                txtPhiBVMT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_BD);
                txtTongCong_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TongCong_BD);

                ///
                txtTieuThu_End.Text = _ctdchd.TieuThu_BD.Value.ToString();
                if (_ctdchd.TienNuoc_End != 0)
                    txtTienNuoc_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_End);
                else
                    txtTienNuoc_End.Text = "0";
                if (_ctdchd.ThueGTGT_End != 0)
                    txtThueGTGT_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_End);
                else
                    txtThueGTGT_End.Text = "0";
                if (_ctdchd.PhiBVMT_End != 0)
                    txtPhiBVMT_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_End);
                else
                    txtPhiBVMT_End.Text = "0";
                if (_ctdchd.TongCong_End != 0)
                    txtTongCong_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TongCong_End);
                else
                    txtTongCong_End.Text = "0";
                txtChiTietMoi.Text = _ctdchd.ChiTietMoi;
            }
            _flag = true;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_ctdchd != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();

                dr["SoPhieu"] = _ctdchd.MaCTDCHD.ToString().Insert(_ctdchd.MaCTDCHD.ToString().Length - 2, "-");
                dr["DanhBo"] = _ctdchd.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = _ctdchd.HoTen;
                if (_ctdchd.DCBD.ToXuLy)
                    dr["SoDon"] = "TXL" + _ctdchd.DCBD.MaDonTXL.Value.ToString().Insert(_ctdchd.DCBD.MaDonTXL.Value.ToString().Length - 2, "-");
                else
                    dr["SoDon"] = _ctdchd.DCBD.MaDon.Value.ToString().Insert(_ctdchd.DCBD.MaDon.Value.ToString().Length - 2, "-");
                dr["NgayKy"] = _ctdchd.NgayKy.Value.ToString("dd/MM/yyyy");
                dr["KyHD"] = _ctdchd.KyHD;
                dr["SoHD"] = _ctdchd.SoHD;
                ///
                dr["TieuThuStart"] = _ctdchd.TieuThu;
                if (_ctdchd.TienNuoc_Start == 0)
                    dr["TienNuocStart"] = "0";
                else
                    dr["TienNuocStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_Start);
                if (_ctdchd.ThueGTGT_Start == 0)
                    dr["ThueGTGTStart"] = 0;
                else
                    dr["ThueGTGTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_Start);
                if (_ctdchd.PhiBVMT_Start == 0)
                    dr["PhiBVMTStart"] = 0;
                else
                    dr["PhiBVMTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_Start);
                if (_ctdchd.TongCong_Start == 0)
                    dr["TongCongStart"] = 0;
                else
                    dr["TongCongStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TongCong_Start);
                ///
                dr["TangGiam"] = _ctdchd.TangGiam;
                ///
                dr["TieuThuBD"] = _ctdchd.TieuThu_BD - _ctdchd.TieuThu;
                if (_ctdchd.TienNuoc_BD == 0)
                    dr["TienNuocBD"] = 0;
                else
                    dr["TienNuocBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_BD);
                if (_ctdchd.ThueGTGT_BD == 0)
                    dr["ThueGTGTBD"] = 0;
                else
                    dr["ThueGTGTBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_BD);
                if (_ctdchd.PhiBVMT_BD == 0)
                    dr["PhiBVMTBD"] = 0;
                else
                    dr["PhiBVMTBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_BD);
                if (_ctdchd.TongCong_BD == 0)
                    dr["TongCongBD"] = 0;
                else
                    dr["TongCongBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TongCong_BD);
                ///
                dr["TieuThuEnd"] = _ctdchd.TieuThu_BD;
                if (_ctdchd.TienNuoc_End == 0)
                    dr["TienNuocEnd"] = 0;
                else
                    dr["TienNuocEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_End);
                if (_ctdchd.ThueGTGT_End == 0)
                    dr["ThueGTGTEnd"] = 0;
                else
                    dr["ThueGTGTEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_End);
                if (_ctdchd.PhiBVMT_End == 0)
                    dr["PhiBVMTEnd"] = 0;
                else
                    dr["PhiBVMTEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_End);
                if (_ctdchd.TongCong_End == 0)
                    dr["TongCongEnd"] = 0;
                else
                    dr["TongCongEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TongCong_End);

                dr["ChucVu"] = _ctdchd.ChucVu;
                dr["NguoiKy"] = _ctdchd.NguoiKy;

                dsBaoCao.Tables["DCHD"].Rows.Add(dr);

                rptPhieuDCHD rpt = new rptPhieuDCHD();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctdchd != null)
                {
                    _ctdchd.DanhBo = txtDanhBo.Text.Trim();
                    _ctdchd.HoTen = txtHoTen.Text.Trim();
                    _ctdchd.DiaChi = txtDiaChi.Text.Trim();
                    _ctdchd.SoVB = txtSoVB.Text.Trim();
                    _ctdchd.NgayKy = dateNgayKy.Value;

                    _ctdchd.KyHD = txtKyHD.Text.Trim();
                    string[] KyHD = txtKyHD.Text.Trim().Split('/');
                    _ctdchd.Ky = int.Parse(KyHD[0]);
                    _ctdchd.Nam = int.Parse(KyHD[1]);

                    _ctdchd.SoHD = txtSoHD.Text.Trim();
                    ///
                    _ctdchd.GiaBieu = int.Parse(txtGiaBieu_Cu.Text.Trim().Replace(".", ""));
                    _ctdchd.DinhMuc = int.Parse(txtDinhMuc_Cu.Text.Trim().Replace(".", ""));
                    _ctdchd.TieuThu = int.Parse(txtTieuThu_Cu.Text.Trim().Replace(".", ""));
                    ///
                    _ctdchd.GiaBieu_BD = int.Parse(txtGiaBieu_Moi.Text.Trim().Replace(".", ""));
                    _ctdchd.DinhMuc_BD = int.Parse(txtDinhMuc_Moi.Text.Trim().Replace(".", ""));
                    _ctdchd.TieuThu_BD = int.Parse(txtTieuThu_Moi.Text.Trim().Replace(".", ""));
                    ///
                    _ctdchd.TienNuoc_Start = int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", ""));
                    _ctdchd.ThueGTGT_Start = int.Parse(txtThueGTGT_Start.Text.Trim().Replace(".", ""));
                    _ctdchd.PhiBVMT_Start = int.Parse(txtPhiBVMT_Start.Text.Trim().Replace(".", ""));
                    _ctdchd.TongCong_Start = int.Parse(txtTongCong_Start.Text.Trim().Replace(".", ""));
                    _ctdchd.ChiTietCu = txtChiTietCu.Text.Trim();
                    ///
                    if (chkDieuChinhGia.Checked)
                    {
                        _ctdchd.DieuChinhGia = true;
                        _ctdchd.TieuThu_DieuChinhGia = _TieuThu_DieuChinhGia;
                        _ctdchd.GiaDieuChinh = int.Parse(txtGiaDieuChinh.Text.Trim().Replace(".", ""));
                    }
                    else
                    {
                        _ctdchd.DieuChinhGia = false;
                        _ctdchd.GiaDieuChinh = null;
                    }
                    ///
                    if (chkKhauTru.Checked)
                    {
                        _ctdchd.KhauTru = true;
                        _ctdchd.SoTienKhauTru = int.Parse(txtSoTienKhauTru.Text.Trim().Replace(".", ""));
                    }
                    else
                    {
                        _ctdchd.KhauTru = false;
                        _ctdchd.SoTienKhauTru = null;
                    }
                    ///
                    if (chkDieuChinhGia2.Checked)
                    {
                        _ctdchd.DieuChinhGia2 = true;
                        _ctdchd.TieuThu_DieuChinhGia2 = int.Parse(txtTieuThu_DieuChinhGia2.Text.Trim().Replace(".", ""));
                        _ctdchd.GiaDieuChinh2 = int.Parse(txtGiaDieuChinh2.Text.Trim().Replace(".", ""));
                    }
                    else
                    {
                        _ctdchd.DieuChinhGia2 = false;
                        _ctdchd.TieuThu_DieuChinhGia2 = null;
                        _ctdchd.GiaDieuChinh2 = null;
                    }
                    ///
                    if (chkTyLe.Checked)
                    {
                        _ctdchd.TyLe = true;
                        _ctdchd.SH = int.Parse(txtSH.Text.Trim().Replace(".", ""));
                        _ctdchd.SX = int.Parse(txtSX.Text.Trim().Replace(".", ""));
                        _ctdchd.DV = int.Parse(txtDV.Text.Trim().Replace(".", ""));
                        _ctdchd.HCSN = int.Parse(txtHCSN.Text.Trim().Replace(".", ""));
                    }
                    else
                    {
                        _ctdchd.TyLe = false;
                        _ctdchd.SH = null;
                        _ctdchd.SX = null;
                        _ctdchd.DV = null;
                        _ctdchd.HCSN = null;
                    }
                    _ctdchd.TienNuoc_BD = int.Parse(txtTienNuoc_BD.Text.Trim().Replace(".", ""));
                    _ctdchd.ThueGTGT_BD = int.Parse(txtThueGTGT_BD.Text.Trim().Replace(".", ""));
                    _ctdchd.PhiBVMT_BD = int.Parse(txtPhiBVMT_BD.Text.Trim().Replace(".", ""));
                    _ctdchd.TongCong_BD = int.Parse(txtTongCong_BD.Text.Trim().Replace(".", ""));
                    ///
                    _ctdchd.TienNuoc_End = int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", ""));
                    _ctdchd.ThueGTGT_End = int.Parse(txtThueGTGT_End.Text.Trim().Replace(".", ""));
                    _ctdchd.PhiBVMT_End = int.Parse(txtPhiBVMT_End.Text.Trim().Replace(".", ""));
                    _ctdchd.TongCong_End = int.Parse(txtTongCong_End.Text.Trim().Replace(".", ""));
                    _ctdchd.ChiTietMoi = txtChiTietMoi.Text.Trim();

                    if (_ctdchd.TienNuoc_End - _ctdchd.TienNuoc_Start == 0)
                        _ctdchd.TangGiam = "";
                    else
                        if (_ctdchd.TienNuoc_End - _ctdchd.TienNuoc_Start > 0)
                            _ctdchd.TangGiam = "Tăng";
                        else
                            _ctdchd.TangGiam = "Giảm";

                    if (_cDCBD.SuaCTDCHD(_ctdchd))
                        MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #region Configure TextBox

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

        private void txtGiaBieu_Cu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                txtDinhMuc_Cu.Focus();
        }

        private void txtDinhMuc_Cu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                txtTieuThu_Cu.Focus();
        }

        private void txtTieuThu_Cu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
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
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                txtGiaBieu_Moi.Focus();
        }

        private void txtGiaBieu_Moi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                txtDinhMuc_Moi.Focus();
        }

        private void txtDinhMuc_Moi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                txtTieuThu_Moi.Focus();
        }

        private void txtTieuThu_Moi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                btnSua.Focus();
        }

        #endregion

        private void txtGiaBieu_Cu_TextChanged(object sender, EventArgs e)
        {
            if (_flag)
                if (txtGiaBieu_Cu.Text.Trim() != "")
                    TinhTienNuoc();
        }

        private void txtDinhMuc_Cu_TextChanged(object sender, EventArgs e)
        {
            if (_flag)
                if (txtDinhMuc_Cu.Text.Trim() != "")
                    TinhTienNuoc();
        }

        private void txtTieuThu_Cu_TextChanged(object sender, EventArgs e)
        {
            if (_flag)
                if (txtTieuThu_Cu.Text.Trim() != "")
                    TinhTienNuoc();
        }

        private void txtGiaDieuChinh_TextChanged(object sender, EventArgs e)
        {
            if (_flag)
                if (txtGiaDieuChinh.Text.Trim() != "")
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

        private void txtGiaBieu_Moi_TextChanged(object sender, EventArgs e)
        {
            if (_flag)
                if (txtGiaBieu_Moi.Text.Trim() != "")
                    TinhTienNuoc();
        }

        private void txtDinhMuc_Moi_TextChanged(object sender, EventArgs e)
        {
            if (_flag)
                if (txtDinhMuc_Moi.Text.Trim() != "")
                    TinhTienNuoc();
        }

        private void txtTieuThu_Moi_TextChanged(object sender, EventArgs e)
        {
            if (_flag)
                if (txtTieuThu_Moi.Text.Trim() != "")
                    TinhTienNuoc();
        }

        private void TinhTienNuoc()
        {
            try
            {
                //string ChiTietCu = "";
                string ChiTietMoi = "";
                //int TieuThu_DieuChinhGia = 0;
                //int TongTienCu = 0;
                int TongTienMoi = 0;
                //TongTienCu = _cGiaNuoc.TinhTienNuoc(false, int.Parse(txtGiaDieuChinh.Text.Trim()), txtDanhBo.Text.Trim(), int.Parse(txtGiaBieu_Cu.Text.Trim()), int.Parse(txtDinhMuc_Cu.Text.Trim()), int.Parse(txtTieuThu_Cu.Text.Trim()), out ChiTietCu, out TieuThu_DieuChinhGia);
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
                //txtChiTietCu.Text = ChiTietCu;
                txtChiTietMoi.Text = ChiTietMoi;
                ///Tiêu Thụ
                //txtTieuThu_Start.Text = txtTieuThu_Cu.Text.Trim();
                txtTieuThu_BD.Text = (int.Parse(txtTieuThu_Moi.Text.Trim()) - int.Parse(txtTieuThu_Cu.Text.Trim())).ToString();
                txtTieuThu_End.Text = txtTieuThu_Moi.Text.Trim();
                ///Tiền Nước
                //if (TongTienCu != 0)
                //    txtTienNuoc_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongTienCu);
                //else
                //    txtTienNuoc_Start.Text = "0";

                if (TongTienMoi != 0)
                    txtTienNuoc_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongTienMoi);
                else
                    txtTienNuoc_End.Text = "0";

                if (TongTienMoi - int.Parse(txtTienNuoc_Start.Text.Replace(".","")) != 0)
                    txtTienNuoc_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongTienMoi - int.Parse(txtTienNuoc_Start.Text.Replace(".", "")));
                else
                    txtTienNuoc_BD.Text = "0";

                

                ///Thuế GTGT
                //if (TongTienCu != 0)
                //    txtThueGTGT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", Math.Round((double)TongTienCu * 5 / 100 + 0.1));
                //else
                //    txtThueGTGT_Start.Text = "0";

                if (TongTienMoi != 0)
                    txtThueGTGT_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", Math.Round((double)TongTienMoi * 5 / 100 + 0.1));
                else
                    txtThueGTGT_End.Text = "0";

                if (TongTienMoi - int.Parse(txtTienNuoc_Start.Text.Replace(".", "")) != 0)
                    txtThueGTGT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (Math.Round((double)TongTienMoi * 5 / 100 + 0.1) - Math.Round((double)int.Parse(txtTienNuoc_Start.Text.Replace(".", "")) * 5 / 100 + 0.1)));
                else
                    txtThueGTGT_BD.Text = "0";

                

                ///Phí BVMT
                //if (TongTienCu != 0)
                //    txtPhiBVMT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (TongTienCu * 10 / 100));
                //else
                //    txtPhiBVMT_Start.Text = "0";

                if (TongTienMoi != 0)
                    txtPhiBVMT_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (TongTienMoi * 10 / 100));
                else
                    txtPhiBVMT_End.Text = "0";

                if (TongTienMoi - int.Parse(txtTienNuoc_Start.Text.Replace(".", "")) != 0)
                    txtPhiBVMT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ((TongTienMoi * 10 / 100) - (int.Parse(txtTienNuoc_Start.Text.Replace(".", "")) * 10 / 100)));
                else
                    txtPhiBVMT_BD.Text = "0";

                

                ///Tổng Cộng
                //if (TongTienCu != 0)
                //    txtTongCong_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (TongTienCu + Math.Round((double)TongTienCu * 5 / 100 + 0.1) + (TongTienCu * 10 / 100)));
                //else
                //    txtTongCong_Start.Text = "0";

                if (TongTienMoi != 0)
                    txtTongCong_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100 + 0.1) + (TongTienMoi * 10 / 100)));
                else
                    txtTongCong_End.Text = "0";

                if (TongTienMoi - int.Parse(txtTienNuoc_Start.Text.Replace(".", "")) != 0)
                    txtTongCong_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ((TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100 + 0.1) + (TongTienMoi * 10 / 100)) - (int.Parse(txtTienNuoc_Start.Text.Replace(".", "")) + Math.Round((double)int.Parse(txtTienNuoc_Start.Text.Replace(".", "")) * 5 / 100 + 0.1) + (int.Parse(txtTienNuoc_Start.Text.Replace(".", "")) * 10 / 100))));
                else
                    txtTongCong_BD.Text = "0";

               

                ///
                if (TongTienMoi - int.Parse(txtTienNuoc_Start.Text.Replace(".", "")) == 0)
                    lbTangGiam.Text = "";
                else
                    if (TongTienMoi - int.Parse(txtTienNuoc_Start.Text.Replace(".", "")) > 0)
                        lbTangGiam.Text = "Tăng:";
                    else
                        lbTangGiam.Text = "Giảm:";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_ctdchd != null)
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (_cDCBD.XoaCTDCHD(_ctdchd))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
        }

        private void btnInA4_Click(object sender, EventArgs e)
        {
            if (_ctdchd != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();

                dr["SoPhieu"] = _ctdchd.MaCTDCHD.ToString().Insert(_ctdchd.MaCTDCHD.ToString().Length - 2, "-");
                dr["DanhBo"] = _ctdchd.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = _ctdchd.HoTen;
                dr["DiaChi"] = _ctdchd.DiaChi;
                if (_ctdchd.DCBD.ToXuLy)
                    dr["SoDon"] = "TXL" + _ctdchd.DCBD.MaDonTXL.Value.ToString().Insert(_ctdchd.DCBD.MaDonTXL.Value.ToString().Length - 2, "-");
                else
                    dr["SoDon"] = _ctdchd.DCBD.MaDon.Value.ToString().Insert(_ctdchd.DCBD.MaDon.Value.ToString().Length - 2, "-");
                dr["NgayKy"] = _ctdchd.NgayKy.Value.ToString("dd/MM/yyyy");
                dr["KyHD"] = _ctdchd.KyHD;
                dr["SoHD"] = _ctdchd.SoHD;
                ///
                dr["DieuChinh"] = "";
                if (_ctdchd.GiaBieu != _ctdchd.GiaBieu_BD)
                    dr["DieuChinh"] = "Giá Biểu từ " + _ctdchd.GiaBieu + " -> " + _ctdchd.GiaBieu_BD;
                if (_ctdchd.DinhMuc != _ctdchd.DinhMuc_BD)
                    if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                        dr["DieuChinh"] = "Định Mức từ " + _ctdchd.DinhMuc + " -> " + _ctdchd.DinhMuc_BD;
                    else
                        dr["DieuChinh"] = dr["DieuChinh"] + ", Định Mức từ " + _ctdchd.DinhMuc + " -> " + _ctdchd.DinhMuc_BD;
                if (_ctdchd.TieuThu != _ctdchd.TieuThu_BD)
                    if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                        dr["DieuChinh"] = "Tiêu Thụ từ " + _ctdchd.TieuThu + " -> " + _ctdchd.TieuThu_BD;
                    else
                        dr["DieuChinh"] = dr["DieuChinh"] + ", Tiêu Thụ từ " + _ctdchd.TieuThu + " -> " + _ctdchd.TieuThu_BD;
                if (_ctdchd.DieuChinhGia == true)
                {
                    switch (_ctdchd.GiaBieu_BD)
                    {
                        case 51:
                        case 52:
                        case 53:
                        case 54:
                        case 59:
                        case 68:
                            if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                                if (_ctdchd.TieuThu_DieuChinhGia == _ctdchd.TieuThu_BD)
                                    dr["DieuChinh"] = _ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + (_ctdchd.GiaDieuChinh.Value - _ctdchd.GiaDieuChinh.Value * CTaiKhoan.GiamTienNuoc / 100).ToString();
                                else
                                    dr["DieuChinh"] = _ctdchd.DinhMuc_BD + "m3 Áp giá " + (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100).ToString() + ", " + _ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + (_ctdchd.GiaDieuChinh.Value - _ctdchd.GiaDieuChinh.Value * CTaiKhoan.GiamTienNuoc / 100).ToString();
                            else
                                if (_ctdchd.TieuThu_DieuChinhGia == _ctdchd.TieuThu_BD)
                                    dr["DieuChinh"] = dr["DieuChinh"] + ", " + _ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + (_ctdchd.GiaDieuChinh.Value - _ctdchd.GiaDieuChinh.Value * CTaiKhoan.GiamTienNuoc / 100).ToString();
                                else
                                    dr["DieuChinh"] = dr["DieuChinh"] + ", " + _ctdchd.DinhMuc_BD + "m3 Áp giá " + (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100).ToString() + ", " + _ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + (_ctdchd.GiaDieuChinh.Value - _ctdchd.GiaDieuChinh.Value * CTaiKhoan.GiamTienNuoc / 100).ToString();
                            break;
                        default:
                            if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                                if (_ctdchd.TieuThu_DieuChinhGia == _ctdchd.TieuThu_BD)
                                    dr["DieuChinh"] = _ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + _ctdchd.GiaDieuChinh.Value;
                                else
                                    dr["DieuChinh"] = _ctdchd.DinhMuc_BD + "m3 Áp giá " + lstGiaNuoc[0].DonGia.Value + ", " + _ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + _ctdchd.GiaDieuChinh.Value;
                            else
                                if (_ctdchd.TieuThu_DieuChinhGia == _ctdchd.TieuThu_BD)
                                    dr["DieuChinh"] = dr["DieuChinh"] + ", " + _ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + _ctdchd.GiaDieuChinh.Value;
                                else
                                    dr["DieuChinh"] = dr["DieuChinh"] + ", " + _ctdchd.DinhMuc_BD + "m3 Áp giá " + lstGiaNuoc[0].DonGia.Value + ", " + _ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + _ctdchd.GiaDieuChinh.Value;
                            break;
                    }
                    
                    dr["ChiTietCu"] = _ctdchd.ChiTietCu;
                    dr["ChiTietMoi"] = _ctdchd.ChiTietMoi;
                }
                if (_ctdchd.TyLe)
                {
                    if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                        dr["DieuChinh"] = "Tỷ lệ";
                    else
                        dr["DieuChinh"] = dr["DieuChinh"] + ", Tỷ lệ";
                    if (_ctdchd.SH != 0)
                        dr["DieuChinh"] = dr["DieuChinh"] + " SH: " + _ctdchd.SH.Value.ToString() + "%";
                    if (_ctdchd.SX != 0)
                        dr["DieuChinh"] = dr["DieuChinh"] + " SX: " + _ctdchd.SX.Value.ToString() + "%";
                    if (_ctdchd.DV != 0)
                        dr["DieuChinh"] = dr["DieuChinh"] + " DV: " + _ctdchd.DV.Value.ToString() + "%";
                    if (_ctdchd.HCSN != 0)
                        dr["DieuChinh"] = dr["DieuChinh"] + " HCSN: " + _ctdchd.HCSN.Value.ToString() + "%";
                    dr["ChiTietCu"] = _ctdchd.ChiTietCu;
                    dr["ChiTietMoi"] = _ctdchd.ChiTietMoi;
                }
                ///
                dr["GiaBieuStart"] = _ctdchd.GiaBieu;
                dr["GiaBieuEnd"] = _ctdchd.GiaBieu_BD;
                dr["DinhMucStart"] = _ctdchd.DinhMuc;
                dr["DinhMucEnd"] = _ctdchd.DinhMuc_BD;
                dr["TieuThuStart"] = _ctdchd.TieuThu;
                if (_ctdchd.TienNuoc_Start == 0)
                    dr["TienNuocStart"] = "0";
                else
                    dr["TienNuocStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_Start);
                if (_ctdchd.ThueGTGT_Start == 0)
                    dr["ThueGTGTStart"] = 0;
                else
                    dr["ThueGTGTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_Start);
                if (_ctdchd.PhiBVMT_Start == 0)
                    dr["PhiBVMTStart"] = 0;
                else
                    dr["PhiBVMTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_Start);
                if (_ctdchd.TongCong_Start == 0)
                    dr["TongCongStart"] = 0;
                else
                    dr["TongCongStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TongCong_Start);
                ///
                dr["TangGiam"] = _ctdchd.TangGiam;
                ///
                dr["TieuThuBD"] = _ctdchd.TieuThu_BD - _ctdchd.TieuThu;
                if (_ctdchd.TienNuoc_BD == 0)
                    dr["TienNuocBD"] = 0;
                else
                    dr["TienNuocBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_BD);
                if (_ctdchd.ThueGTGT_BD == 0)
                    dr["ThueGTGTBD"] = 0;
                else
                    dr["ThueGTGTBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_BD);
                if (_ctdchd.PhiBVMT_BD == 0)
                    dr["PhiBVMTBD"] = 0;
                else
                    dr["PhiBVMTBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_BD);
                if (_ctdchd.TongCong_BD == 0)
                    dr["TongCongBD"] = 0;
                else
                    dr["TongCongBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TongCong_BD);
                ///
                dr["TieuThuEnd"] = _ctdchd.TieuThu_BD;
                if (_ctdchd.TienNuoc_End == 0)
                    dr["TienNuocEnd"] = 0;
                else
                    dr["TienNuocEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_End);
                if (_ctdchd.ThueGTGT_End == 0)
                    dr["ThueGTGTEnd"] = 0;
                else
                    dr["ThueGTGTEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_End);
                if (_ctdchd.PhiBVMT_End == 0)
                    dr["PhiBVMTEnd"] = 0;
                else
                    dr["PhiBVMTEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_End);
                if (_ctdchd.TongCong_End == 0)
                    dr["TongCongEnd"] = 0;
                else
                    dr["TongCongEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TongCong_End);

                dr["ChucVu"] = _ctdchd.ChucVu;
                dr["NguoiKy"] = _ctdchd.NguoiKy;

                dsBaoCao.Tables["DCHD"].Rows.Add(dr);

                rptThongBaoDCHD rpt = new rptThongBaoDCHD();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void chkDieuChinhGia2_CheckedChanged(object sender, EventArgs e)
        {
            if (!_flag)
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
            if (!_flag)
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

        private void txtTienNuoc_BD_TextChanged(object sender, EventArgs e)
        {
            if (_flag && txtTienNuoc_BD.Text.Length > 1)
                CongTruTienNuocBD();
        }

        private void txtThueGTGT_BD_TextChanged(object sender, EventArgs e)
        {
            if (_flag && txtThueGTGT_BD.Text.Length > 1)
                CongTruTienNuocBD();
        }

        private void txtPhiBVMT_BD_TextChanged(object sender, EventArgs e)
        {
            if (_flag && txtPhiBVMT_BD.Text.Length > 1)
                CongTruTienNuocBD();
        }

        private void txtTongCong_BD_TextChanged(object sender, EventArgs e)
        {
            if (_flag && txtTongCong_BD.Text.Length > 1)
                CongTruTienNuocBD();
        }

        private void txtTienNuoc_End_TextChanged(object sender, EventArgs e)
        {
            if (_flag && txtTienNuoc_End.Text.Length > 0)
                CongTruTienNuoc();
        }

        private void txtThueGTGT_End_TextChanged(object sender, EventArgs e)
        {
            if (_flag && txtThueGTGT_End.Text.Length > 0)
                CongTruTienNuoc();
        }

        private void txtPhiBVMT_End_TextChanged(object sender, EventArgs e)
        {
            if (_flag && txtPhiBVMT_End.Text.Length >0)
                CongTruTienNuoc();
        }

        private void txtTongCong_End_TextChanged(object sender, EventArgs e)
        {
            if (_flag && txtTongCong_End.Text.Length > 0)
                CongTruTienNuoc();
        }

        private void txtPhiBVMT_Start_TextChanged(object sender, EventArgs e)
        {
            if (_flag && txtPhiBVMT_Start.Text.Length >0)
                CongTruTienNuoc();
        }

        private void txtTienNuoc_Start_TextChanged(object sender, EventArgs e)
        {
            if (_flag && txtTienNuoc_Start.Text.Length > 0)
                CongTruTienNuoc();
        }

        private void txtThueGTGT_Start_TextChanged(object sender, EventArgs e)
        {
            if (_flag && txtThueGTGT_Start.Text.Length > 0)
                CongTruTienNuoc();
        }

        private void txtTongCong_Start_TextChanged(object sender, EventArgs e)
        {
            if (_flag && txtTongCong_Start.Text.Length > 0)
                CongTruTienNuoc();
        }

        public void CongTruTienNuoc()
        {
            txtTongCong_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", "")) + int.Parse(txtThueGTGT_Start.Text.Trim().Replace(".", "")) + int.Parse(txtPhiBVMT_Start.Text.Trim().Replace(".", "")));
            txtTongCong_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", "")) + int.Parse(txtThueGTGT_End.Text.Trim().Replace(".", "")) + int.Parse(txtPhiBVMT_End.Text.Trim().Replace(".", "")));

            txtTienNuoc_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", "")) - int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", "")));
            txtThueGTGT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(txtThueGTGT_End.Text.Trim().Replace(".", "")) - int.Parse(txtThueGTGT_Start.Text.Trim().Replace(".", "")));
            txtPhiBVMT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(txtPhiBVMT_End.Text.Trim().Replace(".", "")) - int.Parse(txtPhiBVMT_Start.Text.Trim().Replace(".", "")));
            txtTongCong_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(txtTongCong_End.Text.Trim().Replace(".", "")) - int.Parse(txtTongCong_Start.Text.Trim().Replace(".", "")));
        }

        public void CongTruTienNuocBD()
        {
            txtTienNuoc_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", "")) + int.Parse(txtTienNuoc_BD.Text.Trim().Replace(".", "")));
            txtThueGTGT_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(txtThueGTGT_Start.Text.Trim().Replace(".", "")) + int.Parse(txtThueGTGT_BD.Text.Trim().Replace(".", "")));
            txtPhiBVMT_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(txtPhiBVMT_Start.Text.Trim().Replace(".", "")) + int.Parse(txtPhiBVMT_BD.Text.Trim().Replace(".", "")));
            txtTongCong_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(txtTongCong_Start.Text.Trim().Replace(".", "")) + int.Parse(txtTongCong_BD.Text.Trim().Replace(".", "")));
        }
    }
}

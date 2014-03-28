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

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmShowDCHD : Form
    {
        decimal _MaCTDCHD = 0;
        CDCBD _cDCBD = new CDCBD();
        CTDCHD _ctdchd = null;
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();

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
            if (_cDCBD.getCTDCHDbyID(_MaCTDCHD) != null)
            {
                this.Location = new Point(70, 70);
                _ctdchd = _cDCBD.getCTDCHDbyID(_MaCTDCHD);
                if (_ctdchd.DCBD.ToXuLy)
                    txtMaDon.Text = "TXL"+_ctdchd.DCBD.MaDonTXL.ToString().Insert(_ctdchd.DCBD.MaDonTXL.ToString().Length - 2, "-");
                else
                    txtMaDon.Text = _ctdchd.DCBD.MaDon.ToString().Insert(_ctdchd.DCBD.MaDon.ToString().Length - 2, "-");
                txtSoVB.Text = _ctdchd.SoVB;
                dateNgayKy.Value = _ctdchd.NgayKy.Value;
                txtKyHD.Text = _ctdchd.KyHD;
                txtSoHD.Text = _ctdchd.SoHD;
                txtDanhBo.Text = _ctdchd.DanhBo;
                txtHoTen.Text = _ctdchd.HoTen;
                ///
                txtGiaBieu_Cu.Text = _ctdchd.GiaBieu.Value.ToString();
                txtDinhMuc_Cu.Text = _ctdchd.DinhMuc.Value.ToString();
                txtTieuThu_Cu.Text = _ctdchd.TieuThu.Value.ToString();
                txtGiaBieu_Moi.Text = _ctdchd.GiaBieu_BD.Value.ToString();
                txtDinhMuc_Moi.Text = _ctdchd.DinhMuc_BD.Value.ToString();
                txtTieuThu_Moi.Text = _ctdchd.TieuThu_BD.Value.ToString();
                ///
                txtTieuThu_Start.Text = _ctdchd.TieuThu.Value.ToString();
                txtTienNuoc_Start.Text = _ctdchd.TienNuoc_Start.Value.ToString();
                txtThueGTGT_Start.Text = _ctdchd.ThueGTGT_Start.Value.ToString();
                txtPhiBVMT_Start.Text = _ctdchd.PhiBVMT_Start.Value.ToString();
                txtTongCong_Start.Text = _ctdchd.TongCong_Start.Value.ToString();
                ///
                if (_ctdchd.DieuChinhGia)
                {
                    chkGiaDieuChinh.Checked = true;
                    txtGiaDieuChinh.Text = _ctdchd.GiaDieuChinh.ToString();
                }
                ///
                lbTangGiam.Text = _ctdchd.TangGiam;
                txtTieuThu_BD.Text = (_ctdchd.TieuThu_BD - _ctdchd.TieuThu).Value.ToString();
                txtTienNuoc_BD.Text = _ctdchd.TienNuoc_BD.Value.ToString();
                txtThueGTGT_BD.Text = _ctdchd.ThueGTGT_BD.Value.ToString();
                txtPhiBVMT_BD.Text = _ctdchd.PhiBVMT_BD.Value.ToString();
                txtTongCong_BD.Text = _ctdchd.TongCong_BD.Value.ToString();
                ///
                txtTieuThu_End.Text = _ctdchd.TieuThu_BD.Value.ToString();
                txtTienNuoc_End.Text = _ctdchd.TienNuoc_End.Value.ToString();
                txtThueGTGT_End.Text = _ctdchd.ThueGTGT_End.Value.ToString();
                txtPhiBVMT_End.Text = _ctdchd.PhiBVMT_End.Value.ToString();
                txtTongCong_End.Text = _ctdchd.TongCong_End.Value.ToString();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_ctdchd != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();

                dr["SoPhieu"] = _ctdchd.MaCTDCHD.ToString().Insert(_ctdchd.MaCTDCHD.ToString().Length - 2, "-");
                dr["DanhBo"] = _ctdchd.DanhBo.Insert(7, " ").Insert(4, " "); ;
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
                dr["PhiBVMTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_ctdchd.PhiBVMT_Start);
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
                dr["TienNuocEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",_ctdchd.TienNuoc_End);
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
                frmBaoCao frm = new frmBaoCao(rpt);
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
                    _ctdchd.SoVB = txtSoVB.Text.Trim();
                    _ctdchd.NgayKy = dateNgayKy.Value;
                    _ctdchd.KyHD = txtKyHD.Text.Trim();
                    _ctdchd.SoHD = txtSoHD.Text.Trim();
                    ///
                    _ctdchd.GiaBieu = int.Parse(txtGiaBieu_Cu.Text.Trim());
                    _ctdchd.DinhMuc = int.Parse(txtDinhMuc_Cu.Text.Trim());
                    _ctdchd.TieuThu = int.Parse(txtTieuThu_Cu.Text.Trim());
                    ///
                    _ctdchd.GiaBieu_BD = int.Parse(txtGiaBieu_Moi.Text.Trim());
                    _ctdchd.DinhMuc_BD = int.Parse(txtDinhMuc_Moi.Text.Trim());
                    _ctdchd.TieuThu_BD = int.Parse(txtTieuThu_Moi.Text.Trim());
                    ///
                    _ctdchd.TienNuoc_Start = int.Parse(txtTienNuoc_Start.Text.Trim());
                    _ctdchd.ThueGTGT_Start = int.Parse(txtThueGTGT_Start.Text.Trim());
                    _ctdchd.PhiBVMT_Start = int.Parse(txtPhiBVMT_Start.Text.Trim());
                    _ctdchd.TongCong_Start = int.Parse(txtTongCong_Start.Text.Trim());
                    ///
                    if (chkGiaDieuChinh.Checked)
                    {
                        _ctdchd.DieuChinhGia = true;
                        _ctdchd.GiaDieuChinh = int.Parse(txtGiaDieuChinh.Text.Trim());
                    }
                    ///
                    _ctdchd.TienNuoc_BD = int.Parse(txtTienNuoc_BD.Text.Trim());
                    _ctdchd.ThueGTGT_BD = int.Parse(txtThueGTGT_BD.Text.Trim());
                    _ctdchd.PhiBVMT_BD = int.Parse(txtPhiBVMT_BD.Text.Trim());
                    _ctdchd.TongCong_BD = int.Parse(txtTongCong_BD.Text.Trim());
                    ///
                    _ctdchd.TienNuoc_End = int.Parse(txtTienNuoc_End.Text.Trim());
                    _ctdchd.ThueGTGT_End = int.Parse(txtThueGTGT_End.Text.Trim());
                    _ctdchd.PhiBVMT_End = int.Parse(txtPhiBVMT_End.Text.Trim());
                    _ctdchd.TongCong_End = int.Parse(txtTongCong_End.Text.Trim());

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
                chkGiaDieuChinh.Focus();
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
            if (txtGiaBieu_Cu.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtDinhMuc_Cu_TextChanged(object sender, EventArgs e)
        {
            if (txtDinhMuc_Cu.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtTieuThu_Cu_TextChanged(object sender, EventArgs e)
        {
            if (txtTieuThu_Cu.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtGiaDieuChinh_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaDieuChinh.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void chkGiaDieuChinh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGiaDieuChinh.Checked)
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
            int TongTienCu = _cGiaNuoc.TinhTienNuoc(false, int.Parse(txtGiaDieuChinh.Text.Trim()), txtDanhBo.Text.Trim(), int.Parse(txtGiaBieu_Cu.Text.Trim()), int.Parse(txtDinhMuc_Cu.Text.Trim()), int.Parse(txtTieuThu_Cu.Text.Trim()), out ChiTietCu);
            int TongTienMoi = _cGiaNuoc.TinhTienNuoc(chkGiaDieuChinh.Checked, int.Parse(txtGiaDieuChinh.Text.Trim()), txtDanhBo.Text.Trim(), int.Parse(txtGiaBieu_Moi.Text.Trim()), int.Parse(txtDinhMuc_Moi.Text.Trim()), int.Parse(txtTieuThu_Moi.Text.Trim()), out ChiTietMoi);
            ///Chi Tiết
            txtChiTietCu.Text = ChiTietCu;
            txtChiTietMoi.Text = ChiTietMoi;
            ///Tiêu Thụ
            txtTieuThu_Start.Text = txtTieuThu_Cu.Text.Trim();
            txtTieuThu_BD.Text = (int.Parse(txtTieuThu_Moi.Text.Trim()) - int.Parse(txtTieuThu_Cu.Text.Trim())).ToString();
            txtTieuThu_End.Text = txtTieuThu_Moi.Text.Trim();
            ///Tiền Nước
            txtTienNuoc_Start.Text = TongTienCu.ToString();
            txtTienNuoc_BD.Text = (TongTienMoi - TongTienCu).ToString();
            txtTienNuoc_End.Text = TongTienMoi.ToString();
            ///Thuế GTGT
            txtThueGTGT_Start.Text = Math.Round((double)TongTienCu * 5 / 100).ToString();
            txtThueGTGT_BD.Text = (Math.Round((double)TongTienMoi * 5 / 100) - Math.Round((double)TongTienCu * 5 / 100)).ToString();
            txtThueGTGT_End.Text = Math.Round((double)TongTienMoi * 5 / 100).ToString();
            ///Phí BVMT
            txtPhiBVMT_Start.Text = (TongTienCu * 10 / 100).ToString();
            txtPhiBVMT_BD.Text = ((TongTienMoi * 10 / 100) - (TongTienCu * 10 / 100)).ToString();
            txtPhiBVMT_End.Text = (TongTienMoi * 10 / 100).ToString();
            ///Tổng Cộng
            txtTongCong_Start.Text = (TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + (TongTienCu * 10 / 100)).ToString();
            txtTongCong_BD.Text = ((TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + (TongTienMoi * 10 / 100)) - (TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + (TongTienCu * 10 / 100))).ToString();
            txtTongCong_End.Text = (TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + (TongTienMoi * 10 / 100)).ToString();

            if (TongTienMoi - TongTienCu == 0)
                lbTangGiam.Text = "";
            else
                if (TongTienMoi - TongTienCu > 0)
                    lbTangGiam.Text = "Tăng:";
                else
                    lbTangGiam.Text = "Giảm:";
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.BaoCao;
using System.Globalization;
using KTKS_DonKH.BaoCao.CatHuyDanhBo;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmYCCHDB : Form
    {
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        TTKhachHang _ttkhachhang = null;
        CTTKH _cTTKH = new CTTKH();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CCHDB _cCHDB = new CCHDB();
        YeuCauCHDB _ycchdb = null;

        public frmYCCHDB()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        /// <summary>
        /// Nhận Entity TTKhachHang để điền vào textbox
        /// </summary>
        /// <param name="ttkhachhang"></param>
        public void LoadTTKH(TTKhachHang ttkhachhang)
        {
            txtDanhBo.Text = ttkhachhang.DanhBo;
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            ///
            cmbLyDo.SelectedIndex = 0;
            txtSoTien.Text = "";
            txtGhiChuXuLy.Text = "";
            txtHieuLucKy.Text = "";
            ///
            txtHieuLucKy.Text = "";
            _ttkhachhang = null;
            _donkh = null;
            _dontxl = null;
            _ycchdb = null;
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
                        txtMaDon.Text = "TXL"+_dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");
                        if (_cTTKH.getTTKHbyID(_dontxl.DanhBo) != null)
                        {
                            _ttkhachhang = _cTTKH.getTTKHbyID(_dontxl.DanhBo);
                            LoadTTKH(_ttkhachhang);
                        }
                        else
                        {
                            Clear();
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        //_dontxl = null;
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
                    if (_cTTKH.getTTKHbyID(_donkh.DanhBo) != null)
                    {
                        _ttkhachhang = _cTTKH.getTTKHbyID(_donkh.DanhBo);
                        LoadTTKH(_ttkhachhang);
                    }
                    else
                    {
                        Clear();
                        MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //_donkh = null;
                    Clear();
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbLyDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLyDo.SelectedItem.ToString().ToUpper().Contains("TIỀN"))
                txtSoTien.ReadOnly = false;
            else
                txtSoTien.ReadOnly = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ///Nếu đơn thuộc Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_dontxl != null && cmbLyDo.SelectedIndex != -1)
                    {
                        if (!_cCHDB.CheckYCCHDBbyMaDonDanhBo_TXL(_dontxl.MaDon, _dontxl.DanhBo))
                        {
                            YeuCauCHDB ycchdb = new YeuCauCHDB();
                            ycchdb.ToXuLy = true;
                            ycchdb.MaDonTXL = _dontxl.MaDon;
                            ycchdb.DanhBo = txtDanhBo.Text.Trim();
                            ycchdb.HopDong = txtHopDong.Text.Trim();
                            ycchdb.HoTen = txtHoTen.Text.Trim();
                            ycchdb.DiaChi = txtDiaChi.Text.Trim();
                            if (_ttkhachhang != null)
                            {
                                ycchdb.Dot = _ttkhachhang.Dot;
                                ycchdb.Ky = _ttkhachhang.Ky;
                                ycchdb.Nam = _ttkhachhang.Nam;
                            }
                            ycchdb.LyDo = cmbLyDo.SelectedItem.ToString();
                            ycchdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                            if (txtSoTien.Text.Trim() != "")
                                ycchdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                            ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                            ///Ký Tên
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ycchdb.ChucVu = "GIÁM ĐỐC";
                            else
                                ycchdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ycchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            ycchdb.PhieuDuocKy = true;

                            if (_cCHDB.ThemYeuCauCHDB(ycchdb))
                            {
                                if (string.IsNullOrEmpty(_dontxl.TienTrinh))
                                    _dontxl.TienTrinh = "CHDB";
                                else
                                    _dontxl.TienTrinh += ",CHDB";
                                _dontxl.Nhan = true;
                                _cDonTXL.SuaDonTXL(_dontxl, true);
                                MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                DataRow dr = dsBaoCao.Tables["PhieuCHDB"].NewRow();

                                dr["SoPhieu"] = ycchdb.MaYCCHDB.ToString().Insert(ycchdb.MaYCCHDB.ToString().Length - 2, "-");
                                dr["HieuLucKy"] = ycchdb.HieuLucKy;
                                dr["Dot"] = ycchdb.Dot;
                                dr["HoTen"] = ycchdb.HoTen;
                                dr["DiaChi"] = ycchdb.DiaChi;
                                dr["DanhBo"] = ycchdb.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["HopDong"] = ycchdb.HopDong;

                                if (ycchdb.LyDo == "Vấn Đề Khác")
                                    dr["LyDo"] = "";
                                else
                                    dr["LyDo"] = ycchdb.LyDo + ". ";

                                if (ycchdb.GhiChuLyDo != "")
                                    dr["LyDo"] += ycchdb.GhiChuLyDo + ". ";
                                if (ycchdb.SoTien.ToString() != "")
                                    dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ycchdb.SoTien);

                                dr["ChucVu"] = ycchdb.ChucVu;
                                dr["NguoiKy"] = ycchdb.NguoiKy;

                                dsBaoCao.Tables["PhieuCHDB"].Rows.Add(dr);

                                rptPhieuCHDBx2 rpt = new rptPhieuCHDBx2();
                                for (int j = 0; j < rpt.Subreports.Count; j++)
                                {
                                    rpt.Subreports[j].SetDataSource(dsBaoCao);
                                }
                                frmBaoCao frm = new frmBaoCao(rpt);
                                frm.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Phiếu Cắt Hủy Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                ///Nếu đơn thuộc Tổ Khách Hàng
                    else
                    if (_donkh != null && cmbLyDo.SelectedIndex != -1)
                    {
                        if (!_cCHDB.CheckYCCHDBbyMaDonDanhBo(_donkh.MaDon, _donkh.DanhBo))
                        {
                            YeuCauCHDB ycchdb = new YeuCauCHDB();
                            ycchdb.MaDon = _donkh.MaDon;
                            ycchdb.DanhBo = txtDanhBo.Text.Trim();
                            ycchdb.HopDong = txtHopDong.Text.Trim();
                            ycchdb.HoTen = txtHoTen.Text.Trim();
                            ycchdb.DiaChi = txtDiaChi.Text.Trim();
                            if (_ttkhachhang != null)
                            {
                                ycchdb.Dot = _ttkhachhang.Dot;
                                ycchdb.Ky = _ttkhachhang.Ky;
                                ycchdb.Nam = _ttkhachhang.Nam;
                            }
                            ycchdb.LyDo = cmbLyDo.SelectedItem.ToString();
                            ycchdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                            if (txtSoTien.Text.Trim() != "")
                                ycchdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                            ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                            ///Ký Tên
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ycchdb.ChucVu = "GIÁM ĐỐC";
                            else
                                ycchdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ycchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            ycchdb.PhieuDuocKy = true;

                            if (_cCHDB.ThemYeuCauCHDB(ycchdb))
                            {
                                if (string.IsNullOrEmpty(_donkh.TienTrinh))
                                    _donkh.TienTrinh = "CHDB";
                                else
                                    _donkh.TienTrinh += ",CHDB";
                                _donkh.Nhan = true;
                                _cDonKH.SuaDonKH(_donkh, true);
                                MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                DataRow dr = dsBaoCao.Tables["PhieuCHDB"].NewRow();

                                dr["SoPhieu"] = ycchdb.MaYCCHDB.ToString().Insert(ycchdb.MaYCCHDB.ToString().Length - 2, "-");
                                dr["HieuLucKy"] = ycchdb.HieuLucKy;
                                dr["Dot"] = ycchdb.Dot;
                                dr["HoTen"] = ycchdb.HoTen;
                                dr["DiaChi"] = ycchdb.DiaChi;
                                dr["DanhBo"] = ycchdb.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["HopDong"] = ycchdb.HopDong;

                                if (ycchdb.LyDo == "Vấn Đề Khác")
                                    dr["LyDo"] = "";
                                else
                                    dr["LyDo"] = ycchdb.LyDo + ". ";

                                if (ycchdb.GhiChuLyDo != "")
                                    dr["LyDo"] += ycchdb.GhiChuLyDo + ". ";
                                if (ycchdb.SoTien.ToString() != "")
                                    dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ycchdb.SoTien);

                                dr["ChucVu"] = ycchdb.ChucVu;
                                dr["NguoiKy"] = ycchdb.NguoiKy;

                                dsBaoCao.Tables["PhieuCHDB"].Rows.Add(dr);

                                rptPhieuCHDBx2 rpt = new rptPhieuCHDBx2();
                                for (int j = 0; j < rpt.Subreports.Count; j++)
                                {
                                    rpt.Subreports[j].SetDataSource(dsBaoCao);
                                }
                                frmBaoCao frm = new frmBaoCao(rpt);
                                frm.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Phiếu Cắt Hủy Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {

        }

        private void MaYCCHDB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaYCCHDB.Text.Trim() != "")
            {
                if (_cCHDB.getYeuCauCHDbyID(decimal.Parse(txtMaYCCHDB.Text.Trim().Replace("-", ""))) != null)
                {
                    _ycchdb = _cCHDB.getYeuCauCHDbyID(decimal.Parse(txtMaYCCHDB.Text.Trim().Replace("-", "")));
                    if (!string.IsNullOrEmpty(_ycchdb.MaDonTXL.ToString()))
                        txtMaDon.Text = "TXL" + _ycchdb.MaDonTXL.ToString().Insert(_ycchdb.MaDonTXL.ToString().Length - 2, "-");
                    else
                        if (!string.IsNullOrEmpty(_ycchdb.MaDon.ToString()))
                            txtMaDon.Text = _ycchdb.MaDon.ToString().Insert(_ycchdb.MaDon.ToString().Length - 2, "-");

                    txtMaYCCHDB.Text = _ycchdb.MaYCCHDB.ToString().Insert(_ycchdb.MaYCCHDB.ToString().Length - 2, "-");
                    ///
                    txtDanhBo.Text = _ycchdb.DanhBo;
                    txtHopDong.Text = _ycchdb.HopDong;
                    txtHoTen.Text = _ycchdb.HoTen;
                    txtDiaChi.Text = _ycchdb.DiaChi;
                    ///
                    cmbLyDo.SelectedItem = _ycchdb.LyDo;
                    txtSoTien.Text = _ycchdb.SoTien.ToString();
                    txtHieuLucKy.Text = _ycchdb.HieuLucKy;
                    txtGhiChuXuLy.Text = _ycchdb.GhiChuLyDo;
                    ///
                    if (_ycchdb.CatTamNutBit)
                    {
                        chkCatTamNutBit.Checked = true;
                        dateCatTamNutBit.Value = _ycchdb.NgayCatTamNutBit.Value;
                    }
                    else
                    {
                        chkCatTamNutBit.Checked = false;
                        dateCatTamNutBit.Value = DateTime.Now;
                    }
                }
                else
                {
                    //_ycchdb = null;
                    Clear();
                    MessageBox.Show("Số Phiếu này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chkCatTamNutBit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCatTamNutBit.Checked)
            {
                groupBoxCatTamNutBit.Enabled = true;
            }
            else
            {
                groupBoxCatTamNutBit.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_ycchdb != null)
            {
                _ycchdb.LyDo = cmbLyDo.SelectedItem.ToString();
                _ycchdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                if (txtSoTien.Text.Trim() != "")
                    _ycchdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                _ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                if (chkCatTamNutBit.Checked)
                {
                    _ycchdb.CatTamNutBit = true;
                    _ycchdb.NgayCatTamNutBit = dateCatTamNutBit.Value;
                }
                else
                {
                    _ycchdb.CatTamNutBit = false;
                    _ycchdb.NgayCatTamNutBit = null;
                }
                if (_cCHDB.SuaYeuCauCHDB(_ycchdb))
                {
                    Clear();
                    MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Chưa chọn Phiếu YCCHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSoTien_Leave(object sender, EventArgs e)
        {
            if (txtSoTien.Text.Trim() != "")
                txtSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cTTKH.getTTKHbyID(txtDanhBo.Text.Trim()) != null)
                {
                    _ttkhachhang = _cTTKH.getTTKHbyID(txtDanhBo.Text.Trim());
                    LoadTTKH(_ttkhachhang);
                    string ThongTin;
                    if (_cCHDB.CheckCHDBbyDanhBo(_ttkhachhang.DanhBo, out ThongTin))
                        MessageBox.Show("Danh Bộ này đã lập " + ThongTin, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtDanhBo.Text = "";
                    txtHopDong.Text = "";
                    txtHoTen.Text = "";
                    txtDiaChi.Text = "";
                    _ttkhachhang = null;
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
    }
}

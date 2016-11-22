using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.CatHuyDanhBo;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmYCCHDB : Form
    {
        string _mnu = "mnuPhieuCHDB";
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        HOADON _hoadon = null;
        CThuTien _cThuTien = new CThuTien();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDocSo _cDocSo = new CDocSo();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CCHDB _cCHDB = new CCHDB();
        CLyDoCHDB _cLyDoCHDB = new CLyDoCHDB();
        PhieuCHDB _ycchdb = null;
        decimal _MaYCCHDB = 0;

        public frmYCCHDB()
        {
            InitializeComponent();
        }

        public frmYCCHDB(decimal MaYCCHDB)
        {
            _MaYCCHDB = MaYCCHDB;
            InitializeComponent();
        }

        private void frmYCCHDB_Load(object sender, EventArgs e)
        {
            cmbLyDo.DataSource = _cLyDoCHDB.GetDS();
            cmbLyDo.DisplayMember = "LyDo";
            cmbLyDo.ValueMember = "LyDo";
            cmbLyDo.SelectedIndex = -1;

            if (_MaYCCHDB != 0)
            {
                txtMaYCCHDB.Text = _MaYCCHDB.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtMaYCCHDB_KeyPress(sender, arg);
            }
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHopDong.Text = hoadon.HOPDONG;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.getPhuongQuanByID(hoadon.Quan, hoadon.Phuong);
        }

        public void Clear()
        {
            txtMaDon.Text = "";
            txtMaYCCHDB.Text = "";
            ///
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            ///
            cmbLyDo.SelectedIndex = -1;
            txtSoTien.Text = "";
            txtGhiChu.Text = "";
            txtHieuLucKy.Text = "";
            ///
            chkCatTamNutBit.Checked = false;
            chkTroNgai.Checked = false;
            ///
            _hoadon = null;
            _donkh = null;
            _dontxl = null;
            _ycchdb = null;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                string MaDon = txtMaDon.Text.Trim();
                Clear();
                txtMaDon.Text = MaDon;
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
                            LoadTTKH(_hoadon);
                        }
                        else
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (e.KeyChar == 13)
            {
                if (_cThuTien.GetMoiNhat(txtDanhBo.Text.Trim()) != null)
                {
                    _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                    LoadTTKH(_hoadon);
                    //string ThongTin;
                    //if (_cCHDB.CheckCHDBbyDanhBo(_hoadon.DANHBA, out ThongTin))
                    //    MessageBox.Show("Danh Bộ này đã lập " + ThongTin, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaYCCHDB_KeyPress(object sender, KeyPressEventArgs e)
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
                    cmbLyDo.SelectedValue = _ycchdb.LyDo;
                    txtSoTien.Text = _ycchdb.SoTien.ToString();
                    txtHieuLucKy.Text = _ycchdb.HieuLucKy;
                    txtGhiChu.Text = _ycchdb.GhiChuLyDo;
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
                    ///
                    if (_ycchdb.NoiDungTroNgai != null)
                    {
                        chkTroNgai.Checked = true;
                        dateTroNgai.Value = _ycchdb.NgayTroNgai.Value;
                        cmbNoiDung.SelectedItem = _ycchdb.NoiDungTroNgai;
                    }
                    else
                    {
                        chkTroNgai.Checked = false;
                        dateTroNgai.Value = DateTime.Now;
                        cmbNoiDung.SelectedIndex = -1;
                    }
                }
                else
                    MessageBox.Show("Số Phiếu này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbLyDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLyDo.SelectedIndex != -1)
            {
                if (cmbLyDo.SelectedValue.ToString() == "Nợ Tiền Gian Lận Nước" || cmbLyDo.SelectedValue.ToString() == "Không Thanh Toán Tiền Bồi Thường ĐHN")
                    txtSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", 1283641);
            }
            else
            {
                txtSoTien.Text = "";
            }
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
                        if (_dontxl != null && cmbLyDo.SelectedIndex != -1)
                        {
                            if (!_cCHDB.CheckYCCHDBbyMaDonDanhBo_TXL(_dontxl.MaDon, _dontxl.DanhBo))
                            {
                                PhieuCHDB ycchdb = new PhieuCHDB();
                                ycchdb.ToXuLy = true;
                                ycchdb.MaDonTXL = _dontxl.MaDon;
                                ycchdb.DanhBo = txtDanhBo.Text.Trim();
                                ycchdb.HopDong = txtHopDong.Text.Trim();
                                ycchdb.HoTen = txtHoTen.Text.Trim();
                                ycchdb.DiaChi = txtDiaChi.Text.Trim();
                                if (_hoadon != null)
                                {
                                    ycchdb.Dot = _hoadon.DOT.ToString();
                                    ycchdb.Ky = _hoadon.KY.ToString();
                                    ycchdb.Nam = _hoadon.NAM.ToString();
                                }
                                ycchdb.LyDo = cmbLyDo.SelectedValue.ToString();
                                ycchdb.GhiChuLyDo = txtGhiChu.Text.Trim();
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
                                    _dontxl.DaGiaiQuyet = true;
                                    Clear();
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtMaDon.Focus();
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
                                PhieuCHDB ycchdb = new PhieuCHDB();
                                ycchdb.MaDon = _donkh.MaDon;
                                ycchdb.DanhBo = txtDanhBo.Text.Trim();
                                ycchdb.HopDong = txtHopDong.Text.Trim();
                                ycchdb.HoTen = txtHoTen.Text.Trim();
                                ycchdb.DiaChi = txtDiaChi.Text.Trim();
                                if (_hoadon != null)
                                {
                                    ycchdb.Dot = _hoadon.DOT.ToString();
                                    ycchdb.Ky = _hoadon.KY.ToString();
                                    ycchdb.Nam = _hoadon.NAM.ToString();
                                }
                                ycchdb.LyDo = cmbLyDo.SelectedValue.ToString();
                                ycchdb.GhiChuLyDo = txtGhiChu.Text.Trim();
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
                                    _donkh.DaGiaiQuyet = true;
                                    Clear();
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtMaDon.Focus();
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
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                if (_ycchdb != null)
                {
                    _ycchdb.LyDo = cmbLyDo.SelectedValue.ToString();
                    _ycchdb.GhiChuLyDo = txtGhiChu.Text.Trim();
                    if (txtSoTien.Text.Trim() != "")
                        _ycchdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                    else
                        _ycchdb.SoTien = null;
                    _ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                    ///
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
                    ///
                    if (chkTroNgai.Checked)
                    {
                        _ycchdb.NgayTroNgai = dateTroNgai.Value;
                        _ycchdb.NoiDungTroNgai = cmbNoiDung.SelectedItem.ToString();
                        _ycchdb.CreateDate_NgayTroNgai = DateTime.Now;
                    }
                    else
                    {
                        _ycchdb.NgayTroNgai = null;
                        _ycchdb.NoiDungTroNgai = null;
                        _ycchdb.CreateDate_NgayTroNgai = null;
                    }
                    if (_cCHDB.SuaYeuCauCHDB(_ycchdb))
                    {
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaDon.Focus();
                    }
                }
                else
                    MessageBox.Show("Chưa chọn Phiếu YCCHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                if (_ycchdb != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (_cCHDB.XoaYeuCauCHDB(_ycchdb))
                    {
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaDon.Focus();
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                if (_ycchdb != null)
                {
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    DataRow dr = dsBaoCao.Tables["PhieuCHDB"].NewRow();

                    dr["SoPhieu"] = _ycchdb.MaYCCHDB.ToString().Insert(_ycchdb.MaYCCHDB.ToString().Length - 2, "-");
                    dr["HieuLucKy"] = _ycchdb.HieuLucKy;
                    dr["Dot"] = _ycchdb.Dot;
                    dr["HoTen"] = _ycchdb.HoTen;
                    dr["DiaChi"] = _ycchdb.DiaChi;
                    dr["DanhBo"] = _ycchdb.DanhBo.Insert(7, " ").Insert(4, " ");
                    dr["HopDong"] = _ycchdb.HopDong;

                    if (_ycchdb.LyDo == "Vấn Đề Khác")
                        dr["LyDo"] = "";
                    else
                        dr["LyDo"] = _ycchdb.LyDo + ". ";

                    if (_ycchdb.GhiChuLyDo != "")
                        dr["LyDo"] += _ycchdb.GhiChuLyDo + ". ";
                    if (_ycchdb.SoTien.ToString() != "")
                        dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", _ycchdb.SoTien);

                    dr["ChucVu"] = _ycchdb.ChucVu;
                    dr["NguoiKy"] = _ycchdb.NguoiKy;

                    if (!string.IsNullOrEmpty(_ycchdb.MaDonTXL.ToString()))
                        dr["MaDon"] = "TXL" + _ycchdb.MaDonTXL.ToString().Insert(_ycchdb.MaDonTXL.ToString().Length - 2, "-");
                    else
                        if (!string.IsNullOrEmpty(_ycchdb.MaDon.ToString()))
                            dr["MaDon"] = _ycchdb.MaDon.ToString().Insert(_ycchdb.MaDon.ToString().Length - 2, "-");

                    dsBaoCao.Tables["PhieuCHDB"].Rows.Add(dr);

                    rptPhieuCHDBx2 rpt = new rptPhieuCHDBx2();
                    for (int j = 0; j < rpt.Subreports.Count; j++)
                    {
                        rpt.Subreports[j].SetDataSource(dsBaoCao);
                    }
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.ShowDialog();
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoTien_Leave(object sender, EventArgs e)
        {
            if (txtSoTien.Text.Trim() != "")
                txtSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
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

        private void chkNgayXuLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTroNgai.Checked)
            {
                dateTroNgai.Enabled = true;
                cmbNoiDung.Enabled = true;
            }
            else
            {
                dateTroNgai.Enabled = false;
                cmbNoiDung.Enabled = false;
            }
        }

    }
}

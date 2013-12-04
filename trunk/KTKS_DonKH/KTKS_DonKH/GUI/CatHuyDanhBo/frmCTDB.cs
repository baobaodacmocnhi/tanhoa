﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.CatHuyDanhBo;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmCTDB : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();
        TTKhachHang _ttkhachhang = new TTKhachHang();
        CTTKH _cTTKH = new CTTKH();
        CCHDB _cCHDB = new CCHDB();
        CDonKH _cDonKH = new CDonKH();
        CKTXM _cKTXM = new CKTXM();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CTCTDB _ctctdb = null;

        public frmCTDB()
        {
            InitializeComponent();
        }

        public frmCTDB(Dictionary<string, string> source)
        {
            InitializeComponent();
            _source = source;
        }

        private void frmCTDB_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            if (_source["Action"] == "Thêm")
            {
                groupBoxNguyenNhanXuLy.Enabled = true;
                txtMaDon.Text = _source["MaDon"].Insert(4, "-");
                if (_cTTKH.getTTKHbyID(_source["DanhBo"]) != null)
                {
                    _ttkhachhang = _cTTKH.getTTKHbyID(_source["DanhBo"]);
                    txtDanhBo.Text = _ttkhachhang.DanhBo;
                    txtHopDong.Text = _ttkhachhang.GiaoUoc;
                    txtHoTen.Text = _ttkhachhang.HoTen;
                    txtDiaChi.Text = _ttkhachhang.DC1 + _ttkhachhang.DC2 + _cCHDB.getPhuongQuanByID(_ttkhachhang.Quan, _ttkhachhang.Phuong);
                }
            }
            else
                if (_source["Action"] == "Sửa")
                {
                    groupBoxKetQuaXuLy.Enabled = true;
                    groupBoxCapTrenXuLy.Enabled = true;
                    if (_cCHDB.getCTCTDBbyID(decimal.Parse(_source["MaCTCTDB"])) != null)
                    {
                        _ctctdb = _cCHDB.getCTCTDBbyID(decimal.Parse(_source["MaCTCTDB"]));
                        ///Thông Tin
                        txtMaDon.Text = _ctctdb.CHDB.MaDon.ToString().Insert(4, "-");
                        txtDanhBo.Text = _ctctdb.DanhBo;
                        txtHopDong.Text = _ctctdb.HopDong;
                        txtHoTen.Text = _ctctdb.HoTen;
                        txtDiaChi.Text = _ctctdb.DiaChi;
                        ///Nguyên Nhân Xử Lý
                        cmbLyDo.SelectedText = _ctctdb.LyDo;
                        txtGhiChuXuLy.Text = _ctctdb.GhiChuLyDo;
                        txtSoTien.Text = _ctctdb.SoTien.ToString();
                        ///Kết Quả Xử Lý
                        if (_ctctdb.TCTBXuLy)
                        {
                            dateTCTBXuLy.Value = _ctctdb.NgayTCTBXuLy.Value;
                            txtKetQuaTCTBXuLy.Text = _ctctdb.KetQuaTCTBXuLy;
                        }
                        ///Cấp Trên Xử Lý
                        if (_ctctdb.CapTrenXuLy)
                        {
                            dateCapTrenXuLy.Value = _ctctdb.NgayCapTrenXuLy.Value;
                            txtKetQuaCapTrenXuLy.Text = _ctctdb.KetQuaCapTrenXuLy;
                            txtThoiGianLapCatHuy.Text = _ctctdb.ThoiGianLapCatHuy.ToString();
                        }
                    }
                }
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtThoiGianLapCatHuy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
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
            if (cmbLyDo.SelectedIndex != -1)
            {
                CHDB chdb = new CHDB();
                chdb.MaDon = decimal.Parse(_source["MaDon"]);
                chdb.MaNoiChuyenDen = decimal.Parse(_source["MaNoiChuyenDen"]);
                chdb.NoiChuyenDen = _source["NoiChuyenDen"];
                chdb.LyDoChuyenDen = _source["LyDoChuyenDen"];
                if (_cCHDB.ThemCHDB(chdb))
                {
                    switch (_source["NoiChuyenDen"])
                    {
                        case "Khách Hàng":
                            ///Báo cho bảng DonKH là đơn này đã được nơi nhận xử lý
                            DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(_source["MaNoiChuyenDen"]));
                            donkh.Nhan = true;
                            _cDonKH.SuaDonKH(donkh);
                            break;
                        case "Kiểm Tra Xác Minh":
                            ///Báo cho bảng KTXM là đơn này đã được nơi nhận xử lý
                            KTXM ktxm = _cKTXM.getKTXMbyID(decimal.Parse(_source["MaNoiChuyenDen"]));
                            ktxm.Nhan = true;
                            _cKTXM.SuaKTXM(ktxm);
                            break;
                    }
                    _source.Add("MaCHDB", _cCHDB.getMaxMaCHDB().ToString());
                }
                CTCTDB ctctdb = new CTCTDB();
                ctctdb.MaCHDB = decimal.Parse(_source["MaCHDB"]);
                ctctdb.DanhBo = txtDanhBo.Text.Trim();
                ctctdb.HopDong = txtHopDong.Text.Trim();
                ctctdb.HoTen = txtHoTen.Text.Trim();
                ctctdb.DiaChi = txtDiaChi.Text.Trim();
                ctctdb.Dot = _ttkhachhang.Dot;
                ctctdb.Ky = _ttkhachhang.Ky;
                ctctdb.Nam = _ttkhachhang.Nam;
                ctctdb.LyDo = cmbLyDo.SelectedItem.ToString();
                ctctdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                if (txtSoTien.Text.Trim() != "")
                    ctctdb.SoTien = int.Parse(txtSoTien.Text.Trim());

                ///Ký Tên
                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                    ctctdb.ChucVu = "GIÁM ĐỐC";
                else
                    ctctdb.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                ctctdb.NguoiKy = bangiamdoc.HoTen.ToUpper();

                if (_cCHDB.ThemCTCTDB(ctctdb))
                {
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                    dr["SoPhieu"] = _cCHDB.getMaxMaCTCTDB().ToString().Insert(4, "-");
                    dr["HoTen"] = ctctdb.HoTen;
                    dr["DiaChi"] = ctctdb.DiaChi;
                    dr["DanhBo"] = ctctdb.DanhBo;
                    dr["HopDong"] = ctctdb.HopDong;
                    dr["LyDo"] = ctctdb.LyDo+". ";
                    if (ctctdb.GhiChuLyDo != "")
                        dr["LyDo"] += ctctdb.GhiChuLyDo + ". ";
                    if (ctctdb.SoTien.ToString() != "")
                        dr["LyDo"] += "Số Tiền: " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ctctdb.SoTien);
                    dr["ChucVu"] = ctctdb.ChucVu;
                    dr["NguoiKy"] = ctctdb.NguoiKy;

                    dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                    rptThongBaoCTDB rpt = new rptThongBaoCTDB();
                    rpt.SetDataSource(dsBaoCao);
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.ShowDialog();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCapNhatTCTBXuLy_Click(object sender, EventArgs e)
        {
            if (_ctctdb != null)
            {
                _ctctdb.TCTBXuLy = true;
                _ctctdb.NgayTCTBXuLy = dateTCTBXuLy.Value;
                _ctctdb.KetQuaTCTBXuLy = txtKetQuaTCTBXuLy.Text.Trim();
                if (_cCHDB.SuaCTCTDB(_ctctdb))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnCapNhatCapTrenXuLy_Click(object sender, EventArgs e)
        {
            if (_ctctdb != null)
            {
                _ctctdb.CapTrenXuLy = true;
                _ctctdb.NgayCapTrenXuLy = dateCapTrenXuLy.Value;
                _ctctdb.KetQuaCapTrenXuLy = txtKetQuaCapTrenXuLy.Text.Trim();
                _ctctdb.ThoiGianLapCatHuy = int.Parse(txtThoiGianLapCatHuy.Text.Trim());
                if (_cCHDB.SuaCTCTDB(_ctctdb))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

    }
}

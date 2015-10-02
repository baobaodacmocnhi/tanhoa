﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using System.Globalization;
using KTKS_DonKH.BaoCao.CatHuyDanhBo;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.KhachHang;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmShowYCCHDB : Form
    {
        decimal _MaYCCHDB = 0;
        YeuCauCHDB _ycchdb = new YeuCauCHDB();
        CCHDB _cCHDB = new CCHDB();
        CTTKH _cTTKH = new CTTKH();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        TTKhachHang _ttkhachhang = null;

        public frmShowYCCHDB()
        {
            InitializeComponent();
        }

        public frmShowYCCHDB(decimal MaYCCHDB)
        {
            InitializeComponent();
            _MaYCCHDB = MaYCCHDB;
        }

        public frmShowYCCHDB(decimal MaYCCHDB, bool TimKiem)
        {
            InitializeComponent();
            _MaYCCHDB = MaYCCHDB;
            if (TimKiem)
            {
                btnXoa.Enabled = false;
                btnInPhieu.Enabled = false;
                btnSua.Enabled = false;
            }
        }

        private void frmShowYCCHDB_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            if (_cCHDB.getYeuCauCHDbyID(_MaYCCHDB) != null)
            {
                _ycchdb = _cCHDB.getYeuCauCHDbyID(_MaYCCHDB);
                if (!string.IsNullOrEmpty(_ycchdb.MaDonTXL.ToString()))
                    txtMaDon.Text = "TXL" + _ycchdb.MaDonTXL.Value.ToString().Insert(_ycchdb.MaDonTXL.Value.ToString().Length - 2, "-");
                else
                    if (!string.IsNullOrEmpty(_ycchdb.MaDon.ToString()))
                        txtMaDon.Text = _ycchdb.MaDon.Value.ToString().Insert(_ycchdb.MaDon.Value.ToString().Length - 2, "-");

                txtMaYCCHDB.Text = _ycchdb.MaYCCHDB.ToString().Insert(_ycchdb.MaYCCHDB.ToString().Length - 2, "-");
                txtDanhBo.Text = _ycchdb.DanhBo;
                txtHopDong.Text = _ycchdb.HopDong;
                txtHoTen.Text = _ycchdb.HoTen;
                txtDiaChi.Text = _ycchdb.DiaChi;
                ///
                cmbLyDo.SelectedItem = _ycchdb.LyDo;
                txtGhiChuXuLy.Text = _ycchdb.GhiChuLyDo;
                txtSoTien.Text = _ycchdb.SoTien.ToString();
                txtHieuLucKy.Text = _ycchdb.HieuLucKy;
            }
        }

        public void LoadTTKH(TTKhachHang ttkhachhang)
        {
            txtDanhBo.Text = ttkhachhang.DanhBo;
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
        }

        private void cmbLyDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLyDo.SelectedItem.ToString().ToUpper().Contains("TIỀN"))
                txtSoTien.ReadOnly = false;
            else
                txtSoTien.ReadOnly = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ycchdb != null)
                {
                    _ycchdb.DanhBo = txtDanhBo.Text.Trim();
                    _ycchdb.HopDong = txtHopDong.Text.Trim();
                    _ycchdb.HoTen = txtHoTen.Text.Trim();
                    _ycchdb.DiaChi = txtDiaChi.Text.Trim();
                    if (_ttkhachhang != null)
                    {
                        _ycchdb.Dot = _ttkhachhang.Dot;
                        _ycchdb.Ky = _ttkhachhang.Ky;
                        _ycchdb.Nam = _ttkhachhang.Nam;
                    }
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
                        MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (_ycchdb != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["PhieuCHDB"].NewRow();

                dr["SoPhieu"] = _ycchdb.MaYCCHDB.ToString().Insert(_ycchdb.MaYCCHDB.ToString().Length - 2, "-");
                dr["HieuLucKy"] = _ycchdb.HieuLucKy;
                dr["Dot"] = _ycchdb.Dot;
                dr["HoTen"] = _ycchdb.HoTen;
                dr["DiaChi"] = _ycchdb.DiaChi;
                if (!string.IsNullOrEmpty(_ycchdb.DanhBo))
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
                //rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (_cCHDB.XoaYeuCauCHDB(_ycchdb))
                {
                    if (_ycchdb.TBCTDB)
                    {
                        CTCTDB ctctdb = _cCHDB.getCTCTDBbyID(_ycchdb.MaCTCTDB.Value);
                        ctctdb.DaLapPhieu = false;
                        ctctdb.SoPhieu = null;
                        ctctdb.NgayLapPhieu = null;
                        ctctdb.PhieuDuocKy = false;
                        _cCHDB.SuaCTCTDB(ctctdb);
                    }
                    else
                        if (_ycchdb.TBCHDB)
                        {
                            CTCHDB ctchdb = _cCHDB.getCTCHDBbyID(_ycchdb.MaCTCHDB.Value);
                            ctchdb.DaLapPhieu = false;
                            ctchdb.SoPhieu = null;
                            ctchdb.NgayLapPhieu = null;
                            ctchdb.PhieuDuocKy = false;
                            _cCHDB.SuaCTCHDB(ctchdb);
                        }
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
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

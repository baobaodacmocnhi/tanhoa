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
using KTKS_DonKH.BaoCao.CatHuyDanhBo;
using KTKS_DonKH.GUI.BaoCao;
using System.Globalization;
using KTKS_DonKH.DAL.CapNhat;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmShowCTDB : Form
    {
        decimal _MaCTCTDB = 0;
        CCHDB _cCHDB = new CCHDB();
        CTCTDB _ctctdb = null;
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CTTKH _cTTKH = new CTTKH();

        public frmShowCTDB()
        {
            InitializeComponent();
        }

        public frmShowCTDB(decimal MaCTCTDB)
        {
            InitializeComponent();
            _MaCTCTDB = MaCTCTDB;
        }

        public frmShowCTDB(decimal MaCTCTDB,bool TimKiem)
        {
            InitializeComponent();
            _MaCTCTDB = MaCTCTDB;
            if (TimKiem)
            {
                btnCapNhatCapTrenXuLy.Enabled = false;
                btnCapNhatTCTBXuLy.Enabled = false;
                btnIn.Enabled = false;
                btnSua.Enabled = false;
                txtHieuLucKy.ReadOnly = true;
                btnInPhieu.Enabled = false;
            }
        }

        private void frmShowCTDB_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            if (_cCHDB.getCTCTDBbyID(_MaCTCTDB) != null)
            {
                _ctctdb = _cCHDB.getCTCTDBbyID(_MaCTCTDB);
                if (!string.IsNullOrEmpty(_ctctdb.CHDB.MaDonTXL.ToString()))
                    txtMaDon.Text = "TXL" + _ctctdb.CHDB.MaDonTXL.Value.ToString().Insert(_ctctdb.CHDB.MaDonTXL.Value.ToString().Length - 2, "-");
                else
                    if (!string.IsNullOrEmpty(_ctctdb.CHDB.MaDon.ToString()))
                        txtMaDon.Text = _ctctdb.CHDB.MaDon.Value.ToString().Insert(_ctctdb.CHDB.MaDon.Value.ToString().Length - 2, "-");
                txtMaThongBao.Text = _ctctdb.MaCTCTDB.ToString().Insert(_ctctdb.MaCTCTDB.ToString().Length - 2, "-");
                txtDanhBo.Text = _ctctdb.DanhBo;
                txtHopDong.Text = _ctctdb.HopDong;
                txtHoTen.Text = _ctctdb.HoTen;
                txtDiaChi.Text = _ctctdb.DiaChi;
                ///
                cmbLyDo.SelectedItem = _ctctdb.LyDo;
                txtGhiChuXuLy.Text = _ctctdb.GhiChuLyDo;
                txtSoTien.Text = _ctctdb.SoTien.ToString();
                ///
                ///phải có if ở đây vì dateTCTBXuLy không nhận giá trị null
                if (_ctctdb.TCTBXuLy)
                {
                    chkKetQuaTCTBXuLy.Checked = true;
                    dateTCTBXuLy.Value = _ctctdb.NgayTCTBXuLy.Value;
                    if (_ctctdb.TroNgai)
                        chkTroNgai.Checked = true;
                    else
                        chkTroNgai.Checked = false;
                    txtKetQuaTCTBXuLy.Text = _ctctdb.KetQuaTCTBXuLy;
                }
                ///
                ///phải có if ở đây vì dateCapTrenXuLy không nhận giá trị null
                if (_ctctdb.CapTrenXuLy)
                {
                    chkKetQuaCapTrenXuLy.Checked = true;
                    dateCapTrenXuLy.Value = _ctctdb.NgayCapTrenXuLy.Value;
                    txtKetQuaCapTrenXuLy.Text = _ctctdb.KetQuaCapTrenXuLy;
                    txtThoiGianLapCatHuy.Text = _ctctdb.ThoiGianLapCatHuy.Value.ToString();
                }
                ///
                if (_cCHDB.CheckYeuCauCHDBbyMaCTCTDB(_ctctdb.MaCTCTDB))
                {
                    txtHieuLucKy.Text = _ctctdb.YeuCauCHDBs.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaCTCTDB == _ctctdb.MaCTCTDB).HieuLucKy;
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_ctctdb != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                dr["SoPhieu"] = _ctctdb.MaCTCTDB.ToString().Insert(_ctctdb.MaCTCTDB.ToString().Length - 2, "-");
                dr["HoTen"] = _ctctdb.HoTen;
                dr["DiaChi"] = _ctctdb.DiaChi;
                dr["DanhBo"] = _ctctdb.DanhBo;
                dr["HopDong"] = _ctctdb.HopDong;
                if (_ctctdb.LyDo != "Vấn Đề Khác")
                    dr["LyDo"] = _ctctdb.LyDo + ". ";
                if (_ctctdb.GhiChuLyDo != "")
                    dr["LyDo"] += _ctctdb.GhiChuLyDo + ". ";
                if (_ctctdb.SoTien.ToString() != "")
                    dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", _ctctdb.SoTien);
                dr["ChucVu"] = _ctctdb.ChucVu;
                dr["NguoiKy"] = _ctctdb.NguoiKy;

                dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                rptThongBaoCTDB rpt = new rptThongBaoCTDB();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void frmShowCTDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctctdb != null)
                {
                    if (!string.IsNullOrEmpty(cmbLyDo.SelectedItem.ToString()))
                        _ctctdb.LyDo = cmbLyDo.SelectedItem.ToString();
                    _ctctdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                    if (txtSoTien.Text.Trim() != "")
                        _ctctdb.SoTien = int.Parse(txtSoTien.Text.Trim());

                    if (chkKetQuaTCTBXuLy.Checked)
                    {
                        _ctctdb.TCTBXuLy = true;
                        _ctctdb.NgayTCTBXuLy = dateTCTBXuLy.Value;
                        if (chkTroNgai.Checked)
                            _ctctdb.TroNgai = true;
                        else
                            _ctctdb.TroNgai = false;
                        _ctctdb.KetQuaTCTBXuLy = txtKetQuaTCTBXuLy.Text.Trim();
                    }
                    else
                    {
                        _ctctdb.TCTBXuLy = false;
                        _ctctdb.NgayTCTBXuLy = null;
                        _ctctdb.TroNgai = false;
                        _ctctdb.KetQuaTCTBXuLy = null;
                    }

                    if (chkKetQuaCapTrenXuLy.Checked)
                    {
                        _ctctdb.CapTrenXuLy = true;
                        _ctctdb.NgayCapTrenXuLy = dateCapTrenXuLy.Value;
                        _ctctdb.KetQuaCapTrenXuLy = txtKetQuaCapTrenXuLy.Text.Trim();
                        _ctctdb.ThoiGianLapCatHuy = int.Parse(txtThoiGianLapCatHuy.Text.Trim());
                    }
                    else
                    {
                        _ctctdb.CapTrenXuLy = false;
                        _ctctdb.NgayCapTrenXuLy = null;
                        _ctctdb.KetQuaCapTrenXuLy = null;
                        _ctctdb.ThoiGianLapCatHuy = null;
                    }

                    if (_cCHDB.SuaCTCTDB(_ctctdb))
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

        private void btnCapNhatTCTBXuLy_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctctdb != null)
                {
                    _ctctdb.TCTBXuLy = true;
                    _ctctdb.NgayTCTBXuLy = dateTCTBXuLy.Value;
                    _ctctdb.KetQuaTCTBXuLy = txtKetQuaTCTBXuLy.Text.Trim();
                    if (_cCHDB.SuaCTCTDB(_ctctdb))
                    {
                        MessageBox.Show("Cập Nhật Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhatCapTrenXuLy_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctctdb != null)
                {
                    _ctctdb.CapTrenXuLy = true;
                    _ctctdb.NgayCapTrenXuLy = dateCapTrenXuLy.Value;
                    _ctctdb.KetQuaCapTrenXuLy = txtKetQuaCapTrenXuLy.Text.Trim();
                    _ctctdb.ThoiGianLapCatHuy = int.Parse(txtThoiGianLapCatHuy.Text.Trim());
                    if (_cCHDB.SuaCTCTDB(_ctctdb))
                    {
                        MessageBox.Show("Cập Nhật Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkKetQuaTCTBXuLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKetQuaTCTBXuLy.Checked)
                groupBoxKetQuaTCTBXuLy.Enabled = true;
            else
                groupBoxKetQuaTCTBXuLy.Enabled = false;
        }

        private void chkKetQuaCapTrenXuLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKetQuaCapTrenXuLy.Checked)
                groupBoxKetQuaCapTrenXuLy.Enabled = true;
            else
                groupBoxKetQuaCapTrenXuLy.Enabled = false;
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (_ctctdb != null)
            {
                ///Nếu Chưa Lập Phiếu
                if (!_cCHDB.CheckYeuCauCHDBbyMaCTCTDB(_ctctdb.MaCTCTDB))
                {
                    if (txtHieuLucKy.Text.Trim() != "")
                    {
                        YeuCauCHDB ycchdb = new YeuCauCHDB();
                        ycchdb.TBCTDB = true;
                        ycchdb.MaCTCTDB = _ctctdb.MaCTCTDB;
                        ycchdb.DanhBo = _ctctdb.DanhBo;
                        ycchdb.HopDong = _ctctdb.HopDong;
                        ycchdb.HoTen = _ctctdb.HoTen;
                        ycchdb.DiaChi = _ctctdb.DiaChi;
                        ycchdb.LyDo = _ctctdb.LyDo;
                        ycchdb.GhiChuLyDo = _ctctdb.GhiChuLyDo;
                        ycchdb.SoTien = _ctctdb.SoTien;
                        ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                        TTKhachHang ttkhachhang = _cTTKH.getTTKHbyID(_ctctdb.DanhBo);
                        if (ttkhachhang != null)
                        {
                            ycchdb.Dot = ttkhachhang.Dot;
                            ycchdb.Ky = ttkhachhang.Ky;
                            ycchdb.Nam = ttkhachhang.Nam;
                        }
                        ///Ký Tên
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            ycchdb.ChucVu = "GIÁM ĐỐC";
                        else
                            ycchdb.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        ycchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        ycchdb.PhieuDuocKy = true;

                        if (_cCHDB.ThemYeuCauCHDB(ycchdb))
                        {
                            _ctctdb.DaLapPhieu = true;
                            _ctctdb.PhieuDuocKy = true;
                            _cCHDB.SuaCTCTDB(_ctctdb);

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
                        MessageBox.Show("Chưa có Hiệu Lực Kỳ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ///Nếu Đã Lập Phiếu
                else
                {
                    YeuCauCHDB ycchdb = _cCHDB.getYeuCauCHDBbyMaCTCTDB(_ctctdb.MaCTCTDB);
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    DataRow dr = dsBaoCao.Tables["PhieuCHDB"].NewRow();

                    dr["SoPhieu"] = ycchdb.MaYCCHDB.ToString().Insert(ycchdb.MaYCCHDB.ToString().Length - 2, "-");
                    dr["HieuLucKy"] = ycchdb.HieuLucKy;
                    dr["Dot"] = ycchdb.Dot;
                    dr["HoTen"] = ycchdb.HoTen;
                    dr["DiaChi"] = ycchdb.DiaChi;
                    dr["DanhBo"] = ycchdb.DanhBo.Insert(7, " ").Insert(4, " ");
                    dr["HopDong"] = ycchdb.HopDong;
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
        }
    }
}

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

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmShowCHDB : Form
    {
        decimal _MaCTCHDB = 0;
        CCHDB _cCHDB = new CCHDB();
        CTCHDB _ctchdb = null;

        public frmShowCHDB()
        {
            InitializeComponent();
        }

        public frmShowCHDB(decimal MaCTCHDB)
        {
            InitializeComponent();
            _MaCTCHDB = MaCTCHDB;
        }

        private void frmShowCHDB_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            if (_cCHDB.getCTCHDBbyID(_MaCTCHDB) != null)
            {
                _ctchdb = _cCHDB.getCTCHDBbyID(_MaCTCHDB);
                if (!string.IsNullOrEmpty(_ctchdb.CHDB.MaDonTXL.ToString()))
                    txtMaDon.Text = "TXL"+_ctchdb.CHDB.MaDonTXL.Value.ToString().Insert(_ctchdb.CHDB.MaDonTXL.Value.ToString().Length - 2, "-");
                else
                    if (!string.IsNullOrEmpty(_ctchdb.CHDB.MaDon.ToString()))
                        txtMaDon.Text = _ctchdb.CHDB.MaDon.Value.ToString().Insert(_ctchdb.CHDB.MaDon.Value.ToString().Length - 2, "-");
                txtMaThongBaoCH.Text = _ctchdb.MaCTCHDB.ToString().Insert(_ctchdb.MaCTCHDB.ToString().Length - 2, "-");
                if (!string.IsNullOrEmpty(_ctchdb.MaCTCTDB.ToString()))
                    txtMaThongBaoCT.Text = _ctchdb.MaCTCTDB.ToString().Insert(_ctchdb.MaCTCTDB.ToString().Length - 2, "-");
                txtDanhBo.Text = _ctchdb.DanhBo;
                txtHopDong.Text = _ctchdb.HopDong;
                txtHoTen.Text = _ctchdb.HoTen;
                txtDiaChi.Text = _ctchdb.DiaChi;
                ///
                cmbLyDo.SelectedText = _ctchdb.LyDo;
                txtGhiChuXuLy.Text = _ctchdb.GhiChuLyDo;
                txtSoTien.Text = _ctchdb.SoTien.Value.ToString();
                ///
                ///phải có if ở đây vì dateTCTBXuLy không nhận giá trị null
                if (_ctchdb.TCTBXuLy)
                {
                    dateTCTBXuLy.Value = _ctchdb.NgayTCTBXuLy.Value;
                    txtKetQuaTCTBXuLy.Text = _ctchdb.KetQuaTCTBXuLy;
                }
                ///
                ///phải có if ở đây vì dateCapTrenXuLy không nhận giá trị null
                if (_ctchdb.CapTrenXuLy)
                {
                    dateCapTrenXuLy.Value = _ctchdb.NgayCapTrenXuLy.Value;
                    txtKetQuaCapTrenXuLy.Text = _ctchdb.KetQuaCapTrenXuLy;
                    txtThoiGianLapPhieu.Text = _ctchdb.ThoiGianLapPhieu.Value.ToString();
                }
                ///
                txtHieuLucKy.Text = _ctchdb.HieuLucKy;
            }
        }

        private void frmShowCHDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_ctchdb != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                dr["SoPhieu"] = _ctchdb.MaCTCHDB.ToString().Insert(_ctchdb.MaCTCHDB.ToString().Length-2, "-");
                dr["HoTen"] = _ctchdb.HoTen;
                dr["DiaChi"] = _ctchdb.DiaChi;
                dr["DanhBo"] = _ctchdb.DanhBo;
                dr["HopDong"] = _ctchdb.HopDong;
                dr["LyDo"] = _ctchdb.LyDo + ". ";
                if (_ctchdb.GhiChuLyDo != "")
                    dr["LyDo"] += _ctchdb.GhiChuLyDo + ". ";
                if (_ctchdb.SoTien.ToString() != "")
                    dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", _ctchdb.SoTien);
                dr["ChucVu"] = _ctchdb.ChucVu;
                dr["NguoiKy"] = _ctchdb.NguoiKy;

                dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                rptThongBaoCHDB rpt = new rptThongBaoCHDB();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (_ctchdb != null)
                if (_cCHDB.CheckDaLapPhieuCHDB(_ctchdb.MaCTCHDB))
                {
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    DataRow dr = dsBaoCao.Tables["PhieuCHDB"].NewRow();

                    dr["SoPhieu"] = _ctchdb.SoPhieu.ToString().Insert(_ctchdb.SoPhieu.ToString().Length-2, "-");
                    dr["HieuLucKy"] = _ctchdb.HieuLucKy;
                    dr["Dot"] = _ctchdb.DotLapPhieu;
                    dr["HoTen"] = _ctchdb.HoTen;
                    dr["DiaChi"] = _ctchdb.DiaChi;
                    dr["DanhBo"] = _ctchdb.DanhBo;
                    dr["HopDong"] = _ctchdb.HopDong;
                    dr["LyDo"] = _ctchdb.LyDo + ". ";
                    if (_ctchdb.GhiChuLyDo != "")
                        dr["LyDo"] += _ctchdb.GhiChuLyDo + ". ";
                    if (_ctchdb.SoTien.ToString() != "")
                        dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", _ctchdb.SoTien);

                    dr["ChucVu"] = _ctchdb.ChucVuLapPhieu;
                    dr["NguoiKy"] = _ctchdb.NguoiKyLapPhieu;

                    dsBaoCao.Tables["PhieuCHDB"].Rows.Add(dr);

                    rptPhieuCHDB rpt = new rptPhieuCHDB();
                    rpt.SetDataSource(dsBaoCao);
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.ShowDialog();
                }
                else
                    MessageBox.Show("Chưa lập Phiếu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

using System;
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

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmShowYCCHDB : Form
    {
        decimal _MaYCCHDB = 0;
        YeuCauCHDB _ycchdb = new YeuCauCHDB();
        CCHDB _cCHDB = new CCHDB();

        public frmShowYCCHDB()
        {
            InitializeComponent();
        }

        public frmShowYCCHDB(decimal MaYCCHDB)
        {
            InitializeComponent();
            _MaYCCHDB = MaYCCHDB;
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
                    _ycchdb.LyDo = cmbLyDo.SelectedItem.ToString();
                    _ycchdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                    if (txtSoTien.Text.Trim() != "")
                        _ycchdb.SoTien = int.Parse(txtSoTien.Text.Trim());
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

        
    }
}

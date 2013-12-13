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
using KTKS_DonKH.BaoCao.CatHuyDanhBo;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmShowCTDB : Form
    {
        decimal _MaCTCTDB = 0;
        CCHDB _cCHDB = new CCHDB();
        CTCTDB _ctctdb = null;

        public frmShowCTDB()
        {
            InitializeComponent();
        }

        public frmShowCTDB(decimal MaCTCTDB)
        {
            InitializeComponent();
            _MaCTCTDB = MaCTCTDB;
        }

        private void frmShowCTDB_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            if (_cCHDB.getCTCTDBbyID(_MaCTCTDB) != null)
            {
                _ctctdb = _cCHDB.getCTCTDBbyID(_MaCTCTDB);
                txtMaDon.Text = _ctctdb.CHDB.MaDon.Value.ToString().Insert(4, "-");
                txtMaThongBao.Text = _ctctdb.MaCTCTDB.ToString().Insert(4, "-");
                txtDanhBo.Text = _ctctdb.DanhBo;
                txtHopDong.Text = _ctctdb.HopDong;
                txtHoTen.Text = _ctctdb.HoTen;
                txtDiaChi.Text = _ctctdb.DiaChi;
                ///
                cmbLyDo.SelectedText = _ctctdb.LyDo;
                txtGhiChuXuLy.Text = _ctctdb.GhiChuLyDo;
                txtSoTien.Text = _ctctdb.SoTien.Value.ToString();
                ///
                ///phải có if ở đây vì dateTCTBXuLy không nhận giá trị null
                if (_ctctdb.TCTBXuLy)
                {
                    dateTCTBXuLy.Value = _ctctdb.NgayTCTBXuLy.Value;
                    txtKetQuaTCTBXuLy.Text = _ctctdb.KetQuaTCTBXuLy;
                }
                ///
                ///phải có if ở đây vì dateCapTrenXuLy không nhận giá trị null
                if (_ctctdb.CapTrenXuLy)
                {
                    dateCapTrenXuLy.Value = _ctctdb.NgayCapTrenXuLy.Value;
                    txtKetQuaCapTrenXuLy.Text = _ctctdb.KetQuaCapTrenXuLy;
                    txtThoiGianLapCatHuy.Text = _ctctdb.ThoiGianLapCatHuy.Value.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_ctctdb != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                dr["SoPhieu"] = _ctctdb.MaCTCTDB.ToString().Insert(4, "-");
                dr["HoTen"] = _ctctdb.HoTen;
                dr["DiaChi"] = _ctctdb.DiaChi;
                dr["DanhBo"] = _ctctdb.DanhBo;
                dr["HopDong"] = _ctctdb.HopDong;
                dr["LyDo"] = _ctctdb.LyDo + ". ";
                if (_ctctdb.GhiChuLyDo != "")
                    dr["LyDo"] += _ctctdb.GhiChuLyDo + ". ";
                if (_ctctdb.SoTien.ToString() != "")
                    dr["LyDo"] += "Số Tiền: " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", _ctctdb.SoTien);
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
    }
}

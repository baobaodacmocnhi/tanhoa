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
                txtMaDon.Text = _ctchdb.CHDB.MaDon.Value.ToString().Insert(4, "-");
                txtMaThongBaoCH.Text = _ctchdb.MaCTCHDB.ToString().Insert(4, "-");
                txtMaThongBaoCT.Text = _ctchdb.MaCTCTDB.ToString().Insert(4, "-");
                txtDanhBo.Text = _ctchdb.DanhBo;
                txtHopDong.Text = _ctchdb.HopDong;
                txtHoTen.Text = _ctchdb.HoTen;
                txtDiaChi.Text = _ctchdb.DiaChi;
                ///
                cmbLyDo.SelectedText = _ctchdb.LyDo;
                txtGhiChuXuLy.Text = _ctchdb.GhiChuLyDo;
                txtSoTien.Text = _ctchdb.SoTien.Value.ToString();
                ///
                dateTCTBXuLy.Value = _ctchdb.NgayTCTBXuLy.Value;
                txtKetQuaTCTBXuLy.Text = _ctchdb.KetQuaTCTBXuLy;
                ///
                dateCapTrenXuLy.Value = _ctchdb.NgayCapTrenXuLy.Value;
                txtKetQuaCapTrenXuLy.Text = _ctchdb.KetQuaCapTrenXuLy;
                txtThoiGianLapPhieu.Text = _ctchdb.ThoiGianLapPhieu.Value.ToString();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

    }
}

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
using KTKS_DonKH.DAL.CatHuyDanhBo;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmCHDB : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();
        TTKhachHang _ttkhachhang = new TTKhachHang();
        CTTKH _cTTKH = new CTTKH();
        CCHDB _cCHDB = new CCHDB();
        CTCHDB _ctchdb = null;

        public frmCHDB()
        {
            InitializeComponent();
        }

        public frmCHDB(Dictionary<string, string> source)
        {
            InitializeComponent();
            _source = source;
        }

        private void frmCHDB_Load(object sender, EventArgs e)
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
                    txtHieuLucKy.ReadOnly = false;
                    btnInPhieu.Enabled = true;
                    if (_cCHDB.getCTCTDBbyID(decimal.Parse(_source["MaCTCTDB"])) != null)
                    {
                        _ctchdb = _cCHDB.getCTCHDBbyID(decimal.Parse(_source["MaCTCHDB"]));
                        ///Thông Tin
                        txtMaDon.Text = _ctchdb.CHDB.MaDon.ToString().Insert(4, "-");
                        txtDanhBo.Text = _ctchdb.DanhBo;
                        txtHopDong.Text = _ctchdb.HopDong;
                        txtHoTen.Text = _ctchdb.HoTen;
                        txtDiaChi.Text = _ctchdb.DiaChi;
                        ///Nguyên Nhân Xử Lý
                        cmbLyDo.SelectedText = _ctchdb.LyDo;
                        txtGhiChuXuLy.Text = _ctchdb.GhiChuLyDo;
                        txtSoTien.Text = _ctchdb.SoTien.ToString();
                        ///Kết Quả Xử Lý
                        if (_ctchdb.TCTBXuLy)
                        {
                            dateTCTBXuLy.Value = _ctchdb.NgayTCTBXuLy.Value;
                            txtKetQuaTCTBXuLy.Text = _ctchdb.KetQuaTCTBXuLy;
                        }
                        ///Cấp Trên Xử Lý
                        if (_ctchdb.CapTrenXuLy)
                        {
                            dateCapTrenXuLy.Value = _ctchdb.NgayCapTrenXuLy.Value;
                            txtKetQuaCapTrenXuLy.Text = _ctchdb.KetQuaCapTrenXuLy;
                            txtThoiGianLapPhieu.Text = _ctchdb.ThoiGianLapPhieu.ToString();
                        }
                    }
                }
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtThoiGianLapPhieu_KeyPress(object sender, KeyPressEventArgs e)
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

        }

        private void btnCapNhatTCTBXuLy_Click(object sender, EventArgs e)
        {

        }

        private void btnCapNhatCapTrenXuLy_Click(object sender, EventArgs e)
        {

        }    

    }
}

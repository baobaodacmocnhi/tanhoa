using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.DAL.KhachHang;

namespace KTKS_DonKH.GUI.ThaoThuTraLoi
{
    public partial class frmTTTL : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();
        CTTKH _cTTKH = new CTTKH();
        DonKH _donkh = new DonKH();
        TTKhachHang _ttkhachhang = new TTKhachHang();
        CCHDB _cCHDB = new CCHDB();
        CDonKH _cDonKH = new CDonKH();

        public frmTTTL()
        {
            InitializeComponent();
        }

        public frmTTTL(Dictionary<string, string> source)
        {
            InitializeComponent();
            _source = source;
        }

        private void frmTTTL_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            if (_cDonKH.getDonKHbyID(decimal.Parse(_source["MaDon"])) != null)
            {
                _donkh = _cDonKH.getDonKHbyID(decimal.Parse(_source["MaDon"]));
                txtMaDon.Text = _donkh.MaDon.ToString().Insert(4, "-");
            }
            if (_cTTKH.getTTKHbyID(_source["DanhBo"]) != null)
            {
                _ttkhachhang = _cTTKH.getTTKHbyID(_source["DanhBo"]);
                txtDanhBo.Text = _ttkhachhang.DanhBo;
                txtHopDong.Text = _ttkhachhang.GiaoUoc;
                txtHoTen.Text = _ttkhachhang.HoTen;
                txtDiaChi.Text = _ttkhachhang.DC1 + _ttkhachhang.DC2 + _cCHDB.getPhuongQuanByID(_ttkhachhang.Quan, _ttkhachhang.Phuong);
                txtGiaBieu.Text = _ttkhachhang.GB;
                txtDinhMuc.Text = _ttkhachhang.TGDM;
            }
        }

    }
}

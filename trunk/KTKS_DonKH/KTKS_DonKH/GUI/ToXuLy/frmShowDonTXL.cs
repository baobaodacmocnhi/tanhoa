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
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.KhachHang;

namespace KTKS_DonKH.GUI.ToXuLy
{
    public partial class frmShowDonTXL : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();
        CLoaiDonTXL _cLoaiDonTXL = new CLoaiDonTXL();
        DonTXL _dontxl = null;
        TTKhachHang _ttkhachhang = null;
        CDonTXL _cDonTXL = new CDonTXL();
        CTTKH _cTTKH = new CTTKH();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();

        public frmShowDonTXL()
        {
            InitializeComponent();
        }

        public frmShowDonTXL(Dictionary<string, string> source)
        {
            InitializeComponent();
            _source = source;
        }

        public void LoadTTKH(TTKhachHang ttkhachhang)
        {
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
            txtMSThue.Text = ttkhachhang.MSThue;
            txtGiaBieu.Text = ttkhachhang.GB;
            txtDinhMuc.Text = ttkhachhang.TGDM;
        }

        public void Clear()
        {
            cmbLD.SelectedIndex = -1;
            txtMaDon.Text = "";
            txtNgayNhan.Text = "";
            txtNoiDung.Text = "";
            txtSoCongVan.Text = "";

            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtMSThue.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDienThoai.Text = "";
            _ttkhachhang = null;
        }

        private void frmShowDonTXL_Load(object sender, EventArgs e)
        {
            if (_cDonTXL.getDonTXLbyID(decimal.Parse(_source["MaDon"])) != null)
            {
                this.Location = new Point(70, 70);
                cmbLD.DataSource = _cLoaiDonTXL.LoadDSLoaiDonTXL(true);
                cmbLD.DisplayMember = "TenLD";
                cmbLD.ValueMember = "MaLD";
                cmbLD.SelectedIndex = -1;

                _dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(_source["MaDon"]));
                cmbLD.SelectedValue = _dontxl.MaLD.Value;
                txtSoCongVan.Text = _dontxl.SoCongVan;
                txtMaDon.Text = "TXL"+_dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");
                txtNgayNhan.Text = _dontxl.CreateDate.Value.ToString("dd/MM/yyyy");
                txtNoiDung.Text = _dontxl.NoiDung;
                ///
                txtDanhBo.Text = _dontxl.DanhBo;
                txtHopDong.Text = _dontxl.HopDong;
                txtDienThoai.Text = _dontxl.DienThoai;
                txtHoTen.Text = _dontxl.HoTen;
                txtDiaChi.Text = _dontxl.DiaChi;
                txtMSThue.Text = _dontxl.MSThue;
                txtGiaBieu.Text = _dontxl.GiaBieu;
                txtDinhMuc.Text = _dontxl.DinhMuc;

                if (_source["Action"] == "Cập Nhật")
                {
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }

                if (_source["Action"].ToString() == "Tìm Kiếm")
                {
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_dontxl != null)
            {
                _dontxl.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                _dontxl.SoCongVan = txtSoCongVan.Text.Trim();
                _dontxl.DanhBo = txtDanhBo.Text.Trim();
                _dontxl.HopDong = txtHopDong.Text.Trim();
                _dontxl.HoTen = txtHoTen.Text.Trim();
                _dontxl.DiaChi = txtDiaChi.Text.Trim();
                _dontxl.DienThoai = txtDienThoai.Text.Trim();
                _dontxl.MSThue = txtMSThue.Text.Trim();
                _dontxl.GiaBieu = txtGiaBieu.Text.Trim();
                _dontxl.DinhMuc = txtDinhMuc.Text.Trim();
                _dontxl.NoiDung = txtNoiDung.Text.Trim();

                if (_cDonTXL.SuaDonTXL(_dontxl))
                    MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_dontxl != null)
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (_cDonTXL.XoaDonTXL(_dontxl))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
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
                }
                else
                {
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }
    }
}

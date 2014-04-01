using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.BamChi;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.BamChi
{
    public partial class frmShowBamChi : Form
    {
        decimal _MaCTBamChi = 0;
        CTBamChi _ctbamchi = null;
        CTTKH _cTTKH = new CTTKH();
        CBamChi _cBamChi = new CBamChi();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        TTKhachHang _ttkhachhang = null;

        public frmShowBamChi()
        {
            InitializeComponent();
        }

        public frmShowBamChi(decimal MaCTBamChi)
        {
            InitializeComponent();
            _MaCTBamChi = MaCTBamChi;
        }

        public frmShowBamChi(decimal MaCTBamChi, bool TimKiem)
        {
            InitializeComponent();
            _MaCTBamChi = MaCTBamChi;
            if (TimKiem)
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        public void LoadTTKH(TTKhachHang ttkhachhang)
        {
            txtDanhBo.Text = ttkhachhang.DanhBo;
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2;
            txtGiaBieu.Text = ttkhachhang.GB;
            txtDinhMuc.Text = ttkhachhang.TGDM;
        }

        public void LoadCTBamChi(CTBamChi ctbamchi)
        {
            txtDanhBo.Text = ctbamchi.DanhBo;
            txtHopDong.Text = ctbamchi.HopDong;
            txtHoTen.Text = ctbamchi.HoTen;
            txtDiaChi.Text = ctbamchi.DiaChi;
            txtGiaBieu.Text = ctbamchi.GiaBieu.ToString();
            txtDinhMuc.Text = ctbamchi.DinhMuc.ToString();
            ///
            dateBamChi.Value = ctbamchi.NgayBC.Value;
            txtHieu.Text = ctbamchi.Hieu;
            txtCo.Text = ctbamchi.Co.ToString();
            txtChiSo.Text = ctbamchi.ChiSo;
            txtVienChi.Text = ctbamchi.VienChi.ToString();
            txtDayChi.Text = ctbamchi.DayChi.ToString();
            cmbTrangThai.SelectedText = ctbamchi.TrangThai;
            txtMaSoBC.Text = ctbamchi.MaSoBC;
            txtTheoYeuCau.Text = ctbamchi.TheoYeuCau;

        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            ///
            dateBamChi.Value = DateTime.Now;
            txtHieu.Text = "";
            txtCo.Text = "";
            txtChiSo.Text = "";
            txtVienChi.Text = "";
            txtDayChi.Text = "";
            cmbTrangThai.SelectedIndex = -1;
            txtMaSoBC.Text = "";
            txtTheoYeuCau.Text = "";
        }

        private void frmShowNhapBamChi_Load(object sender, EventArgs e)
        {
            this.Location = new Point(30, 70);
            if (_cBamChi.CheckCTBamChibyID(_MaCTBamChi))
            {
                _ctbamchi = _cBamChi.getCTBamChibyID(_MaCTBamChi);
                //if (CTaiKhoan.RoleQLKTXM_CapNhat)
                //    btnXoa.Enabled = true;
                if (_ctbamchi.BamChi.ToXuLy)
                    txtMaDon.Text = "TXL" + _ctbamchi.BamChi.MaDonTXL.ToString().Insert(_ctbamchi.BamChi.MaDonTXL.ToString().Length - 2, "-");
                else
                    txtMaDon.Text = _ctbamchi.BamChi.MaDon.ToString().Insert(_ctbamchi.BamChi.MaDon.ToString().Length - 2, "-");
                LoadCTBamChi(_ctbamchi);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_ctbamchi != null)
            {
                _ctbamchi.DanhBo = txtDanhBo.Text.Trim();
                _ctbamchi.HopDong = txtHopDong.Text.Trim();
                _ctbamchi.HoTen = txtHoTen.Text.Trim();
                _ctbamchi.DiaChi = txtDiaChi.Text.Trim();
                _ctbamchi.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                _ctbamchi.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                if (_ttkhachhang != null)
                {
                    _ctbamchi.Dot = _ttkhachhang.Dot;
                    _ctbamchi.Ky = _ttkhachhang.Ky;
                    _ctbamchi.Nam = _ttkhachhang.Nam;
                }
                ///
                _ctbamchi.NgayBC = dateBamChi.Value;
                _ctbamchi.Hieu = txtHieu.Text.Trim();
                _ctbamchi.Co = int.Parse(txtCo.Text.Trim());
                _ctbamchi.ChiSo = txtChiSo.Text.Trim();
                if (!string.IsNullOrEmpty(txtVienChi.Text.Trim()))
                    _ctbamchi.VienChi = int.Parse(txtVienChi.Text.Trim());
                if (!string.IsNullOrEmpty(txtDayChi.Text.Trim()))
                    _ctbamchi.DayChi = double.Parse(txtVienChi.Text.Trim());
                if (!string.IsNullOrEmpty(cmbTrangThai.SelectedItem.ToString()))
                    _ctbamchi.TrangThai = cmbTrangThai.SelectedItem.ToString();
                _ctbamchi.MaSoBC = txtMaSoBC.Text.Trim();
                _ctbamchi.TheoYeuCau = txtTheoYeuCau.Text.Trim();

                if (_cBamChi.SuaCTBamChi(_ctbamchi))
                {
                    MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void frmShowBamChi_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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
                    _ttkhachhang = null;
                    Clear();
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa xây dựng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
    }
}

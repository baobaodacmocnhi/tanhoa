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
            cmbTinhTrangKiemTra.SelectedItem = ctbamchi.TinhTrangKiemTra;
            txtHieu.Text = ctbamchi.Hieu;
            txtCo.Text = ctbamchi.Co.ToString();
            txtSoThan.Text = ctbamchi.SoThan;
            cmbChiMatSo.SelectedItem = ctbamchi.ChiMatSo;
            cmbChiKhoaGoc.SelectedItem = ctbamchi.ChiKhoaGoc;
            txtMucDichSuDung.Text = ctbamchi.MucDichSuDung;
            txtChiSo.Text = ctbamchi.ChiSo.ToString();
            cmbTinhTrangChiSo.SelectedItem = ctbamchi.TinhTrangChiSo;
            txtVienChi.Text = ctbamchi.VienChi.ToString();
            txtDayChi.Text = ctbamchi.DayChi.ToString();
            cmbTrangThai.SelectedItem = ctbamchi.TrangThai;
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
            cmbTinhTrangKiemTra.SelectedIndex = -1;
            txtHieu.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            txtChiSo.Text = "";
            cmbTinhTrangChiSo.SelectedIndex = -1;
            cmbChiMatSo.SelectedIndex = -1;
            cmbChiKhoaGoc.SelectedIndex = -1;
            txtMucDichSuDung.Text = "";
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
                if (!string.IsNullOrEmpty(txtGiaBieu.Text.Trim()))
                    _ctbamchi.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                    _ctbamchi.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                if (_ttkhachhang != null)
                {
                    _ctbamchi.Dot = _ttkhachhang.Dot;
                    _ctbamchi.Ky = _ttkhachhang.Ky;
                    _ctbamchi.Nam = _ttkhachhang.Nam;
                }
                ///
                _ctbamchi.NgayBC = dateBamChi.Value;
                if (cmbTinhTrangKiemTra.SelectedItem != null)
                    _ctbamchi.TinhTrangKiemTra = cmbTinhTrangKiemTra.SelectedItem.ToString();
                _ctbamchi.Hieu = txtHieu.Text.Trim();

                if (!string.IsNullOrEmpty(txtCo.Text.Trim()))
                    _ctbamchi.Co = int.Parse(txtCo.Text.Trim());

                _ctbamchi.SoThan = txtSoThan.Text.Trim();

                if (!string.IsNullOrEmpty(txtChiSo.Text.Trim()))
                    _ctbamchi.ChiSo = int.Parse(txtChiSo.Text.Trim());

                if (cmbTinhTrangChiSo.SelectedItem != null)
                    _ctbamchi.TinhTrangChiSo = cmbTinhTrangChiSo.SelectedItem.ToString();

                if (cmbChiMatSo.SelectedItem != null)
                    _ctbamchi.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();

                if (cmbChiKhoaGoc.SelectedItem != null)
                    _ctbamchi.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();

                _ctbamchi.MucDichSuDung = txtMucDichSuDung.Text.Trim();

                if (cmbTrangThai.SelectedItem != null)
                    _ctbamchi.TrangThai = cmbTrangThai.SelectedItem.ToString();

                _ctbamchi.MaSoBC = txtMaSoBC.Text.Trim();

                if (!string.IsNullOrEmpty(txtVienChi.Text.Trim()))
                    _ctbamchi.VienChi = int.Parse(txtVienChi.Text.Trim());

                if (!string.IsNullOrEmpty(txtDayChi.Text.Trim()))
                    _ctbamchi.DayChi = double.Parse(txtDayChi.Text.Trim());

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
                    cmbChiMatSo.SelectedIndex = 0;
                    cmbChiKhoaGoc.SelectedIndex = 0;
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

        private void txtCo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtVienChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDayChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != Char.Parse("."))
                e.Handled = true;
        }

        private void txtChiSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cmbTinhTrangKiemTra_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTinhTrangKiemTra.SelectedItem.ToString())
            {
                case "Nhà đóng cửa":
                    txtChiSo.Enabled = false;
                    cmbTinhTrangChiSo.Enabled = false;
                    cmbChiMatSo.Enabled = false;
                    cmbChiKhoaGoc.Enabled = false;
                    txtHieu.Enabled = false;
                    txtCo.Enabled = false;
                    txtSoThan.Enabled = false;
                    txtMucDichSuDung.Enabled = false;
                    txtVienChi.Enabled = false;
                    txtDayChi.Enabled = false;
                    cmbTrangThai.Enabled = false;
                    txtMaSoBC.Enabled = false;
                    txtTheoYeuCau.Enabled = false;
                    ///
                    txtChiSo.Text = "";
                    cmbTinhTrangChiSo.SelectedIndex = -1;
                    cmbChiMatSo.SelectedIndex = -1;
                    cmbChiKhoaGoc.SelectedIndex = -1;
                    txtHieu.Text = "";
                    txtCo.Text = "";
                    txtSoThan.Text = "";
                    txtMucDichSuDung.Text = "";
                    txtVienChi.Text = "";
                    txtDayChi.Text = "";
                    cmbTrangThai.SelectedIndex = -1;
                    txtMaSoBC.Text = "";
                    txtTheoYeuCau.Text = "";
                    break;
                case "BB mất ĐHN bồi thường":
                case "BB mất ĐHN không bồi thường":
                    txtChiSo.Enabled = false;
                    cmbTinhTrangChiSo.Enabled = false;
                    cmbChiMatSo.Enabled = false;
                    cmbChiKhoaGoc.Enabled = false;
                    txtHieu.Enabled = false;
                    txtCo.Enabled = false;
                    txtSoThan.Enabled = false;
                    txtMucDichSuDung.Enabled = false;
                    txtVienChi.Enabled = false;
                    txtDayChi.Enabled = false;
                    cmbTrangThai.Enabled = false;
                    ///
                    txtChiSo.Text = "";
                    cmbTinhTrangChiSo.SelectedIndex = -1;
                    cmbChiMatSo.SelectedIndex = -1;
                    cmbChiKhoaGoc.SelectedIndex = -1;
                    txtHieu.Text = "";
                    txtCo.Text = "";
                    txtSoThan.Text = "";
                    txtMucDichSuDung.Text = "";
                    txtVienChi.Text = "";
                    txtDayChi.Text = "";
                    cmbTrangThai.SelectedIndex = -1;
                    break;
                default:
                    txtChiSo.Enabled = true;
                    cmbTinhTrangChiSo.Enabled = true;
                    cmbChiMatSo.Enabled = true;
                    cmbChiKhoaGoc.Enabled = true;
                    txtHieu.Enabled = true;
                    txtCo.Enabled = true;
                    txtSoThan.Enabled = true;
                    txtMucDichSuDung.Enabled = true;
                    txtVienChi.Enabled = true;
                    txtDayChi.Enabled = true;
                    cmbTrangThai.Enabled = true;
                    txtMaSoBC.Enabled = true;
                    txtTheoYeuCau.Enabled = true;
                    break;
            }
        }

        
    }
}

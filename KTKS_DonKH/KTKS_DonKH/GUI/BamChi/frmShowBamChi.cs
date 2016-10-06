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
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL;

namespace KTKS_DonKH.GUI.BamChi
{
    public partial class frmShowBamChi : Form
    {
        decimal _MaCTBamChi = 0;
        CTBamChi _ctbamchi = null;
        CThuTien _cThuTien = new CThuTien();
        CBamChi _cBamChi = new CBamChi();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        HOADON _hoadon = null;
        CTrangThaiBamChi _cTrangThaiBamChi = new CTrangThaiBamChi();
        bool _flagFirst = true;

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

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHopDong.Text = hoadon.HOPDONG;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG;
            txtGiaBieu.Text = hoadon.GB.ToString();
            txtDinhMuc.Text = hoadon.DM.ToString();
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
            cmbHienTrangKiemTra.SelectedItem = ctbamchi.HienTrangKiemTra;
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
            cmbTrangThaiBC.SelectedValue = ctbamchi.TrangThaiBC;
            txtGhiChu.Text = ctbamchi.GhiChu;
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
            cmbHienTrangKiemTra.SelectedIndex = -1;
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
            cmbTrangThaiBC.SelectedIndex = -1;
            txtMaSoBC.Text = "";
            txtTheoYeuCau.Text = "";
        }

        private void frmShowNhapBamChi_Load(object sender, EventArgs e)
        {
            this.Location = new Point(30, 70);
            cmbTrangThaiBC.DataSource = _cTrangThaiBamChi.LoadDSTrangThaiBamChi(true);
            cmbTrangThaiBC.DisplayMember = "TenTTBC";
            cmbTrangThaiBC.ValueMember = "TenTTBC";
            cmbTrangThaiBC.SelectedIndex = -1;
            _flagFirst = false;

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
                if ((txtDanhBo.Text.Trim().Length > 0 && txtDanhBo.Text.Trim().Length < 11) || txtDanhBo.Text.Trim().Length > 11)
                {
                    MessageBox.Show("Lỗi Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _ctbamchi.DanhBo = txtDanhBo.Text.Trim();
                _ctbamchi.HopDong = txtHopDong.Text.Trim();
                _ctbamchi.HoTen = txtHoTen.Text.Trim().ToUpper();
                _ctbamchi.DiaChi = txtDiaChi.Text.Trim().ToUpper();
                if (!string.IsNullOrEmpty(txtGiaBieu.Text.Trim()))
                    _ctbamchi.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                    _ctbamchi.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                if (_hoadon != null)
                {
                    _ctbamchi.Dot = _hoadon.DOT.ToString();
                    _ctbamchi.Ky = _hoadon.KY.ToString();
                    _ctbamchi.Nam = _hoadon.NAM.ToString();
                }
                ///
                _ctbamchi.NgayBC = dateBamChi.Value;
                if (cmbHienTrangKiemTra.SelectedItem != null)
                    _ctbamchi.HienTrangKiemTra = cmbHienTrangKiemTra.SelectedItem.ToString();
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

                if (cmbTrangThaiBC.SelectedValue != null)
                    _ctbamchi.TrangThaiBC = cmbTrangThaiBC.SelectedValue.ToString();

                _ctbamchi.GhiChu = txtGhiChu.Text.Trim();
                _ctbamchi.MaSoBC = txtMaSoBC.Text.Trim();

                if (!string.IsNullOrEmpty(txtVienChi.Text.Trim()))
                    _ctbamchi.VienChi = int.Parse(txtVienChi.Text.Trim());

                if (!string.IsNullOrEmpty(txtDayChi.Text.Trim()))
                    _ctbamchi.DayChi = double.Parse(txtDayChi.Text.Trim());

                _ctbamchi.TheoYeuCau = txtTheoYeuCau.Text.Trim().ToUpper();

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
                if (_cThuTien.GetMoiNhat(txtDanhBo.Text.Trim()) != null)
                {
                    _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                    LoadTTKH(_hoadon);
                    cmbChiMatSo.SelectedIndex = 0;
                    cmbChiKhoaGoc.SelectedIndex = 0;
                }
                else
                {
                    _hoadon = null;
                    Clear();
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_ctbamchi != null)
            {
                LinQ.BamChi bamchi = _ctbamchi.BamChi;
                if (MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    if (_cBamChi.XoaCTBamChi(_ctbamchi, CTaiKhoan.MaUser))
                    {
                        if (bamchi.CTBamChis.Count == 0)
                            _cBamChi.XoaBamChi(bamchi);
                        MessageBox.Show("Xóa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
            }
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
            switch (cmbHienTrangKiemTra.SelectedItem.ToString())
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
                    cmbTrangThaiBC.Enabled = false;
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
                    cmbTrangThaiBC.SelectedIndex = -1;
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
                    cmbTrangThaiBC.Enabled = false;
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
                    cmbTrangThaiBC.SelectedIndex = -1;
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
                    cmbTrangThaiBC.Enabled = true;
                    txtMaSoBC.Enabled = true;
                    txtTheoYeuCau.Enabled = true;
                    break;
            }
        }

        private void cmbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagFirst)
            {

            }
            else
                switch (((TrangThaiBamChi)cmbTrangThaiBC.SelectedItem).TenTTBC)
                {
                    case "Bấm Chì Thân":
                    case "Đóng Cửa":
                    case "Lấp Chừa Mặt Số":
                    case "Còn Chì":
                    case "Hầm Sâu":
                    case "Trở Ngại Khác":
                        txtVienChi.Text = "";
                        txtDayChi.Text = "";
                        break;
                    case "Bấm Chì Góc-Chì Thân":
                        txtVienChi.Text = "2";
                        txtDayChi.Text = "1.2";
                        break;
                    default:
                        txtVienChi.Text = "1";
                        txtDayChi.Text = "0.6";
                        break;
                }

        }

        
    }
}

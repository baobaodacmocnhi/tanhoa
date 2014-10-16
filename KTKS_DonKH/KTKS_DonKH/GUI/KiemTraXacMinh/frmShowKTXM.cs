using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.HeThong;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.CapNhat;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmShowKTXM : Form
    {
        decimal _MaCTKTXM = 0;
        CTKTXM _ctktxm = null;
        CKTXM _cKTXM = new CKTXM();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        TTKhachHang _ttkhachhang = null;
        CTTKH _cTTKH = new CTTKH();
        CHienTrangKiemTra _cHienTrangKiemTra = new CHienTrangKiemTra();
        bool _flagFirst = true; 

        public frmShowKTXM()
        {
            InitializeComponent();
        }

        public frmShowKTXM(decimal MaCTKTXM)
        {
            InitializeComponent();
            _MaCTKTXM = MaCTKTXM;
        }

        public frmShowKTXM(decimal MaCTKTXM, bool TimKiem)
        {
            InitializeComponent();
            _MaCTKTXM = MaCTKTXM;
            if (TimKiem)
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void frmShowKTXM_Load(object sender, EventArgs e)
        {
            this.Location = new Point(30, 70);
            cmbHienTrangKiemTra.DataSource = _cHienTrangKiemTra.LoadDSHienTrangKiemTra(true);
            cmbHienTrangKiemTra.DisplayMember = "TenHTKT";
            cmbHienTrangKiemTra.ValueMember = "TenHTKT";
            cmbHienTrangKiemTra.SelectedIndex = -1;
            _flagFirst = false;

            if (CTaiKhoan.RoleQLBamChi_CapNhat || CTaiKhoan.RoleBamChi_CapNhat || CTaiKhoan.RoleQLBamChi_Xem || CTaiKhoan.RoleBamChi_Xem)
            {
                lbTheoYeuCau.Visible = true;
                txtTheoYeuCau.Visible = true;
            }
            if (_cKTXM.CheckCTKTXMbyID(_MaCTKTXM))
            {
                _ctktxm = _cKTXM.getCTKTXMbyID(_MaCTKTXM);
                //if (CTaiKhoan.RoleQLKTXM_CapNhat)
                //    btnXoa.Enabled = true;
                if (_ctktxm.KTXM.ToXuLy)
                    txtMaDon.Text = "TXL"+_ctktxm.KTXM.MaDonTXL.ToString().Insert(_ctktxm.KTXM.MaDonTXL.ToString().Length - 2, "-");
                else
                    txtMaDon.Text = _ctktxm.KTXM.MaDon.ToString().Insert(_ctktxm.KTXM.MaDon.ToString().Length - 2, "-");
                LoadCTKTXM(_ctktxm);
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
            string a, b, c;
            _cPhuongQuan.getTTDHNbyID(txtDanhBo.Text.Trim(), out a, out b, out c);
            txtHieu.Text = a;
            txtCo.Text = b;
            txtSoThan.Text = c;
        }

        public void LoadCTKTXM(CTKTXM ctktxm)
        {
            txtDanhBo.Text = ctktxm.DanhBo;
            txtHopDong.Text = ctktxm.HopDong;
            txtHoTen.Text = ctktxm.HoTen;
            txtDiaChi.Text = ctktxm.DiaChi;
            txtGiaBieu.Text = ctktxm.GiaBieu;
            txtDinhMuc.Text = ctktxm.DinhMuc;
            ///
            dateKTXM.Value = ctktxm.NgayKTXM.Value;
                
            txtHieu.Text = ctktxm.Hieu;
            txtCo.Text = ctktxm.Co;
            txtSoThan.Text = ctktxm.SoThan;
            txtChiSo.Text = ctktxm.ChiSo;
            cmbTinhTrangChiSo.SelectedItem = ctktxm.TinhTrangChiSo;
            cmbChiMatSo.SelectedItem = ctktxm.ChiMatSo;
            cmbChiKhoaGoc.SelectedItem = ctktxm.ChiKhoaGoc;
            txtMucDichSuDung.Text = ctktxm.MucDichSuDung;
            txtDienThoai.Text = ctktxm.DienThoai;
            txtHoTenKHKy.Text = ctktxm.HoTenKHKy;
            cmbTinhTrangDHN.SelectedItem = ctktxm.TinhTrangDHN;
            txtNoiDungKiemTra.Text = ctktxm.NoiDungKiemTra;
            txtTheoYeuCau.Text = _ctktxm.TheoYeuCau;

            if (ctktxm.LapBangGia)
            {
                chkLapBangGia.Checked = true;
                dateLapBangGia.Value = ctktxm.NgayLapBangGia.Value;
            }

            if (ctktxm.DongTienBoiThuong)
            {
                chkDongTienBoiThuong.Checked = true;
                dateDongTien.Value = ctktxm.NgayDongTien.Value;
                txtSoTien.Text = ctktxm.SoTien.ToString();
            }

            if (ctktxm.ChuyenLapTBCat)
            {
                chkChuyenCatHuy.Checked = true;
                dateChuyenCatHuy.Value = ctktxm.NgayChuyenLapTBCat.Value;
            }

            try
            {
                cmbHienTrangKiemTra.SelectedValue = ctktxm.HienTrangKiemTra;
            }
            catch (Exception)
            {
            }
            
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
            //dateKTXM.Value = DateTime.Now;
            txtHieu.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            //txtChiSo.Text = "";
            //txtChiMatSo.Text = "";
            //txtChiKhoaGoc.Text = "";
            //txtMucDichSuDung.Text = "";
            //txtDienThoai.Text = "";
            //txtHoTenKHKy.Text = "";
            //txtNoiDungKiemTra.Text = "";
            chkLapBangGia.Checked = false;
            dateLapBangGia.Value = DateTime.Now;
            ///
            chkDongTienBoiThuong.Checked = false;
            dateDongTien.Value = DateTime.Now;
            txtSoTien.Text = "";
            ///
            chkChuyenCatHuy.Checked = false;
            dateChuyenCatHuy.Value = DateTime.Now;
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_ctktxm != null)
            {
                _ctktxm.DanhBo = txtDanhBo.Text.Trim();
                _ctktxm.HopDong = txtHopDong.Text.Trim();
                _ctktxm.HoTen = txtHoTen.Text.Trim().ToUpper();
                _ctktxm.DiaChi = txtDiaChi.Text.Trim().ToUpper();
                _ctktxm.GiaBieu = txtGiaBieu.Text.Trim();
                _ctktxm.DinhMuc = txtDinhMuc.Text.Trim();
                if (_ttkhachhang != null)
                {
                    _ctktxm.Dot = _ttkhachhang.Dot;
                    _ctktxm.Ky = _ttkhachhang.Ky;
                    _ctktxm.Nam = _ttkhachhang.Nam;
                }
                ///
                _ctktxm.NgayKTXM = dateKTXM.Value;

                if (cmbHienTrangKiemTra.SelectedValue != null)
                    _ctktxm.HienTrangKiemTra = cmbHienTrangKiemTra.SelectedValue.ToString();

                _ctktxm.Hieu = txtHieu.Text.Trim();
                _ctktxm.Co = txtCo.Text.Trim();
                _ctktxm.SoThan = txtSoThan.Text.Trim();
                _ctktxm.ChiSo = txtChiSo.Text.Trim();

                if (cmbTinhTrangChiSo.SelectedItem != null)
                _ctktxm.TinhTrangChiSo = cmbTinhTrangChiSo.SelectedItem.ToString();

                if (cmbChiMatSo.SelectedItem != null)
                _ctktxm.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();

                if (cmbChiKhoaGoc.SelectedItem != null)
                _ctktxm.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();

                _ctktxm.MucDichSuDung = txtMucDichSuDung.Text.Trim();
                _ctktxm.DienThoai = txtDienThoai.Text.Trim();
                _ctktxm.HoTenKHKy = txtHoTenKHKy.Text.Trim().ToUpper();

                if (cmbTinhTrangDHN.SelectedItem != null)
                _ctktxm.TinhTrangDHN = cmbTinhTrangDHN.SelectedItem.ToString();

                _ctktxm.NoiDungKiemTra = txtNoiDungKiemTra.Text.Trim();
                _ctktxm.TheoYeuCau = txtTheoYeuCau.Text.Trim().ToUpper();

                if (_ctktxm.LapBangGia != chkLapBangGia.Checked)
                    if (chkLapBangGia.Checked)
                    {
                        _ctktxm.LapBangGia = true;
                        _ctktxm.NgayLapBangGia = dateLapBangGia.Value;
                    }
                    else
                    {
                        _ctktxm.LapBangGia = false;
                        _ctktxm.NgayLapBangGia = null;
                    }

                if(_ctktxm.DongTienBoiThuong!=chkDongTienBoiThuong.Checked)
                    if (chkDongTienBoiThuong.Checked)
                    {
                        _ctktxm.DongTienBoiThuong = true;
                        _ctktxm.NgayDongTien = dateDongTien.Value;
                        if (!string.IsNullOrEmpty(txtSoTien.Text.Trim()))
                            _ctktxm.SoTien = int.Parse(txtSoTien.Text.Trim());
                    }
                    else
                    {
                        _ctktxm.DongTienBoiThuong = false;
                        _ctktxm.NgayDongTien = null;
                        _ctktxm.SoTien = null;
                    }

                if (_ctktxm.ChuyenLapTBCat != chkChuyenCatHuy.Checked)
                    if (chkChuyenCatHuy.Checked)
                    {
                        _ctktxm.ChuyenLapTBCat = true;
                        _ctktxm.NgayChuyenLapTBCat = dateChuyenCatHuy.Value;
                    }
                    else
                    {
                        _ctktxm.ChuyenLapTBCat = false;
                        _ctktxm.NgayChuyenLapTBCat = null;
                    }

                if (_cKTXM.SuaCTKTXM(_ctktxm))
                {
                    MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_ctktxm != null)
                if (MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    if (_cKTXM.XoaCTKTXM(_ctktxm, CTaiKhoan.MaUser))
                    {
                        MessageBox.Show("Xóa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
        }

        private void frmShowKTXM_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtChiSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtCo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cmbTinhTrangKiemTra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagFirst)
            {

            }
            else
                switch (((HienTrangKiemTra)cmbHienTrangKiemTra.SelectedItem).TenHTKT)
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
                        txtDienThoai.Enabled = false;
                        txtHoTenKHKy.Enabled = false;
                        ///
                        txtChiSo.Text = "";
                        cmbTinhTrangChiSo.SelectedIndex = -1;
                        cmbChiMatSo.SelectedIndex = -1;
                        cmbChiKhoaGoc.SelectedIndex = -1;
                        txtHieu.Text = "";
                        txtCo.Text = "";
                        txtSoThan.Text = "";
                        txtMucDichSuDung.Text = "";
                        txtDienThoai.Text = "";
                        txtHoTenKHKy.Text = "";
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
                        txtDienThoai.Enabled = true;
                        txtHoTenKHKy.Enabled = true;
                        ///
                        txtChiSo.Text = "";
                        cmbTinhTrangChiSo.SelectedIndex = -1;
                        cmbChiMatSo.SelectedIndex = -1;
                        cmbChiKhoaGoc.SelectedIndex = -1;
                        txtHieu.Text = "";
                        txtCo.Text = "";
                        txtSoThan.Text = "";
                        txtMucDichSuDung.Text = "";
                        txtDienThoai.Text = "";
                        txtHoTenKHKy.Text = "";
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
                        txtDienThoai.Enabled = true;
                        txtHoTenKHKy.Enabled = true;
                        ///
                        txtChiSo.Text = "";
                        cmbTinhTrangChiSo.SelectedIndex = -1;
                        cmbChiMatSo.SelectedIndex = -1;
                        cmbChiKhoaGoc.SelectedIndex = -1;
                        txtHieu.Text = "";
                        txtCo.Text = "";
                        txtSoThan.Text = "";
                        txtMucDichSuDung.Text = "";
                        txtDienThoai.Text = "";
                        txtHoTenKHKy.Text = "";
                        break;
                }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLapBangGia.Checked)
                groupBoxLapBangGia.Enabled = true;
            else
                groupBoxLapBangGia.Enabled = false;
        }

        private void chkDongTienBoiThuong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDongTienBoiThuong.Checked)
                groupBoxDongTienBoiThuong.Enabled = true;
            else
                groupBoxDongTienBoiThuong.Enabled = false;
        }

        private void chkChuyenCatHuy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenCatHuy.Checked)
                groupBoxChuyenCatHuy.Enabled = true;
            else
                groupBoxChuyenCatHuy.Enabled = false;
        }

       
    }
}

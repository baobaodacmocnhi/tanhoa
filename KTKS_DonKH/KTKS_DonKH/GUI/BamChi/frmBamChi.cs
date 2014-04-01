using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.HeThong;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.BamChi;

namespace KTKS_DonKH.GUI.BamChi
{
    public partial class frmBamChi : Form
    {
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        TTKhachHang _ttkhachhang = null;
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CTTKH _cTTKH = new CTTKH();
        CBamChi _cBamChi = new CBamChi();
        int selectedindex = -1;

        public frmBamChi()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
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

            selectedindex = -1;
        }

        private void frmNhapBamChi_Load(object sender, EventArgs e)
        {
            dgvDSNhapBamChi.AutoGenerateColumns = false;
            dgvDSNhapBamChi.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSNhapBamChi.Font, FontStyle.Bold);

            txtMaSoBC.Text = CTaiKhoan.MaKiemBamChi;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                ///Đơn Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", ""))) != null)
                    {
                        _dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDon.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");
                        dgvDSNhapBamChi.DataSource = _cBamChi.LoadDSCTBamChi_TXL(_dontxl.MaDon, CTaiKhoan.MaUser);
                        MessageBox.Show("Mã Đơn TXL này có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDanhBo.Focus();
                    }
                    else
                    {
                        _dontxl = null;
                        dgvDSNhapBamChi.DataSource = null;
                        Clear();
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ///Đơn Tổ Khách Hàng
                else
                    if (_cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) != null)
                    {
                        _donkh = _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                        txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                        dgvDSNhapBamChi.DataSource = _cBamChi.LoadDSCTBamChi(_donkh.MaDon, CTaiKhoan.MaUser);
                        MessageBox.Show("Mã Đơn KH này có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDanhBo.Focus();
                    }
                    else
                    {
                        _donkh = null;
                        dgvDSNhapBamChi.DataSource = null;
                        Clear();
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                    _ttkhachhang = null;
                    Clear();
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                ///Nếu đơn thuộc Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_dontxl != null && (txtDanhBo.Text.Trim() != "" || txtHoTen.Text.Trim() != "" || txtDiaChi.Text.Trim() != ""))
                    {
                        if (!_cBamChi.CheckBamChibyMaDon_TXL(_dontxl.MaDon))
                        {
                            LinQ.BamChi bamchi = new LinQ.BamChi();
                            bamchi.ToXuLy = true;
                            bamchi.MaDonTXL = _dontxl.MaDon;

                            if (_cBamChi.ThemBamChi(bamchi))
                            {
                                if (string.IsNullOrEmpty(_dontxl.TienTrinh))
                                    _dontxl.TienTrinh = "BamChi";
                                else
                                    _dontxl.TienTrinh += ",BamChi";
                                _dontxl.Nhan = true;
                                _cDonTXL.SuaDonTXL(_dontxl, true);
                            }
                        }
                        if (_cBamChi.CheckCTBamChibyMaDonDanhBo_TXL(_dontxl.MaDon, txtDanhBo.Text.Trim()))
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Bấm Chì", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        CTBamChi ctbamchi = new CTBamChi();
                        ctbamchi.MaBC = _cBamChi.getBamChibyMaDon_TXL(_dontxl.MaDon).MaBC;
                        ctbamchi.DanhBo = txtDanhBo.Text.Trim();
                        ctbamchi.HopDong = txtHopDong.Text.Trim();
                        ctbamchi.HoTen = txtHoTen.Text.Trim();
                        ctbamchi.DiaChi = txtDiaChi.Text.Trim();
                        ctbamchi.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        ctbamchi.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        if (_ttkhachhang != null)
                        {
                            ctbamchi.Dot = _ttkhachhang.Dot;
                            ctbamchi.Ky = _ttkhachhang.Ky;
                            ctbamchi.Nam = _ttkhachhang.Nam;
                        }
                        ///
                        ctbamchi.NgayBC = dateBamChi.Value;
                        ctbamchi.Hieu = txtHieu.Text.Trim();
                        ctbamchi.Co = int.Parse(txtCo.Text.Trim());
                        ctbamchi.ChiSo = txtChiSo.Text.Trim();
                        if (!string.IsNullOrEmpty(txtVienChi.Text.Trim()))
                            ctbamchi.VienChi = int.Parse(txtVienChi.Text.Trim());
                        if (!string.IsNullOrEmpty(txtDayChi.Text.Trim()))
                            ctbamchi.DayChi = double.Parse(txtVienChi.Text.Trim());
                        ctbamchi.TrangThai = cmbTrangThai.SelectedText;
                        ctbamchi.MaSoBC = txtMaSoBC.Text.Trim();
                        ctbamchi.TheoYeuCau = txtTheoYeuCau.Text.Trim();

                        if (_cBamChi.ThemCTBamChi(ctbamchi))
                        {
                            MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvDSNhapBamChi.DataSource = _cBamChi.LoadDSCTBamChi_TXL(_dontxl.MaDon, CTaiKhoan.MaUser);
                            _ttkhachhang = null;
                            Clear();
                        }
                    }
                    else
                        MessageBox.Show("Đơn này không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ///Nếu đơn thuộc Tổ Khách Hàng
                else
                    if (_donkh != null && (txtDanhBo.Text.Trim() != "" || txtHoTen.Text.Trim() != "" || txtDiaChi.Text.Trim() != ""))
                    {
                        if (!_cBamChi.CheckBamChibyMaDon(_donkh.MaDon))
                        {
                            LinQ.BamChi bamchi = new LinQ.BamChi();
                            bamchi.MaDon = _donkh.MaDon;

                            if (_cBamChi.ThemBamChi(bamchi))
                            {
                                if (string.IsNullOrEmpty(_donkh.TienTrinh))
                                    _donkh.TienTrinh = "BamChi";
                                else
                                    _donkh.TienTrinh += ",BamChi";
                                _donkh.Nhan = true;
                                _cDonKH.SuaDonKH(_donkh, true);
                            }
                        }
                        if (_cBamChi.CheckCTBamChibyMaDonDanhBo(_donkh.MaDon, txtDanhBo.Text.Trim()))
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Bấm Chì", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        CTBamChi ctbamchi = new CTBamChi();
                        ctbamchi.MaBC = _cBamChi.getBamChibyMaDon_TXL(_dontxl.MaDon).MaBC;
                        ctbamchi.DanhBo = txtDanhBo.Text.Trim();
                        ctbamchi.HopDong = txtHopDong.Text.Trim();
                        ctbamchi.HoTen = txtHoTen.Text.Trim();
                        ctbamchi.DiaChi = txtDiaChi.Text.Trim();
                        ctbamchi.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        ctbamchi.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        if (_ttkhachhang != null)
                        {
                            ctbamchi.Dot = _ttkhachhang.Dot;
                            ctbamchi.Ky = _ttkhachhang.Ky;
                            ctbamchi.Nam = _ttkhachhang.Nam;
                        }
                        ///
                        ctbamchi.NgayBC = dateBamChi.Value;
                        ctbamchi.Hieu = txtHieu.Text.Trim();
                        ctbamchi.Co = int.Parse(txtCo.Text.Trim());
                        ctbamchi.ChiSo = txtChiSo.Text.Trim();
                        if (!string.IsNullOrEmpty(txtVienChi.Text.Trim()))
                            ctbamchi.VienChi = int.Parse(txtVienChi.Text.Trim());
                        if (!string.IsNullOrEmpty(txtDayChi.Text.Trim()))
                            ctbamchi.DayChi = double.Parse(txtVienChi.Text.Trim());
                        ctbamchi.TrangThai = cmbTrangThai.SelectedText;
                        ctbamchi.MaSoBC = txtMaSoBC.Text.Trim();
                        ctbamchi.TheoYeuCau = txtTheoYeuCau.Text.Trim();

                        if (_cBamChi.ThemCTBamChi(ctbamchi))
                        {
                            MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvDSNhapBamChi.DataSource = _cBamChi.LoadDSCTBamChi_TXL(_donkh.MaDon, CTaiKhoan.MaUser);
                            _ttkhachhang = null;
                            Clear();
                        }
                    }
                    else
                        MessageBox.Show("Đơn này không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedindex != -1)
                {
                    CTBamChi ctbamchi = new CTBamChi();
                    ctbamchi = _cBamChi.getCTBamChibyID(decimal.Parse(dgvDSNhapBamChi["MaCTBC", selectedindex].Value.ToString()));
                    ctbamchi.DanhBo = txtDanhBo.Text.Trim();
                    ctbamchi.HopDong = txtHopDong.Text.Trim();
                    ctbamchi.HoTen = txtHoTen.Text.Trim();
                    ctbamchi.DiaChi = txtDiaChi.Text.Trim();
                    ctbamchi.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                    ctbamchi.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                    if (_ttkhachhang != null)
                    {
                        ctbamchi.Dot = _ttkhachhang.Dot;
                        ctbamchi.Ky = _ttkhachhang.Ky;
                        ctbamchi.Nam = _ttkhachhang.Nam;
                    }
                    ///
                    ctbamchi.NgayBC = dateBamChi.Value;
                    ctbamchi.Hieu = txtHieu.Text.Trim();
                    ctbamchi.Co = int.Parse(txtCo.Text.Trim());
                    ctbamchi.ChiSo = txtChiSo.Text.Trim();
                    if (!string.IsNullOrEmpty(txtVienChi.Text.Trim()))
                        ctbamchi.VienChi = int.Parse(txtVienChi.Text.Trim());
                    if (!string.IsNullOrEmpty(txtDayChi.Text.Trim()))
                        ctbamchi.DayChi = double.Parse(txtVienChi.Text.Trim());
                    if (!string.IsNullOrEmpty(cmbTrangThai.SelectedItem.ToString()))
                        ctbamchi.TrangThai = cmbTrangThai.SelectedItem.ToString();
                    ctbamchi.MaSoBC = txtMaSoBC.Text.Trim();
                    ctbamchi.TheoYeuCau = txtTheoYeuCau.Text.Trim();

                    ///Nếu Đơn thuộc Tổ Xử Lý
                    if (ctbamchi.BamChi.ToXuLy)
                    {
                        if (_dontxl != null && (txtDanhBo.Text.Trim() != "" || txtHoTen.Text.Trim() != "" || txtDiaChi.Text.Trim() != ""))
                        {
                            if (_cBamChi.SuaCTBamChi(ctbamchi))
                            {
                                MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvDSNhapBamChi.DataSource = _cBamChi.LoadDSCTBamChi_TXL(_dontxl.MaDon, CTaiKhoan.MaUser);
                                Clear();
                            }
                        }
                        else
                            MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        ///Nếu Đơn thuộc Tổ Khách Hàng
                        if (_donkh != null && (txtDanhBo.Text.Trim() != "" || txtHoTen.Text.Trim() != "" || txtDiaChi.Text.Trim() != ""))
                        {
                            if (_cBamChi.SuaCTBamChi(ctbamchi))
                            {
                                MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvDSNhapBamChi.DataSource = _cBamChi.LoadDSCTBamChi(_donkh.MaDon, CTaiKhoan.MaUser);
                                Clear();
                            }
                        }
                        else
                            MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDSNhapBamChi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedindex = e.RowIndex;
                LoadCTBamChi(_cBamChi.getCTBamChibyID(decimal.Parse(dgvDSNhapBamChi["MaCTBC", e.RowIndex].Value.ToString())));
            }
            catch (Exception)
            {
            }
        }

        private void dgvDSNhapBamChi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSNhapBamChi.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSNhapBamChi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSNhapBamChi.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void txtVienChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDayChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cmbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTrangThai.SelectedText)
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
                default:
                    txtVienChi.Text = "1";
                    txtDayChi.Text = "0.6";
                    break;
            }
        }

        
    }
}

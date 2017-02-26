using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.ThaoThuTraLoi;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ToBamChi;

namespace KTKS_DonKH.GUI.ThaoThuTraLoi
{
    public partial class frmTTTL : Form
    {
        string _mnu = "mnuTTTL";
        CThuTien _cThuTien = new CThuTien();
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        CTTTTL _cttttl = null;
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CTTTL _cTTTL = new CTTTL();
        CGhiChuCTTTTL _cGhiChuCTTTTL = new CGhiChuCTTTTL();
        CDocSo _cDocSo = new CDocSo();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CVeViecTTTL _cVeViecTTTL = new CVeViecTTTL();
        decimal _MaCTTTTL = -1;

        public frmTTTL()
        {
            InitializeComponent();
        }

        public frmTTTL(decimal MaCTTTTL)
        {
            _MaCTTTTL = MaCTTTTL;
            InitializeComponent();
        }

        private void frmTTTL_Load(object sender, EventArgs e)
        {
            dgvLichSuTTTL.AutoGenerateColumns = false;
            dgvGhiChu.AutoGenerateColumns = false;

            cmbVeViec.DataSource = _cVeViecTTTL.GetDS();
            cmbVeViec.DisplayMember = "TenVV";
            cmbVeViec.SelectedIndex = -1;

            if (_MaCTTTTL != -1)
            {
                txtMaCTTTTL.Text = _MaCTTTTL.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtMaCTTTTL_KeyPress(sender, arg);
            }
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHopDong.Text = hoadon.HOPDONG;
            txtLoTrinh.Text = hoadon.DOT + hoadon.MAY + hoadon.STT;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.getPhuongQuanByID(hoadon.Quan, hoadon.Phuong);
            txtGiaBieu.Text = hoadon.GB.ToString();
            txtDinhMuc.Text = hoadon.DM.ToString();

            dgvLichSuTTTL.DataSource = _cTTTL.GetLichSuCTByDanhBo(_hoadon.DANHBA);
        }

        public void LoadTTTL(CTTTTL cttttl)
        {
            if (cttttl.TTTL.MaDon != null)
                txtMaDon.Text = cttttl.TTTL.MaDon.Value.ToString().Insert(cttttl.TTTL.MaDon.Value.ToString().Length - 2, "-");
            else
                if (cttttl.TTTL.MaDonTXL != null)
                    txtMaDon.Text = "TXL" + cttttl.TTTL.MaDonTXL.Value.ToString().Insert(cttttl.TTTL.MaDonTXL.Value.ToString().Length - 2, "-");
                else
                    if (cttttl.TTTL.MaDonTBC != null)
                        txtMaDon.Text = "TBC" + cttttl.TTTL.MaDonTBC.Value.ToString().Insert(cttttl.TTTL.MaDonTBC.Value.ToString().Length - 2, "-");

            txtMaCTTTTL.Text = cttttl.MaCTTTTL.ToString().Insert(cttttl.MaCTTTTL.ToString().Length - 2, "-");
            txtDanhBo.Text = cttttl.DanhBo;
            txtHopDong.Text = cttttl.HopDong;
            txtLoTrinh.Text = cttttl.LoTrinh;
            txtHoTen.Text = cttttl.HoTen;
            txtDiaChi.Text = cttttl.DiaChi;
            txtGiaBieu.Text = cttttl.GiaBieu;
            txtDinhMuc.Text = cttttl.DinhMuc;
            txtVeViec.Text = cttttl.VeViec;
            txtNoiDung.Text = cttttl.NoiDung;
            txtNoiNhan.Text = cttttl.NoiNhan;

            if (cttttl.GiamNuocXaBo)
                chkGiamNuocXaBo.Checked = true;
            if (cttttl.KiemDinhDHN_Dung)
                chkKiemDinhDHN_Dung.Checked = true;
            if (cttttl.KiemDinhDHN_Sai)
                chkKiemDinhDHN_Sai.Checked = true;
            if (cttttl.ThayDHN)
                chkThayDHN.Checked = true;
            if (cttttl.DieuChinh_GB_DM)
                chkDieuChinh_GB_DM.Checked = true;
            if (cttttl.ThuMoi)
                chkThuMoi.Checked = true;
            if (cttttl.ThuBao)
                chkThuBao.Checked = true;

            dgvLichSuTTTL.DataSource = _cTTTL.GetLichSuCTByDanhBo(cttttl.DanhBo);
            dgvGhiChu.DataSource = _cGhiChuCTTTTL.GetDS(cttttl.MaCTTTTL);
        }

        public void Clear()
        {
            txtMaDon.Text = "";
            txtMaCTTTTL.Text = "";
            ///
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            ///
            txtVeViec.Text = "";
            txtNoiDung.Text = "";
            txtNoiNhan.Text = "";
            ///
            chkGiamNuocXaBo.Checked = false;
            chkKiemDinhDHN_Dung.Checked = false;
            chkKiemDinhDHN_Sai.Checked = false;
            chkThayDHN.Checked = false;
            chkDieuChinh_GB_DM.Checked = false;
            chkThuMoi.Checked = false;
            chkThuBao.Checked = false;

            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            _cttttl = null;
            _MaCTTTTL = -1;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                string MaDon = txtMaDon.Text.Trim();
                Clear();
                txtMaDon.Text = MaDon;
                ///Đơn Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_cDonTXL.CheckExist(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", ""))) == true)
                    {
                        _dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDon.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");
                        if (_cThuTien.GetMoiNhat(_dontxl.DanhBo) != null)
                        {
                            _hoadon = _cThuTien.GetMoiNhat(_dontxl.DanhBo);
                            LoadTTKH(_hoadon);
                        }
                        else
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    if (txtMaDon.Text.Trim().ToUpper().Contains("TBC"))
                    {
                        if (_cDonTBC.CheckExist(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", ""))) == true)
                        {
                            _dontbc = _cDonTBC.Get(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", "")));
                            txtMaDon.Text = "TBC" + _dontbc.MaDon.ToString().Insert(_dontbc.MaDon.ToString().Length - 2, "-");
                            if (_cThuTien.GetMoiNhat(_dontbc.DanhBo) != null)
                            {
                                _hoadon = _cThuTien.GetMoiNhat(_dontbc.DanhBo);
                                LoadTTKH(_hoadon);
                            }
                            else
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ///Đơn Tổ Khách Hàng
                    else
                        if (_cDonKH.CheckExist(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) == true)
                        {
                            _dontkh = _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                            txtMaDon.Text = _dontkh.MaDon.ToString().Insert(_dontkh.MaDon.ToString().Length - 2, "-");
                            if (_cThuTien.GetMoiNhat(_dontkh.DanhBo) != null)
                            {
                                _hoadon = _cThuTien.GetMoiNhat(_dontkh.DanhBo);
                                LoadTTKH(_hoadon);
                            }
                            else
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cThuTien.GetMoiNhat(txtDanhBo.Text.Trim()) != null)
                {
                    _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                    LoadTTKH(_hoadon);
                }
                else
                {
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtMaCTTTTL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && _cTTTL.CheckExist(decimal.Parse(txtMaCTTTTL.Text.Trim().Replace("-", ""))) == true)
            {
                _cttttl = _cTTTL.GetCT(decimal.Parse(txtMaCTTTTL.Text.Trim().Replace("-", "")));
                LoadTTTL(_cttttl);
            }
        }

        private void cmbVeViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVeViec.SelectedIndex != -1)
            {
                VeViecTTTL vv = (VeViecTTTL)cmbVeViec.SelectedItem;
                txtVeViec.Text = vv.TenVV;
                txtNoiDung.Text = vv.NoiDung;
                txtNoiNhan.Text = vv.NoiNhan + " (" + txtMaDon.Text.Trim() + ")";
            }
            else
            {
                txtVeViec.Text = "";
                txtNoiDung.Text = "";
                txtNoiNhan.Text = "";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (txtVeViec.Text.Trim() != "" && txtNoiDung.Text.Trim() != "" & txtNoiNhan.Text.Trim() != "")
                    {
                        MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    CTTTTL cttttl = new CTTTTL();

                    if (_dontkh != null)
                    {
                        if (!_cTTTL.CheckExist("TKH", _dontxl.MaDon))
                        {
                            TTTL tttl = new TTTL();
                            tttl.MaDon = _dontkh.MaDon;
                            _cTTTL.Them(tttl);
                        }
                        if (_cTTTL.CheckExistCT("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim(), DateTime.Now))
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                        cttttl.MaTTTL = _cTTTL.Get("TKH", _dontkh.MaDon).MaTTTL;
                    }
                    else
                        if (_dontxl != null)
                        {
                            if (!_cTTTL.CheckExist("TXL", _dontxl.MaDon))
                            {
                                TTTL tttl = new TTTL();
                                tttl.MaDonTXL = _dontxl.MaDon;
                                _cTTTL.Them(tttl);
                            }
                            if (_cTTTL.CheckExistCT("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim(), DateTime.Now))
                            {
                                MessageBox.Show("Danh Bộ này đã được Lập Thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //return;
                            }
                            cttttl.MaTTTL = _cTTTL.Get("TXL", _dontxl.MaDon).MaTTTL;
                        }
                        else
                            if (_dontbc != null)
                            {
                                if (!_cTTTL.CheckExist("TBC", _dontbc.MaDon))
                                {
                                    TTTL tttl = new TTTL();
                                    tttl.MaDonTBC = _dontbc.MaDon;
                                    _cTTTL.Them(tttl);
                                }
                                if (_cTTTL.CheckExistCT("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim(), DateTime.Now))
                                {
                                    MessageBox.Show("Danh Bộ này đã được Lập Thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //return;
                                }
                                cttttl.MaTTTL = _cTTTL.Get("TBC", _dontbc.MaDon).MaTTTL;
                            }

                    cttttl.DanhBo = txtDanhBo.Text.Trim();
                    cttttl.HopDong = txtHopDong.Text.Trim();
                    cttttl.LoTrinh = txtLoTrinh.Text.Trim();
                    cttttl.HoTen = txtHoTen.Text.Trim();
                    cttttl.DiaChi = txtDiaChi.Text.Trim();
                    cttttl.GiaBieu = txtGiaBieu.Text.Trim();
                    cttttl.DinhMuc = txtDinhMuc.Text.Trim();
                    if (_hoadon != null)
                    {
                        cttttl.Dot = _hoadon.DOT.ToString();
                        cttttl.Ky = _hoadon.KY.ToString();
                        cttttl.Nam = _hoadon.NAM.ToString();
                    }
                    cttttl.VeViec = txtVeViec.Text.Trim();
                    cttttl.NoiDung = txtNoiDung.Text;
                    cttttl.NoiNhan = txtNoiNhan.Text.Trim();
                    ///
                    if (chkGiamNuocXaBo.Checked)
                        cttttl.GiamNuocXaBo = true;
                    if (chkKiemDinhDHN_Dung.Checked)
                        cttttl.KiemDinhDHN_Dung = true;
                    if (chkKiemDinhDHN_Sai.Checked)
                        cttttl.KiemDinhDHN_Sai = true;
                    if (chkThayDHN.Checked)
                        cttttl.ThayDHN = true;
                    if (chkDieuChinh_GB_DM.Checked)
                        cttttl.DieuChinh_GB_DM = true;
                    if (chkThuMoi.Checked)
                        cttttl.ThuMoi = true;
                    if (chkThuBao.Checked)
                        cttttl.ThuBao = true;

                    ///Ký Tên
                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                        cttttl.ChucVu = "GIÁM ĐỐC";
                    else
                        cttttl.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                    cttttl.NguoiKy = bangiamdoc.HoTen.ToUpper();
                    cttttl.ThuDuocKy = true;

                    if (_cTTTL.ThemCT(cttttl))
                    {
                        Clear();
                        MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaDon.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (_cttttl != null)
                    {
                        _cttttl.DanhBo = txtDanhBo.Text.Trim();
                        _cttttl.HopDong = txtHopDong.Text.Trim();
                        _cttttl.LoTrinh = txtLoTrinh.Text.Trim();
                        _cttttl.HoTen = txtHoTen.Text.Trim();
                        _cttttl.DiaChi = txtDiaChi.Text.Trim();
                        _cttttl.GiaBieu = txtGiaBieu.Text.Trim();
                        _cttttl.DinhMuc = txtDinhMuc.Text.Trim();
                        if (_hoadon != null)
                        {
                            _cttttl.Dot = _hoadon.DOT.ToString();
                            _cttttl.Ky = _hoadon.KY.ToString();
                            _cttttl.Nam = _hoadon.NAM.ToString();
                        }
                        _cttttl.VeViec = txtVeViec.Text.Trim();
                        _cttttl.NoiDung = txtNoiDung.Text;
                        _cttttl.NoiNhan = txtNoiNhan.Text.Trim();
                        ///
                        if (chkGiamNuocXaBo.Checked)
                            _cttttl.GiamNuocXaBo = true;
                        if (chkKiemDinhDHN_Dung.Checked)
                            _cttttl.KiemDinhDHN_Dung = true;
                        if (chkKiemDinhDHN_Sai.Checked)
                            _cttttl.KiemDinhDHN_Sai = true;
                        if (chkThayDHN.Checked)
                            _cttttl.ThayDHN = true;
                        if (chkDieuChinh_GB_DM.Checked)
                            _cttttl.DieuChinh_GB_DM = true;
                        if (chkThuMoi.Checked)
                            _cttttl.ThuMoi = true;
                        if (chkThuBao.Checked)
                            _cttttl.ThuBao = true;

                        ///Ký Tên
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            _cttttl.ChucVu = "GIÁM ĐỐC";
                        else
                            _cttttl.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        _cttttl.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        _cttttl.ThuDuocKy = true;

                        if (_cTTTL.SuaCT(_cttttl))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMaDon.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (_cttttl != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_cTTTL.XoaCT(_cttttl))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMaDon.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCapNhatGhiChu_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (_cttttl != null)
                    {
                        GhiChuCTTTTL ghichu = new GhiChuCTTTTL();
                        ghichu.NgayGhiChu = dateGhiChu.Value;
                        ghichu.GhiChu = txtGhiChu.Text.Trim();
                        ghichu.MaCTTTTL = _cttttl.MaCTTTTL;
                        if (_cGhiChuCTTTTL.Them(ghichu))
                            dgvGhiChu.DataSource = _cGhiChuCTTTTL.GetDS(_cttttl.MaCTTTTL);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvGhiChu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvGhiChu.CurrentCell = dgvGhiChu.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvGhiChu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && (_dontkh != null))
            {
                contextMenuStrip1.Show(dgvGhiChu, new Point(e.X, e.Y));
            }
        }

        private void dgvLichSuTTTL_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLichSuTTTL.Columns[e.ColumnIndex].Name == "MaCTTTTL" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvLichSuTTTL.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null && e.Value.ToString().Length > 2)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (_cGhiChuCTTTTL.Xoa(_cGhiChuCTTTTL.Get(int.Parse(dgvGhiChu.CurrentRow.Cells["ID"].Value.ToString()))))
                        {
                            dgvGhiChu.DataSource = _cGhiChuCTTTTL.GetDS(_cttttl.MaCTTTTL);
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


    }
}

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
using KTKS_DonKH.DAL.ThuTraLoi;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ThuTraLoi;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.GUI.DonTu;
using System.Transactions;
using KTKS_DonKH.wrThuongVu;

namespace KTKS_DonKH.GUI.ThuTraLoi
{
    public partial class frmTTTL : Form
    {
        string _mnu = "mnuTTTL";
        CDonTu _cDonTu = new CDonTu();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CTTTL _cTTTL = new CTTTL();
        CTTTL_GhiChu _cGhiChuCTTTTL = new CTTTL_GhiChu();
        CThuTien _cThuTien = new CThuTien();
        CDHN _cDHN = new CDHN();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CTTTL_VeViec _cVeViecTTTL = new CTTTL_VeViec();
        wsThuongVu _wsThuongVu = new wsThuongVu();

        DonTu_ChiTiet _dontu_ChiTiet = null;
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        ThuTraLoi_ChiTiet _cttttl = null;
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
            dgvHinh.AutoGenerateColumns = false;

            cmbVeViec.DataSource = _cVeViecTTTL.getDS_ThuTraLoi();
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
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDHN.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
            txtGiaBieu.Text = hoadon.GB.ToString();
            if (hoadon.DM != null)
                txtDinhMuc.Text = hoadon.DM.Value.ToString();
            else
                txtDinhMuc.Text = "";
            if (hoadon.DinhMucHN != null)
                txtDinhMucHN.Text = hoadon.DinhMucHN.Value.ToString();
            else
                txtDinhMucHN.Text = "";

            dgvLichSuTTTL.DataSource = _cTTTL.GetLichSuCTByDanhBo(_hoadon.DANHBA);

            if (_dontu_ChiTiet != null)
                dateNhanDon.Value = _dontu_ChiTiet.CreateDate.Value;
            else
                if (_dontkh != null)
                    dateNhanDon.Value = _dontkh.CreateDate.Value;
                else
                    if (_dontxl != null)
                        dateNhanDon.Value = _dontxl.CreateDate.Value;
                    else
                        if (_dontbc != null)
                            dateNhanDon.Value = _dontbc.CreateDate.Value;
            if (_cDHN.CheckExist(hoadon.DANHBA) == false)
                MessageBox.Show("Danh Bộ Hủy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void LoadTTTL(ThuTraLoi_ChiTiet cttttl)
        {
            if (cttttl.ThuTraLoi.MaDonMoi != null)
            {
                _dontu_ChiTiet = _cDonTu.get_ChiTiet(cttttl.ThuTraLoi.MaDonMoi.Value, cttttl.STT.Value);
                if (_dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count == 1)
                    txtMaDonMoi.Text = cttttl.ThuTraLoi.MaDonMoi.ToString();
                else
                    txtMaDonMoi.Text = cttttl.ThuTraLoi.MaDonMoi.Value.ToString() + "." + cttttl.STT.Value.ToString();
            }
            else
                if (cttttl.ThuTraLoi.MaDon != null)
                {
                    _dontkh = _cDonKH.Get(cttttl.ThuTraLoi.MaDon.Value);
                    txtMaDonCu.Text = cttttl.ThuTraLoi.MaDon.Value.ToString().Insert(cttttl.ThuTraLoi.MaDon.Value.ToString().Length - 2, "-");
                }
                else
                    if (cttttl.ThuTraLoi.MaDonTXL != null)
                    {
                        _dontxl = _cDonTXL.Get(cttttl.ThuTraLoi.MaDonTXL.Value);
                        txtMaDonCu.Text = "TXL" + cttttl.ThuTraLoi.MaDonTXL.Value.ToString().Insert(cttttl.ThuTraLoi.MaDonTXL.Value.ToString().Length - 2, "-");
                    }
                    else
                        if (cttttl.ThuTraLoi.MaDonTBC != null)
                        {
                            _dontbc = _cDonTBC.Get(cttttl.ThuTraLoi.MaDonTBC.Value);
                            txtMaDonCu.Text = "TBC" + cttttl.ThuTraLoi.MaDonTBC.Value.ToString().Insert(cttttl.ThuTraLoi.MaDonTBC.Value.ToString().Length - 2, "-");
                        }
            txtMaCTTTTL.Text = cttttl.MaCTTTTL.ToString().Insert(cttttl.MaCTTTTL.ToString().Length - 2, "-");
            txtTCHC.Text = cttttl.TCHC;
            chkDuocKy.Checked = cttttl.ThuDuocKy;
            txtDanhBo.Text = cttttl.DanhBo;
            txtHopDong.Text = cttttl.HopDong;
            txtLoTrinh.Text = cttttl.LoTrinh;
            txtHoTen.Text = cttttl.HoTen;
            txtDiaChi.Text = cttttl.DiaChi;
            txtGiaBieu.Text = cttttl.GiaBieu.Value.ToString();
            if (cttttl.DinhMuc != null)
                txtDinhMuc.Text = cttttl.DinhMuc.Value.ToString();
            if (cttttl.DinhMucHN != null)
                txtDinhMucHN.Text = cttttl.DinhMucHN.Value.ToString();
            if (cttttl.NgayTiepNhan != null)
                dateNhanDon.Value = cttttl.NgayTiepNhan.Value;
            else
            {
                if (cttttl.ThuTraLoi.MaDonMoi != null)
                    dateNhanDon.Value = cttttl.ThuTraLoi.DonTu.CreateDate.Value;
                else
                    if (cttttl.ThuTraLoi.MaDon != null)
                        dateNhanDon.Value = cttttl.ThuTraLoi.DonKH.CreateDate.Value;
                    else
                        if (cttttl.ThuTraLoi.MaDonTXL != null)
                            dateNhanDon.Value = cttttl.ThuTraLoi.DonTXL.CreateDate.Value;
                        else
                            if (cttttl.ThuTraLoi.MaDonTBC != null)
                                dateNhanDon.Value = cttttl.ThuTraLoi.DonTBC.CreateDate.Value;
            }
            txtVeViec.Text = cttttl.VeViec;
            txtNoiDung.Text = cttttl.NoiDung;
            txtNoiNhan.Text = cttttl.NoiNhan;
            txtNguoiBao.Text = cttttl.NguoiBao;
            txtDienThoai.Text = cttttl.DienThoai;

            dgvLichSuTTTL.DataSource = _cTTTL.GetLichSuCTByDanhBo(cttttl.DanhBo);
            dgvGhiChu.DataSource = _cGhiChuCTTTTL.GetDS(cttttl.MaCTTTTL);

            dgvHinh.Rows.Clear();
            foreach (ThuTraLoi_ChiTiet_Hinh item in cttttl.ThuTraLoi_ChiTiet_Hinhs.ToList())
            {
                var index = dgvHinh.Rows.Add();
                dgvHinh.Rows[index].Cells["ID_Hinh"].Value = item.ID;
                dgvHinh.Rows[index].Cells["Name_Hinh"].Value = item.Name;
                if (item.Hinh != null)
                    dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(item.Hinh.ToArray());
                dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = item.Loai;
                dgvHinh.Rows[index].Cells["Huy"].Value = item.Huy;
            }
        }

        public void Clear()
        {
            chkDuocKy.Checked = false;
            txtMaDonCu.Text = "";
            txtMaCTTTTL.Text = "";
            txtTCHC.Text = "";
            ///
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDinhMucHN.Text = "";
            ///
            txtVeViec.Text = "";
            txtNoiDung.Text = "";
            txtNoiNhan.Text = "";
            txtNguoiBao.Text = "";
            txtDienThoai.Text = "";

            _dontu_ChiTiet = null;
            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            _cttttl = null;
            _MaCTTTTL = -1;

            dgvHinh.Rows.Clear();

            txtMaDonMoi.Focus();
        }

        private void txtMaDonCu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDonCu.Text.Trim() != "")
            {
                string MaDon = txtMaDonCu.Text.Trim();
                Clear();
                txtMaDonCu.Text = MaDon;
                ///Đơn Tổ Xử Lý
                if (txtMaDonCu.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_cDonTXL.CheckExist(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", ""))) == true)
                    {
                        _dontxl = _cDonTXL.Get(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDonCu.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");

                        if (_cThuTien.GetMoiNhat(_dontxl.DanhBo) != null)
                        {
                            _hoadon = _cThuTien.GetMoiNhat(_dontxl.DanhBo);
                            LoadTTKH(_hoadon);
                        }
                        else
                        {
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            txtDanhBo.Text = _dontxl.DanhBo;
                            txtHopDong.Text = _dontxl.HopDong;
                            txtLoTrinh.Text = _dontxl.MLT;
                            txtHoTen.Text = _dontxl.HoTen;
                            txtDiaChi.Text = _dontxl.DiaChi;
                            txtGiaBieu.Text = _dontxl.GiaBieu.Value.ToString();
                            txtDinhMuc.Text = _dontxl.DinhMuc.Value.ToString();
                        }
                    }
                    else
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    if (txtMaDonCu.Text.Trim().ToUpper().Contains("TBC"))
                    {
                        if (_cDonTBC.CheckExist(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", ""))) == true)
                        {
                            _dontbc = _cDonTBC.Get(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                            txtMaDonCu.Text = "TBC" + _dontbc.MaDon.ToString().Insert(_dontbc.MaDon.ToString().Length - 2, "-");

                            if (_cThuTien.GetMoiNhat(_dontbc.DanhBo) != null)
                            {
                                _hoadon = _cThuTien.GetMoiNhat(_dontbc.DanhBo);
                                LoadTTKH(_hoadon);
                            }
                            else
                            {
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                txtDanhBo.Text = _dontbc.DanhBo;
                                txtHopDong.Text = _dontbc.HopDong;
                                txtLoTrinh.Text = _dontbc.MLT;
                                txtHoTen.Text = _dontbc.HoTen;
                                txtDiaChi.Text = _dontbc.DiaChi;
                                txtGiaBieu.Text = _dontbc.GiaBieu.Value.ToString();
                                txtDinhMuc.Text = _dontbc.DinhMuc.Value.ToString();
                            }
                        }
                        else
                            MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ///Đơn Tổ Khách Hàng
                    else
                        if (_cDonKH.CheckExist(decimal.Parse(txtMaDonCu.Text.Trim().Replace("-", ""))) == true)
                        {
                            _dontkh = _cDonKH.Get(decimal.Parse(txtMaDonCu.Text.Trim().Replace("-", "")));
                            txtMaDonCu.Text = _dontkh.MaDon.ToString().Insert(_dontkh.MaDon.ToString().Length - 2, "-");

                            if (_cThuTien.GetMoiNhat(_dontkh.DanhBo) != null)
                            {
                                _hoadon = _cThuTien.GetMoiNhat(_dontkh.DanhBo);
                                LoadTTKH(_hoadon);
                            }
                            else
                            {
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                txtDanhBo.Text = _dontkh.DanhBo;
                                txtHopDong.Text = _dontkh.HopDong;
                                txtLoTrinh.Text = _dontkh.MLT;
                                txtHoTen.Text = _dontkh.HoTen;
                                txtDiaChi.Text = _dontkh.DiaChi;
                                txtGiaBieu.Text = _dontkh.GiaBieu.Value.ToString();
                                txtDinhMuc.Text = _dontkh.DinhMuc.Value.ToString();
                            }
                        }
                        else
                            MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaDonMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDonMoi.Text.Trim() != "")
            {
                string MaDon = txtMaDonMoi.Text.Trim();
                Clear();
                if (MaDon.Contains(".") == true)
                {
                    string[] MaDons = MaDon.Split('.');
                    _dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(MaDons[0]), int.Parse(MaDons[1]));
                }
                else
                {
                    LinQ.DonTu dt = _cDonTu.get(int.Parse(MaDon));
                    if (dt != null)
                        _dontu_ChiTiet = dt.DonTu_ChiTiets.SingleOrDefault();
                }
                //
                if (_dontu_ChiTiet != null)
                {
                    if (_dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count() == 1)
                        txtMaDonMoi.Text = _dontu_ChiTiet.MaDon.Value.ToString();
                    else
                        txtMaDonMoi.Text = _dontu_ChiTiet.MaDon.Value.ToString() + "." + _dontu_ChiTiet.STT.Value.ToString();

                    _hoadon = _cThuTien.GetMoiNhat(_dontu_ChiTiet.DanhBo);
                    if (_hoadon != null)
                    {
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
                _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                if (_hoadon != null)
                {
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
            if (e.KeyChar == 13 && _cTTTL.CheckExist_CT(decimal.Parse(txtMaCTTTTL.Text.Trim().Replace("-", ""))) == true)
            {
                string MaDon = txtMaCTTTTL.Text.Trim();
                Clear();
                txtMaCTTTTL.Text = MaDon;
                _cttttl = _cTTTL.GetCT(decimal.Parse(txtMaCTTTTL.Text.Trim().Replace("-", "")));
                if (_cttttl != null)
                    LoadTTTL(_cttttl);
                else
                    MessageBox.Show("Mã này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbVeViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVeViec.SelectedIndex != -1)
            {
                ThuTraLoi_VeViec vv = (ThuTraLoi_VeViec)cmbVeViec.SelectedItem;
                txtVeViec.Text = vv.TenVV;
                txtNoiDung.Text = vv.NoiDung;
                if (txtMaDonMoi.Text.Trim() != "")
                    txtNoiNhan.Text = vv.NoiNhan + " (" + txtMaDonMoi.Text.Trim() + ")";
                else
                    if (txtMaDonCu.Text.Trim() != "")
                        txtNoiNhan.Text = vv.NoiNhan + " (" + txtMaDonCu.Text.Trim() + ")";
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
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    if (txtVeViec.Text.Trim() == "" || txtNoiDung.Text.Trim() == "" || txtNoiNhan.Text.Trim() == "")
                    {
                        MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    ThuTraLoi_ChiTiet cttttl = new ThuTraLoi_ChiTiet();

                    if (_dontu_ChiTiet != null)
                    {
                        if (_cTTTL.checkExist(_dontu_ChiTiet.MaDon.Value) == false)
                        {
                            LinQ.ThuTraLoi tttl = new LinQ.ThuTraLoi();
                            tttl.MaDonMoi = _dontu_ChiTiet.MaDon.Value;
                            _cTTTL.Them(tttl);
                        }
                        if (_cTTTL.checkExist_ChiTiet(_dontu_ChiTiet.MaDon.Value, txtDanhBo.Text.Trim(), DateTime.Now) == true)
                        {
                            if (MessageBox.Show("Danh Bộ này đã được Lập Thư\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                return;
                        }
                        cttttl.MaTTTL = _cTTTL.get(_dontu_ChiTiet.MaDon.Value).MaTTTL;
                        cttttl.STT = _dontu_ChiTiet.STT.Value;
                    }
                    else
                        if (_dontkh != null)
                        {
                            if (_cTTTL.CheckExist("TKH", _dontkh.MaDon) == false)
                            {
                                LinQ.ThuTraLoi tttl = new LinQ.ThuTraLoi();
                                tttl.MaDon = _dontkh.MaDon;
                                _cTTTL.Them(tttl);
                            }
                            if (_cTTTL.CheckExist_CT("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim(), DateTime.Now) == true)
                            {
                                if (MessageBox.Show("Danh Bộ này đã được Lập Thư\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    return;
                            }
                            cttttl.MaTTTL = _cTTTL.Get("TKH", _dontkh.MaDon).MaTTTL;
                        }
                        else
                            if (_dontxl != null)
                            {
                                if (_cTTTL.CheckExist("TXL", _dontxl.MaDon) == false)
                                {
                                    LinQ.ThuTraLoi tttl = new LinQ.ThuTraLoi();
                                    tttl.MaDonTXL = _dontxl.MaDon;
                                    _cTTTL.Them(tttl);
                                }
                                if (_cTTTL.CheckExist_CT("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim(), DateTime.Now) == true)
                                {
                                    if (MessageBox.Show("Danh Bộ này đã được Lập Thư\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                        return;
                                }
                                cttttl.MaTTTL = _cTTTL.Get("TXL", _dontxl.MaDon).MaTTTL;
                            }
                            else
                                if (_dontbc != null)
                                {
                                    if (_cTTTL.CheckExist("TBC", _dontbc.MaDon) == false)
                                    {
                                        LinQ.ThuTraLoi tttl = new LinQ.ThuTraLoi();
                                        tttl.MaDonTBC = _dontbc.MaDon;
                                        _cTTTL.Them(tttl);
                                    }
                                    if (_cTTTL.CheckExist_CT("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim(), DateTime.Now) == true)
                                    {
                                        if (MessageBox.Show("Danh Bộ này đã được Lập Thư\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                            return;
                                    }
                                    cttttl.MaTTTL = _cTTTL.Get("TBC", _dontbc.MaDon).MaTTTL;
                                }
                                else
                                {
                                    MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                    cttttl.ThuDuocKy = chkDuocKy.Checked;
                    cttttl.DanhBo = txtDanhBo.Text.Trim();
                    cttttl.HopDong = txtHopDong.Text.Trim();
                    cttttl.LoTrinh = txtLoTrinh.Text.Trim();
                    cttttl.HoTen = txtHoTen.Text.Trim();
                    cttttl.DiaChi = txtDiaChi.Text.Trim();
                    if (string.IsNullOrEmpty(txtGiaBieu.Text.Trim()) == false)
                        cttttl.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                    if (string.IsNullOrEmpty(txtDinhMuc.Text.Trim()) == false)
                        cttttl.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                    if (string.IsNullOrEmpty(txtDinhMucHN.Text.Trim()) == false)
                        cttttl.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                    if (_hoadon != null)
                    {
                        cttttl.Dot = _hoadon.DOT;
                        cttttl.Ky = _hoadon.KY;
                        cttttl.Nam = _hoadon.NAM;
                        cttttl.Phuong = _hoadon.Phuong;
                        cttttl.Quan = _hoadon.Quan;
                    }
                    cttttl.NgayTiepNhan = dateNhanDon.Value;
                    cttttl.VeViec = txtVeViec.Text.Trim();
                    cttttl.NoiDung = txtNoiDung.Text;
                    cttttl.NoiNhan = txtNoiNhan.Text.Trim();
                    cttttl.NguoiBao = txtNguoiBao.Text.Trim();
                    cttttl.DienThoai = txtDienThoai.Text.Trim();

                    ///Ký Tên
                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                        cttttl.ChucVu = "GIÁM ĐỐC";
                    else
                        cttttl.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                    cttttl.NguoiKy = bangiamdoc.HoTen.ToUpper();

                    using (TransactionScope scope = new TransactionScope())
                        if (_cTTTL.ThemCT(cttttl))
                        {
                            foreach (DataGridViewRow item in dgvHinh.Rows)
                            {
                                ThuTraLoi_ChiTiet_Hinh en = new ThuTraLoi_ChiTiet_Hinh();
                                en.IDTTTL_ChiTiet = cttttl.MaCTTTTL;
                                en.Name = item.Cells["Name_Hinh"].Value.ToString();
                                //en.Hinh = Convert.FromBase64String(item.Cells["Bytes_Hinh"].Value.ToString());
                                en.Loai = item.Cells["Loai_Hinh"].Value.ToString();
                                if (_wsThuongVu.ghi_Hinh("ThuTraLoi_ChiTiet_Hinh", en.IDTTTL_ChiTiet.Value.ToString(), en.Name + en.Loai, Convert.FromBase64String(item.Cells["Bytes_Hinh"].Value.ToString())) == true)
                                    _cTTTL.Them_Hinh(en);
                            }
                            if (_dontu_ChiTiet != null)
                            {
                                if (_cDonTu.Them_LichSu(cttttl.CreateDate.Value, "TTTL", "Đã Lập Thư Trả Lời, " + cttttl.VeViec, (int)cttttl.MaCTTTTL, _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value) == true)
                                    scope.Complete();
                            }
                            else
                                scope.Complete();
                            MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (_cttttl != null)
                    {
                        _cttttl.ThuDuocKy = chkDuocKy.Checked;
                        _cttttl.TCHC = txtTCHC.Text.Trim();
                        _cttttl.DanhBo = txtDanhBo.Text.Trim();
                        _cttttl.HopDong = txtHopDong.Text.Trim();
                        _cttttl.LoTrinh = txtLoTrinh.Text.Trim();
                        _cttttl.HoTen = txtHoTen.Text.Trim();
                        _cttttl.DiaChi = txtDiaChi.Text.Trim();
                        _cttttl.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if (string.IsNullOrEmpty(txtGiaBieu.Text.Trim()) == false)
                            _cttttl.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        else
                            _cttttl.GiaBieu = null;
                        if (string.IsNullOrEmpty(txtDinhMuc.Text.Trim()) == false)
                            _cttttl.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        else
                            _cttttl.DinhMuc = null;
                        if (string.IsNullOrEmpty(txtDinhMucHN.Text.Trim()) == false)
                            _cttttl.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                        else
                            _cttttl.DinhMucHN = null;
                        if (_hoadon != null)
                        {
                            _cttttl.Dot = _hoadon.DOT;
                            _cttttl.Ky = _hoadon.KY;
                            _cttttl.Nam = _hoadon.NAM;
                            _cttttl.Phuong = _hoadon.Phuong;
                            _cttttl.Quan = _hoadon.Quan;
                        }
                        _cttttl.NgayTiepNhan = dateNhanDon.Value;
                        _cttttl.VeViec = txtVeViec.Text.Trim();
                        _cttttl.NoiDung = txtNoiDung.Text;
                        _cttttl.NoiNhan = txtNoiNhan.Text.Trim();
                        _cttttl.NguoiBao = txtNguoiBao.Text.Trim();
                        _cttttl.DienThoai = txtDienThoai.Text.Trim();

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
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_cttttl != null && MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        string flagID = _cttttl.MaCTTTTL.ToString();
                        var transactionOptions = new TransactionOptions();
                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                        {
                            DonTu_LichSu dtls = _cDonTu.get_LichSu("TTTL_ChiTiet", (int)_cttttl.MaCTTTTL,_cttttl.CreateBy.Value);
                            if (dtls != null)
                            {
                                _cDonTu.Xoa_LichSu(dtls, true);
                            }
                            if (_cTTTL.XoaCT(_cttttl))
                            {
                                _wsThuongVu.xoa_Folder_Hinh("TTTL_ChiTiet_Hinh", flagID);
                                scope.Complete();
                                scope.Dispose();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhatGhiChu_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (_cttttl != null && _dontu_ChiTiet == null)
                    {
                        ThuTraLoi_GhiChu ghichu = new ThuTraLoi_GhiChu();
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
            //if (dgvLichSuTTTL.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null && e.Value.ToString().Length > 2)
            //{
            //    e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            //}
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (_cGhiChuCTTTTL.Xoa(_cGhiChuCTTTTL.Get(int.Parse(dgvGhiChu.CurrentRow.Cells["ID"].Value.ToString()))))
                        {
                            dgvGhiChu.DataSource = _cGhiChuCTTTTL.GetDS(_cttttl.MaCTTTTL);
                        }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_cttttl != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                //dr["SoPhieu"] = _cttttl.MaCTTTTL.ToString().Insert(_cttttl.MaCTTTTL.ToString().Length - 2, "-");
                dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;
                dr["LoTrinh"] = _cttttl.LoTrinh;
                dr["HoTen"] = _cttttl.HoTen;
                dr["DiaChi"] = _cttttl.DiaChi;
                if (!string.IsNullOrEmpty(_cttttl.DanhBo) && _cttttl.DanhBo.Length == 11)
                    dr["DanhBo"] = _cttttl.DanhBo.Insert(7, " ").Insert(4, " ");

                dr["HopDong"] = _cttttl.HopDong;
                dr["GiaBieu"] = _cttttl.GiaBieu;
                if (_cttttl.DinhMuc != null)
                    dr["DinhMuc"] = _cttttl.DinhMuc;
                if (_cttttl.DinhMucHN != null)
                    dr["DinhMucHN"] = _cttttl.DinhMucHN;
                //if (_cttttl.ThuTraLoi.MaDonMoi != null)
                //    dr["NgayNhanDon"] = _cDonTu.get(_cttttl.ThuTraLoi.MaDonMoi.Value).CreateDate.Value.ToString("dd/MM/yyyy");
                //else
                //    if (_cttttl.ThuTraLoi.MaDon != null)
                //        dr["NgayNhanDon"] = _cttttl.ThuTraLoi.DonKH.CreateDate.Value.ToString("dd/MM/yyyy");
                //    else
                //        if (_cttttl.ThuTraLoi.MaDonTXL != null)
                //            dr["NgayNhanDon"] = _cttttl.ThuTraLoi.DonTXL.CreateDate.Value.ToString("dd/MM/yyyy");
                //        else
                //            if (_cttttl.ThuTraLoi.MaDonTBC != null)
                //                dr["NgayNhanDon"] = _cttttl.ThuTraLoi.DonTBC.CreateDate.Value.ToString("dd/MM/yyyy");
                dr["NgayNhanDon"] = _cttttl.NgayTiepNhan.Value.ToString("dd/MM/yyyy");

                dr["VeViec"] = _cttttl.VeViec;
                dr["NoiDung"] = _cttttl.NoiDung;
                dr["NoiNhan"] = _cttttl.NoiNhan + "\r\nTTL" + _cttttl.MaCTTTTL.ToString().Insert(_cttttl.MaCTTTTL.ToString().Length - 2, "-");
                dr["ChucVu"] = _cttttl.ChucVu;
                dr["NguoiKy"] = _cttttl.NguoiKy;

                dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(drLogo);

                if (!string.IsNullOrEmpty(_cttttl.DanhBo))
                {
                    rptThaoThuTraLoi rpt = new rptThaoThuTraLoi();
                    rpt.SetDataSource(dsBaoCao);
                    rpt.Subreports[0].SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.Show();
                }
                else
                {
                    rptThaoThuTraLoi_KhongDanhBo rpt = new rptThaoThuTraLoi_KhongDanhBo();
                    rpt.SetDataSource(dsBaoCao);
                    rpt.Subreports[0].SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.Show();
                }
            }
        }

        //add file
        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png|PDF files (*.pdf) | *.pdf";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] bytes;
                    if (dialog.FileName.ToLower().Contains("pdf"))
                        bytes = _cTTTL.scanFile(dialog.FileName);
                    else
                        bytes = _cTTTL.scanImage(dialog.FileName);
                    if (_cttttl == null)
                    {
                        var index = dgvHinh.Rows.Add();
                        dgvHinh.Rows[index].Cells["Name_Hinh"].Value = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                        dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(bytes);
                        dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = System.IO.Path.GetExtension(dialog.FileName);
                    }
                    else
                    {
                        if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                        {
                            ThuTraLoi_ChiTiet_Hinh en = new ThuTraLoi_ChiTiet_Hinh();
                            en.IDTTTL_ChiTiet = _cttttl.MaCTTTTL;
                            en.Name = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                            en.Loai = System.IO.Path.GetExtension(dialog.FileName);
                            if (_wsThuongVu.ghi_Hinh("ThuTraLoi_ChiTiet_Hinh", en.IDTTTL_ChiTiet.Value.ToString(), en.Name + en.Loai, bytes) == true)
                                if (_cTTTL.Them_Hinh(en) == true)
                                {
                                    _cTTTL.Refresh();
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    var index = dgvHinh.Rows.Add();
                                    dgvHinh.Rows[index].Cells["Name_Hinh"].Value = en.Name;
                                    dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(bytes);
                                    dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = System.IO.Path.GetExtension(dialog.FileName);
                                }
                        }
                        else
                            MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvHinh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                dgvHinh.CurrentCell = dgvHinh.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvHinh_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Show(dgvHinh, new Point(e.X, e.Y));
            }
        }

        private void dgvHinh_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            byte[] file = _wsThuongVu.get_Hinh("ThuTraLoi_ChiTiet_Hinh", _cttttl.MaCTTTTL.ToString(), dgvHinh.CurrentRow.Cells["Name_Hinh"].Value.ToString() + dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString());
            if (file != null)
                if (dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString().ToLower().Contains("pdf"))
                    _cTTTL.viewPDF(1,file);
                else
                    _cTTTL.viewImage(file);
            else
                MessageBox.Show("File không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void xoaFile_dgvHinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (_cttttl == null)
                    dgvHinh.Rows.RemoveAt(dgvHinh.CurrentRow.Index);
                else
                    if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                    {
                        if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (dgvHinh.CurrentRow.Cells["ID_Hinh"].Value != null)
                                if (_wsThuongVu.xoa_Hinh("ThuTraLoi_ChiTiet_Hinh", _cttttl.MaCTTTTL.ToString(), dgvHinh.CurrentRow.Cells["Name_Hinh"].Value.ToString() + dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString()) == true)
                                    if (_cTTTL.Xoa_Hinh(_cTTTL.get_Hinh(int.Parse(dgvHinh.CurrentRow.Cells["ID_Hinh"].Value.ToString()))))
                                    {
                                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        dgvHinh.Rows.RemoveAt(dgvHinh.CurrentRow.Index);
                                    }
                                    else
                                        MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInhotline_Click(object sender, EventArgs e)
        {
            if (_cttttl != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                //dr["SoPhieu"] = _cttttl.MaCTTTTL.ToString().Insert(_cttttl.MaCTTTTL.ToString().Length - 2, "-");
                dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;
                dr["LoTrinh"] = _cttttl.LoTrinh;
                dr["HoTen"] = _cttttl.HoTen;
                dr["DiaChi"] = _cttttl.DiaChi;
                if (!string.IsNullOrEmpty(_cttttl.DanhBo) && _cttttl.DanhBo.Length == 11)
                    dr["DanhBo"] = _cttttl.DanhBo.Insert(7, " ").Insert(4, " ");

                dr["HopDong"] = _cttttl.HopDong;
                dr["GiaBieu"] = _cttttl.GiaBieu;
                if (_cttttl.DinhMuc != null)
                    dr["DinhMuc"] = _cttttl.DinhMuc;
                if (_cttttl.DinhMucHN != null)
                    dr["DinhMucHN"] = _cttttl.DinhMucHN;
                //if (_cttttl.ThuTraLoi.MaDonMoi != null)
                //    dr["NgayNhanDon"] = _cDonTu.get(_cttttl.ThuTraLoi.MaDonMoi.Value).CreateDate.Value.ToString("dd/MM/yyyy");
                //else
                //    if (_cttttl.ThuTraLoi.MaDon != null)
                //        dr["NgayNhanDon"] = _cttttl.ThuTraLoi.DonKH.CreateDate.Value.ToString("dd/MM/yyyy");
                //    else
                //        if (_cttttl.ThuTraLoi.MaDonTXL != null)
                //            dr["NgayNhanDon"] = _cttttl.ThuTraLoi.DonTXL.CreateDate.Value.ToString("dd/MM/yyyy");
                //        else
                //            if (_cttttl.ThuTraLoi.MaDonTBC != null)
                //                dr["NgayNhanDon"] = _cttttl.ThuTraLoi.DonTBC.CreateDate.Value.ToString("dd/MM/yyyy");
                dr["NgayNhanDon"] = _cttttl.NgayTiepNhan.Value.ToString("dd/MM/yyyy");

                dr["VeViec"] = _cttttl.VeViec;
                dr["NoiDung"] = _cttttl.NoiDung;
                dr["NoiNhan"] = _cttttl.NoiNhan + "\r\nTTL" + _cttttl.MaCTTTTL.ToString().Insert(_cttttl.MaCTTTTL.ToString().Length - 2, "-");
                dr["ChucVu"] = _cttttl.ChucVu;
                dr["NguoiKy"] = _cttttl.NguoiKy;

                dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(drLogo);

                rptThaoThuTraLoi_hotline rpt = new rptThaoThuTraLoi_hotline();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }
        }

        private void frmTTTL_KeyDown(object sender, KeyEventArgs e)
        {
            if (_dontu_ChiTiet != null && e.Control && e.KeyCode == Keys.T)
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    frmCapNhatDonTu_Thumbnail frm = new frmCapNhatDonTu_Thumbnail(_dontu_ChiTiet, "ThuTraLoi_ChiTiet", (int)_cttttl.MaCTTTTL);
                    frm.ShowDialog();
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHinh_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_cttttl != null)
                {
                    if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                    {
                        if (dgvHinh.Columns[e.ColumnIndex].Name == "Huy")
                        {
                            ThuTraLoi_ChiTiet_Hinh en = _cTTTL.get_Hinh(int.Parse(dgvHinh.CurrentRow.Cells["ID_Hinh"].Value.ToString()));
                            en.Huy = bool.Parse(dgvHinh.Rows[e.RowIndex].Cells["Huy"].Value.ToString());
                            _cTTTL.SubmitChanges();
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

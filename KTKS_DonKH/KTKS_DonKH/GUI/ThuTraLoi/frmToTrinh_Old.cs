using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.ThuTraLoi;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ThuTraLoi;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.GUI.DonTu;
using System.Transactions;
using CrystalDecisions.CrystalReports.Engine;

namespace KTKS_DonKH.GUI.ThuTraLoi
{
    public partial class frmToTrinh_Old : Form
    {
        string _mnu = "mnuToTrinh";
        CDonTu _cDonTu = new CDonTu();
        CThuTien _cThuTien = new CThuTien();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CToTrinh _cTT = new CToTrinh();
        CDHN _cDocSo = new CDHN();
        CToTrinh_VeViec _cVeViecToTrinh = new CToTrinh_VeViec();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();

        DonTu_ChiTiet _dontu_ChiTiet = null;
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        ToTrinh_ChiTiet _cttt = null;
        int _IDCT = -1;

        public frmToTrinh_Old()
        {
            InitializeComponent();
        }

        public frmToTrinh_Old(int IDCT)
        {
            _IDCT = IDCT;
            InitializeComponent();
        }

        private void frmToTrinh_Load(object sender, EventArgs e)
        {
            dgvToTrinh.AutoGenerateColumns = false;
            dgvHinh.AutoGenerateColumns = false;
            cmbTimTheo.SelectedIndex = 3;

            cmbVeViec.DataSource = _cVeViecToTrinh.GetDS();
            cmbVeViec.DisplayMember = "Name";
            cmbVeViec.SelectedIndex = -1;

            if (_IDCT != -1)
            {
                txtMaCTTT.Text = _IDCT.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtMaCTTT_KeyPress(sender, arg);
            }
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtMLT.Text = hoadon.MALOTRINH;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
            txtGiaBieu.Text = hoadon.GB.ToString();
            if (hoadon.DM != null)
                txtDinhMuc.Text = hoadon.DM.Value.ToString();
            else
                txtDinhMuc.Text = "";
            if (hoadon.DinhMucHN != null)
                txtDinhMucHN.Text = hoadon.DinhMucHN.Value.ToString();
            else
                txtDinhMucHN.Text = "";
        }

        public void LoadTT(ToTrinh_ChiTiet en)
        {
            if (en.ToTrinh.MaDonMoi != null)
            {
                _dontu_ChiTiet = _cDonTu.get_ChiTiet(en.ToTrinh.MaDonMoi.Value, en.STT.Value);
                if (_dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count == 1)
                    txtMaDonMoi.Text = en.ToTrinh.MaDonMoi.ToString();
                else
                    txtMaDonMoi.Text = en.ToTrinh.MaDonMoi.Value.ToString() + "." + en.STT.Value.ToString();
            }
            else
                if (en.ToTrinh.MaDon != null)
                {
                    _dontkh = _cDonKH.Get(en.ToTrinh.MaDon.Value);
                    txtMaDonCu.Text = en.ToTrinh.MaDon.Value.ToString().Insert(en.ToTrinh.MaDon.Value.ToString().Length - 2, "-");
                }
                else
                    if (en.ToTrinh.MaDonTXL != null)
                    {
                        _dontxl = _cDonTXL.Get(en.ToTrinh.MaDonTXL.Value);
                        txtMaDonCu.Text = "TXL" + en.ToTrinh.MaDonTXL.Value.ToString().Insert(en.ToTrinh.MaDonTXL.Value.ToString().Length - 2, "-");
                    }
                    else
                        if (en.ToTrinh.MaDonTBC != null)
                        {
                            _dontbc = _cDonTBC.Get(en.ToTrinh.MaDonTBC.Value);
                            txtMaDonCu.Text = "TBC" + en.ToTrinh.MaDonTBC.Value.ToString().Insert(en.ToTrinh.MaDonTBC.Value.ToString().Length - 2, "-");
                        }

            txtMaCTTT.Text = en.IDCT.ToString().Insert(en.IDCT.ToString().Length - 2, "-");
            txtDanhBo.Text = en.DanhBo;
            txtMLT.Text = en.LoTrinh;
            txtHoTen.Text = en.HoTen;
            txtDiaChi.Text = en.DiaChi;
            txtGiaBieu.Text = en.GiaBieu.Value.ToString();
            if (en.DinhMuc != null)
                txtDinhMuc.Text = en.DinhMuc.Value.ToString();
            if (en.DinhMucHN != null)
                txtDinhMucHN.Text = en.DinhMucHN.Value.ToString();
            txtVeViec.Text = en.VeViec;
            txtKinhTrinh.Text = en.KinhTrinh;
            txtNoiDung.Text = en.NoiDung;
            txtNoiNhan.Text = en.NoiNhan;

            dgvHinh.Rows.Clear();
            foreach (ToTrinh_ChiTiet_Hinh item in en.ToTrinh_ChiTiet_Hinhs.ToList())
            {
                var index = dgvHinh.Rows.Add();
                dgvHinh.Rows[index].Cells["ID_Hinh"].Value = item.ID;
                dgvHinh.Rows[index].Cells["Name_Hinh"].Value = item.Name;
                dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(item.Hinh.ToArray());
            }

        }

        public void Clear()
        {
            txtMaDonCu.Text = "";
            txtMaCTTT.Text = "";
            ///
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDinhMucHN.Text = "";
            ///
            txtVeViec.Text = "";
            txtKinhTrinh.Text = "";
            txtNoiDung.Text = "";
            txtNoiNhan.Text = "";
            ///
            _dontu_ChiTiet = null;
            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            _cttt = null;

            dgvHinh.Rows.Clear();

            txtMaDonCu.Focus();
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
                            txtHoTen.Text = _dontxl.HoTen;
                            txtDiaChi.Text = _dontxl.DiaChi;
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
                                txtHoTen.Text = _dontbc.HoTen;
                                txtDiaChi.Text = _dontbc.DiaChi;
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
                                txtHoTen.Text = _dontkh.HoTen;
                                txtDiaChi.Text = _dontkh.DiaChi;
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

        private void txtMaCTTT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && _cTT.checkExist_ChiTiet(int.Parse(txtMaCTTT.Text.Trim().Replace("-", ""))) == true)
            {
                string MaDon = txtMaCTTT.Text.Trim();
                Clear();
                txtMaCTTT.Text = MaDon;
                _cttt = _cTT.get_ChiTiet(int.Parse(txtMaCTTT.Text.Trim().Replace("-", "")));
                if (_cttt != null)
                    LoadTT(_cttt);
                else
                    MessageBox.Show("Mã này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDanhBo.Text.Trim() != "" && e.KeyChar == 13)
            {
                _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                if (_hoadon != null)
                {
                    LoadTTKH(_hoadon);
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    ToTrinh_ChiTiet cttt = new ToTrinh_ChiTiet();

                    if (_dontu_ChiTiet != null)
                    {
                        if (_cTT.checkExist(_dontu_ChiTiet.MaDon.Value) == false)
                        {
                            ToTrinh tt = new ToTrinh();
                            tt.MaDonMoi = _dontu_ChiTiet.MaDon.Value;
                            _cTT.Them(tt);
                        }
                        if (_cTT.checkExist_ChiTiet(_dontu_ChiTiet.MaDon.Value, txtDanhBo.Text.Trim(), DateTime.Now) == true)
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                        cttt.ID = _cTT.get(_dontu_ChiTiet.MaDon.Value).ID;
                        cttt.STT = _dontu_ChiTiet.STT.Value;
                    }
                    else
                        if (_dontkh != null)
                        {
                            if (_cTT.CheckExist("TKH", _dontkh.MaDon) == false)
                            {
                                ToTrinh tt = new ToTrinh();
                                tt.MaDon = _dontkh.MaDon;
                                _cTT.Them(tt);
                            }
                            if (_cTT.checkExist_ChiTiet("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim(), DateTime.Now) == true)
                            {
                                MessageBox.Show("Danh Bộ này đã được Lập Thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //return;
                            }
                            cttt.ID = _cTT.Get("TKH", _dontkh.MaDon).ID;
                        }
                        else
                            if (_dontxl != null)
                            {
                                if (_cTT.CheckExist("TXL", _dontxl.MaDon) == false)
                                {
                                    ToTrinh tt = new ToTrinh();
                                    tt.MaDonTXL = _dontxl.MaDon;
                                    _cTT.Them(tt);
                                }
                                if (_cTT.checkExist_ChiTiet("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim(), DateTime.Now) == true)
                                {
                                    MessageBox.Show("Danh Bộ này đã được Lập Thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //return;
                                }
                                cttt.ID = _cTT.Get("TXL", _dontxl.MaDon).ID;
                            }
                            else
                                if (_dontbc != null)
                                {
                                    if (_cTT.CheckExist("TBC", _dontbc.MaDon) == false)
                                    {
                                        ToTrinh tt = new ToTrinh();
                                        tt.MaDonTBC = _dontbc.MaDon;
                                        _cTT.Them(tt);
                                    }
                                    if (_cTT.checkExist_ChiTiet("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim(), DateTime.Now) == true)
                                    {
                                        MessageBox.Show("Danh Bộ này đã được Lập Thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //return;
                                    }
                                    cttt.ID = _cTT.Get("TBC", _dontbc.MaDon).ID;
                                }
                                else
                                {
                                    MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                    cttt.DanhBo = txtDanhBo.Text.Trim();
                    cttt.LoTrinh = txtMLT.Text.Trim();
                    cttt.HoTen = txtHoTen.Text.Trim();
                    cttt.DiaChi = txtDiaChi.Text.Trim();
                    cttt.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                    if (string.IsNullOrEmpty(txtDinhMuc.Text.Trim()) == false)
                        cttt.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                    if (string.IsNullOrEmpty(txtDinhMucHN.Text.Trim()) == false)
                        cttt.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                    cttt.VeViec = txtVeViec.Text.Trim();
                    cttt.KinhTrinh = txtKinhTrinh.Text.Trim();
                    cttt.NoiDung = txtNoiDung.Text;
                    cttt.NoiNhan = txtNoiNhan.Text.Trim();
                    if (_hoadon != null)
                    {
                        cttt.Dot = _hoadon.DOT;
                        cttt.Ky = _hoadon.KY;
                        cttt.Nam = _hoadon.NAM;
                        cttt.Phuong = _hoadon.Phuong;
                        cttt.Quan = _hoadon.Quan;
                        cttt.Hieu = _hoadon.HIEUDH;
                        cttt.Co = _hoadon.CoDH;
                        cttt.SoThan = _hoadon.SoThanDHN;
                    }
                    cttt.ThuDuocKy = true;

                    using (TransactionScope scope = new TransactionScope())
                        if (_cTT.Them_ChiTiet(cttt))
                        {
                            foreach (DataGridViewRow item in dgvHinh.Rows)
                            {
                                ToTrinh_ChiTiet_Hinh en = new ToTrinh_ChiTiet_Hinh();
                                en.IDToTrinh_ChiTiet = cttt.IDCT;
                                en.Name = item.Cells["Name_Hinh"].Value.ToString();
                                en.Hinh = Convert.FromBase64String(item.Cells["Bytes_Hinh"].Value.ToString());
                                _cTT.Them_Hinh(en);
                            }
                            if (_dontu_ChiTiet != null)
                            {
                                if (_cDonTu.Them_LichSu(cttt.CreateDate.Value, "ToTrinh", "Đã Lập Tờ Trình, " + cttt.VeViec, cttt.IDCT, _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value) == true)
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
                    if (_cttt != null)
                    {
                        _cttt.DanhBo = txtDanhBo.Text.Trim();
                        _cttt.LoTrinh = txtMLT.Text.Trim();
                        _cttt.HoTen = txtHoTen.Text.Trim();
                        _cttt.DiaChi = txtDiaChi.Text.Trim();
                        _cttt.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if (string.IsNullOrEmpty(txtDinhMuc.Text.Trim()) == false)
                            _cttt.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        else
                            _cttt.DinhMuc = null;
                        if (string.IsNullOrEmpty(txtDinhMucHN.Text.Trim()) == false)
                            _cttt.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                        else
                            _cttt.DinhMucHN = null;
                        _cttt.VeViec = txtVeViec.Text.Trim();
                        _cttt.KinhTrinh = txtKinhTrinh.Text.Trim();
                        _cttt.NoiDung = txtNoiDung.Text;
                        _cttt.NoiNhan = txtNoiNhan.Text.Trim();
                        if (_hoadon != null)
                        {
                            _cttt.Dot = _hoadon.DOT;
                            _cttt.Ky = _hoadon.KY;
                            _cttt.Nam = _hoadon.NAM;
                            _cttt.Phuong = _hoadon.Phuong;
                            _cttt.Quan = _hoadon.Quan;
                            _cttt.Hieu = _hoadon.HIEUDH;
                            _cttt.Co = _hoadon.CoDH;
                            _cttt.SoThan = _hoadon.SoThanDHN;
                        }

                        if (_cTT.Sua_ChiTiet(_cttt))
                        {
                            MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (_cttt != null && MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        var transactionOptions = new TransactionOptions();
                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                        {
                            DonTu_LichSu dtls = _cDonTu.get_LichSu("ToTrinh_ChiTiet", (int)_cttt.IDCT);
                            if (dtls != null)
                            {
                                _cDonTu.Xoa_LichSu(dtls,true);
                            }
                            if (_cTT.Xoa_ChiTiet(_cttt))
                            {
                                scope.Complete();
                                scope.Dispose();
                                MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Danh Bộ":
                case "Mã TT":
                case "Về Việc":
                    txtNoiDungTimKiem.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
            }
            dgvToTrinh.DataSource = null;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã TT":
                    dgvToTrinh.DataSource = _cTT.get_ChiTiet(int.Parse(txtNoiDungTimKiem.Text.Trim().Replace(" ", "").Replace("-", "")));
                    break;
                case "Danh Bộ":
                    dgvToTrinh.DataSource = _cTT.getDS_ChiTiet_DanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""));
                    break;
                case "Về Việc":
                    dgvToTrinh.DataSource = _cTT.getDS_ChiTiet_VeViec(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""));
                    break;
                case "Ngày":
                    dgvToTrinh.DataSource = _cTT.getDS_ChiTiet(dateTu.Value, dateDen.Value);
                    break;
                default:
                    break;
            }
        }

        private void dgvToTrinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _cttt = _cTT.get_ChiTiet(int.Parse(dgvToTrinh["IDCT", e.RowIndex].Value.ToString()));
                LoadTT(_cttt);
            }
            catch (Exception)
            {
            }

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_cttt != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                dr["SoPhieu"] = _cttt.IDCT.ToString().Insert(_cttt.IDCT.ToString().Length - 2, "-");
                dr["HoTen"] = _cttt.HoTen;
                dr["DiaChi"] = _cttt.DiaChi;
                if (!string.IsNullOrEmpty(_cttt.DanhBo) && _cttt.DanhBo.Length == 11)
                    dr["DanhBo"] = _cttt.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["LoTrinh"] = _cttt.LoTrinh;
                dr["GiaBieu"] = _cttt.GiaBieu;
                if (_cttt.DinhMuc != null)
                    dr["DinhMuc"] = _cttt.DinhMuc.Value;
                if (_cttt.DinhMucHN != null)
                    dr["DinhMucHN"] = _cttt.DinhMucHN.Value;

                dr["VeViec"] = _cttt.VeViec;
                dr["KinhTrinh"] = _cttt.KinhTrinh;
                dr["ThongQua"] = _cttt.ThongQua;
                dr["NoiDung"] = _cttt.NoiDung;
                dr["NoiNhan"] = _cttt.NoiNhan;
                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                    dr["ChucVu"] = "GIÁM ĐỐC";
                else
                    dr["ChucVu"] = "TRÌNH DUYỆT\n" + bangiamdoc.ChucVu.ToUpper();
                dr["NguoiKy"] = bangiamdoc.HoTen.ToUpper();

                dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                ReportDocument rpt;
                if (_cttt.KinhTrinh.ToLower().Contains("thông qua") == true)
                {
                    rpt = new rptToTrinh_ThongQuaPGD();
                }
                else
                {
                    rpt = new rptToTrinh();
                }
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }
        }

        private void dgvToTrinh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvToTrinh.Columns[e.ColumnIndex].Name == "IDCT" && e.Value != null)
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
        }

        private void dgvToTrinh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvToTrinh.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvToTrinh_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (dgvToTrinh.Columns[e.ColumnIndex].Name == "ThuDuocKy" && e.FormattedValue.ToString() != dgvToTrinh[e.ColumnIndex, e.RowIndex].Value.ToString())
                    {
                        ToTrinh_ChiTiet tt = _cTT.get_ChiTiet(int.Parse(dgvToTrinh["IDCT", e.RowIndex].Value.ToString()));
                        tt.ThuDuocKy = bool.Parse(e.FormattedValue.ToString());
                        _cTT.Sua_ChiTiet(tt);
                    }
                    if (dgvToTrinh.Columns[e.ColumnIndex].Name == "TraTrinhKy" && e.FormattedValue.ToString() != dgvToTrinh[e.ColumnIndex, e.RowIndex].Value.ToString())
                    {
                        ToTrinh_ChiTiet tt = _cTT.get_ChiTiet(int.Parse(dgvToTrinh["IDCT", e.RowIndex].Value.ToString()));
                        tt.TraTrinhKy = bool.Parse(e.FormattedValue.ToString());
                        _cTT.Sua_ChiTiet(tt);
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

        private void cmbVeViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVeViec.SelectedIndex != -1)
            {
                ToTrinh_VeViec vv = (ToTrinh_VeViec)cmbVeViec.SelectedItem;
                txtVeViec.Text = vv.Name;
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

        private void btnInDS_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn In những Thư trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                    for (int i = 0; i < dgvToTrinh.Rows.Count; i++)
                        if (dgvToTrinh["In", i].Value != null && bool.Parse(dgvToTrinh["In", i].Value.ToString()) == true)
                        {
                            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                            DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                            ToTrinh_ChiTiet cttt = _cTT.get_ChiTiet(int.Parse(dgvToTrinh["IDCT", i].Value.ToString()));

                            dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;
                            dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                            dr["SoPhieu"] = cttt.IDCT.ToString().Insert(cttt.IDCT.ToString().Length - 2, "-");
                            dr["HoTen"] = cttt.HoTen;
                            dr["DiaChi"] = cttt.DiaChi;
                            if (!string.IsNullOrEmpty(cttt.DanhBo) && cttt.DanhBo.Length == 11)
                                dr["DanhBo"] = cttt.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["LoTrinh"] = cttt.LoTrinh;
                            dr["GiaBieu"] = cttt.GiaBieu;
                            if (cttt.DinhMuc != null)
                                dr["DinhMuc"] = cttt.DinhMuc;
                            if (cttt.DinhMuc != null)
                                dr["DinhMucHN"] = cttt.DinhMucHN;

                            dr["VeViec"] = cttt.VeViec;
                            dr["KinhTrinh"] = cttt.KinhTrinh;
                            dr["ThongQua"] = cttt.ThongQua;
                            dr["NoiDung"] = cttt.NoiDung;
                            dr["NoiNhan"] = cttt.NoiNhan;
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                dr["ChucVu"] = "GIÁM ĐỐC";
                            else
                                dr["ChucVu"] = "TRÌNH DUYỆT\n" + bangiamdoc.ChucVu.ToUpper();
                            dr["NguoiKy"] = bangiamdoc.HoTen.ToUpper();

                            dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                            ReportDocument rpt;
                            if (cttt.KinhTrinh.ToLower().Contains("thông qua") == true)
                            {
                                rpt = new rptToTrinh_ThongQuaPGD();
                            }
                            else
                            {
                                rpt = new rptToTrinh();
                            }

                            rpt.SetDataSource(dsBaoCao);

                            printDialog.AllowSomePages = true;
                            printDialog.ShowHelp = true;

                            //rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                            //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                            rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                            rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                            rpt.Clone();
                            rpt.Dispose();
                        }
                }
            }
        }

        private void frmToTrinh_KeyUp(object sender, KeyEventArgs e)
        {
            if (_dontu_ChiTiet != null && e.Control && e.KeyCode == Keys.T)
            {
                frmCapNhatDonTu_Thumbnail frm = new frmCapNhatDonTu_Thumbnail(_dontu_ChiTiet);
                frm.ShowDialog();
            }
        }

        //add file
        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //ListViewItem item = new ListViewItem();
                    //item.ImageKey = "file";
                    //item.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    //item.SubItems.Add(Convert.ToBase64String(bytes));
                    //lstVFile.Items.Add(item);
                    byte[] bytes = System.IO.File.ReadAllBytes(dialog.FileName);
                    if (_cttt == null)
                    {
                        var index = dgvHinh.Rows.Add();
                        dgvHinh.Rows[index].Cells["Name_Hinh"].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(bytes);
                    }
                    else
                    {
                        if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                        {
                            ToTrinh_ChiTiet_Hinh en = new ToTrinh_ChiTiet_Hinh();
                            en.IDToTrinh_ChiTiet = _cttt.IDCT;
                            en.Name = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            en.Hinh = bytes;
                            if (_cTT.Them_Hinh(en) == true)
                            {
                                _cTT.Refresh();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                var index = dgvHinh.Rows.Add();
                                dgvHinh.Rows[index].Cells["Name_Hinh"].Value = en.Name;
                                dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(bytes);
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
            _cTT.LoadImageView(Convert.FromBase64String(dgvHinh.CurrentRow.Cells["Bytes_Hinh"].Value.ToString()));
        }

        private void xoaFile_dgvHinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (_cttt == null)
                    dgvHinh.Rows.RemoveAt(dgvHinh.CurrentRow.Index);
                else
                    if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                    {
                        if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (dgvHinh.CurrentRow.Cells["ID_Hinh"].Value != null)
                                if (_cTT.Xoa_Hinh(_cTT.get_Hinh(int.Parse(dgvHinh.CurrentRow.Cells["ID_Hinh"].Value.ToString()))))
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

        private void btnLapSoPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    int SoPhieuTong = (int)_cTT.getNextSoPhieuTong();
                    List<ToTrinh_ChiTiet> lst = new List<ToTrinh_ChiTiet>();
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    foreach (DataGridViewRow item in dgvToTrinh.Rows)
                        if (item.Cells["In"].Value != null && bool.Parse(item.Cells["In"].Value.ToString()) == true)
                        {
                            if (string.IsNullOrEmpty(item.Cells["SoPhieuTong"].Value.ToString()))
                            {
                                ToTrinh_ChiTiet cttt = _cTT.get_ChiTiet(int.Parse(item.Cells["IDCT"].Value.ToString()));
                                cttt.SoPhieuTong = (int)SoPhieuTong;
                                cttt.NgaySoPhieuTong = DateTime.Now;
                                cttt.NoiDungSoPhieuTong = txtNoiDungSoPhieuTong.Text.Trim();
                                _cTT.Sua_ChiTiet(cttt);
                            }
                            else
                                if (!lst.Any(itemlst => itemlst.SoPhieuTong == int.Parse(item.Cells["SoPhieuTong"].Value.ToString())))
                                    lst = lst.Concat(_cTT.getDS_ChiTiet_SoPhieuTong(int.Parse(item.Cells["SoPhieuTong"].Value.ToString()))).ToList();
                        }

                    lst = lst.Concat(_cTT.getDS_ChiTiet_SoPhieuTong(SoPhieuTong)).ToList();
                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                    foreach (ToTrinh_ChiTiet item in lst)
                    {
                        DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                        dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;
                        dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                        dr["SoPhieu"] = item.SoPhieuTong.ToString().Insert(item.SoPhieuTong.ToString().Length - 2, "-");

                        dr["VeViec"] = item.VeViec;
                        dr["KinhTrinh"] = item.KinhTrinh;
                        dr["ThongQua"] = item.ThongQua;
                        dr["NoiDung"] = item.NoiDungSoPhieuTong;
                        dr["NoiNhan"] = item.NoiNhan.Substring(0, item.NoiNhan.LastIndexOf("("));
                        if (item.VeViec.ToLower().Contains("nắp hộp bv") || item.VeViec.ToLower().Contains("nắp hộp bảo vệ"))
                            dr["Luuy"] = "+nắp hộp BV";
                        else
                            if (item.VeViec.ToLower().Contains("hộp bv") || item.VeViec.ToLower().Contains("hộp bảo vệ"))
                                dr["Luuy"] = "+hộp BV";
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            dr["ChucVu"] = "GIÁM ĐỐC";
                        else
                            dr["ChucVu"] = "TRÌNH DUYỆT\n" + bangiamdoc.ChucVu.ToUpper();
                        dr["NguoiKy"] = bangiamdoc.HoTen.ToUpper();

                        dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);
                        //
                        DataRow dr2 = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                        dr2["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                        dr2["SoPhieu"] = item.IDCT.ToString().Insert(item.IDCT.ToString().Length - 2, "-");
                        if (item.DanhBo.Length == 11)
                            dr2["DanhBo"] = item.DanhBo.Insert(7, " ").Insert(4, " ");
                        dr2["HoTen"] = item.HoTen;
                        dr2["DiaChi"] = item.DiaChi;
                        dr2["Hieu"] = item.Hieu;
                        dr2["Co"] = item.Co;
                        dr2["SoThan"] = item.SoThan;
                        dr2["Quan"] = item.Quan;
                        dr2["NoiDung"] = item.SoPhieuTong.ToString().Insert(item.SoPhieuTong.ToString().Length - 2, "-");
                        if (item.ToTrinh.ToTrinh_ChiTiets.Count == 1)
                            dr2["NoiNhan"] = item.ToTrinh.MaDonMoi;
                        else
                            dr2["NoiNhan"] = item.ToTrinh.MaDonMoi + "." + item.STT;

                        dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr2);
                    }

                    rptToTrinh_DCMS_DinhKem rpt2 = new rptToTrinh_DCMS_DinhKem();
                    rpt2.SetDataSource(dsBaoCao);
                    frmShowBaoCao frm2 = new frmShowBaoCao(rpt2);
                    frm2.Show();
                    rptToTrinh_DCMS rpt1 = new rptToTrinh_DCMS();
                    rpt1.SetDataSource(dsBaoCao);
                    frmShowBaoCao frm1 = new frmShowBaoCao(rpt1);
                    frm1.Show();

                    btnXem.PerformClick();
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaSoPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        foreach (DataGridViewRow item in dgvToTrinh.Rows)
                            if (item.Cells["In"].Value != null && bool.Parse(item.Cells["In"].Value.ToString()) == true && !string.IsNullOrEmpty(item.Cells["SoPhieuTong"].Value.ToString()))
                            {
                                ToTrinh_ChiTiet cttt = _cTT.get_ChiTiet(int.Parse(item.Cells["IDCT"].Value.ToString()));
                                cttt.SoPhieuTong = null;
                                cttt.NgaySoPhieuTong = null;
                                cttt.NoiDungSoPhieuTong = null;
                                _cTT.Sua_ChiTiet(cttt);
                            }
                        btnXem.PerformClick();
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

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                for (int i = 0; i < dgvToTrinh.Rows.Count; i++)
                {
                    dgvToTrinh["In", i].Value = true;
                }
            }
            else
                for (int i = 0; i < dgvToTrinh.Rows.Count; i++)
                {
                    dgvToTrinh["In", i].Value = false;
                }
        }






    }
}

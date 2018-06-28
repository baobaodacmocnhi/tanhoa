using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ToXuLy;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.DAL.TruyThu;
using KTKS_DonKH.BaoCao.TruyThu;

namespace KTKS_DonKH.GUI.TruyThu
{
    public partial class frmTruyThuTienNuoc : Form
    {
        string _mnu = "mnuTruyThuDMNuoc";
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();
        CTruyThuTienNuoc _cTTTN = new CTruyThuTienNuoc();

        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        TruyThuTienNuoc _tttn = null;
        decimal _MaTTTN = -1;

        public frmTruyThuTienNuoc()
        {
            InitializeComponent();
        }

        public frmTruyThuTienNuoc(decimal MaTTTN)
        {
            _MaTTTN = MaTTTN;
            InitializeComponent();
        }

        private void frmTruyThuTienNuoc_Load(object sender, EventArgs e)
        {
            dgvTruyThuTienNuoc.AutoGenerateColumns = false;
            dgvThanhToanTruyThuTienNuoc.AutoGenerateColumns = false;
            dgvThuMoi.AutoGenerateColumns = false;

            DataTable dt1 = _cTTTN.GetDSNoiDung();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (DataRow item in dt1.Rows)
            {
                auto1.Add(item["NoiDung"].ToString());
            }
            txtNoiDung.AutoCompleteCustomSource = auto1;

            if (_MaTTTN != -1)
            {
                txtMaTTTN.Text = _MaTTTN.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtMaTTTN_KeyPress(sender, arg);
            }
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHopDong.Text = hoadon.HOPDONG;
            txtLoTrinh.Text = hoadon.DOT + hoadon.MAY + hoadon.STT;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
            txtGiaBieu.Text = hoadon.GB.ToString();
            txtDinhMuc.Text = hoadon.DM.ToString();
        }

        public void LoadTTTN(TruyThuTienNuoc tttn)
        {
            if (tttn.MaDon != null)
            {
                _dontkh = _cDonKH.Get(tttn.MaDon.Value);
                txtMaDonCu.Text = tttn.MaDon.Value.ToString().Insert(tttn.MaDon.Value.ToString().Length - 2, "-");
            }
            else
                if (tttn.MaDonTXL != null)
                {
                    _dontxl = _cDonTXL.Get(tttn.MaDonTXL.Value);
                    txtMaDonCu.Text = "TXL" + tttn.MaDonTXL.Value.ToString().Insert(tttn.MaDonTXL.Value.ToString().Length - 2, "-");
                }
                else
                    if (tttn.MaDonTBC != null)
                    {
                        _dontbc = _cDonTBC.Get(tttn.MaDonTBC.Value);
                        txtMaDonCu.Text = "TBC" + tttn.MaDonTBC.Value.ToString().Insert(tttn.MaDonTBC.Value.ToString().Length - 2, "-");
                    }
            txtMaTTTN.Text = tttn.MaTTTN.ToString().Insert(tttn.MaTTTN.ToString().Length - 2, "-");
            //chkXepDon.Checked = tttn.XepDon;
            if (tttn.NgayTinhTrang != null)
            dateTinhTrang.Value = tttn.NgayTinhTrang.Value;
            cmbTinhTrang.SelectedItem = tttn.TinhTrang;
            txtDanhBo.Text = tttn.DanhBo;
            txtHopDong.Text = tttn.HopDong;
            txtLoTrinh.Text = tttn.LoTrinh;
            txtGiaBieu.Text = tttn.GiaBieu.Value.ToString();
            if (tttn.DinhMuc != null)
                txtDinhMuc.Text = tttn.DinhMuc.Value.ToString();
            txtHoTen.Text = tttn.HoTen;
            txtDiaChi.Text = tttn.DiaChi;
            txtDienThoai.Text = tttn.DienThoai;
            txtNoiDung.Text = tttn.NoiDung;

            foreach (CTTruyThuTienNuoc item in tttn.CTTruyThuTienNuocs.ToList())
            {
                dgvTruyThuTienNuoc.Rows.Insert(dgvTruyThuTienNuoc.RowCount - 1, 1);

                dgvTruyThuTienNuoc["MaCTTTTN", dgvTruyThuTienNuoc.RowCount - 2].Value = item.MaCTTTTN;
                dgvTruyThuTienNuoc["Ky", dgvTruyThuTienNuoc.RowCount - 2].Value = item.Ky;
                dgvTruyThuTienNuoc["Nam", dgvTruyThuTienNuoc.RowCount - 2].Value = item.Nam;
                dgvTruyThuTienNuoc["GiaBieu_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.GiaBieuCu;
                dgvTruyThuTienNuoc["DinhMuc_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.DinhMucCu;
                dgvTruyThuTienNuoc["TieuThu_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.TieuThuCu;
                dgvTruyThuTienNuoc["TongCong_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.TongCongCu;
                dgvTruyThuTienNuoc["GiaBieu_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.GiaBieuMoi;
                dgvTruyThuTienNuoc["DinhMuc_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.DinhMucMoi;
                dgvTruyThuTienNuoc["TieuThu_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.TieuThuMoi;
                dgvTruyThuTienNuoc["GiaBan_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.GiaBanMoi;
                dgvTruyThuTienNuoc["ThueGTGT_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.ThueGTGTMoi;
                dgvTruyThuTienNuoc["PhiBVMT_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.PhiBVMTMoi;
                dgvTruyThuTienNuoc["TongCong_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.TongCongMoi;
            }

            LoadDSThanhToan(tttn.MaTTTN);
            LoadDSThuMoi(tttn.MaTTTN);

            int Tongm3HoaDon = 0;
            int Tongm3ThucTe = 0;
            int GiaBan = 0;
            int ThueGTGT = 0;
            int PhiBVMT = 0;
            int TongCongCu = 0;
            int TongCongMoi = 0;
            foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                if (item.Cells["Ky"].Value != null)
                {
                    Tongm3HoaDon += int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                    Tongm3ThucTe += int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                    GiaBan += int.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                    ThueGTGT += int.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                    PhiBVMT += int.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                    TongCongMoi += int.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                    TongCongCu += int.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                }
            txtSoKy.Text = (dgvTruyThuTienNuoc.RowCount - 1).ToString();
            txtTongm3HoaDon.Text = Tongm3HoaDon.ToString();
            txtTongm3ThucTe.Text = Tongm3ThucTe.ToString();
            txtTongm3TruyThu.Text = (Tongm3ThucTe - Tongm3HoaDon).ToString();
            txtGiaBan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaBan);
            txtThueGTGT.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ThueGTGT);
            txtPhiBVMT.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", PhiBVMT);
            txtTongCongMoi.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongMoi);
            txtTongCongCu.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongCu);
            txtTongThanhToan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongMoi - TongCongCu);
        }

        public void Clear()
        {
            txtMaDonCu.Text = "";
            txtMaTTTN.Text = "";
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtLoTrinh.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDienThoai.Text = "";
            txtNoiDung.Text = "";
            cmbTinhTrang.SelectedIndex = -1;
            ///
            dateDongTien.Value = DateTime.Now;
            txtSoTien.Text = "";
            ///
            txtVaoLuc.Text = "";
            txtVeViec.Text = "";
            ///
            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            _tttn = null;
            _MaTTTN = -1;
            ///
            //dgvTruyThuTienNuoc.DataSource = null;
            dgvTruyThuTienNuoc.Rows.Clear();
            dgvThanhToanTruyThuTienNuoc.DataSource = null;
            dgvThuMoi.DataSource = null;
        }

        public void ClearThanhToan()
        {
            dateDongTien.Value = DateTime.Now;
            txtSoTien.Text = "";
        }

        public void ClearThuMoi()
        {
            txtVaoLuc.Text = "";
            txtVeViec.Text = "";
        }

        public void LoadDSThanhToan(decimal MaTTTN)
        {
            dgvThanhToanTruyThuTienNuoc.DataSource = _cTTTN.GetDSThanhToan(MaTTTN);
        }

        public void LoadDSThuMoi(decimal MaTTTN)
        {
            dgvThuMoi.DataSource = _cTTTN.GetDSThuMoi(MaTTTN);
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
                        if (_cTTTN.CheckExist("TXL", decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", ""))) == true)
                        {
                            _tttn = _cTTTN.Get("TXL", decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                            LoadTTTN(_tttn);
                        }
                        else
                        {
                            _dontxl = _cDonTXL.Get(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                            txtMaDonCu.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");

                            if (_cThuTien.GetMoiNhat(_dontxl.DanhBo) != null)
                            {
                                _hoadon = _cThuTien.GetMoiNhat(_dontxl.DanhBo);
                                LoadTTKH(_hoadon);
                            }
                            else
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            if (_cTTTN.CheckExist("TBC", decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", ""))) == true)
                            {
                                _tttn = _cTTTN.Get("TBC", decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                                LoadTTTN(_tttn);
                            }
                            else
                            {
                                _dontbc = _cDonTBC.Get(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                                txtMaDonCu.Text = "TBC" + _dontbc.MaDon.ToString().Insert(_dontbc.MaDon.ToString().Length - 2, "-");

                                if (_cThuTien.GetMoiNhat(_dontbc.DanhBo) != null)
                                {
                                    _hoadon = _cThuTien.GetMoiNhat(_dontbc.DanhBo);
                                    LoadTTKH(_hoadon);
                                }
                                else
                                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ///Đơn Tổ Khách Hàng
                    else
                        if (_cDonKH.CheckExist(decimal.Parse(txtMaDonCu.Text.Trim().Replace("-", ""))) == true)
                        {
                            if (_cTTTN.CheckExist("TKH", decimal.Parse(txtMaDonCu.Text.Trim().Replace("-", ""))) == true)
                            {
                                _tttn = _cTTTN.Get("TKH", decimal.Parse(txtMaDonCu.Text.Trim().Replace("-", "")));
                                LoadTTTN(_tttn);
                            }
                            else
                            {
                                _dontkh = _cDonKH.Get(decimal.Parse(txtMaDonCu.Text.Trim().Replace("-", "")));
                                txtMaDonCu.Text = _dontkh.MaDon.ToString().Insert(_dontkh.MaDon.ToString().Length - 2, "-");

                                if (_cThuTien.GetMoiNhat(_dontkh.DanhBo) != null)
                                {
                                    _hoadon = _cThuTien.GetMoiNhat(_dontkh.DanhBo);
                                    LoadTTKH(_hoadon);
                                }
                                else
                                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtMaDonMoi.Text = MaDon;
                ///Đơn Tổ Xử Lý
                if (txtMaDonMoi.Text.Trim().ToUpper().Contains("XL"))
                {
                    if (_cDonTXL.CheckExist(txtMaDonMoi.Text.Trim()) == true)
                    {
                        if (_cTTTN.CheckExist(txtMaDonMoi.Text.Trim()) == true)
                        {
                            _tttn = _cTTTN.Get(txtMaDonMoi.Text.Trim());
                            LoadTTTN(_tttn);
                        }
                        else
                        {
                            _dontxl = _cDonTXL.Get(txtMaDonMoi.Text.Trim());
                            txtMaDonMoi.Text =_dontxl.MaDonMoi;

                            if (_cThuTien.GetMoiNhat(_dontxl.DanhBo) != null)
                            {
                                _hoadon = _cThuTien.GetMoiNhat(_dontxl.DanhBo);
                                LoadTTKH(_hoadon);
                            }
                            else
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    if (txtMaDonMoi.Text.Trim().ToUpper().Contains("BC"))
                    {
                        if (_cDonTBC.CheckExist(txtMaDonMoi.Text.Trim()) == true)
                        {
                            if (_cTTTN.CheckExist(txtMaDonMoi.Text.Trim()) == true)
                            {
                                _tttn = _cTTTN.Get(txtMaDonMoi.Text.Trim());
                                LoadTTTN(_tttn);
                            }
                            else
                            {
                                _dontbc = _cDonTBC.Get(decimal.Parse(txtMaDonMoi.Text.Trim().Substring(3).Replace("-", "")));
                                txtMaDonMoi.Text = _dontbc.MaDonMoi;

                                if (_cThuTien.GetMoiNhat(_dontbc.DanhBo) != null)
                                {
                                    _hoadon = _cThuTien.GetMoiNhat(_dontbc.DanhBo);
                                    LoadTTKH(_hoadon);
                                }
                                else
                                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ///Đơn Tổ Khách Hàng
                    else
                        if (txtMaDonMoi.Text.Trim().ToUpper().Contains("KH"))
                        {
                            if (_cDonKH.CheckExist(txtMaDonMoi.Text.Trim()) == true)
                            {
                                if (_cTTTN.CheckExist(txtMaDonMoi.Text.Trim()) == true)
                                {
                                    _tttn = _cTTTN.Get(txtMaDonMoi.Text.Trim());
                                    LoadTTTN(_tttn);
                                }
                                else
                                {
                                    _dontkh = _cDonKH.Get(txtMaDonMoi.Text.Trim());
                                    txtMaDonMoi.Text = _dontkh.MaDonMoi;

                                    if (_cThuTien.GetMoiNhat(_dontkh.DanhBo) != null)
                                    {
                                        _hoadon = _cThuTien.GetMoiNhat(_dontkh.DanhBo);
                                        LoadTTKH(_hoadon);
                                    }
                                    else
                                        MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                                MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Length == 11)
            {
                _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                LoadTTKH(_hoadon);
            }
        }

        private void txtMaTTTN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && _cTTTN.CheckExist(decimal.Parse(txtMaTTTN.Text.Trim().Replace("-", ""))) == true)
            {
                string MaTTTN = txtMaTTTN.Text.Trim();
                Clear();
                txtMaTTTN.Text = MaTTTN;
                _tttn = _cTTTN.Get(decimal.Parse(txtMaTTTN.Text.Trim().Replace("-", "")));
                LoadTTTN(_tttn);
            }
        }

        private void dgvTruyThuTienNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTruyThuTienNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvTruyThuTienNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TongCong_Cu" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "GiaBan_Moi" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "ThueGTGT_Moi" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "PhiBVMT_Moi" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TongCong_Moi" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTruyThuTienNuoc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTruyThuTienNuoc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "GiaBieu_Cu")
            {
                dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value = dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value;

                int DinhMuc = 0;
                int TieuThu = 0;
                if (dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString()))
                    DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString());
                if (dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString()))
                    TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString());

                string ChiTietCu = "";
                int TongTienCu = _cGiaNuoc.TinhTienNuoc(false, 0, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString()), DinhMuc, TieuThu, out ChiTietCu);
                int PhiBVMT = _cGiaNuoc.TinhPhiBMVT(int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString()), DinhMuc, TieuThu);

                dgvTruyThuTienNuoc["GiaBan_Cu", e.RowIndex].Value = TongTienCu;
                dgvTruyThuTienNuoc["ThueGTGT_Cu", e.RowIndex].Value = Math.Round((double)TongTienCu * 5 / 100);
                if (PhiBVMT == 0)
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", e.RowIndex].Value = TongTienCu * 10 / 100;
                    dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + (TongTienCu * 10 / 100);
                }
                else
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", e.RowIndex].Value = PhiBVMT;
                    dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + PhiBVMT;
                }
                if (dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value != null)
                    if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) < int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                        dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Tăng";
                    else
                        if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) > int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Giảm";
                        else
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "";
            }

            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "DinhMuc_Cu")
            {
                dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value = dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value;

                int GiaBieu = 0;
                int TieuThu = 0;
                if (dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString()))
                    GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString());
                if (dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString()))
                    TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString());

                string ChiTietCu = "";
                int TongTienCu = _cGiaNuoc.TinhTienNuoc(false, 0, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, int.Parse(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString()), TieuThu, out ChiTietCu);
                int PhiBVMT = _cGiaNuoc.TinhPhiBMVT(int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, int.Parse(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString()), TieuThu);

                dgvTruyThuTienNuoc["GiaBan_Cu", e.RowIndex].Value = TongTienCu;
                dgvTruyThuTienNuoc["ThueGTGT_Cu", e.RowIndex].Value = Math.Round((double)TongTienCu * 5 / 100);
                if (PhiBVMT == 0)
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", e.RowIndex].Value = TongTienCu * 10 / 100;
                    dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + (TongTienCu * 10 / 100);
                }
                else
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", e.RowIndex].Value = PhiBVMT;
                    dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + PhiBVMT;
                }
                if (dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value != null)
                    if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) < int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                        dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Tăng";
                    else
                        if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) > int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Giảm";
                        else
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "";
            }

            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TieuThu_Cu")
            {
                dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value = dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value;

                int GiaBieu = 0;
                int DinhMuc = 0;
                if (dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString()))
                    GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString());
                if (dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString()))
                    DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString());

                string ChiTietCu = "";
                int TongTienCu = _cGiaNuoc.TinhTienNuoc(false, 0, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, int.Parse(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString()), out ChiTietCu);
                int PhiBVMT = _cGiaNuoc.TinhPhiBMVT(int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, int.Parse(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString()));

                dgvTruyThuTienNuoc["GiaBan_Cu", e.RowIndex].Value = TongTienCu;
                dgvTruyThuTienNuoc["ThueGTGT_Cu", e.RowIndex].Value = Math.Round((double)TongTienCu * 5 / 100);
                if (PhiBVMT == 0)
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", e.RowIndex].Value = TongTienCu * 10 / 100;
                    dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + (TongTienCu * 10 / 100);
                }
                else
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", e.RowIndex].Value = PhiBVMT;
                    dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + PhiBVMT;
                }
                if (dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value != null)
                    if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) < int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                        dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Tăng";
                    else
                        if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) > int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Giảm";
                        else
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "";
            }
            ////////////////////////////////////////////

            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "GiaBieu_Moi")
            {
                int DinhMuc = 0;
                int TieuThu = 0;
                if (dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString()))
                    DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString());
                if (dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString()))
                    TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString());

                string ChiTietMoi = "";
                int TongTienMoi = _cGiaNuoc.TinhTienNuoc(false, 0, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString()), DinhMuc, TieuThu, out ChiTietMoi);
                int PhiBVMT = _cGiaNuoc.TinhPhiBMVT(int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString()), DinhMuc, TieuThu);

                dgvTruyThuTienNuoc["GiaBan_Moi", e.RowIndex].Value = TongTienMoi;
                dgvTruyThuTienNuoc["ThueGTGT_Moi", e.RowIndex].Value = Math.Round((double)TongTienMoi * 5 / 100);
                if (PhiBVMT == 0)
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = TongTienMoi * 10 / 100;
                    dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + (TongTienMoi * 10 / 100);
                }
                else
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = PhiBVMT;
                    dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + PhiBVMT;
                }
                if (dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value != null)
                    if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) < int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                        dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Tăng";
                    else
                        if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) > int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Giảm";
                        else
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "";
            }

            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "DinhMuc_Moi")
            {
                int GiaBieu = 0;
                int TieuThu = 0;
                if (dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString()))
                    GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString());
                if (dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString()))
                    TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString());

                string ChiTietMoi = "";
                int TongTienMoi = _cGiaNuoc.TinhTienNuoc(false, 0, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, int.Parse(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString()), TieuThu, out ChiTietMoi);
                int PhiBVMT = _cGiaNuoc.TinhPhiBMVT(int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, int.Parse(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString()), TieuThu);

                dgvTruyThuTienNuoc["GiaBan_Moi", e.RowIndex].Value = TongTienMoi;
                dgvTruyThuTienNuoc["ThueGTGT_Moi", e.RowIndex].Value = Math.Round((double)TongTienMoi * 5 / 100);
                if (PhiBVMT == 0)
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = TongTienMoi * 10 / 100;
                    dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + (TongTienMoi * 10 / 100);
                }
                else
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = PhiBVMT;
                    dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + PhiBVMT;
                }
                if (dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value != null)
                    if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) < int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                        dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Tăng";
                    else
                        if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) > int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Giảm";
                        else
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "";
            }

            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TieuThu_Moi")
            {
                int GiaBieu = 0;
                int DinhMuc = 0;
                if (dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString()))
                    GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString());
                if (dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString()))
                    DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString());

                string ChiTietMoi = "";
                int TongTienMoi = _cGiaNuoc.TinhTienNuoc(false, 0, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, int.Parse(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString()), out ChiTietMoi);
                int PhiBVMT = _cGiaNuoc.TinhPhiBMVT(int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, int.Parse(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString()));

                dgvTruyThuTienNuoc["GiaBan_Moi", e.RowIndex].Value = TongTienMoi;
                dgvTruyThuTienNuoc["ThueGTGT_Moi", e.RowIndex].Value = Math.Round((double)TongTienMoi * 5 / 100);
                if (PhiBVMT == 0)
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = TongTienMoi * 10 / 100;
                    dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + (TongTienMoi * 10 / 100);
                }
                else
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = PhiBVMT;
                    dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + PhiBVMT;
                }
                if (dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value != null)
                    if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) < int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                        dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Tăng";
                    else
                        if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) > int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Giảm";
                        else
                            dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "";
            }
        }

        private void dgvTruyThuTienNuoc_Leave(object sender, EventArgs e)
        {
            int Tongm3HoaDon = 0;
            int Tongm3ThucTe = 0;
            int GiaBan = 0;
            int ThueGTGT = 0;
            int PhiBVMT = 0;
            int TongCongCu = 0;
            int TongCongMoi = 0;
            foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                if (item.Cells["Ky"].Value != null)
                {
                    Tongm3HoaDon += int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                    Tongm3ThucTe += int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                    GiaBan += int.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                    ThueGTGT += int.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                    PhiBVMT += int.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                    TongCongMoi += int.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                    TongCongCu += int.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                }
            txtSoKy.Text = (dgvTruyThuTienNuoc.RowCount - 1).ToString();
            txtTongm3HoaDon.Text = Tongm3HoaDon.ToString();
            txtTongm3ThucTe.Text = Tongm3ThucTe.ToString();
            txtTongm3TruyThu.Text = (Tongm3ThucTe - Tongm3HoaDon).ToString();
            txtGiaBan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaBan);
            txtThueGTGT.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ThueGTGT);
            txtPhiBVMT.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", PhiBVMT);
            txtTongCongMoi.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongMoi);
            txtTongCongCu.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongCu);
            txtTongThanhToan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongMoi - TongCongCu);
        }

        private void dgvTruyThuTienNuoc_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < dgvTruyThuTienNuoc.RowCount - 1)
            {
                dgvTruyThuTienNuoc["Nam", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["Nam", e.RowIndex].Value;
                dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value;
                dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value;
                dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value;
                dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value;
            }
        }

        private void dgvTruyThuTienNuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (dgvTruyThuTienNuoc.SelectedRows[0].Cells["MaCTTTTN"].Value != null)
                {
                    CTTruyThuTienNuoc cttttn = _cTTTN.GetCT(int.Parse(dgvTruyThuTienNuoc.SelectedRows[0].Cells["MaCTTTTN"].Value.ToString()));
                    _cTTTN.XoaCT(cttttn);
                }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    TruyThuTienNuoc tttn = new TruyThuTienNuoc();

                    if (_dontkh != null)
                    {
                        if (_cTTTN.CheckExist("TKH", _dontkh.MaDon) == true)
                        {
                            MessageBox.Show("Đơn này đã được Lập Truy Thu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        tttn.MaDon = _dontkh.MaDon;
                        tttn.MaDonMoi = _dontkh.MaDonMoi;
                    }
                    else
                        if (_dontxl != null)
                        {
                            if (_cTTTN.CheckExist("TXL", _dontxl.MaDon) == true)
                            {
                                MessageBox.Show("Đơn này đã được Lập Truy Thu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            tttn.MaDonTXL = _dontxl.MaDon;
                            tttn.MaDonMoi = _dontxl.MaDonMoi;
                        }
                        else
                            if (_dontbc != null)
                            {
                                if (_cTTTN.CheckExist("TBC", _dontbc.MaDon) == true)
                                {
                                    MessageBox.Show("Đơn này đã được Lập Truy Thu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                tttn.MaDonTBC = _dontbc.MaDon;
                                tttn.MaDonMoi = _dontbc.MaDonMoi;
                            }
                            else
                            {
                                MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                    tttn.DanhBo = txtDanhBo.Text.Trim();
                    tttn.HopDong = txtHopDong.Text.Trim();
                    tttn.LoTrinh = txtLoTrinh.Text.Trim();
                    tttn.HoTen = txtHoTen.Text.Trim();
                    tttn.DiaChi = txtDiaChi.Text.Trim();
                    if (!string.IsNullOrEmpty(txtGiaBieu.Text.Trim()))
                        tttn.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                    if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                        tttn.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                    tttn.DienThoai = txtDienThoai.Text.Trim();
                    tttn.NoiDung = txtNoiDung.Text.Trim();
                    if (cmbTinhTrang.SelectedIndex != -1)
                    {
                        tttn.NgayTinhTrang = dateTinhTrang.Value;
                        tttn.TinhTrang = cmbTinhTrang.SelectedItem.ToString();
                    }
                    else
                        tttn.TinhTrang = "";
                    if (_hoadon != null)
                    {
                        tttn.Dot = _hoadon.DOT.ToString();
                        tttn.Ky = _hoadon.KY.ToString();
                        tttn.Nam = _hoadon.NAM.ToString();
                        tttn.Phuong = _hoadon.Phuong;
                        tttn.Quan = _hoadon.Quan;
                    }

                    _cTTTN.Them(tttn);
                    decimal MaTTTN = tttn.MaTTTN;

                    /////thêm chi tiết
                    //foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                    //    if (item.Cells["Ky"].Value != null)
                    //    {
                    //        if (_cTTTN.CheckExist_CT(MaTTTN, item.Cells["Ky"].Value.ToString(), item.Cells["Nam"].Value.ToString()))
                    //        {
                    //            MessageBox.Show("Kỳ " + item.Cells["Ky"].Value.ToString() + "/" + item.Cells["Nam"].Value.ToString() + " đã có \rVui lòng xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //            return;
                    //        }
                    //    }

                    foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                        if(item.Cells["Ky"].Value != null&&item.Cells["Ky"].ToString()!="" )
                            if (_cTTTN.CheckExist_CT(MaTTTN, item.Cells["Ky"].Value.ToString(), item.Cells["Nam"].Value.ToString()) == false)
                            {
                                CTTruyThuTienNuoc cttttn = new CTTruyThuTienNuoc();
                                cttttn.MaTTTN = MaTTTN;
                                cttttn.Ky = item.Cells["Ky"].Value.ToString();
                                cttttn.Nam = item.Cells["Nam"].Value.ToString();
                                cttttn.GiaBieuCu = int.Parse(item.Cells["GiaBieu_Cu"].Value.ToString());
                                cttttn.DinhMucCu = int.Parse(item.Cells["DinhMuc_Cu"].Value.ToString());
                                cttttn.TieuThuCu = int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                                cttttn.GiaBanCu = int.Parse(item.Cells["GiaBan_Cu"].Value.ToString());
                                cttttn.ThueGTGTCu = int.Parse(item.Cells["ThueGTGT_Cu"].Value.ToString());
                                cttttn.PhiBVMTCu = int.Parse(item.Cells["PhiBVMT_Cu"].Value.ToString());
                                cttttn.TongCongCu = int.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                                ///
                                cttttn.GiaBieuMoi = int.Parse(item.Cells["GiaBieu_Moi"].Value.ToString());
                                cttttn.DinhMucMoi = int.Parse(item.Cells["DinhMuc_Moi"].Value.ToString());
                                cttttn.TieuThuMoi = int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                                cttttn.GiaBanMoi = int.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                                cttttn.ThueGTGTMoi = int.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                                cttttn.PhiBVMTMoi = int.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                                cttttn.TongCongMoi = int.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                                cttttn.TangGiam = item.Cells["TangGiam"].Value.ToString();

                                _cTTTN.ThemCT(cttttn);
                                //cttttn.CreateBy = CTaiKhoan.MaUser;
                                //cttttn.CreateDate = DateTime.Now;
                                //tttn.CTTruyThuTienNuocs.Add(cttttn);
                            }
                    _cTTTN.Refresh();

                    tttn = _cTTTN.Get(tttn.MaTTTN);
                    tttn.TongTien = tttn.CTTruyThuTienNuocs.Sum(item => item.TongCongMoi.Value) - tttn.CTTruyThuTienNuocs.Sum(item => item.TongCongCu.Value);
                    tttn.Tongm3BinhQuan = (int)Math.Round((double)tttn.TongTien / tttn.SoTien1m3);
                    _cTTTN.SubmitChanges();
                    
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    txtMaDonCu.Focus();
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
                    if (_tttn != null)
                    {
                        //_tttn.XepDon = chkXepDon.Checked;
                        if (cmbTinhTrang.SelectedIndex != -1)
                        {
                            _tttn.NgayTinhTrang = dateTinhTrang.Value;
                            _tttn.TinhTrang = cmbTinhTrang.SelectedItem.ToString();
                        }
                        else
                            _tttn.TinhTrang = "";
                        _tttn.DanhBo = txtDanhBo.Text.Trim();
                        _tttn.HopDong = txtHopDong.Text.Trim();
                        _tttn.LoTrinh = txtLoTrinh.Text.Trim();
                        _tttn.HoTen = txtHoTen.Text.Trim();
                        _tttn.DiaChi = txtDiaChi.Text.Trim();
                        if (!string.IsNullOrEmpty(txtGiaBieu.Text.Trim()))
                            _tttn.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                            _tttn.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        _tttn.NoiDung = txtNoiDung.Text.Trim();
                        _tttn.DienThoai = txtDienThoai.Text.Trim();
                        if (_hoadon != null&&_hoadon.DANHBA != txtDanhBo.Text.Trim())
                        {
                            _tttn.Dot = _hoadon.DOT.ToString();
                            _tttn.Ky = _hoadon.KY.ToString();
                            _tttn.Nam = _hoadon.NAM.ToString();
                            _tttn.Phuong = _hoadon.Phuong;
                            _tttn.Quan = _hoadon.Quan;
                        }

                        foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                            if (item.Cells["Ky"].Value != null && item.Cells["Ky"].ToString() != "")
                                if (_cTTTN.CheckExist_CT(_tttn.MaTTTN, item.Cells["Ky"].Value.ToString(), item.Cells["Nam"].Value.ToString()) == false)
                                //if (item.Cells["MaCTTTTN"].Value == null || item.Cells["MaCTTTTN"].Value.ToString()=="")
                                {
                                    CTTruyThuTienNuoc cttttn = new CTTruyThuTienNuoc();

                                    cttttn.MaTTTN = _tttn.MaTTTN;
                                    cttttn.Ky = item.Cells["Ky"].Value.ToString();
                                    cttttn.Nam = item.Cells["Nam"].Value.ToString();
                                    cttttn.GiaBieuCu = int.Parse(item.Cells["GiaBieu_Cu"].Value.ToString());
                                    cttttn.DinhMucCu = int.Parse(item.Cells["DinhMuc_Cu"].Value.ToString());
                                    cttttn.TieuThuCu = int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                                    cttttn.GiaBanCu = int.Parse(item.Cells["GiaBan_Cu"].Value.ToString());
                                    cttttn.ThueGTGTCu = int.Parse(item.Cells["ThueGTGT_Cu"].Value.ToString());
                                    cttttn.PhiBVMTCu = int.Parse(item.Cells["PhiBVMT_Cu"].Value.ToString());
                                    cttttn.TongCongCu = int.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                                    ///
                                    cttttn.GiaBieuMoi = int.Parse(item.Cells["GiaBieu_Moi"].Value.ToString());
                                    cttttn.DinhMucMoi = int.Parse(item.Cells["DinhMuc_Moi"].Value.ToString());
                                    cttttn.TieuThuMoi = int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                                    cttttn.GiaBanMoi = int.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                                    cttttn.ThueGTGTMoi = int.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                                    cttttn.PhiBVMTMoi = int.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                                    cttttn.TongCongMoi = int.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                                    cttttn.TangGiam = item.Cells["TangGiam"].Value.ToString();

                                    _cTTTN.ThemCT(cttttn);
                                    //cttttn.CreateBy = CTaiKhoan.MaUser;
                                    //cttttn.CreateDate = DateTime.Now;
                                    //_tttn.CTTruyThuTienNuocs.Add(cttttn);
                                }
                                else
                                {
                                    CTTruyThuTienNuoc cttttn = _cTTTN.GetCT(_tttn.MaTTTN, item.Cells["Ky"].Value.ToString(), item.Cells["Nam"].Value.ToString());
                                    //CTTruyThuTienNuoc cttttn = _cTTTN.GetCT(int.Parse(item.Cells["MaCTTTTN"].Value.ToString()));

                                    cttttn.Ky = item.Cells["Ky"].Value.ToString();
                                    cttttn.Nam = item.Cells["Nam"].Value.ToString();
                                    cttttn.GiaBieuCu = int.Parse(item.Cells["GiaBieu_Cu"].Value.ToString());
                                    cttttn.DinhMucCu = int.Parse(item.Cells["DinhMuc_Cu"].Value.ToString());
                                    cttttn.TieuThuCu = int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                                    cttttn.GiaBanCu = int.Parse(item.Cells["GiaBan_Cu"].Value.ToString());
                                    cttttn.ThueGTGTCu = int.Parse(item.Cells["ThueGTGT_Cu"].Value.ToString());
                                    cttttn.PhiBVMTCu = int.Parse(item.Cells["PhiBVMT_Cu"].Value.ToString());
                                    cttttn.TongCongCu = int.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                                    ///
                                    cttttn.GiaBieuMoi = int.Parse(item.Cells["GiaBieu_Moi"].Value.ToString());
                                    cttttn.DinhMucMoi = int.Parse(item.Cells["DinhMuc_Moi"].Value.ToString());
                                    cttttn.TieuThuMoi = int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                                    cttttn.GiaBanMoi = int.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                                    cttttn.ThueGTGTMoi = int.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                                    cttttn.PhiBVMTMoi = int.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                                    cttttn.TongCongMoi = int.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                                    cttttn.TangGiam = item.Cells["TangGiam"].Value.ToString();

                                    _cTTTN.SuaCT(cttttn);
                                }
                        _cTTTN.SubmitChanges();
                        _cTTTN.Refresh();

                        _tttn = _cTTTN.Get(_tttn.MaTTTN);
                        _tttn.TongTien = _tttn.CTTruyThuTienNuocs.Sum(item => item.TongCongMoi.Value) - _tttn.CTTruyThuTienNuocs.Sum(item => item.TongCongCu.Value);
                        _tttn.Tongm3BinhQuan = (int)Math.Round((double)_tttn.TongTien / _tttn.SoTien1m3);
                        _cTTTN.SubmitChanges();

                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (_tttn != null && MessageBox.Show("Bạn có chắc chắn xóa Toàn Bộ Truy Thu?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_cTTTN.Xoa(_tttn))
                        {
                            _cTTTN.Refresh();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                if (item.Cells["Ky"].Value != null)
                {
                    DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                    dr["MaDon"] = txtMaDonCu.Text.Trim();
                    dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = txtHoTen.Text.Trim();
                    dr["DiaChi"] = txtDiaChi.Text.Trim();
                    dr["HopDong"] = txtHopDong.Text.Trim();
                    dr["GiaBieu"] = txtGiaBieu.Text.Trim();
                    dr["DinhMuc"] = txtDinhMuc.Text.Trim();

                    dr["Ky"] = item.Cells["Ky"].Value.ToString();
                    dr["Nam"] = item.Cells["Nam"].Value.ToString();
                    dr["GiaBieuCu"] = item.Cells["GiaBieu_Cu"].Value.ToString();
                    dr["DinhMucCu"] = item.Cells["DinhMuc_Cu"].Value.ToString();
                    dr["TieuThuCu"] = item.Cells["TieuThu_Cu"].Value.ToString();
                    dr["GiaBanCu"] = item.Cells["GiaBan_Cu"].Value.ToString();
                    dr["ThueGTGTCu"] = item.Cells["ThueGTGT_Cu"].Value.ToString();
                    dr["PhiBVMTCu"] = item.Cells["PhiBVMT_Cu"].Value.ToString();
                    dr["TongCongCu"] = item.Cells["TongCong_Cu"].Value.ToString();
                    dr["GiaBieuMoi"] = item.Cells["GiaBieu_Moi"].Value.ToString();
                    dr["DinhMucMoi"] = item.Cells["DinhMuc_Moi"].Value.ToString();
                    dr["TieuThuMoi"] = item.Cells["TieuThu_Moi"].Value.ToString();
                    dr["GiaBanMoi"] = item.Cells["GiaBan_Moi"].Value.ToString();
                    dr["ThueGTGTMoi"] = item.Cells["ThueGTGT_Moi"].Value.ToString();
                    dr["PhiBVMTMoi"] = item.Cells["PhiBVMT_Moi"].Value.ToString();
                    dr["TongCongMoi"] = item.Cells["TongCong_Moi"].Value.ToString();
                    dr["TangGiam"] = item.Cells["TangGiam"].Value.ToString();
                    dr["NhanVien"] = CTaiKhoan.HoTen;
                    TruyThuTienNuoc tttn = new TruyThuTienNuoc();
                    if (_dontkh != null)
                        tttn = _cTTTN.Get("TKH", _dontkh.MaDon);
                    else
                        if (_dontxl != null)
                            tttn = _cTTTN.Get("TXL", _dontxl.MaDon);
                        else
                            if (_dontbc != null)
                                tttn = _cTTTN.Get("TBC", _dontbc.MaDon);
                    if (tttn != null)
                        dr["SoTien1m3"] = tttn.SoTien1m3;

                    dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
                }

            rptTruyThuTienNuoc rpt = new rptTruyThuTienNuoc();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnInChiTiet_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                if (item.Cells["Ky"].Value != null)
                {
                    DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                    dr["MaDon"] = txtMaDonCu.Text.Trim();
                    dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = txtHoTen.Text.Trim();
                    dr["DiaChi"] = txtDiaChi.Text.Trim();
                    dr["HopDong"] = txtHopDong.Text.Trim();
                    dr["GiaBieu"] = txtGiaBieu.Text.Trim();
                    dr["DinhMuc"] = txtDinhMuc.Text.Trim();

                    dr["Ky"] = item.Cells["Ky"].Value.ToString();
                    dr["Nam"] = item.Cells["Nam"].Value.ToString();
                    dr["GiaBieuCu"] = item.Cells["GiaBieu_Cu"].Value.ToString();
                    if (item.Cells["DinhMuc_Cu"].Value != null)
                        dr["DinhMucCu"] = item.Cells["DinhMuc_Cu"].Value.ToString();
                    dr["TieuThuCu"] = item.Cells["TieuThu_Cu"].Value.ToString();
                    dr["GiaBanCu"] = item.Cells["GiaBan_Cu"].Value.ToString();
                    dr["ThueGTGTCu"] = item.Cells["ThueGTGT_Cu"].Value.ToString();
                    dr["PhiBVMTCu"] = item.Cells["PhiBVMT_Cu"].Value.ToString();
                    dr["TongCongCu"] = item.Cells["TongCong_Cu"].Value.ToString();
                    dr["GiaBieuMoi"] = item.Cells["GiaBieu_Moi"].Value.ToString();
                    if (item.Cells["DinhMuc_Moi"].Value != null)
                        dr["DinhMucMoi"] = item.Cells["DinhMuc_Moi"].Value.ToString();
                    dr["TieuThuMoi"] = item.Cells["TieuThu_Moi"].Value.ToString();
                    dr["GiaBanMoi"] = item.Cells["GiaBan_Moi"].Value.ToString();
                    dr["ThueGTGTMoi"] = item.Cells["ThueGTGT_Moi"].Value.ToString();
                    dr["PhiBVMTMoi"] = item.Cells["PhiBVMT_Moi"].Value.ToString();
                    dr["TongCongMoi"] = item.Cells["TongCong_Moi"].Value.ToString();
                    if (item.Cells["TangGiam"].Value != null)
                        dr["TangGiam"] = item.Cells["TangGiam"].Value.ToString();
                    dr["NhanVien"] = CTaiKhoan.HoTen;
                    dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
                }

            rptTruyThuTienNuocChiTiet rpt = new rptTruyThuTienNuocChiTiet();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnThemThanhToan_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (_tttn != null)
                    {
                        ThanhToanTruyThuTienNuoc entity = new ThanhToanTruyThuTienNuoc();

                        entity.MaTTTN = _tttn.MaTTTN;
                        entity.NgayDong = dateDongTien.Value;
                        entity.SoTien = int.Parse(txtSoTien.Text.Trim());

                        if (_cTTTN.ThemThanhToan(entity))
                        {
                            ClearThanhToan();
                            LoadDSThanhToan(_tttn.MaTTTN);
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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

        private void btnSuaThanhToan_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (_tttn != null)
                    {
                        ThanhToanTruyThuTienNuoc entity = _cTTTN.GetThanhToan(int.Parse(dgvThanhToanTruyThuTienNuoc.SelectedRows[0].Cells["MaTTTTTN"].Value.ToString()));

                        entity.NgayDong = dateDongTien.Value;
                        entity.SoTien = int.Parse(txtSoTien.Text.Trim());

                        if (_cTTTN.SuaThanhToan(entity))
                        {
                            ClearThanhToan();
                            LoadDSThanhToan(_tttn.MaTTTN);
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnXoaThanhToan_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (_tttn != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        ThanhToanTruyThuTienNuoc entity = _cTTTN.GetThanhToan(int.Parse(dgvThanhToanTruyThuTienNuoc.SelectedRows[0].Cells["MaTTTTTN"].Value.ToString()));

                        if (_cTTTN.XoaThanhToan(entity))
                        {
                            ClearThanhToan();
                            LoadDSThanhToan(_tttn.MaTTTN);
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvThanhToanTruyThuTienNuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvThanhToanTruyThuTienNuoc.Rows[e.RowIndex].Selected = true;
                dateDongTien.Value = DateTime.Parse(dgvThanhToanTruyThuTienNuoc.SelectedRows[0].Cells["NgayDong"].Value.ToString());
                txtSoTien.Text = dgvThanhToanTruyThuTienNuoc.SelectedRows[0].Cells["SoTien"].Value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvThanhToanTruyThuTienNuoc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvThanhToanTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "DaThanhToan")
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    try
                    {
                        if (_tttn != null)
                        {
                            ThanhToanTruyThuTienNuoc entity = _cTTTN.GetThanhToan(int.Parse(dgvThanhToanTruyThuTienNuoc.SelectedRows[0].Cells["MaTTTTTN"].Value.ToString()));

                            entity.DaThanhToan = bool.Parse(dgvThanhToanTruyThuTienNuoc.SelectedRows[0].Cells["DaThanhToan"].Value.ToString());

                            if (_cTTTN.SuaThanhToan(entity))
                            {
                                ClearThanhToan();
                                LoadDSThanhToan(_tttn.MaTTTN);
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private void dgvThanhToanTruyThuTienNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvThanhToanTruyThuTienNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvThanhToanTruyThuTienNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvThanhToanTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void btnThemThuMoi_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (_tttn != null)
                    {
                        TruyThuTienNuoc_ThuMoi entity = new TruyThuTienNuoc_ThuMoi();

                        entity.MaTTTN = _tttn.MaTTTN;
                        entity.VaoLuc = txtVaoLuc.Text.Trim();
                        entity.VeViec = txtVeViec.Text.Trim();

                        if (_cTTTN.ThemThuMoi(entity))
                        {
                            _tttn.NgayTinhTrang = DateTime.Now;
                            _tttn.TinhTrang = "Đang gửi thư mời";
                            _cTTTN.SubmitChanges();
                            ClearThuMoi();
                            LoadDSThuMoi(_tttn.MaTTTN);
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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

        private void btnSuaThuMoi_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (_tttn != null)
                    {
                        TruyThuTienNuoc_ThuMoi entity = _cTTTN.GetThuMoi(int.Parse(dgvThuMoi.SelectedRows[0].Cells["ID"].Value.ToString()));

                        entity.VaoLuc = txtVaoLuc.Text.Trim();
                        entity.VeViec = txtVeViec.Text.Trim();

                        if (_cTTTN.SuaThuMoi(entity))
                        {
                            ClearThuMoi();
                            LoadDSThuMoi(_tttn.MaTTTN);
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnXoaThuMoi_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (_tttn != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        TruyThuTienNuoc_ThuMoi entity = _cTTTN.GetThuMoi(int.Parse(dgvThuMoi.SelectedRows[0].Cells["ID"].Value.ToString()));

                        if (_cTTTN.XoaThuMoi(entity))
                        {
                            ClearThuMoi();
                            LoadDSThuMoi(_tttn.MaTTTN);
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnInThuMoi_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

            dr["MaDon"] = txtMaDonCu.Text.Trim();
            dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " ");
            dr["HoTen"] = txtHoTen.Text.Trim();
            dr["DiaChi"] = txtDiaChi.Text.Trim();
            dr["VaoLuc"] = dgvThuMoi.SelectedRows[0].Cells["VaoLuc"].Value;
            dr["VeViec"] = dgvThuMoi.SelectedRows[0].Cells["VeViec"].Value;
            dr["Lan"] = dgvThuMoi.SelectedRows[0].Cells["Lan"].Value;

            dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);

            rptThuMoi rpt = new rptThuMoi();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void dgvThuMoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvThuMoi.Rows[e.RowIndex].Selected = true;
                txtVaoLuc.Text = dgvThuMoi.SelectedRows[0].Cells["VaoLuc"].Value.ToString();
                txtVeViec.Text = dgvThuMoi.SelectedRows[0].Cells["VeViec"].Value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvTruyThuTienNuoc_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (_tttn != null)
            {
                CTTruyThuTienNuoc cttttn = _cTTTN.GetCT(_tttn.MaTTTN, e.Row.Cells["Ky"].Value.ToString(), e.Row.Cells["Nam"].Value.ToString());
                if (_cTTTN.XoaCT(cttttn))
                {
                    _tttn = _cTTTN.Get(_tttn.MaTTTN);
                    _tttn.TongTien = _tttn.CTTruyThuTienNuocs.Sum(item => item.TongCongMoi.Value) - _tttn.CTTruyThuTienNuocs.Sum(item => item.TongCongCu.Value);
                    _tttn.Tongm3BinhQuan = (int)Math.Round((double)_tttn.TongTien / _tttn.SoTien1m3);
                    _cTTTN.SubmitChanges();
                }
            }
        }

    }
}

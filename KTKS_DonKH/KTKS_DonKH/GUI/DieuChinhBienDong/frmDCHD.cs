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
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.GUI.DonTu;
using System.Transactions;
using KTKS_DonKH.wrThuongVu;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDCHD : Form
    {
        string _mnu = "mnuDCHD";
        CDonTu _cDonTu = new CDonTu();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CDCBD _cDCBD = new CDCBD();
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();
        CKTXM _cKTXM = new CKTXM();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CDHN _cDHN = new CDHN();
        CDocSo _cDocSo = new CDocSo();
        CThuTien _cThuTien = new CThuTien();
        CKhuCongNghiep _cKCN = new CKhuCongNghiep();
        wsThuongVu _wsThuongVu = new wsThuongVu();

        DonTu_ChiTiet _dontu_ChiTiet = null;
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        DocSo _docso = null;
        DCBD_ChiTietHoaDon _ctdchd = null, _dchdLast = null;
        int _TieuThu_DieuChinhGia = 0;
        float _TyLeKhuCongNghiep = 0.0f;
        decimal _MaCTDCHD = -1;

        public frmDCHD()
        {
            InitializeComponent();
        }

        public frmDCHD(decimal MaCTDCHD)
        {
            _MaCTDCHD = MaCTDCHD;
            InitializeComponent();
        }

        private void frmDCHDN_Load(object sender, EventArgs e)
        {
            dgvLichSu.AutoGenerateColumns = false;
            dgvHinh.AutoGenerateColumns = false;

            if (_MaCTDCHD != -1)
            {
                txtSoPhieu.Text = _MaCTDCHD.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtSoPhieu_KeyPress(sender, arg);
            }

            txtKhauTru.Text = _cKCN.getDSKhauTruCoHoaDonMoi();
        }

        public void Clear()
        {
            //txtMaDon.Text = "";
            txtSoPhieu.Text = "";
            chkCodeF2.Checked = false;
            chkBaoCaoThue.Checked = false;
            ///
            txtSoVB.Text = "";
            dateNgayKy.Value = DateTime.Now;
            txtKyHD.Text = "";
            txtSoHD.Text = "";
            txtMaToTrinh.Text = "";
            chkChuyenNhap.Checked = false;
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            lbDangNgan.Text = "Tình Trạng Đăng Ngân";
            chkKhongApGiaGiam.Checked = false;
            ///
            txtHoTen_BD.Text = "";
            txtDiaChi_BD.Text = "";
            txtMST_BD.Text = "";
            txtLyDoDieuChinh.Text = "";
            txtGhiChu.Text = "";
            txtGiaBieu_Cu.Text = "0";
            txtDinhMucHN_Cu.Text = "0";
            txtDinhMuc_Cu.Text = "0";
            txtTieuThu_Cu.Text = "0";
            txtChiTietCu.Text = "";
            chkDieuChinhGia.Checked = false;
            txtGiaDieuChinh.Text = "0";
            txtGiaBieu_Moi.Text = "0";
            txtDinhMucHN_Moi.Text = "0";
            txtDinhMuc_Moi.Text = "0";
            txtTieuThu_Moi.Text = "0";
            txtChiTietMoi.Text = "";
            txtChiTietPhiBVMTMoi.Text = "";
            ///
            chkDieuChinhGia2.Checked = false;
            txtTieuThu_DieuChinhGia2.Text = "0";
            txtGiaDieuChinh2.Text = "0";
            chkDieuChinhGia3.Checked = false;
            txtTieuThuV1_DieuChinhGia3.Text = "0";
            txtTieuThuV2_DieuChinhGia3.Text = "0";
            chkTyLe.Checked = false;
            txtSH.Text = "0";
            txtSX.Text = "0";
            txtDV.Text = "0";
            txtHCSN.Text = "0";
            chkKhuCongNghiep.Checked = false;
            chkApGiaNuocCu.Checked = false;
            ///
            _dontu_ChiTiet = null;
            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            _docso = null;
            _ctdchd = null;
            _dchdLast = null;
            _MaCTDCHD = -1;
            dgvHinh.Rows.Clear();

            txtMaDonMoi.Focus();
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtMLT.Text = hoadon.MALOTRINH;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDHN.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
            //if (hoadon.GB != null)
            //    txtGiaBieu_Cu.Text = txtGiaBieu_Moi.Text = hoadon.GB.ToString();
            //else
            //    txtGiaBieu_Cu.Text = txtGiaBieu_Moi.Text = "0";
            //if (hoadon.DinhMucHN != null)
            //    txtDinhMucHN_Cu.Text = txtDinhMucHN_Moi.Text = hoadon.DinhMucHN.ToString();
            //else
            //    txtDinhMucHN_Cu.Text = txtDinhMucHN_Moi.Text = "0";
            //if (hoadon.DM != null)
            //    txtDinhMuc_Cu.Text = txtDinhMuc_Moi.Text = hoadon.DM.ToString();
            //else
            //    txtDinhMuc_Cu.Text = txtDinhMuc_Moi.Text = "0";
            //if (hoadon.TIEUTHU != null)
            //    txtTieuThu_Cu.Text = txtTieuThu_Moi.Text = _hoadon.TIEUTHU.Value.ToString();
            //else
            //    txtTieuThu_Cu.Text = txtTieuThu_Moi.Text = "0";
            if (_cDHN.CheckExist(hoadon.DANHBA) == false)
                MessageBox.Show("Danh Bộ Hủy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void LoadDCHD(DCBD_ChiTietHoaDon ctdchd)
        {
            try
            {
                if (ctdchd.DCBD.MaDonMoi != null)
                {
                    _dontu_ChiTiet = _cDonTu.get_ChiTiet(ctdchd.DCBD.MaDonMoi.Value, ctdchd.STT.Value);
                    if (_dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count == 1)
                        txtMaDonMoi.Text = ctdchd.DCBD.MaDonMoi.ToString();
                    else
                        txtMaDonMoi.Text = ctdchd.DCBD.MaDonMoi.Value.ToString() + "." + ctdchd.STT.Value.ToString();
                }
                else
                    if (ctdchd.DCBD.MaDon != null)
                    {
                        _dontkh = _cDonKH.Get(ctdchd.DCBD.MaDon.Value);
                        txtMaDonCu.Text = ctdchd.DCBD.MaDon.ToString().Insert(ctdchd.DCBD.MaDon.ToString().Length - 2, "-");
                    }
                    else
                        if (ctdchd.DCBD.MaDonTXL != null)
                        {
                            _dontxl = _cDonTXL.Get(ctdchd.DCBD.MaDonTXL.Value);
                            txtMaDonCu.Text = "TXL" + ctdchd.DCBD.MaDonTXL.ToString().Insert(ctdchd.DCBD.MaDonTXL.ToString().Length - 2, "-");
                        }
                        else
                            if (ctdchd.DCBD.MaDonTBC != null)
                            {
                                _dontbc = _cDonTBC.Get(ctdchd.DCBD.MaDonTBC.Value);
                                txtMaDonCu.Text = "TBC" + ctdchd.DCBD.MaDonTBC.ToString().Insert(ctdchd.DCBD.MaDonTBC.ToString().Length - 2, "-");
                            }

                txtSoPhieu.Text = ctdchd.MaCTDCHD.ToString().Insert(ctdchd.MaCTDCHD.ToString().Length - 2, "-");
                ///
                chkCodeF2.Checked = ctdchd.CodeF2;
                chkBaoCaoThue.Checked = ctdchd.BaoCaoThue;
                txtSoVB.Text = ctdchd.SoVB;
                dateNgayKy.Value = ctdchd.NgayKy.Value;
                txtKyHD.Text = ctdchd.KyHD;
                txtSoHD.Text = ctdchd.SoHD;
                if (ctdchd.MaToTrinh != null)
                    txtMaToTrinh.Text = ctdchd.MaToTrinh.Value.ToString().Insert(ctdchd.MaToTrinh.Value.ToString().Length - 2, "-");
                chkChuyenNhap.Checked = ctdchd.ChuyenNhap;
                txtDanhBo.Text = ctdchd.DanhBo;
                txtHoTen.Text = ctdchd.HoTen;
                txtDiaChi.Text = ctdchd.DiaChi;
                txtMLT.Text = ctdchd.MLT;
                ///
                string[] KyHD = txtKyHD.Text.Trim().Split('/');
                _hoadon = _cThuTien.Get(txtDanhBo.Text.Trim(), int.Parse(KyHD[0]), int.Parse(KyHD[1]));
                if (_hoadon != null)
                {
                }
                else
                {
                    _docso = _cDocSo.get(txtDanhBo.Text.Trim(), int.Parse(KyHD[0]), int.Parse(KyHD[1]));
                }
                ///
                chkKhongApGiaGiam.Checked = ctdchd.KhongApGiaGiam;
                txtGiaBieu_Cu.Text = ctdchd.GiaBieu.Value.ToString();
                txtDinhMucHN_Cu.Text = ctdchd.DinhMucHN.Value.ToString();
                txtDinhMuc_Cu.Text = ctdchd.DinhMuc.Value.ToString();
                txtTieuThu_Cu.Text = ctdchd.TieuThu.Value.ToString();

                ///
                chkDieuChinhGia.Checked = ctdchd.DieuChinhGia;
                if (ctdchd.GiaDieuChinh != null)
                    txtGiaDieuChinh.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.GiaDieuChinh.Value);
                else
                    txtGiaDieuChinh.Text = "0";
                ///
                txtHoTen_BD.Text = ctdchd.HoTen_BD;
                txtDiaChi_BD.Text = ctdchd.DiaChi_BD;
                txtMST_BD.Text = ctdchd.MST_BD;
                txtGiaBieu_Moi.Text = ctdchd.GiaBieu_BD.Value.ToString();
                txtDinhMucHN_Moi.Text = ctdchd.DinhMucHN_BD.Value.ToString();
                txtDinhMuc_Moi.Text = ctdchd.DinhMuc_BD.Value.ToString();
                txtTieuThu_Moi.Text = ctdchd.TieuThu_BD.Value.ToString();

                ///
                chkKhauTru.Checked = ctdchd.KhauTru;
                if (ctdchd.SoTienKhauTru != null)
                    txtSoTienKhauTru.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.SoTienKhauTru.Value);
                else
                    txtSoTienKhauTru.Text = "0";
                ///
                chkDieuChinhGia2.Checked = ctdchd.DieuChinhGia2;
                if (ctdchd.TieuThu_DieuChinhGia2 != null)
                    txtTieuThu_DieuChinhGia2.Text = ctdchd.TieuThu_DieuChinhGia2.Value.ToString();
                else
                    txtTieuThu_DieuChinhGia2.Text = "0";
                if (ctdchd.GiaDieuChinh2 != null)
                    txtGiaDieuChinh2.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.GiaDieuChinh2.Value);
                else
                    txtGiaDieuChinh2.Text = "0";
                ///
                chkDieuChinhGia3.Checked = ctdchd.DieuChinhGia3;
                if (ctdchd.TieuThuV1_DieuChinhGia3 != null)
                    txtTieuThuV1_DieuChinhGia3.Text = ctdchd.TieuThuV1_DieuChinhGia3.Value.ToString();
                else
                    txtTieuThuV1_DieuChinhGia3.Text = "0";
                if (ctdchd.TieuThuV2_DieuChinhGia3 != null)
                    txtTieuThuV2_DieuChinhGia3.Text = ctdchd.TieuThuV2_DieuChinhGia3.Value.ToString();
                else
                    txtTieuThuV2_DieuChinhGia3.Text = "0";
                ///
                chkTyLe.Checked = ctdchd.TyLe;
                if (ctdchd.SH != null)
                    txtSH.Text = ctdchd.SH.Value.ToString();
                else
                    txtSH.Text = "0";
                if (ctdchd.SX != null)
                    txtSX.Text = ctdchd.SX.Value.ToString();
                else
                    txtSX.Text = "0";
                if (ctdchd.DV != null)
                    txtDV.Text = ctdchd.DV.Value.ToString();
                else
                    txtDV.Text = "0";
                if (ctdchd.HCSN != null)
                    txtHCSN.Text = ctdchd.HCSN.Value.ToString();
                else
                    txtHCSN.Text = "0";
                ///
                chkKhuCongNghiep.Checked = ctdchd.KhuCongNghiep;
                chkApGiaNuocCu.Checked = ctdchd.ApGiaNuocCu;
                ///
                txtLyDoDieuChinh.Text = _ctdchd.LyDoDieuChinh;
                txtGhiChu.Text = _ctdchd.GhiChu;
                ///
                txtTieuThu_Start.Text = _ctdchd.TieuThu.Value.ToString();
                txtTienNuoc_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TienNuoc_Start);
                txtThueGTGT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.ThueGTGT_Start);
                txtPhiBVMT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_Start);
                if (ctdchd.PhiBVMT_Thue_Start != null)
                    txtPhiBVMT_Thue_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_Thue_Start);
                else
                    txtPhiBVMT_Thue_Start.Text = "0";
                txtTongCong_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_Start);
                ///
                lbTangGiam.Text = ctdchd.TangGiam;
                txtTieuThu_BD.Text = (ctdchd.TieuThu_BD - ctdchd.TieuThu).Value.ToString();

                txtTienNuoc_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TienNuoc_BD);
                txtThueGTGT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.ThueGTGT_BD);
                txtPhiBVMT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_BD);
                if (ctdchd.PhiBVMT_Thue_BD != 0)
                    txtPhiBVMT_Thue_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_Thue_BD);
                else
                    txtPhiBVMT_Thue_BD.Text = "0";
                txtTongCong_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_BD);
                ///
                txtTieuThu_End.Text = _ctdchd.TieuThu_BD.Value.ToString();
                if (ctdchd.TienNuoc_End != 0)
                    txtTienNuoc_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TienNuoc_End);
                else
                    txtTienNuoc_End.Text = "0";
                if (ctdchd.ThueGTGT_End != 0)
                    txtThueGTGT_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.ThueGTGT_End);
                else
                    txtThueGTGT_End.Text = "0";
                if (ctdchd.PhiBVMT_End != 0)
                    txtPhiBVMT_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_End);
                else
                    txtPhiBVMT_End.Text = "0";
                if (ctdchd.PhiBVMT_Thue_End != 0)
                    txtPhiBVMT_Thue_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_Thue_End);
                else
                    txtPhiBVMT_Thue_End.Text = "0";
                if (ctdchd.TongCong_End != 0)
                    txtTongCong_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_End);
                else
                    txtTongCong_End.Text = "0";

                txtChiTietCu.Text = ctdchd.ChiTietCu;
                txtChiTietMoi.Text = ctdchd.ChiTietMoi;

                dgvHinh.Rows.Clear();
                foreach (DCBD_ChiTietHoaDon_Hinh item in ctdchd.DCBD_ChiTietHoaDon_Hinhs.ToList())
                {
                    var index = dgvHinh.Rows.Add();
                    dgvHinh.Rows[index].Cells["ID_Hinh"].Value = item.ID;
                    dgvHinh.Rows[index].Cells["Name_Hinh"].Value = item.Name;
                    if (item.Hinh != null)
                        dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(item.Hinh.ToArray());
                    dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = item.Loai;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaDonCu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                if (txtMaDonCu.Text.Trim() != "")
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
                                //LoadTTKH(_hoadon);
                                chkCodeF2.Focus();
                            }
                            else
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Mã Đơn TXL này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                    //LoadTTKH(_hoadon);
                                    chkCodeF2.Focus();
                                }
                                else
                                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                                MessageBox.Show("Mã Đơn TBC này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                    //LoadTTKH(_hoadon);
                                    chkCodeF2.Focus();
                                }
                                else
                                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                                MessageBox.Show("Mã Đơn KH này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    txtMaDonMoi.Focus();
        }

        private void txtMaDonMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                if (txtMaDonMoi.Text.Trim() != "")
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
                            chkCodeF2.Focus();
                        }
                        else
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    chkCodeF2.Focus();
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Length == 11)
            {
                _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                if (_hoadon != null)
                {
                    LoadTTKH(_hoadon);
                    txtSoTienKhauTruConLai.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _cKCN.getSoTienKhauTruTon(_hoadon.DANHBA));
                    txtKyHD.Focus();
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtKyHD_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtKyHD.Text.Trim()) && !string.IsNullOrEmpty(txtDanhBo.Text.Trim()))
            {
                string[] KyHD = txtKyHD.Text.Trim().Split('/');
                _hoadon = _cThuTien.Get(txtDanhBo.Text.Trim(), int.Parse(KyHD[0]), int.Parse(KyHD[1]));
                if (_hoadon != null)
                {
                    LoadTTKH(_hoadon);
                    //_dchdLast = _cDCBD.getHoaDon_Last(_hoadon.DANHBA, _hoadon.NAM, _hoadon.KY);
                    //if (_dchdLast != null)
                    //{
                    //    txtGiaBieu_Cu.Text = _dchdLast.GiaBieu_BD.Value.ToString();
                    //    txtDinhMucHN_Cu.Text = _dchdLast.DinhMucHN_BD.Value.ToString();
                    //    txtDinhMuc_Cu.Text = _dchdLast.DinhMuc_BD.Value.ToString();
                    //    txtTieuThu_Cu.Text = _dchdLast.TieuThu_BD.Value.ToString();
                    //    txtChiTietCu.Text = _dchdLast.ChiTietMoi;
                    //    txtTienNuoc_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchdLast.TienNuoc_End.Value);
                    //    txtThueGTGT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchdLast.ThueGTGT_End.Value);
                    //    txtPhiBVMT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchdLast.PhiBVMT_End.Value);
                    //    txtTongCong_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _dchdLast.TongCong_End.Value);
                    //}
                    //else
                    {
                        txtGiaBieu_Cu.Text = txtGiaBieu_Moi.Text = _hoadon.GB.ToString();
                        if (_hoadon.DinhMucHN != null)
                            txtDinhMucHN_Cu.Text = txtDinhMucHN_Moi.Text = _hoadon.DinhMucHN.Value.ToString();
                        else
                            txtDinhMucHN_Cu.Text = txtDinhMucHN_Moi.Text = "0";
                        txtDinhMuc_Cu.Text = txtDinhMuc_Moi.Text = _hoadon.DM.Value.ToString();
                        txtTieuThu_Cu.Text = txtTieuThu_Moi.Text = _hoadon.TIEUTHU.Value.ToString();
                        txtTienNuoc_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _hoadon.GIABAN.Value);
                        txtThueGTGT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _hoadon.THUE.Value);
                        txtPhiBVMT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _hoadon.PHI.Value);
                        txtTongCong_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _hoadon.TONGCONG.Value);
                    }
                    txtSoHD.Text = _hoadon.SOPHATHANH.ToString("00000000");
                    if (_hoadon.DCHD == true)
                    {
                        lbDangNgan.Text = "Hóa Đơn có Điều Chỉnh Tiền Dư";
                        MessageBox.Show(lbDangNgan.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        if (_hoadon.MaNV_DangNgan == null)
                            lbDangNgan.Text = "Hóa Đơn Tồn";
                        else
                        {
                            lbDangNgan.Text = "Hóa Đơn Đã Đăng Ngân";
                            MessageBox.Show(lbDangNgan.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
                else
                {
                    _docso = _cDocSo.get(txtDanhBo.Text.Trim(), int.Parse(KyHD[0]), int.Parse(KyHD[1]));
                    MessageBox.Show("Hóa Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (txtDanhBo.Text.Trim().Length == 11 && txtKyHD.Text.Trim() != "")
                {
                    dgvLichSu.DataSource = _cDCBD.getDS_HoaDon(txtDanhBo.Text.Trim(), int.Parse(KyHD[1]), int.Parse(KyHD[0]));
                }
            }
        }

        private void txtDanhBo_Leave(object sender, EventArgs e)
        {
            //if (txtDanhBo.Text.Trim().Length == 11 && txtKyHD.Text.Trim() != "")
            //{
            //    string[] KyHD = txtKyHD.Text.Trim().Split('/');

            //    dgvLichSu.DataSource = _cDCBD.getDSHoaDon(txtDanhBo.Text.Trim(), int.Parse(KyHD[1]), int.Parse(KyHD[0]));
            //}
        }

        private void txtSoPhieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtSoPhieu.Text.Trim() != "")
            {
                string MaDon = txtSoPhieu.Text.Trim();
                Clear();
                txtSoPhieu.Text = MaDon;
                _ctdchd = _cDCBD.getHoaDon(decimal.Parse(txtSoPhieu.Text.Trim().Replace("-", "")));
                if (_ctdchd != null)
                {
                    LoadDCHD(_ctdchd);
                }
                else
                    MessageBox.Show("Số Phiếu này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (_hoadon != null)
                    {
                        if (_hoadon.SOHOADON == null)
                        {
                            MessageBox.Show("Chưa có Số Hóa Đơn\nLiên hệ Đ.TT để cập nhật", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    if (chkKhuCongNghiep.Checked == false)
                        if (chkChuyenNhap.Checked == true)
                        {
                            if (txtDanhBo.Text.Trim() == "" || txtKyHD.Text.Trim() == "")
                            {
                                MessageBox.Show("Chưa có Mã Đơn/Danh Bộ/Số Văn Bản/Kỳ Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                            if (txtDanhBo.Text.Trim() == "" || txtKyHD.Text.Trim() == "" || txtSoHD.Text.Trim() == "")
                            {
                                MessageBox.Show("Chưa có Mã Đơn/Danh Bộ/Số Văn Bản/Kỳ Hóa Đơn/Số Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                    DCBD_ChiTietHoaDon ctdchd = new DCBD_ChiTietHoaDon();

                    if (_dontu_ChiTiet != null)
                    {
                        if (_cDCBD.checkExist(_dontu_ChiTiet.MaDon.Value) == false)
                        {
                            DCBD dcbd = new DCBD();
                            dcbd.MaDonMoi = _dontu_ChiTiet.MaDon.Value;
                            _cDCBD.Them(dcbd);
                        }
                        if (_cDCBD.checkExist_HoaDon(_dontu_ChiTiet.MaDon.Value, txtDanhBo.Text.Trim(), txtKyHD.Text.Trim()) == true)
                        {
                            if (MessageBox.Show("Danh Bộ này đã Lập ĐCHD\nBạn có chắc chắn Thêm?", "Xác nhận thêm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                                return;
                        }
                        ctdchd.MaDCBD = _cDCBD.get(_dontu_ChiTiet.MaDon.Value).MaDCBD;
                        ctdchd.STT = _dontu_ChiTiet.STT.Value;
                    }
                    else
                        if (_dontkh != null)
                        {
                            if (_cDCBD.CheckExist("TKH", _dontkh.MaDon) == false)
                            {
                                DCBD dcbd = new DCBD();
                                dcbd.MaDon = _dontkh.MaDon;
                                _cDCBD.Them(dcbd);
                            }
                            if (_cDCBD.CheckExist_HoaDon("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim(), txtKyHD.Text.Trim()) == true)
                            {
                                if (MessageBox.Show("Danh Bộ này đã Lập ĐCHD\nBạn có chắc chắn Thêm?", "Xác nhận thêm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                                    return;
                            }
                            ctdchd.MaDCBD = _cDCBD.Get("TKH", _dontkh.MaDon).MaDCBD;
                        }
                        else
                            if (_dontxl != null)
                            {
                                if (_cDCBD.CheckExist("TXL", _dontxl.MaDon) == false)
                                {
                                    DCBD dcbd = new DCBD();
                                    dcbd.MaDonTXL = _dontxl.MaDon;
                                    _cDCBD.Them(dcbd);
                                }
                                if (_cDCBD.CheckExist_HoaDon("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim(), txtKyHD.Text.Trim()) == true)
                                {
                                    if (MessageBox.Show("Danh Bộ này đã Lập ĐCHD\nBạn có chắc chắn Thêm?", "Xác nhận thêm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                                        return;
                                }
                                ctdchd.MaDCBD = _cDCBD.Get("TXL", _dontxl.MaDon).MaDCBD;
                            }
                            else
                                if (_dontbc != null)
                                {
                                    if (_cDCBD.CheckExist("TBC", _dontbc.MaDon) == false)
                                    {
                                        DCBD dcbd = new DCBD();
                                        dcbd.MaDonTBC = _dontbc.MaDon;
                                        _cDCBD.Them(dcbd);
                                    }
                                    if (_cDCBD.CheckExist_HoaDon("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim(), txtKyHD.Text.Trim()) == true)
                                    {
                                        if (MessageBox.Show("Danh Bộ này đã Lập ĐCHD\nBạn có chắc chắn Thêm?", "Xác nhận thêm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                                            return;
                                    }
                                    ctdchd.MaDCBD = _cDCBD.Get("TBC", _dontbc.MaDon).MaDCBD;
                                }
                                else
                                {
                                    MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                    ctdchd.DanhBo = txtDanhBo.Text.Trim();
                    ctdchd.MLT = txtMLT.Text.Trim();
                    ctdchd.HoTen = txtHoTen.Text.Trim();
                    ctdchd.DiaChi = txtDiaChi.Text.Trim();
                    ctdchd.SoVB = txtSoVB.Text.Trim();
                    ctdchd.NgayKy = dateNgayKy.Value;

                    ctdchd.KyHD = txtKyHD.Text.Trim();
                    string[] KyHD = txtKyHD.Text.Trim().Split('/');
                    if (_hoadon != null)
                        ctdchd.Dot = _hoadon.DOT;
                    else
                        if (_docso != null)
                            ctdchd.Dot = int.Parse(_docso.Dot);
                    ctdchd.Ky = int.Parse(KyHD[0]);
                    ctdchd.Nam = int.Parse(KyHD[1]);
                    if (_hoadon != null)
                    {
                        ctdchd.MST = _hoadon.MST;
                        ctdchd.SoHoaDon = _hoadon.SOHOADON;
                        ctdchd.Phuong = _hoadon.Phuong;
                        ctdchd.Quan = _hoadon.Quan;
                    }
                    ctdchd.SoHD = txtSoHD.Text.Trim();
                    if (txtMaToTrinh.Text.Trim() != "")
                        ctdchd.MaToTrinh = int.Parse(txtMaToTrinh.Text.Trim().Replace("-", ""));
                    ctdchd.ChuyenNhap = chkChuyenNhap.Checked;
                    ///
                    ctdchd.KhongApGiaGiam = chkKhongApGiaGiam.Checked;
                    ctdchd.HoTen_BD = txtHoTen_BD.Text.Trim();
                    ctdchd.DiaChi_BD = txtDiaChi_BD.Text.Trim();
                    ctdchd.MST_BD = txtMST_BD.Text.Trim();
                    ctdchd.GiaBieu = int.Parse(txtGiaBieu_Cu.Text.Trim().Replace(".", ""));
                    ctdchd.DinhMucHN = int.Parse(txtDinhMucHN_Cu.Text.Trim().Replace(".", ""));
                    ctdchd.DinhMuc = int.Parse(txtDinhMuc_Cu.Text.Trim().Replace(".", ""));
                    ctdchd.TieuThu = int.Parse(txtTieuThu_Cu.Text.Trim().Replace(".", ""));
                    ///
                    ctdchd.GiaBieu_BD = int.Parse(txtGiaBieu_Moi.Text.Trim().Replace(".", ""));
                    ctdchd.DinhMucHN_BD = int.Parse(txtDinhMucHN_Moi.Text.Trim().Replace(".", ""));
                    ctdchd.DinhMuc_BD = int.Parse(txtDinhMuc_Moi.Text.Trim().Replace(".", ""));
                    ctdchd.TieuThu_BD = int.Parse(txtTieuThu_Moi.Text.Trim().Replace(".", ""));
                    ///
                    ctdchd.TienNuoc_Start = int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", ""));
                    ctdchd.ThueGTGT_Start = int.Parse(txtThueGTGT_Start.Text.Trim().Replace(".", ""));
                    ctdchd.PhiBVMT_Start = int.Parse(txtPhiBVMT_Start.Text.Trim().Replace(".", ""));
                    ctdchd.PhiBVMT_Thue_Start = int.Parse(txtPhiBVMT_Thue_Start.Text.Trim().Replace(".", ""));
                    ctdchd.TongCong_Start = int.Parse(txtTongCong_Start.Text.Trim().Replace(".", ""));
                    ctdchd.ChiTietCu = txtChiTietCu.Text.Trim();
                    ///
                    string ThongTin = "";
                    if (ctdchd.GiaBieu != ctdchd.GiaBieu_BD)
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "GB";
                        else
                            ThongTin += ". GB";
                    }
                    if (ctdchd.DinhMucHN != ctdchd.DinhMucHN_BD || ctdchd.DinhMuc != ctdchd.DinhMuc_BD)
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "ĐM";
                        else
                            ThongTin += ". ĐM";
                    }
                    if (ctdchd.TieuThu != ctdchd.TieuThu_BD)
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Tiêu Thụ";
                        else
                            ThongTin += ". Tiêu Thụ";
                    }
                    if (chkDieuChinhGia.Checked)
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Điều Chỉnh Giá";
                        else
                            ThongTin += ". Điều Chỉnh Giá";
                        ctdchd.DieuChinhGia = true;
                        ctdchd.TieuThu_DieuChinhGia = _TieuThu_DieuChinhGia;
                        ctdchd.GiaDieuChinh = int.Parse(txtGiaDieuChinh.Text.Trim().Replace(".", ""));
                    }
                    ///
                    if (chkKhauTru.Checked)
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Khấu Trừ";
                        else
                            ThongTin += ". Khấu Trừ";
                        ctdchd.KhauTru = true;
                        ctdchd.SoTienKhauTru = int.Parse(txtSoTienKhauTru.Text.Trim().Replace(".", ""));
                    }
                    ///
                    if (chkDieuChinhGia2.Checked)
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Điều Chỉnh Giá 2";
                        else
                            ThongTin += ". Điều Chỉnh Giá 2";
                        ctdchd.DieuChinhGia2 = true;
                        ctdchd.TieuThu_DieuChinhGia2 = int.Parse(txtTieuThu_DieuChinhGia2.Text.Trim().Replace(".", ""));
                        ctdchd.GiaDieuChinh2 = int.Parse(txtGiaDieuChinh2.Text.Trim().Replace(".", ""));
                    }
                    ///
                    if (chkDieuChinhGia3.Checked)
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Điều Chỉnh Giá 3";
                        else
                            ThongTin += ". Điều Chỉnh Giá 3";
                        ctdchd.DieuChinhGia3 = true;
                        ctdchd.TieuThuV1_DieuChinhGia3 = int.Parse(txtTieuThuV1_DieuChinhGia3.Text.Trim().Replace(".", ""));
                        ctdchd.TieuThuV2_DieuChinhGia3 = int.Parse(txtTieuThuV2_DieuChinhGia3.Text.Trim().Replace(".", ""));
                    }
                    ///
                    if (chkTyLe.Checked)
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Tỷ Lệ";
                        else
                            ThongTin += ". Tỷ Lệ";
                        ctdchd.TyLe = true;
                        ctdchd.SH = int.Parse(txtSH.Text.Trim().Replace(".", ""));
                        ctdchd.SX = int.Parse(txtSX.Text.Trim().Replace(".", ""));
                        ctdchd.DV = int.Parse(txtDV.Text.Trim().Replace(".", ""));
                        ctdchd.HCSN = int.Parse(txtHCSN.Text.Trim().Replace(".", ""));
                    }
                    ///
                    if (chkKhuCongNghiep.Checked)
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Khu Công Nghiệp";
                        else
                            ThongTin += ". Khu Công Nghiệp";
                        ctdchd.KhuCongNghiep = true;
                        ctdchd.TyLeKhuCongNghiep = _TyLeKhuCongNghiep;
                    }
                    ///
                    if (chkHoNgheo.Checked)
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Hộ Nghèo";
                        else
                            ThongTin += ". Hộ Nghèo";
                        ctdchd.HoNgheo = true;
                    }
                    //
                    if (ctdchd.HoTen_BD != "" && ctdchd.HoTen_BD != ctdchd.HoTen)
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Họ Tên";
                        else
                            ThongTin += ". Họ Tên";
                    }
                    if (ctdchd.DiaChi_BD != "" && ctdchd.DiaChi_BD != ctdchd.DiaChi)
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Địa Chỉ";
                        else
                            ThongTin += ". Địa Chỉ";
                    }
                    ctdchd.ApGiaNuocCu = chkApGiaNuocCu.Checked;
                    ctdchd.ThongTin = ThongTin;
                    ctdchd.LyDoDieuChinh = txtLyDoDieuChinh.Text.Trim();
                    ctdchd.GhiChu = txtGhiChu.Text.Trim();

                    ctdchd.TienNuoc_BD = int.Parse(txtTienNuoc_BD.Text.Trim().Replace(".", ""));
                    ctdchd.ThueGTGT_BD = int.Parse(txtThueGTGT_BD.Text.Trim().Replace(".", ""));
                    ctdchd.PhiBVMT_BD = int.Parse(txtPhiBVMT_BD.Text.Trim().Replace(".", ""));
                    ctdchd.PhiBVMT_Thue_BD = int.Parse(txtPhiBVMT_Thue_BD.Text.Trim().Replace(".", ""));
                    ctdchd.TongCong_BD = int.Parse(txtTongCong_BD.Text.Trim().Replace(".", ""));
                    ///
                    ctdchd.TienNuoc_End = int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", ""));
                    ctdchd.ThueGTGT_End = int.Parse(txtThueGTGT_End.Text.Trim().Replace(".", ""));
                    ctdchd.PhiBVMT_End = int.Parse(txtPhiBVMT_End.Text.Trim().Replace(".", ""));
                    ctdchd.PhiBVMT_Thue_End = int.Parse(txtPhiBVMT_Thue_End.Text.Trim().Replace(".", ""));
                    ctdchd.TongCong_End = int.Parse(txtTongCong_End.Text.Trim().Replace(".", ""));
                    ctdchd.ChiTietMoi = txtChiTietMoi.Text.Trim();
                    if (ctdchd.TienNuoc_End - ctdchd.TienNuoc_Start == 0)
                        ctdchd.TangGiam = "";
                    else
                        if (ctdchd.TienNuoc_End - ctdchd.TienNuoc_Start > 0)
                            ctdchd.TangGiam = "Tăng";
                        else
                            ctdchd.TangGiam = "Giảm";

                    ///Ký Tên
                    //BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                    //if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                    //    ctdchd.ChucVu = "GIÁM ĐỐC";
                    //else
                    //    ctdchd.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                    //ctdchd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                    ctdchd.PhieuDuocKy = true;

                    ctdchd.CodeF2 = chkCodeF2.Checked;
                    ctdchd.BaoCaoThue = chkBaoCaoThue.Checked;

                    using (TransactionScope scope = new TransactionScope())
                        if (_cDCBD.ThemDCHD(ctdchd))
                        {
                            if (_cKCN.checkExist_KhauTru(ctdchd.DanhBo) == true)
                            {
                                DCBD_KhauTru en = _cKCN.get_KhauTruTon(ctdchd.DanhBo);
                                DCBD_KhauTru_LichSu enLS = new DCBD_KhauTru_LichSu();
                                enLS.DanhBo = en.DanhBo;
                                enLS.Ky = ctdchd.KyHD;
                                enLS.SoTien = ctdchd.SoTienKhauTru;
                                enLS.IDKhauTru = en.ID;
                                enLS.IDDCHD = (int)ctdchd.MaCTDCHD;
                                _cKCN.Them_KhauTruLichSu(enLS);
                            }
                            foreach (DataGridViewRow item in dgvHinh.Rows)
                            {
                                DCBD_ChiTietHoaDon_Hinh en = new DCBD_ChiTietHoaDon_Hinh();
                                en.IDDCBD_ChiTietHoaDon = ctdchd.MaCTDCHD;
                                en.Name = item.Cells["Name_Hinh"].Value.ToString();
                                //en.Hinh = Convert.FromBase64String(item.Cells["Bytes_Hinh"].Value.ToString());
                                en.Loai = item.Cells["Loai_Hinh"].Value.ToString();
                                if (_wsThuongVu.ghi_Hinh("DCBD_ChiTietHoaDon_Hinh", en.IDDCBD_ChiTietHoaDon.Value.ToString(), en.Name + en.Loai, Convert.FromBase64String(item.Cells["Bytes_Hinh"].Value.ToString())) == true)
                                    _cDCBD.Them_Hinh(en);
                            }
                            if (_dontu_ChiTiet != null)
                            {
                                if (_cDonTu.Them_LichSu(ctdchd.CreateDate.Value, "DCHD", "Đã Điều Chỉnh Hóa Đơn, " + ctdchd.ThongTin, (int)ctdchd.MaCTDCHD, _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value) == true)
                                    scope.Complete();
                            }
                            else
                                scope.Complete();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
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
                    if (_ctdchd != null)
                    {
                        _ctdchd.DanhBo = txtDanhBo.Text.Trim();
                        _ctdchd.HoTen = txtHoTen.Text.Trim();
                        _ctdchd.DiaChi = txtDiaChi.Text.Trim();
                        _ctdchd.MLT = txtMLT.Text.Trim();
                        _ctdchd.SoVB = txtSoVB.Text.Trim();
                        _ctdchd.NgayKy = dateNgayKy.Value;

                        _ctdchd.KyHD = txtKyHD.Text.Trim();
                        string[] KyHD = txtKyHD.Text.Trim().Split('/');
                        _ctdchd.Ky = int.Parse(KyHD[0]);
                        _ctdchd.Nam = int.Parse(KyHD[1]);
                        if (_hoadon != null)
                        {
                            _ctdchd.MST = _hoadon.MST;
                            _ctdchd.SoHoaDon = _hoadon.SOHOADON;
                            _ctdchd.Phuong = _hoadon.Phuong;
                            _ctdchd.Quan = _hoadon.Quan;
                        }

                        _ctdchd.SoHD = txtSoHD.Text.Trim();
                        if (txtMaToTrinh.Text.Trim() != "")
                            _ctdchd.MaToTrinh = int.Parse(txtMaToTrinh.Text.Trim().Replace("-", ""));
                        _ctdchd.ChuyenNhap = chkChuyenNhap.Checked;
                        ///
                        _ctdchd.KhongApGiaGiam = chkKhongApGiaGiam.Checked;
                        _ctdchd.GiaBieu = int.Parse(txtGiaBieu_Cu.Text.Trim().Replace(".", ""));
                        _ctdchd.DinhMucHN = int.Parse(txtDinhMucHN_Cu.Text.Trim().Replace(".", ""));
                        _ctdchd.DinhMuc = int.Parse(txtDinhMuc_Cu.Text.Trim().Replace(".", ""));
                        _ctdchd.TieuThu = int.Parse(txtTieuThu_Cu.Text.Trim().Replace(".", ""));
                        ///
                        _ctdchd.HoTen_BD = txtHoTen_BD.Text.Trim();
                        _ctdchd.DiaChi_BD = txtDiaChi_BD.Text.Trim();
                        _ctdchd.MST_BD = txtMST_BD.Text.Trim();
                        _ctdchd.GiaBieu_BD = int.Parse(txtGiaBieu_Moi.Text.Trim().Replace(".", ""));
                        _ctdchd.DinhMucHN_BD = int.Parse(txtDinhMucHN_Moi.Text.Trim().Replace(".", ""));
                        _ctdchd.DinhMuc_BD = int.Parse(txtDinhMuc_Moi.Text.Trim().Replace(".", ""));
                        _ctdchd.TieuThu_BD = int.Parse(txtTieuThu_Moi.Text.Trim().Replace(".", ""));
                        ///
                        _ctdchd.TienNuoc_Start = int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", ""));
                        _ctdchd.ThueGTGT_Start = int.Parse(txtThueGTGT_Start.Text.Trim().Replace(".", ""));
                        _ctdchd.PhiBVMT_Start = int.Parse(txtPhiBVMT_Start.Text.Trim().Replace(".", ""));
                        _ctdchd.PhiBVMT_Thue_Start = int.Parse(txtPhiBVMT_Thue_Start.Text.Trim().Replace(".", ""));
                        _ctdchd.TongCong_Start = int.Parse(txtTongCong_Start.Text.Trim().Replace(".", ""));
                        _ctdchd.ChiTietCu = txtChiTietCu.Text.Trim();
                        ///
                        string ThongTin = "";
                        if (_ctdchd.GiaBieu != _ctdchd.GiaBieu_BD)
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "GB";
                            else
                                ThongTin += ". GB";
                        }
                        if (_ctdchd.DinhMucHN != _ctdchd.DinhMucHN_BD || _ctdchd.DinhMuc != _ctdchd.DinhMuc_BD)
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "ĐM";
                            else
                                ThongTin += ". ĐM";
                        }
                        if (_ctdchd.TieuThu != _ctdchd.TieuThu_BD)
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Tiêu Thụ";
                            else
                                ThongTin += ". Tiêu Thụ";
                        }
                        if (chkDieuChinhGia.Checked)
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Điều Chỉnh Giá";
                            else
                                ThongTin += ". Điều Chỉnh Giá";
                            _ctdchd.DieuChinhGia = true;
                            _ctdchd.TieuThu_DieuChinhGia = _TieuThu_DieuChinhGia;
                            _ctdchd.GiaDieuChinh = int.Parse(txtGiaDieuChinh.Text.Trim().Replace(".", ""));
                        }
                        else
                        {
                            _ctdchd.DieuChinhGia = false;
                            _ctdchd.TieuThu_DieuChinhGia = null;
                            _ctdchd.GiaDieuChinh = null;
                        }
                        ///
                        if (chkKhauTru.Checked)
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Khấu Trừ";
                            else
                                ThongTin += ". Khấu Trừ";
                            _ctdchd.KhauTru = true;
                            _ctdchd.SoTienKhauTru = int.Parse(txtSoTienKhauTru.Text.Trim().Replace(".", ""));
                        }
                        else
                        {
                            _ctdchd.KhauTru = false;
                            _ctdchd.SoTienKhauTru = null;
                        }
                        ///
                        if (chkDieuChinhGia2.Checked)
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Điều Chỉnh Giá 2";
                            else
                                ThongTin += ". Điều Chỉnh Giá 2";
                            _ctdchd.DieuChinhGia2 = true;
                            _ctdchd.TieuThu_DieuChinhGia2 = int.Parse(txtTieuThu_DieuChinhGia2.Text.Trim().Replace(".", ""));
                            _ctdchd.GiaDieuChinh2 = int.Parse(txtGiaDieuChinh2.Text.Trim().Replace(".", ""));
                        }
                        else
                        {
                            _ctdchd.DieuChinhGia2 = false;
                            _ctdchd.TieuThu_DieuChinhGia2 = null;
                            _ctdchd.GiaDieuChinh2 = null;
                        }
                        ///
                        if (chkDieuChinhGia3.Checked)
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Điều Chỉnh Giá 3";
                            else
                                ThongTin += ". Điều Chỉnh Giá 3";
                            _ctdchd.DieuChinhGia3 = true;
                            _ctdchd.TieuThuV1_DieuChinhGia3 = int.Parse(txtTieuThuV1_DieuChinhGia3.Text.Trim().Replace(".", ""));
                            _ctdchd.TieuThuV2_DieuChinhGia3 = int.Parse(txtTieuThuV2_DieuChinhGia3.Text.Trim().Replace(".", ""));
                        }
                        else
                        {
                            _ctdchd.DieuChinhGia2 = false;
                            _ctdchd.TieuThuV1_DieuChinhGia3 = null;
                            _ctdchd.TieuThuV2_DieuChinhGia3 = null;
                        }
                        ///
                        if (chkTyLe.Checked)
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Tỷ Lệ";
                            else
                                ThongTin += ". Tỷ Lệ";
                            _ctdchd.TyLe = true;
                            _ctdchd.SH = int.Parse(txtSH.Text.Trim().Replace(".", ""));
                            _ctdchd.SX = int.Parse(txtSX.Text.Trim().Replace(".", ""));
                            _ctdchd.DV = int.Parse(txtDV.Text.Trim().Replace(".", ""));
                            _ctdchd.HCSN = int.Parse(txtHCSN.Text.Trim().Replace(".", ""));
                        }
                        else
                        {
                            _ctdchd.TyLe = false;
                            _ctdchd.SH = null;
                            _ctdchd.SX = null;
                            _ctdchd.DV = null;
                            _ctdchd.HCSN = null;
                        }
                        ///
                        if (chkKhuCongNghiep.Checked)
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Khu Công Nghiệp";
                            else
                                ThongTin += ". Khu Công Nghiệp";
                            _ctdchd.KhuCongNghiep = true;
                            _ctdchd.TyLeKhuCongNghiep = _TyLeKhuCongNghiep;
                        }
                        else
                        {
                            _ctdchd.KhuCongNghiep = false;
                            _ctdchd.TyLeKhuCongNghiep = null;
                        }
                        if (chkHoNgheo.Checked)
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Hộ Nghèo";
                            else
                                ThongTin += ". Hộ Nghèo";
                            _ctdchd.HoNgheo = true;
                        }
                        //
                        if (_ctdchd.HoTen_BD != "" && _ctdchd.HoTen_BD != _ctdchd.HoTen)
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Họ Tên";
                            else
                                ThongTin += ". Họ Tên";
                        }
                        if (_ctdchd.DiaChi_BD != "" && _ctdchd.DiaChi_BD != _ctdchd.DiaChi)
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Địa Chỉ";
                            else
                                ThongTin += ". Địa Chỉ";
                        }
                        _ctdchd.ApGiaNuocCu = chkApGiaNuocCu.Checked;
                        _ctdchd.ThongTin = ThongTin;
                        _ctdchd.LyDoDieuChinh = txtLyDoDieuChinh.Text.Trim();
                        _ctdchd.GhiChu = txtGhiChu.Text.Trim();

                        _ctdchd.TienNuoc_BD = int.Parse(txtTienNuoc_BD.Text.Trim().Replace(".", ""));
                        _ctdchd.ThueGTGT_BD = int.Parse(txtThueGTGT_BD.Text.Trim().Replace(".", ""));
                        _ctdchd.PhiBVMT_BD = int.Parse(txtPhiBVMT_BD.Text.Trim().Replace(".", ""));
                        _ctdchd.PhiBVMT_Thue_BD = int.Parse(txtPhiBVMT_Thue_BD.Text.Trim().Replace(".", ""));
                        _ctdchd.TongCong_BD = int.Parse(txtTongCong_BD.Text.Trim().Replace(".", ""));
                        ///
                        _ctdchd.TienNuoc_End = int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", ""));
                        _ctdchd.ThueGTGT_End = int.Parse(txtThueGTGT_End.Text.Trim().Replace(".", ""));
                        _ctdchd.PhiBVMT_End = int.Parse(txtPhiBVMT_End.Text.Trim().Replace(".", ""));
                        _ctdchd.PhiBVMT_Thue_End = int.Parse(txtPhiBVMT_Thue_End.Text.Trim().Replace(".", ""));
                        _ctdchd.TongCong_End = int.Parse(txtTongCong_End.Text.Trim().Replace(".", ""));
                        _ctdchd.ChiTietMoi = txtChiTietMoi.Text.Trim();

                        if (_ctdchd.TienNuoc_End - _ctdchd.TienNuoc_Start == 0)
                            _ctdchd.TangGiam = "";
                        else
                            if (_ctdchd.TienNuoc_End - _ctdchd.TienNuoc_Start > 0)
                                _ctdchd.TangGiam = "Tăng";
                            else
                                _ctdchd.TangGiam = "Giảm";

                        ///Ký Tên
                        //BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        //if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                        //    _ctdchd.ChucVu = "GIÁM ĐỐC";
                        //else
                        //    _ctdchd.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        //_ctdchd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        _ctdchd.PhieuDuocKy = true;

                        _ctdchd.CodeF2 = chkCodeF2.Checked;
                        _ctdchd.BaoCaoThue = chkBaoCaoThue.Checked;

                        if (_cDCBD.SuaDCHD(_ctdchd))
                        {
                            //có khẩu trừ lịch sử
                            if (_cKCN.checkExist_KhauTruLichSu((int)_ctdchd.MaCTDCHD) == true)
                            {
                                DCBD_KhauTru_LichSu enLS = _cKCN.get_KhauTruLichSu((int)_ctdchd.MaCTDCHD);
                                if (_cKCN.checkExist_KhauTru(_ctdchd.DanhBo) == true)//sửa thông tin khấu trừ
                                {
                                    DCBD_KhauTru en = _cKCN.get_KhauTruTon(_ctdchd.DanhBo);
                                    enLS.DanhBo = _ctdchd.DanhBo;
                                    enLS.Ky = _ctdchd.KyHD;
                                    enLS.SoTien = _ctdchd.SoTienKhauTru;
                                    enLS.IDKhauTru = en.ID;
                                    enLS.IDDCHD = (int)_ctdchd.MaCTDCHD;
                                    _cKCN.Sua_KhauTruLichSu(enLS);
                                }
                                else//bỏ khấu trừ
                                {
                                    _cKCN.Xoa_KhauTruLichSu(enLS);
                                }
                            }
                            else //không có thêm mới
                            {
                                if (_cKCN.checkExist_KhauTru(_ctdchd.DanhBo) == true)
                                {
                                    DCBD_KhauTru en = _cKCN.get_KhauTruTon(_ctdchd.DanhBo);
                                    DCBD_KhauTru_LichSu enLS = new DCBD_KhauTru_LichSu();
                                    enLS.DanhBo = en.DanhBo;
                                    enLS.Ky = _ctdchd.KyHD;
                                    enLS.SoTien = _ctdchd.SoTienKhauTru;
                                    enLS.IDKhauTru = en.ID;
                                    enLS.IDDCHD = (int)_ctdchd.MaCTDCHD;
                                    _cKCN.Them_KhauTruLichSu(enLS);
                                }
                            }
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            txtMaDonCu.Focus();
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
            //DataTable dt = _cDCBD.ExecuteQuery_DataTable("select * from ctdchd where thongtin is null");
            //foreach (DataRow item in dt.Rows)
            //{
            //    string ThongTin = "";
            //    if (item["GiaBieu"].ToString() != item["GiaBieu_BD"].ToString())
            //    {
            //        if (string.IsNullOrEmpty(ThongTin) == true)
            //            ThongTin += "GB";
            //        else
            //            ThongTin += ". GB";
            //    }
            //    if (item["DinhMuc"].ToString() != item["DinhMuc_BD"].ToString())
            //    {
            //        if (string.IsNullOrEmpty(ThongTin) == true)
            //            ThongTin += "ĐM";
            //        else
            //            ThongTin += ". ĐM";
            //    }
            //    if (item["TieuThu"].ToString() != item["TieuThu_BD"].ToString())
            //    {
            //        if (string.IsNullOrEmpty(ThongTin) == true)
            //            ThongTin += "Tiêu Thụ";
            //        else
            //            ThongTin += ". Tiêu Thụ";
            //    }
            //    if (bool.Parse(item["DieuChinhGia"].ToString()) == true)
            //        if (string.IsNullOrEmpty(ThongTin) == true)
            //            ThongTin += "Điều Chỉnh Giá";
            //        else
            //            ThongTin += ". Điều Chỉnh Giá";
            //    if (bool.Parse(item["KhauTru"].ToString()) == true)
            //        if (string.IsNullOrEmpty(ThongTin) == true)
            //            ThongTin += "Khấu Trừ";
            //        else
            //            ThongTin += ". Khấu Trừ";
            //    if (bool.Parse(item["DieuChinhGia2"].ToString()) == true)
            //        if (string.IsNullOrEmpty(ThongTin) == true)
            //            ThongTin += "Điều Chỉnh Giá 2";
            //        else
            //            ThongTin += ". Điều Chỉnh Giá 2";
            //    if (bool.Parse(item["TyLe"].ToString()) == true)
            //        if (string.IsNullOrEmpty(ThongTin) == true)
            //            ThongTin += "Tỷ Lệ";
            //        else
            //            ThongTin += ". Tỷ Lệ";
            //    _cDCBD.ExecuteNonQuery("update ctdchd set ThongTin=N'" + ThongTin + "' where MaCTDCHD=" + item["MaCTDCHD"]);
            //}
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (_ctdchd != null && MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        string flagID = _ctdchd.MaCTDCHD.ToString();
                        var transactionOptions = new TransactionOptions();
                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                        {
                            DonTu_LichSu dtls = _cDonTu.get_LichSu("DCBD_ChiTietHoaDon", (int)_ctdchd.MaCTDCHD);
                            if (dtls != null)
                            {
                                _cDonTu.Xoa_LichSu(dtls, true);
                            }
                            if (_cDCBD.XoaDCHD(_ctdchd))
                            {
                                _wsThuongVu.xoa_Folder_Hinh("DCBD_ChiTietHoaDon_Hinh", flagID);
                                scope.Complete();
                                scope.Dispose();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
                            }
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
            try
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();

                if (_ctdchd != null)
                {
                    dr["DanhBo"] = _ctdchd.DanhBo.Insert(7, " ").Insert(4, " "); ;
                    dr["HoTen"] = _ctdchd.HoTen;
                    dr["DiaChi"] = _ctdchd.DiaChi;
                    ///
                    dr["GiaBieuStart"] = _ctdchd.GiaBieu.Value.ToString();
                    dr["DinhMucStart"] = _ctdchd.DinhMuc.Value.ToString();
                    dr["TieuThuStart"] = _ctdchd.TieuThu_BD.Value.ToString();
                    dr["TienNuocStart"] = _ctdchd.ChiTietCu + "\n=  " + _ctdchd.TienNuoc_Start.Value.ToString();
                    dr["ThueGTGTStart"] = _ctdchd.TienNuoc_Start.Value.ToString() + " x 5% \n=  " + _ctdchd.ThueGTGT_Start.Value.ToString();
                    dr["PhiBVMTStart"] = _ctdchd.TienNuoc_Start.Value.ToString() + " x 10% \n=  " + _ctdchd.PhiBVMT_Start.Value.ToString();
                    dr["TongCongStart"] = _ctdchd.TongCong_Start.Value.ToString();
                    ///
                    dr["TangGiam"] = _ctdchd.TangGiam;
                    ///
                    //dr["GiaBieuBD"] = int.Parse(txtGiaBieu_Moi.Text.Trim()) - int.Parse(txtGiaBieu_Cu.Text.Trim());
                    dr["DinhMucBD"] = _ctdchd.DinhMuc_BD.Value - _ctdchd.DinhMuc.Value;
                    dr["TieuThuBD"] = _ctdchd.TieuThu_BD.Value - _ctdchd.TieuThu.Value;
                    dr["TienNuocBD"] = _ctdchd.TienNuoc_BD.Value.ToString();
                    dr["ThueGTGTBD"] = _ctdchd.ThueGTGT_BD.Value.ToString();
                    dr["PhiBVMTBD"] = _ctdchd.PhiBVMT_BD.Value.ToString();
                    dr["TongCongBD"] = _ctdchd.TongCong_BD.Value.ToString(); ;
                    ///
                    dr["GiaBieuEnd"] = _ctdchd.GiaBieu_BD.Value.ToString();
                    dr["DinhMucEnd"] = _ctdchd.DinhMuc_BD.Value.ToString();
                    dr["TieuThuEnd"] = _ctdchd.TieuThu_BD.Value.ToString();
                    //if (!string.IsNullOrEmpty(txtTienNuoc_End.Text.Trim()))
                    dr["TienNuocEnd"] = _ctdchd.ChiTietMoi + "\n=  " + _ctdchd.TienNuoc_End.Value.ToString();
                    //if (!string.IsNullOrEmpty(txtThueGTGT_End.Text.Trim()))
                    dr["ThueGTGTEnd"] = _ctdchd.TienNuoc_End.Value.ToString() + " x 5% \n=  " + _ctdchd.ThueGTGT_End.Value.ToString();
                    //if (!string.IsNullOrEmpty(txtPhiBVMT_End.Text.Trim()))
                    dr["PhiBVMTEnd"] = _ctdchd.TienNuoc_End.Value.ToString() + " x 10% \n=  " + _ctdchd.PhiBVMT_End.Value.ToString();
                    //if (!string.IsNullOrEmpty(txtTongCong_End.Text.Trim()))
                    dr["TongCongEnd"] = _ctdchd.TongCong_End.Value.ToString();
                    ///
                    if (_ctdchd.SH != null)
                        dr["SH"] = "SH: " + _ctdchd.SH.Value.ToString();
                    if (_ctdchd.SX != null)
                        dr["SX"] = "SX: " + _ctdchd.SX.Value.ToString();
                    if (_ctdchd.DV != null)
                        dr["DV"] = "DV: " + _ctdchd.DV.Value.ToString();
                    if (_ctdchd.HCSN != null)
                        dr["HCSN"] = "HCSN: " + _ctdchd.HCSN.Value.ToString();
                }
                else
                {
                    dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " "); ;
                    dr["HoTen"] = txtHoTen.Text.Trim();
                    dr["DiaChi"] = txtDiaChi.Text.Trim();
                    ///
                    dr["GiaBieuStart"] = txtGiaBieu_Cu.Text.Trim();
                    dr["DinhMucStart"] = txtDinhMuc_Cu.Text.Trim();
                    dr["TieuThuStart"] = txtTieuThu_Start.Text.Trim();
                    dr["TienNuocStart"] = txtChiTietCu.Text.Trim() + "\n=  " + txtTienNuoc_Start.Text.Trim();
                    dr["ThueGTGTStart"] = txtTienNuoc_Start.Text.Trim() + " x 5% \n=  " + txtThueGTGT_Start.Text.Trim();
                    dr["PhiBVMTStart"] = txtTienNuoc_Start.Text.Trim() + " x 10% \n=  " + txtPhiBVMT_Start.Text.Trim();
                    dr["TongCongStart"] = txtTongCong_Start.Text.Trim();
                    ///
                    dr["TangGiam"] = lbTangGiam.Text;
                    ///
                    //dr["GiaBieuBD"] = int.Parse(txtGiaBieu_Moi.Text.Trim()) - int.Parse(txtGiaBieu_Cu.Text.Trim());
                    dr["DinhMucBD"] = int.Parse(txtDinhMuc_Moi.Text.Trim()) - int.Parse(txtDinhMuc_Cu.Text.Trim());
                    dr["TieuThuBD"] = txtTieuThu_BD.Text.Trim();
                    dr["TienNuocBD"] = txtTienNuoc_BD.Text.Trim();
                    dr["ThueGTGTBD"] = txtThueGTGT_BD.Text.Trim();
                    dr["PhiBVMTBD"] = txtPhiBVMT_BD.Text.Trim();
                    dr["TongCongBD"] = txtTongCong_BD.Text.Trim();
                    ///
                    dr["GiaBieuEnd"] = txtGiaBieu_Moi.Text.Trim();
                    dr["DinhMucEnd"] = txtDinhMuc_Moi.Text.Trim();
                    dr["TieuThuEnd"] = txtTieuThu_End.Text.Trim();
                    if (!string.IsNullOrEmpty(txtTienNuoc_End.Text.Trim()))
                        dr["TienNuocEnd"] = txtChiTietMoi.Text.Trim() + "\n=  " + txtTienNuoc_End.Text.Trim();
                    if (!string.IsNullOrEmpty(txtThueGTGT_End.Text.Trim()))
                        dr["ThueGTGTEnd"] = txtTienNuoc_End.Text.Trim() + " x 5% \n=  " + txtThueGTGT_End.Text.Trim();
                    if (!string.IsNullOrEmpty(txtPhiBVMT_End.Text.Trim()))
                        dr["PhiBVMTEnd"] = txtTienNuoc_End.Text.Trim() + " x 10% \n=  " + txtPhiBVMT_End.Text.Trim();
                    if (!string.IsNullOrEmpty(txtTongCong_End.Text.Trim()))
                        dr["TongCongEnd"] = txtTongCong_End.Text.Trim();
                    ///
                    if (txtSH.Text.Trim() != "0")
                        dr["SH"] = "SH: " + txtSH.Text.Trim();
                    if (txtSX.Text.Trim() != "0")
                        dr["SX"] = "SX: " + txtSX.Text.Trim();
                    if (txtDV.Text.Trim() != "0")
                        dr["DV"] = "DV: " + txtDV.Text.Trim();
                    if (txtHCSN.Text.Trim() != "0")
                        dr["HCSN"] = "HCSN: " + txtHCSN.Text.Trim();
                }
                dsBaoCao.Tables["DCHD"].Rows.Add(dr);
                rptChiTietDCHD rpt = new rptChiTietDCHD();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInA4_Click(object sender, EventArgs e)
        {
            try
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();

                if (_ctdchd != null)
                {
                    //if (_ctdchd.DCBD.MaDonMoi != null)
                    //    dr["MaDon"] = _ctdchd.DCBD.MaDonMoi.Value.ToString();
                    //else
                    //    if (_ctdchd.DCBD.MaDon != null)
                    //        dr["MaDon"] = "TKH" + _ctdchd.DCBD.MaDon.Value.ToString().Insert(_ctdchd.DCBD.MaDon.Value.ToString().Length - 2, "-");
                    //    else
                    //        if (_ctdchd.DCBD.MaDonTXL != null)
                    //            dr["MaDon"] = "TXL" + _ctdchd.DCBD.MaDonTXL.Value.ToString().Insert(_ctdchd.DCBD.MaDonTXL.Value.ToString().Length - 2, "-");
                    //        else
                    //            if (_ctdchd.DCBD.MaDonTBC != null)
                    //                dr["MaDon"] = "TBC" + _ctdchd.DCBD.MaDonTBC.Value.ToString().Insert(_ctdchd.DCBD.MaDonTBC.Value.ToString().Length - 2, "-");

                    dr["MaDon"] = _ctdchd.MaCTDCHD.ToString().Insert(_ctdchd.MaCTDCHD.ToString().Length - 2, "-");
                    dr["SoPhieu"] = "_________";
                    dr["DanhBo"] = _ctdchd.DanhBo.Insert(7, " ").Insert(4, " ");
                    dr["MLT"] = _ctdchd.MLT.Insert(4, " ").Insert(2, " ");
                    dr["HoTen"] = _ctdchd.HoTen;
                    dr["DiaChi"] = _ctdchd.DiaChi;
                    dr["SoVanBan"] = _ctdchd.SoVB;
                    dr["NgayVanBan"] = _ctdchd.NgayKy.Value.ToString("dd/MM/yyyy");
                    dr["KyHD"] = _ctdchd.KyHD;
                    dr["SoHD"] = _ctdchd.SoHD;
                    ///
                    dr["DieuChinh"] = "";
                    if (_ctdchd.GiaBieu != _ctdchd.GiaBieu_BD)
                        dr["DieuChinh"] = "Giá Biểu từ " + _ctdchd.GiaBieu_BD.Value.ToString() + " -> " + _ctdchd.GiaBieu_BD.Value.ToString();
                    if (_ctdchd.DinhMuc != _ctdchd.DinhMuc_BD)
                        if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                            dr["DieuChinh"] = "Định Mức từ " + _ctdchd.DinhMuc.Value.ToString() + " -> " + _ctdchd.DinhMuc_BD.Value.ToString();
                        else
                            dr["DieuChinh"] = dr["DieuChinh"] + ", Định Mức từ " + _ctdchd.DinhMuc.Value.ToString() + " -> " + _ctdchd.DinhMuc_BD.Value.ToString();
                    if (_ctdchd.TieuThu != _ctdchd.TieuThu_BD)
                        if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                            dr["DieuChinh"] = "Tiêu Thụ từ " + _ctdchd.TieuThu.Value.ToString() + " -> " + _ctdchd.TieuThu_BD.Value.ToString();
                        else
                            dr["DieuChinh"] = dr["DieuChinh"] + ", Tiêu Thụ từ " + _ctdchd.TieuThu.Value.ToString() + " -> " + _ctdchd.TieuThu_BD.Value.ToString();
                    if (_ctdchd.DieuChinhGia == true)
                    {
                        HOADON hd = _cThuTien.Get(_ctdchd.DanhBo, _ctdchd.Ky.Value, _ctdchd.Nam.Value);
                        GiaNuoc2 gn = _cGiaNuoc.getGiaNuoc(hd.TUNGAY.Value, hd.DENNGAY.Value);
                        switch (int.Parse(txtGiaBieu_Moi.Text.Trim()))
                        {
                            case 51:
                            case 52:
                            case 53:
                            case 54:
                            case 59:
                            case 68:
                                if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                                    if (_TieuThu_DieuChinhGia == _ctdchd.TieuThu_BD.Value)
                                        dr["DieuChinh"] = _TieuThu_DieuChinhGia + "m3 Áp giá " + (_ctdchd.GiaDieuChinh - _ctdchd.GiaDieuChinh * _cGiaNuoc.GiamTienNuoc / 100).ToString();
                                    else
                                        dr["DieuChinh"] = _ctdchd.DinhMuc_BD.Value.ToString() + "m3 Áp giá " + (gn.SHTM.Value - gn.SHTM.Value * _cGiaNuoc.GiamTienNuoc / 100).ToString() + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + (_ctdchd.GiaDieuChinh.Value - _ctdchd.GiaDieuChinh.Value * _cGiaNuoc.GiamTienNuoc / 100).ToString();
                                else
                                    if (_TieuThu_DieuChinhGia == int.Parse(txtTieuThu_Moi.Text.Trim()))
                                        dr["DieuChinh"] = dr["DieuChinh"] + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + (_ctdchd.GiaDieuChinh.Value - _ctdchd.GiaDieuChinh.Value * _cGiaNuoc.GiamTienNuoc / 100).ToString();
                                    else
                                        dr["DieuChinh"] = dr["DieuChinh"] + ", " + _ctdchd.DinhMuc_BD.Value.ToString() + "m3 Áp giá " + (gn.SHTM.Value - gn.SHTM.Value * _cGiaNuoc.GiamTienNuoc / 100).ToString() + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + (_ctdchd.GiaDieuChinh.Value - _ctdchd.GiaDieuChinh.Value * _cGiaNuoc.GiamTienNuoc / 100).ToString();
                                break;
                            default:
                                if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                                    if (_TieuThu_DieuChinhGia == _ctdchd.TieuThu_BD.Value)
                                        dr["DieuChinh"] = _TieuThu_DieuChinhGia + "m3 Áp giá " + _ctdchd.GiaDieuChinh.Value.ToString();
                                    else
                                        dr["DieuChinh"] = _ctdchd.DinhMuc_BD.Value.ToString() + "m3 Áp giá " + gn.SHTM.Value + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + _ctdchd.GiaDieuChinh.Value.ToString();
                                else
                                    if (_TieuThu_DieuChinhGia == _ctdchd.TieuThu_BD.Value)
                                        dr["DieuChinh"] = dr["DieuChinh"] + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + _ctdchd.GiaDieuChinh.Value.ToString();
                                    else
                                        dr["DieuChinh"] = dr["DieuChinh"] + ", " + _ctdchd.DinhMuc_BD.Value.ToString() + "m3 Áp giá " + gn.SHTM.Value + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + _ctdchd.GiaDieuChinh.Value.ToString();
                                break;
                        }
                    }
                    if (_ctdchd.TyLe == true)
                    {
                        if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                            dr["DieuChinh"] = "Tỷ lệ";
                        else
                            dr["DieuChinh"] = dr["DieuChinh"] + ", Tỷ lệ";
                        if (_ctdchd.SH != null)
                            dr["DieuChinh"] = dr["DieuChinh"] + " SH: " + _ctdchd.SH.Value.ToString() + "%";
                        if (_ctdchd.SX != null)
                            dr["DieuChinh"] = dr["DieuChinh"] + " SX: " + _ctdchd.SX.Value.ToString() + "%";
                        if (_ctdchd.DV != null)
                            dr["DieuChinh"] = dr["DieuChinh"] + " DV: " + _ctdchd.DV.Value.ToString() + "%";
                        if (_ctdchd.HCSN != null)
                            dr["DieuChinh"] = dr["DieuChinh"] + " HCSN: " + _ctdchd.HCSN.Value.ToString() + "%";
                    }
                    if (_ctdchd.KhuCongNghiep == true)
                    {
                        if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                            dr["DieuChinh"] = "Sản lượng vượt so với Sản lượng Tiêu Thụ Bình Quân (" + Math.Round(_ctdchd.TyLeKhuCongNghiep.Value, 2) + "%)";
                        else
                            dr["DieuChinh"] = dr["DieuChinh"] + ", Sản lượng vượt so với Sản lượng Tiêu Thụ Bình Quân (" + Math.Round(_ctdchd.TyLeKhuCongNghiep.Value, 2) + "%)";
                    }
                    dr["ChiTietCu"] = txtChiTietCu.Text.Trim();
                    dr["ChiTietMoi"] = txtChiTietMoi.Text.Trim();
                    ///
                    dr["GiaBieuStart"] = txtGiaBieu_Cu.Text.Trim();
                    dr["GiaBieuEnd"] = txtGiaBieu_Moi.Text.Trim();
                    dr["DinhMucStart"] = txtDinhMuc_Cu.Text.Trim();
                    dr["DinhMucEnd"] = txtDinhMuc_Moi.Text.Trim();
                    dr["TieuThuStart"] = txtTieuThu_Cu.Text.Trim(); ;
                    if (_ctdchd.TienNuoc_Start.Value == 0)
                        dr["TienNuocStart"] = 0;
                    else
                        dr["TienNuocStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_Start.Value);
                    if (_ctdchd.ThueGTGT_Start.Value == 0)
                        dr["ThueGTGTStart"] = 0;
                    else
                        dr["ThueGTGTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_Start.Value);
                    if (_ctdchd.PhiBVMT_Start.Value == 0)
                        dr["PhiBVMTStart"] = 0;
                    else
                        dr["PhiBVMTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_Start.Value);
                    if (_ctdchd.PhiBVMT_Thue_Start.Value == 0)
                        dr["PhiBVMT_ThueStart"] = 0;
                    else
                        dr["PhiBVMT_ThueStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_Thue_Start.Value);
                    if (_ctdchd.TongCong_Start.Value == 0)
                        dr["TongCongStart"] = 0;
                    else
                        dr["TongCongStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TongCong_Start.Value);
                    ///
                    //if (int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", "")) - int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", "")) == 0)
                    //    dr["TangGiam"] = "";
                    //else
                    //    if (int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", "")) - int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", "")) > 0)
                    //        dr["TangGiam"] = "Tăng";
                    //    else
                    //        dr["TangGiam"] = "Giảm";
                    dr["TangGiam"] = _ctdchd.TangGiam;
                    ///
                    dr["TieuThuBD"] = _ctdchd.TieuThu_BD.Value - _ctdchd.TieuThu.Value;
                    if (_ctdchd.TienNuoc_BD.Value == 0)
                        dr["TienNuocBD"] = 0;
                    else
                        dr["TienNuocBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_BD.Value);
                    if (_ctdchd.ThueGTGT_BD.Value == 0)
                        dr["ThueGTGTBD"] = 0;
                    else
                        dr["ThueGTGTBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_BD.Value);
                    if (_ctdchd.PhiBVMT_BD.Value == 0)
                        dr["PhiBVMTBD"] = 0;
                    else
                        dr["PhiBVMTBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_BD.Value);
                    if (_ctdchd.PhiBVMT_Thue_BD.Value == 0)
                        dr["PhiBVMT_ThueBD"] = 0;
                    else
                        dr["PhiBVMT_ThueBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_Thue_BD.Value);
                    if (_ctdchd.TongCong_BD.Value == 0)
                        dr["TongCongBD"] = 0;
                    else
                        dr["TongCongBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TongCong_BD.Value);
                    ///
                    dr["TieuThuEnd"] = _ctdchd.TieuThu_BD.Value;
                    if (_ctdchd.TienNuoc_End.Value == 0)
                        dr["TienNuocEnd"] = 0;
                    else
                        dr["TienNuocEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_End.Value);
                    if (_ctdchd.ThueGTGT_End.Value == 0)
                        dr["ThueGTGTEnd"] = 0;
                    else
                        dr["ThueGTGTEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_End.Value);
                    if (_ctdchd.PhiBVMT_End.Value == 0)
                        dr["PhiBVMTEnd"] = 0;
                    else
                        dr["PhiBVMTEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_End.Value);
                    if (_ctdchd.PhiBVMT_Thue_End.Value == 0)
                        dr["PhiBVMT_ThueEnd"] = 0;
                    else
                        dr["PhiBVMT_ThueEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_Thue_End.Value);
                    if (_ctdchd.TongCong_End.Value == 0)
                        dr["TongCongEnd"] = 0;
                    else
                        dr["TongCongEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TongCong_End.Value);

                    dr["ChucVu"] = _ctdchd.ChucVu;
                    dr["NguoiKy"] = _ctdchd.NguoiKy;

                    dsBaoCao.Tables["DCHD"].Rows.Add(dr);
                    rptThongBaoDCHD_ChuKy rpt = new rptThongBaoDCHD_ChuKy();
                    rpt.SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.Show();
                }
                else
                {
                    dr["SoPhieu"] = "";
                    dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " ");
                    dr["MLT"] = txtMLT.Text.Trim().Insert(4, " ").Insert(2, " ");
                    dr["HoTen"] = txtHoTen.Text.Trim();
                    dr["DiaChi"] = txtDiaChi.Text.Trim();
                    dr["SoVanBan"] = txtMaDonCu.Text.Trim();
                    dr["NgayVanBan"] = dateNgayKy.Value.ToString("dd/MM/yyyy");
                    dr["KyHD"] = txtKyHD.Text.Trim();
                    dr["SoHD"] = txtSoHD.Text.Trim();
                    ///
                    dr["DieuChinh"] = "";
                    if (txtGiaBieu_Cu.Text.Trim() != txtGiaBieu_Moi.Text.Trim())
                        dr["DieuChinh"] = "Giá Biểu từ " + txtGiaBieu_Cu.Text.Trim() + " -> " + txtGiaBieu_Moi.Text.Trim();
                    if (txtDinhMuc_Cu.Text.Trim() != txtDinhMuc_Moi.Text.Trim())
                        if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                            dr["DieuChinh"] = "Định Mức từ " + txtDinhMuc_Cu.Text.Trim() + " -> " + txtDinhMuc_Moi.Text.Trim();
                        else
                            dr["DieuChinh"] = dr["DieuChinh"] + ", Định Mức từ " + txtDinhMuc_Cu.Text.Trim() + " -> " + txtDinhMuc_Moi.Text.Trim();
                    if (txtTieuThu_Cu.Text.Trim() != txtTieuThu_Moi.Text.Trim())
                        if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                            dr["DieuChinh"] = "Tiêu Thụ từ " + txtTieuThu_Cu.Text.Trim() + " -> " + txtTieuThu_Moi.Text.Trim();
                        else
                            dr["DieuChinh"] = dr["DieuChinh"] + ", Tiêu Thụ từ " + txtTieuThu_Cu.Text.Trim() + " -> " + txtTieuThu_Moi.Text.Trim();
                    if (chkDieuChinhGia.Checked == true)
                    {
                        GiaNuoc2 gn = _cGiaNuoc.getGiaNuoc(DateTime.Now, DateTime.Now);
                        switch (int.Parse(txtGiaBieu_Moi.Text.Trim()))
                        {
                            case 51:
                            case 52:
                            case 53:
                            case 54:
                            case 59:
                            case 68:
                                if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                                    if (_TieuThu_DieuChinhGia == int.Parse(txtTieuThu_Moi.Text.Trim()))
                                        dr["DieuChinh"] = _TieuThu_DieuChinhGia + "m3 Áp giá " + (int.Parse(txtGiaDieuChinh.Text.Trim()) - int.Parse(txtGiaDieuChinh.Text.Trim()) * _cGiaNuoc.GiamTienNuoc / 100).ToString();
                                    else
                                        dr["DieuChinh"] = txtDinhMuc_Moi.Text.Trim() + "m3 Áp giá " + (gn.SHTM.Value - gn.SHTM.Value * _cGiaNuoc.GiamTienNuoc / 100).ToString() + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + (int.Parse(txtGiaDieuChinh.Text.Trim()) - int.Parse(txtGiaDieuChinh.Text.Trim()) * _cGiaNuoc.GiamTienNuoc / 100).ToString();
                                else
                                    if (_TieuThu_DieuChinhGia == int.Parse(txtTieuThu_Moi.Text.Trim()))
                                        dr["DieuChinh"] = dr["DieuChinh"] + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + (int.Parse(txtGiaDieuChinh.Text.Trim()) - int.Parse(txtGiaDieuChinh.Text.Trim()) * _cGiaNuoc.GiamTienNuoc / 100).ToString();
                                    else
                                        dr["DieuChinh"] = dr["DieuChinh"] + ", " + txtDinhMuc_Moi.Text.Trim() + "m3 Áp giá " + (gn.SHTM.Value - gn.SHTM.Value * _cGiaNuoc.GiamTienNuoc / 100).ToString() + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + (int.Parse(txtGiaDieuChinh.Text.Trim()) - int.Parse(txtGiaDieuChinh.Text.Trim()) * _cGiaNuoc.GiamTienNuoc / 100).ToString();
                                break;
                            default:
                                if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                                    if (_TieuThu_DieuChinhGia == int.Parse(txtTieuThu_Moi.Text.Trim()))
                                        dr["DieuChinh"] = _TieuThu_DieuChinhGia + "m3 Áp giá " + txtGiaDieuChinh.Text.Trim();
                                    else
                                        dr["DieuChinh"] = txtDinhMuc_Moi.Text.Trim() + "m3 Áp giá " + gn.SHTM.Value + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + txtGiaDieuChinh.Text.Trim();
                                else
                                    if (_TieuThu_DieuChinhGia == int.Parse(txtTieuThu_Moi.Text.Trim()))
                                        dr["DieuChinh"] = dr["DieuChinh"] + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + txtGiaDieuChinh.Text.Trim();
                                    else
                                        dr["DieuChinh"] = dr["DieuChinh"] + ", " + txtDinhMuc_Moi.Text.Trim() + "m3 Áp giá " + gn.SHTM.Value + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + txtGiaDieuChinh.Text.Trim();
                                break;
                        }
                    }
                    if (chkTyLe.Checked == true)
                    {
                        if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                            dr["DieuChinh"] = "Tỷ lệ";
                        else
                            dr["DieuChinh"] = dr["DieuChinh"] + ", Tỷ lệ";
                        if (txtSH.Text.Trim() != "0")
                            dr["DieuChinh"] = dr["DieuChinh"] + " SH: " + txtSH.Text.Trim() + "%";
                        if (txtSX.Text.Trim() != "0")
                            dr["DieuChinh"] = dr["DieuChinh"] + " SX: " + txtSX.Text.Trim() + "%";
                        if (txtDV.Text.Trim() != "0")
                            dr["DieuChinh"] = dr["DieuChinh"] + " DV: " + txtDV.Text.Trim() + "%";
                        if (txtHCSN.Text.Trim() != "0")
                            dr["DieuChinh"] = dr["DieuChinh"] + " HCSN: " + txtHCSN.Text.Trim() + "%";
                    }
                    if (chkKhuCongNghiep.Checked == true)
                    {
                        if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                            dr["DieuChinh"] = "Sản lượng vượt so với Sản lượng Tiêu Thụ Bình Quân (" + Math.Round(_TyLeKhuCongNghiep, 2) + "%)";
                        else
                            dr["DieuChinh"] = dr["DieuChinh"] + ", Sản lượng vượt so với Sản lượng Tiêu Thụ Bình Quân (" + Math.Round(_TyLeKhuCongNghiep, 2) + "%)";
                    }
                    dr["ChiTietCu"] = txtChiTietCu.Text.Trim();
                    dr["ChiTietMoi"] = txtChiTietMoi.Text.Trim();
                    ///
                    dr["GiaBieuStart"] = txtGiaBieu_Cu.Text.Trim();
                    dr["GiaBieuEnd"] = txtGiaBieu_Moi.Text.Trim();
                    dr["DinhMucStart"] = txtDinhMuc_Cu.Text.Trim();
                    dr["DinhMucEnd"] = txtDinhMuc_Moi.Text.Trim();
                    dr["TieuThuStart"] = txtTieuThu_Cu.Text.Trim(); ;
                    if (txtTienNuoc_Start.Text.Trim() == "0")
                        dr["TienNuocStart"] = "0";
                    else
                        dr["TienNuocStart"] = txtTienNuoc_Start.Text.Trim();
                    if (txtThueGTGT_Start.Text.Trim() == "0")
                        dr["ThueGTGTStart"] = 0;
                    else
                        dr["ThueGTGTStart"] = txtThueGTGT_Start.Text.Trim();
                    if (txtPhiBVMT_Start.Text.Trim() == "0")
                        dr["PhiBVMTStart"] = 0;
                    else
                        dr["PhiBVMTStart"] = txtPhiBVMT_Start.Text.Trim();
                    if (txtPhiBVMT_Thue_Start.Text.Trim() == "0")
                        dr["PhiBVMT_ThueStart"] = 0;
                    else
                        dr["PhiBVMT_ThueStart"] = txtPhiBVMT_Thue_Start.Text.Trim();
                    if (txtTongCong_Start.Text.Trim() == "0")
                        dr["TongCongStart"] = 0;
                    else
                        dr["TongCongStart"] = txtTongCong_Start.Text.Trim();
                    ///
                    if (int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", "")) - int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", "")) == 0)
                        dr["TangGiam"] = "";
                    else
                        if (int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", "")) - int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", "")) > 0)
                            dr["TangGiam"] = "Tăng";
                        else
                            dr["TangGiam"] = "Giảm";
                    ///
                    dr["TieuThuBD"] = int.Parse(txtTieuThu_Moi.Text.Trim().Replace(".", "")) - int.Parse(txtTieuThu_Cu.Text.Trim().Replace(".", ""));
                    if (txtTienNuoc_BD.Text.Trim() == "0")
                        dr["TienNuocBD"] = 0;
                    else
                        dr["TienNuocBD"] = txtTienNuoc_BD.Text.Trim();
                    if (txtThueGTGT_BD.Text.Trim() == "0")
                        dr["ThueGTGTBD"] = 0;
                    else
                        dr["ThueGTGTBD"] = txtThueGTGT_BD.Text.Trim();
                    if (txtPhiBVMT_BD.Text.Trim() == "0")
                        dr["PhiBVMTBD"] = 0;
                    else
                        dr["PhiBVMTBD"] = txtPhiBVMT_BD.Text.Trim();
                    if (txtPhiBVMT_Thue_BD.Text.Trim() == "0")
                        dr["PhiBVMT_ThueBD"] = 0;
                    else
                        dr["PhiBVMT_ThueBD"] = txtPhiBVMT_Thue_BD.Text.Trim();
                    if (txtTongCong_BD.Text.Trim() == "0")
                        dr["TongCongBD"] = 0;
                    else
                        dr["TongCongBD"] = txtTongCong_BD.Text.Trim();
                    ///
                    dr["TieuThuEnd"] = txtTieuThu_Moi.Text.Trim();
                    if (txtTienNuoc_End.Text.Trim() == "0")
                        dr["TienNuocEnd"] = 0;
                    else
                        dr["TienNuocEnd"] = txtTienNuoc_End.Text.Trim();
                    if (txtThueGTGT_End.Text.Trim() == "0")
                        dr["ThueGTGTEnd"] = 0;
                    else
                        dr["ThueGTGTEnd"] = txtThueGTGT_End.Text.Trim();
                    if (txtPhiBVMT_End.Text.Trim() == "0")
                        dr["PhiBVMTEnd"] = 0;
                    else
                        dr["PhiBVMTEnd"] = txtPhiBVMT_End.Text.Trim();
                    if (txtPhiBVMT_Thue_End.Text.Trim() == "0")
                        dr["PhiBVMT_ThueEnd"] = 0;
                    else
                        dr["PhiBVMT_ThueEnd"] = txtPhiBVMT_Thue_End.Text.Trim();
                    if (txtTongCong_End.Text.Trim() == "0")
                        dr["TongCongEnd"] = 0;
                    else
                        dr["TongCongEnd"] = txtTongCong_End.Text.Trim();
                    dsBaoCao.Tables["DCHD"].Rows.Add(dr);
                    rptThongBaoDCHD rpt = new rptThongBaoDCHD();
                    rpt.SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Configure TextBox

        private void txtGiaBieu_Cu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDinhMuc_Cu.Focus();
        }

        private void txtDinhMuc_Cu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDinhMucHN_Cu.Focus();
        }

        private void txtDinhMucHN_Cu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtTieuThu_Cu.Focus();
        }

        private void txtTieuThu_Cu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                chkDieuChinhGia.Focus();
        }

        private void chkGiaDieuChinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGiaDieuChinh.Focus();
        }

        private void txtGiaDieuChinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGiaBieu_Moi.Focus();
        }

        private void txtGiaBieu_Moi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDinhMuc_Moi.Focus();
        }

        private void txtDinhMuc_Moi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDinhMucHN_Moi.Focus();
        }

        private void txtDinhMucHN_Moi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtTieuThu_Moi.Focus();
        }

        private void txtTieuThu_Moi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtLyDoDieuChinh.Focus();
        }

        private void txtLyDoDieuChinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnThem.Focus();
        }

        private void chkCodeF2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                dateNgayKy.Focus();
        }

        private void dateNgayKy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDanhBo.Focus();
        }

        private void txtKyHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtMaToTrinh.Focus();
        }

        private void txtSoHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGiaBieu_Cu.Focus();
        }

        private void txtMaToTrinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGiaBieu_Cu.Focus();
        }

        #endregion

        private void txtGiaBieu_Cu_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaBieu_Cu.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtTieuThu_Cu_TextChanged(object sender, EventArgs e)
        {
            if (txtTieuThu_Cu.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtDinhMucHN_Cu_TextChanged(object sender, EventArgs e)
        {
            if (txtDinhMucHN_Cu.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtDinhMuc_Cu_TextChanged(object sender, EventArgs e)
        {
            if (txtDinhMuc_Cu.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void chkGiaDieuChinh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDieuChinhGia.Checked)
            {
                txtGiaDieuChinh.ReadOnly = false;
            }
            else
            {
                txtGiaDieuChinh.Text = "0";
                txtGiaDieuChinh.ReadOnly = true;
            }
        }

        private void txtGiaDieuChinh_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaDieuChinh.Text.Trim() != "")
            {
                TinhTienNuoc();
            }
        }

        private void txtGiaBieu_Moi_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaBieu_Moi.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtDinhMucHN_Moi_TextChanged(object sender, EventArgs e)
        {
            if (txtDinhMucHN_Moi.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtDinhMuc_Moi_TextChanged(object sender, EventArgs e)
        {
            if (txtDinhMuc_Moi.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtTieuThu_Moi_TextChanged(object sender, EventArgs e)
        {
            if (txtTieuThu_Moi.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void chkKhauTru_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKhauTru.Checked)
            {
                txtSoTienKhauTru.ReadOnly = false;
                //TinhTienNuoc();
            }
            else
            {
                txtSoTienKhauTru.ReadOnly = true;
                txtSoTienKhauTru.Text = "0";
                //txtSoTienKhauTru.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _cKCN.getSoTienKhauTruTon(_hoadon.DANHBA));
                //TinhTienNuoc();
            }
        }

        private void chkGiaDieuChinh2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDieuChinhGia2.Checked)
            {
                chkTyLe.Checked = false;
                txtTieuThu_DieuChinhGia2.ReadOnly = false;
                txtGiaDieuChinh2.ReadOnly = false;
            }
            else
            {
                txtTieuThu_DieuChinhGia2.Text = "0";
                txtTieuThu_DieuChinhGia2.ReadOnly = true;
                txtGiaDieuChinh2.Text = "0";
                txtGiaDieuChinh2.ReadOnly = true;
            }
        }

        private void chkTyLe_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTyLe.Checked)
            {
                chkDieuChinhGia2.Checked = false;
                txtSH.ReadOnly = false;
                txtSX.ReadOnly = false;
                txtDV.ReadOnly = false;
                txtHCSN.ReadOnly = false;
            }
            else
            {
                txtSH.Text = "0";
                txtSH.ReadOnly = true;
                txtSX.Text = "0";
                txtSX.ReadOnly = true;
                txtDV.Text = "0";
                txtDV.ReadOnly = true;
                txtHCSN.Text = "0";
                txtHCSN.ReadOnly = true;
            }
        }

        private void txtTieuThu_GiaDieuChinh2_TextChanged(object sender, EventArgs e)
        {
            if (txtTieuThu_DieuChinhGia2.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtGiaTien_GiaDieuChinh2_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaDieuChinh2.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtSH_TextChanged(object sender, EventArgs e)
        {
            if (txtSH.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtSX_TextChanged(object sender, EventArgs e)
        {
            if (txtSX.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtDV_TextChanged(object sender, EventArgs e)
        {
            if (txtDV.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtHCSN_TextChanged(object sender, EventArgs e)
        {
            if (txtHCSN.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void TinhTienNuoc()
        {
            if (String.IsNullOrEmpty(txtDanhBo.Text.Trim()) || (_hoadon == null && _docso == null))
            {
                return;
            }
            string ChiTietG1Truoc = "", ChiTietG2Truoc = "", ChiTietG1Sau = "", ChiTietG2Sau = "", ChiTietPhiBVMTG1Truoc = "", ChiTietPhiBVMTG2Truoc = "", ChiTietPhiBVMTG1Sau = "", ChiTietPhiBVMTG2Sau = "";
            int Ky = 0, Nam = 0, TyleSH = 0, TyLeSX = 0, TyLeDV = 0, TyLeHCSN = 0, TongTienG1Truoc = 0, TongTienG2Truoc = 0, TienNuocTruoc = 0, ThueGTGTTruoc = 0, TDVTNTruoc = 0, ThueTDVTNTruoc = 0, TongTienG1Sau = 0, TongTienG2Sau = 0, TienNuocSau = 0, ThueGTGTSau = 0, TDVTNSau = 0, ThueTDVTNSau = 0, TieuThu_DieuChinhGia = 0, PhiBVMTG1Truoc = 0, PhiBVMTG2Truoc = 0, PhiBVMTG1Sau = 0, PhiBVMTG2Sau = 0, ThueTDVTN_VAT = 0;
            DateTime TuNgay = new DateTime(), DenNgay = new DateTime();

            if (_hoadon != null)
            {
                Ky = _hoadon.KY;
                Nam = _hoadon.NAM;
                if (_hoadon.TUNGAY != null)
                    TuNgay = _hoadon.TUNGAY.Value;
                else
                {
                    _docso = _cDocSo.get(txtDanhBo.Text.Trim(), Ky, Nam);
                    TuNgay = _docso.TuNgay.Value;
                }
                DenNgay = _hoadon.DENNGAY.Value;
                if (_hoadon.TILESH != null && _hoadon.TILESH.Value != 0)
                    TyleSH = _hoadon.TILESH.Value;
                if (_hoadon.TILESX != null && _hoadon.TILESX.Value != 0)
                    TyLeSX = _hoadon.TILESX.Value;
                if (_hoadon.TILEDV != null && _hoadon.TILEDV.Value != 0)
                    TyLeDV = _hoadon.TILEDV.Value;
                if (_hoadon.TILEHCSN != null && _hoadon.TILEHCSN.Value != 0)
                    TyLeHCSN = _hoadon.TILEHCSN.Value;
            }
            else
                if (_docso != null)
                {
                    Ky = int.Parse(_docso.Ky);
                    Nam = _docso.Nam.Value;
                    TuNgay = _docso.TuNgay.Value;
                    DenNgay = _docso.DenNgay.Value;
                    HOADON hoadon = new HOADON();
                    if (int.Parse(_docso.Ky) == 1)
                        hoadon = _cThuTien.Get(_docso.DanhBa, 12, _docso.Nam.Value - 1);
                    else
                        hoadon = _cThuTien.Get(_docso.DanhBa, int.Parse(_docso.Ky) - 1, _docso.Nam.Value);
                    if (hoadon.TILESH != null && hoadon.TILESH.Value != 0)
                        TyleSH = hoadon.TILESH.Value;
                    if (hoadon.TILESX != null && hoadon.TILESX.Value != 0)
                        TyLeSX = hoadon.TILESX.Value;
                    if (hoadon.TILEDV != null && hoadon.TILEDV.Value != 0)
                        TyLeDV = hoadon.TILEDV.Value;
                    if (hoadon.TILEHCSN != null && hoadon.TILEHCSN.Value != 0)
                        TyLeHCSN = hoadon.TILEHCSN.Value;
                }
            if (_dchdLast != null)
            {
                TongTienG1Truoc = _dchdLast.TienNuoc_End.Value;
                ChiTietG1Truoc = _dchdLast.ChiTietMoi;
                TongTienG2Truoc = 0;
                ChiTietG2Truoc = "";
                TieuThu_DieuChinhGia = 0;
            }
            else
                _cGiaNuoc.TinhTienNuoc(chkKhongApGiaGiam.Checked, chkApGiaNuocCu.Checked, false, int.Parse(txtGiaDieuChinh.Text.Trim().Replace(".", "")), txtDanhBo.Text.Trim(), Ky, Nam, TuNgay, DenNgay, int.Parse(txtGiaBieu_Cu.Text.Trim()), TyleSH, TyLeSX, TyLeDV, TyLeHCSN, int.Parse(txtDinhMuc_Cu.Text.Trim()), int.Parse(txtDinhMucHN_Cu.Text.Trim()), int.Parse(txtTieuThu_Cu.Text.Trim()), out TongTienG1Truoc, out ChiTietG1Truoc, out TongTienG2Truoc, out ChiTietG2Truoc, out TieuThu_DieuChinhGia, out  PhiBVMTG1Truoc, out  ChiTietPhiBVMTG1Truoc, out  PhiBVMTG2Truoc, out ChiTietPhiBVMTG2Truoc, out TienNuocTruoc, out ThueGTGTTruoc, out TDVTNTruoc, out ThueTDVTNTruoc, out ThueTDVTN_VAT);
            if (chkDieuChinhGia2.Checked)
            {
                _cGiaNuoc.TinhTienNuoc2(false, chkApGiaNuocCu.Checked, txtDanhBo.Text.Trim(), Ky, Nam, TuNgay, DenNgay, int.Parse(txtGiaBieu_Moi.Text.Trim()), TyleSH, TyLeSX, TyLeDV, TyLeHCSN, int.Parse(txtDinhMuc_Moi.Text.Trim()), int.Parse(txtDinhMucHN_Moi.Text.Trim()), int.Parse(txtTieuThu_Moi.Text.Trim()) - int.Parse(txtTieuThu_DieuChinhGia2.Text.Trim()), int.Parse(txtTieuThu_DieuChinhGia2.Text.Trim()), int.Parse(txtGiaDieuChinh2.Text.Trim()), out TongTienG1Sau, out ChiTietG1Sau, out TongTienG2Sau, out ChiTietG2Sau, out  PhiBVMTG1Sau, out  ChiTietPhiBVMTG1Sau, out  PhiBVMTG2Sau, out ChiTietPhiBVMTG2Sau, out TienNuocSau, out ThueGTGTSau, out TDVTNSau, out ThueTDVTNSau);
            }
            else
                if (chkDieuChinhGia3.Checked)
                {
                    _cGiaNuoc.TinhTienNuoc3(false, chkApGiaNuocCu.Checked, txtDanhBo.Text.Trim(), Ky, Nam, TuNgay, DenNgay, int.Parse(txtGiaBieu_Moi.Text.Trim()), TyleSH, TyLeSX, TyLeDV, TyLeHCSN, int.Parse(txtDinhMuc_Moi.Text.Trim()), int.Parse(txtDinhMucHN_Moi.Text.Trim()), int.Parse(txtTieuThu_Moi.Text.Trim()), int.Parse(txtTieuThuV1_DieuChinhGia3.Text.Trim()), int.Parse(txtTieuThuV2_DieuChinhGia3.Text.Trim()), out TongTienG1Sau, out ChiTietG1Sau, out TongTienG2Sau, out ChiTietG2Sau, out  PhiBVMTG1Sau, out  ChiTietPhiBVMTG1Sau, out  PhiBVMTG2Sau, out ChiTietPhiBVMTG2Sau, out TienNuocSau, out ThueGTGTSau, out TDVTNSau, out ThueTDVTNSau);
                }
                else
                    if (chkTyLe.Checked)
                    {
                        _cGiaNuoc.TinhTienNuoc(false, chkApGiaNuocCu.Checked, chkDieuChinhGia.Checked, int.Parse(txtGiaDieuChinh.Text.Trim().Replace(".", "")), txtDanhBo.Text.Trim(), Ky, Nam, TuNgay, DenNgay, int.Parse(txtGiaBieu_Moi.Text.Trim()), int.Parse(txtSH.Text.Trim()), int.Parse(txtSX.Text.Trim()), int.Parse(txtDV.Text.Trim()), int.Parse(txtHCSN.Text.Trim()), int.Parse(txtDinhMuc_Moi.Text.Trim()), int.Parse(txtDinhMucHN_Moi.Text.Trim()), int.Parse(txtTieuThu_Moi.Text.Trim()), out TongTienG1Sau, out ChiTietG1Sau, out TongTienG2Sau, out ChiTietG2Sau, out _TieuThu_DieuChinhGia, out  PhiBVMTG1Sau, out  ChiTietPhiBVMTG1Sau, out  PhiBVMTG2Sau, out ChiTietPhiBVMTG2Sau, out TienNuocSau, out ThueGTGTSau, out TDVTNSau, out ThueTDVTNSau, out ThueTDVTN_VAT);
                    }
                    else
                        if (chkKhuCongNghiep.Checked)
                        {
                            _cGiaNuoc.TinhTienNuoc_KhuCongNghiep(false, chkApGiaNuocCu.Checked, txtDanhBo.Text.Trim(), Ky, Nam, TuNgay, DenNgay, int.Parse(txtGiaBieu_Moi.Text.Trim()), int.Parse(txtDinhMuc_Moi.Text.Trim()), int.Parse(txtDinhMucHN_Moi.Text.Trim()), int.Parse(txtTieuThu_Moi.Text.Trim()), out TongTienG1Sau, out ChiTietG1Sau, out TongTienG2Sau, out ChiTietG2Sau, out _TyLeKhuCongNghiep, out  PhiBVMTG1Sau, out  ChiTietPhiBVMTG1Sau, out  PhiBVMTG2Sau, out ChiTietPhiBVMTG2Sau, out TienNuocSau, out ThueGTGTSau, out TDVTNSau, out ThueTDVTNSau);
                        }
                        else
                        {
                            _cGiaNuoc.TinhTienNuoc(false, chkApGiaNuocCu.Checked, chkDieuChinhGia.Checked, int.Parse(txtGiaDieuChinh.Text.Trim().Replace(".", "")), txtDanhBo.Text.Trim(), Ky, Nam, TuNgay, DenNgay, int.Parse(txtGiaBieu_Moi.Text.Trim()), TyleSH, TyLeSX, TyLeDV, TyLeHCSN, int.Parse(txtDinhMuc_Moi.Text.Trim()), int.Parse(txtDinhMucHN_Moi.Text.Trim()), int.Parse(txtTieuThu_Moi.Text.Trim()), out TongTienG1Sau, out ChiTietG1Sau, out TongTienG2Sau, out ChiTietG2Sau, out _TieuThu_DieuChinhGia, out  PhiBVMTG1Sau, out  ChiTietPhiBVMTG1Sau, out  PhiBVMTG2Sau, out ChiTietPhiBVMTG2Sau, out TienNuocSau, out ThueGTGTSau, out TDVTNSau, out ThueTDVTNSau, out ThueTDVTN_VAT);
                        }
            string ChiTietMoiA_HoNgheo = "", ChiTietMoiB_HoNgheo = "";
            int TongTienMoiA_HoNgheo = 0, TongTienMoiB_HoNgheo = 0, TieuThu_DieuChinhGia_HoNgheo = 0;
            if (chkHoNgheo.Checked)
            {
                _cGiaNuoc.TinhTienNuoc_HoNgheo(false, chkApGiaNuocCu.Checked, chkDieuChinhGia.Checked, int.Parse(txtGiaDieuChinh.Text.Trim().Replace(".", "")), txtDanhBo.Text.Trim(), Ky, Nam, TuNgay, DenNgay, int.Parse(txtGiaBieu_Moi.Text.Trim()), TyleSH, TyLeSX, TyLeDV, TyLeHCSN, int.Parse(txtDinhMuc_Moi.Text.Trim()), int.Parse(txtDinhMucHN_Moi.Text.Trim()), int.Parse(txtTieuThu_Moi.Text.Trim()), out TongTienMoiA_HoNgheo, out ChiTietMoiA_HoNgheo, out TongTienMoiB_HoNgheo, out ChiTietMoiB_HoNgheo, out TieuThu_DieuChinhGia_HoNgheo, out  PhiBVMTG1Sau, out  ChiTietPhiBVMTG1Sau, out  PhiBVMTG2Sau, out ChiTietPhiBVMTG2Sau, out TienNuocSau, out ThueGTGTSau, out TDVTNSau, out ThueTDVTNSau);
            }
            ///Chi Tiết
            txtChiTietCu.Text = ChiTietG1Truoc + "\r\n" + ChiTietG2Truoc;
            txtChiTietMoi.Text = ChiTietG1Sau + "\r\n" + ChiTietG2Sau;
            txtChiTietPhiBVMTMoi.Text = ChiTietPhiBVMTG1Sau + "\r\n" + ChiTietPhiBVMTG2Sau;
            ///Tiêu Thụ
            txtTieuThu_Start.Text = txtTieuThu_Cu.Text.Trim();
            txtTieuThu_BD.Text = (int.Parse(txtTieuThu_Moi.Text.Trim()) - int.Parse(txtTieuThu_Cu.Text.Trim())).ToString();
            txtTieuThu_End.Text = txtTieuThu_Moi.Text.Trim();
            //tính theo Công Thức
            if (chkCongThucTinh.Checked == true)
            {
                ///Tiền Nước
                if (TienNuocTruoc != 0)
                    txtTienNuoc_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TienNuocTruoc);
                else
                    txtTienNuoc_Start.Text = "0";

                if (TienNuocSau - TienNuocTruoc != 0)
                    txtTienNuoc_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TienNuocSau - TienNuocTruoc);
                else
                    txtTienNuoc_BD.Text = "0";

                if (TienNuocSau != 0)
                    txtTienNuoc_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TienNuocSau);
                else
                    txtTienNuoc_End.Text = "0";

                ///Thuế GTGT
                if (TienNuocTruoc != 0)
                    txtThueGTGT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ThueGTGTTruoc);
                else
                    txtThueGTGT_Start.Text = "0";

                if (TienNuocSau - TienNuocTruoc != 0)
                    txtThueGTGT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ThueGTGTSau - ThueGTGTTruoc);
                else
                    txtThueGTGT_BD.Text = "0";

                if (TienNuocSau != 0)
                    txtThueGTGT_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ThueGTGTSau);
                else
                    txtThueGTGT_End.Text = "0";

                //Phí BVMT
                if (TienNuocTruoc != 0)
                    txtPhiBVMT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TDVTNTruoc);
                else
                    txtPhiBVMT_Start.Text = "0";

                if (TienNuocSau - TienNuocTruoc != 0)
                    txtPhiBVMT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (TDVTNSau - TDVTNTruoc));
                else
                    txtPhiBVMT_BD.Text = "0";

                if (TienNuocSau != 0)
                    txtPhiBVMT_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TDVTNSau);
                else
                    txtPhiBVMT_End.Text = "0";

                //int ThueGTGTTDVTNTruoc = 0, ThueGTGTTDVTNSau = 0, TongCongSau = 0;
                ////Từ 2022 Phí BVMT -> Tiền Dịch Vụ Thoát Nước
                //if ((_hoadon.TUNGAY.Value.Year < 2021) || (_hoadon.TUNGAY.Value.Year == 2021 && _hoadon.DENNGAY.Value.Year == 2021))
                //{
                //    ThueGTGTTDVTNTruoc = ThueGTGTTDVTNSau = 0;
                //    TongCongSau = (int)((TongTienG1Sau + TongTienG2Sau) + Math.Round((double)(TongTienG1Sau + TongTienG2Sau) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (PhiBVMTG1Sau + PhiBVMTG2Sau));
                //}
                //else
                //    if (_hoadon.TUNGAY.Value.Year == 2021 && _hoadon.DENNGAY.Value.Year == 2022)
                //    {
                //        ThueGTGTTDVTNTruoc = (int)Math.Round((double)(PhiBVMTG2Truoc) * 10 / 100, 0, MidpointRounding.AwayFromZero);
                //        ThueGTGTTDVTNSau = (int)Math.Round((double)(PhiBVMTG2Sau) * 10 / 100, 0, MidpointRounding.AwayFromZero);
                //        TongCongSau = (int)((TongTienG1Sau + TongTienG2Sau) + Math.Round((double)(TongTienG1Sau + TongTienG2Sau) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (PhiBVMTG1Sau + PhiBVMTG2Sau) + ThueGTGTTDVTNSau);
                //    }
                //    else
                //        if (_hoadon.TUNGAY.Value.Year >= 2022)
                //        {
                //            ThueGTGTTDVTNTruoc = (int)Math.Round((double)(PhiBVMTG1Truoc + PhiBVMTG2Truoc) * 10 / 100, 0, MidpointRounding.AwayFromZero);
                //            ThueGTGTTDVTNSau = (int)Math.Round((double)(PhiBVMTG1Sau + PhiBVMTG2Sau) * 10 / 100, 0, MidpointRounding.AwayFromZero);
                //            TongCongSau = (int)((TongTienG1Sau + TongTienG2Sau) + Math.Round((double)(TongTienG1Sau + TongTienG2Sau) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (PhiBVMTG1Sau + PhiBVMTG2Sau) + ThueGTGTTDVTNSau);
                //        }

                ///Phí BVMT Thuế
                if (ThueTDVTNTruoc != 0)
                    txtPhiBVMT_Thue_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ThueTDVTNTruoc);
                else
                    txtPhiBVMT_Thue_Start.Text = "0";

                if (ThueTDVTNSau - ThueTDVTNTruoc != 0)
                    txtPhiBVMT_Thue_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (ThueTDVTNSau - ThueTDVTNTruoc));
                else
                    txtPhiBVMT_Thue_BD.Text = "0";

                if (ThueTDVTNSau != 0)
                    txtPhiBVMT_Thue_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ThueTDVTNSau);
                else
                    txtPhiBVMT_Thue_End.Text = "0";

                ///Tổng Cộng
                if (TienNuocTruoc != 0)
                    txtTongCong_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (TienNuocTruoc + ThueGTGTTruoc + TDVTNTruoc + ThueTDVTNTruoc));
                else
                    txtTongCong_Start.Text = "0";

                if (TienNuocSau - TienNuocTruoc != 0)
                    txtTongCong_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ((TienNuocSau + ThueGTGTSau + TDVTNSau + ThueTDVTNSau) - (TienNuocTruoc + ThueGTGTTruoc + TDVTNTruoc + ThueTDVTNTruoc)));
                else
                    txtTongCong_BD.Text = "0";

                if (TienNuocSau != 0)
                    txtTongCong_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (TienNuocSau + ThueGTGTSau + TDVTNSau + ThueTDVTNSau));
                else
                    txtTongCong_End.Text = "0";

                ///
                if (TienNuocSau - TienNuocTruoc == 0)
                    lbTangGiam.Text = "";
                else
                    if (TienNuocSau - TienNuocTruoc > 0)
                        lbTangGiam.Text = "Tăng:";
                    else
                        lbTangGiam.Text = "Giảm:";
            }//lấy theo số tiền hóa đơn
            else
            {
                ///Tiền Nước
                if (_hoadon.GIABAN.Value != 0)
                    txtTienNuoc_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _hoadon.GIABAN.Value);
                else
                    txtTienNuoc_Start.Text = "0";

                if (TienNuocSau - _hoadon.GIABAN.Value != 0)
                    txtTienNuoc_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TienNuocSau - _hoadon.GIABAN.Value);
                else
                    txtTienNuoc_BD.Text = "0";

                if (TienNuocSau != 0)
                    txtTienNuoc_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TienNuocSau);
                else
                    txtTienNuoc_End.Text = "0";

                ///Thuế GTGT
                if (_hoadon.GIABAN.Value != 0)
                    txtThueGTGT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _hoadon.THUE.Value);
                else
                    txtThueGTGT_Start.Text = "0";

                if (TienNuocSau - _hoadon.GIABAN.Value != 0)
                    txtThueGTGT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ThueGTGTSau - (int)_hoadon.THUE.Value);
                else
                    txtThueGTGT_BD.Text = "0";

                if (TienNuocSau != 0)
                    txtThueGTGT_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ThueGTGTSau);
                else
                    txtThueGTGT_End.Text = "0";

                ///Phí BVMT
                if (_hoadon.GIABAN.Value != 0)
                    txtPhiBVMT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _hoadon.PHI.Value);
                else
                    txtPhiBVMT_Start.Text = "0";

                if (TienNuocSau - _hoadon.GIABAN.Value != 0)
                    txtPhiBVMT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (TDVTNSau - _hoadon.PHI.Value));
                else
                    txtPhiBVMT_BD.Text = "0";

                if (TienNuocSau != 0)
                    txtPhiBVMT_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TDVTNSau);
                else
                    txtPhiBVMT_End.Text = "0";

                //int ThueGTGTTDVTNTruoc = 0, ThueGTGTTDVTNSau = 0, TongCongSau = 0;
                ////Từ 2022 Phí BVMT -> Tiền Dịch Vụ Thoát Nước
                //if ((_hoadon.TUNGAY.Value.Year < 2021) || (_hoadon.TUNGAY.Value.Year == 2021 && _hoadon.DENNGAY.Value.Year == 2021))
                //{
                //    ThueGTGTTDVTNTruoc = ThueGTGTTDVTNSau = 0;
                //    TongCongSau = (int)((TongTienG1Sau + TongTienG2Sau) + Math.Round((double)(TongTienG1Sau + TongTienG2Sau) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (PhiBVMTG1Sau + PhiBVMTG2Sau));
                //}
                //else
                //    if (_hoadon.TUNGAY.Value.Year == 2021 && _hoadon.DENNGAY.Value.Year == 2022)
                //    {
                //        ThueGTGTTDVTNTruoc = (int)_hoadon.ThueGTGT_TDVTN.Value;
                //        ThueGTGTTDVTNSau = (int)Math.Round((double)(PhiBVMTG2Sau) * 10 / 100, 0, MidpointRounding.AwayFromZero);
                //        TongCongSau = (int)((TongTienG1Sau + TongTienG2Sau) + Math.Round((double)(TongTienG1Sau + TongTienG2Sau) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (PhiBVMTG1Sau + PhiBVMTG2Sau) + ThueGTGTTDVTNSau);
                //    }
                //    else
                //        if (_hoadon.TUNGAY.Value.Year >= 2022)
                //        {
                //            ThueGTGTTDVTNTruoc = (int)_hoadon.ThueGTGT_TDVTN.Value;
                //            ThueGTGTTDVTNSau = (int)Math.Round((double)(PhiBVMTG1Sau + PhiBVMTG2Sau) * 10 / 100, 0, MidpointRounding.AwayFromZero);
                //            TongCongSau = (int)((TongTienG1Sau + TongTienG2Sau) + Math.Round((double)(TongTienG1Sau + TongTienG2Sau) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (PhiBVMTG1Sau + PhiBVMTG2Sau) + ThueGTGTTDVTNSau);
                //        }

                ///Phí BVMT Thuế
                if (_hoadon.ThueGTGT_TDVTN != null)
                    txtPhiBVMT_Thue_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _hoadon.ThueGTGT_TDVTN.Value);
                else
                    txtPhiBVMT_Thue_Start.Text = "0";

                if (_hoadon.ThueGTGT_TDVTN != null && ThueTDVTNSau - _hoadon.ThueGTGT_TDVTN.Value != 0)
                    txtPhiBVMT_Thue_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (ThueTDVTNSau - _hoadon.ThueGTGT_TDVTN.Value));
                else
                    txtPhiBVMT_Thue_BD.Text = "0";

                if (_hoadon.ThueGTGT_TDVTN != null && TienNuocSau != 0)
                    txtPhiBVMT_Thue_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ThueTDVTNSau);
                else
                    txtPhiBVMT_Thue_End.Text = "0";

                ///Tổng Cộng
                if (_hoadon.GIABAN.Value != 0)
                    txtTongCong_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _hoadon.TONGCONG.Value);
                else
                    txtTongCong_Start.Text = "0";

                if (TienNuocSau - _hoadon.GIABAN.Value != 0)
                    txtTongCong_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ((TienNuocSau + ThueGTGTSau + TDVTNSau + ThueTDVTNSau) - (int)_hoadon.TONGCONG.Value));
                else
                    txtTongCong_BD.Text = "0";

                if (TienNuocSau != 0)
                    txtTongCong_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (TienNuocSau + ThueGTGTSau + TDVTNSau + ThueTDVTNSau));
                else
                    txtTongCong_End.Text = "0";

                ///
                if (TienNuocSau - _hoadon.GIABAN.Value == 0)
                    lbTangGiam.Text = "";
                else
                    if (TienNuocSau - _hoadon.GIABAN.Value > 0)
                        lbTangGiam.Text = "Tăng:";
                    else
                        lbTangGiam.Text = "Giảm:";
            }

            if (chkHoNgheo.Checked)
            {
                txtTienNuoc_End.Text = (int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", "")) - (TongTienMoiA_HoNgheo + TongTienMoiB_HoNgheo)).ToString();
            }
        }

        public void autoFill()
        {
            if (txtTienNuoc_Start.Text.Trim().Replace(".", "") != "" && txtThueGTGT_Start.Text.Trim().Replace(".", "") != "" && txtPhiBVMT_Start.Text.Trim().Replace(".", "") != "" && txtPhiBVMT_Thue_Start.Text.Trim().Replace(".", "") != "" && txtTongCong_Start.Text.Trim().Replace(".", "") != ""
                && txtTienNuoc_End.Text.Trim().Replace(".", "") != "" && txtThueGTGT_End.Text.Trim().Replace(".", "") != "" && txtPhiBVMT_End.Text.Trim().Replace(".", "") != "" && txtPhiBVMT_Thue_End.Text.Trim().Replace(".", "") != "" && txtTongCong_End.Text.Trim().Replace(".", "") != "")
            {
                if (int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", "")) + int.Parse(txtThueGTGT_Start.Text.Trim().Replace(".", "")) + int.Parse(txtPhiBVMT_Start.Text.Trim().Replace(".", "")) + int.Parse(txtPhiBVMT_Thue_Start.Text.Trim().Replace(".", "")) != 0)
                    txtTongCong_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", "")) + int.Parse(txtThueGTGT_Start.Text.Trim().Replace(".", "")) + int.Parse(txtPhiBVMT_Start.Text.Trim().Replace(".", "")) + int.Parse(txtPhiBVMT_Thue_Start.Text.Trim().Replace(".", ""))));
                else
                    txtTongCong_Start.Text = "0";

                if (int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", "")) + int.Parse(txtThueGTGT_End.Text.Trim().Replace(".", "")) + int.Parse(txtPhiBVMT_End.Text.Trim().Replace(".", "")) + int.Parse(txtPhiBVMT_Thue_End.Text.Trim().Replace(".", "")) != 0)
                    txtTongCong_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", "")) + int.Parse(txtThueGTGT_End.Text.Trim().Replace(".", "")) + int.Parse(txtPhiBVMT_End.Text.Trim().Replace(".", "")) + int.Parse(txtPhiBVMT_Thue_End.Text.Trim().Replace(".", ""))));
                else
                    txtTongCong_End.Text = "0";

                if (int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", "")) - int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", "")) != 0)
                    txtTienNuoc_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", "")) - int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", ""))));
                else
                    txtTienNuoc_BD.Text = "0";

                if (int.Parse(txtThueGTGT_End.Text.Trim().Replace(".", "")) - int.Parse(txtThueGTGT_Start.Text.Trim().Replace(".", "")) != 0)
                    txtThueGTGT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int.Parse(txtThueGTGT_End.Text.Trim().Replace(".", "")) - int.Parse(txtThueGTGT_Start.Text.Trim().Replace(".", ""))));
                else
                    txtThueGTGT_BD.Text = "0";

                if (int.Parse(txtPhiBVMT_End.Text.Trim().Replace(".", "")) - int.Parse(txtPhiBVMT_Start.Text.Trim().Replace(".", "")) != 0)
                    txtPhiBVMT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int.Parse(txtPhiBVMT_End.Text.Trim().Replace(".", "")) - int.Parse(txtPhiBVMT_Start.Text.Trim().Replace(".", ""))));
                else
                    txtPhiBVMT_BD.Text = "0";

                if (int.Parse(txtPhiBVMT_Thue_End.Text.Trim().Replace(".", "")) - int.Parse(txtPhiBVMT_Thue_Start.Text.Trim().Replace(".", "")) != 0)
                    txtPhiBVMT_Thue_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int.Parse(txtPhiBVMT_Thue_End.Text.Trim().Replace(".", "")) - int.Parse(txtPhiBVMT_Thue_Start.Text.Trim().Replace(".", ""))));
                else
                    txtPhiBVMT_Thue_BD.Text = "0";

                if (int.Parse(txtTongCong_End.Text.Trim().Replace(".", "")) - int.Parse(txtTongCong_Start.Text.Trim().Replace(".", "")) != 0)
                    txtTongCong_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int.Parse(txtTongCong_End.Text.Trim().Replace(".", "")) - int.Parse(txtTongCong_Start.Text.Trim().Replace(".", ""))));
                else
                    txtTongCong_BD.Text = "0";
            }
        }

        public void autoFill_End()
        {
            if (txtTienNuoc_Start.Text.Trim().Replace(".", "") != "" && txtThueGTGT_Start.Text.Trim().Replace(".", "") != "" && txtPhiBVMT_Start.Text.Trim().Replace(".", "") != "" && txtPhiBVMT_Thue_Start.Text.Trim().Replace(".", "") != "" && txtTongCong_Start.Text.Trim().Replace(".", "") != ""
                && txtTienNuoc_End.Text.Trim().Replace(".", "") != "" && txtThueGTGT_End.Text.Trim().Replace(".", "") != "" && txtPhiBVMT_End.Text.Trim().Replace(".", "") != "" && txtPhiBVMT_Thue_End.Text.Trim().Replace(".", "") != "" && txtTongCong_End.Text.Trim().Replace(".", "") != "")
            {
                if (int.Parse(txtTongCong_End.Text.Trim().Replace(".", "")) - int.Parse(txtTongCong_Start.Text.Trim().Replace(".", "")) != 0)
                    txtTongCong_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int.Parse(txtTongCong_End.Text.Trim().Replace(".", "")) - int.Parse(txtTongCong_Start.Text.Trim().Replace(".", ""))));
                else
                    txtTongCong_BD.Text = "0";
            }
        }

        private void txtTienNuoc_Start_KeyUp(object sender, KeyEventArgs e)
        {
            autoFill();
        }

        private void txtTongCong_End_KeyUp(object sender, KeyEventArgs e)
        {
            autoFill_End();
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctdchd != null)
                {
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();

                    dr["SoPhieu"] = _ctdchd.MaCTDCHD.ToString().Insert(_ctdchd.MaCTDCHD.ToString().Length - 2, "-");
                    dr["DanhBo"] = _ctdchd.DanhBo.Insert(7, " ").Insert(4, " "); ;
                    dr["HoTen"] = _ctdchd.HoTen;
                    if (_ctdchd.DCBD.MaDonMoi != null)
                    {
                        if (_ctdchd.DCBD.DonTu.DonTu_ChiTiets.Count == 1)
                            dr["SoVanBan"] = _ctdchd.DCBD.MaDonMoi.Value.ToString();
                        else
                            dr["SoVanBan"] = _ctdchd.DCBD.MaDonMoi.Value.ToString() + "." + _ctdchd.STT;
                    }
                    else
                        if (_ctdchd.DCBD.MaDon != null)
                            dr["SoVanBan"] = _ctdchd.DCBD.MaDon.Value.ToString().Insert(_ctdchd.DCBD.MaDon.Value.ToString().Length - 2, "-");
                        else
                            if (_ctdchd.DCBD.MaDonTXL != null)
                                dr["SoVanBan"] = "TXL" + _ctdchd.DCBD.MaDonTXL.Value.ToString().Insert(_ctdchd.DCBD.MaDonTXL.Value.ToString().Length - 2, "-");
                            else
                                if (_ctdchd.DCBD.MaDonTBC != null)
                                    dr["SoVanBan"] = "TBC" + _ctdchd.DCBD.MaDonTBC.Value.ToString().Insert(_ctdchd.DCBD.MaDonTBC.Value.ToString().Length - 2, "-");

                    dr["NgayVanBan"] = _ctdchd.NgayKy.Value.ToString("dd/MM/yyyy");
                    dr["KyHD"] = _ctdchd.KyHD;
                    dr["SoHD"] = _ctdchd.SoHD;
                    ///
                    dr["TieuThuStart"] = _ctdchd.TieuThu;
                    if (_ctdchd.TienNuoc_Start == 0)
                        dr["TienNuocStart"] = 0;
                    else
                        dr["TienNuocStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_Start);
                    if (_ctdchd.ThueGTGT_Start == 0)
                        dr["ThueGTGTStart"] = 0;
                    else
                        dr["ThueGTGTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_Start);
                    if (_ctdchd.PhiBVMT_Start == 0)
                        dr["PhiBVMTStart"] = 0;
                    else
                        dr["PhiBVMTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_Start);
                    if (_ctdchd.TongCong_Start == 0)
                        dr["TongCongStart"] = 0;
                    else
                        dr["TongCongStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TongCong_Start);
                    ///
                    dr["TangGiam"] = _ctdchd.TangGiam;
                    ///
                    dr["TieuThuBD"] = _ctdchd.TieuThu_BD - _ctdchd.TieuThu;
                    if (_ctdchd.TienNuoc_BD == 0)
                        dr["TienNuocBD"] = 0;
                    else
                        dr["TienNuocBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_BD);
                    if (_ctdchd.ThueGTGT_BD == 0)
                        dr["ThueGTGTBD"] = 0;
                    else
                        dr["ThueGTGTBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_BD);
                    if (_ctdchd.PhiBVMT_BD == 0)
                        dr["PhiBVMTBD"] = 0;
                    else
                        dr["PhiBVMTBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_BD);
                    if (_ctdchd.TongCong_BD == 0)
                        dr["TongCongBD"] = 0;
                    else
                        dr["TongCongBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TongCong_BD);
                    ///
                    dr["TieuThuEnd"] = _ctdchd.TieuThu_BD;
                    if (_ctdchd.TienNuoc_End == 0)
                        dr["TienNuocEnd"] = 0;
                    else
                        dr["TienNuocEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TienNuoc_End);
                    if (_ctdchd.ThueGTGT_End == 0)
                        dr["ThueGTGTEnd"] = 0;
                    else
                        dr["ThueGTGTEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.ThueGTGT_End);
                    if (_ctdchd.PhiBVMT_End == 0)
                        dr["PhiBVMTEnd"] = 0;
                    else
                        dr["PhiBVMTEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.PhiBVMT_End);
                    if (_ctdchd.TongCong_End == 0)
                        dr["TongCongEnd"] = 0;
                    else
                        dr["TongCongEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _ctdchd.TongCong_End);

                    dr["ChucVu"] = _ctdchd.ChucVu;
                    dr["NguoiKy"] = _ctdchd.NguoiKy;

                    dsBaoCao.Tables["DCHD"].Rows.Add(dr);

                    rptPhieuDCHD rpt = new rptPhieuDCHD();
                    rpt.SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        bytes = _cDCBD.scanFile(dialog.FileName);
                    else
                        bytes = _cDCBD.scanImage(dialog.FileName);
                    if (_ctdchd == null)
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
                            DCBD_ChiTietHoaDon_Hinh en = new DCBD_ChiTietHoaDon_Hinh();
                            en.IDDCBD_ChiTietHoaDon = _ctdchd.MaCTDCHD;
                            en.Name = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                            en.Loai = System.IO.Path.GetExtension(dialog.FileName);
                            if (_wsThuongVu.ghi_Hinh("DCBD_ChiTietHoaDon_Hinh", en.IDDCBD_ChiTietHoaDon.Value.ToString(), en.Name + en.Loai, bytes) == true)
                                if (_cDCBD.Them_Hinh(en) == true)
                                {
                                    _cDCBD.Refresh();
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
            byte[] file = _wsThuongVu.get_Hinh("DCBD_ChiTietHoaDon_Hinh", _ctdchd.MaCTDCHD.ToString(), dgvHinh.CurrentRow.Cells["Name_Hinh"].Value.ToString() + dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString());
            if (file != null)
                if (dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString().ToLower().Contains("pdf"))
                    _cDCBD.viewPDF(file);
                else
                    _cDCBD.viewImage(file);
            else
                MessageBox.Show("File không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void xoaFile_dgvHinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctdchd == null)
                    dgvHinh.Rows.RemoveAt(dgvHinh.CurrentRow.Index);
                else
                    if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                    {
                        if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (dgvHinh.CurrentRow.Cells["ID_Hinh"].Value != null)
                                if (_wsThuongVu.xoa_Hinh("DCBD_ChiTietHoaDon_Hinh", _ctdchd.MaCTDCHD.ToString(), dgvHinh.CurrentRow.Cells["Name_Hinh"].Value.ToString() + dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString()) == true)
                                    if (_cDCBD.Xoa_Hinh(_cDCBD.get_HoaDon_Hinh(int.Parse(dgvHinh.CurrentRow.Cells["ID_Hinh"].Value.ToString()))))
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

        private void dgvLichSu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLichSu.Columns[e.ColumnIndex].Name == "MaCTDCHD" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvLichSu.Columns[e.ColumnIndex].Name == "TienNuoc_End" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvLichSu.Columns[e.ColumnIndex].Name == "ThueGTGT_End" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvLichSu.Columns[e.ColumnIndex].Name == "PhiBVMT_End" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvLichSu.Columns[e.ColumnIndex].Name == "TongCong_End" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void chkDieuChinhGia3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDieuChinhGia3.Checked)
            {
                txtTieuThuV1_DieuChinhGia3.ReadOnly = false;
                txtTieuThuV2_DieuChinhGia3.ReadOnly = false;
            }
            else
            {
                txtTieuThuV1_DieuChinhGia3.Text = "0";
                txtTieuThuV1_DieuChinhGia3.ReadOnly = true;
                txtTieuThuV2_DieuChinhGia3.Text = "0";
                txtTieuThuV2_DieuChinhGia3.ReadOnly = true;
            }
        }

        private void txtTieuThuV1_DieuChinhGia3_TextChanged(object sender, EventArgs e)
        {
            if (txtTieuThuV1_DieuChinhGia3.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void txtTieuThuV2_DieuChinhGia3_TextChanged(object sender, EventArgs e)
        {
            if (txtTieuThuV2_DieuChinhGia3.Text.Trim() != "")
                TinhTienNuoc();
        }

        private void frmDCHD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Add)
                btnThem.PerformClick();
            if (_dontu_ChiTiet != null && e.Control && e.KeyCode == Keys.T)
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    frmCapNhatDonTu_Thumbnail frm = new frmCapNhatDonTu_Thumbnail(_dontu_ChiTiet, "DCBD_ChiTietHoaDon", (int)_ctdchd.MaCTDCHD);
                    frm.ShowDialog();
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}

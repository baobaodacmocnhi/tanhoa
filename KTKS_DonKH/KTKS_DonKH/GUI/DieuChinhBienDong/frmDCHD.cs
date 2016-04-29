using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.ToXuLy;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDCHD : Form
    {
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        TTKhachHang _ttkhachhang = null;
        Dictionary<string, string> _source = new Dictionary<string, string>();
        CTTKH _cTTKH = new CTTKH();
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDCBD _cDCBD = new CDCBD();
        CKTXM _cKTXM = new CKTXM();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        bool _direct = false;///Mở form trực tiếp không qua Danh Sách Đơn
        int _TieuThu_DieuChinhGia = 0;

        public frmDCHD()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load Form trực tiếp không qua Danh Sách Đơn
        /// </summary>
        /// <param name="direct">true</param>
        public frmDCHD(bool direct)
        {
            InitializeComponent();
            _direct = direct;
        }

        public frmDCHD(Dictionary<string, string> source)
        {
            InitializeComponent();
            _source = source;
        }

        public void Clear()
        {
            txtSoVB.Text = "";
            dateNgayKy.Value = DateTime.Now;
            txtKyHD.Text = "";
            txtSoHD.Text = "";
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            ///
            txtGiaBieu_Cu.Text = "0";
            txtDinhMuc_Cu.Text = "0";
            txtTieuThu_Cu.Text = "0";
            txtChiTietCu.Text = "";
            chkDieuChinhGia.Checked = false;
            ///
            txtGiaBieu_Moi.Text = "0";
            txtDinhMuc_Moi.Text = "0";
            txtTieuThu_Moi.Text = "0";
            txtChiTietMoi.Text = "";
            _donkh = null;
            _dontxl = null;
            _ttkhachhang = null;
            ///
            chkDieuChinhGia2.Checked = false;
            chkTyLe.Checked = false;
        }

        private void frmDCHDN_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            if (_direct)
            {
                this.ControlBox = false;
                this.WindowState = FormWindowState.Maximized;
                this.BringToFront();
                txtMaDon.ReadOnly = false;
            }
            else
            {
                this.Location = new Point(70, 70);
                if (_cDonKH.getDonKHbyID(decimal.Parse(_source["MaDon"])) != null)
                {
                    _donkh = _cDonKH.getDonKHbyID(decimal.Parse(_source["MaDon"]));
                    txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                }
                if (_cTTKH.getTTKHbyID(_source["DanhBo"]) != null)
                {
                    _ttkhachhang = _cTTKH.getTTKHbyID(_source["DanhBo"]);
                    txtDanhBo.Text = _ttkhachhang.DanhBo;
                    txtHoTen.Text = _ttkhachhang.HoTen;
                    txtGiaBieu_Cu.Text = txtGiaBieu_Moi.Text = _ttkhachhang.GB;
                    txtDinhMuc_Cu.Text = txtDinhMuc_Moi.Text = _ttkhachhang.TGDM;
                }
            }
        }

        private void frmDCHDN_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

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
                //TinhTienNuoc();
            }
            else
            {
                txtGiaDieuChinh.Text = "0";
                txtGiaDieuChinh.ReadOnly = true;
                //TinhTienNuoc();
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

        private void TinhTienNuoc()
        {
            string ChiTietCu = "";
            string ChiTietMoi = "";
            int TieuThu_DieuChinhGia = 0;
            int TongTienCu = 0;
            int TongTienMoi = 0;
            TongTienCu = _cGiaNuoc.TinhTienNuoc(false, int.Parse(txtGiaDieuChinh.Text.Trim()), txtDanhBo.Text.Trim(), int.Parse(txtGiaBieu_Cu.Text.Trim()), int.Parse(txtDinhMuc_Cu.Text.Trim()), int.Parse(txtTieuThu_Cu.Text.Trim()), out ChiTietCu, out TieuThu_DieuChinhGia);
            if (chkDieuChinhGia2.Checked)
            {
                TongTienMoi = _cGiaNuoc.TinhTienNuoc(chkDieuChinhGia.Checked, int.Parse(txtGiaDieuChinh.Text.Trim()), txtDanhBo.Text.Trim(), int.Parse(txtGiaBieu_Moi.Text.Trim()), int.Parse(txtDinhMuc_Moi.Text.Trim()), int.Parse(txtTieuThu_Moi.Text.Trim()) - int.Parse(txtTieuThu_DieuChinhGia2.Text.Trim()), int.Parse(txtTieuThu_DieuChinhGia2.Text.Trim()), int.Parse(txtGiaDieuChinh2.Text.Trim()), out ChiTietMoi);
            }
            else
                if (chkTyLe.Checked)
                {
                    TongTienMoi = _cGiaNuoc.TinhTienNuoc(chkDieuChinhGia.Checked, int.Parse(txtGiaDieuChinh.Text.Trim()), txtDanhBo.Text.Trim(), int.Parse(txtGiaBieu_Moi.Text.Trim()), int.Parse(txtDinhMuc_Moi.Text.Trim()), int.Parse(txtTieuThu_Moi.Text.Trim()), int.Parse(txtSH.Text.Trim()), int.Parse(txtSX.Text.Trim()), int.Parse(txtDV.Text.Trim()), int.Parse(txtHCSN.Text.Trim()), out ChiTietMoi);
                }
                else
                {
                    TongTienMoi = _cGiaNuoc.TinhTienNuoc(chkDieuChinhGia.Checked, int.Parse(txtGiaDieuChinh.Text.Trim()), txtDanhBo.Text.Trim(), int.Parse(txtGiaBieu_Moi.Text.Trim()), int.Parse(txtDinhMuc_Moi.Text.Trim()), int.Parse(txtTieuThu_Moi.Text.Trim()), out ChiTietMoi, out _TieuThu_DieuChinhGia);
                }
            ///Chi Tiết
            txtChiTietCu.Text = ChiTietCu;
            txtChiTietMoi.Text = ChiTietMoi;
            ///Tiêu Thụ
            txtTieuThu_Start.Text = txtTieuThu_Cu.Text.Trim();
            txtTieuThu_BD.Text = (int.Parse(txtTieuThu_Moi.Text.Trim()) - int.Parse(txtTieuThu_Cu.Text.Trim())).ToString();
            txtTieuThu_End.Text = txtTieuThu_Moi.Text.Trim();
            ///Tiền Nước
            if (TongTienCu != 0)
                txtTienNuoc_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongTienCu);
            else
                txtTienNuoc_Start.Text = "0";

            if (TongTienMoi - TongTienCu != 0)
                txtTienNuoc_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongTienMoi - TongTienCu);
            else
                txtTienNuoc_BD.Text = "0";

            if (TongTienMoi != 0)
                txtTienNuoc_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongTienMoi);
            else
                txtTienNuoc_End.Text = "0";

            ///Thuế GTGT
            if (TongTienCu != 0)
                txtThueGTGT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", Math.Round((double)TongTienCu * 5 / 100 + 0.1));
            else
                txtThueGTGT_Start.Text = "0";

            if (TongTienMoi - TongTienCu != 0)
                txtThueGTGT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (Math.Round((double)TongTienMoi * 5 / 100 + 0.1) - Math.Round((double)TongTienCu * 5 / 100 + 0.1)));
            else
                txtThueGTGT_BD.Text = "0";

            if (TongTienMoi != 0)
                txtThueGTGT_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", Math.Round((double)TongTienMoi * 5 / 100 + 0.1));
            else
                txtThueGTGT_End.Text = "0";

            ///Phí BVMT
            if (TongTienCu != 0)
                txtPhiBVMT_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (TongTienCu * 10 / 100));
            else
                txtPhiBVMT_Start.Text = "0";

            if (TongTienMoi - TongTienCu != 0)
                txtPhiBVMT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ((TongTienMoi * 10 / 100) - (TongTienCu * 10 / 100)));
            else
                txtPhiBVMT_BD.Text = "0";

            if (TongTienMoi != 0)
                txtPhiBVMT_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (TongTienMoi * 10 / 100));
            else
                txtPhiBVMT_End.Text = "0";

            ///Tổng Cộng
            if (TongTienCu != 0)
                txtTongCong_Start.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (TongTienCu + Math.Round((double)TongTienCu * 5 / 100 + 0.1) + (TongTienCu * 10 / 100)));
            else
                txtTongCong_Start.Text = "0";

            if (TongTienMoi - TongTienCu != 0)
                txtTongCong_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ((TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100 + 0.1) + (TongTienMoi * 10 / 100)) - (TongTienCu + Math.Round((double)TongTienCu * 5 / 100 + 0.1) + (TongTienCu * 10 / 100))));
            else
                txtTongCong_BD.Text = "0";

            if (TongTienMoi != 0)
                txtTongCong_End.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100 + 0.1) + (TongTienMoi * 10 / 100)));
            else
                txtTongCong_End.Text = "0";

            ///
            if (TongTienMoi - TongTienCu == 0)
                lbTangGiam.Text = "";
            else
                if (TongTienMoi - TongTienCu > 0)
                    lbTangGiam.Text = "Tăng:";
                else
                    lbTangGiam.Text = "Giảm:";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ///Nếu đơn thuộc Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_dontxl != null && txtDanhBo.Text.Trim() != "" && txtKyHD.Text.Trim() != "" && txtSoHD.Text.Trim() != "")
                    {
                        if (!_cDCBD.CheckDCBDbyMaDon_TXL(_dontxl.MaDon))
                        {
                            DCBD dcbd = new DCBD();
                            dcbd.ToXuLy = true;
                            dcbd.MaDonTXL = _dontxl.MaDon;
                            if (_direct)
                            {
                                if (!_source.ContainsKey("NoiChuyenDen"))
                                    _source.Add("NoiChuyenDen", "");
                            }
                            else
                            {
                                dcbd.MaNoiChuyenDen = decimal.Parse(_source["MaNoiChuyenDen"]);
                                dcbd.NoiChuyenDen = _source["NoiChuyenDen"];
                                dcbd.LyDoChuyenDen = _source["LyDoChuyenDen"];
                            }
                            if (_cDCBD.ThemDCBD(dcbd))
                            {
                                switch (_source["NoiChuyenDen"])
                                {
                                    case "Khách Hàng":
                                        ///Báo cho bảng DonTXL là đơn này đã được nơi nhận xử lý
                                        DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(_source["MaNoiChuyenDen"]));
                                        dontxl.Nhan = true;
                                        _cDonTXL.SuaDonTXL(dontxl, true);
                                        break;
                                    case "Kiểm Tra Xác Minh":
                                        ///Báo cho bảng KTXM là đơn này đã được nơi nhận xử lý
                                        KTXM ktxm = _cKTXM.getKTXMbyID(decimal.Parse(_source["MaNoiChuyenDen"]));
                                        ktxm.Nhan = true;
                                        _cKTXM.SuaKTXM(ktxm, true);
                                        break;
                                }
                                if (string.IsNullOrEmpty(_dontxl.TienTrinh))
                                    _dontxl.TienTrinh = "DCBD";
                                else
                                    _dontxl.TienTrinh += ",DCBD";
                                _dontxl.Nhan = true;
                                _cDonTXL.SuaDonTXL(_dontxl, true);
                            }
                        }
                        //if (_cDCBD.CheckCTDCHDbyMaDonDanhBo_TXL(_dontxl.MaDon, txtDanhBo.Text.Trim()))
                        //{
                        //    MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Biến Động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return;
                        //}
                        CTDCHD ctdchd = new CTDCHD();
                        ctdchd.MaDCBD = _cDCBD.getDCBDbyMaDon_TXL(_dontxl.MaDon).MaDCBD;
                        ctdchd.DanhBo = txtDanhBo.Text.Trim();
                        ctdchd.HoTen = txtHoTen.Text.Trim();
                        ctdchd.DiaChi = txtDiaChi.Text.Trim();
                        //ctdchd.SoVB = txtSoVB.Text.Trim();
                        ctdchd.NgayKy = dateNgayKy.Value;
                        ctdchd.KyHD = txtKyHD.Text.Trim();
                        ctdchd.SoHD = txtSoHD.Text.Trim();
                        ///
                        ctdchd.GiaBieu = int.Parse(txtGiaBieu_Cu.Text.Trim().Replace(".",""));
                        ctdchd.DinhMuc = int.Parse(txtDinhMuc_Cu.Text.Trim().Replace(".", ""));
                        ctdchd.TieuThu = int.Parse(txtTieuThu_Cu.Text.Trim().Replace(".", ""));
                        ///
                        ctdchd.GiaBieu_BD = int.Parse(txtGiaBieu_Moi.Text.Trim().Replace(".", ""));
                        ctdchd.DinhMuc_BD = int.Parse(txtDinhMuc_Moi.Text.Trim().Replace(".", ""));
                        ctdchd.TieuThu_BD = int.Parse(txtTieuThu_Moi.Text.Trim().Replace(".",""));
                        ///
                        ctdchd.TienNuoc_Start = int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", ""));
                        ctdchd.ThueGTGT_Start = int.Parse(txtThueGTGT_Start.Text.Trim().Replace(".", ""));
                        ctdchd.PhiBVMT_Start = int.Parse(txtPhiBVMT_Start.Text.Trim().Replace(".", ""));
                        ctdchd.TongCong_Start = int.Parse(txtTongCong_Start.Text.Trim().Replace(".", ""));
                        ctdchd.ChiTietCu = txtChiTietCu.Text.Trim();
                        ///
                        if (chkDieuChinhGia.Checked)
                        {
                            ctdchd.DieuChinhGia = true;
                            ctdchd.TieuThu_DieuChinhGia = _TieuThu_DieuChinhGia;
                            ctdchd.GiaDieuChinh = int.Parse(txtGiaDieuChinh.Text.Trim().Replace(".", ""));
                        }
                        ///
                        if (chkKhauTru.Checked)
                        {
                            ctdchd.KhauTru = true;
                            ctdchd.SoTienKhauTru = int.Parse(txtSoTienKhauTru.Text.Trim().Replace(".", ""));
                        }
                        ///
                        if (chkDieuChinhGia2.Checked)
                        {
                            ctdchd.DieuChinhGia2 = true;
                            ctdchd.TieuThu_DieuChinhGia2 = int.Parse(txtTieuThu_DieuChinhGia2.Text.Trim().Replace(".", ""));
                            ctdchd.GiaDieuChinh2 = int.Parse(txtGiaDieuChinh2.Text.Trim().Replace(".", ""));
                        }
                        ///
                        if (chkTyLe.Checked)
                        {
                            ctdchd.TyLe = true;
                            ctdchd.SH = int.Parse(txtSH.Text.Trim().Replace(".", ""));
                            ctdchd.SX = int.Parse(txtSX.Text.Trim().Replace(".", ""));
                            ctdchd.DV = int.Parse(txtDV.Text.Trim().Replace(".", ""));
                            ctdchd.HCSN = int.Parse(txtHCSN.Text.Trim().Replace(".", ""));
                        }
                        ctdchd.TienNuoc_BD = int.Parse(txtTienNuoc_BD.Text.Trim().Replace(".", ""));
                        ctdchd.ThueGTGT_BD = int.Parse(txtThueGTGT_BD.Text.Trim().Replace(".", ""));
                        ctdchd.PhiBVMT_BD = int.Parse(txtPhiBVMT_BD.Text.Trim().Replace(".", ""));
                        ctdchd.TongCong_BD = int.Parse(txtTongCong_BD.Text.Trim().Replace(".", ""));
                        ///
                        ctdchd.TienNuoc_End = int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", ""));
                        ctdchd.ThueGTGT_End = int.Parse(txtThueGTGT_End.Text.Trim().Replace(".", ""));
                        ctdchd.PhiBVMT_End = int.Parse(txtPhiBVMT_End.Text.Trim().Replace(".", ""));
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
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            ctdchd.ChucVu = "GIÁM ĐỐC";
                        else
                            ctdchd.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        ctdchd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        ctdchd.PhieuDuocKy = true;

                        if (_cDCBD.ThemCTDCHD(ctdchd))
                        {
                            MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            txtMaDon.Focus();

                            if (!_direct)
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                    }
                    else
                        MessageBox.Show("Chưa có Mã Đơn/Danh Bộ/Số Văn Bản/Kỳ Hóa Đơn/Số Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ///Nếu đơn thuộc Tổ Khách Hàng
                else
                    if (_donkh != null && txtDanhBo.Text.Trim() != "" && txtKyHD.Text.Trim() != "" && txtSoHD.Text.Trim() != "")
                    {
                        if (!_cDCBD.CheckDCBDbyMaDon(_donkh.MaDon))
                        {
                            DCBD dcbd = new DCBD();
                            dcbd.MaDon = _donkh.MaDon;
                            if (_direct)
                            {
                                ///mới check donkh còn ktxm chưa
                                //string a, b, c;
                                //_cDonKH.GetInfobyMaDon(_donkh.MaDon, "DCBD", out a, out b, out c);
                                //_source.Add("MaNoiChuyenDen", a);
                                if (!_source.ContainsKey("NoiChuyenDen"))
                                    _source.Add("NoiChuyenDen", "");
                                //_source.Add("LyDoChuyenDen", c);
                            }
                            else
                            {
                                dcbd.MaNoiChuyenDen = decimal.Parse(_source["MaNoiChuyenDen"]);
                                dcbd.NoiChuyenDen = _source["NoiChuyenDen"];
                                dcbd.LyDoChuyenDen = _source["LyDoChuyenDen"];
                            }
                            if (_cDCBD.ThemDCBD(dcbd))
                            {
                                switch (_source["NoiChuyenDen"])
                                {
                                    case "Khách Hàng":
                                        ///Báo cho bảng DonKH là đơn này đã được nơi nhận xử lý
                                        DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(_source["MaNoiChuyenDen"]));
                                        donkh.Nhan = true;
                                        _cDonKH.SuaDonKH(donkh, true);
                                        break;
                                    case "Kiểm Tra Xác Minh":
                                        ///Báo cho bảng KTXM là đơn này đã được nơi nhận xử lý
                                        KTXM ktxm = _cKTXM.getKTXMbyID(decimal.Parse(_source["MaNoiChuyenDen"]));
                                        ktxm.Nhan = true;
                                        _cKTXM.SuaKTXM(ktxm, true);
                                        break;
                                }
                                //_source.Add("MaDCBD", _cDCBD.getMaxMaDCBD().ToString());
                                if (string.IsNullOrEmpty(_donkh.TienTrinh))
                                    _donkh.TienTrinh = "DCBD";
                                else
                                    _donkh.TienTrinh += ",DCBD";
                                _donkh.Nhan = true;
                                _cDonKH.SuaDonKH(_donkh, true);
                            }
                        }
                        //if (_cDCBD.CheckCTDCHDbyMaDonDanhBo(_donkh.MaDon, txtDanhBo.Text.Trim()))
                        //{
                        //    MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Biến Động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return;
                        //}
                        CTDCHD ctdchd = new CTDCHD();
                        ctdchd.MaDCBD = _cDCBD.getDCBDbyMaDon(_donkh.MaDon).MaDCBD;
                        ctdchd.DanhBo = txtDanhBo.Text.Trim();
                        ctdchd.HoTen = txtHoTen.Text.Trim();
                        ctdchd.DiaChi = txtDiaChi.Text.Trim();
                        //ctdchd.SoVB = txtSoVB.Text.Trim();
                        ctdchd.NgayKy = dateNgayKy.Value;
                        ctdchd.KyHD = txtKyHD.Text.Trim();
                        ctdchd.SoHD = txtSoHD.Text.Trim();
                        ///
                        ctdchd.GiaBieu = int.Parse(txtGiaBieu_Cu.Text.Trim().Replace(".", ""));
                        ctdchd.DinhMuc = int.Parse(txtDinhMuc_Cu.Text.Trim().Replace(".", ""));
                        ctdchd.TieuThu = int.Parse(txtTieuThu_Cu.Text.Trim().Replace(".", ""));
                        ///
                        ctdchd.GiaBieu_BD = int.Parse(txtGiaBieu_Moi.Text.Trim().Replace(".", ""));
                        ctdchd.DinhMuc_BD = int.Parse(txtDinhMuc_Moi.Text.Trim().Replace(".", ""));
                        ctdchd.TieuThu_BD = int.Parse(txtTieuThu_Moi.Text.Trim().Replace(".", ""));
                        ///
                        ctdchd.TienNuoc_Start = int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", ""));
                        ctdchd.ThueGTGT_Start = int.Parse(txtThueGTGT_Start.Text.Trim().Replace(".", ""));
                        ctdchd.PhiBVMT_Start = int.Parse(txtPhiBVMT_Start.Text.Trim().Replace(".", ""));
                        ctdchd.TongCong_Start = int.Parse(txtTongCong_Start.Text.Trim().Replace(".", ""));
                        ctdchd.ChiTietCu = txtChiTietCu.Text.Trim();
                        ///
                        if (chkDieuChinhGia.Checked)
                        {
                            ctdchd.DieuChinhGia = true;
                            ctdchd.TieuThu_DieuChinhGia = _TieuThu_DieuChinhGia;
                            ctdchd.GiaDieuChinh = int.Parse(txtGiaDieuChinh.Text.Trim().Replace(".", ""));
                        }
                        ///
                        if (chkKhauTru.Checked)
                        {
                            ctdchd.KhauTru = true;
                            ctdchd.SoTienKhauTru = int.Parse(txtSoTienKhauTru.Text.Trim().Replace(".", ""));
                        }
                        ///
                        if (chkDieuChinhGia2.Checked)
                        {
                            ctdchd.DieuChinhGia2 = true;
                            ctdchd.TieuThu_DieuChinhGia2 = int.Parse(txtTieuThu_DieuChinhGia2.Text.Trim().Replace(".", ""));
                            ctdchd.GiaDieuChinh2 = int.Parse(txtGiaDieuChinh2.Text.Trim().Replace(".", ""));
                        }
                        ///
                        if (chkTyLe.Checked)
                        {
                            ctdchd.TyLe = true;
                            ctdchd.SH = int.Parse(txtSH.Text.Trim().Replace(".", ""));
                            ctdchd.SX = int.Parse(txtSX.Text.Trim().Replace(".", ""));
                            ctdchd.DV = int.Parse(txtDV.Text.Trim().Replace(".", ""));
                            ctdchd.HCSN = int.Parse(txtHCSN.Text.Trim().Replace(".", ""));
                        }
                        ///
                        ctdchd.TienNuoc_BD = int.Parse(txtTienNuoc_BD.Text.Trim().Replace(".", ""));
                        ctdchd.ThueGTGT_BD = int.Parse(txtThueGTGT_BD.Text.Trim().Replace(".", ""));
                        ctdchd.PhiBVMT_BD = int.Parse(txtPhiBVMT_BD.Text.Trim().Replace(".", ""));
                        ctdchd.TongCong_BD = int.Parse(txtTongCong_BD.Text.Trim().Replace(".", ""));
                        ///
                        ctdchd.TienNuoc_End = int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", ""));
                        ctdchd.ThueGTGT_End = int.Parse(txtThueGTGT_End.Text.Trim().Replace(".", ""));
                        ctdchd.PhiBVMT_End = int.Parse(txtPhiBVMT_End.Text.Trim().Replace(".", ""));
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
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            ctdchd.ChucVu = "GIÁM ĐỐC";
                        else
                            ctdchd.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        ctdchd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        ctdchd.PhieuDuocKy = true;

                        if (_cDCBD.ThemCTDCHD(ctdchd))
                        {
                            MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                            //DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();

                            //dr["SoPhieu"] = _cDCBD.getMaxMaCTDCHD().ToString().Insert(_cDCBD.getMaxMaCTDCHD().ToString().Length - 2, "-");
                            //dr["DanhBo"] = ctdchd.DanhBo.Insert(7, " ").Insert(4, " ");
                            //dr["HoTen"] = ctdchd.HoTen;
                            //dr["SoDon"] = ctdchd.DCBD.MaDon.Value.ToString().Insert(ctdchd.DCBD.MaDon.Value.ToString().Length - 2, "-");
                            //dr["NgayKy"] = ctdchd.NgayKy.Value.ToString("dd/MM/yyyy");
                            //dr["KyHD"] = ctdchd.KyHD;
                            //dr["SoHD"] = ctdchd.SoHD;
                            /////
                            //dr["TieuThuStart"] = ctdchd.TieuThu;
                            //dr["TienNuocStart"] = ctdchd.TienNuoc_Start;
                            //dr["ThueGTGTStart"] = ctdchd.ThueGTGT_Start;
                            //dr["PhiBVMTStart"] = ctdchd.PhiBVMT_Start;
                            //dr["TongCongStart"] = ctdchd.TongCong_Start;
                            /////
                            //dr["TangGiam"] = ctdchd.TangGiam;
                            /////
                            //dr["TieuThuBD"] = ctdchd.TieuThu_BD - ctdchd.TieuThu;
                            //dr["TienNuocBD"] = ctdchd.TienNuoc_BD;
                            //dr["ThueGTGTBD"] = ctdchd.ThueGTGT_BD;
                            //dr["PhiBVMTBD"] = ctdchd.PhiBVMT_BD;
                            //dr["TongCongBD"] = ctdchd.TongCong_BD;
                            /////
                            //dr["TieuThuEnd"] = ctdchd.TieuThu_BD;
                            //dr["TienNuocEnd"] = ctdchd.TienNuoc_End;
                            //dr["ThueGTGTEnd"] = ctdchd.ThueGTGT_End;
                            //dr["PhiBVMTEnd"] = ctdchd.PhiBVMT_End;
                            //dr["TongCongEnd"] = ctdchd.TongCong_End;

                            //dr["ChucVu"] = ctdchd.ChucVu;
                            //dr["NguoiKy"] = ctdchd.NguoiKy;

                            //dsBaoCao.Tables["DCHD"].Rows.Add(dr);

                            //rptPhieuDCHD rpt = new rptPhieuDCHD();
                            //rpt.SetDataSource(dsBaoCao);
                            //frmBaoCao frm = new frmBaoCao(rpt);
                            //frm.ShowDialog();

                            Clear();
                            txtMaDon.Focus();

                            if (!_direct)
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                    }
                    else
                        MessageBox.Show("Chưa có Mã Đơn/Danh Bộ/Số Văn Bản/Kỳ Hóa Đơn/Số Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                        if (_cTTKH.getTTKHbyID(_dontxl.DanhBo) != null)
                        {
                            _ttkhachhang = _cTTKH.getTTKHbyID(_dontxl.DanhBo);

                            txtDanhBo.Text = _ttkhachhang.DanhBo;
                            txtHoTen.Text = _ttkhachhang.HoTen;
                            txtDiaChi.Text = _ttkhachhang.DC1 + " " + _ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(_ttkhachhang.Quan, _ttkhachhang.Phuong);
                            if (!string.IsNullOrEmpty(_ttkhachhang.GB))
                                txtGiaBieu_Cu.Text = txtGiaBieu_Moi.Text = _ttkhachhang.GB;
                            else
                                txtGiaBieu_Cu.Text = txtGiaBieu_Moi.Text = "0";
                            if (!string.IsNullOrEmpty(_ttkhachhang.TGDM))
                                txtDinhMuc_Cu.Text = txtDinhMuc_Moi.Text = _ttkhachhang.TGDM;
                            else
                                txtDinhMuc_Cu.Text = txtDinhMuc_Moi.Text = "0";
                            dateNgayKy.Focus();
                        }
                        else
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        _dontxl = null;
                        MessageBox.Show("Mã Đơn TXL này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ///Đơn Tổ Khách Hàng
                else
                    if (_cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) != null)
                    {
                        _donkh = _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                        txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                        if (_cTTKH.getTTKHbyID(_donkh.DanhBo) != null)
                        {
                            _ttkhachhang = _cTTKH.getTTKHbyID(_donkh.DanhBo);

                            txtDanhBo.Text = _ttkhachhang.DanhBo;
                            txtHoTen.Text = _ttkhachhang.HoTen;
                            txtDiaChi.Text = _ttkhachhang.DC1 + " " + _ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(_ttkhachhang.Quan, _ttkhachhang.Phuong);
                            if (!string.IsNullOrEmpty(_ttkhachhang.GB))
                                txtGiaBieu_Cu.Text = txtGiaBieu_Moi.Text = _ttkhachhang.GB;
                            else
                                txtGiaBieu_Cu.Text = txtGiaBieu_Moi.Text = "0";
                            if (!string.IsNullOrEmpty(_ttkhachhang.TGDM))
                                txtDinhMuc_Cu.Text = txtDinhMuc_Moi.Text = _ttkhachhang.TGDM;
                            else
                                txtDinhMuc_Cu.Text = txtDinhMuc_Moi.Text = "0";
                            dateNgayKy.Focus();
                        }
                        else
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        _donkh = null;
                        MessageBox.Show("Mã Đơn KH này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

            }
        }

        #region Configure TextBox

        private void txtGiaBieu_Cu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                txtDinhMuc_Cu.Focus();
        }

        private void txtDinhMuc_Cu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                txtTieuThu_Cu.Focus();
        }

        private void txtTieuThu_Cu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
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
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                txtGiaBieu_Moi.Focus();
        }

        private void txtGiaBieu_Moi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                txtDinhMuc_Moi.Focus();
        }

        private void txtDinhMuc_Moi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                txtTieuThu_Moi.Focus();
        }

        private void txtTieuThu_Moi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                btnLuu.Focus();
        }

        private void dateNgayKy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtKyHD.Focus();
        }

        private void txtKyHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtSoHD.Focus();
        }

        private void txtSoHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGiaBieu_Cu.Focus();
        }

        #endregion

        private void frmDCHD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Add)
                btnLuu.PerformClick();
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
                txtSoTienKhauTru.Text = "0";
                txtSoTienKhauTru.ReadOnly = true;
                //TinhTienNuoc();
            }
        }

        private void txtTienNuoc_BD_TextChanged(object sender, EventArgs e)
        {
            if (chkKhauTru.Checked)
                txtTienNuoc_End.Text = (int.Parse(txtTienNuoc_Start.Text.Trim()) + int.Parse(txtTienNuoc_BD.Text.Trim())).ToString();
        }

        private void txtThueGTGT_BD_TextChanged(object sender, EventArgs e)
        {
            if (chkKhauTru.Checked)
                txtThueGTGT_End.Text = (int.Parse(txtThueGTGT_Start.Text.Trim()) + int.Parse(txtThueGTGT_BD.Text.Trim())).ToString();
        }

        private void txtPhiBVMT_BD_TextChanged(object sender, EventArgs e)
        {
            if (chkKhauTru.Checked)
                txtPhiBVMT_End.Text = (int.Parse(txtPhiBVMT_Start.Text.Trim()) + int.Parse(txtPhiBVMT_BD.Text.Trim())).ToString();
        }

        private void txtTongCong_BD_TextChanged(object sender, EventArgs e)
        {
            if (chkKhauTru.Checked)
                txtTongCong_End.Text = (int.Parse(txtTongCong_Start.Text.Trim()) + int.Parse(txtTongCong_BD.Text.Trim())).ToString();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();

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
                    dr["SH"] = "SH: "+txtSH.Text.Trim();
                if (txtSX.Text.Trim() != "0")
                    dr["SX"] = "SX: " + txtSX.Text.Trim();
                if (txtDV.Text.Trim() != "0")
                    dr["DV"] = "DV: " + txtDV.Text.Trim();
                if (txtHCSN.Text.Trim() != "0")
                    dr["HCSN"] = "HCSN: " + txtHCSN.Text.Trim();
                dsBaoCao.Tables["DCHD"].Rows.Add(dr);

                rptChiTietDCHD rpt = new rptChiTietDCHD();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
            catch (Exception)
            {

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

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Length == 11)
            {
                TTKhachHang ttkhachhang = _cTTKH.getTTKHbyID(txtDanhBo.Text.Trim());

                txtDanhBo.Text = ttkhachhang.DanhBo;
                txtHoTen.Text = ttkhachhang.HoTen;
                txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
                if (!string.IsNullOrEmpty(ttkhachhang.GB))
                    txtGiaBieu_Cu.Text = txtGiaBieu_Moi.Text = ttkhachhang.GB;
                else
                    txtGiaBieu_Cu.Text = txtGiaBieu_Moi.Text = "0";
                if (!string.IsNullOrEmpty(ttkhachhang.TGDM))
                    txtDinhMuc_Cu.Text = txtDinhMuc_Moi.Text = ttkhachhang.TGDM;
                else
                    txtDinhMuc_Cu.Text = txtDinhMuc_Moi.Text = "0";
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

        private void txtTongCong_End_TextChanged(object sender, EventArgs e)
        {
            txtTieuThu_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",(int.Parse(txtTieuThu_End.Text.Trim().Replace(".", "")) - int.Parse(txtTieuThu_Start.Text.Trim().Replace(".", ""))));
            txtTienNuoc_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",(int.Parse(txtTienNuoc_End.Text.Trim().Replace(".", "")) - int.Parse(txtTienNuoc_Start.Text.Trim().Replace(".", ""))));
            txtThueGTGT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",(int.Parse(txtThueGTGT_End.Text.Trim().Replace(".", "")) - int.Parse(txtThueGTGT_Start.Text.Trim().Replace(".", ""))));
            txtPhiBVMT_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",(int.Parse(txtPhiBVMT_End.Text.Trim().Replace(".", "")) - int.Parse(txtPhiBVMT_Start.Text.Trim().Replace(".", ""))));
            txtTongCong_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",(int.Parse(txtTongCong_End.Text.Trim().Replace(".", "")) - int.Parse(txtTongCong_Start.Text.Trim().Replace(".", ""))));
        }

        private void btnInA4_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();

            dr["SoPhieu"] = "";
            dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " "); ;
            dr["HoTen"] = txtHoTen.Text.Trim();
            dr["DiaChi"] = txtDiaChi.Text.Trim();
            dr["SoDon"] = txtMaDon.Text.Trim();
            dr["NgayKy"] = dateNgayKy.Value.ToString("dd/MM/yyyy");
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
                if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                    if (_TieuThu_DieuChinhGia == int.Parse(txtTieuThu_Moi.Text.Trim()))
                        dr["DieuChinh"] = _TieuThu_DieuChinhGia + "m3 Áp giá " + txtGiaDieuChinh.Text.Trim();
                    else
                        dr["DieuChinh"] = "Vượt " + txtDinhMuc_Moi.Text.Trim() + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + txtGiaDieuChinh.Text.Trim();
                else
                    if (_TieuThu_DieuChinhGia == int.Parse(txtTieuThu_Moi.Text.Trim()))
                        dr["DieuChinh"] = dr["DieuChinh"] + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + txtGiaDieuChinh.Text.Trim();
                    else
                        dr["DieuChinh"] = dr["DieuChinh"] + ", Vượt " + txtDinhMuc_Moi.Text.Trim() + ", " + _TieuThu_DieuChinhGia + "m3 Áp giá " + txtGiaDieuChinh.Text.Trim();
                dr["ChiTietCu"] = txtChiTietCu.Text.Trim();
                dr["ChiTietMoi"] = txtChiTietMoi.Text.Trim();
            }
            if (chkTyLe.Checked==true)
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
                dr["ChiTietCu"] = txtChiTietCu.Text.Trim();
                dr["ChiTietMoi"] = txtChiTietMoi.Text.Trim();
            }
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
            if (txtTongCong_End.Text.Trim() == "0")
                dr["TongCongEnd"] = 0;
            else
                dr["TongCongEnd"] =txtTongCong_End.Text.Trim();

            //dr["ChucVu"] = ctdchd.ChucVu;
            //dr["NguoiKy"] = ctdchd.NguoiKy;

            dsBaoCao.Tables["DCHD"].Rows.Add(dr);

            rptThongBaoDCHD rpt = new rptThongBaoDCHD();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }



    }
}

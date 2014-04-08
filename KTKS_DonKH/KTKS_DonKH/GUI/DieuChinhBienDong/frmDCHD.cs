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
            chkGiaDieuChinh.Checked = false;
            ///
            txtGiaBieu_Moi.Text = "0";
            txtDinhMuc_Moi.Text = "0";
            txtTieuThu_Moi.Text = "0";
            txtChiTietMoi.Text = "";
            _donkh = null;
            _dontxl = null;
            _ttkhachhang = null;
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
            if (chkGiaDieuChinh.Checked)
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
                TinhTienNuoc();
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
            int TongTienCu = _cGiaNuoc.TinhTienNuoc(false, int.Parse(txtGiaDieuChinh.Text.Trim()), txtDanhBo.Text.Trim(), int.Parse(txtGiaBieu_Cu.Text.Trim()), int.Parse(txtDinhMuc_Cu.Text.Trim()), int.Parse(txtTieuThu_Cu.Text.Trim()), out ChiTietCu);
            int TongTienMoi = _cGiaNuoc.TinhTienNuoc(chkGiaDieuChinh.Checked, int.Parse(txtGiaDieuChinh.Text.Trim()), txtDanhBo.Text.Trim(), int.Parse(txtGiaBieu_Moi.Text.Trim()), int.Parse(txtDinhMuc_Moi.Text.Trim()), int.Parse(txtTieuThu_Moi.Text.Trim()), out ChiTietMoi);
            ///Chi Tiết
            txtChiTietCu.Text = ChiTietCu;
            txtChiTietMoi.Text = ChiTietMoi;
            ///Tiêu Thụ
            txtTieuThu_Start.Text = txtTieuThu_Cu.Text.Trim();
            txtTieuThu_BD.Text = (int.Parse(txtTieuThu_Moi.Text.Trim()) - int.Parse(txtTieuThu_Cu.Text.Trim())).ToString();
            txtTieuThu_End.Text = txtTieuThu_Moi.Text.Trim();
            ///Tiền Nước
            txtTienNuoc_Start.Text = TongTienCu.ToString();
            txtTienNuoc_BD.Text = (TongTienMoi - TongTienCu).ToString();
            txtTienNuoc_End.Text = TongTienMoi.ToString();
            ///Thuế GTGT
            txtThueGTGT_Start.Text = Math.Round((double)TongTienCu * 5 / 100).ToString();
            txtThueGTGT_BD.Text = (Math.Round((double)TongTienMoi * 5 / 100) - Math.Round((double)TongTienCu * 5 / 100)).ToString();
            txtThueGTGT_End.Text = Math.Round((double)TongTienMoi * 5 / 100).ToString();
            ///Phí BVMT
            txtPhiBVMT_Start.Text = (TongTienCu * 10 / 100).ToString();
            txtPhiBVMT_BD.Text = ((TongTienMoi * 10 / 100) - (TongTienCu * 10 / 100)).ToString();
            txtPhiBVMT_End.Text = (TongTienMoi * 10 / 100).ToString();
            ///Tổng Cộng
            txtTongCong_Start.Text = (TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + (TongTienCu * 10 / 100)).ToString();
            txtTongCong_BD.Text = ((TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + (TongTienMoi * 10 / 100)) - (TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + (TongTienCu * 10 / 100))).ToString();
            txtTongCong_End.Text = (TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + (TongTienMoi * 10 / 100)).ToString();

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
                        ctdchd.GiaBieu = int.Parse(txtGiaBieu_Cu.Text.Trim());
                        ctdchd.DinhMuc = int.Parse(txtDinhMuc_Cu.Text.Trim());
                        ctdchd.TieuThu = int.Parse(txtTieuThu_Cu.Text.Trim());
                        ///
                        ctdchd.GiaBieu_BD = int.Parse(txtGiaBieu_Moi.Text.Trim());
                        ctdchd.DinhMuc_BD = int.Parse(txtDinhMuc_Moi.Text.Trim());
                        ctdchd.TieuThu_BD = int.Parse(txtTieuThu_Moi.Text.Trim());
                        ///
                        ctdchd.TienNuoc_Start = int.Parse(txtTienNuoc_Start.Text.Trim());
                        ctdchd.ThueGTGT_Start = int.Parse(txtThueGTGT_Start.Text.Trim());
                        ctdchd.PhiBVMT_Start = int.Parse(txtPhiBVMT_Start.Text.Trim());
                        ctdchd.TongCong_Start = int.Parse(txtTongCong_Start.Text.Trim());
                        ///
                        if (chkGiaDieuChinh.Checked)
                        {
                            ctdchd.DieuChinhGia = true;
                            ctdchd.GiaDieuChinh = int.Parse(txtGiaDieuChinh.Text.Trim());
                        }
                        ///
                        ctdchd.TienNuoc_BD = int.Parse(txtTienNuoc_BD.Text.Trim());
                        ctdchd.ThueGTGT_BD = int.Parse(txtThueGTGT_BD.Text.Trim());
                        ctdchd.PhiBVMT_BD = int.Parse(txtPhiBVMT_BD.Text.Trim());
                        ctdchd.TongCong_BD = int.Parse(txtTongCong_BD.Text.Trim());
                        ///
                        ctdchd.TienNuoc_End = int.Parse(txtTienNuoc_End.Text.Trim());
                        ctdchd.ThueGTGT_End = int.Parse(txtThueGTGT_End.Text.Trim());
                        ctdchd.PhiBVMT_End = int.Parse(txtPhiBVMT_End.Text.Trim());
                        ctdchd.TongCong_End = int.Parse(txtTongCong_End.Text.Trim());

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
                        ctdchd.GiaBieu = int.Parse(txtGiaBieu_Cu.Text.Trim());
                        ctdchd.DinhMuc = int.Parse(txtDinhMuc_Cu.Text.Trim());
                        ctdchd.TieuThu = int.Parse(txtTieuThu_Cu.Text.Trim());
                        ///
                        ctdchd.GiaBieu_BD = int.Parse(txtGiaBieu_Moi.Text.Trim());
                        ctdchd.DinhMuc_BD = int.Parse(txtDinhMuc_Moi.Text.Trim());
                        ctdchd.TieuThu_BD = int.Parse(txtTieuThu_Moi.Text.Trim());
                        ///
                        ctdchd.TienNuoc_Start = int.Parse(txtTienNuoc_Start.Text.Trim());
                        ctdchd.ThueGTGT_Start = int.Parse(txtThueGTGT_Start.Text.Trim());
                        ctdchd.PhiBVMT_Start = int.Parse(txtPhiBVMT_Start.Text.Trim());
                        ctdchd.TongCong_Start = int.Parse(txtTongCong_Start.Text.Trim());
                        ///
                        if (chkGiaDieuChinh.Checked)
                        {
                            ctdchd.DieuChinhGia = true;
                            ctdchd.GiaDieuChinh = int.Parse(txtGiaDieuChinh.Text.Trim());
                        }
                        ///
                        ctdchd.TienNuoc_BD = int.Parse(txtTienNuoc_BD.Text.Trim());
                        ctdchd.ThueGTGT_BD = int.Parse(txtThueGTGT_BD.Text.Trim());
                        ctdchd.PhiBVMT_BD = int.Parse(txtPhiBVMT_BD.Text.Trim());
                        ctdchd.TongCong_BD = int.Parse(txtTongCong_BD.Text.Trim());
                        ///
                        ctdchd.TienNuoc_End = int.Parse(txtTienNuoc_End.Text.Trim());
                        ctdchd.ThueGTGT_End = int.Parse(txtThueGTGT_End.Text.Trim());
                        ctdchd.PhiBVMT_End = int.Parse(txtPhiBVMT_End.Text.Trim());
                        ctdchd.TongCong_End = int.Parse(txtTongCong_End.Text.Trim());

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
                chkGiaDieuChinh.Focus();
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

       

    }
}

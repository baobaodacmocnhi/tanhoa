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
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.DongNuoc;

namespace KTKS_DonKH.GUI.DongNuoc
{
    public partial class frmDongNuoc : Form
    {
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        TTKhachHang _ttkhachhang = null;
        LinQ.DongNuoc _dongnuoc = null;
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CTTKH _cTTKH = new CTTKH();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CDongNuoc _cDongNuoc = new CDongNuoc();


        public frmDongNuoc()
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

        private void frmDongNuoc_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Nhận Entity TTKhachHang để điền vào textbox
        /// </summary>
        /// <param name="ttkhachhang"></param>
        public void LoadTTKH(TTKhachHang ttkhachhang)
        {
            txtDanhBo.Text = ttkhachhang.DanhBo;
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
        }

        public void Clear()
        {
            txtMaThongBao.Text = "";
            ///
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            ///
            txtSoCongVan_DN.Text = "";
            dateCongVan_DN.Value = DateTime.Now;
            txtPhuong_DN.Text = "";
            txtQuan_DN.Text = "";
            ///
            txtSoCongVan_MN.Text = "";
            dateCongVan_MN.Value = DateTime.Now;
            txtPhuong_MN.Text = "";
            txtQuan_MN.Text = "";
            txtLyDoDN.Text = "";
            txtHinhThucDN.Text = "";
            ///
            _ttkhachhang = null;
            _dongnuoc = null;
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
                            LoadTTKH(_ttkhachhang);

                        }
                        else
                        {
                            Clear();
                            MessageBox.Show("Danh Bộ không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        _dontxl = null;
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
                        if (_cTTKH.getTTKHbyID(_donkh.DanhBo) != null)
                        {
                            _ttkhachhang = _cTTKH.getTTKHbyID(_donkh.DanhBo);
                            LoadTTKH(_ttkhachhang);

                        }
                        else
                        {
                            Clear();
                            MessageBox.Show("Danh Bộ không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        _donkh = null;
                        Clear();
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        ///Nếu đơn thuộc Tổ Xử Lý
        //        if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
        //        {
        //            if (_dontxl != null && _ttkhachhang != null && txtSoCongVan_DN.Text.Trim()!="")
        //            {
        //                if (!_cCHDB.CheckCHDBbyMaDon_TXL(_dontxl.MaDon))
        //                {
        //                    CHDB chdb = new CHDB();
        //                    chdb.ToXuLy = true;
        //                    chdb.MaDonTXL = _dontxl.MaDon;
        //                    if (_cCHDB.ThemCHDB(chdb))
        //                    {
        //                        if (string.IsNullOrEmpty(_dontxl.TienTrinh))
        //                            _dontxl.TienTrinh = "CHDB";
        //                        else
        //                            _dontxl.TienTrinh += ",CHDB";
        //                        _dontxl.Nhan = true;
        //                        _cDonTXL.SuaDonTXL(_dontxl, true);
        //                    }
        //                }
        //                if (_cCHDB.CheckCTCHDBbyMaDonDanhBo_TXL(_dontxl.MaDon, txtDanhBo.Text.Trim()))
        //                {
        //                    MessageBox.Show("Danh Bộ này đã được Lập Cắt Hủy Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return;
        //                }
        //                CTCHDB ctchdb = new CTCHDB();
        //                ctchdb.MaCHDB = _cCHDB.getCHDBbyMaDon_TXL(_dontxl.MaDon).MaCHDB;
        //                ctchdb.DanhBo = txtDanhBo.Text.Trim();
        //                ctchdb.HopDong = txtHopDong.Text.Trim();
        //                ctchdb.HoTen = txtHoTen.Text.Trim();
        //                ctchdb.DiaChi = txtDiaChi.Text.Trim();
        //                ctchdb.Dot = _ttkhachhang.Dot;
        //                ctchdb.Ky = _ttkhachhang.Ky;
        //                ctchdb.Nam = _ttkhachhang.Nam;
        //                ctchdb.LyDo = cmbLyDo.SelectedItem.ToString();
        //                ctchdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
        //                if (txtSoTien.Text.Trim() != "")
        //                    ctchdb.SoTien = int.Parse(txtSoTien.Text.Trim());
        //                ///Đã lập Cắt Tạm
        //                if (txtMaThongBaoCT.Text.Trim() != "")
        //                {
        //                    ctchdb.DaLapCatTam = true;
        //                    ctchdb.MaCTCTDB = decimal.Parse(txtMaThongBaoCT.Text.Trim().Replace("-", ""));
        //                }
        //                ///Ký Tên
        //                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
        //                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
        //                    ctchdb.ChucVu = "GIÁM ĐỐC";
        //                else
        //                    ctchdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
        //                ctchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
        //                ctchdb.ThongBaoDuocKy = true;

        //                if (_cCHDB.ThemCTCHDB(ctchdb))
        //                {
        //                    MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //                    Clear();

        //                    if (!_direct)
        //                    {
        //                        this.DialogResult = DialogResult.OK;
        //                        this.Close();
        //                    }
        //                }
        //            }
        //            else
        //                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnCapNhatMoNuoc_Click(object sender, EventArgs e)
        {

        }

        private void btnInTBDN_Click(object sender, EventArgs e)
        {

        }

        private void btnInTBMN_Click(object sender, EventArgs e)
        {

        }
    }
}

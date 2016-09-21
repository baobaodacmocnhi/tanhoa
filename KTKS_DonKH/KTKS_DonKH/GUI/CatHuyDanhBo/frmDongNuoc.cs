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
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DongNuoc;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.BamChi;

namespace KTKS_DonKH.GUI.DongNuoc
{
    public partial class frmDongNuoc : Form
    {
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        TTKhachHang _ttkhachhang = null;
        CTDongNuoc _ctdongnuoc = null;
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CTTKH _cTTKH = new CTTKH();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CBamChi _cBamChi = new CBamChi();

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
            dgvDSBamChi.AutoGenerateColumns = false;
            dgvDSBamChi.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSBamChi.Font, FontStyle.Bold);
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
            txtDiaChiDHN.Text = txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
        }

        public void Clear()
        {
            txtMaThongBao_DN.Text = "";
            ///
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtDiaChiDHN.Text = "";
            ///
            dateDongNuoc.Value = DateTime.Now;
            txtSoCongVan_DN.Text = "";
            dateCongVan_DN.Value = DateTime.Now;
            txtPhuong_DN.Text = "";
            txtQuan_DN.Text = "";
            ///
            dateMoNuoc.Value = DateTime.Now;
            txtSoCongVan_MN.Text = "";
            dateCongVan_MN.Value = DateTime.Now;
            txtPhuong_MN.Text = "";
            txtQuan_MN.Text = "";
            txtLyDoDN.Text = "";
            txtHinhThucDN.Text = "";
            ///
            _ttkhachhang = null;
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
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                ///Nếu đơn thuộc Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if ((_dontxl != null || _ctdongnuoc != null) && txtSoCongVan_DN.Text.Trim() != "")
                    {
                        if (!_cDongNuoc.CheckDongNuocbyMaDon_TXL(_dontxl.MaDon))
                        {
                            LinQ.DongNuoc dongnuoc = new LinQ.DongNuoc();
                            dongnuoc.ToXuLy = true;
                            dongnuoc.MaDonTXL = _dontxl.MaDon;
                            if (_cDongNuoc.ThemDongNuoc(dongnuoc))
                            {
                                if (string.IsNullOrEmpty(_dontxl.TienTrinh))
                                    _dontxl.TienTrinh = "DongNuoc";
                                else
                                    _dontxl.TienTrinh += ",DongNuoc";
                                _dontxl.Nhan = true;
                                _cDonTXL.SuaDonTXL(_dontxl, true);
                            }
                        }
                        if (_cDongNuoc.CheckCTDongNuocbyMaDonDanhBo_TXL(_dontxl.MaDon, txtDanhBo.Text.Trim()))
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Cắt Hủy Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        CTDongNuoc ctdongnuoc = new CTDongNuoc();
                        ctdongnuoc.MaDN = _cDongNuoc.getDongNuocbyMaDon_TXL(_dontxl.MaDon).MaDN;
                        ctdongnuoc.DanhBo = txtDanhBo.Text.Trim();
                        ctdongnuoc.HopDong = txtHopDong.Text.Trim();
                        ctdongnuoc.HoTen = txtHoTen.Text.Trim();
                        ctdongnuoc.DiaChi = txtDiaChi.Text.Trim();
                        if (_ttkhachhang != null)
                        {
                            ctdongnuoc.Dot = _ttkhachhang.Dot;
                            ctdongnuoc.Ky = _ttkhachhang.Ky;
                            ctdongnuoc.Nam = _ttkhachhang.Nam;
                        }
                        ctdongnuoc.DiaChiDHN = txtDiaChiDHN.Text.Trim();
                        ctdongnuoc.NgayDN = dateDongNuoc.Value;
                        ctdongnuoc.SoCongVan_DN = txtSoCongVan_DN.Text.Trim();
                        ctdongnuoc.NgayCongVan_DN = dateCongVan_DN.Value;
                        ctdongnuoc.Phuong = txtPhuong_DN.Text.Trim();
                        ctdongnuoc.Quan = txtQuan_DN.Text.Trim();
                        ///Ký Tên
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            ctdongnuoc.ChucVu_DN = "GIÁM ĐỐC";
                        else
                            ctdongnuoc.ChucVu_DN = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        ctdongnuoc.NguoiKy_DN = bangiamdoc.HoTen.ToUpper();
                        ctdongnuoc.ThongBaoDuocKy_DN = true;

                        if (_cDongNuoc.ThemCTDongNuoc(ctdongnuoc))
                        {
                            MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                    else
                        MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ///Nếu đơn thuộc Tổ Khách Hàng
                else
                    if ((_donkh != null || _ctdongnuoc != null) && txtSoCongVan_DN.Text.Trim() != "")
                    {
                        if (!_cDongNuoc.CheckDongNuocbyMaDon(_donkh.MaDon))
                        {
                            LinQ.DongNuoc dongnuoc = new LinQ.DongNuoc();
                            dongnuoc.MaDon = _donkh.MaDon;
                            if (_cDongNuoc.ThemDongNuoc(dongnuoc))
                            {
                                if (string.IsNullOrEmpty(_donkh.TienTrinh))
                                    _donkh.TienTrinh = "DongNuoc";
                                else
                                    _donkh.TienTrinh += ",DongNuoc";
                                _donkh.Nhan = true;
                                _cDonKH.SuaDonKH(_donkh, true);
                            }
                        }
                        if (_cDongNuoc.CheckCTDongNuocbyMaDonDanhBo(_donkh.MaDon, txtDanhBo.Text.Trim()))
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Cắt Hủy Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        CTDongNuoc ctdongnuoc = new CTDongNuoc();
                        ctdongnuoc.MaDN = _cDongNuoc.getDongNuocbyMaDon(_donkh.MaDon).MaDN;
                        ctdongnuoc.DanhBo = txtDanhBo.Text.Trim();
                        ctdongnuoc.HopDong = txtHopDong.Text.Trim();
                        ctdongnuoc.HoTen = txtHoTen.Text.Trim();
                        ctdongnuoc.DiaChi = txtDiaChi.Text.Trim();
                        if (_ttkhachhang != null)
                        {
                            ctdongnuoc.Dot = _ttkhachhang.Dot;
                            ctdongnuoc.Ky = _ttkhachhang.Ky;
                            ctdongnuoc.Nam = _ttkhachhang.Nam;
                        }
                        ctdongnuoc.DiaChiDHN = txtDiaChiDHN.Text.Trim();
                        ctdongnuoc.NgayDN = dateDongNuoc.Value;
                        ctdongnuoc.SoCongVan_DN = txtSoCongVan_DN.Text.Trim();
                        ctdongnuoc.NgayCongVan_DN = dateCongVan_DN.Value;
                        ctdongnuoc.Phuong = txtPhuong_DN.Text.Trim();
                        ctdongnuoc.Quan = txtQuan_DN.Text.Trim();
                        ///Ký Tên
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            ctdongnuoc.ChucVu_DN = "GIÁM ĐỐC";
                        else
                            ctdongnuoc.ChucVu_DN = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        ctdongnuoc.NguoiKy_DN = bangiamdoc.HoTen.ToUpper();
                        ctdongnuoc.ThongBaoDuocKy_DN = true;

                        if (_cDongNuoc.ThemCTDongNuoc(ctdongnuoc))
                        {
                            MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                    else
                        MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (_ctdongnuoc != null)
                {
                    if (txtMaThongBao_DN.Text.Trim().Replace("-", "") != "")
                        _ctdongnuoc.MaCTDN = decimal.Parse(txtMaThongBao_DN.Text.Trim().Replace("-", ""));

                    _ctdongnuoc.DanhBo = txtDanhBo.Text.Trim();
                    _ctdongnuoc.HopDong = txtHopDong.Text.Trim();
                    _ctdongnuoc.HoTen = txtHoTen.Text.Trim();
                    _ctdongnuoc.DiaChi = txtDiaChi.Text.Trim();
                    if (_ttkhachhang != null)
                    {
                        _ctdongnuoc.Dot = _ttkhachhang.Dot;
                        _ctdongnuoc.Ky = _ttkhachhang.Ky;
                        _ctdongnuoc.Nam = _ttkhachhang.Nam;
                    }

                    _ctdongnuoc.DiaChiDHN = txtDiaChiDHN.Text.Trim();
                    _ctdongnuoc.NgayDN = dateDongNuoc.Value;
                    _ctdongnuoc.SoCongVan_DN = txtSoCongVan_DN.Text.Trim();
                    _ctdongnuoc.NgayCongVan_DN = dateCongVan_DN.Value;
                    _ctdongnuoc.Phuong = txtPhuong_DN.Text.Trim();
                    _ctdongnuoc.Quan = txtQuan_DN.Text.Trim();

                    if (_ctdongnuoc.MoNuoc)
                    {
                        _ctdongnuoc.NgayMN = dateMoNuoc.Value;
                        _ctdongnuoc.SoCongVan_MN = txtSoCongVan_MN.Text.Trim();
                        _ctdongnuoc.NgayCongVan_MN = dateCongVan_MN.Value;
                        _ctdongnuoc.LyDo_DN = txtLyDoDN.Text.Trim();
                        _ctdongnuoc.HinhThuc_DN = txtHinhThucDN.Text.Trim();
                    }

                    if (_cDongNuoc.SuaCTDongNuoc(_ctdongnuoc))
                    {
                        MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhatMoNuoc_Click(object sender, EventArgs e)
        {
            if (_ctdongnuoc != null && _ctdongnuoc.MoNuoc == false&&txtSoCongVan_MN.Text.Trim()!="")
            {
                if (txtMaThongBao_DN.Text.Trim().Replace("-", "") != "")
                    _ctdongnuoc.MaCTDN = decimal.Parse(txtMaThongBao_DN.Text.Trim().Replace("-", ""));

                _ctdongnuoc.MoNuoc = true;
                _ctdongnuoc.MaCTMN = _cDongNuoc.getMaxNextMaCTMN();
                _ctdongnuoc.NgayMN = dateMoNuoc.Value;
                _ctdongnuoc.SoCongVan_MN = txtSoCongVan_MN.Text.Trim();
                _ctdongnuoc.NgayCongVan_MN = dateCongVan_MN.Value;
                _ctdongnuoc.LyDo_DN = txtLyDoDN.Text.Trim();
                _ctdongnuoc.HinhThuc_DN = txtHinhThucDN.Text.Trim();
                
                ///Ký Tên
                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                    _ctdongnuoc.ChucVu_MN = "GIÁM ĐỐC";
                else
                    _ctdongnuoc.ChucVu_MN = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                _ctdongnuoc.NguoiKy_MN = bangiamdoc.HoTen.ToUpper();
                _ctdongnuoc.ThongBaoDuocKy_MN = true;

                if (_cDongNuoc.SuaCTDongNuoc(_ctdongnuoc))
                {
                    MessageBox.Show("Cập Nhật Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
            }
        }

        private void btnInTBDN_Click(object sender, EventArgs e)
        {
            if (_ctdongnuoc != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThongBaoDongNuoc"].NewRow();

                dr["SoPhieu"] = _ctdongnuoc.MaCTDN.ToString().Insert(_ctdongnuoc.MaCTDN.ToString().Length - 2, "-");
                dr["HoTen"] = _ctdongnuoc.HoTen;
                dr["DiaChi"] = _ctdongnuoc.DiaChi;
                dr["DanhBo"] = _ctdongnuoc.DanhBo;
                dr["HopDong"] = _ctdongnuoc.HopDong;
                dr["DiaChiDHN"] = _ctdongnuoc.DiaChiDHN;
                ///
                dr["NgayXuLy"] = _ctdongnuoc.NgayDN.Value.ToString("dd/MM/yyyy");
                dr["SoCongVan"] = _ctdongnuoc.SoCongVan_DN;
                dr["NgayCongVan"] = _ctdongnuoc.NgayCongVan_DN.Value.ToString("dd/MM/yyyy");
                dr["Phuong"] = _ctdongnuoc.Phuong;
                dr["Quan"] = _ctdongnuoc.Quan;
                ///
                dr["ChucVu"] = _ctdongnuoc.ChucVu_DN;
                dr["NguoiKy"] = _ctdongnuoc.NguoiKy_DN;

                dsBaoCao.Tables["ThongBaoDongNuoc"].Rows.Add(dr);

                rptThongBaoDN rpt = new rptThongBaoDN();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Chưa có Thông Báo Đóng Nước", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInTBMN_Click(object sender, EventArgs e)
        {
            if (_ctdongnuoc != null && _ctdongnuoc.MoNuoc == true)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThongBaoDongNuoc"].NewRow();

                dr["SoPhieu"] = _ctdongnuoc.MaCTMN.ToString().Insert(_ctdongnuoc.MaCTMN.ToString().Length - 2, "-");
                dr["HoTen"] = _ctdongnuoc.HoTen;
                dr["DiaChi"] = _ctdongnuoc.DiaChi;
                dr["DanhBo"] = _ctdongnuoc.DanhBo;
                dr["HopDong"] = _ctdongnuoc.HopDong;
                dr["DiaChiDHN"] = _ctdongnuoc.DiaChiDHN;
                ///
                dr["NgayXuLy"] = _ctdongnuoc.NgayMN.Value.ToString("dd/MM/yyyy");
                dr["SoCongVan"] = _ctdongnuoc.SoCongVan_MN;
                dr["NgayCongVan"] = _ctdongnuoc.NgayCongVan_MN.Value.ToString("dd/MM/yyyy");
                dr["Phuong"] = _ctdongnuoc.Phuong;
                dr["Quan"] = _ctdongnuoc.Quan;
                dr["LyDo"] = _ctdongnuoc.LyDo_DN;
                dr["HinhThuc"] = _ctdongnuoc.HinhThuc_DN;
                dr["SoPhieuDN"] = _ctdongnuoc.MaCTDN.ToString().Insert(_ctdongnuoc.MaCTDN.ToString().Length - 2, "-");
                ///
                dr["ChucVu"] = _ctdongnuoc.ChucVu_MN;
                dr["NguoiKy"] = _ctdongnuoc.NguoiKy_MN;

                dsBaoCao.Tables["ThongBaoDongNuoc"].Rows.Add(dr);

                rptThongBaoMN rpt = new rptThongBaoMN();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Chưa có Thông Báo Đóng Nước/Nội Dung Mở Nước", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtMaThongBao_DN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cDongNuoc.getCTDongNuocbyID(decimal.Parse(txtMaThongBao_DN.Text.Trim().Replace("-", ""))) != null)
                {
                    _ctdongnuoc = _cDongNuoc.getCTDongNuocbyID(decimal.Parse(txtMaThongBao_DN.Text.Trim().Replace("-", "")));
                    if (!string.IsNullOrEmpty(_ctdongnuoc.DongNuoc.MaDonTXL.ToString()))
                    {
                        txtMaDon.Text = "TXL" + _ctdongnuoc.DongNuoc.MaDonTXL.ToString().Insert(_ctdongnuoc.DongNuoc.MaDonTXL.ToString().Length - 2, "-");
                        dgvDSBamChi.DataSource = _cBamChi.LoadDSCTBamChi_TXL(_ctdongnuoc.DongNuoc.MaDonTXL.Value, _ctdongnuoc.DanhBo);
                    }
                    else
                        if (!string.IsNullOrEmpty(_ctdongnuoc.DongNuoc.MaDon.ToString()))
                        {
                            txtMaDon.Text = _ctdongnuoc.DongNuoc.MaDon.ToString().Insert(_ctdongnuoc.DongNuoc.MaDon.ToString().Length - 2, "-");
                            dgvDSBamChi.DataSource = _cBamChi.LoadDSCTBamChi(_ctdongnuoc.DongNuoc.MaDon.Value, _ctdongnuoc.DanhBo);
                        }

                    txtMaThongBao_DN.Text = _ctdongnuoc.MaCTDN.ToString().Insert(_ctdongnuoc.MaCTDN.ToString().Length - 2, "-");

                    if (!string.IsNullOrEmpty(_ctdongnuoc.MaCTMN.ToString()))
                        txtMaThongBao_MN.Text = _ctdongnuoc.MaCTMN.ToString().Insert(_ctdongnuoc.MaCTMN.ToString().Length - 2, "-");
                    ///
                    txtDanhBo.Text = _ctdongnuoc.DanhBo;
                    txtHopDong.Text = _ctdongnuoc.HopDong;
                    txtHoTen.Text = _ctdongnuoc.HoTen;
                    txtDiaChi.Text = _ctdongnuoc.DiaChi;
                    txtDiaChiDHN.Text = _ctdongnuoc.DiaChiDHN;
                    ///
                    dateDongNuoc.Value = _ctdongnuoc.NgayDN.Value;
                    txtSoCongVan_DN.Text = _ctdongnuoc.SoCongVan_DN;
                    dateCongVan_DN.Value = _ctdongnuoc.NgayCongVan_DN.Value;
                    txtPhuong_DN.Text = _ctdongnuoc.Phuong;
                    txtQuan_DN.Text = _ctdongnuoc.Quan;
                    ///
                    if (_ctdongnuoc.MoNuoc)
                    {
                        dateMoNuoc.Value = _ctdongnuoc.NgayMN.Value;
                        txtSoCongVan_MN.Text = _ctdongnuoc.SoCongVan_MN;
                        dateCongVan_MN.Value = _ctdongnuoc.NgayCongVan_MN.Value;
                        txtLyDoDN.Text = _ctdongnuoc.LyDo_DN;
                        txtHinhThucDN.Text = _ctdongnuoc.HinhThuc_DN;
                        btnCapNhatMoNuoc.Enabled = false;
                    }
                    else
                    {
                        dateMoNuoc.Value = DateTime.Now;
                        txtSoCongVan_MN.Text = "";
                        dateCongVan_MN.Value = DateTime.Now;
                        txtLyDoDN.Text = "";
                        txtHinhThucDN.Text = "";
                        btnCapNhatMoNuoc.Enabled = true;
                    }
                }
                else
                {
                    Clear();
                    _ctdongnuoc = null;
                    MessageBox.Show("Mã Thông Báo này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    txtDanhBo.Text = "";
                    txtHopDong.Text = "";
                    txtHoTen.Text = "";
                    txtDiaChi.Text = "";
                    txtDiaChiDHN.Text = "";
                    _ttkhachhang = null;
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

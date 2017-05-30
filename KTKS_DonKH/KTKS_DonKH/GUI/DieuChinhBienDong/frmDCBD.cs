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
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDCBD : Form
    {
        string _mnu = "mnuDCBD";
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        CTDCBD _ctdcbd = null;
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CChungTu _cChungTu = new CChungTu();
        CThuTien _cThuTien = new CThuTien();
        CDCBD _cDCBD = new CDCBD();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CKTXM _cKTXM = new CKTXM();
        CDocSo _cDocSo = new CDocSo();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        bool _flagCtrl3 = false;
        decimal _MaCTDCBD = -1;

        public frmDCBD()
        {
            InitializeComponent();
        }

        public frmDCBD(decimal MaCTDCBD)
        {
            _MaCTDCBD = MaCTDCBD;
            InitializeComponent();
        }

        private void frmDCBD_Load(object sender, EventArgs e)
        {
            ///this.KeyPreview = true;
            ///Hàm Properties không có nên phải add code
            ///Dùng để bôi đen Text
            txtMaDon.GotFocus += new EventHandler(txtMaDon_GotFocus);

            dgvDSSoDangKy.AutoGenerateColumns = false;
            dgvDSSoDangKy.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSSoDangKy.Font, FontStyle.Bold);
            //DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSSoDangKy.Columns["MaLCT"];
            //cmbColumn.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
            //cmbColumn.DisplayMember = "TenLCT";
            //cmbColumn.ValueMember = "MaLCT";

            dgvDSDieuChinh.AutoGenerateColumns = false;
            dgvDSDieuChinh.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSDieuChinh.Font, FontStyle.Bold);

            dgvLichSuChungTu.AutoGenerateColumns = false;
            dgvLichSuChungTu.ColumnHeadersDefaultCellStyle.Font = new Font(dgvLichSuChungTu.Font, FontStyle.Bold);

            dgvDSChungTu.AutoGenerateColumns = false;
            dgvDSChungTu.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSChungTu.Font, FontStyle.Bold);

            if (_MaCTDCBD != -1)
            {
                txtSoPhieu.Text = _MaCTDCBD.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtSoPhieu_KeyPress(sender, arg);
            }

            lbDSHetHan.Text = _cChungTu.LoadDSCapDinhMucHetHan().Rows.Count.ToString() + " Sổ sắp hết hạn";
        }

        void txtMaDon_GotFocus(object sender, EventArgs e)
        {
            txtMaDon.SelectAll();
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHopDong.Text = hoadon.HOPDONG;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
            txtMSThue.Text = hoadon.MST;
            txtGiaBieu.Text = hoadon.GB.ToString();
            txtDinhMuc.Text = hoadon.DM.ToString();
            txtSH.Text = hoadon.TILESH.ToString();
            txtSX.Text = hoadon.TILESX.ToString();
            txtDV.Text = hoadon.TILEDV.ToString();
            txtHCSN.Text = hoadon.TILEHCSN.ToString();
            txtDot.Text = _cDocSo.GetDot(hoadon.DANHBA);

            dgvDSSoDangKy.DataSource = _cChungTu.GetDSCT(hoadon.DANHBA);
            dgvDSDieuChinh.DataSource = _cDCBD.LoadDSDCbyDanhBo(hoadon.DANHBA);
            LoadTongNK();
        }

        public void LoadDCBD(CTDCBD ctdcbd)
        {
            if (ctdcbd.DCBD.MaDon != null)
            {
                _donkh = _cDonKH.Get(ctdcbd.DCBD.MaDon.Value);
                txtMaDon.Text = ctdcbd.DCBD.MaDon.ToString().Insert(ctdcbd.DCBD.MaDon.ToString().Length - 2, "-");
            }
            else
                if (ctdcbd.DCBD.MaDonTXL != null)
                {
                    _dontxl = _cDonTXL.Get(ctdcbd.DCBD.MaDonTXL.Value);
                    txtMaDon.Text = "TXL" + ctdcbd.DCBD.MaDonTXL.ToString().Insert(ctdcbd.DCBD.MaDonTXL.ToString().Length - 2, "-");
                }
                else
                    if (ctdcbd.DCBD.MaDonTBC != null)
                    {
                        _dontbc = _cDonTBC.Get(ctdcbd.DCBD.MaDonTBC.Value);
                        txtMaDon.Text = "TBC" + ctdcbd.DCBD.MaDonTBC.ToString().Insert(ctdcbd.DCBD.MaDonTBC.ToString().Length - 2, "-");
                    }

            txtSoPhieu.Text = ctdcbd.MaCTDCBD.ToString().Insert(ctdcbd.MaCTDCBD.ToString().Length - 2, "-");
            ///
            txtDot.Text = ctdcbd.Dot;
            txtHieuLucKy.Text = ctdcbd.HieuLucKy;
            txtGhiChu.Text = ctdcbd.GhiChu;
            txtDanhBo.Text = ctdcbd.DanhBo;
            txtHopDong.Text = ctdcbd.HopDong;
            txtHoTen.Text = ctdcbd.HoTen;
            txtDiaChi.Text = ctdcbd.DiaChi;
            txtMSThue.Text = ctdcbd.MSThue;
            if (ctdcbd.GiaBieu != null)
                txtGiaBieu.Text = ctdcbd.GiaBieu.Value.ToString();
            else
                txtGiaBieu.Text = "";
            if (ctdcbd.DinhMuc != null)
                txtDinhMuc.Text = ctdcbd.DinhMuc.Value.ToString();
            else
                txtDinhMuc.Text = "";
            txtSH.Text = ctdcbd.SH;
            txtSX.Text = ctdcbd.SX;
            txtDV.Text = ctdcbd.DV;
            txtHCSN.Text = ctdcbd.HCSN;
            ///
            txtHoTen_BD.Text = ctdcbd.HoTen_BD;
            txtDiaChi_BD.Text = ctdcbd.DiaChi_BD;
            txtMSThue_BD.Text = ctdcbd.MSThue_BD;
            if (ctdcbd.GiaBieu_BD != null)
                txtGiaBieu_BD.Text = ctdcbd.GiaBieu_BD.Value.ToString();
            else
                txtGiaBieu_BD.Text = "";
            if (ctdcbd.DinhMuc_BD != null)
                txtDinhMuc_BD.Text = ctdcbd.DinhMuc_BD.Value.ToString();
            else
                txtDinhMuc_BD.Text = "";
            txtSH_BD.Text = ctdcbd.SH_BD;
            txtSX_BD.Text = ctdcbd.SX_BD;
            txtDV_BD.Text = ctdcbd.DV_BD;
            txtHCSN_BD.Text = ctdcbd.HCSN_BD;
            ///
            chkDMGiuNguyen.Checked = ctdcbd.DMGiuNguyen;
            chkGiaHan.Checked = ctdcbd.GiaHan;
            chkDoanThanhNien.Checked = ctdcbd.DoanThanhNien;
            chkCatMSThue.Checked = ctdcbd.CatMSThue;
            ///
            dgvDSSoDangKy.DataSource = _cChungTu.GetDSCT(ctdcbd.DanhBo);
            dgvDSDieuChinh.DataSource = _cDCBD.LoadDSDCbyDanhBo(ctdcbd.DanhBo);
            LoadTongNK();
        }

        public void Clear()
        {
            //txtMaDon.Text = "";
            txtSoPhieu.Text = "";
            txtDot.Text = "";
            txtHieuLucKy.Text = "";
            txtGhiChu.Text = "";
            ///
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtMSThue.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtSH.Text = "";
            txtSX.Text = "";
            txtDV.Text = "";
            txtHCSN.Text = "";
            ///
            chkDMGiuNguyen.Checked = false;
            chkGiaHan.Checked = false;
            chkDoanThanhNien.Checked = false;
            chkCatMSThue.Checked = false;
            ///
            txtHoTen_BD.Text = "";
            txtDiaChi_BD.Text = "";
            txtMSThue_BD.Text = "";
            txtGiaBieu_BD.Text = "";
            txtDinhMuc_BD.Text = "";
            txtSH_BD.Text = "";
            txtSX_BD.Text = "";
            txtDV_BD.Text = "";
            txtHCSN_BD.Text = "";
            lbTongNK.Text = "";
            ///
            _hoadon = null;
            _donkh = null;
            _dontxl = null;
            _dontbc = null;
            _ctdcbd = null;
            _MaCTDCBD = -1;
            ///
            dgvDSSoDangKy.DataSource = null;
            dgvDSDieuChinh.DataSource = null;
            dgvLichSuChungTu.DataSource = null;
            dgvDSChungTu.DataSource = null;
        }

        /// <summary>
        /// Hiện thị Tổng số NK Đăng Ký của Danh Bộ
        /// </summary>
        public void LoadTongNK()
        {
            int TongNK = 0;
            foreach (DataRow itemRow in ((DataTable)dgvDSSoDangKy.DataSource).Rows)
                if (!bool.Parse(itemRow["Cat"].ToString()))
                {
                    TongNK += int.Parse(itemRow["SoNKDangKy"].ToString());
                }
            lbTongNK.Text = "Tổng NK: " + TongNK;
            lbTongDM.Text = "Tổng ĐM: " + TongNK * 4;
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
                        _dontxl = _cDonTXL.Get(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDon.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");
                        if (_cThuTien.GetMoiNhat(_dontxl.DanhBo) != null)
                        {
                            _hoadon = _cThuTien.GetMoiNhat(_dontxl.DanhBo);
                            LoadTTKH(_hoadon);
                            txtDanhBo.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDanhBo.Focus();
                        }
                    }
                    else
                        MessageBox.Show("Mã Đơn TXL này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                txtDanhBo.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtDanhBo.Focus();
                            }
                        }
                        else
                            MessageBox.Show("Mã Đơn TXL này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ///Đơn Tổ Khách Hàng
                    else
                        if (_cDonKH.CheckExist(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) == true)
                        {
                            _donkh = _cDonKH.Get(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                            txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                            if (_cThuTien.GetMoiNhat(_donkh.DanhBo) != null)
                            {
                                _hoadon = _cThuTien.GetMoiNhat(_donkh.DanhBo);
                                LoadTTKH(_hoadon);
                                txtDanhBo.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtDanhBo.Focus();
                            }
                        }
                        else
                            MessageBox.Show("Mã Đơn KH này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    txtHieuLucKy.Focus();
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSoPhieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtSoPhieu.Text.Trim() != "")
                if (_cDCBD.CheckExist_DCBD(decimal.Parse(txtSoPhieu.Text.Trim().Replace("-", ""))) == true)
                {
                    _ctdcbd = _cDCBD.GetDCBDByMaCTDCBD(decimal.Parse(txtSoPhieu.Text.Trim().Replace("-", "")));
                    LoadDCBD(_ctdcbd);
                }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    //if (_dontxl != null && ((chkDMGiuNguyen.Checked || chkGiaHan.Checked) || (txtHieuLucKy.Text.Trim() != "" && (
                    //        !string.IsNullOrEmpty(txtHoTen_BD.Text.Trim())
                    //        || !string.IsNullOrEmpty(txtDiaChi_BD.Text.Trim())
                    //        || !string.IsNullOrEmpty(txtMSThue_BD.Text.Trim())
                    //        || !string.IsNullOrEmpty(txtGiaBieu_BD.Text.Trim())
                    //        || !string.IsNullOrEmpty(txtDinhMuc_BD.Text.Trim())
                    //        ))))
                    if ((chkDMGiuNguyen.Checked == false && chkGiaHan.Checked == false) && (txtHieuLucKy.Text.Trim() == "" || (txtHoTen_BD.Text.Trim() == "" && txtDiaChi_BD.Text.Trim() == "" && txtMSThue_BD.Text.Trim() == "" && txtGiaBieu_BD.Text.Trim() == "" && txtDinhMuc_BD.Text.Trim() == "")))
                    {
                        MessageBox.Show("Chưa có Hiệu Lực Kỳ \nHoặc không có biến động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    CTDCBD ctdcbd = new CTDCBD();

                    if (_donkh != null)
                    {
                        if (_cDCBD.CheckExist("TKH", _donkh.MaDon) == false)
                        {
                            DCBD dcbd = new DCBD();
                            dcbd.MaDon = _donkh.MaDon;
                            _cDCBD.Them(dcbd);
                        }
                        if (_cDCBD.CheckExist_DCBD("TKH", _donkh.MaDon, txtDanhBo.Text.Trim()) == true)
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Biến Động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ctdcbd.MaDCBD = _cDCBD.Get("TKH", _donkh.MaDon).MaDCBD;
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
                            if (_cDCBD.CheckExist_DCBD("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim()) == true)
                            {
                                MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Biến Động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            ctdcbd.MaDCBD = _cDCBD.Get("TXL", _dontxl.MaDon).MaDCBD;
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
                                if (_cDCBD.CheckExist_DCBD("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim()) == true)
                                {
                                    MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Biến Động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                ctdcbd.MaDCBD = _cDCBD.Get("TBC", _dontbc.MaDon).MaDCBD;
                            }
                            else
                            {
                                MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                    ctdcbd.DanhBo = txtDanhBo.Text.Trim();
                    ctdcbd.HopDong = txtHopDong.Text.Trim();
                    ctdcbd.HoTen = txtHoTen.Text.Trim();
                    ctdcbd.DiaChi = txtDiaChi.Text.Trim();
                    if (_hoadon != null)
                    {
                        ctdcbd.MaQuanPhuong = _hoadon.Quan + " " + _hoadon.Phuong;
                        ctdcbd.Ky = _hoadon.KY.ToString();
                        ctdcbd.Nam = _hoadon.NAM.ToString();
                    }
                    ctdcbd.MSThue = txtMSThue.Text.Trim();
                    if (!string.IsNullOrEmpty(txtGiaBieu.Text.Trim()))
                        ctdcbd.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                    else
                        ctdcbd.GiaBieu = null;
                    if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                        ctdcbd.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                    else
                        ctdcbd.DinhMuc = null;
                    ctdcbd.SH = txtSH.Text.Trim();
                    ctdcbd.SX = txtSX.Text.Trim();
                    ctdcbd.DV = txtDV.Text.Trim();
                    ctdcbd.HCSN = txtHCSN.Text.Trim();
                    ctdcbd.Dot = txtDot.Text.Trim();
                    ctdcbd.HieuLucKy = txtHieuLucKy.Text.Trim();
                    ctdcbd.GhiChu = txtGhiChu.Text.Trim();

                    ///Biến lưu Điều Chỉnh về gì (Họ Tên,Địa Chỉ,Định Mức,Giá Biểu,MSThuế)
                    string ThongTin = "";
                    ///Họ Tên
                    if (txtHoTen_BD.Text.Trim() != "")
                    {
                        ThongTin += "Họ Tên. ";
                        ctdcbd.HoTen_BD = txtHoTen_BD.Text.Trim();
                    }
                    ///Địa Chỉ
                    if (txtDiaChi_BD.Text.Trim() != "")
                    {
                        ThongTin += "Địa Chỉ. ";
                        ctdcbd.DiaChi_BD = txtDiaChi_BD.Text.Trim();
                    }
                    ///Mã Số Thuế
                    if (txtMSThue_BD.Text.Trim() != "")
                    {
                        ThongTin += "MST. ";
                        ctdcbd.MSThue_BD = txtMSThue_BD.Text.Trim();
                    }
                    if (chkCatMSThue.Checked)
                    {
                        ThongTin += "MST. ";
                        ctdcbd.CatMSThue = true;
                    }
                    ///Giá Biểu
                    if (txtGiaBieu_BD.Text.Trim() != "")
                    {
                        ThongTin += "GB. ";
                        ctdcbd.GiaBieu_BD = int.Parse(txtGiaBieu_BD.Text.Trim());
                    }
                    ///Định Mức
                    if (txtDinhMuc_BD.Text.Trim() != "")
                    {
                        ThongTin += "ĐM. ";
                        ctdcbd.DinhMuc_BD = int.Parse(txtDinhMuc_BD.Text.Trim());
                    }
                    if (txtSH_BD.Text.Trim() != "" || txtSX_BD.Text.Trim() != "" || txtDV_BD.Text.Trim() != "" || txtHCSN_BD.Text.Trim() != "")
                        ThongTin += "Tỷ Lệ. ";
                    ///SH
                    if (txtSH_BD.Text.Trim() != "")
                        ctdcbd.SH_BD = txtSH_BD.Text.Trim();
                    ///SX
                    if (txtSX_BD.Text.Trim() != "")
                        ctdcbd.SX_BD = txtSX_BD.Text.Trim();
                    ///DV
                    if (txtDV_BD.Text.Trim() != "")
                        ctdcbd.DV_BD = txtDV_BD.Text.Trim();
                    ///HCSN
                    if (txtHCSN_BD.Text.Trim() != "")
                        ctdcbd.HCSN_BD = txtHCSN_BD.Text.Trim();

                    ctdcbd.ThongTin = ThongTin;

                    ctdcbd.DMGiuNguyen = chkDMGiuNguyen.Checked;
                    ctdcbd.GiaHan = chkGiaHan.Checked;
                    ctdcbd.DoanThanhNien = chkDoanThanhNien.Checked;

                    if (chkDMGiuNguyen.Checked || chkGiaHan.Checked)
                        ctdcbd.PhieuDuocKy = false;
                    else
                    {
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            ctdcbd.ChucVu = "GIÁM ĐỐC";
                        else
                            ctdcbd.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        ctdcbd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        ctdcbd.PhieuDuocKy = true;
                    }

                    if (_cDCBD.ThemDCBD(ctdcbd))
                    {
                        Clear();
                        MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (_ctdcbd != null)
                    {
                        _ctdcbd.DanhBo = txtDanhBo.Text.Trim();
                        _ctdcbd.HopDong = txtHopDong.Text.Trim();
                        _ctdcbd.HoTen = txtHoTen.Text.Trim();
                        _ctdcbd.DiaChi = txtDiaChi.Text.Trim();
                        if (_hoadon != null)
                        {
                            _ctdcbd.MaQuanPhuong = _hoadon.Quan + " " + _hoadon.Phuong;
                            _ctdcbd.Ky = _hoadon.KY.ToString();
                            _ctdcbd.Nam = _hoadon.NAM.ToString();
                        }
                        _ctdcbd.MSThue = txtMSThue.Text.Trim();
                        if (!string.IsNullOrEmpty(txtGiaBieu.Text.Trim()))
                            _ctdcbd.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        else
                            _ctdcbd.GiaBieu = null;
                        if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                            _ctdcbd.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        else
                            _ctdcbd.DinhMuc = null;
                        _ctdcbd.SH = txtSH.Text.Trim();
                        _ctdcbd.SX = txtSX.Text.Trim();
                        _ctdcbd.DV = txtDV.Text.Trim();
                        _ctdcbd.HCSN = txtHCSN.Text.Trim();
                        _ctdcbd.Dot = txtDot.Text.Trim();
                        _ctdcbd.HieuLucKy = txtHieuLucKy.Text.Trim();
                        _ctdcbd.GhiChu = txtGhiChu.Text.Trim();

                        ///Biến lưu Điều Chỉnh về gì (Họ Tên,Địa Chỉ,Định Mức,Giá Biểu,MSThuế)
                        string ThongTin = "";
                        ///Họ Tên
                        if (txtHoTen_BD.Text.Trim() != "")
                        {
                            ThongTin += "Họ Tên. ";
                            _ctdcbd.HoTen_BD = txtHoTen_BD.Text.Trim();
                        }
                        else
                            _ctdcbd.HoTen_BD = null;
                        ///Địa Chỉ
                        if (txtDiaChi_BD.Text.Trim() != "")
                        {
                            ThongTin += "Địa Chỉ. ";
                            _ctdcbd.DiaChi_BD = txtDiaChi_BD.Text.Trim();
                        }
                        else
                            _ctdcbd.DiaChi_BD = null;
                        ///Mã Số Thuế
                        if (txtMSThue_BD.Text.Trim() != "")
                        {
                            ThongTin += "MST. ";
                            _ctdcbd.MSThue_BD = txtMSThue_BD.Text.Trim();
                        }
                        else
                            _ctdcbd.MSThue_BD = null;
                        if (chkCatMSThue.Checked)
                        {
                            ThongTin += "MST. ";
                            _ctdcbd.CatMSThue = true;
                        }
                        else
                            _ctdcbd.CatMSThue = false;
                        ///Giá Biểu
                        if (txtGiaBieu_BD.Text.Trim() != "")
                        {
                            ThongTin += "GB. ";
                            _ctdcbd.GiaBieu_BD = int.Parse(txtGiaBieu_BD.Text.Trim());
                        }
                        else
                            _ctdcbd.GiaBieu_BD = null;
                        ///Định Mức
                        if (txtDinhMuc_BD.Text.Trim() != "")
                        {
                            ThongTin += "ĐM. ";
                            _ctdcbd.DinhMuc_BD = int.Parse(txtDinhMuc_BD.Text.Trim());
                        }
                        else
                            _ctdcbd.DinhMuc_BD = null;
                        if (txtSH_BD.Text.Trim() != "" || txtSX_BD.Text.Trim() != "" || txtDV_BD.Text.Trim() != "" || txtHCSN_BD.Text.Trim() != "")
                            ThongTin += "Tỷ Lệ. ";
                        ///SH
                        if (txtSH_BD.Text.Trim() != "")
                            _ctdcbd.SH_BD = txtSH_BD.Text.Trim();
                        else
                            _ctdcbd.SH_BD = null;
                        ///SX
                        if (txtSX_BD.Text.Trim() != "")
                            _ctdcbd.SX_BD = txtSX_BD.Text.Trim();
                        else
                            _ctdcbd.SX_BD = null;
                        ///DV
                        if (txtDV_BD.Text.Trim() != "")
                            _ctdcbd.DV_BD = txtDV_BD.Text.Trim();
                        else
                            _ctdcbd.DV_BD = null;
                        ///HCSN
                        if (txtHCSN_BD.Text.Trim() != "")
                            _ctdcbd.HCSN_BD = txtHCSN_BD.Text.Trim();
                        else
                            _ctdcbd.HCSN_BD = null;

                        _ctdcbd.ThongTin = ThongTin;

                        _ctdcbd.DMGiuNguyen = chkDMGiuNguyen.Checked;
                        _ctdcbd.GiaHan = chkGiaHan.Checked;
                        _ctdcbd.DoanThanhNien = chkDoanThanhNien.Checked;

                        if (chkDMGiuNguyen.Checked || chkGiaHan.Checked)
                            _ctdcbd.PhieuDuocKy = false;
                        else
                        {
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                _ctdcbd.ChucVu = "GIÁM ĐỐC";
                            else
                                _ctdcbd.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            _ctdcbd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            _ctdcbd.PhieuDuocKy = true;
                        }
                        if (_cDCBD.SuaDCBD(_ctdcbd))
                        {
                            Clear();
                            MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (_ctdcbd != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (_cDCBD.XoaDCBD(_ctdcbd))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void frmDCBD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Add)
                btnThem.PerformClick();
            if ((_donkh != null || _dontxl != null || _dontbc != null) && e.Control && e.KeyCode == Keys.D1)
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                if (_donkh != null)
                {
                    source.Add("Loai", "TKH");
                    source.Add("MaDon", _donkh.MaDon.ToString());
                }
                else
                    if (_dontxl != null)
                    {
                        source.Add("Loai", "TXL");
                        source.Add("MaDon", _dontxl.MaDon.ToString());
                    }
                    else
                        if (_dontbc != null)
                        {
                            source.Add("Loai", "TBC");
                            source.Add("MaDon", _dontbc.MaDon.ToString());
                        }
                source.Add("DanhBo", txtDanhBo.Text.Trim());
                if (txtHoTen_BD.Text.Trim() == "")
                    source.Add("HoTen", txtHoTen.Text.Trim());
                else
                    source.Add("HoTen", txtHoTen_BD.Text.Trim());
                ///
                if (txtDiaChi_BD.Text.Trim() == "")
                    if (txtDiaChi.Text.Trim().Contains(","))
                        source.Add("DiaChi", txtDiaChi.Text.Trim().Substring(0, txtDiaChi.Text.Trim().IndexOf(",")));
                    else
                        source.Add("DiaChi", txtDiaChi.Text.Trim());
                else
                    source.Add("DiaChi", txtDiaChi_BD.Text.Trim());
                source.Add("MaCT", "");
                source.Add("MaLCT", "");
                frmSoDK frm = new frmSoDK(source);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgvDSSoDangKy.DataSource = _cChungTu.GetDSCT(txtDanhBo.Text.Trim());
                    LoadTongNK();
                }
                //thêmToolStripMenuItem.PerformClick();
            }
            if ((_donkh != null || _dontxl != null || _dontbc != null) && e.Control && e.KeyCode == Keys.D2)
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                if (_donkh != null)
                {
                    source.Add("Loai", "TKH");
                    source.Add("MaDon", _donkh.MaDon.ToString());
                }
                else
                    if (_dontxl != null)
                    {
                        source.Add("Loai", "TXL");
                        source.Add("MaDon", _dontxl.MaDon.ToString());
                    }
                    else
                        if (_dontbc != null)
                        {
                            source.Add("Loai", "TBC");
                            source.Add("MaDon", _dontbc.MaDon.ToString());
                        }
                source.Add("DanhBo", txtDanhBo.Text.Trim());
                if (txtHoTen_BD.Text.Trim() == "")
                    source.Add("HoTen", txtHoTen.Text.Trim());
                else
                    source.Add("HoTen", txtHoTen_BD.Text.Trim());
                ///
                if (txtDiaChi_BD.Text.Trim() == "")
                    if (txtDiaChi.Text.Trim().Contains(","))
                        source.Add("DiaChi", txtDiaChi.Text.Trim().Substring(0, txtDiaChi.Text.Trim().IndexOf(",")));
                    else
                        source.Add("DiaChi", txtDiaChi.Text.Trim());
                else
                    source.Add("DiaChi", txtDiaChi_BD.Text.Trim());
                frmNhanDM frm = new frmNhanDM(source);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgvDSSoDangKy.DataSource = _cChungTu.GetDSCT(txtDanhBo.Text.Trim());
                    LoadTongNK();
                }
                //nhậnĐịnhMứctoolStripMenuItem.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.D3)
            {
                if (!_flagCtrl3)
                {
                    _flagCtrl3 = true;
                    groupBox_DSSoDangKy.Height = 358;
                    dgvDSSoDangKy.Height = 330;
                    panel_LichSuDieuChinh.Location = new Point(0, 560);
                }
                else
                {
                    _flagCtrl3 = false;
                    groupBox_DSSoDangKy.Height = 229;
                    dgvDSSoDangKy.Height = 200;
                    panel_LichSuDieuChinh.Location = new Point(0, 434);
                }
            }
            if (e.Control && e.KeyCode == Keys.D4)
            {
                frmTimKiemChungTu frm = new frmTimKiemChungTu();
                frm.ShowDialog();
            }
        }

        private void lbDSHetHan_DoubleClick(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = _cChungTu.LoadDSCapDinhMucHetHan();

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
            {
                if (!string.IsNullOrEmpty(itemRow["NgayHetHan"].ToString()))
                {
                    DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                    dr["TuNgay"] = "";
                    dr["DenNgay"] = "";
                    if (_cDCBD.checkCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                    {
                        string a = _cDCBD.getCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
                        dr["SoPhieu"] = a.Insert(a.Length - 2, "-");
                    }
                    else
                        dr["SoPhieu"] = "";

                    if (_cChungTu.CheckMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString()))
                    {
                        decimal MaDon = _cChungTu.getMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString());
                        dr["MaDon"] = MaDon.ToString().Insert(MaDon.ToString().Length - 2, "-");
                    }
                    else
                        dr["MaDon"] = "";

                    if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                        dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");

                    HOADON hoadon = _cThuTien.GetMoiNhat(itemRow["DanhBo"].ToString());
                    if (hoadon != null)
                    {
                        dr["HoTen"] = hoadon.TENKH;
                        dr["DiaChi"] = hoadon.SO + " " + hoadon.DUONG;
                        dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                        dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(hoadon.Quan));
                    }

                    dr["MaLCT"] = itemRow["MaLCT"];
                    dr["TenLCT"] = itemRow["TenLCT"];
                    dr["MaCT"] = itemRow["MaCT"];
                    dr["DinhMucCap"] = (int.Parse(itemRow["SoNKDangKy"].ToString()) * 4).ToString();
                    dr["NgayHetHan"] = itemRow["NgayHetHan"];
                    dr["DienThoai"] = itemRow["DienThoai"];
                    dr["GhiChu"] = itemRow["GhiChu"];

                    dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                }
            }

            rptDSCapDinhMuc rpt = new rptDSCapDinhMuc();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                Dictionary<string, string> source = new Dictionary<string, string>();

                if (_donkh != null)
                {
                    source.Add("Loai", "TKH");
                    source.Add("MaDon", _donkh.MaDon.ToString());
                }
                else
                    if (_dontxl != null)
                    {
                        source.Add("Loai", "TXL");
                        source.Add("MaDon", _dontxl.MaDon.ToString());
                    }
                    else
                        if (_dontbc != null)
                        {
                            source.Add("Loai", "TBC");
                            source.Add("MaDon", _dontbc.MaDon.ToString());
                        }

                source.Add("DanhBo", txtDanhBo.Text.Trim());
                if (txtHoTen_BD.Text.Trim() == "")
                    source.Add("HoTen", txtHoTen.Text.Trim());
                else
                    source.Add("HoTen", txtHoTen_BD.Text.Trim());
                ///
                if (txtDiaChi_BD.Text.Trim() == "")
                    if (txtDiaChi.Text.Trim().Contains(","))
                        source.Add("DiaChi", txtDiaChi.Text.Trim().Substring(0, txtDiaChi.Text.Trim().IndexOf(",")));
                    else
                        source.Add("DiaChi", txtDiaChi.Text.Trim());
                else
                    source.Add("DiaChi", txtDiaChi_BD.Text.Trim());
                source.Add("MaCT", "");
                source.Add("MaLCT", "");
                frmSoDK frm = new frmSoDK(source);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgvDSSoDangKy.DataSource = _cChungTu.GetDSCT(txtDanhBo.Text.Trim());
                    LoadTongNK();
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                if (_donkh != null)
                {
                    source.Add("Loai", "TKH");
                    source.Add("MaDon", _donkh.MaDon.ToString());
                }
                else
                    if (_dontxl != null)
                    {
                        source.Add("Loai", "TXL");
                        source.Add("MaDon", _dontxl.MaDon.ToString());
                    }
                    else
                        if (_dontbc != null)
                        {
                            source.Add("Loai", "TBC");
                            source.Add("MaDon", _dontbc.MaDon.ToString());
                        }
                source.Add("DanhBo", txtDanhBo.Text.Trim());
                source.Add("MaCT", dgvDSSoDangKy.CurrentRow.Cells["MaCT"].Value.ToString());
                source.Add("MaLCT", dgvDSSoDangKy.CurrentRow.Cells["MaLCT"].Value.ToString());
                if (txtHoTen_BD.Text.Trim() == "")
                    source.Add("HoTen", txtHoTen.Text.Trim());
                else
                    source.Add("HoTen", txtHoTen_BD.Text.Trim());

                frmSoDK frm = new frmSoDK(source);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgvDSSoDangKy.DataSource = _cChungTu.GetDSCT(txtDanhBo.Text.Trim());
                    LoadTongNK();
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cắtChuyểnĐịnhMứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                if (_donkh != null)
                {
                    source.Add("Loai", "TKH");
                    source.Add("MaDon", _donkh.MaDon.ToString());
                }
                else
                    if (_dontxl != null)
                    {
                        source.Add("Loai", "TXL");
                        source.Add("MaDon", _dontxl.MaDon.ToString());
                    }
                    else
                        if (_dontbc != null)
                        {
                            source.Add("Loai", "TBC");
                            source.Add("MaDon", _dontbc.MaDon.ToString());
                        }
                source.Add("DanhBo", txtDanhBo.Text.Trim());
                source.Add("MaCT", dgvDSSoDangKy.CurrentRow.Cells["MaCT"].Value.ToString());
                source.Add("MaLCT", dgvDSSoDangKy.CurrentRow.Cells["MaLCT"].Value.ToString());
                if (txtHoTen_BD.Text.Trim() == "")
                    source.Add("HoTen", txtHoTen.Text.Trim());
                else
                    source.Add("HoTen", txtHoTen_BD.Text.Trim());
                frmCatChuyenDM frm = new frmCatChuyenDM(source);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgvDSSoDangKy.DataSource = _cChungTu.GetDSCT(txtDanhBo.Text.Trim());
                    LoadTongNK();
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void nhậnĐịnhMứctoolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                if (_donkh != null)
                {
                    source.Add("Loai", "TKH");
                    source.Add("MaDon", _donkh.MaDon.ToString());
                }
                else
                    if (_dontxl != null)
                    {
                        source.Add("Loai", "TXL");
                        source.Add("MaDon", _dontxl.MaDon.ToString());
                    }
                    else
                        if (_dontbc != null)
                        {
                            source.Add("Loai", "TBC");
                            source.Add("MaDon", _dontbc.MaDon.ToString());
                        }
                source.Add("DanhBo", txtDanhBo.Text.Trim());
                if (txtHoTen_BD.Text.Trim() == "")
                    source.Add("HoTen", txtHoTen.Text.Trim());
                else
                    source.Add("HoTen", txtHoTen_BD.Text.Trim());
                ///
                if (txtDiaChi_BD.Text.Trim() == "")
                    if (txtDiaChi.Text.Trim().Contains(","))
                        source.Add("DiaChi", txtDiaChi.Text.Trim().Substring(0, txtDiaChi.Text.Trim().IndexOf(",")));
                    else
                        source.Add("DiaChi", txtDiaChi.Text.Trim());
                else
                    source.Add("DiaChi", txtDiaChi_BD.Text.Trim());
                frmNhanDM frm = new frmNhanDM(source);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgvDSSoDangKy.DataSource = _cChungTu.GetDSCT(txtDanhBo.Text.Trim());
                    LoadTongNK();
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        CTChungTu ctchungtu = _cChungTu.GetCT(txtDanhBo.Text.Trim(), dgvDSSoDangKy.CurrentRow.Cells["MaCT"].Value.ToString(), int.Parse(dgvDSSoDangKy.CurrentRow.Cells["MaLCT"].Value.ToString()));
                        if (_cChungTu.XoaCT(ctchungtu))
                        {
                            dgvDSSoDangKy.DataSource = _cChungTu.GetDSCT(txtDanhBo.Text.Trim());
                            LoadTongNK();
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

        private void dgvDSSoDangKy_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSSoDangKy.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
            if (bool.Parse(dgvDSSoDangKy.Rows[e.RowIndex].Cells["Cat"].Value.ToString()) == true)
                dgvDSSoDangKy.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSlateGray;
            else
                dgvDSSoDangKy.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
        }

        private void dgvDSSoDangKy_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    sửaToolStripMenuItem.Enabled = true;
                    cắtChuyểnĐịnhMứcToolStripMenuItem.Enabled = true;
                    xóaToolStripMenuItem.Enabled = true;
                }
                else
                {
                    sửaToolStripMenuItem.Enabled = false;
                    cắtChuyểnĐịnhMứcToolStripMenuItem.Enabled = false;
                    xóaToolStripMenuItem.Enabled = false;
                }
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvDSSoDangKy.CurrentCell = dgvDSSoDangKy.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvDSSoDangKy_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && (_donkh != null || _dontxl != null || _dontbc != null))
            {
                thêmToolStripMenuItem.Enabled = true;
                nhậnĐịnhMứctoolStripMenuItem.Enabled = true;
                contextMenuStrip1.Show(dgvDSSoDangKy, new Point(e.X, e.Y));
            }
        }

        private void dgvDSSoDangKy_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.ControlBox = false;
            contextMenuStrip1.Enabled = false;
        }

        private void dgvDSSoDangKy_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    ///Hiện tại nếu check Cat mà exit bằng X thì dữ liệu không được lưu
                    ///Sau khi check phải check qua chỗ khác mới lưu
                    CTChungTu ctchungtu = _cChungTu.GetCT(dgvDSSoDangKy["DanhBo", e.RowIndex].Value.ToString(), dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString(), int.Parse(dgvDSSoDangKy["MaLCT", e.RowIndex].Value.ToString()));
                    if (bool.Parse(dgvDSSoDangKy["Cat", e.RowIndex].Value.ToString()) != ctchungtu.Cat)
                    {
                        ctchungtu.Cat = bool.Parse(dgvDSSoDangKy["Cat", e.RowIndex].Value.ToString());
                        _cChungTu.SuaCT(ctchungtu);
                    }
                    if (bool.Parse(dgvDSSoDangKy["GiaHan_SCT", e.RowIndex].Value.ToString()) != ctchungtu.GiaHan)
                    {
                        ctchungtu.GiaHan = bool.Parse(dgvDSSoDangKy["GiaHan_SCT", e.RowIndex].Value.ToString());
                        _cChungTu.SuaCT(ctchungtu);
                    }
                    if (dgvDSSoDangKy["DienThoai", e.RowIndex].Value.ToString() != ctchungtu.DienThoai)
                    {
                        ctchungtu.DienThoai = dgvDSSoDangKy["DienThoai", e.RowIndex].Value.ToString();
                        _cChungTu.SuaCT(ctchungtu);
                    }

                    this.ControlBox = true;
                    contextMenuStrip1.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvDSSoDangKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvDSChungTu.DataSource = _cChungTu.GetDSCT(dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString(), int.Parse(dgvDSSoDangKy["MaLCT", e.RowIndex].Value.ToString()));
                dgvLichSuChungTu.DataSource = _cChungTu.LoadDSLichSuChungTubyID(dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString(), int.Parse(dgvDSSoDangKy["MaLCT", e.RowIndex].Value.ToString()));
            }
            catch (Exception)
            {

            }
        }

        private void dgvDSDieuChinh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDieuChinh.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSDieuChinh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSDieuChinh.Columns[e.ColumnIndex].Name == "MaDC" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvDSDieuChinh.Columns[e.ColumnIndex].Name == "MaDon" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvDSDieuChinh_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvDSDieuChinh["DieuChinh", e.RowIndex].Value.ToString() == "Biến Động")
            {
                CTDCBD ctdcbd = _cDCBD.GetDCBDByMaCTDCBD(decimal.Parse(dgvDSDieuChinh["MaDC", e.RowIndex].Value.ToString()));
                DataTable dt = (DataTable)dgvDSSoDangKy.DataSource;
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                if (dt.Rows.Count == 0)
                {
                    DataRow dr = dsBaoCao.Tables["ChiTietDieuChinh"].NewRow();

                    dr["SoPhieu"] = ctdcbd.MaCTDCBD.ToString().Insert(ctdcbd.MaCTDCBD.ToString().Length - 2, "-");
                    dr["ThongTin"] = ctdcbd.ThongTin;
                    dr["HieuLucKy"] = ctdcbd.HieuLucKy;
                    dr["DanhBo"] = ctdcbd.DanhBo.Insert(7, " ").Insert(4, " ");

                    if (ctdcbd.DCBD.MaDon != null)
                        dr["MaDon"] = ctdcbd.DCBD.MaDon.Value.ToString().Insert(ctdcbd.DCBD.MaDon.Value.ToString().Length - 2, "-");
                    else
                        if (ctdcbd.DCBD.MaDonTXL != null)
                            dr["MaDon"] = "TXL" + ctdcbd.DCBD.MaDonTXL.Value.ToString().Insert(ctdcbd.DCBD.MaDonTXL.Value.ToString().Length - 2, "-");
                        else
                            if (ctdcbd.DCBD.MaDonTBC != null)
                                dr["MaDon"] = "TBC" + ctdcbd.DCBD.MaDonTBC.Value.ToString().Insert(ctdcbd.DCBD.MaDonTBC.Value.ToString().Length - 2, "-");

                    dr["HoTen"] = ctdcbd.HoTen;
                    dr["DiaChi"] = ctdcbd.DiaChi;
                    dr["GiaBieu"] = ctdcbd.GiaBieu;
                    dr["DinhMuc"] = ctdcbd.DinhMuc;
                    dr["MSThue"] = ctdcbd.MSThue;
                    ///Biến Động
                    dr["HoTenBD"] = ctdcbd.HoTen_BD;
                    dr["DiaChiBD"] = ctdcbd.DiaChi_BD;
                    dr["GiaBieuBD"] = ctdcbd.GiaBieu_BD;
                    dr["DinhMucBD"] = ctdcbd.DinhMuc_BD;
                    dr["MSThueBD"] = ctdcbd.MSThue_BD;

                    dsBaoCao.Tables["ChiTietDieuChinh"].Rows.Add(dr);
                }
                else
                    foreach (DataRow itemRow in dt.Rows)
                    {
                        DataRow dr = dsBaoCao.Tables["ChiTietDieuChinh"].NewRow();

                        dr["SoPhieu"] = ctdcbd.MaCTDCBD.ToString().Insert(ctdcbd.MaCTDCBD.ToString().Length - 2, "-");
                        dr["ThongTin"] = ctdcbd.ThongTin;
                        dr["HieuLucKy"] = ctdcbd.HieuLucKy;
                        dr["DanhBo"] = ctdcbd.DanhBo.Insert(7, " ").Insert(4, " ");

                        if (ctdcbd.DCBD.MaDon != null)
                            dr["MaDon"] = ctdcbd.DCBD.MaDon.Value.ToString().Insert(ctdcbd.DCBD.MaDon.Value.ToString().Length - 2, "-");
                        else
                            if (ctdcbd.DCBD.MaDonTXL != null)
                                dr["MaDon"] = "TXL" + ctdcbd.DCBD.MaDonTXL.Value.ToString().Insert(ctdcbd.DCBD.MaDonTXL.Value.ToString().Length - 2, "-");
                            else
                                if (ctdcbd.DCBD.MaDonTBC != null)
                                    dr["MaDon"] = "TBC" + ctdcbd.DCBD.MaDonTBC.Value.ToString().Insert(ctdcbd.DCBD.MaDonTBC.Value.ToString().Length - 2, "-");

                        dr["HoTen"] = ctdcbd.HoTen;
                        dr["DiaChi"] = ctdcbd.DiaChi;
                        dr["GiaBieu"] = ctdcbd.GiaBieu;
                        dr["DinhMuc"] = ctdcbd.DinhMuc;
                        dr["MSThue"] = ctdcbd.MSThue;
                        ///Biến Động
                        dr["HoTenBD"] = ctdcbd.HoTen_BD;
                        dr["DiaChiBD"] = ctdcbd.DiaChi_BD;
                        dr["GiaBieuBD"] = ctdcbd.GiaBieu_BD;
                        dr["DinhMucBD"] = ctdcbd.DinhMuc_BD;
                        dr["MSThueBD"] = ctdcbd.MSThue_BD;

                        dr["TenLCT"] = itemRow["TenLCT"].ToString();
                        dr["MaCT"] = itemRow["MaCT"].ToString();
                        dr["DiaChiCT"] = itemRow["DiaChi"].ToString();
                        dr["SoNKTong"] = itemRow["SoNKTong"].ToString();
                        dr["SoNKDangKy"] = itemRow["SoNKDangKy"].ToString();

                        dsBaoCao.Tables["ChiTietDieuChinh"].Rows.Add(dr);
                    }
                rptChiTietDieuChinh rpt = new rptChiTietDieuChinh();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();

            }
            else
                if (dgvDSDieuChinh["DieuChinh", e.RowIndex].Value.ToString() == "Hóa Đơn")
                    MessageBox.Show("Tính năng Hóa Đơn chưa được xây dựng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvLichSuChungTu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvLichSuChungTu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSChungTu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSChungTu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        #region Configure TextBox

        private void txtDanhBo_Leave(object sender, EventArgs e)
        {
            //txtHieuLucKy.Focus();
        }

        private void txtHieuLucKy_Leave(object sender, EventArgs e)
        {
            //txtHoTen_BD.Focus();
            //flagFirst = false;
        }

        private void txtHieuLucKy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtHoTen_BD.Focus();
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDiaChi.Focus();
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtMSThue.Focus();
        }

        private void txtMSThue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGiaBieu.Focus();
        }

        private void txtGiaBieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDinhMuc.Focus();
        }

        private void txtDinhMuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtHoTen_BD.Focus();
        }

        private void txtHoTen_BD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDiaChi_BD.Focus();
        }

        private void txtDiaChi_BD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtMSThue_BD.Focus();
        }

        private void txtMSThue_BD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGiaBieu_BD.Focus();
        }

        private void txtGiaBieu_BD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDinhMuc_BD.Focus();
        }

        private void txtDinhMuc_BD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                dgvDSSoDangKy.Focus();
        }

        #endregion

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            CLichSuDonTu _cLichSuDonTu = new CLichSuDonTu();

            LichSuDonTu entity = new LichSuDonTu();
            entity.NgayChuyen = DateTime.Now;
            //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
            //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
            entity.GhiChu = txtCapNhat.Text.Trim();
            if (_donkh != null)
            {
                entity.MaDon = _donkh.MaDon;
                entity.ID_NoiChuyen = 2;
                entity.NoiChuyen = "Tổ Khách Hàng";
            }
            else
                if (_dontxl != null)
                {
                    entity.MaDonTXL = _dontxl.MaDon;
                    entity.ID_NoiChuyen = 3;
                    entity.NoiChuyen = "Tổ Xử Lý";
                }
                else
                    if (_dontbc != null)
                    {
                        entity.MaDonTBC = _dontbc.MaDon;
                        entity.ID_NoiChuyen = 4;
                        entity.NoiChuyen = "Tổ Bấm Chì";
                    }
            _cLichSuDonTu.Them(entity);
        }



    }
}

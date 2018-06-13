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

        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        CTDCBD _ctdcbd = null;
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
            txtMaDonCu.GotFocus += new EventHandler(txtMaDon_GotFocus);

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
            txtMaDonCu.SelectAll();
        }

        private void LoadTTKH(HOADON hoadon)
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
            dgvDSDieuChinh.DataSource = _cDCBD.getDSDCBD(hoadon.DANHBA);
            LoadTongNK();
        }

        private void LoadDCBD(CTDCBD ctdcbd)
        {
            if (ctdcbd.DCBD.MaDon != null)
            {
                _dontkh = _cDonKH.Get(ctdcbd.DCBD.MaDon.Value);
                txtMaDonCu.Text = ctdcbd.DCBD.MaDon.ToString().Insert(ctdcbd.DCBD.MaDon.ToString().Length - 2, "-");
            }
            else
                if (ctdcbd.DCBD.MaDonTXL != null)
                {
                    _dontxl = _cDonTXL.Get(ctdcbd.DCBD.MaDonTXL.Value);
                    txtMaDonCu.Text = "TXL" + ctdcbd.DCBD.MaDonTXL.ToString().Insert(ctdcbd.DCBD.MaDonTXL.ToString().Length - 2, "-");
                }
                else
                    if (ctdcbd.DCBD.MaDonTBC != null)
                    {
                        _dontbc = _cDonTBC.Get(ctdcbd.DCBD.MaDonTBC.Value);
                        txtMaDonCu.Text = "TBC" + ctdcbd.DCBD.MaDonTBC.ToString().Insert(ctdcbd.DCBD.MaDonTBC.ToString().Length - 2, "-");
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
            chkGBGiuNguyen.Checked = ctdcbd.GBGiuNguyen;
            chkGiaHanKT3.Checked = ctdcbd.GiaHanKT3;
            chkGiaHanNhapCu.Checked = ctdcbd.GiaHanNhapCu;
            chkDoanThanhNien.Checked = ctdcbd.DoanThanhNien;
            chkCatMSThue.Checked = ctdcbd.CatMSThue;
            chkXoaDiaChiLienHe.Checked = ctdcbd.XoaDiaChiLienHe;
            ///
            dgvDSSoDangKy.DataSource = _cChungTu.GetDSCT(ctdcbd.DanhBo);
            dgvDSDieuChinh.DataSource = _cDCBD.getDSDCBD(ctdcbd.DanhBo);
            LoadTongNK();
        }

        private void Clear()
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
            chkGBGiuNguyen.Checked = false;
            chkGiaHanKT3.Checked = false;
            chkGiaHanNhapCu.Checked = false;
            chkDoanThanhNien.Checked = false;
            chkCatMSThue.Checked = false;
            chkXoaDiaChiLienHe.Checked = false;
            chkBoQuaKiemTraTrung.Checked = false;
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
            _dontkh = null;
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
        private void LoadTongNK()
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
                        if (_cDonKH.CheckExist(decimal.Parse(txtMaDonCu.Text.Trim().Replace("-", ""))) == true)
                        {
                            _dontkh = _cDonKH.Get(decimal.Parse(txtMaDonCu.Text.Trim().Replace("-", "")));
                            txtMaDonCu.Text = _dontkh.MaDon.ToString().Insert(_dontkh.MaDon.ToString().Length - 2, "-");

                            if (_cThuTien.GetMoiNhat(_dontkh.DanhBo) != null)
                            {
                                _hoadon = _cThuTien.GetMoiNhat(_dontkh.DanhBo);
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
                        _dontxl = _cDonTXL.Get(txtMaDonMoi.Text.Trim());
                        txtMaDonMoi.Text = _dontxl.MaDonMoi;

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
                    if (txtMaDonMoi.Text.Trim().ToUpper().Contains("BC"))
                    {
                        if (_cDonTBC.CheckExist(txtMaDonMoi.Text.Trim()) == true)
                        {
                            _dontbc = _cDonTBC.Get(txtMaDonMoi.Text.Trim());
                            txtMaDonMoi.Text = _dontbc.MaDonMoi;

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
                        if (txtMaDonMoi.Text.Trim().ToUpper().Contains("KH"))
                        {
                            if (_cDonKH.CheckExist(txtMaDonMoi.Text.Trim()) == true)
                            {
                                _dontkh = _cDonKH.Get(txtMaDonMoi.Text.Trim());
                                txtMaDonCu.Text = _dontkh.MaDonMoi;

                                if (_cThuTien.GetMoiNhat(_dontkh.DanhBo) != null)
                                {
                                    _hoadon = _cThuTien.GetMoiNhat(_dontkh.DanhBo);
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
                if (_cDCBD.checkExist_BienDong(decimal.Parse(txtSoPhieu.Text.Trim().Replace("-", ""))) == true)
                {
                    _ctdcbd = _cDCBD.getBienDong(decimal.Parse(txtSoPhieu.Text.Trim().Replace("-", "")));
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
                    if ((chkDMGiuNguyen.Checked == false && chkGBGiuNguyen.Checked == false && chkGiaHanKT3.Checked == false && chkGiaHanNhapCu.Checked == false)
                        && (txtHieuLucKy.Text.Trim() == "" || (txtHoTen_BD.Text.Trim() == "" && txtDiaChi_BD.Text.Trim() == "" && txtMSThue_BD.Text.Trim() == "" && txtGiaBieu_BD.Text.Trim() == "" && txtDinhMuc_BD.Text.Trim() == ""
                        && txtSH_BD.Text.Trim() == "" && txtSX_BD.Text.Trim() == "" && txtDV_BD.Text.Trim() == "" && txtHCSN_BD.Text.Trim() == "")))
                    {
                        MessageBox.Show("Chưa có Hiệu Lực Kỳ \nHoặc không có biến động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    CTDCBD ctdcbd = new CTDCBD();

                    if (_dontkh != null)
                    {
                        if (_cDCBD.CheckExist("TKH", _dontkh.MaDon) == false)
                        {
                            DCBD dcbd = new DCBD();
                            dcbd.MaDon = _dontkh.MaDon;
                            dcbd.MaDonMoi = _dontkh.MaDonMoi;
                            _cDCBD.Them(dcbd);
                        }
                        if (chkBoQuaKiemTraTrung.Checked == false && _cDCBD.checkExist_BienDong("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim()) == true)
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Biến Động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ctdcbd.MaDCBD = _cDCBD.Get("TKH", _dontkh.MaDon).MaDCBD;
                    }
                    else
                        if (_dontxl != null)
                        {
                            if (_cDCBD.CheckExist("TXL", _dontxl.MaDon) == false)
                            {
                                DCBD dcbd = new DCBD();
                                dcbd.MaDonTXL = _dontxl.MaDon;
                                dcbd.MaDonMoi = _dontxl.MaDonMoi;
                                _cDCBD.Them(dcbd);
                            }
                            if (chkBoQuaKiemTraTrung.Checked == false && _cDCBD.checkExist_BienDong("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim()) == true)
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
                                    dcbd.MaDonMoi = _dontbc.MaDonMoi;
                                    _cDCBD.Them(dcbd);
                                }
                                if (chkBoQuaKiemTraTrung.Checked == false && _cDCBD.checkExist_BienDong("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim()) == true)
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
                        ctdcbd.Phuong = _hoadon.Phuong;
                        ctdcbd.Quan = _hoadon.Quan;
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
                    if (chkXoaDiaChiLienHe.Checked)
                    {
                        //ThongTin += "Địa Chỉ. ";
                        ctdcbd.XoaDiaChiLienHe = true;
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
                    ctdcbd.GBGiuNguyen = chkGBGiuNguyen.Checked;
                    ctdcbd.GiaHanKT3 = chkGiaHanKT3.Checked;
                    ctdcbd.GiaHanNhapCu = chkGiaHanNhapCu.Checked;
                    ctdcbd.DoanThanhNien = chkDoanThanhNien.Checked;

                    if (chkDMGiuNguyen.Checked || chkGBGiuNguyen.Checked || chkGiaHanKT3.Checked || chkGiaHanNhapCu.Checked)
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
                        txtMaDonCu.Focus();
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
                            _ctdcbd.Phuong = _hoadon.Phuong;
                            _ctdcbd.Quan = _hoadon.Quan;
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
                        if (chkXoaDiaChiLienHe.Checked)
                        {
                            //ThongTin += "Địa Chỉ. ";
                            _ctdcbd.XoaDiaChiLienHe = true;
                        }
                        else
                            _ctdcbd.XoaDiaChiLienHe = false;
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
                        _ctdcbd.GBGiuNguyen = chkGBGiuNguyen.Checked;
                        _ctdcbd.GiaHanKT3 = chkGiaHanKT3.Checked;
                        _ctdcbd.GiaHanNhapCu = chkGiaHanNhapCu.Checked;
                        _ctdcbd.DoanThanhNien = chkDoanThanhNien.Checked;

                        if (chkDMGiuNguyen.Checked || chkGBGiuNguyen.Checked || chkGiaHanKT3.Checked||chkGiaHanNhapCu.Checked)
                        {
                            _ctdcbd.ChucVu = null;
                            _ctdcbd.NguoiKy = null;
                            _ctdcbd.PhieuDuocKy = false;
                        }
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
            if ((_dontkh != null || _dontxl != null || _dontbc != null) && e.Control && e.KeyCode == Keys.D1)
            {
                Them();
            }
            if ((_dontkh != null || _dontxl != null || _dontbc != null) && e.Control && e.KeyCode == Keys.D2)
            {
                Nhan();
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
                    if (_cDCBD.checkExist_BienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                    {
                        string a = _cDCBD.getBienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
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
                if (_dontkh != null || _dontxl != null || _dontbc != null)
                    Them();
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                if (_dontkh != null || _dontxl != null || _dontbc != null)
                    Sua();
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cắtChuyểnĐịnhMứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                if (_dontkh != null || _dontxl != null || _dontbc != null)
                    CatChuyen();
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void nhậnĐịnhMứctoolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                if (_dontkh != null || _dontxl != null || _dontbc != null)
                    Nhan();
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
            if (e.Button == MouseButtons.Right && (_dontkh != null || _dontxl != null || _dontbc != null))
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
                CTDCBD ctdcbd = _cDCBD.getBienDong(decimal.Parse(dgvDSDieuChinh["MaDC", e.RowIndex].Value.ToString()));
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
            if (_dontkh != null)
            {
                entity.MaDon = _dontkh.MaDon;
                entity.ID_NoiChuyen = 2;
                entity.NoiChuyen = "Tổ Khách Hàng";
                entity.GhiChu = "cTrân trả về tổ";
            }
            else
                if (_dontxl != null)
                {
                    entity.MaDonTXL = _dontxl.MaDon;
                    entity.ID_NoiChuyen = 3;
                    entity.NoiChuyen = "Tổ Xử Lý";
                    entity.GhiChu = "cTrân trả về tổ";
                }
                else
                    if (_dontbc != null)
                    {
                        entity.MaDonTBC = _dontbc.MaDon;
                        entity.ID_NoiChuyen = 4;
                        entity.NoiChuyen = "Tổ Bấm Chì";
                        entity.GhiChu = "cTrân trả về tổ";
                    }
            _cLichSuDonTu.Them(entity);
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            DataRow dr = dsBaoCao.Tables["DCBD"].NewRow();

            //CTDCBD ctdcbd = _cDCBD.GetDCBDByMaCTDCBD(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));
            if (_ctdcbd.DCBD.MaDon != null)
                dr["MaDon"] = _ctdcbd.DCBD.MaDon.ToString().Insert(_ctdcbd.DCBD.MaDon.ToString().Length - 2, "-");
            else
                if (_ctdcbd.DCBD.MaDonTXL != null)
                    dr["MaDon"] = "TXL" + _ctdcbd.DCBD.MaDonTXL.ToString().Insert(_ctdcbd.DCBD.MaDonTXL.ToString().Length - 2, "-");
                else
                    if (_ctdcbd.DCBD.MaDonTBC != null)
                        dr["MaDon"] = "TBC" + _ctdcbd.DCBD.MaDonTBC.ToString().Insert(_ctdcbd.DCBD.MaDonTBC.ToString().Length - 2, "-");

            dr["SoPhieu"] = _ctdcbd.MaCTDCBD.ToString().Insert(_ctdcbd.MaCTDCBD.ToString().Length - 2, "-");
            dr["ThongTin"] = _ctdcbd.ThongTin;
            dr["HieuLucKy"] = _ctdcbd.HieuLucKy;
            dr["Dot"] = _ctdcbd.Dot;
            ///Hiện tại xử lý mã số thuế như vậy
            if (_ctdcbd.CatMSThue)
                dr["MSThue"] = "MST: Cắt MST";
            if (!string.IsNullOrEmpty(_ctdcbd.MSThue_BD))
                dr["MSThue"] = "MST: " + _ctdcbd.MSThue_BD;
            dr["DanhBo"] = _ctdcbd.DanhBo.Insert(7, " ").Insert(4, " ");
            dr["HopDong"] = _ctdcbd.HopDong;
            dr["HoTen"] = _ctdcbd.HoTen;
            dr["DiaChi"] = _ctdcbd.DiaChi;
            if (_ctdcbd.XoaDiaChiLienHe == true)
                dr["XoaDiaChiLienHe"] = "Xóa Địa Chỉ Liên Hệ";
            dr["MaQuanPhuong"] = _ctdcbd.MaQuanPhuong;
            dr["GiaBieu"] = _ctdcbd.GiaBieu;
            dr["DinhMuc"] = _ctdcbd.DinhMuc;
            ///Biến Động
            dr["HoTenBD"] = _ctdcbd.HoTen_BD;
            dr["DiaChiBD"] = _ctdcbd.DiaChi_BD;
            dr["GiaBieuBD"] = _ctdcbd.GiaBieu_BD;
            dr["DinhMucBD"] = _ctdcbd.DinhMuc_BD;
            if (!string.IsNullOrEmpty(_ctdcbd.SH_BD))
                dr["TyLe"] = "Tỷ Lệ SH: " + _ctdcbd.SH_BD + "%";

            if (!string.IsNullOrEmpty(_ctdcbd.SX_BD))
                if (string.IsNullOrEmpty(dr["TyLe"].ToString()))
                    dr["TyLe"] = "Tỷ Lệ SX: " + _ctdcbd.SX_BD + "%";
                else
                    dr["TyLe"] += ", SX: " + _ctdcbd.SX_BD + "%";

            if (!string.IsNullOrEmpty(_ctdcbd.DV_BD))
                if (string.IsNullOrEmpty(dr["TyLe"].ToString()))
                    dr["TyLe"] = "Tỷ Lệ DV: " + _ctdcbd.DV_BD + "%";
                else
                    dr["TyLe"] += ", DV: " + _ctdcbd.DV_BD + "%";

            if (!string.IsNullOrEmpty(_ctdcbd.HCSN_BD))
                if (string.IsNullOrEmpty(dr["TyLe"].ToString()))
                    dr["TyLe"] = "Tỷ Lệ HCSN: " + _ctdcbd.HCSN_BD + "%";
                else
                    dr["TyLe"] += ", HCSN: " + _ctdcbd.HCSN_BD + "%";
            ///Ký Tên
            if (_ctdcbd.DMGiuNguyen)
                dr["KhongBD"] = "ĐM Giữ Nguyên";
            else
                if (_ctdcbd.GBGiuNguyen)
                    dr["KhongBD"] = "GB Giữ Nguyên";
                else
                    if (_ctdcbd.GiaHanKT3)
                        dr["KhongBD"] = "Gia Hạn KT3";
                    else
                        if (_ctdcbd.GiaHanNhapCu)
                            dr["KhongBD"] = "Gia Hạn Nhập Cư";
                        else
                        {
                            dr["ChucVu"] = _ctdcbd.ChucVu;
                            dr["NguoiKy"] = _ctdcbd.NguoiKy;
                        }

            dsBaoCao.Tables["DCBD"].Rows.Add(dr);

            rptPhieuDCBD rpt = new rptPhieuDCBD();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        #region DataTransfer

        private void Them()
        {
            CDataTransfer dataT = new CDataTransfer();
            if (_dontkh != null)
            {
                dataT.Loai = "TKH";
                dataT.MaDon = _dontkh.MaDon;
                dataT.MaDonMoi = _dontkh.MaDonMoi;
            }
            else
                if (_dontxl != null)
                {
                    dataT.Loai = "TXL";
                    dataT.MaDon = _dontxl.MaDon;
                    dataT.MaDonMoi = _dontxl.MaDonMoi;
                }
                else
                    if (_dontbc != null)
                    {
                        dataT.Loai = "TBC";
                        dataT.MaDon = _dontbc.MaDon;
                        dataT.MaDonMoi = _dontbc.MaDonMoi;
                    }
            dataT.DanhBo = txtDanhBo.Text.Trim();
            if (txtHoTen_BD.Text.Trim() == "")
                dataT.HoTen = txtHoTen.Text.Trim();
            else
                dataT.HoTen = txtHoTen_BD.Text.Trim();
            if (txtDiaChi_BD.Text.Trim() == "")
                if (txtDiaChi.Text.Trim().Contains(","))
                    dataT.DiaChi = txtDiaChi.Text.Trim().Substring(0, txtDiaChi.Text.Trim().IndexOf(","));
                else
                    dataT.DiaChi = txtDiaChi.Text.Trim();
            else
                dataT.DiaChi = txtDiaChi_BD.Text.Trim();
            //dataT.MaCT = "";
            //dataT.MaLCT = "";

            frmSoDK frm = new frmSoDK(dataT);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvDSSoDangKy.DataSource = _cChungTu.GetDSCT(txtDanhBo.Text.Trim());
                LoadTongNK();
            }
        }

        private void Sua()
        {
            CDataTransfer dataT = new CDataTransfer();
            if (_dontkh != null)
            {
                dataT.Loai = "TKH";
                dataT.MaDon = _dontkh.MaDon;
                dataT.MaDonMoi = _dontkh.MaDonMoi;
            }
            else
                if (_dontxl != null)
                {
                    dataT.Loai = "TXL";
                    dataT.MaDon = _dontxl.MaDon;
                    dataT.MaDonMoi = _dontxl.MaDonMoi;
                }
                else
                    if (_dontbc != null)
                    {
                        dataT.Loai = "TBC";
                        dataT.MaDon = _dontbc.MaDon;
                        dataT.MaDonMoi = _dontbc.MaDonMoi;
                    }
            dataT.DanhBo = txtDanhBo.Text.Trim();
            if (txtHoTen_BD.Text.Trim() == "")
                dataT.HoTen = txtHoTen.Text.Trim();
            else
                dataT.HoTen = txtHoTen_BD.Text.Trim();
            dataT.MaCT = dgvDSSoDangKy.CurrentRow.Cells["MaCT"].Value.ToString();
            dataT.MaLCT = int.Parse(dgvDSSoDangKy.CurrentRow.Cells["MaLCT"].Value.ToString());

            frmSoDK frm = new frmSoDK(dataT);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvDSSoDangKy.DataSource = _cChungTu.GetDSCT(txtDanhBo.Text.Trim());
                LoadTongNK();
            }
        }

        private void Nhan()
        {
            CDataTransfer dataT = new CDataTransfer();
            if (_dontkh != null)
            {
                dataT.Loai = "TKH";
                dataT.MaDon = _dontkh.MaDon;
                dataT.MaDonMoi = _dontkh.MaDonMoi;
            }
            else
                if (_dontxl != null)
                {
                    dataT.Loai = "TXL";
                    dataT.MaDon = _dontxl.MaDon;
                    dataT.MaDonMoi = _dontxl.MaDonMoi;
                }
                else
                    if (_dontbc != null)
                    {
                        dataT.Loai = "TBC";
                        dataT.MaDon = _dontbc.MaDon;
                        dataT.MaDonMoi = _dontbc.MaDonMoi;
                    }
            dataT.DanhBo = txtDanhBo.Text.Trim();
            if (txtHoTen_BD.Text.Trim() == "")
                dataT.HoTen = txtHoTen.Text.Trim();
            else
                dataT.HoTen = txtHoTen_BD.Text.Trim();
            if (txtDiaChi_BD.Text.Trim() == "")
                if (txtDiaChi.Text.Trim().Contains(","))
                    dataT.DiaChi = txtDiaChi.Text.Trim().Substring(0, txtDiaChi.Text.Trim().IndexOf(","));
                else
                    dataT.DiaChi = txtDiaChi.Text.Trim();
            else
                dataT.DiaChi = txtDiaChi_BD.Text.Trim();

            frmNhanDM frm = new frmNhanDM(dataT);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvDSSoDangKy.DataSource = _cChungTu.GetDSCT(txtDanhBo.Text.Trim());
                LoadTongNK();
            }
        }

        private void CatChuyen()
        {
            CDataTransfer dataT = new CDataTransfer();
            if (_dontkh != null)
            {
                dataT.Loai = "TKH";
                dataT.MaDon = _dontkh.MaDon;
                dataT.MaDonMoi = _dontkh.MaDonMoi;
            }
            else
                if (_dontxl != null)
                {
                    dataT.Loai = "TXL";
                    dataT.MaDon = _dontxl.MaDon;
                    dataT.MaDonMoi = _dontxl.MaDonMoi;
                }
                else
                    if (_dontbc != null)
                    {
                        dataT.Loai = "TBC";
                        dataT.MaDon = _dontbc.MaDon;
                        dataT.MaDonMoi = _dontbc.MaDonMoi;
                    }
            dataT.DanhBo = txtDanhBo.Text.Trim();

            if (txtHoTen_BD.Text.Trim() == "")
                dataT.HoTen = txtHoTen.Text.Trim();
            else
                dataT.HoTen = txtHoTen_BD.Text.Trim();
            dataT.MaCT = dgvDSSoDangKy.CurrentRow.Cells["MaCT"].Value.ToString();
            dataT.MaLCT = int.Parse(dgvDSSoDangKy.CurrentRow.Cells["MaLCT"].Value.ToString());

            frmCatChuyenDM frm = new frmCatChuyenDM(dataT);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvDSSoDangKy.DataSource = _cChungTu.GetDSCT(txtDanhBo.Text.Trim());
                LoadTongNK();
            }
        }

        #endregion

        private void btnNhapNhieuGB_Click(object sender, EventArgs e)
        {
            frmNhapNhieuGB frm = new frmNhapNhieuGB();
            frm.ShowDialog();
        }
    }
}

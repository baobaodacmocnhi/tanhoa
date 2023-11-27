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
using KTKS_DonKH.GUI.DonTu;
using System.Transactions;
using KTKS_DonKH.wrThuongVu;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDCBD : Form
    {
        string _mnu = "mnuDCBD";
        CDonTu _cDonTu = new CDonTu();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CChungTu _cChungTu = new CChungTu();
        CThuTien _cThuTien = new CThuTien();
        CDCBD _cDCBD = new CDCBD();
        CKTXM _cKTXM = new CKTXM();
        CDHN _cDHN = new CDHN();
        CDocSo _cDocSo = new CDocSo();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        wsThuongVu _wsThuongVu = new wsThuongVu();

        DonTu_ChiTiet _dontu_ChiTiet = null;
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        DCBD_ChiTietBienDong _ctdcbd = null;
        bool _flagCtrl3 = false;
        bool _flagInsert = false;
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
            //dgvDSSoDangKy.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSSoDangKy.Font, FontStyle.Bold);
            //DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSSoDangKy.Columns["MaLCT"];
            //cmbColumn.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
            //cmbColumn.DisplayMember = "TenLCT";
            //cmbColumn.ValueMember = "MaLCT";

            dgvDSDieuChinh.AutoGenerateColumns = false;
            //dgvDSDieuChinh.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSDieuChinh.Font, FontStyle.Bold);

            dgvLichSuChungTu.AutoGenerateColumns = false;
            //dgvLichSuChungTu.ColumnHeadersDefaultCellStyle.Font = new Font(dgvLichSuChungTu.Font, FontStyle.Bold);

            dgvDSChungTu.AutoGenerateColumns = false;
            //dgvDSChungTu.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSChungTu.Font, FontStyle.Bold);

            dgvHinh.AutoGenerateColumns = false;

            if (_MaCTDCBD != -1)
            {
                txtSoPhieu.Text = _MaCTDCBD.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtSoPhieu_KeyPress(sender, arg);
            }

            lbDSHetHan.Text = _cChungTu.LoadDSCapDinhMucHetHan_CCCD().Rows.Count.ToString() + " cccd sắp hết hạn";
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
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDHN.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
            txtDiaChi_XuatHoaDon.Text = _cDCBD.getDiaChiXuatHoaDon(hoadon.DANHBA);
            txtMSThue.Text = hoadon.MST;
            txtGiaBieu.Text = hoadon.GB.ToString();
            txtDinhMucHN.Text = hoadon.DinhMucHN.ToString();
            txtDinhMuc.Text = hoadon.DM.ToString();
            txtSH.Text = hoadon.TILESH.ToString();
            txtSX.Text = hoadon.TILESX.ToString();
            txtDV.Text = hoadon.TILEDV.ToString();
            txtHCSN.Text = hoadon.TILEHCSN.ToString();
            txtDot.Text = _cDHN.GetDot(hoadon.DANHBA);

            //kiểm tra phí bvmt
            string sohoadon = "";
            if (hoadon.SoHoaDonCu != null)
                sohoadon = hoadon.SoHoaDonCu;
            else
                sohoadon = hoadon.SOHOADON;
            //if (hoadon.PHI.Value == 0 && hoadon.TIEUTHU.Value != 0 && _cDCBD.checkExist_HoaDon(sohoadon) == false)
            //    lbKhongTinhPhiBVMT.Visible = true;
            //else
            //    lbKhongTinhPhiBVMT.Visible = false;
            if (_cDocSo.checkKhongTinhPBVMT(hoadon.DANHBA) == true)
                lbKhongTinhPhiBVMT.Visible = true;
            else
                lbKhongTinhPhiBVMT.Visible = false;
            dgvDSSoDangKy.DataSource = _cChungTu.getDS_ChiTiet_DanhBo(txtDanhBo.Text.Trim());
            dgvDSSoDangKy.CurrentCell = dgvDSSoDangKy.Rows[dgvDSSoDangKy.Rows.Count - 1].Cells[1];
            dgvDSDieuChinh.DataSource = _cDCBD.getDSDCBD(txtDanhBo.Text.Trim());
            if (dgvDSDieuChinh.Rows.Count > 0)
            {
                dgvDSDieuChinh.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                dgvDSDieuChinh.Rows[0].DefaultCellStyle.Font = new Font(dgvDSDieuChinh.DefaultCellStyle.Font, FontStyle.Bold);
            }
            LoadTongNK();
            if (_cDHN.CheckExist(hoadon.DANHBA) == false)
                MessageBox.Show("Danh Bộ Hủy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            chkNhaTro.Checked = _cDCBD.checkExist_NhaTro(hoadon.DANHBA);
        }

        private void LoadDCBD(DCBD_ChiTietBienDong ctdcbd)
        {
            if (ctdcbd.DCBD.MaDonMoi != null)
            {
                _dontu_ChiTiet = _cDonTu.get_ChiTiet(ctdcbd.DCBD.MaDonMoi.Value, ctdcbd.STT.Value);
                if (_dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count == 1)
                    txtMaDonMoi.Text = ctdcbd.DCBD.MaDonMoi.ToString();
                else
                    txtMaDonMoi.Text = ctdcbd.DCBD.MaDonMoi.Value.ToString() + "." + ctdcbd.STT.Value.ToString();
            }
            else
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
            txtCongDung.Text = ctdcbd.CongDung;
            txtDienThoai.Text = ctdcbd.DienThoai;
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
            if (ctdcbd.DinhMucHN != null)
                txtDinhMucHN.Text = ctdcbd.DinhMucHN.Value.ToString();
            else
                txtDinhMucHN.Text = "";
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
            if (ctdcbd.DinhMucHN_BD != null)
                txtDinhMucHN_BD.Text = ctdcbd.DinhMucHN_BD.Value.ToString();
            else
                txtDinhMucHN_BD.Text = "";
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
            chkTinhPhiBVMT.Checked = ctdcbd.TinhPhiBVMT;
            chkKhongTinhPhiBVMT.Checked = ctdcbd.KhongTinhPhiBVMT;
            chkChuaKTXM.Checked = ctdcbd.ChuaKTXM;
            ///
            dgvDSSoDangKy.DataSource = _cChungTu.getDS_ChiTiet_DanhBo(ctdcbd.DanhBo);
            dgvDSSoDangKy.CurrentCell = dgvDSSoDangKy.Rows[dgvDSSoDangKy.Rows.Count - 1].Cells[1];
            dgvDSDieuChinh.DataSource = _cDCBD.getDSDCBD(ctdcbd.DanhBo);
            if (dgvDSDieuChinh.Rows.Count > 0)
            {
                dgvDSDieuChinh.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                dgvDSDieuChinh.Rows[0].DefaultCellStyle.Font = new Font(dgvDSDieuChinh.DefaultCellStyle.Font, FontStyle.Bold);
            }
            LoadTongNK();

            dgvHinh.Rows.Clear();
            foreach (DCBD_ChiTietBienDong_Hinh item in ctdcbd.DCBD_ChiTietBienDong_Hinhs.ToList())
            {
                var index = dgvHinh.Rows.Add();
                dgvHinh.Rows[index].Cells["ID_Hinh"].Value = item.ID;
                dgvHinh.Rows[index].Cells["Name_Hinh"].Value = item.Name;
                if (item.Hinh != null)
                    dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(item.Hinh.ToArray());
                dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = item.Loai;
            }
        }

        private void Clear()
        {
            //txtMaDon.Text = "";
            //txtMaDonMoi.Text = "";
            txtSoPhieu.Text = "";
            txtDot.Text = "";
            txtHieuLucKy.Text = "";
            txtCongDung.Text = "";
            txtDienThoai.Text = "";
            txtGhiChu.Text = "";
            ///
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtDiaChi_XuatHoaDon.Text = "";
            txtMSThue.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMucHN.Text = "";
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
            chkTinhPhiBVMT.Checked = false;
            chkKhongTinhPhiBVMT.Checked = false;
            chkChuaKTXM.Checked = false;
            chkNhaTro.Checked = false;
            ///
            txtHoTen_BD.Text = "";
            txtDiaChi_BD.Text = "";
            txtMSThue_BD.Text = "";
            txtGiaBieu_BD.Text = "";
            txtDinhMucHN_BD.Text = "";
            txtDinhMuc_BD.Text = "";
            txtSH_BD.Text = "";
            txtSX_BD.Text = "";
            txtDV_BD.Text = "";
            txtHCSN_BD.Text = "";
            lbTongNK.Text = "";
            lbTongDM.Text = "";
            lbKhongTinhPhiBVMT.Visible = false;
            ///
            _dontu_ChiTiet = null;
            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            _ctdcbd = null;
            _MaCTDCBD = -1;
            _flagInsert = false;
            ///
            dgvDSSoDangKy.DataSource = null;
            dgvDSDieuChinh.DataSource = null;
            dgvLichSuChungTu.DataSource = null;
            dgvDSChungTu.DataSource = null;
            dgvHinh.Rows.Clear();

            txtMaDonMoi.Focus();
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
                                LoadTTKH(_hoadon);
                                txtMaDonMoi.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtMaDonMoi.Focus();
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
                                    txtMaDonMoi.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtMaDonMoi.Focus();
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
                                    txtMaDonMoi.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtMaDonMoi.Focus();
                                }
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
                            txtDanhBo.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDanhBo.Focus();
                        }
                    }
                    else
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    txtDanhBo.Focus();
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                if (_hoadon != null)
                {
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
            {
                string MaDon = txtSoPhieu.Text.Trim();
                Clear();
                txtSoPhieu.Text = MaDon;
                _ctdcbd = _cDCBD.getBienDong(decimal.Parse(txtSoPhieu.Text.Trim().Replace("-", "")));
                if (_ctdcbd != null)
                {
                    LoadDCBD(_ctdcbd);
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

                    DCBD_ChiTietBienDong ctdcbd = new DCBD_ChiTietBienDong();

                    if (_dontu_ChiTiet != null)
                    {
                        if (_cDCBD.checkExist(_dontu_ChiTiet.MaDon.Value) == false)
                        {
                            DCBD dcbd = new DCBD();
                            dcbd.MaDonMoi = _dontu_ChiTiet.MaDon.Value;
                            _cDCBD.Them(dcbd);
                        }
                        if (chkBoQuaKiemTraTrung.Checked == false && _cDCBD.checkExist_BienDong(_dontu_ChiTiet.MaDon.Value, txtDanhBo.Text.Trim()) == true)
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Biến Động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ctdcbd.MaDCBD = _cDCBD.get(_dontu_ChiTiet.MaDon.Value).MaDCBD;
                        ctdcbd.STT = _dontu_ChiTiet.STT.Value;
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
                    if (!string.IsNullOrEmpty(txtDinhMucHN.Text.Trim()))
                        ctdcbd.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                    else
                        ctdcbd.DinhMucHN = null;
                    ctdcbd.SH = txtSH.Text.Trim();
                    ctdcbd.SX = txtSX.Text.Trim();
                    ctdcbd.DV = txtDV.Text.Trim();
                    ctdcbd.HCSN = txtHCSN.Text.Trim();
                    ctdcbd.Dot = txtDot.Text.Trim();
                    ctdcbd.HieuLucKy = txtHieuLucKy.Text.Trim();
                    ctdcbd.CongDung = txtCongDung.Text.Trim();
                    ctdcbd.DienThoai = txtDienThoai.Text.Trim();
                    ctdcbd.GhiChu = txtGhiChu.Text.Trim();
                    ctdcbd.ChuaKTXM = chkChuaKTXM.Checked;

                    ///Biến lưu Điều Chỉnh về gì (Họ Tên,Địa Chỉ,Định Mức,Giá Biểu,MSThuế)
                    string ThongTin = "";
                    ///Họ Tên
                    if (txtHoTen_BD.Text.Trim() != "")
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Tên";
                        else
                            ThongTin += ". Tên";
                        ctdcbd.HoTen_BD = txtHoTen_BD.Text.Trim();
                    }
                    ///Địa Chỉ
                    if (txtDiaChi_BD.Text.Trim() != "")
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Địa Chỉ";
                        else
                            ThongTin += ". Địa Chỉ";
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
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "MST";
                        else
                            ThongTin += ". MST";
                        ctdcbd.MSThue_BD = txtMSThue_BD.Text.Trim();
                    }
                    if (chkCatMSThue.Checked)
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Cắt MST";
                        else
                            ThongTin += ". Cắt MST";
                        ctdcbd.CatMSThue = true;
                    }
                    ///Giá Biểu
                    if (txtGiaBieu_BD.Text.Trim() != "")
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Giá Biểu";
                        else
                            ThongTin += ". Giá Biểu";
                        ctdcbd.GiaBieu_BD = int.Parse(txtGiaBieu_BD.Text.Trim());
                    }
                    ///Định Mức
                    if (txtDinhMuc_BD.Text.Trim() != "" && txtDinhMuc.Text.Trim() != txtDinhMuc_BD.Text.Trim())
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Định Mức";
                        else
                            ThongTin += ". Định Mức";
                        ctdcbd.DinhMuc_BD = int.Parse(txtDinhMuc_BD.Text.Trim());
                    }
                    if (txtDinhMucHN_BD.Text.Trim() != "" && txtDinhMucHN_BD.Text.Trim() != txtDinhMucHN.Text.Trim())
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Định Mức Nghèo";
                        else
                            ThongTin += ". Định Mức Nghèo";
                        ctdcbd.DinhMucHN_BD = int.Parse(txtDinhMucHN_BD.Text.Trim());
                    }
                    if (txtSH_BD.Text.Trim() != "" || txtSX_BD.Text.Trim() != "" || txtDV_BD.Text.Trim() != "" || txtHCSN_BD.Text.Trim() != "")
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Tỷ Lệ";
                        else
                            ThongTin += ". Tỷ Lệ";
                    }
                    if (chkTinhPhiBVMT.Checked)
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Tính Phí BVMT";
                        else
                            ThongTin += ". Tính Phí BVMT";
                        ctdcbd.TinhPhiBVMT = true;
                    }
                    if (chkKhongTinhPhiBVMT.Checked)
                    {
                        if (string.IsNullOrEmpty(ThongTin) == true)
                            ThongTin += "Không Tính Phí BVMT";
                        else
                            ThongTin += ". Không Tính Phí BVMT";
                        ctdcbd.KhongTinhPhiBVMT = true;
                    }
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
                        //BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        //if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                        //    ctdcbd.ChucVu = "GIÁM ĐỐC";
                        //else
                        //    ctdcbd.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        //ctdcbd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        ctdcbd.PhieuDuocKy = true;
                    }
                    if (chkNhaTro.Checked)
                        _cDCBD.them_NhaTro(ctdcbd.DanhBo);
                    else
                        _cDCBD.xoa_NhaTro(ctdcbd.DanhBo);
                    //không chạy transaction đc vì hàm xử lý hiệu lực kỳ
                    //using (TransactionScope scope = new TransactionScope())
                    if (_cDCBD.ThemDCBD(ctdcbd))
                    {
                        foreach (DataGridViewRow item in dgvHinh.Rows)
                        {
                            DCBD_ChiTietBienDong_Hinh en = new DCBD_ChiTietBienDong_Hinh();
                            en.IDDCBD_ChiTietBienDong = ctdcbd.MaCTDCBD;
                            en.Name = item.Cells["Name_Hinh"].Value.ToString();
                            //en.Hinh = Convert.FromBase64String(item.Cells["Bytes_Hinh"].Value.ToString());
                            en.Loai = item.Cells["Loai_Hinh"].Value.ToString();
                            if (_wsThuongVu.ghi_Hinh("DCBD_ChiTietBienDong_Hinh", en.IDDCBD_ChiTietBienDong.Value.ToString(), en.Name + en.Loai, Convert.FromBase64String(item.Cells["Bytes_Hinh"].Value.ToString())) == true)
                                _cDCBD.Them_Hinh(en);
                        }
                        if (_dontu_ChiTiet != null)
                        {
                            if (_cDonTu.Them_LichSu(ctdcbd.CreateDate.Value, "DCBD", "Đã Điều Chỉnh Biến Động, " + ctdcbd.ThongTin, (int)ctdcbd.MaCTDCBD, _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value) == true)
                            {
                                //scope.Complete();
                            }
                        }
                        //else
                        //scope.Complete();
                        string error = "";
                        bool flag = false;
                        if (ctdcbd.ThongTin.Contains("Tên") && _dontu_ChiTiet.CreateDate.Value.Date >= new DateTime(2023, 09, 11))
                        {
                            wrEContract.wsEContract ws = new wrEContract.wsEContract();
                            flag = ws.editEContract(ctdcbd.DCBD.MaDonMoi.Value.ToString(), "", "tanho@2022", out error);
                            if (flag)
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Lỗi EContract " + error, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
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
                        if (!string.IsNullOrEmpty(txtDinhMucHN.Text.Trim()))
                            _ctdcbd.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                        else
                            _ctdcbd.DinhMucHN = null;
                        _ctdcbd.SH = txtSH.Text.Trim();
                        _ctdcbd.SX = txtSX.Text.Trim();
                        _ctdcbd.DV = txtDV.Text.Trim();
                        _ctdcbd.HCSN = txtHCSN.Text.Trim();
                        _ctdcbd.Dot = txtDot.Text.Trim();
                        _ctdcbd.HieuLucKy = txtHieuLucKy.Text.Trim();
                        _ctdcbd.CongDung = txtCongDung.Text.Trim();
                        _ctdcbd.DienThoai = txtDienThoai.Text.Trim();
                        _ctdcbd.GhiChu = txtGhiChu.Text.Trim();
                        _ctdcbd.ChuaKTXM = chkChuaKTXM.Checked;

                        ///Biến lưu Điều Chỉnh về gì (Họ Tên,Địa Chỉ,Định Mức,Giá Biểu,MSThuế)
                        string ThongTin = "";
                        ///Họ Tên
                        if (txtHoTen_BD.Text.Trim() != "")
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Tên";
                            else
                                ThongTin += ". Tên";
                            _ctdcbd.HoTen_BD = txtHoTen_BD.Text.Trim();
                        }
                        else
                            _ctdcbd.HoTen_BD = null;
                        ///Địa Chỉ
                        if (txtDiaChi_BD.Text.Trim() != "")
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Địa Chỉ";
                            else
                                ThongTin += ". Địa Chỉ";
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
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "MST";
                            else
                                ThongTin += ". MST";
                            _ctdcbd.MSThue_BD = txtMSThue_BD.Text.Trim();
                        }
                        else
                            _ctdcbd.MSThue_BD = null;
                        if (chkCatMSThue.Checked)
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Cắt MST";
                            else
                                ThongTin += ". Cắt MST";
                            _ctdcbd.CatMSThue = true;
                        }
                        else
                            _ctdcbd.CatMSThue = false;
                        ///Giá Biểu
                        if (txtGiaBieu_BD.Text.Trim() != "")
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Giá Biểu";
                            else
                                ThongTin += ". Giá Biểu";
                            _ctdcbd.GiaBieu_BD = int.Parse(txtGiaBieu_BD.Text.Trim());
                        }
                        else
                            _ctdcbd.GiaBieu_BD = null;
                        ///Định Mức
                        if (txtDinhMuc_BD.Text.Trim() != "")
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Định Mức";
                            else
                                ThongTin += ". Định Mức";
                            _ctdcbd.DinhMuc_BD = int.Parse(txtDinhMuc_BD.Text.Trim());
                        }
                        else
                            _ctdcbd.DinhMuc_BD = null;
                        if (txtDinhMucHN_BD.Text.Trim() != "")
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Định Mức Nghèo";
                            else
                                ThongTin += ". Định Mức Nghèo";
                            _ctdcbd.DinhMucHN_BD = int.Parse(txtDinhMucHN_BD.Text.Trim());
                        }
                        else
                            _ctdcbd.DinhMucHN_BD = null;
                        //tỷ lệ
                        if (txtSH_BD.Text.Trim() != "" || txtSX_BD.Text.Trim() != "" || txtDV_BD.Text.Trim() != "" || txtHCSN_BD.Text.Trim() != "")
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Tỷ Lệ";
                            else
                                ThongTin += ". Tỷ Lệ";
                        }
                        if (chkTinhPhiBVMT.Checked)
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Tính Phí BVMT";
                            else
                                ThongTin += ". Tính Phí BVMT";
                            _ctdcbd.TinhPhiBVMT = true;
                        }
                        if (chkKhongTinhPhiBVMT.Checked)
                        {
                            if (string.IsNullOrEmpty(ThongTin) == true)
                                ThongTin += "Không Tính Phí BVMT";
                            else
                                ThongTin += ". Không Tính Phí BVMT";
                            _ctdcbd.KhongTinhPhiBVMT = true;
                        }
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

                        if (chkDMGiuNguyen.Checked || chkGBGiuNguyen.Checked || chkGiaHanKT3.Checked || chkGiaHanNhapCu.Checked)
                        {
                            _ctdcbd.ChucVu = null;
                            _ctdcbd.NguoiKy = null;
                            _ctdcbd.PhieuDuocKy = false;
                        }
                        else
                        {
                            //BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            //if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            //    _ctdcbd.ChucVu = "GIÁM ĐỐC";
                            //else
                            //    _ctdcbd.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            //_ctdcbd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            _ctdcbd.PhieuDuocKy = true;
                        }
                        if (chkNhaTro.Checked)
                            _cDCBD.them_NhaTro(_ctdcbd.DanhBo);
                        else
                            _cDCBD.xoa_NhaTro(_ctdcbd.DanhBo);
                        if (_cDCBD.SuaDCBD(_ctdcbd))
                        {
                            string error = "";
                            bool flag = false;
                            if (_ctdcbd.ThongTin.Contains("Tên") && _dontu_ChiTiet.CreateDate.Value.Date >= new DateTime(2023, 09, 11))
                            {
                                wrEContract.wsEContract ws = new wrEContract.wsEContract();
                                flag = ws.editEContract(_ctdcbd.DCBD.MaDonMoi.Value.ToString(), "", "tanho@2022", out error);
                                if (flag)
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show("Lỗi EContract " + error, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
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
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (_ctdcbd != null && MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_ctdcbd.ChuyenDocSo == true)
                        {
                            MessageBox.Show("Đã có Chuyển Đọc Số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string flagID = _ctdcbd.MaCTDCBD.ToString();
                        var transactionOptions = new TransactionOptions();
                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                        {
                            DonTu_LichSu dtls = _cDonTu.get_LichSu("DCBD_ChiTietBienDong", (int)_ctdcbd.MaCTDCBD, _ctdcbd.CreateBy.Value);
                            if (dtls != null)
                            {
                                _cDonTu.Xoa_LichSu(dtls, true);
                            }
                            if (_cDCBD.XoaDCBD(_ctdcbd))
                            {
                                _wsThuongVu.xoa_Folder_Hinh("DCBD_ChiTietBienDong_Hinh", flagID);
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

        private int _searchIndex = -1;
        private string _searchNoiDung = "";

        private void GetNoiDungfrmTimKiem(string NoiDung)
        {
            if (_searchNoiDung != NoiDung)
                _searchIndex = -1;

            for (int i = 0; i < dgvDSSoDangKy.Rows.Count; i++)
            {
                if (_searchNoiDung != NoiDung)
                    _searchNoiDung = NoiDung;

                _searchIndex = (_searchIndex + 1) % dgvDSSoDangKy.Rows.Count;
                DataGridViewRow row = dgvDSSoDangKy.Rows[_searchIndex];
                if (row.Cells["MaCT"].Value == null)
                {
                    continue;
                }
                if (row.Cells["MaCT"].Value.ToString() == NoiDung)
                {
                    dgvDSSoDangKy.CurrentCell = row.Cells["MaCT"];
                    dgvDSSoDangKy.Rows[_searchIndex].Selected = true;
                    return;
                }
            }
        }

        private void frmDCBD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                switch (e.KeyCode)
                {
                    case Keys.Add://lưu
                        btnThem.PerformClick();
                        break;
                    case Keys.D1://mở form thêm sổ
                        if ((_dontu_ChiTiet != null || _dontkh != null || _dontxl != null || _dontbc != null))
                            Them();
                        break;
                    case Keys.D2://mở form nhận sổ
                        if ((_dontu_ChiTiet != null || _dontkh != null || _dontxl != null || _dontbc != null))
                            Nhan();
                        break;
                    case Keys.D3://mở rộng form 
                        if (!_flagCtrl3)
                        {
                            _flagCtrl3 = true;
                            groupBox_DSSoDangKy.Height = 358;
                            dgvDSSoDangKy.Height = 330;
                            panel_LichSuDieuChinh.Location = new Point(0, 581);
                        }
                        else
                        {
                            _flagCtrl3 = false;
                            groupBox_DSSoDangKy.Height = 229;
                            dgvDSSoDangKy.Height = 200;
                            panel_LichSuDieuChinh.Location = new Point(0, 455);
                        }
                        break;
                    case Keys.D4://mở form tìm kiếm chung cư
                        frmTimKiemChungTu frm = new frmTimKiemChungTu();
                        bool flag = false;
                        foreach (var item in this.OwnedForms)
                            if (item.Name == frm.Name)
                            {
                                item.Activate();
                                flag = true;
                            }
                        if (flag == false)
                        {
                            frm.MyGetNoiDung = new frmTimKiemChungTu.GetNoiDung(GetNoiDungfrmTimKiem);
                            frm.Owner = this;
                            frm.Show();
                        }
                        break;
                    //case Keys.D5://mở form cccd
                    //    frmCCCD frm1 = new frmCCCD(txtDanhBo.Text.Trim());
                    //    if (frm1.ShowDialog() == DialogResult.OK)
                    //        dgvDSSoDangKy.DataSource = _cChungTu.getDS_ChiTiet_DanhBo(txtDanhBo.Text.Trim());
                    //    break;
                    case Keys.T://mở form cập nhật tiến trình
                        if (_dontu_ChiTiet != null)
                        {
                            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                            {
                                frmCapNhatDonTu_Thumbnail frm2 = new frmCapNhatDonTu_Thumbnail(_dontu_ChiTiet, "DCBD_ChiTietBienDong", (int)_ctdcbd.MaCTDCBD);
                                frm2.ShowDialog();
                            }
                            else
                                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    default:
                        break;
                }
            //if (e.Control && e.KeyCode == Keys.Add)
            //    btnThem.PerformClick();
            //if ((_dontu_ChiTiet != null || _dontkh != null || _dontxl != null || _dontbc != null) && e.Control && e.KeyCode == Keys.D1)
            //{
            //    Them();
            //}
            //if ((_dontu_ChiTiet != null || _dontkh != null || _dontxl != null || _dontbc != null) && e.Control && e.KeyCode == Keys.D2)
            //{
            //    Nhan();
            //}
            //if (e.Control && e.KeyCode == Keys.D3)
            //{
            //    if (!_flagCtrl3)
            //    {
            //        _flagCtrl3 = true;
            //        groupBox_DSSoDangKy.Height = 358;
            //        dgvDSSoDangKy.Height = 330;
            //        panel_LichSuDieuChinh.Location = new Point(0, 560);
            //    }
            //    else
            //    {
            //        _flagCtrl3 = false;
            //        groupBox_DSSoDangKy.Height = 229;
            //        dgvDSSoDangKy.Height = 200;
            //        panel_LichSuDieuChinh.Location = new Point(0, 434);
            //    }
            //}
            //if (e.Control && e.KeyCode == Keys.D4)
            //{
            //    frmTimKiemChungTu frm = new frmTimKiemChungTu();
            //    frm.ShowDialog();
            //}
            //if (_dontu_ChiTiet != null && e.Control && e.KeyCode == Keys.T)
            //{
            //    frmCapNhatDonTu_Thumbnail frm = new frmCapNhatDonTu_Thumbnail(_dontu_ChiTiet);
            //    frm.ShowDialog();
            //}
        }

        private void lbDSHetHan_DoubleClick(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = _cChungTu.LoadDSCapDinhMucHetHan_CCCD();

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
                        string a = _cDCBD.getMaBienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
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
                        dr["Phuong"] = _cDonTu.getTenPhuong(int.Parse(hoadon.Quan), int.Parse(hoadon.Phuong));
                        dr["Quan"] = _cDonTu.getTenQuan(int.Parse(hoadon.Quan));
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
                if (_dontu_ChiTiet != null || _dontkh != null || _dontxl != null || _dontbc != null)
                    Them();
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                if (_dontu_ChiTiet != null || _dontkh != null || _dontxl != null || _dontbc != null)
                    Sua();
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cắtChuyểnĐịnhMứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                if (_dontu_ChiTiet != null || _dontkh != null || _dontxl != null || _dontbc != null)
                    CatChuyen();
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void nhậnĐịnhMứctoolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                if (_dontu_ChiTiet != null || _dontkh != null || _dontxl != null || _dontbc != null)
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
                    if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        ChungTu_ChiTiet ctchungtu = _cChungTu.GetCT(txtDanhBo.Text.Trim(), dgvDSSoDangKy.CurrentRow.Cells["MaCT"].Value.ToString(), int.Parse(dgvDSSoDangKy.CurrentRow.Cells["MaLCT"].Value.ToString()));
                        if (_cChungTu.XoaCT(ctchungtu))
                        {
                            dgvDSSoDangKy.DataSource = _cChungTu.getDS_ChiTiet_DanhBo(txtDanhBo.Text.Trim());
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
            if (dgvDSSoDangKy.Rows[e.RowIndex].Cells["Cat"].Value != null && dgvDSSoDangKy.Rows[e.RowIndex].Cells["Cat"].Value.ToString() != "" && bool.Parse(dgvDSSoDangKy.Rows[e.RowIndex].Cells["Cat"].Value.ToString()) == true)
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
            if (e.Button == MouseButtons.Right && (_dontu_ChiTiet != null || _dontkh != null || _dontxl != null || _dontbc != null))
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
            try
            {
                if (dgvDSSoDangKy.Columns[e.ColumnIndex].Name == "MaCT")
                {
                    if (dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString().Trim().Length != 12)
                    {
                        MessageBox.Show("CCCD gồm 12 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ///Kiểm tra Danh Bộ & Số Chứng Từ
                    if (_cChungTu.CheckExist_CT(_hoadon.DANHBA, dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString().Trim(), 15))
                    {
                        MessageBox.Show("Số đăng ký này đã đăng ký với Danh Bộ này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        if (_cChungTu.CheckExist_CT(dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString().Trim(), 15))
                        {
                            MessageBox.Show("Đã đăng ký với Danh Bộ " + _cChungTu.getDS_ChiTiet(dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString().Trim(), 15).Rows[0]["DanhBo"].ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    ChungTu ct = _cChungTu.Get(dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString(), 15);
                    if (ct != null)
                    {
                        dgvDSSoDangKy["HoTen", e.RowIndex].Value = ct.HoTen;
                        dgvDSSoDangKy["DiaChi", e.RowIndex].Value = ct.DiaChi;
                        dgvDSSoDangKy["NgaySinh", e.RowIndex].Value = ct.NgaySinh.Value.ToString("dd/MM/yyyy");
                    }
                    dgvDSChungTu.DataSource = _cChungTu.getDS_ChiTiet(dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString(), 15);
                    dgvLichSuChungTu.DataSource = _cChungTu.LoadDSLichSuChungTubyID(dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString(), 15);
                }
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (dgvDSSoDangKy["DanhBo", e.RowIndex].Value != null && dgvDSSoDangKy["MaCT", e.RowIndex].Value != null && dgvDSSoDangKy["DanhBo", e.RowIndex].Value.ToString() != "" && dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString() != "")
                    {
                        ///Hiện tại nếu check Cat mà exit bằng X thì dữ liệu không được lưu
                        ///Sau khi check phải check qua chỗ khác mới lưu
                        ChungTu_ChiTiet ctchungtu = _cChungTu.GetCT(dgvDSSoDangKy["DanhBo", e.RowIndex].Value.ToString(), dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString(), int.Parse(dgvDSSoDangKy["MaLCT", e.RowIndex].Value.ToString()));
                        if (dgvDSSoDangKy.Columns[e.ColumnIndex].Name == "HoTen")
                            if (dgvDSSoDangKy["HoTen", e.RowIndex].Value.ToString() != ctchungtu.ChungTu.HoTen)
                            {
                                ctchungtu.ChungTu.HoTen = dgvDSSoDangKy["HoTen", e.RowIndex].Value.ToString();
                                _cChungTu.SuaCT(ctchungtu);
                            }
                        if (dgvDSSoDangKy.Columns[e.ColumnIndex].Name == "DiaChi")
                            if (dgvDSSoDangKy["DiaChi", e.RowIndex].Value.ToString() != ctchungtu.ChungTu.DiaChi)
                            {
                                ctchungtu.ChungTu.DiaChi = dgvDSSoDangKy["DiaChi", e.RowIndex].Value.ToString();
                                _cChungTu.SuaCT(ctchungtu);
                            }
                        if (dgvDSSoDangKy.Columns[e.ColumnIndex].Name == "NgaySinh")
                        {
                            string[] NgaySinhs = null;
                            string NgaySinh = "";
                            if (dgvDSSoDangKy["NgaySinh", e.RowIndex].Value.ToString().Trim().Contains(" "))
                                NgaySinh = dgvDSSoDangKy["NgaySinh", e.RowIndex].Value.ToString().Trim().Substring(0, dgvDSSoDangKy["NgaySinh", e.RowIndex].Value.ToString().Trim().IndexOf(" "));
                            else
                                NgaySinh = dgvDSSoDangKy["NgaySinh", e.RowIndex].Value.ToString().Trim();
                            if (NgaySinh.Contains("/"))
                                NgaySinhs = NgaySinh.Split('/');
                            else
                                if (NgaySinh.Contains("-"))
                                    NgaySinhs = NgaySinh.Split('-');
                            if (NgaySinhs != null && NgaySinhs.Count() == 3)
                            {
                                ctchungtu.ChungTu.NgaySinh = new DateTime(int.Parse(NgaySinhs[2]), int.Parse(NgaySinhs[1]), int.Parse(NgaySinhs[0]));
                            }
                            else
                                ctchungtu.ChungTu.NgaySinh = new DateTime(int.Parse(NgaySinh), 1, 1);
                            _cChungTu.SuaCT(ctchungtu);
                        }
                        if (dgvDSSoDangKy.Columns[e.ColumnIndex].Name == "KhacDiaBan")
                            if (bool.Parse(dgvDSSoDangKy["KhacDiaBan", e.RowIndex].Value.ToString()) != ctchungtu.ChungTu.KhacDiaBan)
                            {
                                ctchungtu.ChungTu.KhacDiaBan = bool.Parse(dgvDSSoDangKy["KhacDiaBan", e.RowIndex].Value.ToString());
                                _cChungTu.SuaCT(ctchungtu);
                            }
                        if (dgvDSSoDangKy.Columns[e.ColumnIndex].Name == "ThuongTru")
                            if (bool.Parse(dgvDSSoDangKy["ThuongTru", e.RowIndex].Value.ToString()) != ctchungtu.ThuongTru)
                            {
                                ctchungtu.ThuongTru = bool.Parse(dgvDSSoDangKy["ThuongTru", e.RowIndex].Value.ToString());
                                _cChungTu.SuaCT(ctchungtu);
                            }
                        if (dgvDSSoDangKy.Columns[e.ColumnIndex].Name == "TamTru")
                            if (bool.Parse(dgvDSSoDangKy["TamTru", e.RowIndex].Value.ToString()) != ctchungtu.TamTru)
                            {
                                ctchungtu.TamTru = bool.Parse(dgvDSSoDangKy["TamTru", e.RowIndex].Value.ToString());
                                _cChungTu.SuaCT(ctchungtu);
                            }
                        if (dgvDSSoDangKy.Columns[e.ColumnIndex].Name == "NgayHetHan")
                        {
                            string[] NgayHetHans = null;
                            string NgayHetHan = "";
                            if (dgvDSSoDangKy["NgayHetHan", e.RowIndex].Value.ToString().Trim().Contains(" "))
                                NgayHetHan = dgvDSSoDangKy["NgayHetHan", e.RowIndex].Value.ToString().Trim().Substring(0, dgvDSSoDangKy["NgayHetHan", e.RowIndex].Value.ToString().Trim().IndexOf(" "));
                            else
                                NgayHetHan = dgvDSSoDangKy["NgayHetHan", e.RowIndex].Value.ToString().Trim();

                            if (NgayHetHan.Contains("/"))
                                NgayHetHans = NgayHetHan.Split('/');
                            else
                                if (NgayHetHan.Contains("-"))
                                    NgayHetHans = NgayHetHan.Split('-');
                            if (NgayHetHans.Count() == 3)
                            {
                                ctchungtu.NgayHetHan = new DateTime(int.Parse(NgayHetHans[2]), int.Parse(NgayHetHans[1]), int.Parse(NgayHetHans[0]));
                            }
                            _cChungTu.SuaCT(ctchungtu);
                        }
                        if (dgvDSSoDangKy.Columns[e.ColumnIndex].Name == "Cat")
                            if (bool.Parse(dgvDSSoDangKy["Cat", e.RowIndex].Value.ToString()) != ctchungtu.Cat)
                            {
                                ctchungtu.Cat = bool.Parse(dgvDSSoDangKy["Cat", e.RowIndex].Value.ToString());
                                if (ctchungtu.Cat)
                                    ctchungtu.Cat_Ngay = DateTime.Now;
                                else
                                    ctchungtu.Cat_Ngay = null;
                                _cChungTu.SuaCT(ctchungtu);
                            }
                        if (dgvDSSoDangKy.Columns[e.ColumnIndex].Name == "DienThoai")
                            if (dgvDSSoDangKy["DienThoai", e.RowIndex].Value.ToString() != ctchungtu.DienThoai)
                            {
                                ctchungtu.DienThoai = dgvDSSoDangKy["DienThoai", e.RowIndex].Value.ToString();
                                _cChungTu.SuaCT(ctchungtu);
                            }
                        //if (bool.Parse(dgvDSSoDangKy["GiaHan_SCT", e.RowIndex].Value.ToString()) != ctchungtu.GiaHan)
                        //{
                        //    ctchungtu.GiaHan = bool.Parse(dgvDSSoDangKy["GiaHan_SCT", e.RowIndex].Value.ToString());
                        //    _cChungTu.SuaCT(ctchungtu);
                        //}

                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ControlBox = true;
                contextMenuStrip1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDSSoDangKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvDSChungTu.DataSource = _cChungTu.getDS_ChiTiet(dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString(), int.Parse(dgvDSSoDangKy["MaLCT", e.RowIndex].Value.ToString()));
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
            //if (dgvDSDieuChinh.Columns[e.ColumnIndex].Name == "MaDon" && !string.IsNullOrEmpty(e.Value.ToString()))
            //{
            //    e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            //}
        }

        private void dgvDSDieuChinh_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvDSDieuChinh["DieuChinh", e.RowIndex].Value.ToString() == "Biến Động")
            {
                DCBD_ChiTietBienDong ctdcbd = _cDCBD.getBienDong(decimal.Parse(dgvDSDieuChinh["MaDC", e.RowIndex].Value.ToString()));
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
            {
                string[] str = txtHieuLucKy.Text.Split('/');
                if (str.Count() < 2)
                {
                    txtHieuLucKy.Text += "/" + DateTime.Now.Year;
                }
                txtHoTen_BD.Focus();
            }
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

        private void txtDinhMucHN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtHoTen_BD.Focus();
        }

        private void txtDinhMuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDinhMuc.Focus();
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

        private void txtDinhMucHN_BD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                dgvDSSoDangKy.Focus();
        }

        private void txtDinhMuc_BD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDinhMucHN_BD.Focus();
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

            //DCBD_ChiTietBienDong ctdcbd = _cDCBD.GetDCBDByMaCTDCBD(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));
            if (_ctdcbd.DCBD.MaDonMoi != null)
            {
                if (_ctdcbd.DCBD.DonTu.DonTu_ChiTiets.Count == 1)
                    dr["MaDon"] = _ctdcbd.DCBD.MaDonMoi.ToString();
                else
                    dr["MaDon"] = _ctdcbd.DCBD.MaDonMoi.ToString() + "." + _ctdcbd.STT;
            }
            else
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
            dr["DinhMucHN"] = _ctdcbd.DinhMucHN;
            ///Biến Động
            dr["HoTenBD"] = _ctdcbd.HoTen_BD;
            dr["DiaChiBD"] = _ctdcbd.DiaChi_BD;
            dr["GiaBieuBD"] = _ctdcbd.GiaBieu_BD;
            dr["DinhMucBD"] = _ctdcbd.DinhMuc_BD;
            dr["DinhMucHNBD"] = _ctdcbd.DinhMucHN_BD;
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
                            //dr["ChucVu"] = _ctdcbd.ChucVu;
                            //dr["NguoiKy"] = _ctdcbd.NguoiKy;
                            dr["ChucVu"] = "TUQ GIÁM ĐỐC\n" + CTaiKhoan.ChucVu.ToUpper().Replace("PHÒNG", "") + CTaiKhoan.TenPhong.ToUpper();
                            dr["NguoiKy"] = CTaiKhoan.NguoiKy.ToUpper();
                        }

            dsBaoCao.Tables["DCBD"].Rows.Add(dr);

            rptPhieuDCBD_15112019 rpt = new rptPhieuDCBD_15112019();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        #region DataTransfer

        private void Them()
        {
            CDataTransfer dataT = new CDataTransfer();
            if (_dontu_ChiTiet != null)
            {
                dataT.Loai = "MaDonMoi";
                dataT.MaDonMoi = _dontu_ChiTiet.MaDon.Value;
                dataT.STT = _dontu_ChiTiet.STT.Value;
            }
            else
                if (_dontkh != null)
                {
                    dataT.Loai = "TKH";
                    dataT.MaDon = _dontkh.MaDon;
                }
                else
                    if (_dontxl != null)
                    {
                        dataT.Loai = "TXL";
                        dataT.MaDon = _dontxl.MaDon;
                    }
                    else
                        if (_dontbc != null)
                        {
                            dataT.Loai = "TBC";
                            dataT.MaDon = _dontbc.MaDon;
                        }
            dataT.DanhBo = txtDanhBo.Text.Trim();
            if (txtHoTen_BD.Text.Trim() == "")
                dataT.HoTenDB = dataT.HoTen = txtHoTen.Text.Trim();
            else
                dataT.HoTenDB = dataT.HoTen = txtHoTen_BD.Text.Trim();
            if (txtDiaChi_BD.Text.Trim() == "")
                if (txtDiaChi.Text.Trim().Contains(","))
                    dataT.DiaChiDB = dataT.DiaChi = txtDiaChi.Text.Trim().Substring(0, txtDiaChi.Text.Trim().IndexOf(","));
                else
                    dataT.DiaChiDB = dataT.DiaChi = txtDiaChi.Text.Trim();
            else
                dataT.DiaChiDB = dataT.DiaChi = txtDiaChi_BD.Text.Trim();
            if (_hoadon != null)
            {
                dataT.Quan = _hoadon.Quan;
                dataT.Phuong = _hoadon.Phuong;
            }
            frmSoDK frm = new frmSoDK(dataT);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvDSSoDangKy.DataSource = _cChungTu.getDS_ChiTiet_DanhBo(txtDanhBo.Text.Trim());
                LoadTongNK();
            }
        }

        private void Sua()
        {
            CDataTransfer dataT = new CDataTransfer();
            if (_dontu_ChiTiet != null)
            {
                dataT.Loai = "MaDonMoi";
                dataT.MaDonMoi = _dontu_ChiTiet.MaDon.Value;
                dataT.STT = _dontu_ChiTiet.STT.Value;
            }
            else
                if (_dontkh != null)
                {
                    dataT.Loai = "TKH";
                    dataT.MaDon = _dontkh.MaDon;
                }
                else
                    if (_dontxl != null)
                    {
                        dataT.Loai = "TXL";
                        dataT.MaDon = _dontxl.MaDon;
                    }
                    else
                        if (_dontbc != null)
                        {
                            dataT.Loai = "TBC";
                            dataT.MaDon = _dontbc.MaDon;
                        }
            dataT.DanhBo = txtDanhBo.Text.Trim();
            if (txtHoTen_BD.Text.Trim() == "")
                dataT.HoTenDB = dataT.HoTen = txtHoTen.Text.Trim();
            else
                dataT.HoTenDB = dataT.HoTen = txtHoTen_BD.Text.Trim();
            if (txtDiaChi_BD.Text.Trim() == "")
                if (txtDiaChi.Text.Trim().Contains(","))
                    dataT.DiaChiDB = dataT.DiaChi = txtDiaChi.Text.Trim().Substring(0, txtDiaChi.Text.Trim().IndexOf(","));
                else
                    dataT.DiaChiDB = dataT.DiaChi = txtDiaChi.Text.Trim();
            else
                dataT.DiaChiDB = dataT.DiaChi = txtDiaChi_BD.Text.Trim();
            if (_hoadon != null)
            {
                dataT.Quan = _hoadon.Quan;
                dataT.Phuong = _hoadon.Phuong;
            }
            dataT.MaCT = dgvDSSoDangKy.CurrentRow.Cells["MaCT"].Value.ToString();
            dataT.MaLCT = int.Parse(dgvDSSoDangKy.CurrentRow.Cells["MaLCT"].Value.ToString());

            frmSoDK frm = new frmSoDK(dataT);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvDSSoDangKy.DataSource = _cChungTu.getDS_ChiTiet_DanhBo(txtDanhBo.Text.Trim());
                LoadTongNK();
            }
        }

        private void Nhan()
        {
            CDataTransfer dataT = new CDataTransfer();
            if (_dontu_ChiTiet != null)
            {
                dataT.Loai = "MaDonMoi";
                dataT.MaDonMoi = _dontu_ChiTiet.MaDon.Value;
                dataT.STT = _dontu_ChiTiet.STT.Value;
            }
            else
                if (_dontkh != null)
                {
                    dataT.Loai = "TKH";
                    dataT.MaDon = _dontkh.MaDon;
                }
                else
                    if (_dontxl != null)
                    {
                        dataT.Loai = "TXL";
                        dataT.MaDon = _dontxl.MaDon;
                    }
                    else
                        if (_dontbc != null)
                        {
                            dataT.Loai = "TBC";
                            dataT.MaDon = _dontbc.MaDon;
                        }
            dataT.DanhBo = txtDanhBo.Text.Trim();
            if (txtHoTen_BD.Text.Trim() == "")
                dataT.HoTenDB = dataT.HoTen = txtHoTen.Text.Trim();
            else
                dataT.HoTenDB = dataT.HoTen = txtHoTen_BD.Text.Trim();
            if (txtDiaChi_BD.Text.Trim() == "")
                if (txtDiaChi.Text.Trim().Contains(","))
                    dataT.DiaChiDB = dataT.DiaChi = txtDiaChi.Text.Trim().Substring(0, txtDiaChi.Text.Trim().IndexOf(","));
                else
                    dataT.DiaChiDB = dataT.DiaChi = txtDiaChi.Text.Trim();
            else
                dataT.DiaChiDB = dataT.DiaChi = txtDiaChi_BD.Text.Trim();
            if (_hoadon != null)
            {
                dataT.Quan = _hoadon.Quan;
                dataT.Phuong = _hoadon.Phuong;
            }

            frmNhanDM frm = new frmNhanDM(dataT);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvDSSoDangKy.DataSource = _cChungTu.getDS_ChiTiet_DanhBo(txtDanhBo.Text.Trim());
                LoadTongNK();
            }
        }

        private void CatChuyen()
        {
            CDataTransfer dataT = new CDataTransfer();
            if (_dontu_ChiTiet != null)
            {
                dataT.Loai = "MaDonMoi";
                dataT.MaDonMoi = _dontu_ChiTiet.MaDon.Value;
                dataT.STT = _dontu_ChiTiet.STT.Value;
            }
            else
                if (_dontkh != null)
                {
                    dataT.Loai = "TKH";
                    dataT.MaDon = _dontkh.MaDon;
                }
                else
                    if (_dontxl != null)
                    {
                        dataT.Loai = "TXL";
                        dataT.MaDon = _dontxl.MaDon;
                    }
                    else
                        if (_dontbc != null)
                        {
                            dataT.Loai = "TBC";
                            dataT.MaDon = _dontbc.MaDon;
                        }
            dataT.DanhBo = txtDanhBo.Text.Trim();
            if (txtHoTen_BD.Text.Trim() == "")
                dataT.HoTenDB = dataT.HoTen = txtHoTen.Text.Trim();
            else
                dataT.HoTenDB = dataT.HoTen = txtHoTen_BD.Text.Trim();
            if (txtDiaChi_BD.Text.Trim() == "")
                if (txtDiaChi.Text.Trim().Contains(","))
                    dataT.DiaChiDB = dataT.DiaChi = txtDiaChi.Text.Trim().Substring(0, txtDiaChi.Text.Trim().IndexOf(","));
                else
                    dataT.DiaChiDB = dataT.DiaChi = txtDiaChi.Text.Trim();
            else
                dataT.DiaChiDB = dataT.DiaChi = txtDiaChi_BD.Text.Trim();
            if (_hoadon != null)
            {
                dataT.Quan = _hoadon.Quan;
                dataT.Phuong = _hoadon.Phuong;
            }

            dataT.MaCT = dgvDSSoDangKy.CurrentRow.Cells["MaCT"].Value.ToString();
            dataT.MaLCT = int.Parse(dgvDSSoDangKy.CurrentRow.Cells["MaLCT"].Value.ToString());

            frmCatChuyenDM frm = new frmCatChuyenDM(dataT);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvDSSoDangKy.DataSource = _cChungTu.getDS_ChiTiet_DanhBo(txtDanhBo.Text.Trim());
                LoadTongNK();
            }
        }

        #endregion

        private void btnNhapNhieuGB_Click(object sender, EventArgs e)
        {
            frmNhapNhieuGB frm = new frmNhapNhieuGB();
            frm.ShowDialog();
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
                    if (_ctdcbd == null)
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
                            DCBD_ChiTietBienDong_Hinh en = new DCBD_ChiTietBienDong_Hinh();
                            en.IDDCBD_ChiTietBienDong = _ctdcbd.MaCTDCBD;
                            en.Name = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                            en.Loai = System.IO.Path.GetExtension(dialog.FileName);
                            if (_wsThuongVu.ghi_Hinh("DCBD_ChiTietBienDong_Hinh", en.IDDCBD_ChiTietBienDong.Value.ToString(), en.Name + en.Loai, bytes) == true)
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
            byte[] file = _wsThuongVu.get_Hinh("DCBD_ChiTietBienDong_Hinh", _ctdcbd.MaCTDCBD.ToString(), dgvHinh.CurrentRow.Cells["Name_Hinh"].Value.ToString() + dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString());
            if (file != null)
                if (dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString().ToLower().Contains("pdf"))
                    _cDCBD.viewPDF(1, file);
                else
                    _cDCBD.viewImage(file);
            else
                MessageBox.Show("File không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void xoaFile_dgvHinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctdcbd == null)
                    dgvHinh.Rows.RemoveAt(dgvHinh.CurrentRow.Index);
                else
                    if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                    {
                        if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (dgvHinh.CurrentRow.Cells["ID_Hinh"].Value != null)
                            {
                                if (_wsThuongVu.xoa_Hinh("DCBD_ChiTietBienDong_Hinh", _ctdcbd.MaCTDCBD.ToString(), dgvHinh.CurrentRow.Cells["Name_Hinh"].Value.ToString() + dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString()) == true)
                                    if (_cDCBD.Xoa_Hinh(_cDCBD.get_BienDong_Hinh(int.Parse(dgvHinh.CurrentRow.Cells["ID_Hinh"].Value.ToString()))))
                                    {
                                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        dgvHinh.Rows.RemoveAt(dgvHinh.CurrentRow.Index);
                                    }
                                    else
                                        MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvDSSoDangKy_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_flagInsert && dgvDSSoDangKy["DanhBo", e.RowIndex].Value != null && dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString() != ""
                    && dgvDSSoDangKy["MaCT", e.RowIndex].Value != null && dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString() != "")
                    if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                    {
                        if (dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString().Trim().Length != 12)
                        {
                            MessageBox.Show("CCCD gồm 12 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ///Kiểm tra Danh Bộ & Số Chứng Từ
                        if (_cChungTu.CheckExist_CT(_hoadon.DANHBA, dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString().Trim(), 15))
                        {
                            MessageBox.Show("Số đăng ký này đã đăng ký với Danh Bộ này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                            if (_cChungTu.CheckExist_CT(dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString().Trim(), 15))
                            {
                                MessageBox.Show("Đã đăng ký với Danh Bộ " + _cChungTu.getDS_ChiTiet(dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString().Trim(), 15).Rows[0]["DanhBo"].ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        ChungTu chungtu;
                        ///Kiểm tra Số Chứng Từ
                        if (_cChungTu.CheckExist(dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString().Trim(), 15) == false)
                        {
                            chungtu = new ChungTu();
                            chungtu.MaCT = dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString().Trim();
                            string[] NgaySinhs = null;
                            string NgaySinh = "";
                            if (dgvDSSoDangKy["NgaySinh", e.RowIndex].Value.ToString().Trim().Contains(" "))
                                NgaySinh = dgvDSSoDangKy["NgaySinh", e.RowIndex].Value.ToString().Trim().Substring(0, dgvDSSoDangKy["NgaySinh", e.RowIndex].Value.ToString().Trim().IndexOf(" "));
                            else
                                NgaySinh = dgvDSSoDangKy["NgaySinh", e.RowIndex].Value.ToString().Trim();
                            if (NgaySinh.Contains("/"))
                                NgaySinhs = NgaySinh.Split('/');
                            else
                                if (NgaySinh.Contains("-"))
                                    NgaySinhs = NgaySinh.Split('-');
                            if (NgaySinhs != null && NgaySinhs.Count() == 3)
                            {
                                chungtu.NgaySinh = new DateTime(int.Parse(NgaySinhs[2]), int.Parse(NgaySinhs[1]), int.Parse(NgaySinhs[0]));
                            }
                            else
                                chungtu.NgaySinh = new DateTime(int.Parse(NgaySinh), 1, 1);
                            chungtu.HoTen = dgvDSSoDangKy["HoTen", e.RowIndex].Value.ToString().Trim();
                            chungtu.DiaChi = dgvDSSoDangKy["DiaChi", e.RowIndex].Value.ToString().Trim();
                            chungtu.SoNKTong = 1;
                            chungtu.MaLCT = 15;
                            _cChungTu.Them(chungtu);
                        }
                        else
                        {
                            chungtu = _cChungTu.Get(dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString().Trim(), 15);
                            chungtu.HoTen = dgvDSSoDangKy["HoTen", e.RowIndex].Value.ToString().Trim();
                            chungtu.DiaChi = dgvDSSoDangKy["DiaChi", e.RowIndex].Value.ToString().Trim();
                            string[] NgaySinhs = null;

                            string NgaySinh = "";
                            if (dgvDSSoDangKy["NgaySinh", e.RowIndex].Value.ToString().Trim().Contains(" "))
                                NgaySinh = dgvDSSoDangKy["NgaySinh", e.RowIndex].Value.ToString().Trim().Substring(0, dgvDSSoDangKy["NgaySinh", e.RowIndex].Value.ToString().Trim().IndexOf(" "));
                            else
                                NgaySinh = dgvDSSoDangKy["NgaySinh", e.RowIndex].Value.ToString().Trim();
                            if (NgaySinh.Contains("/"))
                                NgaySinhs = NgaySinh.Split('/');
                            else
                                if (NgaySinh.Contains("-"))
                                    NgaySinhs = NgaySinh.Split('-');
                            if (NgaySinhs != null && NgaySinhs.Count() == 3)
                            {
                                chungtu.NgaySinh = new DateTime(int.Parse(NgaySinhs[2]), int.Parse(NgaySinhs[1]), int.Parse(NgaySinhs[0]));
                            }
                            else
                                chungtu.NgaySinh = new DateTime(int.Parse(NgaySinh), 1, 1);
                            _cChungTu.Sua(chungtu);
                        }
                        ChungTu_ChiTiet ctchungtu = new ChungTu_ChiTiet();
                        ctchungtu.DanhBo = txtDanhBo.Text.Trim();
                        ctchungtu.MaLCT = 15;
                        ctchungtu.MaCT = chungtu.MaCT;
                        ctchungtu.SoNKDangKy = 1;
                        if (dgvDSSoDangKy["NgayHetHan", e.RowIndex].Value != null && dgvDSSoDangKy["NgayHetHan", e.RowIndex].Value.ToString() != "")
                        {
                            string[] NgayHetHans = null;
                            string NgayHetHan = "";
                            if (dgvDSSoDangKy["NgayHetHan", e.RowIndex].Value.ToString().Trim().Contains(" "))
                                NgayHetHan = dgvDSSoDangKy["NgayHetHan", e.RowIndex].Value.ToString().Trim().Substring(0, dgvDSSoDangKy["NgayHetHan", e.RowIndex].Value.ToString().Trim().IndexOf(" "));
                            else
                                NgayHetHan = dgvDSSoDangKy["NgayHetHan", e.RowIndex].Value.ToString().Trim();

                            if (NgayHetHan.Contains("/"))
                                NgayHetHans = NgayHetHan.Split('/');
                            else
                                if (NgayHetHan.Contains("-"))
                                    NgayHetHans = NgayHetHan.Split('-');
                            if (NgayHetHans.Count() == 3)
                            {
                                ctchungtu.NgayHetHan = new DateTime(int.Parse(NgayHetHans[2]), int.Parse(NgayHetHans[1]), int.Parse(NgayHetHans[0]));
                            }
                        }
                        if (dgvDSSoDangKy["DienThoai", e.RowIndex].Value != null)
                            ctchungtu.DienThoai = dgvDSSoDangKy["DienThoai", e.RowIndex].Value.ToString().Trim();
                        if (dgvDSSoDangKy["GhiChu", e.RowIndex].Value != null)
                            ctchungtu.GhiChu = dgvDSSoDangKy["GhiChu", e.RowIndex].Value.ToString().Trim();
                        if (dgvDSSoDangKy["Lo", e.RowIndex].Value != null)
                            ctchungtu.Lo = dgvDSSoDangKy["Lo", e.RowIndex].Value.ToString().Trim();
                        if (dgvDSSoDangKy["Phong", e.RowIndex].Value != null)
                            ctchungtu.Phong = dgvDSSoDangKy["Phong", e.RowIndex].Value.ToString().Trim();
                        if (_hoadon != null)
                        {
                            ctchungtu.Phuong = _hoadon.Phuong;
                            ctchungtu.Quan = _hoadon.Quan;
                        }
                        if (_cChungTu.ThemCT(ctchungtu))
                        {
                            dgvDSSoDangKy["SoNKDangKy", e.RowIndex].Value = 1;
                            LoadTongNK();
                            ///Ghi thông tin Lịch Sử chung
                            ChungTu_LichSu lichsuchungtu = _cChungTu.ChungTuToLichSu(ctchungtu);
                            if (_dontu_ChiTiet != null)
                            {
                                lichsuchungtu.MaDonMoi = _dontu_ChiTiet.MaDon;
                                lichsuchungtu.STT = _dontu_ChiTiet.STT;
                            }
                            _cChungTu.ThemLichSuChungTu(lichsuchungtu);
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

        private void dgvDSSoDangKy_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            _flagInsert = true;
        }




    }
}

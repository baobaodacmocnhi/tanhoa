using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ToKhachHang;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.DAL.TruyThu;
using KTKS_DonKH.GUI.ToXuLy;
using KTKS_DonKH.GUI.ToBamChi;

namespace KTKS_DonKH.GUI.ToKhachHang
{
    public partial class frmNhanDonTKH : Form
    {
        string _mnu = "mnuNhanDonTKH";
        DonKH _donkh = null;
        HOADON _hoadon = null;
        CLoaiDon _cLoaiDon = new CLoaiDon();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CLichSuDonTu _cLichSuDonTu = new CLichSuDonTu();
        CTruyThuTienNuoc _cTTTN = new CTruyThuTienNuoc();
        decimal _MaDonTKH = -1;

        public frmNhanDonTKH()
        {
            InitializeComponent();
        }

        public frmNhanDonTKH(decimal MaDonTKH)
        {
            _MaDonTKH = MaDonTKH;
            InitializeComponent();
        }

        private void frmNhanDonKH_Load(object sender, EventArgs e)
        {
            dgvLichSuDon.AutoGenerateColumns = false;
            dgvLichSuDonTu.AutoGenerateColumns = false;
            lbTruyThu.Text = "";

            cmbLD.DataSource = _cLoaiDon.LoadDSLoaiDon();
            cmbLD.DisplayMember = "TenLD";
            cmbLD.ValueMember = "MaLD";
            cmbLD.SelectedIndex = -1;

            if (_MaDonTKH != -1)
            {
                txtMaDon.Text = _MaDonTKH.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtMaDon_KeyPress(sender, arg);
            }
        }

        public void Clear()
        {
            cmbLD.SelectedIndex = -1;
            txtMaDon.Text = "";
            txtNgayNhan.Text = "";
            txtNoiDung.Text = "";
            txtSoCongVan.Text = "";
            txtTongSoDanhBo.Text = "1";

            chkKiemTraDHN.Checked = false;
            chkTienNuoc.Checked = false;
            chkChiSoNuoc.Checked = false;
            chkThayDoiGiaNuoc.Checked = false;
            chkThayDoiTenHopDong.Checked = false;
            chkCapDM.Checked = false;
            chkCatChuyenDM.Checked = false;
            chkGiamDM.Checked = false;
            chkLyDoKhac.Checked = false;
            chkDieuChinhSoNha.Checked = false;
            chkMatDHN.Checked = false;
            chkHuHongDHN.Checked = false;
            chkChiNiem.Checked = false;
            chkThayDoiTenHopDong.Checked = false;
            chkThayDoiMST.Checked = false;
            chkThayDoiGiaNuoc.Checked = false;
            chkTamNgung.Checked = false;
            chkHuyHopDong.Checked = false;
            chkMoNuoc.Checked = false;

            txtLyDoKhac.Text = "";
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtDienThoai.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";

            chkCT_HoaDon.Checked = false;
            chkCT_HK_KT3.Checked = false;
            chkCT_STT_GXNTT.Checked = false;
            chkCT_HDTN_CQN.Checked = false;
            chkCT_GC_SDSN.Checked = false;
            chkCT_GXN2SN.Checked = false;
            chkCT_GDKKD.Checked = false;
            chkCT_GCNDTDHN.Checked = false;

            txtDinhMucSau.Text = "";
            txtHieuLucTuKy.Text = "";
            lbTruyThu.Text = "";

            _donkh = null;
            _hoadon = null;
            _MaDonTKH = -1;
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA.Insert(7, " ").Insert(4, " ");
            txtHopDong.Text = hoadon.HOPDONG;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
            txtGiaBieu.Text = hoadon.GB.ToString();
            txtDinhMuc.Text = hoadon.DM.ToString();
            dgvLichSuDon.DataSource = _cLichSuDonTu.GetDS_3To(hoadon.DANHBA);
            if (_cTTTN.CheckExist_ChuaXepDon(hoadon.DANHBA) == true)
            {
                lbTruyThu.Text = "Danh Bộ này đang Truy Thu";
                MessageBox.Show("Danh Bộ này đang Truy Thu", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
            else
                lbTruyThu.Text = "";
        }

        public void LoadDonTKH(DonKH entity)
        {
            cmbLD.SelectedValue = entity.MaLD.Value;
            txtSoCongVan.Text = entity.SoCongVan;
            txtMaDon.Text = entity.MaDon.ToString().Insert(entity.MaDon.ToString().Length - 2, "-");
            txtNgayNhan.Text = entity.CreateDate.Value.ToString("dd/MM/yyyy");
            txtNoiDung.Text = entity.NoiDung;

            if (entity.KiemTraDHN)
                chkKiemTraDHN.Checked = true;
            if (entity.TienNuoc)
                chkTienNuoc.Checked = true;
            if (entity.ChiSoNuoc)
                chkChiSoNuoc.Checked = true;
            if (entity.DonGiaNuoc)
                chkThayDoiGiaNuoc.Checked = true;
            if (entity.SangTen)
                chkThayDoiTenHopDong.Checked = true;
            if (entity.DangKyDM)
                chkCapDM.Checked = true;
            if (entity.CatChuyenDM)
                chkCatChuyenDM.Checked = true;
            if (entity.GiamDM)
                chkGiamDM.Checked = true;
            if (entity.DCSoNha)
                chkDieuChinhSoNha.Checked = true;
            if (entity.MatDHN)
                chkMatDHN.Checked = true;
            if (entity.HuHongDHN)
                chkHuHongDHN.Checked = true;
            if (entity.ChiNiem)
                chkChiNiem.Checked = true;
            if (entity.ThayDoiMST)
                chkThayDoiMST.Checked = true;
            if (entity.TamNgung)
                chkTamNgung.Checked = true;
            if (entity.HuyHopDong)
                chkHuyHopDong.Checked = true;
            if (entity.LoaiKhac)
                chkLyDoKhac.Checked = true;

            txtLyDoKhac.Text = entity.LyDoLoaiKhac;
            if (entity.DanhBo.Length == 11)
            txtDanhBo.Text = entity.DanhBo.Insert(7, " ").Insert(4, " ");
            else
                txtDanhBo.Text = entity.DanhBo;
            txtHopDong.Text = entity.HopDong;
            txtDienThoai.Text = entity.DienThoai;
            txtHoTen.Text = entity.HoTen;
            txtDiaChi.Text = entity.DiaChi;
            txtGiaBieu.Text = entity.GiaBieu;
            txtDinhMuc.Text = entity.DinhMuc;

            if (entity.CT_HoaDon)
                chkCT_HoaDon.Checked = true;
            if (entity.CT_HK_KT3)
                chkCT_HK_KT3.Checked = true;
            if (entity.CT_STT_GXNTT)
                chkCT_STT_GXNTT.Checked = true;
            if (entity.CT_HDTN_CQN)
                chkCT_HDTN_CQN.Checked = true;
            if (entity.CT_GC_SDSN)
                chkCT_GC_SDSN.Checked = true;
            if (entity.CT_GXN2SN)
                chkCT_GXN2SN.Checked = true;
            if (entity.CT_GDKKD)
                chkCT_GDKKD.Checked = true;
            if (entity.CT_GCNDTDHN)
                chkCT_GCNDTDHN.Checked = true;

            txtDinhMucSau.Text = entity.DinhMucSau;
            txtHieuLucTuKy.Text = entity.HieuLucTuKy;
            dgvLichSuDon.DataSource = _cLichSuDonTu.GetDS_3To(entity.DanhBo);
            dgvLichSuDonTu.DataSource = _cLichSuDonTu.GetDS("TKH", entity.MaDon);
        }

        private void cmbLD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLD.SelectedIndex != -1)
            {
                //txtMaDon.Text = _cDonKH.getMaxNextID().ToString().Insert(_cDonKH.getMaxNextID().ToString().Length - 2, "-");
                txtNgayNhan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void chkLyDoKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLyDoKhac.Checked)
                txtLyDoKhac.ReadOnly = false;
            else
                txtLyDoKhac.ReadOnly = true;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDanhBo.Text.Trim().Replace(" ", "").Length == 11 && e.KeyChar == 13)
            {
                _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim().Replace(" ", ""));
                if (_hoadon != null)
                {
                    LoadTTKH(_hoadon);
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInBienNhan_Click(object sender, EventArgs e)
        {
            if (_donkh != null)
                InBienNhan(_donkh);
        }

        public void InBienNhan(DonKH entity)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            DataRow dr = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
            dr["MaDon"] = entity.MaDon.ToString().Insert(entity.MaDon.ToString().Length - 2, "-"); ;
            dr["TenLD"] = entity.LoaiDon.TenLD;
            dr["KhachHang"] = entity.HoTen;
            if (entity.DanhBo != "")
                dr["DanhBo"] = entity.DanhBo.Insert(7, " ").Insert(4, " ");
            dr["DiaChi"] = entity.DiaChi;
            dr["HopDong"] = entity.HopDong;
            dr["DienThoai"] = entity.DienThoai;

            #region CheckBox
            if (entity.KiemTraDHN)
            {
                dr["KiemTraDHN"] = true;
            }
            else
            {
                dr["KiemTraDHN"] = false;
            }

            if (entity.TienNuoc)
            {
                dr["TienNuoc"] = true;
            }
            else
            {
                dr["TienNuoc"] = false;
            }

            if (entity.ChiSoNuoc)
            {
                dr["ChiSoNuoc"] = true;
            }
            else
            {
                dr["ChiSoNuoc"] = false;
            }

            if (entity.DonGiaNuoc)
            {
                dr["DonGiaNuoc"] = true;
            }
            else
            {
                dr["DonGiaNuoc"] = false;
            }

            if (entity.DangKyDM)
            {
                dr["DangKyDM"] = true;
            }
            else
            {
                dr["DangKyDM"] = false;
            }

            if (entity.CatChuyenDM)
            {
                dr["CatChuyenDM"] = true;
            }
            else
            {
                dr["CatChuyenDM"] = false;
            }

            if (entity.GiamDM)
            {
                dr["GiamDM"] = true;
            }
            else
            {
                dr["GiamDM"] = false;
            }

            if (entity.DCSoNha)
            {
                dr["DCSoNha"] = true;
            }
            else
            {
                dr["DCSoNha"] = false;
            }

            if (entity.MatDHN)
            {
                dr["MatDHN"] = true;
            }
            else
            {
                dr["MatDHN"] = false;
            }

            if (entity.HuHongDHN)
            {
                dr["HuHongDHN"] = true;
            }
            else
            {
                dr["HuHongDHN"] = false;
            }

            if (entity.ChiNiem)
            {
                dr["ChiNiem"] = true;
            }
            else
            {
                dr["ChiNiem"] = false;
            }

            if (entity.ThayDoiMST)
            {
                dr["ThayDoiMST"] = true;
            }
            else
            {
                dr["ThayDoiMST"] = false;
            }

            if (entity.TamNgung)
            {
                dr["TamNgung"] = true;
            }
            else
            {
                dr["TamNgung"] = false;
            }

            if (entity.HuyHopDong)
            {
                dr["HuyHopDong"] = true;
            }
            else
            {
                dr["HuyHopDong"] = false;
            }

            if (entity.MoNuoc)
            {
                dr["MoNuoc"] = true;
            }
            else
            {
                dr["MoNuoc"] = false;
            }

            if (entity.LoaiKhac)
            {
                dr["LoaiKhac"] = true;
                dr["LyDoLoaiKhac"] = entity.LyDoLoaiKhac;
            }
            else
            {
                dr["LoaiKhac"] = false;
            }

            if (entity.SangTen)
            {
                dr["SangTen"] = true;
            }
            else
            {
                dr["SangTen"] = false;
            }

            if (entity.CT_HoaDon)
            {
                dr["CT_HoaDon"] = true;
            }
            else
            {
                dr["CT_HoaDon"] = false;
            }

            if (entity.CT_HK_KT3)
            {
                dr["CT_HK_KT3"] = true;
            }
            else
            {
                dr["CT_HK_KT3"] = false;
            }

            if (entity.CT_STT_GXNTT)
            {
                dr["CT_STT_GXNTT"] = true;
            }
            else
            {
                dr["CT_STT_GXNTT"] = false;
            }

            if (entity.CT_HDTN_CQN)
            {
                dr["CT_HDTN_CQN"] = true;
            }
            else
            {
                dr["CT_HDTN_CQN"] = false;
            }

            if (entity.CT_GC_SDSN)
            {
                dr["CT_GC_SDSN"] = true;
            }
            else
            {
                dr["CT_GC_SDSN"] = false;
            }

            if (entity.CT_GXN2SN)
            {
                dr["CT_GXN2SN"] = true;
            }
            else
            {
                dr["CT_GXN2SN"] = false;
            }

            if (entity.CT_GDKKD)
            {
                dr["CT_GDKKD"] = true;
            }
            else
            {
                dr["CT_GDKKD"] = false;
            }

            if (entity.CT_GCNDTDHN)
            {
                dr["CT_GCNDTDHN"] = true;
            }
            else
            {
                dr["CT_GCNDTDHN"] = false;
            }
            #endregion

            dr["NgayGiaiQuyet"] = entity.NgayGiaiQuyet;
            dr["DinhMucSau"] = entity.DinhMucSau;
            dr["HieuLucTuKy"] = entity.HieuLucTuKy;
            dr["HoTenNV"] = CTaiKhoan.HoTen;
            dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(dr);
            rptBienNhanDonKH rpt = new rptBienNhanDonKH();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                if (_cDonKH.CheckExist(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) == true)
                {
                    _donkh = _cDonKH.Get(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                    LoadDonTKH(_donkh);
                }
                else
                {
                    Clear();
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (cmbLD.SelectedIndex != -1)
                    {
                        if (txtDanhBo.Text.Trim().Replace(" ", "") != "" && _cDonKH.CheckExist(txtDanhBo.Text.Trim().Replace(" ", ""), DateTime.Now) == true)
                        {
                            MessageBox.Show("Danh Bộ này đã nhận đơn trong ngày hôm nay rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        DonKH donkh = new DonKH();
                        donkh.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                        donkh.SoCongVan = txtSoCongVan.Text.Trim();
                        donkh.NoiDung = txtNoiDung.Text.Trim();

                        donkh.DanhBo = txtDanhBo.Text.Trim().Replace(" ","");
                        donkh.HopDong = txtHopDong.Text.Trim();
                        donkh.HoTen = txtHoTen.Text.Trim();
                        donkh.DiaChi = txtDiaChi.Text.Trim();
                        donkh.DienThoai = txtDienThoai.Text.Trim();
                        donkh.GiaBieu = txtGiaBieu.Text.Trim();
                        donkh.DinhMuc = txtDinhMuc.Text.Trim();
                        if (_hoadon != null)
                        {
                            donkh.Dot = _hoadon.DOT.Value.ToString();
                            donkh.Ky = _hoadon.KY.ToString();
                            donkh.Nam = _hoadon.NAM.Value.ToString();
                            donkh.MLT = _hoadon.MALOTRINH;
                        }
                        donkh.DinhMucSau = txtDinhMucSau.Text.Trim();
                        donkh.HieuLucTuKy = txtHieuLucTuKy.Text.Trim();

                        #region CheckBox

                        donkh.NgayGiaiQuyet = "Trong thời gian 5 ngày làm việc kể từ ngày nhận hồ sơ, Công ty sẽ giải quyết theo quy định hiện hành";

                        if (chkKiemTraDHN.Checked)
                            donkh.KiemTraDHN = true;

                        if (chkTienNuoc.Checked)
                            donkh.TienNuoc = true;

                        if (chkChiSoNuoc.Checked)
                            donkh.ChiSoNuoc = true;

                        if (chkThayDoiGiaNuoc.Checked)
                            donkh.DonGiaNuoc = true;

                        if (chkThayDoiTenHopDong.Checked)
                        {
                            donkh.SangTen = true;
                            donkh.NgayGiaiQuyet = "Quý khách nhận lại Hợp Đồng vào ngày "+GetToDate(DateTime.Now,30).ToString("dd/MM/yyyy")+". Quá thời hạn trên, Khách Hàng không liên hệ nhận Hợp Đồng; mọi Khiếu Nại về sau sẽ không được giải quyết";
                        }

                        if (chkCapDM.Checked)
                            donkh.DangKyDM = true;

                        if (chkCatChuyenDM.Checked)
                            donkh.CatChuyenDM = true;

                        if (chkGiamDM.Checked)
                            donkh.GiamDM = true;

                        if (chkDieuChinhSoNha.Checked)
                            donkh.DCSoNha = true;

                        if (chkMatDHN.Checked)
                            donkh.MatDHN = true;

                        if (chkHuHongDHN.Checked)
                            donkh.HuHongDHN = true;

                        if (chkChiNiem.Checked)
                            donkh.ChiNiem = true;

                        if (chkThayDoiMST.Checked)
                            donkh.ThayDoiMST = true;

                        if (chkTamNgung.Checked)
                            donkh.TamNgung = true;

                        if (chkHuyHopDong.Checked)
                            donkh.HuyHopDong = true;

                        if (chkMoNuoc.Checked)
                            donkh.MoNuoc = true;

                        if (chkLyDoKhac.Checked)
                        {
                            donkh.LoaiKhac = true;
                            donkh.LyDoLoaiKhac = txtLyDoKhac.Text.Trim();
                        }

                        if (chkCT_HoaDon.Checked)
                            donkh.CT_HoaDon = true;

                        if (chkCT_HK_KT3.Checked)
                            donkh.CT_HK_KT3 = true;

                        if (chkCT_STT_GXNTT.Checked)
                            donkh.CT_STT_GXNTT = true;

                        if (chkCT_HDTN_CQN.Checked)
                            donkh.CT_HDTN_CQN = true;

                        if (chkCT_GC_SDSN.Checked)
                            donkh.CT_GC_SDSN = true;

                        if (chkCT_GXN2SN.Checked)
                            donkh.CT_GXN2SN = true;

                        if (chkCT_GDKKD.Checked)
                            donkh.CT_GDKKD = true;

                        if (chkCT_GCNDTDHN.Checked)
                            donkh.CT_GCNDTDHN = true;

                        #endregion

                        _cDonKH.beginTransaction();
                        if (_cDonKH.Them(donkh))
                        {
                            _cDonKH.commitTransaction();
                            Clear();
                            MessageBox.Show("Thành công/n Mã Đơn:" + donkh.MaDon.ToString().Insert(donkh.MaDon.ToString().Length - 2, "-"), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (chkKhongInBienNhan.Checked==false)
                            {
                                InBienNhan(donkh);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _cDonKH.rollback();
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
                if (_donkh != null)
                {
                    _donkh.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                    _donkh.SoCongVan = txtSoCongVan.Text.Trim();
                    if (_donkh.DanhBo != txtDanhBo.Text.Trim().Replace(" ", ""))
                        if (_hoadon != null)
                        {
                            _donkh.Dot = _hoadon.DOT.Value.ToString();
                            _donkh.Ky = _hoadon.KY.ToString();
                            _donkh.Nam = _hoadon.NAM.Value.ToString();
                            _donkh.MLT = _hoadon.MALOTRINH;
                        }
                    _donkh.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                    _donkh.HopDong = txtHopDong.Text.Trim();
                    _donkh.HoTen = txtHoTen.Text.Trim();
                    _donkh.DiaChi = txtDiaChi.Text.Trim();
                    _donkh.DienThoai = txtDienThoai.Text.Trim();
                    _donkh.GiaBieu = txtGiaBieu.Text.Trim();
                    _donkh.DinhMuc = txtDinhMuc.Text.Trim();

                    _donkh.NoiDung = txtNoiDung.Text.Trim();
                    _donkh.DinhMucSau = txtDinhMucSau.Text.Trim();
                    _donkh.HieuLucTuKy = txtHieuLucTuKy.Text.Trim();

                    #region CheckBox

                    _donkh.NgayGiaiQuyet = "Trong thời gian 5 ngày làm việc kể từ ngày nhận hồ sơ, Công ty sẽ giải quyết theo quy định hiện hành";

                    if (chkKiemTraDHN.Checked)
                        _donkh.KiemTraDHN = true;
                    else
                        _donkh.KiemTraDHN = false;

                    if (chkTienNuoc.Checked)
                        _donkh.TienNuoc = true;
                    else
                        _donkh.TienNuoc = false;

                    if (chkChiSoNuoc.Checked)
                        _donkh.ChiSoNuoc = true;
                    else
                        _donkh.ChiSoNuoc = false;

                    if (chkThayDoiGiaNuoc.Checked)
                        _donkh.DonGiaNuoc = true;
                    else
                        _donkh.DonGiaNuoc = false;

                    if (chkThayDoiTenHopDong.Checked)
                    {
                        _donkh.SangTen = true;
                        _donkh.NgayGiaiQuyet = "Quý khách nhận lại Hợp Đồng vào ngày " + GetToDate(_donkh.CreateDate.Value, 30).ToString("dd/MM/yyyy") + ". Quá thời hạn trên, Khách Hàng không liên hệ nhận Hợp Đồng; mọi Khiếu Nại về sau sẽ không được giải quyết";
                    }
                    else
                        _donkh.SangTen = false;

                    if (chkCapDM.Checked)
                        _donkh.DangKyDM = true;
                    else
                        _donkh.DangKyDM = false;

                    if (chkCatChuyenDM.Checked)
                        _donkh.CatChuyenDM = true;
                    else
                        _donkh.CatChuyenDM = false;

                    if (chkGiamDM.Checked)
                        _donkh.GiamDM = true;
                    else
                        _donkh.GiamDM = false;

                    if (chkDieuChinhSoNha.Checked)
                        _donkh.DCSoNha = true;
                    else
                        _donkh.DCSoNha = false;

                    if (chkMatDHN.Checked)
                        _donkh.MatDHN = true;
                    else
                        _donkh.MatDHN = false;

                    if (chkHuHongDHN.Checked)
                        _donkh.HuHongDHN = true;
                    else
                        _donkh.HuHongDHN = false;

                    if (chkChiNiem.Checked)
                        _donkh.ChiNiem = true;
                    else
                        _donkh.ChiNiem = false;

                    if (chkThayDoiMST.Checked)
                        _donkh.ThayDoiMST = true;
                    else
                        _donkh.ThayDoiMST = false;

                    if (chkTamNgung.Checked)
                        _donkh.TamNgung = true;
                    else
                        _donkh.TamNgung = false;

                    if (chkHuyHopDong.Checked)
                        _donkh.HuyHopDong = true;
                    else
                        _donkh.HuyHopDong = false;

                    if (chkMoNuoc.Checked)
                        _donkh.MoNuoc = true;
                    else
                        _donkh.MoNuoc = false;

                    if (chkLyDoKhac.Checked)
                    {
                        _donkh.LoaiKhac = true;
                        _donkh.LyDoLoaiKhac = txtLyDoKhac.Text.Trim();
                    }
                    else
                    {
                        _donkh.LoaiKhac = false;
                        _donkh.LyDoLoaiKhac = null;
                    }

                    if (chkCT_HoaDon.Checked)
                        _donkh.CT_HoaDon = true;
                    else
                        _donkh.CT_HoaDon = false;

                    if (chkCT_HK_KT3.Checked)
                        _donkh.CT_HK_KT3 = true;
                    else
                        _donkh.CT_HK_KT3 = false;

                    if (chkCT_STT_GXNTT.Checked)
                        _donkh.CT_STT_GXNTT = true;
                    else
                        _donkh.CT_STT_GXNTT = false;

                    if (chkCT_HDTN_CQN.Checked)
                        _donkh.CT_HDTN_CQN = true;
                    else
                        _donkh.CT_HDTN_CQN = false;

                    if (chkCT_GC_SDSN.Checked)
                        _donkh.CT_GC_SDSN = true;
                    else
                        _donkh.CT_GC_SDSN = false;

                    if (chkCT_GXN2SN.Checked)
                        _donkh.CT_GXN2SN = true;
                    else
                        _donkh.CT_GXN2SN = false;

                    if (chkCT_GDKKD.Checked)
                        _donkh.CT_GDKKD = true;
                    else
                        _donkh.CT_GDKKD = false;

                    if (chkCT_GCNDTDHN.Checked)
                        _donkh.CT_GCNDTDHN = true;
                    else
                        _donkh.CT_GCNDTDHN = false;

                    #endregion

                    if (_cDonKH.Sua(_donkh))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                if (_donkh != null && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_cDonKH.Xoa(_donkh))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvLichSuDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLichSuDon.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        public DateTime GetToDate(DateTime FromDate,int SoNgayCongThem)
        {
            while (SoNgayCongThem > 0)
            {
                if (FromDate.DayOfWeek == DayOfWeek.Friday)
                    FromDate = FromDate.AddDays(3);
                else
                    if (FromDate.DayOfWeek == DayOfWeek.Saturday)
                        FromDate = FromDate.AddDays(2);
                    else
                        FromDate = FromDate.AddDays(1);
                SoNgayCongThem--;
            }
            return FromDate;
        }

        private void dgvLichSuDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvLichSuDon.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                if (dgvLichSuDon["MaDon", dgvLichSuDon.CurrentRow.Index].Value.ToString().ToUpper().Contains("TKH"))
                {
                    frmNhanDonTKH frm = new frmNhanDonTKH(decimal.Parse(dgvLichSuDon["MaDon", dgvLichSuDon.CurrentRow.Index].Value.ToString().Substring(3)));
                    frm.ShowDialog();
                }
                else
                    if (dgvLichSuDon["MaDon", dgvLichSuDon.CurrentRow.Index].Value.ToString().ToUpper().Contains("TXL"))
                    {
                        frmNhanDonTXL frm = new frmNhanDonTXL(decimal.Parse(dgvLichSuDon["MaDon", dgvLichSuDon.CurrentRow.Index].Value.ToString().Substring(3)));
                        frm.ShowDialog();
                    }
                    else

                        if (dgvLichSuDon["MaDon", dgvLichSuDon.CurrentRow.Index].Value.ToString().ToUpper().Contains("TBC"))
                        {
                            frmNhanDonTBC frm = new frmNhanDonTBC(decimal.Parse(dgvLichSuDon["MaDon", dgvLichSuDon.CurrentRow.Index].Value.ToString().Substring(3)));
                            frm.ShowDialog();
                        }
            }
        }

    }
}

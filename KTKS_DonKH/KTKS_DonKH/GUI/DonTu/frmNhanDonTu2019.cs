using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.DAL;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DonTu;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.TruyThu;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.DAL.ThuMoi;
using KTKS_DonKH.wrThuongVu;
using KTKS_DonKH.wrEContract;

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmNhanDonTu2019 : Form
    {
        string _mnu = "mnuNhanDonTu";
        CDonTu _cDonTu = new CDonTu();
        CNhomDon _cNhomDon = new CNhomDon();
        CThuTien _cThuTien = new CThuTien();
        CDHN _cDHN = new CDHN();
        CTruyThuTienNuoc _cTTTN = new CTruyThuTienNuoc();
        CGanMoi _cGanMoi = new CGanMoi();
        CKTXM _cKTXM = new CKTXM();
        CThuMoi _cThuMoi = new CThuMoi();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CPhongBanDoi _cPBD = new CPhongBanDoi();
        CDocSo _cDocSo = new CDocSo();
        CTTKH _cTTKH = new CTTKH();
        wsThuongVu _wsThuongVu = new wsThuongVu();
        wsEContract _wsEContract = new wsEContract();
        LinQ.DonTu _dontu = null;
        HOADON _hoadon = null;
        int _MaDon = -1;
        bool _flagdgvDanhBo_inserRow = false;

        public frmNhanDonTu2019()
        {
            InitializeComponent();
        }

        public frmNhanDonTu2019(int MaDon)
        {
            InitializeComponent();
            _MaDon = MaDon;
        }

        private void frmDonTu_Load(object sender, EventArgs e)
        {
            dgvDanhBo.AutoGenerateColumns = false;
            dgvLichSuNhanDon.AutoGenerateColumns = false;
            lbTruyThu.Text = "";

            DataTable dt = _cNhomDon.getDSGroup("DieuChinh");
            chkcmbDieuChinh.Properties.DataSource = dt;
            chkcmbDieuChinh.Properties.ValueMember = "ID";
            chkcmbDieuChinh.Properties.DisplayMember = "Name";

            dt = _cNhomDon.getDSGroup("KhieuNai");
            chkcmbKhieuNai.Properties.DataSource = dt;
            chkcmbKhieuNai.Properties.ValueMember = "ID";
            chkcmbKhieuNai.Properties.DisplayMember = "Name";

            dt = _cNhomDon.getDSGroup("SuCo");
            chkcmbDHN.Properties.DataSource = dt;
            chkcmbDHN.Properties.ValueMember = "ID";
            chkcmbDHN.Properties.DisplayMember = "Name";

            dt = _cNhomDon.getDSGroup("QuanLy");
            chkcmbQuanLy.Properties.DataSource = dt;
            chkcmbQuanLy.Properties.ValueMember = "ID";
            chkcmbQuanLy.Properties.DisplayMember = "Name";

            cmbPhongBanDoi.DataSource = _cPBD.GetDS();
            cmbPhongBanDoi.DisplayMember = "Name";
            cmbPhongBanDoi.ValueMember = "Name";
            cmbPhongBanDoi.SelectedIndex = -1;

            if (_MaDon != -1)
            {
                txtMaDon.Text = _MaDon.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtMaDon_KeyPress(sender, arg);
            }
        }

        public void LoadTTKH(HOADON entity)
        {
            txtDanhBo.Text = entity.DANHBA.Insert(7, " ").Insert(4, " ");
            txtHopDong.Text = entity.HOPDONG;
            txtHoTen.Text = entity.TENKH;
            txtDiaChi.Text = entity.SO + " " + entity.DUONG + _cDHN.GetPhuongQuan(entity.Quan, entity.Phuong);
            txtGiaBieu.Text = entity.GB.ToString();
            if (entity.DM != null)
                txtDinhMuc.Text = entity.DM.ToString();
            else
                txtDinhMuc.Text = "";
            if (entity.DinhMucHN != null)
                txtDinhMucHN.Text = entity.DinhMucHN.Value.ToString();
            else
                txtDinhMucHN.Text = "";
            dgvLichSuNhanDon.DataSource = _cDonTu.getDS_ChiTiet_ByDanhBo(entity.DANHBA);

            if (_cDonTu.checkExists_14ngay(entity.DANHBA) == true)
                MessageBox.Show("Danh Bộ này có Đơn trong 14 ngày gần nhất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            string str, TinhTrang = "";
            str = _cTTTN.check_TinhTrang_Ton(entity.DANHBA);
            if (str == "")
            {
                if (_cKTXM.checkCanKhachHangLienHe(txtDanhBo.Text.Trim().Replace(" ", ""), out TinhTrang) == true)
                    str = TinhTrang;
            }
            if (str == "")
            {
                if (_cThuMoi.checkCanKhachHangLienHe(txtDanhBo.Text.Trim().Replace(" ", ""), out TinhTrang) == true)
                    str = TinhTrang;
            }
            if (str == "")
            {
                if (_cDonTu.checkExist_ChuyenDeDinhMuc_ChuaKTXM(txtDanhBo.Text.Trim().Replace(" ", ""), out TinhTrang) == true)
                    str = TinhTrang;
            }
            //hiện thị
            if (str != "")
            {
                lbTruyThu.Text = str;
                MessageBox.Show("Danh Bộ này đang có Đơn Tồn\n" + str, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                lbTruyThu.Text = "";
            string strDuongCamDao = _cGanMoi.getDuongCamDao(entity.SO, entity.DUONG);
            if (strDuongCamDao != "")
                MessageBox.Show(strDuongCamDao, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void LoadDonTu(LinQ.DonTu entity)
        {
            try
            {
                if (entity.DonTu_ChiTiets.Count == 1)
                {
                    tabControl.SelectTab("tabTTKH");
                    if (entity.SoNK != null)
                    {
                        chkCCDM.Checked = entity.CCDM;
                        txtSoNK.Text = entity.SoNK.Value.ToString();
                        txtHieuLucKy.Text = entity.HieuLucKy;
                    }
                    if (entity.ThoiHan != null)
                    {
                        cmbThoiHan.SelectedItem = entity.ThoiHan;
                        dateHetHan.Value = entity.NgayHetHan.Value;
                    }
                    if (entity.DonTu_ChiTiets.SingleOrDefault().DanhBo != null && entity.DonTu_ChiTiets.SingleOrDefault().DanhBo.Length == 11)
                        txtDanhBo.Text = entity.DonTu_ChiTiets.SingleOrDefault().DanhBo.Insert(7, " ").Insert(4, " ");
                    txtHopDong.Text = entity.DonTu_ChiTiets.SingleOrDefault().HopDong;
                    txtDienThoai.Text = entity.DonTu_ChiTiets.SingleOrDefault().DienThoai;
                    txtNguoiBao.Text = entity.DonTu_ChiTiets.SingleOrDefault().NguoiBao;
                    txtHoTen.Text = entity.DonTu_ChiTiets.SingleOrDefault().HoTen;
                    txtDiaChi.Text = entity.DonTu_ChiTiets.SingleOrDefault().DiaChi;
                    if (entity.DonTu_ChiTiets.SingleOrDefault().GiaBieu != null)
                        txtGiaBieu.Text = entity.DonTu_ChiTiets.SingleOrDefault().GiaBieu.Value.ToString();
                    if (entity.DonTu_ChiTiets.SingleOrDefault().DinhMuc != null)
                        txtDinhMuc.Text = entity.DonTu_ChiTiets.SingleOrDefault().DinhMuc.Value.ToString();
                    if (entity.DonTu_ChiTiets.SingleOrDefault().DinhMucHN != null)
                        txtDinhMucHN.Text = entity.DonTu_ChiTiets.SingleOrDefault().DinhMucHN.Value.ToString();
                    txtHoTenMoi.Text = entity.DonTu_ChiTiets.SingleOrDefault().HoTenMoi;
                    txtCCCD.Text = entity.DonTu_ChiTiets.SingleOrDefault().CCCD;
                    txtNgayCap.Text = entity.DonTu_ChiTiets.SingleOrDefault().NgayCap;
                    txtDCThuongTru.Text = entity.DonTu_ChiTiets.SingleOrDefault().DCThuongTru;
                    txtDCHienNay.Text = entity.DonTu_ChiTiets.SingleOrDefault().DCHienNay;
                    txtDienThoaiMoi.Text = entity.DonTu_ChiTiets.SingleOrDefault().DienThoai;
                    txtFax.Text = entity.DonTu_ChiTiets.SingleOrDefault().Fax;
                    txtEmail.Text = entity.DonTu_ChiTiets.SingleOrDefault().Email;
                    txtSTK.Text = entity.DonTu_ChiTiets.SingleOrDefault().STK;
                    txtBank.Text = entity.DonTu_ChiTiets.SingleOrDefault().Bank;
                    txtMST.Text = entity.DonTu_ChiTiets.SingleOrDefault().MST;
                    txtDCLapDat.Text = entity.DonTu_ChiTiets.SingleOrDefault().DCLapDat;
                }
                else
                {
                    tabControl.SelectTab("tabCongVan");

                    foreach (DonTu_ChiTiet item in entity.DonTu_ChiTiets.ToList())
                    {
                        dgvDanhBo.Rows.Insert(dgvDanhBo.RowCount - 1, 1);

                        dgvDanhBo["ID", dgvDanhBo.RowCount - 2].Value = item.ID;
                        dgvDanhBo["STT", dgvDanhBo.RowCount - 2].Value = item.STT;
                        dgvDanhBo["DanhBo", dgvDanhBo.RowCount - 2].Value = item.DanhBo;
                        dgvDanhBo["QLDHN_MaDon", dgvDanhBo.RowCount - 2].Value = item.QLDHN_MaDon;
                        dgvDanhBo["HopDong", dgvDanhBo.RowCount - 2].Value = item.HopDong;
                        dgvDanhBo["HoTen", dgvDanhBo.RowCount - 2].Value = item.HoTen;
                        dgvDanhBo["DiaChi", dgvDanhBo.RowCount - 2].Value = item.DiaChi;
                        dgvDanhBo["GiaBieu", dgvDanhBo.RowCount - 2].Value = item.GiaBieu;
                        dgvDanhBo["DinhMuc", dgvDanhBo.RowCount - 2].Value = item.DinhMuc;
                        dgvDanhBo["DinhMucHN", dgvDanhBo.RowCount - 2].Value = item.DinhMucHN;
                        dgvDanhBo["Dot", dgvDanhBo.RowCount - 2].Value = item.Dot;
                        dgvDanhBo["Ky", dgvDanhBo.RowCount - 2].Value = item.Ky;
                        dgvDanhBo["Nam", dgvDanhBo.RowCount - 2].Value = item.Nam;
                        dgvDanhBo["MLT", dgvDanhBo.RowCount - 2].Value = item.MLT;
                        dgvDanhBo["Quan", dgvDanhBo.RowCount - 2].Value = item.Quan;
                        dgvDanhBo["Phuong", dgvDanhBo.RowCount - 2].Value = item.Phuong;
                    }
                    //dgvDanhBo.DataSource = entity.DonTu_ChiTiets.ToList();
                }
                chkChanHoaDon.Checked = entity.DonTu_ChiTiets.FirstOrDefault().ChanHoaDon;
                if (entity.DonTu_ChiTiets.FirstOrDefault().ChanHoaDon_Ky != null)
                {
                    txtKyHDChan.Text = entity.DonTu_ChiTiets.FirstOrDefault().ChanHoaDon_Ky + "/" + entity.DonTu_ChiTiets.FirstOrDefault().ChanHoaDon_Nam;
                }
                chkVanPhong.Checked = entity.VanPhong;
                txtMaDon.Text = entity.MaDon.ToString();
                dateCreateDate.Value = entity.CreateDate.Value;
                txtNguoiLap.Text = _cTaiKhoan.GetHoTen(entity.CreateBy.Value);
                if (entity.SoCongVan_PhongBanDoi != null)
                    cmbPhongBanDoi.SelectedValue = entity.SoCongVan_PhongBanDoi;
                if (entity.SoCongVan != null)
                {
                    txtSoCongVan.Text = entity.SoCongVan;
                    txtTongDB.Text = entity.TongDB.ToString();
                }

                if (entity.ID_NhomDon_PKH != null)
                {
                    chkcmbDieuChinh.SetEditValue(entity.ID_NhomDon_PKH);
                    if (entity.ID_NhomDon_PKH.Contains("9"))
                        panel1.Visible = true;
                    else
                        panel1.Visible = false;
                    chkcmbKhieuNai.SetEditValue(entity.ID_NhomDon_PKH);
                    chkcmbDHN.SetEditValue(entity.ID_NhomDon_PKH);
                    chkcmbQuanLy.SetEditValue(entity.ID_NhomDon_PKH);
                }
                //if (entity.ID_NhomDon_ChiTiet != null)
                //    cmbNhomDon_ChiTiet.SelectedValue = entity.ID_NhomDon_ChiTiet;
                if (chkcmbDieuChinh.Properties.Items.Count > 0)
                {
                    int count = 0;
                    for (int i = 0; i < chkcmbDieuChinh.Properties.Items.Count; i++)
                    {
                        if (chkcmbDieuChinh.Properties.Items[i].CheckState == CheckState.Checked && (chkcmbDieuChinh.Properties.Items[i].Value.ToString() == "7"))
                            count++;
                    }
                    if (count != 0)
                        panel1.Visible = true;
                    else
                        panel1.Visible = false;
                }
                txtNoiDungKhachHang.Text = entity.Name_NhomDon_PKH;
                txtNoiDungThuongVu.Text = entity.Name_NhomDon;
                txtVanDeKhac.Text = entity.VanDeKhac;

                chkCT_HopDongNganHang.Checked = entity.CT_HopDongNganHang;
                chkCT_GiaiQuyet_Huy_DKCT.Checked = entity.CT_GiayBao;
                chkCT_HDTN_CQN.Checked = entity.CT_HDTN_CQN;
                chkCT_CQN.Checked = entity.CT_CQN;
                chkCT_Khac.Checked = entity.CT_Khac;
                chkCT_CVXuatHD.Checked = entity.CT_CVXuatHD;
                if (entity.CT_Khac == true)
                {
                    txtCT_Khac_GhiChu.Text = entity.CT_Khac_GhiChu;
                }
                else
                {
                    txtCT_Khac_GhiChu.Text = "";
                }
                chkCT_HK_KT3.Checked = entity.CT_HK_KT3;
                //chkCT_STT_GXNTT.Checked = entity.CT_STT_GXNTT;
                chkCT_GDKKD.Checked = entity.CT_GDKKD;
                chkCT_GiayUyQuyen.Checked = entity.CT_HoNgheo;

                chkCT_GC_SDSN.Checked = entity.CT_GC_SDSN;
                //chkCT_GXN2SN.Checked = entity.CT_GXN2SN;
                chkCT_GCNDTDHN.Checked = entity.CT_GCNDTDHN;

                dgvLichSuNhanDon.DataSource = _cDonTu.getDS_ChiTiet_ByDanhBo(entity.DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Clear()
        {
            if (chkGiuSoCongVan.Checked == false)
            {
                cmbPhongBanDoi.SelectedIndex = -1;
                txtSoCongVan.Text = "";
                txtTongDB.Text = "1";

                for (int i = 0; i < chkcmbDieuChinh.Properties.Items.Count; i++)
                {
                    chkcmbDieuChinh.Properties.Items[i].CheckState = CheckState.Unchecked;
                }
                for (int i = 0; i < chkcmbKhieuNai.Properties.Items.Count; i++)
                {
                    chkcmbKhieuNai.Properties.Items[i].CheckState = CheckState.Unchecked;
                }
                for (int i = 0; i < chkcmbDHN.Properties.Items.Count; i++)
                {
                    chkcmbDHN.Properties.Items[i].CheckState = CheckState.Unchecked;
                }
                for (int i = 0; i < chkcmbQuanLy.Properties.Items.Count; i++)
                {
                    chkcmbQuanLy.Properties.Items[i].CheckState = CheckState.Unchecked;
                }
                txtNoiDungKhachHang.Text = "";
                txtNoiDungThuongVu.Text = "";

            }
            txtVanDeKhac.Text = "";
            txtMaDon.Text = "";
            lbTruyThu.Text = "";
            txtNguoiLap.Text = "";

            cmbNhomDon_ChiTiet.SelectedIndex = -1;
            chkCCDM.Checked = false;
            txtSoNK.Text = "";
            txtHieuLucKy.Text = "";
            cmbThoiHan.SelectedIndex = -1;
            //dateHetHan.Value = DateTime.Now;

            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtDienThoai.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDinhMucHN.Text = "";
            txtNguoiBao.Text = "";
            txtDienThoai.Text = "";
            chkChanHoaDon.Checked = false;
            txtKyHDChan.Text = "";
            txtHoTenMoi.Text = "";
            txtCCCD.Text = "";
            txtNgayCap.Text = "";
            txtDCThuongTru.Text = "";
            txtDCHienNay.Text = "";
            txtDienThoaiMoi.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            txtSTK.Text = "";
            txtBank.Text = "";
            txtMST.Text = "";
            if (dgvDanhBo.DataSource != null)
                dgvDanhBo.DataSource = null;
            else
            {
                dgvDanhBo.Rows.Clear();
                //dgvDanhBo.Rows.Add();
            }

            chkCT_HopDongNganHang.Checked = false;
            chkCT_GiaiQuyet_Huy_DKCT.Checked = false;
            chkCT_HDTN_CQN.Checked = false;
            chkCT_CQN.Checked = false;
            chkCT_Khac.Checked = false;
            txtCT_Khac_GhiChu.Text = "";

            chkCT_HK_KT3.Checked = false;
            //chkCT_STT_GXNTT.Checked = false;
            chkCT_GDKKD.Checked = false;
            chkCT_GiayUyQuyen.Checked = false;

            chkCT_GC_SDSN.Checked = false;
            //chkCT_GXN2SN.Checked = false;
            chkCT_GCNDTDHN.Checked = false;

            _dontu = null;
            _hoadon = null;
            _MaDon = -1;
        }

        private void chkcmbDieuChinh_EditValueChanged(object sender, EventArgs e)
        {
            if (chkcmbDieuChinh.Properties.Items.Count > 0)
            {
                int count = 0;
                for (int i = 0; i < chkcmbDieuChinh.Properties.Items.Count; i++)
                {
                    if (chkcmbDieuChinh.Properties.Items[i].CheckState == CheckState.Checked && txtNoiDungKhachHang.Text.Trim().Contains(chkcmbDieuChinh.Properties.Items[i].ToString()) == false)
                    {
                        if (txtNoiDungKhachHang.Text.Trim() == "")
                            txtNoiDungKhachHang.Text = chkcmbDieuChinh.Properties.Items[i].ToString();
                        else
                            txtNoiDungKhachHang.Text += "; " + chkcmbDieuChinh.Properties.Items[i].ToString();
                    }
                    else
                        if (chkcmbDieuChinh.Properties.Items[i].CheckState == CheckState.Unchecked && txtNoiDungKhachHang.Text.Trim().Contains(chkcmbDieuChinh.Properties.Items[i].ToString()) == true)
                        {
                            txtNoiDungKhachHang.Text = txtNoiDungKhachHang.Text.Replace("; " + chkcmbDieuChinh.Properties.Items[i].ToString(), "");
                            txtNoiDungKhachHang.Text = txtNoiDungKhachHang.Text.Replace(chkcmbDieuChinh.Properties.Items[i].ToString() + "; ", "");
                            txtNoiDungKhachHang.Text = txtNoiDungKhachHang.Text.Replace(chkcmbDieuChinh.Properties.Items[i].ToString(), "");
                        }
                    if (chkcmbDieuChinh.Properties.Items[i].CheckState == CheckState.Checked && (chkcmbDieuChinh.Properties.Items[i].Value.ToString() == "7"))
                        count++;
                }
                if (count != 0)
                    panel1.Visible = true;
                else
                    panel1.Visible = false;
            }
        }

        private void chkcmbKhieuNai_EditValueChanged(object sender, EventArgs e)
        {
            if (chkcmbKhieuNai.Properties.Items.Count > 0)
            {
                for (int i = 0; i < chkcmbKhieuNai.Properties.Items.Count; i++)
                    if (chkcmbKhieuNai.Properties.Items[i].CheckState == CheckState.Checked && txtNoiDungKhachHang.Text.Trim().Contains(chkcmbKhieuNai.Properties.Items[i].ToString()) == false)
                    {
                        if (txtNoiDungKhachHang.Text.Trim() == "")
                            txtNoiDungKhachHang.Text = chkcmbKhieuNai.Properties.Items[i].ToString();
                        else
                            txtNoiDungKhachHang.Text += "; " + chkcmbKhieuNai.Properties.Items[i].ToString();
                    }
                    else
                        if (chkcmbKhieuNai.Properties.Items[i].CheckState == CheckState.Unchecked && txtNoiDungKhachHang.Text.Trim().Contains(chkcmbKhieuNai.Properties.Items[i].ToString()) == true)
                        {
                            txtNoiDungKhachHang.Text = txtNoiDungKhachHang.Text.Replace("; " + chkcmbKhieuNai.Properties.Items[i].ToString(), "");
                            txtNoiDungKhachHang.Text = txtNoiDungKhachHang.Text.Replace(chkcmbKhieuNai.Properties.Items[i].ToString() + "; ", "");
                            txtNoiDungKhachHang.Text = txtNoiDungKhachHang.Text.Replace(chkcmbKhieuNai.Properties.Items[i].ToString(), "");
                        }
            }
        }

        private void chkcmbDHN_EditValueChanged(object sender, EventArgs e)
        {
            if (chkcmbDHN.Properties.Items.Count > 0)
            {
                for (int i = 0; i < chkcmbDHN.Properties.Items.Count; i++)
                    if (chkcmbDHN.Properties.Items[i].CheckState == CheckState.Checked && txtNoiDungKhachHang.Text.Trim().Contains(chkcmbDHN.Properties.Items[i].ToString()) == false)
                    {
                        if (txtNoiDungKhachHang.Text.Trim() == "")
                            txtNoiDungKhachHang.Text = chkcmbDHN.Properties.Items[i].ToString();
                        else
                            txtNoiDungKhachHang.Text += "; " + chkcmbDHN.Properties.Items[i].ToString();
                    }
                    else
                        if (chkcmbDHN.Properties.Items[i].CheckState == CheckState.Unchecked && txtNoiDungKhachHang.Text.Trim().Contains(chkcmbDHN.Properties.Items[i].ToString()) == true)
                        {
                            txtNoiDungKhachHang.Text = txtNoiDungKhachHang.Text.Replace("; " + chkcmbDHN.Properties.Items[i].ToString(), "");
                            txtNoiDungKhachHang.Text = txtNoiDungKhachHang.Text.Replace(chkcmbDHN.Properties.Items[i].ToString() + "; ", "");
                            txtNoiDungKhachHang.Text = txtNoiDungKhachHang.Text.Replace(chkcmbDHN.Properties.Items[i].ToString(), "");
                        }
            }
        }

        private void chkcmbQuanLy_EditValueChanged(object sender, EventArgs e)
        {
            if (chkcmbQuanLy.Properties.Items.Count > 0)
            {
                for (int i = 0; i < chkcmbQuanLy.Properties.Items.Count; i++)
                    if (chkcmbQuanLy.Properties.Items[i].CheckState == CheckState.Checked && txtNoiDungKhachHang.Text.Trim().Contains(chkcmbQuanLy.Properties.Items[i].ToString()) == false)
                    {
                        if (txtNoiDungKhachHang.Text.Trim() == "")
                            txtNoiDungKhachHang.Text = chkcmbQuanLy.Properties.Items[i].ToString();
                        else
                            txtNoiDungKhachHang.Text += "; " + chkcmbQuanLy.Properties.Items[i].ToString();
                    }
                    else
                        if (chkcmbQuanLy.Properties.Items[i].CheckState == CheckState.Unchecked && txtNoiDungKhachHang.Text.Trim().Contains(chkcmbQuanLy.Properties.Items[i].ToString()) == true)
                        {
                            txtNoiDungKhachHang.Text = txtNoiDungKhachHang.Text.Replace("; " + chkcmbQuanLy.Properties.Items[i].ToString(), "");
                            txtNoiDungKhachHang.Text = txtNoiDungKhachHang.Text.Replace(chkcmbQuanLy.Properties.Items[i].ToString() + "; ", "");
                            txtNoiDungKhachHang.Text = txtNoiDungKhachHang.Text.Replace(chkcmbQuanLy.Properties.Items[i].ToString(), "");
                        }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    LinQ.DonTu entity = new LinQ.DonTu();
                    if (tabControl.SelectedTab.Name == "tabTTKH")
                    {
                        if (txtSoCongVan.Text.Trim() != "")
                        {
                            if (int.Parse(txtTongDB.Text.Trim()) != 1)
                            {
                                MessageBox.Show("Tổng Danh Bộ không đúng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        if (_cDonTu.checkExists_14ngay(txtDanhBo.Text.Trim().Replace(" ", "")) == true)
                        {
                            if (MessageBox.Show("Danh Bộ " + txtDanhBo.Text.Trim().Replace(" ", "") + " có Đơn trong 14 ngày gần nhất\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                return;
                        }
                        else
                            if (_cDonTu.checkExist_ChiTiet(txtDanhBo.Text.Trim().Replace(" ", ""), txtHoTen.Text.Trim(), txtDiaChi.Text.Trim(), DateTime.Now) == true)
                            {
                                if (MessageBox.Show("Danh Bộ " + txtDanhBo.Text.Trim().Replace(" ", "") + " đã nhận đơn trong ngày hôm nay rồi\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    return;
                            }

                        //if (_cKTXM.checkKhongLienHe(txtDanhBo.Text.Trim().Replace(" ", "")) == true)
                        //{
                        //    if (MessageBox.Show("Danh Bộ này Đã có THƯ MỜI bên Kiểm Tra Xác Minh, nhưng không liên hệ\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        //        //MessageBox.Show("Danh Bộ này Đã có THƯ MỜI, nhưng không liên hệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        return;
                        //}

                        if (txtSoNK.Text.Trim() != "")
                        {
                            entity.CCDM = chkCCDM.Checked;
                            entity.SoNK = int.Parse(txtSoNK.Text.Trim());
                            entity.HieuLucKy = txtHieuLucKy.Text.Trim();
                            if (cmbThoiHan.SelectedIndex >= 0)
                            {
                                entity.ThoiHan = cmbThoiHan.SelectedItem.ToString();
                                entity.NgayHetHan = dateHetHan.Value;
                            }
                        }

                        DonTu_ChiTiet entityCT = new DonTu_ChiTiet();
                        entityCT.ID = _cDonTu.getMaxID_ChiTiet() + 1;
                        entityCT.STT = 1;
                        entityCT.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                        entityCT.HopDong = txtHopDong.Text.Trim();
                        entityCT.DienThoai = txtDienThoai.Text.Trim();
                        entityCT.NguoiBao = txtNguoiBao.Text.Trim();
                        entityCT.HoTen = txtHoTen.Text.Trim();
                        entityCT.DiaChi = txtDiaChi.Text.Trim();
                        if (txtGiaBieu.Text.Trim() != "")
                            entityCT.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if (txtDinhMuc.Text.Trim() != "")
                            entityCT.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        if (txtDinhMucHN.Text.Trim() != "")
                            entityCT.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                        if (_hoadon != null)
                        {
                            entityCT.MLT = _hoadon.MALOTRINH;
                            entityCT.Dot = _hoadon.DOT;
                            entityCT.Ky = _hoadon.KY;
                            entityCT.Nam = _hoadon.NAM;
                            entityCT.Quan = _hoadon.Quan;
                            entityCT.Phuong = _hoadon.Phuong;
                        }
                        entityCT.ChanHoaDon = chkChanHoaDon.Checked;
                        if (txtKyHDChan.Text.Trim() != "")
                        {
                            string[] Kys = txtKyHDChan.Text.Trim().Split('/');
                            entityCT.ChanHoaDon_Ky = int.Parse(Kys[0]);
                            entityCT.ChanHoaDon_Nam = int.Parse(Kys[0]);
                            entityCT.ChanHoaDon_Ngay = DateTime.Now;
                        }
                        entityCT.HoTenMoi = txtHoTenMoi.Text.Trim();
                        entityCT.CCCD = txtCCCD.Text.Trim();
                        entityCT.NgayCap = txtNgayCap.Text.Trim();
                        entityCT.DCThuongTru = txtDCThuongTru.Text.Trim();
                        entityCT.DCHienNay = txtDCHienNay.Text.Trim();
                        entityCT.DienThoai = txtDienThoaiMoi.Text.Trim();
                        entityCT.Fax = txtFax.Text.Trim();
                        entityCT.Email = txtEmail.Text.Trim();
                        entityCT.STK = txtSTK.Text.Trim();
                        entityCT.Bank = txtBank.Text.Trim();
                        entityCT.MST = txtMST.Text.Trim();
                        entityCT.DCLapDat = txtDCLapDat.Text.Trim();
                        entityCT.CreateBy = CTaiKhoan.MaUser;
                        entityCT.CreateDate = DateTime.Now;
                        entityCT.TinhTrang = "Tồn";
                        entity.DonTu_ChiTiets.Add(entityCT);
                        //add điện thoại qua trung tam
                        if (entityCT.DienThoai.Replace(".", "").Replace(" ", "").Length == 10
                        && !_cDHN.checkExists_DienThoai(entityCT.DanhBo, entityCT.DienThoai.Replace(".", "").Replace(" ", "")))
                        {
                            SDT_DHN enSDT = new SDT_DHN();
                            enSDT.DanhBo = entityCT.DanhBo;
                            enSDT.DienThoai = entityCT.DienThoai.Replace(".", "").Replace(" ", "");
                            enSDT.GhiChu = "P. TV";
                            _cDHN.them_DienThoai(enSDT);
                        }
                    }
                    else if (tabControl.SelectedTab.Name == "tabCongVan")
                    {
                        if (int.Parse(txtTongDB.Text.Trim()) != dgvDanhBo.RowCount - 1)
                        {
                            MessageBox.Show("Tổng Danh Bộ không đúng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        foreach (DataGridViewRow item in dgvDanhBo.Rows)
                        {
                            if (item.Cells["DanhBo"].Value != null || item.Cells["HoTen"].Value != null || item.Cells["DiaChi"].Value != null)
                            {
                                if (item.Cells["DanhBo"].Value != null)
                                {
                                    if (_cDonTu.checkExists_14ngay(item.Cells["DanhBo"].Value.ToString()) == true)
                                    {
                                        if (MessageBox.Show("Danh Bộ " + item.Cells["DanhBo"].Value.ToString() + " có Đơn trong 14 ngày gần nhất\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                            return;
                                    }
                                    else
                                        if (_cDonTu.checkExist_ChiTiet(item.Cells["DanhBo"].Value.ToString(), item.Cells["HoTen"].Value.ToString(), item.Cells["DiaChi"].Value.ToString(), DateTime.Now) == true)
                                        {
                                            if (MessageBox.Show("Danh Bộ " + item.Cells["DanhBo"].Value.ToString() + " đã nhận đơn trong ngày hôm nay rồi\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                                return;
                                        }
                                }
                            }
                        }
                        int ID = _cDonTu.getMaxID_ChiTiet();
                        int STT = 0;
                        foreach (DataGridViewRow item in dgvDanhBo.Rows)
                        {
                            if (item.Cells["DanhBo"].Value != null || item.Cells["HoTen"].Value != null || item.Cells["DiaChi"].Value != null)
                            {
                                DonTu_ChiTiet entityCT = new DonTu_ChiTiet();
                                entityCT.ID = ++ID;
                                entityCT.STT = ++STT;

                                if (item.Cells["DanhBo"].Value != null && item.Cells["DanhBo"].Value.ToString() != "")
                                    entityCT.DanhBo = item.Cells["DanhBo"].Value.ToString();
                                if (item.Cells["QLDHN_MaDon"].Value != null && item.Cells["QLDHN_MaDon"].Value.ToString() != "")
                                    entityCT.QLDHN_MaDon = int.Parse(item.Cells["QLDHN_MaDon"].Value.ToString());
                                if (item.Cells["MLT"].Value != null && item.Cells["MLT"].Value.ToString() != "")
                                    entityCT.MLT = item.Cells["MLT"].Value.ToString();
                                if (item.Cells["HopDong"].Value != null && item.Cells["HopDong"].Value.ToString() != "")
                                    entityCT.HopDong = item.Cells["HopDong"].Value.ToString();
                                if (item.Cells["HoTen"].Value != null && item.Cells["HoTen"].Value.ToString() != "")
                                    entityCT.HoTen = item.Cells["HoTen"].Value.ToString();
                                if (item.Cells["DiaChi"].Value != null && item.Cells["DiaChi"].Value.ToString() != "")
                                    entityCT.DiaChi = item.Cells["DiaChi"].Value.ToString();
                                if (item.Cells["GiaBieu"].Value != null && item.Cells["GiaBieu"].Value.ToString() != "")
                                    entityCT.GiaBieu = int.Parse(item.Cells["GiaBieu"].Value.ToString());
                                if (item.Cells["DinhMuc"].Value != null && item.Cells["DinhMuc"].Value.ToString() != "")
                                    entityCT.DinhMuc = int.Parse(item.Cells["DinhMuc"].Value.ToString());
                                if (item.Cells["DinhMucHN"].Value != null && item.Cells["DinhMucHN"].Value.ToString() != "")
                                    entityCT.DinhMucHN = int.Parse(item.Cells["DinhMucHN"].Value.ToString());
                                if (item.Cells["Dot"].Value != null && item.Cells["Dot"].Value.ToString() != "")
                                    entityCT.Dot = int.Parse(item.Cells["Dot"].Value.ToString());
                                if (item.Cells["Ky"].Value != null && item.Cells["Ky"].Value.ToString() != "")
                                    entityCT.Ky = int.Parse(item.Cells["Ky"].Value.ToString());
                                if (item.Cells["Nam"].Value != null && item.Cells["Nam"].Value.ToString() != "")
                                    entityCT.Nam = int.Parse(item.Cells["Nam"].Value.ToString());
                                if (item.Cells["Quan"].Value != null && item.Cells["Quan"].Value.ToString() != "")
                                    entityCT.Quan = item.Cells["Quan"].Value.ToString();
                                if (item.Cells["Phuong"].Value != null && item.Cells["Phuong"].Value.ToString() != "")
                                    entityCT.Phuong = item.Cells["Phuong"].Value.ToString();

                                entityCT.ChanHoaDon = chkChanHoaDon.Checked;
                                entityCT.CreateBy = CTaiKhoan.MaUser;
                                entityCT.CreateDate = DateTime.Now;
                                entityCT.TinhTrang = "Tồn";

                                entity.DonTu_ChiTiets.Add(entityCT);
                            }
                        }
                    }
                    //
                    if (txtSoCongVan.Text.Trim() != "")
                    {
                        if (cmbPhongBanDoi.SelectedIndex != -1)
                            entity.SoCongVan_PhongBanDoi = cmbPhongBanDoi.SelectedValue.ToString();
                        entity.SoCongVan = txtSoCongVan.Text.Trim();
                        entity.TongDB = int.Parse(txtTongDB.Text.Trim());
                    }
                    //
                    entity.NgayHenGiaiQuyet = "Trong thời gian 5 ngày làm việc kể từ ngày nhận hồ sơ, sẽ có nhân viên đến liên hệ với Khách Hàng. ";
                    //entity.NgayHenGiaiQuyet = "";
                    entity.ID_NhomDon_PKH = "";
                    bool flag = false;
                    for (int i = 0; i < chkcmbDieuChinh.Properties.Items.Count; i++)
                        if (chkcmbDieuChinh.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            if (!flag)
                                flag = _wsThuongVu.checkExists_DonTu(entity.DanhBo, chkcmbDieuChinh.Properties.Items[i].Value.ToString(), "30");
                            if (entity.ID_NhomDon_PKH == "")
                                entity.ID_NhomDon_PKH = chkcmbDieuChinh.Properties.Items[i].Value.ToString();
                            else
                                entity.ID_NhomDon_PKH += ";" + chkcmbDieuChinh.Properties.Items[i].Value.ToString();
                            if (chkcmbDieuChinh.Properties.Items[i].Value.ToString() == "9")
                                entity.NgayHenGiaiQuyet = "Quý khách nhận lại Hợp Đồng vào ngày " + _cDonTu.GetToDate(DateTime.Now, 30).ToString("dd/MM/yyyy") + ". Quá thời hạn trên, Khách Hàng không liên hệ nhận Hợp Đồng; mọi Khiếu Nại về sau sẽ không được giải quyết. ";
                        }
                    for (int i = 0; i < chkcmbKhieuNai.Properties.Items.Count; i++)
                        if (chkcmbKhieuNai.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            if (!flag)
                                flag = _wsThuongVu.checkExists_DonTu(entity.DanhBo, chkcmbKhieuNai.Properties.Items[i].Value.ToString(), "30");
                            if (entity.ID_NhomDon_PKH == "")
                                entity.ID_NhomDon_PKH = chkcmbKhieuNai.Properties.Items[i].Value.ToString();
                            else
                                entity.ID_NhomDon_PKH += ";" + chkcmbKhieuNai.Properties.Items[i].Value.ToString();
                        }
                    for (int i = 0; i < chkcmbDHN.Properties.Items.Count; i++)
                        if (chkcmbDHN.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            if (!flag)
                                flag = _wsThuongVu.checkExists_DonTu(entity.DanhBo, chkcmbDHN.Properties.Items[i].Value.ToString(), "30");
                            if (entity.ID_NhomDon_PKH == "")
                                entity.ID_NhomDon_PKH = chkcmbDHN.Properties.Items[i].Value.ToString();
                            else
                                entity.ID_NhomDon_PKH += ";" + chkcmbDHN.Properties.Items[i].Value.ToString();
                        }
                    for (int i = 0; i < chkcmbQuanLy.Properties.Items.Count; i++)
                        if (chkcmbQuanLy.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            if (!flag)
                                flag = _wsThuongVu.checkExists_DonTu(entity.DanhBo, chkcmbQuanLy.Properties.Items[i].Value.ToString(), "30");
                            if (entity.ID_NhomDon_PKH == "")
                                entity.ID_NhomDon_PKH = chkcmbQuanLy.Properties.Items[i].Value.ToString();
                            else
                                entity.ID_NhomDon_PKH += ";" + chkcmbQuanLy.Properties.Items[i].Value.ToString();
                        }
                    entity.Name_NhomDon_PKH = txtNoiDungKhachHang.Text.Trim();
                    if (txtVanDeKhac.Text.Trim() != "")
                        entity.VanDeKhac = txtVanDeKhac.Text.Trim();
                    //if (cmbNhomDon_ChiTiet.SelectedIndex > -1)
                    //{
                    //    entity.ID_NhomDon_ChiTiet = int.Parse(cmbNhomDon_ChiTiet.SelectedValue.ToString());
                    //    entity.Name_NhomDon_ChiTiet = cmbNhomDon_ChiTiet.Text;
                    //}
                    if (flag)
                    {
                        if (MessageBox.Show("Danh Bộ " + txtDanhBo.Text.Trim().Replace(" ", "") + " đã nhận đơn cùng nội dùng trong 30 ngày\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return;
                    }
                    ///
                    if (chkCT_HopDongNganHang.Checked)
                        entity.CT_HopDongNganHang = true;
                    if (chkCT_GiaiQuyet_Huy_DKCT.Checked)
                        entity.CT_GiaiQuyet_Huy_DKCT = true;
                    if (chkCT_HDTN_CQN.Checked)
                        entity.CT_HDTN_CQN = true;
                    if (chkCT_CQN.Checked)
                        entity.CT_CQN = true;
                    if (chkCT_Khac.Checked)
                    {
                        entity.CT_Khac = true;
                        entity.CT_Khac_GhiChu = txtCT_Khac_GhiChu.Text.Trim();
                    }

                    if (chkCT_HK_KT3.Checked)
                        entity.CT_HK_KT3 = true;
                    //if (chkCT_STT_GXNTT.Checked)
                    //    entity.CT_STT_GXNTT = true;
                    if (chkCT_GDKKD.Checked)
                        entity.CT_GDKKD = true;
                    if (chkCT_GiayUyQuyen.Checked)
                        entity.CT_GiayUyQuyen = true;

                    if (chkCT_GC_SDSN.Checked)
                        entity.CT_GC_SDSN = true;
                    //if (chkCT_GXN2SN.Checked)
                    //    entity.CT_GXN2SN = true;
                    if (chkCT_GCNDTDHN.Checked)
                        entity.CT_GCNDTDHN = true;
                    if (chkCT_CVXuatHD.Checked)
                        entity.CT_CVXuatHD = true;
                    entity.VanPhong = chkVanPhong.Checked;
                    entity.MaPhong = CTaiKhoan.MaPhong;
                    ///
                    if (_cDonTu.Them(entity))
                    {
                        MessageBox.Show("Thành công\nMã Đơn: " + entity.MaDon.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (chkKhongInBienNhan.Checked == false)
                            InBienNhan(entity);
                        Clear();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (_dontu != null)
                    {
                        if (CTaiKhoan.Admin == false && _cDonTu.checkPhong(_dontu.MaDon, CTaiKhoan.MaPhong) == false)
                        {
                            MessageBox.Show("Mã Đơn này không thuộc phòng của bạn lập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (_dontu.DonTu_ChiTiets.Count == 1)
                        {
                            if (txtDanhBo.Text.Trim().Replace(" ", "") != _dontu.DonTu_ChiTiets.SingleOrDefault().DanhBo || txtHoTen.Text.Trim() != _dontu.DonTu_ChiTiets.SingleOrDefault().HoTen || txtDiaChi.Text.Trim() != _dontu.DonTu_ChiTiets.SingleOrDefault().DiaChi)
                                if (_cDonTu.checkExist_ChiTiet(txtDanhBo.Text.Trim().Replace(" ", ""), txtHoTen.Text.Trim(), txtDiaChi.Text.Trim(), DateTime.Now) == true)
                                {
                                    if (MessageBox.Show("Danh Bộ " + txtDanhBo.Text.Trim().Replace(" ", "") + " đã nhận đơn trong ngày hôm nay rồi\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                        return;
                                }
                            if (txtSoNK.Text.Trim() != "")
                            {
                                _dontu.CCDM = chkCCDM.Checked;
                                _dontu.SoNK = int.Parse(txtSoNK.Text.Trim());
                                _dontu.HieuLucKy = txtHieuLucKy.Text.Trim();
                            }
                            else
                                if (_dontu.SoNK != null)
                                {
                                    _dontu.CCDM = false;
                                    _dontu.SoNK = null;
                                    _dontu.HieuLucKy = null;
                                }
                            _dontu.DonTu_ChiTiets.SingleOrDefault().DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                            _dontu.DonTu_ChiTiets.SingleOrDefault().HopDong = txtHopDong.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().DienThoai = txtDienThoai.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().NguoiBao = txtNguoiBao.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().HoTen = txtHoTen.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().DiaChi = txtDiaChi.Text.Trim();
                            if (txtGiaBieu.Text.Trim() != "")
                                _dontu.DonTu_ChiTiets.SingleOrDefault().GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                            if (txtDinhMuc.Text.Trim() != "")
                                _dontu.DonTu_ChiTiets.SingleOrDefault().DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                            if (txtDinhMucHN.Text.Trim() != "")
                                _dontu.DonTu_ChiTiets.SingleOrDefault().DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                            if (_hoadon != null && _hoadon.DANHBA != txtDanhBo.Text.Trim().Replace(" ", ""))
                            {
                                _dontu.DonTu_ChiTiets.SingleOrDefault().MLT = _hoadon.MALOTRINH;
                                _dontu.DonTu_ChiTiets.SingleOrDefault().Dot = _hoadon.DOT;
                                _dontu.DonTu_ChiTiets.SingleOrDefault().Ky = _hoadon.KY;
                                _dontu.DonTu_ChiTiets.SingleOrDefault().Nam = _hoadon.NAM;
                                _dontu.DonTu_ChiTiets.SingleOrDefault().Quan = _hoadon.Quan;
                                _dontu.DonTu_ChiTiets.SingleOrDefault().Phuong = _hoadon.Phuong;
                            }
                            _dontu.DonTu_ChiTiets.SingleOrDefault().ChanHoaDon = chkChanHoaDon.Checked;
                            if (txtKyHDChan.Text.Trim() != "")
                            {
                                string[] Kys = txtKyHDChan.Text.Trim().Split('/');
                                _dontu.DonTu_ChiTiets.SingleOrDefault().ChanHoaDon_Ky = int.Parse(Kys[0]);
                                _dontu.DonTu_ChiTiets.SingleOrDefault().ChanHoaDon_Nam = int.Parse(Kys[0]);
                            }
                            _dontu.DonTu_ChiTiets.SingleOrDefault().HoTenMoi = txtHoTenMoi.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().CCCD = txtCCCD.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().NgayCap = txtNgayCap.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().DCThuongTru = txtDCThuongTru.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().DCHienNay = txtDCHienNay.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().DienThoai = txtDienThoaiMoi.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().Fax = txtFax.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().Email = txtEmail.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().STK = txtSTK.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().Bank = txtBank.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().MST = txtMST.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().DCLapDat = txtDCLapDat.Text.Trim();
                        }
                        if (tabControl.SelectedTab.Name == "tabTTKH")
                        {
                            if (txtSoCongVan.Text.Trim() != "")
                            {
                                if (int.Parse(txtTongDB.Text.Trim()) != 1)
                                {
                                    MessageBox.Show("Tổng Danh Bộ không đúng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                        else if (tabControl.SelectedTab.Name == "tabCongVan")
                        {
                            if (int.Parse(txtTongDB.Text.Trim()) != dgvDanhBo.RowCount - 1)
                            {
                                MessageBox.Show("Tổng Danh Bộ không đúng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            for (int i = 0; i < _dontu.DonTu_ChiTiets.Count; i++)
                            {
                                _dontu.DonTu_ChiTiets[i].STT = i + 1;
                            }
                        }
                        //
                        _dontu.VanPhong = chkVanPhong.Checked;
                        if (txtSoCongVan.Text.Trim() != "")
                        {
                            if (cmbPhongBanDoi.SelectedIndex != -1)
                                _dontu.SoCongVan_PhongBanDoi = cmbPhongBanDoi.SelectedValue.ToString();
                            _dontu.SoCongVan = txtSoCongVan.Text.Trim();
                            _dontu.TongDB = int.Parse(txtTongDB.Text.Trim());
                        }
                        else
                        {
                            _dontu.SoCongVan = null;
                            _dontu.TongDB = 0;
                        }
                        ///
                        _dontu.ID_NhomDon_PKH = "";
                        _dontu.NgayHenGiaiQuyet = "Trong thời gian 5 ngày làm việc kể từ ngày nhận hồ sơ, Công ty sẽ giải quyết theo quy định hiện hành";
                        for (int i = 0; i < chkcmbDieuChinh.Properties.Items.Count; i++)
                            if (chkcmbDieuChinh.Properties.Items[i].CheckState == CheckState.Checked)
                            {
                                if (_dontu.ID_NhomDon_PKH == "")
                                    _dontu.ID_NhomDon_PKH = chkcmbDieuChinh.Properties.Items[i].Value.ToString();
                                else
                                    _dontu.ID_NhomDon_PKH += ";" + chkcmbDieuChinh.Properties.Items[i].Value.ToString();
                                if (chkcmbDieuChinh.Properties.Items[i].Value.ToString() == "9")
                                    _dontu.NgayHenGiaiQuyet = "Quý khách nhận lại Hợp Đồng vào ngày " + _cDonTu.GetToDate(_dontu.CreateDate.Value, 30).ToString("dd/MM/yyyy") + ". Quá thời hạn trên, Khách Hàng không liên hệ nhận Hợp Đồng; mọi Khiếu Nại về sau sẽ không được giải quyết";
                            }
                        for (int i = 0; i < chkcmbKhieuNai.Properties.Items.Count; i++)
                            if (chkcmbKhieuNai.Properties.Items[i].CheckState == CheckState.Checked)
                            {
                                if (_dontu.ID_NhomDon_PKH == "")
                                    _dontu.ID_NhomDon_PKH = chkcmbKhieuNai.Properties.Items[i].Value.ToString();
                                else
                                    _dontu.ID_NhomDon_PKH += ";" + chkcmbKhieuNai.Properties.Items[i].Value.ToString();
                            }
                        for (int i = 0; i < chkcmbDHN.Properties.Items.Count; i++)
                            if (chkcmbDHN.Properties.Items[i].CheckState == CheckState.Checked)
                            {
                                if (_dontu.ID_NhomDon_PKH == "")
                                    _dontu.ID_NhomDon_PKH = chkcmbDHN.Properties.Items[i].Value.ToString();
                                else
                                    _dontu.ID_NhomDon_PKH += ";" + chkcmbDHN.Properties.Items[i].Value.ToString();
                            }
                        for (int i = 0; i < chkcmbQuanLy.Properties.Items.Count; i++)
                            if (chkcmbQuanLy.Properties.Items[i].CheckState == CheckState.Checked)
                            {
                                if (_dontu.ID_NhomDon_PKH == "")
                                    _dontu.ID_NhomDon_PKH = chkcmbQuanLy.Properties.Items[i].Value.ToString();
                                else
                                    _dontu.ID_NhomDon_PKH += ";" + chkcmbQuanLy.Properties.Items[i].Value.ToString();
                            }
                        _dontu.Name_NhomDon_PKH = txtNoiDungKhachHang.Text.Trim();
                        if (txtVanDeKhac.Text.Trim() != "")
                            _dontu.VanDeKhac = txtVanDeKhac.Text.Trim();
                        //if (cmbNhomDon_ChiTiet.SelectedIndex > -1)
                        //{
                        //    _dontu.ID_NhomDon_ChiTiet = int.Parse(cmbNhomDon_ChiTiet.SelectedValue.ToString());
                        //    _dontu.Name_NhomDon_ChiTiet = cmbNhomDon_ChiTiet.Text;
                        //}
                        ///
                        if (chkCT_HopDongNganHang.Checked)
                            _dontu.CT_HopDongNganHang = true;
                        else
                            _dontu.CT_HopDongNganHang = false;

                        if (chkCT_GiaiQuyet_Huy_DKCT.Checked)
                            _dontu.CT_GiaiQuyet_Huy_DKCT = true;
                        else
                            _dontu.CT_GiaiQuyet_Huy_DKCT = false;

                        if (chkCT_HDTN_CQN.Checked)
                            _dontu.CT_HDTN_CQN = true;
                        else
                            _dontu.CT_HDTN_CQN = false;

                        if (chkCT_CQN.Checked)
                            _dontu.CT_CQN = true;
                        else
                            _dontu.CT_CQN = false;

                        if (chkCT_Khac.Checked)
                        {
                            _dontu.CT_Khac = true;
                            _dontu.CT_Khac_GhiChu = txtCT_Khac_GhiChu.Text.Trim();
                        }
                        else
                        {
                            _dontu.CT_Khac = false;
                            _dontu.CT_Khac_GhiChu = null;
                        }

                        //

                        if (chkCT_HK_KT3.Checked)
                            _dontu.CT_HK_KT3 = true;
                        else
                            _dontu.CT_HK_KT3 = false;

                        //if (chkCT_STT_GXNTT.Checked)
                        //    _dontu.CT_STT_GXNTT = true;
                        //else
                        //    _dontu.CT_STT_GXNTT = false;

                        if (chkCT_GDKKD.Checked)
                            _dontu.CT_GDKKD = true;
                        else
                            _dontu.CT_GDKKD = false;
                        if (chkCT_GiayUyQuyen.Checked)
                            _dontu.CT_GiayUyQuyen = true;
                        else
                            _dontu.CT_GiayUyQuyen = false;

                        //

                        if (chkCT_GC_SDSN.Checked)
                            _dontu.CT_GC_SDSN = true;
                        else
                            _dontu.CT_GC_SDSN = false;

                        //if (chkCT_GXN2SN.Checked)
                        //    _dontu.CT_GXN2SN = true;
                        //else
                        //    _dontu.CT_GXN2SN = false;

                        if (chkCT_GCNDTDHN.Checked)
                            _dontu.CT_GCNDTDHN = true;
                        else
                            _dontu.CT_GCNDTDHN = false;
                        if (chkCT_CVXuatHD.Checked)
                            _dontu.CT_CVXuatHD = true;
                        else
                            _dontu.CT_CVXuatHD = false;
                        ///
                        if (_cDonTu.Sua(_dontu))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (_dontu != null && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (CTaiKhoan.Admin == false && _cDonTu.checkPhong(_dontu.MaDon, CTaiKhoan.MaPhong) == false)
                        {
                            MessageBox.Show("Mã Đơn này không thuộc phòng của bạn lập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (_cDonTu.Xoa(_dontu))
                        {
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
                {
                    if (_cDHN.CheckExist(txtDanhBo.Text.Trim().Replace(" ", "")) == false)
                        MessageBox.Show("Danh Bộ Hủy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (_cGanMoi.checkTaiLapChuaCoHoaDon(txtDanhBo.Text.Trim().Replace(" ", "")))
                    MessageBox.Show("Danh Bộ tái lập chưa có hóa đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMaDon.Text.Trim() != "" && e.KeyChar == 13)
            {
                int MaDon = int.Parse(txtMaDon.Text.Trim());
                Clear();
                _dontu = _cDonTu.get(MaDon);
                if (_dontu != null)
                {
                    LoadDonTu(_dontu);
                }
                else
                {
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_dontu != null)
                InBienNhan(_dontu);
        }

        public void InBienNhan(LinQ.DonTu entity)
        {
            try
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                dr["MaDon"] = entity.MaDon.ToString();

                if (entity.DonTu_ChiTiets.Count == 1)
                {
                    dr["KhachHang"] = entity.DonTu_ChiTiets.SingleOrDefault().HoTen;
                    if (entity.DonTu_ChiTiets.SingleOrDefault().DanhBo != "")
                        dr["DanhBo"] = entity.DonTu_ChiTiets.SingleOrDefault().DanhBo.Insert(7, " ").Insert(4, " ");
                    dr["DiaChi"] = entity.DonTu_ChiTiets.SingleOrDefault().DiaChi;
                    dr["HopDong"] = entity.DonTu_ChiTiets.SingleOrDefault().HopDong;
                    dr["GiaBieu"] = entity.DonTu_ChiTiets.SingleOrDefault().GiaBieu;
                    dr["DinhMuc"] = entity.DonTu_ChiTiets.SingleOrDefault().DinhMuc;
                    dr["DinhMucHN"] = entity.DonTu_ChiTiets.SingleOrDefault().DinhMucHN;
                    dr["DienThoai"] = entity.DonTu_ChiTiets.SingleOrDefault().DienThoai;
                    if (entity.DonTu_ChiTiets.SingleOrDefault().ChanHoaDon == true)
                    {
                        dr["PathLogo"] = "***";
                    }
                }
                dr["NoiDung"] = entity.Name_NhomDon_PKH;
                if (entity.CCDM)
                {
                    dr["LyDoLoaiKhac"] = "(CCĐM) ";
                }
                dr["LyDoLoaiKhac"] += entity.VanDeKhac;

                #region CheckBox

                if (entity.CT_HopDongNganHang)
                {
                    dr["CT_HopDongNganHang"] = true;
                }
                else
                {
                    dr["CT_HopDongNganHang"] = false;
                }

                if (entity.CT_GiaiQuyet_Huy_DKCT)
                {
                    dr["CT_GiayBao"] = true;
                }
                else
                {
                    dr["CT_GiayBao"] = false;
                }

                if (entity.CT_HDTN_CQN)
                {
                    dr["CT_HDTN_CQN"] = true;
                }
                else
                {
                    dr["CT_HDTN_CQN"] = false;
                }

                if (entity.CT_CQN)
                {
                    dr["CT_CQN"] = true;
                }
                else
                {
                    dr["CT_CQN"] = false;
                }

                if (entity.CT_Khac)
                {
                    dr["CT_Khac"] = true;
                    dr["CT_Khac_GhiChu"] = entity.CT_Khac_GhiChu;
                }
                else
                {
                    dr["CT_Khac"] = false;
                }

                //

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

                if (entity.CT_GDKKD)
                {
                    dr["CT_GDKKD"] = true;
                }
                else
                {
                    dr["CT_GDKKD"] = false;
                }

                if (entity.CT_GiayUyQuyen)
                {
                    dr["CT_HoNgheo"] = true;
                }
                else
                {
                    dr["CT_HoNgheo"] = false;
                }

                //

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

                if (entity.CT_GCNDTDHN)
                {
                    dr["CT_GCNDTDHN"] = true;
                }
                else
                {
                    dr["CT_GCNDTDHN"] = false;
                }

                if (entity.CT_CVXuatHD)
                {
                    dr["CT_CVXuatHD"] = true;
                }
                else
                {
                    dr["CT_CVXuatHD"] = false;
                }
                #endregion

                dr["NgayGiaiQuyet"] = entity.NgayHenGiaiQuyet;
                if (entity.SoNK != null)
                    dr["DinhMucSau"] = entity.SoNK * 4;
                dr["HieuLucTuKy"] = entity.HieuLucKy;
                if (entity.NgayHetHan != null)
                {
                    dr["NgayHetHan"] = entity.NgayHetHan.Value.ToString("dd/MM/yyyy");
                    dr["TenLD"] = "Đề nghị khách hàng liên hệ Công ty đăng ký lại định mức nước khi hết hạn.";
                }
                else
                    dr["NgayHetHan"] = "";
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                dr["HoTenNV"] = CTaiKhoan.HoTen;
                QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
                QRCoder.QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://service.cskhtanhoa.com.vn/khachhang/tientrinhdon?id=" + entity.MaDon, QRCoder.QRCodeGenerator.ECCLevel.H);
                QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData);
                Bitmap qrCodeImage;
                qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, false);
                qrCodeImage = _cDonTu.resizeImage(qrCodeImage, 170, 170);
                //System.IO.File.WriteAllBytes(@"D:\qrcode.jpg", _cDonTu.ImageToByte(qrCodeImage));
                //dr["QRCode"] = @"D:\qrcode.jpg";
                dr["QRCode"] = _cDonTu.ImageToByte(qrCodeImage);
                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(dr);
                rptBienNhanDonTu rpt = new rptBienNhanDonTu();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhBo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((dgvDanhBo.Columns[e.ColumnIndex].Name == "DanhBo" && dgvDanhBo["DanhBo", e.RowIndex].Value != null) || (dgvDanhBo.Columns[e.ColumnIndex].Name == "DiaChi" && dgvDanhBo["DiaChi", e.RowIndex].Value != null))
            {
                for (int i = 0; i < dgvDanhBo.Rows.Count; i++)
                    if (i != e.RowIndex && dgvDanhBo["DanhBo", i].Value != null && dgvDanhBo["DanhBo", e.RowIndex].Value != null && dgvDanhBo["DanhBo", i].Value.ToString() != "" && dgvDanhBo["DanhBo", i].Value.ToString() == dgvDanhBo["DanhBo", e.RowIndex].Value.ToString())
                    {
                        MessageBox.Show("Danh Bộ đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                if (dgvDanhBo["DanhBo", e.RowIndex].Value != null)
                {
                    HOADON hoadon = _cThuTien.GetMoiNhat(dgvDanhBo["DanhBo", e.RowIndex].Value.ToString());
                    if (hoadon != null)
                    {
                        dgvDanhBo["HopDong", e.RowIndex].Value = hoadon.HOPDONG;
                        dgvDanhBo["HoTen", e.RowIndex].Value = hoadon.TENKH;
                        dgvDanhBo["DiaChi", e.RowIndex].Value = hoadon.SO + " " + hoadon.DUONG + _cDHN.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
                        dgvDanhBo["GiaBieu", e.RowIndex].Value = hoadon.GB;
                        dgvDanhBo["DinhMuc", e.RowIndex].Value = hoadon.DM;
                        dgvDanhBo["DinhMucHN", e.RowIndex].Value = hoadon.DinhMucHN;
                        dgvDanhBo["Dot", e.RowIndex].Value = hoadon.DOT;
                        dgvDanhBo["Ky", e.RowIndex].Value = hoadon.KY;
                        dgvDanhBo["Nam", e.RowIndex].Value = hoadon.NAM;
                        dgvDanhBo["MLT", e.RowIndex].Value = hoadon.MALOTRINH;
                        dgvDanhBo["Quan", e.RowIndex].Value = hoadon.Quan;
                        dgvDanhBo["Phuong", e.RowIndex].Value = hoadon.Phuong;
                        dgvLichSuNhanDon.DataSource = _cDonTu.getDS_ChiTiet_ByDanhBo(hoadon.DANHBA);
                    }
                    else
                    {
                        MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //update record đã lưu
                if (dgvDanhBo["ID", e.RowIndex].Value != null)
                {
                    DonTu_ChiTiet en = _cDonTu.get_ChiTiet(int.Parse(dgvDanhBo["ID", e.RowIndex].Value.ToString()));
                    if (dgvDanhBo["DanhBo", e.RowIndex].Value != null && dgvDanhBo["DanhBo", e.RowIndex].Value.ToString() != "")
                        en.DanhBo = dgvDanhBo["DanhBo", e.RowIndex].Value.ToString();
                    if (dgvDanhBo["QLDHN_MaDon", e.RowIndex].Value != null && dgvDanhBo["QLDHN_MaDon", e.RowIndex].Value.ToString() != "")
                        en.QLDHN_MaDon = int.Parse(dgvDanhBo["QLDHN_MaDon", e.RowIndex].Value.ToString());
                    else
                        en.QLDHN_MaDon = null;
                    if (dgvDanhBo["MLT", e.RowIndex].Value != null && dgvDanhBo["MLT", e.RowIndex].Value.ToString() != "")
                        en.MLT = dgvDanhBo["MLT", e.RowIndex].Value.ToString();
                    if (dgvDanhBo["HopDong", e.RowIndex].Value != null && dgvDanhBo["HopDong", e.RowIndex].Value.ToString() != "")
                        en.HopDong = dgvDanhBo["HopDong", e.RowIndex].Value.ToString();
                    if (dgvDanhBo["HoTen", e.RowIndex].Value != null && dgvDanhBo["HoTen", e.RowIndex].Value.ToString() != "")
                        en.HoTen = dgvDanhBo["HoTen", e.RowIndex].Value.ToString();
                    if (dgvDanhBo["DiaChi", e.RowIndex].Value != null && dgvDanhBo["DiaChi", e.RowIndex].Value.ToString() != "")
                        en.DiaChi = dgvDanhBo["DiaChi", e.RowIndex].Value.ToString();
                    if (dgvDanhBo["GiaBieu", e.RowIndex].Value != null && dgvDanhBo["GiaBieu", e.RowIndex].Value.ToString() != "")
                        en.GiaBieu = int.Parse(dgvDanhBo["GiaBieu", e.RowIndex].Value.ToString());
                    if (dgvDanhBo["DinhMuc", e.RowIndex].Value != null && dgvDanhBo["DinhMuc", e.RowIndex].Value.ToString() != "")
                        en.DinhMuc = int.Parse(dgvDanhBo["DinhMuc", e.RowIndex].Value.ToString());
                    if (dgvDanhBo["DinhMucHN", e.RowIndex].Value != null && dgvDanhBo["DinhMucHN", e.RowIndex].Value.ToString() != "")
                        en.DinhMucHN = int.Parse(dgvDanhBo["DinhMucHN", e.RowIndex].Value.ToString());
                    if (dgvDanhBo["Dot", e.RowIndex].Value != null && dgvDanhBo["Dot", e.RowIndex].Value.ToString() != "")
                        en.Dot = int.Parse(dgvDanhBo["Dot", e.RowIndex].Value.ToString());
                    if (dgvDanhBo["Ky", e.RowIndex].Value != null && dgvDanhBo["Ky", e.RowIndex].Value.ToString() != "")
                        en.Ky = int.Parse(dgvDanhBo["Ky", e.RowIndex].Value.ToString());
                    if (dgvDanhBo["Nam", e.RowIndex].Value != null && dgvDanhBo["Nam", e.RowIndex].Value.ToString() != "")
                        en.Nam = int.Parse(dgvDanhBo["Nam", e.RowIndex].Value.ToString());
                    if (dgvDanhBo["Quan", e.RowIndex].Value != null && dgvDanhBo["Quan", e.RowIndex].Value.ToString() != "")
                        en.Quan = dgvDanhBo["Quan", e.RowIndex].Value.ToString();
                    if (dgvDanhBo["Phuong", e.RowIndex].Value != null && dgvDanhBo["Phuong", e.RowIndex].Value.ToString() != "")
                        en.Phuong = dgvDanhBo["Phuong", e.RowIndex].Value.ToString();
                    en.ModifyBy = CTaiKhoan.MaUser;
                    en.ModifyDate = DateTime.Now;
                    _cDonTu.SubmitChanges();
                }
                //thêm row mới
                if (_flagdgvDanhBo_inserRow == true)
                {
                    DonTu_ChiTiet en = new DonTu_ChiTiet();
                    if (dgvDanhBo["DanhBo", e.RowIndex].Value != null && dgvDanhBo["DanhBo", e.RowIndex].Value.ToString() != "")
                        en.DanhBo = dgvDanhBo["DanhBo", e.RowIndex].Value.ToString();
                    if (dgvDanhBo["QLDHN_MaDon", e.RowIndex].Value != null && dgvDanhBo["QLDHN_MaDon", e.RowIndex].Value.ToString() != "")
                        en.QLDHN_MaDon = int.Parse(dgvDanhBo["QLDHN_MaDon", e.RowIndex].Value.ToString());
                    else
                        en.QLDHN_MaDon = null;
                    if (dgvDanhBo["MLT", e.RowIndex].Value != null && dgvDanhBo["MLT", e.RowIndex].Value.ToString() != "")
                        en.MLT = dgvDanhBo["MLT", e.RowIndex].Value.ToString();
                    if (dgvDanhBo["HopDong", e.RowIndex].Value != null && dgvDanhBo["HopDong", e.RowIndex].Value.ToString() != "")
                        en.HopDong = dgvDanhBo["HopDong", e.RowIndex].Value.ToString();
                    if (dgvDanhBo["HoTen", e.RowIndex].Value != null && dgvDanhBo["HoTen", e.RowIndex].Value.ToString() != "")
                        en.HoTen = dgvDanhBo["HoTen", e.RowIndex].Value.ToString();
                    if (dgvDanhBo["DiaChi", e.RowIndex].Value != null && dgvDanhBo["DiaChi", e.RowIndex].Value.ToString() != "")
                        en.DiaChi = dgvDanhBo["DiaChi", e.RowIndex].Value.ToString();
                    if (dgvDanhBo["GiaBieu", e.RowIndex].Value != null && dgvDanhBo["GiaBieu", e.RowIndex].Value.ToString() != "")
                        en.GiaBieu = int.Parse(dgvDanhBo["GiaBieu", e.RowIndex].Value.ToString());
                    if (dgvDanhBo["DinhMuc", e.RowIndex].Value != null && dgvDanhBo["DinhMuc", e.RowIndex].Value.ToString() != "")
                        en.DinhMuc = int.Parse(dgvDanhBo["DinhMuc", e.RowIndex].Value.ToString());
                    if (dgvDanhBo["DinhMucHN", e.RowIndex].Value != null && dgvDanhBo["DinhMucHN", e.RowIndex].Value.ToString() != "")
                        en.DinhMucHN = int.Parse(dgvDanhBo["DinhMucHN", e.RowIndex].Value.ToString());
                    if (dgvDanhBo["Dot", e.RowIndex].Value != null && dgvDanhBo["Dot", e.RowIndex].Value.ToString() != "")
                        en.Dot = int.Parse(dgvDanhBo["Dot", e.RowIndex].Value.ToString());
                    if (dgvDanhBo["Ky", e.RowIndex].Value != null && dgvDanhBo["Ky", e.RowIndex].Value.ToString() != "")
                        en.Ky = int.Parse(dgvDanhBo["Ky", e.RowIndex].Value.ToString());
                    if (dgvDanhBo["Nam", e.RowIndex].Value != null && dgvDanhBo["Nam", e.RowIndex].Value.ToString() != "")
                        en.Nam = int.Parse(dgvDanhBo["Nam", e.RowIndex].Value.ToString());
                    if (dgvDanhBo["Quan", e.RowIndex].Value != null && dgvDanhBo["Quan", e.RowIndex].Value.ToString() != "")
                        en.Quan = dgvDanhBo["Quan", e.RowIndex].Value.ToString();
                    if (dgvDanhBo["Phuong", e.RowIndex].Value != null && dgvDanhBo["Phuong", e.RowIndex].Value.ToString() != "")
                        en.Phuong = dgvDanhBo["Phuong", e.RowIndex].Value.ToString();
                    en.MaDon = _dontu.MaDon;
                    en.ID = _cDonTu.getMaxID_ChiTiet() + 1;
                    if (_dontu.DonTu_ChiTiets.Max(item => item.STT) == null)
                        en.STT = 1;
                    else
                        en.STT = _dontu.DonTu_ChiTiets.Max(item => item.STT) + 1;
                    en.CreateBy = CTaiKhoan.MaUser;
                    en.CreateDate = DateTime.Now;
                    _dontu.DonTu_ChiTiets.Add(en);
                    _cDonTu.SubmitChanges();
                    //_cDonTu.Them_ChiTiet(en);
                    _flagdgvDanhBo_inserRow = false;
                }
            }
        }

        private void dgvDanhBo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhBo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtSoNK_TextChanged(object sender, EventArgs e)
        {
            if (txtSoNK.Text.Trim() != "")
                txtDM.Text = (int.Parse(txtSoNK.Text.Trim()) * 4).ToString();
            else
                txtDM.Text = "";
        }

        private void txtSoNK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoNK_Leave(object sender, EventArgs e)
        {
            if (txtSoNK.Text.Trim() != "")
            {
                txtHieuLucKy.Text = _cDocSo.getHieuLucKyToi(chkCCDM.Checked, _hoadon.DOT);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtDanhBo_TimKiem.Text.Trim() != "")
                dgvDanhBoTimKiem.DataSource = _cDHN.TimKiem(txtDanhBo_TimKiem.Text.Trim());
            else
                dgvDanhBoTimKiem.DataSource = _cDHN.TimKiem(txtHoTen_TimKiem.Text.Trim(), txtSoNha_TimKiem.Text.Trim(), txtTenDuong_TimKiem.Text.Trim());
        }

        private void dgvDanhBo_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (_dontu != null && e.Row.Cells["ID"].Value == null)
                    {
                        if (CTaiKhoan.Admin == false && _cDonTu.checkPhong(_dontu.MaDon, CTaiKhoan.MaPhong) == false)
                        {
                            MessageBox.Show("Mã Đơn này không thuộc phòng của bạn lập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        _flagdgvDanhBo_inserRow = true;
                        //DonTu_ChiTiet en = new DonTu_ChiTiet();
                        //if (e.Row.Cells["DanhBo"].Value != null)
                        //    en.DanhBo = e.Row.Cells["DanhBo"].Value.ToString();
                        //if (e.Row.Cells["MLT"].Value != null)
                        //    en.MLT = e.Row.Cells["MLT"].Value.ToString();
                        //if (e.Row.Cells["HopDong"].Value != null)
                        //    en.HopDong = e.Row.Cells["HopDong"].Value.ToString();
                        //if (e.Row.Cells["HoTen"].Value != null)
                        //    en.HoTen = e.Row.Cells["HoTen"].Value.ToString();
                        //if (e.Row.Cells["DiaChi"].Value != null)
                        //    en.DiaChi = e.Row.Cells["DiaChi"].Value.ToString();
                        //if (e.Row.Cells["GiaBieu"].Value != null)
                        //    en.GiaBieu = int.Parse(e.Row.Cells["GiaBieu"].Value.ToString());
                        //if (e.Row.Cells["DinhMuc"].Value != null)
                        //    en.DinhMuc = int.Parse(e.Row.Cells["DinhMuc"].Value.ToString());
                        //if (e.Row.Cells["Dot"].Value != null)
                        //    en.Dot = int.Parse(e.Row.Cells["Dot"].Value.ToString());
                        //if (e.Row.Cells["Ky"].Value != null)
                        //    en.Ky = int.Parse(e.Row.Cells["Ky"].Value.ToString());
                        //if (e.Row.Cells["Nam"].Value != null)
                        //    en.Nam = int.Parse(e.Row.Cells["Nam"].Value.ToString());
                        //if (e.Row.Cells["Quan"].Value != null)
                        //    en.Quan = e.Row.Cells["Quan"].Value.ToString();
                        //if (e.Row.Cells["Phuong"].Value != null)
                        //    en.Phuong = e.Row.Cells["Phuong"].Value.ToString();
                        //_cDonTu.Them_ChiTiet(en);
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

        private void dgvDanhBo_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (_dontu != null && dgvDanhBo.Columns.Contains("ID") && e.Row.Cells["ID"].Value != null)
                    {
                        if (CTaiKhoan.Admin == false && _cDonTu.checkPhong(_dontu.MaDon, CTaiKhoan.MaPhong) == false)
                        {
                            MessageBox.Show("Mã Đơn này không thuộc phòng của bạn lập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        _cDonTu.Xoa_ChiTiet(_cDonTu.get_ChiTiet(int.Parse(e.Row.Cells["ID"].Value.ToString())));
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

        private void chkCT_Khac_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCT_Khac.Checked == true)
                txtCT_Khac_GhiChu.ReadOnly = false;
            else
            {
                txtCT_Khac_GhiChu.Text = "";
                txtCT_Khac_GhiChu.ReadOnly = true;
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    tabControl.SelectTab("tabCongVan");
                    DataTable dtExcel = _cDonTu.ExcelToDataTable(dialog.FileName);
                    //CExcel fileExcel = new CExcel(dialog.FileName);
                    //DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");
                    foreach (DataRow item in dtExcel.Rows)
                    {
                        bool exists = false;
                        for (int i = 0; i < dgvDanhBo.Rows.Count; i++)
                            if (dgvDanhBo["DanhBo", i].Value != null && dgvDanhBo["DanhBo", i].Value.ToString() != "" && dgvDanhBo["DanhBo", i].Value.ToString() == item[0].ToString().Replace(" ", ""))
                            {
                                exists = true;
                            }
                        if (exists == false)
                        {
                            HOADON hoadon = _cThuTien.GetMoiNhat(item[0].ToString().Replace(" ", ""));
                            if (hoadon != null)
                            {
                                dgvDanhBo.Rows.Insert(dgvDanhBo.RowCount - 1, 1);
                                dgvDanhBo["DanhBo", dgvDanhBo.RowCount - 2].Value = hoadon.DANHBA;
                                dgvDanhBo["HopDong", dgvDanhBo.RowCount - 2].Value = hoadon.HOPDONG;
                                dgvDanhBo["HoTen", dgvDanhBo.RowCount - 2].Value = hoadon.TENKH;
                                dgvDanhBo["DiaChi", dgvDanhBo.RowCount - 2].Value = hoadon.SO + " " + hoadon.DUONG + _cDHN.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
                                dgvDanhBo["GiaBieu", dgvDanhBo.RowCount - 2].Value = hoadon.GB;
                                dgvDanhBo["DinhMuc", dgvDanhBo.RowCount - 2].Value = hoadon.DM;
                                dgvDanhBo["DinhMucHN", dgvDanhBo.RowCount - 2].Value = hoadon.DinhMucHN;
                                dgvDanhBo["Dot", dgvDanhBo.RowCount - 2].Value = hoadon.DOT;
                                dgvDanhBo["Ky", dgvDanhBo.RowCount - 2].Value = hoadon.KY;
                                dgvDanhBo["Nam", dgvDanhBo.RowCount - 2].Value = hoadon.NAM;
                                dgvDanhBo["MLT", dgvDanhBo.RowCount - 2].Value = hoadon.MALOTRINH;
                                dgvDanhBo["Quan", dgvDanhBo.RowCount - 2].Value = hoadon.Quan;
                                dgvDanhBo["Phuong", dgvDanhBo.RowCount - 2].Value = hoadon.Phuong;
                            }
                            else
                            {
                                dgvDanhBo.Rows.Insert(dgvDanhBo.RowCount - 1, 1);
                                dgvDanhBo["DanhBo", dgvDanhBo.RowCount - 2].Value = item[0].ToString().Replace(" ", "");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbThoiHan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbThoiHan.SelectedIndex >= 0)
            {
                switch (cmbThoiHan.SelectedItem.ToString())
                {
                    case "6 tháng":
                        dateHetHan.Value = DateTime.Now.AddMonths(6);
                        break;
                    case "12 tháng":
                        dateHetHan.Value = DateTime.Now.AddMonths(12);
                        break;
                    default:
                        dateHetHan.Value = DateTime.Now;
                        break;
                }

            }
        }

        private void btnImportQLDHN_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl.SelectTab("tabCongVan");
                DataTable dtExcel = _cDocSo.getPhieuChuyen(txtPhieuChuyen.Text.Trim());
                if (dtExcel.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu, Vui lòng liên hệ Đ. QLĐHN", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                foreach (DataRow item in dtExcel.Rows)
                {
                    bool exists = false;
                    for (int i = 0; i < dgvDanhBo.Rows.Count; i++)
                        if (dgvDanhBo["DanhBo", i].Value != null && dgvDanhBo["DanhBo", i].Value.ToString() != "" && dgvDanhBo["DanhBo", i].Value.ToString() == item[0].ToString().Replace(" ", ""))
                        {
                            exists = true;
                        }
                    if (exists == false)
                    {
                        HOADON hoadon = _cThuTien.GetMoiNhat(item["DanhBo"].ToString().Replace(" ", ""));
                        if (hoadon != null)
                        {
                            dgvDanhBo.Rows.Insert(dgvDanhBo.RowCount - 1, 1);
                            dgvDanhBo["DanhBo", dgvDanhBo.RowCount - 2].Value = hoadon.DANHBA;
                            dgvDanhBo["HopDong", dgvDanhBo.RowCount - 2].Value = hoadon.HOPDONG;
                            dgvDanhBo["HoTen", dgvDanhBo.RowCount - 2].Value = hoadon.TENKH;
                            dgvDanhBo["DiaChi", dgvDanhBo.RowCount - 2].Value = hoadon.SO + " " + hoadon.DUONG + _cDHN.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
                            dgvDanhBo["GiaBieu", dgvDanhBo.RowCount - 2].Value = hoadon.GB;
                            dgvDanhBo["DinhMuc", dgvDanhBo.RowCount - 2].Value = hoadon.DM;
                            dgvDanhBo["DinhMucHN", dgvDanhBo.RowCount - 2].Value = hoadon.DinhMucHN;
                            dgvDanhBo["Dot", dgvDanhBo.RowCount - 2].Value = hoadon.DOT;
                            dgvDanhBo["Ky", dgvDanhBo.RowCount - 2].Value = hoadon.KY;
                            dgvDanhBo["Nam", dgvDanhBo.RowCount - 2].Value = hoadon.NAM;
                            dgvDanhBo["MLT", dgvDanhBo.RowCount - 2].Value = hoadon.MALOTRINH;
                            dgvDanhBo["Quan", dgvDanhBo.RowCount - 2].Value = hoadon.Quan;
                            dgvDanhBo["Phuong", dgvDanhBo.RowCount - 2].Value = hoadon.Phuong;
                            dgvDanhBo["QLDHN_MaDon", dgvDanhBo.RowCount - 2].Value = item["ID"].ToString();
                        }
                        //else
                        //{
                        //    dgvDanhBo.Rows.Insert(dgvDanhBo.RowCount - 1, 1);
                        //    dgvDanhBo["DanhBo", dgvDanhBo.RowCount - 2].Value = item[0].ToString().Replace(" ", "");
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDienThoai_Leave(object sender, EventArgs e)
        {
            txtDienThoaiMoi = txtDienThoai;
        }

        private void btnXemTruocEContract_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    string error;
                    if (_dontu != null)
                        _hoadon = _cThuTien.GetMoiNhat(_dontu.DonTu_ChiTiets.SingleOrDefault().DanhBo);
                    byte[] bytes = _wsEContract.renderEContract(txtHopDong.Text.Trim(), txtDanhBo.Text.Trim().Replace(" ", ""), DateTime.Now, txtHoTenMoi.Text.Trim(), txtCCCD.Text.Trim(), txtNgayCap.Text.Trim(), txtDCThuongTru.Text.Trim(), txtDCHienNay.Text.Trim(), txtDienThoaiMoi.Text.Trim(), txtFax.Text.Trim(), txtEmail.Text.Trim(), txtSTK.Text.Trim(), txtBank.Text.Trim(), txtMST.Text.Trim(), _hoadon.CoDH, txtDCLapDat.Text.Trim(), "", "tanho@2022", out error);
                    if (error == "")
                        _cDonTu.viewPDF(bytes);
                    else
                        MessageBox.Show("Thất bại " + error, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaoEContract_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    if (_dontu != null)
                    {
                        DataTable dtHDDT = _cTTKH.ExecuteQuery_DataTable("select * from Zalo_EContract_ChiTiet where MaDon=" + _dontu.MaDon.ToString() + " order by CreateDate desc");
                        if (dtHDDT != null && dtHDDT.Rows.Count > 1)
                        {
                            if (MessageBox.Show("Mã đơn đã tạo EContract, bạn có muốn tạo thêm không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }
                        }
                        bool CaNhan = true;
                        if (txtMST.Text.Trim() != "")
                            CaNhan = false;
                        if (_dontu != null)
                            _hoadon = _cThuTien.GetMoiNhat(_dontu.DonTu_ChiTiets.SingleOrDefault().DanhBo);
                        string error;
                        bool result = _wsEContract.createEContract(txtHopDong.Text.Trim(), txtDanhBo.Text.Trim().Replace(" ", ""), DateTime.Now, txtHoTenMoi.Text.Trim(), txtCCCD.Text.Trim(), txtNgayCap.Text.Trim(), txtDCThuongTru.Text.Trim(), txtDCHienNay.Text.Trim(), txtDienThoaiMoi.Text.Trim(), txtFax.Text.Trim(), txtEmail.Text.Trim(), txtSTK.Text.Trim(), txtBank.Text.Trim(), txtMST.Text.Trim(), _hoadon.CoDH, txtDCLapDat.Text.Trim(), "", false, CaNhan, _dontu.MaDon.ToString(), "", "tanho@2022", out error);
                        if (result)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Thất bại " + error, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Chưa có mã đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuiEContract_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    if (_dontu != null)
                    {

                        if (_dontu != null)
                            _hoadon = _cThuTien.GetMoiNhat(_dontu.DonTu_ChiTiets.SingleOrDefault().DanhBo);
                        string error;
                        bool result = _wsEContract.sendEContract(_dontu.MaDon.ToString(), "", "tanho@2022", out error);
                        if (result)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Thất bại " + error, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Chưa có mã đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}

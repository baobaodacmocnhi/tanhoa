using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.KhachHang;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.GUI.KhachHang
{
    public partial class frmNhanDonKH : Form
    {
        CLoaiDon _cLoaiDon = new CLoaiDon();
        CDonKH _cDonKH = new CDonKH();
        CTTKH _cTTKH = new CTTKH();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        CNhanVien _cNhanVien = new CNhanVien();
        string SH = "";
        string SX = "";
        string DV = "";
        string HCSN = "";
        string Dot = "";
        string Ky = "";
        string Nam = "";

        public frmNhanDonKH()
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

        public void Clear()
        {
            cmbLD.SelectedIndex = -1;
            txtMaDon.Text = "";
            txtNgayNhan.Text = "";
            txtNoiDung.Text = "";

            chkKiemTraDHN.Checked = false;
            chkTienNuoc.Checked = false;
            chkChiSoNuoc.Checked = false;
            chkDonGiaNuoc.Checked = false;
            chkSangTen.Checked = false;
            chkDangKyDM.Checked = false;
            chkCatChuyenDM.Checked = false;
            chkNuocDuc.Checked = false;
            chkLyDoKhac.Checked = false;

            txtLyDoKhac.Text = "";
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtDienThoai.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtMSThue.Text = "";
            //cmbNVKiemTra.SelectedIndex = 0;

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
        }

        private void frmNhanDonKH_Load(object sender, EventArgs e)
        {
            cmbLD.DataSource = _cLoaiDon.LoadDSLoaiDon(true);
            cmbLD.DisplayMember = "TenLD";
            cmbLD.ValueMember = "MaLD";
            cmbLD.SelectedIndex = -1;

            //cmbNVKiemTra.DataSource = _cNhanVien.LoadDSNhanVien(true);
            //cmbNVKiemTra.DisplayMember = "HoTen";
            //cmbNVKiemTra.ValueMember = "HoTen";

            Clear();
        }

        private void cmbLD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLD.SelectedIndex != -1)
            {
                txtMaDon.Text = _cDonKH.getMaxNextID().ToString().Insert(_cDonKH.getMaxNextID().ToString().Length - 2, "-");
                txtNgayNhan.Text = DateTime.Now.ToString("dd/MM/yyyy");
                ///Thêm Số Loại Đơn đễ lưu trữ
                try
                {
                    ///combobox bị lỗi ở lần đầu tiên nên phải đặc trong try/catch
                    txtMaXepDon.Text = _cDonKH.getMaXepDonNext(int.Parse(cmbLD.SelectedValue.ToString())).ToString().Insert(_cDonKH.getMaXepDonNext(int.Parse(cmbLD.SelectedValue.ToString())).ToString().Length - 2, "-") + "/" + _cLoaiDon.getKyHieuLDubyID(int.Parse(cmbLD.SelectedValue.ToString()));
                }
                catch (Exception)
                {
                    txtMaXepDon.Text = "";
                }
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
            if (e.KeyChar == 13)
            {
                TTKhachHang ttkhachhang = _cTTKH.getTTKHbyID(txtDanhBo.Text.Trim());
                if (ttkhachhang != null)
                {
                    txtHopDong.Text = ttkhachhang.GiaoUoc;
                    txtHoTen.Text = ttkhachhang.HoTen;
                    txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
                    txtMSThue.Text = ttkhachhang.MSThue;
                    txtGiaBieu.Text = ttkhachhang.GB;
                    txtDinhMuc.Text = ttkhachhang.TGDM;
                    SH = ttkhachhang.SH;
                    SX = ttkhachhang.SX;
                    DV = ttkhachhang.DV;
                    HCSN = ttkhachhang.HCSN;
                    Dot = ttkhachhang.Dot;
                    Ky = ttkhachhang.Ky;
                    Nam = ttkhachhang.Nam;
                }
                else
                {
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDanhBo.Text = "";
                    txtHopDong.Text = "";
                    txtDienThoai.Text = "";
                    txtHoTen.Text = "";
                    txtDiaChi.Text = "";
                    txtGiaBieu.Text = "";
                    txtDinhMuc.Text = "";
                    txtMSThue.Text = "";
                }
            }
        }

        private void btnInBienNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbLD.SelectedIndex != -1)
                {
                    DonKH donkh = new DonKH();
                    donkh.MaDon = _cDonKH.getMaxNextID();
                    donkh.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                    donkh.SoCongVan = txtSoCongVan.Text.Trim();
                    donkh.NoiDung = txtNoiDung.Text.Trim();
                    donkh.MaXepDon = decimal.Parse(txtMaXepDon.Text.Trim().Substring(0, txtMaXepDon.Text.Trim().IndexOf("/")).Replace("-", ""));

                    donkh.DanhBo = txtDanhBo.Text.Trim();
                    donkh.HopDong = txtHopDong.Text.Trim();
                    donkh.HoTen = txtHoTen.Text.Trim();
                    donkh.DiaChi = txtDiaChi.Text.Trim();
                    donkh.DienThoai = txtDienThoai.Text.Trim();
                    donkh.MSThue = txtMSThue.Text.Trim();
                    donkh.GiaBieu = txtGiaBieu.Text.Trim();
                    donkh.DinhMuc = txtDinhMuc.Text.Trim();
                    donkh.SH = SH;
                    donkh.SX = SX;
                    donkh.DV = DV;
                    donkh.HCSN = HCSN;
                    donkh.Dot = Dot;
                    donkh.Ky = Ky;
                    donkh.Nam = Nam;

                    //donkh.GhiChuNguoiDi = cmbNVKiemTra.SelectedValue.ToString();
                    donkh.DinhMucSau = txtDinhMucSau.Text.Trim();
                    donkh.HieuLucTuKy = txtHieuLucTuKy.Text.Trim();

                    #region CheckBox
                    if (chkKiemTraDHN.Checked)
                        donkh.KiemTraDHN = true;

                    if (chkTienNuoc.Checked)
                        donkh.TienNuoc = true;

                    if (chkChiSoNuoc.Checked)
                        donkh.ChiSoNuoc = true;

                    if (chkDonGiaNuoc.Checked)
                        donkh.DonGiaNuoc = true;

                    if (chkSangTen.Checked)
                        donkh.SangTen = true;

                    if (chkDangKyDM.Checked)
                        donkh.DangKyDM = true;

                    if (chkCatChuyenDM.Checked)
                        donkh.CatChuyenDM = true;

                    if (chkNuocDuc.Checked)
                        donkh.NuocDuc = true;

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

                    if (_cDonKH.ThemDonKH(donkh))
                    {
                        MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                        DataRow dr = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                        dr["MaDon"] = txtMaDon.Text.Trim() + "/" + _cLoaiDon.getKyHieuLDubyID(int.Parse(cmbLD.SelectedValue.ToString())); ;
                        //dr["MaXepDon"] = _cLoaiDon.getKyHieuLDubyID(int.Parse(cmbLD.SelectedValue.ToString()));
                        dr["TenLD"] = cmbLD.Text;
                        dr["KhachHang"] = txtHoTen.Text.Trim();
                        if (txtDanhBo.Text.Trim() != "")
                            dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, ".").Insert(4, ".");
                        dr["DiaChi"] = txtDiaChi.Text.Trim();
                        dr["HopDong"] = txtHopDong.Text.Trim();
                        dr["DienThoai"] = txtDienThoai.Text.Trim();

                        #region CheckBox
                        if (donkh.KiemTraDHN)
                        {
                            dr["KiemTraDHN"] = true;
                        }
                        else
                        {
                            dr["KiemTraDHN"] = false;
                        }

                        if (donkh.TienNuoc)
                        {
                            dr["TienNuoc"] = true;
                        }
                        else
                        {
                            dr["TienNuoc"] = false;
                        }

                        if (donkh.ChiSoNuoc)
                        {
                            dr["ChiSoNuoc"] = true;
                        }
                        else
                        {
                            dr["ChiSoNuoc"] = false;
                        }

                        if (donkh.DonGiaNuoc)
                        {
                            dr["DonGiaNuoc"] = true;
                        }
                        else
                        {
                            dr["DonGiaNuoc"] = false;
                        }

                        if (donkh.SangTen)
                        {
                            dr["SangTen"] = true;
                        }
                        else
                        {
                            dr["SangTen"] = false;
                        }

                        if (donkh.DangKyDM)
                        {
                            dr["DangKyDM"] = true;
                        }
                        else
                        {
                            dr["DangKyDM"] = false;
                        }

                        if (donkh.CatChuyenDM)
                        {
                            dr["CatChuyenDM"] = true;
                        }
                        else
                        {
                            dr["CatChuyenDM"] = false;
                        }

                        if (donkh.NuocDuc)
                        {
                            dr["NuocDuc"] = true;
                        }
                        else
                        {
                            dr["NuocDuc"] = false;
                        }

                        if (donkh.LoaiKhac)
                        {
                            dr["LoaiKhac"] = true;
                            dr["LyDoLoaiKhac"] = donkh.LyDoLoaiKhac;
                        }
                        else
                        {
                            dr["LoaiKhac"] = false;
                        }

                        if (donkh.CT_HoaDon)
                        {
                            dr["CT_HoaDon"] = true;
                        }
                        else
                        {
                            dr["CT_HoaDon"] = false;
                        }

                        if (donkh.CT_HK_KT3)
                        {
                            dr["CT_HK_KT3"] = true;
                        }
                        else
                        {
                            dr["CT_HK_KT3"] = false;
                        }

                        if (donkh.CT_STT_GXNTT)
                        {
                            dr["CT_STT_GXNTT"] = true;
                        }
                        else
                        {
                            dr["CT_STT_GXNTT"] = false;
                        }

                        if (donkh.CT_HDTN_CQN)
                        {
                            dr["CT_HDTN_CQN"] = true;
                        }
                        else
                        {
                            dr["CT_HDTN_CQN"] = false;
                        }

                        if (donkh.CT_GC_SDSN)
                        {
                            dr["CT_GC_SDSN"] = true;
                        }
                        else
                        {
                            dr["CT_GC_SDSN"] = false;
                        }

                        if (donkh.CT_GXN2SN)
                        {
                            dr["CT_GXN2SN"] = true;
                        }
                        else
                        {
                            dr["CT_GXN2SN"] = false;
                        }

                        if (donkh.CT_GDKKD)
                        {
                            dr["CT_GDKKD"] = true;
                        }
                        else
                        {
                            dr["CT_GDKKD"] = false;
                        }

                        if (donkh.CT_GCNDTDHN)
                        {
                            dr["CT_GCNDTDHN"] = true;
                        }
                        else
                        {
                            dr["CT_GCNDTDHN"] = false;
                        }
                        #endregion

                        dr["DinhMucSau"] = txtDinhMucSau.Text.Trim();
                        dr["HieuLucTuKy"] = txtHieuLucTuKy.Text.Trim();
                        dr["HoTenNV"] = CTaiKhoan.HoTen;
                        dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(dr);
                        rptBienNhanDonKH rpt = new rptBienNhanDonKH();
                        rpt.SetDataSource(dsBaoCao);
                        frmBaoCao frm = new frmBaoCao(rpt);
                        frm.ShowDialog();

                        Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.GUI.KhachHang;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.BaoCao;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
using KTKS_DonKH.GUI.ToXuLy;
using System.Threading;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.GUI.BaoCao;
using System.Globalization;
using System.Transactions;
using KTKS_DonKH.DAL;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDSDCBD : Form
    {
        CDonKH _cDonKH = new CDonKH();
        CDCBD _cDCBD = new CDCBD();
        CKTXM _cKTXM = new CKTXM();
        CChiNhanh _cChiNhanh = new CChiNhanh();
        CChungTu _cChungTu = new CChungTu();
        CCatChuyenDM _cCatChuyenDM = new CCatChuyenDM();
        List<GiaNuoc> _lstGiaNuoc;
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();

        public frmDSDCBD()
        {
            InitializeComponent();

        }

        private void frmDSDCBD_Load(object sender, EventArgs e)
        {
            _lstGiaNuoc = _cGiaNuoc.LoadDSGiaNuoc();

            dgvDSDCBD.AutoGenerateColumns = false;
            dgvDSCatChuyenDM.AutoGenerateColumns = false;

            radDSDCBD.Checked = true;
            cmbTimTheo.SelectedItem = "Ngày";
        }

        private void radDSDCDB_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSDCBD.Checked)
            {
                dgvDSDCBD.Columns["ChuyenDocSo"].Visible = true;
                dgvDSDCBD.Columns["HoTen"].Visible = true;
                dgvDSDCBD.Columns["HoTen_BD"].Visible = true;
                dgvDSDCBD.Columns["DiaChi"].Visible = true;
                dgvDSDCBD.Columns["DiaChi_BD"].Visible = true;
                dgvDSDCBD.Columns["MSThue"].Visible = true;
                dgvDSDCBD.Columns["MSThue_BD"].Visible = true;
                dgvDSDCBD.Columns["GiaBieu"].Visible = true;
                dgvDSDCBD.Columns["GiaBieu_BD"].Visible = true;
                dgvDSDCBD.Columns["DinhMuc"].Visible = true;
                dgvDSDCBD.Columns["DinhMuc_BD"].Visible = true;
                ///
                dgvDSDCBD.Columns["CodeF2"].Visible = false;
                dgvDSDCBD.Columns["TieuThu"].Visible = false;
                dgvDSDCBD.Columns["TieuThu_BD"].Visible = false;
                dgvDSDCBD.Columns["TongCong_Start"].Visible = false;
                dgvDSDCBD.Columns["TongCong_End"].Visible = false;
                dgvDSDCBD.Columns["TongCong_BD"].Visible = false;
                dgvDSDCBD.Columns["TangGiam"].Visible = false;

                dgvDSDCBD.Visible = true;
                dgvDSCatChuyenDM.Visible = false;
            }
        }

        private void radDSDCHD_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSDCHD.Checked)
            {
                dgvDSDCBD.Columns["ChuyenDocSo"].Visible = false;
                dgvDSDCBD.Columns["HoTen"].Visible = false;
                dgvDSDCBD.Columns["HoTen_BD"].Visible = false;
                dgvDSDCBD.Columns["DiaChi"].Visible = false;
                dgvDSDCBD.Columns["DiaChi_BD"].Visible = false;
                dgvDSDCBD.Columns["MSThue"].Visible = false;
                dgvDSDCBD.Columns["MSThue_BD"].Visible = false;
                ///
                dgvDSDCBD.Columns["CodeF2"].Visible = true;
                dgvDSDCBD.Columns["GiaBieu"].Visible = true;
                dgvDSDCBD.Columns["GiaBieu_BD"].Visible = true;
                dgvDSDCBD.Columns["DinhMuc"].Visible = true;
                dgvDSDCBD.Columns["DinhMuc_BD"].Visible = true;
                dgvDSDCBD.Columns["TieuThu"].Visible = true;
                dgvDSDCBD.Columns["TieuThu_BD"].Visible = true;
                dgvDSDCBD.Columns["TongCong_Start"].Visible = true;
                dgvDSDCBD.Columns["TongCong_End"].Visible = true;
                dgvDSDCBD.Columns["TongCong_BD"].Visible = true;
                dgvDSDCBD.Columns["TangGiam"].Visible = true;

                dgvDSDCBD.Visible = true;
                dgvDSCatChuyenDM.Visible = false;
            }
        }

        private void radDSCatChuyenDM_CheckedChanged(object sender, EventArgs e)
        {
            //DSDCBD_BS = new BindingSource();
            //DSDCBD_BS.DataSource = _cChungTu.LoadDSCatChuyenDM();
            //dgvDSCatChuyenDM.DataSource = DSDCBD_BS;

            dgvDSCatChuyenDM.Visible = true;
            dgvDSDCBD.Visible = false;
            chkSelectAll.Visible = true;
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Số Phiếu":
                    txtNoiDungTimKiem.Visible = true;
                    txtNoiDungTimKiem2.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Danh Bộ":
                    txtNoiDungTimKiem.Visible = true;
                    txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
            }
            dgvDSDCBD.DataSource = null;
            dgvDSCatChuyenDM.DataSource = null;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                        if (chkTheoUser.Checked)
                        {
                            if (radDSDCBD.Checked)
                                dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCBDByMaDons(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                            else
                            if (radDSDCHD.Checked)
                                dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCHDByMaDons(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                            else
                                if (radDSCatChuyenDM.Checked)
                                    dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDMByMaDons(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                        }
                        else
                        {
                            if (radDSDCBD.Checked)
                                dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCBDByMaDons(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                            else
                            if (radDSDCHD.Checked)
                                dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCHDByMaDons(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                            else
                                if (radDSCatChuyenDM.Checked)
                                    dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDMByMaDons(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                        }
                    else
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            if (chkTheoUser.Checked)
                            {
                                if (radDSDCBD.Checked)
                                    dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCBDByMaDon(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                                else
                                    if (radDSDCHD.Checked)
                                        dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCHDByMaDon(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                                    else
                                        if (radDSCatChuyenDM.Checked)
                                            dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDMByMaDon(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                            }
                            else
                            {
                                if (radDSDCBD.Checked)
                                    dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCBDByMaDon(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                                else
                                    if (radDSDCHD.Checked)
                                        dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCHDByMaDon(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                                    else
                                        if (radDSCatChuyenDM.Checked)
                                            dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDMByMaDon(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                            }
                    break;
                case "Số Phiếu":
                    if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                        if (chkTheoUser.Checked)
                        {
                            if (radDSDCBD.Checked)
                                dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCBDBySoPhieus(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                            else
                                if (radDSDCHD.Checked)
                                    dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCHDBySoPhieus(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                                else
                                    if (radDSCatChuyenDM.Checked)
                                        dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDMBySoPhieus(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                        }
                        else
                        {
                            if (radDSDCBD.Checked)
                                dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCBDBySoPhieus(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                            else
                                if (radDSDCHD.Checked)
                                    dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCHDBySoPhieus(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                                else
                                    if (radDSCatChuyenDM.Checked)
                                        dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDMBySoPhieus(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                        }
                    else
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            if (chkTheoUser.Checked)
                            {
                                if (radDSDCBD.Checked)
                                    dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCBDBySoPhieu(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                                else
                                    if (radDSDCHD.Checked)
                                        dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCHDBySoPhieu(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                                    else
                                        if (radDSCatChuyenDM.Checked)
                                            dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDMBySoPhieu(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                            }
                            else
                            {
                                if (radDSDCBD.Checked)
                                    dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCBDBySoPhieu(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                                else
                                    if (radDSDCHD.Checked)
                                        dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCHDBySoPhieu(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                                    else
                                        if (radDSCatChuyenDM.Checked)
                                            dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDMBySoPhieu(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                            }
                    break;
                case "Danh Bộ":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        if (chkTheoUser.Checked)
                        {
                            if (radDSDCBD.Checked)
                                dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCBDByDanhBo(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                            else
                                if (radDSDCHD.Checked)
                                    dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCHDByDanhBo(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                                else
                                    if (radDSCatChuyenDM.Checked)
                                        dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDMByDanhBo(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                        }
                        else
                        {
                            if (radDSDCBD.Checked)
                                dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCBDByDanhBo(txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                            else
                                if (radDSDCHD.Checked)
                                    dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCHDByDanhBo(txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                                else
                                    if (radDSCatChuyenDM.Checked)
                                        dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDMByDanhBo(txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                        }
                    break;
                case "Ngày":
                    if (chkTheoUser.Checked)
                    {
                        if (radDSDCBD.Checked)
                            dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCBDByDates(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                        else
                            if (radDSDCHD.Checked)
                                dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCHDByDates(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                            else
                                if (radDSCatChuyenDM.Checked)
                                    dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDMByDates(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                    }
                    else
                    {
                        if (radDSDCBD.Checked)
                            dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCBDByDates(dateTu.Value, dateDen.Value);
                        else
                            if (radDSDCHD.Checked)
                                dgvDSDCBD.DataSource = _cDCBD.LoadDSCTDCHDByDates(dateTu.Value, dateDen.Value);
                            else
                                if (radDSCatChuyenDM.Checked)
                                    dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDMByDates(dateTu.Value, dateDen.Value);
                    }
                    break;
                default:
                    break;
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                if (radDSDCBD.Checked || radDSDCHD.Checked)
                    for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                    {
                        dgvDSDCBD["In", i].Value = true;
                    }
                else
                    if (radDSCatChuyenDM.Checked)
                        for (int i = 0; i < dgvDSCatChuyenDM.Rows.Count; i++)
                        {
                            dgvDSCatChuyenDM["In_CC", i].Value = true;
                        }
            }
            else
                if (radDSDCBD.Checked || radDSDCHD.Checked)
                    for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                    {
                        dgvDSDCBD["In", i].Value = false;
                    }
                else
                    if (radDSCatChuyenDM.Checked)
                        for (int i = 0; i < dgvDSCatChuyenDM.Rows.Count; i++)
                        {
                            dgvDSCatChuyenDM["In_CC", i].Value = false;
                        }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn In những Phiếu trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    if (radDSDCBD.Checked)
                    {
                        for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                            if (dgvDSDCBD["In", i].Value != null && bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true)
                            {
                                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                DataRow dr = dsBaoCao.Tables["DCBD"].NewRow();

                                CTDCBD ctdcbd = _cDCBD.getCTDCBDbyID(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));
                                if (ctdcbd.DCBD.ToXuLy)
                                    dr["MaDon"] = "TXL" + ctdcbd.DCBD.MaDonTXL.ToString().Insert(ctdcbd.DCBD.MaDonTXL.ToString().Length - 2, "-");
                                else
                                    dr["MaDon"] = ctdcbd.DCBD.MaDon.ToString().Insert(ctdcbd.DCBD.MaDon.ToString().Length - 2, "-");
                                dr["SoPhieu"] = ctdcbd.MaCTDCBD.ToString().Insert(ctdcbd.MaCTDCBD.ToString().Length - 2, "-");
                                dr["ThongTin"] = ctdcbd.ThongTin;
                                dr["HieuLucKy"] = ctdcbd.HieuLucKy;
                                dr["Dot"] = ctdcbd.Dot;
                                ///Hiện tại xử lý mã số thuế như vậy
                                if (ctdcbd.CatMSThue)
                                    dr["MSThue"] = "MST: Cắt MST";
                                if (!string.IsNullOrEmpty(ctdcbd.MSThue_BD))
                                    dr["MSThue"] = "MST: " + ctdcbd.MSThue_BD;
                                dr["DanhBo"] = ctdcbd.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["HopDong"] = ctdcbd.HopDong;
                                dr["HoTen"] = ctdcbd.HoTen;
                                dr["DiaChi"] = ctdcbd.DiaChi;
                                dr["MaQuanPhuong"] = ctdcbd.MaQuanPhuong;
                                dr["GiaBieu"] = ctdcbd.GiaBieu;
                                dr["DinhMuc"] = ctdcbd.DinhMuc;
                                ///Biến Động
                                dr["HoTenBD"] = ctdcbd.HoTen_BD;
                                dr["DiaChiBD"] = ctdcbd.DiaChi_BD;
                                dr["GiaBieuBD"] = ctdcbd.GiaBieu_BD;
                                dr["DinhMucBD"] = ctdcbd.DinhMuc_BD;
                                if (!string.IsNullOrEmpty(ctdcbd.SH_BD))
                                    dr["TyLe"] = "Tỷ Lệ SH: " + ctdcbd.SH_BD + "%";

                                if (!string.IsNullOrEmpty(ctdcbd.SX_BD))
                                    if (string.IsNullOrEmpty(dr["TyLe"].ToString()))
                                        dr["TyLe"] = "Tỷ Lệ SX: " + ctdcbd.SX_BD + "%";
                                    else
                                        dr["TyLe"] += ", SX: " + ctdcbd.SX_BD + "%";

                                if (!string.IsNullOrEmpty(ctdcbd.DV_BD))
                                    if (string.IsNullOrEmpty(dr["TyLe"].ToString()))
                                        dr["TyLe"] = "Tỷ Lệ DV: " + ctdcbd.DV_BD + "%";
                                    else
                                        dr["TyLe"] += ", DV: " + ctdcbd.DV_BD + "%";

                                if (!string.IsNullOrEmpty(ctdcbd.HCSN_BD))
                                    if (string.IsNullOrEmpty(dr["TyLe"].ToString()))
                                        dr["TyLe"] = "Tỷ Lệ HCSN: " + ctdcbd.HCSN_BD + "%";
                                    else
                                        dr["TyLe"] += ", HCSN: " + ctdcbd.HCSN_BD + "%";
                                ///Ký Tên
                                if (ctdcbd.DMGiuNguyen)
                                    dr["KhongBD"] = "ĐM Giữ Nguyên";
                                else
                                    if (ctdcbd.GiaHan)
                                        dr["KhongBD"] = "Gia Hạn";
                                    else
                                    {
                                        dr["ChucVu"] = ctdcbd.ChucVu;
                                        dr["NguoiKy"] = ctdcbd.NguoiKy;
                                    }

                                dsBaoCao.Tables["DCBD"].Rows.Add(dr);

                                rptPhieuDCBD rpt = new rptPhieuDCBD();
                                rpt.SetDataSource(dsBaoCao);

                                printDialog.AllowSomePages = true;
                                printDialog.ShowHelp = true;

                                rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                rpt.PrintToPrinter(1, false, 1, 1);
                                rpt.Clone();
                                rpt.Dispose();
                            }
                    }
                    else
                        if (radDSDCHD.Checked)
                        {
                            for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                                if (dgvDSDCBD["In", i].Value!=null&&bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true)
                                {
                                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                    DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();

                                    CTDCHD ctdchd = _cDCBD.getCTDCHDbyID(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));
                                    dr["SoPhieu"] = ctdchd.MaCTDCHD.ToString().Insert(ctdchd.MaCTDCHD.ToString().Length - 2, "-");
                                    dr["DanhBo"] = ctdchd.DanhBo.Insert(7, " ").Insert(4, " "); ;
                                    dr["HoTen"] = ctdchd.HoTen;
                                    if (ctdchd.DCBD.ToXuLy)
                                        dr["SoDon"] = "TXL" + ctdchd.DCBD.MaDonTXL.Value.ToString().Insert(ctdchd.DCBD.MaDonTXL.Value.ToString().Length - 2, "-");
                                    else
                                        dr["SoDon"] = ctdchd.DCBD.MaDon.Value.ToString().Insert(ctdchd.DCBD.MaDon.Value.ToString().Length - 2, "-");
                                    dr["NgayKy"] = ctdchd.NgayKy.Value.ToString("dd/MM/yyyy");
                                    dr["KyHD"] = ctdchd.KyHD;
                                    dr["SoHD"] = ctdchd.SoHD;
                                    ///
                                    dr["TieuThuStart"] = ctdchd.TieuThu;
                                    if (ctdchd.TienNuoc_Start == 0)
                                        dr["TienNuocStart"] = "0";
                                    else
                                        dr["TienNuocStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TienNuoc_Start);
                                    if (ctdchd.ThueGTGT_Start == 0)
                                        dr["ThueGTGTStart"] = 0;
                                    else
                                        dr["ThueGTGTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.ThueGTGT_Start);
                                    if (ctdchd.PhiBVMT_Start == 0)
                                        dr["PhiBVMTStart"] = 0;
                                    else
                                        dr["PhiBVMTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_Start);
                                    if (ctdchd.TongCong_Start == 0)
                                        dr["TongCongStart"] = 0;
                                    else
                                        dr["TongCongStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_Start);
                                    ///
                                    dr["TangGiam"] = ctdchd.TangGiam;
                                    ///
                                    dr["TieuThuBD"] = ctdchd.TieuThu_BD - ctdchd.TieuThu;
                                    if (ctdchd.TienNuoc_BD == 0)
                                        dr["TienNuocBD"] = 0;
                                    else
                                        dr["TienNuocBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TienNuoc_BD);
                                    if (ctdchd.ThueGTGT_BD == 0)
                                        dr["ThueGTGTBD"] = 0;
                                    else
                                        dr["ThueGTGTBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.ThueGTGT_BD);
                                    if (ctdchd.PhiBVMT_BD == 0)
                                        dr["PhiBVMTBD"] = 0;
                                    else
                                        dr["PhiBVMTBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_BD);
                                    if (ctdchd.TongCong_BD == 0)
                                        dr["TongCongBD"] = 0;
                                    else
                                        dr["TongCongBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_BD);
                                    ///
                                    dr["TieuThuEnd"] = ctdchd.TieuThu_BD;
                                    if (ctdchd.TienNuoc_End == 0)
                                        dr["TienNuocEnd"] = 0;
                                    else
                                        dr["TienNuocEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TienNuoc_End);
                                    if (ctdchd.ThueGTGT_End == 0)
                                        dr["ThueGTGTEnd"] = 0;
                                    else
                                        dr["ThueGTGTEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.ThueGTGT_End);
                                    if (ctdchd.PhiBVMT_End == 0)
                                        dr["PhiBVMTEnd"] = 0;
                                    else
                                        dr["PhiBVMTEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_End);
                                    if (ctdchd.TongCong_End == 0)
                                        dr["TongCongEnd"] = 0;
                                    else
                                        dr["TongCongEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_End);

                                    dr["ChucVu"] = ctdchd.ChucVu;
                                    dr["NguoiKy"] = ctdchd.NguoiKy;

                                    dsBaoCao.Tables["DCHD"].Rows.Add(dr);

                                    rptPhieuDCHD rpt = new rptPhieuDCHD();
                                    rpt.SetDataSource(dsBaoCao);

                                    printDialog.AllowSomePages = true;
                                    printDialog.ShowHelp = true;

                                    rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                    rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                    rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                    rpt.PrintToPrinter(1, false, 1, 1);
                                    rpt.Clone();
                                    rpt.Dispose();
                                }
                        }
                        else
                            if (radDSCatChuyenDM.Checked)
                            {
                                for (int i = 0; i < dgvDSCatChuyenDM.Rows.Count; i++)
                                    if (dgvDSCatChuyenDM["In_CC", i].Value != null && bool.Parse(dgvDSCatChuyenDM["In_CC", i].Value.ToString()) == true)
                                    {
                                        LichSuChungTu lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(decimal.Parse(dgvDSCatChuyenDM["SoPhieu_CC", i].Value.ToString()));

                                        if (lichsuchungtu.YeuCauCat)
                                        {
                                            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                            DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                            if (!string.IsNullOrEmpty(lichsuchungtu.MaDon.ToString()) || !string.IsNullOrEmpty(lichsuchungtu.MaDonTXL.ToString()))
                                                if (lichsuchungtu.ToXuLy)
                                                    dr["MaDon"] = "TXL" + lichsuchungtu.MaDonTXL.ToString().Insert(lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                                else
                                                    dr["MaDon"] = lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");

                                            dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                                            dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(lichsuchungtu.CatNK_MaCN.Value);
                                            if (!string.IsNullOrEmpty(lichsuchungtu.NhanNK_DanhBo))
                                                dr["DanhBoNhan"] = lichsuchungtu.NhanNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                            dr["HoTenNhan"] = lichsuchungtu.NhanNK_HoTen;
                                            dr["DiaChiNhan"] = lichsuchungtu.NhanNK_DiaChi;
                                            if (!string.IsNullOrEmpty(lichsuchungtu.CatNK_DanhBo))
                                                dr["DanhBoCat"] = lichsuchungtu.CatNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                            dr["HoTenCat"] = lichsuchungtu.CatNK_HoTen;
                                            dr["DiaChiCat"] = lichsuchungtu.CatNK_DiaChi;
                                            ///có thể sai MaCT, nếu sai đổi lại lấy txtMaCT
                                            dr["SoNKCat"] = lichsuchungtu.SoNK.ToString() + " nhân khẩu (HK: " + lichsuchungtu.MaCT + ")";

                                            dr["ChucVu"] = lichsuchungtu.ChucVu;
                                            dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                            dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                                            rptPhieuYCCatDMx2 rpt = new rptPhieuYCCatDMx2();
                                            for (int j = 0; j < rpt.Subreports.Count; j++)
                                            {
                                                rpt.Subreports[j].SetDataSource(dsBaoCao);
                                            }

                                            printDialog.AllowSomePages = true;
                                            printDialog.ShowHelp = true;

                                            rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                            rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                                            rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                            rpt.PrintToPrinter(1, false, 1, 1);
                                        }
                                        else
                                            if (lichsuchungtu.CatDM)
                                            {
                                                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                                DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                                if (!string.IsNullOrEmpty(lichsuchungtu.MaDon.ToString()) || !string.IsNullOrEmpty(lichsuchungtu.MaDonTXL.ToString()))
                                                    if (lichsuchungtu.ToXuLy)
                                                        dr["MaDon"] = "TXL" + lichsuchungtu.MaDonTXL.ToString().Insert(lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                                    else
                                                        dr["MaDon"] = lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");

                                                dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                                                dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(lichsuchungtu.NhanNK_MaCN.Value);
                                                if (!string.IsNullOrEmpty(lichsuchungtu.NhanNK_DanhBo))
                                                    dr["DanhBoNhan"] = lichsuchungtu.NhanNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                                dr["HoTenNhan"] = lichsuchungtu.NhanNK_HoTen;
                                                dr["DiaChiNhan"] = lichsuchungtu.NhanNK_DiaChi;
                                                if (!string.IsNullOrEmpty(lichsuchungtu.CatNK_DanhBo))
                                                    dr["DanhBoCat"] = lichsuchungtu.CatNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                                dr["HoTenCat"] = lichsuchungtu.CatNK_HoTen;
                                                dr["DiaChiCat"] = lichsuchungtu.CatNK_DiaChi;
                                                dr["SoNKCat"] = lichsuchungtu.SoNK + " nhân khẩu (HK: " + lichsuchungtu.MaCT + ")";

                                                dr["ChucVu"] = lichsuchungtu.ChucVu;
                                                dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                                dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                                                rptPhieuYCNhanDMx2 rpt = new rptPhieuYCNhanDMx2();
                                                for (int j = 0; j < rpt.Subreports.Count; j++)
                                                {
                                                    rpt.Subreports[j].SetDataSource(dsBaoCao);
                                                }

                                                printDialog.AllowSomePages = true;
                                                printDialog.ShowHelp = true;

                                                rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                                                rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                                rpt.PrintToPrinter(1, false, 1, 1);
                                            }
                                            else
                                                if (lichsuchungtu.NhanDM)
                                                {
                                                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                                    DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                                    if (!string.IsNullOrEmpty(lichsuchungtu.MaDon.ToString()) || !string.IsNullOrEmpty(lichsuchungtu.MaDonTXL.ToString()))
                                                        if (lichsuchungtu.ToXuLy)
                                                            dr["MaDon"] = "TXL" + lichsuchungtu.MaDonTXL.ToString().Insert(lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                                        else
                                                            dr["MaDon"] = lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");

                                                    dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                                                    dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(lichsuchungtu.CatNK_MaCN.Value);
                                                    if (!string.IsNullOrEmpty(lichsuchungtu.NhanNK_DanhBo))
                                                        dr["DanhBoNhan"] = lichsuchungtu.NhanNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                                    dr["HoTenNhan"] = lichsuchungtu.NhanNK_HoTen;
                                                    dr["DiaChiNhan"] = lichsuchungtu.NhanNK_DiaChi;
                                                    if (!string.IsNullOrEmpty(lichsuchungtu.CatNK_DanhBo))
                                                        dr["DanhBoCat"] = lichsuchungtu.CatNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                                    dr["HoTenCat"] = lichsuchungtu.CatNK_HoTen;
                                                    dr["DiaChiCat"] = lichsuchungtu.CatNK_DiaChi;
                                                    ///có thể sai MaCT, nếu sai đổi lại lấy txtMaCT
                                                    dr["SoNKCat"] = lichsuchungtu.SoNK.ToString() + " nhân khẩu (HK: " + lichsuchungtu.MaCT + ")";

                                                    dr["ChucVu"] = lichsuchungtu.ChucVu;
                                                    dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                                    dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                                                    rptPhieuYCCatDMx2 rpt = new rptPhieuYCCatDMx2();
                                                    for (int j = 0; j < rpt.Subreports.Count; j++)
                                                    {
                                                        rpt.Subreports[j].SetDataSource(dsBaoCao);
                                                    }

                                                    printDialog.AllowSomePages = true;
                                                    printDialog.ShowHelp = true;

                                                    rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                                    rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                                                    rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                                    rpt.PrintToPrinter(1, false, 1, 1);
                                                }
                                    }
                            }
                }
            }
        }

        private void btnCapNhatDocSo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn Cập Nhật Đọc Số những Phiếu trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (radDSDCBD.Checked)
                {
                    CDocSo _cDocSo = new CDocSo();
                    int k = 0;
                    System.IO.StreamWriter log = System.IO.File.AppendText("\\\\192.168.90.9\\cntt\\BaoBao\\KTKS_DonKH\\log.txt");
                    //try
                    //{
                    log.WriteLine("Danh Sách chuyển Đọc số ngày " + DateTime.Now);
                    for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                        if (bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true && bool.Parse(dgvDSDCBD["PhieuDuocKy", i].Value.ToString()) == true && bool.Parse(dgvDSDCBD["ChuyenDocSo", i].Value.ToString()) == false)
                        {
                            CTDCBD ctdcbd = new CTDCBD();
                            ctdcbd = _cDCBD.getCTDCBDbyID(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));

                            if (ctdcbd != null)
                            {
                                if (_cDocSo.CheckExist(ctdcbd.DanhBo) && !string.IsNullOrEmpty(ctdcbd.ThongTin))
                                {
                                    if (!string.IsNullOrEmpty(ctdcbd.DinhMuc_BD.ToString()))
                                    {
                                        _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set DINHMUC=" + ctdcbd.DinhMuc_BD.Value.ToString() + " where DANHBO='" + ctdcbd.DanhBo + "'");
                                    }
                                    if (!string.IsNullOrEmpty(ctdcbd.GiaBieu_BD.ToString()))
                                    {
                                        _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set GIABIEU=" + ctdcbd.GiaBieu_BD.Value.ToString() + " where DANHBO='" + ctdcbd.DanhBo + "'");
                                    }
                                    if (!string.IsNullOrEmpty(ctdcbd.HoTen_BD))
                                    {
                                        _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set HOTEN=N'" + ctdcbd.HoTen_BD.ToString().Replace("'", "") + "' where DANHBO='" + ctdcbd.DanhBo + "'");
                                    }
                                    if (!string.IsNullOrEmpty(ctdcbd.MSThue_BD))
                                    {
                                        _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set MSTHUE=" + ctdcbd.MSThue_BD.ToString() + " where DANHBO='" + ctdcbd.DanhBo + "'");
                                    }

                                    TB_GHICHU ghichu = new TB_GHICHU();
                                    ghichu.DANHBO = ctdcbd.DanhBo;
                                    ghichu.DONVI = "KTKS";
                                    ghichu.NOIDUNG = "PYC: " + ctdcbd.MaCTDCBD.ToString().Insert(ctdcbd.MaCTDCBD.ToString().Length - 2, "-");
                                    ghichu.NOIDUNG += " ," + ctdcbd.CreateDate.Value.ToString("dd/MM/yyyy");
                                    ghichu.NOIDUNG += " - HL : " + ctdcbd.HieuLucKy + " - ĐC";
                                    if (!string.IsNullOrEmpty(ctdcbd.HoTen_BD))
                                    {
                                        ghichu.NOIDUNG += " Tên: " + ctdcbd.HoTen_BD + ",";
                                    }
                                    if (!string.IsNullOrEmpty(ctdcbd.DiaChi_BD))
                                    {
                                        ghichu.NOIDUNG += " Địa Chỉ: " + ctdcbd.DiaChi_BD + ",";
                                    }
                                    if (!string.IsNullOrEmpty(ctdcbd.MSThue_BD))
                                    {
                                        ghichu.NOIDUNG += " MST: " + ctdcbd.MSThue_BD + ",";
                                    }
                                    if (!string.IsNullOrEmpty(ctdcbd.GiaBieu_BD.ToString()))
                                    {
                                        ghichu.NOIDUNG += " Giá Biểu Từ " + ctdcbd.GiaBieu + " -> " + ctdcbd.GiaBieu_BD + ",";
                                    }
                                    if (!string.IsNullOrEmpty(ctdcbd.DinhMuc_BD.ToString()))
                                    {
                                        ghichu.NOIDUNG += " Định Mức Từ " + ctdcbd.DinhMuc + " -> " + ctdcbd.DinhMuc_BD + ",";
                                    }

                                    string sqlGhiChu = "insert into TB_GHICHU(DANHBO,DONVI,NOIDUNG,CREATEDATE,CREATEBY)values('" + ghichu.DANHBO + "','" + ghichu.DONVI + "',N'" + ghichu.NOIDUNG + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',N'" + CTaiKhoan.HoTen + "')";
                                    if (_cDocSo.LinQ_ExecuteNonQuery(sqlGhiChu))
                                    {
                                        ctdcbd.ChuyenDocSo = true;
                                        ctdcbd.NgayChuyenDocSo = DateTime.Now;
                                        ctdcbd.NguoiChuyenDocSo = CTaiKhoan.MaUser;
                                        _cDCBD.SuaCTDCBD(ctdcbd);
                                    }

                                    log.WriteLine(k.ToString() + "/ " + ctdcbd.MaCTDCBD + " ; " + ctdcbd.ThongTin + " ; " + ctdcbd.DanhBo + " ");
                                    k++;
                                }
                                //else
                                //    MessageBox.Show("Danh Bộ: " + ctdcbd.DanhBo + " thuộc Số Phiếu: " + ctdcbd.MaCTDCBD.ToString().Insert(ctdcbd.MaCTDCBD.ToString().Length - 2, "-")
                                //        + " không có bên QLĐHN", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    //DSDCBD_BS.DataSource = _cDCBD.LoadDSCTDCBD();
                    log.WriteLine("=============================================");
                    log.Close();
                    log.Dispose();
                    MessageBox.Show("Cập Nhật Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //catch (Exception ex)
                    //{
                    //    log.WriteLine("=============================================");
                    //    log.Close();
                    //    log.Dispose();
                    //    MessageBox.Show("Lỗi tại Số Phiếu: " + dgvDSDCBD["SoPhieu", k].Value.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
        }

        private void btnInDSPhieu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn In những Phiếu trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (radDSCatChuyenDM.Checked)
                {
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    for (int i = 0; i < dgvDSCatChuyenDM.Rows.Count; i++)
                        if (dgvDSCatChuyenDM["In_CC", i].Value != null && bool.Parse(dgvDSCatChuyenDM["In_CC", i].Value.ToString()) == true)
                        {
                            LichSuChungTu lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(decimal.Parse(dgvDSCatChuyenDM["SoPhieu_CC", i].Value.ToString()));
                            if (lichsuchungtu.YeuCauCat)
                            {
                                DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                if (!string.IsNullOrEmpty(lichsuchungtu.MaDon.ToString()) || !string.IsNullOrEmpty(lichsuchungtu.MaDonTXL.ToString()))
                                    if (lichsuchungtu.ToXuLy)
                                        dr["MaDon"] = "TXL" + lichsuchungtu.MaDonTXL.ToString().Insert(lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                    else
                                        dr["MaDon"] = lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");

                                dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                                dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(lichsuchungtu.CatNK_MaCN.Value);
                                if (!string.IsNullOrEmpty(lichsuchungtu.NhanNK_DanhBo))
                                    dr["DanhBoNhan"] = lichsuchungtu.NhanNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                dr["HoTenNhan"] = lichsuchungtu.NhanNK_HoTen;
                                dr["DiaChiNhan"] = lichsuchungtu.NhanNK_DiaChi;
                                if (!string.IsNullOrEmpty(lichsuchungtu.CatNK_DanhBo))
                                    dr["DanhBoCat"] = lichsuchungtu.CatNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                dr["HoTenCat"] = lichsuchungtu.CatNK_HoTen;
                                dr["DiaChiCat"] = lichsuchungtu.CatNK_DiaChi;
                                ///có thể sai MaCT, nếu sai đổi lại lấy txtMaCT
                                dr["SoNKCat"] = lichsuchungtu.SoNK.ToString() + " nhân khẩu (HK: " + lichsuchungtu.MaCT + ")";

                                dr["ChucVu"] = lichsuchungtu.ChucVu;
                                dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);
                            }
                        }
                    rptDSPhieuCatChuyen rpt = new rptDSPhieuCatChuyen();
                    rpt.SetDataSource(dsBaoCao);

                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.ShowDialog();
                }
            }
        }

        private void btnInA4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn In những Phiếu trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    if (radDSDCHD.Checked)
                    {
                        for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                            if (dgvDSDCBD["In", i].Value != null && bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true)
                            {
                                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();

                                CTDCHD ctdchd = _cDCBD.getCTDCHDbyID(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));
                                dr["SoPhieu"] = ctdchd.MaCTDCHD.ToString().Insert(ctdchd.MaCTDCHD.ToString().Length - 2, "-");
                                dr["DanhBo"] = ctdchd.DanhBo.Insert(7, " ").Insert(4, " "); ;
                                dr["HoTen"] = ctdchd.HoTen;
                                dr["DiaChi"] = ctdchd.DiaChi;
                                if (ctdchd.DCBD.ToXuLy)
                                    dr["SoDon"] = "TXL" + ctdchd.DCBD.MaDonTXL.Value.ToString().Insert(ctdchd.DCBD.MaDonTXL.Value.ToString().Length - 2, "-");
                                else
                                    dr["SoDon"] = ctdchd.DCBD.MaDon.Value.ToString().Insert(ctdchd.DCBD.MaDon.Value.ToString().Length - 2, "-");
                                dr["NgayKy"] = ctdchd.NgayKy.Value.ToString("dd/MM/yyyy");
                                dr["KyHD"] = ctdchd.KyHD;
                                dr["SoHD"] = ctdchd.SoHD;
                                ///
                                dr["DieuChinh"] = "";
                                if (ctdchd.GiaBieu != ctdchd.GiaBieu_BD)
                                    dr["DieuChinh"] = "Giá Biểu từ " + ctdchd.GiaBieu + " -> " + ctdchd.GiaBieu_BD;
                                if (ctdchd.DinhMuc != ctdchd.DinhMuc_BD)
                                    if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                                        dr["DieuChinh"] = "Định Mức từ " + ctdchd.DinhMuc + " -> " + ctdchd.DinhMuc_BD;
                                    else
                                        dr["DieuChinh"] = dr["DieuChinh"] + ", Định Mức từ " + ctdchd.DinhMuc + " -> " + ctdchd.DinhMuc_BD;
                                if (ctdchd.TieuThu != ctdchd.TieuThu_BD)
                                    if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                                        dr["DieuChinh"] = "Tiêu Thụ từ " + ctdchd.TieuThu + " -> " + ctdchd.TieuThu_BD;
                                    else
                                        dr["DieuChinh"] = dr["DieuChinh"] + ", Tiêu Thụ từ " + ctdchd.TieuThu + " -> " + ctdchd.TieuThu_BD;
                                if (ctdchd.DieuChinhGia == true)
                                {
                                    switch (ctdchd.GiaBieu_BD)
                                    {
                                        case 51:
                                        case 52:
                                        case 53:
                                        case 54:
                                        case 59:
                                        case 68:
                                            if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                                                if (ctdchd.TieuThu_DieuChinhGia == ctdchd.TieuThu_BD)
                                                    dr["DieuChinh"] = ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + (ctdchd.GiaDieuChinh.Value - ctdchd.GiaDieuChinh.Value * CTaiKhoan.GiamTienNuoc / 100).ToString();
                                                else
                                                    dr["DieuChinh"] = ctdchd.DinhMuc_BD + "m3 Áp giá " + (_lstGiaNuoc[0].DonGia.Value - _lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100).ToString() + ", " + ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + (ctdchd.GiaDieuChinh.Value - ctdchd.GiaDieuChinh.Value * CTaiKhoan.GiamTienNuoc / 100).ToString();
                                            else
                                                if (ctdchd.TieuThu_DieuChinhGia == ctdchd.TieuThu_BD)
                                                    dr["DieuChinh"] = dr["DieuChinh"] + ", " + ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + (ctdchd.GiaDieuChinh.Value - ctdchd.GiaDieuChinh.Value * CTaiKhoan.GiamTienNuoc / 100).ToString();
                                                else
                                                    dr["DieuChinh"] = dr["DieuChinh"] + ", " + ctdchd.DinhMuc_BD + "m3 Áp giá " + (_lstGiaNuoc[0].DonGia.Value - _lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100).ToString() + ", " + ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + (ctdchd.GiaDieuChinh.Value - ctdchd.GiaDieuChinh.Value * CTaiKhoan.GiamTienNuoc / 100).ToString();
                                            break;
                                        default:
                                            if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                                                if (ctdchd.TieuThu_DieuChinhGia == ctdchd.TieuThu_BD)
                                                    dr["DieuChinh"] = ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + ctdchd.GiaDieuChinh.Value;
                                                else
                                                    dr["DieuChinh"] = ctdchd.DinhMuc_BD + "m3 Áp giá " + _lstGiaNuoc[0].DonGia.Value + ", " + ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + ctdchd.GiaDieuChinh.Value;
                                            else
                                                if (ctdchd.TieuThu_DieuChinhGia == ctdchd.TieuThu_BD)
                                                    dr["DieuChinh"] = dr["DieuChinh"] + ", " + ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + ctdchd.GiaDieuChinh.Value;
                                                else
                                                    dr["DieuChinh"] = dr["DieuChinh"] + ", " + ctdchd.DinhMuc_BD + "m3 Áp giá " + _lstGiaNuoc[0].DonGia.Value + ", " + ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + ctdchd.GiaDieuChinh.Value;
                                            break;
                                    }
                                    dr["ChiTietCu"] = ctdchd.ChiTietCu;
                                    dr["ChiTietMoi"] = ctdchd.ChiTietMoi;
                                }
                                if (ctdchd.TyLe)
                                {
                                    if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                                        dr["DieuChinh"] = "Tỷ lệ";
                                    else
                                        dr["DieuChinh"] = dr["DieuChinh"] + ", Tỷ lệ";
                                    if (ctdchd.SH != 0)
                                        dr["DieuChinh"] = dr["DieuChinh"] + " SH: " + ctdchd.SH.Value.ToString() + "%";
                                    if (ctdchd.SX != 0)
                                        dr["DieuChinh"] = dr["DieuChinh"] + " SX: " + ctdchd.SX.Value.ToString() + "%";
                                    if (ctdchd.DV != 0)
                                        dr["DieuChinh"] = dr["DieuChinh"] + " DV: " + ctdchd.DV.Value.ToString() + "%";
                                    if (ctdchd.HCSN != 0)
                                        dr["DieuChinh"] = dr["DieuChinh"] + " HCSN: " + ctdchd.HCSN.Value.ToString() + "%";
                                    dr["ChiTietCu"] = ctdchd.ChiTietCu;
                                    dr["ChiTietMoi"] = ctdchd.ChiTietMoi;
                                }
                                ///
                                dr["GiaBieuStart"] = ctdchd.GiaBieu;
                                dr["GiaBieuEnd"] = ctdchd.GiaBieu_BD;
                                dr["DinhMucStart"] = ctdchd.DinhMuc;
                                dr["DinhMucEnd"] = ctdchd.DinhMuc_BD;
                                dr["TieuThuStart"] = ctdchd.TieuThu;
                                if (ctdchd.TienNuoc_Start == 0)
                                    dr["TienNuocStart"] = "0";
                                else
                                    dr["TienNuocStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TienNuoc_Start);
                                if (ctdchd.ThueGTGT_Start == 0)
                                    dr["ThueGTGTStart"] = 0;
                                else
                                    dr["ThueGTGTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.ThueGTGT_Start);
                                if (ctdchd.PhiBVMT_Start == 0)
                                    dr["PhiBVMTStart"] = 0;
                                else
                                    dr["PhiBVMTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_Start);
                                if (ctdchd.TongCong_Start == 0)
                                    dr["TongCongStart"] = 0;
                                else
                                    dr["TongCongStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_Start);
                                ///
                                dr["TangGiam"] = ctdchd.TangGiam;
                                ///
                                dr["TieuThuBD"] = ctdchd.TieuThu_BD - ctdchd.TieuThu;
                                if (ctdchd.TienNuoc_BD == 0)
                                    dr["TienNuocBD"] = 0;
                                else
                                    dr["TienNuocBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TienNuoc_BD);
                                if (ctdchd.ThueGTGT_BD == 0)
                                    dr["ThueGTGTBD"] = 0;
                                else
                                    dr["ThueGTGTBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.ThueGTGT_BD);
                                if (ctdchd.PhiBVMT_BD == 0)
                                    dr["PhiBVMTBD"] = 0;
                                else
                                    dr["PhiBVMTBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_BD);
                                if (ctdchd.TongCong_BD == 0)
                                    dr["TongCongBD"] = 0;
                                else
                                    dr["TongCongBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_BD);
                                ///
                                dr["TieuThuEnd"] = ctdchd.TieuThu_BD;
                                if (ctdchd.TienNuoc_End == 0)
                                    dr["TienNuocEnd"] = 0;
                                else
                                    dr["TienNuocEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TienNuoc_End);
                                if (ctdchd.ThueGTGT_End == 0)
                                    dr["ThueGTGTEnd"] = 0;
                                else
                                    dr["ThueGTGTEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.ThueGTGT_End);
                                if (ctdchd.PhiBVMT_End == 0)
                                    dr["PhiBVMTEnd"] = 0;
                                else
                                    dr["PhiBVMTEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_End);
                                if (ctdchd.TongCong_End == 0)
                                    dr["TongCongEnd"] = 0;
                                else
                                    dr["TongCongEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_End);

                                dr["ChucVu"] = ctdchd.ChucVu;
                                dr["NguoiKy"] = ctdchd.NguoiKy;

                                dsBaoCao.Tables["DCHD"].Rows.Add(dr);

                                rptThongBaoDCHD rpt = new rptThongBaoDCHD();
                                rpt.SetDataSource(dsBaoCao);

                                printDialog.AllowSomePages = true;
                                printDialog.ShowHelp = true;

                                rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                rpt.PrintToPrinter(1, false, 1, 1);
                            }
                    }

                }
            }
        }

        #region dgvDSDCBD (Danh Sách Điều Chỉnh Biến Động)

        /// <summary>
        /// Hiện thị số thứ tự dòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSDCBD_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDCBD.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        /// <summary>
        /// Format dữ liệu trong column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSDCBD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSDCBD.Columns[e.ColumnIndex].Name == "SoPhieu" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvDSDCBD.Columns[e.ColumnIndex].Name == "TongCong_Start" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDSDCBD.Columns[e.ColumnIndex].Name == "TongCong_End" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDSDCBD.Columns[e.ColumnIndex].Name == "TongCong_BD" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        /// <summary>
        /// Kết thúc Edit Column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSDCBD_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (radDSDCBD.Checked)
            {
                bool ischecked = false;
                if (bool.Parse(dgvDSDCBD["PhieuDuocKy", e.RowIndex].Value.ToString()) == true)
                    ischecked = true;
                else
                    ischecked = false;
                CTDCBD ctdcbd = _cDCBD.getCTDCBDbyID(decimal.Parse(dgvDSDCBD.CurrentRow.Cells["SoPhieu"].Value.ToString()));
                if (ctdcbd.PhieuDuocKy != ischecked)
                {
                    ctdcbd.PhieuDuocKy = ischecked;
                    _cDCBD.SuaCTDCBD(ctdcbd);
                }
            }
            if (radDSDCHD.Checked)
            {
                bool ischecked = false;
                if (bool.Parse(dgvDSDCBD["PhieuDuocKy", e.RowIndex].Value.ToString()) == true)
                    ischecked = true;
                else
                    ischecked = false;
                CTDCHD ctdchd = _cDCBD.getCTDCHDbyID(decimal.Parse(dgvDSDCBD.CurrentRow.Cells["SoPhieu"].Value.ToString()));
                if (ctdchd.PhieuDuocKy != ischecked)
                {
                    ctdchd.PhieuDuocKy = ischecked;
                    _cDCBD.SuaCTDCHD(ctdchd);
                }
            }
        }

        /// <summary>
        /// Ctrl+F Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSDCBD_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSDCBD.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                if (radDSDCBD.Checked)
                {
                    frmDCBD frm = new frmDCBD(decimal.Parse(dgvDSDCBD["SoPhieu", dgvDSDCBD.CurrentRow.Index].Value.ToString()));
                    if (frm.ShowDialog() == DialogResult.OK) { }
                    //DSDCBD_BS.DataSource = _cDCBD.LoadDSCTDCBD();
                }
                if (radDSDCHD.Checked)
                {
                    frmDCHD frm = new frmDCHD(decimal.Parse(dgvDSDCBD["SoPhieu", dgvDSDCBD.CurrentRow.Index].Value.ToString()));
                    if (frm.ShowDialog() == DialogResult.OK) { }
                    //DSDCBD_BS.DataSource = _cDCBD.LoadDSCTDCHD();
                }
            }
        }

        #endregion

        #region dgvDSCatChuyenDM (Danh Sách Cắt Chuyển Định Mức)

        private void dgvDSCatChuyenDM_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSCatChuyenDM.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSCatChuyenDM_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSCatChuyenDM.Columns[e.ColumnIndex].Name == "PhieuDuocKy_CC")
            {
                LichSuChungTu lichsuchungtu = _cChungTu.getLSCTbyID(decimal.Parse(dgvDSCatChuyenDM.CurrentRow.Cells["MaLSCT"].Value.ToString()));
                lichsuchungtu.PhieuDuocKy = bool.Parse(dgvDSCatChuyenDM["PhieuDuocKy_CC", e.RowIndex].Value.ToString());
                _cChungTu.SuaLichSuChungTu(lichsuchungtu);
            }
        }

        private void dgvDSCatChuyenDM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSCatChuyenDM.Columns[e.ColumnIndex].Name == "SoPhieu_CC" && e.Value != null && e.Value.ToString().Length > 2)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvDSCatChuyenDM.Columns[e.ColumnIndex].Name == "MaCTDCBD_CC" && e.Value != null && e.Value.ToString().Length > 2)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvDSCatChuyenDM_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSCatChuyenDM.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmCatChuyenDM frm = new frmCatChuyenDM(decimal.Parse(dgvDSCatChuyenDM["MaLSCT", dgvDSCatChuyenDM.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }

        #endregion

        private void txtNoiDungTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtNoiDungTimKiem.Text.Trim() != "")
                btnXem.PerformClick();
        }

        private void txtNoiDungTimKiem2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                btnXem.PerformClick();
        }

        private void dgvDSDCBD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSDCBD.Columns[e.ColumnIndex].Name == "CodeF2")
            {
                CTDCHD ctdchd = _cDCBD.getCTDCHDbyID(decimal.Parse(dgvDSDCBD["SoPhieu", e.RowIndex].Value.ToString()));
                ctdchd.CodeF2 = bool.Parse(dgvDSDCBD["CodeF2", e.RowIndex].Value.ToString());
                _cDCBD.SuaCTDCHD(ctdchd);
            }
        }

        
    }
}

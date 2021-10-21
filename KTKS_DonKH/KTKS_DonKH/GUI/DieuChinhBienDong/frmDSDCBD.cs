using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.GUI.ToKhachHang;
using KTKS_DonKH.DAL.ToKhachHang;
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
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDSDCBD : Form
    {
        CDonTu _cDonTu = new CDonTu();
        CDonKH _cDonKH = new CDonKH();
        CDCBD _cDCBD = new CDCBD();
        CKTXM _cKTXM = new CKTXM();
        CChiNhanh _cChiNhanh = new CChiNhanh();
        CChungTu _cChungTu = new CChungTu();
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();
        CDHN _cDocSo = new CDHN();
        CThuTien _cThuTien = new CThuTien();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        string _mnu = "mnuDSDCBD";
        List<GiaNuoc> _lstGiaNuoc;
        dbThuTienDataContext _dbThuTien = new dbThuTienDataContext();

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
                dgvDSDCBD.Columns["DinhMucHN"].Visible = true;
                dgvDSDCBD.Columns["DinhMucHN_BD"].Visible = true;
                ///
                //dgvDSDCBD.Columns["ChuyenThuTien"].Visible = false;
                dgvDSDCBD.Columns["ThuTienCapNhat"].Visible = false;
                dgvDSDCBD.Columns["ThuTienGiaiTrach"].Visible = false;
                dgvDSDCBD.Columns["Ky"].Visible = false;
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
                //dgvDSDCBD.Columns["ChuyenThuTien"].Visible = true;
                dgvDSDCBD.Columns["ThuTienCapNhat"].Visible = true;
                dgvDSDCBD.Columns["ThuTienGiaiTrach"].Visible = true;
                dgvDSDCBD.Columns["Ky"].Visible = true;
                dgvDSDCBD.Columns["CodeF2"].Visible = true;
                dgvDSDCBD.Columns["GiaBieu"].Visible = true;
                dgvDSDCBD.Columns["GiaBieu_BD"].Visible = true;
                dgvDSDCBD.Columns["DinhMuc"].Visible = true;
                dgvDSDCBD.Columns["DinhMuc_BD"].Visible = true;
                dgvDSDCBD.Columns["DinhMucHN"].Visible = true;
                dgvDSDCBD.Columns["DinhMucHN_BD"].Visible = true;
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
            //string sql = "select *,SoPhieu=MaCTDCBD,'In'='false' from DCBD_ChiTietBienDong where CAST(CreateDate as date)>='2018-03-01' and CAST(CreateDate as date)<='2018-03-31' and ChuyenDocSo=0 and PhieuDuocKy=1"
            //+ " and DanhBo not in (select DanhBo from DCBD_ChiTietBienDong where CAST(CreateDate as date)>'2018-03-31') order by CreateDate asc";
            //dgvDSDCBD.DataSource = _cDCBD.ExecuteQuery_SqlDataAdapter_DataTable(sql);
            if (chkCreateBy.Checked)
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Mã Đơn":
                        if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                        {
                            if (radDSDCBD.Checked)
                            {
                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                    dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_MaDon("TKH", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                                else
                                    if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                        dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_MaDon("TXL", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                                    else
                                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                            dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_MaDon("TBC", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                                        else
                                            dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_MaDon("", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim()), decimal.Parse(txtNoiDungTimKiem2.Text.Trim()));
                            }
                            else
                                if (radDSDCHD.Checked)
                                {
                                    if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                        dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_MaDon("TKH", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                                    else
                                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                            dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_MaDon("TXL", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                                        else
                                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                                dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_MaDon("TBC", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                                            else
                                                dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_MaDon("", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim()), decimal.Parse(txtNoiDungTimKiem2.Text.Trim()));
                                }
                                else
                                    if (radDSCatChuyenDM.Checked)
                                    {
                                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                            dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_MaDon("TKH", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                                        else
                                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                                dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_MaDon("TXL", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                                            else
                                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                                    dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_MaDon("TBC", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                                                else
                                                    dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_MaDon("", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim()), decimal.Parse(txtNoiDungTimKiem2.Text.Trim()));
                                    }
                        }
                        else
                            if (txtNoiDungTimKiem.Text.Trim() != "")
                            {
                                if (radDSDCBD.Checked)
                                {
                                    if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                        dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_MaDon("TKH", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                    else
                                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                            dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_MaDon("TXL", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                        else
                                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                                dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_MaDon("TBC", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                            else
                                                dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_MaDon("", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim()));
                                }
                                else
                                    if (radDSDCHD.Checked)
                                    {
                                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                            dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_MaDon("TKH", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                        else
                                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                                dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_MaDon("TXL", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                            else
                                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                                    dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_MaDon("TBC", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                                else
                                                    dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_MaDon("", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim()));
                                    }
                                    else
                                        if (radDSCatChuyenDM.Checked)
                                        {
                                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                                dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_MaDon("TKH", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                            else
                                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                                    dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_MaDon("TXL", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                                else
                                                    if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                                        dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_MaDon("TBC", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                                    else
                                                        dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_MaDon("", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim()));
                                        }
                            }
                        break;
                    case "Số Phiếu":
                        if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                        {
                            if (radDSDCBD.Checked)
                                dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_SoPhieu(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                            else
                                if (radDSDCHD.Checked)
                                    dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_SoPhieu(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                                else
                                    if (radDSCatChuyenDM.Checked)
                                        dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_SoPhieu(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                        }
                        else
                            if (txtNoiDungTimKiem.Text.Trim() != "")
                            {
                                if (radDSDCBD.Checked)
                                    dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_SoPhieu(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                                else
                                    if (radDSDCHD.Checked)
                                        dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_SoPhieu(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                                    else
                                        if (radDSCatChuyenDM.Checked)
                                            dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_SoPhieu(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                            }
                        break;
                    case "Danh Bộ":
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                        {
                            if (radDSDCBD.Checked)
                                dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_DanhBo(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim().Replace(" ", ""));
                            else
                                if (radDSDCHD.Checked)
                                    dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_DanhBo(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim().Replace(" ", ""));
                                else
                                    if (radDSCatChuyenDM.Checked)
                                        dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_DanhBo(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim().Replace(" ", ""));
                        }
                        break;
                    case "Ngày":
                        if (radDSDCBD.Checked)
                            dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_CreateDate(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                        else
                            if (radDSDCHD.Checked)
                                if (txtKy.Text.Trim() != "")
                                    dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_CreateDate(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                                else
                                    dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_CreateDate(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                            else
                                if (radDSCatChuyenDM.Checked)
                                    dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_CreateDate(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                        break;
                    default:
                        break;
                }
            else
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Mã Đơn":
                        if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                        {
                            if (radDSDCBD.Checked)
                            {
                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                    dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_MaDon("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                                else
                                    if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                        dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_MaDon("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                                    else
                                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                            dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_MaDon("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                                        else
                                            dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_MaDon("", decimal.Parse(txtNoiDungTimKiem.Text.Trim()), decimal.Parse(txtNoiDungTimKiem2.Text.Trim()));
                            }
                            else
                                if (radDSDCHD.Checked)
                                {
                                    if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                        dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_MaDon("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                                    else
                                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                            dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_MaDon("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                                        else
                                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                                dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_MaDon("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                                            else
                                                dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_MaDon("", decimal.Parse(txtNoiDungTimKiem.Text.Trim()), decimal.Parse(txtNoiDungTimKiem2.Text.Trim()));
                                }
                                else
                                    if (radDSCatChuyenDM.Checked)
                                    {
                                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                            dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_MaDon("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                                        else
                                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                                dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_MaDon("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                                            else
                                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                                    dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_MaDon("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                                                else
                                                    dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_MaDon("", decimal.Parse(txtNoiDungTimKiem.Text.Trim()), decimal.Parse(txtNoiDungTimKiem2.Text.Trim()));

                                    }
                        }
                        else
                            if (txtNoiDungTimKiem.Text.Trim() != "")
                            {
                                if (radDSDCBD.Checked)
                                {
                                    if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                        dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_MaDon("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                    else
                                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                            dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_MaDon("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                        else
                                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                                dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_MaDon("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                            else
                                                dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_MaDon("", decimal.Parse(txtNoiDungTimKiem.Text.Trim()));

                                }
                                else
                                    if (radDSDCHD.Checked)
                                    {
                                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                            dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_MaDon("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                        else
                                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                                dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_MaDon("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                            else
                                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                                    dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_MaDon("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                                else
                                                    dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_MaDon("", decimal.Parse(txtNoiDungTimKiem.Text.Trim()));

                                    }
                                    else
                                        if (radDSCatChuyenDM.Checked)
                                        {
                                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                                dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_MaDon("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                            else
                                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                                    dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_MaDon("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                                else
                                                    if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                                        dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_MaDon("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                                    else
                                                        dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_MaDon("", decimal.Parse(txtNoiDungTimKiem.Text.Trim()));

                                        }
                            }
                        break;
                    case "Số Phiếu":
                        if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                        {
                            if (radDSDCBD.Checked)
                                dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_SoPhieu(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                            else
                                if (radDSDCHD.Checked)
                                    dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_SoPhieu(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                                else
                                    if (radDSCatChuyenDM.Checked)
                                        dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_SoPhieu(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                        }
                        else
                            if (txtNoiDungTimKiem.Text.Trim() != "")
                            {
                                if (radDSDCBD.Checked)
                                    dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_SoPhieu(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                                else
                                    if (radDSDCHD.Checked)
                                        dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_SoPhieu(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                                    else
                                        if (radDSCatChuyenDM.Checked)
                                            dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_SoPhieu(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                            }
                        break;
                    case "Danh Bộ":
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                        {
                            if (radDSDCBD.Checked)
                                dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_DanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""));
                            else
                                if (radDSDCHD.Checked)
                                    dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_DanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""));
                                else
                                    if (radDSCatChuyenDM.Checked)
                                        dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_DanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""));
                        }
                        break;
                    case "Ngày":
                        if (radDSDCBD.Checked)
                            dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_CreateDate(dateTu.Value, dateDen.Value);
                        else
                            if (radDSDCHD.Checked)
                                if (txtKy.Text.Trim() != "")
                                    dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_CreateDate(dateTu.Value, dateDen.Value, txtKy.Text.Trim());
                                else
                                    dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_CreateDate(dateTu.Value, dateDen.Value);
                            else
                                if (radDSCatChuyenDM.Checked)
                                    dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_CreateDate(dateTu.Value, dateDen.Value);
                        break;
                    default:
                        break;
                }
            if (radDSDCHD.Checked)
                foreach (DataGridViewRow item in dgvDSDCBD.Rows)
                {
                    string[] Kys = item.Cells["Ky"].Value.ToString().Split('/');
                    item.Cells["ThuTienCapNhat"].Value = _dbThuTien.DIEUCHINH_HDs.Any(itemDC => itemDC.FK_HOADON == _dbThuTien.HOADONs.SingleOrDefault(itemHD => itemHD.DANHBA == item.Cells["DanhBo"].Value.ToString() && itemHD.NAM == int.Parse(Kys[1]) && itemHD.KY == int.Parse(Kys[0])).ID_HOADON && itemDC.TONGCONG_END != null);
                    item.Cells["ThuTienGiaiTrach"].Value = _dbThuTien.HOADONs.SingleOrDefault(itemHD => itemHD.DANHBA == item.Cells["DanhBo"].Value.ToString() && itemHD.NAM == int.Parse(Kys[1]) && itemHD.KY == int.Parse(Kys[0])).NGAYGIAITRACH;
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
                //PrintDialog printDialog = new PrintDialog();
                //if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    if (radDSDCBD.Checked)
                    {
                        for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                            if (dgvDSDCBD["In", i].Value != null && bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true)
                            {
                                //DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                DataRow dr = dsBaoCao.Tables["DCBD"].NewRow();

                                DCBD_ChiTietBienDong ctdcbd = _cDCBD.getBienDong(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));
                                if (ctdcbd.DCBD.MaDonMoi != null)
                                {
                                    if (ctdcbd.DCBD.DonTu.DonTu_ChiTiets.Count == 1)
                                        dr["MaDon"] = ctdcbd.DCBD.MaDonMoi.ToString();
                                    else
                                        dr["MaDon"] = ctdcbd.DCBD.MaDonMoi.ToString() + "." + ctdcbd.STT;
                                }
                                else
                                    if (ctdcbd.DCBD.MaDon != null)
                                        dr["MaDon"] = ctdcbd.DCBD.MaDon.ToString().Insert(ctdcbd.DCBD.MaDon.ToString().Length - 2, "-");
                                    else
                                        if (ctdcbd.DCBD.MaDonTXL != null)
                                            dr["MaDon"] = "TXL" + ctdcbd.DCBD.MaDonTXL.ToString().Insert(ctdcbd.DCBD.MaDonTXL.ToString().Length - 2, "-");
                                        else
                                            if (ctdcbd.DCBD.MaDonTBC != null)
                                                dr["MaDon"] = "TBC" + ctdcbd.DCBD.MaDonTBC.ToString().Insert(ctdcbd.DCBD.MaDonTBC.ToString().Length - 2, "-");

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
                                if (ctdcbd.XoaDiaChiLienHe == true)
                                    dr["XoaDiaChiLienHe"] = "Xóa Địa Chỉ Liên Hệ";
                                dr["MaQuanPhuong"] = ctdcbd.MaQuanPhuong;
                                dr["GiaBieu"] = ctdcbd.GiaBieu;
                                dr["DinhMuc"] = ctdcbd.DinhMuc;
                                dr["DinhMucHN"] = ctdcbd.DinhMucHN;
                                ///Biến Động
                                dr["HoTenBD"] = ctdcbd.HoTen_BD;
                                dr["DiaChiBD"] = ctdcbd.DiaChi_BD;
                                dr["GiaBieuBD"] = ctdcbd.GiaBieu_BD;
                                dr["DinhMucBD"] = ctdcbd.DinhMuc_BD;
                                dr["DinhMucHNBD"] = ctdcbd.DinhMucHN_BD;
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
                                    if (ctdcbd.GBGiuNguyen)
                                        dr["KhongBD"] = "GB Giữ Nguyên";
                                    else
                                        if (ctdcbd.GiaHanKT3)
                                            dr["KhongBD"] = "Gia Hạn KT3";
                                        else
                                            if (ctdcbd.GiaHanNhapCu)
                                                dr["KhongBD"] = "Gia Hạn Nhập Cư";
                                            else
                                            {
                                                dr["ChucVu"] = ctdcbd.ChucVu;
                                                dr["NguoiKy"] = ctdcbd.NguoiKy;
                                            }

                                dsBaoCao.Tables["DCBD"].Rows.Add(dr);

                                //rptPhieuDCBD_15112019 rpt = new rptPhieuDCBD_15112019();
                                //rpt.SetDataSource(dsBaoCao);

                                //printDialog.AllowSomePages = true;
                                //printDialog.ShowHelp = true;

                                //rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                //rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                //rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                                //rpt.Clone();
                                //rpt.Dispose();
                            }
                        rptPhieuDCBD_15112019 rpt = new rptPhieuDCBD_15112019();
                        rpt.SetDataSource(dsBaoCao);
                        frmShowBaoCao frm = new frmShowBaoCao(rpt);
                        frm.Show();
                    }
                    else
                        if (radDSDCHD.Checked)
                        {
                            for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                                if (dgvDSDCBD["In", i].Value != null && bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true)
                                {
                                    //DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                    DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();

                                    DCBD_ChiTietHoaDon ctdchd = _cDCBD.getHoaDon(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));
                                    dr["SoPhieu"] = ctdchd.MaCTDCHD.ToString().Insert(ctdchd.MaCTDCHD.ToString().Length - 2, "-");
                                    dr["DanhBo"] = ctdchd.DanhBo.Insert(7, " ").Insert(4, " "); ;
                                    dr["HoTen"] = ctdchd.HoTen;
                                    if (ctdchd.DCBD.MaDonMoi != null)
                                    {
                                        if (ctdchd.DCBD.DonTu.DonTu_ChiTiets.Count == 1)
                                            dr["SoVanBan"] = ctdchd.DCBD.MaDonMoi.Value.ToString();
                                        else
                                            dr["SoVanBan"] = ctdchd.DCBD.MaDonMoi.Value.ToString() + "." + ctdchd.STT;
                                    }
                                    else
                                        if (ctdchd.DCBD.MaDon != null)
                                            dr["SoVanBan"] = ctdchd.DCBD.MaDon.Value.ToString().Insert(ctdchd.DCBD.MaDon.Value.ToString().Length - 2, "-");
                                        else
                                            if (ctdchd.DCBD.MaDonTXL != null)
                                                dr["SoVanBan"] = "TXL" + ctdchd.DCBD.MaDonTXL.Value.ToString().Insert(ctdchd.DCBD.MaDonTXL.Value.ToString().Length - 2, "-");
                                            else
                                                if (ctdchd.DCBD.MaDonTBC != null)
                                                    dr["SoVanBan"] = "TBC" + ctdchd.DCBD.MaDonTBC.Value.ToString().Insert(ctdchd.DCBD.MaDonTBC.Value.ToString().Length - 2, "-");

                                    dr["NgayVanBan"] = ctdchd.NgayKy.Value.ToString("dd/MM/yyyy");
                                    dr["KyHD"] = ctdchd.KyHD;
                                    dr["SoHD"] = ctdchd.SoHD;
                                    ///
                                    dr["TieuThuStart"] = ctdchd.TieuThu;
                                    if (ctdchd.TienNuoc_Start == 0)
                                        dr["TienNuocStart"] = 0;
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

                                    //rptPhieuDCHD rpt = new rptPhieuDCHD();
                                    //rpt.SetDataSource(dsBaoCao);

                                    //printDialog.AllowSomePages = true;
                                    //printDialog.ShowHelp = true;

                                    //rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                    //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                    //rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                    //rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                                    //rpt.Clone();
                                    //rpt.Dispose();
                                }
                            rptPhieuDCHD rpt = new rptPhieuDCHD();
                            rpt.SetDataSource(dsBaoCao);
                            frmShowBaoCao frm = new frmShowBaoCao(rpt);
                            frm.Show();
                        }
                        else
                            if (radDSCatChuyenDM.Checked)
                            {
                                for (int i = 0; i < dgvDSCatChuyenDM.Rows.Count; i++)
                                    if (dgvDSCatChuyenDM["In_CC", i].Value != null && bool.Parse(dgvDSCatChuyenDM["In_CC", i].Value.ToString()) == true)
                                    {
                                        ChungTu_LichSu lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(decimal.Parse(dgvDSCatChuyenDM["SoPhieu_CC", i].Value.ToString()));

                                        if (lichsuchungtu.YeuCauCat)
                                        {
                                            //DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                            DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                            dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;
                                            if (lichsuchungtu.MaDonMoi != null)
                                            {
                                                LinQ.DonTu en = _cDonTu.get(lichsuchungtu.MaDonMoi.Value);
                                                if (en.DonTu_ChiTiets.Count == 1)
                                                    dr["MaDon"] = lichsuchungtu.MaDonMoi.ToString();
                                                else
                                                    dr["MaDon"] = lichsuchungtu.MaDonMoi.ToString() + "." + lichsuchungtu.STT.Value.ToString();
                                            }
                                            else
                                                if (lichsuchungtu.MaDon != null)
                                                    dr["MaDon"] = "TKH" + lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");
                                                else
                                                    if (lichsuchungtu.MaDonTXL != null)
                                                        dr["MaDon"] = "TXL" + lichsuchungtu.MaDonTXL.ToString().Insert(lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                                    else
                                                        if (lichsuchungtu.MaDonTBC != null)
                                                            dr["MaDon"] = "TBC" + lichsuchungtu.MaDonTBC.ToString().Insert(lichsuchungtu.MaDonTBC.ToString().Length - 2, "-");

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
                                            dr["SoNKCat"] = lichsuchungtu.SoNK.ToString() + " nhân khẩu (" + _cLoaiChungTu.GetKyHieu(lichsuchungtu.MaLCT.Value) + ": " + lichsuchungtu.MaCT + ")";
                                            dr["HoTensCat"] = lichsuchungtu.CatNK_HoTens;

                                            dr["ChucVu"] = lichsuchungtu.ChucVu;
                                            dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                            dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                                            DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                                            drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                                            dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(drLogo);

                                            //rptPhieuYCCatDM_A4 rpt = new rptPhieuYCCatDM_A4();
                                            //rpt.SetDataSource(dsBaoCao);
                                            //rpt.Subreports[0].SetDataSource(dsBaoCao);

                                            //printDialog.AllowSomePages = true;
                                            //printDialog.ShowHelp = true;

                                            //rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                            //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                            //rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                            //rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                                            //rpt.Clone();
                                            //rpt.Dispose();
                                        }
                                        else
                                            if (lichsuchungtu.CatDM)
                                            {
                                                //DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                                //DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                                //if (lichsuchungtu.MaDon != null)
                                                //    dr["MaDon"] = lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");
                                                //else
                                                //    if (lichsuchungtu.MaDonTXL != null)
                                                //        dr["MaDon"] = "TXL" + lichsuchungtu.MaDonTXL.ToString().Insert(lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                                //    else
                                                //        if (lichsuchungtu.MaDonTBC != null)
                                                //            dr["MaDon"] = "TBC" + lichsuchungtu.MaDonTBC.ToString().Insert(lichsuchungtu.MaDonTBC.ToString().Length - 2, "-");

                                                //dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                                                //dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(lichsuchungtu.NhanNK_MaCN.Value);
                                                //if (!string.IsNullOrEmpty(lichsuchungtu.NhanNK_DanhBo))
                                                //    dr["DanhBoNhan"] = lichsuchungtu.NhanNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                                //dr["HoTenNhan"] = lichsuchungtu.NhanNK_HoTen;
                                                //dr["DiaChiNhan"] = lichsuchungtu.NhanNK_DiaChi;
                                                //if (!string.IsNullOrEmpty(lichsuchungtu.CatNK_DanhBo))
                                                //    dr["DanhBoCat"] = lichsuchungtu.CatNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                                //dr["HoTenCat"] = lichsuchungtu.CatNK_HoTen;
                                                //dr["DiaChiCat"] = lichsuchungtu.CatNK_DiaChi;
                                                //dr["SoNKCat"] = lichsuchungtu.SoNK + " nhân khẩu (" + _cLoaiChungTu.GetKyHieu(lichsuchungtu.MaLCT.Value) + ": " + lichsuchungtu.MaCT + ")";

                                                //dr["ChucVu"] = lichsuchungtu.ChucVu;
                                                //dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                                //dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                                                //rptPhieuYCNhanDMx2 rpt = new rptPhieuYCNhanDMx2();
                                                //for (int j = 0; j < rpt.Subreports.Count; j++)
                                                //{
                                                //    rpt.Subreports[j].SetDataSource(dsBaoCao);
                                                //}

                                                //printDialog.AllowSomePages = true;
                                                //printDialog.ShowHelp = true;

                                                //rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                                //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                                                //rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                                //rpt.PrintToPrinter(1, false, 1, 1);
                                                MessageBox.Show("Liện hệ BB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            else
                                                if (lichsuchungtu.NhanDM)
                                                {
                                                    //DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                                    //DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                                    //if (lichsuchungtu.MaDon != null)
                                                    //    dr["MaDon"] = lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");
                                                    //else
                                                    //    if (lichsuchungtu.MaDonTXL != null)
                                                    //        dr["MaDon"] = "TXL" + lichsuchungtu.MaDonTXL.ToString().Insert(lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                                    //    else
                                                    //        if (lichsuchungtu.MaDonTBC != null)
                                                    //            dr["MaDon"] = "TBC" + lichsuchungtu.MaDonTBC.ToString().Insert(lichsuchungtu.MaDonTBC.ToString().Length - 2, "-");

                                                    //dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                                                    //dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(lichsuchungtu.CatNK_MaCN.Value);
                                                    //if (!string.IsNullOrEmpty(lichsuchungtu.NhanNK_DanhBo))
                                                    //    dr["DanhBoNhan"] = lichsuchungtu.NhanNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                                    //dr["HoTenNhan"] = lichsuchungtu.NhanNK_HoTen;
                                                    //dr["DiaChiNhan"] = lichsuchungtu.NhanNK_DiaChi;
                                                    //if (!string.IsNullOrEmpty(lichsuchungtu.CatNK_DanhBo))
                                                    //    dr["DanhBoCat"] = lichsuchungtu.CatNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                                    //dr["HoTenCat"] = lichsuchungtu.CatNK_HoTen;
                                                    //dr["DiaChiCat"] = lichsuchungtu.CatNK_DiaChi;
                                                    /////có thể sai MaCT, nếu sai đổi lại lấy txtMaCT
                                                    //dr["SoNKCat"] = lichsuchungtu.SoNK.ToString() + " nhân khẩu (" + _cLoaiChungTu.GetKyHieu(lichsuchungtu.MaLCT.Value) + ": " + lichsuchungtu.MaCT + ")";

                                                    //dr["ChucVu"] = lichsuchungtu.ChucVu;
                                                    //dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                                    //dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                                                    //rptPhieuYCCatDMx2 rpt = new rptPhieuYCCatDMx2();
                                                    //for (int j = 0; j < rpt.Subreports.Count; j++)
                                                    //{
                                                    //    rpt.Subreports[j].SetDataSource(dsBaoCao);
                                                    //}

                                                    //printDialog.AllowSomePages = true;
                                                    //printDialog.ShowHelp = true;

                                                    //rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                                    //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                                                    //rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                                    //rpt.PrintToPrinter(1, false, 1, 1);
                                                    MessageBox.Show("Liện hệ BB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                    }
                                rptPhieuYCCatDM_A4 rpt = new rptPhieuYCCatDM_A4();
                                rpt.SetDataSource(dsBaoCao);
                                rpt.Subreports[0].SetDataSource(dsBaoCao);
                                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                                frm.Show();
                            }
                }
            }
        }

        private void btnCapNhatDocSo_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (MessageBox.Show("Bạn chắc chắn Cập Nhật Đọc Số những Phiếu trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        if (radDSDCBD.Checked)
                        {
                            string k = "";
                            //System.IO.StreamWriter log = System.IO.File.AppendText("\\\\192.168.90.9\\cntt\\BaoBao\\KTKS_DonKH\\log.txt");
                            try
                            {
                                //log.WriteLine("Danh Sách chuyển Đọc số ngày " + DateTime.Now);
                                for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                                    if (dgvDSDCBD["In", i].Value != null && bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true && bool.Parse(dgvDSDCBD["PhieuDuocKy", i].Value.ToString()) == true && bool.Parse(dgvDSDCBD["ChuyenDocSo", i].Value.ToString()) == false)
                                    //using (var scope = new TransactionScope())
                                    {
                                        DCBD_ChiTietBienDong ctdcbd = new DCBD_ChiTietBienDong();
                                        ctdcbd = _cDCBD.getBienDong(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));

                                        if (ctdcbd != null)
                                        {
                                            if (_cDocSo.CheckExist(ctdcbd.DanhBo) && !string.IsNullOrEmpty(ctdcbd.ThongTin))
                                            {
                                                k = ctdcbd.MaCTDCBD.ToString();
                                                if (!string.IsNullOrEmpty(ctdcbd.DinhMuc_BD.ToString()))
                                                {
                                                    _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set DINHMUC=" + ctdcbd.DinhMuc_BD.Value.ToString() + " where DANHBO='" + ctdcbd.DanhBo + "'");
                                                }
                                                if (!string.IsNullOrEmpty(ctdcbd.DinhMucHN_BD.ToString()))
                                                {
                                                    _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set DINHMUCHN=" + ctdcbd.DinhMucHN_BD.Value.ToString() + " where DANHBO='" + ctdcbd.DanhBo + "'");
                                                }
                                                if (!string.IsNullOrEmpty(ctdcbd.GiaBieu_BD.ToString()))
                                                {
                                                    _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set GIABIEU=" + ctdcbd.GiaBieu_BD.Value.ToString() + " where DANHBO='" + ctdcbd.DanhBo + "'");
                                                }
                                                if (!string.IsNullOrEmpty(ctdcbd.HoTen_BD))
                                                {
                                                    _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set HOTEN=N'" + ctdcbd.HoTen_BD.ToString().Replace("'", "") + "' where DANHBO='" + ctdcbd.DanhBo + "'");
                                                }
                                                if (!string.IsNullOrEmpty(ctdcbd.DiaChi_BD))
                                                {
                                                    _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set DiaChiHoaDon=N'" + ctdcbd.DiaChi_BD + "',SOHO=SONHA+' '+TENDUONG,SONHA=N'" + ctdcbd.DiaChi_BD.Substring(0, ctdcbd.DiaChi_BD.IndexOf(" ")) + "',TENDUONG=N'" + ctdcbd.DiaChi_BD.Substring((ctdcbd.DiaChi_BD.IndexOf(" ") + 1), ctdcbd.DiaChi_BD.Length - ctdcbd.DiaChi_BD.IndexOf(" ") - 1) + "' where DANHBO='" + ctdcbd.DanhBo + "'");
                                                }
                                                if (!string.IsNullOrEmpty(ctdcbd.MSThue_BD))
                                                {
                                                    _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set MSTHUE='" + ctdcbd.MSThue_BD.ToString() + "' where DANHBO='" + ctdcbd.DanhBo + "'");
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
                                                if (!string.IsNullOrEmpty(ctdcbd.DinhMucHN_BD.ToString()))
                                                {
                                                    ghichu.NOIDUNG += " Định Mức Hộ Nghèo Từ " + ctdcbd.DinhMucHN + " -> " + ctdcbd.DinhMucHN_BD + ",";
                                                }

                                                string sqlGhiChu = "insert into TB_GHICHU(DANHBO,DONVI,NOIDUNG,CREATEDATE,CREATEBY)values('" + ghichu.DANHBO + "','" + ghichu.DONVI + "',N'" + ghichu.NOIDUNG + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',N'" + CTaiKhoan.HoTen + "')";
                                                if (_cDocSo.LinQ_ExecuteNonQuery(sqlGhiChu))
                                                {
                                                    ctdcbd.ChuyenDocSo = true;
                                                    ctdcbd.NgayChuyenDocSo = DateTime.Now;
                                                    ctdcbd.NguoiChuyenDocSo = CTaiKhoan.MaUser;
                                                    _cDCBD.SuaDCBD(ctdcbd);
                                                    //scope.Complete();
                                                }

                                                //log.WriteLine(k.ToString() + "/ " + ctdcbd.MaCTDCBD + " ; " + ctdcbd.ThongTin + " ; " + ctdcbd.DanhBo + " ");
                                                //k++;
                                            }
                                            //else
                                            //    MessageBox.Show("Danh Bộ: " + ctdcbd.DanhBo + " thuộc Số Phiếu: " + ctdcbd.MaCTDCBD.ToString().Insert(ctdcbd.MaCTDCBD.ToString().Length - 2, "-")
                                            //        + " không có bên QLĐHN", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                //DSDCBD_BS.DataSource = _cDCBD.LoadDSCTDCBD();
                                //log.WriteLine("=============================================");
                                //log.Close();
                                //log.Dispose();
                                MessageBox.Show("Cập Nhật Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                //    log.WriteLine("=============================================");
                                //    log.Close();
                                //    log.Dispose();
                                //    MessageBox.Show("Lỗi tại Số Phiếu: " + dgvDSDCBD["SoPhieu", k].Value.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MessageBox.Show(ex.Message + " " + k, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnThuHoiCapNhatDocSo_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (MessageBox.Show("Bạn chắc chắn Thu Hồi Cập Nhật Đọc Số những Phiếu trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        if (radDSDCBD.Checked)
                        {
                            for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                                if (bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true && bool.Parse(dgvDSDCBD["PhieuDuocKy", i].Value.ToString()) == true && bool.Parse(dgvDSDCBD["ChuyenDocSo", i].Value.ToString()) == true)
                                //using (var scope = new TransactionScope())
                                {
                                    DCBD_ChiTietBienDong ctdcbd = new DCBD_ChiTietBienDong();
                                    ctdcbd = _cDCBD.getBienDong(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));

                                    if (ctdcbd != null)
                                    {
                                        if (_cDocSo.CheckExist(ctdcbd.DanhBo) && !string.IsNullOrEmpty(ctdcbd.ThongTin))
                                        {
                                            if (!string.IsNullOrEmpty(ctdcbd.DinhMuc_BD.ToString()))
                                            {
                                                _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set DINHMUC=" + ctdcbd.DinhMuc.Value.ToString() + " where DANHBO='" + ctdcbd.DanhBo + "'");
                                            }
                                            if (!string.IsNullOrEmpty(ctdcbd.DinhMucHN_BD.ToString()))
                                            {
                                                _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set DINHMUCHN=" + ctdcbd.DinhMucHN.Value.ToString() + " where DANHBO='" + ctdcbd.DanhBo + "'");
                                            }
                                            if (!string.IsNullOrEmpty(ctdcbd.GiaBieu_BD.ToString()))
                                            {
                                                _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set GIABIEU=" + ctdcbd.GiaBieu.Value.ToString() + " where DANHBO='" + ctdcbd.DanhBo + "'");
                                            }
                                            if (!string.IsNullOrEmpty(ctdcbd.HoTen_BD))
                                            {
                                                _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set HOTEN=N'" + ctdcbd.HoTen.ToString().Replace("'", "") + "' where DANHBO='" + ctdcbd.DanhBo + "'");
                                            }
                                            if (!string.IsNullOrEmpty(ctdcbd.DiaChi_BD))
                                            {
                                                _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set DiaChiHoaDon=N'" + ctdcbd.DiaChi + "',SONHA=N'" + ctdcbd.DiaChi.Substring(0, ctdcbd.DiaChi.IndexOf(" ")) + "',TENDUONG=N'" + ctdcbd.DiaChi.Substring((ctdcbd.DiaChi.IndexOf(" ") + 1), ctdcbd.DiaChi.Length - ctdcbd.DiaChi.IndexOf(" ") - 1) + "' where DANHBO='" + ctdcbd.DanhBo + "'");
                                            }
                                            if (!string.IsNullOrEmpty(ctdcbd.MSThue_BD))
                                            {
                                                _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set MSTHUE='" + ctdcbd.MSThue.ToString() + "' where DANHBO='" + ctdcbd.DanhBo + "'");
                                            }

                                            string sqlGhiChu = "delete from TB_GHICHU where DONVI='KTKS' and DANHBO='" + ctdcbd.DanhBo + "' and NOIDUNG like 'PYC: " + ctdcbd.MaCTDCBD.ToString().Insert(ctdcbd.MaCTDCBD.ToString().Length - 2, "-") + "%'";
                                            if (_cDocSo.LinQ_ExecuteNonQuery(sqlGhiChu))
                                            {
                                                ctdcbd.ChuyenDocSo = false;
                                                ctdcbd.NgayChuyenDocSo = null;
                                                ctdcbd.NguoiChuyenDocSo = null;
                                                ctdcbd.PhieuDuocKy = false;
                                                _cDCBD.SuaDCBD(ctdcbd);
                                                //scope.Complete();
                                            }
                                        }
                                    }
                                }
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnInDSPhieu_Click(object sender, EventArgs e)
        {
            if (radDSDCBD.Checked)
            {
                if (MessageBox.Show("Bạn chắc chắn In Danh Sách Phiếu điều chỉnh Giá Biểu, Định Mức?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataSetBaoCao dsBaoCaoHN = new DataSetBaoCao();
                    DataSetBaoCao dsBaoCaoDC = new DataSetBaoCao();
                    for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                        if (dgvDSDCBD["In", i].Value != null && bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true)
                        {
                            DCBD_ChiTietBienDong ctdcbd = _cDCBD.getBienDong(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));
                            if (ctdcbd.ThongTin.Contains("Giá Biểu"))
                            {
                                DataRow dr = dsBaoCaoHN.Tables["DCBD"].NewRow();

                                dr["ThongTin"] = ctdcbd.ThongTin;
                                dr["Dot"] = ctdcbd.Dot;
                                dr["HieuLucKy"] = ctdcbd.HieuLucKy;
                                dr["DanhBo"] = ctdcbd.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["HopDong"] = ctdcbd.HopDong;
                                dr["HoTen"] = ctdcbd.HoTen;
                                dr["DiaChi"] = ctdcbd.DiaChi;
                                dr["GiaBieu"] = ctdcbd.GiaBieu;
                                dr["DinhMucHN"] = ctdcbd.DinhMucHN;
                                dr["DinhMuc"] = ctdcbd.DinhMuc;
                                ///Biến Động
                                dr["GiaBieuBD"] = ctdcbd.GiaBieu_BD;
                                dr["DinhMucHNBD"] = ctdcbd.DinhMucHN_BD;
                                dr["DinhMucBD"] = ctdcbd.DinhMuc_BD;
                                ///Ký Tên
                                dr["ChucVu"] = ctdcbd.ChucVu;
                                dr["NguoiKy"] = ctdcbd.NguoiKy;

                                dsBaoCaoHN.Tables["DCBD"].Rows.Add(dr);
                            }
                            else
                                if (ctdcbd.ThongTin.Contains("Định Mức"))
                                {
                                    DataRow dr = dsBaoCaoDC.Tables["DCBD"].NewRow();

                                    dr["ThongTin"] = ctdcbd.ThongTin;
                                    dr["Dot"] = ctdcbd.Dot;
                                    dr["HieuLucKy"] = ctdcbd.HieuLucKy;
                                    dr["DanhBo"] = ctdcbd.DanhBo.Insert(7, " ").Insert(4, " ");
                                    dr["HopDong"] = ctdcbd.HopDong;
                                    dr["HoTen"] = ctdcbd.HoTen;
                                    dr["DiaChi"] = ctdcbd.DiaChi;
                                    dr["GiaBieu"] = ctdcbd.GiaBieu;
                                    dr["DinhMucHN"] = ctdcbd.DinhMucHN;
                                    dr["DinhMuc"] = ctdcbd.DinhMuc;
                                    ///Biến Động
                                    dr["GiaBieuBD"] = ctdcbd.GiaBieu_BD;
                                    dr["DinhMucHNBD"] = ctdcbd.DinhMucHN_BD;
                                    dr["DinhMucBD"] = ctdcbd.DinhMuc_BD;
                                    ///Ký Tên
                                    dr["ChucVu"] = ctdcbd.ChucVu;
                                    dr["NguoiKy"] = ctdcbd.NguoiKy;

                                    dsBaoCaoDC.Tables["DCBD"].Rows.Add(dr);
                                }
                        }
                    rptDSPhieuDCBD_HN rpt = new rptDSPhieuDCBD_HN();
                    rpt.SetDataSource(dsBaoCaoHN);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.Show();
                    rptDSPhieuDCBD_DC rpt2 = new rptDSPhieuDCBD_DC();
                    rpt2.SetDataSource(dsBaoCaoDC);
                    frmShowBaoCao frm2 = new frmShowBaoCao(rpt2);
                    frm2.Show();
                }
            }
            else
                if (radDSDCHD.Checked)
                {
                    DataSetBaoCao dsBaoCao_SoTien = new DataSetBaoCao();
                    DataSetBaoCao dsBaoCao_SoTien_BaoCaoThue = new DataSetBaoCao();
                    DataSetBaoCao dsBaoCao_ThongTin = new DataSetBaoCao();
                    DataSetBaoCao dsBaoCao_KhauTru = new DataSetBaoCao();
                    for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                        if (dgvDSDCBD["In", i].Value != null && bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true)
                        {
                            DCBD_ChiTietHoaDon ctdchd = _cDCBD.getHoaDon(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));

                            if (ctdchd.KhauTru == false)
                            {
                                if ((ctdchd.HoTen_BD == null && ctdchd.DiaChi_BD == null) || (ctdchd.HoTen_BD == "" && ctdchd.DiaChi_BD == ""))
                                {
                                    DataRow dr = dsBaoCao_SoTien.Tables["DCHD"].NewRow();
                                    DataRow dr_BCT = dsBaoCao_SoTien_BaoCaoThue.Tables["DCHD"].NewRow();

                                    dr_BCT["MaDon"] = dr["MaDon"] = ctdchd.MaCTDCHD.ToString();
                                    dr_BCT["SoPhieu"] = dr["SoPhieu"] = ctdchd.MaCTDCHD.ToString().Insert(ctdchd.MaCTDCHD.ToString().Length - 2, "-");
                                    dr_BCT["DanhBo"] = dr["DanhBo"] = ctdchd.DanhBo;

                                    if (ctdchd.Dot != null)
                                        dr_BCT["KyHD"] = dr["KyHD"] = ctdchd.Dot.Value.ToString("00") + "/" + ctdchd.KyHD;
                                    else
                                        dr_BCT["KyHD"] = dr["KyHD"] = ctdchd.KyHD;
                                    dr_BCT["SoHD"] = dr["SoHD"] = ctdchd.SoHD;
                                    ///
                                    if (ctdchd.GiaBieu.Value != ctdchd.GiaBieu_BD.Value)
                                    {
                                        dr_BCT["GiaBieuStart"] = dr["GiaBieuStart"] = ctdchd.GiaBieu;
                                        dr_BCT["GiaBieuEnd"] = dr["GiaBieuEnd"] = ctdchd.GiaBieu_BD;
                                    }
                                    if (ctdchd.DinhMuc.Value != ctdchd.DinhMuc_BD.Value)
                                    {
                                        dr_BCT["DinhMucStart"] = dr["DinhMucStart"] = ctdchd.DinhMuc;
                                        dr_BCT["DinhMucEnd"] = dr["DinhMucEnd"] = ctdchd.DinhMuc_BD;
                                    }
                                    if (ctdchd.TieuThu.Value != ctdchd.TieuThu_BD.Value)
                                    {
                                        dr_BCT["TieuThuStart"] = dr["TieuThuStart"] = ctdchd.TieuThu;
                                        dr_BCT["TieuThuEnd"] = dr["TieuThuEnd"] = ctdchd.TieuThu_BD;
                                    }

                                    if (ctdchd.TienNuoc_Start == 0)
                                        dr_BCT["TienNuocStart"] = dr["TienNuocStart"] = 0;
                                    else
                                        dr_BCT["TienNuocStart"] = dr["TienNuocStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TienNuoc_Start);
                                    if (ctdchd.ThueGTGT_Start == 0)
                                        dr_BCT["ThueGTGTStart"] = dr["ThueGTGTStart"] = 0;
                                    else
                                        dr_BCT["ThueGTGTStart"] = dr["ThueGTGTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.ThueGTGT_Start);
                                    if (ctdchd.PhiBVMT_Start == 0)
                                        dr_BCT["PhiBVMTStart"] = dr["PhiBVMTStart"] = 0;
                                    else
                                        dr_BCT["PhiBVMTStart"] = dr["PhiBVMTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_Start);
                                    if (ctdchd.TongCong_Start == 0)
                                        dr_BCT["TongCongStart"] = dr["TongCongStart"] = 0;
                                    else
                                        dr_BCT["TongCongStart"] = dr["TongCongStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_Start);
                                    ///
                                    ///
                                    if (ctdchd.TienNuoc_BD == 0)
                                        dr_BCT["TienNuocBD"] = dr["TienNuocBD"] = 0;
                                    else
                                        dr_BCT["TienNuocBD"] = dr["TienNuocBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TienNuoc_BD);
                                    if (ctdchd.ThueGTGT_BD == 0)
                                        dr_BCT["ThueGTGTBD"] = dr["ThueGTGTBD"] = 0;
                                    else
                                        dr_BCT["ThueGTGTBD"] = dr["ThueGTGTBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.ThueGTGT_BD);
                                    if (ctdchd.PhiBVMT_BD == 0)
                                        dr_BCT["PhiBVMTBD"] = dr["PhiBVMTBD"] = 0;
                                    else
                                        dr_BCT["PhiBVMTBD"] = dr["PhiBVMTBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_BD);
                                    if (ctdchd.TongCong_BD == 0)
                                        dr_BCT["TongCongBD"] = dr["TongCongBD"] = 0;
                                    else
                                        dr_BCT["TongCongBD"] = dr["TongCongBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_BD);
                                    ///

                                    if (ctdchd.TienNuoc_End == 0)
                                        dr_BCT["TienNuocEnd"] = dr["TienNuocEnd"] = 0;
                                    else
                                        dr_BCT["TienNuocEnd"] = dr["TienNuocEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TienNuoc_End);
                                    if (ctdchd.ThueGTGT_End == 0)
                                        dr_BCT["ThueGTGTEnd"] = dr["ThueGTGTEnd"] = 0;
                                    else
                                        dr_BCT["ThueGTGTEnd"] = dr["ThueGTGTEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.ThueGTGT_End);
                                    if (ctdchd.PhiBVMT_End == 0)
                                        dr_BCT["PhiBVMTEnd"] = dr["PhiBVMTEnd"] = 0;
                                    else
                                        dr_BCT["PhiBVMTEnd"] = dr["PhiBVMTEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_End);
                                    if (ctdchd.TongCong_End == 0)
                                        dr_BCT["TongCongEnd"] = dr["TongCongEnd"] = 0;
                                    else
                                        dr_BCT["TongCongEnd"] = dr["TongCongEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_End);

                                    if (ctdchd.MaToTrinh != null)
                                        dr_BCT["MaToTrinh"] = dr["MaToTrinh"] = ctdchd.MaToTrinh.Value.ToString().Insert(ctdchd.MaToTrinh.Value.ToString().Length - 2, "-");
                                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                        dr_BCT["ChucVu"] = dr["ChucVu"] = "GIÁM ĐỐC";
                                    else
                                        dr_BCT["ChucVu"] = dr["ChucVu"] = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                    dr_BCT["NguoiKy"] = dr["NguoiKy"] = bangiamdoc.HoTen.ToUpper();
                                    if (ctdchd.BaoCaoThue == true)
                                        dsBaoCao_SoTien_BaoCaoThue.Tables["DCHD"].Rows.Add(dr_BCT);
                                    else
                                        dsBaoCao_SoTien.Tables["DCHD"].Rows.Add(dr);
                                }
                                else
                                {
                                    DataRow dr = dsBaoCao_ThongTin.Tables["DCHD"].NewRow();

                                    dr["MaDon"] = ctdchd.MaCTDCHD.ToString();
                                    dr["SoPhieu"] = ctdchd.MaCTDCHD.ToString().Insert(ctdchd.MaCTDCHD.ToString().Length - 2, "-");
                                    dr["DanhBo"] = ctdchd.DanhBo;

                                    if (ctdchd.Dot != null)
                                        dr["KyHD"] = ctdchd.Dot.Value.ToString("00") + "/" + ctdchd.KyHD;
                                    else
                                        dr["KyHD"] = ctdchd.KyHD;
                                    dr["SoHD"] = ctdchd.SoHD;
                                    ///
                                    if (ctdchd.HoTen_BD != null && ctdchd.HoTen_BD != "")
                                    {
                                        dr["HoTen"] = ctdchd.HoTen;
                                        dr["HoTenBD"] = ctdchd.HoTen_BD;
                                    }
                                    if (ctdchd.DiaChi_BD != null && ctdchd.DiaChi_BD != "")
                                    {
                                        dr["DiaChi"] = ctdchd.DiaChi;
                                        dr["DiaChiBD"] = ctdchd.DiaChi_BD;
                                    }
                                    if (ctdchd.MST_BD != null && ctdchd.MST_BD != "")
                                    {
                                        dr["MST"] = ctdchd.MST;
                                        dr["MSTBD"] = ctdchd.MST_BD;
                                    }
                                    //
                                    //if (ctdchd.GiaBieu.Value != ctdchd.GiaBieu_BD.Value)
                                    //{
                                    //    dr["GiaBieuStart"] = ctdchd.GiaBieu;
                                    //    dr["GiaBieuEnd"] = ctdchd.GiaBieu_BD;
                                    //}
                                    //if (ctdchd.DinhMuc.Value != ctdchd.DinhMuc_BD.Value)
                                    //{
                                    //    dr["DinhMucStart"] = ctdchd.DinhMuc;
                                    //    dr["DinhMucEnd"] = ctdchd.DinhMuc_BD;
                                    //}
                                    //if (ctdchd.TieuThu.Value != ctdchd.TieuThu_BD.Value)
                                    //{
                                    //    dr["TieuThuStart"] = ctdchd.TieuThu;
                                    //    dr["TieuThuEnd"] = ctdchd.TieuThu_BD;
                                    //}

                                    //if (ctdchd.TienNuoc_Start == 0)
                                    //    dr["TienNuocStart"] = 0;
                                    //else
                                    //    dr["TienNuocStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TienNuoc_Start);
                                    //if (ctdchd.ThueGTGT_Start == 0)
                                    //    dr["ThueGTGTStart"] = 0;
                                    //else
                                    //    dr["ThueGTGTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.ThueGTGT_Start);
                                    //if (ctdchd.PhiBVMT_Start == 0)
                                    //    dr["PhiBVMTStart"] = 0;
                                    //else
                                    //    dr["PhiBVMTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_Start);
                                    //if (ctdchd.TongCong_Start == 0)
                                    //    dr["TongCongStart"] = 0;
                                    //else
                                    //    dr["TongCongStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_Start);
                                    /////
                                    /////
                                    //if (ctdchd.TienNuoc_BD == 0)
                                    //    dr["TienNuocBD"] = 0;
                                    //else
                                    //    dr["TienNuocBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TienNuoc_BD);
                                    //if (ctdchd.ThueGTGT_BD == 0)
                                    //    dr["ThueGTGTBD"] = 0;
                                    //else
                                    //    dr["ThueGTGTBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.ThueGTGT_BD);
                                    //if (ctdchd.PhiBVMT_BD == 0)
                                    //    dr["PhiBVMTBD"] = 0;
                                    //else
                                    //    dr["PhiBVMTBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_BD);
                                    //if (ctdchd.TongCong_BD == 0)
                                    //    dr["TongCongBD"] = 0;
                                    //else
                                    //    dr["TongCongBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_BD);
                                    /////

                                    //if (ctdchd.TienNuoc_End == 0)
                                    //    dr["TienNuocEnd"] = 0;
                                    //else
                                    //    dr["TienNuocEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TienNuoc_End);
                                    //if (ctdchd.ThueGTGT_End == 0)
                                    //    dr["ThueGTGTEnd"] = 0;
                                    //else
                                    //    dr["ThueGTGTEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.ThueGTGT_End);
                                    //if (ctdchd.PhiBVMT_End == 0)
                                    //    dr["PhiBVMTEnd"] = 0;
                                    //else
                                    //    dr["PhiBVMTEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_End);
                                    //if (ctdchd.TongCong_End == 0)
                                    //    dr["TongCongEnd"] = 0;
                                    //else
                                    //    dr["TongCongEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_End);

                                    if (ctdchd.MaToTrinh != null)
                                        dr["MaToTrinh"] = ctdchd.MaToTrinh.Value.ToString().Insert(ctdchd.MaToTrinh.Value.ToString().Length - 2, "-");
                                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                        dr["ChucVu"] = "GIÁM ĐỐC";
                                    else
                                        dr["ChucVu"] = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                    dr["NguoiKy"] = bangiamdoc.HoTen.ToUpper();
                                    dsBaoCao_ThongTin.Tables["DCHD"].Rows.Add(dr);
                                }
                            }
                            else
                            {
                                DataRow dr = dsBaoCao_KhauTru.Tables["DCHD"].NewRow();

                                dr["MaDon"] = ctdchd.MaCTDCHD.ToString();
                                dr["SoPhieu"] = ctdchd.MaCTDCHD.ToString().Insert(ctdchd.MaCTDCHD.ToString().Length - 2, "-");
                                dr["DanhBo"] = ctdchd.DanhBo;

                                if (ctdchd.Dot != null)
                                    dr["KyHD"] = ctdchd.Dot.Value.ToString("00") + "/" + ctdchd.KyHD;
                                else
                                    dr["KyHD"] = ctdchd.KyHD;
                                dr["SoHD"] = ctdchd.SoHD;
                                ///
                                if (ctdchd.GiaBieu.Value != ctdchd.GiaBieu_BD.Value)
                                {
                                    dr["GiaBieuStart"] = ctdchd.GiaBieu;
                                    dr["GiaBieuEnd"] = ctdchd.GiaBieu_BD;
                                }
                                if (ctdchd.DinhMuc.Value != ctdchd.DinhMuc_BD.Value)
                                {
                                    dr["DinhMucStart"] = ctdchd.DinhMuc;
                                    dr["DinhMucEnd"] = ctdchd.DinhMuc_BD;
                                }
                                if (ctdchd.TieuThu.Value != ctdchd.TieuThu_BD.Value)
                                {
                                    dr["TieuThuStart"] = ctdchd.TieuThu;
                                    dr["TieuThuEnd"] = ctdchd.TieuThu_BD;
                                }

                                if (ctdchd.TienNuoc_Start == 0)
                                    dr["TienNuocStart"] = 0;
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
                                ///
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

                                if (ctdchd.MaToTrinh != null)
                                    dr["MaToTrinh"] = ctdchd.MaToTrinh.Value.ToString().Insert(ctdchd.MaToTrinh.Value.ToString().Length - 2, "-");
                                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                    dr["ChucVu"] = "GIÁM ĐỐC";
                                else
                                    dr["ChucVu"] = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                dr["NguoiKy"] = bangiamdoc.HoTen.ToUpper();
                                dsBaoCao_KhauTru.Tables["DCHD"].Rows.Add(dr);
                            }
                        }
                    if (dsBaoCao_SoTien.Tables["DCHD"].Rows.Count > 0)
                    {
                        rptDSPhieuDCBD_HDDT_SoTien rpt = new rptDSPhieuDCBD_HDDT_SoTien();
                        rpt.SetDataSource(dsBaoCao_SoTien);
                        frmShowBaoCao frm = new frmShowBaoCao(rpt);
                        frm.Show();
                    }
                    if (dsBaoCao_SoTien_BaoCaoThue.Tables["DCHD"].Rows.Count > 0)
                    {
                        rptDSPhieuDCBD_HDDT_SoTien_BaoCaoThue rpt = new rptDSPhieuDCBD_HDDT_SoTien_BaoCaoThue();
                        rpt.SetDataSource(dsBaoCao_SoTien_BaoCaoThue);
                        frmShowBaoCao frm = new frmShowBaoCao(rpt);
                        frm.Show();
                    }
                    if (dsBaoCao_ThongTin.Tables["DCHD"].Rows.Count > 0)
                    {
                        rptDSPhieuDCBD_HDDT_ThongTin rpt = new rptDSPhieuDCBD_HDDT_ThongTin();
                        rpt.SetDataSource(dsBaoCao_ThongTin);
                        frmShowBaoCao frm = new frmShowBaoCao(rpt);
                        frm.Show();
                    }
                    if (dsBaoCao_KhauTru.Tables["DCHD"].Rows.Count > 0)
                    {
                        rptDSPhieuDCBD_HDDT_KhauTru rpt = new rptDSPhieuDCBD_HDDT_KhauTru();
                        rpt.SetDataSource(dsBaoCao_KhauTru);
                        frmShowBaoCao frm = new frmShowBaoCao(rpt);
                        frm.Show();
                    }

                }
                else
                    if (radDSCatChuyenDM.Checked)
                    {
                        if (MessageBox.Show("Bạn chắc chắn In những Phiếu Cắt Chuyển trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                            for (int i = 0; i < dgvDSCatChuyenDM.Rows.Count; i++)
                                if (dgvDSCatChuyenDM["In_CC", i].Value != null && bool.Parse(dgvDSCatChuyenDM["In_CC", i].Value.ToString()) == true)
                                {
                                    ChungTu_LichSu lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(decimal.Parse(dgvDSCatChuyenDM["SoPhieu_CC", i].Value.ToString()));
                                    if (lichsuchungtu.YeuCauCat)
                                    {
                                        DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                        dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;
                                        if (lichsuchungtu.MaDonMoi != null)
                                        {
                                            LinQ.DonTu en = _cDonTu.get(lichsuchungtu.MaDonMoi.Value);
                                            if (en.DonTu_ChiTiets.Count == 1)
                                                dr["MaDon"] = lichsuchungtu.MaDonMoi.ToString();
                                            else
                                                dr["MaDon"] = lichsuchungtu.MaDonMoi.ToString() + "." + lichsuchungtu.STT.Value.ToString();
                                        }
                                        else
                                            if (lichsuchungtu.MaDon != null)
                                                dr["MaDon"] = "TKH" + lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");
                                            else
                                                if (lichsuchungtu.MaDonTXL != null)
                                                    dr["MaDon"] = "TXL" + lichsuchungtu.MaDonTXL.ToString().Insert(lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                                else
                                                    if (lichsuchungtu.MaDonTBC != null)
                                                        dr["MaDon"] = "TBC" + lichsuchungtu.MaDonTBC.ToString().Insert(lichsuchungtu.MaDonTBC.ToString().Length - 2, "-");

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
                                        dr["SoNKCat"] = lichsuchungtu.SoNK.ToString() + " nhân khẩu (" + _cLoaiChungTu.GetKyHieu(lichsuchungtu.MaLCT.Value) + ": " + lichsuchungtu.MaCT + ")";
                                        dr["HoTensCat"] = lichsuchungtu.CatNK_HoTens;

                                        dr["ChucVu"] = lichsuchungtu.ChucVu;
                                        dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                        dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);
                                    }
                                    else
                                        if (lichsuchungtu.CatDM)
                                        {
                                            DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                            dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;
                                            if (lichsuchungtu.MaDonMoi != null)
                                            {
                                                LinQ.DonTu en = _cDonTu.get(lichsuchungtu.MaDonMoi.Value);
                                                if (en.DonTu_ChiTiets.Count == 1)
                                                    dr["MaDon"] = lichsuchungtu.MaDonMoi.ToString();
                                                else
                                                    dr["MaDon"] = lichsuchungtu.MaDonMoi.ToString() + "." + lichsuchungtu.STT.Value.ToString();
                                            }
                                            else
                                                if (lichsuchungtu.MaDon != null)
                                                    dr["MaDon"] = "TKH" + lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");
                                                else
                                                    if (lichsuchungtu.MaDonTXL != null)
                                                        dr["MaDon"] = "TXL" + lichsuchungtu.MaDonTXL.ToString().Insert(lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                                    else
                                                        if (lichsuchungtu.MaDonTBC != null)
                                                            dr["MaDon"] = "TBC" + lichsuchungtu.MaDonTBC.ToString().Insert(lichsuchungtu.MaDonTBC.ToString().Length - 2, "-");

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
                                            ///có thể sai MaCT, nếu sai đổi lại lấy txtMaCT
                                            dr["SoNKCat"] = lichsuchungtu.SoNK.ToString() + " nhân khẩu (" + _cLoaiChungTu.GetKyHieu(lichsuchungtu.MaLCT.Value) + ": " + lichsuchungtu.MaCT + ")";
                                            dr["HoTensCat"] = lichsuchungtu.CatNK_HoTens;

                                            dr["ChucVu"] = lichsuchungtu.ChucVu;
                                            dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                            dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);
                                        }
                                }
                            DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                            drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                            dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(drLogo);

                            rptDSPhieuCatChuyen rpt = new rptDSPhieuCatChuyen();
                            rpt.SetDataSource(dsBaoCao);
                            rpt.Subreports[0].SetDataSource(dsBaoCao);
                            frmShowBaoCao frm = new frmShowBaoCao(rpt);
                            frm.ShowDialog();
                        }
                    }
        }

        private void btnInA4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn In những Phiếu trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //PrintDialog printDialog = new PrintDialog();
                //if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    if (radDSDCHD.Checked)
                    {
                        for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                            if (dgvDSDCBD["In", i].Value != null && bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true)
                            {
                                //DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();

                                DCBD_ChiTietHoaDon ctdchd = _cDCBD.getHoaDon(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));

                                //if (ctdchd.DCBD.MaDonMoi != null)
                                //    dr["MaDon"] = ctdchd.DCBD.MaDonMoi.Value.ToString();
                                //else
                                //if (ctdchd.DCBD.MaDon != null)
                                //    dr["MaDon"] = ctdchd.DCBD.MaDon.Value.ToString().Insert(ctdchd.DCBD.MaDon.Value.ToString().Length - 2, "-");
                                //else
                                //    if (ctdchd.DCBD.MaDonTXL != null)
                                //        dr["MaDon"] = "TXL" + ctdchd.DCBD.MaDonTXL.Value.ToString().Insert(ctdchd.DCBD.MaDonTXL.Value.ToString().Length - 2, "-");
                                //    else
                                //        if (ctdchd.DCBD.MaDonTBC != null)
                                //            dr["MaDon"] = "TBC" + ctdchd.DCBD.MaDonTBC.Value.ToString().Insert(ctdchd.DCBD.MaDonTBC.Value.ToString().Length - 2, "-");
                                dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;
                                dr["MaDon"] = ctdchd.MaCTDCHD.ToString().Insert(ctdchd.MaCTDCHD.ToString().Length - 2, "-");
                                dr["SoPhieu"] = "_________";
                                dr["DanhBo"] = ctdchd.DanhBo.Insert(7, " ").Insert(4, " "); ;
                                dr["MLT"] = ctdchd.MLT.Insert(4, " ").Insert(2, " ");
                                dr["HoTen"] = ctdchd.HoTen;
                                dr["DiaChi"] = ctdchd.DiaChi;
                                dr["SoVanBan"] = ctdchd.SoVB;
                                dr["NgayVanBan"] = ctdchd.NgayKy.Value.ToString("dd/MM/yyyy");
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
                                                    dr["DieuChinh"] = ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + (ctdchd.GiaDieuChinh.Value - ctdchd.GiaDieuChinh.Value * _cGiaNuoc.GiamTienNuoc / 100).ToString();
                                                else
                                                    dr["DieuChinh"] = ctdchd.DinhMuc_BD + "m3 Áp giá " + (_lstGiaNuoc[0].DonGia.Value - _lstGiaNuoc[0].DonGia.Value * _cGiaNuoc.GiamTienNuoc / 100).ToString() + ", " + ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + (ctdchd.GiaDieuChinh.Value - ctdchd.GiaDieuChinh.Value * _cGiaNuoc.GiamTienNuoc / 100).ToString();
                                            else
                                                if (ctdchd.TieuThu_DieuChinhGia == ctdchd.TieuThu_BD)
                                                    dr["DieuChinh"] = dr["DieuChinh"] + ", " + ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + (ctdchd.GiaDieuChinh.Value - ctdchd.GiaDieuChinh.Value * _cGiaNuoc.GiamTienNuoc / 100).ToString();
                                                else
                                                    dr["DieuChinh"] = dr["DieuChinh"] + ", " + ctdchd.DinhMuc_BD + "m3 Áp giá " + (_lstGiaNuoc[0].DonGia.Value - _lstGiaNuoc[0].DonGia.Value * _cGiaNuoc.GiamTienNuoc / 100).ToString() + ", " + ctdchd.TieuThu_DieuChinhGia + "m3 Áp giá " + (ctdchd.GiaDieuChinh.Value - ctdchd.GiaDieuChinh.Value * _cGiaNuoc.GiamTienNuoc / 100).ToString();
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
                                }
                                if (ctdchd.KhuCongNghiep == true)
                                {
                                    if (string.IsNullOrEmpty(dr["DieuChinh"].ToString()))
                                        dr["DieuChinh"] = "Sản lượng vượt so với Sản lượng Tiêu Thụ Bình Quân (" + Math.Round(ctdchd.TyLeKhuCongNghiep.Value, 2) + "%)";
                                    else
                                        dr["DieuChinh"] = dr["DieuChinh"] + ", Sản lượng vượt so với Sản lượng Tiêu Thụ Bình Quân (" + Math.Round(ctdchd.TyLeKhuCongNghiep.Value, 2) + "%)";
                                }
                                dr["ChiTietCu"] = ctdchd.ChiTietCu;
                                dr["ChiTietMoi"] = ctdchd.ChiTietMoi;
                                ///
                                dr["GiaBieuStart"] = ctdchd.GiaBieu;
                                dr["GiaBieuEnd"] = ctdchd.GiaBieu_BD;
                                dr["DinhMucStart"] = ctdchd.DinhMuc;
                                dr["DinhMucEnd"] = ctdchd.DinhMuc_BD;
                                dr["TieuThuStart"] = ctdchd.TieuThu;
                                if (ctdchd.TienNuoc_Start == 0)
                                    dr["TienNuocStart"] = 0;
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

                                //if (ctdchd.KhuCongNghiep == true)
                                //{
                                dr["ChucVu"] = ctdchd.ChucVu;
                                dr["NguoiKy"] = ctdchd.NguoiKy;
                                //}

                                dsBaoCao.Tables["DCHD"].Rows.Add(dr);

                                //ReportDocument rpt;
                                ////if (ctdchd.KhuCongNghiep == true)
                                ////{
                                //rpt = new rptThongBaoDCHD_ChuKy();
                                ////}
                                ////else
                                ////{
                                ////    rpt = new rptThongBaoDCHD();
                                ////}
                                //rpt.SetDataSource(dsBaoCao);

                                //printDialog.AllowSomePages = true;
                                //printDialog.ShowHelp = true;

                                //rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                //rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                //rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                                //rpt.Clone();
                                //rpt.Dispose();
                            }
                        rptThongBaoDCHD_ChuKy rpt = new rptThongBaoDCHD_ChuKy();
                        frmShowBaoCao frm = new frmShowBaoCao(rpt);
                        frm.Show();
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
                DCBD_ChiTietBienDong ctdcbd = _cDCBD.getBienDong(decimal.Parse(dgvDSDCBD.CurrentRow.Cells["SoPhieu"].Value.ToString()));
                if (ctdcbd.PhieuDuocKy != ischecked)
                {
                    ctdcbd.PhieuDuocKy = ischecked;
                    _cDCBD.SuaDCBD(ctdcbd);
                }
            }
            if (radDSDCHD.Checked)
            {
                bool ischecked = false;
                if (bool.Parse(dgvDSDCBD["PhieuDuocKy", e.RowIndex].Value.ToString()) == true)
                    ischecked = true;
                else
                    ischecked = false;
                DCBD_ChiTietHoaDon ctdchd = _cDCBD.getHoaDon(decimal.Parse(dgvDSDCBD.CurrentRow.Cells["SoPhieu"].Value.ToString()));
                if (ctdchd.PhieuDuocKy != ischecked)
                {
                    ctdchd.PhieuDuocKy = ischecked;
                    _cDCBD.SuaDCHD(ctdchd);
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
                ChungTu_LichSu lichsuchungtu = _cChungTu.getLSCTbyID(decimal.Parse(dgvDSCatChuyenDM.CurrentRow.Cells["MaLSCT"].Value.ToString()));
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
                if (dgvDSCatChuyenDM["Loai_CC", dgvDSCatChuyenDM.CurrentRow.Index].Value.ToString() == "Cắt")
                {
                    frmCatChuyenDM frm = new frmCatChuyenDM(decimal.Parse(dgvDSCatChuyenDM["MaLSCT", dgvDSCatChuyenDM.CurrentRow.Index].Value.ToString()));
                    frm.ShowDialog();
                }
                else
                {
                    ChungTu_LichSu entity = _cChungTu.getLSCTbyID(decimal.Parse(dgvDSCatChuyenDM["MaLSCT", dgvDSCatChuyenDM.CurrentRow.Index].Value.ToString()));
                    frmSoDK frm = new frmSoDK(entity);
                    frm.ShowDialog();
                }
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
                DCBD_ChiTietHoaDon ctdchd = _cDCBD.getHoaDon(decimal.Parse(dgvDSDCBD["SoPhieu", e.RowIndex].Value.ToString()));
                ctdchd.CodeF2 = bool.Parse(dgvDSDCBD["CodeF2", e.RowIndex].Value.ToString());
                _cDCBD.SuaDCHD(ctdchd);
            }
        }

        private void btnInThuBao_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                if (radDSDCBD.Checked)
                {
                    for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                        if (dgvDSDCBD["In", i].Value != null && bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true)
                        {
                            DCBD_ChiTietBienDong ctdcbd = _cDCBD.getBienDong(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));
                            if (ctdcbd.CongDung != null && ctdcbd.CongDung != "")
                            {
                                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                DataRow dr = dsBaoCao.Tables["DCBD"].NewRow();

                                dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;
                                dr["SoPhieu"] = ctdcbd.MaCTDCBD.ToString().Insert(ctdcbd.MaCTDCBD.ToString().Length - 2, "-");
                                dr["HieuLucKy"] = ctdcbd.HieuLucKy;
                                dr["DanhBo"] = ctdcbd.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["HopDong"] = ctdcbd.HopDong;
                                dr["HoTen"] = ctdcbd.HoTen;
                                dr["DiaChi"] = ctdcbd.DiaChi;
                                dr["ThongTin"] = ctdcbd.CongDung;
                                string[] HieuLucKys = ctdcbd.HieuLucKy.Split('/');
                                GiaNuoc2 gn = _cGiaNuoc.getGiaNuoc(int.Parse(HieuLucKys[1]));
                                dr["TienNuocSH"] = gn.SHTM;
                                dr["TienNuocSHVuot1"] = gn.SHVM1;
                                dr["TienNuocSHVuot2"] = gn.SHVM2;
                                dr["TienNuocKDDV"] = gn.KDDV;

                                if (ctdcbd.SH_BD != "")
                                    dr["SH"] = ctdcbd.SH_BD;
                                else
                                    if (ctdcbd.SH != "")
                                        dr["SH"] = ctdcbd.SH;

                                if (ctdcbd.DV_BD != "")
                                    dr["DV"] = ctdcbd.DV_BD;
                                else
                                    if (ctdcbd.DV != "")
                                        dr["DV"] = ctdcbd.DV;

                                if (ctdcbd.DCBD.MaDon != null)
                                    dr["MaDon"] = ctdcbd.DCBD.MaDon.ToString().Insert(ctdcbd.DCBD.MaDon.ToString().Length - 2, "-");
                                else
                                    if (ctdcbd.DCBD.MaDonTXL != null)
                                        dr["MaDon"] = "TXL" + ctdcbd.DCBD.MaDonTXL.ToString().Insert(ctdcbd.DCBD.MaDonTXL.ToString().Length - 2, "-");
                                    else
                                        if (ctdcbd.DCBD.MaDonTBC != null)
                                            dr["MaDon"] = "TBC" + ctdcbd.DCBD.MaDonTBC.ToString().Insert(ctdcbd.DCBD.MaDonTBC.ToString().Length - 2, "-");
                                //if (radTruongPhong.Checked == true)
                                //{
                                //    dr["ChucVu"] = "TRƯỞNG";
                                //    dr["NguoiKy"] = radTruongPhong.Text;
                                //}
                                //else
                                //    if (radPhoPhong.Checked == true)
                                //    {
                                //        dr["ChucVu"] = "PHÓ";
                                //        dr["NguoiKy"] = radPhoPhong.Text;
                                //    }
                                dr["ChucVu"] = CTaiKhoan.ChucVu;
                                dr["NguoiKy"] = CTaiKhoan.NguoiKy;
                                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                                dsBaoCao.Tables["DCBD"].Rows.Add(dr);

                                DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(drLogo);

                                if (ctdcbd.GiaBieu == 68 || ctdcbd.GiaBieu_BD == 68)
                                {
                                    rptThuBaoDCBD_ChungCu rpt = new rptThuBaoDCBD_ChungCu();
                                    rpt.SetDataSource(dsBaoCao);
                                    rpt.Subreports[0].SetDataSource(dsBaoCao);
                                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                                    frm.Show();
                                    //printDialog.AllowSomePages = true;
                                    //printDialog.ShowHelp = true;

                                    //rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                    //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                    //rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                    //rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                                    //rpt.Clone();
                                    //rpt.Dispose();
                                }
                                else
                                {
                                    rptThuBaoDCBD rpt = new rptThuBaoDCBD();
                                    rpt.SetDataSource(dsBaoCao);
                                    rpt.Subreports[0].SetDataSource(dsBaoCao);
                                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                                    frm.Show();
                                    //printDialog.AllowSomePages = true;
                                    //printDialog.ShowHelp = true;

                                    //rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                    //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                    //rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                    //rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                                    //rpt.Clone();
                                    //rpt.Dispose();
                                }
                            }
                        }
                }
            }
        }

        private void btnInNhan_Click(object sender, EventArgs e)
        {
            if (radDSDCBD.Checked)
            {
                DataSetBaoCao dsBaoCao1 = new DataSetBaoCao();
                DataSetBaoCao dsBaoCao2 = new DataSetBaoCao();
                bool flag = true;///in 2 bên
                ///
                for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                    if (dgvDSDCBD["In", i].Value != null && bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true)
                    {
                        DCBD_ChiTietBienDong ctdcbd = _cDCBD.getBienDong(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));
                        if (ctdcbd.CongDung != null && ctdcbd.CongDung != "")
                        {
                            if (flag == true)
                            {
                                DataRow dr = dsBaoCao1.Tables["ThaoThuTraLoi"].NewRow();

                                dr["HoTen"] = ctdcbd.HoTen;
                                dr["DiaChi"] = ctdcbd.DiaChi;
                                dr["SoPhieu"] = ctdcbd.MaCTDCBD.ToString().Insert(ctdcbd.MaCTDCBD.ToString().Length - 2, "-") + "/TB";

                                dsBaoCao1.Tables["ThaoThuTraLoi"].Rows.Add(dr);
                                flag = false;
                            }
                            else
                            {
                                DataRow dr = dsBaoCao2.Tables["ThaoThuTraLoi"].NewRow();

                                dr["HoTen"] = ctdcbd.HoTen;
                                dr["DiaChi"] = ctdcbd.DiaChi;
                                dr["SoPhieu"] = ctdcbd.MaCTDCBD.ToString().Insert(ctdcbd.MaCTDCBD.ToString().Length - 2, "-") + "/TB";

                                dsBaoCao2.Tables["ThaoThuTraLoi"].Rows.Add(dr);
                                flag = true;
                            }
                        }
                    }
                rptKinhGui rpt = new rptKinhGui();
                rpt.Subreports[0].SetDataSource(dsBaoCao1);
                rpt.Subreports[1].SetDataSource(dsBaoCao2);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void btnExcelHDDT_Click(object sender, EventArgs e)
        {
            try
            {
                if (radDSDCHD.Checked)
                {
                    DataTable dt = new DataTable();
                    for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                        if (dgvDSDCBD["In", i].Value != null && bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true)
                        {
                            dt.Merge(_cDCBD.getHoaDon_DataTable(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString())));
                        }

                    //Tạo các đối tượng Excel
                    Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbooks oBooks;
                    Microsoft.Office.Interop.Excel.Sheets oSheets;
                    Microsoft.Office.Interop.Excel.Workbook oBook;
                    Microsoft.Office.Interop.Excel.Worksheet oSheet;
                    //Microsoft.Office.Interop.Excel.Worksheet oSheetCQ;

                    //Tạo mới một Excel WorkBook 
                    oExcel.Visible = true;
                    oExcel.DisplayAlerts = false;
                    //khai báo số lượng sheet
                    oExcel.Application.SheetsInNewWorkbook = 1;
                    oBooks = oExcel.Workbooks;

                    oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                    oSheets = oBook.Worksheets;
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

                    oSheet.Name = "Sheet1";
                    // Tạo tiêu đề cột 
                    Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
                    cl1.Value2 = "Đợt";
                    cl1.ColumnWidth = 5;

                    Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
                    cl2.Value2 = "Kỳ";
                    cl2.ColumnWidth = 5;

                    Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
                    cl3.Value2 = "Năm";
                    cl3.ColumnWidth = 5;

                    Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
                    cl4.Value2 = "Danh Bộ";
                    cl4.ColumnWidth = 12;

                    Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E1", "E1");
                    cl5.Value2 = "Số Phát Hành";
                    cl5.ColumnWidth = 10;

                    Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F1", "F1");
                    cl6.Value2 = "Số Hóa Đơn Cũ";
                    cl6.ColumnWidth = 15;

                    Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G1", "G1");
                    cl7.Value2 = "Giá Biểu Cũ";
                    cl7.ColumnWidth = 11;

                    Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H1", "H1");
                    cl8.Value2 = "Định Mức Cũ";
                    cl8.ColumnWidth = 11;

                    Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I1", "I1");
                    cl9.Value2 = "Tiêu Thụ Cũ";
                    cl9.ColumnWidth = 11;

                    Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J1", "J1");
                    cl10.Value2 = "Tiền Nước Cũ";
                    cl10.ColumnWidth = 15;

                    Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K1", "K1");
                    cl11.Value2 = "Thuế GTGT Cũ";
                    cl11.ColumnWidth = 15;

                    Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L1", "L1");
                    cl12.Value2 = "Phí BVMT Cũ";
                    cl12.ColumnWidth = 15;

                    Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M1", "M1");
                    cl13.Value2 = "Tổng Cộng Cũ";
                    cl13.ColumnWidth = 15;

                    Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("N1", "N1");
                    cl14.Value2 = "Giá Biểu Mới";
                    cl14.ColumnWidth = 11;

                    Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("O1", "O1");
                    cl15.Value2 = "Định Mức Mới";
                    cl15.ColumnWidth = 11;

                    Microsoft.Office.Interop.Excel.Range cl16 = oSheet.get_Range("P1", "P1");
                    cl16.Value2 = "Tiêu Thụ Mới";
                    cl16.ColumnWidth = 11;

                    Microsoft.Office.Interop.Excel.Range cl17 = oSheet.get_Range("Q1", "Q1");
                    cl17.Value2 = "Tiền Nước Mới";
                    cl17.ColumnWidth = 15;

                    Microsoft.Office.Interop.Excel.Range cl18 = oSheet.get_Range("R1", "R1");
                    cl18.Value2 = "Thuế GTGT Mới";
                    cl18.ColumnWidth = 15;

                    Microsoft.Office.Interop.Excel.Range cl19 = oSheet.get_Range("S1", "S1");
                    cl19.Value2 = "Phí BVMT Mới";
                    cl19.ColumnWidth = 15;

                    Microsoft.Office.Interop.Excel.Range cl20 = oSheet.get_Range("T1", "T1");
                    cl20.Value2 = "Tổng Cộng Mới";
                    cl20.ColumnWidth = 15;

                    Microsoft.Office.Interop.Excel.Range cl21 = oSheet.get_Range("U1", "U1");
                    cl21.Value2 = "Số Hóa Đơn Mới";
                    cl21.ColumnWidth = 15;

                    Microsoft.Office.Interop.Excel.Range cl22 = oSheet.get_Range("V1", "V1");
                    cl22.Value2 = "Báo Cáo Thuế";
                    cl22.ColumnWidth = 15;

                    // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
                    // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
                    int numColumn = 22;
                    object[,] arr = new object[dt.Rows.Count, numColumn];

                    //Chuyển dữ liệu từ DataTable vào mảng đối tượng
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        //if (bool.Parse(dr["PhieuDuocKy"].ToString()) == true && ((int.Parse(dr["Nam"].ToString()) > 2020) || (int.Parse(dr["Nam"].ToString()) == 2020 && int.Parse(dr["Ky"].ToString()) >= 7)))
                        {
                            arr[i, 0] = dr["Dot"].ToString();
                            arr[i, 1] = dr["Ky"].ToString();
                            arr[i, 2] = dr["Nam"].ToString();
                            arr[i, 3] = dr["DanhBo"].ToString();
                            arr[i, 4] = dr["SoPhatHanh"].ToString();
                            arr[i, 5] = dr["SoHoaDon"].ToString();
                            arr[i, 6] = dr["GiaBieu"].ToString();
                            arr[i, 7] = dr["DinhMuc"].ToString();
                            arr[i, 8] = dr["TieuThu"].ToString();
                            arr[i, 9] = dr["TienNuoc_Start"].ToString();
                            arr[i, 10] = dr["ThueGTGT_Start"].ToString();
                            arr[i, 11] = dr["PhiBVMT_Start"].ToString();
                            arr[i, 12] = dr["TongCong_Start"].ToString();
                            arr[i, 13] = dr["GiaBieu_BD"].ToString();
                            arr[i, 14] = dr["DinhMuc_BD"].ToString();
                            arr[i, 15] = dr["TieuThu_BD"].ToString();
                            arr[i, 16] = dr["TienNuoc_End"].ToString();
                            arr[i, 17] = dr["ThueGTGT_End"].ToString();
                            arr[i, 18] = dr["PhiBVMT_End"].ToString();
                            arr[i, 19] = dr["TongCong_End"].ToString();
                            arr[i, 21] = dr["BaoCaoThue"].ToString();
                        }
                    }

                    //Thiết lập vùng điền dữ liệu
                    int rowStart = 2;
                    int columnStart = 1;

                    int rowEnd = rowStart + dt.Rows.Count - 1;
                    int columnEnd = numColumn;

                    // Ô bắt đầu điền dữ liệu
                    Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
                    // Ô kết thúc điền dữ liệu
                    Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
                    // Lấy về vùng điền dữ liệu
                    Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

                    Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
                    Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
                    Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
                    c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                    Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
                    Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
                    Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
                    c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    c3b.NumberFormat = "@";

                    Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
                    Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
                    Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
                    c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                    Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
                    Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
                    Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
                    c3d.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                    //Điền dữ liệu vào vùng đã thiết lập
                    range.Value2 = arr;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcelHDDT2_Click(object sender, EventArgs e)
        {
            try
            {
                if (radDSDCHD.Checked)
                {
                    DataTable dt = new DataTable();
                    for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                        if (dgvDSDCBD["In", i].Value != null && bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true)
                        {
                            dt.Merge(_cDCBD.getHoaDon_DataTable(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString())));
                        }

                    //Tạo các đối tượng Excel
                    Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbooks oBooks;
                    Microsoft.Office.Interop.Excel.Sheets oSheets;
                    Microsoft.Office.Interop.Excel.Workbook oBook;
                    Microsoft.Office.Interop.Excel.Worksheet oSheet;
                    //Microsoft.Office.Interop.Excel.Worksheet oSheetCQ;

                    //Tạo mới một Excel WorkBook 
                    oExcel.Visible = true;
                    oExcel.DisplayAlerts = false;
                    //khai báo số lượng sheet
                    oExcel.Application.SheetsInNewWorkbook = 1;
                    oBooks = oExcel.Workbooks;

                    oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                    oSheets = oBook.Worksheets;
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

                    oSheet.Name = "Sheet1";
                    // Tạo tiêu đề cột 
                    Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
                    cl1.Value2 = "Đợt";
                    cl1.ColumnWidth = 5;

                    Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
                    cl2.Value2 = "Kỳ";
                    cl2.ColumnWidth = 5;

                    Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
                    cl3.Value2 = "Năm";
                    cl3.ColumnWidth = 5;

                    Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
                    cl4.Value2 = "Danh Bộ";
                    cl4.ColumnWidth = 12;

                    Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E1", "E1");
                    cl5.Value2 = "Số Phát Hành";
                    cl5.ColumnWidth = 10;

                    Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F1", "F1");
                    cl6.Value2 = "Chỉ Số Mới";
                    cl6.ColumnWidth = 10;

                    Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G1", "G1");
                    cl7.Value2 = "Chỉ Số Cũ";
                    cl7.ColumnWidth = 10;

                    Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H1", "H1");
                    cl8.Value2 = "Mẫu Số Cũ";
                    cl8.ColumnWidth = 10;

                    Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I1", "I1");
                    cl9.Value2 = "Ký Hiệu Cũ";
                    cl9.ColumnWidth = 10;

                    Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J1", "J1");
                    cl10.Value2 = "Số Hóa Đơn Cũ";
                    cl10.ColumnWidth = 10;

                    Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K1", "K1");
                    cl11.Value2 = "Họ Tên Người Mua Hàng";
                    cl11.ColumnWidth = 15;

                    Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L1", "L1");
                    cl12.Value2 = "Tên Đơn Vị";
                    cl12.ColumnWidth = 15;

                    Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M1", "M1");
                    cl13.Value2 = "Địa Chỉ Đơn Vị Mua";
                    cl13.ColumnWidth = 15;

                    Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("N1", "N1");
                    cl14.Value2 = "Mã Số Thuế";
                    cl14.ColumnWidth = 11;

                    Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("O1", "O1");
                    cl15.Value2 = "Giá Biểu Mới";
                    cl15.ColumnWidth = 10;

                    Microsoft.Office.Interop.Excel.Range cl16 = oSheet.get_Range("P1", "P1");
                    cl16.Value2 = "Định Mức Mới";
                    cl16.ColumnWidth = 10;

                    Microsoft.Office.Interop.Excel.Range cl17 = oSheet.get_Range("Q1", "Q1");
                    cl17.Value2 = "Tiêu Thụ Mới";
                    cl17.ColumnWidth = 10;

                    Microsoft.Office.Interop.Excel.Range cl18 = oSheet.get_Range("R1", "R1");
                    cl18.Value2 = "Số Lượng";
                    cl18.ColumnWidth = 10;

                    Microsoft.Office.Interop.Excel.Range cl19 = oSheet.get_Range("S1", "S1");
                    cl19.Value2 = "Đơn Giá";
                    cl19.ColumnWidth = 10;

                    Microsoft.Office.Interop.Excel.Range cl20 = oSheet.get_Range("T1", "T1");
                    cl20.Value2 = "Thành Tiền";
                    cl20.ColumnWidth = 15;

                    Microsoft.Office.Interop.Excel.Range cl21 = oSheet.get_Range("U1", "U1");
                    cl21.Value2 = "Thuế GTGT";
                    cl21.ColumnWidth = 10;

                    Microsoft.Office.Interop.Excel.Range cl22 = oSheet.get_Range("V1", "V1");
                    cl22.Value2 = "Phí BVMT";
                    cl22.ColumnWidth = 10;

                    Microsoft.Office.Interop.Excel.Range cl23 = oSheet.get_Range("W1", "W1");
                    cl23.Value2 = "Cộng Tiền Dịch Vụ Chưa Thuế";
                    cl23.ColumnWidth = 15;

                    Microsoft.Office.Interop.Excel.Range cl24 = oSheet.get_Range("X1", "X1");
                    cl24.Value2 = "Thuế GTGT Mới";
                    cl24.ColumnWidth = 15;

                    Microsoft.Office.Interop.Excel.Range cl25 = oSheet.get_Range("Y1", "Y1");
                    cl25.Value2 = "Phí BVMT Mới";
                    cl25.ColumnWidth = 15;

                    Microsoft.Office.Interop.Excel.Range cl26 = oSheet.get_Range("Z1", "Z1");
                    cl26.Value2 = "Tổng Cộng Mới";
                    cl26.ColumnWidth = 15;

                    Microsoft.Office.Interop.Excel.Range cl27 = oSheet.get_Range("AA1", "AA1");
                    cl27.Value2 = "Ký Hiệu Mới";
                    cl27.ColumnWidth = 10;

                    Microsoft.Office.Interop.Excel.Range cl28 = oSheet.get_Range("AB1", "AB1");
                    cl28.Value2 = "Số Hóa Đơn Mới";
                    cl28.ColumnWidth = 10;

                    // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
                    // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
                    //int numColumn = 28;
                    //object[,] arr = new object[dt.Rows.Count, numColumn];
                    int indexRow = 1;
                    //Chuyển dữ liệu từ DataTable vào mảng đối tượng
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        string[] ChiTietMois = dr["ChiTietMoi"].ToString().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                        foreach (string item in ChiTietMois)
                        {
                            indexRow++;
                            oSheet.Cells[indexRow, 1] = dr["Dot"].ToString();
                            oSheet.Cells[indexRow, 2] = dr["Ky"].ToString();
                            oSheet.Cells[indexRow, 3] = dr["Nam"].ToString();
                            oSheet.Cells[indexRow, 4] = dr["DanhBo"].ToString();
                            oSheet.Cells[indexRow, 5] = dr["SoPhatHanh"].ToString();
                            oSheet.Cells[indexRow, 6] = "";
                            oSheet.Cells[indexRow, 7] = "";
                            oSheet.Cells[indexRow, 8] = "01GTKT0/002";
                            oSheet.Cells[indexRow, 9] = dr["SoHoaDon"].ToString().Substring(0, 6);
                            oSheet.Cells[indexRow, 10] = dr["SoHoaDon"].ToString().Substring(6, 7);
                            oSheet.Cells[indexRow, 11] = dr["HoTen_BD"].ToString();
                            oSheet.Cells[indexRow, 12] = dr["HoTen_BD"].ToString();
                            oSheet.Cells[indexRow, 13] = dr["DiaChi_BD"].ToString();
                            oSheet.Cells[indexRow, 14] = dr["MST_BD"].ToString();
                            oSheet.Cells[indexRow, 15] = dr["GiaBieu_BD"].ToString();
                            oSheet.Cells[indexRow, 16] = dr["DinhMuc_BD"].ToString();
                            oSheet.Cells[indexRow, 17] = dr["TieuThu_BD"].ToString();
                            if (item != "")
                            {
                                string[] DonGia = item.Split('x');
                                oSheet.Cells[indexRow, 18] = DonGia[0].Trim().Replace(".", "");
                                oSheet.Cells[indexRow, 19] = DonGia[1].Trim().Replace(".", "");
                                oSheet.Cells[indexRow, 20] = int.Parse(DonGia[0].Trim().Replace(".", "")) * int.Parse(DonGia[1].Trim().Replace(".", ""));
                            }
                            oSheet.Cells[indexRow, 21] = "5";
                            oSheet.Cells[indexRow, 22] = "10";
                            oSheet.Cells[indexRow, 23] = dr["TienNuoc_End"].ToString();
                            oSheet.Cells[indexRow, 24] = dr["ThueGTGT_End"].ToString();
                            oSheet.Cells[indexRow, 25] = dr["PhiBVMT_End"].ToString();
                            oSheet.Cells[indexRow, 26] = dr["TongCong_End"].ToString();
                        }
                    }

                    //Thiết lập vùng điền dữ liệu
                    //int rowStart = 2;
                    //int columnStart = 1;

                    //int rowEnd = rowStart + dt.Rows.Count - 1;
                    //int columnEnd = numColumn;

                    //// Ô bắt đầu điền dữ liệu
                    //Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
                    //// Ô kết thúc điền dữ liệu
                    //Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
                    //// Lấy về vùng điền dữ liệu
                    ////Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
                    //////Điền dữ liệu vào vùng đã thiết lập
                    ////range.Value2 = arr;

                    //Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
                    //Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
                    //Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
                    //c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                    //Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
                    //Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
                    //Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
                    //c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    //c3b.NumberFormat = "@";

                    //Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
                    //Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
                    //Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
                    //c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                    //Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
                    //Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
                    //Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
                    //c3d.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhatThuTien_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (MessageBox.Show("Bạn chắc chắn Cập Nhật Thu Tiền những Phiếu trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        if (radDSDCHD.Checked)
                        {
                            for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                                if (dgvDSDCBD["In", i].Value != null && bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true && bool.Parse(dgvDSDCBD["PhieuDuocKy", i].Value.ToString()) == true && bool.Parse(dgvDSDCBD["ChuyenThuTien", i].Value.ToString()) == false)
                                {
                                    //using (TransactionScope scope = new TransactionScope())
                                    {
                                        DCBD_ChiTietHoaDon ctdchd = _cDCBD.getHoaDon(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));
                                        if (ctdchd != null)
                                        {
                                            DIEUCHINH_HD dchd = _cThuTien.get_DCHD(ctdchd.SoHoaDon);
                                            HOADON hoadon = _cThuTien.get(ctdchd.SoHoaDon);
                                            if (dchd != null)
                                            {
                                                if (ctdchd.DCBD.MaDon != null)
                                                    dchd.PHIEU_DC = (int)ctdchd.DCBD.MaDon;
                                                else
                                                    if (ctdchd.DCBD.MaDonTXL != null)
                                                        dchd.PHIEU_DC = (int)ctdchd.DCBD.MaDonTXL;
                                                    else
                                                        if (ctdchd.DCBD.MaDonTBC != null)
                                                            dchd.PHIEU_DC = (int)ctdchd.DCBD.MaDonTBC;

                                                dchd.NGAY_VB = ctdchd.NgayKy.Value;
                                                dchd.NGAY_DC = DateTime.Now;

                                                //if (dchd.SoPhieu != ctdchd.MaCTDCHD)
                                                //{
                                                //    dchd.GIABAN_BD = hoadon.GIABAN;
                                                //    dchd.THUE_BD = hoadon.THUE;
                                                //    dchd.PHI_BD = hoadon.PHI;
                                                //    dchd.TONGCONG_BD = hoadon.TONGCONG;
                                                //}

                                                dchd.SoPhieu = ctdchd.MaCTDCHD;
                                                dchd.TangGiam = ctdchd.TangGiam;

                                                dchd.GIABAN_DC = ctdchd.TienNuoc_BD.Value;
                                                dchd.GIABAN_END = ctdchd.TienNuoc_End.Value;

                                                dchd.THUE_DC = ctdchd.ThueGTGT_BD.Value;
                                                dchd.THUE_END = ctdchd.ThueGTGT_End.Value;

                                                dchd.PHI_DC = ctdchd.PhiBVMT_BD.Value;
                                                dchd.PHI_END = ctdchd.PhiBVMT_End.Value;

                                                dchd.TONGCONG_DC = ctdchd.TongCong_BD.Value;
                                                dchd.TONGCONG_END = ctdchd.TongCong_End.Value;

                                                dchd.GB_DC = ctdchd.GiaBieu_BD;
                                                dchd.DM_DC = ctdchd.DinhMuc_BD;
                                                dchd.TIEUTHU_DC = ctdchd.TieuThu_BD;

                                                dchd.ModifyDate = DateTime.Now;
                                                ///lưu lịch sử
                                                _cThuTien.LuuLichSuDC(dchd);

                                                if (ctdchd.BaoCaoThue == true)
                                                {
                                                    dchd.BaoCaoThue = true;
                                                    dchd.UpdatedHDDT = true;
                                                    hoadon.BaoCaoThue = true;
                                                }
                                                else
                                                {
                                                    dchd.BaoCaoThue = false;
                                                    dchd.UpdatedHDDT = false;
                                                    hoadon.BaoCaoThue = false;
                                                }
                                                hoadon.GIABAN = dchd.GIABAN_END;
                                                hoadon.THUE = dchd.THUE_END;
                                                hoadon.PHI = dchd.PHI_END;
                                                hoadon.TONGCONG = dchd.TONGCONG_END;
                                                hoadon.ModifyDate = DateTime.Now;
                                                _cThuTien.SubmitChanges();

                                                ctdchd.ChuyenThuTien = true;
                                                ctdchd.NgayChuyenThuTien = DateTime.Now;
                                                ctdchd.NguoiChuyenThuTien = CTaiKhoan.MaUser;
                                                ctdchd.ModifyBy = CTaiKhoan.MaUser;
                                                ctdchd.ModifyDate = DateTime.Now;
                                                _cDCBD.SubmitChanges();

                                                //scope.Complete();
                                            }
                                            else
                                            {
                                                DIEUCHINH_HD dchd1 = new DIEUCHINH_HD();
                                                dchd1.FK_HOADON = hoadon.ID_HOADON;
                                                dchd1.SoHoaDon = hoadon.SOHOADON;
                                                dchd1.GiaBieu = hoadon.GB;
                                                if (hoadon.DM != null)
                                                    dchd1.DinhMuc = (int)hoadon.DM;
                                                dchd1.TIEUTHU_BD = (int)hoadon.TIEUTHU;
                                                dchd1.GIABAN_BD = hoadon.GIABAN;
                                                dchd1.PHI_BD = hoadon.PHI;
                                                dchd1.THUE_BD = hoadon.THUE;
                                                dchd1.TONGCONG_BD = hoadon.TONGCONG;
                                                dchd1.NGAY_DC = DateTime.Now;

                                                if (ctdchd.DCBD.MaDonMoi != null)
                                                    dchd1.PHIEU_DC = ctdchd.DCBD.MaDonMoi;
                                                else
                                                    if (ctdchd.DCBD.MaDon != null)
                                                        dchd1.PHIEU_DC = (int)ctdchd.DCBD.MaDon;
                                                    else
                                                        if (ctdchd.DCBD.MaDonTXL != null)
                                                            dchd1.PHIEU_DC = (int)ctdchd.DCBD.MaDonTXL;
                                                        else
                                                            if (ctdchd.DCBD.MaDonTBC != null)
                                                                dchd1.PHIEU_DC = (int)ctdchd.DCBD.MaDonTBC;

                                                dchd1.NGAY_VB = ctdchd.NgayKy.Value;
                                                dchd1.SoPhieu = ctdchd.MaCTDCHD;
                                                dchd1.TangGiam = ctdchd.TangGiam;

                                                //_dchd.GIABAN_BD = ctdchd.TienNuoc_Start.Value;
                                                dchd1.GIABAN_DC = ctdchd.TienNuoc_BD.Value;
                                                dchd1.GIABAN_END = ctdchd.TienNuoc_End.Value;

                                                //_dchd.THUE_BD = ctdchd.ThueGTGT_Start.Value;
                                                dchd1.THUE_DC = ctdchd.ThueGTGT_BD.Value;
                                                dchd1.THUE_END = ctdchd.ThueGTGT_End.Value;

                                                //_dchd.PHI_BD = ctdchd.PhiBVMT_Start.Value;
                                                dchd1.PHI_DC = ctdchd.PhiBVMT_BD.Value;
                                                dchd1.PHI_END = ctdchd.PhiBVMT_End.Value;

                                                //_dchd.TONGCONG_BD = ctdchd.TongCong_Start.Value;
                                                dchd1.TONGCONG_DC = ctdchd.TongCong_BD.Value;
                                                dchd1.TONGCONG_END = ctdchd.TongCong_End.Value;

                                                dchd1.GB_DC = ctdchd.GiaBieu_BD;
                                                dchd1.DM_DC = ctdchd.DinhMuc_BD;
                                                dchd1.TIEUTHU_DC = ctdchd.TieuThu_BD;

                                                dchd1.CreateDate = DateTime.Now;
                                                _cThuTien.Them(dchd1);
                                                ///lưu lịch sử
                                                _cThuTien.LuuLichSuDC(dchd1);

                                                if (ctdchd.BaoCaoThue == true)
                                                {
                                                    dchd1.BaoCaoThue = true;
                                                    dchd1.UpdatedHDDT = true;
                                                    hoadon.BaoCaoThue = true;
                                                }
                                                else
                                                {
                                                    dchd1.BaoCaoThue = false;
                                                    dchd1.UpdatedHDDT = false;
                                                    hoadon.BaoCaoThue = false;
                                                }

                                                hoadon.GIABAN = dchd1.GIABAN_END;
                                                hoadon.THUE = dchd1.THUE_END;
                                                hoadon.PHI = dchd1.PHI_END;
                                                hoadon.TONGCONG = dchd1.TONGCONG_END;
                                                hoadon.ModifyDate = DateTime.Now;
                                                _cThuTien.SubmitChanges();

                                                ctdchd.ChuyenThuTien = true;
                                                ctdchd.NgayChuyenThuTien = DateTime.Now;
                                                ctdchd.NguoiChuyenThuTien = CTaiKhoan.MaUser;
                                                ctdchd.ModifyBy = CTaiKhoan.MaUser;
                                                ctdchd.ModifyDate = DateTime.Now;
                                                _cDCBD.SubmitChanges();

                                                //scope.Complete();
                                            }
                                        }

                                    }
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



    }
}

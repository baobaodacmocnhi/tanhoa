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
        CDocSo _cDocSo = new CDocSo();

        List<GiaNuoc> _lstGiaNuoc;

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
            //string sql = "select *,SoPhieu=MaCTDCBD,'In'='false' from DCBD_ChiTietBienDong where CAST(CreateDate as date)>='2018-03-01' and CAST(CreateDate as date)<='2018-03-31' and ChuyenDocSo=0 and PhieuDuocKy=1"
            //+ " and DanhBo not in (select DanhBo from DCBD_ChiTietBienDong where CAST(CreateDate as date)>'2018-03-31') order by CreateDate asc";
            //dgvDSDCBD.DataSource = _cDCBD.ExecuteQuery_SqlDataAdapter_DataTable(sql);
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                        if (chkCreateBy.Checked)
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
                            if (chkCreateBy.Checked)
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
                            else
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
                        if (chkCreateBy.Checked)
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
                            if (chkCreateBy.Checked)
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
                            else
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
                        if (chkCreateBy.Checked)
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
                        else
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
                    if (chkCreateBy.Checked)
                    {
                        if (radDSDCBD.Checked)
                            dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_CreateDate(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                        else
                            if (radDSDCHD.Checked)
                                dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_CreateDate(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                            else
                                if (radDSCatChuyenDM.Checked)
                                    dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_CreateDate(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                    }
                    else
                    {
                        if (radDSDCBD.Checked)
                            dgvDSDCBD.DataSource = _cDCBD.getDS_BienDong_CreateDate(dateTu.Value, dateDen.Value);
                        else
                            if (radDSDCHD.Checked)
                                dgvDSDCBD.DataSource = _cDCBD.getDS_HoaDon_CreateDate(dateTu.Value, dateDen.Value);
                            else
                                if (radDSCatChuyenDM.Checked)
                                    dgvDSCatChuyenDM.DataSource = _cChungTu.getDS_CatChuyenDM_CreateDate(dateTu.Value, dateDen.Value);
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

                                rptPhieuDCBD rpt = new rptPhieuDCBD();
                                rpt.SetDataSource(dsBaoCao);

                                printDialog.AllowSomePages = true;
                                printDialog.ShowHelp = true;

                                rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                                rpt.Clone();
                                rpt.Dispose();
                            }
                    }
                    else
                        if (radDSDCHD.Checked)
                        {
                            for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                                if (dgvDSDCBD["In", i].Value != null && bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true)
                                {
                                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
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
                                            dr["SoVanBan"] =ctdchd.DCBD.MaDonMoi.Value.ToString() + "." + ctdchd.STT;
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
                                        dr["TienNuocStart"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.TienNuoc_Start);
                                    if (ctdchd.ThueGTGT_Start == 0)
                                        dr["ThueGTGTStart"] = 0;
                                    else
                                        dr["ThueGTGTStart"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.ThueGTGT_Start);
                                    if (ctdchd.PhiBVMT_Start == 0)
                                        dr["PhiBVMTStart"] = 0;
                                    else
                                        dr["PhiBVMTStart"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.PhiBVMT_Start);
                                    if (ctdchd.TongCong_Start == 0)
                                        dr["TongCongStart"] = 0;
                                    else
                                        dr["TongCongStart"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.TongCong_Start);
                                    ///
                                    dr["TangGiam"] = ctdchd.TangGiam;
                                    ///
                                    dr["TieuThuBD"] = ctdchd.TieuThu_BD - ctdchd.TieuThu;
                                    if (ctdchd.TienNuoc_BD == 0)
                                        dr["TienNuocBD"] = 0;
                                    else
                                        dr["TienNuocBD"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.TienNuoc_BD);
                                    if (ctdchd.ThueGTGT_BD == 0)
                                        dr["ThueGTGTBD"] = 0;
                                    else
                                        dr["ThueGTGTBD"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.ThueGTGT_BD);
                                    if (ctdchd.PhiBVMT_BD == 0)
                                        dr["PhiBVMTBD"] = 0;
                                    else
                                        dr["PhiBVMTBD"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.PhiBVMT_BD);
                                    if (ctdchd.TongCong_BD == 0)
                                        dr["TongCongBD"] = 0;
                                    else
                                        dr["TongCongBD"] =String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_BD);
                                    ///
                                    dr["TieuThuEnd"] = ctdchd.TieuThu_BD;
                                    if (ctdchd.TienNuoc_End == 0)
                                        dr["TienNuocEnd"] = 0;
                                    else
                                        dr["TienNuocEnd"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.TienNuoc_End);
                                    if (ctdchd.ThueGTGT_End == 0)
                                        dr["ThueGTGTEnd"] = 0;
                                    else
                                        dr["ThueGTGTEnd"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.ThueGTGT_End);
                                    if (ctdchd.PhiBVMT_End == 0)
                                        dr["PhiBVMTEnd"] = 0;
                                    else
                                        dr["PhiBVMTEnd"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.PhiBVMT_End);
                                    if (ctdchd.TongCong_End == 0)
                                        dr["TongCongEnd"] = 0;
                                    else
                                        dr["TongCongEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.TongCong_End);

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
                                    rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
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
                                        ChungTu_LichSu lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(decimal.Parse(dgvDSCatChuyenDM["SoPhieu_CC", i].Value.ToString()));

                                        if (lichsuchungtu.YeuCauCat)
                                        {
                                            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                            DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                            if (lichsuchungtu.MaDonMoi != null)
                                            {
                                                LinQ.DonTu en = _cDonTu.get(lichsuchungtu.MaDonMoi.Value);
                                                if(en.DonTu_ChiTiets.Count==1)
                                                dr["MaDon"] = lichsuchungtu.MaDonMoi.ToString();
                                                else
                                                    dr["MaDon"] = lichsuchungtu.MaDonMoi.ToString()+"."+lichsuchungtu.STT.Value.ToString();
                                            }
                                            else
                                                if (lichsuchungtu.MaDon != null)
                                                    dr["MaDon"] = "TKH"+lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");
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

                                            dr["ChucVu"] = lichsuchungtu.ChucVu;
                                            dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                            dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                                            rptPhieuYCCatDMA4 rpt = new rptPhieuYCCatDMA4();
                                            rpt.SetDataSource(dsBaoCao);
                                            //for (int j = 0; j < rpt.Subreports.Count; j++)
                                            //{
                                            //    rpt.Subreports[j].SetDataSource(dsBaoCao);
                                            //}

                                            //frmShowBaoCao frm = new frmShowBaoCao(rpt);
                                            //frm.Show();
                                            printDialog.AllowSomePages = true;
                                            printDialog.ShowHelp = true;

                                            //rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                            //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                                            rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                            rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                                            rpt.Clone();
                                            rpt.Dispose();
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
                            }
                }
            }
        }

        private void btnCapNhatDocSo_Click(object sender, EventArgs e)
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
                                            _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set SOHO=SONHA+' '+TENDUONG,SONHA=N'" + ctdcbd.DiaChi_BD.Substring(0, ctdcbd.DiaChi_BD.IndexOf(" ")) + "',TENDUONG=N'" + ctdcbd.DiaChi_BD.Substring((ctdcbd.DiaChi_BD.IndexOf(" ") + 1), ctdcbd.DiaChi_BD.Length - ctdcbd.DiaChi_BD.IndexOf(" ") - 1) + "' where DANHBO='" + ctdcbd.DanhBo + "'");
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

        private void btnThuHoiCapNhatDocSo_Click(object sender, EventArgs e)
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
                                        _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set SONHA=N'" + ctdcbd.DiaChi.Substring(0, ctdcbd.DiaChi.IndexOf(" ")) + "',TENDUONG=N'" + ctdcbd.DiaChi.Substring((ctdcbd.DiaChi.IndexOf(" ") + 1), ctdcbd.DiaChi.Length - ctdcbd.DiaChi.IndexOf(" ") - 1) + "' where DANHBO='" + ctdcbd.DanhBo + "'");
                                    }
                                    if (!string.IsNullOrEmpty(ctdcbd.MSThue_BD))
                                    {
                                        _cDocSo.LinQ_ExecuteNonQuery("update TB_DULIEUKHACHHANG set MSTHUE=" + ctdcbd.MSThue.ToString() + " where DANHBO='" + ctdcbd.DanhBo + "'");
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
                            ChungTu_LichSu lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(decimal.Parse(dgvDSCatChuyenDM["SoPhieu_CC", i].Value.ToString()));
                            if (lichsuchungtu.YeuCauCat)
                            {
                                DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

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
                                    dr["MaDon"] = "TKH"+lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");
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

                                dr["ChucVu"] = lichsuchungtu.ChucVu;
                                dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);
                            }
                            else
                                if (lichsuchungtu.CatDM)
                                {
                                    DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

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
                                        dr["MaDon"] = "TKH"+lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");
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
                                    dr["TienNuocStart"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.TienNuoc_Start);
                                if (ctdchd.ThueGTGT_Start == 0)
                                    dr["ThueGTGTStart"] = 0;
                                else
                                    dr["ThueGTGTStart"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.ThueGTGT_Start);
                                if (ctdchd.PhiBVMT_Start == 0)
                                    dr["PhiBVMTStart"] = 0;
                                else
                                    dr["PhiBVMTStart"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.PhiBVMT_Start);
                                if (ctdchd.TongCong_Start == 0)
                                    dr["TongCongStart"] = 0;
                                else
                                    dr["TongCongStart"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.TongCong_Start);
                                ///
                                dr["TangGiam"] = ctdchd.TangGiam;
                                ///
                                dr["TieuThuBD"] = ctdchd.TieuThu_BD - ctdchd.TieuThu;
                                if (ctdchd.TienNuoc_BD == 0)
                                    dr["TienNuocBD"] = 0;
                                else
                                    dr["TienNuocBD"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.TienNuoc_BD);
                                if (ctdchd.ThueGTGT_BD == 0)
                                    dr["ThueGTGTBD"] = 0;
                                else
                                    dr["ThueGTGTBD"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.ThueGTGT_BD);
                                if (ctdchd.PhiBVMT_BD == 0)
                                    dr["PhiBVMTBD"] = 0;
                                else
                                    dr["PhiBVMTBD"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.PhiBVMT_BD);
                                if (ctdchd.TongCong_BD == 0)
                                    dr["TongCongBD"] = 0;
                                else
                                    dr["TongCongBD"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.TongCong_BD);
                                ///
                                dr["TieuThuEnd"] = ctdchd.TieuThu_BD;
                                if (ctdchd.TienNuoc_End == 0)
                                    dr["TienNuocEnd"] = 0;
                                else
                                    dr["TienNuocEnd"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.TienNuoc_End);
                                if (ctdchd.ThueGTGT_End == 0)
                                    dr["ThueGTGTEnd"] = 0;
                                else
                                    dr["ThueGTGTEnd"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.ThueGTGT_End);
                                if (ctdchd.PhiBVMT_End == 0)
                                    dr["PhiBVMTEnd"] = 0;
                                else
                                    dr["PhiBVMTEnd"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.PhiBVMT_End);
                                if (ctdchd.TongCong_End == 0)
                                    dr["TongCongEnd"] = 0;
                                else
                                    dr["TongCongEnd"] =  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",ctdchd.TongCong_End);

                                //if (ctdchd.KhuCongNghiep == true)
                                //{
                                    dr["ChucVu"] = ctdchd.ChucVu;
                                    dr["NguoiKy"] = ctdchd.NguoiKy;
                                //}

                                dsBaoCao.Tables["DCHD"].Rows.Add(dr);

                                ReportDocument rpt;
                                //if (ctdchd.KhuCongNghiep == true)
                                //{
                                    rpt = new rptThongBaoDCHD_ChuKy();                                    
                                //}
                                //else
                                //{
                                //    rpt = new rptThongBaoDCHD();
                                //}
                                rpt.SetDataSource(dsBaoCao);

                                printDialog.AllowSomePages = true;
                                printDialog.ShowHelp = true;

                                rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                                rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                                rpt.Clone();
                                rpt.Dispose();
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
                            if (ctdcbd.GhiChu != null && ctdcbd.GhiChu != "")
                            {
                                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                DataRow dr = dsBaoCao.Tables["DCBD"].NewRow();

                                dr["SoPhieu"] = ctdcbd.MaCTDCBD.ToString().Insert(ctdcbd.MaCTDCBD.ToString().Length - 2, "-");
                                dr["HieuLucKy"] = ctdcbd.HieuLucKy;
                                dr["DanhBo"] = ctdcbd.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["HopDong"] = ctdcbd.HopDong;
                                dr["HoTen"] = ctdcbd.HoTen;
                                dr["DiaChi"] = ctdcbd.DiaChi;
                                dr["ThongTin"] = ctdcbd.GhiChu;
                                if (ctdcbd.DCBD.MaDon != null)
                                    dr["MaDon"] = ctdcbd.DCBD.MaDon.ToString().Insert(ctdcbd.DCBD.MaDon.ToString().Length - 2, "-");
                                else
                                    if (ctdcbd.DCBD.MaDonTXL != null)
                                        dr["MaDon"] = "TXL" + ctdcbd.DCBD.MaDonTXL.ToString().Insert(ctdcbd.DCBD.MaDonTXL.ToString().Length - 2, "-");
                                    else
                                        if (ctdcbd.DCBD.MaDonTBC != null)
                                            dr["MaDon"] = "TBC" + ctdcbd.DCBD.MaDonTBC.ToString().Insert(ctdcbd.DCBD.MaDonTBC.ToString().Length - 2, "-");
                                if (radTruongPhong.Checked==true)
                                {
                                    dr["ChucVu"]="TRƯỞNG";
                                    dr["NguoiKy"] = radTruongPhong.Text;
                                }
                                else
                                    if (radPhoPhong.Checked == true)
                                    {
                                        dr["ChucVu"] = "PHÓ";
                                        dr["NguoiKy"] = radPhoPhong.Text;
                                    }

                                dsBaoCao.Tables["DCBD"].Rows.Add(dr);

                                rptThuBaoDCBD rpt = new rptThuBaoDCBD();
                                rpt.SetDataSource(dsBaoCao);

                                printDialog.AllowSomePages = true;
                                printDialog.ShowHelp = true;

                                //rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                                rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                //rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, false, 0,0);
                                rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                                rpt.Clone();
                                rpt.Dispose();

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
                        if (ctdcbd.GhiChu != null && ctdcbd.GhiChu != "")
                        {
                            if (flag == true)
                            {
                                DataRow dr = dsBaoCao1.Tables["ThaoThuTraLoi"].NewRow();

                                dr["HoTen"] = ctdcbd.HoTen;
                                dr["DiaChi"] = ctdcbd.DiaChi;
                                dr["SoPhieu"] = ctdcbd.MaCTDCBD.ToString().Insert(ctdcbd.MaCTDCBD.ToString().Length - 2, "-")+"/TB";

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




    }
}

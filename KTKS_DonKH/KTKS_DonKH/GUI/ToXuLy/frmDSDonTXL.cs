﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ToXuLy;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.BamChi;

namespace KTKS_DonKH.GUI.ToXuLy
{
    public partial class frmDSDonTXL : Form
    {
        CDonTXL _cDonTXL = new CDonTXL();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CBamChi _cBamChi = new CBamChi();

        public frmDSDonTXL()
        {
            InitializeComponent();
        }

        private void frmQLDonTXL_Load(object sender, EventArgs e)
        {
            dgvDSDonTXL.AutoGenerateColumns = false;

            cmbTimTheo.SelectedItem = "Ngày";
        }
        
        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Danh Bộ":
                case "Địa Chỉ":
                case "Số Công Văn":
                    txtNoiDungTimKiem.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
            }
            dgvDSDonTXL.DataSource = null;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL") && txtNoiDungTimKiem.Text.Trim().Length > 3)
                        dgvDSDonTXL.DataSource = _cDonTXL.GetDS(decimal.Parse(txtNoiDungTimKiem.Text.Trim().ToUpper().Substring(3).Replace("-", "")));
                    break;
                case "Số Công Văn":
                    dgvDSDonTXL.DataSource = _cDonTXL.GetDSBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    break;
                case "Danh Bộ":
                    dgvDSDonTXL.DataSource = _cDonTXL.GetDSByDanhBo(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    break;
                //case "Địa Chỉ":
                //    dgvDSDonTXL.DataSource = _cDonTXL.GetDSByDiaChi(txtNoiDungTimKiem.Text.Trim().ToUpper());
                //    break;
                case "Ngày":
                    dgvDSDonTXL.DataSource = _cDonTXL.GetDS(dateTu.Value, dateDen.Value);
                    break;
            }
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataGridViewRow item in dgvDSDonTXL.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                dr["LoaiBaoCao"] = "TỔ XỬ LÝ";
                dr["MaDon"] = item.Cells["MaDon"].Value.ToString().Insert(item.Cells["MaDon"].Value.ToString().Length - 2, "-");
                //dr["STT"] = item.Cells["STT"].Value;
                dr["TenLD"] = item.Cells["TenLD"].Value.ToString();
                dr["SoCongVan"] = item.Cells["SoCongVan"].Value.ToString();
                dr["NgayNhan"] = item.Cells["CreateDate"].Value.ToString();
                if (!string.IsNullOrEmpty(item.Cells["DanhBo"].Value.ToString()) && item.Cells["DanhBo"].Value.ToString().Length == 11)
                    dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item.Cells["HoTen"].Value;
                dr["DiaChi"] = item.Cells["DiaChi"].Value;
                dr["NoiDung"] = item.Cells["NoiDung"].Value;

                dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
            }
            rptDSDonTXL rpt = new rptDSDonTXL();
            rpt.SetDataSource(dsBaoCao);
            rpt.Subreports[0].SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void dgvDSDonTXL_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDonTXL.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSDonTXL_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSDonTXL.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmNhanDonTXL frm = new frmNhanDonTXL(decimal.Parse(dgvDSDonTXL["MaDon", dgvDSDonTXL.CurrentRow.Index].Value.ToString().Substring(3)));
                frm.ShowDialog();
            }
        }

        private void dgvDSDonTXL_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSDonTXL.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null && e.Value.ToString().Length > 2)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        //private void btnInChiTiet_Click(object sender, EventArgs e)
        //{
        //    DataTable dt = ((DataTable)dgvDSDonTXL.DataSource).DefaultView.ToTable();
        //    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
        //    foreach (DataRow itemRow in dt.Rows)
        //    {
        //        DonTXL dontxl = _cDonTXL.Get(decimal.Parse(itemRow["MaDon"].ToString()));
        //        if (dontxl.Chuyen_KTXM)
        //        {
        //            DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();

        //            dr["MaDon"] = "TXL" + itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
        //            dr["TenLD"] = itemRow["TenLD"].ToString();
        //            dr["NgayNhan"] = itemRow["CreateDate"].ToString();
        //            dr["NoiDung"] = itemRow["NoiDung"].ToString();
        //            dr["LoaiChuyen"] = "Đi Kiểm Tra";
        //            if (dontxl.NgayChuyen_KTXM != null)
        //                dr["NgayChuyen"] = dontxl.NgayChuyen_KTXM.Value.ToString("dd/MM/yyyy");
        //            if (dontxl.NguoiDi_KTXM != null)
        //                dr["GhiChu"] = _cTaiKhoan.GetHoTen(int.Parse(dontxl.NguoiDi_KTXM.Value.ToString()));
        //            dr["GhiChu"] += ". " + dontxl.GhiChuChuyen_KTXM;

        //            dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
        //        }
        //        if (dontxl.ChuyenBanDoiKhac)
        //        {
        //            DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();

        //            dr["MaDon"] = "TXL" + itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
        //            dr["TenLD"] = itemRow["TenLD"].ToString();
        //            dr["NgayNhan"] = itemRow["CreateDate"].ToString();
        //            dr["NoiDung"] = itemRow["NoiDung"].ToString();
        //            dr["LoaiChuyen"] = "Đi Ban Đội Khác";
        //            if (dontxl.NgayChuyenBanDoiKhac != null)
        //                dr["NgayChuyen"] = dontxl.NgayChuyenBanDoiKhac.Value.ToString("dd/MM/yyyy");
        //            dr["GhiChu"] = dontxl.GhiChuChuyenBanDoiKhac;

        //            dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
        //        }
        //        if (dontxl.ChuyenToKhachHang)
        //        {
        //            DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();

        //            dr["MaDon"] = "TXL" + itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
        //            dr["TenLD"] = itemRow["TenLD"].ToString();
        //            dr["NgayNhan"] = itemRow["CreateDate"].ToString();
        //            dr["NoiDung"] = itemRow["NoiDung"].ToString();
        //            dr["LoaiChuyen"] = "Đi Tổ Khách Hàng";
        //            if (dontxl.NgayChuyenToKhachHang != null)
        //                dr["NgayChuyen"] = dontxl.NgayChuyenToKhachHang.Value.ToString("dd/MM/yyyy");
        //            dr["GhiChu"] = dontxl.GhiChuChuyenToKhachHang;

        //            dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
        //        }
        //        if (dontxl.ChuyenBanDoiKhac)
        //        {
        //            DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();

        //            dr["MaDon"] = "TXL" + itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
        //            dr["TenLD"] = itemRow["TenLD"].ToString();
        //            dr["NgayNhan"] = itemRow["CreateDate"].ToString();
        //            dr["NoiDung"] = itemRow["NoiDung"].ToString();
        //            dr["LoaiChuyen"] = "Đi Khác";
        //            if (dontxl.NgayChuyenKhac != null)
        //                dr["NgayChuyen"] = dontxl.NgayChuyenKhac.Value.ToString("dd/MM/yyyy");
        //            dr["GhiChu"] = dontxl.GhiChuChuyenKhac;

        //            dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
        //        }
        //    }
        //    rptChiTietDonTXL rpt = new rptChiTietDonTXL();
        //    rpt.SetDataSource(dsBaoCao);
        //    frmShowBaoCao frm = new frmShowBaoCao(rpt);
        //    frm.ShowDialog();
        //}

        //private void btnInBamChi_Click(object sender, EventArgs e)
        //{
        //    DataTable dt = ((DataTable)dgvDSDonTXL.DataSource).DefaultView.ToTable();

        //    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
        //    foreach (DataRow itemRow in dt.Rows)
        //        if (itemRow["TenLD"].ToString().Contains("Bấm Chì"))
        //        {
        //            DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

        //            //dr["TuNgay"] = _tuNgay;
        //            //dr["DenNgay"] = _denNgay;
        //            dr["TenLD"] = itemRow["TenLD"];
        //            dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
        //            if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Length == 11)
        //                dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
        //            if (_cBamChi.CheckExist_BamChi("TXL",decimal.Parse(itemRow["MaDon"].ToString())))
        //            {
        //                dr["DaGiaiQuyet"] = "True";
        //            }

        //            dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
        //        }

        //    rptDSDonTXL_BamChi rpt = new rptDSDonTXL_BamChi();
        //    rpt.SetDataSource(dsBaoCao);
        //    frmShowBaoCao frm = new frmShowBaoCao(rpt);
        //    frm.ShowDialog();
        //}
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.BaoCao.DonTu;
using KTKS_DonKH.BaoCao.ToXuLy;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao.ToKhachHang;
using System.Runtime.InteropServices;
using KTKS_DonKH.DAL;

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmBaoCaoDonTu : Form
    {
        CDonTu _cDonTu = new CDonTu();
        CNoiChuyen _cNoiChuyen = new CNoiChuyen();
        CTo _cTo = new CTo();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CThuTien _cThuTien = new CThuTien();
        CDHN _cDocSo = new CDHN();
        CNhomDon _cNhomDon = new CNhomDon();

        public frmBaoCaoDonTu()
        {
            InitializeComponent();
        }

        private void frmBaoCaoDonTu_Load(object sender, EventArgs e)
        {
            cmbNoiChuyen_LichSuChuyenDon.DataSource = _cNoiChuyen.GetDS("DonTuChuyen");
            cmbNoiChuyen_LichSuChuyenDon.ValueMember = "ID";
            cmbNoiChuyen_LichSuChuyenDon.DisplayMember = "Name";
            cmbNoiChuyen_LichSuChuyenDon.SelectedIndex = 0;
            List<NoiChuyen> lstNoiChuyen = _cNoiChuyen.GetDS("DonTuNhan");
            NoiChuyen en = new NoiChuyen();
            en.ID = 0;
            en.Name = "Tất Cả";
            lstNoiChuyen.Insert(0, en);
            cmbNoiNhan_LichSuChuyenDon.DataSource = lstNoiChuyen;
            cmbNoiNhan_LichSuChuyenDon.ValueMember = "ID";
            cmbNoiNhan_LichSuChuyenDon.DisplayMember = "Name";
            cmbNoiNhan_LichSuChuyenDon.SelectedIndex = 0;

            cmbNoiNhan_NhanDon.DataSource = _cNoiChuyen.GetDS("DonTuNhan");
            cmbNoiNhan_NhanDon.ValueMember = "ID";
            cmbNoiNhan_NhanDon.DisplayMember = "Name";
            cmbNoiNhan_NhanDon.SelectedIndex = 0;

            if (CTaiKhoan.Admin || CTaiKhoan.TruongPhong || CTaiKhoan.ToTruong)
            {
                cmbTo.DataSource = _cTo.getDS_KTXM();
                cmbTo.ValueMember = "KyHieu";
                cmbTo.DisplayMember = "TenTo";
                panelTo.Visible = true;
            }
            else
            {
                panelTo.Visible = false;
            }

            //Danh Sách Chuyển KTXM (ngày chuyển)
            DataTable dt = new DataTable();
            dt = _cTaiKhoan.getDS_KTXM(CTaiKhoan.KyHieuMaTo);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["MaU"] = 0;
                dr["HoTen"] = "Tất Cả";
                dt.Rows.InsertAt(dr, 0);
                cmbNhanVienKiemTra.DataSource = dt;
                cmbNhanVienKiemTra.ValueMember = "MaU";
                cmbNhanVienKiemTra.DisplayMember = "HoTen";
                cmbNhanVienKiemTra.SelectedIndex = 0;
            }

            DataTable dt2 = new DataTable();
            dt2 = _cNhomDon.getDS();
            if (dt2 != null)
            {
                DataRow dr = dt2.NewRow();
                dr["Name"] = "Tất Cả";
                dt2.Rows.InsertAt(dr, 0);
                cmbNoiDungThuongVu_DSChuyenKTXM.DataSource = dt2;
                cmbNoiDungThuongVu_DSChuyenKTXM.ValueMember = "Name";
                cmbNoiDungThuongVu_DSChuyenKTXM.DisplayMember = "Name";
            }
        }

        private void cmbTimTheo_LichSuChuyenDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo_LichSuChuyenDon.SelectedItem.ToString())
            {
                case "Số Công Văn":
                    txtNoiDungTimKiem_LichSuChuyenDon.Visible = true;
                    panel_KhoangThoiGian_LichSuChuyenDon.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem_LichSuChuyenDon.Visible = false;
                    panel_KhoangThoiGian_LichSuChuyenDon.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem_LichSuChuyenDon.Visible = false;
                    panel_KhoangThoiGian_LichSuChuyenDon.Visible = false;
                    break;
            }
        }

        private void btnBaoCao_LichSuChuyenDon_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (chkNguoiLap.Checked == true)
            {
                dt = _cDonTu.getDS_LichSu( CTaiKhoan.MaUser, dateTu_LichSuChuyenDon.Value, dateDen_LichSuChuyenDon.Value,cmbNoiChuyen_LichSuChuyenDon.SelectedValue.ToString(),cmbNoiNhan_LichSuChuyenDon.SelectedValue.ToString());
                //if (cmbNoiNhan_LichSuChuyenDon.SelectedIndex == 0)
                //    switch (cmbTimTheo_LichSuChuyenDon.SelectedItem.ToString())
                //    {
                //        case "Ngày":
                //            dt = _cDonTu.getDS_LichSu(CTaiKhoan.KyHieuMaTo, CTaiKhoan.MaUser, dateTu_LichSuChuyenDon.Value, dateDen_LichSuChuyenDon.Value);
                //            break;
                //        case "Số Công Văn":
                //            dt = _cDonTu.getDS_LichSu(CTaiKhoan.KyHieuMaTo, CTaiKhoan.MaUser, txtNoiDungTimKiem_LichSuChuyenDon.Text.Trim().ToUpper());
                //            break;
                //    }
                //else
                //    if (cmbNoiNhan_LichSuChuyenDon.SelectedIndex > 0)
                //        switch (cmbTimTheo_LichSuChuyenDon.SelectedItem.ToString())
                //        {
                //            case "Ngày":
                //                dt = _cDonTu.getDS_LichSu(CTaiKhoan.KyHieuMaTo, CTaiKhoan.MaUser, dateTu_LichSuChuyenDon.Value, dateDen_LichSuChuyenDon.Value, int.Parse(cmbNoiNhan_LichSuChuyenDon.SelectedValue.ToString()));
                //                break;
                //            case "Số Công Văn":
                //                dt = _cDonTu.getDS_LichSu(CTaiKhoan.KyHieuMaTo, CTaiKhoan.MaUser, txtNoiDungTimKiem_LichSuChuyenDon.Text.Trim().ToUpper(), int.Parse(cmbNoiNhan_LichSuChuyenDon.SelectedValue.ToString()));
                //                break;
                //        }
            }
            else
                dt = _cDonTu.getDS_LichSu( dateTu_LichSuChuyenDon.Value, dateDen_LichSuChuyenDon.Value, cmbNoiChuyen_LichSuChuyenDon.SelectedValue.ToString(), cmbNoiNhan_LichSuChuyenDon.SelectedValue.ToString());
                //if (cmbNoiNhan_LichSuChuyenDon.SelectedIndex == 0)
                //    switch (cmbTimTheo_LichSuChuyenDon.SelectedItem.ToString())
                //    {
                //        case "Ngày":
                //            dt = _cDonTu.getDS_LichSu(CTaiKhoan.KyHieuMaTo, dateTu_LichSuChuyenDon.Value, dateDen_LichSuChuyenDon.Value);
                //            break;
                //        case "Số Công Văn":
                //            dt = _cDonTu.getDS_LichSu(CTaiKhoan.KyHieuMaTo, txtNoiDungTimKiem_LichSuChuyenDon.Text.Trim().ToUpper());
                //            break;
                //    }
                //else
                //    if (cmbNoiNhan_LichSuChuyenDon.SelectedIndex > 0)
                //        switch (cmbTimTheo_LichSuChuyenDon.SelectedItem.ToString())
                //        {
                //            case "Ngày":
                //                dt = _cDonTu.getDS_LichSu(CTaiKhoan.KyHieuMaTo, dateTu_LichSuChuyenDon.Value, dateDen_LichSuChuyenDon.Value, int.Parse(cmbNoiNhan_LichSuChuyenDon.SelectedValue.ToString()));
                //                break;
                //            case "Số Công Văn":
                //                dt = _cDonTu.getDS_LichSu(CTaiKhoan.KyHieuMaTo, txtNoiDungTimKiem_LichSuChuyenDon.Text.Trim().ToUpper(), int.Parse(cmbNoiNhan_LichSuChuyenDon.SelectedValue.ToString()));
                //                break;
                //        }
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["CongVan"].NewRow();

                dr["TuNgay"] = dateTu_LichSuChuyenDon.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_LichSuChuyenDon.Value.ToString("dd/MM/yyyy");
                dr["Ma"] = item["MaDon"].ToString();
                dr["MaChiTiet"] = item["MaDonChiTiet"].ToString();
                dr["CreateDate"] = item["NgayChuyen"].ToString();
                if (item["DanhBo"].ToString().Length == 11)
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["DiaChi"] = item["DiaChi"].ToString();
                dr["NoiDung"] = item["NoiDungDon"].ToString();
                dr["NoiNhan"] = item["NoiNhan"].ToString();
                dr["GhiChu"] = item["NoiDung"].ToString();
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                dr["NguoiLap"] = CTaiKhoan.HoTen;

                dsBaoCao.Tables["CongVan"].Rows.Add(dr);
            }
            rptDSChuyenDonTu rpt = new rptDSChuyenDonTu();
            rpt.SetDataSource(dsBaoCao);
            rpt.Subreports[0].SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void cmbTimTheo_DSChuyenKTXM_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo_DSChuyenKTXM.SelectedItem.ToString())
            {
                case "Số Công Văn":
                case "Mã Đơn":
                    txtNoiDungTimKiem_DSChuyenKTXM.Visible = true;
                    panel_KhoangThoiGian_DSChuyenKTXM.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem_DSChuyenKTXM.Visible = false;
                    panel_KhoangThoiGian_DSChuyenKTXM.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem_DSChuyenKTXM.Visible = false;
                    panel_KhoangThoiGian_DSChuyenKTXM.Visible = false;
                    break;
            }
        }

        private void btnBaoCao_DSChuyenKTXM_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            switch (cmbTimTheo_DSChuyenKTXM.SelectedItem.ToString())
            {
                case "Ngày":
                    if (CTaiKhoan.TruongPhong == true || cmbNhanVienKiemTra.SelectedIndex == 0)
                        if (cmbNoiDungThuongVu_DSChuyenKTXM.SelectedIndex == 0)
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, dateTu_DSChuyenKTXM.Value, dateDen_DSChuyenKTXM.Value);
                        else
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, cmbNoiDungThuongVu_DSChuyenKTXM.SelectedValue.ToString(), dateTu_DSChuyenKTXM.Value, dateDen_DSChuyenKTXM.Value);
                    else
                        if (cmbNoiDungThuongVu_DSChuyenKTXM.SelectedIndex == 0)
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, int.Parse(cmbNhanVienKiemTra.SelectedValue.ToString()), dateTu_DSChuyenKTXM.Value, dateDen_DSChuyenKTXM.Value);
                        else
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, int.Parse(cmbNhanVienKiemTra.SelectedValue.ToString()), cmbNoiDungThuongVu_DSChuyenKTXM.SelectedValue.ToString(), dateTu_DSChuyenKTXM.Value, dateDen_DSChuyenKTXM.Value);
                    break;
                case "Số Công Văn":
                    if (CTaiKhoan.TruongPhong == true || cmbNhanVienKiemTra.SelectedIndex == 0)
                        if (cmbNoiDungThuongVu_DSChuyenKTXM.SelectedIndex == 0)
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, txtNoiDungTimKiem_DSChuyenKTXM.Text.Trim().ToUpper());
                        else
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, cmbNoiDungThuongVu_DSChuyenKTXM.SelectedValue.ToString(), txtNoiDungTimKiem_DSChuyenKTXM.Text.Trim().ToUpper());
                    else
                        if (cmbNoiDungThuongVu_DSChuyenKTXM.SelectedIndex == 0)
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, int.Parse(cmbNhanVienKiemTra.SelectedValue.ToString()), txtNoiDungTimKiem_DSChuyenKTXM.Text.Trim().ToUpper());
                        else
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, int.Parse(cmbNhanVienKiemTra.SelectedValue.ToString()), cmbNoiDungThuongVu_DSChuyenKTXM.SelectedValue.ToString(), txtNoiDungTimKiem_DSChuyenKTXM.Text.Trim().ToUpper());
                    break;
                case "Mã Đơn":
                    if (CTaiKhoan.TruongPhong == true || cmbNhanVienKiemTra.SelectedIndex == 0)
                        if (cmbNoiDungThuongVu_DSChuyenKTXM.SelectedIndex == 0)
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, int.Parse(txtNoiDungTimKiem_DSChuyenKTXM.Text.Trim().ToUpper()));
                        else
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, cmbNoiDungThuongVu_DSChuyenKTXM.SelectedValue.ToString(), int.Parse(txtNoiDungTimKiem_DSChuyenKTXM.Text.Trim().ToUpper()));
                    else
                        if (cmbNoiDungThuongVu_DSChuyenKTXM.SelectedIndex == 0)
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, int.Parse(cmbNhanVienKiemTra.SelectedValue.ToString()), int.Parse(txtNoiDungTimKiem_DSChuyenKTXM.Text.Trim().ToUpper()));
                        else
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, int.Parse(cmbNhanVienKiemTra.SelectedValue.ToString()), cmbNoiDungThuongVu_DSChuyenKTXM.SelectedValue.ToString(), int.Parse(txtNoiDungTimKiem_DSChuyenKTXM.Text.Trim().ToUpper()));
                    break;
            }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            if (chkChuaKT_DSChuyenKTXM.Checked)
                foreach (DataRow itemRow in dt.Rows)
                {
                    if (bool.Parse(itemRow["GiaiQuyet"].ToString()) == false)
                    {
                        DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                        if (cmbTimTheo_DSChuyenKTXM.SelectedItem.ToString() == "Ngày")
                        {
                            dr["TuNgay"] = dateTu_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                            dr["DenNgay"] = dateDen_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                        }
                        dr["MaDon"] = itemRow["MaDon"].ToString();
                        //dr["STT"] = itemRow["STT"].ToString();
                        dr["NgayChuyen"] = itemRow["NgayChuyen"];
                        dr["NgayNhan"] = itemRow["NgayNhan"];
                        dr["SoCongVan"] = itemRow["SoCongVan"];
                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Length == 11)
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];
                        dr["NoiDung"] = itemRow["NoiDung"];
                        dr["GhiChuChuyenKT"] = itemRow["NoiDungKTXM"];
                        dr["NguoiDi"] = itemRow["NguoiDi"];
                        dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                        dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
                    }
                }
            else
                foreach (DataRow itemRow in dt.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                    if (cmbTimTheo_DSChuyenKTXM.SelectedItem.ToString() == "Ngày")
                    {
                        dr["TuNgay"] = dateTu_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                    }
                    dr["MaDon"] = itemRow["MaDon"].ToString();
                    //dr["STT"] = itemRow["STT"].ToString();
                    dr["NgayChuyen"] = itemRow["NgayChuyen"];
                    dr["NgayNhan"] = itemRow["NgayNhan"];
                    dr["SoCongVan"] = itemRow["SoCongVan"];
                    if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Length == 11)
                        dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = itemRow["HoTen"];
                    dr["DiaChi"] = itemRow["DiaChi"];
                    dr["NoiDung"] = itemRow["NoiDung"];
                    dr["GhiChuChuyenKT"] = itemRow["NoiDungKTXM"];
                    dr["NguoiDi"] = itemRow["NguoiDi"];
                    dr["DaGiaiQuyet"] = itemRow["GiaiQuyet"];
                    dr["NgayGiaiQuyet"] = itemRow["NgayGiaiQuyet"];
                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                    dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
                }

            rptDSDonTXLChuyenKTXM rpt = new rptDSDonTXLChuyenKTXM();
            rpt.SetDataSource(dsBaoCao);
            rpt.Subreports[0].SetDataSource(dsBaoCao);
            rpt.Subreports[1].SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnInDSTong_DSChuyenKTXM_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            switch (cmbTimTheo_DSChuyenKTXM.SelectedItem.ToString())
            {
                case "Ngày":
                    if (CTaiKhoan.TruongPhong == true || cmbNhanVienKiemTra.SelectedIndex == 0)
                        if (cmbNoiDungThuongVu_DSChuyenKTXM.SelectedIndex == 0)
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, dateTu_DSChuyenKTXM.Value, dateDen_DSChuyenKTXM.Value);
                        else
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, cmbNoiDungThuongVu_DSChuyenKTXM.SelectedValue.ToString(), dateTu_DSChuyenKTXM.Value, dateDen_DSChuyenKTXM.Value);
                    else
                        if (cmbNoiDungThuongVu_DSChuyenKTXM.SelectedIndex == 0)
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, int.Parse(cmbNhanVienKiemTra.SelectedValue.ToString()), dateTu_DSChuyenKTXM.Value, dateDen_DSChuyenKTXM.Value);
                        else
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, int.Parse(cmbNhanVienKiemTra.SelectedValue.ToString()), cmbNoiDungThuongVu_DSChuyenKTXM.SelectedValue.ToString(), dateTu_DSChuyenKTXM.Value, dateDen_DSChuyenKTXM.Value);
                    break;
                case "Số Công Văn":
                    if (CTaiKhoan.TruongPhong == true || cmbNhanVienKiemTra.SelectedIndex == 0)
                        if (cmbNoiDungThuongVu_DSChuyenKTXM.SelectedIndex == 0)
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, txtNoiDungTimKiem_DSChuyenKTXM.Text.Trim().ToUpper());
                        else
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, cmbNoiDungThuongVu_DSChuyenKTXM.SelectedValue.ToString(), txtNoiDungTimKiem_DSChuyenKTXM.Text.Trim().ToUpper());
                    else
                        if (cmbNoiDungThuongVu_DSChuyenKTXM.SelectedIndex == 0)
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, int.Parse(cmbNhanVienKiemTra.SelectedValue.ToString()), txtNoiDungTimKiem_DSChuyenKTXM.Text.Trim().ToUpper());
                        else
                            dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, int.Parse(cmbNhanVienKiemTra.SelectedValue.ToString()), cmbNoiDungThuongVu_DSChuyenKTXM.SelectedValue.ToString(), txtNoiDungTimKiem_DSChuyenKTXM.Text.Trim().ToUpper());
                    break;
            }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            if (chkChuaKT_DSChuyenKTXM.Checked)
                foreach (DataRow itemRow in dt.Rows)
                {
                    if (bool.Parse(itemRow["GiaiQuyet"].ToString()) == false)
                    {
                        DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                        if (cmbTimTheo_DSChuyenKTXM.SelectedItem.ToString() == "Ngày")
                        {
                            dr["TuNgay"] = dateTu_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                            dr["DenNgay"] = dateDen_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                        }
                        dr["MaDon"] = itemRow["MaDon"].ToString();
                        //dr["STT"] = itemRow["STT"].ToString();
                        dr["NgayChuyen"] = itemRow["NgayChuyen"];
                        dr["NgayNhan"] = itemRow["NgayNhan"];
                        dr["SoCongVan"] = itemRow["SoCongVan"];
                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Length == 11)
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];
                        dr["NoiDung"] = itemRow["NoiDung"];
                        dr["GhiChuChuyenKT"] = itemRow["NoiDungKTXM"];
                        dr["NguoiDi"] = itemRow["NguoiDi"];
                        dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                        dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
                    }
                }
            else
                foreach (DataRow itemRow in dt.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                    if (cmbTimTheo_DSChuyenKTXM.SelectedItem.ToString() == "Ngày")
                    {
                        dr["TuNgay"] = dateTu_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                    }
                    dr["MaDon"] = itemRow["MaDon"].ToString();
                    //dr["STT"] = itemRow["STT"].ToString();
                    dr["NgayChuyen"] = itemRow["NgayChuyen"];
                    dr["NgayNhan"] = itemRow["NgayNhan"];
                    dr["SoCongVan"] = itemRow["SoCongVan"];
                    if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Length == 11)
                        dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = itemRow["HoTen"];
                    dr["DiaChi"] = itemRow["DiaChi"];
                    dr["NoiDung"] = itemRow["NoiDung"];
                    dr["GhiChuChuyenKT"] = itemRow["NoiDungKTXM"];
                    dr["NguoiDi"] = itemRow["NguoiDi"];
                    dr["DaGiaiQuyet"] = itemRow["GiaiQuyet"];
                    dr["NgayGiaiQuyet"] = itemRow["NgayGiaiQuyet"];
                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                    dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
                }

            rptDSDonChuyenKTXM_Tong rpt = new rptDSDonChuyenKTXM_Tong();
            rpt.SetDataSource(dsBaoCao);
            rpt.Subreports[0].SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        //

        private void btnBaoCao_ThongKeNhomDon_ToGD_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (CTaiKhoan.Admin || CTaiKhoan.TruongPhong || CTaiKhoan.ToTruong)
                dt = _cDonTu.getDS_ThongKeNhomDon("", dateTu_ThongKeNhomDon_ToGD.Value, dateDen_ThongKeNhomDon_ToGD.Value);
            else
                dt = _cDonTu.getDS_ThongKeNhomDon(CTaiKhoan.KyHieuMaTo, dateTu_ThongKeNhomDon_ToGD.Value, dateDen_ThongKeNhomDon_ToGD.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DanhSach"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeNhomDon_ToGD.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeNhomDon_ToGD.Value.ToString("dd/MM/yyyy");
                dr["LoaiBaoCao"] = CTaiKhoan.TenTo.ToUpper();
                dr["MaDon"] = item["MaDon"];
                dr["MaDonChiTiet"] = item["MaDonChiTiet"];
                dr["NhomDon"] = item["NhomDon"];
                dr["ChuyenToGD"] = item["ChuyenToGD"];
                dr["ChuyenToTB"] = item["ChuyenToTB"];
                dr["ChuyenToTP"] = item["ChuyenToTP"];
                dr["ChuyenToBC"] = item["ChuyenToBC"];
                dr["ChuyenKhac"] = item["ChuyenKhac"];
                dr["NguoiLap"] = CTaiKhoan.HoTen;

                dsBaoCao.Tables["DanhSach"].Rows.Add(dr);
            }

            rptThongKeDonTu rpt = new rptThongKeDonTu();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnInDSChuaChuyen_ThongKeNhomDon_ToGD_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (CTaiKhoan.Admin || CTaiKhoan.TruongPhong || CTaiKhoan.ToTruong)
                dt = _cDonTu.getDS_ThongKeNhomDon("", dateTu_ThongKeNhomDon_ToGD.Value, dateDen_ThongKeNhomDon_ToGD.Value);
            else
                dt = _cDonTu.getDS_ThongKeNhomDon(CTaiKhoan.KyHieuMaTo, dateTu_ThongKeNhomDon_ToGD.Value, dateDen_ThongKeNhomDon_ToGD.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
                if (bool.Parse(item["ChuyenToTB"].ToString()) == false && bool.Parse(item["ChuyenToTP"].ToString()) == false && bool.Parse(item["ChuyenToBC"].ToString()) == false && bool.Parse(item["ChuyenKhac"].ToString()) == false)
                {
                    DataRow dr = dsBaoCao.Tables["DanhSach"].NewRow();

                    dr["TuNgay"] = dateTu_ThongKeNhomDon_ToGD.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen_ThongKeNhomDon_ToGD.Value.ToString("dd/MM/yyyy");
                    dr["LoaiBaoCao"] = "CHƯA CHUYỂN";
                    dr["MaDon"] = item["MaDonChiTiet"];
                    dr["DanhBo"] = item["DanhBo"];
                    dr["HoTen"] = item["HoTen"];
                    dr["DiaChi"] = item["DiaChi"];
                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                    dsBaoCao.Tables["DanhSach"].Rows.Add(dr);
                }

            rptDanhSach_Doc rpt = new rptDanhSach_Doc();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        //

        private void btnBaoCao_ThongKeNhomDon_3To_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (CTaiKhoan.Admin || CTaiKhoan.TruongPhong || CTaiKhoan.ToTruong)
            {
                if (cmbTo.SelectedIndex > -1)
                    dt = _cDonTu.getDS_ThongKeNhomDon(cmbTo.SelectedValue.ToString(), dateTu_ThongKeNhomDon_3To.Value, dateDen_ThongKeNhomDon_3To.Value);
            }
            else
                dt = _cDonTu.getDS_ThongKeNhomDon(CTaiKhoan.KyHieuMaTo, dateTu_ThongKeNhomDon_3To.Value, dateDen_ThongKeNhomDon_3To.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DanhSachDonKH"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeNhomDon_3To.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeNhomDon_3To.Value.ToString("dd/MM/yyyy");
                dr["LoaiBaoCao"] = CTaiKhoan.TenTo.ToUpper();
                dr["MaDonMoi"] = item["MaDon"];
                dr["MaDon"] = item["MaDonChiTiet"];
                dr["TenLD"] = item["NhomDon"];
                dr["ChuyenTrucTiep"] = item["ChuyenTrucTiep"];
                dr["ChuyenKTXM"] = item["ChuyenKTXM"];
                dr["DaKTXM"] = item["DaKTXM"];
                dr["NguoiLap"] = CTaiKhoan.HoTen;

                dsBaoCao.Tables["DanhSachDonKH"].Rows.Add(dr);
            }

            rptThongKeDonTKH rpt = new rptThongKeDonTKH();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnInDSChuaChuyen_ThongKeNhomDon_3To_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (CTaiKhoan.Admin || CTaiKhoan.TruongPhong || CTaiKhoan.ToTruong)
            {
                if (cmbTo.SelectedIndex > -1)
                    dt = _cDonTu.getDS_ThongKeNhomDon(cmbTo.SelectedValue.ToString(), dateTu_ThongKeNhomDon_3To.Value, dateDen_ThongKeNhomDon_3To.Value);
            }
            else
                dt = _cDonTu.getDS_ThongKeNhomDon(CTaiKhoan.KyHieuMaTo, dateTu_ThongKeNhomDon_3To.Value, dateDen_ThongKeNhomDon_3To.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
                if (bool.Parse(item["ChuyenTrucTiep"].ToString()) == false && bool.Parse(item["ChuyenKTXM"].ToString()) == false)
                {
                    DataRow dr = dsBaoCao.Tables["DanhSachDonKH"].NewRow();

                    dr["TuNgay"] = dateTu_ThongKeNhomDon_3To.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen_ThongKeNhomDon_3To.Value.ToString("dd/MM/yyyy");
                    dr["MaDon"] = item["MaDonChiTiet"];
                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                    dsBaoCao.Tables["DanhSachDonKH"].Rows.Add(dr);
                }

            rptDSDonKH rpt = new rptDSDonKH();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnInDSChuaKTXM_ThongKeNhomDon_3To_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (CTaiKhoan.Admin || CTaiKhoan.TruongPhong || CTaiKhoan.ToTruong)
            {
                if (cmbTo.SelectedIndex > -1)
                    dt = _cDonTu.getDS_ThongKeNhomDon(cmbTo.SelectedValue.ToString(), dateTu_ThongKeNhomDon_3To.Value, dateDen_ThongKeNhomDon_3To.Value);
            }
            else
                dt = _cDonTu.getDS_ThongKeNhomDon(CTaiKhoan.KyHieuMaTo, dateTu_ThongKeNhomDon_3To.Value, dateDen_ThongKeNhomDon_3To.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
                if (bool.Parse(item["ChuyenKTXM"].ToString()) == true && bool.Parse(item["DaKTXM"].ToString()) == false)
                {
                    DataRow dr = dsBaoCao.Tables["DanhSachDonKH"].NewRow();

                    dr["TuNgay"] = dateTu_ThongKeNhomDon_3To.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen_ThongKeNhomDon_3To.Value.ToString("dd/MM/yyyy");
                    dr["MaDon"] = item["MaDonChiTiet"];
                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                    dsBaoCao.Tables["DanhSachDonKH"].Rows.Add(dr);
                }

            rptDSDonKH rpt = new rptDSDonKH();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        //

        private void btnBaoCao_ThongKeNhomDon_Phong_Click(object sender, EventArgs e)
        {
            DataTable dt = _cDonTu.getDS_ThongKeNhomDon(dateTu_ThongKeNhomDon_Phong.Value, dateDen_ThongKeNhomDon_Phong.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DanhSach"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeNhomDon_Phong.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeNhomDon_Phong.Value.ToString("dd/MM/yyyy");
                dr["MaDon"] = item["MaDon"];
                dr["MaDonChiTiet"] = item["MaDonChiTiet"];
                dr["NhomDon"] = item["NhomDon"];
                //dr["ChuyenKhac"] = item["ChuyenTrucTiep"];
                dr["DaKTXM"] = item["DaKTXM"];
                dr["NguoiLap"] = CTaiKhoan.HoTen;
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                dsBaoCao.Tables["DanhSach"].Rows.Add(dr);
            }

            rptThongKeDonTu_Phong rpt = new rptThongKeDonTu_Phong();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnInDSChuaChuyen_ThongKeNhomDon_Phong_Click(object sender, EventArgs e)
        {
            DataTable dt;
            if (cmbNoiDungThuongVu.SelectedIndex == 0)
                dt = _cDonTu.getDS_ThongKeNhomDon(dateTu_ThongKeNhomDon_Phong.Value, dateDen_ThongKeNhomDon_Phong.Value);
            else
                dt = _cDonTu.getDS_ThongKeNhomDon_DCMS_TroNgayThayDHN(dateTu_ThongKeNhomDon_Phong.Value, dateDen_ThongKeNhomDon_Phong.Value);

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
                if (bool.Parse(item["DaKTXM"].ToString()) == false)
                {
                    DataRow dr = dsBaoCao.Tables["DanhSach"].NewRow();

                    dr["TuNgay"] = dateTu_ThongKeNhomDon_Phong.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen_ThongKeNhomDon_Phong.Value.ToString("dd/MM/yyyy");
                    dr["LoaiBaoCao"] = "TỒN";
                    dr["MaDon"] = item["MaDonChiTiet"];
                    dr["DanhBo"] = item["DanhBo"];
                    dr["HoTen"] = item["HoTen"];
                    dr["DiaChi"] = item["DiaChi"];
                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                    dsBaoCao.Tables["DanhSach"].Rows.Add(dr);
                }

            rptDanhSach_Doc rpt = new rptDanhSach_Doc();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnInDS_ThongKeNhomDon_3To_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (CTaiKhoan.Admin || CTaiKhoan.TruongPhong || CTaiKhoan.ToTruong)
            {
                if (cmbTo.SelectedIndex > -1)
                    dt = _cDonTu.getDS_ThongKeNhomDon(cmbTo.SelectedValue.ToString(), dateTu_ThongKeNhomDon_3To.Value, dateDen_ThongKeNhomDon_3To.Value);
            }
            else
                dt = _cDonTu.getDS_ThongKeNhomDon(CTaiKhoan.KyHieuMaTo, dateTu_ThongKeNhomDon_3To.Value, dateDen_ThongKeNhomDon_3To.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow[] checkExists = dsBaoCao.Tables["DanhSach"].Select("MaDon = '" + item["MaDon"] + "'");
                if (checkExists.Length == 0)
                {
                    DataRow dr = dsBaoCao.Tables["DanhSach"].NewRow();

                    dr["TuNgay"] = dateTu_ThongKeNhomDon_3To.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen_ThongKeNhomDon_3To.Value.ToString("dd/MM/yyyy");
                    dr["LoaiBaoCao"] = CTaiKhoan.TenTo.ToUpper();
                    dr["MaDon"] = item["MaDon"];
                    dr["DanhBo"] = item["DanhBo"];
                    dr["HoTen"] = item["HoTen"];
                    dr["DiaChi"] = item["DiaChi"];
                    dr["NhomDon"] = item["NhomDon"];
                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                    dsBaoCao.Tables["DanhSach"].Rows.Add(dr);
                }
            }

            rptDanhSach_Doc_GroupNhomDon rpt = new rptDanhSach_Doc_GroupNhomDon();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    DataTable dtExport = new DataTable();
                    dtExport.Columns.Add("DanhBo", typeof(String));
                    dtExport.Columns.Add("HoTen", typeof(String));
                    dtExport.Columns.Add("DiaChi", typeof(String));
                    dtExport.Columns.Add("Phuong", typeof(String));
                    dtExport.Columns.Add("Quan", typeof(String));

                    //CExcel fileExcel = new CExcel(dialog.FileName);
                    //DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");
                    //foreach (DataRow item in dtExcel.Rows)
                    //    if (!string.IsNullOrEmpty(item[0].ToString()) && item[0].ToString().Replace(" ", "").Length == 11)
                    //    {
                    //        HOADON hd = _cThuTien.GetMoiNhat(item[0].ToString().Replace(" ", ""));
                    //        if (hd != null)
                    //        {
                    //            DataRow dr = dtExport.NewRow();
                    //            dr["DanhBo"] = hd.DANHBA;
                    //            dr["HoTen"] = hd.TENKH;
                    //            dr["DiaChi"] = hd.SO + " " + hd.DUONG;
                    //            dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(hd.Quan),hd.Phuong);
                    //            dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(hd.Quan));
                    //            dtExport.Rows.Add(dr);
                    //        }
                    //    }

                    //Create COM Objects. Create a COM object for everything that is referenced
                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(dialog.FileName);
                    Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                    Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;

                    //iterate over the rows and columns and print to the console as it appears in the file
                    //excel is not zero based!!
                    for (int i = 1; i <= rowCount; i++)
                    {
                        if (xlRange.Cells[i, 1] != null && xlRange.Cells[i, 1].Value2 != null && !string.IsNullOrEmpty(xlRange.Cells[i, 1].Value2.ToString()) && xlRange.Cells[i, 1].Value2.ToString().Replace(" ", "").Length == 11)
                        {
                            HOADON hd = _cThuTien.GetMoiNhat(xlRange.Cells[i, 1].Value2.ToString().Replace(" ", ""));
                            if (hd != null)
                            {
                                DataRow dr = dtExport.NewRow();
                                dr["DanhBo"] = hd.DANHBA;
                                dr["HoTen"] = hd.TENKH;
                                dr["DiaChi"] = hd.SO + " " + hd.DUONG;
                                dr["Phuong"] = _cDonTu.getTenPhuong(int.Parse(hd.Quan), int.Parse(hd.Phuong));
                                dr["Quan"] = _cDonTu.getTenQuan(int.Parse(hd.Quan));
                                dtExport.Rows.Add(dr);
                            }
                        }
                    }

                    //cleanup
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    //rule of thumb for releasing com objects:
                    //  never use two dots, all COM objects must be referenced and released individually
                    //  ex: [somthing].[something].[something] is bad
                    //release com objects to fully kill excel process from running in the background
                    Marshal.ReleaseComObject(xlRange);
                    Marshal.ReleaseComObject(xlWorksheet);
                    //close and release
                    xlWorkbook.Close();
                    Marshal.ReleaseComObject(xlWorkbook);
                    //quit and release
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);

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
                    //oSheetCQ = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(2);

                    XuatExcel(dtExport, oSheet, "Thông Tin Khách Hàng");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XuatExcel(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName)
        {
            oSheet.Name = SheetName;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
            cl1.Value2 = "Danh Bộ";
            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
            cl2.Value2 = "Khách Hàng";
            cl2.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
            cl3.Value2 = "Địa Chỉ";
            cl3.ColumnWidth = 50;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
            cl4.Value2 = "Phường";
            cl4.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E1", "E1");
            cl5.Value2 = "Quận";
            cl5.ColumnWidth = 15;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 5];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = dr["DanhBo"].ToString();
                arr[i, 1] = dr["HoTen"].ToString();
                arr[i, 2] = dr["DiaChi"].ToString();
                arr[i, 3] = dr["Phuong"].ToString();
                arr[i, 4] = dr["Quan"].ToString();
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 5;

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

            Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
            Microsoft.Office.Interop.Excel.Range c2e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
            Microsoft.Office.Interop.Excel.Range c3e = oSheet.get_Range(c1e, c2e);
            c3e.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            c3e.NumberFormat = "@";

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }

        private void btnBaoCao_ThongKeDonTon_Click(object sender, EventArgs e)
        {
            DataTable dt = _cDonTu.getDS_ThongKeDonTu_Ton(dateTu_ThongKeDonTon.Value, dateDen_ThongKeDonTon.Value);

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DanhSach"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeDonTon.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeDonTon.Value.ToString("dd/MM/yyyy");
                dr["LoaiBaoCao"] = "TỒN";
                dr["MaDonChiTiet"] = item["MaDonChiTiet"];
                dr["MaDon"] = item["MaDon"];
                dr["NhomDon"] = item["TinhTrang"];
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                dr["NguoiLap"] = CTaiKhoan.HoTen;

                dsBaoCao.Tables["DanhSach"].Rows.Add(dr);
            }

            rptDanhSach_Doc_GroupNhomDon rpt2 = new rptDanhSach_Doc_GroupNhomDon();
            rpt2.SetDataSource(dsBaoCao);
            frmShowBaoCao frm2 = new frmShowBaoCao(rpt2);
            frm2.Show();

            rptThongKeDonTu_Ton rpt = new rptThongKeDonTu_Ton();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnIn_NhanDon_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = _cDonTu.getDS_LichSu(dateTu_NhanDon.Value, dateDen_NhanDon.Value, int.Parse(cmbNoiNhan_NhanDon.SelectedValue.ToString()));

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["CongVan"].NewRow();

                dr["TuNgay"] = dateTu_NhanDon.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_NhanDon.Value.ToString("dd/MM/yyyy");
                dr["Ma"] = item["MaDon"].ToString();
                dr["MaChiTiet"] = item["MaDonChiTiet"].ToString();
                dr["CreateDate"] = item["NgayChuyen"].ToString();
                if (item["DanhBo"].ToString().Length == 11)
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["DiaChi"] = item["DiaChi"].ToString();
                dr["NoiDung"] = item["NoiDungDon"].ToString();
                dr["NoiNhan"] = item["NoiNhan"].ToString();
                dr["GhiChu"] = item["NoiDung"].ToString();
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                dr["NguoiLap"] = CTaiKhoan.HoTen;

                dsBaoCao.Tables["CongVan"].Rows.Add(dr);
            }
            rptDSChuyenDonTu rpt = new rptDSChuyenDonTu();
            rpt.SetDataSource(dsBaoCao);
            rpt.Subreports[0].SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnBaoCao_DonChuyenDe_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = _cDonTu.getDSDonChuyenDe(dateTu_DonChuyenDe.Value, dateDen_DonChuyenDe.Value);

            int SLThuMoi = 0, SLXuLy = 0, SLDanhBoTang = 0, SLDinhMucTang = 0
                , SLDanhBoGiam = 0, SLDinhMucGiam = 0, SLDanhBoKhongDoi = 0, SLLapTruyThu = 0;
            foreach (DataRow item in dt.Rows)
            {
                if (item["CanKhachHangLienHe"] != null && item["CanKhachHangLienHe"].ToString() != "")
                {
                    if (bool.Parse(item["CanKhachHangLienHe"].ToString()) == true)
                        SLThuMoi++;
                    else
                        if (item["DinhMuc"].ToString() != "" && item["DinhMucMoi"].ToString() != "")
                        {
                            SLXuLy++;
                            if (int.Parse(item["DinhMucMoi"].ToString()) - int.Parse(item["DinhMuc"].ToString()) > 0)
                            {
                                SLDanhBoTang++;
                                SLDinhMucTang += int.Parse(item["DinhMucMoi"].ToString()) - int.Parse(item["DinhMuc"].ToString());
                            }
                            else
                                if (int.Parse(item["DinhMuc"].ToString()) - int.Parse(item["DinhMucMoi"].ToString()) > 0)
                                {
                                    SLDanhBoGiam++;
                                    SLDinhMucGiam += int.Parse(item["DinhMuc"].ToString()) - int.Parse(item["DinhMucMoi"].ToString());
                                }
                                else
                                    if (int.Parse(item["DinhMuc"].ToString()) - int.Parse(item["DinhMucMoi"].ToString()) == 0)
                                        SLDanhBoKhongDoi++;
                            if (bool.Parse(item["LapTruyThu"].ToString()) == true)
                                SLLapTruyThu++;
                        }
                }
            }
            int countMaDon = dt.AsEnumerable()
              .Select(s => new
              {
                  value = s.Field<int>("MaDon"),
              })
              .Distinct().ToList().Count();

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            DataRow dr = dsBaoCao.Tables["DanhSachDonKH"].NewRow();

            dr["TuNgay"] = dateTu_DonChuyenDe.Value.ToString("dd/MM/yyyy");
            dr["DenNgay"] = dateDen_DonChuyenDe.Value.ToString("dd/MM/yyyy");
            dr["SLDon"] = countMaDon;
            dr["SLDanhBo"] = dt.Rows.Count;
            dr["SLThuMoi"] = SLThuMoi;
            dr["SLXuLy"] = SLXuLy;
            dr["SLDanhBoTang"] = SLDanhBoTang;
            dr["SLDinhMucTang"] = SLDinhMucTang;
            dr["SLDanhBoGiam"] = SLDanhBoGiam;
            dr["SLDinhMucGiam"] = SLDinhMucGiam;
            dr["SLDanhBoKhongDoi"] = SLDanhBoKhongDoi;
            dr["SLLapTruyThu"] = SLLapTruyThu;

            dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
            dr["NguoiLap"] = CTaiKhoan.HoTen;

            dsBaoCao.Tables["DanhSachDonKH"].Rows.Add(dr);

            rptThongKeDonChuyenDe rpt = new rptThongKeDonChuyenDe();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.TruyThu;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.TruyThu;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.TruyThu
{
    public partial class frmBaoCaoTruyThu : Form
    {
        CTruyThuTienNuoc _cTTTN = new CTruyThuTienNuoc();

        public frmBaoCaoTruyThu()
        {
            InitializeComponent();
        }

        private void frmBaoCaoTruyThu_Load(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_ThongKeTruyThu_Click(object sender, EventArgs e)
        {
            DataTable dt = _cTTTN.getDS(dateTu_ThongKeTruyThu.Value, dateDen_ThongKeTruyThu.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeTruyThu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeTruyThu.Value.ToString("dd/MM/yyyy");
                dr["MaDon"] = item["MaDon"];
                dr["NoiDung"] = item["TinhTrang"];
                dr["TieuThuMoi"] = item["Tongm3BinhQuan"];
                dr["TongCongMoi"] = item["TongTien"];
                dr["NhanVien"] = CTaiKhoan.HoTen;
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                dr["NguoiKy"] = CTaiKhoan.NguoiKy;

                dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
            }

            rptThongKeTruyThu rpt = new rptThongKeTruyThu();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            if (cmbTinhTrang.SelectedIndex == -1)
                return;
            DataTable dt = new DataTable();
            if (cmbTinhTrang.SelectedIndex == 0)
                dt = _cTTTN.getDS(dateTu_ThongKeTruyThu.Value, dateDen_ThongKeTruyThu.Value);
            else
                if (cmbTinhTrang.SelectedIndex > 0)
                    dt = _cTTTN.getDS(dateTu_ThongKeTruyThu.Value, dateDen_ThongKeTruyThu.Value, cmbTinhTrang.Text);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            //if (item["TinhTrang"].ToString() ==cmbTinhTrang.SelectedItem.ToString() )
            {
                DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeTruyThu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeTruyThu.Value.ToString("dd/MM/yyyy");
                dr["LoaiBaoCao"] = cmbTinhTrang.Text.ToUpper();
                dr["MaDon"] = item["MaDon"].ToString();
                dr["ID"] = item["IDCT"].ToString().Insert(item["IDCT"].ToString().Length - 2, "-");
                dr["SoCongVan"] = item["SoCongVan"];
                dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item["HoTen"];
                dr["DiaChi"] = item["DiaChi"];
                dr["NoiDung"] = item["NoiDung"];

                dr["TieuThuMoi"] = item["Tongm3BinhQuan"];
                dr["TongCongMoi"] = item["TongTien"];
                dr["NhanVien"] = CTaiKhoan.HoTen;
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                dr["NguoiKy"] = CTaiKhoan.NguoiKy;

                dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
            }

            rptDSTruyThuTienNuoc rpt = new rptDSTruyThuTienNuoc();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnIn_TheoTinhTrang_Click(object sender, EventArgs e)
        {
            if (cmbTinhTrang_TheoTinhTrang.SelectedIndex == -1)
                return;
            DataTable dt = new DataTable();
            if (cmbTinhTrang_TheoTinhTrang.SelectedIndex == 0)
                dt = _cTTTN.getDS();
            else
                if (cmbTinhTrang_TheoTinhTrang.SelectedIndex > 0)
                    dt = _cTTTN.getDS_TinhTrang(cmbTinhTrang_TheoTinhTrang.Text);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            //if (item["TinhTrang"].ToString() ==cmbTinhTrang.SelectedItem.ToString() )
            {
                DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeTruyThu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeTruyThu.Value.ToString("dd/MM/yyyy");
                dr["LoaiBaoCao"] = cmbTinhTrang_TheoTinhTrang.Text.ToUpper();
                dr["MaDon"] = item["MaDon"].ToString();
                dr["ID"] = item["IDCT"].ToString().Insert(item["IDCT"].ToString().Length-2, "-");
                dr["SoCongVan"] = item["SoCongVan"];
                dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item["HoTen"];
                dr["DiaChi"] = item["DiaChi"];
                dr["NoiDung"] = item["NoiDung"];

                dr["TieuThuMoi"] = item["Tongm3BinhQuan"];
                dr["TongCongMoi"] = item["TongTien"];
                dr["NhanVien"] = CTaiKhoan.HoTen;
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                dr["NguoiKy"] = CTaiKhoan.NguoiKy;

                dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
            }

            rptDSTruyThuTienNuoc rpt = new rptDSTruyThuTienNuoc();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnBaoCao_TheoTinhTrang_Click(object sender, EventArgs e)
        {
            DataTable dt = _cTTTN.getDS();
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeTruyThu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeTruyThu.Value.ToString("dd/MM/yyyy");
                dr["MaDon"] = item["MaDon"];
                dr["NoiDung"] = item["TinhTrang"];
                dr["TieuThuMoi"] = item["Tongm3BinhQuan"];
                dr["TongCongMoi"] = item["TongTien"];
                dr["NhanVien"] = CTaiKhoan.HoTen;
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                dr["NguoiKy"] = CTaiKhoan.NguoiKy;

                dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
            }

            rptThongKeTruyThu rpt = new rptThongKeTruyThu();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }
    }
}

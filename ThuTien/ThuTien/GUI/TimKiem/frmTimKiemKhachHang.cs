﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL;
using ThuTien.DAL.TongHop;
using ThuTien.LinQ;
using ThuTien.DAL.Quay;
using CrystalDecisions.CrystalReports.Engine;
using KTKS_DonKH.GUI.BaoCao;
using ThuTien.BaoCao.TimKiem;
using ThuTien.BaoCao;

namespace ThuTien.GUI.TimKiem
{
    public partial class frmTimKiemKhachHang : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CKTKS_DonKH _cKinhDoanh = new CKTKS_DonKH();
        CChuyenNoKhoDoi _cCNKD = new CChuyenNoKhoDoi();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CCAPNUOCTANHOA _cCapNuocTanHoa = new CCAPNUOCTANHOA();

        public frmTimKiemKhachHang()
        {
            InitializeComponent();
        }

        private void frmTimKiemKhachHang_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvKinhDoanh.AutoGenerateColumns = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = _cHoaDon.GetDSTimKiem(txtDanhBo.Text.Trim(), txtHoTen.Text.Trim(), txtDiaChi.Text.Trim());
            dgvKinhDoanh.DataSource = _cKinhDoanh.GetDSP_KinhDoanh(txtDanhBo.Text.Trim());

            foreach (DataGridViewRow item in dgvHoaDon.Rows)
            {
                if(_cDongNuoc.CheckCTDongNuocBySoHoaDon(item.Cells["SoHoaDon"].Value.ToString()))
                    item.DefaultCellStyle.BackColor = Color.Yellow;
                if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon"].Value.ToString()))
                {
                    item.Cells["TinhTrang"].Value = _cLenhHuy.GetTinhTrangBySoHoaDon(item.Cells["SoHoaDon"].Value.ToString());
                    item.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "GiaBan" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "ThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "PhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "NgayDN")
            {
                if (_cCNKD.CheckExist(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString()))
                {
                    TT_ChuyenNoKhoDoi cnkd = _cCNKD.GetBySoHoaDon(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString());

                    dgvHoaDon["NgayGiaiTrach", e.RowIndex].Value = cnkd.CreateDate.Value.ToString("dd/MM/yyyy");
                    dgvHoaDon["DangNgan", e.RowIndex].Value = "CNKĐ";
                }
            }
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiem.PerformClick();
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiem.PerformClick();
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiem.PerformClick();
        }

        private void btnInPhieuTieuThu_Click(object sender, EventArgs e)
        {
            //DataTable dtTieuThu = _cHoaDon.GetDSTieuThu(txtDanhBo.Text.Trim());

            DataTable dtPhieuTieuThu = _cCapNuocTanHoa.GetTTKH(txtDanhBo.Text.Trim());
            
            DataTable dtGhiChu = _cCapNuocTanHoa.GetGhiChu(txtDanhBo.Text.Trim());

            dsBaoCao ds = new dsBaoCao();

            if (dtPhieuTieuThu.Rows.Count > 0)
            {
                DataRow dr = ds.Tables["PhieuTieuThu"].NewRow();
                dr["DanhBo"] = dtPhieuTieuThu.Rows[0]["DanhBo"];
                dr["HopDong"] = dtPhieuTieuThu.Rows[0]["HopDong"];
                dr["GiaBieu"] = dtPhieuTieuThu.Rows[0]["GiaBieu"];
                dr["DinhMuc"] = dtPhieuTieuThu.Rows[0]["DinhMuc"];
                dr["MLT"] = dtPhieuTieuThu.Rows[0]["MLT"];
                dr["Hieu"] = dtPhieuTieuThu.Rows[0]["Hieu"];
                dr["Co"] = dtPhieuTieuThu.Rows[0]["Co"];
                dr["SoThan"] = dtPhieuTieuThu.Rows[0]["SoThan"];
                dr["ViTri"] = dtPhieuTieuThu.Rows[0]["ViTri"];
                dr["HoTen"] = dtPhieuTieuThu.Rows[0]["HoTen"];
                dr["DiaChi"] = dtPhieuTieuThu.Rows[0]["DiaChi"];
                dr["DienThoai"] = dtPhieuTieuThu.Rows[0]["DienThoai"];
                if (dgvHoaDon.Rows.Count > 0)
                    dr["HanhThu"] = dgvHoaDon["HanhThu",0].Value.ToString();
                ds.Tables["PhieuTieuThu"].Rows.Add(dr);
            }

            //foreach (DataRow item in dtTieuThu.Rows)
            //{
            //    DataRow dr = ds.Tables["TieuThu"].NewRow();
            //    dr["Ky"] = item["Ky"];
            //    dr["SoHoaDon"] = item["SoHoaDon"];
            //    dr["TieuThu"] = item["TieuThu"];
            //    dr["TongCong"] = item["TongCong"];
            //    dr["NgayGiaiTrach"] = item["NgayGiaiTrach"];
            //    ds.Tables["TieuThu"].Rows.Add(dr);
            //}
            if(dgvHoaDon.RowCount>10)
                for (int i = 0; i < 10; i++)
                {
                    DataRow dr = ds.Tables["TieuThu"].NewRow();
                    dr["Ky"] = dgvHoaDon["Ky", i].Value.ToString();
                    dr["NgayDoc"] = dgvHoaDon["NgayDoc", i].Value.ToString();
                    dr["ChiSo"] = dgvHoaDon["ChiSo", i].Value.ToString();
                    dr["TieuThu"] = dgvHoaDon["TieuThu", i].Value.ToString();
                    dr["TongCong"] = dgvHoaDon["TongCong", i].Value.ToString();
                    dr["NgayGiaiTrach"] = dgvHoaDon["NgayGiaiTrach", i].Value.ToString();
                    ds.Tables["TieuThu"].Rows.Add(dr);
                }
            else
                for (int i = 0; i < dgvHoaDon.RowCount; i++)
                {
                    DataRow dr = ds.Tables["TieuThu"].NewRow();
                    dr["Ky"] = dgvHoaDon["Ky", i].Value.ToString();
                    dr["NgayDoc"] = dgvHoaDon["NgayDoc", i].Value.ToString();
                    dr["ChiSo"] = dgvHoaDon["ChiSo", i].Value.ToString();
                    dr["TieuThu"] = dgvHoaDon["TieuThu", i].Value.ToString();
                    dr["TongCong"] = dgvHoaDon["TongCong", i].Value.ToString();
                    dr["NgayGiaiTrach"] = dgvHoaDon["NgayGiaiTrach", i].Value.ToString();
                    ds.Tables["TieuThu"].Rows.Add(dr);
                }

            foreach (DataRow item in dtGhiChu.Rows)
            {
                DataRow dr = ds.Tables["GhiChu"].NewRow();
                dr["CreateDate"] = item["CreateDate"];
                dr["NoiDung"] = item["NoiDung"];
                ds.Tables["GhiChu"].Rows.Add(dr);
            }

            ReportDocument rpt = new rptPhieuTieuThu();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }
        
    }
}

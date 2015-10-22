﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.BaoCao;
using ThuTien.GUI.BaoCao;
using ThuTien.BaoCao.ToTruong;
using System.Globalization;
using ThuTien.DAL.Quay;
using ThuTien.LinQ;
using ThuTien.DAL;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmTongHopNo : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();
        CKTKS_DonKH _cKTKS_DonKH = new CKTKS_DonKH();
        BindingSource bsHoaDon = new BindingSource();
        DataTable dt = new DataTable();

        public frmTongHopNo()
        {
            InitializeComponent();

            dateThanhToan.Value = DateTime.Now;
        }

        private void frmTongHopNo_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvHoaDon.DataSource = bsHoaDon;

            //DataTable dt = new DataTable();
            DataColumn col = new DataColumn("MaHD");
            col.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(col);
            //DataColumn[] columns = new DataColumn[1];
            //columns[0] = dt.Columns["MaHD"];
            //dt.PrimaryKey = columns;

            col = new DataColumn("HoTen");
            col.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(col);

            col = new DataColumn("DanhBo");
            col.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(col);

            col = new DataColumn("DiaChi");
            col.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(col);

            col = new DataColumn("Ky");
            col.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(col);

            col = new DataColumn("GiaBieu");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);

            col = new DataColumn("DinhMuc");
            col.DataType = System.Type.GetType("System.Int32");

            dt.Columns.Add(col);
            col = new DataColumn("TieuThu");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);

            col = new DataColumn("GiaBan");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);

            col = new DataColumn("ThueGTGT");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);

            col = new DataColumn("PhiBVMT");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);

            col = new DataColumn("TongCong");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);

            //bsHoaDon.DataSource = dt;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DataTable dtTemp = _cHoaDon.GetDSTonByDanhBo(txtDanhBo.Text.Trim());
                if (dtTemp.Rows.Count > 0)
                {
                    foreach (DataRow item in dtTemp.Rows)
                        //if (!dt.Rows.Contains(item["MaHD"].ToString()))
                        {
                            DataRow row = dt.NewRow();
                            row["MaHD"] = item["MaHD"];
                            row["DanhBo"] = item["DanhBo"];
                            row["DiaChi"] = item["DiaChi"];
                            row["Ky"] = item["Ky"];
                            row["TieuThu"] = item["TieuThu"];
                            row["GiaBan"] = item["GiaBan"];
                            row["ThueGTGT"] = item["ThueGTGT"];
                            row["PhiBVMT"] = item["PhiBVMT"];
                            row["TongCong"] = item["TongCong"];
                            dt.Rows.Add(row);
                        }
                }
                else
                {
                    HOADON hoadon = _cHoaDon.GetMoiNhat(txtDanhBo.Text.Trim());

                    DataRow row = dt.NewRow();
                    row["MaHD"] = hoadon.ID_HOADON;
                    row["HoTen"] = hoadon.TENKH;
                    row["DanhBo"] = hoadon.DANHBA;
                    row["DiaChi"] = hoadon.SO+" "+hoadon.DUONG;
                    row["GiaBieu"] = hoadon.GB;
                    if (hoadon.DM != null)
                        row["DinhMuc"] = hoadon.DM;
                    row["TieuThu"] = 0;

                    dt.Rows.Add(row);
                }
                bsHoaDon.DataSource = dt;
                txtDanhBo.Text = "";
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            CTamThu _cTamThu = new CTamThu();
            dsBaoCao ds = new dsBaoCao();
            int TongCongSo = 0;
            foreach (DataGridViewRow item in dgvHoaDon.Rows)
            {
                DataRow dr = ds.Tables["TongHopNo"].NewRow();
                dr["KinhGui"] = txtKinhGui.Text.Trim();
                dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                dr["Ky"] = item.Cells["Ky"].Value.ToString();
                dr["TieuThu"] = item.Cells["TieuThu"].Value.ToString();
                dr["GiaBan"] = item.Cells["GiaBan"].Value.ToString();
                dr["ThueGTGT"] = item.Cells["ThueGTGT"].Value.ToString();
                dr["PhiBVMT"] = item.Cells["PhiBVMT"].Value.ToString();
                dr["TongCong"] = item.Cells["TongCong"].Value.ToString();
                TongCongSo += int.Parse(item.Cells["TongCong"].Value.ToString());
                dr["CSM"] = txtCSM.Text.Trim();
                dr["CSC"] = txtCSC.Text.Trim();
                dr["TT"] = txtTT.Text.Trim();
                dr["DM"] = txtDM.Text.Trim();
                
                ds.Tables["TongHopNo"].Rows.Add(dr);
            }
            DataRow dr1 = ds.Tables["TongHopNo"].NewRow();
            dr1["TongCongChu"] = _cTamThu.ConvertMoneyToWord(TongCongSo.ToString());
            dr1["NgayThanhToan"] = dateThanhToan.Value.ToString("dd/MM/yyyy");
            ds.Tables["TongHopNo"].Rows.Add(dr1);
            rptTongHopNo rpt = new rptTongHopNo();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "GiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "ThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "PhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHoaDon_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TieuThu" && e.FormattedValue.ToString().Replace(",", "") != dgvHoaDon[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                string ChiTiet = "";
                int DM = 0;
                if (dgvHoaDon["DinhMuc", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvHoaDon["DinhMuc", e.RowIndex].Value.ToString()))
                    DM = int.Parse(dgvHoaDon["DinhMuc", e.RowIndex].Value.ToString());
                int TongTien = _cKTKS_DonKH.TinhTienNuoc(false, 0, dgvHoaDon["DanhBo", e.RowIndex].Value.ToString(), int.Parse(dgvHoaDon["GiaBieu", e.RowIndex].Value.ToString()), DM, int.Parse(e.FormattedValue.ToString().Replace(".", "")), out ChiTiet);
                dgvHoaDon["GiaBan", e.RowIndex].Value = TongTien;
                dgvHoaDon["ThueGTGT", e.RowIndex].Value = Math.Round((double)TongTien * 5 / 100);
                dgvHoaDon["PhiBVMT", e.RowIndex].Value = TongTien * 10 / 100;
                dgvHoaDon["TongCong", e.RowIndex].Value = TongTien + Math.Round((double)TongTien * 5 / 100) + (TongTien * 10 / 100);
            }
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtKinhGui.Text = dgvHoaDon["HoTen", e.RowIndex].Value.ToString();
            }
            catch
            {
            }
        }

        
    }
}

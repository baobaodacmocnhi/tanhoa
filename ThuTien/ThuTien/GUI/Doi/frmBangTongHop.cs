﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.DAL.Doi;
using System.Globalization;
using ThuTien.BaoCao;
using ThuTien.BaoCao.Doi;
using ThuTien.GUI.BaoCao;
using ThuTien.DAL.TongHop;

namespace ThuTien.GUI.Doi
{
    public partial class frmBangTongHop : Form
    {
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();
        CChuyenNoKhoDoi _cCNKD = new CChuyenNoKhoDoi();
        CDCHD _cDCHD = new CDCHD();

        public frmBangTongHop()
        {
            InitializeComponent();
        }

        private void frmBangTongHop_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;

            List<TT_To> lst = _cTo.getDS_HanhThu();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            lst.Insert(0, to);
            cmbTo.DataSource = lst;
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
        }

        public void LoadDataGridView()
        {
            int TongHDThu = 0;
            long TongCongThu = 0;
            if (dgvHoaDon.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
                {
                    TongHDThu += int.Parse(item.Cells["TongHDThu"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongThu"].Value.ToString()))
                        TongCongThu += long.Parse(item.Cells["TongCongThu"].Value.ToString());
                }
                txtTongHDThu.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDThu);
                txtTongCongThu.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongThu);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            List<TT_To> lst = _cTo.getDS_HanhThu();

            dt = _cHoaDon.GetBangTongHop(lst[0].MaTo, dateTu.Value, dateDen.Value);
            for (int i = 1; i < lst.Count; i++)
            {
                dt.Merge(_cHoaDon.GetBangTongHop(lst[i].MaTo, dateTu.Value, dateDen.Value));
            }
            dgvHoaDon.DataSource = dt;
            LoadDataGridView();
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongHDThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCongThu" && e.Value != null)
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

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (cmbKy.SelectedIndex != -1)
            {
                DateTime NgayGiaiTrachNow = new DateTime(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), DateTime.DaysInMonth(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                DateTime NgayGiaiTrachOld = NgayGiaiTrachNow.AddMonths(-1);
                NgayGiaiTrachOld = new DateTime(NgayGiaiTrachOld.Year, NgayGiaiTrachOld.Month, DateTime.DaysInMonth(NgayGiaiTrachOld.Year, NgayGiaiTrachOld.Month));

                dsBaoCao ds = new dsBaoCao();
                dsBaoCao dsBangTinh = new dsBaoCao();

                DataTable dtDoi = _cHoaDon.GetBaoCaoTongHop_Doi("TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), NgayGiaiTrachNow, NgayGiaiTrachOld);
                dtDoi.Merge(_cHoaDon.GetBaoCaoTongHop_Doi("CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), NgayGiaiTrachNow, NgayGiaiTrachOld));

                /////lấy chuẩn thu của kỳ
                //DataTable dtDCHD = _cDCHD.GetChuanThu_Doi("TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                //dtDCHD.Merge(_cDCHD.GetChuanThu_Doi("CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                //foreach (DataRow item in dtDCHD.Rows)
                //{
                //    DataRow[] drDoi = dtDoi.Select("Loai='" + item["Loai"] + "'");
                //    drDoi[0]["GTChuanThu"] = long.Parse(drDoi[0]["GTChuanThu"].ToString()) - long.Parse(item["TONGCONG_END"].ToString()) + long.Parse(item["TONGCONG_BD"].ToString());
                //}

                DataTable dtDCHDChuanThu = new DataTable();
                DataTable dtDCHDTonCuKy = new DataTable();
                DataTable dtDCHDTonTrongKy = new DataTable();
                DataTable dtDCHDTongTon = new DataTable();
                List<TT_To> lstTo = _cTo.getDS_HanhThu();

                DataTable dtTo = new DataTable();
                for (int i = 0; i < lstTo.Count; i++)
                {
                    dtTo.Merge(_cHoaDon.GetBaoCaoTongHop_To("TG", lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), NgayGiaiTrachNow, NgayGiaiTrachOld));
                    dtTo.Merge(_cHoaDon.GetBaoCaoTongHop_To("CQ", lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), NgayGiaiTrachNow, NgayGiaiTrachOld));

                    dtDCHDChuanThu.Merge(_cDCHD.GetChuanThu("TG", lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                    dtDCHDChuanThu.Merge(_cDCHD.GetChuanThu("CQ", lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));

                    dtDCHDTonCuKy.Merge(_cDCHD.GetChuanThuTonDenKyDenNgay("TG", lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()) - 1, NgayGiaiTrachOld));
                    dtDCHDTonCuKy.Merge(_cDCHD.GetChuanThuTonDenKyDenNgay("CQ", lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()) - 1, NgayGiaiTrachOld));

                    dtDCHDTonTrongKy.Merge(_cDCHD.GetChuanThuTonTrongKyDenNgay("TG", lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), NgayGiaiTrachNow));
                    dtDCHDTonTrongKy.Merge(_cDCHD.GetChuanThuTonTrongKyDenNgay("CQ", lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), NgayGiaiTrachNow));

                    dtDCHDTongTon.Merge(_cDCHD.GetChuanThuTonDenKyDenNgay("TG", lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), NgayGiaiTrachNow));
                    dtDCHDTongTon.Merge(_cDCHD.GetChuanThuTonDenKyDenNgay("CQ", lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), NgayGiaiTrachNow));
                }

                foreach (DataRow item in dtDCHDChuanThu.Rows)
                {
                    DataRow[] drDoi = dtDoi.Select("Loai='" + item["Loai"] + "'");
                    drDoi[0]["GTChuanThu"] = long.Parse(drDoi[0]["GTChuanThu"].ToString()) - long.Parse(item["TONGCONG_DC"].ToString()) ;

                    DataRow[] drTo = dtTo.Select("TenTo='" + item["TenTo"] + "' and Loai='" + item["Loai"] + "'");
                    drTo[0]["GTChuanThu"] = long.Parse(drTo[0]["GTChuanThu"].ToString()) - long.Parse(item["TONGCONG_DC"].ToString()) ;
                }

                foreach (DataRow item in dtDCHDTonCuKy.Rows)
                {
                    DataRow[] drDoi = dtDoi.Select("Loai='" + item["Loai"] + "'");
                    drDoi[0]["GTTonCu"] = long.Parse(drDoi[0]["GTTonCu"].ToString()) - long.Parse(item["TONGCONG_DC"].ToString()) ;

                    DataRow[] drTo = dtTo.Select("TenTo='" + item["TenTo"] + "' and Loai='" + item["Loai"] + "'");
                    drTo[0]["GTTonCu"] = long.Parse(drTo[0]["GTTonCu"].ToString()) - long.Parse(item["TONGCONG_DC"].ToString());
                }

                foreach (DataRow item in dtDCHDTonTrongKy.Rows)
                {
                    DataRow[] drDoi = dtDoi.Select("Loai='" + item["Loai"] + "'");
                    drDoi[0]["GTTonThu"] = long.Parse(drDoi[0]["GTTonThu"].ToString()) - long.Parse(item["TONGCONG_DC"].ToString()) ;

                    DataRow[] drTo = dtTo.Select("TenTo='" + item["TenTo"] + "' and Loai='" + item["Loai"] + "'");
                    drTo[0]["GTTonThu"] = long.Parse(drTo[0]["GTTonThu"].ToString()) - long.Parse(item["TONGCONG_DC"].ToString()) ;
                }

                foreach (DataRow item in dtDCHDTongTon.Rows)
                {
                    DataRow[] drDoi = dtDoi.Select("Loai='" + item["Loai"] + "'");
                    drDoi[0]["GTTongTon"] = long.Parse(drDoi[0]["GTTongTon"].ToString()) - long.Parse(item["TONGCONG_DC"].ToString()) ;

                    DataRow[] drTo = dtTo.Select("TenTo='" + item["TenTo"] + "' and Loai='" + item["Loai"] + "'");
                    drTo[0]["GTTongTon"] = long.Parse(drTo[0]["GTTongTon"].ToString()) - long.Parse(item["TONGCONG_DC"].ToString()) ;
                }

                foreach (DataRow item in dtDoi.Rows)
                {
                    DataRow dr = ds.Tables["BaoCaoTongHop"].NewRow();
                    ///chỉ lấy hóa đơn
                    DataRow drBangTinh = dsBangTinh.Tables["BaoCaoTongHop"].NewRow();

                    dr["Ky"] = drBangTinh["Ky"] = cmbKy.SelectedItem.ToString();
                    dr["Nam"] = drBangTinh["Nam"] = cmbNam.SelectedValue.ToString();
                    dr["To"] = drBangTinh["To"] = item["TenTo"];
                    dr["Loai"] = drBangTinh["Loai"] = item["Loai"];
                    dr["LoaiBaoCao"] = "HĐ";
                    ///chỉ lấy hóa đơn
                    if (item["Loai"].ToString() == "TG")
                        dr["CNKD"] = drBangTinh["CNKD"] = _cCNKD.CountCT("TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    else
                        if (item["Loai"].ToString() == "CQ")
                            dr["CNKD"] = drBangTinh["CNKD"] = _cCNKD.CountCT("CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    dr["TonCu"] = drBangTinh["TonCu"] = item["HDTonCu"];
                    dr["TyLeTonCu"] = "100";
                    dr["ChuanThu"] = drBangTinh["ChuanThu"] = item["HDChuanThu"];
                    dr["TyLeChuanThu"] = "100";
                    dr["TonThu"] = item["HDTonThu"];
                    dr["TyLeTonThu"] = 100 - Math.Round(double.Parse(item["HDTonThu"].ToString()) / double.Parse(item["HDChuanThu"].ToString()) * 100, 2);
                    dr["TongTon"] = drBangTinh["TongTon"] = item["HDTongTon"];
                    dr["TyLeTongTon"] = "100";
                    dr["ThuDat"] = dr["TyLeTonThu"];
                    ds.Tables["BaoCaoTongHop"].Rows.Add(dr);

                    dsBangTinh.Tables["BaoCaoTongHop"].Rows.Add(drBangTinh);

                    DataRow dr2 = ds.Tables["BaoCaoTongHop"].NewRow();
                    dr2["Ky"] = cmbKy.SelectedItem.ToString();
                    dr2["Nam"] = cmbNam.SelectedValue.ToString();
                    dr2["To"] = item["TenTo"];
                    dr2["Loai"] = item["Loai"];
                    dr2["LoaiBaoCao"] = "GT";
                    dr2["TonCu"] = item["GTTonCu"];
                    dr2["TyLeTonCu"] = "100";
                    dr2["ChuanThu"] = item["GTChuanThu"];
                    dr2["TyLeChuanThu"] = "100";
                    dr2["TonThu"] = item["GTTonThu"];
                    dr2["TyLeTonThu"] = 100 - Math.Round(double.Parse(item["GTTonThu"].ToString()) / double.Parse(item["GTChuanThu"].ToString()) * 100, 2);
                    dr2["TongTon"] = item["GTTongTon"];
                    dr2["TyLeTongTon"] = "100";
                    dr2["ThuDat"] = dr["TyLeTonThu"];
                    ds.Tables["BaoCaoTongHop"].Rows.Add(dr2);
                }

                foreach (DataRow item in dtTo.Rows)
                {
                    DataRow dr = ds.Tables["BaoCaoTongHop"].NewRow();
                    ///chỉ lấy hóa đơn
                    DataRow drBangTinh = dsBangTinh.Tables["BaoCaoTongHop"].NewRow();

                    dr["Ky"] = drBangTinh["Ky"] = cmbKy.SelectedItem.ToString();
                    dr["Nam"] = drBangTinh["Nam"] = cmbNam.SelectedValue.ToString();
                    dr["To"] = drBangTinh["To"] = item["TenTo"];
                    dr["Loai"] = drBangTinh["Loai"] = item["Loai"];
                    dr["LoaiBaoCao"] = "HĐ";
                    ///chỉ lấy hóa đơn
                    if (item["Loai"].ToString() == "TG")
                        dr["CNKD"] = drBangTinh["CNKD"] = _cCNKD.CountCT("TG", int.Parse(item["MaTo"].ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    else
                        if (item["Loai"].ToString() == "CQ")
                            dr["CNKD"] = drBangTinh["CNKD"] = _cCNKD.CountCT("CQ", int.Parse(item["MaTo"].ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    dr["TonCu"] = drBangTinh["TonCu"] = item["HDTonCu"];
                    dr["TyLeTonCu"] = Math.Round(double.Parse(item["HDTonCu"].ToString()) / double.Parse(dtDoi.Compute("sum(HDTonCu)", "Loai='" + dr["Loai"] + "'").ToString()) * 100, 2);
                    dr["ChuanThu"] = drBangTinh["ChuanThu"] = item["HDChuanThu"];
                    dr["TyLeChuanThu"] = Math.Round(double.Parse(item["HDChuanThu"].ToString()) / double.Parse(dtDoi.Compute("sum(HDChuanThu)", "Loai='" + dr["Loai"] + "'").ToString()) * 100, 2);
                    dr["TonThu"] = item["HDTonThu"];
                    dr["TyLeTonThu"] = Math.Round(double.Parse(item["HDTonThu"].ToString()) / double.Parse(dtDoi.Compute("sum(HDTonThu)", "Loai='" + dr["Loai"] + "'").ToString()) * 100, 2);
                    dr["TongTon"] = drBangTinh["TongTon"] = item["HDTongTon"];
                    dr["TyLeTongTon"] = Math.Round(double.Parse(item["HDTongTon"].ToString()) / double.Parse(dtDoi.Compute("sum(HDTongTon)", "Loai='" + dr["Loai"] + "'").ToString()) * 100, 2);
                    dr["ThuDat"] = 100 - Math.Round(double.Parse(item["HDTonThu"].ToString()) / double.Parse(item["HDChuanThu"].ToString()) * 100, 2);
                    ds.Tables["BaoCaoTongHop"].Rows.Add(dr);

                    dsBangTinh.Tables["BaoCaoTongHop"].Rows.Add(drBangTinh);

                    DataRow dr2 = ds.Tables["BaoCaoTongHop"].NewRow();
                    dr2["Ky"] = cmbKy.SelectedItem.ToString();
                    dr2["Nam"] = cmbNam.SelectedValue.ToString();
                    dr2["To"] = item["TenTo"];
                    dr2["Loai"] = item["Loai"];
                    dr2["LoaiBaoCao"] = "GT";
                    dr2["TonCu"] = item["GTTonCu"];
                    dr2["TyLeTonCu"] = Math.Round(double.Parse(item["GTTonCu"].ToString()) / double.Parse(dtDoi.Compute("sum(GTTonCu)", "Loai='" + dr["Loai"] + "'").ToString()) * 100, 2);
                    dr2["ChuanThu"] = item["GTChuanThu"];
                    dr2["TyLeChuanThu"] = Math.Round(double.Parse(item["GTChuanThu"].ToString()) / double.Parse(dtDoi.Compute("sum(GTChuanThu)", "Loai='" + dr["Loai"] + "'").ToString()) * 100, 2);
                    dr2["TonThu"] = item["GTTonThu"];
                    dr2["TyLeTonThu"] = Math.Round(double.Parse(item["GTTonThu"].ToString()) / double.Parse(dtDoi.Compute("sum(GTTonThu)", "Loai='" + dr["Loai"] + "'").ToString()) * 100, 2);
                    dr2["TongTon"] = item["GTTongTon"];
                    dr2["TyLeTongTon"] = Math.Round(double.Parse(item["GTTongTon"].ToString()) / double.Parse(dtDoi.Compute("sum(GTTongTon)", "Loai='" + dr["Loai"] + "'").ToString()) * 100, 2);
                    dr2["ThuDat"] = 100 - Math.Round(double.Parse(item["GTTonThu"].ToString()) / double.Parse(item["GTChuanThu"].ToString()) * 100, 2);
                    ds.Tables["BaoCaoTongHop"].Rows.Add(dr2);
                }

                rptBaoCaoTongHop rpt = new rptBaoCaoTongHop();
                rpt.SetDataSource(ds);
                rpt.Subreports[0].SetDataSource(dsBangTinh);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
        }


    }
}

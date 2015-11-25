﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.QuanTri;
using System.Globalization;
using ThuTien.BaoCao;
using ThuTien.GUI.BaoCao;
using ThuTien.BaoCao.ToTruong;
using ThuTien.LinQ;
using ThuTien.DAL.TongHop;
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL.Quay;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmNangSuatThuTienTo : Form
    {
        //string _mnu = "mnuKiemTraTon";
        CHoaDon _cHoaDon = new CHoaDon();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CDCHD _cDCHD = new CDCHD();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CLenhHuy _cLenhHuy = new CLenhHuy();

        public frmNangSuatThuTienTo()
        {
            InitializeComponent();
        }

        private void frmNangSuatThuTien_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";

            lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
        }

        public void CountdgvHDTuGia()
        {
            int TongHD = 0;
            long TongGiaBan = 0;
            long TongCong = 0;
            int TongHDThu = 0;
            long TongGiaBanThu = 0;
            long TongCongThu = 0;
            int TongHDTon = 0;
            long TongGiaBanTon = 0;
            long TongCongTon = 0;

            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHD_TG"].Value.ToString()))
                        TongHD += int.Parse(item.Cells["TongHD_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBan_TG"].Value.ToString()))
                        TongGiaBan += long.Parse(item.Cells["TongGiaBan_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_TG"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong_TG"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDThu_TG"].Value.ToString()))
                        TongHDThu += int.Parse(item.Cells["TongHDThu_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanThu_TG"].Value.ToString()))
                        TongGiaBanThu += long.Parse(item.Cells["TongGiaBanThu_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongThu_TG"].Value.ToString()))
                        TongCongThu += long.Parse(item.Cells["TongCongThu_TG"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDTon_TG"].Value.ToString()))
                        TongHDTon += int.Parse(item.Cells["TongHDTon_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanTon_TG"].Value.ToString()))
                        TongGiaBanTon += long.Parse(item.Cells["TongGiaBanTon_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongTon_TG"].Value.ToString()))
                        TongCongTon += long.Parse(item.Cells["TongCongTon_TG"].Value.ToString());

                    if (string.IsNullOrEmpty(item.Cells["TongGiaBanThu_TG"].Value.ToString()))
                        item.Cells["TiLeGiaBan_TG"].Value = "0%";
                    else
                        item.Cells["TiLeGiaBan_TG"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongGiaBanThu_TG"].Value.ToString()) / double.Parse(item.Cells["TongGiaBan_TG"].Value.ToString())) * 100);
                    
                    if (string.IsNullOrEmpty(item.Cells["TongCongThu_TG"].Value.ToString()))
                        item.Cells["TiLeTongCong_TG"].Value = "0%";
                    else
                        item.Cells["TiLeTongCong_TG"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongCongThu_TG"].Value.ToString()) / double.Parse(item.Cells["TongCong_TG"].Value.ToString())) * 100);
                }
                txtTongHD_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongGiaBan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongHDThu_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDThu);
                txtTongGiaBanThu_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanThu);
                txtTongCongThu_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongThu);
                txtTongHDTon_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTon);
                txtTongGiaBanTon_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanTon);
                txtTongCongTon_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTon);
            }
        }

        public void CountdgvHDCoQuan()
        {
            int TongHD = 0;
            long TongGiaBan = 0;
            long TongCong = 0;
            int TongHDThu = 0;
            long TongGiaBanThu = 0;
            long TongCongThu = 0;
            int TongHDTon = 0;
            long TongGiaBanTon = 0;
            long TongCongTon = 0;
            
            if (dgvHDCoQuan.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHD_CQ"].Value.ToString()))
                        TongHD += int.Parse(item.Cells["TongHD_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBan_CQ"].Value.ToString()))
                        TongGiaBan += long.Parse(item.Cells["TongGiaBan_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_CQ"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong_CQ"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDThu_CQ"].Value.ToString()))
                        TongHDThu += int.Parse(item.Cells["TongHDThu_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanThu_CQ"].Value.ToString()))
                        TongGiaBanThu += long.Parse(item.Cells["TongGiaBanThu_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongThu_CQ"].Value.ToString()))
                        TongCongThu += long.Parse(item.Cells["TongCongThu_CQ"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDTon_CQ"].Value.ToString()))
                        TongHDTon += int.Parse(item.Cells["TongHDTon_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanTon_CQ"].Value.ToString()))
                        TongGiaBanTon += long.Parse(item.Cells["TongGiaBanTon_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongTon_CQ"].Value.ToString()))
                        TongCongTon += long.Parse(item.Cells["TongCongTon_CQ"].Value.ToString());

                    if (string.IsNullOrEmpty(item.Cells["TongGiaBanThu_CQ"].Value.ToString()))
                        item.Cells["TiLeGiaBan_CQ"].Value = "0%";
                    else
                        item.Cells["TiLeGiaBan_CQ"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongGiaBanThu_CQ"].Value.ToString()) / double.Parse(item.Cells["TongGiaBan_CQ"].Value.ToString())) * 100);
                    
                    if (string.IsNullOrEmpty(item.Cells["TongCongThu_CQ"].Value.ToString()))
                        item.Cells["TiLeTongCong_CQ"].Value = "0%";
                    else
                        item.Cells["TiLeTongCong_CQ"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongCongThu_CQ"].Value.ToString()) / double.Parse(item.Cells["TongCong_CQ"].Value.ToString())) * 100);
                }
                txtTongHD_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongGiaBan_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongHDThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDThu);
                txtTongGiaBanThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanThu);
                txtTongCongThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongThu);
                txtTongHDTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTon);
                txtTongGiaBanTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanTon);
                txtTongCongTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTon);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if (chkNgayKiemTra.Checked)
                {
                    dgvHDTuGia.DataSource = _cHoaDon.GetNangSuat_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                }
                else
                {
                    ///chọn tất cả các kỳ
                    if (cmbKy.SelectedIndex == 0)
                    {
                        dgvHDTuGia.DataSource = _cHoaDon.GetNangSuat_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                    }
                    ///chọn 1 kỳ cụ thể
                    else
                        if (cmbKy.SelectedIndex > 0)
                        {
                            dgvHDTuGia.DataSource = _cHoaDon.GetNangSuat_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                        }
                }
                CountdgvHDTuGia();
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    if (chkNgayKiemTra.Checked)
                    {
                        dgvHDCoQuan.DataSource = _cHoaDon.GetNangSuat_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                    }
                    else
                    {
                        ///chọn tất cả các kỳ
                        if (cmbKy.SelectedIndex == 0)
                        {
                            dgvHDCoQuan.DataSource = _cHoaDon.GetNangSuat_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                        }
                        ///chọn 1 kỳ cụ thể
                        else
                            if (cmbKy.SelectedIndex > 0)
                            {
                                dgvHDCoQuan.DataSource = _cHoaDon.GetNangSuat_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                            }
                    }
                    CountdgvHDCoQuan();
                }
        }

        private void dgvHDTuGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHD_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongGiaBan_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCong_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDThu_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongGiaBanThu_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongThu_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDTon_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongGiaBanTon_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongTon_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDCoQuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHD_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongGiaBan_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCong_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHDThu_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongGiaBanThu_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCongThu_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHDTon_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongGiaBanTon_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCongTon_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDTuGia_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDTuGia.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHDCoQuan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDCoQuan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    DataRow dr = ds.Tables["NangSuatThuTien"].NewRow();
                    dr["Nam"] = cmbNam.SelectedValue.ToString();
                    dr["Ky"] = cmbKy.SelectedItem.ToString();
                    dr["To"] = CNguoiDung.TenTo;
                    dr["Loai"] = "Tư Gia";
                    dr["TongHD"] = item.Cells["TongHD_TG"].Value;
                    dr["TongGiaBan"] = item.Cells["TongGiaBan_TG"].Value;
                    dr["TongCong"] = item.Cells["TongCong_TG"].Value;
                    dr["TongHDThu"] = item.Cells["TongHDThu_TG"].Value;
                    dr["TongGiaBanThu"] = item.Cells["TongGiaBanThu_TG"].Value;
                    dr["TongCongThu"] = item.Cells["TongCongThu_TG"].Value;
                    dr["TongHDTon"] = item.Cells["TongHDTon_TG"].Value;
                    dr["TongGiaBanTon"] = item.Cells["TongGiaBanTon_TG"].Value;
                    dr["TongCongTon"] = item.Cells["TongCongTon_TG"].Value;
                    dr["NhanVien"] = item.Cells["HoTen_TG"].Value;
                    dr["TiLeGiaBan"] = item.Cells["TiLeGiaBan_TG"].Value;
                    dr["TiLeTongCong"] = item.Cells["TiLeTongCong_TG"].Value;
                    ds.Tables["NangSuatThuTien"].Rows.Add(dr);
                }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                    {
                        DataRow dr = ds.Tables["NangSuatThuTien"].NewRow();
                        dr["Nam"] = cmbNam.SelectedValue.ToString();
                        dr["Ky"] = cmbKy.SelectedItem.ToString();
                        dr["To"] = CNguoiDung.TenTo;
                        dr["Loai"] = "Cơ Quan";
                        dr["TongHD"] = item.Cells["TongHD_CQ"].Value;
                        dr["TongGiaBan"] = item.Cells["TongGiaBan_CQ"].Value;
                        dr["TongCong"] = item.Cells["TongCong_CQ"].Value;
                        dr["TongHDThu"] = item.Cells["TongHDThu_CQ"].Value;
                        dr["TongGiaBanThu"] = item.Cells["TongGiaBanThu_CQ"].Value;
                        dr["TongCongThu"] = item.Cells["TongCongThu_CQ"].Value;
                        dr["TongHDTon"] = item.Cells["TongHDTon_CQ"].Value;
                        dr["TongGiaBanTon"] = item.Cells["TongGiaBanTon_CQ"].Value;
                        dr["TongCongTon"] = item.Cells["TongCongTon_CQ"].Value;
                        dr["NhanVien"] = item.Cells["HoTen_CQ"].Value;
                        dr["TiLeGiaBan"] = item.Cells["TiLeGiaBan_CQ"].Value;
                        dr["TiLeTongCong"] = item.Cells["TiLeTongCong_CQ"].Value;
                        ds.Tables["NangSuatThuTien"].Rows.Add(dr);
                    }

            rptNangSuatThuTien_To rpt = new rptNangSuatThuTien_To();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void chkNgayKiemTra_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgayKiemTra.Checked)
                dateGiaiTrach.Enabled = true;
            else
                dateGiaiTrach.Enabled = false;
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (cmbKy.SelectedIndex != -1)
            {
                DateTime NgayGiaiTrachNow = new DateTime(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), DateTime.DaysInMonth(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                DateTime NgayGiaiTrachOld = NgayGiaiTrachNow.AddMonths(-1);
                NgayGiaiTrachOld = new DateTime(NgayGiaiTrachOld.Year, NgayGiaiTrachOld.Month, DateTime.DaysInMonth(NgayGiaiTrachOld.Year, NgayGiaiTrachOld.Month));

                dsBaoCao ds = new dsBaoCao();

                DataTable dtNV = _cHoaDon.GetBaoCaoTongHop_NV("TG",CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), NgayGiaiTrachNow, NgayGiaiTrachOld);
                dtNV.Merge(_cHoaDon.GetBaoCaoTongHop_NV("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), NgayGiaiTrachNow, NgayGiaiTrachOld));

                DataTable dtDCHDChuanThu = new DataTable();
                DataTable dtDCHDTonCuKy = new DataTable();
                DataTable dtDCHDTongTon = new DataTable();
                List<TT_NguoiDung> lstND = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);

                foreach (TT_NguoiDung item in lstND)
                {
                    dtDCHDChuanThu.Merge(_cDCHD.GetChuanThu_NV("TG", item.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                    dtDCHDChuanThu.Merge(_cDCHD.GetChuanThu_NV("CQ", item.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));

                    dtDCHDTonCuKy.Merge(_cDCHD.GetChuanThuTonDenKyDenNgay_NV("TG", item.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()) - 1, NgayGiaiTrachOld));
                    dtDCHDTonCuKy.Merge(_cDCHD.GetChuanThuTonDenKyDenNgay_NV("CQ", item.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()) - 1, NgayGiaiTrachOld));

                    dtDCHDTongTon.Merge(_cDCHD.GetChuanThuTonDenKyDenNgay_NV("TG", item.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), NgayGiaiTrachNow));
                    dtDCHDTongTon.Merge(_cDCHD.GetChuanThuTonDenKyDenNgay_NV("CQ", item.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), NgayGiaiTrachNow));
                }

                foreach (DataRow item in dtDCHDChuanThu.Rows)
                {
                    DataRow[] drTo = dtNV.Select("MaND=" + item["MaNV"] + " and Loai='" + item["Loai"] + "'");
                    drTo[0]["GTChuanThu"] = long.Parse(drTo[0]["GTChuanThu"].ToString()) - long.Parse(item["TONGCONG_END"].ToString()) + long.Parse(item["TONGCONG_BD"].ToString());
                }

                foreach (DataRow item in dtDCHDTonCuKy.Rows)
                {
                    DataRow[] drTo = dtNV.Select("MaND='" + item["MaNV"] + "' and Loai='" + item["Loai"] + "'");
                    drTo[0]["GTTonCu"] = long.Parse(drTo[0]["GTTonCu"].ToString()) - long.Parse(item["TONGCONG_END"].ToString()) + long.Parse(item["TONGCONG_BD"].ToString());
                }

                foreach (DataRow item in dtDCHDTongTon.Rows)
                {
                    DataRow[] drTo = dtNV.Select("MaND='" + item["MaNV"] + "' and Loai='" + item["Loai"] + "'");
                    drTo[0]["GTTongTon"] = long.Parse(drTo[0]["GTTongTon"].ToString()) - long.Parse(item["TONGCONG_END"].ToString()) + long.Parse(item["TONGCONG_BD"].ToString());
                }

                foreach (DataRow item in dtNV.Rows)
                {
                    DataRow dr = ds.Tables["BaoCaoTongHop"].NewRow();

                    dr["Ky"] = cmbKy.SelectedItem.ToString() + "/" + cmbNam.SelectedValue.ToString();
                    dr["To"] = CNguoiDung.TenTo;
                    dr["STT"]=item["STT"];
                    dr["HanhThu"] = item["HoTen"];
                    dr["Loai"] = item["Loai"];
                    dr["TonCu"] = item["HDTonCu"];
                    dr["TyLeTonCu"] = item["GTTonCu"];
                    dr["ChuanThu"] = item["HDChuanThu"];
                    dr["TyLeChuanThu"] = item["GTChuanThu"];
                    if (string.IsNullOrEmpty(item["HDTongTon"].ToString()))
                        dr["TongTon"] = 0;
                    else
                        dr["TongTon"] = item["HDTongTon"];
                    if (string.IsNullOrEmpty(item["GTTongTon"].ToString()))
                        dr["TyLeTongTon"] = 0;
                    else
                        dr["TyLeTongTon"] = item["GTTongTon"];
                    dr["NhanVien"] = CNguoiDung.HoTen;
                    ds.Tables["BaoCaoTongHop"].Rows.Add(dr);
                }

                ///Dòng Tổng Cộng
                ///TG
                DataRow drTC = ds.Tables["BaoCaoTongHop"].NewRow();

                drTC["Ky"] = cmbKy.SelectedItem.ToString() + "/" + cmbNam.SelectedValue.ToString();
                drTC["To"] = CNguoiDung.TenTo;
                drTC["STT"] = dtNV.Compute("SUM(STT)+1","");
                drTC["HanhThu"] = "Tổng Cộng";
                drTC["Loai"] = "TG";
                drTC["TonCu"] = dtNV.Compute("SUM(HDTonCu)", "Loai='TG'");
                drTC["TyLeTonCu"] = dtNV.Compute("SUM(GTTonCu)", "Loai='TG'");
                drTC["ChuanThu"] = dtNV.Compute("SUM(HDChuanThu)", "Loai='TG'");
                drTC["TyLeChuanThu"] = dtNV.Compute("SUM(GTChuanThu)", "Loai='TG'");
                if (string.IsNullOrEmpty(dtNV.Compute("SUM(HDTongTon)", "Loai='TG'").ToString()))
                    drTC["TongTon"] = 0;
                else
                    drTC["TongTon"] = dtNV.Compute("SUM(HDTongTon)", "Loai='TG'");
                if (string.IsNullOrEmpty(dtNV.Compute("SUM(GTTongTon)", "Loai='TG'").ToString()))
                    drTC["TyLeTongTon"] = 0;
                else
                    drTC["TyLeTongTon"] = dtNV.Compute("SUM(GTTongTon)", "Loai='TG'");
                drTC["NhanVien"] = CNguoiDung.HoTen;
                ds.Tables["BaoCaoTongHop"].Rows.Add(drTC);

                ///CQ
                drTC = ds.Tables["BaoCaoTongHop"].NewRow();

                drTC["Ky"] = cmbKy.SelectedItem.ToString() + "/" + cmbNam.SelectedValue.ToString();
                drTC["To"] = CNguoiDung.TenTo;
                drTC["STT"] = dtNV.Compute("SUM(STT)+1", "");
                drTC["HanhThu"] = "Tổng Cộng";
                drTC["Loai"] = "CQ";
                drTC["TonCu"] = dtNV.Compute("SUM(HDTonCu)", "Loai='CQ'");
                drTC["TyLeTonCu"] = dtNV.Compute("SUM(GTTonCu)", "Loai='CQ'");
                drTC["ChuanThu"] = dtNV.Compute("SUM(HDChuanThu)", "Loai='CQ'");
                drTC["TyLeChuanThu"] = dtNV.Compute("SUM(GTChuanThu)", "Loai='CQ'");
                if (string.IsNullOrEmpty(dtNV.Compute("SUM(HDTongTon)", "Loai='CQ'").ToString()))
                    drTC["TongTon"] = 0;
                else
                    drTC["TongTon"] = dtNV.Compute("SUM(HDTongTon)", "Loai='CQ'");
                if (string.IsNullOrEmpty(dtNV.Compute("SUM(GTTongTon)", "Loai='CQ'").ToString()))
                    drTC["TyLeTongTon"] = 0;
                else
                    drTC["TyLeTongTon"] = dtNV.Compute("SUM(GTTongTon)", "Loai='CQ'");
                drTC["NhanVien"] = CNguoiDung.HoTen;
                ds.Tables["BaoCaoTongHop"].Rows.Add(drTC);

                ///Thêm Đóng Nước
                DataTable dtDongNuoc = _cDongNuoc.GetBaoCaoTongHop(CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                foreach (DataRow item in dtDongNuoc.Rows)
                {
                    DataRow dr = ds.Tables["DSDongNuoc"].NewRow();

                    dr["STT"] = item["STT"];
                    dr["HanhThu"] = item["HoTen"];
                    dr["DanhBo"] = item["DanhBo"];
                    dr["SoHoaDon"] = item["SoHoaDon"];
                    DIEUCHINH_HD dchd = _cDCHD.GetBySoHoaDon(item["SoHoaDon"].ToString());
                    if (dchd!=null)
                    {
                        //DIEUCHINH_HD dchd = _cDCHD.GetBySoHoaDon(item["SoHoaDon"].ToString());
                        dr["TongCong"] = long.Parse(item["TongCong"].ToString()) - dchd.TONGCONG_END + dchd.TONGCONG_BD;
                    }
                    else
                        dr["TongCong"] = item["TongCong"];
                    dr["NgayGiaiTrach"] = item["NgayGiaiTrach"];
                    dr["MaKQDN"] = _cDongNuoc.GetKQDongNuocByMaDN(decimal.Parse(item["MaDN"].ToString()));
                    if (_cLenhHuy.CheckExist(item["SoHoaDon"].ToString()))
                        dr["LenhHuy"] = true;
                    else
                        dr["LenhHuy"] = false;

                    ds.Tables["DSDongNuoc"].Rows.Add(dr);
                }

                rptBaoCaoTo rpt = new rptBaoCaoTo();
                rpt.SetDataSource(ds);
                rpt.Subreports[0].SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
        }


    }
}

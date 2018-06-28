﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.Doi;
using ThuTien.LinQ;
using System.Globalization;
using ThuTien.BaoCao;
using ThuTien.GUI.BaoCao;
using ThuTien.DAL.Quay;
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.BaoCao.ToTruong;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmKiemTraTonTo : Form
    {
        //string _mnu = "mnuKiemTraTonTo";
        CHoaDon _cHoaDon = new CHoaDon();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CDuLieuKhachHang _cDLKH = new CDuLieuKhachHang();

        public frmKiemTraTonTo()
        {
            InitializeComponent();
        }

        private void frmKiemTraTon_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            TT_NguoiDung nguoidung = new TT_NguoiDung();
            nguoidung.MaND = -1;
            nguoidung.HoTen = "Tất cả";
            List<TT_NguoiDung> lst = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
            lst.Insert(0, nguoidung);
            cmbNhanVien.DataSource = lst;
            cmbNhanVien.DisplayMember = "HoTen";
            cmbNhanVien.ValueMember = "MaND";

            DataTable dtNam = _cHoaDon.GetNam();
            DataRow dr = dtNam.NewRow();
            dr["ID"] = "Tất Cả";
            dtNam.Rows.InsertAt(dr, 0);
            cmbNam.DataSource = dtNam;
            cmbNam.DisplayMember = "ID";
            cmbNam.ValueMember = "Nam";

            lbTo.Text = "Tổ  " + CNguoiDung.TenTo;

            dateGiaiTrach.Value = DateTime.Now;

            cmbNam.SelectedValue = DateTime.Now.Year.ToString();
            cmbKy.SelectedItem = DateTime.Now.Month.ToString();
            cmbFromDot.SelectedIndex = 0;
            cmbToDot.SelectedIndex = 0;
        }

        public void CountdgvHDTuGia()
        {
            int TongHD = 0;
            long TongCong = 0;
            int TongHDThu = 0;
            long TongCongThu = 0;
            int TongHDTon = 0;
            long TongCongTon = 0;
            int TongHDTonThucTe = 0;
            long TongCongTonThucTe = 0;

            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHD_TG"].Value.ToString()))
                        TongHD += int.Parse(item.Cells["TongHD_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_TG"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong_TG"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDThu_TG"].Value.ToString()))
                        TongHDThu += int.Parse(item.Cells["TongHDThu_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongThu_TG"].Value.ToString()))
                        TongCongThu += long.Parse(item.Cells["TongCongThu_TG"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDTon_TG"].Value.ToString()))
                        TongHDTon += int.Parse(item.Cells["TongHDTon_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongTon_TG"].Value.ToString()))
                        TongCongTon += long.Parse(item.Cells["TongCongTon_TG"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDTonThucTe_TG"].Value.ToString()))
                        TongHDTonThucTe += int.Parse(item.Cells["TongHDTonThucTe_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongTonThucTe_TG"].Value.ToString()))
                        TongCongTonThucTe += long.Parse(item.Cells["TongCongTonThucTe_TG"].Value.ToString());
                }
                txtTongHD_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongHDThu_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDThu);
                txtTongCongThu_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongThu);
                txtTongHDTon_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTon);
                txtTongCongTon_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTon);
                txtTongHDTonThucTe_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTonThucTe);
                txtTongCongTonThucTe_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTonThucTe);
            }
        }

        public void CountdgvHDCoQuan()
        {
            int TongHD = 0;
            long TongCong = 0;
            int TongHDThu = 0;
            long TongCongThu = 0;
            int TongHDTon = 0;
            long TongCongTon = 0;
            int TongHDTonThucTe = 0;
            long TongCongTonThucTe = 0;

            if (dgvHDCoQuan.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHD_CQ"].Value.ToString()))
                        TongHD += int.Parse(item.Cells["TongHD_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_CQ"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong_CQ"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDThu_CQ"].Value.ToString()))
                        TongHDThu += int.Parse(item.Cells["TongHDThu_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongThu_CQ"].Value.ToString()))
                        TongCongThu += long.Parse(item.Cells["TongCongThu_CQ"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDTon_CQ"].Value.ToString()))
                        TongHDTon += int.Parse(item.Cells["TongHDTon_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongTon_CQ"].Value.ToString()))
                        TongCongTon += long.Parse(item.Cells["TongCongTon_CQ"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDTonThucTe_CQ"].Value.ToString()))
                        TongHDTonThucTe += int.Parse(item.Cells["TongHDTonThucTe_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongTonThucTe_CQ"].Value.ToString()))
                        TongCongTonThucTe += long.Parse(item.Cells["TongCongTonThucTe_CQ"].Value.ToString());
                }
                txtTongHD_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongHDThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDThu);
                txtTongCongThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongThu);
                txtTongHDTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTon);
                txtTongCongTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTon);
                txtTongHDTonThucTe_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTonThucTe);
                txtTongCongTonThucTe_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTonThucTe);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                ///chọn tất cả nhân viên trong tổ
                if (cmbNhanVien.SelectedIndex == 0)
                {
                    if ((chkDenKy.Checked || chkTrongKy.Checked) && chkNgayKiemTra.Checked)
                    {
                        if (chkDenKy.Checked)
                            dgvHDTuGia.DataSource = _cHoaDon.GetTongTonDenKyDenNgay_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                        else
                            if (chkTrongKy.Checked)
                                dgvHDTuGia.DataSource = _cHoaDon.GetTongTonTrongKyDenNgay_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                    }
                    else
                        if (chkDenKy.Checked)
                        {
                            if (cmbFromDot.SelectedIndex == 0)
                                dgvHDTuGia.DataSource = _cHoaDon.GetTongTonDenKy_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                            else
                                if (cmbFromDot.SelectedIndex > 0)
                                    dgvHDTuGia.DataSource = _cHoaDon.GetTongTonDenKy_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()));
                        }
                        else
                            if (chkNgayKiemTra.Checked)
                            {
                                dgvHDTuGia.DataSource = _cHoaDon.GetTongTon_To("TG", CNguoiDung.MaTo, dateGiaiTrach.Value);
                            }
                            else
                            {
                                ///chọn tất cả các năm
                                if (cmbNam.SelectedIndex == 0)
                                {
                                    dgvHDTuGia.DataSource = _cHoaDon.GetTongTon_To("TG", CNguoiDung.MaTo);
                                }
                                else
                                    ///chọn 1 năm cụ thể
                                    if (cmbNam.SelectedIndex > 0)
                                        ///chọn tất cả các kỳ
                                        if (cmbKy.SelectedIndex == 0)
                                        {
                                            dgvHDTuGia.DataSource = _cHoaDon.GetTongTon_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                                        }
                                        ///chọn 1 kỳ cụ thể
                                        else
                                            if (cmbKy.SelectedIndex > 0)
                                                ///chọn tất cả các đợt
                                                if (cmbFromDot.SelectedIndex == 0)
                                                {
                                                    dgvHDTuGia.DataSource = _cHoaDon.GetTongTon_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                                }
                                                else
                                                    ///chọn 1 đợt cụ thể
                                                    if (cmbFromDot.SelectedIndex > 0)
                                                    {
                                                        dgvHDTuGia.DataSource = _cHoaDon.GetTongTon_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()));
                                                    }
                            }
                }
                else
                    ///chọn 1 nhân viên cụ thể
                    if (cmbNhanVien.SelectedIndex > 0)
                    {
                        if ((chkDenKy.Checked || chkTrongKy.Checked) && chkNgayKiemTra.Checked)
                        {
                            if (chkDenKy.Checked)
                                dgvHDTuGia.DataSource = _cHoaDon.GetTongTonDenKyDenNgay_NV("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                            else
                                if (chkTrongKy.Checked)
                                    dgvHDTuGia.DataSource = _cHoaDon.GetTongTonTrongKyDenNgay_NV("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                        }
                        else
                            if (chkDenKy.Checked)
                            {
                                if (cmbFromDot.SelectedIndex == 0)
                                {
                                    dgvHDTuGia.DataSource = _cHoaDon.GetTongTonDenKy_NV("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                }
                                else
                                    if (cmbFromDot.SelectedIndex > 0)
                                    {
                                        DataTable dt = new DataTable();
                                        for (int i = int.Parse(cmbFromDot.SelectedItem.ToString()); i <= int.Parse(cmbToDot.SelectedItem.ToString()); i++)
                                        {
                                            dt.Merge(_cHoaDon.GetTongTonDenKy_NV("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i));
                                        }
                                        dgvHDTuGia.DataSource = dt;
                                    }
                            }
                            else
                                if (chkNgayKiemTra.Checked)
                                {
                                    dgvHDTuGia.DataSource = _cHoaDon.GetTongTon_NV("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), dateGiaiTrach.Value);
                                }
                                else
                                {
                                    ///chọn tất cả các năm
                                    if (cmbNam.SelectedIndex == 0)
                                    {
                                        dgvHDTuGia.DataSource = _cHoaDon.GetTongTon_NV("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()));
                                    }
                                    else
                                        ///chọn 1 năm cụ thể
                                        if (cmbNam.SelectedIndex > 0)
                                            ///chọn tất cả các kỳ
                                            if (cmbKy.SelectedIndex == 0)
                                            {
                                                dgvHDTuGia.DataSource = _cHoaDon.GetTongTon_NV("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                                            }
                                            ///chọn 1 kỳ cụ thể
                                            else
                                                if (cmbKy.SelectedIndex > 0)
                                                    if (cmbFromDot.SelectedIndex == 0)
                                                    {
                                                        dgvHDTuGia.DataSource = _cHoaDon.GetTongTon_NV("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                                    }
                                                    else
                                                        if (cmbFromDot.SelectedIndex > 0)
                                                        {
                                                            DataTable dt = new DataTable();
                                                            for (int i = int.Parse(cmbFromDot.SelectedItem.ToString()); i <= int.Parse(cmbToDot.SelectedItem.ToString()); i++)
                                                            {
                                                                dt.Merge(_cHoaDon.GetTongTon_NV("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i));
                                                            }
                                                            dgvHDTuGia.DataSource = dt;
                                                        }
                                }
                    }
                CountdgvHDTuGia();
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    ///chọn tất cả nhân viên trong tổ
                    if (cmbNhanVien.SelectedIndex == 0)
                    {
                        if ((chkDenKy.Checked || chkTrongKy.Checked) && chkNgayKiemTra.Checked)
                        {
                            if (chkDenKy.Checked)
                                dgvHDCoQuan.DataSource = _cHoaDon.GetTongTonDenKyDenNgay_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                            else
                                if (chkTrongKy.Checked)
                                    dgvHDCoQuan.DataSource = _cHoaDon.GetTongTonTrongKyDenNgay_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                        }
                        else
                            if (chkDenKy.Checked)
                            {
                                if (cmbFromDot.SelectedIndex == 0)
                                    dgvHDCoQuan.DataSource = _cHoaDon.GetTongTonDenKy_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                else
                                    if (cmbFromDot.SelectedIndex > 0)
                                        dgvHDCoQuan.DataSource = _cHoaDon.GetTongTonDenKy_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()));
                            }
                            else
                                if (chkNgayKiemTra.Checked)
                                {
                                    dgvHDCoQuan.DataSource = _cHoaDon.GetTongTon_To("CQ", CNguoiDung.MaTo, dateGiaiTrach.Value);
                                }
                                else
                                {
                                    ///chọn tất cả các năm
                                    if (cmbNam.SelectedIndex == 0)
                                    {
                                        dgvHDCoQuan.DataSource = _cHoaDon.GetTongTon_To("CQ", CNguoiDung.MaTo);
                                    }
                                    else
                                        ///chọn 1 năm cụ thể
                                        if (cmbNam.SelectedIndex > 0)
                                            ///chọn tất cả các kỳ
                                            if (cmbKy.SelectedIndex == 0)
                                            {
                                                dgvHDCoQuan.DataSource = _cHoaDon.GetTongTon_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                                            }
                                            ///chọn 1 kỳ cụ thể
                                            else
                                                if (cmbKy.SelectedIndex > 0)
                                                ///chọn tất cả các đợt
                                                    if (cmbFromDot.SelectedIndex == 0)
                                                {
                                                    dgvHDCoQuan.DataSource = _cHoaDon.GetTongTon_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                                }
                                                    else
                                                        ///chọn 1 đợt cụ thể
                                                        if (cmbFromDot.SelectedIndex > 0)
                                                        {
                                                            dgvHDCoQuan.DataSource = _cHoaDon.GetTongTon_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()));
                                                        }
                                }
                    }
                    else
                        ///chọn 1 nhân viên cụ thể
                        if (cmbNhanVien.SelectedIndex > 0)
                        {
                            if ((chkDenKy.Checked || chkTrongKy.Checked) && chkNgayKiemTra.Checked)
                            {
                                if (chkDenKy.Checked)
                                    dgvHDCoQuan.DataSource = _cHoaDon.GetTongTonDenKyDenNgay_NV("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                                else
                                    if (chkTrongKy.Checked)
                                        dgvHDCoQuan.DataSource = _cHoaDon.GetTongTonTrongKyDenNgay_NV("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                            }
                            else
                                if (chkDenKy.Checked)
                                {
                                    if (cmbFromDot.SelectedIndex == 0)
                                    {
                                        dgvHDCoQuan.DataSource = _cHoaDon.GetTongTonDenKy_NV("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                    }
                                    else
                                        if (cmbFromDot.SelectedIndex > 0)
                                        {
                                            DataTable dt = new DataTable();
                                            for (int i = int.Parse(cmbFromDot.SelectedItem.ToString()); i <= int.Parse(cmbToDot.SelectedItem.ToString()); i++)
                                            {
                                                dt.Merge(_cHoaDon.GetTongTonDenKy_NV("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i));
                                            }
                                            dgvHDCoQuan.DataSource = dt;
                                        }
                                }
                                else
                                    if (chkNgayKiemTra.Checked)
                                    {
                                        dgvHDCoQuan.DataSource = _cHoaDon.GetTongTon_NV("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), dateGiaiTrach.Value);
                                    }
                                    else
                                    {
                                        ///chọn tất cả các năm
                                        if (cmbNam.SelectedIndex == 0)
                                        {
                                            dgvHDTuGia.DataSource = _cHoaDon.GetTongTon_NV("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()));
                                        }
                                        else
                                            ///chọn 1 năm cụ thể
                                            if (cmbNam.SelectedIndex > 0)
                                                ///chọn tất cả các kỳ
                                                if (cmbKy.SelectedIndex == 0)
                                                {
                                                    dgvHDCoQuan.DataSource = _cHoaDon.GetTongTon_NV("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                                                }
                                                ///chọn 1 kỳ cụ thể
                                                else
                                                    if (cmbKy.SelectedIndex > 0)
                                                        if (cmbFromDot.SelectedIndex == 0)
                                                        {
                                                            dgvHDCoQuan.DataSource = _cHoaDon.GetTongTon_NV("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                                        }
                                                        else
                                                            if (cmbFromDot.SelectedIndex > 0)
                                                            {
                                                                DataTable dt = new DataTable();
                                                                for (int i = int.Parse(cmbFromDot.SelectedItem.ToString()); i <= int.Parse(cmbToDot.SelectedItem.ToString()); i++)
                                                                {
                                                                    dt.Merge(_cHoaDon.GetTongTon_NV("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i));
                                                                }
                                                                dgvHDCoQuan.DataSource = dt;
                                                            }
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
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCong_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDThu_TG" && e.Value != null)
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
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongTon_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDTonThucTe_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongTonThucTe_TG" && e.Value != null)
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
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCong_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHDThu_CQ" && e.Value != null)
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
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCongTon_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHDTonThucTe_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCongTonThucTe_CQ" && e.Value != null)
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

        private void btnInDSNhanVien_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if (chkDenKy.Checked && chkNgayKiemTra.Checked)
                {
                    dt = _cHoaDon.GetDSTonDenKyDenNgay_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                }
                else
                    if (chkDenKy.Checked)
                    {
                        if (cmbNhanVien.SelectedIndex == 0)
                            dt = _cHoaDon.GetDSTonDenKy_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                        else
                            if (cmbNhanVien.SelectedIndex > 0)
                            {
                                if (cmbFromDot.SelectedIndex == 0)
                                    for (int i = 1; i <= 20; i++)
                                    {
                                        dt.Merge(_cHoaDon.GetDSTonDenKy_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i, int.Parse(txtSoKy.Text.Trim())));
                                    }
                                else
                                    if (cmbFromDot.SelectedIndex > 0)
                                        for (int i = int.Parse(cmbFromDot.SelectedItem.ToString()); i <= int.Parse(cmbToDot.SelectedItem.ToString()); i++)
                                        {
                                            dt.Merge(_cHoaDon.GetDSTonDenKy_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i, int.Parse(txtSoKy.Text.Trim())));
                                        }
                            }
                    }
                    else
                        if (chkNgayKiemTra.Checked)
                        {
                            dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                        }
                        else
                        {
                            if (cmbNam.SelectedIndex == 0)
                                dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(txtSoKy.Text.Trim()));
                            else
                                if (cmbNam.SelectedIndex > 0)
                                    if (cmbKy.SelectedIndex == 0)
                                        dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                    else
                                        if (cmbKy.SelectedIndex > 0)
                                            if (cmbNhanVien.SelectedIndex == 0)
                                                dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                            else
                                                if (cmbNhanVien.SelectedIndex > 0)
                                                {
                                                    if (cmbFromDot.SelectedIndex == 0)
                                                        for (int i = 1; i <= 20; i++)
                                                        {
                                                            dt.Merge(_cHoaDon.GetDSTon_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i, int.Parse(txtSoKy.Text.Trim())));
                                                        }
                                                    else
                                                        if (cmbFromDot.SelectedIndex > 0)
                                                            for (int i = int.Parse(cmbFromDot.SelectedItem.ToString()); i <= int.Parse(cmbToDot.SelectedItem.ToString()); i++)
                                                            {
                                                                dt.Merge(_cHoaDon.GetDSTon_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i, int.Parse(txtSoKy.Text.Trim())));
                                                            }
                                                }
                        }
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                    dr["LoaiBaoCao"] = "TƯ GIA TỒN";
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                    dr["Ky"] = item["Ky"];
                    dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                    dr["TongCong"] = item["TongCong"];
                    dr["SoPhatHanh"] = item["SoPhatHanh"];
                    dr["SoHoaDon"] = item["SoHoaDon"];
                    dr["NhanVien"] = dgvHDTuGia.SelectedRows[0].Cells["HoTen_TG"].Value.ToString();
                    if (_cLenhHuy.CheckExist(item["SoHoaDon"].ToString()))
                        dr["LenhHuy"] = true;
                    ds.Tables["DSHoaDon"].Rows.Add(dr);
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    if (chkDenKy.Checked && chkNgayKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetDSTonDenKyDenNgay_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                    }
                    else
                        if (chkDenKy.Checked)
                        {
                            if (cmbNhanVien.SelectedIndex == 0)
                                dt = _cHoaDon.GetDSTonDenKy_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                            else
                                if (cmbNhanVien.SelectedIndex > 0)
                                {
                                    if (cmbFromDot.SelectedIndex == 0)
                                        for (int i = 1; i <= 20; i++)
                                        {
                                            dt.Merge(_cHoaDon.GetDSTonDenKy_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i, int.Parse(txtSoKy.Text.Trim())));
                                        }
                                    else
                                        if (cmbFromDot.SelectedIndex > 0)
                                            for (int i = int.Parse(cmbFromDot.SelectedItem.ToString()); i <= int.Parse(cmbToDot.SelectedItem.ToString()); i++)
                                            {
                                                dt.Merge(_cHoaDon.GetDSTonDenKy_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i, int.Parse(txtSoKy.Text.Trim())));
                                            }
                                }
                        }
                        else
                            if (chkNgayKiemTra.Checked)
                            {
                                dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                            }
                            else
                            {
                                if (cmbNam.SelectedIndex == 0)
                                    dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                else
                                    if (cmbNam.SelectedIndex > 0)
                                        if (cmbKy.SelectedIndex == 0)
                                            dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                        else
                                            if (cmbKy.SelectedIndex > 0)
                                                if (cmbNhanVien.SelectedIndex == 0)
                                                    dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                                else
                                                    if (cmbNhanVien.SelectedIndex > 0)
                                                    {
                                                        if (cmbFromDot.SelectedIndex == 0)
                                                            for (int i = 1; i <= 20; i++)
                                                            {
                                                                dt.Merge(_cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i, int.Parse(txtSoKy.Text.Trim())));
                                                            }
                                                        else
                                                            if (cmbFromDot.SelectedIndex > 0)
                                                                for (int i = int.Parse(cmbFromDot.SelectedItem.ToString()); i <= int.Parse(cmbToDot.SelectedItem.ToString()); i++)
                                                                {
                                                                    dt.Merge(_cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i, int.Parse(txtSoKy.Text.Trim())));
                                                                }
                                                    }
                            }
                    foreach (DataRow item in dt.Rows)
                    {
                        DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                        dr["LoaiBaoCao"] = "CƠ QUAN TỒN";
                        dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                        dr["Ky"] = item["Ky"];
                        dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                        dr["TongCong"] = item["TongCong"];
                        dr["SoPhatHanh"] = item["SoPhatHanh"];
                        dr["SoHoaDon"] = item["SoHoaDon"];
                        dr["NhanVien"] = dgvHDCoQuan.SelectedRows[0].Cells["HoTen_CQ"].Value.ToString();
                        if (_cLenhHuy.CheckExist(item["SoHoaDon"].ToString()))
                            dr["LenhHuy"] = true;
                        ds.Tables["DSHoaDon"].Rows.Add(dr);
                    }
                }
            rptDSHoaDon rpt = new rptDSHoaDon();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnInDSTo_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if (chkDenKy.Checked && chkNgayKiemTra.Checked)
                {
                    dt = _cHoaDon.GetDSTonDenKyDenNgay_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                }
                else
                    if (chkDenKy.Checked)
                    {
                        dt = _cHoaDon.GetDSTonDenKy_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                    }
                    else
                        if (chkNgayKiemTra.Checked)
                        {
                            dt = _cHoaDon.GetDSTon_To("TG", CNguoiDung.MaTo, dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                        }
                        else
                        {
                            if (cmbNam.SelectedIndex == 0)
                                dt = _cHoaDon.GetDSTon_To("TG", CNguoiDung.MaTo, int.Parse(txtSoKy.Text.Trim()));
                            else
                                if (cmbNam.SelectedIndex > 0)
                                    if (cmbKy.SelectedIndex == 0)
                                        dt = _cHoaDon.GetDSTon_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                    else
                                        if (cmbKy.SelectedIndex > 0)
                                            dt = _cHoaDon.GetDSTon_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                        }
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                    dr["LoaiBaoCao"] = "TƯ GIA TỒN";
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                    dr["Ky"] = item["Ky"];
                    dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                    dr["TongCong"] = item["TongCong"];
                    dr["SoPhatHanh"] = item["SoPhatHanh"];
                    dr["SoHoaDon"] = item["SoHoaDon"];
                    dr["NhanVien"] = dgvHDTuGia.SelectedRows[0].Cells["HoTen_TG"].Value.ToString();
                    if (_cLenhHuy.CheckExist(item["SoHoaDon"].ToString()))
                        dr["LenhHuy"] = true;
                    ds.Tables["DSHoaDon"].Rows.Add(dr);
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    if (chkDenKy.Checked && chkNgayKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetDSTonDenKyDenNgay_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                    }
                    else
                        if (chkDenKy.Checked)
                        {
                            dt = _cHoaDon.GetDSTonDenKy_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                        }
                        else
                            if (chkNgayKiemTra.Checked)
                            {
                                dt = _cHoaDon.GetDSTon_To("CQ", CNguoiDung.MaTo, dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                            }
                            else
                            {
                                if (cmbNam.SelectedIndex == 0)
                                    dt = _cHoaDon.GetDSTon_To("CQ", CNguoiDung.MaTo, int.Parse(txtSoKy.Text.Trim()));
                                else
                                    if (cmbNam.SelectedIndex > 0)
                                        if (cmbKy.SelectedIndex == 0)
                                            dt = _cHoaDon.GetDSTon_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                        else
                                            if (cmbKy.SelectedIndex > 0)
                                                dt = _cHoaDon.GetDSTon_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                            }
                    foreach (DataRow item in dt.Rows)
                    {
                        DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                        dr["LoaiBaoCao"] = "CƠ QUAN TỒN";
                        dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                        dr["Ky"] = item["Ky"];
                        dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                        dr["TongCong"] = item["TongCong"];
                        dr["SoPhatHanh"] = item["SoPhatHanh"];
                        dr["SoHoaDon"] = item["SoHoaDon"];
                        dr["NhanVien"] = dgvHDCoQuan.SelectedRows[0].Cells["HoTen_CQ"].Value.ToString();
                        if (_cLenhHuy.CheckExist(item["SoHoaDon"].ToString()))
                            dr["LenhHuy"] = true;
                        ds.Tables["DSHoaDon"].Rows.Add(dr);
                    }
                }
            rptDSHoaDon rpt = new rptDSHoaDon();
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

        private void btnInDSNVThucTe_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if (chkDenKy.Checked && chkNgayKiemTra.Checked)
                {
                    dt = _cHoaDon.GetDSTonDenKyDenNgay_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                }
                else
                    if (chkDenKy.Checked)
                    {
                        if (cmbNhanVien.SelectedIndex == 0)
                            dt = _cHoaDon.GetDSTonDenKy_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                        else
                            if (cmbNhanVien.SelectedIndex > 0)
                            {
                                if (cmbFromDot.SelectedIndex == 0)
                                    for (int i = 1; i <= 20; i++)
                                    {
                                        dt.Merge(_cHoaDon.GetDSTonDenKy_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i, int.Parse(txtSoKy.Text.Trim())));
                                    }
                                else
                                    if (cmbFromDot.SelectedIndex > 0)
                                        for (int i = int.Parse(cmbFromDot.SelectedItem.ToString()); i <= int.Parse(cmbToDot.SelectedItem.ToString()); i++)
                                        {
                                            dt.Merge(_cHoaDon.GetDSTonDenKy_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i, int.Parse(txtSoKy.Text.Trim())));
                                        }
                            }
                    }
                    else
                        if (chkNgayKiemTra.Checked)
                        {
                            dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                        }
                        else
                        {
                            if (cmbNam.SelectedIndex == 0)
                                dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(txtSoKy.Text.Trim()));
                            else
                                if (cmbNam.SelectedIndex > 0)
                                    if (cmbKy.SelectedIndex == 0)
                                        dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                    else
                                        if (cmbKy.SelectedIndex > 0)
                                            if (cmbNhanVien.SelectedIndex == 0)
                                                dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                            else
                                                if (cmbNhanVien.SelectedIndex > 0)
                                                {
                                                    if (cmbFromDot.SelectedIndex == 0)
                                                        for (int i = 1; i <= 20; i++)
                                                        {
                                                            dt.Merge(_cHoaDon.GetDSTon_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i, int.Parse(txtSoKy.Text.Trim())));
                                                        }
                                                    else
                                                        if (cmbFromDot.SelectedIndex > 0)
                                                            for (int i = int.Parse(cmbFromDot.SelectedItem.ToString()); i <= int.Parse(cmbToDot.SelectedItem.ToString()); i++)
                                                            {
                                                                dt.Merge(_cHoaDon.GetDSTon_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i, int.Parse(txtSoKy.Text.Trim())));
                                                            }
                                                }
                        }
                foreach (DataRow item in dt.Rows)
                    if (!_cDongNuoc.CheckExist_CTDongNuoc(item["SoHoaDon"].ToString()) && !_cLenhHuy.CheckExist(item["SoHoaDon"].ToString()) && !_cDLKH.CheckExist2(item["SoHoaDon"].ToString()))
                    {
                        DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                        dr["LoaiBaoCao"] = "TƯ GIA TỒN";
                        dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                        dr["Ky"] = item["Ky"];
                        dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                        dr["TongCong"] = item["TongCong"];
                        dr["SoPhatHanh"] = item["SoPhatHanh"];
                        dr["SoHoaDon"] = item["SoHoaDon"];
                        dr["NhanVien"] = dgvHDTuGia.SelectedRows[0].Cells["HoTen_TG"].Value.ToString();
                        ds.Tables["DSHoaDon"].Rows.Add(dr);
                    }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    if (chkDenKy.Checked && chkNgayKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetDSTonDenKyDenNgay_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                    }
                    else
                        if (chkDenKy.Checked)
                        {
                            if (cmbNhanVien.SelectedIndex == 0)
                                dt = _cHoaDon.GetDSTonDenKy_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                            else
                                if (cmbNhanVien.SelectedIndex > 0)
                                {
                                    if (cmbFromDot.SelectedIndex == 0)
                                        for (int i = 1; i <= 20; i++)
                                        {
                                            dt.Merge(_cHoaDon.GetDSTonDenKy_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i, int.Parse(txtSoKy.Text.Trim())));
                                        }
                                    else
                                        if (cmbFromDot.SelectedIndex > 0)
                                            for (int i = int.Parse(cmbFromDot.SelectedItem.ToString()); i <= int.Parse(cmbToDot.SelectedItem.ToString()); i++)
                                            {
                                                dt.Merge(_cHoaDon.GetDSTonDenKy_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i, int.Parse(txtSoKy.Text.Trim())));
                                            }
                                }
                        }
                        else
                            if (chkNgayKiemTra.Checked)
                            {
                                dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                            }
                            else
                            {
                                if (cmbNam.SelectedIndex == 0)
                                    dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                else
                                    if (cmbNam.SelectedIndex > 0)
                                        if (cmbKy.SelectedIndex == 0)
                                            dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                        else
                                            if (cmbKy.SelectedIndex > 0)
                                                if (cmbNhanVien.SelectedIndex == 0)
                                                    dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                                else
                                                    if (cmbNhanVien.SelectedIndex > 0)
                                                    {
                                                        if (cmbFromDot.SelectedIndex == 0)
                                                            for (int i = 1; i <= 20; i++)
                                                            {
                                                                dt.Merge(_cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i, int.Parse(txtSoKy.Text.Trim())));
                                                            }
                                                        else
                                                            if (cmbFromDot.SelectedIndex > 0)
                                                                for (int i = int.Parse(cmbFromDot.SelectedItem.ToString()); i <= int.Parse(cmbToDot.SelectedItem.ToString()); i++)
                                                                {
                                                                    dt.Merge(_cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i, int.Parse(txtSoKy.Text.Trim())));
                                                                }
                                                    }
                            }
                    foreach (DataRow item in dt.Rows)
                        if (!_cDongNuoc.CheckExist_CTDongNuoc(item["SoHoaDon"].ToString()) && !_cLenhHuy.CheckExist(item["SoHoaDon"].ToString()) && !_cDLKH.CheckExist2(item["SoHoaDon"].ToString()))
                        {
                            DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                            dr["LoaiBaoCao"] = "CƠ QUAN TỒN";
                            dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                            dr["Ky"] = item["Ky"];
                            dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                            dr["TongCong"] = item["TongCong"];
                            dr["SoPhatHanh"] = item["SoPhatHanh"];
                            dr["SoHoaDon"] = item["SoHoaDon"];
                            dr["NhanVien"] = dgvHDCoQuan.SelectedRows[0].Cells["HoTen_CQ"].Value.ToString();
                            ds.Tables["DSHoaDon"].Rows.Add(dr);
                        }
                }
            rptDSHoaDon rpt = new rptDSHoaDon();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void chkKyKiemTra_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDenKy.Checked)
                chkTrongKy.Checked = false;
        }

        private void chkTrongKy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTrongKy.Checked)
                chkDenKy.Checked = false;
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dsBaoCao dsBaoCao = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if ((chkDenKy.Checked || chkTrongKy.Checked) && chkNgayKiemTra.Checked)
                {
                    if (chkDenKy.Checked)
                        dt = _cHoaDon.GetBaoCaoTonDenKyDenNgay_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                    else
                        if (chkTrongKy.Checked)
                            dt = _cHoaDon.GetBaoCaoTonTrongKyDenNgay_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                }
                else
                    if (chkDenKy.Checked)
                    {
                        dt = _cHoaDon.GetBaoCaoTonDenKy_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    }
                    else
                        if (chkNgayKiemTra.Checked)
                        {
                            dt = _cHoaDon.GetBaoCaoTon_To("TG", CNguoiDung.MaTo, dateGiaiTrach.Value);
                        }
                        else
                        {
                            ///chọn tất cả các năm
                            if (cmbNam.SelectedIndex == 0)
                            {
                                dt = _cHoaDon.GetBaoCaoTon_To("TG", CNguoiDung.MaTo);
                            }
                            else
                                ///chọn 1 năm cụ thể
                                if (cmbNam.SelectedIndex > 0)
                                    ///chọn tất cả các kỳ
                                    if (cmbKy.SelectedIndex == 0)
                                    {
                                        dt = _cHoaDon.GetBaoCaoTon_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                                    }
                                    ///chọn 1 kỳ cụ thể
                                    else
                                        if (cmbKy.SelectedIndex > 0)
                                        ///chọn tất cả các đợt
                                        {
                                            dt = _cHoaDon.GetBaoCaoTon_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                        }
                        }
                foreach (DataRow item in dt.Rows)
                {
                    int SoLuong = 0;
                    int TongCong = 0;
                    DataRow dr = dsBaoCao.Tables["BaoCaoTon"].NewRow();
                    dr["LoaiBaoCao"] = "TƯ GIA";
                    dr["To"] = item["TenTo"];
                    dr["HanhThu"] = item["HoTen"];
                    dr["LenhHuySL"] = item["LenhHuySL"];
                    dr["LenhHuyTC"] = item["LenhHuyTC"];
                    dr["DongNuocSL"] = item["DongNuocSL"];
                    dr["DongNuocTC"] = item["DongNuocTC"];
                    dr["ChuyenKhoanSL"] = item["ChuyenKhoanSL"];
                    dr["ChuyenKhoanTC"] = item["ChuyenKhoanTC"];
                    dr["TongSL"] = item["TongSL"];
                    dr["TongTC"] = item["TongTC"];
                    if (!string.IsNullOrEmpty(item["LenhHuySL"].ToString()))
                    {
                        SoLuong -= int.Parse(item["LenhHuySL"].ToString());
                        TongCong -= int.Parse(item["LenhHuyTC"].ToString());
                    }
                    if (!string.IsNullOrEmpty(item["DongNuocSL"].ToString()))
                    {
                        SoLuong -= int.Parse(item["DongNuocSL"].ToString());
                        TongCong -= int.Parse(item["DongNuocTC"].ToString());
                    }
                    if (!string.IsNullOrEmpty(item["ChuyenKhoanSL"].ToString()))
                    {
                        SoLuong -= int.Parse(item["ChuyenKhoanSL"].ToString());
                        TongCong -= int.Parse(item["ChuyenKhoanTC"].ToString());
                    }
                    if (!string.IsNullOrEmpty(item["TongSL"].ToString()))
                    {
                        SoLuong += int.Parse(item["TongSL"].ToString());
                        TongCong += int.Parse(item["TongTC"].ToString());
                    }
                    dr["ThucTeSL"] = SoLuong;
                    dr["ThucTeTC"] = TongCong;
                    dsBaoCao.Tables["BaoCaoTon"].Rows.Add(dr);
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    if ((chkDenKy.Checked || chkTrongKy.Checked) && chkNgayKiemTra.Checked)
                    {
                        if (chkDenKy.Checked)
                            dt = _cHoaDon.GetBaoCaoTonDenKyDenNgay_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                        else
                            if (chkTrongKy.Checked)
                                dt = _cHoaDon.GetBaoCaoTonTrongKyDenNgay_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                    }
                    else
                        if (chkDenKy.Checked)
                        {
                            dt = _cHoaDon.GetBaoCaoTonDenKy_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                        }
                        else
                            if (chkNgayKiemTra.Checked)
                            {
                                dt = _cHoaDon.GetBaoCaoTon_To("CQ", CNguoiDung.MaTo, dateGiaiTrach.Value);
                            }
                            else
                            {
                                ///chọn tất cả các năm
                                if (cmbNam.SelectedIndex == 0)
                                {
                                    dt = _cHoaDon.GetBaoCaoTon_To("CQ", CNguoiDung.MaTo);
                                }
                                else
                                    ///chọn 1 năm cụ thể
                                    if (cmbNam.SelectedIndex > 0)
                                        ///chọn tất cả các kỳ
                                        if (cmbKy.SelectedIndex == 0)
                                        {
                                            dt = _cHoaDon.GetBaoCaoTon_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                                        }
                                        ///chọn 1 kỳ cụ thể
                                        else
                                            if (cmbKy.SelectedIndex > 0)
                                            ///chọn tất cả các đợt
                                            {
                                                dt = _cHoaDon.GetBaoCaoTon_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                            }
                            }
                    foreach (DataRow item in dt.Rows)
                    {
                        int SoLuong = 0;
                        int TongCong = 0;
                        DataRow dr = dsBaoCao.Tables["BaoCaoTon"].NewRow();
                        dr["LoaiBaoCao"] = "CƠ QUAN";
                        dr["To"] = item["TenTo"];
                        dr["HanhThu"] = item["HoTen"];
                        dr["LenhHuySL"] = item["LenhHuySL"];
                        dr["LenhHuyTC"] = item["LenhHuyTC"];
                        dr["DongNuocSL"] = item["DongNuocSL"];
                        dr["DongNuocTC"] = item["DongNuocTC"];
                        dr["ChuyenKhoanSL"] = item["ChuyenKhoanSL"];
                        dr["ChuyenKhoanTC"] = item["ChuyenKhoanTC"];
                        dr["TongSL"] = item["TongSL"];
                        dr["TongTC"] = item["TongTC"];
                        if (!string.IsNullOrEmpty(item["LenhHuySL"].ToString()))
                        {
                            SoLuong -= int.Parse(item["LenhHuySL"].ToString());
                            TongCong -= int.Parse(item["LenhHuyTC"].ToString());
                        }
                        if (!string.IsNullOrEmpty(item["DongNuocSL"].ToString()))
                        {
                            SoLuong -= int.Parse(item["DongNuocSL"].ToString());
                            TongCong -= int.Parse(item["DongNuocTC"].ToString());
                        }
                        if (!string.IsNullOrEmpty(item["ChuyenKhoanSL"].ToString()))
                        {
                            SoLuong -= int.Parse(item["ChuyenKhoanSL"].ToString());
                            TongCong -= int.Parse(item["ChuyenKhoanTC"].ToString());
                        }
                        if (!string.IsNullOrEmpty(item["TongSL"].ToString()))
                        {
                            SoLuong += int.Parse(item["TongSL"].ToString());
                            TongCong += int.Parse(item["TongTC"].ToString());
                        }
                        dr["ThucTeSL"] = SoLuong;
                        dr["ThucTeTC"] = TongCong;
                        dsBaoCao.Tables["BaoCaoTon"].Rows.Add(dr);
                    }
                }
            rptBaoCaoTon rpt = new rptBaoCaoTon();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }
    }
}

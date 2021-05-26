using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using System.Globalization;
using ThuTien.DAL.DongNuoc;

namespace ThuTien.GUI.DongNuoc
{
    public partial class frmTheoDoiDongNuoc : Form
    {
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CDongNuoc _cDongNuoc = new CDongNuoc();

        public frmTheoDoiDongNuoc()
        {
            InitializeComponent();
        }

        private void frmTheoDoiDongNuoc_Load(object sender, EventArgs e)
        {
            cmbNhanVienDongNuoc.DataSource = _cNguoiDung.getDS_DongNuoc();
            cmbNhanVienDongNuoc.DisplayMember = "HoTen";
            cmbNhanVienDongNuoc.ValueMember = "MaND";

            gridControl.LevelTree.Nodes.Add("Chi Tiết Đóng Nước", gridViewCTDN);

            cmbTimTheo.SelectedIndex = 0;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataSet ds = null;

            ds = _cDongNuoc.getDS_Ton(cmbTimTheo.SelectedItem.ToString(), int.Parse(cmbNhanVienDongNuoc.SelectedValue.ToString()));

            gridControl.DataSource = ds.Tables["DongNuoc"];

            decimal TongHD = 0, TongCong = 0;
            for (int i = 0; i < gridViewDN.DataRowCount; i++)
            {
                DataRow row = gridViewDN.GetDataRow(i);
                DataRow[] childRows = row.GetChildRows("Chi Tiết Đóng Nước");

                string TinhTrang = "Tồn";
                int DangNgan = 0;
                foreach (DataRow itemChild in childRows)
                {
                    if (!string.IsNullOrEmpty(itemChild["NgayGiaiTrach"].ToString()))
                    {
                        DangNgan++;
                    }
                    if (DangNgan == childRows.Count())
                        TinhTrang = "Đăng Ngân";
                    //if (_cDongNuoc.CheckExist_KQDongNuoc(int.Parse(row["MaDN"].ToString())))
                    //{
                    //    TinhTrang = "Đã Khóa Nước";
                    //}
                    if (!string.IsNullOrEmpty(row["MaKQDN"].ToString()))
                        TinhTrang = "Đã Khóa Nước";
                    TongHD++;
                    TongCong += int.Parse(itemChild["TongCong"].ToString());
                }
                gridViewDN.SetRowCellValue(i, "TinhTrang", TinhTrang);
            }
            txtTongLenh.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", gridViewDN.DataRowCount);
            txtTongHD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
            txtTongCong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
        }

        private void gridViewDN_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MLT" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (e.Column.FieldName == "DanhBo" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (e.Column.FieldName == "MaDN" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (e.Column.FieldName == "TongCongLenh" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            //if (e.Column.FieldName == "CreateBy" && !string.IsNullOrEmpty(e.Value.ToString()))
            //{
            //    e.DisplayText = _cNguoiDung.GetHoTenByMaND(int.Parse(e.Value.ToString()));
            //}
            //if (e.Column.FieldName == "MaNV_DongNuoc" && !string.IsNullOrEmpty(e.Value.ToString()))
            //{
            //    e.DisplayText = _cNguoiDung.GetHoTenByMaND(int.Parse(e.Value.ToString()));
            //}
        }

        private void gridViewDN_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridViewCTDN_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "TieuThu" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (e.Column.FieldName == "GiaBan" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (e.Column.FieldName == "ThueGTGT" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (e.Column.FieldName == "PhiBVMT" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (e.Column.FieldName == "TongCong" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }
    }
}

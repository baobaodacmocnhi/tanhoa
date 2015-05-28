using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using System.Globalization;
using ThuTien.DAL.DongNuoc;

namespace ThuTien.GUI.Doi
{
    public partial class frmXemTBDongNuoc : Form
    {
        CTo _cTo = new CTo();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CDongNuoc _cDongNuoc = new CDongNuoc();

        public frmXemTBDongNuoc()
        {
            InitializeComponent();
        }

        private void frmXemTBDongNuoc_Load(object sender, EventArgs e)
        {
            List<TT_To> lst = _cTo.GetDSHanhThu();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            lst.Insert(0, to);
            cmbTo.DataSource = lst;
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";

            gridControl.LevelTree.Nodes.Add("Chi Tiết Đóng Nước", gridViewCTDN);
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTo.SelectedIndex > 0)
            {
                List<TT_NguoiDung> lst = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbTo.SelectedValue.ToString()));
                TT_NguoiDung nguoidung = new TT_NguoiDung();
                nguoidung.MaND = 0;
                nguoidung.HoTen = "Tất Cả";
                lst.Insert(0, nguoidung);
                cmbNhanVien.DataSource = lst;
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaND";
            }
            else
            {
                cmbNhanVien.DataSource = null;
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            ///tất cả các tổ
            if (cmbTo.SelectedIndex == 0)
            {
                List<TT_To> lst = _cTo.GetDSHanhThu();
                DataSet ds = new DataSet();

                foreach (TT_To item in lst)
                {
                    List<TT_NguoiDung> lstND = _cNguoiDung.GetDSHanhThuByMaTo(item.MaTo);

                    foreach (TT_NguoiDung itemND in lstND)
                    {
                        if (ds.Tables.Count == 0)
                            ds = _cDongNuoc.GetDSByMaNVCreateDates(itemND.MaND, dateTu.Value, dateDen.Value);
                        else
                            ds.Merge(_cDongNuoc.GetDSByMaNVCreateDates(itemND.MaND, dateTu.Value, dateDen.Value));
                    }
                }
                gridControl.DataSource = ds.Tables["DongNuoc"];
            }
            ///chọn 1 tổ nhất định
            else
            {
                ///chọn tất cả nhân viên
                if (cmbNhanVien.SelectedIndex == 0)
                {
                    DataSet ds = new DataSet();
                    for (int i = 1; i < cmbNhanVien.Items.Count; i++)
                    {
                        if (ds.Tables.Count == 0)
                            ds = _cDongNuoc.GetDSByMaNVCreateDates(((TT_NguoiDung)cmbNhanVien.Items[i]).MaND, dateTu.Value, dateDen.Value);
                        else
                            ds.Merge(_cDongNuoc.GetDSByMaNVCreateDates(((TT_NguoiDung)cmbNhanVien.Items[i]).MaND, dateTu.Value, dateDen.Value));
                    }
                    gridControl.DataSource = ds.Tables["DongNuoc"];
                }
                ///chọn 1 nhân viên nhất định
                else
                {
                    gridControl.DataSource = _cDongNuoc.GetDSByMaNVCreateDates(int.Parse(cmbNhanVien.SelectedValue.ToString()), dateTu.Value, dateDen.Value).Tables["DongNuoc"];
                }
            }
        }

        private void gridViewDN_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaDN" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (e.Column.FieldName == "CreateBy" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.DisplayText = _cNguoiDung.GetHoTenByMaND(int.Parse(e.Value.ToString()));
            }
            if (e.Column.FieldName == "MaNV_DongNuoc" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.DisplayText = _cNguoiDung.GetHoTenByMaND(int.Parse(e.Value.ToString()));
            }
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

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
    public partial class frmXemTBDongNuocDoi : Form
    {
        CTo _cTo = new CTo();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        DataTable _dtTongTo = new DataTable();
        DataTable _dtTongNV = new DataTable();

        public frmXemTBDongNuocDoi()
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

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;

            DataColumn cl1 = new DataColumn("TenTo");
            DataColumn cl2 = new DataColumn("Tong");
            DataColumn cl3 = new DataColumn("TongThu");
            DataColumn cl4 = new DataColumn("TongDN");
            DataColumn cl5 = new DataColumn("TongTon");

            _dtTongTo.Columns.Add(cl1);
            _dtTongTo.Columns.Add(cl2);
            _dtTongTo.Columns.Add(cl3);
            _dtTongTo.Columns.Add(cl4);
            _dtTongTo.Columns.Add(cl5);
            _dtTongTo.PrimaryKey = new DataColumn[] { _dtTongTo.Columns["TenTo"] };

             cl1 = new DataColumn("TenNV");
             cl2 = new DataColumn("Tong_NV");
             cl3 = new DataColumn("TongThu_NV");
             cl4 = new DataColumn("TongDN_NV");
             cl5 = new DataColumn("TongTon_NV");
            _dtTongNV.Columns.Add(cl1);
            _dtTongNV.Columns.Add(cl2);
            _dtTongNV.Columns.Add(cl3);
            _dtTongNV.Columns.Add(cl4);
            _dtTongNV.Columns.Add(cl5);
            _dtTongNV.PrimaryKey = new DataColumn[] { _dtTongNV.Columns["TenNV"] };
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
            _dtTongTo.Rows.Clear();
            _dtTongNV.Rows.Clear();

            ///tất cả các tổ
            if (cmbTo.SelectedIndex == 0)
            {
                List<TT_To> lstTo = _cTo.GetDSHanhThu();
                DataSet ds = new DataSet();

                foreach (TT_To item in lstTo)
                {
                    ///kê khai Tổ để Count số lượng ở bên dưới
                    DataRow drTo = _dtTongTo.NewRow();
                    drTo["TenTo"] = item.TenTo;
                    drTo["Tong"] = 0;
                    drTo["TongThu"] = 0;
                    drTo["TongDN"] = 0;
                    drTo["TongTon"] = 0;
                    _dtTongTo.Rows.Add(drTo);

                    List<TT_NguoiDung> lstND_DN = _cNguoiDung.GetDSDongNuocByMaTo(item.MaTo);
                    foreach (TT_NguoiDung itemND in lstND_DN)
                    {
                        ///kê khai NV để Count số lượng ở bên dưới
                        DataRow drNV = _dtTongNV.NewRow();
                        drNV["TenNV"] = itemND.HoTen;
                        drNV["Tong_NV"] = 0;
                        drNV["TongThu_NV"] = 0;
                        drNV["TongDN_NV"] = 0;
                        drNV["TongTon_NV"] = 0;
                        _dtTongNV.Rows.Add(drNV);
                    }

                    List<TT_NguoiDung> lstND = _cNguoiDung.GetDSHanhThuByMaTo(item.MaTo);
                    foreach (TT_NguoiDung itemND in lstND)
                    {
                        if (ds.Tables.Count == 0)
                            ds = _cDongNuoc.GetDSByCreateByCreateDates(item.TenTo, itemND.MaND, dateTu.Value, dateDen.Value);
                        else
                            ds.Merge(_cDongNuoc.GetDSByCreateByCreateDates(item.TenTo, itemND.MaND, dateTu.Value, dateDen.Value));
                    }
                }
                gridControl.DataSource = ds.Tables["DongNuoc"];
            }
            else
                ///chọn 1 tổ nhất định
                if (cmbTo.SelectedIndex > 0)
                {
                    ///kê khai Tổ để Count số lượng ở bên dưới
                    DataRow dr = _dtTongTo.NewRow();
                    dr["TenTo"] = ((TT_To)cmbTo.SelectedItem).TenTo;
                    dr["Tong"] = 0;
                    dr["TongThu"] = 0;
                    dr["TongDN"] = 0;
                    dr["TongTon"] = 0;
                    _dtTongTo.Rows.Add(dr);

                    List<TT_NguoiDung> lstND_DN = _cNguoiDung.GetDSDongNuocByMaTo(((TT_To)cmbTo.SelectedItem).MaTo);
                    foreach (TT_NguoiDung itemND in lstND_DN)
                    {
                        ///kê khai NV để Count số lượng ở bên dưới
                        DataRow drNV = _dtTongNV.NewRow();
                        drNV["TenNV"] = itemND.HoTen;
                        drNV["Tong_NV"] = 0;
                        drNV["TongThu_NV"] = 0;
                        drNV["TongDN_NV"] = 0;
                        drNV["TongTon_NV"] = 0;
                        _dtTongNV.Rows.Add(drNV);

                    }
                    ///chọn tất cả nhân viên
                    if (cmbNhanVien.SelectedIndex == 0)
                    {
                        DataSet ds = new DataSet();
                        for (int i = 1; i < cmbNhanVien.Items.Count; i++)
                        {
                            if (ds.Tables.Count == 0)
                                ds = _cDongNuoc.GetDSByCreateByCreateDates(((TT_To)cmbTo.SelectedItem).TenTo, ((TT_NguoiDung)cmbNhanVien.Items[i]).MaND, dateTu.Value, dateDen.Value);
                            else
                                ds.Merge(_cDongNuoc.GetDSByCreateByCreateDates(((TT_To)cmbTo.SelectedItem).TenTo, ((TT_NguoiDung)cmbNhanVien.Items[i]).MaND, dateTu.Value, dateDen.Value));
                        }
                        gridControl.DataSource = ds.Tables["DongNuoc"];
                    }
                    else
                        ///chọn 1 nhân viên nhất định
                        if (cmbNhanVien.SelectedIndex > 0)
                        {
                            gridControl.DataSource = _cDongNuoc.GetDSByCreateByCreateDates(((TT_To)cmbTo.SelectedItem).TenTo, int.Parse(cmbNhanVien.SelectedValue.ToString()), dateTu.Value, dateDen.Value).Tables["DongNuoc"];
                        }
                }

            ///Kiểm Tra Tình Trạng, Giải Trách hết Hóa Đơn trong Thông Báo Đóng Nước mới tính
            for (int i = 0; i < gridViewDN.DataRowCount; i++)
            {
                DataRow row = gridViewDN.GetDataRow(i);

                DataRow[] rowTongTo = _dtTongTo.Select("TenTo like '" + row["TenTo"].ToString() + "'");
                DataRow[] rowTongNV = _dtTongNV.Select("TenNV like '" + row["HoTen_DongNuoc"].ToString() + "'");

                DataRow[] childRows = row.GetChildRows("Chi Tiết Đóng Nước");

                string TinhTrang = "Tồn";
                int DangNgan = 0;
                foreach (DataRow itemChild in childRows)
                {
                    DateTime NgayGiaiTrach;
                    DateTime.TryParse(itemChild["NgayGiaiTrach"].ToString(), out NgayGiaiTrach);
                    ///xét ngày đăng ngân để lấy tồn lùi
                    if (!string.IsNullOrEmpty(itemChild["NgayGiaiTrach"].ToString()) && NgayGiaiTrach.Date <= dateDen.Value.Date)
                    {
                        //TinhTrang = "Đăng Ngân";
                        DangNgan++;
                    }
                    if (DangNgan == childRows.Count())
                        TinhTrang = "Đăng Ngân";
                    if (_cDongNuoc.CheckExist_KQDongNuoc(int.Parse(row["MaDN"].ToString()), dateDen.Value.Date))
                    {
                        TinhTrang = "Đã Khóa Nước";
                    }
                }
                gridViewDN.SetRowCellValue(i, "TinhTrang", TinhTrang);

                rowTongTo[0]["Tong"] = int.Parse(rowTongTo[0]["Tong"].ToString()) + 1;

                if (TinhTrang == "Tồn")
                    rowTongTo[0]["TongTon"] = int.Parse(rowTongTo[0]["TongTon"].ToString()) + 1;
                else
                    if (TinhTrang == "Đăng Ngân")
                        rowTongTo[0]["TongThu"] = int.Parse(rowTongTo[0]["TongThu"].ToString()) + 1;
                    else
                        if (TinhTrang == "Đã Khóa Nước")
                            rowTongTo[0]["TongDN"] = int.Parse(rowTongTo[0]["TongDN"].ToString()) + 1;

                if (rowTongNV.Count() > 0)
                {
                    rowTongNV[0]["Tong_NV"] = int.Parse(rowTongNV[0]["Tong_NV"].ToString()) + 1;

                    if (TinhTrang == "Tồn")
                        rowTongNV[0]["TongTon_NV"] = int.Parse(rowTongNV[0]["TongTon_NV"].ToString()) + 1;
                    else
                        if (TinhTrang == "Đăng Ngân")
                            rowTongNV[0]["TongThu_NV"] = int.Parse(rowTongNV[0]["TongThu_NV"].ToString()) + 1;
                        else
                            if (TinhTrang == "Đã Khóa Nước")
                                rowTongNV[0]["TongDN_NV"] = int.Parse(rowTongNV[0]["TongDN_NV"].ToString()) + 1;
                }
            }

            dgvTongDN_To.DataSource = _dtTongTo;
            dgvTongDN_NV.DataSource = _dtTongNV;
        }

        private void gridViewDN_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaDN" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (e.Column.FieldName == "DanhBo" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (e.Column.FieldName == "TongCong" && e.Value != null)
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
            if (e.Column.FieldName == "MLT" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
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

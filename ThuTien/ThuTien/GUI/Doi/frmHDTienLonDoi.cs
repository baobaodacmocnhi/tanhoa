using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using System.Globalization;
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL.Quay;

namespace ThuTien.GUI.Doi
{
    public partial class frmHDTienLonDoi : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();
        CTo _cTo = new CTo();
        List<TT_To> _lstTo;
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CLenhHuy _cLenhHuy = new CLenhHuy();

        public frmHDTienLonDoi()
        {
            InitializeComponent();
        }

        private void frmHDTienLonDoi_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            DataTable dtNam = _cHoaDon.GetNam();
            DataRow dr = dtNam.NewRow();
            dr["ID"] = "Tất Cả";
            dtNam.Rows.InsertAt(dr, 0);
            cmbNam.DataSource = dtNam;
            cmbNam.DisplayMember = "ID";
            cmbNam.ValueMember = "Nam";

            _lstTo = _cTo.getDS_HanhThu(CNguoiDung.IDPhong);
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            _lstTo.Insert(0, to);
            cmbTo.DataSource = _lstTo;
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";
            cmbDot.Items.Add("Tất Cả");
            for (int i = CNguoiDung.FromDot; i <= CNguoiDung.ToDot; i++)
            {
                cmbDot.Items.Add(i.ToString());
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if (cmbTo.SelectedIndex == 0)
                {
                    ///chọn tất cả các năm
                    if (cmbNam.SelectedIndex == 0)
                    {
                        foreach (TT_To item in _lstTo)
                        {
                            dt.Merge(_cHoaDon.GetDSByTienLon_Doi("TG", chkLayChinhXacSoTien.Checked, chkTon.Checked, item.MaTo, int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                        }
                    }
                    else
                        ///chọn 1 năm cụ thể
                        if (cmbNam.SelectedIndex > 0)
                            ///chọn tất cả các kỳ
                            if (cmbKy.SelectedIndex == 0)
                            {
                                foreach (TT_To item in _lstTo)
                                {
                                    dt.Merge(_cHoaDon.GetDSByTienLon_Doi("TG", chkLayChinhXacSoTien.Checked, chkTon.Checked, item.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                                }
                            }
                            ///chọn 1 kỳ cụ thể
                            else
                                if (cmbKy.SelectedIndex > 0)
                                    ///chọn tất cả các đợt
                                    if (cmbDot.SelectedIndex == 0)
                                    {
                                        foreach (TT_To item in _lstTo)
                                        {
                                            dt.Merge(_cHoaDon.GetDSByTienLon_Doi("TG", chkLayChinhXacSoTien.Checked, chkTon.Checked, item.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                                        }
                                    }
                                    ///chọn 1 đợt cụ thể
                                    else
                                        if (cmbDot.SelectedIndex > 0)
                                        {
                                            foreach (TT_To item in _lstTo)
                                            {
                                                dt.Merge(_cHoaDon.GetDSByTienLon_Doi("TG", chkLayChinhXacSoTien.Checked, chkTon.Checked, item.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                                            }
                                        }
                }
                else
                    if (cmbTo.SelectedIndex > 0)
                    {
                        ///chọn tất cả các năm
                        if (cmbNam.SelectedIndex == 0)
                        {
                            dt = _cHoaDon.GetDSByTienLon_Doi("TG", chkLayChinhXacSoTien.Checked, chkTon.Checked, int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                        }
                        else
                            ///chọn 1 năm cụ thể
                            if (cmbNam.SelectedIndex > 0)
                                ///chọn tất cả các kỳ
                                if (cmbKy.SelectedIndex == 0)
                                {
                                    dt = _cHoaDon.GetDSByTienLon_Doi("TG", chkLayChinhXacSoTien.Checked, chkTon.Checked, int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                                }
                                ///chọn 1 kỳ cụ thể
                                else
                                    if (cmbKy.SelectedIndex > 0)
                                        ///chọn tất cả các đợt
                                        if (cmbDot.SelectedIndex == 0)
                                        {
                                            dt = _cHoaDon.GetDSByTienLon_Doi("TG", chkLayChinhXacSoTien.Checked, chkTon.Checked, int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                                        }
                                        ///chọn 1 đợt cụ thể
                                        else
                                            if (cmbDot.SelectedIndex > 0)
                                            {
                                                dt = _cHoaDon.GetDSByTienLon_Doi("TG", chkLayChinhXacSoTien.Checked, chkTon.Checked, int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                                            }
                    }

                dgvHDTuGia.DataSource = dt;
                //dgvHDTuGia.Sort(dgvHDTuGia.Columns["NgayGiaiTrach_TG"], ListSortDirection.Ascending);
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    if (bool.Parse(item.Cells["DongNuoc_TG"].Value.ToString()))
                        item.DefaultCellStyle.BackColor = Color.Yellow;
                    if (bool.Parse(item.Cells["LenhHuy_TG"].Value.ToString()))
                        item.DefaultCellStyle.BackColor = Color.Red;
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    if (cmbTo.SelectedIndex == 0)
                    {
                        ///chọn tất cả các năm
                        if (cmbNam.SelectedIndex == 0)
                        {
                            foreach (TT_To item in _lstTo)
                            {
                                dt.Merge(_cHoaDon.GetDSByTienLon_Doi("CQ", chkLayChinhXacSoTien.Checked, chkTon.Checked, item.MaTo, int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                            }
                        }
                        else
                            ///chọn 1 năm cụ thể
                            if (cmbNam.SelectedIndex > 0)
                                ///chọn tất cả các kỳ
                                if (cmbKy.SelectedIndex == 0)
                                {
                                    foreach (TT_To item in _lstTo)
                                    {
                                        dt.Merge(_cHoaDon.GetDSByTienLon_Doi("CQ", chkLayChinhXacSoTien.Checked, chkTon.Checked, item.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                                    }
                                }
                                ///chọn 1 kỳ cụ thể
                                else
                                    if (cmbKy.SelectedIndex > 0)
                                        ///chọn tất cả các đợt
                                        if (cmbDot.SelectedIndex == 0)
                                        {
                                            foreach (TT_To item in _lstTo)
                                            {
                                                dt.Merge(_cHoaDon.GetDSByTienLon_Doi("CQ", chkLayChinhXacSoTien.Checked, chkTon.Checked, item.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                                            }
                                        }
                                        ///chọn 1 đợt cụ thể
                                        else
                                            if (cmbDot.SelectedIndex > 0)
                                            {
                                                foreach (TT_To item in _lstTo)
                                                {
                                                    dt.Merge(_cHoaDon.GetDSByTienLon_Doi("CQ", chkLayChinhXacSoTien.Checked, chkTon.Checked, item.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                                                }
                                            }
                    }
                    else
                        if (cmbTo.SelectedIndex > 0)
                        {
                            ///chọn tất cả các năm
                            if (cmbNam.SelectedIndex == 0)
                            {
                                dt = _cHoaDon.GetDSByTienLon_Doi("CQ", chkLayChinhXacSoTien.Checked, chkTon.Checked, int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                            }
                            else
                                ///chọn 1 năm cụ thể
                                if (cmbNam.SelectedIndex > 0)
                                    ///chọn tất cả các kỳ
                                    if (cmbKy.SelectedIndex == 0)
                                    {
                                        dt = _cHoaDon.GetDSByTienLon_Doi("CQ", chkLayChinhXacSoTien.Checked, chkTon.Checked, int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                                    }
                                    ///chọn 1 kỳ cụ thể
                                    else
                                        if (cmbKy.SelectedIndex > 0)
                                            ///chọn tất cả các đợt
                                            if (cmbDot.SelectedIndex == 0)
                                            {
                                                dt = _cHoaDon.GetDSByTienLon_Doi("CQ", chkLayChinhXacSoTien.Checked, chkTon.Checked, int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                                            }
                                            ///chọn 1 đợt cụ thể
                                            else
                                                if (cmbDot.SelectedIndex > 0)
                                                {
                                                    dt = _cHoaDon.GetDSByTienLon_Doi("CQ", chkLayChinhXacSoTien.Checked, chkTon.Checked, int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                                                }
                        }

                    dgvHDCoQuan.DataSource = dt;
                    //dgvHDCoQuan.Sort(dgvHDCoQuan.Columns["NgayGiaiTrach_CQ"], ListSortDirection.Ascending);
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                    {
                        if (bool.Parse(item.Cells["DongNuoc_TG"].Value.ToString()))
                            item.DefaultCellStyle.BackColor = Color.Yellow;
                        if (bool.Parse(item.Cells["LenhHuy_TG"].Value.ToString()))
                            item.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoTien_Leave(object sender, EventArgs e)
        {
            txtSoTien.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
        }

        private void dgvHDTuGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "DanhBo_TG" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TieuThu_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "GiaBan_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "ThueGTGT_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "PhiBVMT_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCong_TG" && e.Value != null)
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

        private void dgvHDCoQuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "DanhBo_CQ" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TieuThu_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "GiaBan_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "ThueGTGT_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "PhiBVMT_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCong_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDCoQuan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDCoQuan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHDTuGia_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dgvHDTuGia.Rows)
            {
                if (_cDongNuoc.CheckExist_CTDongNuoc(item.Cells["SoHoaDon_TG"].Value.ToString()))
                    item.DefaultCellStyle.BackColor = Color.Yellow;
                item.Cells["NgayDN_TG"].Value = _cDongNuoc.GetNgayDongNuoc(item.Cells["SoHoaDon_TG"].Value.ToString());
                if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon_TG"].Value.ToString()))
                    item.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void dgvHDCoQuan_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
            {
                if (_cDongNuoc.CheckExist_CTDongNuoc(item.Cells["SoHoaDon_CQ"].Value.ToString()))
                    item.DefaultCellStyle.BackColor = Color.Yellow;
                item.Cells["NgayDN_CQ"].Value = _cDongNuoc.GetNgayDongNuoc(item.Cells["SoHoaDon_CQ"].Value.ToString());
                if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon_CQ"].Value.ToString()))
                    item.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                DataTable dt = (DataTable)dgvHDTuGia.DataSource;

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

                XuatExcel(dt, oSheet, "TIỀN LỚN TƯ GIA");
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    DataTable dt = (DataTable)dgvHDCoQuan.DataSource;

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

                    XuatExcel(dt, oSheet, "TIỀN LỚN CƠ QUAN");
                }
        }

        private void XuatExcel(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName)
        {
            oSheet.Name = SheetName;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
            cl1.Value2 = "Số Hóa Đơn";
            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
            cl2.Value2 = "Kỳ";
            cl2.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
            cl3.Value2 = "Danh Bộ";
            cl3.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
            cl4.Value2 = "Khách Hàng";
            cl4.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("E1", "E1");
            cl12.Value2 = "Địa Chỉ";
            cl12.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("F1", "F1");
            cl5.Value2 = "MLT";
            cl5.ColumnWidth = 12;

            //Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("G1", "G1");
            //cl6.Value2 = "Giá Bán";
            //cl6.ColumnWidth = 15;

            //Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("H1", "H1");
            //cl7.Value2 = "Thuế GTGT";
            //cl7.ColumnWidth = 15;

            //Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("I1", "I1");
            //cl8.Value2 = "Phí BVMT";
            //cl8.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("G1", "G1");
            cl9.Value2 = "Tổng Cộng";
            cl9.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("H1", "H1");
            cl10.Value2 = "Hành Thu";
            cl10.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("I1", "I1");
            cl11.Value2 = "Tổ";
            cl11.ColumnWidth = 5;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 9];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = dr["SoHoaDon"].ToString();
                arr[i, 1] = dr["Ky"].ToString();
                arr[i, 2] = dr["DanhBo"].ToString();
                arr[i, 3] = dr["HoTen"].ToString();
                arr[i, 4] = dr["DiaChi"].ToString();
                arr[i, 5] = dr["MLT"].ToString();
                //arr[i, 5] = dr["GiaBan"].ToString();
                //arr[i, 6] = dr["ThueGTGT"].ToString();
                //arr[i, 7] = dr["PhiBVMT"].ToString();
                arr[i, 6] = dr["TongCong"].ToString();
                arr[i, 7] = dr["HanhThu"].ToString();
                arr[i, 8] = dr["To"].ToString();
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 9;

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

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }
    }
}

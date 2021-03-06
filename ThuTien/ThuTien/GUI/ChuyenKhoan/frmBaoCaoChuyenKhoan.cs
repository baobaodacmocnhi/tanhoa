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
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.GUI.BaoCao;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmBaoCaoChuyenKhoan : Form
    {
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();
        CBangKe _cBangKe = new CBangKe();
        CTienDu _cTienDu = new CTienDu();
        CNganHang _cNganHang = new CNganHang();
        CPhiMoNuoc _cPMN = new CPhiMoNuoc();
        frmLoading frm;

        public frmBaoCaoChuyenKhoan()
        {
            InitializeComponent();
        }

        private void frmBaoCaoChuyenKhoan_Load(object sender, EventArgs e)
        {
            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
        }

        private void btnXuatExcelTongHopDangNgan_Click(object sender, EventArgs e)
        {
            List<TT_To> lstTo = _cTo.getDS_HanhThu();
            //DataTable[] dtTo = new DataTable[lstTo.Count];

            //dtTo[0] = _cHoaDon.GetTongDangNganChuyenKhoanByMaToNgayGiaiTrachs(lstTo[0].MaTo, dateTu.Value, dateDen.Value);
            //for (int i = 1; i < lstTo.Count; i++)
            //{
            //    dtTo[i] = _cHoaDon.GetTongDangNganChuyenKhoanByMaToNgayGiaiTrachs(lstTo[i].MaTo, dateTu.Value, dateDen.Value);
            //}

            //Tạo các đối tượng Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;

            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            //khai báo số lượng sheet
            oExcel.Application.SheetsInNewWorkbook = lstTo.Count + 1;
            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;

            Microsoft.Office.Interop.Excel.Worksheet[] dtoSheet = new Microsoft.Office.Interop.Excel.Worksheet[lstTo.Count + 1];

            DataTable[] dtTongDangNgan = new DataTable[lstTo.Count];
            DataTable[] dtTongDangNgan_DongA = new DataTable[lstTo.Count];
            DataTable[] dtTongDangNgan_ExceptDongA = new DataTable[lstTo.Count];

            for (int i = 0; i < lstTo.Count; i++)
            {
                dtoSheet[i] = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(i + 1);
                dtTongDangNgan[i] = _cHoaDon.GetTongDangNganChuyenKhoan(lstTo[i].MaTo, dateTu.Value, dateDen.Value);
                dtTongDangNgan_DongA[i] = _cHoaDon.GetTongDangNganChuyenKhoanDongA(lstTo[i].MaTo, dateTu.Value, dateDen.Value);
                dtTongDangNgan_ExceptDongA[i] = _cHoaDon.GetTongDangNganChuyenKhoanExceptDongA(lstTo[i].MaTo, dateTu.Value, dateDen.Value);
                XuatExcelTongHopDangNgan(dtTongDangNgan[i], dtoSheet[i], lstTo[i].TenTo, dateDen.Value.Month.ToString() + "/" + dateDen.Value.Year.ToString());
            }
            dtoSheet[lstTo.Count] = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(lstTo.Count + 1);
            XuatExcelTongHopDangNgan_DongA(dtTongDangNgan_ExceptDongA, dtTongDangNgan_DongA, dtoSheet[lstTo.Count], "Đông Á", dateDen.Value.Month.ToString() + "/" + dateDen.Value.Year.ToString());
        }

        private void XuatExcelTongHopDangNgan(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName, string Ky)
        {
            oSheet.Name = SheetName;

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "C1");
            head.MergeCells = true;
            head.Value2 = "PHIẾU BÁO CÁO SỐ LIỆU UNC ĐĂNG NGÂN THÁNG \r\n " + Ky + " - TỔ " + SheetName;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.RowHeight = 50;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Ngày";
            cl1.ColumnWidth = 30;
            cl1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Tổng HĐ";
            cl2.ColumnWidth = 30;
            cl2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Tổng Cộng";
            cl3.ColumnWidth = 30;
            cl3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 3];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = dr["Ngay"].ToString();
                arr[i, 1] = dr["TongHD"].ToString();
                arr[i, 2] = dr["TongCong"].ToString();
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 3;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            oSheet.get_Range(c2a, c3a).Font.Bold = true;
            oSheet.get_Range(c2a, c3a).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2a, c3a).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            oSheet.get_Range(c2b, c3b).Font.Bold = true;
            oSheet.get_Range(c2b, c3b).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2b, c3b).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            oSheet.get_Range(c2c, c3c).Font.Bold = true;
            oSheet.get_Range(c2c, c3c).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2c, c3c).NumberFormat = "#,##0";

            //Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
            //Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
            //Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
            //oSheet.get_Range(c2d, c3d).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
            //Microsoft.Office.Interop.Excel.Range c2e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
            //Microsoft.Office.Interop.Excel.Range c3e = oSheet.get_Range(c1e, c2e);
            //oSheet.get_Range(c2e, c3e).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Microsoft.Office.Interop.Excel.Range c1f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 6];
            //Microsoft.Office.Interop.Excel.Range c2f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 6];
            //Microsoft.Office.Interop.Excel.Range c3f = oSheet.get_Range(c1f, c2f);
            //oSheet.get_Range(c2f, c3f).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }

        private void XuatExcelTongHopDangNgan_DongA(DataTable[] dtDangNgan, DataTable[] dtDongA, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName, string Ky)
        {
            oSheet.Name = SheetName;

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "M1");
            head.MergeCells = true;
            head.Value2 = "PHIẾU BÁO CÁO SỐ LIỆU UNC ĐĂNG NGÂN THÁNG \r\n " + Ky;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.RowHeight = 50;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl = oSheet.get_Range("A3", "A3");
            cl.Value2 = "Ngày";
            cl.ColumnWidth = 10;
            cl.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("C3", "D3");
            cl1.MergeCells = true;
            cl1.Value2 = "TB1";
            cl1.ColumnWidth = 25;
            cl1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl1a = oSheet.get_Range("C4", "C4");
            cl1a.Value2 = "HĐ";
            cl1a.ColumnWidth = 10;
            cl1a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl1b = oSheet.get_Range("D4", "D4");
            cl1b.Value2 = "TC";
            cl1b.ColumnWidth = 15;
            cl1b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("E3", "F3");
            cl2.MergeCells = true;
            cl2.Value2 = "TB2";
            cl2.ColumnWidth = 25;
            cl2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl2a = oSheet.get_Range("E4", "E4");
            cl2a.Value2 = "HĐ";
            cl2a.ColumnWidth = 10;
            cl2a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl2b = oSheet.get_Range("F4", "F4");
            cl2b.Value2 = "TC";
            cl2b.ColumnWidth = 15;
            cl2b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("G3", "H3");
            cl3.MergeCells = true;
            cl3.Value2 = "TP1";
            cl3.ColumnWidth = 25;
            cl3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl3a = oSheet.get_Range("G4", "G4");
            cl3a.Value2 = "HĐ";
            cl3a.ColumnWidth = 10;
            cl3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl3b = oSheet.get_Range("H4", "H4");
            cl3b.Value2 = "TC";
            cl3b.ColumnWidth = 15;
            cl3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("I3", "J3");
            cl4.MergeCells = true;
            cl4.Value2 = "TP2";
            cl4.ColumnWidth = 25;
            cl4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl4a = oSheet.get_Range("I4", "I4");
            cl4a.Value2 = "HĐ";
            cl4a.ColumnWidth = 10;
            cl4a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl4b = oSheet.get_Range("J4", "J4");
            cl4b.Value2 = "TC";
            cl4b.ColumnWidth = 15;
            cl4b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("K3", "L3");
            cl5.MergeCells = true;
            cl5.Value2 = "TỔNG";
            cl5.ColumnWidth = 25;
            cl5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl5a = oSheet.get_Range("K4", "K4");
            cl5a.Value2 = "HĐ";
            cl5a.ColumnWidth = 10;
            cl5a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl5b = oSheet.get_Range("L4", "L4");
            cl5b.Value2 = "TC";
            cl5b.ColumnWidth = 15;
            cl5b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("M3", "N3");
            cl6.MergeCells = true;
            cl6.Value2 = "CÒN LẠI";
            cl6.ColumnWidth = 25;
            cl6.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl6a = oSheet.get_Range("M4", "M4");
            cl6a.Value2 = "HĐ";
            cl6a.ColumnWidth = 10;
            cl6a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl6b = oSheet.get_Range("N4", "N4");
            cl6b.Value2 = "TC";
            cl6b.ColumnWidth = 15;
            cl6b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dtDangNgan[0].Rows.Count * 3, 14];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            //TB1
            int j = 0;//biến kiểm soát nhảy hàng
            for (int i = 0; i < dtDangNgan[0].Rows.Count; i++)
            {
                DataRow dr = dtDangNgan[0].Rows[i];

                arr[i + j, 0] = dr["Ngay"].ToString();
                arr[i + j + 1, 1] = "Đông Á";

                if (dtDongA[0].Rows.Count > 0)
                {
                    DataRow[] drDongA = dtDongA[0].Select("Ngay like '" + dr["Ngay"].ToString() + "'");
                    if (drDongA.Count() > 0)
                    {
                        arr[i + j + 1, 2] = drDongA[0]["TongHD"].ToString();
                        arr[i + j + 1, 3] = drDongA[0]["TongCong"].ToString();

                        arr[i + j + 1, 10] = drDongA[0]["TongHD"].ToString();
                        arr[i + j + 1, 11] = drDongA[0]["TongCong"].ToString();
                    }
                }

                arr[i + j, 1] = "Tổ";
                arr[i + j, 2] = dr["TongHD"].ToString();
                arr[i + j, 3] = dr["TongCong"].ToString();

                arr[i + j, 10] = dr["TongHD"].ToString();
                arr[i + j, 11] = dr["TongCong"].ToString();

                j = j + 2;//nhảy hàng
            }

            //TB2
            j = 0;//biến kiểm soát nhảy hàng
            for (int i = 0; i < dtDangNgan[1].Rows.Count; i++)
            {
                DataRow dr = dtDangNgan[1].Rows[i];

                if (dtDongA[1].Rows.Count > 0)
                {
                    DataRow[] drDongA = dtDongA[1].Select("Ngay like '" + dr["Ngay"].ToString() + "'");
                    if (drDongA.Count() > 0)
                    {
                        arr[i + j + 1, 4] = drDongA[0]["TongHD"].ToString();
                        arr[i + j + 1, 5] = drDongA[0]["TongCong"].ToString();

                        if (arr[i + j + 1, 10] != null)
                            arr[i + j + 1, 10] = int.Parse(arr[i + j + 1, 10].ToString()) + int.Parse(drDongA[0]["TongHD"].ToString());
                        else
                            arr[i + j + 1, 10] = drDongA[0]["TongHD"].ToString();
                        if (arr[i + j + 1, 11] != null)
                            arr[i + j + 1, 11] = int.Parse(arr[i + j + 1, 11].ToString()) + int.Parse(drDongA[0]["TongCong"].ToString());
                        else
                            arr[i + j + 1, 11] = drDongA[0]["TongCong"].ToString();
                    }
                }

                arr[i + j, 4] = dr["TongHD"].ToString();
                arr[i + j, 5] = dr["TongCong"].ToString();

                arr[i + j, 10] = int.Parse(arr[i + j, 10].ToString()) + int.Parse(dr["TongHD"].ToString());
                arr[i + j, 11] = Int64.Parse(arr[i + j, 11].ToString()) + int.Parse(dr["TongCong"].ToString());

                j = j + 2;//nhảy hàng
            }

            //TP1
            j = 0;//biến kiểm soát nhảy hàng
            for (int i = 0; i < dtDangNgan[2].Rows.Count; i++)
            {
                DataRow dr = dtDangNgan[2].Rows[i];

                if (dtDongA[2].Rows.Count > 0)
                {
                    DataRow[] drDongA = dtDongA[2].Select("Ngay like '" + dr["Ngay"].ToString() + "'");
                    if (drDongA.Count() > 0)
                    {
                        arr[i + j + 1, 6] = drDongA[0]["TongHD"].ToString();
                        arr[i + j + 1, 7] = drDongA[0]["TongCong"].ToString();

                        if (arr[i + j + 1, 10] != null)
                            arr[i + j + 1, 10] = int.Parse(arr[i + j + 1, 10].ToString()) + int.Parse(drDongA[0]["TongHD"].ToString());
                        else
                            arr[i + j + 1, 10] = drDongA[0]["TongHD"].ToString();
                        if (arr[i + j + 1, 11] != null)
                            arr[i + j + 1, 11] = int.Parse(arr[i + j + 1, 11].ToString()) + int.Parse(drDongA[0]["TongCong"].ToString());
                        else
                            arr[i + j + 1, 11] = drDongA[0]["TongCong"].ToString();
                    }
                }

                arr[i + j, 6] = dr["TongHD"].ToString();
                arr[i + j, 7] = dr["TongCong"].ToString();

                arr[i + j, 10] = int.Parse(arr[i + j, 10].ToString()) + int.Parse(dr["TongHD"].ToString());
                arr[i + j, 11] = Int64.Parse(arr[i + j, 11].ToString()) + int.Parse(dr["TongCong"].ToString());

                j = j + 2;//nhảy hàng
            }

            //TP2
            j = 0;//biến kiểm soát nhảy hàng
            for (int i = 0; i < dtDangNgan[3].Rows.Count; i++)
            {
                DataRow dr = dtDangNgan[3].Rows[i];

                if (dtDongA[3].Rows.Count > 0)
                {
                    DataRow[] drDongA = dtDongA[3].Select("Ngay like '" + dr["Ngay"].ToString() + "'");
                    if (drDongA.Count() > 0)
                    {
                        arr[i + j + 1, 8] = drDongA[0]["TongHD"].ToString();
                        arr[i + j + 1, 9] = drDongA[0]["TongCong"].ToString();

                        if (arr[i + j + 1, 10] != null)
                            arr[i + j + 1, 10] = int.Parse(arr[i + j + 1, 10].ToString()) + int.Parse(drDongA[0]["TongHD"].ToString());
                        else
                            arr[i + j + 1, 10] = drDongA[0]["TongHD"].ToString();
                        if (arr[i + j + 1, 11] != null)
                            arr[i + j + 1, 11] = int.Parse(arr[i + j + 1, 11].ToString()) + int.Parse(drDongA[0]["TongCong"].ToString());
                        else
                            arr[i + j + 1, 11] = drDongA[0]["TongCong"].ToString();
                    }
                }

                arr[i + j, 8] = dr["TongHD"].ToString();
                arr[i + j, 9] = dr["TongCong"].ToString();

                arr[i + j, 10] = int.Parse(arr[i + j, 10].ToString()) + int.Parse(dr["TongHD"].ToString());
                arr[i + j, 11] = Int64.Parse(arr[i + j, 11].ToString()) + int.Parse(dr["TongCong"].ToString());

                j = j + 2;//nhảy hàng
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 5;
            int columnStart = 1;

            int rowEnd = rowStart + dtDangNgan[0].Rows.Count * 3 - 1;
            int columnEnd = 14;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            oSheet.get_Range(c2a, c3a).Font.Bold = true;
            oSheet.get_Range(c2a, c3a).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2a, c3a).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            oSheet.get_Range(c2b, c3b).Font.Bold = true;
            oSheet.get_Range(c2b, c3b).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2b, c3b).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            oSheet.get_Range(c2c, c3c).Font.Bold = true;
            oSheet.get_Range(c2c, c3c).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2c, c3c).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
            Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
            Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
            oSheet.get_Range(c2d, c3d).Font.Bold = true;
            oSheet.get_Range(c2d, c3d).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2d, c3d).NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
            Microsoft.Office.Interop.Excel.Range c2e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
            Microsoft.Office.Interop.Excel.Range c3e = oSheet.get_Range(c1e, c2e);
            oSheet.get_Range(c2e, c3e).Font.Bold = true;
            oSheet.get_Range(c2e, c3e).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2e, c3e).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 6];
            Microsoft.Office.Interop.Excel.Range c2f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 6];
            Microsoft.Office.Interop.Excel.Range c3f = oSheet.get_Range(c1f, c2f);
            oSheet.get_Range(c2f, c3f).Font.Bold = true;
            oSheet.get_Range(c2f, c3f).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2f, c3f).NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range c1g = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 7];
            Microsoft.Office.Interop.Excel.Range c2g = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 7];
            Microsoft.Office.Interop.Excel.Range c3g = oSheet.get_Range(c1g, c2g);
            oSheet.get_Range(c2g, c3g).Font.Bold = true;
            oSheet.get_Range(c2g, c3g).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2g, c3g).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1h = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 8];
            Microsoft.Office.Interop.Excel.Range c2h = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 8];
            Microsoft.Office.Interop.Excel.Range c3h = oSheet.get_Range(c1h, c2h);
            oSheet.get_Range(c2h, c3h).Font.Bold = true;
            oSheet.get_Range(c2h, c3h).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2h, c3h).NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range c1i = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 9];
            Microsoft.Office.Interop.Excel.Range c2i = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 9];
            Microsoft.Office.Interop.Excel.Range c3i = oSheet.get_Range(c1i, c2i);
            oSheet.get_Range(c2i, c3i).Font.Bold = true;
            oSheet.get_Range(c2i, c3i).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2i, c3i).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1j = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 10];
            Microsoft.Office.Interop.Excel.Range c2j = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 10];
            Microsoft.Office.Interop.Excel.Range c3j = oSheet.get_Range(c1j, c2j);
            oSheet.get_Range(c2j, c3j).Font.Bold = true;
            oSheet.get_Range(c2j, c3j).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2j, c3j).NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range c1k = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 11];
            Microsoft.Office.Interop.Excel.Range c2k = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 11];
            Microsoft.Office.Interop.Excel.Range c3k = oSheet.get_Range(c1k, c2k);
            oSheet.get_Range(c2k, c3k).Font.Bold = true;
            oSheet.get_Range(c2k, c3k).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2k, c3k).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1l = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 12];
            Microsoft.Office.Interop.Excel.Range c2l = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 12];
            Microsoft.Office.Interop.Excel.Range c3l = oSheet.get_Range(c1l, c2l);
            oSheet.get_Range(c2l, c3l).Font.Bold = true;
            oSheet.get_Range(c2l, c3l).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2l, c3l).NumberFormat = "#,##0";

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }

        private void btnXuatExcelBangKe_Click(object sender, EventArgs e)
        {
            if (backgroundWorker_BangKe.IsBusy)
                backgroundWorker_BangKe.CancelAsync();
            else
            {
                backgroundWorker_BangKe.RunWorkerAsync();
                frm = new frmLoading();
                frm.ShowDialog();
            }

        }

        //private void XuatExcelBangKe(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName, string NgayGiaiTrach, long TonDau)
        //{
        //    oSheet.Name = SheetName;

        //    // Tạo phần đầu nếu muốn
        //    Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "M1");
        //    head.MergeCells = true;
        //    head.Value2 = "BẢNG KÊ KHÁCH HÀNG CHUYỂN KHOẢN - GIẢI TRÁCH TIỀN NƯỚC \r\n NGÀY " + NgayGiaiTrach;
        //    head.Font.Bold = true;
        //    head.Font.Name = "Times New Roman";
        //    head.Font.Size = "20";
        //    head.RowHeight = 50;
        //    head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

        //    Microsoft.Office.Interop.Excel.Range head2 = oSheet.get_Range("A2", "M2");
        //    head2.MergeCells = true;
        //    head2.Value2 = "Tồn đầu ngày: " + TonDau;
        //    head2.Font.Bold = true;
        //    head2.Font.Name = "Times New Roman";

        //    // Tạo tiêu đề cột 
        //    Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
        //    cl1.Value2 = "STT";
        //    cl1.ColumnWidth = 5;
        //    cl1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    cl1.Font.Name = "Times New Roman";

        //    Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
        //    cl2.Value2 = "TÊN KHÁCH HÀNG";
        //    cl2.ColumnWidth = 20;
        //    cl2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    cl2.Font.Name = "Times New Roman";

        //    Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
        //    cl3.Value2 = "DANH BỘ";
        //    cl3.ColumnWidth = 15;
        //    cl3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    cl3.Font.Name = "Times New Roman";

        //    Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "E3");
        //    cl4.MergeCells = true;
        //    cl4.Value2 = "KHÁCH HÀNG CK";
        //    cl4.ColumnWidth = 20;
        //    cl4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    cl4.Font.Name = "Times New Roman";

        //    Microsoft.Office.Interop.Excel.Range cl4a = oSheet.get_Range("D4", "D4");
        //    cl4a.Value2 = "PT";
        //    cl4a.ColumnWidth = 10;
        //    cl4a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    cl4a.Font.Name = "Times New Roman";

        //    Microsoft.Office.Interop.Excel.Range cl4b = oSheet.get_Range("E4", "E4");
        //    cl4b.Value2 = "SỐ TIỀN";
        //    cl4b.ColumnWidth = 10;
        //    cl4b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    cl4b.Font.Name = "Times New Roman";

        //    Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("F3", "M3");
        //    cl5.MergeCells = true;
        //    cl5.Value2 = "GIẢI TRÁCH";
        //    cl5.ColumnWidth = 70;
        //    cl5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    cl5.Font.Name = "Times New Roman";

        //    Microsoft.Office.Interop.Excel.Range cl5a = oSheet.get_Range("F4", "F4");
        //    cl5a.Value2 = "KỲ";
        //    cl5a.ColumnWidth = 5;
        //    cl5a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    cl5a.Font.Name = "Times New Roman";

        //    Microsoft.Office.Interop.Excel.Range cl5b = oSheet.get_Range("G4", "G4");
        //    cl5b.Value2 = "NGÀY BK";
        //    cl5b.ColumnWidth = 10;
        //    cl5b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    cl5b.Font.Name = "Times New Roman";

        //    Microsoft.Office.Interop.Excel.Range cl5c = oSheet.get_Range("H4", "H4");
        //    cl5c.Value2 = "PT";
        //    cl5c.ColumnWidth = 10;
        //    cl5c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    cl5c.Font.Name = "Times New Roman";

        //    Microsoft.Office.Interop.Excel.Range cl5d = oSheet.get_Range("I4", "I4");
        //    cl5d.Value2 = "TN";
        //    cl5d.ColumnWidth = 10;
        //    cl5d.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    cl5d.Font.Name = "Times New Roman";

        //    Microsoft.Office.Interop.Excel.Range cl5e = oSheet.get_Range("J4", "J4");
        //    cl5e.Value2 = "THUẾ";
        //    cl5e.ColumnWidth = 10;
        //    cl5e.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    cl5e.Font.Name = "Times New Roman";

        //    Microsoft.Office.Interop.Excel.Range cl5f = oSheet.get_Range("K4", "K4");
        //    cl5f.Value2 = "PHÍ BVMT";
        //    cl5f.ColumnWidth = 10;
        //    cl5f.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    cl5f.Font.Name = "Times New Roman";

        //    Microsoft.Office.Interop.Excel.Range cl5g = oSheet.get_Range("L4", "L4");
        //    cl5g.Value2 = "CỘNG GT";
        //    cl5g.ColumnWidth = 10;
        //    cl5g.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    cl5g.Font.Name = "Times New Roman";

        //    Microsoft.Office.Interop.Excel.Range cl5h = oSheet.get_Range("M4", "M4");
        //    cl5h.Value2 = "LỆCH";
        //    cl5h.ColumnWidth = 10;
        //    cl5h.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    cl5h.Font.Name = "Times New Roman";

        //    Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("N3", "N3");
        //    cl6.MergeCells = true;
        //    cl6.Value2 = "LOẠI";
        //    cl6.ColumnWidth = 5;
        //    cl6.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    cl6.Font.Name = "Times New Roman";

        //    // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
        //    // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
        //    object[,] arr = new object[dt.Rows.Count, 14];

        //    //Chuyển dữ liệu từ DataTable vào mảng đối tượng
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        DataRow dr = dt.Rows[i];

        //        arr[i, 0] = i + 1;
        //        arr[i, 1] = dr["HoTen"].ToString();
        //        arr[i, 2] = dr["DanhBo"].ToString();
        //        arr[i, 4] = dr["SoTien"].ToString();
        //        arr[i, 5] = dr["Ky"].ToString();
        //        if (!string.IsNullOrEmpty(dr["CreateDate"].ToString()))
        //            arr[i, 6] = DateTime.Parse(dr["CreateDate"].ToString()).ToString("dd/MM/yyyy");
        //        arr[i, 8] = dr["GiaBan"].ToString();
        //        arr[i, 9] = dr["ThueGTGT"].ToString();
        //        arr[i, 10] = dr["PhiBVMT"].ToString();
        //        arr[i, 11] = dr["TongCong"].ToString();
        //        if (!string.IsNullOrEmpty(dr["SoTien"].ToString()))
        //            arr[i, 12] = int.Parse(dr["SoTien"].ToString()) - int.Parse(dr["TongCong"].ToString());
        //        arr[i, 13] = dr["Loai"];
        //    }

        //    //Thiết lập vùng điền dữ liệu
        //    int rowStart = 5;
        //    int columnStart = 1;

        //    int rowEnd = rowStart + dt.Rows.Count - 1;
        //    int columnEnd = 14;

        //    // Ô bắt đầu điền dữ liệu
        //    Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
        //    // Ô kết thúc điền dữ liệu
        //    Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
        //    // Lấy về vùng điền dữ liệu
        //    Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

        //    //Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
        //    //Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
        //    //Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
        //    //oSheet.get_Range(c2a, c3a).Font.Bold = true;
        //    //oSheet.get_Range(c2a, c3a).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    //oSheet.get_Range(c2a, c3a).NumberFormat = "@";

        //    //Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 6];
        //    //Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 6];
        //    //Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
        //    //oSheet.get_Range(c2b, c3b).Font.Bold = true;
        //    //oSheet.get_Range(c2b, c3b).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    //oSheet.get_Range(c2b, c3b).NumberFormat = "@";

        //    //Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
        //    //Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
        //    //Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
        //    //oSheet.get_Range(c2c, c3c).Font.Bold = true;
        //    //oSheet.get_Range(c2c, c3c).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    //oSheet.get_Range(c2c, c3c).NumberFormat = "#,##0";

        //    ////Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
        //    ////Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
        //    ////Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
        //    ////oSheet.get_Range(c2d, c3d).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

        //    ////Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
        //    ////Microsoft.Office.Interop.Excel.Range c2e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
        //    ////Microsoft.Office.Interop.Excel.Range c3e = oSheet.get_Range(c1e, c2e);
        //    ////oSheet.get_Range(c2e, c3e).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

        //    ////Microsoft.Office.Interop.Excel.Range c1f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 6];
        //    ////Microsoft.Office.Interop.Excel.Range c2f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 6];
        //    ////Microsoft.Office.Interop.Excel.Range c3f = oSheet.get_Range(c1f, c2f);
        //    ////oSheet.get_Range(c2f, c3f).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

        //    //Điền dữ liệu vào vùng đã thiết lập
        //    range.Value2 = arr;

        //    oSheet.Cells[rowEnd + 2, 2] = "AGR";
        //    oSheet.Cells[rowEnd + 3, 2] = "MB";
        //    oSheet.Cells[rowEnd + 4, 2] = "KHO BẠC";
        //}

        private void btnXuatExcelDSChuyenKhoan_Click(object sender, EventArgs e)
        {
            DataTable dt = _cHoaDon.GetDSChuyenKhoan(int.Parse(cmbNam.SelectedValue.ToString()));
            if (dt == null)
            {
                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            oSheet.Name = "Danh Sách Chuyển Khoản " + cmbNam.SelectedValue.ToString();

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
            cl1.Value2 = "Danh Bộ";
            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
            cl2.Value2 = "Kỳ 1";
            cl2.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
            cl3.Value2 = "Kỳ 2";
            cl3.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
            cl4.Value2 = "Kỳ 3";
            cl4.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E1", "E1");
            cl5.Value2 = "Kỳ 4";
            cl5.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F1", "F1");
            cl6.Value2 = "Kỳ 5";
            cl6.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G1", "G1");
            cl7.Value2 = "Kỳ 6";
            cl7.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H1", "H1");
            cl8.Value2 = "Kỳ 7";
            cl8.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I1", "I1");
            cl9.Value2 = "Kỳ 8";
            cl9.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J1", "J1");
            cl10.Value2 = "Kỳ 9";
            cl10.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K1", "K1");
            cl11.Value2 = "Kỳ 10";
            cl11.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L1", "L1");
            cl12.Value2 = "Kỳ 11";
            cl12.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M1", "M1");
            cl13.Value2 = "Kỳ 12";
            cl13.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("N1", "N1");
            cl14.Value2 = "Phường ";
            cl14.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("O1", "O1");
            cl15.Value2 = "Quận";
            cl15.ColumnWidth = 10;

            //Microsoft.Office.Interop.Excel.Range cl16 = oSheet.get_Range("P1", "P1");
            //cl16.Value2 = "Bank";
            //cl16.ColumnWidth = 10;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 15];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = dr["DanhBo"].ToString();
                if (!string.IsNullOrEmpty(dr["Ky1"].ToString()) && bool.Parse(dr["Ky1"].ToString()))
                    arr[i, 1] = "X";
                if (!string.IsNullOrEmpty(dr["Ky2"].ToString()) && bool.Parse(dr["Ky2"].ToString()))
                    arr[i, 2] = "X";
                if (!string.IsNullOrEmpty(dr["Ky3"].ToString()) && bool.Parse(dr["Ky3"].ToString()))
                    arr[i, 3] = "X";
                if (!string.IsNullOrEmpty(dr["Ky4"].ToString()) && bool.Parse(dr["Ky4"].ToString()))
                    arr[i, 4] = "X";
                if (!string.IsNullOrEmpty(dr["Ky5"].ToString()) && bool.Parse(dr["Ky5"].ToString()))
                    arr[i, 5] = "X";
                if (!string.IsNullOrEmpty(dr["Ky6"].ToString()) && bool.Parse(dr["Ky6"].ToString()))
                    arr[i, 6] = "X";
                if (!string.IsNullOrEmpty(dr["Ky7"].ToString()) && bool.Parse(dr["Ky7"].ToString()))
                    arr[i, 7] = "X";
                if (!string.IsNullOrEmpty(dr["Ky8"].ToString()) && bool.Parse(dr["Ky8"].ToString()))
                    arr[i, 8] = "X";
                if (!string.IsNullOrEmpty(dr["Ky9"].ToString()) && bool.Parse(dr["Ky9"].ToString()))
                    arr[i, 9] = "X";
                if (!string.IsNullOrEmpty(dr["Ky10"].ToString()) && bool.Parse(dr["Ky10"].ToString()))
                    arr[i, 10] = "X";
                if (!string.IsNullOrEmpty(dr["Ky11"].ToString()) && bool.Parse(dr["Ky11"].ToString()))
                    arr[i, 11] = "X";
                if (!string.IsNullOrEmpty(dr["Ky12"].ToString()) && bool.Parse(dr["Ky12"].ToString()))
                    arr[i, 12] = "X";
                arr[i, 13] = dr["TenPhuong"].ToString();
                arr[i, 14] = dr["TenQuan"].ToString();
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 15;

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

        private void backgroundWorker_BangKe_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dtBK = _cBangKe.GetDS_BangKe(dateGiaiTrach.Value);
            DataTable dtDN = _cHoaDon.GetDSDangNganChuyenKhoan(dateGiaiTrach.Value);
            //DataTable dtBKLui5 = _cBangKe.GetDS_BangKeLui5(dateGiaiTrach.Value);
            if (dtBK == null || dtBK.Rows.Count == 0 || dtDN == null || dtDN.Rows.Count == 0)
            {
                MessageBox.Show("Lỗi, Dữ liệu Đăng Ngân không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("MaBK", typeof(int));
            dt.Columns.Add("DanhBo", typeof(string));
            dt.Columns.Add("SoTien", typeof(int));
            dt.Columns.Add("SoPhieuThu", typeof(string));
            dt.Columns.Add("NgayPhieuThu", typeof(DateTime));
            dt.Columns.Add("CreateDate", typeof(DateTime));
            dt.Columns.Add("MaNH", typeof(int));
            dt.Columns.Add("NganHang", typeof(string));
            dt.Columns.Add("Ky", typeof(string));
            dt.Columns.Add("HoTen", typeof(string));
            dt.Columns.Add("GiaBan", typeof(int));
            dt.Columns.Add("ThueGTGT", typeof(int));
            dt.Columns.Add("PhiBVMT", typeof(int));
            dt.Columns.Add("TongCong", typeof(int));
            dt.Columns.Add("Lech", typeof(int));
            dt.Columns.Add("TienMat", typeof(int));
            //dt.Columns.Add("Loai", typeof(string));
            dt.Columns.Add("BangKeCu", typeof(string));

            string SoPhieuThu = "";
            int count = 1, countSum = 1, SumSoTien = 0, SumGiaBan = 0, SumThueGTGT = 0, SumPhiBVMT = 0, SumTongCong = 0;
            foreach (DataRow item in dtBK.Rows)
            {
                if (SoPhieuThu == "")
                {
                    SoPhieuThu = item["SoPhieuThu"].ToString();
                    SumSoTien = int.Parse(item["SoTien"].ToString());
                }
                else
                    if (SoPhieuThu == item["SoPhieuThu"].ToString())
                    {
                        countSum++;
                        SumSoTien += int.Parse(item["SoTien"].ToString());
                    }
                    else
                    {
                        if (countSum > 1)
                        {
                            //thêm dòng sum
                            DataRow dr = dt.NewRow();
                            dr["MaBK"] = dtBK.Rows[count - 2]["MaBK"];
                            dr["SoPhieuThu"] = dtBK.Rows[count - 2]["SoPhieuThu"];
                            dr["NgayPhieuThu"] = dtBK.Rows[count - 2]["NgayPhieuThu"];
                            dr["SoTien"] = SumSoTien;
                            dr["GiaBan"] = SumGiaBan;
                            dr["ThueGTGT"] = SumThueGTGT;
                            dr["PhiBVMT"] = SumPhiBVMT;
                            dr["TongCong"] = SumTongCong;
                            dr["Lech"] = SumSoTien - SumTongCong;
                            dt.Rows.Add(dr);
                        }
                        countSum = 1;
                        SumGiaBan = 0;
                        SumThueGTGT = 0;
                        SumPhiBVMT = 0;
                        SumTongCong = 0;
                        SoPhieuThu = item["SoPhieuThu"].ToString();
                        SumSoTien = int.Parse(item["SoTien"].ToString());
                    }
                count++;

                DataRow[] drDN = dtDN.Select("DanhBo like '" + item["DanhBo"].ToString() + "'");

                //bảng kê có đăng ngân
                if (drDN.Count() > 0)
                {
                    int i = 0;
                    int GiaBan = int.Parse(dtDN.Compute("sum(GiaBan)", "DanhBo like '" + item["DanhBo"].ToString() + "'").ToString());
                    int ThueGTGT = int.Parse(dtDN.Compute("sum(ThueGTGT)", "DanhBo like '" + item["DanhBo"].ToString() + "'").ToString());
                    int PhiBVMT = int.Parse(dtDN.Compute("sum(PhiBVMT)", "DanhBo like '" + item["DanhBo"].ToString() + "'").ToString());
                    int TongCong = int.Parse(dtDN.Compute("sum(TongCong)", "DanhBo like '" + item["DanhBo"].ToString() + "'").ToString());

                    //cập nhật sum
                    if (SoPhieuThu == item["SoPhieuThu"].ToString())
                    {
                        SumGiaBan += GiaBan;
                        SumThueGTGT += ThueGTGT;
                        SumPhiBVMT += PhiBVMT;
                        SumTongCong += TongCong;
                    }
                    //else
                    //{
                    //    SoPhieuThu = item["SoPhieuThu"].ToString();
                    //    SumGiaBan = GiaBan;
                    //    SumThueGTGT = ThueGTGT;
                    //    SumPhiBVMT = PhiBVMT;
                    //    SumTongCong = TongCong;
                    //}

                    foreach (DataRow itemdrDN in drDN)
                    {
                        //thêm dòng
                        DataRow dr = dt.NewRow();
                        //if (drDN.Count() == 1)
                        if (i == 0)
                        {
                            dr["MaBK"] = item["MaBK"];
                            dr["SoTien"] = item["SoTien"];
                            dr["SoPhieuThu"] = item["SoPhieuThu"];
                            dr["NgayPhieuThu"] = item["NgayPhieuThu"];
                            dr["CreateDate"] = item["CreateDate"];
                            dr["MaNH"] = item["MaNH"];
                            dr["NganHang"] = item["TenNH"];
                            dr["Lech"] = int.Parse(item["SoTien"].ToString()) - TongCong;
                        }
                        else
                        {
                            dr["MaBK"] = item["MaBK"];
                            dr["SoPhieuThu"] = item["SoPhieuThu"];
                            dr["NgayPhieuThu"] = item["NgayPhieuThu"];
                            dr["CreateDate"] = item["CreateDate"];
                        }

                        dr["DanhBo"] = item["DanhBo"];
                        dr["HoTen"] = itemdrDN["HoTen"];
                        dr["Ky"] = itemdrDN["Ky"];
                        if (string.IsNullOrEmpty(itemdrDN["TienMat"].ToString()))
                        {
                            dr["GiaBan"] = itemdrDN["GiaBan"];
                            dr["ThueGTGT"] = itemdrDN["ThueGTGT"];
                            dr["PhiBVMT"] = itemdrDN["PhiBVMT"];
                            dr["TongCong"] = itemdrDN["TongCong"];
                        }
                        else
                        {
                            dr["GiaBan"] = int.Parse(itemdrDN["GiaBan"].ToString()) - int.Parse(itemdrDN["TienMat"].ToString());
                            dr["ThueGTGT"] = itemdrDN["ThueGTGT"];
                            dr["PhiBVMT"] = itemdrDN["PhiBVMT"];
                            dr["TongCong"] = int.Parse(itemdrDN["TongCong"].ToString()) - int.Parse(itemdrDN["TienMat"].ToString());
                        }
                        dr["TienMat"] = itemdrDN["TienMat"];
                        //if (int.Parse(itemdrDN["GiaBieu"].ToString()) > 20)
                        //    dr["Loai"] = "CQ";
                        //else
                        //    dr["Loai"] = "TG";

                        dt.Rows.Add(dr);
                        i++;
                        //trừ bớt trong danh sách đăng ngân
                        dtDN.Rows.Remove(itemdrDN);
                    }
                    //if (i > 1)
                    //{
                    //    DataRow dr = dt.NewRow();
                    //    dr["MaBK"] = item["MaBK"];
                    //    dr["SoTien"] = item["SoTien"];
                    //    dr["SoPhieuThu"] = item["SoPhieuThu"];
                    //    dr["NgayPhieuThu"] = item["NgayPhieuThu"];
                    //    dr["CreateDate"] = item["CreateDate"];
                    //    dr["MaNH"] = item["MaNH"];
                    //    dr["NganHang"] = item["TenNH"];
                    //    dr["GiaBan"] = GiaBan;
                    //    dr["ThueGTGT"] = ThueGTGT;
                    //    dr["PhiBVMT"] = PhiBVMT;
                    //    dr["TongCong"] = TongCong;
                    //    dr["Lech"] = int.Parse(item["SoTien"].ToString()) - TongCong;
                    //    dt.Rows.Add(dr);
                    //}

                }
                //bảng kê không có đăng ngân
                else
                {
                    //thêm dòng
                    DataRow dr = dt.NewRow();
                    dr["MaBK"] = item["MaBK"];
                    dr["DanhBo"] = item["DanhBo"];
                    dr["SoTien"] = item["SoTien"];
                    dr["SoPhieuThu"] = item["SoPhieuThu"];
                    dr["NgayPhieuThu"] = item["NgayPhieuThu"];
                    dr["CreateDate"] = item["CreateDate"];
                    dr["MaNH"] = item["MaNH"];
                    dr["NganHang"] = item["TenNH"];
                    dr["Lech"] = item["SoTien"];
                    //if (item["DanhBo"].ToString().Length == 11)
                    //{
                    //    HOADON hoadon = _cHoaDon.GetMoiNhat(item["DanhBo"].ToString());
                    //    if (hoadon != null)
                    //        if (hoadon.GB > 20)
                    //            dr["Loai"] = "CQ";
                    //        else
                    //            dr["Loai"] = "TG";
                    //}

                    dt.Rows.Add(dr);
                }

            }

            //dt.DefaultView.Sort = "Loai DESC,MaBK ASC";
            dt.DefaultView.Sort = "MaBK ASC";
            dt = dt.DefaultView.ToTable();

            //danh sách đăng ngân còn lại
            //if (dtDN.Rows.Count > 0)
            //{
            //    dtDN.DefaultView.Sort = "GiaBieu ASC";
            //    dtDN = dtDN.DefaultView.ToTable();
            //}
            foreach (DataRow item in dtDN.Rows)
            {
                TT_BangKe bk = _cBangKe.getLast(item["DanhBo"].ToString(), dateGiaiTrach.Value);

                ///có bảng kê
                if (bk != null)
                {
                    DataRow dr = dt.NewRow();

                    dr["MaBK"] = bk.MaBK;
                    dr["DanhBo"] = bk.DanhBo;
                    //dr["SoTien"] = bk.SoTien;
                    //dr["BangKeCu"] = "X";
                    if (bk.SoPhieuThu != null)
                        dr["SoPhieuThu"] = bk.SoPhieuThu;
                    if (bk.NgayPhieuThu != null)
                        dr["NgayPhieuThu"] = bk.NgayPhieuThu;
                    dr["CreateDate"] = bk.CreateDate;
                    if (bk.MaNH != null)
                    {
                        dr["MaNH"] = bk.MaNH;
                        dr["NganHang"] = _cNganHang.GetByMaNH(bk.MaNH.Value).NGANHANG1;
                    }
                    dr["DanhBo"] = item["DanhBo"];
                    dr["HoTen"] = item["HoTen"];
                    dr["Ky"] = item["Ky"];
                    if (string.IsNullOrEmpty(item["TienMat"].ToString()))
                    {
                        dr["GiaBan"] = item["GiaBan"];
                        dr["ThueGTGT"] = item["ThueGTGT"];
                        dr["PhiBVMT"] = item["PhiBVMT"];
                        dr["TongCong"] = item["TongCong"];
                    }
                    else
                    {
                        dr["GiaBan"] = int.Parse(item["GiaBan"].ToString()) - int.Parse(item["TienMat"].ToString());
                        dr["ThueGTGT"] = item["ThueGTGT"];
                        dr["PhiBVMT"] = item["PhiBVMT"];
                        dr["TongCong"] = int.Parse(item["TongCong"].ToString()) - int.Parse(item["TienMat"].ToString());
                    }
                    dr["Lech"] = int.Parse(item["TongCong"].ToString()) * -1;
                    dr["TienMat"] = item["TienMat"];
                    //if (int.Parse(item["GiaBieu"].ToString()) > 20)
                    //    dr["Loai"] = "CQ";
                    //else
                    //    dr["Loai"] = "TG";

                    dt.Rows.Add(dr);
                }
                //không có bảng kê
                else
                {
                    DataRow dr = dt.NewRow();

                    dr["DanhBo"] = item["DanhBo"];
                    dr["HoTen"] = item["HoTen"];
                    dr["Ky"] = item["Ky"];
                    if (string.IsNullOrEmpty(item["TienMat"].ToString()))
                    {
                        dr["GiaBan"] = item["GiaBan"];
                        dr["ThueGTGT"] = item["ThueGTGT"];
                        dr["PhiBVMT"] = item["PhiBVMT"];
                        dr["TongCong"] = item["TongCong"];
                    }
                    else
                    {
                        dr["GiaBan"] = int.Parse(item["GiaBan"].ToString()) - int.Parse(item["TienMat"].ToString());
                        dr["ThueGTGT"] = item["ThueGTGT"];
                        dr["PhiBVMT"] = item["PhiBVMT"];
                        dr["TongCong"] = int.Parse(item["TongCong"].ToString()) - int.Parse(item["TienMat"].ToString());
                    }
                    dr["Lech"] = int.Parse(item["TongCong"].ToString()) * -1;
                    dr["TienMat"] = item["TienMat"];
                    //if (int.Parse(item["GiaBieu"].ToString()) > 20)
                    //    dr["Loai"] = "CQ";
                    //else
                    //    dr["Loai"] = "TG";

                    dt.Rows.Add(dr);
                }
            }

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

            oSheet.Name = "BẢNG KÊ";

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "M1");
            head.MergeCells = true;
            head.Value2 = "BẢNG KÊ KHÁCH HÀNG CHUYỂN KHOẢN - GIẢI TRÁCH TIỀN NƯỚC \r\n NGÀY " + dateGiaiTrach.Value.ToString("dd/MM/yyyy");
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.RowHeight = 50;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            long TonDau = _cTienDu.GetTongTienTonDauNgay(dateGiaiTrach.Value) + _cPMN.getPhiMoNuoc_Chot(false);

            Microsoft.Office.Interop.Excel.Range head2a = oSheet.get_Range("A2", "B2");
            head2a.MergeCells = true;
            head2a.Value2 = "Tồn năm " + dateGiaiTrach.Value.ToString("yyyy") + ":";
            head2a.Font.Bold = true;
            head2a.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range head2b = oSheet.get_Range("C2", "C2");
            //head2b.MergeCells = true;
            head2b.Value2 = TonDau;
            head2b.Font.Bold = true;
            head2b.Font.Name = "Times New Roman";
            head2b.NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range head3a = oSheet.get_Range("A3", "B3");
            head3a.MergeCells = true;
            head3a.Value2 = "A. Tồn lũy kế đầu ngày:";
            head3a.Font.Bold = true;
            head3a.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range head3b = oSheet.get_Range("C3", "C3");
            //head3b.MergeCells = true;
            head3b.Value2 = TonDau;
            head3b.Font.Bold = true;
            head3b.Font.Name = "Times New Roman";
            head3b.NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range head4 = oSheet.get_Range("A4", "M4");
            head4.MergeCells = true;
            head4.Value2 = "B. Tình hình phát sinh, giải trách của chứng từ ngày " + dateGiaiTrach.Value.AddDays(-1).ToString("dd/MM/yyyy") + ":";
            //head4.Font.Bold = true;
            head4.Font.Name = "Times New Roman";

            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A5", "A5");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 5;
            cl1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl1.Font.Bold = true;
            cl1.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B5", "B5");
            cl2.Value2 = "TÊN KHÁCH HÀNG";
            cl2.ColumnWidth = 20;
            cl2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl2.Font.Bold = true;
            cl2.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C5", "C5");
            cl3.Value2 = "DANH BỘ";
            cl3.ColumnWidth = 15;
            cl3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl3.Font.Bold = true;
            cl3.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D5", "E5");
            cl4.MergeCells = true;
            cl4.Value2 = "KHÁCH HÀNG CK";
            cl4.ColumnWidth = 40;
            cl4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl4.Font.Bold = true;
            cl4.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl4a = oSheet.get_Range("D6", "D6");
            cl4a.Value2 = "PT";
            cl4a.ColumnWidth = 20;
            cl4a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl4a.Font.Bold = true;
            cl4a.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl4b = oSheet.get_Range("E6", "E6");
            cl4b.Value2 = "SỐ TIỀN";
            cl4b.ColumnWidth = 20;
            cl4b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl4b.Font.Bold = true;
            cl4b.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("F5", "M5");
            cl5.MergeCells = true;
            cl5.Value2 = "GIẢI TRÁCH";
            cl5.ColumnWidth = 70;
            cl5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5.Font.Bold = true;
            cl5.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5a = oSheet.get_Range("F6", "F6");
            cl5a.Value2 = "KỲ";
            cl5a.ColumnWidth = 5;
            cl5a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5a.Font.Bold = true;
            cl5a.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5b = oSheet.get_Range("G6", "G6");
            cl5b.Value2 = "NGÀY BK";
            cl5b.ColumnWidth = 11;
            cl5b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5b.Font.Bold = true;
            cl5b.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5c = oSheet.get_Range("H6", "H6");
            cl5c.Value2 = "PT";
            cl5c.ColumnWidth = 20;
            cl5c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5c.Font.Bold = true;
            cl5c.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5d = oSheet.get_Range("I6", "I6");
            cl5d.Value2 = "TN";
            cl5d.ColumnWidth = 12;
            cl5d.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5d.Font.Bold = true;
            cl5d.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5e = oSheet.get_Range("J6", "J6");
            cl5e.Value2 = "THUẾ";
            cl5e.ColumnWidth = 10;
            cl5e.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5e.Font.Bold = true;
            cl5e.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5f = oSheet.get_Range("K6", "K6");
            cl5f.Value2 = "PHÍ BVMT";
            cl5f.ColumnWidth = 10;
            cl5f.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5f.Font.Bold = true;
            cl5f.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5g = oSheet.get_Range("L6", "L6");
            cl5g.Value2 = "CỘNG GT";
            cl5g.ColumnWidth = 12;
            cl5g.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5g.Font.Bold = true;
            cl5g.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5h = oSheet.get_Range("M6", "M6");
            cl5h.Value2 = "LỆCH";
            cl5h.ColumnWidth = 10;
            cl5h.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5h.Font.Bold = true;
            cl5h.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("N5", "N5");
            cl6.Value2 = "LOẠI";
            cl6.ColumnWidth = 5;
            cl6.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl6.Font.Bold = true;
            cl6.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("O5", "O5");
            cl7.Value2 = "BANK";
            cl7.ColumnWidth = 10;
            cl7.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl7.Font.Bold = true;
            cl7.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("P5", "P5");
            cl8.Value2 = "TIỀN MẶT";
            cl8.ColumnWidth = 10;
            cl8.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl8.Font.Bold = true;
            cl8.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("Q5", "Q5");
            cl9.Value2 = "BẢNG KÊ CŨ";
            cl9.ColumnWidth = 10;
            cl9.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl9.Font.Bold = true;
            cl9.Font.Name = "Times New Roman";

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 17];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            //int STT = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                //if (!string.IsNullOrEmpty(dr["DanhBo"].ToString()))
                //    arr[i, 0] = STT++;
                arr[i, 0] = i + 1;
                arr[i, 1] = dr["HoTen"].ToString();
                arr[i, 2] = dr["DanhBo"].ToString();
                if (!string.IsNullOrEmpty(dr["SoPhieuThu"].ToString()))
                {
                    arr[i, 3] = dr["SoPhieuThu"].ToString();
                    arr[i, 7] = dr["SoPhieuThu"].ToString();
                }
                arr[i, 4] = dr["SoTien"].ToString();
                arr[i, 5] = dr["Ky"].ToString();
                if (!string.IsNullOrEmpty(dr["NgayPhieuThu"].ToString()))
                    arr[i, 6] = DateTime.Parse(dr["NgayPhieuThu"].ToString()).ToString("dd/MM/yyyy");
                //if (!string.IsNullOrEmpty(dr["SoPhieuThu"].ToString()))
                //    arr[i, 7] = dr["SoPhieuThu"].ToString();
                arr[i, 8] = dr["GiaBan"].ToString();
                arr[i, 9] = dr["ThueGTGT"].ToString();
                arr[i, 10] = dr["PhiBVMT"].ToString();
                arr[i, 11] = dr["TongCong"].ToString();
                //if (!string.IsNullOrEmpty(dr["SoTien"].ToString()) && !string.IsNullOrEmpty(dr["TongCong"].ToString()))
                //    arr[i, 12] = int.Parse(dr["SoTien"].ToString()) - int.Parse(dr["TongCong"].ToString());
                arr[i, 12] = dr["Lech"];
                //arr[i, 13] = dr["Loai"];

                arr[i, 14] = dr["NganHang"];
                arr[i, 15] = dr["TienMat"];
                arr[i, 16] = dr["BangKeCu"];
                //if (!string.IsNullOrEmpty(dr["TongBK"].ToString()))
                //    if (int.Parse(dr["TongBK"].ToString()) > 1)
                //        arr[i, 14] = "X";
                //if (!string.IsNullOrEmpty(dr["TongHD"].ToString()))
                //    if (int.Parse(dr["TongHD"].ToString()) > 1)
                //        arr[i, 14] = "X";
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 7;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 17;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            //oSheet.get_Range(c2a, c3a).Font.Bold = true;
            //oSheet.get_Range(c2a, c3a).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2a, c3a).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 7];
            Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 7];
            Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            //oSheet.get_Range(c2b, c3b).Font.Bold = true;
            //oSheet.get_Range(c2b, c3b).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2b, c3b).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 8];
            Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 8];
            Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            //oSheet.get_Range(c2c, c3c).Font.Bold = true;
            //oSheet.get_Range(c2c, c3c).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2c, c3c).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
            Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
            Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
            //oSheet.get_Range(c2d, c3d).Font.Bold = true;
            //oSheet.get_Range(c2d, c3d).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2d, c3d).NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 9];
            Microsoft.Office.Interop.Excel.Range c2e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 9];
            Microsoft.Office.Interop.Excel.Range c3e = oSheet.get_Range(c1e, c2e);
            //oSheet.get_Range(c2e, c3e).Font.Bold = true;
            //oSheet.get_Range(c2e, c3e).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2e, c3e).NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range c1f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 10];
            Microsoft.Office.Interop.Excel.Range c2f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 10];
            Microsoft.Office.Interop.Excel.Range c3f = oSheet.get_Range(c1f, c2f);
            //oSheet.get_Range(c2f, c3f).Font.Bold = true;
            //oSheet.get_Range(c2f, c3f).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2f, c3f).NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range c1g = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 11];
            Microsoft.Office.Interop.Excel.Range c2g = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 11];
            Microsoft.Office.Interop.Excel.Range c3g = oSheet.get_Range(c1g, c2g);
            //oSheet.get_Range(c2g, c3g).Font.Bold = true;
            //oSheet.get_Range(c2g, c3g).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2g, c3g).NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range c1h = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 12];
            Microsoft.Office.Interop.Excel.Range c2h = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 12];
            Microsoft.Office.Interop.Excel.Range c3h = oSheet.get_Range(c1h, c2h);
            //oSheet.get_Range(c2h, c3h).Font.Bold = true;
            //oSheet.get_Range(c2h, c3h).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2h, c3h).NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range c1i = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 13];
            Microsoft.Office.Interop.Excel.Range c2i = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 13];
            Microsoft.Office.Interop.Excel.Range c3i = oSheet.get_Range(c1i, c2i);
            //oSheet.get_Range(c2i, c3i).Font.Bold = true;
            //oSheet.get_Range(c2i, c3i).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2i, c3i).NumberFormat = "#,##0";

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;

            oSheet.Cells[rowEnd + 1, 5] = dtBK.Compute("sum(SoTien)", "CreateDate >='" + dateGiaiTrach.Value.ToString("yyyy/MM/dd") + "'");
            oSheet.Cells[rowEnd + 1, 9] = dt.Compute("sum(GiaBan)", "DanhBo <> ''");
            oSheet.Cells[rowEnd + 1, 10] = dt.Compute("sum(ThueGTGT)", "DanhBo <> ''");
            oSheet.Cells[rowEnd + 1, 11] = dt.Compute("sum(PhiBVMT)", "DanhBo <> ''");
            oSheet.Cells[rowEnd + 1, 12] = dt.Compute("sum(TongCong)", "DanhBo <> ''");
            //format number
            Microsoft.Office.Interop.Excel.Range c1sum1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, 5];
            Microsoft.Office.Interop.Excel.Range c2sum1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, 12];
            Microsoft.Office.Interop.Excel.Range c3sum1 = oSheet.get_Range(c1sum1, c2sum1);
            oSheet.get_Range(c2sum1, c3sum1).Font.Bold = true;
            //oSheet.get_Range(c2sum1, c3sum1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2sum1, c3sum1).NumberFormat = "#,##0";

            oSheet.Cells[rowEnd + 3, 2] = "AGR";
            oSheet.Cells[rowEnd + 4, 2] = "MB";
            oSheet.Cells[rowEnd + 5, 2] = "KHO BẠC";
            oSheet.Cells[rowEnd + 6, 2] = "VCB";

            oSheet.Cells[rowEnd + 3, 3] = dtBK.Compute("sum(SoTien)", "MaNH <> 3 and MaNH <> 4 and MaNH <> 10 and CreateDate >='" + dateGiaiTrach.Value.ToString("yyyy/MM/dd") + "'");
            oSheet.Cells[rowEnd + 4, 3] = dtBK.Compute("sum(SoTien)", "MaNH = 4 and CreateDate >='" + dateGiaiTrach.Value.ToString("yyyy/MM/dd") + "'");
            oSheet.Cells[rowEnd + 5, 3] = dtBK.Compute("sum(SoTien)", "MaNH = 3 and CreateDate >='" + dateGiaiTrach.Value.ToString("yyyy/MM/dd") + "'");
            oSheet.Cells[rowEnd + 6, 3] = dtBK.Compute("sum(SoTien)", "MaNH = 10 and CreateDate >='" + dateGiaiTrach.Value.ToString("yyyy/MM/dd") + "'");
            //format number
            Microsoft.Office.Interop.Excel.Range c1sum2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 3, 3];
            Microsoft.Office.Interop.Excel.Range c2sum2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 6, 3];
            Microsoft.Office.Interop.Excel.Range c3sum2 = oSheet.get_Range(c1sum2, c2sum2);
            oSheet.get_Range(c2sum2, c3sum2).Font.Bold = true;
            //oSheet.get_Range(c2sum2, c3sum2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2sum2, c3sum2).NumberFormat = "#,##0";

            oSheet.Cells[rowEnd + 8, 2] = "Tồn cuối ngày:";
            oSheet.Cells[rowEnd + 8, 3] = _cTienDu.GetTongTienTonDenNgay(dateGiaiTrach.Value) + _cPMN.getPhiMoNuoc_Chot(false);
            //format number
            Microsoft.Office.Interop.Excel.Range c1sum3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 8, 3];
            Microsoft.Office.Interop.Excel.Range c2sum3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 8, 3];
            Microsoft.Office.Interop.Excel.Range c3sum3 = oSheet.get_Range(c1sum3, c2sum3);
            oSheet.get_Range(c2sum3, c3sum3).Font.Bold = true;
            //oSheet.get_Range(c2sum3, c3sum3).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2sum3, c3sum3).NumberFormat = "#,##0";
        }

        private void backgroundWorker_BangKe_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (frm != null)
                frm.Close();
        }

        private void btnXuatExcelBangKeMoi_Click(object sender, EventArgs e)
        {
            if (backgroundWorker_BangKeMoi.IsBusy)
                backgroundWorker_BangKeMoi.CancelAsync();
            else
            {
                backgroundWorker_BangKeMoi.RunWorkerAsync();
                frm = new frmLoading();
                frm.ShowDialog();
            }

        }

        private void backgroundWorker_BangKeMoi_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dtBK = _cBangKe.GetDS_BangKe(dateGiaiTrach.Value);
            DataTable dtDN = _cHoaDon.GetDSDangNganChuyenKhoan(dateGiaiTrach.Value);
            //DataTable dtBKLui5 = _cBangKe.GetDS_BangKeLui5(dateGiaiTrach.Value);
            if (dtBK == null || dtBK.Rows.Count == 0 || dtDN == null || dtDN.Rows.Count == 0)
            {
                MessageBox.Show("Lỗi, Dữ liệu Đăng Ngân không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("MaBK", typeof(int));
            dt.Columns.Add("DanhBo", typeof(string));
            dt.Columns.Add("SoTien", typeof(int));
            dt.Columns.Add("SoPhieuThu", typeof(string));
            dt.Columns.Add("NgayPhieuThu", typeof(DateTime));
            dt.Columns.Add("CreateDate", typeof(DateTime));
            dt.Columns.Add("MaNH", typeof(int));
            dt.Columns.Add("NganHang", typeof(string));
            dt.Columns.Add("Ky", typeof(string));
            dt.Columns.Add("HoTen", typeof(string));
            dt.Columns.Add("GiaBan", typeof(int));
            dt.Columns.Add("ThueGTGT", typeof(int));
            dt.Columns.Add("PhiBVMT", typeof(int));
            dt.Columns.Add("TongCong", typeof(int));
            dt.Columns.Add("Lech", typeof(int));
            dt.Columns.Add("TienMat", typeof(int));
            //dt.Columns.Add("Loai", typeof(string));

            string SoPhieuThu = "";
            int count = 1, countSum = 1, SumSoTien = 0, SumGiaBan = 0, SumThueGTGT = 0, SumPhiBVMT = 0, SumTongCong = 0;
            foreach (DataRow item in dtBK.Rows)
            {
                if (SoPhieuThu == "")
                {
                    SoPhieuThu = item["SoPhieuThu"].ToString();
                    SumSoTien = int.Parse(item["SoTien"].ToString());
                }
                else
                    if (SoPhieuThu == item["SoPhieuThu"].ToString())
                    {
                        countSum++;
                        SumSoTien += int.Parse(item["SoTien"].ToString());
                    }
                    else
                    {
                        if (countSum > 1)
                        {
                            //thêm dòng sum
                            DataRow dr = dt.NewRow();
                            dr["MaBK"] = dtBK.Rows[count - 2]["MaBK"];
                            dr["SoPhieuThu"] = dtBK.Rows[count - 2]["SoPhieuThu"];
                            dr["NgayPhieuThu"] = dtBK.Rows[count - 2]["NgayPhieuThu"];
                            dr["SoTien"] = SumSoTien;
                            dr["GiaBan"] = SumGiaBan;
                            dr["ThueGTGT"] = SumThueGTGT;
                            dr["PhiBVMT"] = SumPhiBVMT;
                            dr["TongCong"] = SumTongCong;
                            dr["Lech"] = SumSoTien - SumTongCong;
                            dt.Rows.Add(dr);
                        }
                        countSum = 1;
                        SumGiaBan = 0;
                        SumThueGTGT = 0;
                        SumPhiBVMT = 0;
                        SumTongCong = 0;
                        SoPhieuThu = item["SoPhieuThu"].ToString();
                        SumSoTien = int.Parse(item["SoTien"].ToString());
                    }
                count++;

                DataRow[] drDN = dtDN.Select("DanhBo like '" + item["DanhBo"].ToString() + "'");

                //bảng kê có đăng ngân
                if (drDN.Count() > 0)
                {
                    int i = 0;
                    int GiaBan = int.Parse(dtDN.Compute("sum(GiaBan)", "DanhBo like '" + item["DanhBo"].ToString() + "'").ToString());
                    int ThueGTGT = int.Parse(dtDN.Compute("sum(ThueGTGT)", "DanhBo like '" + item["DanhBo"].ToString() + "'").ToString());
                    int PhiBVMT = int.Parse(dtDN.Compute("sum(PhiBVMT)", "DanhBo like '" + item["DanhBo"].ToString() + "'").ToString());
                    int TongCong = int.Parse(dtDN.Compute("sum(TongCong)", "DanhBo like '" + item["DanhBo"].ToString() + "'").ToString());

                    //cập nhật sum
                    if (SoPhieuThu == item["SoPhieuThu"].ToString())
                    {
                        SumGiaBan += GiaBan;
                        SumThueGTGT += ThueGTGT;
                        SumPhiBVMT += PhiBVMT;
                        SumTongCong += TongCong;
                    }
                    //else
                    //{
                    //    SoPhieuThu = item["SoPhieuThu"].ToString();
                    //    SumGiaBan = GiaBan;
                    //    SumThueGTGT = ThueGTGT;
                    //    SumPhiBVMT = PhiBVMT;
                    //    SumTongCong = TongCong;
                    //}

                    foreach (DataRow itemdrDN in drDN)
                    {
                        //thêm dòng
                        DataRow dr = dt.NewRow();
                        //if (drDN.Count() == 1)
                        if (i == 0)
                        {
                            dr["MaBK"] = item["MaBK"];
                            dr["SoTien"] = item["SoTien"];
                            dr["SoPhieuThu"] = item["SoPhieuThu"];
                            dr["NgayPhieuThu"] = item["NgayPhieuThu"];
                            dr["CreateDate"] = item["CreateDate"];
                            dr["MaNH"] = item["MaNH"];
                            dr["NganHang"] = item["TenNH"];
                            dr["Lech"] = int.Parse(item["SoTien"].ToString()) - TongCong;
                        }
                        else
                        {
                            dr["MaBK"] = item["MaBK"];
                            dr["SoPhieuThu"] = item["SoPhieuThu"];
                            dr["NgayPhieuThu"] = item["NgayPhieuThu"];
                            dr["CreateDate"] = item["CreateDate"];
                        }

                        dr["DanhBo"] = item["DanhBo"];
                        dr["HoTen"] = itemdrDN["HoTen"];
                        dr["Ky"] = itemdrDN["Ky"];
                        if (string.IsNullOrEmpty(itemdrDN["TienMat"].ToString()))
                        {
                            dr["GiaBan"] = itemdrDN["GiaBan"];
                            dr["ThueGTGT"] = itemdrDN["ThueGTGT"];
                            dr["PhiBVMT"] = itemdrDN["PhiBVMT"];
                            dr["TongCong"] = itemdrDN["TongCong"];
                        }
                        else
                        {
                            dr["GiaBan"] = int.Parse(itemdrDN["GiaBan"].ToString()) - int.Parse(itemdrDN["TienMat"].ToString());
                            dr["ThueGTGT"] = itemdrDN["ThueGTGT"];
                            dr["PhiBVMT"] = itemdrDN["PhiBVMT"];
                            dr["TongCong"] = int.Parse(itemdrDN["TongCong"].ToString()) - int.Parse(itemdrDN["TienMat"].ToString());
                        }
                        dr["TienMat"] = itemdrDN["TienMat"];
                        //if (int.Parse(itemdrDN["GiaBieu"].ToString()) > 20)
                        //    dr["Loai"] = "CQ";
                        //else
                        //    dr["Loai"] = "TG";

                        dt.Rows.Add(dr);
                        i++;
                        //trừ bớt trong danh sách đăng ngân
                        dtDN.Rows.Remove(itemdrDN);
                    }
                    //if (i > 1)
                    //{
                    //    DataRow dr = dt.NewRow();
                    //    dr["MaBK"] = item["MaBK"];
                    //    dr["SoTien"] = item["SoTien"];
                    //    dr["SoPhieuThu"] = item["SoPhieuThu"];
                    //    dr["NgayPhieuThu"] = item["NgayPhieuThu"];
                    //    dr["CreateDate"] = item["CreateDate"];
                    //    dr["MaNH"] = item["MaNH"];
                    //    dr["NganHang"] = item["TenNH"];
                    //    dr["GiaBan"] = GiaBan;
                    //    dr["ThueGTGT"] = ThueGTGT;
                    //    dr["PhiBVMT"] = PhiBVMT;
                    //    dr["TongCong"] = TongCong;
                    //    dr["Lech"] = int.Parse(item["SoTien"].ToString()) - TongCong;
                    //    dt.Rows.Add(dr);
                    //}

                }
                //bảng kê không có đăng ngân
                else
                {
                    //thêm dòng
                    DataRow dr = dt.NewRow();
                    dr["MaBK"] = item["MaBK"];
                    dr["DanhBo"] = item["DanhBo"];
                    dr["SoTien"] = item["SoTien"];
                    dr["SoPhieuThu"] = item["SoPhieuThu"];
                    dr["NgayPhieuThu"] = item["NgayPhieuThu"];
                    dr["CreateDate"] = item["CreateDate"];
                    dr["MaNH"] = item["MaNH"];
                    dr["NganHang"] = item["TenNH"];
                    dr["Lech"] = item["SoTien"];
                    //if (item["DanhBo"].ToString().Length == 11)
                    //{
                    //    HOADON hoadon = _cHoaDon.GetMoiNhat(item["DanhBo"].ToString());
                    //    if (hoadon != null)
                    //        if (hoadon.GB > 20)
                    //            dr["Loai"] = "CQ";
                    //        else
                    //            dr["Loai"] = "TG";
                    //}

                    dt.Rows.Add(dr);
                }

            }

            //dt.DefaultView.Sort = "Loai DESC,MaBK ASC";
            dt.DefaultView.Sort = "MaBK ASC";
            dt = dt.DefaultView.ToTable();

            //danh sách đăng ngân còn lại
            //if (dtDN.Rows.Count > 0)
            //{
            //    dtDN.DefaultView.Sort = "GiaBieu ASC";
            //    dtDN = dtDN.DefaultView.ToTable();
            //}
            foreach (DataRow item in dtDN.Rows)
            {
                TT_BangKe bk = _cBangKe.getLast(item["DanhBo"].ToString(), dateGiaiTrach.Value);

                ///có bảng kê
                if (bk != null)
                {
                    DataRow dr = dt.NewRow();

                    dr["MaBK"] = bk.MaBK;
                    dr["DanhBo"] = bk.DanhBo;
                    dr["SoTien"] = bk.SoTien;
                    if (bk.SoPhieuThu != null)
                        dr["SoPhieuThu"] = bk.SoPhieuThu;
                    if (bk.NgayPhieuThu != null)
                        dr["NgayPhieuThu"] = bk.NgayPhieuThu;
                    dr["CreateDate"] = bk.CreateDate;
                    if (bk.MaNH != null)
                    {
                        dr["MaNH"] = bk.MaNH;
                        dr["NganHang"] = _cNganHang.GetByMaNH(bk.MaNH.Value).NGANHANG1;
                    }
                    dr["DanhBo"] = item["DanhBo"];
                    dr["HoTen"] = item["HoTen"];
                    dr["Ky"] = item["Ky"];
                    if (string.IsNullOrEmpty(item["TienMat"].ToString()))
                    {
                        dr["GiaBan"] = item["GiaBan"];
                        dr["ThueGTGT"] = item["ThueGTGT"];
                        dr["PhiBVMT"] = item["PhiBVMT"];
                        dr["TongCong"] = item["TongCong"];
                    }
                    else
                    {
                        dr["GiaBan"] = int.Parse(item["GiaBan"].ToString()) - int.Parse(item["TienMat"].ToString());
                        dr["ThueGTGT"] = item["ThueGTGT"];
                        dr["PhiBVMT"] = item["PhiBVMT"];
                        dr["TongCong"] = int.Parse(item["TongCong"].ToString()) - int.Parse(item["TienMat"].ToString());
                    }
                    dr["Lech"] = int.Parse(item["TongCong"].ToString()) * -1;
                    dr["TienMat"] = item["TienMat"];
                    //if (int.Parse(item["GiaBieu"].ToString()) > 20)
                    //    dr["Loai"] = "CQ";
                    //else
                    //    dr["Loai"] = "TG";

                    dt.Rows.Add(dr);
                }
                //không có bảng kê
                else
                {
                    DataRow dr = dt.NewRow();

                    dr["DanhBo"] = item["DanhBo"];
                    dr["HoTen"] = item["HoTen"];
                    dr["Ky"] = item["Ky"];
                    if (string.IsNullOrEmpty(item["TienMat"].ToString()))
                    {
                        dr["GiaBan"] = item["GiaBan"];
                        dr["ThueGTGT"] = item["ThueGTGT"];
                        dr["PhiBVMT"] = item["PhiBVMT"];
                        dr["TongCong"] = item["TongCong"];
                    }
                    else
                    {
                        dr["GiaBan"] = int.Parse(item["GiaBan"].ToString()) - int.Parse(item["TienMat"].ToString());
                        dr["ThueGTGT"] = item["ThueGTGT"];
                        dr["PhiBVMT"] = item["PhiBVMT"];
                        dr["TongCong"] = int.Parse(item["TongCong"].ToString()) - int.Parse(item["TienMat"].ToString());
                    }
                    dr["Lech"] = int.Parse(item["TongCong"].ToString()) * -1;
                    dr["TienMat"] = item["TienMat"];
                    //if (int.Parse(item["GiaBieu"].ToString()) > 20)
                    //    dr["Loai"] = "CQ";
                    //else
                    //    dr["Loai"] = "TG";

                    dt.Rows.Add(dr);
                }
            }

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

            oSheet.Name = "BẢNG KÊ";

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "M1");
            head.MergeCells = true;
            head.Value2 = "BẢNG KÊ KHÁCH HÀNG CHUYỂN KHOẢN - GIẢI TRÁCH TIỀN NƯỚC \r\n NGÀY " + dateGiaiTrach.Value.ToString("dd/MM/yyyy");
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.RowHeight = 50;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            long TonDau = _cTienDu.GetTongTienTonDauNgay(dateGiaiTrach.Value) + _cPMN.getPhiMoNuoc_Chot(false);

            Microsoft.Office.Interop.Excel.Range head2a = oSheet.get_Range("A2", "B2");
            head2a.MergeCells = true;
            head2a.Value2 = "Tồn năm " + dateGiaiTrach.Value.ToString("yyyy") + ":";
            head2a.Font.Bold = true;
            head2a.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range head2b = oSheet.get_Range("C2", "C2");
            //head2b.MergeCells = true;
            head2b.Value2 = TonDau;
            head2b.Font.Bold = true;
            head2b.Font.Name = "Times New Roman";
            head2b.NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range head3a = oSheet.get_Range("A3", "B3");
            head3a.MergeCells = true;
            head3a.Value2 = "A. Tồn lũy kế đầu ngày:";
            head3a.Font.Bold = true;
            head3a.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range head3b = oSheet.get_Range("C3", "C3");
            //head3b.MergeCells = true;
            head3b.Value2 = TonDau;
            head3b.Font.Bold = true;
            head3b.Font.Name = "Times New Roman";
            head3b.NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range head4 = oSheet.get_Range("A4", "M4");
            head4.MergeCells = true;
            head4.Value2 = "B. Tình hình phát sinh, giải trách của chứng từ ngày " + dateGiaiTrach.Value.AddDays(-1).ToString("dd/MM/yyyy") + ":";
            //head4.Font.Bold = true;
            head4.Font.Name = "Times New Roman";

            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A5", "A5");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 5;
            cl1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl1.Font.Bold = true;
            cl1.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B5", "B5");
            cl2.Value2 = "TÊN KHÁCH HÀNG";
            cl2.ColumnWidth = 20;
            cl2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl2.Font.Bold = true;
            cl2.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C5", "C5");
            cl3.Value2 = "DANH BỘ";
            cl3.ColumnWidth = 12;
            cl3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl3.Font.Bold = true;
            cl3.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D5", "E5");
            cl4.MergeCells = true;
            cl4.Value2 = "KHÁCH HÀNG CK";
            cl4.ColumnWidth = 20;
            cl4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl4.Font.Bold = true;
            cl4.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl4a = oSheet.get_Range("D6", "D6");
            cl4a.Value2 = "PT";
            cl4a.ColumnWidth = 8;
            cl4a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl4a.Font.Bold = true;
            cl4a.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl4b = oSheet.get_Range("E6", "E6");
            cl4b.Value2 = "SỐ TIỀN";
            cl4b.ColumnWidth = 12;
            cl4b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl4b.Font.Bold = true;
            cl4b.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("F5", "M5");
            cl5.MergeCells = true;
            cl5.Value2 = "GIẢI TRÁCH";
            cl5.ColumnWidth = 70;
            cl5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5.Font.Bold = true;
            cl5.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5a = oSheet.get_Range("F6", "F6");
            cl5a.Value2 = "KỲ";
            cl5a.ColumnWidth = 5;
            cl5a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5a.Font.Bold = true;
            cl5a.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5b = oSheet.get_Range("G6", "G6");
            cl5b.Value2 = "NGÀY BK";
            cl5b.ColumnWidth = 11;
            cl5b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5b.Font.Bold = true;
            cl5b.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5c = oSheet.get_Range("H6", "H6");
            cl5c.Value2 = "PT";
            cl5c.ColumnWidth = 8;
            cl5c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5c.Font.Bold = true;
            cl5c.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5d = oSheet.get_Range("I6", "I6");
            cl5d.Value2 = "TN";
            cl5d.ColumnWidth = 12;
            cl5d.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5d.Font.Bold = true;
            cl5d.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5e = oSheet.get_Range("J6", "J6");
            cl5e.Value2 = "THUẾ";
            cl5e.ColumnWidth = 10;
            cl5e.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5e.Font.Bold = true;
            cl5e.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5f = oSheet.get_Range("K6", "K6");
            cl5f.Value2 = "PHÍ BVMT";
            cl5f.ColumnWidth = 10;
            cl5f.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5f.Font.Bold = true;
            cl5f.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5g = oSheet.get_Range("L6", "L6");
            cl5g.Value2 = "CỘNG GT";
            cl5g.ColumnWidth = 12;
            cl5g.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5g.Font.Bold = true;
            cl5g.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5h = oSheet.get_Range("M6", "M6");
            cl5h.Value2 = "LỆCH";
            cl5h.ColumnWidth = 10;
            cl5h.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5h.Font.Bold = true;
            cl5h.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("N5", "N5");
            cl6.Value2 = "LOẠI";
            cl6.ColumnWidth = 5;
            cl6.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl6.Font.Bold = true;
            cl6.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("O5", "O5");
            cl7.Value2 = "BANK";
            cl7.ColumnWidth = 10;
            cl7.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl7.Font.Bold = true;
            cl7.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("P5", "P5");
            cl8.Value2 = "TIỀN MẶT";
            cl8.ColumnWidth = 10;
            cl8.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl8.Font.Bold = true;
            cl8.Font.Name = "Times New Roman";


            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 16];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            //int STT = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                //if (!string.IsNullOrEmpty(dr["DanhBo"].ToString()))
                //    arr[i, 0] = STT++;
                arr[i, 0] = i + 1;
                arr[i, 1] = dr["HoTen"].ToString();
                arr[i, 2] = dr["DanhBo"].ToString();
                if (!string.IsNullOrEmpty(dr["SoPhieuThu"].ToString()))
                {
                    arr[i, 3] = dr["SoPhieuThu"].ToString();
                    arr[i, 7] = dr["SoPhieuThu"].ToString();
                }
                arr[i, 4] = dr["SoTien"].ToString();
                arr[i, 5] = dr["Ky"].ToString();
                if (!string.IsNullOrEmpty(dr["NgayPhieuThu"].ToString()))
                    arr[i, 6] = DateTime.Parse(dr["NgayPhieuThu"].ToString()).ToString("dd/MM/yyyy");
                //if (!string.IsNullOrEmpty(dr["SoPhieuThu"].ToString()))
                //    arr[i, 7] = dr["SoPhieuThu"].ToString();
                arr[i, 8] = dr["GiaBan"].ToString();
                arr[i, 9] = dr["ThueGTGT"].ToString();
                arr[i, 10] = dr["PhiBVMT"].ToString();
                arr[i, 11] = dr["TongCong"].ToString();
                //if (!string.IsNullOrEmpty(dr["SoTien"].ToString()) && !string.IsNullOrEmpty(dr["TongCong"].ToString()))
                //    arr[i, 12] = int.Parse(dr["SoTien"].ToString()) - int.Parse(dr["TongCong"].ToString());
                arr[i, 12] = dr["Lech"];
                //arr[i, 13] = dr["Loai"];

                arr[i, 14] = dr["NganHang"];
                arr[i, 15] = dr["TienMat"];
                //if (!string.IsNullOrEmpty(dr["TongBK"].ToString()))
                //    if (int.Parse(dr["TongBK"].ToString()) > 1)
                //        arr[i, 14] = "X";
                //if (!string.IsNullOrEmpty(dr["TongHD"].ToString()))
                //    if (int.Parse(dr["TongHD"].ToString()) > 1)
                //        arr[i, 14] = "X";
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 7;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 16;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            //oSheet.get_Range(c2a, c3a).Font.Bold = true;
            //oSheet.get_Range(c2a, c3a).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2a, c3a).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 7];
            Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 7];
            Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            //oSheet.get_Range(c2b, c3b).Font.Bold = true;
            //oSheet.get_Range(c2b, c3b).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2b, c3b).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 8];
            Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 8];
            Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            //oSheet.get_Range(c2c, c3c).Font.Bold = true;
            //oSheet.get_Range(c2c, c3c).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2c, c3c).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
            Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
            Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
            //oSheet.get_Range(c2d, c3d).Font.Bold = true;
            //oSheet.get_Range(c2d, c3d).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2d, c3d).NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 9];
            Microsoft.Office.Interop.Excel.Range c2e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 9];
            Microsoft.Office.Interop.Excel.Range c3e = oSheet.get_Range(c1e, c2e);
            //oSheet.get_Range(c2e, c3e).Font.Bold = true;
            //oSheet.get_Range(c2e, c3e).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2e, c3e).NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range c1f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 10];
            Microsoft.Office.Interop.Excel.Range c2f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 10];
            Microsoft.Office.Interop.Excel.Range c3f = oSheet.get_Range(c1f, c2f);
            //oSheet.get_Range(c2f, c3f).Font.Bold = true;
            //oSheet.get_Range(c2f, c3f).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2f, c3f).NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range c1g = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 11];
            Microsoft.Office.Interop.Excel.Range c2g = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 11];
            Microsoft.Office.Interop.Excel.Range c3g = oSheet.get_Range(c1g, c2g);
            //oSheet.get_Range(c2g, c3g).Font.Bold = true;
            //oSheet.get_Range(c2g, c3g).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2g, c3g).NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range c1h = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 12];
            Microsoft.Office.Interop.Excel.Range c2h = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 12];
            Microsoft.Office.Interop.Excel.Range c3h = oSheet.get_Range(c1h, c2h);
            //oSheet.get_Range(c2h, c3h).Font.Bold = true;
            //oSheet.get_Range(c2h, c3h).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2h, c3h).NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range c1i = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 13];
            Microsoft.Office.Interop.Excel.Range c2i = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 13];
            Microsoft.Office.Interop.Excel.Range c3i = oSheet.get_Range(c1i, c2i);
            //oSheet.get_Range(c2i, c3i).Font.Bold = true;
            //oSheet.get_Range(c2i, c3i).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2i, c3i).NumberFormat = "#,##0";

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;

            oSheet.Cells[rowEnd + 1, 5] = dtBK.Compute("sum(SoTien)", "CreateDate >='" + dateGiaiTrach.Value.ToString("yyyy/MM/dd") + "'");
            oSheet.Cells[rowEnd + 1, 9] = dt.Compute("sum(GiaBan)", "DanhBo <> ''");
            oSheet.Cells[rowEnd + 1, 10] = dt.Compute("sum(ThueGTGT)", "DanhBo <> ''");
            oSheet.Cells[rowEnd + 1, 11] = dt.Compute("sum(PhiBVMT)", "DanhBo <> ''");
            oSheet.Cells[rowEnd + 1, 12] = dt.Compute("sum(TongCong)", "DanhBo <> ''");
            //format number
            Microsoft.Office.Interop.Excel.Range c1sum1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, 5];
            Microsoft.Office.Interop.Excel.Range c2sum1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, 12];
            Microsoft.Office.Interop.Excel.Range c3sum1 = oSheet.get_Range(c1sum1, c2sum1);
            oSheet.get_Range(c2sum1, c3sum1).Font.Bold = true;
            //oSheet.get_Range(c2sum1, c3sum1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2sum1, c3sum1).NumberFormat = "#,##0";

            oSheet.Cells[rowEnd + 3, 2] = "AGR";
            oSheet.Cells[rowEnd + 4, 2] = "MB";
            oSheet.Cells[rowEnd + 5, 2] = "KHO BẠC";
            oSheet.Cells[rowEnd + 6, 2] = "VCB";

            oSheet.Cells[rowEnd + 3, 3] = dtBK.Compute("sum(SoTien)", "MaNH <> 3 and MaNH <> 4 and MaNH <> 10 and CreateDate >='" + dateGiaiTrach.Value.ToString("yyyy/MM/dd") + "'");
            oSheet.Cells[rowEnd + 4, 3] = dtBK.Compute("sum(SoTien)", "MaNH = 4 and CreateDate >='" + dateGiaiTrach.Value.ToString("yyyy/MM/dd") + "'");
            oSheet.Cells[rowEnd + 5, 3] = dtBK.Compute("sum(SoTien)", "MaNH = 3 and CreateDate >='" + dateGiaiTrach.Value.ToString("yyyy/MM/dd") + "'");
            oSheet.Cells[rowEnd + 6, 3] = dtBK.Compute("sum(SoTien)", "MaNH = 10 and CreateDate >='" + dateGiaiTrach.Value.ToString("yyyy/MM/dd") + "'");
            //format number
            Microsoft.Office.Interop.Excel.Range c1sum2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 3, 3];
            Microsoft.Office.Interop.Excel.Range c2sum2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 6, 3];
            Microsoft.Office.Interop.Excel.Range c3sum2 = oSheet.get_Range(c1sum2, c2sum2);
            oSheet.get_Range(c2sum2, c3sum2).Font.Bold = true;
            //oSheet.get_Range(c2sum2, c3sum2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2sum2, c3sum2).NumberFormat = "#,##0";

            oSheet.Cells[rowEnd + 8, 2] = "Tồn cuối ngày:";
            oSheet.Cells[rowEnd + 8, 3] = _cTienDu.GetTongTienTonDenNgay(dateGiaiTrach.Value) + _cPMN.getPhiMoNuoc_Chot(false);
            //format number
            Microsoft.Office.Interop.Excel.Range c1sum3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 8, 3];
            Microsoft.Office.Interop.Excel.Range c2sum3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 8, 3];
            Microsoft.Office.Interop.Excel.Range c3sum3 = oSheet.get_Range(c1sum3, c2sum3);
            oSheet.get_Range(c2sum3, c3sum3).Font.Bold = true;
            //oSheet.get_Range(c2sum3, c3sum3).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c2sum3, c3sum3).NumberFormat = "#,##0";
        }

        private void backgroundWorker_BangKeMoi_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (frm != null)
                frm.Close();
        }

    }
}

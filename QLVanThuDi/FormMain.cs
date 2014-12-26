using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLVanThu.DAL;

namespace QLVanThu
{
    public partial class FormMain : Form
    {
        CDataQLVanThuDi _CDataQLVanThuDi = new CDataQLVanThuDi();
        BindingSource vanthudis = new BindingSource();
        DataTable _dt = new DataTable();
        string _TuNgay ="";
        string _DenNgay = "";
        Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
        Microsoft.Office.Interop.Excel.Workbooks oBooks;
        Microsoft.Office.Interop.Excel.Sheets oSheets;
        Microsoft.Office.Interop.Excel.Workbook oBook;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            vanthudis.DataSource = _CDataQLVanThuDi.LoadDSVanThuDi();
            dgvDSVanThuDi.DataSource =  vanthudis ;
        }

        private void LoadDSVanThuDiFilter()
        {
            string expression = String.Format("(NgayThangVB like '%{0}%' or SoKyHieuVB like '%{0}%' or LoaiTrichYeuNoiDung like '%{0}%')", txtNoiDungTimKiem.Text.Trim());
            //if (chkCongVanDen.Checked)
            //    expression = "LoaiVBGID=3 and " + expression;
            //else
            //    if (chkDonThuDen.Checked)
            //        expression = "LoaiVBGID=7 and " + expression;
            vanthudis.Filter = expression;
        }

        private void ExportToExcel(DataTable dt, string sheetName, string title)
        {
            int r=0;
            try
            {
                //Tạo các đối tượng Excel
                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbooks oBooks;
                Microsoft.Office.Interop.Excel.Sheets oSheets;
                Microsoft.Office.Interop.Excel.Workbook oBook;
                Microsoft.Office.Interop.Excel.Worksheet oSheet;

                //Tạo mới một Excel WorkBook 
                oExcel.Visible = true;
                oExcel.DisplayAlerts = false;
                oExcel.Application.SheetsInNewWorkbook = 1;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;
                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
                oSheet.Name = sheetName;

                // Tạo phần đầu nếu muốn
                Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "G1");
                head.MergeCells = true;
                head.Value2 = title;
                head.Font.Bold = true;
                head.Font.Name = "Times New Roman";
                head.Font.Size = "20";
                head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                // Tạo tiêu đề cột 
                Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
                cl1.Value2 = "Ngày Tháng Văn Bản";
                cl1.ColumnWidth = 18;

                Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "C3");
                cl2.Value2 = "Số Ký Hiệu A";
                cl2.ColumnWidth = 12;

                Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
                cl3.Value2 = "Số Ký Hiệu B";
                cl3.ColumnWidth = 22;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
                cl4.Value2 = "Đơn Vị Thảo";
                cl4.ColumnWidth = 12;

                Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
                cl5.Value2 = "Loại";
                cl5.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
                cl6.Value2 = "Loại Trích Yếu Nội Dung";
                cl6.ColumnWidth = 150;

                Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
                cl7.Value2 = "Nơi Nhận";
                cl7.ColumnWidth = 200;

                Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "G3");
                rowHead.Font.Bold = true;
                //rowHead.AutoFilter(1,Type.Missing,Microsoft.Office.Interop.Excel.XlAutoFilterOperator.xlAnd,Type.Missing,true);
                // Kẻ viền
                rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                // Thiết lập màu nền
                rowHead.Interior.ColorIndex = 15;
                rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


                // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
                // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
                object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];

                //Chuyển dữ liệu từ DataTable vào mảng đối tượng
                for (r = 0; r < dt.Rows.Count; r++)
                {
                    DataRow dr = dt.Rows[r];
                    //for (int c = 0; c < dt.Columns.Count - 3; c++)
                    //{
                    //    arr[r, c] = dr[c];
                    //}
                    arr[r, 0] = dr["NgayThangVB"];
                    string[] SoKyHieuDatas = dr["SoKyHieuVB"].ToString().Split('/');
                    string[] NoiThaoDatas = dr["SoKyHieuVB"].ToString().Split('-');
                    arr[r, 1] = SoKyHieuDatas[0];
                    arr[r, 2] = SoKyHieuDatas[1];
                    arr[r, 3] = NoiThaoDatas[NoiThaoDatas.Count() - 1];
                    arr[r, 4] = dr["LoaiVB"];
                    arr[r, 5] = dr["LoaiTrichYeuNoiDung"];
                    arr[r, 6] = dr["NoiNhan"];
                }

                //Thiết lập vùng điền dữ liệu
                int rowStart = 4;
                int columnStart = 1;

                int rowEnd = rowStart + dt.Rows.Count - 1;
                int columnEnd = dt.Columns.Count - 3;

                // Ô bắt đầu điền dữ liệu
                Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
                // Ô kết thúc điền dữ liệu
                Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
                // Lấy về vùng điền dữ liệu
                Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

                //Điền dữ liệu vào vùng đã thiết lập
                range.Value2 = arr;

                // Kẻ viền
                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                // Căn giữa cột Ngày Đi
                Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];
                Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);
                oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3, c4).Font.Name = "Times New Roman";
                oSheet.get_Range(c3, c4).Font.Size = 12;
                // Căn trái cột Số Ký Hiệu A
                Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
                Microsoft.Office.Interop.Excel.Range c3b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
                Microsoft.Office.Interop.Excel.Range c4b = oSheet.get_Range(c1b, c3b);
                oSheet.get_Range(c3b, c4b).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3b, c4b).Font.Name = "Times New Roman";
                oSheet.get_Range(c3b, c4b).Font.Size = 12;
                // Căn trái cột Số Ký Hiệu B
                Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
                Microsoft.Office.Interop.Excel.Range c3c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
                Microsoft.Office.Interop.Excel.Range c4c = oSheet.get_Range(c1c, c3c);
                oSheet.get_Range(c3c, c4c).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3c, c4c).Font.Name = "Times New Roman";
                oSheet.get_Range(c3c, c4c).Font.Size = 12;
                // Căn giữa cột Đơn Vị Thảo
                Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
                Microsoft.Office.Interop.Excel.Range c3d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
                Microsoft.Office.Interop.Excel.Range c4d = oSheet.get_Range(c1d, c3d);
                oSheet.get_Range(c3d, c4d).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3d, c4d).Font.Name = "Times New Roman";
                oSheet.get_Range(c3d, c4d).Font.Size = 12;
                // Căn giữa cột Loại Văn Bản
                Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
                Microsoft.Office.Interop.Excel.Range c3e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
                Microsoft.Office.Interop.Excel.Range c4e = oSheet.get_Range(c1e, c3e);
                oSheet.get_Range(c3e, c4e).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3e, c4e).Font.Name = "Times New Roman";
                oSheet.get_Range(c3e, c4e).Font.Size = 12;
                // Nội Dung
                Microsoft.Office.Interop.Excel.Range c1f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 6];
                Microsoft.Office.Interop.Excel.Range c3f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 6];
                Microsoft.Office.Interop.Excel.Range c4f = oSheet.get_Range(c1f, c3f);
                oSheet.get_Range(c3f, c4f).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                oSheet.get_Range(c3f, c4f).Font.Name = "Times New Roman";
                oSheet.get_Range(c3f, c4f).Font.Size = 12;
                // Nơi Nhận
                Microsoft.Office.Interop.Excel.Range c1g = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 7];
                Microsoft.Office.Interop.Excel.Range c3g = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 7];
                Microsoft.Office.Interop.Excel.Range c4g = oSheet.get_Range(c1g, c3g);
                oSheet.get_Range(c3g, c4g).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                oSheet.get_Range(c3g, c4g).Font.Name = "Times New Roman";
                oSheet.get_Range(c3g, c4g).Font.Size = 12;
            }
            catch (Exception)
            {
                MessageBox.Show("Ký hiệu văn bản sai: "+dt.Rows[r]["SoKyHieuVB"].ToString());
            }
            
        }

        private void ExportToExcelTongHop(DataTable dt)
        {
            int r = 0;
            int TuSo = 100000;
            int DenSo = 0 ;
            try
            {
                //Tạo các đối tượng Excel
                //Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                //Microsoft.Office.Interop.Excel.Workbooks oBooks;
                //Microsoft.Office.Interop.Excel.Sheets oSheets;
                //Microsoft.Office.Interop.Excel.Workbook oBook;
                Microsoft.Office.Interop.Excel.Worksheet oSheetTongHop;

                //Tạo mới một Excel WorkBook 
                oExcel.Visible = true;
                oExcel.DisplayAlerts = false;
                //khai báo số lượng sheet
                oExcel.Application.SheetsInNewWorkbook = 14;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;
                oSheetTongHop = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
                oSheetTongHop.Name = "Tổng Hợp";

                // Tạo phần đầu nếu muốn
                Microsoft.Office.Interop.Excel.Range head1 = oSheetTongHop.get_Range("A1", "D1");
                head1.MergeCells = true;
                head1.Value2 = "TỔNG CÔNG TY CẤP NƯỚC SÀI GÒN";
                head1.Font.Name = "Times New Roman";
                head1.Font.Size = "11";
                head1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range head2 = oSheetTongHop.get_Range("A2", "D2");
                head2.MergeCells = true;
                head2.Value2 = "TRÁCH NHIỆM HỮU HẠN MTV";
                head2.Font.Name = "Times New Roman";
                head2.Font.Size = "11";
                head2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range head3 = oSheetTongHop.get_Range("A3", "D3");
                head3.MergeCells = true;
                head3.Value2 = "CÔNG TY TNHH MTV CẤP NƯỚC TÂN HÒA";
                head3.Font.Bold = true;
                head3.Font.Name = "Times New Roman";
                head3.Font.Size = "11";
                head3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range head4 = oSheetTongHop.get_Range("G1", "H1");
                head4.MergeCells = true;
                head4.Value2 = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
                head4.Font.Bold = true;
                head4.Font.Name = "Times New Roman";
                head4.Font.Size = "11";
                head4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range head5 = oSheetTongHop.get_Range("G2", "H2");
                head5.MergeCells = true;
                head5.Value2 = "Độc lập - Tự do - Hạnh phúc";
                head5.Font.Bold = true;
                head5.Font.Name = "Times New Roman";
                head5.Font.Size = "11";
                head5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range head6 = oSheetTongHop.get_Range("A6", "H6");
                head6.MergeCells = true;
                head6.Value2 = "DANH MỤC VĂN BẢN ĐI";
                head6.Font.Bold = true;
                head6.Font.Name = "Times New Roman";
                head6.Font.Size = "20";
                head6.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range head7 = oSheetTongHop.get_Range("A7", "H7");
                head7.MergeCells = true;
                head7.Value2 = "Từ ngày: " + _TuNgay + "    đến ngày: " + _DenNgay;
                head7.Font.Bold = true;
                head7.Font.Name = "Times New Roman";
                head7.Font.Size = "18";
                head7.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                

                // Tạo tiêu đề cột 
                Microsoft.Office.Interop.Excel.Range cl1 = oSheetTongHop.get_Range("A10", "A10");
                cl1.Value2 = "STT";
                cl1.ColumnWidth = 5;
                cl1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl2 = oSheetTongHop.get_Range("B10", "B10");
                cl2.Value2 = "Ngày";
                cl2.ColumnWidth = 12;
                cl2.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl3 = oSheetTongHop.get_Range("C10", "D10");
                cl3.MergeCells = true;
                cl3.Value2 = "Số Ký Hiệu Văn Bản";
                cl3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //cl3.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range cl3a = oSheetTongHop.get_Range("C11", "C11");
                cl3a.ColumnWidth = 6;

                Microsoft.Office.Interop.Excel.Range cl3b = oSheetTongHop.get_Range("D11", "D11");
                cl3b.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheetTongHop.get_Range("E10", "E10");
                cl4.Value2 = "Đơn Vị Thảo";
                cl4.ColumnWidth = 15;
                cl4.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl5 = oSheetTongHop.get_Range("F10", "F10");
                cl5.Value2 = "Loại";
                cl5.ColumnWidth = 8;
                cl5.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl6 = oSheetTongHop.get_Range("G10", "G10");
                cl6.Value2 = "Trích Yếu Nội Dung";
                cl6.ColumnWidth = 80;
                cl6.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl7 = oSheetTongHop.get_Range("H10", "H10");
                cl7.Value2 = "Ghi Chú";
                cl7.ColumnWidth = 20;
                cl7.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range rowHead = oSheetTongHop.get_Range("A10", "H10");
                rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                rowHead.Font.Bold = true;
                rowHead.Interior.Color= System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                rowHead.RowHeight = 20;

                // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
                // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
                object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];
                
                //Chuyển dữ liệu từ DataTable vào mảng đối tượng
                for (r = 0; r < dt.Rows.Count; r++)
                {
                    DataRow dr = dt.Rows[r];
                    //for (int c = 0; c < dt.Columns.Count - 3; c++)
                    //{
                    //    arr[r, c] = dr[c];
                    //}
                    arr[r, 0] = r + 1;
                    arr[r, 1] = dr["NgayThangVB"];
                    string[] SoKyHieuDatas = dr["SoKyHieuVB"].ToString().Split('/');
                    string[] NoiThaoDatas = dr["SoKyHieuVB"].ToString().Split('-');
                    if (int.Parse(SoKyHieuDatas[0]) < TuSo)
                        TuSo = int.Parse(SoKyHieuDatas[0]);
                    if (int.Parse(SoKyHieuDatas[0]) > DenSo)
                        DenSo = int.Parse(SoKyHieuDatas[0]);
                    arr[r, 2] = SoKyHieuDatas[0];
                    arr[r, 3] = SoKyHieuDatas[1];
                    arr[r, 4] = NoiThaoDatas[NoiThaoDatas.Count() - 1];
                    arr[r, 5] = dr["LoaiVB"];
                    arr[r, 6] = dr["LoaiTrichYeuNoiDung"];
                }

                //Thiết lập vùng điền dữ liệu
                int rowStart = 12;
                int columnStart = 1;

                int rowEnd = rowStart + dt.Rows.Count - 1;
                int columnEnd = 8;

                // Ô bắt đầu điền dữ liệu
                Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, columnStart];
                // Ô kết thúc điền dữ liệu
                Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, columnEnd];
                // Lấy về vùng điền dữ liệu
                Microsoft.Office.Interop.Excel.Range range = oSheetTongHop.get_Range(c1, c2);

                //Điền dữ liệu vào vùng đã thiết lập
                range.Value2 = arr;

                // Kẻ viền
                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                // Tạo filter
                Microsoft.Office.Interop.Excel.Range c1z = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart - 1, columnStart];
                Microsoft.Office.Interop.Excel.Range c2z = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, columnEnd];
                Microsoft.Office.Interop.Excel.Range rangez = oSheetTongHop.get_Range(c1z, c2z);
                rangez.AutoFilter(1, Type.Missing, Microsoft.Office.Interop.Excel.XlAutoFilterOperator.xlAnd, Type.Missing, true);
                // Font tổng thể
                Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, columnStart];
                Microsoft.Office.Interop.Excel.Range c4 = oSheetTongHop.get_Range(c1, c3);
                c4.RowHeight = 50;
                //oSheet.get_Range(c3, c4).Font.Name = "Times New Roman";
                //oSheet.get_Range(c3, c4).Font.Size = 12;
                // Căn giữa cột STT
                Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 1];
                Microsoft.Office.Interop.Excel.Range c3a = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 1];
                Microsoft.Office.Interop.Excel.Range c4a = oSheetTongHop.get_Range(c1a, c3a);
                oSheetTongHop.get_Range(c3a, c4a).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3a, c4a).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3a, c4a).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3a, c4a).Font.Size = 12;
                // Căn giữa Ngày
                Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 2];
                Microsoft.Office.Interop.Excel.Range c3b = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 2];
                Microsoft.Office.Interop.Excel.Range c4b = oSheetTongHop.get_Range(c1b, c3b);
                oSheetTongHop.get_Range(c3b, c4b).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3b, c4b).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3b, c4b).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3b, c4b).Font.Size = 12;
                // Căn trái cột Số Ký Hiệu A
                Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 3];
                Microsoft.Office.Interop.Excel.Range c3c = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 3];
                Microsoft.Office.Interop.Excel.Range c4c = oSheetTongHop.get_Range(c1c, c3c);
                oSheetTongHop.get_Range(c3c, c4c).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3c, c4c).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3c, c4c).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3c, c4c).Font.Size = 12;
                // Căn trái cột Số Ký Hiệu B
                Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 4];
                Microsoft.Office.Interop.Excel.Range c3d = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 4];
                Microsoft.Office.Interop.Excel.Range c4d = oSheetTongHop.get_Range(c1d, c3d);
                oSheetTongHop.get_Range(c3d, c4d).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3d, c4d).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                oSheetTongHop.get_Range(c3d, c4d).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3d, c4d).Font.Size = 12;
                // Căn giữa cột Đơn Vị Thảo
                Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 5];
                Microsoft.Office.Interop.Excel.Range c3e = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 5];
                Microsoft.Office.Interop.Excel.Range c4e = oSheetTongHop.get_Range(c1e, c3e);
                oSheetTongHop.get_Range(c3e, c4e).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3e, c4e).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3e, c4e).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3e, c4e).Font.Size = 12;
                // Căn giữa cột Loại Văn Bản
                Microsoft.Office.Interop.Excel.Range c1f = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 6];
                Microsoft.Office.Interop.Excel.Range c3f = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 6];
                Microsoft.Office.Interop.Excel.Range c4f = oSheetTongHop.get_Range(c1f, c3f);
                oSheetTongHop.get_Range(c3f, c4f).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3f, c4f).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3f, c4f).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3f, c4f).Font.Size = 12;
                // Nội Dung
                Microsoft.Office.Interop.Excel.Range c1g = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 7];
                Microsoft.Office.Interop.Excel.Range c3g = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 7];
                Microsoft.Office.Interop.Excel.Range c4g = oSheetTongHop.get_Range(c1g, c3g);
                oSheetTongHop.get_Range(c3g, c4g).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3g, c4g).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                oSheetTongHop.get_Range(c3g, c4g).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3g, c4g).Font.Size = 12;
                oSheetTongHop.get_Range(c3g, c4g).ShrinkToFit = true;
                oSheetTongHop.get_Range(c3g, c4g).WrapText = true;
                //Edit phần đầu
                Microsoft.Office.Interop.Excel.Range head8 = oSheetTongHop.get_Range("A8", "H8");
                head8.MergeCells = true;
                head8.Value2 = "Từ số: " + TuSo + "    đến số: " + DenSo;
                head8.Font.Bold = true;
                head8.Font.Name = "Times New Roman";
                head8.Font.Size = "18";
                head8.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }
            catch (Exception)
            {
                MessageBox.Show("Ký hiệu văn bản sai: " + dt.Rows[r]["SoKyHieuVB"].ToString());
            }

        }

        private void ExportToExcelChiTiet(DataTable dt,Microsoft.Office.Interop.Excel.Worksheet oSheet,string SheetName)
        {
            int r = 0;
            int TuSo = 100000;
            int DenSo = 0 ;
            try
            {
                oSheet.Name = SheetName;

                // Tạo phần đầu nếu muốn
                Microsoft.Office.Interop.Excel.Range head1 = oSheet.get_Range("A1", "D1");
                head1.MergeCells = true;
                head1.Value2 = "TỔNG CÔNG TY CẤP NƯỚC SÀI GÒN";
                head1.Font.Name = "Times New Roman";
                head1.Font.Size = "11";
                head1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range head2 = oSheet.get_Range("A2", "D2");
                head2.MergeCells = true;
                head2.Value2 = "TRÁCH NHIỆM HỮU HẠN MTV";
                head2.Font.Name = "Times New Roman";
                head2.Font.Size = "11";
                head2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range head3 = oSheet.get_Range("A3", "D3");
                head3.MergeCells = true;
                head3.Value2 = "CÔNG TY TNHH MTV CẤP NƯỚC TÂN HÒA";
                head3.Font.Bold = true;
                head3.Font.Name = "Times New Roman";
                head3.Font.Size = "11";
                head3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range head4 = oSheet.get_Range("G1", "H1");
                head4.MergeCells = true;
                head4.Value2 = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
                head4.Font.Bold = true;
                head4.Font.Name = "Times New Roman";
                head4.Font.Size = "11";
                head4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range head5 = oSheet.get_Range("G2", "H2");
                head5.MergeCells = true;
                head5.Value2 = "Độc lập - Tự do - Hạnh phúc";
                head5.Font.Bold = true;
                head5.Font.Name = "Times New Roman";
                head5.Font.Size = "11";
                head5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range head6 = oSheet.get_Range("A6", "H6");
                head6.MergeCells = true;
                head6.Value2 = "DANH MỤC VĂN BẢN ĐI     (" + SheetName+")";
                head6.Font.Bold = true;
                head6.Font.Name = "Times New Roman";
                head6.Font.Size = "20";
                head6.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range head7 = oSheet.get_Range("A7", "H7");
                head7.MergeCells = true;
                head7.Value2 = "Từ ngày: " + _TuNgay + "    đến ngày: " + _DenNgay;
                head7.Font.Bold = true;
                head7.Font.Name = "Times New Roman";
                head7.Font.Size = "18";
                head7.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;



                // Tạo tiêu đề cột 
                Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A10", "A10");
                cl1.Value2 = "STT";
                cl1.ColumnWidth = 5;
                cl1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B10", "B10");
                cl2.Value2 = "Ngày";
                cl2.ColumnWidth = 12;
                cl2.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C10", "D10");
                cl3.MergeCells = true;
                cl3.Value2 = "Số Ký Hiệu Văn Bản";
                cl3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //cl3.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range cl3a = oSheet.get_Range("C11", "C11");
                cl3a.ColumnWidth = 6;

                Microsoft.Office.Interop.Excel.Range cl3b = oSheet.get_Range("D11", "D11");
                cl3b.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("E10", "E10");
                cl4.Value2 = "Đơn Vị Thảo";
                cl4.ColumnWidth = 15;
                cl4.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("F10", "F10");
                cl5.Value2 = "Loại";
                cl5.ColumnWidth = 8;
                cl5.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("G10", "G10");
                cl6.Value2 = "Trích Yếu Nội Dung";
                cl6.ColumnWidth = 80;
                cl6.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("H10", "H10");
                cl7.Value2 = "Ghi Chú";
                cl7.ColumnWidth = 20;
                cl7.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A10", "H10");
                rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                rowHead.Font.Bold = true;
                rowHead.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                rowHead.RowHeight = 20;

                // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
                // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
                object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];

                //Chuyển dữ liệu từ DataTable vào mảng đối tượng
                for (r = 0; r < dt.Rows.Count; r++)
                {
                    DataRow dr = dt.Rows[r];
                    //for (int c = 0; c < dt.Columns.Count - 3; c++)
                    //{
                    //    arr[r, c] = dr[c];
                    //}
                    arr[r, 0] = r + 1;
                    arr[r, 1] = dr["NgayThangVB"];
                    string[] SoKyHieuDatas = dr["SoKyHieuVB"].ToString().Split('/');
                    string[] NoiThaoDatas = dr["SoKyHieuVB"].ToString().Split('-');
                    if (int.Parse(SoKyHieuDatas[0]) < TuSo)
                        TuSo = int.Parse(SoKyHieuDatas[0]);
                    if (int.Parse(SoKyHieuDatas[0]) > DenSo)
                        DenSo = int.Parse(SoKyHieuDatas[0]);
                    arr[r, 2] = SoKyHieuDatas[0];
                    arr[r, 3] = SoKyHieuDatas[1];
                    arr[r, 4] = NoiThaoDatas[NoiThaoDatas.Count() - 1];
                    arr[r, 5] = dr["LoaiVB"];
                    arr[r, 6] = dr["LoaiTrichYeuNoiDung"];
                }

                //Thiết lập vùng điền dữ liệu
                int rowStart = 12;
                int columnStart = 1;

                int rowEnd = rowStart + dt.Rows.Count - 1;
                int columnEnd = 8;

                // Ô bắt đầu điền dữ liệu
                Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
                // Ô kết thúc điền dữ liệu
                Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
                // Lấy về vùng điền dữ liệu
                Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

                //Điền dữ liệu vào vùng đã thiết lập
                range.Value2 = arr;

                // Kẻ viền
                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                //Tạo filter
                Microsoft.Office.Interop.Excel.Range c1z = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart - 1, columnStart];
                Microsoft.Office.Interop.Excel.Range c2z = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
                Microsoft.Office.Interop.Excel.Range rangez = oSheet.get_Range(c1z, c2z);
                rangez.AutoFilter(1, Type.Missing, Microsoft.Office.Interop.Excel.XlAutoFilterOperator.xlAnd, Type.Missing, true);
                // Font tổng thể
                Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];
                Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);
                c4.RowHeight = 50;
                //oSheet.get_Range(c3, c4).Font.Name = "Times New Roman";
                //oSheet.get_Range(c3, c4).Font.Size = 12;
                // Căn giữa cột STT
                Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
                Microsoft.Office.Interop.Excel.Range c3a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
                Microsoft.Office.Interop.Excel.Range c4a = oSheet.get_Range(c1a, c3a);
                oSheet.get_Range(c3a, c4a).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3a, c4a).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3a, c4a).Font.Name = "Times New Roman";
                oSheet.get_Range(c3a, c4a).Font.Size = 12;
                // Căn giữa Ngày
                Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
                Microsoft.Office.Interop.Excel.Range c3b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
                Microsoft.Office.Interop.Excel.Range c4b = oSheet.get_Range(c1b, c3b);
                oSheet.get_Range(c3b, c4b).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3b, c4b).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3b, c4b).Font.Name = "Times New Roman";
                oSheet.get_Range(c3b, c4b).Font.Size = 12;
                // Căn trái cột Số Ký Hiệu A
                Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
                Microsoft.Office.Interop.Excel.Range c3c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
                Microsoft.Office.Interop.Excel.Range c4c = oSheet.get_Range(c1c, c3c);
                oSheet.get_Range(c3c, c4c).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3c, c4c).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3c, c4c).Font.Name = "Times New Roman";
                oSheet.get_Range(c3c, c4c).Font.Size = 12;
                // Căn trái cột Số Ký Hiệu B
                Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
                Microsoft.Office.Interop.Excel.Range c3d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
                Microsoft.Office.Interop.Excel.Range c4d = oSheet.get_Range(c1d, c3d);
                oSheet.get_Range(c3d, c4d).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3d, c4d).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                oSheet.get_Range(c3d, c4d).Font.Name = "Times New Roman";
                oSheet.get_Range(c3d, c4d).Font.Size = 12;
                // Căn giữa cột Đơn Vị Thảo
                Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
                Microsoft.Office.Interop.Excel.Range c3e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
                Microsoft.Office.Interop.Excel.Range c4e = oSheet.get_Range(c1e, c3e);
                oSheet.get_Range(c3e, c4e).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3e, c4e).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3e, c4e).Font.Name = "Times New Roman";
                oSheet.get_Range(c3e, c4e).Font.Size = 12;
                // Căn giữa cột Loại Văn Bản
                Microsoft.Office.Interop.Excel.Range c1f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 6];
                Microsoft.Office.Interop.Excel.Range c3f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 6];
                Microsoft.Office.Interop.Excel.Range c4f = oSheet.get_Range(c1f, c3f);
                oSheet.get_Range(c3f, c4f).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3f, c4f).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3f, c4f).Font.Name = "Times New Roman";
                oSheet.get_Range(c3f, c4f).Font.Size = 12;
                // Nội Dung
                Microsoft.Office.Interop.Excel.Range c1g = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 7];
                Microsoft.Office.Interop.Excel.Range c3g = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 7];
                Microsoft.Office.Interop.Excel.Range c4g = oSheet.get_Range(c1g, c3g);
                oSheet.get_Range(c3g, c4g).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3g, c4g).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                oSheet.get_Range(c3g, c4g).Font.Name = "Times New Roman";
                oSheet.get_Range(c3g, c4g).Font.Size = 12;
                oSheet.get_Range(c3g, c4g).ShrinkToFit = true;
                oSheet.get_Range(c3g, c4g).WrapText = true;
                //Edit phần đầu
                Microsoft.Office.Interop.Excel.Range head8 = oSheet.get_Range("A8", "H8");
                head8.MergeCells = true;
                head8.Value2 = "Từ số: " + TuSo + "    đến số: " + DenSo;
                head8.Font.Bold = true;
                head8.Font.Name = "Times New Roman";
                head8.Font.Size = "18";
                head8.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }
            catch (Exception)
            {
                MessageBox.Show("Ký hiệu văn bản sai: " + dt.Rows[r]["SoKyHieuVB"].ToString());
            }

        }

        private void dgvDSVanThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chkCongVanDen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCongVanDen.Checked)
                chkDonThuDen.Checked = false;
            LoadDSVanThuDiFilter();
        }

        private void chkDonThuDen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDonThuDen.Checked)
                chkCongVanDen.Checked = false;
            LoadDSVanThuDiFilter();
        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDSVanThuDiFilter();
        }

        private void btnXuatFileExcel_Click(object sender, EventArgs e)
        {
            //ExportToExcel(((DataTable)vanthudis.DataSource).DefaultView.ToTable(), "Danh sách văn thư đi", "DANH SÁCH VĂN THƯ ĐI");
            ExportToExcelTongHop(((DataTable)vanthudis.DataSource).DefaultView.ToTable());
            DataTable temp = ((DataTable)vanthudis.DataSource);
            Microsoft.Office.Interop.Excel.Worksheet oSheetTCHC = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(2);
            Microsoft.Office.Interop.Excel.Worksheet oSheetKTTC = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(3);
            Microsoft.Office.Interop.Excel.Worksheet oSheetKHVTTH = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(4);
            Microsoft.Office.Interop.Excel.Worksheet oSheetKTCN = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(5);
            Microsoft.Office.Interop.Excel.Worksheet oSheetKTKS = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(6);
            Microsoft.Office.Interop.Excel.Worksheet oSheetQLDA = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(7);
            Microsoft.Office.Interop.Excel.Worksheet oSheetQLĐHN = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(8);
            Microsoft.Office.Interop.Excel.Worksheet oSheetĐTT = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(9);
            Microsoft.Office.Interop.Excel.Worksheet oSheetTCTB = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(10);
            Microsoft.Office.Interop.Excel.Worksheet oSheetTCXL = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(11);
            Microsoft.Office.Interop.Excel.Worksheet oSheetGNKDT = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(12);
            Microsoft.Office.Interop.Excel.Worksheet oSheetCNTT = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(13);
            Microsoft.Office.Interop.Excel.Worksheet oSheetTGV = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(14);
            DataTable[] a = new DataTable[13];
            for (int i = 0; i < 13; i++)
            {
                a[i] = new DataTable();
                foreach (DataColumn item in temp.Columns)
                {
                    a[i].Columns.Add(new DataColumn(item.ColumnName, item.DataType));
                }

            }

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = temp.Rows[i];

                if (dr["SoKyHieuVB"].ToString().Contains("TCHC"))
                    a[0].ImportRow(dr);
                else
                    if (dr["SoKyHieuVB"].ToString().Contains("KTTC"))
                        a[1].ImportRow(dr);
                    else
                        if (dr["SoKyHieuVB"].ToString().Contains("KHVTTH"))
                            a[2].ImportRow(dr);
                        else
                            if (dr["SoKyHieuVB"].ToString().Contains("KTCN"))
                                a[3].ImportRow(dr);
                            else
                                if (dr["SoKyHieuVB"].ToString().Contains("KTKS"))
                                    a[4].ImportRow(dr);
                                else
                                    if (dr["SoKyHieuVB"].ToString().Contains("QLDA"))
                                        a[5].ImportRow(dr);
                                    else
                                        if (dr["SoKyHieuVB"].ToString().Contains("QLĐHN"))
                                            a[6].ImportRow(dr);
                                        else
                                            if (dr["SoKyHieuVB"].ToString().Contains("ĐTT"))
                                                a[7].ImportRow(dr);
                                            else
                                                if (dr["SoKyHieuVB"].ToString().Contains("TCTB"))
                                                    a[8].ImportRow(dr);
                                                else
                                                    if (dr["SoKyHieuVB"].ToString().Contains("TCXL"))
                                                        a[9].ImportRow(dr);
                                                    else
                                                        if (dr["SoKyHieuVB"].ToString().Contains("GNKDT"))
                                                            a[10].ImportRow(dr);
                                                        else
                                                            if (dr["SoKyHieuVB"].ToString().Contains("CNTT"))
                                                                a[11].ImportRow(dr);
                                                            else
                                                                if (dr["SoKyHieuVB"].ToString().Contains("TGV"))
                                                                    a[12].ImportRow(dr);
            }
            for (int i = 0; i < 13; i++)
            {
                switch (i)
                {
                    case 0:
                        ExportToExcelChiTiet(a[i], oSheetTCHC, "TCHC");
                        break;
                    case 1:
                        ExportToExcelChiTiet(a[i], oSheetKTTC, "KTTC");
                        break;
                    case 2:
                        ExportToExcelChiTiet(a[i], oSheetKHVTTH, "KHVTTH");
                        break;
                    case 3:
                        ExportToExcelChiTiet(a[i], oSheetKTCN, "KTCN");
                        break;
                    case 4:
                        ExportToExcelChiTiet(a[i], oSheetKTKS, "KTKS");
                        break;
                    case 5:
                        ExportToExcelChiTiet(a[i], oSheetQLDA, "QLDA");
                        break;
                    case 6:
                        ExportToExcelChiTiet(a[i], oSheetQLĐHN, "QLĐHN");
                        break;
                    case 7:
                        ExportToExcelChiTiet(a[i], oSheetĐTT, "ĐTT");
                        break;
                    case 8:
                        ExportToExcelChiTiet(a[i], oSheetTCTB, "TCTB");
                        break;
                    case 9:
                        ExportToExcelChiTiet(a[i], oSheetTCXL, "TCXL");
                        break;
                    case 10:
                        ExportToExcelChiTiet(a[i], oSheetGNKDT, "GNKDT");
                        break;
                    case 11:
                        ExportToExcelChiTiet(a[i], oSheetCNTT, "CNTT");
                        break;
                    case 12:
                        ExportToExcelChiTiet(a[i], oSheetTGV, "TGV");
                        break;
                    default:
                        break;
                }
            }
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (chkTimeTimKiem.Checked)
                if (dateDenNgay.Value.Date >= dateTuNgay.Value.Date)
                {
                    _TuNgay = dateTuNgay.Value.Date.ToString("dd/MM/yyyy");
                    _DenNgay = dateDenNgay.Value.Date.ToString("dd/MM/yyyy");
                    vanthudis.DataSource = _CDataQLVanThuDi.LoadDSVanThuDiDateToDate(dateTuNgay.Value.Date.ToString("yyyy-MM-dd"), dateDenNgay.Value.Date.ToString("yyyy-MM-dd"));
                }
                else
                    MessageBox.Show("Đến Ngày phải lớn hơn Từ Ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void chkTimeTimKiem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTimeTimKiem.Checked)
            {
                dateTuNgay.Enabled = true;
                dateDenNgay.Enabled = true;
            }
            else
            {
                dateTuNgay.Value = DateTime.Now;
                dateDenNgay.Value = DateTime.Now;
                dateTuNgay.Enabled = false;
                dateDenNgay.Enabled = false;
                vanthudis.DataSource = _CDataQLVanThuDi.LoadDSVanThuDi();
            }
        }

        private void cmbPhongBanDoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string KeyWord = "";
            switch (cmbPhongBanDoi.SelectedIndex)
            {
                case 1:
                    KeyWord = "TCHC";
                    break;
                case 2:
                    KeyWord = "KTTC";
                    break;
                case 3:
                    KeyWord = "KHVTTH";
                    break;
                case 4:
                    KeyWord = "KTCN";
                    break;
                case 5:
                    KeyWord = "KTKS";
                    break;
                case 6:
                    KeyWord = "QLDA";
                    break;
                case 7:
                    KeyWord = "QLĐHN";
                    break;
                case 8:
                    KeyWord = "ĐTT";
                    break;
                case 9:
                    KeyWord = "TCTB";
                    break;
                case 10:
                    KeyWord = "TCXL";
                    break;
                case 11:
                    KeyWord = "GNKDT";
                    break;
                case 12:
                    KeyWord = "CNTT";
                    break;
                case 13:
                    KeyWord = "TGV";
                    break;
                case 14:
                    KeyWord = "-QLDA";
                    break;
                default:
                    KeyWord = "";
                    break;
            }
            string expression;
            if (KeyWord == "-QLDA")
                expression = String.Format("(SoKyHieuVB not like '%QLDA')");
            else
                expression = String.Format("(SoKyHieuVB like '%{0}%')", KeyWord);
            vanthudis.Filter = expression;
        }



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLVanThuDen.DAL;

namespace QLVanThuDen
{
    public partial class FormMain : Form
    {
        CDataQLVanThuDen _CDataQLVanThuDen = new CDataQLVanThuDen();
        BindingSource vanthus = new BindingSource();
        DataTable dt = new DataTable();
        string _TuNgay = "";
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
            vanthus.DataSource = _CDataQLVanThuDen.LoadDSVanThuDen();
            dgvDSVanThuDen.DataSource = vanthus;
        }

        private void LoadDSVanThuFilter()
        {
            string expression = String.Format("(NgayDen like '%{0}%' or SoDen like '%{0}%' or TacGiaVB like '%{0}%' or SoKyHieuVB like '%{0}%' or LoaiTrichYeuNoiDung like '%{0}%' or NguoiNhan like '%{0}%')", txtNoiDungTimKiem.Text.Trim());
            if (cmbPhanLoai.SelectedIndex == 0)
                expression = "TacGiaVB like '%%' and "+expression;
            else
                if (cmbPhanLoai.SelectedIndex == 1)
                    expression = "(TacGiaVB like 'UBND%' or TacGiaVB like '%TP.HCM' or TacGiaVB like '%Q.TB%' or TacGiaVB like '%Tân Bình%' or TacGiaVB like '%Q.TP%' or TacGiaVB like '%Tân Phú%') and "+expression;
                else
                    if (cmbPhanLoai.SelectedIndex == 2)
                        expression = "(TacGiaVB like '%TCTCNSG%' or SoKyHieuVB like '%GTTN%')";
                    else
                        if (cmbPhanLoai.SelectedIndex == 3)
                            expression = "(TacGiaVB not like 'UBND%' and TacGiaVB not like '%TP.HCM' and TacGiaVB not like '%Q.TB%' and TacGiaVB not like '%Tân Bình%' and TacGiaVB not like '%Q.TP%' and TacGiaVB not like '%Tân Phú%' and TacGiaVB not like '%TCTCNSG%' and SoKyHieuVB not like '%GTTN%') and "+expression;
            if (chkCongVanDen.Checked)
                expression = "LoaiVBGID=3 and " + expression;
            else
                if (chkDonThuDen.Checked)
                    expression = "LoaiVBGID=7 and " + expression;
            vanthus.Filter = expression;
        }

        private void ExportToExcelMucLuc()
        {
            Microsoft.Office.Interop.Excel.Worksheet oSheetMucLuc;

            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            //khai báo số lượng sheet
            oExcel.Application.SheetsInNewWorkbook = 5;
            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheetMucLuc = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheetMucLuc.Name = "Mục Lục";

            Microsoft.Office.Interop.Excel.Range head1 = oSheetMucLuc.get_Range("A3", "I3");
            head1.MergeCells = true;
            head1.Value2 = "MỤC LỤC VĂN BẢN ĐẾN";
            head1.Font.Name = "Times New Roman";
            head1.Font.Size = "24";
            head1.Font.Bold = true;
            head1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ///
            Microsoft.Office.Interop.Excel.Range head2a = oSheetMucLuc.get_Range("B5", "B5");
            head2a.Value2 = "1/";
            head2a.Font.Name = "Times New Roman";
            head2a.Font.Size = "20";
            head2a.Font.Bold = true;
            head2a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head2b = oSheetMucLuc.get_Range("C5", "I5");
            head2b.MergeCells = true;
            head2b.Value2 = "BẢNG TỔNG HỢP";
            head2b.Font.Name = "Times New Roman";
            head2b.Font.Size = "20";
            head2b.Font.Bold = true;
            //head2b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ///
            Microsoft.Office.Interop.Excel.Range head3a = oSheetMucLuc.get_Range("B6", "B6");
            head3a.Value2 = "2/";
            head3a.Font.Name = "Times New Roman";
            head3a.Font.Size = "20";
            head3a.Font.Bold = true;
            head3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head3b = oSheetMucLuc.get_Range("C6", "I6");
            head3b.MergeCells = true;
            head3b.Value2 = "THÀNH PHỐ, QUẬN";
            head3b.Font.Name = "Times New Roman";
            head3b.Font.Size = "20";
            head3b.Font.Bold = true;
            //head3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ///
            Microsoft.Office.Interop.Excel.Range head4a = oSheetMucLuc.get_Range("B7", "B7");
            head4a.Value2 = "3/";
            head4a.Font.Name = "Times New Roman";
            head4a.Font.Size = "20";
            head4a.Font.Bold = true;
            head4a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head4b = oSheetMucLuc.get_Range("C7", "R7");
            head4b.MergeCells = true;
            head4b.Value2 = "TỔNG CÔNG TY CẤP NƯỚC SÀI GÒN-TNHH MTV";
            head4b.Font.Name = "Times New Roman";
            head4b.Font.Size = "20";
            head4b.Font.Bold = true;
            //head4b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ///
            Microsoft.Office.Interop.Excel.Range head5a = oSheetMucLuc.get_Range("B8", "B8");
            head5a.Value2 = "4/";
            head5a.Font.Name = "Times New Roman";
            head5a.Font.Size = "20";
            head5a.Font.Bold = true;
            head5a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head5b = oSheetMucLuc.get_Range("C8", "R8");
            head5b.MergeCells = true;
            head5b.Value2 = "CÁC CÔNG TY, CN TÂN HÒA, CỤC KHU, TRUNG TÂM, NGÂN HÀNG, VEI...";
            head5b.Font.Name = "Times New Roman";
            head5b.Font.Size = "20";
            head5b.Font.Bold = true;
            //head5b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        private void ExportToExcel(DataTable dt, string loaiVB, string SheetName)
        {
            int r = 0;
            //float TuSo = 100000;
            //float DenSo = 0;
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
                oExcel.Application.SheetsInNewWorkbook = 1;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;
                oSheetTongHop = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
                oSheetTongHop.Name = SheetName;

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
                head3.Value2 = "CÔNG TY CP CẤP NƯỚC TÂN HÒA";
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
                head6.Value2 = "DANH MỤC " + loaiVB;
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
                cl2.Value2 = "Ngày Đến";
                cl2.ColumnWidth = 11;
                cl2.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl3 = oSheetTongHop.get_Range("C10", "C10");
                cl3.Value2 = "Số Đến";
                cl3.ColumnWidth = 10;
                cl3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                //Microsoft.Office.Interop.Excel.Range cl3a = oSheetTongHop.get_Range("C11", "C11");
                //cl3a.ColumnWidth = 6;

                //Microsoft.Office.Interop.Excel.Range cl3b = oSheetTongHop.get_Range("D11", "D11");
                //cl3b.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheetTongHop.get_Range("D10", "D10");
                cl4.Value2 = "Nơi Gửi";
                cl4.ColumnWidth = 30;
                cl4.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl5 = oSheetTongHop.get_Range("E10", "E10");
                cl5.Value2 = "Số Ký Hiệu Văn Bản";
                cl5.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                cl5.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range cl6 = oSheetTongHop.get_Range("F10", "F10");
                cl6.Value2 = "Ngày";
                cl6.ColumnWidth = 11;
                cl6.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl7 = oSheetTongHop.get_Range("G10", "G10");
                cl7.Value2 = "Loại";
                cl7.ColumnWidth = 5;
                cl7.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl8 = oSheetTongHop.get_Range("H10", "H10");
                cl8.Value2 = "Trích Yếu Nội Dung";
                cl8.ColumnWidth = 80;
                cl8.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl9 = oSheetTongHop.get_Range("I10", "I10");
                cl9.Value2 = "Ghi Chú";
                cl9.ColumnWidth = 20;
                cl9.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range rowHead = oSheetTongHop.get_Range("A10", "I10");
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
                    arr[r, 1] = dr["NgayDen"];
                    //if (int.Parse(dr["SoDen"].ToString().Replace("ĐT", "")) < TuSo)
                    //    TuSo = int.Parse(dr["SoDen"].ToString().Replace("ĐT", ""));
                    //if (int.Parse(dr["SoDen"].ToString().Replace("ĐT", "")) > DenSo)
                    //    DenSo = int.Parse(dr["SoDen"].ToString().Replace("ĐT", ""));
                    arr[r, 2] = dr["SoDen"];
                    arr[r, 3] = dr["TacGiaVB"];
                    arr[r, 4] = dr["SoKyHieuVB"];
                    arr[r, 5] = dr["NgayThangVB"];
                    arr[r, 6] = dr["LoaiVB"];
                    arr[r, 7] = dr["LoaiTrichYeuNoiDung"];
                }

                //Thiết lập vùng điền dữ liệu
                int rowStart = 12;
                int columnStart = 1;

                int rowEnd = rowStart + dt.Rows.Count - 1;
                int columnEnd = 9;

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
                // Căn giữ Số Đến
                Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 3];
                Microsoft.Office.Interop.Excel.Range c3c = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 3];
                Microsoft.Office.Interop.Excel.Range c4c = oSheetTongHop.get_Range(c1c, c3c);
                oSheetTongHop.get_Range(c3c, c4c).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3c, c4c).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3c, c4c).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3c, c4c).Font.Size = 12;
                // Căn trái Nơi Gửi
                Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 4];
                Microsoft.Office.Interop.Excel.Range c3d = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 4];
                Microsoft.Office.Interop.Excel.Range c4d = oSheetTongHop.get_Range(c1d, c3d);
                oSheetTongHop.get_Range(c3d, c4d).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3d, c4d).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                oSheetTongHop.get_Range(c3d, c4d).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3d, c4d).Font.Size = 12;
                oSheetTongHop.get_Range(c3d, c4d).ShrinkToFit = true;
                oSheetTongHop.get_Range(c3d, c4d).WrapText = true;
                // Căn trái Ký Hiệu Gốc
                Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 5];
                Microsoft.Office.Interop.Excel.Range c3e = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 5];
                Microsoft.Office.Interop.Excel.Range c4e = oSheetTongHop.get_Range(c1e, c3e);
                oSheetTongHop.get_Range(c3e, c4e).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3e, c4e).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                oSheetTongHop.get_Range(c3e, c4e).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3e, c4e).Font.Size = 12;
                // Căn giữa Ngày Văn Bản
                Microsoft.Office.Interop.Excel.Range c1f = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 6];
                Microsoft.Office.Interop.Excel.Range c3f = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 6];
                Microsoft.Office.Interop.Excel.Range c4f = oSheetTongHop.get_Range(c1f, c3f);
                oSheetTongHop.get_Range(c3f, c4f).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3f, c4f).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3f, c4f).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3f, c4f).Font.Size = 12;
                // Căn giữa Loại
                Microsoft.Office.Interop.Excel.Range c1k = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 7];
                Microsoft.Office.Interop.Excel.Range c3k = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 7];
                Microsoft.Office.Interop.Excel.Range c4k = oSheetTongHop.get_Range(c1f, c3f);
                oSheetTongHop.get_Range(c3k, c4k).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3k, c4k).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3k, c4k).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3k, c4k).Font.Size = 12;
                // Nội Dung
                Microsoft.Office.Interop.Excel.Range c1g = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 8];
                Microsoft.Office.Interop.Excel.Range c3g = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 8];
                Microsoft.Office.Interop.Excel.Range c4g = oSheetTongHop.get_Range(c1g, c3g);
                oSheetTongHop.get_Range(c3g, c4g).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3g, c4g).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                oSheetTongHop.get_Range(c3g, c4g).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3g, c4g).Font.Size = 12;
                oSheetTongHop.get_Range(c3g, c4g).ShrinkToFit = true;
                oSheetTongHop.get_Range(c3g, c4g).WrapText = true;
                //Edit phần đầu
                //Microsoft.Office.Interop.Excel.Range head8 = oSheetTongHop.get_Range("A8", "H8");
                //head8.MergeCells = true;
                //head8.Value2 = "Từ số: " + TuSo + "    đến số: " + DenSo;
                //head8.Font.Bold = true;
                //head8.Font.Name = "Times New Roman";
                //head8.Font.Size = "18";
                //head8.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }
            catch (Exception)
            {
                MessageBox.Show("Ký hiệu văn bản sai: " + dt.Rows[r]["SoKyHieuVB"].ToString() + " == " + dt.Rows[r]["SoDen"].ToString());
            }
        }

        private void ExportToExcelTongHop(DataTable dt,string loaiVB)
        {
            int r = 0;
            //float TuSo = 100000;
            //float DenSo = 0;
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
                oExcel.Application.SheetsInNewWorkbook = 4;
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
                head3.Value2 = "CÔNG TY CP CẤP NƯỚC TÂN HÒA";
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
                head6.Value2 = "DANH MỤC " + loaiVB;
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
                cl2.Value2 = "Ngày Đến";
                cl2.ColumnWidth = 11;
                cl2.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl3 = oSheetTongHop.get_Range("C10", "C10");
                cl3.Value2 = "Số Đến";
                cl3.ColumnWidth = 10;
                cl3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                //Microsoft.Office.Interop.Excel.Range cl3a = oSheetTongHop.get_Range("C11", "C11");
                //cl3a.ColumnWidth = 6;

                //Microsoft.Office.Interop.Excel.Range cl3b = oSheetTongHop.get_Range("D11", "D11");
                //cl3b.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheetTongHop.get_Range("D10", "D10");
                cl4.Value2 = "Nơi Gửi";
                cl4.ColumnWidth = 30;
                cl4.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl5 = oSheetTongHop.get_Range("E10", "E10");
                cl5.Value2 = "Số Ký Hiệu Văn Bản";
                cl5.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                cl5.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range cl6 = oSheetTongHop.get_Range("F10", "F10");
                cl6.Value2 = "Ngày";
                cl6.ColumnWidth = 11;
                cl6.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl7 = oSheetTongHop.get_Range("G10", "G10");
                cl7.Value2 = "Loại";
                cl7.ColumnWidth = 5;
                cl7.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl8 = oSheetTongHop.get_Range("H10", "H10");
                cl8.Value2 = "Trích Yếu Nội Dung";
                cl8.ColumnWidth = 80;
                cl8.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl9 = oSheetTongHop.get_Range("I10", "I10");
                cl9.Value2 = "Ghi Chú";
                cl9.ColumnWidth = 20;
                cl9.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range rowHead = oSheetTongHop.get_Range("A10", "I10");
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
                    arr[r, 1] = dr["NgayDen"];
                    //if (int.Parse(dr["SoDen"].ToString().Replace("ĐT", "")) < TuSo)
                    //    TuSo = int.Parse(dr["SoDen"].ToString().Replace("ĐT", ""));
                    //if (int.Parse(dr["SoDen"].ToString().Replace("ĐT", "")) > DenSo)
                    //    DenSo = int.Parse(dr["SoDen"].ToString().Replace("ĐT", ""));
                    arr[r, 2] = dr["SoDen"];
                    arr[r, 3] = dr["TacGiaVB"];
                    arr[r, 4] = dr["SoKyHieuVB"];
                    arr[r, 5] = dr["NgayThangVB"];
                    arr[r, 6] = dr["LoaiVB"];
                    arr[r, 7] = dr["LoaiTrichYeuNoiDung"];
                }

                //Thiết lập vùng điền dữ liệu
                int rowStart = 12;
                int columnStart = 1;

                int rowEnd = rowStart + dt.Rows.Count - 1;
                int columnEnd = 9;

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
                // Căn giữ Số Đến
                Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 3];
                Microsoft.Office.Interop.Excel.Range c3c = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 3];
                Microsoft.Office.Interop.Excel.Range c4c = oSheetTongHop.get_Range(c1c, c3c);
                oSheetTongHop.get_Range(c3c, c4c).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3c, c4c).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3c, c4c).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3c, c4c).Font.Size = 12;
                // Căn trái Nơi Gửi
                Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 4];
                Microsoft.Office.Interop.Excel.Range c3d = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 4];
                Microsoft.Office.Interop.Excel.Range c4d = oSheetTongHop.get_Range(c1d, c3d);
                oSheetTongHop.get_Range(c3d, c4d).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3d, c4d).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                oSheetTongHop.get_Range(c3d, c4d).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3d, c4d).Font.Size = 12;
                oSheetTongHop.get_Range(c3d, c4d).ShrinkToFit = true;
                oSheetTongHop.get_Range(c3d, c4d).WrapText = true;
                // Căn trái Ký Hiệu Gốc
                Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 5];
                Microsoft.Office.Interop.Excel.Range c3e = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 5];
                Microsoft.Office.Interop.Excel.Range c4e = oSheetTongHop.get_Range(c1e, c3e);
                oSheetTongHop.get_Range(c3e, c4e).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3e, c4e).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                oSheetTongHop.get_Range(c3e, c4e).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3e, c4e).Font.Size = 12;
                // Căn giữa Ngày Văn Bản
                Microsoft.Office.Interop.Excel.Range c1f = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 6];
                Microsoft.Office.Interop.Excel.Range c3f = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 6];
                Microsoft.Office.Interop.Excel.Range c4f = oSheetTongHop.get_Range(c1f, c3f);
                oSheetTongHop.get_Range(c3f, c4f).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3f, c4f).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3f, c4f).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3f, c4f).Font.Size = 12;
                // Căn giữa Loại
                Microsoft.Office.Interop.Excel.Range c1k = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 7];
                Microsoft.Office.Interop.Excel.Range c3k = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 7];
                Microsoft.Office.Interop.Excel.Range c4k = oSheetTongHop.get_Range(c1f, c3f);
                oSheetTongHop.get_Range(c3k, c4k).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3k, c4k).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3k, c4k).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3k, c4k).Font.Size = 12;
                // Nội Dung
                Microsoft.Office.Interop.Excel.Range c1g = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowStart, 8];
                Microsoft.Office.Interop.Excel.Range c3g = (Microsoft.Office.Interop.Excel.Range)oSheetTongHop.Cells[rowEnd, 8];
                Microsoft.Office.Interop.Excel.Range c4g = oSheetTongHop.get_Range(c1g, c3g);
                oSheetTongHop.get_Range(c3g, c4g).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheetTongHop.get_Range(c3g, c4g).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                oSheetTongHop.get_Range(c3g, c4g).Font.Name = "Times New Roman";
                oSheetTongHop.get_Range(c3g, c4g).Font.Size = 12;
                oSheetTongHop.get_Range(c3g, c4g).ShrinkToFit = true;
                oSheetTongHop.get_Range(c3g, c4g).WrapText = true;
                //Edit phần đầu
                //Microsoft.Office.Interop.Excel.Range head8 = oSheetTongHop.get_Range("A8", "H8");
                //head8.MergeCells = true;
                //head8.Value2 = "Từ số: " + TuSo + "    đến số: " + DenSo;
                //head8.Font.Bold = true;
                //head8.Font.Name = "Times New Roman";
                //head8.Font.Size = "18";
                //head8.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }
            catch (Exception)
            {
                MessageBox.Show("Ký hiệu văn bản sai: " + dt.Rows[r]["SoKyHieuVB"].ToString() + " == " + dt.Rows[r]["SoDen"].ToString());
            }

        }

        private void ExportToExcelChiTiet(DataTable dt, string loaiVB, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName)
        {
            int r = 0;
            //float TuSo = 100000;
            //float DenSo = 0;
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
                head3.Value2 = "CÔNG TY CP CẤP NƯỚC TÂN HÒA";
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
                head6.Value2 = "DANH MỤC " + loaiVB;
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
                cl2.Value2 = "Ngày Đến";
                cl2.ColumnWidth = 11;
                cl2.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C10", "C10");
                cl3.Value2 = "Số Đến";
                cl3.ColumnWidth = 10;
                cl3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                //Microsoft.Office.Interop.Excel.Range cl3a = oSheetTongHop.get_Range("C11", "C11");
                //cl3a.ColumnWidth = 6;

                //Microsoft.Office.Interop.Excel.Range cl3b = oSheetTongHop.get_Range("D11", "D11");
                //cl3b.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D10", "D10");
                cl4.Value2 = "Nơi Gửi";
                cl4.ColumnWidth = 30;
                cl4.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E10", "E10");
                cl5.Value2 = "Số Ký Hiệu Văn Bản";
                cl5.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                cl5.ColumnWidth = 20;

                //Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F10", "F10");
                //cl6.Value2 = "Ngày";
                //cl6.ColumnWidth = 11;
                //cl6.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("F10", "F10");
                cl7.Value2 = "Loại";
                cl7.ColumnWidth = 10;
                cl7.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("G10", "G10");
                cl8.Value2 = "Trích Yếu Nội Dung";
                cl8.ColumnWidth = 80;
                cl8.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("H10", "H10");
                cl9.Value2 = "Ghi Chú";
                cl9.ColumnWidth = 20;
                cl9.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

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
                    arr[r, 1] = dr["NgayDen"];
                    //if (int.Parse(dr["SoDen"].ToString().Replace("ĐT", "")) < TuSo)
                    //    TuSo = int.Parse(dr["SoDen"].ToString().Replace("ĐT", ""));
                    //if (int.Parse(dr["SoDen"].ToString().Replace("ĐT", "")) > DenSo)
                    //    DenSo = int.Parse(dr["SoDen"].ToString().Replace("ĐT", ""));
                    arr[r, 2] = dr["SoDen"];
                    arr[r, 3] = dr["TacGiaVB"];
                    arr[r, 4] = dr["SoKyHieuVB"];
                    //arr[r, 5] = dr["NgayThangVB"];
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
                // Tạo filter
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
                // Căn giữ Số Đến
                Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
                Microsoft.Office.Interop.Excel.Range c3c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
                Microsoft.Office.Interop.Excel.Range c4c = oSheet.get_Range(c1c, c3c);
                oSheet.get_Range(c3c, c4c).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3c, c4c).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3c, c4c).Font.Name = "Times New Roman";
                oSheet.get_Range(c3c, c4c).Font.Size = 12;
                // Căn trái Nơi Gửi
                Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
                Microsoft.Office.Interop.Excel.Range c3d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
                Microsoft.Office.Interop.Excel.Range c4d = oSheet.get_Range(c1d, c3d);
                oSheet.get_Range(c3d, c4d).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3d, c4d).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                oSheet.get_Range(c3d, c4d).Font.Name = "Times New Roman";
                oSheet.get_Range(c3d, c4d).Font.Size = 12;
                oSheet.get_Range(c3d, c4d).ShrinkToFit = true;
                oSheet.get_Range(c3d, c4d).WrapText = true;
                // Căn trái Ký Hiệu Gốc
                Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
                Microsoft.Office.Interop.Excel.Range c3e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
                Microsoft.Office.Interop.Excel.Range c4e = oSheet.get_Range(c1e, c3e);
                oSheet.get_Range(c3e, c4e).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3e, c4e).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                oSheet.get_Range(c3e, c4e).Font.Name = "Times New Roman";
                oSheet.get_Range(c3e, c4e).Font.Size = 12;
                // Căn giữa Ngày Văn Bản
                //Microsoft.Office.Interop.Excel.Range c1f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 6];
                //Microsoft.Office.Interop.Excel.Range c3f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 6];
                //Microsoft.Office.Interop.Excel.Range c4f = oSheet.get_Range(c1f, c3f);
                //oSheet.get_Range(c3f, c4f).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //oSheet.get_Range(c3f, c4f).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //oSheet.get_Range(c3f, c4f).Font.Name = "Times New Roman";
                //oSheet.get_Range(c3f, c4f).Font.Size = 12;
                // Căn giữa Loại
                Microsoft.Office.Interop.Excel.Range c1k = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 6];
                Microsoft.Office.Interop.Excel.Range c3k = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 6];
                Microsoft.Office.Interop.Excel.Range c4k = oSheet.get_Range(c1k, c3k);
                oSheet.get_Range(c3k, c4k).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3k, c4k).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.get_Range(c3k, c4k).Font.Name = "Times New Roman";
                oSheet.get_Range(c3k, c4k).Font.Size = 12;
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
                //Microsoft.Office.Interop.Excel.Range head8 = oSheetTongHop.get_Range("A8", "H8");
                //head8.MergeCells = true;
                //head8.Value2 = "Từ số: " + TuSo + "    đến số: " + DenSo;
                //head8.Font.Bold = true;
                //head8.Font.Name = "Times New Roman";
                //head8.Font.Size = "18";
                //head8.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }
            catch (Exception)
            {
                MessageBox.Show("Ký hiệu văn bản sai: " + dt.Rows[r]["SoKyHieuVB"].ToString() + " == " + dt.Rows[r]["SoDen"].ToString());
            }

        }

        private void dgvDSVanThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chkCongVanDen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCongVanDen.Checked)
                chkDonThuDen.Checked = false;
            LoadDSVanThuFilter();
        }

        private void chkDonThuDen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDonThuDen.Checked)
                chkCongVanDen.Checked = false;
            LoadDSVanThuFilter();
        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDSVanThuFilter();
        }

        private void btnXuatFileExcel_Click(object sender, EventArgs e)
        {
            //ExportToExcel(((DataTable)vanthus.DataSource).DefaultView.ToTable(), "Danh sách văn thư", "DANH SÁCH VĂN THƯ");
            if (cmbPhanLoai.SelectedIndex == 0)
            {
                if (chkCongVanDen.Checked)
                {
                    //ExportToExcelTongHop(((DataTable)vanthus.DataSource).DefaultView.ToTable(), "CÔNG VĂN ĐẾN");
                    DataTable temp = (((DataTable)vanthus.DataSource).DefaultView.ToTable());
                    
                    DataTable[] a = new DataTable[4];
                    for (int i = 0; i < 4; i++)
                    {
                        a[i] = new DataTable();
                        foreach (DataColumn item in temp.Columns)
                        {
                            a[i].Columns.Add(new DataColumn(item.ColumnName, item.DataType));
                        }
                        DataColumn[] columns = new DataColumn[1];
                        columns[0] = a[i].Columns["SoDen"];
                        a[i].PrimaryKey = columns;
                    }
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        DataRow dr = temp.Rows[i];
                        if (!a[3].Rows.Contains(dr["SoDen"].ToString()))
                            a[3].ImportRow(dr);
                        if (dr["TacGiaVB"].ToString().Contains("UBND") || dr["TacGiaVB"].ToString().Contains("TP.HCM") || dr["TacGiaVB"].ToString().Contains("Q.TB") ||
                            dr["TacGiaVB"].ToString().Contains("Tân Bình") || dr["TacGiaVB"].ToString().Contains("Q.TP") || dr["TacGiaVB"].ToString().Contains("Tân Phú"))
                        {
                            if (!a[0].Rows.Contains(dr["SoDen"].ToString()))
                                a[0].ImportRow(dr);
                        }
                        else
                            if (dr["TacGiaVB"].ToString().Contains("TCTCNSG") || dr["TacGiaVB"].ToString().Contains("GTTN"))
                            {
                                if (!a[1].Rows.Contains(dr["SoDen"].ToString()))
                                    a[1].ImportRow(dr);
                            }
                            else
                            {
                                if (!a[2].Rows.Contains(dr["SoDen"].ToString()))
                                    a[2].ImportRow(dr);
                            }
                    }
                    //ExportToExcelTongHop(a[3], "CÔNG VĂN ĐẾN");
                    ExportToExcelMucLuc();
                    Microsoft.Office.Interop.Excel.Worksheet oSheetTongHop = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(2);
                    Microsoft.Office.Interop.Excel.Worksheet oSheetTPHCM = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(3);
                    Microsoft.Office.Interop.Excel.Worksheet oSheetTongCty = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(4);
                    Microsoft.Office.Interop.Excel.Worksheet oSheetKhac = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(5);
                    for (int i = 0; i < 4; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                ExportToExcelChiTiet(a[i], "CÔNG VĂN ĐẾN", oSheetTPHCM, "TPHCM");
                                break;
                            case 1:
                                ExportToExcelChiTiet(a[i], "CÔNG VĂN ĐẾN", oSheetTongCty, "Tổng Cty");
                                break;
                            case 2:
                                ExportToExcelChiTiet(a[i], "CÔNG VĂN ĐẾN", oSheetKhac, "Khác");
                                break;
                            case 3:
                                ExportToExcelChiTiet(a[i], "CÔNG VĂN ĐẾN", oSheetTongHop, "Tổng Hợp");
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                    if (chkDonThuDen.Checked)
                    {
                        //ExportToExcelTongHop(((DataTable)vanthus.DataSource).DefaultView.ToTable(), "ĐƠN THƯ ĐẾN");
                        DataTable temp = (((DataTable)vanthus.DataSource).DefaultView.ToTable());
                        
                        DataTable[] a = new DataTable[4];
                        for (int i = 0; i < 4; i++)
                        {
                            a[i] = new DataTable();
                            foreach (DataColumn item in temp.Columns)
                            {
                                a[i].Columns.Add(new DataColumn(item.ColumnName, item.DataType));
                            }
                            DataColumn[] columns = new DataColumn[1];
                            columns[0] = a[i].Columns["SoDen"];
                            a[i].PrimaryKey = columns;
                        }
                        for (int i = 0; i < temp.Rows.Count; i++)
                        {
                            DataRow dr = temp.Rows[i];

                            if (!a[3].Rows.Contains(dr["SoDen"].ToString()))
                                    a[3].ImportRow(dr);

                            if (dr["TacGiaVB"].ToString().Contains("UBND") || dr["TacGiaVB"].ToString().Contains("TP.HCM") || dr["TacGiaVB"].ToString().Contains("Q.TB") ||
                                dr["TacGiaVB"].ToString().Contains("Tân Bình") || dr["TacGiaVB"].ToString().Contains("Q.TP") || dr["TacGiaVB"].ToString().Contains("Tân Phú"))
                            {
                                if (!a[0].Rows.Contains(dr["SoDen"].ToString()))
                                    a[0].ImportRow(dr);
                            }
                            else
                                if (dr["TacGiaVB"].ToString().Contains("TCTCNSG") || dr["TacGiaVB"].ToString().Contains("GTTN"))
                                {
                                    if (!a[1].Rows.Contains(dr["SoDen"].ToString()))
                                        a[1].ImportRow(dr);
                                }
                                else
                                {
                                    if (!a[2].Rows.Contains(dr["SoDen"].ToString()))
                                        a[2].ImportRow(dr);
                                }
                        }
                        //ExportToExcelTongHop(a[3], "ĐƠN THƯ ĐẾN");
                        ExportToExcelMucLuc();
                        Microsoft.Office.Interop.Excel.Worksheet oSheetTongHop = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(2);
                        Microsoft.Office.Interop.Excel.Worksheet oSheetTPHCM = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(3);
                        Microsoft.Office.Interop.Excel.Worksheet oSheetTongCty = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(4);
                        Microsoft.Office.Interop.Excel.Worksheet oSheetKhac = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(5);
                        for (int i = 0; i < 3; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    ExportToExcelChiTiet(a[i], "ĐƠN THƯ ĐẾN", oSheetTPHCM, "TPHCM");
                                    break;
                                case 1:
                                    ExportToExcelChiTiet(a[i], "ĐƠN THƯ ĐẾN", oSheetTongCty, "Tổng Cty");
                                    break;
                                case 2:
                                    ExportToExcelChiTiet(a[i], "ĐƠN THƯ ĐẾN", oSheetKhac, "Khác");
                                    break;
                                case 3:
                                    ExportToExcelChiTiet(a[i], "ĐƠN THƯ ĐẾN", oSheetTongHop, "Tổng Hợp");
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
            }
            else
                if (cmbPhanLoai.SelectedIndex == 1 || cmbPhanLoai.SelectedIndex == 2 || cmbPhanLoai.SelectedIndex == 3)
                {
                    if (chkCongVanDen.Checked)
                    {
                        DataTable dt = ((DataTable)vanthus.DataSource).DefaultView.ToTable();
                        DataTable dtTemp = new DataTable();
                        foreach (DataColumn item in dt.Columns)
                        {
                            dtTemp.Columns.Add(new DataColumn(item.ColumnName, item.DataType));
                        }
                        DataColumn[] columns = new DataColumn[1];
                        columns[0] = dtTemp.Columns["SoDen"];
                        dtTemp.PrimaryKey = columns;
                        foreach (DataRow item in dt.Rows)
                            if (!dtTemp.Rows.Contains(item["SoDen"].ToString()))
                                dtTemp.ImportRow(item);
                        ExportToExcel(dtTemp, "CÔNG VĂN ĐẾN", cmbPhanLoai.SelectedItem.ToString());
                    }
                    else
                        if (chkDonThuDen.Checked)
                        {
                            DataTable dt = ((DataTable)vanthus.DataSource).DefaultView.ToTable();
                            DataTable dtTemp = new DataTable();
                            foreach (DataColumn item in dt.Columns)
                            {
                                dtTemp.Columns.Add(new DataColumn(item.ColumnName, item.DataType));
                            }
                            DataColumn[] columns = new DataColumn[1];
                            columns[0] = dtTemp.Columns["SoDen"];
                            dtTemp.PrimaryKey = columns;
                            foreach (DataRow item in dt.Rows)
                                if (!dtTemp.Rows.Contains(item["SoDen"].ToString()))
                                    dtTemp.ImportRow(item);
                            ExportToExcel(dtTemp, "ĐƠN THƯ ĐẾN", cmbPhanLoai.SelectedItem.ToString());
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
                    vanthus.DataSource = _CDataQLVanThuDen.LoadDSVanThuDenDateToDate(dateTuNgay.Value.Date.ToString("yyyy-MM-dd"), dateDenNgay.Value.Date.ToString("yyyy-MM-dd"));
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
                vanthus.DataSource = _CDataQLVanThuDen.LoadDSVanThuDen();
            }
        }

        private void dgvDSVanThu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                System.Diagnostics.Process.Start(@"\\server_hp380\WorkflowData\" + dgvDSVanThuDen["PathFile", e.RowIndex].Value.ToString());
            }
        }

        private void cmbPhongBanDoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string expression = "";
            if (cmbPhanLoai.SelectedIndex == 0)
                expression = "(TacGiaVB like '%%')";
            else
                if (cmbPhanLoai.SelectedIndex == 1)
                    expression = "(TacGiaVB like 'UBND%' or TacGiaVB like '%TP.HCM' or TacGiaVB like '%Q.TB%' or TacGiaVB like '%Tân Bình%' or TacGiaVB like '%Q.TP%' or TacGiaVB like '%Tân Phú%')";
                else
                    if (cmbPhanLoai.SelectedIndex == 2)
                        expression = "(TacGiaVB like '%TCTCNSG%' or SoKyHieuVB like '%GTTN%')";
                    else
                        if (cmbPhanLoai.SelectedIndex == 3)
                            expression = "(TacGiaVB not like 'UBND%' and TacGiaVB not like '%TP.HCM' and TacGiaVB not like '%Q.TB%' and TacGiaVB not like '%Tân Bình%' and TacGiaVB not like '%Q.TP%' and TacGiaVB not like '%Tân Phú%' and TacGiaVB not like '%TCTCNSG%' and SoKyHieuVB not like '%GTTN%')";
            if (chkCongVanDen.Checked)
                expression = "LoaiVBGID=3 and " + expression;
            else
                if (chkDonThuDen.Checked)
                    expression = "LoaiVBGID=7 and " + expression;
            vanthus.Filter = expression;
        }

        private void dgvDSVanThuDen_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSVanThuDen.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }



    }
}

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
using ThuTien.DAL.Doi;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmBaoCaoChuyenKhoan : Form
    {
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();

        public frmBaoCaoChuyenKhoan()
        {
            InitializeComponent();
        }

        private void frmBaoCaoChuyenKhoan_Load(object sender, EventArgs e)
        {

        }

        private void btnXuatExcelTongHopDangNgan_Click(object sender, EventArgs e)
        {
            if (dateTu.Value<=dateDen.Value)
            {
                List<TT_To> lstTo = _cTo.GetDSHanhThu();
                DataTable[] dtTo = new DataTable[lstTo.Count];

                dtTo[0] = _cHoaDon.GetTongDangNganChuyenKhoanByMaToNgayGiaiTrachs(lstTo[0].MaTo, dateTu.Value, dateDen.Value);
                for (int i = 1; i < lstTo.Count; i++)
                {
                    dtTo[i] = _cHoaDon.GetTongDangNganChuyenKhoanByMaToNgayGiaiTrachs(lstTo[i].MaTo, dateTu.Value, dateDen.Value);
                }

                //Tạo các đối tượng Excel
                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbooks oBooks;
                Microsoft.Office.Interop.Excel.Sheets oSheets;
                Microsoft.Office.Interop.Excel.Workbook oBook;

                //Tạo mới một Excel WorkBook 
                oExcel.Visible = true;
                oExcel.DisplayAlerts = false;
                //khai báo số lượng sheet
                oExcel.Application.SheetsInNewWorkbook = lstTo.Count;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;

                Microsoft.Office.Interop.Excel.Worksheet[] dtoSheet = new Microsoft.Office.Interop.Excel.Worksheet[lstTo.Count];
                for (int i = 0; i < lstTo.Count; i++)
                {
                    dtoSheet[i] = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(i+1);
                    XuatExcel(_cHoaDon.GetTongDangNganChuyenKhoanByMaToNgayGiaiTrachs(lstTo[i].MaTo, dateTu.Value, dateDen.Value), dtoSheet[i], lstTo[i].TenTo, dateDen.Value.Month.ToString() + "/" + dateDen.Value.Year.ToString());
                }
            }
        }

        private void XuatExcel(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName,string Ky)
        {
            oSheet.Name = SheetName;

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "C1");
            head.MergeCells = true;
            head.Value2 = "PHIẾU BÁO CÁO SỐ LIỆU UNC ĐĂNG NGÂN THÁNG \r\n "+Ky+" - TỔ "+SheetName;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.RowHeight = 50;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Ngày";
            cl1.ColumnWidth = 35;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Tổng HĐ";
            cl2.ColumnWidth = 35;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Tổng Cộng";
            cl3.ColumnWidth = 35;

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
            oSheet.get_Range(c2c, c3c).NumberFormat = "@";

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
    }
}

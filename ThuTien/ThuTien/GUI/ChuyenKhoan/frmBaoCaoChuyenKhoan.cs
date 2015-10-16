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
using ThuTien.DAL.ChuyenKhoan;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmBaoCaoChuyenKhoan : Form
    {
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();
        CBangKe _cBangKe = new CBangKe();
        CTienDu _cTienDu = new CTienDu();

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
                oExcel.Application.SheetsInNewWorkbook = lstTo.Count;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;

                Microsoft.Office.Interop.Excel.Worksheet[] dtoSheet = new Microsoft.Office.Interop.Excel.Worksheet[lstTo.Count];
                for (int i = 0; i < lstTo.Count; i++)
                {
                    dtoSheet[i] = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(i+1);
                    XuatExcelTongHopDangNgan(_cHoaDon.GetTongDangNganChuyenKhoanByMaToNgayGiaiTrachs(lstTo[i].MaTo, dateTu.Value, dateDen.Value), dtoSheet[i], lstTo[i].TenTo, dateDen.Value.Month.ToString() + "/" + dateDen.Value.Year.ToString());
                }
            }
        }

        private void XuatExcelTongHopDangNgan(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName, string Ky)
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

        private void btnXuatExcelBangKe_Click(object sender, EventArgs e)
        {
            DataTable dtBK = _cBangKe.GetDS_BangKe(dateGiaiTrach.Value);
            DataTable dtDN = _cHoaDon.GetDSDangNganChuyenKhoan_BangKe(dateGiaiTrach.Value);
            
            DataTable dt = new DataTable();
            dt.Columns.Add("MaBK", typeof(int));
            dt.Columns.Add("DanhBo", typeof(string));
            dt.Columns.Add("SoTien", typeof(int));
            dt.Columns.Add("CreateDate", typeof(DateTime));
            dt.Columns.Add("NganHang", typeof(string));
            dt.Columns.Add("Ky", typeof(int));
            dt.Columns.Add("HoTen", typeof(string));
            dt.Columns.Add("GiaBan", typeof(int));
            dt.Columns.Add("ThueGTGT", typeof(int));
            dt.Columns.Add("PhiBVMT", typeof(int));
            dt.Columns.Add("TongCong", typeof(int));
            dt.Columns.Add("GiaBieu", typeof(int));

            foreach (DataRow item in dtDN.Rows)
            {
                DataRow[] drBK = dtBK.Select("DanhBo like '" + item["DanhBo"].ToString() + "'");
                DataRow dr = dt.NewRow();
                if (drBK.Count() > 0)
                {
                    dr["MaBK"] = drBK[0]["MaBK"];
                    dr["SoTien"] = drBK[0]["SoTien"];
                    dr["CreateDate"] = drBK[0]["CreateDate"];
                    dr["NganHang"] = drBK[0]["TenNH"];
                }
                dr["Ky"] = item["Ky"];
                dr["DanhBo"] = item["DanhBo"];
                dr["HoTen"] = item["HoTen"];
                dr["GiaBan"] = item["GiaBan"];
                dr["ThueGTGT"] = item["ThueGTGT"];
                dr["PhiBVMT"] = item["PhiBVMT"];
                dr["TongCong"] = item["TongCong"];
                dr["GiaBieu"] = item["GiaBieu"];
                dt.Rows.Add(dr);
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

            XuatExcelBangKe(dt, oSheet, "BẢNG KÊ", dateGiaiTrach.Value.ToString("dd/MM/yyyy"),_cTienDu.GetTongTienTon(dateGiaiTrach.Value));
        }

        private void XuatExcelBangKe(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName, string NgayGiaiTrach,long TonDau)
        {
            oSheet.Name = SheetName;

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "M1");
            head.MergeCells = true;
            head.Value2 = "BẢNG KÊ KHÁCH HÀNG CHUYỂN KHOẢN - GIẢI TRÁCH TIỀN NƯỚC \r\n NGÀY " + NgayGiaiTrach;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.RowHeight = 50;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head2 = oSheet.get_Range("A2", "M2");
            head2.MergeCells = true;
            head2.Value2 = "Tồn đầu ngày: "+TonDau;
            head2.Font.Bold = true;
            head2.Font.Name = "Times New Roman";

            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 5;
            cl1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl1.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "TÊN KHÁCH HÀNG";
            cl2.ColumnWidth = 20;
            cl2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl2.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "DANH BỘ";
            cl3.ColumnWidth = 15;
            cl3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl3.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "E3");
            cl4.MergeCells = true;
            cl4.Value2 = "KHÁCH HÀNG CK";
            cl4.ColumnWidth = 20;
            cl4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl4.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl4a = oSheet.get_Range("D4", "D4");
            cl4a.Value2 = "PT";
            cl4a.ColumnWidth = 10;
            cl4a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl4a.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl4b = oSheet.get_Range("E4", "E4");
            cl4b.Value2 = "SỐ TIỀN";
            cl4b.ColumnWidth = 10;
            cl4b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl4b.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("F3", "M3");
            cl5.MergeCells = true;
            cl5.Value2 = "GIẢI TRÁCH";
            cl5.ColumnWidth = 70;
            cl5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5a = oSheet.get_Range("F4", "F4");
            cl5a.Value2 = "KỲ";
            cl5a.ColumnWidth = 5;
            cl5a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5a.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5b = oSheet.get_Range("G4", "G4");
            cl5b.Value2 = "NGÀY BK";
            cl5b.ColumnWidth = 10;
            cl5b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5b.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5c = oSheet.get_Range("H4", "H4");
            cl5c.Value2 = "PT";
            cl5c.ColumnWidth = 10;
            cl5c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5c.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5d = oSheet.get_Range("I4", "I4");
            cl5d.Value2 = "TN";
            cl5d.ColumnWidth = 10;
            cl5d.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5d.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5e = oSheet.get_Range("J4", "J4");
            cl5e.Value2 = "THUẾ";
            cl5e.ColumnWidth = 10;
            cl5e.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5e.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5f = oSheet.get_Range("K4", "K4");
            cl5f.Value2 = "PHÍ BVMT";
            cl5f.ColumnWidth = 10;
            cl5f.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5f.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5g = oSheet.get_Range("L4", "L4");
            cl5g.Value2 = "CỘNG GT";
            cl5g.ColumnWidth = 10;
            cl5g.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5g.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl5h = oSheet.get_Range("M4", "M4");
            cl5h.Value2 = "LỆCH";
            cl5h.ColumnWidth = 10;
            cl5h.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl5h.Font.Name = "Times New Roman";

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("N3", "N3");
            cl6.MergeCells = true;
            cl6.Value2 = "LOẠI";
            cl6.ColumnWidth = 5;
            cl6.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            cl6.Font.Name = "Times New Roman";

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 14];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = i + 1;
                arr[i, 1] = dr["HoTen"].ToString();
                arr[i, 2] = dr["DanhBo"].ToString();
                arr[i, 4] = dr["SoTien"].ToString();
                arr[i, 5] = dr["Ky"].ToString();
                if (!string.IsNullOrEmpty(dr["CreateDate"].ToString()))
                    arr[i, 6] = DateTime.Parse(dr["CreateDate"].ToString()).ToString("dd/MM/yyyy");
                arr[i, 8] = dr["GiaBan"].ToString();
                arr[i, 9] = dr["ThueGTGT"].ToString();
                arr[i, 10] = dr["PhiBVMT"].ToString();
                arr[i, 11] = dr["TongCong"].ToString();
                if (!string.IsNullOrEmpty(dr["SoTien"].ToString()))
                    arr[i, 12] = int.Parse(dr["SoTien"].ToString()) - int.Parse(dr["TongCong"].ToString());
                if (int.Parse(dr["GiaBieu"].ToString()) > 20)
                    arr[i, 13] = "CQ";
                else
                    arr[i, 13] = "TG";
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 5;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 14;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            //Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            //Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            //oSheet.get_Range(c2a, c3a).Font.Bold = true;
            //oSheet.get_Range(c2a, c3a).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //oSheet.get_Range(c2a, c3a).NumberFormat = "@";

            //Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 6];
            //Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 6];
            //Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            //oSheet.get_Range(c2b, c3b).Font.Bold = true;
            //oSheet.get_Range(c2b, c3b).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //oSheet.get_Range(c2b, c3b).NumberFormat = "@";

            //Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            //Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            //Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            //oSheet.get_Range(c2c, c3c).Font.Bold = true;
            //oSheet.get_Range(c2c, c3c).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //oSheet.get_Range(c2c, c3c).NumberFormat = "#,##0";

            ////Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
            ////Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
            ////Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
            ////oSheet.get_Range(c2d, c3d).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            ////Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
            ////Microsoft.Office.Interop.Excel.Range c2e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
            ////Microsoft.Office.Interop.Excel.Range c3e = oSheet.get_Range(c1e, c2e);
            ////oSheet.get_Range(c2e, c3e).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            ////Microsoft.Office.Interop.Excel.Range c1f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 6];
            ////Microsoft.Office.Interop.Excel.Range c2f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 6];
            ////Microsoft.Office.Interop.Excel.Range c3f = oSheet.get_Range(c1f, c2f);
            ////oSheet.get_Range(c2f, c3f).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.ChuyenKhoan;
using System.Globalization;
using ThuTien.DAL;

namespace ThuTien.GUI.PhoGiamDoc
{
    public partial class frmKiemTraThu2Lan : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();
        CDichVuThu _cDichVuThu = new CDichVuThu();
        CCAPNUOCTANHOA _cCapNuocTanHoa = new CCAPNUOCTANHOA();

        public frmKiemTraThu2Lan()
        {
            InitializeComponent();
        }

        private void frmKiemTraThu2Lan_Load(object sender, EventArgs e)
        {
            dgvDichVuThu.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";

            cmbKy.SelectedItem = DateTime.Now.Month.ToString();
            cmbDot.SelectedIndex = 0;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbDot.SelectedIndex == 0)
            {
                dgvDichVuThu.DataSource = _cDichVuThu.GetDS_PGD(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
            }
            else
                if (cmbDot.SelectedIndex > 0)
                {
                    dgvDichVuThu.DataSource = _cDichVuThu.GetDS_PGD(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                }
        }

        private void dgvDichVuThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDichVuThu.Columns[e.ColumnIndex].Name == "MLT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvDichVuThu.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && e.Value.ToString().Length == 11)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvDichVuThu.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDichVuThu.Columns[e.ColumnIndex].Name == "Phi" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvDichVuThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDichVuThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
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

            oSheet.Name = "Danh Sách Thu 2 Lần";

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("A1", "A1");
            cl5.Value2 = "MLT";
            cl5.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
            cl2.Value2 = "Kỳ";
            cl2.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("C1", "C1");
            cl1.Value2 = "Số Hóa Đơn";
            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("D1", "D1");
            cl3.Value2 = "Danh Bộ";
            cl3.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("E1", "E1");
            cl4.Value2 = "Khách Hàng";
            cl4.ColumnWidth = 25;

            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("F1", "F1");
            cl12.Value2 = "Địa Chỉ";
            cl12.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("G1", "G1");
            cl6.Value2 = "Số Tiền";
            cl6.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("H1", "H1");
            cl7.Value2 = "Tổ";
            cl7.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("I1", "I1");
            cl8.Value2 = "Hành Thu";
            cl8.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("J1", "J1");
            cl9.Value2 = "Ngày Thu";
            cl9.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("K1", "K1");
            cl10.Value2 = "Ngày Giải Trách";
            cl10.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("L1", "L1");
            cl11.Value2 = "Đăng Ngân";
            cl11.ColumnWidth = 15;

            DataTable dt = (DataTable)dgvDichVuThu.DataSource;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 12];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = dr["MLT"].ToString();
                arr[i, 1] = dr["Ky"].ToString();
                arr[i, 2] = dr["SoHoaDon"].ToString();
                arr[i, 3] = dr["DanhBo"].ToString();
                arr[i, 4] = dr["HoTen"].ToString();
                arr[i, 5] = dr["DiaChi"].ToString();
                arr[i, 6] = dr["SoTien"].ToString();
                arr[i, 7] = dr["To"].ToString();
                arr[i, 8] = dr["HanhThu"].ToString();
                arr[i, 9] = dr["CreateDate"].ToString();
                arr[i, 10] = dr["NgayGiaiTrach"].ToString();
                arr[i, 11] = dr["DangNgan"].ToString();
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 12;

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

        private void btnXuatExcelChuyenKhoan_Click(object sender, EventArgs e)
        {
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

            DataTable dt = _cHoaDon.GetDSChuyenKhoan(int.Parse(cmbNam.SelectedValue.ToString()));

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


    }
}

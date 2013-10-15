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

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            vanthus.DataSource = _CDataQLVanThuDen.LoadDSVanThuDen();
            dgvDSVanThu.DataSource =  vanthus ;
        }

        private void LoadDSVanThuFilter()
        {
            string expression = String.Format("(NgayDen like '%{0}%' or SoDen like '%{0}%' or TacGiaVB like '%{0}%' or SoKyHieuVB like '%{0}%' or LoaiTrichYeuNoiDung like '%{0}%' or NguoiNhan like '%{0}%')", txtNoiDungTimKiem.Text.Trim());
            if (chkCongVanDen.Checked)
                expression = "LoaiVBGID=3 and " + expression;
            else
                if (chkDonThuDen.Checked)
                    expression = "LoaiVBGID=7 and " + expression;
            vanthus.Filter = expression;
        }

        private void ExportToExcel(DataTable dt, string sheetName, string title)
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
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "H1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Ngày Đến";
            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Số Đến";
            cl2.ColumnWidth = 10;
            

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Tác Giả Văn Bản";
            cl3.ColumnWidth = 40;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "Số Ký Hiệu Văn Bản";
            cl4.ColumnWidth = 25;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Ngày Tháng Văn Bản";
            cl5.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "Loại";
            cl6.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "Loại Trích Yếu Nội Dung";
            cl7.ColumnWidth = 100;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "Người Nhận";
            cl8.ColumnWidth = 25;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "H3");
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
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                DataRow dr = dt.Rows[r];
                for (int c = 0; c < dt.Columns.Count - 3; c++)
                {
                    arr[r, c] = dr[c];
                }
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
            // Căn giữa cột Ngày Đến
            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];
            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);
            oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c3, c4).Font.Name = "Times New Roman";
            oSheet.get_Range(c3, c4).Font.Size = 12;
            // Căn trái cột Số Đến
            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            Microsoft.Office.Interop.Excel.Range c3b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            Microsoft.Office.Interop.Excel.Range c4b = oSheet.get_Range(c1b, c3b);
            oSheet.get_Range(c3b, c4b).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            oSheet.get_Range(c3b, c4b).Font.Name = "Times New Roman";
            oSheet.get_Range(c3b, c4b).Font.Size = 12;
            // Căn trái cột Số Ký Hiệu Văn Bản
            Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
            Microsoft.Office.Interop.Excel.Range c3c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
            Microsoft.Office.Interop.Excel.Range c4c = oSheet.get_Range(c1c, c3c);
            oSheet.get_Range(c3c, c4c).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            oSheet.get_Range(c3c, c4c).Font.Name = "Times New Roman";
            oSheet.get_Range(c3c, c4c).Font.Size = 12;
            // Căn giữa cột Ngày Tháng Văn Bản
            Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
            Microsoft.Office.Interop.Excel.Range c3d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
            Microsoft.Office.Interop.Excel.Range c4d = oSheet.get_Range(c1d, c3d);
            oSheet.get_Range(c3d, c4d).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c3d, c4d).Font.Name = "Times New Roman";
            oSheet.get_Range(c3d, c4d).Font.Size = 12;
            // Căn giữa cột Loại Văn Bản
            Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 6];
            Microsoft.Office.Interop.Excel.Range c3e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 6];
            Microsoft.Office.Interop.Excel.Range c4e = oSheet.get_Range(c1e, c3e);
            oSheet.get_Range(c3e, c4e).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c3e, c4e).Font.Name = "Times New Roman";
            oSheet.get_Range(c3e, c4e).Font.Size = 12;
            // Căn giữa cột Nội Dung
            Microsoft.Office.Interop.Excel.Range c1f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 7];
            Microsoft.Office.Interop.Excel.Range c3f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 7];
            Microsoft.Office.Interop.Excel.Range c4f = oSheet.get_Range(c1f, c3f);
            oSheet.get_Range(c3f, c4f).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c3f, c4f).Font.Name = "Times New Roman";
            oSheet.get_Range(c3f, c4f).Font.Size = 12;
            // Căn giữa cột Người Nhận
            Microsoft.Office.Interop.Excel.Range c1g = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 8];
            Microsoft.Office.Interop.Excel.Range c3g = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 8];
            Microsoft.Office.Interop.Excel.Range c4g = oSheet.get_Range(c1g, c3g);
            oSheet.get_Range(c3g, c4g).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c3g, c4g).Font.Name = "Times New Roman";
            oSheet.get_Range(c3g, c4g).Font.Size = 12;
            // Căn giữa cột Tác Giả Văn Bản
            Microsoft.Office.Interop.Excel.Range c1h = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            Microsoft.Office.Interop.Excel.Range c3h = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            Microsoft.Office.Interop.Excel.Range c4h = oSheet.get_Range(c1h, c3h);
            oSheet.get_Range(c3h, c4h).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range(c3h, c4h).Font.Name = "Times New Roman";
            oSheet.get_Range(c3h, c4h).Font.Size = 12;
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
            ExportToExcel(((DataTable)vanthus.DataSource).DefaultView.ToTable(), "Danh sách văn thư", "DANH SÁCH VĂN THƯ");
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (chkTimeTimKiem.Checked)
                if (dateDenNgay.Value.Date >= dateTuNgay.Value.Date)
                {
                    vanthus.DataSource = _CDataQLVanThuDen.LoadDSVanThuDenDateToDate(dateTuNgay.Value.Date.ToString("yyyy-MM-dd"), dateDenNgay.Value.Date.AddDays(1).ToString("yyyy-MM-dd"));
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



    }
}

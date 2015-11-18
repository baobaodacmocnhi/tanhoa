using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.ChuyenKhoan;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmLichSuDieuChinhTienDu : Form
    {
        CTienDu _cTienDu = new CTienDu();

        public frmLichSuDieuChinhTienDu()
        {
            InitializeComponent();
        }

        private void frmLichSuDieuChinhTien_Load(object sender, EventArgs e)
        {
            dgvLichSuDieuChinhTienDu.AutoGenerateColumns = false;
            dgvLichSuTienDu.AutoGenerateColumns = false;

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dateTu.Value <= dateDen.Value)
            {
                DataTable dtChuyen = _cTienDu.GetDSChuyenTien(dateTu.Value, dateDen.Value);
                DataTable dtNhan = _cTienDu.GetDSNhanTien(dateTu.Value, dateDen.Value);

                DataTable dt = new DataTable();
                dt.Columns.Add("DanhBoChuyen", typeof(string));
                dt.Columns.Add("SoTienChuyen", typeof(int));
                dt.Columns.Add("DanhBoNhan", typeof(string));
                dt.Columns.Add("CreateDate", typeof(DateTime));

                for (int i = 0; i < dtChuyen.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();

                    dr["DanhBoChuyen"] = dtChuyen.Rows[i]["DanhBo"];
                    dr["SoTienChuyen"] = int.Parse(dtChuyen.Rows[i]["SoTien"].ToString()) * -1;
                    dr["DanhBoNhan"] = dtNhan.Rows[i]["DanhBo"];
                    dr["CreateDate"] = dtChuyen.Rows[i]["CreateDate"];

                    dt.Rows.Add(dr);
                }

                dgvLichSuDieuChinhTienDu.DataSource = dt;
            }
        }

        private void dgvLichSuDieuChinhTienDu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLichSuDieuChinhTienDu.Columns[e.ColumnIndex].Name == "DanhBoChuyen" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvLichSuDieuChinhTienDu.Columns[e.ColumnIndex].Name == "SoTienChuyen" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvLichSuDieuChinhTienDu.Columns[e.ColumnIndex].Name == "DanhBoNhan" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
        }

        private void dgvLichSuDieuChinhTienDu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvLichSuDieuChinhTienDu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Replace(" ", "").Length == 11)
            {
                dgvLichSuTienDu.DataSource = _cTienDu.GetDSLichSu(txtDanhBo.Text.Trim().Replace(" ", ""));
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvLichSuTienDu.DataSource;

            //Tạo các đối tượng Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            //khai báo số lượng sheet
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            //XuatExcel(dt, oSheet, "LỊCH SỬ", txtDanhBo.Text.Trim());

            oSheet.Name = "LỊCH SỬ";

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "F1");
            head.MergeCells = true;
            head.Value2 = "LỊCH SỬ GIAO DỊCH DANH BỘ " + txtDanhBo.Text.Trim();
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "16";
            head.RowHeight = 25;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Ngày Lập";
            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Số Tiền";
            cl2.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Loại";
            cl3.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "Danh Bộ Chuyển/Nhận";
            cl4.ColumnWidth = 15;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 4];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = dr["CreateDate"].ToString();
                arr[i, 1] = dr["SoTien"].ToString();
                arr[i, 2] = dr["Loai"].ToString();
                arr[i, 3] = dr["DanhBoChuyenNhan"].ToString();
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 4;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            oSheet.get_Range(c2a, c3a).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            oSheet.get_Range(c2b, c3b).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            oSheet.get_Range(c2b, c3b).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            oSheet.get_Range(c2c, c3c).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
            Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
            Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
            oSheet.get_Range(c2d, c3d).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

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

        private void dgvLichSuTienDu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLichSuTienDu.Columns[e.ColumnIndex].Name == "TongCong_LSTD" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvLichSuTienDu.Columns[e.ColumnIndex].Name == "DanhBoChuyenNhan_LSTD" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
        }

        private void dgvLichSuTienDu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvLichSuTienDu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}

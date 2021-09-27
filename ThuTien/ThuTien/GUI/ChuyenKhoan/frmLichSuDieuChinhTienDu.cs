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

            cmbLoai.SelectedIndex = 0;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dateTu.Value <= dateDen.Value)
            {
                DataTable dt = new DataTable();
                switch (cmbLoai.SelectedItem.ToString())
                {
                    case "Bảng Kê":
                        dt = _cTienDu.GetDSLichSu("Bảng Kê", dateTu.Value, dateDen.Value);
                        break;
                    case "Đăng Ngân":
                        dt = _cTienDu.GetDSLichSu("Đăng Ngân", dateTu.Value, dateDen.Value);
                        break;
                    case "Chuyển Tiền":
                        dt = _cTienDu.GetDSLichSu("Chuyển Tiền",dateTu.Value, dateDen.Value);
                        break;
                    case "Nhận Tiền":
                        dt = _cTienDu.GetDSLichSu("Nhận Tiền", dateTu.Value, dateDen.Value);
                        break;
                    case "Điều Chỉnh Tiền":
                        dt = _cTienDu.GetDSLichSu("Điều Chỉnh Tiền", dateTu.Value, dateDen.Value);
                        break;
                    default:
                        dt = _cTienDu.GetDSLichSu("", dateTu.Value, dateDen.Value);
                        break;
                }
                dgvLichSuDieuChinhTienDu.DataSource = dt;

                long TongCong = 0;
                foreach (DataGridViewRow item in dgvLichSuDieuChinhTienDu.Rows)
                {
                    TongCong += int.Parse(item.Cells["SoTien"].Value.ToString());
                }
                txtTongCong.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void dgvLichSuDieuChinhTienDu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLichSuDieuChinhTienDu.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvLichSuDieuChinhTienDu.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvLichSuDieuChinhTienDu.Columns[e.ColumnIndex].Name == "DanhBoChuyenNhan" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
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
            if (e.KeyChar == 13)
            {
                dgvLichSuTienDu.DataSource = _cTienDu.GetDSLichSu(txtDanhBo.Text.Trim().Replace(" ", ""));
                long TongCong = 0;
                for (int i = dgvLichSuTienDu.RowCount-1; i >= 0; i--)
                    if (dgvLichSuTienDu["SoTien_LSTD", i].Value.ToString() != "")
                    {
                        if (i == dgvLichSuTienDu.RowCount-1)
                            dgvLichSuTienDu["BienDong_LSTD", i].Value = dgvLichSuTienDu["SoTien_LSTD", i].Value;
                        else
                            dgvLichSuTienDu["BienDong_LSTD", i].Value = int.Parse(dgvLichSuTienDu["BienDong_LSTD", i + 1].Value.ToString()) + int.Parse(dgvLichSuTienDu["SoTien_LSTD", i].Value.ToString());
                        TongCong += int.Parse(dgvLichSuTienDu["SoTien_LSTD", i].Value.ToString());
                    }
                //foreach (DataGridViewRow item in dgvLichSuTienDu.Rows)
                //    if (item.Cells["SoTien_LSTD"].Value.ToString() != "")
                //    {
                //        TongCong += int.Parse(item.Cells["SoTien_LSTD"].Value.ToString());
                //    }
                txtTongCong_LSTD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
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

        private void dgvLichSuTienDu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLichSuTienDu.Columns[e.ColumnIndex].Name == "SoTien_LSTD" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvLichSuTienDu.Columns[e.ColumnIndex].Name == "BienDong_LSTD" && e.Value != null)
            {
                if ((int)e.Value == 0)
                    e.Value = "0";
                else
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

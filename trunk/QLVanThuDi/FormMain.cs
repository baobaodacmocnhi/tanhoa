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
        DataTable dt = new DataTable();

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
            for (int r = 0; r < dt.Rows.Count; r++)
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
                arr[r, 3] = NoiThaoDatas[NoiThaoDatas.Count()-1];
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
            ExportToExcel(((DataTable)vanthudis.DataSource).DefaultView.ToTable(), "Danh sách văn thư đi", "DANH SÁCH VĂN THƯ ĐI");
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (chkTimeTimKiem.Checked)
                if (dateDenNgay.Value.Date >= dateTuNgay.Value.Date)
                {
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
                default:
                    KeyWord = "";
                    break;
            }
            string expression = String.Format("(SoKyHieuVB like '%{0}%')", KeyWord);
            vanthudis.Filter = expression;
        }



    }
}

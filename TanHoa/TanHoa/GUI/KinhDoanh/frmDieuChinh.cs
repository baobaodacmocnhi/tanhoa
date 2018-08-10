using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoa.DAL;

namespace TanHoa.GUI.KinhDoanh
{
    public partial class frmDieuChinh : Form
    {
        //CConnection _cKinhDoanh = new CConnection("Data Source=192.168.90.11;Initial Catalog=KTKS_DonKH;Persist Security Info=True;User ID=sa;Password=capnuoctanhoa789");
        CConnection _cKinhDoanh = new CConnection("Data Source=serverg8-01;Initial Catalog=KTKS_DonKH;Persist Security Info=True;User ID=sa;Password=capnuoctanhoa789");
        DataTable dt = new DataTable();

        public frmDieuChinh()
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
        }

        private void frmDieuChinh_Load(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (radBienDong.Checked)
            {
                string sql = "select ID=MaCTDCBD"
                            + ",DanhBo"
                            + ",HoTen"
                            + ",DiaChi"
                            + ",ThongTin"
                            + ",CreateDate"
                            + ",GiaBieu"
                            + ",DinhMuc"
                            + ",SH"
                            + ",SX"
                            + ",DV"
                            + ",HCSN"
                            + ",HoTen_BD"
                            + ",DiaChi_BD"
                            + ",MSThue_BD"
                            + ",GiaBieu_BD"
                            + ",DinhMuc_BD"
                            + ",SH_BD"
                            + ",SX_BD"
                            + ",DV_BD"
                            + ",HCSN_BD"
                            + " from DCBD_ChiTietBienDong where CAST(CreateDate as date)>='" + dateFrom.Value.ToString("yyyyMMdd") + "' and CAST(CreateDate as date)<='" + dateTo.Value.ToString("yyyyMMdd") + "'";
                if (chkGiaBieu.Checked == true)
                    sql += " and GiaBieu!=GiaBieu_BD";
                if (chkDinhMuc.Checked == true)
                    sql += " and DinhMuc!=DinhMuc_BD";
                sql += " order by CreateDate asc";
                dt = _cKinhDoanh.ExecuteQuery_DataTable(sql);
            }
            else if (radHoaDon.Checked)
            {
                string sql = "select ID=MaCTDCHD"
                            + ",DanhBo"
                            + ",HoTen"
                            + ",DiaChi"
                            + ",CreateDate"
                            + ",TongCong_Start"
                            + ",TongCong_BD"
                            + ",TongCong_End"
                            + ",KyHD"
                            + ",TangGiam"
                            + ",ThongTin"
                            + ",LyDoDieuChinh"
                            + ",GiaBieu"
                            + ",GiaBieu_BD"
                            + ",DinhMuc"
                            + ",DinhMuc_BD"
                            + ",TieuThu"
                            + ",TieuThu_BD"
                            + ",DieuChinhGia"
                            + ",TieuThu_DieuChinhGia"
                            + ",GiaDieuChinh"
                            + ",ChiTietMoi"
                            + " from DCBD_ChiTietHoaDon where CAST(CreateDate as date)>='" + dateFrom.Value.ToString("yyyyMMdd") + "' and CAST(CreateDate as date)<='" + dateTo.Value.ToString("yyyyMMdd") + "'";
                if (chkGiaBieu.Checked == true)
                    sql += " and GiaBieu!=GiaBieu_BD";
                if (chkDinhMuc.Checked == true)
                    sql += " and DinhMuc!=DinhMuc_BD";
                if (chkTieuThu.Checked == true)
                    sql += " and TieuThu!=TieuThu_BD";
                if (chkDieuChinhGia.Checked == true)
                    sql += " and DieuChinhGia=1";
                sql += " order by CreateDate asc";
                dt = _cKinhDoanh.ExecuteQuery_DataTable(sql);

            }
            dataGridView.DataSource = dt;
            txtTong.Text = dt.Rows.Count.ToString();
            long TongCong_BD = 0;
            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                if (item.Cells["TongCong_BD"].Value != null)
                    TongCong_BD += long.Parse(item.Cells["TongCong_BD"].Value.ToString());
                if (item.Cells["GiaBieu_BD"].Value != null && item.Cells["GiaBieu_BD"].Value.ToString()!="")
                    if ((int)item.Cells["GiaBieu"].Value != (int)item.Cells["GiaBieu_BD"].Value)
                        item.Cells["GiaBieu_BD"].Style.BackColor = Color.Orange;
                if (item.Cells["DinhMuc_BD"].Value != null && item.Cells["DinhMuc_BD"].Value.ToString() != "")
                    if ((int)item.Cells["DinhMuc"].Value != (int)item.Cells["DinhMuc_BD"].Value)
                        item.Cells["DinhMuc_BD"].Style.BackColor = Color.Orange;
                if (item.Cells["TieuThu"].Value != null)
                    if ((int)item.Cells["TieuThu"].Value != (int)item.Cells["TieuThu_BD"].Value)
                        item.Cells["TieuThu_BD"].Style.BackColor = Color.Orange;
                if (item.Cells["DieuChinhGia"].Value != null)
                    if ((bool)item.Cells["DieuChinhGia"].Value == true)
                    {
                        item.Cells["TieuThu_DieuChinhGia"].Style.BackColor = Color.Orange;
                        item.Cells["GiaDieuChinh"].Style.BackColor = Color.Orange;
                    }
            }
            txtTongCong_BD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong_BD);
        }

        private void radBienDong_CheckedChanged(object sender, EventArgs e)
        {
            if (radBienDong.Checked == true)
            {
                chkTieuThu.Visible = false;
                chkDieuChinhGia.Visible = false;
                //
                dataGridView.Columns["HoTen_BD"].Visible = true;
                dataGridView.Columns["DiaChi_BD"].Visible = true;
                dataGridView.Columns["SH"].Visible = true;
                dataGridView.Columns["SX"].Visible = true;
                dataGridView.Columns["DV"].Visible = true;
                dataGridView.Columns["HCSN"].Visible = true;
                dataGridView.Columns["SH_BD"].Visible = true;
                dataGridView.Columns["SX_BD"].Visible = true;
                dataGridView.Columns["DV_BD"].Visible = true;
                dataGridView.Columns["HCSN_BD"].Visible = true;
                //
                dataGridView.Columns["LyDoDieuChinh"].Visible = false;
                dataGridView.Columns["KyHD"].Visible = false;
                dataGridView.Columns["TangGiam"].Visible = false;
                dataGridView.Columns["TieuThu"].Visible = false;
                dataGridView.Columns["TieuThu_BD"].Visible = false;
                dataGridView.Columns["TieuThu_DieuChinhGia"].Visible = false;
                dataGridView.Columns["GiaDieuChinh"].Visible = false;
                dataGridView.Columns["ChiTietMoi"].Visible = false;
            }
        }

        private void radHoaDon_CheckedChanged(object sender, EventArgs e)
        {
            if (radHoaDon.Checked == true)
            {
                chkTieuThu.Visible = true;
                chkDieuChinhGia.Visible = true;
                //
                dataGridView.Columns["HoTen_BD"].Visible = false;
                dataGridView.Columns["DiaChi_BD"].Visible = false;
                dataGridView.Columns["SH"].Visible = false;
                dataGridView.Columns["SX"].Visible = false;
                dataGridView.Columns["DV"].Visible = false;
                dataGridView.Columns["HCSN"].Visible = false;
                dataGridView.Columns["SH_BD"].Visible = false;
                dataGridView.Columns["SX_BD"].Visible = false;
                dataGridView.Columns["DV_BD"].Visible = false;
                dataGridView.Columns["HCSN_BD"].Visible = false;
                //
                dataGridView.Columns["LyDoDieuChinh"].Visible = true;
                dataGridView.Columns["KyHD"].Visible = true;
                dataGridView.Columns["TangGiam"].Visible = true;
                dataGridView.Columns["TieuThu"].Visible = true;
                dataGridView.Columns["TieuThu_BD"].Visible = true;
                dataGridView.Columns["TieuThu_DieuChinhGia"].Visible = true;
                dataGridView.Columns["GiaDieuChinh"].Visible = true;
                dataGridView.Columns["ChiTietMoi"].Visible = true;
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            String strName = "";
            if (radBienDong.Checked)
            {
                strName = "DANH SÁCH ĐIỀU CHỈNH BIẾN ĐỘNG";
            }
            else
            {
                strName = "DANH SÁCH ĐIỀU CHỈNH HÓA ĐƠN";
            }
            if (dt == null||dt.Rows.Count==0)
                return;
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

            oSheet.Name = strName;

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "F1");
            head.MergeCells = true;
            head.Value2 = strName;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.RowHeight = 50;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head2 = oSheet.get_Range("A2", "F2");
            head2.MergeCells = true;
            head2.Value2 = "Từ Ngày " + dateFrom.Value.ToString("dd/MM/yyyy") + " Đến Ngày " + dateTo.Value.ToString("dd/MM/yyyy");
            head2.Font.Bold = true;
            head2.Font.Name = "Times New Roman";
            head2.Font.Size = "20";
            head2.RowHeight = 50;
            head2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            object[,] arrHead = new object[1, dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                DataColumn dc = dt.Columns[i];

                arrHead[0, i] = dc.ColumnName;
            }
            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1Head = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[4, 1];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2Head = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[4, dt.Columns.Count];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range rangeHead = oSheet.get_Range(c1Head, c2Head);

            rangeHead.Value2 = arrHead;

            // Tạo tiêu đề cột 
            //Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A4", "A4");
            //cl1.Value2 = "Danh Bộ";
            //cl1.ColumnWidth = 15;

            //Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B4", "B4");
            //cl2.Value2 = "Khách Hàng";
            //cl2.ColumnWidth = 30;

            //Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C4", "C4");
            //cl3.Value2 = "Địa Chỉ";
            //cl3.ColumnWidth = 30;


            //Thiết lập vùng điền dữ liệu
            int columnStart = 1;
            int columnEnd = dt.Columns.Count;
            int rowStart = 5;
            int rowEnd = rowStart + dt.Rows.Count - 1;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, columnEnd];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    arr[i, j] = dr[j];
                }
            }

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            range.NumberFormat = "@";
            //Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            //Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            //Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            //c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            //Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            //Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            //c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            //c3b.NumberFormat = "#,##0";

            //Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            //Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            //Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            //c3c.NumberFormat = "@";
            //c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "TongCong_Start" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dataGridView.Columns[e.ColumnIndex].Name == "TongCong_BD" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dataGridView.Columns[e.ColumnIndex].Name == "TongCong_End" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }
    }
}

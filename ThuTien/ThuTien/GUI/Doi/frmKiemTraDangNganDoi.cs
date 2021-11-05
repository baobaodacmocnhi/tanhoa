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
using System.Globalization;
using ThuTien.BaoCao;
using ThuTien.BaoCao.ChuyenKhoan;
using ThuTien.GUI.BaoCao;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;

namespace ThuTien.GUI.Doi
{
    public partial class frmKiemTraDangNganDoi : Form
    {
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();
        CChotDangNgan _cChotDangNgan = new CChotDangNgan();

        frmLoading frm;
        string _actionNopTien = "";

        public frmKiemTraDangNganDoi()
        {
            InitializeComponent();
        }

        private void frmKiemTraDangNganDoi_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;
            dgvNhanVien_TC.AutoGenerateColumns = false;
            dgvChotDangNgan.AutoGenerateColumns = false;

            List<TT_To> lst = _cTo.getDS();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            lst.Insert(0, to);
            cmbTo.DataSource = lst;
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;

            tabTuGia.Text = "Hóa Đơn";
            tabControl.TabPages.Remove(tabCoQuan);
        }

        public void CountdgvHDTuGia()
        {
            int TongHD = 0;
            long TongGiaBan = 0;
            long TongThueGTGT = 0;
            long TongPhiBVMT = 0;
            long TongCong = 0;
            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    TongHD += int.Parse(item.Cells["TongHD_TG"].Value.ToString());
                    TongGiaBan += long.Parse(item.Cells["TongGiaBan_TG"].Value.ToString());
                    TongThueGTGT += long.Parse(item.Cells["TongThueGTGT_TG"].Value.ToString());
                    TongPhiBVMT += long.Parse(item.Cells["TongPhiBVMT_TG"].Value.ToString());
                    TongCong += long.Parse(item.Cells["TongCong_TG"].Value.ToString());
                }
                txtTongHD_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongGiaBan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        public void CountdgvHDCoQuan()
        {
            int TongHD = 0;
            long TongGiaBan = 0;
            long TongThueGTGT = 0;
            long TongPhiBVMT = 0;
            long TongCong = 0;
            if (dgvHDCoQuan.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    TongHD += int.Parse(item.Cells["TongHD_CQ"].Value.ToString());
                    TongGiaBan += long.Parse(item.Cells["TongGiaBan_CQ"].Value.ToString());
                    TongThueGTGT += long.Parse(item.Cells["TongThueGTGT_CQ"].Value.ToString());
                    TongPhiBVMT += long.Parse(item.Cells["TongPhiBVMT_CQ"].Value.ToString());
                    TongCong += long.Parse(item.Cells["TongCong_CQ"].Value.ToString());
                }
                txtTongHD_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongGiaBan_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        public void CountdgvNhanVien_TC()
        {
            int TongHD = 0;
            long TongGiaBan = 0;
            long TongThueGTGT = 0;
            long TongPhiBVMT = 0;
            long TongCong = 0;
            if (dgvNhanVien_TC.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvNhanVien_TC.Rows)
                {
                    TongHD += int.Parse(item.Cells["TongHD_TC"].Value.ToString());
                    TongGiaBan += long.Parse(item.Cells["TongGiaBan_TC"].Value.ToString());
                    TongThueGTGT += long.Parse(item.Cells["TongThueGTGT_TC"].Value.ToString());
                    TongPhiBVMT += long.Parse(item.Cells["TongPhiBVMT_TC"].Value.ToString());
                    TongCong += long.Parse(item.Cells["TongCong_TC"].Value.ToString());
                }

                txtTongHD_TC.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongGiaBan_TC.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_TC.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_TC.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong_TC.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            List<TT_To> lst = _cTo.getDS();
            dgvNhanVien_TC.DataSource = _cHoaDon.GetTongDangNgan_Doi(dateTu.Value, dateDen.Value);
            CountdgvNhanVien_TC();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if (int.Parse(cmbTo.SelectedValue.ToString()) == 0)
                {
                    DataTable dt = new DataTable();

                    dt = _cHoaDon.GetTongDangNgan_Doi("", lst[0].MaTo, dateTu.Value, dateDen.Value);
                    for (int i = 1; i < lst.Count; i++)
                    {
                        dt.Merge(_cHoaDon.GetTongDangNgan_Doi("", lst[i].MaTo, dateTu.Value, dateDen.Value));
                    }

                    dgvHDTuGia.DataSource = dt;
                }
                else
                {
                    dgvHDTuGia.DataSource = _cHoaDon.GetTongDangNgan_Doi("", int.Parse(cmbTo.SelectedValue.ToString()), dateTu.Value, dateDen.Value);
                }
                CountdgvHDTuGia();
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    if (int.Parse(cmbTo.SelectedValue.ToString()) == 0)
                    {
                        DataTable dt = new DataTable();

                        dt = _cHoaDon.GetTongDangNgan_Doi("CQ", lst[0].MaTo, dateTu.Value, dateDen.Value);
                        for (int i = 1; i < lst.Count; i++)
                        {
                            dt.Merge(_cHoaDon.GetTongDangNgan_Doi("CQ", lst[i].MaTo, dateTu.Value, dateDen.Value));
                        }

                        dgvHDCoQuan.DataSource = dt;
                    }
                    else
                    {
                        dgvHDCoQuan.DataSource = _cHoaDon.GetTongDangNgan_Doi("CQ", int.Parse(cmbTo.SelectedValue.ToString()), dateTu.Value, dateDen.Value);
                    }
                    CountdgvHDCoQuan();
                }
        }

        private void dgvHDTuGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHD_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongGiaBan_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongThueGTGT_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongPhiBVMT_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCong_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDCoQuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHD_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongGiaBan_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongThueGTGT_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongPhiBVMT_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCong_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDTuGia_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDTuGia.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHDCoQuan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDCoQuan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHDTuGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvNhanVien.DataSource = _cHoaDon.GetTongDangNgan_To("", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), dateTu.Value, dateDen.Value);
        }

        private void dgvHDCoQuan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvNhanVien.DataSource = _cHoaDon.GetTongDangNgan_To("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), dateTu.Value, dateDen.Value);
        }

        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongHD_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongGiaBan_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongThueGTGT_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongPhiBVMT_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongCong_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvNhanVien_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvNhanVien.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvNhanVien_TC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNhanVien_TC.Columns[e.ColumnIndex].Name == "TongHD_TC" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_TC.Columns[e.ColumnIndex].Name == "TongGiaBan_TC" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_TC.Columns[e.ColumnIndex].Name == "TongThueGTGT_TC" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_TC.Columns[e.ColumnIndex].Name == "TongPhiBVMT_TC" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_TC.Columns[e.ColumnIndex].Name == "TongCong_TC" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvNhanVien_TC_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvNhanVien_TC.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvNhanVien_TC_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvNhanVien_TC.RowCount > 0 && e.Button == MouseButtons.Left)
            {
                DateTime FromNgayGiaiTrach;
                DateTime ToNgayGiaiTrach;
                DateTime.TryParse(dgvNhanVien_TC["FromNgayGiaiTrach", e.RowIndex].Value.ToString(), out FromNgayGiaiTrach);
                DateTime.TryParse(dgvNhanVien_TC["ToNgayGiaiTrach", e.RowIndex].Value.ToString(), out ToNgayGiaiTrach);

                DataTable dt = new DataTable();
                if (string.IsNullOrEmpty(dgvNhanVien_TC["MaNV_TC", e.RowIndex].Value.ToString()))
                    dt = _cHoaDon.GetDSDangNgan(null, FromNgayGiaiTrach, ToNgayGiaiTrach);
                else
                    dt = _cHoaDon.GetDSDangNgan(int.Parse(dgvNhanVien_TC["MaNV_TC", e.RowIndex].Value.ToString()), FromNgayGiaiTrach, ToNgayGiaiTrach);
                dsBaoCao ds = new dsBaoCao();
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["TuNgay"] = FromNgayGiaiTrach.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = ToNgayGiaiTrach.ToString("dd/MM/yyyy");
                    dr["LoaiBaoCao"] = "HÓA ĐƠN ĐĂNG NGÂN";
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                    dr["HoTen"] = item["HoTen"].ToString();
                    dr["MLT"] = item["MLT"].ToString();
                    dr["Ky"] = item["Ky"].ToString();
                    dr["TongCong"] = item["TongCong"].ToString();
                    dr["HanhThu"] = item["HanhThu"].ToString();
                    dr["To"] = item["To"].ToString();
                    if (int.Parse(item["GiaBieu"].ToString()) > 20)
                        dr["Loai"] = "CQ";
                    else
                        dr["Loai"] = "TG";
                    ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }

                rptDSTamThuChuyenKhoan rpt = new rptDSTamThuChuyenKhoan();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = _cHoaDon.GetDSDangNgan(dateTu.Value, dateDen.Value);

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

            XuatExcel(dt, oSheet, "ĐĂNG NGÂN");
        }

        private void XuatExcel(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName)
        {
            oSheet.Name = SheetName;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
            cl1.Value2 = "Số Hóa Đơn";
            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
            cl2.Value2 = "Kỳ";
            cl2.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
            cl3.Value2 = "Danh Bộ";
            cl3.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
            cl4.Value2 = "Khách Hàng";
            cl4.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E1", "E1");
            cl5.Value2 = "MLT";
            cl5.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F1", "F1");
            cl6.Value2 = "Giá Bán";
            cl6.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G1", "G1");
            cl7.Value2 = "Thuế GTGT";
            cl7.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H1", "H1");
            cl8.Value2 = "Phí BVMT";
            cl8.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I1", "I1");
            cl9.Value2 = "Tổng Cộng";
            cl9.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J1", "J1");
            cl10.Value2 = "Hành Thu";
            cl10.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K1", "K1");
            cl11.Value2 = "Tổ";
            cl11.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M1", "M1");
            cl13.Value2 = "Loại";
            cl13.ColumnWidth = 5;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 13];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = dr["SoHoaDon"].ToString();
                arr[i, 1] = dr["Ky"].ToString();
                arr[i, 2] = dr["DanhBo"].ToString();
                arr[i, 3] = dr["HoTen"].ToString();
                arr[i, 4] = dr["MLT"].ToString();
                arr[i, 5] = dr["GiaBan"].ToString();
                arr[i, 6] = dr["ThueGTGT"].ToString();
                arr[i, 7] = dr["PhiBVMT"].ToString();
                arr[i, 8] = dr["TongCong"].ToString();
                arr[i, 9] = dr["HanhThu"].ToString();
                arr[i, 10] = dr["To"].ToString();
                if (int.Parse(dr["GiaBieu"].ToString()) > 20)
                    arr[i, 12] = "CQ";
                else
                    arr[i, 12] = "TG";
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 13;

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

        private void btnXemChot_Click(object sender, EventArgs e)
        {
            try
            {
                dgvChotDangNgan.DataSource = _cChotDangNgan.getDS(dateTu_ChotDangNgan.Value, dateDen_ChotDangNgan.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemChot_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen("mnuDieuChinhDangNganDoi", "Them"))
                {
                    if (_cChotDangNgan.checkExist(dateTu_ChotDangNgan.Value) == true)
                    {
                        MessageBox.Show("Ngày Chốt đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    TT_ChotDangNgan en = new TT_ChotDangNgan();
                    en.NgayChot = dateTu_ChotDangNgan.Value;
                    en.Chot = false;
                    if (_cChotDangNgan.them(en) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnXemChot.PerformClick();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChotDangNgan_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen("mnuDieuChinhDangNganDoi", "Sua"))
                {
                    if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "Chot")
                    {
                        TT_ChotDangNgan en = _cChotDangNgan.get(int.Parse(dgvChotDangNgan["ID", e.RowIndex].Value.ToString()));
                        en.Chot = bool.Parse(dgvChotDangNgan["Chot", e.RowIndex].Value.ToString());
                        if (_cChotDangNgan.sua(en) == true)
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChotDangNgan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.SyncNopTien == true && CNguoiDung.CheckQuyen("mnuDieuChinhDangNganDoi", "Sua"))
                {
                    if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "SyncNopTien")
                    {
                        if (MessageBox.Show("Bạn có chắc chắn Nộp Tiền?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            TT_ChotDangNgan en = _cChotDangNgan.get(int.Parse(dgvChotDangNgan["ID", e.RowIndex].Value.ToString()));
                            if (_cChotDangNgan.checkExist_ChotDangNgan(en.NgayChot.Value) == true)
                            {
                                MessageBox.Show("Ngày Đăng Ngân đã Chốt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            //DataTable dt = _cHoaDon.ExecuteQuery_DataTable("select MaHD=ID_HOADON from HOADON where Cast(NgayGiaiTrach as date)='" + en.NgayChot.Value.ToString("yyyyMMdd") + "' and syncNopTien=0 and (NAM>2020 or (NAM=2020 and KY>=6)) and DCHD=0 order by NGAYGIAITRACH asc");
                            //foreach (DataRow item in dt.Rows)
                            //{
                            //    _cHoaDon.ExecuteNonQuery("insert into Temp_SyncHoaDon(ID,[Action],Name,Value,MaHD)values((select ID=case when not exists (select ID from Temp_SyncHoaDon) then 1 else MAX(ID)+1 end from Temp_SyncHoaDon),'NopTien','',''," + item["MaHD"] + ")");
                            //}

                            //DataTable dt = _cHoaDon.GetDSDangNgan(DateTime.Parse(dgvChotDangNgan["NgayChot", e.RowIndex].Value.ToString()), DateTime.Parse(dgvChotDangNgan["NgayChot", e.RowIndex].Value.ToString()));
                            //int SL = (int)Math.Ceiling((double)dt.Rows.Count / 1000);
                            _actionNopTien = "NopTien";
                            if (backgroundWorker_NopTien.IsBusy)
                                backgroundWorker_NopTien.CancelAsync();
                            else
                            {
                                backgroundWorker_NopTien.RunWorkerAsync();
                                frm = new frmLoading();
                                frm.ShowDialog();
                            }
                        }
                    }

                    if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "XuatFile")
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.DefaultExt = "dat";
                        saveFileDialog.Filter = "Text files (*.dat)|*.dat";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            TT_ChotDangNgan en = _cChotDangNgan.get(int.Parse(dgvChotDangNgan["ID", e.RowIndex].Value.ToString()));
                            DataTable dt = _cHoaDon.getDSDangNgan_DieuChinhHoaDon(en.NgayChot.Value);
                            using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                                foreach (DataRow item in dt.Rows)
                                {
                                    writer.Write("\"" + item["Nam"] + "\"");
                                    writer.Write(",\"" + int.Parse(item["SoPhatHanh"].ToString()).ToString("00000000") + "\"");
                                    writer.Write(",\"" + item["DangNgan"] + "\"");
                                    writer.Write(",\"" + DateTime.Parse(item["NgayGiaiTrach"].ToString()).ToString("yyyyMMdd") + "\"");
                                    writer.Write(",\"" + item["TieuThu"] + "\"");
                                    writer.Write(",\"" + item["GiaBan"] + "\"");
                                    writer.Write(",\"" + item["ThueGTGT"] + "\"");
                                    writer.Write(",\"" + item["PhiBVMT"] + "\"");
                                    writer.WriteLine(",\"1\"");
                                }
                            MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                    if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "ShowError")
                    {
                        TT_ChotDangNgan en = _cChotDangNgan.get(int.Parse(dgvChotDangNgan["ID", e.RowIndex].Value.ToString()));
                        DataTable dt = _cHoaDon.getDSDangNgan_ChuaNopTien(en.NgayChot.Value);
                        dsBaoCao ds = new dsBaoCao();
                        foreach (DataRow item in dt.Rows)
                        {
                            DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                            dr["LoaiBaoCao"] = "LỖI NỘP TIỀN";
                            dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                            dr["Ky"] = item["Ky"];
                            dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                            dr["TongCong"] = item["TongCong"];
                            dr["GiaBieu"] = _cChotDangNgan.ExecuteQuery_ReturnOneValue("select top 1 Result from Temp_SyncHoaDon where MaHD=" + item["MaHD"].ToString() + " or SoHoaDon='" + item["SoHoaDon"].ToString() + "'");
                            dr["NhanVien"] = CNguoiDung.HoTen;
                            ds.Tables["DSHoaDon"].Rows.Add(dr);
                        }

                        rptDSHoaDon_SyncError rpt = new rptDSHoaDon_SyncError();
                        rpt.SetDataSource(ds);
                        frmBaoCao frm = new frmBaoCao(rpt);
                        frm.Show();
                    }

                    if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "ShowHDDTDCBCT")
                    {
                        TT_ChotDangNgan en = _cChotDangNgan.get(int.Parse(dgvChotDangNgan["ID", e.RowIndex].Value.ToString()));
                        DataTable dt = _cHoaDon.getDSDangNgan_HDDCBaoCaoThue(en.NgayChot.Value);
                        dsBaoCao ds = new dsBaoCao();
                        foreach (DataRow item in dt.Rows)
                        {
                            DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                            dr["LoaiBaoCao"] = "HÓA ĐƠN ĐIỀU CHỈNH ĐÃ BÁO CÁO THUẾ";
                            dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                            dr["Ky"] = item["Ky"];
                            dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                            dr["TongCong"] = item["TongCong"];
                            dr["GiaBieu"] = item["NgayGiaiTrach"];
                            if (bool.Parse(item["DangNgan_ChuyenKhoan"].ToString()) == true)
                                dr["DinhMuc"] = "10";
                            else
                                if (bool.Parse(item["DangNgan_Quay"].ToString()) == true)
                                    dr["DinhMuc"] = "TN";
                                else
                                    if (bool.Parse(item["DangNgan_Ton"].ToString()) == true)
                                        dr["DinhMuc"] = "TQ";
                            dr["NhanVien"] = CNguoiDung.HoTen;
                            ds.Tables["DSHoaDon"].Rows.Add(dr);
                        }

                        rptDSHoaDon_BCT rpt = new rptDSHoaDon_BCT();
                        rpt.SetDataSource(ds);
                        frmBaoCao frm = new frmBaoCao(rpt);
                        frm.Show();
                    }

                    if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "SyncNopTien_Except12")
                    {
                        if (MessageBox.Show("Bạn có chắc chắn Nộp Tiền TRỪ Kỳ 12?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            TT_ChotDangNgan en = _cChotDangNgan.get(int.Parse(dgvChotDangNgan["ID", e.RowIndex].Value.ToString()));
                            if (_cChotDangNgan.checkExist_ChotDangNgan(en.NgayChot.Value) == true)
                            {
                                MessageBox.Show("Ngày Đăng Ngân đã Chốt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            _actionNopTien = "NopTien_Except12";
                            if (backgroundWorker_NopTien.IsBusy)
                                backgroundWorker_NopTien.CancelAsync();
                            else
                            {
                                backgroundWorker_NopTien.RunWorkerAsync();
                                frm = new frmLoading();
                                frm.ShowDialog();
                            }
                        }
                    }

                    if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "SyncNopTien_12")
                    {
                        if (MessageBox.Show("Bạn có chắc chắn Nộp Tiền BÙ Kỳ 12?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            TT_ChotDangNgan en = _cChotDangNgan.get(int.Parse(dgvChotDangNgan["ID", e.RowIndex].Value.ToString()));
                            if (_cChotDangNgan.checkExist_ChotDangNgan(en.NgayChot.Value) == true)
                            {
                                MessageBox.Show("Ngày Đăng Ngân đã Chốt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            _actionNopTien = "NopTien_12";
                            if (backgroundWorker_NopTien.IsBusy)
                                backgroundWorker_NopTien.CancelAsync();
                            else
                            {
                                backgroundWorker_NopTien.RunWorkerAsync();
                                frm = new frmLoading();
                                frm.ShowDialog();
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChotDangNgan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "SLDangNgan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "TCDangNgan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "SLCNKD" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "TCCNKD" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "SLGiay" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "TCGiay" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "SLHDDT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "TCHDDT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "SLHDDTDC" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "TCHDDTDC" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "SLHDDTDCBCT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "TCHDDTDCBCT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "SLHDDTSach" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "TCHDDTSach" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "SLNopTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvChotDangNgan.Columns[e.ColumnIndex].Name == "TCNopTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvChotDangNgan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvChotDangNgan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void backgroundWorker_NopTien_DoWork(object sender, DoWorkEventArgs e)
        {
            wsThuTien.wsThuTien wsThuTien = new wsThuTien.wsThuTien();
            TT_ChotDangNgan en = _cChotDangNgan.get(int.Parse(dgvChotDangNgan.CurrentRow.Cells["ID"].Value.ToString()));
            string result = "";
            switch (_actionNopTien)
            {
                case "NopTien":
                    result = wsThuTien.syncNopTienLo(en.NgayChot.Value.ToString("dd/MM/yyyy"));
                    break;
                case "NopTien_Except12":
                    result = wsThuTien.syncNopTienLo_Except12(en.NgayChot.Value.ToString("dd/MM/yyyy"));
                    break;
                case "NopTien_12":
                    result = wsThuTien.syncNopTienLo_12(en.NgayChot.Value.ToString("dd/MM/yyyy"));
                    break;
            }

            string[] results = result.Split(';');
            if (bool.Parse(results[0]) == true)
            {
                //MessageBox.Show("Thành công Nộp Tiền ngày " + en.NgayChot.Value.ToString("dd/MM/yyyy"), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void backgroundWorker_NopTien_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (frm != null)
                frm.Close();
            switch (_actionNopTien)
            {
                case "NopTien_Except12":
                    MessageBox.Show("Hoàn Tất Nộp Tiền TRỪ Kỳ 12 ngày " + dgvChotDangNgan.CurrentRow.Cells["NgayChot"].Value.ToString().Substring(0, dgvChotDangNgan.CurrentRow.Cells["NgayChot"].Value.ToString().IndexOf(" ")) + "\nVui lòng kiểm tra lại số liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "NopTien_12":
                    MessageBox.Show("Hoàn Tất Nộp Tiền BÙ Kỳ 12 ngày " + dgvChotDangNgan.CurrentRow.Cells["NgayChot"].Value.ToString().Substring(0, dgvChotDangNgan.CurrentRow.Cells["NgayChot"].Value.ToString().IndexOf(" ")) + "\nVui lòng kiểm tra lại số liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    MessageBox.Show("Hoàn Tất Nộp Tiền ngày " + dgvChotDangNgan.CurrentRow.Cells["NgayChot"].Value.ToString().Substring(0, dgvChotDangNgan.CurrentRow.Cells["NgayChot"].Value.ToString().IndexOf(" ")) + "\nVui lòng kiểm tra lại số liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

            btnXemChot.PerformClick();
        }



    }
}

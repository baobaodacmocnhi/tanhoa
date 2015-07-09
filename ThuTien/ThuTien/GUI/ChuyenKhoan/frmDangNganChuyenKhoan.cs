using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.Quay;
using ThuTien.DAL.QuanTri;
using System.Globalization;
using ThuTien.DAL.TongHop;
using ThuTien.BaoCao;
using ThuTien.BaoCao.NhanVien;
using KTKS_DonKH.GUI.BaoCao;
using ThuTien.GUI.TimKiem;
using ThuTien.LinQ;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmDangNganChuyenKhoan : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();
        CTamThu _cTamThu = new CTamThu();
        string _mnu = "mnuDangNganChuyenKhoan";
        CDCHD _cDCHD = new CDCHD();

        public frmDangNganChuyenKhoan()
        {
            InitializeComponent();
        }

        private void frmDangNganChuyenKhoan_Load(object sender, EventArgs e)
        {
            dgvHDDaThu.AutoGenerateColumns = false;
            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
            {
                foreach (string item in txtSoHoaDon.Lines)
                    if (!string.IsNullOrEmpty(item.Trim())&&!lstHD.Items.Contains(item.Trim()))
                    {
                        lstHD.Items.Add(item.Trim());
                    }
                txtSoLuong.Text = lstHD.Items.Count.ToString();
                txtSoHoaDon.Text = "";
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dateTu.Value <= dateDen.Value)
            {
                dgvHDDaThu.DataSource = _cHoaDon.GetDSDangNganChuyenKhoanByMaNVNgayGiaiTrachs(CNguoiDung.MaND, dateTu.Value, dateDen.Value);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                foreach (var item in lstHD.Items)
                {
                    string loai;
                    if (!_cTamThu.CheckBySoHoaDon(item.ToString(), out loai))
                    {
                        MessageBox.Show("Hóa Đơn không có Tạm Thu: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstHD.SelectedItem = item;
                        return;
                    }
                    if (loai == "Quầy")
                    {
                        MessageBox.Show("Hóa Đơn có Tạm Thu(Quầy): " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstHD.SelectedItem = item;
                        return;
                    }
                    if (_cDCHD.CheckBySoHoaDon(item.ToString()))
                    {
                        MessageBox.Show("Hóa Đơn đã Rút đi Điều Chỉnh: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstHD.SelectedItem = item;
                        return;
                    }
                }
                try
                {
                    _cHoaDon.SqlBeginTransaction();
                    foreach (var item in lstHD.Items)
                        if (!_cHoaDon.DangNgan("ChuyenKhoan", item.ToString(), CNguoiDung.MaND))
                        {
                            _cHoaDon.SqlRollbackTransaction();
                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    _cHoaDon.SqlCommitTransaction();
                    lstHD.Items.Clear();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    _cHoaDon.SqlRollbackTransaction();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (dgvHDDaThu.RowCount > 0)
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        try
                        {
                            _cHoaDon.SqlBeginTransaction();
                            foreach (DataGridViewRow item in dgvHDDaThu.SelectedRows)
                            {
                                if (!_cHoaDon.XoaDangNgan("ChuyenKhoan", item.Cells["SoHoaDon"].Value.ToString(), CNguoiDung.MaND))
                                {
                                    _cHoaDon.SqlRollbackTransaction();
                                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            _cHoaDon.SqlCommitTransaction();
                            if (dgvHDDaThu.RowCount > 0)
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            _cHoaDon.SqlRollbackTransaction();
                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void lstHD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstHD.Items.Count > 0 && lstHD.SelectedIndex!=-1)
                lstHD.Items.RemoveAt(lstHD.SelectedIndex);
        }

        private void lstHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoLuong.Text = lstHD.Items.Count.ToString();
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (dateTu.Value.Date == dateDen.Value.Date)
            {
                dsBaoCao ds = new dsBaoCao();
                DataTable dt = _cHoaDon.GetTongDangNganByMaNV_DangNganNgayDangNgans("TG", CNguoiDung.MaND, dateTu.Value, dateDen.Value);
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds.Tables["PhieuDangNgan"].NewRow();
                    dr["To"] = CNguoiDung.TenTo;
                    dr["Loai"] = "Tư Gia";
                    dr["NgayDangNgan"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                    dr["TongHD"] = item["TongHD"].ToString();
                    dr["TongGiaBan"] = item["TongGiaBan"].ToString();
                    dr["TongThueGTGT"] = item["TongThueGTGT"].ToString();
                    dr["TongPhiBVMT"] = item["TongPhiBVMT"].ToString();
                    dr["TongCong"] = item["TongCong"].ToString();
                    dr["NhanVien"] = CNguoiDung.HoTen;
                    ds.Tables["PhieuDangNgan"].Rows.Add(dr);
                }

                dt = _cHoaDon.GetTongDangNganByMaNV_DangNganNgayDangNgans("CQ", CNguoiDung.MaND, dateTu.Value, dateDen.Value);
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds.Tables["PhieuDangNgan"].NewRow();
                    dr["To"] = CNguoiDung.TenTo;
                    dr["Loai"] = "Cơ Quan";
                    dr["NgayDangNgan"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                    dr["TongHD"] = item["TongHD"].ToString();
                    dr["TongGiaBan"] = item["TongGiaBan"].ToString();
                    dr["TongThueGTGT"] = item["TongThueGTGT"].ToString();
                    dr["TongPhiBVMT"] = item["TongPhiBVMT"].ToString();
                    dr["TongCong"] = item["TongCong"].ToString();
                    dr["NhanVien"] = CNguoiDung.HoTen;
                    ds.Tables["PhieuDangNgan"].Rows.Add(dr);
                }

                rptPhieuDangNgan rpt = new rptPhieuDangNgan();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Từ Ngày = Đến Ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvHDDaThu.RowCount > 0)
            {
                CTo _cTo = new CTo();
                List<TT_To> lstTo = _cTo.GetDSHanhThu();
                DataTable[] dtTos=new DataTable[lstTo.Count];
                DataTable dt = (DataTable)dgvHDDaThu.DataSource;
                
                for (int i = 0; i < lstTo.Count; i++)
                {
                    foreach (DataColumn item in dt.Columns)
                    {
                        dtTos[i].Columns.Add(new DataColumn(item.ColumnName, item.DataType));
                    }
                }
                
                foreach (DataRow item in dt.Rows)
                    for (int i = 0; i < lstTo.Count; i++)
                        if (item["To"].ToString() == lstTo[i].TenTo)
                        {
                            dtTos[i].ImportRow(item);
                        }

                //Tạo các đối tượng Excel
                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbooks oBooks;
                //Microsoft.Office.Interop.Excel.Sheets oSheets;
                Microsoft.Office.Interop.Excel.Workbook oBook;
                Microsoft.Office.Interop.Excel.Worksheet[] oSheets = new Microsoft.Office.Interop.Excel.Worksheet[lstTo.Count];

                //Tạo mới một Excel WorkBook 
                oExcel.Visible = true;
                oExcel.DisplayAlerts = false;
                //khai báo số lượng sheet
                oExcel.Application.SheetsInNewWorkbook = lstTo.Count;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                //oSheets = oBook.Worksheets;
                //oSheetTG = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
                //oSheetCQ = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(2);

                //XuatExcel(dtTG, oSheetTG, "Tư Gia");
                //XuatExcel(dtCQ, oSheetCQ, "Cơ Quan");
            }
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

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 11];

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
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 11;

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

        private void dgvHDDaThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "GiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "ThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "PhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDDaThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDDaThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void GetNoiDungfrmTimKiem(string NoiDung)
        {
            foreach (DataGridViewRow item in dgvHDDaThu.Rows)
                if (item.Cells["DanhBo"].Value.ToString() == NoiDung)
                {
                    dgvHDDaThu.CurrentCell = item.Cells[0];
                    item.Selected = true;
                }
        }

        private void frmDangNganChuyenKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                frmTimKiem frm = new frmTimKiem();
                bool flag = false;
                foreach (var item in this.OwnedForms)
                    if (item.Name == frm.Name)
                    {
                        item.Activate();
                        flag = true;
                    }
                if (flag == false)
                {
                    frm.MyGetNoiDung = new frmTimKiem.GetNoiDung(GetNoiDungfrmTimKiem);
                    frm.Owner = this;
                    frm.Show();
                }
            }
        }

        
 
    }
}

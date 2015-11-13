using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.LinQ;
using System.Globalization;
using ThuTien.GUI.TimKiem;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmBangKe : Form
    {
        string _mnu = "mnuBangKe";
        CBangKe _cBangKe = new CBangKe();
        CNganHang _cNganHang = new CNganHang();
        CTienDu _cTienDu = new CTienDu();
        
        public frmBangKe()
        {
            InitializeComponent();
        }

        private void frmBangKe_Load(object sender, EventArgs e)
        {
            dgvBangKe.AutoGenerateColumns = false;
            dgvBangKeGroup.AutoGenerateColumns = false;
            dgvLichSuTienDu.AutoGenerateColumns = false;

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
            dateNgayLap.Value = DateTime.Now;

        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dialog.ShowDialog() == DialogResult.OK)
                        if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Excel fileExcel = new Excel(dialog.FileName);
                            DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");

                            foreach (DataRow item in dtExcel.Rows)
                                if (!string.IsNullOrEmpty(item[1].ToString()) && !string.IsNullOrEmpty(item[2].ToString()))
                                {
                                    //if (item[0].ToString().Length == 11 && _cBangKe.CheckExist(item[0].ToString(), DateTime.Now))
                                    //{
                                    //    MessageBox.Show("Danh Bộ: " + item[0].ToString() + " đã thêm trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //    continue;
                                    //}
                                    TT_BangKe bangke = new TT_BangKe();
                                    bangke.DanhBo = item[0].ToString().Trim();
                                    bangke.SoTien = int.Parse(item[1].ToString().Trim());
                                    bangke.MaNH = _cNganHang.GetMaNHByKyHieu(item[2].ToString().Trim());
                                    bangke.CreateDate = dateNgayLap.Value;
                                    bangke.CreateBy = CNguoiDung.MaND;
                                    bangke.CreateDate2 = DateTime.Now;
                                    bangke.CreateBy2 = CNguoiDung.MaND;
                                    if (_cBangKe.Them(bangke))
                                        _cTienDu.Update(bangke.DanhBo, bangke.SoTien.Value, "Bảng Kê","Thêm");
                                }
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    btnXem.PerformClick();

                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvBangKe.DataSource = _cBangKe.GetDS_BangKe_DangNgan(dateTu.Value, dateDen.Value);
            long TongSoTien = 0;
            int TongHD = 0;
            long TongCong = 0;
            if (dgvBangKe.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvBangKe.Rows)
                {
                    TongSoTien += long.Parse(item.Cells["SoTien"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["HoaDon"].Value.ToString()))
                        TongHD += int.Parse(item.Cells["HoaDon"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong"].Value.ToString());
                }
                txtTongDanhBo.Text = dgvBangKe.RowCount.ToString();
                txtTongSoTien.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongSoTien);
                txtTongHD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongCong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }

            dgvBangKeGroup.DataSource = _cBangKe.GetDS_Group(dateTu.Value, dateDen.Value);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    try
                    {
                        foreach (DataGridViewRow item in dgvBangKe.SelectedRows)
                        {
                            TT_BangKe bangke = _cBangKe.Get(int.Parse(item.Cells["MaBK"].Value.ToString()));
                            if (_cBangKe.Xoa(bangke))
                                _cTienDu.Update(bangke.DanhBo, bangke.SoTien.Value * -1, "Bảng Kê","Xóa");
                        }
                        btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int _searchIndex = -1;
        private string _searchNoiDung = "";

        private void GetNoiDungfrmTimKiem(string NoiDung)
        {
            if (_searchNoiDung != NoiDung)
                _searchIndex = -1;

            for(int i = 0; i < dgvBangKe.Rows.Count; i++)
            {
                if (_searchNoiDung != NoiDung)
                    _searchNoiDung = NoiDung;

                _searchIndex = (_searchIndex + 1) % dgvBangKe.Rows.Count;
                DataGridViewRow row = dgvBangKe.Rows[_searchIndex];
                if (row.Cells["DanhBo"].Value == null || row.Cells["SoTien"].Value == null)
                {
                    continue;
                }
                if (row.Cells["DanhBo"].Value.ToString() == NoiDung || row.Cells["SoTien"].Value.ToString() == NoiDung)
                {
                    dgvBangKe.CurrentCell = row.Cells["DanhBo"];
                    dgvBangKe.Rows[_searchIndex].Selected = true;
                    return;
                }
            }
        }

        private void dgvBangKe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBangKe.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && e.Value.ToString().Length==11)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvBangKe.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvBangKe.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvBangKe_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvBangKe.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvBangKe_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvBangKe.Columns[e.ColumnIndex].Name == "DanhBo" && e.FormattedValue.ToString().Replace(" ", "") != dgvBangKe[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TT_BangKe bangke = _cBangKe.Get(int.Parse(dgvBangKe["MaBK", e.RowIndex].Value.ToString()));
                    bangke.DanhBo = e.FormattedValue.ToString().Replace(" ", "");
                    if (_cBangKe.Sua(bangke))
                    {
                        _cTienDu.Update(dgvBangKe[e.ColumnIndex, e.RowIndex].Value.ToString().Replace(" ", ""), bangke.SoTien.Value * -1, "Bảng Kê","Sửa Từ Danh Bộ");
                        _cTienDu.Update(bangke.DanhBo, bangke.SoTien.Value, "Bảng Kê", "Sửa Đến Danh Bộ");
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBangKe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                frmTimKiemForm frm = new frmTimKiemForm();
                bool flag = false;
                foreach (var item in this.OwnedForms)
                    if (item.Name == frm.Name)
                    {
                        item.Activate();
                        flag = true;
                    }
                if (flag == false)
                {
                    frm.MyGetNoiDung = new frmTimKiemForm.GetNoiDung(GetNoiDungfrmTimKiem);
                    frm.Owner = this;
                    frm.Show();
                }
            }
        }

        private void dgvBangKeGroup_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBangKeGroup.Columns[e.ColumnIndex].Name == "TongCong_Group" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvBangKeGroup_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvBangKeGroup.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Length == 11)
            {
                dgvLichSuTienDu.DataSource = _cTienDu.GetDSLichSu(txtDanhBo.Text.Trim().Replace(" ",""));
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

            XuatExcel(dt, oSheet, "LỊCH SỬ",txtDanhBo.Text.Trim());
        }

        private void XuatExcel(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName,string DanhBo)
        {
            oSheet.Name = SheetName;

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "F1");
            head.MergeCells = true;
            head.Value2 = "LỊCH SỬ GIAO DỊCH DANH BỘ " + DanhBo;
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

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 3];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = dr["CreateDate"].ToString();
                arr[i, 1] = dr["SoTien"].ToString();
                arr[i, 2] = dr["Loai"].ToString();
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
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
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

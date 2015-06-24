﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.Quay;
using System.Globalization;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.DAL.TongHop;
using ThuTien.BaoCao;
using ThuTien.BaoCao.ChuyenKhoan;
using KTKS_DonKH.GUI.BaoCao;
using System.Data.OleDb;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmTamThuChuyenKhoan : Form
    {
        string _mnu = "mnuTamThuChuyenKhoan";
        CHoaDon _cHoaDon = new CHoaDon();
        CTamThu _cTamThu = new CTamThu();
        CNganHang _cNganHang = new CNganHang();
        CDCHD _cDCHD = new CDCHD();

        public frmTamThuChuyenKhoan()
        {
            InitializeComponent();
        }

        private void frmTamThuChuyenKhoan_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvTamThu.AutoGenerateColumns = false;
            cmbNganHang.DataSource = _cNganHang.GetDS();
            cmbNganHang.DisplayMember = "TenNH";
            cmbNganHang.ValueMember = "MaNH";
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            dgvHoaDon.DataSource = null;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim()) && e.KeyChar == 13)
            {
                DataTable dt = new DataTable();
                foreach (string item in txtDanhBo.Lines)
                    if (item.Length == 11)
                    {
                        dt.Merge(_cHoaDon.GetDSTonByDanhBo(item));
                    }
                dgvHoaDon.DataSource = dt;
                for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
                {
                    dgvHoaDon["Chon", i].Value = true;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvHoaDon.Rows)
                if (item.Cells["Chon"].Value!=null&&bool.Parse(item.Cells["Chon"].Value.ToString()))
                {
                    if (_cTamThu.CheckBySoHoaDon(item.Cells["SoHoaDon"].Value.ToString()))
                    {
                        MessageBox.Show("Hóa Đơn này đã Tạm Thu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        item.Selected = true;
                        return;
                    }
                    if (_cDCHD.CheckBySoHoaDon(item.Cells["SoHoaDon"].Value.ToString()))
                    {
                        MessageBox.Show("Hóa Đơn này đã Rút đi Điều Chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        item.Selected = true;
                        return;
                    }
                }

            try
            {
                _cTamThu.BeginTransaction();
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
                    if (item.Cells["Chon"].Value != null && bool.Parse(item.Cells["Chon"].Value.ToString()))
                    {
                        TAMTHU tamthu = new TAMTHU();
                        tamthu.DANHBA = item.Cells["DanhBo"].Value.ToString();
                        tamthu.FK_HOADON = int.Parse(item.Cells["MaHD"].Value.ToString());
                        tamthu.SoHoaDon = item.Cells["SoHoaDon"].Value.ToString();
                        tamthu.ChuyenKhoan = true;
                        tamthu.MaNH = int.Parse(cmbNganHang.SelectedValue.ToString());

                        if (!_cTamThu.Them(tamthu))
                        {
                            _cTamThu.Rollback();
                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                _cTamThu.CommitTransaction();
                Clear();
                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                _cTamThu.Rollback();
                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dateTu.Value <= dateDen.Value)
            {
                dgvTamThu.DataSource = _cTamThu.GetDSByDates(true, CNguoiDung.MaND, dateTu.Value, dateDen.Value);
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabThongTin")
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = false;
            }
            else
                if (tabControl.SelectedTab.Name == "tabTamThu")
                {
                    btnThem.Enabled = false;
                    btnXoa.Enabled = true;
                }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _cTamThu.BeginTransaction();
                    foreach (DataGridViewRow item in dgvTamThu.SelectedRows)
                    {
                        TAMTHU tamthu = _cTamThu.GetByMaTT(int.Parse(item.Cells["MaTT"].Value.ToString()));
                        if (!_cHoaDon.CheckDangNganBySoHoaDon(tamthu.SoHoaDon))
                        {
                            if (!_cTamThu.Xoa(tamthu))
                            {
                                _cTamThu.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            _cTamThu.Rollback();
                            dgvTamThu.ClearSelection();
                            item.Selected = true;
                            MessageBox.Show("Hóa đơn đã Đăng Ngân", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    _cTamThu.CommitTransaction();
                    btnXem.PerformClick();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "GiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "ThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "PhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTamThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "DanhBo_TT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "TieuThu_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "GiaBan_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "ThueGTGT_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "PhiBVMT_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "TongCong_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "MaNH_TT" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = _cNganHang.GetByMaNH(int.Parse(e.Value.ToString())).NGANHANG1;
            }
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvTamThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTamThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnInTamThu_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvTamThu.Rows)
            {
                DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["DanhBo"] = item.Cells["DanhBo_TT"].Value.ToString().Insert(4, " ").Insert(8, " ");
                dr["HoTen"] = item.Cells["HoTen_TT"].Value.ToString();
                dr["MLT"] = item.Cells["MLT_TT"].Value.ToString();
                dr["Ky"] = item.Cells["Ky_TT"].Value.ToString();
                dr["TongCong"] = item.Cells["TongCong_TT"].Value.ToString();
                dr["NhanVien"] = item.Cells["HanhThu_TT"].Value.ToString();
                dr["To"] = item.Cells["To_TT"].Value.ToString();
                ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
            }
            rptDSTamThuChuyenKhoan rpt = new rptDSTamThuChuyenKhoan();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Excel fileExcel = new Excel(dialog.FileName);
                DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");

                DataTable dt = new DataTable();
                foreach (DataRow item in dtExcel.Rows)
                    if (item[0].ToString().Length == 11)
                    {
                        dt.Merge(_cHoaDon.GetDSTonByDanhBo(item[0].ToString()));
                    }
                dgvHoaDon.DataSource = dt;

                foreach (DataRow itemExcel in dtExcel.Rows)
                {
                    string ChenhLech = "";
                    int SoTien = 0;
                    DataRow[] dr = dt.Select("DanhBo like '" + itemExcel[0].ToString() + "'");
                    foreach (DataRow itemRow in dr)
                    {
                        SoTien += int.Parse(itemRow["TongCong"].ToString());
                    }
                    if (int.Parse(itemExcel[1].ToString()) > SoTien)
                    {
                        ChenhLech = "Dư: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",(int.Parse(itemExcel[1].ToString()) - SoTien));
                        foreach (DataGridViewRow itemRow in dgvHoaDon.Rows)
                            if (itemRow.Cells["DanhBo"].Value.ToString() == itemExcel[0].ToString())
                            {
                                itemRow.Cells["ChenhLech"].Value = ChenhLech;
                                itemRow.DefaultCellStyle.BackColor = Color.GreenYellow;
                            }
                    }
                    else
                        if (int.Parse(itemExcel[1].ToString()) < SoTien)
                        {
                            ChenhLech = "Thiếu: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",(int.Parse(itemExcel[1].ToString()) - SoTien));
                            foreach (DataGridViewRow itemRow in dgvHoaDon.Rows)
                                if (itemRow.Cells["DanhBo"].Value.ToString() == itemExcel[0].ToString())
                                {
                                    itemRow.Cells["ChenhLech"].Value = ChenhLech;
                                    itemRow.DefaultCellStyle.BackColor = Color.Red;
                                }
                        }
                }
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
                {
                    item.Cells["Chon"].Value = true;
                }
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvTamThu.RowCount > 0)
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
                //khai báo số lượng sheet
                oExcel.Application.SheetsInNewWorkbook = 1;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;
                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
                oSheet.Name = "Sheet1";

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
                cl5.Value2 = "Tổng Cộng";
                cl5.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F1", "F1");
                cl6.Value2 = "Hành Thu";
                cl6.ColumnWidth = 30;

                // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
                // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
                object[,] arr = new object[dgvTamThu.RowCount, 6];

                //Chuyển dữ liệu từ DataTable vào mảng đối tượng
                for (int i = 0; i < dgvTamThu.RowCount; i++)
                {
                    DataGridViewRow dr = dgvTamThu.Rows[i];

                    arr[i, 0] = dr.Cells["SoHoaDon_TT"].Value.ToString();
                    arr[i, 1] = dr.Cells["Ky_TT"].Value.ToString();
                    arr[i, 2] = dr.Cells["DanhBo_TT"].Value.ToString();
                    arr[i, 3] = dr.Cells["HoTen_TT"].Value.ToString();
                    arr[i, 4] = dr.Cells["TongCong_TT"].Value.ToString();
                    arr[i, 5] = dr.Cells["HanhThu_TT"].Value.ToString() + ", " + dr.Cells["To_TT"].Value.ToString();
                }

                //Thiết lập vùng điền dữ liệu
                int rowStart = 2;
                int columnStart = 1;

                int rowEnd = rowStart + dgvTamThu.RowCount - 1;
                int columnEnd = 6;

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

                Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
                Microsoft.Office.Interop.Excel.Range c2e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
                Microsoft.Office.Interop.Excel.Range c3e = oSheet.get_Range(c1e, c2e);
                oSheet.get_Range(c2e, c3e).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                Microsoft.Office.Interop.Excel.Range c1f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 6];
                Microsoft.Office.Interop.Excel.Range c2f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 6];
                Microsoft.Office.Interop.Excel.Range c3f = oSheet.get_Range(c1f, c2f);
                oSheet.get_Range(c2f, c3f).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                //Điền dữ liệu vào vùng đã thiết lập
                range.Value2 = arr;
            }
        }
    }
}

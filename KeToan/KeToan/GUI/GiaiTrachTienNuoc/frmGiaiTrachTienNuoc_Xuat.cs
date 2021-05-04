using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KeToan.DAL.QuanTri;
using Microsoft.Office.Interop.Excel;
using KeToan.LinQ;
using System.Runtime.InteropServices;
using System.Globalization;
using KeToan.DAL.GiaiTrachTienNuoc;

namespace KeToan.GUI.GiaiTrachTienNuoc
{
    public partial class frmGiaiTrachTienNuoc_Xuat : Form
    {
        string _mnu = "mnuGiaiTrachTienNuoc_Xuat";
        CGiaiTrachTienNuoc_Xuat _cGTTN_Xuat = new CGiaiTrachTienNuoc_Xuat();
        CGiaiTrachTienNuoc_Nhap _cGTTN_Nhap = new CGiaiTrachTienNuoc_Nhap();

        public frmGiaiTrachTienNuoc_Xuat()
        {
            InitializeComponent();
        }

        private void frmGiaiTrachTienNuoc_Xuat_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvHoaDon.DataSource = _cGTTN_Xuat.getDS(dateTu.Value, dateDen.Value);
                decimal TongCong = 0;
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
                {
                    TongCong += decimal.Parse(item.Cells["TongCong"].Value.ToString());
                }
                txtTong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHoaDon.RowCount);
                txtTongCong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                if (CUser.CheckQuyen(_mnu, "Them"))
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dialog.ShowDialog() == DialogResult.OK)
                        if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Microsoft.Office.Interop.Excel.Application _excelApp = new Microsoft.Office.Interop.Excel.Application();
                            _excelApp.Visible = true;

                            //open the workbook
                            Workbook workbook = _excelApp.Workbooks.Open(dialog.FileName,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing);

                            //select the first sheet        
                            Worksheet worksheet = (Worksheet)workbook.Worksheets[1];

                            //find the used range in worksheet
                            Range excelRange = worksheet.UsedRange;

                            //get an object array of all of the cells in the worksheet (their values)
                            object[,] valueArray = (object[,])excelRange.get_Value(XlRangeValueDataType.xlRangeValueDefault);

                            //access the cells
                            for (int row = 7; row <= worksheet.UsedRange.Rows.Count; ++row)
                                if (valueArray[row, 6] != null && valueArray[row, 6].ToString() != "" && valueArray[row, 12] != null && int.Parse(valueArray[row, 12].ToString()) > 0)
                                {
                                    GiaiTrachTienNuoc_Xuat en = new GiaiTrachTienNuoc_Xuat();
                                    error = en.ID.ToString();
                                    en.HoTen = valueArray[row, 2].ToString();
                                    en.DanhBo = valueArray[row, 3].ToString();
                                    en.Ky = int.Parse(valueArray[row, 6].ToString());
                                    if (valueArray[row, 7].ToString() != "")
                                        en.NgayPhieuThu = DateTime.Parse(valueArray[row, 7].ToString());
                                    if (valueArray[row, 8].ToString() != "")
                                        en.SoPhieuThu = valueArray[row, 8].ToString();
                                    if (valueArray[row, 9].ToString() != "")
                                        en.GiaBan = int.Parse(valueArray[row, 9].ToString());
                                    if (valueArray[row, 10].ToString() != "")
                                        en.ThueGTGT = int.Parse(valueArray[row, 10].ToString());
                                    if (valueArray[row, 11].ToString() != "")
                                        en.PhiBVMT = int.Parse(valueArray[row, 11].ToString());
                                    en.TongCong = int.Parse(valueArray[row, 12].ToString());
                                    en.NgayGiaiTrach = DateTime.Parse(valueArray[1, 1].ToString().Substring(valueArray[1, 1].ToString().LastIndexOf(" "), 11));
                                    try
                                    {
                                        en.IDNhap = _cGTTN_Nhap.get(en.SoPhieuThu, en.NgayPhieuThu.Value, en.DanhBo).ID;
                                    }
                                    catch
                                    {
                                        throw new Exception("Không có SPT tại STT: " + valueArray[row, 1].ToString());
                                    }
                                    //if (_cGTTN.checkExists(en.SoPhieuThu, en.NgayPhieuThu.Value, en.DanhBo, en.Ky.Value) == false)
                                    _cGTTN_Xuat.Them(en);
                                }

                            //clean up stuffs
                            workbook.Close(false, Type.Missing, Type.Missing);
                            Marshal.ReleaseComObject(worksheet);
                            Marshal.ReleaseComObject(workbook);

                            _excelApp.Quit();
                            Marshal.FinalReleaseComObject(_excelApp);
                            GC.Collect();
                            GC.WaitForPendingFinalizers();

                            MessageBox.Show("Đã xử lý xong, Vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXem.PerformClick();
                        }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nLỗi tại STT: " +error, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        foreach (DataGridViewRow item in dgvHoaDon.SelectedRows)
                        {
                            _cGTTN_Xuat.Xoa(item.Cells["ID"].Value.ToString());
                        }
                        MessageBox.Show("Đã xử lý xong, Vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnXem.PerformClick();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}

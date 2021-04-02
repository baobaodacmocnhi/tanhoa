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
        CGiaiTrachTienNuoc_Xuat _cGTTN = new CGiaiTrachTienNuoc_Xuat();

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
                dgvHoaDon.DataSource = _cGTTN.getDS(dateTu.Value, dateDen.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
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
                            _excelApp.Visible = false;

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
                                if (valueArray[row, 1].ToString() != "")
                                {
                                    GiaiTrachTienNuoc_Xuat en = new GiaiTrachTienNuoc_Xuat();

                                    en.DanhBo = valueArray[row, 3].ToString();
                                    en.Ky = int.Parse(valueArray[row, 6].ToString());
                                    en.NgayPhieuThu = DateTime.Parse(valueArray[row, 7].ToString());
                                    en.SoPhieuThu = valueArray[row, 8].ToString();
                                    en.GiaBan = int.Parse(valueArray[row, 9].ToString());
                                    en.ThueGTGT = int.Parse(valueArray[row, 10].ToString());
                                    en.PhiBVMT = int.Parse(valueArray[row, 11].ToString());
                                    en.TongCong = int.Parse(valueArray[row, 12].ToString());
                                    en.NgayGiaiTrach = DateTime.Parse(valueArray[1, 1].ToString().Substring(valueArray[1, 1].ToString().LastIndexOf(" "),10));

                                    if (_cGTTN.checkExists(en.SoPhieuThu, en.NgayPhieuThu.Value, en.DanhBo, en.Ky.Value) == false)
                                        _cGTTN.Them(en);
                                }

                            //clean up stuffs
                            workbook.Close(false, Type.Missing, Type.Missing);
                            Marshal.ReleaseComObject(workbook);

                            _excelApp.Quit();
                            Marshal.FinalReleaseComObject(_excelApp);

                            MessageBox.Show("Đã xử lý xong, Vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXem.PerformClick();
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
                            _cGTTN.Xoa(item.Cells["ID"].Value.ToString());
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
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
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

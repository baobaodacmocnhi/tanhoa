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
using System.Runtime.InteropServices;
using KeToan.LinQ;
using KeToan.DAL.GiaiTrachTienNuoc;
using System.Globalization;

namespace KeToan.GUI.GiaiTrachTienNuoc
{
    public partial class frmGiaiTrachTienNuoc_Nhap : Form
    {
        string _mnu = "mnuGiaiTrachTienNuoc_Nhap";
        CGiaiTrachTienNuoc_Nhap _cGTTN = new CGiaiTrachTienNuoc_Nhap();
        Microsoft.Office.Interop.Excel.Application _excelApp;
        Workbook workbook;
        Worksheet worksheet;

        public frmGiaiTrachTienNuoc_Nhap()
        {
            InitializeComponent();
        }

        private void frmGiaiTrachTienNuoc_Nhap_Load(object sender, EventArgs e)
        {
            gridControl.LevelTree.Nodes.Add("Chi Tiết", gridViewChiTiet);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkTon.Checked == true)
                    gridControl.DataSource = _cGTTN.getDS_Ton().Tables["PhieuThu"];
                else
                    gridControl.DataSource = _cGTTN.getDS(dateTu.Value, dateDen.Value).Tables["PhieuThu"];
                decimal TongCong = 0, TongCongTon = 0;
                for (int i = 0; i < gridView.DataRowCount; i++)
                {
                    DataRow row = gridView.GetDataRow(i);
                    TongCong += decimal.Parse(row["SoTien"].ToString());
                    if(row["SoTien"]!=null && row["SoTien"].ToString()!="")
                        TongCongTon += decimal.Parse(row["SoTienTon"].ToString());
                }
                //dgvHoaDon.DataSource = _cGTTN.getDS(dateTu.Value, dateDen.Value);
                //decimal TongCong = 0;
                //foreach (DataGridViewRow item in dgvHoaDon.Rows)
                //{
                //    TongCong += decimal.Parse(item.Cells["SoTien"].Value.ToString());
                //}
                txtTong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", gridView.DataRowCount);
                txtTongCong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongCongTon.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTon);
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
                            _excelApp = new Microsoft.Office.Interop.Excel.Application();
                            _excelApp.Visible = false;

                            //open the workbook
                            workbook = _excelApp.Workbooks.Open(dialog.FileName,
                               Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                               Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                               Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                               Type.Missing, Type.Missing);

                            //select the first sheet        
                            worksheet = (Worksheet)workbook.Worksheets[1];

                            //find the used range in worksheet
                            Range excelRange = worksheet.UsedRange;

                            //get an object array of all of the cells in the worksheet (their values)
                            object[,] valueArray = (object[,])excelRange.get_Value(XlRangeValueDataType.xlRangeValueDefault);

                            //access the cells
                            for (int row = 8; row <= worksheet.UsedRange.Rows.Count; ++row)
                                if (valueArray[row, 1] != null && valueArray[row, 1].ToString() != "")
                                {
                                    GiaiTrachTienNuoc_Nhap en = new GiaiTrachTienNuoc_Nhap();
                                    en.NgayPhieuThu = DateTime.Parse(valueArray[row, 1].ToString());
                                    en.SoPhieuThu = valueArray[row, 2].ToString();
                                    en.DanhBo = valueArray[row, 3].ToString();
                                    en.NganHang = valueArray[row, 4].ToString();
                                    en.SoTien = int.Parse(valueArray[row, 6].ToString());
                                    if (_cGTTN.checkExists(en.SoPhieuThu, en.NgayPhieuThu.Value, en.DanhBo) == false)
                                        _cGTTN.Them(en);
                                }

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
            finally
            {
                //clean up stuffs
                Marshal.ReleaseComObject(worksheet);
                workbook.Close(false, Type.Missing, Type.Missing);
                Marshal.ReleaseComObject(workbook);

                _excelApp.Quit();
                Marshal.FinalReleaseComObject(_excelApp);
                GC.Collect();
                GC.WaitForPendingFinalizers();
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
                        //foreach (DataGridViewRow item in dgvHoaDon.SelectedRows)
                        //{
                        //    _cGTTN.Xoa(item.Cells["ID"].Value.ToString());
                        //}
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
            //if (dgvHoaDon.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            //{
            //    e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            //}
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            //{
            //    e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            //}
        }

        private void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "SoTien" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (e.Column.FieldName == "SoTienTon" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridViewChiTiet_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "SoTien_CT" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }


    }
}

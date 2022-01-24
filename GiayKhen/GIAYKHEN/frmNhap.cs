using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GIAYKHEN
{
    public partial class frmNhap : Form
    {
        GKDataContext _db = new GKDataContext();

        public frmNhap()
        {
            InitializeComponent();
        }

        private void btnCongDoan_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                    if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        DataTable dtExcel = ExcelToDataTable(dialog.FileName);
                        string PhongBan = "";
                        for (int i = 0; i < dtExcel.Rows.Count; i++)
                            if (!string.IsNullOrEmpty(dtExcel.Rows[i][0].ToString().Trim()))
                            {
                                A_GIAYKHEN en = new A_GIAYKHEN();
                                en.HOTEN = dtExcel.Rows[i][0].ToString().Trim();
                                en.CHUCVU = dtExcel.Rows[i][1].ToString().Trim().ToUpper();
                                en.PHONGBAN = dtExcel.Rows[i][2].ToString().Trim().ToUpper();
                                en.CongDoan = true;
                                _db.A_GIAYKHENs.InsertOnSubmit(en);
                                _db.SubmitChanges();
                            }
                            else
                            {
                                PhongBan = dtExcel.Rows[i][2].ToString().Trim();
                            }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable ExcelToDataTable(string path)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = null;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = null;
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = null;
            DataTable dt = new DataTable();
            try
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(path);
                xlWorksheet = xlWorkbook.Worksheets[1];

                int rows = xlWorksheet.UsedRange.Rows.Count;
                int cols = xlWorksheet.UsedRange.Columns.Count;

                int noofrow = 1;

                for (int c = 1; c <= cols; c++)
                {
                    //string colname = xlWorksheet.Cells[1, c].Text;
                    //dt.Columns.Add(colname);
                    dt.Columns.Add(c.ToString());
                    noofrow = 2;
                }

                for (int r = noofrow; r <= rows; r++)
                {
                    DataRow dr = dt.NewRow();
                    for (int c = 1; c <= cols; c++)
                    {
                        dr[c - 1] = xlWorksheet.Cells[r, c].Value;
                    }

                    dt.Rows.Add(dr);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                //release com objects to fully kill excel process from running in the background
                //if (xlRange != null)
                //{
                //    Marshal.ReleaseComObject(xlRange);
                //}

                if (xlWorksheet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorksheet);
                }

                //close and release
                if (xlWorkbook != null)
                {
                    xlWorkbook.Close();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
                }

                //quit and release
                if (xlApp != null)
                {
                    xlApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return dt;
        }

        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        private void btnCongTy_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                    if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        DataTable dtExcel = ExcelToDataTable(dialog.FileName);
                        string PhongBan = "";
                        for (int i = 16; i < dtExcel.Rows.Count; i++)
                            if (!string.IsNullOrEmpty(dtExcel.Rows[i][0].ToString().Trim()) && IsNumeric(dtExcel.Rows[i][0].ToString().Trim()))
                            {
                                A_GIAYKHEN en = new A_GIAYKHEN();
                                en.HOTEN = dtExcel.Rows[i][1].ToString().Trim();
                                en.CHUCVU = dtExcel.Rows[i][3].ToString().Trim().ToUpper();
                                en.PHONGBAN = dtExcel.Rows[i][2].ToString().Trim().ToUpper();
                                if (dtExcel.Rows[i][4].ToString().Trim() == "Nữ")
                                    en.GioiTinh = false;
                                else
                                    en.GioiTinh = true;
                                _db.A_GIAYKHENs.InsertOnSubmit(en);
                                _db.SubmitChanges();
                            }
                            else
                            {
                                PhongBan = dtExcel.Rows[i][2].ToString().Trim();
                            }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDoanThanhNien_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                    if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        DataTable dtExcel = ExcelToDataTable(dialog.FileName);
                        string PhongBan = "";
                        for (int i = 16; i < dtExcel.Rows.Count; i++)
                            if (!string.IsNullOrEmpty(dtExcel.Rows[i][0].ToString().Trim()) && IsNumeric(dtExcel.Rows[i][0].ToString().Trim()))
                            {
                                A_GIAYKHEN en = new A_GIAYKHEN();
                                en.HOTEN = dtExcel.Rows[i][1].ToString().Trim();
                                en.CHUCVU = dtExcel.Rows[i][3].ToString().Trim().ToUpper();
                                en.PHONGBAN = dtExcel.Rows[i][2].ToString().Trim().ToUpper();
                                if (dtExcel.Rows[i][4].ToString().Trim() == "Nữ")
                                    en.GioiTinh = false;
                                else
                                    en.GioiTinh = true;
                                _db.A_GIAYKHENs.InsertOnSubmit(en);
                                _db.SubmitChanges();
                            }
                            else
                            {
                                PhongBan = dtExcel.Rows[i][2].ToString().Trim();
                            }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}

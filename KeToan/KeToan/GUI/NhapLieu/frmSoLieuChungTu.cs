using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using KeToan.BaoCao;
using KeToan.BaoCao.NhapLieu;
using KeToan.GUI.BaoCao;
using CrystalDecisions.CrystalReports.Engine;

namespace KeToan.GUI.NhapLieu
{
    public partial class frmSoLieuChungTu : Form
    {
        public frmSoLieuChungTu()
        {
            InitializeComponent();
        }

        private void frmSoLieuChungTu_Load(object sender, EventArgs e)
        {

        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                dialog.Multiselect = false;
                
                if (dialog.ShowDialog() == DialogResult.OK)
                    if (MessageBox.Show("Bạn có chắc chắn In?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        dsBaoCao ds = new dsBaoCao();
                        //Create COM Objects. Create a COM object for everything that is referenced
                        Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(dialog.FileName);
                        Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                        Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

                        int rowCount = xlRange.Rows.Count;
                        int colCount = xlRange.Columns.Count;

                        //iterate over the rows and columns and print to the console as it appears in the file
                        //excel is not zero based!!
                        for (int i = 13; i <= rowCount; i++)
                        {
                            if (xlRange.Cells[i, 3] != null && xlRange.Cells[i, 3].Value2 != null && !string.IsNullOrEmpty(xlRange.Cells[i, 3].Value2.ToString()))
                            {
                                DataRow dr = ds.Tables["HoaDonDienTu"].NewRow();
                                dr["ID"] = cmbNganHang.SelectedItem.ToString();
                                dr["NoiDung"] = xlRange.Cells[i, 3].Value2.ToString();
                                ds.Tables["HoaDonDienTu"].Rows.Add(dr);
                            }
                        }

                        //cleanup
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        //rule of thumb for releasing com objects:
                        //  never use two dots, all COM objects must be referenced and released individually
                        //  ex: [somthing].[something].[something] is bad
                        //release com objects to fully kill excel process from running in the background
                        Marshal.ReleaseComObject(xlRange);
                        Marshal.ReleaseComObject(xlWorksheet);
                        //close and release
                        xlWorkbook.Close();
                        Marshal.ReleaseComObject(xlWorkbook);
                        //quit and release
                        xlApp.Quit();
                        Marshal.ReleaseComObject(xlApp);

                        ReportDocument rpt;
                        if (cmbNganHang.SelectedItem.ToString() == "KB")
                            rpt = new rptSLCT_A4();
                        else
                            rpt = new rptSLCT_A5();
                        rpt.SetDataSource(ds);
                        frmBaoCao frm = new frmBaoCao(rpt);
                        frm.ShowDialog();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

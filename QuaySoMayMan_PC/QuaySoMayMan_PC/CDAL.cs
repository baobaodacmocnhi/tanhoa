using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace QuaySoMayMan_PC
{
    class CDAL
    {
        string strConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + AppDomain.CurrentDomain.BaseDirectory + "\\quaysomayman.accdb;Persist Security Info=True";
        OleDbConnection oleConnection;
        public static DataTable _dtExcel = new DataTable();

        public CDAL()
        {
            oleConnection = new OleDbConnection(strConnection);
        }

        public bool ExecuteNonQuery(string sql)
        {
            oleConnection.Open();
            OleDbCommand oldCommand = new OleDbCommand(sql, oleConnection);
            int rowsAffected = oldCommand.ExecuteNonQuery();
            oleConnection.Close();
            if (rowsAffected >= 1)
                return true;
            else
                return false;
        }

        public bool update_Quay(int STT)
        {
            return ExecuteNonQuery("update KhachMoi set Quay=true where STT='" + STT + "'");
        }

        public bool update_ResetQuay()
        {
            return ExecuteNonQuery("update KhachMoi set Quay=false");
        }

        public bool update_ResetQuay(int STT)
        {
            return ExecuteNonQuery("update KhachMoi set Quay=false where STT='" + STT + "'");
        }

        public DataTable get_KhachMoi(int STT)
        {
            OleDbDataAdapter oldAdapter = new OleDbDataAdapter("select * from KhachMoi where STT='" + STT + "'", oleConnection);
            oleConnection.Open();
            DataTable dt = new DataTable();
            oldAdapter.Fill(dt);
            oleConnection.Close();
            return dt;
        }

        public DataTable getDS_KhachMoi()
        {
            OleDbDataAdapter oldAdapter = new OleDbDataAdapter("select * from KhachMoi", oleConnection);
            oleConnection.Open();
            DataTable dt = new DataTable();
            oldAdapter.Fill(dt);
            oleConnection.Close();
            return dt;
        }

        public DataTable getDS_KhachMoi_ChuaQuay()
        {
            OleDbDataAdapter oldAdapter = new OleDbDataAdapter("select * from KhachMoi where Quay=false", oleConnection);
            oleConnection.Open();
            DataTable dt = new DataTable();
            oldAdapter.Fill(dt);
            oleConnection.Close();
            return dt;
        }

        public bool checkExist(int STT)
        {
            OleDbCommand oldCommand = new OleDbCommand("select count(*) from KhachMoi where STT='" + STT + "'", oleConnection);
            oleConnection.Open();
            object result = oldCommand.ExecuteScalar();
            oleConnection.Close();
            if ((int)result >= 1)
                return true;
            else
                return false;
        }

        public bool checkExist_Quay(int STT)
        {
            OleDbCommand oldCommand = new OleDbCommand("select count(*) from KhachMoi where STT='" + STT + "' and Quay=true", oleConnection);
            oleConnection.Open();
            object result = oldCommand.ExecuteScalar();
            oleConnection.Close();
            if ((int)result >= 1)
                return true;
            else
                return false;
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
                    string colname = xlWorksheet.Cells[1, c].Text;
                    dt.Columns.Add(colname);
                    //dt.Columns.Add(c.ToString());
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
                    xlWorkbook.Close(false, Type.Missing, Type.Missing);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
                }

                //quit and release
                if (xlApp != null)
                {
                    xlApp.Quit();
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlApp);
                }
                System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
                foreach (System.Diagnostics.Process p in process)
                {
                    if (!string.IsNullOrEmpty(p.ProcessName))
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch { }
                    }
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return dt;
        }

    }
}

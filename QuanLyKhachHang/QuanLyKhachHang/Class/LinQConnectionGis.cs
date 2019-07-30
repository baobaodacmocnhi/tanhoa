using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Data;
using System.Data.SqlClient;
using QuanLyKhachHang.DataBase;

namespace QuanLyKhachHang.Class
{
    public static class LinQConnectionGis
    {
        static log4net.ILog log = log4net.LogManager.GetLogger("File");

      

        public static DataTable getDataTable(string sql)
        {
            DataTable table = new DataTable();
            GISDataContext db = new GISDataContext();
            try
            {
                db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            return table;
        }
    }
}
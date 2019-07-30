using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BaoCao_Web.DataBase;
using System.Data.SqlClient;

namespace BaoCao_Web.Class
{
    public class C_tab_BaoCao
    {

        static log4net.ILog log = log4net.LogManager.GetLogger("File");
        public static DataSet tb_Report(string query, string table)
        {
            DataSet ds = new DataSet();
            ThuTienDataContext db = new ThuTienDataContext();
            db.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, table);
            return ds;
        }
        public static DataSet tb_Report2(string query, string table)
        {
            DataSet ds = new DataSet();
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, table);
            return ds;
        }
        public static DataSet tb_Report(string query1, string table1, string query2, string table2)
        {
            DataSet ds = new DataSet();
            ThuTienDataContext db = new ThuTienDataContext();
            db.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query1, db.Connection.ConnectionString);
            adapter.Fill(ds, table1);

            adapter = new SqlDataAdapter(query2, db.Connection.ConnectionString);
            adapter.Fill(ds, table2);

            return ds;
        }
    }
}

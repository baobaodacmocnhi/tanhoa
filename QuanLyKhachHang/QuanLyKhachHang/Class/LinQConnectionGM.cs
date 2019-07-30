using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using QuanLyKhachHang.DataBase;
using System.Data;
using log4net;

namespace QuanLyKhachHang.Class
{
    public static class LinQConnectionGM
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LinQConnection).Name);

        public static int ExecuteCommand(string sql)
        {
            int result = 0;
            GanMoiDataContext db = new GanMoiDataContext();
            try
            {
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {
                log.Error("LinQConnection ExecuteCommand : " + sql);
                log.Error("LinQConnection ExecuteCommand : " + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            db.SubmitChanges();
            return result;
        }

        public static int ExecuteCommand_(string sql)
        {
            int result = 0;
            GanMoiDataContext db = new GanMoiDataContext();
            try
            {
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {
                log.Error("LinQConnection ExecuteCommand_ : " + sql);
                log.Error("LinQConnection ExecuteCommand_ : " + ex.Message);

            }
            finally
            {
                db.Connection.Close();
            }
            db.SubmitChanges();
            return result;
        }
        public static DataTable getDataTable(string sql)
        {
            DataTable table = new DataTable();
            GanMoiDataContext db = new GanMoiDataContext();
            try
            {
                if (db.Connection.State == ConnectionState.Open)
                {
                    db.Connection.Close();
                }
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

        public static DataTable getDataTable(string sql, int FirstRow, int pageSize)
        {
            GanMoiDataContext db = new GanMoiDataContext();
            try
            {
                if (db.Connection.State == ConnectionState.Open)
                {
                    db.Connection.Close();
                }
                db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
                db.Connection.Close();
                return dataset.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            return null;
        }

      
       
    }
}
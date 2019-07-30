using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Data;
using System.Data.SqlClient;
using DHCD_KiemPhieu.DataBase;
using System.Transactions;

namespace DHCD_KiemPhieu.Class
{
    public static class LinQConnection
    {
        static log4net.ILog log = log4net.LogManager.GetLogger("File");

        public static double ReturnResult(string sql)
        {
            double result = 0;
            TanHoaDataContext db = new TanHoaDataContext();
            try
            {
                using (var scope = new TransactionScope())
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
                    scope.Complete();
                    scope.Dispose();
                    return result;
                }
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

        public static int ExecuteCommand(string sql)
        {
            int result = 0;
            TanHoaDataContext db = new TanHoaDataContext();
            try
            {

                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
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
                log.Error("LinQConnection getDataTable" + ex.Message);
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
            TanHoaDataContext db = new TanHoaDataContext();
            try
            {
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
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
                log.Error("LinQConnection getDataTable" + ex.Message);
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
            TanHoaDataContext db = new TanHoaDataContext();
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



        public static DataTable getDataTable(string sql, int FirstRow, int pageSize)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            try
            {
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
        public static DataTable ExecuteStoredProcedure(string storedNam, string lan,string ngay)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            DataTable dt = new DataTable();
            try
            {

                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(storedNam, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter _ky = cmd.Parameters.Add("@LAN", SqlDbType.VarChar);
                _ky.Direction = ParameterDirection.Input;
                _ky.Value = lan;

                SqlParameter _nam = cmd.Parameters.Add("@NGAY", SqlDbType.VarChar);
                _nam.Direction = ParameterDirection.Input;
                _nam.Value = ngay;

                adapter.SelectCommand = cmd;

                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;

        }
    }
}
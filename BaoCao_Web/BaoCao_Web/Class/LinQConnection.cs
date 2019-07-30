using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Data;
using System.Data.SqlClient;
using BaoCao_Web.DataBase;

namespace BaoCao_Web.Class
{
    public static class LinQConnection
    {
        static log4net.ILog log = log4net.LogManager.GetLogger("File");

        public static int ReturnResult(string sql)
        {
            int result = 0;
            TanHoaDataContext db = new TanHoaDataContext();
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

        public static DataTable getDataTableHoaDon(string sql)
        {
            DataTable table = new DataTable();
            ThuTienDataContext db = new ThuTienDataContext();
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
        public static void ExecuteStoredProcedure(string storedNam, int ky, int nam)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(storedNam, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter _ky = cmd.Parameters.Add("@KY", SqlDbType.Int);
                _ky.Direction = ParameterDirection.Input;
                _ky.Value = ky;

                SqlParameter _nam = cmd.Parameters.Add("@NAM", SqlDbType.Int);
                _nam.Direction = ParameterDirection.Input;
                _nam.Value = nam;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public static DataSet ExecuteStoredProcedureDS(string storedNam, int ky, int nam)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(storedNam, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter _ky = cmd.Parameters.Add("@KY", SqlDbType.Int);
                _ky.Direction = ParameterDirection.Input;
                _ky.Value = ky;

                SqlParameter _nam = cmd.Parameters.Add("@NAM", SqlDbType.Int);
                _nam.Direction = ParameterDirection.Input;
                _nam.Value = nam;

                DataSet dataset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataset);
                
                return dataset;
            }
            catch (Exception ex)
            {
                log.Error("LinQConnection getDataTable" + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        
            //TanHoaDataContext db = new TanHoaDataContext();
            //SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);

            //conn.Open();
            //SqlCommand cmd = new SqlCommand("DELETEDATABG", conn);
            //cmd.CommandType = CommandType.StoredProcedure;

            //SqlParameter inparm = cmd.Parameters.Add("@shs", SqlDbType.VarChar);
            //inparm.Direction = ParameterDirection.Input;
            //inparm.Value = shs;
            //cmd.ExecuteNonQuery();
            //conn.Close();
    }
}
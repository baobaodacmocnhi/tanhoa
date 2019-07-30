using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKhachHang.Class
{

    public static class OledbConnection
    {
        static log4net.ILog log = log4net.LogManager.GetLogger("File");
      //  static string connectionSting = ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFileLyLichDHN"].ConnectionString;
        
        public static int ExecuteCommand(string connectionSting, string sql)
        {
            OleDbConnection objConnection = new OleDbConnection(connectionSting);
            try
            {
                objConnection.Open();
                OleDbCommand objCmd = new OleDbCommand(sql, objConnection);
                return objCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                log.Error("OleDbConnection ExecuteCommand" + ex.Message);
            }
            finally
            {
                objConnection.Close();
            }
            return 0;
        }
        public static int ExecuteCommand(string connectionSting,  string HODONG, string TENKH, string SONHA, string TENDUONG, string PHUONG, string QUAN, string  DANHBO )
        {
            OleDbConnection objConnection = new OleDbConnection(connectionSting);
            try
            {
                objConnection.Open();
                OleDbCommand objCmd = new OleDbCommand();
                string insert = "UPDATE HANDHELD SET HODONG=@HOPDONG, TENKH=@TENKH, SONHA=@SONHA,TENDUONG=@TENDUONG,PHUONG=@PHUONG,QUAN=@QUAN WHERE DANHBO=@DANHBO ";
                objCmd.CommandText =insert;
                objCmd.Parameters.Add("@DANHBO", OleDbType.VarChar).Value = DANHBO;
                objCmd.Parameters.Add("@HODONG", OleDbType.VarChar).Value = HODONG;
                objCmd.Parameters.Add("@TENKH", OleDbType.VarChar).Value = TENKH;
                objCmd.Parameters.Add("@SONHA", OleDbType.VarChar).Value = SONHA;
                objCmd.Parameters.Add("@PHUONG", OleDbType.VarChar).Value = PHUONG;
                objCmd.Parameters.Add("@QUAN", OleDbType.VarChar).Value = QUAN;
                return objCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                log.Error("OleDbConnection ExecuteCommand" + ex.Message);
            }
            finally
            {
                objConnection.Close();
            }
            return 0;
        }

        public static DataTable getDataTable(string connectionSting,string sql)
        {

            OleDbConnection conn = new OleDbConnection(connectionSting);
            try
            { 
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, conn);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                log.Error("OleDbConnection getDataTable" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }


    }
}

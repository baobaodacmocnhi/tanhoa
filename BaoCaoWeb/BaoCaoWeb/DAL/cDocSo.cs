using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BaoCaoWeb.DAL
{
    public class cDocSo
    {
        protected static string _connectionString;  // Chuỗi kết nối
        protected SqlConnection connection;         // Đối tượng kết nối
        protected SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu
        protected SqlCommand command;               // Đối tượng command thực thi truy vấn
        //protected SqlTransaction transaction;       // Đối tượng transaction

        public cDocSo()
        {
            try
            {
                _connectionString = CGlobalVariable.DocSoWFH;
                connection = new SqlConnection(_connectionString);
            }
            catch (Exception)
            {
            }

        }

        public void Connect()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }

        public void Disconnect()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        public object ExecuteQuery_ReturnOneValue(string sql)
        {
            try
            {
                Connect();
                command = new SqlCommand(sql, connection);
                object result = command.ExecuteScalar();
                Disconnect();
                return result;
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        public DataTable ExecuteQuery_DataTable(string sql)
        {
            this.Connect();
            DataTable dt = new DataTable();
            command = new SqlCommand();
            command.Connection = this.connection;
            adapter = new SqlDataAdapter(sql, connection);
            try
            {
                adapter.Fill(dt);
            }
            catch (SqlException e)
            {
                throw e;
            }
            this.Disconnect();
            return dt;
        }

        public DataTable getSanLuongNam(int NamPrevious, int NamPresent)
        {
            string sql = "select t1.Ky,SanLuongPrevious=t1.SanLuong,SanLuongPresent=t2.SanLuong,ChenhLech=t2.SanLuong-t1.SanLuong from"
                        + " (select Ky, SanLuong = SUM(TieuThuMoi) from DocSo where Nam = " + NamPrevious + " group by Ky)t1"
                        + " left join"
                        + " (select Ky, SanLuong = SUM(TieuThuMoi) from DocSo where Nam = " + NamPresent + " group by Ky)t2 on t1.Ky = t2.Ky"
                        + " order by t1.Ky";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getSanLuongChuanThu(int NamPresent)
        {
            string sql = "select t1.Ky,SanLuongPrevious=t1.SanLuong,SanLuongPresent=t2.SanLuong,ChenhLech=t2.SanLuong-t1.SanLuong from"
                        + " (select Ky, SanLuong = SUM(TieuThuMoi) from DocSo where Nam = " + NamPresent + " group by Ky)t1"
                        + " left join"
                        + " (select Ky, SanLuong = SUM(TIEUTHU) from HOADON_TA.dbo.HOADON where Nam = " + NamPresent + " group by Ky)t2 on t1.Ky = t2.Ky"
                        + " order by t1.Ky";
            return ExecuteQuery_DataTable(sql);
        }

    }
}
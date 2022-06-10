using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Data;
using System.Data.SqlClient;

namespace KTKS_DonKH.DAL
{
    class CTTKH
    {
        private dbTrungTamKhachHangDataContext db = new dbTrungTamKhachHangDataContext();

        protected static string _connectionString;  // Chuỗi kết nối
        protected SqlConnection connection;         // Đối tượng kết nối
        protected SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu
        protected SqlCommand command;               // Đối tượng command thực thi truy vấn

        public CTTKH()
        {
            try
            {
                _connectionString = KTKS_DonKH.Properties.Settings.Default.TRUNGTAMKHACHHANGConnectionString;
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

        public DataTable ExecuteQuery_DataTable(string sql)
        {
            this.Connect();
            DataTable dt = new DataTable();
            command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
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

     

    }
}

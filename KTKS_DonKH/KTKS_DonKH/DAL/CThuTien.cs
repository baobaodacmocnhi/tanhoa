using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Data;
using System.Data.SqlClient;

namespace KTKS_DonKH.DAL
{
    class CThuTien
    {
        private dbThuTienDataContext db = new dbThuTienDataContext();

        protected static string _connectionString;  // Chuỗi kết nối
        protected SqlConnection connection;         // Đối tượng kết nối
        protected SqlCommand command;               // Đối tượng command thực thi truy vấn
        protected SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu

        public CThuTien()
        {
            try
            {
                _connectionString = KTKS_DonKH.Properties.Settings.Default.HOADON_TAConnectionString;
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

        /// <summary>
        /// Thực thi câu truy vấn SQL trả về một đối tượng DataSet chứa kết quả trả về
        /// </summary>
        /// <param name="strSelect">Câu truy vấn cần thực thi lấy dữ liệu</param>
        /// <returns>Đối tượng dataset chứa dữ liệu kết quả câu truy vấn</returns>
        public DataSet ExecuteQuery_SqlDataAdapter_DataSet(string sql)
        {
            try
            {
                Connect();
                DataSet dataset = new DataSet();
                command = new SqlCommand();
                command.Connection = this.connection;
                adapter = new SqlDataAdapter(sql, connection);
                try
                {
                    adapter.Fill(dataset);
                }
                catch (SqlException e)
                {
                    throw e;
                }
                Disconnect();
                return dataset;
            }
            catch (Exception)
            {
                Disconnect();
                return null;
            }
        }

        /// <summary>
        /// Thực thi câu truy vấn SQL trả về một đối tượng DataTable chứa kết quả trả về
        /// </summary>
        /// <param name="strSelect">Câu truy vấn cần thực thi lấy dữ liệu</param>
        /// <returns>Đối tượng datatable chứa dữ liệu kết quả câu truy vấn</returns>
        public DataTable ExecuteQuery_SqlDataAdapter_DataTable(string sql)
        {
            try
            {
                return ExecuteQuery_SqlDataAdapter_DataSet(sql).Tables[0];
            }
            catch (Exception)
            {
                Disconnect();
                return null;
            }
        }

        public HOADON GetMoiNhat(string DanhBo)
        {
            if (db.HOADONs.Any(item => item.DANHBA == DanhBo))
                return db.HOADONs.Where(item => item.DANHBA == DanhBo).OrderByDescending(item => item.ID_HOADON).First();
            else
                return null;
        }

        public HOADON Get(string DanhBo,int Ky,int Nam)
        {
            if (db.HOADONs.Any(item => item.DANHBA == DanhBo && item.KY==Ky && item.NAM==Nam))
                return db.HOADONs.SingleOrDefault(item => item.DANHBA == DanhBo && item.KY == Ky && item.NAM == Nam);
            else
                return null;
        }

        public decimal GetTieuThuMoiNhat(string DanhBo)
        {
            if (db.HOADONs.Any(item => item.DANHBA == DanhBo))
                return db.HOADONs.Where(item => item.DANHBA == DanhBo).OrderByDescending(item => item.ID_HOADON).First().TIEUTHU.Value;
            else
                return 0;
        }

        public DataTable GetDSTimKiem(string DanhBo, string MLT)
        {
            string sql = "select * from TimKiem('" + DanhBo + "','" + MLT + "') order by MaHD desc";

            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetDSTimKiemTTKH(string HoTen, string SoNha, string TenDuong)
        {
            string sql = "select * from TimKiemTTKH('" + HoTen + "','" + SoNha + "','" + TenDuong + "')";

            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }
    }
}

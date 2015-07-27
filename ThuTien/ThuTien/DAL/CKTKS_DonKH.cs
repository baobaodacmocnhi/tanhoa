using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ThuTien.DAL
{
    class CKTKS_DonKH
    {
        protected static string _connectionString;  // Chuỗi kết nối
        protected SqlConnection connection;         // Đối tượng kết nối
        protected SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu
        protected SqlCommand command;               // Đối tượng command thực thi truy vấn
        //protected SqlTransaction transaction;       // Đối tượng transaction

        public CKTKS_DonKH()
        {
            try
            {
                //_connectionString = "Data Source=192.168.90.8\\KD;Initial Catalog=HOADON_TA;Persist Security Info=True;User ID=sa;Password=123@tanhoa";
                _connectionString = ThuTien.Properties.Settings.Default.KTKS_DonKHConnectionString;
                connection = new SqlConnection(_connectionString);
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception ex)
            {
                Disconnect();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
            catch (Exception ex)
            {
                Disconnect();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSP_KinhDoanh(string DanhBo)
        {
            string sqlKTXM = "select Loai=N'Kiểm Tra Xác Minh',NoiDungKiemTra as NoiDung,CreateDate from CTKTXM where DanhBo='" + DanhBo + "'";
            string sqlDCBD = "select Loai=N'Điều Chỉnh Biến Động',ThongTin as NoiDung,CreateDate from CTDCBD where DanhBo='" + DanhBo + "'";
            string sqlDCHD = "select Loai=N'Điểu Chỉnh Hóa Đơn',TangGiam as NoiDung,CreateDate from CTDCHD where DanhBo='" + DanhBo + "'";
            string sqlCTDB = "select Loai=N'TB Cắt Tạm Danh Bộ',LyDo+'. '+GhiChuLyDo as NoiDung,CreateDate from CTCTDB where DanhBo='" + DanhBo + "'";
            string sqlCHDB = "select Loai=N'TB Cắt Hủy Danh Bộ',LyDo+'. '+GhiChuLyDo as NoiDung,CreateDate from CTCHDB where DanhBo='" + DanhBo + "'";
            string sqlYCCHDB = "select Loai=N'Phiếu Yêu Cầu Cắt Hủy Danh Bộ',LyDo+'. '+GhiChuLyDo as NoiDung,CreateDate from YeuCauCHDB where DanhBo='" + DanhBo + "'";
            string sqlTTTL = "select Loai=N'Thư Trả Lời',NoiDung,CreateDate from CTTTTL where DanhBo='" + DanhBo + "'";

            DataTable dt = ExecuteQuery_SqlDataAdapter_DataTable(sqlKTXM);
            dt.Merge(ExecuteQuery_SqlDataAdapter_DataTable(sqlDCBD));
            dt.Merge(ExecuteQuery_SqlDataAdapter_DataTable(sqlDCHD));
            dt.Merge(ExecuteQuery_SqlDataAdapter_DataTable(sqlCTDB));
            dt.Merge(ExecuteQuery_SqlDataAdapter_DataTable(sqlCHDB));
            dt.Merge(ExecuteQuery_SqlDataAdapter_DataTable(sqlYCCHDB));
            dt.Merge(ExecuteQuery_SqlDataAdapter_DataTable(sqlTTTL));
            dt.DefaultView.Sort = "CreateDate desc";
            return dt.DefaultView.ToTable();
        }
    }
}

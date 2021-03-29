using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BaoCaoWeb.DAL
{
    public class cThuTien
    {
        protected static string _connectionString;  // Chuỗi kết nối
        protected SqlConnection connection;         // Đối tượng kết nối
        protected SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu
        protected SqlCommand command;               // Đối tượng command thực thi truy vấn
        //protected SqlTransaction transaction;       // Đối tượng transaction

        public cThuTien()
        {
            try
            {
                _connectionString = "Data Source=server9;Initial Catalog=HOADON_TA;Persist Security Info=True;User ID=sa;Password=db9@tanhoa";
                //_connectionString = ThuTien.Properties.Settings.Default.KTKS_DonKHConnectionString;
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

        public DataTable getDoanhThu()
        {
            string sql = "select t1.Ky,DoanhThuPrevious=t1.DoanhThu,DoanhThuPresent=t2.DoanhThu,ChenhLech=t2.DoanhThu-t1.DoanhThu from"
                        + " (select Ky,DoanhThu=SUM(TongCong) from HOADON where Nam = " + (DateTime.Now.Year - 1) + " group by Ky)t1"
                        + " left join"
                        + " (select Ky,DoanhThu=SUM(TongCong) from HOADON where Nam = " + DateTime.Now.Year + " group by Ky)t2 on t1.Ky = t2.Ky"
                        + " order by t1.Ky";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getGiaBanBinhQuan()
        {
            string sql = "select t1.Ky,DoanhThuPrevious=t1.DoanhThu,DoanhThuPresent=t2.DoanhThu,ChenhLech=t2.DoanhThu-t1.DoanhThu from"
                        + " (select Ky,DoanhThu=SUM(GiaBanBinhQuan) from TT_GiaBanBinhQuan where Nam = " + (DateTime.Now.Year - 1) + " group by Ky)t1"
                        + " left join"
                        + " (select Ky,DoanhThu=SUM(GiaBanBinhQuan) from TT_GiaBanBinhQuan where Nam = " + DateTime.Now.Year + " group by Ky)t2 on t1.Ky = t2.Ky"
                        + " order by t1.Ky";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getThuHo()
        {
            string sql = "select TenNH=(select NGANHANG from NGANHANG where ID_NGANHANG=MaNH),MaNH,TongCong=SUM(TONGCONG),HoaDon=COUNT(ID_HOADON)"
                        + " from TAMTHU tt,HOADON hd where tt.FK_HOADON=hd.ID_HOADON and NGAYGIAITRACH is not null and YEAR(NGAYGIAITRACH)=" + DateTime.Now.Year + " and DangNgan_ChuyenKhoan=1"
                        + " group by MaNH";
            return ExecuteQuery_DataTable(sql);
        }
    }
}
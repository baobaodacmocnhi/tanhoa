using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VanBanKhachHangWeb.DAL
{
    public class cKinhDoanh
    {
        protected static string _connectionString;  // Chuỗi kết nối
        protected SqlConnection connection;         // Đối tượng kết nối
        protected SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu
        protected SqlCommand command;               // Đối tượng command thực thi truy vấn
        //protected SqlTransaction transaction;       // Đối tượng transaction

        public cKinhDoanh()
        {
            try
            {
                _connectionString = "Data Source=serverg8-01;Initial Catalog=KTKS_DonKH;Persist Security Info=True;User ID=sa;Password=db11@tanhoa";
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

        public DataTable getDS_File(string DanhBo)
        {
            //string sqlKTXM = "select db='Kinh Doanh',Loai=N'Kiểm Tra Xác Minh',NoiDung=NoiDungKiemTra,CreateDate=NgayKTXM,'Table'='KTXM_ChiTiet','Column'='MaCTKTXM',Ma=MaCTKTXM,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu from KTXM_ChiTiet where DanhBo='" + DanhBo + "'";
            //string sqlBamChi = "select db='Kinh Doanh',Loai=N'Bấm Chì',NoiDung=TrangThaiBC,CreateDate=NgayBC,'Table'='BamChi_ChiTiet','Column'='MaCTBC',Ma=MaCTBC,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu from BamChi_ChiTiet where DanhBo='" + DanhBo + "'";
            //string sqlDCBD = "select db='Kinh Doanh',Loai=N'Điều Chỉnh Biến Động',NoiDung=ThongTin,CreateDate,'Table'='DCBD_ChiTietBienDong','Column'='MaCTDCBD',Ma=MaCTDCBD,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu from DCBD_ChiTietBienDong where DanhBo='" + DanhBo + "'";
            //string sqlDCHD = "select db='Kinh Doanh',Loai=N'Điều Chỉnh Hóa Đơn',NoiDung=TangGiam,CreateDate,'Table'='DCBD_ChiTietHoaDon','Column'='MaCTDCHD',Ma=MaCTDCHD,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu from DCBD_ChiTietHoaDon where DanhBo='" + DanhBo + "'";
            string sqlCTDB = "select LoaiVanBan=N'TB Cắt Tạm',DanhBo,HoTen,DiaChi,NoiDung=LyDo+'. '+GhiChuLyDo,a.CreateDate,TableName='CHDB_ChiTietCatTam_Hinh',IDFileContent=b.ID from CHDB_ChiTietCatTam a,CHDB_ChiTietCatTam_Hinh b where a.DanhBo='" + DanhBo + "' and a.MaCTCTDB=b.IDCHDB_ChiTietCatTam";
            string sqlCHDB = "select LoaiVanBan=N'TB Cắt Hủy',DanhBo,HoTen,DiaChi,NoiDung=LyDo+'. '+GhiChuLyDo,a.CreateDate,TableName='CHDB_ChiTietCatHuy_Hinh',IDFileContent=b.ID from CHDB_ChiTietCatHuy a,CHDB_ChiTietCatHuy_Hinh b where a.DanhBo='" + DanhBo + "' and a.MaCTCHDB=b.IDCHDB_ChiTietCatHuy";
            //string sqlPhieuCHDB = "select db='Kinh Doanh',Loai=N'Phiếu Hủy',NoiDung=LyDo+'. '+GhiChuLyDo,CreateDate,'Table'='CHDB_Phieu','Column'='MaYCCHDB',Ma=MaYCCHDB,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu from CHDB_Phieu where DanhBo='" + DanhBo + "'";
            string sqlTTTL = "select LoaiVanBan=N'Thư Trả Lời',DanhBo,HoTen,DiaChi,NoiDung=VeViec,a.CreateDate,TableName='ThuTraLoi_ChiTiet_Hinh',IDFileContent=b.ID from ThuTraLoi_ChiTiet a,ThuTraLoi_ChiTiet_Hinh b where a.DanhBo='" + DanhBo + "' and a.MaCTTTTL=b.IDTTTL_ChiTiet";

            DataTable dt = new DataTable();
            //dt.Merge(ExecuteQuery_DataTable(sqlKTXM));
            //dt.Merge(ExecuteQuery_DataTable(sqlDCBD));
            //dt.Merge(ExecuteQuery_DataTable(sqlDCHD));
            dt.Merge(ExecuteQuery_DataTable(sqlCTDB));
            dt.Merge(ExecuteQuery_DataTable(sqlCHDB));
            //dt.Merge(ExecuteQuery_DataTable(sqlPhieuCHDB));
            dt.Merge(ExecuteQuery_DataTable(sqlTTTL));
            dt.DefaultView.Sort = "CreateDate desc";
            return dt.DefaultView.ToTable();
        }

        public byte[] getFile(string TableName, string IDFileContent)
        {
            int count = (int)ExecuteQuery_ReturnOneValue("select count(*) from " + TableName + " where ID=" + IDFileContent);
            if (count > 0)
                return (byte[])ExecuteQuery_ReturnOneValue("select Hinh from " + TableName + " where ID=" + IDFileContent);
            else
                return null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ThuTien.LinQ;
using System.Reflection;

namespace ThuTien.DAL
{
    class CDHN
    {
        protected static string _connectionString;  // Chuỗi kết nối
        protected SqlConnection connection;         // Đối tượng kết nối
        protected SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu
        protected SqlCommand command;               // Đối tượng command thực thi truy vấn
        dbDHNDataContext _db = new dbDHNDataContext();

        public CDHN()
        {
            try
            {
                //_connectionString = "Data Source=192.168.90.8\\KD;Initial Catalog=HOADON_TA;Persist Security Info=True;User ID=sa;Password=123@tanhoa";
                _connectionString = ThuTien.Properties.Settings.Default.CAPNUOCTANHOAConnectionString;
                connection = new SqlConnection(ThuTien.Properties.Settings.Default.CAPNUOCTANHOAConnectionString);
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

        public bool ExecuteNonQuery(string sql)
        {
            try
            {
                Connect();
                command = new SqlCommand(sql, connection);
                int rowsAffected = command.ExecuteNonQuery();
                Disconnect();
                if (rowsAffected >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        /// <summary>
        /// var vrCountry = from country in objEmpDataContext.CountryMaster
        ///                select new {country.CountryID,country.CountryName};
        /// DataTable dt = LINQToDataTable(vrCountry);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="varlist"></param>
        /// <returns></returns>
        public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
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

        public bool CheckExist(string DanhBo)
        {
            return _db.TB_DULIEUKHACHHANGs.Any(item => item.DANHBO == DanhBo);
        }

        public TB_DULIEUKHACHHANG GetTTKH(string DanhBo)
        {
            return _db.TB_DULIEUKHACHHANGs.SingleOrDefault(item => item.DANHBO == DanhBo);
        }

        public DataTable GetTTKH(string HoTen, string SoNha, string TenDuong)
        {
            return LINQToDataTable(_db.TB_DULIEUKHACHHANGs.Where(item => item.HOTEN.Contains(HoTen.ToUpper()) && item.SONHA.Contains(SoNha.ToUpper()) && item.TENDUONG.Contains(TenDuong.ToUpper()))
                .Select(item => new
                {
                    DanhBo = item.DANHBO,
                    item.HOPDONG,
                    item.GIABIEU,
                    item.DINHMUC,
                    MLT = item.LOTRINH,
                    Hieu = item.HIEUDH,
                    Co = item.CODH,
                    SoThan = item.SOTHANDH,
                    ViTri = item.VITRIDHN,
                    HoTen = item.HOTEN,
                    DiaChi = item.SONHA + "  " + item.TENDUONG,
                    item.DIENTHOAI,
                    HanhThu = ""
                }).ToList());
        }

        public DataTable GetGhiChu(string DanhBo)
        {
            return LINQToDataTable(_db.TB_GHICHUs.Where(item => item.DANHBO == DanhBo)
                .OrderByDescending(item => item.CREATEDATE).Select(item => new { item.CREATEDATE, item.NOIDUNG }).Take(5).ToList());
        }
        
        public string GetDienThoai(string DanhBo)
        {
            return _db.TB_DULIEUKHACHHANGs.SingleOrDefault(item => item.DANHBO == DanhBo).DIENTHOAI;
        }

        public string GetCoDHN(string DanhBo)
        {
            return _db.TB_DULIEUKHACHHANGs.SingleOrDefault(item => item.DANHBO == DanhBo).CODH;
               
        }

        public void GetDMA(string DanhBo, out string Quan, out string Phuong, out  string CoDHN, out string MaDMA)
        {
            Connect();
            SqlCommand cmd = new SqlCommand("sp_ThongTin", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter inparm = cmd.Parameters.Add("@DANHBO", SqlDbType.VarChar,50);
            inparm.Direction = ParameterDirection.Input;
            inparm.Value = DanhBo;

            SqlParameter _QUAN = cmd.Parameters.Add("@QUAN", SqlDbType.VarChar, 50);
            _QUAN.Direction = ParameterDirection.Output;

            SqlParameter _PHUONG = cmd.Parameters.Add("@PHUONG", SqlDbType.VarChar, 50);
            _PHUONG.Direction = ParameterDirection.Output;

            SqlParameter _CODH = cmd.Parameters.Add("@CODH", SqlDbType.VarChar, 50);
            _CODH.Direction = ParameterDirection.Output;

            SqlParameter _MADMA = cmd.Parameters.Add("@MADMA", SqlDbType.VarChar, 50);
            _MADMA.Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            Quan = cmd.Parameters["@QUAN"].Value + "";
            Phuong = cmd.Parameters["@PHUONG"].Value + "";
            CoDHN = cmd.Parameters["@CODH"].Value + "";
            MaDMA = cmd.Parameters["@MADMA"].Value + "";
            Disconnect();

        }

        public void GetPhuongQuan(string DanhBo, out string TenPhuong, out string TenQuan)
        {
            TenPhuong = "";
            TenQuan = "";
            var query = from item in _db.TB_DULIEUKHACHHANGs
                        join itemP in _db.PHUONGs on new { p = item.PHUONG, q = Convert.ToInt32(item.QUAN) } equals new { p = itemP.MAPHUONG, q = itemP.MAQUAN }
                        where item.DANHBO == DanhBo
                        select new
                        {
                            itemP.TENPHUONG,
                            itemP.QUAN.TENQUAN,
                        };
            if (query.Count() > 0)
            {
                TenPhuong = query.FirstOrDefault().TENPHUONG;
                TenQuan = query.FirstOrDefault().TENQUAN;
            }
        }

        public string GetPhuongQuan(string DanhBo)
        {
            var query = from item in _db.TB_DULIEUKHACHHANGs
                        join itemP in _db.PHUONGs on new { p = item.PHUONG, q = Convert.ToInt32(item.QUAN) } equals new { p = itemP.MAPHUONG, q = itemP.MAQUAN }
                        where item.DANHBO == DanhBo
                        select new
                        {
                            itemP.TENPHUONG,
                            itemP.QUAN.TENQUAN,
                        };
            if (query.Count() > 0)
            {
                return " P."+query.FirstOrDefault().TENPHUONG + ", Q."+query.FirstOrDefault().TENQUAN;
            }
            else
                return "";
        }
    }
}

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
    class CCAPNUOCTANHOA
    {
        protected static string _connectionString;  // Chuỗi kết nối
        protected SqlConnection connection;         // Đối tượng kết nối
        protected SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu
        protected SqlCommand command;               // Đối tượng command thực thi truy vấn
        dbCAPNUOCTANHOADataContext _dbCapNuocTanHoa = new dbCAPNUOCTANHOADataContext();

        public CCAPNUOCTANHOA()
        {
            try
            {
                //_connectionString = "Data Source=192.168.90.8\\KD;Initial Catalog=HOADON_TA;Persist Security Info=True;User ID=sa;Password=123@tanhoa";
                _connectionString = ThuTien.Properties.Settings.Default.CAPNUOCTANHOAConnectionString;
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

        public DataTable GetTTKH(string DanhBo)
        {
            return LINQToDataTable(_dbCapNuocTanHoa.TB_DULIEUKHACHHANGs.Where(item => item.DANHBO == DanhBo)
                .Select(item => new { DanhBo = item.DANHBO, item.HOPDONG, item.GIABIEU, item.DINHMUC, MLT = item.LOTRINH
                , Hieu = item.HIEUDH, Co = item.CODH, SoThan = item.SOTHANDH, ViTri = item.VITRIDHN, HoTen = item.HOTEN
                , DiaChi = item.SONHA + "  " + item.TENDUONG, item.DIENTHOAI,HanhThu="" }).Take(1).ToList());
        }

        public string GetDienThoaiKH(string DanhBo)
        {
            return _dbCapNuocTanHoa.TB_DULIEUKHACHHANGs.SingleOrDefault(item => item.DANHBO == DanhBo).DIENTHOAI;
        }

        public DataTable GetGhiChu(string DanhBo)
        {
            return LINQToDataTable(_dbCapNuocTanHoa.TB_GHICHUs.Where(item => item.DANHBO == DanhBo)
                .OrderByDescending(item => item.CREATEDATE).Select(item=>new {item.CREATEDATE,item.NOIDUNG }).Take(5).ToList());
        }

        public string GetCoDHN(string DanhBo)
        {
            return _dbCapNuocTanHoa.TB_DULIEUKHACHHANGs.SingleOrDefault(item=>item.DANHBO==DanhBo).CODH;
               
        }

        public void GetDMA(string DanhBo, out string Quan, out string Phuong, out  string CoDHN, out string MaDMA)
        {
            Connect();
            SqlCommand cmd = new SqlCommand("sp_ThongTin", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter inparm = cmd.Parameters.Add("@DANHBO", SqlDbType.VarChar);
            inparm.Direction = ParameterDirection.Input;
            inparm.Value = _dbCapNuocTanHoa;

            SqlParameter _QUAN = cmd.Parameters.Add("@QUAN", SqlDbType.VarChar);
            _QUAN.Direction = ParameterDirection.Output;

            SqlParameter _PHUONG = cmd.Parameters.Add("@PHUONG", SqlDbType.VarChar);
            _PHUONG.Direction = ParameterDirection.Output;

            SqlParameter _CODH = cmd.Parameters.Add("@CODH", SqlDbType.VarChar);
            _CODH.Direction = ParameterDirection.Output;

            SqlParameter _MADMA = cmd.Parameters.Add("@MADMA", SqlDbType.VarChar);
            _MADMA.Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            Quan = cmd.Parameters["@QUAN"].Value + "";
            Phuong = cmd.Parameters["@PHUONG"].Value + "";
            CoDHN = cmd.Parameters["@CODH"].Value + "";
            MaDMA = cmd.Parameters["@MADMA"].Value + "";
            Disconnect();

        }
    }
}

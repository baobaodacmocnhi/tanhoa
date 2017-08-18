using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace WSSmartPhone
{
    public class CBaoBao
    {
        protected static string _connectionString;  // Chuỗi kết nối
        protected SqlConnection connection;         // Đối tượng kết nối
        protected SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu
        protected SqlCommand command;               // Đối tượng command thực thi truy vấn
        //protected SqlTransaction transaction;       // Đối tượng transaction

        public CBaoBao()
        {
            try
            {
                _connectionString = "Data Source=192.168.90.9;Initial Catalog=BaoBao;Persist Security Info=True;User ID=sa;Password=123@tanhoa";
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

        public bool ExecuteNonQuery(string sql)
        {
            try
            {
                Connect();
                command = new SqlCommand(sql, connection);
                int rowsAffected = command.ExecuteNonQuery();
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
        /// Hàm thực thi các câu truy vấn lấy thông tin dữ liệu như Select
        /// </summary>
        /// <param name="sqlString"> Câu truy vấn (Select) cần thực thi </param>
        /// <returns> Hàm trả về một đối tượng SqlDataReader chứa thông tin dữ liệu trả về </returns>
        public SqlDataReader ExecuteQuery_SqlDataReader(string sql)
        {
            try
            {
                Connect();
                command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                //Disconnect();
                return reader;
            }
            catch (Exception)
            {
                Disconnect();
                return null;
            }
        }

        public DataTable ExecuteQuery_SqlDataReader_DataTable(string sql)
        {
            try
            {
                DataTable dt = new DataTable();
                Connect();
                command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
                Disconnect();
                return dt;
            }
            catch (Exception)
            {
                Disconnect();
                return null;
            }
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

        /// <summary>
        /// Chuyển đối tượng Reader sang Entity Class
        /// </summary>
        /// <typeparam name="T">Tên Class</typeparam>
        /// <param name="reader">kết quả thực thi</param>
        /// <returns></returns>
        public T MapToClass<T>(SqlDataReader reader) where T : class
        {
            T obj = default(T);
            try
            {
                //T returnedObject = Activator.CreateInstance<T>();
                //List<PropertyInfo> modelProperties = returnedObject.GetType().GetProperties().OrderBy(p => p.MetadataToken).ToList();
                //for (int i = 0; i < modelProperties.Count; i++)
                //    modelProperties[i].SetValue(returnedObject, Convert.ChangeType(reader.GetValue(i), modelProperties[i].PropertyType), null);
                //return returnedObject;

                while (reader.Read())
                {
                    obj = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        if (!object.Equals(reader[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, reader[prop.Name], null);
                        }
                    }
                }
                return obj;
            }
            catch (Exception)
            {
                return obj;
            }

        }

        public bool ThemKhachHang(string HoTen, int GioiTinh)
        {
            int ID = 0;
            if (int.Parse(ExecuteQuery_SqlDataAdapter_DataTable("select COUNT(ID) from KhachHang").Rows[0][0].ToString()) == 0)
                ID = 1;
            else
                ID = int.Parse(ExecuteQuery_SqlDataAdapter_DataTable("select MAX(ID)+1 from KhachHang").Rows[0][0].ToString());
            string sql = "insert into KhachHang(ID,HoTen,GioiTinh)values(" + ID + ",N'" + HoTen + "'," + GioiTinh + ")";
            return ExecuteNonQuery(sql);
        }

        public bool XoaKhachHang(int ID)
        {
            return ExecuteNonQuery("delete KhachHang where ID=" + ID);
        }

        public DataTable GetDSKhachHang()
        {
            return ExecuteQuery_SqlDataAdapter_DataTable("select * from KhachHang");
        }
    }
}
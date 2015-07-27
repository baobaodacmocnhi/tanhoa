using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ThuTien.DAL
{
    class CDAL
    {
        protected static dbThuTienDataContext _db = new dbThuTienDataContext();

        public void BeginTransaction()
        {
            if (_db.Connection.State == System.Data.ConnectionState.Closed)
                _db.Connection.Open();
            _db.Transaction = _db.Connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _db.Transaction.Commit();
        }

        public void Rollback()
        {
            _db.Transaction.Rollback();
        }

        public void SubmitChanges()
        {
            _db.SubmitChanges();

        }

        public bool LinQExecuteNonQuery(string sql)
        {
            if (_db.ExecuteCommand(sql) == 0)
                return false;
            else
                return true;
        }

        //public void SubmitChanges()
        //{
        //    _db.SubmitChanges();
        //}

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
        /// var vrCountry = from country in objEmpDataContext.CountryMaster
        ///                select new {country.CountryID,country.CountryName};
        /// DataTable dt = LINQToDataTable(objEmpDataContext,vrCountry);
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable ToDataTable(System.Data.Linq.DataContext ctx, object query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            IDbCommand cmd = ctx.GetCommand(query as IQueryable);
            cmd.CommandTimeout = 0;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = (SqlCommand)cmd;
            DataTable dt = new DataTable("sd");
           
            try
            {
                cmd.Connection.Open();
                adapter.FillSchema(dt, SchemaType.Source);
                adapter.Fill(dt);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }

        protected static string _connectionString;  // Chuỗi kết nối
        protected SqlConnection connection;         // Đối tượng kết nối
        protected SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu
        protected SqlCommand command;               // Đối tượng command thực thi truy vấn
        protected SqlTransaction transaction;       // Đối tượng transaction

        public CDAL()
        {
            try
            {
                //_connectionString = "Data Source=192.168.90.8\\KD;Initial Catalog=HOADON_TA;Persist Security Info=True;User ID=sa;Password=123@tanhoa";
                _connectionString = ThuTien.Properties.Settings.Default.HOADON_TAConnectionString;
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

        public void SqlBeginTransaction()
        {
            try
            {
                Connect();
                transaction = connection.BeginTransaction();
            }
            catch (Exception) { }
        }

        public void SqlCommitTransaction()
        {
            try
            {
                transaction.Commit();
                transaction.Dispose();
                Disconnect();
            }
            catch (Exception) { }
        }

        public void SqlRollbackTransaction()
        {
            transaction.Rollback();
            transaction.Dispose();
            try
            {
                Disconnect();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Thực thi câu truy vấn SQL không trả về dữ liệu
        /// </summary>
        /// <param name="sql">Câu truy vấn cần thực thi</param>
        /// <param name="flagTransaction">Có hoặc Không transaction</param>
        public bool ExecuteNonQuery(string sql, bool flagTransaction)
        {
            if (!flagTransaction)
                try
                {
                    Connect();
                    command = new SqlCommand(sql, connection);
                    int rowAffect = command.ExecuteNonQuery();
                    Disconnect();
                    if (rowAffect == 0)
                        return false;
                    else
                        return true;
                }
                catch (Exception ex)
                {
                    Disconnect();
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            else
                try
                {
                    Connect();
                    transaction = connection.BeginTransaction();
                    command = new SqlCommand(sql, connection);
                    command.Transaction = transaction;
                    int rowAffect = command.ExecuteNonQuery();
                    transaction.Commit();
                    Disconnect();
                    if (rowAffect == 0)
                        return false;
                    else
                        return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Disconnect();
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
        }

        /// <summary>
        /// Thực thi câu truy vấn SQL không trả về dữ liệu. Trước đó phải mở Transaction/Kết thúc phải đóng Transaction
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ExecuteNonQuery_Transaction(string sql)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command = new SqlCommand(sql, connection);
                command.Transaction = transaction;
                if (command.ExecuteNonQuery() == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
            catch (Exception ex)
            {
                Disconnect();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception ex)
            {
                Disconnect();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception ex)
            {
                Disconnect();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return obj;
            }
            
        }

        /// <summary>
        /// Lấy mã tiếp theo, theo định dạng sttnăm 113(12013)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public decimal getMaxNextIDTable(decimal id)
        {
            string nam = id.ToString().Substring(id.ToString().Length - 2, 2);
            string stt = id.ToString().Substring(0, id.ToString().Length - 2);
            if (decimal.Parse(nam) == decimal.Parse(DateTime.Now.ToString("yy")))
            {
                stt = (decimal.Parse(stt) + 1).ToString();
            }
            else
            {
                stt = "1";
                nam = DateTime.Now.ToString("yy");
            }
            return decimal.Parse(stt + nam);
        }

        #region ConvertMoneyToWord

        private string unit(int n)
        {
            string chuoi = "";
            if (n == 1) chuoi = " đồng ";
            else if (n == 2) chuoi = " nghìn ";
            else if (n == 3) chuoi = " triệu ";
            else if (n == 4) chuoi = " tỷ ";
            else if (n == 5) chuoi = " nghìn tỷ ";
            else if (n == 6) chuoi = " triệu tỷ ";
            else if (n == 7) chuoi = " tỷ tỷ ";
            return chuoi;
        }

        private string convert_number(string n)
        {
            string chuoi = "";
            if (n == "0") chuoi = "không";
            else if (n == "1") chuoi = "một";
            else if (n == "2") chuoi = "hai";
            else if (n == "3") chuoi = "ba";
            else if (n == "4") chuoi = "bốn";
            else if (n == "5") chuoi = "năm";
            else if (n == "6") chuoi = "sáu";
            else if (n == "7") chuoi = "bảy";
            else if (n == "8") chuoi = "tám";
            else if (n == "9") chuoi = "chín";
            return chuoi;
        }

        private string join_number(string n)
        {
            string chuoi = "";
            int i = 1, j = n.Length;
            while (i <= j)
            {
                if (i == 1) chuoi = convert_number(n.Substring(j - i, 1)) + chuoi;
                else if (i == 2) chuoi = convert_number(n.Substring(j - i, 1)) + " mươi " + chuoi;
                else if (i == 3) chuoi = convert_number(n.Substring(j - i, 1)) + " trăm " + chuoi;
                i += 1;
            }
            return chuoi;
        }

        private string join_unit(string n)
        {
            int sokytu = n.Length;
            int sodonvi = (sokytu % 3 > 0) ? (sokytu / 3 + 1) : (sokytu / 3);
            n = n.PadLeft(sodonvi * 3, '0');
            sokytu = n.Length;
            string chuoi = "";
            int i = 1;
            while (i <= sodonvi)
            {
                if (i == sodonvi) chuoi = join_number((int.Parse(n.Substring(sokytu - (i * 3), 3))).ToString()) + unit(i) + chuoi;
                else chuoi = join_number(n.Substring(sokytu - (i * 3), 3)) + unit(i) + chuoi;
                i += 1;
            }
            return chuoi;
        }

        private string replace_special_word(string chuoi)
        {
            chuoi = chuoi.Replace("không mươi không ", "");
            chuoi = chuoi.Replace("không mươi", "lẻ");
            chuoi = chuoi.Replace("i không", "i");
            chuoi = chuoi.Replace("i năm", "i lăm");
            chuoi = chuoi.Replace("một mươi", "mười");
            chuoi = chuoi.Replace("mươi một", "mươi mốt");
            return chuoi;
        }

        public string ConvertMoneyToWord(string money)
        {
            return replace_special_word(join_unit(money));
        }

        #endregion


    }
}

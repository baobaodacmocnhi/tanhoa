using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Diagnostics;

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

        public void NullTransaction()
        {
            _db.Transaction = null;
        }

        public void SubmitChanges()
        {
            _db.SubmitChanges();
        }

        public bool LinQ_ExecuteNonQuery(string sql)
        {
            if (_db.ExecuteCommand(sql) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Refresh()
        {
            _db = new dbThuTienDataContext();
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
                _db.CommandTimeout = 60;
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

        public bool ExecuteNonQuery(string sql)
        {
            try
            {
                Connect();
                command = new SqlCommand(sql, connection);
                command.CommandTimeout = 600;
                int rowsAffected = command.ExecuteNonQuery();
                Disconnect();
                if (rowsAffected >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
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
                command = new SqlCommand(sql, connection, transaction);
                //command.CommandTimeout = 0;
                //command.Transaction = transaction;
                if (command.ExecuteNonQuery() == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ExecuteQuery_DataTable(string sql)
        {
            try
            {
                this.Connect();
                DataTable dt = new DataTable();
                command = new SqlCommand(sql, connection);
                command.CommandTimeout = 60;
                adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
                this.Disconnect();
                return dt;
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        public DataSet ExecuteQuery_DataSet(string sql)
        {
            try
            {
                Connect();
                DataSet dataset = new DataSet();
                command = new SqlCommand(sql, connection);
                command.CommandTimeout = 0;
                adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);
                Disconnect();
                return dataset;
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// Lấy mã tiếp theo, theo định dạng sttnăm 113(12013)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public decimal getMaxNextIDTable(decimal id)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
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
            string str = replace_special_word(join_unit(money));
            if (str.Length > 1)
                return str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
            else
                return "";
        }

        #endregion

        public void LoadImageView(byte[] pData)
        {
            try
            {
                // get a tempfilename and store the image
                //var tempFileName = Path.GetTempFileName();
                string tempFileName = Path.GetRandomFileName();
                tempFileName = Path.ChangeExtension(tempFileName, "jpg");
                tempFileName = Path.Combine(Path.GetTempPath(), tempFileName);

                FileStream mStream = new FileStream(tempFileName, FileMode.Create);
                //byte[] pData = entity.Image.ToArray();
                mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                Bitmap bm = new Bitmap(mStream, false);
                mStream.Dispose();

                string path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

                // create our startup process and argument
                var psi = new ProcessStartInfo(
                    "rundll32.exe",
                    String.Format(
                        "\"{0}{1}\", ImageView_Fullscreen {2}",
                        Environment.Is64BitOperatingSystem ?
                            path.Replace(" (x86)", "") :
                            path
                            ,
                        @"\Windows Photo Viewer\PhotoViewer.dll",
                        tempFileName)
                    );

                psi.UseShellExecute = false;

                var viewer = Process.Start(psi);
                // cleanup when done...
                viewer.EnableRaisingEvents = true;
                viewer.Exited += (o, args) =>
                {
                    File.Delete(tempFileName);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DateTime GetToDate(DateTime FromDate, int SoNgayCongThem)
        {
            try
            {
                while (SoNgayCongThem > 0)
                {
                    if (FromDate.DayOfWeek == DayOfWeek.Friday)
                        FromDate = FromDate.AddDays(3);
                    else
                        if (FromDate.DayOfWeek == DayOfWeek.Saturday)
                            FromDate = FromDate.AddDays(2);
                        else
                            FromDate = FromDate.AddDays(1);
                    SoNgayCongThem--;
                }
                return FromDate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ExcelToDataTable(string path)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = null;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = null;
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = null;
            DataTable dt = new DataTable();
            try
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(path);
                xlWorksheet = xlWorkbook.Worksheets[1];

                int rows = xlWorksheet.UsedRange.Rows.Count;
                int cols = xlWorksheet.UsedRange.Columns.Count;

                int noofrow = 1;

                for (int c = 1; c <= cols; c++)
                {
                    //string colname = xlWorksheet.Cells[1, c].Text;
                    //dt.Columns.Add(colname);
                    dt.Columns.Add(c.ToString());
                    noofrow = 2;
                }

                for (int r = noofrow; r <= rows; r++)
                {
                    DataRow dr = dt.NewRow();
                    for (int c = 1; c <= cols; c++)
                    {
                         dr[c - 1] = xlWorksheet.Cells[r, c].Value;
                    }

                    dt.Rows.Add(dr);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                //release com objects to fully kill excel process from running in the background
                //if (xlRange != null)
                //{
                //    Marshal.ReleaseComObject(xlRange);
                //}

                if (xlWorksheet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorksheet);
                }

                //close and release
                if (xlWorkbook != null)
                {
                    xlWorkbook.Close();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
                }

                //quit and release
                if (xlApp != null)
                {
                    xlApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return dt;
        }

        public double convertToDouble(string number)
        {
            if (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ".")
                number.Replace(",", ".");
            return double.Parse(number);
        }
    }
}

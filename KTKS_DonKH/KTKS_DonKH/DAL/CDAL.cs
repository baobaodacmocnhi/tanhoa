using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace KTKS_DonKH.DAL
{
    class CDAL
    {
        protected static dbKinhDoanhDataContext db = new dbKinhDoanhDataContext();
        protected static dbThuTienDataContext dbThuTien = new dbThuTienDataContext();

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

        public void beginTransaction()
        {
            if (db.Connection.State == System.Data.ConnectionState.Closed)
                db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
        }

        public void commitTransaction()
        {
            db.Transaction.Commit();
        }

        public void rollback()
        {
            db.Transaction.Rollback();
        }

        public void SubmitChanges()
        {
            db.SubmitChanges();
        }

        public void Refresh()
        {
            db = new dbKinhDoanhDataContext();
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
                _connectionString = KTKS_DonKH.Properties.Settings.Default.KTKS_DonKHConnectionString;
                connection = new SqlConnection(_connectionString);
                db.CommandTimeout = 300;
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
                int rowsAffected = command.ExecuteNonQuery();
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
                //Disconnect();
                return result;
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
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public DateTime GetToDate(DateTime FromDate, int SoNgayCongThem)
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

        public List<Quan> GetDSQuan()
        {
            return db.Quans.ToList();
        }

        public List<Phuong> GetDSPhuong(int MaQuan)
        {
            return db.Phuongs.Where(item => item.IDQuan == MaQuan).ToList();
        }

        public string getTenQuan(int MaQuan)
        {
            return db.Quans.SingleOrDefault(item => item.ID == MaQuan).Name2;
        }

        public string getTenPhuong(int MaQuan, int MaPhuong)
        {
            return db.Phuongs.SingleOrDefault(item => item.IDQuan == MaQuan && item.IDPhuong == MaPhuong).Name2;
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
                    string colname = xlWorksheet.Cells[1, c].Text;
                    dt.Columns.Add(colname);
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
                return dt;
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
        }

        public double convertToDouble(string number)
        {
            if (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ".")
                number.Replace(",", ".");
            return double.Parse(number);
        }

        public Bitmap resizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public Bitmap resizeImage(Image image, decimal percentage)
        {
            int width = (int)Math.Round(image.Width * percentage, MidpointRounding.AwayFromZero);
            int height = (int)Math.Round(image.Height * percentage, MidpointRounding.AwayFromZero);
            return resizeImage(image, width, height);
        }

        public byte[] ImageToByte(Bitmap image)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(image, typeof(byte[]));
        }

        public byte[] scanVanBan(string path)
        {
            Image image = Image.FromFile(path);
            Bitmap resizedImage = resizeImage(image, 0.25m);
            return ImageToByte(resizedImage);
        }
    }
}

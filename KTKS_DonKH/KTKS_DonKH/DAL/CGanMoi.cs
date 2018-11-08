using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace KTKS_DonKH.DAL
{
    class CGanMoi
    {
        protected static string _connectionString;  // Chuỗi kết nối
        protected SqlConnection connection;         // Đối tượng kết nối
        protected SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu
        protected SqlCommand command;               // Đối tượng command thực thi truy vấn

        public CGanMoi()
        {
            try
            {
                _connectionString = "Data Source=hp_g7\\KD;Initial Catalog=TANHOA_WATER;Persist Security Info=True;User ID=sa;Password=db8@tanhoa";
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

        public string getDuongCamDao(string SoNha, string TenDuong)
        {
            string leDuong = "";
            if (TenDuong == "") return "";
            SoNha = Regex.Replace(SoNha, @"[^0-9/]", "");
            bool duongCamDao = false;
            DataTable tbTenDuong = ExecuteQuery_DataTable("SELECT [GIOIHAN],[NAMKETTHUC],[QUANLY] FROM [DUONGCAMDAO] WHERE [TenDuong] = '" + TenDuong + "'");
            if (tbTenDuong.Rows.Count > 0)
            {
                if (SoNha.Contains("/"))
                {
                    string SoNha1 = Regex.Replace(SoNha, @"(.*/)\d+", @"$1");
                    string SoNha2 = Regex.Replace(SoNha, @".*/(\d+)", @"$1");
                    tbTenDuong.DefaultView.RowFilter = "GIOIHAN like '" + SoNha1 + "%'";
                    if (tbTenDuong.DefaultView.Count > 0)
                    {
                        int SoNhaInt = Int32.Parse(SoNha2);
                        int SoNhaOdd = SoNhaInt % 2;
                        if (SoNhaOdd == 0)
                            leDuong = "Số chẵn";
                        else
                            leDuong = "Số lẻ";
                        for (int i = 0; i < tbTenDuong.DefaultView.Count; i++)
                        {
                            string[] dauCuoi = Regex.Replace(tbTenDuong.DefaultView[i][0].ToString(), @"[^0-9-/]", "").Split('-');
                            int dauInt = Int32.Parse(dauCuoi[0]);
                            int cuoiInt = Int32.Parse(dauCuoi[1]);
                            if (dauInt % 2 == SoNhaOdd && SoNhaInt >= dauInt && SoNhaInt <= cuoiInt)
                            {
                                duongCamDao = true;
                                tbTenDuong.DefaultView.RowFilter = "GIOIHAN='" + tbTenDuong.DefaultView[i][0].ToString() + "'";
                                break;
                            }
                        }
                    }
                }
                else if (SoNha != "")
                {
                    int SoNhaInt = Int32.Parse(SoNha);
                    int SoNhaOdd = SoNhaInt % 2;
                    if (SoNhaOdd == 0)
                        leDuong = "Số chẵn";
                    else
                        leDuong = "Số lẻ";
                    for (int i = 0; i < tbTenDuong.DefaultView.Count && !tbTenDuong.DefaultView[i][0].ToString().Contains("/"); i++)
                    {
                        string[] dauCuoi = Regex.Replace(tbTenDuong.DefaultView[i][0].ToString(), @"[^0-9-/]", "").Split('-');
                        int dauInt = Int32.Parse(dauCuoi[0]);
                        int cuoiInt = Int32.Parse(dauCuoi[1]);
                        if (dauInt % 2 == SoNhaOdd && SoNhaInt >= dauInt && SoNhaInt <= cuoiInt)
                        {
                            duongCamDao = true;
                            tbTenDuong.DefaultView.RowFilter = "GIOIHAN='" + tbTenDuong.DefaultView[i][0].ToString() + "'";
                            break;
                        }
                    }
                }
                else //khong co dia chi
                {
                    //duongCamDao = true;
                }
            }
            if (duongCamDao)
            {
                string docContent = "ĐƯỜNG CẤM ĐÀO\r\n";
                docContent += String.Format("{0} từ nhà số {1}, kết thúc năm {2}, quản lý {3}", leDuong, tbTenDuong.DefaultView[0][0].ToString().Replace("-", " đến nhà số "), tbTenDuong.DefaultView[0][1].ToString(), tbTenDuong.DefaultView[0][2].ToString());
                return docContent;
            }
            else
                return "";
        }
    }
}

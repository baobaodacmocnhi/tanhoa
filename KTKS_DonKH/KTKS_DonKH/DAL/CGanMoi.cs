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
                _connectionString = "Data Source=server9;Initial Catalog=TANHOA_WATER;Persist Security Info=True;User ID=sa;Password=db9@tanhoa";
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

        public string convertToUnSign(string s)
        {
            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD)).ToUpper();
        }
        //code moi
        private DataTable getDuongCamDao(string tenduong)
        {
            return ExecuteQuery_DataTable(" SELECT [GIOIHAN],[NAMKETTHUC],[QUANLY],[LOAI] FROM [DUONGCAMDAO] WHERE [TENDUONG] = '" + tenduong + "' ORDER BY [LOAI]");
        }

        public string getDuongCamDao(string SoNha, string TenDuong)
        {
            string leDuong = "";
            TenDuong = convertToUnSign(Regex.Replace(TenDuong.Trim(), @"  +", " ").ToUpper()); //, @"(^ +)|(( ) +)|( +$)", "$2"
            if (TenDuong == "") return "";
            SoNha = Regex.Replace(SoNha, @"[^0-9/]", "");
            bool duongCamDao = false;
            DataTable tbTenDuong = getDuongCamDao(TenDuong);
            if (tbTenDuong.Rows.Count > 0)
            {
                if (SoNha.Contains("/"))
                {
                    string soNha1 = Regex.Replace(SoNha, @"(.*/)\d+", @"$1");
                    string soNha2 = Regex.Replace(SoNha, @".*/(\d+)", @"$1");
                    tbTenDuong.DefaultView.RowFilter = "GIOIHAN like '" + soNha1 + "%'";
                    if (tbTenDuong.DefaultView.Count > 0)
                    {
                        int soNhaInt = Int32.Parse(soNha2);
                        int soNhaOdd = soNhaInt % 2;
                        if (soNhaOdd == 0)
                            leDuong = "Số chẵn";
                        else
                            leDuong = "Số lẻ";
                        string filter = "";
                        for (int i = 0; i < tbTenDuong.DefaultView.Count; i++)
                        {
                            string[] dauCuoi = Regex.Replace(tbTenDuong.DefaultView[i][0].ToString(), @"[^0-9-/]", "").Split('-');
                            int dauInt = Int32.Parse(dauCuoi[0]);
                            int cuoiInt = Int32.Parse(dauCuoi[1]);
                            int namKetThuc = (int)tbTenDuong.DefaultView[i][1];
                            if (namKetThuc >= DateTime.Now.Year && dauInt % 2 == soNhaOdd && soNhaInt >= dauInt && soNhaInt <= cuoiInt)
                            {
                                duongCamDao = true;
                                if (filter == "")
                                    filter = "GIOIHAN='" + tbTenDuong.DefaultView[i][0].ToString() + "'";
                                else
                                    filter += " OR GIOIHAN='" + tbTenDuong.DefaultView[i][0].ToString() + "'";
                                //break;
                            }
                        }
                        tbTenDuong.DefaultView.RowFilter = filter;
                    }
                }
                else if (SoNha != "")
                {
                    int soNhaInt = Int32.Parse(SoNha);
                    int soNhaOdd = soNhaInt % 2;
                    if (soNhaOdd == 0)
                        leDuong = "Số chẵn";
                    else
                        leDuong = "Số lẻ";
                    string filter = "";
                    for (int i = 0; i < tbTenDuong.DefaultView.Count; i++)
                    {
                        if (!tbTenDuong.DefaultView[i][0].ToString().Contains("/"))
                        {
                            string[] dauCuoi = Regex.Replace(tbTenDuong.DefaultView[i][0].ToString(), @"[^0-9-/]", "").Split('-');
                            int dauInt = Int32.Parse(dauCuoi[0]);
                            int cuoiInt = Int32.Parse(dauCuoi[1]);
                            int namKetThuc = (int)tbTenDuong.DefaultView[i][1];
                            if (namKetThuc >= DateTime.Now.Year && dauInt % 2 == soNhaOdd && soNhaInt >= dauInt && soNhaInt <= cuoiInt)
                            {
                                duongCamDao = true;
                                if (filter == "")
                                    filter = "GIOIHAN='" + tbTenDuong.DefaultView[i][0].ToString() + "'";
                                else
                                    filter += " OR GIOIHAN='" + tbTenDuong.DefaultView[i][0].ToString() + "'";
                                //break;
                            }
                        }
                    }
                    tbTenDuong.DefaultView.RowFilter = filter;
                }
                else //khong co dia chi
                {
                    //duongCamDao = true;
                }
            }
            if (duongCamDao)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < tbTenDuong.DefaultView.Count; i++)
                {
                    string loai = tbTenDuong.DefaultView[i][3].ToString();
                    string loaiString;
                    switch (loai)
                    {
                        case "0":
                            loaiString = "ĐƯỜNG CẤM ĐÀO";
                            break;
                        case "1":
                            loaiString = "ĐƯỜNG HẠN CHẾ THI CÔNG (CẤM ĐÀO)\r\nTheo Thông báo số 6215/TB-SGTVT\r\n";
                            break;
                        case "2":
                            loaiString = "ĐƯỜNG HẠN CHẾ THI CÔNG BAN NGÀY (PHÉP KHU)\r\nTheo Thông báo số 6214/TB-SGTVT\r\n";
                            break;
                        default:
                            loaiString = "";
                            break;
                    }
                    //sb.Append("<font size='4' color='red'><b>").Append(loaiString).Append("</b></font></br>");
                    sb.Append(loaiString);
                    string gioiHan = tbTenDuong.DefaultView[i][0].ToString();
                    if (gioiHan == "1-9999" || gioiHan == "2-10000")
                        sb.Append("Suốt tuyến");
                    else
                        sb.Append(leDuong).Append(" từ nhà số ").Append(gioiHan.Replace("-", " đến nhà số "));
                    string namKetThuc = tbTenDuong.DefaultView[i][1].ToString();
                    if (namKetThuc != "9999")
                        sb.Append(", kết thúc năm ").Append(namKetThuc);
                    sb.Append(", quản lý ").Append(tbTenDuong.DefaultView[i][2].ToString());
                }
                return sb.ToString();
            }
            else
                return "";
        }

        public bool checkTaiLapChuaCoHoaDon(string DanhBo)
        {
            string sql = "declare @exists bit"
                    + " select @exists= case when exists"
                    + " (SELECT * FROM [TANHOA_WATER].[dbo].[KH_HOSOKHACHHANG] hskh,[TANHOA_WATER].[dbo].[DON_KHACHHANG] donkh"
                    + "   where hskh.HOANCONG=1 and hskh.SHS=donkh.SHS and REPLACE(donkh.DANHBO,'-','')='" + DanhBo + "')"
                    + "   then 1 else 0 end"
                    + " if (@exists=1)"
                    + " begin"
                    + " select case when exists"
                    + " (SELECT * FROM [TANHOA_WATER].[dbo].[KH_HOSOKHACHHANG] hskh,[TANHOA_WATER].[dbo].[DON_KHACHHANG] donkh,HOADON_TA.dbo.HOADON hd"
                    + "   where hskh.HOANCONG=1 and hskh.SHS=donkh.SHS and REPLACE(donkh.DANHBO,'-','')='" + DanhBo + "'"
                    + "   and CAST(hd.CreateDate as date)>CAST(hskh.NGAYHOANCONG as date) and REPLACE(donkh.DANHBO,'-','')=hd.DANHBA)"
                    + "   then 'false' else 'true' end"
                    + " end"
                    + " else"
                    + " select 'false'";
            return bool.Parse(ExecuteQuery_ReturnOneValue(sql).ToString());
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Data;
using System.Data.SqlClient;

namespace KTKS_DonKH.DAL
{
    class CTTKH
    {
        private dbTrungTamKhachHangDataContext db = new dbTrungTamKhachHangDataContext();

        protected static string _connectionString;  // Chuỗi kết nối
        protected SqlConnection connection;         // Đối tượng kết nối
        protected SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu
        protected SqlCommand command;               // Đối tượng command thực thi truy vấn

        public CTTKH()
        {
            try
            {
                _connectionString = KTKS_DonKH.Properties.Settings.Default.TRUNGTAMKHACHHANGConnectionString;
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
            command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
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

        public string getHieuLucKyToi(bool CCDM, int Dot)
        {
            DataTable dt = ExecuteQuery_DataTable("select ds.Ky,ds.Nam,Dot=dsct.IDDot from Lich_DocSo ds,Lich_DocSo_ChiTiet dsct where NgayDoc>=CAST(getdate() as date) and ds.ID=dsct.IDDocSo and dsct.IDDot=" + Dot);
            if (dt != null && dt.Rows.Count > 0)
            {
                //chưa tới đợt đọc số
                if (Dot >= int.Parse(dt.Rows[0]["Dot"].ToString()))
                    if (int.Parse(dt.Rows[0]["Dot"].ToString()) >= 1 && int.Parse(dt.Rows[0]["Dot"].ToString()) <= 12)
                    {
                        if (CCDM)
                            if (dt.Rows[0]["Ky"].ToString() == "11")
                                return "01/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                            else
                                if (dt.Rows[0]["Ky"].ToString() == "12")
                                    return "02/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                                else
                                    return (int.Parse(dt.Rows[0]["Ky"].ToString()) + 2).ToString("00") + "/" + dt.Rows[0]["Nam"].ToString();
                        else
                            if (dt.Rows[0]["Ky"].ToString() == "12")
                                return "01/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                            else
                                return (int.Parse(dt.Rows[0]["Ky"].ToString()) + 1).ToString("00") + "/" + dt.Rows[0]["Nam"].ToString();
                    }
                    else
                        if (int.Parse(dt.Rows[0]["Dot"].ToString()) >= 13 && int.Parse(dt.Rows[0]["Dot"].ToString()) <= 20)
                            if (dt.Rows[0]["Ky"].ToString() == "11")
                                return "01/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                            else
                                if (dt.Rows[0]["Ky"].ToString() == "12")
                                    return "02/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                                else
                                    return (int.Parse(dt.Rows[0]["Ky"].ToString()) + 2).ToString("00") + "/" + dt.Rows[0]["Nam"].ToString();
                        else
                            return "";
                else//đã qua đợt đọc số
                    if (int.Parse(dt.Rows[0]["Dot"].ToString()) >= 1 && int.Parse(dt.Rows[0]["Dot"].ToString()) <= 12)
                    {
                        if (dt.Rows[0]["Ky"].ToString() == "11")
                            return "01/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                        else
                            if (dt.Rows[0]["Ky"].ToString() == "12")
                                return "02/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                            else
                                return (int.Parse(dt.Rows[0]["Ky"].ToString()) + 2).ToString("00") + "/" + dt.Rows[0]["Nam"].ToString();
                    }
                    else
                        if (int.Parse(dt.Rows[0]["Dot"].ToString()) >= 13 && int.Parse(dt.Rows[0]["Dot"].ToString()) <= 20)
                            if (CCDM)
                                if (dt.Rows[0]["Ky"].ToString() == "11")
                                    return "01/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                                else
                                    if (dt.Rows[0]["Ky"].ToString() == "12")
                                        return "02/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                                    else
                                        return (int.Parse(dt.Rows[0]["Ky"].ToString()) + 2).ToString("00") + "/" + dt.Rows[0]["Nam"].ToString();
                            else
                                if (dt.Rows[0]["Ky"].ToString() == "12")
                                    return "01/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                                else
                                    return (int.Parse(dt.Rows[0]["Ky"].ToString()) + 1).ToString("00") + "/" + dt.Rows[0]["Nam"].ToString();
                        else
                            return "";
            }
            else
                return "";
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.Configuration;

namespace WSSmartPhone
{
    class CThuTien : Connection
    {

        public CThuTien()
        {
            _connectionString = ConfigurationManager.AppSettings["ThuTien"].ToString(); ;
        }


        //public CThuTien()
        //{
        //    try
        //    {
        //        _connectionString = "Data Source=192.168.90.9;Initial Catalog=HOADON_TA;Persist Security Info=True;User ID=sa;Password=123@tanhoa";
        //        connection = new SqlConnection(_connectionString);
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        public DataTable GetDSHoaDon(string DanhBo)
        {
            return ExecuteQuery_SqlDataAdapter_DataTable("select * from HOADON where DANHBA='" + DanhBo + "' order by ID_HOADON desc");
        }
    }
}

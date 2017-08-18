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
            _connectionString = ConfigurationManager.AppSettings["ThuTien"].ToString();
        }

        public DataTable GetDSHoaDon(string DanhBo)
        {
            return ExecuteQuery_SqlDataAdapter_DataTable("select * from HOADON where DANHBA='" + DanhBo + "' order by ID_HOADON desc");
        }
    }
}

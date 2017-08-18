using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.Configuration;

namespace WSSmartPhone
{
    class CThuTien
    {
        Connection _DAL = new Connection(ConfigurationManager.AppSettings["BaoBao"].ToString());
        
        public DataTable GetDSHoaDon(string DanhBo)
        {
           return _DAL.ExecuteQuery_SqlDataAdapter_DataTable("select * from HOADON where DANHBA='" + DanhBo + "er by ID_HOADON desc");
        }
    }
}

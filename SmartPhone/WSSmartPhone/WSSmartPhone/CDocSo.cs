using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.Configuration;

namespace WSSmartPhone
{
    class CDocSo
    {
        Connection _DAL = new Connection(ConfigurationManager.AppSettings["ThuTien"].ToString());

   
    }
}

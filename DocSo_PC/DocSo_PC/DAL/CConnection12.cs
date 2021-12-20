using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocSo_PC.DAL
{
    class CConnection12
    {
        public static CConnection _cDAL = new CConnection("");

        public byte[] getHinh(string ID)
        {
            string sql = "SELECT top 1 Image " +
               "FROM DocSoTH_Hinh.dbo.HinhDHN " +
               "WHERE HinhDHNID =" + ID;
            return (byte[])_cDAL.ExecuteQuery_ReturnOneValue(sql);
        }
    }
}

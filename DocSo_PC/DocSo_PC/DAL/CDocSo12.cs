using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocSo_PC.DAL
{
    class CDocSo12
    {
        public static CConnection _cDAL = new CConnection("Data Source=server12;Initial Catalog=DocSoTH;Persist Security Info=True;User ID=sa;Password=db12@tanhoa");

        public byte[] getHinh(string ID)
        {
            string sql = "SELECT top 1 Image " +
               "FROM DocSoTH_Hinh.dbo.HinhDHN " +
               "WHERE HinhDHNID =" + ID;
            return (byte[])_cDAL.ExecuteQuery_ReturnOneValue(sql);
        }
    }
}

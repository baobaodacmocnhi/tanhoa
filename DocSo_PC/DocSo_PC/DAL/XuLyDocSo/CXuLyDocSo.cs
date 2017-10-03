using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using System.Data;

namespace DocSo_PC.DAL.XuLyDocSo
{
    class CXuLyDocSo : CDALTest
    {
        static DocSoTestDataContext db = new DocSoTestDataContext();
        
        public DataTable getMayDS(int tods)
        {
            string sql = "SELECT  May  FROM   MayDS WHERE NhanVienID is not null  ";
            if (tods != 0)
                sql += " AND ToID="+tods;
            sql += " order by may";

            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        
        }
    }
}

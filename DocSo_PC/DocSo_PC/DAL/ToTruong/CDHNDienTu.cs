using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DocSo_PC.DAL.ToTruong
{
    class CDHNDienTu : CDAL
    {
        public DataTable getDS()
        {
            return _cDAL.ExecuteQuery_DataTable("SELECT * FROM [sDHN].[dbo].[sDHN_PMAC]");
        }

        public DataTable getDS_ChiSo(string TableName, DateTime FromDate, DateTime ToDate)
        {
            return _cDAL.ExecuteQuery_DataTable("select CreateDate=TimeStamp,ChiSo=Value FROM [SERVER14].[viwater].[dbo].[" + TableName + "] where CAST(TimeStamp as date)>='" + FromDate.ToString("yyyyMMdd") + "' and CAST(TimeStamp as date)<='" + ToDate.ToString("yyyyMMdd") + "'");
        }

    }
}

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

        public DataTable getDS_ChiSo(string DanhBo, DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = _cDAL.ExecuteQuery_DataTable("SELECT * FROM [sDHN].[dbo].[sDHN_PMAC] where DanhBo='" + DanhBo + "'");
            return _cDAL.ExecuteQuery_DataTable("select CreateDate=t1.TimeStamp,ChiSo=cast(t1.Value-(select t2.Value FROM [SERVER14].[viwater].[dbo].[" + dt.Rows[0]["TableNameNguoc"].ToString() + "] t2 where t2.TimeStamp=t1.TimeStamp) as decimal(10,0)) FROM [SERVER14].[viwater].[dbo].[" + dt.Rows[0]["TableName"].ToString() + "] t1 where CAST(TimeStamp as date)>='" + FromDate.ToString("yyyyMMdd") + "' and CAST(TimeStamp as date)<='" + ToDate.ToString("yyyyMMdd") + "'");
        }

    }
}

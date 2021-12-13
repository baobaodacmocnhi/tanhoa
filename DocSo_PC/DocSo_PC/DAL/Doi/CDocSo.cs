using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using System.Data;

namespace DocSo_PC.DAL.Doi
{
    class CDocSo : CDAL
    {
        public DataTable getDS_Nam()
        {
            string sql = "select Nam=CAST(SUBSTRING(BillID,0,5)as int)"
                          + " from BillState"
                          + " group by SUBSTRING(BillID,0,5)"
                          + " order by Nam desc";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public bool them_BillState(BillState en)
        {
            try
            {
                _db.BillStates.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExists_BillState(string Nam, string Ky, string Dot)
        {
            return _db.BillStates.Any(item => item.BillID == Nam + Ky + Dot);
        }

        public bool checkChuyenBilling_BillState(string Nam, string Ky, string Dot)
        {
            return _db.BillStates.Any(item => item.BillID == Nam + Ky + Dot && item.izDS == "1");
        }

        public bool them_BienDong(BienDong en)
        {
            try
            {
                _db.BienDongs.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public DataTable getDS_TaoDot()
        {
            string sql = "select *"
                        + " ,TongHD=(select COUNT(*) from server9.HOADON_TA.dbo.HOADON where NAM=t1.Nam and KY=t1.Ky-1 and DOT=t1.Dot)"
                        + " ,TongBD=(select COUNT(*) from BienDong where Nam=t1.Nam and Ky=t1.Ky and Dot=t1.Dot)"
                        + " from"
                        + " (select Nam=SUBSTRING(BillID,0,5)"
                        + " ,Ky=SUBSTRING(BillID,5,2)"
                        + " ,Dot=SUBSTRING(BillID,7,2)"
                        + " ,ID=BillID"
                        + " from BillState where BillID like '202112%')t1";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

    }
}

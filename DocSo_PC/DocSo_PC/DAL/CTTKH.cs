using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DocSo_PC.LinQ;

namespace DocSo_PC.DAL
{
    class CTTKH
    {
        public static dbTrungTamKhachHangDataContext _db = new dbTrungTamKhachHangDataContext();
        public static CConnection _cDAL = new CConnection(_db.Connection.ConnectionString);

        public string getHieuLucKyToi()
        {
            DataTable dt = _cDAL.ExecuteQuery_DataTable("select ds.Ky,ds.Nam from Lich_DocSo ds,Lich_DocSo_ChiTiet dsct where NgayDoc>=CAST(getdate() as date) and ds.ID=dsct.IDDocSo");
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Ky"].ToString() == "12")
                    return "01/" + int.Parse(dt.Rows[0]["Nam"].ToString());
                else
                    return (int.Parse(dt.Rows[0]["Ky"].ToString()) + 1).ToString("00") + "/" + dt.Rows[0]["Nam"].ToString();
            }
            else
                return "";
        }

    }
}

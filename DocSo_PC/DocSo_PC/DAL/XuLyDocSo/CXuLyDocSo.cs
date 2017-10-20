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
                sql += " AND ToID=" + tods;
            sql += " order by may";

            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }
        public DataTable getGanMoi(string db)
        {
            string sql = "SELECT DanhBa,NgayKiem,NoiDung,Hieu,Co,ChiSo,NgayCapNhat,NVCapNhat   FROM [DocSoTH].[dbo].[ThongBao]";
            sql += " WHERE  DanhBa='" + db + "' order by NgayKiem asc";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable getDuLieuDocSo(string db, string code, string may, int nam, string ky, string dot)
        {
            string sql = "SELECT DocSoID,MLT1,DanhBa,TTDHNCu,TTDHNMoi,CodeCu,CodeMoi,CSCu,CSMoi,TieuThuMoi,TBTT FROM DocSo ";
            sql += " WHERE Nam=" + nam + " AND Ky='" + ky + "' AND Dot='" + dot + "' ";
            if (!"".Equals(db))
                sql += " AND DanhBa='" + db + "' ";

            if (!"".Equals(code) && !"-1".Equals(code))
                sql += "AND CodeMoi='" + code + "' ";

            if (!"".Equals(may))
                sql += "AND May='" + may + "' ";

            sql += " ORDER BY MLT1 ASC ";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable SumTongSoDS(string tods, string may, int nam, string ky, string dot)
        {
            string sql = "SELECT COUNT(*) AS TSKH, COUNT(CASE WHEN CodeMoi = '' THEN 1 ELSE NULL END) AS TSCG,  ";
            sql += " SUM(TieuThuMoi) AS SANLUONG, ";
            sql += " COUNT(CASE WHEN CodeMoi LIKE 'F%' THEN 1 ELSE NULL END)AS TSDC,  ";
            sql += " COUNT(CASE WHEN TieuThuMoi=0 AND CodeMoi<>'' THEN 1 ELSE NULL END)AS TSHD0  ";
            sql += " FROM DocSo ";
            sql += " WHERE Nam=" + nam + " AND Ky='" + ky + "' ";

            if (!"".Equals(dot))
                sql += "  AND Dot='" + dot + "' ";

            if (!"".Equals(tods))
            {
                if (int.Parse(tods) != 0)
                    sql += " AND TODS= " + tods + "   ";
            }
            if (!"".Equals(may))
                sql += "AND May='" + may + "' ";

            // sql += " ORDER BY MLT1 ASC ";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }


    }
}

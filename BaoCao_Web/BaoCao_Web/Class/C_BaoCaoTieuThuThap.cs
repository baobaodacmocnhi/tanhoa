using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaoCao_Web.DataBase;
using System.Data;

namespace BaoCao_Web.Class
{
    public class C_BaoCaoTieuThuThap
    {
        static log4net.ILog log = log4net.LogManager.GetLogger("File");
        static TanHoaDataContext db = new TanHoaDataContext();

        public static DataTable get_BAOCAO_SANLUONG()
        {
            return Class.LinQConnection.getDataTable("SELECT * FROM W_BAOCAO_SANLUONG");
        }
        public static void RESET_BAOCAO_SANLUONG()
        {
            string sql = "UPDATE [CAPNUOCTANHOA].[dbo].[W_BAOCAO_SANLUONG] ";
            sql += " SET  [KN_DHN] = 0";
            sql += "  ,[KN_SANLUONG] =0";
            sql += "  ,[KT_DHN] = 0";
            sql += "  ,[KT_SANLUONG] = 0";
            sql += "  ,[TANGIAM_DHN] = 0";
            sql += "  ,[TANGIAM_SANLUONG] = 0";
            sql += "  ,[NT_DHN] = 0";
            sql += "  ,[NT_SANLUONG] = 0";
            sql += "  ,[NT_TANGIAM_DHN] = 0";
            sql += "  ,[NT_TANGIAM_SANLUONG] =0";

            try
            {
                int resqult = Class.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));
                log.Info("RESET SO LIEU  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("RESET SO LIEU " + ex.Message);
            }
        }


        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY(string nam, int ky)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG ";
            sql += " SET W_BAOCAO_SANLUONG.KN_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG.KN_SANLUONG= t2.SANLUONG ";
            sql += "FROM W_BAOCAO_SANLUONG INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS, COUNT(case when TieuThuMoi=0 then 1 else null end) AS COUNTDHN, COUNT(case when (TieuThuMoi>=1  AND TieuThuMoi<=4 ) then 1 else null end) AS SANLUONG ";
            sql += " FROM DocSoTH.dbo.DocSo  t  ";
            sql += " WHERE  KY=" + ky + " AND NAM=" + nam;
            sql += " GROUP BY TODS ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_SANLUONG.TODS = t2.TODS";

            try
            {
                int resqult = LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC(string nam, int ky)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG ";
            sql += " SET W_BAOCAO_SANLUONG.KT_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG.KT_SANLUONG= t2.SANLUONG ";
            sql += "FROM W_BAOCAO_SANLUONG INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS, COUNT(case when TieuThuMoi=0 then 1 else null end) AS COUNTDHN,COUNT(case when (TieuThuMoi>=1  AND TieuThuMoi<=4 ) then 1 else null end) AS SANLUONG ";
            sql += " FROM DocSoTH.dbo.DocSo  t  ";
            sql += " WHERE  KY=" + ky + " AND NAM=" + nam;
            sql += " GROUP BY TODS ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_SANLUONG.TODS = t2.TODS";

            try
            {
                int resqult = LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC(string nam, int ky)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG ";
            sql += " SET W_BAOCAO_SANLUONG.NT_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG.NT_SANLUONG= t2.SANLUONG ";
            sql += "FROM W_BAOCAO_SANLUONG INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS, COUNT(case when TieuThuMoi=0 then 1 else null end) AS COUNTDHN,COUNT(case when (TieuThuMoi>=1  AND TieuThuMoi<=4 ) then 1 else null end) AS SANLUONG ";
            sql += " FROM DocSoTH.dbo.DocSo  t  ";
            sql += " WHERE  KY=" + ky + " AND NAM=" + nam;
            sql += " GROUP BY TODS ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_SANLUONG.TODS = t2.TODS";

            try
            {
                int resqult = LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC " + ex.Message);
            }
        }


        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM()
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG ";
            sql += " SET TANGIAM_DHN =KN_DHN-KT_DHN, ";
            sql += " TANGIAM_SANLUONG =KN_SANLUONG-KT_SANLUONG, ";
            sql += " NT_TANGIAM_DHN =KN_DHN- NT_DHN ,";
            sql += " NT_TANGIAM_SANLUONG =KN_SANLUONG -NT_SANLUONG ";

            try
            {
                int resqult = Class.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC " + ex.Message);
            }
        }
        /// chi tiet tung may doc so 
        /// 
        public static DataTable get_BAOCAO_SANLUONG_MAY()
        {
            string sql = "SELECT '    '+(CONVERT(VARCHAR(10),TODS)+' '+CASE WHEN MAYDS<10 THEN '0'+(CONVERT(VARCHAR(10),MAYDS)) ELSE (CONVERT(VARCHAR(10),MAYDS)) END) AS TENTO, KN_DHN, KN_SANLUONG, KT_DHN, KT_SANLUONG, TANGIAM_DHN, TANGIAM_SANLUONG, NT_DHN, NT_SANLUONG, NT_TANGIAM_DHN, NT_TANGIAM_SANLUONG";
            sql += " FROM W_BAOCAO_SANLUONG_MAY  ORDER BY TODS ASC, MAYDS ASC ";
            return Class.LinQConnection.getDataTable(sql.Replace(@"\t", " "));
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_MAY(string nam, int ky)
        {
            string sql = "INSERT INTO W_BAOCAO_SANLUONG_MAY ";
            sql += " SELECT MAQUAN,MAPHUONG, COUNT(ds.DANHBA) AS 'KN_DHN', ";
            sql += " (case when SUM(ds.TIEUTHU) IS NULL then 0 else SUM(ds.TIEUTHU) end) AS KN_SANLUONG, ";
            sql += " KT_DHN=0,KT_SANLUONG=0,TANGIAM_DHN=0,TANGIAM_SANLUONG=0,NT_DHN=0,NT_SANLUONG=0,NT_TANGIAM_DHN=0,NT_TANGIAM_SANLUONG=0 ";
            sql += " FROM DocSo_PHT.dbo.DS" + nam + " ds , DocSo_PHT.dbo.KHACHHANG kh ";
            sql += " WHERE ds.DANHBA=kh.DANHBA AND MAQUAN IS NOT NULL AND ds.KY=" + ky;
            sql += " GROUP BY MAQUAN,MAPHUONG ";
            try
            {
                Class.LinQConnection.ExecuteCommand("DELETE FROM W_BAOCAO_SANLUONG_MAY ");
                int resqult = Class.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_MAY(string nam, int ky)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG_MAY ";
            sql += " SET W_BAOCAO_SANLUONG_MAY.KT_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG_MAY.KT_SANLUONG= t2.SANLUONG ";
            sql += " FROM W_BAOCAO_SANLUONG_MAY INNER JOIN ";
            sql += " ( ";
            sql += " SELECT MAQUAN,MAPHUONG, COUNT(case when ds.TIEUTHU=0 then 1 else null end) AS COUNTDHN,COUNT(case when (ds.TIEUTHU>=1  AND ds.TIEUTHU<=4 ) then 1 else null end) AS SANLUONG ";
            sql += " FROM DocSo_PHT.dbo.DS" + nam + " ds , DocSo_PHT.dbo.KHACHHANG kh ";
            sql += " WHERE ds.DANHBA=kh.DANHBA AND MAQUAN IS NOT NULL AND ds.KY=" + ky;
            sql += " GROUP BY MAQUAN,MAPHUONG ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_SANLUONG_MAY.TODS = t2.MAQUAN AND W_BAOCAO_SANLUONG_MAY.MAYDS = t2.MAPHUONG";

            try
            {
                int resqult = Class.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_MAY(string nam, int ky)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG_MAY ";
            sql += " SET W_BAOCAO_SANLUONG_MAY.NT_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG_MAY.NT_SANLUONG= t2.SANLUONG ";
            sql += " FROM W_BAOCAO_SANLUONG_MAY INNER JOIN ";
            sql += " ( ";
            sql += " SELECT MAQUAN,MAPHUONG, COUNT(case when ds.TIEUTHU=0 then 1 else null end) AS COUNTDHN,COUNT(case when (ds.TIEUTHU>=1  AND ds.TIEUTHU<=4 ) then 1 else null end) AS SANLUONG ";
            sql += " FROM DocSo_PHT.dbo.DS" + nam + " ds , DocSo_PHT.dbo.KHACHHANG kh ";
            sql += " WHERE ds.DANHBA=kh.DANHBA AND MAQUAN IS NOT NULL AND ds.KY=" + ky;
            sql += " GROUP BY MAQUAN,MAPHUONG ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_SANLUONG_MAY.TODS = t2.MAQUAN AND W_BAOCAO_SANLUONG_MAY.MAYDS = t2.MAPHUONG";
            try
            {
                int resqult = Class.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM_MAY()
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG_MAY ";
            sql += " SET TANGIAM_DHN =KN_DHN-KT_DHN, ";
            sql += " TANGIAM_SANLUONG =KN_SANLUONG-KT_SANLUONG, ";
            sql += " NT_TANGIAM_DHN =KN_DHN- NT_DHN ,";
            sql += " NT_TANGIAM_SANLUONG =KN_SANLUONG -NT_SANLUONG ";

            try
            {
                int resqult = Class.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC " + ex.Message);
            }
        }


        ///// THEO ĐỢT


        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_DOT(string nam, int ky, int dot)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG ";
            sql += " SET W_BAOCAO_SANLUONG.KN_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG.KN_SANLUONG= t2.SANLUONG ";
            sql += "FROM W_BAOCAO_SANLUONG INNER JOIN ";
            sql += "(";
            sql += " SELECT TODS, COUNT(case when TieuThuMoi=0 then 1 else null end) AS COUNTDHN,COUNT(case when (TieuThuMoi>=1  AND TieuThuMoi<=4 ) then 1 else null end) AS SANLUONG ";
            sql += " FROM DocSoTH.dbo.DocSo  t  ";
            sql += " WHERE NAM=" + nam + " AND  KY=" + ky + " AND DOT =" + dot;
            sql += " GROUP BY TODS ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_SANLUONG.TODS=t2.TODS";

            try
            {
                sql = sql.Replace(@"\t", " ");
                int resqult = LinQConnection.ExecuteCommand(sql);

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_DOT " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_DOT(string nam, int ky, int dot)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG ";
            sql += " SET W_BAOCAO_SANLUONG.KT_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG.KT_SANLUONG= t2.SANLUONG ";
            sql += "FROM W_BAOCAO_SANLUONG INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS, COUNT(case when TieuThuMoi=0 then 1 else null end) AS COUNTDHN,COUNT(case when (TieuThuMoi>=1  AND TieuThuMoi<=4 ) then 1 else null end) AS SANLUONG ";
            sql += " FROM DocSoTH.dbo.DocSo  t  ";
            sql += " WHERE NAM=" + nam + " AND  KY=" + ky + " AND DOT =" + dot;
            sql += " GROUP BY TODS ";
            sql += " ) as t2 ";
            sql += " ON W_BAOCAO_SANLUONG.TODS = t2.TODS";

            try
            {
                int resqult = LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_DOT " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_DOT(string nam, int ky, int dot)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG ";
            sql += " SET W_BAOCAO_SANLUONG.NT_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG.NT_SANLUONG= t2.SANLUONG ";
            sql += "FROM W_BAOCAO_SANLUONG INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS, COUNT(case when TieuThuMoi=0 then 1 else null end) AS COUNTDHN,COUNT(case when (TieuThuMoi>=1  AND TieuThuMoi<=4 ) then 1 else null end) AS SANLUONG ";
            sql += " FROM DocSoTH.dbo.DocSo  t  ";
            sql += " WHERE NAM=" + nam + " AND  KY=" + ky + " AND DOT =" + dot;
            sql += " GROUP BY TODS ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_SANLUONG.TODS = t2.TODS";

            try
            {
                int resqult = LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_DOT " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM_DOT()
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG ";
            sql += " SET TANGIAM_DHN =KN_DHN-KT_DHN, ";
            sql += " TANGIAM_SANLUONG =KN_SANLUONG-KT_SANLUONG, ";
            sql += " NT_TANGIAM_DHN =KN_DHN- NT_DHN ,";
            sql += " NT_TANGIAM_SANLUONG =KN_SANLUONG -NT_SANLUONG ";

            try
            {
                int resqult = Class.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_DOT  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_DOT " + ex.Message);
            }
        }
        /// chi tiet tung may doc so 
        /// 
        //public static DataTable get_BAOCAO_SANLUONG_MAY_DOT()
        //{
        //    string sql = "SELECT * FROM W_BAOCAO_SANLUONG_MAY WHERE TODS='" + tods + "' ORDER BY MAYDS ASC ";
        //    return Class.LinQConnection.getDataTable(sql.Replace(@"\t", " "));
        //}

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_MAY_DOT(string nam, int ky, int dot)
        {
            string sql = "INSERT INTO W_BAOCAO_SANLUONG_MAY ";
            sql += " SELECT MAQUAN,MAPHUONG, COUNT(ds.DANHBA) AS 'KN_DHN' ,  ";
            sql += " (case when SUM(ds.TIEUTHU) IS NULL then 0 else SUM(ds.TIEUTHU) end) AS KN_SANLUONG, ";
            sql += " KT_DHN=0,KT_SANLUONG=0,TANGIAM_DHN=0,TANGIAM_SANLUONG=0,NT_DHN=0,NT_SANLUONG=0,NT_TANGIAM_DHN=0,NT_TANGIAM_SANLUONG=0 ";
            sql += " FROM DocSo_PHT.dbo.DS" + nam + " ds , DocSo_PHT.dbo.KHACHHANG kh ";
            sql += " WHERE ds.DANHBA=kh.DANHBA AND MAQUAN IS NOT NULL AND ds.KY=" + ky + " AND ds.DOT =" + dot;
            sql += " GROUP BY MAQUAN,MAPHUONG ";
            try
            {
                Class.LinQConnection.ExecuteCommand("DELETE FROM W_BAOCAO_SANLUONG_MAY ");
                int resqult = Class.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_DOT  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_DOT " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_MAY_DOT(string nam, int ky, int dot)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG_MAY ";
            sql += " SET W_BAOCAO_SANLUONG_MAY.KT_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG_MAY.KT_SANLUONG= t2.SANLUONG ";
            sql += " FROM	W_BAOCAO_SANLUONG_MAY INNER JOIN ";
            sql += " ( ";
            sql += " SELECT MAQUAN,MAPHUONG, COUNT(case when ds.TIEUTHU=0 then 1 else null end) AS COUNTDHN,COUNT(case when (ds.TIEUTHU>=1  AND ds.TIEUTHU<=4 ) then 1 else null end) AS SANLUONG ";
            sql += " FROM DocSo_PHT.dbo.DS" + nam + " ds , DocSo_PHT.dbo.KHACHHANG kh ";
            sql += " WHERE ds.DANHBA=kh.DANHBA AND MAQUAN IS NOT NULL AND ds.KY=" + ky + " AND ds.DOT =" + dot;
            sql += " GROUP BY MAQUAN,MAPHUONG ";
            sql += " ) as t2 ";
            sql += " ON W_BAOCAO_SANLUONG_MAY.TODS = t2.MAQUAN AND W_BAOCAO_SANLUONG_MAY.MAYDS = t2.MAPHUONG";

            try
            {
                int resqult = Class.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_DOT  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_DOT " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_MAY_DOT(string nam, int ky, int dot)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG_MAY ";
            sql += " SET W_BAOCAO_SANLUONG_MAY.NT_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG_MAY.NT_SANLUONG= t2.SANLUONG ";
            sql += " FROM W_BAOCAO_SANLUONG_MAY INNER JOIN ";
            sql += " ( ";
            sql += " SELECT MAQUAN,MAPHUONG, COUNT(case when ds.TIEUTHU=0 then 1 else null end) AS COUNTDHN,COUNT(case when (ds.TIEUTHU>=1  AND ds.TIEUTHU<=4 ) then 1 else null end) AS SANLUONG ";
            sql += " FROM DocSo_PHT.dbo.DS" + nam + " ds , DocSo_PHT.dbo.KHACHHANG kh ";
            sql += " WHERE ds.DANHBA=kh.DANHBA AND MAQUAN IS NOT NULL AND ds.KY=" + ky + " AND ds.DOT =" + dot;
            sql += " GROUP BY MAQUAN,MAPHUONG ";
            sql += " ) as t2 ";
            sql += " ON W_BAOCAO_SANLUONG_MAY.TODS = t2.MAQUAN AND W_BAOCAO_SANLUONG_MAY.MAYDS = t2.MAPHUONG";
            try
            {
                int resqult = Class.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_DOT  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_DOT " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM_MAY_DOT()
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG_MAY ";
            sql += " SET TANGIAM_DHN =KN_DHN-KT_DHN, ";
            sql += " TANGIAM_SANLUONG =KN_SANLUONG-KT_SANLUONG, ";
            sql += " NT_TANGIAM_DHN =KN_DHN- NT_DHN ,";
            sql += " NT_TANGIAM_SANLUONG =KN_SANLUONG -NT_SANLUONG ";

            try
            {
                int resqult = Class.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_DOT  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_DOT " + ex.Message);
            }
        }
    
    }
}
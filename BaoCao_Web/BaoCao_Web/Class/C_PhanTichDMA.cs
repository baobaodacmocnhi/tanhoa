using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaoCao_Web.DataBase;
using System.Data;

namespace BaoCao_Web.Class
{
    public class C_PhanTichDMA
    {
        static log4net.ILog log = log4net.LogManager.GetLogger("File");
        static TanHoaDataContext db = new TanHoaDataContext();

        public static DataTable get_BAOCAO_SANLUONG()
        {
            return LinQConnection.getDataTable("SELECT * FROM GNKDT_THONGTINDMA ORDER BY ID ASC ");
        }

        public static void CAPNHAT_DHN_HH()
        {
            string sql1 = " UPDATE [GNKDT_THONGTINDMA] SET [TONGDHN] = 0 ,[KN_DHN] = 0 ,[KN_SANLUONG] = 0 ,[KT_DHN] = 0 ,[KT_SANLUONG] = 0 ,[TANGIAM_DHN] = 0     ,[TANGIAM_SANLUONG] = 0 ,[NT_DHN] = 0 ,[NT_SANLUONG] = 0 ,[NT_TANGIAM_DHN] = 0   ,[NT_TANGIAM_SANLUONG] =0 ";

            string sql = " UPDATE GNKDT_THONGTINDMA   SET GNKDT_THONGTINDMA.TONGDHN = t2.SL  FROM (SELECT MADMA,COUNT(*) as SL FROM TB_DULIEUKHACHHANG GROUP BY MADMA ) T2  WHERE GNKDT_THONGTINDMA.MADMA=T2.MADMA  ";

            try
            {
                LinQConnection.ExecuteCommand(sql1.Replace(@"\t", " "));
                int resqult = LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));
                log.Info("CAPNHAT_DHN_HH  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHAT_DHN_HH " + ex.Message);
            }
        }



        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY(string nam, int ky)
        {
            string sql = "UPDATE GNKDT_THONGTINDMA ";
            sql += " SET GNKDT_THONGTINDMA.KN_DHN = t2.COUNTDHN, GNKDT_THONGTINDMA.KN_SANLUONG= t2.SANLUONG ";
            sql += "FROM GNKDT_THONGTINDMA INNER JOIN ";
            sql += " ( ";

            sql += " SELECT  MADMA, COUNT(DANHBA) AS COUNTDHN,(case when SUM(TIEUTHU) IS NULL then 0 else SUM(TIEUTHU) end) AS SANLUONG ";
            sql += " FROM [SERVER9].[HOADON_TA].[dbo].[HOADON] ds, TB_DULIEUKHACHHANG kh  ";
            sql += " WHERE kh.DANHBO=ds.DANHBA AND ds.KY=" + ky + " AND ds.NAM=" + nam + " AND kh.KY_<=" + ky;
            sql += " GROUP BY MADMA ";

            sql += " ) as t2 ";
            sql += " ON	GNKDT_THONGTINDMA.MADMA = t2.MADMA";


            try
            {
                int resqult = LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC(int nam, int ky)
        {
           
            int nam_ = nam;
            int ky_ = ky;

            if (ky == 1)
            {
                nam_ = nam - 1;
                ky_ = 12;
            }
            else
            {
                ky_ = ky - 1;
            }


            string sql = "UPDATE GNKDT_THONGTINDMA ";
            sql += " SET GNKDT_THONGTINDMA.KT_DHN = t2.COUNTDHN, GNKDT_THONGTINDMA.KT_SANLUONG= t2.SANLUONG ";
            sql += "FROM GNKDT_THONGTINDMA INNER JOIN ";
            sql += " ( ";

            sql += " SELECT  MADMA, COUNT(DANHBA) AS COUNTDHN,(case when SUM(TIEUTHU) IS NULL then 0 else SUM(TIEUTHU) end) AS SANLUONG ";
            sql += " FROM [SERVER9].[HOADON_TA].[dbo].[HOADON] ds, TB_DULIEUKHACHHANG kh  ";
            sql += " WHERE kh.DANHBO=ds.DANHBA AND ds.KY=" + ky_ + " AND ds.NAM=" + nam + " AND kh.KY_<=" + ky;
            sql += " GROUP BY MADMA ";

            sql += " ) as t2 ";
            sql += " ON	GNKDT_THONGTINDMA.MADMA = t2.MADMA";


            try
            {
                int resqult = LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC(int nam, int ky)
        {
           

            int nam_ = nam;
            int ky_ = ky;
            nam_ = nam - 1;

            string sql = "UPDATE GNKDT_THONGTINDMA ";
            sql += " SET GNKDT_THONGTINDMA.NT_DHN = t2.COUNTDHN, GNKDT_THONGTINDMA.NT_SANLUONG= t2.SANLUONG ";
            sql += "FROM GNKDT_THONGTINDMA INNER JOIN ";
            sql += " ( ";

            sql += " SELECT  MADMA, COUNT(DANHBA) AS COUNTDHN,(case when SUM(TIEUTHU) IS NULL then 0 else SUM(TIEUTHU) end) AS SANLUONG ";
            sql += " FROM [SERVER9].[HOADON_TA].[dbo].[HOADON] ds, TB_DULIEUKHACHHANG kh  ";
            sql += " WHERE kh.DANHBO=ds.DANHBA AND ds.KY=" + ky + " AND ds.NAM=" + nam_ + " AND kh.KY_<=" + ky;
            sql += " GROUP BY MADMA ";

            sql += " ) as t2 ";
            sql += " ON	GNKDT_THONGTINDMA.MADMA = t2.MADMA";

            try
            {
                int resqult = LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM()
        {
            string sql = "UPDATE GNKDT_THONGTINDMA ";
            sql += " SET TANGIAM_DHN =KN_DHN-KT_DHN, ";
            sql += " TANGIAM_SANLUONG =KN_SANLUONG-KT_SANLUONG, ";
            sql += " NT_TANGIAM_DHN =KN_DHN- NT_DHN ,";
            sql += " NT_TANGIAM_SANLUONG =KN_SANLUONG -NT_SANLUONG ";

            try
            {
                int resqult = LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC " + ex.Message);
            }
        }
    }
}
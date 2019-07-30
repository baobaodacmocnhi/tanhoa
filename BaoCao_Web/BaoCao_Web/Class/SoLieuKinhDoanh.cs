using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaoCao_Web.DataBase;
using log4net;
using System.Data;

namespace BaoCao_Web.Class
{
    public class SoLieuKinhDoanh
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SoLieuKinhDoanh).Name);
        private static TanHoaDataContext db = new TanHoaDataContext();
        
        public static DataTable getSoLieuByYear(string year)
        {
            string query2 = "SELECT TOP(1) * FROM BAOCAO_KINHDOANH WHERE NAM ='" + (int.Parse(year)-1) + "' AND KY=12 ";
            string query = "SELECT * FROM BAOCAO_KINHDOANH WHERE NAM ='" + year + "'  ORDER BY NAM,KY ASC ";
            DataTable tb = LinQConnection.getDataTable(query2);
            tb.Merge(LinQConnection.getDataTable(query));
            return tb;
        }

        public static bool Update() {

            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }

        public static bool Insert(BAOCAO_KINHDOANH bc)
        {

            try
            {
                db.BAOCAO_KINHDOANHs.InsertOnSubmit(bc);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }

        public static BAOCAO_KINHDOANH findByKy(int ky, int nam) {
            try
            {
                var query = from q in db.BAOCAO_KINHDOANHs where q.KY == ky && q.NAM == nam select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

            }
            return null;
            
        }
        public static DataTable SoSanhSoLieu(string nam, string nam2) { 
        
string query = " SELECT *,DOANHTHU1-DOANHTHU AS DOANHTHU2, ";
query += " DT_KY1- ISNULL(DT_KY,0) AS DT_KY2,";
query += " DT_4KY1-ISNULL(DT_4KY,0) AS DT_4KY2,"; 
query += " SANLUONG1-ISNULL(SANLUONG,0) AS SANLUONG2,";
query += " SLDHN1-ISNULL(SLDHN,0) AS SLDHN2,";
query += " TANGDHN1-ISNULL(TANGDHN,0) AS TANGDHN2,";
query += " DHN_NHO31-ISNULL(DHN_NHO3,0) AS DHN_NHO32,";
query += " GIABQ1-ISNULL(GIABQ,0) AS GIABQ2,";
query += " TONG_DM1-ISNULL(TONG_DM,0) AS TONG_DM2,";
query += " HDTB_PN1-ISNULL(HDTB_PN,0) AS HDTB_PN2,";
query += " HDTB_TB1-ISNULL(HDTB_TB,0) AS HDTB_TB2,";
query += " HDTB_TP1-ISNULL(HDTB_TP,0) AS HDTB_TP2,";
query += " HDTB1-ISNULL(HDTB,0) AS HDTB2,";
query += " HDTB_TANG1-ISNULL(HDTB_TANG,0) AS HDTB_TANG2,";
query += " HOADON01-ISNULL(HOADON0,0) AS HOADON02,";
query += " HOADON0_PN1-ISNULL(HOADON0_PN,0) AS HOADON0_PN2,";
query += " HOADON0_TB1-ISNULL(HOADON0_TB,0) AS HOADON0_TB2,";
query += " HOADON0_TP1-ISNULL(HOADON0_TP,0) AS HOADON0_TP2,";
query += " HOADON0_TG1-ISNULL(HOADON0_TG,0) AS HOADON0_TG2,";
query += " HOADON41-ISNULL(HOADON4,0) AS HOADON42,";
query += " HOADON4_PN1-ISNULL(HOADON4_PN,0) AS HOADON4_PN2,";
query += " HOADON4_TB1-ISNULL(HOADON4_TB,0) AS HOADON4_TB2,";
query += " HOADON4_TP1-ISNULL(HOADON4_TP,0) AS HOADON4_TP2,";
query += " HOADON4_TG1-ISNULL(HOADON4_TG,0) AS HOADON4_TG2,";
query += " HDTON_TRUOC1-ISNULL(HDTON_TRUOC,0) AS HDTON_TRUOC,";
query += " HDTON_TONG1-ISNULL(HDTON_TONG,0) AS HDTON_TONG2,";
query += " HDTON_TG1-ISNULL(HDTON_TG,0) AS HDTON_TG2,";
query += " HDTON_CQ1-ISNULL(HDTON_CQ,0) AS HDTON_CQ2,";
query += " SLTON_TONG1-ISNULL(SLTON_TONG,0) AS SLTON_TONG2,";
query += " SLTON_TG1-ISNULL(SLTON_TG,0) AS SLTON_TG2,";
query += " SLTON_CQ1-ISNULL(SLTON_TG,0) AS SLTON_TG2";
query += " FROM (";
query += " SELECT KY,'" + nam + "' as 'NAM', DOANHTHU, DT_KY, DT_4KY, SANLUONG, SLDHN, TANGDHN, ";
	query += " DHN_NHO3, GIABQ, TONG_DM, HDTB_PN, HDTB_TB, HDTB_TP, HDTB, ";
	query += " HDTB_TANG, HOADON0, HOADON0_PN, HOADON0_TB, HOADON0_TP, ";
	query += " HOADON0_TG, HOADON4, HOADON4_PN, HOADON4_TB, HOADON4_TP, ";
	query += " HOADON4_TG, HDTON_TRUOC, HDTON_TONG, HDTON_TG, HDTON_CQ, ";
	query += " SLTON_TONG, SLTON_TG, SLTON_CQ ";
	query += " FROM BAOCAO_KINHDOANH WHERE NAM="+nam+") AS T1";
query += " FULL OUTER JOIN (";
query += " SELECT KY AS KY1 ,'" + nam2 + "' AS NAM1,DOANHTHU AS DOANHTHU1,DT_KY AS DT_KY1,DT_4KY AS DT_4KY1,SANLUONG AS SANLUONG1,SLDHN AS SLDHN1,";
	query += " TANGDHN AS TANGDHN1,DHN_NHO3 AS DHN_NHO31,GIABQ AS GIABQ1,TONG_DM AS TONG_DM1,HDTB_PN AS HDTB_PN1,";
	query += " HDTB_TB AS HDTB_TB1,HDTB_TP AS HDTB_TP1,HDTB AS HDTB1,HDTB_TANG AS HDTB_TANG1,HOADON0 AS HOADON01,";
	query += " HOADON0_PN AS HOADON0_PN1,HOADON0_TB AS HOADON0_TB1,HOADON0_TP AS HOADON0_TP1,HOADON0_TG AS HOADON0_TG1,";
	query += " HOADON4 AS HOADON41,HOADON4_PN AS HOADON4_PN1,HOADON4_TB AS HOADON4_TB1,HOADON4_TP AS HOADON4_TP1,";
	query += " HOADON4_TG AS HOADON4_TG1,HDTON_TRUOC AS HDTON_TRUOC1,HDTON_TONG AS HDTON_TONG1,HDTON_TG AS HDTON_TG1,";
    query += " HDTON_CQ AS HDTON_CQ1,SLTON_TONG AS SLTON_TONG1,SLTON_TG AS SLTON_TG1,SLTON_CQ AS SLTON_CQ1 FROM BAOCAO_KINHDOANH WHERE NAM=" + nam2 + "";
query += " ) AS T2";
query += " ON T1.KY=T2.KY1 ORDER BY KY ASC ";

return Class.LinQConnection.getDataTable(query);

        }

    }
}
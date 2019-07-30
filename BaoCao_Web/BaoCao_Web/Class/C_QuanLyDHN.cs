using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using log4net;
using System.Configuration;
using BaoCao_Web.DataBase;

namespace BaoCao_Web.Class
{
    class C_QuanLyDHN
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_QuanLyDHN).Name);

        static TanHoaDataContext db = new TanHoaDataContext();

        public static string getNhanVienDS(int mayds)
        {

            string tennv = "";
            var query = from q in db.TB_NHANVIENDOCSOs where q.MAYDS == mayds select q;
            TB_NHANVIENDOCSO nv = query.SingleOrDefault();
            if (nv != null)
            {
                return nv.NAME;
            }
            return tennv;
        }


        public static DataSet getThongKeDHN(int ky, int nam)
        {
            LinQConnection.ExecuteStoredProcedure("THONGKEDHN", ky, nam);
            DataSet ds = new DataSet();
            TanHoaDataContext db = new TanHoaDataContext();

            db.Connection.Open();
            string query = "SELECT * FROM TB_THONGKEDHN WHERE HIEUCU='False' ORDER BY STT ASC ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_THONGKEDHN");


            query = "SELECT * FROM TB_THONGKEDHN  WHERE HIEUCU='True' ORDER BY STT ASC";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_THONGKEDHN_CU");

            query = "SELECT SUM(CO15) AS SUM_CO15, SUM(CO20) AS SUM_CO20, SUM(CO25) AS SUM_CO25, SUM(CO40) AS SUM_CO40, SUM(CO50) AS SUM_CO50, SUM(CO80) AS SUM_CO80, SUM(CO100) AS SUM_CO100, SUM(CO150) AS SUM_CO150, SUM(CO200) AS SUM_CO200, SUM(NHOCO15) AS SUM_NHOCO15, SUM(NHOCO20) AS SUM_NHOCO20, SUM(NHOCO25) AS SUM_NHOCO25, SUM(NHOCO40) AS SUM_NHOCO40, SUM(NHOCO50) AS SUM_NHOCO50, SUM(NHOCO80) AS SUM_NHOCO80, SUM(NHOCO100) AS SUM_NHOCO100, SUM(NHOCO150) AS SUM_NHOCO150, SUM(NHOCO200) AS SUM_NHOCO200, SUM(LONCO15) AS SUM_LONCO15, SUM(LONCO20) AS SUM_LONCO20, SUM(LONCO25) AS SUM_LONCO25, SUM(LONCO40) AS SUM_LONCO40, SUM(LONCO50) AS SUM_LONCO50, SUM(LONCO80) AS SUM_LONCO80, SUM(LONCO100) AS SUM_LONCO100, SUM(LONCO150) AS SUM_LONCO150, SUM(LONCO200) AS SUM_LONCO200 FROM TB_THONGKEDHN";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_THONGKEDHN_SUM");
            return ds;
        }

        static string khoi = ConfigurationManager.AppSettings["khoi"].ToString();
        public static void CAPNHAT_BIENDOCCHISO(string nam, int ky, int dot)
        {

            //int codhn = int.Parse(ConfigurationManager.AppSettings["codhn"].ToString());
            string sql = " UPDATE TB_NHANVIENDOCSO ";

            if (dot == 0)
            {
                sql += " SET SOLUONGDHN=t2.SOLUONG,SANLUONG=t2.SANLUONG,KHONGGHI=t2.KOGHI,TANG=t2.TANG,GIAM=t2.GAM ,NHAXD=t2.XAYDUNG,GIENG=t2.GIENG ";
                sql += " FROM	TB_NHANVIENDOCSO INNER JOIN  ";
                sql += " (  ";
                sql += " SELECT t.MAY, COUNT(t.DANHBA) AS SOLUONG,(case when SUM(t.TieuThuMoi) IS NULL then 0 else SUM(CASE WHEN t.TieuThuMoi<0 THEN 0 ELSE t.TieuThuMoi END) end) AS SANLUONG,";
                sql += "  COUNT(case when (t.CodeMoi LIKE 'F%' OR t.CodeMoi='61' OR t.CodeMoi='64'  OR t.CodeMoi='66')  then 1 else null end) AS KOGHI,";
                sql += "   COUNT(case when (t.GhiChuDS LIKE N'%Xây dựng%') then 1 else null end )AS XAYDUNG,";
                sql += " COUNT(case when (t.TieuThuMoi >= (t.TBTT * 1.51)) AND t.CodeMoi='4' then 1 else null end) AS TANG,";
                sql += " COUNT(case when (t.TieuThuMoi <= (t.TBTT * 0.51)) AND t.CodeMoi='4' then 1 else null end) AS GAM,";
                sql += " COUNT(case when t.GhiChuDS LIKE N'%GIẾ%' then 1 else null end) AS GIENG";
                sql += " FROM DocSoTH.dbo.DocSo  t  ";

              
                    sql += " WHERE NAM=" + nam + "  AND KY=" + ky;


                sql += " GROUP BY  MAY ";
                sql += " ) as t2 ";
                sql += " ON TB_NHANVIENDOCSO.MAYDS = t2.MAY";
            }
            else
            {
                sql += " SET SOLUONGDHN=t2.SOLUONG,SANLUONG=t2.SANLUONG,KHONGGHI=t2.KOGHI,TANG=t2.TANG,GIAM=t2.GAM ,NHAXD=t2.XAYDUNG,GIENG=t2.GIENG ";
                sql += " FROM	TB_NHANVIENDOCSO INNER JOIN  ";
                sql += " (  ";
                sql += " SELECT t.MAY, COUNT(t.DANHBA) AS SOLUONG,(case when SUM(t.TieuThuMoi) IS NULL then 0 else SUM(CASE WHEN t.TieuThuMoi<0 THEN 0 ELSE t.TieuThuMoi END) end) AS SANLUONG,";
                sql += "  COUNT(case when (t.CodeMoi LIKE 'F%' OR t.CodeMoi='61' OR t.CodeMoi='64'  OR t.CodeMoi='66')  then 1 else null end) AS KOGHI,";
                sql += "   COUNT(case when (t.GhiChuDS LIKE N'%Xây dựng%') then 1 else null end )AS XAYDUNG,";
                sql += " COUNT(case when (t.TieuThuMoi >= (t.TBTT * 1.51)) AND t.CodeMoi='4' then 1 else null end) AS TANG,";
                sql += " COUNT(case when (t.TieuThuMoi <= (t.TBTT * 0.51)) AND t.CodeMoi='4' then 1 else null end) AS GAM,";
                sql += " COUNT(case when t.GhiChuDS LIKE N'%GIẾ%' then 1 else null end) AS GIENG";
                sql += " FROM DocSoTH.dbo.DocSo  t ";

              
                    sql += " WHERE  KY=" + ky + " AND  NAM=" + nam + "  AND DOT =" + dot + "";
                sql += " GROUP BY  MAY ";
                sql += " ) as t2 ";
                sql += " ON TB_NHANVIENDOCSO.MAYDS = t2.MAY";
            }
            try
            {
                LinQConnection.ExecuteCommand("UPDATE TB_NHANVIENDOCSO SET SOLUONGDHN=0, SANLUONG=0, KHONGGHI=0, NHAXD=0, TANG=0, GIAM=0");
                sql = sql.Replace(@"\t", " ");
                int resqult = LinQConnection.ExecuteCommand(sql);
                log.Info("CAPNHAT_BIENDOCCHISO  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHAT_BIENDOCCHISO " + ex.Message);
            }
            //string sql = "UPDATE TB_NHANVIENDOCSO ";
            //sql += " SET SET SOLUONGDHN=t2.SOLUONG,SANLUONG=t2.SANLUONG,KHONGGHI=t2.KOGHI,TANG=t2.TANG,GIAM=t2.GAM ";
            //sql += " FROM	TB_NHANVIENDOCSO INNER JOIN  ";
            //sql += "(";
            //sql += " SELECT MAY, COUNT(DANHBA) AS SOLUONG,(case when SUM(TIEUTHU) IS NULL then 0 else SUM(TIEUTHU) end) AS SANLUONG, ";
            //sql += "  COUNT(case when (CODE LIKE 'F%' OR CODE='61' OR CODE='64'  OR CODE='66')  then 1 else null end) AS KOGHI ";
            //sql += "  COUNT(case when (t.TIEUTHU-t3.TIEUTHU)>100  then 1 else null end) AS TANG,";
            //sql += "  COUNT(case when (t.TIEUTHU-t3.TIEUTHU)<100  then 1 else null end) AS GAM ";
            //sql += " FROM DocSo_PHT.dbo.DS" + nam;
            //if (dot == 0) {
            //    sql += " WHERE  KY=" + ky;
            //}
            //else
            //{
            //    sql += " WHERE  KY=" + ky + " AND DOT =" + dot;
            //}
            //sql += " GROUP BY MAY ";
            //sql += " ) as t2 ";
            //sql += " ON TB_NHANVIENDOCSO.MAYDS = t2.MAY";

            try
            {
                LinQConnection.ExecuteCommand("UPDATE TB_NHANVIENDOCSO SET SOLUONGDHN=0, SANLUONG=0, KHONGGHI=0, NHAXD=0, TANG=0, GIAM=0");
                sql = sql.Replace(@"\t", " ");
                int resqult = LinQConnection.ExecuteCommand(sql);
                log.Info("CAPNHAT_BIENDOCCHISO  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHAT_BIENDOCCHISO " + ex.Message);
            }
        }

        public static DataTable getTheoDoiBienDocChiSo()
        {
            string query = "SELECT ROW_NUMBER() OVER (ORDER BY MAYDS  ASC) STT, FULLNAME,MAYDS ,SOLUONGDHN  ,SANLUONG   ,KHONGGHI ,NHAXD ,TANG ,GIAM FROM TB_NHANVIENDOCSO  ORDER BY MAYDS ASC ";
            return LinQConnection.getDataTable(query);
        }

        public static DataTable getThoiGianDocDo(string nam, string ky, string dot)
        {
            string query = "SELECT  nv.MAYDS, nv.FULLNAME, COUNT(*) AS SOLUONG , CONVERT(VARCHAR(5),MIN(GIOGHI),108) AS BATDAU,CONVERT(VARCHAR(5),MAX(GIOGHI),108) AS KETHUC ";
            query += " FROM TB_NHANVIENDOCSO nv, DocSoTH.dbo.DocSo ds ";
            query += " WHERE nv.MAYDS  = ds.MAY AND NAM = '" + nam + "' AND ds.KY='" + ky + "' AND ds.DOT='" + dot + "'";
            query += " GROUP BY nv.MAYDS, nv.FULLNAME";
            query += " ORDER BY nv.MAYDS ASC";
            if ("00".Equals(dot))
            {
                query = "SELECT  nv.MAYDS, nv.FULLNAME, COUNT(*) AS SOLUONG , CONVERT(VARCHAR(5),MIN(GIOGHI),108) AS BATDAU,CONVERT(VARCHAR(5),MAX(GIOGHI),108) AS KETHUC ";
                query += " FROM TB_NHANVIENDOCSO nv, DocSoTH.dbo.DocSo ds ";
                query += " WHERE nv.MAYDS  = ds.MAY AND NAM = '" + nam + "' AND ds.KY='" + ky + "'";
                query += " GROUP BY nv.MAYDS, nv.FULLNAME";
                query += " ORDER BY nv.MAYDS ASC";
            }
            return LinQConnection.getDataTable(query);
        }



        public static DataTable getNhanVienDocSo()
        {
            string query = "SELECT MAYDS, NAME FROM TB_NHANVIENDOCSO  ORDER BY MAYDS ASC ";
            return LinQConnection.getDataTable(query);
        }
        public static DataTable getSoDocSo(string nvds, string dot, int ky)
        {
            string query = "";
            if ("00".Equals(dot))
            {
                query = "SELECT ROW_NUMBER() OVER (ORDER BY LOTRINH  ASC) STT,DANHBO, LOTRINH,HOTEN, (SONHA+ '' + TENDUONG ) AS DCHI,HOPDONG,GIABIEU,DINHMUC,CODH, HIEUDH,SOTHANDH,YEAR(NGAYTHAY) AS NAMGAN, VITRIDHN ";
                query += "FROM TB_DULIEUKHACHHANG KH ";
                query += "WHERE CONVERT(INT,SUBSTRING(RTRIM(LOTRINH),3,2))='" + nvds + "' AND KY<=" + ky;
            }
            else
            {
                query = "SELECT ROW_NUMBER() OVER (ORDER BY LOTRINH  ASC) STT,DANHBO, LOTRINH,HOTEN, (SONHA+ '' + TENDUONG ) AS DCHI,HOPDONG,GIABIEU,DINHMUC,CODH, HIEUDH,SOTHANDH,YEAR(NGAYTHAY) AS NAMGAN, VITRIDHN ";
                query += "FROM TB_DULIEUKHACHHANG KH ";
                query += "WHERE LEFT(RTRIM(LOTRINH),2)='" + dot + "' AND CONVERT(INT,SUBSTRING(RTRIM(LOTRINH),3,2))='" + nvds + "' AND KY<=" + ky;
            }
            return LinQConnection.getDataTable(query);
        }
        public static DataTable getSoThan(string sothan)
        {
            string query = "";
            query = "SELECT ROW_NUMBER() OVER (ORDER BY LOTRINH  ASC) STT,DANHBO, LOTRINH,HOTEN, (SONHA+ ' ' + TENDUONG ) AS DCHI,HOPDONG,GIABIEU,DINHMUC,CODH, HIEUDH,SOTHANDH,YEAR(NGAYTHAY) AS NAMGAN, VITRIDHN,CHISOKYTRUOC ";
            query += "FROM TB_DULIEUKHACHHANG KH ";
            query += "WHERE SOTHANDH LIKE '%" + sothan + "%' ";
            return LinQConnection.getDataTable(query);
        }
        public static DataTable getDiaChi(string diachi)
        {
            string query = "";
            query = "SELECT ROW_NUMBER() OVER (ORDER BY LOTRINH  ASC) STT,DANHBO, LOTRINH,HOTEN, (SONHA+ ' ' + TENDUONG ) AS DCHI,HOPDONG,GIABIEU,DINHMUC,CODH, HIEUDH,SOTHANDH,YEAR(NGAYTHAY) AS NAMGAN, VITRIDHN,CHISOKYTRUOC ";
            query += "FROM TB_DULIEUKHACHHANG KH ";
            query += "WHERE (SONHA+' '+ TENDUONG) LIKE '%" + diachi + "%' ";
            return LinQConnection.getDataTable(query);
        }
    }
}
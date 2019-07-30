using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaoCao_Web.DataBase;
using System.Data;
using System.Data.SqlClient;

namespace BaoCao_Web.Class
{
    public class C_ToChucHanhChanh
    {
        static log4net.ILog log = log4net.LogManager.GetLogger("File");
        static TanHoaDataContext db = new TanHoaDataContext();

        public static TCHC_GIAYXINVE finById(int id)
        {
            try
            {
                var query = from q in db.TCHC_GIAYXINVEs where q.ID == id select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static void Insert(TCHC_GIAYXINVE tb)
        {
            try
            {
                db.TCHC_GIAYXINVEs.InsertOnSubmit(tb);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public static void Delete(TCHC_GIAYXINVE tb)
        {
            try
            {
                db.TCHC_GIAYXINVEs.DeleteOnSubmit(tb);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public static bool Update()
        {
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

        public static DataTable getDuLieuXinVe(string month,string nam)
        {
            // không thời hạn
            string sql = "SELECT ID,PHONGBAN,MANV,TENNV,  ";
            sql += "  N'KHÔNG THỜI HẠN' AS LOAICT, ";
            sql += " CONVERT(VARCHAR(20), TUNGAY,103) AS  'TUNGAY' , CONVERT(VARCHAR(20), DENNGAY,103) AS 'DENNGAY',CONVERT(varchar(10),PHUTVAO) AS  'PHUTVAO', CONVERT(varchar(10),PHUTRA) AS  'PHUTRA' ";
            sql += "  FROM TCHC_GIAYXINVE  WHERE  LOAIGP='KT'   ";
            sql += " ORDER BY  PHONGBAN ASC, MANV ASC ";
            DataTable tab = Class.LinQConnection.getDataTable(sql);

            sql = "SELECT ID,PHONGBAN,MANV,TENNV,  ";
            sql += "  N'ĐI NGOÀI' AS LOAICT, ";
            sql += " CONVERT(VARCHAR(20), TUNGAY,103) AS  'TUNGAY' , CONVERT(VARCHAR(20), DENNGAY,103) AS 'DENNGAY',CONVERT(varchar(10),PHUTVAO) AS  'PHUTVAO', CONVERT(varchar(10),PHUTRA) AS  'PHUTRA' ";
            sql += "  FROM TCHC_GIAYXINVE  WHERE  LOAIGP='VH'   ";
            sql += " ORDER BY  PHONGBAN ASC, MANV ASC ";
            tab.Merge(Class.LinQConnection.getDataTable(sql));

            // có thời hạn
            sql = "SELECT ID,PHONGBAN,MANV,TENNV,  ";
            sql += " N'CÓ THỜI HẠN' AS LOAICT, ";
            sql += " CONVERT(VARCHAR(20), TUNGAY,103) AS  'TUNGAY' , CONVERT(VARCHAR(20), DENNGAY,103) AS 'DENNGAY', CONVERT(varchar(10),PHUTVAO) AS  'PHUTVAO', CONVERT(varchar(10),PHUTRA) AS  'PHUTRA'  ";
            sql += "  FROM TCHC_GIAYXINVE  WHERE LOAIGP='TH' AND   THANG='" + month + "' AND YEAR(CREATEDATE)='"+nam+"' "; 
            sql += " ORDER BY  PHONGBAN ASC, MANV ASC ";
            tab.Merge(Class.LinQConnection.getDataTable(sql));

            // công tác có thời hạn
            sql = "SELECT ID,PHONGBAN,MANV,TENNV,  ";
            sql += " N'CÔNG TÁC' AS LOAICT, ";
            sql += " CONVERT(VARCHAR(20), TUNGAY,103) AS  'TUNGAY' , CONVERT(VARCHAR(20), DENNGAY,103) AS 'DENNGAY', CASE WHEN (LOAIGP='TN' OR LOAIGP='CT')  AND (BUOICT='S' OR BUOICT='N') THEN N'SÁNG'  ELSE convert(varchar(10),PHUTVAO) END AS 'PHUTVAO' ,CASE WHEN (LOAIGP='TN' OR LOAIGP='CT') AND (BUOICT='C' OR BUOICT='N') THEN N'CHIỀU' ELSE convert(varchar(10),PHUTRA)  END AS 'PHUTRA'   ";
            sql += "  FROM TCHC_GIAYXINVE  WHERE LOAIGP='CT' AND  THANG='" + month + "' AND YEAR(CREATEDATE)='" + nam + "' ";  
            sql += " ORDER BY  PHONGBAN ASC, MANV ASC ";
            tab.Merge(Class.LinQConnection.getDataTable(sql));

            // có thời hạn
            sql = "SELECT ID,PHONGBAN,MANV,TENNV,  ";
            sql += " CASE WHEN LOAIGP='TN' THEN N'NGÀY' ELSE  CASE WHEN LOAIGP='TH' THEN N'CÓ THỜI HẠN' ELSE  CASE WHEN LOAIGP='TH' THEN N'KHÔNG THỜI HẠN' ELSE CASE WHEN LOAIGP='CT' THEN N'CÔNG TÁC'  END END END END AS LOAICT, ";
            sql += " CONVERT(VARCHAR(20), TUNGAY,103) AS  'TUNGAY' , CONVERT(VARCHAR(20), DENNGAY,103) AS 'DENNGAY', CASE WHEN (LOAIGP='TN' OR LOAIGP='CT')  AND (BUOICT='S' OR BUOICT='N') THEN N'SÁNG'  ELSE convert(varchar(10),PHUTVAO) END AS 'PHUTVAO' ,CASE WHEN (LOAIGP='TN' OR LOAIGP='CT') AND (BUOICT='C' OR BUOICT='N') THEN N'CHIỀU' ELSE convert(varchar(10),PHUTRA)  END AS 'PHUTRA'   ";
            sql += "  FROM TCHC_GIAYXINVE  WHERE LOAIGP NOT IN ('KT','TH','VH','CT') AND  THANG='" + month + "' AND YEAR(CREATEDATE)='" + nam + "' ";  
            sql += " ORDER BY  PHONGBAN ASC, MANV ASC ";
            tab.Merge( Class.LinQConnection.getDataTable(sql));
            return tab;

        }

        public static DataTable getDuLieuXinVe(string PhongBan,string month, string nam)
        {
            // không thời hạn
            string sql = "SELECT ID,PHONGBAN,MANV,TENNV,  ";
            sql += "  N'KHÔNG THỜI HẠN' AS LOAICT, ";
            sql += " CONVERT(VARCHAR(20), TUNGAY,103) AS  'TUNGAY' , CONVERT(VARCHAR(20), DENNGAY,103) AS 'DENNGAY',CONVERT(varchar(10),PHUTVAO) AS  'PHUTVAO', CONVERT(varchar(10),PHUTRA) AS  'PHUTRA' ";
            sql += "  FROM TCHC_GIAYXINVE  WHERE  LOAIGP='KT' and PhongBan='"+PhongBan+"'";
            sql += " ORDER BY  PHONGBAN ASC, MANV ASC ";
            DataTable tab = Class.LinQConnection.getDataTable(sql);

            sql = "SELECT ID,PHONGBAN,MANV,TENNV,  ";
            sql += "  N'ĐI NGOÀI' AS LOAICT, ";
            sql += " CONVERT(VARCHAR(20), TUNGAY,103) AS  'TUNGAY' , CONVERT(VARCHAR(20), DENNGAY,103) AS 'DENNGAY',CONVERT(varchar(10),PHUTVAO) AS  'PHUTVAO', CONVERT(varchar(10),PHUTRA) AS  'PHUTRA' ";
            sql += "  FROM TCHC_GIAYXINVE  WHERE  LOAIGP='VH' and PhongBan='" + PhongBan + "'";
            sql += " ORDER BY  PHONGBAN ASC, MANV ASC ";
            tab.Merge(Class.LinQConnection.getDataTable(sql));

            // có thời hạn
            sql = "SELECT ID,PHONGBAN,MANV,TENNV,  ";
            sql += " N'CÓ THỜI HẠN' AS LOAICT, ";
            sql += " CONVERT(VARCHAR(20), TUNGAY,103) AS  'TUNGAY' , CONVERT(VARCHAR(20), DENNGAY,103) AS 'DENNGAY', CONVERT(varchar(10),PHUTVAO) AS  'PHUTVAO', CONVERT(varchar(10),PHUTRA) AS  'PHUTRA'  ";
            sql += "  FROM TCHC_GIAYXINVE  WHERE LOAIGP='TH' AND   THANG='" + month + "' AND YEAR(CREATEDATE)='" + nam + "' and PhongBan='" + PhongBan + "'";
            sql += " ORDER BY  PHONGBAN ASC, MANV ASC ";
            tab.Merge(Class.LinQConnection.getDataTable(sql));

            // công tác có thời hạn
            sql = "SELECT ID,PHONGBAN,MANV,TENNV,  ";
            sql += " N'CÔNG TÁC' AS LOAICT, ";
            sql += " CONVERT(VARCHAR(20), TUNGAY,103) AS  'TUNGAY' , CONVERT(VARCHAR(20), DENNGAY,103) AS 'DENNGAY', CASE WHEN (LOAIGP='TN' OR LOAIGP='CT')  AND (BUOICT='S' OR BUOICT='N') THEN N'SÁNG'  ELSE convert(varchar(10),PHUTVAO) END AS 'PHUTVAO' ,CASE WHEN (LOAIGP='TN' OR LOAIGP='CT') AND (BUOICT='C' OR BUOICT='N') THEN N'CHIỀU' ELSE convert(varchar(10),PHUTRA)  END AS 'PHUTRA'   ";
            sql += "  FROM TCHC_GIAYXINVE  WHERE LOAIGP='CT' AND  THANG='" + month + "' AND YEAR(CREATEDATE)='" + nam + "' and PhongBan='" + PhongBan + "'";
            sql += " ORDER BY  PHONGBAN ASC, MANV ASC ";
            tab.Merge(Class.LinQConnection.getDataTable(sql));

            // có thời hạn
            sql = "SELECT ID,PHONGBAN,MANV,TENNV,  ";
            sql += " CASE WHEN LOAIGP='TN' THEN N'NGÀY' ELSE  CASE WHEN LOAIGP='TH' THEN N'CÓ THỜI HẠN' ELSE  CASE WHEN LOAIGP='TH' THEN N'KHÔNG THỜI HẠN' ELSE CASE WHEN LOAIGP='CT' THEN N'CÔNG TÁC'  END END END END AS LOAICT, ";
            sql += " CONVERT(VARCHAR(20), TUNGAY,103) AS  'TUNGAY' , CONVERT(VARCHAR(20), DENNGAY,103) AS 'DENNGAY', CASE WHEN (LOAIGP='TN' OR LOAIGP='CT')  AND (BUOICT='S' OR BUOICT='N') THEN N'SÁNG'  ELSE convert(varchar(10),PHUTVAO) END AS 'PHUTVAO' ,CASE WHEN (LOAIGP='TN' OR LOAIGP='CT') AND (BUOICT='C' OR BUOICT='N') THEN N'CHIỀU' ELSE convert(varchar(10),PHUTRA)  END AS 'PHUTRA'   ";
            sql += "  FROM TCHC_GIAYXINVE  WHERE LOAIGP NOT IN ('KT','TH','VH','CT') AND  THANG='" + month + "' AND YEAR(CREATEDATE)='" + nam + "' and PhongBan='" + PhongBan + "'";
            sql += " ORDER BY  PHONGBAN ASC, MANV ASC ";
            tab.Merge(Class.LinQConnection.getDataTable(sql));
            return tab;

        }
    }
}
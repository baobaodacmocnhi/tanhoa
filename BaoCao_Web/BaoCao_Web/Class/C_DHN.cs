using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaoCao_Web.DataBase;
using System.Data;

namespace BaoCao_Web.Class
{
    public class C_DHN
    {
        log4net.ILog log = log4net.LogManager.GetLogger("File");
        TanHoaDataContext db = new TanHoaDataContext();
        // Thong Ke Dong Ho Nuoc
        public static DataTable getCoDHN()
        {
            string sql = "SELECT CONVERT(INT,CODH) AS CODH,COUNT(*) AS SODH ";
            sql += " FROM TB_DULIEUKHACHHANG";
            sql += " GROUP BY CODH";
            sql += " ORDER BY CONVERT(INT,CODH) ASC";
            return LinQConnection.getDataTable(sql);
        }

        public static DataTable getNamGanDHN(string ky, string nam)
        {
            string sql = "SELECT YEAR(NGAYTHAY) AS NGAYTHAY, COUNT(*) AS SODH FROM GET_DLKH_BY_KY(" + nam + "," + ky + ") GROUP BY YEAR(NGAYTHAY) ORDER BY NGAYTHAY;";
            return LinQConnection.getDataTable(sql);
        }
        public static int TongSoDHN(string ky, string nam)
        {
            string sql = "SELECT COUNT(*) FROM GET_DLKH_BY_KY(" + nam + "," + ky + ");";
            return (int)LinQConnection.getDataTable(sql).Rows[0].ItemArray[0];
        }
        public static void getThongKeDHN(int ky, int nam, ref int tongSoDhn, ref object thongKeNam, ref object thongKeHieu)
        {
            DataSet dataset = LinQConnection.ExecuteStoredProcedureDS("THONGKEDHN_HD_FULL", ky, nam);
            tongSoDhn = (int)dataset.Tables[0].Rows[0].ItemArray[0];
            thongKeNam = dataset.Tables[1];
            thongKeHieu = dataset.Tables[2];
        }
        public static DataTable getThongKeThayDHN(string tungay, string denngay)
        {
            string sql = "SELECT COUNT(case when CONVERT(DATETIME,DHN_NGAYBAOTHAY,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) then 1 else null end) AS SOLUONGTHAY ";
            sql += ",COUNT(case when (HCT_TRONGAI ='False' OR HCT_TRONGAI IS NULL) AND  CONVERT(DATETIME,HCT_NGAYGAN,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) then 1 else null end) AS HOANTAT ";
            sql += ",COUNT(case when HCT_TRONGAI ='True' AND  CONVERT(DATETIME,HCT_NGAYGAN,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) then 1 else null end) AS TRONGAI ";
            sql += ", COUNT(case when CONVERT(DATETIME,DHN_NGAYBAOTHAY,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) then 1 else null end) ";
            sql += "-(COUNT(case when (HCT_TRONGAI ='False' OR HCT_NGAYGAN IS NOT NULL) AND  CONVERT(DATETIME,HCT_NGAYGAN,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) then 1 else null end) ";
            sql += " +COUNT(case when HCT_TRONGAI ='True'  AND  CONVERT(DATETIME,HCT_NGAYGAN,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) then 1 else null end)) AS CHUAGAN ";
            sql += " FROM TB_THAYDHN WHERE DHN_DANHBO IS NOT NULL ";

            return LinQConnection.getDataTable(sql);
        }

        public static DataTable getThongKeLoaiBaoThay(string tungay, string denngay)
        {
            string sql = "SELECT REPLACE(TENBANGKE,'THEO','') AS 'BANGKE', COUNT(*) AS 'SOLUONG'";
            sql += " FROM dbo.TB_THAYDHN T , dbo.TB_LOAIBANGKE L WHERE T.DHN_LOAIBANGKE=L.LOAIBK ";
            sql += " AND CONVERT(DATETIME,DHN_NGAYBAOTHAY,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";
            sql += " GROUP BY TENBANGKE ";
            return LinQConnection.getDataTable(sql);
        }

        public static DataTable getTroNgaiThay(string tungay, string denngay)
        {
            string sql = "SELECT loai.TENBANGKE,(DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) as 'SOBANGKE',thay.DHN_DANHBO, kh.HOTEN,(kh.SONHA+' ' +kh.TENDUONG) AS 'DIACHI'  , CONVERT(VARCHAR(20),DHN_NGAYBAOTHAY,103) AS 'NGAYBAO' , HCT_LYDOTRONGAI as 'TRONGAI' ";
            sql += " FROM TB_THAYDHN thay, TB_LOAIBANGKE loai,TB_DULIEUKHACHHANG kh  ";
            sql += " WHERE thay.DHN_DANHBO=kh.DANHBO AND thay.DHN_LOAIBANGKE=loai.LOAIBK  AND HCT_TRONGAI ='1' AND (XLT_XULY='0' OR XLT_XULY IS NULL) ";
            sql += " AND CONVERT(DATETIME,HCT_NGAYGAN,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";
            sql += " ORDER BY DHN_NGAYBAOTHAY DESC";

            return LinQConnection.getDataTable(sql);
        }

        public static DataTable getTroNgaiThay_daxuly(string tungay, string denngay)
        {
            string sql = "SELECT loai.TENBANGKE,(DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) as 'SOBANGKE',thay.DHN_DANHBO, kh.HOTEN,(kh.SONHA+' ' +kh.TENDUONG) AS 'DIACHI'  , CONVERT(VARCHAR(20),DHN_NGAYBAOTHAY,103) AS 'NGAYBAO' , HCT_LYDOTRONGAI as 'TRONGAI', CASE WHEN XLT_CHUYENXL='BANKTKS-DC' THEN N'CHUYỂN KIỂM TRA' ELSE CASE WHEN XLT_CHUYENXL='TCTB' THEN N'CHUYỂN TCTB' ELSE N'ĐỘI XỬ LÝ' END  END AS 'NOIDUNGXULY', XLT_KETQUA ";
            sql += " FROM TB_THAYDHN thay, TB_LOAIBANGKE loai,TB_DULIEUKHACHHANG kh  ";
            sql += " WHERE thay.DHN_DANHBO=kh.DANHBO AND thay.DHN_LOAIBANGKE=loai.LOAIBK  AND HCT_TRONGAI ='1' AND XLT_XULY='1'  ";
            sql += " AND CONVERT(DATETIME,HCT_NGAYGAN,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";
            sql += " ORDER BY DHN_NGAYBAOTHAY DESC";

            return LinQConnection.getDataTable(sql);
        }
        ///////////////////// GIAM HOA DON = 0 //////////////////////////////
        public static DataTable getTheoDoiHoaDon0(string tungay, string denngay)
        {
            string sql = "SELECT COUNT(case when CONVERT(DATETIME,DHN_NGAYGHINHAN,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) then 1 else null end) AS SL_GHINHAN ";
             sql += " ,COUNT(case when (DHN_CAMKET <> '' AND DHN_CAMKET IS NOT NULL) AND  CONVERT(DATETIME,DHN_NGAYGHINHAN,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) then 1 else null end) AS DHN_CAMKET ";
             sql += " ,COUNT(case when (DHN_BAMHI <> '' AND DHN_BAMHI IS NOT NULL) AND  CONVERT(DATETIME,DHN_NGAYGHINHAN,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) then 1 else null end) AS DHN_BAMCHI ";
             sql += " ,COUNT(case when CONVERT(DATETIME,KTKS_NGAYTIEPXUC,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) then 1 else null end) AS KTKS_GHINHAN ";
             sql += " ,COUNT(case when (KTKS_CAMKET <> '' AND KTKS_CAMKET IS NOT NULL) AND  CONVERT(DATETIME,KTKS_NGAYTIEPXUC,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) then 1 else null end) AS KTKS_CAMKET ";
             sql += " ,COUNT(case when (KTKS_BAMHI <> '' AND KTKS_BAMHI IS NOT NULL) AND  CONVERT(DATETIME,KTKS_NGAYTIEPXUC,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) then 1 else null end) AS KTKS_BAMCHI ";
             sql += " FROM DK_GIAMHOADON ";


            return LinQConnection.getDataTable(sql);
        }
    }
}
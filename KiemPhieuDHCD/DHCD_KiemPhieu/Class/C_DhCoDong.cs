using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DHCD_KiemPhieu.Class
{
    public class C_DhCoDong
    {
        public static DataTable getDSCoDongThamDu(string macd)
        {
            string sql = "SELECT  STT, STTCD, MACD, TENCD, CMND, NGAYCAP, NOICAP, DIACHI, CDGD, PHONGTOA, TONGCD  FROM  DSCODONG_THAMDU  ORDER BY NGAYVAO DESC ";
            return LinQConnection.getDataTable(sql);
        }

        public static DataTable getDSCoDongChuaDen()
        {
            string sql = "SELECT  STT, STTCD, MACD, TENCD, CMND, NGAYCAP, NOICAP, DIACHI, CDGD, PHONGTOA, TONGCD  FROM  DSCODONG WHERE MACD NOT IN ( SELECT MACD FROM DSCODONG_THAMDU)  ORDER BY STT ASC ";
            return LinQConnection.getDataTable(sql);
        }

        public static DataTable getDSCoDong(string macd)
        {
            string sql = "SELECT * FROM  DSCODONG ORDER BY STT ASC ";
            if (!"".Equals(macd))
            {
                sql = "SELECT  * FROM  DSCODONG WHERE MACD LIKE N'%" + macd + "%' ORDER BY STT DESC";
            }
            return LinQConnection.getDataTable(sql);
        }
    }
}
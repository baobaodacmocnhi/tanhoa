using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BaoCao_Web.DataBase;

namespace BaoCao_Web.Class
{
    public class C_Chart
    {

        public static DataTable getBienDongDHN(int nam) {
            return LinQConnection.getDataTable("SELECT * FROM CHART_BIENDONGDHN WHERE NAM='"+nam+"' ORDER BY THANG ASC");
        }

        public static DataTable getBienDongSanLuong(string nam) {
            return LinQConnection.getDataTable("SELECT * FROM CHART_SANLUONG WHERE NAM IN (" + nam + ") ORDER BY NAM ASC");
        }
        public static DataTable getSanLuongTrungBinh(string nam)
        {
            return LinQConnection.getDataTable("SELECT * FROM CHART_SANLUONG_TRUNGBINH WHERE NAM IN (" + nam + ") ORDER BY NAM ASC");
        }

        public static DataTable getBienDongDoanhThu(string nam)
        {
            return LinQConnection.getDataTable("SELECT * FROM CHART_DOANHTHU WHERE NAM IN (" + nam + ") ORDER BY NAM ASC");
        }
         
        
    }
}
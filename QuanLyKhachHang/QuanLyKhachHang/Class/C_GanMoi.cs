using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Office.Interop.Excel;

namespace QuanLyKhachHang.Class
{
    public static class C_GanMoi
    {

        //public static DataTable TimDonKH(string shs, string hoten, string diachi, int FirstRow, int pageSize, string dienthoai)
        //{
        //    string sql = "SELECT  biennhan.SHS, biennhan.HOTEN,( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN) as 'DIACHI',DIENTHOAI ,CONVERT(VARCHAR(20),biennhan.NGAYNHAN,103) AS 'NGAYNHAN',lhs.TENLOAI as 'LOAIHS' ";
        //    sql += " FROM QUAN q,PHUONG p,DON_KHACHHANG biennhan, LOAI_HOSO lhs ";
        //    sql += " WHERE biennhan.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN  AND biennhan.PHUONG=p.MAPHUONG AND lhs.MALOAI=biennhan.LOAIHOSO";
        //    if (!"".Equals(shs))
        //    {
        //        //  sql += " AND biennhan.SHS = '" + shs + "'";
        //        sql += " AND (biennhan.SHS = '" + shs + "' OR biennhan.HOSOCHA = '" + shs + "' )";
        //    }
        //    if (!"".Equals(hoten))
        //    {
        //        sql += " AND HOTEN LIKE N'%" + hoten + "%'";
        //    }
        //    if (!"".Equals(dienthoai))
        //    {
        //        sql += " AND DIENTHOAI LIKE N'%" + dienthoai + "%'";
        //    }
        //    if (!"".Equals(diachi))
        //    {
        //        sql += " AND  replace(( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN),' ','')  LIKE N'%" + diachi.Replace(" ", "") + "%'";
        //    }
        //    return LinQConnectionGM.getDataTable(sql);
        //}

    }
}
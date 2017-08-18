using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Configuration;

namespace WSSmartPhone
{
    class CBaoBao
    {
        Connection _DAL = new Connection(ConfigurationManager.AppSettings["BaoBao"].ToString());

        public bool ThemKhachHang(string HoTen, int GioiTinh)
        {
            int ID = 0;
            if (int.Parse(_DAL.ExecuteQuery_SqlDataAdapter_DataTable("select COUNT(ID) from KhachHang").Rows[0][0].ToString()) == 0)
                ID = 1;
            else
                ID = int.Parse(_DAL.ExecuteQuery_SqlDataAdapter_DataTable("select MAX(ID)+1 from KhachHang").Rows[0][0].ToString());
            string sql = "insert into KhachHang(ID,HoTen,GioiTinh)values(" + ID + ",N'" + HoTen + "'," + GioiTinh + ")";
            return _DAL.ExecuteNonQuery(sql);
        }

        public bool XoaKhachHang(string ID)
        {
            return _DAL.ExecuteNonQuery("delete KhachHang where ID=" + ID);
        }

        public DataTable GetDSKhachHang()
        {
            return _DAL.ExecuteQuery_SqlDataAdapter_DataTable("select * from KhachHang");
        }
    }
}
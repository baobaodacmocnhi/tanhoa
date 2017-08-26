using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.Configuration;

namespace WSSmartPhone
{
    class CDocSo
    {
        Connection _DAL = new Connection(ConfigurationManager.AppSettings["DocSo"].ToString());
        Connection _DAL_Test = new Connection("Data Source=192.168.1.8\\KD;Initial Catalog=DocSoSP01;Persist Security Info=True;User ID=sa;Password=123@tanhoa");

        public bool CheckDangNhap(string TaiKhoan, string MatKhau)
        {
            if (_DAL.ExecuteQuery_ReturnOneValue("select MaND from NguoiDung where TaiKhoan='" + TaiKhoan + "' and MatKhau='" + MatKhau + "'") != null)
                return true;
            else
                return false;
        }

        public DataTable DangNhap(string TaiKhoan, string MatKhau)
        {
            return _DAL.ExecuteQuery_SqlDataAdapter_DataTable("select * from NguoiDung where TaiKhoan='" + TaiKhoan + "' and MatKhau='" + MatKhau + "'");
        }

        public DataTable GetDSCode()
        {
            return _DAL.ExecuteQuery_SqlDataAdapter_DataTable("select * from TTDHN order by STT asc");
        }

        public DataTable GetDSDocSo(string Nam, string Ky, string Dot, string May)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @Dot int;"
                        + " declare @May int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @Dot=" + Dot + ";"
                        + " set @May=" + May + ";"
                        + " select a.*,b.*,c.* from"
                        + " (select * from DocSo where Nam=@Nam and Ky=@Ky and Dot=@Dot and May=@May ) a"
                        + " left join"
                        + " (select DanhBa,CSCu2=CSCu,CodeCu2=CodeCu,TieuThuCu2=TieuThuCu from DocSo where Nam=@Nam and Ky=@Ky-1 and Dot=@Dot and May=@May ) b on a.DanhBa=b.DanhBa"
                        + " left join"
                        + " (select DanhBa,CSCu3=CSCu,CodeCu3=CodeCu,TieuThuCu3=TieuThuCu from DocSo where Nam=@Nam and Ky=@Ky-2 and Dot=@Dot and May=@May ) c on a.DanhBa=c.DanhBa"
                        + " order by MLT1 asc";
            return _DAL_Test.ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

    }
}
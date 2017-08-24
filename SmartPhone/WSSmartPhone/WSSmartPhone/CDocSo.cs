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
            return _DAL_Test.ExecuteQuery_SqlDataAdapter_DataTable("select * from DocSo where Nam=" + Nam + " and Ky=" + Ky + " and Dot=" + Dot + " and May=" + May+" order by MLT1 asc");
        }

    }
}

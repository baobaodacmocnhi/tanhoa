using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.HeThong
{
    class CDangNhap
    {
        private static string _taiKhoan = "";
        private static bool _roleTaiKhoan = false;

        public static bool RoleTaiKhoan
        {
            get { return CDangNhap._roleTaiKhoan; }
            set { CDangNhap._roleTaiKhoan = value; }
        }
        public static string TaiKhoan
        {
            get { return _taiKhoan; }
            set { _taiKhoan = value; }
        }

        DB_KTKS_DonKHDataContext db = new DB_KTKS_DonKHDataContext();
        public bool DangNhap(string taikhoan, string matkhau)
        {
            if (db.Users.Any(item => item.TaiKhoan == taikhoan && item.MatKhau == matkhau))
            {
                _taiKhoan = taikhoan;
                //Mã Role Tài Khoản là 1
                if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 1).CapQuyen == true)
                    _roleTaiKhoan = true;
                else
                    _roleTaiKhoan = false;
                return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrungTamKhachHang.LinQ;

namespace TrungTamKhachHang.DAL.QuanTri
{
    class CUser : CTrungTamKhachHang
    {
        static int _MaUser;
        public static int MaUser
        {
            get { return CUser._MaUser; }
            set { CUser._MaUser = value; }
        }

        static string _Name;
        public static string Name
        {
            get { return CUser._Name; }
            set { CUser._Name = value; }
        }

        static bool _Admin;
        public static bool Admin
        {
            get { return CUser._Admin; }
            set { CUser._Admin = value; }
        }

        static int _MaNhom;
        public static int MaNhom
        {
            get { return CUser._MaNhom; }
            set { CUser._MaNhom = value; }
        }

        static System.Data.DataTable _dtQuyenNhom;
        public static System.Data.DataTable dtQuyenNhom
        {
            get { return CUser._dtQuyenNhom; }
            set { CUser._dtQuyenNhom = value; }
        }

        static System.Data.DataTable _dtQuyenNguoiDung;
        public static System.Data.DataTable dtQuyenNguoiDung
        {
            get { return CUser._dtQuyenNguoiDung; }
            set { CUser._dtQuyenNguoiDung = value; }
        }

        public static bool CheckQuyen(string TenMenu, string LoaiQuyen)
        {
            string query = "";
            switch (LoaiQuyen)
            {
                case "Xem":
                    query = "TenMenu ='" + TenMenu + "' and Xem=1";
                    break;
                case "Them":
                    query = "TenMenu ='" + TenMenu + "' and Them=1";
                    break;
                case "Sua":
                    query = "TenMenu ='" + TenMenu + "' and Sua=1";
                    break;
                case "Xoa":
                    query = "TenMenu ='" + TenMenu + "' and Xoa=1";
                    break;
                default:
                    break;
            }
            System.Data.DataRow[] drs;
            ///Kiểm tra quyền theo Nhóm
            if (_dtQuyenNhom != null)
            {
                drs = dtQuyenNhom.Select(query);
                if (drs.Count() > 0)
                    return true;
                else
                    if (dtQuyenNguoiDung != null)
                    {
                        ///Kiểm tra quyền theo Người Dùng
                        drs = dtQuyenNguoiDung.Select(query);
                        if (drs.Count() > 0)
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
            }
            else
                if (dtQuyenNguoiDung != null)
                {
                    ///Kiểm tra quyền theo Người Dùng
                    drs = dtQuyenNguoiDung.Select(query);
                    if (drs.Count() > 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
        }

        public bool Them(User entity)
        {
            try
            {
                if (_db.Users.Count() > 0)
                    entity.ID = _db.Users.Max(item => item.ID) + 1;
                else
                    entity.ID = 1;
                
                entity.CreateBy = CUser.MaUser;
                entity.CreateDate = DateTime.Now;
                _db.Users.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(User entity)
        {
            try
            {
                entity.ModifyBy = CUser.MaUser;
                entity.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaAn(User entity)
        {
            try
            {
                entity.An = true;
                entity.ModifyBy = CUser.MaUser;
                entity.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<User> GetDS()
        {
            return _db.Users.ToList();
        }

        /// <summary>
        /// Lấy Danh Sách Nhân Viên ngoài trừ Mã ND truyền vào
        /// </summary>
        /// <param name="MaND"></param>
        /// <returns></returns>
        public List<User> GetDSExcept(int ID)
        {
            return _db.Users.Where(item => item.ID != ID && item.ID != 0 && item.An == false).ToList();
        }

        public List<User> GetDS_Admin()
        {
            return _db.Users.ToList();
        }

        public User Get(int ID)
        {
            return _db.Users.SingleOrDefault(item => item.ID == ID);
        }

        public User Get(string Username)
        {
            return _db.Users.SingleOrDefault(item => item.Username == Username);
        }

        public bool DangNhap(string Username, string Password)
        {
                return _db.Users.Any(item => item.Username == Username && item.Password == Password);
        }

        public bool CheckExist(string Username)
        {
                return _db.Users.Any(item => item.Username == Username);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection;
using DangBoWeb.LinQ;

namespace DangBoWeb
{
    
    public class DangNhapModel
    {
        [Required]
        [Display(Name = "Tài Khoản")]
        public string TaiKhoan { get; set; }

        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu")]
        public string MatKhau { get; set; }

        public int MaU { set; get; }

        public string HoTen { set; get; }

        public bool Admin { set; get; }

        public DataTable dtQuyenNhom { set; get; }

        public DataTable dtQuyenNguoiDung { set; get; }
    }

    public class DoiMatKhauModel
    {
        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu Cũ")]
        public string MatKhauCu { get; set; }

        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu Mới")]
        public string MatKhauMoi { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác Nhận Mật Khẩu Mới")]
        [Compare("MatKhauMoi", ErrorMessage = "Mật Khẩu Mới và Xác Nhận Mật Khẩu Mới không khớp")]
        public string ConfirmMatKhauMoi { get; set; }
    }

    public class CUserSession
    {
        public static bool checkExistsUserSession()
        {
            DangNhapModel model = getUserSession();
            if (model == null)
                return false;
            else
                return true;
        }

        public static void setUserSession(DangNhapModel user)
        {
            HttpContext.Current.Session["UserSession"] = user;
        }

        public static DangNhapModel getUserSession()
        {
            DangNhapModel user = (DangNhapModel)HttpContext.Current.Session["UserSession"];
            return user;
        }

        public static void removeUserSession()
        {
            HttpContext.Current.Session["UserSession"] = null;
        }

        public static string getHotTenUserSession()
        {
            DangNhapModel model = getUserSession();
            if (model == null)
                return "";
            else
                return model.HoTen;
        }

        public static int getMaUserSession()
        {
            DangNhapModel model = getUserSession();
            if (model == null)
                return -1;
            else
                return model.MaU;
        }

        public static bool getAdminUserSession()
        {
            DangNhapModel model = getUserSession();
            if (model == null)
                return false;
            else
                return model.Admin;
        }

        public static bool CheckQuyen(string TenMenu, string LoaiQuyen)
        {
            DangNhapModel model = getUserSession();
            if (model == null)
                return false;
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
            if (model.dtQuyenNhom != null)
            {
                drs = model.dtQuyenNhom.Select(query);
                if (drs.Count() > 0)
                    return true;
                else
                    if (model.dtQuyenNguoiDung != null)
                {
                    ///Kiểm tra quyền theo Người Dùng
                    drs = model.dtQuyenNguoiDung.Select(query);
                    if (drs.Count() > 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                if (model.dtQuyenNguoiDung != null)
            {
                ///Kiểm tra quyền theo Người Dùng
                drs = model.dtQuyenNguoiDung.Select(query);
                if (drs.Count() > 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }

    public class CDAL
    {
        private static dbDangBo _db = new dbDangBo();

        public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        public static DataTable getDS_PhanQuyenNhom(int MaTT_Nhom)
        {
            return LINQToDataTable(_db.PhanQuyenNhoms.Where(item => item.MaNhom == MaTT_Nhom).Select(item =>
            new { item.Menu.TextMenuCha, item.Menu.STT, item.MaMenu, item.Menu.TenMenu, item.Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa, item.ToanQuyen, item.QuanLy }).ToList());
        }

        public static DataTable getDS_PhanQuyenNguoiDung(int MaND)
        {
            return LINQToDataTable(_db.PhanQuyenNguoiDungs.Where(item => item.MaND == MaND).Select(item =>
            new { item.Menu.TextMenuCha, item.Menu.STT, item.MaMenu, item.Menu.TenMenu, item.Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa, item.ToanQuyen, item.QuanLy }).ToList());
        }
    }

}
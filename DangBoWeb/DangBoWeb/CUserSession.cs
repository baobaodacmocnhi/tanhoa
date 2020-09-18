using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DangBoWeb
{
    public class CUserSession
    {
        public static void setUser(CUserSessionChild user)
        {
            HttpContext.Current.Session["User"] = user;
        }

        public static CUserSessionChild getUser()
        {
            var user = HttpContext.Current.Session["User"];
            if (user == null)
                return null;
            else
                return (CUserSessionChild)user;
        }
    }

    [Serializable]
    public class CUserSessionChild
    {
        public int MaU { set; get; }
        public string HoTen { set; get; }
    }

    public class DoiMatKhau
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Tài Khoản")]
        public string TaiKhoan { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu")]
        public string MatKhau { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác Nhận Mật Khẩu")]
        [Compare("MatKhau", ErrorMessage = "Mật Khẩu và Xác Nhận Mật Khẩu không khớp")]
        public string ConfirmMatKhau { get; set; }

        public string Code { get; set; }
    }
}
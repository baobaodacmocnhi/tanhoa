using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
}
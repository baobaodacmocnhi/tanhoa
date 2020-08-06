using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DangBoWeb.DAL
{

    public class CUserSession
    {
        public static void setUser(CUserSessionChild session)
        {
            HttpContext.Current.Session["User"] = session;
        }

        public static CUserSessionChild getUser()
        {
            var session = HttpContext.Current.Session["User"];
            if (session == null)
                return null;
            else
                return (CUserSessionChild)session;
        }
    }

    [Serializable]
    public class CUserSessionChild
    {
        public int MaU { set; get; }
        public string HoTen { set; get; }
    }
}
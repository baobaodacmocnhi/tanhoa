using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace DHCD_KiemPhieu
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            log4net.Config.XmlConfigurator.Configure();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            Session["title"]="";
            Session["BAUCU"] = null;
            Session["year"] = DateTime.Now.Year.ToString();
            Session["chamcong"] = null;
            Session["col"] = 0;
            Session["arrTitle"] = new string[] {};
            Session["login"] = null;
            Session["ky"] = "";
            Session["nam"] = "";
            Session["tuky"] = "";
            Session["denky"] = "";
            Session["TongDS"] = "";
            Session["treport"] = "";
            Session["SQL"] = "";
            Session["LoaiDT"] = "";
            Session["col"] = 3;
            int count_visit = 0;

           
            // khóa website
            Application.Lock();

            // gán biến Application count_visit
        

            // Mở khóa website
            Application.UnLock();

        

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}

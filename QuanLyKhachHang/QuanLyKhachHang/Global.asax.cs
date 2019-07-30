using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace QuanLyKhachHang
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
            Session["year"] = DateTime.Now.Year.ToString();
            Session["col"] = 0;
            Session["login"] = null;
            Session["col"] = 3;
            Session["MADMA"] = "";
            Session["lat"] = "10.801433295748337" ;
            Session["lng"] = "106.65252816547981";
            Session["dsDongnuoc"] = null;
                      Session["imgfile"] = "";
            Session["phong"] = "";
            Session["page"] = null;

            Session["thuadat"] = "0";
            Session["tuyenduong"] = "0";
            Session["tuyenong"] = "0";
            Session["dongho"] = "0";
            Session["iddma"] = "0";
            Session["dma"] = "0";
            Session["poy"] = null;
            
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QuanLyKhachHang
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////for logging to file
            ////Session["login"] = "teste";
            //if( Request.QueryString["login"] != null)
            //    Session["login"] = Request.QueryString["login"].ToString();
            ////Response.Redirect(@"View\QuanLyVan.aspx");
           log4net.ILog logger = log4net.LogManager.GetLogger("File");

           Response.Redirect(@"mHome.aspx");
          
           

        }
    }
}
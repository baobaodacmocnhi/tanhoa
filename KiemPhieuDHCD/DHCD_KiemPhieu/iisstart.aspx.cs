using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DHCD_KiemPhieu
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //for logging to file
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           
           Response.Redirect(@"View\Login.aspx");
          
           

        }
    }
}
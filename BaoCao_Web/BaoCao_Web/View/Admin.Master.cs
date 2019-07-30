using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoDien.View
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ("".Equals(Session["USER"] + "")) {
                Response.Redirect(@"Login.aspx");
            }
        }
    }
}
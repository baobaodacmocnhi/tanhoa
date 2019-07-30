using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DHCD_KiemPhieu.View
{
    public partial class HomePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["spMoi"] = Class.C_Home.getSANPHAM_MOI() ;
            //Session["spBanChay"] = Class.C_Home.getSANPHAM_BANCHAY();
             
        }

        protected void btTimKiem_Load(object sender, EventArgs e)
        {
             
           
        }

        protected void btTimKiem_Click(object sender, EventArgs e)
        {
           // Response.Redirect(@"Home.aspx?search=" + txtSearch.Text);
        }
    }
}
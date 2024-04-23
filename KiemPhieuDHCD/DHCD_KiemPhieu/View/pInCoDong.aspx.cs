using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DHCD_KiemPhieu.View
{
    public partial class pInCoDong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            Session["TT"] = this.DropDownList1.SelectedValue.ToString();
            Response.Redirect("Print.aspx?page=IN");
        }
    }
}
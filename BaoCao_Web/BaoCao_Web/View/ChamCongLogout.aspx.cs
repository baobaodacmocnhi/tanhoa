﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoCao_Web.View
{
    public partial class ChamCongLogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["chamconglogin"] != null)
                Session["chamconglogin"] = null;
            Response.Redirect("Home.aspx");
        }
    }
}
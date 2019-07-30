using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyKhachHang.Class;

namespace QuanLyKhachHang
{
    public partial class addDB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;

            //if (Request.QueryString["db"] != null && !"".Equals(Request.QueryString["db"].ToString()))
            //{
            //    string lat = Request.QueryString["lat"];
            //    string lng = Request.QueryString["lng"];
            //    string db = Request.QueryString["db"];

            //    Class.LinQConnection.ExecuteCommand(" INSERT INTO DANHBO VALUES ('" + db + "','" + lat + "','" + lng + "')");

            //    Response.Redirect(@"addDB.aspx");
            //}
        }

         

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string lat = String.Format("{0}", Request.Form["Lat"]);
            string lng = String.Format("{0}", Request.Form["Long"]);
            string db = String.Format("{0}", Request.Form["db"]);

            string sql = " INSERT INTO DANHBO VALUES ('" + db + "','" + lat + "','" + lng + "')";
            if (C_KyThuat.ExecuteCommand_(sql) > 0)
                Label2.Text = "Thành Công";
            else
                Label2.Text = "Thất Bại";

        }
    }
}
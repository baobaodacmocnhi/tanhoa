using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoCao_Web.View
{
    public partial class KinhDoanh : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            MaintainScrollPositionOnPostBack = true;
            if ("U".Equals(Request.Params["type"] + "") || "u".Equals(Request.Params["type"] + ""))
            {

                this.Panel1.Controls.Clear();
                Control control = LoadControl("BaoKinhDoanh/UpdateKinhDoanh.ascx");
                this.Panel1.Controls.Add(control);
               // title.Text = "THỐNG KÊ ĐỒNG HỒ NƯỚC";
            }else  if ("V".Equals(Request.Params["type"] + ""))
            {

                this.Panel1.Controls.Clear();
                Control control = LoadControl("BaoKinhDoanh/ViewKinhDoanh.ascx");
                this.Panel1.Controls.Add(control);
               // title.Text = "SỐ LIỆU KINH DOANH NĂM " ;
            }else  if ("S".Equals(Request.Params["type"] + ""))
            {

                this.Panel1.Controls.Clear();
                Control control = LoadControl("BaoKinhDoanh/SoSanhSoLieuKD.ascx");
                this.Panel1.Controls.Add(control);
               // title.Text = "SỐ LIỆU KINH DOANH NĂM " ;
            }
            
        }
    }
}
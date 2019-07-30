using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoCao_Web.View
{
    public partial class BieuDoBaoCao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           MaintainScrollPositionOnPostBack = true;
           if ("BDDHN".Equals(Request.Params["type"] + ""))
           {
              
                this.Panel1.Controls.Clear();
                Control control = LoadControl("tabBieuDo/tb_BienDongDHN.ascx");
                this.Panel1.Controls.Add(control);
                title.Text = "BIỂU ĐỒ BIẾN ĐỘNG ĐỒNG HỒ NƯỚC";
            }
           else if ("BDSLUONG".Equals(Request.Params["type"] + ""))
            { 
                this.Panel1.Controls.Clear();
                Control control = LoadControl("tabBieuDo/tab_BieuDoSanLuong.ascx");
                this.Panel1.Controls.Add(control);
                title.Text = "BIỂU ĐỒ SẢN LƯỢNG";
            }
           else if ("BDDTHU".Equals(Request.Params["type"] + ""))
            {
                this.Panel1.Controls.Clear();
                Control control = LoadControl("tabBieuDo/tab_BieuDoDoanhThu.ascx");
                this.Panel1.Controls.Add(control);
                title.Text = "BIỂU ĐỒ DOANH THU ";
            }
            else if ("TTT".Equals(Request.Params["type"] + ""))
            {
                this.Panel1.Controls.Clear();
                Control control = LoadControl("tabDHN/tabLoaiKHTieuThuThap.ascx");
                this.Panel1.Controls.Add(control);
                title.Text = "THEO DÕI SẢN LƯỢNG THEO LOẠI KHÁCH HÀNG ";
            }
            else if ("CODE".Equals(Request.Params["type"] + ""))
            {
                this.Panel1.Controls.Clear();
                Control control = LoadControl("tabDHN/tabCodeDocSo.ascx");
                this.Panel1.Controls.Add(control);
                title.Text = "THEO DÕI CODE ĐỌC SỐ ";
            }  
        }
    }
}
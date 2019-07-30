using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoCao_Web.View
{
    public partial class QuanLyDHN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if("DTTDK".Equals(Request.Params["type"]+"")){
              
                this.Panel1.Controls.Clear();
                Control control = LoadControl("tabDHN/tabThongKeDHN.ascx");
                this.Panel1.Controls.Add(control);
                title.Text = "THỐNG KÊ ĐỒNG HỒ NƯỚC";
            }
            else if ("TDSL".Equals(Request.Params["type"] + ""))
            { 
                this.Panel1.Controls.Clear();
                Control control = LoadControl("tabDHN/tabTheoDoiSanLuong.ascx");
                this.Panel1.Controls.Add(control);
                title.Text = "THEO DÕI SẢN LƯỢNG";
            }
            else if ("TDTT".Equals(Request.Params["type"] + ""))
            {
                this.Panel1.Controls.Clear();
                Control control = LoadControl("tabDHN/tabTheoDoiTieuThuThap.ascx");
                this.Panel1.Controls.Add(control);
                title.Text = "THEO DÕI SỐ LƯỢNG KHÁCH HÀNG TIÊU THỤ THẤP ";
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
            else if ("CTCODE".Equals(Request.Params["type"] + ""))
            {
                this.Panel1.Controls.Clear();
                Control control = LoadControl("tabDHN/tab_ChiTietCode.ascx");
                this.Panel1.Controls.Add(control);
                title.Text = "PHÂN TÍCH CODE ĐỌC SỐ ";
            }
            else if ("CS".Equals(Request.Params["type"] + ""))
            {
                this.Panel1.Controls.Clear();
                Control control = LoadControl("tabDHN/tabBienDocCS.ascx");
                this.Panel1.Controls.Add(control);
                title.Text = "THEO DÕI KẾT QUẢ BIÊN ĐỌC CHỈ SỐ NƯỚC ";
            }

            else if ("SDS".Equals(Request.Params["type"] + ""))
            {
                this.Panel1.Controls.Clear();
                Control control = LoadControl("tabDHN/tabSoDocSo.ascx");
                this.Panel1.Controls.Add(control);
                title.Text = "SỔ ĐỌC SỐ  ";
            }
            else if ("TGD".Equals(Request.Params["type"] + ""))
            {
                this.Panel1.Controls.Clear();
                Control control = LoadControl("tabDHN/tab_TheoDoiGhiCS.ascx");
                this.Panel1.Controls.Add(control);
                title.Text = "THỜI GIAN BIÊN ĐỌC CHỈ SỐ  ";
            }
            else if ("SEARCH".Equals(Request.Params["type"] + ""))
            {
                this.Panel1.Controls.Clear();
                Control control = LoadControl("tabDHN/tabTraCuu.ascx");
                this.Panel1.Controls.Add(control);
                title.Text = "TRA CỨU THÔNG TIN KHÁCH HÀNG  ";
            }
            
            
            
        }
    }
}
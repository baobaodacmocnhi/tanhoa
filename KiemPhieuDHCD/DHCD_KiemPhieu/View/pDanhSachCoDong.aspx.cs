using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DHCD_KiemPhieu.View
{
    public partial class pDanhSachCoDong : System.Web.UI.Page
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
            Binddata();
        }
        private void Binddata()
        {
            //if ("".Equals(txtTextSearch.Text))
            //{
                GridView1.AllowPaging = true;
                GridView1.DataSource = Class.C_DhCoDong.getDSCoDong("");
                GridView1.DataBind();
            //}
            //else
            //{
                //GridView1.AllowPaging = true;
                //GridView1.DataSource = Class.C_News.getNews(txtTextSearch.Text);
                //GridView1.DataBind();
            //}
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Control control = LoadControl("A_NewAdd.ascx");
            //this.Panel1.Controls.Add(control);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Binddata();
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            Binddata();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditTin")
            {

            }
            else if (e.CommandName == "delteTin")
            {
                //string id = e.CommandArgument.ToString();
                //Class.C_News.DeleteNews(id);
                //Binddata();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Binddata();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Label id = (Label)GridView1.Rows[GridView1.EditIndex].FindControl("lbid");
            //Label mapc = (Label)GridView1.Rows[GridView1.EditIndex].FindControl("lbmapc");
            //TextBox thongtin = (TextBox)GridView1.Rows[GridView1.EditIndex].FindControl("txtthongtin");
            //TextBox link = (TextBox)GridView1.Rows[GridView1.EditIndex].FindControl("txtlink");
            //Label luotxem = (Label)GridView1.Rows[GridView1.EditIndex].FindControl("label4");

            //Hardware_Support softgrid = new Hardware_Support();
            //Hardware_Support_Info infogrid = new Hardware_Support_Info(int.Parse(id.Text), mapc.Text, thongtin.Text, link.Text, int.Parse(luotxem.Text));
            //bool infogrid1 = softgrid.UpdateHardwareSupport(infogrid);
            //if (infogrid1)
            //{
            //    MessageBox.show(this, "Sửa thành công !!!");
            //}
            //GridView1.EditIndex = -1;
            //Binddata();
        }
        int _cpGD = 0;
        int _cpPT = 0;
        int _cpTC = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label cpGD = (Label)e.Row.FindControl("Label9");
                    _cpGD += int.Parse(cpGD.Text.Replace(".", "").Replace(",", ""));

                    Label cpPT = (Label)e.Row.FindControl("Label10");
                    _cpPT += int.Parse(cpPT.Text.Replace(".", "").Replace(",", ""));

                    Label cpTC = (Label)e.Row.FindControl("Label11");
                    _cpTC += int.Parse(cpTC.Text.Replace(".", "").Replace(",", ""));
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label kn_DHN = (Label)e.Row.FindControl("lbCPGD");
                    kn_DHN.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _cpGD); ;

                    Label knSanLuong = (Label)e.Row.FindControl("lbCPPT");
                    knSanLuong.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _cpPT);

                    Label kt_DHN = (Label)e.Row.FindControl("lbCPTC");
                    kt_DHN.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _cpTC);
                }      
            }
            catch (Exception)
            {
                 
            }
               
        }

       
    }
}
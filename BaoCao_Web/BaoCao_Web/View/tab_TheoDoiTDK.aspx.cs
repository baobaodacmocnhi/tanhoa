using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BaoCao_Web.View
{
    public partial class tab_TheoDoiTDK : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ThongKeThay()
        {


        }
        protected void btXemBangKe_Click(object sender, EventArgs e)
        {
            this.dataTongBK.DataSource = Class.C_DHN.getThongKeThayDHN(this.tungay.Text.Trim(), this.denngay.Text.Trim());
            this.dataTongBK.DataBind();
            tongBangKe.Visible = false;
            danhsachtrongai.Visible = false;
        }

        protected void dataTongBK_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ("TONG".Equals(e.CommandName) || "SOLUONGTHAY".Equals(e.CommandName))
            {
                tongBangKe.Visible = true;
                danhsachtrongai.Visible = false;
                daxuly.Visible = false;
                TabContainer1.Visible = false;
                this.tongBangKe.DataSource = Class.C_DHN.getThongKeLoaiBaoThay(this.tungay.Text.Trim(), this.denngay.Text.Trim());
                this.tongBangKe.DataBind();
            }
            if ("TRONGAI".Equals(e.CommandName))
            {
                tongBangKe.Visible = false;
                danhsachtrongai.Visible = true;
                daxuly.Visible = true;
                TabContainer1.Visible = true;
                this.danhsachtrongai.DataSource = Class.C_DHN.getTroNgaiThay(this.tungay.Text.Trim(), this.denngay.Text.Trim());
                this.danhsachtrongai.DataBind();

                this.daxuly.DataSource = Class.C_DHN.getTroNgaiThay_daxuly(this.tungay.Text.Trim(), this.denngay.Text.Trim());
                this.daxuly.DataBind();

            }
        }

        protected void danhsachtrongai_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    // when mouse is over the row, save original color to new attribute, and change it to highlight yellow color
            //    e.Row.Attributes.Add("onmouseover",
            //  "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFF00'");

            //    // when mouse leaves the row, change the bg color to its original value   
            //    e.Row.Attributes.Add("onmouseout",
            //    "this.style.backgroundColor=this.originalstyle;");
            //}
        }

        protected void danhsachtrongai_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {

                // when mouse is over the row, save original color to new attribute, and change it to highlight color
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");

                // when mouse leaves the row, change the bg color to its original value  
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }
        }

        protected void daxuly_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {

                // when mouse is over the row, save original color to new attribute, and change it to highlight color
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");

                // when mouse leaves the row, change the bg color to its original value  
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }
        }
    }
}
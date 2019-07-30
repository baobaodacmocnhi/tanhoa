using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoCao_Web.View.tabDHN
{
    public partial class tabThongKeDHN : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DONGHONUOC.DataSource = Class.C_DHN.getCoDHN();
            //DONGHONUOC.DataBind();
            //if (IsPostBack)
            //    return;
            int ky = DateTime.Now.Month;
            int nam = DateTime.Now.Year;
            if (ky >= 13)
            {
                ky = 1;
                nam = nam + 1;
            }

            cbKy.SelectedIndex = (ky - 1);
            int tongSoDhn = 0;
            object thongKeNam = null;
            object thongKeHieu = null;
            Class.C_DHN.getThongKeDHN(ky, nam, ref tongSoDhn, ref thongKeNam, ref thongKeHieu);
            lbSoDHN.Text = String.Format("{0:0,0}", tongSoDhn);
            NAMGAN.DataSource = thongKeNam;
            NAMGAN.DataBind();

            thongkedhn.DataSource = thongKeHieu;
            thongkedhn.DataBind();

        }
        decimal totalPrice = 0M;
        protected void DONGHONUOC_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPrice = (Label)e.Row.FindControl("Label1");

                decimal price = Decimal.Parse(lblPrice.Text);

                totalPrice += price;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("lbSum");

                lblTotalPrice.Text = String.Format("{0:0,0}", totalPrice);

            }
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {

                // when mouse is over the row, save original color to new attribute, and change it to highlight color
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");

                // when mouse leaves the row, change the bg color to its original value  
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }
        }
        decimal totalPrice2 = 0M;
        protected void NAMGAN_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPrice = (Label)e.Row.FindControl("Label1");

                decimal price = Decimal.Parse(lblPrice.Text);

                totalPrice2 += price;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("lbSum");

                lblTotalPrice.Text = String.Format("{0:0,0}", totalPrice2);

            }
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");

            // when mouse leaves the row, change the bg color to its original value  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }

        double CO15 = 0; double CO20 = 0; double CO25 = 0; double CO40 = 0; double CO50 = 0; double CO80 = 0;
        double CO100 = 0; double CO150 = 0; double CO200 = 0; double NHOCO15 = 0; double NHOCO20 = 0;
        double NHOCO25 = 0; double NHOCO40 = 0; double NHOCO50 = 0; double NHOCO80 = 0; double NHOCO100 = 0;
        double NHOCO150 = 0; double NHOCO200 = 0; double LONCO15 = 0; double LONCO20 = 0; double LONCO25 = 0;
        double LONCO40 = 0; double LONCO50 = 0; double LONCO80 = 0; double LONCO100 = 0; double LONCO150 = 0; double LONCO200 = 0;

        protected void thongkedhn_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");
            // when mouse leaves the row, change the bg color to its original value  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Label1 = (Label)e.Row.FindControl("Label1");
                CO15 += Double.Parse(Label1.Text);
                Label Label2 = (Label)e.Row.FindControl("Label2");
                CO20 += Double.Parse(Label2.Text);
                Label Label3 = (Label)e.Row.FindControl("Label3");
                CO25 += Double.Parse(Label3.Text);
                Label Label4 = (Label)e.Row.FindControl("Label4");
                CO40 += Double.Parse(Label4.Text);
                Label Label5 = (Label)e.Row.FindControl("Label5");
                CO50 += Double.Parse(Label5.Text);
                Label Label6 = (Label)e.Row.FindControl("Label6");
                CO80 += Double.Parse(Label6.Text);
                Label Label7 = (Label)e.Row.FindControl("Label7");
                CO100 += Double.Parse(Label7.Text);
                Label Label8 = (Label)e.Row.FindControl("Label8");
                CO150 += Double.Parse(Label8.Text);
                Label Label9 = (Label)e.Row.FindControl("Label9");
                CO200 += Double.Parse(Label9.Text);
                Label Label10 = (Label)e.Row.FindControl("Label10");
                NHOCO15 += Double.Parse(Label10.Text);
                Label Label11 = (Label)e.Row.FindControl("Label11");
                NHOCO20 += Double.Parse(Label11.Text);
                Label Label12 = (Label)e.Row.FindControl("Label12");
                NHOCO25 += Double.Parse(Label12.Text);
                Label Label13 = (Label)e.Row.FindControl("Label13");
                NHOCO40 += Double.Parse(Label13.Text);
                Label Label14 = (Label)e.Row.FindControl("Label14");
                NHOCO50 += Double.Parse(Label14.Text);
                Label Label15 = (Label)e.Row.FindControl("Label15");
                NHOCO80 += Double.Parse(Label15.Text);
                Label Label16 = (Label)e.Row.FindControl("Label16");
                NHOCO100 += Double.Parse(Label16.Text);
                Label Label17 = (Label)e.Row.FindControl("Label17");
                NHOCO150 += Double.Parse(Label17.Text);
                Label Label18 = (Label)e.Row.FindControl("Label18");
                NHOCO200 += Double.Parse(Label18.Text);
                Label Label19 = (Label)e.Row.FindControl("Label19");
                LONCO15 += Double.Parse(Label19.Text);
                Label Label20 = (Label)e.Row.FindControl("Label20");
                LONCO20 += Double.Parse(Label20.Text);
                Label Label21 = (Label)e.Row.FindControl("Label21");
                LONCO25 += Double.Parse(Label21.Text);
                Label Label22 = (Label)e.Row.FindControl("Label22");
                LONCO40 += Double.Parse(Label22.Text);
                Label Label23 = (Label)e.Row.FindControl("Label23");
                LONCO50 += Double.Parse(Label23.Text);
                Label Label24 = (Label)e.Row.FindControl("Label24");
                LONCO80 += Double.Parse(Label24.Text);
                Label Label25 = (Label)e.Row.FindControl("Label25");
                LONCO100 += Double.Parse(Label25.Text);
                Label Label26 = (Label)e.Row.FindControl("Label26");
                LONCO150 += Double.Parse(Label26.Text);
                Label Label27 = (Label)e.Row.FindControl("Label27");
                LONCO200 += Double.Parse(Label27.Text);

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label Label1 = (Label)e.Row.FindControl("Label1");
                Label1.Text = String.Format("{0:0,0}", CO15);
                Label Label2 = (Label)e.Row.FindControl("Label289");
                Label2.Text = String.Format("{0:0,0}", CO20);
                Label Label3 = (Label)e.Row.FindControl("Label3");
                Label3.Text = String.Format("{0:0,0}", CO25);
                Label Label4 = (Label)e.Row.FindControl("Label4");
                Label4.Text = String.Format("{0:0,0}", CO40);
                Label Label5 = (Label)e.Row.FindControl("Label5");
                Label5.Text = String.Format("{0:0,0}", CO50);
                Label Label6 = (Label)e.Row.FindControl("Label6");
                Label6.Text = String.Format("{0:0,0}", CO80);
                Label Label7 = (Label)e.Row.FindControl("Label7");
                Label7.Text = String.Format("{0:0,0}", CO100);
                Label Label8 = (Label)e.Row.FindControl("Label8");
                Label8.Text = String.Format("{0:0,0}", CO150);
                Label Label9 = (Label)e.Row.FindControl("Label9");
                Label9.Text = String.Format("{0:0,0}", CO200);
                Label Label10 = (Label)e.Row.FindControl("Label10");
                Label10.Text = String.Format("{0:0,0}", NHOCO15);
                Label Label11 = (Label)e.Row.FindControl("Label11");
                Label11.Text = String.Format("{0:0,0}", NHOCO20);
                Label Label12 = (Label)e.Row.FindControl("Label12");
                Label12.Text = String.Format("{0:0,0}", NHOCO25);
                Label Label13 = (Label)e.Row.FindControl("Label13");
                Label13.Text = String.Format("{0:0,0}", NHOCO40);
                Label Label14 = (Label)e.Row.FindControl("Label14");
                Label14.Text = String.Format("{0:0,0}", NHOCO50);
                Label Label15 = (Label)e.Row.FindControl("Label15");
                Label15.Text = String.Format("{0:0,0}", NHOCO80);
                Label Label16 = (Label)e.Row.FindControl("Label16");
                Label16.Text = String.Format("{0:0,0}", NHOCO100);
                Label Label17 = (Label)e.Row.FindControl("Label17");
                Label17.Text = String.Format("{0:0,0}", NHOCO150);
                Label Label18 = (Label)e.Row.FindControl("Label18");
                Label18.Text = String.Format("{0:0,0}", NHOCO200);
                Label Label19 = (Label)e.Row.FindControl("Label19");
                Label19.Text = String.Format("{0:0,0}", LONCO15);
                Label Label20 = (Label)e.Row.FindControl("Label20");
                Label20.Text = String.Format("{0:0,0}", LONCO20);
                Label Label21 = (Label)e.Row.FindControl("Label21");
                Label21.Text = String.Format("{0:0,0}", LONCO25);
                Label Label22 = (Label)e.Row.FindControl("Label22");
                Label22.Text = String.Format("{0:0,0}", LONCO40);
                Label Label23 = (Label)e.Row.FindControl("Label23");
                Label23.Text = String.Format("{0:0,0}", LONCO50);
                Label Label24 = (Label)e.Row.FindControl("Label24");
                Label24.Text = String.Format("{0:0,0}", LONCO80);
                Label Label25 = (Label)e.Row.FindControl("Label25");
                Label25.Text = String.Format("{0:0,0}", LONCO100);
                Label Label26 = (Label)e.Row.FindControl("Label26");
                Label26.Text = String.Format("{0:0,0}", LONCO150);
                Label Label27 = (Label)e.Row.FindControl("Label27");
                Label27.Text = String.Format("{0:0,0}", LONCO200);
            }

        }

        protected void cbKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            totalPrice = 0M;
            totalPrice2 = 0M;
            CO15 = 0; CO20 = 0; CO25 = 0; CO40 = 0; CO50 = 0; CO80 = 0;
            CO100 = 0; CO150 = 0; CO200 = 0; NHOCO15 = 0; NHOCO20 = 0;
            NHOCO25 = 0; NHOCO40 = 0; NHOCO50 = 0; NHOCO80 = 0; NHOCO100 = 0;
            NHOCO150 = 0; NHOCO200 = 0; LONCO15 = 0; LONCO20 = 0; LONCO25 = 0;
            LONCO40 = 0; LONCO50 = 0; LONCO80 = 0; LONCO100 = 0; LONCO150 = 0; LONCO200 = 0;

            int ky = int.Parse(cbKy.Text);
            int nam = DateTime.Now.Year;

            int tongSoDhn = 0;
            object thongKeNam = null;
            object thongKeHieu = null;
            Class.C_DHN.getThongKeDHN(ky, nam, ref tongSoDhn, ref thongKeNam, ref thongKeHieu);
            lbSoDHN.Text = String.Format("{0:0,0}", tongSoDhn);
            NAMGAN.DataSource = thongKeNam;
            NAMGAN.DataBind();

            thongkedhn.DataSource = thongKeHieu;
            thongkedhn.DataBind();
        }
    }
}
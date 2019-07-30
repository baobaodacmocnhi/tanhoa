using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DHCD_KiemPhieu.View
{
    public partial class pDanhSachCoDongThamDu : System.Web.UI.Page
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
        int _cpGD = 0;
        int _cpPT = 0;
        int _cpTC = 0;
        private void Binddata()
        {

            GridView1.AllowPaging = true;
            GridView1.DataSource = Class.C_DhCoDong.getDSCoDongThamDu("");
            GridView1.DataBind();
            int sl = GridView1.Rows.Count;
            tc_sl.Text = sl + "";

            if (_cpTC > 0)
                tc_cp.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _cpTC);
            else
                tc_cp.Text = "0";

            double tl = _cpTC / Class.LinQConnection.ReturnResult("SELECT SUM(TONGCD) FROM DSCODONG");
            tc_tl.Text = String.Format("{0:0.##}", tl * 100).Replace(".",",") + "%";


            GridView2.AllowPaging = true;
            GridView2.DataSource = Class.C_DhCoDong.getDSCoDongChuaDen();
            GridView2.DataBind();


        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            Binddata();
        }
      

      
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void txtCoDong_TextChanged(object sender, EventArgs e)
        {
            string sql = " INSERT INTO DSCODONG_THAMDU (STT, STTCD, MACD, TENCD, CMND, NGAYCAP, NOICAP, DIACHI, CDGD, PHONGTOA, TONGCD, NGAYVAO)";
            sql += " SELECT STT, STTCD, MACD, TENCD, CMND, NGAYCAP, NOICAP, DIACHI, CDGD, PHONGTOA, TONGCD,GETDATE() AS NGAYVAO  FROM DSCODONG WHERE ( STT='" + this.txtCoDong.Text.Replace(" ", "") + "' )";
            Class.LinQConnection.ExecuteCommand(sql);
            Binddata();
            this.txtCoDong.Focus();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Class.LinQConnection.ExecuteCommand("DELETE FROM DSCODONG_THAMDU WHERE MACD='" + e.CommandArgument.ToString() + "'");
            Binddata();
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        int cdCD = 0;
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label cpGD = (Label)e.Row.FindControl("Label22");
                cdCD += int.Parse(cpGD.Text.Replace(".", "").Replace(",", ""));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label kt_DHN = (Label)e.Row.FindControl("lbCPTC0");
                kt_DHN.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", cdCD);
            }          
        }

       
    }
}
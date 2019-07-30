using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BaoCao_Web.Class;

namespace BaoCao_Web.View
{
    public partial class QuanLyDMA_ChartLL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            NamHienTai_DHN();
        }
        public void NamHienTai_DHN()
        {
            string value = Request.Params["value"].ToString();
            string title = "['GIỜ','m3/h']";

            string sl = "SELECT  LEFT(CAST(convert(time,[TimeStamp]) AS VARCHAR),5) AS GIO,Value FROM dbo.t_Data_Logger_" + value + " WHERE CONVERT(DATE,[TimeStamp])=CONVERT(DATE,GETDATE()) ORDER BY  [TimeStamp] DESC ";
            DataTable table = LinQConnectionGis.getDataTable(sl);

            for (int i = 0; i < table.Rows.Count; i++)
            {


                //title += "['" + f + "'" + ", " + table.Rows[i]["TIEUTHU"].ToString() + "],";
                title += ", ['" + table.Rows[i]["GIO"].ToString() + "'," + table.Rows[i]["Value"].ToString() + "]";
            }

            Session["sanluong"] = title;

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;

        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            string str =  Calendar1.SelectedDate.Day.ToString() + "/" + Calendar1.SelectedDate.Month + "/" + Calendar1.SelectedDate.Year.ToString();
            txtngay.Text = str;
            chuyengnay0.Visible = false;
            chuyengnay.Visible = true;
            Calendar1.Visible = false;
            chontungay();
        }

        protected void chuyenngay_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }
        public void chontungay()
        {
            string value = Request.Params["value"].ToString();
            string title = "['GIỜ','m3/h']";

            string sl = "SELECT  LEFT(CAST(convert(time,[TimeStamp]) AS VARCHAR),2) AS GIO,Value FROM dbo.t_Data_Logger_" + value + " WHERE CONVERT(DATE,[TimeStamp])=CONVERT(DATE,'" + Calendar1.SelectedDate + "')  AND  (DATEPART(MINUTE, [TimeStamp])=0) ORDER BY  [TimeStamp] DESC ";
            DataTable table = LinQConnectionGis.getDataTable(sl);

            for (int i = 0; i < table.Rows.Count; i++)
            {


                //title += "['" + f + "'" + ", " + table.Rows[i]["TIEUTHU"].ToString() + "],";
                title += ", ['" + table.Rows[i]["GIO"].ToString() + "'," + table.Rows[i]["Value"].ToString() + "]";
            }

            Session["sanluong"] = title;

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //Session["chamcong"] = null;
            Response.Redirect(@"\View\QuanLyDMA.aspx");
        }
    }
}
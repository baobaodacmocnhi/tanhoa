using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BaoCao_Web.View
{
    public partial class dmaApLuc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            pLoad();

        }

        public void pLoad()
        {
            int y = DateTime.Now.Year;
            Session["col"] = TextBox1.Text;
            Session["year"] = y;
            listDMA.DataSource = Class.LinQConnection.getDataTable("SELECT ID,MADMA,REPLACE(MADMA,'TH-','') as TEN FROM GNKDT_THONGTINDMA ORDER BY ID ASC");
            listDMA.DataTextField = "TEN";
            listDMA.DataValueField = "MADMA";
            listDMA.DataBind();

        }

        protected void listDMA_SelectedIndexChanged(object sender, EventArgs e)
        {
            string flag = "'123'";
            foreach (ListItem item in listDMA.Items)
            {
                if (item.Selected)
                {
                    flag += ",'" + item.Value + "'";
                }

            }
            string sql = "SELECT ID,MADMA FROM GNKDT_THONGTINDMA WHERE MADMA IN (" + flag + ") ORDER BY ID ASC";
            DataTable tb = Class.LinQConnection.getDataTable(sql);
            Session["chamcongAL"] = tb;

            //DataList1.DataSource = 
            //DataList1.DataBind();
        }

         protected void cAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cAll.Checked)
            {
                string flag = "'123'";
                foreach (ListItem item in listDMA.Items)
                {
                    flag += ",'" + item.Value + "'";
                    item.Selected = true;
                }
                string sql = "SELECT ID,MADMA FROM GNKDT_THONGTINDMA WHERE MADMA IN (" + flag + ") ORDER BY ID ASC";
                DataTable tb = Class.LinQConnection.getDataTable(sql);
                Session["chamcongAL"] = tb;
            }
            else
            {
                foreach (ListItem item in listDMA.Items)
                {
                    item.Selected = false;
                }

                Session["chamcongAL"] = null;
            }
        }

         protected void TextBox1_TextChanged(object sender, EventArgs e)
         {
             Session["col"] = TextBox1.Text;
         }

         protected void check0_CheckedChanged(object sender, EventArgs e)
         {
             //string sq = "SELECT *  FROM [t_Channel_Configurations]  where LEFT([Description],5)='" + dma.Replace("TH-", "") + "' AND ChannelName='Pressure'";
         }

         protected void checkLoi_CheckedChanged(object sender, EventArgs e)
         {

         }

    }
}
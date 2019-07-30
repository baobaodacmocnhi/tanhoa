using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BaoCao_Web.View.tabBieuDo
{
    public partial class tb_BienDongDHN : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string script = "";
            DataTable table = Class.C_Chart.getBienDongDHN(DateTime.Now.Year);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (i == table.Rows.Count - 1)
                {
                    script += "['" + table.Rows[i][1].ToString() + "'," + table.Rows[i][2].ToString() + "," + table.Rows[i][3].ToString() + ", " + table.Rows[i][4].ToString() + "]";
                }
                else
                {
                    script += "['" + table.Rows[i][1].ToString() + "'," + table.Rows[i][2].ToString() + "," + table.Rows[i][3].ToString() + ", " + table.Rows[i][4].ToString() + "],";
                }

            }
            Session["biendongdhn"] = script;
        }
    }
}
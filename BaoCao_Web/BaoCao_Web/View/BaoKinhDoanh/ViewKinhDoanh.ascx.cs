using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaoCao_Web.Class;

namespace BaoCao_Web.View.BaoKinhDoanh
{
    public partial class ViewKinhDoanh : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            int y = DateTime.Now.Year;
            for (int i = y - 2; i < y + 3; i++)
            {
                year.Items.Add(i+"");
            }
            year.SelectedIndex = 2;
           Session["BAOKD"] = Class.SoLieuKinhDoanh.getSoLieuByYear(y+"");
          
        }

        protected void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["BAOKD"] = Class.SoLieuKinhDoanh.getSoLieuByYear(this.year.Text+ "");
            
        }

        protected void btIn_Click(object sender, EventArgs e)
        {
            CrystalReportSource1.ReportDocument.SetDataSource(Class.SoLieuKinhDoanh.getSoLieuByYear(this.year.Text));
            CrystalReportSource1.ReportDocument.SetParameterValue("nam", this.year.Text);
            CrystalReportSource1.ReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "SO_LIEU_NAM " + this.year.Text);
        }

    }
}
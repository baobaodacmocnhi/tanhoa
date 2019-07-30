using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoCao_Web.View.tabDHN
{
    public partial class tabBienDocCS : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            nam.Text = DateTime.Now.Year.ToString();
            if (DateTime.Now.Month == 0)
            {
                this.ky.SelectedIndex = 0;
            }
            else
            {
                this.ky.SelectedIndex = DateTime.Now.Month - 1;
            }
        }

        protected void btXemBangKe_Click(object sender, EventArgs e)
        {
            string dotds = dot.Text;
            string kyds = ky.Text;
            string namds = nam.Text;
            int ky_ = int.Parse(kyds);
            int nam_ = int.Parse(namds);
            int dot_ = int.Parse(dotds);
            Class.C_QuanLyDHN.CAPNHAT_BIENDOCCHISO(nam_+"", ky_, int.Parse(dotds));
            GridView1.DataSource = Class.C_QuanLyDHN.getTheoDoiBienDocChiSo();
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // when mouse is over the row, save original color to new attribute, and change it to highlight color
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");

            // when mouse leaves the row, change the bg color to its original value  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
    }
}
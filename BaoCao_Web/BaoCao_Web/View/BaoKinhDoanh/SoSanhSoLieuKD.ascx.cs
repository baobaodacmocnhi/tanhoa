using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaoCao_Web.Class;

namespace BaoCao_Web.View.BaoKinhDoanh
{
    public partial class SoSanhSoLieuKD : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            int y = DateTime.Now.Year;
            for (int i = y - 2; i < y + 3; i++)
            {
                year.Items.Add(i+"");
                year0.Items.Add(i + "");
            }
            year.SelectedIndex = 2;
            year0.SelectedIndex = 1;
            Session["BAOKD"] = Class.SoLieuKinhDoanh.SoSanhSoLieu((y-1) + "",(y)+"");
          
        }

        protected void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["BAOKD"] = Class.SoLieuKinhDoanh.SoSanhSoLieu(this.year.Text + "", this.year0.Text + ""); 
        }

        protected void btIn_Click(object sender, EventArgs e)
        {
         
        }

    }
}
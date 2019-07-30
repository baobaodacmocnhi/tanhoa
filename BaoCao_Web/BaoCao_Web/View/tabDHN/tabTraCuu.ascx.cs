using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoCao_Web.View.tabDHN
{
    public partial class tabTraCuu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["sds"] = null;
        }
       
        protected void btXemBangKe_Click(object sender, EventArgs e)
        {
            string s = dot.SelectedValue + "";
            string search = txtLoai.Text;
            if ("0".Equals(s))
                Session["sds"] = Class.C_QuanLyDHN.getSoThan(search);
            else if ("1".Equals(s))
                Session["sds"] = Class.C_QuanLyDHN.getDiaChi(search);

            
            
        }
    }
}
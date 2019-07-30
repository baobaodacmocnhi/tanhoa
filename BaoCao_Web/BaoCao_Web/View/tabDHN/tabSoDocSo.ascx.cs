using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoCao_Web.View.tabDHN
{
    public partial class tabSoDocSo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DateTime.Now.Month == 0)
            {
                this.ky.SelectedIndex = 0;
            }
            else
            {
                this.ky.SelectedIndex = DateTime.Now.Month - 1;
            }

            Session["sds"] = null;
          
            nhanviends.DataSource = Class.C_QuanLyDHN.getNhanVienDocSo();
            nhanviends.DataValueField = "MAYDS";
            nhanviends.DataTextField = "NAME";
            nhanviends.DataBind();
        }
       
        protected void btXemBangKe_Click(object sender, EventArgs e)
        {
            string nvds = nhanviends.SelectedValue + "";
            string _dot = dot.Text;
            int _ky = int.Parse(ky.Text);
            Session["sds"] = Class.C_QuanLyDHN.getSoDocSo(nvds, _dot, _ky);
        }
    }
}
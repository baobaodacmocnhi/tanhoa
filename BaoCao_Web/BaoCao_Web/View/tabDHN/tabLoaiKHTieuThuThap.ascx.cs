using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoCao_Web.View.tabDHN
{
    public partial class tabLoaiKHTieuThuThap : System.Web.UI.UserControl
    {
        protected void Page_Load(object senderdouble, EventArgs e)
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
        protected void bcTheo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        log4net.ILog log = log4net.LogManager.GetLogger("File");
        protected void btXemBangKe_Click(object senderdouble, EventArgs e)
        {
        }

       
    }
}
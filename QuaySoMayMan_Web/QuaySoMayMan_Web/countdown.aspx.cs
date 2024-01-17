using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaySoMayMan_Web
{
    public partial class countdown : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbPhong.Text = cmbPhong.SelectedItem.Text;
            }
        }



        protected void cmbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbPhong.Text = cmbPhong.SelectedItem.Text;
            lbTime.Text = "00:00";

        }

        protected void btnStart_Click(object sender, EventArgs e)
        {

        }

        protected void btnEnd_Click(object sender, EventArgs e)
        {

        }


    }
}
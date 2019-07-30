using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaoCao_Web.DataBase;

namespace BaoCao_Web.View
{
    public partial class LoginChamCong1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (UserLogin(this.txtusername.Text, this.txtpassword.Text) == true)
            {
                Response.Redirect(Session["linked"].ToString());
            }
            else
                this.mess.Visible = true;
        }

        public bool UserLogin(string userName, string passWord)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from user in db.User_ChamCongs where user.Username == userName && user.Password == passWord select user;
            User_ChamCong userLogin = data.SingleOrDefault();
            if (userLogin != null)
            {
                Session["chamconglogin"] = userLogin.Username;
                Session["MaPhong"] = userLogin.MaPhong;
                Session["TCHC"] = userLogin.TCHC;
                return true;
            }
            return false;
        }
    }
}
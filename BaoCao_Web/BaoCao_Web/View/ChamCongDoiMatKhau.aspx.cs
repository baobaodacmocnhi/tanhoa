using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaoCao_Web.DataBase;

namespace BaoCao_Web.View
{
    public partial class ChamCongDoiMatKhau : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["chamconglogin"] == null)
            {
                Session["linked"] = "ChamCongDoiMatKhau.aspx?page=KD";
                Response.Redirect("ChamCongLogin.aspx");
            }
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword_Old.Text == "" || txtPassword_New.Text == "" || txtPassword_Conf.Text == "")
                    return;

                TanHoaDataContext db = new TanHoaDataContext();

                User_ChamCong userLogin = db.User_ChamCongs.SingleOrDefault(item => item.Username == Session["chamconglogin"].ToString());

                if (userLogin != null)
                {
                    if (txtPassword_Old.Text != userLogin.Password)
                    {
                        this.mess.Text = "Mật Khẩu cũ không đúng";
                        this.mess.Visible = true;
                    }
                    if (txtPassword_New.Text != txtPassword_Conf.Text)
                    {
                        this.mess.Text = "Mật Khẩu xác nhận không đúng";
                        this.mess.Visible = true;
                    }
                    userLogin.Password = txtPassword_New.Text;
                    db.SubmitChanges();
                    this.mess.Text = "Mật Khẩu đổi thành công";
                    this.mess.Visible = true;
                }
                else
                    this.mess.Visible = true;
            }
            catch (Exception)
            {
                this.mess.Visible = true;
            }
        }
    }
}
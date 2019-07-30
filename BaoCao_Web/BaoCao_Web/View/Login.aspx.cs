using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using BaoCao_Web.DataBase;

namespace BaoCao_Web.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private const string cryptoKey = "tanhoa";
        private static readonly byte[] IV = new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };

        public string Encrypt(string s)
        {
            if (s == null || s.Length == 0) return string.Empty;
            string result = string.Empty;
            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(s);
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));
                des.IV = IV;
                result = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch
            {
            }

            return result;
        }
        public string Decrypt(string s)
        {
            if (s == null || s.Length == 0) return string.Empty;
            string result = string.Empty;
            try
            {
                byte[] buffer = Convert.FromBase64String(s);
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));
                des.IV = IV;
                result = Encoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch
            {

            }

            return result;
        }
        public bool UserLogin(string userName, string passWord)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from user in db.SYS_USERs where user.USERNAME == userName && user.PASSWORD == passWord && user.ENABLED == true && user.MAPHONG=="TCHC" select user;
            SYS_USER userLogin = data.SingleOrDefault();
            if (userLogin != null)
            {
                SYS_USER userlogin = (SYS_USER)data.SingleOrDefault();
                Session["login"] = userlogin.USERNAME;
                return true;
            }
            return false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (UserLogin(this.txtusername.Text, Encrypt(this.txtpassword.Text)) == true)
                Response.Redirect("hc_CapNhatGiayXP.aspx?page=KD");
            else
                this.mess.Visible = true;
        }
    }
}
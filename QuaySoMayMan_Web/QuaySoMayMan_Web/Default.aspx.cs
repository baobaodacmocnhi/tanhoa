using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QuaySoMayMan_Web
{
    public partial class TrangChu : System.Web.UI.Page
    {
        CDAL _cDAL = new CDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSoTrungThuong.Focus();
        }

        protected void btnHienThi_Click(object sender, EventArgs e)
        {
            DataTable dt= _cDAL.get_KhachMoi(txtSoTrungThuong.Text.Trim());
            if (dt != null && dt.Rows.Count > 0)
            {
                lbSTT.Text = dt.Rows[0]["STT"].ToString();
                lbHoTen.Text = dt.Rows[0]["HoTen"].ToString();
                lbCongTy.Text = dt.Rows[0]["DonVi"].ToString();
                txtSoTrungThuong.Focus();
                txtSoTrungThuong.Text = "";
            }
            else
            {
                string strJSAlert = ("<script>alert('Số " + txtSoTrungThuong.Text.Trim() + " không tồn tại');</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "strJSAlert", strJSAlert);
                //Response.Write("<script>alert('Số " + txtSoTrungThuong.Text.Trim() + " không tồn tại');</script>");
            }
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            _cDAL.update_Quay(txtSoTrungThuong.Text.Trim());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using BaoCao_Web.DataBase;
using System.Drawing;

namespace BaoCao_Web.View
{
    public partial class hc_CapNhatThongTinNV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["chamconglogin"] == null)
            {
                Session["linked"] = "hc_CapNhatThongTinNV.aspx?page=KD";
                Response.Redirect("ChamCongLogin.aspx");
            }
            else
                if ((Boolean)Session["TCHC"] == false)
                {
                    Response.Write("<script>alert('Bạn không có quyền truy cập trang này');window.location.href='Home.aspx';</script>");
                }
                else
                {
                    MaintainScrollPositionOnPostBack = true;
                    if (IsPostBack)
                        return;
                    PageLoad();
                }
        }
        public void PageLoad()
        {

            cbPhongBanDoi.DataSource = Class.LinQConnection.getDataTable("SELECT * FROM TCHC_PHONGBAN  ORDER BY ID ASC ");
            cbPhongBanDoi.DataTextField = "TENPHONG";
            cbPhongBanDoi.DataValueField = "ID";
            cbPhongBanDoi.DataBind();

            cbPhongBanDoi0.DataSource = Class.LinQConnection.getDataTable("SELECT * FROM TCHC_PHONGBAN WHERE ID <> 1 ORDER BY ID ASC ");
            cbPhongBanDoi0.DataTextField = "TENPHONG";
            cbPhongBanDoi0.DataValueField = "ID";
            cbPhongBanDoi0.DataBind();

            string connectionString = ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFile"].ConnectionString;
           
            string sql = "  SELECT info.UserFullCode, info.UserFullName, dt.Dept  ";
            sql += "  FROM UserInfo info ";
            sql += "   LEFT JOIN Dept dt ";
            sql += "    ON  info.IDD=dt.IDD ";

            if (!"1".Equals(cbPhongBanDoi.SelectedValue))
            {
                sql += " WHERE info.IDD=" + cbPhongBanDoi.SelectedValue;
            }
           
            sql += " ORDER BY info.IDD ASC, info.UserFullCode ASC ";
            cpNhanVien.DataSource = Class.OledbConnection.getDataTable(connectionString, sql);
            cpNhanVien.DataTextField = "UserFullName";
            cpNhanVien.DataValueField = "UserFullCode";
            cpNhanVien.DataBind();

        }
        void setSTT()
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridView1.Rows[i].Cells[0].Text = (i + 1)+"";
            }
        }
        void load2()
        {   /* ---------------------- */
            string connectionString = ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFile"].ConnectionString;
           
            string sql = "  SELECT info.UserFullCode, info.UserFullName,info.UserLoaiNV,dt.Dept   ";
            sql += "  FROM UserInfo info ";
            sql += "   LEFT JOIN Dept dt ";
            sql += "    ON  info.IDD=dt.IDD ";
            if (!"1".Equals(cbPhongBanDoi.SelectedValue))
            {
                sql += " WHERE info.IDD=" + cbPhongBanDoi.SelectedValue;
            }
            
            sql += " ORDER BY info.UserFullCode ASC ";
            cpNhanVien.DataSource = Class.OledbConnection.getDataTable(connectionString, sql);
            cpNhanVien.DataTextField = "UserFullName";
            cpNhanVien.DataValueField = "UserFullCode";
            cpNhanVien.DataBind();
            GridView1.DataSource = Class.OledbConnection.getDataTable(connectionString, sql);
            GridView1.DataBind();

            setSTT();
        }
      
        protected void cbPhongBanDoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            load2();

        }

        int stt = 1;
        public string get_stt()
        {
            return Convert.ToString(stt++);
        }

        protected void btXemBangKe_Click(object sender, EventArgs e)
        {
            string loainv = "VP";
            if (ckNV0.Checked)
            {
                loainv = "VP";
            }
            if (ckCN0.Checked)
            {
                loainv = "CN";
            }

            string sql = " UPDATE UserInfo SET IDD ='" + cbPhongBanDoi0.SelectedValue + "', UserLoaiNV='" + loainv + "'  WHERE UserFullCode='" + cpNhanVien.SelectedValue + "'";
            string connectionString = ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFile"].ConnectionString;

            try
            {
                Class.OledbConnection.ExecuteCommand(connectionString, sql);
                this.lbThanhCong.Text = "Cập Nhật Thành Công.";
            }
            catch (Exception)
            {
                lbThanhCong.ForeColor = Color.Red;
                this.lbThanhCong.Text = "Cập Nhật Thất Bại.";

            }
            load2();
           
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string sql = " DELETE FROM UserInfo  WHERE UserFullCode='" + e.CommandArgument.ToString() + "'";
            string connectionString = ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFile"].ConnectionString;

            try
            {
                Class.OledbConnection.ExecuteCommand(connectionString, sql);
                this.lbThanhCong.Text = "Xóa Thành Công.";
            }
            catch (Exception)
            {
                lbThanhCong.ForeColor = Color.Red;
                this.lbThanhCong.Text = "Xóa Thất Bại.";

            }
            load2();
        }
        
       
    }
}
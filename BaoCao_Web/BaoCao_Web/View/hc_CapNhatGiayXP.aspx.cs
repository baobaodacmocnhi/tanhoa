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
    public partial class hc_CapNhatGiayXP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["chamconglogin"] == null)
            {
                Session["linked"] = "hc_CapNhatGiayXP.aspx?page=KD";
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
            cbNam.Items.Add((DateTime.Now.Year - 1)+"");
            cbNam.Items.Add((DateTime.Now.Year ) + "");
            cbNam.Items.Add((DateTime.Now.Year +1) + "");
            this.cbNam.SelectedIndex = 1;

            this.tungay.Text = Class.Format.NgayVNVN(DateTime.Now.Date) + "/" + DateTime.Now.Year.ToString();
            this.cbThang.SelectedIndex = DateTime.Now.Month-1;
            this.cbThang0.SelectedIndex = DateTime.Now.Month - 1;
            cbPhongBanDoi.DataSource = Class.LinQConnection.getDataTable("SELECT * FROM TCHC_PHONGBAN WHERE ID <> 1 ORDER BY ID ASC ");
            cbPhongBanDoi.DataTextField = "TENPHONG";
            cbPhongBanDoi.DataValueField = "ID";
            cbPhongBanDoi.DataBind();
            /* ---------------------- */
            string connectionString = ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFile"].ConnectionString;
            string sql = " SELECT info.UserFullCode, info.UserFullName, dt.Dept";
            sql += " FROM UserInfo info,Dept dt WHERE info.IDD=dt.IDD ";
            if (!"1".Equals(cbPhongBanDoi.SelectedValue))
            {
                sql += " AND info.IDD=" + cbPhongBanDoi.SelectedValue;
            }
            if (ckNV.Checked)
            {
                sql += " AND info.UserLoaiNV='VP' ";
            }
            if (ckCN.Checked)
            {
                sql += " AND info.UserLoaiNV='CN' ";
            }
            sql += " ORDER BY info.IDD ASC, info.UserFullCode ASC ";
            cpNhanVien.DataSource = Class.OledbConnection.getDataTable(connectionString, sql);
            cpNhanVien.DataTextField = "UserFullName";
            cpNhanVien.DataValueField = "UserFullCode";
            cpNhanVien.DataBind();

            dataLoad();
        }

        protected void btXemBangKe_Click(object sender, EventArgs e)
        {
            try
            {
                TCHC_GIAYXINVE xv = new TCHC_GIAYXINVE();
                xv.PHONGBAN = this.cbPhongBanDoi.SelectedItem.Text;
                xv.MANV = this.cpNhanVien.SelectedItem.Value;
                xv.TENNV = this.cpNhanVien.SelectedItem.Text;
                xv.LOAIGP = this.cpLoaiGiayPhep.SelectedValue;
                if (cpLoaiGiayPhep.SelectedIndex == 3)
                {
                    xv.BUOICT = cbGiayCongTac.Text;
                }
                if (cpLoaiGiayPhep.SelectedIndex == 4)
                {

                }
                else
                {
                    try
                    {
                        xv.TUNGAY = DateTime.ParseExact(tungay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        xv.DENNGAY = DateTime.ParseExact(denngay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        xv.PHUTVAO = int.Parse(this.txtPhutVao.Text);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        xv.PHUTRA = int.Parse(this.txtPhutRa.Text);
                    }
                    catch (Exception)
                    {
                    }
                }

                xv.NOIDUNGGV = this.txtNoiDungCT.Text;
                xv.CREATEDATE = DateTime.Now;
                xv.CREATEBY = Session["chamconglogin"].ToString();
                xv.THANG = this.cbThang.Text;
                Class.C_ToChucHanhChanh.Insert(xv);
                lbThanhCong.ForeColor = Color.Blue;
                this.lbThanhCong.Text = "Cập Nhật Thành Công.";
                this.txtPhutVao.Text = "";
                this.txtPhutVao.Text = "";
                this.txtNoiDungCT.Text = "";
                dataLoad();
            }
            catch (Exception)
            {
                lbThanhCong.ForeColor = Color.Red;
                this.lbThanhCong.Text = "Cập Nhật Thất Bại.";
            }
        }

        protected void cbPhongBanDoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* ---------------------- */
            string connectionString = ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFile"].ConnectionString;
            string sql = " SELECT info.UserFullCode, info.UserFullName, dt.Dept";
            sql += " FROM UserInfo info,Dept dt WHERE info.IDD=dt.IDD ";
            if (!"1".Equals(cbPhongBanDoi.SelectedValue))
            {
                sql += " AND info.IDD=" + cbPhongBanDoi.SelectedValue;
            }
            if (ckNV.Checked)
            {
                sql += " AND info.UserLoaiNV='VP' ";
            }
            if (ckCN.Checked)
            {
                sql += " AND info.UserLoaiNV='CN' ";
            }
            sql += " ORDER BY info.IDD ASC, info.UserFullCode ASC ";
            cpNhanVien.DataSource = Class.OledbConnection.getDataTable(connectionString, sql);
            cpNhanVien.DataTextField = "UserFullName";
            cpNhanVien.DataValueField = "UserFullCode";
            cpNhanVien.DataBind();
        }

        protected void cpLoaiGiayPhep_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Label3.Visible = false;
            this.cbGiayCongTac.Visible = false;
            this.Label1.Visible = true;
            this.tungay.Visible = true;
            this.Label2.Visible = true;
            this.denngay.Visible = true;
            this.txtPhutRa.Visible = true;
            this.txtPhutVao.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = false;
            txtNoiDungCT.Visible = false;
            if (cpLoaiGiayPhep.SelectedIndex == 0)
            {// trong ngày
                this.Label1.Text = "NGÀY";
                this.tungay.Text = Class.Format.NgayVNVN(DateTime.Now.Date) + "/" + DateTime.Now.Year.ToString();
                this.Label2.Visible = false;
                this.denngay.Visible = false;
                this.Label1.Visible = true;
                this.tungay.Visible = true;
            }
            else if (cpLoaiGiayPhep.SelectedIndex == 1)
            {//có thời hạn
                this.Label1.Text = "TỪ NGÀY";
                this.tungay.Text = "";
                this.Label2.Visible = true;
                this.denngay.Visible = true;
                this.Label1.Visible = true;
                this.tungay.Visible = true;
            }
            else if (cpLoaiGiayPhep.SelectedIndex == 2)
            {//không thời hạn
                this.Label1.Visible = false;
                this.tungay.Visible = false;
                this.Label2.Visible = false;
                this.denngay.Visible = false;
                this.tungay.Text = "";
                this.denngay.Text = "";
            }
            else if (cpLoaiGiayPhep.SelectedIndex == 3)
            {//công tác
                this.Label1.Visible = true;
                this.tungay.Visible = true;
                this.Label2.Visible = true;
                this.denngay.Visible = true;
                this.txtPhutRa.Visible = false;
                this.txtPhutVao.Visible = false;
                this.Label3.Visible = true;
                this.cbGiayCongTac.Visible = true;
                this.Label1.Visible = true;
                this.tungay.Visible = true;
                this.Label2.Visible = true;
                this.denngay.Visible = true;
                Label4.Visible = false;
                Label5.Visible = false;
                Label6.Visible = true;
                txtNoiDungCT.Visible = true;
            }
            else if (cpLoaiGiayPhep.SelectedIndex == 4)
            {// đi ngoài
                this.Label1.Visible = false;
                this.tungay.Visible = false;
                this.Label2.Visible = false;
                this.denngay.Visible = false;
                this.txtPhutRa.Visible = false;
                this.txtPhutVao.Visible = false;
                this.Label3.Visible = false;
                this.cbGiayCongTac.Visible = false;
                this.Label1.Visible = false;
                this.tungay.Visible = false;
                this.Label2.Visible = false;
                this.denngay.Visible = false;
                Label4.Visible = false;
                Label5.Visible = false;
                this.tungay.Text = "";
                this.denngay.Text = "";

            }
        }
        int stt = 1;
        public string get_stt()
        {
            return Convert.ToString(stt++);
        }
        public void dataLoad()
        {
            if (cbPhongBanDoi.SelectedIndex == 0)
            {
                GridView1.DataSource = Class.C_ToChucHanhChanh.getDuLieuXinVe(cbThang0.Text, cbNam.Text);
            }
            else
                GridView1.DataSource = Class.C_ToChucHanhChanh.getDuLieuXinVe(cbPhongBanDoi.SelectedItem.Text,cbThang0.Text, cbNam.Text);
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;   //trang hien tai
            //int trang_thu = e.NewPageIndex;      //the hien trang thu may
            //int so_dong = GridView1.PageSize;       //moi trang co bao nhieu dong
            //stt = trang_thu * so_dong + 1;
            dataLoad();
        }

       

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            Class.LinQConnection.ExecuteCommand("DELETE FROM TCHC_GIAYXINVE WHERE ID='" + e.CommandArgument.ToString() + "'");
            dataLoad();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            dataLoad();
        }
       
    }
}
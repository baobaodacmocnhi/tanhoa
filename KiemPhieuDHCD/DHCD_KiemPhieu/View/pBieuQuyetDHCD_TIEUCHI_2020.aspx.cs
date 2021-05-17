using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DHCD_KiemPhieu.View
{
    public partial class pKiemPhieuDHCD_2020 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["login"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            Binddata();
            this.txtCoDong.Text = "";
            this.tungay.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
        }
        private void Binddata()
        {
            LoadDongY();
            LoadKhongDongY();
            LoadKhongYkien();
        }




        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Binddata();
            //if (DropDownList1.SelectedIndex == 1)
            //    lbTitle.Text = "Thông qua Báo cáo hoạt động của Hội đồng quản trị năm 2015 và kế hoạch hoạt động năm 2016";
            //else if (DropDownList1.SelectedIndex == 2)
            //    lbTitle.Text = "Thông qua Báo cáo hoạt động của Ban kiểm soát Công ty CP Cấp nước Tân Hòa năm 2015";
            //else if (DropDownList1.SelectedIndex == 3)
            //    lbTitle.Text = "Thông qua Báo cáo tổng kết hoạt động sản xuất kinh doanh năm 2015  và Phương hướng hoạt động sản xuất kinh doanh năm 2016";
            //else if (DropDownList1.SelectedIndex == 4)
            //    lbTitle.Text = "Thông qua Báo cáo tài chính tóm tắt năm 2015 (đã kiểm toán)";
            //else if (DropDownList1.SelectedIndex == 5)
            //    lbTitle.Text = "Thông qua việc sửa đổi, bổ sung Điều lệ Công Ty Cổ Phần Cấp nước Tân Hòa";
            //else if (DropDownList1.SelectedIndex == 6)
            //    lbTitle.Text = "Thông qua Phương án phân phối lợi nhuận 2015";
            //else if (DropDownList1.SelectedIndex == 7)
            //    lbTitle.Text = "Thông qua Kế hoạch tài chính năm 2016 ";
            //else if (DropDownList1.SelectedIndex == 8)
            //    lbTitle.Text = "Thông qua Ủy quyền cho HĐQT quyết định lựa chọn đơn vị kiểm toán Báo cáo tài chính 2016 ";
            //else if (DropDownList1.SelectedIndex == 9)
            //    lbTitle.Text = "Thông qua Quỹ tiền lương kế hoạch đối với Chủ Tịch Hội đồng quản trị, Giám đốc, Phó Giám đốc, Kế toán trưởng và chế độ thù lao của Hội đồng quản trị, Ban kiểm soát, Thư ký Công ty năm 2016 ";
            //else if (DropDownList1.SelectedIndex == 10)
            //    lbTitle.Text = "Thông qua Miễn nhiệm Thành viên Ban viên Ban Kiểm soát ";
            try
            {
                lbTitle.Text = Class.LinQConnection.getDataTable("SELECT * FROM TIEUCHIBIEUQUYET WHERE STT='" + DropDownList1.SelectedIndex + "'").Rows[0][1].ToString();
            }
            catch (Exception)
            {

                lbTitle.Text = "";
            }
           
        }

        public void LoadDongY()
        {
            string sql = " SELECT STT,STTCD, MACD, TENCD, CMND, NGAYCAP, NOICAP, DIACHI, CDGD, PHONGTOA, TONGCD ";
            sql += " FROM DSCODONG_THAMDU ";
            sql += " WHERE MACD NOT IN (SELECT MACD FROM KIEMPHIEU_BIEUQUYET WHERE LANBQ= " + DropDownList1.SelectedValue.ToString() + " AND CONVERT(VARCHAR(50),NGAYBQ,103)='" + this.tungay.Text + "' ) ORDER BY STT ASC ";

            DataTable dt = Class.LinQConnection.getDataTable(sql);
            G_DY.DataSource = dt;
            G_DY.DataBind();


            dy_sl.Text = "0";
            dy_cp.Text = "0";
            dy_tl.Text = "0";

            try
            {
                double sum = Convert.ToDouble(dt.Compute("SUM(TONGCD)", string.Empty));
                dy_sl.Text = String.Format("{0:0,0}", dt.Rows.Count);
                //dy_cp.Text = String.Format("{0:0,0}", sum);
                dy_cp.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", sum);

                double tl = sum / Class.LinQConnection.ReturnResult("SELECT SUM(TONGCD) FROM DSCODONG_THAMDU");
                dy_tl.Text = String.Format("{0:0.##}", tl * 100).Replace(".", ",") + "%";
            }
            catch (Exception)
            {
               
            }
            

        }
        public void LoadKhongDongY()
        {

            string sql = " SELECT kp.ID, STT,cd.STTCD, cd.MACD, TENCD, CMND, NGAYCAP, NOICAP, DIACHI, CDGD, PHONGTOA, cd.TONGCD";
            sql += " FROM DSCODONG_THAMDU cd, KIEMPHIEU_BIEUQUYET kp ";
            sql += " WHERE kp.LOAIBQ=0 AND cd.MACD=kp.MACD AND LANBQ= " + DropDownList1.SelectedValue.ToString() + " AND CONVERT(VARCHAR(50),NGAYBQ,103)='" + this.tungay.Text + "'  ORDER BY CREATEDATE DESC ";

            DataTable dt = Class.LinQConnection.getDataTable(sql);
            G_KDY.DataSource = dt;
            G_KDY.DataBind();

            kdy_sl.Text = "0";
            kdy_cp.Text = "0";
            kdy_tl.Text = "0";

            try
            {

                double sum = Convert.ToDouble(dt.Compute("SUM(TONGCD)", string.Empty));
                kdy_sl.Text = String.Format("{0:0,0}", dt.Rows.Count);
                //kdy_cp.Text = String.Format("{0:0,0}", sum);
                kdy_cp.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",sum);

                double tl = sum / Class.LinQConnection.ReturnResult("SELECT SUM(TONGCD) FROM DSCODONG_THAMDU");
                kdy_tl.Text = String.Format("{0:0.##}", tl * 100).Replace(".",",") + "%";
            }
            catch (Exception)
            {


            }
        }

        public void LoadKhongYkien()
        {

            string sql = " SELECT kp.ID, STT,cd.STTCD, cd.MACD, TENCD, CMND, NGAYCAP, NOICAP, DIACHI, CDGD, PHONGTOA, cd.TONGCD";
            sql += " FROM DSCODONG_THAMDU cd, KIEMPHIEU_BIEUQUYET kp ";
            sql += " WHERE kp.LOAIBQ=1 AND cd.MACD=kp.MACD AND LANBQ= " + DropDownList1.SelectedValue.ToString() + " AND CONVERT(VARCHAR(50),NGAYBQ,103)='" + this.tungay.Text + "'  ORDER BY CREATEDATE DESC ";

            DataTable dt = Class.LinQConnection.getDataTable(sql);
            G_KYK.DataSource = dt;
            G_KYK.DataBind();

            ky_sl0.Text = "0";
            ky_cp0.Text = "0";
            ky_tl0.Text = "0";

            try
            {

                double sum = Convert.ToDouble(dt.Compute("SUM(TONGCD)", string.Empty));
                ky_sl0.Text = String.Format("{0:0,0}", dt.Rows.Count);
                //ky_cp0.Text = String.Format("{0:0,0}", sum);
                ky_cp0.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", sum);

                double tl = sum / Class.LinQConnection.ReturnResult("SELECT SUM(TONGCD) FROM DSCODONG_THAMDU");
                ky_tl0.Text = String.Format("{0:0.##}", tl * 100).Replace(".", ",") + "%";
            }
            catch (Exception)
            {


            }
        }

        protected void btCapNhat2_Click(object sender, EventArgs e)
        {
        }

        protected void G_KDY_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Class.LinQConnection.ExecuteCommand("DELETE FROM KIEMPHIEU_BIEUQUYET WHERE ID='" + e.CommandArgument.ToString() + "'");
            Binddata();
        }

        protected void txtCoDong_TextChanged(object sender, EventArgs e)
        {

            string sql = " INSERT INTO KIEMPHIEU_BIEUQUYET(LANBQ,NGAYBQ,LOAIBQ,STTCD,MACD,TONGCD,CREATEBY,CREATEDATE) ";
            sql += " (SELECT " + DropDownList1.SelectedValue.ToString() + " AS LANBQ,'" + DateTime.ParseExact(tungay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + "' AS NGAYBQ,0 AS LOAIBQ,STTCD,MACD,TONGCD,'" + Session["login"] + "' AS CREATEBY, GETDATE() AS CREATEDATE ";
            sql += " FROM DSCODONG_THAMDU WHERE STTCD=REPLACE('" + this.txtCoDong.Text.Replace(" ", "") + "','THW','') OR MACD='" + this.txtCoDong.Text.Replace(" ", "") + "' )";
            Class.LinQConnection.ExecuteCommand(sql);
            Binddata();
            this.txtCoDong.Focus();
        }

        protected void txtCoDong0_TextChanged(object sender, EventArgs e)
        {
            string sql = " INSERT INTO KIEMPHIEU_BIEUQUYET(LANBQ,NGAYBQ,LOAIBQ,STTCD,MACD,TONGCD,CREATEBY,CREATEDATE) ";
            sql += " (SELECT " + DropDownList1.SelectedValue.ToString() + " AS LANBQ,'" + DateTime.ParseExact(tungay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + "' AS NGAYBQ,1 AS LOAIBQ,STTCD,MACD,TONGCD,'" + Session["login"] + "' AS CREATEBY, GETDATE() AS CREATEDATE ";
            sql += " FROM DSCODONG_THAMDU WHERE STTCD=REPLACE('" + this.txtCoDong0.Text.Replace(" ", "") + "','THW','') OR MACD='" + this.txtCoDong0.Text.Replace(" ", "") + "' )";
            Class.LinQConnection.ExecuteCommand(sql);
            Binddata();
            this.txtCoDong0.Focus();
        }

        protected void G_KYK_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Class.LinQConnection.ExecuteCommand("DELETE FROM KIEMPHIEU_BIEUQUYET WHERE ID='" + e.CommandArgument.ToString() + "'");
            Binddata();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BaoCao_Web.View.tabSanLuong
{
    public partial class tabPhanTichThay : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            nam.Text = DateTime.Now.Year.ToString();
            loadhieu();
            //if (DateTime.Now.Month == 0)
            //{
            //    this.ky.SelectedIndex = 0;
            //}
            //else
            //{
            //    this.ky.SelectedIndex = DateTime.Now.Month - 1;
            //}
        }
        public void loadhieu()
        {
            DataTable table = new DataTable("TONGKETKINHPHI");
            table.Columns.Add("HIEUDH", typeof(string));
            table.Columns.Add("TENDONGHO", typeof(string));
            
            DataRow myDataRow = table.NewRow();
            myDataRow["HIEUDH"] = "";
            myDataRow["TENDONGHO"] = "";

            table.Rows.Add(myDataRow);


            string sql = "SELECT * FROM TB_HIEUDONGHO ";
            DataTable tb2 = Class.LinQConnection.getDataTable(sql);
            table.Merge(tb2);

            cbHieu.DataSource = table;
            cbHieu.DataValueField = "HIEUDH";
            cbHieu.DataTextField = "HIEUDH";
            cbHieu.DataBind();
        
        }

        protected void btXemBangKe_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"tabSanLuong\PhanTichThayDHN.aspx?m=" + ky.SelectedValue + "&y=" + nam.Text + "&code=" + code.SelectedValue + "&hieu=" + cbHieu.SelectedItem.Text);
        }

        
    }
}
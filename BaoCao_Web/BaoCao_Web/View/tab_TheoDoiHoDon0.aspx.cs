using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BaoCao_Web.View
{
    public partial class tab_TheoDoiHoDon0 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            this.tungay.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            this.denngay.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            ThongKeHoadon();
        }

        public void ThongKeHoadon()
        {

            this.dataTongBK.DataSource = Class.C_DHN.getTheoDoiHoaDon0(this.tungay.Text.Trim(), this.denngay.Text.Trim());
            this.dataTongBK.DataBind();

            try
            {
                getChart();

            }
            catch (Exception)
            {
                
            }

        }
        
        protected void btXemBangKe_Click(object sender, EventArgs e)
        {
            ThongKeHoadon();
        }

        string FullKy(int n) {
            if (n < 10)
                return "0" + n;
            return n+"";
        }

        //public static string DoiDonViMet(double number)
        //{
        //    //string line = String.Format('{0:0.0}', number);
        //    //string[] words = Regex.Split(line, '\\.');
        //    //if (words.Length == 2)
        //    //{
        //    //    return words[0] + 'm' + words[1];
        //    //}
        //    //return words[0] + 'm';
        //    string line = String.Format("{0:0.0}", number);
        //    string[] words = Regex.Split(line, "\\.");
        //    if (words.Length == 2)
        //    {
        //        if (words[1].Equals('0'))
        //            return words[0];
        //        else
        //            return words[0] + ',' + words[1];
        //    }
        //    return words[0];
        //}
        static log4net.ILog log = log4net.LogManager.GetLogger("File");
        public DataTable getChart() {
          DataTable tableTre = new DataTable();
           
            string _tungay = this.tungay.Text.Trim();
            int _tuky = int.Parse(_tungay.Substring(3, 2));
            int _tunam = int.Parse(_tungay.Substring(6, 4));
       
            string _denngay = this.denngay.Text.Trim();
            int _denky = int.Parse(_denngay.Substring(3, 2));
            int _dennam = int.Parse(_denngay.Substring(6, 4));
            
            DateTime tNgay = DateTime.ParseExact(_tungay, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime dNgay = DateTime.ParseExact(_denngay, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
      
            int tongThang=(dNgay.Month - tNgay.Month) + 12 * (dNgay.Year - tNgay.Year)+1;           
            string[] arrTitle = new string[tongThang];

            for (int i = 0; i < tongThang; i++)
			{
                string tableName = _tunam + FullKy(_tuky);
                tableTre.Columns.Add(tableName, typeof(String));
                arrTitle[i] = tableName;
                _tuky = _tuky + 1;
                if (_tuky > 12) {
                    _tuky = 1;
                    _tunam = _tunam + 1;
                }
			}

            string title = "['KỲ', 'Số Lượng Hóa Đơn =0']";
            

            if (tableTre != null)
            {
                DataRow row = tableTre.NewRow();
                foreach (string s in arrTitle)
                {
                    string sql = "SELECT COUNT(*) FROM DocSoTH.dbo.HoaDon WHERE TieuThu=0 AND HoaDonID LIKE '" + s + "%'";
                   // log.Error("LinQConnection ExecuteCommand : " + sql);
                    int soluong = Class.LinQConnection.ReturnResult(sql);
                    row[s] = soluong;
                    if (soluong != 0) {
                        title += ",['" + s.Replace("_", "/") + "', " + soluong + "]";
                    }
                    

                }
                tableTre.Rows.Add(row);
            }
          title =  "[" + title + "]";
          Session["hoadon"] = title;
            return tableTre;
        }
        
        
        protected void dataTongBK_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if ("TONG".Equals(e.CommandName) || "SOLUONGTHAY".Equals(e.CommandName))
            //{
            //    tongBangKe.Visible = true;
            //    danhsachtrongai.Visible = false;
            //    daxuly.Visible = false;
            //    TabContainer1.Visible = false;
            //    this.tongBangKe.DataSource = Class.C_DHN.getThongKeLoaiBaoThay(this.tungay.Text.Trim(), this.denngay.Text.Trim());
            //    this.tongBangKe.DataBind();
            //}
            //if ("TRONGAI".Equals(e.CommandName))
            //{
            //    tongBangKe.Visible = false;
            //    danhsachtrongai.Visible = true;
            //    daxuly.Visible = true;
            //    TabContainer1.Visible = true;
            //    this.danhsachtrongai.DataSource = Class.C_DHN.getTroNgaiThay(this.tungay.Text.Trim(), this.denngay.Text.Trim());
            //    this.danhsachtrongai.DataBind();

            //    this.daxuly.DataSource = Class.C_DHN.getTroNgaiThay_daxuly(this.tungay.Text.Trim(), this.denngay.Text.Trim());
            //    this.daxuly.DataBind();
               
            //}
        }

        protected void danhsachtrongai_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    // when mouse is over the row, save original color to new attribute, and change it to highlight yellow color
            //    e.Row.Attributes.Add("onmouseover",
            //  "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFF00'");

            //    // when mouse leaves the row, change the bg color to its original value   
            //    e.Row.Attributes.Add("onmouseout",
            //    "this.style.backgroundColor=this.originalstyle;");
            //}
        }

        protected void danhsachtrongai_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {

                // when mouse is over the row, save original color to new attribute, and change it to highlight color
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");

                // when mouse leaves the row, change the bg color to its original value  
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }
        }

        protected void daxuly_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {

                // when mouse is over the row, save original color to new attribute, and change it to highlight color
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");

                // when mouse leaves the row, change the bg color to its original value  
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }
        }
    }
}
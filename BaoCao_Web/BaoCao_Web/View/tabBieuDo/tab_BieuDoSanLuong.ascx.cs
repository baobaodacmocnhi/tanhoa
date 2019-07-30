using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace BaoCao_Web.View.tabBieuDo
{
    public partial class tab_BieuDoSanLuong : System.Web.UI.UserControl
    {
        public void NamHienTai_DHN(string nam)
        {
            string title = "['THÁNG'";
            string thang01 = "['01'";
            string thang02 = "['02'";
            string thang03 = "['03'";
            string thang04 = "['04'";
            string thang05 = "['05'";
            string thang06 = "['06'";
            string thang07 = "['07'";
            string thang08 = "['08'";
            string thang09 = "['09'";
            string thang10 = "['10'";
            string thang11 = "['11'";
            string thang12 = "['12'";


            DataTable table = Class.C_Chart.getBienDongSanLuong("'" + nam + "'");
            DataTable tableTB = Class.C_Chart.getSanLuongTrungBinh("'" + nam + "'");
            GridView1.DataSource = table;
            GridView1.DataBind();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                title += ", '" + table.Rows[i]["NAM"].ToString() + "'";
                thang01 += ", " + table.Rows[i]["THANG01"].ToString() + "";
                thang02 += ", " + table.Rows[i]["THANG02"].ToString() + "";
                thang03 += ", " + table.Rows[i]["THANG03"].ToString() + "";
                thang04 += ", " + table.Rows[i]["THANG04"].ToString() + "";
                thang05 += ", " + table.Rows[i]["THANG05"].ToString() + "";
                thang06 += ", " + table.Rows[i]["THANG06"].ToString() + "";
                thang07 += ", " + table.Rows[i]["THANG07"].ToString() + "";
                thang08 += ", " + table.Rows[i]["THANG08"].ToString() + "";
                thang09 += ", " + table.Rows[i]["THANG09"].ToString() + "";
                thang10 += ", " + table.Rows[i]["THANG10"].ToString() + "";
                thang11 += ", " + table.Rows[i]["THANG11"].ToString() + "";
                thang12 += ", " + table.Rows[i]["THANG12"].ToString() + "";
            }
            string binhquan = "";
            for (int i = 0; i < tableTB.Rows.Count; i++)
            {
                title += ", 'Dự Đoán'";
                thang01 += ", " + tableTB.Rows[i]["THANG01"].ToString() + "";
                thang02 += ", " + tableTB.Rows[i]["THANG02"].ToString() + "";
                thang03 += ", " + tableTB.Rows[i]["THANG03"].ToString() + "";
                thang04 += ", " + tableTB.Rows[i]["THANG04"].ToString() + "";
                thang05 += ", " + tableTB.Rows[i]["THANG05"].ToString() + "";
                thang06 += ", " + tableTB.Rows[i]["THANG06"].ToString() + "";
                thang07 += ", " + tableTB.Rows[i]["THANG07"].ToString() + "";
                thang08 += ", " + tableTB.Rows[i]["THANG08"].ToString() + "";
                thang09 += ", " + tableTB.Rows[i]["THANG09"].ToString() + "";
                thang10 += ", " + tableTB.Rows[i]["THANG10"].ToString() + "";
                thang11 += ", " + tableTB.Rows[i]["THANG11"].ToString() + "";
                thang12 += ", " + tableTB.Rows[i]["THANG12"].ToString() + "";
                binhquan = tableTB.Rows[i]["CHITIEU"].ToString();
            }
            title += ", 'Chỉ Tiêu '";
            thang01 += ", " + binhquan + "";
            thang02 += ", " + binhquan + "";
            thang03 += ", " + binhquan + "";
            thang04 += ", " + binhquan + "";
            thang05 += ", " + binhquan + "";
            thang06 += ", " + binhquan + "";
            thang07 += ", " + binhquan + "";
            thang08 += ", " + binhquan + "";
            thang09 += ", " + binhquan + "";
            thang10 += ", " + binhquan + "";
            thang11 += ", " + binhquan + "";
            thang12 += ", " + binhquan + ""; 


            string script = title + "]," + thang01 + "]," + thang02 + "]," + thang03 + "]," + thang04 + "]," + thang05 + "]," + thang06 + "]," + thang07 + "]," + thang08 + "],";
            script += thang09 + "]," + thang10 + "]," + thang11 + "]," + thang12 + "]";
            Session["sanluong"] = script;
        
        }

        public void TungNam(string nam)
        {
            string title = "['THÁNG'";
            string thang01 = "['01'";
            string thang02 = "['02'";
            string thang03 = "['03'";
            string thang04 = "['04'";
            string thang05 = "['05'";
            string thang06 = "['06'";
            string thang07 = "['07'";
            string thang08 = "['08'";
            string thang09 = "['09'";
            string thang10 = "['10'";
            string thang11 = "['11'";
            string thang12 = "['12'";


            DataTable table = Class.C_Chart.getBienDongSanLuong("'" + nam + "'");
            DataTable tableTB = Class.C_Chart.getSanLuongTrungBinh("'" + nam + "'");
            GridView1.DataSource = table;
            GridView1.DataBind();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                title += ", '" + table.Rows[i]["NAM"].ToString() + "'";
                thang01 += ", " + table.Rows[i]["THANG01"].ToString() + "";
                thang02 += ", " + table.Rows[i]["THANG02"].ToString() + "";
                thang03 += ", " + table.Rows[i]["THANG03"].ToString() + "";
                thang04 += ", " + table.Rows[i]["THANG04"].ToString() + "";
                thang05 += ", " + table.Rows[i]["THANG05"].ToString() + "";
                thang06 += ", " + table.Rows[i]["THANG06"].ToString() + "";
                thang07 += ", " + table.Rows[i]["THANG07"].ToString() + "";
                thang08 += ", " + table.Rows[i]["THANG08"].ToString() + "";
                thang09 += ", " + table.Rows[i]["THANG09"].ToString() + "";
                thang10 += ", " + table.Rows[i]["THANG10"].ToString() + "";
                thang11 += ", " + table.Rows[i]["THANG11"].ToString() + "";
                thang12 += ", " + table.Rows[i]["THANG12"].ToString() + "";
            }
            string binhquan = "";
            for (int i = 0; i < tableTB.Rows.Count; i++)
            {
                //title += ", 'Dự Đoán'";
                //thang01 += ", " + tableTB.Rows[i]["THANG01"].ToString() + "";
                //thang02 += ", " + tableTB.Rows[i]["THANG02"].ToString() + "";
                //thang03 += ", " + tableTB.Rows[i]["THANG03"].ToString() + "";
                //thang04 += ", " + tableTB.Rows[i]["THANG04"].ToString() + "";
                //thang05 += ", " + tableTB.Rows[i]["THANG05"].ToString() + "";
                //thang06 += ", " + tableTB.Rows[i]["THANG06"].ToString() + "";
                //thang07 += ", " + tableTB.Rows[i]["THANG07"].ToString() + "";
                //thang08 += ", " + tableTB.Rows[i]["THANG08"].ToString() + "";
                //thang09 += ", " + tableTB.Rows[i]["THANG09"].ToString() + "";
                //thang10 += ", " + tableTB.Rows[i]["THANG10"].ToString() + "";
                //thang11 += ", " + tableTB.Rows[i]["THANG11"].ToString() + "";
                //thang12 += ", " + tableTB.Rows[i]["THANG12"].ToString() + "";
                binhquan = tableTB.Rows[i]["CHITIEU"].ToString();
            }
            title += ", 'Chỉ Tiêu '";
            thang01 += ", " + binhquan + "";
            thang02 += ", " + binhquan + "";
            thang03 += ", " + binhquan + "";
            thang04 += ", " + binhquan + "";
            thang05 += ", " + binhquan + "";
            thang06 += ", " + binhquan + "";
            thang07 += ", " + binhquan + "";
            thang08 += ", " + binhquan + "";
            thang09 += ", " + binhquan + "";
            thang10 += ", " + binhquan + "";
            thang11 += ", " + binhquan + "";
            thang12 += ", " + binhquan + "";


            string script = title + "]," + thang01 + "]," + thang02 + "]," + thang03 + "]," + thang04 + "]," + thang05 + "]," + thang06 + "]," + thang07 + "]," + thang08 + "],";
            script += thang09 + "]," + thang10 + "]," + thang11 + "]," + thang12 + "]";
            Session["sanluong"] = script;

        }

        public void SoSanhTungNam() {
            string _cacnam = "'" + cacnam.Text.Replace(",", "','").Replace(" ", "");
            _cacnam = _cacnam + "'";

            string title = "['THÁNG'";
            string thang01 = "['01'";
            string thang02 = "['02'";
            string thang03 = "['03'";
            string thang04 = "['04'";
            string thang05 = "['05'";
            string thang06 = "['06'";
            string thang07 = "['07'";
            string thang08 = "['08'";
            string thang09 = "['09'";
            string thang10 = "['10'";
            string thang11 = "['11'";
            string thang12 = "['12'";

            double _thang01 = 0;
            double _thang02 = 0;
            double _thang03 = 0;
            double _thang04 = 0;
            double _thang05 = 0;
            double _thang06 = 0;
            double _thang07 = 0;
            double _thang08 = 0;
            double _thang09 = 0;
            double _thang10 = 0;
            double _thang11 = 0;
            double _thang12 = 0;

            DataTable table = Class.C_Chart.getBienDongSanLuong(_cacnam);
            GridView1.DataSource = table;
            GridView1.DataBind();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                title += ", '" + table.Rows[i]["NAM"].ToString() + "'";
                thang01 += ", " + table.Rows[i]["THANG01"].ToString() + "";
                _thang01 += double.Parse(table.Rows[i]["THANG01"].ToString());
                thang02 += ", " + table.Rows[i]["THANG02"].ToString() + "";
                _thang02 += double.Parse(table.Rows[i]["THANG02"].ToString());
                thang03 += ", " + table.Rows[i]["THANG03"].ToString() + "";
                _thang03 += double.Parse(table.Rows[i]["THANG03"].ToString());
                thang04 += ", " + table.Rows[i]["THANG04"].ToString() + "";
                _thang04 += double.Parse(table.Rows[i]["THANG04"].ToString());
                thang05 += ", " + table.Rows[i]["THANG05"].ToString() + "";
                _thang05 += double.Parse(table.Rows[i]["THANG05"].ToString());
                thang06 += ", " + table.Rows[i]["THANG06"].ToString() + "";
                _thang06 += double.Parse(table.Rows[i]["THANG06"].ToString());
                thang07 += ", " + table.Rows[i]["THANG07"].ToString() + "";
                _thang07 += double.Parse(table.Rows[i]["THANG07"].ToString());
                thang08 += ", " + table.Rows[i]["THANG08"].ToString() + "";
                _thang08 += double.Parse(table.Rows[i]["THANG08"].ToString());
                thang09 += ", " + table.Rows[i]["THANG09"].ToString() + "";
                _thang09 += double.Parse(table.Rows[i]["THANG09"].ToString());
                thang10 += ", " + table.Rows[i]["THANG10"].ToString() + "";
                _thang10 += double.Parse(table.Rows[i]["THANG10"].ToString());
                thang11 += ", " + table.Rows[i]["THANG11"].ToString() + "";
                _thang11 += double.Parse(table.Rows[i]["THANG11"].ToString());
                thang12 += ", " + table.Rows[i]["THANG12"].ToString() + "";
                _thang12 += double.Parse(table.Rows[i]["THANG12"].ToString());
            }


            title += ", 'Trung Bình " + (table.Rows.Count) + " năm'";
            thang01 += ", " + Math.Round(_thang01 / (table.Rows.Count), 2) + "";
            thang02 += ", " + Math.Round(_thang02 / (table.Rows.Count), 2) + "";
            thang03 += ", " + Math.Round(_thang03 / (table.Rows.Count), 2) + "";
            thang04 += ", " + Math.Round(_thang04 / (table.Rows.Count), 2) + "";
            thang05 += ", " + Math.Round(_thang05 / (table.Rows.Count), 2) + "";
            thang06 += ", " + Math.Round(_thang06 / (table.Rows.Count), 2) + "";
            thang07 += ", " + Math.Round(_thang07 / (table.Rows.Count), 2) + "";
            thang08 += ", " + Math.Round(_thang08 / (table.Rows.Count), 2) + "";
            thang09 += ", " + Math.Round(_thang09 / (table.Rows.Count), 2) + "";
            thang10 += ", " + Math.Round(_thang10 / (table.Rows.Count), 2) + "";
            thang11 += ", " + Math.Round(_thang11 / (table.Rows.Count), 2) + "";
            thang12 += ", " + Math.Round(_thang12 / (table.Rows.Count), 2) + ""; 


            string script = title + "]," + thang01 + "]," + thang02 + "]," + thang03 + "]," + thang04 + "]," + thang05 + "]," + thang06 + "]," + thang07 + "]," + thang08 + "],";
            script += thang09 + "]," + thang10 + "]," + thang11 + "]," + thang12 + "]";
            Session["sanluong"] = script;
        }
        string config = ConfigurationManager.AppSettings["configDoiDHN"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            cacnam.Text = DateTime.Now.Year.ToString();
            if ("1".Equals(config))
            {
                NamHienTai_DHN(DateTime.Now.Year.ToString());
            }
            else
            {
                TungNam(DateTime.Now.Year.ToString());
            }
            //SoSanhTungNam();
            
           // NamHienTai_DHN();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 0)
            {
                if ("1".Equals(config))
                {
                    NamHienTai_DHN(cacnam.Text);
                }
                else
                {
                    TungNam(cacnam.Text);
                }
            }
            else {
                SoSanhTungNam();
            }
        }
    }
}
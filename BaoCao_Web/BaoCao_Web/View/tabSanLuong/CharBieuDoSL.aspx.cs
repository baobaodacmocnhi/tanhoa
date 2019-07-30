using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BaoCao_Web.Class;

namespace BaoCao_Web.View.tabSanLuong
{
    public partial class CharBieuDoSL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
                
            NamHienTai_DHN();
        }
        public void NamHienTai_DHN()
        {
            string danhbo = Request.Params["value"].ToString();
            string title = "['KỲ','SẢN LƯỢNG']";
            
            string sl = "SELECT TOP(12) DANHBA,CAST(KY AS varchar)+'/'+CAST(NAM AS varchar) as KY,CODE,TIEUTHU FROM HOADON WHERE DANHBA='" + danhbo + "' ORDER BY NAM DESC, KY desc";
            DataTable table = LinQConnection.getDataTableHoaDon(sl);

            for (int i = table.Rows.Count-1; i >=0; i--)
            {
                //title += "['" + f + "'" + ", " + table.Rows[i]["TIEUTHU"].ToString() + "],";
                title += ", ['" + table.Rows[i]["KY"].ToString() +"'," + table.Rows[i]["TIEUTHU"].ToString() + "]";
             }

            Session["sanluong"] = title;

        }
    }
}
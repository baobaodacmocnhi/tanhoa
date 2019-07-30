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
    public partial class PhanTichThayDHN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataLoad();
        }
         
        public void DataLoad()
        {
          int  month = int.Parse(Request.Params["m"].ToString());
           int year = int.Parse(Request.Params["y"].ToString());
           string code = Request.Params["code"].ToString();
           string hieu = Request.Params["hieu"].ToString();
            
           lbTt.Text = "PHÂN TÍCH DANH SÁCH ĐHN CODE " + code;
            //string code = Request.Params["code"].ToString();

            

           string sql = " SELECT hd.DOT, DANHBA, TENKH , SO +' '+DUONG AS DIACHI,GB , DM ,'' AS K1,'' AS C1,'' AS T1,'' AS K2,'' AS C2,'' AS T2,''AS K3,'' AS C3,'' AS T3,CAST(hd.KY AS varchar)+'/'+CAST(hd.NAM AS varchar) as KY,hd.CODE,TIEUTHU,'' AS TK1,'' AS TC1,'' AS TT1,'' AS TK2,'' AS TC2,'' AS TT2,'' AS TK3,'' AS TC3,'' AS TT3 ";
           sql += " FROM W_HOADON hd where  hd.KY=" + month + " AND hd.NAM=" + year + " AND hd.CODE LIKE '" + code + "%' ";
            if(!hieu.Equals(""))
                sql += " AND LEFT(replace(hd.HIEUDH,' ',''),3)='" + hieu + "' ";

            DataTable tbsl = LinQConnection.getDataTableHoaDon(sql);
            for (int i = 0; i < tbsl.Rows.Count; i++)
            {
                DataTable tbSau = null;
                string db = tbsl.Rows[i]["DANHBA"].ToString();
                // 3 ky sau thay                 
                sql = " SELECT TOP(3) DANHBA,CAST(KY AS varchar)+'/'+CAST(NAM AS varchar) as KY,CODE,TIEUTHU  FROM W_HOADON WHERE DANHBA='" + db + "' AND KY >" + month + " AND NAM=" + year;
                tbSau = LinQConnection.getDataTableHoaDon(sql);
                for (int j = 0; j < tbSau.Rows.Count; j++)
                {
                    tbsl.Rows[i]["TK" + (j + 1)] = tbSau.Rows[j]["KY"].ToString();
                    tbsl.Rows[i]["TC" + (j + 1)] = tbSau.Rows[j]["CODE"].ToString();
                    tbsl.Rows[i]["TT" + (j + 1)] = tbSau.Rows[j]["TIEUTHU"].ToString();
                }
                if (tbSau.Rows.Count < 3)
                {
                    sql = " SELECT TOP(" + (3 - tbSau.Rows.Count) + ") DANHBA,CAST(KY AS varchar)+'/'+CAST(NAM AS varchar) as KY,CODE,TIEUTHU  FROM W_HOADON WHERE DANHBA='" + db + "' AND KY >= 1 AND NAM=" + (year + 1);
                    tbSau = LinQConnection.getDataTableHoaDon(sql);
                    if (tbSau.Rows.Count == 1)
                    {
                        tbsl.Rows[i]["TK3"] = tbSau.Rows[0]["KY"].ToString();
                        tbsl.Rows[i]["TC3"] = tbSau.Rows[0]["CODE"].ToString();
                        tbsl.Rows[i]["TT3"] = tbSau.Rows[0]["TIEUTHU"].ToString();
                    }
                    if (tbSau.Rows.Count >= 2)
                    {
                        for (int j = 0; j < tbSau.Rows.Count; j++)
                        {
                            tbsl.Rows[i]["TK" + (j + 1)] = tbSau.Rows[j]["KY"].ToString();
                            tbsl.Rows[i]["TC" + (j + 1)] = tbSau.Rows[j]["CODE"].ToString();
                            tbsl.Rows[i]["TT" + (j + 1)] = tbSau.Rows[j]["TIEUTHU"].ToString();
                        }
                    }
                }
                // 3 ky truoc thay 
                sql = " SELECT TOP(3) DANHBA,CAST(KY AS varchar)+'/'+CAST(NAM AS varchar) as KY,CODE,TIEUTHU FROM W_HOADON WHERE DANHBA='" + db + "' AND KY <" + month + " AND NAM=" + year + " ORDER BY CAST(KY AS int) DESC ";
                tbSau = LinQConnection.getDataTableHoaDon(sql);
                int f = 3;
                //for (int j = tbSau.Rows.Count - 1; j >= 0; j--)
                //{
                //    tbsl.Rows[i]["K" + f] = tbSau.Rows[j]["KY"].ToString();
                //    tbsl.Rows[i]["C" + f] = tbSau.Rows[j]["CODE"].ToString();
                //    tbsl.Rows[i]["T" + f] = tbSau.Rows[j]["TIEUTHU"].ToString();
                //    f--;
                //}

                for (int j = 0; j < tbSau.Rows.Count; j++)
                {
                    tbsl.Rows[i]["K" + f] = tbSau.Rows[j]["KY"].ToString();
                    tbsl.Rows[i]["C" + f] = tbSau.Rows[j]["CODE"].ToString();
                    tbsl.Rows[i]["T" + f] = tbSau.Rows[j]["TIEUTHU"].ToString();
                    f--;
                }

                if (tbSau.Rows.Count < 3)
                {
                    sql = " SELECT TOP(" + (3 - tbSau.Rows.Count) + ") DANHBA,CAST(KY AS varchar)+'/'+CAST(NAM AS varchar) as KY,CODE,TIEUTHU FROM W_HOADON WHERE DANHBA='" + db + "' AND KY <=12 AND NAM=" + (year - 1) + "  ORDER BY CAST(KY AS int) DESC ";
                    tbSau = LinQConnection.getDataTableHoaDon(sql);
                    if (tbSau.Rows.Count == 1)
                    {
                        tbsl.Rows[i]["K" + f] = tbSau.Rows[0]["KY"].ToString();
                        tbsl.Rows[i]["C" + f] = tbSau.Rows[0]["CODE"].ToString();
                        tbsl.Rows[i]["T" + f] = tbSau.Rows[0]["TIEUTHU"].ToString();
                    }
                    if (tbSau.Rows.Count >= 2)
                    {
                        for (int j = 0; j < tbSau.Rows.Count; j++)
                        {
                            tbsl.Rows[i]["K" + f] = tbSau.Rows[j]["KY"].ToString();
                            tbsl.Rows[i]["C" + f] = tbSau.Rows[j]["CODE"].ToString();
                            tbsl.Rows[i]["T" + f] = tbSau.Rows[j]["TIEUTHU"].ToString();
                            f--;
                        }
                    }
                }
            }

            //GridView1.DataSource = tbsl;
            //GridView1.DataBind();
            Session["chamcong"] = tbsl;
        }
    }
}
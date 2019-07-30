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
    public partial class FillData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDanhBo.Visible = false;
            btThem.Visible = false;
            btThem0.Visible = false;
            if ("GIÁ BIỂU".Equals(Session["LoaiDT"] + "") || "CỞ ĐHN".Equals(Session["LoaiDT"] + ""))
            {
                PLoad();
            }
            if ("TIEMNANG".Equals(Request.Params["value"].ToString()))
            {
                LoadTiemNang();
                lbTt.Text = "DANH SÁCH KHÁCH HÀNG TIỀM NĂNG";
                txtDanhBo.Visible = true;
                btThem.Visible = true;
                btThem0.Visible = true;
            }


        }
        public void PLoad()
        {
            string pra = Request.Params["value"].ToString();
            string sql = "SELECT SUBSTRING(LOTRINH,1,2) as 'DOT', kh.DANHBO, kh.HOTEN, kh.SONHA +' '+kh.TENDUONG AS DIACHI,kh.GIABIEU as GB,kh.DINHMUC as DM, ";
            sql += " '' AS K1,'' AS C1,'' AS T1,'' AS K2,'' AS C2,'' AS T2 ,'' AS K3,'' AS C3,'' AS T3 ,'' AS K4,'' AS C4,'' AS T4 ,'' AS K5,'' AS C5,'' AS T5 ,'' AS K6,'' AS C6,'' AS T6 , ";
            sql += " '' AS K7,'' AS C7,'' AS T7 ,'' AS K8,'' AS C8,'' AS T8 ,'' AS K9,'' AS C9,'' AS T9 ,'' AS K10,'' AS C10,'' AS T10, '' AS K11,'' AS C11,'' AS T11,'' AS K12,'' AS C12,'' AS T12 ";
            sql += " FROM  TB_DULIEUKHACHHANG kh ";
           
            
            if ("GIÁ BIỂU".Equals(Session["LoaiDT"] + ""))
            {
                sql += "     WHERE GIABIEU='" + pra + "'";
                lbTt.Text = "DANH SÁCH KHÁCH HÀNG THEO GIÁ BIỂU";
            }
            else if ("CỞ ĐHN".Equals(Session["LoaiDT"] + ""))
            {
                sql += "     WHERE CODH='" + pra + "'";
                lbTt.Text = "DANH SÁCH KHÁCH HÀNG THEO CỞ ĐHN";
            }

            DataTable tb = LinQConnection.getDataTable(sql);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                string sl = "SELECT TOP(12) DANHBA,CAST(KY AS varchar)+'/'+CAST(NAM AS varchar) as KY,CODE,TIEUTHU FROM HOADON WHERE DANHBA='" + tb.Rows[i]["DANHBO"].ToString() + "' ORDER BY CAST(NAM AS INT) DESC, CAST(KY AS INT) DESC ";
                DataTable tbsl = LinQConnection.getDataTableHoaDon(sl);
                for (int j = 0; j < tbsl.Rows.Count; j++)
                {
                    tb.Rows[i]["K" + (j + 1)] = tbsl.Rows[j]["KY"].ToString();
                    tb.Rows[i]["C" + (j + 1)] = tbsl.Rows[j]["CODE"].ToString();
                    tb.Rows[i]["T" + (j + 1)] = tbsl.Rows[j]["TIEUTHU"].ToString();

                }
            }
           

            Session["chamcong"] = tb;
        }

        public void LoadTiemNang()
        {
            string pra = Request.Params["value"].ToString();
            string sql = "SELECT SUBSTRING(LOTRINH,1,2) as 'DOT', kh.DANHBO, kh.HOTEN, kh.SONHA +' '+kh.TENDUONG AS DIACHI,kh.GIABIEU as GB,kh.DINHMUC as DM, ";
            sql += " '' AS K1,'' AS C1,'' AS T1,'' AS K2,'' AS C2,'' AS T2 ,'' AS K3,'' AS C3,'' AS T3 ,'' AS K4,'' AS C4,'' AS T4 ,'' AS K5,'' AS C5,'' AS T5 ,'' AS K6,'' AS C6,'' AS T6 , ";
            sql += " '' AS K7,'' AS C7,'' AS T7 ,'' AS K8,'' AS C8,'' AS T8 ,'' AS K9,'' AS C9,'' AS T9 ,'' AS K10,'' AS C10,'' AS T10, '' AS K11,'' AS C11,'' AS T11,'' AS K12,'' AS C12,'' AS T12 ";
            sql += " FROM  TB_DULIEUKHACHHANG kh ,TB_KHACHHANGTIEMNANG tn WHERE kh.DANHBO=tn.DANHBO ";


            DataTable tb = LinQConnection.getDataTable(sql);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                string sl = "SELECT TOP(12) DANHBA,CAST(KY AS varchar)+'/'+CAST(NAM AS varchar) as KY,CODE,TIEUTHU FROM HOADON WHERE DANHBA='" + tb.Rows[i]["DANHBO"].ToString() + "' ORDER BY CAST(NAM AS INT) DESC, CAST(KY AS INT) DESC ";
                DataTable tbsl = LinQConnection.getDataTableHoaDon(sl);
                for (int j = 0; j < tbsl.Rows.Count; j++)
                {
                    tb.Rows[i]["K" + (j + 1)] = tbsl.Rows[j]["KY"].ToString();
                    tb.Rows[i]["C" + (j + 1)] = tbsl.Rows[j]["CODE"].ToString();
                    tb.Rows[i]["T" + (j + 1)] = tbsl.Rows[j]["TIEUTHU"].ToString();

                }
            }


            Session["chamcong"] = tb;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LinQConnection.ExecuteCommand("INSERT INTO TB_KHACHHANGTIEMNANG VALUES ('"+txtDanhBo.Text+"')");
            //Response.Redirect(@"View/tabSanLuong/FillData.aspx?value=TIEMNANG");
            Response.Redirect(Request.RawUrl);
        }

        protected void btThem0_Click(object sender, EventArgs e)
        {
            LinQConnection.ExecuteCommand("DELETE FROM  TB_KHACHHANGTIEMNANG WHERE DANHBO='" + txtDanhBo.Text + "'");
           // Response.Redirect(@"View/tabSanLuong/FillData.aspx?value=TIEMNANG");
           // Response.Redirect(Request.RawUrl);
           
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect(@"View\Home.aspx");
        }
    }
}
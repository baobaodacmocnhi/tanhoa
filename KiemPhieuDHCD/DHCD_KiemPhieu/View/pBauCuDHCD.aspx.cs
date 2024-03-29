﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DHCD_KiemPhieu.View
{
    public partial class pBauCuDHCD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            this.tungay.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            DropDownList2.SelectedIndex = 10;
        }

        private void Binddata()
        {
            checkName.DataSource = Class.LinQConnection.getDataTable("SELECT STT,  (CAST(STT AS VARCHAR) + '. ' +TENBC) AS  TENBC FROM BAUCU WHERE LANBC= " + DropDownList1.SelectedValue.ToString() + " AND CONVERT(VARCHAR(50),NGAYBC,103)='" + this.tungay.Text + "'  ORDER BY STT ASC ");
            checkName.DataTextField = "TENBC";
            checkName.DataValueField = "STT";
            checkName.DataBind();
            loadKQ();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Binddata();
            if (DropDownList1.SelectedIndex == 1)
            {
                title.Text  = "..: KIỂM PHIẾU BẦU ĐẠI BIỂU THAM GIA TỔ ĐỐI THOẠI ĐỊNH KỲ NĂM 2020 :..";
                lbKetqua.Text = "KẾT QUẢ BẦU ĐẠI BIỂU THAM GIA TỔ ĐỐI THOẠI ĐỊNH KỲ NĂM 2020";
            }
            else if (DropDownList1.SelectedIndex == 2)
            {
                title.Text = "..: KIỂM PHIẾU BẦU ĐẠI BIỂU BAN THANH TRA NHÂN DÂN ĐỊNH KỲ NĂM 2019 :..";
                lbKetqua.Text = "KẾT QUẢ BẦU ĐẠI BIỂU BAN THANH TRA NHÂN DÂN ĐỊNH KỲ NĂM 2019";
            }
        }

        protected void G_KDY_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Class.LinQConnection.ExecuteCommand("DELETE FROM KIEMPHIEU WHERE ID='" + e.CommandArgument.ToString() + "'");
            Binddata();
        }
       
        protected void checkName_SelectedIndexChanged(object sender, EventArgs e)
        {
                for (int i = 0; i < checkName.Items.Count; i++)
                {
                    if (checkName.Items[i].Selected)
                    {
                        checkName.Items[i].Attributes.Add("style", "text-decoration:line-through; color:Red;");
                    }
                }   
       
        }

        void loadKQ()
        {
            this.tc_thuvao.Text = "0";
            string sql = " SELECT STT,  TENBC,SUM(SLDY) AS DY, ";
            sql += " ROUND(100.0*((SUM(SLDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLDY ,";
            sql += " SUM(SLKDY) AS KDY ,  ";
            sql += " ROUND(100.0*((SUM(SLKDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLKDY ";
            sql += " FROM BAUCU WHERE (STT > 0 AND STT <= " + DropDownList2.SelectedValue.ToString() + "  ) AND LANBC= " + DropDownList1.SelectedValue.ToString() + " AND CONVERT(VARCHAR(50),NGAYBC,103)='" + this.tungay.Text + "' ";
            sql += " GROUP BY STT,TENBC ORDER BY STT ASC  ";

            DataTable tb = Class.LinQConnection.getDataTable(sql);
            gTK.DataSource = tb;           
            Session["SQL"] = sql;
            Session["LoaiBaoCao"] = DropDownList1.SelectedValue.ToString();
            //// sort
            //string sqlSort = " SELECT   STT,  TENBC,TENBC2,SUM(SLDY) AS DY, ";
            //sqlSort += " ROUND(100.0*((SUM(SLDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLDY ,";
            //sqlSort += " SUM(SLKDY) AS KDY ,  ";
            //sqlSort += " ROUND(100.0*((SUM(SLKDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLKDY ";
            //sqlSort += " FROM BAUCU WHERE STT > 0 AND LANBC= " + DropDownList1.SelectedValue.ToString() + " AND CONVERT(VARCHAR(50),NGAYBC,103)='" + this.tungay.Text + "' ";
            //sqlSort += " GROUP BY STT,TENBC,TENBC2 ORDER BY SUM(SLDY) DESC,TENBC2 ASC ";
            //Session["SQL2"] = sqlSort;
            ////

            gTK.DataBind();
            try
            {
                string sql2 = "SELECT SUM(SLKDY)  FROM BAUCU WHERE STT= 0 AND LANBC= " + DropDownList1.SelectedValue.ToString() + " AND CONVERT(VARCHAR(50),NGAYBC,103)='" + this.tungay.Text + "' ";
                double khople = Class.LinQConnection.ReturnResult(sql2);
               
                int kq = int.Parse(tb.Rows[0]["DY"].ToString()) + int.Parse(tb.Rows[0]["KDY"].ToString());
                
                this.tc_hople.Text = (kq) + "";
                this.tc_khople.Text = khople + "";
                this.tc_thuvao.Text = (kq + khople) + "";

                Session["TV"] = this.tc_thuvao.Text;
                Session["HL"] = this.tc_hople.Text ;
                Session["KHL"] = this.tc_khople.Text;

            }
            catch (Exception)
            {
                this.tc_hople.Text = "0";
                this.tc_khople.Text = "0";
                this.tc_thuvao.Text = "0";
            }

        }
        protected void btSubmit_Click(object sender, EventArgs e)
        {
            if (checkName.Items[0].Selected)
            {
                string sql = "UPDATE BAUCU SET SLKDY= (SLKDY+1) WHERE STT=0 AND LANBC= " + DropDownList1.SelectedValue.ToString() + " AND CONVERT(VARCHAR(50),NGAYBC,103)='" + this.tungay.Text + "'";
                Class.LinQConnection.ExecuteCommand(sql);
                checkName.Items[0].Selected = false;
            }
            else
            {
                for (int i = 0; i < checkName.Items.Count; i++)
                {
                    if (checkName.Items[i].Selected)
                    {
                        string sql = "UPDATE BAUCU SET SLKDY= (SLKDY+1) WHERE STT <> 0 AND STT=" + checkName.Items[i].Value + " AND LANBC= " + DropDownList1.SelectedValue.ToString() + " AND CONVERT(VARCHAR(50),NGAYBC,103)='" + this.tungay.Text + "'";
                        Class.LinQConnection.ExecuteCommand(sql);
                        checkName.Items[i].Selected = false;
                    }
                    else
                    {
                        string sql = "UPDATE BAUCU SET SLDY= (SLDY+1) WHERE STT <> 0 AND  STT=" + checkName.Items[i].Value + " AND  LANBC= " + DropDownList1.SelectedValue.ToString() + " AND CONVERT(VARCHAR(50),NGAYBC,103)='" + this.tungay.Text + "'";
                        Class.LinQConnection.ExecuteCommand(sql);
                    }
                }
            }
            Binddata();           
        }

        protected void lSort_Click(object sender, EventArgs e)
        {
            string sql = " SELECT   STT,  TENBC,TENBC2,SUM(SLDY) AS DY, ";
            sql += " ROUND(100.0*((SUM(SLDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLDY ,";
            sql += " SUM(SLKDY) AS KDY ,  ";
            sql += " ROUND(100.0*((SUM(SLKDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLKDY ";
            sql += " FROM BAUCU WHERE STT > 0 AND LANBC= " + DropDownList1.SelectedValue.ToString() + " AND CONVERT(VARCHAR(50),NGAYBC,103)='" + this.tungay.Text + "' ";
            sql += " GROUP BY STT,TENBC,TENBC2 ORDER BY SUM(SLDY) DESC,TENBC2 ASC ";

            gTK.DataSource = Class.LinQConnection.getDataTable(sql);
            gTK.DataBind();
        }

        //protected void txtTheTV_TextChanged(object sender, EventArgs e)
        //{
        //    this.tc_phatra.Text = String.Format("{0:0,0}", txtTheTV.Text);
        //}

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadKQ();
        }

        protected void btKetQua_Click(object sender, EventArgs e)
        {
            string sql = " SELECT TOP(" + DropDownList3.SelectedValue.ToString() + ")   STT,  TENBC,TENBC2,SUM(SLDY) AS DY, ";
            sql += " ROUND(100.0*((SUM(SLDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLDY ,";
            sql += " SUM(SLKDY) AS KDY ,  ";
            sql += " ROUND(100.0*((SUM(SLKDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLKDY ";
            sql += " FROM BAUCU WHERE STT > 0 AND LANBC= " + DropDownList1.SelectedValue.ToString() + " AND CONVERT(VARCHAR(50),NGAYBC,103)='" + this.tungay.Text + "' ";
            sql += " GROUP BY STT,TENBC,TENBC2 ORDER BY SUM(SLDY) DESC,TENBC2 ASC ";

            gTK.DataSource = Class.LinQConnection.getDataTable(sql);
            gTK.DataBind();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedValue.ToString() == "0")
                loadKQ();
            else
            {
                string sql = " SELECT TOP(" + DropDownList3.SelectedValue.ToString() + ")   STT,  TENBC,TENBC2,SUM(SLDY) AS DY, ";
                sql += " ROUND(100.0*((SUM(SLDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLDY ,";
                sql += " SUM(SLKDY) AS KDY ,  ";
                sql += " ROUND(100.0*((SUM(SLKDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLKDY ";
                sql += " FROM BAUCU WHERE STT > 0 AND LANBC= " + DropDownList1.SelectedValue.ToString() + " AND CONVERT(VARCHAR(50),NGAYBC,103)='" + this.tungay.Text + "' ";
                sql += " GROUP BY STT,TENBC,TENBC2 ORDER BY SUM(SLDY) DESC,TENBC2 ASC ";

                gTK.DataSource = Class.LinQConnection.getDataTable(sql);
                gTK.DataBind();

                // sort
                string sqlSort = " SELECT TOP(" + DropDownList3.SelectedValue.ToString() + ")  STT,  TENBC,TENBC2,SUM(SLDY) AS DY, ";
                sqlSort += " ROUND(100.0*((SUM(SLDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLDY ,";
                sqlSort += " SUM(SLKDY) AS KDY ,  ";
                sqlSort += " ROUND(100.0*((SUM(SLKDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLKDY ";
                sqlSort += " FROM BAUCU WHERE STT > 0 AND LANBC= " + DropDownList1.SelectedValue.ToString() + " AND CONVERT(VARCHAR(50),NGAYBC,103)='" + this.tungay.Text + "' ";
                sqlSort += " GROUP BY STT,TENBC,TENBC2 ORDER BY SUM(SLDY) DESC,TENBC2 ASC ";
                Session["SQL2"] = sqlSort;
                //
            }

        }

        protected void an_CheckedChanged(object sender, EventArgs e)
        {
            if(an.Checked)
                this.Panel1.Visible = false;
            else
                this.Panel1.Visible = true;
            
        }
    }
}
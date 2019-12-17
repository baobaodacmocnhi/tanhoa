using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Transactions;

namespace DHCD_KiemPhieu.View
{
    public partial class pBauCuCongDoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dgvDaBau.AutoGenerateColumns = false;
            if (Session["login"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            this.tungay.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            DropDownList2.SelectedIndex = 12;
        }

        private void Binddata()
        {
            //checkName.DataSource = Class.LinQConnection.getDataTable("SELECT ID,  (CAST(ID AS VARCHAR) + '. ' +TENBC) AS  TENBC FROM BB_THANHVIENBAUCU WHERE LANBC= " + DropDownList1.SelectedValue.ToString() + " AND CONVERT(VARCHAR(50),NGAYBC,103)='" + this.tungay.Text + "'  ORDER BY ID ASC ");
            checkName.DataSource = Class.LinQConnection.getDataTable("SELECT ID,  (CAST(ID AS VARCHAR) + '. ' +TENBC) AS  TENBC FROM BB_THANHVIENBAUCU WHERE LANBC= " + DropDownList1.SelectedValue.ToString() + " ORDER BY ID ASC ");
            checkName.DataTextField = "TENBC";
            checkName.DataValueField = "ID";
            checkName.DataBind();
            loadKQ();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Binddata();
            if (DropDownList1.SelectedIndex == 1)
            {
                title.Text = "..: KIỂM PHIẾU BẦU BAN CHẤP HÀNH CÔNG ĐOÀN KHÓA II, NHIỆM KỲ 2020-2025 :..";
                lbKetqua.Text = "KẾT QUẢ BẦU BAN CHẤP HÀNH CÔNG ĐOÀN KHÓA II, NHIỆM KỲ 2020-2025";
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

        public void LoadDSDaNhap()
        {
            //load danh sách đã nhập
            DataTable dt = Class.LinQConnection.getDataTable("select ID,STT=ROW_NUMBER() OVER(ORDER BY ID ASC),CreateDate,KHONGHOPLE,SoLuong=COUNT(*) from BB_KETQUABAUCU where CreateBy=" + Session["login"] + " group by ID,CreateDate,KHONGHOPLE order by ID desc");
            dgvDaBau.DataSource = dt;
            dgvDaBau.DataBind();
        }

        public void loadKQ()
        {
            LoadDSDaNhap();

            this.tc_thuvao.Text = "0";

            string sql = "select STT=ROW_NUMBER() OVER(ORDER BY IDUngVien ASC),TenBC=(select TenBC from BB_THANHVIENBAUCU where ID=IDUngVien)"
                        + " ,DY=SUM(CASE WHEN DongY=1 THEN 1 else 0 END)"
                        + " ,TLDY=ROUND(100.0*((SUM(CASE WHEN DongY=1 THEN 1 else 0 END)*1.0)/(SUM(CASE WHEN DongY=1 THEN 1 else 0 END)+SUM(CASE WHEN KhongDongY=1 THEN 1 else 0 END) )),2)"
                        + " ,KDY=SUM(CASE WHEN KhongDongY=1 THEN 1 else 0 END)"
                        + " ,TLKDY=ROUND(100.0*((SUM(CASE WHEN KhongDongY=1 THEN 1 else 0 END)*1.0)/(SUM(CASE WHEN DongY=1 THEN 1 else 0 END)+SUM(CASE WHEN KhongDongY=1 THEN 1 else 0 END) )),2)"
                        + " from BB_KETQUABAUCU where (IDUngVien > 0 AND IDUngVien <= " + DropDownList2.SelectedValue.ToString() + "  ) group by IDUngVien";

            DataTable tb = Class.LinQConnection.getDataTable(sql);
            gTK.DataSource = tb;
            Session["SQL"] = sql;
            Session["LoaiBaoCao"] = DropDownList1.SelectedValue.ToString();
            //// sort
            //string sqlSort = " SELECT   STT,  TENBC,TENBC2,SUM(SLDY) AS DY, ";
            //sqlSort += " ROUND(100.0*((SUM(SLDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLDY ,";
            //sqlSort += " SUM(SLKDY) AS KDY ,  ";
            //sqlSort += " ROUND(100.0*((SUM(SLKDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLKDY1 ";
            //sqlSort += " FROM BAUCU WHERE STT > 0 AND LANBC= " + DropDownList1.SelectedValue.ToString() + " AND CONVERT(VARCHAR(50),NGAYBC,103)='" + this.tungay.Text + "' ";
            //sqlSort += " GROUP BY STT,TENBC,TENBC2 ORDER BY SUM(SLDY) DESC,TENBC2 ASC ";
            //Session["SQL2"] = sqlSort;
            ////

            gTK.DataBind();
            try
            {
                string sql1 = "select HopLe=COUNT(*) from (select distinct ID,CreateDate from BB_KETQUABAUCU where KHONGHOPLE=0)t1";
                double hople = Class.LinQConnection.ReturnResult(sql1);
                string sql2 = "select KhongHopLe=COUNT(*) from (select distinct ID,CreateDate from BB_KETQUABAUCU where KHONGHOPLE=1)t1";
                double khonghople = Class.LinQConnection.ReturnResult(sql2);

                this.tc_hople.Text = hople + "";
                this.tc_khople.Text = khonghople + "";
                this.tc_thuvao.Text = (hople + khonghople) + "";

                Session["TV"] = this.tc_thuvao.Text;
                Session["HL"] = this.tc_hople.Text;
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
            DateTime date = DateTime.Now;
            if (checkName.Items[0].Selected)
            {
                string sql = "declare @ID int"
                            + " set @ID=(case when not exists(select ID from BB_KETQUABAUCU) then 1 else (select MAX(ID) from BB_KETQUABAUCU)+1 end)";
                for (int i = 1; i < checkName.Items.Count; i++)
                {
                    sql += " insert into BB_KETQUABAUCU(ID,IDUNGVIEN,KHONGHOPLE,DONGY,KHONGDONGY,CREATEBY,CREATEDATE)values(@ID," + checkName.Items[i].Value + ",1,0,1," + Session["login"] + ",'" + date.ToString("yyyyMMdd HH:mm:ss") + "')";
                }
                using (TransactionScope scope = new TransactionScope())
                {
                    if (Class.LinQConnection.ExecuteCommand(sql) > 0)
                        scope.Complete();
                }
                checkName.Items[0].Selected = false;
            }
            else
            {
                string sql = "declare @ID int"
                             + " set @ID=(case when not exists(select ID from BB_KETQUABAUCU) then 1 else (select MAX(ID) from BB_KETQUABAUCU)+1 end)";
                for (int i = 1; i < checkName.Items.Count; i++)
                {
                    if (checkName.Items[i].Selected)
                    {
                        sql += " insert into BB_KETQUABAUCU(ID,IDUNGVIEN,DONGY,KHONGDONGY,CREATEBY,CREATEDATE)values(@ID," + checkName.Items[i].Value + ",0,1," + Session["login"] + ",'" + date.ToString("yyyyMMdd HH:mm:ss") + "')";
                        checkName.Items[i].Selected = false;
                    }
                    else
                    {
                        sql += " insert into BB_KETQUABAUCU(ID,IDUNGVIEN,DONGY,KHONGDONGY,CREATEBY,CREATEDATE)values(@ID," + checkName.Items[i].Value + ",1,0," + Session["login"] + ",'" + date.ToString("yyyyMMdd HH:mm:ss") + "')";
                    }
                }
                using (TransactionScope scope = new TransactionScope())
                {
                    if (Class.LinQConnection.ExecuteCommand(sql) > 0)
                        scope.Complete();
                }
            }
            Binddata();
        }

        protected void lSort_Click(object sender, EventArgs e)
        {
            string sql = " SELECT   STT,  TENBC,TENBC2,SUM(SLDY) AS DY, ";
            sql += " ROUND(100.0*((SUM(SLDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLDY ,";
            sql += " SUM(SLKDY) AS KDY ,  ";
            sql += " ROUND(100.0*((SUM(SLKDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLKDY1 ";
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
            string sql = "select TOP(" + DropDownList3.SelectedValue.ToString() + ") STT=IDUngVien,TenBC=(select TenBC from BB_THANHVIENBAUCU where ID=IDUngVien)"
                        + " ,DY=SUM(CASE WHEN DongY=1 THEN 1 else 0 END)"
                        + " ,TLDY=ROUND(100.0*((SUM(CASE WHEN DongY=1 THEN 1 else 0 END)*1.0)/(SUM(CASE WHEN DongY=1 THEN 1 else 0 END)+SUM(CASE WHEN KhongDongY=1 THEN 1 else 0 END) )),2)"
                        + " ,KDY=SUM(CASE WHEN KhongDongY=1 THEN 1 else 0 END)"
                        + " ,TLKDY=ROUND(100.0*((SUM(CASE WHEN KhongDongY=1 THEN 1 else 0 END)*1.0)/(SUM(CASE WHEN DongY=1 THEN 1 else 0 END)+SUM(CASE WHEN KhongDongY=1 THEN 1 else 0 END) )),2)"
                        + " from BB_KETQUABAUCU where (IDUngVien > 0 AND IDUngVien <= " + DropDownList2.SelectedValue.ToString() + "  ) group by IDUngVien"
                        + " order by SUM(CASE WHEN DongY=1 THEN 1 else 0 END) desc";



            gTK.DataSource = Class.LinQConnection.getDataTable(sql);
            gTK.DataBind();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedValue.ToString() == "0")
                loadKQ();
            else
            {
                //string sql = " SELECT TOP(" + DropDownList3.SelectedValue.ToString() + ")   STT,  TENBC,TENBC2,SUM(SLDY) AS DY, ";
                //sql += " ROUND(100.0*((SUM(SLDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLDY ,";
                //sql += " SUM(SLKDY) AS KDY ,  ";
                //sql += " ROUND(100.0*((SUM(SLKDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLKDY1 ";
                //sql += " FROM BAUCU WHERE STT > 0 AND LANBC= " + DropDownList1.SelectedValue.ToString() + " AND CONVERT(VARCHAR(50),NGAYBC,103)='" + this.tungay.Text + "' ";
                //sql += " GROUP BY STT,TENBC,TENBC2 ORDER BY SUM(SLDY) DESC,TENBC2 ASC ";

                string sql = "select TOP(" + DropDownList3.SelectedValue.ToString() + ") STT=IDUngVien,TenBC=(select TenBC from BB_THANHVIENBAUCU where ID=IDUngVien)"
                        + " ,DY=SUM(CASE WHEN DongY=1 THEN 1 else 0 END)"
                        + " ,TLDY=ROUND(100.0*((SUM(CASE WHEN DongY=1 THEN 1 else 0 END)*1.0)/(SUM(CASE WHEN DongY=1 THEN 1 else 0 END)+SUM(CASE WHEN KhongDongY=1 THEN 1 else 0 END) )),2)"
                        + " ,KDY=SUM(CASE WHEN KhongDongY=1 THEN 1 else 0 END)"
                        + " ,TLKDY=ROUND(100.0*((SUM(CASE WHEN KhongDongY=1 THEN 1 else 0 END)*1.0)/(SUM(CASE WHEN DongY=1 THEN 1 else 0 END)+SUM(CASE WHEN KhongDongY=1 THEN 1 else 0 END) )),2)"
                        + " from BB_KETQUABAUCU where (IDUngVien > 0 AND IDUngVien <= " + DropDownList2.SelectedValue.ToString() + "  ) group by IDUngVien"
                        + " order by SUM(CASE WHEN DongY=1 THEN 1 else 0 END) desc";

                DataTable dt = Class.LinQConnection.getDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                }

                gTK.DataSource = dt;
                gTK.DataBind();

                // sort
                string sqlSort = " SELECT TOP(" + DropDownList3.SelectedValue.ToString() + ")  STT,  TENBC,TENBC2,SUM(SLDY) AS DY, ";
                sqlSort += " ROUND(100.0*((SUM(SLDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLDY ,";
                sqlSort += " SUM(SLKDY) AS KDY ,  ";
                sqlSort += " ROUND(100.0*((SUM(SLKDY)*1.0)/(SUM(SLDY)+SUM(SLKDY) )),2)  AS TLKDY1 ";
                sqlSort += " FROM BAUCU WHERE STT > 0 AND LANBC= " + DropDownList1.SelectedValue.ToString() + " AND CONVERT(VARCHAR(50),NGAYBC,103)='" + this.tungay.Text + "' ";
                sqlSort += " GROUP BY STT,TENBC,TENBC2 ORDER BY SUM(SLDY) DESC,TENBC2 ASC ";
                Session["SQL2"] = sql;
                //
            }

        }

        protected void an_CheckedChanged(object sender, EventArgs e)
        {
            if (an.Checked)
                this.Panel1.Visible = false;
            else
                this.Panel1.Visible = true;

        }

        protected void btnDanhSachDaNhap_Click(object sender, EventArgs e)
        {
            if (dgvDaBau.Visible == true)
                dgvDaBau.Visible = false;
            else
                dgvDaBau.Visible = true;
        }

        protected void dgvDaBau_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (Class.LinQConnection.ExecuteCommand("delete BB_KETQUABAUCU where ID=" + e.Values[4]) > 0)
                    scope.Complete();
            }
            loadKQ();
        }
    }
}
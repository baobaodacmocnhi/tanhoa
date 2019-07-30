using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoCao_Web.View.tabDHN
{
    public partial class tab_ChiTietCode : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            nam.Text = DateTime.Now.Year.ToString();
            if (DateTime.Now.Month == 0)
            {
                this.ky.SelectedIndex = 0;
            }
            else
            {
                this.ky.SelectedIndex = DateTime.Now.Month - 1;
            }
            Panel1.Width = 2800;
        }
        log4net.ILog log = log4net.LogManager.GetLogger("File");
        protected void btXemBangKe_Click(object sender, EventArgs e)
        {
            log.Info("--------------------------------------------------------");
            Class.C_BaoCaoCodeDS.RESET_CODE_DS_DETAIL();
            string dotds = dot.Text;
            string kyds = ky.Text;
            string namds = nam.Text;
            int ky_ = int.Parse(kyds);
            int nam_ = int.Parse(namds);
            int dot_ = int.Parse(dotds);
            if ("00".Equals(dotds))
            {
              

                // ky hien tai       
                Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_KYNAY_DETAIL(nam_.ToString(), ky_);
                // ky truoc
                if (ky_ == 1)
                {
                    Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC((nam_ - 1) + "", 12);
                    Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_DETAIL((nam_ - 1) + "", 12);
                }
                else
                {
                    Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC(nam_.ToString(), ky_ - 1);
                    Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_DETAIL(nam_.ToString(), ky_ - 1);
                }
                GridView1.DataSource = Class.C_BaoCaoCodeDS.get_BAOCAO_CODE_DETAIL();
                GridView1.DataBind();
            }
            else
            {
                Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_KYNAY_DETAIL_DOT(nam_.ToString(), ky_, dot_);
                // ky truoc
                if (ky_ == 1)
                {
                    Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_DETAIL_DOT((nam_ - 1) + "", 12, dot_);
                }
                else
                {
                    Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_DETAIL_DOT(nam_.ToString(), ky_ - 1, dot_);
                }

                GridView1.DataSource = Class.C_BaoCaoCodeDS.get_BAOCAO_CODE_DETAIL();
                GridView1.DataBind();
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // when mouse is over the row, save original color to new attribute, and change it to highlight color
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");

            // when mouse leaves the row, change the bg color to its original value  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
       
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoCao_Web.View.tabDHN
{
    public partial class tabCodeDocSo : System.Web.UI.UserControl
    {
        protected void Page_Load(object senderdouble, EventArgs e)
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
        }

        log4net.ILog log = log4net.LogManager.GetLogger("File");
        protected void btXemBangKe_Click(object senderdouble, EventArgs e)
        {
            log.Info("--------------------------------------------------------");
            string dotds = dot.Text;
            string kyds = ky.Text;
            string namds = nam.Text;
            int ky_ = int.Parse(kyds);
            int nam_ = int.Parse(namds);
            int dot_ = int.Parse(dotds);
            if ("1".Equals(bcTheo.SelectedValue + ""))
            {
                Panel1.Width = 1745;

                lbTieuDe.Text = "TỔ ĐỌC SỐ";
                Class.C_BaoCaoCodeDS.RESET_CODE_DS();
                if ("00".Equals(dotds))
                {
                    // ky hien tai
                    Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_KYNAY(nam_.ToString(), ky_);
                    // ky truoc
                    if (ky_ == 1)
                    {
                        Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC((nam_ - 1) + "", 12);
                    }
                    else
                    {
                        Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC(nam_.ToString(), ky_ - 1);
                    }

                    bcCode.DataSource = Class.C_BaoCaoCodeDS.get_BAOCAO_CODE();
                    bcCode.DataBind();
                }
                else
                {
                    // ky hien tai
                    Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_KYNAY_DOT(nam_.ToString(), ky_, dot_);
                    // ky truoc
                    if (ky_ == 1)
                    {
                        Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_DOT((nam_ - 1) + "", 12, dot_);
                    }
                    else
                    {
                        Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_DOT(nam_.ToString(), ky_ - 1, dot_);
                    }

                    bcCode.DataSource = Class.C_BaoCaoCodeDS.get_BAOCAO_CODE();
                    bcCode.DataBind();
                }
            }
            else
            {
                Panel1.Width = 1750;
                lbTieuDe.Text = "MÃ QUẬN PHƯỜNG";
                if ("00".Equals(dotds))
                {
                    // ky hien tai
                    Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_MAY_KYNAY(nam_.ToString(), ky_);
                    // ky truoc
                    if (ky_ == 1)
                    {
                        Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_MAY_KYTRUOC((nam_ - 1) + "", 12);
                    }
                    else
                    {
                        Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_MAY_KYTRUOC(nam_.ToString(), ky_ - 1);
                    }


                    bcCode.DataSource = Class.C_BaoCaoCodeDS.get_BAOCAO_CODE_MAY();
                    bcCode.DataBind();
                }
                else
                {
                    // ky hien tai
                    Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_KYNAY_MAY_DOT(nam_.ToString(), ky_, dot_);
                    // ky truoc
                    if (ky_ == 1)
                    {
                        Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_MAY_DOT((nam_ - 1) + "", 12, dot_);
                    }
                    else
                    {
                        Class.C_BaoCaoCodeDS.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_MAY_DOT(nam_.ToString(), ky_ - 1, dot_);
                    }

                    bcCode.DataSource = Class.C_BaoCaoCodeDS.get_BAOCAO_CODE_MAY();
                    bcCode.DataBind();
                }
            }


            log.Info("--------------------------------------------------------");

        }

        double KN_CODE4 = 0;
        double KN_CODE5 = 0;
        double KN_CODE6 = 0;
        double KN_CODE8 = 0;
        double KN_CODEM = 0;
        double KN_CODEN = 0;
        double KN_CODEQ = 0;
        double KN_CODEF = 0;
        double KN_CODEK = 0;
        double KT_CODE4 = 0;
        double KT_CODE5 = 0;
        double KT_CODE6 = 0;
        double KT_CODE8 = 0;
        double KT_CODEM = 0;
        double KT_CODEN = 0;
        double KT_CODEQ = 0;
        double KT_CODEF = 0;
        double KT_CODEK = 0;

        protected void bcCode_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label kn_DHN = (Label)e.Row.FindControl("KN_CODE4");
                KN_CODE4 += double.Parse(kn_DHN.Text);

                Label knSanLuong = (Label)e.Row.FindControl("KN_CODE5");
                KN_CODE5 += double.Parse(knSanLuong.Text);

                Label kt_DHN = (Label)e.Row.FindControl("KN_CODE6");
                KN_CODE6 += double.Parse(kt_DHN.Text);

                Label ktSanLuong = (Label)e.Row.FindControl("KN_CODE8");
                KN_CODE8 += double.Parse(ktSanLuong.Text);

                Label Label6 = (Label)e.Row.FindControl("KN_CODEM");
                KN_CODEM += double.Parse(Label6.Text);

                Label Label7 = (Label)e.Row.FindControl("KN_CODEN");
                KN_CODEN += double.Parse(Label7.Text);

                Label Label8 = (Label)e.Row.FindControl("KN_CODEQ");
                KN_CODEQ += double.Parse(Label8.Text);

                Label Label9 = (Label)e.Row.FindControl("KN_CODEF");
                KN_CODEF += double.Parse(Label9.Text);

                Label Label10 = (Label)e.Row.FindControl("KN_CODEK");
                KN_CODEK += double.Parse(Label10.Text);


                Label Label11 = (Label)e.Row.FindControl("KT_CODE4");
                KT_CODE4 += double.Parse(Label11.Text);

                Label Label12 = (Label)e.Row.FindControl("KT_CODE5");
                KT_CODE5 += double.Parse(Label12.Text);

                Label Label13 = (Label)e.Row.FindControl("KT_CODE6");
                KT_CODE6 += double.Parse(Label13.Text);

                Label Label14 = (Label)e.Row.FindControl("KT_CODE8");
                KT_CODE8 += double.Parse(Label14.Text);

                Label Label15 = (Label)e.Row.FindControl("KT_CODEM");
                KT_CODEM += double.Parse(Label15.Text);

                Label Label16 = (Label)e.Row.FindControl("KT_CODEN");
                KT_CODEN += double.Parse(Label16.Text);


                Label Label17 = (Label)e.Row.FindControl("KT_CODEQ");
                KT_CODEQ += double.Parse(Label17.Text);

                Label Label18 = (Label)e.Row.FindControl("KT_CODEF");
                KT_CODEF += double.Parse(Label18.Text);

                Label Label19 = (Label)e.Row.FindControl("KT_CODEK");
                KT_CODEK += double.Parse(Label19.Text);


            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label kn_DHN = (Label)e.Row.FindControl("KN_CODE4");
                kn_DHN.Text = String.Format("{0:0,0}", KN_CODE4);

                Label knSanLuong = (Label)e.Row.FindControl("KN_CODE5");
                knSanLuong.Text = String.Format("{0:0,0}", KN_CODE5);

                Label kt_DHN = (Label)e.Row.FindControl("KN_CODE6");
                kt_DHN.Text = String.Format("{0:0,0}", KN_CODE6);

                Label ktSanLuong = (Label)e.Row.FindControl("KN_CODE8");
                ktSanLuong.Text = String.Format("{0:0,0}", KN_CODE8);

                Label Label6 = (Label)e.Row.FindControl("KN_CODEM");
                Label6.Text = String.Format("{0:0,0}", KN_CODEM);

                Label Label7 = (Label)e.Row.FindControl("KN_CODEN");
                Label7.Text = String.Format("{0:0,0}", KN_CODEN);

                Label Label8 = (Label)e.Row.FindControl("KN_CODEQ");
                Label8.Text = String.Format("{0:0,0}", KN_CODEQ);

                Label Label9 = (Label)e.Row.FindControl("KN_CODEF");
                Label9.Text = String.Format("{0:0,0}", KN_CODEF);

                Label Label10 = (Label)e.Row.FindControl("KN_CODEK");
                Label10.Text = String.Format("{0:0,0}", KN_CODEK);


                Label Label11 = (Label)e.Row.FindControl("KT_CODE4");
                Label11.Text = String.Format("{0:0,0}", KT_CODE4);

                Label Label12 = (Label)e.Row.FindControl("KT_CODE5");
                Label12.Text = String.Format("{0:0,0}", KT_CODE5);

                Label Label13 = (Label)e.Row.FindControl("KT_CODE6");
                Label13.Text = String.Format("{0:0,0}", KT_CODE6);

                Label Label14 = (Label)e.Row.FindControl("KT_CODE8");
                Label14.Text = String.Format("{0:0,0}", KT_CODE8);

                Label Label15 = (Label)e.Row.FindControl("KT_CODEM");
                Label15.Text = String.Format("{0:0,0}", KT_CODEM);

                Label Label16 = (Label)e.Row.FindControl("KT_CODEN");
                Label16.Text = String.Format("{0:0,0}", KT_CODEN);


                Label Label17 = (Label)e.Row.FindControl("KT_CODEQ");
                Label17.Text = String.Format("{0:0,0}", KT_CODEQ); ;

                Label Label18 = (Label)e.Row.FindControl("KT_CODEF");
                Label18.Text = String.Format("{0:0,0}", KT_CODEF);

                Label Label19 = (Label)e.Row.FindControl("KT_CODEK");
                Label19.Text = String.Format("{0:0,0}", KT_CODEK);

            }
            // when mouse is over the row, save original color to new attribute, and change it to highlight color
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");

            // when mouse leaves the row, change the bg color to its original value  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
    }
}
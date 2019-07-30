using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoCao_Web.View.tabSanLuong
{
    public partial class tbPhanTichDMA : System.Web.UI.UserControl
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
            string kyds = ky.Text;
            string namds = nam.Text;
            int ky_ = int.Parse(kyds);
            int nam_ = int.Parse(namds);
            Session["ky"] = ky_;
            Session["nam"] = nam_;

              Class.C_PhanTichDMA.CAPNHAT_DHN_HH();
              Class.C_PhanTichDMA.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY(namds, ky_);
              Class.C_PhanTichDMA.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC(nam_, ky_);
              Class.C_PhanTichDMA.CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC(nam_, ky_);
              Class.C_PhanTichDMA.CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM();

            sanLuongTo.DataSource =   Class.C_PhanTichDMA.get_BAOCAO_SANLUONG();

            sanLuongTo.DataBind();



            log.Info("--------------------------------------------------------");
        }
        double KN_DHN = 0;
        double KN_SANLUONG = 0;
        double KT_DHN = 0;
        double KT_SANLUONG = 0;
        double TANGIAM_DHN = 0;
        double TANGIAM_SANLUONG = 0;
        double NT_DHN = 0;
        double NT_SANLUONG = 0;
        double NT_TANGIAM_DHN = 0;
        double NT_TANGIAM_SANLUONG = 0;
        protected void sanLuongTo_RowDataBound(object senderdouble, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label kn_DHN = (Label)e.Row.FindControl("kn_DHN");
                KN_DHN += double.Parse(kn_DHN.Text);

                Label knSanLuong = (Label)e.Row.FindControl("knSanLuong");
                KN_SANLUONG += double.Parse(knSanLuong.Text);

                Label kt_DHN = (Label)e.Row.FindControl("kt_DHN");
                KT_DHN += double.Parse(kt_DHN.Text);

                Label ktSanLuong = (Label)e.Row.FindControl("ktSanLuong");
                KT_SANLUONG += double.Parse(ktSanLuong.Text);

                Label Label6 = (Label)e.Row.FindControl("Label6");
                TANGIAM_DHN += double.Parse(Label6.Text);

                Image dhn_up = (Image)e.Row.FindControl("dhn_change");
                if (double.Parse(Label6.Text) > 0)
                {
                    dhn_up.ImageUrl = "~/Image/up.png";
                }
                else if (double.Parse(Label6.Text) < 0)
                {
                    dhn_up.ImageUrl = "~/Image/down.png";
                }
                else
                {
                    dhn_up.ImageUrl = "~/Image/nochange.png";
                }

                Image sl_change = (Image)e.Row.FindControl("sl_change");

                Label Label7 = (Label)e.Row.FindControl("Label7");
                TANGIAM_SANLUONG += double.Parse(Label7.Text);
                if (double.Parse(Label7.Text) > 0)
                {
                    sl_change.ImageUrl = "~/Image/up.png";
                }
                else if (double.Parse(Label7.Text) < 0)
                {
                    sl_change.ImageUrl = "~/Image/down.png";
                }
                else
                {
                    sl_change.ImageUrl = "~/Image/nochange.png";
                }

                Label Label8 = (Label)e.Row.FindControl("Label8");
                NT_DHN += double.Parse(Label8.Text);

                Label Label9 = (Label)e.Row.FindControl("Label9");
                NT_SANLUONG += double.Parse(Label9.Text);

                Label Label10 = (Label)e.Row.FindControl("Label10");
                NT_TANGIAM_DHN += double.Parse(Label10.Text);
                Image dhn_nt = (Image)e.Row.FindControl("dhn_nt");
                if (double.Parse(Label10.Text) > 0)
                {
                    dhn_nt.ImageUrl = "~/Image/up.png";
                }
                else if (double.Parse(Label10.Text) < 0)
                {
                    dhn_nt.ImageUrl = "~/Image/down.png";
                }
                else
                {
                    dhn_nt.ImageUrl = "~/Image/nochange.png";
                }

                Label Label11 = (Label)e.Row.FindControl("Label11");
                NT_TANGIAM_SANLUONG += double.Parse(Label11.Text);

                Image sl_nt = (Image)e.Row.FindControl("sl_nt");
                if (double.Parse(Label11.Text) > 0)
                {
                    sl_nt.ImageUrl = "~/Image/up.png";
                }
                else if (double.Parse(Label11.Text) < 0)
                {
                    sl_nt.ImageUrl = "~/Image/down.png";
                }
                else
                {
                    sl_nt.ImageUrl = "~/Image/nochange.png";
                }

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label kn_DHN = (Label)e.Row.FindControl("kn_DHN");
                kn_DHN.Text = String.Format("{0:0,0}", KN_DHN); ;

                Label knSanLuong = (Label)e.Row.FindControl("knSanLuong");
                knSanLuong.Text = String.Format("{0:0,0}", KN_SANLUONG); ;

                Label kt_DHN = (Label)e.Row.FindControl("kt_DHN");
                kt_DHN.Text = String.Format("{0:0,0}", KT_DHN); ;

                Label ktSanLuong = (Label)e.Row.FindControl("ktSanLuong");
                ktSanLuong.Text = String.Format("{0:0,0}", KT_SANLUONG); ;

                Label Label6 = (Label)e.Row.FindControl("Label6");
                Label6.Text = String.Format("{0:0,0}", TANGIAM_DHN); ;
                Image dhn_change_sum = (Image)e.Row.FindControl("dhn_change_sum");
                if (double.Parse(Label6.Text) > 0)
                {
                    dhn_change_sum.ImageUrl = "~/Image/up.png";
                }
                else if (double.Parse(Label6.Text) < 0)
                {
                    dhn_change_sum.ImageUrl = "~/Image/down.png";
                }
                else
                {
                    dhn_change_sum.ImageUrl = "~/Image/nochange.png";
                }


                Label Label7 = (Label)e.Row.FindControl("Label7");
                Label7.Text = String.Format("{0:0,0}", TANGIAM_SANLUONG); ;
                Image sl_change_sum = (Image)e.Row.FindControl("sl_change_sum");
                if (double.Parse(Label7.Text) > 0)
                {
                    sl_change_sum.ImageUrl = "~/Image/up.png";
                }
                else if (double.Parse(Label7.Text) < 0)
                {
                    sl_change_sum.ImageUrl = "~/Image/down.png";
                }
                else
                {
                    sl_change_sum.ImageUrl = "~/Image/nochange.png";
                }

                Label Label8 = (Label)e.Row.FindControl("Label8");
                Label8.Text = String.Format("{0:0,0}", NT_DHN); ;

                Label Label9 = (Label)e.Row.FindControl("Label9");
                Label9.Text = String.Format("{0:0,0}", NT_SANLUONG); ;

                Label Label10 = (Label)e.Row.FindControl("Label10");
                Label10.Text = String.Format("{0:0,0}", NT_TANGIAM_DHN);
                Image nt_dhn_change_sum = (Image)e.Row.FindControl("nt_dhn_change_sum");
                if (double.Parse(Label10.Text) > 0)
                {
                    nt_dhn_change_sum.ImageUrl = "~/Image/up.png";
                }
                else if (double.Parse(Label10.Text) < 0)
                {
                    nt_dhn_change_sum.ImageUrl = "~/Image/down.png";
                }
                else
                {
                    nt_dhn_change_sum.ImageUrl = "~/Image/nochange.png";
                }


                Label Label11 = (Label)e.Row.FindControl("Label11");
                Label11.Text = String.Format("{0:0,0}", NT_TANGIAM_SANLUONG);

                Image nt_sl_change_sum = (Image)e.Row.FindControl("nt_sl_change_sum");
                if (double.Parse(Label11.Text) > 0)
                {
                    nt_sl_change_sum.ImageUrl = "~/Image/up.png";
                }
                else if (double.Parse(Label11.Text) < 0)
                {
                    nt_sl_change_sum.ImageUrl = "~/Image/down.png";
                }
                else
                {
                    nt_sl_change_sum.ImageUrl = "~/Image/nochange.png";
                }

            }
            // when mouse is over the row, save original color to new attribute, and change it to highlight color
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");

            // when mouse leaves the row, change the bg color to its original value  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }

       
    }
}
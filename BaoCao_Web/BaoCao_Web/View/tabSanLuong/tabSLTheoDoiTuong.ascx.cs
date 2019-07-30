using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoCao_Web.View.tabSanLuong
{
    public partial class tabSLTheoDoiTuong : System.Web.UI.UserControl
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
                Session["LoaiDT"] = "TỔ ĐỌC SỐ";
                Session["treport"] = "PHÂN TÍCH SẢN LƯỢNG ĐHN THEO TỔ ĐỌC SỐ  KỲ " + kyds + "/" + namds;
                Panel1.Width = 1195;

                lbTieuDe.Text = "TỔ ĐỌC SỐ";
                Class.C_BaoCaoSanLuong.RESET_BAOCAO_SANLUONG();
                if ("00".Equals(dotds))
                {
                    // ky hien tai
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY(nam_.ToString(), ky_);
                   
                    // ky truoc
                    if (ky_ == 1)
                    {
                        Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC((nam_ - 1) + "", 12);

                    }
                    else
                    {
                        Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC(nam_.ToString(), ky_ - 1);
                    }

                    // nam truoc
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC((nam_ - 1) + "", ky_);

                    // CAP NHAT SO LIEU 
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM();
                    // so lieu
                    sanLuongTo.DataSource = Class.C_BaoCaoSanLuong.get_BAOCAO_SANLUONG();
                    sanLuongTo.DataBind();
                }
                else
                {
                    // ky hien tai
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_DOT(nam_.ToString(), ky_, dot_);
                    // ky truoc
                    if (ky_ == 1)
                    {
                        Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_DOT((nam_ - 1) + "", 12, dot_);
                    }
                    else
                    {
                        Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_DOT(nam_.ToString(), ky_ - 1, dot_);
                    }

                    // nam truoc
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_DOT((nam_ - 1) + "", ky_, dot_);

                    // CAP NHAT SO LIEU 
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM();
                    sanLuongTo.DataSource = Class.C_BaoCaoSanLuong.get_BAOCAO_SANLUONG();
                    sanLuongTo.DataBind();
                }
            }
            else  if ("2".Equals(bcTheo.SelectedValue + ""))
            {
                Session["LoaiDT"] = "QUẬN PHƯỜNG";
                Panel1.Width = 1213;
                lbTieuDe.Text = "MÃ QUẬN PHƯỜNG";
                Session["treport"] = "PHÂN TÍCH SẢN LƯỢNG ĐHN THEO " + Session["LoaiDT"] + " KỲ " + kyds + "/" + namds;
                if ("00".Equals(dotds))
                {
                    // ky hien tai
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_MAY(nam_.ToString(), ky_);
                    // ky truoc
                    if (ky_ == 1)
                    {
                        Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_MAY((nam_ - 1) + "", 12);
                    }
                    else
                    {
                        Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_MAY(nam_.ToString(), ky_ - 1);
                    }

                    // nam truoc
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_MAY((nam_ - 1) + "", ky_);

                    // CAP NHAT SO LIEU 
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM_MAY();
                    // so lieu
                    sanLuongTo.DataSource = Class.C_BaoCaoSanLuong.get_BAOCAO_SANLUONG_MAY();
                    sanLuongTo.DataBind();
                }
                else
                {
                    // ky hien tai
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_MAY_DOT(nam_.ToString(), ky_, dot_);
                    // ky truoc
                    if (ky_ == 1)
                    {
                        Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_MAY_DOT((nam_ - 1) + "", 12, dot_);
                    }
                    else
                    {
                        Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_MAY_DOT(nam_.ToString(), ky_ - 1, dot_);
                    }

                    // nam truoc
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_MAY_DOT((nam_ - 1) + "", ky_, dot_);

                    // CAP NHAT SO LIEU 
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM_MAY();
                    sanLuongTo.DataSource = Class.C_BaoCaoSanLuong.get_BAOCAO_SANLUONG_MAY();
                    sanLuongTo.DataBind();
                }
            }

            else if ("3".Equals(bcTheo.SelectedValue + ""))
            {
                Panel1.Width = 1213;
                lbTieuDe.Text = " GIÁ BIỂU ";
                Session["LoaiDT"] = "GIÁ BIỂU";
                Session["treport"] = "PHÂN TÍCH SẢN LƯỢNG ĐHN THEO " + Session["LoaiDT"] + " KỲ " + kyds + "/" + namds;
                if ("00".Equals(dotds))
                {
                    // ky hien tai
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_GB(nam_.ToString(), ky_);
                    lbKyNay.Text ="("+ Class.LinQConnectionTT.ReturnResult("SELECT MAX(DOT)  FROM HOADON kh WHERE kh.NAM=" + nam_ + " AND kh.KY=" + ky_) + " đợt )";
                    // ky truoc
                    if (ky_ == 1)
                    {
                        Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_GB((nam_ - 1) + "", 12);
                        lbKyTruoc.Text = "(" + Class.LinQConnectionTT.ReturnResult("SELECT MAX(DOT)  FROM HOADON kh WHERE kh.NAM=" + (nam_ - 1) + " AND kh.KY=12") + " đợt )";
                    }
                    else
                    {
                        Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_GB(nam_.ToString(), ky_ - 1);
                        lbKyTruoc.Text = "(" + Class.LinQConnectionTT.ReturnResult("SELECT MAX(DOT)  FROM HOADON kh WHERE kh.NAM=" + nam_ + " AND kh.KY=" + (ky_ - 1)) + " đợt )";
                    }

                    // nam truoc
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_GB((nam_ - 1) + "", ky_);

                    // CAP NHAT SO LIEU 
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM_GB();
                    // so lieu
                    sanLuongTo.DataSource = Class.C_BaoCaoSanLuong.get_BAOCAO_SANLUONG_GB();
                    sanLuongTo.DataBind();
                }
                else
                {
                    // ky hien tai
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_GB_DOT(nam_.ToString(), ky_, dot_);

                    // ky truoc
                    if (ky_ == 1)
                    {
                        Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_GB_DOT((nam_ - 1) + "", 12, dot_);
                    }
                    else
                    {
                        Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_GB_DOT(nam_.ToString(), ky_ - 1, dot_);
                    }

                    // nam truoc
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_GB_DOT((nam_ - 1) + "", ky_, dot_);

                    // CAP NHAT SO LIEU 
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM_GB();
                    sanLuongTo.DataSource = Class.C_BaoCaoSanLuong.get_BAOCAO_SANLUONG_GB();
                    sanLuongTo.DataBind();
                }
            }

            else if ("4".Equals(bcTheo.SelectedValue + ""))
            {
                Session["LoaiDT"] = "CỞ ĐHN";
                Session["treport"] = "PHÂN TÍCH SẢN LƯỢNG ĐHN THEO " + Session["LoaiDT"] + " KỲ " + kyds + "/" + namds;
                Panel1.Width = 1213;
                lbTieuDe.Text = " CỞ ĐHN ";
                if ("00".Equals(dotds))
                {
                    // ky hien tai
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_CODH(nam_.ToString(), ky_);
                    lbKyNay.Text = "(" + Class.LinQConnectionTT.ReturnResult("SELECT MAX(DOT)  FROM HOADON kh WHERE kh.NAM=" + nam_ + " AND kh.KY=" + ky_) + " đợt )";
                    // ky truoc
                    if (ky_ == 1)
                    {
                        Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_CODH((nam_ - 1) + "", 12);
                        lbKyTruoc.Text = "(" + Class.LinQConnectionTT.ReturnResult("SELECT MAX(DOT)  FROM HOADON kh WHERE kh.NAM=" + (nam_ - 1) + " AND kh.KY=12") + " đợt )";
                    }
                    else
                    {
                        Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_CODH(nam_.ToString(), ky_ - 1);
                        lbKyTruoc.Text = "(" + Class.LinQConnectionTT.ReturnResult("SELECT MAX(DOT)  FROM HOADON kh WHERE kh.NAM=" + nam_ + " AND kh.KY=" + (ky_ - 1)) + " đợt )";
                    }

                    // nam truoc
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_CODH((nam_ - 1) + "", ky_);

                    // CAP NHAT SO LIEU 
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM_CODH();
                    // so lieu
                    sanLuongTo.DataSource = Class.C_BaoCaoSanLuong.get_BAOCAO_SANLUONG_CODH();
                    sanLuongTo.DataBind();
                }
                else
                {
                    // ky hien tai
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_CODH_DOT(nam_.ToString(), ky_, dot_);
                    // ky truoc
                    if (ky_ == 1)
                    {
                        Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_CODH_DOT((nam_ - 1) + "", 12, dot_);
                    }
                    else
                    {
                        Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_CODH_DOT(nam_.ToString(), ky_ - 1, dot_);
                    }

                    // nam truoc
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_CODH_DOT((nam_ - 1) + "", ky_, dot_);

                    // CAP NHAT SO LIEU 
                    Class.C_BaoCaoSanLuong.CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM_GB();
                    sanLuongTo.DataSource = Class.C_BaoCaoSanLuong.get_BAOCAO_SANLUONG_GB();
                    sanLuongTo.DataBind();
                }
            }

            
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
                if (double.Parse(Label6.Text) > 0) {
                    dhn_up.ImageUrl = "~/Image/up.png";
                }
                else if (double.Parse(Label6.Text) < 0)
                {
                    dhn_up.ImageUrl = "~/Image/down.png";
                }
                else {
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

        protected void bcTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ("1".Equals(bcTheo.SelectedValue + ""))
            {
                lbTieuDe.Text = "TỔ ĐỌC SỐ";
            }
            else if ("2".Equals(bcTheo.SelectedValue + ""))
            {
                lbTieuDe.Text = "MÃ QUẬN PHƯỜNG";
            }
            else if ("3".Equals(bcTheo.SelectedValue + ""))
            {
                lbTieuDe.Text = "GIÁ BIỂU ";
            }
            else if ("4".Equals(bcTheo.SelectedValue + ""))
            {
                lbTieuDe.Text = "CỞ ĐHN";
            }
        }

        protected void btIn_Click(object sender, EventArgs e)
        {
            try
            {

                string sql = "SELECT * FROM W_BAOCAO_SANLUONG ";
                Session["SQL"] = sql;
                Response.Redirect(@"Print.aspx?page=bcSL");
            }
            catch (Exception)
            {

            }
        }
    }
}
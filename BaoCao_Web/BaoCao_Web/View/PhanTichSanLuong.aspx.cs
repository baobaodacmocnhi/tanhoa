using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoCao_Web.View
{
    public partial class PhanTichSanLuong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if ("PTTHAY".Equals(Request.Params["type"] + ""))
            {
                this.Panel1.Controls.Clear();
                Control control = LoadControl("tabSanLuong/tabPhanTichThay.ascx");
                this.Panel1.Controls.Add(control);
                title.Text = "PHÂN TÍCH SẢN LƯỢNG THAY ĐHN";
            }
            else if ("PTDOITHUONG".Equals(Request.Params["type"] + ""))
            {
                this.Panel1.Controls.Clear();
                Control control = LoadControl("tabSanLuong/tabSLTheoDoiTuong.ascx");
                this.Panel1.Controls.Add(control);
                title.Text = "PHÂN TÍCH ĐỐI TƯỢNG SỬ DỤNG NƯỚC";
            }
            else if ("PTDMA".Equals(Request.Params["type"] + ""))
            {
                this.Panel1.Controls.Clear();
                Control control = LoadControl("tabSanLuong/tbPhanTichDMA.ascx");
                this.Panel1.Controls.Add(control);
                title.Text = "PHÂN TÍCH SẢN LƯỢNG DMA ";
            }
        }
    }
}
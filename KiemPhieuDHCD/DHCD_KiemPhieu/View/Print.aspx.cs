using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DHCD_KiemPhieu.DataBase;
using System.IO;

namespace DHCD_KiemPhieu.View
{
    public partial class Print : System.Web.UI.Page
    {
        log4net.ILog log = log4net.LogManager.GetLogger("File");
        protected void Page_Load(object sender, EventArgs e)
        {

            string sql = "";
            string title = "";

            if ("BQ".Equals(Request.Params["page"] + ""))
            {
                sql = Session["SQL"] + "";
                CrystalReportSource1.Report.FileName = "inKQBieuQuyet.rpt";

                CrystalReportSource1.ReportDocument.SetDataSource((DataTable)Session["TABLE"]);

                CrystalReportSource1.ReportDocument.SetParameterValue("TC", Session["TC"] + "");
                CrystalReportSource1.ReportDocument.SetParameterValue("TS", Session["TS"] + "");
                CrystalReportSource1.ReportDocument.SetParameterValue("TR", Session["TR"] + "");
                CrystalReportSource1.ReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "KET_QUA_BIEU_QUYET");

            } if ("IN".Equals(Request.Params["page"] + ""))
            {
                CrystalReportSource1.Report.FileName = "inTheBieuQuyet_N.rpt";
                CrystalReportSource1.ReportDocument.SetDataSource(Img());
                CrystalReportSource1.ReportDocument.SetParameterValue("TT", Session["TT"] + "");

                CrystalReportSource1.ReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "THE_BIEU_QUYET");
            }
            if ("BC".Equals(Request.Params["page"] + ""))
            {
                CrystalReportSource1.Report.FileName = "inTheBauCuBKS_3.rpt";
                CrystalReportSource1.ReportDocument.SetDataSource(Img());
                CrystalReportSource1.ReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "THE_BIEU_QUYET");
            }
            if ("HD".Equals(Request.Params["page"] + ""))
            {
                CrystalReportSource1.Report.FileName = "inTheBieuQuyetHDQT_1.rpt";
                CrystalReportSource1.ReportDocument.SetDataSource(Img());
                CrystalReportSource1.ReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "THE_BIEU_QUYET");
            }
            if ("TDT".Equals(Request.Params["page"] + ""))
            {
                sql = Session["SQL"] + "";
                string sql2 = Session["SQL2"] + "";
                TanHoaDataContext db = new TanHoaDataContext();

                DataSet ds = new DataSet();
                if (db.Connection.State == ConnectionState.Open)
                {
                    db.Connection.Close();
                }
                db.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(ds, "KQBAUCU");

                adapter = new SqlDataAdapter(sql2, db.Connection.ConnectionString);
                adapter.Fill(ds, "KQTRUNGCU");

                if ("1".Equals(Session["LoaiBaoCao"].ToString()))
                {
                    CrystalReportSource1.Report.FileName = "inKQBauCu_TDT.rpt";
                    CrystalReportSource1.ReportDocument.SetDataSource(ds);
                    CrystalReportSource1.ReportDocument.SetParameterValue("TV", Session["TV"] + "");
                    CrystalReportSource1.ReportDocument.SetParameterValue("HL", Session["HL"] + "");
                    CrystalReportSource1.ReportDocument.SetParameterValue("KHL", Session["KHL"] + "");
                    CrystalReportSource1.ReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "THE_BIEU_QUYET");
                }
                else
                    if ("2".Equals(Session["LoaiBaoCao"].ToString()))
                    {
                        CrystalReportSource1.Report.FileName = "inKQBauCu_BTT.rpt";
                        CrystalReportSource1.ReportDocument.SetDataSource(ds);
                        CrystalReportSource1.ReportDocument.SetParameterValue("TV", Session["TV"] + "");
                        CrystalReportSource1.ReportDocument.SetParameterValue("HL", Session["HL"] + "");
                        CrystalReportSource1.ReportDocument.SetParameterValue("KHL", Session["KHL"] + "");
                        CrystalReportSource1.ReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "THE_BIEU_QUYET");
                    }
            }
            if ("CongDoan".Equals(Request.Params["page"] + ""))
            {
                sql = Session["SQL"] + "";
                string sql2 = Session["SQL2"] + "";
                TanHoaDataContext db = new TanHoaDataContext();

                DataSet ds = new DataSet();
                if (db.Connection.State == ConnectionState.Open)
                {
                    db.Connection.Close();
                }
                db.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(ds, "KQBAUCU");

                adapter = new SqlDataAdapter(sql2, db.Connection.ConnectionString);
                adapter.Fill(ds, "KQTRUNGCU");

                if ("1".Equals(Session["LoaiBaoCao"].ToString()))
                {
                    CrystalReportSource1.Report.FileName = "inKQBauCu_CongDoan.rpt";
                    CrystalReportSource1.ReportDocument.SetDataSource(ds);
                    CrystalReportSource1.ReportDocument.SetParameterValue("TV", Session["TV"] + "");
                    CrystalReportSource1.ReportDocument.SetParameterValue("HL", Session["HL"] + "");
                    CrystalReportSource1.ReportDocument.SetParameterValue("KHL", Session["KHL"] + "");
                    CrystalReportSource1.ReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "THE_BIEU_QUYET");
                }
            }
        }


        private void LoadImage(DataRow objDataRow, string strImageField, string FilePath)
        {
            try
            {
                FileStream fs = new FileStream(FilePath,
                           System.IO.FileMode.Open, System.IO.FileAccess.Read);
                byte[] Image = new byte[fs.Length];
                fs.Read(Image, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                objDataRow[strImageField] = Image;
            }
            catch (Exception)
            {

            }
        }
        public DataTable Img()
        {
            DataTable tb = Class.LinQConnection.getDataTable("SELECT STT, STTCD, MACD, TENCD, CMND, NGAYCAP, NOICAP, DIACHI, CDGD, PHONGTOA, TONGCD, ImgPath, Image FROM DSCODONG  ");

            for (int index = 0; index < tb.Rows.Count; index++)
            {
                if (tb.Rows[index]["STT"].ToString() != "")
                {
                    //string s = this.Server.MapPath(tb.Rows[index]["ImgPath"].ToString());
                    string s = this.Server.MapPath("./mavach/mavach (" + tb.Rows[index]["STT"].ToString() + ").jpg");

                    if (File.Exists(s))
                    {
                        LoadImage(tb.Rows[index], "Image", s);
                    }
                    else
                    {
                        LoadImage(tb.Rows[index], "Image",
                                  "DefaultPicturePath");
                    }
                }
                else
                {
                    LoadImage(tb.Rows[index], "Image",
                              "DefaultPicturePath");
                }
            }
            return tb;

        }
    }
}
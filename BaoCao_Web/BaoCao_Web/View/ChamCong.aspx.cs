using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Globalization;
using ExcelCOM = Microsoft.Office.Interop.Excel;
using System.IO;
using BaoCao_Web.DataBase;

namespace BaoCao_Web.View
{
    public partial class ChamCong : System.Web.UI.Page
    {
        string thang__ = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["chamconglogin"] == null)
            {
                Session["linked"] = "ChamCong.aspx?page=KD";
                Response.Redirect("ChamCongLogin.aspx");
            }
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            if (Session["MaPhong"] != null)
            {
                DataTable dt = null;
                if ((int)Session["MaPhong"] == 1)
                {
                    dt = Class.LinQConnection.getDataTable("SELECT * FROM TCHC_PHONGBAN ORDER BY ID ASC ");
                }
                else
                {
                    dt = Class.LinQConnection.getDataTable("SELECT * FROM TCHC_PHONGBAN where ID=" + Session["MaPhong"] + " ORDER BY ID ASC ");
                }
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "TENPHONG";
                DropDownList1.DataValueField = "ID";
                DropDownList1.DataBind();
            }
        }

        public void AddTableTre(DataTable tableTre, string manv, string tennv, string phongban, string ngay, string thu, string giovao, string giora, string tre, string som, string ghichu)
        {
            if (tableTre != null)
            {
                DataRow row = tableTre.NewRow();
                row["MANV"] = manv;
                row["TENNV"] = tennv;
                row["PHONGBAN"] = phongban;
                row["NGAY"] = ngay + "/" + DateTime.Now.Year.ToString();
                row["THU"] = thu;
                row["GIOVAO"] = giovao;
                row["TRE"] = tre;
                row["GIORA"] = giora;
                row["SOM"] = som;
                row["GHICHU"] = ghichu;

                tableTre.Rows.Add(row);
            }

        }

        TCHC_GIAYXINVE _xinve = null;
        List<TCHC_GIAYXINVE> _lstXinVe = null;
        TanHoaDataContext db = new TanHoaDataContext();
        int sophutTre = 0;
        int sophuSom = 0;
        string type = "";
        string noidung = "";

        int getThongTin(string manv, DateTime ngay)
        {
            //di ngoai
            var query = from q in db.TCHC_GIAYXINVEs where q.MANV == manv && q.LOAIGP == "VH" select q;
            if (query.ToList().Count > 0)
            {
                _xinve = query.ToList()[0];
                type = "DN";
                noidung = "DI NGOAI";
                return 1;
            }

            /* Cong Tác */
            //xin tu ngay den ngay
            query = from q in db.TCHC_GIAYXINVEs where q.MANV == manv && q.LOAIGP == "CT" && (q.TUNGAY.Value.Date == ngay.Date || (ngay.Date >= q.TUNGAY.Value.Date && ngay.Date <= q.DENNGAY.Value.Date)) orderby q.CREATEDATE descending select q;
            if (query.ToList().Count > 0)
            {
                _xinve = query.ToList()[0];
                _lstXinVe = query.ToList();
                type = "TH";
                noidung = "CONG TAC";
                return 5;
            }

            //xin trong ngay
            query = from q in db.TCHC_GIAYXINVEs where q.MANV == manv && q.LOAIGP == "TN" && q.TUNGAY.Value.Date == ngay.Date orderby q.CREATEDATE descending select q;
            if (query.ToList().Count > 0)
            {
                _xinve = query.ToList()[0];
                _lstXinVe = query.ToList();
                type = "TN";
                noidung = "XIN VE SOM";
                return 3;
            }

            //xin tu ngay den ngay
            query = from q in db.TCHC_GIAYXINVEs where q.MANV == manv && q.LOAIGP == "TH" && ngay.Date >= q.TUNGAY.Value.Date && ngay.Date <= q.DENNGAY.Value.Date orderby q.CREATEDATE descending select q;
            if (query.ToList().Count > 0)
            {
                _xinve = query.ToList()[0];
                _lstXinVe = query.ToList();
                type = "TH";
                noidung = "XIN VE SOM";
                return 4;
            }

            //khong thoi han
            query = from q in db.TCHC_GIAYXINVEs where q.MANV == manv && q.LOAIGP == "KT" orderby q.CREATEDATE descending select q;
            if (query.ToList().Count > 0)
            {
                _xinve = query.ToList()[0];
                type = "KT";
                noidung = "XIN VE SOM";
                return 2;
            }

            return 0;
        }

        bool checkExist_XinTrongNgay(string manv, DateTime ngay)
        {
         var query = from q in db.TCHC_GIAYXINVEs where q.MANV == manv && q.LOAIGP == "TN" && q.TUNGAY.Value.Date == ngay.Date orderby q.CREATEDATE descending select q;
            if (query.ToList().Count > 0)
            {
                return true;
            }
            else
                return false;
        }

        public int parseInt(object o)
        {
            try
            {
                return int.Parse(o.ToString());
            }
            catch (Exception)
            {
            }
            return 0;
        }

        public void LoadData()
        {
            int k = 0;
            string MaNV = "", TenNV = "";
            try
            {
                DataTable tableTre = new DataTable();
                tableTre.Columns.Add("MANV", typeof(String));
                tableTre.Columns.Add("TENNV", typeof(String));
                tableTre.Columns.Add("PHONGBAN", typeof(String));
                tableTre.Columns.Add("NGAY", typeof(String));
                tableTre.Columns.Add("THU", typeof(String));
                tableTre.Columns.Add("GIOVAO", typeof(String));
                tableTre.Columns.Add("TRE", typeof(String));
                tableTre.Columns.Add("GIORA", typeof(String));
                tableTre.Columns.Add("SOM", typeof(String));
                tableTre.Columns.Add("GHICHU", typeof(String));

                string connectionString = ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFile"].ConnectionString;
                string sql = " SELECT info.UserFullCode, info.UserFullName, dt.Dept";
                sql += " FROM UserInfo info,Dept dt WHERE info.IDD=dt.IDD ";
                if (!"1".Equals(DropDownList1.SelectedValue))
                {
                    sql += " AND info.IDD=" + DropDownList1.SelectedValue;
                }
                if (ckNV.Checked)
                {
                    sql += " AND info.UserLoaiNV='VP' ";
                }
                if (ckCN.Checked)
                {
                    sql += " AND info.UserLoaiNV='CN' ";
                }
                sql += " ORDER BY info.IDD ASC, info.UserFullCode ASC ";
                string dateformat = ConfigurationManager.AppSettings["dateformat"].ToString();
                DataTable workTable = new DataTable("NHANSU");
                DataColumn workCol = workTable.Columns.Add("MANV", typeof(String));
                workTable.Columns.Add("TENNV", typeof(String));
                workTable.Columns.Add("SỐ PHÚT", typeof(String));
                DateTime tNgay = DateTime.ParseExact(tungay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime dNgay = DateTime.ParseExact(denngay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                thang__ = dNgay.Month.ToString();
                TimeSpan Time = dNgay - tNgay;
                int TongSoNgay = Time.Days + 4;
                Panel2.Width = TongSoNgay * 150;
                string[] arrTitle = new string[TongSoNgay];
                int numTitle = 0;
                arrTitle[numTitle++] = "NGÀY CÔNG";
                arrTitle[numTitle++] = "TRỂ";
                arrTitle[numTitle++] = "SỐ PHÚT";
                int flag = 2;
                while (tNgay <= dNgay)
                {
                    workTable.Columns.Add(Class.Format.NgayVNVN(tNgay), typeof(String));
                    arrTitle[numTitle++] = Class.Format.NgayVNVN(tNgay);
                    workTable.Columns.Add(Class.Format.NgayVNVN(tNgay) + "TRE", typeof(String));
                    workTable.Columns.Add(Class.Format.NgayVNVN(tNgay) + "RA", typeof(String));
                    workTable.Columns.Add(Class.Format.NgayVNVN(tNgay) + "SOM", typeof(String));
                    workTable.Columns.Add(Class.Format.NgayVNVN(tNgay) + "TYPE", typeof(String));
                    tNgay = tNgay.AddDays(1.0);
                    flag = flag + 3;
                }
                workTable.Columns.Add("NGÀY CÔNG", typeof(String));
                workTable.Columns.Add("TRỂ", typeof(String));
                flag = flag + 2;

                DataTable tb = Class.OledbConnection.getDataTable(connectionString, sql);
                //if(tb==null)
                //    ScriptManager.RegisterStartupScript(this, GetType(), "alertmsg", "alert('" + connectionString + "');", true);
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (i == 4)
                    {

                    }
                     k = i;
                     MaNV = tb.Rows[i]["UserFullCode"].ToString();
                     TenNV= tb.Rows[i]["UserFullName"].ToString();
                    int tongphuttre = 0;
                    int tongngaycong = 0;
                    int tongtre = 0;
                    string manv = tb.Rows[i]["UserFullCode"].ToString();
                    string tennv = tb.Rows[i]["UserFullName"].ToString();
                    string phongban = tb.Rows[i]["Dept"].ToString();
                    string ngay = "";
                    string thu = "";
                    string giovao = "";
                    string giora = "";
                    string tre = "";
                    string som = "";
                    DataRow row = workTable.NewRow();
                    row["MANV"] = manv;
                    row["TENNV"] = tennv;
                    tNgay = DateTime.ParseExact(tungay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    int phutSomThem = 0;
                    int phutTreThem = 0;
                    int flagLoai = getThongTin(manv, tNgay);
                    if (flagLoai == 2)
                    {
                        flagLoai = 2;
                        phutTreThem = parseInt(_xinve.PHUTVAO);
                        phutSomThem = parseInt(_xinve.PHUTRA);
                    }
                    while (tNgay <= dNgay)
                    {
                        //if("00245".Equals(manv))
                        //{
                        //   tre = "";
                        //}
                        tre = "";
                        som = "";
                        string sql_ck = " SELECT ior.TimeStr FROM CheckInOut AS ior WHERE (((ior.UserFullCode)='" + manv + "') AND ((CDate([TimeDate]))='" + tNgay.ToShortDateString() + "')) ORDER BY TimeStr ASC";
                        DataTable t1 = Class.OledbConnection.getDataTable(connectionString, sql_ck);
                        int flag_ = t1.Rows.Count;
                        bool boolTre = false;
                        if (flag_ > 0)
                        {
                            if (flagLoai == 1)
                            {
                                string gVao = t1.Rows[0]["TimeStr"].ToString().Replace(" ", "");
                                if (!"".Equals(gVao))
                                {
                                    string tmp = t1.Rows[0]["TimeStr"].ToString();
                                    try
                                    {
                                        ngay = Class.Format.NgayVNVN(tNgay);
                                        //   DateTime tm1 = DateTime.ParseExact(t1.Rows[0]["TimeStr"].ToString(), dateformat, CultureInfo.CreateSpecificCulture("en-US"));
                                        DateTime tm1 = DateTime.Parse(t1.Rows[0]["TimeStr"].ToString());
                                        row[Class.Format.NgayVNVN(tNgay)] = tm1.ToString("H:mm");
                                        tongngaycong++;
                                        thu = tm1.Date.DayOfWeek.ToString();
                                        giovao = tm1.ToString("H:mm");
                                    }
                                    catch (Exception)
                                    {
                                        row[Class.Format.NgayVNVN(tNgay)] = "-";
                                    }
                                }
                                else
                                {
                                    row[Class.Format.NgayVNVN(tNgay)] = "-";
                                }

                                // Gi? Ra
                                string gRa = t1.Rows[flag_ - 1]["TimeStr"].ToString().Replace(" ", "");

                                try
                                {
                                    //      DateTime tm2 = DateTime.ParseExact(t1.Rows[flag_ - 1]["TimeStr"].ToString(), dateformat, CultureInfo.CreateSpecificCulture("en-US"));
                                    DateTime tm2 = DateTime.Parse(t1.Rows[flag_ - 1]["TimeStr"].ToString());
                                    row[Class.Format.NgayVNVN(tNgay) + "RA"] = tm2.ToString("HH:mm");
                                    giora = tm2.ToString("HH:mm");
                                }
                                catch (Exception)
                                {
                                    row[Class.Format.NgayVNVN(tNgay) + "RA"] = "-";
                                }
                            }
                            else if (flagLoai != 2)
                            {
                                //if ("00120".Equals(manv))
                                //{
                                //    flagLoai = getThongTin(manv, tNgay);
                                //}
                                type = "";
                                flagLoai = getThongTin(manv, tNgay);
                                if (flagLoai == 3 || flagLoai == 4) // đi công tác
                                {
                                    if (_lstXinVe.Count == 1)
                                    {
                                        phutTreThem = parseInt(_xinve.PHUTVAO);
                                        phutSomThem = parseInt(_xinve.PHUTRA);
                                    }
                                    else
                                    {
                                        phutTreThem = parseInt(_lstXinVe.Where(item => item.PHUTVAO != null).SingleOrDefault().PHUTVAO);
                                        phutSomThem = parseInt(_lstXinVe.Where(item => item.PHUTRA != null).SingleOrDefault().PHUTRA);
                                    }
                                }
                                else if (flagLoai == 5) // đi công tác
                                {
                                    //edit mới
                                    if (checkExist_XinTrongNgay(manv, tNgay) == true)
                                        if (_lstXinVe.Count == 1)
                                        {
                                            phutTreThem = parseInt(_xinve.PHUTVAO);
                                            phutSomThem = parseInt(_xinve.PHUTRA);
                                        }
                                        else
                                        {
                                            phutTreThem = parseInt(_lstXinVe.Where(item => item.PHUTVAO != null).SingleOrDefault().PHUTVAO);
                                            phutSomThem = parseInt(_lstXinVe.Where(item => item.PHUTRA != null).SingleOrDefault().PHUTRA);
                                        }
                                    //
                                    row[Class.Format.NgayVNVN(tNgay)] = "CT";
                                    row[Class.Format.NgayVNVN(tNgay) + "TYPE"] = "CT";
                                    ngay = Class.Format.NgayVNVN(tNgay);
                                    tongngaycong++;
                                    thu = tNgay.Date.DayOfWeek.ToString();
                                    if (_xinve.BUOICT == "S")
                                    {
                                        int id = 0;
                                        ////////////////////
                                        if (t1.Rows.Count > 1)
                                        {
                                            id = flag_ - 1;
                                        }

                                        try
                                        {
                                            // DateTime tm2 = DateTime.ParseExact(t1.Rows[id]["TimeStr"].ToString(), dateformat, CultureInfo.CreateSpecificCulture("en-US"));
                                            DateTime tm2 = DateTime.Parse(t1.Rows[flag_ - 1]["TimeStr"].ToString());
                                            row[Class.Format.NgayVNVN(tNgay) + "RA"] = tm2.ToString("HH:mm");
                                            giora = tm2.ToString("HH:mm");

                                            if (tm2.Hour == 16 && tm2.Minute < 50)
                                            {
                                                row[Class.Format.NgayVNVN(tNgay) + "SOM"] = "1";
                                                tongtre++;
                                                boolTre = true;
                                                int tr = (16 * 60 + 50) - (tm2.Hour * 60 + tm2.Minute);
                                                som = tr + "";
                                                tongphuttre += tr;
                                            }
                                            else if (tm2.Hour < 16)
                                            {
                                                row[Class.Format.NgayVNVN(tNgay) + "SOM"] = "1";
                                                tongtre++;
                                                boolTre = true;
                                                int tr = (16 * 60 + 50) - (tm2.Hour * 60 + tm2.Minute);
                                                som = tr + "";
                                                tongphuttre += tr;
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            row[Class.Format.NgayVNVN(tNgay) + "RA"] = "-";
                                        }
                                        ///////
                                    }
                                    else if (_xinve.BUOICT == "C")
                                    {
                                        ////////////////////
                                        string gVao = t1.Rows[0]["TimeStr"].ToString().Replace(" ", "");
                                        if (!"".Equals(gVao))
                                        {
                                            string tmp = t1.Rows[0]["TimeStr"].ToString();
                                            try
                                            {
                                                ngay = Class.Format.NgayVNVN(tNgay);
                                                //     DateTime tm1 = DateTime.ParseExact(t1.Rows[0]["TimeStr"].ToString(), dateformat, CultureInfo.CreateSpecificCulture("en-US"));
                                                DateTime tm1 = DateTime.Parse(t1.Rows[0]["TimeStr"].ToString());
                                                row[Class.Format.NgayVNVN(tNgay)] = tm1.ToString("H:mm");
                                                giovao = tm1.ToString("H:mm");

                                                if (tm1.Hour == 7 && tm1.Minute > 40)
                                                {
                                                    row[Class.Format.NgayVNVN(tNgay) + "TRE"] = "1";
                                                    tongtre++;
                                                    boolTre = true;
                                                    int tr = (tm1.Hour * 60 + tm1.Minute) - (7 * 60 + 40);
                                                    tre = tr + "";
                                                    tongphuttre += tr;
                                                }
                                                else if (tm1.Hour > 7)
                                                {
                                                    row[Class.Format.NgayVNVN(tNgay) + "TRE"] = "1";
                                                    tongtre++;
                                                    boolTre = true;
                                                    int tr = (tm1.Hour * 60 + tm1.Minute) - (7 * 60 + 40);
                                                    tre = tr + "";
                                                    tongphuttre += tr;
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                row[Class.Format.NgayVNVN(tNgay)] = "-";
                                            }
                                        }
                                        else
                                        {
                                            row[Class.Format.NgayVNVN(tNgay)] = "-";
                                        }

                                        row[Class.Format.NgayVNVN(tNgay) + "RA"] = "CT";

                                        // Gi? Ra
                                        //string gRa = t1.Rows[flag_ - 1]["TimeStr"].ToString().Replace(" ", "");
                                        //if (gRa.Equals(gVao))
                                        //{
                                        //    AddTableTre(tableTre, manv, tennv, phongban, ngay, thu, giovao, "-", tre, "-", "KHONG QUET");
                                        //}
                                        //else
                                        //{
                                        //    try
                                        //    {
                                        //      //  DateTime tm2 = DateTime.ParseExact(t1.Rows[flag_ - 1]["TimeStr"].ToString(), dateformat, CultureInfo.CreateSpecificCulture("en-US"));
                                        //        DateTime tm2 = DateTime.Parse(t1.Rows[flag_ - 1]["TimeStr"].ToString());
                                        //        row[Class.Format.NgayVNVN(tNgay) + "RA"] = tm2.ToString("HH:mm");
                                        //        giora = tm2.ToString("HH:mm");

                                        //        if (tm2.Hour == 11 && tm2.Minute < 20)
                                        //        {
                                        //            row[Class.Format.NgayVNVN(tNgay) + "SOM"] = "1";
                                        //            tongtre++;
                                        //            boolTre = true;
                                        //            int tr = (11 * 60 + 50) - (tm2.Hour * 60 + tm2.Minute);
                                        //            som = tr + "";
                                        //            tongphuttre += tr;
                                        //        }
                                        //        else if (tm2.Hour < 11)
                                        //        {
                                        //            row[Class.Format.NgayVNVN(tNgay) + "SOM"] = "1";
                                        //            tongtre++;
                                        //            boolTre = true;
                                        //            int tr = (11 * 60 + 50) - (tm2.Hour * 60 + tm2.Minute);
                                        //            som = tr + "";
                                        //            tongphuttre += tr;
                                        //        }


                                        //    }
                                        //    catch (Exception)
                                        //    {
                                        //        row[Class.Format.NgayVNVN(tNgay) + "RA"] = "-";
                                        //    }
                                        //}

                                        ///////
                                    }
                                    else
                                    {
                                        ngay = Class.Format.NgayVNVN(tNgay);
                                        row[Class.Format.NgayVNVN(tNgay)] = "CT";
                                        row[Class.Format.NgayVNVN(tNgay) + "TYPE"] = "CT";
                                        tongngaycong++;
                                        thu = tNgay.Date.DayOfWeek.ToString();
                                        giovao = "CT";
                                        row[Class.Format.NgayVNVN(tNgay) + "TYPE"] = "CT";

                                        row[Class.Format.NgayVNVN(tNgay) + "RA"] = "CT";
                                        giora = "CT";
                                    }
                                }
                            }

                            ////////////////////// TÍNH GIỜ THEO ĐIỀU KIỆN //////////////////////////////////////
                            if (flagLoai == 2 || flagLoai == 3 || flagLoai == 4 || flagLoai == 0)
                            {
                                // Gi? Vào
                                string gVao = t1.Rows[0]["TimeStr"].ToString().Replace(" ", "");
                                if (!"".Equals(gVao))
                                {
                                    string tmp = t1.Rows[0]["TimeStr"].ToString();
                                    try
                                    {
                                        ngay = Class.Format.NgayVNVN(tNgay);
                                        //fix bug DateTime tm1 = DateTime.ParseExact(t1.Rows[0]["TimeStr"].ToString(), dateformat, CultureInfo.CreateSpecificCulture("en-US"));
                                        DateTime tm1 = DateTime.Parse(t1.Rows[0]["TimeStr"].ToString());
                                        row[Class.Format.NgayVNVN(tNgay)] = tm1.ToString("H:mm");
                                        tongngaycong++;
                                        thu = tm1.Date.DayOfWeek.ToString();
                                        giovao = tm1.ToString("H:mm");
                                        tm1 = tm1.AddMinutes(phutTreThem * -1);
                                        if (tm1.Hour == 7 && tm1.Minute > 40)
                                        {
                                            row[Class.Format.NgayVNVN(tNgay) + "TRE"] = "1";
                                            tongtre++;
                                            boolTre = true;
                                            int tr = (tm1.Hour * 60 + tm1.Minute) - (7 * 60 + 40);
                                            tre = tr + "";
                                            tongphuttre += tr;
                                        }
                                        else if (tm1.Hour > 7)
                                        {
                                            row[Class.Format.NgayVNVN(tNgay) + "TRE"] = "1";
                                            tongtre++;
                                            boolTre = true;
                                            int tr = (tm1.Hour * 60 + tm1.Minute) - (7 * 60 + 40);
                                            tre = tr + "";
                                            tongphuttre += tr;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        row[Class.Format.NgayVNVN(tNgay)] = "-";
                                    }
                                }
                                else
                                {
                                    row[Class.Format.NgayVNVN(tNgay)] = "-";
                                }
                                // Gi? Ra
                                string gRa = t1.Rows[flag_ - 1]["TimeStr"].ToString().Replace(" ", "");

                                if (gVao.Equals(gRa))
                                {
                                    AddTableTre(tableTre, manv, tennv, phongban, ngay, thu, giovao, "-", tre, "-", "KHONG QUET");
                                    row[Class.Format.NgayVNVN(tNgay) + "RA"] = "KQ";
                                }
                                else
                                {
                                    try
                                    {
                                        //fix bug DateTime tm2 = DateTime.ParseExact(t1.Rows[flag_ - 1]["TimeStr"].ToString(), dateformat, CultureInfo.CreateSpecificCulture("en-US"));
                                        DateTime tm2 = DateTime.Parse(t1.Rows[flag_ - 1]["TimeStr"].ToString());
                                        row[Class.Format.NgayVNVN(tNgay) + "RA"] = tm2.ToString("HH:mm");
                                        giora = tm2.ToString("HH:mm");
                                        tm2 = tm2.AddMinutes(phutSomThem);
                                        if (tm2.Hour == 16 && tm2.Minute < 50)
                                        {
                                            row[Class.Format.NgayVNVN(tNgay) + "SOM"] = "1";
                                            tongtre++;
                                            boolTre = true;
                                            int tr = (16 * 60 + 50) - (tm2.Hour * 60 + tm2.Minute);
                                            som = tr + "";
                                            tongphuttre += tr;
                                        }
                                        else if (tm2.Hour < 16)
                                        {
                                            row[Class.Format.NgayVNVN(tNgay) + "SOM"] = "1";
                                            tongtre++;
                                            boolTre = true;
                                            int tr = (16 * 60 + 50) - (tm2.Hour * 60 + tm2.Minute);
                                            som = tr + "";
                                            tongphuttre += tr;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        row[Class.Format.NgayVNVN(tNgay) + "RA"] = "-";
                                    }
                                }
                            }
                        }
                        else
                        {
                            // không quét đi công tác
                            if (getThongTin(manv, tNgay) == 5) // đi công tác
                            {
                                //edit mới
                                if (checkExist_XinTrongNgay(manv, tNgay) == true)
                                {
                                    // Gi? Vào
                                    string gVao = t1.Rows[0]["TimeStr"].ToString().Replace(" ", "");
                                    if (!"".Equals(gVao))
                                    {
                                        string tmp = t1.Rows[0]["TimeStr"].ToString();
                                        try
                                        {
                                            ngay = Class.Format.NgayVNVN(tNgay);
                                            //fix bug DateTime tm1 = DateTime.ParseExact(t1.Rows[0]["TimeStr"].ToString(), dateformat, CultureInfo.CreateSpecificCulture("en-US"));
                                            DateTime tm1 = DateTime.Parse(t1.Rows[0]["TimeStr"].ToString());
                                            row[Class.Format.NgayVNVN(tNgay)] = tm1.ToString("H:mm");
                                            tongngaycong++;
                                            thu = tm1.Date.DayOfWeek.ToString();
                                            giovao = tm1.ToString("H:mm");
                                            tm1 = tm1.AddMinutes(phutTreThem * -1);
                                            if (tm1.Hour == 7 && tm1.Minute > 40)
                                            {
                                                row[Class.Format.NgayVNVN(tNgay) + "TRE"] = "1";
                                                tongtre++;
                                                boolTre = true;
                                                int tr = (tm1.Hour * 60 + tm1.Minute) - (7 * 60 + 40);
                                                tre = tr + "";
                                                tongphuttre += tr;
                                            }
                                            else if (tm1.Hour > 7)
                                            {
                                                row[Class.Format.NgayVNVN(tNgay) + "TRE"] = "1";
                                                tongtre++;
                                                boolTre = true;
                                                int tr = (tm1.Hour * 60 + tm1.Minute) - (7 * 60 + 40);
                                                tre = tr + "";
                                                tongphuttre += tr;
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            row[Class.Format.NgayVNVN(tNgay)] = "-";
                                        }
                                    }
                                    else
                                    {
                                        row[Class.Format.NgayVNVN(tNgay)] = "-";
                                    }
                                    // Gi? Ra
                                    string gRa = t1.Rows[flag_ - 1]["TimeStr"].ToString().Replace(" ", "");

                                    if (gVao.Equals(gRa))
                                    {
                                        AddTableTre(tableTre, manv, tennv, phongban, ngay, thu, giovao, "-", tre, "-", "KHONG QUET");
                                        row[Class.Format.NgayVNVN(tNgay) + "RA"] = "KQ";
                                    }
                                    else
                                    {
                                        try
                                        {
                                            //fix bug DateTime tm2 = DateTime.ParseExact(t1.Rows[flag_ - 1]["TimeStr"].ToString(), dateformat, CultureInfo.CreateSpecificCulture("en-US"));
                                            DateTime tm2 = DateTime.Parse(t1.Rows[flag_ - 1]["TimeStr"].ToString());
                                            row[Class.Format.NgayVNVN(tNgay) + "RA"] = tm2.ToString("HH:mm");
                                            giora = tm2.ToString("HH:mm");
                                            tm2 = tm2.AddMinutes(phutSomThem);
                                            if (tm2.Hour == 16 && tm2.Minute < 50)
                                            {
                                                row[Class.Format.NgayVNVN(tNgay) + "SOM"] = "1";
                                                tongtre++;
                                                boolTre = true;
                                                int tr = (16 * 60 + 50) - (tm2.Hour * 60 + tm2.Minute);
                                                som = tr + "";
                                                tongphuttre += tr;
                                            }
                                            else if (tm2.Hour < 16)
                                            {
                                                row[Class.Format.NgayVNVN(tNgay) + "SOM"] = "1";
                                                tongtre++;
                                                boolTre = true;
                                                int tr = (16 * 60 + 50) - (tm2.Hour * 60 + tm2.Minute);
                                                som = tr + "";
                                                tongphuttre += tr;
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            row[Class.Format.NgayVNVN(tNgay) + "RA"] = "-";
                                        }
                                    }
                                }
                                //
                                if (_xinve.BUOICT == "N")
                                {
                                    ngay = Class.Format.NgayVNVN(tNgay);
                                    row[Class.Format.NgayVNVN(tNgay)] = "CT";
                                    row[Class.Format.NgayVNVN(tNgay) + "TYPE"] = "CT";
                                    tongngaycong++;
                                    thu = tNgay.Date.DayOfWeek.ToString();
                                    giovao = "CT";
                                    row[Class.Format.NgayVNVN(tNgay) + "TYPE"] = "CT";

                                    row[Class.Format.NgayVNVN(tNgay) + "RA"] = "CT";
                                    giora = "CT";
                                }
                                else if (_xinve.BUOICT == "S")
                                {
                                    ngay = Class.Format.NgayVNVN(tNgay);
                                    row[Class.Format.NgayVNVN(tNgay)] = "CT";
                                    row[Class.Format.NgayVNVN(tNgay) + "TYPE"] = "CT";
                                    tongngaycong++;
                                    thu = tNgay.Date.DayOfWeek.ToString();
                                    giovao = "CT";
                                    row[Class.Format.NgayVNVN(tNgay) + "TYPE"] = "CT";

                                    AddTableTre(tableTre, manv, tennv, phongban, Class.Format.NgayVNVN(tNgay), tNgay.DayOfWeek.ToString(), "", "", "", "", "KHONG QUET");
                                    row[Class.Format.NgayVNVN(tNgay) + "RA"] = "KQ";
                                }
                                else if (_xinve.BUOICT == "C")
                                {
                                    ngay = Class.Format.NgayVNVN(tNgay);
                                    row[Class.Format.NgayVNVN(tNgay)] = "KQ";
                                    AddTableTre(tableTre, manv, tennv, phongban, Class.Format.NgayVNVN(tNgay), tNgay.DayOfWeek.ToString(), "", "", "", "", "KHONG QUET");
                                    tongngaycong++;
                                    thu = tNgay.Date.DayOfWeek.ToString();
                                    giovao = "CT";
                                    row[Class.Format.NgayVNVN(tNgay) + "TYPE"] = "CT";

                                    row[Class.Format.NgayVNVN(tNgay) + "RA"] = "CT";
                                    giora = "CT";
                                }
                            }
                            else
                            { // không quét
                                if (tNgay.DayOfWeek != DayOfWeek.Saturday && tNgay.DayOfWeek != DayOfWeek.Sunday)
                                {
                                    AddTableTre(tableTre, manv, tennv, phongban, Class.Format.NgayVNVN(tNgay), tNgay.DayOfWeek.ToString(), "", "", "", "", "KHONG QUET");
                                    row[Class.Format.NgayVNVN(tNgay)] = "KQ";
                                    row[Class.Format.NgayVNVN(tNgay) + "RA"] = "KQ";
                                }
                            }
                        }
                        if (boolTre)
                        {
                            AddTableTre(tableTre, manv, tennv, phongban, ngay, thu, giovao, giora, tre, som, "");
                        }

                        tNgay = tNgay.AddDays(1.0);
                        if (flagLoai != 2 && flagLoai != 0)
                        {
                            phutTreThem = 0;
                            phutSomThem = 0;
                        }
                    }
                    row["SỐ PHÚT"] = tongphuttre;
                    row["NGÀY CÔNG"] = tongngaycong;
                    row["TRỂ"] = tongtre;
                    workTable.Rows.Add(row);
                }
                Session["chamcong"] = workTable;
                //Session["col"] = flag;
                Session["arrTitle"] = arrTitle;
                Session["tableTre"] = tableTre;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertmsg", "alert('" + ex.Message +" "+ k+" "+MaNV+" "+TenNV+"');", true);
            }
        }

        protected void btXemBangKe_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            string title = "DI TRE THANG " + tungay.Text.Substring(3, 2) + ".xls";
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", title));
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Charset = "UTF-8";
            using (StringWriter sw = new StringWriter())
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                Table table = new Table();
                table.GridLines = System.Web.UI.WebControls.GridLines.Both;
                TableRow tRow = new TableRow();
                TableCell Cell = new TableCell();
                Cell.BorderColor = System.Drawing.Color.Black;
                Cell.Text = "DANH SACH NHAN VIEN TRE THANG " + tungay.Text.Substring(3, 2) + " ( TU " + tungay.Text + " DEN " + denngay.Text + ")";
                Cell.BorderStyle = BorderStyle.Solid;
                Cell.HorizontalAlign = HorizontalAlign.Center;
                Cell.VerticalAlign = VerticalAlign.Middle;
                Cell.Font.Bold = true;
                Cell.Font.Size = 15;
                Cell.Height = 30;
                Cell.ColumnSpan = 10;
                tRow.Cells.Add(Cell);
                table.Rows.Add(tRow);

                tRow = new TableRow();
                tRow.Cells.Add(new TableCell() { Width = 100, HorizontalAlign = HorizontalAlign.Center, Text = "MA NV" });
                tRow.Cells.Add(new TableCell() { Width = 300, HorizontalAlign = HorizontalAlign.Center, Text = "TEN NHAN VIEN" });
                tRow.Cells.Add(new TableCell() { Width = 100, HorizontalAlign = HorizontalAlign.Center, Text = "PHONG BAN" });
                tRow.Cells.Add(new TableCell() { Width = 100, HorizontalAlign = HorizontalAlign.Center, Text = "NGAY" });
                tRow.Cells.Add(new TableCell() { Width = 100, HorizontalAlign = HorizontalAlign.Center, Text = "THU " });
                tRow.Cells.Add(new TableCell() { Width = 100, HorizontalAlign = HorizontalAlign.Center, Text = "GIO VAO" });
                tRow.Cells.Add(new TableCell() { Width = 100, HorizontalAlign = HorizontalAlign.Center, Text = "VAO TRE" });
                tRow.Cells.Add(new TableCell() { Width = 100, HorizontalAlign = HorizontalAlign.Center, Text = "GIO VE" });
                tRow.Cells.Add(new TableCell() { Width = 100, HorizontalAlign = HorizontalAlign.Center, Text = "VE SOM" });
                tRow.Cells.Add(new TableCell() { Width = 200, HorizontalAlign = HorizontalAlign.Center, Text = "GHI CHU " });
                table.Rows.Add(tRow); // Done! Header row added.

                DataTable tableTre = (DataTable)Session["tableTre"];
                foreach (DataRow item in tableTre.Rows)
                {
                    tRow = new TableRow();
                    tRow.Cells.Add(new TableCell() { Width = 100, HorizontalAlign = HorizontalAlign.Center, Text = item[0].ToString() });
                    tRow.Cells.Add(new TableCell() { Width = 300, HorizontalAlign = HorizontalAlign.Left, Text = item[1].ToString() });
                    tRow.Cells.Add(new TableCell() { Width = 100, HorizontalAlign = HorizontalAlign.Center, Text = item[2].ToString() });
                    tRow.Cells.Add(new TableCell() { Width = 100, HorizontalAlign = HorizontalAlign.Center, Text = item[3].ToString() });
                    tRow.Cells.Add(new TableCell() { Width = 100, HorizontalAlign = HorizontalAlign.Center, Text = item[4].ToString() });
                    tRow.Cells.Add(new TableCell() { Width = 100, HorizontalAlign = HorizontalAlign.Center, Text = item[5].ToString() });
                    tRow.Cells.Add(new TableCell() { Width = 100, HorizontalAlign = HorizontalAlign.Center, Text = item[6].ToString() });
                    tRow.Cells.Add(new TableCell() { Width = 100, HorizontalAlign = HorizontalAlign.Center, Text = item[7].ToString() });
                    tRow.Cells.Add(new TableCell() { Width = 100, HorizontalAlign = HorizontalAlign.Center, Text = item[8].ToString() });
                    tRow.Cells.Add(new TableCell() { Width = 100, HorizontalAlign = HorizontalAlign.Center, Text = item[9].ToString() });
                    table.Rows.Add(tRow);
                }

                table.RenderControl(htw);
                HttpContext.Current.Response.Output.Write(sw.ToString());
                HttpContext.Current.Response.End();
                HttpContext.Current.Response.Clear();

            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Data;
using DocSo_PC.DAL.QuanTri;

namespace DocSo_PC.DAL.sDHN
{
    class CsDHN : CDAL
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();

        public DataTable getDS(int IDNCC)
        {
            string sql = "select db.DanhBo,MLT=kh.LOTRINH,HOTEN,DiaChi=SONHA+' '+TENDUONG"
                        + " from sDHN db,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG kh"
                        + " where IDNCC=" + IDNCC + " and db.DanhBo=kh.DanhBo";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public bool checkExists(string DanhBo)
        {
            return _db.sDHNs.Any(item => item.DanhBo == DanhBo);
        }

        #region Hoa Sen

        public DataTable getDS_NCC()
        {
            string sql = "select ID,Name from sDHN_NCC";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public bool updateDS_DHN()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8033/api/all/?req=list_swm_Id");
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();

                    var obj = jss.Deserialize<dynamic>(result);
                    foreach (var item in obj)
                    {
                        if (checkExists(item) == false)
                            _cDAL.ExecuteNonQuery("insert into sDHN(DanhBo,IDNCC,Valid,CreateBy)values('" + item + "',1,1," + CNguoiDung.MaND + ")");
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_ChiSoNuoc(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8033/api/volume/?id=" + DanhBo + "&date=" + Time.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();

                    var obj = jss.Deserialize<dynamic>(result);
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ChiSo", typeof(System.Double));
                    dt.Columns.Add("ThoiGianCapNhat", typeof(System.DateTime));
                    DataRow dr = dt.NewRow();
                    dr["ChiSo"] = obj["Vol"];
                    dr["ThoiGianCapNhat"] = DateTime.Parse(obj["TimeUpdate"]);
                    dt.Rows.Add(dr);
                    return dt;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //// Create a request for the URL.       
            //var request = WebRequest.Create("http://www.contoso.com/default.html");
            //request.ContentType = contentType; //your contentType, Json, text,etc. -- or comment, for text
            //request.Method = method; //method, GET, POST, etc -- or comment for GET
            //using (WebResponse resp = request.GetResponse())
            //{
            //    if (resp == null)
            //        new Exception("Response is null");

            //    return resp.GetResponseStream();//Get stream
            //}
        }

        public DataTable get_ChatLuongSong(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8033/api/signal_quality/?id=" + DanhBo + "&date=" + Time.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();

                    var obj = jss.Deserialize<dynamic>(result);
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ChatLuongSong", typeof(System.String));
                    DataRow dr = dt.NewRow();
                    dr["ChatLuongSong"] = obj;
                    dt.Rows.Add(dr);
                    return dt;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_CanhBao(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8033/api/warnings/?id=" + DanhBo + "&date=" + Time.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();

                    var obj = jss.Deserialize<dynamic>(result);
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CBPinYeu", typeof(System.Boolean));
                    dt.Columns.Add("CBRoRi", typeof(System.Boolean));
                    dt.Columns.Add("CBQuaDong", typeof(System.Boolean));
                    dt.Columns.Add("CBChayNguoc", typeof(System.Boolean));
                    dt.Columns.Add("CBNamCham", typeof(System.Boolean));
                    dt.Columns.Add("CBKhoOng", typeof(System.Boolean));
                    dt.Columns.Add("CBMoHop", typeof(System.Boolean));
                    dt.Columns.Add("ThoiGianCapNhat", typeof(System.DateTime));
                    DataRow dr = dt.NewRow();
                    dr["CBPinYeu"] = obj["IsLowBatt"];
                    dr["CBRoRi"] = obj["IsLeakage"];
                    dr["CBQuaDong"] = obj["IsOverLoad"];
                    dr["CBChayNguoc"] = obj["IsReverse"];
                    dr["CBNamCham"] = obj["IsTampering"];
                    dr["CBKhoOng"] = obj["IsDry"];
                    dr["CBMoHop"] = obj["IsOpenBox"];
                    dr["ThoiGianCapNhat"] = DateTime.Parse(obj["TimeUpdate"]);
                    dt.Rows.Add(dr);
                    return dt;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_Pin(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8033/api/battery/?id=" + DanhBo + "&date=" + Time.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();

                    var obj = jss.Deserialize<dynamic>(result);
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Pin", typeof(System.Int32));
                    dt.Columns.Add("ThoiLuongPinConLai", typeof(System.String));
                    dt.Columns.Add("ThoiGianCapNhat", typeof(System.DateTime));
                    DataRow dr = dt.NewRow();
                    dr["Pin"] = obj["batt_percent"];
                    dr["ThoiLuongPinConLai"] = obj["batt_duration"];
                    dr["ThoiGianCapNhat"] = DateTime.Parse(obj["TimeUpdate"]);
                    dt.Rows.Add(dr);
                    return dt;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_All(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8033/api/all/?id=" + DanhBo + "&date=" + Time.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();

                    var obj = jss.Deserialize<dynamic>(result);
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ChiSo", typeof(System.Double));
                    dt.Columns.Add("Pin", typeof(System.Int32));
                    dt.Columns.Add("ThoiLuongPinConLai", typeof(System.String));
                    dt.Columns.Add("LuuLuong", typeof(System.Double));
                    dt.Columns.Add("ChatLuongSong", typeof(System.String));
                    dt.Columns.Add("CBPinYeu", typeof(System.Boolean));
                    dt.Columns.Add("CBRoRi", typeof(System.Boolean));
                    dt.Columns.Add("CBQuaDong", typeof(System.Boolean));
                    dt.Columns.Add("CBChayNguoc", typeof(System.Boolean));
                    dt.Columns.Add("CBNamCham", typeof(System.Boolean));
                    dt.Columns.Add("CBKhoOng", typeof(System.Boolean));
                    dt.Columns.Add("CBMoHop", typeof(System.Boolean));
                    dt.Columns.Add("Longitude", typeof(System.Double));
                    dt.Columns.Add("Latitude", typeof(System.Double));
                    dt.Columns.Add("Altitude", typeof(System.Double));
                    dt.Columns.Add("ChuKy", typeof(System.Int32));
                    dt.Columns.Add("ThoiGianCapNhat", typeof(System.DateTime));
                    DataRow dr = dt.NewRow();
                    dr["ChiSo"] = obj["Volume"];
                    dr["Pin"] = obj["Battery"];
                    dr["ThoiLuongPinConLai"] = obj["RemainBatt"];
                    dr["LuuLuong"] = obj["Flow"] ?? DBNull.Value;
                    dr["ChatLuongSong"] = obj["Rssi"] ?? DBNull.Value;
                    dr["CBPinYeu"] = obj["IsLowBatt"];
                    dr["CBRoRi"] = obj["IsLeakage"];
                    dr["CBQuaDong"] = obj["IsOverLoad"];
                    dr["CBChayNguoc"] = obj["IsReverse"];
                    dr["CBNamCham"] = obj["IsTampering"];
                    dr["CBKhoOng"] = obj["IsDry"];
                    dr["CBMoHop"] = obj["IsOpenBox"];
                    dr["Longitude"] = obj["Longitude"] ?? DBNull.Value;
                    dr["Latitude"] = obj["Latitude"] ?? DBNull.Value;
                    dr["Altitude"] = obj["Altitude"] ?? DBNull.Value;
                    dr["ChuKy"] = obj["Interval"] ?? DBNull.Value;
                    dr["ThoiGianCapNhat"] = DateTime.Parse(obj["Time"]);
                    dt.Rows.Add(dr);
                    return dt;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_All(string DanhBo, DateTime FromTime, DateTime ToTime)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8033/api/all/?id=" + DanhBo + "&date1=" + FromTime.ToString("dd-MM-yyyy") + "&date2=" + ToTime.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();

                    var obj = jss.Deserialize<dynamic>(result);
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ChiSo", typeof(System.Double));
                    dt.Columns.Add("Pin", typeof(System.Int32));
                    dt.Columns.Add("ThoiLuongPinConLai", typeof(System.String));
                    dt.Columns.Add("LuuLuong", typeof(System.Double));
                    dt.Columns.Add("ChatLuongSong", typeof(System.String));
                    dt.Columns.Add("CBPinYeu", typeof(System.Boolean));
                    dt.Columns.Add("CBRoRi", typeof(System.Boolean));
                    dt.Columns.Add("CBQuaDong", typeof(System.Boolean));
                    dt.Columns.Add("CBChayNguoc", typeof(System.Boolean));
                    dt.Columns.Add("CBNamCham", typeof(System.Boolean));
                    dt.Columns.Add("CBKhoOng", typeof(System.Boolean));
                    dt.Columns.Add("CBMoHop", typeof(System.Boolean));
                    dt.Columns.Add("Longitude", typeof(System.Double));
                    dt.Columns.Add("Latitude", typeof(System.Double));
                    dt.Columns.Add("Altitude", typeof(System.Double));
                    dt.Columns.Add("ChuKy", typeof(System.Int32));
                    dt.Columns.Add("ThoiGianCapNhat", typeof(System.DateTime));
                    foreach (var item in obj)
                    {
                        DataRow dr = dt.NewRow();
                        dr["ChiSo"] = item["Volume"];
                        dr["Pin"] = item["Battery"];
                        dr["ThoiLuongPinConLai"] = item["RemainBatt"];
                        dr["LuuLuong"] = item["Flow"] ?? DBNull.Value;
                        dr["CBPinYeu"] = item["IsLowBatt"];
                        dr["CBRoRi"] = item["IsLeakage"];
                        dr["CBQuaDong"] = item["IsOverLoad"];
                        dr["CBChayNguoc"] = item["IsReverse"];
                        dr["CBNamCham"] = item["IsTampering"];
                        dr["CBKhoOng"] = item["IsDry"];
                        dr["CBMoHop"] = item["IsOpenBox"];
                        dr["Longitude"] = item["Longitude"] ?? DBNull.Value;
                        dr["Latitude"] = item["Latitude"] ?? DBNull.Value;
                        dr["Altitude"] = item["Altitude"] ?? DBNull.Value;
                        dr["ChuKy"] = item["Interval"] ?? DBNull.Value;
                        dr["ThoiGianCapNhat"] = DateTime.Parse(item["Time"]);
                        dt.Rows.Add(dr);
                    }

                    return dt;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}

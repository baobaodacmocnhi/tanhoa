using System;
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
            string sql = "select IDLogger,db.DanhBo,MLT=kh.LOTRINH,HOTEN,DiaChi=SONHA+' '+TENDUONG"
                        + " from sDHN db,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG kh"
                        + " where IDNCC=" + IDNCC + " and Valid=1 and db.DanhBo=kh.DanhBo";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public bool checkExists(string DanhBo)
        {
            return _db.sDHNs.Any(item => item.DanhBo == DanhBo);
        }

        public DataTable getDS_NCC()
        {
            string sql = "select ID,Name from sDHN_NCC";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        #region Hoa Sen

        public bool updateDS_DHN_HoaSen()
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
                    _cDAL.ExecuteNonQuery("update sDHN set Valid=0 where IDNCC=1");
                    var obj = jss.Deserialize<dynamic>(result);
                    foreach (var item in obj)
                    {
                        if (checkExists(item["MaDanhbo"]) == false)
                            if (string.IsNullOrEmpty(item["SeriModule"]))
                                _cDAL.ExecuteNonQuery("insert into sDHN(DanhBo,IDNCC,Valid,CreateBy)values('" + item["MaDanhbo"] + "',1,1," + CNguoiDung.MaND + ")");
                            else
                                _cDAL.ExecuteNonQuery("insert into sDHN(DanhBo,IDNCC,IDLogger,Valid,CreateBy)values('" + item["MaDanhbo"] + "',1,'" + item["SeriModule"] + "',1," + CNguoiDung.MaND + ")");
                        else
                            _cDAL.ExecuteNonQuery("update sDHN set Valid=1 where DanhBo='" + item["MaDanhbo"] + "' and IDNCC=1");
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

        public DataTable get_ChiSoNuoc_HoaSen(string DanhBo, DateTime Time)
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
                    if (result != "")
                    {
                        var obj = jss.Deserialize<dynamic>(result);
                        DataTable dt = new DataTable();
                        dt.Columns.Add("ChiSo", typeof(System.Double));
                        dt.Columns.Add("ThoiGianCapNhat", typeof(System.DateTime));
                        DataRow dr = dt.NewRow();
                        dr["ChiSo"] = obj["Vol"];
                        if (obj["TimeUpdate"] != "")
                            dr["ThoiGianCapNhat"] = DateTime.Parse(obj["TimeUpdate"]);
                        dt.Rows.Add(dr);
                        return dt;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_ChiSoNuoc_HoaSen(string DanhBo, DateTime Time, int Hour)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8033/api/Survey/?id=" + DanhBo + "&date=" + Time.ToString("dd-MM-yyyy") + " " + Hour.ToString("00") + ":00:00");
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "")
                    {
                        var obj = jss.Deserialize<dynamic>(result);
                        DataTable dt = new DataTable();
                        dt.Columns.Add("ChiSo", typeof(System.Double));
                        dt.Columns.Add("ThoiGianCapNhat", typeof(System.DateTime));
                        DataRow dr = dt.NewRow();
                        dr["ChiSo"] = obj["Volume"];
                        if (obj["Time"] != "")
                            dr["ThoiGianCapNhat"] = DateTime.Parse(obj["Time"]);
                        dt.Rows.Add(dr);
                        return dt;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable get_ChiSoNuoc_HoaSen_Survey(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8033/api/Survey/?id=" + DanhBo + "&date=" + Time.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "")
                    {
                        var obj = jss.Deserialize<dynamic>(result);
                        DataTable dt = new DataTable();
                        dt.Columns.Add("ChiSo", typeof(System.Double));
                        dt.Columns.Add("ThoiGianCapNhat", typeof(System.DateTime));
                        foreach (var item in obj)
                        {
                            DataRow dr = dt.NewRow();
                            dr["ChiSo"] = item["Volume"];
                            if (item["Time"] != "")
                                dr["ThoiGianCapNhat"] = DateTime.Parse(item["Time"]);
                            dt.Rows.Add(dr);
                        }
                        return dt;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable get_ChatLuongSong_HoaSen(string DanhBo, DateTime Time)
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
                    if (result != "")
                    {
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
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_CanhBao_HoaSen(string DanhBo, DateTime Time)
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
                    if (result != "")
                    {
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
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_Pin_HoaSen(string DanhBo, DateTime Time)
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
                    if (result != "")
                    {
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
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_All_HoaSen(string DanhBo, DateTime Time)
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
                    if (result != "")
                    {
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
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_All_HoaSen(string DanhBo, DateTime FromTime, DateTime ToTime)
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
                    if (result != "")
                    {
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
                            dr["ChatLuongSong"] = item["Rssi"] ?? DBNull.Value;
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
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Rynan

        public bool updateDS_DHN_Rynan()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:7032/api/list_swm_Id");
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    _cDAL.ExecuteNonQuery("update sDHN set Valid=0 where IDNCC=2");
                    var obj = jss.Deserialize<dynamic>(result);
                    foreach (var item in obj)
                    {
                        if (checkExists(item) == false)
                            _cDAL.ExecuteNonQuery("insert into sDHN(DanhBo,IDNCC,Valid,CreateBy)values('" + item + "',2,1," + CNguoiDung.MaND + ")");
                        else
                            _cDAL.ExecuteNonQuery("update sDHN set Valid=1 where DanhBo='" + item + "' and IDNCC=2");
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

        public DataTable get_ChiSoNuoc_Rynan(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:7032/api/volume?Id=" + DanhBo + "&Date=" + Time.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "Not value return.")
                    {
                        var obj = jss.Deserialize<dynamic>(result);
                        DataTable dt = new DataTable();
                        dt.Columns.Add("ChiSo", typeof(System.Double));
                        dt.Columns.Add("ThoiGianCapNhat", typeof(System.DateTime));
                        foreach (var item in obj)
                        {
                            DataRow dr = dt.NewRow();
                            dr["ChiSo"] = item["Vol"];
                            dr["ThoiGianCapNhat"] = DateTime.Parse(item["TimeUpdate"]);
                            dt.Rows.Add(dr);
                        }
                        return dt;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_ChiSoNuoc_Rynan(string DanhBo, DateTime Time, int Hour)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:7032/api/volume?Id=" + DanhBo + "&Date=" + Time.ToString("dd-MM-yyyy") + "&Hour=" + Hour);
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "Not value return.")
                    {
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
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable get_ChatLuongSong_Rynan(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:7032/api/signal_quality?id=" + DanhBo + "&date=" + Time.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "Not value return.")
                    {
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
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_CanhBao_Rynan(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:7032/api/warnings?Id=" + DanhBo + "&Date=" + Time.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "Not value return.")
                    {
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
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_Pin_Rynan(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:7032/api/battery?Id=" + DanhBo + "&Date=" + Time.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "Not value return.")
                    {
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
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_All_Rynan(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:7032/api/swm_hour?Id=" + DanhBo + "&Date=" + Time.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "Not value return.")
                    {
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
                            dr["ChatLuongSong"] = item["Rssi"] ?? DBNull.Value;
                            dr["CBPinYeu"] = item["IsLowBatt"];
                            dr["CBRoRi"] = item["IsLeakage"];
                            dr["CBQuaDong"] = item["IsOverLoad"];
                            dr["CBChayNguoc"] = item["IsReverse"];
                            dr["CBNamCham"] = item["IsTampering"];
                            dr["CBKhoOng"] = item["IsDry"];
                            dr["CBMoHop"] = item["IsOpenBox"];
                            dr["Longitude"] = item["Longitude"] ?? DBNull.Value;
                            dr["Latitude"] = item["Latitude"] ?? DBNull.Value;
                            //dr["Altitude"] = item["Altitude"] ?? DBNull.Value;
                            dr["ChuKy"] = item["Interval"] ?? DBNull.Value;
                            dr["ThoiGianCapNhat"] = DateTime.Parse(item["Time"]);
                            dt.Rows.Add(dr);
                        }
                        return dt;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_All_Rynan(string DanhBo, DateTime Time, int Hour)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:7032/api/swm_hour?Id=" + DanhBo + "&Date=" + Time.ToString("dd-MM-yyyy") + "&Hour=" + Hour);
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "Not value return.")
                    {
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
                        //dr["Altitude"] = obj["Altitude"] ?? DBNull.Value;
                        dr["ChuKy"] = obj["Interval"] ?? DBNull.Value;
                        dr["ThoiGianCapNhat"] = DateTime.Parse(obj["Time"]);
                        dt.Rows.Add(dr);
                        return dt;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_All_Rynan(string DanhBo, DateTime FromTime, DateTime ToTime)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:7032/api/all?Id=" + DanhBo + "&Date1=" + FromTime.ToString("dd-MM-yyyy") + "&Date2=" + ToTime.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "Not value return.")
                    {
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
                            dr["ChatLuongSong"] = item["Rssi"] ?? DBNull.Value;
                            dr["CBPinYeu"] = item["IsLowBatt"];
                            dr["CBRoRi"] = item["IsLeakage"];
                            dr["CBQuaDong"] = item["IsOverLoad"];
                            dr["CBChayNguoc"] = item["IsReverse"];
                            dr["CBNamCham"] = item["IsTampering"];
                            dr["CBKhoOng"] = item["IsDry"];
                            dr["CBMoHop"] = item["IsOpenBox"];
                            dr["Longitude"] = item["Longitude"] ?? DBNull.Value;
                            dr["Latitude"] = item["Latitude"] ?? DBNull.Value;
                            //dr["Altitude"] = item["Altitude"] ?? DBNull.Value;
                            dr["ChuKy"] = item["Interval"] ?? DBNull.Value;
                            dr["ThoiGianCapNhat"] = DateTime.Parse(item["Time"]);
                            dt.Rows.Add(dr);
                        }
                        return dt;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_All_Rynan(string DanhBo, DateTime FromTime, DateTime ToTime, int Hour)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:7032/api/all?Id=" + DanhBo + "&Date1=" + FromTime.ToString("dd-MM-yyyy") + "&Date2=" + ToTime.ToString("dd-MM-yyyy") + "&Hour=" + Hour);
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "Not value return.")
                    {
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
                            dr["ChatLuongSong"] = item["Rssi"] ?? DBNull.Value;
                            dr["CBPinYeu"] = item["IsLowBatt"];
                            dr["CBRoRi"] = item["IsLeakage"];
                            dr["CBQuaDong"] = item["IsOverLoad"];
                            dr["CBChayNguoc"] = item["IsReverse"];
                            dr["CBNamCham"] = item["IsTampering"];
                            dr["CBKhoOng"] = item["IsDry"];
                            dr["CBMoHop"] = item["IsOpenBox"];
                            dr["Longitude"] = item["Longitude"] ?? DBNull.Value;
                            dr["Latitude"] = item["Latitude"] ?? DBNull.Value;
                            //dr["Altitude"] = item["Altitude"] ?? DBNull.Value;
                            dr["ChuKy"] = item["Interval"] ?? DBNull.Value;
                            dr["ThoiGianCapNhat"] = DateTime.Parse(item["Time"]);
                            dt.Rows.Add(dr);
                        }
                        return dt;
                    }
                    else
                        return null;
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

        #region Deviwas

        public bool updateDS_DHN_Deviwas()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8039/api/all/?req=list_swm_Id");
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    _cDAL.ExecuteNonQuery("update sDHN set Valid=0 where IDNCC=3");
                    var obj = jss.Deserialize<dynamic>(result);
                    foreach (var item in obj)
                    {
                        if (checkExists(item["MaDanhbo"]) == false)
                            if (string.IsNullOrEmpty(item["SeriModule"]))
                                _cDAL.ExecuteNonQuery("insert into sDHN(DanhBo,IDNCC,Valid,CreateBy)values('" + item["MaDanhbo"] + "',3,1," + CNguoiDung.MaND + ")");
                            else
                                _cDAL.ExecuteNonQuery("insert into sDHN(DanhBo,IDNCC,IDLogger,Valid,CreateBy)values('" + item["MaDanhbo"] + "',3,'" + item["SeriModule"] + "',1," + CNguoiDung.MaND + ")");
                        else
                            _cDAL.ExecuteNonQuery("update sDHN set Valid=1,IDLogger='" + item["SeriModule"] + "' where DanhBo='" + item["MaDanhbo"] + "' and IDNCC=3");
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

        public DataTable get_ChiSoNuoc_Deviwas(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8039/api/volume?id=" + DanhBo + "&date=" + Time.ToString("dd-MM-yyyy"));
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
                    foreach (var item in obj)
                    {
                        DataRow dr = dt.NewRow();
                        dr["ChiSo"] = item["Vol"];
                        dr["ThoiGianCapNhat"] = DateTime.Parse(item["TimeUpdate"]);
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

        public DataTable get_ChiSoNuoc_Deviwas(string DanhBo, DateTime Time, int Hour)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8039/api/volume?id=" + DanhBo + "&date=" + Time.ToString("dd-MM-yyyy") + "&hour=" + Hour);
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
                    foreach (var item in obj)
                    {
                        DataRow dr = dt.NewRow();
                        dr["ChiSo"] = item["Vol"];
                        dr["ThoiGianCapNhat"] = DateTime.Parse(item["TimeUpdate"]);
                        dt.Rows.Add(dr);
                    }
                    return dt;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable get_ChatLuongSong_Deviwas(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8039/api/signal_quality?id=" + DanhBo + "&date=" + Time.ToString("dd-MM-yyyy"));
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
                    foreach (var item in obj)
                    {
                        DataRow dr = dt.NewRow();
                        dr["ChatLuongSong"] = item["Rssi"];
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

        public DataTable get_CanhBao_Deviwas(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8039/api/warnings?id=" + DanhBo + "&date=" + Time.ToString("dd-MM-yyyy"));
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
                    dt.Columns.Add("CBDangRoRi", typeof(System.Boolean));
                    dt.Columns.Add("CBDaRoRi", typeof(System.Boolean));
                    dt.Columns.Add("CBKhongSuDung", typeof(System.Boolean));
                    dt.Columns.Add("CBQuaDong", typeof(System.Boolean));
                    dt.Columns.Add("CBDuoiDong", typeof(System.Boolean));
                    dt.Columns.Add("CBChayNguoc", typeof(System.Boolean));
                    dt.Columns.Add("CBNamCham", typeof(System.Boolean));
                    dt.Columns.Add("CBKhoOng", typeof(System.Boolean));
                    dt.Columns.Add("CBMoHop", typeof(System.Boolean));
                    dt.Columns.Add("ThoiGianCapNhat", typeof(System.DateTime));
                    foreach (var item in obj)
                        if (item["Warning"] != null)
                        {
                            DataRow dr = dt.NewRow();
                            string[] strs = ((string)item["Warning"]).Split('|');
                            foreach (string itemC in strs)
                            {
                                if (itemC == "low battery")
                                    dr["CBPinYeu"] = true;
                                if (itemC == "leakage current")
                                    dr["CBDangRoRi"] = true;
                                if (itemC == "leakage historic")
                                    dr["CBDaRoRi"] = true;
                                if (itemC == "no usage")
                                    dr["CBKhongSuDung"] = true;
                                if (itemC == "back flow")
                                    dr["CBChayNguoc"] = true;
                                if (itemC == "over flow")
                                    dr["CBQuaDong"] = true;
                                if (itemC == "under flow")
                                    dr["CBDuoiDong"] = true;
                                if (itemC == "meter block")
                                    dr["CBKhoOng"] = true;
                                if (itemC == "mechanical fraud")
                                    dr["CBMoHop"] = true;
                            }
                            dr["ThoiGianCapNhat"] = Time;
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

        public DataTable get_Pin_Deviwas(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8039/api/battery?id=" + DanhBo + "&date=" + Time.ToString("dd-MM-yyyy"));
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
                    foreach (var item in obj)
                    {
                        DataRow dr = dt.NewRow();
                        //dr["Pin"] = obj["batt_percent"];
                        dr["ThoiLuongPinConLai"] = item["bat_duration"];
                        dr["ThoiGianCapNhat"] = DateTime.Parse(item["TimeUpdate"]);
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

        public DataTable get_All_Deviwas(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8039/api/all?id=" + DanhBo + "&date=" + Time.ToString("dd-MM-yyyy"));
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
                        dr["ChiSo"] = item["Vol"];
                        //dr["Pin"] = obj["Battery"];
                        dr["ThoiLuongPinConLai"] = item["bat_duration"];
                        //dr["LuuLuong"] = obj["Flow"] ?? DBNull.Value;
                        dr["ChatLuongSong"] = item["Rssi"] ?? DBNull.Value;
                        //dr["CBPinYeu"] = obj["IsLowBatt"];
                        //dr["CBRoRi"] = obj["IsLeakage"];
                        //dr["CBQuaDong"] = obj["IsOverLoad"];
                        //dr["CBChayNguoc"] = obj["IsReverse"];
                        //dr["CBNamCham"] = obj["IsTampering"];
                        //dr["CBKhoOng"] = obj["IsDry"];
                        //dr["CBMoHop"] = obj["IsOpenBox"];
                        //dr["Longitude"] = obj["Longitude"] ?? DBNull.Value;
                        //dr["Latitude"] = obj["Latitude"] ?? DBNull.Value;
                        //dr["Altitude"] = obj["Altitude"] ?? DBNull.Value;
                        //dr["ChuKy"] = obj["Interval"] ?? DBNull.Value;
                        dr["ThoiGianCapNhat"] = DateTime.Parse(item["TimeUpdate"]);
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

        public DataTable get_All_Deviwas(string DanhBo, DateTime Time, int Hour)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8039/api/all?id=" + DanhBo + "&date=" + Time.ToString("dd-MM-yyyy") + "&hour=" + Hour);
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
                        dr["ChiSo"] = item["Vol"];
                        //dr["Pin"] = obj["Battery"];
                        dr["ThoiLuongPinConLai"] = item["bat_duration"];
                        //dr["LuuLuong"] = obj["Flow"] ?? DBNull.Value;
                        dr["ChatLuongSong"] = item["Rssi"] ?? DBNull.Value;
                        //dr["CBPinYeu"] = obj["IsLowBatt"];
                        //dr["CBRoRi"] = obj["IsLeakage"];
                        //dr["CBQuaDong"] = obj["IsOverLoad"];
                        //dr["CBChayNguoc"] = obj["IsReverse"];
                        //dr["CBNamCham"] = obj["IsTampering"];
                        //dr["CBKhoOng"] = obj["IsDry"];
                        //dr["CBMoHop"] = obj["IsOpenBox"];
                        //dr["Longitude"] = obj["Longitude"] ?? DBNull.Value;
                        //dr["Latitude"] = obj["Latitude"] ?? DBNull.Value;
                        //dr["Altitude"] = obj["Altitude"] ?? DBNull.Value;
                        //dr["ChuKy"] = obj["Interval"] ?? DBNull.Value;
                        dr["ThoiGianCapNhat"] = DateTime.Parse(item["TimeUpdate"]);
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

        public DataTable get_All_Deviwas(string DanhBo, DateTime FromTime, DateTime ToTime)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8039/api/all?id=" + DanhBo + "&date1=" + FromTime.ToString("dd-MM-yyyy") + "&date2=" + ToTime.ToString("dd-MM-yyyy"));
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
                        dr["ChiSo"] = item["Vol"];
                        //dr["Pin"] = item["Battery"];
                        dr["ThoiLuongPinConLai"] = item["bat_duration"];
                        //dr["LuuLuong"] = item["Flow"] ?? DBNull.Value;
                        dr["ChatLuongSong"] = item["Rssi"] ?? DBNull.Value;
                        //dr["CBPinYeu"] = item["IsLowBatt"];
                        //dr["CBRoRi"] = item["IsLeakage"];
                        //dr["CBQuaDong"] = item["IsOverLoad"];
                        //dr["CBChayNguoc"] = item["IsReverse"];
                        //dr["CBNamCham"] = item["IsTampering"];
                        //dr["CBKhoOng"] = item["IsDry"];
                        //dr["CBMoHop"] = item["IsOpenBox"];
                        //dr["Longitude"] = item["Longitude"] ?? DBNull.Value;
                        //dr["Latitude"] = item["Latitude"] ?? DBNull.Value;
                        //dr["Altitude"] = item["Altitude"] ?? DBNull.Value;
                        //dr["ChuKy"] = item["Interval"] ?? DBNull.Value;
                        dr["ThoiGianCapNhat"] = DateTime.Parse(item["TimeUpdate"]);
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

        #region Phạm Lãm

        public bool updateDS_DHN_PhamLam()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8032/apipl/List_Swm_Id");
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    _cDAL.ExecuteNonQuery("update sDHN set Valid=0 where IDNCC=4");
                    var obj = jss.Deserialize<dynamic>(result);
                    foreach (var item in obj)
                    {
                        if (checkExists(item["wmid"]) == false)
                            if (string.IsNullOrEmpty(item["idlogger"]))
                                _cDAL.ExecuteNonQuery("insert into sDHN(DanhBo,IDNCC,Valid,CreateBy)values('" + item["wmid"] + "',4,1," + CNguoiDung.MaND + ")");
                            else
                                _cDAL.ExecuteNonQuery("insert into sDHN(DanhBo,IDNCC,IDLogger,Valid,CreateBy)values('" + item["wmid"] + "',4,'" + item["idlogger"] + "',1," + CNguoiDung.MaND + ")");
                        else
                            _cDAL.ExecuteNonQuery("update sDHN set Valid=1,IDLogger='" + item["idlogger"] + "' where DanhBo='" + item["wmid"] + "' and IDNCC=4");
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

        public DataTable get_ChiSoNuoc_PhamLam(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8032/apipl/Volume/" + DanhBo + "/" + Time.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "NoneData")
                    {
                        var obj = jss.Deserialize<dynamic>(result);
                        DataTable dt = new DataTable();
                        dt.Columns.Add("ChiSo", typeof(System.Double));
                        dt.Columns.Add("ThoiGianCapNhat", typeof(System.DateTime));
                        foreach (var item in obj)
                        {
                            DataRow dr = dt.NewRow();
                            dr["ChiSo"] = item["vol"];
                            dr["ThoiGianCapNhat"] = DateTime.Parse(item["timeUpdate"]);
                            dt.Rows.Add(dr);
                        }
                        return dt;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_ChiSoNuoc_PhamLam(string DanhBo, DateTime Time, int Hour)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8032/apipl/Volume/" + DanhBo + "/" + Time.ToString("dd-MM-yyyy") + "/" + Hour);
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "NoneData")
                    {
                        var obj = jss.Deserialize<dynamic>(result);
                        DataTable dt = new DataTable();
                        dt.Columns.Add("ChiSo", typeof(System.Double));
                        dt.Columns.Add("ThoiGianCapNhat", typeof(System.DateTime));
                        DataRow dr = dt.NewRow();
                        dr["ChiSo"] = obj["vol"] ?? DBNull.Value;
                        dr["ThoiGianCapNhat"] = DateTime.Parse(obj["timeUpdate"]);
                        dt.Rows.Add(dr);
                        return dt;
                    }
                    return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable get_ChatLuongSong_PhamLam(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:7032/api/signal_quality?id=" + DanhBo + "&date=" + Time.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "NoneData")
                    {
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
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_CanhBao_PhamLam(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(" http://swm.sawaco.com.vn:8032/apipl/warning/" + DanhBo + "/" + Time.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "NoneData")
                    {
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
                        foreach (var item in obj)
                        {
                            DataRow dr = dt.NewRow();
                            dr["CBPinYeu"] = item["isLowBatt"] ?? DBNull.Value;
                            dr["CBRoRi"] = item["isLeakage"] ?? DBNull.Value;
                            dr["CBQuaDong"] = item["isOverLoad"] ?? DBNull.Value;
                            dr["CBChayNguoc"] = item["isReverse"] ?? DBNull.Value;
                            dr["CBNamCham"] = item["isTampering"] ?? DBNull.Value;
                            dr["CBKhoOng"] = item["isDry"] ?? DBNull.Value;
                            dr["CBMoHop"] = item["isOpenBox"] ?? DBNull.Value;
                            dr["ThoiGianCapNhat"] = DateTime.Parse(item["timeUpdate"]);
                            dt.Rows.Add(dr);
                        }
                        return dt;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_Pin_PhamLam(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api.plwater.vn/battery/" + DanhBo + "/" + Time.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "NoneData")
                    {
                        var obj = jss.Deserialize<dynamic>(result);
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Pin", typeof(System.Int32));
                        dt.Columns.Add("ThoiLuongPinConLai", typeof(System.String));
                        dt.Columns.Add("ThoiGianCapNhat", typeof(System.DateTime));
                        foreach (var item in obj)
                        {
                            DataRow dr = dt.NewRow();
                            dr["Pin"] = obj["batt_percent"];
                            dr["ThoiLuongPinConLai"] = obj["batt_duration"];
                            dr["ThoiGianCapNhat"] = DateTime.Parse(obj["timeUpdate"]);
                            dt.Rows.Add(dr);
                        }
                        return dt;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_All_PhamLam(string DanhBo, DateTime Time)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8032/apipl/swm_hour/" + DanhBo + "/" + Time.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "NoneData")
                    {
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
                            dr["ChiSo"] = item["flow"];
                            //dr["Pin"] = item["Battery"];
                            //dr["ThoiLuongPinConLai"] = item["RemainBatt"];
                            //dr["LuuLuong"] = item["Flow"] ?? DBNull.Value;
                            dr["ChatLuongSong"] = item["rsrp"] ?? DBNull.Value;
                            dr["CBPinYeu"] = item["isLowBatt"] ?? DBNull.Value;
                            dr["CBRoRi"] = item["isLeakage"] ?? DBNull.Value;
                            dr["CBQuaDong"] = item["isOverLoad"] ?? DBNull.Value;
                            dr["CBChayNguoc"] = item["isReverse"] ?? DBNull.Value;
                            dr["CBNamCham"] = item["isTampering"] ?? DBNull.Value;
                            dr["CBKhoOng"] = item["isDry"] ?? DBNull.Value;
                            dr["CBMoHop"] = item["isOpenBox"] ?? DBNull.Value;
                            dr["Longitude"] = item["longitude"] ?? DBNull.Value;
                            dr["Latitude"] = item["latitude"] ?? DBNull.Value;
                            dr["Altitude"] = item["altitude"] ?? DBNull.Value;
                            dr["ChuKy"] = item["interval"] ?? DBNull.Value;
                            dr["ThoiGianCapNhat"] = DateTime.Parse(item["time"]);
                            dt.Rows.Add(dr);
                        }
                        return dt;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_All_PhamLam(string DanhBo, DateTime Time, int Hour)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8032/apipl/swm_hour/" + DanhBo + "/" + Time.ToString("dd-MM-yyyy") + "/" + Hour);
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "NoneData")
                    {
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
                        //foreach (var item in obj)
                        {
                            DataRow dr = dt.NewRow();
                            dr["ChiSo"] = obj["flow"];
                            //dr["Pin"] = item["Battery"];
                            //dr["ThoiLuongPinConLai"] = item["RemainBatt"];
                            //dr["LuuLuong"] = item["Flow"] ?? DBNull.Value;
                            dr["ChatLuongSong"] = obj["rsrp"] ?? DBNull.Value;
                            dr["CBPinYeu"] = obj["isLowBatt"] ?? DBNull.Value;
                            dr["CBRoRi"] = obj["isLeakage"] ?? DBNull.Value;
                            dr["CBQuaDong"] = obj["isOverLoad"] ?? DBNull.Value;
                            dr["CBChayNguoc"] = obj["isReverse"] ?? DBNull.Value;
                            dr["CBNamCham"] = obj["isTampering"] ?? DBNull.Value;
                            dr["CBKhoOng"] = obj["isDry"] ?? DBNull.Value;
                            dr["CBMoHop"] = obj["isOpenBox"] ?? DBNull.Value;
                            dr["Longitude"] = obj["longitude"] ?? DBNull.Value;
                            dr["Latitude"] = obj["latitude"] ?? DBNull.Value;
                            dr["Altitude"] = obj["altitude"] ?? DBNull.Value;
                            dr["ChuKy"] = obj["interval"] ?? DBNull.Value;
                            dr["ThoiGianCapNhat"] = DateTime.Parse(obj["time"]);
                            dt.Rows.Add(dr);
                        }
                        return dt;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_All_PhamLam(string DanhBo, DateTime FromTime, DateTime ToTime)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8032/apipl/All/" + DanhBo + "/" + FromTime.ToString("dd-MM-yyyy") + "/" + ToTime.ToString("dd-MM-yyyy"));
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "NoneData")
                    {
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
                            dr["ChiSo"] = item["flow"];
                            //dr["Pin"] = item["Battery"];
                            //dr["ThoiLuongPinConLai"] = item["RemainBatt"];
                            //dr["LuuLuong"] = item["Flow"] ?? DBNull.Value;
                            dr["ChatLuongSong"] = item["rsrp"] ?? DBNull.Value;
                            dr["CBPinYeu"] = item["isLowBatt"] ?? DBNull.Value;
                            dr["CBRoRi"] = item["isLeakage"] ?? DBNull.Value;
                            dr["CBQuaDong"] = item["isOverLoad"] ?? DBNull.Value;
                            dr["CBChayNguoc"] = item["isReverse"] ?? DBNull.Value;
                            dr["CBNamCham"] = item["isTampering"] ?? DBNull.Value;
                            dr["CBKhoOng"] = item["isDry"] ?? DBNull.Value;
                            dr["CBMoHop"] = item["isOpenBox"] ?? DBNull.Value;
                            dr["Longitude"] = item["longitude"] ?? DBNull.Value;
                            dr["Latitude"] = item["latitude"] ?? DBNull.Value;
                            dr["Altitude"] = item["altitude"] ?? DBNull.Value;
                            dr["ChuKy"] = item["interval"] ?? DBNull.Value;
                            dr["ThoiGianCapNhat"] = DateTime.Parse(item["time"]);
                            dt.Rows.Add(dr);
                        }
                        return dt;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_All_PhamLam(string DanhBo, DateTime FromTime, DateTime ToTime, int Hour)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8032/apipl/All/" + DanhBo + "/" + FromTime.ToString("dd-MM-yyyy") + "/" + ToTime.ToString("dd-MM-yyyy") + "/" + Hour);
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    string result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    if (result != "NoneData")
                    {
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
                            dr["ChiSo"] = item["flow"];
                            //dr["Pin"] = item["Battery"];
                            //dr["ThoiLuongPinConLai"] = item["RemainBatt"];
                            //dr["LuuLuong"] = item["Flow"] ?? DBNull.Value;
                            dr["ChatLuongSong"] = item["rsrp"] ?? DBNull.Value;
                            dr["CBPinYeu"] = item["isLowBatt"] ?? DBNull.Value;
                            dr["CBRoRi"] = item["isLeakage"] ?? DBNull.Value;
                            dr["CBQuaDong"] = item["isOverLoad"] ?? DBNull.Value;
                            dr["CBChayNguoc"] = item["isReverse"] ?? DBNull.Value;
                            dr["CBNamCham"] = item["isTampering"] ?? DBNull.Value;
                            dr["CBKhoOng"] = item["isDry"] ?? DBNull.Value;
                            dr["CBMoHop"] = item["isOpenBox"] ?? DBNull.Value;
                            dr["Longitude"] = item["longitude"] ?? DBNull.Value;
                            dr["Latitude"] = item["latitude"] ?? DBNull.Value;
                            dr["Altitude"] = item["altitude"] ?? DBNull.Value;
                            dr["ChuKy"] = item["interval"] ?? DBNull.Value;
                            dr["ThoiGianCapNhat"] = DateTime.Parse(item["time"]);
                            dt.Rows.Add(dr);
                        }
                        return dt;
                    }
                    else
                        return null;
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

        public DataTable getBaoCao()
        {
            string sql = "select dhn.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,ttkh.NGAYGANDH,ttkh.NGAYTHAY"
+ " ,TieuThuCu=(select SUM(TieuThuMoi) from DocSo where DanhBa=dhn.DanhBo and NAM=2020)"
+ " from sDHN dhn,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh"
+ " where Valid=1 and dhn.DanhBo=ttkh.DANHBO";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

    }
}

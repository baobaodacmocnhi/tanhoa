using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace DocSo_PC.DAL.sDHN
{
    class CsDHN
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();

        #region Hoa Sen

        public void getChiSoNuoc(string DanhBo, DateTime Time)
        {
            string result = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://swm.sawaco.com.vn:8033/api/volume/?id=" + DanhBo + "&date=" + Time.ToString("dd-MM-yyyy"));
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();

                    var obj = jss.Deserialize<dynamic>(result);
                    if (obj["status"] == "OK" || obj["status"] == "ERR:7" || obj["status"] == "ERR:8")
                    {
                    }
                    else
                    {
                    }
                }
                else
                    result = "false;" + respuesta.StatusCode;

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

        #endregion
    }
}

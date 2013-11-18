using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL
{
    class CDAL
    {
        protected static DB_KTKS_DonKHDataContext db = new DB_KTKS_DonKHDataContext();

        ///// <summary>
        ///// Lấy mã tiếp theo, theo định dạng năm-stt (2013-1)
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public string getMaxNextIDTable(string id)
        //{
        //    string[] id_Sub = id.Split('-');
        //    string nam = "";
        //    string stt = "";
        //    if (id_Sub[0] == DateTime.Now.Year.ToString())
        //    {
        //        nam = id_Sub[0];
        //        stt = (int.Parse(id_Sub[1]) + 1).ToString();
        //    }
        //    else
        //    {
        //        nam = DateTime.Now.Year.ToString();
        //        stt = "1";
        //    }
        //    return nam + "-" + stt;
        //}

        /// <summary>
        /// Lấy mã tiếp theo, theo định dạng nămstt (20131)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public decimal getMaxNextIDTable(decimal id)
        {
            string nam = id.ToString().Substring(0,4);
            string stt = id.ToString().Substring(4);
            if (decimal.Parse(nam) == decimal.Parse(DateTime.Now.Year.ToString()))
            {
                stt = (decimal.Parse(stt) + 1).ToString();
            }
            else
            {
                nam = DateTime.Now.Year.ToString();
                stt = "1";
            }
            return decimal.Parse(nam + stt);
        }
    }
}

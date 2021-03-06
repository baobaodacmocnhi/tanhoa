﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_ChungCu.LinQ;

namespace KTKS_ChungCu.DAL
{
    class CDAL
    {
        protected static dbChungCuDataContext db = new dbChungCuDataContext();
        protected static dbDonKHDataContext dbDonKH = new dbDonKHDataContext();
        protected static dbThuTienDataContext dbThuTien = new dbThuTienDataContext();
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
        /// Lấy mã tiếp theo, theo định dạng sttnăm 113(12013)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public decimal getMaxNextIDTable(decimal id)
        {
            string nam = id.ToString().Substring(id.ToString().Length - 2, 2);
            string stt = id.ToString().Substring(0, id.ToString().Length - 2);
            if (decimal.Parse(nam) == decimal.Parse(DateTime.Now.ToString("yy")))
            {
                stt = (decimal.Parse(stt) + 1).ToString();
            }
            else
            {
                stt = "1";
                nam = DateTime.Now.ToString("yy");
            }
            return decimal.Parse(stt + nam);
        }
    }
}

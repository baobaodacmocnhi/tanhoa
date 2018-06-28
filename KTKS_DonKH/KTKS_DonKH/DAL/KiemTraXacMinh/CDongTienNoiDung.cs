using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace KTKS_DonKH.DAL.KiemTraXacMinh
{
    class CDongTienNoiDung : CDAL
    {
        public DataTable getDS(string Loai)
        {
            switch (Loai)
            {
                case "TKH":
                    return LINQToDataTable(db.DongTienNoiDungs.Where(item => item.TKH == true).ToList());
                case "TXL":
                    return LINQToDataTable(db.DongTienNoiDungs.Where(item => item.TXL == true).ToList());
                case "TBC":
                    return LINQToDataTable(db.DongTienNoiDungs.Where(item => item.TBC == true).ToList());
                default:
                    return LINQToDataTable(db.DongTienNoiDungs.ToList());;
            }

        }
    }
}

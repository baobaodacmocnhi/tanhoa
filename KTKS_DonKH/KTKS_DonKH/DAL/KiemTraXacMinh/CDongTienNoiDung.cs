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
                case "ToTB":
                    return LINQToDataTable(db.DongTienNoiDungs.Where(item => item.ToTB == true).ToList());
                case "ToTP":
                    return LINQToDataTable(db.DongTienNoiDungs.Where(item => item.ToTP == true).ToList());
                case "ToBC":
                    return LINQToDataTable(db.DongTienNoiDungs.Where(item => item.ToBC == true).ToList());
                default:
                    return LINQToDataTable(db.DongTienNoiDungs.ToList());
            }

        }

        
    }
}

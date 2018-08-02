using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Data;

namespace KTKS_DonKH.DAL.DonTu
{
    class CNoiChuyen:CDAL
    {
        public List<NoiChuyen> GetDS(string Loai)
        {
            switch (Loai)
            {
                case "DonTuChuyen":
                    return db.NoiChuyens.Where(item => item.DonTuChuyen == true).OrderBy(item => item.STT).ToList();
                case "DonTuNhan":
                    return db.NoiChuyens.Where(item => item.DonTuNhan == true).OrderBy(item => item.STT).ToList();
                case "TKH":
                    return db.NoiChuyens.Where(item=>item.TKH==true).OrderBy(item => item.STT).ToList();
                case "TXL":
                    return db.NoiChuyens.Where(item => item.TXL == true).OrderBy(item => item.STT).ToList();
                case "TBC":
                    return db.NoiChuyens.Where(item => item.TBC == true).OrderBy(item => item.STT).ToList();
                default:
                    return null;
            }
           
        }

        public DataTable GetDS_CT(int ID_NoiChuyen)
        {
            return LINQToDataTable(db.CTNoiChuyens.Where(item => item.ID_NoiChuyen == ID_NoiChuyen).OrderBy(item => item.STT).ToList());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Data;

namespace KTKS_DonKH.DAL.DonTu
{
    class CPhongBanDoi:CDAL
    {
        public DataTable GetDS()
        {
            return LINQToDataTable(db.PhongBanDois.OrderBy(item => item.STT).ToList());
        }
    }
}

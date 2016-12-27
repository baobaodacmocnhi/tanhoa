using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.DonTu
{
    class CPhongBanDoi:CDAL
    {
        public List<PhongBanDoi> GetDS()
        {
            return db.PhongBanDois.OrderBy(item => item.STT).ToList();
        }
    }
}

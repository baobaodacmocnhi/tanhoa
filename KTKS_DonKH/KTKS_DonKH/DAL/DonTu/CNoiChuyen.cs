using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.DonTu
{
    class CNoiChuyen:CDAL
    {
        public List<NoiChuyen> GetDS()
        {
            return db.NoiChuyens.OrderBy(item=>item.STT).ToList();
        }

        
    }
}

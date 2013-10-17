using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.NhapLieu
{
    class CDonKH
    {
        DB_KTKS_DonKHDataContext db = new DB_KTKS_DonKHDataContext();

        public int getMaxID()
        {
            if (db.DonKHs.Count() > 0)
                return db.DonKHs.Max(itemDonKH => itemDonKH.MaDon);
            else
                return 1;
        }
    }
}

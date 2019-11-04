using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL
{
    class CDocSo
    {
        private dbHandHeldDataContext db = new dbHandHeldDataContext();

        public DocSo get(string DanhBo, int Ky, int Nam)
        {
            return db.DocSos.SingleOrDefault(item => item.DanhBa == DanhBo && Convert.ToInt32( item.Ky) == Ky && item.Nam == Nam);
        }
    }
}

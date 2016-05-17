using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL
{
    class CThuTien
    {
        protected static dbThuTienDataContext db = new dbThuTienDataContext();

        public HOADON GetMoiNhat(string DanhBo)
        {
            if (db.HOADONs.Any(item => item.DANHBA == DanhBo))
                return db.HOADONs.Where(item => item.DANHBA == DanhBo).OrderByDescending(item => item.ID_HOADON).First();
            else
                return null;
        }

        public HOADON GetMoiNhat(string DanhBo,int Ky,int Nam)
        {
            if (db.HOADONs.Any(item => item.DANHBA == DanhBo && item.KY==Ky && item.NAM==Nam))
                return db.HOADONs.SingleOrDefault(item => item.DANHBA == DanhBo && item.KY == Ky && item.NAM == Nam);
            else
                return null;
        }

        public decimal GetTieuThuMoiNhat(string DanhBo)
        {
            if (db.HOADONs.Any(item => item.DANHBA == DanhBo))
                return db.HOADONs.Where(item => item.DANHBA == DanhBo).OrderByDescending(item => item.ID_HOADON).First().TIEUTHU.Value;
            else
                return 0;
        }
    }
}

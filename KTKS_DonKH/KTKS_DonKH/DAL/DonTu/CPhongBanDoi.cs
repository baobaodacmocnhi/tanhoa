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
        public DataTable getDS_ConfigChuongTrinh()
        {
            return LINQToDataTable(db.Phongs.ToList());
        }

        public string getTenPhong_ConfigChuongTrinh(int MaPhong)
        {
            return db.Phongs.SingleOrDefault(item => item.ID == MaPhong).Name;
        }

        public DataTable GetDS()
        {
            return LINQToDataTable(db.PhongBanDois.OrderBy(item => item.STT).ToList());
        }
    }
}

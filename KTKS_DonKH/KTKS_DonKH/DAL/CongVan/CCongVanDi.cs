using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;
using System.Data;

namespace KTKS_DonKH.DAL.CongVan
{
    class CCongVanDi : CDAL
    {
        public bool Them(CongVanDi item)
        {
            try
            {
                if (db.CongVanDis.Count() > 0)
                    item.ID = db.CongVanDis.Max(item2 => item2.ID) + 1;
                else
                    item.ID = 1;
                item.CreateDate = DateTime.Now;
                item.CreateBy = CTaiKhoan.MaUser;
                db.CongVanDis.InsertOnSubmit(item);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Sua(CongVanDi item)
        {
            try
            {
                item.ModifyDate = DateTime.Now;
                item.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Xoa(CongVanDi item)
        {
            try
            {
                db.CongVanDis.DeleteOnSubmit(item);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public CongVanDi Get(int ID)
        {
            return db.CongVanDis.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetDS(DateTime FromCreateDate,int ToHour, DateTime ToCreateDate,int FromHour)
        {
            return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(db.CongVanDis.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.CreateDate.Value.Hour >= ToHour && item.CreateDate.Value.Hour <= FromHour).ToList());
        }

        public DataTable GetDS(string DanhBo)
        {
            return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(db.CongVanDis.Where(item=>item.DanhBo==DanhBo).ToList());
        }

        public DataTable GetDS_Ma(string Ma)
        {
            return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(db.CongVanDis.Where(item => item.Ma == Ma).ToList());
        }

        public DataTable GetDSDonKH(decimal MaDon)
        {
            return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(db.CongVanDis.Where(item => item.MaDon == MaDon).ToList());
        }

        public DataTable GetDSDonTXL(decimal MaDonTXL)
        {
            return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(db.CongVanDis.Where(item => item.MaDonTXL == MaDonTXL).ToList());
        }

        public DataTable GetDSNoiDung()
        {
            return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(db.CongVanDis.Select(item => new { item.NoiDung }).ToList().Distinct());
        }
    }
}

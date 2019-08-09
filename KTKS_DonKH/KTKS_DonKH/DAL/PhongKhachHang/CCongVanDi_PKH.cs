using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.PhongKhachHang
{
    class CCongVanDi_PKH : CDAL
    {
        public bool Them(PKH_CongVanDi item)
        {
            try
            {
                if (db.PKH_CongVanDis.Count() > 0)
                    item.ID = db.PKH_CongVanDis.Max(item2 => item2.ID) + 1;
                else
                    item.ID = 1;
                item.CreateDate = DateTime.Now;
                item.CreateBy = CTaiKhoan.MaUser;
                db.PKH_CongVanDis.InsertOnSubmit(item);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Them(PKH_CongVanDi item, DateTime CreateDate)
        {
            try
            {
                if (db.PKH_CongVanDis.Count() > 0)
                    item.ID = db.PKH_CongVanDis.Max(item2 => item2.ID) + 1;
                else
                    item.ID = 1;
                item.CreateDate = CreateDate;
                item.CreateBy = CTaiKhoan.MaUser;
                db.PKH_CongVanDis.InsertOnSubmit(item);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Sua(PKH_CongVanDi item)
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

        public bool Xoa(PKH_CongVanDi item)
        {
            try
            {
                db.PKH_CongVanDis.DeleteOnSubmit(item);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckExist(string LoaiVanBan, string Ma, string NoiChuyen, DateTime CreateDate)
        {
            return db.PKH_CongVanDis.Any(item => item.LoaiVanBan == LoaiVanBan && item.Ma == Ma && item.NoiChuyen == NoiChuyen && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public PKH_CongVanDi Get(int ID)
        {
            return db.PKH_CongVanDis.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetDS(DateTime FromCreateDate, int FromHour, DateTime ToCreateDate, int ToHour)
        {
            DateTime FromDate = new DateTime(FromCreateDate.Year, FromCreateDate.Month, FromCreateDate.Day, FromHour, 0, 0);
            DateTime ToDate = new DateTime(ToCreateDate.Year, ToCreateDate.Month, ToCreateDate.Day, ToHour, 0, 0);
            return LINQToDataTable(db.PKH_CongVanDis.Where(item => item.CreateDate.Value >= FromDate && item.CreateDate.Value <= ToDate).ToList());
        }

        public DataTable GetDS(int CreateBy, DateTime FromCreateDate, int FromHour, DateTime ToCreateDate, int ToHour)
        {
            DateTime FromDate = new DateTime(FromCreateDate.Year, FromCreateDate.Month, FromCreateDate.Day, FromHour, 0, 0);
            DateTime ToDate = new DateTime(ToCreateDate.Year, ToCreateDate.Month, ToCreateDate.Day, ToHour, 0, 0);
            return LINQToDataTable(db.PKH_CongVanDis.Where(item => item.CreateBy == CreateBy && item.CreateDate.Value >= FromDate && item.CreateDate.Value <= ToDate).ToList());
        }

        public DataTable GetDS(string DanhBo)
        {
            return LINQToDataTable(db.PKH_CongVanDis.Where(item => item.DanhBo == DanhBo).ToList());
        }

        public DataTable GetDS(int CreateBy, string DanhBo)
        {
            return LINQToDataTable(db.PKH_CongVanDis.Where(item => item.CreateBy == CreateBy && item.DanhBo == DanhBo).ToList());
        }

        public DataTable GetDS_Ma(string Ma)
        {
            return LINQToDataTable(db.PKH_CongVanDis.Where(item => item.Ma == Ma).ToList());
        }

        public DataTable GetDS_Ma(int CreateBy, string Ma)
        {
            return LINQToDataTable(db.PKH_CongVanDis.Where(item => item.CreateBy == CreateBy && item.Ma == Ma).ToList());
        }

        public DataTable GetDSNoiDung()
        {
            return LINQToDataTable(db.PKH_CongVanDis.Select(item => new { item.NoiDung }).ToList().Distinct());
        }
    }
}

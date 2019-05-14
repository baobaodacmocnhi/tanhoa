using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
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

        public bool Them(CongVanDi item,DateTime CreateDate)
        {
            try
            {
                if (db.CongVanDis.Count() > 0)
                    item.ID = db.CongVanDis.Max(item2 => item2.ID) + 1;
                else
                    item.ID = 1;
                item.CreateDate = CreateDate;
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

        public bool CheckExist(string LoaiVanBan,string Ma,string NoiChuyen,DateTime CreateDate)
        {
            return db.CongVanDis.Any(item => item.LoaiVanBan == LoaiVanBan && item.Ma == Ma &&item.NoiChuyen==NoiChuyen&& item.CreateDate.Value.Date == CreateDate.Date);
        }

        public CongVanDi Get(int ID)
        {
            return db.CongVanDis.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetDS(DateTime FromCreateDate,int FromHour, DateTime ToCreateDate,int ToHour)
        {
            DateTime FromDate = new DateTime(FromCreateDate.Year, FromCreateDate.Month, FromCreateDate.Day, FromHour, 0, 0);
            DateTime ToDate = new DateTime(ToCreateDate.Year, ToCreateDate.Month, ToCreateDate.Day, ToHour, 0, 0);
            return LINQToDataTable(db.CongVanDis.Where(item => item.CreateDate.Value >= FromDate && item.CreateDate.Value <= ToDate).ToList());
        }

        public DataTable GetDS(int CreateBy,DateTime FromCreateDate, int FromHour, DateTime ToCreateDate, int ToHour)
        {
            DateTime FromDate = new DateTime(FromCreateDate.Year, FromCreateDate.Month, FromCreateDate.Day, FromHour, 0, 0);
            DateTime ToDate = new DateTime(ToCreateDate.Year, ToCreateDate.Month, ToCreateDate.Day, ToHour, 0, 0);
            return LINQToDataTable(db.CongVanDis.Where(item => item.CreateBy==CreateBy && item.CreateDate.Value >= FromDate && item.CreateDate.Value <= ToDate).ToList());
        }

        public DataTable GetDS(string DanhBo)
        {
            return LINQToDataTable(db.CongVanDis.Where(item=>item.DanhBo==DanhBo).ToList());
        }

        public DataTable GetDS(int CreateBy,string DanhBo)
        {
            return LINQToDataTable(db.CongVanDis.Where(item => item.CreateBy == CreateBy && item.DanhBo == DanhBo).ToList());
        }

        public DataTable GetDS_Ma(string Ma)
        {
            return LINQToDataTable(db.CongVanDis.Where(item => item.Ma == Ma).ToList());
        }

        public DataTable GetDS_Ma(int CreateBy, string Ma)
        {
            return LINQToDataTable(db.CongVanDis.Where(item => item.CreateBy == CreateBy && item.Ma == Ma).ToList());
        }

        public DataTable GetDSDonKH(decimal MaDon)
        {
            return LINQToDataTable(db.CongVanDis.Where(item => item.MaDon == MaDon).ToList());
        }

        public DataTable GetDSDonTXL(decimal MaDonTXL)
        {
            return LINQToDataTable(db.CongVanDis.Where(item => item.MaDonTXL == MaDonTXL).ToList());
        }

        public DataTable GetDSNoiDung()
        {
            return LINQToDataTable(db.CongVanDis.Select(item => new { item.NoiDung }).ToList().Distinct());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.DonTu
{
    class CLichSuDonTu:CDAL
    {
        public bool Them(LichSuDonTu entity)
        {
            try
            {
                if (db.LichSuDonTus.Count() == 0)
                    entity.ID = 1;
                else
                    entity.ID = db.LichSuDonTus.Max(item => item.ID) + 1;
                entity.CreateBy = CTaiKhoan.MaUser;
                entity.CreateDate = DateTime.Now;
                db.LichSuDonTus.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Xoa(LichSuDonTu entity)
        {
            try
            {
                db.LichSuDonTus.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckExist(DateTime NgayChuyen,int ID_NoiChuyen,int ID_NoiNhan)
        {
            return db.LichSuDonTus.Any(item => item.NgayChuyen.Value.Date == NgayChuyen.Date && item.ID_NoiChuyen == ID_NoiChuyen && item.ID_NoiNhan == ID_NoiNhan);
        }

        public LichSuDonTu Get(int ID)
        {
            return db.LichSuDonTus.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetDS(bool ToXuLy, Decimal MaDon)
        {
            if (ToXuLy == true)
                return LINQToDataTable(db.LichSuDonTus.Where(item => item.MaDonTXL.Value == MaDon).OrderByDescending(item=>item.CreateDate).ToList());
            else
                return LINQToDataTable(db.LichSuDonTus.Where(item => item.MaDon.Value == MaDon).OrderByDescending(item => item.CreateDate).ToList());
        }
    }
}

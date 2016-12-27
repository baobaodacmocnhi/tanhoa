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

        public DataTable GetDS(bool ToXuLy, Decimal MaDon)
        {
            if (ToXuLy == true)
                return LINQToDataTable(db.LichSuDonTus.Where(item => item.MaDonTXL.Value == MaDon).ToList());
            else
                return LINQToDataTable(db.LichSuDonTus.Where(item => item.MaDon.Value == MaDon).ToList());
        }
    }
}

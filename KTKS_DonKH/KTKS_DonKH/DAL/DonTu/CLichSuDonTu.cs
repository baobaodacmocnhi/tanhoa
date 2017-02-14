using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.DonTu
{
    class CLichSuDonTu : CDAL
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

        public bool CheckExist(DateTime NgayChuyen, int ID_NoiChuyen, int ID_NoiNhan)
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
                return LINQToDataTable(db.LichSuDonTus.Where(item => item.MaDonTXL.Value == MaDon).OrderByDescending(item => item.NgayChuyen).ToList());
            else
                return LINQToDataTable(db.LichSuDonTus.Where(item => item.MaDon.Value == MaDon).OrderByDescending(item => item.NgayChuyen).ToList());
        }

        public DataTable GetDS(bool ToXuLy, DateTime FromNgayChuyen, DateTime ToNgayChuyen)
        {
            if (ToXuLy == true)
            {
                var query = from itemLichSuDon in db.LichSuDonTus
                            join itemDonTXL in db.DonTXLs on itemLichSuDon.MaDonTXL equals itemDonTXL.MaDon
                            where itemLichSuDon.MaDonTXL != null && itemLichSuDon.NgayChuyen.Value.Date >= FromNgayChuyen.Date && itemLichSuDon.NgayChuyen.Value.Date <= ToNgayChuyen.Date
                            orderby itemLichSuDon.NgayChuyen ascending
                            select new
                            {
                                itemDonTXL.MaDon,
                                itemDonTXL.LoaiDonTXL.TenLD,
                                itemDonTXL.DanhBo,
                                itemDonTXL.HoTen,
                                itemDonTXL.DiaChi,
                                itemLichSuDon.NgayChuyen,
                                itemLichSuDon.NoiChuyen,
                                itemLichSuDon.NoiNhan,
                            };
                return LINQToDataTable(query.ToList());
            }
            else
            {
                var query = from itemLichSuDon in db.LichSuDonTus
                            join itemDonKH in db.DonKHs on itemLichSuDon.MaDon equals itemDonKH.MaDon
                            where itemLichSuDon.MaDon != null && itemLichSuDon.NgayChuyen.Value.Date >= FromNgayChuyen.Date && itemLichSuDon.NgayChuyen.Value.Date <= ToNgayChuyen.Date
                            orderby itemLichSuDon.NgayChuyen ascending
                            select new
                            {
                                itemDonKH.MaDon,
                                itemDonKH.LoaiDon.TenLD,
                                itemDonKH.DanhBo,
                                itemDonKH.HoTen,
                                itemDonKH.DiaChi,
                                itemLichSuDon.NgayChuyen,
                                itemLichSuDon.NoiChuyen,
                                itemLichSuDon.NoiNhan,
                            };
                return LINQToDataTable(query.ToList());
            }
        }
    }
}

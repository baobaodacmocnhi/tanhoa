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

        public DataTable GetDS(string Loai, Decimal MaDon)
        {
            DataTable dt = new DataTable();
            switch (Loai)
            {
                case "TKH":
                    dt = LINQToDataTable(db.LichSuDonTus.Where(item => item.MaDon.Value == MaDon).OrderByDescending(item => item.NgayChuyen).ToList());
                    break;
                case "TXL":
                    dt = LINQToDataTable(db.LichSuDonTus.Where(item => item.MaDonTXL.Value == MaDon).OrderByDescending(item => item.NgayChuyen).ToList());
                    break;
                case "TBC":
                    dt = LINQToDataTable(db.LichSuDonTus.Where(item => item.MaDonTBC.Value == MaDon).OrderByDescending(item => item.NgayChuyen).ToList());
                    break;
            }
            return dt;
        }

        public DataTable GetDS(string Loai, DateTime FromNgayChuyen, DateTime ToNgayChuyen)
        {
            DataTable dt = new DataTable();
            switch (Loai)
            {
                case "TKH":
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
                                    itemLichSuDon.GhiChu,
                                };
                    dt = LINQToDataTable(query.ToList());
                    break;
                case "TXL":
                    query = from itemLichSuDon in db.LichSuDonTus
                            join itemDonTXL in db.DonTXLs on itemLichSuDon.MaDonTXL equals itemDonTXL.MaDon
                            where itemLichSuDon.MaDonTXL != null && itemLichSuDon.NgayChuyen.Value.Date >= FromNgayChuyen.Date && itemLichSuDon.NgayChuyen.Value.Date <= ToNgayChuyen.Date
                            && itemLichSuDon.ID_NoiChuyen != 1
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
                                itemLichSuDon.GhiChu,
                            };
                    dt = LINQToDataTable(query.ToList());
                    break;
                case "TBC":
                    query = from itemLichSuDon in db.LichSuDonTus
                            join itemDonTBC in db.DonTBCs on itemLichSuDon.MaDonTBC equals itemDonTBC.MaDon
                            where itemLichSuDon.MaDonTBC != null && itemLichSuDon.NgayChuyen.Value.Date >= FromNgayChuyen.Date && itemLichSuDon.NgayChuyen.Value.Date <= ToNgayChuyen.Date
                            && itemLichSuDon.ID_NoiChuyen != 1
                            orderby itemLichSuDon.NgayChuyen ascending
                            select new
                            {
                                itemDonTBC.MaDon,
                                itemDonTBC.LoaiDonTBC.TenLD,
                                itemDonTBC.DanhBo,
                                itemDonTBC.HoTen,
                                itemDonTBC.DiaChi,
                                itemLichSuDon.NgayChuyen,
                                itemLichSuDon.NoiChuyen,
                                itemLichSuDon.NoiNhan,
                                itemLichSuDon.GhiChu,
                            };
                    dt = LINQToDataTable(query.ToList());
                    break;
            }
            return dt;
        }



        public bool Them(LichSuChuyenKT lichsuchuyenkt)
        {
            try
            {
                if (db.LichSuChuyenKTs.Count() > 0)
                {
                    string ID = "MaLSChuyen";
                    string Table = "LichSuChuyenKT";
                    decimal MaLSChuyen = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    lichsuchuyenkt.MaLSChuyen = getMaxNextIDTable(MaLSChuyen);
                }
                else
                    lichsuchuyenkt.MaLSChuyen = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                lichsuchuyenkt.CreateDate = DateTime.Now;
                lichsuchuyenkt.CreateBy = CTaiKhoan.MaUser;
                db.LichSuChuyenKTs.InsertOnSubmit(lichsuchuyenkt);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                Refresh();
                return false;
            }
        }

        public bool Sua(LichSuChuyenKT lichsuchuyenkt)
        {
            try
            {
                lichsuchuyenkt.ModifyDate = DateTime.Now;
                lichsuchuyenkt.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                Refresh();
                return false;
            }
        }

        public bool Xoa(LichSuChuyenKT lichsuchuyenkt)
        {
            try
            {
                db.LichSuChuyenKTs.DeleteOnSubmit(lichsuchuyenkt);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                Refresh();
                return false;
            }
        }

        public LichSuChuyenKT Get(decimal MaLSChuyenKT)
        {
            try
            {
                return db.LichSuChuyenKTs.SingleOrDefault(item => item.MaLSChuyen == MaLSChuyenKT);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

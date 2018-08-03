using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.ThuMoi
{
    class CThuMoi:CDAL
    {
        public bool Them(LinQ.ThuMoi entity)
        {
            try
            {
                if (db.ThuMois.Count() > 0)
                {
                    entity.ID = db.ThuMois.Max(item => item.ID) + 1;
                    if (entity.MaDonTKH != null)
                    {
                        if (db.ThuMois.Any(item => item.MaDonTKH == entity.MaDonTKH) == false)
                            entity.Lan = 2;
                        else
                            entity.Lan = db.ThuMois.Where(item => item.MaDonTKH == entity.MaDonTKH).Count() + 1;
                    }
                    else
                        if (entity.MaDonTXL != null)
                        {
                            if (db.ThuMois.Any(item => item.MaDonTXL == entity.MaDonTXL) == false)
                                entity.Lan = 2;
                            else
                                entity.Lan = db.ThuMois.Where(item => item.MaDonTXL == entity.MaDonTXL).Count() + 1;
                        }
                        else
                            if (entity.MaDonTBC != null)
                            {
                                if (db.ThuMois.Any(item => item.MaDonTBC == entity.MaDonTBC) == false)
                                    entity.Lan = 2;
                                else
                                    entity.Lan = db.ThuMois.Where(item => item.MaDonTBC == entity.MaDonTBC).Count() + 1;
                            }
                }
                else
                {
                    entity.ID = 1;
                    entity.Lan = 2;
                }
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.ThuMois.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(LinQ.ThuMoi entity)
        {
            try
            {
                entity.ModifyDate = DateTime.Now;
                entity.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(LinQ.ThuMoi entity)
        {
            try
            {
                db.ThuMois.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public LinQ.ThuMoi Get(int ID)
        {
            return db.ThuMois.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetDS(string To, decimal MaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from item in db.ThuMois
                                where item.MaDonTKH == MaDon
                                select new
                                {
                                    MaDon = item.MaDonTKH != null ? "TKH" + item.MaDonTKH
                                        : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                        : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                                        item.ID,
                                    item.DanhBo,
                                    item.HoTen,
                                    item.DiaChi,
                                    item.GiaBieu,
                                    item.DinhMuc,
                                    item.Lan,
                                    item.CanCu,
                                    item.VaoLuc,
                                    item.VeViec,
                                    item.CreateDate,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    var query2 = from item in db.ThuMois
                                 where item.MaDonTXL == MaDon
                                 select new
                                 {
                                     MaDon = item.MaDonTKH != null ? "TKH" + item.MaDonTKH
                                         : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                         : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                                     item.ID,
                                     item.DanhBo,
                                     item.HoTen,
                                     item.DiaChi,
                                     item.GiaBieu,
                                     item.DinhMuc,
                                     item.Lan,
                                     item.CanCu,
                                     item.VaoLuc,
                                     item.VeViec,
                                     item.CreateDate,
                                 };
                    return LINQToDataTable(query2);
                case "TBC":
                    var query3 = from item in db.ThuMois
                                 where item.MaDonTBC == MaDon
                                 select new
                                 {
                                     MaDon = item.MaDonTKH != null ? "TKH" + item.MaDonTKH
                                         : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                         : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                                     item.ID,
                                     item.DanhBo,
                                     item.HoTen,
                                     item.DiaChi,
                                     item.GiaBieu,
                                     item.DinhMuc,
                                     item.Lan,
                                     item.CanCu,
                                     item.VaoLuc,
                                     item.VeViec,
                                     item.CreateDate,
                                 };
                    return LINQToDataTable(query3);
                default:
                    return null;
            }
        }

        public DataTable GetDS(string DanhBo)
        {
            var query = from item in db.ThuMois
                        where item.DanhBo == DanhBo
                        select new
                        {
                            MaDon = item.MaDonTKH != null ? "TKH" + item.MaDonTKH
                                : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                            item.ID,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.GiaBieu,
                            item.DinhMuc,
                            item.Lan,
                            item.CanCu,
                            item.VaoLuc,
                            item.VeViec,
                            item.CreateDate,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime FromCreatDate, DateTime ToCreateDate)
        {
            var query = from item in db.ThuMois
                        where item.CreateDate.Value.Date >= FromCreatDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.MaDonTKH != null ? "TKH" + item.MaDonTKH
                                : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                            item.ID,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.GiaBieu,
                            item.DinhMuc,
                            item.Lan,
                            item.CanCu,
                            item.VaoLuc,
                            item.VeViec,
                            item.CreateDate,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(int CreateBy,DateTime FromCreatDate, DateTime ToCreateDate)
        {
            var query = from item in db.ThuMois
                        where item.CreateBy==CreateBy&&item.CreateDate.Value.Date >= FromCreatDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.MaDonTKH != null ? "TKH" + item.MaDonTKH
                                : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                            item.ID,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.GiaBieu,
                            item.DinhMuc,
                            item.Lan,
                            item.CanCu,
                            item.VaoLuc,
                            item.VeViec,
                            item.CreateDate,
                        };
            return LINQToDataTable(query);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.ToXuLy
{
    class CGianLan : CDAL
    {
        public bool Them(GianLan entity)
        {
            try
            {
                if (db.GianLans.Count() > 0)
                    entity.ID = db.GianLans.Max(item => item.ID) + 1;
                else
                    entity.ID = 1;
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.GianLans.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool Sua(GianLan entity)
        {
            try
            {
                entity.ModifyDate = DateTime.Now;
                entity.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool Xoa(GianLan entity)
        {
            try
            {
                db.GianLans.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public GianLan Get(int ID)
        {
            return db.GianLans.SingleOrDefault(item => item.ID == ID);
        }

        public GianLan Get(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.GianLans.SingleOrDefault(item => item.MaDon == MaDon);
                case "TXL":
                    return db.GianLans.SingleOrDefault(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.GianLans.SingleOrDefault(item => item.MaDonTBC == MaDon);
                default:
                    return null;
            }
        }

        public GianLan Get(string MaDonMoi)
        {
            return db.GianLans.SingleOrDefault(item => item.MaDon_New == MaDonMoi);
        }

        public bool CheckExist(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.GianLans.Any(item => item.MaDon == MaDon);
                case "TXL":
                    return db.GianLans.Any(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.GianLans.Any(item => item.MaDonTBC == MaDon);
                default:
                    return false;
            }
        }

        public bool CheckExist(string MaDonMoi)
        {
            return db.GianLans.Any(item => item.MaDon_New == MaDonMoi);
        }

        public DataTable GetDS(string DanhBo)
        {
            var query = from item in db.GianLans
                        where item.DanhBo == DanhBo
                        select new
                        {
                            item.ID,
                            MaDon = item.MaDon != null ? "TKH" + item.MaDon
                                    : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                    : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDungViPham,
                            item.TinhTrang,
                            item.XepDon,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.GianLans
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            item.ID,
                            MaDon = item.MaDon != null ? "TKH" + item.MaDon
                                    : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                    : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDungViPham,
                            item.TinhTrang,
                            item.XepDon,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSNoiDungViPham()
        {
            return LINQToDataTable(db.GianLans.Select(item => new { item.NoiDungViPham }).ToList().Distinct());
        }

        public DataTable GetDSTinhTrang()
        {
            return LINQToDataTable(db.GianLans.Select(item => new { item.TinhTrang }).ToList().Distinct());
        }
    }
}

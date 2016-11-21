using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.ToXuLy
{
    class CGianLan:CDAL
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
            return db.GianLans.SingleOrDefault(item=>item.ID==ID);
        }

        public GianLan Get(decimal MaDon)
        {
            return db.GianLans.SingleOrDefault(item => item.MaDon == MaDon);
        }

        public GianLan Get_TXL(decimal MaDonTXL)
        {
            return db.GianLans.SingleOrDefault(item => item.MaDonTXL == MaDonTXL);
        }

        public bool CheckExist(decimal MaDon)
        {
            return db.GianLans.Any(item => item.MaDon == MaDon);
        }

        public bool CheckExist_TXL(decimal MaDonTXL)
        {
            return db.GianLans.Any(item => item.MaDonTXL == MaDonTXL);
        }

        public DataTable GetDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            DataTable dt = new DataTable();

            var query = from item in db.GianLans
                        where item.ToXuLy == false && item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            item.ID,
                            item.ToXuLy,
                            MaDon=item.MaDon,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDungViPham,
                            item.TinhTrang,
                        };
            dt = LINQToDataTable(query.ToList());

            var queryTXL = from item in db.GianLans
                        where item.ToXuLy == true && item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            item.ID,
                            item.ToXuLy,
                            MaDon = item.MaDonTXL,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDungViPham,
                            item.TinhTrang,
                        };
            dt.Merge( LINQToDataTable(queryTXL.ToList()));

            return dt;
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

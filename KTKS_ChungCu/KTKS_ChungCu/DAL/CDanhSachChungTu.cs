using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_ChungCu.LinQ;
using System.Data;

namespace KTKS_ChungCu.DAL
{
    class CDanhSachChungTu:CDAL
    {
        public bool Them(DanhSachChungTu entity)
        {
            try
            {
                if (db.DanhSachChungTus.Count() > 0)
                    entity.ID = db.DanhSachChungTus.Max(item => item.ID) + 1;
                else
                    entity.ID = 1;
                entity.CreateDate = DateTime.Now;
                db.DanhSachChungTus.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Sua(DanhSachChungTu entity)
        {
            try
            {
                entity.ModifyDate = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Xoa(DanhSachChungTu entity)
        {
            try
            {
                db.DanhSachChungTus.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DanhSachChungTu Get(int ID)
        {
            return db.DanhSachChungTus.SingleOrDefault(item => item.ID == ID);
        }

        public List<DanhSachChungTu> GetDS(string MaCT)
        {
            return db.DanhSachChungTus.Where(itemCT => itemCT.MaCT == MaCT).ToList();
        }

        public DataTable LoadDSChungTu_DB(string DanhBo)
        {
            try
            {
                var query = from itemCTCT in db.DanhSachChungTus
                            where itemCTCT.DanhBo == DanhBo
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.ID,
                                itemCTCT.STT,
                                itemCTCT.DanhBo,
                                itemCTCT.Lo,
                                itemCTCT.Phong,
                                itemCTCT.MaLCT,
                                itemCTCT.MaCT,
                                itemCTCT.HoTen,
                                itemCTCT.SoNKTong,
                                itemCTCT.SoNKDangKy,
                                itemCTCT.NgayHetHan,
                                itemCTCT.ThoiHan,
                                itemCTCT.GhiChu,
                            };
                return Function.CLinQToDataTable.LINQToDataTable(query);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable LoadDSChungTu_DB_Lo(string DanhBo, string Lo)
        {
            try
            {
                var query = from itemCTCT in db.DanhSachChungTus
                            where itemCTCT.DanhBo == DanhBo && itemCTCT.Lo == Lo
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.ID,
                                itemCTCT.STT,
                                itemCTCT.DanhBo,
                                itemCTCT.Lo,
                                itemCTCT.Phong,
                                itemCTCT.MaLCT,
                                itemCTCT.MaCT,
                                itemCTCT.HoTen,
                                itemCTCT.SoNKTong,
                                itemCTCT.SoNKDangKy,
                                itemCTCT.NgayHetHan,
                                itemCTCT.ThoiHan,
                                itemCTCT.GhiChu,
                            };
                return Function.CLinQToDataTable.LINQToDataTable(query);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable LoadDSChungTu_CT(string MaCT)
        {
            try
            {
                var query = from itemCTCT in db.DanhSachChungTus
                            where itemCTCT.MaCT == MaCT
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.ID,
                                itemCTCT.STT,
                                itemCTCT.DanhBo,
                                itemCTCT.Lo,
                                itemCTCT.Phong,
                                itemCTCT.MaLCT,
                                itemCTCT.MaCT,
                                itemCTCT.HoTen,
                                itemCTCT.SoNKTong,
                                itemCTCT.SoNKDangKy,
                                itemCTCT.NgayHetHan,
                                itemCTCT.ThoiHan,
                                itemCTCT.GhiChu,
                            };
                return Function.CLinQToDataTable.LINQToDataTable(query);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable LoadDSChungTu_CT(string DanhBo, string MaCT)
        {
            try
            {
                var query = from itemCTCT in db.DanhSachChungTus
                            where itemCTCT.DanhBo == DanhBo && itemCTCT.MaCT == MaCT
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.ID,
                                itemCTCT.STT,
                                itemCTCT.DanhBo,
                                itemCTCT.Lo,
                                itemCTCT.Phong,
                                itemCTCT.MaLCT,
                                itemCTCT.MaCT,
                                itemCTCT.HoTen,
                                itemCTCT.SoNKTong,
                                itemCTCT.SoNKDangKy,
                                itemCTCT.NgayHetHan,
                                itemCTCT.ThoiHan,
                                itemCTCT.GhiChu,
                            };
                return Function.CLinQToDataTable.LINQToDataTable(query);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable LoadDSChungTu_HoTen(string HoTen)
        {
            try
            {
                var query = from itemCTCT in db.DanhSachChungTus
                            where itemCTCT.HoTen == HoTen
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.ID,
                                itemCTCT.STT,
                                itemCTCT.DanhBo,
                                itemCTCT.Lo,
                                itemCTCT.Phong,
                                itemCTCT.MaLCT,
                                itemCTCT.MaCT,
                                itemCTCT.HoTen,
                                itemCTCT.SoNKTong,
                                itemCTCT.SoNKDangKy,
                                itemCTCT.NgayHetHan,
                                itemCTCT.ThoiHan,
                                itemCTCT.GhiChu,
                            };
                return Function.CLinQToDataTable.LINQToDataTable(query);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable LoadDSChungTu_Lo(string Lo)
        {
            try
            {
                var query = from itemCTCT in db.DanhSachChungTus
                            where itemCTCT.Lo == Lo
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.ID,
                                itemCTCT.STT,
                                itemCTCT.DanhBo,
                                itemCTCT.Lo,
                                itemCTCT.Phong,
                                itemCTCT.MaLCT,
                                itemCTCT.MaCT,
                                itemCTCT.HoTen,
                                itemCTCT.SoNKTong,
                                itemCTCT.SoNKDangKy,
                                itemCTCT.NgayHetHan,
                                itemCTCT.ThoiHan,
                                itemCTCT.GhiChu,
                            };
                return Function.CLinQToDataTable.LINQToDataTable(query);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable LoadDSChungTu_Lo(string DanhBo, string Lo)
        {
            try
            {
                var query = from itemCTCT in db.DanhSachChungTus
                            where itemCTCT.DanhBo == DanhBo && itemCTCT.Lo == Lo
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.ID,
                                itemCTCT.STT,
                                itemCTCT.DanhBo,
                                itemCTCT.Lo,
                                itemCTCT.Phong,
                                itemCTCT.MaLCT,
                                itemCTCT.MaCT,
                                itemCTCT.HoTen,
                                itemCTCT.SoNKTong,
                                itemCTCT.SoNKDangKy,
                                itemCTCT.NgayHetHan,
                                itemCTCT.ThoiHan,
                                itemCTCT.GhiChu,
                            };
                return Function.CLinQToDataTable.LINQToDataTable(query);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable LoadDSChungTu_Phong(string Phong)
        {
            try
            {
                var query = from itemCTCT in db.DanhSachChungTus
                            where itemCTCT.Phong == Phong
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.ID,
                                itemCTCT.STT,
                                itemCTCT.DanhBo,
                                itemCTCT.Lo,
                                itemCTCT.Phong,
                                itemCTCT.MaLCT,
                                itemCTCT.MaCT,
                                itemCTCT.HoTen,
                                itemCTCT.SoNKTong,
                                itemCTCT.SoNKDangKy,
                                itemCTCT.NgayHetHan,
                                itemCTCT.ThoiHan,
                                itemCTCT.GhiChu,
                            };
                return Function.CLinQToDataTable.LINQToDataTable(query);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable LoadDSChungTu_Phong(string DanhBo, string Phong)
        {
            try
            {
                var query = from itemCTCT in db.DanhSachChungTus
                            where itemCTCT.DanhBo == DanhBo && itemCTCT.Phong == Phong
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.ID,
                                itemCTCT.STT,
                                itemCTCT.DanhBo,
                                itemCTCT.Lo,
                                itemCTCT.Phong,
                                itemCTCT.MaLCT,
                                itemCTCT.MaCT,
                                itemCTCT.HoTen,
                                itemCTCT.SoNKTong,
                                itemCTCT.SoNKDangKy,
                                itemCTCT.NgayHetHan,
                                itemCTCT.ThoiHan,
                                itemCTCT.GhiChu,
                            };
                return Function.CLinQToDataTable.LINQToDataTable(query);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable LoadDSChungTu_STT(string DanhBo, string Lo, int STT)
        {
            try
            {
                var query = from itemCTCT in db.DanhSachChungTus
                            where itemCTCT.DanhBo == DanhBo && itemCTCT.STT == STT && itemCTCT.Lo == Lo
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.ID,
                                itemCTCT.STT,
                                itemCTCT.DanhBo,
                                itemCTCT.Lo,
                                itemCTCT.Phong,
                                itemCTCT.MaLCT,
                                itemCTCT.MaCT,
                                itemCTCT.HoTen,
                                itemCTCT.SoNKTong,
                                itemCTCT.SoNKDangKy,
                                itemCTCT.NgayHetHan,
                                itemCTCT.ThoiHan,
                                itemCTCT.GhiChu,
                            };
                return Function.CLinQToDataTable.LINQToDataTable(query);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable LoadDSChungTu_STTs(string DanhBo, string Lo, int TuSTT, int DenSTT)
        {
            try
            {
                var query = from itemCTCT in db.DanhSachChungTus
                            where itemCTCT.DanhBo == DanhBo && itemCTCT.STT >= TuSTT && itemCTCT.STT <= DenSTT && itemCTCT.Lo == Lo
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.ID,
                                itemCTCT.STT,
                                itemCTCT.DanhBo,
                                itemCTCT.Lo,
                                itemCTCT.Phong,
                                itemCTCT.MaLCT,
                                itemCTCT.MaCT,
                                itemCTCT.HoTen,
                                itemCTCT.SoNKTong,
                                itemCTCT.SoNKDangKy,
                                itemCTCT.NgayHetHan,
                                itemCTCT.ThoiHan,
                                itemCTCT.GhiChu,
                            };
                return Function.CLinQToDataTable.LINQToDataTable(query);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int GetTongNKDangKy(string DanhBo)
        {
            return db.DanhSachChungTus.Where(item => item.DanhBo == DanhBo).Sum(item => item.SoNKDangKy);
        }
    }
}

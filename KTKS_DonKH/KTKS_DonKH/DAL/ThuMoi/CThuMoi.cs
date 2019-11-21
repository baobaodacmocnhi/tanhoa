using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.DAL.ThuMoi
{
    class CThuMoi : CDAL
    {
        public bool them(LinQ.ThuMoi entity)
        {
            try
            {
                if (db.ThuMois.Count() > 0)
                {
                    entity.ID = db.ThuMois.Max(item => item.ID) + 1;
                }
                else
                {
                    entity.ID = 1;
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

        public bool checkExist(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.ThuMois.Any(item => item.MaDonTKH == MaDon);
                case "TXL":
                    return db.ThuMois.Any(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.ThuMois.Any(item => item.MaDonTBC == MaDon);
                default:
                    return false;
            }
        }

        public LinQ.ThuMoi get(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.ThuMois.SingleOrDefault(item => item.MaDonTKH == MaDon);
                case "TXL":
                    return db.ThuMois.SingleOrDefault(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.ThuMois.SingleOrDefault(item => item.MaDonTBC == MaDon);
                default:
                    return null;
            }
        }

        public bool them_ChiTiet(ThuMoi_ChiTiet entity)
        {
            try
            {
                if (db.ThuMoi_ChiTiets.Count() > 0)
                {
                    //entity.IDCT = db.ThuMoi_ChiTiets.Max(item => item.IDCT) + 1;
                    //if (entity.ThuMoi.MaDonTKH != null)
                    //{
                    //    if (db.ThuMoi_ChiTiets.Any(item => item.ThuMoi.MaDonTKH == entity.ThuMoi.MaDonTKH&&item.DanhBo==entity.DanhBo) == false)
                    //        entity.Lan = 2;
                    //    else
                    //        entity.Lan = db.ThuMoi_ChiTiets.Where(item => item.ThuMoi.MaDonTKH == entity.ThuMoi.MaDonTKH && item.DanhBo == entity.DanhBo).Count() + 1;
                    //}
                    //else
                    //    if (entity.ThuMoi.MaDonTXL != null)
                    //    {
                    //        if (db.ThuMoi_ChiTiets.Any(item => item.ThuMoi.MaDonTXL == entity.ThuMoi.MaDonTXL && item.DanhBo == entity.DanhBo) == false)
                    //            entity.Lan = 2;
                    //        else
                    //            entity.Lan = db.ThuMoi_ChiTiets.Where(item => item.ThuMoi.MaDonTXL == entity.ThuMoi.MaDonTXL && item.DanhBo == entity.DanhBo).Count() + 1;
                    //    }
                    //    else
                    //        if (entity.ThuMoi.MaDonTBC != null)
                    //        {
                    //            if (db.ThuMoi_ChiTiets.Any(item => item.ThuMoi.MaDonTBC == entity.ThuMoi.MaDonTBC && item.DanhBo == entity.DanhBo) == false)
                    //                entity.Lan = 2;
                    //            else
                    //                entity.Lan = db.ThuMoi_ChiTiets.Where(item => item.ThuMoi.MaDonTBC == entity.ThuMoi.MaDonTBC && item.DanhBo == entity.DanhBo).Count() + 1;
                    //        }
                    string Column = "IDCT";
                    string Table = "ThuMoi_ChiTiet";
                    int IDCT = db.ExecuteQuery<int>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + Column + "),LEN(CONVERT(nvarchar(50)," + Column + "))-1,2)) from " + Table + " " +
                        "select MAX(" + Column + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + Column + "),LEN(CONVERT(nvarchar(50)," + Column + "))-1,2)=@Ma").Single();
                    entity.IDCT = (int)getMaxNextIDTable(IDCT);
                }
                else
                {
                    entity.IDCT = int.Parse("1" + DateTime.Now.ToString("yy"));
                }
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.ThuMoi_ChiTiets.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool sua_ChiTiet(ThuMoi_ChiTiet entity)
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

        public bool xoa_ChiTiet(ThuMoi_ChiTiet entity)
        {
            try
            {
                CDonTu _cDonTu = new CDonTu();
                _cDonTu.Xoa_LichSu("ThuMoi_ChiTiet", (int)entity.IDCT);
                int ID = entity.ID;
                db.ThuMoi_ChiTiet_Hinhs.DeleteAllOnSubmit(entity.ThuMoi_ChiTiet_Hinhs.ToList());
                db.ThuMoi_ChiTiets.DeleteOnSubmit(entity);
                db.SubmitChanges();
                if (db.ThuMoi_ChiTiets.Any(item => item.ID == ID) == false)
                    db.ThuMois.DeleteOnSubmit(db.ThuMois.SingleOrDefault(item => item.ID == ID));
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist_ChiTiet(string Loai, decimal MaDon, string DanhBo)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.ThuMoi_ChiTiets.Any(item => item.ThuMoi.MaDonTKH == MaDon && item.DanhBo == DanhBo);
                case "TXL":
                    return db.ThuMoi_ChiTiets.Any(item => item.ThuMoi.MaDonTXL == MaDon && item.DanhBo == DanhBo);
                case "TBC":
                    return db.ThuMoi_ChiTiets.Any(item => item.ThuMoi.MaDonTBC == MaDon && item.DanhBo == DanhBo);
                default:
                    return false;
            }
        }

        public bool checkCanKhachHangLienHe(string DanhBo, out string TinhTrang)
        {
            if (db.ThuMoi_ChiTiets.Any(item => item.DanhBo == DanhBo && item.CanKhachHangLienHe == true))
            {
                TinhTrang = "có Thư Mời";
                ThuMoi_ChiTiet en = db.ThuMoi_ChiTiets.FirstOrDefault(item => item.DanhBo == DanhBo && item.CanKhachHangLienHe == true);
                if (en.ThuMoi.MaDonMoi != null)
                    TinhTrang += " (" + en.ThuMoi.MaDonMoi.Value.ToString() + ")";
                else
                    if (en.ThuMoi.MaDonTKH != null)
                        TinhTrang += " (TKH" + en.ThuMoi.MaDonTKH.Value.ToString() + ")";
                    else
                        if (en.ThuMoi.MaDonTXL != null)
                            TinhTrang += " (TXL" + en.ThuMoi.MaDonTXL.Value.ToString() + ")";
                        else
                            if (en.ThuMoi.MaDonTBC != null)
                                TinhTrang += " (TBC" + en.ThuMoi.MaDonTBC.Value.ToString() + ")";
                            else
                                TinhTrang += "";
                return true;
            }
            else
            {
                TinhTrang = "";
                return false;
            }
        }

        public int maxLan_ChiTiet(string Loai, decimal MaDon, string DanhBo)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.ThuMoi_ChiTiets.Where(item => item.ThuMoi.MaDonTKH == MaDon && item.DanhBo == DanhBo).Max(item => item.Lan).Value;
                case "TXL":
                    return db.ThuMoi_ChiTiets.Where(item => item.ThuMoi.MaDonTXL == MaDon && item.DanhBo == DanhBo).Max(item => item.Lan).Value;
                case "TBC":
                    return db.ThuMoi_ChiTiets.Where(item => item.ThuMoi.MaDonTBC == MaDon && item.DanhBo == DanhBo).Max(item => item.Lan).Value;
                default:
                    return -1;
            }
        }

        public ThuMoi_ChiTiet get_ChiTiet(int IDCT)
        {
            return db.ThuMoi_ChiTiets.SingleOrDefault(item => item.IDCT == IDCT);
        }

        public DataTable getDS_ChiTiet(string To, decimal MaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from item in db.ThuMoi_ChiTiets
                                where item.ThuMoi.MaDonTKH == MaDon
                                select new
                                {
                                    MaDon = "TKH" + item.ThuMoi.MaDonTKH,
                                    item.IDCT,
                                    item.DanhBo,
                                    item.HoTen,
                                    item.DiaChi,
                                    item.GiaBieu,
                                    item.DinhMuc,
                                    item.Lan,
                                    item.CanCu,
                                    item.VaoLuc,
                                    item.VeViec,
                                    item.Luuy,
                                    item.NoiNhan,
                                    item.CreateDate,
                                    CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from item in db.ThuMoi_ChiTiets
                            where item.ThuMoi.MaDonTXL == MaDon
                            select new
                            {
                                MaDon = "TXL" + item.ThuMoi.MaDonTXL,
                                item.IDCT,
                                item.DanhBo,
                                item.HoTen,
                                item.DiaChi,
                                item.GiaBieu,
                                item.DinhMuc,
                                item.Lan,
                                item.CanCu,
                                item.VaoLuc,
                                item.VeViec,
                                item.Luuy,
                                item.NoiNhan,
                                item.CreateDate,
                                CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from item in db.ThuMoi_ChiTiets
                            where item.ThuMoi.MaDonTBC == MaDon
                            select new
                            {
                                MaDon = "TBC" + item.ThuMoi.MaDonTBC,
                                item.IDCT,
                                item.DanhBo,
                                item.HoTen,
                                item.DiaChi,
                                item.GiaBieu,
                                item.DinhMuc,
                                item.Lan,
                                item.CanCu,
                                item.VaoLuc,
                                item.VeViec,
                                item.Luuy,
                                item.NoiNhan,
                                item.CreateDate,
                                CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.ThuMoi_ChiTiets
                            where item.ThuMoi.MaDonMoi == MaDon
                            select new
                            {
                                MaDon = item.ThuMoi.DonTu.DonTu_ChiTiets.Count == 1 ? item.ThuMoi.MaDonMoi.Value.ToString() : item.ThuMoi.MaDonMoi.Value.ToString() + "." + item.STT.Value.ToString(),
                                item.IDCT,
                                item.DanhBo,
                                item.HoTen,
                                item.DiaChi,
                                item.GiaBieu,
                                item.DinhMuc,
                                item.Lan,
                                item.CanCu,
                                item.VaoLuc,
                                item.VeViec,
                                item.Luuy,
                                item.NoiNhan,
                                item.CreateDate,
                                CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_ChiTiet(string DanhBo)
        {
            var query = from item in db.ThuMoi_ChiTiets
                        where item.DanhBo == DanhBo
                        select new
                        {
                            MaDon = item.ThuMoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuMoi.MaDonMoi).Count() == 1 ? item.ThuMoi.MaDonMoi.Value.ToString() : item.ThuMoi.MaDonMoi + "." + item.STT
                                    : item.ThuMoi.MaDonTKH != null ? "TKH" + item.ThuMoi.MaDonTKH
                                    : item.ThuMoi.MaDonTXL != null ? "TXL" + item.ThuMoi.MaDonTXL
                                    : item.ThuMoi.MaDonTBC != null ? "TBC" + item.ThuMoi.MaDonTBC : null,
                            item.IDCT,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.GiaBieu,
                            item.DinhMuc,
                            item.Lan,
                            item.CanCu,
                            item.VaoLuc,
                            item.VeViec,
                            item.Luuy,
                            item.NoiNhan,
                            item.CreateDate,
                            CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet(DateTime FromCreatDate, DateTime ToCreateDate)
        {
            var query = from item in db.ThuMoi_ChiTiets
                        where item.CreateDate.Value.Date >= FromCreatDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.ThuMoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuMoi.MaDonMoi).Count() == 1 ? item.ThuMoi.MaDonMoi.Value.ToString() : item.ThuMoi.MaDonMoi + "." + item.STT
                                    : item.ThuMoi.MaDonTKH != null ? "TKH" + item.ThuMoi.MaDonTKH
                                    : item.ThuMoi.MaDonTXL != null ? "TXL" + item.ThuMoi.MaDonTXL
                                    : item.ThuMoi.MaDonTBC != null ? "TBC" + item.ThuMoi.MaDonTBC : null,
                            item.IDCT,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.GiaBieu,
                            item.DinhMuc,
                            item.Lan,
                            item.CanCu,
                            item.VaoLuc,
                            item.VeViec,
                            item.Luuy,
                            item.NoiNhan,
                            item.CreateDate,
                            CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet(int CreateBy, DateTime FromCreatDate, DateTime ToCreateDate)
        {
            var query = from item in db.ThuMoi_ChiTiets
                        where item.CreateBy == CreateBy && item.CreateDate.Value.Date >= FromCreatDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.ThuMoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuMoi.MaDonMoi).Count() == 1 ? item.ThuMoi.MaDonMoi.Value.ToString() : item.ThuMoi.MaDonMoi + "." + item.STT
                                    : item.ThuMoi.MaDonTKH != null ? "TKH" + item.ThuMoi.MaDonTKH
                                    : item.ThuMoi.MaDonTXL != null ? "TXL" + item.ThuMoi.MaDonTXL
                                    : item.ThuMoi.MaDonTBC != null ? "TBC" + item.ThuMoi.MaDonTBC : null,
                            item.IDCT,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.GiaBieu,
                            item.DinhMuc,
                            item.Lan,
                            item.CanCu,
                            item.VaoLuc,
                            item.VeViec,
                            item.Luuy,
                            item.NoiNhan,
                            item.CreateDate,
                            CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getCanCu()
        {
            return LINQToDataTable(db.ThuMoi_ChiTiets.Select(item => new { item.CanCu }).ToList().Distinct());
        }

        public DataTable getVeViec()
        {
            return LINQToDataTable(db.ThuMoi_ChiTiets.Select(item => new { item.VeViec }).ToList().Distinct());
        }

        //MaDonMoi

        public bool checkExist(int MaDon)
        {
            return db.ThuMois.Any(item => item.MaDonMoi == MaDon);
        }

        public bool checkExist_ChiTiet(int MaDon, string DanhBo)
        {
            return db.ThuMoi_ChiTiets.Any(item => item.ThuMoi.MaDonMoi == MaDon && item.DanhBo == DanhBo);
        }

        public int maxLan_ChiTiet(int MaDon, string DanhBo)
        {
            return db.ThuMoi_ChiTiets.Where(item => item.ThuMoi.MaDonMoi == MaDon && item.DanhBo == DanhBo).Max(item => item.Lan).Value;
        }

        public LinQ.ThuMoi get(int MaDon)
        {
            return db.ThuMois.SingleOrDefault(item => item.MaDonMoi == MaDon);
        }

        public DataTable getDS_ChiTiet(int MaDon)
        {
            var query = from item in db.ThuMoi_ChiTiets
                        where item.ThuMoi.MaDonTKH == MaDon
                        select new
                        {
                            MaDon = item.ThuMoi.MaDonMoi,
                            item.IDCT,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.GiaBieu,
                            item.DinhMuc,
                            item.Lan,
                            item.CanCu,
                            item.VaoLuc,
                            item.VeViec,
                            item.Luuy,
                            item.NoiNhan,
                            item.CreateDate,
                        };
            return LINQToDataTable(query);
        }

        #region Hình

        public bool Them_Hinh(ThuMoi_ChiTiet_Hinh en)
        {
            try
            {
                if (db.ThuMoi_ChiTiet_Hinhs.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = db.ThuMoi_ChiTiet_Hinhs.Max(item => item.ID) + 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.ThuMoi_ChiTiet_Hinhs.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_Hinh(ThuMoi_ChiTiet_Hinh en)
        {
            try
            {
                db.ThuMoi_ChiTiet_Hinhs.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public ThuMoi_ChiTiet_Hinh get_Hinh(int ID)
        {
            return db.ThuMoi_ChiTiet_Hinhs.SingleOrDefault(item => item.ID == ID);
        }

        #endregion
    }
}

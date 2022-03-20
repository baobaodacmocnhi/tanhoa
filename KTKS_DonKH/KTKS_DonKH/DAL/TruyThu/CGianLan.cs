using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.DAL.TruyThu
{
    class CGianLan : CDAL
    {
        public bool Them(GianLan entity)
        {
            try
            {
                if (db.GianLans.Count() > 0)
                {
                    string Column = "MaGL";
                    string Table = "GianLan";
                    decimal MaGL = db.ExecuteQuery<int>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + Column + "),LEN(CONVERT(nvarchar(50)," + Column + "))-1,2)) from " + Table + " " +
                        "select MAX(" + Column + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + Column + "),LEN(CONVERT(nvarchar(50)," + Column + "))-1,2)=@Ma").Single();
                    entity.MaGL = (int)getMaxNextIDTable(MaGL);
                }
                else
                    entity.MaGL = int.Parse("1" + DateTime.Now.ToString("yy"));
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.GianLans.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
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
            catch (Exception ex)
            {
                Refresh();
                throw ex;
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
                    return db.GianLans.Any(item => item.MaDon == MaDon);
                case "TXL":
                    return db.GianLans.Any(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.GianLans.Any(item => item.MaDonTBC == MaDon);
                default:
                    return false;
            }
        }

        public GianLan get(string Loai, decimal MaDon)
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

        public bool Them_ChiTiet(GianLan_ChiTiet entity)
        {
            try
            {
                if (db.GianLan_ChiTiets.Count() > 0)
                {
                    string ID = "MaCTGL";
                    string Table = "GianLan_ChiTiet";
                    int MaCTGL = db.ExecuteQuery<int>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    entity.MaCTGL = (int)getMaxNextIDTable(MaCTGL);
                }
                else
                    entity.MaCTGL = int.Parse("1" + DateTime.Now.ToString("yy"));
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.GianLan_ChiTiets.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua_ChiTiet(GianLan_ChiTiet entity)
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

        public bool Xoa_ChiTiet(GianLan_ChiTiet entity)
        {
            try
            {
                //CDonTu _cDonTu = new CDonTu();
                //_cDonTu.Xoa_LichSu("GianLan_ChiTiet", (int)entity.MaCTGL);
                db.DonTu_LichSus.DeleteOnSubmit(db.DonTu_LichSus.SingleOrDefault(item => item.TableName == "GianLan_ChiTiet" && item.IDCT == Convert.ToInt32(entity.MaCTGL.ToString())));
                int ID = entity.MaGL.Value;
                db.GianLan_ChiTiet_Hinhs.DeleteAllOnSubmit(entity.GianLan_ChiTiet_Hinhs.ToList());
                db.GianLan_ChiTiets.DeleteOnSubmit(entity);
                if (db.GianLan_ChiTiets.Any(item => item.MaGL == ID) == false)
                    db.GianLans.DeleteOnSubmit(db.GianLans.SingleOrDefault(item => item.MaGL == ID));
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
                    return db.GianLan_ChiTiets.Any(item => item.GianLan.MaDon == MaDon && item.DanhBo == DanhBo);
                case "TXL":
                    return db.GianLan_ChiTiets.Any(item => item.GianLan.MaDonTXL == MaDon && item.DanhBo == DanhBo);
                case "TBC":
                    return db.GianLan_ChiTiets.Any(item => item.GianLan.MaDonTBC == MaDon && item.DanhBo == DanhBo);
                default:
                    return false;
            }
        }

        public bool checkExist_ChiTiet(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.GianLan_ChiTiets.Any(item => item.GianLan.MaDon == MaDon);
                case "TXL":
                    return db.GianLan_ChiTiets.Any(item => item.GianLan.MaDonTXL == MaDon);
                case "TBC":
                    return db.GianLan_ChiTiets.Any(item => item.GianLan.MaDonTBC == MaDon);
                default:
                    return false;
            }
        }

        public GianLan_ChiTiet get_ChiTiet(int ID)
        {
            return db.GianLan_ChiTiets.SingleOrDefault(item => item.MaCTGL == ID);
        }

        public GianLan_ChiTiet get_ChiTiet(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.GianLan_ChiTiets.SingleOrDefault(item => item.GianLan.MaDon == MaDon);
                case "TXL":
                    return db.GianLan_ChiTiets.SingleOrDefault(item => item.GianLan.MaDonTXL == MaDon);
                case "TBC":
                    return db.GianLan_ChiTiets.SingleOrDefault(item => item.GianLan.MaDonTBC == MaDon);
                default:
                    return null;
            }

        }

        public DataTable getDS_ChiTiet()
        {
            var query = from item in db.GianLan_ChiTiets
                        select new
                        {
                            MaDon = item.GianLan.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.GianLan.MaDonMoi).Count() == 1 ? item.GianLan.MaDonMoi.Value.ToString() : item.GianLan.MaDonMoi + "." + item.STT
                                    : item.GianLan.MaDon != null ? "TKH" + item.GianLan.MaDon
                                    : item.GianLan.MaDonTXL != null ? "TXL" + item.GianLan.MaDonTXL
                                    : item.GianLan.MaDonTBC != null ? "TBC" + item.GianLan.MaDonTBC : null,
                            ID = item.MaCTGL,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDungViPham,
                            item.TinhTrang,
                            item.XepDon,
                            item.CreateDate,
                            item.GianLan.MaDonTXL,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet(string DanhBo)
        {
            var query = from item in db.GianLan_ChiTiets
                        where item.DanhBo == DanhBo
                        select new
                        {
                            MaDon = item.GianLan.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.GianLan.MaDonMoi).Count() == 1 ?  item.GianLan.MaDonMoi.Value.ToString() : item.GianLan.MaDonMoi + "." + item.STT
                                    : item.GianLan.MaDon != null ? "TKH" + item.GianLan.MaDon
                                    : item.GianLan.MaDonTXL != null ? "TXL" + item.GianLan.MaDonTXL
                                    : item.GianLan.MaDonTBC != null ? "TBC" + item.GianLan.MaDonTBC : null,
                            ID = item.MaCTGL,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDungViPham,
                            item.TinhTrang,
                            item.XepDon,
                            item.CreateDate,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.GianLan_ChiTiets
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.GianLan.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.GianLan.MaDonMoi).Count() == 1 ?  item.GianLan.MaDonMoi.Value.ToString() : item.GianLan.MaDonMoi + "." + item.STT
                                    : item.GianLan.MaDon != null ? "TKH" + item.GianLan.MaDon
                                    : item.GianLan.MaDonTXL != null ? "TXL" + item.GianLan.MaDonTXL
                                    : item.GianLan.MaDonTBC != null ? "TBC" + item.GianLan.MaDonTBC : null,
                            ID = item.MaCTGL,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDungViPham,
                            item.TinhTrang,
                            item.XepDon,
                            item.CreateDate,
                            item.GianLan.MaDonTXL,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet_TinhTrang(string TinhTrang)
        {
            var query = from item in db.GianLan_ChiTiets
                        where item.TinhTrang==TinhTrang
                        select new
                        {
                            MaDon = item.GianLan.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.GianLan.MaDonMoi).Count() == 1 ? item.GianLan.MaDonMoi.Value.ToString() : item.GianLan.MaDonMoi + "." + item.STT
                                    : item.GianLan.MaDon != null ? "TKH" + item.GianLan.MaDon
                                    : item.GianLan.MaDonTXL != null ? "TXL" + item.GianLan.MaDonTXL
                                    : item.GianLan.MaDonTBC != null ? "TBC" + item.GianLan.MaDonTBC : null,
                            ID = item.MaCTGL,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDungViPham,
                            item.TinhTrang,
                            item.XepDon,
                            item.CreateDate,
                            item.GianLan.MaDonTXL,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSNoiDungViPham()
        {
            return LINQToDataTable(db.GianLan_ChiTiets.Select(item => new { item.NoiDungViPham }).ToList().Distinct());
        }

        public DataTable GetDSTinhTrang()
        {
            return LINQToDataTable(db.GianLan_ChiTiets.Select(item => new { item.TinhTrang }).ToList().Distinct());
        }

        //MaDonMoi

        public bool checkExist(int MaDon)
        {
            return db.GianLans.Any(item => item.MaDonMoi == MaDon);
        }

        public bool checkExist_ChiTiet(int MaDon, string DanhBo)
        {
            return db.GianLan_ChiTiets.Any(item => item.GianLan.MaDonMoi == MaDon && item.DanhBo == DanhBo);
        }

        public GianLan get(int MaDon)
        {
            return db.GianLans.SingleOrDefault(item => item.MaDonMoi == MaDon);
        }

        #region Hình

        public bool Them_Hinh(GianLan_ChiTiet_Hinh en)
        {
            try
            {
                if (db.GianLan_ChiTiet_Hinhs.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = db.GianLan_ChiTiet_Hinhs.Max(item => item.ID) + 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.GianLan_ChiTiet_Hinhs.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_Hinh(GianLan_ChiTiet_Hinh en)
        {
            try
            {
                db.GianLan_ChiTiet_Hinhs.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public GianLan_ChiTiet_Hinh get_Hinh(int ID)
        {
            return db.GianLan_ChiTiet_Hinhs.SingleOrDefault(item => item.ID == ID);
        }

        #endregion
    }
}

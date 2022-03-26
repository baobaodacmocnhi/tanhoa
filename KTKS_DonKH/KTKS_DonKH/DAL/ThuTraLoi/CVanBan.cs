using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.DonTu;
using System.Data;

namespace KTKS_DonKH.DAL.VanBan
{
    class CVanBan : CDAL
    {
        #region VanBan (Văn Bản)

        public bool Them(LinQ.VanBan en)
        {
            try
            {
                if (db.VanBans.Count() > 0)
                {
                    en.ID = db.VanBans.Max(item => item.ID) + 1;
                }
                else
                    en.ID = 1;
                en.CreateDate = DateTime.Now;
                en.CreateBy = CTaiKhoan.MaUser;
                db.VanBans.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(LinQ.VanBan en)
        {
            try
            {
                en.ModifyDate = DateTime.Now;
                en.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public LinQ.VanBan get_ID(int ID)
        {
            return db.VanBans.SingleOrDefault(item => item.ID == ID);
        }

        public LinQ.VanBan get_MaDon(int MaDon)
        {
            return db.VanBans.SingleOrDefault(item => item.MaDon == MaDon);
        }

        public bool checkExist(int MaDon)
        {
            return db.VanBans.Any(item => item.MaDon == MaDon);
        }

        #endregion

        #region VanBan_ChiTiet (Chi Tiết Văn Bản)

        public bool ThemCT(VanBan_ChiTiet en)
        {
            try
            {
                if (db.VanBan_ChiTiets.Count() > 0)
                {
                    string Column = "IDCT";
                    string Table = "VanBan_ChiTiet";
                    int IDCT = db.ExecuteQuery<int>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + Column + "),LEN(CONVERT(nvarchar(50)," + Column + "))-1,2)) from " + Table + " " +
                        "select MAX(" + Column + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + Column + "),LEN(CONVERT(nvarchar(50)," + Column + "))-1,2)=@Ma").Single();
                    en.IDCT = (int)getMaxNextIDTable(IDCT);
                }
                else
                {
                    en.IDCT = int.Parse("1" + DateTime.Now.ToString("yy"));
                }
                en.CreateDate = DateTime.Now;
                en.CreateBy = CTaiKhoan.MaUser;
                db.VanBan_ChiTiets.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool SuaCT(VanBan_ChiTiet en)
        {
            try
            {
                en.ModifyDate = DateTime.Now;
                en.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool XoaCT(VanBan_ChiTiet en)
        {
            try
            {
                //db.DonTu_LichSus.DeleteOnSubmit(db.DonTu_LichSus.SingleOrDefault(item => item.TableName == "VanBan_ChiTiet" && item.IDCT == Convert.ToInt32(en.IDCT.ToString())));
                decimal ID = en.ID;
                db.VanBan_ChiTiet_Hinhs.DeleteAllOnSubmit(en.VanBan_ChiTiet_Hinhs.ToList());
                db.VanBan_ChiTiets.DeleteOnSubmit(en);
                db.SubmitChanges();
                if (db.VanBan_ChiTiets.Any(item => item.ID == ID) == false)
                    db.VanBans.DeleteOnSubmit(db.VanBans.SingleOrDefault(item => item.ID == ID));
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool CheckExist_ChiTiet(int IDCT)
        {
            return db.VanBan_ChiTiets.Any(item => item.IDCT == IDCT);
        }

        public bool checkExist_ChiTiet(int MaDon, string DanhBo, DateTime CreateDate)
        {
            return db.VanBan_ChiTiets.Any(item => item.VanBan.MaDon == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public VanBan_ChiTiet get_ChiTiet(int IDCT)
        {
            return db.VanBan_ChiTiets.SingleOrDefault(item => item.IDCT == IDCT);
        }

        public DataTable getDS()
        {
            return LINQToDataTable(db.VanBan_ChiTiets.ToList());
        }

        public DataTable getDS(int MaDon)
        {

            var query = from item in db.VanBan_ChiTiets
                        where item.VanBan.MaDon == MaDon
                        select new
                        {
                            MaDon = item.VanBan.MaDon.Value.ToString(),
                            item.IDCT,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                            item.NoiNhan,
                            item.ThuDuocKy,
                        };
            return LINQToDataTable(query);

        }

        public DataTable getDS(int FromIDCT, int ToIDCT)
        {
            var query = from item in db.VanBan_ChiTiets
                        where item.IDCT >= FromIDCT && item.IDCT <= ToIDCT
                        select new
                        {
                            MaDon = item.VanBan.MaDon != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.VanBan.MaDon).Count() == 1 ? item.VanBan.MaDon.Value.ToString() : item.VanBan.MaDon + "." + item.STT : null,
                            item.IDCT,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                            item.NoiNhan,
                            item.ThuDuocKy,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS(string DanhBo)
        {
            var query = from item in db.VanBan_ChiTiets
                        where item.DanhBo == DanhBo
                        select new
                        {
                            MaDon = item.VanBan.MaDon != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.VanBan.MaDon).Count() == 1 ? item.VanBan.MaDon.Value.ToString() : item.VanBan.MaDon + "." + item.STT : null,
                            item.IDCT,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                            item.NoiNhan,
                            item.ThuDuocKy,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.VanBan_ChiTiets
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.VanBan.MaDon != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.VanBan.MaDon).Count() == 1 ? item.VanBan.MaDon.Value.ToString() : item.VanBan.MaDon + "." + item.STT : null,
                            item.IDCT,
                            ID = item.IDCT,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                            item.NoiNhan,
                            item.ThuDuocKy,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetLichSuCTByDanhBo(string DanhBo)
        {
            var query = from item in db.VanBan_ChiTiets
                        where item.DanhBo == DanhBo
                        orderby item.CreateDate descending
                        select new
                        {
                            item.IDCT,
                            MaDon = item.VanBan.MaDon != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.VanBan.MaDon).Count() == 1 ? item.VanBan.MaDon.Value.ToString() : item.VanBan.MaDon + "." + item.STT : null,
                            item.VeViec,
                        };
            return LINQToDataTable(query);
        }

        #endregion

        #region Hình

        public bool Them_Hinh(VanBan_ChiTiet_Hinh en)
        {
            try
            {
                if (db.VanBan_ChiTiet_Hinhs.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = db.VanBan_ChiTiet_Hinhs.Max(item => item.ID) + 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.VanBan_ChiTiet_Hinhs.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_Hinh(VanBan_ChiTiet_Hinh en)
        {
            try
            {
                db.VanBan_ChiTiet_Hinhs.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public VanBan_ChiTiet_Hinh get_Hinh(int ID)
        {
            return db.VanBan_ChiTiet_Hinhs.SingleOrDefault(item => item.ID == ID);
        }

        #endregion
    }
}

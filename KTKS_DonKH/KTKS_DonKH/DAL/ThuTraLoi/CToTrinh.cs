﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.DAL.ThuTraLoi
{
    class CToTrinh : CDAL
    {
        #region ToTrinh (Tờ Trình)

        public bool Them(ToTrinh en)
        {
            try
            {
                if (db.ToTrinhs.Count() > 0)
                {
                    en.ID = db.ToTrinhs.Max(item => item.ID) + 1;
                    //string Column = "ID";
                    //string Table = "ToTrinh";
                    //int ID = db.ExecuteQuery<int>("declare @Ma int " +
                    //    "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + Column + "),LEN(CONVERT(nvarchar(50)," + Column + "))-1,2)) from " + Table + " " +
                    //    "select MAX(" + Column + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + Column + "),LEN(CONVERT(nvarchar(50)," + Column + "))-1,2)=@Ma").Single();
                    //en.ID = (int)getMaxNextIDTable(ID);
                }
                else
                    en.ID = 1;
                //en.ID = int.Parse("1" + DateTime.Now.ToString("yy"));
                en.CreateDate = DateTime.Now;
                en.CreateBy = CTaiKhoan.MaUser;
                db.ToTrinhs.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(ToTrinh en)
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

        public ToTrinh Get(int ID)
        {
            return db.ToTrinhs.SingleOrDefault(itemTT => itemTT.ID == ID);
        }

        public ToTrinh Get(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.ToTrinhs.SingleOrDefault(item => item.MaDon == MaDon);
                case "TXL":
                    return db.ToTrinhs.SingleOrDefault(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.ToTrinhs.SingleOrDefault(item => item.MaDonTBC == MaDon);
                default:
                    return null;
            }
        }

        public bool CheckExist(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.ToTrinhs.Any(item => item.MaDon == MaDon);
                case "TXL":
                    return db.ToTrinhs.Any(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.ToTrinhs.Any(item => item.MaDonTBC == MaDon);
                default:
                    return false;
            }
        }

        #endregion

        #region ToTrinh_ChiTiet (Chi Tiết Tờ Trình)

        public bool Them_ChiTiet(ToTrinh_ChiTiet en)
        {
            try
            {
                if (db.ToTrinh_ChiTiets.Count() > 0)
                {
                    string Column = "IDCT";
                    string Table = "ToTrinh_ChiTiet";
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
                db.ToTrinh_ChiTiets.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua_ChiTiet(ToTrinh_ChiTiet en)
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

        public bool Xoa_ChiTiet(ToTrinh_ChiTiet en)
        {
            try
            {
                CDonTu _cDonTu = new CDonTu();
                _cDonTu.Xoa_LichSu("ToTrinh_ChiTiet", (int)en.IDCT);
                decimal ID = en.ID;
                db.ToTrinh_ChiTiets.DeleteOnSubmit(en);
                db.SubmitChanges();
                if (db.ToTrinh_ChiTiets.Any(item => item.ID == ID) == false)
                    db.ToTrinhs.DeleteOnSubmit(db.ToTrinhs.SingleOrDefault(item => item.ID == ID));
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist_ChiTiet(int IDCT)
        {
            return db.ToTrinh_ChiTiets.Any(item => item.IDCT == IDCT);
        }

        public bool checkExist_ChiTiet(string Loai, decimal MaDon, string DanhBo, DateTime CreateDate)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.ToTrinh_ChiTiets.Any(item => item.ToTrinh.MaDon == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
                case "TXL":
                    return db.ToTrinh_ChiTiets.Any(item => item.ToTrinh.MaDonTXL == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
                case "TBC":
                    return db.ToTrinh_ChiTiets.Any(item => item.ToTrinh.MaDonTBC == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
                default:
                    return false;
            }
        }

        public ToTrinh_ChiTiet get_ChiTiet(int IDCT)
        {
            return db.ToTrinh_ChiTiets.SingleOrDefault(item => item.IDCT == IDCT);
        }

        public DataTable getDS_ChiTiet(int IDCT)
        {
            var query = from item in db.ToTrinh_ChiTiets
                        where item.IDCT == IDCT
                        select new
                        {
                            MaDon = item.ToTrinh.MaDon != null ? "TKH" + item.ToTrinh.MaDon
                                : item.ToTrinh.MaDonTXL != null ? "TXL" + item.ToTrinh.MaDonTXL
                                : item.ToTrinh.MaDonTBC != null ? "TBC" + item.ToTrinh.MaDonTBC : null,
                            item.IDCT,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet_DanhBo(string DanhBo)
        {
            var query = from item in db.ToTrinh_ChiTiets
                        where item.DanhBo == DanhBo
                        select new
                        {
                            MaDon = item.ToTrinh.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ToTrinh.MaDonMoi).Count() == 1 ?  item.ToTrinh.MaDonMoi.Value.ToString() : item.ToTrinh.MaDonMoi + "." + item.STT
                                    : item.ToTrinh.MaDon != null ? "TKH" + item.ToTrinh.MaDon
                                    : item.ToTrinh.MaDonTXL != null ? "TXL" + item.ToTrinh.MaDonTXL
                                    : item.ToTrinh.MaDonTBC != null ? "TBC" + item.ToTrinh.MaDonTBC : null,
                            item.IDCT,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet_VeViec(string VeViec)
        {
            var query = from item in db.ToTrinh_ChiTiets
                        where item.VeViec.Contains(VeViec)
                        select new
                        {
                            MaDon = item.ToTrinh.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ToTrinh.MaDonMoi).Count() == 1 ?  item.ToTrinh.MaDonMoi.Value.ToString() : item.ToTrinh.MaDonMoi + "." + item.STT
                                    : item.ToTrinh.MaDon != null ? "TKH" + item.ToTrinh.MaDon
                                    : item.ToTrinh.MaDonTXL != null ? "TXL" + item.ToTrinh.MaDonTXL
                                    : item.ToTrinh.MaDonTBC != null ? "TBC" + item.ToTrinh.MaDonTBC : null,
                            item.IDCT,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.ToTrinh_ChiTiets
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.ToTrinh.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ToTrinh.MaDonMoi).Count() == 1 ?  item.ToTrinh.MaDonMoi.Value.ToString() : item.ToTrinh.MaDonMoi + "." + item.STT
                                    : item.ToTrinh.MaDon != null ? "TKH" + item.ToTrinh.MaDon
                                    : item.ToTrinh.MaDonTXL != null ? "TXL" + item.ToTrinh.MaDonTXL
                                    : item.ToTrinh.MaDonTBC != null ? "TBC" + item.ToTrinh.MaDonTBC : null,
                            item.IDCT,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                        };
            return LINQToDataTable(query);
        }

        #endregion

        //MaDonMoi

        public bool checkExist(int MaDon)
        {
            return db.ToTrinhs.Any(item => item.MaDonMoi == MaDon);
        }

        public bool checkExist_ChiTiet(int MaDon, string DanhBo, DateTime CreateDate)
        {
            return db.ToTrinh_ChiTiets.Any(item => item.ToTrinh.MaDonMoi == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public ToTrinh get(int MaDon)
        {
            return db.ToTrinhs.SingleOrDefault(item => item.MaDonMoi == MaDon);
        }

        #region Hình

        public bool Them_Hinh(ToTrinh_ChiTiet_Hinh en)
        {
            try
            {
                if (db.ToTrinh_ChiTiet_Hinhs.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = db.ToTrinh_ChiTiet_Hinhs.Max(item => item.ID) + 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.ToTrinh_ChiTiet_Hinhs.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_Hinh(ToTrinh_ChiTiet_Hinh en)
        {
            try
            {
                db.ToTrinh_ChiTiet_Hinhs.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public ToTrinh_ChiTiet_Hinh get_Hinh(int ID)
        {
            return db.ToTrinh_ChiTiet_Hinhs.SingleOrDefault(item => item.ID == ID);
        }

        #endregion
    }
}

using System;
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
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
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
                en.ModifyBy = CTaiKhoan.MaUser;
                en.ModifyDate = DateTime.Now;
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
                _cDonTu.Xoa_LichSus("ToTrinh_ChiTiet", (int)en.IDCT);
                decimal ID = en.ID;
                db.ToTrinh_ChiTiet_Hinhs.DeleteAllOnSubmit(en.ToTrinh_ChiTiet_Hinhs.ToList());
                db.ToTrinh_ChiTiet_DanhSaches.DeleteAllOnSubmit(en.ToTrinh_ChiTiet_DanhSaches.ToList());
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

        public bool checkExist_ChiTiet_90Ngay(string DanhBo, string VeViec)
        {
            return db.ToTrinh_ChiTiets.Any(item => item.DanhBo == DanhBo && item.VeViec.Contains(VeViec) && item.CreateDate.Value.Date >= DateTime.Now.Date.AddDays(-90));
        }

        public bool checkExist_ChiTiet_DieuChinhHoaDon_Tu072021(string DanhBo)
        {
            return db.ToTrinh_ChiTiets.Any(item => item.DanhBo == DanhBo && item.VeViec.Contains("Điều chỉnh hóa đơn") && item.CreateDate.Value.Date >= new DateTime(2021, 7, 1).Date);
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
                            ID = item.IDCT,
                            item.IDCT,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                            item.SoPhieuTong,
                            item.NguoiKy,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet(int IDCT, int CreateBy)
        {
            var query = from item in db.ToTrinh_ChiTiets
                        where item.IDCT == IDCT && item.CreateBy == CreateBy
                        select new
                        {
                            MaDon = item.ToTrinh.MaDon != null ? "TKH" + item.ToTrinh.MaDon
                                : item.ToTrinh.MaDonTXL != null ? "TXL" + item.ToTrinh.MaDonTXL
                                : item.ToTrinh.MaDonTBC != null ? "TBC" + item.ToTrinh.MaDonTBC : null,
                            ID = item.IDCT,
                            item.IDCT,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                            item.SoPhieuTong,
                            item.NguoiKy,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet_DanhBo(string DanhBo)
        {
            var query = from item in db.ToTrinh_ChiTiets
                        where item.DanhBo == DanhBo || item.ToTrinh_ChiTiet_DanhSaches.Any(itemA => itemA.DanhBo == DanhBo)
                        select new
                        {
                            MaDon = item.ToTrinh.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ToTrinh.MaDonMoi).Count() == 1 ? item.ToTrinh.MaDonMoi.Value.ToString() : item.ToTrinh.MaDonMoi + "." + item.STT
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
                            item.SoPhieuTong,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet_DanhBo(string DanhBo, int CreateBy)
        {
            var query = from item in db.ToTrinh_ChiTiets
                        where (item.DanhBo == DanhBo || item.ToTrinh_ChiTiet_DanhSaches.Any(itemA => itemA.DanhBo == DanhBo)) && item.CreateBy == CreateBy
                        select new
                        {
                            MaDon = item.ToTrinh.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ToTrinh.MaDonMoi).Count() == 1 ? item.ToTrinh.MaDonMoi.Value.ToString() : item.ToTrinh.MaDonMoi + "." + item.STT
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
                            item.SoPhieuTong,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet_VeViec(string VeViec)
        {
            var query = from item in db.ToTrinh_ChiTiets
                        where item.VeViec.Contains(VeViec)
                        select new
                        {
                            MaDon = item.ToTrinh.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ToTrinh.MaDonMoi).Count() == 1 ? item.ToTrinh.MaDonMoi.Value.ToString() : item.ToTrinh.MaDonMoi + "." + item.STT
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
                            item.SoPhieuTong,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet_VeViec(string VeViec, int CreateBy)
        {
            var query = from item in db.ToTrinh_ChiTiets
                        where item.VeViec.Contains(VeViec) && item.CreateBy == CreateBy
                        select new
                        {
                            MaDon = item.ToTrinh.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ToTrinh.MaDonMoi).Count() == 1 ? item.ToTrinh.MaDonMoi.Value.ToString() : item.ToTrinh.MaDonMoi + "." + item.STT
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
                            item.SoPhieuTong,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.ToTrinh_ChiTiets
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        orderby item.CreateDate descending
                        select new
                        {
                            MaDon = item.ToTrinh.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ToTrinh.MaDonMoi).Count() == 1 ? item.ToTrinh.MaDonMoi.Value.ToString() : item.ToTrinh.MaDonMoi + "." + item.STT
                                    : item.ToTrinh.MaDon != null ? "TKH" + item.ToTrinh.MaDon
                                    : item.ToTrinh.MaDonTXL != null ? "TXL" + item.ToTrinh.MaDonTXL
                                    : item.ToTrinh.MaDonTBC != null ? "TBC" + item.ToTrinh.MaDonTBC : null,
                            ID = item.IDCT,
                            item.IDCT,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                            item.SoPhieuTong,
                            item.NguoiKy,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet(DateTime FromCreateDate, DateTime ToCreateDate, int CreateBy)
        {
            var query = from item in db.ToTrinh_ChiTiets
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.CreateBy == CreateBy
                        orderby item.CreateDate descending
                        select new
                        {
                            MaDon = item.ToTrinh.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ToTrinh.MaDonMoi).Count() == 1 ? item.ToTrinh.MaDonMoi.Value.ToString() : item.ToTrinh.MaDonMoi + "." + item.STT
                                    : item.ToTrinh.MaDon != null ? "TKH" + item.ToTrinh.MaDon
                                    : item.ToTrinh.MaDonTXL != null ? "TXL" + item.ToTrinh.MaDonTXL
                                    : item.ToTrinh.MaDonTBC != null ? "TBC" + item.ToTrinh.MaDonTBC : null,
                            ID = item.IDCT,
                            item.IDCT,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                            item.SoPhieuTong,
                            item.NguoiKy,
                        };
            return LINQToDataTable(query);
        }

        public decimal getNextSoPhieuTong()
        {
            if (db.ToTrinh_ChiTiets.Max(item => item.SoPhieuTong) == null)
                return int.Parse("1" + DateTime.Now.ToString("yy"));
            else
            {
                string ID = "SoPhieuTong";
                string Table = "ToTrinh_ChiTiet";
                int SoPhieu = db.ExecuteQuery<int>("declare @Ma int " +
                    "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                    "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                return getMaxNextIDTable(SoPhieu);
            }
        }

        public List<ToTrinh_ChiTiet> getDS_ChiTiet_SoPhieuTong(int SoPhieuTong)
        {
            return db.ToTrinh_ChiTiets.Where(item => item.SoPhieuTong == SoPhieuTong).ToList();
        }

        #endregion

        #region ToTrinh_ChiTiet_DanhSach (Chi Tiết Tờ Trình Danh Sách)

        public bool Them_ChiTiet_DanhSach(ToTrinh_ChiTiet_DanhSach en)
        {
            try
            {
                if (db.ToTrinh_ChiTiet_DanhSaches.Count() > 0)
                {
                    en.IDDanhSach = db.ToTrinh_ChiTiet_DanhSaches.Max(item => item.IDDanhSach) + 1;
                }
                else
                {
                    en.IDDanhSach = 1;
                }
                en.CreateDate = DateTime.Now;
                en.CreateBy = CTaiKhoan.MaUser;
                db.ToTrinh_ChiTiet_DanhSaches.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua_ChiTiet_DanhSach(ToTrinh_ChiTiet_DanhSach en)
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

        public bool Xoa_ChiTiet_DanhSach(ToTrinh_ChiTiet_DanhSach en)
        {
            try
            {
                CDonTu _cDonTu = new CDonTu();
                _cDonTu.Xoa_LichSu("ToTrinh_ChiTiet", (int)en.IDCT, en.MaDon.Value, en.STT.Value);
                db.ToTrinh_ChiTiet_DanhSaches.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public ToTrinh_ChiTiet_DanhSach get_ChiTiet_DanhSach(int ID)
        {
            return db.ToTrinh_ChiTiet_DanhSaches.SingleOrDefault(item => item.IDDanhSach == ID);
        }

        public int get_IDDanhSach_Max()
        {
            if (db.ToTrinh_ChiTiet_DanhSaches.Count() > 0)
            {
                return db.ToTrinh_ChiTiet_DanhSaches.Max(item => item.IDDanhSach);
            }
            else
            {
                return 0;
            }
        }

        #endregion

        //MaDonMoi

        public bool checkExist(int MaDon)
        {
            return db.ToTrinhs.Any(item => item.MaDonMoi == MaDon);
        }

        public bool checkExist_ChiTiet(int MaDon, string DanhBo, DateTime CreateDate)
        {
            if (db.ToTrinh_ChiTiets.Any(item => item.ToTrinh.MaDonMoi == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date) == true)
                return true;
            else
                return db.ToTrinh_ChiTiet_DanhSaches.Any(item => item.MaDon == MaDon && item.DanhBo == DanhBo && item.ToTrinh_ChiTiet.CreateDate.Value.Date == CreateDate.Date);
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

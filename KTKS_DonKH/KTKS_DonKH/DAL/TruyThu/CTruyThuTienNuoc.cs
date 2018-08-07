﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;
using System.Data;

namespace KTKS_DonKH.DAL.TruyThu
{
    class CTruyThuTienNuoc : CDAL
    {
        //int SoTien1m3 = 19345;
        int SoTien1m3 = 19435;

        #region TruyThuTienNuoc

        public bool Them(TruyThuTienNuoc tttn)
        {
            try
            {
                if (db.TruyThuTienNuocs.Count() > 0)
                {
                    string ID = "MaTTTN";
                    string Table = "TruyThuTienNuoc";
                    decimal MaTTTN = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    tttn.MaTTTN = getMaxNextIDTable(MaTTTN);
                }
                else
                    tttn.MaTTTN = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                tttn.CreateDate = DateTime.Now;
                tttn.CreateBy = CTaiKhoan.MaUser;
                db.TruyThuTienNuocs.InsertOnSubmit(tttn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(TruyThuTienNuoc tttn)
        {
            try
            {
                tttn.ModifyDate = DateTime.Now;
                tttn.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(TruyThuTienNuoc tttn)
        {
            try
            {
                db.TruyThuTienNuocs.DeleteOnSubmit(tttn);
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
                    return db.TruyThuTienNuocs.Any(item => item.MaDon == MaDon);
                case "TXL":
                    return db.TruyThuTienNuocs.Any(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.TruyThuTienNuocs.Any(item => item.MaDonTBC == MaDon);
                default:
                    return false;
            }
        }

        public TruyThuTienNuoc get(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.TruyThuTienNuocs.SingleOrDefault(item => item.MaDon == MaDon);
                case "TXL":
                    return db.TruyThuTienNuocs.SingleOrDefault(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.TruyThuTienNuocs.SingleOrDefault(item => item.MaDonTBC == MaDon);
                default:
                    return null;
            }
        }

        #endregion

        #region TruyThuTienNuoc_ChiTiet

        public bool Them_ChiTiet(TruyThuTienNuoc_ChiTiet cttttn)
        {
            try
            {
                if (db.TruyThuTienNuoc_ChiTiets.Count() > 0)
                {
                    string ID = "MaCTTTTN";
                    string Table = "TruyThuTienNuoc_ChiTiet";
                    decimal MaCTTTTN = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    cttttn.MaCTTTTN = getMaxNextIDTable(MaCTTTTN);
                }
                else
                    cttttn.MaCTTTTN = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                cttttn.SoTien1m3 = SoTien1m3;//lưu lại số tiền trong quá khứ do có thể thay đổi trong tương lai
                cttttn.CreateDate = DateTime.Now;
                cttttn.CreateBy = CTaiKhoan.MaUser;
                db.TruyThuTienNuoc_ChiTiets.InsertOnSubmit(cttttn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua_ChiTiet(TruyThuTienNuoc_ChiTiet cttttn)
        {
            try
            {
                cttttn.ModifyDate = DateTime.Now;
                cttttn.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_ChiTiet(TruyThuTienNuoc_ChiTiet cttttn)
        {
            try
            {
                db.TruyThuTienNuoc_HoaDons.DeleteAllOnSubmit(cttttn.TruyThuTienNuoc_HoaDons.ToList());
                db.TruyThuTienNuoc_ThanhToans.DeleteAllOnSubmit(cttttn.TruyThuTienNuoc_ThanhToans.ToList());
                db.TruyThuTienNuoc_ThuMois.DeleteAllOnSubmit(cttttn.TruyThuTienNuoc_ThuMois.ToList());
                db.TruyThuTienNuoc_ChiTiets.DeleteOnSubmit(cttttn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist_ChiTiet(decimal MaCTTTTN)
        {
            return db.TruyThuTienNuoc_ChiTiets.Any(item => item.MaCTTTTN == MaCTTTTN);
        }

        public bool checkExist_ChiTiet(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.TruyThuTienNuoc_ChiTiets.Any(item => item.TruyThuTienNuoc.MaDon == MaDon);
                case "TXL":
                    return db.TruyThuTienNuoc_ChiTiets.Any(item => item.TruyThuTienNuoc.MaDonTXL == MaDon);
                case "TBC":
                    return db.TruyThuTienNuoc_ChiTiets.Any(item => item.TruyThuTienNuoc.MaDonTBC == MaDon);
                default:
                    return false;
            }

        }

        public bool checkExist_ChiTiet(string Loai, decimal MaDon, string DanhBo)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.TruyThuTienNuoc_ChiTiets.Any(item => item.TruyThuTienNuoc.MaDon == MaDon && item.DanhBo == DanhBo);
                case "TXL":
                    return db.TruyThuTienNuoc_ChiTiets.Any(item => item.TruyThuTienNuoc.MaDonTXL == MaDon && item.DanhBo == DanhBo);
                case "TBC":
                    return db.TruyThuTienNuoc_ChiTiets.Any(item => item.TruyThuTienNuoc.MaDonTBC == MaDon && item.DanhBo == DanhBo);
                default:
                    return false;
            }
        }

        public bool CheckExist_ChuaXepDon(string DanhBo)
        {
            return db.TruyThuTienNuoc_ChiTiets.Any(item => (item.TinhTrang == null || item.TinhTrang == "" || item.TinhTrang == "Đang gửi thư mời") && item.DanhBo == DanhBo);
        }

        public string GetTinhTrang(string DanhBo)
        {
            if (db.TruyThuTienNuoc_ChiTiets.Any(item => item.DanhBo == DanhBo && (item.TinhTrang == "Đang gửi thư mời" || item.TinhTrang == "Trả góp" || item.TinhTrang == "Đã gửi TB tạm ngưng cung cấp nước" || item.TinhTrang == "Chuyển lập TB hủy")) == true)
                return db.TruyThuTienNuoc_ChiTiets.SingleOrDefault(item => item.DanhBo == DanhBo && (item.TinhTrang == "Đang gửi thư mời" || item.TinhTrang == "Trả góp" || item.TinhTrang == "Đã gửi TB tạm ngưng cung cấp nước" || item.TinhTrang == "Chuyển lập TB hủy")).TinhTrang;
            else
                return "";
        }

        public TruyThuTienNuoc_ChiTiet get_ChiTiet(decimal MaCTTTTN)
        {
            return db.TruyThuTienNuoc_ChiTiets.SingleOrDefault(item => item.MaCTTTTN == MaCTTTTN);
        }

        public TruyThuTienNuoc_ChiTiet get_ChiTiet(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.TruyThuTienNuoc_ChiTiets.SingleOrDefault(item => item.TruyThuTienNuoc.MaDon == MaDon);
                case "TXL":
                    return db.TruyThuTienNuoc_ChiTiets.SingleOrDefault(item => item.TruyThuTienNuoc.MaDonTXL == MaDon);
                case "TBC":
                    return db.TruyThuTienNuoc_ChiTiets.SingleOrDefault(item => item.TruyThuTienNuoc.MaDonTBC == MaDon);
                default:
                    return null;
            }
        }

        public DataTable GetDS(decimal MaCTTTTN)
        {
            var query = from item in db.TruyThuTienNuoc_ChiTiets
                        where item.MaCTTTTN == MaCTTTTN
                        select new
                        {
                            MaDon = item.TruyThuTienNuoc.MaDon != null ? "TKH" + item.TruyThuTienNuoc.MaDon
                                : item.TruyThuTienNuoc.MaDonTXL != null ? "TXL" + item.TruyThuTienNuoc.MaDonTXL
                                : item.TruyThuTienNuoc.MaDonTBC != null ? "TBC" + item.TruyThuTienNuoc.MaDonTBC : null,
                            SoCongVan = item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.SoCongVan
                                : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.SoCongVan
                                : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.SoCongVan : null,
                            item.MaCTTTTN,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.DienThoai,
                            //item.TongTien,
                            //item.Tongm3BinhQuan,
                            TongTien = item.TruyThuTienNuoc_HoaDons.Count > 0 ? item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongMoi).Value - item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongCu).Value : 0,
                            Tongm3BinhQuan = item.TruyThuTienNuoc_HoaDons.Count > 0 ? (item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongMoi).Value - item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongCu).Value) / item.SoTien1m3 : 0,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(string DanhBo)
        {
            var query = from item in db.TruyThuTienNuoc_ChiTiets
                        where item.DanhBo == DanhBo
                        select new
                        {
                            MaDon = item.TruyThuTienNuoc.MaDon != null ? "TKH" + item.TruyThuTienNuoc.MaDon
                                : item.TruyThuTienNuoc.MaDonTXL != null ? "TXL" + item.TruyThuTienNuoc.MaDonTXL
                                : item.TruyThuTienNuoc.MaDonTBC != null ? "TBC" + item.TruyThuTienNuoc.MaDonTBC : null,
                            SoCongVan = item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.SoCongVan
                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.SoCongVan
                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.SoCongVan : null,
                            item.MaCTTTTN,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.DienThoai,
                            //item.TongTien,
                            //item.Tongm3BinhQuan,
                            TongTien = item.TruyThuTienNuoc_HoaDons.Count > 0 ? item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongMoi).Value - item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongCu).Value : 0,
                            Tongm3BinhQuan = item.TruyThuTienNuoc_HoaDons.Count > 0 ? (item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongMoi).Value - item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongCu).Value) / item.SoTien1m3 : 0,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.TruyThuTienNuoc_ChiTiets
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.TruyThuTienNuoc.MaDon != null ? "TKH" + item.TruyThuTienNuoc.MaDon
                                : item.TruyThuTienNuoc.MaDonTXL != null ? "TXL" + item.TruyThuTienNuoc.MaDonTXL
                                : item.TruyThuTienNuoc.MaDonTBC != null ? "TBC" + item.TruyThuTienNuoc.MaDonTBC : null,
                            SoCongVan = item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.SoCongVan
                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.SoCongVan
                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.SoCongVan : null,
                            item.MaCTTTTN,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.DienThoai,
                            //item.TongTien,
                            //item.Tongm3BinhQuan,
                            TongTien = item.TruyThuTienNuoc_HoaDons.Count > 0 ? item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongMoi).Value - item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongCu).Value : 0,
                            Tongm3BinhQuan = item.TruyThuTienNuoc_HoaDons.Count > 0 ? (item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongMoi).Value - item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongCu).Value) / item.SoTien1m3 : 0,
                            //XepDon = item.TinhTrang != null ? item.TinhTrang != "" ? item.TinhTrang != "Đang gửi thư mời" ? true : false : false : false,
                            item.TinhTrang,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime FromNgayTinhTrang, DateTime ToNgayTinhTrang, string TinhTrang)
        {
            var query = from item in db.TruyThuTienNuoc_ChiTiets
                        where item.NgayTinhTrang.Value.Date >= FromNgayTinhTrang.Date && item.NgayTinhTrang.Value.Date <= ToNgayTinhTrang.Date && item.TinhTrang.ToString() == TinhTrang
                        select new
                        {
                            MaDon = item.TruyThuTienNuoc.MaDon != null ? "TKH" + item.TruyThuTienNuoc.MaDon
                                : item.TruyThuTienNuoc.MaDonTXL != null ? "TXL" + item.TruyThuTienNuoc.MaDonTXL
                                : item.TruyThuTienNuoc.MaDonTBC != null ? "TBC" + item.TruyThuTienNuoc.MaDonTBC : null,
                            SoCongVan = item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.SoCongVan
                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.SoCongVan
                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.SoCongVan : null,
                            item.MaCTTTTN,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.DienThoai,
                            //item.TongTien,
                            //item.Tongm3BinhQuan,
                            TongTien = item.TruyThuTienNuoc_HoaDons.Count > 0 ? item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongMoi).Value - item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongCu).Value : 0,
                            Tongm3BinhQuan = item.TruyThuTienNuoc_HoaDons.Count > 0 ? (item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongMoi).Value - item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongCu).Value) / item.SoTien1m3 : 0,
                            //XepDon = item.TinhTrang != null ? item.TinhTrang != "" ? item.TinhTrang != "Đang gửi thư mời" ? true : false : false : false,
                            item.TinhTrang,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSNoiDung()
        {
            return LINQToDataTable(db.TruyThuTienNuoc_ChiTiets.Select(item => new { item.NoiDung }).ToList().Distinct());
        }

        #endregion

        #region TruyThuTienNuoc_HoaDon

        public bool Them_HoaDon(TruyThuTienNuoc_HoaDon cttttn)
        {
            try
            {
                if (db.TruyThuTienNuoc_HoaDons.Count() > 0)
                {
                    cttttn.MaCTTTTN = db.TruyThuTienNuoc_HoaDons.Max(item => item.MaCTTTTN) + 1;
                }
                else
                    cttttn.MaCTTTTN = 1;
                cttttn.CreateDate = DateTime.Now;
                cttttn.CreateBy = CTaiKhoan.MaUser;
                db.TruyThuTienNuoc_HoaDons.InsertOnSubmit(cttttn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua_HoaDon(TruyThuTienNuoc_HoaDon cttttn)
        {
            try
            {
                cttttn.ModifyDate = DateTime.Now;
                cttttn.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_HoaDon(TruyThuTienNuoc_HoaDon cttttn)
        {
            try
            {
                db.TruyThuTienNuoc_HoaDons.DeleteOnSubmit(cttttn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool CheckExist_HoaDon(decimal MaCTTTTN, string Ky, string Nam)
        {
            return db.TruyThuTienNuoc_HoaDons.Any(item => item.MaCTTTTN == MaCTTTTN && item.Ky == Ky && item.Nam == Nam);
        }

        public TruyThuTienNuoc_HoaDon get_HoaDon(decimal MaCTTTTN)
        {
            return db.TruyThuTienNuoc_HoaDons.SingleOrDefault(item => item.MaCTTTTN == MaCTTTTN);
        }

        public TruyThuTienNuoc_HoaDon get_HoaDon(decimal MaCTTTTN, string Ky, string Nam)
        {
            return db.TruyThuTienNuoc_HoaDons.SingleOrDefault(item => item.MaCTTTTN == MaCTTTTN && item.Ky == Ky && item.Nam == Nam);
        }

        #endregion

        #region TruyThuTienNuoc_ThanhToan

        public bool Them_ThanhToan(TruyThuTienNuoc_ThanhToan tttttn)
        {
            try
            {
                if (db.TruyThuTienNuoc_ThanhToans.Count() > 0)
                {
                    tttttn.ID = db.TruyThuTienNuoc_ThanhToans.Max(item => item.ID) + 1;
                }
                else
                    tttttn.ID = 1;
                tttttn.CreateDate = DateTime.Now;
                tttttn.CreateBy = CTaiKhoan.MaUser;
                db.TruyThuTienNuoc_ThanhToans.InsertOnSubmit(tttttn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua_ThanhToan(TruyThuTienNuoc_ThanhToan tttttn)
        {
            try
            {
                tttttn.ModifyDate = DateTime.Now;
                tttttn.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_ThanhToan(TruyThuTienNuoc_ThanhToan tttttn)
        {
            try
            {
                db.TruyThuTienNuoc_ThanhToans.DeleteOnSubmit(tttttn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public TruyThuTienNuoc_ThanhToan get_ThanhToan(int ID)
        {
            return db.TruyThuTienNuoc_ThanhToans.SingleOrDefault(item => item.ID == ID);
        }

        public List<TruyThuTienNuoc_ThanhToan> getDS_ThanhToan(decimal MaCTTTTN)
        {
            return db.TruyThuTienNuoc_ThanhToans.Where(item => item.MaCTTTTN == MaCTTTTN).ToList();
        }

        #endregion

        #region Thư Mời

        public bool Them_ThuMoi(TruyThuTienNuoc_ThuMoi entity)
        {
            try
            {
                if (db.TruyThuTienNuoc_ThuMois.Count() > 0)
                {
                    entity.ID = db.TruyThuTienNuoc_ThuMois.Max(item => item.ID) + 1;
                    if (db.TruyThuTienNuoc_ThuMois.Where(item => item.MaCTTTTN == entity.MaCTTTTN).Count() == 0)
                        entity.STT = 2;
                    else
                        entity.STT = db.TruyThuTienNuoc_ThuMois.Where(item => item.MaCTTTTN == entity.MaCTTTTN).Count() + 1;
                }
                else
                {
                    entity.ID = 1;
                    entity.STT = 2;
                }
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.TruyThuTienNuoc_ThuMois.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua_ThuMoi(TruyThuTienNuoc_ThuMoi entity)
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

        public bool Xoa_ThuMoi(TruyThuTienNuoc_ThuMoi entity)
        {
            try
            {
                db.TruyThuTienNuoc_ThuMois.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public TruyThuTienNuoc_ThuMoi get_ThuMoi(int ID)
        {
            return db.TruyThuTienNuoc_ThuMois.SingleOrDefault(item => item.ID == ID);
        }

        public List<TruyThuTienNuoc_ThuMoi> getDS_ThuMoi(decimal MaCTTTTN)
        {
            return db.TruyThuTienNuoc_ThuMois.Where(item => item.MaCTTTTN == MaCTTTTN).ToList();
        }

        #endregion

        public int CountTongTienThanhToan(decimal MaCTTTTN)
        {
            try
            {
                if (db.TruyThuTienNuoc_HoaDons.Any(item => item.MaCTTTTN == MaCTTTTN))
                    return db.TruyThuTienNuoc_HoaDons.Where(item => item.MaCTTTTN == MaCTTTTN).Sum(item => item.TongCongMoi).Value - db.TruyThuTienNuoc_HoaDons.Where(item => item.MaCTTTTN == MaCTTTTN).Sum(item => item.TongCongCu).Value;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int CountTongm3(decimal MaCTTTTN)
        {
            try
            {
                if (db.TruyThuTienNuoc_HoaDons.Any(item => item.MaCTTTTN == MaCTTTTN))
                    return (db.TruyThuTienNuoc_HoaDons.Where(item => item.MaCTTTTN == MaCTTTTN).Sum(item => item.TongCongMoi).Value - db.TruyThuTienNuoc_HoaDons.Where(item => item.MaCTTTTN == MaCTTTTN).Sum(item => item.TongCongCu).Value) / SoTien1m3;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        //MaDonMoi

        public bool checkExist(int MaDon)
        {
                    return db.TruyThuTienNuocs.Any(item => item.MaDonMoi == MaDon);
        }

        public bool checkExist_ChiTiet(int MaDon, string DanhBo)
        {
                    return db.TruyThuTienNuoc_ChiTiets.Any(item => item.TruyThuTienNuoc.MaDonMoi == MaDon && item.DanhBo == DanhBo);
        }

        public TruyThuTienNuoc get(int MaDon)
        {
                    return db.TruyThuTienNuocs.SingleOrDefault(item => item.MaDonMoi == MaDon);
        }
    }
}

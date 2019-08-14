using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;
using System.Data;
using KTKS_DonKH.DAL.DonTu;

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
                    string Column = "ID";
                    string Table = "TruyThuTienNuoc";
                    int ID = db.ExecuteQuery<int>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + Column + "),LEN(CONVERT(nvarchar(50)," + Column + "))-1,2)) from " + Table + " " +
                        "select MAX(" + Column + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + Column + "),LEN(CONVERT(nvarchar(50)," + Column + "))-1,2)=@Ma").Single();
                    tttn.ID = (int)getMaxNextIDTable(ID);
                }
                else
                    tttn.ID = int.Parse("1" + DateTime.Now.ToString("yy"));
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
                    string Column = "IDCT";
                    string Table = "TruyThuTienNuoc_ChiTiet";
                    int IDCT = db.ExecuteQuery<int>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + Column + "),LEN(CONVERT(nvarchar(50)," + Column + "))-1,2)) from " + Table + " " +
                        "select MAX(" + Column + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + Column + "),LEN(CONVERT(nvarchar(50)," + Column + "))-1,2)=@Ma").Single();
                    cttttn.IDCT = (int)getMaxNextIDTable(IDCT);
                }
                else
                    cttttn.IDCT = int.Parse("1" + DateTime.Now.ToString("yy"));
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
                CDonTu _cDonTu = new CDonTu();
                _cDonTu.Xoa_LichSu("TruyThuTienNuoc_ChiTiet", (int)cttttn.IDCT);
                int ID = cttttn.ID.Value;
                int IDCT = cttttn.IDCT;
                db.TruyThuTienNuoc_HoaDons.DeleteAllOnSubmit(cttttn.TruyThuTienNuoc_HoaDons.ToList());
                db.SubmitChanges();
                db.TruyThuTienNuoc_ThanhToans.DeleteAllOnSubmit(db.TruyThuTienNuoc_ThanhToans.Where(item=>item.IDCT==IDCT).ToList());
                db.SubmitChanges();
                db.TruyThuTienNuoc_ThuMois.DeleteAllOnSubmit(cttttn.TruyThuTienNuoc_ThuMois.ToList());
                db.SubmitChanges();
                db.TruyThuTienNuoc_ChiTiets.DeleteOnSubmit(cttttn);
                db.SubmitChanges();
                if (db.TruyThuTienNuoc_ChiTiets.Any(item => item.ID == ID) == false)
                    db.TruyThuTienNuocs.DeleteOnSubmit(db.TruyThuTienNuocs.SingleOrDefault(item => item.ID == ID));
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist_ChiTiet(decimal IDCT)
        {
            return db.TruyThuTienNuoc_ChiTiets.Any(item => item.IDCT == IDCT);
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

        public string check_TinhTrang_Ton(string DanhBo)
        {
            //if (db.TruyThuTienNuoc_ChiTiets.Any(item => item.DanhBo == DanhBo && (item.TinhTrang != "Đã thanh toán" && item.TinhTrang != "Điều chỉnh không phát sinh truy thu" && item.TinhTrang != "Miễn truy thu" && item.TinhTrang != "Giữ nguyên")) == true)
            //    return db.TruyThuTienNuoc_ChiTiets.SingleOrDefault(item => item.DanhBo == DanhBo && (item.TinhTrang != "Đã thanh toán" && item.TinhTrang != "Điều chỉnh không phát sinh truy thu" && item.TinhTrang != "Miễn truy thu" && item.TinhTrang != "Giữ nguyên")).TinhTrang;
            //else
            //    return "";
            return ExecuteQuery_ReturnOneValue("select dbo.fnCheckTinhTrangTruyThu_Ton('" + DanhBo + "')").ToString();
        }

        public TruyThuTienNuoc_ChiTiet get_ChiTiet(decimal IDCT)
        {
            return db.TruyThuTienNuoc_ChiTiets.SingleOrDefault(item => item.IDCT == IDCT);
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

        public DataTable getDS(int IDCT)
        {
            var query = from item in db.TruyThuTienNuoc_ChiTiets
                        where item.IDCT == IDCT
                        select new
                        {
                            MaDon = item.TruyThuTienNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.TruyThuTienNuoc.MaDonMoi).Count() == 1 ?  item.TruyThuTienNuoc.MaDonMoi.Value.ToString() : item.TruyThuTienNuoc.MaDonMoi + "." + item.STT
                                    : item.TruyThuTienNuoc.MaDon != null ? "TKH" + item.TruyThuTienNuoc.MaDon
                                    : item.TruyThuTienNuoc.MaDonTXL != null ? "TXL" + item.TruyThuTienNuoc.MaDonTXL
                                    : item.TruyThuTienNuoc.MaDonTBC != null ? "TBC" + item.TruyThuTienNuoc.MaDonTBC : null,
                            SoCongVan = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.SoCongVan
                                    : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.SoCongVan
                                    : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.SoCongVan
                                    : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.SoCongVan : null,
                            item.IDCT,
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

        public DataTable getDS(string DanhBo)
        {
            var query = from item in db.TruyThuTienNuoc_ChiTiets
                        where item.DanhBo == DanhBo
                        select new
                        {
                            MaDon = item.TruyThuTienNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.TruyThuTienNuoc.MaDonMoi).Count() == 1 ?  item.TruyThuTienNuoc.MaDonMoi.Value.ToString() : item.TruyThuTienNuoc.MaDonMoi + "." + item.STT
                                    : item.TruyThuTienNuoc.MaDon != null ? "TKH" + item.TruyThuTienNuoc.MaDon
                                    : item.TruyThuTienNuoc.MaDonTXL != null ? "TXL" + item.TruyThuTienNuoc.MaDonTXL
                                    : item.TruyThuTienNuoc.MaDonTBC != null ? "TBC" + item.TruyThuTienNuoc.MaDonTBC : null,
                            SoCongVan = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.SoCongVan
                                    :item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.SoCongVan
                                    : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.SoCongVan
                                    : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.SoCongVan : null,
                            item.IDCT,
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

        public DataTable getDS(DateTime FromNgayTinhTrang, DateTime ToNgayTinhTrang)
        {
            var query = from item in db.TruyThuTienNuoc_ChiTiets
                        where item.NgayTinhTrang.Value.Date >= FromNgayTinhTrang.Date && item.NgayTinhTrang.Value.Date <= ToNgayTinhTrang.Date
                        select new
                        {
                            MaDon = item.TruyThuTienNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.TruyThuTienNuoc.MaDonMoi).Count() == 1 ?  item.TruyThuTienNuoc.MaDonMoi.Value.ToString() : item.TruyThuTienNuoc.MaDonMoi + "." + item.STT
                                    : item.TruyThuTienNuoc.MaDon != null ? "TKH" + item.TruyThuTienNuoc.MaDon
                                    : item.TruyThuTienNuoc.MaDonTXL != null ? "TXL" + item.TruyThuTienNuoc.MaDonTXL
                                    : item.TruyThuTienNuoc.MaDonTBC != null ? "TBC" + item.TruyThuTienNuoc.MaDonTBC : null,
                            SoCongVan = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.SoCongVan
                                    : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.SoCongVan
                                    : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.SoCongVan
                                    : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.SoCongVan : null,
                            item.IDCT,
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

        public DataTable getDS(DateTime FromNgayTinhTrang, DateTime ToNgayTinhTrang, string TinhTrang)
        {
            var query = from item in db.TruyThuTienNuoc_ChiTiets
                        where item.NgayTinhTrang.Value.Date >= FromNgayTinhTrang.Date && item.NgayTinhTrang.Value.Date <= ToNgayTinhTrang.Date && item.TinhTrang.ToString() == TinhTrang
                        select new
                        {
                            MaDon = item.TruyThuTienNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.TruyThuTienNuoc.MaDonMoi).Count() == 1 ? item.TruyThuTienNuoc.MaDonMoi.Value.ToString() : item.TruyThuTienNuoc.MaDonMoi + "." + item.STT
                                    : item.TruyThuTienNuoc.MaDon != null ? "TKH" + item.TruyThuTienNuoc.MaDon
                                    : item.TruyThuTienNuoc.MaDonTXL != null ? "TXL" + item.TruyThuTienNuoc.MaDonTXL
                                    : item.TruyThuTienNuoc.MaDonTBC != null ? "TBC" + item.TruyThuTienNuoc.MaDonTBC : null,
                            SoCongVan = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.SoCongVan
                                    : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.SoCongVan
                                    : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.SoCongVan
                                    : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.SoCongVan : null,
                            item.IDCT,
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

        public bool Them_HoaDon(TruyThuTienNuoc_HoaDon hoadon)
        {
            try
            {
                if (db.TruyThuTienNuoc_HoaDons.Count() > 0)
                {
                    hoadon.ID = db.TruyThuTienNuoc_HoaDons.Max(item => item.ID) + 1;
                }
                else
                    hoadon.ID = 1;
                hoadon.CreateDate = DateTime.Now;
                hoadon.CreateBy = CTaiKhoan.MaUser;
                db.TruyThuTienNuoc_HoaDons.InsertOnSubmit(hoadon);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua_HoaDon(TruyThuTienNuoc_HoaDon hoadon)
        {
            try
            {
                hoadon.ModifyDate = DateTime.Now;
                hoadon.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_HoaDon(TruyThuTienNuoc_HoaDon hoadon)
        {
            try
            {
                db.TruyThuTienNuoc_HoaDons.DeleteOnSubmit(hoadon);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool CheckExist_HoaDon(decimal IDCT, int Ky, int Nam)
        {
            return db.TruyThuTienNuoc_HoaDons.Any(item => item.IDCT == IDCT && item.Ky == Ky && item.Nam == Nam);
        }

        public TruyThuTienNuoc_HoaDon get_HoaDon(decimal IDCT)
        {
            return db.TruyThuTienNuoc_HoaDons.SingleOrDefault(item => item.IDCT == IDCT);
        }

        public TruyThuTienNuoc_HoaDon get_HoaDon(decimal IDCT, int Ky, int Nam)
        {
            return db.TruyThuTienNuoc_HoaDons.SingleOrDefault(item => item.IDCT == IDCT && item.Ky == Ky && item.Nam == Nam);
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

        public List<TruyThuTienNuoc_ThanhToan> getDS_ThanhToan(int IDCT)
        {
            return db.TruyThuTienNuoc_ThanhToans.Where(item => item.IDCT == IDCT).ToList();
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
                    if (db.TruyThuTienNuoc_ThuMois.Where(item => item.IDCT == entity.IDCT).Count() == 0)
                        entity.STT = 2;
                    else
                        entity.STT = db.TruyThuTienNuoc_ThuMois.Where(item => item.IDCT == entity.IDCT).Count() + 1;
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

        public List<TruyThuTienNuoc_ThuMoi> getDS_ThuMoi(int IDCT)
        {
            return db.TruyThuTienNuoc_ThuMois.Where(item => item.IDCT == IDCT).ToList();
        }

        public DataTable getDS_ThuMoi(DateTime FromCreateDate,DateTime ToCreateDate)
        {
            var query = from item in db.TruyThuTienNuoc_ThuMois
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc.MaDonMoi).Count() == 1 ? "" + item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc.MaDonMoi : item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc.MaDonMoi + "." + item.STT
                                    : item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc.MaDon != null ? "TKH" + item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc.MaDon
                                    : item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc.MaDonTXL != null ? "TXL" + item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc.MaDonTXL
                                    : item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc.MaDonTBC != null ? "TBC" + item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc.MaDonTBC : null,
                            SoCongVan = item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc.DonTu.SoCongVan
                                    : item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc.DonKH.SoCongVan
                                    : item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc.DonTXL.SoCongVan
                                    : item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc.DonTBC.SoCongVan : null,
                            item.IDCT,
                            item.CreateDate,
                            item.TruyThuTienNuoc_ChiTiet.DanhBo,
                            item.TruyThuTienNuoc_ChiTiet.HoTen,
                            item.TruyThuTienNuoc_ChiTiet.DiaChi,
                            item.TruyThuTienNuoc_ChiTiet.NoiDung,
                            item.TruyThuTienNuoc_ChiTiet.DienThoai,
                            //item.TongTien,
                            //item.Tongm3BinhQuan,
                            TongTien = item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc_HoaDons.Count > 0 ? item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongMoi).Value - item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongCu).Value : 0,
                            Tongm3BinhQuan = item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc_HoaDons.Count > 0 ? (item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongMoi).Value - item.TruyThuTienNuoc_ChiTiet.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongCu).Value) / item.TruyThuTienNuoc_ChiTiet.SoTien1m3 : 0,
                            //XepDon = item.TinhTrang != null ? item.TinhTrang != "" ? item.TinhTrang != "Đang gửi thư mời" ? true : false : false : false,
                            //item.TinhTrang,
                        };
            return LINQToDataTable(query);
        }

        #endregion

        public int CountTongTienThanhToan(int IDCT)
        {
            try
            {
                if (db.TruyThuTienNuoc_HoaDons.Any(item => item.IDCT == IDCT))
                    return db.TruyThuTienNuoc_HoaDons.Where(item => item.IDCT == IDCT).Sum(item => item.TongCongMoi).Value - db.TruyThuTienNuoc_HoaDons.Where(item => item.IDCT == IDCT).Sum(item => item.TongCongCu).Value;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int CountTongm3(int IDCT)
        {
            try
            {
                if (db.TruyThuTienNuoc_HoaDons.Any(item => item.IDCT == IDCT))
                    return (db.TruyThuTienNuoc_HoaDons.Where(item => item.IDCT == IDCT).Sum(item => item.TongCongMoi).Value - db.TruyThuTienNuoc_HoaDons.Where(item => item.IDCT == IDCT).Sum(item => item.TongCongCu).Value) / SoTien1m3;
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

        #region Hình

        public bool Them_Hinh(TruyThuTienNuoc_ChiTiet_Hinh en)
        {
            try
            {
                if (db.TruyThuTienNuoc_ChiTiet_Hinhs.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = db.TruyThuTienNuoc_ChiTiet_Hinhs.Max(item => item.ID) + 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.TruyThuTienNuoc_ChiTiet_Hinhs.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_Hinh(TruyThuTienNuoc_ChiTiet_Hinh en)
        {
            try
            {
                db.TruyThuTienNuoc_ChiTiet_Hinhs.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public TruyThuTienNuoc_ChiTiet_Hinh get_Hinh(int ID)
        {
            return db.TruyThuTienNuoc_ChiTiet_Hinhs.SingleOrDefault(item => item.ID == ID);
        }

        #endregion
    }
}

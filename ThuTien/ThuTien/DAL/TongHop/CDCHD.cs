using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.TongHop
{
    class CDCHD:CDAL
    {
        dbKTKS_DonKHDataContext _dbKTKS_DonKH = new dbKTKS_DonKHDataContext();

        public bool Them(DIEUCHINH_HD dchd)
        {
            try
            {
                //if (_db.DIEUCHINH_HDs.Count() > 0)
                //    hoadon.ID_DIEUCHINH_HD = _db.DIEUCHINH_HDs.Max(item => item.ID_DIEUCHINH_HD) + 1;
                //else
                //    hoadon.ID_DIEUCHINH_HD = 1;
                dchd.CreateDate = DateTime.Now;
                dchd.CreateBy = CNguoiDung.MaND;
                _db.DIEUCHINH_HDs.InsertOnSubmit(dchd);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(DIEUCHINH_HD dchd)
        {
            try
            {
                dchd.ModifyDate = DateTime.Now;
                dchd.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(DIEUCHINH_HD dchd)
        {
            try
            {
                _db.DIEUCHINH_HDs.DeleteOnSubmit(dchd);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckBySoHoaDon(string SoHoaDon)
        {
            try
            {
                return _db.DIEUCHINH_HDs.Any(item => item.SoHoaDon == SoHoaDon && item.TangGiam == null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DIEUCHINH_HD> GetDS()
        {
            return _db.DIEUCHINH_HDs.ToList();
        }

        public DataTable GetChuanThu(string Loai, int MaTo, int Nam, int Ky, int Dot)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot && itemHD.GB >= 11 && itemHD.GB <= 20
                            select new
                            {
                                MaTo = MaTo,
                                _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                                MaNV=itemHD.MaNV_HanhThu,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                itemHD.NGAYGIAITRACH,
                                itemDC.GIABAN_BD,
                                itemDC.TONGCONG_BD,
                                itemDC.GIABAN_END,
                                itemDC.TONGCONG_END,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemDC in _db.DIEUCHINH_HDs
                                join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                                where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot && itemHD.GB > 20
                                select new
                                {
                                    MaTo = MaTo,
                                    _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                                    MaNV = itemHD.MaNV_HanhThu,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                    itemHD.NGAYGIAITRACH,
                                    itemDC.GIABAN_BD,
                                    itemDC.TONGCONG_BD,
                                    itemDC.GIABAN_END,
                                    itemDC.TONGCONG_END,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetChuanThu(string Loai, int MaTo, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && itemDC.SoPhieu!=null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.GB >= 11 && itemHD.GB <= 20
                            select new
                            {
                                MaTo = MaTo,
                                _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                                MaNV = itemHD.MaNV_HanhThu,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                itemHD.NGAYGIAITRACH,
                                itemDC.GIABAN_BD,
                                itemDC.TONGCONG_BD,
                                itemDC.GIABAN_END,
                                itemDC.TONGCONG_END,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemDC in _db.DIEUCHINH_HDs
                                join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                                where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        &&itemDC.SoPhieu!=null&& itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.GB > 20
                                select new
                                {
                                    MaTo = MaTo,
                                    _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                                    MaNV = itemHD.MaNV_HanhThu,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                    itemHD.NGAYGIAITRACH,
                                    itemDC.GIABAN_BD,
                                    itemDC.TONGCONG_BD,
                                    itemDC.GIABAN_END,
                                    itemDC.TONGCONG_END,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetChuanThu(string Loai, int MaTo, int Nam)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    &&itemDC.SoPhieu!=null&& itemHD.NAM == Nam && itemHD.GB >= 11 && itemHD.GB <= 20
                            select new
                            {
                                MaTo = MaTo,
                                _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                                MaNV = itemHD.MaNV_HanhThu,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                itemHD.NGAYGIAITRACH,
                                itemDC.GIABAN_BD,
                                itemDC.TONGCONG_BD,
                                itemDC.GIABAN_END,
                                itemDC.TONGCONG_END,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemDC in _db.DIEUCHINH_HDs
                                join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                                where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        &&itemDC.SoPhieu!=null&& itemHD.NAM == Nam && itemHD.GB > 20
                                select new
                                {
                                    MaTo = MaTo,
                                    _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                                    MaNV = itemHD.MaNV_HanhThu,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                    itemDC.GIABAN_BD,
                                    itemDC.TONGCONG_BD,
                                    itemDC.GIABAN_END,
                                    itemDC.TONGCONG_END,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        //public DataTable GetDSChuaDCHD(int MaNV)
        //{
        //    var query = from itemDC in _db.DIEUCHINH_HDs
        //                join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
        //                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND
        //                where itemDC.CreateBy == MaNV && itemDC.TangGiam==null
        //                select new
        //                {
        //                    MaDCHD = itemDC.ID_DIEUCHINH_HD,
        //                    itemHD.NGAYGIAITRACH,
        //                    itemDC.CreateDate,
        //                    itemHD.SOHOADON,
        //                    itemHD.SOPHATHANH,
        //                    itemHD.NAM,
        //                    itemHD.KY,
        //                    itemHD.DOT,
        //                    MLT = itemHD.MALOTRINH,
        //                    DanhBo = itemHD.DANHBA,
        //                    HoTen = itemHD.TENKH,
        //                    DiaChi = itemHD.SO + " " + itemHD.DUONG,
        //                    GiaBan_Start=itemDC.GIABAN_BD,
        //                    ThueGTGT_Start = itemDC.THUE_BD,
        //                    PhiBVMT_Start = itemDC.PHI_BD,
        //                    TongCong_Start=itemDC.TONGCONG_BD,
        //                    itemDC.TangGiam,
        //                    TongCong_BD=itemDC.TONGCONG_DC,
        //                    TongCong_End=itemDC.TONGCONG_END,
        //                    HanhThu = itemND.TT_To.TenTo + ": " + itemND.HoTen,
        //                };
        //    return LINQToDataTable(query);
        //}

        //public DataTable GetDSDaDCHD(int MaNV)
        //{
        //    var query = from itemDC in _db.DIEUCHINH_HDs
        //                join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
        //                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND
        //                where itemDC.CreateBy == MaNV && itemDC.TangGiam != null
        //                select new
        //                {
        //                    MaDCHD = itemDC.ID_DIEUCHINH_HD,
        //                    itemHD.NGAYGIAITRACH,
        //                    itemDC.CreateDate,
        //                    itemHD.SOHOADON,
        //                    itemHD.SOPHATHANH,
        //                    itemHD.NAM,
        //                    itemHD.KY,
        //                    itemHD.DOT,
        //                    MLT = itemHD.MALOTRINH,
        //                    DanhBo = itemHD.DANHBA,
        //                    HoTen = itemHD.TENKH,
        //                    DiaChi = itemHD.SO + " " + itemHD.DUONG,
        //                    GiaBan_Start = itemDC.GIABAN_BD,
        //                    ThueGTGT_Start = itemDC.THUE_BD,
        //                    PhiBVMT_Start = itemDC.PHI_BD,
        //                    TongCong_Start = itemDC.TONGCONG_BD,
        //                    itemDC.TangGiam,
        //                    TongCong_BD = itemDC.TONGCONG_DC,
        //                    TongCong_End = itemDC.TONGCONG_END,
        //                    HanhThu = itemND.TT_To.TenTo + ": " + itemND.HoTen,
        //                };
        //    return LINQToDataTable(query);
        //}

        public DataTable GetDSByMaNVCreateDate(bool DaDieuChinh,int MaNV,DateTime TuNgay)
        {
            if (DaDieuChinh)
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemDC.TangGiam != null && itemDC.CreateBy == MaNV && itemDC.CreateDate.Value.Date==TuNgay.Date
                            select new
                            {
                                MaDCHD = itemDC.ID_DIEUCHINH_HD,
                                itemHD.SOHOADON,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                GiaBan_Start = itemDC.GIABAN_BD,
                                ThueGTGT_Start = itemDC.THUE_BD,
                                PhiBVMT_Start = itemDC.PHI_BD,
                                TongCong_Start = itemDC.TONGCONG_BD,
                                itemDC.TangGiam,
                                TongCong_BD = itemDC.TONGCONG_DC,
                                TongCong_End = itemDC.TONGCONG_END,
                                HanhThu = itemtableND.TT_To.TenTo + ": " + itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            else
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemDC.TangGiam == null && itemDC.CreateBy == MaNV && itemDC.CreateDate.Value.Date == TuNgay.Date
                            select new
                            {
                                MaDCHD = itemDC.ID_DIEUCHINH_HD,
                                itemHD.SOHOADON,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                GiaBan_Start = itemDC.GIABAN_BD,
                                ThueGTGT_Start = itemDC.THUE_BD,
                                PhiBVMT_Start = itemDC.PHI_BD,
                                TongCong_Start = itemDC.TONGCONG_BD,
                                itemDC.TangGiam,
                                TongCong_BD = itemDC.TONGCONG_DC,
                                TongCong_End = itemDC.TONGCONG_END,
                                HanhThu = itemtableND.TT_To.TenTo + ": " + itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
        }

        public DataTable GetDSByMaNVCreateDates(bool DaDieuChinh, int MaNV, DateTime TuNgay, DateTime DenNgay)
        {
            if (DaDieuChinh)
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemDC.TangGiam != null && itemDC.CreateBy == MaNV && itemDC.CreateDate.Value.Date >= TuNgay.Date && itemDC.CreateDate.Value.Date <= DenNgay.Date
                            select new
                            {
                                itemDC.CreateDate,
                                MaDCHD = itemDC.ID_DIEUCHINH_HD,
                                itemHD.SOHOADON,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                GiaBan_Start = itemDC.GIABAN_BD,
                                ThueGTGT_Start = itemDC.THUE_BD,
                                PhiBVMT_Start = itemDC.PHI_BD,
                                TongCong_Start = itemDC.TONGCONG_BD,
                                itemDC.TangGiam,
                                TongCong_BD = itemDC.TONGCONG_DC,
                                TongCong_End = itemDC.TONGCONG_END,
                                HanhThu = itemtableND.TT_To.TenTo + ": " + itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            else
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemDC.TangGiam == null && itemDC.CreateBy == MaNV && itemDC.CreateDate.Value.Date >= TuNgay.Date && itemDC.CreateDate.Value.Date <= DenNgay.Date
                            select new
                            {
                                MaDCHD = itemDC.ID_DIEUCHINH_HD,
                                itemHD.SOHOADON,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                GiaBan_Start = itemDC.GIABAN_BD,
                                ThueGTGT_Start = itemDC.THUE_BD,
                                PhiBVMT_Start = itemDC.PHI_BD,
                                TongCong_Start = itemDC.TONGCONG_BD,
                                itemDC.TangGiam,
                                TongCong_BD = itemDC.TONGCONG_DC,
                                TongCong_End = itemDC.TONGCONG_END,
                                HanhThu = itemtableND.TT_To.TenTo + ": " + itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
        }

        public DIEUCHINH_HD GetByMaDCHD(int MaDC)
        {
            return _db.DIEUCHINH_HDs.SingleOrDefault(item => item.ID_DIEUCHINH_HD == MaDC);
        }

        public DIEUCHINH_HD GetBySoHoaDon(string SoHoaDon)
        {
            return _db.DIEUCHINH_HDs.SingleOrDefault(item => item.SoHoaDon == SoHoaDon);
        }

        public DonKH GetDonKHbyID(decimal MaDon)
        {
            return _dbKTKS_DonKH.DonKHs.SingleOrDefault(itemDonKH => itemDonKH.MaDon == MaDon);
        }

        public DonTXL GetDonTXLbyID(decimal MaDon)
        {
            return _dbKTKS_DonKH.DonTXLs.SingleOrDefault(itemDonTXL => itemDonTXL.MaDon == MaDon);
        }

        public CTDCHD GetCTDCHDBySoPhieu(decimal SoPhieu)
        {
            return _dbKTKS_DonKH.CTDCHDs.SingleOrDefault(item => item.MaCTDCHD == SoPhieu);
        }
    }
}

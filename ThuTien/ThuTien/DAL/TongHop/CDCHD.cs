using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.TongHop
{
    class CDCHD : CDAL
    {
        public bool ThemLSDC(TT_LichSuDieuChinhHD lsdc)
        {
            try
            {
                lsdc.CreateDate = DateTime.Now;
                lsdc.CreateBy = CNguoiDung.MaND;
                _db.TT_LichSuDieuChinhHDs.InsertOnSubmit(lsdc);
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

        public bool CheckExistByDangRutDC(string SoHoaDon)
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

        public bool CheckExist(string SoHoaDon)
        {
            try
            {
                return _db.DIEUCHINH_HDs.Any(item => item.SoHoaDon == SoHoaDon);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DIEUCHINH_HD Get(string SoHoaDon)
        {
            return _db.DIEUCHINH_HDs.SingleOrDefault(item => item.SoHoaDon == SoHoaDon);
        }

        public List<DIEUCHINH_HD> GetDS()
        {
            return _db.DIEUCHINH_HDs.ToList();
        }

        public DataTable GetTongChuanThu(int Nam, int Ky)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky
                        group itemDC by itemHD.KY into itemGroup
                        select new
                        {
                            Ky = Ky,
                            GIABAN_BD = itemGroup.Sum(groupItem => groupItem.GIABAN_BD),
                            TONGCONG_BD = itemGroup.Sum(groupItem => groupItem.TONGCONG_BD),
                            GIABAN_END = itemGroup.Sum(groupItem => groupItem.GIABAN_END),
                            TONGCONG_END = itemGroup.Sum(groupItem => groupItem.TONGCONG_END),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetTongChuanThu(int MaTo, int Nam, int Ky, int Dot)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot
                        group itemDC by itemHD.KY into itemGroup
                        select new
                        {
                            MaTo = MaTo,
                            _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                            GIABAN_BD = itemGroup.Sum(groupItem => groupItem.GIABAN_BD),
                            TONGCONG_BD = itemGroup.Sum(groupItem => groupItem.TONGCONG_BD),
                            GIABAN_END = itemGroup.Sum(groupItem => groupItem.GIABAN_END),
                            TONGCONG_END = itemGroup.Sum(groupItem => groupItem.TONGCONG_END),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetChuanThu_Doi(string Loai, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.GB >= 11 && itemHD.GB <= 20
                            select new
                            {
                                Loai="TG",
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
                                where itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.GB > 20
                                select new
                                {
                                    Loai="CQ",
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
                                    && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.GB >= 11 && itemHD.GB <= 20
                            select new
                            {
                                Loai="TG",
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
                                        && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.GB > 20
                                select new
                                {
                                    Loai = "CQ",
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
                                    && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.GB >= 11 && itemHD.GB <= 20
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
                                        && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.GB > 20
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

        public DataTable GetChuanThu(string Loai, int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky 
                                    && itemHD.GB >= 11 && itemHD.GB <= 20
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
                                        && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.GB > 20
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

        public DataTable GetChuanThu(string SoHoaDon)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where itemDC.SoHoaDon == SoHoaDon
                        select new
                        {
                            itemDC.GIABAN_BD,
                            THUEGTGT_BD = itemDC.THUE_BD,
                            PHIBVMT_BD = itemDC.PHI_BD,
                            itemDC.TONGCONG_BD,
                            itemDC.GIABAN_END,
                            THUEGTGT_END = itemDC.THUE_END,
                            PHIBVMT_END = itemDC.PHI_END,
                            itemDC.TONGCONG_END,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetChuanThu_NV(string Loai, int MaNV_HanhThu, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where itemHD.MaNV_HanhThu==MaNV_HanhThu && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.GB >= 11 && itemHD.GB <= 20
                            select new
                            {
                                Loai = "TG",
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
                                where itemHD.MaNV_HanhThu == MaNV_HanhThu && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.GB > 20
                                select new
                                {
                                    Loai = "CQ",
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

        public DataTable GetChuanThuTon(string Loai, int MaTo, int Nam, int Ky, int Dot)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot && itemHD.NGAYGIAITRACH == null && itemHD.GB >= 11 && itemHD.GB <= 20
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
                                        && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot && itemHD.NGAYGIAITRACH == null && itemHD.GB > 20
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

        public DataTable GetChuanThuTon(string Loai, int MaTo, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.NGAYGIAITRACH == null && itemHD.GB >= 11 && itemHD.GB <= 20
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
                                        && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.NGAYGIAITRACH == null && itemHD.GB > 20
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

        public DataTable GetChuanThuTon(string Loai, int MaTo, int Nam)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.NGAYGIAITRACH == null && itemHD.GB >= 11 && itemHD.GB <= 20
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
                                        && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.NGAYGIAITRACH == null && itemHD.GB > 20
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

        public DataTable GetChuanThuTon(string Loai, int MaTo)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && itemDC.SoPhieu != null && itemHD.NGAYGIAITRACH == null && itemHD.GB >= 11 && itemHD.GB <= 20
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
                                        && itemDC.SoPhieu != null && itemHD.NGAYGIAITRACH == null && itemHD.GB > 20
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

        public DataTable GetChuanThuTon(string Loai, int MaTo, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && itemDC.SoPhieu != null && (itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date) && itemHD.GB >= 11 && itemHD.GB <= 20
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
                                        && itemDC.SoPhieu != null && (itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date) && itemHD.GB > 20
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

        public DataTable GetChuanThuTonDenKy(string Loai, int MaTo, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && itemDC.SoPhieu != null && (itemHD.NAM < Nam || (itemHD.NAM==Nam &&itemHD.KY <= Ky)) && itemHD.NGAYGIAITRACH == null && itemHD.GB >= 11 && itemHD.GB <= 20
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
                                        && itemDC.SoPhieu != null && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky)) && itemHD.NGAYGIAITRACH == null && itemHD.GB > 20
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

        public DataTable GetChuanThuTonDenKyDenNgay(string Loai, int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && itemDC.SoPhieu != null && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky)) && (itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date) && itemHD.GB >= 11 && itemHD.GB <= 20
                            select new
                            {
                                Loai="TG",
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
                                        && itemDC.SoPhieu != null && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky))&&(itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date) && itemHD.GB > 20
                                select new
                                {
                                    Loai = "CQ",
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

        public DataTable GetChuanThuTonTrongKyDenNgay(string Loai, int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && (itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date) && itemHD.GB >= 11 && itemHD.GB <= 20
                            select new
                            {
                                Loai = "TG",
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
                                        && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && (itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date) && itemHD.GB > 20
                                select new
                                {
                                    Loai = "CQ",
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

        public DataTable GetChuanThuTon_NV(string Loai, int MaNV, int Nam, int Ky, int Dot)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where itemHD.MaNV_HanhThu == MaNV
                                    && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot && itemHD.NGAYGIAITRACH == null && itemHD.GB >= 11 && itemHD.GB <= 20
                            select new
                            {
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
                                where itemHD.MaNV_HanhThu == MaNV
                                        && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot && itemHD.NGAYGIAITRACH == null && itemHD.GB > 20
                                select new
                                {
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

        public DataTable GetChuanThuTon_NV(string Loai, int MaNV, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where itemHD.MaNV_HanhThu == MaNV
                                    && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.NGAYGIAITRACH == null && itemHD.GB >= 11 && itemHD.GB <= 20
                            select new
                            {
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
                                where itemHD.MaNV_HanhThu == MaNV
                                        && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.NGAYGIAITRACH == null && itemHD.GB > 20
                                select new
                                {
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

        public DataTable GetChuanThuTon_NV(string Loai, int MaNV, int Nam)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where itemHD.MaNV_HanhThu == MaNV
                                    && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.NGAYGIAITRACH == null && itemHD.GB >= 11 && itemHD.GB <= 20
                            select new
                            {
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
                                where itemHD.MaNV_HanhThu == MaNV
                                        && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.NGAYGIAITRACH == null && itemHD.GB > 20
                                select new
                                {
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

        public DataTable GetChuanThuTon_NV(string Loai, int MaNV)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where itemHD.MaNV_HanhThu == MaNV
                                    && itemDC.SoPhieu != null && itemHD.NGAYGIAITRACH == null && itemHD.GB >= 11 && itemHD.GB <= 20
                            select new
                            {
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
                                where itemHD.MaNV_HanhThu == MaNV
                                        && itemDC.SoPhieu != null && itemHD.NGAYGIAITRACH == null && itemHD.GB > 20
                                select new
                                {
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

        public DataTable GetChuanThuTon_NV(string Loai, int MaNV, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where itemHD.MaNV_HanhThu == MaNV
                                    && itemDC.SoPhieu != null && (itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date) && itemHD.GB >= 11 && itemHD.GB <= 20
                            select new
                            {
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
                                where itemHD.MaNV_HanhThu == MaNV
                                        && itemDC.SoPhieu != null && (itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date) && itemHD.GB > 20
                                select new
                                {
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

        public DataTable GetChuanThuTonDenKy_NV(string Loai, int MaNV, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where itemHD.MaNV_HanhThu == MaNV
                                    && itemDC.SoPhieu != null && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky)) && itemHD.NGAYGIAITRACH == null && itemHD.GB >= 11 && itemHD.GB <= 20
                            select new
                            {
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
                                where itemHD.MaNV_HanhThu == MaNV
                                        && itemDC.SoPhieu != null && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky)) && itemHD.NGAYGIAITRACH == null && itemHD.GB > 20
                                select new
                                {
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

        public DataTable GetChuanThuTonDenKyDenNgay_NV(string Loai, int MaNV,int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where itemHD.MaNV_HanhThu == MaNV
                                    && itemDC.SoPhieu != null && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky))&&(itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date) && itemHD.GB >= 11 && itemHD.GB <= 20
                            select new
                            {
                                Loai="TG",
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
                                where itemHD.MaNV_HanhThu == MaNV
                                        && itemDC.SoPhieu != null && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky))&&(itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date) && itemHD.GB > 20
                                select new
                                {
                                    Loai = "CQ",
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

        public DataTable GetChuanThuTonTrongKyDenNgay_NV(string Loai, int MaNV, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where itemHD.MaNV_HanhThu == MaNV
                                    && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && (itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date) && itemHD.GB >= 11 && itemHD.GB <= 20
                            select new
                            {
                                Loai = "TG",
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
                                where itemHD.MaNV_HanhThu == MaNV
                                        && itemDC.SoPhieu != null && itemHD.NAM == Nam && itemHD.KY == Ky && (itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date) && itemHD.GB > 20
                                select new
                                {
                                    Loai = "CQ",
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

        public DataTable GetDSByCreateDate(bool DaDieuChinh, DateTime TuNgay)
        {
            if (DaDieuChinh)
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemDC.TangGiam != null && itemDC.CreateDate.Value.Date == TuNgay.Date
                            select new
                            {
                                NgayDC = itemDC.NGAY_DC,
                                MaDCHD = itemDC.ID_DIEUCHINH_HD,
                                itemHD.SOHOADON,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                GiaBan_End = itemDC.GIABAN_END,
                                ThueGTGT_End = itemDC.THUE_END,
                                PhiBVMT_End = itemDC.PHI_END,
                                TongCong_End = itemDC.TONGCONG_END,
                                itemDC.TangGiam,
                                TongCong_BD = itemDC.TONGCONG_DC,
                                TongCong_Start = itemDC.TONGCONG_BD,
                                To = itemtableND.TT_To.TenTo,
                                HanhThu = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            else
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemDC.TangGiam == null && itemDC.CreateDate.Value.Date == TuNgay.Date
                            select new
                            {
                                NgayDC = itemDC.NGAY_DC,
                                MaDCHD = itemDC.ID_DIEUCHINH_HD,
                                itemHD.SOHOADON,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                GiaBan_End = itemDC.GIABAN_END,
                                ThueGTGT_End = itemDC.THUE_END,
                                PhiBVMT_End = itemDC.PHI_END,
                                TongCong_End = itemDC.TONGCONG_END,
                                itemDC.TangGiam,
                                TongCong_BD = itemDC.TONGCONG_DC,
                                TongCong_Start = itemDC.TONGCONG_BD,
                                To = itemtableND.TT_To.TenTo,
                                HanhThu = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
        }

        public DataTable GetDSByCreateDates(bool DaDieuChinh, DateTime TuNgay, DateTime DenNgay)
        {
            if (DaDieuChinh)
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemDC.TangGiam != null && itemDC.CreateDate.Value.Date >= TuNgay.Date && itemDC.CreateDate.Value.Date <= DenNgay.Date
                            select new
                            {
                                NgayDC = itemDC.NGAY_DC,
                                MaDCHD = itemDC.ID_DIEUCHINH_HD,
                                itemHD.SOHOADON,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                GiaBan_End = itemDC.GIABAN_END,
                                ThueGTGT_End = itemDC.THUE_END,
                                PhiBVMT_End = itemDC.PHI_END,
                                TongCong_End = itemDC.TONGCONG_END,
                                itemDC.TangGiam,
                                TongCong_BD = itemDC.TONGCONG_DC,
                                TongCong_Start = itemDC.TONGCONG_BD,
                                To = itemtableND.TT_To.TenTo,
                                HanhThu = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            else
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemDC.TangGiam == null && itemDC.CreateDate.Value.Date >= TuNgay.Date && itemDC.CreateDate.Value.Date <= DenNgay.Date
                            select new
                            {
                                NgayDC = itemDC.NGAY_DC,
                                MaDCHD = itemDC.ID_DIEUCHINH_HD,
                                itemHD.SOHOADON,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                GiaBan_End = itemDC.GIABAN_END,
                                ThueGTGT_End = itemDC.THUE_END,
                                PhiBVMT_End = itemDC.PHI_END,
                                TongCong_End = itemDC.TONGCONG_END,
                                itemDC.TangGiam,
                                TongCong_BD = itemDC.TONGCONG_DC,
                                TongCong_Start = itemDC.TONGCONG_BD,
                                To = itemtableND.TT_To.TenTo,
                                HanhThu = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
        }

        public DataTable GetDSByNgayDC(DateTime TuNgay, DateTime DenNgay)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.NGAY_DC.Value.Date >= TuNgay.Date && itemDC.NGAY_DC.Value.Date <= DenNgay.Date
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            GiaBan_End = itemDC.GIABAN_END,
                            ThueGTGT_End = itemDC.THUE_END,
                            PhiBVMT_End = itemDC.PHI_END,
                            TongCong_End = itemDC.TONGCONG_END,
                            itemDC.TangGiam,
                            TongCong_BD = itemDC.TONGCONG_DC,
                            TongCong_Start = itemDC.TONGCONG_BD,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDangNgan(DateTime TuNgay, DateTime DenNgay)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.ChuyenNoKhoDoi==false && itemHD.NGAYGIAITRACH.Value.Date >= TuNgay.Date && itemHD.NGAYGIAITRACH.Value.Date <= DenNgay.Date
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            GiaBan_End = itemDC.GIABAN_END,
                            ThueGTGT_End = itemDC.THUE_END,
                            PhiBVMT_End = itemDC.PHI_END,
                            TongCong_End = itemDC.TONGCONG_END,
                            itemDC.TangGiam,
                            TongCong_BD = itemDC.TONGCONG_DC,
                            TongCong_Start = itemDC.TONGCONG_BD,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSTon()
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.NGAYGIAITRACH==null
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            GiaBan_End = itemDC.GIABAN_END,
                            ThueGTGT_End = itemDC.THUE_END,
                            PhiBVMT_End = itemDC.PHI_END,
                            TongCong_End = itemDC.TONGCONG_END,
                            itemDC.TangGiam,
                            TongCong_BD = itemDC.TONGCONG_DC,
                            TongCong_Start = itemDC.TONGCONG_BD,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(bool DaDieuChinh)
        {
            if (DaDieuChinh)
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemDC.TangGiam != null
                            select new
                            {
                                NgayDC = itemDC.NGAY_DC,
                                MaDCHD = itemDC.ID_DIEUCHINH_HD,
                                itemHD.SOHOADON,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                GiaBan_End = itemDC.GIABAN_END,
                                ThueGTGT_End = itemDC.THUE_END,
                                PhiBVMT_End = itemDC.PHI_END,
                                TongCong_End = itemDC.TONGCONG_END,
                                itemDC.TangGiam,
                                TongCong_BD = itemDC.TONGCONG_DC,
                                TongCong_Start = itemDC.TONGCONG_BD,
                                To = itemtableND.TT_To.TenTo,
                                HanhThu = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            else
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemDC.TangGiam == null
                            select new
                            {
                                NgayDC = itemDC.NGAY_DC,
                                MaDCHD = itemDC.ID_DIEUCHINH_HD,
                                itemHD.SOHOADON,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                GiaBan_End = itemDC.GIABAN_END,
                                ThueGTGT_End = itemDC.THUE_END,
                                PhiBVMT_End = itemDC.PHI_END,
                                TongCong_End = itemDC.TONGCONG_END,
                                itemDC.TangGiam,
                                TongCong_BD = itemDC.TONGCONG_DC,
                                TongCong_Start = itemDC.TONGCONG_BD,
                                To = itemtableND.TT_To.TenTo,
                                HanhThu = itemtableND.HoTen,
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

        dbKTKS_DonKHDataContext _dbKTKS_DonKH = new dbKTKS_DonKHDataContext();

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

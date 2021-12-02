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
                if (_db.TT_LichSuDieuChinhHDs.Count() > 0)
                    lsdc.ID = _db.TT_LichSuDieuChinhHDs.Max(item => item.ID) + 1;
                else
                    lsdc.ID = 1;
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

        public void Refresh(DIEUCHINH_HD dchd)
        {
            _db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, dchd);
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
                throw ex;
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
                _db = new dbThuTienDataContext();
                throw ex;
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
                _db = new dbThuTienDataContext();
                throw ex;
            }
        }

        public bool CheckExistByDangRutDC(int MaHD)
        {
            return _db.DIEUCHINH_HDs.Any(item => item.FK_HOADON == MaHD && item.TangGiam == null);
        }

        public bool CheckExist(int MaHD)
        {
            return _db.DIEUCHINH_HDs.Any(item => item.FK_HOADON == MaHD);
        }

        public bool CheckExist_ChuanThu(int MaHD)
        {
            return _db.DIEUCHINH_HDs.Any(item => item.FK_HOADON == MaHD && item.ChuanThu1 == false);
        }

        public bool CheckExist_UpdatedHDDT(int MaHD)
        {
            //hóa đơn giấy
            if (_db.HOADONs.Any(item => item.ID_HOADON == MaHD && (item.NAM < 2020 || (item.NAM == 2020 && item.KY <= 6))) == true)
                return true;
            else//hóa đơn điện tử
                if (_db.DIEUCHINH_HDs.Any(item => item.FK_HOADON == MaHD) == false)
                    return true;
                else
                    return _db.DIEUCHINH_HDs.Any(item => item.FK_HOADON == MaHD && item.UpdatedHDDT == true);
        }

        public bool CheckExist_UpdatedHDDT(string SoHoaDon, ref string DanhBo)
        {
            //hóa đơn giấy
            if (_db.HOADONs.Any(item => item.SOHOADON == SoHoaDon && (item.NAM < 2020 || (item.NAM == 2020 && item.KY <= 6))) == true)
                return true;
            else//hóa đơn điện tử
                if (_db.DIEUCHINH_HDs.Any(item => item.FK_HOADON == _db.HOADONs.SingleOrDefault(itemHD => itemHD.SOHOADON == SoHoaDon).ID_HOADON) == false)
                    return true;
                else
                {
                    if (_db.DIEUCHINH_HDs.Any(item => item.FK_HOADON == _db.HOADONs.SingleOrDefault(itemHD => itemHD.SOHOADON == SoHoaDon).ID_HOADON && item.UpdatedHDDT == true) == false)
                    {
                        HOADON hd = _db.HOADONs.SingleOrDefault(itemHD => itemHD.SOHOADON == SoHoaDon);
                        if (hd != null)
                            DanhBo = hd.DANHBA + " " + hd.KY + "/" + hd.NAM;
                        return false;
                    }
                    else
                        return true;
                }
        }

        public bool CheckExist_ChuaUpdatedHDDT(string DanhBo)
        {
            string sql = "select COUNT(dchd.ID_DIEUCHINH_HD) from HOADON hd,DIEUCHINH_HD dchd"
                        + " where dchd.UpdatedHDDT=0 and hd.DANHBA='" + DanhBo + "' and hd.ID_HOADON=dchd.FK_HOADON"
                        + " and (hd.NAM>2020 or (hd.NAM=2020 and hd.KY>6))";
            if ((int)ExecuteQuery_ReturnOneValue(sql) == 0)
                return false;
            else
                return true;
        }

        public DIEUCHINH_HD Get(int MaHD)
        {
            DIEUCHINH_HD dchd = _db.DIEUCHINH_HDs.SingleOrDefault(item => item.FK_HOADON == MaHD);
            if (dchd != null)
            {
                if (dchd.GIABAN_DC == null)
                    dchd.GIABAN_DC = 0;
                if (dchd.THUE_DC == null)
                    dchd.THUE_DC = 0;
                if (dchd.PHI_DC == null)
                    dchd.PHI_DC = 0;
                if (dchd.TONGCONG_DC == null)
                    dchd.TONGCONG_DC = 0;

                if (dchd.GIABAN_END == null)
                    dchd.GIABAN_END = 0;
                if (dchd.THUE_END == null)
                    dchd.THUE_END = 0;
                if (dchd.PHI_END == null)
                    dchd.PHI_END = 0;
                if (dchd.TONGCONG_END == null)
                    dchd.TONGCONG_END = 0;
                return dchd;
            }
            else
                return null;
        }

        public DIEUCHINH_HD GetByMaDC(int MaDC)
        {
            DIEUCHINH_HD dchd = _db.DIEUCHINH_HDs.SingleOrDefault(item => item.ID_DIEUCHINH_HD == MaDC);
            if (dchd != null)
            {

                return dchd;
            }
            else
                return null;
        }

        public DIEUCHINH_HD get(string SoHoaDon)
        {
            DIEUCHINH_HD dchd = _db.DIEUCHINH_HDs.SingleOrDefault(item => item.SoHoaDon == SoHoaDon);
            if (dchd != null)
            {
                return dchd;
            }
            else
                return null;
        }

        public List<DIEUCHINH_HD> GetDS()
        {
            return _db.DIEUCHINH_HDs.ToList();
        }

        public DataTable GetTongChuanThu(int Nam, int Ky)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky
                        group itemDC by itemHD.KY into itemGroup
                        select new
                        {
                            Ky = Ky,
                            GIABAN_BD = itemGroup.Sum(groupItem => groupItem.GIABAN_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.GIABAN_BD),
                            ThueGTGT_BD = itemGroup.Sum(groupItem => groupItem.THUE_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.THUE_BD),
                            PhiBVMT_BD = itemGroup.Sum(groupItem => groupItem.PHI_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.PHI_BD),
                            TONGCONG_BD = itemGroup.Sum(groupItem => groupItem.TONGCONG_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TONGCONG_BD),
                            GIABAN_DC = itemGroup.Sum(groupItem => groupItem.GIABAN_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.GIABAN_DC),
                            ThueGTGT_DC = itemGroup.Sum(groupItem => groupItem.THUE_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.THUE_DC),
                            PhiBVMT_DC = itemGroup.Sum(groupItem => groupItem.PHI_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.PHI_DC),
                            TONGCONG_DC = itemGroup.Sum(groupItem => groupItem.TONGCONG_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TONGCONG_DC),
                            GIABAN_END = itemGroup.Sum(groupItem => groupItem.GIABAN_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.GIABAN_END),
                            ThueGTGT_End = itemGroup.Sum(groupItem => groupItem.THUE_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.THUE_END),
                            PhiBVMT_End = itemGroup.Sum(groupItem => groupItem.PHI_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.PHI_END),
                            TONGCONG_END = itemGroup.Sum(groupItem => groupItem.TONGCONG_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TONGCONG_END),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetTongChuanThu(int Nam, int Ky, int Dot)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot
                        group itemDC by itemHD.DOT into itemGroup
                        select new
                        {
                            GIABAN_BD = itemGroup.Sum(groupItem => groupItem.GIABAN_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.GIABAN_BD),
                            ThueGTGT_BD = itemGroup.Sum(groupItem => groupItem.THUE_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.THUE_BD),
                            PhiBVMT_BD = itemGroup.Sum(groupItem => groupItem.PHI_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.PHI_BD),
                            TONGCONG_BD = itemGroup.Sum(groupItem => groupItem.TONGCONG_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TONGCONG_BD),
                            GIABAN_DC = itemGroup.Sum(groupItem => groupItem.GIABAN_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.GIABAN_DC),
                            ThueGTGT_DC = itemGroup.Sum(groupItem => groupItem.THUE_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.THUE_DC),
                            PhiBVMT_DC = itemGroup.Sum(groupItem => groupItem.PHI_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.PHI_DC),
                            TONGCONG_DC = itemGroup.Sum(groupItem => groupItem.TONGCONG_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TONGCONG_DC),
                            GIABAN_END = itemGroup.Sum(groupItem => groupItem.GIABAN_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.GIABAN_END),
                            ThueGTGT_End = itemGroup.Sum(groupItem => groupItem.THUE_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.THUE_END),
                            PhiBVMT_End = itemGroup.Sum(groupItem => groupItem.PHI_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.PHI_END),
                            TONGCONG_END = itemGroup.Sum(groupItem => groupItem.TONGCONG_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TONGCONG_END),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetTongChuanThu(int MaTo, int Nam, int Ky, int Dot)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot
                        group itemDC by itemHD.KY into itemGroup
                        select new
                        {
                            MaTo = MaTo,
                            _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                            GIABAN_BD = itemGroup.Sum(groupItem => groupItem.GIABAN_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.GIABAN_BD),
                            TONGCONG_BD = itemGroup.Sum(groupItem => groupItem.TONGCONG_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TONGCONG_BD),
                            GIABAN_DC = itemGroup.Sum(groupItem => groupItem.GIABAN_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.GIABAN_DC),
                            TONGCONG_DC = itemGroup.Sum(groupItem => groupItem.TONGCONG_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TONGCONG_DC),
                            GIABAN_END = itemGroup.Sum(groupItem => groupItem.GIABAN_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.GIABAN_END),
                            TONGCONG_END = itemGroup.Sum(groupItem => groupItem.TONGCONG_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TONGCONG_END),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetTongChuanThuTon(int Nam, int Ky)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && (itemHD.KhoaTienDu == true || itemHD.NGAYGIAITRACH == null)
                        group itemDC by itemHD.KY into itemGroup
                        select new
                        {
                            Ky = Ky,
                            GIABAN_BD = itemGroup.Sum(groupItem => groupItem.GIABAN_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.GIABAN_BD),
                            TONGCONG_BD = itemGroup.Sum(groupItem => groupItem.TONGCONG_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TONGCONG_BD),
                            GIABAN_DC = itemGroup.Sum(groupItem => groupItem.GIABAN_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.GIABAN_DC),
                            TONGCONG_DC = itemGroup.Sum(groupItem => groupItem.TONGCONG_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TONGCONG_DC),
                            GIABAN_END = itemGroup.Sum(groupItem => groupItem.GIABAN_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.GIABAN_END),
                            TONGCONG_END = itemGroup.Sum(groupItem => groupItem.TONGCONG_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TONGCONG_END),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetChuanThu_Doi(string Loai, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.GB >= 10 && itemHD.GB <= 20
                            select new
                            {
                                Loai = "TG",
                                itemHD.NGAYGIAITRACH,
                                GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemDC in _db.DIEUCHINH_HDs
                                join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                                where itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.GB > 20
                                select new
                                {
                                    Loai = "CQ",
                                    itemHD.NGAYGIAITRACH,
                                    GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                    TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                    GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                    TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                    GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                    TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
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
                                    && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.GB >= 10 && itemHD.GB <= 20
                            select new
                            {
                                MaTo = MaTo,
                                _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                                MaNV = itemHD.MaNV_HanhThu,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                itemHD.NGAYGIAITRACH,
                                GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
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
                                        && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.GB > 20
                                select new
                                {
                                    MaTo = MaTo,
                                    _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                                    MaNV = itemHD.MaNV_HanhThu,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                    itemHD.NGAYGIAITRACH,
                                    GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                    TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                    GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                    TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                    GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                    TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetChuanThu(string Loai, int MaTo, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                //var query = from itemDC in _db.DIEUCHINH_HDs
                //            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                //            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                //                    && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                //                    && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.GB>=10 && itemHD.GB <= 20
                //            select new
                //            {
                //                Loai = "TG",
                //                MaTo = MaTo,
                //                _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                //                MaNV = itemHD.MaNV_HanhThu,
                //                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                //                itemHD.NGAYGIAITRACH,
                //                GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                //                TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                //                GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                //                TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                //            };
                //return LINQToDataTable(query);
                string sql = "select Loai='TG',MaTo=" + MaTo + ",TenTo=(select TenTo from TT_To where MaTo=" + MaTo + "),MaNV=hd.MaNV_HanhThu,HoTen=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_HanhThu)"
                        + " ,hd.NGAYGIAITRACH"
                        + " ,GIABAN_BD=case when dchd.GIABAN_BD is null then 0 else dchd.GIABAN_BD end"
                        + " ,TONGCONG_BD=case when dchd.TONGCONG_BD is null then 0 else dchd.TONGCONG_BD end"
                        + " ,GIABAN_DC=case when dchd.GIABAN_DC is null then 0 else dchd.GIABAN_DC end"
                        + " ,TONGCONG_DC=case when dchd.TONGCONG_DC is null then 0 else dchd.TONGCONG_DC end"
                        + " ,GIABAN_END=case when dchd.GIABAN_END is null then 0 else dchd.GIABAN_END end"
                        + " ,TONGCONG_END=case when dchd.TONGCONG_END is null then 0 else dchd.TONGCONG_END end"
                        + " from DIEUCHINH_HD dchd,HOADON hd where dchd.FK_HOADON=hd.ID_HOADON"
                        + " and hd.MAY>=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ") and hd.MAY<=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ") and dchd.ChuanThu1=0 and hd.NAM=" + Nam + " and hd.KY=" + Ky
                        + " and hd.GB>=10 and hd.GB <= 20";
                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    //var query = from itemDC in _db.DIEUCHINH_HDs
                    //            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                    //            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                    //                    && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                    //                    && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.GB > 20
                    //            select new
                    //            {
                    //                Loai = "CQ",
                    //                MaTo = MaTo,
                    //                _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                    //                MaNV = itemHD.MaNV_HanhThu,
                    //                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                    //                itemHD.NGAYGIAITRACH,
                    //                GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                    //                TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                    //                GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                    //                TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                    //            };
                    //return LINQToDataTable(query);
                    string sql = "select Loai='CQ',MaTo=" + MaTo + ",TenTo=(select TenTo from TT_To where MaTo=" + MaTo + "),MaNV=hd.MaNV_HanhThu,HoTen=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_HanhThu)"
                        + " ,hd.NGAYGIAITRACH"
                        + " ,GIABAN_BD=case when dchd.GIABAN_BD is null then 0 else dchd.GIABAN_BD end"
                        + " ,TONGCONG_BD=case when dchd.TONGCONG_BD is null then 0 else dchd.TONGCONG_BD end"
                        + " ,GIABAN_DC=case when dchd.GIABAN_DC is null then 0 else dchd.GIABAN_DC end"
                        + " ,TONGCONG_DC=case when dchd.TONGCONG_DC is null then 0 else dchd.TONGCONG_DC end"
                        + " ,GIABAN_END=case when dchd.GIABAN_END is null then 0 else dchd.GIABAN_END end"
                        + " ,TONGCONG_END=case when dchd.TONGCONG_END is null then 0 else dchd.TONGCONG_END end"
                        + " from DIEUCHINH_HD dchd,HOADON hd where dchd.FK_HOADON=hd.ID_HOADON"
                        + " and hd.MAY>=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ") and hd.MAY<=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ") and dchd.ChuanThu1=0 and hd.NAM=" + Nam + " and hd.KY=" + Ky
                        + " and hd.GB > 20";
                    return ExecuteQuery_DataTable(sql);
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
                                    && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot && itemHD.GB >= 10 && itemHD.GB <= 20
                            select new
                            {
                                MaTo = MaTo,
                                _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                                MaNV = itemHD.MaNV_HanhThu,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                itemHD.NGAYGIAITRACH,
                                GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
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
                                        && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot && itemHD.GB > 20
                                select new
                                {
                                    MaTo = MaTo,
                                    _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                                    MaNV = itemHD.MaNV_HanhThu,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                    itemHD.NGAYGIAITRACH,
                                    GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                    TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                    GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                    TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                    GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                    TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
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
                                   && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.GB >= 10 && itemHD.GB <= 20
                            select new
                            {
                                MaTo = MaTo,
                                _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                                MaNV = itemHD.MaNV_HanhThu,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                itemHD.NGAYGIAITRACH,
                                GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
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
                                       && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.GB > 20
                                select new
                                {
                                    MaTo = MaTo,
                                    _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                                    MaNV = itemHD.MaNV_HanhThu,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                    itemHD.NGAYGIAITRACH,
                                    GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                    TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                    GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                    TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                    GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                    TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetChuanThu(string SoHoaDon)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where itemDC.SoHoaDon == SoHoaDon && itemDC.ChuanThu1 == false
                        select new
                        {
                            GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                            THUEGTGT_BD = itemDC.THUE_BD,
                            PHIBVMT_BD = itemDC.PHI_BD,
                            TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                            GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                            TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                            GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                            THUEGTGT_END = itemDC.THUE_END,
                            PHIBVMT_END = itemDC.PHI_END,
                            TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetChuanThu_NV(string Loai, int MaNV_HanhThu, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where itemHD.MaNV_HanhThu == MaNV_HanhThu && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.GB >= 10 && itemHD.GB <= 20
                            select new
                            {
                                Loai = "TG",
                                MaNV = itemHD.MaNV_HanhThu,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                itemHD.NGAYGIAITRACH,
                                GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemDC in _db.DIEUCHINH_HDs
                                join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                                where itemHD.MaNV_HanhThu == MaNV_HanhThu && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.GB > 20
                                select new
                                {
                                    Loai = "CQ",
                                    MaNV = itemHD.MaNV_HanhThu,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                    itemHD.NGAYGIAITRACH,
                                    GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                    TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                    GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                    TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                    GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                    TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetChuanThuTon(int MaTo)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && itemDC.ChuanThu1 == false && (itemHD.KhoaTienDu == true || itemHD.NGAYGIAITRACH == null)
                        select new
                        {
                            MaTo = MaTo,
                            _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                            MaNV = itemHD.MaNV_HanhThu,
                            _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                            itemHD.NGAYGIAITRACH,
                            GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                            TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                            GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                            TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                            GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                            TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetChuanThuTon(int MaTo, int Nam)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && (itemHD.KhoaTienDu == true || itemHD.NGAYGIAITRACH == null)
                        select new
                        {
                            MaTo = MaTo,
                            _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                            MaNV = itemHD.MaNV_HanhThu,
                            _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                            itemHD.NGAYGIAITRACH,
                            GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                            TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                            GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                            TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                            GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                            TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetChuanThuTon(int MaTo, int Nam, int Ky)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && (itemHD.KhoaTienDu == true || itemHD.NGAYGIAITRACH == null)
                        select new
                        {
                            MaTo = MaTo,
                            _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                            MaNV = itemHD.MaNV_HanhThu,
                            _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                            itemHD.NGAYGIAITRACH,
                            GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                            TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                            GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                            TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                            GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                            TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetChuanThuTon(int MaTo, int Nam, int Ky, int Dot)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot
                                && (itemHD.KhoaTienDu == true || itemHD.NGAYGIAITRACH == null)
                        select new
                        {
                            MaTo = MaTo,
                            _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                            MaNV = itemHD.MaNV_HanhThu,
                            _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                            itemHD.NGAYGIAITRACH,
                            GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                            TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                            GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                            TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                            GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                            TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetChuanThuTon(int MaTo, int Nam, int Ky, int FromDot, int ToDot)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT >= FromDot && itemHD.DOT <= ToDot
                                && (itemHD.KhoaTienDu == true || itemHD.NGAYGIAITRACH == null)
                        select new
                        {
                            MaTo = MaTo,
                            _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                            MaNV = itemHD.MaNV_HanhThu,
                            _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                            itemHD.NGAYGIAITRACH,
                            GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                            TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                            GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                            TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                            GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                            TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetChuanThuTon(int MaTo, DateTime NgayGiaiTrach)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && itemDC.ChuanThu1 == false && (itemHD.KhoaTienDu == true || itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date)
                        select new
                        {
                            MaTo = MaTo,
                            _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                            MaNV = itemHD.MaNV_HanhThu,
                            _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                            itemHD.NGAYGIAITRACH,
                            GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                            TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                            GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                            TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                            GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                            TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetChuanThuTonDenKy(int MaTo, int Nam, int Ky)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                               && itemDC.ChuanThu1 == false && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky)) && (itemHD.KhoaTienDu == true || itemHD.NGAYGIAITRACH == null)
                        select new
                        {
                            MaTo = MaTo,
                            _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                            MaNV = itemHD.MaNV_HanhThu,
                            _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                            itemHD.NGAYGIAITRACH,
                            GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                            TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                            GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                            TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                            GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                            TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetChuanThuTonDenKy(int MaTo, int Nam, int Ky, int FromDot, int ToDot)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                               && itemDC.ChuanThu1 == false && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky)) && itemHD.DOT >= FromDot && itemHD.DOT <= ToDot
                               && (itemHD.KhoaTienDu == true || itemHD.NGAYGIAITRACH == null)
                        select new
                        {
                            MaTo = MaTo,
                            _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                            MaNV = itemHD.MaNV_HanhThu,
                            _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                            itemHD.NGAYGIAITRACH,
                            GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                            TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                            GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                            TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                            GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                            TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetChuanThuTonDenKyDenNgay(int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && itemDC.ChuanThu1 == false && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky))
                                && (itemHD.KhoaTienDu == true || itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date)
                        select new
                        {
                            MaTo = MaTo,
                            _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                            MaNV = itemHD.MaNV_HanhThu,
                            _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                            itemHD.NGAYGIAITRACH,
                            GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                            TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                            GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                            TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                            GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                            TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetChuanThuTonDenKyDenNgay(int MaTo, int Nam, int Ky, int FromDot, int ToDot, DateTime NgayGiaiTrach)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && itemDC.ChuanThu1 == false && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky)) && itemHD.DOT >= FromDot && itemHD.DOT <= ToDot
                                && (itemHD.KhoaTienDu == true || itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date)
                        select new
                        {
                            MaTo = MaTo,
                            _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                            MaNV = itemHD.MaNV_HanhThu,
                            _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                            itemHD.NGAYGIAITRACH,
                            GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                            TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                            GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                            TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                            GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                            TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetChuanThuTonDenKyDenNgay(string Loai, int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && itemDC.ChuanThu1 == false && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky))
                                    && (itemHD.KhoaTienDu == true || itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date)
                                    && itemHD.GB >= 10 && itemHD.GB <= 20
                            select new
                            {
                                Loai = "TG",
                                MaTo = MaTo,
                                _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                                MaNV = itemHD.MaNV_HanhThu,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                itemHD.NGAYGIAITRACH,
                                GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
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
                                        && itemDC.ChuanThu1 == false && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky))
                                        && (itemHD.KhoaTienDu == true || itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date)
                                        && itemHD.GB > 20
                                select new
                                {
                                    Loai = "CQ",
                                    MaTo = MaTo,
                                    _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                                    MaNV = itemHD.MaNV_HanhThu,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                    itemHD.NGAYGIAITRACH,
                                    GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                    TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                    GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                    TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                    GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                    TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetChuanThuTonTrongKyDenNgay(int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                               && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky
                               && (itemHD.KhoaTienDu == true || itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date)
                        select new
                        {
                            MaTo = MaTo,
                            _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                            MaNV = itemHD.MaNV_HanhThu,
                            _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                            itemHD.NGAYGIAITRACH,
                            GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                            TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                            GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                            TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                            GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                            TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetChuanThuTonTrongKyDenNgay(int MaTo, int Nam, int Ky, int FromDot, int ToDot, DateTime NgayGiaiTrach)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                               && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT >= FromDot && itemHD.DOT <= ToDot
                               && (itemHD.KhoaTienDu == true || itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date)
                        select new
                        {
                            MaTo = MaTo,
                            _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                            MaNV = itemHD.MaNV_HanhThu,
                            _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                            itemHD.NGAYGIAITRACH,
                            GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                            TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                            GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                            TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                            GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                            TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetChuanThuTonTrongKyDenNgay(string Loai, int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                   && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky
                                   && (itemHD.KhoaTienDu == true || itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date)
                                   && itemHD.GB >= 10 && itemHD.GB <= 20
                            select new
                            {
                                Loai = "TG",
                                MaTo = MaTo,
                                _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                                MaNV = itemHD.MaNV_HanhThu,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                itemHD.NGAYGIAITRACH,
                                GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
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
                                       && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky
                                       && (itemHD.KhoaTienDu == true || itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date)
                                       && itemHD.GB > 20
                                select new
                                {
                                    Loai = "CQ",
                                    MaTo = MaTo,
                                    _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
                                    MaNV = itemHD.MaNV_HanhThu,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                    itemHD.NGAYGIAITRACH,
                                    GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                    TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                    GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                    TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                    GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                    TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
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
                                   && itemDC.ChuanThu1 == false && itemHD.NGAYGIAITRACH == null && itemHD.GB >= 10 && itemHD.GB <= 20
                            select new
                            {
                                MaNV = itemHD.MaNV_HanhThu,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                itemHD.NGAYGIAITRACH,
                                GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemDC in _db.DIEUCHINH_HDs
                                join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                                where itemHD.MaNV_HanhThu == MaNV
                                        && itemDC.ChuanThu1 == false && itemHD.NGAYGIAITRACH == null && itemHD.GB > 20
                                select new
                                {
                                    MaNV = itemHD.MaNV_HanhThu,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                    itemHD.NGAYGIAITRACH,
                                    GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                    TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                    GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                    TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                    GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                    TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
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
                                   && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.NGAYGIAITRACH == null && itemHD.GB >= 10 && itemHD.GB <= 20
                            select new
                            {
                                MaNV = itemHD.MaNV_HanhThu,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                itemHD.NGAYGIAITRACH,
                                GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemDC in _db.DIEUCHINH_HDs
                                join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                                where itemHD.MaNV_HanhThu == MaNV
                                     && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.NGAYGIAITRACH == null && itemHD.GB > 20
                                select new
                                {
                                    MaNV = itemHD.MaNV_HanhThu,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                    itemHD.NGAYGIAITRACH,
                                    GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                    TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                    GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                    TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                    GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                    TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
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
                                   && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.NGAYGIAITRACH == null && itemHD.GB >= 10 && itemHD.GB <= 20
                            select new
                            {
                                MaNV = itemHD.MaNV_HanhThu,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                itemHD.NGAYGIAITRACH,
                                GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemDC in _db.DIEUCHINH_HDs
                                join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                                where itemHD.MaNV_HanhThu == MaNV
                                      && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.NGAYGIAITRACH == null && itemHD.GB > 20
                                select new
                                {
                                    MaNV = itemHD.MaNV_HanhThu,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                    itemHD.NGAYGIAITRACH,
                                    GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                    TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                    GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                    TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                    GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                    TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
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
                                   && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot && itemHD.NGAYGIAITRACH == null && itemHD.GB >= 10 && itemHD.GB <= 20
                            select new
                            {
                                MaNV = itemHD.MaNV_HanhThu,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                itemHD.NGAYGIAITRACH,
                                GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemDC in _db.DIEUCHINH_HDs
                                join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                                where itemHD.MaNV_HanhThu == MaNV
                                      && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot && itemHD.NGAYGIAITRACH == null && itemHD.GB > 20
                                select new
                                {
                                    MaNV = itemHD.MaNV_HanhThu,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                    itemHD.NGAYGIAITRACH,
                                    GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                    TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                    GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                    TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                    GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                    TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
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
                                    && itemDC.ChuanThu1 == false && (itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date) && itemHD.GB >= 10 && itemHD.GB <= 20
                            select new
                            {
                                MaNV = itemHD.MaNV_HanhThu,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                itemHD.NGAYGIAITRACH,
                                GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemDC in _db.DIEUCHINH_HDs
                                join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                                where itemHD.MaNV_HanhThu == MaNV
                                        && itemDC.ChuanThu1 == false && (itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date) && itemHD.GB > 20
                                select new
                                {
                                    MaNV = itemHD.MaNV_HanhThu,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                    itemHD.NGAYGIAITRACH,
                                    GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                    TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                    GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                    TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                    GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                    TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
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
                                    && itemDC.ChuanThu1 == false && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky)) && itemHD.NGAYGIAITRACH == null && itemHD.GB >= 10 && itemHD.GB <= 20
                            select new
                            {
                                MaNV = itemHD.MaNV_HanhThu,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                itemHD.NGAYGIAITRACH,
                                GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemDC in _db.DIEUCHINH_HDs
                                join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                                where itemHD.MaNV_HanhThu == MaNV
                                        && itemDC.ChuanThu1 == false && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky)) && itemHD.NGAYGIAITRACH == null && itemHD.GB > 20
                                select new
                                {
                                    MaNV = itemHD.MaNV_HanhThu,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                    itemHD.NGAYGIAITRACH,
                                    GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                    TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                    GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                    TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                    GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                    TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetChuanThuTonDenKyDenNgay_NV(string Loai, int MaNV, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemDC in _db.DIEUCHINH_HDs
                            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                            where itemHD.MaNV_HanhThu == MaNV
                                     && itemDC.ChuanThu1 == false && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky))
                                     && (itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date || itemHD.KhoaTienDu == true)
                                     && itemHD.GB >= 10 && itemHD.GB <= 20
                            select new
                            {
                                Loai = "TG",
                                MaNV = itemHD.MaNV_HanhThu,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                itemHD.NGAYGIAITRACH,
                                GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemDC in _db.DIEUCHINH_HDs
                                join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                                where itemHD.MaNV_HanhThu == MaNV
                                        && itemDC.ChuanThu1 == false && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky))
                                        && (itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date || itemHD.KhoaTienDu == true)
                                        && itemHD.GB > 20
                                select new
                                {
                                    Loai = "CQ",
                                    MaNV = itemHD.MaNV_HanhThu,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                    itemHD.NGAYGIAITRACH,
                                    GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                    TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                    GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                    TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                    GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                    TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
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
                                    && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky
                                    && (itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date || itemHD.KhoaTienDu == true)
                                    && itemHD.GB >= 10 && itemHD.GB <= 20
                            select new
                            {
                                Loai = "TG",
                                MaNV = itemHD.MaNV_HanhThu,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                itemHD.NGAYGIAITRACH,
                                GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemDC in _db.DIEUCHINH_HDs
                                join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                                where itemHD.MaNV_HanhThu == MaNV
                                       && itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky
                                       && (itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayGiaiTrach.Date || itemHD.KhoaTienDu == true)
                                       && itemHD.GB > 20
                                select new
                                {
                                    Loai = "CQ",
                                    MaNV = itemHD.MaNV_HanhThu,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemHD.MaNV_HanhThu).HoTen,
                                    itemHD.NGAYGIAITRACH,
                                    GIABAN_BD = itemDC.GIABAN_BD == null ? 0 : itemDC.GIABAN_BD,
                                    TONGCONG_BD = itemDC.TONGCONG_BD == null ? 0 : itemDC.TONGCONG_BD,
                                    GIABAN_DC = itemDC.GIABAN_DC == null ? 0 : itemDC.GIABAN_DC,
                                    TONGCONG_DC = itemDC.TONGCONG_DC == null ? 0 : itemDC.TONGCONG_DC,
                                    GIABAN_END = itemDC.GIABAN_END == null ? 0 : itemDC.GIABAN_END,
                                    TONGCONG_END = itemDC.TONGCONG_END == null ? 0 : itemDC.TONGCONG_END,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetChuanThu_DongNuoc_BaoCaoTongHop(DateTime FromDate, DateTime ToDate)
        {
            string sql = "declare @FromDate date;"
                        + " declare @ToDate date;"
                        + " set @FromDate='" + FromDate.ToString("yyyyMMdd") + "';"
                        + " set @ToDate='" + ToDate.ToString("yyyyMMdd") + "';"
                        + " select nd.MaND as MaNV,nd.HoTen,nd.STT,toncu.TCTonCu_BD,toncu.TCTonCu_END,nhan.TCNhan_BD,nhan.TCNhan_END"
                        + ",dangngan.TCDangNgan_BD,dangngan.TCDangNgan_END,lenhhuy.TCHuy_BD,lenhhuy.TCHuy_END,tongton.TCTongTon_BD,tongton.TCTongTon_END from"
                        + " (select MaND,HoTen,STT from TT_NguoiDung where DongNuoc=1) nd"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,SUM(dchd.TONGCONG_BD) as TCTonCu_BD,SUM(dchd.TONGCONG_END) as TCTonCu_END"
                        + " from DIEUCHINH_HD dchd,TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dchd.SoHoaDon=hd.SOHOADON and dn.MaDN=ctdn.MaDN and ctdn.SoHoaDon=hd.SOHOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0 and dchd.ChuanThu1=0"
                        + " and CAST(dn.CreateDate as date)<@FromDate and (hd.NGAYGIAITRACH is null or (CAST(hd.NGAYGIAITRACH as date)>@FromDate))"
                        + " group by nd.MaND,nd.HoTen,nd.STT) toncu on nd.MaND=toncu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,SUM(dchd.TONGCONG_BD) as TCNhan_BD,SUM(dchd.TONGCONG_END) as TCNhan_END"
                        + " from DIEUCHINH_HD dchd,TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dchd.SoHoaDon=hd.SOHOADON and dn.MaDN=ctdn.MaDN and ctdn.SoHoaDon=hd.SOHOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0 and dchd.ChuanThu1=0"
                        + " and CAST(dn.CreateDate as date)>=@FromDate and CAST(dn.CreateDate as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) nhan on nd.MaND=nhan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,SUM(dchd.TONGCONG_BD) as TCDangNgan_BD,SUM(dchd.TONGCONG_END) as TCDangNgan_END"
                        + " from DIEUCHINH_HD dchd,TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dchd.SoHoaDon=hd.SOHOADON and dn.MaDN=ctdn.MaDN and ctdn.SoHoaDon=hd.SOHOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0 and dchd.ChuanThu1=0"
                        + " and CAST(NGAYGIAITRACH as date)>=@FromDate and CAST(NGAYGIAITRACH as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) dangngan on nd.MaND=dangngan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,SUM(dchd.TONGCONG_BD) as TCHuy_BD,SUM(dchd.TONGCONG_END) as TCHuy_END"
                        + " from DIEUCHINH_HD dchd,TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_LenhHuy lenhhuy,TT_NguoiDung nd"
                        + " where dchd.SoHoaDon=hd.SOHOADON and dn.MaDN=ctdn.MaDN and ctdn.SoHoaDon=hd.SOHOADON and lenhhuy.SoHoaDon=hd.SOHOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0 and dchd.ChuanThu1=0"
                        + " and CAST(lenhhuy.CreateDate as date)>=@FromDate and CAST(lenhhuy.CreateDate as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) lenhhuy on nd.MaND=lenhhuy.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,SUM(dchd.TONGCONG_BD) as TCTongTon_BD,SUM(dchd.TONGCONG_END) as TCTongTon_END"
                        + " from DIEUCHINH_HD dchd,TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dchd.SoHoaDon=hd.SOHOADON and dn.MaDN=ctdn.MaDN and ctdn.SoHoaDon=hd.SOHOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0 and dchd.ChuanThu1=0"
                        + " and CAST(dn.NgayGiao as date)<=@ToDate and (hd.NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@ToDate) and ctdn.SoHoaDon not in (select SoHoaDon from TT_LenhHuy)"
                        + " group by nd.MaND,nd.HoTen,nd.STT) tongton on nd.MaND=tongton.MaND"
                        + " order by nd.STT asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetChuanThu_DongNuoc_BaoCaoTongHop(int MaTo, DateTime FromDate, DateTime ToDate)
        {
            string sql = "declare @FromDate date;"
                        + " declare @ToDate date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @FromDate='" + FromDate.ToString("yyyyMMdd") + "';"
                        + " set @ToDate='" + ToDate.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select nd.MaND as MaNV,nd.HoTen,nd.STT,toncu.TCTonCu_BD,toncu.TCTonCu_END,nhan.TCNhan_BD,nhan.TCNhan_END"
                        + ",dangngan.TCDangNgan_BD,dangngan.TCDangNgan_END,lenhhuy.TCHuy_BD,lenhhuy.TCHuy_END,tongton.TCTongTon_BD,tongton.TCTongTon_END from"
                        + " (select MaND,HoTen,STT from TT_NguoiDung where DongNuoc=1 and MaTo=" + MaTo + ") nd"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,SUM(dchd.TONGCONG_BD) as TCTonCu_BD,SUM(dchd.TONGCONG_END) as TCTonCu_END"
                        + " from DIEUCHINH_HD dchd,TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dchd.SoHoaDon=hd.SOHOADON and dn.MaDN=ctdn.MaDN and ctdn.SoHoaDon=hd.SOHOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0 and dchd.ChuanThu1=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and CAST(dn.CreateDate as date)<@FromDate and (hd.NGAYGIAITRACH is null or (CAST(hd.NGAYGIAITRACH as date)>@FromDate))"
                        + " group by nd.MaND,nd.HoTen,nd.STT) toncu on nd.MaND=toncu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,SUM(dchd.TONGCONG_BD) as TCNhan_BD,SUM(dchd.TONGCONG_END) as TCNhan_END"
                        + " from DIEUCHINH_HD dchd,TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dchd.SoHoaDon=hd.SOHOADON and dn.MaDN=ctdn.MaDN and ctdn.SoHoaDon=hd.SOHOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0 and dchd.ChuanThu1=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and CAST(dn.CreateDate as date)>=@FromDate and CAST(dn.CreateDate as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) nhan on nd.MaND=nhan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,SUM(dchd.TONGCONG_BD) as TCDangNgan_BD,SUM(dchd.TONGCONG_END) as TCDangNgan_END"
                        + " from DIEUCHINH_HD dchd,TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dchd.SoHoaDon=hd.SOHOADON and dn.MaDN=ctdn.MaDN and ctdn.SoHoaDon=hd.SOHOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0 and dchd.ChuanThu1=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and CAST(NGAYGIAITRACH as date)>=@FromDate and CAST(NGAYGIAITRACH as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) dangngan on nd.MaND=dangngan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,SUM(dchd.TONGCONG_BD) as TCHuy_BD,SUM(dchd.TONGCONG_END) as TCHuy_END"
                        + " from DIEUCHINH_HD dchd,TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_LenhHuy lenhhuy,TT_NguoiDung nd"
                        + " where dchd.SoHoaDon=hd.SOHOADON and dn.MaDN=ctdn.MaDN and ctdn.SoHoaDon=hd.SOHOADON and lenhhuy.SoHoaDon=hd.SOHOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0 and dchd.ChuanThu1=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and CAST(lenhhuy.CreateDate as date)>=@FromDate and CAST(lenhhuy.CreateDate as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) lenhhuy on nd.MaND=lenhhuy.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,SUM(dchd.TONGCONG_BD) as TCTongTon_BD,SUM(dchd.TONGCONG_END) as TCTongTon_END"
                        + " from DIEUCHINH_HD dchd,TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dchd.SoHoaDon=hd.SOHOADON and dn.MaDN=ctdn.MaDN and ctdn.SoHoaDon=hd.SOHOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0 and dchd.ChuanThu1=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and CAST(dn.NgayGiao as date)<=@ToDate and (hd.NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@ToDate) and ctdn.SoHoaDon not in (select SoHoaDon from TT_LenhHuy)"
                        + " group by nd.MaND,nd.HoTen,nd.STT) tongton on nd.MaND=tongton.MaND"
                        + " order by nd.STT asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_Giay_TV_ChuaCapNhat()
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.TONGCONG_END == null && (itemHD.NAM < 2020 || (itemHD.NAM == 2020 && itemHD.KY < 7))
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            MaHD = itemDC.FK_HOADON,
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
                            TieuThu_BD = itemDC.TIEUTHU_DC - itemDC.TIEUTHU_BD,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                            itemDC.ChuanThu1,
                            itemHD.NGAYGIAITRACH,
                            itemDC.UpdatedHDDT,
                            itemHD.DOT,
                            Ky2 = itemHD.KY,
                            itemHD.NAM,
                            itemHD.SOPHATHANH,
                            GiaBieuCu = itemDC.GiaBieu,
                            DinhMucCu = itemDC.DinhMuc,
                            TieuThuCu = itemDC.TIEUTHU_BD,
                            GiaBieuMoi = itemDC.GB_DC,
                            DinhMucMoi = itemDC.DM_DC,
                            TieuThuMoi = itemDC.TIEUTHU_DC,
                            GiaBan_Start = itemDC.GIABAN_BD,
                            ThueGTGT_Start = itemDC.THUE_BD,
                            PhiBVMT_Start = itemDC.PHI_BD,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_Giay_Tong_ChuaCapNhat()
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.TONGCONG_END != null && itemDC.UpdatedHDDT == false && (itemHD.NAM < 2020 || (itemHD.NAM == 2020 && itemHD.KY < 7))
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            MaHD = itemDC.FK_HOADON,
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
                            TieuThu_BD = itemDC.TIEUTHU_DC - itemDC.TIEUTHU_BD,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                            itemDC.ChuanThu1,
                            itemHD.NGAYGIAITRACH,
                            itemDC.UpdatedHDDT,
                            itemHD.DOT,
                            Ky2 = itemHD.KY,
                            itemHD.NAM,
                            itemHD.SOPHATHANH,
                            GiaBieuCu = itemDC.GiaBieu,
                            DinhMucCu = itemDC.DinhMuc,
                            TieuThuCu = itemDC.TIEUTHU_BD,
                            GiaBieuMoi = itemDC.GB_DC,
                            DinhMucMoi = itemDC.DM_DC,
                            TieuThuMoi = itemDC.TIEUTHU_DC,
                            GiaBan_Start = itemDC.GIABAN_BD,
                            ThueGTGT_Start = itemDC.THUE_BD,
                            PhiBVMT_Start = itemDC.PHI_BD,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_Giay_TV_Tong_ChuaCapNhat()
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.TONGCONG_END == null && itemDC.UpdatedHDDT == false && (itemHD.NAM < 2020 || (itemHD.NAM == 2020 && itemHD.KY < 7))
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            MaHD = itemDC.FK_HOADON,
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
                            TieuThu_BD = itemDC.TIEUTHU_DC - itemDC.TIEUTHU_BD,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                            itemDC.ChuanThu1,
                            itemHD.NGAYGIAITRACH,
                            itemDC.UpdatedHDDT,
                            itemHD.DOT,
                            Ky2 = itemHD.KY,
                            itemHD.NAM,
                            itemHD.SOPHATHANH,
                            GiaBieuCu = itemDC.GiaBieu,
                            DinhMucCu = itemDC.DinhMuc,
                            TieuThuCu = itemDC.TIEUTHU_BD,
                            GiaBieuMoi = itemDC.GB_DC,
                            DinhMucMoi = itemDC.DM_DC,
                            TieuThuMoi = itemDC.TIEUTHU_DC,
                            GiaBan_Start = itemDC.GIABAN_BD,
                            ThueGTGT_Start = itemDC.THUE_BD,
                            PhiBVMT_Start = itemDC.PHI_BD,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_HDDT_TV_ChuaCapNhat()
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.TONGCONG_END == null && (itemHD.NAM > 2020 || (itemHD.NAM == 2020 && itemHD.KY >= 7))
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            MaHD = itemDC.FK_HOADON,
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
                            TieuThu_BD = itemDC.TIEUTHU_DC - itemDC.TIEUTHU_BD,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                            itemDC.ChuanThu1,
                            itemHD.NGAYGIAITRACH,
                            itemDC.UpdatedHDDT,
                            itemHD.DOT,
                            Ky2 = itemHD.KY,
                            itemHD.NAM,
                            itemHD.SOPHATHANH,
                            GiaBieuCu = itemDC.GiaBieu,
                            DinhMucCu = itemDC.DinhMuc,
                            TieuThuCu = itemDC.TIEUTHU_BD,
                            GiaBieuMoi = itemDC.GB_DC,
                            DinhMucMoi = itemDC.DM_DC,
                            TieuThuMoi = itemDC.TIEUTHU_DC,
                            GiaBan_Start = itemDC.GIABAN_BD,
                            ThueGTGT_Start = itemDC.THUE_BD,
                            PhiBVMT_Start = itemDC.PHI_BD,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_HDDT_Tong_ChuaCapNhat()
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.TONGCONG_END != null && itemDC.UpdatedHDDT == false && (itemHD.NAM > 2020 || (itemHD.NAM == 2020 && itemHD.KY >= 7))
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            MaHD = itemDC.FK_HOADON,
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
                            TieuThu_BD = itemDC.TIEUTHU_DC - itemDC.TIEUTHU_BD,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                            itemDC.ChuanThu1,
                            itemHD.NGAYGIAITRACH,
                            itemDC.UpdatedHDDT,
                            itemHD.DOT,
                            Ky2 = itemHD.KY,
                            itemHD.NAM,
                            itemHD.SOPHATHANH,
                            GiaBieuCu = itemDC.GiaBieu,
                            DinhMucCu = itemDC.DinhMuc,
                            TieuThuCu = itemDC.TIEUTHU_BD,
                            GiaBieuMoi = itemDC.GB_DC,
                            DinhMucMoi = itemDC.DM_DC,
                            TieuThuMoi = itemDC.TIEUTHU_DC,
                            GiaBan_Start = itemDC.GIABAN_BD,
                            ThueGTGT_Start = itemDC.THUE_BD,
                            PhiBVMT_Start = itemDC.PHI_BD,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_HDDT_TV_Tong_ChuaCapNhat()
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.TONGCONG_END == null && itemDC.UpdatedHDDT == false && (itemHD.NAM > 2020 || (itemHD.NAM == 2020 && itemHD.KY >= 7))
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            MaHD = itemDC.FK_HOADON,
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
                            TieuThu_BD = itemDC.TIEUTHU_DC - itemDC.TIEUTHU_BD,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                            itemDC.ChuanThu1,
                            itemHD.NGAYGIAITRACH,
                            itemDC.UpdatedHDDT,
                            itemHD.DOT,
                            Ky2 = itemHD.KY,
                            itemHD.NAM,
                            itemHD.SOPHATHANH,
                            GiaBieuCu = itemDC.GiaBieu,
                            DinhMucCu = itemDC.DinhMuc,
                            TieuThuCu = itemDC.TIEUTHU_BD,
                            GiaBieuMoi = itemDC.GB_DC,
                            DinhMucMoi = itemDC.DM_DC,
                            TieuThuMoi = itemDC.TIEUTHU_DC,
                            GiaBan_Start = itemDC.GIABAN_BD,
                            ThueGTGT_Start = itemDC.THUE_BD,
                            PhiBVMT_Start = itemDC.PHI_BD,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_HD0_Ton()
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.TONGCONG_END == 0 && itemHD.NGAYGIAITRACH == null && itemDC.UpdatedHDDT == true
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            MaHD = itemDC.FK_HOADON,
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
                            TieuThu_BD = itemDC.TIEUTHU_DC - itemDC.TIEUTHU_BD,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                            itemDC.ChuanThu1,
                            itemHD.NGAYGIAITRACH,
                            itemDC.UpdatedHDDT,
                            itemHD.DOT,
                            Ky2 = itemHD.KY,
                            itemHD.NAM,
                            itemHD.SOPHATHANH,
                            GiaBieuCu = itemDC.GiaBieu,
                            DinhMucCu = itemDC.DinhMuc,
                            TieuThuCu = itemDC.TIEUTHU_BD,
                            GiaBieuMoi = itemDC.GB_DC,
                            DinhMucMoi = itemDC.DM_DC,
                            TieuThuMoi = itemDC.TIEUTHU_DC,
                            GiaBan_Start = itemDC.GIABAN_BD,
                            ThueGTGT_Start = itemDC.THUE_BD,
                            PhiBVMT_Start = itemDC.PHI_BD,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_DanhBo(string DanhBo)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.DANHBA == DanhBo
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            MaHD = itemDC.FK_HOADON,
                            itemDC.SoHoaDon,
                            itemDC.SoHoaDonMoi,
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
                            TieuThu_BD = itemDC.TIEUTHU_DC - itemDC.TIEUTHU_BD,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                            itemDC.ChuanThu1,
                            itemHD.NGAYGIAITRACH,
                            itemDC.UpdatedHDDT,
                        };
            return LINQToDataTable(query);
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
                            MaHD = itemDC.FK_HOADON,
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
                            TieuThu_BD = itemDC.TIEUTHU_DC - itemDC.TIEUTHU_BD,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                            itemDC.ChuanThu1,
                            itemHD.NGAYGIAITRACH,
                            itemDC.UpdatedHDDT,
                            itemHD.DOT,
                            Ky2 = itemHD.KY,
                            itemHD.NAM,
                            itemHD.SOPHATHANH,
                            GiaBieuCu = itemDC.GiaBieu,
                            DinhMucCu = itemDC.DinhMuc,
                            TieuThuCu = itemDC.TIEUTHU_BD,
                            GiaBieuMoi = itemDC.GB_DC,
                            DinhMucMoi = itemDC.DM_DC,
                            TieuThuMoi = itemDC.TIEUTHU_DC,
                            GiaBan_Start = itemDC.GIABAN_BD,
                            ThueGTGT_Start = itemDC.THUE_BD,
                            PhiBVMT_Start = itemDC.PHI_BD,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSByNgayDC(DateTime TuNgay, DateTime DenNgay, int Nam, int Ky)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.NGAY_DC.Value.Date >= TuNgay.Date && itemDC.NGAY_DC.Value.Date <= DenNgay.Date && itemHD.NAM == Nam && itemHD.KY == Ky
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            MaHD = itemDC.FK_HOADON,
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
                            TieuThu_BD = itemDC.TIEUTHU_DC - itemDC.TIEUTHU_BD,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                            itemDC.ChuanThu1,
                            itemHD.NGAYGIAITRACH,
                            itemDC.UpdatedHDDT,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDangNgan(DateTime TuNgay, DateTime DenNgay)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.ChuyenNoKhoDoi == false && itemHD.NGAYGIAITRACH.Value.Date >= TuNgay.Date && itemHD.NGAYGIAITRACH.Value.Date <= DenNgay.Date
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
                            TieuThu_BD = itemDC.TIEUTHU_DC - itemDC.TIEUTHU_BD,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDangNgan(DateTime TuNgay, DateTime DenNgay, int Nam, int Ky)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.ChuyenNoKhoDoi == false && itemHD.NGAYGIAITRACH.Value.Date >= TuNgay.Date && itemHD.NGAYGIAITRACH.Value.Date <= DenNgay.Date && itemHD.NAM == Nam && itemHD.KY == Ky
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
                            TieuThu_BD = itemDC.TIEUTHU_DC - itemDC.TIEUTHU_BD,
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
                        where itemHD.NGAYGIAITRACH == null
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
                            TieuThu_BD = itemDC.TIEUTHU_DC - itemDC.TIEUTHU_BD,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSTon(int Nam, int Ky)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.NGAYGIAITRACH == null && itemHD.NAM == Nam && itemHD.KY == Ky
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
                            TieuThu_BD = itemDC.TIEUTHU_DC - itemDC.TIEUTHU_BD,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        //get lịch sử

        public DataTable getLichSu(int MaHD)
        {
            string sql = "WITH temp AS ("
+ "   select *"
+ "   ,ROW_NUMBER() OVER (PARTITION BY SoPhieu ORDER BY CreateDate DESC) AS rn"
+ " from TT_LichSuDieuChinhHD"
+ " where FK_HOADON=" + MaHD + " and SoPhieu is not null"
+ " )"
+ " SELECT * FROM temp WHERE rn=1";
            return ExecuteQuery_DataTable(sql);
        }

        //hóa đơn chờ điều chỉnh

        public bool Them_HDChoDC(TT_HoaDonChoDieuChinh en)
        {
            try
            {
                en.CreateDate = DateTime.Now;
                en.CreateBy = CNguoiDung.MaND;
                _db.TT_HoaDonChoDieuChinhs.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                throw ex;
            }
        }

        public bool Xoa_HDChoDC(TT_HoaDonChoDieuChinh en)
        {
            try
            {
                _db.TT_HoaDonChoDieuChinhs.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                throw ex;
            }
        }

        public bool checkExist_HDChoDC(string DanhBo, int Nam, int Ky)
        {
            return _db.TT_HoaDonChoDieuChinhs.Any(item => item.DanhBo == DanhBo && item.Nam == Nam && item.Ky == Ky);
        }

        public TT_HoaDonChoDieuChinh get_HDChoDC(string DanhBo, int Nam, int Ky)
        {
            return _db.TT_HoaDonChoDieuChinhs.SingleOrDefault(item => item.DanhBo == DanhBo && item.Nam == Nam && item.Ky == Ky);
        }

        public DataTable getDS_HDChoDC()
        {
            return LINQToDataTable(_db.TT_HoaDonChoDieuChinhs.ToList());
        }

    }
}

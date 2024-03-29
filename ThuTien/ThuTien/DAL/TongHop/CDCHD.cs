﻿using System;
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
                Refresh();
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
                Refresh();
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
                Refresh();
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
                Refresh();
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

        public bool CheckExist_UpdatedHDDT(int MaHD, ref string DanhBo)
        {
            if (_db.TT_DeviceConfigs.Any(item => item.checkUpdatedHDDT == true) == true)
            {
                //hóa đơn giấy
                if (_db.HOADONs.Any(item => item.ID_HOADON == MaHD && (item.NAM < 2020 || (item.NAM == 2020 && item.KY <= 6))) == true)
                    return true;
                else//hóa đơn điện tử
                    if (_db.DIEUCHINH_HDs.Any(item => item.FK_HOADON == MaHD) == false)
                        return true;
                    else
                    {
                        if (_db.DIEUCHINH_HDs.Any(item => item.FK_HOADON == MaHD && item.UpdatedHDDT == true) == false)
                        {
                            HOADON hd = _db.HOADONs.SingleOrDefault(itemHD => itemHD.ID_HOADON == MaHD);
                            if (hd != null)
                                DanhBo = hd.DANHBA + " " + hd.KY + "/" + hd.NAM;
                            return false;
                        }
                        else
                            return true;
                    }
            }
            else
                return true;
        }

        public bool CheckExist_UpdatedHDDT(string SoHoaDon, ref string DanhBo)
        {
            if (_db.TT_DeviceConfigs.Any(item => item.checkUpdatedHDDT == true) == true)
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
            else
                return true;
        }

        public bool CheckExist_ChuaUpdatedHDDT1(string DanhBo)
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
            DIEUCHINH_HD dchd = _db.DIEUCHINH_HDs.SingleOrDefault(item => item.FK_HOADON == _db.HOADONs.SingleOrDefault(hd => hd.SOHOADON == SoHoaDon).ID_HOADON);
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
                            TieuThu_BD = itemGroup.Sum(groupItem => groupItem.TIEUTHU_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TIEUTHU_BD),
                            TieuThu_DC = itemGroup.Sum(groupItem => groupItem.TIEUTHU_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TIEUTHU_DC),
                            GIABAN_BD = itemGroup.Sum(groupItem => groupItem.GIABAN_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.GIABAN_BD),
                            ThueGTGT_BD = itemGroup.Sum(groupItem => groupItem.THUE_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.THUE_BD),
                            PhiBVMT_BD = itemGroup.Sum(groupItem => groupItem.PHI_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.PHI_BD),
                            PhiBVMT_Thue_BD = itemGroup.Sum(groupItem => groupItem.PHI_Thue_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.PHI_Thue_BD),
                            TONGCONG_BD = itemGroup.Sum(groupItem => groupItem.TONGCONG_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TONGCONG_BD),
                            GIABAN_DC = itemGroup.Sum(groupItem => groupItem.GIABAN_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.GIABAN_DC),
                            ThueGTGT_DC = itemGroup.Sum(groupItem => groupItem.THUE_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.THUE_DC),
                            PhiBVMT_DC = itemGroup.Sum(groupItem => groupItem.PHI_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.PHI_DC),
                            PhiBVMT_Thue_DC = itemGroup.Sum(groupItem => groupItem.PHI_Thue_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.PHI_Thue_DC),
                            TONGCONG_DC = itemGroup.Sum(groupItem => groupItem.TONGCONG_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TONGCONG_DC),
                            GIABAN_END = itemGroup.Sum(groupItem => groupItem.GIABAN_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.GIABAN_END),
                            ThueGTGT_End = itemGroup.Sum(groupItem => groupItem.THUE_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.THUE_END),
                            PhiBVMT_End = itemGroup.Sum(groupItem => groupItem.PHI_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.PHI_END),
                            PhiBVMT_Thue_End = itemGroup.Sum(groupItem => groupItem.PHI_Thue_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.PHI_Thue_END),
                            TONGCONG_END = itemGroup.Sum(groupItem => groupItem.TONGCONG_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TONGCONG_END),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetTongChuanThu(int Nam, int Ky, int TuDot, int DenDot)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT >= TuDot && itemHD.DOT <= DenDot
                        group itemDC by itemHD.KY into itemGroup
                        select new
                        {
                            GIABAN_BD = itemGroup.Sum(groupItem => groupItem.GIABAN_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.GIABAN_BD),
                            ThueGTGT_BD = itemGroup.Sum(groupItem => groupItem.THUE_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.THUE_BD),
                            PhiBVMT_BD = itemGroup.Sum(groupItem => groupItem.PHI_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.PHI_BD),
                            PhiBVMT_Thue_BD = itemGroup.Sum(groupItem => groupItem.PHI_Thue_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.PHI_Thue_BD),
                            TONGCONG_BD = itemGroup.Sum(groupItem => groupItem.TONGCONG_BD) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TONGCONG_BD),
                            GIABAN_DC = itemGroup.Sum(groupItem => groupItem.GIABAN_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.GIABAN_DC),
                            ThueGTGT_DC = itemGroup.Sum(groupItem => groupItem.THUE_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.THUE_DC),
                            PhiBVMT_DC = itemGroup.Sum(groupItem => groupItem.PHI_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.PHI_DC),
                            PhiBVMT_Thue_DC = itemGroup.Sum(groupItem => groupItem.PHI_Thue_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.PHI_Thue_DC),
                            TONGCONG_DC = itemGroup.Sum(groupItem => groupItem.TONGCONG_DC) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TONGCONG_DC),
                            GIABAN_END = itemGroup.Sum(groupItem => groupItem.GIABAN_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.GIABAN_END),
                            ThueGTGT_End = itemGroup.Sum(groupItem => groupItem.THUE_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.THUE_END),
                            PhiBVMT_End = itemGroup.Sum(groupItem => groupItem.PHI_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.PHI_END),
                            PhiBVMT_Thue_End = itemGroup.Sum(groupItem => groupItem.PHI_Thue_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.PHI_Thue_END),
                            TONGCONG_END = itemGroup.Sum(groupItem => groupItem.TONGCONG_END) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TONGCONG_END),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetTongChuanThu_To(int MaTo, int Nam, int Ky, int Dot)
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

        public DataTable GetTongChuanThuTon(int Nam, int Ky, int TuDot, int DenDot)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        where itemDC.ChuanThu1 == false && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT >= TuDot && itemHD.DOT <= DenDot && (itemHD.KhoaTienDu == true || itemHD.NGAYGIAITRACH == null)
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

        public DataTable GetChuanThu_DongNuoc_BaoCaoTongHop(DateTime FromDate, DateTime ToDate, int IDPhong)
        {
            string sql = "declare @FromDate date;"
                        + " declare @ToDate date;"
                        + " set @FromDate='" + FromDate.ToString("yyyyMMdd") + "';"
                        + " set @ToDate='" + ToDate.ToString("yyyyMMdd") + "';"
                        + " select nd.MaND as MaNV,nd.HoTen,nd.STT,toncu.TCTonCu_BD,toncu.TCTonCu_END,nhan.TCNhan_BD,nhan.TCNhan_END"
                        + ",dangngan.TCDangNgan_BD,dangngan.TCDangNgan_END,lenhhuy.TCHuy_BD,lenhhuy.TCHuy_END,tongton.TCTongTon_BD,tongton.TCTongTon_END from"
                        + " (select MaND,HoTen,STT from TT_NguoiDung where DongNuoc=1 and ToTruong=0 and (select DongNuoc from TT_To where TT_To.MaTo=TT_NguoiDung.MaTo)=1 and (select IDPhong from TT_To where TT_To.MaTo=TT_NguoiDung.MaTo)=" + IDPhong + ") nd"
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
                        + " and hd.MAY>=@TuCuonGCS and hd.MAY<=@DenCuonGCS"
                        + " and CAST(dn.CreateDate as date)<@FromDate and (hd.NGAYGIAITRACH is null or (CAST(hd.NGAYGIAITRACH as date)>@FromDate))"
                        + " group by nd.MaND,nd.HoTen,nd.STT) toncu on nd.MaND=toncu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,SUM(dchd.TONGCONG_BD) as TCNhan_BD,SUM(dchd.TONGCONG_END) as TCNhan_END"
                        + " from DIEUCHINH_HD dchd,TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dchd.SoHoaDon=hd.SOHOADON and dn.MaDN=ctdn.MaDN and ctdn.SoHoaDon=hd.SOHOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0 and dchd.ChuanThu1=0"
                        + " and hd.MAY>=@TuCuonGCS and hd.MAY<=@DenCuonGCS"
                        + " and CAST(dn.CreateDate as date)>=@FromDate and CAST(dn.CreateDate as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) nhan on nd.MaND=nhan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,SUM(dchd.TONGCONG_BD) as TCDangNgan_BD,SUM(dchd.TONGCONG_END) as TCDangNgan_END"
                        + " from DIEUCHINH_HD dchd,TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dchd.SoHoaDon=hd.SOHOADON and dn.MaDN=ctdn.MaDN and ctdn.SoHoaDon=hd.SOHOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0 and dchd.ChuanThu1=0"
                        + " and hd.MAY>=@TuCuonGCS and hd.MAY<=@DenCuonGCS"
                        + " and CAST(NGAYGIAITRACH as date)>=@FromDate and CAST(NGAYGIAITRACH as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) dangngan on nd.MaND=dangngan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,SUM(dchd.TONGCONG_BD) as TCHuy_BD,SUM(dchd.TONGCONG_END) as TCHuy_END"
                        + " from DIEUCHINH_HD dchd,TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_LenhHuy lenhhuy,TT_NguoiDung nd"
                        + " where dchd.SoHoaDon=hd.SOHOADON and dn.MaDN=ctdn.MaDN and ctdn.SoHoaDon=hd.SOHOADON and lenhhuy.SoHoaDon=hd.SOHOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0 and dchd.ChuanThu1=0"
                        + " and hd.MAY>=@TuCuonGCS and hd.MAY<=@DenCuonGCS"
                        + " and CAST(lenhhuy.CreateDate as date)>=@FromDate and CAST(lenhhuy.CreateDate as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) lenhhuy on nd.MaND=lenhhuy.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,SUM(dchd.TONGCONG_BD) as TCTongTon_BD,SUM(dchd.TONGCONG_END) as TCTongTon_END"
                        + " from DIEUCHINH_HD dchd,TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dchd.SoHoaDon=hd.SOHOADON and dn.MaDN=ctdn.MaDN and ctdn.SoHoaDon=hd.SOHOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0 and dchd.ChuanThu1=0"
                        + " and hd.MAY>=@TuCuonGCS and hd.MAY<=@DenCuonGCS"
                        + " and CAST(dn.NgayGiao as date)<=@ToDate and (hd.NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@ToDate) and ctdn.SoHoaDon not in (select SoHoaDon from TT_LenhHuy)"
                        + " group by nd.MaND,nd.HoTen,nd.STT) tongton on nd.MaND=tongton.MaND"
                        + " order by nd.STT asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getNangSuat_ChuanThu_Doi(int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            return ExecuteQuery_DataTable("declare @NgayGiaiTrach date;"
                             + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                             + " select MIN(t1.TongHD)as TongHD,MIN(t1.TongGiaBan)as TongGiaBan,MIN(t1.TongCong)as TongCong,MIN(t1.TongHDThu)as TongHDThu,MIN(t1.TongGiaBanThu)as TongGiaBanThu,MIN(t1.TongCongThu)as TongCongThu,MIN(t1.TongHDTon)as TongHDTon,MIN(t1.TongGiaBanTon)as TongGiaBanTon,MIN(t1.TongCongTon)as TongCongTon"
                             + " ,MIN(t1.TongHDThucThu)as TongHDThucThu,MIN(t1.TongGiaBanThucThu)as TongGiaBanThucThu,MIN(t1.TongCongThucThu)as TongCongThucThu from"
                             + " ((select count(DANHBA) as TongHD,sum(dc.GIABAN_DC) as TongGiaBan,sum(dc.TONGCONG_DC) as TongCong,0 as TongHDThu,0 as TongGiaBanThu,0 as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongHDThucThu,0 as TongGiaBanThucThu,0 as TongCongThucThu"
                             + " from HOADON hd,DIEUCHINH_HD dc where NAM=" + Nam + " and KY=" + Ky + " and hd.ID_HOADON=dc.FK_HOADON)"
                             + " union"
                             + " (select 0 as TongHD,0 as TongGiaBan,0 as TongCong,count(DANHBA) as TongHDThu,sum(dc.GIABAN_DC) as TongGiaBanThu,sum(dc.TONGCONG_DC) as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongHDThucThu,0 as TongGiaBanThucThu,0 as TongCongThucThu"
                             + " from HOADON hd,DIEUCHINH_HD dc where NAM=" + Nam + " and KY=" + Ky + " and hd.ID_HOADON=dc.FK_HOADON and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach)"
                             + " union"
                             + " (select 0 as TongHD,0 as TongGiaBan,0 as TongCong,0 as TongHDThu,0 as TongGiaBanThu,0 as TongCongThu,count(DANHBA) as TongHDTon,sum(dc.GIABAN_DC) as TongGiaBanTon,sum(dc.TONGCONG_DC) as TongCongTon,0 as TongHDThucThu,0 as TongGiaBanThucThu,0 as TongCongThucThu"
                             + " from HOADON hd,DIEUCHINH_HD dc where NAM=" + Nam + " and KY=" + Ky + " and hd.ID_HOADON=dc.FK_HOADON and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach))"
                             + " union"
                             + " (select 0 as TongHD,0 as TongGiaBan,0 as TongCong,0 as TongHDThu,0 as TongGiaBanThu,0 as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,count(DANHBA) as TongHDThucThu,sum(dc.GIABAN_DC) as TongGiaBanThucThu,sum(dc.TONGCONG_DC) as TongCongThucThu"
                             + " from HOADON hd,DIEUCHINH_HD dc where NAM=" + Nam + " and KY=" + Ky + " and hd.ID_HOADON=dc.FK_HOADON and NGAYGIAITRACH is not null)) t1;");
        }

        public DataTable getDS_Giay_TV_ChuaCapNhat()
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.SoPhieu == null && (itemHD.NAM < 2020 || (itemHD.NAM == 2020 && itemHD.KY < 7))
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            itemDC.NgayChan,
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
                        where itemDC.SoPhieu != null && itemDC.UpdatedHDDT == false && (itemHD.NAM < 2020 || (itemHD.NAM == 2020 && itemHD.KY < 7))
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            itemDC.NgayChan,
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
                        where itemDC.SoPhieu == null && itemDC.UpdatedHDDT == false && (itemHD.NAM < 2020 || (itemHD.NAM == 2020 && itemHD.KY < 7))
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            itemDC.NgayChan,
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
                        where itemDC.SoPhieu == null && (itemHD.NAM > 2020 || (itemHD.NAM == 2020 && itemHD.KY >= 7))
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            itemDC.NgayChan,
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
                        where itemDC.SoPhieu != null && itemDC.UpdatedHDDT == false && (itemHD.NAM > 2020 || (itemHD.NAM == 2020 && itemHD.KY >= 7))
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            itemDC.NgayChan,
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
                        where itemDC.SoPhieu == null && itemDC.UpdatedHDDT == false && (itemHD.NAM > 2020 || (itemHD.NAM == 2020 && itemHD.KY >= 7))
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            itemDC.NgayChan,
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

        public DataTable getDS_HDDT_Tong_CapNhat_ChuaDangNgan()
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.SoPhieu != null && itemDC.UpdatedHDDT == true && (itemHD.NAM > 2020 || (itemHD.NAM == 2020 && itemHD.KY >= 7))
                        && itemHD.NGAYGIAITRACH == null
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            itemDC.NgayChan,
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
                            itemDC.NgayChan,
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
                            itemDC.NgayChan,
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
                            itemDC.NgayChan,
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
                            itemDC.NgayChan,
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

        public DataTable GetDSByNgayChan(DateTime TuNgay, DateTime DenNgay)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.NgayChan.Value.Date >= TuNgay.Date && itemDC.NgayChan.Value.Date <= DenNgay.Date
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            itemDC.NgayChan,
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

        public DataTable GetDSByNgayChan(DateTime TuNgay, DateTime DenNgay, int Nam, int Ky)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.NgayChan.Value.Date >= TuNgay.Date && itemDC.NgayChan.Value.Date <= DenNgay.Date && itemHD.NAM == Nam && itemHD.KY == Ky
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            itemDC.NgayChan,
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
                            itemDC.NgayChan,
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
                            itemDC.NgayChan,
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
                            itemDC.NgayChan,
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
                            itemDC.NgayChan,
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
                            + " SELECT * FROM temp WHERE rn=1 order by Ngay_DC desc";
            return ExecuteQuery_DataTable(sql);
        }

        public bool updateLichSu(string SoPhieu, string SoHoaDonMoi)
        {
            string sql = "update TT_LichSuDieuChinhHD set SoHoaDonMoi='" + SoHoaDonMoi + "' where SoPhieu=" + SoPhieu;
            return ExecuteNonQuery(sql);
        }

        public bool LuuLichSuDC(DIEUCHINH_HD dchd)
        {
            TT_LichSuDieuChinhHD lsdc = new TT_LichSuDieuChinhHD();

            lsdc.FK_HOADON = dchd.FK_HOADON;
            lsdc.SoHoaDon = dchd.SoHoaDon;
            lsdc.GiaBieu = dchd.GiaBieu;
            lsdc.DinhMuc = dchd.DinhMuc;
            lsdc.DinhMucHN = dchd.DinhMucHN;
            lsdc.TIEUTHU_BD = dchd.TIEUTHU_BD;
            lsdc.GIABAN_BD = dchd.GIABAN_BD;
            lsdc.PHI_BD = dchd.PHI_BD;
            lsdc.PHI_Thue_BD = dchd.PHI_Thue_BD;
            lsdc.THUE_BD = dchd.THUE_BD;
            lsdc.TONGCONG_BD = dchd.TONGCONG_BD;

            lsdc.PHIEU_DC = dchd.PHIEU_DC;
            lsdc.NGAY_VB = dchd.NGAY_VB;
            lsdc.NGAY_DC = dchd.NGAY_DC;
            lsdc.SoPhieu = dchd.SoPhieu;
            lsdc.TangGiam = dchd.TangGiam;

            lsdc.GIABAN_DC = dchd.GIABAN_DC;
            lsdc.GIABAN_END = dchd.GIABAN_END;

            lsdc.THUE_DC = dchd.THUE_DC;
            lsdc.THUE_END = dchd.THUE_END;

            lsdc.PHI_DC = dchd.PHI_DC;
            lsdc.PHI_END = dchd.PHI_END;
            lsdc.PHI_Thue_DC = dchd.PHI_Thue_DC;
            lsdc.PHI_Thue_END = dchd.PHI_Thue_END;

            lsdc.TONGCONG_DC = dchd.TONGCONG_DC;
            lsdc.TONGCONG_END = dchd.TONGCONG_END;

            lsdc.GB_DC = dchd.GB_DC;
            lsdc.DM_DC = dchd.DM_DC;
            lsdc.DinhMucHN_DC = dchd.DinhMucHN_DC;
            lsdc.TIEUTHU_DC = dchd.TIEUTHU_DC;

            lsdc.SoHoaDonMoi = dchd.SoHoaDonMoi;

            lsdc.HoTen_BD = dchd.HoTen_BD;
            lsdc.HoTen_End = dchd.HoTen_End;
            lsdc.DiaChi_BD = dchd.DiaChi_BD;
            lsdc.DiaChi_End = dchd.DiaChi_End;
            lsdc.NgayChan = dchd.NgayChan;

            return ThemLSDC(lsdc);
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
                Refresh();
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
                Refresh();
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

        //hóa đơn thu tiền trước, điều chỉnh đăng ngân sau
        public bool Them_HDDC_DangNgan(TT_HDDC_DangNgan en)
        {
            try
            {
                en.CreateDate = DateTime.Now;
                en.CreateBy = CNguoiDung.MaND;
                _db.TT_HDDC_DangNgans.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_HDDC_DangNgan(TT_HDDC_DangNgan en)
        {
            try
            {
                _db.TT_HDDC_DangNgans.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist_HDDC_DangNgan(int MaHD)
        {
            return _db.TT_HDDC_DangNgans.Any(item => item.MaHD == MaHD);
        }

        public bool checkExist_Chot_HDDC_DangNgan(int MaHD)
        {
            HOADON hd = _db.HOADONs.SingleOrDefault(itemHD => itemHD.ID_HOADON == MaHD);
            if (hd != null)
            {
                if (hd.NAM > 2022 || (hd.NAM == 2022 && hd.KY >= 5))
                    return true;
                else
                    return false;
            }
            return false;
        }

        public DataTable getDS_HDDC_Cho_DangNgan_HD0()
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.TONGCONG_END == 0 && itemHD.NGAYGIAITRACH == null && itemDC.SoPhieu != null && itemDC.UpdatedHDDT == false && (itemHD.NAM > 2022 || (itemHD.NAM == 2022 && itemHD.KY >= 5))
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            itemDC.NgayChan,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            MaHD = itemDC.FK_HOADON,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            GiaBan_End = itemDC.GIABAN_END,
                            ThueGTGT_End = itemDC.THUE_END,
                            PhiBVMT_End = itemDC.PHI_END,
                            PhiBVMT_Thue_End = itemDC.PHI_Thue_END,
                            TongCong_End = itemDC.TONGCONG_END,
                            itemDC.TangGiam,
                            GiaBan_BD = itemDC.GIABAN_DC,
                            ThueGTGT_BD = itemDC.THUE_DC,
                            PhiBVMT_BD = itemDC.PHI_DC,
                            PhiBVMT_Thue_BD = itemDC.PHI_Thue_DC,
                            TongCong_BD = itemDC.TONGCONG_DC,
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
                            HoTenMoi = itemDC.HoTen_End,
                            DiaChiMoi = itemDC.DiaChi_End,
                            MSTMoi = itemDC.MST_End,
                            GiaBieuCu = itemDC.GiaBieu,
                            DinhMucCu = itemDC.DinhMuc,
                            TieuThuCu = itemDC.TIEUTHU_BD,
                            GiaBieuMoi = itemDC.GB_DC,
                            DinhMucMoi = itemDC.DM_DC,
                            TieuThuMoi = itemDC.TIEUTHU_DC,
                            GiaBan_Start = itemDC.GIABAN_BD,
                            ThueGTGT_Start = itemDC.THUE_BD,
                            PhiBVMT_Start = itemDC.PHI_BD,
                            PhiBVMT_Thue_Start = itemDC.PHI_Thue_BD,
                            TongCong_Start = itemDC.TONGCONG_BD,
                            itemDC.SoPhieu,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_HDDC_Cho_DangNgan_HD0_ThayThe()
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.TONGCONG_END == 0 && itemHD.NGAYGIAITRACH == null && itemDC.SoPhieu != null && itemDC.UpdatedHDDT == false && (itemHD.NAM < 2022 || (itemHD.NAM == 2022 && itemHD.KY < 5))
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            itemDC.NgayChan,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            MaHD = itemDC.FK_HOADON,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            GiaBan_End = itemDC.GIABAN_END,
                            ThueGTGT_End = itemDC.THUE_END,
                            PhiBVMT_End = itemDC.PHI_END,
                            PhiBVMT_Thue_End = itemDC.PHI_Thue_END,
                            TongCong_End = itemDC.TONGCONG_END,
                            itemDC.TangGiam,
                            GiaBan_BD = itemDC.GIABAN_DC,
                            ThueGTGT_BD = itemDC.THUE_DC,
                            PhiBVMT_BD = itemDC.PHI_DC,
                            PhiBVMT_Thue_BD = itemDC.PHI_Thue_DC,
                            TongCong_BD = itemDC.TONGCONG_DC,
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
                            HoTenMoi = itemDC.HoTen_End,
                            DiaChiMoi = itemDC.DiaChi_End,
                            MSTMoi = itemDC.MST_End,
                            GiaBieuCu = itemDC.GiaBieu,
                            DinhMucCu = itemDC.DinhMuc,
                            TieuThuCu = itemDC.TIEUTHU_BD,
                            GiaBieuMoi = itemDC.GB_DC,
                            DinhMucMoi = itemDC.DM_DC,
                            TieuThuMoi = itemDC.TIEUTHU_DC,
                            GiaBan_Start = itemDC.GIABAN_BD,
                            ThueGTGT_Start = itemDC.THUE_BD,
                            PhiBVMT_Start = itemDC.PHI_BD,
                            PhiBVMT_Thue_Start = itemDC.PHI_Thue_BD,
                            TongCong_Start = itemDC.TONGCONG_BD,
                            itemDC.SoPhieu,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_HDDC_Cho_DangNgan()
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHDDC in _db.TT_HDDC_DangNgans on itemDC.FK_HOADON equals itemHDDC.MaHD
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.TONGCONG_END != 0 && itemDC.SoPhieu != null && itemDC.UpdatedHDDT == false && (itemHD.NAM > 2022 || (itemHD.NAM == 2022 && itemHD.KY >= 5))
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            itemDC.NgayChan,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            MaHD = itemDC.FK_HOADON,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            GiaBan_End = itemDC.GIABAN_END,
                            ThueGTGT_End = itemDC.THUE_END,
                            PhiBVMT_End = itemDC.PHI_END,
                            PhiBVMT_Thue_End = itemDC.PHI_Thue_END,
                            TongCong_End = itemDC.TONGCONG_END,
                            itemDC.TangGiam,
                            GiaBan_BD = itemDC.GIABAN_DC,
                            ThueGTGT_BD = itemDC.THUE_DC,
                            PhiBVMT_BD = itemDC.PHI_DC,
                            PhiBVMT_Thue_BD = itemDC.PHI_Thue_DC,
                            TongCong_BD = itemDC.TONGCONG_DC,
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
                            HoTenMoi = itemDC.HoTen_End,
                            DiaChiMoi = itemDC.DiaChi_End,
                            MSTMoi = itemDC.MST_End,
                            GiaBieuCu = itemDC.GiaBieu,
                            DinhMucCu = itemDC.DinhMuc,
                            TieuThuCu = itemDC.TIEUTHU_BD,
                            GiaBieuMoi = itemDC.GB_DC,
                            DinhMucMoi = itemDC.DM_DC,
                            TieuThuMoi = itemDC.TIEUTHU_DC,
                            GiaBan_Start = itemDC.GIABAN_BD,
                            ThueGTGT_Start = itemDC.THUE_BD,
                            PhiBVMT_Start = itemDC.PHI_BD,
                            PhiBVMT_Thue_Start = itemDC.PHI_Thue_BD,
                            TongCong_Start = itemDC.TONGCONG_BD,
                            itemHDDC.ChuyenKhoan,
                            itemDC.SoPhieu,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_HDDC_Cho_DangNgan_ThayThe_Admin(int CreateBy)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHDDC in _db.TT_QuetTams on itemDC.FK_HOADON equals itemHDDC.MaHD
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHDDC.CreateBy == CreateBy && (itemHD.NAM < 2022 || (itemHD.NAM == 2022 && itemHD.KY < 5))
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            itemDC.NgayChan,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            MaHD = itemDC.FK_HOADON,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            GiaBan_End = itemDC.GIABAN_END,
                            ThueGTGT_End = itemDC.THUE_END,
                            PhiBVMT_End = itemDC.PHI_END,
                            PhiBVMT_Thue_End = itemDC.PHI_Thue_END,
                            TongCong_End = itemDC.TONGCONG_END,
                            itemDC.TangGiam,
                            GiaBan_BD = itemDC.GIABAN_DC,
                            ThueGTGT_BD = itemDC.THUE_DC,
                            PhiBVMT_BD = itemDC.PHI_DC,
                            PhiBVMT_Thue_BD = itemDC.PHI_Thue_DC,
                            TongCong_BD = itemDC.TONGCONG_DC,
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
                            HoTenMoi = itemDC.HoTen_End,
                            DiaChiMoi = itemDC.DiaChi_End,
                            MSTMoi = itemDC.MST_End,
                            GiaBieuCu = itemDC.GiaBieu,
                            DinhMucCu = itemDC.DinhMuc,
                            TieuThuCu = itemDC.TIEUTHU_BD,
                            GiaBieuMoi = itemDC.GB_DC,
                            DinhMucMoi = itemDC.DM_DC,
                            TieuThuMoi = itemDC.TIEUTHU_DC,
                            GiaBan_Start = itemDC.GIABAN_BD,
                            ThueGTGT_Start = itemDC.THUE_BD,
                            PhiBVMT_Start = itemDC.PHI_BD,
                            PhiBVMT_Thue_Start = itemDC.PHI_Thue_BD,
                            TongCong_Start = itemDC.TONGCONG_BD,
                            itemDC.SoPhieu,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_HDDC_Cho_DangNgan_ThayThe()
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHDDC in _db.TT_HDDC_DangNgans on itemDC.FK_HOADON equals itemHDDC.MaHD
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.TONGCONG_END != 0 && itemDC.SoPhieu != null && itemDC.UpdatedHDDT == false && (itemHD.NAM < 2022 || (itemHD.NAM == 2022 && itemHD.KY < 5))
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            itemDC.NgayChan,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            MaHD = itemDC.FK_HOADON,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            GiaBan_End = itemDC.GIABAN_END,
                            ThueGTGT_End = itemDC.THUE_END,
                            PhiBVMT_End = itemDC.PHI_END,
                            PhiBVMT_Thue_End = itemDC.PHI_Thue_END,
                            TongCong_End = itemDC.TONGCONG_END,
                            itemDC.TangGiam,
                            GiaBan_BD = itemDC.GIABAN_DC,
                            ThueGTGT_BD = itemDC.THUE_DC,
                            PhiBVMT_BD = itemDC.PHI_DC,
                            PhiBVMT_Thue_BD = itemDC.PHI_Thue_DC,
                            TongCong_BD = itemDC.TONGCONG_DC,
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
                            HoTenMoi = itemDC.HoTen_End,
                            DiaChiMoi = itemDC.DiaChi_End,
                            MSTMoi = itemDC.MST_End,
                            GiaBieuCu = itemDC.GiaBieu,
                            DinhMucCu = itemDC.DinhMuc,
                            TieuThuCu = itemDC.TIEUTHU_BD,
                            GiaBieuMoi = itemDC.GB_DC,
                            DinhMucMoi = itemDC.DM_DC,
                            TieuThuMoi = itemDC.TIEUTHU_DC,
                            GiaBan_Start = itemDC.GIABAN_BD,
                            ThueGTGT_Start = itemDC.THUE_BD,
                            PhiBVMT_Start = itemDC.PHI_BD,
                            PhiBVMT_Thue_Start = itemDC.PHI_Thue_BD,
                            TongCong_Start = itemDC.TONGCONG_BD,
                            itemHDDC.ChuyenKhoan,
                            itemDC.SoPhieu,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_HDDC_DangNgan_HD0(int FromDot, int ToDot)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.TONGCONG_END == 0 && itemHD.NGAYGIAITRACH == null && itemDC.SoPhieu != null && itemDC.UpdatedHDDT == true && (itemHD.NAM > 2022 || (itemHD.NAM == 2022 && itemHD.KY >= 5))
                        && itemHD.DOT >= FromDot && itemHD.DOT <= ToDot
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            itemDC.NgayChan,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            MaHD = itemDC.FK_HOADON,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            GiaBan_End = itemDC.GIABAN_END,
                            ThueGTGT_End = itemDC.THUE_END,
                            PhiBVMT_End = itemDC.PHI_END,
                            PhiBVMT_Thue_End = itemDC.PHI_Thue_END,
                            TongCong_End = itemDC.TONGCONG_END,
                            itemDC.TangGiam,
                            GiaBan_BD = itemDC.GIABAN_DC,
                            ThueGTGT_BD = itemDC.THUE_DC,
                            PhiBVMT_BD = itemDC.PHI_DC,
                            PhiBVMT_Thue_BD = itemDC.PHI_Thue_DC,
                            TongCong_BD = itemDC.TONGCONG_DC,
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
                            PhiBVMT_Thue_Start = itemDC.PHI_Thue_BD,
                            TongCong_Start = itemDC.TONGCONG_BD,
                            itemDC.SoPhieu,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_HDDC_DangNgan(int FromDot, int ToDot)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHDDC in _db.TT_HDDC_DangNgans on itemDC.FK_HOADON equals itemHDDC.MaHD
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDC.TONGCONG_END != 0 && itemDC.SoPhieu != null && itemDC.UpdatedHDDT == true && (itemHD.NAM > 2022 || (itemHD.NAM == 2022 && itemHD.KY >= 5))
                        && itemHD.DOT >= FromDot && itemHD.DOT <= ToDot
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            itemDC.NgayChan,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            MaHD = itemDC.FK_HOADON,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            GiaBan_End = itemDC.GIABAN_END,
                            ThueGTGT_End = itemDC.THUE_END,
                            PhiBVMT_End = itemDC.PHI_END,
                            PhiBVMT_Thue_End = itemDC.PHI_Thue_END,
                            TongCong_End = itemDC.TONGCONG_END,
                            itemDC.TangGiam,
                            GiaBan_BD = itemDC.GIABAN_DC,
                            ThueGTGT_BD = itemDC.THUE_DC,
                            PhiBVMT_BD = itemDC.PHI_DC,
                            PhiBVMT_Thue_BD = itemDC.PHI_Thue_DC,
                            TongCong_BD = itemDC.TONGCONG_DC,
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
                            PhiBVMT_Thue_Start = itemDC.PHI_Thue_BD,
                            TongCong_Start = itemDC.TONGCONG_BD,
                            itemHDDC.ChuyenKhoan,
                            itemDC.SoPhieu,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_HDDC_DangNgan_GiaoNhan(DateTime FromNgayDangNgan, DateTime ToNgayDangNgan)
        {
            //var query = from itemDC in _db.DIEUCHINH_HDs
            //            join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
            //            where itemHD.NGAYGIAITRACH.Value.Date >= FromNgayDangNgan.Date && itemHD.NGAYGIAITRACH.Value.Date <= ToNgayDangNgan.Date && itemHD.MaNV_DangNgan != null
            //            && itemDC.NGAY_DC.Value.Date >= new DateTime(2022, 07, 01).Date
            //            orderby itemHD.NGAYGIAITRACH ascending
            //            select new
            //            {
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                DanhBo = itemHD.DANHBA,
            //                itemHD.TONGCONG,
            //                itemHD.NGAYGIAITRACH,
            //                itemDC.SoPhieu,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.DangNgan_Quay,
            //            };
            //return LINQToDataTable(query);
            return ExecuteQuery_DataTable("select Ky=CONVERT(varchar(2),Ky)+'/'+CONVERT(varchar(4),NAM),DanhBo=hd.DANHBA"
                                    + " ,hd.TONGCONG,NGAYGIAITRACH,dc.SoPhieu,DangNgan_ChuyenKhoan,DangNgan_Quay"
                                    + " from DIEUCHINH_HD dc,HOADON hd"
                                    + " where dc.FK_HOADON=hd.ID_HOADON and MaNV_DangNgan is not null"
                                    + " and CAST(NGAYGIAITRACH as date)>='" + FromNgayDangNgan.ToString("yyyyMMdd") + "' and CAST(NGAYGIAITRACH as date)<='" + ToNgayDangNgan.ToString("yyyyMMdd") + "'"
                                    + " and CAST(NGAY_DC as date)>='20220701' order by CAST(NGAYGIAITRACH as date)");
        }

        public DataTable getNam_HDDC_Cho_DangNgan_va_HD0()
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHDDC in _db.TT_HDDC_DangNgans on itemDC.FK_HOADON equals itemHDDC.MaHD
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where (itemDC.TONGCONG_END != 0 || (itemDC.TONGCONG_END == 0 && itemHD.NGAYGIAITRACH == null)) && itemDC.SoPhieu != null && itemDC.UpdatedHDDT == false && (itemHD.NAM > 2022 || (itemHD.NAM == 2022 && itemHD.KY >= 5))
                        select new
                        {
                            NgayDC = itemDC.NGAY_DC,
                            itemDC.NgayChan,
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            MaHD = itemDC.FK_HOADON,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            GiaBan_End = itemDC.GIABAN_END,
                            ThueGTGT_End = itemDC.THUE_END,
                            PhiBVMT_End = itemDC.PHI_END,
                            PhiBVMT_Thue_End = itemDC.PHI_Thue_END,
                            TongCong_End = itemDC.TONGCONG_END,
                            itemDC.TangGiam,
                            GiaBan_BD = itemDC.GIABAN_DC,
                            ThueGTGT_BD = itemDC.THUE_DC,
                            PhiBVMT_BD = itemDC.PHI_DC,
                            PhiBVMT_Thue_BD = itemDC.PHI_Thue_DC,
                            TongCong_BD = itemDC.TONGCONG_DC,
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
                            HoTenMoi = itemDC.HoTen_End,
                            DiaChiMoi = itemDC.DiaChi_End,
                            MSTMoi = itemDC.MST_End,
                            GiaBieuCu = itemDC.GiaBieu,
                            DinhMucCu = itemDC.DinhMuc,
                            TieuThuCu = itemDC.TIEUTHU_BD,
                            GiaBieuMoi = itemDC.GB_DC,
                            DinhMucMoi = itemDC.DM_DC,
                            TieuThuMoi = itemDC.TIEUTHU_DC,
                            GiaBan_Start = itemDC.GIABAN_BD,
                            ThueGTGT_Start = itemDC.THUE_BD,
                            PhiBVMT_Start = itemDC.PHI_BD,
                            PhiBVMT_Thue_Start = itemDC.PHI_Thue_BD,
                            TongCong_Start = itemDC.TONGCONG_BD,
                            itemHDDC.ChuyenKhoan,
                            itemDC.SoPhieu,
                        };
            return LINQToDataTable(query);
        }

    }

}

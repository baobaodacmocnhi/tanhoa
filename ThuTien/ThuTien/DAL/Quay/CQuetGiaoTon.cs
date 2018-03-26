using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.Quay
{
    class CQuetGiaoTon : CDAL
    {
        public bool Them(TT_QuetGiaoTon entity)
        {
            try
            {
                if (_db.TT_QuetGiaoTons.Count() > 0)
                    entity.ID = _db.TT_QuetGiaoTons.Max(item => item.ID) + 1;
                else
                    entity.ID = 1;
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CNguoiDung.MaND;
                _db.TT_QuetGiaoTons.InsertOnSubmit(entity);
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

        public bool Xoa(TT_QuetGiaoTon entity)
        {
            try
            {
                _db.TT_QuetGiaoTons.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(string SoHoaDon, DateTime CreateDate)
        {
            return _db.TT_QuetGiaoTons.Any(item => item.SoHoaDon == SoHoaDon && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public TT_QuetGiaoTon Get(int ID)
        {
            return _db.TT_QuetGiaoTons.SingleOrDefault(item => item.ID == ID);
        }

        public TT_QuetGiaoTon Get(string SoHoaDon)
        {
            return _db.TT_QuetGiaoTons.SingleOrDefault(item => item.SoHoaDon == SoHoaDon);
        }

        public DataTable GetDS(string Loai, DateTime FromCreatedDate, DateTime ToCreatedDate)
        {
            if (Loai == "TG")
            {
                var query = from itemQT in _db.TT_QuetGiaoTons
                            join itemHD in _db.HOADONs on itemQT.MaHD equals itemHD.ID_HOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemQT.CreateDate.Value.Date >= FromCreatedDate.Date && itemQT.CreateDate.Value.Date <= ToCreatedDate.Date && itemHD.GB >= 11 && itemHD.GB <= 20
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                Loai = "TG",
                                itemQT.ID,
                                itemQT.SoHoaDon,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                MLT = itemHD.MALOTRINH,
                                itemHD.SOPHATHANH,
                                itemHD.TONGCONG,
                                GiaBieu = itemHD.GB,
                                HanhThu = itemtableND.HoTen,
                                To = itemtableND.TT_To.TenTo,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemQT in _db.TT_QuetGiaoTons
                                join itemHD in _db.HOADONs on itemQT.SoHoaDon equals itemHD.SOHOADON
                                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemQT.CreateDate.Value.Date >= FromCreatedDate.Date && itemQT.CreateDate.Value.Date <= ToCreatedDate.Date && itemHD.GB > 20
                                orderby itemHD.MALOTRINH ascending
                                select new
                                {
                                    Loai = "CQ",
                                    itemQT.ID,
                                    itemQT.SoHoaDon,
                                    DanhBo = itemHD.DANHBA,
                                    HoTen = itemHD.TENKH,
                                    DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                    Ky = itemHD.KY + "/" + itemHD.NAM,
                                    MLT = itemHD.MALOTRINH,
                                    itemHD.SOPHATHANH,
                                    itemHD.TONGCONG,
                                    GiaBieu = itemHD.GB,
                                    HanhThu = itemtableND.HoTen,
                                    To = itemtableND.TT_To.TenTo,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSByMaTo(string Loai, int MaTo, DateTime FromCreatedDate, DateTime ToCreatedDate)
        {
            if (Loai == "TG")
            {
                var query = from itemQT in _db.TT_QuetGiaoTons
                            join itemHD in _db.HOADONs on itemQT.MaHD equals itemHD.ID_HOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            && itemQT.CreateDate.Value.Date >= FromCreatedDate.Date && itemQT.CreateDate.Value.Date <= ToCreatedDate.Date && itemHD.GB >= 11 && itemHD.GB <= 20
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                Loai = "TG",
                                itemQT.ID,
                                itemQT.SoHoaDon,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                MLT = itemHD.MALOTRINH,
                                itemHD.SOPHATHANH,
                                itemHD.TONGCONG,
                                GiaBieu = itemHD.GB,
                                HanhThu = itemtableND.HoTen,
                                To = itemtableND.TT_To.TenTo,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemQT in _db.TT_QuetGiaoTons
                                join itemHD in _db.HOADONs on itemQT.SoHoaDon equals itemHD.SOHOADON
                                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && itemQT.CreateDate.Value.Date >= FromCreatedDate.Date && itemQT.CreateDate.Value.Date <= ToCreatedDate.Date && itemHD.GB > 20
                                orderby itemHD.MALOTRINH ascending
                                select new
                                {
                                    Loai = "CQ",
                                    itemQT.ID,
                                    itemQT.SoHoaDon,
                                    DanhBo = itemHD.DANHBA,
                                    HoTen = itemHD.TENKH,
                                    DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                    Ky = itemHD.KY + "/" + itemHD.NAM,
                                    MLT = itemHD.MALOTRINH,
                                    itemHD.SOPHATHANH,
                                    itemHD.TONGCONG,
                                    GiaBieu = itemHD.GB,
                                    HanhThu = itemtableND.HoTen,
                                    To = itemtableND.TT_To.TenTo,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSByMaNV(string Loai, int MaNV_HanhThu, DateTime FromCreatedDate, DateTime ToCreatedDate)
        {
            if (Loai == "TG")
            {
                var query = from itemQT in _db.TT_QuetGiaoTons
                            join itemHD in _db.HOADONs on itemQT.MaHD equals itemHD.ID_HOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemQT.CreateDate.Value.Date >= FromCreatedDate.Date && itemQT.CreateDate.Value.Date <= ToCreatedDate.Date && itemHD.MaNV_HanhThu == MaNV_HanhThu && itemHD.GB >= 11 && itemHD.GB <= 20
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                Loai="TG",
                                itemQT.ID,
                                itemQT.SoHoaDon,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                MLT = itemHD.MALOTRINH,
                                itemHD.SOPHATHANH,
                                itemHD.TONGCONG,
                                GiaBieu = itemHD.GB,
                                HanhThu = itemtableND.HoTen,
                                To = itemtableND.TT_To.TenTo,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemQT in _db.TT_QuetGiaoTons
                                join itemHD in _db.HOADONs on itemQT.SoHoaDon equals itemHD.SOHOADON
                                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemQT.CreateDate.Value.Date >= FromCreatedDate.Date && itemQT.CreateDate.Value.Date <= ToCreatedDate.Date && itemHD.MaNV_HanhThu == MaNV_HanhThu && itemHD.GB > 20
                                orderby itemHD.MALOTRINH ascending
                                select new
                                {
                                    Loai = "CQ",
                                    itemQT.ID,
                                    itemQT.SoHoaDon,
                                    DanhBo = itemHD.DANHBA,
                                    HoTen = itemHD.TENKH,
                                    DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                    Ky = itemHD.KY + "/" + itemHD.NAM,
                                    MLT = itemHD.MALOTRINH,
                                    itemHD.SOPHATHANH,
                                    itemHD.TONGCONG,
                                    GiaBieu = itemHD.GB,
                                    HanhThu = itemtableND.HoTen,
                                    To = itemtableND.TT_To.TenTo,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        //public DataTable GetDS(DateTime CreatedDate)
        //{
        //        var query = from itemQT in _db.TT_QuetGiaoTons
        //                    join itemHD in _db.HOADONs on itemQT.MaHD equals itemHD.ID_HOADON
        //                    join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
        //                    from itemtableND in tableND.DefaultIfEmpty()
        //                    where itemQT.CreateDate.Value.Date == CreatedDate.Date
        //                    orderby itemHD.MALOTRINH ascending
        //                    select new
        //                    {
        //                        itemQT.ID,
        //                        itemQT.SoHoaDon,
        //                        DanhBo = itemHD.DANHBA,
        //                        HoTen = itemHD.TENKH,
        //                        DiaChi = itemHD.SO + " " + itemHD.DUONG,
        //                        Ky = itemHD.KY + "/" + itemHD.NAM,
        //                        MLT = itemHD.MALOTRINH,
        //                        itemHD.SOPHATHANH,
        //                        itemHD.TONGCONG,
        //                        GiaBieu = itemHD.GB,
        //                        HanhThu = itemtableND.HoTen,
        //                        To = itemtableND.TT_To.TenTo,
        //                    };
        //        return LINQToDataTable(query);
        //}

        //public DataTable GetDSByMaTo(int MaTo, DateTime CreatedDate)
        //{
        //        var query = from itemQT in _db.TT_QuetGiaoTons
        //                    join itemHD in _db.HOADONs on itemQT.MaHD equals itemHD.ID_HOADON
        //                    join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
        //                    from itemtableND in tableND.DefaultIfEmpty()
        //                    where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
        //                        && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    && itemQT.CreateDate.Value.Date == CreatedDate.Date
        //                    orderby itemHD.MALOTRINH ascending
        //                    select new
        //                    {
        //                        itemQT.ID,
        //                        itemQT.SoHoaDon,
        //                        DanhBo = itemHD.DANHBA,
        //                        HoTen = itemHD.TENKH,
        //                        DiaChi = itemHD.SO + " " + itemHD.DUONG,
        //                        Ky = itemHD.KY + "/" + itemHD.NAM,
        //                        MLT = itemHD.MALOTRINH,
        //                        itemHD.SOPHATHANH,
        //                        itemHD.TONGCONG,
        //                        GiaBieu = itemHD.GB,
        //                        HanhThu = itemtableND.HoTen,
        //                        To = itemtableND.TT_To.TenTo,
        //                    };
        //        return LINQToDataTable(query);
        //}

        //public DataTable GetDSByMaNV(int MaNV_HanhThu, DateTime CreatedDate)
        //{
        //        var query = from itemQT in _db.TT_QuetGiaoTons
        //                    join itemHD in _db.HOADONs on itemQT.MaHD equals itemHD.ID_HOADON
        //                    join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
        //                    from itemtableND in tableND.DefaultIfEmpty()
        //                    where itemQT.CreateDate.Value.Date == CreatedDate.Date && itemHD.MaNV_HanhThu == MaNV_HanhThu
        //                    orderby itemHD.MALOTRINH ascending
        //                    select new
        //                    {
        //                        itemQT.ID,
        //                        itemQT.SoHoaDon,
        //                        DanhBo = itemHD.DANHBA,
        //                        HoTen = itemHD.TENKH,
        //                        DiaChi = itemHD.SO + " " + itemHD.DUONG,
        //                        Ky = itemHD.KY + "/" + itemHD.NAM,
        //                        MLT = itemHD.MALOTRINH,
        //                        itemHD.SOPHATHANH,
        //                        itemHD.TONGCONG,
        //                        GiaBieu = itemHD.GB,
        //                        HanhThu = itemtableND.HoTen,
        //                        To = itemtableND.TT_To.TenTo,
        //                    };
        //        return LINQToDataTable(query);
        //}

    }
}

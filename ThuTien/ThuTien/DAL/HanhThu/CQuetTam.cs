using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.HanhThu
{
    class CQuetTam : CDAL
    {
        public bool Them(TT_QuetTam quettam)
        {
            try
            {
                if (_db.TT_QuetTams.Count() > 0)
                    quettam.MaQT = _db.TT_QuetTams.Max(item => item.MaQT) + 1;
                else
                    quettam.MaQT = 1;
                quettam.CreateDate = DateTime.Now;
                quettam.CreateBy = CNguoiDung.MaND;
                _db.TT_QuetTams.InsertOnSubmit(quettam);
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

        public bool Xoa(TT_QuetTam quettam)
        {
            try
            {
                _db.TT_QuetTams.DeleteOnSubmit(quettam);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(string SoHoaDon, int CreatBy, DateTime CreateDate)
        {
            return _db.TT_QuetTams.Any(item => item.SoHoaDon == SoHoaDon && item.CreateBy == CreatBy && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public TT_QuetTam GetByID(int MaQT)
        {
            return _db.TT_QuetTams.SingleOrDefault(item => item.MaQT == MaQT);
        }

        public TT_QuetTam GetBySoHoaDon(string SoHoaDon)
        {
            return _db.TT_QuetTams.SingleOrDefault(item => item.SoHoaDon == SoHoaDon);
        }

        public DataTable GetDSByMaNVCreatedDate(string Loai, int MaNV, DateTime CreatedDate)
        {
            if (Loai == "TG")
            {
                var query = from itemQT in _db.TT_QuetTams
                            join itemHD in _db.HOADONs on itemQT.SoHoaDon equals itemHD.SOHOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemQT.CreateDate.Value.Date == CreatedDate.Date && itemQT.CreateBy == MaNV && itemHD.GB >= 11 && itemHD.GB <= 20
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                itemQT.MaQT,
                                itemQT.CreateBy,
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
                    var query = from itemQT in _db.TT_QuetTams
                                join itemHD in _db.HOADONs on itemQT.SoHoaDon equals itemHD.SOHOADON
                                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemQT.CreateDate.Value.Date == CreatedDate.Date && itemQT.CreateBy == MaNV && itemHD.GB > 20
                                orderby itemHD.MALOTRINH ascending
                                select new
                                {
                                    itemQT.MaQT,
                                    itemQT.CreateBy,
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

        public DataTable GetDSByMaNVCreatedDate(string Loai, int MaNV)
        {
            if (Loai == "TG")
            {
                var query = from itemQT in _db.TT_QuetTams
                            join itemHD in _db.HOADONs on itemQT.SoHoaDon equals itemHD.SOHOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemQT.CreateBy == MaNV && itemHD.GB >= 11 && itemHD.GB <= 20
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                itemQT.MaQT,
                                itemQT.CreateBy,
                                itemQT.SoHoaDon,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                MLT = itemHD.MALOTRINH,
                                itemHD.SOPHATHANH,
                                itemHD.TONGCONG,
                                GiaBieu=itemHD.GB,
                                itemHD.HOPDONG,
                                HanhThu = itemtableND.HoTen,
                                To=itemtableND.TT_To.TenTo,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemQT in _db.TT_QuetTams
                                join itemHD in _db.HOADONs on itemQT.SoHoaDon equals itemHD.SOHOADON
                                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemQT.CreateBy == MaNV && itemHD.GB > 20
                                orderby itemHD.MALOTRINH ascending
                                select new
                                {
                                    itemQT.MaQT,
                                    itemQT.CreateBy,
                                    itemQT.SoHoaDon,
                                    DanhBo = itemHD.DANHBA,
                                    HoTen = itemHD.TENKH,
                                    DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                    Ky = itemHD.KY + "/" + itemHD.NAM,
                                    MLT = itemHD.MALOTRINH,
                                    itemHD.SOPHATHANH,
                                    itemHD.TONGCONG,
                                    GiaBieu = itemHD.GB,
                                    itemHD.HOPDONG,
                                    HanhThu = itemtableND.HoTen,
                                    To = itemtableND.TT_To.TenTo,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSByMaNVCreatedDate(int MaNV, DateTime CreatedDate)
        {
            var query = from itemQT in _db.TT_QuetTams
                        join itemHD in _db.HOADONs on itemQT.SoHoaDon equals itemHD.SOHOADON
                        where itemQT.CreateDate.Value.Date == CreatedDate.Date && itemQT.CreateBy == MaNV
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                        };
            return LINQToDataTable(query);
        }
    }
}

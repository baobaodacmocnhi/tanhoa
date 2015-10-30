using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ThuTien.DAL.ChuyenKhoan
{
    class CDichVuThu:CDAL
    {
        public DataTable GetDichVuThu()
        {
            return LINQToDataTable(_db.ViewGetDichVuThus.OrderBy(item=>item.TenDichVu));
        }

        public DataTable GetDS(string TenDichVu,DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from itemDV in _db.TT_DichVuThus
                        join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDV.CreateDate.Date >= FromCreateDate.Date && itemDV.CreateDate.Date <= ToCreateDate.Date && itemDV.TenDichVu.Contains(TenDichVu)
                        select new
                        {
                            itemDV.SoHoaDon,
                            itemDV.SoTien,
                            itemDV.Phi,
                            itemDV.TenDichVu,
                            itemDV.CreateDate,
                            itemHD.NGAYGIAITRACH,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi=itemHD.SO+" "+itemHD.DUONG,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(int MaTo, string TenDichVu, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from itemDV in _db.TT_DichVuThus
                        join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDV.CreateDate.Date >= FromCreateDate.Date && itemDV.CreateDate.Date <= ToCreateDate.Date && itemDV.TenDichVu.Contains(TenDichVu)
                            && Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                            && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        select new
                        {
                            itemDV.SoHoaDon,
                            itemDV.SoTien,
                            itemDV.Phi,
                            itemDV.TenDichVu,
                            itemDV.CreateDate,
                            itemHD.NGAYGIAITRACH,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                        };
            return LINQToDataTable(query);
        }
    }
}

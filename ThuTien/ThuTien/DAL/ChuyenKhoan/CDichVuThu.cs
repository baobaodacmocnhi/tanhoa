using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ThuTien.DAL.ChuyenKhoan
{
    class CDichVuThu:CDAL
    {
        public bool CheckExist(string SoHoaDon)
        {
            return _db.TT_DichVuThus.Any(item => item.SoHoaDon == SoHoaDon);
        }

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
                        where itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate 
                        && itemDV.TenDichVu.Contains(TenDichVu)
                        orderby itemDV.CreateDate ascending
                        select new
                        {
                            itemDV.SoHoaDon,
                            itemDV.SoTien,
                            itemDV.Phi,
                            itemDV.TenDichVu,
                            itemDV.CreateDate,
                            itemHD.NGAYGIAITRACH,
                            itemHD.DangNgan_ChuyenKhoan,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi=itemHD.SO+" "+itemHD.DUONG,
                            GiaBieu=itemHD.GB,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(string TenDichVu, DateTime FromCreateDate, DateTime ToCreateDate,int FromDot,int ToDot)
        {
            var query = from itemDV in _db.TT_DichVuThus
                        join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate
                        && itemDV.TenDichVu.Contains(TenDichVu) && itemHD.DOT.Value >= FromDot && itemHD.DOT.Value <= ToDot
                        orderby itemDV.CreateDate ascending
                        select new
                        {
                            itemDV.SoHoaDon,
                            itemDV.SoTien,
                            itemDV.Phi,
                            itemDV.TenDichVu,
                            itemDV.CreateDate,
                            itemHD.NGAYGIAITRACH,
                            itemHD.DangNgan_ChuyenKhoan,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
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
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                            && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
                        orderby itemDV.CreateDate ascending
                        select new
                        {
                            itemDV.SoHoaDon,
                            itemDV.SoTien,
                            itemDV.Phi,
                            itemDV.TenDichVu,
                            itemDV.CreateDate,
                            itemHD.NGAYGIAITRACH,
                            itemHD.DangNgan_ChuyenKhoan,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(int MaTo, string TenDichVu, DateTime FromCreateDate, DateTime ToCreateDate, int FromDot, int ToDot)
        {
            var query = from itemDV in _db.TT_DichVuThus
                        join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                            && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
                            && itemHD.DOT.Value >= FromDot && itemHD.DOT.Value <= ToDot
                        orderby itemDV.CreateDate ascending
                        select new
                        {
                            itemDV.SoHoaDon,
                            itemDV.SoTien,
                            itemDV.Phi,
                            itemDV.TenDichVu,
                            itemDV.CreateDate,
                            itemHD.NGAYGIAITRACH,
                            itemHD.DangNgan_ChuyenKhoan,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                        };
            return LINQToDataTable(query);
        }
        
        public DataTable GetDS_NV(int MaNV_HanhThu, string TenDichVu, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            DataTable dt=new DataTable();
            var query = from itemDV in _db.TT_DichVuThus
                        join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.MaNV_HanhThu == MaNV_HanhThu
                            && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
                        select new
                        {
                            itemDV.SoHoaDon,
                            itemDV.SoTien,
                            itemDV.Phi,
                            itemDV.TenDichVu,
                            itemDV.CreateDate,
                            itemHD.NGAYGIAITRACH,
                            itemHD.DangNgan_ChuyenKhoan,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                        };
            dt=LINQToDataTable(query);

            var queryDN = from itemDV in _db.TT_DichVuThus
                          join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
                          join itemCTDN in _db.TT_CTDongNuocs on itemDV.SoHoaDon equals itemCTDN.SoHoaDon
                          join itemND in _db.TT_NguoiDungs on itemCTDN.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
                          from itemtableND in tableND.DefaultIfEmpty()
                          where itemCTDN.TT_DongNuoc.MaNV_DongNuoc == MaNV_HanhThu
                            && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
                          select new
                          {
                              itemDV.SoHoaDon,
                              itemDV.SoTien,
                              itemDV.Phi,
                              itemDV.TenDichVu,
                              itemDV.CreateDate,
                              itemHD.NGAYGIAITRACH,
                              itemHD.DangNgan_ChuyenKhoan,
                              Ky = itemHD.KY + "/" + itemHD.NAM,
                              MLT = itemHD.MALOTRINH,
                              DanhBo = itemHD.DANHBA,
                              HoTen = itemHD.TENKH,
                              DiaChi = itemHD.SO + " " + itemHD.DUONG,
                              GiaBieu = itemHD.GB,
                              HanhThu = itemtableND.HoTen,
                              To = itemtableND.TT_To.TenTo,
                          };
            dt.Merge(LINQToDataTable(queryDN));
            dt.DefaultView.Sort = "CreateDate ASC";
            dt = dt.DefaultView.ToTable();

            return dt;
        }

        public DataTable GetDS_NV(int MaNV_HanhThu, string TenDichVu, DateTime FromCreateDate, DateTime ToCreateDate, int FromDot, int ToDot)
        {
            DataTable dt = new DataTable();
            var query = from itemDV in _db.TT_DichVuThus
                        join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.MaNV_HanhThu == MaNV_HanhThu
                            && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
                            && itemHD.DOT.Value >= FromDot && itemHD.DOT.Value <= ToDot
                        select new
                        {
                            itemDV.SoHoaDon,
                            itemDV.SoTien,
                            itemDV.Phi,
                            itemDV.TenDichVu,
                            itemDV.CreateDate,
                            itemHD.NGAYGIAITRACH,
                            itemHD.DangNgan_ChuyenKhoan,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                        };
            dt = LINQToDataTable(query);

            var queryDN = from itemDV in _db.TT_DichVuThus
                          join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
                          join itemCTDN in _db.TT_CTDongNuocs on itemDV.SoHoaDon equals itemCTDN.SoHoaDon
                          join itemND in _db.TT_NguoiDungs on itemCTDN.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
                          from itemtableND in tableND.DefaultIfEmpty()
                          where itemCTDN.TT_DongNuoc.MaNV_DongNuoc == MaNV_HanhThu
                            && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
                            && itemHD.DOT.Value >= FromDot && itemHD.DOT.Value <= ToDot
                          select new
                          {
                              itemDV.SoHoaDon,
                              itemDV.SoTien,
                              itemDV.Phi,
                              itemDV.TenDichVu,
                              itemDV.CreateDate,
                              itemHD.NGAYGIAITRACH,
                              itemHD.DangNgan_ChuyenKhoan,
                              Ky = itemHD.KY + "/" + itemHD.NAM,
                              MLT = itemHD.MALOTRINH,
                              DanhBo = itemHD.DANHBA,
                              HoTen = itemHD.TENKH,
                              DiaChi = itemHD.SO + " " + itemHD.DUONG,
                              GiaBieu = itemHD.GB,
                              HanhThu = itemtableND.HoTen,
                              To = itemtableND.TT_To.TenTo,
                          };
            dt.Merge(LINQToDataTable(queryDN));
            dt.DefaultView.Sort = "CreateDate ASC";
            dt = dt.DefaultView.ToTable();

            return dt;
        }
    }
}

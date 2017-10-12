using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ThuTien.LinQ;

namespace ThuTien.DAL.ChuyenKhoan
{
    class CDichVuThu : CDAL
    {
        public TT_DichVuThu Get(string SoHoaDon)
        {
            return _db.TT_DichVuThus.SingleOrDefault(item => item.SoHoaDon == SoHoaDon);
        }

        public bool CheckExist(string SoHoaDon)
        {
            return _db.TT_DichVuThus.Any(item => item.SoHoaDon == SoHoaDon);
        }

        public bool Xoa(TT_DichVuThu dvt)
        {
            try
            {
                _db.TT_DichVuThus.DeleteOnSubmit(dvt);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable GetDichVuThu()
        {
            return LINQToDataTable(_db.ViewGetDichVuThus.OrderBy(item => item.TenDichVu));
        }

        public DataTable GetDS(string DanhBo)
        {
            var query = from itemDV in _db.TT_DichVuThus
                        join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                        from itemtableDN in tableDN.DefaultIfEmpty()
                        where itemDV.DanhBo == DanhBo
                        orderby itemDV.CreateDate ascending
                        select new
                        {
                            itemDV.SoHoaDon,
                            itemDV.SoTien,
                            itemDV.Phi,
                            itemDV.TenDichVu,
                            itemDV.CreateDate,
                            itemHD.NGAYGIAITRACH,
                            itemHD.DangNgan_Quay,
                            itemHD.DangNgan_ChuyenKhoan,
                            itemHD.TIEUTHU,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            DangNgan = itemtableDN.HoTen,
                        };
            return LINQToDataTable(query);
            //string sql = "select dvt.SoHoaDon,dvt.SoTien,dvt.Phi,dvt.TenDichVu,dvt.CreateDate,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,"
            //            + " hd.TIEUTHU,Ky=convert(varchar(2),hd.KY) +'/'+convert(varchar(4),hd.NAM),MLT=hd.MALOTRINH,DanhBo=hd.DANHBA,HoTen=hd.TENKH,"
            //            + " DiaChi=hd.SO+' '+hd.DUONG,GiaBieu=hd.GB,HanhThu=hanhthu.HoTen,'To'=(select TenTo from TT_To where MaTo=hanhthu.MaTo),DangNgan=dangngan.HoTen"
            //            + " from TT_DichVuThu dvt,HOADON hd"
            //            + " left join TT_NguoiDung hanhthu on hd.MaNV_HanhThu=hanhthu.MaND"
            //            + " left join TT_NguoiDung dangngan on hd.MaNV_DangNgan=dangngan.MaND"
            //            + " where dvt.SoHoaDon=hd.SOHOADON and dvt.DanhBo='"+DanhBo+"'"
            //            + " order by dvt.CreateDate desc";
            //return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetDS(string TenDichVu, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from itemDV in _db.TT_DichVuThus
                        join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                        from itemtableDN in tableDN.DefaultIfEmpty()
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
                            itemHD.DangNgan_Quay,
                            itemHD.DangNgan_ChuyenKhoan,
                            itemHD.TIEUTHU,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
                            HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND=>itemND.MaND== _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
                            //To = itemtableND.TT_To.TenTo,
                            To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
                            DangNgan = itemtableDN.HoTen,
                            DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon&&item.TT_DongNuoc.Huy==false),
                            LenhHuy=_db.TT_LenhHuys.Any(item=>item.SoHoaDon==itemDV.SoHoaDon),
                        };
            return LINQToDataTable(query);
            //string sql = "select dvt.SoHoaDon,dvt.SoTien,dvt.Phi,dvt.TenDichVu,dvt.CreateDate,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,"
            //            + " hd.TIEUTHU,Ky=convert(varchar(2),hd.KY) +'/'+convert(varchar(4),hd.NAM),MLT=hd.MALOTRINH,DanhBo=hd.DANHBA,HoTen=hd.TENKH,"
            //            + " DiaChi=hd.SO+' '+hd.DUONG,GiaBieu=hd.GB,HanhThu=hanhthu.HoTen,'To'=(select TenTo from TT_To where MaTo=hanhthu.MaTo),DangNgan=dangngan.HoTen"
            //            + " from TT_DichVuThu dvt,HOADON hd"
            //            + " left join TT_NguoiDung hanhthu on hd.MaNV_HanhThu=hanhthu.MaND"
            //            + " left join TT_NguoiDung dangngan on hd.MaNV_DangNgan=dangngan.MaND"
            //            + " where dvt.SoHoaDon=hd.SOHOADON and dvt.CreateDate>='" + FromCreateDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%'"
            //            + " order by dvt.CreateDate desc";
            //return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetDS(string TenDichVu, DateTime FromCreateDate, DateTime ToCreateDate, int FromDot, int ToDot)
        {
            var query = from itemDV in _db.TT_DichVuThus
                        join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                        from itemtableDN in tableDN.DefaultIfEmpty()
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
                            itemHD.DangNgan_Quay,
                            itemHD.DangNgan_ChuyenKhoan,
                            itemHD.TIEUTHU,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            DangNgan = itemtableDN.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(int MaTo, string TenDichVu, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from itemDV in _db.TT_DichVuThus
                        join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                        from itemtableDN in tableDN.DefaultIfEmpty()
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
                            itemHD.DangNgan_Quay,
                            itemHD.DangNgan_ChuyenKhoan,
                            itemHD.TIEUTHU,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            DangNgan = itemtableDN.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(int MaTo, string TenDichVu, DateTime FromCreateDate, DateTime ToCreateDate, int FromDot, int ToDot)
        {
            var query = from itemDV in _db.TT_DichVuThus
                        join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                        from itemtableDN in tableDN.DefaultIfEmpty()
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
                            itemHD.DangNgan_Quay,
                            itemHD.DangNgan_ChuyenKhoan,
                            itemHD.TIEUTHU,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            DangNgan = itemtableDN.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS_NV(int MaNV_HanhThu, string TenDichVu, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            DataTable dt = new DataTable();
            var query = from itemDV in _db.TT_DichVuThus
                        join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                        from itemtableDN in tableDN.DefaultIfEmpty()
                        where itemHD.MaNV_HanhThu == MaNV_HanhThu
                            && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
                            && !(from itemCTDN in _db.TT_CTDongNuocs where itemCTDN.TT_DongNuoc.Huy == false select itemCTDN.SoHoaDon).Contains(itemHD.SOHOADON)
                        select new
                        {
                            itemDV.SoHoaDon,
                            itemDV.SoTien,
                            itemDV.Phi,
                            itemDV.TenDichVu,
                            itemDV.CreateDate,
                            itemHD.NGAYGIAITRACH,
                            itemHD.DangNgan_Quay,
                            itemHD.DangNgan_ChuyenKhoan,
                            itemHD.TIEUTHU,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            DangNgan = itemtableDN.HoTen,
                        };
            dt = LINQToDataTable(query);

            var queryDN = from itemDV in _db.TT_DichVuThus
                          join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
                          join itemCTDN in _db.TT_CTDongNuocs on itemDV.SoHoaDon equals itemCTDN.SoHoaDon
                          join itemND in _db.TT_NguoiDungs on itemCTDN.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
                          from itemtableND in tableND.DefaultIfEmpty()
                          join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                          from itemtableDN in tableDN.DefaultIfEmpty()
                          where itemCTDN.TT_DongNuoc.MaNV_DongNuoc == MaNV_HanhThu && itemCTDN.TT_DongNuoc.Huy == false
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
                              DangNgan = itemtableDN.HoTen,
                          };
            dt.Merge(LINQToDataTable(queryDN));
            if (dt.Rows.Count > 0)
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
                        join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                        from itemtableDN in tableDN.DefaultIfEmpty()
                        where itemHD.MaNV_HanhThu == MaNV_HanhThu
                            && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
                            && itemHD.DOT.Value >= FromDot && itemHD.DOT.Value <= ToDot
                            && !(from itemCTDN in _db.TT_CTDongNuocs where itemCTDN.TT_DongNuoc.Huy == false select itemCTDN.SoHoaDon).Contains(itemHD.SOHOADON)
                        select new
                        {
                            itemDV.SoHoaDon,
                            itemDV.SoTien,
                            itemDV.Phi,
                            itemDV.TenDichVu,
                            itemDV.CreateDate,
                            itemHD.NGAYGIAITRACH,
                            itemHD.DangNgan_Quay,
                            itemHD.DangNgan_ChuyenKhoan,
                            itemHD.TIEUTHU,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            DangNgan = itemtableDN.HoTen,
                        };
            dt = LINQToDataTable(query);

            var queryDN = from itemDV in _db.TT_DichVuThus
                          join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
                          join itemCTDN in _db.TT_CTDongNuocs on itemDV.SoHoaDon equals itemCTDN.SoHoaDon
                          join itemND in _db.TT_NguoiDungs on itemCTDN.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
                          from itemtableND in tableND.DefaultIfEmpty()
                          join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                          from itemtableDN in tableDN.DefaultIfEmpty()
                          where itemCTDN.TT_DongNuoc.MaNV_DongNuoc == MaNV_HanhThu && itemCTDN.TT_DongNuoc.Huy == false
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
                              DangNgan = itemtableDN.HoTen,
                          };
            dt.Merge(LINQToDataTable(queryDN));
            if (dt.Rows.Count > 0)
                dt.DefaultView.Sort = "CreateDate ASC";
            dt = dt.DefaultView.ToTable();

            return dt;
        }

        public DataTable GetDS_PGD(int Nam, int Ky)
        {
            var query = from itemDV in _db.TT_DichVuThus
                        join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                        from itemtableDN in tableDN.DefaultIfEmpty()
                        where itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DangNgan_ChuyenKhoan == false
                        orderby itemDV.CreateDate ascending
                        select new
                        {
                            itemDV.SoHoaDon,
                            itemDV.SoTien,
                            itemDV.Phi,
                            itemDV.TenDichVu,
                            itemDV.CreateDate,
                            itemHD.NGAYGIAITRACH,
                            itemHD.DangNgan_Quay,
                            itemHD.DangNgan_ChuyenKhoan,
                            itemHD.TIEUTHU,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            DangNgan = itemtableDN.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS_PGD(int Nam, int Ky, int Dot)
        {
            var query = from itemDV in _db.TT_DichVuThus
                        join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                        from itemtableDN in tableDN.DefaultIfEmpty()
                        where itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot && itemHD.DangNgan_ChuyenKhoan == false
                        orderby itemDV.CreateDate ascending
                        select new
                        {
                            itemDV.SoHoaDon,
                            itemDV.SoTien,
                            itemDV.Phi,
                            itemDV.TenDichVu,
                            itemDV.CreateDate,
                            itemHD.NGAYGIAITRACH,
                            itemHD.DangNgan_Quay,
                            itemHD.DangNgan_ChuyenKhoan,
                            itemHD.TIEUTHU,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            DangNgan = itemtableDN.HoTen,
                        };
            return LINQToDataTable(query);
        }

    }
}

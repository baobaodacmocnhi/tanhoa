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
                            DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
                            LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
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
                            //HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND=>itemND.MaND== _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            //To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
                            DangNgan = itemtableDN.HoTen,
                            DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
                            LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
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
                            DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
                            LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(string TenDichVu, int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
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
                            DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
                            LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(string TenDichVu, int MaTo, DateTime FromCreateDate, DateTime ToCreateDate, int FromDot, int ToDot)
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
                            DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
                            LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(string TenDichVu, int MaTo, int Nam)
        {
            string sql = "declare @MaTo int;"
                    + " set @MaTo=" + MaTo + ";"
                    + " select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=DANHBA,HoTen=TENKH,"
                    + " DiaChi=SO+' '+DUONG,NGAYGIAITRACH,'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),"
                    + " SoTien,TenDichVu,dvt.CreateDate"
                    + " from TT_DichVuThu dvt,HOADON hd"
                    + " where dvt.Nam=" + Nam + " and dvt.TenDichVu like '%" + TenDichVu + "%' and hd.ID_HOADON=dvt.MaHD"
                    + " and MAY>=(select TuCuonGCS from TT_To where MaTo=@MaTo) and MAY<=(select DenCuonGCS from TT_To where MaTo=@MaTo) and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " order by MALOTRINH asc";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetDS(string TenDichVu, int MaTo, int Nam, int Ky)
        {
            string sql = "declare @MaTo int;"
                    + " set @MaTo=" + MaTo + ";"
                    + " select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=DANHBA,HoTen=TENKH,"
                    + " DiaChi=SO+' '+DUONG,NGAYGIAITRACH,'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),"
                    + " SoTien,TenDichVu,dvt.CreateDate"
                    + " from TT_DichVuThu dvt,HOADON hd"
                    + " where dvt.Nam=" + Nam + " and dvt.Ky=" + Ky + " and dvt.TenDichVu like '%" + TenDichVu + "%' and hd.ID_HOADON=dvt.MaHD"
                    + " and MAY>=(select TuCuonGCS from TT_To where MaTo=@MaTo) and MAY<=(select DenCuonGCS from TT_To where MaTo=@MaTo) and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " order by MALOTRINH asc";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetBienDongChuyenKhoan(string TenDichVu, int Nam, int Ky)
        {
            string sql = "declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @NamCu int;"
                    + " declare @KyCu int;"
                    + " declare @TenDichVu varchar(20);"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @TenDichVu='" + TenDichVu + "';"
                    + " if @Ky=1"
                    + " begin"
                    + " set @NamCu=@Nam-1;"
                    + " set @KyCu=12;"
                    + " end"
                    + " else"
                    + " begin"
                    + " set @NamCu=@Nam;"
                    + " set @KyCu=@Ky-1;"
                    + " end"
                    + " select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " COUNT(*)-(select TongHDCK=COUNT(*) from TT_DichVuThu dvt,HOADON hd"
                    + " where dvt.Nam=@NamCu and dvt.Ky=@KyCu and dvt.TenDichVu like '%'+@TenDichVu+'%' and hd.ID_HOADON=dvt.MaHD"
                    + " and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " from TT_DichVuThu dvt,HOADON hd"
                    + " where dvt.Nam=@Nam and dvt.Ky=@Ky and dvt.TenDichVu like '%'+@TenDichVu+'%' and hd.ID_HOADON=dvt.MaHD"
                    + " and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetBienDongChuyenKhoan(string TenDichVu, int MaTo, int Nam, int Ky)
        {
            string sql = "declare @MaTo int;"
                    + " declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @NamCu int;"
                    + " declare @KyCu int;"
                    + " declare @TenDichVu varchar(20);"
                    + " set @MaTo=" + MaTo + ";"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @TenDichVu='" + TenDichVu + "';"
                    + " if @Ky=1"
                    + " begin"
                    + " set @NamCu=@Nam-1;"
                    + " set @KyCu=12;"
                    + " end"
                    + " else"
                    + " begin"
                    + " set @NamCu=@Nam;"
                    + " set @KyCu=@Ky-1;"
                    + " end"
                    + " select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " COUNT(*)-(select TongHDCK=COUNT(*) from TT_DichVuThu dvt,HOADON hd"
                    + " where dvt.Nam=@NamCu and dvt.Ky=@KyCu and dvt.TenDichVu like '%'+@TenDichVu+'%' and hd.ID_HOADON=dvt.MaHD"
                    + " and MAY>=(select TuCuonGCS from TT_To where MaTo=@MaTo) and MAY<=(select DenCuonGCS from TT_To where MaTo=@MaTo) and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " from TT_DichVuThu dvt,HOADON hd"
                    + " where dvt.Nam=@Nam and dvt.Ky=@Ky and dvt.TenDichVu like '%'+@TenDichVu+'%' and hd.ID_HOADON=dvt.MaHD"
                    + " and MAY>=(select TuCuonGCS from TT_To where MaTo=@MaTo) and MAY<=(select DenCuonGCS from TT_To where MaTo=@MaTo) and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetBienDongChuyenKhoan_NV(string TenDichVu, int MaNV_HanhThu, int Nam, int Ky)
        {
            string sql = "declare @MaNV_HanhThu int;"
                    + " declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @NamCu int;"
                    + " declare @KyCu int;"
                    + " declare @TenDichVu varchar(20);"
                    + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @TenDichVu='" + TenDichVu + "';"
                    + " if @Ky=1"
                    + " begin"
                    + " set @NamCu=@Nam-1;"
                    + " set @KyCu=12;"
                    + " end"
                    + " else"
                    + " begin"
                    + " set @NamCu=@Nam;"
                    + " set @KyCu=@Ky-1;"
                    + " end"
                    + " select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " COUNT(*)-(select TongHDCK=COUNT(*) from TT_DichVuThu dvt,HOADON hd"
                    + " where dvt.Nam=@NamCu and dvt.Ky=@KyCu and dvt.TenDichVu like '%'+@TenDichVu+'%' and hd.ID_HOADON=dvt.MaHD"
                    + " and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " from TT_DichVuThu dvt,HOADON hd"
                    + " where dvt.Nam=@Nam and dvt.Ky=@Ky and dvt.TenDichVu like '%'+@TenDichVu+'%' and hd.ID_HOADON=dvt.MaHD"
                    + " and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetDS(string TenDichVu, int MaTo, int Nam, int Ky, int FromDot, int ToDot)
        {
            string sql = "declare @MaTo int;"
                    + " set @MaTo=" + MaTo + ";"
                    + " select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=DANHBA,HoTen=TENKH,"
                    + " DiaChi=SO+' '+DUONG,NGAYGIAITRACH,'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),"
                    + " SoTien,TenDichVu,dvt.CreateDate"
                    + " from TT_DichVuThu dvt,HOADON hd"
                    + " where dvt.Nam=" + Nam + " and dvt.Ky=" + Ky + " and dvt.TenDichVu like '%" + TenDichVu + "%' and hd.ID_HOADON=dvt.MaHD"
                    + " and MAY>=(select TuCuonGCS from TT_To where MaTo=@MaTo) and MAY<=(select DenCuonGCS from TT_To where MaTo=@MaTo) and DOT=>" + FromDot + " and DOT<=" + ToDot + " and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " order by MALOTRINH asc";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetDS_NV(string TenDichVu, int MaNV_HanhThu, int Nam)
        {
            string sql = "declare @MaNV_HanhThu int;"
                    + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                    + " select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=DANHBA,HoTen=TENKH,"
                    + " DiaChi=SO+' '+DUONG,NGAYGIAITRACH,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=MaNV_HanhThu)),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),"
                    + " SoTien,TenDichVu,dvt.CreateDate"
                    + " from TT_DichVuThu dvt,HOADON hd"
                    + " where dvt.Nam=" + Nam + " and dvt.TenDichVu like '%" + TenDichVu + "%' and hd.ID_HOADON=dvt.MaHD"
                    + " and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " order by MALOTRINH asc";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetDS_NV(string TenDichVu, int MaNV_HanhThu, int Nam, int Ky)
        {
            string sql = "declare @MaNV_HanhThu int;"
                    + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                    + " select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=DANHBA,HoTen=TENKH,"
                    + " DiaChi=SO+' '+DUONG,NGAYGIAITRACH,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=MaNV_HanhThu)),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),"
                    + " SoTien,TenDichVu,dvt.CreateDate"
                    + " from TT_DichVuThu dvt,HOADON hd"
                    + " where dvt.Nam=" + Nam + " and dvt.Ky=" + Ky + " and dvt.TenDichVu like '%" + TenDichVu + "%' and hd.ID_HOADON=dvt.MaHD"
                    + " and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " order by MALOTRINH asc";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetDS_NV(string TenDichVu, int MaNV_HanhThu, int Nam, int Ky, int FromDot, int ToDot)
        {
            string sql = "declare @MaNV_HanhThu int;"
                    + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                    + " select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=DANHBA,HoTen=TENKH,"
                    + " DiaChi=SO+' '+DUONG,NGAYGIAITRACH,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=MaNV_HanhThu)),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),"
                    + " SoTien,TenDichVu,dvt.CreateDate"
                    + " from TT_DichVuThu dvt,HOADON hd"
                    + " where dvt.Nam=" + Nam + " and dvt.Ky=" + Ky + " and dvt.TenDichVu like '%" + TenDichVu + "%' and hd.ID_HOADON=dvt.MaHD"
                    + " and MaNV_HanhThu=@MaNV_HanhThu and DOT=>" + FromDot + " and DOT<=" + ToDot + " and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " order by MALOTRINH asc";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetDS_NV(string TenDichVu, int MaNV_HanhThu, DateTime FromCreateDate, DateTime ToCreateDate)
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
                            DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
                            LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
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
                              DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
                              LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
                          };
            dt.Merge(LINQToDataTable(queryDN));
            if (dt.Rows.Count > 0)
                dt.DefaultView.Sort = "CreateDate ASC";
            dt = dt.DefaultView.ToTable();

            return dt;
        }

        public DataTable GetDS_NV(string TenDichVu, int MaNV_HanhThu, DateTime FromCreateDate, DateTime ToCreateDate, int FromDot, int ToDot)
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
                            DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
                            LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
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
                              DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
                              LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
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

        public DataTable GetPhanTichChuyenKhoan(string DichVuThu, int MaTo, int Nam)
        {
            string sql = "declare @Nam int;"
                     + " declare @MaTo int;"
                     + " declare @TuCuonGCS int;"
                     + " declare @DenCuonGCS int;"
                     + " set @Nam=" + Nam + ";"
                     + " set @MaTo=" + MaTo + ";"
                     + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                     + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                     + " select MaTo=@MaTo,TenTo=(select TenTo from TT_To where MaTo=@MaTo),TongHD=MAX(t1.TongHD),TongHDCK=MAX(t1.TongHDCK),TongGiaBanCK=MAX(t1.TongGiaBanCK),TongCongCK=MAX(t1.TongCongCK)"
                     + " ,TongHDChuaCK=MAX(t1.TongHDChuaCK),TongGiaBanChuaCK=MAX(t1.TongGiaBanChuaCK),TongCongChuaCK=MAX(t1.TongCongChuaCK) from"
                     + " ((select TongHD=COUNT(ID_HOADON),TongHDCK=0,TongGiaBanCK=0,TongCongCK=0,TongHDChuaCK=0,TongGiaBanChuaCK=0,TongCongChuaCK=0 from HOADON"
                     + " where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS)"
                     + " union"
                     + " (select TongHD=0,TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG),TongHDChuaCK=0,TongGiaBanChuaCK=0,TongCongChuaCK=0 from HOADON hd,TT_DichVuThu dvt"
                     + " where hd.ID_HOADON=dvt.MaHD and hd.NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=1 and TenDichVu like '%" + DichVuThu + "%')"
                     + " union"
                     + " (select TongHD=0,TongHDCK=0,TongGiaBanCK=0,TongCongCK=0,TongHDChuaCK=COUNT(ID_HOADON),TongGiaBanChuaCK=SUM(GIABAN),TongCongChuaCK=SUM(TONGCONG) from HOADON"
                     + " where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=0))t1";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetPhanTichChuyenKhoan(string DichVuThu, int MaTo, int Nam, int Ky)
        {
            string sql = "declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @MaTo int;"
                    + " declare @TuCuonGCS int;"
                    + " declare @DenCuonGCS int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @MaTo=" + MaTo + ";"
                    + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                    + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                    + " select MaTo=@MaTo,TenTo=(select TenTo from TT_To where MaTo=@MaTo),TongHD=MAX(t1.TongHD),TongHDCK=MAX(t1.TongHDCK),TongGiaBanCK=MAX(t1.TongGiaBanCK),TongCongCK=MAX(t1.TongCongCK)"
                    + " ,TongHDChuaCK=MAX(t1.TongHDChuaCK),TongGiaBanChuaCK=MAX(t1.TongGiaBanChuaCK),TongCongChuaCK=MAX(t1.TongCongChuaCK) from"
                    + " ((select TongHD=COUNT(ID_HOADON),TongHDCK=0,TongGiaBanCK=0,TongCongCK=0,TongHDChuaCK=0,TongGiaBanChuaCK=0,TongCongChuaCK=0 from HOADON"
                    + " where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS)"
                    + " union"
                    + " (select TongHD=0,TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG),TongHDChuaCK=0,TongGiaBanChuaCK=0,TongCongChuaCK=0 from HOADON hd,TT_DichVuThu dvt"
                    + " where hd.ID_HOADON=dvt.MaHD and hd.NAM=@Nam and hd.KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=1 and TenDichVu like '%" + DichVuThu + "%')"
                    + " union"
                    + " (select TongHD=0,TongHDCK=0,TongGiaBanCK=0,TongCongCK=0,TongHDChuaCK=COUNT(ID_HOADON),TongGiaBanChuaCK=SUM(GIABAN),TongCongChuaCK=SUM(TONGCONG) from HOADON"
                    + " where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=0))t1";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetPhanTichChuyenKhoan(string DichVuThu, int MaTo, int Nam, DateTime NgayGiaiTrach)
        {
            string sql = "declare @Nam int;"
                     + " declare @MaTo int;"
                     + " declare @NgayGiaiTrach date;"
                     + " declare @TuCuonGCS int;"
                     + " declare @DenCuonGCS int;"
                     + " set @Nam=" + Nam + ";"
                     + " set @MaTo=" + MaTo + ";"
                     + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyy-MM-dd") + "';"
                     + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                     + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                     + " select MaTo=@MaTo,TenTo=(select TenTo from TT_To where MaTo=@MaTo),TongHD=MAX(t1.TongHD),TongHDCK=MAX(t1.TongHDCK),TongGiaBanCK=MAX(t1.TongGiaBanCK),TongCongCK=MAX(t1.TongCongCK)"
                     + " ,TongHDChuaCK=MAX(t1.TongHDChuaCK),TongGiaBanChuaCK=MAX(t1.TongGiaBanChuaCK),TongCongChuaCK=MAX(t1.TongCongChuaCK) from"
                     + " ((select TongHD=COUNT(ID_HOADON),TongHDCK=0,TongGiaBanCK=0,TongCongCK=0,TongHDChuaCK=0,TongGiaBanChuaCK=0,TongCongChuaCK=0 from HOADON"
                     + " where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS)"
                     + " union"
                     + " (select TongHD=0,TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG),TongHDChuaCK=0,TongGiaBanChuaCK=0,TongCongChuaCK=0 from HOADON hd,TT_DichVuThu dvt"
                     + " where hd.ID_HOADON=dvt.MaHD and hd.NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                     + " and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1 and TenDichVu like '%" + DichVuThu + "%')"
                     + " union"
                     + " (select TongHD=0,TongHDCK=0,TongGiaBanCK=0,TongCongCK=0,TongHDChuaCK=COUNT(ID_HOADON),TongGiaBanChuaCK=SUM(GIABAN),TongCongChuaCK=SUM(TONGCONG) from HOADON"
                     + " where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=0))t1";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetPhanTichChuyenKhoan(string DichVuThu, int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            string sql = "declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @MaTo int;"
                    + " declare @NgayGiaiTrach date;"
                    + " declare @TuCuonGCS int;"
                    + " declare @DenCuonGCS int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @MaTo=" + MaTo + ";"
                    + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyy-MM-dd") + "';"
                    + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                    + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                    + " select MaTo=@MaTo,TenTo=(select TenTo from TT_To where MaTo=@MaTo),TongHD=MAX(t1.TongHD),TongHDCK=MAX(t1.TongHDCK),TongGiaBanCK=MAX(t1.TongGiaBanCK),TongCongCK=MAX(t1.TongCongCK)"
                    + " ,TongHDChuaCK=MAX(t1.TongHDChuaCK),TongGiaBanChuaCK=MAX(t1.TongGiaBanChuaCK),TongCongChuaCK=MAX(t1.TongCongChuaCK) from"
                    + " ((select TongHD=COUNT(ID_HOADON),TongHDCK=0,TongGiaBanCK=0,TongCongCK=0,TongHDChuaCK=0,TongGiaBanChuaCK=0,TongCongChuaCK=0 from HOADON"
                    + " where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS)"
                    + " union"
                    + " (select TongHD=0,TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG),TongHDChuaCK=0,TongGiaBanChuaCK=0,TongCongChuaCK=0 from HOADON hd,TT_DichVuThu dvt"
                    + " where hd.ID_HOADON=dvt.MaHD and hd.NAM=@Nam and hd.KY=@Ky and MAY>=@TuCuonGCS"
                    + " and MAY<=@DenCuonGCS and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1 and TenDichVu like '%" + DichVuThu + "%')"
                    + " union"
                    + " (select TongHD=0,TongHDCK=0,TongGiaBanCK=0,TongCongCK=0,TongHDChuaCK=COUNT(ID_HOADON),TongGiaBanChuaCK=SUM(GIABAN),TongCongChuaCK=SUM(TONGCONG) from HOADON"
                    + " where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=0))t1";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetPhanTichChuyenKhoan_NV(string DichVuThu, int MaTo, int Nam)
        {
            string sql = "declare @Nam int;"
                    + " declare @MaTo int;"
                    + " declare @TuCuonGCS int;"
                    + " declare @DenCuonGCS int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @MaTo=" + MaTo + ";"
                    + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                    + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                    + " select *,HoTen=(select HoTen from TT_NguoiDung where MaND=ck.MaNV_HanhThu) from"
                    + " (select MaNV_HanhThu,TongHD=COUNT(ID_HOADON) from HOADON"
                    + " where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                    + " group by MaNV_HanhThu)hd"
                    + " left join"
                    + " (select MaNV_HanhThu,TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd,TT_DichVuThu dvt"
                    + " where hd.ID_HOADON=dvt.MaHD and hd.NAM=@Nam and DangNgan_ChuyenKhoan=1 and TenDichVu like '%" + DichVuThu + "%'"
                    + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and NGAYGIAITRACH is not null"
                    + " group by MaNV_HanhThu)ck on ck.MaNV_HanhThu=hd.MaNV_HanhThu"
                    + " left join"
                    + " (select MaNV_HanhThu,TongHDChuaCK=COUNT(ID_HOADON),TongGiaBanChuaCK=SUM(GIABAN),TongCongChuaCK=SUM(TONGCONG) from HOADON"
                    + " where NAM=@Nam and DangNgan_ChuyenKhoan=0"
                    + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and NGAYGIAITRACH is not null"
                    + " group by MaNV_HanhThu)chuack on chuack.MaNV_HanhThu=hd.MaNV_HanhThu"
                    + " order by ck.MaNV_HanhThu";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetPhanTichChuyenKhoan_NV(string DichVuThu, int MaTo, int Nam, int Ky)
        {
            string sql = "declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @MaTo int;"
                    + " declare @TuCuonGCS int;"
                    + " declare @DenCuonGCS int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @MaTo=" + MaTo + ";"
                    + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                    + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                    + " select *,HoTen=(select HoTen from TT_NguoiDung where MaND=ck.MaNV_HanhThu) from"
                    + " (select MaNV_HanhThu,TongHD=COUNT(ID_HOADON) from HOADON"
                    + " where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                    + " group by MaNV_HanhThu)hd"
                    + " left join"
                    + " (select MaNV_HanhThu,TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd,TT_DichVuThu dvt"
                    + " where hd.ID_HOADON=dvt.MaHD and hd.NAM=@Nam and hd.KY=@Ky and DangNgan_ChuyenKhoan=1 and TenDichVu like '%" + DichVuThu + "%'"
                    + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and NGAYGIAITRACH is not null"
                    + " group by MaNV_HanhThu)ck on ck.MaNV_HanhThu=hd.MaNV_HanhThu"
                    + " left join"
                    + " (select MaNV_HanhThu,TongHDChuaCK=COUNT(ID_HOADON),TongGiaBanChuaCK=SUM(GIABAN),TongCongChuaCK=SUM(TONGCONG) from HOADON"
                    + " where NAM=@Nam and KY=@Ky and DangNgan_ChuyenKhoan=0"
                    + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and NGAYGIAITRACH is not null"
                    + " group by MaNV_HanhThu)chuack on chuack.MaNV_HanhThu=hd.MaNV_HanhThu"
                    + " order by ck.MaNV_HanhThu";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetPhanTichChuyenKhoan_NV(string DichVuThu, int MaTo, int Nam, DateTime NgayGiaiTrach)
        {
            string sql = "declare @Nam int;"
                    + " declare @MaTo int;"
                    + " declare @NgayGiaiTrach date;"
                    + " declare @TuCuonGCS int;"
                    + " declare @DenCuonGCS int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @MaTo=" + MaTo + ";"
                    + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyy-MM-dd") + "';"
                    + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                    + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                    + " select *,HoTen=(select HoTen from TT_NguoiDung where MaND=ck.MaNV_HanhThu) from"
                    + " (select MaNV_HanhThu,TongHD=COUNT(ID_HOADON) from HOADON"
                    + " where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                    + " group by MaNV_HanhThu)hd"
                    + " left join"
                    + " (select MaNV_HanhThu,TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd,TT_DichVuThu dvt"
                    + " where hd.ID_HOADON=dvt.MaHD and hd.NAM=@Nam and DangNgan_ChuyenKhoan=1 and TenDichVu like '%" + DichVuThu + "%'"
                    + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach"
                    + " group by MaNV_HanhThu)ck on ck.MaNV_HanhThu=hd.MaNV_HanhThu"
                    + " left join"
                    + " (select MaNV_HanhThu,TongHDChuaCK=COUNT(ID_HOADON),TongGiaBanChuaCK=SUM(GIABAN),TongCongChuaCK=SUM(TONGCONG) from HOADON"
                    + " where NAM=@Nam and DangNgan_ChuyenKhoan=0"
                    + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach"
                    + " group by MaNV_HanhThu)chuack on chuack.MaNV_HanhThu=hd.MaNV_HanhThu"
                    + " order by ck.MaNV_HanhThu";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetPhanTichChuyenKhoan_NV(string DichVuThu, int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            string sql = "declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @MaTo int;"
                    + " declare @NgayGiaiTrach date;"
                    + " declare @TuCuonGCS int;"
                    + " declare @DenCuonGCS int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @MaTo=" + MaTo + ";"
                    + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyy-MM-dd") + "';"
                    + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                    + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                    + " select *,HoTen=(select HoTen from TT_NguoiDung where MaND=ck.MaNV_HanhThu) from"
                    + " (select MaNV_HanhThu,TongHD=COUNT(ID_HOADON) from HOADON"
                    + " where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                    + " group by MaNV_HanhThu)hd"
                    + " left join"
                    + " (select MaNV_HanhThu,TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd,TT_DichVuThu dvt"
                    + " where hd.ID_HOADON=dvt.MaHD and hd.NAM=@Nam and hd.KY=@Ky and DangNgan_ChuyenKhoan=1 and TenDichVu like '%" + DichVuThu + "%'"
                    + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach"
                    + " group by MaNV_HanhThu)ck on ck.MaNV_HanhThu=hd.MaNV_HanhThu"
                    + " left join"
                    + " (select MaNV_HanhThu,TongHDChuaCK=COUNT(ID_HOADON),TongGiaBanChuaCK=SUM(GIABAN),TongCongChuaCK=SUM(TONGCONG) from HOADON"
                    + " where NAM=@Nam and KY=@Ky and DangNgan_ChuyenKhoan=0"
                    + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach"
                    + " group by MaNV_HanhThu)chuack on chuack.MaNV_HanhThu=hd.MaNV_HanhThu"
                    + " order by ck.MaNV_HanhThu";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

    }
}

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

        public DataTable getDS(string DanhBo)
        {
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where itemDV.DanhBo == DanhBo
            //            orderby itemDV.CreateDate ascending
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = itemtableND.HoTen,
            //                To = itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //return LINQToDataTable(query);
            string sql = "select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                        + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                        + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                        + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                        + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                        + " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) then 'true' else 'false' end"
                        + " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD) then 'true' else 'false' end"
                        + " from TT_DichVuThu dvt,HOADON hd where dvt.DanhBo='"+DanhBo+"' and dvt.MaHD=hd.ID_HOADON"
                        + " order by dvt.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

         public DataTable getDS(string TenDichVu, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate
            //            && itemDV.TenDichVu.Contains(TenDichVu)
            //            orderby itemDV.CreateDate ascending
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                //HanhThu = itemtableND.HoTen,
            //                //To = itemtableND.TT_To.TenTo,
            //                To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //return LINQToDataTable(query);
            string sql = "select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                        + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                        + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                        + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                        + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                        + " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                        + " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                        + " from TT_DichVuThu dvt,HOADON hd where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and dvt.MaHD=hd.ID_HOADON"
                        + " order by dvt.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DenKy(string TenDichVu, DateTime FromCreateDate, DateTime ToCreateDate, int Nam, int Ky)
        {
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate
            //            && itemDV.TenDichVu.Contains(TenDichVu) && (itemHD.NAM < Nam ||(itemHD.NAM == Nam&& itemHD.KY <= Ky))
            //            orderby itemDV.CreateDate ascending
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                //HanhThu = itemtableND.HoTen,
            //                //To = itemtableND.TT_To.TenTo,
            //                To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //return LINQToDataTable(query);
            string sql = "select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                        + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                        + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                        + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                        + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                        + " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                        + " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                        + " from TT_DichVuThu dvt,HOADON hd where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and dvt.MaHD=hd.ID_HOADON and (hd.NAM<"+Nam+" or (hd.NAM="+Nam+" and hd.KY<="+Ky+"))"
                        + " order by dvt.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_Dot(string TenDichVu, DateTime FromCreateDate, DateTime ToCreateDate, int FromDot, int ToDot)
        {
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate
            //            && itemDV.TenDichVu.Contains(TenDichVu) && itemHD.DOT.Value >= FromDot && itemHD.DOT.Value <= ToDot
            //            orderby itemDV.CreateDate ascending
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                //HanhThu = itemtableND.HoTen,
            //                //To = itemtableND.TT_To.TenTo,
            //                To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //return LINQToDataTable(query);
            string sql = "select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                        + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                        + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                        + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                        + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                        + " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                        + " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                        + " from TT_DichVuThu dvt,HOADON hd where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and dvt.MaHD=hd.ID_HOADON and hd.DOT>=" + FromDot + " and hd.DOT<=" + ToDot
                        + " order by dvt.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DenKy_Dot(string TenDichVu, DateTime FromCreateDate, DateTime ToCreateDate, int Nam, int Ky, int FromDot, int ToDot)
        {
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate
            //            && itemDV.TenDichVu.Contains(TenDichVu) && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky)) && itemHD.DOT.Value >= FromDot && itemHD.DOT.Value <= ToDot
            //            orderby itemDV.CreateDate ascending
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                //HanhThu = itemtableND.HoTen,
            //                //To = itemtableND.TT_To.TenTo,
            //                To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //return LINQToDataTable(query);
            string sql = "select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                        + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                        + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                        + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                        + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                        + " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                        + " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                        + " from TT_DichVuThu dvt,HOADON hd where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and dvt.MaHD=hd.ID_HOADON and and (hd.NAM<"+Nam+" or (hd.NAM="+Nam+" and hd.KY<="+Ky+")) and hd.DOT>=" + FromDot + " and hd.DOT<=" + ToDot
                        + " order by dvt.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS(string TenDichVu, int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
            //                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
            //                && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
            //            orderby itemDV.CreateDate ascending
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                //HanhThu = itemtableND.HoTen,
            //                //To = itemtableND.TT_To.TenTo,
            //                To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //return LINQToDataTable(query);
            string sql = "select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                        + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                        + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                        + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                        + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                        + " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                        + " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                        + " from TT_DichVuThu dvt,HOADON hd where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and dvt.MaHD=hd.ID_HOADON and hd.MAY>=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ") and hd.MAY<=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " order by dvt.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DenKy(string TenDichVu, int MaTo, DateTime FromCreateDate, DateTime ToCreateDate, int Nam, int Ky)
        {
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
            //                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
            //                && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu) && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky))
            //            orderby itemDV.CreateDate ascending
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                //HanhThu = itemtableND.HoTen,
            //                //To = itemtableND.TT_To.TenTo,
            //                To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //return LINQToDataTable(query);
            string sql = "select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                        + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                        + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                        + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                        + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                        + " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                        + " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                        + " from TT_DichVuThu dvt,HOADON hd where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and dvt.MaHD=hd.ID_HOADON and (hd.NAM<" + Nam + " or (hd.NAM=" + Nam + " and hd.KY<=" + Ky + ")) and hd.MAY>=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ") and hd.MAY<=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " order by dvt.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_Dot(string TenDichVu, int MaTo, DateTime FromCreateDate, DateTime ToCreateDate, int FromDot, int ToDot)
        {
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
            //                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
            //                && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
            //                && itemHD.DOT.Value >= FromDot && itemHD.DOT.Value <= ToDot
            //            orderby itemDV.CreateDate ascending
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                //HanhThu = itemtableND.HoTen,
            //                //To = itemtableND.TT_To.TenTo,
            //                To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //return LINQToDataTable(query);
            string sql = "select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                        + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                        + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                        + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                        + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                        + " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                        + " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                        + " from TT_DichVuThu dvt,HOADON hd where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and dvt.MaHD=hd.ID_HOADON and hd.DOT>=" + FromDot + " and hd.DOT<=" + ToDot + " and hd.MAY>=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ") and hd.MAY<=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " order by dvt.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DenKy_Dot(string TenDichVu, int MaTo, DateTime FromCreateDate, DateTime ToCreateDate, int Nam, int Ky, int FromDot, int ToDot)
        {
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
            //                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
            //                && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
            //                && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky)) && itemHD.DOT.Value >= FromDot && itemHD.DOT.Value <= ToDot
            //            orderby itemDV.CreateDate ascending
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                //HanhThu = itemtableND.HoTen,
            //                //To = itemtableND.TT_To.TenTo,
            //                To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //return LINQToDataTable(query);
            string sql = "select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                        + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                        + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                        + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                        + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                        + " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                        + " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                        + " from TT_DichVuThu dvt,HOADON hd where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and dvt.MaHD=hd.ID_HOADON and (hd.NAM<" + Nam + " or (hd.NAM=" + Nam + " and hd.KY<=" + Ky + ")) and hd.DOT>=" + FromDot + " and hd.DOT<=" + ToDot + " and hd.MAY>=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ") and hd.MAY<=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " order by dvt.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_NV(string TenDichVu, int MaNV_HanhThu, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            //DataTable dt = new DataTable();
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where itemHD.MaNV_HanhThu == MaNV_HanhThu
            //                && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
            //                && !(from itemCTDN in _db.TT_CTDongNuocs where itemCTDN.TT_DongNuoc.Huy == false select itemCTDN.SoHoaDon).Contains(itemHD.SOHOADON)
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                //HanhThu = itemtableND.HoTen,
            //                //To = itemtableND.TT_To.TenTo,
            //                To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //dt = LINQToDataTable(query);

            //var queryDN = from itemDV in _db.TT_DichVuThus
            //              join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //              join itemCTDN in _db.TT_CTDongNuocs on itemDV.SoHoaDon equals itemCTDN.SoHoaDon
            //              join itemND in _db.TT_NguoiDungs on itemCTDN.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
            //              from itemtableND in tableND.DefaultIfEmpty()
            //              join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //              from itemtableDN in tableDN.DefaultIfEmpty()
            //              where itemCTDN.TT_DongNuoc.MaNV_DongNuoc == MaNV_HanhThu && itemCTDN.TT_DongNuoc.Huy == false
            //                && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
            //              select new
            //              {
            //                  itemDV.SoHoaDon,
            //                  itemDV.SoTien,
            //                  Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                  itemDV.TenDichVu,
            //                  itemDV.CreateDate,
            //                  itemHD.NGAYGIAITRACH,
            //                  itemHD.DangNgan_ChuyenKhoan,
            //                  Ky = itemHD.KY + "/" + itemHD.NAM,
            //                  MLT = itemHD.MALOTRINH,
            //                  DanhBo = itemHD.DANHBA,
            //                  HoTen = itemHD.TENKH,
            //                  DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                  GiaBieu = itemHD.GB,
            //                  HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                  //HanhThu = itemtableND.HoTen,
            //                  //To = itemtableND.TT_To.TenTo,
            //                  To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                  DangNgan = itemtableDN.HoTen,
            //                  DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                  LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //              };
            //dt.Merge(LINQToDataTable(queryDN));
            //if (dt.Rows.Count > 0)
            //    dt.DefaultView.Sort = "CreateDate ASC";
            //dt = dt.DefaultView.ToTable();

            //return dt;
            string sql="if ((select DongNuoc from TT_NguoiDung where MaND="+MaNV_HanhThu+")=0)"
                            + " select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
	                        + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                            + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                            + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
	                        + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
	                        + " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
	                        + " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                            + " from TT_DichVuThu dvt,HOADON hd where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and hd.MaNV_HanhThu=" + MaNV_HanhThu + " and not exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) and dvt.MaHD=hd.ID_HOADON"
	                        + " order by dvt.CreateDate asc"
                        + " else"
                            + " select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
	                        + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                            + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                            + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
	                        + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
	                        + " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
	                        + " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                            + " from TT_DichVuThu dvt,HOADON hd,TT_DongNuoc dn,TT_CTDongNuoc ctdn where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and dn.MaNV_DongNuoc=" + MaNV_HanhThu + " and ctdn.MaHD=dvt.MaHD and dn.Huy=0 and dn.MaDN=ctdn.MaDN and dvt.MaHD=hd.ID_HOADON"
	                        + " order by dvt.CreateDate asc";
        return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DenKy_NV(string TenDichVu, int MaNV_HanhThu, DateTime FromCreateDate, DateTime ToCreateDate, int Nam, int Ky)
        {
            //DataTable dt = new DataTable();
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where itemHD.MaNV_HanhThu == MaNV_HanhThu
            //                && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu) && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky))
            //                && !(from itemCTDN in _db.TT_CTDongNuocs where itemCTDN.TT_DongNuoc.Huy == false select itemCTDN.SoHoaDon).Contains(itemHD.SOHOADON)
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                //HanhThu = itemtableND.HoTen,
            //                //To = itemtableND.TT_To.TenTo,
            //                To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //dt = LINQToDataTable(query);

            //var queryDN = from itemDV in _db.TT_DichVuThus
            //              join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //              join itemCTDN in _db.TT_CTDongNuocs on itemDV.SoHoaDon equals itemCTDN.SoHoaDon
            //              join itemND in _db.TT_NguoiDungs on itemCTDN.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
            //              from itemtableND in tableND.DefaultIfEmpty()
            //              join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //              from itemtableDN in tableDN.DefaultIfEmpty()
            //              where itemCTDN.TT_DongNuoc.MaNV_DongNuoc == MaNV_HanhThu && itemCTDN.TT_DongNuoc.Huy == false
            //                && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)&&(itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky))
            //              select new
            //              {
            //                  itemDV.SoHoaDon,
            //                  itemDV.SoTien,
            //                  Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                  itemDV.TenDichVu,
            //                  itemDV.CreateDate,
            //                  itemHD.NGAYGIAITRACH,
            //                  itemHD.DangNgan_ChuyenKhoan,
            //                  Ky = itemHD.KY + "/" + itemHD.NAM,
            //                  MLT = itemHD.MALOTRINH,
            //                  DanhBo = itemHD.DANHBA,
            //                  HoTen = itemHD.TENKH,
            //                  DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                  GiaBieu = itemHD.GB,
            //                  HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                  //HanhThu = itemtableND.HoTen,
            //                  //To = itemtableND.TT_To.TenTo,
            //                  To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                  DangNgan = itemtableDN.HoTen,
            //                  DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                  LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //              };
            //dt.Merge(LINQToDataTable(queryDN));
            //if (dt.Rows.Count > 0)
            //    dt.DefaultView.Sort = "CreateDate ASC";
            //dt = dt.DefaultView.ToTable();

            //return dt;
            string sql = "if ((select DongNuoc from TT_NguoiDung where MaND=" + MaNV_HanhThu + ")=0)"
                            + " select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                            + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                            + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                            + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                            + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                            + " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                            + " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                            + " from TT_DichVuThu dvt,HOADON hd where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and hd.MaNV_HanhThu=" + MaNV_HanhThu + " and not exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) and dvt.MaHD=hd.ID_HOADON and (hd.NAM<" + Nam + " or (hd.NAM=" + Nam + " and hd.KY<=" + Ky + "))"
                            + " order by dvt.CreateDate asc"
                        + " else"
                            + " select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                            + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                            + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                            + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                            + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                            + " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                            + " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                            + " from TT_DichVuThu dvt,HOADON hd,TT_DongNuoc dn,TT_CTDongNuoc ctdn where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and dn.MaNV_DongNuoc=" + MaNV_HanhThu + " and ctdn.MaHD=dvt.MaHD and dn.Huy=0 and dn.MaDN=ctdn.MaDN and dvt.MaHD=hd.ID_HOADON and (hd.NAM<" + Nam + " or (hd.NAM=" + Nam + " and hd.KY<=" + Ky + "))"
                            + " order by dvt.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_NV_Dot(string TenDichVu, int MaNV_HanhThu, DateTime FromCreateDate, DateTime ToCreateDate, int FromDot, int ToDot)
        {
            //DataTable dt = new DataTable();
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where itemHD.MaNV_HanhThu == MaNV_HanhThu
            //                && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
            //                && itemHD.DOT.Value >= FromDot && itemHD.DOT.Value <= ToDot
            //                && !(from itemCTDN in _db.TT_CTDongNuocs where itemCTDN.TT_DongNuoc.Huy == false select itemCTDN.SoHoaDon).Contains(itemHD.SOHOADON)
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                //HanhThu = itemtableND.HoTen,
            //                //To = itemtableND.TT_To.TenTo,
            //                To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //dt = LINQToDataTable(query);

            //var queryDN = from itemDV in _db.TT_DichVuThus
            //              join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //              join itemCTDN in _db.TT_CTDongNuocs on itemDV.SoHoaDon equals itemCTDN.SoHoaDon
            //              join itemND in _db.TT_NguoiDungs on itemCTDN.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
            //              from itemtableND in tableND.DefaultIfEmpty()
            //              join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //              from itemtableDN in tableDN.DefaultIfEmpty()
            //              where itemCTDN.TT_DongNuoc.MaNV_DongNuoc == MaNV_HanhThu && itemCTDN.TT_DongNuoc.Huy == false
            //                && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
            //                && itemHD.DOT.Value >= FromDot && itemHD.DOT.Value <= ToDot
            //              select new
            //              {
            //                  itemDV.SoHoaDon,
            //                  itemDV.SoTien,
            //                  Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                  itemDV.TenDichVu,
            //                  itemDV.CreateDate,
            //                  itemHD.NGAYGIAITRACH,
            //                  itemHD.DangNgan_ChuyenKhoan,
            //                  Ky = itemHD.KY + "/" + itemHD.NAM,
            //                  MLT = itemHD.MALOTRINH,
            //                  DanhBo = itemHD.DANHBA,
            //                  HoTen = itemHD.TENKH,
            //                  DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                  GiaBieu = itemHD.GB,
            //                  HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                  //HanhThu = itemtableND.HoTen,
            //                  //To = itemtableND.TT_To.TenTo,
            //                  To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                  DangNgan = itemtableDN.HoTen,
            //                  DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                  LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //              };
            //dt.Merge(LINQToDataTable(queryDN));
            //if (dt.Rows.Count > 0)
            //    dt.DefaultView.Sort = "CreateDate ASC";
            //dt = dt.DefaultView.ToTable();

            //return dt;
            string sql = "if ((select DongNuoc from TT_NguoiDung where MaND=" + MaNV_HanhThu + ")=0)"
                            + " select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                            + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                            + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                            + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                            + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                            + " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                            + " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                            + " from TT_DichVuThu dvt,HOADON hd where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and hd.MaNV_HanhThu=" + MaNV_HanhThu + " and not exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) and dvt.MaHD=hd.ID_HOADON and hd.DOT>=" + FromDot + " and hd.DOT<=" + ToDot 
                            + " order by dvt.CreateDate asc"
                        + " else"
                            + " select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                            + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                            + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                            + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                            + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                            + " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                            + " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                            + " from TT_DichVuThu dvt,HOADON hd,TT_DongNuoc dn,TT_CTDongNuoc ctdn where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and dn.MaNV_DongNuoc=" + MaNV_HanhThu + " and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN and dn.Huy=0 and dvt.MaHD=hd.ID_HOADON and hd.DOT>=" + FromDot + " and hd.DOT<=" + ToDot 
                            + " order by dvt.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DenKy_NV_Dot(string TenDichVu, int MaNV_HanhThu, DateTime FromCreateDate, DateTime ToCreateDate, int Nam, int Ky, int FromDot, int ToDot)
        {
            //DataTable dt = new DataTable();
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where itemHD.MaNV_HanhThu == MaNV_HanhThu
            //                && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
            //                && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky)) && itemHD.DOT.Value >= FromDot && itemHD.DOT.Value <= ToDot
            //                && !(from itemCTDN in _db.TT_CTDongNuocs where itemCTDN.TT_DongNuoc.Huy == false select itemCTDN.SoHoaDon).Contains(itemHD.SOHOADON)
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                //HanhThu = itemtableND.HoTen,
            //                //To = itemtableND.TT_To.TenTo,
            //                To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //dt = LINQToDataTable(query);

            //var queryDN = from itemDV in _db.TT_DichVuThus
            //              join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //              join itemCTDN in _db.TT_CTDongNuocs on itemDV.SoHoaDon equals itemCTDN.SoHoaDon
            //              join itemND in _db.TT_NguoiDungs on itemCTDN.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
            //              from itemtableND in tableND.DefaultIfEmpty()
            //              join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //              from itemtableDN in tableDN.DefaultIfEmpty()
            //              where itemCTDN.TT_DongNuoc.MaNV_DongNuoc == MaNV_HanhThu && itemCTDN.TT_DongNuoc.Huy == false
            //                && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
            //                && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky)) && itemHD.DOT.Value >= FromDot && itemHD.DOT.Value <= ToDot
            //              select new
            //              {
            //                  itemDV.SoHoaDon,
            //                  itemDV.SoTien,
            //                  Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                  itemDV.TenDichVu,
            //                  itemDV.CreateDate,
            //                  itemHD.NGAYGIAITRACH,
            //                  itemHD.DangNgan_ChuyenKhoan,
            //                  Ky = itemHD.KY + "/" + itemHD.NAM,
            //                  MLT = itemHD.MALOTRINH,
            //                  DanhBo = itemHD.DANHBA,
            //                  HoTen = itemHD.TENKH,
            //                  DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                  GiaBieu = itemHD.GB,
            //                  HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                  //HanhThu = itemtableND.HoTen,
            //                  //To = itemtableND.TT_To.TenTo,
            //                  To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                  DangNgan = itemtableDN.HoTen,
            //                  DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                  LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //              };
            //dt.Merge(LINQToDataTable(queryDN));
            //if (dt.Rows.Count > 0)
            //    dt.DefaultView.Sort = "CreateDate ASC";
            //dt = dt.DefaultView.ToTable();

            //return dt;
            string sql = "if ((select DongNuoc from TT_NguoiDung where MaND=" + MaNV_HanhThu + ")=0)"
                            + " select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                            + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                            + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                            + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                            + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                            + " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                            + " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                            + " from TT_DichVuThu dvt,HOADON hd where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and hd.MaNV_HanhThu=" + MaNV_HanhThu + " and not exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) and dvt.MaHD=hd.ID_HOADON and (hd.NAM<" + Nam + " or (hd.NAM=" + Nam + " and hd.KY<=" + Ky + ")) and hd.DOT>=" + FromDot + " and hd.DOT<=" + ToDot 
                            + " order by dvt.CreateDate asc"
                        + " else"
                            + " select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                            + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                            + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                            + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                            + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                            + " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                            + " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                            + " from TT_DichVuThu dvt,HOADON hd,TT_DongNuoc dn,TT_CTDongNuoc ctdn where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and dn.MaNV_DongNuoc=" + MaNV_HanhThu + " and ctdn.MaHD=dvt.MaHD and dn.Huy=0 and dn.MaDN=ctdn.MaDN and dvt.MaHD=hd.ID_HOADON and (hd.NAM<" + Nam + " or (hd.NAM=" + Nam + " and hd.KY<=" + Ky + ")) and hd.DOT>=" + FromDot + " and hd.DOT<=" + ToDot 
                            + " order by dvt.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDS(int MaNH, int MaTo, int Nam)
        {
            string sql = "declare @Nam int;"
                    + " declare @MaTo int;"
                    + " declare @MaNH int;"
                    + " declare @TuCuonGCS int;"
                    + " declare @DenCuonGCS int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @MaTo=" + MaTo + ";"
                    + " set @MaNH=" + MaNH + ";"
                    + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                    + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                    + " if @MaNH=-2"//tất cả
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 	from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 	where NAM=@Nam and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH like '%%'"
                    + " 	and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	union all"
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 	from HOADON hd"
                    + " 	where NAM=@Nam and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 	and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	order by MALOTRINH asc"
                    + " else"
                    + " 	if @MaNH=-1"//khác
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where 2=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc"
                    + " 	else"//ngân hàng bình thường
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 		from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 		where NAM=@Nam and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH=@MaNH"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDS(int MaNH, int MaTo, int Nam, int Ky)
        {
            string sql = "declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @MaTo int;"
                    + " declare @MaNH int;"
                    + " declare @TuCuonGCS int;"
                    + " declare @DenCuonGCS int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @MaTo=" + MaTo + ";"
                    + " set @MaNH=" + MaNH + ";"
                    + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                    + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                    + " if @MaNH=-2"//tất cả
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 	from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 	where NAM=@Nam and KY=@Ky and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH like '%%'"
                    + " 	and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	union all"
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 	from HOADON hd"
                    + " 	where NAM=@Nam and KY=@Ky and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 	and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	order by MALOTRINH asc"
                    + " else"
                    + " 	if @MaNH=-1"//khác
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc"
                    + " 	else"//ngân hàng bình thường
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 		from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 		where NAM=@Nam and KY=@Ky and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH=@MaNH"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDS(int MaNH, int MaTo, int Nam, int Ky, int FromDot, int ToDot)
        {
            string sql = "declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @MaTo int;"
                    + " declare @MaNH int;"
                    + " declare @FromDot int;"
                    + " declare @ToDot int;"
                    + " declare @TuCuonGCS int;"
                    + " declare @DenCuonGCS int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @MaTo=" + MaTo + ";"
                    + " set @MaNH=" + MaNH + ";"
                    + " set @FromDot=" + FromDot + ";"
                    + " set @ToDot=" + ToDot + ";"
                    + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                    + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                    + " if @MaNH=-2"//tất cả
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 	from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 	where NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH like '%%'"
                    + " 	and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	union all"
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 	from HOADON hd"
                    + " 	where NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 	and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	order by MALOTRINH asc"
                    + " else"
                    + " 	if @MaNH=-1"//khác
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc"
                    + " 	else"//ngân hàng bình thường
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 		from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 		where NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH=@MaNH"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDS_NV(int MaNH, int MaNV_HanhThu, int Nam)
        {
            string sql = "declare @Nam int;"
                    + " declare @MaNV_HanhThu int;"
                    + " declare @MaNH int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                    + " set @MaNH=" + MaNH + ";"
                    + " if @MaNH=-2"//tất cả
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 	from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 	where NAM=@Nam and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH like '%%'"
                    + " 	and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	union all"
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 	from HOADON hd"
                    + " 	where NAM=@Nam and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 	and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	order by MALOTRINH asc"
                    + " else"
                    + " 	if @MaNH=-1"//khác
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc"
                    + " 	else"//ngân hàng bình thường
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 		from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 		where NAM=@Nam and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH=@MaNH"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDS_NV(int MaNH, int MaNV_HanhThu, int Nam, int Ky)
        {
            string sql = "declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @MaNV_HanhThu int;"
                    + " declare @MaNH int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                    + " set @MaNH=" + MaNH + ";"
                    + " if @MaNH=-2"//tất cả
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 	from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 	where NAM=@Nam and KY=@Ky and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH like '%%'"
                    + " 	and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	union all"
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 	from HOADON hd"
                    + " 	where NAM=@Nam and KY=@Ky and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 	and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	order by MALOTRINH asc"
                    + " else"
                    + " 	if @MaNH=-1"//khác
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc"
                    + " 	else"//ngân hàng bình thường
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 		from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 		where NAM=@Nam and KY=@Ky and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH=@MaNH"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDS_NV(int MaNH, int MaNV_HanhThu, int Nam, int Ky, int FromDot, int ToDot)
        {
            string sql = "declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @MaNV_HanhThu int;"
                    + " declare @MaNH int;"
                    + " declare @FromDot int;"
                    + " declare @ToDot int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                    + " set @MaNH=" + MaNH + ";"
                    + " set @FromDot=" + FromDot + ";"
                    + " set @ToDot=" + ToDot + ";"
                    + " if @MaNH=-2"//tất cả
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 	from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 	where NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH like '%%'"
                    + " 	and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	union all"
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 	from HOADON hd"
                    + " 	where NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 	and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	order by MALOTRINH asc"
                    + " else"
                    + " 	if @MaNH=-1"//khác
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc"
                    + " 	else"//ngân hàng bình thường
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 		from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 		where NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH=@MaNH"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc";
            return ExecuteQuery_DataTable(sql);
        }

        //

        public DataTable getDS_LenhHuy(string TenDichVu, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemLH in _db.TT_LenhHuys on itemDV.SoHoaDon equals itemLH.SoHoaDon
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate
            //            && itemDV.TenDichVu.Contains(TenDichVu)
            //            orderby itemDV.CreateDate ascending
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                //HanhThu = itemtableND.HoTen,
            //                //To = itemtableND.TT_To.TenTo,
            //                To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                //DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                //LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //return LINQToDataTable(query);
            string sql = "select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                            + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                            + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                            + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                            + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                            //+ " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                            //+ " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                            + " from TT_DichVuThu dvt,HOADON hd,TT_LenhHuy lh where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and dvt.MaHD=hd.ID_HOADON and hd.ID_HOADON=lh.MaHD"
                            + " order by dvt.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_LenhHuy(string TenDichVu, int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemLH in _db.TT_LenhHuys on itemDV.SoHoaDon equals itemLH.SoHoaDon
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
            //                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
            //                && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
            //            orderby itemDV.CreateDate ascending
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                //HanhThu = itemtableND.HoTen,
            //                //To = itemtableND.TT_To.TenTo,
            //                To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                //DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                //LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //return LINQToDataTable(query);
            string sql = "select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                            + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                            + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                            + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                            + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                //+ " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                //+ " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                            + " from TT_DichVuThu dvt,HOADON hd,TT_LenhHuy lh where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and dvt.MaHD=hd.ID_HOADON and hd.ID_HOADON=lh.MaHD and hd.MAY>=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ") and hd.MAY<=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                            + " order by dvt.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_NV_LenhHuy(string TenDichVu, int MaNV_HanhThu, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            //DataTable dt = new DataTable();
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemLH in _db.TT_LenhHuys on itemDV.SoHoaDon equals itemLH.SoHoaDon
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where itemHD.MaNV_HanhThu == MaNV_HanhThu
            //                && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
            //                && !(from itemCTDN in _db.TT_CTDongNuocs where itemCTDN.TT_DongNuoc.Huy == false select itemCTDN.SoHoaDon).Contains(itemHD.SOHOADON)
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                //HanhThu = itemtableND.HoTen,
            //                //To = itemtableND.TT_To.TenTo,
            //                To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                //DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                //LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //dt = LINQToDataTable(query);

            //var queryDN = from itemDV in _db.TT_DichVuThus
            //              join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //              join itemLH in _db.TT_LenhHuys on itemDV.SoHoaDon equals itemLH.SoHoaDon
            //              join itemCTDN in _db.TT_CTDongNuocs on itemDV.SoHoaDon equals itemCTDN.SoHoaDon
            //              join itemND in _db.TT_NguoiDungs on itemCTDN.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
            //              from itemtableND in tableND.DefaultIfEmpty()
            //              join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //              from itemtableDN in tableDN.DefaultIfEmpty()
            //              where itemCTDN.TT_DongNuoc.MaNV_DongNuoc == MaNV_HanhThu && itemCTDN.TT_DongNuoc.Huy == false
            //                && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
            //              select new
            //              {
            //                  itemDV.SoHoaDon,
            //                  itemDV.SoTien,
            //                  Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                  itemDV.TenDichVu,
            //                  itemDV.CreateDate,
            //                  itemHD.NGAYGIAITRACH,
            //                  itemHD.DangNgan_ChuyenKhoan,
            //                  Ky = itemHD.KY + "/" + itemHD.NAM,
            //                  MLT = itemHD.MALOTRINH,
            //                  DanhBo = itemHD.DANHBA,
            //                  HoTen = itemHD.TENKH,
            //                  DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                  GiaBieu = itemHD.GB,
            //                  HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                  //HanhThu = itemtableND.HoTen,
            //                  //To = itemtableND.TT_To.TenTo,
            //                  To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                  DangNgan = itemtableDN.HoTen,
            //                  //DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                  //LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //              };
            //dt.Merge(LINQToDataTable(queryDN));
            //if (dt.Rows.Count > 0)
            //    dt.DefaultView.Sort = "CreateDate ASC";
            //dt = dt.DefaultView.ToTable();

            //return dt;
            string sql = "if ((select DongNuoc from TT_NguoiDung where MaND=" + MaNV_HanhThu + ")=0)"
                            + " select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                            + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                            + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                            + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                            + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                            //+ " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                            //+ " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                            + " from TT_DichVuThu dvt,HOADON hd,TT_LenhHuy hd where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and hd.MaNV_HanhThu=" + MaNV_HanhThu + " and not exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) and dvt.MaHD=hd.ID_HOADON and hd.ID_HOADON=lh.MaHD"
                            + " order by dvt.CreateDate asc"
                        + " else"
                            + " select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                            + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                            + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                            + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                            + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                            //+ " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                            //+ " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                            + " from TT_DichVuThu dvt,HOADON hd,TT_DongNuoc dn,TT_CTDongNuoc ctdn,TT_LenhHuy hd where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and dn.MaNV_DongNuoc=" + MaNV_HanhThu + " and ctdn.MaHD=dvt.MaHD and dn.Huy=0 and dn.MaDN=ctdn.MaDN and dvt.MaHD=hd.ID_HOADON and hd.ID_HOADON=lh.MaHD"
                            + " order by dvt.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_Dot_LenhHuy(string TenDichVu, DateTime FromCreateDate, DateTime ToCreateDate, int FromDot, int ToDot)
        {
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemLH in _db.TT_LenhHuys on itemDV.SoHoaDon equals itemLH.SoHoaDon
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate
            //            && itemDV.TenDichVu.Contains(TenDichVu) && itemHD.DOT.Value >= FromDot && itemHD.DOT.Value <= ToDot
            //            orderby itemDV.CreateDate ascending
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                //HanhThu = itemtableND.HoTen,
            //                //To = itemtableND.TT_To.TenTo,
            //                To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                //DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                //LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //return LINQToDataTable(query);
            string sql = "select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                            + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                            + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                            + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                            + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                //+ " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                //+ " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                            + " from TT_DichVuThu dvt,HOADON hd,TT_LenhHuy lh where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and dvt.MaHD=hd.ID_HOADON and hd.DOT>="+FromDot+" and hd.DOT<="+ToDot+" hd.ID_HOADON=lh.MaHD"
                            + " order by dvt.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_Dot_LenhHuy(string TenDichVu, int MaTo, DateTime FromCreateDate, DateTime ToCreateDate, int FromDot, int ToDot)
        {
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemLH in _db.TT_LenhHuys on itemDV.SoHoaDon equals itemLH.SoHoaDon
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
            //                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
            //                && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
            //                && itemHD.DOT.Value >= FromDot && itemHD.DOT.Value <= ToDot
            //            orderby itemDV.CreateDate ascending
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                //HanhThu = itemtableND.HoTen,
            //                //To = itemtableND.TT_To.TenTo,
            //                To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                //DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                //LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //return LINQToDataTable(query);
            string sql = "select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                            + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                            + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                            + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                            + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                //+ " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                //+ " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                            + " from TT_DichVuThu dvt,HOADON hd,TT_LenhHuy lh where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and dvt.MaHD=hd.ID_HOADON and hd.MAY>=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ") and hd.MAY<=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ") and hd.DOT>=" + FromDot + " and hd.DOT<=" + ToDot + " hd.ID_HOADON=lh.MaHD"
                            + " order by dvt.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_NV_Dot_LenhHuy(string TenDichVu, int MaNV_HanhThu, DateTime FromCreateDate, DateTime ToCreateDate, int FromDot, int ToDot)
        {
            //DataTable dt = new DataTable();
            //var query = from itemDV in _db.TT_DichVuThus
            //            join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //            join itemLH in _db.TT_LenhHuys on itemDV.SoHoaDon equals itemLH.SoHoaDon
            //            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //            from itemtableDN in tableDN.DefaultIfEmpty()
            //            where itemHD.MaNV_HanhThu == MaNV_HanhThu
            //                && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
            //                && itemHD.DOT.Value >= FromDot && itemHD.DOT.Value <= ToDot
            //                && !(from itemCTDN in _db.TT_CTDongNuocs where itemCTDN.TT_DongNuoc.Huy == false select itemCTDN.SoHoaDon).Contains(itemHD.SOHOADON)
            //            select new
            //            {
            //                itemDV.SoHoaDon,
            //                itemDV.SoTien,
            //                Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                itemDV.TenDichVu,
            //                itemDV.IDGiaoDich,
            //                itemDV.CreateDate,
            //                itemHD.NGAYGIAITRACH,
            //                itemHD.DangNgan_Quay,
            //                itemHD.DangNgan_ChuyenKhoan,
            //                itemHD.TIEUTHU,
            //                Ky = itemHD.KY + "/" + itemHD.NAM,
            //                MLT = itemHD.MALOTRINH,
            //                DanhBo = itemHD.DANHBA,
            //                HoTen = itemHD.TENKH,
            //                DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                GiaBieu = itemHD.GB,
            //                HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                //HanhThu = itemtableND.HoTen,
            //                //To = itemtableND.TT_To.TenTo,
            //                To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                DangNgan = itemtableDN.HoTen,
            //                //DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                //LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //            };
            //dt = LINQToDataTable(query);

            //var queryDN = from itemDV in _db.TT_DichVuThus
            //              join itemHD in _db.HOADONs on itemDV.SoHoaDon equals itemHD.SOHOADON
            //              join itemLH in _db.TT_LenhHuys on itemDV.SoHoaDon equals itemLH.SoHoaDon
            //              join itemCTDN in _db.TT_CTDongNuocs on itemDV.SoHoaDon equals itemCTDN.SoHoaDon
            //              join itemND in _db.TT_NguoiDungs on itemCTDN.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
            //              from itemtableND in tableND.DefaultIfEmpty()
            //              join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
            //              from itemtableDN in tableDN.DefaultIfEmpty()
            //              where itemCTDN.TT_DongNuoc.MaNV_DongNuoc == MaNV_HanhThu && itemCTDN.TT_DongNuoc.Huy == false
            //                && itemDV.CreateDate >= FromCreateDate && itemDV.CreateDate <= ToCreateDate && itemDV.TenDichVu.Contains(TenDichVu)
            //                && itemHD.DOT.Value >= FromDot && itemHD.DOT.Value <= ToDot
            //              select new
            //              {
            //                  itemDV.SoHoaDon,
            //                  itemDV.SoTien,
            //                  Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
            //                  itemDV.TenDichVu,
            //                  itemDV.CreateDate,
            //                  itemHD.NGAYGIAITRACH,
            //                  itemHD.DangNgan_ChuyenKhoan,
            //                  Ky = itemHD.KY + "/" + itemHD.NAM,
            //                  MLT = itemHD.MALOTRINH,
            //                  DanhBo = itemHD.DANHBA,
            //                  HoTen = itemHD.TENKH,
            //                  DiaChi = itemHD.SO + " " + itemHD.DUONG,
            //                  GiaBieu = itemHD.GB,
            //                  HanhThu = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
            //                  //HanhThu = itemtableND.HoTen,
            //                  //To = itemtableND.TT_To.TenTo,
            //                  To = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
            //                  DangNgan = itemtableDN.HoTen,
            //                  //DongNuoc = _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == itemDV.SoHoaDon && item.TT_DongNuoc.Huy == false),
            //                  //LenhHuy = _db.TT_LenhHuys.Any(item => item.SoHoaDon == itemDV.SoHoaDon),
            //              };
            //dt.Merge(LINQToDataTable(queryDN));
            //if (dt.Rows.Count > 0)
            //    dt.DefaultView.Sort = "CreateDate ASC";
            //dt = dt.DefaultView.ToTable();

            //return dt;
            string sql = "if ((select DongNuoc from TT_NguoiDung where MaND=" + MaNV_HanhThu + ")=0)"
                            + " select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                            + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                            + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                            + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                            + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                //+ " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                //+ " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                            + " from TT_DichVuThu dvt,HOADON hd,TT_LenhHuy hd where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and hd.MaNV_HanhThu=" + MaNV_HanhThu + " and not exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) and dvt.MaHD=hd.ID_HOADON and hd.DOT>=" + FromDot + " and hd.DOT<=" + ToDot + " and hd.ID_HOADON=lh.MaHD"
                            + " order by dvt.CreateDate asc"
                        + " else"
                            + " select dvt.MaHD,dvt.SoHoaDon,dvt.DanhBo,Ky=CONVERT(char(2),dvt.Ky)+'/'+CONVERT(char(4),dvt.Nam),dvt.SoTien,dvt.TenDichVu,dvt.IDGiaoDich,dvt.CreateDate,Phi=(select PhiMoNuoc from TT_DichVuThuTong where ID=dvt.IDDichVu)"
                            + " ,hd.NGAYGIAITRACH,hd.DangNgan_Quay,hd.DangNgan_ChuyenKhoan,MLT=hd.MALOTRINH,hd.TIEUTHU,GiaBieu=hd.GB,HoTen=hd.TENKH,DiaChi=hd.SO+' '+hd.DUONG"
                            + " ,HanhThu=(select HoTen from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end)"
                            + " ,'To'=(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and MaNV_DongNuoc is not null and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then (select top 1 dn.MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN) else hd.MaNV_HanhThu end))"
                            + " ,DangNgan=(select HoTen from TT_NguoiDung where MaND=hd.MaNV_DangNgan)"
                //+ " ,DongNuoc=case when exists (select top 1 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and ctdn.MaHD=dvt.MaHD and dn.MaDN=ctdn.MaDN)then 'true' else 'false' end"
                //+ " ,LenhHuy=case when exists (select top 1 MaHD from TT_LenhHuy where MaHD=dvt.MaHD)then 'true' else 'false' end"
                            + " from TT_DichVuThu dvt,HOADON hd,TT_DongNuoc dn,TT_CTDongNuoc ctdn,TT_LenhHuy hd where dvt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm:ss") + "' and dvt.TenDichVu like '%" + TenDichVu + "%' and dn.MaNV_DongNuoc=" + MaNV_HanhThu + " and ctdn.MaHD=dvt.MaHD and dn.Huy=0 and dn.MaDN=ctdn.MaDN and dvt.MaHD=hd.ID_HOADON and hd.DOT>=" + FromDot + " and hd.DOT<=" + ToDot + " and hd.ID_HOADON=lh.MaHD"
                            + " order by dvt.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

        //

        public DataTable GetDS_GiaBieu(int MaNH, int MaTo, int Nam, int GiaBieu)
        {
            string sql = "declare @Nam int;"
                    + " declare @MaTo int;"
                    + " declare @MaNH int;"
                    + " declare @GiaBieu int;"
                    + " declare @TuCuonGCS int;"
                    + " declare @DenCuonGCS int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @MaTo=" + MaTo + ";"
                    + " set @MaNH=" + MaNH + ";"
                    + " set @GiaBieu=" + GiaBieu + ";"
                    + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                    + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                    + " if @MaNH=-2"//tất cả
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 	from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 	where NAM=@Nam and GB=@GiaBieu and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH like '%%'"
                    + " 	and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	union all"
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 	from HOADON hd"
                    + " 	where NAM=@Nam and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 	and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	order by MALOTRINH asc"
                    + " else"
                    + " 	if @MaNH=-1"//khác
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where 2=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc"
                    + " 	else"//ngân hàng bình thường
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 		from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 		where NAM=@Nam and GB=@GiaBieu and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH=@MaNH"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDS_GiaBieu(int MaNH, int MaTo, int Nam, int Ky, int GiaBieu)
        {
            string sql = "declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @MaTo int;"
                    + " declare @MaNH int;"
                    + " declare @GiaBieu int;"
                    + " declare @TuCuonGCS int;"
                    + " declare @DenCuonGCS int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @MaTo=" + MaTo + ";"
                    + " set @MaNH=" + MaNH + ";"
                    + " set @GiaBieu=" + GiaBieu + ";"
                    + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                    + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                    + " if @MaNH=-2"//tất cả
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 	from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 	where NAM=@Nam and KY=@Ky and GB=@GiaBieu and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH like '%%'"
                    + " 	and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	union all"
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 	from HOADON hd"
                    + " 	where NAM=@Nam and KY=@Ky and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 	and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	order by MALOTRINH asc"
                    + " else"
                    + " 	if @MaNH=-1"//khác
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc"
                    + " 	else"//ngân hàng bình thường
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 		from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 		where NAM=@Nam and KY=@Ky and GB=@GiaBieu and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH=@MaNH"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDS_GiaBieu_NV(int MaNH, int MaNV_HanhThu, int Nam, int GiaBieu)
        {
            string sql = "declare @Nam int;"
                    + " declare @MaNV_HanhThu int;"
                    + " declare @MaNH int;"
                    + " declare @GiaBieu int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                    + " set @MaNH=" + MaNH + ";"
                    + " set @GiaBieu=" + GiaBieu + ";"
                    + " if @MaNH=-2"//tất cả
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 	from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 	where NAM=@Nam and GB=@GiaBieu and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH like '%%'"
                    + " 	and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	union all"
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 	from HOADON hd"
                    + " 	where NAM=@Nam and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 	and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	order by MALOTRINH asc"
                    + " else"
                    + " 	if @MaNH=-1"//khác
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc"
                    + " 	else"//ngân hàng bình thường
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 		from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 		where NAM=@Nam and GB=@GiaBieu and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH=@MaNH"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDS_GiaBieu_NV(int MaNH, int MaNV_HanhThu, int Nam, int Ky, int GiaBieu)
        {
            string sql = "declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @MaNV_HanhThu int;"
                    + " declare @MaNH int;"
                    + " declare @GiaBieu int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                    + " set @MaNH=" + MaNH + ";"
                    + " set @GiaBieu=" + GiaBieu + ";"
                    + " if @MaNH=-2"//tất cả
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 	from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 	where NAM=@Nam and KY=@Ky and GB=@GiaBieu and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH like '%%'"
                    + " 	and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	union all"
                    + " 	select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 	'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 	from HOADON hd"
                    + " 	where NAM=@Nam and KY=@Ky and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 	and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	order by MALOTRINH asc"
                    + " else"
                    + " 	if @MaNH=-1"//khác
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=N'Khác',GiaBieu=GB,TieuThu"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc"
                    + " 	else"//ngân hàng bình thường
                    + " 		select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                    + " 		'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),TONGCONG,TenNH=NGANHANG,GiaBieu=GB,TieuThu"
                    + " 		from TAMTHU tt,HOADON hd,NGANHANG nh"
                    + " 		where NAM=@Nam and KY=@Ky and GB=@GiaBieu and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH=@MaNH"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		order by MALOTRINH asc";
            return ExecuteQuery_DataTable(sql);
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
                            Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
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
                            Phi=itemDV.TT_DichVuThuTong.PhiMoNuoc,
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

        public DataTable GetBienDongChuyenKhoan(int MaNH, int Nam, int Ky)
        {
            string sql = "declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @NamCu int;"
                    + " declare @KyCu int;"
                    + " declare @MaNH int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @MaNH=" + MaNH + ";"
                    + " if @Ky=1"
                    + " 	begin"
                    + " 		set @NamCu=@Nam-1;"
                    + " 		set @KyCu=12;"
                    + " 	end"
                    + " else"
                    + " 	begin"
                    + " 		set @NamCu=@Nam;"
                    + " 		set @KyCu=@Ky-1;"
                    + " 	end"
                    + " if @MaNH=-2"
                    + " 	select a.Nam,a.Ky,TongHDCK=SUM(a.TongHDCK),BienDong=SUM(a.BienDong) from"
                    + " 		(select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and MaNH like '%%' and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and MaNH like '%%' and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		union all"
                    + " 		select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)a"
                    + " 	group by Nam,Ky"
                    + " else"
                    + " 	if @MaNH=-1"
                    + " 		select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	else"
                    + " 		select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and MaNH=@MaNH and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and MaNH=@MaNH and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetBienDongChuyenKhoan(int MaNH, int MaTo, int Nam, int Ky)
        {
            string sql = "declare @MaTo int;"
                    + " declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @NamCu int;"
                    + " declare @KyCu int;"
                    + " declare @MaNH int;"
                    + " declare @TuCuonGCS int;"
                    + " declare @DenCuonGCS int;"
                    + " set @MaTo=" + MaTo + ";"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @MaNH=" + MaNH + ";"
                    + " if @Ky=1"
                    + " 	begin"
                    + " 		set @NamCu=@Nam-1;"
                    + " 		set @KyCu=12;"
                    + " 	end"
                    + " else"
                    + " 	begin"
                    + " 		set @NamCu=@Nam;"
                    + " 		set @KyCu=@Ky-1;"
                    + " 	end"
                    + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                    + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                    + " if @MaNH=-2"
                    + " 	select a.Nam,a.Ky,TongHDCK=SUM(a.TongHDCK),BienDong=SUM(a.BienDong) from"
                    + " 		(select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and MaNH like '%%' and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and MaNH like '%%' and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		union all"
                    + " 		select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)a"
                    + " 	group by Nam,Ky"
                    + " else"
                    + " 	if @MaNH=-1"
                    + " 		select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	else"
                    + " 		select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and MaNH=@MaNH and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and MaNH=@MaNH and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetBienDongChuyenKhoan_NV(int MaNH, int MaNV_HanhThu, int Nam, int Ky)
        {
            string sql = "declare @MaNV_HanhThu int;"
                    + " declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @NamCu int;"
                    + " declare @KyCu int;"
                    + " declare @MaNH int;"
                    + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @MaNH=" + MaNH + ";"
                    + " if @Ky=1"
                    + " 	begin"
                    + " 		set @NamCu=@Nam-1;"
                    + " 		set @KyCu=12;"
                    + " 	end"
                    + " else"
                    + " 	begin"
                    + " 		set @NamCu=@Nam;"
                    + " 		set @KyCu=@Ky-1;"
                    + " 	end"
                    + " if @MaNH=-2"
                    + " 	select a.Nam,a.Ky,TongHDCK=SUM(a.TongHDCK),BienDong=SUM(a.BienDong) from"
                    + " 		(select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and MaNH like '%%' and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and MaNH like '%%' and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		union all"
                    + " 		select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)a"
                    + " 	group by Nam,Ky"
                    + " else"
                    + " 	if @MaNH=-1"
                    + " 		select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	else"
                    + " 		select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and MaNH=@MaNH and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and MaNH=@MaNH and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetBienDongChuyenKhoan_GiaBieu(int MaNH, int Nam, int Ky, int GiaBieu)
        {
            string sql = "declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @NamCu int;"
                    + " declare @KyCu int;"
                    + " declare @MaNH int;"
                    + " declare @GiaBieu int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @MaNH=" + MaNH + ";"
                    + " set @GiaBieu=" + GiaBieu + ";"
                    + " if @Ky=1"
                    + " 	begin"
                    + " 		set @NamCu=@Nam-1;"
                    + " 		set @KyCu=12;"
                    + " 	end"
                    + " else"
                    + " 	begin"
                    + " 		set @NamCu=@Nam;"
                    + " 		set @KyCu=@Ky-1;"
                    + " 	end"
                    + " if @MaNH=-2"
                    + " 	select a.Nam,a.Ky,TongHDCK=SUM(a.TongHDCK),BienDong=SUM(a.BienDong) from"
                    + " 		(select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and GB=@GiaBieu and MaNH like '%%' and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and GB=@GiaBieu and MaNH like '%%' and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		union all"
                    + " 		select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)a"
                    + " 	group by Nam,Ky"
                    + " else"
                    + " 	if @MaNH=-1"
                    + " 		select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	else"
                    + " 		select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and GB=@GiaBieu and MaNH=@MaNH and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and GB=@GiaBieu and MaNH=@MaNH and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetBienDongChuyenKhoan_GiaBieu(int MaNH, int MaTo, int Nam, int Ky, int GiaBieu)
        {
            string sql = "declare @MaTo int;"
                    + " declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @NamCu int;"
                    + " declare @KyCu int;"
                    + " declare @MaNH int;"
                    + " declare @GiaBieu int;"
                    + " declare @TuCuonGCS int;"
                    + " declare @DenCuonGCS int;"
                    + " set @MaTo=" + MaTo + ";"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @MaNH=" + MaNH + ";"
                    + " set @GiaBieu=" + GiaBieu + ";"
                    + " if @Ky=1"
                    + " 	begin"
                    + " 		set @NamCu=@Nam-1;"
                    + " 		set @KyCu=12;"
                    + " 	end"
                    + " else"
                    + " 	begin"
                    + " 		set @NamCu=@Nam;"
                    + " 		set @KyCu=@Ky-1;"
                    + " 	end"
                    + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                    + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                    + " if @MaNH=-2"
                    + " 	select a.Nam,a.Ky,TongHDCK=SUM(a.TongHDCK),BienDong=SUM(a.BienDong) from"
                    + " 		(select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and GB=@GiaBieu and MaNH like '%%' and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and GB=@GiaBieu and MaNH like '%%' and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		union all"
                    + " 		select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)a"
                    + " 	group by Nam,Ky"
                    + " else"
                    + " 	if @MaNH=-1"
                    + " 		select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	else"
                    + " 		select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and GB=@GiaBieu and MaNH=@MaNH and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and GB=@GiaBieu and MaNH=@MaNH and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetBienDongChuyenKhoan_GiaBieu_NV(int MaNH, int MaNV_HanhThu, int Nam, int Ky, int GiaBieu)
        {
            string sql = "declare @MaNV_HanhThu int;"
                    + " declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @NamCu int;"
                    + " declare @KyCu int;"
                    + " declare @MaNH int;"
                    + " declare @GiaBieu int;"
                    + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @MaNH=" + MaNH + ";"
                    + " set @GiaBieu=" + GiaBieu + ";"
                    + " if @Ky=1"
                    + " 	begin"
                    + " 		set @NamCu=@Nam-1;"
                    + " 		set @KyCu=12;"
                    + " 	end"
                    + " else"
                    + " 	begin"
                    + " 		set @NamCu=@Nam;"
                    + " 		set @KyCu=@Ky-1;"
                    + " 	end"
                    + " if @MaNH=-2"
                    + " 	select a.Nam,a.Ky,TongHDCK=SUM(a.TongHDCK),BienDong=SUM(a.BienDong) from"
                    + " 		(select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and GB=@GiaBieu and MaNH like '%%' and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and GB=@GiaBieu and MaNH like '%%' and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 		union all"
                    + " 		select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)a"
                    + " 	group by Nam,Ky"
                    + " else"
                    + " 	if @MaNH=-1"
                    + " 		select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and GB=@GiaBieu and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                    + " 	else"
                    + " 		select Nam=@Nam,Ky=@Ky,TongHDCK=COUNT(*),BienDong="
                    + " 		COUNT(*)-(select TongHDCK=COUNT(*) from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@NamCu and KY=@KyCu and GB=@GiaBieu and MaNH=@MaNH and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null)"
                    + " 		from TAMTHU tt,HOADON hd"
                    + " 		where NAM=@Nam and KY=@Ky and GB=@GiaBieu and MaNH=@MaNH and hd.ID_HOADON=tt.FK_HOADON"
                    + " 		and MaNV_HanhThu=@MaNV_HanhThu and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetPhanTichChuyenKhoan(string Loai, int MaNH, int MaTo, int Nam)
        {
            if (Loai == "TG")
            {
                string sql = "declare @Nam int;"
                        + " declare @MaTo int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @MaTo=" + MaTo + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                        + " select MaTo=@MaTo,TenTo=(select TenTo from TT_To where MaTo=@MaTo),* from"
                        + " (select TongHD=COUNT(ID_HOADON) from HOADON where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20)tong,"
                        + " "
                        + " (select TongHDCKB=COUNT(ID_HOADON),TongGiaBanCKB=SUM(GIABAN),TongCongCKB=SUM(TONGCONG) from HOADON hd,TAMTHU tt"
                        + " where hd.NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=1"
                        + " and (MaNH like case when '" + MaNH + "'='-1' then '%%' else '" + MaNH + "' end) and hd.ID_HOADON=tt.FK_HOADON)ckb,"
                        + " "
                        + " (select TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd"
                        + " where hd.NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=1 and ID_HOADON not in (select FK_HOADON from TAMTHU))ck,"
                        + " "
                        + " (select TongHDKhongCK=COUNT(ID_HOADON),TongGiaBanKhongCK=SUM(GIABAN),TongCongKhongCK=SUM(TONGCONG) from HOADON"
                        + " where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=0)khongck,"
                        + " "
                        + " (select TongHDTon=COUNT(ID_HOADON) from HOADON where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is null)ton";
                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "declare @Nam int;"
                        + " declare @MaTo int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @MaTo=" + MaTo + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                        + " select MaTo=@MaTo,TenTo=(select TenTo from TT_To where MaTo=@MaTo),* from"
                        + " (select TongHD=COUNT(ID_HOADON) from HOADON where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20)tong,"
                        + " "
                        + " (select TongHDCKB=COUNT(ID_HOADON),TongGiaBanCKB=SUM(GIABAN),TongCongCKB=SUM(TONGCONG) from HOADON hd,TAMTHU tt"
                        + " where hd.NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=1"
                        + " and (MaNH like case when '" + MaNH + "'='-1' then '%%' else '" + MaNH + "' end) and hd.ID_HOADON=tt.FK_HOADON)ckb,"
                        + " "
                        + " (select TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd"
                        + " where hd.NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=1 and ID_HOADON not in (select FK_HOADON from TAMTHU))ck,"
                        + " "
                        + " (select TongHDKhongCK=COUNT(ID_HOADON),TongGiaBanKhongCK=SUM(GIABAN),TongCongKhongCK=SUM(TONGCONG) from HOADON"
                        + " where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=0)khongck,"
                        + " "
                        + " (select TongHDTon=COUNT(ID_HOADON) from HOADON where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is null)ton";
                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetPhanTichChuyenKhoan(string Loai, int MaNH, int MaTo, int Nam, int Ky)
        {
            if (Loai == "TG")
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
                        + " select MaTo=@MaTo,TenTo=(select TenTo from TT_To where MaTo=@MaTo),* from"
                        + " (select TongHD=COUNT(ID_HOADON) from HOADON where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20)tong,"
                        + " "
                        + " (select TongHDCKB=COUNT(ID_HOADON),TongGiaBanCKB=SUM(GIABAN),TongCongCKB=SUM(TONGCONG) from HOADON hd,TAMTHU tt"
                        + " where hd.NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=1"
                        + " and (MaNH like case when '" + MaNH + "'='-1' then '%%' else '" + MaNH + "' end) and hd.ID_HOADON=tt.FK_HOADON)ckb,"
                        + " "
                        + " (select TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd"
                        + " where hd.NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=1 and ID_HOADON not in (select FK_HOADON from TAMTHU))ck,"
                        + " "
                        + " (select TongHDKhongCK=COUNT(ID_HOADON),TongGiaBanKhongCK=SUM(GIABAN),TongCongKhongCK=SUM(TONGCONG) from HOADON"
                        + " where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=0)khongck,"
                        + " "
                        + " (select TongHDTon=COUNT(ID_HOADON) from HOADON where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is null)ton";
                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
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
                        + " select MaTo=@MaTo,TenTo=(select TenTo from TT_To where MaTo=@MaTo),* from"
                        + " (select TongHD=COUNT(ID_HOADON) from HOADON where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20)tong,"
                        + " "
                        + " (select TongHDCKB=COUNT(ID_HOADON),TongGiaBanCKB=SUM(GIABAN),TongCongCKB=SUM(TONGCONG) from HOADON hd,TAMTHU tt"
                        + " where hd.NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=1"
                        + " and (MaNH like case when '" + MaNH + "'='-1' then '%%' else '" + MaNH + "' end) and hd.ID_HOADON=tt.FK_HOADON)ckb,"
                        + " "
                        + " (select TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd"
                        + " where hd.NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=1 and ID_HOADON not in (select FK_HOADON from TAMTHU))ck,"
                        + " "
                        + " (select TongHDKhongCK=COUNT(ID_HOADON),TongGiaBanKhongCK=SUM(GIABAN),TongCongKhongCK=SUM(TONGCONG) from HOADON"
                        + " where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=0)khongck,"
                        + " "
                        + " (select TongHDTon=COUNT(ID_HOADON) from HOADON where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is null)ton";
                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetPhanTichChuyenKhoan(string Loai, int MaNH, int MaTo, int Nam, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                string sql = "declare @Nam int;"
                        + " declare @MaTo int;"
                        + " declare @NgayGiaiTrach date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @MaTo=" + MaTo + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                        + " select MaTo=@MaTo,TenTo=(select TenTo from TT_To where MaTo=@MaTo),* from"
                        + " (select TongHD=COUNT(ID_HOADON) from HOADON where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20)tong,"
                        + " "
                        + " (select TongHDCKB=COUNT(ID_HOADON),TongGiaBanCKB=SUM(GIABAN),TongCongCKB=SUM(TONGCONG) from HOADON hd,TAMTHU tt"
                        + " where hd.NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1"
                        + " and (MaNH like case when '" + MaNH + "'='-1' then '%%' else '" + MaNH + "' end) and hd.ID_HOADON=tt.FK_HOADON)ckb,"
                        + " "
                        + " (select TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd"
                        + " where hd.NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1 and ID_HOADON not in (select FK_HOADON from TAMTHU))ck,"
                        + " "
                        + " (select TongHDKhongCK=COUNT(ID_HOADON),TongGiaBanKhongCK=SUM(GIABAN),TongCongKhongCK=SUM(TONGCONG) from HOADON"
                        + " where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=0)khongck,"
                        + " "
                        + " (select TongHDTon=COUNT(ID_HOADON) from HOADON where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach))ton";
                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "declare @Nam int;"
                        + " declare @MaTo int;"
                        + " declare @NgayGiaiTrach date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @MaTo=" + MaTo + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                        + " select MaTo=@MaTo,TenTo=(select TenTo from TT_To where MaTo=@MaTo),* from"
                        + " (select TongHD=COUNT(ID_HOADON) from HOADON where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20)tong,"
                        + " "
                        + " (select TongHDCKB=COUNT(ID_HOADON),TongGiaBanCKB=SUM(GIABAN),TongCongCKB=SUM(TONGCONG) from HOADON hd,TAMTHU tt"
                        + " where hd.NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1"
                        + " and (MaNH like case when '" + MaNH + "'='-1' then '%%' else '" + MaNH + "' end) and hd.ID_HOADON=tt.FK_HOADON)ckb,"
                        + " "
                        + " (select TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd"
                        + " where hd.NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1 and ID_HOADON not in (select FK_HOADON from TAMTHU))ck,"
                        + " "
                        + " (select TongHDKhongCK=COUNT(ID_HOADON),TongGiaBanKhongCK=SUM(GIABAN),TongCongKhongCK=SUM(TONGCONG) from HOADON"
                        + " where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=0)khongck,"
                        + " "
                        + " (select TongHDTon=COUNT(ID_HOADON) from HOADON where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach))ton";
                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetPhanTichChuyenKhoan(string Loai, int MaNH, int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
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
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                        + " select MaTo=@MaTo,TenTo=(select TenTo from TT_To where MaTo=@MaTo),* from"
                        + " (select TongHD=COUNT(ID_HOADON) from HOADON where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20)tong,"
                        + " "
                        + " (select TongHDCKB=COUNT(ID_HOADON),TongGiaBanCKB=SUM(GIABAN),TongCongCKB=SUM(TONGCONG) from HOADON hd,TAMTHU tt"
                        + " where hd.NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1"
                        + " and (MaNH like case when '" + MaNH + "'='-1' then '%%' else '" + MaNH + "' end) and hd.ID_HOADON=tt.FK_HOADON)ckb,"
                        + " "
                        + " (select TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd"
                        + " where hd.NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1 and ID_HOADON not in (select FK_HOADON from TAMTHU))ck,"
                        + " "
                        + " (select TongHDKhongCK=COUNT(ID_HOADON),TongGiaBanKhongCK=SUM(GIABAN),TongCongKhongCK=SUM(TONGCONG) from HOADON"
                        + " where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=0)khongck,"
                        + " "
                        + " (select TongHDTon=COUNT(ID_HOADON) from HOADON where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach))ton";
                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
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
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                        + " select MaTo=@MaTo,TenTo=(select TenTo from TT_To where MaTo=@MaTo),* from"
                        + " (select TongHD=COUNT(ID_HOADON) from HOADON where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20)tong,"
                        + " "
                        + " (select TongHDCKB=COUNT(ID_HOADON),TongGiaBanCKB=SUM(GIABAN),TongCongCKB=SUM(TONGCONG) from HOADON hd,TAMTHU tt"
                        + " where hd.NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1"
                        + " and (MaNH like case when '" + MaNH + "'='-1' then '%%' else '" + MaNH + "' end) and hd.ID_HOADON=tt.FK_HOADON)ckb,"
                        + " "
                        + " (select TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd"
                        + " where hd.NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1 and ID_HOADON not in (select FK_HOADON from TAMTHU))ck,"
                        + " "
                        + " (select TongHDKhongCK=COUNT(ID_HOADON),TongGiaBanKhongCK=SUM(GIABAN),TongCongKhongCK=SUM(TONGCONG) from HOADON"
                        + " where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=0)khongck,"
                        + " "
                        + " (select TongHDTon=COUNT(ID_HOADON) from HOADON where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach))ton";
                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetPhanTichChuyenKhoan_NV(string Loai, int MaNH, int MaTo, int Nam)
        {
            if (Loai == "TG")
            {
                string sql = "declare @Nam int;"
                        + " declare @MaTo int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @MaTo=" + MaTo + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                        + " select tong.MaNV_HanhThu,HoTen=(select HoTen from TT_NguoiDung where MaND=tong.MaNV_HanhThu),* from"
                        + " (select MaNV_HanhThu,TongHD=COUNT(ID_HOADON) from HOADON where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 group by MaNV_HanhThu)tong"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDCKB=COUNT(ID_HOADON),TongGiaBanCKB=SUM(GIABAN),TongCongCKB=SUM(TONGCONG) from HOADON hd,TAMTHU tt"
                        + " where hd.NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=1"
                        + " and (MaNH like case when '" + MaNH + "'='-1' then '%%' else '" + MaNH + "' end) and hd.ID_HOADON=tt.FK_HOADON group by MaNV_HanhThu)ckb on tong.MaNV_HanhThu=ckb.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd"
                        + " where hd.NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=1 and ID_HOADON not in (select FK_HOADON from TAMTHU) group by MaNV_HanhThu)ck on tong.MaNV_HanhThu=ck.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDKhongCK=COUNT(ID_HOADON),TongGiaBanKhongCK=SUM(GIABAN),TongCongKhongCK=SUM(TONGCONG) from HOADON"
                        + " where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=0 group by MaNV_HanhThu)khongck on tong.MaNV_HanhThu=khongck.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDTon=COUNT(ID_HOADON) from HOADON where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is null group by MaNV_HanhThu)ton on tong.MaNV_HanhThu=ton.MaNV_HanhThu"
                        + " order by (select STT from TT_NguoiDung where MaND=tong.MaNV_HanhThu)";
                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "declare @Nam int;"
                        + " declare @MaTo int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @MaTo=" + MaTo + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                        + " select tong.MaNV_HanhThu,HoTen=(select HoTen from TT_NguoiDung where MaND=tong.MaNV_HanhThu),* from"
                        + " (select MaNV_HanhThu,TongHD=COUNT(ID_HOADON) from HOADON where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 group by MaNV_HanhThu)tong"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDCKB=COUNT(ID_HOADON),TongGiaBanCKB=SUM(GIABAN),TongCongCKB=SUM(TONGCONG) from HOADON hd,TAMTHU tt"
                        + " where hd.NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=1"
                        + " and (MaNH like case when '" + MaNH + "'='-1' then '%%' else '" + MaNH + "' end) and hd.ID_HOADON=tt.FK_HOADON group by MaNV_HanhThu)ckb on tong.MaNV_HanhThu=ckb.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd"
                        + " where hd.NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=1 and ID_HOADON not in (select FK_HOADON from TAMTHU) group by MaNV_HanhThu)ck on tong.MaNV_HanhThu=ck.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDKhongCK=COUNT(ID_HOADON),TongGiaBanKhongCK=SUM(GIABAN),TongCongKhongCK=SUM(TONGCONG) from HOADON"
                        + " where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=0 group by MaNV_HanhThu)khongck on tong.MaNV_HanhThu=khongck.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDTon=COUNT(ID_HOADON) from HOADON where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is null group by MaNV_HanhThu)ton on tong.MaNV_HanhThu=ton.MaNV_HanhThu"
                        + " order by (select STT from TT_NguoiDung where MaND=tong.MaNV_HanhThu)";
                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetPhanTichChuyenKhoan_NV(string Loai, int MaNH, int MaTo, int Nam, int Ky)
        {
            if (Loai == "TG")
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
                        + " select tong.MaNV_HanhThu,HoTen=(select HoTen from TT_NguoiDung where MaND=tong.MaNV_HanhThu),* from"
                        + " (select MaNV_HanhThu,TongHD=COUNT(ID_HOADON) from HOADON where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 group by MaNV_HanhThu)tong"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDCKB=COUNT(ID_HOADON),TongGiaBanCKB=SUM(GIABAN),TongCongCKB=SUM(TONGCONG) from HOADON hd,TAMTHU tt"
                        + " where hd.NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=1"
                        + " and (MaNH like case when '" + MaNH + "'='-1' then '%%' else '" + MaNH + "' end) and hd.ID_HOADON=tt.FK_HOADON group by MaNV_HanhThu)ckb on tong.MaNV_HanhThu=ckb.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd"
                        + " where hd.NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=1 and ID_HOADON not in (select FK_HOADON from TAMTHU) group by MaNV_HanhThu)ck on tong.MaNV_HanhThu=ck.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDKhongCK=COUNT(ID_HOADON),TongGiaBanKhongCK=SUM(GIABAN),TongCongKhongCK=SUM(TONGCONG) from HOADON"
                        + " where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=0 group by MaNV_HanhThu)khongck on tong.MaNV_HanhThu=khongck.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDTon=COUNT(ID_HOADON) from HOADON where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is null group by MaNV_HanhThu)ton on tong.MaNV_HanhThu=ton.MaNV_HanhThu"
                        + " order by (select STT from TT_NguoiDung where MaND=tong.MaNV_HanhThu)";
                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
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
                        + " select tong.MaNV_HanhThu,HoTen=(select HoTen from TT_NguoiDung where MaND=tong.MaNV_HanhThu),* from"
                        + " (select MaNV_HanhThu,TongHD=COUNT(ID_HOADON) from HOADON where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 group by MaNV_HanhThu)tong"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDCKB=COUNT(ID_HOADON),TongGiaBanCKB=SUM(GIABAN),TongCongCKB=SUM(TONGCONG) from HOADON hd,TAMTHU tt"
                        + " where hd.NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=1"
                        + " and (MaNH like case when '" + MaNH + "'='-1' then '%%' else '" + MaNH + "' end) and hd.ID_HOADON=tt.FK_HOADON group by MaNV_HanhThu)ckb on tong.MaNV_HanhThu=ckb.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd"
                        + " where hd.NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=1 and ID_HOADON not in (select FK_HOADON from TAMTHU) group by MaNV_HanhThu)ck on tong.MaNV_HanhThu=ck.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDKhongCK=COUNT(ID_HOADON),TongGiaBanKhongCK=SUM(GIABAN),TongCongKhongCK=SUM(TONGCONG) from HOADON"
                        + " where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and DangNgan_ChuyenKhoan=0 group by MaNV_HanhThu)khongck on tong.MaNV_HanhThu=khongck.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDTon=COUNT(ID_HOADON) from HOADON where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is null group by MaNV_HanhThu)ton on tong.MaNV_HanhThu=ton.MaNV_HanhThu"
                        + " order by (select STT from TT_NguoiDung where MaND=tong.MaNV_HanhThu)";
                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetPhanTichChuyenKhoan_NV(string Loai, int MaNH, int MaTo, int Nam, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                string sql = "declare @Nam int;"
                                 + " declare @MaTo int;"
                                 + " declare @NgayGiaiTrach date;"
                                 + " declare @TuCuonGCS int;"
                                 + " declare @DenCuonGCS int;"
                                 + " set @Nam=" + Nam + ";"
                                 + " set @MaTo=" + MaTo + ";"
                                 + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                                 + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                                 + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                                 + " select tong.MaNV_HanhThu,HoTen=(select HoTen from TT_NguoiDung where MaND=tong.MaNV_HanhThu),* from"
                                 + " (select MaNV_HanhThu,TongHD=COUNT(ID_HOADON) from HOADON where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 group by MaNV_HanhThu)tong"
                                 + " left join"
                                 + " (select MaNV_HanhThu,TongHDCKB=COUNT(ID_HOADON),TongGiaBanCKB=SUM(GIABAN),TongCongCKB=SUM(TONGCONG) from HOADON hd,TAMTHU tt"
                                 + " where hd.NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1"
                                 + " and (MaNH like case when '" + MaNH + "'='-1' then '%%' else '" + MaNH + "' end) and hd.ID_HOADON=tt.FK_HOADON group by MaNV_HanhThu)ckb on tong.MaNV_HanhThu=ckb.MaNV_HanhThu"
                                 + " left join"
                                 + " (select MaNV_HanhThu,TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd"
                                 + " where hd.NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1 and ID_HOADON not in (select FK_HOADON from TAMTHU) group by MaNV_HanhThu)ck on tong.MaNV_HanhThu=ck.MaNV_HanhThu"
                                 + " left join"
                                 + " (select MaNV_HanhThu,TongHDKhongCK=COUNT(ID_HOADON),TongGiaBanKhongCK=SUM(GIABAN),TongCongKhongCK=SUM(TONGCONG) from HOADON"
                                 + " where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=0 group by MaNV_HanhThu)khongck on tong.MaNV_HanhThu=khongck.MaNV_HanhThu"
                                 + " left join"
                                 + " (select MaNV_HanhThu,TongHDTon=COUNT(ID_HOADON) from HOADON where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach) group by MaNV_HanhThu)ton on tong.MaNV_HanhThu=ton.MaNV_HanhThu"
                                 + " order by (select STT from TT_NguoiDung where MaND=tong.MaNV_HanhThu)";
                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "declare @Nam int;"
                                + " declare @MaTo int;"
                                + " declare @NgayGiaiTrach date;"
                                + " declare @TuCuonGCS int;"
                                + " declare @DenCuonGCS int;"
                                + " set @Nam=" + Nam + ";"
                                + " set @MaTo=" + MaTo + ";"
                                + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                                + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                                + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                                + " select tong.MaNV_HanhThu,HoTen=(select HoTen from TT_NguoiDung where MaND=tong.MaNV_HanhThu),* from"
                                + " (select MaNV_HanhThu,TongHD=COUNT(ID_HOADON) from HOADON where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 group by MaNV_HanhThu)tong"
                                + " left join"
                                + " (select MaNV_HanhThu,TongHDCKB=COUNT(ID_HOADON),TongGiaBanCKB=SUM(GIABAN),TongCongCKB=SUM(TONGCONG) from HOADON hd,TAMTHU tt"
                                + " where hd.NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1"
                                + " and (MaNH like case when '" + MaNH + "'='-1' then '%%' else '" + MaNH + "' end) and hd.ID_HOADON=tt.FK_HOADON group by MaNV_HanhThu)ckb on tong.MaNV_HanhThu=ckb.MaNV_HanhThu"
                                + " left join"
                                + " (select MaNV_HanhThu,TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd"
                                + " where hd.NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1 and ID_HOADON not in (select FK_HOADON from TAMTHU) group by MaNV_HanhThu)ck on tong.MaNV_HanhThu=ck.MaNV_HanhThu"
                                + " left join"
                                + " (select MaNV_HanhThu,TongHDKhongCK=COUNT(ID_HOADON),TongGiaBanKhongCK=SUM(GIABAN),TongCongKhongCK=SUM(TONGCONG) from HOADON"
                                + " where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=0 group by MaNV_HanhThu)khongck on tong.MaNV_HanhThu=khongck.MaNV_HanhThu"
                                + " left join"
                                + " (select MaNV_HanhThu,TongHDTon=COUNT(ID_HOADON) from HOADON where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach) group by MaNV_HanhThu)ton on tong.MaNV_HanhThu=ton.MaNV_HanhThu"
                                + " order by (select STT from TT_NguoiDung where MaND=tong.MaNV_HanhThu)";
                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetPhanTichChuyenKhoan_NV(string Loai, int MaNH, int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
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
                                 + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                                 + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                                 + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                                 + " select tong.MaNV_HanhThu,HoTen=(select HoTen from TT_NguoiDung where MaND=tong.MaNV_HanhThu),* from"
                                 + " (select MaNV_HanhThu,TongHD=COUNT(ID_HOADON) from HOADON where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 group by MaNV_HanhThu)tong"
                                 + " left join"
                                 + " (select MaNV_HanhThu,TongHDCKB=COUNT(ID_HOADON),TongGiaBanCKB=SUM(GIABAN),TongCongCKB=SUM(TONGCONG) from HOADON hd,TAMTHU tt"
                                 + " where hd.NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1"
                                 + " and (MaNH like case when '" + MaNH + "'='-1' then '%%' else '" + MaNH + "' end) and hd.ID_HOADON=tt.FK_HOADON group by MaNV_HanhThu)ckb on tong.MaNV_HanhThu=ckb.MaNV_HanhThu"
                                 + " left join"
                                 + " (select MaNV_HanhThu,TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd"
                                 + " where hd.NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1 and ID_HOADON not in (select FK_HOADON from TAMTHU) group by MaNV_HanhThu)ck on tong.MaNV_HanhThu=ck.MaNV_HanhThu"
                                 + " left join"
                                 + " (select MaNV_HanhThu,TongHDKhongCK=COUNT(ID_HOADON),TongGiaBanKhongCK=SUM(GIABAN),TongCongKhongCK=SUM(TONGCONG) from HOADON"
                                 + " where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=0 group by MaNV_HanhThu)khongck on tong.MaNV_HanhThu=khongck.MaNV_HanhThu"
                                 + " left join"
                                 + " (select MaNV_HanhThu,TongHDTon=COUNT(ID_HOADON) from HOADON where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>=11 and GB<=20 and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach) group by MaNV_HanhThu)ton on tong.MaNV_HanhThu=ton.MaNV_HanhThu"
                                 + " order by (select STT from TT_NguoiDung where MaND=tong.MaNV_HanhThu)";
                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
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
                                 + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                                 + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                                 + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                                 + " select tong.MaNV_HanhThu,HoTen=(select HoTen from TT_NguoiDung where MaND=tong.MaNV_HanhThu),* from"
                                 + " (select MaNV_HanhThu,TongHD=COUNT(ID_HOADON) from HOADON where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 group by MaNV_HanhThu)tong"
                                 + " left join"
                                 + " (select MaNV_HanhThu,TongHDCKB=COUNT(ID_HOADON),TongGiaBanCKB=SUM(GIABAN),TongCongCKB=SUM(TONGCONG) from HOADON hd,TAMTHU tt"
                                 + " where hd.NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1"
                                 + " and (MaNH like case when '" + MaNH + "'='-1' then '%%' else '" + MaNH + "' end) and hd.ID_HOADON=tt.FK_HOADON group by MaNV_HanhThu)ckb on tong.MaNV_HanhThu=ckb.MaNV_HanhThu"
                                 + " left join"
                                 + " (select MaNV_HanhThu,TongHDCK=COUNT(ID_HOADON),TongGiaBanCK=SUM(GIABAN),TongCongCK=SUM(TONGCONG) from HOADON hd"
                                 + " where hd.NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1 and ID_HOADON not in (select FK_HOADON from TAMTHU) group by MaNV_HanhThu)ck on tong.MaNV_HanhThu=ck.MaNV_HanhThu"
                                 + " left join"
                                 + " (select MaNV_HanhThu,TongHDKhongCK=COUNT(ID_HOADON),TongGiaBanKhongCK=SUM(GIABAN),TongCongKhongCK=SUM(TONGCONG) from HOADON"
                                 + " where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and DangNgan_ChuyenKhoan=0 group by MaNV_HanhThu)khongck on tong.MaNV_HanhThu=khongck.MaNV_HanhThu"
                                 + " left join"
                                 + " (select MaNV_HanhThu,TongHDTon=COUNT(ID_HOADON) from HOADON where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and GB>20 and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach) group by MaNV_HanhThu)ton on tong.MaNV_HanhThu=ton.MaNV_HanhThu"
                                 + " order by (select STT from TT_NguoiDung where MaND=tong.MaNV_HanhThu)";
                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetDS_XuatExcel(int MaTo,int Nam)
        {
            string sql = "declare @Nam int;"
                        + " declare @MaTo int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @MaTo="+MaTo+";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                        + " select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                        + " 'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),GiaBan,TONGCONG,DangNgan=N'Chuyển Khoản',TenNH=NGANHANG,GiaBieu=GB,TieuThu,DinhMuc=DM,DinhMucHN"
                        + " from TAMTHU tt,HOADON hd,NGANHANG nh"
                        + " where NAM=@Nam and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH like '%%'"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                        + " union all"
                        + " select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                        + " 'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),GiaBan,TONGCONG,DangNgan=N'Chuyển Khoản',TenNH=N'',GiaBieu=GB,TieuThu,DinhMuc=DM,DinhMucHN"
                        + " from TAMTHU tt,HOADON hd"
                        + " where NAM=@Nam and hd.ID_HOADON=tt.FK_HOADON and MaNH is null"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                        + " union all"
                        + " select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                        + " 'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),GiaBan,TONGCONG,DangNgan=N'Chuyển Khoản',TenNH=N'Khác',GiaBieu=GB,TieuThu,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " where NAM=@Nam and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                        + " union all"
                        + " select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                        + " 'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),GiaBan,TONGCONG,"
                        + " DangNgan=case when DangNgan_HanhThu=1 then N'Hành Thu' when DangNgan_Ton=1 then N'Đăng Ngân Tồn' when DangNgan_Quay=1 then N'Quầy' end,TenNH=N'',GiaBieu=GB,TieuThu,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=0 and NGAYGIAITRACH is not null"
                        + " union all"
                        + " select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                        + " 'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),GiaBan,TONGCONG,"
                        + " DangNgan=N'',TenNH=N'',GiaBieu=GB,TieuThu,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " where NAM=@Nam and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and NGAYGIAITRACH is null"
                        + " order by MALOTRINH asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDS_XuatExcel(int MaTo, int Nam, int Ky)
        {
            string sql = "declare @Nam int;"
                        + " declare @MaTo int;"
                        + " declare @Ky int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @MaTo=" + MaTo + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=@MaTo);"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=@MaTo);"
                        + " select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                        + " 'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),GiaBan,TONGCONG,DangNgan=N'Chuyển Khoản',TenNH=NGANHANG,GiaBieu=GB,TieuThu,DinhMuc=DM,DinhMucHN"
                        + " from TAMTHU tt,HOADON hd,NGANHANG nh"
                        + " where NAM=@Nam and KY=@Ky and hd.ID_HOADON=tt.FK_HOADON and nh.ID_NGANHANG=tt.MaNH and MaNH like '%%'"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                        + " union all"
                        + " select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                        + " 'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),GiaBan,TONGCONG,DangNgan=N'Chuyển Khoản',TenNH=N'',GiaBieu=GB,TieuThu,DinhMuc=DM,DinhMucHN"
                        + " from TAMTHU tt,HOADON hd"
                        + " where NAM=@Nam and KY=@Ky and hd.ID_HOADON=tt.FK_HOADON and MaNH is null"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                        + " union all"
                        + " select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                        + " 'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),GiaBan,TONGCONG,DangNgan=N'Chuyển Khoản',TenNH=N'Khác',GiaBieu=GB,TieuThu,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " where NAM=@Nam and KY=@Ky and ID_HOADON not in (select FK_HOADON from TAMTHU)"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=1 and NGAYGIAITRACH is not null"
                        + " union all"
                        + " select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                        + " 'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),GiaBan,TONGCONG,"
                        + " DangNgan=case when DangNgan_HanhThu=1 then N'Hành Thu' when DangNgan_Ton=1 then N'Đăng Ngân Tồn' when DangNgan_Quay=1 then N'Quầy' end,TenNH=N'',GiaBieu=GB,TieuThu,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and DangNgan_ChuyenKhoan=0 and NGAYGIAITRACH is not null"
                        + " union all"
                        + " select MLT=MALOTRINH,hd.SoHoaDon,Ky=CONVERT(varchar(2),hd.Ky)+'/'+CONVERT(varchar(4),hd.Nam),DanhBo=hd.DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,NGAYGIAITRACH,"
                        + " 'To'=(select TenTo from TT_To where MaTo=@MaTo),HanhThu=(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu),GiaBan,TONGCONG,"
                        + " DangNgan=N'',TenNH=N'',GiaBieu=GB,TieuThu,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " where NAM=@Nam and KY=@Ky and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS and NGAYGIAITRACH is null"
                        + " order by MALOTRINH asc";

            return ExecuteQuery_DataTable(sql);
        }
    }
}

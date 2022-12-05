using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DocSo_PC.LinQ;

namespace DocSo_PC.DAL
{
    class CThuongVu
    {
        public static dbThuongVuDataContext _db = new dbThuongVuDataContext();
        public static CConnection _cDAL = new CConnection(_db.Connection.ConnectionString);
        wrThuongVu.wsThuongVu _wsThuongVu = new wrThuongVu.wsThuongVu();

        public DataTable getDS_KTXM_ChuaNhan(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select ktxmct.DanhBo,ktxmct.HoTen,ktxmct.DiaChi,NoiDung=ktxmct.NoiDungKiemTra,NgayLap=ktxmct.NgayKTXM,NgayChuyen=cvd.CreateDate"
                        + " ,MLT=(select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=ktxmct.DanhBo),cvd.ID,Nhan_QLDHN"
                        + " ,MaDon=cvd.Ma,LoaiVB=N'Biên Bản Kiểm Tra',TableName='KTXM_ChiTiet',IDCT=CAST(ktxmct.MaCTKTXM as int),NoiChuyen=N'P. Thương Vụ'"
                        + " from CongVanDi cvd,KTXM ktxm,KTXM_ChiTiet ktxmct"
                        + " where CAST(cvd.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(cvd.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'"
                        + " and NoiChuyen=N'Đội QLĐHN' and KTXM=1 and ktxm.MaKTXM=ktxmct.MaKTXM"
                        + " and ktxm.MaDonMoi=case when cvd.Ma like '%.%' then SUBSTRING(Ma,0,9) else Ma end"
                        + " and ktxmct.STT=case when cvd.Ma like '%.%' then RIGHT(Ma,LEN(Ma)-9) else 1 end"
                //+ " and ktxmct.MaCTKTXM not in (select IDCT from DocSoTH.dbo.CongVanDen where TableName='KTXM_ChiTiet')"
                        + " order by cvd.CreateDate asc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ToTrinh_ChuaNhan(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select ttct.DanhBo,ttct.HoTen,ttct.DiaChi,NoiDung=ttct.VeViec,NgayLap=ttct.CreateDate,NgayChuyen=cvd.CreateDate"
                         + " ,MLT=(select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=ttct.DanhBo),cvd.ID,Nhan_QLDHN"
                         + " ,MaDon=cvd.Ma,LoaiVB=N'Tờ Trình',TableName='ToTrinh_ChiTiet',IDCT=CAST(ttct.IDCT as int),NoiChuyen=N'P. Thương Vụ'"
                         + " from CongVanDi cvd,ToTrinh tt,ToTrinh_ChiTiet ttct"
                         + " where CAST(cvd.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(cvd.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'"
                         + " and NoiChuyen=N'Đội QLĐHN' and ToTrinh=1 and tt.ID=ttct.ID"
                         + " and tt.MaDonMoi=case when cvd.Ma like '%.%' then SUBSTRING(Ma,0,9) else Ma end"
                         + " and ttct.STT=case when cvd.Ma like '%.%' then RIGHT(Ma,LEN(Ma)-9) else 1 end"
                //+ " and ttct.IDCT not in (select IDCT from DocSoTH.dbo.CongVanDen where TableName='ToTrinh_ChiTiet')"
                         + " order by cvd.CreateDate asc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_KTXM(int MaDon, int STT)
        {
            return _cDAL.ExecuteQuery_DataTable("select t1.*,'To'=(select TenTo from DocSoTH.dbo.[To] where TuMay<=SUBSTRING(t1.MLT,3,2) and DenMay>=SUBSTRING(t1.MLT,3,2)) from"
                + " (select LoaiVB=N'Kiểm Tra Xác Minh',NoiChuyen=N'P. Thương Vụ',DanhBo,HoTen,DiaChi"
                + " ,MLT=(select top 1 * from (select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=ctktxm.DanhBo and LOTRINH is not null union select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG_HUYDB where DanhBo=ctktxm.DanhBo and LOTRINH is not null)t2)"
            + " ,NoiDung=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=ktxm.MaDonMoi)=1) then CONVERT(varchar(10),ktxm.MaDonMoi) else CONVERT(varchar(10),ktxm.MaDonMoi)+'.'+CONVERT(varchar(10),ctktxm.STT) end+' - BBKT - '+convert(varchar(10),ctktxm.NgayKTXM,103)+' - CS: '+ctktxm.ChiSo+' '+isnull(ctktxm.TinhTrangChiSo,'')+'. V/v '+ctktxm.NoiDungKiemTra+' - '+(select HoTen from Users where MaU=ctktxm.CreateBy)"
            + " ,MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=ktxm.MaDonMoi)=1) then CONVERT(varchar(10),ktxm.MaDonMoi) else CONVERT(varchar(10),ktxm.MaDonMoi)+'.'+CONVERT(varchar(10),ctktxm.STT) end"
            + " ,TableName='KTXM_ChiTiet',IDCT=CAST(ctktxm.MaCTKTXM as int),ToMaHoa='false'"
            + " from KTXM ktxm,KTXM_ChiTiet ctktxm where ktxm.MaKTXM=ctktxm.MaKTXM and ktxm.MaDonMoi=" + MaDon + " and ctktxm.STT=" + STT + ")t1");
        }

        public DataTable getDS_KTXM(string DanhBo)
        {
            return _cDAL.ExecuteQuery_DataTable("select t1.*,'To'=(select TenTo from DocSoTH.dbo.[To] where TuMay<=SUBSTRING(t1.MLT,3,2) and DenMay>=SUBSTRING(t1.MLT,3,2)) from"
                + " (select LoaiVB=N'Kiểm Tra Xác Minh',NoiChuyen=N'P. Thương Vụ',DanhBo,HoTen,DiaChi"
                + " ,MLT=(select top 1 * from (select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=ctktxm.DanhBo and LOTRINH is not null union select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG_HUYDB where DanhBo=ctktxm.DanhBo and LOTRINH is not null)t2)"
            + " ,NoiDung=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=ktxm.MaDonMoi)=1) then CONVERT(varchar(10),ktxm.MaDonMoi) else CONVERT(varchar(10),ktxm.MaDonMoi)+'.'+CONVERT(varchar(10),ctktxm.STT) end+' - BBKT - '+convert(varchar(10),ctktxm.NgayKTXM,103)+' - CS: '+ctktxm.ChiSo+' '+isnull(ctktxm.TinhTrangChiSo,'')+'. V/v '+ctktxm.NoiDungKiemTra+' - '+(select HoTen from Users where MaU=ctktxm.CreateBy)"
            + " ,MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=ktxm.MaDonMoi)=1) then CONVERT(varchar(10),ktxm.MaDonMoi) else CONVERT(varchar(10),ktxm.MaDonMoi)+'.'+CONVERT(varchar(10),ctktxm.STT) end"
            + " ,TableName='KTXM_ChiTiet',IDCT=CAST(ctktxm.MaCTKTXM as int),ToMaHoa='false'"
            + " from KTXM ktxm,KTXM_ChiTiet ctktxm where ktxm.MaKTXM=ctktxm.MaKTXM and ctktxm.DanhBo='" + DanhBo + "')t1");
        }

        public DataTable getDS_CHDB(int MaDon, int STT)
        {
            return _cDAL.ExecuteQuery_DataTable("select t1.*,'To'=(select TenTo from DocSoTH.dbo.[To] where TuMay<=SUBSTRING(t1.MLT,3,2) and DenMay>=SUBSTRING(t1.MLT,3,2)) from"
            + " (select LoaiVB=N'TB Cắt Tạm',NoiChuyen=N'P. Thương Vụ',DanhBo,HoTen,DiaChi"
                + " ,MLT=(select top 1 * from (select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=ct.DanhBo and LOTRINH is not null union select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG_HUYDB where DanhBo=ct.DanhBo and LOTRINH is not null)t2)"
             + " ,NoiDung=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=chdb.MaDonMoi)=1) then CONVERT(varchar(10),chdb.MaDonMoi) else CONVERT(varchar(10),chdb.MaDonMoi)+'.'+CONVERT(varchar(10),ct.STT) end+N' - TB Cắt Tạm - '+convert(varchar(10),ct.CreateDate,103)+N'. Lý do: '+ct.LyDo+' '+isnull(CONVERT(varchar(20),ct.SoTien),'')+' '+isnull(GhiChuLyDo,'')+' - '+COALESCE(convert(varchar(10),ct.NgayThucHien,103),'')+' - '+(select HoTen from Users where MaU=ct.CreateBy)"
             + " ,MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=chdb.MaDonMoi)=1) then CONVERT(varchar(10),chdb.MaDonMoi) else CONVERT(varchar(10),chdb.MaDonMoi)+'.'+CONVERT(varchar(10),ct.STT) end"
             + " ,TableName='CHDB_ChiTietCatTam',IDCT=CAST(ct.MaCTCTDB as int),ToMaHoa='false'"
             + " from CHDB chdb,CHDB_ChiTietCatTam ct where chdb.MaCHDB=ct.MaCHDB and chdb.MaDonMoi=" + MaDon + " and ct.STT=" + STT
             + " union"
             + " select LoaiVB=N'TB Cắt Hủy',NoiChuyen=N'P. Thương Vụ',DanhBo,HoTen,DiaChi"
                + " ,MLT=(select top 1 * from (select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=ct.DanhBo and LOTRINH is not null union select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG_HUYDB where DanhBo=ct.DanhBo and LOTRINH is not null)t2)"
             + " ,NoiDung=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=chdb.MaDonMoi)=1) then CONVERT(varchar(10),chdb.MaDonMoi) else CONVERT(varchar(10),chdb.MaDonMoi)+'.'+CONVERT(varchar(10),ct.STT) end+N' - TB Cắt Hủy - '+convert(varchar(10),ct.CreateDate,103)+N'. Lý do: '+ct.LyDo+' '+isnull(CONVERT(varchar(20),ct.SoTien),'')+' '+isnull(GhiChuLyDo,'')+' - '+COALESCE(convert(varchar(10),ct.NgayThucHien,103),'')+' - '+(select HoTen from Users where MaU=ct.CreateBy)"
             + " ,MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=chdb.MaDonMoi)=1) then CONVERT(varchar(10),chdb.MaDonMoi) else CONVERT(varchar(10),chdb.MaDonMoi)+'.'+CONVERT(varchar(10),ct.STT) end"
             + " ,TableName='CHDB_ChiTietCatHuy',IDCT=CAST(ct.MaCTCHDB as int),ToMaHoa='false'"
             + " from CHDB chdb,CHDB_ChiTietCatHuy ct where chdb.MaCHDB=ct.MaCHDB and chdb.MaDonMoi=" + MaDon + " and ct.STT=" + STT
             + " union"
             + " select LoaiVB=N'Phiếu Hủy',NoiChuyen=N'P. Thương Vụ',DanhBo,HoTen,DiaChi"
             + "    ,MLT=(select top 1 * from (select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=ct.DanhBo and LOTRINH is not null union select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG_HUYDB where DanhBo=ct.DanhBo and LOTRINH is not null)t2)"
             + " ,NoiDung=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=chdb.MaDonMoi)=1) then CONVERT(varchar(10),chdb.MaDonMoi) else CONVERT(varchar(10),chdb.MaDonMoi)+'.'+CONVERT(varchar(10),ct.STT) end+N' - Phiếu Hủy - '+convert(varchar(10),ct.CreateDate,103)+N'. Lý do: '+ct.LyDo+' '+isnull(CONVERT(varchar(20),ct.SoTien),'')+' '+isnull(GhiChuLyDo,'')+' - '+(select HoTen from Users where MaU=ct.CreateBy)"
             + " ,MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=chdb.MaDonMoi)=1) then CONVERT(varchar(10),chdb.MaDonMoi) else CONVERT(varchar(10),chdb.MaDonMoi)+'.'+CONVERT(varchar(10),ct.STT) end"
             + " ,TableName='CHDB_Phieu',IDCT=CAST(ct.MaYCCHDB as int),ToMaHoa='false'"
             + " from CHDB chdb,CHDB_Phieu ct where chdb.MaCHDB=ct.MaCHDB and chdb.MaDonMoi=" + MaDon + " and ct.STT=" + STT + ")t1");
        }

        public DataTable getDS_CHDB(string DanhBo)
        {
            return _cDAL.ExecuteQuery_DataTable("select t1.*,'To'=(select TenTo from DocSoTH.dbo.[To] where TuMay<=SUBSTRING(t1.MLT,3,2) and DenMay>=SUBSTRING(t1.MLT,3,2)) from"
            + " (select LoaiVB=N'TB Cắt Tạm',NoiChuyen=N'P. Thương Vụ',DanhBo,HoTen,DiaChi"
                + " ,MLT=(select top 1 * from (select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=ct.DanhBo and LOTRINH is not null union select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG_HUYDB where DanhBo=ct.DanhBo and LOTRINH is not null)t2)"
             + " ,NoiDung=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=chdb.MaDonMoi)=1) then CONVERT(varchar(10),chdb.MaDonMoi) else CONVERT(varchar(10),chdb.MaDonMoi)+'.'+CONVERT(varchar(10),ct.STT) end+N' - TB Cắt Tạm - '+convert(varchar(10),ct.CreateDate,103)+N'. Lý do: '+ct.LyDo+' '+isnull(CONVERT(varchar(20),ct.SoTien),'')+' '+isnull(GhiChuLyDo,'')+' - '+COALESCE(convert(varchar(10),ct.NgayThucHien,103),'')+' - '+(select HoTen from Users where MaU=ct.CreateBy)"
             + " ,MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=chdb.MaDonMoi)=1) then CONVERT(varchar(10),chdb.MaDonMoi) else CONVERT(varchar(10),chdb.MaDonMoi)+'.'+CONVERT(varchar(10),ct.STT) end"
             + " ,TableName='CHDB_ChiTietCatTam',IDCT=CAST(ct.MaCTCTDB as int),ToMaHoa='false'"
             + " from CHDB chdb,CHDB_ChiTietCatTam ct where chdb.MaCHDB=ct.MaCHDB and ct.DanhBo='" + DanhBo + "'"
             + " union"
             + " select LoaiVB=N'TB Cắt Hủy',NoiChuyen=N'P. Thương Vụ',DanhBo,HoTen,DiaChi"
                + " ,MLT=(select top 1 * from (select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=ct.DanhBo and LOTRINH is not null union select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG_HUYDB where DanhBo=ct.DanhBo and LOTRINH is not null)t2)"
             + " ,NoiDung=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=chdb.MaDonMoi)=1) then CONVERT(varchar(10),chdb.MaDonMoi) else CONVERT(varchar(10),chdb.MaDonMoi)+'.'+CONVERT(varchar(10),ct.STT) end+N' - TB Cắt Hủy - '+convert(varchar(10),ct.CreateDate,103)+N'. Lý do: '+ct.LyDo+' '+isnull(CONVERT(varchar(20),ct.SoTien),'')+' '+isnull(GhiChuLyDo,'')+' - '+COALESCE(convert(varchar(10),ct.NgayThucHien,103),'')+' - '+(select HoTen from Users where MaU=ct.CreateBy)"
             + " ,MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=chdb.MaDonMoi)=1) then CONVERT(varchar(10),chdb.MaDonMoi) else CONVERT(varchar(10),chdb.MaDonMoi)+'.'+CONVERT(varchar(10),ct.STT) end"
             + " ,TableName='CHDB_ChiTietCatHuy',IDCT=CAST(ct.MaCTCHDB as int),ToMaHoa='false'"
             + " from CHDB chdb,CHDB_ChiTietCatHuy ct where chdb.MaCHDB=ct.MaCHDB and ct.DanhBo='" + DanhBo + "'"
             + " union"
             + " select LoaiVB=N'Phiếu Hủy',NoiChuyen=N'P. Thương Vụ',DanhBo,HoTen,DiaChi"
             + "    ,MLT=(select top 1 * from (select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=ct.DanhBo and LOTRINH is not null union select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG_HUYDB where DanhBo=ct.DanhBo and LOTRINH is not null)t2)"
             + " ,NoiDung=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=chdb.MaDonMoi)=1) then CONVERT(varchar(10),chdb.MaDonMoi) else CONVERT(varchar(10),chdb.MaDonMoi)+'.'+CONVERT(varchar(10),ct.STT) end+N' - Phiếu Hủy - '+convert(varchar(10),ct.CreateDate,103)+N'. Lý do: '+ct.LyDo+' '+isnull(CONVERT(varchar(20),ct.SoTien),'')+' '+isnull(GhiChuLyDo,'')+' - '+(select HoTen from Users where MaU=ct.CreateBy)"
             + " ,MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=chdb.MaDonMoi)=1) then CONVERT(varchar(10),chdb.MaDonMoi) else CONVERT(varchar(10),chdb.MaDonMoi)+'.'+CONVERT(varchar(10),ct.STT) end"
             + " ,TableName='CHDB_Phieu',IDCT=CAST(ct.MaYCCHDB as int),ToMaHoa='false'"
             + " from CHDB chdb,CHDB_Phieu ct where chdb.MaCHDB=ct.MaCHDB and ct.DanhBo='13031133093')t1");
        }

        public DataTable getDS_ToTrinh(int MaDon, int STT)
        {
            return _cDAL.ExecuteQuery_DataTable("select t1.*,'To'=(select TenTo from DocSoTH.dbo.[To] where TuMay<=SUBSTRING(t1.MLT,3,2) and DenMay>=SUBSTRING(t1.MLT,3,2)) from"
            + " (select LoaiVB=N'Tờ Trình',NoiChuyen=N'P. Thương Vụ',DanhBo,HoTen,DiaChi"
                + " ,MLT=(select top 1 * from (select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=ct.DanhBo and LOTRINH is not null union select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG_HUYDB where DanhBo=ct.DanhBo and LOTRINH is not null)t2)"
              + " ,NoiDung=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=tt.MaDonMoi)=1) then CONVERT(varchar(10),tt.MaDonMoi) else CONVERT(varchar(10),tt.MaDonMoi)+'.'+CONVERT(varchar(10),ct.STT) end+N' - Tờ Trình - '+convert(varchar(10),ct.CreateDate,103)+'. V/v '+ct.VeViec+' - '+(select HoTen from Users where MaU=ct.CreateBy)"
              + " ,MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=tt.MaDonMoi)=1) then CONVERT(varchar(10),tt.MaDonMoi) else CONVERT(varchar(10),tt.MaDonMoi)+'.'+CONVERT(varchar(10),ct.STT) end"
              + " ,TableName='ToTrinh_ChiTiet',IDCT=CAST(ct.IDCT as int),ToMaHoa='false'"
              + " from ToTrinh tt,ToTrinh_ChiTiet ct where tt.ID=ct.ID and tt.MaDonMoi=" + MaDon + " and ct.STT=" + STT + ")t1");
        }

        public DataTable getDS_ToTrinh(string DanhBo)
        {
            return _cDAL.ExecuteQuery_DataTable("select t1.*,'To'=(select TenTo from DocSoTH.dbo.[To] where TuMay<=SUBSTRING(t1.MLT,3,2) and DenMay>=SUBSTRING(t1.MLT,3,2)) from"
            + " (select LoaiVB=N'Tờ Trình',NoiChuyen=N'P. Thương Vụ',DanhBo,HoTen,DiaChi"
                + " ,MLT=(select top 1 * from (select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=ct.DanhBo and LOTRINH is not null union select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG_HUYDB where DanhBo=ct.DanhBo and LOTRINH is not null)t2)"
              + " ,NoiDung=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=tt.MaDonMoi)=1) then CONVERT(varchar(10),tt.MaDonMoi) else CONVERT(varchar(10),tt.MaDonMoi)+'.'+CONVERT(varchar(10),ct.STT) end+N' - Tờ Trình - '+convert(varchar(10),ct.CreateDate,103)+'. V/v '+ct.VeViec+' - '+(select HoTen from Users where MaU=ct.CreateBy)"
              + " ,MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=tt.MaDonMoi)=1) then CONVERT(varchar(10),tt.MaDonMoi) else CONVERT(varchar(10),tt.MaDonMoi)+'.'+CONVERT(varchar(10),ct.STT) end"
              + " ,TableName='ToTrinh_ChiTiet',IDCT=CAST(ct.IDCT as int),ToMaHoa='false'"
              + " from ToTrinh tt,ToTrinh_ChiTiet ct where tt.ID=ct.ID and ct.DanhBo='" + DanhBo + "')t1");
        }

        public byte[] getHinh_KTXM(int IDCT)
        {
            object filename = _cDAL.ExecuteQuery_ReturnOneValue("select [Name]+'.'+Loai from KTXM_ChiTiet_Hinh where IDKTXM_ChiTiet=" + IDCT);
            if (filename != null)
                return _wsThuongVu.get_Hinh("KTXM_ChiTiet_Hinh", IDCT.ToString(), filename.ToString());
            else return null;
        }

        public byte[] getHinh_ToTrinh(int IDCT)
        {
            object filename = _cDAL.ExecuteQuery_ReturnOneValue("select [Name]+'.'+Loai from ToTrinh_ChiTiet_Hinh where IDToTrinh_ChiTiet=" + IDCT);
            if (filename != null)
                return _wsThuongVu.get_Hinh("ToTrinh_ChiTiet_Hinh", IDCT.ToString(), filename.ToString());
            else return null;
        }

        public DataTable getGiaNuoc(string Nam)
        {
            return _cDAL.ExecuteQuery_DataTable("select top 1 * from GiaNuoc2 where Name<=" + Nam + " order by Name desc");
        }

        public string getChucVu_Duyet()
        {
            return _cDAL.ExecuteQuery_ReturnOneValue("select ChucVu from BanGiamDoc where KyTen=1").ToString();
        }

        public string getNguoiKy_Duyet()
        {
            return _cDAL.ExecuteQuery_ReturnOneValue("select HoTen from BanGiamDoc where KyTen=1").ToString();
        }

        public string getChucVu_GDDuyet()
        {
            return _cDAL.ExecuteQuery_ReturnOneValue("select ChucVu from BanGiamDoc where KyTenDuyet=1").ToString();
        }

        public string getNguoiKy_GDDuyet()
        {
            return _cDAL.ExecuteQuery_ReturnOneValue("select HoTen from BanGiamDoc where KyTenDuyet=1").ToString();
        }

        public LinQ.DonTu get(decimal MaDon)
        {
            return _db.DonTus.SingleOrDefault(item => item.MaDon == MaDon);
        }

        public DonTu_ChiTiet get_ChiTiet(decimal MaDon, decimal STT)
        {
            return _db.DonTu_ChiTiets.SingleOrDefault(item => item.MaDon == MaDon && item.STT == STT);
        }

        public void getTableHinh(string TableName, out string TableNameHinh, out string IDName)
        {
            DataTable dt = _cDAL.ExecuteQuery_DataTable("select * from TableHinh where TableName='" + TableName + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                TableNameHinh = dt.Rows[0]["TableNameHinh"].ToString();
                IDName = dt.Rows[0]["IDName"].ToString();
            }
            else
            {
                TableNameHinh = "";
                IDName = "";
            }
        }

    }
}

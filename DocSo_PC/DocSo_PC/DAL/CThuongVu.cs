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
                + " (select LoaiVB=N'BB Kiểm Tra',NoiChuyen=N'P. Thương Vụ',DanhBo,HoTen,DiaChi"
                + " ,MLT=(select top 1 * from (select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=ctktxm.DanhBo and LOTRINH is not null union select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG_HUYDB where DanhBo=ctktxm.DanhBo and LOTRINH is not null)t2)"
            + " ,NoiDung=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=ktxm.MaDonMoi)=1) then CONVERT(varchar(10),ktxm.MaDonMoi) else CONVERT(varchar(10),ktxm.MaDonMoi)+'.'+CONVERT(varchar(10),ctktxm.STT) end+' - BBKT - '+convert(varchar(10),ctktxm.NgayKTXM,103)+' - CS: '+ctktxm.ChiSo+' '+isnull(ctktxm.TinhTrangChiSo,'')+'. V/v '+ctktxm.NoiDungKiemTra+' - '+(select HoTen from Users where MaU=ctktxm.CreateBy)"
            + " ,MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=ktxm.MaDonMoi)=1) then CONVERT(varchar(10),ktxm.MaDonMoi) else CONVERT(varchar(10),ktxm.MaDonMoi)+'.'+CONVERT(varchar(10),ctktxm.STT) end"
            + " ,TableName='KTXM_ChiTiet',IDCT=CAST(ctktxm.MaCTKTXM as int),ToMaHoa='false'"
            + " from KTXM ktxm,KTXM_ChiTiet ctktxm where ktxm.MaKTXM=ctktxm.MaKTXM and ktxm.MaDonMoi=" + MaDon + " and ctktxm.STT=" + STT + ")t1");
        }

        public DataTable getDS_KTXM(string DanhBo)
        {
            return _cDAL.ExecuteQuery_DataTable("select t1.*,'To'=(select TenTo from DocSoTH.dbo.[To] where TuMay<=SUBSTRING(t1.MLT,3,2) and DenMay>=SUBSTRING(t1.MLT,3,2)) from"
                + " (select LoaiVB=N'BB Kiểm Tra',NoiChuyen=N'P. Thương Vụ',DanhBo,HoTen,DiaChi"
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

        public DataTable getDS_CongVanDi_QLDHN(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return _cDAL.ExecuteQuery_DataTable("");
        }

        public DataTable getFile(string TableName, int IDCT)
        {
            string TableNameHinh, IDName;
            getTableHinh(TableName, out TableNameHinh, out IDName);
            if (TableNameHinh != "")
            {
                DataTable dt = _cDAL.ExecuteQuery_DataTable("select FileName=[Name]+Loai,Type=Loai from " + TableNameHinh + " where " + IDName + "=" + IDCT + " order by CreateDate asc");
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataTable dtResult = new DataTable();
                    dtResult.Columns.Add("File", typeof(object));
                    dtResult.Columns.Add("Type", typeof(string));
                    foreach (DataRow item in dt.Rows)
                        if (item["FileName"].ToString() != "")
                        {
                            DataRow dr = dtResult.NewRow();
                            dr["File"] = _wsThuongVu.get_Hinh(TableNameHinh, IDCT.ToString(), item["FileName"].ToString());
                            dr["Type"] = item["Type"].ToString();
                            dtResult.Rows.Add(dr);
                        }
                    return dtResult;
                }
                //object filename = _cDAL.ExecuteQuery_ReturnOneValue("select [Name]+Loai from " + TableNameHinh + " where " + IDName + "=" + IDCT + " order by CreateDate asc");
                //if (filename != null)
                //{
                //    object file = _wsThuongVu.get_Hinh(TableNameHinh, IDCT.ToString(), filename.ToString());
                //    if (filename.ToString().ToLower().Contains(".pdf"))
                //    {
                //        type = "pdf";
                //    }
                //    return file;
                //}
            }
            return null;
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

        public DataTable getDS_CVD(string KyHieuTo, DateTime FromNgayChuyen, DateTime ToNgayChuyen)
        {
            if (KyHieuTo != "")
                KyHieuTo = " and '" + KyHieuTo + "'=(select KyHieu from [To] where MaTo=(select MaTo from Users where MaU=ls.CreateBy))";
            string sql = "select t2.*,'To'=(select TenTo from DocSoTH.dbo.[To] where TuMay<=SUBSTRING(t2.MLT,3,2) and DenMay>=SUBSTRING(t2.MLT,3,2)) from "
                + " (select t1.*,MLT=(select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=t1.DanhBo) from "
                + "( select LoaiVB=(select [Name] from TableHinh where TableHinh.TableName=ls.TableName),NoiChuyen=N'P. Thương Vụ',NoiNhan,NgayChuyen,TableName,ls.IDCT,ToMaHoa='false'"
                + " ,MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=ls.MaDon)=1) then CONVERT(varchar(10),ls.MaDon) else CONVERT(varchar(10),ls.MaDon)+'.'+CONVERT(varchar(10),ls.STT) end"
+ " ,DanhBo=case when TableName='BamChi_ChiTiet' then (select DanhBo from BamChi_ChiTiet where MaCTBC=ls.IDCT) "
+ " 		 when TableName='CHDB_ChiTietCatHuy' then (select DanhBo from CHDB_ChiTietCatHuy where MaCTCHDB=ls.IDCT) "
+ " 		 when TableName='CHDB_ChiTietCatTam' then (select DanhBo from CHDB_ChiTietCatTam where MaCTCTDB=ls.IDCT) "
+ " 		 when TableName='CHDB_Phieu' then (select DanhBo from CHDB_Phieu where MaYCCHDB=ls.IDCT) "
+ " 		 when TableName='DCBD_ChiTietBienDong' then (select DanhBo from DCBD_ChiTietBienDong where MaCTDCBD=ls.IDCT) "
+ " 		 when TableName='DCBD_ChiTietHoaDon' then (select DanhBo from DCBD_ChiTietHoaDon where MaCTDCHD=ls.IDCT) "
+ " 		 when TableName='GianLan_ChiTiet' then (select DanhBo from GianLan_ChiTiet where MaGL=ls.IDCT) "
+ " 		 when TableName='KTXM_ChiTiet' then (select DanhBo from KTXM_ChiTiet where MaCTKTXM=ls.IDCT) "
+ " 		 when TableName='ThuMoi_ChiTiet' then (select DanhBo from ThuMoi_ChiTiet where ThuMoi_ChiTiet.IDCT=ls.IDCT) "
+ " 		 when TableName='ThuTraLoi_ChiTiet' then (select DanhBo from ThuTraLoi_ChiTiet where MaCTTTTL=ls.IDCT) "
+ " 		 when TableName='ToTrinh_ChiTiet' then (select DanhBo from ToTrinh_ChiTiet where ToTrinh_ChiTiet.IDCT=ls.IDCT) "
+ " 		 when TableName='TruyThuTienNuoc_ChiTiet' then (select DanhBo from TruyThuTienNuoc_ChiTiet where TruyThuTienNuoc_ChiTiet.IDCT=ls.IDCT) "
+ " 		 when TableName='VanBan_ChiTiet' then (select DanhBo from VanBan_ChiTiet where VanBan_ChiTiet.IDCT=ls.IDCT) end"
+ " ,HoTen=case when TableName='BamChi_ChiTiet' then (select HoTen from BamChi_ChiTiet where MaCTBC=ls.IDCT) "
+ " 		 when TableName='CHDB_ChiTietCatHuy' then (select HoTen from CHDB_ChiTietCatHuy where MaCTCHDB=ls.IDCT) "
+ " 		 when TableName='CHDB_ChiTietCatTam' then (select HoTen from CHDB_ChiTietCatTam where MaCTCTDB=ls.IDCT) "
+ " 		 when TableName='CHDB_Phieu' then (select HoTen from CHDB_Phieu where MaYCCHDB=ls.IDCT) "
+ " 		 when TableName='DCBD_ChiTietBienDong' then (select HoTen from DCBD_ChiTietBienDong where MaCTDCBD=ls.IDCT) "
+ " 		 when TableName='DCBD_ChiTietHoaDon' then (select HoTen from DCBD_ChiTietHoaDon where MaCTDCHD=ls.IDCT) "
+ " 		 when TableName='GianLan_ChiTiet' then (select HoTen from GianLan_ChiTiet where MaGL=ls.IDCT) "
+ " 		 when TableName='KTXM_ChiTiet' then (select HoTen from KTXM_ChiTiet where MaCTKTXM=ls.IDCT) "
+ " 		 when TableName='ThuMoi_ChiTiet' then (select HoTen from ThuMoi_ChiTiet where ThuMoi_ChiTiet.IDCT=ls.IDCT) "
+ " 		 when TableName='ThuTraLoi_ChiTiet' then (select HoTen from ThuTraLoi_ChiTiet where MaCTTTTL=ls.IDCT) "
+ " 		 when TableName='ToTrinh_ChiTiet' then (select HoTen from ToTrinh_ChiTiet where ToTrinh_ChiTiet.IDCT=ls.IDCT) "
+ " 		 when TableName='TruyThuTienNuoc_ChiTiet' then (select HoTen from TruyThuTienNuoc_ChiTiet where TruyThuTienNuoc_ChiTiet.IDCT=ls.IDCT) "
+ " 		 when TableName='VanBan_ChiTiet' then (select HoTen from VanBan_ChiTiet where VanBan_ChiTiet.IDCT=ls.IDCT) end"
+ " ,DiaChi=case when TableName='BamChi_ChiTiet' then (select DiaChi from BamChi_ChiTiet where MaCTBC=ls.IDCT) "
+ " 		 when TableName='CHDB_ChiTietCatHuy' then (select DiaChi from CHDB_ChiTietCatHuy where MaCTCHDB=ls.IDCT) "
+ " 		 when TableName='CHDB_ChiTietCatTam' then (select DiaChi from CHDB_ChiTietCatTam where MaCTCTDB=ls.IDCT) "
+ " 		 when TableName='CHDB_Phieu' then (select DiaChi from CHDB_Phieu where MaYCCHDB=ls.IDCT) "
+ " 		 when TableName='DCBD_ChiTietBienDong' then (select DiaChi from DCBD_ChiTietBienDong where MaCTDCBD=ls.IDCT) "
+ " 		 when TableName='DCBD_ChiTietHoaDon' then (select DiaChi from DCBD_ChiTietHoaDon where MaCTDCHD=ls.IDCT) "
+ " 		 when TableName='GianLan_ChiTiet' then (select DiaChi from GianLan_ChiTiet where MaGL=ls.IDCT) "
+ " 		 when TableName='KTXM_ChiTiet' then (select DiaChi from KTXM_ChiTiet where MaCTKTXM=ls.IDCT) "
+ " 		 when TableName='ThuMoi_ChiTiet' then (select DiaChi from ThuMoi_ChiTiet where ThuMoi_ChiTiet.IDCT=ls.IDCT) "
+ " 		 when TableName='ThuTraLoi_ChiTiet' then (select DiaChi from ThuTraLoi_ChiTiet where MaCTTTTL=ls.IDCT) "
+ " 		 when TableName='ToTrinh_ChiTiet' then (select DiaChi from ToTrinh_ChiTiet where ToTrinh_ChiTiet.IDCT=ls.IDCT) "
+ " 		 when TableName='TruyThuTienNuoc_ChiTiet' then (select DiaChi from TruyThuTienNuoc_ChiTiet where TruyThuTienNuoc_ChiTiet.IDCT=ls.IDCT) "
+ " 		 when TableName='VanBan_ChiTiet' then (select DiaChi from VanBan_ChiTiet where VanBan_ChiTiet.IDCT=ls.IDCT) end"
+ " ,NoiDung=case when TableName='BamChi_ChiTiet' then (select (select [Name] from TableHinh where TableHinh.TableName=ls.TableName)+' - '+convert(varchar(10),CreateDate,103)+'. V/v '+TrangThaiBC+' - '+(select HoTen from Users where MaU=BamChi_ChiTiet.CreateBy) from BamChi_ChiTiet where MaCTBC=ls.IDCT)"
+ " 		 when TableName='CHDB_ChiTietCatHuy' then (select (select [Name] from TableHinh where TableHinh.TableName=ls.TableName)+' - '+convert(varchar(10),CreateDate,103)+N'. Lý do: '+LyDo+isnull(' '+CONVERT(varchar(20),SoTien),'')+isnull(' '+GhiChuLyDo,'')+' - '+COALESCE(convert(varchar(10),NgayThucHien,103),'')+' - '+(select HoTen from Users where MaU=CHDB_ChiTietCatHuy.CreateBy) from CHDB_ChiTietCatHuy where MaCTCHDB=ls.IDCT)"
+ " 		 when TableName='CHDB_ChiTietCatTam' then (select (select [Name] from TableHinh where TableHinh.TableName=ls.TableName)+' - '+convert(varchar(10),CreateDate,103)+N'. Lý do: '+LyDo+isnull(' '+CONVERT(varchar(20),SoTien),'')+isnull(' '+GhiChuLyDo,'')+' - '+COALESCE(convert(varchar(10),NgayThucHien,103),'')+' - '+(select HoTen from Users where MaU=CHDB_ChiTietCatTam.CreateBy) from CHDB_ChiTietCatTam where MaCTCTDB=ls.IDCT)"
+ " 		 when TableName='CHDB_Phieu' then (select (select [Name] from TableHinh where TableHinh.TableName=ls.TableName)+' - '+convert(varchar(10),CreateDate,103)+N'. Lý do: '+LyDo+isnull(' '+CONVERT(varchar(20),SoTien),'')+isnull(' '+GhiChuLyDo,'')+' - HL: '+HieuLucKy+' - '+(select HoTen from Users where MaU=CHDB_Phieu.CreateBy) from CHDB_Phieu where MaYCCHDB=ls.IDCT)"
+ " 		 when TableName='DCBD_ChiTietBienDong' then (select (select [Name] from TableHinh where TableHinh.TableName=ls.TableName)+' - '+convert(varchar(10),CreateDate,103)+'. V/v '+ThongTin+' - '+(select HoTen from Users where MaU=DCBD_ChiTietBienDong.CreateBy) from DCBD_ChiTietBienDong where MaCTDCBD=ls.IDCT)"
+ " 		 when TableName='DCBD_ChiTietHoaDon' then (select (select [Name] from TableHinh where TableHinh.TableName=ls.TableName)+' - '+convert(varchar(10),CreateDate,103)+'. V/v '+KyHD+' - '+(select HoTen from Users where MaU=DCBD_ChiTietHoaDon.CreateBy) from DCBD_ChiTietHoaDon where MaCTDCHD=ls.IDCT)"
+ " 		 when TableName='GianLan_ChiTiet' then (select (select [Name] from TableHinh where TableHinh.TableName=ls.TableName)+' - '+convert(varchar(10),CreateDate,103)+'. V/v '+NoiDungViPham+' - '+(select HoTen from Users where MaU=GianLan_ChiTiet.CreateBy) from GianLan_ChiTiet where MaGL=ls.IDCT)"
+ " 		 when TableName='KTXM_ChiTiet' then (select (select [Name] from TableHinh where TableHinh.TableName=ls.TableName)+' - '+convert(varchar(10),NgayKTXM,103)+' - CS: '+ChiSo+' '+isnull(TinhTrangChiSo,'')+'. V/v '+NoiDungKiemTra+' - '+(select HoTen from Users where MaU=KTXM_ChiTiet.CreateBy) from KTXM_ChiTiet where MaCTKTXM=ls.IDCT)"
+ " 		 when TableName='ThuMoi_ChiTiet' then (select (select [Name] from TableHinh where TableHinh.TableName=ls.TableName)+' - '+convert(varchar(10),CreateDate,103)+'. V/v '+VeViec+' - '+(select HoTen from Users where MaU=ThuMoi_ChiTiet.CreateBy) from ThuMoi_ChiTiet where ThuMoi_ChiTiet.IDCT=ls.IDCT)"
+ " 		 when TableName='ThuTraLoi_ChiTiet' then (select (select [Name] from TableHinh where TableHinh.TableName=ls.TableName)+' - '+convert(varchar(10),CreateDate,103)+'. V/v '+VeViec+' - '+(select HoTen from Users where MaU=ThuTraLoi_ChiTiet.CreateBy) from ThuTraLoi_ChiTiet where MaCTTTTL=ls.IDCT)"
+ " 		 when TableName='ToTrinh_ChiTiet' then (select (select [Name] from TableHinh where TableHinh.TableName=ls.TableName)+' - '+convert(varchar(10),CreateDate,103)+'. V/v '+VeViec+' - '+(select HoTen from Users where MaU=ToTrinh_ChiTiet.CreateBy) from ToTrinh_ChiTiet where ToTrinh_ChiTiet.IDCT=ls.IDCT)"
+ " 		 when TableName='TruyThuTienNuoc_ChiTiet' then (select (select [Name] from TableHinh where TableHinh.TableName=ls.TableName)+' - '+convert(varchar(10),CreateDate,103)+'. V/v '+NoiDung+' - '+(select HoTen from Users where MaU=TruyThuTienNuoc_ChiTiet.CreateBy) from TruyThuTienNuoc_ChiTiet where TruyThuTienNuoc_ChiTiet.IDCT=ls.IDCT)"
+ " 		 when TableName='VanBan_ChiTiet' then (select (select [Name] from TableHinh where TableHinh.TableName=ls.TableName)+' - '+convert(varchar(10),CreateDate,103)+'. V/v '+VeViec+' - '+(select HoTen from Users where MaU=VanBan_ChiTiet.CreateBy) from VanBan_ChiTiet where VanBan_ChiTiet.IDCT=ls.IDCT) end"
+ " from DonTu_LichSu ls where ls.NgayChuyen>='" + FromNgayChuyen.ToString("yyyy-MM-dd HH:mm") + "' and ls.NgayChuyen<='" + ToNgayChuyen.ToString("yyyy-MM-dd HH:mm") + "' and ls.ID_NoiNhan=22 and ls.TableName is not null " + KyHieuTo + ")t1)t2 order by NgayChuyen asc";

            return _cDAL.ExecuteQuery_DataTable(sql);
        }

    }
}

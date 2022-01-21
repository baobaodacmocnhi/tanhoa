﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DocSo_PC.DAL
{
    class CThuongVu
    {
        public static CConnection _cDAL = new CConnection("Data Source=serverg8-01;Initial Catalog=KTKS_DonKH;Persist Security Info=True;User ID=sa;Password=db11@tanhoa");

        public DataTable getDS_KTXM_ChuaNhan(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select ktxmct.DanhBo,ktxmct.HoTen,ktxmct.DiaChi,NoiDung=ktxmct.NoiDungKiemTra,NgayLap=ktxmct.NgayKTXM,NgayChuyen=cvd.CreateDate"
                        + " ,MLT=(select LOTRINH from server8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=ktxmct.DanhBo),cvd.ID,Nhan_QLDHN"
                        + " ,MaDon=cvd.Ma,LoaiVB=N'Biên Bản Kiểm Tra',TableName='KTXM_ChiTiet',IDCT=CAST(ktxmct.MaCTKTXM as int),NoiChuyen=N'P. Thương Vụ'"
                        + " from CongVanDi cvd,KTXM ktxm,KTXM_ChiTiet ktxmct"
                        + " where CAST(cvd.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(cvd.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'"
                        + " and NoiChuyen=N'Đội QLĐHN' and KTXM=1 and ktxm.MaKTXM=ktxmct.MaKTXM"
                        + " and ktxm.MaDonMoi=case when cvd.Ma like '%.%' then SUBSTRING(Ma,0,9) else Ma end"
                        + " and ktxmct.STT=case when cvd.Ma like '%.%' then RIGHT(Ma,LEN(Ma)-9) else 1 end"
                        //+ " and ktxmct.MaCTKTXM not in (select IDCT from server8.DocSoTH.dbo.CongVanDen where TableName='KTXM_ChiTiet')"
                        + " order by cvd.CreateDate asc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ToTrinh_ChuaNhan(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select ttct.DanhBo,ttct.HoTen,ttct.DiaChi,NoiDung=ttct.VeViec,NgayLap=ttct.CreateDate,NgayChuyen=cvd.CreateDate"
                         + " ,MLT=(select LOTRINH from server8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=ttct.DanhBo),cvd.ID,Nhan_QLDHN"
                         + " ,MaDon=cvd.Ma,LoaiVB=N'Tờ Trình',TableName='ToTrinh_ChiTiet',IDCT=CAST(ttct.IDCT as int),NoiChuyen=N'P. Thương Vụ'"
                         + " from CongVanDi cvd,ToTrinh tt,ToTrinh_ChiTiet ttct"
                         + " where CAST(cvd.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(cvd.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'"
                         + " and NoiChuyen=N'Đội QLĐHN' and ToTrinh=1 and tt.ID=ttct.ID"
                         + " and tt.MaDonMoi=case when cvd.Ma like '%.%' then SUBSTRING(Ma,0,9) else Ma end"
                         + " and ttct.STT=case when cvd.Ma like '%.%' then RIGHT(Ma,LEN(Ma)-9) else 1 end"
                         //+ " and ttct.IDCT not in (select IDCT from server8.DocSoTH.dbo.CongVanDen where TableName='ToTrinh_ChiTiet')"
                         + " order by cvd.CreateDate asc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public object getHinh_KTXM(int IDCT)
        {
            return _cDAL.ExecuteQuery_ReturnOneValue("select Hinh from KTXM_ChiTiet_Hinh where IDKTXM_ChiTiet=" + IDCT);
        }

        public object getHinh_ToTrinh(int IDCT)
        {
            return _cDAL.ExecuteQuery_ReturnOneValue("select Hinh from ToTrinh_ChiTiet_Hinh where IDToTrinh_ChiTiet=" + IDCT);
        }

    }
}

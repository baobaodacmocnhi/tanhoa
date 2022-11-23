﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DocSo_PC.LinQ;

namespace DocSo_PC.DAL
{
    class CGanMoi
    {
        public static dbGanMoiDataContext _db = new dbGanMoiDataContext();
        public static CConnection _cDAL = new CConnection(_db.Connection.ConnectionString);

        public DataTable getDS_BBNT(string DanhBo)
        {
            return _cDAL.ExecuteQuery_DataTable("select t1.*,'To'=(select TenTo from DocSoTH.dbo.[To] where TuMay<=SUBSTRING(t1.MLT,3,2) and DenMay>=SUBSTRING(t1.MLT,3,2)) from"
            + " (select LoaiVB=N'Biên Bản Nghiệm Thu',NoiChuyen=N'Đ. TCTB',DanhBo=REPLACE(don.DANHBO, '-', ''),HoTen,DiaChi=hoso.DHN_SONHA+' '+hoso.DHN_DIACHI"
            + " ,MLT=(select top 1 * from (select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=REPLACE(don.DANHBO, '-', '') union select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG_HUYDB where DanhBo=REPLACE(don.DANHBO, '-', ''))t2)"
             + " ,NoiDung=don.SHS+' - BBNT - '+COALESCE(convert(varchar(10),hoso.NGAYTHICONG,103),'')+'. V/v '+don.GHICHU+' - CSGo: '+CONVERT(varchar(6),isnull(hoso.TCTB_CSGO,''))+' - CSGan: '+CONVERT(varchar(6),isnull(hoso.CHISO,''))"
             + " ,MaDon=don.SHS"
             + " ,TableName='KH_HOSOKHACHHANG',IDCT=hoso.ID,ToMaHoa='false'"
             + " from DON_KHACHHANG don,KH_HOSOKHACHHANG hoso where don.SHS=hoso.SHS and REPLACE(don.DANHBO, '-', '')='" + DanhBo + "')t1");
        }



    }
}

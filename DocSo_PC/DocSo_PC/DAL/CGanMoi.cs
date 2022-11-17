using System;
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
            return _cDAL.ExecuteQuery_DataTable("select LoaiVB=N'Biên Bản Nghiệm Thu',NoiChuyen=N'Đ. TCTB',MLT=(select LOTRINH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=REPLACE(don.DANHBO, '-', '')),DanhBo=REPLACE(don.DANHBO, '-', ''),HoTen,DiaChi=hoso.DHN_SONHA+' '+hoso.DHN_DIACHI"
             + " ,NoiDung=don.SHS+' - BBNT - '+convert(varchar(10),hoso.NGAYTHICONG,103)+'. V/v '+don.GHICHU+' - CSGo: '+CONVERT(varchar(6),hoso.TCTB_CSGO)+' - CSGan: '+CONVERT(varchar(6),hoso.CHISO)"
             + " ,MaDon=don.SHS"
             + " ,TableName='KH_HOSOKHACHHANG',IDCT=hoso.ID"
             + " from DON_KHACHHANG don,KH_HOSOKHACHHANG hoso where don.SHS=hoso.SHS and REPLACE(don.DANHBO, '-', '')='" + DanhBo + "'");
        }



    }
}

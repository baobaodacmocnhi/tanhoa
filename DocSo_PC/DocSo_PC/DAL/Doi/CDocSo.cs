using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using System.Data;
using DocSo_PC.DAL.QuanTri;

namespace DocSo_PC.DAL.Doi
{
    class CDocSo : CDAL
    {

        public DataTable getDS_Nam()
        {
            string sql = "select Nam=CAST(SUBSTRING(BillID,0,5)as int)"
                          + " from BillState"
                          + " group by SUBSTRING(BillID,0,5)"
                          + " order by Nam desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        //table BillState
        public bool them_BillState(BillState en)
        {
            try
            {
                _db.BillStates.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExists_BillState(string Nam, string Ky, string Dot)
        {
            return _db.BillStates.Any(item => item.BillID == Nam + Ky + Dot);
        }

        public bool checkChot_BillState(string BillID)
        {
            return _db.BillStates.Any(item => item.BillID == BillID && item.izDS == "1");
        }

        public bool checkChot_BillState(string Nam, string Ky, string Dot)
        {
            return _db.BillStates.Any(item => item.BillID == Nam + Ky + Dot && item.izDS == "1");
        }

        public BillState get_BillState(string BillID)
        {
            return _db.BillStates.SingleOrDefault(item => item.BillID == BillID);
        }

        //table BienDong
        public bool them_BienDong(BienDong en)
        {
            try
            {
                _db.BienDongs.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public List<BienDong> getDS_BienDong(string Nam, string Ky, string Dot)
        {
            return _db.BienDongs.Where(item => item.Nam == int.Parse(Nam) && item.Ky == Ky && item.Dot == Dot).ToList();
        }

        public BienDong get_BienDong(string ID)
        {
            return _db.BienDongs.SingleOrDefault(item => item.BienDongID == ID);
        }


        //table Code
        public DataTable getDS_Code()
        {
            return _cDAL.ExecuteQuery_DataTable("select Code from TTDHN order by stt asc");
        }

        public DataTable getDS_Code(string Nam, string Ky, string Dot)
        {
            return _cDAL.ExecuteQuery_DataTable("select Code=CodeMoi from DocSo where Nam=" + Nam + " and Ky=" + Ky + " and Dot=" + Dot + " group by CodeMoi");
        }

        public string getTTDHNCode(string Code)
        {
            return _cDAL.ExecuteQuery_ReturnOneValue("select TTDHN from TTDHN where Code='" + Code + "'").ToString();
        }


        //table DocSo
        public bool them_DocSo(DocSo en)
        {
            try
            {
                _db.DocSos.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExists_DocSo(string ID)
        {
            return _db.DocSos.Any(item => item.DocSoID == ID);
        }

        public bool checkExists_DocSo(string Nam, string Ky, string Dot)
        {
            return _db.DocSos.Any(item => item.Nam == int.Parse(Nam) && item.Ky == Ky && item.Dot == Dot);
        }

        public DocSo get_DocSo(string DocSoID)
        {
            return _db.DocSos.SingleOrDefault(item => item.DocSoID == DocSoID);
        }

        public DocSo get_DocSo(string DanhBo, string Nam, string Ky)
        {
            return _db.DocSos.SingleOrDefault(item => item.Nam == int.Parse(Nam) && item.Ky == Ky && item.DanhBa == DanhBo);
        }

        public int TinhTBTT(string DanhBo, string Nam, string Ky)
        {
            if (Ky == "01")
            {
                return (int)_cDAL.ExecuteQuery_ReturnOneValue("select SUM(TieuThuMoi) from DocSo where Nam=" + (int.Parse(Nam) - 1) + " and Ky in (10,11,12) and DanhBa='" + DanhBo + "'");
            }
            else
                if (Ky == "02")
                {
                    return (int)_cDAL.ExecuteQuery_ReturnOneValue("select SUM(TieuThuMoi) from DocSo where ((Nam=" + (int.Parse(Nam) - 1) + " and Ky in (11,12)) or (Nam=" + Nam + " and Ky in (" + (int.Parse(Ky) - 1) + "))) and DanhBa='" + DanhBo + "'");
                }
                else
                    if (Ky == "03")
                    {
                        return (int)_cDAL.ExecuteQuery_ReturnOneValue("select SUM(TieuThuMoi) from DocSo where ((Nam=" + (int.Parse(Nam) - 1) + " and Ky in (12)) or (Nam=" + Nam + " and Ky in (" + (int.Parse(Ky) - 2) + "," + (int.Parse(Ky) - 1) + "))) and DanhBa='" + DanhBo + "'");
                    }
                    else
                    {
                        return (int)_cDAL.ExecuteQuery_ReturnOneValue("select SUM(TieuThuMoi) from DocSo where Nam=" + Nam + " and Ky in (" + (int.Parse(Ky) - 3) + "," + (int.Parse(Ky) - 2) + "," + (int.Parse(Ky) - 1) + ") and DanhBa='" + DanhBo + "'");
                    }
        }

        public void updateTBTTDocSo(string Nam, string Ky, string Dot)
        {
            _cDAL.ExecuteNonQuery("exec dbo.spUpdateTBTTDocSo '" + Nam + "','" + Ky + "','" + Dot + "'");
        }

        public DataTable getTong_TaoDot(string Nam, string Ky)
        {
            string sql = "";
            if (Ky == "1")
                sql = "select *"
                            + " ,TongHD=(select COUNT(*) from server9.HOADON_TA.dbo.HOADON where NAM=t1.Nam-1 and KY=12 and DOT=t1.Dot)"
                            + " ,TongBD=(select COUNT(*) from BienDong where Nam=t1.Nam and Ky=t1.Ky and Dot=t1.Dot)"
                            + " ,TongTD=(select COUNT(*) from DocSo where Nam=t1.Nam and Ky=t1.Ky and Dot=t1.Dot)"
                            + " ,CreateDateBD=(select top 1 NgayCapNhat from BienDong where Nam=t1.Nam and Ky=t1.Ky and Dot=t1.Dot)"
                            + " ,CreateDateTD=(select top 1 NgayTaoDS from DocSo where Nam=t1.Nam and Ky=t1.Ky and Dot=t1.Dot)"
                            + " from"
                            + " (select Nam=SUBSTRING(BillID,0,5)"
                            + " ,Ky=SUBSTRING(BillID,5,2)"
                            + " ,Dot=SUBSTRING(BillID,7,2)"
                            + " ,BillID=BillID"
                            + " ,Chot=case when izDS is null then 'false' else 'true' end"
                            + " from BillState where BillID like '" + Nam + Ky + "%')t1";
            else
                sql = "select *"
                        + " ,TongHD=(select COUNT(*) from server9.HOADON_TA.dbo.HOADON where NAM=t1.Nam and KY=t1.Ky-1 and DOT=t1.Dot)"
                        + " ,TongBD=(select COUNT(*) from BienDong where Nam=t1.Nam and Ky=t1.Ky and Dot=t1.Dot)"
                        + " ,TongTD=(select COUNT(*) from DocSo where Nam=t1.Nam and Ky=t1.Ky and Dot=t1.Dot)"
                        + " ,CreateDateBD=(select top 1 NgayCapNhat from BienDong where Nam=t1.Nam and Ky=t1.Ky and Dot=t1.Dot)"
                        + " ,CreateDateTD=(select top 1 NgayTaoDS from DocSo where Nam=t1.Nam and Ky=t1.Ky and Dot=t1.Dot)"
                        + " from"
                        + " (select Nam=SUBSTRING(BillID,0,5)"
                        + " ,Ky=SUBSTRING(BillID,5,2)"
                        + " ,Dot=SUBSTRING(BillID,7,2)"
                        + " ,BillID=BillID"
                        + " ,Chot=case when izDS is null then 'false' else 'true' end"
                        + " from BillState where BillID like '" + Nam + Ky + "%')t1";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_GiaoTangCuong(string May, string Nam, string Ky, string Dot)
        {
            string sql = "select DocSoID,MLT=MLT1,DanhBo=DanhBa,May,PhanMay from DocSo where Nam=" + Nam + " and Ky=" + Ky + " and Dot=" + Dot + " and May=" + May + " order by MLT1 asc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_GhiChu(string DanhBo)
        {
            string sql = "select Ky+'/'+str(Nam,4,0) as NamKy,DanhBa,CodeMoi,TTDHNMoi,CSCu,CSMoi,TieuThuMoi,GhiChuDS,GhiChuKH,GhiChuTV"
                            + " from DocSo where DanhBa='" + DanhBo + "' order by DocSoID desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        //xử lý
        public DataTable getDS_XuLy_DanhBo(string Nam, string Ky, string DanhBo)
        {
            string sql = "select ds.*,BaoThayDK=case when baothay.DanhBo is not null then 'true' else 'false' end"
                        + " ,BaoThayBT=case when thwater.DanhBo is not null then 'true' else 'false' end"
                        + " ,CSGo=case when baothay.DanhBo is not null then baothay.CSGo else case when thwater.DanhBo is not null then thwater.CSGo else '' end end"
                        + " ,CSGan=case when baothay.DanhBo is not null then baothay.CSGan else case when thwater.DanhBo is not null then thwater.CSGan else '' end end"
                        + " from DocSo  ds left join (SELECT DanhBo=REPLACE(DANHBO,'-',''),CSGan=ChiSo,CSGo=TCTB_CSGo FROM TANHOA_WATER.dbo.V_HOANGCONGTCTB WHERE DATEADD(DAY,30,NGAYTHICONG)>=GETDATE()) thwater on ds.DanhBa=thwater.DanhBo"
                        + " left join (select DanhBo=DanhBa,CSGo,CSGan from BaoThay b inner join ThamSo t on b.LoaiBT=t.Code where t.CodeType = 'BT' and DATEADD(DAY,30,NgayThay)>=GETDATE()) baothay on ds.DanhBa=baothay.DanhBo"
                        + " where Nam=" + Nam + " and Ky=" + Ky + " and DanhBa=" + DanhBo;
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_XuLy_DanhBo(string MaTo, string Nam, string Ky, string DanhBo)
        {
            string sql = "select ds.*,BaoThayDK=case when baothay.DanhBo is not null then 'true' else 'false' end"
                        + " ,BaoThayBT=case when thwater.DanhBo is not null then 'true' else 'false' end"
                        + " ,CSGo=case when baothay.DanhBo is not null then baothay.CSGo else case when thwater.DanhBo is not null then thwater.CSGo else '' end end"
                        + " ,CSGan=case when baothay.DanhBo is not null then baothay.CSGan else case when thwater.DanhBo is not null then thwater.CSGan else '' end end"
                        + " from DocSo ds left join (SELECT DanhBo=REPLACE(DANHBO,'-',''),CSGan=ChiSo,CSGo=TCTB_CSGo FROM TANHOA_WATER.dbo.V_HOANGCONGTCTB WHERE DATEADD(DAY,30,NGAYTHICONG)>=GETDATE()) thwater on ds.DanhBa=thwater.DanhBo"
                        + " left join (select DanhBo=DanhBa,CSGo,CSGan from BaoThay b inner join ThamSo t on b.LoaiBT=t.Code where t.CodeType = 'BT' and DATEADD(DAY,30,NgayThay)>=GETDATE()) baothay on ds.DanhBa=baothay.DanhBo"
                        + " where Nam=" + Nam + " and Ky=" + Ky + " and DanhBa=" + DanhBo + " and (select TuMay from [To] where MaTo=" + MaTo + ")<=May and May<=(select DenMay from [To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_XuLy(string MaTo, string Nam, string Ky, string Dot, string May, string Code, ref DataTable dtTong)
        {
            if (MaTo == "0")
                MaTo = "";
            else
                MaTo = " and (select TuMay from [To] where MaTo=" + MaTo + ")<=May and May<=(select DenMay from [To] where MaTo=" + MaTo + ")";
            if (May == "" || May == "Tất Cả")
                May = "";
            else
                May = " and May like '" + May + "'";
            if (Code == "" || Code == "Tất Cả")
                Code = "";
            else
                Code = " and CodeMoi like '" + Code + "'";
            string sql = "select ds.*,BaoThayDK=case when baothay.DanhBo is not null then 'true' else 'false' end"
                        + " ,BaoThayBT=case when thwater.DanhBo is not null then 'true' else 'false' end"
                        + " ,CSGo=case when baothay.DanhBo is not null then baothay.CSGo else case when thwater.DanhBo is not null then thwater.CSGo else '' end end"
                        + " ,CSGan=case when baothay.DanhBo is not null then baothay.CSGan else case when thwater.DanhBo is not null then thwater.CSGan else '' end end"
                        + " from DocSo ds left join (SELECT DanhBo=REPLACE(DANHBO,'-',''),CSGan=ChiSo,CSGo=TCTB_CSGo FROM TANHOA_WATER.dbo.V_HOANGCONGTCTB WHERE DATEADD(DAY,30,NGAYTHICONG)>=GETDATE()) thwater on ds.DanhBa=thwater.DanhBo"
                        + " left join (select DanhBo=DanhBa,CSGo,CSGan from BaoThay b inner join ThamSo t on b.LoaiBT=t.Code where t.CodeType = 'BT' and DATEADD(DAY,30,NgayThay)>=GETDATE()) baothay on ds.DanhBa=baothay.DanhBo"
                        + " where Nam=" + Nam + " and Ky=" + Ky + " and Dot=" + Dot + MaTo + May + Code
                        + " order by MLT2 asc";
            string sql2 = "select TongSL=COUNT(DocSoID)"
                        + " ,SLDaGhi=COUNT(case when CodeMoi!='' then 1 else null end)"
                        + " ,SLChuaGhi=COUNT(case when CodeMoi='' then 1 else null end)"
                        + " ,SanLuong=SUM(TieuThuMoi)"
                        + " ,SLHD0=COUNT(case when TieuThuMoi=0 then 1 else null end)"
                        + " from DocSo where Nam=" + Nam + " and Ky=" + Ky + " and Dot=" + Dot + MaTo + May + Code;
            dtTong = _cDAL.ExecuteQuery_DataTable(sql2);
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getThongBao(string DanhBo)
        {
            string sql = "select d.SoLenh,t.CodeDesc,ChiSo,NgayKiem,NoiDung,Hieu,Co,NgayCapNhat"
                            + " from ThongBao d inner join ThamSo t on d.LoaiLenh=t.Code "
                            + " where DanhBa='" + DanhBo + "' and t.CodeType='TB' order by ID desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getBaoThay(string DanhBo)
        {
            string sql = "select DanhBa,t.CodeDesc,CSGo,CSGan,SoThanMoi,NgayThay,NgayCapNhat,NVCapNhat"
                            + " from BaoThay b inner join ThamSo t on b.LoaiBT=t.Code "
                            + " where DanhBa='" + DanhBo + "' and t.CodeType = 'BT' order by NgayCapNhat desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public bool checkBaoThay(string DanhBo)
        {
            string sql = "select top 1 DanhBa from BaoThay b inner join ThamSo t on b.LoaiBT=t.Code where DanhBa='" + DanhBo + "' and t.CodeType = 'BT' and DATEADD(DAY,30,NgayThay)>=GETDATE()";
            object result = _cDAL.ExecuteQuery_ReturnOneValue(sql);
            if (result != null && result.ToString() != "")
                return true;
            else
                return false;
        }

        public DataTable getLichSu(string DanhBo, string Nam, string Ky)
        {
            DataTable dt;
            string sql = "select Col,Ky11,Ky10,Ky9,Ky8,Ky7,Ky6,Ky5,Ky4,Ky3,Ky2,Ky1,Ky0 from"
            + "      (select 'Ky'+convert(varchar(5),(2021*12+12)-Nam*12-Ky+" + Ky + ") as KyN,Col,Val"
            + "      from DocSo cross apply"
            + "          (values"
            + "              (N'1. Kỳ',Ky+'/'+str(Nam,4,0)),"
            + "              (N'2. Ngày đọc',convert(varchar(10),DenNgay,103)),"
            + "              ('3. Code',CodeMoi),"
            + "              (N'4. Chỉ số',convert(varchar(10),CSMoi)),"
            + "              (N'5. Tiêu thụ',convert(varchar(10),TieuThuMoi)))"
            + "          cs (Col,Val)"
            + "      where DanhBa = '" + DanhBo + "') src"
            + "  pivot (max(Val) for KyN in (Ky11,Ky10,Ky9,Ky8,Ky7,Ky6,Ky5,Ky4,Ky3,Ky2,Ky1,Ky0)) pvt";
            dt = _cDAL.ExecuteQuery_DataTable(sql);
            sql = "select Col,Ky11,Ky10,Ky9,Ky8,Ky7,Ky6,Ky5,Ky4,Ky3,Ky2,Ky1,Ky0 from"
            + "      (select 'Ky'+convert(varchar(5),(2021*12+12)-Nam*12-Ky+" + Ky + ") as KyN,Col,Val"
            + "      from server9.HOADON_TA.dbo.HOADON cross apply"
            + "          (values"
            + "              (N'6. Tiêu Thụ HĐ',convert(varchar(10),TIEUTHU)),"
            + "              (N'7. Đăng Ngân',convert(varchar(10),NgayGiaiTrach,103)),"
            + "              (N'8. SoHoaDonCu',SoHoaDonCu)"
            + "              )"
            + "          cs (Col,Val)"
            + "      where DanhBa = '" + DanhBo + "') src"
            + "  pivot (max(Val) for KyN in (Ky11,Ky10,Ky9,Ky8,Ky7,Ky6,Ky5,Ky4,Ky3,Ky2,Ky1,Ky0)) pvt";
            dt.Merge(_cDAL.ExecuteQuery_DataTable(sql));
            return dt;
        }

        public int tinhCodeTieuThu(string DocSoID, string Code, int CSM)
        {
            string sql = "EXEC [dbo].[spTinhTieuThu]"
                    + " @DANHBO = N'" + DocSoID.Substring(6, 11) + "',"
                    + " @KY = " + DocSoID.Substring(4, 2) + ","
                    + " @NAM = " + DocSoID.Substring(0, 4) + ","
                    + " @CODE = N'" + Code + "',"
                    + " @CSMOI = " + CSM;
            return (int)_cDAL.ExecuteQuery_ReturnOneValue(sql);
        }

        public DataTable getDS_Code5K5N(string Nam, string Ky, string Dot)
        {
            string sql = "select DanhBa,MLT1,CSCu,CSMoi,TieuThuMoi,CodeMoi"
                            + " from DocSoTH.dbo.DocSo"
                            + " where Nam=" + Nam + " and Ky=" + Ky + " and Dot=" + Dot + " and CodeMoi in ('5N','5K')"
                            + " order by MLT1 asc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public bool updateDS_Code5K5N(string Nam, string Ky, string Dot)
        {
            string sql = "update DocSo"
                            + " set CSCu=CSMoi-TieuThuMoi,NgayCapNhat=getdate(),NVCapNhat=N'" + CNguoiDung.HoTen + "'"
                            + " where Nam=" + Nam + " and Ky=" + Ky + " and Dot=" + Dot + " and CodeMoi in ('5N','5K')";
            return _cDAL.ExecuteNonQuery(sql);
        }


        //chuyển billing
        public DataTable getTong_ChuyenBilling(string Nam, string Ky)
        {
            string sql = "select *"
                        + " ,TongHD=(select COUNT(*) from DocSo where Nam=t1.Nam and Ky=t1.Ky and Dot=t1.Dot)"
                        + " ,TongTieuThu=(select SUM(TieuThuMoi) from DocSo where Nam=t1.Nam and Ky=t1.Ky and Dot=t1.Dot)"
                        + " ,TongHDChuaChuyen=''"
                        + " ,CreateDateChuyen=''"
                        + " from"
                        + " (select Nam=SUBSTRING(BillID,0,5)"
                        + " ,Ky=SUBSTRING(BillID,5,2)"
                        + " ,Dot=SUBSTRING(BillID,7,2)"
                        + " ,BillID=BillID"
                        + " ,Chot=case when izDS is null then 'false' else 'true' end"
                        + " from BillState where BillID like '" + Nam + Ky + "%')t1";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ChuyenBilling(string Nam, string Ky, string Dot)
        {
            string sql = "SELECT DocSoID,DanhBa,CSCu,CASE WHEN LEFT(CodeMoi, 1) = 'F' OR LEFT(CodeMoi, 1) = '6' THEN TieuThuMoi ELSE CSMOI END AS CSMoi,TieuThuMoi,CASE WHEN LEFT(CodeMoi,1) = '4' THEN '4' ELSE CodeMoi END AS CodeMoi,MLT2,TTDHNMoi"
                        + ",DenNgay=CONVERT(varchar(10),DenNgay,103),Nam,Ky,Dot FROM DocSo WHERE Nam=" + Nam + " and Ky='" + Ky + "' AND Dot='" + Dot + "' order by MLT2 asc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }


    }
}

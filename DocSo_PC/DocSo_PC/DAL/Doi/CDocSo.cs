using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using System.Data;

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

        public bool checkChuyenBilling_BillState(string Nam, string Ky, string Dot)
        {
            return _db.BillStates.Any(item => item.BillID == Nam + Ky + Dot && item.izDS == "1");
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

        public string getTTDHNCode(string Code)
        {
            return _cDAL.ExecuteQuery_ReturnOneValue("select TTDHN from TTDHN where Code=" + Code).ToString();
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

        public DataTable getDS_TaoDot(string Nam, string Ky)
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
                            + " ,ID=BillID"
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
                        + " ,ID=BillID"
                        + " from BillState where BillID like '" + Nam + Ky + "%')t1";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_GiaoTangCuong(string May, string Nam, string Ky, string Dot)
        {
            string sql = "select DocSoID,MLT=MLT1,DanhBo=DanhBa,May,PhanMay from DocSo where Nam=" + Nam + " and Ky=" + Ky + " and Dot=" + Dot + " and May=" + May + " order by MLT1 asc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_XuLy_DanhBo(string Nam, string Ky, string DanhBo)
        {
            string sql = "select * from DocSo where Nam=" + Nam + " and Ky=" + Ky + " and DanhBa=" + DanhBo;
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_XuLy_DanhBo(string MaTo, string Nam, string Ky, string DanhBo)
        {
            string sql = "select * from DocSo where Nam=" + Nam + " and Ky=" + Ky + " and DanhBa=" + DanhBo + " (select TuMay from [To] where MaTo=" + MaTo + ")<=May and May<=(select DenMay from [To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_XuLy(string MaTo, string Nam, string Ky, string Dot, string May, string Code, ref DataTable dtTong)
        {
            if (May == "Tất Cả")
                May = "";
            if (Code == "Tất Cả")
                Code = "";
            string sql = "select * from DocSo where Nam=" + Nam + " and Ky=" + Ky + " and Dot=" + Dot + " and (select TuMay from [To] where MaTo=" + MaTo + ")<=May and May<=(select DenMay from [To] where MaTo=" + MaTo + ") and May like '%" + May + "%' and CodeMoi like '%" + Code + "%'";
            string sql2 = "select TongSL=COUNT(DocSoID)"
                        + " ,SLDaGhi=COUNT(case when CodeMoi!='' then 1 else null end)"
                        + " ,SLChuaGhi=COUNT(case when CodeMoi='' then 1 else null end)"
                        + " ,SanLuong=SUM(TieuThuMoi)"
                        + " ,SLHD0=COUNT(case when TieuThuMoi=0 then 1 else null end)"
                        + " from DocSo where Nam=" + Nam + " and Ky=" + Ky + " and Dot=" + Dot + " and (select TuMay from [To] where MaTo=" + MaTo + ")<=May and May<=(select DenMay from [To] where MaTo=" + MaTo + ") and May like '%" + May + "%' and CodeMoi like '%" + Code + "%'";
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

        public DataTable getLichSu(string DanhBo, string Nam, string Ky)
        {
            string sql = "select Col,Ky11,Ky10,Ky9,Ky8,Ky7,Ky6,Ky5,Ky4,Ky3,Ky2,Ky1,Ky0 from"
            + "      (select 'Ky'+convert(varchar(5),(2021*12+12)-Nam*12-Ky) as KyN,Col,Val"
            + "      from DocSo cross apply"
            + "          (values"
            + "              (N'1. Kỳ',Ky+'/'+str(Nam,4,0)),"
            + "              (N'2. Ngày đọc',convert(varchar(10),DenNgay,103)),"
            + "              ('3. Code',CodeMoi),"
            + "              (N'4. Chỉ số',convert(varchar(10),CSMoi)),"
            + "              (N'5. Tiêu thụ',convert(varchar(10),TieuThuMoi)))"
            + "          cs (Col,Val)"
            + "      where DanhBa = 13132150168) src"
            + "  pivot (max(Val) for KyN in (Ky11,Ky10,Ky9,Ky8,Ky7,Ky6,Ky5,Ky4,Ky3,Ky2,Ky1,Ky0)) pvt";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }
    }
}

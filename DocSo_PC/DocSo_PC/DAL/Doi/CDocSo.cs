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
            return _cDAL.ExecuteQuery_SqlDataAdapter_DataTable(sql);
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

        public void updateDocSo(ref DocSo en)
        {
            DocSo enTruoc;
            if (en.Ky == "1")
                enTruoc = get_DocSo(en.DanhBa, (en.Nam.Value - 1).ToString(), "12");
            else
                enTruoc = get_DocSo(en.DanhBa, en.Nam.Value.ToString(), (int.Parse(en.Ky) - 1).ToString());
            if (enTruoc != null)
            {
                en.TBTT = TinhTBTT(en.DanhBa, en.Nam.Value.ToString(), en.Ky);
                en.CodeCu = enTruoc.CodeMoi;
                en.TTDHNCu = enTruoc.TTDHNMoi;
                en.TuNgay = enTruoc.DenNgay;
            }
        }

        public void updateTBTTDocSo(string Nam,string Ky,string Dot)
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
            return _cDAL.ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

    }
}

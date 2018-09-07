using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.Doi
{
    class CGuiThongBao:CDAL
    {
        public bool Them(TT_GuiThongBao entity)
        {
            try
            {
                if (_db.TT_GuiThongBaos.Count() == 0)
                    entity.ID = 1;
                else
                    entity.ID = _db.TT_GuiThongBaos.Max(item => item.ID) + 1;
                entity.CreateBy = CNguoiDung.MaND;
                entity.CreateDate = DateTime.Now;
                _db.TT_GuiThongBaos.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(TT_GuiThongBao entity)
        {
            try
            {
                _db.TT_GuiThongBaos.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(TT_GuiThongBao entity)
        {
            try
            {
                entity.ModifyBy = CNguoiDung.MaND;
                entity.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool CheckExist(string DanhBo)
        {
            return _db.TT_GuiThongBaos.Any(item => item.DanhBo == DanhBo);
        }
        
        public TT_GuiThongBao Get(int ID)
        {
            return _db.TT_GuiThongBaos.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetDS()
        {
            return LINQToDataTable(_db.TT_GuiThongBaos.ToList());
        }

        public DataTable GetDS(int FromDot, int ToDot)
        {
            string sql = ";with ttkh as"
                        + " ("
                        + " 	select b.*,'To'=(select TenTo from TT_To where MaTo=nd.MaTo),HanhThu=nd.HoTen from"
                        + " 	(select DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,HOPDONG,GiaBieu=GB,MLT=MALOTRINH,MaNV_HanhThu,ROW_NUMBER() OVER (PARTITION BY DANHBA ORDER BY CreateDate DESC) AS rn from HOADON) b"
                        + " 	left join TT_NguoiDung nd on b.MaNV_HanhThu=nd.MaND"
                        + " 	where rn=1 and DOT>=" + FromDot + " and DOT<=" + ToDot
                        + " )"
                        + " select * from"
                        + " (select ID,DanhBo,CreateDate from TT_GuiThongBao) a,ttkh"
                        + " where a.DanhBo=ttkh.DANHBA";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDS(int FromDot, int ToDot,int GiaBieu)
        {
            string sql = ";with ttkh as"
                        + " ("
                        + " 	select b.*,'To'=(select TenTo from TT_To where MaTo=nd.MaTo),HanhThu=nd.HoTen from"
                        + " 	(select DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,HOPDONG,MaNV_HanhThu,GiaBieu=GB,MLT=MALOTRINH,ROW_NUMBER() OVER (PARTITION BY DANHBA ORDER BY CreateDate DESC) AS rn from HOADON) b"
                        + " 	left join TT_NguoiDung nd on b.MaNV_HanhThu=nd.MaND"
                        + " 	where rn=1 and DOT>=" + FromDot + " and DOT<=" + ToDot + " and GB=" + GiaBieu
                        + " )"
                        + " select * from"
                        + " (select ID,DanhBo,CreateDate from TT_GuiThongBao) a,ttkh"
                        + " where a.DanhBo=ttkh.DANHBA";
            return ExecuteQuery_DataTable(sql);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.Doi
{
    class CDangKy2 : CDAL
    {
        public bool Them(TT_DangKy2 dangky)
        {
            try
            {
                dangky.CreateDate = DateTime.Now;
                dangky.CreateBy = CNguoiDung.MaND;
                _db.TT_DangKy2s.InsertOnSubmit(dangky);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(TT_DangKy2 dangky)
        {
            try
            {
                _db.TT_DangKy2s.DeleteOnSubmit(dangky);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(TT_DangKy2 dangky)
        {
            try
            {
                dangky.ModifyDate = DateTime.Now;
                dangky.ModifyBy = CNguoiDung.MaND;
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
            return _db.TT_DangKy2s.Any(item => item.DanhBo == DanhBo);
        }

        public TT_DangKy2 Get(string DanhBo)
        {
            return _db.TT_DangKy2s.SingleOrDefault(item => item.DanhBo == DanhBo);
        }

        public DataTable getDS(int MaNV, int Nam)
        {
            string sql = "declare @Nam int;"
                        + " declare @MaNV int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @MaNV=" + MaNV + ";"
                        + " select t1.* from"
                        + " (select distinct db.TenTo,db.MaNV,db.NhanVien,db.HoTen,db.HOPDONG,db.DanhBo,db.MLT,db.DiaChi,db.DM,ky1.Ky1,ky2.Ky2,ky3.Ky3,ky4.Ky4,"
                        + " ky5.Ky5,ky6.Ky6,ky7.Ky7,ky8.Ky8,ky9.Ky9,ky10.Ky10,ky11.Ky11,ky12.Ky12,row_number() over (partition by db.DanhBo order by db.MaHD desc) as RowNumber"
                        + " from"
                        + " (select TenTo,MaNV,NhanVien=nd.HoTen,hd.HOPDONG,hd.DANHBA as DanhBo,MLT=hd.MALOTRINH,HoTen=hd.TENKH,hd.SO+' '+hd.DUONG as DiaChi,hd.ID_HOADON as MaHD,DM"
                        + " from TT_DangKy2 dk,HOADON hd,TT_NguoiDung nd,TT_To tto"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=nd.MaND and nd.MaTo=tto.MaTo and dk.MaNV=@MaNV) db"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky1"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=1) ky1 on db.DanhBo=ky1.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky2"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=2) ky2 on db.DanhBo=ky2.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky3"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=3) ky3 on db.DanhBo=ky3.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky4"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=4) ky4 on db.DanhBo=ky4.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky5"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=5) ky5 on db.DanhBo=ky5.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky6"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=6) ky6 on db.DanhBo=ky6.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky7"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=7) ky7 on db.DanhBo=ky7.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky8"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=8) ky8 on db.DanhBo=ky8.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky9"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=9) ky9 on db.DanhBo=ky9.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky10"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=10) ky10 on db.DanhBo=ky10.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky11"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=11) ky11 on db.DanhBo=ky11.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky12"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=12) ky12 on db.DanhBo=ky12.DanhBo) t1"
                        + " where RowNumber=1";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS(int MaNV, int Nam,int FromDot,int ToDot)
        {
            string sql = "declare @Nam int;"
                        + " declare @MaNV int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @MaNV=" + MaNV + ";"
                        + " select t1.* from"
                        + " (select distinct db.TenTo,db.MaNV,db.NhanVien,db.HoTen,db.HOPDONG,db.DanhBo,db.MLT,db.DiaChi,db.DM,ky1.Ky1,ky2.Ky2,ky3.Ky3,ky4.Ky4,"
                        + " ky5.Ky5,ky6.Ky6,ky7.Ky7,ky8.Ky8,ky9.Ky9,ky10.Ky10,ky11.Ky11,ky12.Ky12,row_number() over (partition by db.DanhBo order by db.MaHD desc) as RowNumber"
                        + " from"
                        + " (select TenTo,MaNV,NhanVien=nd.HoTen,hd.HOPDONG,hd.DANHBA as DanhBo,MLT=hd.MALOTRINH,HoTen=hd.TENKH,hd.SO+' '+hd.DUONG as DiaChi,hd.ID_HOADON as MaHD,DM"
                        + " from TT_DangKy2 dk,HOADON hd,TT_NguoiDung nd,TT_To tto"
                        + " where hd.DOT>=" + FromDot + " and hd.DOT<=" + ToDot + " and dk.DanhBo=hd.DANHBA and dk.MaNV=nd.MaND and nd.MaTo=tto.MaTo and dk.MaNV=@MaNV) db"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky1"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=1) ky1 on db.DanhBo=ky1.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky2"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=2) ky2 on db.DanhBo=ky2.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky3"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=3) ky3 on db.DanhBo=ky3.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky4"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=4) ky4 on db.DanhBo=ky4.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky5"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=5) ky5 on db.DanhBo=ky5.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky6"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=6) ky6 on db.DanhBo=ky6.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky7"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=7) ky7 on db.DanhBo=ky7.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky8"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=8) ky8 on db.DanhBo=ky8.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky9"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=9) ky9 on db.DanhBo=ky9.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky10"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=10) ky10 on db.DanhBo=ky10.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky11"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=11) ky11 on db.DanhBo=ky11.DanhBo"
                        + " left join"
                        + " (select dk.DanhBo,TIEUTHU as Ky12"
                        + " from TT_DangKy2 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@Nam and KY=12) ky12 on db.DanhBo=ky12.DanhBo) t1"
                        + " where RowNumber=1";

            return ExecuteQuery_DataTable(sql);
        }
    }
}

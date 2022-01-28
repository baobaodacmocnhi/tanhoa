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

        public DataTable getDS(int Nam)
        {
            string sql = "declare @Nam int;"
                         + " set @Nam=" + Nam + ";"
                         + " select t1.* from"
                         + " (select distinct db.HoTen,db.HOPDONG,db.DanhBo,db.MLT,db.DiaChi,db.DM,ky1.Ky1,ky2.Ky2,ky3.Ky3,ky4.Ky4,"
                         + " ky5.Ky5,ky6.Ky6,ky7.Ky7,ky8.Ky8,ky9.Ky9,ky10.Ky10,ky11.Ky11,ky12.Ky12"
                         + " ,TieuThu1,NgayGiaiTrach1,TieuThu2,NgayGiaiTrach2,TieuThu3,NgayGiaiTrach3,TieuThu4,NgayGiaiTrach4,TieuThu5,NgayGiaiTrach5,TieuThu6,NgayGiaiTrach6,TieuThu7,NgayGiaiTrach7,TieuThu8,NgayGiaiTrach8,TieuThu9,NgayGiaiTrach9,TieuThu10,NgayGiaiTrach10,TieuThu11,NgayGiaiTrach11,TieuThu12,NgayGiaiTrach12" 
                         + " ,row_number() over (partition by db.DanhBo order by db.MaHD desc) as RowNumber"
                         + " from"
                         + " (select hd.HOPDONG,hd.DANHBA as DanhBo,MLT=hd.MALOTRINH,HoTen=hd.TENKH,hd.SO+' '+hd.DUONG as DiaChi,hd.ID_HOADON as MaHD,DM"
                         + " from TT_DangKy2 dk,HOADON hd"
                         + " where dk.DanhBo=hd.DANHBA) db"
                         + " left join"
                         + " (select dk.DanhBo,case when NGAYGIAITRACH is not null then 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: '+CONVERT(varchar(10),NGAYGIAITRACH,103) else 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: ' end as Ky1,TieuThu1=TIEUTHU,NgayGiaiTrach1=NGAYGIAITRACH"
                         + " from TT_DangKy2 dk,HOADON hd"
                         + " where dk.DanhBo=hd.DANHBA and NAM=@Nam and KY=1) ky1 on db.DanhBo=ky1.DanhBo"
                         + " left join"
                         + " (select dk.DanhBo,case when NGAYGIAITRACH is not null then 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: '+CONVERT(varchar(10),NGAYGIAITRACH,103) else 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: ' end as Ky2,TieuThu2=TIEUTHU,NgayGiaiTrach2=NGAYGIAITRACH"
                         + " from TT_DangKy2 dk,HOADON hd"
                         + " where dk.DanhBo=hd.DANHBA and NAM=@Nam and KY=2) ky2 on db.DanhBo=ky2.DanhBo"
                         + " left join"
                         + " (select dk.DanhBo,case when NGAYGIAITRACH is not null then 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: '+CONVERT(varchar(10),NGAYGIAITRACH,103) else 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: ' end as Ky3,TieuThu3=TIEUTHU,NgayGiaiTrach3=NGAYGIAITRACH"
                         + " from TT_DangKy2 dk,HOADON hd"
                         + " where dk.DanhBo=hd.DANHBA and NAM=@Nam and KY=3) ky3 on db.DanhBo=ky3.DanhBo"
                         + " left join"
                         + " (select dk.DanhBo,case when NGAYGIAITRACH is not null then 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: '+CONVERT(varchar(10),NGAYGIAITRACH,103) else 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: ' end as Ky4,TieuThu4=TIEUTHU,NgayGiaiTrach4=NGAYGIAITRACH"
                         + " from TT_DangKy2 dk,HOADON hd"
                         + " where dk.DanhBo=hd.DANHBA and NAM=@Nam and KY=4) ky4 on db.DanhBo=ky4.DanhBo"
                         + " left join"
                         + " (select dk.DanhBo,case when NGAYGIAITRACH is not null then 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: '+CONVERT(varchar(10),NGAYGIAITRACH,103) else 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: ' end as Ky5,TieuThu5=TIEUTHU,NgayGiaiTrach5=NGAYGIAITRACH"
                         + " from TT_DangKy2 dk,HOADON hd"
                         + " where dk.DanhBo=hd.DANHBA and NAM=@Nam and KY=5) ky5 on db.DanhBo=ky5.DanhBo"
                         + " left join"
                         + " (select dk.DanhBo,case when NGAYGIAITRACH is not null then 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: '+CONVERT(varchar(10),NGAYGIAITRACH,103) else 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: ' end as Ky6,TieuThu6=TIEUTHU,NgayGiaiTrach6=NGAYGIAITRACH"
                         + " from TT_DangKy2 dk,HOADON hd"
                         + " where dk.DanhBo=hd.DANHBA and NAM=@Nam and KY=6) ky6 on db.DanhBo=ky6.DanhBo"
                         + " left join"
                         + " (select dk.DanhBo,case when NGAYGIAITRACH is not null then 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: '+CONVERT(varchar(10),NGAYGIAITRACH,103) else 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: ' end as Ky7,TieuThu7=TIEUTHU,NgayGiaiTrach7=NGAYGIAITRACH"
                         + " from TT_DangKy2 dk,HOADON hd"
                         + " where dk.DanhBo=hd.DANHBA and NAM=@Nam and KY=7) ky7 on db.DanhBo=ky7.DanhBo"
                         + " left join"
                         + " (select dk.DanhBo,case when NGAYGIAITRACH is not null then 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: '+CONVERT(varchar(10),NGAYGIAITRACH,103) else 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: ' end as Ky8,TieuThu8=TIEUTHU,NgayGiaiTrach8=NGAYGIAITRACH"
                         + " from TT_DangKy2 dk,HOADON hd"
                         + " where dk.DanhBo=hd.DANHBA and NAM=@Nam and KY=8) ky8 on db.DanhBo=ky8.DanhBo"
                         + " left join"
                         + " (select dk.DanhBo,case when NGAYGIAITRACH is not null then 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: '+CONVERT(varchar(10),NGAYGIAITRACH,103) else 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: ' end as Ky9,TieuThu9=TIEUTHU,NgayGiaiTrach9=NGAYGIAITRACH"
                         + " from TT_DangKy2 dk,HOADON hd"
                         + " where dk.DanhBo=hd.DANHBA and NAM=@Nam and KY=9) ky9 on db.DanhBo=ky9.DanhBo"
                         + " left join"
                         + " (select dk.DanhBo,case when NGAYGIAITRACH is not null then 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: '+CONVERT(varchar(10),NGAYGIAITRACH,103) else 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: ' end as Ky10,TieuThu10=TIEUTHU,NgayGiaiTrach10=NGAYGIAITRACH"
                         + " from TT_DangKy2 dk,HOADON hd"
                         + " where dk.DanhBo=hd.DANHBA and NAM=@Nam and KY=10) ky10 on db.DanhBo=ky10.DanhBo"
                         + " left join"
                         + " (select dk.DanhBo,case when NGAYGIAITRACH is not null then 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: '+CONVERT(varchar(10),NGAYGIAITRACH,103) else 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: ' end as Ky11,TieuThu11=TIEUTHU,NgayGiaiTrach11=NGAYGIAITRACH"
                         + " from TT_DangKy2 dk,HOADON hd"
                         + " where dk.DanhBo=hd.DANHBA and NAM=@Nam and KY=11) ky11 on db.DanhBo=ky11.DanhBo"
                         + " left join"
                         + " (select dk.DanhBo,case when NGAYGIAITRACH is not null then 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: '+CONVERT(varchar(10),NGAYGIAITRACH,103) else 'TT: '+CONVERT(varchar(10),TIEUTHU)+'\r\nTC: '+CONVERT(varchar(10),TONGCONG)+'\r\nĐN: ' end as Ky12,TieuThu12=TIEUTHU,NgayGiaiTrach12=NGAYGIAITRACH"
                         + " from TT_DangKy2 dk,HOADON hd"
                         + " where dk.DanhBo=hd.DANHBA and NAM=@Nam and KY=12) ky12 on db.DanhBo=ky12.DanhBo) t1"
                         + " where RowNumber=1";

            return ExecuteQuery_DataTable(sql);
        }

    }
}

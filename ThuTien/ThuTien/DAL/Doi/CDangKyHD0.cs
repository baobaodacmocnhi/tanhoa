using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.Doi
{
    class CDangKyHD0 : CDAL
    {
        public bool Them(TT_DangKyHD0 dangky)
        {
            try
            {
                dangky.CreateDate = DateTime.Now;
                dangky.CreateBy = CNguoiDung.MaND;
                _db.TT_DangKyHD0s.InsertOnSubmit(dangky);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(TT_DangKyHD0 dangky)
        {
            try
            {
                _db.TT_DangKyHD0s.DeleteOnSubmit(dangky);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(TT_DangKyHD0 dangky)
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
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(string DanhBo)
        {
            return _db.TT_DangKyHD0s.Any(item => item.DanhBo == DanhBo);
        }

        public TT_DangKyHD0 GetByID(string DanhBo)
        {
            return _db.TT_DangKyHD0s.SingleOrDefault(item => item.DanhBo == DanhBo);
        }

        public DataTable GetDS(int MaNV, int Nam)
        {
            string sql = "declare @nam int;"
                        + " declare @MaNV int;"
                        + " set @nam="+Nam+";"
                        + " set @MaNV="+MaNV+";"
                        + " select ky1.TenTo,ky1.MaNV,ky1.HoTen,ky1.DanhBo,ky1.DiaChi,ky1.TIEUTHU as Ky1,ky2.TIEUTHU as Ky2,ky3.TIEUTHU as Ky3,"
                                + " ky4.TIEUTHU as Ky4,ky4.TIEUTHU as Ky4,ky5.TIEUTHU as Ky5,ky6.TIEUTHU as Ky6,"
                                + " ky7.TIEUTHU as Ky7,ky8.TIEUTHU as Ky8,ky9.TIEUTHU as Ky9,ky10.TIEUTHU as Ky10,"
                                + " ky11.TIEUTHU as Ky11,ky12.TIEUTHU as Ky12"
                        + " from"
                        + " (select TenTo,MaNV,nd.HoTen,dk.DanhBo,hd.SO+' '+hd.DUONG as DiaChi,TIEUTHU"
                        + " from TT_DangKyHD0 dk,HOADON hd,TT_NguoiDung nd,TT_To tto"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=nd.MaND and nd.MaTo=tto.MaTo and dk.MaNV=@MaNV and NAM=@nam and KY=1) ky1"
                        + " left join"
                        + " (select MaNV,dk.DanhBo,TIEUTHU"
                        + " from TT_DangKyHD0 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@nam and KY=2) ky2 on ky1.DanhBo=ky2.DanhBo"
                        + " left join"
                        + " (select MaNV,dk.DanhBo,TIEUTHU"
                        + " from TT_DangKyHD0 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@nam and KY=3) ky3 on ky1.DanhBo=ky3.DanhBo"
                        + " left join"
                        + " (select MaNV,dk.DanhBo,TIEUTHU"
                        + " from TT_DangKyHD0 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@nam and KY=4) ky4 on ky1.DanhBo=ky4.DanhBo"
                        + " left join"
                        + " (select MaNV,dk.DanhBo,TIEUTHU"
                        + " from TT_DangKyHD0 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@nam and KY=5) ky5 on ky1.DanhBo=ky5.DanhBo"
                        + " left join"
                        + " (select MaNV,dk.DanhBo,TIEUTHU"
                        + " from TT_DangKyHD0 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@nam and KY=6) ky6 on ky1.DanhBo=ky6.DanhBo"
                        + " left join"
                        + " (select MaNV,dk.DanhBo,TIEUTHU"
                        + " from TT_DangKyHD0 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@nam and KY=7) ky7 on ky1.DanhBo=ky7.DanhBo"
                        + " left join"
                        + " (select MaNV,dk.DanhBo,TIEUTHU"
                        + " from TT_DangKyHD0 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@nam and KY=8) ky8 on ky1.DanhBo=ky8.DanhBo"
                        + " left join"
                        + " (select MaNV,dk.DanhBo,TIEUTHU"
                        + " from TT_DangKyHD0 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@nam and KY=9) ky9 on ky1.DanhBo=ky9.DanhBo"
                        + " left join"
                        + " (select MaNV,dk.DanhBo,TIEUTHU"
                        + " from TT_DangKyHD0 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@nam and KY=10) ky10 on ky1.DanhBo=ky10.DanhBo"
                        + " left join"
                        + " (select MaNV,dk.DanhBo,TIEUTHU"
                        + " from TT_DangKyHD0 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@nam and KY=11) ky11 on ky1.DanhBo=ky11.DanhBo"
                        + " left join"
                        + " (select MaNV,dk.DanhBo,TIEUTHU"
                        + " from TT_DangKyHD0 dk,HOADON hd"
                        + " where dk.DanhBo=hd.DANHBA and dk.MaNV=@MaNV and NAM=@nam and KY=12) ky12 on ky1.DanhBo=ky12.DanhBo";

            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }
    }
}

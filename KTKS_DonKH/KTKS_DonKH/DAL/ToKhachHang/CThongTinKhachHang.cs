using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.DAL.ToKhachHang
{
    class CThongTinKhachHang:CDAL
    {
        public bool Them(ThongTinKhachHang entity)
        {
            try
            {
                if (db.ThongTinKhachHangs.Count() == 0)
                    entity.ID = 1;
                else
                    entity.ID = db.ThongTinKhachHangs.Max(item => item.ID) + 1;
                entity.CreateBy = CTaiKhoan.MaUser;
                entity.CreateDate = DateTime.Now;
                db.ThongTinKhachHangs.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Sua(ThongTinKhachHang entity)
        {
            try
            {
                entity.ModifyBy = CTaiKhoan.MaUser;
                entity.ModifyDate = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckExist(string DienThoai, string DanhBo)
        {
            return db.ThongTinKhachHangs.Any(item => item.DienThoai == DienThoai && item.DanhBo == DanhBo);
        }

        public ThongTinKhachHang Get(string DienThoai, string DanhBo)
        {
            return db.ThongTinKhachHangs.SingleOrDefault(item=>item.DienThoai==DienThoai&&item.DanhBo==DanhBo);
        }
    }
}

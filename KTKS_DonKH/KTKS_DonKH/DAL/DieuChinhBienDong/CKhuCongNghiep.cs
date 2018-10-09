using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.DieuChinhBienDong
{
    class CKhuCongNghiep:CDAL
    {
        public bool Them(KhuCongNghiep en)
        {
            try
            {
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.KhuCongNghieps.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(KhuCongNghiep en)
        {
            try
            {
                db.KhuCongNghieps.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist(string DanhBo)
        {
            return db.KhuCongNghieps.Any(item => item.DanhBo == DanhBo);
        }

        public KhuCongNghiep get(string DanhBo)
        {
            return db.KhuCongNghieps.SingleOrDefault(item => item.DanhBo == DanhBo);
        }

        public DataTable getDS()
        {
            return LINQToDataTable( db.KhuCongNghieps.ToList());
        }
    }
}

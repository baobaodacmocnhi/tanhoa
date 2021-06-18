using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.DieuChinhBienDong
{
    class CKhuCongNghiep : CDAL
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
            return LINQToDataTable(db.KhuCongNghieps.ToList());
        }

        //Khấu Trừ

        public bool Them_KhauTru(DCBD_KhauTru en)
        {
            try
            {
                if (db.DCBD_KhauTrus.Count() > 0)
                    en.ID = db.DCBD_KhauTrus.Max(item => item.ID) + 1;
                else
                    en.ID = 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.DCBD_KhauTrus.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_KhauTru(DCBD_KhauTru en)
        {
            try
            {
                db.DCBD_KhauTrus.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua_KhauTru(DCBD_KhauTru en)
        {
            try
            {
                en.ModifyBy = CTaiKhoan.MaUser;
                en.ModifyDate = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist_KhauTru(string DanhBo)
        {
            return db.DCBD_KhauTrus.Any(item => item.DanhBo == DanhBo && item.TatToan == false);
        }

        public DCBD_KhauTru get_KhauTru(string DanhBo)
        {
            return db.DCBD_KhauTrus.SingleOrDefault(item => item.DanhBo == DanhBo && item.TatToan == false);
        }

        public DataTable getDS_KhauTru()
        {
            return LINQToDataTable(db.DCBD_KhauTrus.ToList());
        }

        //Khấu Trừ Lịch Sử

        public bool Them_KhauTruLichSu(DCBD_KhauTru_LichSu en)
        {
            try
            {
                if (db.DCBD_KhauTru_LichSus.Count() > 0)
                    en.ID = db.DCBD_KhauTru_LichSus.Max(item => item.ID) + 1;
                else
                    en.ID = 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.DCBD_KhauTru_LichSus.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_KhauTruLichSu(DCBD_KhauTru_LichSu en)
        {
            try
            {
                db.DCBD_KhauTru_LichSus.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public DataTable getDS_KhauTruLichSu(int IDKhauTru)
        {
            return LINQToDataTable(db.DCBD_KhauTru_LichSus.Where(item => item.IDKhauTru == IDKhauTru));
        }

    }
}

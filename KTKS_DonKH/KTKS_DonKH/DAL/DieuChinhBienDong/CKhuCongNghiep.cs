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
        CThuTien _cThuTien = new CThuTien();

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

        public DCBD_KhauTru get_KhauTru(int ID)
        {
            return db.DCBD_KhauTrus.SingleOrDefault(item => item.ID == ID);
        }

        public DCBD_KhauTru get_KhauTruTon(string DanhBo)
        {
            return db.DCBD_KhauTrus.SingleOrDefault(item => item.DanhBo == DanhBo && item.TatToan == false);
        }

        public DataTable getDS_KhauTru()
        {
            return LINQToDataTable(db.DCBD_KhauTrus.ToList());
        }

        public string getDSKhauTruCoHoaDonMoi()
        {
            string str = "Khấu Trừ: ";
            foreach (DCBD_KhauTru item in db.DCBD_KhauTrus.ToList())
            {
                HOADON hd = _cThuTien.GetMoiNhat(item.DanhBo);
                if (db.DCBD_ChiTietHoaDons.Any(itemA => itemA.DanhBo == hd.DANHBA && itemA.KyHD.Contains(hd.KY + "/" + hd.NAM) == true) == false)
                    str += hd.DANHBA + " có hóa đơn kỳ " + hd.KY + "/" + hd.NAM;
            }
            return str;
        }

        public int getSoTienKhauTruTon(string DanhBo)
        {
            DCBD_KhauTru en = get_KhauTruTon(DanhBo);
            if (en != null)
            {
                if (en.DCBD_KhauTru_LichSus.Count == 0)
                    return en.SoTien.Value;
                else
                    return en.SoTien.Value - en.DCBD_KhauTru_LichSus.Sum(item => item.SoTien).Value;
            }
            else return 0;
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

        public bool Sua_KhauTruLichSu(DCBD_KhauTru_LichSu en)
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

        public bool checkExist_KhauTruLichSu(int IDDCHD)
        {
            return db.DCBD_KhauTru_LichSus.Any(item => item.IDDCHD == IDDCHD);
        }

        public DCBD_KhauTru_LichSu get_KhauTruLichSu(int IDDCHD)
        {
            return db.DCBD_KhauTru_LichSus.SingleOrDefault(item => item.IDDCHD == IDDCHD);
        }

        public DataTable getDS_KhauTruLichSu(int IDKhauTru)
        {
            return LINQToDataTable(db.DCBD_KhauTru_LichSus.Where(item => item.IDKhauTru == IDKhauTru));
        }



    }
}

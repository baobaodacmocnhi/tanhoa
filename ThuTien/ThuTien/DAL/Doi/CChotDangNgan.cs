using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.Doi
{
    class CChotDangNgan : CDAL
    {
        public bool them(TT_ChotDangNgan en)
        {
            try
            {
                if (_db.TT_ChotDangNgans.Count() > 0)
                    en.ID = _db.TT_ChotDangNgans.Max(item => item.ID) + 1;
                else
                    en.ID = 1;
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.TT_ChotDangNgans.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool sua(TT_ChotDangNgan en)
        {
            try
            {
                en.ModifyBy = CNguoiDung.MaND;
                en.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool xoa(TT_ChotDangNgan en)
        {
            try
            {
                _db.TT_ChotDangNgans.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist(DateTime NgayChot)
        {
            return _db.TT_ChotDangNgans.Any(item => item.NgayChot.Value.Date == NgayChot.Date);
        }

        public bool checkExist_ChotDangNgan(DateTime NgayChot)
        {
            return _db.TT_ChotDangNgans.Any(item => item.NgayChot.Value.Date == NgayChot.Date && item.Chot == true);
        }

        public TT_ChotDangNgan get(int ID)
        {
            return _db.TT_ChotDangNgans.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS(DateTime FromNgayChot, DateTime ToNgayChot)
        {
            string sql = "select ID,NgayChot,Chot,"
                        + " SLDangNgan=(select COUNT(ID_HOADON) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date)),"
                        + " SLThanhToan=(select COUNT(ID_HOADON) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date) and SyncThanhToan=1),"
                        + " SLNopTien=(select COUNT(ID_HOADON) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date) and SyncNopTien=1)"
                        + " from TT_ChotDangNgan where CAST(NgayChot as date)>='" + FromNgayChot.ToString("yyyyMMdd") + "' and CAST(NgayChot as date)<='" + ToNgayChot.ToString("yyyyMMdd") + "'"
                        + " group by ID,NgayChot,Chot order by ID desc";
            return ExecuteQuery_DataTable(sql);
        }

    }
}

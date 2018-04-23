using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTCN_CongVan.LinQ;
using System.Data;

namespace KTCN_CongVan.DAL
{
    class CCongVanDi : CDAL
    {
        public bool Them(CongVanDi entity)
        {
            try
            {
                if (_db.CongVanDis.Count() > 0)
                    entity.ID = _db.CongVanDis.Max(item => item.ID) + 1;
                else
                    entity.ID = 1;
                entity.CreateDate = DateTime.Now;
                _db.CongVanDis.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(CongVanDi entity)
        {
            try
            {
                entity.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(CongVanDi entity)
        {
            try
            {
                _db.CongVanDis.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public CongVanDi Get(int ID)
        {
            return _db.CongVanDis.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetLoaiCongVan()
        {
            return LINQToDataTable(_db.CongVanDis.Select(item => new { item.LoaiCongVan }).ToList().Distinct());
        }

        public DataTable GetDS()
        {
            return LINQToDataTable(_db.CongVanDis.ToList());
        }

        public DataTable GetDS_SoCongVan(string SoCongVan)
        {
            return LINQToDataTable(_db.CongVanDis.Where(item => item.SoCongVan.Contains(SoCongVan)).ToList());
        }

        public DataTable GetDS_NoiNhan(string NoiNhan)
        {
            return LINQToDataTable(_db.CongVanDis.Where(item => item.NoiNhan.Contains(NoiNhan)).ToList());
        }

        public DataTable GetDS(DateTime FromNgayNhan,DateTime ToNgayNhan)
        {
            return LINQToDataTable(_db.CongVanDis.Where(item=>item.NgayNhan.Value.Date>=FromNgayNhan.Date&&item.NgayNhan.Value.Date<=ToNgayNhan.Date).ToList());
        }

        public DataTable GetDS_NgayHetHan(DateTime FromNgayHetHan, DateTime ToNgayHetHan)
        {
            return LINQToDataTable(_db.CongVanDis.Where(item => item.NgayHetHan.Value.Date >= FromNgayHetHan.Date && item.NgayHetHan.Value.Date <= ToNgayHetHan.Date).ToList());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTCN_CongVan.LinQ;
using System.Data;

namespace KTCN_CongVan.DAL
{
    class CCongVanDen:CDAL
    {
        public bool Them(CongVanDen entity)
        {
            try
            {
                if (_db.CongVanDens.Count() > 0)
                    entity.ID = _db.CongVanDens.Max(item => item.ID) + 1;
                else
                    entity.ID = 1;
                entity.CreateDate = DateTime.Now;
                _db.CongVanDens.InsertOnSubmit(entity);
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

        public bool Sua(CongVanDen entity)
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

        public bool Xoa(CongVanDen entity)
        {
            try
            {
                _db.CongVanDens.DeleteOnSubmit(entity);
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

        public CongVanDen Get(int ID)
        {
            return _db.CongVanDens.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetLoaiCongVan()
        {
            return LINQToDataTable(_db.CongVanDens.Select(item => new { item.LoaiCongVan }).ToList().Distinct());
        }

        public DataTable GetNoiDung()
        {
            return LINQToDataTable(_db.CongVanDens.Select(item => new { item.NoiDung }).ToList().Distinct());
        }

        public DataTable GetDS()
        {
            return LINQToDataTable(_db.CongVanDens.ToList());
        }

        public DataTable GetDS_SoCongVan(string SoCongVan)
        {
            return LINQToDataTable(_db.CongVanDens.Where(item => item.SoCongVan.Contains(SoCongVan)).ToList());
        }

        public DataTable GetDS_NoiNhan(string NoiNhan)
        {
            return LINQToDataTable(_db.CongVanDens.Where(item => item.NoiNhan.Contains(NoiNhan)).ToList());
        }

        public DataTable GetDS(DateTime FromNgayNhan, DateTime ToNgayNhan)
        {
            return LINQToDataTable(_db.CongVanDens.Where(item => item.NgayNhan.Value.Date >= FromNgayNhan.Date && item.NgayNhan.Value.Date <= ToNgayNhan.Date).ToList());
        }

        public DataTable GetDS_NgayHetHan(DateTime FromNgayHetHan, DateTime ToNgayHetHan)
        {
            return LINQToDataTable(_db.CongVanDens.Where(item => item.NgayHetHan.Value.Date >= FromNgayHetHan.Date && item.NgayHetHan.Value.Date <= ToNgayHetHan.Date).ToList());
        }
    }
}

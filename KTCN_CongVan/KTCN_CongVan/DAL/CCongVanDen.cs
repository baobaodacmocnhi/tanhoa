using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTCN_CongVan.LinQ;
using System.Data;
using KTCN_CongVan.DAL.QuanTri;

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
                entity.CreateBy = CUser.ID;
                entity.CreateDate = DateTime.Now;
                entity.IDPhong = CUser.IDPhong;
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
                entity.ModifyBy = CUser.ID;
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

        public CongVanDen get(int ID)
        {
            return _db.CongVanDens.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getLoaiCongVan(int IDPhong)
        {
            return LINQToDataTable(_db.CongVanDens.Select(item => new { item.LoaiCongVan }).ToList().Distinct());
        }

        public DataTable getNoiDung(int IDPhong)
        {
            return LINQToDataTable(_db.CongVanDens.Select(item => new { item.NoiDung }).ToList().Distinct());
        }

        public DataTable GetDS()
        {
            return LINQToDataTable(_db.CongVanDens.ToList());
        }

        public DataTable getDS_SoCongVan(int IDPhong,string SoCongVan)
        {
            return LINQToDataTable(_db.CongVanDens.Where(item => item.SoCongVan.Contains(SoCongVan)).ToList());
        }

        public DataTable getDS_NoiDung(int IDPhong, string NoiDung)
        {
            return LINQToDataTable(_db.CongVanDens.Where(item => item.NoiDung.Contains(NoiDung)).ToList());
        }

        public DataTable getDS_NoiNhan(int IDPhong, string NoiNhan)
        {
            return LINQToDataTable(_db.CongVanDens.Where(item => item.NoiNhan.Contains(NoiNhan)).ToList());
        }

        public DataTable getDS(int IDPhong, DateTime FromNgayNhan, DateTime ToNgayNhan)
        {
            return LINQToDataTable(_db.CongVanDens.Where(item => item.NgayNhan.Value.Date >= FromNgayNhan.Date && item.NgayNhan.Value.Date <= ToNgayNhan.Date).ToList());
        }

        public DataTable getDS_NgayHetHan(int IDPhong, DateTime FromNgayHetHan, DateTime ToNgayHetHan)
        {
            return LINQToDataTable(_db.CongVanDens.Where(item => item.NgayHetHan.Value.Date >= FromNgayHetHan.Date && item.NgayHetHan.Value.Date <= ToNgayHetHan.Date).ToList());
        }
    }
}

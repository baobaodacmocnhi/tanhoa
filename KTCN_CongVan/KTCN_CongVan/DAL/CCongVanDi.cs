using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTCN_CongVan.LinQ;
using System.Data;
using KTCN_CongVan.DAL.QuanTri;

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
                entity.CreateBy = CUser.ID;
                entity.CreateDate = DateTime.Now;
                entity.IDPhong = CUser.IDPhong;
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

        public CongVanDi get(int ID)
        {
            return _db.CongVanDis.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getLoaiCongVan(int IDPhong)
        {
            return LINQToDataTable(_db.CongVanDis.Where(item => item.IDPhong == IDPhong).Select(item => new { item.LoaiCongVan }).ToList().Distinct());
        }

        public DataTable getNoiDung(int IDPhong)
        {
            return LINQToDataTable(_db.CongVanDis.Where(item=>item.IDPhong==IDPhong).Select(item => new { item.NoiDung }).ToList().Distinct());
        }

        public DataTable GetDS()
        {
            return LINQToDataTable(_db.CongVanDis.ToList());
        }

        public DataTable getDS_SoCongVan(int IDPhong,string SoCongVan)
        {
            return LINQToDataTable(_db.CongVanDis.Where(item => item.IDPhong == IDPhong && item.SoCongVan.Contains(SoCongVan)).ToList());
        }

        public DataTable getDS_NoiDung(int IDPhong, string NoiDung)
        {
            return LINQToDataTable(_db.CongVanDis.Where(item => item.IDPhong == IDPhong && item.NoiDung.Contains(NoiDung)).ToList());
        }

        public DataTable getDS_NoiNhan(int IDPhong, string NoiNhan)
        {
            return LINQToDataTable(_db.CongVanDis.Where(item => item.IDPhong == IDPhong && item.NoiNhan.Contains(NoiNhan)).ToList());
        }

        public DataTable getDS(int IDPhong, DateTime FromNgayNhan, DateTime ToNgayNhan)
        {
            return LINQToDataTable(_db.CongVanDis.Where(item => item.IDPhong == IDPhong && item.NgayNhan.Value.Date >= FromNgayNhan.Date && item.NgayNhan.Value.Date <= ToNgayNhan.Date).ToList());
        }

        public DataTable getDS_NgayHetHan(int IDPhong, DateTime FromNgayHetHan, DateTime ToNgayHetHan)
        {
            return LINQToDataTable(_db.CongVanDis.Where(item =>item.IDPhong==IDPhong && item.NgayHetHan.Value.Date >= FromNgayHetHan.Date && item.NgayHetHan.Value.Date <= ToNgayHetHan.Date).ToList());
        }

        public DataTable getDS_Ton(int IDPhong)
        {
            return LINQToDataTable(_db.CongVanDis.Where(item => item.IDPhong == IDPhong && item.HoanTat==false).ToList());
        }
    }
}

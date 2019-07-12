using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrungTamKhachHang.LinQ;
using TrungTamKhachHang.DAL.QuanTri;
using System.Data;

namespace TrungTamKhachHang.DAL.LichDocSoThuTien
{
    class CLichThuTien : CTrungTamKhachHang
    {
        public bool Them(Lich_ThuTien entity)
        {
            try
            {
                if (_db.Lich_ThuTiens.Count() > 0)
                    entity.ID = _db.Lich_ThuTiens.Max(item => item.ID) + 1;
                else
                    entity.ID = 1;
                entity.CreateBy = CUser.MaUser;
                entity.CreateDate = DateTime.Now;

                foreach (Lich_Dot item in _db.Lich_Dots.ToList())
                {
                    Lich_ThuTien_ChiTiet enCT = new Lich_ThuTien_ChiTiet();
                    enCT.IDThuTien = entity.ID;
                    enCT.IDDot = item.ID;
                    enCT.CreateBy = CUser.MaUser;
                    enCT.CreateDate = DateTime.Now;
                    entity.Lich_ThuTien_ChiTiets.Add(enCT);
                }

                _db.Lich_ThuTiens.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(Lich_ThuTien entity)
        {
            try
            {
                entity.ModifyBy = CUser.MaUser;
                entity.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Xoa(Lich_ThuTien entity)
        {
            try
            {
                _db.Lich_ThuTiens.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist(int Ky, int Nam)
        {
            return _db.Lich_ThuTiens.Any(item => item.Ky == Ky && item.Nam == Nam);
        }

        public Lich_ThuTien get(int ID)
        {
            return _db.Lich_ThuTiens.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS()
        {
            return LINQToDataTable(_db.Lich_ThuTiens.OrderByDescending(item => item.CreateDate).ToList());
        }

        public DataTable getDS_ChiTiet(int IDThuTien)
        {
            return LINQToDataTable(_db.Lich_ThuTien_ChiTiets.Where(item=>item.IDThuTien==IDThuTien).ToList());
        }
    }
}

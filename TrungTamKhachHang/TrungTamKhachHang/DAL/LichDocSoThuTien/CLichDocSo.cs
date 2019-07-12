using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrungTamKhachHang.LinQ;
using TrungTamKhachHang.DAL.QuanTri;
using System.Data;

namespace TrungTamKhachHang.DAL.LichDocSoThuTien
{
    class CLichDocSo : CTrungTamKhachHang
    {
        public bool Them(Lich_DocSo entity)
        {
            try
            {
                if (_db.Lich_DocSos.Count() > 0)
                    entity.ID = _db.Lich_DocSos.Max(item => item.ID) + 1;
                else
                    entity.ID = 1;
                entity.CreateBy = CUser.MaUser;
                entity.CreateDate = DateTime.Now;

                foreach (Lich_Dot item in _db.Lich_Dots.ToList())
                {
                    Lich_DocSo_ChiTiet enCT = new Lich_DocSo_ChiTiet();
                    enCT.IDDocSo = entity.ID;
                    enCT.IDDot = item.ID;
                    enCT.CreateBy = CUser.MaUser;
                    enCT.CreateDate = DateTime.Now;
                    entity.Lich_DocSo_ChiTiets.Add(enCT);
                }

                _db.Lich_DocSos.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(Lich_DocSo entity)
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

        public bool Xoa(Lich_DocSo entity)
        {
            try
            {
                _db.Lich_DocSos.DeleteOnSubmit(entity);
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
            return _db.Lich_DocSos.Any(item => item.Ky == Ky && item.Nam == Nam);
        }

        public Lich_DocSo get(int ID)
        {
            return _db.Lich_DocSos.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS()
        {
            return LINQToDataTable(_db.Lich_DocSos.OrderByDescending(item=>item.CreateDate).ToList());
        }

        public DataTable getDS_ChiTiet(int IDDocSo)
        {
            return LINQToDataTable(_db.Lich_DocSo_ChiTiets.Where(item => item.IDDocSo == IDDocSo).ToList());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using DocSo_PC.DAL.QuanTri;

namespace DocSo_PC.DAL
{
    class CLichDocSo
    {
        public static dbTrungTamKhachHangDataContext _db = new dbTrungTamKhachHangDataContext();
        public static CConnection _cDAL = new CConnection(_db.Connection.ConnectionString);

        public void SubmitChanges()
        {
            _db.SubmitChanges();
        }

        public void Refresh()
        {
            _db = new dbTrungTamKhachHangDataContext();
        }

        public bool Them(Lich_DocSo entity)
        {
            try
            {
                if (_db.Lich_DocSos.Count() > 0)
                    entity.ID = _db.Lich_DocSos.Max(item => item.ID) + 1;
                else
                    entity.ID = 1;
                entity.CreateBy = CNguoiDung.MaND;
                entity.CreateDate = DateTime.Now;

                foreach (Lich_Dot item in _db.Lich_Dots.ToList())
                {
                    Lich_DocSo_ChiTiet enCT = new Lich_DocSo_ChiTiet();
                    enCT.IDDocSo = entity.ID;
                    enCT.IDDot = item.ID;
                    enCT.CreateBy = CNguoiDung.MaND;
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
                entity.ModifyBy = CNguoiDung.MaND;
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
                _db.Lich_DocSo_ChiTiets.DeleteAllOnSubmit(entity.Lich_DocSo_ChiTiets.ToList());
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

        public Lich_DocSo get(int Ky, int Nam)
        {
            return _db.Lich_DocSos.SingleOrDefault(item => item.Ky == Ky && item.Nam == Nam);
        }

        public DateTime getNgayDoc(int Nam, int Ky, int Dot)
        {
            return get(Nam, Ky).Lich_DocSo_ChiTiets.SingleOrDefault(item => item.IDDot == Dot).NgayDoc.Value;
        }

        public string getNamKyDot(DateTime NgayDoc)
        {
            Lich_DocSo_ChiTiet en = _db.Lich_DocSo_ChiTiets.Where(item => item.NgayDoc.Value.Date == NgayDoc.Date).Take(1).SingleOrDefault();
            if (en != null)
                return en.Lich_DocSo.Nam.Value.ToString() + "-" + en.Lich_DocSo.Ky.Value.ToString("00") + "-" + en.Lich_Dot.ID.ToString("00");
            else
                return "";
        }

        public DataTable getDS()
        {
            return _cDAL.LINQToDataTable(_db.Lich_DocSos.OrderByDescending(item => item.CreateDate).ToList());
        }

        public DataTable getDS_ChiTiet(int IDDocSo)
        {
            return _cDAL.LINQToDataTable(_db.Lich_DocSo_ChiTiets.Where(item => item.IDDocSo == IDDocSo).ToList());
        }
    }
}

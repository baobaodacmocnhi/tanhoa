using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.Windows.Forms;
using DocSo_PC.DAL.QuanTri;

namespace DocSo_PC.DAL
{
    class CLichDocSo
    {
        public static dbTrungTamKhachHangDataContext _db = new dbTrungTamKhachHangDataContext();
        public static CConnection _cDAL = new CConnection("Data Source=serverg8-01;Initial Catalog=TRUNGTAMKHACHHANG;Persist Security Info=True;User ID=sa;Password=db11@tanhoa");

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

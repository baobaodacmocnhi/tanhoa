using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;
using System.Data;

namespace DocSo_PC.DAL.ToTruong
{
    class CDocSoTruoc : CDAL
    {
        public bool them(DocSoTruoc en)
        {
            try
            {
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.DocSoTruocs.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool xoa(DocSoTruoc en)
        {
            try
            {
                _db.DocSoTruocs.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist(string Nam, string Ky, string Dot, string May)
        {
            return _db.DocSoTruocs.Any(item => item.Nam == Convert.ToInt32(Nam) && item.Ky == Ky && item.Dot == Dot && item.May == May);
        }

        public DocSoTruoc get(string Nam, string Ky, string Dot, string May)
        {
            return _db.DocSoTruocs.SingleOrDefault(item => item.Nam == Convert.ToInt32(Nam) && item.Ky == Ky && item.Dot == Dot && item.May == May);
        }

        public DataTable getDS(string MaTo)
        {
            return _cDAL.LINQToDataTable(_db.DocSoTruocs.Where(item => Convert.ToInt32(item.May) >= _db.Tos.SingleOrDefault(itemT => itemT.MaTo == Convert.ToInt32(MaTo)).TuMay && Convert.ToInt32(item.May) <= _db.Tos.SingleOrDefault(itemT => itemT.MaTo == Convert.ToInt32(MaTo)).DenMay).OrderByDescending(item => item.CreateDate));
        }

    }
}

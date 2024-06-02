using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using System.Data;

namespace DocSo_PC.DAL.QuanTri
{
    class CMayDS : CDAL
    {
        public bool them(MayD en)
        {
            try
            {
                _db.MayDs.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool sua(MayD en)
        {
            try
            {
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool xoa(MayD en)
        {
            try
            {
                _db.MayDs.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExists(string May)
        {
            try
            {
                return _db.MayDs.Any(item => item.May == May);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable getDS()
        {
            var query = from itemM in _db.MayDs
                        join itemT in _db.Tos on Convert.ToInt32(itemM.MaTo) equals itemT.MaTo
                        select new
                        {
                            itemM.May,
                            To = itemT.TenTo
                        };
            return _cDAL.LINQToDataTable(query.ToList());
        }

        public DataTable getDS(int MaTo)
        {
            var query = from itemM in _db.MayDs
                        join itemT in _db.Tos on Convert.ToInt32(itemM.MaTo) equals itemT.MaTo
                        where itemM.MaTo == MaTo
                        select new
                        {
                            itemM.May,
                            To = itemT.TenTo
                        };
            return _cDAL.LINQToDataTable(query.ToList());
        }

        public MayD get(string May)
        {
            return _db.MayDs.SingleOrDefault(item => item.May == May);
        }

    }
}

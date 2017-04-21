using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCTB_Web.Database;
using System.Data;

namespace TCTB_Web.DAL.TCTB
{
    public class CBaoBe:CDAL
    {
        public bool Them(KT_BaoBe_BB entity)
        {
            try
            {
                if (_db.KT_BaoBe_BBs.Count() > 0)
                    entity.ID = _db.KT_BaoBe_BBs.Max(item => item.ID) + 1;
                else
                    entity.ID = 1;
                entity.CreateDate = DateTime.Now;
                _db.KT_BaoBe_BBs.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Sua(KT_BaoBe_BB entity)
        {
            try
            {
                entity.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Xoa(KT_BaoBe_BB entity)
        {
            try
            {
                _db.KT_BaoBe_BBs.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public KT_BaoBe_BB Get(int ID)
        {
            return _db.KT_BaoBe_BBs.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetDS()
        {
            return LINQToDataTable(_db.KT_BaoBe_BBs.ToList());
        }

    }
}
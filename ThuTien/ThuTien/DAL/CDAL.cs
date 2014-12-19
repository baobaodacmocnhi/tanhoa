using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;

namespace ThuTien.DAL
{
    class CDAL
    {
        protected static dbThuTienDataContext _db = new dbThuTienDataContext();

        public void BeginTransaction()
        {
            if (_db.Connection.State == System.Data.ConnectionState.Closed)
                _db.Connection.Open();
            _db.Transaction = _db.Connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _db.Transaction.Commit();
        }

        public void Rollback()
        {
            _db.Transaction.Rollback();
        }

        //public void SubmitChanges()
        //{
        //    _db.SubmitChanges();
        //}

    }
}

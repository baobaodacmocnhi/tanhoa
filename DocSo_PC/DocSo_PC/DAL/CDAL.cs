using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DocSo_PC.DAL
{
    class CDAL
    {
        public static dbDocSoTHTestDataContext _db = new dbDocSoTHTestDataContext();
        public static CConnection _cDAL = new CConnection(_db.Connection.ConnectionString);

        public void SubmitChanges()
        {
            _db.SubmitChanges();
        }

        public void Refresh()
        {
            _db = new dbDocSoTHTestDataContext();
        }



    }
}

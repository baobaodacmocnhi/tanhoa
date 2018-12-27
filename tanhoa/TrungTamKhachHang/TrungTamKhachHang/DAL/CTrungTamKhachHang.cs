using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrungTamKhachHang.LinQ;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TrungTamKhachHang.DAL
{
    class CTrungTamKhachHang:CConnection
    {
        protected static dbTrungTamKhachHangDataContext _db = new dbTrungTamKhachHangDataContext();

        public void SubmitChanges()
        {
            _db.SubmitChanges();
        }

        public void Refresh()
        {
            _db = new dbTrungTamKhachHangDataContext();
        }

    }
}

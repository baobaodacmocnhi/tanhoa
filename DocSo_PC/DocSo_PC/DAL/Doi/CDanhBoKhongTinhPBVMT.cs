using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.QuanTri;
using System.Data;

namespace DocSo_PC.DAL.Doi
{
    class CDanhBoKhongTinhPBVMT : CDAL
    {
        public bool them(DanhBoKPBVMT en)
        {
            try
            {
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.DanhBoKPBVMTs.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool xoa(DanhBoKPBVMT en)
        {
            try
            {
                _db.DanhBoKPBVMTs.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist(string DanhBo)
        {
            return _db.DanhBoKPBVMTs.Any(item => item.DanhBo == DanhBo);
        }

        public DanhBoKPBVMT get(string DanhBo)
        {
            return _db.DanhBoKPBVMTs.SingleOrDefault(item => item.DanhBo == DanhBo);
        }

        public DataTable getDS()
        {
            return LINQToDataTable(_db.DanhBoKPBVMTs.ToList());
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.QuanTri;
using System.Data;

namespace DocSo_PC.DAL.MaHoa
{
    class CDanhBoBoQua : CDAL
    {
        public bool Them(MaHoa_DanhBo_Except ctktxm)
        {
            try
            {
                ctktxm.CreateBy = CNguoiDung.MaND;
                _db.MaHoa_DanhBo_Excepts.InsertOnSubmit(ctktxm);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(MaHoa_DanhBo_Except ctktxm)
        {
            try
            {
                _db.MaHoa_DanhBo_Excepts.DeleteOnSubmit(ctktxm);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist( string DanhBo)
        {
            return _db.MaHoa_DanhBo_Excepts.Any(item =>  item.DanhBo == DanhBo);
        }

        public MaHoa_DanhBo_Except get(string DanhBo)
        {
            return _db.MaHoa_DanhBo_Excepts.SingleOrDefault(item => item.DanhBo == DanhBo);
        }

        public DataTable getDS()
        {
            return _cDAL.LINQToDataTable(_db.MaHoa_DanhBo_Excepts.ToList());
        }

    }
}

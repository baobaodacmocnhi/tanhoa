using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;

namespace ThuTien.DAL.ToTruong
{
    class CGhiChu:CDAL
    {
        public bool Them(TT_GhiChu en)
        {
            try
            {
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.TT_GhiChus.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(TT_GhiChu en)
        {
            try
            {
                en.ModifyBy = CNguoiDung.MaND;
                en.ModifyDate = DateTime.Now;
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
            return _db.TT_GhiChus.Any(item => item.DanhBo == DanhBo);
        }

        public TT_GhiChu get(string DanhBo)
        {
            return _db.TT_GhiChus.SingleOrDefault(item => item.DanhBo == DanhBo);
        }
    }
}

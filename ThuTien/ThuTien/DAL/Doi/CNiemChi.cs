using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.Doi
{
    class CNiemChi:CDAL
    {
        public bool Them(TT_NiemChi en)
        {
            try
            {
                en.CreateDate = DateTime.Now;
                en.CreateBy = CNguoiDung.MaND;
                _db.TT_NiemChis.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(TT_NiemChi en)
        {
            try
            {
                _db.TT_NiemChis.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(TT_NiemChi en)
        {
            try
            {
                en.ModifyDate = DateTime.Now;
                en.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist(int ID)
        {
            return _db.TT_NiemChis.Any(item => item.ID == ID);
        }

        public DataTable getDSNhap_Group()
        {
            var query = from item in _db.TT_NiemChis
                        group item by item.CreateDate.Value.Date into itemGroup
                        select new
                        {
                            CreateDate=itemGroup.Key,
                            TuSo = itemGroup.Min(groupItem => groupItem.ID),
                            DenSo = itemGroup.Max(groupItem => groupItem.ID),
                            SLNhap = itemGroup.Count(),
                            SLSuDung = itemGroup.Count(groupItem => groupItem.Used==true),
                            SLTon = itemGroup.Count() - itemGroup.Count(groupItem => groupItem.Used == true),
                        };
            return LINQToDataTable(query);
        }
    }
}

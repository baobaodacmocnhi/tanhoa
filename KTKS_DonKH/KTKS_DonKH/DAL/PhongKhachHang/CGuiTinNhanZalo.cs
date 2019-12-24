using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.PhongKhachHang
{
    class CGuiTinNhanZalo:CDAL
    {
        public bool them(KH_GuiTinNhanZalo en)
        {
            try
            {
                if (db.KH_GuiTinNhanZalos.Count() > 0)
                    en.ID = db.KH_GuiTinNhanZalos.Max(item => item.ID) + 1;
                else
                    en.ID = 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.KH_GuiTinNhanZalos.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public DataTable getDS()
        {
            return LINQToDataTable(db.KH_GuiTinNhanZalos.OrderByDescending(item => item.CreateDate).ToList());
        }

        dbTrungTamKhachHangDataContext dbTTKH = new dbTrungTamKhachHangDataContext();
        public DataTable getDS_Zalo()
        {
            var result = dbTTKH.Zalos.GroupBy(test => test.IDZalo)
                   .Select(grp => grp.First())
                   .ToList();
            return LINQToDataTable(result);
        }

        public void excute(string sql)
        {
            dbTTKH.ExecuteCommand(sql);
        }
    }
}

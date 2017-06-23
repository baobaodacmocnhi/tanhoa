using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.DonTu
{
    class CNhomDon:CDAL
    {
        public bool Them(NhomDon entity)
        {
            try
            {
                if (db.NhomDons.Count() > 0)
                {
                    entity.ID = db.NhomDons.Max(item => item.ID) + 1;
                    if (entity.DieuChinh == true)
                        entity.STT = db.NhomDons.Where(item => item.DieuChinh == true).Max(item => item.STT) + 1;
                    else
                        if (entity.KhieuNai == true)
                            entity.STT = db.NhomDons.Where(item => item.KhieuNai == true).Max(item => item.STT) + 1;
                        else
                            if (entity.DHN == true)
                                entity.STT = db.NhomDons.Where(item => item.DHN == true).Max(item => item.STT) + 1;
                }
                else
                {
                    entity.ID = 1;
                    entity.STT = 1;
                }
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.NhomDons.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                Refresh();
                return false;
            }
        }

        public bool Sua(NhomDon entity)
        {
            try
            {
                entity.ModifyDate = DateTime.Now;
                entity.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                Refresh();
                return false;
            }
        }

        public bool Xoa(NhomDon entity)
        {
            try
            {
                db.NhomDons.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                Refresh();
                return false;
            }
        }

        public DataTable GetDS(string Loai)
        {
            switch (Loai)
            {
                case "DieuChinh":
                    return LINQToDataTable(db.NhomDons.Where(item => item.DieuChinh == true).ToList());
                case "KhieuNai":
                    return LINQToDataTable(db.NhomDons.Where(item => item.KhieuNai == true).ToList());
                case "DHN":
                    return LINQToDataTable(db.NhomDons.Where(item => item.DHN == true).ToList());
                default:
                    return null;
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.DonTu
{
    class CDonTu:CDAL
    {
        public bool Them(LinQ.DonTu entity)
        {
            try
            {
                if (db.DonTus.Any(item => item.NamThang == DateTime.Now.ToString("yyMM")) == true)
                {
                    entity.NamThang = DateTime.Now.ToString("yyMM");
                    entity.STT = (int.Parse(db.DonTus.Where(item => item.NamThang == DateTime.Now.ToString("yyMM")).Max(item => item.STT)) + 1).ToString("000");
                }
                else
                {
                    entity.NamThang = DateTime.Now.ToString("yyMM");
                    entity.STT = 1.ToString("000");
                }
                entity.CreateBy = CTaiKhoan.MaUser;
                entity.CreateDate = DateTime.Now;
                db.DonTus.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Sua(LinQ.DonTu entity)
        {
            try
            {
                entity.ModifyBy = CTaiKhoan.MaUser;
                entity.ModifyDate = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Xoa(LinQ.DonTu entity)
        {
            try
            {
                db.DonTus.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable GetDS()
        {
           return  LINQToDataTable(db.DonTus.ToList());
        }

    }
}

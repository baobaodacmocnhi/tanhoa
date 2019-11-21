﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.DieuChinhBienDong
{
    class CHoNgheo : CDAL
    {
        public bool Them(HoNgheo en)
        {
            try
            {
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.HoNgheos.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(HoNgheo en)
        {
            try
            {
                en.ModifyBy = CTaiKhoan.MaUser;
                en.ModifyDate = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(HoNgheo en)
        {
            try
            {
                db.HoNgheos.DeleteOnSubmit(en);
                db.SubmitChanges();
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
            return db.HoNgheos.Any(item => item.DanhBo == DanhBo);
        }

        public HoNgheo get(string DanhBo)
        {
            return db.HoNgheos.SingleOrDefault(item => item.DanhBo == DanhBo);
        }

        public DataTable getDS()
        {
            return LINQToDataTable(db.HoNgheos.OrderBy(item=>item.DanhBo).ToList());
        }

        public DataTable getDS(string DanhBo)
        {
            return LINQToDataTable(db.HoNgheos.Where(item => item.DanhBo==DanhBo).ToList());
        }

        public DataTable getDS_To(int MaTo)
        {
            return LINQToDataTable(db.HoNgheos.Where(item => db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).MaTo == MaTo).OrderBy(item => item.DanhBo));
        }

        public DataTable getDS_Dot(int Dot)
        {
            return LINQToDataTable(db.HoNgheos.Where(item => item.Dot == Dot).OrderBy(item => item.DanhBo));
        }

        public DataTable getDS(int MaTo, int Dot)
        {
            return LINQToDataTable(db.HoNgheos.Where(item => db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).MaTo == MaTo && item.Dot == Dot).OrderBy(item => item.DanhBo));
        }
    }
}
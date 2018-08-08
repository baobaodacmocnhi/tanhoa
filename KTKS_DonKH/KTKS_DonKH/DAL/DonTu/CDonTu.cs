﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.DonTu
{
    class CDonTu : CDAL
    {
        public bool Them(LinQ.DonTu entity)
        {
            try
            {
                if (db.DonTus.Any(item => item.NamThang == DateTime.Now.ToString("yyMM")) == true)
                {
                    entity.STT = (int.Parse(db.DonTus.Where(item => item.NamThang == DateTime.Now.ToString("yyMM")).Max(item => item.STT)) + 1).ToString("000");
                }
                else
                {
                    entity.STT = 1.ToString("000");
                }
                entity.NamThang = DateTime.Now.ToString("yyMM");
                entity.MaDon = int.Parse(entity.NamThang + entity.STT);
                entity.CreateBy = CTaiKhoan.MaUser;
                entity.CreateDate = DateTime.Now;
                db.DonTus.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
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
            catch (Exception ex)
            {
                Refresh();
                throw ex;
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
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist(int MaDon)
        {
            return db.DonTus.Any(item => item.MaDon == MaDon);
        }
  
        public LinQ.DonTu get(int MaDon)
        {
            return db.DonTus.SingleOrDefault(item => item.MaDon == MaDon);
        }

        public DataTable getDS(int MaDon)
        {
            var query = from item in db.DonTus
                        where item.MaDon == MaDon
                        select new
                        {
                            item.MaDon,
                            item.SoCongVan,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            NoiDung = item.Name_NhomDon,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS(int FromMaDon, int ToMaDon)
        {
            var query = from item in db.DonTus
                        where item.MaDon >= FromMaDon && item.MaDon <= ToMaDon
                        select new
                        {
                            item.MaDon,
                            item.SoCongVan,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            NoiDung = item.Name_NhomDon,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSByDanhBo(string DanhBo)
        {
            var query = from item in db.DonTus
                        where item.DanhBo == DanhBo
                        select new
                        {
                            item.MaDon,
                            item.SoCongVan,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            NoiDung = item.Name_NhomDon,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSBySoCongVan(string SoCongVan)
        {
            var query = from item in db.DonTus
                        where item.SoCongVan == SoCongVan
                        select new
                        {
                            item.MaDon,
                            item.SoCongVan,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            NoiDung = item.Name_NhomDon,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.DonTus
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            item.MaDon,
                            item.SoCongVan,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            NoiDung = item.Name_NhomDon,
                        };
            return LINQToDataTable(query);
        }

        // chi tiết

        public int getMaxID_ChiTiet()
        {
            if (db.DonTu_ChiTiets.Count() == 0)
                return 0;
            else
                return db.DonTu_ChiTiets.Max(item => item.ID);
        }

        public bool checkExist_ChiTiet(string DanhBo, DateTime CreateDate)
        {
            return db.DonTu_ChiTiets.Any(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public DonTu_ChiTiet get_ChiTiet(int MaDon, int STT)
        {
            return db.DonTu_ChiTiets.SingleOrDefault(item => item.MaDon == MaDon && item.STT == STT);
        }

        // lịch sử

        public bool Them(DonTu_LichSu entity)
        {
            try
            {
                if (db.DonTu_LichSus.Count() == 0)
                    entity.ID = 1;
                else
                    entity.ID = db.DonTu_LichSus.Max(item => item.ID) + 1;
                entity.CreateBy = CTaiKhoan.MaUser;
                entity.CreateDate = DateTime.Now;
                db.DonTu_LichSus.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(DonTu_LichSu entity)
        {
            try
            {
                db.DonTu_LichSus.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public DonTu_LichSu get_LichSu(int ID)
        {
            return db.DonTu_LichSus.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS_LichSu(int MaDon, int STT)
        {
            var query = from item in db.DonTu_LichSus
                        where item.MaDon == MaDon && item.STT == STT
                        select new
                        {
                            item.ID,
                            item.NgayChuyen,
                            item.NoiChuyen,
                            item.NoiNhan,
                            item.KTXM,
                            item.NoiDung,
                            CreateBy=db.Users.SingleOrDefault(itemU=>itemU.MaU==item.CreateBy).HoTen
                        };
            return LINQToDataTable(query);
        }
    }
}

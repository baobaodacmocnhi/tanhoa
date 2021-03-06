﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeToan.LinQ;
using KeToan.DAL.QuanTri;
using System.Data;

namespace KeToan.DAL.GiaiTrachTienNuoc
{
    class CGiaiTrachTienNuoc_Nhap : CDAL
    {
        public bool Them(GiaiTrachTienNuoc_Nhap en)
        {
            try
            {
                if (_db.GiaiTrachTienNuoc_Nhaps.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = _db.GiaiTrachTienNuoc_Nhaps.Max(item => item.ID) + 1;
                en.CreateDate = DateTime.Now;
                en.CreateBy = CUser.MaUser;
                _db.GiaiTrachTienNuoc_Nhaps.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(GiaiTrachTienNuoc_Nhap en)
        {
            try
            {
                en.ModifyDate = DateTime.Now;
                en.ModifyBy = CUser.MaUser;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        //public bool Xoa(GiaiTrachTienNuoc_Nhap en)
        //{
        //    try
        //    {
        //        _db.GiaiTrachTienNuoc_Nhaps.DeleteOnSubmit(en);
        //        _db.SubmitChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Refresh();
        //        throw ex;
        //    }
        //}

        public bool Xoa(string ID)
        {
            return ExecuteNonQuery("delete GiaiTrachTienNuoc_Nhap where ID=" + ID);
        }

        public bool checkExists(string SoPhieuThu, DateTime NgayPhieuThu, string DanhBo)
        {
            return _db.GiaiTrachTienNuoc_Nhaps.Any(item => item.SoPhieuThu == SoPhieuThu && item.NgayPhieuThu.Value.Date == NgayPhieuThu.Date && item.DanhBo == DanhBo);
        }

        public GiaiTrachTienNuoc_Nhap get(string SoPhieuThu, DateTime NgayPhieuThu, string DanhBo)
        {
            if (_db.GiaiTrachTienNuoc_Nhaps.Count(item => item.SoPhieuThu == SoPhieuThu && item.NgayPhieuThu.Value.Date == NgayPhieuThu.Date) > 1)
                return _db.GiaiTrachTienNuoc_Nhaps.SingleOrDefault(item => item.SoPhieuThu == SoPhieuThu && item.NgayPhieuThu.Value.Date == NgayPhieuThu.Date && item.DanhBo == DanhBo);
            else
                return _db.GiaiTrachTienNuoc_Nhaps.SingleOrDefault(item => item.SoPhieuThu == SoPhieuThu && item.NgayPhieuThu.Value.Date == NgayPhieuThu.Date);
        }

        public DataSet getDS_Ton()
        {
            DataSet ds = new DataSet();

            var query = from item in _db.GiaiTrachTienNuoc_Nhaps
                        where _db.GiaiTrachTienNuoc_Xuats.Any(itemA => itemA.IDNhap == item.ID) == false || (item.SoTien - _db.GiaiTrachTienNuoc_Xuats.Where(itemA => itemA.IDNhap == item.ID).Sum(itemA => itemA.SoTienPhieuThu)) != 0
                        orderby item.ID ascending
                        select new
                        {
                            item.ID,
                            item.SoPhieuThu,
                            item.NgayPhieuThu,
                            item.DanhBo,
                            item.SoTien,
                            SoTienTon = _db.GiaiTrachTienNuoc_Xuats.Any(itemA => itemA.IDNhap == item.ID) == false ? 0 : (item.SoTien - _db.GiaiTrachTienNuoc_Xuats.Where(itemA => itemA.IDNhap == item.ID).Sum(itemA => itemA.SoTienPhieuThu)),
                            item.NganHang,
                            TinhTrang = (item.SoTien - _db.GiaiTrachTienNuoc_Xuats.Where(itemA => itemA.IDNhap == item.ID).Sum(itemA => itemA.SoTienPhieuThu)) == 0 ? "Hết" : "Tồn",
                        };
            DataTable dt = new DataTable();
            dt = LINQToDataTable(query);
            dt.TableName = "PhieuThu";
            ds.Tables.Add(dt);

            var queryCT = from itemXuat in _db.GiaiTrachTienNuoc_Xuats
                          join itemNhap in _db.GiaiTrachTienNuoc_Nhaps on itemXuat.IDNhap equals itemNhap.ID
                          where itemXuat.IDNhap == null || (itemNhap.SoTien - _db.GiaiTrachTienNuoc_Xuats.Where(itemA => itemA.IDNhap == itemNhap.ID).Sum(itemA => itemA.SoTienPhieuThu)) != 0
                          select new
                          {
                              itemXuat.IDNhap,
                              itemXuat.DanhBo,
                              itemXuat.Ky,
                              SoTien = itemXuat.TongCong,
                              itemXuat.NgayGiaiTrach,
                          };
            DataTable dtCT = new DataTable();
            dtCT = LINQToDataTable(queryCT);
            dtCT.TableName = "ChiTiet";
            ds.Tables.Add(dtCT);

            if (dt.Rows.Count > 0 && dtCT.Rows.Count > 0)
                ds.Relations.Add("Chi Tiết", ds.Tables["PhieuThu"].Columns["ID"], ds.Tables["ChiTiet"].Columns["IDNhap"]);

            return ds;
        }

        public DataSet getDS(string NoiDungTimKiem)
        {
            DataSet ds = new DataSet();

            var query = from item in _db.GiaiTrachTienNuoc_Nhaps
                        where item.DanhBo.Contains(NoiDungTimKiem) || item.HoTen.Contains(NoiDungTimKiem)
                        orderby item.ID ascending
                        select new
                        {
                            item.ID,
                            item.SoPhieuThu,
                            item.NgayPhieuThu,
                            item.DanhBo,
                            item.SoTien,
                            SoTienTon = _db.GiaiTrachTienNuoc_Xuats.Any(itemA => itemA.IDNhap == item.ID) == false ? 0 : (item.SoTien - _db.GiaiTrachTienNuoc_Xuats.Where(itemA => itemA.IDNhap == item.ID).Sum(itemA => itemA.SoTienPhieuThu)),
                            item.NganHang,
                            TinhTrang = (item.SoTien - _db.GiaiTrachTienNuoc_Xuats.Where(itemA => itemA.IDNhap == item.ID).Sum(itemA => itemA.SoTienPhieuThu)) == 0 ? "Hết" : "Tồn",
                        };
            DataTable dt = new DataTable();
            dt = LINQToDataTable(query);
            dt.TableName = "PhieuThu";
            ds.Tables.Add(dt);

            var queryCT = from itemXuat in _db.GiaiTrachTienNuoc_Xuats
                          join itemNhap in _db.GiaiTrachTienNuoc_Nhaps on itemXuat.IDNhap equals itemNhap.ID
                          where itemNhap.DanhBo.Contains(NoiDungTimKiem) || itemNhap.HoTen.Contains(NoiDungTimKiem)
                          select new
                          {
                              itemXuat.IDNhap,
                              itemXuat.DanhBo,
                              itemXuat.Ky,
                              itemXuat.GiaBan,
                              itemXuat.ThueGTGT,
                              itemXuat.PhiBVMT,
                              itemXuat.TongCong,
                              itemXuat.NgayGiaiTrach,
                              itemXuat.SoTienPhieuThu,
                          };
            DataTable dtCT = new DataTable();
            dtCT = LINQToDataTable(queryCT);
            dtCT.TableName = "ChiTiet";
            ds.Tables.Add(dtCT);

            if (dt.Rows.Count > 0 && dtCT.Rows.Count > 0)
                ds.Relations.Add("Chi Tiết", ds.Tables["PhieuThu"].Columns["ID"], ds.Tables["ChiTiet"].Columns["IDNhap"]);

            return ds;
        }

        public DataSet getDS(DateTime FromNgayPhieuThu, DateTime ToNgayPhieuThu)
        {
            DataSet ds = new DataSet();

            var query = from item in _db.GiaiTrachTienNuoc_Nhaps
                        where item.NgayPhieuThu.Value.Date >= FromNgayPhieuThu.Date && item.NgayPhieuThu.Value.Date <= ToNgayPhieuThu.Date
                        orderby item.ID ascending
                        select new
                        {
                            item.ID,
                            item.SoPhieuThu,
                            item.NgayPhieuThu,
                            item.DanhBo,
                            item.SoTien,
                            SoTienTon = _db.GiaiTrachTienNuoc_Xuats.Any(itemA => itemA.IDNhap == item.ID) == false ? 0 : (item.SoTien - _db.GiaiTrachTienNuoc_Xuats.Where(itemA => itemA.IDNhap == item.ID).Sum(itemA => itemA.SoTienPhieuThu)),
                            item.NganHang,
                            TinhTrang = (item.SoTien - _db.GiaiTrachTienNuoc_Xuats.Where(itemA => itemA.IDNhap == item.ID).Sum(itemA => itemA.SoTienPhieuThu)) == 0 ? "Hết" : "Tồn",
                        };
            DataTable dt = new DataTable();
            dt = LINQToDataTable(query);
            dt.TableName = "PhieuThu";
            ds.Tables.Add(dt);

            var queryCT = from itemXuat in _db.GiaiTrachTienNuoc_Xuats
                          join itemNhap in _db.GiaiTrachTienNuoc_Nhaps on itemXuat.IDNhap equals itemNhap.ID
                          where itemNhap.NgayPhieuThu.Value.Date >= FromNgayPhieuThu.Date && itemNhap.NgayPhieuThu.Value.Date <= ToNgayPhieuThu.Date
                          select new
                          {
                              itemXuat.IDNhap,
                              itemXuat.DanhBo,
                              itemXuat.Ky,
                              itemXuat.GiaBan,
                              itemXuat.ThueGTGT,
                              itemXuat.PhiBVMT,
                              itemXuat.TongCong,
                              itemXuat.NgayGiaiTrach,
                              itemXuat.SoTienPhieuThu,
                          };
            DataTable dtCT = new DataTable();
            dtCT = LINQToDataTable(queryCT);
            dtCT.TableName = "ChiTiet";
            ds.Tables.Add(dtCT);

            if (dt.Rows.Count > 0 && dtCT.Rows.Count > 0)
                ds.Relations.Add("Chi Tiết", ds.Tables["PhieuThu"].Columns["ID"], ds.Tables["ChiTiet"].Columns["IDNhap"]);

            return ds;
        }
    }
}

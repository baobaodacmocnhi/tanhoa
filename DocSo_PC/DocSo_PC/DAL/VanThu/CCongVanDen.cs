﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.QuanTri;

namespace DocSo_PC.DAL.VanThu
{
    class CCongVanDen : CDAL
    {
        public bool Them(CongVanDen en)
        {
            try
            {
                if (_db.CongVanDens.Count() > 0)
                    en.ID = _db.CongVanDens.Max(item => item.ID) + 1;
                else
                    en.ID = 1;
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.CongVanDens.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(CongVanDen en)
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
                throw ex;
            }
        }

        public bool Xoa(CongVanDen en)
        {
            try
            {
                _db.CongVanDens.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExists(string TableName, int IDCT)
        {
            return _db.CongVanDens.Any(item => item.TableName == TableName && item.IDCT == IDCT);
        }

        public CongVanDen get(int ID)
        {
            return _db.CongVanDens.SingleOrDefault(item => item.ID == ID);
        }

        public CongVanDen get(string TableName, int IDCT)
        {
            return _db.CongVanDens.SingleOrDefault(item => item.TableName == TableName && item.IDCT == IDCT);
        }

        public DataTable getDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {

            return _cDAL.ExecuteQuery_DataTable("select *,'To'=(select TenTo from [To] where TuMay<=SUBSTRING(MLT,3,2) and DenMay>=SUBSTRING(MLT,3,2))  from CongVanDen where cast(createdate as date)>='" + ToCreateDate.ToString("yyyyMMdd") + "' and cast(createdate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'");
        }

        public DataTable getDS(string DanhBo)
        {
            return _cDAL.LINQToDataTable(_db.CongVanDens.Where(item => item.DanhBo == DanhBo).OrderByDescending(item => item.CreateDate));
        }

    }
}

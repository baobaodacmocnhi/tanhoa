﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.Doi
{
    class CCuaHangThuHo:CDAL
    {
        public bool Them(TT_DichVuThu_CuaHang entity)
        {
            try
            {
                if(_db.TT_DichVuThu_CuaHangs.Count()>0)
                    entity.ID=_db.TT_DichVuThu_CuaHangs.Max(item=>item.ID)+1;
                else
                    entity.ID=1;
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CNguoiDung.MaND;
                _db.TT_DichVuThu_CuaHangs.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(TT_DichVuThu_CuaHang entity)
        {
            try
            {
                _db.TT_DichVuThu_CuaHangs.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(TT_DichVuThu_CuaHang entity)
        {
            try
            {
                entity.ModifyDate = DateTime.Now;
                entity.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExists_DiaChi(string DiaChi)
        {
            return _db.TT_DichVuThu_CuaHangs.Any(item => item.DiaChi == DiaChi);
        }

        public bool checkExists_DanhBo(string DanhBo)
        {
            return _db.TT_DichVuThu_CuaHangs.Any(item => item.DanhBo == DanhBo);
        }

        public TT_DichVuThu_CuaHang get(int ID)
        {
            return _db.TT_DichVuThu_CuaHangs.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS()
        {
            return LINQToDataTable(_db.TT_DichVuThu_CuaHangs.ToList());
        }

    }
}

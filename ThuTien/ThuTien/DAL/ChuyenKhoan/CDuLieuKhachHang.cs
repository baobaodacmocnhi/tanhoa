﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.ChuyenKhoan
{
    class CDuLieuKhachHang:CDAL
    {
        public bool Them(TT_DuLieuKhachHang dlkh)
        {
            try
            {
                dlkh.CreateDate = DateTime.Now;
                dlkh.CreateBy = CNguoiDung.MaND;
                _db.TT_DuLieuKhachHangs.InsertOnSubmit(dlkh);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(TT_DuLieuKhachHang dlkh)
        {
            try
            {
                dlkh.ModifyDate = DateTime.Now;
                dlkh.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(TT_DuLieuKhachHang dlkh)
        {
            try
            {
                _db.TT_DuLieuKhachHangs.DeleteOnSubmit(dlkh);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public TT_DuLieuKhachHang GetByNamKyDanhBo(int nam, int ky,string DanhBo)
        {
            return _db.TT_DuLieuKhachHangs.SingleOrDefault(item => item.Nam == nam && item.Ky == ky && item.DanhBo == DanhBo);
        }

        public bool CheckExistByNamKyDanhBo(int nam, int ky, string DanhBo)
        {
            return _db.TT_DuLieuKhachHangs.Any(item => item.Nam == nam && item.Ky == ky && item.DanhBo == DanhBo);
        }

        public DataTable GetDSDangNgan(int nam, int ky)
        {
            var query = from itemDLKH in _db.TT_DuLieuKhachHangs
                        join itemHD in _db.HOADONs on itemDLKH.DanhBo equals itemHD.DANHBA
                        where itemDLKH.Nam == nam && itemDLKH.Ky == ky && itemHD.NAM == nam && itemHD.KY == ky && itemHD.MaNV_DangNgan != null
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            itemHD.KY,
                            itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSTon(int nam, int ky)
        {
            var query = from itemDLKH in _db.TT_DuLieuKhachHangs
                        join itemHD in _db.HOADONs on itemDLKH.DanhBo equals itemHD.DANHBA
                        where itemDLKH.Nam == nam && itemDLKH.Ky == ky && itemHD.NAM == nam && itemHD.KY == ky && itemHD.MaNV_DangNgan == null
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            itemHD.KY,
                            itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                        };
            return LINQToDataTable(query);
        }

        #region DuLieuKhachHang_SoHoaDon

        public bool Them2(TT_DuLieuKhachHang_SoHoaDon dlkh)
        {
            try
            {
                dlkh.CreateDate = DateTime.Now;
                dlkh.CreateBy = CNguoiDung.MaND;
                _db.TT_DuLieuKhachHang_SoHoaDons.InsertOnSubmit(dlkh);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua2(TT_DuLieuKhachHang_SoHoaDon dlkh)
        {
            try
            {
                dlkh.ModifyDate = DateTime.Now;
                dlkh.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa2(TT_DuLieuKhachHang_SoHoaDon dlkh)
        {
            try
            {
                _db.TT_DuLieuKhachHang_SoHoaDons.DeleteOnSubmit(dlkh);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public TT_DuLieuKhachHang_SoHoaDon GetBySoHoaDon2(string SoHoaDon)
        {
            return _db.TT_DuLieuKhachHang_SoHoaDons.SingleOrDefault(item => item.SoHoaDon == SoHoaDon);
        }

        public DataTable GetDS2(DateTime CreateDate)
        {
            var query = from itemDLKH in _db.TT_DuLieuKhachHang_SoHoaDons
                        join itemHD in _db.HOADONs on itemDLKH.SoHoaDon equals itemHD.SOHOADON
                        where itemDLKH.CreateDate.Value.Date == CreateDate.Date
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            itemHD.KY,
                            itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS2(DateTime CreateDate1, DateTime CreateDate2)
        {
            var query = from itemDLKH in _db.TT_DuLieuKhachHang_SoHoaDons
                        join itemHD in _db.HOADONs on itemDLKH.SoHoaDon equals itemHD.SOHOADON
                        where itemDLKH.CreateDate.Value.Date >= CreateDate1.Date && itemDLKH.CreateDate.Value.Date <= CreateDate2.Date
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            itemHD.KY,
                            itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                        };
            return LINQToDataTable(query);
        }
        #endregion
    }
}

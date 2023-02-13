using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;
using System.Globalization;

namespace ThuTien.DAL.ChuyenKhoan
{
    class CDuLieuKhachHang : CDAL
    {
        public bool Them(TT_DuLieuKhachHang_DanhBo dlkh)
        {
            try
            {
                dlkh.CreateDate = DateTime.Now;
                dlkh.CreateBy = CNguoiDung.MaND;
                _db.TT_DuLieuKhachHang_DanhBos.InsertOnSubmit(dlkh);
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

        public bool Them(string DanhBo)
        {
            try
            {
                string sql = "insert into TT_DuLieuKhachHang(DanhBo,CreateDate,CreateBy) values ('" + DanhBo + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "'," + CNguoiDung.MaND + ")";

                LinQ_ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(TT_DuLieuKhachHang_DanhBo dlkh)
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

        public bool Xoa(TT_DuLieuKhachHang_DanhBo dlkh)
        {
            try
            {
                _db.TT_DuLieuKhachHang_DanhBos.DeleteOnSubmit(dlkh);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public TT_DuLieuKhachHang_DanhBo GetByDanhBo(string DanhBo)
        {
            return _db.TT_DuLieuKhachHang_DanhBos.SingleOrDefault(item => item.DanhBo == DanhBo);
        }

        public bool CheckExistDanhBo(string DanhBo)
        {
            return _db.TT_DuLieuKhachHang_DanhBos.Any(item => item.DanhBo == DanhBo);
        }

        public List<TT_DuLieuKhachHang_DanhBo> GetDS()
        {
            return _db.TT_DuLieuKhachHang_DanhBos.ToList();
        }

        public DataTable GetDSDanhBoTon(int Dot)
        {
            //string sql = "select dlkhDB.DanhBo,SoTaiKhoan,SoHoaDon,Ky,TIEUTHU,GIABAN,ThueGTGT,PhiBVMT,TONGCONG from TT_DuLieuKhachHang_DanhBo dlkhDB"
            //         + " left  join"
            //         + " (select DANHBA,a.SoHoaDon,(convert(varchar(2),KY)+'/'+convert(varchar(4),NAM)) as Ky,TIEUTHU,GIABAN,THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG"
            //         + " from TT_DuLieuKhachHang_SoHoaDon a, HOADON b where a.SoHoaDon=b.SOHOADON and NAM=" + Nam + " and KY=" + Ky + ") dlkhHD on dlkhHD.DANHBA=dlkhDB.DanhBo";
            //string sql = "select dlkhDB.DanhBo,SoTaiKhoan,dlkhHD.* from TT_DuLieuKhachHang_DanhBo dlkhDB"
            //         + " left  join"
            //         + " (select DANHBA,SOHOADON,NAM,KY,DOT,TIEUTHU,GIABAN,THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG"
            //         + " from HOADON where NAM=" + Nam + " and KY=" + Ky + " and DOT="+Dot+") dlkhHD on dlkhHD.DANHBA=dlkhDB.DanhBo";
            string sql = "select dlkhDB.DanhBo,dlkhDB.HoTen,SoTaiKhoan,MaHD=hd.ID_HOADON,SOHOADON,SOPHATHANH,NAM,KY,DOT,TIEUTHU,GIABAN,THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,"
                        + "nd.HoTen as HanhThu,tto.TenTo as 'To',GB as GiaBieu,MALOTRINH as MLT"
                        + " from TT_DuLieuKhachHang_DanhBo dlkhDB,HOADON hd"
                        + " left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " left join TT_To tto on nd.MaTo=tto.MaTo"
                        + " where dlkhDB.DanhBo=hd.DANHBA and NGAYGIAITRACH is null and DOT=" + Dot + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                        + " order by MALOTRINH asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSDanhBoTon(int TuDot, int DenDot)
        {
            //string sql = "select dlkhDB.DanhBo,SoTaiKhoan,SoHoaDon,Ky,TIEUTHU,GIABAN,ThueGTGT,PhiBVMT,TONGCONG from TT_DuLieuKhachHang_DanhBo dlkhDB"
            //         + " left  join"
            //         + " (select DANHBA,a.SoHoaDon,(convert(varchar(2),KY)+'/'+convert(varchar(4),NAM)) as Ky,TIEUTHU,GIABAN,THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG"
            //         + " from TT_DuLieuKhachHang_SoHoaDon a, HOADON b where a.SoHoaDon=b.SOHOADON and NAM=" + Nam + " and KY=" + Ky + ") dlkhHD on dlkhHD.DANHBA=dlkhDB.DanhBo";
            //string sql = "select dlkhDB.DanhBo,SoTaiKhoan,dlkhHD.* from TT_DuLieuKhachHang_DanhBo dlkhDB"
            //         + " left  join"
            //         + " (select DANHBA,SOHOADON,NAM,KY,DOT,TIEUTHU,GIABAN,THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG"
            //         + " from HOADON where NAM=" + Nam + " and KY=" + Ky + " and DOT="+Dot+") dlkhHD on dlkhHD.DANHBA=dlkhDB.DanhBo";
            string sql = "select dlkhDB.DanhBo,dlkhDB.HoTen,SoTaiKhoan,MaHD=hd.ID_HOADON,SOHOADON,SOPHATHANH,NAM,KY,DOT,TIEUTHU,GIABAN,THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,"
                        + "nd.HoTen as HanhThu,tto.TenTo as 'To',GB as GiaBieu,MALOTRINH as MLT"
                        + " from TT_DuLieuKhachHang_DanhBo dlkhDB,HOADON hd"
                        + " left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " left join TT_To tto on nd.MaTo=tto.MaTo"
                        + " where dlkhDB.DanhBo=hd.DANHBA and NGAYGIAITRACH is null and DOT>=" + TuDot + " and DOT<=" + DenDot + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                        + " order by MALOTRINH asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSDanhBoTon()
        {
            string sql = "select dlkhDB.DanhBo,dlkhDB.HoTen,SoTaiKhoan,MaHD=hd.ID_HOADON,SOHOADON,SOPHATHANH,NAM,KY,DOT,TIEUTHU,GIABAN,THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,"
                        + "nd.HoTen as HanhThu,tto.TenTo as 'To',GB as GiaBieu,MALOTRINH as MLT"
                        + " from TT_DuLieuKhachHang_DanhBo dlkhDB,HOADON hd"
                        + " left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " left join TT_To tto on nd.MaTo=tto.MaTo"
                        + " where dlkhDB.DanhBo=hd.DANHBA and NGAYGIAITRACH is null and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                        + " order by MALOTRINH asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTon(int Nam, int Ky)
        {
            var query = from itemDLKH in _db.TT_DuLieuKhachHang_DanhBos
                        join itemHD in _db.HOADONs on itemDLKH.DanhBo equals itemHD.DANHBA
                        where itemHD.NGAYGIAITRACH == null && itemHD.NAM == Nam && itemHD.KY == Ky
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

        public bool CheckExist2(string SoHoaDon)
        {
            if (_db.HOADONs.Any(itemHD => itemHD.SOHOADON == SoHoaDon))
                return _db.TT_DuLieuKhachHang_SoHoaDons.Any(item => item.MaHD == _db.HOADONs.SingleOrDefault(itemHD => itemHD.SOHOADON == SoHoaDon).ID_HOADON);
            else
                return false;
        }

        public TT_DuLieuKhachHang_SoHoaDon GetBySoHoaDon2(string SoHoaDon)
        {
            return _db.TT_DuLieuKhachHang_SoHoaDons.SingleOrDefault(item => item.SoHoaDon == SoHoaDon);
        }

        public DataTable GetDS2(DateTime CreateDate)
        {
            var query = from itemDLKH in _db.TT_DuLieuKhachHang_SoHoaDons
                        join itemHD in _db.HOADONs on itemDLKH.MaHD equals itemHD.ID_HOADON
                        where itemDLKH.CreateDate.Value.Date == CreateDate.Date
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            MLT = itemHD.MALOTRINH,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
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
                        join itemHD in _db.HOADONs on itemDLKH.MaHD equals itemHD.ID_HOADON
                        join itemDLKHDB in _db.TT_DuLieuKhachHang_DanhBos on itemHD.DANHBA equals itemDLKHDB.DanhBo into tableDLHKDB
                        from itemtableDLHKDB in tableDLHKDB.DefaultIfEmpty()
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemDLKH.CreateDate.Value.Date >= CreateDate1.Date && itemDLKH.CreateDate.Value.Date <= CreateDate2.Date
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            itemHD.SOPHATHANH,
                            MLT = itemHD.MALOTRINH,
                            itemHD.KY,
                            itemHD.NAM,
                            itemHD.DOT,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            GiaBieu = itemHD.GB,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            itemtableDLHKDB.SoTaiKhoan,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetTongQuet(int MaTo, DateTime CreateDate1, DateTime CreateDate2)
        {
            var query = from itemDLKH in _db.TT_DuLieuKhachHang_SoHoaDons
                        join itemHD in _db.HOADONs on itemDLKH.MaHD equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        && itemDLKH.CreateDate.Value.Date >= CreateDate1.Date && itemDLKH.CreateDate.Value.Date <= CreateDate2.Date
                        group itemHD by itemDLKH.CreateDate.Value.Date into itemGroup
                        select new
                        {
                            Ngay = itemGroup.Key.Day + "/" + itemGroup.Key.Month,
                            TongHD = itemGroup.Count(),
                            TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetTongQuetDangNgan(int MaTo, DateTime CreateDate1, DateTime CreateDate2)
        {
            var query = from itemDLKH in _db.TT_DuLieuKhachHang_SoHoaDons
                        join itemHD in _db.HOADONs on itemDLKH.MaHD equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        && itemDLKH.CreateDate.Value.Date >= CreateDate1.Date && itemDLKH.CreateDate.Value.Date <= CreateDate2.Date && itemHD.NGAYGIAITRACH != null
                        group itemHD by itemDLKH.CreateDate.Value.Date into itemGroup
                        select new
                        {
                            Ngay = itemGroup.Key.Day + "/" + itemGroup.Key.Month,
                            TongHD = itemGroup.Count(),
                            TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetTongQuetTon(int MaTo, DateTime CreateDate1, DateTime CreateDate2)
        {
            var query = from itemDLKH in _db.TT_DuLieuKhachHang_SoHoaDons
                        join itemHD in _db.HOADONs on itemDLKH.MaHD equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        && itemDLKH.CreateDate.Value.Date >= CreateDate1.Date && itemDLKH.CreateDate.Value.Date <= CreateDate2.Date && itemHD.NGAYGIAITRACH == null
                        group itemHD by itemDLKH.CreateDate.Value.Date into itemGroup
                        select new
                        {
                            Ngay = itemGroup.Key.Day + "/" + itemGroup.Key.Month,
                            TongHD = itemGroup.Count(),
                            TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                        };
            return LINQToDataTable(query);
        }

        #endregion
    }
}

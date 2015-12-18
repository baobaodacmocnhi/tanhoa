using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.Quay
{
    class CLenhHuy:CDAL
    {
        public bool Them(TT_LenhHuy lenhhuy)
        {
            try
            {
                lenhhuy.CreateDate = DateTime.Now;
                lenhhuy.CreateBy = CNguoiDung.MaND;
                _db.TT_LenhHuys.InsertOnSubmit(lenhhuy);
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

        public bool Xoa(TT_LenhHuy lenhhuy)
        {
            try
            {
                _db.TT_LenhHuys.DeleteOnSubmit(lenhhuy);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(TT_LenhHuy lenhhuy)
        {
            try
            {
                lenhhuy.ModifyDate = DateTime.Now;
                lenhhuy.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(string SoHoaDon)
        {
            try
            {
                string sql = "";
                sql = "delete TT_LenhHuy where SoHoaDon='" + SoHoaDon + "'";
                return ExecuteNonQuery_Transaction(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(string SoHoaDon)
        {
            return _db.TT_LenhHuys.Any(item => item.SoHoaDon == SoHoaDon);
        }

        public bool CheckExist(string SoHoaDon,int Nam,int Ky)
        {
            return _db.TT_LenhHuys.Any(item => item.SoHoaDon == SoHoaDon && item.CreateDate.Value.Year == Nam && item.CreateDate.Value.Month == Ky);
        }

        public TT_LenhHuy GetBySoHoaDon(string SoHoaDon)
        {
            return _db.TT_LenhHuys.SingleOrDefault(item => item.SoHoaDon == SoHoaDon);
        }

        public DataTable GetDS()
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen=itemHD.TENKH,
                            DiaChi=itemHD.SO+" "+itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(int MaTo)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                           && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime CreateDate)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemLH.CreateDate.Value.Date == CreateDate.Date
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemLH.CreateDate.Value.Date >= FromCreateDate.Date && itemLH.CreateDate.Value.Date <= ToCreateDate.Date
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSTon()
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.NGAYGIAITRACH==null
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSTon(int MaTo)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                           && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                           && itemHD.NGAYGIAITRACH == null
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDangNgan()
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.NGAYGIAITRACH != null
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDangNgan(int MaTo)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                           && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                           && itemHD.NGAYGIAITRACH != null
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetTinhTrangMoiNhat(string DanhBo)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.SoHoaDon equals itemHD.SOHOADON
                        where itemHD.DANHBA==DanhBo
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            Ky=itemHD.KY+"/"+itemHD.NAM,
                            itemLH.TinhTrang,
                        };
            return LINQToDataTable(query.Take(1));
        }
        
        public string GetTinhTrangBySoHoaDon(string SoHoaDon)
        {
            return _db.TT_LenhHuys.SingleOrDefault(item => item.SoHoaDon == SoHoaDon).TinhTrang;
        }

        public bool GetCatByDanhBo(string DanhBo)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.SoHoaDon equals itemHD.SOHOADON
                        where itemHD.DANHBA == DanhBo
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            itemLH.Cat,
                        };
            if (query.ToList().Count > 0)
                return query.FirstOrDefault().Cat;
            else
                return false;
        }

        
    }
}

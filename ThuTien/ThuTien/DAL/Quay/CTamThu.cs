using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.Quay
{
    class CTamThu:CDAL
    {
        public bool Them(TAMTHU tamthu)
        {
            try
            {
                if (_db.TAMTHUs.Count() > 0)
                    tamthu.ID_TAMTHU = _db.TAMTHUs.Max(item => item.ID_TAMTHU) + 1;
                else
                    tamthu.ID_TAMTHU = 1;
                tamthu.CreateDate = DateTime.Now;
                tamthu.CreateBy = CNguoiDung.MaND;
                _db.TAMTHUs.InsertOnSubmit(tamthu);
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

        public bool Sua(TAMTHU tamthu)
        {
            try
            {
                tamthu.ModifyDate = DateTime.Now;
                tamthu.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(TAMTHU tamthu)
        {
            try
            {
                _db.TAMTHUs.DeleteOnSubmit(tamthu);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaAn(string SoHoaDon)
        {
            try
            {
                string sql = "";
                sql = "update TAMTHU set Xoa=1 where SoHoaDon='" + SoHoaDon + "'";
                return ExecuteNonQuery_Transaction(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(string SoHoaDon, out bool ChuyenKhoan)
        {
            if (_db.TAMTHUs.Any(item => item.SoHoaDon == SoHoaDon))
                ChuyenKhoan = _db.TAMTHUs.SingleOrDefault(item => item.SoHoaDon == SoHoaDon).ChuyenKhoan;
            else
                ChuyenKhoan = false;
            return _db.TAMTHUs.Any(item => item.SoHoaDon == SoHoaDon);
        }

        public bool CheckExist(string SoHoaDon, out string Loai)
        {
            Loai = "";
            if (_db.TAMTHUs.Any(item => item.SoHoaDon == SoHoaDon))
            {
                if (_db.TAMTHUs.SingleOrDefault(item => item.SoHoaDon == SoHoaDon).ChuyenKhoan)
                    Loai = "Chuyển Khoản";
                else
                    Loai = "Quầy";
                return true;
            }
            else
                return false;
        }

        public bool CheckExist(string SoHoaDon, bool ChuyenKhoan)
        {
            return _db.TAMTHUs.Any(item => item.SoHoaDon == SoHoaDon && item.ChuyenKhoan == ChuyenKhoan);
        }

        public bool CheckExist(string SoHoaDon)
        {
            return _db.TAMTHUs.Any(item => item.SoHoaDon == SoHoaDon);
        }

        public DataTable GetDS(bool ChuyenKhoan,DateTime TuNgay)
        {
            var query = from itemTT in _db.TAMTHUs
                        join itemHD in _db.HOADONs on itemTT.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemNH in _db.NGANHANGs on itemTT.MaNH equals itemNH.ID_NGANHANG into tableNH
                        from itemtableNH in tableNH.DefaultIfEmpty()
                        where itemTT.Xoa == false && itemTT.CreateDate.Value.Date == TuNgay.Date && itemTT.ChuyenKhoan == ChuyenKhoan
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            MaTT = itemTT.ID_TAMTHU,
                            itemTT.SoPhieu,
                            itemHD.NGAYGIAITRACH,
                            itemTT.CreateDate,
                            itemHD.SOHOADON,
                            itemHD.SOPHATHANH,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            itemTT.MaNH,
                            TenNH = itemtableNH.NGANHANG1,
                            GiaBieu = itemHD.GB,
                            itemTT.TienDu,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(bool ChuyenKhoan,DateTime TuNgay, DateTime DenNgay)
        {
            var query = from itemTT in _db.TAMTHUs
                        join itemHD in _db.HOADONs on itemTT.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemNH in _db.NGANHANGs on itemTT.MaNH equals itemNH.ID_NGANHANG into tableNH
                        from itemtableNH in tableNH.DefaultIfEmpty()
                        where itemTT.Xoa==false&& itemTT.CreateDate.Value.Date >= TuNgay.Date && itemTT.CreateDate.Value.Date <= DenNgay.Date && itemTT.ChuyenKhoan == ChuyenKhoan
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            MaTT = itemTT.ID_TAMTHU,
                            itemTT.SoPhieu,
                            itemHD.NGAYGIAITRACH,
                            itemTT.CreateDate,
                            itemHD.SOHOADON,
                            itemHD.SOPHATHANH,
                            Ky=itemHD.KY+"/"+itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            itemTT.MaNH,
                            TenNH=itemtableNH.NGANHANG1,
                            GiaBieu=itemHD.GB,
                            itemTT.TienDu,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSTon(int MaTo,bool ChuyenKhoan)
        {
            var query = from itemTT in _db.TAMTHUs
                        join itemHD in _db.HOADONs on itemTT.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemTT.Xoa == false && itemTT.ChuyenKhoan == ChuyenKhoan && itemHD.NGAYGIAITRACH==null
                        && Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemTT.CreateDate,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public List<TAMTHU> GetDSBySoPhieu(decimal SoPhieu)
        {
            return _db.TAMTHUs.Where(item => item.SoPhieu == SoPhieu).ToList();
        }

        public TAMTHU GetByMaTT(int MaTT)
        {
            return _db.TAMTHUs.SingleOrDefault(item => item.ID_TAMTHU == MaTT);
        }

        public decimal GetMaxSoPhieu()
        {
            if (_db.TAMTHUs.Max(item => item.SoPhieu) == null)
            {
                return decimal.Parse("1" + DateTime.Now.ToString("yy"));
            }
            else
            {
                string ID = "SoPhieu";
                string Table = "TAMTHU";
                decimal SoPhieu = _db.ExecuteQuery<decimal>("declare @Ma int " +
                    "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                    "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                return getMaxNextIDTable(SoPhieu);
            }
        }

        public string GetTenNganHang(string SoHoaDon)
        {
            if (_db.TAMTHUs.Any(itemTT => itemTT.SoHoaDon == SoHoaDon && itemTT.MaNH != null))
                return _db.NGANHANGs.SingleOrDefault(item => item.ID_NGANHANG == _db.TAMTHUs.SingleOrDefault(itemTT => itemTT.SoHoaDon == SoHoaDon && itemTT.MaNH != null).MaNH).NGANHANG1;
            else
                return "";
        }
    }
}

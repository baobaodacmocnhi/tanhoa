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

        public bool Xoa(string SoHoaDon)
        {
            try
            {
                string sql = "";
                sql = "delete TAMTHU where SoHoaDon='" + SoHoaDon + "'";
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

        public DataTable GetDS(bool ChuyenKhoan,DateTime TuNgay)
        {
            var query = from itemTT in _db.TAMTHUs
                        join itemHD in _db.HOADONs on itemTT.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemNH in _db.NGANHANGs on itemTT.MaNH equals itemNH.ID_NGANHANG into tableNH
                        from itemtableNH in tableNH.DefaultIfEmpty()
                        where itemTT.CreateDate.Value.Date==TuNgay.Date && itemTT.ChuyenKhoan==ChuyenKhoan
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
                        where itemTT.CreateDate.Value.Date >= TuNgay.Date && itemTT.CreateDate.Value.Date <= DenNgay.Date && itemTT.ChuyenKhoan == ChuyenKhoan
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
    }
}

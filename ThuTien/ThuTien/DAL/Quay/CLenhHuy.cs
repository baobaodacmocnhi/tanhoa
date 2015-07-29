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
                        select new
                        {
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSByCreatedDate(DateTime TuNgay)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemLH.CreateDate.Value.Date == TuNgay.Date
                        select new
                        {
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu=itemHD.GB,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSByCreatedDates(DateTime TuNgay, DateTime DenNgay)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemLH.CreateDate.Value.Date >= TuNgay.Date && itemLH.CreateDate.Value.Date <= DenNgay.Date
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                        };
            return LINQToDataTable(query);
        }
    }
}

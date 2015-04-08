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

        public bool CheckBySoHoaDon(string SoHoaDon)
        {
            return _db.TAMTHUs.Any(item => item.SoHoaDon == SoHoaDon);
        }

        public bool CheckBySoHoaDon(string SoHoaDon,out string loai)
        {
            loai = "";
            if (_db.TAMTHUs.Any(item => item.SoHoaDon == SoHoaDon))
            {
                if (_db.TAMTHUs.SingleOrDefault(item => item.SoHoaDon == SoHoaDon).ChuyenKhoan)
                    loai = "Chuyển Khoản";
                else
                    loai = "Quầy";
                return true;
            }
            else
                return false;
        }

        public DataTable GetDSByDate(bool ChuyenKhoan,int MaNV,DateTime TuNgay)
        {
            var query = from itemTT in _db.TAMTHUs
                        join itemHD in _db.HOADONs on itemTT.FK_HOADON equals itemHD.ID_HOADON
                        where itemTT.CreateDate.Value.Date==TuNgay.Date && itemTT.CreateBy==MaNV && itemTT.ChuyenKhoan==ChuyenKhoan
                        select new
                        {
                            MaTT = itemTT.ID_TAMTHU,
                            itemHD.NGAYGIAITRACH,
                            itemTT.CreateDate,
                            itemHD.SOHOADON,
                            DanhBo = itemHD.DANHBA,
                            itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSByDates(bool ChuyenKhoan, int MaNV, DateTime TuNgay, DateTime DenNgay)
        {
            var query = from itemTT in _db.TAMTHUs
                        //join itemNH in _db.NGANHANGs on itemTT.MaNH equals itemNH.ID_NGANHANG
                        join itemHD in _db.HOADONs on itemTT.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND
                        where itemTT.CreateDate.Value.Date >= TuNgay.Date && itemTT.CreateDate.Value.Date <= DenNgay.Date && itemTT.CreateBy == MaNV && itemTT.ChuyenKhoan == ChuyenKhoan
                        select new
                        {
                            MaTT = itemTT.ID_TAMTHU,
                            itemHD.NGAYGIAITRACH,
                            itemTT.CreateDate,
                            itemHD.SOHOADON,
                            itemHD.SOPHATHANH,
                            //itemHD.NAM,
                            Ky=itemHD.KY+"/"+itemHD.NAM,
                            //itemHD.DOT,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            HanhThu = itemND.HoTen,
                            To = itemND.TT_To.TenTo,
                            itemTT.MaNH,
                        };
            return LINQToDataTable(query);
        }

        public TAMTHU GetByMaTT(int MaTT)
        {
            return _db.TAMTHUs.SingleOrDefault(item => item.ID_TAMTHU == MaTT);
        }
    }
}

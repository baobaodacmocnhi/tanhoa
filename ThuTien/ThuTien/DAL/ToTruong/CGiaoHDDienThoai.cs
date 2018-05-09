using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.ToTruong
{
    class CGiaoHDDienThoai:CDAL
    {
        public bool Them(TT_GiaoHDDienThoai entity)
        {
            try
            {
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CNguoiDung.MaND;
                _db.TT_GiaoHDDienThoais.InsertOnSubmit(entity);
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

        public bool Xoa(TT_GiaoHDDienThoai entity)
        {
            try
            {
                _db.TT_GiaoHDDienThoais.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(int MaHD, int MaNV, DateTime NgayDi)
        {
            return _db.TT_GiaoHDDienThoais.Any(item => item.MaHD == MaHD && item.MaNV == MaNV && item.NgayDi == NgayDi.Date);
        }

        public DataTable getDS(int MaNV,DateTime NgayDi)
        {
            var query=from itemG in _db.TT_GiaoHDDienThoais
                      join itemHD in _db.HOADONs on itemG.MaHD equals itemHD.ID_HOADON
                      join itemND in _db.TT_NguoiDungs on itemG.MaNV equals itemND.MaND
                      where itemG.MaNV==MaNV && itemG.NgayDi==NgayDi.Date
                      select new
                      {
                          itemG.MaNV,
                          itemND.HoTen,
                          itemG.MaHD,
                          itemG.SoHoaDon,
                          Ky=itemHD.KY+"/"+itemHD.NAM,
                          itemHD.GIABAN,
                          ThueGTGT=itemHD.THUE,
                          PhiBVMT=itemHD.PHI,
                          itemHD.TONGCONG,
                          itemG.NgayDi,
                      };
            return LINQToDataTable(query);
        }

    }
}

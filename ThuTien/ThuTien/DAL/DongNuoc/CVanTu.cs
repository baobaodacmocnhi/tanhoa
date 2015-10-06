using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.DongNuoc
{
    class CVanTu:CDAL
    {
        public bool Them(TT_VanTu vantu)
        {
            try
            {
                vantu.CreateDate = DateTime.Now;
                vantu.CreateBy = CNguoiDung.MaND;
                _db.TT_VanTus.InsertOnSubmit(vantu);
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

        public bool Xoa(TT_VanTu vantu)
        {
            try
            {
                _db.TT_VanTus.DeleteOnSubmit(vantu);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(string DanhBo)
        {
            return _db.TT_VanTus.Any(item => item.DanhBo == DanhBo);
        }

        public TT_VanTu GetByID(string DanhBo)
        {
            return _db.TT_VanTus.SingleOrDefault(item => item.DanhBo == DanhBo);
        }

        public DataTable GetDS()
        {
            var query = from itemVT in _db.TT_VanTus
                        join itemHD in _db.HOADONs on itemVT.DanhBo equals itemHD.DANHBA
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        select new
                        {
                            itemVT.DanhBo,
                            DiaChi=itemHD.SO+ " "+itemHD.DUONG,
                            To=itemtableND.TT_To.TenTo,
                            HanhThu=itemtableND.HoTen,
                        };

            return LINQToDataTable(query);
        }
    }
}

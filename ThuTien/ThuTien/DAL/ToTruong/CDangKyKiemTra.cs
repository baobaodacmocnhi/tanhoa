using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.ToTruong
{
    class CDangKyKiemTra:CDAL
    {
        public bool Them(TT_DangKyKiemTra dangky)
        {
            try
            {
                dangky.CreateDate = DateTime.Now;
                dangky.CreateBy = CNguoiDung.MaND;
                _db.TT_DangKyKiemTras.InsertOnSubmit(dangky);
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

        public bool Xoa(TT_DangKyKiemTra dangky)
        {
            try
            {
                _db.TT_DangKyKiemTras.DeleteOnSubmit(dangky);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(TT_DangKyKiemTra dangky)
        {
            try
            {
                dangky.ModifyDate = DateTime.Now;
                dangky.ModifyBy = CNguoiDung.MaND;
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
            return _db.TT_DangKyKiemTras.Any(item => item.DanhBo == DanhBo);
        }

        public string GetHoTen(string DanhBo)
        {
            return _db.TT_NguoiDungs.SingleOrDefault(item => item.MaND == _db.TT_DangKyKiemTras.SingleOrDefault(item2 => item2.DanhBo == DanhBo).MaNV).HoTen;
        }

        public TT_DangKyKiemTra Get(string DanhBo)
        {
            return _db.TT_DangKyKiemTras.SingleOrDefault(item => item.DanhBo == DanhBo);
        }

        public DataTable GetDS(int MaNV)
        {
            var query = from itemDK in _db.TT_DangKyKiemTras
                        join itemND in _db.TT_NguoiDungs on itemDK.MaNV equals itemND.MaND
                        where itemDK.MaNV == MaNV
                        select new
                        {
                            itemND.HoTen,
                            itemDK.DanhBo,
                            itemDK.MLT,
                            itemDK.DiaChi,
                            itemDK.GB_DM_Cu,
                            itemDK.NoiDung,
                            itemDK.CreateDate,
                        };
            return LINQToDataTable(query);
        }
    }
}

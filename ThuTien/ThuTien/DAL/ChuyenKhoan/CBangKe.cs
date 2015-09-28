using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.ChuyenKhoan
{
    class CBangKe : CDAL
    {
        public bool Them(TT_BangKe bangke)
        {
            try
            {
                if (_db.TT_BangKes.Count() == 0)
                    bangke.MaBK = 1;
                else
                    bangke.MaBK = _db.TT_BangKes.Max(item => item.MaBK) + 1;
                bangke.CreateDate = DateTime.Now;
                bangke.CreateBy = CNguoiDung.MaND;
                _db.TT_BangKes.InsertOnSubmit(bangke);
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

        public bool Sua(TT_BangKe bangke)
        {
            try
            {
                bangke.ModifyDate = DateTime.Now;
                bangke.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(TT_BangKe bangke)
        {
            try
            {
                _db.TT_BangKes.DeleteOnSubmit(bangke);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(string DanhBo, DateTime CreateDate)
        {
            return _db.TT_BangKes.Any(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public TT_BangKe Get(int MaBK)
        {
            return _db.TT_BangKes.SingleOrDefault(item => item.MaBK == MaBK);
        }

        public DataTable GetDS()
        {
            var query = from itemBK in _db.TT_BangKes
                        join itemNH in _db.NGANHANGs on itemBK.MaNH equals itemNH.ID_NGANHANG into tableNH
                        from itemtableNH in tableNH.DefaultIfEmpty()
                        select new
                        {
                            itemBK.MaBK,
                            itemBK.DanhBo,
                            itemBK.SoTien,
                            itemBK.CreateDate,
                            TenNH = itemtableNH.NGANHANG1,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime TuNgay, DateTime DenNgay)
        {
            var query = from itemBK in _db.TT_BangKes
                        join itemNH in _db.NGANHANGs on itemBK.MaNH equals itemNH.ID_NGANHANG into tableNH
                        from itemtableNH in tableNH.DefaultIfEmpty()
                        where itemBK.CreateDate.Value.Date >= TuNgay.Date && itemBK.CreateDate.Value.Date <= DenNgay.Date
                        select new
                        {
                            itemBK.MaBK,
                            itemBK.DanhBo,
                            itemBK.SoTien,
                            itemBK.CreateDate,
                            TenNH = itemtableNH.NGANHANG1,
                        };
            return LINQToDataTable(query);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.TongHop
{
    class CCongVan:CDAL
    {
        public bool Them(TT_CongVan congvan)
        {
            try
            {
                if (_db.TT_CongVans.Count() > 0)
                    congvan.MaCV = _db.TT_CongVans.Max(item => item.MaCV) + 1;
                else
                    congvan.MaCV = 1;
                congvan.CreateDate = DateTime.Now;
                congvan.CreateBy = CNguoiDung.MaND;
                _db.TT_CongVans.InsertOnSubmit(congvan);
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

        public bool Xoa(TT_CongVan congvan)
        {
            try
            {
                _db.TT_CongVans.DeleteOnSubmit(congvan);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(TT_CongVan congvan)
        {
            try
            {
                congvan.ModifyDate = DateTime.Now;
                congvan.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(string Loai, string DanhBo, DateTime CreateDate)
        {
            return _db.TT_CongVans.Any(item => item.Loai == Loai && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public DataTable GetDS(string DanhBo)
        {
            var query = from item in _db.TT_CongVans
                        where item.DanhBo==DanhBo
                        select new
                        {
                            db="Thu Tiền",
                            item.Loai,
                            item.NoiDung,
                            item.CreateDate,
                            Table="TT_CongVan",
                            Column="MaCV",
                            Ma=(decimal)item.MaCV,
                            ThuTien_Nhan=true,
                            ThuTien_NgayNhan = item.CreateDate,
                            ThuTien_GhiChu=item.GhiChu,
                            item.GhiChu,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(string Loai, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in _db.TT_CongVans
                        where item.Loai.Contains(Loai) && item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            db = "Thu Tiền",
                            item.Loai,
                            item.NoiDung,
                            item.CreateDate,
                            Table = "TT_CongVan",
                            Column = "MaCV",
                            Ma = (decimal)item.MaCV,
                            ThuTien_Nhan = true,
                            ThuTien_NgayNhan = item.CreateDate,
                            ThuTien_GhiChu = item.GhiChu,
                            item.GhiChu,
                        };
            return LINQToDataTable(query);
        }
    }
}

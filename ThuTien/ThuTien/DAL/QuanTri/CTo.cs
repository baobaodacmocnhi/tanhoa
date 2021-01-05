using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;

namespace ThuTien.DAL.QuanTri
{
    class CTo : CDAL
    {
        public bool Them(TT_To to)
        {
            try
            {
                if (_db.TT_Tos.Count() > 0)
                    to.MaTo = _db.TT_Tos.Max(item => item.MaTo) + 1;
                else
                    to.MaTo = 1;
                to.CreateDate = DateTime.Now;
                to.CreateBy = CNguoiDung.MaND;
                _db.TT_Tos.InsertOnSubmit(to);
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

        public bool Sua(TT_To to)
        {
            try
            {
                to.ModifyDate = DateTime.Now;
                to.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(TT_To to)
        {
            try
            {
                _db.TT_Tos.DeleteOnSubmit(to);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public List<TT_To> getDS_All()
        {
            return _db.TT_Tos.ToList();
        }

        public List<TT_To> getDS()
        {
            return _db.TT_Tos.Where(item => item.An == false).ToList();
        }

        public List<TT_To> getDS_HanhThu()
        {
            return _db.TT_Tos.Where(item => item.HanhThu == true && item.An == false).ToList();
        }

        public List<TT_To> getDS_DongNuoc()
        {
            return _db.TT_Tos.Where(item => item.DongNuoc == true && item.An == false).ToList();
        }

        public TT_To get(int MaTo)
        {
            return _db.TT_Tos.SingleOrDefault(item => item.MaTo == MaTo);
        }

        public string getHoTen(int MaTo)
        {
            return _db.TT_Tos.SingleOrDefault(item => item.MaTo == MaTo).TenTo;
        }

        public bool checkHanhThu(int MaTo)
        {
            return _db.TT_Tos.Any(item => item.MaTo == MaTo && item.HanhThu == true);
        }

        public bool checkDongNuoc(int MaTo)
        {
            return _db.TT_Tos.Any(item => item.MaTo == MaTo && item.DongNuoc == true);
        }
    }
}

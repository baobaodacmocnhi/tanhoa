using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;

namespace DocSo_PC.DAL.QuanTri
{
    class CTo:CDAL
    {
        public bool Them(To to)
        {
            try
            {
                if (_db.Tos.Count() > 0)
                    to.MaTo = _db.Tos.Max(item => item.MaTo) + 1;
                else
                    to.MaTo = 1;
                to.CreateDate = DateTime.Now;
                to.CreateBy = CNguoiDung.MaND;
                _db.Tos.InsertOnSubmit(to);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(To to)
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

        public bool Xoa(To to)
        {
            try
            {
                _db.Tos.DeleteOnSubmit(to);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public List<To> getDS()
        {
            return _db.Tos.ToList();
        }

        public List<To> getDS_HanhThu()
        {
            return _db.Tos.Where(item => item.HanhThu == true).ToList();
        }

        public To get(int MaTo)
        {
            return _db.Tos.SingleOrDefault(item => item.MaTo == MaTo);
        }

        public string getTenTo(int MaTo)
        {
            return _db.Tos.SingleOrDefault(item => item.MaTo == MaTo).TenTo;
        }

        public bool checkHanhThu(int MaTo)
        {
            return _db.Tos.Any(item => item.MaTo == MaTo && item.HanhThu == true);
        }
    }
}

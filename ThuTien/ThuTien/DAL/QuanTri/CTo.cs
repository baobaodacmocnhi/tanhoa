using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;

namespace ThuTien.DAL.QuanTri
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

        public List<To> GetDSTo()
        {
            return _db.Tos.ToList();
        }

        public To GetToByMaTo(int MaTo)
        {
            return _db.Tos.SingleOrDefault(item => item.MaTo == MaTo);
        }

        public string GetTenToByMaTo(int MaTo)
        {
            return _db.Tos.SingleOrDefault(item => item.MaTo == MaTo).TenTo;
        }
    }
}

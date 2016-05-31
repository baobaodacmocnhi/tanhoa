using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;

namespace ThuTien.DAL.Doi
{
    class CGiaBanBinhQuan:CDAL
    {
        public bool Them(TT_GiaBanBinhQuan entity)
        {
            try
            {
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CNguoiDung.MaND;
                _db.TT_GiaBanBinhQuans.InsertOnSubmit(entity);
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

        public bool Sua(TT_GiaBanBinhQuan entity)
        {
            try
            {
                entity.ModifyDate = DateTime.Now;
                entity.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(TT_GiaBanBinhQuan entity)
        {
            try
            {
                _db.TT_GiaBanBinhQuans.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(int Nam, int Ky)
        {
            return _db.TT_GiaBanBinhQuans.Any(item => item.Nam == Nam && item.Ky == Ky);
        }

        public List<TT_GiaBanBinhQuan> GetDS()
        {
            return _db.TT_GiaBanBinhQuans.ToList();
        }

        public List<TT_GiaBanBinhQuan> GetDS(int Nam)
        {
            return _db.TT_GiaBanBinhQuans.Where(item=>item.Nam==Nam).ToList();
        }

        public TT_GiaBanBinhQuan Get(int Nam, int Ky)
        {
           return  _db.TT_GiaBanBinhQuans.SingleOrDefault(item => item.Nam == Nam && item.Ky == Ky);
        }

    }
}

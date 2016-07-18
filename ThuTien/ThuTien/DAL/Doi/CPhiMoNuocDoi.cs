using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.Doi
{
    class CPhiMoNuocDoi:CDAL
    {
        public bool Them(TT_PhiMoNuocDoi entity)
        {
            try
            {
                if (_db.TT_PhiMoNuocDois.Count() > 0)
                    entity.ID = _db.TT_PhiMoNuocDois.Max(item => item.ID) + 1;
                else
                    entity.ID = 1;
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CNguoiDung.MaND;
                _db.TT_PhiMoNuocDois.InsertOnSubmit(entity);
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

        public bool Sua(TT_PhiMoNuocDoi entity)
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

        public bool Xoa(TT_PhiMoNuocDoi entity)
        {
            try
            {
                _db.TT_PhiMoNuocDois.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public TT_PhiMoNuocDoi Get(int ID)
        {
            return _db.TT_PhiMoNuocDois.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetDS()
        {
            return LINQToDataTable(_db.TT_PhiMoNuocDois.ToList());
        }
    }
}

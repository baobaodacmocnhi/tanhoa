using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.KiemTraXacMinh
{
    class CHienTrangKiemTra : CDAL
    {
        public bool Them(HienTrangKiemTra entity)
        {
            try
            {
                if (db.HienTrangKiemTras.Count() > 0)
                    entity.MaHTKT = db.HienTrangKiemTras.Max(itemHTKT => itemHTKT.MaHTKT) + 1;
                else
                    entity.MaHTKT = 1;
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.HienTrangKiemTras.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool Sua(HienTrangKiemTra entity)
        {
            try
            {
                entity.ModifyDate = DateTime.Now;
                entity.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool Xoa(HienTrangKiemTra entity)
        {
            try
            {
                db.HienTrangKiemTras.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public HienTrangKiemTra Get(int MaHTKT)
        {
            return db.HienTrangKiemTras.SingleOrDefault(itemHTKT => itemHTKT.MaHTKT == MaHTKT);
        }

        public List<HienTrangKiemTra> GetDS()
        {
            return db.HienTrangKiemTras.OrderBy(item => item.STT).ToList();
        }

        public int GetMaxSTT()
        {
            if (db.HienTrangKiemTras.Count() == 0)
                return 0;
            else
                return db.HienTrangKiemTras.Max(item => item.STT).Value;
        }
    }
}

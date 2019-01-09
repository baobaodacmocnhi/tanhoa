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
        public bool Them(KTXM_HienTrang entity)
        {
            try
            {
                if (db.KTXM_HienTrangs.Count() > 0)
                    entity.MaHTKT = db.KTXM_HienTrangs.Max(itemHTKT => itemHTKT.MaHTKT) + 1;
                else
                    entity.MaHTKT = 1;
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.KTXM_HienTrangs.InsertOnSubmit(entity);
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

        public bool Sua(KTXM_HienTrang entity)
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

        public bool Xoa(KTXM_HienTrang entity)
        {
            try
            {
                db.KTXM_HienTrangs.DeleteOnSubmit(entity);
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

        public KTXM_HienTrang Get(int MaHTKT)
        {
            return db.KTXM_HienTrangs.SingleOrDefault(itemHTKT => itemHTKT.MaHTKT == MaHTKT);
        }

        public List<KTXM_HienTrang> getDS()
        {
            return db.KTXM_HienTrangs.OrderBy(item => item.TenHTKT).ToList();
        }

        public List<KTXM_HienTrang> getDS(string To)
        {
            switch (To)
            {
                case "ToTB":
                    return db.KTXM_HienTrangs.Where(item => item.ToTB == true).OrderBy(item => item.STT_ToTB).ToList();
                case "ToTP":
                    return db.KTXM_HienTrangs.Where(item => item.ToTP == true).OrderBy(item => item.STT_ToTP).ToList();
                case "ToBC":
                    return db.KTXM_HienTrangs.Where(item => item.ToBC == true).OrderBy(item => item.STT_ToBC).ToList();
                default:
                    return db.KTXM_HienTrangs.OrderBy(item => item.TenHTKT).ToList();
            }
            
        }

        public int GetMaxSTT()
        {
            if (db.KTXM_HienTrangs.Count() == 0)
                return 0;
            else
                return db.KTXM_HienTrangs.Max(item => item.STT).Value;
        }
    }
}

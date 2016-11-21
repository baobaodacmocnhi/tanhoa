using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.DAL.DieuChinhBienDong
{
    class CLoaiChungTu : CDAL
    {
        //dbKinhDoanhDataContext db = new dbKinhDoanhDataContext();

        public List<LoaiChungTu> LoadDSLoaiChungTu()
        {
            try
            {
                    //var query = from itemLCT in db.LoaiChungTus
                    //            select new { itemLCT.MaLCT, itemLCT.KyHieuLCT, itemLCT.TenLCT, itemLCT.ThoiHan };
                    return db.LoaiChungTus.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách loại chứng từ, hàm này được dùng trong nội bộ DAL
        /// </summary>
        /// <param name="inheritance">true</param>
        /// <returns></returns>
        public List<LoaiChungTu> LoadDSLoaiChungTu(bool inhertance)
        {
            try
            {
                if (inhertance)
                {
                    //var query = from itemLCT in db.LoaiChungTus
                    //            select new { itemLCT.MaLCT, itemLCT.KyHieuLCT, itemLCT.TenLCT, itemLCT.ThoiHan };
                    return db.LoaiChungTus.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public LoaiChungTu getLoaiChungTubyID(int MaLCT)
        {
            try
            {
                return db.LoaiChungTus.SingleOrDefault(itemLCT => itemLCT.MaLCT == MaLCT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemLoaiChungTu(LoaiChungTu loaichungtu)
        {
            try
            {
                    if (db.LoaiChungTus.Count() > 0)
                        loaichungtu.MaLCT = db.LoaiChungTus.Max(itemLCT => itemLCT.MaLCT) + 1;
                    else
                        loaichungtu.MaLCT = 1;
                    loaichungtu.CreateDate = DateTime.Now;
                    loaichungtu.CreateBy = CTaiKhoan.MaUser;
                    db.LoaiChungTus.InsertOnSubmit(loaichungtu);
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Thêm LoaiChungTu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool SuaLoaiChungTu(LoaiChungTu loaichungtu)
        {
            try
            {
                    loaichungtu.ModifyDate = DateTime.Now;
                    loaichungtu.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Sửa LoaiChungTu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        /// <summary>
        /// Lấy MaLCT bằng TenLCT
        /// </summary>
        /// <param name="TenLCT"></param>
        /// <returns></returns>
        public int getMaLCTbyTenLCT(string TenLCT)
        {
            try
            {
                return db.LoaiChungTus.SingleOrDefault(itemLCT => itemLCT.TenLCT == TenLCT).MaLCT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}

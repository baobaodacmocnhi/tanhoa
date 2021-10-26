using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.QuanTri
{
    class CBanGiamDoc : CDAL
    {
        public List<BanGiamDoc> getDS_Admin()
        {
            return db.BanGiamDocs.ToList();
        }

        public List<BanGiamDoc> getDS()
        {
            return db.BanGiamDocs.Where(item=>item.An==false).ToList();
        }

        public BanGiamDoc get(int ID)
        {
            return db.BanGiamDocs.Single(itemBGD => itemBGD.MaBGD == ID);
        }

        public BanGiamDoc getBGDNguoiKy()
        {
            return db.BanGiamDocs.SingleOrDefault(itemBGD => itemBGD.KyTen == true);
        }

        public BanGiamDoc getBGDNguoiKyDuyet()
        {
            return db.BanGiamDocs.SingleOrDefault(itemBGD => itemBGD.KyTenDuyet == true);
        }

        public bool Them(BanGiamDoc bangiamdoc)
        {
            try
            {
                if (db.BanGiamDocs.Count() > 0)
                    bangiamdoc.MaBGD = db.BanGiamDocs.Max(itemBGD => itemBGD.MaBGD) + 1;
                else
                    bangiamdoc.MaBGD = 1;
                bangiamdoc.CreateDate = DateTime.Now;
                bangiamdoc.CreateBy = CTaiKhoan.MaUser;
                db.BanGiamDocs.InsertOnSubmit(bangiamdoc);
                db.SubmitChanges();
                MessageBox.Show("Thành công Thêm BanGiamDoc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(BanGiamDoc bangiamdoc)
        {
            try
            {
                bangiamdoc.ModifyDate = DateTime.Now;
                bangiamdoc.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        
    }
}

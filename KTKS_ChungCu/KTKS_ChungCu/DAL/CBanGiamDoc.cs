using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_ChungCu.LinQ;
using System.Windows.Forms;

namespace KTKS_ChungCu.DAL
{
    class CBanGiamDoc : CDAL
    {
        public List<BanGiamDoc> LoadDSBanGiamDoc()
        {
            try
            {
                    return dbDonKH.BanGiamDocs.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public BanGiamDoc getBanGiamDocbyID(int MaBGD)
        {
            try
            {
                return dbDonKH.BanGiamDocs.Single(itemBGD => itemBGD.MaBGD == MaBGD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public BanGiamDoc getBGDNguoiKy()
        {
            try
            {
                return dbDonKH.BanGiamDocs.SingleOrDefault(itemBGD => itemBGD.KyTen == true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

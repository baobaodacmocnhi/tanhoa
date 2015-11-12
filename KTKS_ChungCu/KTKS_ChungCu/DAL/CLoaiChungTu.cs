using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_ChungCu.LinQ;
using System.Windows.Forms;

namespace KTKS_ChungCu.DAL
{
    class CLoaiChungTu : CDAL
    {

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
                    return dbDonKH.LoaiChungTus.ToList();
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
                return dbDonKH.LoaiChungTus.SingleOrDefault(itemLCT => itemLCT.MaLCT == MaLCT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
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
                return dbDonKH.LoaiChungTus.SingleOrDefault(itemLCT => itemLCT.TenLCT == TenLCT).MaLCT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public string getMaxNextID()
        {
            try
            {
                if (db.ChungTus.Any(itemCC => itemCC.MaCT.Substring(0, 4) == "XNTT"))
                {
                    string MaxID = db.ChungTus.Where(itemCC => itemCC.MaCT.Substring(0, 4) == "XNTT").Max(itemCC => itemCC.MaCT).ToString();
                    string stt = MaxID.Substring(4);
                    return "XNTT" + (stt + 1);
                }
                else
                    return "XNTT" + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
    }
}

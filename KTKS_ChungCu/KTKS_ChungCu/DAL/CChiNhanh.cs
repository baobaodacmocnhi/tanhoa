using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_ChungCu.LinQ;
using System.Windows.Forms;

namespace KTKS_ChungCu.DAL
{
    class CChiNhanh : CDAL
    {
        public List<ChiNhanh> LoadDSChiNhanh()
        {
            try
            {
                return dbDonKH.ChiNhanhs.ToList();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách Chi Nhánh, hàm này được dùng trong nội bộ DAL
        /// </summary>
        /// <param name="inheritance">true</param>
        /// <returns></returns>
        public List<ChiNhanh> LoadDSChiNhanh(bool inhertance)
        {
            try
            {
                if (inhertance)
                {
                    return dbDonKH.ChiNhanhs.ToList();
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

        /// <summary>
        /// Lấy danh sách Chi Nhánh(ngoài trừ Chi Nhánh nào đó), hàm này được dùng trong nội bộ DAL
        /// </summary>
        /// <param name="inhertance"></param>
        /// <param name="except">Tên Chi Nhánh ngoại trừ</param>
        /// <returns></returns>
        public List<ChiNhanh> LoadDSChiNhanh(bool inhertance,string except)
        {
            try
            {
                if (inhertance)
                {
                    var query = from itemCN in dbDonKH.ChiNhanhs
                                where !itemCN.TenCN.ToUpper().Contains(except.ToUpper())
                                select itemCN;
                    return query.ToList();
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

        public ChiNhanh getChiNhanhbyID(int MaCN)
        {
            try
            {
                return dbDonKH.ChiNhanhs.SingleOrDefault(itemCN => itemCN.MaCN == MaCN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Tên Chi Nhánh từ Mã Chi Nhánh truyền vào
        /// </summary>
        /// <param name="MaCN"></param>
        /// <returns></returns>
        public string getTenChiNhanhbyID(int MaCN)
        {
            try
            {
                return dbDonKH.ChiNhanhs.Single(itemCN => itemCN.MaCN == MaCN).TenCN;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.KhachHang
{
    class CChuyenDi : CDAL
    {
        //DB_KTKS_DonKHDataContext db = new DB_KTKS_DonKHDataContext();

        public List<ChuyenDi> LoadDSChuyenDi()
        {
            try
            {
                return db.ChuyenDis.OrderBy(itemCD=>itemCD.STT).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Load Danh Sách trong bảng Chuyển Đi trừ MaChuyen truyền vào
        /// </summary>
        /// <param name="MaChuyen">giá trị truyền vào cần loại trừ</param>
        /// <returns></returns>
        public List<ChuyenDi> LoadDSChuyenDi(string MaChuyen)
        {
            try
            {
                return db.ChuyenDis.Where(itemCD => itemCD.MaChuyen != MaChuyen).OrderBy(itemCD => itemCD.STT).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Load Danh Sách trong bảng Chuyển Đi trừ MaChuyen truyền vào
        /// </summary>
        /// <param name="MaChuyen1"></param>
        /// <param name="MaChuyen2"></param>
        /// <returns></returns>
        public List<ChuyenDi> LoadDSChuyenDi(string MaChuyen1, string MaChuyen2)
        {
            try
            {
                return db.ChuyenDis.Where(itemCD => itemCD.MaChuyen != MaChuyen1 && itemCD.MaChuyen != MaChuyen2).OrderBy(itemCD => itemCD.STT).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

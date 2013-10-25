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
    }
}

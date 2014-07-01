using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.KhachHang
{
    class CPhuongQuan
    {
        DB_CAPNUOCTANHOADataContext dbCAPNUOCTANHOA = new DB_CAPNUOCTANHOADataContext();

        /// <summary>
        /// Lấy Tên Phường & Quận của Danh Bộ
        /// </summary>
        /// <param name="MaQuan"></param>
        /// <param name="MaPhuong"></param>
        /// <returns></returns>
        public string getPhuongQuanByID(string MaQuan, string MaPhuong)
        {
            try
            {
                string Phuong = ", P." + dbCAPNUOCTANHOA.PHUONGs.Single(itemPhuong => itemPhuong.MAQUAN == int.Parse(MaQuan) && itemPhuong.MAPHUONG == MaPhuong).TENPHUONG;
                string Quan = ", Q." + dbCAPNUOCTANHOA.QUANs.Single(itemQuan => itemQuan.MAQUAN == int.Parse(MaQuan)).TENQUAN;
                return Phuong + Quan;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public void getTTDHNbyID(string DanhBo,out string Hieu,out string Co,out string SoThan)
        {
            try
            {
                TB_DULIEUKHACHHANG ttkhachhang = dbCAPNUOCTANHOA.TB_DULIEUKHACHHANGs.SingleOrDefault(itemttkhachhang => itemttkhachhang.DANHBO == DanhBo);
                Hieu = ttkhachhang.HIEUDH;
                Co = ttkhachhang.CODH;
                SoThan = ttkhachhang.SOTHANDH;
            }
            catch (Exception ex)
            {
                Hieu = "";
                Co = "";
                SoThan = "";
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}

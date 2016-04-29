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

        public List<QUAN> LoadDSQuan()
        {
           return  dbCAPNUOCTANHOA.QUANs.ToList();
        }

        public List<PHUONG> LoadDSPhuongbyQuan(int MaQuan)
        {
            return dbCAPNUOCTANHOA.PHUONGs.Where(item => item.MAQUAN == MaQuan).ToList();
        }

        public string getTenQuanByMaQuan(int MaQuan)
        {
            return dbCAPNUOCTANHOA.QUANs.SingleOrDefault(item => item.MAQUAN == MaQuan).TENQUAN;
        }

        public string getTenPhuongByMaQuanPhuong(int MaQuan,string MaPhuong)
        {
            return dbCAPNUOCTANHOA.PHUONGs.SingleOrDefault(item => item.MAQUAN == MaQuan&&item.MAPHUONG==MaPhuong).TENPHUONG;
        }

        public string getDot(string DanhBo)
        {
            return dbCAPNUOCTANHOA.TB_DULIEUKHACHHANGs.SingleOrDefault(item => item.DANHBO == DanhBo).LOTRINH.Substring(0,2);
        }
    }
}

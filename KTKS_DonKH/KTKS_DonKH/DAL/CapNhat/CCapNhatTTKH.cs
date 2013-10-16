using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;
using System.IO;

namespace KTKS_DonKH.DAL.CapNhat
{
    class CCapNhatTTKH
    {
        DB_KTKS_DonKHDataContext db = new DB_KTKS_DonKHDataContext();

        public void CapNhatTTKH(string pathFile)
        {
            if (CTaiKhoan.RoleCapNhat)
            {
                db.HoaDons.DeleteAllOnSubmit(db.HoaDons);
                string[] lines= File.ReadAllLines(pathFile);
                foreach (string line in lines)
                {
                    string[] ContentsLine = line.Split(',');
                    HoaDon hd = new HoaDon();
                    hd.Khu = ContentsLine[0].Substring(1, ContentsLine[0].Length - 2);
                    hd.Dot = ContentsLine[1].Substring(1, ContentsLine[1].Length - 2);
                    hd.DanhBo = ContentsLine[2].Substring(1, ContentsLine[2].Length - 2);
                    hd.CD = ContentsLine[3].Substring(1, ContentsLine[3].Length - 2);
                    hd.CuLy = ContentsLine[4].Substring(1, ContentsLine[4].Length - 2);
                    hd.MSTLK = ContentsLine[5].Substring(1, ContentsLine[5].Length - 2);
                    hd.GiaoUoc = ContentsLine[6].Substring(1, ContentsLine[6].Length - 2);
                    hd.HoTen = ContentsLine[7].Substring(1, ContentsLine[7].Length - 2);
                    hd.DC1 = ContentsLine[8].Substring(1, ContentsLine[8].Length - 2);
                    hd.DC2 = ContentsLine[9].Substring(1, ContentsLine[9].Length - 2);
                    hd.MSKH = ContentsLine[10].Substring(1, ContentsLine[10].Length - 2);
                    hd.MSCQ = ContentsLine[11].Substring(1, ContentsLine[11].Length - 2);
                    hd.GB = ContentsLine[12].Substring(1, ContentsLine[12].Length - 2);
                    hd.SH = ContentsLine[13].Substring(1, ContentsLine[13].Length - 2);
                    hd.HCSN = ContentsLine[14].Substring(1, ContentsLine[14].Length - 2);
                    hd.SX = ContentsLine[15].Substring(1, ContentsLine[15].Length - 2);
                    hd.DV = ContentsLine[16].Substring(1, ContentsLine[16].Length - 2);
                    hd.TGDM = ContentsLine[17].Substring(1, ContentsLine[17].Length - 2);
                    hd.Ky = ContentsLine[18].Substring(1, ContentsLine[18].Length - 2);
                    hd.Nam = ContentsLine[19].Substring(1, ContentsLine[19].Length - 2);
                    hd.Code = ContentsLine[20].Substring(1, ContentsLine[20].Length - 2);
                    hd.CodeFu = ContentsLine[21].Substring(1, ContentsLine[21].Length - 2);
                    hd.CSCu = ContentsLine[22].Substring(1, ContentsLine[22].Length - 2);
                    hd.CSMoi = ContentsLine[23].Substring(1, ContentsLine[23].Length - 2);
                    hd.RT = ContentsLine[24].Substring(1, ContentsLine[24].Length - 2);
                    hd.NgayDSKT = ContentsLine[25].Substring(1, ContentsLine[25].Length - 2);
                    hd.NgayDSKN = ContentsLine[26].Substring(1, ContentsLine[26].Length - 2);
                    hd.ChuKyDS = ContentsLine[27].Substring(1, ContentsLine[27].Length - 2);
                    hd.LNCC = ContentsLine[28].Substring(1, ContentsLine[28].Length - 2);
                    hd.LNCT = ContentsLine[29].Substring(1, ContentsLine[29].Length - 2);
                    hd.LNBuToiThieu = ContentsLine[30].Substring(1, ContentsLine[30].Length - 2);
                    hd.LNSH = ContentsLine[31].Substring(1, ContentsLine[31].Length - 2);
                    hd.LNHCSN = ContentsLine[32].Substring(1, ContentsLine[32].Length - 2);
                    hd.LNSX = ContentsLine[33].Substring(1, ContentsLine[33].Length - 2);
                    hd.LNDV = ContentsLine[34].Substring(1, ContentsLine[34].Length - 2);
                    hd.CuonGCS = ContentsLine[35].Substring(1, ContentsLine[35].Length - 2);
                    hd.CuonSTT = ContentsLine[36].Substring(1, ContentsLine[36].Length - 2);
                    hd.GiaBan = ContentsLine[37].Substring(1, ContentsLine[37].Length - 2);
                    hd.ThueGTGT = ContentsLine[38].Substring(1, ContentsLine[38].Length - 2);
                    hd.PhiBVMT = ContentsLine[39].Substring(1, ContentsLine[39].Length - 2);
                    hd.TongCong = ContentsLine[40].Substring(1, ContentsLine[40].Length - 2);
                    hd.GiaBanBuToiThieu = ContentsLine[41].Substring(1, ContentsLine[41].Length - 2);
                    hd.ThueGTGTBuToiThieu = ContentsLine[42].Substring(1, ContentsLine[42].Length - 2);
                    hd.PhiBVMTBuToiThieu = ContentsLine[43].Substring(1, ContentsLine[43].Length - 2);
                    hd.TongCongBuToiThieu = ContentsLine[44].Substring(1, ContentsLine[44].Length - 2);
                    hd.SoPhatHanh = ContentsLine[45].Substring(1, ContentsLine[45].Length - 2);
                    hd.SoHoaDon = ContentsLine[46].Substring(1, ContentsLine[46].Length - 2);
                    hd.NgayPhatHanh = ContentsLine[47].Substring(1, ContentsLine[47].Length - 2);
                    hd.Quan = ContentsLine[48].Substring(1, ContentsLine[48].Length - 2);
                    hd.Phuong = ContentsLine[49].Substring(1, ContentsLine[49].Length - 2);
                    hd.SoDHN = ContentsLine[50].Substring(1, ContentsLine[50].Length - 2);
                    hd.MSThue = ContentsLine[51].Substring(1, ContentsLine[51].Length - 2);
                    hd.TileTieuThu = ContentsLine[52].Substring(1, ContentsLine[52].Length - 2);
                    hd.NgayGanDHN = ContentsLine[53].Substring(1, ContentsLine[53].Length - 2);
                    hd.SoHo = ContentsLine[54].Substring(1, ContentsLine[54].Length - 2);
                    
                    db.HoaDons.InsertOnSubmit(hd);
                }
                db.SubmitChanges();
                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
    }
}

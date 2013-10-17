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
    class CTTKH
    {
        DB_KTKS_DonKHDataContext db = new DB_KTKS_DonKHDataContext();

        public void CapNhatTTKH(string pathFile)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    db.TTKhachHangs.DeleteAllOnSubmit(db.TTKhachHangs);
                    string[] lines = File.ReadAllLines(pathFile);
                    foreach (string line in lines)
                    {
                        string[] ContentsLine = line.Split(',');
                        TTKhachHang ttkhachhang = new TTKhachHang();
                        ttkhachhang.Khu = ContentsLine[0].Substring(1, ContentsLine[0].Length - 2);
                        ttkhachhang.Dot = ContentsLine[1].Substring(1, ContentsLine[1].Length - 2);
                        ttkhachhang.DanhBo = ContentsLine[2].Substring(1, ContentsLine[2].Length - 2);
                        ttkhachhang.CD = ContentsLine[3].Substring(1, ContentsLine[3].Length - 2);
                        ttkhachhang.CuLy = ContentsLine[4].Substring(1, ContentsLine[4].Length - 2);
                        ttkhachhang.MSTLK = ContentsLine[5].Substring(1, ContentsLine[5].Length - 2);
                        ttkhachhang.GiaoUoc = ContentsLine[6].Substring(1, ContentsLine[6].Length - 2);
                        ttkhachhang.HoTen = ContentsLine[7].Substring(1, ContentsLine[7].Length - 2);
                        ttkhachhang.DC1 = ContentsLine[8].Substring(1, ContentsLine[8].Length - 2);
                        ttkhachhang.DC2 = ContentsLine[9].Substring(1, ContentsLine[9].Length - 2);
                        ttkhachhang.MSKH = ContentsLine[10].Substring(1, ContentsLine[10].Length - 2);
                        ttkhachhang.MSCQ = ContentsLine[11].Substring(1, ContentsLine[11].Length - 2);
                        ttkhachhang.GB = ContentsLine[12].Substring(1, ContentsLine[12].Length - 2);
                        ttkhachhang.SH = ContentsLine[13].Substring(1, ContentsLine[13].Length - 2);
                        ttkhachhang.HCSN = ContentsLine[14].Substring(1, ContentsLine[14].Length - 2);
                        ttkhachhang.SX = ContentsLine[15].Substring(1, ContentsLine[15].Length - 2);
                        ttkhachhang.DV = ContentsLine[16].Substring(1, ContentsLine[16].Length - 2);
                        ttkhachhang.TGDM = ContentsLine[17].Substring(1, ContentsLine[17].Length - 2);
                        ttkhachhang.Ky = ContentsLine[18].Substring(1, ContentsLine[18].Length - 2);
                        ttkhachhang.Nam = ContentsLine[19].Substring(1, ContentsLine[19].Length - 2);
                        ttkhachhang.Code = ContentsLine[20].Substring(1, ContentsLine[20].Length - 2);
                        ttkhachhang.CodeFu = ContentsLine[21].Substring(1, ContentsLine[21].Length - 2);
                        ttkhachhang.CSCu = ContentsLine[22].Substring(1, ContentsLine[22].Length - 2);
                        ttkhachhang.CSMoi = ContentsLine[23].Substring(1, ContentsLine[23].Length - 2);
                        ttkhachhang.RT = ContentsLine[24].Substring(1, ContentsLine[24].Length - 2);
                        ttkhachhang.NgayDSKT = ContentsLine[25].Substring(1, ContentsLine[25].Length - 2);
                        ttkhachhang.NgayDSKN = ContentsLine[26].Substring(1, ContentsLine[26].Length - 2);
                        ttkhachhang.ChuKyDS = ContentsLine[27].Substring(1, ContentsLine[27].Length - 2);
                        ttkhachhang.LNCC = ContentsLine[28].Substring(1, ContentsLine[28].Length - 2);
                        ttkhachhang.LNCT = ContentsLine[29].Substring(1, ContentsLine[29].Length - 2);
                        ttkhachhang.LNBuToiThieu = ContentsLine[30].Substring(1, ContentsLine[30].Length - 2);
                        ttkhachhang.LNSH = ContentsLine[31].Substring(1, ContentsLine[31].Length - 2);
                        ttkhachhang.LNHCSN = ContentsLine[32].Substring(1, ContentsLine[32].Length - 2);
                        ttkhachhang.LNSX = ContentsLine[33].Substring(1, ContentsLine[33].Length - 2);
                        ttkhachhang.LNDV = ContentsLine[34].Substring(1, ContentsLine[34].Length - 2);
                        ttkhachhang.CuonGCS = ContentsLine[35].Substring(1, ContentsLine[35].Length - 2);
                        ttkhachhang.CuonSTT = ContentsLine[36].Substring(1, ContentsLine[36].Length - 2);
                        ttkhachhang.GiaBan = ContentsLine[37].Substring(1, ContentsLine[37].Length - 2);
                        ttkhachhang.ThueGTGT = ContentsLine[38].Substring(1, ContentsLine[38].Length - 2);
                        ttkhachhang.PhiBVMT = ContentsLine[39].Substring(1, ContentsLine[39].Length - 2);
                        ttkhachhang.TongCong = ContentsLine[40].Substring(1, ContentsLine[40].Length - 2);
                        ttkhachhang.GiaBanBuToiThieu = ContentsLine[41].Substring(1, ContentsLine[41].Length - 2);
                        ttkhachhang.ThueGTGTBuToiThieu = ContentsLine[42].Substring(1, ContentsLine[42].Length - 2);
                        ttkhachhang.PhiBVMTBuToiThieu = ContentsLine[43].Substring(1, ContentsLine[43].Length - 2);
                        ttkhachhang.TongCongBuToiThieu = ContentsLine[44].Substring(1, ContentsLine[44].Length - 2);
                        ttkhachhang.SoPhatHanh = ContentsLine[45].Substring(1, ContentsLine[45].Length - 2);
                        ttkhachhang.SoHoaDon = ContentsLine[46].Substring(1, ContentsLine[46].Length - 2);
                        ttkhachhang.NgayPhatHanh = ContentsLine[47].Substring(1, ContentsLine[47].Length - 2);
                        ttkhachhang.Quan = ContentsLine[48].Substring(1, ContentsLine[48].Length - 2);
                        ttkhachhang.Phuong = ContentsLine[49].Substring(1, ContentsLine[49].Length - 2);
                        ttkhachhang.SoDHN = ContentsLine[50].Substring(1, ContentsLine[50].Length - 2);
                        ttkhachhang.MSThue = ContentsLine[51].Substring(1, ContentsLine[51].Length - 2);
                        ttkhachhang.TileTieuThu = ContentsLine[52].Substring(1, ContentsLine[52].Length - 2);
                        ttkhachhang.NgayGanDHN = ContentsLine[53].Substring(1, ContentsLine[53].Length - 2);
                        ttkhachhang.SoHo = ContentsLine[54].Substring(1, ContentsLine[54].Length - 2);

                        db.TTKhachHangs.InsertOnSubmit(ttkhachhang);
                    }
                    db.SubmitChanges();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public TTKhachHang getTTKHbyID(string DanhBo)
        {
            try
            {
                return db.TTKhachHangs.Single(itemTTKH => itemTTKH.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
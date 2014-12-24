using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;

namespace ThuTien.DAL.Doi
{
    class CHoaDon : CDAL
    {
        public bool Them(string path)
        {
            try
            {
                this.BeginTransaction();
                string[] lines = System.IO.File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] contents = line.Split(',');
                    HoaDon hoadon = new HoaDon();
                    if (!string.IsNullOrWhiteSpace(contents[0].Replace("\"", "")))
                        hoadon.Khu = int.Parse(contents[0].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[1].Replace("\"", "")))
                        hoadon.Dot = contents[1].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[2].Replace("\"", "")))
                        hoadon.DanhBo = contents[2].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[3].Replace("\"", "")))
                        hoadon.CD = int.Parse(contents[3].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[4].Replace("\"", "")))
                        hoadon.CuLy = int.Parse(contents[4].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[5].Replace("\"", "")))
                        hoadon.MSTLK = contents[5].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[6].Replace("\"", "")))
                        hoadon.HopDong = contents[6].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[7].Replace("\"", "")))
                        hoadon.HoTen = contents[7].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[8].Replace("\"", "")))
                        hoadon.DC1 = contents[8].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[9].Replace("\"", "")))
                        hoadon.DC2 = contents[9].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[10].Replace("\"", "")))
                        hoadon.MSKH = contents[10].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[11].Replace("\"", "")))
                        hoadon.MSCQ = contents[11].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[12].Replace("\"", "")))
                        hoadon.GB = int.Parse(contents[12].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[13].Replace("\"", "")))
                        hoadon.SH = int.Parse(contents[13].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[14].Replace("\"", "")))
                        hoadon.HCSN = int.Parse(contents[14].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[15].Replace("\"", "")))
                        hoadon.SX = int.Parse(contents[15].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[16].Replace("\"", "")))
                        hoadon.DV = int.Parse(contents[16].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[17].Replace("\"", "")))
                        hoadon.DM = int.Parse(contents[17].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[18].Replace("\"", "")))
                        hoadon.Ky = int.Parse(contents[18].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[19].Replace("\"", "")))
                        hoadon.Nam = int.Parse(contents[19].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[20].Replace("\"", "")))
                        hoadon.Code = contents[20].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[21].Replace("\"", "")))
                        hoadon.CodeFu = contents[21].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[22].Replace("\"", "")))
                        hoadon.CSCu = int.Parse(contents[22].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[23].Replace("\"", "")))
                        hoadon.CSMoi = int.Parse(contents[23].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[24].Replace("\"", "")))
                        hoadon.RT = contents[24].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[25].Replace("\"", "")))
                        hoadon.NgayDSKT = DateTime.ParseExact(contents[25].Replace("\"", ""), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    if (!string.IsNullOrWhiteSpace(contents[26].Replace("\"", "")))
                        hoadon.NgayDSKN = DateTime.ParseExact(contents[26].Replace("\"", ""), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    if (!string.IsNullOrWhiteSpace(contents[27].Replace("\"", "")))
                        hoadon.ChuKyDS = int.Parse(contents[27].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[28].Replace("\"", "")))
                        hoadon.LNCC = int.Parse(contents[28].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[29].Replace("\"", "")))
                        hoadon.LNCT = int.Parse(contents[29].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[30].Replace("\"", "")))
                        hoadon.LNBuToiThieu = int.Parse(contents[30].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[31].Replace("\"", "")))
                        hoadon.LNSH = int.Parse(contents[31].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[32].Replace("\"", "")))
                        hoadon.LNHCSN = int.Parse(contents[32].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[33].Replace("\"", "")))
                        hoadon.LNSX = int.Parse(contents[33].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[34].Replace("\"", "")))
                        hoadon.LNDV = int.Parse(contents[34].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[35].Replace("\"", "")))
                        hoadon.CuonGCS = contents[35].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[36].Replace("\"", "")))
                        hoadon.CuonSTT = contents[36].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[37].Replace("\"", "")))
                        hoadon.GiaBan = int.Parse(contents[37].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[38].Replace("\"", "")))
                        hoadon.ThueGTGT = int.Parse(contents[38].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[39].Replace("\"", "")))
                        hoadon.PhiBVMT = int.Parse(contents[39].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[40].Replace("\"", "")))
                        hoadon.TongCong = int.Parse(contents[40].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[41].Replace("\"", "")))
                        hoadon.GiaBanBuToiThieu = int.Parse(contents[41].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[42].Replace("\"", "")))
                        hoadon.ThueGTGTBuToiThieu = int.Parse(contents[42].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[43].Replace("\"", "")))
                        hoadon.PhiBVMTBuToiThieu = int.Parse(contents[43].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[44].Replace("\"", "")))
                        hoadon.TongCongBuToiThieu = int.Parse(contents[44].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[45].Replace("\"", "")))
                        hoadon.SoPhatHanh = contents[45].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[46].Replace("\"", "")))
                        hoadon.SoHoaDon = contents[46].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[47].Replace("\"", "")))
                        hoadon.NgayPhatHanh = DateTime.Parse(contents[47].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[48].Replace("\"", "")))
                        hoadon.Quan = int.Parse(contents[48].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[49].Replace("\"", "")))
                        hoadon.Phuong = int.Parse(contents[49].Replace("\"", ""));
                    if (!string.IsNullOrWhiteSpace(contents[50].Replace("\"", "")))
                        hoadon.SoDHN = contents[50].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[51].Replace("\"", "")))
                        hoadon.MSThue = contents[51].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[52].Replace("\"", "")))
                        hoadon.TileTieuThu = contents[52].Replace("\"", "");
                    if (!string.IsNullOrWhiteSpace(contents[53].Replace("\"", "")))
                        hoadon.NgayGanDHN = DateTime.ParseExact(contents[53].Replace("\"", ""), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    if (!string.IsNullOrWhiteSpace(contents[54].Replace("\"", "")))
                        hoadon.SoHo = contents[54].Replace("\"", "");
                    hoadon.CreateBy = CNguoiDung.MaND;
                    hoadon.CreateDate = DateTime.Now;

                    _db.HoaDons.InsertOnSubmit(hoadon);
                }
                _db.SubmitChanges();
                this.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                this.Rollback();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }
    }
}

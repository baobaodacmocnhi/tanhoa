using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

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
                    string lineR = line.Replace("\",\"", "$").Replace("\"", "");
                    string[] contents = lineR.Split('$');
                    //string[] contents = System.Text.RegularExpressions.Regex.Split(line, @"\W+");
                    HoaDon hoadon = new HoaDon();
                    if (!string.IsNullOrWhiteSpace(contents[0]))
                        hoadon.Khu = int.Parse(contents[0]);
                    if (!string.IsNullOrWhiteSpace(contents[1]))
                        hoadon.Dot = int.Parse(contents[1]);
                    if (!string.IsNullOrWhiteSpace(contents[2]))
                        hoadon.DanhBo = contents[2];
                    if (!string.IsNullOrWhiteSpace(contents[3]))
                        hoadon.CD = int.Parse(contents[3]);
                    if (!string.IsNullOrWhiteSpace(contents[4]))
                        hoadon.CuLy = int.Parse(contents[4]);
                    if (!string.IsNullOrWhiteSpace(contents[5]))
                        hoadon.MSTLK = contents[5];
                    if (!string.IsNullOrWhiteSpace(contents[6]))
                        hoadon.HopDong = contents[6];
                    if (!string.IsNullOrWhiteSpace(contents[7]))
                        hoadon.HoTen = contents[7];
                    if (!string.IsNullOrWhiteSpace(contents[8]))
                        hoadon.DC1 = contents[8];
                    if (!string.IsNullOrWhiteSpace(contents[9]))
                        hoadon.DC2 = contents[9];
                    if (!string.IsNullOrWhiteSpace(contents[10]))
                        hoadon.MSKH = contents[10];
                    if (!string.IsNullOrWhiteSpace(contents[11]))
                        hoadon.MSCQ = contents[11];
                    if (!string.IsNullOrWhiteSpace(contents[12]))
                        hoadon.GB = int.Parse(contents[12]);
                    if (!string.IsNullOrWhiteSpace(contents[13]))
                        hoadon.SH = int.Parse(contents[13]);
                    if (!string.IsNullOrWhiteSpace(contents[14]))
                        hoadon.HCSN = int.Parse(contents[14]);
                    if (!string.IsNullOrWhiteSpace(contents[15]))
                        hoadon.SX = int.Parse(contents[15]);
                    if (!string.IsNullOrWhiteSpace(contents[16]))
                        hoadon.DV = int.Parse(contents[16]);
                    if (!string.IsNullOrWhiteSpace(contents[17]))
                        hoadon.DM = int.Parse(contents[17]);
                    if (!string.IsNullOrWhiteSpace(contents[18]))
                        hoadon.Ky = int.Parse(contents[18]);
                    if (!string.IsNullOrWhiteSpace(contents[19]))
                        hoadon.Nam = int.Parse(contents[19]);
                    if (!string.IsNullOrWhiteSpace(contents[20]))
                        hoadon.Code = contents[20];
                    if (!string.IsNullOrWhiteSpace(contents[21]))
                        hoadon.CodeFu = contents[21];
                    if (!string.IsNullOrWhiteSpace(contents[22]))
                        hoadon.CSCu = int.Parse(contents[22]);
                    if (!string.IsNullOrWhiteSpace(contents[23]))
                        hoadon.CSMoi = int.Parse(contents[23]);
                    if (!string.IsNullOrWhiteSpace(contents[24]))
                        hoadon.RT = contents[24];
                    if (!string.IsNullOrWhiteSpace(contents[25]))
                        hoadon.NgayDSKT = DateTime.ParseExact(contents[25], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    if (!string.IsNullOrWhiteSpace(contents[26]))
                        hoadon.NgayDSKN = DateTime.ParseExact(contents[26], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    if (!string.IsNullOrWhiteSpace(contents[27]))
                        hoadon.ChuKyDS = int.Parse(contents[27]);
                    if (!string.IsNullOrWhiteSpace(contents[28]))
                        hoadon.LNCC = int.Parse(contents[28]);
                    if (!string.IsNullOrWhiteSpace(contents[29]))
                        hoadon.LNCT = int.Parse(contents[29]);
                    if (!string.IsNullOrWhiteSpace(contents[30]))
                        hoadon.LNBuToiThieu = int.Parse(contents[30]);
                    if (!string.IsNullOrWhiteSpace(contents[31]))
                        hoadon.LNSH = int.Parse(contents[31]);
                    if (!string.IsNullOrWhiteSpace(contents[32]))
                        hoadon.LNHCSN = int.Parse(contents[32]);
                    if (!string.IsNullOrWhiteSpace(contents[33]))
                        hoadon.LNSX = int.Parse(contents[33]);
                    if (!string.IsNullOrWhiteSpace(contents[34]))
                        hoadon.LNDV = int.Parse(contents[34]);
                    if (!string.IsNullOrWhiteSpace(contents[35]))
                        hoadon.CuonGCS = contents[35];
                    if (!string.IsNullOrWhiteSpace(contents[36]))
                        hoadon.CuonSTT = contents[36];
                    if (!string.IsNullOrWhiteSpace(contents[37]))
                        hoadon.GiaBan = int.Parse(contents[37]);
                    if (!string.IsNullOrWhiteSpace(contents[38]))
                        hoadon.ThueGTGT = int.Parse(contents[38]);
                    if (!string.IsNullOrWhiteSpace(contents[39]))
                        hoadon.PhiBVMT = int.Parse(contents[39]);
                    if (!string.IsNullOrWhiteSpace(contents[40]))
                        hoadon.TongCong = int.Parse(contents[40]);
                    if (!string.IsNullOrWhiteSpace(contents[41]))
                        hoadon.GiaBanBuToiThieu = int.Parse(contents[41]);
                    if (!string.IsNullOrWhiteSpace(contents[42]))
                        hoadon.ThueGTGTBuToiThieu = int.Parse(contents[42]);
                    if (!string.IsNullOrWhiteSpace(contents[43]))
                        hoadon.PhiBVMTBuToiThieu = int.Parse(contents[43]);
                    if (!string.IsNullOrWhiteSpace(contents[44]))
                        hoadon.TongCongBuToiThieu = int.Parse(contents[44]);
                    if (!string.IsNullOrWhiteSpace(contents[45]))
                        hoadon.SoPhatHanh = int.Parse(contents[45]);
                    if (!string.IsNullOrWhiteSpace(contents[46]))
                        hoadon.SoHoaDon = contents[46];
                    if (!string.IsNullOrWhiteSpace(contents[47]))
                        hoadon.NgayPhatHanh = DateTime.Parse(contents[47]);
                    if (!string.IsNullOrWhiteSpace(contents[48]))
                        hoadon.Quan = int.Parse(contents[48]);
                    if (!string.IsNullOrWhiteSpace(contents[49]))
                        hoadon.Phuong = int.Parse(contents[49]);
                    if (!string.IsNullOrWhiteSpace(contents[50]))
                        hoadon.SoDHN = contents[50];
                    if (!string.IsNullOrWhiteSpace(contents[51]))
                        hoadon.MSThue = contents[51];
                    if (!string.IsNullOrWhiteSpace(contents[52]))
                        hoadon.TileTieuThu = contents[52];
                    if (!string.IsNullOrWhiteSpace(contents[53]))
                        hoadon.NgayGanDHN = DateTime.ParseExact(contents[53], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    if (!string.IsNullOrWhiteSpace(contents[54]))
                        hoadon.SoHo = contents[54];
                    hoadon.CreateBy = CNguoiDung.MaND;
                    hoadon.CreateDate = DateTime.Now;

                    if (CheckByNamKyDot(hoadon.Nam.Value, hoadon.Ky.Value, hoadon.Dot.Value))
                    {
                        this.Rollback();
                        System.Windows.Forms.MessageBox.Show("Năm " + hoadon.Nam.Value + "; Kỳ " + hoadon.Ky.Value + "; Đợt " + hoadon.Dot.Value + " đã có rồi", "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return false;
                    }

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

        public bool CheckByNamKyDot(int nam, int ky, int dot)
        {
            return _db.HoaDons.Any(item => item.Nam == nam && item.Ky == ky && item.Dot == dot);
        }

        public DataTable GetNam()
        {
            return this.LINQToDataTable(_db.HoaDons.Select(item => new { item.Nam }).Distinct().OrderByDescending(item => item.Nam).ToList());
        }

        public DataTable GetTongHDByNamKy(int nam, int ky)
        {
            var query = from item in _db.HoaDons
                        where item.Nam == nam && item.Ky == ky
                        group item by item.Dot into itemGroup
                        select new
                        {
                            Dot= itemGroup.Key,
                            TongHD = itemGroup.Count(),
                            TongLNCC = itemGroup.Sum(groupItem => groupItem.LNCC),
                            TongGiaBan = itemGroup.Sum(groupItem => groupItem.GiaBan),
                            TongThueGTGT = itemGroup.Sum(groupItem => groupItem.ThueGTGT),
                            TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PhiBVMT),
                            TongCong = itemGroup.Sum(groupItem => groupItem.TongCong),
                        };
            return this.LINQToDataTable(query.OrderBy(item=>item.Dot));
        }
    }

}
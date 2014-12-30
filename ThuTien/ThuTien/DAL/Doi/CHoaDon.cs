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
                    HOADON hoadon = new HOADON();
                    //if (!string.IsNullOrWhiteSpace(contents[0]))
                    //    hoadon.Khu = int.Parse(contents[0]);
                    if (!string.IsNullOrWhiteSpace(contents[1]))
                        hoadon.DOT = int.Parse(contents[1]);
                    if (!string.IsNullOrWhiteSpace(contents[2]))
                        hoadon.DANHBA = contents[2];
                    //if (!string.IsNullOrWhiteSpace(contents[3]))
                    //    hoadon.CD = int.Parse(contents[3]);
                    //if (!string.IsNullOrWhiteSpace(contents[4]))
                    //    hoadon.CuLy = int.Parse(contents[4]);
                    //if (!string.IsNullOrWhiteSpace(contents[5]))
                    //    hoadon.MSTLK = contents[5];
                    if (!string.IsNullOrWhiteSpace(contents[6]))
                        hoadon.HOPDONG = contents[6];
                    if (!string.IsNullOrWhiteSpace(contents[7]))
                        hoadon.TENKH = contents[7];
                    if (!string.IsNullOrWhiteSpace(contents[8]))
                        hoadon.SO = contents[8];
                    if (!string.IsNullOrWhiteSpace(contents[9]))
                        hoadon.DUONG = contents[9];
                    //if (!string.IsNullOrWhiteSpace(contents[10]))
                    //    hoadon.MSKH = contents[10];
                    //if (!string.IsNullOrWhiteSpace(contents[11]))
                    //    hoadon.MSCQ = contents[11];
                    if (!string.IsNullOrWhiteSpace(contents[12]))
                        hoadon.GB = int.Parse(contents[12]);
                    if (!string.IsNullOrWhiteSpace(contents[13]))
                        hoadon.TILESH = int.Parse(contents[13]);
                    if (!string.IsNullOrWhiteSpace(contents[14]))
                        hoadon.TILEHCSN = int.Parse(contents[14]);
                    if (!string.IsNullOrWhiteSpace(contents[15]))
                        hoadon.TILESX = int.Parse(contents[15]);
                    if (!string.IsNullOrWhiteSpace(contents[16]))
                        hoadon.TILEDV = int.Parse(contents[16]);
                    if (!string.IsNullOrWhiteSpace(contents[17]))
                        hoadon.DM = int.Parse(contents[17]);
                    if (!string.IsNullOrWhiteSpace(contents[18]))
                        hoadon.KY = int.Parse(contents[18]);
                    if (!string.IsNullOrWhiteSpace(contents[19]))
                        hoadon.NAM = int.Parse(contents[19]);
                    if (!string.IsNullOrWhiteSpace(contents[20]))
                        hoadon.CODE = contents[20];
                    //if (!string.IsNullOrWhiteSpace(contents[21]))
                    //    hoadon.CodeFu = contents[21];
                    if (!string.IsNullOrWhiteSpace(contents[22]))
                        hoadon.CSCU = int.Parse(contents[22]);
                    if (!string.IsNullOrWhiteSpace(contents[23]))
                        hoadon.CSMOI = int.Parse(contents[23]);
                    //if (!string.IsNullOrWhiteSpace(contents[24]))
                    //    hoadon.RT = contents[24];
                    if (!string.IsNullOrWhiteSpace(contents[25]))
                        hoadon.TUNGAY = DateTime.ParseExact(contents[25], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    if (!string.IsNullOrWhiteSpace(contents[26]))
                        hoadon.DENNGAY = DateTime.ParseExact(contents[26], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    if (!string.IsNullOrWhiteSpace(contents[27]))
                        hoadon.SONGAY = int.Parse(contents[27]);
                    if (!string.IsNullOrWhiteSpace(contents[28]))
                        hoadon.TIEUTHU = int.Parse(contents[28]);
                    //if (!string.IsNullOrWhiteSpace(contents[29]))
                    //    hoadon.LNCT = int.Parse(contents[29]);
                    if (!string.IsNullOrWhiteSpace(contents[30]))
                        hoadon.TIEUTHUBU = int.Parse(contents[30]);
                    if (!string.IsNullOrWhiteSpace(contents[31]))
                        hoadon.TILESH = int.Parse(contents[31]);
                    if (!string.IsNullOrWhiteSpace(contents[32]))
                        hoadon.TILEHCSN = int.Parse(contents[32]);
                    if (!string.IsNullOrWhiteSpace(contents[33]))
                        hoadon.TILESX = int.Parse(contents[33]);
                    if (!string.IsNullOrWhiteSpace(contents[34]))
                        hoadon.TILEDV = int.Parse(contents[34]);
                    if (!string.IsNullOrWhiteSpace(contents[35]))
                        hoadon.MAY = contents[35];
                    if (!string.IsNullOrWhiteSpace(contents[36]))
                        hoadon.STT = contents[36];
                    if (!string.IsNullOrWhiteSpace(contents[37]))
                        hoadon.GIABAN = int.Parse(contents[37]);
                    if (!string.IsNullOrWhiteSpace(contents[38]))
                        hoadon.THUE = int.Parse(contents[38]);
                    if (!string.IsNullOrWhiteSpace(contents[39]))
                        hoadon.PHI = int.Parse(contents[39]);
                    if (!string.IsNullOrWhiteSpace(contents[40]))
                        hoadon.TONGCONG = int.Parse(contents[40]);
                    if (!string.IsNullOrWhiteSpace(contents[41]))
                        hoadon.GIABAN_BU = int.Parse(contents[41]);
                    if (!string.IsNullOrWhiteSpace(contents[42]))
                        hoadon.THUE_BU = int.Parse(contents[42]);
                    if (!string.IsNullOrWhiteSpace(contents[43]))
                        hoadon.PHI_BU = int.Parse(contents[43]);
                    if (!string.IsNullOrWhiteSpace(contents[44]))
                        hoadon.TONGCONG_BU = int.Parse(contents[44]);
                    if (!string.IsNullOrWhiteSpace(contents[45]))
                        hoadon.SOPHATHANH = int.Parse(contents[45]);
                    if (!string.IsNullOrWhiteSpace(contents[46]))
                        hoadon.SOHOADON = contents[46];
                    //if (!string.IsNullOrWhiteSpace(contents[47]))
                    //    hoadon.NgayPhatHanh = DateTime.Parse(contents[47]);
                    //if (!string.IsNullOrWhiteSpace(contents[48]))
                    //    hoadon.Quan = int.Parse(contents[48]);
                    //if (!string.IsNullOrWhiteSpace(contents[49]))
                    //    hoadon.Phuong = int.Parse(contents[49]);
                    //if (!string.IsNullOrWhiteSpace(contents[50]))
                    //    hoadon.SoDHN = contents[50];
                    if (!string.IsNullOrWhiteSpace(contents[51]))
                        hoadon.MST = contents[51];
                    //if (!string.IsNullOrWhiteSpace(contents[52]))
                    //    hoadon.TileTieuThu = contents[52];
                    //if (!string.IsNullOrWhiteSpace(contents[53]))
                    //    hoadon.NgayGanDHN = DateTime.ParseExact(contents[53], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    //if (!string.IsNullOrWhiteSpace(contents[54]))
                    //    hoadon.SoHo = contents[54];
                    hoadon.CreateBy = CNguoiDung.MaND;
                    hoadon.CreateDate = DateTime.Now;
                    hoadon.MALOTRINH = hoadon.DOT.Value.ToString("00") + hoadon.MAY + hoadon.STT;
                    if (CheckByNamKyDot(hoadon.NAM.Value, hoadon.KY, hoadon.DOT.Value))
                    {
                        this.Rollback();
                        System.Windows.Forms.MessageBox.Show("Năm " + hoadon.NAM.Value + "; Kỳ " + hoadon.KY + "; Đợt " + hoadon.DOT.Value + " đã có rồi", "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return false;
                    }

                    _db.HOADONs.InsertOnSubmit(hoadon);
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

        public bool ThemChia(List<HOADON> lstHD)
        {
            try
            {
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool TestThemChia(int MaTo, string tumlt, string denmlt, int nam, int ky, int dot,int MaNV)
        {
            try
            {
                _db.HOADONs.Where(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && Convert.ToInt32(item.MALOTRINH) >= int.Parse(tumlt) && Convert.ToInt32(item.MALOTRINH) <= int.Parse(denmlt) && item.NAM == nam && item.KY == ky && item.DOT == dot).ToList()
                                    .ForEach(item => item.MaNV_HanhThu = MaNV);
                _db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaChia(List<HOADON> lstHD)
        {
            try
            {
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckByNamKyDot(int nam, int ky, int dot)
        {
            return _db.HOADONs.Any(item => item.NAM == nam && item.KY == ky && item.DOT == dot);
        }

        public DataTable GetNam()
        {
            //return this.LINQToDataTable(_db.HOADONs.Select(item => new { item.NAM }).Distinct().OrderByDescending(item => item.NAM).ToList());
            return this.LINQToDataTable(_db.ViewGetNamHDs.OrderByDescending(item=>item.Nam));
        }

        public DataTable GetTongHDByNamKy(int nam, int ky)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == nam && item.KY == ky
                        orderby item.DOT ascending
                        group item by item.DOT into itemGroup
                        select new
                        {
                            Dot= itemGroup.Key,
                            TongHD = itemGroup.Count(),
                            TongLNCC = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                            TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                            TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                            TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                            TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                        };
            return this.LINQToDataTable(query);
        }

        public DataTable GetDSChiaByNamKyDot(int MaTo, string loai, int nam, int ky, int dot)
        {
            if (loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB>=11 && item.GB<=20 
                                    && Convert.ToInt32(item.MAY) >=_db.TT_Tos.SingleOrDefault(itemTo=>itemTo.MaTo==MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            orderby item.MALOTRINH
                            group item by item.MaNV_HanhThu into itemGroup
                            select new
                            {
                                MaNV = itemGroup.Key,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND=>itemND.MaND==itemGroup.Key).HoTen,
                                TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                                DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                                TuSHD = itemGroup.Min(groupItem => groupItem.SOHOADON),
                                DenSHD = itemGroup.Max(groupItem => groupItem.SOHOADON),
                                TongHD = itemGroup.Count(),
                                TongLNCC = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                            };
                return this.LINQToDataTable(query.OrderBy(item=>item.TuMLT));
            }
            else
                if (loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB>20
                                group item by item.MaNV_HanhThu into itemGroup
                                select new
                                {
                                    Dot = itemGroup.Key,
                                    TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                                    DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                                    TuSHD = itemGroup.Min(groupItem => groupItem.SOHOADON),
                                    DenSHD = itemGroup.Max(groupItem => groupItem.SOHOADON),
                                    TongHD = itemGroup.Count(),
                                    TongLNCC = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                                    TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                    TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                    TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                    TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                };
                    return this.LINQToDataTable(query);
                }
            return null;
        }

        public bool CheckMLTByNamKyDot(int MaTo, string mlt, int nam, int ky, int dot)
        {
            return _db.HOADONs.Any(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS 
                                    && item.MALOTRINH == mlt && item.NAM == nam && item.KY == ky && item.DOT == dot);
        }

        public List<HOADON> GetDSByMLTNamKyDot(int MaTo, string tumlt, string denmlt, int nam, int ky, int dot)
        {
            return _db.HOADONs.Where(item =>Convert.ToInt32(item.MAY) >=_db.TT_Tos.SingleOrDefault(itemTo=>itemTo.MaTo==MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && Convert.ToInt32(item.MALOTRINH) >= int.Parse(tumlt) && Convert.ToInt32(item.MALOTRINH) <= int.Parse(denmlt) && item.NAM == nam && item.KY == ky && item.DOT == dot).ToList();
        }
    }

}
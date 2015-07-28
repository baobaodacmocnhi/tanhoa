using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;
using System.Globalization;

namespace ThuTien.DAL.Doi
{
    class CHoaDon : CDAL
    {
        /// <summary>
        /// Thêm hóa đơn mới từ billing (.dat)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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
                        hoadon.NAM = int.Parse("20" + contents[19]);
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
                    //if (CheckByNamKyDot(hoadon.NAM.Value, hoadon.KY, hoadon.DOT.Value))
                    //{
                    //    this.Rollback();
                    //    System.Windows.Forms.MessageBox.Show("Năm " + hoadon.NAM.Value + "; Kỳ " + hoadon.KY + "; Đợt " + hoadon.DOT.Value + " đã có rồi", "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    //    return false;
                    //}
                    if (_db.HOADONs.Any(item => item.SOHOADON == hoadon.SOHOADON))
                        _db.ExecuteCommand("update HOADON set HOPDONG='" + hoadon.HOPDONG + "',GB=" + hoadon.GB.Value + ",DM=" + hoadon.DM.Value + ",CODE='" + hoadon.CODE + "',CSCU=" + hoadon.CSCU.Value + ",CSMOI=" + hoadon.CSMOI.Value + ",TIEUTHU=" + hoadon.TIEUTHU.Value + ",GIABAN=" + hoadon.GIABAN.Value + ",THUE=" + hoadon.THUE.Value + ",PHI=" + hoadon.PHI.Value + ",TONGCONG=" + hoadon.TONGCONG.Value + ",SOPHATHANH='" + hoadon.SOPHATHANH + "',SOHOADON='" + hoadon.SOHOADON + "' where NAM=" + hoadon.NAM.Value + " and KY=" + hoadon.KY + " and DOT=" + hoadon.DOT.Value);
                    else
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

        /// <summary>
        /// Chia hóa đơn cho anh/em đi thu
        /// </summary>
        /// <param name="MaTo"></param>
        /// <param name="loai"></param>
        /// <param name="tusophathanh"></param>
        /// <param name="densophathanh"></param>
        /// <param name="nam"></param>
        /// <param name="ky"></param>
        /// <param name="dot"></param>
        /// <param name="MaNV"></param>
        /// <returns></returns>
        public bool ThemChia(string Loai, int MaTo, int DotChia, decimal TuSoPhatHanh, decimal DenSoPhatHanh, int Nam, int Ky, int Dot, int MaNV)
        {
            try
            {
                if (Loai == "TG")
                {
                    //_db.HOADONs.Where(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                    //                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                    //                    && Convert.ToInt32(item.MALOTRINH) >= int.Parse(tumlt) && Convert.ToInt32(item.MALOTRINH) <= int.Parse(denmlt)
                    //                    && item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB >= 11 && item.GB <= 20).ToList()
                    //                    .ForEach(item => { item.MaNV_HanhThu = MaNV; item.ModifyBy = CNguoiDung.MaND; item.ModifyDate = DateTime.Now; });
                    string sql = "update HOADON set MaNV_HanhThu=" + MaNV + ",DOTCHIA=" + DotChia + ",NGAYGIAO='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                        + "where SOPHATHANH>='" + TuSoPhatHanh + "' and SOPHATHANH<='" + DenSoPhatHanh + "' and NAM=" + Nam + " and KY=" + Ky + " and DOT=" + Dot + " and GB>=11 and GB<=20 "
                        + "and MAY>=" + ExecuteQuery_SqlDataReader_DataTable("select TuCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + " and MAY<=" + ExecuteQuery_SqlDataReader_DataTable("select DenCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + "";
                    ExecuteNonQuery(sql, true);
                }
                else
                    if (Loai == "CQ")
                    {
                        //_db.HOADONs.Where(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                        //            && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        //            && Convert.ToInt32(item.MALOTRINH) >= int.Parse(tumlt) && Convert.ToInt32(item.MALOTRINH) <= int.Parse(denmlt)
                        //            && item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB > 20).ToList()
                        //            .ForEach(item => { item.MaNV_HanhThu = MaNV; item.ModifyBy = CNguoiDung.MaND; item.ModifyDate = DateTime.Now; });
                        string sql = "update HOADON set MaNV_HanhThu=" + MaNV + ",DOTCHIA=" + DotChia + ",NGAYGIAO='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                        + "where SOPHATHANH>='" + TuSoPhatHanh + "' and SOPHATHANH<='" + DenSoPhatHanh + "' and NAM=" + Nam + " and KY=" + Ky + " and DOT=" + Dot + " and GB>20 "
                        + "and MAY>=" + ExecuteQuery_SqlDataReader_DataTable("select TuCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + " and MAY<=" + ExecuteQuery_SqlDataReader_DataTable("select DenCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + "";
                        ExecuteNonQuery(sql, true);
                    }
                //_db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(HOADON hoadon)
        {
            try
            {
                hoadon.ModifyDate = DateTime.Now;
                hoadon.ModifyBy = CNguoiDung.MaND;
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

        /// <summary>
        /// Xóa hóa đơn đã chi cho anh/em đi thu
        /// </summary>
        /// <param name="MaTo"></param>
        /// <param name="loai"></param>
        /// <param name="tusophathanh"></param>
        /// <param name="densophathanh"></param>
        /// <param name="nam"></param>
        /// <param name="ky"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        public bool XoaChia(string Loai, int MaTo, decimal TuSoPhatHanh, decimal DenSoPhatHanh, int Nam, int Ky, int Dot)
        {
            try
            {
                if (Loai == "TG")
                {
                    //_db.HOADONs.Where(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                    //                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                    //                    && Convert.ToInt32(item.MALOTRINH) >= int.Parse(tumlt) && Convert.ToInt32(item.MALOTRINH) <= int.Parse(denmlt)
                    //                    && item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB >= 11 && item.GB <= 20).ToList()
                    //                    .ForEach(item => { item.MaNV_HanhThu = null; item.ModifyBy = CNguoiDung.MaND; item.ModifyDate = DateTime.Now; });
                    string sql = "update HOADON set MaNV_HanhThu=null,DOTCHIA=null,NGAYGIAO=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                        + "where SOPHATHANH>='" + TuSoPhatHanh + "' and SOPHATHANH<='" + DenSoPhatHanh + "' and NAM=" + Nam + " and KY=" + Ky + " and DOT=" + Dot + " and GB>=11 and GB<=20 "
                        + "and MAY>=" + ExecuteQuery_SqlDataReader_DataTable("select TuCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + " and MAY<=" + ExecuteQuery_SqlDataReader_DataTable("select DenCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + "";
                    ExecuteNonQuery(sql, true);
                }
                else
                    if (Loai == "CQ")
                    {
                        //_db.HOADONs.Where(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                        //            && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        //            && Convert.ToInt32(item.MALOTRINH) >= int.Parse(tumlt) && Convert.ToInt32(item.MALOTRINH) <= int.Parse(denmlt)
                        //            && item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB > 20).ToList()
                        //            .ForEach(item => { item.MaNV_HanhThu = null; item.ModifyBy = CNguoiDung.MaND; item.ModifyDate = DateTime.Now; });
                        string sql = "update HOADON set MaNV_HanhThu=null,DOTCHIA=null,NGAYGIAO=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                        + "where SOPHATHANH>='" + TuSoPhatHanh + "' and SOPHATHANH<='" + DenSoPhatHanh + "' and NAM=" + Nam + " and KY=" + Ky + " and DOT=" + Dot + " and GB>20 "
                        + "and MAY>=" + ExecuteQuery_SqlDataReader_DataTable("select TuCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + " and MAY<=" + ExecuteQuery_SqlDataReader_DataTable("select DenCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + "";
                        ExecuteNonQuery(sql, true);
                    }
                //_db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra tồn tại
        /// </summary>
        /// <param name="nam"></param>
        /// <param name="ky"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        public bool CheckByNamKyDot(int Nam, int Ky, int Dot)
        {
            return _db.HOADONs.Any(item => item.NAM == Nam && item.KY == Ky && item.DOT == Dot);
        }

        public bool CheckBySoHoaDon(string SoHoaDon)
        {
            return _db.HOADONs.Any(item => item.SOHOADON == SoHoaDon);
        }

        /// <summary>
        /// Kiểm tra số phát hành có thuộc tổ/năm/kỳ/đợt
        /// </summary>
        /// <param name="MaTo"></param>
        /// <param name="loai"></param>
        /// <param name="sophathanh"></param>
        /// <param name="nam"></param>
        /// <param name="ky"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        public bool CheckSoPhatHanhByNamKyDot(string Loai, int MaTo, decimal SoPhatHanh, int Nam, int Ky, int Dot)
        {
            if (Loai == "TG")
                return _db.HOADONs.Any(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        && item.SOPHATHANH == SoPhatHanh && item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.GB >= 11 && item.GB <= 20);
            else
                if (Loai == "CQ")
                    return _db.HOADONs.Any(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.SOPHATHANH == SoPhatHanh && item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.GB > 20);
                else
                    return false;
        }

        /// <summary>
        /// Kiểm tra xem trong danh sách hóa đơn có cái nào đã được giao hay chưa
        /// </summary>
        /// <param name="tusophathanh"></param>
        /// <param name="densophathanh"></param>
        /// <param name="nam"></param>
        /// <returns></returns>
        public bool CheckGiaoBySoPhatHanhsNam(decimal TuSoPhatHanh, decimal DenSoPhatHanh, int Nam)
        {
            return _db.HOADONs.Any(item => item.SOPHATHANH >= TuSoPhatHanh && item.SOPHATHANH <= DenSoPhatHanh && item.NAM == Nam && item.MaNV_HanhThu != null);
        }

        /// <summary>
        /// Kiểm tra đã đăng ngân chưa (số phát hành trong 1 năm không bị trùng)
        /// </summary>
        /// <param name="tusophathanh"></param>
        /// <param name="densophathanh"></param>
        /// <param name="nam"></param>
        /// <param name="MaNV"></param>
        /// <returns></returns>
        public bool CheckDangNganBySoPhatHanhsNam(decimal TuSoPhatHanh, decimal DenSoPhatHanh, int Nam, int MaNV)
        {
            return _db.HOADONs.Any(item => item.SOPHATHANH >= TuSoPhatHanh && item.SOPHATHANH <= DenSoPhatHanh && item.NAM == Nam && item.MaNV_DangNgan == MaNV);
        }

        /// <summary>
        /// Kiểm tra Hóa Đơn đã Đăng Ngân chưa
        /// </summary>
        /// <param name="SoHoaDon"></param>
        /// <returns></returns>
        public bool CheckDangNganBySoHoaDon(string SoHoaDon)
        {
            return _db.HOADONs.Any(item => item.SOHOADON == SoHoaDon && item.MaNV_DangNgan != null);
        }

        /// <summary>
        /// Kiểm tra hóa đơn tồn được giao cho ai
        /// </summary>
        /// <param name="SoHoaDon"></param>
        /// <param name="MaNV_GiaoTon"></param>
        /// <returns></returns>
        public bool CheckGiaoTonBySoHoaDonMaNV(string SoHoaDon, int MaNV_GiaoTon)
        {
            return _db.HOADONs.Any(item => item.SOHOADON == SoHoaDon && item.MaNV_GiaoTon == MaNV_GiaoTon);
        }

        public HOADON GetByMaHD(int MaHD)
        {
            return _db.HOADONs.SingleOrDefault(item => item.ID_HOADON == MaHD);
        }

        public HOADON GetBySoHoaDon(string SoHoaDon)
        {
            return _db.HOADONs.SingleOrDefault(item => item.SOHOADON == SoHoaDon);
        }

        public HOADON GetByDanhBo(string DanhBo)
        {
            return _db.HOADONs.OrderByDescending(item => item.DANHBA == DanhBo).First();
        }

        /// <summary>
        /// Lấy danh sách năm có trong hóa đơn
        /// </summary>
        /// <returns></returns>
        public DataTable GetNam()
        {
            //return this.LINQToDataTable(_db.HOADONs.Select(item => new { item.NAM }).Distinct().OrderByDescending(item => item.NAM).ToList());
            return LINQToDataTable(_db.ViewGetNamHDs.OrderByDescending(item => item.Nam));
            //return ExecuteQuery_SqlDataReader_DataTable("select * from ViewGetNamHD");
        }
        
        /// <summary>
        /// Lấy Sum thông tin hóa đơn
        /// </summary>
        /// <param name="nam"></param>
        /// <param name="ky"></param>
        /// <returns></returns>
        public DataTable GetTongByNamKy(int nam, int ky)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == nam && item.KY == ky
                        orderby item.DOT ascending
                        group item by item.DOT into itemGroup
                        select new
                        {
                            Dot = itemGroup.Key,
                            TongHD = itemGroup.Count(),
                            TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                            TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                            TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                            TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                            TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                        };
            return LINQToDataTable(query);
            //string sql = "select DOT,count(ID_HoaDon) as TongHD,sum(TIEUTHU) as TongLNCC,sum(GIABAN) as TongGiaBan,sum(THUE) as TongThueGTGT,sum(PHI) as TongPhiBVMT,sum(TONGCONG) as TongCong "
            //    + "from HOADON where NAM='" + nam + "' and KY='" + ky + "' group by DOT order by DOT asc";
            //return ExecuteQuery_SqlDataReader_DataTable(sql);
        }

        /// <summary>
        /// Lấy Sum thông tin những hóa đơn đã chia cho các anh/em
        /// </summary>
        /// <param name="MaTo"></param>
        /// <param name="loai"></param>
        /// <param name="nam"></param>
        /// <param name="ky"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        public DataTable GetTongGiaoByNamKyDot(string Loai, int MaTo, int Nam, int Ky, int Dot)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.GB >= 11 && item.GB <= 20
                            group item by new { item.MaNV_HanhThu, item.DOTCHIA } into itemGroup
                            select new
                            {
                                MaNV = itemGroup.Key.MaNV_HanhThu,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key.MaNV_HanhThu).HoTen,
                                DotChia = itemGroup.Key.DOTCHIA,
                                TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                                DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                                TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                                DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                                TongHD = itemGroup.Count(),
                                //TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                                //TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                //TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                //TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                            };
                return LINQToDataTable(query.OrderBy(item=>item.TuMLT));
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.GB > 20
                                group item by new { item.MaNV_HanhThu, item.DOTCHIA } into itemGroup
                                select new
                                {
                                    MaNV = itemGroup.Key.MaNV_HanhThu,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key.MaNV_HanhThu).HoTen,
                                    DotChia = itemGroup.Key.DOTCHIA,
                                    TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                                    DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                                    TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                                    DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                                    TongHD = itemGroup.Count(),
                                    //TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                                    //TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                    //TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                    //TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                    TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                };
                    return LINQToDataTable(query.OrderBy(item => item.TuMLT));
                }
            return null;
        }

        /// <summary>
        /// Lấy Sum thông tin những hóa đơn tồn của các anh/em
        /// </summary>
        /// <param name="MaTo"></param>
        /// <param name="loai"></param>
        /// <param name="nam"></param>
        /// <param name="ky"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        public DataTable GetTongTon_To(string Loai, int MaTo, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                //var query = from item in _db.HOADONs
                //            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                //                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                //                && item.NAM == Nam && item.KY == Ky && item.GB >= 11 && item.GB <= 20
                //            orderby item.SOPHATHANH ascending
                //            group item by item.MaNV_HanhThu into itemGroup
                //            select new
                //            {
                //                MaNV = itemGroup.Key,
                //                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                //                TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                //                DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                //                TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                //                DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                //                TongHD = itemGroup.Count(),
                //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                //            };
                //return LINQToDataTable(query);

                string sql = "declare @nam int;"
                            + " declare @ky int;"
                            + " set @nam=" + Nam + ";"
                            + " set @ky=" + Ky + ";"
                            + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and KY=@ky and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and KY=@ky and NGAYGIAITRACH is null and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and KY=@ky and NGAYGIAITRACH is not null and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) thu on tong.MaND=thu.MaND"
                            + " order by tong.MaND asc";

                return ExecuteQuery_SqlDataAdapter_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    //var query = from item in _db.HOADONs
                    //            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                    //                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                    //                && item.NAM == Nam && item.KY == Ky && item.GB > 20
                    //            orderby item.SOPHATHANH ascending
                    //            group item by item.MaNV_HanhThu into itemGroup
                    //            select new
                    //            {
                    //                MaNV = itemGroup.Key,
                    //                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                    //                TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                    //                DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                    //                TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                    //                DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                    //                TongHD = itemGroup.Count(),
                    //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                    //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                    //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                    //            };
                    //return LINQToDataTable(query);

                    string sql = "declare @nam int;"
                            + " declare @ky int;"
                            + " set @nam=" + Nam + ";"
                            + " set @ky=" + Ky + ";"
                            + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and KY=@ky and GB>20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and KY=@ky and NGAYGIAITRACH is null and GB>20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and KY=@ky and NGAYGIAITRACH is not null and GB>20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) thu on tong.MaND=thu.MaND"
                            + " order by tong.MaND asc";

                    return ExecuteQuery_SqlDataAdapter_DataTable(sql);
                }
            return null;
        }

        public DataTable GetTongTon_To(string Loai, int MaTo, int Nam)
        {
            if (Loai == "TG")
            {
                //var query = from item in _db.HOADONs
                //            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                //                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                //                && item.NAM == Nam && item.GB >= 11 && item.GB <= 20
                //            orderby item.MaNV_HanhThu ascending
                //            group item by item.MaNV_HanhThu into itemGroup
                //            select new
                //            {
                //                MaNV = itemGroup.Key,
                //                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                //                TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                //                DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                //                TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                //                DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                //                TongHD = itemGroup.Count(),
                //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                //            };
                //return LINQToDataTable(query);

                string sql = "declare @nam int;"
                            + " set @nam=" + Nam + ";"
                            + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,NAM) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and NGAYGIAITRACH is null and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,NAM) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and NGAYGIAITRACH is not null and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,NAM) thu on tong.MaND=thu.MaND"
                            + " order by tong.MaND asc";

                return ExecuteQuery_SqlDataAdapter_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    //var query = from item in _db.HOADONs
                    //            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                    //                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                    //                && item.NAM == Nam && item.GB > 20
                    //            orderby item.SOPHATHANH ascending
                    //            group item by item.MaNV_HanhThu into itemGroup
                    //            select new
                    //            {
                    //                MaNV = itemGroup.Key,
                    //                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                    //                TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                    //                DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                    //                TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                    //                DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                    //                TongHD = itemGroup.Count(),
                    //                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                    //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                    //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                    //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                    //            };
                    //return LINQToDataTable(query);

                    string sql = "declare @nam int;"
                            + " set @nam=" + Nam + ";"
                            + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and GB>20"
                            + " group by nd.MaND,nd.HoTen,NAM) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and NGAYGIAITRACH is null and GB>20"
                            + " group by nd.MaND,nd.HoTen,NAM) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and NGAYGIAITRACH is not null and GB>20"
                            + " group by nd.MaND,nd.HoTen,NAM) thu on tong.MaND=thu.MaND"
                            + " order by tong.MaND asc";

                    return ExecuteQuery_SqlDataAdapter_DataTable(sql);
                }
            return null;
        }

        public DataTable GetTongTon_To(string Loai, int MaTo, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                //var query = from item in _db.HOADONs
                //            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                //                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                //                && (item.NGAYGIAITRACH == null || item.NGAYGIAITRACH.Value.Date < NgayGiaiTrach.Date) && item.GB >= 11 && item.GB <= 20
                //            orderby item.MaNV_HanhThu ascending
                //            group item by item.MaNV_HanhThu into itemGroup
                //            select new
                //            {
                //                MaNV = itemGroup.Key,
                //                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                //                TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                //                DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                //                TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                //                DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                //                TongHD = itemGroup.Count(),
                //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null && groupItem.NGAYGIAITRACH.Value.Date < NgayGiaiTrach.Date),
                //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null && groupItem.NGAYGIAITRACH.Value.Date < NgayGiaiTrach.Date).Sum(groupItem => groupItem.TONGCONG),
                //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null || groupItem.NGAYGIAITRACH.Value.Date < NgayGiaiTrach.Date),
                //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null || groupItem.NGAYGIAITRACH.Value.Date < NgayGiaiTrach.Date).Sum(groupItem => groupItem.TONGCONG),
                //            };
                //return LINQToDataTable(query);

                string sql = "declare @ngaygiaitrach varchar(10);"
                            + " set @ngaygiaitrach=" + NgayGiaiTrach.ToString("yyyy-MM-dd") + ";"
                            + " select tong.MaND,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and (NGAYGIAITRACH<@ngaygiaitrach or NGAYGIAITRACH is null) and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NGAYGIAITRACH<@ngaygiaitrach and NGAYGIAITRACH is not null and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                            + " order by tong.MaND asc";

                return ExecuteQuery_SqlDataAdapter_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    //var query = from item in _db.HOADONs
                    //            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                    //                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                    //                && (item.NGAYGIAITRACH == null || item.NGAYGIAITRACH.Value.Date < NgayGiaiTrach.Date) && item.GB > 20
                    //            orderby item.SOPHATHANH ascending
                    //            group item by item.MaNV_HanhThu into itemGroup
                    //            select new
                    //            {
                    //                MaNV = itemGroup.Key,
                    //                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                    //                TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                    //                DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                    //                TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                    //                DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                    //                TongHD = itemGroup.Count(),
                    //                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                    //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null && groupItem.NGAYGIAITRACH.Value.Date < NgayGiaiTrach.Date),
                    //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null && groupItem.NGAYGIAITRACH.Value.Date < NgayGiaiTrach.Date).Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null || groupItem.NGAYGIAITRACH.Value.Date < NgayGiaiTrach.Date),
                    //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null || groupItem.NGAYGIAITRACH.Value.Date < NgayGiaiTrach.Date).Sum(groupItem => groupItem.TONGCONG),
                    //            };
                    //return LINQToDataTable(query);

                    string sql = "declare @ngaygiaitrach varchar(10);"
                            + " set @ngaygiaitrach=" + NgayGiaiTrach.ToString("yyyy-MM-dd") + ";"
                            + " select tong.MaND,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and (NGAYGIAITRACH<@ngaygiaitrach or NGAYGIAITRACH is null) and GB>20"
                            + " group by nd.MaND,nd.HoTen) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and (NGAYGIAITRACH<@ngaygiaitrach or NGAYGIAITRACH is null) and GB>20"
                            + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NGAYGIAITRACH<@ngaygiaitrach and NGAYGIAITRACH is not null and GB>20"
                            + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                            + " order by tong.MaND asc";

                    return ExecuteQuery_SqlDataAdapter_DataTable(sql);
                }
            return null;
        }

        /// <summary>
        /// Lấy Sum thông tin những hóa đơn tồn của các Tổ
        /// </summary>
        /// <param name="MaTo"></param>
        /// <param name="loai"></param>
        /// <param name="nam"></param>
        /// <param name="ky"></param>
        /// <returns></returns>
        public DataTable GetTongTon_Doi(string Loai, int MaTo, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                //var query = from item in _db.HOADONs
                //            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                //                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                //                && item.NAM == Nam && item.KY == Ky && item.GB >= 11 && item.GB <= 20
                //            orderby MaTo ascending
                //            group item by MaTo into itemGroup
                //            select new
                //            {
                //                MaTo = itemGroup.Key,
                //                _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == itemGroup.Key).TenTo,
                //                TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                //                DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                //                TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                //                DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                //                TongHD = itemGroup.Count(),
                //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                //            };
                //return LINQToDataTable(query);

                string sql = "declare @nam int;"
                            + " declare @ky int;"
                            + " set @nam=" + Nam + ";"
                            + " set @ky=" + Ky + ";"
                            + " select tong.MaTo,tong.TenTo,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon"
                            + " from"
                            + " (select nd.MaTo,TenTo,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND join TT_To tto on nd.MaTo=tto.MaTo"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and KY=@ky and GB>=11 and GB<=20"
                            + " group by nd.MaTo,TenTo,KY,NAM) tong"
                            + " left join"
                            + " (select nd.MaTo,TenTo,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND join TT_To tto on nd.MaTo=tto.MaTo"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and KY=@ky and NGAYGIAITRACH is null and GB>=11 and GB<=20"
                            + " group by nd.MaTo,TenTo,KY,NAM) ton on tong.MaTo=ton.MaTo"
                            + " left join"
                            + " (select nd.MaTo,TenTo,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND join TT_To tto on nd.MaTo=tto.MaTo"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and KY=@ky and NGAYGIAITRACH is not null and GB>=11 and GB<=20"
                            + " group by nd.MaTo,TenTo,KY,NAM) thu on tong.MaTo=thu.MaTo"
                            + " order by tong.MaTo asc";

                return ExecuteQuery_SqlDataAdapter_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    //var query = from item in _db.HOADONs
                    //            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                    //                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                    //                && item.NAM == Nam && item.KY == Ky && item.GB > 20
                    //            orderby MaTo ascending
                    //            group item by MaTo into itemGroup
                    //            select new
                    //            {
                    //                MaTo = itemGroup.Key,
                    //                _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == itemGroup.Key).TenTo,
                    //                TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                    //                DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                    //                TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                    //                DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                    //                TongHD = itemGroup.Count(),
                    //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                    //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                    //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                    //            };
                    //return LINQToDataTable(query);

                    string sql = "declare @nam int;"
                            + " declare @ky int;"
                            + " set @nam=" + Nam + ";"
                            + " set @ky=" + Ky + ";"
                            + " select tong.MaTo,tong.TenTo,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon"
                            + " from"
                            + " (select nd.MaTo,TenTo,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND join TT_To tto on nd.MaTo=tto.MaTo"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and KY=@ky and GB>20"
                            + " group by nd.MaTo,TenTo,KY,NAM) tong"
                            + " left join"
                            + " (select nd.MaTo,TenTo,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND join TT_To tto on nd.MaTo=tto.MaTo"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and KY=@ky and NGAYGIAITRACH is null and GB>20"
                            + " group by nd.MaTo,TenTo,KY,NAM) ton on tong.MaTo=ton.MaTo"
                            + " left join"
                            + " (select nd.MaTo,TenTo,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND join TT_To tto on nd.MaTo=tto.MaTo"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and KY=@ky and NGAYGIAITRACH is not null and GB>20"
                            + " group by nd.MaTo,TenTo,KY,NAM) thu on tong.MaTo=thu.MaTo"
                            + " order by tong.MaTo asc";

                    return ExecuteQuery_SqlDataAdapter_DataTable(sql);
                }
            return null;
        }

        public DataTable GetTongTon_Doi(string Loai, int MaTo, int Nam)
        {
            if (Loai == "TG")
            {
                //var query = from item in _db.HOADONs
                //            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                //                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                //                && item.NAM == Nam && item.GB >= 11 && item.GB <= 20
                //            orderby MaTo ascending
                //            group item by MaTo into itemGroup
                //            select new
                //            {
                //                MaTo = itemGroup.Key,
                //                _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == itemGroup.Key).TenTo,
                //                TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                //                DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                //                TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                //                DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                //                TongHD = itemGroup.Count(),
                //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                //            };
                //return LINQToDataTable(query);

                string sql = "declare @nam int;"
                            + " set @nam=" + Nam + ";"
                            + " select tong.MaTo,tong.TenTo,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon"
                            + " from"
                            + " (select nd.MaTo,TenTo,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND join TT_To tto on nd.MaTo=tto.MaTo"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and GB>=11 and GB<=20"
                            + " group by nd.MaTo,TenTo,NAM) tong"
                            + " left join"
                            + " (select nd.MaTo,TenTo,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND join TT_To tto on nd.MaTo=tto.MaTo"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and NGAYGIAITRACH is null and GB>=11 and GB<=20"
                            + " group by nd.MaTo,TenTo,NAM) ton on tong.MaTo=ton.MaTo"
                            + " left join"
                            + " (select nd.MaTo,TenTo,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND join TT_To tto on nd.MaTo=tto.MaTo"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and NGAYGIAITRACH is not null and GB>=11 and GB<=20"
                            + " group by nd.MaTo,TenTo,NAM) thu on tong.MaTo=thu.MaTo"
                            + " order by tong.MaTo asc";

                return ExecuteQuery_SqlDataAdapter_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    //var query = from item in _db.HOADONs
                    //            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                    //                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                    //                && item.NAM == Nam && item.GB > 20
                    //            orderby MaTo ascending
                    //            group item by MaTo into itemGroup
                    //            select new
                    //            {
                    //                MaTo = itemGroup.Key,
                    //                _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == itemGroup.Key).TenTo,
                    //                TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                    //                DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                    //                TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                    //                DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                    //                TongHD = itemGroup.Count(),
                    //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                    //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                    //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                    //            };
                    //return LINQToDataTable(query);

                    string sql = "declare @nam int;"
                            + " set @nam=" + Nam + ";"
                            + " select tong.MaTo,tong.TenTo,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon"
                            + " from"
                            + " (select nd.MaTo,TenTo,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND join TT_To tto on nd.MaTo=tto.MaTo"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and GB>20"
                            + " group by nd.MaTo,TenTo,NAM) tong"
                            + " left join"
                            + " (select nd.MaTo,TenTo,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND join TT_To tto on nd.MaTo=tto.MaTo"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and NGAYGIAITRACH is null and GB>20"
                            + " group by nd.MaTo,TenTo,NAM) ton on tong.MaTo=ton.MaTo"
                            + " left join"
                            + " (select nd.MaTo,TenTo,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND join TT_To tto on nd.MaTo=tto.MaTo"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and NGAYGIAITRACH is not null and GB>20"
                            + " group by nd.MaTo,TenTo,NAM) thu on tong.MaTo=thu.MaTo"
                            + " order by tong.MaTo asc";

                    return ExecuteQuery_SqlDataAdapter_DataTable(sql);
                }
            return null;
        }

        public DataTable GetTongTonByMaNV_HanhThu(string Loai, int MaNV_HanhThu, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                //var query = from item in _db.HOADONs
                //            where item.MaNV_HanhThu == MaNV_HanhThu && item.NAM == Nam && item.KY == Ky && item.GB >= 11 && item.GB <= 20
                //            orderby item.MaNV_HanhThu ascending
                //            group item by item.MaNV_HanhThu into itemGroup
                //            select new
                //            {
                //                MaNV = itemGroup.Key,
                //                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                //                TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                //                DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                //                TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                //                DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                //                TongHD = itemGroup.Count(),
                //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                //            };
                //return LINQToDataTable(query);

                string sql = "declare @nam int;"
                            + " declare @ky int;"
                            + " set @nam=" + Nam + ";"
                            + " set @ky=" + Ky + ";"
                            + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NAM=@nam and KY=@ky and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NAM=@nam and KY=@ky and NGAYGIAITRACH is null and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NAM=@nam and KY=@ky and NGAYGIAITRACH is not null and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) thu on tong.MaND=thu.MaND"
                            + " order by tong.MaND asc";

                return ExecuteQuery_SqlDataAdapter_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    //var query = from item in _db.HOADONs
                    //            where item.MaNV_HanhThu == MaNV_HanhThu && item.NAM == Nam && item.KY == Ky && item.GB > 20
                    //            orderby item.MaNV_HanhThu ascending
                    //            group item by item.MaNV_HanhThu into itemGroup
                    //            select new
                    //            {
                    //                MaNV = itemGroup.Key,
                    //                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                    //                TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                    //                DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                    //                TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                    //                DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                    //                TongHD = itemGroup.Count(),
                    //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                    //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                    //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                    //            };
                    //return LINQToDataTable(query);

                    string sql = "declare @nam int;"
                            + " declare @ky int;"
                            + " set @nam=" + Nam + ";"
                            + " set @ky=" + Ky + ";"
                            + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NAM=@nam and KY=@ky and GB>20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NAM=@nam and KY=@ky and NGAYGIAITRACH is null and GB>20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NAM=@nam and KY=@ky and NGAYGIAITRACH is not null and GB>20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) thu on tong.MaND=thu.MaND"
                            + " order by tong.MaND asc";

                    return ExecuteQuery_SqlDataAdapter_DataTable(sql);
                }
            return null;
        }

        public DataTable GetTongTonByMaNV_HanhThu(string Loai, int MaNV_HanhThu, int Nam)
        {
            if (Loai == "TG")
            {
                //var query = from item in _db.HOADONs
                //            where item.MaNV_HanhThu == MaNV_HanhThu && item.NAM == Nam && item.GB >= 11 && item.GB <= 20
                //            orderby item.MaNV_HanhThu ascending
                //            group item by item.MaNV_HanhThu into itemGroup
                //            select new
                //            {
                //                MaNV = itemGroup.Key,
                //                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                //                TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                //                DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                //                TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                //                DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                //                TongHD = itemGroup.Count(),
                //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                //            };
                //return LINQToDataTable(query);

                string sql = "declare @nam int;"
                            + " set @nam=" + Nam + ";"
                            + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu="+MaNV_HanhThu
                            + " and NAM=@nam and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,NAM) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NAM=@nam and NGAYGIAITRACH is null and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,NAM) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NAM=@nam and NGAYGIAITRACH is not null and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,NAM) thu on tong.MaND=thu.MaND"
                            + " order by tong.MaND asc";

                return ExecuteQuery_SqlDataAdapter_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    //var query = from item in _db.HOADONs
                    //            where item.MaNV_HanhThu == MaNV_HanhThu && item.NAM == Nam && item.GB > 20
                    //            orderby item.MaNV_HanhThu ascending
                    //            group item by item.MaNV_HanhThu into itemGroup
                    //            select new
                    //            {
                    //                MaNV = itemGroup.Key,
                    //                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                    //                TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                    //                DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                    //                TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                    //                DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                    //                TongHD = itemGroup.Count(),
                    //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                    //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                    //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                    //            };
                    //return LINQToDataTable(query);

                    string sql = "declare @nam int;"
                            + " set @nam=" + Nam + ";"
                            + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NAM=@nam and GB>20"
                            + " group by nd.MaND,nd.HoTen,NAM) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NAM=@nam and NGAYGIAITRACH is null and GB>20"
                            + " group by nd.MaND,nd.HoTen,NAM) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NAM=@nam and NGAYGIAITRACH is not null and GB>20"
                            + " group by nd.MaND,nd.HoTen,NAM) thu on tong.MaND=thu.MaND"
                            + " order by tong.MaND asc";

                    return ExecuteQuery_SqlDataAdapter_DataTable(sql);
                }
            return null;
        }

        public DataTable GetTongTonByMaNV_HanhThu(string Loai, int MaNV_HanhThu, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                //var query = from item in _db.HOADONs
                //            where item.MaNV_HanhThu == MaNV_HanhThu && (item.NGAYGIAITRACH==null||item.NGAYGIAITRACH.Value.Date<NgayGiaiTrach.Date) && item.GB >= 11 && item.GB <= 20
                //            orderby item.MaNV_HanhThu ascending
                //            group item by item.MaNV_HanhThu into itemGroup
                //            select new
                //            {
                //                MaNV = itemGroup.Key,
                //                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                //                TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                //                DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                //                TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                //                DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                //                TongHD = itemGroup.Count(),
                //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null && groupItem.NGAYGIAITRACH.Value.Date<NgayGiaiTrach.Date),
                //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null && groupItem.NGAYGIAITRACH.Value.Date < NgayGiaiTrach.Date).Sum(groupItem => groupItem.TONGCONG),
                //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null || groupItem.NGAYGIAITRACH.Value.Date < NgayGiaiTrach.Date),
                //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null || groupItem.NGAYGIAITRACH.Value.Date < NgayGiaiTrach.Date).Sum(groupItem => groupItem.TONGCONG),
                //            };
                //return LINQToDataTable(query);

                string sql = "declare @ngaygiaitrach varchar(10);"
                            + " set @ngaygiaitrach=" + NgayGiaiTrach.ToString("yyyy-MM-dd") + ";"
                            + " select tong.MaND,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu="+MaNV_HanhThu
                            + " and (NGAYGIAITRACH<@ngaygiaitrach or NGAYGIAITRACH is null) and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and (NGAYGIAITRACH<@ngaygiaitrach or NGAYGIAITRACH is null) and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NGAYGIAITRACH<@ngaygiaitrach and NGAYGIAITRACH is not null and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                            + " order by tong.MaND asc";

                return ExecuteQuery_SqlDataAdapter_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    //var query = from item in _db.HOADONs
                    //            where item.MaNV_HanhThu == MaNV_HanhThu && (item.NGAYGIAITRACH == null || item.NGAYGIAITRACH.Value.Date < NgayGiaiTrach.Date) && item.GB > 20
                    //            orderby item.MaNV_HanhThu ascending
                    //            group item by item.MaNV_HanhThu into itemGroup
                    //            select new
                    //            {
                    //                MaNV = itemGroup.Key,
                    //                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                    //                TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                    //                DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                    //                TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                    //                DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                    //                TongHD = itemGroup.Count(),
                    //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null && groupItem.NGAYGIAITRACH.Value.Date < NgayGiaiTrach.Date),
                    //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null && groupItem.NGAYGIAITRACH.Value.Date < NgayGiaiTrach.Date).Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null || groupItem.NGAYGIAITRACH.Value.Date < NgayGiaiTrach.Date),
                    //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null || groupItem.NGAYGIAITRACH.Value.Date < NgayGiaiTrach.Date).Sum(groupItem => groupItem.TONGCONG),
                    //            };
                    //return LINQToDataTable(query);

                    string sql = "declare @ngaygiaitrach varchar(10);"
                            + " set @ngaygiaitrach=" + NgayGiaiTrach.ToString("yyyy-MM-dd") + ";"
                            + " select tong.MaND,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and (NGAYGIAITRACH<@ngaygiaitrach or NGAYGIAITRACH is null) and GB>20"
                            + " group by nd.MaND,nd.HoTen) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and (NGAYGIAITRACH<@ngaygiaitrach or NGAYGIAITRACH is null) and GB>20"
                            + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NGAYGIAITRACH<@ngaygiaitrach and NGAYGIAITRACH is not null and GB>20"
                            + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                            + " order by tong.MaND asc";

                    return ExecuteQuery_SqlDataAdapter_DataTable(sql);
                }
            return null;
        }

        public DataTable GetNangSuat_To(string Loai, int MaTo, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                //var query = from item in _db.HOADONs
                //            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                //                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                //                && item.NAM == Nam && item.KY == Ky && item.GB >= 11 && item.GB <= 20
                //            group item by item.MaNV_HanhThu into itemGroup
                //            select new
                //            {
                //                MaNV = itemGroup.Key,
                //                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                //                TongHD = itemGroup.Count(),
                //                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                //                TongGiaBanThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.GIABAN),
                //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                //                TongGiaBanTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.GIABAN),
                //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                //            };
                //return ToDataTable(_db, query.OrderBy(item => item.HoTen));
                ////return LINQToDataTable(query.OrderBy(item => item.HoTen));

                string sql = "declare @nam int;"
                            + " declare @ky int;"
                            + " set @nam=" + Nam + ";"
                            + " set @ky=" + Ky + ";"
                            + " select tong.MaND,tong.HoTen,TongHD,TongGiaBan,TongCong,TongHDThu,TongGiaBanThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHD,sum(GIABAN) as TongGiaBan,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and KY=@ky and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and KY=@ky and NGAYGIAITRACH is null and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(GIABAN) as TongGiaBanThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and KY=@ky and NGAYGIAITRACH is not null and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) thu on tong.MaND=thu.MaND"
                            + " order by tong.MaND asc";

                return ExecuteQuery_SqlDataAdapter_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    //var query = from item in _db.HOADONs
                    //            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                    //                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                    //                && item.NAM == Nam && item.KY == Ky && item.GB > 20
                    //            group item by item.MaNV_HanhThu into itemGroup
                    //            select new
                    //            {
                    //                MaNV = itemGroup.Key,
                    //                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                    //                TongHD = itemGroup.Count(),
                    //                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                    //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                    //                TongGiaBanThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.GIABAN),
                    //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                    //                TongGiaBanTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.GIABAN),
                    //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                    //            };
                    //return ToDataTable(_db, query.OrderBy(item => item.HoTen));
                    ////return LINQToDataTable(query.OrderBy(item => item.HoTen));

                    string sql = "declare @nam int;"
                            + " declare @ky int;"
                            + " set @nam=" + Nam + ";"
                            + " set @ky=" + Ky + ";"
                            + " select tong.MaND,tong.HoTen,TongHD,TongGiaBan,TongCong,TongHDThu,TongGiaBanThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHD,sum(GIABAN) as TongGiaBan,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and KY=@ky and GB>20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and KY=@ky and NGAYGIAITRACH is null and GB>20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(GIABAN) as TongGiaBanThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and KY=@ky and NGAYGIAITRACH is not null and GB>20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) thu on tong.MaND=thu.MaND"
                            + " order by tong.MaND asc";

                    return ExecuteQuery_SqlDataAdapter_DataTable(sql);
                }
            return null;
        }

        public DataTable GetNangSuat_To(string Loai, int MaTo, int Nam)
        {
            if (Loai == "TG")
            {
                //var query = from item in _db.HOADONs
                //            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                //                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                //                && item.NAM == Nam && item.GB >= 11 && item.GB <= 20
                //            group item by item.MaNV_HanhThu into itemGroup
                //            select new
                //            {
                //                MaNV = itemGroup.Key,
                //                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                //                TongHD = itemGroup.Count(),
                //                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                //                TongGiaBanThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.GIABAN),
                //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                //                TongGiaBanTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.GIABAN),
                //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                //            };
                //return ToDataTable(_db, query.OrderBy(item => item.HoTen));
                ////return LINQToDataTable(query.OrderBy(item=>item.HoTen));

                string sql = "declare @nam int;"
                            + " set @nam=" + Nam + ";"
                            + " select tong.MaND,tong.HoTen,TongHD,TongGiaBan,TongCong,TongHDThu,TongGiaBanThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHD,sum(GIABAN) as TongGiaBan,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,NAM) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and NGAYGIAITRACH is null and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,NAM) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(GIABAN) as TongGiaBanThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and NGAYGIAITRACH is not null and GB>=11 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,NAM) thu on tong.MaND=thu.MaND"
                            + " order by tong.MaND asc";

                return ExecuteQuery_SqlDataAdapter_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    //var query = from item in _db.HOADONs
                    //            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                    //                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                    //                && item.NAM == Nam && item.GB > 20
                    //            group item by item.MaNV_HanhThu into itemGroup
                    //            select new
                    //            {
                    //                MaNV = itemGroup.Key,
                    //                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                    //                TongHD = itemGroup.Count(),
                    //                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                    //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                    //                TongGiaBanThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.GIABAN),
                    //                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                    //                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                    //                TongGiaBanTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.GIABAN),
                    //                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                    //            };
                    //return ToDataTable(_db, query.OrderBy(item => item.HoTen));
                    ////return LINQToDataTable(query.OrderBy(item => item.HoTen));

                    string sql = "declare @nam int;"
                            + " set @nam=" + Nam + ";"
                            + " select tong.MaND,tong.HoTen,TongHD,TongGiaBan,TongCong,TongHDThu,TongGiaBanThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHD,sum(GIABAN) as TongGiaBan,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and GB>20"
                            + " group by nd.MaND,nd.HoTen,NAM) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and NGAYGIAITRACH is null and GB>20"
                            + " group by nd.MaND,nd.HoTen,NAM) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(GIABAN) as TongGiaBanThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@nam and NGAYGIAITRACH is not null and GB>20"
                            + " group by nd.MaND,nd.HoTen,NAM) thu on tong.MaND=thu.MaND"
                            + " order by tong.MaND asc";

                    return ExecuteQuery_SqlDataAdapter_DataTable(sql);
                }
            return null;
        }

        public DataTable GetNangSuat_Doi(string Loai, int MaTo, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && item.NAM == Nam && item.KY == Ky && item.GB >= 11 && item.GB <= 20
                            orderby MaTo ascending
                            group item by MaTo into itemGroup
                            select new
                            {
                                MaTo = itemGroup.Key ,
                                _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == itemGroup.Key).TenTo,
                                TongHD = itemGroup.Count(),
                                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                                TongGiaBanThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.GIABAN),
                                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                                TongGiaBanTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.GIABAN),
                                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.NAM == Nam && item.KY == Ky && item.GB > 20
                                orderby MaTo ascending
                                group item by MaTo into itemGroup
                                select new
                                {
                                    MaTo = itemGroup.Key,
                                    _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == itemGroup.Key).TenTo,
                                    TongHD = itemGroup.Count(),
                                    TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                    TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                                    TongGiaBanThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.GIABAN),
                                    TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                                    TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                                    TongGiaBanTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.GIABAN),
                                    TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetNangSuat_Doi(string Loai, int MaTo, int Nam)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && item.NAM == Nam && item.GB >= 11 && item.GB <= 20
                            orderby MaTo ascending
                            group item by MaTo into itemGroup
                            select new
                            {
                                MaTo = itemGroup.Key,
                                _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == itemGroup.Key).TenTo,
                                TongHD = itemGroup.Count(),
                                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                                TongGiaBanThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.GIABAN),
                                TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                                TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                                TongGiaBanTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.GIABAN),
                                TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.NAM == Nam && item.GB > 20
                                orderby MaTo ascending
                                group item by MaTo into itemGroup
                                select new
                                {
                                    MaTo = itemGroup.Key,
                                    _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == itemGroup.Key).TenTo,
                                    TongHD = itemGroup.Count(),
                                    TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                    TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                                    TongGiaBanThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.GIABAN),
                                    TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                                    TongHDTon = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH == null),
                                    TongGiaBanTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.GIABAN),
                                    TongCongTon = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetBangTongHop(int MaTo, DateTime TuNgayDangNgan, DateTime DenNgayDangNgan)
        {
            var query = from item in _db.HOADONs
                        where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                            && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            && item.NGAYGIAITRACH.Value.Date >= TuNgayDangNgan.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayDangNgan.Date
                        orderby item.MaNV_HanhThu ascending
                        group item by item.MaNV_HanhThu into itemGroup
                        select new
                        {
                            MaNV = itemGroup.Key,
                            _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                            TongHDThu = itemGroup.Count(groupItem => groupItem.NGAYGIAITRACH != null),
                            TongCongThu = itemGroup.Where(groupItem => groupItem.NGAYGIAITRACH != null).Sum(groupItem => groupItem.TONGCONG),
                        };
            return LINQToDataTable(query);
        }
        
        //public DataTable GetChuanThuByNamKy(int MaTo, string loai, int nam, int ky)
        //{
        //    if (loai == "TG")
        //    {
        //        var query = from item in _db.HOADONs
        //                    where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
        //                        && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                        && item.NAM == nam && item.KY == ky && item.GB >= 11 && item.GB <= 20
        //                    select new
        //                    {
        //                        MaTo = MaTo,
        //                        _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
        //                        MaHD = item.ID_HOADON,
        //                        item.SOHOADON,
        //                        item.NGAYGIAITRACH,
        //                        item.GIABAN,
        //                        ThueGTGT = item.THUE,
        //                        PhiBVMT = item.PHI,
        //                        item.TONGCONG,
        //                    };
        //        return LINQToDataTable(query);
        //    }
        //    else
        //        if (loai == "CQ")
        //        {
        //            var query = from item in _db.HOADONs
        //                        where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
        //                            && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                            && item.NAM == nam && item.KY == ky && item.GB > 20
        //                        select new
        //                        {
        //                            MaTo = MaTo,
        //                            _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
        //                            MaHD=item.ID_HOADON,
        //                            item.SOHOADON,
        //                            item.NGAYGIAITRACH,
        //                            item.GIABAN,
        //                            ThueGTGT = item.THUE,
        //                            PhiBVMT = item.PHI,
        //                            item.TONGCONG,
        //                        };
        //            return LINQToDataTable(query);
        //        }
        //    return null;
        //}

        //public DataTable GetChuanThuByNam(int MaTo, string loai, int nam)
        //{
        //    if (loai == "TG")
        //    {
        //        var query = from item in _db.HOADONs
        //                    where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
        //                        && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                        && item.NAM == nam && item.GB >= 11 && item.GB <= 20
        //                    select new
        //                    {
        //                        MaTo = MaTo,
        //                        _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
        //                        MaHD = item.ID_HOADON,
        //                        item.SOHOADON,
        //                        item.NGAYGIAITRACH,
        //                        item.GIABAN,
        //                        ThueGTGT = item.THUE,
        //                        PhiBVMT = item.PHI,
        //                        item.TONGCONG,
        //                    };
        //        return LINQToDataTable(query);
        //    }
        //    else
        //        if (loai == "CQ")
        //        {
        //            var query = from item in _db.HOADONs
        //                        where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
        //                            && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                            && item.NAM == nam && item.GB > 20
        //                        select new
        //                        {
        //                            MaTo = MaTo,
        //                            _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == MaTo).TenTo,
        //                            MaHD = item.ID_HOADON,
        //                            item.SOHOADON,
        //                            item.NGAYGIAITRACH,
        //                            item.GIABAN,
        //                            ThueGTGT = item.THUE,
        //                            PhiBVMT = item.PHI,
        //                            item.TONGCONG,
        //                        };
        //            return LINQToDataTable(query);
        //        }
        //    return null;
        //}

        /// <summary>
        /// Lấy Sum thông tin những hóa đơn đã đăng ngân bởi các anh/em
        /// </summary>
        /// <param name="MaTo"></param>
        /// <param name="loai"></param>
        /// <param name="NgayDangNgan"></param>
        /// <returns></returns>
        public DataTable GetTongDangNganByNgayGiaiTrach_To(string Loai, int MaTo, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                ///Tổ Văn Phòng
                if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu != true)
                {
                    var query = from item in _db.HOADONs
                                where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo&&itemND.MaND==item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                orderby item.MaNV_DangNgan ascending
                                group item by item.MaNV_DangNgan into itemGroup
                                select new
                                {
                                    MaNV = itemGroup.Key,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                    //TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                                    //DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                                    //TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                                    //DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                                    TongHD = itemGroup.Count(),
                                    TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                    TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                    TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                    TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    //TongHDThu = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key),
                                    //TongCongThu = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key).Sum(groupItem => groupItem.TONGCONG),
                                    //TongHDTon = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null),
                                    //TongCongTon = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                                };
                    return LINQToDataTable(query);
                }
                ///Tổ Hành Thu
                else
                {
                    var query = from item in _db.HOADONs
                                where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    //&& _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                    && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                orderby item.MaNV_DangNgan ascending
                                group item by item.MaNV_DangNgan into itemGroup
                                select new
                                {
                                    MaNV = itemGroup.Key,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                    //TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                                    //DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                                    //TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                                    //DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                                    TongHD = itemGroup.Count(),
                                    TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                    TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                    TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                    TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    //TongHDThu = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key),
                                    //TongCongThu = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key).Sum(groupItem => groupItem.TONGCONG),
                                    //TongHDTon = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null),
                                    //TongCongTon = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                                };
                    return LINQToDataTable(query);
                }
            }
            else
                if (Loai == "CQ")
                {
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu != true)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                    &&item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                    orderby item.MaNV_DangNgan ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        //TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                                        //DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                                        //TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                                        //DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        //TongHDThu = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key),
                                        //TongCongThu = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key).Sum(groupItem => groupItem.TONGCONG),
                                        //TongHDTon = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null),
                                        //TongCongTon = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query);
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        //&& _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                    orderby item.MaNV_DangNgan ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        //TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                                        //DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                                        //TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                                        //DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        //TongHDThu = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key),
                                        //TongCongThu = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key).Sum(groupItem => groupItem.TONGCONG),
                                        //TongHDTon = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null),
                                        //TongCongTon = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query);
                    }
                }
            return null;
        }

        public DataTable GetTongDangNganByNgayGiaiTrach_To(string Loai, int MaTo, DateTime TuNgayGiaiTrach, DateTime DenNgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                ///Tổ Văn Phòng
                if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu != true)
                {
                    var query = from item in _db.HOADONs
                                where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                orderby item.MaNV_DangNgan ascending
                                group item by item.MaNV_DangNgan into itemGroup
                                select new
                                {
                                    MaNV = itemGroup.Key,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                    //TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                                    //DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                                    //TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                                    //DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                                    TongHD = itemGroup.Count(),
                                    TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                    TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                    TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                    TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    //TongHDThu = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key),
                                    //TongCongThu = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key).Sum(groupItem => groupItem.TONGCONG),
                                    //TongHDTon = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null),
                                    //TongCongTon = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                                };
                    return LINQToDataTable(query);
                }
                ///Tổ Hành Thu
                else
                {
                    var query = from item in _db.HOADONs
                                where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                    && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                orderby item.MaNV_DangNgan ascending
                                group item by item.MaNV_DangNgan into itemGroup
                                select new
                                {
                                    MaNV = itemGroup.Key,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                    //TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                                    //DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                                    //TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                                    //DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                                    TongHD = itemGroup.Count(),
                                    TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                    TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                    TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                    TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    //TongHDThu = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key),
                                    //TongCongThu = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key).Sum(groupItem => groupItem.TONGCONG),
                                    //TongHDTon = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null),
                                    //TongCongTon = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                                };
                    return LINQToDataTable(query);
                }
            }
            else
                if (Loai == "CQ")
                {
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu != true)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                    && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && item.GB > 20
                                    orderby item.MaNV_DangNgan ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        //TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                                        //DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                                        //TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                                        //DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        //TongHDThu = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key),
                                        //TongCongThu = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key).Sum(groupItem => groupItem.TONGCONG),
                                        //TongHDTon = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null),
                                        //TongCongTon = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query);
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        && _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && item.GB > 20
                                    orderby item.MaNV_DangNgan ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        //TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                                        //DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                                        //TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                                        //DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        //TongHDThu = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key),
                                        //TongCongThu = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key).Sum(groupItem => groupItem.TONGCONG),
                                        //TongHDTon = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null),
                                        //TongCongTon = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query);
                    }
                }
            return null;
        }

        //public DataTable GetTongDangNganByNgayGiaiTrach_Doi(string Loai, int MaTo, DateTime NgayGiaiTrach)
        //{
        //    if (Loai == "TG")
        //    {
        //        var query = from item in _db.HOADONs
        //                    where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
        //                        && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                        && _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
        //                        && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
        //                    orderby MaTo ascending
        //                    group item by MaTo into itemGroup
        //                    select new
        //                    {
        //                        MaTo = itemGroup.Key,
        //                        _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == itemGroup.Key).TenTo,
        //                        TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
        //                        DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
        //                        TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
        //                        DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
        //                        TongHD = itemGroup.Count(),
        //                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
        //                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
        //                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
        //                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
        //                        //TongHDThu = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key),
        //                        //TongCongThu = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key).Sum(groupItem => groupItem.TONGCONG),
        //                        //TongHDTon = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null),
        //                        //TongCongTon = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
        //                    };
        //        return LINQToDataTable(query);
        //    }
        //    else
        //        if (Loai == "CQ")
        //        {
        //            var query = from item in _db.HOADONs
        //                        where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
        //                            && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                            && _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
        //                            && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
        //                        orderby MaTo ascending
        //                        group item by MaTo into itemGroup
        //                        select new
        //                        {
        //                            MaTo = itemGroup.Key,
        //                            _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == itemGroup.Key).TenTo,
        //                            TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
        //                            DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
        //                            TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
        //                            DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
        //                            TongHD = itemGroup.Count(),
        //                            TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
        //                            TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
        //                            TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
        //                            TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
        //                            //TongHDThu = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key),
        //                            //TongCongThu = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key).Sum(groupItem => groupItem.TONGCONG),
        //                            //TongHDTon = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null),
        //                            //TongCongTon = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
        //                        };
        //            return LINQToDataTable(query);
        //        }
        //    return null;
        //}

        /// <summary>
        /// Lấy Sum thông tin những hóa đơn đã đăng ngân bởi các tổ
        /// </summary>
        /// <param name="MaTo"></param>
        /// <param name="loai"></param>
        /// <param name="TuNgayDangNgan"></param>
        /// <param name="DenNgayDangNgan"></param>
        /// <returns></returns>
        public DataTable GetTongDangNganByNgayGiaiTrach_Doi(string Loai, int MaTo, DateTime TuNgayGiaiTrach, DateTime DenNgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                ///Tổ Văn Phòng
                if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu != true)
                {
                    var query = from item in _db.HOADONs
                                where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                orderby MaTo ascending
                                group item by MaTo into itemGroup
                                select new
                                {
                                    MaTo = itemGroup.Key,
                                    _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == itemGroup.Key).TenTo,
                                    TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                                    DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                                    TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                                    DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                                    TongHD = itemGroup.Count(),
                                    TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                    TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                    TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                    TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    //TongHDThu = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key),
                                    //TongCongThu = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key).Sum(groupItem => groupItem.TONGCONG),
                                    //TongHDTon = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null),
                                    //TongCongTon = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                                };
                    return LINQToDataTable(query);
                }
                ///Tổ Hành Thu
                else
                {
                    var query = from item in _db.HOADONs
                                where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                    && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                orderby MaTo ascending
                                group item by MaTo into itemGroup
                                select new
                                {
                                    MaTo = itemGroup.Key,
                                    _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == itemGroup.Key).TenTo,
                                    TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                                    DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                                    TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                                    DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                                    TongHD = itemGroup.Count(),
                                    TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                    TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                    TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                    TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    //TongHDThu = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key),
                                    //TongCongThu = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key).Sum(groupItem => groupItem.TONGCONG),
                                    //TongHDTon = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null),
                                    //TongCongTon = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                                };
                    return LINQToDataTable(query);
                }
            }
            else
                if (Loai == "CQ")
                {
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu != true)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan) ///Kiểm tra nhân viên đăng ngân thuộc tổ
                                    && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && item.GB > 20
                                    orderby MaTo ascending
                                    group item by MaTo into itemGroup
                                    select new
                                    {
                                        MaTo = itemGroup.Key,
                                        _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == itemGroup.Key).TenTo,
                                        TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                                        DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                                        TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                                        DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        //TongHDThu = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key),
                                        //TongCongThu = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key).Sum(groupItem => groupItem.TONGCONG),
                                        //TongHDTon = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null),
                                        //TongCongTon = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query);
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        && _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && item.GB > 20
                                    orderby MaTo ascending
                                    group item by MaTo into itemGroup
                                    select new
                                    {
                                        MaTo = itemGroup.Key,
                                        _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == itemGroup.Key).TenTo,
                                        TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                                        DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                                        TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                                        DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        //TongHDThu = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key),
                                        //TongCongThu = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key).Sum(groupItem => groupItem.TONGCONG),
                                        //TongHDTon = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null),
                                        //TongCongTon = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query);
                    }
                }
            return null;
        }

        public DataTable GetTongDangNganByNgayGiaiTrach_Doi(DateTime TuNgayGiaiTrach, DateTime DenNgayGiaiTrach)
        {
            var query = from item in _db.HOADONs
                        where item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date
                        orderby item.MaNV_DangNgan ascending
                        group item by item.MaNV_DangNgan into itemGroup
                        select new
                        {
                            MaNV = itemGroup.Key,
                            _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                            //TuMLT = itemGroup.Min(groupItem => groupItem.MALOTRINH),
                            //DenMLT = itemGroup.Max(groupItem => groupItem.MALOTRINH),
                            //TuSoPhatHanh = itemGroup.Min(groupItem => groupItem.SOPHATHANH),
                            //DenSoPhatHanh = itemGroup.Max(groupItem => groupItem.SOPHATHANH),
                            TongHD = itemGroup.Count(),
                            TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                            TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                            TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                            TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                            //TongHDThu = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key),
                            //TongCongThu = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == itemGroup.Key).Sum(groupItem => groupItem.TONGCONG),
                            //TongHDTon = itemGroup.Count(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null),
                            //TongCongTon = itemGroup.Where(groupItem => groupItem.MaNV_DangNgan == null && groupItem.NGAYGIAITRACH == null).Sum(groupItem => groupItem.TONGCONG),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetTongDangNganByMaNV_HanhThuNamKyDot(string Loai, int MaNV_HanhThu, int Nam, int Ky, int Dot)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.MaNV_HanhThu==MaNV_HanhThu && item.NGAYGIAITRACH != null && item.GB >= 11 && item.GB <= 20
                            orderby item.MaNV_DangNgan ascending
                            group item by item.MaNV_DangNgan into itemGroup
                            select new
                            {
                                MaNV = itemGroup.Key,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                TongHD = itemGroup.Count(),
                                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.MaNV_HanhThu == MaNV_HanhThu && item.NGAYGIAITRACH != null && item.GB > 20
                                orderby item.MaNV_DangNgan ascending
                                group item by item.MaNV_DangNgan into itemGroup
                                select new
                                {
                                    MaNV = itemGroup.Key,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                    TongHD = itemGroup.Count(),
                                    TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                    TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                    TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                    TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetTongDangNganByMaNV_DangNganNgayGiaiTrach(string Loai, int MaNV_DangNgan, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where item.MaNV_DangNgan == MaNV_DangNgan && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                            orderby item.MaNV_DangNgan ascending
                            group item by item.MaNV_DangNgan into itemGroup
                            select new
                            {
                                MaNV = itemGroup.Key,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                TongHD = itemGroup.Count(),
                                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where item.MaNV_DangNgan == MaNV_DangNgan && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                orderby item.MaNV_DangNgan ascending
                                group item by item.MaNV_DangNgan into itemGroup
                                select new
                                {
                                    MaNV = itemGroup.Key,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                    TongHD = itemGroup.Count(),
                                    TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                    TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                    TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                    TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetTongDangNganByMaNV_DangNganNgayGiaiTrachs(string Loai, int MaNV_DangNgan, DateTime TuNgay, DateTime DenNgay)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where item.MaNV_DangNgan == MaNV_DangNgan && item.NGAYGIAITRACH.Value.Date >= TuNgay.Date && item.NGAYGIAITRACH.Value.Date <= DenNgay.Date && item.GB >= 11 && item.GB <= 20
                            orderby item.MaNV_DangNgan ascending
                            group item by item.MaNV_DangNgan into itemGroup
                            select new
                            {
                                MaNV = itemGroup.Key,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                TongHD = itemGroup.Count(),
                                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where item.MaNV_DangNgan == MaNV_DangNgan && item.NGAYGIAITRACH.Value.Date >= TuNgay.Date && item.NGAYGIAITRACH.Value.Date <= DenNgay.Date && item.GB > 20
                                orderby item.MaNV_DangNgan ascending
                                group item by item.MaNV_DangNgan into itemGroup
                                select new
                                {
                                    MaNV = itemGroup.Key,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                    TongHD = itemGroup.Count(),
                                    TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                    TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                    TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                    TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        /// <summary>
        /// Lấy Sum hóa đơn đã đăng ngân chuyển khoản theo Tổ trong khoảng thời gian
        /// </summary>
        /// <param name="MaTo"></param>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable GetTongDangNganChuyenKhoanByMaToNgayGiaiTrachs(int MaTo, DateTime TuNgayGiaiTrach, DateTime DenNgayGiaiTrach)
        {
            var query = from item in _db.HOADONs
                        where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        && item.DangNgan_ChuyenKhoan == true && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date
                        orderby item.NGAYGIAITRACH ascending
                        group item by item.NGAYGIAITRACH.Value.Date into itemGroup
                        select new
                        {
                            Ngay = itemGroup.Key.Day + "/" + itemGroup.Key.Month,
                            TongHD = itemGroup.Count(),
                            TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                        };
            return LINQToDataTable(query);

            //string sql = "declare @Tungaygiaitrach varchar(10);"
            //            + " declare @Denngaygiaitrach varchar(10);"
            //            + " set @Tungaygiaitrach=" + TuNgayGiaiTrach.ToString("yyyy-MM-dd") + ";"
            //            + " set @Denngaygiaitrach=" + DenNgayGiaiTrach.ToString("yyyy-MM-dd") + ";"
            //            + " select nd.MaTo,TenTo,day(NGAYGIAITRACH) as Ngay,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
            //            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND join TT_To tto on nd.MaTo=tto.MaTo"
            //            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
            //            + " and DangNgan_ChuyenKhoan='True' and NGAYGIAITRACH>=@Tungaygiaitrach and NGAYGIAITRACH<=@Denngaygiaitrach"
            //            + " group by nd.MaTo,TenTo,day(NGAYGIAITRACH)";

            //return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        /// <summary>
        /// Hàm dùng để Báo Cáo Tổng Hợp. Hàm giống GetTongDangNganByNgayGiaiTrach_To nhưng khác ở chỗ chống trùng nhân viên đăng ngân Tổ Văn Phòng ở Tổ Hành Thu
        /// </summary>
        /// <param name="Loai"></param>
        /// <param name="NgayGiaiTrach"></param>
        /// <returns></returns>
        public DataTable GetTongHopDangNganDoi(string Loai, DateTime NgayGiaiTrach)
        {
            if (Loai == "CK")
            {
                ///Tổ Văn Phòng
                var query = from item in _db.HOADONs
                            where item.DangNgan_ChuyenKhoan == true///chỉ lấy ngân hàng
                            && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                            group item by item.DangNgan_ChuyenKhoan into itemGroup
                            select new
                            {
                                HoTen = "NGÂN HÀNG",
                                ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                TongHD = itemGroup.Count(),
                                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "TG")
                {
                    ///Tổ Hành Thu & Quầy
                    var query = from item in _db.HOADONs
                                where item.DangNgan_ChuyenKhoan == false///ngoài ngân hàng ra
                                    && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                group item by item.DangNgan_ChuyenKhoan into itemGroup
                                select new
                                {
                                    ///Dùng chung với report TongHopDangNganChiTiet nên phải đổi MaTo & TenTo
                                    HoTen = "TƯ GIA",
                                    ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                    TongHD = itemGroup.Count(),
                                    TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                    TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                    TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                    TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                };
                    return LINQToDataTable(query);
                }
                else
                    if (Loai == "CQ")
                    {
                        ///Tổ Hành Thu & Quầy
                        var query = from item in _db.HOADONs
                                    where item.DangNgan_ChuyenKhoan == false///ngoài ngân hàng ra
                                        && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                    group item by item.DangNgan_ChuyenKhoan into itemGroup
                                    select new
                                    {
                                        ///Dùng chung với report TongHopDangNganChiTiet nên phải đổi MaTo & TenTo
                                        HoTen = "CƠ QUAN",
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query);
                    }
            return null;
        }

        /// <summary>
        /// Hàm dùng để Báo Cáo Tổng Hợp. Hàm giống GetTongDangNganByNgayGiaiTrach_To nhưng khác ở chỗ chống trùng nhân viên đăng ngân Tổ Văn Phòng ở Tổ Hành Thu
        /// </summary>
        /// <param name="Loai"></param>
        /// <param name="MaTo"></param>
        /// <param name="NgayGiaiTrach"></param>
        /// <returns></returns>
        public DataTable GetTongHopDangNganChiTiet(string Loai, int MaTo, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                ///Tổ Văn Phòng
                if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu != true)
                {
                    var query = from item in _db.HOADONs
                                where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                orderby item.MaNV_DangNgan ascending
                                group item by item.MaNV_DangNgan into itemGroup
                                select new
                                {
                                    MaNV = itemGroup.Key,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                    ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                    TongHD = itemGroup.Count(),
                                    TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                    TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                    TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                    TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                };
                    return LINQToDataTable(query);
                }
                ///Tổ Hành Thu
                else
                {
                    var query = from item in _db.HOADONs
                                where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                    && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                orderby item.MaNV_DangNgan ascending
                                group item by item.MaNV_DangNgan into itemGroup
                                select new
                                {
                                    MaNV = itemGroup.Key,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                    ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                    TongHD = itemGroup.Count(),
                                    TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                    TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                    TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                    TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                };
                    return LINQToDataTable(query);
                }
            }
            else
                if (Loai == "CQ")
                {
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu != true)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                    && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                    orderby item.MaNV_DangNgan ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query);
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        && _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                    orderby item.MaNV_DangNgan ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query);
                    }
                }
            return null;
        }

        /// <summary>
        /// Lấy Sum thông tin những hóa đơn đã chia cho từng anh/em cụ thể
        /// </summary>
        /// <param name="MaNV"></param>
        /// <param name="nam"></param>
        /// <param name="ky"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        public DataTable GetTongTGByMaNVNamKyDot(int MaNV, int Nam, int Ky, int Dot)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.MaNV_HanhThu == MaNV
                        group item by item.GB >= 11 && item.GB <= 20 into itemGroup
                        select new
                        {
                            Loai = itemGroup.Key.ToString(),
                            itemGroup.FirstOrDefault().DOT,
                            TongHD = itemGroup.Count(),
                            TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                            TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                            TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                            TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                            TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                        };
            return LINQToDataTable(query);
        }

        /// <summary>
        /// Lấy danh sách hóa đơn được giao & đã đăng ngân bởi anh/em cụ thể
        /// </summary>
        /// <param name="MaNV"></param>
        /// <param name="nam"></param>
        /// <param name="ky"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        public DataTable GetDSDangNganHanhThuTGByMaNVNamKyDot(int MaNV_DangNgan, int Nam, int Ky, int Dot)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.DangNgan_HanhThu == true && item.MaNV_DangNgan == MaNV_DangNgan && item.GB >= 11 && item.GB <= 20
                        orderby item.MALOTRINH ascending
                        select new
                        {
                            item.NGAYGIAITRACH,
                            item.SOHOADON,
                            Ky = item.KY + "/" + item.NAM,
                            MLT = item.MALOTRINH,
                            item.SOPHATHANH,
                            DanhBo = item.DANHBA,
                            item.TIEUTHU,
                            item.GIABAN,
                            ThueGTGT = item.THUE,
                            PhiBVMT = item.PHI,
                            item.TONGCONG,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDangNganHanhThuByMaNVNgayGiaiTrach(string Loai, int MaNV_DangNgan, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.DangNgan_HanhThu == true && item.MaNV_DangNgan == MaNV_DangNgan && item.GB >= 11 && item.GB <= 20
                            orderby item.SOHOADON ascending
                            select new
                            {
                                item.NGAYGIAITRACH,
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                MLT = item.MALOTRINH,
                                item.SOPHATHANH,
                                DanhBo = item.DANHBA,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.DangNgan_HanhThu == true && item.MaNV_DangNgan == MaNV_DangNgan && item.GB > 20
                                orderby item.SOHOADON ascending
                                select new
                                {
                                    item.NGAYGIAITRACH,
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    MLT = item.MALOTRINH,
                                    item.SOPHATHANH,
                                    DanhBo = item.DANHBA,
                                    item.TIEUTHU,
                                    item.GIABAN,
                                    ThueGTGT = item.THUE,
                                    PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSDangNganByMaNVNgayGiaiTrach(string Loai,int MaNV_DangNgan, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.MaNV_DangNgan == MaNV_DangNgan && item.GB >= 11 && item.GB <= 20
                            orderby item.MALOTRINH ascending
                            select new
                            {
                                item.NGAYGIAITRACH,
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                MLT = item.MALOTRINH,
                                item.SOPHATHANH,
                                DanhBo = item.DANHBA,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.MaNV_DangNgan == MaNV_DangNgan && item.GB > 20
                                orderby item.MALOTRINH ascending
                                select new
                                {
                                    item.NGAYGIAITRACH,
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    MLT = item.MALOTRINH,
                                    item.SOPHATHANH,
                                    DanhBo = item.DANHBA,
                                    item.TIEUTHU,
                                    item.GIABAN,
                                    ThueGTGT = item.THUE,
                                    PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSDangNganByToMaNVNgayGiaiTrach(string Loai, int MaTo,int MaNV_DangNgan, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                             && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.MaNV_DangNgan == MaNV_DangNgan && item.GB >= 11 && item.GB <= 20
                            orderby item.MALOTRINH ascending
                            select new
                            {
                                item.NGAYGIAITRACH,
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                MLT = item.MALOTRINH,
                                item.SOPHATHANH,
                                DanhBo = item.DANHBA,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.MaNV_DangNgan == MaNV_DangNgan && item.GB > 20
                                orderby item.MALOTRINH ascending
                                select new
                                {
                                    item.NGAYGIAITRACH,
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    MLT = item.MALOTRINH,
                                    item.SOPHATHANH,
                                    DanhBo = item.DANHBA,
                                    item.TIEUTHU,
                                    item.GIABAN,
                                    ThueGTGT = item.THUE,
                                    PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        /// <summary>
        /// Lấy danh sách hóa đơn được giao & tồn lại bởi anh/em cụ thể
        /// </summary>
        /// <param name="MaNV"></param>
        /// <param name="nam"></param>
        /// <param name="ky"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        public DataTable GetDSTon(string Loai,int MaNV, int Nam, int Ky, int Dot)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.MaNV_HanhThu == MaNV && item.NGAYGIAITRACH == null && item.GB >= 11 && item.GB <= 20
                            orderby item.MALOTRINH ascending
                            select new
                            {
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                MLT = item.MALOTRINH,
                                item.SOPHATHANH,
                                DanhBo = item.DANHBA,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.MaNV_HanhThu == MaNV && item.NGAYGIAITRACH == null && item.GB > 20
                                orderby item.MALOTRINH ascending
                                select new
                                {
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    MLT = item.MALOTRINH,
                                    item.SOPHATHANH,
                                    DanhBo = item.DANHBA,
                                    item.TIEUTHU,
                                    item.GIABAN,
                                    ThueGTGT = item.THUE,
                                    PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSTon(string Loai, int MaNV, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where item.NAM == Nam && item.KY == Ky && item.MaNV_HanhThu == MaNV && item.NGAYGIAITRACH == null && item.GB >= 11 && item.GB <= 20
                            orderby item.MALOTRINH ascending
                            select new
                            {
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                MLT = item.MALOTRINH,
                                item.SOPHATHANH,
                                DanhBo = item.DANHBA,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where item.NAM == Nam && item.KY == Ky && item.MaNV_HanhThu == MaNV && item.NGAYGIAITRACH == null && item.GB > 20
                                orderby item.MALOTRINH ascending
                                select new
                                {
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    MLT = item.MALOTRINH,
                                    item.SOPHATHANH,
                                    DanhBo = item.DANHBA,
                                    item.TIEUTHU,
                                    item.GIABAN,
                                    ThueGTGT = item.THUE,
                                    PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSTonNhieuKy(string Loai, int MaNV,int NhieuKy ,int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where item.NAM == Nam && item.KY == Ky && item.MaNV_HanhThu == MaNV && item.NGAYGIAITRACH == null && item.GB >= 11 && item.GB <= 20
                            orderby item.MALOTRINH ascending
                            select new
                            {
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                MLT = item.MALOTRINH,
                                item.SOPHATHANH,
                                DanhBo = item.DANHBA,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where item.NAM == Nam && item.KY == Ky && item.MaNV_HanhThu == MaNV && item.NGAYGIAITRACH == null && item.GB > 20
                                orderby item.MALOTRINH ascending
                                select new
                                {
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    MLT = item.MALOTRINH,
                                    item.SOPHATHANH,
                                    DanhBo = item.DANHBA,
                                    item.TIEUTHU,
                                    item.GIABAN,
                                    ThueGTGT = item.THUE,
                                    PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSTon(string Loai, int MaNV, int Nam)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where item.NAM == Nam && item.MaNV_HanhThu == MaNV && item.NGAYGIAITRACH == null && item.GB >= 11 && item.GB <= 20
                            orderby item.MALOTRINH ascending
                            select new
                            {
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                MLT = item.MALOTRINH,
                                item.SOPHATHANH,
                                DanhBo = item.DANHBA,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where item.NAM == Nam && item.MaNV_HanhThu == MaNV && item.NGAYGIAITRACH == null && item.GB > 20
                                orderby item.MALOTRINH ascending
                                select new
                                {
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    MLT = item.MALOTRINH,
                                    item.SOPHATHANH,
                                    DanhBo = item.DANHBA,
                                    item.TIEUTHU,
                                    item.GIABAN,
                                    ThueGTGT = item.THUE,
                                    PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSTonNhieuKy(string Loai, int MaNV,int NhieuKy ,int Nam)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where item.NAM == Nam && item.MaNV_HanhThu == MaNV && item.NGAYGIAITRACH == null && item.GB >= 11 && item.GB <= 20
                            orderby item.MALOTRINH ascending
                            select new
                            {
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                MLT = item.MALOTRINH,
                                item.SOPHATHANH,
                                DanhBo = item.DANHBA,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where item.NAM == Nam && item.MaNV_HanhThu == MaNV && item.NGAYGIAITRACH == null && item.GB > 20
                                orderby item.MALOTRINH ascending
                                select new
                                {
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    MLT = item.MALOTRINH,
                                    item.SOPHATHANH,
                                    DanhBo = item.DANHBA,
                                    item.TIEUTHU,
                                    item.GIABAN,
                                    ThueGTGT = item.THUE,
                                    PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSToTon(string Loai, int MaTo, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            && item.NAM == Nam && item.KY == Ky && item.NGAYGIAITRACH == null && item.GB >= 11 && item.GB <= 20
                            orderby item.MALOTRINH ascending
                            select new
                            {
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                MLT = item.MALOTRINH,
                                item.SOPHATHANH,
                                DanhBo = item.DANHBA,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS 
                                && item.NAM == Nam && item.KY == Ky && item.NGAYGIAITRACH == null && item.GB > 20
                                orderby item.MALOTRINH ascending
                                select new
                                {
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    MLT = item.MALOTRINH,
                                    item.SOPHATHANH,
                                    DanhBo = item.DANHBA,
                                    item.TIEUTHU,
                                    item.GIABAN,
                                    ThueGTGT = item.THUE,
                                    PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSToTon(string Loai, int MaTo, int Nam)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            && item.NAM == Nam && item.NGAYGIAITRACH == null && item.GB >= 11 && item.GB <= 20
                            orderby item.MALOTRINH ascending
                            select new
                            {
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                MLT = item.MALOTRINH,
                                item.SOPHATHANH,
                                DanhBo = item.DANHBA,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && item.NAM == Nam && item.NGAYGIAITRACH == null && item.GB > 20
                                orderby item.MALOTRINH ascending
                                select new
                                {
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    MLT = item.MALOTRINH,
                                    item.SOPHATHANH,
                                    DanhBo = item.DANHBA,
                                    item.TIEUTHU,
                                    item.GIABAN,
                                    ThueGTGT = item.THUE,
                                    PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        /// <summary>
        /// Lấy danh sách tất cả hóa đơn tồn
        /// </summary>
        /// <returns></returns>
        public DataTable GetDSTon()
        {
            var query = from item in _db.HOADONs
                        where item.NGAYGIAITRACH == null
                        select new
                        {
                            item.SOHOADON,
                            item.TONGCONG,
                        };
            return LINQToDataTable(query);
        }

        /// <summary>
        /// Lấy Danh Sách Hóa Đơn Tồn theo Danh Bộ, phục vụ cho Thu Tạm tại Quầy/Chuyển Khoản (Left join)
        /// </summary>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public DataTable GetDSTonByDanhBo(string DanhBo)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.DANHBA == DanhBo && itemHD.NGAYGIAITRACH == null
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
                            itemHD.SOPHATHANH,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            GiaBieu = itemHD.GB,
                            DinhMuc = itemHD.DM,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSGiaoTonByDates(int MaTo,DateTime TuNgay, DateTime DenNgay)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        join itemNDTruoc in _db.TT_NguoiDungs on itemHD.MaNV_HanhThuTruoc equals itemNDTruoc.MaND into tableNDTruoc
                        from itemtableND in tableND.DefaultIfEmpty()
                        from itemtableNDTruoc in tableNDTruoc.DefaultIfEmpty()
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && itemHD.NGAYGIAOTON.Value.Date >= TuNgay.Date && itemHD.NGAYGIAOTON.Value.Date <= DenNgay.Date
                        //orderby itemHD.MaNV_GiaoTon ascending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            NgayGiaiTrach = itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            DanhBo = itemHD.DANHBA,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            MaNV_HanhThu = itemtableND.HoTen,
                            MaNV_HanhThuTruoc = itemtableNDTruoc.HoTen,
                            itemHD.NGAYGIAOTON,
                        };
            return LINQToDataTable(query);
        }

        //public DataTable GetDSGiaoTonByMaNVDates1(int MaNV_GiaoTon, DateTime TuNgay, DateTime DenNgay)
        //{
        //    var query = from itemHD in _db.HOADONs
        //                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_GiaoTon equals itemND.MaND into tableND
        //                from itemtableND in tableND.DefaultIfEmpty()
        //                where itemHD.MaNV_GiaoTon == MaNV_GiaoTon && itemHD.NGAYGIAOTON.Value.Date >= TuNgay.Date && itemHD.NGAYGIAOTON.Value.Date <= DenNgay.Date
        //                orderby itemHD.ID_HOADON ascending
        //                select new
        //                {
        //                    MaHD = itemHD.ID_HOADON,
        //                    NgayGiaiTrach = itemHD.NGAYGIAITRACH,
        //                    itemHD.SOHOADON,
        //                    Ky = itemHD.KY + "/" + itemHD.NAM,
        //                    MLT = itemHD.MALOTRINH,
        //                    itemHD.SOPHATHANH,
        //                    DanhBo = itemHD.DANHBA,
        //                    itemHD.TIEUTHU,
        //                    itemHD.GIABAN,
        //                    ThueGTGT = itemHD.THUE,
        //                    PhiBVMT = itemHD.PHI,
        //                    itemHD.TONGCONG,
        //                    MaNV_GiaoTon = itemtableND.HoTen,
        //                };
        //    return LINQToDataTable(query);
        //}

        /// <summary>
        /// Lấy danh sách hóa đơn giao tồn đã đăng ngân bởi người được giao tồn
        /// </summary>
        /// <param name="MaNV_DangNgan"></param>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable GetDSDangNganTonByMaNVDate(string Loai,int MaNV_DangNgan, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemHD in _db.HOADONs
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemHD.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                            && itemHD.DangNgan_Ton == true && itemHD.MaNV_DangNgan == MaNV_DangNgan && itemHD.GB>=11 && itemHD.GB<=20
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                MaHD = itemHD.ID_HOADON,
                                NgayGiaiTrach = itemHD.NGAYGIAITRACH,
                                itemHD.SOHOADON,
                                Ky=itemHD.KY+"/"+itemHD.NAM,
                                MLT=itemHD.MALOTRINH,
                                itemHD.SOPHATHANH,
                                DanhBo = itemHD.DANHBA,
                                itemHD.TIEUTHU,
                                itemHD.GIABAN,
                                ThueGTGT = itemHD.THUE,
                                PhiBVMT = itemHD.PHI,
                                itemHD.TONGCONG,
                                MaNV_HanhThu = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemHD in _db.HOADONs
                                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_GiaoTon equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemHD.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                                && itemHD.DangNgan_Ton == true && itemHD.MaNV_DangNgan == MaNV_DangNgan && itemHD.GB > 20
                                orderby itemHD.MALOTRINH ascending
                                select new
                                {
                                    MaHD = itemHD.ID_HOADON,
                                    NgayGiaiTrach = itemHD.NGAYGIAITRACH,
                                    itemHD.SOHOADON,
                                    Ky = itemHD.KY + "/" + itemHD.NAM,
                                    MLT = itemHD.MALOTRINH,
                                    itemHD.SOPHATHANH,
                                    DanhBo = itemHD.DANHBA,
                                    itemHD.TIEUTHU,
                                    itemHD.GIABAN,
                                    ThueGTGT = itemHD.THUE,
                                    PhiBVMT = itemHD.PHI,
                                    itemHD.TONGCONG,
                                    MaNV_HanhThu = itemtableND.HoTen,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        /// <summary>
        /// Lấy danh sách hóa đơn giao tồn nhưng chưa đăng ngân
        /// </summary>
        /// <param name="MaNV_GiaoTon"></param>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        //public DataTable GetDSTonGiaoTonByMaNVDates1(int MaNV_GiaoTon, DateTime TuNgay, DateTime DenNgay)
        //{
        //    var query = from itemHD in _db.HOADONs
        //                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_GiaoTon equals itemND.MaND
        //                where itemHD.MaNV_GiaoTon == MaNV_GiaoTon && itemHD.NGAYGIAOTON.Value.Date >= TuNgay.Date && itemHD.NGAYGIAOTON.Value.Date <= DenNgay.Date
        //                && itemHD.NGAYGIAITRACH == null
        //                orderby itemHD.ID_HOADON ascending
        //                select new
        //                {
        //                    MaHD = itemHD.ID_HOADON,
        //                    NgayGiaiTrach = itemHD.NGAYGIAITRACH,
        //                    itemHD.SOHOADON,
        //                    Ky = itemHD.KY + "/" + itemHD.NAM,
        //                    MLT = itemHD.MALOTRINH,
        //                    itemHD.SOPHATHANH,
        //                    DanhBo = itemHD.DANHBA,
        //                    itemHD.TIEUTHU,
        //                    itemHD.GIABAN,
        //                    ThueGTGT = itemHD.THUE,
        //                    PhiBVMT = itemHD.PHI,
        //                    itemHD.TONGCONG,
        //                    MaNV_GiaoTon = itemND.HoTen,
        //                };
        //    return LINQToDataTable(query);
        //}

        public DataTable GetDSByDanhBo(string DanhBo)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.DANHBA == DanhBo
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            itemHD.SOPHATHANH,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            itemHD.MALOTRINH,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSBySoHoaDon_Quay(string SoHoaDon)
        {
            var query = from item in _db.HOADONs
                        where item.SOHOADON == SoHoaDon
                        select new
                        {
                            item.NGAYGIAITRACH,
                            item.NAM,
                            item.KY,
                            item.DOT,
                            item.SOHOADON,
                            item.SOPHATHANH,
                            DanhBo = item.DANHBA,
                            item.TIEUTHU,
                            item.GIABAN,
                            ThueGTGT = item.THUE,
                            PhiBVMT = item.PHI,
                            item.TONGCONG,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSBySoPhatHanh_Quay(decimal SoPhatHanh)
        {
            var query = from item in _db.HOADONs
                        where item.SOPHATHANH == SoPhatHanh
                        select new
                        {
                            item.NGAYGIAITRACH,
                            item.NAM,
                            item.KY,
                            item.DOT,
                            item.SOHOADON,
                            item.SOPHATHANH,
                            DanhBo = item.DANHBA,
                            item.TIEUTHU,
                            item.GIABAN,
                            ThueGTGT = item.THUE,
                            PhiBVMT = item.PHI,
                            item.TONGCONG,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDangNganQuayByMaNVNgayGiaiTrach(string Loai,int MaNV, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemHD in _db.HOADONs
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemHD.DangNgan_Quay == true && itemHD.MaNV_DangNgan == MaNV && itemHD.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && itemHD.GB >= 11 && itemHD.GB <= 20
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                itemHD.NGAYGIAITRACH,
                                itemHD.SOHOADON,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                MLT = itemHD.MALOTRINH,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                itemHD.TIEUTHU,
                                itemHD.GIABAN,
                                ThueGTGT = itemHD.THUE,
                                PhiBVMT = itemHD.PHI,
                                itemHD.TONGCONG,
                                HanhThu = itemtableND.HoTen,
                                To = itemtableND.TT_To.TenTo,
                                GiaBieu=itemHD.GB,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemHD in _db.HOADONs
                                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemHD.DangNgan_Quay == true && itemHD.MaNV_DangNgan == MaNV && itemHD.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && itemHD.GB > 20
                                orderby itemHD.MALOTRINH ascending
                                select new
                                {
                                    itemHD.NGAYGIAITRACH,
                                    itemHD.SOHOADON,
                                    Ky = itemHD.KY + "/" + itemHD.NAM,
                                    MLT = itemHD.MALOTRINH,
                                    DanhBo = itemHD.DANHBA,
                                    HoTen = itemHD.TENKH,
                                    itemHD.TIEUTHU,
                                    itemHD.GIABAN,
                                    ThueGTGT = itemHD.THUE,
                                    PhiBVMT = itemHD.PHI,
                                    itemHD.TONGCONG,
                                    HanhThu = itemtableND.HoTen,
                                    To = itemtableND.TT_To.TenTo,
                                    GiaBieu = itemHD.GB,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSDangNganChuyenKhoanByMaNVNgayGiaiTrach(string Loai,int MaNV, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemHD in _db.HOADONs
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemHD.DangNgan_ChuyenKhoan == true && itemHD.MaNV_DangNgan == MaNV && itemHD.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && itemHD.GB >= 11 && itemHD.GB <= 20
                            select new
                            {
                                itemHD.NGAYGIAITRACH,
                                itemHD.SOHOADON,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                MLT = itemHD.MALOTRINH,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                itemHD.TIEUTHU,
                                itemHD.GIABAN,
                                ThueGTGT = itemHD.THUE,
                                PhiBVMT = itemHD.PHI,
                                itemHD.TONGCONG,
                                HanhThu = itemtableND.HoTen,
                                To = itemtableND.TT_To.TenTo,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemHD in _db.HOADONs
                                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemHD.DangNgan_ChuyenKhoan == true && itemHD.MaNV_DangNgan == MaNV && itemHD.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && itemHD.GB > 20
                                select new
                                {
                                    itemHD.NGAYGIAITRACH,
                                    itemHD.SOHOADON,
                                    Ky = itemHD.KY + "/" + itemHD.NAM,
                                    MLT = itemHD.MALOTRINH,
                                    DanhBo = itemHD.DANHBA,
                                    HoTen = itemHD.TENKH,
                                    itemHD.TIEUTHU,
                                    itemHD.GIABAN,
                                    ThueGTGT = itemHD.THUE,
                                    PhiBVMT = itemHD.PHI,
                                    itemHD.TONGCONG,
                                    HanhThu = itemtableND.HoTen,
                                    To = itemtableND.TT_To.TenTo,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSByTienLon_To(string Loai, int MaNV, int Nam, int SoTien)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where item.NAM == Nam && item.MaNV_HanhThu == MaNV && item.TONGCONG >= SoTien && item.GB >= 11 && item.GB <= 20
                            orderby item.MALOTRINH ascending
                            select new
                            {
                                item.NGAYGIAITRACH,
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                DanhBo = item.DANHBA,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where item.NAM == Nam && item.MaNV_HanhThu == MaNV && item.TONGCONG >= SoTien && item.GB > 20
                                orderby item.MALOTRINH ascending
                                select new
                                {
                                    item.NGAYGIAITRACH,
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    DanhBo = item.DANHBA,
                                    item.TIEUTHU,
                                    item.GIABAN,
                                    ThueGTGT = item.THUE,
                                    PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSByTienLon_To(string Loai, int MaNV, int Nam, int Ky, int SoTien)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where item.NAM == Nam && item.KY == Ky && item.MaNV_HanhThu == MaNV && item.TONGCONG >= SoTien && item.GB >= 11 && item.GB <= 20
                            orderby item.MALOTRINH ascending
                            select new
                            {
                                item.NGAYGIAITRACH,
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                DanhBo = item.DANHBA,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where item.NAM == Nam && item.KY == Ky && item.MaNV_HanhThu == MaNV && item.TONGCONG >= SoTien && item.GB > 20
                                orderby item.MALOTRINH ascending
                                select new
                                {
                                    item.NGAYGIAITRACH,
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    DanhBo = item.DANHBA,
                                    item.TIEUTHU,
                                    item.GIABAN,
                                    ThueGTGT = item.THUE,
                                    PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        /// <summary>
        /// Lấy danh sách hóa đơn của nhân viên có số tiền lớn
        /// </summary>
        /// <param name="loai"></param>
        /// <param name="MaNV"></param>
        /// <param name="nam"></param>
        /// <param name="ky"></param>
        /// <param name="dot"></param>
        /// <param name="SoTien"></param>
        /// <returns></returns>
        public DataTable GetDSByTienLon_To(string Loai, int MaNV, int Nam, int Ky, int Dot, int SoTien)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.MaNV_HanhThu == MaNV && item.TONGCONG >= SoTien && item.GB >= 11 && item.GB <= 20
                            orderby item.MALOTRINH ascending
                            select new
                            {
                                item.NGAYGIAITRACH,
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                DanhBo = item.DANHBA,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.MaNV_HanhThu == MaNV && item.TONGCONG >= SoTien && item.GB > 20
                                orderby item.MALOTRINH ascending
                                select new
                                {
                                    item.NGAYGIAITRACH,
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    DanhBo = item.DANHBA,
                                    item.TIEUTHU,
                                    item.GIABAN,
                                    ThueGTGT = item.THUE,
                                    PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSByTienLon_Doi(string Loai, int MaTo, int Nam, int SoTien)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.NAM == Nam && item.TONGCONG >= SoTien && item.GB >= 11 && item.GB <= 20
                            select new
                            {
                                item.NGAYGIAITRACH,
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                DanhBo = item.DANHBA,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.NAM == Nam && item.TONGCONG >= SoTien && item.GB > 20
                                select new
                                {
                                    item.NGAYGIAITRACH,
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    DanhBo = item.DANHBA,
                                    item.TIEUTHU,
                                    item.GIABAN,
                                    ThueGTGT = item.THUE,
                                    PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSByTienLon_Doi(string Loai, int MaTo, int Nam, int Ky, int SoTien)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.NAM == Nam && item.KY == Ky && item.TONGCONG >= SoTien && item.GB >= 11 && item.GB <= 20
                            select new
                            {
                                item.NGAYGIAITRACH,
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                DanhBo = item.DANHBA,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.NAM == Nam && item.KY == Ky && item.TONGCONG >= SoTien && item.GB > 20
                                select new
                                {
                                    item.NGAYGIAITRACH,
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    DanhBo = item.DANHBA,
                                    item.TIEUTHU,
                                    item.GIABAN,
                                    ThueGTGT = item.THUE,
                                    PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSByTienLon_Doi(string Loai, int MaTo, int Nam, int Ky, int Dot, int SoTien)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.TONGCONG >= SoTien && item.GB >= 11 && item.GB <= 20
                            select new
                            {
                                item.NGAYGIAITRACH,
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                DanhBo = item.DANHBA,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.TONGCONG >= SoTien && item.GB > 20
                                select new
                                {
                                    item.NGAYGIAITRACH,
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    DanhBo = item.DANHBA,
                                    item.TIEUTHU,
                                    item.GIABAN,
                                    ThueGTGT = item.THUE,
                                    PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        /// <summary>
        /// Lấy danh sách hóa đơn thu 2 lần
        /// </summary>
        /// <param name="nam"></param>
        /// <param name="ky"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        public DataTable GetDSThu2Lan(int Nam, int Ky, int Dot)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.Thu2Lan == true
                        select new
                        {
                            MaHD = item.ID_HOADON,
                            item.NGAYGIAITRACH,
                            item.SOHOADON,
                            DanhBo = item.DANHBA,
                            item.TIEUTHU,
                            item.GIABAN,
                            ThueGTGT = item.THUE,
                            PhiBVMT = item.PHI,
                            item.TONGCONG,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSHoaDon0(int Nam, int Ky, string GiaBieu, string DinhMuc, string Code)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.TIEUTHU == 0 && itemHD.NAM == Nam && itemHD.KY == Ky
                            && itemHD.GB.Value.ToString().Contains(GiaBieu.ToString())
                            && itemHD.DM.Value.ToString().Contains(DinhMuc.ToString())
                            && itemHD.CODE.Contains(Code)
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
                            itemHD.SOPHATHANH,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            GiaBieu = itemHD.GB,
                            DinhMuc = itemHD.DM,
                            itemHD.CODE,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            itemHD.TIEUTHU,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSHoaDon0(int Nam, string GiaBieu, string DinhMuc, string Code)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.TIEUTHU == 0 && itemHD.NAM == Nam
                            && itemHD.GB.Value.ToString().Contains(GiaBieu.ToString())
                            && itemHD.DM.Value.ToString().Contains(DinhMuc.ToString())
                            && itemHD.CODE.Contains(Code)
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
                            itemHD.SOPHATHANH,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            GiaBieu = itemHD.GB,
                            DinhMuc = itemHD.DM,
                            itemHD.CODE,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            itemHD.TIEUTHU,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSTimKiem(string DanhBo, string HoTen, string DiaChi)
        {
            string sql = "select ID_HOADON as MaHD,DANHBA as DanhBo,MALOTRINH as MLT,TENKH as HoTen,(SO+' '+DUONG) as DiaChi,GB as GiaBieu,DM as DinhMuc,SoHoaDon,"
                + "(convert(varchar(2),KY)+'/'+convert(varchar(4),NAM)) as Ky,TieuThu,GiaBan,Thue as ThueGTGT,Phi as PhiBVMT,TongCong,NgayGiaiTrach,b.HoTen as DangNgan,c.HoTen as HanhThu,NgayDN"
                + ",DENNGAY as NgayDoc,CSMOI as ChiSo"
                + " from HOADON a left join TT_NguoiDung b on a.MaNV_DangNgan=b.MaND"
                + " left join TT_NguoiDung c on a.MaNV_HanhThu=c.MaND"
                + " left join (select MaHD,NgayDN from TT_DongNuoc a,TT_CTDongNuoc b,TT_KQDongNuoc c where a.MaDN=b.MaDN and a.MaDN=c.MaDN) as DongNuoc on  a.ID_HOADON=DONGNUOC.MaHD"
                + " where a.DANHBA like '%" + DanhBo + "%' and a.TENKH like '%" + HoTen + "%' and (SO+' '+DUONG) like '%" + DiaChi + "%'"
                + "order by ID_HOADON desc";

            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public decimal TinhGiaBanBinhQuanByNamKy(int Nam, int Ky)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == Nam && item.KY == Ky
                        select new
                        {
                            item.GIABAN,
                            item.TIEUTHU,
                        };
            return query.ToList().Select(item => item.GIABAN).Sum().Value / query.ToList().Select(item => item.TIEUTHU).Sum().Value;
        }

        public decimal TinhGiaBanBinhQuanByNam(int Nam)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == Nam
                        select new
                        {
                            item.GIABAN,
                            item.TIEUTHU,
                        };
            return query.ToList().Select(item => item.GIABAN).Sum().Value / query.ToList().Select(item => item.TIEUTHU).Sum().Value;
        }

        public void PhanTichDoanhThuByNamKy(int Nam, int Ky, string GiaBieu, string DinhMuc, out decimal DoanhThu, out decimal SanLuong)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == Nam && item.KY == Ky
                            && item.GB.Value.ToString().Contains(GiaBieu.ToString())
                            && item.DM.Value.ToString().Contains(DinhMuc.ToString())
                        select new
                        {
                            item.GIABAN,
                            item.TIEUTHU,
                        };
            DoanhThu = query.ToList().Select(item => item.GIABAN).Sum().Value;
            SanLuong = query.ToList().Select(item => item.TIEUTHU).Sum().Value;
        }

        public void PhanTichDoanhThuByNam(int Nam, string GiaBieu, string DinhMuc, out decimal DoanhThu, out decimal SanLuong)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == Nam
                            && item.GB.Value.ToString().Contains(GiaBieu.ToString())
                            && item.DM.Value.ToString().Contains(DinhMuc.ToString())
                        select new
                        {
                            item.GIABAN,
                            item.TIEUTHU,
                        };
            DoanhThu = query.ToList().Select(item => item.GIABAN).Sum().Value;
            SanLuong = query.ToList().Select(item => item.TIEUTHU).Sum().Value;
        }

        public int CountDSTon()
        {
            return _db.HOADONs.Count(item => item.NGAYGIAITRACH == null);
        }

        public int CountBySoPhatHanhs(decimal TuSoPhatHanh, decimal DenSoPhatHanh)
        {
            return _db.HOADONs.Count(item => item.SOPHATHANH >= TuSoPhatHanh && item.SOPHATHANH <= DenSoPhatHanh);
        }

        //public List<HOADON> GetDSBySoPhatHanhNamsKyDot(int MaTo, string loai, decimal tusophathanh, decimal densophathanh, int nam, int ky, int dot)
        //{
        //    if (loai == "TG")
        //        return _db.HOADONs.Where(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
        //                                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                                && item.SOPHATHANH >= tusophathanh && item.SOPHATHANH <= densophathanh
        //                                && item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB >= 11 && item.GB <= 20).ToList();
        //    else
        //        if (loai == "CQ")
        //            return _db.HOADONs.Where(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
        //                            && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                            && item.SOPHATHANH >= tusophathanh && item.SOPHATHANH <= densophathanh
        //                            && item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB > 20).ToList();
        //        else
        //            return null;

        //}

        public bool DangNgan(string Loai, string SoHoaDon, int MaNV)
        {
            try
            {
                string sql = "";
                if (Loai == "HanhThu")
                    sql = "update HOADON set DangNgan_HanhThu=1,MaNV_DangNgan=" + MaNV + ",NGAYGIAITRACH='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                            + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null"; //" and NGAYGIAITRACH is null";
                else
                    if (Loai == "Quay")
                        sql = "update HOADON set DangNgan_Quay=1,MaNV_DangNgan=" + MaNV + ",NGAYGIAITRACH='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                                + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null"; //" and NGAYGIAITRACH is null";
                    else
                        if (Loai == "ChuyenKhoan")
                            sql = "update HOADON set DangNgan_ChuyenKhoan=1,MaNV_DangNgan=" + MaNV + ",NGAYGIAITRACH='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                                + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null"; //" and NGAYGIAITRACH is null";
                        else
                            if (Loai == "Ton")
                                sql = "update HOADON set DangNgan_Ton=1,MaNV_DangNgan=" + MaNV + ",NGAYGIAITRACH='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                                    + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null";
                ExecuteNonQuery_Transaction(sql);
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool DangNgan(string Loai, string SoHoaDon, int MaNV, DateTime NgayGiaiTrach)
        {
            try
            {
                string sql = "";
                if (Loai == "")
                    sql = "update HOADON set MaNV_DangNgan=" + MaNV + ",NGAYGIAITRACH='" + NgayGiaiTrach.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                            + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null";
                else
                    if (Loai == "HanhThu")
                        sql = "update HOADON set DangNgan_HanhThu=1,MaNV_DangNgan=" + MaNV + ",NGAYGIAITRACH='" + NgayGiaiTrach.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                                + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null";
                    else
                        if (Loai == "Quay")
                            sql = "update HOADON set DangNgan_Quay=1,MaNV_DangNgan=" + MaNV + ",NGAYGIAITRACH='" + NgayGiaiTrach.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                                    + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null";
                        else
                            if (Loai == "ChuyenKhoan")
                                sql = "update HOADON set DangNgan_ChuyenKhoan=1,MaNV_DangNgan=" + MaNV + ",NGAYGIAITRACH='" + NgayGiaiTrach.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                                    + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null";
                            else
                                if (Loai == "Ton")
                                    sql = "update HOADON set DangNgan_Ton=1,MaNV_DangNgan=" + MaNV + ",NGAYGIAITRACH='" + NgayGiaiTrach.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                                        + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null";
                return ExecuteNonQuery_Transaction(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaDangNgan(string Loai, string SoHoaDon, int MaNV)
        {
            try
            {
                string sql = "";
                if (Loai == "")
                    sql = "update HOADON set MaNV_DangNgan=null,NGAYGIAITRACH=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                           + "where SOHOADON='" + SoHoaDon + "' and MaNV_DangNgan=" + MaNV;
                else
                    if (Loai == "HanhThu")
                        sql = "update HOADON set DangNgan_HanhThu=0,MaNV_DangNgan=null,NGAYGIAITRACH=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                               + "where SOHOADON='" + SoHoaDon + "' and DangNgan_HanhThu=1 and MaNV_DangNgan=" + MaNV;
                    else
                        if (Loai == "Quay")
                            sql = "update HOADON set DangNgan_Quay=0,MaNV_DangNgan=null,NGAYGIAITRACH=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                                   + "where SOHOADON='" + SoHoaDon + "' and DangNgan_Quay=1 and MaNV_DangNgan=" + MaNV;
                        else
                            if (Loai == "ChuyenKhoan")
                                sql = "update HOADON set DangNgan_ChuyenKhoan=0,MaNV_DangNgan=null,NGAYGIAITRACH=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                                       + "where SOHOADON='" + SoHoaDon + "' and DangNgan_ChuyenKhoan=1 and MaNV_DangNgan=" + MaNV;
                            else
                                if (Loai == "Ton")
                                    sql = "update HOADON set DangNgan_Ton=0,MaNV_DangNgan=null,NGAYGIAITRACH=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                                           + "where SOHOADON='" + SoHoaDon + "' and DangNgan_Ton=1 and MaNV_DangNgan=" + MaNV;
                return ExecuteNonQuery_Transaction(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaDangNgan(string SoHoaDon)
        {
            try
            {
                string sql = "";
                    sql = "update HOADON set DangNgan_HanhThu=0,DangNgan_Quay=0,DangNgan_ChuyenKhoan=0,DangNgan_Ton=0,MaNV_DangNgan=null,NGAYGIAITRACH=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                           + "where SOHOADON='" + SoHoaDon + "'";
                return ExecuteNonQuery_Transaction(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool GiaoTon(string SoHoaDon, int MaNV_GiaoTon)
        {
            try
            {
                string sql = "update HOADON set MaNV_HanhThuTruoc=MaNV_HanhThu,MaNV_HanhThu=" + MaNV_GiaoTon + ",NGAYGIAOTON='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                                + "where SOHOADON='" + SoHoaDon + "' and MaNV_DangNgan is null";
                return ExecuteNonQuery_Transaction(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaGiaoTon(string SoHoaDon)
        {
            try
            {
                string sql = "update HOADON set MaNV_HanhThu=MaNV_HanhThuTruoc,MaNV_HanhThuTruoc=null,NGAYGIAOTON=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                                + "where SOHOADON='" + SoHoaDon + "' and MaNV_DangNgan is null";
                return ExecuteNonQuery_Transaction(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        //public bool DangNganTon(string sohoadon, int MaNV)
        //{
        //    try
        //    {
        //        string sql = "update HOADON set DangNgan_Ton=1,MaNV_DangNgan=" + MaNV + ",NGAYGIAITRACH='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
        //                        + "where SOHOADON='" + sohoadon + "' and MaNV_DangNgan is null";
        //        return ExecuteNonQuery_Transaction(sql);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        //        return false;
        //    }
        //}

        //public bool XoaDangNganTon(string sohoadon, int MaNV)
        //{
        //    try
        //    {
        //        string sql = "update HOADON set DangNgan_Ton=0,MaNV_DangNgan=null,NGAYGIAITRACH=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
        //                           + "where SOHOADON='" + sohoadon + "' and DangNgan_Ton=1 and MaNV_DangNgan=" + MaNV;
        //        return ExecuteNonQuery_Transaction(sql);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        //        return false;
        //    }
        //}

        public bool Thu2Lan(string SoHoaDon)
        {
            try
            {
                string sql = "";
                sql = "update HOADON set Thu2Lan=1 where SOHOADON='" + SoHoaDon + "'";
                return ExecuteNonQuery_Transaction(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ChuyenNoKhoDoi(string SoHoaDon)
        {
            try
            {
                string sql = "";
                sql = "update HOADON set ChuyenNoKhoDoi=1 where SOHOADON='" + SoHoaDon + "'";
                return ExecuteNonQuery_Transaction(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaChuyenNoKhoDoi(string SoHoaDon)
        {
            try
            {
                string sql = "";
                sql = "update HOADON set ChuyenNoKhoDoi=0 where SOHOADON='" + SoHoaDon + "'";
                return ExecuteNonQuery_Transaction(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }
    }

}
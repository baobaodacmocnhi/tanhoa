using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;
using System.Globalization;
using ThuTien.DAL.ChuyenKhoan;

namespace ThuTien.DAL.Doi
{
    class CHoaDon : CDAL
    {
        CChanHoaDonAuto _cChanHoaDonAuto = new CChanHoaDonAuto();

        /// <summary>
        /// Thêm hóa đơn mới từ billing (.dat)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Them(string path)
        {
            try
            {
                //this.BeginTransaction();
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
                        hoadon.TIEUTHUSH = int.Parse(contents[31]);
                    if (!string.IsNullOrWhiteSpace(contents[32]))
                        hoadon.TIEUTHUHCSN = int.Parse(contents[32]);
                    if (!string.IsNullOrWhiteSpace(contents[33]))
                        hoadon.TIEUTHUSX = int.Parse(contents[33]);
                    if (!string.IsNullOrWhiteSpace(contents[34]))
                        hoadon.TIEUTHUDV = int.Parse(contents[34]);
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
                    hoadon.MALOTRINH = hoadon.DOT.ToString("00") + hoadon.MAY + hoadon.STT;

                    //string Quan = "", Phuong = "", CoDH = "", MaDMA = "";
                    //_cCapNuocTanHoa.GetDMA(hoadon.DANHBA, out Quan, out Phuong, out CoDH, out MaDMA);
                    //hoadon.Quan = Quan;
                    //hoadon.Phuong = Phuong;
                    //hoadon.CoDH = CoDH;
                    //hoadon.MaDMA = MaDMA;
                    //if (CheckByNamKyDot(hoadon.NAM, hoadon.KY, hoadon.DOT.Value))
                    //{
                    //    this.Rollback();
                    //    System.Windows.Forms.MessageBox.Show("Năm " + hoadon.NAM + "; Kỳ " + hoadon.KY + "; Đợt " + hoadon.DOT.Value + " đã có rồi", "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    //    return false;
                    //}
                    if (_db.HOADONs.Any(item => item.SOHOADON == hoadon.SOHOADON))
                    {
                        _db.ExecuteCommand("update HOADON set HOPDONG='" + hoadon.HOPDONG + "',GB=" + hoadon.GB + ",DM=" + hoadon.DM.Value + ",CODE='" + hoadon.CODE + "',CSCU=" + hoadon.CSCU.Value + ",CSMOI=" + hoadon.CSMOI.Value + ",TIEUTHU=" + hoadon.TIEUTHU.Value + ",GIABAN=" + hoadon.GIABAN.Value + ",THUE=" + hoadon.THUE.Value + ",PHI=" + hoadon.PHI.Value + ",TONGCONG=" + hoadon.TONGCONG.Value + ",SOPHATHANH='" + hoadon.SOPHATHANH + "' where SOHOADON='" + hoadon.SOHOADON + "'");
                    }
                    else
                        _db.HOADONs.InsertOnSubmit(hoadon);
                    _db.SubmitChanges();
                }

                //this.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                //this.Rollback();
                Refresh();
                throw ex;
            }
        }

        public bool Them(HOADON hoadon)
        {
            try
            {
                hoadon.ID_HOADON = _db.HOADONs.Max(item => item.ID_HOADON) + 1;
                hoadon.CreateBy = CNguoiDung.MaND;
                hoadon.CreateDate = DateTime.Now;
                _db.HOADONs.InsertOnSubmit(hoadon);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
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
                throw ex;
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
                    string sql = "update HOADON set MaNV_HanhThu=" + MaNV + ",DOTCHIA=" + DotChia + ",NGAYGIAO='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() "
                                + "where SOPHATHANH>='" + TuSoPhatHanh + "' and SOPHATHANH<='" + DenSoPhatHanh + "' and NAM=" + Nam + " and KY=" + Ky + " and DOT=" + Dot + " and GB>=10 and GB<=20 "
                                + "and MAY>=" + ExecuteQuery_DataTable("select TuCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + " and MAY<=" + ExecuteQuery_DataTable("select DenCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + "";
                    LinQ_ExecuteNonQuery(sql);
                }
                else
                    if (Loai == "CQ")
                    {
                        //_db.HOADONs.Where(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).

                        //            && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        //            && Convert.ToInt32(item.MALOTRINH) >= int.Parse(tumlt) && Convert.ToInt32(item.MALOTRINH) <= int.Parse(denmlt)
                        //            && item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB > 20).ToList()
                        //            .ForEach(item => { item.MaNV_HanhThu = MaNV; item.ModifyBy = CNguoiDung.MaND; item.ModifyDate = DateTime.Now; });
                        string sql = "update HOADON set MaNV_HanhThu=" + MaNV + ",DOTCHIA=" + DotChia + ",NGAYGIAO='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() "
                                    + "where SOPHATHANH>='" + TuSoPhatHanh + "' and SOPHATHANH<='" + DenSoPhatHanh + "' and NAM=" + Nam + " and KY=" + Ky + " and DOT=" + Dot + " and GB>20 "
                                    + "and MAY>=" + ExecuteQuery_DataTable("select TuCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + " and MAY<=" + ExecuteQuery_DataTable("select DenCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + "";
                        LinQ_ExecuteNonQuery(sql);
                    }
                    else
                        if (Loai == "")
                        {
                            string sql = "update HOADON set MaNV_HanhThu=" + MaNV + ",DOTCHIA=" + DotChia + ",NGAYGIAO='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() "
                                        + "where SOPHATHANH>='" + TuSoPhatHanh + "' and SOPHATHANH<='" + DenSoPhatHanh + "' and NAM=" + Nam + " and KY=" + Ky + " and DOT=" + Dot
                                        + " and MAY>=" + ExecuteQuery_DataTable("select TuCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + " and MAY<=" + ExecuteQuery_DataTable("select DenCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + "";
                            LinQ_ExecuteNonQuery(sql);
                        }
                //_db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
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
                Refresh();
                throw ex;
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
                throw ex;
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
                    string sql = "update HOADON set MaNV_HanhThu=null,DOTCHIA=null,NGAYGIAO=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate()"
                                + " where SOPHATHANH>='" + TuSoPhatHanh + "' and SOPHATHANH<='" + DenSoPhatHanh + "' and NAM=" + Nam + " and KY=" + Ky + " and DOT=" + Dot + " and GB>=10 and GB<=20"
                                + " and MAY>=" + ExecuteQuery_DataTable("select TuCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + " and MAY<=" + ExecuteQuery_DataTable("select DenCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + "";
                    LinQ_ExecuteNonQuery(sql);
                }
                else
                    if (Loai == "CQ")
                    {
                        //_db.HOADONs.Where(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                        //            && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        //            && Convert.ToInt32(item.MALOTRINH) >= int.Parse(tumlt) && Convert.ToInt32(item.MALOTRINH) <= int.Parse(denmlt)
                        //            && item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB > 20).ToList()
                        //            .ForEach(item => { item.MaNV_HanhThu = null; item.ModifyBy = CNguoiDung.MaND; item.ModifyDate = DateTime.Now; });
                        string sql = "update HOADON set MaNV_HanhThu=null,DOTCHIA=null,NGAYGIAO=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate()"
                                    + " where SOPHATHANH>='" + TuSoPhatHanh + "' and SOPHATHANH<='" + DenSoPhatHanh + "' and NAM=" + Nam + " and KY=" + Ky + " and DOT=" + Dot + " and GB>20"
                                    + " and MAY>=" + ExecuteQuery_DataTable("select TuCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + " and MAY<=" + ExecuteQuery_DataTable("select DenCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + "";
                        LinQ_ExecuteNonQuery(sql);
                    }
                    else
                        if (Loai == "")
                        {
                            string sql = "update HOADON set MaNV_HanhThu=null,DOTCHIA=null,NGAYGIAO=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate()"
                                        + " where SOPHATHANH>='" + TuSoPhatHanh + "' and SOPHATHANH<='" + DenSoPhatHanh + "' and NAM=" + Nam + " and KY=" + Ky + " and DOT=" + Dot
                                        + " and MAY>=" + ExecuteQuery_DataTable("select TuCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + " and MAY<=" + ExecuteQuery_DataTable("select DenCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + "";
                            LinQ_ExecuteNonQuery(sql);
                        }
                //_db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckExist(string DanhBo, int Nam, int Ky)
        {
            return _db.HOADONs.Any(item => item.DANHBA == DanhBo && item.NAM == Nam && item.KY == Ky);
        }

        /// <summary>
        /// Kiểm tra tồn tại
        /// </summary>
        /// <param name="nam"></param>
        /// <param name="ky"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        //public bool CheckExist(string DanhBo, int Nam, int Ky, int Dot)
        //{
        //    return _db.HOADONs.Any(item => item.DANHBA == DanhBo && item.NAM == Nam && item.KY == Ky && item.DOT == Dot);
        //}

        public bool CheckExist(string SoHoaDon)
        {
            return _db.HOADONs.Any(item => item.SOHOADON == SoHoaDon);
        }

        public bool CheckExist_HD0(string DanhBo, int Nam, int Ky)
        {
            return _db.HOADONs.Any(item => item.DANHBA == DanhBo && item.NAM == Nam && item.KY == Ky && item.TIEUTHU == 0);
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
                    if (Loai == "")
                        return _db.HOADONs.Any(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                   && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                   && item.SOPHATHANH == SoPhatHanh && item.NAM == Nam && item.KY == Ky && item.DOT == Dot);
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

        public bool CheckDangNganChuyenKhoanTienMat(string SoHoaDon)
        {
            return _db.HOADONs.Any(item => item.SOHOADON == SoHoaDon && item.DangNgan_ChuyenKhoan == true && item.TienMat != null);
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

        /// <summary>
        /// Kiểm tra đợt hóa đơn chỉ được xóa trong ngày. phục vụ nút hủy đăng ngân trong hành thu
        /// </summary>
        /// <param name="MaNV_DangNgan"></param>
        /// <param name="Nam"></param>
        /// <param name="Ky"></param>
        /// <param name="Dot"></param>
        /// <returns></returns>
        public bool CheckCoTheXoaDangNgan(int MaNV_DangNgan, int Nam, int Ky, int Dot)
        {
            //return _db.HOADONs.Any(item => item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.DangNgan_HanhThu == true
            //    && item.MaNV_DangNgan == MaNV_DangNgan && item.GB >= 11 && item.GB <= 20 && item.NGAYGIAITRACH.Value.Date == DateTime.Now.Date);
            return _db.HOADONs.Any(item => item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.DangNgan_HanhThu == true
                && item.MaNV_DangNgan == MaNV_DangNgan && item.NGAYGIAITRACH.Value.Date == DateTime.Now.Date);
        }

        /// <summary>
        /// Kiểm tra nhân viên đăng ngân có ĐCHĐ
        /// </summary>
        /// <param name="MaNV_DangNgan"></param>
        /// <param name="NgayGiaiTrach"></param>
        /// <returns></returns>
        public bool checkExist_DangNganCoDCHD(int MaNV_DangNgan, DateTime NgayGiaiTrach)
        {
            return _db.HOADONs.Any(item => item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.MaNV_DangNgan == MaNV_DangNgan && item.DCHD == true);
        }

        public bool checkExists_KyMoi(string Ky)
        {
            string[] Kys = Ky.Split('/');
            if (int.Parse(Kys[1]) > DateTime.Now.Year)
                return true;
            else
                if (int.Parse(Kys[1]) == DateTime.Now.Year)
                {
                    if (int.Parse(Kys[0]) > DateTime.Now.Month)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
        }

        public HOADON Get(int MaHD)
        {
            return _db.HOADONs.SingleOrDefault(item => item.ID_HOADON == MaHD);
        }

        public HOADON Get(string SoHoaDon)
        {
            return _db.HOADONs.SingleOrDefault(item => item.SOHOADON == SoHoaDon);
        }

        public HOADON Get(string DanhBo, int Nam, int Ky)
        {
            return _db.HOADONs.SingleOrDefault(item => item.DANHBA == DanhBo && item.NAM == Nam && item.KY == Ky);
        }

        public HOADON Get(string DanhBo, int Nam, int Ky, int Dot)
        {
            return _db.HOADONs.SingleOrDefault(item => item.DANHBA == DanhBo && item.NAM == Nam && item.KY == Ky && item.DOT == Dot);
        }

        public HOADON GetMoiNhat(string DanhBo)
        {
            if (_db.HOADONs.Any(item => item.DANHBA == DanhBo))
                return _db.HOADONs.Where(item => item.DANHBA == DanhBo).ToList().OrderByDescending(item => item.ID_HOADON).First();
            else
                return null;
        }

        public HOADON GetMoiNhi(string DanhBo)
        {
            if (_db.HOADONs.Any(item => item.DANHBA == DanhBo))
                return _db.HOADONs.Where(item => item.DANHBA == DanhBo).ToList().OrderByDescending(item => item.ID_HOADON).Skip(1).First();
            else
                return null;
        }

        public HOADON GetTonMoiNhat(string DanhBo)
        {
            if (_db.HOADONs.Any(item => item.DANHBA == DanhBo && item.NGAYGIAITRACH == null))
                return _db.HOADONs.Where(item => item.DANHBA == DanhBo && item.NGAYGIAITRACH == null).ToList().OrderByDescending(item => item.ID_HOADON).First();
            else
                return null;
        }

        public string GetMLT(string DanhBo)
        {
            if (GetMoiNhat(DanhBo) != null)
                return GetMoiNhat(DanhBo).MALOTRINH;
            else
                return "";
        }

        public string GetHanhThu(string SoHoaDon)
        {
            return (from itemHD in _db.HOADONs
                    join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND
                    where itemHD.SOHOADON == SoHoaDon
                    select new { itemND.HoTen }).FirstOrDefault().HoTen;
        }

        public List<HOADON> GetDSTon(string DanhBo)
        {
            if (_db.HOADONs.Where(item => item.DANHBA == DanhBo && item.NGAYGIAITRACH == null).Count() > 0)
                return _db.HOADONs.Where(item => item.DANHBA == DanhBo && item.NGAYGIAITRACH == null).OrderBy(item => item.ID_HOADON).ToList();
            else
                return null;
        }

        public List<HOADON> getDSTon_KhongChanTienDu_KhongDCHD(string DanhBo)
        {
            if (_db.HOADONs.Where(item => item.DANHBA == DanhBo && item.NGAYGIAITRACH == null && item.ChanTienDu == false && item.DCHD == false ).Count() > 0)
                return _db.HOADONs.Where(item => item.DANHBA == DanhBo && item.NGAYGIAITRACH == null && item.ChanTienDu == false && item.DCHD == false ).OrderBy(item => item.ID_HOADON).ToList();
            else
                return null;
        }

        public List<HOADON> GetDSTon_CoChanTienDu(string DanhBo)
        {
            if (_db.HOADONs.Where(item => item.DANHBA == DanhBo && (item.NGAYGIAITRACH == null || item.ChanTienDu == true) ).Count() > 0)
                return _db.HOADONs.Where(item => item.DANHBA == DanhBo && (item.NGAYGIAITRACH == null || item.ChanTienDu == true) ).ToList().OrderBy(item => item.ID_HOADON).ToList();
            else
                return null;
        }

        public List<HOADON> GetDSTon_CoChanTienDu_TruHoNgheo(string DanhBo)
        {
            if (_db.HOADONs.Where(item => item.DANHBA == DanhBo && (item.NGAYGIAITRACH == null || item.ChanTienDu == true && (item.GB != 10 && item.DinhMucHN == null))).Count() > 0)
                return _db.HOADONs.Where(item => item.DANHBA == DanhBo && (item.NGAYGIAITRACH == null || item.ChanTienDu == true && (item.GB != 10 && item.DinhMucHN == null))).OrderBy(item => item.ID_HOADON).ToList();
            else
                return null;
        }

        public DataTable GetTongTon_GroupKy(int Nam)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == Nam && (item.NGAYGIAITRACH == null || item.KhoaTienDu == true)
                        group item by item.KY into itemGroup
                        select new
                        {
                            Ky = itemGroup.Key,
                            TongHD = itemGroup.Count(),
                            TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                        };
            return LINQToDataTable(query);
        }

        /// <summary>
        /// Lấy danh sách năm có trong hóa đơn
        /// </summary>
        /// <returns></returns>
        public DataTable GetNam()
        {
            //return this.LINQToDataTable(_db.HOADONs.Select(item => new { item.NAM }).Distinct().OrderByDescending(item => item.NAM).ToList());
            return LINQToDataTable(_db.ViewGetNamHDs.OrderByDescending(item => item.NAM));
            //return ExecuteQuery_DataTable("select * from ViewGetNamHD");
        }

        /// <summary>
        /// Lấy Sum thông tin hóa đơn
        /// </summary>
        /// <param name="nam"></param>
        /// <param name="ky"></param>
        /// <returns></returns>
        public DataTable GetTongByNamKy(int Nam, int Ky)
        {
            //var query = from item in _db.HOADONs
            //            where item.NAM == Nam && item.KY == Ky
            //            //orderby item.DOT ascending
            //            group item by item.DOT into itemGroup
            //            select new
            //            {
            //                Dot = itemGroup.Key,
            //                TongHD = itemGroup.Count(),
            //                TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
            //                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
            //                TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
            //                TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
            //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
            //                itemGroup.FirstOrDefault().CreateDate,
            //                HD0 = itemGroup.Count(groupItem => groupItem.TIEUTHU == 0),
            //            };
            //return LINQToDataTable(query.OrderBy(item => item.Dot));
            string sql = "select DOT,TongHD=COUNT(ID_HOADON),TongTieuThu=SUM(TIEUTHU),TongGiaBan=SUM(GIABAN),TongThueGTGT=SUM(THUE),"
                        + " TongPhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG),HD0=COUNT(case when TIEUTHU = 0 then 1 else null end),"
                        + " SONGAY=MAX(SONGAY),CreateDate=MAX(CreateDate)"
                        + " from HOADON where NAM=" + Nam + " and KY=" + Ky
                        + " group by DOT";
            return ExecuteQuery_DataTable(sql);
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
                                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                            };
                return LINQToDataTable(query.OrderBy(item => item.TuMLT));
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
                                    TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                    TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                    TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                    TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                };
                    return LINQToDataTable(query.OrderBy(item => item.TuMLT));
                }
                else
                    if (Loai == "")
                    {
                        var query = from item in _db.HOADONs
                                    where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        && item.NAM == Nam && item.KY == Ky && item.DOT == Dot
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
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongHDTruoc = _db.HOADONs.Count(itemA => itemA.NGAYGIAITRACH == null && itemA.MaNV_HanhThu == itemGroup.Key.MaNV_HanhThu && itemA.DOT == Dot && (itemA.NAM < Nam || (itemA.KY < Ky && itemA.NAM == Nam))),
                                        TongCongTruoc = _db.HOADONs.Where(itemA => itemA.NGAYGIAITRACH == null && itemA.MaNV_HanhThu == itemGroup.Key.MaNV_HanhThu && itemA.DOT == Dot && (itemA.NAM < Nam || (itemA.KY < Ky && itemA.NAM == Nam))).Sum(itemA => itemA.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.TuMLT));
                    }
            return null;
        }

        public DataTable getTongGiaoHoaDon(int MaTo, int Nam, int Ky)
        {
            string sql = "select nd.STT,HanhThu=nd.HoTen,DOT,TongHD=COUNT(ID_HOADON) from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu=nd.MaND"
                        + " where NAM=" + Nam + " and KY=" + Ky + " and MAY>=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ") and MAY<=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " group by nd.STT,nd.HoTen,DOT"
                        + " order by nd.STT";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTon_To(int MaTo)
        {
            string sql = "declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon,TongCongTonBilling,TongHDTonThucTe,TongGiaBanTonThucTe,TongCongTonThucTe,TongCongTonBillingThucTe"
                        + " from"
                        + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " group by nd.MaND,nd.HoTen) tong"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NGAYGIAITRACH is not null"
                        + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.GIABAN) as TongGiaBanTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe,sum(hd.TONGCONG) as TongCongTonBillingThucTe"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                        + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                        + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                        + " and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                        + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTon_To(int MaTo, int Nam)
        {
            string sql = "declare @Nam int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon,TongCongTonBilling,TongHDTonThucTe,TongGiaBanTonThucTe,TongCongTonThucTe,TongCongTonBillingThucTe"
                        + " from"
                        + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where "
                        + " and NAM=@Nam"
                        + " group by nd.MaND,nd.HoTen,NAM) tong"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and NGAYGIAITRACH is not null"
                        + " group by nd.MaND,nd.HoTen,NAM) thu on tong.MaND=thu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen,NAM) ton on tong.MaND=ton.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.GIABAN) as TongGiaBanTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe,sum(hd.TONGCONG) as TongCongTonBillingThucTe"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                        + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                        + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                        + " and NAM=@Nam and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                        + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTon_To(int MaTo, int Nam, int Ky)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon,TongCongTonBilling,TongHDTonThucTe,TongGiaBanTonThucTe,TongCongTonThucTe,TongCongTonBillingThucTe"
                        + " from"
                        + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky"
                        + " group by nd.MaND,nd.HoTen,KY,NAM) tong"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and NGAYGIAITRACH is not null"
                        + " group by nd.MaND,nd.HoTen,KY,NAM) thu on tong.MaND=thu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen,KY,NAM) ton on tong.MaND=ton.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.GIABAN) as TongGiaBanTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe,sum(hd.TONGCONG) as TongCongTonBillingThucTe"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                        + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                        + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                        + " and NAM=@Nam and KY=@Ky and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                        + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTon_To(int MaTo, int Nam, int Ky, int Dot)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @Dot int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @Dot=" + Dot + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon,TongCongTonBilling,TongHDTonThucTe,TongGiaBanTonThucTe,TongCongTonThucTe,TongCongTonBillingThucTe"
                        + " from"
                        + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT=@Dot"
                        + " group by nd.MaND,nd.HoTen,DOT,KY,NAM) tong"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT=@Dot and NGAYGIAITRACH is not null"
                        + " group by nd.MaND,nd.HoTen,DOT,KY,NAM) thu on tong.MaND=thu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen,DOT,KY,NAM) ton on tong.MaND=ton.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.GIABAN) as TongGiaBanTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe,sum(hd.TONGCONG) as TongCongTonBillingThucTe"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                        + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                        + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                        + " and NAM=@Nam and KY=@Ky and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                        + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTon_To(int MaTo, int Nam, int Ky, int FromDot, int ToDot)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon,TongCongTonBilling,TongHDTonThucTe,TongGiaBanTonThucTe,TongCongTonThucTe,TongCongTonBillingThucTe"
                        + " from"
                        + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot"
                        + " group by nd.MaND,nd.HoTen,KY,NAM) tong"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and NGAYGIAITRACH is not null"
                        + " group by nd.MaND,nd.HoTen,KY,NAM) thu on tong.MaND=thu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen,KY,NAM) ton on tong.MaND=ton.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.GIABAN) as TongGiaBanTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe,sum(hd.TONGCONG) as TongCongTonBillingThucTe"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                        + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                        + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                        + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTon_To(int MaTo, DateTime NgayGiaiTrach)
        {
            string sql = "declare @NgayGiaiTrach date;"
                    + " declare @TuCuonGCS int;"
                    + " declare @DenCuonGCS int;"
                    + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                    + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                    + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                    + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon,TongCongTonBilling,TongHDTonThucTe,TongGiaBanTonThucTe,TongCongTonThucTe,TongCongTonBillingThucTe"
                    + " from"
                    + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                    + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                    + " group by nd.MaND,nd.HoTen) tong"
                    + " left join"
                    + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                    + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                    + " and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach"
                    + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                    + " left join"
                    + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                    + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                    + " and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                    + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                    + " left join"
                    + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.GIABAN) as TongGiaBanTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe,sum(hd.TONGCONG) as TongCongTonBillingThucTe"
                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                    + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                    + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                    + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                    + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                    + " and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                    + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                    + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTonDenKy_To(int MaTo, int Nam, int Ky)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon,TongCongTonBilling,TongHDTonThucTe,TongGiaBanTonThucTe,TongCongTonThucTe,TongCongTonBillingThucTe"
                        + " from"
                        + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky))"
                        + " group by nd.MaND,nd.HoTen) tong"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and NGAYGIAITRACH is not null"
                        + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.GIABAN) as TongGiaBanTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe,sum(hd.TONGCONG) as TongCongTonBillingThucTe"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                        + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                        + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                        + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTonDenKy_To(int MaTo, int Nam, int Ky, int FromDot, int ToDot)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon,TongCongTonBilling,TongHDTonThucTe,TongGiaBanTonThucTe,TongCongTonThucTe,TongCongTonBillingThucTe"
                        + " from"
                        + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot"
                        + " group by nd.MaND,nd.HoTen) tong"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and NGAYGIAITRACH is not null"
                        + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.GIABAN) as TongGiaBanTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe,sum(hd.TONGCONG) as TongCongTonBillingThucTe"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                        + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                        + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                        + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTonDenKyDenNgay_To(int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @NgayGiaiTrach date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon,TongCongTonBilling,TongHDTonThucTe,TongGiaBanTonThucTe,TongCongTonThucTe,TongCongTonBillingThucTe"
                        + " from"
                        + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky))"
                        + " group by nd.MaND,nd.HoTen) tong"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach"
                        + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.GIABAN) as TongGiaBanTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe,sum(hd.TONGCONG) as TongCongTonBillingThucTe"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                        + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                        + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                        + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTonDenKyDenNgay_To(int MaTo, int Nam, int Ky, int FromDot, int ToDot, DateTime NgayGiaiTrach)
        {
            string sql = "declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @FromDot int;"
                    + " declare @ToDot int;"
                    + " declare @NgayGiaiTrach date;"
                    + " declare @TuCuonGCS int;"
                    + " declare @DenCuonGCS int;"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @FromDot=" + FromDot + ";"
                    + " set @ToDot=" + ToDot + ";"
                    + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                    + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                    + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                    + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon,TongCongTonBilling,TongHDTonThucTe,TongGiaBanTonThucTe,TongCongTonThucTe,TongCongTonBillingThucTe"
                    + " from"
                    + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                    + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                    + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot"
                    + " group by nd.MaND,nd.HoTen) tong"
                    + " left join"
                    + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                    + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                    + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach"
                    + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                    + " left join"
                    + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                    + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                    + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                    + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                    + " left join"
                    + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.GIABAN) as TongGiaBanTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe,sum(hd.TONGCONG) as TongCongTonBillingThucTe"
                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                    + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                    + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                    + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                    + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                    + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                    + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                    + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTonTrongKyDenNgay_To(int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            string sql = " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @NgayGiaiTrach date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon,TongCongTonBilling,TongHDTonThucTe,TongGiaBanTonThucTe,TongCongTonThucTe,TongCongTonBillingThucTe"
                        + " from"
                        + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky"
                        + " group by nd.MaND,nd.HoTen) tong"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach"
                        + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.GIABAN) as TongGiaBanTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe,sum(hd.TONGCONG) as TongCongTonBillingThucTe"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                        + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                        + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                        + " and NAM=@Nam and KY=@Ky and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                        + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTonTrongKyDenNgay_To(int MaTo, int Nam, int Ky, int FromDot, int ToDot, DateTime NgayGiaiTrach)
        {
            string sql = " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " declare @NgayGiaiTrach date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon,TongCongTonBilling,TongHDTonThucTe,TongGiaBanTonThucTe,TongCongTonThucTe,TongCongTonBillingThucTe"
                        + " from"
                        + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot"
                        + " group by nd.MaND,nd.HoTen) tong"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach"
                        + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.GIABAN) as TongGiaBanTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe,sum(hd.TONGCONG) as TongCongTonBillingThucTe"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                        + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                        + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                        + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTon_Doi(int MaTo)
        {
            string sql = "declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select '" + MaTo + "' as MaTo,TenTo=(select TenTo from TT_To where MaTo=" + MaTo + "),MAX(t1.TuMLT)as TuMLT,MAX(t1.DenMLT)as DenMLT,MAX(t1.TuSoPhatHanh)as TuSoPhatHanh,MAX(t1.DenSoPhatHanh)as DenSoPhatHanh,MAX(t1.TongHD)as TongHD,MAX(t1.TongCong)as TongCong,MAX(t1.TongHDThu)as TongHDThu,MAX(t1.TongCongThu)as TongCongThu,MAX(t1.TongHDTon)as TongHDTon,MAX(t1.TongGiaBanTon)as TongGiaBanTon,MAX(t1.TongCongTon)as TongCongTon,MAX(t1.TongCongTonBilling)as TongCongTonBilling from"
                        + " ((select min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong,0 as TongHDThu,0 as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and KhoaTienDu=0 and NGAYGIAITRACH is not null)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,0 as TongHDThu,0 as TongCongThu,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (KhoaTienDu=1 or NGAYGIAITRACH is null)))) t1";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTon_Doi(int MaTo, int Nam)
        {
            string sql = "declare @Nam int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select '" + MaTo + "' as MaTo,TenTo=(select TenTo from TT_To where MaTo=" + MaTo + "),MAX(t1.TuMLT)as TuMLT,MAX(t1.DenMLT)as DenMLT,MAX(t1.TuSoPhatHanh)as TuSoPhatHanh,MAX(t1.DenSoPhatHanh)as DenSoPhatHanh,MAX(t1.TongHD)as TongHD,MAX(t1.TongCong)as TongCong,MAX(t1.TongHDThu)as TongHDThu,MAX(t1.TongCongThu)as TongCongThu,MAX(t1.TongHDTon)as TongHDTon,MAX(t1.TongGiaBanTon)as TongGiaBanTon,MAX(t1.TongCongTon)as TongCongTon,MAX(t1.TongCongTonBilling)as TongCongTonBilling from"
                        + " ((select min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong,0 as TongHDThu,0 as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam group by NAM)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KhoaTienDu=0 and NGAYGIAITRACH is not null group by NAM)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,0 as TongHDThu,0 as TongCongThu,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and (KhoaTienDu=1 or NGAYGIAITRACH is null) group by NAM)) t1";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTon_Doi(int MaTo, int Nam, int Ky)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select '" + MaTo + "' as MaTo,TenTo=(select TenTo from TT_To where MaTo=" + MaTo + "),MAX(t1.TuMLT)as TuMLT,MAX(t1.DenMLT)as DenMLT,MAX(t1.TuSoPhatHanh)as TuSoPhatHanh,MAX(t1.DenSoPhatHanh)as DenSoPhatHanh,MAX(t1.TongHD)as TongHD,MAX(t1.TongCong)as TongCong,MAX(t1.TongHDThu)as TongHDThu,MAX(t1.TongCongThu)as TongCongThu,MAX(t1.TongHDTon)as TongHDTon,MAX(t1.TongGiaBanTon)as TongGiaBanTon,MAX(t1.TongCongTon)as TongCongTon,MAX(t1.TongCongTonBilling)as TongCongTonBilling from"
                        + " ((select min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong,0 as TongHDThu,0 as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky group by KY,NAM)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and KhoaTienDu=0 and NGAYGIAITRACH is not null group by KY,NAM)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,0 as TongHDThu,0 as TongCongThu,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and (KhoaTienDu=1 or NGAYGIAITRACH is null) group by KY,NAM)) t1";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTon_Doi(int MaTo, int Nam, int Ky, int Dot)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @Dot int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @Dot=" + Dot + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select '" + MaTo + "' as MaTo,TenTo=(select TenTo from TT_To where MaTo=" + MaTo + "),MAX(t1.TuMLT)as TuMLT,MAX(t1.DenMLT)as DenMLT,MAX(t1.TuSoPhatHanh)as TuSoPhatHanh,MAX(t1.DenSoPhatHanh)as DenSoPhatHanh,MAX(t1.TongHD)as TongHD,MAX(t1.TongCong)as TongCong,MAX(t1.TongHDThu)as TongHDThu,MAX(t1.TongCongThu)as TongCongThu,MAX(t1.TongHDTon)as TongHDTon,MAX(t1.TongGiaBanTon)as TongGiaBanTon,MAX(t1.TongCongTon)as TongCongTon,MAX(t1.TongCongTonBilling)as TongCongTonBilling from"
                        + " ((select min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong,0 as TongHDThu,0 as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT=@Dot group by DOT,KY,NAM)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT=@Dot and KhoaTienDu=0 and NGAYGIAITRACH is not null group by DOT,KY,NAM)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,0 as TongHDThu,0 as TongCongThu,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null) group by DOT,KY,NAM)) t1";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTon_Doi(int MaTo, int Nam, int Ky, int FromDot, int ToDot)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select '" + MaTo + "' as MaTo,TenTo=(select TenTo from TT_To where MaTo=" + MaTo + "),MAX(t1.TuMLT)as TuMLT,MAX(t1.DenMLT)as DenMLT,MAX(t1.TuSoPhatHanh)as TuSoPhatHanh,MAX(t1.DenSoPhatHanh)as DenSoPhatHanh,MAX(t1.TongHD)as TongHD,MAX(t1.TongCong)as TongCong,MAX(t1.TongHDThu)as TongHDThu,MAX(t1.TongCongThu)as TongCongThu,MAX(t1.TongHDTon)as TongHDTon,MAX(t1.TongGiaBanTon)as TongGiaBanTon,MAX(t1.TongCongTon)as TongCongTon,MAX(t1.TongCongTonBilling)as TongCongTonBilling from"
                        + " ((select min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong,0 as TongHDThu,0 as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot group by DOT,KY,NAM)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and KhoaTienDu=0 and NGAYGIAITRACH is not null group by DOT,KY,NAM)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,0 as TongHDThu,0 as TongCongThu,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null) group by DOT,KY,NAM)) t1";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTon_Doi(int MaTo, DateTime NgayGiaiTrach)
        {
            string sql = "declare @NgayGiaiTrach date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select '" + MaTo + "' as MaTo,TenTo=(select TenTo from TT_To where MaTo=" + MaTo + "),MAX(t1.TuMLT)as TuMLT,MAX(t1.DenMLT)as DenMLT,MAX(t1.TuSoPhatHanh)as TuSoPhatHanh,MAX(t1.DenSoPhatHanh)as DenSoPhatHanh,MAX(t1.TongHD)as TongHD,MAX(t1.TongCong)as TongCong,MAX(t1.TongHDThu)as TongHDThu,MAX(t1.TongCongThu)as TongCongThu,MAX(t1.TongHDTon)as TongHDTon,MAX(t1.TongGiaBanTon)as TongGiaBanTon,MAX(t1.TongCongTon)as TongCongTon,MAX(t1.TongCongTonBilling)as TongCongTonBilling from"
                        + " ((select min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong,0 as TongHDThu,0 as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and KhoaTienDu=0 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,0 as TongHDThu,0 as TongCongThu,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)))) t1";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTonDenKy_Doi(int MaTo, int Nam, int Ky)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select '" + MaTo + "' as MaTo,TenTo=(select TenTo from TT_To where MaTo=" + MaTo + "),MAX(t1.TuMLT)as TuMLT,MAX(t1.DenMLT)as DenMLT,MAX(t1.TuSoPhatHanh)as TuSoPhatHanh,MAX(t1.DenSoPhatHanh)as DenSoPhatHanh,MAX(t1.TongHD)as TongHD,MAX(t1.TongCong)as TongCong,MAX(t1.TongHDThu)as TongHDThu,MAX(t1.TongCongThu)as TongCongThu,MAX(t1.TongHDTon)as TongHDTon,MAX(t1.TongGiaBanTon)as TongGiaBanTon,MAX(t1.TongCongTon)as TongCongTon,MAX(t1.TongCongTonBilling)as TongCongTonBilling from"
                        + " ((select min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong,0 as TongHDThu,0 as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)))"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and KhoaTienDu=0 and NGAYGIAITRACH is not null)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,0 as TongHDThu,0 as TongCongThu,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null))) t1";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTonDenKy_Doi(int MaTo, int Nam, int Ky, int FromDot, int ToDot)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select '" + MaTo + "' as MaTo,TenTo=(select TenTo from TT_To where MaTo=" + MaTo + "),MAX(t1.TuMLT)as TuMLT,MAX(t1.DenMLT)as DenMLT,MAX(t1.TuSoPhatHanh)as TuSoPhatHanh,MAX(t1.DenSoPhatHanh)as DenSoPhatHanh,MAX(t1.TongHD)as TongHD,MAX(t1.TongCong)as TongCong,MAX(t1.TongHDThu)as TongHDThu,MAX(t1.TongCongThu)as TongCongThu,MAX(t1.TongHDTon)as TongHDTon,MAX(t1.TongGiaBanTon)as TongGiaBanTon,MAX(t1.TongCongTon)as TongCongTon,MAX(t1.TongCongTonBilling)as TongCongTonBilling from"
                        + " ((select min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong,0 as TongHDThu,0 as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and KhoaTienDu=0 and NGAYGIAITRACH is not null)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,0 as TongHDThu,0 as TongCongThu,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null))) t1";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTonDenKyDenNgay_Doi(int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @NgayGiaiTrach date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select '" + MaTo + "' as MaTo,TenTo=(select TenTo from TT_To where MaTo=" + MaTo + "),MAX(t1.TuMLT)as TuMLT,MAX(t1.DenMLT)as DenMLT,MAX(t1.TuSoPhatHanh)as TuSoPhatHanh,MAX(t1.DenSoPhatHanh)as DenSoPhatHanh,MAX(t1.TongHD)as TongHD,MAX(t1.TongCong)as TongCong,MAX(t1.TongHDThu)as TongHDThu,MAX(t1.TongCongThu)as TongCongThu,MAX(t1.TongHDTon)as TongHDTon,MAX(t1.TongGiaBanTon)as TongGiaBanTon,MAX(t1.TongCongTon)as TongCongTon,MAX(t1.TongCongTonBilling)as TongCongTonBilling from"
                        + " ((select min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong,0 as TongHDThu,0 as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)))"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and KhoaTienDu=0 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,0 as TongHDThu,0 as TongCongThu,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach))) t1";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTonDenKyDenNgay_Doi(int MaTo, int Nam, int Ky, int FromDot, int ToDot, DateTime NgayGiaiTrach)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " declare @NgayGiaiTrach date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select '" + MaTo + "' as MaTo,TenTo=(select TenTo from TT_To where MaTo=" + MaTo + "),MAX(t1.TuMLT)as TuMLT,MAX(t1.DenMLT)as DenMLT,MAX(t1.TuSoPhatHanh)as TuSoPhatHanh,MAX(t1.DenSoPhatHanh)as DenSoPhatHanh,MAX(t1.TongHD)as TongHD,MAX(t1.TongCong)as TongCong,MAX(t1.TongHDThu)as TongHDThu,MAX(t1.TongCongThu)as TongCongThu,MAX(t1.TongHDTon)as TongHDTon,MAX(t1.TongGiaBanTon)as TongGiaBanTon,MAX(t1.TongCongTon)as TongCongTon,MAX(t1.TongCongTonBilling)as TongCongTonBilling from"
                        + " ((select min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong,0 as TongHDThu,0 as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and KhoaTienDu=0 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,0 as TongHDThu,0 as TongCongThu,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach))) t1";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTonTrongKyDenNgay_Doi(int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @NgayGiaiTrach date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select '" + MaTo + "' as MaTo,TenTo=(select TenTo from TT_To where MaTo=" + MaTo + "),MAX(t1.TuMLT)as TuMLT,MAX(t1.DenMLT)as DenMLT,MAX(t1.TuSoPhatHanh)as TuSoPhatHanh,MAX(t1.DenSoPhatHanh)as DenSoPhatHanh,MAX(t1.TongHD)as TongHD,MAX(t1.TongCong)as TongCong,MAX(t1.TongHDThu)as TongHDThu,MAX(t1.TongCongThu)as TongCongThu,MAX(t1.TongHDTon)as TongHDTon,MAX(t1.TongGiaBanTon)as TongGiaBanTon,MAX(t1.TongCongTon)as TongCongTon,MAX(t1.TongCongTonBilling)as TongCongTonBilling from"
                        + " ((select min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong,0 as TongHDThu,0 as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and KhoaTienDu=0 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,0 as TongHDThu,0 as TongCongThu,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach))) t1";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTonTrongKyDenNgay_Doi(int MaTo, int Nam, int Ky, int FromDot, int ToDot, DateTime NgayGiaiTrach)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " declare @NgayGiaiTrach date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select '" + MaTo + "' as MaTo,TenTo=(select TenTo from TT_To where MaTo=" + MaTo + "),MAX(t1.TuMLT)as TuMLT,MAX(t1.DenMLT)as DenMLT,MAX(t1.TuSoPhatHanh)as TuSoPhatHanh,MAX(t1.DenSoPhatHanh)as DenSoPhatHanh,MAX(t1.TongHD)as TongHD,MAX(t1.TongCong)as TongCong,MAX(t1.TongHDThu)as TongHDThu,MAX(t1.TongCongThu)as TongCongThu,MAX(t1.TongHDTon)as TongHDTon,MAX(t1.TongGiaBanTon)as TongGiaBanTon,MAX(t1.TongCongTon)as TongCongTon,MAX(t1.TongCongTonBilling)as TongCongTonBilling from"
                        + " ((select min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong,0 as TongHDThu,0 as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon,0 as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and KhoaTienDu=0 and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach)"
                        + " union"
                        + " (select 0 as TuMLT,0 as DenMLT,0 as TuSoPhatHanh,0 as DenSoPhatHanh,0 as TongHD,0 as TongCong,0 as TongHDThu,0 as TongCongThu,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon,sum(hd.TONGCONG) as TongCongTonBilling"
                        + " from HOADON hd where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach))) t1";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTon_NV(int MaNV_HanhThu)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon,TongHDTonThucTe,TongCongTonThucTe"
                        + " from"
                        + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " group by nd.MaND,nd.HoTen) tong"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NGAYGIAITRACH is not null"
                        + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                        + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                        + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                        + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                        + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTon_NV(int MaNV_HanhThu, int Nam)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " declare @Nam int;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " set @Nam=" + Nam + ";"
                        + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon,TongHDTonThucTe,TongCongTonThucTe"
                        + " from"
                        + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam"
                        + " group by nd.MaND,nd.HoTen) tong"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and NGAYGIAITRACH is not null"
                        + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                        + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                        + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                        + " and NAM=@Nam and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                        + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTon_NV(int MaNV_HanhThu, int Nam, int Ky)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @Dot int;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " select tong.MaND as MaNV,tong.HoTen,DOT,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon,TongHDTonThucTe,TongCongTonThucTe"
                        + " from"
                        + " (select nd.MaND,nd.HoTen,DOT,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and KY=@Ky"
                        + " group by nd.MaND,nd.HoTen,DOT) tong"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and KY=@Ky and NGAYGIAITRACH is not null"
                        + " group by nd.MaND,nd.HoTen,DOT) thu on tong.MaND=thu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and KY=@Ky and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen,DOT) ton on tong.MaND=ton.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                        + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                        + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                        + " and NAM=@Nam and KY=@Ky and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen,DOT) tonthucte on tong.MaND=tonthucte.MaND"
                        + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTon_NV(int MaNV_HanhThu, int Nam, int Ky, int Dot)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @Dot int;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @Dot=" + Dot + ";"
                        + " select Dot=" + Dot + ",tong.MaND as MaNV,tong.HoTen,DOT,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon,TongHDTonThucTe,TongCongTonThucTe"
                        + " from"
                        + " (select nd.MaND,nd.HoTen,DOT,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and KY=@Ky and DOT=@Dot"
                        + " group by nd.MaND,nd.HoTen,DOT) tong"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and KY=@Ky and DOT=@Dot and NGAYGIAITRACH is not null"
                        + " group by nd.MaND,nd.HoTen,DOT) thu on tong.MaND=thu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and KY=@Ky and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen,DOT) ton on tong.MaND=ton.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                        + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                        + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                        + " and NAM=@Nam and KY=@Ky and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen,DOT) tonthucte on tong.MaND=tonthucte.MaND"
                        + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTon_NV(int MaNV_HanhThu, DateTime NgayGiaiTrach)
        {
            string sql = "declare @MaNV_HanhThu int;"
                    + " declare @NgayGiaiTrach date;"
                    + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                    + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                    + " select tong.MaND,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon,TongHDTonThucTe,TongCongTonThucTe"
                    + " from"
                    + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                    + " where MaNV_HanhThu=@MaNV_HanhThu"
                    + " group by nd.MaND,nd.HoTen) tong"
                    + " left join"
                    + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                    + " where MaNV_HanhThu=@MaNV_HanhThu"
                    + " and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach"
                    + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                    + " left join"
                    + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                    + " where MaNV_HanhThu=@MaNV_HanhThu"
                    + " and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                    + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                    + " left join"
                    + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe"
                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                    + " where MaNV_HanhThu=@MaNV_HanhThu"
                    + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                    + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                    + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                    + " and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                    + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                    + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTonDenKy_NV(string Loai, int MaNV_HanhThu, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                string sql = "declare @Nam int;"
                            + " declare @Ky int;"
                            + " set @Nam=" + Nam + ";"
                            + " set @Ky=" + Ky + ";"
                            + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon,TongHDTonThucTe,TongCongTonThucTe"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and GB>=10 and GB<=20"
                            + " group by nd.MaND,nd.HoTen) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and NGAYGIAITRACH is not null and GB>=10 and GB<=20"
                            + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>=10 and GB<=20"
                            + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                            + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>=10 and GB<=20"
                            + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                            + " order by tong.MaND asc";

                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "declare @Nam int;"
                            + " declare @Ky int;"
                            + " set @Nam=" + Nam + ";"
                            + " set @Ky=" + Ky + ";"
                            + " select tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon,TongHDTonThucTe,TongCongTonThucTe"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and GB>20"
                            + " group by nd.MaND,nd.HoTen) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and NGAYGIAITRACH is not null and GB>20"
                            + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>20"
                            + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                            + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>20"
                            + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                            + " order by tong.MaND asc";

                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetTongTonDenKy_NV(int MaNV_HanhThu, int Nam, int Ky, int Dot)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @Dot int;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @Dot=" + Dot + ";"
                        + " select Dot=" + Dot + ",tong.MaND as MaNV,tong.HoTen,DOT,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon,TongHDTonThucTe,TongCongTonThucTe"
                        + " from"
                        + " (select nd.MaND,nd.HoTen,DOT,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT=@Dot"
                        + " group by nd.MaND,nd.HoTen,DOT) tong"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT=@Dot and NGAYGIAITRACH is not null"
                        + " group by nd.MaND,nd.HoTen,DOT) thu on tong.MaND=thu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen,DOT) ton on tong.MaND=ton.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                        + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                        + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by nd.MaND,nd.HoTen,DOT) tonthucte on tong.MaND=tonthucte.MaND"
                        + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTonDenKyDenNgay_NV(int MaNV_HanhThu, int Nam, int Ky, int Dot, DateTime NgayGiaiTrach)
        {
            string sql = "declare @MaNV_HanhThu int;"
                    + " declare @Nam int;"
                    + " declare @Ky int;"
                    + " declare @Dot int;"
                    + " declare @NgayGiaiTrach date;"
                    + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                    + " set @Nam=" + Nam + ";"
                    + " set @Ky=" + Ky + ";"
                    + " set @Dot=" + Dot + ";"
                    + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                    + " select Dot=" + Dot + ",tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon,TongHDTonThucTe,TongCongTonThucTe"
                    + " from"
                    + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                    + " where MaNV_HanhThu=@MaNV_HanhThu"
                    + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT=@Dot"
                    + " group by nd.MaND,nd.HoTen) tong"
                    + " left join"
                    + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                    + " where MaNV_HanhThu=@MaNV_HanhThu"
                    + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT=@Dot and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach"
                    + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                    + " left join"
                    + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                    + " where MaNV_HanhThu=@MaNV_HanhThu"
                    + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                    + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                    + " left join"
                    + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe"
                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                    + " where MaNV_HanhThu=@MaNV_HanhThu"
                    + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                    + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                    + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                    + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                    + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                    + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongTonTrongKyDenNgay_NV(int MaNV_HanhThu, int Nam, int Ky, int Dot, DateTime NgayGiaiTrach)
        {
            string sql = "declare @MaNV_HanhThu int;"
                            + " declare @Nam int;"
                            + " declare @Ky int;"
                            + " declare @Dot int;"
                            + " declare @NgayGiaiTrach date;"
                            + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                            + " set @Nam=" + Nam + ";"
                            + " set @Ky=" + Ky + ";"
                            + " set @Dot=" + Dot + ";"
                            + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                            + " select Dot=" + Dot + ",tong.MaND as MaNV,tong.HoTen,TuMLT,DenMLT,TuSoPhatHanh,DenSoPhatHanh,TongHD,TongCong,TongHDThu,TongCongThu,TongHDTon,TongCongTon,TongHDTonThucTe,TongCongTonThucTe"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,min(MALOTRINH) as TuMLT,max(MALOTRINH) as DenMLT,min(SOPHATHANH) as TuSoPhatHanh,max(SOPHATHANH) as DenSoPhatHanh,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=@MaNV_HanhThu"
                            + " and NAM=@Nam and KY=@Ky and DOT=@Dot"
                            + " group by nd.MaND,nd.HoTen) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=@MaNV_HanhThu"
                            + " and NAM=@Nam and KY=@Ky and DOT=@Dot and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach"
                            + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=@MaNV_HanhThu"
                            + " and NAM=@Nam and KY=@Ky and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                            + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTonThucTe,sum(hd.TONGCONG) as TongCongTonThucTe"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MaNV_HanhThu=@MaNV_HanhThu"
                            + " and ID_HOADON not in (select MaHD from TT_CTDongNuoc a, TT_DongNuoc b where a.MaDN=b.MaDN and Huy=0)"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " and ID_HOADON not in (select MaHD from TT_DuLieuKhachHang_SoHoaDon)"
                            + " and NAM=@Nam and KY=@Ky and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                            + " group by nd.MaND,nd.HoTen) tonthucte on tong.MaND=tonthucte.MaND"
                            + " order by tong.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }



        public DataTable GetBaoCaoTon_To(int MaTo, DateTime NgayGiaiTrach)
        {
            string sql = "declare @NgayGiaiTrach date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
                        + " from"
                        + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " and ID_HOADON not in"
                        + " ("
                        + " select ID_HOADON"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " )"
                        + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
                        + " where ck.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
                        + " order by nhanvien.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        //public DataTable GetBaoCaoTon_To(string Loai, int MaTo)
        //{
        //    if (Loai == "TG")
        //    {
        //        string sql = "select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
        //                    + " from"
        //                    + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
        //                    + " where lh.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
        //                    + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " and ID_HOADON not in"
        //                    + " ("
        //                    + " select ID_HOADON"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
        //                    + " where lh.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " )"
        //                    + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
        //                    + " where ck.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
        //                    + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
        //                    + " order by nhanvien.MaND asc";

        //        return ExecuteQuery_DataTable(sql);
        //    }
        //    else
        //        if (Loai == "CQ")
        //        {
        //            string sql = "select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
        //                    + " from"
        //                    + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
        //                    + " where lh.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NGAYGIAITRACH is null and GB>20"
        //                    + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
        //                    + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NGAYGIAITRACH is null and GB>20"
        //                    + " and ID_HOADON not in"
        //                    + " ("
        //                    + " select ID_HOADON"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
        //                    + " where lh.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NGAYGIAITRACH is null and GB>20"
        //                    + " )"
        //                    + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
        //                    + " where ck.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NGAYGIAITRACH is null and GB>20"
        //                    + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
        //                    + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NGAYGIAITRACH is null and GB>20"
        //                    + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
        //                    + " order by nhanvien.MaND asc";

        //            return ExecuteQuery_DataTable(sql);
        //        }
        //    return null;
        //}

        //public DataTable GetBaoCaoTon_To(string Loai, int MaTo, int Nam)
        //{
        //    if (Loai == "TG")
        //    {
        //        string sql = "declare @Nam int;"
        //                    + " set @Nam=" + Nam + ";"
        //                    + " select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
        //                    + " from"
        //                    + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
        //                    + " where lh.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
        //                    + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " and ID_HOADON not in"
        //                    + " ("
        //                    + " select ID_HOADON"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
        //                    + " where lh.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " )"
        //                    + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
        //                    + " where ck.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
        //                    + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
        //                    + " order by nhanvien.MaND asc";

        //        return ExecuteQuery_DataTable(sql);
        //    }
        //    else
        //        if (Loai == "CQ")
        //        {
        //            string sql = "declare @Nam int;"
        //                    + " set @Nam=" + Nam + ";"
        //                    + " select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
        //                    + " from"
        //                    + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
        //                    + " where lh.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and NGAYGIAITRACH is null and GB>20"
        //                    + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
        //                    + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and NGAYGIAITRACH is null and GB>20"
        //                    + " and ID_HOADON not in"
        //                    + " ("
        //                    + " select ID_HOADON"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
        //                    + " where lh.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and NGAYGIAITRACH is null and GB>20"
        //                    + " )"
        //                    + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
        //                    + " where ck.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and NGAYGIAITRACH is null and GB>20"
        //                    + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
        //                    + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and NGAYGIAITRACH is null and GB>20"
        //                    + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
        //                    + " order by nhanvien.MaND asc";

        //            return ExecuteQuery_DataTable(sql);
        //        }
        //    return null;
        //}

        //public DataTable GetBaoCaoTon_To(string Loai, int MaTo, int Nam, int Ky)
        //{
        //    if (Loai == "TG")
        //    {
        //        string sql = "declare @Nam int;"
        //                    + " declare @Ky int;"
        //                    + " set @Nam=" + Nam + ";"
        //                    + " set @Ky=" + Ky + ";"
        //                    + " select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
        //                    + " from"
        //                    + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
        //                    + " where lh.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY=@Ky and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
        //                    + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY=@Ky and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " and ID_HOADON not in"
        //                    + " ("
        //                    + " select ID_HOADON"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
        //                    + " where lh.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY=@Ky and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " )"
        //                    + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
        //                    + " where ck.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY=@Ky and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
        //                    + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY=@Ky and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
        //                    + " order by nhanvien.MaND asc";

        //        return ExecuteQuery_DataTable(sql);
        //    }
        //    else
        //        if (Loai == "CQ")
        //        {
        //            string sql = "declare @Nam int;"
        //                    + " declare @Ky int;"
        //                    + " set @Nam=" + Nam + ";"
        //                    + " set @Ky=" + Ky + ";"
        //                    + " select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
        //                    + " from"
        //                    + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
        //                    + " where lh.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY=@Ky and NGAYGIAITRACH is null and GB>20"
        //                    + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
        //                    + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY=@Ky and NGAYGIAITRACH is null and GB>20"
        //                    + " and ID_HOADON not in"
        //                    + " ("
        //                    + " select ID_HOADON"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
        //                    + " where lh.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY=@Ky and NGAYGIAITRACH is null and GB>20"
        //                    + " )"
        //                    + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
        //                    + " where ck.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY=@Ky and NGAYGIAITRACH is null and GB>20"
        //                    + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
        //                    + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY<=@Ky and NGAYGIAITRACH is null and GB>20"
        //                    + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
        //                    + " order by nhanvien.MaND asc";

        //            return ExecuteQuery_DataTable(sql);
        //        }
        //    return null;
        //}

        //public DataTable GetBaoCaoTon_To(string Loai, int MaTo, int Nam, int Ky, int Dot)
        //{
        //    if (Loai == "TG")
        //    {
        //        string sql = "declare @Nam int;"
        //                    + " declare @Ky int;"
        //                    + " declare @Dot int;"
        //                    + " set @Nam=" + Nam + ";"
        //                    + " set @Ky=" + Ky + ";"
        //                    + " set @Dot=" + Dot + ";"
        //                    + " select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
        //                    + " from"
        //                    + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
        //                    + " where lh.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY=@Ky and DOT=@Dot and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
        //                    + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY=@Ky and DOT=@Dot and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " and ID_HOADON not in"
        //                    + " ("
        //                    + " select ID_HOADON"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
        //                    + " where lh.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY=@Ky and DOT=@Dot and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " )"
        //                    + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
        //                    + " where ck.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY=@Ky and DOT=@Dot and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
        //                    + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY=@Ky and DOT=@Dot and NGAYGIAITRACH is null and GB>=10 and GB<=20"
        //                    + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
        //                    + " order by nhanvien.MaND asc";

        //        return ExecuteQuery_DataTable(sql);
        //    }
        //    else
        //        if (Loai == "CQ")
        //        {
        //            string sql = "declare @Nam int;"
        //                    + " declare @Ky int;"
        //                    + " declare @Dot int;"
        //                    + " set @Nam=" + Nam + ";"
        //                    + " set @Ky=" + Ky + ";"
        //                    + " set @Dot=" + Dot + ";"
        //                    + " select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
        //                    + " from"
        //                    + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
        //                    + " where lh.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY=@Ky and DOT=@Dot and NGAYGIAITRACH is null and GB>20"
        //                    + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
        //                    + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY=@Ky and DOT=@Dot and NGAYGIAITRACH is null and GB>20"
        //                    + " and ID_HOADON not in"
        //                    + " ("
        //                    + " select ID_HOADON"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
        //                    + " where lh.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY=@Ky and DOT=@Dot and NGAYGIAITRACH is null and GB>20"
        //                    + " )"
        //                    + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
        //                    + " where ck.MaHD=hd.ID_HOADON"
        //                    + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY=@Ky and DOT=@Dot and NGAYGIAITRACH is null and GB>20"
        //                    + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
        //                    + " left join"
        //                    + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
        //                    + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
        //                    + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
        //                    + " and NAM=@Nam and hd.KY<=@Ky and DOT=@Dot and NGAYGIAITRACH is null and GB>20"
        //                    + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
        //                    + " order by nhanvien.MaND asc";

        //            return ExecuteQuery_DataTable(sql);
        //        }
        //    return null;
        //}

        public DataTable GetBaoCaoTonDenKyDenNgay_To(int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @NgayGiaiTrach date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
                        + " from"
                        + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " and ID_HOADON not in"
                        + " ("
                        + " select ID_HOADON"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " )"
                        + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
                        + " where ck.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
                        + " order by nhanvien.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetBaoCaoTonDenKyDenNgay_To(int MaTo, int Nam, int Ky, int FromDot, int ToDot, DateTime NgayGiaiTrach)
        {
            string sql = "declare @NgayGiaiTrach date;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
                        + " from"
                        + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and hd.DOT>=@FromDot and hd.DOT<=@ToDot and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and hd.DOT>=@FromDot and hd.DOT<=@ToDot and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " and ID_HOADON not in"
                        + " ("
                        + " select ID_HOADON"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and hd.DOT>=@FromDot and hd.DOT<=@ToDot and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " )"
                        + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
                        + " where ck.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and hd.DOT>=@FromDot and hd.DOT<=@ToDot and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and hd.DOT>=@FromDot and hd.DOT<=@ToDot and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
                        + " order by nhanvien.MaND asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetBaoCaoTonTrongKyDenNgay_To(int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            string sql = "declare @NgayGiaiTrach date;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
                        + " from"
                        + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " and ID_HOADON not in"
                        + " ("
                        + " select ID_HOADON"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " )"
                        + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
                        + " where ck.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
                        + " order by nhanvien.MaND asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetBaoCaoTonTrongKyDenNgay_To(int MaTo, int Nam, int Ky, int FromDot, int ToDot, DateTime NgayGiaiTrach)
        {
            string sql = "declare @NgayGiaiTrach date;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
                        + " from"
                        + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and hd.DOT>=@FromDot and hd.DOT<=@ToDot and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and hd.DOT>=@FromDot and hd.DOT<=@ToDot and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " and ID_HOADON not in"
                        + " ("
                        + " select ID_HOADON"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and hd.DOT>=@FromDot and hd.DOT<=@ToDot and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " )"
                        + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
                        + " where ck.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and hd.DOT>=@FromDot and hd.DOT<=@ToDot and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and hd.DOT>=@FromDot and hd.DOT<=@ToDot and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach)"
                        + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
                        + " order by nhanvien.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetBaoCaoTonDenKy_To(int MaTo, int Nam, int Ky)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
                        + " from"
                        + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and NGAYGIAITRACH is null"
                        + " and ID_HOADON not in"
                        + " ("
                        + " select ID_HOADON"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and NGAYGIAITRACH is null"
                        + " )"
                        + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
                        + " where ck.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
                        + " order by nhanvien.MaND asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetBaoCaoTonDenKy_To(int MaTo, int Nam, int Ky, int FromDot, int ToDot)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
                        + " from"
                        + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and hd.DOT>=@FromDot and hd.DOT<=@ToDot and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and hd.DOT>=@FromDot and hd.DOT<=@ToDot and NGAYGIAITRACH is null"
                        + " and ID_HOADON not in"
                        + " ("
                        + " select ID_HOADON"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and hd.DOT>=@FromDot and hd.DOT<=@ToDot and NGAYGIAITRACH is null"
                        + " )"
                        + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
                        + " where ck.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and hd.DOT>=@FromDot and hd.DOT<=@ToDot and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and hd.KY<=@Ky)) and hd.DOT>=@FromDot and hd.DOT<=@ToDot and NGAYGIAITRACH is null or"
                        + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
                        + " order by nhanvien.MaND asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetBaoCaoTon_To(int MaTo)
        {
            string sql = "declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
                        + " from"
                        + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NGAYGIAITRACH is null"
                        + " and ID_HOADON not in"
                        + " ("
                        + " select ID_HOADON"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NGAYGIAITRACH is null"
                        + " )"
                        + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
                        + " where ck.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
                        + " order by nhanvien.MaND asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetBaoCaoTon_To(int MaTo, int Nam)
        {
            string sql = "declare @Nam int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
                        + " from"
                        + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and NGAYGIAITRACH is null"
                        + " and ID_HOADON not in"
                        + " ("
                        + " select ID_HOADON"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and NGAYGIAITRACH is null"
                        + " )"
                        + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
                        + " where ck.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
                        + " order by nhanvien.MaND asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetBaoCaoTon_To(int MaTo, int Nam, int Ky)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
                        + " from"
                        + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and NGAYGIAITRACH is null"
                        + " and ID_HOADON not in"
                        + " ("
                        + " select ID_HOADON"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and NGAYGIAITRACH is null"
                        + " )"
                        + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
                        + " where ck.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
                        + " order by nhanvien.MaND asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetBaoCaoTon_To(int MaTo, int Nam, int Ky, int Dot)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @Dot int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @Dot=" + Dot + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
                        + " from"
                        + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and DOT=@Dot and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and DOT=@Dot and NGAYGIAITRACH is null"
                        + " and ID_HOADON not in"
                        + " ("
                        + " select ID_HOADON"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and DOT=@Dot and NGAYGIAITRACH is null"
                        + " )"
                        + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
                        + " where ck.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and DOT=@Dot and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and DOT=@Dot and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
                        + " order by nhanvien.MaND asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetBaoCaoTon_To(int MaTo, int Nam, int Ky, int FromDot, int ToDot)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select TenTo,nhanvien.MaND as MaNV,nhanvien.HoTen,LenhHuySL,LenhHuyTC,DongNuocSL,DongNuocTC,ChuyenKhoanSL,ChuyenKhoanTC,TongSL,TongTC"
                        + " from"
                        + " (select TenTo,MaND,HoTen from TT_NguoiDung nd,TT_To tto where nd.MaTo=tto.MaTo and nd.MaTo=" + MaTo + " and nd.HanhThu=1) nhanvien"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as LenhHuySL,SUM(hd.TONGCONG) as LenhHuyTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) lenhhuy on nhanvien.MaND=lenhhuy.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as DongNuocSL,SUM(hd.TONGCONG) as DongNuocTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DongNuoc dn,TT_CTDongNuoc ctdn"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and NGAYGIAITRACH is null"
                        + " and ID_HOADON not in"
                        + " ("
                        + " select ID_HOADON"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_LenhHuy lh"
                        + " where lh.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and NGAYGIAITRACH is null"
                        + " )"
                        + " group by nd.MaND,nd.HoTen) dongnuoc on nhanvien.MaND=dongnuoc.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as ChuyenKhoanSL,SUM(hd.TONGCONG) as ChuyenKhoanTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND,TT_DuLieuKhachHang_SoHoaDon ck"
                        + " where ck.MaHD=hd.ID_HOADON"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) chuyenkhoan on nhanvien.MaND=chuyenkhoan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,COUNT(ID_HOADON) as TongSL,SUM(hd.TONGCONG) as TongTC"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and hd.KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and NGAYGIAITRACH is null"
                        + " group by nd.MaND,nd.HoTen) tongton on nhanvien.MaND=tongton.MaND"
                        + " order by nhanvien.MaND asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetNangSuat_To(string Loai, int MaTo, int Nam, int Ky, int Dot)
        {
            if (Loai == "TG")
            {
                string sql = "declare @Nam int;"
                            + " declare @Ky int;"
                            + " declare @Dot int;"
                            + " set @Nam=" + Nam + ";"
                            + " set @Ky=" + Ky + ";"
                            + " set @Dot=" + Dot + ";"
                            + " select tong.MaND as MaNV,tong.HoTen,TongHD,TongGiaBan,TongCong,TongHDThu,TongGiaBanThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHD,sum(GIABAN) as TongGiaBan,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and KY=@Ky and DOT=@Dot and GB>=10 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,DOT,KY,NAM) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(GIABAN) as TongGiaBanThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and KY=@Ky and DOT=@Dot and NGAYGIAITRACH is not null and GB>=10 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,DOT,KY,NAM) thu on tong.MaND=thu.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and KY=@Ky and DOT=@Dot and NGAYGIAITRACH is null and GB>=10 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,DOT,KY,NAM) ton on tong.MaND=ton.MaND"
                            + " order by tong.MaND asc";

                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "declare @Nam int;"
                            + " declare @Ky int;"
                            + " declare @Dot int;"
                            + " set @Nam=" + Nam + ";"
                            + " set @Ky=" + Ky + ";"
                            + " set @Dot=" + Dot + ";"
                            + " select tong.MaND as MaNV,tong.HoTen,TongHD,TongGiaBan,TongCong,TongHDThu,TongGiaBanThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHD,sum(GIABAN) as TongGiaBan,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and KY=@Ky and DOT=@Dot and GB>20"
                            + " group by nd.MaND,nd.HoTen,DOT,KY,NAM) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(GIABAN) as TongGiaBanThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and KY=@Ky and DOT=@Dot and NGAYGIAITRACH is not null and GB>20"
                            + " group by nd.MaND,nd.HoTen,DOT,KY,NAM) thu on tong.MaND=thu.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and KY=@Ky and DOT=@Dot and NGAYGIAITRACH is null and GB>20"
                            + " group by nd.MaND,nd.HoTen,DOT,KY,NAM) ton on tong.MaND=ton.MaND"
                            + " order by tong.MaND asc";

                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetNangSuat_To(string Loai, int MaTo, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                string sql = "declare @Nam int;"
                            + " declare @Ky int;"
                            + " set @Nam=" + Nam + ";"
                            + " set @Ky=" + Ky + ";"
                            + " select tong.MaND as MaNV,tong.HoTen,TongHD,TongGiaBan,TongCong,TongHDThu,TongGiaBanThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHD,sum(GIABAN) as TongGiaBan,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and KY=@Ky and GB>=10 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(GIABAN) as TongGiaBanThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and KY=@Ky and NGAYGIAITRACH is not null and GB>=10 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) thu on tong.MaND=thu.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and KY=@Ky and NGAYGIAITRACH is null and GB>=10 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) ton on tong.MaND=ton.MaND"
                            + " order by tong.MaND asc";

                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "declare @Nam int;"
                            + " declare @Ky int;"
                            + " set @Nam=" + Nam + ";"
                            + " set @Ky=" + Ky + ";"
                            + " select tong.MaND as MaNV,tong.HoTen,TongHD,TongGiaBan,TongCong,TongHDThu,TongGiaBanThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHD,sum(GIABAN) as TongGiaBan,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and KY=@Ky and GB>20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(GIABAN) as TongGiaBanThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and KY=@Ky and NGAYGIAITRACH is not null and GB>20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) thu on tong.MaND=thu.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and KY=@Ky and NGAYGIAITRACH is null and GB>20"
                            + " group by nd.MaND,nd.HoTen,KY,NAM) ton on tong.MaND=ton.MaND"
                            + " order by tong.MaND asc";

                    return ExecuteQuery_DataTable(sql);
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

                string sql = "declare @Nam int;"
                            + " set @Nam=" + Nam + ";"
                            + " select tong.MaND as MaNV,tong.HoTen,TongHD,TongGiaBan,TongCong,TongHDThu,TongGiaBanThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHD,sum(GIABAN) as TongGiaBan,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and GB>=10 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,NAM) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(GIABAN) as TongGiaBanThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and NGAYGIAITRACH is not null and GB>=10 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,NAM) thu on tong.MaND=thu.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and NGAYGIAITRACH is null and GB>=10 and GB<=20"
                            + " group by nd.MaND,nd.HoTen,NAM) ton on tong.MaND=ton.MaND"
                            + " order by tong.MaND asc";

                return ExecuteQuery_DataTable(sql);
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

                    string sql = "declare @Nam int;"
                            + " set @Nam=" + Nam + ";"
                            + " select tong.MaND as MaNV,tong.HoTen,TongHD,TongGiaBan,TongCong,TongHDThu,TongGiaBanThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHD,sum(GIABAN) as TongGiaBan,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and GB>20"
                            + " group by nd.MaND,nd.HoTen,NAM) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(GIABAN) as TongGiaBanThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and NGAYGIAITRACH is not null and GB>20"
                            + " group by nd.MaND,nd.HoTen,NAM) thu on tong.MaND=thu.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and NGAYGIAITRACH is null and GB>20"
                            + " group by nd.MaND,nd.HoTen,NAM) ton on tong.MaND=ton.MaND"
                            + " order by tong.MaND asc";

                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetNangSuat_To(string Loai, int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
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

                string sql = "declare @NgayGiaiTrach date;"
                            + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                            + " select tong.MaND as MaNV,tong.HoTen,TongHD,TongGiaBan,TongCong,TongHDThu,TongGiaBanThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHD,sum(GIABAN) as TongGiaBan,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=" + Nam + " and KY=" + Ky + " and GB>=10 and GB<=20"
                            + " group by nd.MaND,nd.HoTen) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(GIABAN) as TongGiaBanThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=" + Nam + " and KY=" + Ky + " and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and GB>=10 and GB<=20"
                            + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=" + Nam + " and KY=" + Ky + " and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach) and GB>=10 and GB<=20"
                            + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                            + " order by tong.MaND asc";

                return ExecuteQuery_DataTable(sql);
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

                    string sql = "declare @NgayGiaiTrach date;"
                            + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                            + " select tong.MaND as MaNV,tong.HoTen,TongHD,TongGiaBan,TongCong,TongHDThu,TongGiaBanThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon"
                            + " from"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHD,sum(GIABAN) as TongGiaBan,sum(hd.TONGCONG) as TongCong"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=" + Nam + " and KY=" + Ky + " and GB>20"
                            + " group by nd.MaND,nd.HoTen) tong"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(GIABAN) as TongGiaBanThu,sum(hd.TONGCONG) as TongCongThu"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=" + Nam + " and KY=" + Ky + " and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and GB>20"
                            + " group by nd.MaND,nd.HoTen) thu on tong.MaND=thu.MaND"
                            + " left join"
                            + " (select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=" + Nam + " and KY=" + Ky + " and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach) and GB>20"
                            + " group by nd.MaND,nd.HoTen) ton on tong.MaND=ton.MaND"
                            + " order by tong.MaND asc";

                    return ExecuteQuery_DataTable(sql);
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

        public DataTable GetNangSuat_Doi(string Loai, int MaTo, int Nam, int Ky, int Dot)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.GB >= 11 && item.GB <= 20
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
                                    && item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.GB > 20
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

        public DataTable GetNangSuat_Doi(string Loai, int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                string sql = "declare @NgayGiaiTrach date;"
                            + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                            + " select '" + MaTo + "' as MaTo,'" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TenTo + "' as TenTo,MAX(t1.TongHD)as TongHD,MAX(t1.TongGiaBan)as TongGiaBan,MAX(t1.TongCong)as TongCong,MAX(t1.TongHDThu)as TongHDThu,MAX(t1.TongGiaBanThu)as TongGiaBanThu,MAX(t1.TongCongThu)as TongCongThu,MAX(t1.TongHDTon)as TongHDTon,MAX(t1.TongGiaBanTon)as TongGiaBanTon,MAX(t1.TongCongTon)as TongCongTon from"
                            + " ((select count(DANHBA) as TongHD,sum(hd.GIABAN) as TongGiaBan,sum(hd.TONGCONG) as TongCong,0 as TongHDThu,0 as TongGiaBanThu,0 as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon"
                            + " from HOADON hd where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=" + Nam + " and KY=" + Ky + " and GB>=10 and GB<=20)"
                            + " union"
                            + " (select 0 as TongHD,0 as TongGiaBan,0 as TongCong,count(DANHBA) as TongHDThu,sum(hd.GIABAN) as TongGiaBanThu,sum(hd.TONGCONG) as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon"
                            + " from HOADON hd where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=" + Nam + " and KY=" + Ky + " and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and GB>=10 and GB<=20)"
                            + " union"
                            + " (select 0 as TongHD,0 as TongGiaBan,0 as TongCong,0 as TongHDThu,0 as TongGiaBanThu,0 as TongCongThu,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=" + Nam + " and KY=" + Ky + " and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach) and GB>=10 and GB<=20)) t1";

                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "declare @NgayGiaiTrach date;"
                            + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                            + " select '" + MaTo + "' as MaTo,'" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TenTo + "' as TenTo,MAX(t1.TongHD)as TongHD,MAX(t1.TongGiaBan)as TongGiaBan,MAX(t1.TongCong)as TongCong,MAX(t1.TongHDThu)as TongHDThu,MAX(t1.TongGiaBanThu)as TongGiaBanThu,MAX(t1.TongCongThu)as TongCongThu,MAX(t1.TongHDTon)as TongHDTon,MAX(t1.TongGiaBanTon)as TongGiaBanTon,MAX(t1.TongCongTon)as TongCongTon from"
                            + " ((select count(DANHBA) as TongHD,sum(hd.GIABAN) as TongGiaBan,sum(hd.TONGCONG) as TongCong,0 as TongHDThu,0 as TongGiaBanThu,0 as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon"
                            + " from HOADON hd where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=" + Nam + " and KY=" + Ky + " and GB>20)"
                            + " union"
                            + " (select 0 as TongHD,0 as TongGiaBan,0 as TongCong,count(DANHBA) as TongHDThu,sum(hd.GIABAN) as TongGiaBanThu,sum(hd.TONGCONG) as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon"
                            + " from HOADON hd where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=" + Nam + " and KY=" + Ky + " and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and GB>20)"
                            + " union"
                            + " (select 0 as TongHD,0 as TongGiaBan,0 as TongCong,0 as TongHDThu,0 as TongGiaBanThu,0 as TongCongThu,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=" + Nam + " and KY=" + Ky + " and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach) and GB>20)) t1";

                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetNangSuat_Doi(string Loai, int MaTo, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                string sql = "declare @NgayGiaiTrach date;"
                            + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                            + " select '" + MaTo + "' as MaTo,'" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TenTo + "' as TenTo,MAX(t1.TongHD)as TongHD,MAX(t1.TongGiaBan)as TongGiaBan,MAX(t1.TongCong)as TongCong,MAX(t1.TongHDThu)as TongHDThu,MAX(t1.TongGiaBanThu)as TongGiaBanThu,MAX(t1.TongCongThu)as TongCongThu,MAX(t1.TongHDTon)as TongHDTon,MAX(t1.TongGiaBanTon)as TongGiaBanTon,MAX(t1.TongCongTon)as TongCongTon from"
                            + " ((select count(DANHBA) as TongHD,sum(hd.GIABAN) as TongGiaBan,sum(hd.TONGCONG) as TongCong,0 as TongHDThu,0 as TongGiaBanThu,0 as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon"
                            + " from HOADON hd where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and GB>=10 and GB<=20)"
                            + " union"
                            + " (select 0 as TongHD,0 as TongGiaBan,0 as TongCong,count(DANHBA) as TongHDThu,sum(hd.GIABAN) as TongGiaBanThu,sum(hd.TONGCONG) as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon"
                            + " from HOADON hd where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and GB>=10 and GB<=20)"
                            + " union"
                            + " (select 0 as TongHD,0 as TongGiaBan,0 as TongCong,0 as TongHDThu,0 as TongGiaBanThu,0 as TongCongThu,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach) and GB>=10 and GB<=20)) t1";

                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "declare @NgayGiaiTrach date;"
                            + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                            + " select '" + MaTo + "' as MaTo,'" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TenTo + "' as TenTo,MAX(t1.TongHD)as TongHD,MAX(t1.TongGiaBan)as TongGiaBan,MAX(t1.TongCong)as TongCong,MAX(t1.TongHDThu)as TongHDThu,MAX(t1.TongGiaBanThu)as TongGiaBanThu,MAX(t1.TongCongThu)as TongCongThu,MAX(t1.TongHDTon)as TongHDTon,MAX(t1.TongGiaBanTon)as TongGiaBanTon,MAX(t1.TongCongTon)as TongCongTon from"
                            + " ((select count(DANHBA) as TongHD,sum(hd.GIABAN) as TongGiaBan,sum(hd.TONGCONG) as TongCong,0 as TongHDThu,0 as TongGiaBanThu,0 as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon"
                            + " from HOADON hd where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and GB>20)"
                            + " union"
                            + " (select 0 as TongHD,0 as TongGiaBan,0 as TongCong,count(DANHBA) as TongHDThu,sum(hd.GIABAN) as TongGiaBanThu,sum(hd.TONGCONG) as TongCongThu,0 as TongHDTon,0 as TongGiaBanTon,0 as TongCongTon"
                            + " from HOADON hd where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@NgayGiaiTrach and GB>20)"
                            + " union"
                            + " (select 0 as TongHD,0 as TongGiaBan,0 as TongCong,0 as TongHDThu,0 as TongGiaBanThu,0 as TongCongThu,count(DANHBA) as TongHDTon,sum(hd.GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon"
                            + " from HOADON hd where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach) and GB>20)) t1";

                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetChuanThu_Doi(int MaTo, int Nam, int Ky, int Dot)
        {
            var query = from item in _db.HOADONs
                        where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                            && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            && item.NAM == Nam && item.KY == Ky && item.DOT == Dot
                        orderby MaTo ascending
                        group item by MaTo into itemGroup
                        select new
                        {
                            MaTo = itemGroup.Key,
                            _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == itemGroup.Key).TenTo,
                            TongHD = itemGroup.Count(),
                            TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                        };
            return LINQToDataTable(query);
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

        public DataTable GetBaoCaoTongHop_Doi(string Loai, int Nam, int Ky, DateTime NgayGiaiTrachNow, DateTime NgayGiaiTrachOld)
        {
            if (Loai == "TG")
            {
                string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @NgayGiaiTrachNow date;"
                        + " declare @NgayGiaiTrachOld date;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @NgayGiaiTrachNow='" + NgayGiaiTrachNow.ToString("yyyyMMdd") + "';"
                        + " set @NgayGiaiTrachOld='" + NgayGiaiTrachOld.ToString("yyyyMMdd") + "';"
                        + " select 0 as MaTo,N'Đội' as TenTo,'TG' as Loai,MAX(HDTonCu)as HDTonCu,MAX(GTTonCu)as GTTonCu,MAX(HDChuanThu)as HDChuanThu,MAX(GTChuanThu)as GTChuanThu,MAX(HDTonThu)as HDTonThu,MAX(GTTonThu)as GTTonThu,MAX(HDTongTon)as HDTongTon,MAX(GTTongTon)as GTTongTon from"
                        + " ((select COUNT(ID_HOADON) as HDTonCu,SUM(TONGCONG) as GTTonCu,0 as HDChuanThu,0 as GTChuanThu,0 as HDTonThu,0 as GTTonThu,0 as HDTongTon,0 as GTTongTon"
                        + " from HOADON where (NAM<@Nam or (NAM=@Nam and KY<=@Ky-1)) and (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>@NgayGiaiTrachOld) or KhoaTienDu=1) and GB>=10 and GB<=20)"
                        + " union"
                        + " (select 0 as HDTonCu,0 as GTTonCu,COUNT(ID_HOADON) as HDChuanThu,SUM(TONGCONG) as GTChuanThu,0 as HDTonThu,0 as GTTonThu,0 as HDTongTon,0 as GTTongTon"
                        + " from HOADON where NAM=@Nam and KY=@Ky and GB>=10 and GB<=20)"
                        + " union"
                        + " (select 0 as HDTonCu,0 as GTTonCu,0 as HDChuanThu,0 as GTChuanThu,COUNT(ID_HOADON) as HDTonThu,SUM(TONGCONG) as GTTonThu,0 as HDTongTon,0 as GTTongTon"
                        + " from HOADON where NAM=@Nam and KY=@Ky and (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>@NgayGiaiTrachNow) or KhoaTienDu=1) and GB>=10 and GB<=20)"
                        + " union"
                        + " (select 0 as HDTonCu,0 as GTTonCu,0 as HDChuanThu,0 as GTChuanThu,0 as HDTonThu,0 as GTTonThu,COUNT(ID_HOADON) as HDTongTon,SUM(TONGCONG) as GTTongTon"
                        + " from HOADON where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>@NgayGiaiTrachNow) or KhoaTienDu=1) and GB>=10 and GB<=20))t1";

                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @NgayGiaiTrachNow date;"
                        + " declare @NgayGiaiTrachOld date;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @NgayGiaiTrachNow='" + NgayGiaiTrachNow.ToString("yyyyMMdd") + "';"
                        + " set @NgayGiaiTrachOld='" + NgayGiaiTrachOld.ToString("yyyyMMdd") + "';"
                        + " select 0 as MaTo,N'Đội' as TenTo,'CQ' as Loai,MAX(HDTonCu)as HDTonCu,MAX(GTTonCu)as GTTonCu,MAX(HDChuanThu)as HDChuanThu,MAX(GTChuanThu)as GTChuanThu,MAX(HDTonThu)as HDTonThu,MAX(GTTonThu)as GTTonThu,MAX(HDTongTon)as HDTongTon,MAX(GTTongTon)as GTTongTon from"
                        + " ((select COUNT(ID_HOADON) as HDTonCu,SUM(TONGCONG) as GTTonCu,0 as HDChuanThu,0 as GTChuanThu,0 as HDTonThu,0 as GTTonThu,0 as HDTongTon,0 as GTTongTon"
                        + " from HOADON where (NAM<@Nam or (NAM=@Nam and KY<=@Ky-1)) and (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>@NgayGiaiTrachOld) or KhoaTienDu=1) and GB>20)"
                        + " union"
                        + " (select 0 as HDTonCu,0 as GTTonCu,COUNT(ID_HOADON) as HDChuanThu,SUM(TONGCONG) as GTChuanThu,0 as HDTonThu,0 as GTTonThu,0 as HDTongTon,0 as GTTongTon"
                        + " from HOADON where NAM=@Nam and KY=@Ky and GB>20)"
                        + " union"
                        + " (select 0 as HDTonCu,0 as GTTonCu,0 as HDChuanThu,0 as GTChuanThu,COUNT(ID_HOADON) as HDTonThu,SUM(TONGCONG) as GTTonThu,0 as HDTongTon,0 as GTTongTon"
                        + " from HOADON where NAM=@Nam and KY=@Ky and (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>@NgayGiaiTrachNow) or KhoaTienDu=1) and GB>20)"
                        + " union"
                        + " (select 0 as HDTonCu,0 as GTTonCu,0 as HDChuanThu,0 as GTChuanThu,0 as HDTonThu,0 as GTTonThu,COUNT(ID_HOADON) as HDTongTon,SUM(TONGCONG) as GTTongTon"
                        + " from HOADON where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>@NgayGiaiTrachNow) or KhoaTienDu=1) and GB>20))t1";

                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetBaoCaoTongHop_To(string Loai, int MaTo, int Nam, int Ky, DateTime NgayGiaiTrachNow, DateTime NgayGiaiTrachOld)
        {
            if (Loai == "TG")
            {
                string sql = "declare @NgayGiaiTrachNow date;"
                        + " declare @NgayGiaiTrachOld date;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @NgayGiaiTrachNow='" + NgayGiaiTrachNow.ToString("yyyyMMdd") + "';"
                        + " set @NgayGiaiTrachOld='" + NgayGiaiTrachOld.ToString("yyyyMMdd") + "';"
                        + " select '" + MaTo + "' as MaTo,'" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TenTo + "' as TenTo,'TG' as Loai,MAX(HDTonCu)as HDTonCu,MAX(GTTonCu)as GTTonCu,MAX(HDChuanThu)as HDChuanThu,MAX(GTChuanThu)as GTChuanThu,MAX(HDTonThu)as HDTonThu,MAX(GTTonThu)as GTTonThu,MAX(HDTongTon)as HDTongTon,MAX(GTTongTon)as GTTongTon from"
                        + " ((select COUNT(ID_HOADON) as HDTonCu,SUM(TONGCONG) as GTTonCu,0 as HDChuanThu,0 as GTChuanThu,0 as HDTonThu,0 as GTTonThu,0 as HDTongTon,0 as GTTongTon"
                        + " from HOADON where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky-1)) and (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>@NgayGiaiTrachOld) or KhoaTienDu=1) and GB>=10 and GB<=20)"
                        + " union"
                        + " (select 0 as HDTonCu,0 as GTTonCu,COUNT(ID_HOADON) as HDChuanThu,SUM(TONGCONG) as GTChuanThu,0 as HDTonThu,0 as GTTonThu,0 as HDTongTon,0 as GTTongTon"
                        + " from HOADON where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        + " and NAM=@Nam and KY=@Ky and GB>=10 and GB<=20)"
                        + " union"
                        + " (select 0 as HDTonCu,0 as GTTonCu,0 as HDChuanThu,0 as GTChuanThu,COUNT(ID_HOADON) as HDTonThu,SUM(TONGCONG) as GTTonThu,0 as HDTongTon,0 as GTTongTon"
                        + " from HOADON where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        + " and NAM=@Nam and KY=@Ky and (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>@NgayGiaiTrachNow) or KhoaTienDu=1) and GB>=10 and GB<=20)"
                        + " union"
                        + " (select 0 as HDTonCu,0 as GTTonCu,0 as HDChuanThu,0 as GTChuanThu,0 as HDTonThu,0 as GTTonThu,COUNT(ID_HOADON) as HDTongTon,SUM(TONGCONG) as GTTongTon"
                        + " from HOADON where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>@NgayGiaiTrachNow) or KhoaTienDu=1) and GB>=10 and GB<=20))t1";

                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "declare @NgayGiaiTrachNow date;"
                            + " declare @NgayGiaiTrachOld date;"
                            + " declare @Nam int;"
                            + " declare @Ky int;"
                            + " set @Nam=" + Nam + ";"
                            + " set @Ky=" + Ky + ";"
                            + " set @NgayGiaiTrachNow='" + NgayGiaiTrachNow.ToString("yyyyMMdd") + "';"
                            + " set @NgayGiaiTrachOld='" + NgayGiaiTrachOld.ToString("yyyyMMdd") + "';"
                            + " select '" + MaTo + "' as MaTo,'" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TenTo + "' as TenTo,'CQ' as Loai,MAX(HDTonCu)as HDTonCu,MAX(GTTonCu)as GTTonCu,MAX(HDChuanThu)as HDChuanThu,MAX(GTChuanThu)as GTChuanThu,MAX(HDTonThu)as HDTonThu,MAX(GTTonThu)as GTTonThu,MAX(HDTongTon)as HDTongTon,MAX(GTTongTon)as GTTongTon from"
                            + " ((select COUNT(ID_HOADON) as HDTonCu,SUM(TONGCONG) as GTTonCu,0 as HDChuanThu,0 as GTChuanThu,0 as HDTonThu,0 as GTTonThu,0 as HDTongTon,0 as GTTongTon"
                            + " from HOADON where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky-1)) and (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>@NgayGiaiTrachOld) or KhoaTienDu=1) and GB>20)"
                            + " union"
                            + " (select 0 as HDTonCu,0 as GTTonCu,COUNT(ID_HOADON) as HDChuanThu,SUM(TONGCONG) as GTChuanThu,0 as HDTonThu,0 as GTTonThu,0 as HDTongTon,0 as GTTongTon"
                            + " from HOADON where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and KY=@Ky and GB>20)"
                            + " union"
                            + " (select 0 as HDTonCu,0 as GTTonCu,0 as HDChuanThu,0 as GTChuanThu,COUNT(ID_HOADON) as HDTonThu,SUM(TONGCONG) as GTTonThu,0 as HDTongTon,0 as GTTongTon"
                            + " from HOADON where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=@Nam and KY=@Ky and (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>@NgayGiaiTrachNow) or KhoaTienDu=1) and GB>20)"
                            + " union"
                            + " (select 0 as HDTonCu,0 as GTTonCu,0 as HDChuanThu,0 as GTChuanThu,0 as HDTonThu,0 as GTTonThu,COUNT(ID_HOADON) as HDTongTon,SUM(TONGCONG) as GTTongTon"
                            + " from HOADON where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>@NgayGiaiTrachNow) or KhoaTienDu=1) and GB>20))t1";

                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetBaoCaoTongHop_NV(string Loai, int MaTo, int Nam, int Ky, DateTime NgayGiaiTrachNow, DateTime NgayGiaiTrachOld, DateTime NgayGiaiTrachFuture)
        {
            if (Loai == "TG")
            {
                string sql = "declare @NgayGiaiTrachNow date;"
                        + " declare @NgayGiaiTrachOld date;"
                        + " declare @NgayGiaiTrachFuture date;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @NgayGiaiTrachNow='" + NgayGiaiTrachNow.ToString("yyyyMMdd") + "';"
                        + " set @NgayGiaiTrachOld='" + NgayGiaiTrachOld.ToString("yyyyMMdd") + "';"
                        + " set @NgayGiaiTrachFuture='" + NgayGiaiTrachFuture.ToString("yyyyMMdd") + "';"
                        + " select nd.MaND as MaNV,nd.HoTen,nd.STT,'TG' as Loai,toncu.HDTonCu,toncu.GTTonCu,chuanthu.HDChuanThu,chuanthu.GTChuanThu,tonthu.HDTonThu,tonthu.GTTonThu,tongton.HDTongTon,tongton.GTTongTon from"
                        + " (select MaND,HoTen,STT from TT_NguoiDung) nd"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(ID_HOADON) as HDChuanThu,SUM(TONGCONG) as GTChuanThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        + " and NAM=@Nam and KY=@Ky and GB>=10 and GB<=20 group by nd.MaND,nd.HoTen,nd.STT) chuanthu on nd.MaND=chuanthu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(ID_HOADON) as HDTonCu,SUM(TONGCONG) as GTTonCu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky-1)) and (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>@NgayGiaiTrachOld) or KhoaTienDu=1)"
                        + " and GB>=10 and GB<=20 group by nd.MaND,nd.HoTen,nd.STT) toncu on nd.MaND=toncu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(ID_HOADON) as HDTonThu,SUM(TONGCONG) as GTTonThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        + " and NAM=@Nam and KY=@Ky and (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>@NgayGiaiTrachFuture) or KhoaTienDu=1)"
                        + " and GB>=10 and GB<=20 group by nd.MaND,nd.HoTen,nd.STT) tonthu on nd.MaND=tonthu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(ID_HOADON) as HDTongTon,SUM(TONGCONG) as GTTongTon"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>@NgayGiaiTrachNow) or KhoaTienDu=1)"
                        + " and GB>=10 and GB<=20 group by nd.MaND,nd.HoTen,nd.STT) tongton on nd.MaND=tongton.MaND"
                        + " order by nd.STT asc";

                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "declare @NgayGiaiTrachNow date;"
                        + " declare @NgayGiaiTrachOld date;"
                        + " declare @NgayGiaiTrachFuture date;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @NgayGiaiTrachNow='" + NgayGiaiTrachNow.ToString("yyyyMMdd") + "';"
                        + " set @NgayGiaiTrachOld='" + NgayGiaiTrachOld.ToString("yyyyMMdd") + "';"
                        + " set @NgayGiaiTrachFuture='" + NgayGiaiTrachFuture.ToString("yyyyMMdd") + "';"
                        + " select nd.MaND as MaNV,nd.HoTen,nd.STT,'CQ' as Loai,toncu.HDTonCu,toncu.GTTonCu,chuanthu.HDChuanThu,chuanthu.GTChuanThu,tonthu.HDTonThu,tonthu.GTTonThu,tongton.HDTongTon,tongton.GTTongTon from"
                        + " (select MaND,HoTen,STT from TT_NguoiDung) nd"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(ID_HOADON) as HDChuanThu,SUM(TONGCONG) as GTChuanThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        + " and NAM=@Nam and KY=@Ky and GB>20 group by nd.MaND,nd.HoTen,nd.STT) chuanthu on nd.MaND=chuanthu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(ID_HOADON) as HDTonCu,SUM(TONGCONG) as GTTonCu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky-1)) and (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>@NgayGiaiTrachOld) or KhoaTienDu=1)"
                        + " and GB>20 group by nd.MaND,nd.HoTen,nd.STT) toncu on nd.MaND=toncu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(ID_HOADON) as HDTonThu,SUM(TONGCONG) as GTTonThu"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        + " and NAM=@Nam and KY=@Ky and (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>@NgayGiaiTrachFuture) or KhoaTienDu=1)"
                        + " and GB>20 group by nd.MaND,nd.HoTen,nd.STT) tonthu on nd.MaND=tonthu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(ID_HOADON) as HDTongTon,SUM(TONGCONG) as GTTongTon"
                        + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>@NgayGiaiTrachNow) or KhoaTienDu=1)"
                        + " and GB>20 group by nd.MaND,nd.HoTen,nd.STT) tongton on nd.MaND=tongton.MaND"
                        + " order by nd.STT asc";

                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetBaoCaoTyLeTon(int Nam)
        {
            string sql = "select * from"
                    + " (select KY,TongHD=COUNT(ID_HOADON),TongGiaBan=SUM(GIABAN) from HOADON where NAM=" + Nam
                    + " group by Ky) t1"
                    + " left join"
                    + " (select KY,TongHDTon=COUNT(ID_HOADON),TongGiaBanTon=SUM(GIABAN) from HOADON where NAM=" + Nam + " and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                    + " group by Ky) t2 on t1.KY=t2.KY order by t1.KY asc";
            return ExecuteQuery_DataTable(sql);
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

        public DataTable GetTongDangNgan_NV(int MaNV, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            string sql = "declare @Nam int"
                        + " declare @Ky int"
                        + " declare @FromDot int"
                        + " declare @ToDot int"
                        + " declare @NgayGiaiTrach date"
                        + " declare @MaNV int"
                        + " set @Nam=" + Nam
                        + " set @Ky=" + Ky
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "'"
                        + " set @MaNV=" + MaNV
                        + " select MaNV=nv.MaNV,nv.STT,nv.HoTen,TongHDTonDau,TongCongTonDau,TongHDDangNgan,TongCongDangNgan"
                        + " ,TongHDDangNganTangCuong,TongCongDangNganTangCuong,TongHDDangNganQuay,TongCongDangNganQuay,TongHDDangNganChuyenKhoan,TongCongDangNganChuyenKhoan,TongHDTonCuoi,TongCongTonCuoi,TongHDInPhieuBao,TongHDTBDongNuoc,TongHDXoa,TongCongXoa"
                        + " from"
                        + " (select MaNV=@MaNV,STT=(select STT from TT_NguoiDung where MaND=@MaNV),HoTen=(select HoTen from TT_NguoiDung where MaND=@MaNV)) nv"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDTonDau=COUNT(ID_HOADON),TongCongTonDau=SUM(TONGCONG) from HOADON"
                        + " where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>=@NgayGiaiTrach) and MaNV_HanhThu=@MaNV"
                        + " group by MaNV_HanhThu) tondau on nv.MaNV=tondau.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_DangNgan,TongHDDangNgan=COUNT(ID_HOADON),TongCongDangNgan=SUM(TONGCONG) from HOADON"
                        + " where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and CAST(NGAYGIAITRACH as date)=@NgayGiaiTrach and (DangNgan_HanhThu=1 or DangNgan_Ton=1) and MaNV_DangNgan=@MaNV"
                        + " group by MaNV_DangNgan) dangngan on nv.MaNV=dangngan.MaNV_DangNgan"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDDangNganTangCuong=COUNT(ID_HOADON),TongCongDangNganTangCuong=SUM(TONGCONG) from HOADON"
                        + " where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and CAST(NGAYGIAITRACH as date)=@NgayGiaiTrach and (DangNgan_HanhThu=1 or DangNgan_Ton=1) and MaNV_DangNgan!=@MaNV"
                        + " group by MaNV_HanhThu) dangngantangcuong on nv.MaNV=dangngantangcuong.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDDangNganQuay=COUNT(ID_HOADON),TongCongDangNganQuay=SUM(TONGCONG) from HOADON"
                        + " where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and CAST(NGAYGIAITRACH as date)=@NgayGiaiTrach and DangNgan_Quay=1 and MaNV_HanhThu=@MaNV"
                        + " group by MaNV_HanhThu) dangnganquay on nv.MaNV=dangnganquay.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDDangNganChuyenKhoan=COUNT(ID_HOADON),TongCongDangNganChuyenKhoan=SUM(TONGCONG) from HOADON"
                        + " where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and CAST(NGAYGIAITRACH as date)=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1 and MaNV_HanhThu=@MaNV"
                        + " group by MaNV_HanhThu) dangnganchuyenkhoan on nv.MaNV=dangnganchuyenkhoan.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDTonCuoi=COUNT(ID_HOADON),TongCongTonCuoi=SUM(TONGCONG) from HOADON"
                        + " where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach) and MaNV_HanhThu=@MaNV"
                        + " group by MaNV_HanhThu) toncuoi on nv.MaNV=toncuoi.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDInPhieuBao=COUNT(ID_HOADON) from HOADON"
                        + " where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and CAST(InPhieuBao_Ngay as date)=@NgayGiaiTrach and MaNV_HanhThu=@MaNV"
                        + " group by MaNV_HanhThu) inphieubao on nv.MaNV=inphieubao.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDTBDongNuoc=COUNT(ID_HOADON) from HOADON"
                        + " where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and CAST(TBDongNuoc_Ngay as date)=@NgayGiaiTrach and MaNV_HanhThu=@MaNV"
                        + " group by MaNV_HanhThu) tbdongnuoc on nv.MaNV=tbdongnuoc.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDXoa=COUNT(ID_HOADON),TongCongXoa=SUM(TONGCONG) from HOADON"
                        + " where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and CAST(XoaDangNgan_Ngay_DienThoai as date)=@NgayGiaiTrach and MaNV_HanhThu=@MaNV"
                        + " group by MaNV_HanhThu) xoa on nv.MaNV=xoa.MaNV_HanhThu"
                        + " order by STT";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongDangNgan_NV(int MaNV, int Nam, int Ky, int FromDot, int ToDot, DateTime NgayGiaiTrach)
        {
            string sql = "declare @Nam int"
                        + " declare @Ky int"
                        + " declare @FromDot int"
                        + " declare @ToDot int"
                        + " declare @NgayGiaiTrach date"
                        + " declare @MaNV int"
                        + " set @Nam=" + Nam
                        + " set @Ky=" + Ky
                        + " set @FromDot=" + FromDot
                        + " set @ToDot=" + ToDot
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "'"
                        + " set @MaNV=" + MaNV
                        + " select MaNV=nv.MaNV,nv.STT,nv.HoTen,TongHDTonDau,TongCongTonDau,TongHDDangNgan,TongCongDangNgan"
                        + " ,TongHDDangNganTangCuong,TongCongDangNganTangCuong,TongHDDangNganQuay,TongCongDangNganQuay,TongHDDangNganChuyenKhoan,TongCongDangNganChuyenKhoan,TongHDTonCuoi,TongCongTonCuoi,TongHDInPhieuBao,TongHDTBDongNuoc,TongHDXoa,TongCongXoa"
                        + " from"
                        + " (select MaNV=@MaNV,STT=(select STT from TT_NguoiDung where MaND=@MaNV),HoTen=(select HoTen from TT_NguoiDung where MaND=@MaNV)) nv"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDTonDau=COUNT(ID_HOADON),TongCongTonDau=SUM(TONGCONG) from HOADON"
                        + " where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>=@NgayGiaiTrach) and MaNV_HanhThu=@MaNV"
                        + " group by MaNV_HanhThu) tondau on nv.MaNV=tondau.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_DangNgan,TongHDDangNgan=COUNT(ID_HOADON),TongCongDangNgan=SUM(TONGCONG) from HOADON"
                        + " where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and CAST(NGAYGIAITRACH as date)=@NgayGiaiTrach and (DangNgan_HanhThu=1 or DangNgan_Ton=1) and MaNV_DangNgan=@MaNV"
                        + " group by MaNV_DangNgan) dangngan on nv.MaNV=dangngan.MaNV_DangNgan"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDDangNganTangCuong=COUNT(ID_HOADON),TongCongDangNganTangCuong=SUM(TONGCONG) from HOADON"
                        + " where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and CAST(NGAYGIAITRACH as date)=@NgayGiaiTrach and (DangNgan_HanhThu=1 or DangNgan_Ton=1) and MaNV_DangNgan!=@MaNV"
                        + " group by MaNV_HanhThu) dangngantangcuong on nv.MaNV=dangngantangcuong.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDDangNganQuay=COUNT(ID_HOADON),TongCongDangNganQuay=SUM(TONGCONG) from HOADON"
                        + " where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and CAST(NGAYGIAITRACH as date)=@NgayGiaiTrach and DangNgan_Quay=1 and MaNV_HanhThu=@MaNV"
                        + " group by MaNV_HanhThu) dangnganquay on nv.MaNV=dangnganquay.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDDangNganChuyenKhoan=COUNT(ID_HOADON),TongCongDangNganChuyenKhoan=SUM(TONGCONG) from HOADON"
                        + " where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and CAST(NGAYGIAITRACH as date)=@NgayGiaiTrach and DangNgan_ChuyenKhoan=1 and MaNV_HanhThu=@MaNV"
                        + " group by MaNV_HanhThu) dangnganchuyenkhoan on nv.MaNV=dangnganchuyenkhoan.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDTonCuoi=COUNT(ID_HOADON),TongCongTonCuoi=SUM(TONGCONG) from HOADON"
                        + " where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@NgayGiaiTrach) and MaNV_HanhThu=@MaNV"
                        + " group by MaNV_HanhThu) toncuoi on nv.MaNV=toncuoi.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDInPhieuBao=COUNT(ID_HOADON) from HOADON"
                        + " where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and CAST(InPhieuBao_Ngay as date)=@NgayGiaiTrach and MaNV_HanhThu=@MaNV"
                        + " group by MaNV_HanhThu) inphieubao on nv.MaNV=inphieubao.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDTBDongNuoc=COUNT(ID_HOADON) from HOADON"
                        + " where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and CAST(TBDongNuoc_Ngay as date)=@NgayGiaiTrach and MaNV_HanhThu=@MaNV"
                        + " group by MaNV_HanhThu) tbdongnuoc on nv.MaNV=tbdongnuoc.MaNV_HanhThu"
                        + " left join"
                        + " (select MaNV_HanhThu,TongHDXoa=COUNT(ID_HOADON),TongCongXoa=SUM(TONGCONG) from HOADON"
                        + " where (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and CAST(XoaDangNgan_Ngay_DienThoai as date)=@NgayGiaiTrach and MaNV_HanhThu=@MaNV"
                        + " group by MaNV_HanhThu) xoa on nv.MaNV=xoa.MaNV_HanhThu"
                        + " order by STT";
            return ExecuteQuery_DataTable(sql);
        }

        /// <summary>
        /// Lấy Sum thông tin những hóa đơn đã đăng ngân bởi các anh/em, không tính nhân viên thuộc tổ đó không
        /// </summary>
        /// <param name="MaTo"></param>
        /// <param name="loai"></param>
        /// <param name="NgayDangNgan"></param>
        /// <returns></returns>
        public DataTable GetTongDangNgan_To(string Loai, int MaTo, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                ///Tổ Văn Phòng
                if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                {
                    var query = from item in _db.HOADONs
                                where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                && item.KhoaTienDu == false && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
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
                                    && item.KhoaTienDu == false && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
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
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                    && item.KhoaTienDu == false && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
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
                                        && item.KhoaTienDu == false && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
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

        /// <summary>
        /// Lấy Sum thông tin những hóa đơn đã đăng ngân bởi các anh/em, có tính nhân viên thuộc tổ đó không
        /// </summary>
        /// <param name="Loai"></param>
        /// <param name="MaTo"></param>
        /// <param name="TuNgayGiaiTrach"></param>
        /// <param name="DenNgayGiaiTrach"></param>
        /// <returns></returns>
        public DataTable GetTongDangNgan_To(string Loai, int MaTo, DateTime TuNgayGiaiTrach, DateTime DenNgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                ///Tổ Văn Phòng
                if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                {
                    var query = from item in _db.HOADONs
                                where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                && item.KhoaTienDu == false && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
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
                                    && item.KhoaTienDu == false && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
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
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                    && item.KhoaTienDu == false && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && item.GB > 20
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
                                        && item.KhoaTienDu == false && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && item.GB > 20
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
                    if (Loai == "")
                    {
                        ///Tổ Văn Phòng
                        if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                        {
                            var query = from item in _db.HOADONs
                                        where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.KhoaTienDu == false && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date
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
                                            && item.KhoaTienDu == false && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date
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
        public DataTable GetTongDangNgan_Doi(string Loai, int MaTo, DateTime TuNgayGiaiTrach, DateTime DenNgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                ///Tổ Văn Phòng
                if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                {
                    var query = from item in _db.HOADONs
                                where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                && item.KhoaTienDu == false && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
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
                                    && item.KhoaTienDu == false && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
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
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan) ///Kiểm tra nhân viên đăng ngân thuộc tổ
                                    && item.KhoaTienDu == false && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && item.GB > 20
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
                                       && item.KhoaTienDu == false && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && item.GB > 20
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
                    if (Loai == "")
                    {
                        ///Tổ Văn Phòng
                        if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                        {
                            var query = from item in _db.HOADONs
                                        where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan) ///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.KhoaTienDu == false && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date
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
                                           && item.KhoaTienDu == false && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date
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

        public DataTable GetTongDangNgan_Doi(DateTime TuNgayGiaiTrach, DateTime DenNgayGiaiTrach)
        {
            var query = from item in _db.HOADONs
                        where item.KhoaTienDu == false && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date
                        group item by item.MaNV_DangNgan into itemGroup
                        select new
                        {
                            MaNV = itemGroup.Key,
                            _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                            _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
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
                            FromNgayGiaiTrach = TuNgayGiaiTrach.ToString(),
                            ToNgayGiaiTrach = DenNgayGiaiTrach.ToString(),
                        };
            return LINQToDataTable(query.OrderBy(item => item.STT));
        }

        public DataTable GetTongDangNgan(string Loai, int MaNV_HanhThu, int Nam, int Ky, int Dot)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.MaNV_HanhThu == MaNV_HanhThu && item.NGAYGIAITRACH != null && item.GB >= 11 && item.GB <= 20
                            orderby item.MaNV_DangNgan ascending
                            group item by new { item.MaNV_DangNgan, item.NGAYGIAITRACH.Value.Date } into itemGroup
                            select new
                            {
                                MaNV_HanhThu = MaNV_HanhThu,
                                MaNV_DangNgan = itemGroup.Key.MaNV_DangNgan,
                                NgayGiaiTrach = itemGroup.Key.Date,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key.MaNV_DangNgan).HoTen,
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
                                group item by new { item.MaNV_DangNgan, item.NGAYGIAITRACH.Value.Date } into itemGroup
                                select new
                                {
                                    MaNV_HanhThu = MaNV_HanhThu,
                                    MaNV_DangNgan = itemGroup.Key.MaNV_DangNgan,
                                    NgayGiaiTrach = itemGroup.Key.Date,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key.MaNV_DangNgan).HoTen,
                                    TongHD = itemGroup.Count(),
                                    TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                    TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                    TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                    TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                };
                    return LINQToDataTable(query);
                }
                else
                    if (Loai == "")
                    {
                        var query = from item in _db.HOADONs
                                    where item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.MaNV_HanhThu == MaNV_HanhThu && item.NGAYGIAITRACH != null
                                    orderby item.MaNV_DangNgan ascending
                                    group item by new { item.MaNV_DangNgan, item.NGAYGIAITRACH.Value.Date } into itemGroup
                                    select new
                                    {
                                        MaNV_HanhThu = MaNV_HanhThu,
                                        MaNV_DangNgan = itemGroup.Key.MaNV_DangNgan,
                                        NgayGiaiTrach = itemGroup.Key.Date,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key.MaNV_DangNgan).HoTen,
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

        public DataTable GetTongDangNgan(string Loai, int MaNV_DangNgan, DateTime NgayGiaiTrach)
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
                                TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
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
                                    TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                    TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                };
                    return LINQToDataTable(query);
                }
                else
                    if (Loai == "")
                    {
                        DataTable dt = new DataTable();
                        var query = from item in _db.HOADONs
                                    where item.MaNV_DangNgan == MaNV_DangNgan && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                                    && (item.NAM < 2020 || (item.NAM == 2020 && item.KY < 7))
                                    orderby item.MaNV_DangNgan ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        LoaiHoaDon = "Giấy",
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        dt.Merge(LINQToDataTable(query));

                        var query2 = from item in _db.HOADONs
                                     where item.MaNV_DangNgan == MaNV_DangNgan && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                                     && (item.NAM > 2020 || (item.NAM == 2020 && item.KY >= 7))
                                     orderby item.MaNV_DangNgan ascending
                                     group item by item.MaNV_DangNgan into itemGroup
                                     select new
                                     {
                                         MaNV = itemGroup.Key,
                                         _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                         LoaiHoaDon = "Điện Tử",
                                         TongHD = itemGroup.Count(),
                                         TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                         TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                         TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                         TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                         TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TienDu),
                                         TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat) == null ? 0 : itemGroup.Sum(groupItem => groupItem.TienMat),
                                     };
                        dt.Merge(LINQToDataTable(query2));

                        return dt;
                    }
            return null;
        }

        public DataTable GetTongDangNgan_PhanKyLon(int MaNV_DangNgan, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            DataTable dt = new DataTable();
            string sql = "select MaNV=MaNV_DangNgan,HoTen=(select HoTen from TT_NguoiDung where MaND=MaNV_DangNgan),'LoaiHoaDon'=N'Giấy',TongHD=COUNT(ID_HOADON),SUM(GIABAN)as TongGiaBan,SUM(THUE)as TongThueGTGT,SUM(PHI)as TongPhiBVMT,SUM(TONGCONG)as TongCong,"
                        + " TongTienDu=SUM(TienDu),TongTienMat=SUM(TienMat)"
                        + " from HOADON where MaNV_DangNgan=" + MaNV_DangNgan + " and NAM=" + Nam + " and KY=" + Ky + " and (NAM<2020 or(NAM=2020 and KY<7)) and CAST(NGAYGIAITRACH as date)='" + NgayGiaiTrach.ToString("yyyyMMdd") + "'"
                        + " group by MaNV_DangNgan";
            dt.Merge(ExecuteQuery_DataTable(sql));
            sql = "select MaNV=MaNV_DangNgan,HoTen=(select HoTen from TT_NguoiDung where MaND=MaNV_DangNgan),'LoaiHoaDon'=N'Điện Tử',TongHD=COUNT(ID_HOADON),SUM(GIABAN)as TongGiaBan,SUM(THUE)as TongThueGTGT,SUM(PHI)as TongPhiBVMT,SUM(TONGCONG)as TongCong,"
                        + " TongTienDu=SUM(TienDu),TongTienMat=SUM(TienMat)"
                        + " from HOADON where MaNV_DangNgan=" + MaNV_DangNgan + " and NAM=" + Nam + " and KY=" + Ky + " and (NAM>2020 or(NAM=2020 and KY>=7)) and CAST(NGAYGIAITRACH as date)='" + NgayGiaiTrach.ToString("yyyyMMdd") + "'"
                        + " group by MaNV_DangNgan";
            dt.Merge(ExecuteQuery_DataTable(sql));
            return dt;
        }

        public DataTable GetTongDangNgan_PhanKyNho(int MaNV_DangNgan, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            DataTable dt = new DataTable();
            string sql = "select MaNV=MaNV_DangNgan,HoTen=(select HoTen from TT_NguoiDung where MaND=MaNV_DangNgan),'LoaiHoaDon'=N'Giấy',TongHD=COUNT(ID_HOADON),SUM(GIABAN)as TongGiaBan,SUM(THUE)as TongThueGTGT,SUM(PHI)as TongPhiBVMT,SUM(TONGCONG)as TongCong,"
                        + " TongTienDu=SUM(TienDu),TongTienMat=SUM(TienMat)"
                        + " from HOADON where MaNV_DangNgan=" + MaNV_DangNgan + " and (NAM<" + Nam + " or (NAM=" + Nam + " and KY<" + Ky + ")) and (NAM<2020 or(NAM=2020 and KY<7)) and CAST(NGAYGIAITRACH as date)='" + NgayGiaiTrach.ToString("yyyyMMdd") + "'"
                        + " group by MaNV_DangNgan";
            dt.Merge(ExecuteQuery_DataTable(sql));
            sql = "select MaNV=MaNV_DangNgan,HoTen=(select HoTen from TT_NguoiDung where MaND=MaNV_DangNgan),'LoaiHoaDon'=N'Điện Tử',TongHD=COUNT(ID_HOADON),SUM(GIABAN)as TongGiaBan,SUM(THUE)as TongThueGTGT,SUM(PHI)as TongPhiBVMT,SUM(TONGCONG)as TongCong,"
                        + " TongTienDu=SUM(TienDu),TongTienMat=SUM(TienMat)"
                        + " from HOADON where MaNV_DangNgan=" + MaNV_DangNgan + " and (NAM<" + Nam + " or (NAM=" + Nam + " and KY<" + Ky + ")) and (NAM>2020 or(NAM=2020 and KY>=7)) and CAST(NGAYGIAITRACH as date)='" + NgayGiaiTrach.ToString("yyyyMMdd") + "'"
                        + " group by MaNV_DangNgan";
            dt.Merge(ExecuteQuery_DataTable(sql));
            return dt;
        }

        public DataTable GetTongDangNgan(string Loai, int MaNV_DangNgan, DateTime TuNgay, DateTime DenNgay)
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
        public DataTable GetTongDangNganChuyenKhoan(int MaTo, DateTime TuNgayGiaiTrach, DateTime DenNgayGiaiTrach)
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
            //            + " set @Tungaygiaitrach=" + TuNgayGiaiTrach.ToString("yyyyMMdd") + ";"
            //            + " set @Denngaygiaitrach=" + DenNgayGiaiTrach.ToString("yyyyMMdd") + ";"
            //            + " select nd.MaTo,TenTo,day(NGAYGIAITRACH) as Ngay,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
            //            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND join TT_To tto on nd.MaTo=tto.MaTo"
            //            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
            //            + " and DangNgan_ChuyenKhoan='True' and NGAYGIAITRACH>=@Tungaygiaitrach and NGAYGIAITRACH<=@Denngaygiaitrach"
            //            + " group by nd.MaTo,TenTo,day(NGAYGIAITRACH)";

            //return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongDangNganChuyenKhoanDongA(int MaTo, DateTime TuNgayGiaiTrach, DateTime DenNgayGiaiTrach)
        {
            var query = from item in _db.HOADONs
                        where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && item.DangNgan_ChuyenKhoan == true && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date
                                && (from itemDLKH in _db.TT_DuLieuKhachHang_SoHoaDons select itemDLKH.SoHoaDon).Contains(item.SOHOADON)
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
            //            + " set @Tungaygiaitrach=" + TuNgayGiaiTrach.ToString("yyyyMMdd") + ";"
            //            + " set @Denngaygiaitrach=" + DenNgayGiaiTrach.ToString("yyyyMMdd") + ";"
            //            + " select nd.MaTo,TenTo,day(NGAYGIAITRACH) as Ngay,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
            //            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND join TT_To tto on nd.MaTo=tto.MaTo"
            //            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
            //            + " and DangNgan_ChuyenKhoan='True' and NGAYGIAITRACH>=@Tungaygiaitrach and NGAYGIAITRACH<=@Denngaygiaitrach"
            //            + " group by nd.MaTo,TenTo,day(NGAYGIAITRACH)";

            //return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongDangNganChuyenKhoanExceptDongA(int MaTo, DateTime TuNgayGiaiTrach, DateTime DenNgayGiaiTrach)
        {
            var query = from item in _db.HOADONs
                        where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && item.DangNgan_ChuyenKhoan == true && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date
                                && !(from itemDLKH in _db.TT_DuLieuKhachHang_SoHoaDons select itemDLKH.SoHoaDon).Contains(item.SOHOADON)
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
            //            + " set @Tungaygiaitrach=" + TuNgayGiaiTrach.ToString("yyyyMMdd") + ";"
            //            + " set @Denngaygiaitrach=" + DenNgayGiaiTrach.ToString("yyyyMMdd") + ";"
            //            + " select nd.MaTo,TenTo,day(NGAYGIAITRACH) as Ngay,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
            //            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND join TT_To tto on nd.MaTo=tto.MaTo"
            //            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
            //            + " and DangNgan_ChuyenKhoan='True' and NGAYGIAITRACH>=@Tungaygiaitrach and NGAYGIAITRACH<=@Denngaygiaitrach"
            //            + " group by nd.MaTo,TenTo,day(NGAYGIAITRACH)";

            //return ExecuteQuery_DataTable(sql);
        }

        /// <summary>
        /// Lấy Sum hóa đơn đã đăng ngân Quầy theo Tổ trong khoảng thời gian
        /// </summary>
        /// <param name="MaTo"></param>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable GetTongDangNganQuay(int MaTo, DateTime TuNgayGiaiTrach, DateTime DenNgayGiaiTrach)
        {
            var query = from item in _db.HOADONs
                        where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        && item.DangNgan_Quay == true && item.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date
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
            //            + " set @Tungaygiaitrach=" + TuNgayGiaiTrach.ToString("yyyyMMdd") + ";"
            //            + " set @Denngaygiaitrach=" + DenNgayGiaiTrach.ToString("yyyyMMdd") + ";"
            //            + " select nd.MaTo,TenTo,day(NGAYGIAITRACH) as Ngay,count(DANHBA) as TongHD,sum(hd.TONGCONG) as TongCong"
            //            + " from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND join TT_To tto on nd.MaTo=tto.MaTo"
            //            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
            //            + " and DangNgan_ChuyenKhoan='True' and NGAYGIAITRACH>=@Tungaygiaitrach and NGAYGIAITRACH<=@Denngaygiaitrach"
            //            + " group by nd.MaTo,TenTo,day(NGAYGIAITRACH)";

            //return ExecuteQuery_DataTable(sql);
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
                            && item.ChuyenNoKhoDoi == false && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                            && item.KhoaTienDu == false
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
                                TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "TG")
                {
                    ///Tổ Hành Thu & Quầy
                    var query = from item in _db.HOADONs
                                where item.DangNgan_ChuyenKhoan == false///ngoài ngân hàng ra
                                    && item.ChuyenNoKhoDoi == false && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                    && item.KhoaTienDu == false
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
                                        && item.ChuyenNoKhoDoi == false && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                        && item.KhoaTienDu == false
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

        public DataTable GetTongHopDangNganDoi_PhanKyLon(string Loai, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            if (Loai == "CK")
            {
                ///Tổ Văn Phòng
                var query = from item in _db.HOADONs
                            where item.DangNgan_ChuyenKhoan == true///chỉ lấy ngân hàng
                            && item.ChuyenNoKhoDoi == false && item.NAM == Nam && item.KY == Ky && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                            && item.KhoaTienDu == false
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
                                TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "TG")
                {
                    ///Tổ Hành Thu & Quầy
                    var query = from item in _db.HOADONs
                                where item.DangNgan_ChuyenKhoan == false///ngoài ngân hàng ra
                                    && item.ChuyenNoKhoDoi == false && item.NAM == Nam && item.KY == Ky && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                    && item.KhoaTienDu == false
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
                                        && item.ChuyenNoKhoDoi == false && item.NAM == Nam && item.KY == Ky && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                        && item.KhoaTienDu == false
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

        public DataTable GetTongHopDangNganDoi_PhanKyNho(string Loai, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            if (Loai == "CK")
            {
                ///Tổ Văn Phòng
                var query = from item in _db.HOADONs
                            where item.DangNgan_ChuyenKhoan == true///chỉ lấy ngân hàng
                            && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || item.NAM == Nam && item.KY < Ky) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                            && item.KhoaTienDu == false
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
                                TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "TG")
                {
                    ///Tổ Hành Thu & Quầy
                    var query = from item in _db.HOADONs
                                where item.DangNgan_ChuyenKhoan == false///ngoài ngân hàng ra
                                    && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || item.NAM == Nam && item.KY < Ky) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                    && item.KhoaTienDu == false
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
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || item.NAM == Nam && item.KY < Ky) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                        && item.KhoaTienDu == false
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
            switch (Loai)
            {
                case "TG":
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                case "CQ":
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                default:
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
            }
        }

        public DataTable GetTongHopDangNganChiTiet_SyncNopTien_Ngay(string Loai, int MaTo, DateTime NgayGiaiTrach)
        {
            switch (Loai)
            {
                case "TG":
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && item.SyncNopTien_Ngay.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && item.SyncNopTien_Ngay.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                case "CQ":
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && item.SyncNopTien_Ngay.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && item.SyncNopTien_Ngay.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                default:
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && item.SyncNopTien_Ngay.Value.Date == NgayGiaiTrach.Date
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && item.SyncNopTien_Ngay.Value.Date == NgayGiaiTrach.Date
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
            }
        }

        public DataTable GetTongHopDangNganChiTiet_PhanKyLon(string Loai, int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            switch (Loai)
            {
                case "TG":
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && item.NAM == Nam && item.KY == Ky && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && item.NAM == Nam && item.KY == Ky && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                        && item.KhoaTienDu == false
                                    orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                case "CQ":
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && item.NAM == Nam && item.KY == Ky && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && item.NAM == Nam && item.KY == Ky && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                        && item.KhoaTienDu == false
                                    orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                default:
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && item.NAM == Nam && item.KY == Ky && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && item.NAM == Nam && item.KY == Ky && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                                        && item.KhoaTienDu == false
                                    orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
            }
        }

        public DataTable GetTongHopDangNganChiTiet_PhanKyNho(string Loai, int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            switch (Loai)
            {
                case "TG":
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || (item.NAM == Nam && item.KY < Ky)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || (item.NAM == Nam && item.KY < Ky)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                        && item.KhoaTienDu == false
                                    orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                case "CQ":
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || (item.NAM == Nam && item.KY < Ky)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || (item.NAM == Nam && item.KY < Ky)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                        && item.KhoaTienDu == false
                                    orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                default:
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || (item.NAM == Nam && item.KY < Ky)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || (item.NAM == Nam && item.KY < Ky)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                                        && item.KhoaTienDu == false
                                    orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
            }
        }

        public DataTable GetTongHopDangNganChiTiet_PhanKyNho_Giay(string Loai, int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            switch (Loai)
            {
                case "TG":
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || (item.NAM == Nam && item.KY < Ky)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || (item.NAM == Nam && item.KY < Ky)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                        && item.KhoaTienDu == false
                                    orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                case "CQ":
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || (item.NAM == Nam && item.KY < Ky)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || (item.NAM == Nam && item.KY < Ky)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                        && item.KhoaTienDu == false
                                    orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                default:
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || (item.NAM == Nam && item.KY < Ky)) && (item.NAM < 2020 || (item.NAM == 2020 && item.KY < 7)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || (item.NAM == Nam && item.KY < Ky)) && (item.NAM < 2020 || (item.NAM == 2020 && item.KY < 7)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                                        && item.KhoaTienDu == false
                                    orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
            }
        }

        public DataTable GetTongHopDangNganChiTiet_PhanKyNho_DienTu(string Loai, int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            switch (Loai)
            {
                case "TG":
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || (item.NAM == Nam && item.KY < Ky)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || (item.NAM == Nam && item.KY < Ky)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB >= 11 && item.GB <= 20
                                        && item.KhoaTienDu == false
                                    orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                case "CQ":
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || (item.NAM == Nam && item.KY < Ky)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || (item.NAM == Nam && item.KY < Ky)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.GB > 20
                                        && item.KhoaTienDu == false
                                    orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                default:
                    ///Tổ Văn Phòng
                    if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
                    {
                        var query = from item in _db.HOADONs
                                    where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || (item.NAM == Nam && item.KY < Ky)) && (item.NAM > 2020 || (item.NAM == 2020 && item.KY >= 7)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                                        && item.KhoaTienDu == false
                                    //orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                        TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                        TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
                    ///Tổ Hành Thu
                    else
                    {
                        var query = from item in _db.HOADONs
                                    where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                        && item.ChuyenNoKhoDoi == false && (item.NAM < Nam || (item.NAM == Nam && item.KY < Ky)) && (item.NAM > 2020 || (item.NAM == 2020 && item.KY >= 7)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                                        && item.KhoaTienDu == false
                                    orderby item.STT ascending
                                    group item by item.MaNV_DangNgan into itemGroup
                                    select new
                                    {
                                        MaNV = itemGroup.Key,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                        _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                        ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                        TongHD = itemGroup.Count(),
                                        TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                        TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                        TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                        TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                    };
                        return LINQToDataTable(query.OrderBy(item => item.STT));
                    }
            }
        }

        public DataTable GetTongHopDangNganChiTiet_Giay(int MaTo, DateTime NgayGiaiTrach)
        {
            ///Tổ Văn Phòng
            if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
            {
                var query = from item in _db.HOADONs
                            where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                && item.ChuyenNoKhoDoi == false && (item.NAM < 2020 || (item.NAM == 2020 && item.KY < 7)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                                && item.KhoaTienDu == false
                            //orderby item.STT ascending
                            group item by item.MaNV_DangNgan into itemGroup
                            select new
                            {
                                MaNV = itemGroup.Key,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                TongHD = itemGroup.Count(),
                                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                            };
                return LINQToDataTable(query.OrderBy(item => item.STT));
            }
            ///Tổ Hành Thu
            else
            {
                var query = from item in _db.HOADONs
                            where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                && item.ChuyenNoKhoDoi == false && (item.NAM < 2020 || (item.NAM == 2020 && item.KY < 7)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                                && item.KhoaTienDu == false
                            orderby item.STT ascending
                            group item by item.MaNV_DangNgan into itemGroup
                            select new
                            {
                                MaNV = itemGroup.Key,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                TongHD = itemGroup.Count(),
                                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                            };
                return LINQToDataTable(query.OrderBy(item => item.STT));
            }
        }

        public DataTable GetTongHopDangNganChiTiet_DienTu(int MaTo, DateTime NgayGiaiTrach)
        {
            ///Tổ Văn Phòng
            if (_db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).HanhThu == false && _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DongNuoc == false)
            {
                var query = from item in _db.HOADONs
                            where _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                && item.ChuyenNoKhoDoi == false && (item.NAM > 2020 || (item.NAM == 2020 && item.KY >= 7)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                                && item.KhoaTienDu == false
                            //orderby item.STT ascending
                            group item by item.MaNV_DangNgan into itemGroup
                            select new
                            {
                                MaNV = itemGroup.Key,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                TongHD = itemGroup.Count(),
                                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                                TongTienDu = itemGroup.Sum(groupItem => groupItem.TienDu),
                                TongTienMat = itemGroup.Sum(groupItem => groupItem.TienMat),
                            };
                return LINQToDataTable(query.OrderBy(item => item.STT));
            }
            ///Tổ Hành Thu
            else
            {
                var query = from item in _db.HOADONs
                            where //Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                //&& Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                _db.TT_NguoiDungs.Any(itemND => itemND.MaTo == MaTo && itemND.MaND == item.MaNV_DangNgan)///Kiểm tra nhân viên đăng ngân thuộc tổ
                                && item.ChuyenNoKhoDoi == false && (item.NAM > 2020 || (item.NAM == 2020 && item.KY >= 7)) && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                                && item.KhoaTienDu == false
                            orderby item.STT ascending
                            group item by item.MaNV_DangNgan into itemGroup
                            select new
                            {
                                MaNV = itemGroup.Key,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).STT,
                                ChuyenKhoan = itemGroup.FirstOrDefault().DangNgan_ChuyenKhoan,
                                TongHD = itemGroup.Count(),
                                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                                TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                            };
                return LINQToDataTable(query.OrderBy(item => item.STT));
            }
        }

        public DataTable GetTongHopDangNganChiTiet_HanhThuTG(DateTime NgayGiaiTrach)
        {
            string sql = "select MaND as MaNV,STT,HoTen,CAST(0 as bit) as ChuyenKhoan,TongHD,TongGiaBan,TongThueGTGT,TongPhiBVMT,TongCong from"
                        + " (select MaND,STT,HoTen from TT_NguoiDung where HanhThu=1)nd"
                        + " left join"
                        + " (select MaNV_DangNgan,COUNT(*)as TongHD,SUM(GIABAN)as TongGiaBan,SUM(THUE)as TongThueGTGT,SUM(PHI)as TongPhiBVMT,SUM(TONGCONG)as TongCong"
                        + " from HOADON where ChuyenNoKhoDoi=0 and KhoaTienDu=0 and GB>=1 and GB<=20 and CAST(NGAYGIAITRACH as date)='" + NgayGiaiTrach.ToString("yyyyMMdd") + "' group by MaNV_DangNgan)hd on hd.MaNV_DangNgan=nd.MaND"
                        + " order by nd.STT asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongHopDangNganChiTiet_HanhThuTG_PhanKyLon(int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            string sql = "select MaND as MaNV,STT,HoTen,CAST(0 as bit) as ChuyenKhoan,TongHD,TongGiaBan,TongThueGTGT,TongPhiBVMT,TongCong from"
                        + " (select MaND,STT,HoTen from TT_NguoiDung where HanhThu=1)nd"
                        + " left join"
                        + " (select MaNV_DangNgan,COUNT(*)as TongHD,SUM(GIABAN)as TongGiaBan,SUM(THUE)as TongThueGTGT,SUM(PHI)as TongPhiBVMT,SUM(TONGCONG)as TongCong"
                        + " from HOADON where ChuyenNoKhoDoi=0 and KhoaTienDu=0 and GB>=1 and GB<=20 and NAM=" + Nam + " and KY=" + Ky + " and CAST(NGAYGIAITRACH as date)='" + NgayGiaiTrach.ToString("yyyyMMdd") + "' group by MaNV_DangNgan)hd on hd.MaNV_DangNgan=nd.MaND"
                        + " order by nd.STT asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongHopDangNganChiTiet_HanhThuTG_PhanKyNho(int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            string sql = "select MaND as MaNV,STT,HoTen,CAST(0 as bit) as ChuyenKhoan,TongHD,TongGiaBan,TongThueGTGT,TongPhiBVMT,TongCong from"
                        + " (select MaND,STT,HoTen from TT_NguoiDung where HanhThu=1)nd"
                        + " left join"
                        + " (select MaNV_DangNgan,COUNT(*)as TongHD,SUM(GIABAN)as TongGiaBan,SUM(THUE)as TongThueGTGT,SUM(PHI)as TongPhiBVMT,SUM(TONGCONG)as TongCong"
                        + " from HOADON where ChuyenNoKhoDoi=0 and KhoaTienDu=0 and GB>=1 and GB<=20 and (NAM<" + Nam + " or (NAM=" + Nam + " and KY<" + Ky + ")) and CAST(NGAYGIAITRACH as date)='" + NgayGiaiTrach.ToString("yyyyMMdd") + "' group by MaNV_DangNgan)hd on hd.MaNV_DangNgan=nd.MaND"
                        + " order by nd.STT asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongHopDangNganChiTiet_HanhThu(DateTime NgayGiaiTrach)
        {
            string sql = "select MaND as MaNV,STT,HoTen,CAST(0 as bit) as ChuyenKhoan,TongHD,TongGiaBan,TongThueGTGT,TongPhiBVMT,TongCong from"
                        + " (select MaND,STT,HoTen from TT_NguoiDung where HanhThu=1)nd"
                        + " left join"
                        + " (select MaNV_DangNgan,COUNT(*)as TongHD,SUM(GIABAN)as TongGiaBan,SUM(THUE)as TongThueGTGT,SUM(PHI)as TongPhiBVMT,SUM(TONGCONG)as TongCong"
                        + " from HOADON where ChuyenNoKhoDoi=0 and KhoaTienDu=0 and CAST(NGAYGIAITRACH as date)='" + NgayGiaiTrach.ToString("yyyyMMdd") + "' group by MaNV_DangNgan)hd on hd.MaNV_DangNgan=nd.MaND"
                        + " order by nd.STT asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongHopDangNganChiTiet_HanhThu_SyncNopTien_Ngay(DateTime NgayGiaiTrach)
        {
            string sql = "select MaND as MaNV,STT,HoTen,CAST(0 as bit) as ChuyenKhoan,TongHD,TongGiaBan,TongThueGTGT,TongPhiBVMT,TongCong from"
                        + " (select MaND,STT,HoTen from TT_NguoiDung where HanhThu=1)nd"
                        + " left join"
                        + " (select MaNV_DangNgan,COUNT(*)as TongHD,SUM(GIABAN)as TongGiaBan,SUM(THUE)as TongThueGTGT,SUM(PHI)as TongPhiBVMT,SUM(TONGCONG)as TongCong"
                        + " from HOADON where ChuyenNoKhoDoi=0 and KhoaTienDu=0 and CAST(SyncNopTien_Ngay as date)='" + NgayGiaiTrach.ToString("yyyyMMdd") + "' group by MaNV_DangNgan)hd on hd.MaNV_DangNgan=nd.MaND"
                        + " order by nd.STT asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongHopDangNganChiTiet_HanhThu_PhanKyLon(int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            string sql = "select MaND as MaNV,STT,HoTen,CAST(0 as bit) as ChuyenKhoan,TongHD,TongGiaBan,TongThueGTGT,TongPhiBVMT,TongCong from"
                        + " (select MaND,STT,HoTen from TT_NguoiDung where HanhThu=1)nd"
                        + " left join"
                        + " (select MaNV_DangNgan,COUNT(*)as TongHD,SUM(GIABAN)as TongGiaBan,SUM(THUE)as TongThueGTGT,SUM(PHI)as TongPhiBVMT,SUM(TONGCONG)as TongCong"
                        + " from HOADON where ChuyenNoKhoDoi=0 and KhoaTienDu=0 and NAM=" + Nam + " and KY=" + Ky + " and CAST(NGAYGIAITRACH as date)='" + NgayGiaiTrach.ToString("yyyyMMdd") + "' group by MaNV_DangNgan)hd on hd.MaNV_DangNgan=nd.MaND"
                        + " order by nd.STT asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongHopDangNganChiTiet_HanhThu_PhanKyNho_Giay(int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            string sql = "select MaND as MaNV,STT,HoTen,CAST(0 as bit) as ChuyenKhoan,TongHD,TongGiaBan,TongThueGTGT,TongPhiBVMT,TongCong from"
                        + " (select MaND,STT,HoTen from TT_NguoiDung where HanhThu=1)nd"
                        + " left join"
                        + " (select MaNV_DangNgan,COUNT(*)as TongHD,SUM(GIABAN)as TongGiaBan,SUM(THUE)as TongThueGTGT,SUM(PHI)as TongPhiBVMT,SUM(TONGCONG)as TongCong"
                        + " from HOADON where ChuyenNoKhoDoi=0 and KhoaTienDu=0 and (NAM<" + Nam + " or (NAM=" + Nam + " and KY<" + Ky + ")) and (NAM<2020 or(NAM=2020 and KY<7)) and CAST(NGAYGIAITRACH as date)='" + NgayGiaiTrach.ToString("yyyyMMdd") + "' group by MaNV_DangNgan)hd on hd.MaNV_DangNgan=nd.MaND"
                        + " order by nd.STT asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongHopDangNganChiTiet_HanhThu_PhanKyNho_DienTu(int Nam, int Ky, DateTime NgayGiaiTrach)
        {
            string sql = "select MaND as MaNV,STT,HoTen,CAST(0 as bit) as ChuyenKhoan,TongHD,TongGiaBan,TongThueGTGT,TongPhiBVMT,TongCong from"
                        + " (select MaND,STT,HoTen from TT_NguoiDung where HanhThu=1)nd"
                        + " left join"
                        + " (select MaNV_DangNgan,COUNT(*)as TongHD,SUM(GIABAN)as TongGiaBan,SUM(THUE)as TongThueGTGT,SUM(PHI)as TongPhiBVMT,SUM(TONGCONG)as TongCong"
                        + " from HOADON where ChuyenNoKhoDoi=0 and KhoaTienDu=0 and (NAM<" + Nam + " or (NAM=" + Nam + " and KY<" + Ky + ")) and (NAM>2020 or(NAM=2020 and KY>=7)) and CAST(NGAYGIAITRACH as date)='" + NgayGiaiTrach.ToString("yyyyMMdd") + "' group by MaNV_DangNgan)hd on hd.MaNV_DangNgan=nd.MaND"
                        + " order by nd.STT asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongHopDangNganChiTiet_HanhThu_Giay(DateTime NgayGiaiTrach)
        {
            string sql = "select MaND as MaNV,STT,HoTen,CAST(0 as bit) as ChuyenKhoan,TongHD,TongGiaBan,TongThueGTGT,TongPhiBVMT,TongCong from"
                        + " (select MaND,STT,HoTen from TT_NguoiDung where HanhThu=1)nd"
                        + " left join"
                        + " (select MaNV_DangNgan,COUNT(*)as TongHD,SUM(GIABAN)as TongGiaBan,SUM(THUE)as TongThueGTGT,SUM(PHI)as TongPhiBVMT,SUM(TONGCONG)as TongCong"
                        + " from HOADON where ChuyenNoKhoDoi=0 and KhoaTienDu=0 and (NAM<2020 or (NAM=2020 and KY<7)) and CAST(NGAYGIAITRACH as date)='" + NgayGiaiTrach.ToString("yyyyMMdd") + "' group by MaNV_DangNgan)hd on hd.MaNV_DangNgan=nd.MaND"
                        + " order by nd.STT asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetTongHopDangNganChiTiet_HanhThu_DienTu(DateTime NgayGiaiTrach)
        {
            string sql = "select MaND as MaNV,STT,HoTen,CAST(0 as bit) as ChuyenKhoan,TongHD,TongGiaBan,TongThueGTGT,TongPhiBVMT,TongCong from"
                        + " (select MaND,STT,HoTen from TT_NguoiDung where HanhThu=1)nd"
                        + " left join"
                        + " (select MaNV_DangNgan,COUNT(*)as TongHD,SUM(GIABAN)as TongGiaBan,SUM(THUE)as TongThueGTGT,SUM(PHI)as TongPhiBVMT,SUM(TONGCONG)as TongCong"
                        + " from HOADON where ChuyenNoKhoDoi=0 and KhoaTienDu=0 and (NAM>2020 or (NAM=2020 and KY>=7)) and CAST(NGAYGIAITRACH as date)='" + NgayGiaiTrach.ToString("yyyyMMdd") + "' group by MaNV_DangNgan)hd on hd.MaNV_DangNgan=nd.MaND"
                        + " order by nd.STT asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getTongHopDangNgan_KeToan_TheoNgay(DateTime FromNgayGiaiTrach, DateTime ToNgayGiaiTrach)
        {
            //string sql = "declare @FromNgayGiaiTrach date"
            //            + " declare @ToNgayGiaiTrach date"
            //            + " set @FromNgayGiaiTrach='" + FromNgayGiaiTrach.ToString("yyyyMMdd") + "'"
            //            + " set @ToNgayGiaiTrach='" + ToNgayGiaiTrach.ToString("yyyyMMdd") + "'"
            //    //cùng kỳ
            //            + " select STT=1,Loai=N'Hành Thu',PhanKy=N'Cùng Kỳ',NgayGiaiTrach=CAST(NGAYGIAITRACH as date),GiaBan=SUM(GIABAN),ThueGTGT=SUM(THUE),PhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG) from HOADON"
            //            + " where CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach and KY=MONTH(@FromNgayGiaiTrach) and NAM=YEAR(@FromNgayGiaiTrach) and (DangNgan_HanhThu=1 or DangNgan_Ton=1)"
            //            + " group by CAST(NGAYGIAITRACH as date)"
            //            + " union all"
            //            + " select STT=2,Loai=N'Quầy',PhanKy=N'Cùng Kỳ',NgayGiaiTrach=CAST(NGAYGIAITRACH as date),GiaBan=SUM(GIABAN),ThueGTGT=SUM(THUE),PhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG) from HOADON"
            //            + " where CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach and KY=MONTH(@FromNgayGiaiTrach) and NAM=YEAR(@FromNgayGiaiTrach) and DangNgan_Quay=1"
            //            + " group by CAST(NGAYGIAITRACH as date)"
            //            + " union all"
            //            + " select STT=3,Loai=N'Chuyển Khoản',PhanKy=N'Cùng Kỳ',NgayGiaiTrach=CAST(NGAYGIAITRACH as date),GiaBan=SUM(GIABAN),ThueGTGT=SUM(THUE),PhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG) from HOADON"
            //            + " where CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach and KY=MONTH(@FromNgayGiaiTrach) and NAM=YEAR(@FromNgayGiaiTrach) and DangNgan_ChuyenKhoan=1"
            //            + " group by CAST(NGAYGIAITRACH as date)"
            //            + " union all"
            //    //khác kỳ
            //            + " select STT=1,Loai=N'Hành Thu',PhanKy=N'Khác Kỳ',NgayGiaiTrach=CAST(NGAYGIAITRACH as date),GiaBan=SUM(GIABAN),ThueGTGT=SUM(THUE),PhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG) from HOADON"
            //            + " where CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach and (NAM!=YEAR(@FromNgayGiaiTrach) or (KY!=MONTH(@FromNgayGiaiTrach) and NAM=YEAR(@FromNgayGiaiTrach))) and (DangNgan_HanhThu=1 or DangNgan_Ton=1)"
            //            + " group by CAST(NGAYGIAITRACH as date)"
            //            + " union all"
            //            + " select STT=2,Loai=N'Quầy',PhanKy=N'Khác Kỳ',NgayGiaiTrach=CAST(NGAYGIAITRACH as date),GiaBan=SUM(GIABAN),ThueGTGT=SUM(THUE),PhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG) from HOADON"
            //            + " where CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach and (NAM!=YEAR(@FromNgayGiaiTrach) or (KY!=MONTH(@FromNgayGiaiTrach) and NAM=YEAR(@FromNgayGiaiTrach))) and DangNgan_Quay=1"
            //            + " group by CAST(NGAYGIAITRACH as date)"
            //            + " union all"
            //            + " select STT=3,Loai=N'Chuyển Khoản',PhanKy=N'Khác Kỳ',NgayGiaiTrach=CAST(NGAYGIAITRACH as date),GiaBan=SUM(GIABAN),ThueGTGT=SUM(THUE),PhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG) from HOADON"
            //            + " where CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach and (NAM!=YEAR(@FromNgayGiaiTrach) or (KY!=MONTH(@FromNgayGiaiTrach) and NAM=YEAR(@FromNgayGiaiTrach))) and DangNgan_ChuyenKhoan=1"
            //            + " group by CAST(NGAYGIAITRACH as date)"
            //            + " order by PhanKy,NgayGiaiTrach,STT";
            string sql = "declare @FromNgayGiaiTrach date"
                        + " declare @ToNgayGiaiTrach date"
                        + " set @FromNgayGiaiTrach='" + FromNgayGiaiTrach.ToString("yyyyMMdd") + "'"
                        + " set @ToNgayGiaiTrach='" + ToNgayGiaiTrach.ToString("yyyyMMdd") + "'"
                        + " select *,STT=CONVERT(varchar(8),NgayGiaiTrach,112) from"
                        + " (select PhanKy=N'Cùng Kỳ',NgayGiaiTrach=CAST(NGAYGIAITRACH as date),GiaBan=SUM(GIABAN),ThueGTGT=SUM(THUE),PhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG) from HOADON"
                        + " where CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach and KY=MONTH(@ToNgayGiaiTrach) and NAM=YEAR(@ToNgayGiaiTrach) and ChuyenNoKhoDoi=0"
                        + " group by CAST(NGAYGIAITRACH as date)"
                        + " union all"
                        + " select PhanKy=N'Khác Kỳ',NgayGiaiTrach=CAST(NGAYGIAITRACH as date),GiaBan=SUM(GIABAN),ThueGTGT=SUM(THUE),PhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG) from HOADON"
                        + " where CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach and KY<MONTH(@ToNgayGiaiTrach) and NAM=YEAR(@ToNgayGiaiTrach) and ChuyenNoKhoDoi=0"
                        + " group by CAST(NGAYGIAITRACH as date)"
                        + " union all"
                        + " select PhanKy=N'Khác Kỳ Năm',NgayGiaiTrach=CAST(NGAYGIAITRACH as date),GiaBan=SUM(GIABAN),ThueGTGT=SUM(THUE),PhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG) from HOADON"
                        + " where CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach and NAM<YEAR(@ToNgayGiaiTrach) and ChuyenNoKhoDoi=0"
                        + " group by CAST(NGAYGIAITRACH as date))t1"
                        + " order by PhanKy,NgayGiaiTrach";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getTongHopDangNgan_KeToan_TheoThang(DateTime FromNgayGiaiTrach, DateTime ToNgayGiaiTrach)
        {
            string sql = "declare @FromNgayGiaiTrach date"
                        + " declare @ToNgayGiaiTrach date"
                        + " set @FromNgayGiaiTrach='" + FromNgayGiaiTrach.ToString("yyyyMMdd") + "'"
                        + " set @ToNgayGiaiTrach='" + ToNgayGiaiTrach.ToString("yyyyMMdd") + "'"
                        + " select *,STT=CONVERT(varchar(8),NgayGiaiTrach,112) from"
                        + " (select PhanKy=N'Cùng Kỳ',NgayGiaiTrach=RIGHT('0' + CAST(MONTH(NGAYGIAITRACH) as varchar(2)),2)+'/'+CONVERT(varchar(4),YEAR(NGAYGIAITRACH)),GiaBan=SUM(GIABAN),ThueGTGT=SUM(THUE),PhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG) from HOADON"
                        + " where CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach and KY=MONTH(@ToNgayGiaiTrach) and NAM=YEAR(@ToNgayGiaiTrach) and ChuyenNoKhoDoi=0"
                        + " group by RIGHT('0' + CAST(MONTH(NGAYGIAITRACH) as varchar(2)),2)+'/'+CONVERT(varchar(4),YEAR(NGAYGIAITRACH))"
                        + " union all"
                        + " select PhanKy=N'Khác Kỳ',NgayGiaiTrach=RIGHT('0' + CAST(MONTH(NGAYGIAITRACH) as varchar(2)),2)+'/'+CONVERT(varchar(4),YEAR(NGAYGIAITRACH)),GiaBan=SUM(GIABAN),ThueGTGT=SUM(THUE),PhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG) from HOADON"
                        + " where CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach and KY<MONTH(NGAYGIAITRACH) and NAM=YEAR(@ToNgayGiaiTrach) and ChuyenNoKhoDoi=0"
                        + " group by RIGHT('0' + CAST(MONTH(NGAYGIAITRACH) as varchar(2)),2)+'/'+CONVERT(varchar(4),YEAR(NGAYGIAITRACH))"
                        + " union all"
                        + " select PhanKy=N'Khác Kỳ Năm',NgayGiaiTrach=RIGHT('0' + CAST(MONTH(NGAYGIAITRACH) as varchar(2)),2)+'/'+CONVERT(varchar(4),YEAR(NGAYGIAITRACH)),GiaBan=SUM(GIABAN),ThueGTGT=SUM(THUE),PhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG) from HOADON"
                        + " where CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach and NAM<YEAR(@ToNgayGiaiTrach) and ChuyenNoKhoDoi=0"
                        + " group by RIGHT('0' + CAST(MONTH(NGAYGIAITRACH) as varchar(2)),2)+'/'+CONVERT(varchar(4),YEAR(NGAYGIAITRACH)))t1"
                        + " order by PhanKy,NgayGiaiTrach";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getTongHopDangNgan_KeToan_CungKy(DateTime FromNgayGiaiTrach, DateTime ToNgayGiaiTrach)
        {
            string sql = "declare @FromNgayGiaiTrach date"
                        + " declare @ToNgayGiaiTrach date"
                        + " set @FromNgayGiaiTrach='" + FromNgayGiaiTrach.ToString("yyyyMMdd") + "'"
                        + " set @ToNgayGiaiTrach='" + ToNgayGiaiTrach.ToString("yyyyMMdd") + "'"
                        + " select STT=1,Loai=N'Hành Thu',PhanKy=N'Cùng Kỳ',NgayGiaiTrach=CAST(NGAYGIAITRACH as date),GiaBan=SUM(GIABAN),ThueGTGT=SUM(THUE),PhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG) from HOADON"
                        + " where CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach and KY=MONTH(@FromNgayGiaiTrach) and NAM=YEAR(@FromNgayGiaiTrach) and (DangNgan_HanhThu=1 or DangNgan_Ton=1)"
                        + " group by CAST(NGAYGIAITRACH as date)"
                        + " union all"
                        + " select STT=2,Loai=N'Quầy',PhanKy=N'Cùng Kỳ',NgayGiaiTrach=CAST(NGAYGIAITRACH as date),GiaBan=SUM(GIABAN),ThueGTGT=SUM(THUE),PhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG) from HOADON"
                        + " where CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach and KY=MONTH(@FromNgayGiaiTrach) and NAM=YEAR(@FromNgayGiaiTrach) and DangNgan_Quay=1"
                        + " group by CAST(NGAYGIAITRACH as date)"
                        + " union all"
                        + " select STT=3,Loai=N'Chuyển Khoản',PhanKy=N'Cùng Kỳ',NgayGiaiTrach=CAST(NGAYGIAITRACH as date),GiaBan=SUM(GIABAN),ThueGTGT=SUM(THUE),PhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG) from HOADON"
                        + " where CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach and KY=MONTH(@FromNgayGiaiTrach) and NAM=YEAR(@FromNgayGiaiTrach) and DangNgan_ChuyenKhoan=1"
                        + " group by CAST(NGAYGIAITRACH as date)"
                        + " order by PhanKy,NgayGiaiTrach,STT;";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getTongHopDangNgan_KeToan_KhacKy(DateTime FromNgayGiaiTrach, DateTime ToNgayGiaiTrach)
        {
            string sql = "declare @FromNgayGiaiTrach date"
                        + " declare @ToNgayGiaiTrach date"
                        + " set @FromNgayGiaiTrach='" + FromNgayGiaiTrach.ToString("yyyyMMdd") + "'"
                        + " set @ToNgayGiaiTrach='" + ToNgayGiaiTrach.ToString("yyyyMMdd") + "'"
                        + " select STT=1,Loai=N'Hành Thu',PhanKy=N'Khác Kỳ',NgayGiaiTrach=CAST(NGAYGIAITRACH as date),GiaBan=SUM(GIABAN),ThueGTGT=SUM(THUE),PhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG) from HOADON"
                        + " where CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach and (NAM!=YEAR(@FromNgayGiaiTrach) or (KY!=MONTH(@FromNgayGiaiTrach) and NAM=YEAR(@FromNgayGiaiTrach))) and (DangNgan_HanhThu=1 or DangNgan_Ton=1)"
                        + " group by CAST(NGAYGIAITRACH as date)"
                        + " union all"
                        + " select STT=2,Loai=N'Quầy',PhanKy=N'Khác Kỳ',NgayGiaiTrach=CAST(NGAYGIAITRACH as date),GiaBan=SUM(GIABAN),ThueGTGT=SUM(THUE),PhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG) from HOADON"
                        + " where CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach and (NAM!=YEAR(@FromNgayGiaiTrach) or (KY!=MONTH(@FromNgayGiaiTrach) and NAM=YEAR(@FromNgayGiaiTrach))) and DangNgan_Quay=1"
                        + " group by CAST(NGAYGIAITRACH as date)"
                        + " union all"
                        + " select STT=3,Loai=N'Chuyển Khoản',PhanKy=N'Khác Kỳ',NgayGiaiTrach=CAST(NGAYGIAITRACH as date),GiaBan=SUM(GIABAN),ThueGTGT=SUM(THUE),PhiBVMT=SUM(PHI),TongCong=SUM(TONGCONG) from HOADON"
                        + " where CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach and (NAM!=YEAR(@FromNgayGiaiTrach) or (KY!=MONTH(@FromNgayGiaiTrach) and NAM=YEAR(@FromNgayGiaiTrach))) and DangNgan_ChuyenKhoan=1"
                        + " group by CAST(NGAYGIAITRACH as date)"
                        + " order by PhanKy,NgayGiaiTrach,STT;";
            return ExecuteQuery_DataTable(sql);
        }

        /// <summary>
        /// Lấy Sum thông tin những hóa đơn đã chia cho từng anh/em cụ thể
        /// </summary>
        /// <param name="MaNV"></param>
        /// <param name="nam"></param>
        /// <param name="ky"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        public DataTable GetTongTGByMaNVNamKyDot(int MaNV_HanhThu, int Nam, int Ky, int Dot)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.MaNV_HanhThu == MaNV_HanhThu
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

        public DataTable GetTongByMaNVNamKyDot(int MaNV_HanhThu, int Nam, int Ky, int Dot)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.MaNV_HanhThu == MaNV_HanhThu
                        group item by item.MaNV_HanhThu into itemGroup
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

        public DataTable getDS_HoaDonDienTu_All(int MaNV_HanhThu, int Nam, int Ky, int FromDot, int ToDot)
        {
            if (_db.TT_NguoiDungs.SingleOrDefault(itemA => itemA.MaND == MaNV_HanhThu).DongNuoc == false)
            {
                var query = from item in _db.HOADONs
                            where (item.NAM < Nam || (item.NAM == Nam && item.KY <= Ky)) && item.DOT >= FromDot && item.DOT <= ToDot && item.MaNV_HanhThu == MaNV_HanhThu
                            orderby item.MALOTRINH ascending
                            select new
                            {
                                item.NGAYGIAITRACH,
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                MLT = item.MALOTRINH,
                                item.SOPHATHANH,
                                DanhBo = item.DANHBA,
                                HoTen = item.TENKH,
                                DiaChi = item.SO + " " + item.DUONG,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                                item.DangNgan_DienThoai,
                                item.InPhieuBao_Ngay,
                                item.InPhieuBao2_Ngay,
                                item.XoaDangNgan_Ngay_DienThoai,
                                item.TBDongNuoc_Ngay,
                                item.DangNgan_DienThoai_Location,
                                item.InPhieuBao_Location,
                                item.InPhieuBao2_Location,
                                item.TBDongNuoc_Location,
                                item.XoaDangNgan_Location_DienThoai,
                            };
                return LINQToDataTable(query);
            }
            else
            {
                var query = from item in _db.HOADONs
                            where (item.NAM < Nam || (item.NAM == Nam && item.KY <= Ky)) && item.DOT >= FromDot && item.DOT <= ToDot
                            && (item.InPhieuBao_MaNV == MaNV_HanhThu || item.InPhieuBao2_MaNV == MaNV_HanhThu || item.TBDongNuoc_MaNV == MaNV_HanhThu)
                            orderby item.MALOTRINH ascending
                            select new
                            {
                                item.NGAYGIAITRACH,
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                MLT = item.MALOTRINH,
                                item.SOPHATHANH,
                                DanhBo = item.DANHBA,
                                HoTen = item.TENKH,
                                DiaChi = item.SO + " " + item.DUONG,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                                item.DangNgan_DienThoai,
                                item.InPhieuBao_Ngay,
                                item.InPhieuBao2_Ngay,
                                item.XoaDangNgan_Ngay_DienThoai,
                                item.TBDongNuoc_Ngay,
                                item.DangNgan_DienThoai_Location,
                                item.InPhieuBao_Location,
                                item.InPhieuBao2_Location,
                                item.TBDongNuoc_Location,
                                item.XoaDangNgan_Location_DienThoai,
                            };
                return LINQToDataTable(query);
            }
        }

        public DataTable getDS_HoaDonDienTu_Ton(int MaNV_HanhThu, int Nam, int Ky, int FromDot, int ToDot)
        {
            if (_db.TT_NguoiDungs.SingleOrDefault(itemA => itemA.MaND == MaNV_HanhThu).DongNuoc == false)
            {
                var query = from item in _db.HOADONs
                            where (item.NAM < Nam || (item.NAM == Nam && item.KY <= Ky)) && item.DOT >= FromDot && item.DOT <= ToDot && item.MaNV_HanhThu == MaNV_HanhThu
                            && (item.NGAYGIAITRACH == null || item.NGAYGIAITRACH.Value.Date == DateTime.Now.Date)
                            orderby item.MALOTRINH ascending
                            select new
                            {
                                item.NGAYGIAITRACH,
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                MLT = item.MALOTRINH,
                                item.SOPHATHANH,
                                DanhBo = item.DANHBA,
                                HoTen = item.TENKH,
                                DiaChi = item.SO + " " + item.DUONG,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                                item.DangNgan_DienThoai,
                                item.InPhieuBao_Ngay,
                                item.InPhieuBao2_Ngay,
                                item.XoaDangNgan_Ngay_DienThoai,
                                item.TBDongNuoc_Ngay,
                                item.DangNgan_DienThoai_Location,
                                item.InPhieuBao_Location,
                                item.InPhieuBao2_Location,
                                item.TBDongNuoc_Location,
                                item.XoaDangNgan_Location_DienThoai,
                            };
                return LINQToDataTable(query);
            }
            else
            {
                var query = from item in _db.HOADONs
                            where (item.NAM < Nam || (item.NAM == Nam && item.KY <= Ky)) && item.DOT >= FromDot && item.DOT <= ToDot
                            && (item.InPhieuBao_MaNV == MaNV_HanhThu || item.InPhieuBao2_MaNV == MaNV_HanhThu || item.TBDongNuoc_MaNV == MaNV_HanhThu)
                            && (item.NGAYGIAITRACH == null || item.NGAYGIAITRACH.Value.Date == DateTime.Now.Date)
                            orderby item.MALOTRINH ascending
                            select new
                            {
                                item.NGAYGIAITRACH,
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                MLT = item.MALOTRINH,
                                item.SOPHATHANH,
                                DanhBo = item.DANHBA,
                                HoTen = item.TENKH,
                                DiaChi = item.SO + " " + item.DUONG,
                                item.TIEUTHU,
                                item.GIABAN,
                                ThueGTGT = item.THUE,
                                PhiBVMT = item.PHI,
                                item.TONGCONG,
                                item.DangNgan_DienThoai,
                                item.InPhieuBao_Ngay,
                                item.InPhieuBao2_Ngay,
                                item.XoaDangNgan_Ngay_DienThoai,
                                item.TBDongNuoc_Ngay,
                                item.DangNgan_DienThoai_Location,
                                item.InPhieuBao_Location,
                                item.InPhieuBao2_Location,
                                item.TBDongNuoc_Location,
                                item.XoaDangNgan_Location_DienThoai,
                            };
                return LINQToDataTable(query);
            }
        }

        public DataTable getCount_CongViec(int MaNV_HanhThu, int Nam, int Ky, int FromDot, int ToDot, DateTime Ngay)
        {
            string sql = "declare @Ngay date"
                        + " set @Ngay='" + Ngay.ToString("yyyyMMdd") + "'"
                        + " if ((select DongNuoc from TT_NguoiDung where MaND=" + MaNV_HanhThu + ")=0)"
                        + " select Dot,TongCong=FORMAT(COUNT(ID_HOADON), '#,#')+' - '+ FORMAT(SUM(TONGCONG), '#,#')"
                        + " ,NhacNo=FORMAT(COUNT(case when (CAST(InPhieuBao_Ngay as date)=@Ngay or CAST(InPhieuBao2_Ngay as date)=@Ngay) then 1 else null end), '#,#')+' - '+FORMAT(SUM(case when (CAST(InPhieuBao_Ngay as date)=@Ngay or CAST(InPhieuBao2_Ngay as date)=@Ngay) then TONGCONG else null end), '#,#')"
                        + " ,ThuHo=FORMAT(COUNT(case when (dvt.MaHD is not null and CAST(dvt.CreateDate as date)=@Ngay) then 1 else null end), '#,#')+' - '+FORMAT(SUM(case when (dvt.MaHD is not null and CAST(dvt.CreateDate as date)=@Ngay) then TONGCONG else null end), '#,#')"
                        + " ,ChuaDi=FORMAT(COUNT(case when (InPhieuBao_Ngay is null and InPhieuBao2_Ngay is null) then 1 else null end), '#,#')+' - '+FORMAT(SUM(case when (InPhieuBao_Ngay is null and InPhieuBao2_Ngay is null) then TONGCONG else null end), '#,#')"
                        + " from HOADON hd left join TT_DichVuThu dvt on dvt.MaHD=hd.ID_HOADON"
                        + " where hd.NAM=" + Nam + " and hd.KY=" + Ky + " and DOT>=" + FromDot + " and DOT<=" + ToDot + " and MaNV_HanhThu=" + MaNV_HanhThu + " group by DOT"
                        + " else"
                        + " select Dot,TongCong=FORMAT(COUNT(ID_HOADON), '#,#')+' - '+ FORMAT(SUM(TONGCONG), '#,#')"
                        + " ,NhacNo=FORMAT(COUNT(case when (CAST(InPhieuBao_Ngay as date)=@Ngay or CAST(InPhieuBao2_Ngay as date)=@Ngay) then 1 else null end), '#,#')+' - '+FORMAT(SUM(case when (CAST(InPhieuBao_Ngay as date)=@Ngay or CAST(InPhieuBao2_Ngay as date)=@Ngay) then TONGCONG else null end), '#,#')"
                        + " ,ThuHo=FORMAT(COUNT(case when (dvt.MaHD is not null and CAST(dvt.CreateDate as date)=@Ngay) then 1 else null end), '#,#')+' - '+FORMAT(SUM(case when (dvt.MaHD is not null and CAST(dvt.CreateDate as date)=@Ngay) then TONGCONG else null end), '#,#')"
                        + " ,ChuaDi=FORMAT(COUNT(case when (InPhieuBao_Ngay is null and InPhieuBao2_Ngay is null) then 1 else null end), '#,#')+' - '+FORMAT(SUM(case when (InPhieuBao_Ngay is null and InPhieuBao2_Ngay is null) then TONGCONG else null end), '#,#')"
                        + " from HOADON hd left join TT_DichVuThu dvt on dvt.MaHD=hd.ID_HOADON"
                        + " where hd.NAM=" + Nam + " and hd.KY=" + Ky + " and DOT>=" + FromDot + " and DOT<=" + ToDot + " and (InPhieuBao_MaNV=" + MaNV_HanhThu + " or InPhieuBao2_MaNV=" + MaNV_HanhThu + " or TBDongNuoc_MaNV=" + MaNV_HanhThu + ") group by DOT";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS(int MaTo, int Nam, int Ky, int Dot)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == Nam && item.KY == Ky && item.DOT == Dot
                        && Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                        && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        orderby item.MALOTRINH ascending
                        select new
                        {
                            item.NGAYGIAITRACH,
                            item.SOHOADON,
                            Ky = item.KY + "/" + item.NAM,
                            MLT = item.MALOTRINH,
                            item.SOPHATHANH,
                            DanhBo = item.DANHBA,
                            HoTen = item.TENKH,
                            DiaChi = item.SO + " " + item.DUONG,
                            item.TIEUTHU,
                            item.GIABAN,
                            ThueGTGT = item.THUE,
                            PhiBVMT = item.PHI,
                            item.TONGCONG,
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
        public DataTable GetDSDangNganHanhThuTG(int MaNV_DangNgan, int Nam, int Ky, int Dot)
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

        public DataTable GetDSDangNganHanhThu(int MaNV_DangNgan, int Nam, int Ky, int Dot)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.DangNgan_HanhThu == true && item.MaNV_DangNgan == MaNV_DangNgan
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

        public DataTable GetDSDangNganHanhThu(string Loai, int MaNV_DangNgan, DateTime NgayGiaiTrach)
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
                else
                    if (Loai == "")
                    {
                        var query = from item in _db.HOADONs
                                    where item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.DangNgan_HanhThu == true && item.MaNV_DangNgan == MaNV_DangNgan
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

        public DataTable GetDSDangNganDum(int MaNV_HanhThu, Nullable<int> MaNV_DangNgan, int Nam, int Ky, int Dot, DateTime NgayGiaiTrach)
        {
            if (MaNV_DangNgan.HasValue)
            {
                var query = from item in _db.HOADONs
                            where item.MaNV_HanhThu == MaNV_HanhThu && item.MaNV_DangNgan == MaNV_DangNgan && item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
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
            {
                var query = from item in _db.HOADONs
                            where item.MaNV_HanhThu == MaNV_HanhThu && item.MaNV_DangNgan == null && item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
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
        }

        public DataTable GetDSDangNgan_KeToan_Chot2019(DateTime FromNgayGiaiTrach, DateTime ToNgayGiaiTrach)
        {
            var query = from item in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on item.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.NGAYGIAITRACH.Value.Date >= FromNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= ToNgayGiaiTrach.Date && item.ChuyenNoKhoDoi == false
                        orderby item.MALOTRINH ascending
                        select new
                        {
                            item.NGAYGIAITRACH,
                            item.SOHOADON,
                            Ky = item.KY + "/" + item.NAM,
                            Ky2 = item.KY,
                            Nam2 = item.NAM,
                            MLT = item.MALOTRINH,
                            item.SOPHATHANH,
                            DanhBo = item.DANHBA,
                            HoTen = item.TENKH,
                            item.TIEUTHU,
                            item.GIABAN,
                            ThueGTGT = item.THUE,
                            PhiBVMT = item.PHI,
                            item.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = item.GB,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDangNgan(DateTime FromNgayGiaiTrach, DateTime ToNgayGiaiTrach)
        {
            var query = from item in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on item.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.NGAYGIAITRACH.Value.Date >= FromNgayGiaiTrach.Date && item.NGAYGIAITRACH.Value.Date <= ToNgayGiaiTrach.Date
                        orderby item.MALOTRINH ascending
                        select new
                        {
                            item.NGAYGIAITRACH,
                            item.SOHOADON,
                            Ky = item.KY + "/" + item.NAM,
                            Ky2 = item.KY,
                            Nam2 = item.NAM,
                            MLT = item.MALOTRINH,
                            item.SOPHATHANH,
                            DanhBo = item.DANHBA,
                            HoTen = item.TENKH,
                            item.TIEUTHU,
                            item.GIABAN,
                            ThueGTGT = item.THUE,
                            PhiBVMT = item.PHI,
                            item.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = item.GB,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDangNgan(int MaNV_DangNgan, DateTime NgayGiaiTrach)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.MaNV_DangNgan == MaNV_DangNgan && itemHD.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDangNgan(string Loai, int MaNV_DangNgan, DateTime NgayGiaiTrach)
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
                else
                    if (Loai == "")
                    {
                        var query = from item in _db.HOADONs
                                    where item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && item.MaNV_DangNgan == MaNV_DangNgan
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

        public DataTable GetDSDangNgan(Nullable<int> MaNV_DangNgan, DateTime FromNgayGiaiTrach, DateTime ToNgayGiaiTrach)
        {
            if (MaNV_DangNgan.HasValue)
            {
                var query = from itemHD in _db.HOADONs
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemHD.MaNV_DangNgan == MaNV_DangNgan && itemHD.NGAYGIAITRACH.Value.Date >= FromNgayGiaiTrach.Date && itemHD.NGAYGIAITRACH.Value.Date <= ToNgayGiaiTrach.Date
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                itemHD.NGAYGIAITRACH,
                                itemHD.SOHOADON,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                MLT = itemHD.MALOTRINH,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                itemHD.TONGCONG,
                                GiaBieu = itemHD.GB,
                                To = itemtableND.TT_To.TenTo,
                                HanhThu = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            else
            {
                var query = from itemHD in _db.HOADONs
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemHD.MaNV_DangNgan == null && itemHD.NGAYGIAITRACH.Value.Date >= FromNgayGiaiTrach.Date && itemHD.NGAYGIAITRACH.Value.Date <= ToNgayGiaiTrach.Date
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                itemHD.NGAYGIAITRACH,
                                itemHD.SOHOADON,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                MLT = itemHD.MALOTRINH,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                itemHD.TONGCONG,
                                GiaBieu = itemHD.GB,
                                To = itemtableND.TT_To.TenTo,
                                HanhThu = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
        }

        public DataTable getDSDangNgan_CoDCHD(DateTime NgayGiaiTrach)
        {
            var query = from item in _db.HOADONs
                        where item.DCHD == true && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
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
                            item.TienDu,
                            item.TienMat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSDangNgan_CoDCHD(int MaTo, DateTime NgayGiaiTrach)
        {
            var query = from item in _db.HOADONs
                        where item.DCHD == true && item.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && _db.TT_NguoiDungs.SingleOrDefault(itemA => itemA.MaND == item.MaNV_DangNgan).MaTo == MaTo
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
                            item.TienDu,
                            item.TienMat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSDangNgan_ChuaNopTien(DateTime NgayGiaiTrach)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.SyncNopTien == false && itemHD.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && (itemHD.NAM > 2020 || (itemHD.NAM == 2020 && itemHD.KY >= 7)) && itemHD.MaNV_DangNgan != null
                        && itemHD.BaoCaoThue == false
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSDangNgan_HDDCBaoCaoThue(DateTime NgayGiaiTrach)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && (itemHD.NAM > 2020 || (itemHD.NAM == 2020 && itemHD.KY >= 7)) && itemHD.MaNV_DangNgan != null
                        && itemHD.BaoCaoThue == true
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSXoaDangNgan_HoaDonDienTu(int MaNV_HanhThu, DateTime NgayXoaDangNgan)
        {
            var query = from item in _db.HOADONs
                        where item.XoaDangNgan_Ngay_DienThoai.Value.Date == NgayXoaDangNgan.Date && item.MaNV_HanhThu == MaNV_HanhThu
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
                            item.XoaDangNgan_Ngay_DienThoai,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSInPhieuBao_HoaDonDienTu(int MaNV_HanhThu, DateTime NgayInPhieuBao)
        {
            var query = from item in _db.HOADONs
                        where item.InPhieuBao_Ngay.Value.Date == NgayInPhieuBao.Date && item.MaNV_HanhThu == MaNV_HanhThu
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

        public DataTable getDSInTBDongNuoc_HoaDonDienTu(int MaNV_HanhThu, DateTime NgayInTBDongNuoc)
        {
            var query = from item in _db.HOADONs
                        where item.TBDongNuoc_Ngay.Value.Date == NgayInTBDongNuoc.Date && item.MaNV_HanhThu == MaNV_HanhThu
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

        public DataTable GetDSDangNgan_To(string Loai, int MaTo, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemHD in _db.HOADONs
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                             && itemHD.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && itemHD.GB >= 11 && itemHD.GB <= 20
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                itemHD.NGAYGIAITRACH,
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
                                To = itemtableND.TT_To.TenTo,
                                HanhThu = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemHD in _db.HOADONs
                                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && itemHD.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && itemHD.GB > 20
                                orderby itemHD.MALOTRINH ascending
                                select new
                                {
                                    itemHD.NGAYGIAITRACH,
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
                                    To = itemtableND.TT_To.TenTo,
                                    HanhThu = itemtableND.HoTen,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSDangNganHanhThu_To_CoThuHo(string Loai, int MaTo, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                string sql = "select NGAYGIAITRACH,hd.SOHOADON,Ky=convert(varchar(2),hd.KY)+'/'+convert(varchar(4),hd.NAM),"
                        + " MLT=MALOTRINH,DanhBo=DANHBA,HoTen=TENKH,TIEUTHU,GIABAN,ThueGTGT=THUE,PhiBVMT=hd.PHI,TONGCONG,"
                        + " 'To'=(select TenTo from TT_To where MaTo=nd.MaTo),HanhThu=nd.HoTen"
                        + " from HOADON hd join TT_DichVuThu dvt on dvt.SoHoaDon=hd.SOHOADON"
                        + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                        + " where MAY>=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ") and MAY<=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ") and"
                        + " CAST(NGAYGIAITRACH as date)='" + NgayGiaiTrach.ToString("yyyyMMdd") + "' and hd.DangNgan_HanhThu=1 and GB>=10 and GB<=20";

                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "select NGAYGIAITRACH,hd.SOHOADON,Ky=convert(varchar(2),hd.KY)+'/'+convert(varchar(4),hd.NAM),"
                         + " MLT=MALOTRINH,DanhBo=DANHBA,HoTen=TENKH,TIEUTHU,GIABAN,ThueGTGT=THUE,PhiBVMT=hd.PHI,TONGCONG,"
                         + " 'To'=(select TenTo from TT_To where MaTo=nd.MaTo),HanhThu=nd.HoTen"
                         + " from HOADON hd join TT_DichVuThu dvt on dvt.SoHoaDon=hd.SOHOADON"
                         + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                         + " where MAY>=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ") and MAY<=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ") and"
                         + " CAST(NGAYGIAITRACH as date)='" + NgayGiaiTrach.ToString("yyyyMMdd") + "' and hd.DangNgan_HanhThu=1 and GB>20";

                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetDSDangNganQuay(string Loai, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemHD in _db.HOADONs
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemHD.DangNgan_Quay == true && itemHD.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && itemHD.GB >= 11 && itemHD.GB <= 20
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
            else
                if (Loai == "CQ")
                {
                    var query = from itemHD in _db.HOADONs
                                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemHD.DangNgan_Quay == true && itemHD.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && itemHD.GB > 20
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

        public DataTable GetDSDangNganQuay(string Loai, DateTime TuNgayGiaiTrach, DateTime DenNgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemHD in _db.HOADONs
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemHD.DangNgan_Quay == true && itemHD.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && itemHD.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && itemHD.GB >= 11 && itemHD.GB <= 20
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
                                where itemHD.DangNgan_Quay == true && itemHD.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && itemHD.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && itemHD.GB > 20
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
                    if (Loai == "")
                    {
                        var query = from itemHD in _db.HOADONs
                                    join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                    from itemtableND in tableND.DefaultIfEmpty()
                                    where itemHD.DangNgan_Quay == true && itemHD.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && itemHD.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date
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

        //public DataTable GetDSDangNganChuyenKhoan(string Loai, DateTime NgayGiaiTrach)
        //{
        //    if (Loai == "TG")
        //    {
        //        var query = from itemHD in _db.HOADONs
        //                    join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
        //                    from itemtableND in tableND.DefaultIfEmpty()
        //                    where itemHD.DangNgan_ChuyenKhoan == true && itemHD.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && itemHD.GB >= 11 && itemHD.GB <= 20
        //                    select new
        //                    {
        //                        itemHD.NGAYGIAITRACH,
        //                        itemHD.SOHOADON,
        //                        Ky = itemHD.KY + "/" + itemHD.NAM,
        //                        MLT = itemHD.MALOTRINH,
        //                        DanhBo = itemHD.DANHBA,
        //                        HoTen = itemHD.TENKH,
        //                        itemHD.TIEUTHU,
        //                        itemHD.GIABAN,
        //                        ThueGTGT = itemHD.THUE,
        //                        PhiBVMT = itemHD.PHI,
        //                        itemHD.TONGCONG,
        //                        HanhThu = itemtableND.HoTen,
        //                        To = itemtableND.TT_To.TenTo,
        //                    };
        //        return LINQToDataTable(query);
        //    }
        //    else
        //        if (Loai == "CQ")
        //        {
        //            var query = from itemHD in _db.HOADONs
        //                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
        //                        from itemtableND in tableND.DefaultIfEmpty()
        //                        where itemHD.DangNgan_ChuyenKhoan == true && itemHD.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date && itemHD.GB > 20
        //                        select new
        //                        {
        //                            itemHD.NGAYGIAITRACH,
        //                            itemHD.SOHOADON,
        //                            Ky = itemHD.KY + "/" + itemHD.NAM,
        //                            MLT = itemHD.MALOTRINH,
        //                            DanhBo = itemHD.DANHBA,
        //                            HoTen = itemHD.TENKH,
        //                            itemHD.TIEUTHU,
        //                            itemHD.GIABAN,
        //                            ThueGTGT = itemHD.THUE,
        //                            PhiBVMT = itemHD.PHI,
        //                            itemHD.TONGCONG,
        //                            HanhThu = itemtableND.HoTen,
        //                            To = itemtableND.TT_To.TenTo,
        //                        };
        //            return LINQToDataTable(query);
        //        }
        //    return null;
        //}

        public DataTable GetDSDangNganChuyenKhoan(string Loai, DateTime TuNgayGiaiTrach, DateTime DenNgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemHD in _db.HOADONs
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemHD.DangNgan_ChuyenKhoan == true && itemHD.TienMat == null && itemHD.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && itemHD.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && itemHD.GB >= 11 && itemHD.GB <= 20
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
            else
                if (Loai == "CQ")
                {
                    var query = from itemHD in _db.HOADONs
                                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemHD.DangNgan_ChuyenKhoan == true && itemHD.TienMat == null && itemHD.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && itemHD.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && itemHD.GB > 20
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
                else
                    if (Loai == "")
                    {
                        var query = from itemHD in _db.HOADONs
                                    join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                    from itemtableND in tableND.DefaultIfEmpty()
                                    where itemHD.DangNgan_ChuyenKhoan == true && itemHD.TienMat == null && itemHD.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && itemHD.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date
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

        public DataTable GetDSDangNganChuyenKhoan(DateTime NgayGiaiTrach)
        {
            var query = from itemHD in _db.HOADONs
                        //join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        //from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.DangNgan_ChuyenKhoan == true && itemHD.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                        orderby itemHD.ID_HOADON ascending
                        select new
                        {
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            itemHD.KY,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            TongCong = itemHD.TONGCONG,
                            GiaBieu = itemHD.GB,
                            itemHD.TienMat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDangNganChuyenKhoan(int MaTo, int Nam, int Ky)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                         && itemHD.DangNgan_ChuyenKhoan == true && itemHD.NAM == Nam && itemHD.KY == Ky
                        orderby itemHD.ID_HOADON ascending
                        select new
                        {
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDangNganTienMatChuyenKhoan(string Loai, DateTime TuNgayGiaiTrach, DateTime DenNgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemHD in _db.HOADONs
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemHD.DangNgan_ChuyenKhoan == true && itemHD.TienMat != null && itemHD.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && itemHD.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && itemHD.GB >= 11 && itemHD.GB <= 20
                            select new
                            {
                                itemHD.NGAYGIAITRACH,
                                itemHD.SOHOADON,
                                itemHD.SOPHATHANH,
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
                                itemHD.TienDu,
                                itemHD.TienMat,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemHD in _db.HOADONs
                                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemHD.DangNgan_ChuyenKhoan == true && itemHD.TienMat != null && itemHD.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && itemHD.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date && itemHD.GB > 20
                                select new
                                {
                                    itemHD.NGAYGIAITRACH,
                                    itemHD.SOHOADON,
                                    itemHD.SOPHATHANH,
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
                                    itemHD.TienDu,
                                    itemHD.TienMat,
                                };
                    return LINQToDataTable(query);
                }
                else
                    if (Loai == "")
                    {
                        var query = from itemHD in _db.HOADONs
                                    join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                    from itemtableND in tableND.DefaultIfEmpty()
                                    where itemHD.DangNgan_ChuyenKhoan == true && itemHD.TienMat != null && itemHD.NGAYGIAITRACH.Value.Date >= TuNgayGiaiTrach.Date && itemHD.NGAYGIAITRACH.Value.Date <= DenNgayGiaiTrach.Date
                                    select new
                                    {
                                        itemHD.NGAYGIAITRACH,
                                        itemHD.SOHOADON,
                                        itemHD.SOPHATHANH,
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
                                        itemHD.TienDu,
                                        itemHD.TienMat,
                                    };
                        return LINQToDataTable(query);
                    }
            return null;
        }

        public DataTable GetDSTon_NV(int MaNV_HanhThu, int SoKy)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,GiaBieu=GB"
                        + " from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTon_NV(int MaNV_HanhThu, int Nam, int SoKy)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " declare @Nam int;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " set @Nam=" + Nam + ";"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,GiaBieu=GB"
                        + " from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and (KhoaTienDu=1 or NGAYGIAITRACH is null) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTon_NV(int MaNV_HanhThu, int Nam, int Ky, int SoKy)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,GiaBieu=GB"
                        + " from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and KY=@Ky and (KhoaTienDu=1 or NGAYGIAITRACH is null) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and KY=@Ky and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTon_NV(int MaNV_HanhThu, int Nam, int Ky, int Dot, int SoKy)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @Dot int;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @Dot=" + Dot + ";"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,GiaBieu=GB"
                        + " from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and KY=@Ky and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and KY=@Ky and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTon_NV(int MaNV_HanhThu, int Nam, int Ky, int FromDot, int ToDot, int SoKy)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,GiaBieu=GB"
                        + " from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTon_NV(int MaNV_HanhThu, DateTime NgayGiaiTrach, int SoKy)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " declare @NgayGiaiTrach date;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,GiaBieu=GB"
                        + " from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTonDenKy_NV(int MaNV_HanhThu, int Nam, int Ky, int SoKy)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,GiaBieu=GB,MaNV=@MaNV_HanhThu,HanhThu=(select HoTen from TT_NguoiDung where MaND=@MaNV_HanhThu)"
                        + " from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTonDenKy_NV(int MaNV_HanhThu, int Nam, int Ky, int Dot, int SoKy)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @Dot int;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @Dot=" + Dot + ";"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,GiaBieu=GB,"
                        + " MaNV=@MaNV_HanhThu,HanhThu=(select HoTen from TT_NguoiDung where MaND=@MaNV_HanhThu)"
                        + " from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTonDenKy_NV(int MaNV_HanhThu, int Nam, int Ky, int FromDot, int ToDot, int SoKy)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,GiaBieu=GB,"
                        + " MaNV=@MaNV_HanhThu,HanhThu=(select HoTen from TT_NguoiDung where MaND=@MaNV_HanhThu)"
                        + " from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTonDenKyDenNgay_NV(int MaNV_HanhThu, int Nam, int Ky, DateTime NgayGiaiTrach, int SoKy)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @NgayGiaiTrach date;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,GiaBieu=GB"
                        + " from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTonDenKyDenNgay_NV(int MaNV_HanhThu, int Nam, int Ky, int Dot, DateTime NgayGiaiTrach, int SoKy)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @Dot int;"
                        + " declare @NgayGiaiTrach date;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @Dot=" + Dot + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,GiaBieu=GB"
                        + " from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTonDenKyDenNgay_NV(int MaNV_HanhThu, int Nam, int Ky, int FromDot, int ToDot, DateTime NgayGiaiTrach, int SoKy)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " declare @NgayGiaiTrach date;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,GiaBieu=GB"
                        + " from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTonTrongKyDenNgay_NV(int MaNV_HanhThu, int Nam, int Ky, DateTime NgayGiaiTrach, int SoKy)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @NgayGiaiTrach date;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,GiaBieu=GB"
                        + " from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and KY=@Ky and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and KY=@Ky and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTonTrongKyDenNgay_NV(int MaNV_HanhThu, int Nam, int Ky, int Dot, DateTime NgayGiaiTrach, int SoKy)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " declare @NgayGiaiTrach date;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @Dot=" + Dot + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,GiaBieu=GB"
                        + " from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and KY=@Ky and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and KY=@Ky and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTonTrongKyDenNgay_NV(int MaNV_HanhThu, int Nam, int Ky, int FromDot, int ToDot, DateTime NgayGiaiTrach, int SoKy)
        {
            string sql = "declare @MaNV_HanhThu int;"
                        + " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " declare @NgayGiaiTrach date;"
                        + " set @MaNV_HanhThu=" + MaNV_HanhThu + ";"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,GiaBieu=GB"
                        + " from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MaNV_HanhThu=@MaNV_HanhThu"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTon_To(int MaTo, int SoKy)
        {
            string sql = "declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To',GiaBieu=GB,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                        + " left join TT_To tto on tto.MaTo=nd.MaTo"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTon_To(int MaTo, int Nam, int SoKy)
        {
            string sql = "declare @Nam int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To',GiaBieu=GB,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                        + " left join TT_To tto on tto.MaTo=nd.MaTo"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and (KhoaTienDu=1 or NGAYGIAITRACH is null) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTon_To(int MaTo, int Nam, int Ky, int SoKy)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To',GiaBieu=GB,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                        + " left join TT_To tto on tto.MaTo=nd.MaTo"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and (KhoaTienDu=1 or NGAYGIAITRACH is null) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTon_To(int MaTo, int Nam, int Ky, int Dot, int SoKy)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @Dot int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @Dot=" + Dot + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To',GiaBieu=GB,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                        + " left join TT_To tto on tto.MaTo=nd.MaTo"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTon_To(int MaTo, int Nam, int Ky, int FromDot, int ToDot, int SoKy)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To',GiaBieu=GB,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                        + " left join TT_To tto on tto.MaTo=nd.MaTo"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTon_To(int MaTo, DateTime NgayGiaiTrach, int SoKy)
        {
            string sql = "declare @NgayGiaiTrach date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To',GiaBieu=GB,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                        + " left join TT_To tto on tto.MaTo=nd.MaTo"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTonDenKy_To(int MaTo, int Nam, int Ky, int SoKy)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To',GiaBieu=GB,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                        + " left join TT_To tto on tto.MaTo=nd.MaTo"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTonDenKy_To(int MaTo, int Nam, int Ky, int FromDot, int ToDot, int SoKy)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To',GiaBieu=GB,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                        + " left join TT_To tto on tto.MaTo=nd.MaTo"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTonDenKyDenNgay_To(int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach, int SoKy)
        {
            string sql = " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @NgayGiaiTrach date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To',GiaBieu=GB,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                        + " left join TT_To tto on tto.MaTo=nd.MaTo"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTonDenKyDenNgay_To(int MaTo, int Nam, int Ky, int Dot, DateTime NgayGiaiTrach, int SoKy)
        {
            string sql = " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @Dot int;"
                        + " declare @NgayGiaiTrach date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @Dot=" + Dot + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To',GiaBieu=GB,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                        + " left join TT_To tto on tto.MaTo=nd.MaTo"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT=@Dot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTonDenKyDenNgay_To(int MaTo, int Nam, int Ky, int FromDot, int ToDot, DateTime NgayGiaiTrach, int SoKy)
        {
            string sql = " declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " declare @NgayGiaiTrach date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To',GiaBieu=GB,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                        + " left join TT_To tto on tto.MaTo=nd.MaTo"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and (NAM<@Nam or (NAM=@Nam and KY<=@Ky)) and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTonTrongKyDenNgay_To(int MaTo, int Nam, int Ky, DateTime NgayGiaiTrach, int SoKy)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @NgayGiaiTrach date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To',GiaBieu=GB,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                        + " left join TT_To tto on tto.MaTo=nd.MaTo"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTonTrongKyDenNgay_To(int MaTo, int Nam, int Ky, int FromDot, int ToDot, DateTime NgayGiaiTrach, int SoKy)
        {
            string sql = "declare @Nam int;"
                        + " declare @Ky int;"
                        + " declare @FromDot int;"
                        + " declare @ToDot int;"
                        + " declare @NgayGiaiTrach date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @Nam=" + Nam + ";"
                        + " set @Ky=" + Ky + ";"
                        + " set @FromDot=" + FromDot + ";"
                        + " set @ToDot=" + ToDot + ";"
                        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To',GiaBieu=GB,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                        + " left join TT_To tto on tto.MaTo=nd.MaTo"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach) and DANHBA in"
                        + " (select DANHBA from HOADON"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and NAM=@Nam and KY=@Ky and DOT>=@FromDot and DOT<=@ToDot and (KhoaTienDu=1 or NGAYGIAITRACH is null or CAST(NgayGiaiTrach as date)>@NgayGiaiTrach)"
                        + " group by DANHBA"
                        + " having COUNT(*)>=" + SoKy + ")"
                        + " order by MLT,Ky asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTon_Doi_GiaoTon(string Loai, int Nam)
        {
            if (Loai == "TG")
            {
                string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                            + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                            + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To'"
                            + " from HOADON hd"
                            + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                            + " left join TT_To tto on tto.MaTo=nd.MaTo"
                            + " where"
                            + " NAM=" + Nam + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>=10 and GB<=20"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " order by MLT,Ky asc";

                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                            + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                            + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To'"
                            + " from HOADON hd"
                            + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                            + " left join TT_To tto on tto.MaTo=nd.MaTo"
                            + " where"
                            + " NAM=" + Nam + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>20"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " order by MLT,Ky asc";

                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetDSTon_Doi_GiaoTon(string Loai, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                            + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                            + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To'"
                            + " from HOADON hd"
                            + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                            + " left join TT_To tto on tto.MaTo=nd.MaTo"
                            + " where"
                            + " NAM=" + Nam + " and KY=" + Ky + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>=10 and GB<=20"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " order by MLT,Ky asc";

                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                            + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                            + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To'"
                            + " from HOADON hd"
                            + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                            + " left join TT_To tto on tto.MaTo=nd.MaTo"
                            + " where"
                            + " NAM=" + Nam + " and KY=" + Ky + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>20"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " order by MLT,Ky asc";

                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetDSTon_Doi_GiaoTon(string Loai, int Nam, int Ky, int FromDot, int ToDot)
        {
            if (Loai == "TG")
            {
                string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                            + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                            + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To'"
                            + " from HOADON hd"
                            + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                            + " left join TT_To tto on tto.MaTo=nd.MaTo"
                            + " where"
                            + " NAM=" + Nam + " and KY=" + Ky + " and DOT>=" + FromDot + " and DOT<=" + ToDot + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>=10 and GB<=20"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " order by MLT,Ky asc";

                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                            + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                            + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To'"
                            + " from HOADON hd"
                            + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                            + " left join TT_To tto on tto.MaTo=nd.MaTo"
                            + " where"
                            + " NAM=" + Nam + " and KY=" + Ky + " and DOT>=" + FromDot + " and DOT<=" + ToDot + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>20"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " order by MLT,Ky asc";

                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetDSTon_To_GiaoTon(string Loai, int MaTo, int Nam)
        {
            if (Loai == "TG")
            {
                string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                            + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                            + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To'"
                            + " from HOADON hd"
                            + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                            + " left join TT_To tto on tto.MaTo=nd.MaTo"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=" + Nam + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>=10 and GB<=20"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " order by MLT,Ky asc";

                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                            + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                            + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To'"
                            + " from HOADON hd"
                            + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                            + " left join TT_To tto on tto.MaTo=nd.MaTo"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=" + Nam + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>20"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " order by MLT,Ky asc";

                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetDSTon_To_GiaoTon(string Loai, int MaTo, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                            + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                            + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To'"
                            + " from HOADON hd"
                            + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                            + " left join TT_To tto on tto.MaTo=nd.MaTo"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=" + Nam + " and KY=" + Ky + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>=10 and GB<=20"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " order by MLT,Ky asc";

                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                            + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                            + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To'"
                            + " from HOADON hd"
                            + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                            + " left join TT_To tto on tto.MaTo=nd.MaTo"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=" + Nam + " and KY=" + Ky + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>20"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " order by MLT,Ky asc";

                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetDSTon_To_GiaoTon(string Loai, int MaTo, int Nam, int Ky, int FromDot, int ToDot)
        {
            if (Loai == "TG")
            {
                string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                            + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                            + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To'"
                            + " from HOADON hd"
                            + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                            + " left join TT_To tto on tto.MaTo=nd.MaTo"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=" + Nam + " and KY=" + Ky + " and DOT>=" + FromDot + " and DOT<=" + ToDot + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>=10 and GB<=20"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " order by MLT,Ky asc";

                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                            + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                            + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To'"
                            + " from HOADON hd"
                            + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                            + " left join TT_To tto on tto.MaTo=nd.MaTo"
                            + " where MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                            + " and NAM=" + Nam + " and KY=" + Ky + " and DOT>=" + FromDot + " and DOT<=" + ToDot + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>20"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " order by MLT,Ky asc";

                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetDSTon_NV_GiaoTon(string Loai, int MaNV_HanhThu, int Nam)
        {
            if (Loai == "TG")
            {
                string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                            + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                            + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG"
                            + " from HOADON"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NAM=" + Nam + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>=10 and GB<=20"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " order by MLT,Ky asc";

                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                            + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                            + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG"
                            + " from HOADON"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NAM=" + Nam + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>20"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " order by MLT,Ky asc";

                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetDSTon_NV_GiaoTon(string Loai, int MaNV_HanhThu, int Nam, int Ky)
        {
            if (Loai == "TG")
            {
                string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                            + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                            + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG"
                            + " from HOADON"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NAM=" + Nam + " and KY=" + Ky + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>=10 and GB<=20"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " order by MLT,Ky asc";

                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                            + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                            + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG"
                            + " from HOADON"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NAM=" + Nam + " and KY=" + Ky + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>20"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " order by MLT,Ky asc";

                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        public DataTable GetDSTon_NV_GiaoTon(string Loai, int MaNV_HanhThu, int Nam, int Ky, int FromDot, int ToDot)
        {
            if (Loai == "TG")
            {
                string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                            + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                            + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG"
                            + " from HOADON"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NAM=" + Nam + " and KY=" + Ky + " and DOT>=" + FromDot + " and DOT<=" + ToDot + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>=10 and GB<=20"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " order by MLT,Ky asc";

                return ExecuteQuery_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                            + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,TIEUTHU,GIABAN,"
                            + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG"
                            + " from HOADON"
                            + " where MaNV_HanhThu=" + MaNV_HanhThu
                            + " and NAM=" + Nam + " and KY=" + Ky + " and DOT>=" + FromDot + " and DOT<=" + ToDot + " and (KhoaTienDu=1 or NGAYGIAITRACH is null) and GB>20"
                            + " and ID_HOADON not in (select MaHD from TT_LenhHuy)"
                            + " order by MLT,Ky asc";

                    return ExecuteQuery_DataTable(sql);
                }
            return null;
        }

        /// <summary>
        /// Lấy danh sách tất cả hóa đơn tồn
        /// </summary>
        /// <returns></returns>
        public DataTable GetDSTon_DieuChinhMLT(string DanhBo, string MLT_Moi)
        {
            var query = from item in _db.HOADONs
                        where item.DANHBA == DanhBo && item.MALOTRINH != MLT_Moi && item.NGAYGIAITRACH == null
                        select new
                        {
                            MaHD = item.ID_HOADON,
                            DanhBo = item.DANHBA,
                            MLT = item.MALOTRINH,
                            item.SOHOADON,
                            Ky = item.KY + "/" + item.NAM,
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
                        where itemHD.DANHBA == DanhBo && itemHD.NGAYGIAITRACH == null && ((itemHD.GB != 10 && itemHD.DinhMucHN == null) || ((itemHD.GB == 10 || (itemHD.GB != 10 && itemHD.DinhMucHN != null)) && ((itemHD.KY != 4 && itemHD.KY != 5 && itemHD.KY != 6 && itemHD.NAM == 2020) || itemHD.NAM > 2020)))
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            GiaBieu = itemHD.GB,
                            TyLeSH = itemHD.TILESH,
                            TyLeHCSN = itemHD.TILEHCSN,
                            TyLeSX = itemHD.TILESX,
                            TyLeDV = itemHD.TILEDV,
                            itemHD.DinhMucHN,
                            DinhMuc = itemHD.DM,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                            itemHD.TUNGAY,
                            itemHD.DENNGAY,
                            Ky2 = itemHD.KY,
                            itemHD.NAM,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSTonByDanhBo_TruHoNgheo(string DanhBo)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.DANHBA == DanhBo && itemHD.NGAYGIAITRACH == null && (itemHD.GB != 10 && itemHD.DinhMucHN == null)
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            GiaBieu = itemHD.GB,
                            TyLeSH = itemHD.TILESH,
                            TyLeHCSN = itemHD.TILEHCSN,
                            TyLeSX = itemHD.TILESX,
                            TyLeDV = itemHD.TILEDV,
                            itemHD.DinhMucHN,
                            DinhMuc = itemHD.DM,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                            itemHD.TUNGAY,
                            itemHD.DENNGAY,
                        };
            return LINQToDataTable(query);
        }

        public List<HOADON> GetListDSTonByDanhBo(string DanhBo)
        {
            return _db.HOADONs.Where(item => item.NGAYGIAITRACH == null && item.DANHBA == DanhBo).ToList();
        }

        public DataTable GetDSTon_CoTieuThu(int MaTo, int Nam, int Ky, int Dot)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                            && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                         && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot && itemHD.TIEUTHU > 0 && itemHD.NGAYGIAITRACH == null
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSTon_CoTieuThu(int MaTo, int Nam, int Ky)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                            && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                         && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.TIEUTHU > 0 && itemHD.NGAYGIAITRACH == null
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSTonByDanhBo_ExceptHD0(string DanhBo)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.DANHBA == DanhBo && itemHD.NGAYGIAITRACH == null && itemHD.TONGCONG != 0
                        orderby itemHD.ID_HOADON ascending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
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

        public DataTable GetDSTonByDanhBo_CodeF(string DanhBo)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.DANHBA == DanhBo && itemHD.NGAYGIAITRACH == null && itemHD.CODE == "F"
                        orderby itemHD.ID_HOADON ascending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
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

        public DataTable getDSTon_ThoatNgheo()
        {
            string sql = "select ID_HOADON as MaHD,SOHOADON,CONVERT(varchar(2),KY)+'/'+CONVERT(varchar(4),NAM)as Ky,"
                        + " MALOTRINH as MLT,SOPHATHANH,DANHBA as DanhBo,TENKH as HoTen,SO+' '+DUONG as DiaChi,TIEUTHU,GIABAN,"
                        + " THUE as ThueGTGT,PHI as PhiBVMT,TONGCONG,CODE,nd.HoTen as HanhThu,tto.TenTo as 'To',GiaBieu=GB,DinhMuc=DM,DinhMucHN"
                        + " from HOADON hd"
                        + " left join TT_NguoiDung nd on nd.MaND=hd.MaNV_HanhThu"
                        + " left join TT_To tto on tto.MaTo=nd.MaTo"
                        + " where (KhoaTienDu=1 or NGAYGIAITRACH is null) and NAM=2020 and (KY=4 or KY=5 or KY=6) and DANHBA in"
                        + " (select DanhBo from TT_ThoatNgheo)"
                        + " order by MLT,Ky asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSGiaoTonByToDates(int MaTo, DateTime TuNgay, DateTime DenNgay)
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

        public DataTable GetDSGiaoTonByNVDates(int MaNV, DateTime TuNgay, DateTime DenNgay)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        join itemNDTruoc in _db.TT_NguoiDungs on itemHD.MaNV_HanhThuTruoc equals itemNDTruoc.MaND into tableNDTruoc
                        from itemtableND in tableND.DefaultIfEmpty()
                        from itemtableNDTruoc in tableNDTruoc.DefaultIfEmpty()
                        where itemHD.MaNV_HanhThu == MaNV
                                && itemHD.NGAYGIAOTON.Value.Date >= TuNgay.Date && itemHD.NGAYGIAOTON.Value.Date <= DenNgay.Date
                        //orderby itemHD.MaNV_GiaoTon ascending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            NgayGiaiTrach = itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
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

        /// <summary>
        /// Lấy danh sách hóa đơn giao tồn đã đăng ngân bởi người được giao tồn
        /// </summary>
        /// <param name="MaNV_DangNgan"></param>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable GetDSDangNganTonByMaNVDate(string Loai, int MaNV_DangNgan, DateTime NgayGiaiTrach)
        {
            if (Loai == "TG")
            {
                var query = from itemHD in _db.HOADONs
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemHD.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                            && itemHD.DangNgan_Ton == true && itemHD.MaNV_DangNgan == MaNV_DangNgan && itemHD.GB >= 11 && itemHD.GB <= 20
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                MaHD = itemHD.ID_HOADON,
                                NgayGiaiTrach = itemHD.NGAYGIAITRACH,
                                itemHD.SOHOADON,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                MLT = itemHD.MALOTRINH,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                DiaChi = itemHD.SO + " " + itemHD.DUONG,
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
                                    DanhBo = itemHD.DANHBA,
                                    HoTen = itemHD.TENKH,
                                    DiaChi = itemHD.SO + " " + itemHD.DUONG,
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
                    if (Loai == "")
                    {
                        var query = from itemHD in _db.HOADONs
                                    join itemND in _db.TT_NguoiDungs on itemHD.MaNV_GiaoTon equals itemND.MaND into tableND
                                    from itemtableND in tableND.DefaultIfEmpty()
                                    where itemHD.NGAYGIAITRACH.Value.Date == NgayGiaiTrach.Date
                                    && itemHD.DangNgan_Ton == true && itemHD.MaNV_DangNgan == MaNV_DangNgan
                                    orderby itemHD.MALOTRINH ascending
                                    select new
                                    {
                                        MaHD = itemHD.ID_HOADON,
                                        NgayGiaiTrach = itemHD.NGAYGIAITRACH,
                                        itemHD.SOHOADON,
                                        Ky = itemHD.KY + "/" + itemHD.NAM,
                                        MLT = itemHD.MALOTRINH,
                                        DanhBo = itemHD.DANHBA,
                                        HoTen = itemHD.TENKH,
                                        DiaChi = itemHD.SO + " " + itemHD.DUONG,
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
                            To = itemtableND.TT_To.TenTo,
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

        public DataTable GetDSChuyenKhoan(int Nam)
        {
            string sql = "declare @Nam int;"
                        + " set @Nam=" + Nam + ";"
                        + " select *,TENPHUONG,TENQUAN from"
                        + " (select tt.* from"
                        + " (select t.DANHBA as DanhBo,t1.DangNgan_ChuyenKhoan as Ky1,t2.DangNgan_ChuyenKhoan as Ky2,t3.DangNgan_ChuyenKhoan as Ky3,t4.DangNgan_ChuyenKhoan as Ky4,t5.DangNgan_ChuyenKhoan as Ky5,t6.DangNgan_ChuyenKhoan as Ky6,"
                        + " t7.DangNgan_ChuyenKhoan as Ky7,t8.DangNgan_ChuyenKhoan as Ky8,t9.DangNgan_ChuyenKhoan as Ky9,t10.DangNgan_ChuyenKhoan as Ky10,t11.DangNgan_ChuyenKhoan as Ky11,t12.DangNgan_ChuyenKhoan as Ky12,"
                        + " row_number() over (partition by t.DanhBa order by t.DanhBa) as RowNumber,Quan,Phuong from"
                        + " (select DANHBA,Quan,Phuong from HOADON where NAM=@Nam and DangNgan_ChuyenKhoan=1) t"
                        + " left join"
                        + " (select DANHBA,DangNgan_ChuyenKhoan from HOADON where NAM=@Nam and DangNgan_ChuyenKhoan=1 and KY=1) t1 on t.DANHBA=t1.DANHBA"
                        + " left join"
                        + " (select DANHBA,DangNgan_ChuyenKhoan from HOADON where NAM=@Nam and DangNgan_ChuyenKhoan=1 and KY=2) t2 on t.DANHBA=t2.DANHBA"
                        + " left join"
                        + " (select DANHBA,DangNgan_ChuyenKhoan from HOADON where NAM=@Nam and DangNgan_ChuyenKhoan=1 and KY=3) t3 on t.DANHBA=t3.DANHBA"
                        + " left join"
                        + " (select DANHBA,DangNgan_ChuyenKhoan from HOADON where NAM=@Nam and DangNgan_ChuyenKhoan=1 and KY=4) t4 on t.DANHBA=t4.DANHBA"
                        + " left join"
                        + " (select DANHBA,DangNgan_ChuyenKhoan from HOADON where NAM=@Nam and DangNgan_ChuyenKhoan=1 and KY=5) t5 on t.DANHBA=t5.DANHBA"
                        + " left join"
                        + " (select DANHBA,DangNgan_ChuyenKhoan from HOADON where NAM=@Nam and DangNgan_ChuyenKhoan=1 and KY=6) t6 on t.DANHBA=t6.DANHBA"
                        + " left join"
                        + " (select DANHBA,DangNgan_ChuyenKhoan from HOADON where NAM=@Nam and DangNgan_ChuyenKhoan=1 and KY=7) t7 on t.DANHBA=t7.DANHBA"
                        + " left join"
                        + " (select DANHBA,DangNgan_ChuyenKhoan from HOADON where NAM=@Nam and DangNgan_ChuyenKhoan=1 and KY=8) t8 on t.DANHBA=t8.DANHBA"
                        + " left join"
                        + " (select DANHBA,DangNgan_ChuyenKhoan from HOADON where NAM=@Nam and DangNgan_ChuyenKhoan=1 and KY=9) t9 on t.DANHBA=t9.DANHBA"
                        + " left join"
                        + " (select DANHBA,DangNgan_ChuyenKhoan from HOADON where NAM=@Nam and DangNgan_ChuyenKhoan=1 and KY=10) t10 on t.DANHBA=t10.DANHBA"
                        + " left join"
                        + " (select DANHBA,DangNgan_ChuyenKhoan from HOADON where NAM=@Nam and DangNgan_ChuyenKhoan=1 and KY=11) t11 on t.DANHBA=t11.DANHBA"
                        + " left join"
                        + " (select DANHBA,DangNgan_ChuyenKhoan from HOADON where NAM=@Nam and DangNgan_ChuyenKhoan=1 and KY=12) t12 on t.DANHBA=t12.DANHBA) tt"
                        + " where RowNumber=1) ttt"
                        + " left join SERVER8.CAPNUOCTANHOA.dbo.PHUONG phuong on ttt.Phuong=phuong.MAPHUONG and ttt.Quan=phuong.MAQUAN"
                        + " left join SERVER8.CAPNUOCTANHOA.dbo.QUAN quan on ttt.Quan=quan.MAQUAN";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSByTienLon_To(string Loai, int MaNV, int Nam, int SoTien)
        {
            if (Loai == "TG")
            {
                var query = from itemHD in _db.HOADONs
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemHD.NAM == Nam && itemHD.MaNV_HanhThu == MaNV && itemHD.TONGCONG >= SoTien && itemHD.GB >= 11 && itemHD.GB <= 20
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                itemHD.NGAYGIAITRACH,
                                itemHD.SOHOADON,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                MLT = itemHD.MALOTRINH,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                itemHD.TIEUTHU,
                                //itemHD.GIABAN,
                                //ThueGTGT = itemHD.THUE,
                                //PhiBVMT = itemHD.PHI,
                                itemHD.TONGCONG,
                                HanhThu = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemHD in _db.HOADONs
                                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemHD.NAM == Nam && itemHD.MaNV_HanhThu == MaNV && itemHD.TONGCONG >= SoTien && itemHD.GB > 20
                                orderby itemHD.MALOTRINH ascending
                                select new
                                {
                                    itemHD.NGAYGIAITRACH,
                                    itemHD.SOHOADON,
                                    Ky = itemHD.KY + "/" + itemHD.NAM,
                                    MLT = itemHD.MALOTRINH,
                                    DanhBo = itemHD.DANHBA,
                                    HoTen = itemHD.TENKH,
                                    DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                    itemHD.TIEUTHU,
                                    //itemHD.GIABAN,
                                    //ThueGTGT = itemHD.THUE,
                                    //PhiBVMT = itemHD.PHI,
                                    itemHD.TONGCONG,
                                    HanhThu = itemtableND.HoTen,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSByTienLon_To(string Loai, int MaNV, int Nam, int Ky, int SoTien)
        {
            if (Loai == "TG")
            {
                var query = from itemHD in _db.HOADONs
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.MaNV_HanhThu == MaNV && itemHD.TONGCONG >= SoTien && itemHD.GB >= 11 && itemHD.GB <= 20
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                itemHD.NGAYGIAITRACH,
                                itemHD.SOHOADON,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                MLT = itemHD.MALOTRINH,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                itemHD.TIEUTHU,
                                //itemHD.GIABAN,
                                //ThueGTGT = itemHD.THUE,
                                //PhiBVMT = itemHD.PHI,
                                itemHD.TONGCONG,
                                HanhThu = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemHD in _db.HOADONs
                                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.MaNV_HanhThu == MaNV && itemHD.TONGCONG >= SoTien && itemHD.GB > 20
                                orderby itemHD.MALOTRINH ascending
                                select new
                                {
                                    itemHD.NGAYGIAITRACH,
                                    itemHD.SOHOADON,
                                    Ky = itemHD.KY + "/" + itemHD.NAM,
                                    MLT = itemHD.MALOTRINH,
                                    DanhBo = itemHD.DANHBA,
                                    HoTen = itemHD.TENKH,
                                    DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                    itemHD.TIEUTHU,
                                    //itemHD.GIABAN,
                                    //ThueGTGT = itemHD.THUE,
                                    //PhiBVMT = itemHD.PHI,
                                    itemHD.TONGCONG,
                                    HanhThu = itemtableND.HoTen,
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
                var query = from itemHD in _db.HOADONs
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot && itemHD.MaNV_HanhThu == MaNV && itemHD.TONGCONG >= SoTien && itemHD.GB >= 11 && itemHD.GB <= 20
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                itemHD.NGAYGIAITRACH,
                                itemHD.SOHOADON,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                MLT = itemHD.MALOTRINH,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                itemHD.TIEUTHU,
                                //itemHD.GIABAN,
                                //ThueGTGT = itemHD.THUE,
                                //PhiBVMT = itemHD.PHI,
                                itemHD.TONGCONG,
                                HanhThu = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemHD in _db.HOADONs
                                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot && itemHD.MaNV_HanhThu == MaNV && itemHD.TONGCONG >= SoTien && itemHD.GB > 20
                                orderby itemHD.MALOTRINH ascending
                                select new
                                {
                                    itemHD.NGAYGIAITRACH,
                                    itemHD.SOHOADON,
                                    Ky = itemHD.KY + "/" + itemHD.NAM,
                                    MLT = itemHD.MALOTRINH,
                                    DanhBo = itemHD.DANHBA,
                                    HoTen = itemHD.TENKH,
                                    DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                    itemHD.TIEUTHU,
                                    //itemHD.GIABAN,
                                    //ThueGTGT = itemHD.THUE,
                                    //PhiBVMT = itemHD.PHI,
                                    itemHD.TONGCONG,
                                    HanhThu = itemtableND.HoTen,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSByTienLon_Doi(string Loai, int MaTo, int SoTien)
        {
            if (Loai == "TG")
            {
                var query = from item in _db.HOADONs
                            join itemND in _db.TT_NguoiDungs on item.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.NGAYGIAITRACH == null && item.TONGCONG >= SoTien && item.GB >= 11 && item.GB <= 20
                            select new
                            {
                                item.NGAYGIAITRACH,
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                DanhBo = item.DANHBA,
                                HoTen = item.TENKH,
                                DiaChi = item.SO + " " + item.DUONG,
                                MLT = item.MALOTRINH,
                                item.TIEUTHU,
                                //item.GIABAN,
                                //ThueGTGT = item.THUE,
                                //PhiBVMT = item.PHI,
                                item.TONGCONG,
                                To = itemtableND.TT_To.TenTo,
                                HanhThu = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                join itemND in _db.TT_NguoiDungs on item.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.NGAYGIAITRACH == null && item.TONGCONG >= SoTien && item.GB > 20
                                select new
                                {
                                    item.NGAYGIAITRACH,
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    DanhBo = item.DANHBA,
                                    HoTen = item.TENKH,
                                    DiaChi = item.SO + " " + item.DUONG,
                                    MLT = item.MALOTRINH,
                                    item.TIEUTHU,
                                    //item.GIABAN,
                                    //ThueGTGT = item.THUE,
                                    //PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                    To = itemtableND.TT_To.TenTo,
                                    HanhThu = itemtableND.HoTen,
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
                            join itemND in _db.TT_NguoiDungs on item.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.NAM == Nam && item.TONGCONG >= SoTien && item.GB >= 11 && item.GB <= 20
                            select new
                            {
                                item.NGAYGIAITRACH,
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                DanhBo = item.DANHBA,
                                HoTen = item.TENKH,
                                DiaChi = item.SO + " " + item.DUONG,
                                MLT = item.MALOTRINH,
                                item.TIEUTHU,
                                //item.GIABAN,
                                //ThueGTGT = item.THUE,
                                //PhiBVMT = item.PHI,
                                item.TONGCONG,
                                To = itemtableND.TT_To.TenTo,
                                HanhThu = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                join itemND in _db.TT_NguoiDungs on item.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.NAM == Nam && item.TONGCONG >= SoTien && item.GB > 20
                                select new
                                {
                                    item.NGAYGIAITRACH,
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    DanhBo = item.DANHBA,
                                    HoTen = item.TENKH,
                                    DiaChi = item.SO + " " + item.DUONG,
                                    MLT = item.MALOTRINH,
                                    item.TIEUTHU,
                                    //item.GIABAN,
                                    //ThueGTGT = item.THUE,
                                    //PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                    To = itemtableND.TT_To.TenTo,
                                    HanhThu = itemtableND.HoTen,
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
                            join itemND in _db.TT_NguoiDungs on item.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.NAM == Nam && item.KY == Ky && item.TONGCONG >= SoTien && item.GB >= 11 && item.GB <= 20
                            select new
                            {
                                item.NGAYGIAITRACH,
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                DanhBo = item.DANHBA,
                                HoTen = item.TENKH,
                                DiaChi = item.SO + " " + item.DUONG,
                                MLT = item.MALOTRINH,
                                item.TIEUTHU,
                                //item.GIABAN,
                                //ThueGTGT = item.THUE,
                                //PhiBVMT = item.PHI,
                                item.TONGCONG,
                                To = itemtableND.TT_To.TenTo,
                                HanhThu = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                join itemND in _db.TT_NguoiDungs on item.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.NAM == Nam && item.KY == Ky && item.TONGCONG >= SoTien && item.GB > 20
                                select new
                                {
                                    item.NGAYGIAITRACH,
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    DanhBo = item.DANHBA,
                                    HoTen = item.TENKH,
                                    DiaChi = item.SO + " " + item.DUONG,
                                    MLT = item.MALOTRINH,
                                    item.TIEUTHU,
                                    //item.GIABAN,
                                    //ThueGTGT = item.THUE,
                                    //PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                    To = itemtableND.TT_To.TenTo,
                                    HanhThu = itemtableND.HoTen,
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
                            join itemND in _db.TT_NguoiDungs on item.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.TONGCONG >= SoTien && item.GB >= 11 && item.GB <= 20
                            select new
                            {
                                item.NGAYGIAITRACH,
                                item.SOHOADON,
                                Ky = item.KY + "/" + item.NAM,
                                DanhBo = item.DANHBA,
                                HoTen = item.TENKH,
                                DiaChi = item.SO + " " + item.DUONG,
                                MLT = item.MALOTRINH,
                                item.TIEUTHU,
                                //item.GIABAN,
                                //ThueGTGT = item.THUE,
                                //PhiBVMT = item.PHI,
                                item.TONGCONG,
                                To = itemtableND.TT_To.TenTo,
                                HanhThu = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                join itemND in _db.TT_NguoiDungs on item.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.NAM == Nam && item.KY == Ky && item.DOT == Dot && item.TONGCONG >= SoTien && item.GB > 20
                                select new
                                {
                                    item.NGAYGIAITRACH,
                                    item.SOHOADON,
                                    Ky = item.KY + "/" + item.NAM,
                                    DanhBo = item.DANHBA,
                                    HoTen = item.TENKH,
                                    MLT = item.MALOTRINH,
                                    item.TIEUTHU,
                                    item.GIABAN,
                                    ThueGTGT = item.THUE,
                                    PhiBVMT = item.PHI,
                                    item.TONGCONG,
                                    To = itemtableND.TT_To.TenTo,
                                    HanhThu = itemtableND.HoTen,
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
        public DataTable GetDSThu2Lan(int Nam, int Ky, int Dot, bool ChuyenKhoan, bool Tra)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot && itemHD.Thu2Lan == true && itemHD.Thu2Lan_ChuyenKhoan == ChuyenKhoan && itemHD.Thu2Lan_Tra == Tra
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            MLT = itemHD.MALOTRINH,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
                            ChuyenKhoan = itemHD.Thu2Lan_ChuyenKhoan,
                            Tra = itemHD.Thu2Lan_Tra,
                            NgayTra = itemHD.Thu2Lan_NgayTra,
                            GhiChu = itemHD.Thu2Lan_GhiChu,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSThu2Lan(int Nam, int Ky, bool ChuyenKhoan, bool Tra)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.Thu2Lan == true && itemHD.Thu2Lan_ChuyenKhoan == ChuyenKhoan && itemHD.Thu2Lan_Tra == Tra
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            MLT = itemHD.MALOTRINH,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
                            ChuyenKhoan = itemHD.Thu2Lan_ChuyenKhoan,
                            Tra = itemHD.Thu2Lan_Tra,
                            NgayTra = itemHD.Thu2Lan_NgayTra,
                            GhiChu = itemHD.Thu2Lan_GhiChu,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSThu2Lan(bool ChuyenKhoan, bool Tra)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.Thu2Lan == true && itemHD.Thu2Lan_ChuyenKhoan == ChuyenKhoan && itemHD.Thu2Lan_Tra == Tra
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            MLT = itemHD.MALOTRINH,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
                            ChuyenKhoan = itemHD.Thu2Lan_ChuyenKhoan,
                            Tra = itemHD.Thu2Lan_Tra,
                            NgayTra = itemHD.Thu2Lan_NgayTra,
                            GhiChu = itemHD.Thu2Lan_GhiChu,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSThu2Lan(int Nam, bool ChuyenKhoan, bool Tra)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.NAM == Nam && itemHD.Thu2Lan == true && itemHD.Thu2Lan_ChuyenKhoan == ChuyenKhoan && itemHD.Thu2Lan_Tra == Tra
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            MLT = itemHD.MALOTRINH,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
                            ChuyenKhoan = itemHD.Thu2Lan_ChuyenKhoan,
                            Tra = itemHD.Thu2Lan_Tra,
                            NgayTra = itemHD.Thu2Lan_NgayTra,
                            GhiChu = itemHD.Thu2Lan_GhiChu,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSThu2Lan(string DanhBo, bool ChuyenKhoan, bool Tra)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.DANHBA == DanhBo && itemHD.Thu2Lan == true && itemHD.Thu2Lan_ChuyenKhoan == ChuyenKhoan && itemHD.Thu2Lan_Tra == Tra
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.NGAYGIAITRACH,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                            MLT = itemHD.MALOTRINH,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBieu = itemHD.GB,
                            ChuyenKhoan = itemHD.Thu2Lan_ChuyenKhoan,
                            Tra = itemHD.Thu2Lan_Tra,
                            NgayTra = itemHD.Thu2Lan_NgayTra,
                            GhiChu = itemHD.Thu2Lan_GhiChu,
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSHoaDon0_Ton(int Nam, int Ky, int Dot)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.TIEUTHU == 0 && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot && itemHD.NGAYGIAITRACH == null
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
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

        public DataTable GetDSHoaDon0(int Nam, int Ky, int TuDot, int DenDot, string GiaBieu, string DinhMuc, string Code)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.TIEUTHU == 0 && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT >= TuDot && itemHD.DOT <= DenDot
                            && itemHD.GB.ToString().Contains(GiaBieu.ToString())
                            && (itemHD.DM == null || itemHD.DM.Value.ToString().Contains(DinhMuc.ToString()))
                            && itemHD.CODE.Contains(Code)
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
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

        public DataTable GetDSHoaDon0(int Nam, int Ky, int Dot, string GiaBieu, string DinhMuc, string Code)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.TIEUTHU == 0 && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot
                            && itemHD.GB.ToString().Contains(GiaBieu.ToString())
                            && (itemHD.DM == null || itemHD.DM.Value.ToString().Contains(DinhMuc.ToString()))
                            && itemHD.CODE.Contains(Code)
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
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

        public DataTable GetDSHoaDon0(int Nam, int Ky, string GiaBieu, string DinhMuc, string Code)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.TIEUTHU == 0 && itemHD.NAM == Nam && itemHD.KY == Ky
                            && itemHD.GB.ToString().Contains(GiaBieu.ToString())
                            && (itemHD.DM == null || itemHD.DM.Value.ToString().Contains(DinhMuc.ToString()))
                            && itemHD.CODE.Contains(Code)
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
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
                        && itemHD.GB.ToString().Contains(GiaBieu.ToString())
                        && (itemHD.DM == null || itemHD.DM.Value.ToString().Contains(DinhMuc.ToString()))
                        && itemHD.CODE.Contains(Code)
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
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

        public DataTable GetDSHoaDon0_To(int MaTo, int Nam, string GiaBieu, string DinhMuc, string Code)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                              && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        && itemHD.TIEUTHU == 0 && itemHD.NAM == Nam
                        && itemHD.GB.ToString().Contains(GiaBieu.ToString())
                        && (itemHD.DM == null || itemHD.DM.Value.ToString().Contains(DinhMuc.ToString()))
                        && itemHD.CODE.Contains(Code)
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
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

        public DataTable GetDSHoaDon0_To(int MaTo, int Nam, int Ky, string GiaBieu, string DinhMuc, string Code)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                              && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        && itemHD.TIEUTHU == 0 && itemHD.NAM == Nam && itemHD.KY == Ky
                        && itemHD.GB.ToString().Contains(GiaBieu.ToString())
                        && (itemHD.DM == null || itemHD.DM.Value.ToString().Contains(DinhMuc.ToString()))
                        && itemHD.CODE.Contains(Code)
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
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

        public DataTable GetDSHoaDon0_To(int MaTo, int Nam, int Ky, int TuDot, int DenDot, string GiaBieu, string DinhMuc, string Code)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                              && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        && itemHD.TIEUTHU == 0 && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT >= TuDot && itemHD.DOT <= DenDot
                        && itemHD.GB.ToString().Contains(GiaBieu.ToString())
                        && (itemHD.DM == null || itemHD.DM.Value.ToString().Contains(DinhMuc.ToString()))
                        && itemHD.CODE.Contains(Code)
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
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

        public DataTable GetDSHoaDon0_To(int MaTo, int Nam, int Ky, int Dot, string GiaBieu, string DinhMuc, string Code)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                              && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        && itemHD.TIEUTHU == 0 && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot
                        && itemHD.GB.ToString().Contains(GiaBieu.ToString())
                        && (itemHD.DM == null || itemHD.DM.Value.ToString().Contains(DinhMuc.ToString()))
                        && itemHD.CODE.Contains(Code)
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
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

        public DataTable GetDSHoaDon0_NV(int MaNV, int Nam, string GiaBieu, string DinhMuc, string Code)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.MaNV_HanhThu == MaNV && itemHD.TIEUTHU == 0 && itemHD.NAM == Nam
                        && itemHD.GB.ToString().Contains(GiaBieu.ToString())
                        && (itemHD.DM == null || itemHD.DM.Value.ToString().Contains(DinhMuc.ToString()))
                        && itemHD.CODE.Contains(Code)
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
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

        public DataTable GetDSHoaDon0_NV(int MaNV, int Nam, int Ky, string GiaBieu, string DinhMuc, string Code)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.MaNV_HanhThu == MaNV && itemHD.TIEUTHU == 0 && itemHD.NAM == Nam && itemHD.KY == Ky
                        && itemHD.GB.ToString().Contains(GiaBieu.ToString())
                        && (itemHD.DM == null || itemHD.DM.Value.ToString().Contains(DinhMuc.ToString()))
                        && itemHD.CODE.Contains(Code)
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
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

        public DataTable GetDSHoaDon0_NV(int MaNV, int Nam, int Ky, int TuDot, int DenDot, string GiaBieu, string DinhMuc, string Code)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.MaNV_HanhThu == MaNV && itemHD.TIEUTHU == 0 && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT >= TuDot && itemHD.DOT <= DenDot
                        && itemHD.GB.ToString().Contains(GiaBieu.ToString())
                        && (itemHD.DM == null || itemHD.DM.Value.ToString().Contains(DinhMuc.ToString()))
                        && itemHD.CODE.Contains(Code)
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
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

        public DataTable GetDSHoaDon0_NV(int MaNV, int Nam, int Ky, int Dot, string GiaBieu, string DinhMuc, string Code)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.MaNV_HanhThu == MaNV && itemHD.TIEUTHU == 0 && itemHD.NAM == Nam && itemHD.KY == Ky && itemHD.DOT == Dot
                        && itemHD.GB.ToString().Contains(GiaBieu.ToString())
                        && (itemHD.DM == null || itemHD.DM.Value.ToString().Contains(DinhMuc.ToString()))
                        && itemHD.CODE.Contains(Code)
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
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

        public DataTable GetGroupHD0(int Nam)
        {
            var query = from item in _db.HOADONs
                        where item.TIEUTHU == 0 && item.NAM == Nam
                        group item by item.KY into itemGroup
                        select new
                        {
                            Ky = itemGroup.Key,
                            TongHD = itemGroup.Count(),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetGroupHD0_To(int MaTo, int Nam)
        {
            var query = from item in _db.HOADONs
                        where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                              && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                              && item.TIEUTHU == 0 && item.NAM == Nam
                        group item by item.KY into itemGroup
                        select new
                        {
                            Ky = itemGroup.Key,
                            TongHD = itemGroup.Count(),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetGroupHD0_NV(int MaNV, int Nam)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.MaNV_HanhThu == MaNV && itemHD.TIEUTHU == 0 && itemHD.NAM == Nam
                        group itemHD by itemHD.KY into itemGroup
                        select new
                        {
                            Ky = itemGroup.Key,
                            TongHD = itemGroup.Count(),
                        };
            return LINQToDataTable(query);
        }

        public DataTable ThongKeHD0_Code(int Nam, int Ky)
        {
            string sql = " select t1.CODE,t1.TongHD as KyA,t2.TongHD as KyB,t1.TongHD-t2.TongHD as BienDong from"
                         + " (select CODE,COUNT(*) as TongHD from HOADON"
                         + " where TIEUTHU=0 and NAM=" + Nam + " and KY=" + Ky
                         + " group by CODE) t1"
                         + " left join"
                         + " (select CODE,COUNT(*) as TongHD from HOADON"
                         + " where TIEUTHU=0 and NAM=" + Nam + " and KY=" + (Ky - 1)
                         + " group by CODE) t2 on t1.CODE=t2.CODE"
                         + " order by t1.CODE asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable ThongKeHD0_Code_To(int MaTo, int Nam, int Ky)
        {
            string sql = " select t1.CODE,t1.TongHD as KyA,t2.TongHD as KyB,t1.TongHD-t2.TongHD as BienDong from"
                         + " (select CODE,COUNT(*) as TongHD from HOADON"
                         + " where MAY>=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ") and MAY<=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ") and TIEUTHU=0 and NAM=" + Nam + " and KY=" + Ky
                         + " group by CODE) t1"
                         + " left join"
                         + " (select CODE,COUNT(*) as TongHD from HOADON"
                         + " where MAY>=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ") and MAY<=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ") and TIEUTHU=0 and NAM=" + Nam + " and KY=" + (Ky - 1)
                         + " group by CODE) t2 on t1.CODE=t2.CODE"
                         + " order by t1.CODE asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable ThongKeHD0_Code_NV(int MaNV_HanhThu, int Nam, int Ky)
        {
            string sql = " select t1.CODE,t1.TongHD as KyA,t2.TongHD as KyB,t1.TongHD-t2.TongHD as BienDong from"
                         + " (select CODE,COUNT(*) as TongHD from HOADON hd, TT_NguoiDung nd"
                         + " where hd.MaNV_HanhThu=nd.MaND and hd.MaNV_HanhThu=" + MaNV_HanhThu + " and TIEUTHU=0 and NAM=" + Nam + " and KY=" + Ky
                         + " group by CODE) t1"
                         + " left join"
                         + " (select CODE,COUNT(*) as TongHD from HOADON hd, TT_NguoiDung nd"
                         + " where hd.MaNV_HanhThu=nd.MaND and hd.MaNV_HanhThu=" + MaNV_HanhThu + " and TIEUTHU=0 and NAM=" + Nam + " and KY=" + (Ky - 1)
                         + " group by CODE) t2 on t1.CODE=t2.CODE"
                         + " order by t1.CODE asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTimKiem(string DanhBo, string MLT)
        {
            //string sql = "select ID_HOADON as MaHD,DANHBA as DanhBo,MALOTRINH as MLT,TENKH as HoTen,(SO+' '+DUONG) as DiaChi,GB as GiaBieu,DM as DinhMuc,a.SoHoaDon,"
            //    + "(convert(varchar(2),KY)+'/'+convert(varchar(4),NAM)) as Ky,TieuThu,GiaBan,Thue as ThueGTGT,Phi as PhiBVMT,TongCong,NgayGiaiTrach,b.HoTen as DangNgan,c.HoTen as HanhThu,MaDN,NgayDN,NgayMN"
            //    + ",DENNGAY as NgayDoc,CSMOI as ChiSo"
            //    + " from HOADON a left join TT_NguoiDung b on a.MaNV_DangNgan=b.MaND"
            //    + " left join TT_NguoiDung c on a.MaNV_HanhThu=c.MaND"
            //    + " left join"
            //    + " (select b.SoHoaDon,a.MaDN,NgayDN from TT_DongNuoc a"
            //    + " left join TT_CTDongNuoc b on a.MaDN=b.MaDN"
            //    + " left join TT_KQDongNuoc c on a.MaDN=c.MaDN where Huy=0) as dn on  a.SOHOADON=dn.SoHoaDon"
            //    + " where a.DANHBA like '%" + DanhBo + "%' and a.TENKH like '%" + HoTen + "%' and (SO+' '+DUONG) like '%" + DiaChi + "%'"
            //    + "order by ID_HOADON desc";

            string sql = "select * from fnTimKiem('" + DanhBo + "','" + MLT + "') order by MaHD desc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTimKiemTatCa(string DanhBo, string MLT)
        {
            //string sqlCu = "select * from fnTimKiemCu('" + DanhBo + "','" + MLT + "')";
            //string sql = "select * from fnTimKiem('" + DanhBo + "','" + MLT + "')";
            string sqlCu = "select * from fnTimKiemCu('" + DanhBo + "','" + MLT + "')";
            string sql = "select * from fnTimKiem('" + DanhBo + "','" + MLT + "')";

            DataTable dt = ExecuteQuery_DataTable(sql);
            dt.Merge(ExecuteQuery_DataTable(sqlCu));
            dt.DefaultView.Sort = "MaHD DESC";
            return dt;
        }

        public DataTable GetDSTimKiemTTKH(string HoTen, string SoNha, string TenDuong)
        {
            string sql = "select * from fnTimKiemTTKH('" + HoTen + "','" + SoNha + "','" + TenDuong + "')";

            return ExecuteQuery_DataTable(sql);
        }

        /// <summary>
        /// lấy danh sách chặn tiền dư
        /// </summary>
        /// <returns></returns>
        public DataTable GetDSChanTienDu(bool ChanHoaDonAuto)
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemTD in _db.TT_TienDus on itemHD.DANHBA equals itemTD.DanhBo into tableTD
                        from itemtableTD in tableTD.DefaultIfEmpty()
                        where itemHD.KhoaTienDu == true && _db.TT_ChanHoaDon_DanhBos.Any(item => item.DanhBo == itemHD.DANHBA && item.Nam == itemHD.NAM && itemHD.KY >= item.TuKy && itemHD.KY <= item.DenKy) == ChanHoaDonAuto
                        orderby itemHD.NgayChanTienDu descending
                        select new
                        {
                            itemHD.ChanTienDu,
                            itemHD.NgayChanTienDu,
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
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
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                            TienDu = itemtableTD.SoTien,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDCHDTienDu()
        {
            var query = from itemHD in _db.HOADONs
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemTD in _db.TT_TienDus on itemHD.DANHBA equals itemTD.DanhBo into tableTD
                        from itemtableTD in tableTD.DefaultIfEmpty()
                        where itemHD.DCHD == true
                        orderby itemHD.Ngay_DCHD descending
                        select new
                        {
                            itemHD.ChanTienDu,
                            itemHD.NgayChanTienDu,
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
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
                            To = itemtableND.TT_To.TenTo,
                            HanhThu = itemtableND.HoTen,
                            TienDu = itemtableTD.SoTien,
                            itemHD.TongCongTruoc_DCHD,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetGroupGiaBieu(int Nam)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == Nam
                        group item by item.GB into itemGroup
                        select new
                        {
                            ID = itemGroup.Key,
                            GiaBieu = itemGroup.Key.ToString(),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetGiaBanBinhQuan(int Nam)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == Nam
                        group item by item.NAM into itemGroup
                        select new
                        {
                            TongHD = itemGroup.Count(),
                            TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                            TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                            TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                            GiaBanBinhQuan = (double)itemGroup.Sum(groupItem => groupItem.GIABAN) / (double)itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetGiaBanBinhQuan(int Nam, int Ky)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == Nam && item.KY == Ky
                        group item by item.KY into itemGroup
                        select new
                        {
                            TongHD = itemGroup.Count(),
                            TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                            TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                            TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                            GiaBanBinhQuan = (double)itemGroup.Sum(groupItem => groupItem.GIABAN) / (double)itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                        };
            return LINQToDataTable(query);
        }

        public DataTable PhanTichDoanhThuByGiaBieu(int Nam)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == Nam
                        group item by item.GB into itemGroup
                        select new
                        {
                            Loai = itemGroup.Key,
                            TongHD = itemGroup.Count(),
                            TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                            TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                            TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                        };
            return LINQToDataTable(query);
        }

        public DataTable PhanTichDoanhThuByGiaBieu(int Nam, int Ky)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == Nam && item.KY == Ky
                        group item by item.GB into itemGroup
                        select new
                        {
                            Loai = itemGroup.Key,
                            TongHD = itemGroup.Count(),
                            TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                            TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                            TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                        };
            return LINQToDataTable(query);
        }

        public DataTable PhanTichDoanhThuByDinhMuc(int Nam, int FromDinhMuc, int ToDinhMuc)
        {
            DataTable dt = new DataTable();
            int DinhMuc = 4;

            var query0 = from item in _db.HOADONs
                         where item.NAM == Nam && (item.DM == 0 || item.DM == null)
                         group item by item.DM into itemGroup
                         select new
                         {
                             Loai = itemGroup.Key.ToString(),
                             TongHD = itemGroup.Count(),
                             TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                             TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                             TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                         };
            dt.Merge(LINQToDataTable(query0));

            while (DinhMuc < FromDinhMuc)
            {
                var query = from item in _db.HOADONs
                            where item.NAM == Nam && item.DM == DinhMuc
                            group item by item.DM into itemGroup
                            select new
                            {
                                Loai = itemGroup.Key.ToString(),
                                TongHD = itemGroup.Count(),
                                TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                            };
                dt.Merge(LINQToDataTable(query));
                DinhMuc += 4;
            }
            var queryDM = from item in _db.HOADONs
                          where item.NAM == Nam && item.DM >= FromDinhMuc && item.DM <= ToDinhMuc
                          group item by item.DM >= FromDinhMuc && item.DM <= ToDinhMuc into itemGroup
                          select new
                          {
                              Loai = FromDinhMuc + " - " + ToDinhMuc,
                              TongHD = itemGroup.Count(),
                              TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                              TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                              TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                          };
            dt.Merge(LINQToDataTable(queryDM));

            queryDM = from item in _db.HOADONs
                      where item.NAM == Nam && item.DM > ToDinhMuc
                      group item by item.DM > ToDinhMuc into itemGroup
                      select new
                      {
                          Loai = ToDinhMuc + 4 + " - Còn Lại",
                          TongHD = itemGroup.Count(),
                          TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                          TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                          TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                      };
            dt.Merge(LINQToDataTable(queryDM));

            return dt;
        }

        public DataTable PhanTichDoanhThuByDinhMuc(int Nam, int Ky, int FromDinhMuc, int ToDinhMuc)
        {
            DataTable dt = new DataTable();
            int DinhMuc = 4;

            var query0 = from item in _db.HOADONs
                         where item.NAM == Nam && item.KY == Ky && (item.DM == 0 || item.DM == null)
                         group item by item.DM into itemGroup
                         select new
                         {
                             Loai = itemGroup.Key.ToString(),
                             TongHD = itemGroup.Count(),
                             TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                             TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                             TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                         };
            dt.Merge(LINQToDataTable(query0));

            while (DinhMuc < FromDinhMuc)
            {
                var query = from item in _db.HOADONs
                            where item.NAM == Nam && item.KY == Ky && item.DM == DinhMuc
                            group item by item.DM into itemGroup
                            select new
                            {
                                Loai = itemGroup.Key.ToString(),
                                TongHD = itemGroup.Count(),
                                TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                            };
                dt.Merge(LINQToDataTable(query));
                DinhMuc += 4;
            }
            var queryDM = from item in _db.HOADONs
                          where item.NAM == Nam && item.KY == Ky && item.DM >= FromDinhMuc && item.DM <= ToDinhMuc
                          group item by item.DM >= FromDinhMuc && item.DM <= ToDinhMuc into itemGroup
                          select new
                          {
                              Loai = FromDinhMuc + " - " + ToDinhMuc,
                              TongHD = itemGroup.Count(),
                              TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                              TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                              TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                          };
            dt.Merge(LINQToDataTable(queryDM));

            queryDM = from item in _db.HOADONs
                      where item.NAM == Nam && item.KY == Ky && item.DM > ToDinhMuc
                      group item by item.DM > ToDinhMuc into itemGroup
                      select new
                      {
                          Loai = ToDinhMuc + 4 + " - Còn Lại",
                          TongHD = itemGroup.Count(),
                          TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                          TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                          TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                      };
            dt.Merge(LINQToDataTable(queryDM));

            //var query0 = from item in _db.HOADONs
            //             where item.NAM == Nam && item.KY == Ky && item.DM == 0
            //             group item by item.DM into itemGroup
            //             select new
            //             {
            //                 Loai = itemGroup.Key.ToString(),
            //                 TongHD = itemGroup.Count(),
            //                 TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
            //                 TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
            //                 TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
            //             };
            //dt.Merge(LINQToDataTable(query0));

            //var query4 = from item in _db.HOADONs
            //             where item.NAM == Nam && item.KY == Ky && item.DM == 4
            //             group item by item.DM into itemGroup
            //             select new
            //             {
            //                 Loai = itemGroup.Key.ToString(),
            //                 TongHD = itemGroup.Count(),
            //                 TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
            //                 TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
            //                 TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
            //             };
            //dt.Merge(LINQToDataTable(query4));

            //var query8 = from item in _db.HOADONs
            //             where item.NAM == Nam && item.KY == Ky && item.DM == 8
            //             group item by item.DM into itemGroup
            //             select new
            //             {
            //                 Loai = itemGroup.Key.ToString(),
            //                 TongHD = itemGroup.Count(),
            //                 TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
            //                 TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
            //                 TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
            //             };
            //dt.Merge(LINQToDataTable(query8));

            //var query12 = from item in _db.HOADONs
            //              where item.NAM == Nam && item.KY == Ky && item.DM == 12
            //              group item by item.DM into itemGroup
            //              select new
            //              {
            //                  Loai = itemGroup.Key.ToString(),
            //                  TongHD = itemGroup.Count(),
            //                  TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
            //                  TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
            //                  TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
            //              };
            //dt.Merge(LINQToDataTable(query12));

            //var query16 = from item in _db.HOADONs
            //              where item.NAM == Nam && item.KY == Ky && item.DM == 16
            //              group item by item.DM into itemGroup
            //              select new
            //              {
            //                  Loai = itemGroup.Key.ToString(),
            //                  TongHD = itemGroup.Count(),
            //                  TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
            //                  TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
            //                  TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
            //              };
            //dt.Merge(LINQToDataTable(query16));

            //var query20 = from item in _db.HOADONs
            //              where item.NAM == Nam && item.KY == Ky && item.DM == 20
            //              group item by item.DM into itemGroup
            //              select new
            //              {
            //                  Loai = itemGroup.Key.ToString(),
            //                  TongHD = itemGroup.Count(),
            //                  TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
            //                  TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
            //                  TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
            //              };
            //dt.Merge(LINQToDataTable(query20));

            //var queryK = from item in _db.HOADONs
            //             where item.NAM == Nam && item.KY == Ky && item.DM >= FromDinhMuc && item.DM <= ToDinhMuc
            //             group item by item.DM >= FromDinhMuc && item.DM <= ToDinhMuc into itemGroup
            //             select new
            //             {
            //                 Loai = FromDinhMuc + "-" + ToDinhMuc,
            //                 TongHD = itemGroup.Count(),
            //                 TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
            //                 TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
            //                 TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
            //             };
            //dt.Merge(LINQToDataTable(queryK));

            //var queryKK = from item in _db.HOADONs
            //              where item.NAM == Nam && item.KY == Ky && (item.DM != 0 && item.DM != 4 && item.DM != 8 && item.DM != 12 && item.DM != 16 && item.DM != 20 && (item.DM < FromDinhMuc || item.DM > ToDinhMuc) || item.DM == null)
            //              group item by item.KY == Ky && (item.DM != 0 && item.DM != 4 && item.DM != 8 && item.DM != 12 && (item.DM < FromDinhMuc || item.DM > ToDinhMuc) || item.DM == null) into itemGroup
            //              select new
            //              {
            //                  Loai = "Còn Lại",
            //                  TongHD = itemGroup.Count(),
            //                  TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
            //                  TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
            //                  TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
            //              };
            //dt.Merge(LINQToDataTable(queryKK));

            return dt;
        }

        public DataTable PhanTichDoanhThuByDinhMuc(int Nam, int Ky, int FromDinhMuc, int ToDinhMuc, int FromDinhMuc2, int ToDinhMuc2)
        {
            DataTable dt = new DataTable();
            int DinhMuc = 4;

            var query0 = from item in _db.HOADONs
                         where item.NAM == Nam && item.KY == Ky && (item.DM == 0 || item.DM == null)
                         group item by item.DM into itemGroup
                         select new
                         {
                             Loai = itemGroup.Key.ToString(),
                             TongHD = itemGroup.Count(),
                             TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                             TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                             TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                         };
            dt.Merge(LINQToDataTable(query0));

            while (DinhMuc < FromDinhMuc)
            {
                var query = from item in _db.HOADONs
                            where item.NAM == Nam && item.KY == Ky && item.DM == DinhMuc
                            group item by item.DM into itemGroup
                            select new
                            {
                                Loai = itemGroup.Key.ToString(),
                                TongHD = itemGroup.Count(),
                                TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                            };
                dt.Merge(LINQToDataTable(query));
                DinhMuc += 4;
            }

            var queryDM = from item in _db.HOADONs
                          where item.NAM == Nam && item.KY == Ky && item.DM >= FromDinhMuc && item.DM <= ToDinhMuc
                          group item by item.DM >= FromDinhMuc && item.DM <= ToDinhMuc into itemGroup
                          select new
                          {
                              Loai = FromDinhMuc + " - " + ToDinhMuc,
                              TongHD = itemGroup.Count(),
                              TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                              TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                              TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                          };
            dt.Merge(LINQToDataTable(queryDM));

            ///

            if (ToDinhMuc + 4 < FromDinhMuc2)
            {
                queryDM = from item in _db.HOADONs
                          where item.NAM == Nam && item.KY == Ky && item.DM >= ToDinhMuc + 4 && item.DM <= FromDinhMuc2 - 4
                          group item by item.DM >= ToDinhMuc + 4 && item.DM <= FromDinhMuc2 - 4 into itemGroup
                          select new
                          {
                              Loai = (ToDinhMuc + 4).ToString() + " - " + (FromDinhMuc2 - 4).ToString(),
                              TongHD = itemGroup.Count(),
                              TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                              TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                              TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                          };
                dt.Merge(LINQToDataTable(queryDM));
            }

            queryDM = from item in _db.HOADONs
                      where item.NAM == Nam && item.KY == Ky && item.DM >= FromDinhMuc2 && item.DM <= ToDinhMuc2
                      group item by item.DM >= FromDinhMuc2 && item.DM <= ToDinhMuc2 into itemGroup
                      select new
                      {
                          Loai = FromDinhMuc2 + " - " + ToDinhMuc2,
                          TongHD = itemGroup.Count(),
                          TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                          TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                          TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                      };
            dt.Merge(LINQToDataTable(queryDM));

            ///

            queryDM = from item in _db.HOADONs
                      where item.NAM == Nam && item.KY == Ky && item.DM > ToDinhMuc2
                      group item by item.DM > ToDinhMuc2 into itemGroup
                      select new
                      {
                          Loai = ToDinhMuc2 + 4 + " - Còn Lại",
                          TongHD = itemGroup.Count(),
                          TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                          TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                          TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                      };
            dt.Merge(LINQToDataTable(queryDM));

            return dt;
        }

        public DataTable PhanTichDoanhThuByDinhMuc(int Nam, int Ky, int FromDinhMuc, int ToDinhMuc, int FromDinhMuc2, int ToDinhMuc2, int FromDinhMuc3, int ToDinhMuc3)
        {
            DataTable dt = new DataTable();
            int DinhMuc = 4;

            var query0 = from item in _db.HOADONs
                         where item.NAM == Nam && item.KY == Ky && (item.DM == 0 || item.DM == null)
                         group item by item.DM into itemGroup
                         select new
                         {
                             Loai = itemGroup.Key.ToString(),
                             TongHD = itemGroup.Count(),
                             TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                             TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                             TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                         };
            dt.Merge(LINQToDataTable(query0));

            while (DinhMuc < FromDinhMuc)
            {
                var query = from item in _db.HOADONs
                            where item.NAM == Nam && item.KY == Ky && item.DM == DinhMuc
                            group item by item.DM into itemGroup
                            select new
                            {
                                Loai = itemGroup.Key.ToString(),
                                TongHD = itemGroup.Count(),
                                TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                                TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                            };
                dt.Merge(LINQToDataTable(query));
                DinhMuc += 4;
            }

            var queryDM = from item in _db.HOADONs
                          where item.NAM == Nam && item.KY == Ky && item.DM >= FromDinhMuc && item.DM <= ToDinhMuc
                          group item by item.DM >= FromDinhMuc && item.DM <= ToDinhMuc into itemGroup
                          select new
                          {
                              Loai = FromDinhMuc + " - " + ToDinhMuc,
                              TongHD = itemGroup.Count(),
                              TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                              TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                              TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                          };
            dt.Merge(LINQToDataTable(queryDM));

            ///

            if (ToDinhMuc + 4 < FromDinhMuc2)
            {
                queryDM = from item in _db.HOADONs
                          where item.NAM == Nam && item.KY == Ky && item.DM >= ToDinhMuc + 4 && item.DM <= FromDinhMuc2 - 4
                          group item by item.DM >= ToDinhMuc + 4 && item.DM <= FromDinhMuc2 - 4 into itemGroup
                          select new
                          {
                              Loai = (ToDinhMuc + 4).ToString() + " - " + (FromDinhMuc2 - 4).ToString(),
                              TongHD = itemGroup.Count(),
                              TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                              TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                              TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                          };
                dt.Merge(LINQToDataTable(queryDM));
            }

            queryDM = from item in _db.HOADONs
                      where item.NAM == Nam && item.KY == Ky && item.DM >= FromDinhMuc2 && item.DM <= ToDinhMuc2
                      group item by item.DM >= FromDinhMuc2 && item.DM <= ToDinhMuc2 into itemGroup
                      select new
                      {
                          Loai = FromDinhMuc2 + " - " + ToDinhMuc2,
                          TongHD = itemGroup.Count(),
                          TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                          TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                          TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                      };
            dt.Merge(LINQToDataTable(queryDM));

            ///

            if (ToDinhMuc2 + 4 < FromDinhMuc3)
            {
                queryDM = from item in _db.HOADONs
                          where item.NAM == Nam && item.KY == Ky && item.DM >= ToDinhMuc2 + 4 && item.DM <= FromDinhMuc3 - 4
                          group item by item.DM >= ToDinhMuc2 + 4 && item.DM <= FromDinhMuc3 - 4 into itemGroup
                          select new
                          {
                              Loai = (ToDinhMuc2 + 4).ToString() + " - " + (FromDinhMuc3 - 4).ToString(),
                              TongHD = itemGroup.Count(),
                              TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                              TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                              TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                          };
                dt.Merge(LINQToDataTable(queryDM));
            }

            queryDM = from item in _db.HOADONs
                      where item.NAM == Nam && item.KY == Ky && item.DM >= FromDinhMuc3 && item.DM <= ToDinhMuc3
                      group item by item.DM >= FromDinhMuc3 && item.DM <= ToDinhMuc3 into itemGroup
                      select new
                      {
                          Loai = FromDinhMuc3 + " - " + ToDinhMuc3,
                          TongHD = itemGroup.Count(),
                          TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                          TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                          TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                      };
            dt.Merge(LINQToDataTable(queryDM));

            ///

            queryDM = from item in _db.HOADONs
                      where item.NAM == Nam && item.KY == Ky && item.DM > ToDinhMuc3
                      group item by item.DM > ToDinhMuc3 into itemGroup
                      select new
                      {
                          Loai = ToDinhMuc3 + 4 + " - Còn Lại",
                          TongHD = itemGroup.Count(),
                          TongTieuThu = itemGroup.Sum(groupItem => groupItem.TIEUTHU),
                          TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                          TongDinhMuc = itemGroup.Sum(groupItem => groupItem.DM),
                      };
            dt.Merge(LINQToDataTable(queryDM));

            return dt;
        }

        public DataTable getDS_XacNhanThanhToan(string DanhBo, int FromKy, int FromNam, int ToKy, int ToNam)
        {
            string sql = "declare @DanhBo char(11)"
                        + " declare @FromKy int"
                        + " declare @FromNam int"
                        + " declare @ToKy int"
                        + " declare @ToNam int"
                        + " set @DanhBo='" + DanhBo + "'"
                        + " set @FromKy=" + FromKy
                        + " set @FromNam=" + FromNam
                        + " set @ToKy=" + ToKy
                        + " set @ToNam=" + ToNam
                        + " if(@FromNam=@ToNam)"
                        + " 	select DanhBo=DANHBA,KY,NAM,GIABAN,ThueGTGT=THUE,PhiBVMT=PHI,TONGCONG,NGAYGIAITRACH,SOHOADON from HOADON where DANHBA=@DanhBo and NAM>=@FromNam and KY>=@FromKy and NAM<=@ToNam and KY<=@ToKy"
                        + " 	union all"
                        + " 	select DanhBo=DANHBA,KY,NAM,GIABAN,ThueGTGT=THUE,PhiBVMT=PHI,TONGCONG,NGAYGIAITRACH,SOHOADON from TT_HoaDonCu where DANHBA=@DanhBo and NAM>=@FromNam and KY>=@FromKy and NAM<=@ToNam and KY<=@ToKy"
                        + " else"
                        + " 	if(@FromNam<@ToNam)"
                        + " 		select DanhBo=DANHBA,KY,NAM,GIABAN,ThueGTGT=THUE,PhiBVMT=PHI,TONGCONG,NGAYGIAITRACH,SOHOADON from HOADON where DANHBA=@DanhBo and ((NAM>=@FromNam and NAM<@ToNam and KY>=@FromKy) or (NAM=@ToNam and KY<=@ToKy))"
                        + " 		union all"
                        + " 		select DanhBo=DANHBA,KY,NAM,GIABAN,ThueGTGT=THUE,PhiBVMT=PHI,TONGCONG,NGAYGIAITRACH,SOHOADON from TT_HoaDonCu where DANHBA=@DanhBo and ((NAM>=@FromNam and NAM<@ToNam  and KY>=@FromKy) or (NAM=@ToNam and KY<=@ToKy))";
            return ExecuteQuery_DataTable(sql);
        }

        public int CountHoaDon(int Nam, int Ky)
        {
            return _db.HOADONs.Count(item => item.NAM == Nam && item.KY == Ky);
        }

        public int CountDSTon()
        {
            return _db.HOADONs.Count(item => item.NGAYGIAITRACH == null);
        }

        public int CountBySoPhatHanhs(decimal TuSoPhatHanh, decimal DenSoPhatHanh, int Nam, int Ky, int Dot)
        {
            return _db.HOADONs.Count(item => item.SOPHATHANH >= TuSoPhatHanh && item.SOPHATHANH <= DenSoPhatHanh && item.NAM == Nam && item.KY == Ky && item.DOT == Dot);
        }

        public DateTime GetNgayGiaiTrach(string SoHoaDon)
        {
            return _db.HOADONs.SingleOrDefault(item => item.SOHOADON == SoHoaDon).NGAYGIAITRACH.Value;
        }

        public DataTable getXuatExcelBangKe(DateTime NgayGiaiTrach)
        {
            string sql = "select bk.*,DanhBo=DANHBA,HoTen=TENKH,Ky,GIABAN,ThueGTGT=THUE,PhiBVMT=hd.PHI,TONGCONG,TienMat from HOADON hd"
                        + " left join"
                        + " ("
                        + " 	select DanhBo,SoPhieuThu,NgayPhieuThu,SoTien,ROW_NUMBER() OVER (PARTITION BY DanhBo ORDER BY CreateDate desc) AS RowNum from TT_BangKe"
                        + " 	where CAST(CreateDate as date)<='" + NgayGiaiTrach.ToString("yyyyMMdd") + "'"
                        + " ) bk on bk.DanhBo=hd.DANHBA and RowNum=1"
                        + " where DangNgan_ChuyenKhoan=1 and CAST(NGAYGIAITRACH as date)='" + NgayGiaiTrach.ToString("yyyyMMdd") + "'"
                        + " order by NGAYGIAITRACH asc";
            return ExecuteQuery_DataTable(sql);
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

        public bool DangNgan(string Loai, string SoHoaDon, int MaNV_DangNgan)
        {
            try
            {
                string sql = "";
                //if (Loai == "HanhThu")
                //    sql = "update HOADON set DangNgan_HanhThu=1,MaNV_DangNgan=" + MaNV_DangNgan + ",NGAYGIAITRACH='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() "
                //            + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null ";
                //else
                //    if (Loai == "Quay")
                //        sql = "update HOADON set DangNgan_Quay=1,MaNV_DangNgan=" + MaNV_DangNgan + ",NGAYGIAITRACH='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() "
                //                + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null ";
                //    else
                //        if (Loai == "ChuyenKhoan")
                //        {
                //            sql = "update HOADON set DangNgan_ChuyenKhoan=1,MaNV_DangNgan=" + MaNV_DangNgan + ",NGAYGIAITRACH='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() "
                //                + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null ";

                //        }
                //        else
                //            if (Loai == "Ton")
                //                sql = "update HOADON set DangNgan_Ton=1,MaNV_DangNgan=" + MaNV_DangNgan + ",NGAYGIAITRACH='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() "
                //                    + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null ";
                if (Loai == "HanhThu")
                    sql = "update HOADON set DangNgan_HanhThu=1,MaNV_DangNgan=" + MaNV_DangNgan + ",NGAYGIAITRACH=getdate(),Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() "
                            + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null ";
                else
                    if (Loai == "Quay")
                        sql = "update HOADON set DangNgan_Quay=1,MaNV_DangNgan=" + MaNV_DangNgan + ",NGAYGIAITRACH=getdate(),Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() "
                                + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null ";
                    else
                        if (Loai == "ChuyenKhoan")
                        {
                            sql = "update HOADON set DangNgan_ChuyenKhoan=1,MaNV_DangNgan=" + MaNV_DangNgan + ",NGAYGIAITRACH=getdate(),Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() "
                                + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null ";

                        }
                        else
                            if (Loai == "Ton")
                                sql = "update HOADON set DangNgan_Ton=1,MaNV_DangNgan=" + MaNV_DangNgan + ",NGAYGIAITRACH=getdate(),Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() "
                                    + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null ";
                //return ExecuteNonQuery_Transaction(sql);
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DangNgan(string Loai, string SoHoaDon, int MaNV_DangNgan, DateTime NgayGiaiTrach)
        {
            try
            {
                string sql = "";
                if (Loai == "")
                    sql = "update HOADON set MaNV_DangNgan=" + MaNV_DangNgan + ",NGAYGIAITRACH='" + NgayGiaiTrach.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() "
                            + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null ";
                else
                    if (Loai == "HanhThu")
                        sql = "update HOADON set DangNgan_HanhThu=1,MaNV_DangNgan=" + MaNV_DangNgan + ",NGAYGIAITRACH='" + NgayGiaiTrach.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() "
                                + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null ";
                    else
                        if (Loai == "Quay")
                            sql = "update HOADON set DangNgan_Quay=1,MaNV_DangNgan=" + MaNV_DangNgan + ",NGAYGIAITRACH='" + NgayGiaiTrach.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyDate=getdate() "
                                    + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null ";
                        else
                            if (Loai == "ChuyenKhoan")
                            {
                                sql = "update HOADON set DangNgan_ChuyenKhoan=1,MaNV_DangNgan=" + MaNV_DangNgan + ",NGAYGIAITRACH='" + NgayGiaiTrach.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyDate=getdate() "
                                    + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null ";

                            }
                            else
                                if (Loai == "Ton")
                                    sql = "update HOADON set DangNgan_Ton=1,MaNV_DangNgan=" + MaNV_DangNgan + ",NGAYGIAITRACH='" + NgayGiaiTrach.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyDate=getdate() "
                                        + "where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null ";
                //return ExecuteNonQuery_Transaction(sql);
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DangNganTienMatChuyenKhoan(string SoHoaDon, int MaNV_DangNgan)
        {
            try
            {
                string sql = "update HOADON set DangNgan_ChuyenKhoan=1,MaNV_DangNgan=" + MaNV_DangNgan + ",NGAYGIAITRACH=getdate(),Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate(),"
                    + "TienDu=(select td.SoTien from TT_TienDu td,HOADON hd where td.DanhBo=hd.DANHBA and SOHOADON='" + SoHoaDon + "'),TienMat=(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "')-(select td.SoTien from TT_TienDu td,HOADON hd where td.DanhBo=hd.DANHBA and SOHOADON='" + SoHoaDon + "')"
                    + " where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null ";
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DangNganTienMatChuyenKhoan(string SoHoaDon, int MaNV_DangNgan, DateTime NgayGiaiTrach)
        {
            try
            {
                string sql = "update HOADON set DangNgan_ChuyenKhoan=1,MaNV_DangNgan=" + MaNV_DangNgan + ",NGAYGIAITRACH='" + NgayGiaiTrach.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate(),"
                    + "TienDu=(select td.SoTien from TT_TienDu td,HOADON hd where td.DanhBo=hd.DANHBA and SOHOADON='" + SoHoaDon + "'),TienMat=(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "')-(select td.SoTien from TT_TienDu td,HOADON hd where td.DanhBo=hd.DANHBA and SOHOADON='" + SoHoaDon + "')"
                    + " where SOHOADON='" + SoHoaDon + "' and NGAYGIAITRACH is null ";
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaDangNgan(string Loai, string SoHoaDon, int MaNV_DangNgan)
        {
            try
            {
                string sql = "";
                if (Loai == "")
                    sql = "update HOADON set MaNV_DangNgan=null,NGAYGIAITRACH=null,DangNgan_DienThoai=0,DangNgan_HanhThu=0,DangNgan_Quay=0,DangNgan_ChuyenKhoan=0,DangNgan_Ton=0,ModifyBy=" + CNguoiDung.MaND + ",Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyDate=getdate() "
                           + "where SOHOADON='" + SoHoaDon + "' and MaNV_DangNgan=" + MaNV_DangNgan;
                else
                    if (Loai == "HanhThu")
                        sql = "update HOADON set DangNgan_DienThoai=0,DangNgan_HanhThu=0,MaNV_DangNgan=null,NGAYGIAITRACH=null,ModifyBy=" + CNguoiDung.MaND + ",Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyDate=getdate() "
                               + "where SOHOADON='" + SoHoaDon + "' and DangNgan_HanhThu=1 and MaNV_DangNgan=" + MaNV_DangNgan;
                    else
                        if (Loai == "Quay")
                            sql = "update HOADON set DangNgan_Quay=0,MaNV_DangNgan=null,NGAYGIAITRACH=null,ModifyBy=" + CNguoiDung.MaND + ",Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyDate=getdate() "
                                   + "where SOHOADON='" + SoHoaDon + "' and DangNgan_Quay=1 and MaNV_DangNgan=" + MaNV_DangNgan;
                        else
                            if (Loai == "ChuyenKhoan")
                                sql = "update HOADON set DangNgan_ChuyenKhoan=0,MaNV_DangNgan=null,NGAYGIAITRACH=null,ModifyBy=" + CNguoiDung.MaND + ",Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyDate=getdate() "
                                       + "where SOHOADON='" + SoHoaDon + "' and DangNgan_ChuyenKhoan=1 and MaNV_DangNgan=" + MaNV_DangNgan + " and TienMat is null";
                            else
                                if (Loai == "Ton")
                                    sql = "update HOADON set DangNgan_DienThoai=0,DangNgan_Ton=0,MaNV_DangNgan=null,NGAYGIAITRACH=null,ModifyBy=" + CNguoiDung.MaND + ",Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyDate=getdate() "
                                           + "where SOHOADON='" + SoHoaDon + "' and DangNgan_Ton=1 and MaNV_DangNgan=" + MaNV_DangNgan;
                //return ExecuteNonQuery_Transaction(sql);
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaDangNganTienMatChuyenKhoan(string SoHoaDon, int MaNV_DangNgan)
        {
            try
            {
                string sql = "update HOADON set DangNgan_ChuyenKhoan=0,MaNV_DangNgan=null,NGAYGIAITRACH=null,TienDu=null,TienMat=null,Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() "
                                       + "where SOHOADON='" + SoHoaDon + "' and DangNgan_ChuyenKhoan=1 and MaNV_DangNgan=" + MaNV_DangNgan;
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaDangNgan(string SoHoaDon)
        {
            try
            {
                string sql = "";
                sql = "update HOADON set DangNgan_DienThoai=0,DangNgan_HanhThu=0,DangNgan_Quay=0,DangNgan_ChuyenKhoan=0,DangNgan_Ton=0,MaNV_DangNgan=null,NGAYGIAITRACH=null,Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() "
                       + "where SOHOADON='" + SoHoaDon + "'";
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GiaoTon(string SoHoaDon, int MaNV_GiaoTon)
        {
            try
            {
                string sql = "update HOADON set MaNV_HanhThuTruoc=MaNV_HanhThu,MaNV_HanhThu=" + MaNV_GiaoTon + ",NGAYGIAOTON='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() "
                                + "where SOHOADON='" + SoHoaDon + "' and MaNV_DangNgan is null";
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaGiaoTon(string SoHoaDon)
        {
            try
            {
                string sql = "update HOADON set MaNV_HanhThu=MaNV_HanhThuTruoc,MaNV_HanhThuTruoc=null,NGAYGIAOTON=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() "
                                + "where SOHOADON='" + SoHoaDon + "' and MaNV_DangNgan is null";
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Thu2Lan(string SoHoaDon, bool ChuyenKhoan)
        {
            try
            {
                string sql = "";
                sql = "update HOADON set Thu2Lan=1,Thu2Lan_ChuyenKhoan='" + ChuyenKhoan + "' where Thu2Lan=0 and SOHOADON='" + SoHoaDon + "'";
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaThu2Lan(string SoHoaDon)
        {
            try
            {
                string sql = "";
                sql = "update HOADON set Thu2Lan=0 where Thu2Lan=1 and SOHOADON='" + SoHoaDon + "'";
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Thu2Lan(int Nam, int Ky, string DanhBo, bool ChuyenKhoan)
        {
            try
            {
                string sql = "";
                sql = "update HOADON set Thu2Lan=1,Thu2Lan_ChuyenKhoan='" + ChuyenKhoan + "' where Thu2Lan=0 and NAM=" + Nam + " and KY=" + Ky + " and DANHBA='" + DanhBo + "'";
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Thu2Lan_GhiChu(string SoHoaDon, string GhiChu)
        {
            try
            {
                string sql = "";
                sql = "update HOADON set Thu2Lan_GhiChu=N'" + GhiChu + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate()"
                + " where SOHOADON='" + SoHoaDon + "'";
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Thu2Lan_Tra(string SoHoaDon)
        {
            try
            {
                string sql = "";
                sql = "update HOADON set Thu2Lan_Tra=1,Thu2Lan_NgayTra='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate()"
                + " where Thu2Lan_Tra=0 and SOHOADON='" + SoHoaDon + "'";
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Thu2Lan_XoaTra(string SoHoaDon)
        {
            try
            {
                string sql = "";
                sql = "update HOADON set Thu2Lan_Tra=0,Thu2Lan_NgayTra=null,Thu2Lan_GhiChu=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate()"
                    + " where Thu2Lan_Tra=1 and SOHOADON='" + SoHoaDon + "'";
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ChuyenNoKhoDoi(string SoHoaDon)
        {
            try
            {
                string sql = "";
                sql = "update HOADON set ChuyenNoKhoDoi=1,NGAYGIAITRACH='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() where ChuyenNoKhoDoi=0 and SOHOADON='" + SoHoaDon + "'";
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaChuyenNoKhoDoi(string SoHoaDon)
        {
            try
            {
                string sql = "";
                sql = "update HOADON set ChuyenNoKhoDoi=0,NGAYGIAITRACH=null,Name_PC='" + CNguoiDung.Name_PC + "',IP_PC='" + CNguoiDung.IP_PC + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() where ChuyenNoKhoDoi=1 and SOHOADON='" + SoHoaDon + "'";
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckKhoaTienDuBySoHoaDon(string SoHoaDon)
        {
            return _db.HOADONs.Any(item => item.SOHOADON == SoHoaDon && item.KhoaTienDu == true);
        }

        public bool CheckKhoaTienDuByDanhBo(string DanhBo)
        {
            return _db.HOADONs.Any(item => item.DANHBA == DanhBo && item.KhoaTienDu == true);
        }

        public bool CheckDCHDTienDuBySoHoaDon(string SoHoaDon)
        {
            return _db.HOADONs.Any(item => item.SOHOADON == SoHoaDon && item.DCHD == true);
        }

        public bool CheckDCHDTienDuByDanhBo(string DanhBo)
        {
            return _db.HOADONs.Any(item => item.DANHBA == DanhBo && item.DCHD == true);
        }

        //lịch sử đăng ngân
        public DataTable getDS_LichSuDangNgan(int MaHD)
        {
            var query = from item in _db.TT_LichSuDangNgans
                        join itemND in _db.TT_NguoiDungs on item.CreateBy equals itemND.MaND
                        where item.MaHD == MaHD
                        select new
                        {
                            item.GhiChu,
                            item.Name_PC,
                            item.IP_PC,
                            CreateBy = itemND.HoTen,
                            item.CreateDate,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS(string soluong)
        {
            string sql = "select distinct top " + soluong + " DanhBo=DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,Hieu=HIEUDH,Co=CoDH from HOADON where KY=12 and DOT=20";
            return ExecuteQuery_DataTable(sql);
        }
    }

}
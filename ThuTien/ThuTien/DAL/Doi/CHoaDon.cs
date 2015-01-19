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
        public bool ThemChia(int MaTo,string loai, decimal tusophathanh, decimal densophathanh, int nam, int ky, int dot,int MaNV)
        {
            try
            {
                if (loai == "TG")
                {
                    //_db.HOADONs.Where(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                    //                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                    //                    && Convert.ToInt32(item.MALOTRINH) >= int.Parse(tumlt) && Convert.ToInt32(item.MALOTRINH) <= int.Parse(denmlt)
                    //                    && item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB >= 11 && item.GB <= 20).ToList()
                    //                    .ForEach(item => { item.MaNV_HanhThu = MaNV; item.ModifyBy = CNguoiDung.MaND; item.ModifyDate = DateTime.Now; });
                    string sql = "update HOADON set MaNV_HanhThu=" + MaNV + ",NGAYGIAO='" + DateTime.Now + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now + "' "
                        + "where SOPHATHANH>='" + tusophathanh + "' and SOPHATHANH<='" + densophathanh + "' and NAM=" + nam + " and KY=" + ky + " and DOT=" + dot + " and GB>=11 and GB<=20 "
                        + "and MAY>=" + ExecuteQuery_SqlDataReader_DataTable("select TuCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + " and MAY<=" + ExecuteQuery_SqlDataReader_DataTable("select DenCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + "";
                    ExecuteNonQuery(sql,true);
                }
                else
                    if (loai == "CQ")
                    {
                        //_db.HOADONs.Where(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                        //            && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        //            && Convert.ToInt32(item.MALOTRINH) >= int.Parse(tumlt) && Convert.ToInt32(item.MALOTRINH) <= int.Parse(denmlt)
                        //            && item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB > 20).ToList()
                        //            .ForEach(item => { item.MaNV_HanhThu = MaNV; item.ModifyBy = CNguoiDung.MaND; item.ModifyDate = DateTime.Now; });
                        string sql = "update HOADON set MaNV_HanhThu=" + MaNV + ",NGAYGIAO='" + DateTime.Now + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now + "' "
                        + "where SOPHATHANH>='" + tusophathanh + "' and SOPHATHANH<='" + densophathanh + "' and NAM=" + nam + " and KY=" + ky + " and DOT=" + dot + " and GB>20 "
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
        public bool XoaChia(int MaTo, string loai, decimal tusophathanh, decimal densophathanh, int nam, int ky, int dot)
        {
            try
            {
                if (loai == "TG")
                {
                    //_db.HOADONs.Where(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                    //                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                    //                    && Convert.ToInt32(item.MALOTRINH) >= int.Parse(tumlt) && Convert.ToInt32(item.MALOTRINH) <= int.Parse(denmlt)
                    //                    && item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB >= 11 && item.GB <= 20).ToList()
                    //                    .ForEach(item => { item.MaNV_HanhThu = null; item.ModifyBy = CNguoiDung.MaND; item.ModifyDate = DateTime.Now; });
                    string sql = "update HOADON set MaNV_HanhThu=null,NGAYGIAO=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now + "' "
                        + "where SOPHATHANH>='" + tusophathanh + "' and SOPHATHANH<='" + densophathanh + "' and NAM=" + nam + " and KY=" + ky + " and DOT=" + dot + " and GB>=11 and GB<=20 "
                        + "and MAY>=" + ExecuteQuery_SqlDataReader_DataTable("select TuCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + " and MAY<=" + ExecuteQuery_SqlDataReader_DataTable("select DenCuonGCS from TT_To where MaTo=" + MaTo).Rows[0][0] + "";
                    ExecuteNonQuery(sql,true);
                }
                else
                    if (loai == "CQ")
                    {
                        //_db.HOADONs.Where(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                        //            && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        //            && Convert.ToInt32(item.MALOTRINH) >= int.Parse(tumlt) && Convert.ToInt32(item.MALOTRINH) <= int.Parse(denmlt)
                        //            && item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB > 20).ToList()
                        //            .ForEach(item => { item.MaNV_HanhThu = null; item.ModifyBy = CNguoiDung.MaND; item.ModifyDate = DateTime.Now; });
                        string sql = "update HOADON set MaNV_HanhThu=null,NGAYGIAO=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now + "' "
                        + "where SOPHATHANH>='" + tusophathanh + "' and SOPHATHANH<='" + densophathanh + "' and NAM=" + nam + " and KY=" + ky + " and DOT=" + dot + " and GB>20 "
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
        public bool CheckByNamKyDot(int nam, int ky, int dot)
        {
            return _db.HOADONs.Any(item => item.NAM == nam && item.KY == ky && item.DOT == dot);
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
        public bool CheckSoPhatHanhByNamKyDot(int MaTo, string loai, decimal sophathanh, int nam, int ky, int dot)
        {
            if (loai == "TG")
                return _db.HOADONs.Any(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        && item.SOPHATHANH == sophathanh && item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB >= 11 && item.GB <= 20);
            else
                if (loai == "CQ")
                    return _db.HOADONs.Any(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.SOPHATHANH == sophathanh && item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB > 20);
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
        public bool CheckGiaoBySoPhatHanhsNamKyDot(decimal tusophathanh, decimal densophathanh, int nam)
        {
            return _db.HOADONs.Any(item => item.SOPHATHANH >= tusophathanh && item.SOPHATHANH <= densophathanh && item.NAM == nam && item.MaNV_HanhThu != null);
        }

        /// <summary>
        /// Kiểm tra đã đăng ngân chưa (số phát hành trong 1 năm không bị trùng)
        /// </summary>
        /// <param name="tusophathanh"></param>
        /// <param name="densophathanh"></param>
        /// <param name="nam"></param>
        /// <returns></returns>
        public bool CheckDangNganBySoPhatHanhsNamKyDot(decimal tusophathanh, decimal densophathanh, int nam)
        {
            return _db.HOADONs.Any(item => item.SOPHATHANH >= tusophathanh && item.SOPHATHANH <= densophathanh && item.NAM == nam && item.MaNV_DangNgan != null);
        }

        /// <summary>
        /// Lấy danh sách năm có trong hóa đơn
        /// </summary>
        /// <returns></returns>
        public DataTable GetNam()
        {
            //return this.LINQToDataTable(_db.HOADONs.Select(item => new { item.NAM }).Distinct().OrderByDescending(item => item.NAM).ToList());
            return LINQToDataTable(_db.ViewGetNamHDs.OrderByDescending(item=>item.Nam));
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
        public DataTable GetDSGiaoByNamKyDot(int MaTo, string loai, int nam, int ky, int dot)
        {
            if (loai == "TG")
            {
                var query = from item in _db.HOADONs
                            where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB >= 11 && item.GB <= 20
                            orderby item.SOPHATHANH ascending
                            group item by item.MaNV_HanhThu into itemGroup
                            select new
                            {
                                MaNV = itemGroup.Key,
                                _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
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
                return LINQToDataTable(query);
            }
            else
                if (loai == "CQ")
                {
                    var query = from item in _db.HOADONs
                                where Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB > 20
                                orderby item.SOPHATHANH ascending
                                group item by item.MaNV_HanhThu into itemGroup
                                select new
                                {
                                    MaNV = itemGroup.Key,
                                    _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == itemGroup.Key).HoTen,
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
                    return LINQToDataTable(query);
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
        public DataTable GetTongByMaNVNamKyDot(int MaNV, int nam, int ky, int dot)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == nam && item.KY == ky && item.DOT == dot && item.MaNV_HanhThu == MaNV
                        group item by item.GB >= 11 && item.GB <= 20 into itemGroup
                        select new
                        {
                            Loai=itemGroup.Key.ToString(),
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
        public DataTable GetDSDangNganHanhThuByMaNVNamKyDot(int MaNV, int nam, int ky, int dot)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == nam && item.KY == ky && item.DOT == dot && item.MaNV_HanhThu==MaNV && item.DangNgan_HanhThu==true && item.MaNV_DangNgan == MaNV
                        orderby item.SOHOADON ascending
                        select new
                        {
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

        /// <summary>
        /// Lấy danh sách hóa đơn được giao & tồn lại bởi anh/em cụ thể
        /// </summary>
        /// <param name="MaNV"></param>
        /// <param name="nam"></param>
        /// <param name="ky"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        public DataTable GetDSTonByMaNVNamKyDot(int MaNV, int nam, int ky, int dot)
        {
            var query = from item in _db.HOADONs
                        where item.NAM == nam && item.KY == ky && item.DOT == dot && item.MaNV_HanhThu == MaNV && item.MaNV_DangNgan == null
                        orderby item.SOHOADON ascending
                        select new
                        {
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

        public DataTable GetDSDangNganQuayByMaNVNgayGiaiTrachs(int MaNV,DateTime TuNgay,DateTime DenNgay)
        {
            var query = from item in _db.HOADONs
                        where item.DangNgan_Quay == true && item.MaNV_DangNgan == MaNV && item.NGAYGIAITRACH.Value.Date >= TuNgay.Date && item.NGAYGIAITRACH.Value.Date <= DenNgay.Date
                        select new
                        {
                            item.NAM,
                            item.KY,
                            item.DOT,
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

        public List<HOADON> GetDSBySoPhatHanhNamsKyDot(int MaTo, string loai, decimal tusophathanh, decimal densophathanh, int nam, int ky, int dot)
        {
            if (loai == "TG")
                return _db.HOADONs.Where(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                        && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                        && item.SOPHATHANH >= tusophathanh && item.SOPHATHANH <= densophathanh
                                        && item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB >= 11 && item.GB <= 20).ToList();
            else
                if (loai == "CQ")
                    return _db.HOADONs.Where(item => Convert.ToInt32(item.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(item.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && item.SOPHATHANH >= tusophathanh && item.SOPHATHANH <= densophathanh
                                    && item.NAM == nam && item.KY == ky && item.DOT == dot && item.GB > 20).ToList();
                else
                    return null;

        }

        public bool DangNgan(string loai,string sohoadon, int MaNV, int nam, int ky, int dot)
        {
            try
            {
                string sql = "";
                if (loai == "HanhThu")
                    sql = "update HOADON set DangNgan_HanhThu=1,MaNV_DangNgan=" + MaNV + ",NGAYGIAITRACH='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                            + "where SOHOADON='" + sohoadon + "' and MaNV_DangNgan is null and NGAYGIAITRACH is null and NAM=" + nam + " and KY=" + ky + " and DOT=" + dot + "";
                else
                    if (loai == "Quay")
                        sql = "update HOADON set DangNgan_Quay=1,MaNV_DangNgan=" + MaNV + ",NGAYGIAITRACH='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                                + "where SOHOADON='" + sohoadon + "' and MaNV_DangNgan is null and NGAYGIAITRACH is null and NAM=" + nam + " and KY=" + ky + " and DOT=" + dot + "";
                    else
                        if (loai == "ChuyenKhoan")
                            sql = "update HOADON set DangNgan_ChuyenKhoan=1,MaNV_DangNgan=" + MaNV + ",NGAYGIAITRACH='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                                + "where SOHOADON='" + sohoadon + "' and MaNV_DangNgan is null and NGAYGIAITRACH is null and NAM=" + nam + " and KY=" + ky + " and DOT=" + dot + "";
                return ExecuteNonQuery_Transaction(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaDangNgan(string loai,string sohoadon, int MaNV, int nam, int ky, int dot)
        {
            try
            {
                string sql = "";
                if (loai == "HanhThu")
                    sql = "update HOADON set DangNgan_HanhThu=0,MaNV_DangNgan=null,NGAYGIAITRACH=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                           + "where SOHOADON='" + sohoadon + "' and DangNgan_HanhThu=1 and MaNV_DangNgan=" + MaNV + " and NGAYGIAITRACH is not null and NAM=" + nam + " and KY=" + ky + " and DOT=" + dot + "";
                else
                    if (loai == "Quay")
                        sql = "update HOADON set DangNgan_Quay=0,MaNV_DangNgan=null,NGAYGIAITRACH=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                               + "where SOHOADON='" + sohoadon + "' and DangNgan_Quay=1 and MaNV_DangNgan=" + MaNV + " and NGAYGIAITRACH is not null and NAM=" + nam + " and KY=" + ky + " and DOT=" + dot + "";
                    else
                        if (loai == "ChuyenKhoan")
                            sql = "update HOADON set DangNgan_ChuyenKhoan=0,MaNV_DangNgan=null,NGAYGIAITRACH=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' "
                                   + "where SOHOADON='" + sohoadon + "' and DangNgan_ChuyenKhoan=1 and MaNV_DangNgan=" + MaNV + " and NGAYGIAITRACH is not null and NAM=" + nam + " and KY=" + ky + " and DOT=" + dot + "";
                return ExecuteNonQuery(sql, false);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            } 
        }
    }

}
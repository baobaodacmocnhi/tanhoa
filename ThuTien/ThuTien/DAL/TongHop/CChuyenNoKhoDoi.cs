using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using System.Data;
using ThuTien.DAL.QuanTri;

namespace ThuTien.DAL.TongHop
{
    class CChuyenNoKhoDoi : CDAL
    {
        public bool Them(TT_ChuyenNoKhoDoi cnkd)
        {
            try
            {
                if (_db.TT_ChuyenNoKhoDois.Count() > 0)
                {
                    string ID = "MaCNKD";
                    string Table = "TT_ChuyenNoKhoDoi";
                    decimal MaCNKD = _db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    cnkd.MaCNKD = getMaxNextIDTable(MaCNKD);
                }
                else
                    cnkd.MaCNKD = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                cnkd.CreateDate = DateTime.Now;
                cnkd.CreateBy = CNguoiDung.MaND;
                _db.TT_ChuyenNoKhoDois.InsertOnSubmit(cnkd);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(TT_ChuyenNoKhoDoi cnkd)
        {
            try
            {
                cnkd.ModifyDate = DateTime.Now;
                cnkd.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(decimal MaCNKD)
        {
            try
            {
                string sql = "";
                sql = "delete TT_ChuyenNoKhoDoi where MaCNKD=" + MaCNKD;
                return ExecuteNonQuery_Transaction(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ThemCT(TT_CTChuyenNoKhoDoi ctcnkd)
        {
            try
            {
                ctcnkd.CreateDate = DateTime.Now;
                ctcnkd.CreateBy = CNguoiDung.MaND;
                _db.TT_CTChuyenNoKhoDois.InsertOnSubmit(ctcnkd);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SuaCT(TT_CTChuyenNoKhoDoi ctcnkd)
        {
            try
            {
                ctcnkd.ModifyDate = DateTime.Now;
                ctcnkd.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaCT(TT_CTChuyenNoKhoDoi ctcnkd)
        {
            try
            {
                _db.TT_CTChuyenNoKhoDois.DeleteOnSubmit(ctcnkd);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaCT(string SoHoaDon)
        {
            try
            {
                string sql = "";
                sql = "delete TT_CTChuyenNoKhoDoi where SoHoaDon='" + SoHoaDon + "'";
                return ExecuteNonQuery_Transaction(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExistCT(string SoHoaDon)
        {
            return _db.TT_CTChuyenNoKhoDois.Any(item => item.SoHoaDon == SoHoaDon);
        }

        public TT_ChuyenNoKhoDoi Get(decimal MaCNKD)
        {
            return _db.TT_ChuyenNoKhoDois.SingleOrDefault(item => item.MaCNKD == MaCNKD);
        }

        public TT_CTChuyenNoKhoDoi GetCT(string SoHoaDon)
        {
            return _db.TT_CTChuyenNoKhoDois.SingleOrDefault(item => item.SoHoaDon == SoHoaDon);
        }

        public List<TT_CTChuyenNoKhoDoi> GetDSCT_ChuaLapPhieu(string DanhBo)
        {
            var query = from itemCT in _db.TT_CTChuyenNoKhoDois
                        join itemHD in _db.HOADONs on itemCT.SoHoaDon equals itemHD.SOHOADON
                        where itemHD.DANHBA == DanhBo && itemCT.MaCNKD == null
                        select itemCT;
            return query.ToList();
        }

        public DataTable GetDSCT(decimal MaCNKD)
        {
            var query = from itemCT in _db.TT_CTChuyenNoKhoDois
                        join itemHD in _db.HOADONs on itemCT.SoHoaDon equals itemHD.SOHOADON
                        where itemCT.MaCNKD == MaCNKD
                        select new
                        {
                            itemCT.MaCNKD,
                            itemCT.SoHoaDon,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            itemHD.SOPHATHANH,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSCT()
        {
            var query = from itemCNKD in _db.TT_CTChuyenNoKhoDois
                        join itemHD in _db.HOADONs on itemCNKD.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        select new
                        {
                            itemCNKD.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemCNKD.CreateDate,
                            itemCNKD.MaCNKD,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSCT(DateTime TuNgay)
        {
            var query = from itemCNKD in _db.TT_CTChuyenNoKhoDois
                        join itemHD in _db.HOADONs on itemCNKD.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemCNKD.CreateDate.Value.Date == TuNgay.Date
                        select new
                        {
                            itemCNKD.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemCNKD.CreateDate,
                            itemCNKD.MaCNKD,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSCT(DateTime TuNgay, DateTime DenNgay)
        {
            var query = from itemCNKD in _db.TT_CTChuyenNoKhoDois
                        join itemHD in _db.HOADONs on itemCNKD.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemCNKD.CreateDate.Value.Date >= TuNgay.Date && itemCNKD.CreateDate.Value.Date <= DenNgay.Date
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemCNKD.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DiaChi=itemHD.SO+" "+itemHD.DUONG,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemCNKD.CreateDate,
                            itemCNKD.MaCNKD,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetTongHopDangNgan(string Loai, DateTime CreateDate)
        {
            if (Loai == "TG")
            {
                //var query = from itemCNKD in _db.TT_ChuyenNoKhoDois
                //            join itemHD in _db.HOADONs on itemCNKD.SoHoaDon equals itemHD.SOHOADON
                //            where itemCNKD.CreateDate.Value.Date == CreateDate.Date && itemHD.GB >= 11 && itemHD.GB <= 20
                //            group itemHD by itemHD.ID_HOADON into itemGroup
                //            select new
                //            {
                //                TongHD = itemGroup.Count(),
                //                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                //                TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                //                TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                //            };
                //return LINQToDataTable(query);

                string sql = "select COUNT(a.SoHoaDon) as TongHD,SUM(GIABAN) as TongGiaBan,SUM(THUE) as TongThueGTGT,SUM(PHI) as TongPhiBVMT,SUM(TONGCONG) as TongCong from TT_CTChuyenNoKhoDoi a,HOADON b"
                        + " where a.SoHoaDon=b.SOHOADON and GB>=11 and GB<=20 and CONVERT(varchar(10),a.CreateDate,103)='" + CreateDate.ToString("dd/MM/yyyy") + "'"
                        + " group by CONVERT(varchar(10),a.CreateDate,103)";

                return ExecuteQuery_SqlDataAdapter_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    //var query = from itemCNKD in _db.TT_ChuyenNoKhoDois
                    //            join itemHD in _db.HOADONs on itemCNKD.SoHoaDon equals itemHD.SOHOADON
                    //            where itemCNKD.CreateDate.Value.Date == CreateDate.Date && itemHD.GB > 20
                    //            group itemHD by itemHD.ID_HOADON into itemGroup
                    //            select new
                    //            {
                    //                TongHD = itemGroup.Count(),
                    //                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                    //                TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                    //                TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                    //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                    //            };
                    //return LINQToDataTable(query);

                    string sql = "select COUNT(a.SoHoaDon) as TongHD,SUM(GIABAN) as TongGiaBan,SUM(THUE) as TongThueGTGT,SUM(PHI) as TongPhiBVMT,SUM(TONGCONG) as TongCong from TT_CTChuyenNoKhoDoi a,HOADON b"
                        + " where a.SoHoaDon=b.SOHOADON and GB>20 and CONVERT(varchar(10),a.CreateDate,103)='" + CreateDate.ToString("dd/MM/yyyy") + "'"
                        + " group by CONVERT(varchar(10),a.CreateDate,103)";

                    return ExecuteQuery_SqlDataAdapter_DataTable(sql);
                }
            return null;
        }

        public DataTable GetTongHopDangNganDCHD(string Loai, DateTime CreateDate)
        {
            if (Loai == "TG")
            {
                string sql = "select COUNT(a.SoHoaDon) as TongHD,SUM(GIABAN_DC) as TongGiaBan,SUM(THUE_DC) as TongThueGTGT,SUM(PHI_DC) as TongPhiBVMT,SUM(TONGCONG_DC) as TongCong from TT_CTChuyenNoKhoDoi a,HOADON b,DIEUCHINH_HD dchd"
                        + " where a.SoHoaDon=b.SOHOADON and a.SoHoaDon=dchd.SOHOADON and GB>=11 and GB<=20 and CONVERT(varchar(10),a.CreateDate,103)='" + CreateDate.ToString("dd/MM/yyyy") + "'"
                        + " group by CONVERT(varchar(10),a.CreateDate,103)";

                return ExecuteQuery_SqlDataAdapter_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    string sql = "select COUNT(a.SoHoaDon) as TongHD,SUM(GIABAN_DC) as TongGiaBan,SUM(THUE_DC) as TongThueGTGT,SUM(PHI_DC) as TongPhiBVMT,SUM(TONGCONG_DC) as TongCong from TT_CTChuyenNoKhoDoi a,HOADON b,DIEUCHINH_HD dchd"
                        + " where a.SoHoaDon=b.SOHOADON and a.SoHoaDon=dchd.SOHOADON and GB>20 and CONVERT(varchar(10),a.CreateDate,103)='" + CreateDate.ToString("dd/MM/yyyy") + "'"
                        + " group by CONVERT(varchar(10),a.CreateDate,103)";

                    return ExecuteQuery_SqlDataAdapter_DataTable(sql);
                }
            return null;
        }

        public DataTable GetTongHopDangNgan(DateTime CreateDate)
        {
            //var query = from itemCNKD in _db.TT_ChuyenNoKhoDois
            //            join itemHD in _db.HOADONs on itemCNKD.SoHoaDon equals itemHD.SOHOADON
            //            where itemCNKD.CreateDate.Value.Date == CreateDate.Date
            //            group itemHD by itemHD.ID_HOADON into itemGroup
            //            select new
            //            {
            //                TongHD = itemGroup.Count(),
            //                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
            //                TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
            //                TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
            //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
            //            };
            //return LINQToDataTable(query);

            string sql = "select COUNT(a.SoHoaDon) as TongHD,SUM(GIABAN) as TongGiaBan,SUM(THUE) as TongThueGTGT,SUM(PHI) as TongPhiBVMT,SUM(TONGCONG) as TongCong from TT_CTChuyenNoKhoDoi a,HOADON b"
                        + " where a.SoHoaDon=b.SOHOADON and CONVERT(varchar(10),a.CreateDate,103)='" + CreateDate.ToString("dd/MM/yyyy") + "'"
                        + " group by CONVERT(varchar(10),a.CreateDate,103)";

            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetTongHopDangNganDCHD(DateTime CreateDate)
        {
            string sql = "select COUNT(a.SoHoaDon) as TongHD,SUM(GIABAN_DC) as TongGiaBan,SUM(THUE_DC) as TongThueGTGT,SUM(PHI_DC) as TongPhiBVMT,SUM(TONGCONG_DC) as TongCong from TT_CTChuyenNoKhoDoi a,DIEUCHINH_HD b"
                        + " where a.SoHoaDon=b.SOHOADON and CONVERT(varchar(10),a.CreateDate,103)='" + CreateDate.ToString("dd/MM/yyyy") + "'"
                        + " group by CONVERT(varchar(10),a.CreateDate,103)";

            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public int CountCT(decimal MaCNKD)
        {
            return _db.TT_CTChuyenNoKhoDois.Count(item => item.MaCNKD == MaCNKD);
        }

        public int CountCT(string Loai, int Nam,int Ky)
        {
            if (Loai == "TG")
            {
                var query = from itemCNKD in _db.TT_CTChuyenNoKhoDois
                            join itemHD in _db.HOADONs on itemCNKD.SoHoaDon equals itemHD.SOHOADON
                            where itemHD.GB<=20 && itemCNKD.CreateDate.Value.Year == Nam && itemCNKD.CreateDate.Value.Month == Ky
                            select new
                            {
                                itemCNKD.SoHoaDon,
                            };
                return query.Count();
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemCNKD in _db.TT_CTChuyenNoKhoDois
                                join itemHD in _db.HOADONs on itemCNKD.SoHoaDon equals itemHD.SOHOADON
                                where itemHD.GB > 20 && itemCNKD.CreateDate.Value.Year == Nam && itemCNKD.CreateDate.Value.Month == Ky
                                select new
                                {
                                    itemCNKD.SoHoaDon,
                                };
                    return query.Count();
                }
            return 0;
        }

        public int CountCT(string Loai,int MaTo, int Nam,int Ky)
        {
            if (Loai == "TG")
            {
                var query = from itemCNKD in _db.TT_CTChuyenNoKhoDois
                            join itemHD in _db.HOADONs on itemCNKD.SoHoaDon equals itemHD.SOHOADON
                            where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                && itemHD.GB <= 20 && itemCNKD.CreateDate.Value.Year == Nam && itemCNKD.CreateDate.Value.Month == Ky
                            select new
                            {
                                itemCNKD.SoHoaDon,
                            };
                return query.Count();
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemCNKD in _db.TT_CTChuyenNoKhoDois
                                join itemHD in _db.HOADONs on itemCNKD.SoHoaDon equals itemHD.SOHOADON
                                where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                    && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                                    && itemHD.GB > 20 && itemCNKD.CreateDate.Value.Year == Nam && itemCNKD.CreateDate.Value.Month == Ky
                                select new
                                {
                                    itemCNKD.SoHoaDon,
                                };
                    return query.Count();
                }
            return 0;
        }

        dbKTKS_DonKHDataContext _dbKTKS_DonKH = new dbKTKS_DonKHDataContext();

        public YeuCauCHDB GetYeuCauCHDB(decimal MaYCCHDB)
        {
            return _dbKTKS_DonKH.YeuCauCHDBs.SingleOrDefault(item => item.MaYCCHDB == MaYCCHDB);
        }
    }
}

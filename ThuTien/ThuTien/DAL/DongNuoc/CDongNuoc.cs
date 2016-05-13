using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;
using System.Globalization;

namespace ThuTien.DAL.DongNuoc
{
    class CDongNuoc : CDAL
    {
        public void Refresh(TT_CTDongNuoc ctdongnuoc)
        {
            _db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, ctdongnuoc);
        }

        public bool ThemDN(TT_DongNuoc dongnuoc)
        {
            try
            {
                if (_db.TT_DongNuocs.Count() > 0)
                {
                    string ID = "MaDN";
                    string Table = "TT_DongNuoc";
                    decimal MaDN = _db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    //decimal MaCHDB = db.CHDBs.Max(itemCHDB => itemCHDB.MaCHDB);
                    dongnuoc.MaDN = getMaxNextIDTable(MaDN);
                }
                else
                    dongnuoc.MaDN = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                dongnuoc.CreateDate = DateTime.Now;
                dongnuoc.CreateBy = CNguoiDung.MaND;
                _db.TT_DongNuocs.InsertOnSubmit(dongnuoc);
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

        public bool SuaDN(TT_DongNuoc dongnuoc)
        {
            try
            {
                dongnuoc.ModifyDate = DateTime.Now;
                dongnuoc.ModifyBy = CNguoiDung.MaND;
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

        public bool ThemKQ(TT_KQDongNuoc kqdongnuoc)
        {
            try
            {
                if (_db.TT_KQDongNuocs.Count() > 0)
                    kqdongnuoc.MaKQDN = _db.TT_KQDongNuocs.Max(item => item.MaKQDN) + 1;
                else
                    kqdongnuoc.MaKQDN = 1;
                kqdongnuoc.CreateDate = DateTime.Now;
                kqdongnuoc.CreateBy = CNguoiDung.MaND;
                _db.TT_KQDongNuocs.InsertOnSubmit(kqdongnuoc);
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

        public bool SuaKQ(TT_KQDongNuoc kqdongnuoc)
        {
            try
            {
                kqdongnuoc.ModifyDate = DateTime.Now;
                kqdongnuoc.ModifyBy = CNguoiDung.MaND;
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

        public bool GiaoDongNuoc(decimal MaDN,int MaNV_DongNuoc)
        {
            try
            {
                string sql = "update TT_DongNuoc set MaNV_DongNuoc=" + MaNV_DongNuoc + ",NgayGiao='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' where MaDN=" + MaDN;
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaGiaoDongNuoc(decimal MaDN)
        {
            try
            {
                string sql = "update TT_DongNuoc set MaNV_DongNuoc=null,NgayGiao=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' where MaDN=" + MaDN;
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(decimal MaDN)
        {
            try
            {
                string sql = "";
                sql = "delete TT_CTDongNuoc where MaDN=" + MaDN;
                sql += " delete TT_DongNuoc where MaDN=" + MaDN;
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaKQ(TT_KQDongNuoc kqdongnuoc)
        {
            try
            {
                _db.TT_KQDongNuocs.DeleteOnSubmit(kqdongnuoc);
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

        /// <summary>
        /// Lấy Danh Sách Thông Báo Đóng Nước chưa bị Hủy
        /// </summary>
        /// <param name="MaNV"></param>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataSet GetDSByMaNVCreateDates(string TenTo, int MaNV, DateTime TuNgay, DateTime DenNgay)
        {
            DataSet ds = new DataSet();

            var queryDN = from itemDN in _db.TT_DongNuocs
                          where itemDN.Huy == false && itemDN.CreateBy == MaNV && itemDN.CreateDate.Value.Date >= TuNgay.Date && itemDN.CreateDate.Value.Date <= DenNgay.Date
                          orderby itemDN.MLT ascending
                          select new
                            {
                                In = false,
                                TenTo,
                                itemDN.MaDN,
                                itemDN.DanhBo,
                                itemDN.HoTen,
                                itemDN.DiaChi,
                                TongCong = itemDN.TT_CTDongNuocs.Sum(item => item.TongCong),
                                itemDN.MLT,
                                itemDN.CreateBy,
                                //NgayGiaiTrach = itemDN.TT_CTDongNuocs.FirstOrDefault().HOADON.NGAYGIAITRACH,
                                NgayGiaiTrach = _db.HOADONs.SingleOrDefault(itemHD=>itemHD.SOHOADON == itemDN.TT_CTDongNuocs.FirstOrDefault().SoHoaDon).NGAYGIAITRACH,
                                itemDN.MaNV_DongNuoc,
                                itemDN.CreateDate,
                                TinhTrang = "",///Phải thêm để GridView lấy cột để edit lại sau
                            };
            DataTable dtDongNuoc = new DataTable();
            dtDongNuoc = LINQToDataTable(queryDN);
            dtDongNuoc.TableName = "DongNuoc";
            ds.Tables.Add(dtDongNuoc);

            var queryCTDN = from itemCTDN in _db.TT_CTDongNuocs
                            join itemDN in _db.TT_DongNuocs on itemCTDN.MaDN equals itemDN.MaDN
                            join itemHD in _db.HOADONs on itemCTDN.MaHD equals itemHD.ID_HOADON //into tableHD
                            //from itemtableHD in tableHD.DefaultIfEmpty()
                            where itemDN.Huy == false && itemDN.CreateBy == MaNV && itemDN.CreateDate.Value.Date >= TuNgay.Date && itemDN.CreateDate.Value.Date <= DenNgay.Date
                            select new
                            {
                                itemCTDN.MaDN,
                                itemCTDN.SoHoaDon,
                                itemCTDN.Ky,
                                itemCTDN.TieuThu,
                                itemCTDN.GiaBan,
                                itemCTDN.ThueGTGT,
                                itemCTDN.PhiBVMT,
                                itemCTDN.TongCong,
                                NgayGiaiTrach=itemHD.NGAYGIAITRACH,
                            };
            DataTable dtCTDongNuoc = new DataTable();
            dtCTDongNuoc = LINQToDataTable(queryCTDN);
            dtCTDongNuoc.TableName = "CTDongNuoc";
            ds.Tables.Add(dtCTDongNuoc);

            if (dtDongNuoc.Rows.Count > 0 && dtCTDongNuoc.Rows.Count > 0)
                ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["DongNuoc"].Columns["MaDN"], ds.Tables["CTDongNuoc"].Columns["MaDN"]);

            return ds;
        }

        public DataTable GetDSCTDongNuocTon(int MaTo, DateTime NgayKiemTra)
        {
            var query = from itemCT in _db.TT_CTDongNuocs
                        join itemDN in _db.TT_DongNuocs on itemCT.MaDN equals itemDN.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemDN.MaNV_DongNuoc equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemCT.TT_DongNuoc.MaNV_DongNuoc != null && itemtableND.MaTo == MaTo
                        && (itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayKiemTra.Date)
                        select new
                        {
                            itemCT.MaDN,
                            itemCT.TT_DongNuoc.HoTen,
                            itemCT.TT_DongNuoc.DiaChi,
                            itemCT.TT_DongNuoc.DanhBo,
                            itemCT.TT_DongNuoc.MLT,
                            itemHD.SOHOADON,
                            itemCT.Ky,
                            itemCT.TongCong,
                            itemtableND.TT_To.TenTo,
                            NhanVien = itemtableND.HoTen,
                        };

            return LINQToDataTable(query.Distinct());
        }

        public DataTable GetDSKQDongNuocByNgayDNs(DateTime FromNgayDN, DateTime ToNgayDN)
        {
            return LINQToDataTable(_db.TT_KQDongNuocs.Where(item => item.NgayDN.Value.Date >= FromNgayDN.Date && item.NgayDN.Value.Date <= ToNgayDN.Date).ToList());
        }

        public DataTable GetDSKQDongNuocByMaToNgayDNs(int MaTo, DateTime FromNgayDN, DateTime ToNgayDN)
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        where itemKQ.NgayDN.Value.Date >= FromNgayDN.Date && itemKQ.NgayDN.Value.Date <= ToNgayDN.Date
                                && Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        select itemKQ;
            return LINQToDataTable(query.Distinct());
        }

        public DataTable GetDSKQDongNuocByMaNVNgayDNs(int MaNV, DateTime FromNgayDN, DateTime ToNgayDN)
        {
            return LINQToDataTable(_db.TT_KQDongNuocs.Where(item => item.CreateBy == MaNV && item.NgayDN.Value.Date >= FromNgayDN.Date && item.NgayDN.Value.Date <= ToNgayDN.Date).ToList());
        }

        public DataTable BaoCaoVatTu(DateTime FromNgayDN, DateTime ToNgayDN)
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemND in _db.TT_NguoiDungs on itemKQ.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemKQ.NgayDN.Value.Date >= FromNgayDN.Date && itemKQ.NgayDN.Value.Date <= ToNgayDN.Date
                        orderby itemKQ.NgayDN ascending
                        select new
                        {
                            itemKQ.DanhBo,
                            itemKQ.HoTen,
                            itemKQ.DiaChi,
                            itemKQ.Hieu,
                            itemKQ.Co,
                            itemKQ.ChiSoDN,
                            itemKQ.NgayDN,
                            NhanVien = itemtableND.HoTen,
                            To=itemtableND.MaTo,

                        };
            return LINQToDataTable(query.Distinct());
        }

        public List<TT_KQDongNuoc> GetDSKQDongNuocBySoPhieuDN(decimal SoPhieuDN)
        {
            return _db.TT_KQDongNuocs.Where(item => item.SoPhieuDN == SoPhieuDN).ToList();
        }

        public List<TT_KQDongNuoc> GetDSKQDongNuocBySoPhieuMN(decimal SoPhieuMN)
        {
            return _db.TT_KQDongNuocs.Where(item => item.SoPhieuMN == SoPhieuMN).ToList();
        }

        public List<TT_KQDongNuoc> GetDSSoPhieuDN()
        {
            return _db.TT_KQDongNuocs.Where(item => item.SoPhieuDN != null).GroupBy(item => item.SoPhieuDN).Select(group => group.First()).OrderByDescending(item=>item.NgaySoPhieuDN).ToList();
        }

        public List<TT_KQDongNuoc> GetDSSoPhieuMN()
        {
            return _db.TT_KQDongNuocs.Where(item => item.SoPhieuMN != null).GroupBy(item => item.SoPhieuMN).Select(group => group.First()).OrderByDescending(item => item.NgaySoPhieuMN).ToList();
        }
        
        public DataTable GetDSKQDongMoNuocByDanhBo(string DanhBo)
        {
            return LINQToDataTable(_db.TT_KQDongNuocs.Where(item =>item.DanhBo==DanhBo).ToList());
        }

        public DataTable GetDSKQMoNuocByDates(DateTime TuNgay, DateTime DenNgay)
        {
            return LINQToDataTable(_db.TT_KQDongNuocs.Where(item => item.NgayMN.Value.Date >= TuNgay.Date && item.NgayMN.Value.Date <= DenNgay.Date).ToList());
        }

        public DataTable GetDSKQMoNuocByMaToDates(int MaTo, DateTime TuNgay, DateTime DenNgay)
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        where itemKQ.NgayMN.Value.Date >= TuNgay.Date && itemKQ.NgayMN.Value.Date <= DenNgay.Date
                                && Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        select itemKQ;
            return LINQToDataTable(query.Distinct());
        }

        public DataTable GetDSKQMoNuocByMaNVDates(int MaNV, DateTime TuNgay, DateTime DenNgay)
        {
            return LINQToDataTable(_db.TT_KQDongNuocs.Where(item => item.CreateBy == MaNV && item.NgayMN.Value.Date >= TuNgay.Date && item.NgayMN.Value.Date <= DenNgay.Date).ToList());
        }

        public DataTable GetDSCanMoNuoc()
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemKQ.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.NGAYGIAITRACH != null && itemKQ.NgayDN != null && itemKQ.NgayMN == null && itemHD.ChuyenNoKhoDoi == false
                        select new
                        {
                            itemKQ.MaKQDN,
                            itemKQ.MaDN,
                            itemKQ.CreateDate,
                            itemKQ.DanhBo,
                            itemKQ.HoTen,
                            itemKQ.DiaChi,
                            itemKQ.NgayDN,
                            itemHD.NGAYGIAITRACH,
                            itemKQ.GhiChuTroNgai,
                            itemKQ.TroNgaiMN,
                            MaNV_DongNuoc=itemtableND.HoTen,
                        };
            return LINQToDataTable(query.GroupBy(item => item.MaDN).Select(item => item.First()).ToList());
        }

        public DataTable GetDSCanMoNuoc(int MaTo)
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemKQ.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.NGAYGIAITRACH != null && itemKQ.NgayDN != null && itemKQ.NgayMN == null && itemHD.ChuyenNoKhoDoi == false
                                && Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        select new
                        {
                            itemKQ.MaKQDN,
                            itemKQ.MaDN,
                            itemKQ.CreateDate,
                            itemKQ.DanhBo,
                            itemKQ.HoTen,
                            itemKQ.DiaChi,
                            itemKQ.NgayDN,
                            itemHD.NGAYGIAITRACH,
                            itemKQ.GhiChuTroNgai,
                            itemKQ.TroNgaiMN,
                            MaNV_DongNuoc = itemtableND.HoTen,
                        };
            return LINQToDataTable(query.GroupBy(item=>item.MaDN).Select(item=>item.First()).ToList());
        }

        public DataTable GetDSKQDongNuoc(bool DongPhi,string DanhBo)
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        where itemKQ.DongPhi == DongPhi && itemKQ.NgayDN != null && itemKQ.NgayMN == null && itemHD.ChuyenNoKhoDoi == false && itemKQ.DanhBo.Contains(DanhBo)
                        select new
                        {
                            itemKQ.MaDN,
                            itemKQ.MaKQDN,
                            itemKQ.CreateDate,
                            itemKQ.DanhBo,
                            itemKQ.HoTen,
                            itemKQ.DiaChi,
                            itemKQ.NgayDN,
                            itemKQ.DongPhi,
                            itemKQ.NgayDongPhi,
                            itemKQ.ChuyenKhoan,
                            itemHD.NGAYGIAITRACH,
                        };
            return LINQToDataTable(query.GroupBy(item => item.MaDN).Select(item => item.First()).ToList());
        }

        public DataTable GetBaoCaoTongHop(int MaTo,DateTime FromDate, DateTime ToDate)
        {
            string sql = "declare @FromDate date;"
                        + " declare @ToDate date;"
                        + " set @FromDate='" + FromDate.ToString("yyyy-MM-dd") + "';"
                        + " set @ToDate='" + ToDate.ToString("yyyy-MM-dd") + "';"
                        + " select nd.MaND as MaNV,nd.HoTen,nd.STT,toncu.DCTonCu,toncu.HDTonCu,toncu.TCTonCu,nhan.DCNhan,nhan.HDNhan,nhan.TCNhan"
                        + ",dangngan.DCDangNgan,dangngan.HDDangNgan,dangngan.TCDangNgan,lenhhuy.DCHuy,lenhhuy.HDHuy,lenhhuy.TCHuy,tongton.DCTongTon,tongton.HDTongTon,tongton.TCTongTon,khoanuoc.DCKhoaNuoc from"
                        + " (select MaND,HoTen,STT from TT_NguoiDung where DongNuoc=1 and MaTo="+MaTo+") nd"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(DISTINCT DanhBo) as DCTonCu,COUNT(hd.SOHOADON) as HDTonCu,SUM(hd.TONGCONG) as TCTonCu"
                        + " from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0"
                        + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        + " and CAST(dn.CreateDate as date)<@FromDate and (hd.NGAYGIAITRACH is null or (CAST(hd.NGAYGIAITRACH as date)>@FromDate))"
                        + " group by nd.MaND,nd.HoTen,nd.STT) toncu on nd.MaND=toncu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(DISTINCT DanhBo) as DCNhan,COUNT(hd.SOHOADON) as HDNhan,SUM(hd.TONGCONG) as TCNhan"
                        + " from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0"
                        + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        + " and CAST(dn.CreateDate as date)>=@FromDate and CAST(dn.CreateDate as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) nhan on nd.MaND=nhan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(DISTINCT DanhBo) as DCDangNgan,COUNT(hd.SOHOADON) as HDDangNgan,SUM(hd.TONGCONG) as TCDangNgan"
                        + " from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0"
                        + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        + " and CAST(NGAYGIAITRACH as date)>=@FromDate and CAST(NGAYGIAITRACH as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) dangngan on nd.MaND=dangngan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(DISTINCT DanhBo) as DCHuy,COUNT(hd.SOHOADON) as HDHuy,SUM(hd.TONGCONG) as TCHuy"
                        + " from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_LenhHuy lenhhuy,TT_NguoiDung nd"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and lenhhuy.MaHD=hd.ID_HOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0"
                        + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        + " and CAST(lenhhuy.CreateDate as date)>=@FromDate and CAST(lenhhuy.CreateDate as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) lenhhuy on nd.MaND=lenhhuy.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(DISTINCT DanhBo) as DCTongTon,COUNT(hd.SOHOADON) as HDTongTon,SUM(hd.TONGCONG) as TCTongTon"
                        + " from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0"
                        + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        + " and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@ToDate) and ctdn.SoHoaDon not in (select SoHoaDon from TT_LenhHuy)"
                        + " group by nd.MaND,nd.HoTen,nd.STT) tongton on nd.MaND=tongton.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(DISTINCT kqdn.DanhBo) as DCKhoaNuoc"
                        + " from TT_DongNuoc dn,TT_CTDongNuoc ctdn,TT_KQDongNuoc kqdn,HOADON hd,TT_NguoiDung nd"
                        + " where dn.MaDN=ctdn.MaDN and dn.MaDN=kqdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0"
                        + " and MAY>=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS + " and MAY<=" + _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        + " and CAST(kqdn.NgayDN as date)>=@FromDate and CAST(kqdn.NgayDN as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) khoanuoc on nd.MaND=khoanuoc.MaND"
                        + " order by nd.STT asc";

            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public bool CheckHuyLenh(decimal MaDN)
        {
            return _db.TT_DongNuocs.Any(item => item.MaDN == MaDN && item.Huy == true);
        }

        /// <summary>
        /// Kiểm tra lệnh đóng nước của hóa đơn có được đăng ngân chưa, nếu đăng ngân tất cả rồi thì không có nhập Kết Quả Đóng Nước. 1 hóa đơn còn tồn vẫn cho Nhập
        /// </summary>
        /// <param name="MaDN"></param>
        /// <returns></returns>
        public bool CheckDangNgan(decimal MaDN)
        {
            //return _db.TT_CTDongNuocs.Any(item => item.MaDN == MaDN && item.HOADON.NGAYGIAITRACH != null);
            foreach (TT_CTDongNuoc item in _db.TT_CTDongNuocs.Where(item => item.MaDN == MaDN))
                if (_db.HOADONs.FirstOrDefault(itemHD=>itemHD.ID_HOADON==item.MaHD).NGAYGIAITRACH == null)
                    return false;
            return true;
        }

        /// <summary>
        /// Kiểm tra thông báo đóng nước có được giao cho nhân viên hay không
        /// </summary>
        /// <param name="MaDN"></param>
        /// <param name="MaNV_DongNuoc"></param>
        /// <returns></returns>
        public bool CheckExist_DongNuoc(decimal MaDN, int MaNV_DongNuoc)
        {
            return _db.TT_DongNuocs.Any(item => item.MaDN == MaDN && item.MaNV_DongNuoc == MaNV_DongNuoc);
        }

        public bool CheckExist_DongNuoc(decimal MaDN)
        {
            return _db.TT_DongNuocs.Any(item => item.MaDN == MaDN);
        }

        public bool CheckExist_KQDongNuoc(decimal MaDN)
        {
            return _db.TT_KQDongNuocs.Any(item => item.MaDN == MaDN);
        }

        public bool CheckExist_KQDongNuoc(decimal MaDN, DateTime NgayDN)
        {
            return _db.TT_KQDongNuocs.Any(item => item.MaDN == MaDN && item.CreateDate.Value.Date <= NgayDN.Date);
        }

        /// <summary>
        /// Kiểm tra nhân viên có đi đóng nước thông báo được giao hay chưa
        /// </summary>
        /// <param name="MaDN"></param>
        /// <param name="MaNV_DongNuoc"></param>
        /// <returns></returns>
        public bool CheckExist_KQDongNuoc(decimal MaDN, int MaNV_DongNuoc)
        {
            return _db.TT_KQDongNuocs.Any(item => item.MaDN == MaDN && item.CreateBy == MaNV_DongNuoc);
        }

        public bool CheckExist_KQDongNuocLan2(string SoHoaDon)
        {
            if (CheckExist_CTDongNuoc(SoHoaDon))
            {
                if (_db.TT_CTDongNuocs.SingleOrDefault(item => item.MaHD == _db.HOADONs.SingleOrDefault(itemHD => itemHD.SOHOADON == SoHoaDon).ID_HOADON && item.TT_DongNuoc.Huy == false).TT_DongNuoc.TT_KQDongNuocs.Count > 0)
                    return _db.TT_CTDongNuocs.SingleOrDefault(item => item.MaHD == _db.HOADONs.SingleOrDefault(itemHD => itemHD.SOHOADON == SoHoaDon).ID_HOADON && item.TT_DongNuoc.Huy == false).TT_DongNuoc.TT_KQDongNuocs.SingleOrDefault().DongNuoc2;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// Kiểm tra Số Hóa Đơn có lập Thông Báo chưa. Nếu Thông Báo trước đó bị hủy thì vẫn được lập cái mới
        /// </summary>
        /// <param name="SoHoaDon"></param>
        /// <returns></returns>
        public bool CheckExist_CTDongNuoc(string SoHoaDon)
        {
            if (_db.HOADONs.Any(itemHD => itemHD.SOHOADON == SoHoaDon))
                return _db.TT_CTDongNuocs.Any(item => item.MaHD == _db.HOADONs.SingleOrDefault(itemHD => itemHD.SOHOADON == SoHoaDon).ID_HOADON && item.TT_DongNuoc.Huy == false);
            else
                return false;
        }

        /// <summary>
        /// Kiểm tra Tồn Tại & Lấy Tên Nhân Viên, Tên Tổ theo Số Hóa Đơn. Phục vụ cho Tạm Thu
        /// </summary>
        /// <param name="SoHoaDon"></param>
        /// <param name="HoTen"></param>
        /// <param name="TenTo"></param>
        /// <returns></returns>
        public bool CheckExist_CTDongNuoc(string SoHoaDon, out string HoTen, out string TenTo)
        {
            HoTen = "";
            TenTo = "";
            var query = from itemDN in _db.TT_DongNuocs
                        join itemND in _db.TT_NguoiDungs on itemDN.MaNV_DongNuoc equals itemND.MaND
                        join itemCTDN in _db.TT_CTDongNuocs on itemDN.MaDN equals itemCTDN.MaDN
                        where itemCTDN.MaHD == _db.HOADONs.SingleOrDefault(itemHD => itemHD.SOHOADON == SoHoaDon).ID_HOADON && itemDN.Huy == false
                        select new
                        {
                            itemND.HoTen,
                            itemND.TT_To.TenTo,
                        };
            if (query.Count() > 0)
            {
                HoTen = query.Take(1).ToList()[0].HoTen;
                TenTo = query.Take(1).ToList()[0].TenTo;
                return true;
            }
            else
                return false;
        }

        public TT_DongNuoc GetDongNuocByMaDN(decimal MaDN)
        {
            return _db.TT_DongNuocs.SingleOrDefault(item => item.MaDN == MaDN);
        }

        public TT_KQDongNuoc GetKQDongNuocByMaKQDN(int MaKQDN)
        {
            return _db.TT_KQDongNuocs.SingleOrDefault(item => item.MaKQDN == MaKQDN);
        }

        public TT_KQDongNuoc GetKQDongNuocByMaDN(decimal MaDN)
        {
            return _db.TT_KQDongNuocs.SingleOrDefault(item => item.MaDN == MaDN);
        }

        public TT_KQDongNuoc GetKQDongNuocByDanhBo(string DanhBo)
        {
            return _db.TT_KQDongNuocs.SingleOrDefault(item => item.DanhBo == DanhBo && item.TT_DongNuoc.Huy==false);
        }

        public string GetNgayDNBySoHoaDon(string SoHoaDon)
        {
            var query = from itemDN in _db.TT_DongNuocs
                        join itemCTDN in _db.TT_CTDongNuocs on itemDN.MaDN equals itemCTDN.MaDN
                        join itemKQDN in _db.TT_KQDongNuocs on itemDN.MaDN equals itemKQDN.MaDN
                        where itemCTDN.MaHD == _db.HOADONs.SingleOrDefault(itemHD => itemHD.SOHOADON == SoHoaDon).ID_HOADON && itemKQDN.NgayDN != null && itemDN.Huy == false
                        select new
                        {
                            NgayDN = itemKQDN.NgayDN
                        };
            if (query.Count() > 0)
                return query.Take(1).ToList()[0].NgayDN.Value.ToString("dd/MM/yyyy");
            else
                return "";
        }

        public int GetPhiMoNuoc()
        {
            return _db.TT_CacLoaiPhis.FirstOrDefault().PhiMoNuoc.Value;
        }

        public decimal GetNextSoPhieuDN()
        {
            if (_db.TT_KQDongNuocs.Max(item => item.SoPhieuDN) == null)
                return decimal.Parse("1" + DateTime.Now.ToString("yy"));
            else
            {
                string ID = "SoPhieuDN";
                string Table = "TT_KQDongNuoc";
                decimal SoPhieu = _db.ExecuteQuery<decimal>("declare @Ma int " +
                    "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                    "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                return getMaxNextIDTable(SoPhieu);
            }
        }

        public decimal GetNextSoPhieuMN()
        {
            if (_db.TT_KQDongNuocs.Max(item => item.SoPhieuMN) == null)
                return decimal.Parse("1" + DateTime.Now.ToString("yy"));
            else
            {
                string ID = "SoPhieuMN";
                string Table = "TT_KQDongNuoc";
                decimal SoPhieu = _db.ExecuteQuery<decimal>("declare @Ma int " +
                    "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                    "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                return getMaxNextIDTable(SoPhieu);
            }
        }

        public string GetNgayDongNuoc(string SoHoaDon)
        {
            if (_db.TT_KQDongNuocs.Any(item => item.TT_DongNuoc.TT_CTDongNuocs.Any(itemCTDN => itemCTDN.MaHD == _db.HOADONs.SingleOrDefault(itemHD => itemHD.SOHOADON == SoHoaDon).ID_HOADON) == true && item.NgayDN != null) == true)
                return _db.TT_KQDongNuocs.SingleOrDefault(item => item.TT_DongNuoc.TT_CTDongNuocs.Any(itemCTDN => itemCTDN.MaHD == _db.HOADONs.SingleOrDefault(itemHD => itemHD.SOHOADON == SoHoaDon).ID_HOADON) == true && item.NgayDN != null).NgayDN.Value.ToString("dd/MM/yyyy");
            return "";
        }

        //public DataTable GetTongDongNuoc(int MaNV, DateTime TuNgay, DateTime DenNgay)
        //{

        //    var queryDN = from itemDN in _db.TT_DongNuocs
        //                  where itemDN.Huy == false && itemDN.CreateBy == MaNV && itemDN.CreateDate.Value.Date >= TuNgay.Date && itemDN.CreateDate.Value.Date <= DenNgay.Date
        //                  select new
        //                  {
                              
        //                  };
        //}
    }
}

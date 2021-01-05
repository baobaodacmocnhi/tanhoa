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
                Refresh();
                throw ex;
            }
        }

        public bool ThemDN(TT_DongNuoc dongnuoc, int CreateBy)
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
                dongnuoc.CreateBy = CreateBy;
                _db.TT_DongNuocs.InsertOnSubmit(dongnuoc);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
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
                Refresh();
                throw ex;
            }
        }

        public bool XoaCT(TT_CTDongNuoc en)
        {
            try
            {
                _db.TT_CTDongNuocs.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
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
                Refresh();
                throw ex;
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
                Refresh();
                throw ex;
            }
        }

        public bool ThemKQ_Hinh(TT_KQDongNuoc_Hinh en)
        {
            try
            {
                if (_db.TT_KQDongNuoc_Hinhs.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = _db.TT_KQDongNuoc_Hinhs.Max(item => item.ID) + 1;
                en.CreateDate = DateTime.Now;
                en.CreateBy = CNguoiDung.MaND;
                _db.TT_KQDongNuoc_Hinhs.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool XoaKQ_Hinh(TT_KQDongNuoc_Hinh en)
        {
            try
            {
                _db.TT_KQDongNuoc_Hinhs.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool GiaoDongNuoc(decimal MaDN, int MaNV_DongNuoc)
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
                _db.TT_KQDongNuoc_Hinhs.DeleteAllOnSubmit(kqdongnuoc.TT_KQDongNuoc_Hinhs.ToList());
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
        public DataSet GetDSByCreateByCreateDates(string TenTo, int CreateBy, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            DataSet ds = new DataSet();

            var queryDN = from itemDN in _db.TT_DongNuocs
                          join itemND1 in _db.TT_NguoiDungs on itemDN.CreateBy equals itemND1.MaND into tableND1
                          from itemtableND1 in tableND1.DefaultIfEmpty()
                          join itemND2 in _db.TT_NguoiDungs on itemDN.MaNV_DongNuoc equals itemND2.MaND into tableND2
                          from itemtableND2 in tableND2.DefaultIfEmpty()
                          where itemDN.Huy == false && itemDN.CreateBy == CreateBy && itemDN.CreateDate.Value.Date >= FromCreateDate.Date && itemDN.CreateDate.Value.Date <= ToCreateDate.Date
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
                                itemDN.ThemHoaDon,
                                HanhThu = itemtableND1.HoTen,
                                //NgayGiaiTrach = itemDN.TT_CTDongNuocs.FirstOrDefault().HOADON.NGAYGIAITRACH,
                                NgayGiaiTrach = _db.HOADONs.SingleOrDefault(itemHD => itemHD.SOHOADON == itemDN.TT_CTDongNuocs.FirstOrDefault().SoHoaDon).NGAYGIAITRACH,
                                itemDN.MaNV_DongNuoc,
                                HoTen_DongNuoc = itemtableND2.HoTen,
                                itemDN.CreateDate,
                                TinhTrang = "",//Phải thêm để GridView lấy cột để edit lại sau
                                TongCongLenh = itemDN.TT_CTDongNuocs.Sum(item => item.TongCong),
                            };
            DataTable dtDongNuoc = new DataTable();
            dtDongNuoc = LINQToDataTable(queryDN);
            dtDongNuoc.TableName = "DongNuoc";
            ds.Tables.Add(dtDongNuoc);

            var queryCTDN = from itemCTDN in _db.TT_CTDongNuocs
                            join itemDN in _db.TT_DongNuocs on itemCTDN.MaDN equals itemDN.MaDN
                            join itemHD in _db.HOADONs on itemCTDN.MaHD equals itemHD.ID_HOADON //into tableHD
                            //from itemtableHD in tableHD.DefaultIfEmpty()
                            where itemDN.Huy == false && itemDN.CreateBy == CreateBy && itemDN.CreateDate.Value.Date >= FromCreateDate.Date && itemDN.CreateDate.Value.Date <= ToCreateDate.Date
                            select new
                            {
                                itemCTDN.MaDN,
                                itemCTDN.MaHD,
                                itemCTDN.SoHoaDon,
                                itemCTDN.Ky,
                                itemCTDN.TieuThu,
                                itemCTDN.GiaBan,
                                itemCTDN.ThueGTGT,
                                itemCTDN.PhiBVMT,
                                itemCTDN.TongCong,
                                NgayGiaiTrach = itemHD.NGAYGIAITRACH,
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

        public DataTable GetDSCTDongNuocTon(int MaTo)
        {
            var query = from itemCT in _db.TT_CTDongNuocs
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                           && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                           && itemHD.NGAYGIAITRACH == null
                        select new
                        {
                            DanhBo = itemHD.DANHBA,
                        };
            return LINQToDataTable(query.Distinct());
        }

        public DataTable getDS_KQDongNuoc(DateTime FromNgayDN, DateTime ToNgayDN)
        {
            //var query = from item in _db.TT_KQDongNuocs
            //            where (item.NgayDN.Value.Date >= FromNgayDN.Date && item.NgayDN.Value.Date <= ToNgayDN.Date) || (item.NgayDN1.Value.Date >= FromNgayDN.Date && item.NgayDN1.Value.Date <= ToNgayDN.Date)
            //            select new
            //            {
            //                item.MaKQDN,
            //                item.DanhBo,
            //                item.HopDong,
            //                item.HoTen,
            //                item.DiaChi,
            //                item.MLT,
            //                item.DongNuoc,
            //                item.NgayDN,
            //                item.Hieu,
            //                item.Co,
            //                item.SoThan,
            //                item.ChiSoDN,
            //                item.NiemChi,
            //                item.ChiMatSo,
            //                item.ChiKhoaGoc,
            //                item.LyDo,
            //                item.GhiChu,
            //                item.DongNuoc2,
            //                item.NgayDN1,
            //                item.ChiSoDN1,
            //                item.NiemChi1,
            //                item.SoPhieuDN,
            //                item.MoNuoc,
            //                item.NgayMN,
            //                item.ChiSoMN,
            //                item.GhiChuMN,
            //                item.SoPhieuMN,
            //                item.DongPhi,
            //                item.MaDN,
            //                item.DaKy,
            //                item.NgayKy,
            //                item.Duyet,
            //            };
            //return LINQToDataTable(query);
            DataTable dt = new DataTable();
            var query = from item in _db.TT_KQDongNuocs
                        join itemND in _db.TT_NguoiDungs on item.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where (item.NgayDN.Value.Date >= FromNgayDN.Date && item.NgayDN.Value.Date <= ToNgayDN.Date)
                        select new
                        {
                            item.MaKQDN,
                            item.DanhBo,
                            item.HopDong,
                            item.HoTen,
                            item.DiaChi,
                            item.MLT,
                            item.Hieu,
                            item.Co,
                            item.SoThan,
                            item.NgayDN,
                            item.ChiSoDN,
                            item.NiemChi,
                            item.ChiMatSo,
                            item.ChiKhoaGoc,
                            item.LyDo,
                            item.GhiChu,
                            item.SoPhieuDN,
                            item.MoNuoc,
                            item.NgayMN,
                            item.ChiSoMN,
                            item.GhiChuMN,
                            item.SoPhieuMN,
                            item.DongPhi,
                            item.MaDN,
                            item.DaKy,
                            item.NgayKy,
                            item.Duyet,
                            item.KhoaTu,
                            item.KhoaKhac,
                            To = _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == itemtableND.MaTo).TenTo,
                            NhanVien = itemtableND.HoTen,
                            item.CreateDate,
                        };
            dt.Merge(LINQToDataTable(query));
            var query2 = from item in _db.TT_KQDongNuocs
                         join itemND in _db.TT_NguoiDungs on item.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
                         from itemtableND in tableND.DefaultIfEmpty()
                         where (item.NgayDN1.Value.Date >= FromNgayDN.Date && item.NgayDN1.Value.Date <= ToNgayDN.Date)
                         select new
                         {
                             item.MaKQDN,
                             item.DanhBo,
                             item.HopDong,
                             item.HoTen,
                             item.DiaChi,
                             item.MLT,
                             item.Hieu,
                             item.Co,
                             item.SoThan,
                             NgayDN = item.NgayDN1,
                             ChiSoDN = item.ChiSoDN1,
                             NiemChi = item.NiemChi1,
                             item.ChiMatSo,
                             item.ChiKhoaGoc,
                             item.LyDo,
                             item.GhiChu,
                             item.SoPhieuDN,
                             item.MoNuoc,
                             item.NgayMN,
                             item.ChiSoMN,
                             item.GhiChuMN,
                             item.SoPhieuMN,
                             item.DongPhi,
                             item.MaDN,
                             item.DaKy,
                             item.NgayKy,
                             item.Duyet,
                             item.KhoaTu,
                             item.KhoaKhac,
                             To = _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == itemtableND.MaTo).TenTo,
                             NhanVien = itemtableND.HoTen,
                             item.CreateDate,
                         };
            dt.Merge(LINQToDataTable(query2));
            return dt;
        }

        public DataTable getDS_KQDongNuoc_MaTo_NgayDN(int MaTo, DateTime FromNgayDN, DateTime ToNgayDN)
        {
            DataTable dt = new DataTable();
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        where (itemKQ.NgayDN.Value.Date >= FromNgayDN.Date && itemKQ.NgayDN.Value.Date <= ToNgayDN.Date)
                                && Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        select new
                        {
                            itemKQ.MaKQDN,
                            itemKQ.DanhBo,
                            itemKQ.HopDong,
                            itemKQ.HoTen,
                            itemKQ.DiaChi,
                            itemKQ.MLT,
                            itemKQ.Hieu,
                            CoDHN = itemKQ.Co,
                            itemKQ.SoThan,
                            itemKQ.NgayDN,
                            itemKQ.ChiSoDN,
                            itemKQ.NiemChi,
                            itemKQ.ChiMatSo,
                            itemKQ.ChiKhoaGoc,
                            itemKQ.LyDo,
                            itemKQ.GhiChu,
                            itemKQ.SoPhieuDN,
                            itemKQ.MoNuoc,
                            itemKQ.NgayMN,
                            itemKQ.ChiSoMN,
                            itemKQ.GhiChuMN,
                            itemKQ.SoPhieuMN,
                            itemKQ.DongPhi,
                            itemKQ.MaDN,
                            itemKQ.DaKy,
                            itemKQ.NgayKy,
                            itemKQ.Duyet,
                            itemKQ.CreateDate,
                        };
            dt.Merge(LINQToDataTable(query.Distinct()));
            var query2 = from itemKQ in _db.TT_KQDongNuocs
                         join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                         join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                         where (itemKQ.NgayDN1.Value.Date >= FromNgayDN.Date && itemKQ.NgayDN1.Value.Date <= ToNgayDN.Date)
                                 && Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                 && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                         select new
                         {
                             itemKQ.MaKQDN,
                             itemKQ.DanhBo,
                             itemKQ.HopDong,
                             itemKQ.HoTen,
                             itemKQ.DiaChi,
                             itemKQ.MLT,
                             itemKQ.Hieu,
                             CoDHN = itemKQ.Co,
                             itemKQ.SoThan,
                             NgayDN = itemKQ.NgayDN1,
                             ChiSoDN = itemKQ.ChiSoDN1,
                             NiemChi = itemKQ.NiemChi1,
                             itemKQ.ChiMatSo,
                             itemKQ.ChiKhoaGoc,
                             itemKQ.LyDo,
                             itemKQ.GhiChu,
                             itemKQ.SoPhieuDN,
                             itemKQ.MoNuoc,
                             itemKQ.NgayMN,
                             itemKQ.ChiSoMN,
                             itemKQ.GhiChuMN,
                             itemKQ.SoPhieuMN,
                             itemKQ.DongPhi,
                             itemKQ.MaDN,
                             itemKQ.DaKy,
                             itemKQ.NgayKy,
                             itemKQ.Duyet,
                             itemKQ.CreateDate,
                         };
            dt.Merge(LINQToDataTable(query2.Distinct()));
            return dt;
        }

        public DataTable getDS_KQDongNuoc_MaNV_NgayDN(int MaNV, DateTime FromNgayDN, DateTime ToNgayDN)
        {
            DataTable dt = new DataTable();
            var query = from item in _db.TT_KQDongNuocs
                        where item.CreateBy == MaNV
                        && (item.NgayDN.Value.Date >= FromNgayDN.Date && item.NgayDN.Value.Date <= ToNgayDN.Date)
                        select new
                        {
                            item.MaKQDN,
                            item.DanhBo,
                            item.HopDong,
                            item.HoTen,
                            item.DiaChi,
                            item.MLT,
                            item.Hieu,
                            item.Co,
                            item.SoThan,
                            item.NgayDN,
                            item.ChiSoDN,
                            item.NiemChi,
                            item.ChiMatSo,
                            item.ChiKhoaGoc,
                            item.LyDo,
                            item.GhiChu,
                            item.SoPhieuDN,
                            item.MoNuoc,
                            item.NgayMN,
                            item.ChiSoMN,
                            item.GhiChuMN,
                            item.SoPhieuMN,
                            item.DongPhi,
                            item.MaDN,
                            item.DaKy,
                            item.NgayKy,
                            item.Duyet,
                            item.CreateDate,
                        };
            dt.Merge(LINQToDataTable(query));
            var query2 = from item in _db.TT_KQDongNuocs
                         where item.CreateBy == MaNV
                         && (item.NgayDN1.Value.Date >= FromNgayDN.Date && item.NgayDN1.Value.Date <= ToNgayDN.Date)
                         select new
                         {
                             item.MaKQDN,
                             item.DanhBo,
                             item.HopDong,
                             item.HoTen,
                             item.DiaChi,
                             item.MLT,
                             item.Hieu,
                             item.Co,
                             item.SoThan,
                             NgayDN = item.NgayDN1,
                             ChiSoDN = item.ChiSoDN1,
                             NiemChi = item.NiemChi1,
                             item.ChiMatSo,
                             item.ChiKhoaGoc,
                             item.LyDo,
                             item.GhiChu,
                             item.SoPhieuDN,
                             item.MoNuoc,
                             item.NgayMN,
                             item.ChiSoMN,
                             item.GhiChuMN,
                             item.SoPhieuMN,
                             item.DongPhi,
                             item.MaDN,
                             item.DaKy,
                             item.NgayKy,
                             item.Duyet,
                             item.CreateDate,
                         };
            dt.Merge(LINQToDataTable(query2));
            return dt;
        }

        public DataTable CountDongMoNuoc(int MaTo, DateTime FromDate, DateTime ToDate)
        {
            string sql = "declare @FromDate datetime;"
                        + " declare @ToDate datetime;"
                        + " declare @MaTo int;"
                        + " set @FromDate='" + FromDate.ToString("yyyyMMdd") + "'"
                        + " set @ToDate='" + ToDate.ToString("yyyyMMdd") + "'"
                        + " set @MaTo=" + MaTo + ";"
                        + " select MaTo=@MaTo,TenTo=(select TenTo from TT_To where MaTo=@MaTo)"
                        + " ,DongNuoc=(select count(*) from (select distinct kqdn.MaKQDN,kqdn.DanhBo as DongNuoc from HOADON hd,TT_KQDongNuoc kqdn,TT_CTDongNuoc ctdn"
                        + " where hd.ID_HOADON=ctdn.MaHD and kqdn.MaDN=ctdn.MaDN and cast(kqdn.NgayDN as date)>=@FromDate and cast(kqdn.NgayDN as date)<=@ToDate"
                        + " and hd.MAY>=(select TuCuonGCS from TT_To where MaTo=@MaTo) and hd.MAY<=(select DenCuonGCS from TT_To where MaTo=@MaTo))dn)"
                        + " +(select count(*) from (select distinct kqdn.MaKQDN,kqdn.DanhBo as DongNuoc from HOADON hd,TT_KQDongNuoc kqdn,TT_CTDongNuoc ctdn"
                        + " where hd.ID_HOADON=ctdn.MaHD and kqdn.MaDN=ctdn.MaDN and cast(kqdn.NgayDN1 as date)>=@FromDate and cast(kqdn.NgayDN1 as date)<=@ToDate"
                        + " and hd.MAY>=(select TuCuonGCS from TT_To where MaTo=@MaTo) and hd.MAY<=(select DenCuonGCS from TT_To where MaTo=@MaTo))dn)"
                        + " ,MoNuoc=(select count(*) from (select distinct kqdn.MaKQDN,kqdn.DanhBo as DongNuoc from HOADON hd,TT_KQDongNuoc kqdn,TT_CTDongNuoc ctdn"
                        + " where hd.ID_HOADON=ctdn.MaHD and kqdn.MaDN=ctdn.MaDN and cast(kqdn.NgayMN as date)>=@FromDate and cast(kqdn.NgayMN as date)<=@ToDate"
                        + " and hd.MAY>=(select TuCuonGCS from TT_To where MaTo=@MaTo) and hd.MAY<=(select DenCuonGCS from TT_To where MaTo=@MaTo))mn)";

            return ExecuteQuery_DataTable(sql);
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
            return _db.TT_KQDongNuocs.Where(item => item.SoPhieuDN != null).GroupBy(item => item.SoPhieuDN).Select(group => group.First()).OrderByDescending(item => item.NgaySoPhieuDN).ToList();
        }

        public List<TT_KQDongNuoc> GetDSSoPhieuMN()
        {
            return _db.TT_KQDongNuocs.Where(item => item.SoPhieuMN != null).GroupBy(item => item.SoPhieuMN).Select(group => group.First()).OrderByDescending(item => item.NgaySoPhieuMN).ToList();
        }

        public DataTable GetDSKQDongMoNuocByDanhBo(string DanhBo)
        {
            return LINQToDataTable(_db.TT_KQDongNuocs.Where(item => item.DanhBo == DanhBo).ToList());
        }

        public DataTable getDS_KQMoNuoc(DateTime FromNgayMN, DateTime ToNgayMN)
        {
            var query = from item in _db.TT_KQDongNuocs
                        where item.NgayMN.Value.Date >= FromNgayMN.Date && item.NgayMN.Value.Date <= ToNgayMN.Date
                        select new
                        {
                            item.MaKQDN,
                            item.DanhBo,
                            item.HopDong,
                            item.HoTen,
                            item.DiaChi,
                            item.MLT,
                            item.DongNuoc,
                            item.NgayDN,
                            item.Hieu,
                            item.Co,
                            item.SoThan,
                            item.ChiSoDN,
                            item.NiemChi,
                            item.ChiMatSo,
                            item.ChiKhoaGoc,
                            item.LyDo,
                            item.GhiChu,
                            item.DongNuoc2,
                            item.NgayDN1,
                            item.ChiSoDN1,
                            item.NiemChi1,
                            item.SoPhieuDN,
                            item.MoNuoc,
                            item.NgayMN,
                            item.ChiSoMN,
                            item.GhiChuMN,
                            item.SoPhieuMN,
                            item.MaDN,
                            item.DaKy,
                            item.NgayKy,
                            item.Duyet,
                            item.CreateDate,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_KQMoNuoc_MaTo_NgayMN(int MaTo, DateTime FromNgayMN, DateTime ToNgayMN)
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        where itemKQ.NgayMN.Value.Date >= FromNgayMN.Date && itemKQ.NgayMN.Value.Date <= ToNgayMN.Date
                                && Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        select new
                        {
                            itemKQ.MaKQDN,
                            itemKQ.DanhBo,
                            itemKQ.HopDong,
                            itemKQ.HoTen,
                            itemKQ.DiaChi,
                            itemKQ.MLT,
                            itemKQ.DongNuoc,
                            itemKQ.NgayDN,
                            itemKQ.Hieu,
                            CoDHN = itemKQ.Co,
                            itemKQ.SoThan,
                            itemKQ.ChiSoDN,
                            itemKQ.NiemChi,
                            itemKQ.ChiMatSo,
                            itemKQ.ChiKhoaGoc,
                            itemKQ.LyDo,
                            itemKQ.GhiChu,
                            itemKQ.DongNuoc2,
                            itemKQ.NgayDN1,
                            itemKQ.ChiSoDN1,
                            itemKQ.NiemChi1,
                            itemKQ.SoPhieuDN,
                            itemKQ.MoNuoc,
                            itemKQ.NgayMN,
                            itemKQ.ChiSoMN,
                            itemKQ.GhiChuMN,
                            itemKQ.SoPhieuMN,
                            itemKQ.MaDN,
                            itemKQ.DaKy,
                            itemKQ.NgayKy,
                            itemKQ.Duyet,
                            itemKQ.CreateDate,
                        };
            return LINQToDataTable(query.Distinct());
        }

        public DataTable getDS_KQDongNuoc_MaNV_NgayMN(int MaNV, DateTime FromNgayMN, DateTime ToNgayMN)
        {
            var query = from item in _db.TT_KQDongNuocs
                        where item.CreateBy == MaNV && item.NgayMN.Value.Date >= FromNgayMN.Date && item.NgayMN.Value.Date <= ToNgayMN.Date
                        select new
                        {
                            item.MaKQDN,
                            item.DanhBo,
                            item.HopDong,
                            item.HoTen,
                            item.DiaChi,
                            item.MLT,
                            item.DongNuoc,
                            item.NgayDN,
                            item.Hieu,
                            item.Co,
                            item.SoThan,
                            item.ChiSoDN,
                            item.NiemChi,
                            item.ChiMatSo,
                            item.ChiKhoaGoc,
                            item.LyDo,
                            item.GhiChu,
                            item.DongNuoc2,
                            item.NgayDN1,
                            item.ChiSoDN1,
                            item.NiemChi1,
                            item.SoPhieuDN,
                            item.MoNuoc,
                            item.NgayMN,
                            item.ChiSoMN,
                            item.GhiChuMN,
                            item.SoPhieuMN,
                            item.MaDN,
                            item.DaKy,
                            item.NgayKy,
                            item.Duyet,
                            item.CreateDate,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSCanMoNuoc()
        {
            //var query = from itemKQ in _db.TT_KQDongNuocs
            //            join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
            //            join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
            //            join itemND in _db.TT_NguoiDungs on itemKQ.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            where itemHD.NGAYGIAITRACH != null && itemKQ.NgayDN != null && itemKQ.NgayMN == null && itemHD.ChuyenNoKhoDoi == false
            //            select new
            //            {
            //                itemKQ.MaKQDN,
            //                itemKQ.MaDN,
            //                itemKQ.CreateDate,
            //                itemKQ.DanhBo,
            //                itemKQ.HoTen,
            //                itemKQ.DiaChi,
            //                itemKQ.NgayDN,
            //                itemHD.NGAYGIAITRACH,
            //                CoDHN = itemKQ.Co,
            //                itemKQ.GhiChuTroNgai,
            //                itemKQ.TroNgaiMN,
            //                MaNV_DongNuoc = itemtableND.HoTen,
            //            };
            //return LINQToDataTable(query.GroupBy(item => item.MaDN).Select(item => item.First()).ToList());
            string sql = "select MaKQDN,kqdn.MaDN,kqdn.CreateDate,kqdn.DanhBo,kqdn.HoTen,kqdn.DiaChi,NgayDN,CoDHN=Co,kqdn.GhiChuTroNgai,TroNgaiMN,MaNV_DongNuoc=(select HoTen from TT_NguoiDung where MaND=dn.MaNV_DongNuoc)"
                        + " from TT_DongNuoc dn,TT_KQDongNuoc kqdn where dn.MaDN=kqdn.MaDN and NgayDN is not null and NgayMN is null"
                        + " and (select COUNT(MaHD) from TT_CTDongNuoc ctdn,HOADON hd where ctdn.MaHD=hd.ID_HOADON and NGAYGIAITRACH is not null and ChuyenNoKhoDoi=0 and kqdn.MaDN=ctdn.MaDN)=(select COUNT(MaHD) from TT_CTDongNuoc ctdn where kqdn.MaDN=ctdn.MaDN)";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSCanMoNuoc(int MaTo)
        {
            //var query = from itemKQ in _db.TT_KQDongNuocs
            //            join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
            //            join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
            //            join itemND in _db.TT_NguoiDungs on itemKQ.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            where itemHD.NGAYGIAITRACH != null && itemKQ.NgayDN != null && itemKQ.NgayMN == null && itemHD.ChuyenNoKhoDoi == false
            //                    && Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
            //                    && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
            //            select new
            //            {
            //                itemKQ.MaKQDN,
            //                itemKQ.MaDN,
            //                itemKQ.CreateDate,
            //                itemKQ.DanhBo,
            //                itemKQ.HoTen,
            //                itemKQ.DiaChi,
            //                itemKQ.NgayDN,
            //                itemHD.NGAYGIAITRACH,
            //                CoDHN = itemKQ.Co,
            //                itemKQ.GhiChuTroNgai,
            //                itemKQ.TroNgaiMN,
            //                MaNV_DongNuoc = itemtableND.HoTen,
            //            };
            //return LINQToDataTable(query.GroupBy(item => item.MaDN).Select(item => item.First()).ToList());
            string sql = "select MaKQDN,kqdn.MaDN,kqdn.CreateDate,kqdn.DanhBo,kqdn.HoTen,kqdn.DiaChi,NgayDN,CoDHN=Co,kqdn.GhiChuTroNgai,TroNgaiMN,MaNV_DongNuoc=(select HoTen from TT_NguoiDung where MaND=dn.MaNV_DongNuoc)"
                        + " from TT_DongNuoc dn,TT_KQDongNuoc kqdn where dn.MaDN=kqdn.MaDN and NgayDN is not null and NgayMN is null"
                        + " and (select COUNT(MaHD) from TT_CTDongNuoc ctdn,HOADON hd where ctdn.MaHD=hd.ID_HOADON and NGAYGIAITRACH is not null and ChuyenNoKhoDoi=0 and kqdn.MaDN=ctdn.MaDN)=(select COUNT(MaHD) from TT_CTDongNuoc ctdn where kqdn.MaDN=ctdn.MaDN)";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSKQDongNuoc_PhiMoNuoc_All(bool ChuyenKhoan, string DanhBo)
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        where itemKQ.ChuyenKhoan == ChuyenKhoan && itemKQ.NgayDN != null && itemKQ.DanhBo == DanhBo
                        select new
                        {
                            itemKQ.MaDN,
                            itemKQ.MaKQDN,
                            itemKQ.CreateDate,
                            itemKQ.DanhBo,
                            itemKQ.HoTen,
                            itemKQ.DiaChi,
                            itemKQ.NgayDN,
                            itemKQ.PhiMoNuoc,
                            itemKQ.DongPhi,
                            itemKQ.NgayDongPhi,
                            itemKQ.ChuyenKhoan,
                            itemHD.NGAYGIAITRACH,
                            CoDHN = itemKQ.Co,
                        };
            return LINQToDataTable(query.GroupBy(item => item.MaDN).Select(item => item.First()).ToList());
        }

        public DataTable GetDSKQDongNuoc_PhiMoNuoc_All(bool ChuyenKhoan, DateTime FromNgayDongPhi, DateTime ToNgayDongPhi)
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        where itemKQ.ChuyenKhoan == ChuyenKhoan && itemKQ.NgayDongPhi.Value.Date >= FromNgayDongPhi.Date && itemKQ.NgayDongPhi.Value.Date <= ToNgayDongPhi.Date
                        select new
                        {
                            itemKQ.MaDN,
                            itemKQ.MaKQDN,
                            itemKQ.CreateDate,
                            itemKQ.DanhBo,
                            itemKQ.HoTen,
                            itemKQ.DiaChi,
                            itemKQ.NgayDN,
                            itemKQ.PhiMoNuoc,
                            itemKQ.DongPhi,
                            itemKQ.NgayDongPhi,
                            itemKQ.ChuyenKhoan,
                            itemHD.NGAYGIAITRACH,
                            CoDHN = itemKQ.Co,
                        };
            return LINQToDataTable(query.GroupBy(item => item.MaDN).Select(item => item.First()).ToList());
        }

        public DataTable GetDSKQDongNuoc_PhiMoNuoc(bool ChuyenKhoan, string DanhBo)
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        where itemKQ.ChuyenKhoan == ChuyenKhoan && itemKQ.NgayDN != null && itemKQ.NgayMN == null && itemKQ.TroNgaiMN == false && itemHD.ChuyenNoKhoDoi == false && itemKQ.DanhBo == DanhBo
                        select new
                        {
                            itemKQ.MaDN,
                            itemKQ.MaKQDN,
                            itemKQ.CreateDate,
                            itemKQ.DanhBo,
                            itemKQ.HoTen,
                            itemKQ.DiaChi,
                            itemKQ.NgayDN,
                            itemKQ.PhiMoNuoc,
                            itemKQ.DongPhi,
                            itemKQ.NgayDongPhi,
                            itemKQ.ChuyenKhoan,
                            itemHD.NGAYGIAITRACH,
                            CoDHN = itemKQ.Co,
                        };
            return LINQToDataTable(query.GroupBy(item => item.MaDN).Select(item => item.First()).ToList());
        }

        public DataTable GetDSKQDongNuoc_PhiMoNuoc(bool ChuyenKhoan, DateTime FromNgayDongPhi, DateTime ToNgayDongPhi)
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        where itemKQ.ChuyenKhoan == ChuyenKhoan && itemHD.ChuyenNoKhoDoi == false && itemKQ.NgayDongPhi.Value.Date >= FromNgayDongPhi.Date && itemKQ.NgayDongPhi.Value.Date <= ToNgayDongPhi.Date
                        select new
                        {
                            itemKQ.MaDN,
                            itemKQ.MaKQDN,
                            itemKQ.CreateDate,
                            itemKQ.DanhBo,
                            itemKQ.HoTen,
                            itemKQ.DiaChi,
                            itemKQ.NgayDN,
                            itemKQ.PhiMoNuoc,
                            itemKQ.DongPhi,
                            itemKQ.NgayDongPhi,
                            itemKQ.ChuyenKhoan,
                            itemHD.NGAYGIAITRACH,
                            CoDHN = itemKQ.Co,
                        };
            return LINQToDataTable(query.GroupBy(item => item.MaDN).Select(item => item.First()).ToList());
        }

        public DataTable GetDSKQDongNuoc_PhiMoNuoc(DateTime FromNgayDongPhi, DateTime ToNgayDongPhi)
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        where itemKQ.NgayDongPhi.Value.Date >= FromNgayDongPhi.Date && itemKQ.NgayDongPhi.Value.Date <= ToNgayDongPhi.Date
                        select new
                        {
                            itemKQ.MaDN,
                            itemKQ.MaKQDN,
                            itemKQ.CreateDate,
                            itemKQ.DanhBo,
                            itemKQ.HoTen,
                            itemKQ.DiaChi,
                            itemKQ.NgayDN,
                            itemKQ.PhiMoNuoc,
                            itemKQ.DongPhi,
                            itemKQ.NgayDongPhi,
                            itemKQ.ChuyenKhoan,
                            itemHD.NGAYGIAITRACH,
                            CoDHN = itemKQ.Co,
                        };
            return LINQToDataTable(query.GroupBy(item => item.MaDN).Select(item => item.First()).ToList());
        }

        public DataTable GetDSKQDongNuoc_DongPhi(int MaNV_DongPhi, DateTime FromNgayDongPhi, DateTime ToNgayDongPhi)
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        where itemKQ.NgayDongPhi.Value.Date >= FromNgayDongPhi.Date && itemKQ.NgayDongPhi.Value.Date <= ToNgayDongPhi.Date && itemKQ.MaNV_DongPhi == MaNV_DongPhi
                        select new
                        {
                            itemKQ.MaDN,
                            itemKQ.MaKQDN,
                            itemKQ.CreateDate,
                            itemKQ.DanhBo,
                            itemKQ.HoTen,
                            itemKQ.DiaChi,
                            itemKQ.NgayDN,
                            itemKQ.PhiMoNuoc,
                            itemKQ.DongPhi,
                            itemKQ.NgayDongPhi,
                            itemKQ.ChuyenKhoan,
                            itemHD.NGAYGIAITRACH,
                            itemKQ.Co,
                            itemKQ.Hieu,
                            itemKQ.SoThan,
                            itemKQ.ChiSoDN,
                            itemKQ.LyDo,
                        };
            return LINQToDataTable(query.GroupBy(item => item.MaDN).Select(item => item.First()).ToList());
        }

        public DataTable GetBaoCaoTongHop(int MaTo, DateTime FromDate, DateTime ToDate)
        {
            string sql = "declare @FromDate date;"
                        + " declare @ToDate date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @FromDate='" + FromDate.ToString("yyyyMMdd") + "';"
                        + " set @ToDate='" + ToDate.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select nd.MaND as MaNV,nd.HoTen,nd.STT,toncu.DCTonCu,toncu.HDTonCu,toncu.TCTonCu,nhan.DCNhan,nhan.HDNhan,nhan.TCNhan"
                        + ",dangngan.DCDangNgan,dangngan.HDDangNgan,dangngan.TCDangNgan,lenhhuy.DCHuy,lenhhuy.HDHuy,lenhhuy.TCHuy,tongton.DCTongTon,tongton.HDTongTon,tongton.TCTongTon,dongnuoc.DCDongNuoc from"
                        + " (select MaND,HoTen,STT from TT_NguoiDung where DongNuoc=1 and MaTo=" + MaTo + ") nd"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(DISTINCT DanhBo) as DCTonCu,COUNT(hd.SOHOADON) as HDTonCu,SUM(hd.TONGCONG) as TCTonCu"
                        + " from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and CAST(dn.CreateDate as date)<@FromDate and (hd.NGAYGIAITRACH is null or (CAST(hd.NGAYGIAITRACH as date)>@FromDate))"
                        + " group by nd.MaND,nd.HoTen,nd.STT) toncu on nd.MaND=toncu.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(DISTINCT DanhBo) as DCNhan,COUNT(hd.SOHOADON) as HDNhan,SUM(hd.TONGCONG) as TCNhan"
                        + " from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and CAST(dn.CreateDate as date)>=@FromDate and CAST(dn.CreateDate as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) nhan on nd.MaND=nhan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(DISTINCT DanhBo) as DCDangNgan,COUNT(hd.SOHOADON) as HDDangNgan,SUM(hd.TONGCONG) as TCDangNgan"
                        + " from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and CAST(NGAYGIAITRACH as date)>=@FromDate and CAST(NGAYGIAITRACH as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) dangngan on nd.MaND=dangngan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(DISTINCT dn.DanhBo) as DCHuy,COUNT(hd.SOHOADON) as HDHuy,SUM(hd.TONGCONG) as TCHuy"
                        + " from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_LenhHuy lenhhuy,TT_NguoiDung nd"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and lenhhuy.MaHD=hd.ID_HOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and CAST(lenhhuy.CreateDate as date)>=@FromDate and CAST(lenhhuy.CreateDate as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) lenhhuy on nd.MaND=lenhhuy.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(DISTINCT DanhBo) as DCTongTon,COUNT(hd.SOHOADON) as HDTongTon,SUM(hd.TONGCONG) as TCTongTon"
                        + " from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and CAST(dn.NgayGiao as date)<=@ToDate and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)>@ToDate) and ctdn.MaHD not in (select MaHD from TT_LenhHuy)"
                        + " group by nd.MaND,nd.HoTen,nd.STT) tongton on nd.MaND=tongton.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(DISTINCT kqdn.DanhBo) as DCDongNuoc"
                        + " from TT_DongNuoc dn,TT_CTDongNuoc ctdn,TT_KQDongNuoc kqdn,HOADON hd,TT_NguoiDung nd"
                        + " where dn.MaDN=ctdn.MaDN and dn.MaDN=kqdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and CAST(kqdn.NgayDN as date)>=@FromDate and CAST(kqdn.NgayDN as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) dongnuoc on nd.MaND=dongnuoc.MaND"
                        + " order by nd.STT asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetBaoCaoTongHop_ChiTiet(int MaTo, DateTime FromDate, DateTime ToDate)
        {
            string sql = "declare @FromDate date;"
                        + " declare @ToDate date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @FromDate='" + FromDate.ToString("yyyyMMdd") + "';"
                        + " set @ToDate='" + ToDate.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select nd.MaND as MaNV,nd.HoTen,nd.STT,dangngan.DCDangNgan,dongnuoc.DCDongNuoc,monuoc.DCMoNuoc,phoihop.DCPhoiHop from"
                        + " (select MaND,HoTen,STT from TT_NguoiDung where DongNuoc=1 and MaTo=" + MaTo + ") nd"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(DISTINCT DanhBo) as DCDangNgan"
                        + " from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and CAST(hd.NGAYGIAITRACH as date)>=@FromDate and CAST(hd.NGAYGIAITRACH as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) dangngan on nd.MaND=dangngan.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(DISTINCT kqdn.DanhBo) as DCDongNuoc"
                        + " from TT_DongNuoc dn,TT_CTDongNuoc ctdn,TT_KQDongNuoc kqdn,HOADON hd,TT_NguoiDung nd"
                        + " where dn.MaDN=ctdn.MaDN and dn.MaDN=kqdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and CAST(kqdn.NgayDN as date)>=@FromDate and CAST(kqdn.NgayDN as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) dongnuoc on nd.MaND=dongnuoc.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(DISTINCT kqdn.DanhBo) as DCMoNuoc"
                        + " from TT_DongNuoc dn,TT_CTDongNuoc ctdn,TT_KQDongNuoc kqdn,HOADON hd,TT_NguoiDung nd"
                        + " where dn.MaDN=ctdn.MaDN and dn.MaDN=kqdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and CAST(kqdn.NgayMN as date)>=@FromDate and CAST(kqdn.NgayMN as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) monuoc on nd.MaND=monuoc.MaND"
                        + " left join"
                        + " (select nd.MaND,nd.HoTen,nd.STT,COUNT(DISTINCT ph.ID) as DCPhoiHop"
                        + " from TT_DongNuoc_PhoiHop ph,TT_NguoiDung nd"
                        + " where ph.CreateBy=nd.MaND"
                        + " and CAST(ph.CreateDate as date)>=@FromDate and CAST(ph.CreateDate as date)<=@ToDate"
                        + " group by nd.MaND,nd.HoTen,nd.STT) phoihop on nd.MaND=phoihop.MaND"
                        + " order by nd.STT asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetBaoCaoTongHop_DanhSach(int MaTo, DateTime FromDate, DateTime ToDate)
        {
            string sql = "declare @FromDate date;"
                        + " declare @ToDate date;"
                        + " declare @TuCuonGCS int;"
                        + " declare @DenCuonGCS int;"
                        + " set @FromDate='" + FromDate.ToString("yyyyMMdd") + "';"
                        + " set @ToDate='" + ToDate.ToString("yyyyMMdd") + "';"
                        + " set @TuCuonGCS=(select TuCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " set @DenCuonGCS=(select DenCuonGCS from TT_To where MaTo=" + MaTo + ")"
                        + " select nd.MaND as MaNV,HanhThu=nd.HoTen,nd.STT,dangngan.* from"
                        + " (select MaND,HoTen,STT from TT_NguoiDung where DongNuoc=1 and MaTo=" + MaTo + ") nd,"
                        + " (select distinct Loai=N'Đăng Ngân',nd.MaND,dn.DanhBo,dn.HoTen,dn.DiaChi,NgayXuLy=CAST(hd.NGAYGIAITRACH as date),NiemChi=NULL,DongNuoc2='false',NgayXuLy1=NULL,NiemChi1=NULL,KhoaTu='false',KhoaKhac='false',NoiDung=NULL"
                        + " from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd,TT_NguoiDung nd"
                        + " where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0 and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and CAST(hd.NGAYGIAITRACH as date)>=@FromDate and CAST(hd.NGAYGIAITRACH as date)<=@ToDate) dangngan"
                        + " where nd.MaND=dangngan.MaND"
                        + " union all"
                        + " select nd.MaND as MaNV,nd.HoTen,nd.STT,dongnuoc.* from"
                        + " (select MaND,HoTen,STT from TT_NguoiDung where DongNuoc=1 and MaTo=" + MaTo + ") nd,"
                        + " (select distinct Loai=N'Đóng Nước',nd.MaND,dn.DanhBo,dn.HoTen,dn.DiaChi,NgayXuLy=CAST(kqdn.NgayDN as date),kqdn.NiemChi,kqdn.DongNuoc2,NgayXuLy1=CAST(kqdn.NgayDN1 as date),kqdn.NiemChi1,kqdn.KhoaTu,kqdn.KhoaKhac,NoiDung=NULL"
                        + " from TT_DongNuoc dn,TT_CTDongNuoc ctdn,TT_KQDongNuoc kqdn,HOADON hd,TT_NguoiDung nd"
                        + " where dn.MaDN=ctdn.MaDN and dn.MaDN=kqdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and ((CAST(kqdn.NgayDN as date)>=@FromDate and CAST(kqdn.NgayDN as date)<=@ToDate) or (CAST(kqdn.NgayDN1 as date)>=@FromDate and CAST(kqdn.NgayDN1 as date)<=@ToDate))) dongnuoc"
                        + " where nd.MaND=dongnuoc.MaND"
                        + " union all"
                        + " select nd.MaND as MaNV,nd.HoTen,nd.STT,monuoc.* from"
                        + " (select MaND,HoTen,STT from TT_NguoiDung where DongNuoc=1 and MaTo=" + MaTo + ") nd,"
                        + " (select distinct Loai=N'Mở Nước',nd.MaND,dn.DanhBo,dn.HoTen,dn.DiaChi,NgayXuLy=CAST(kqdn.NgayMN as date),NiemChi=NULL,DongNuoc2='false',NgayXuLy1=NULL,NiemChi1=NULL,kqdn.KhoaTu,kqdn.KhoaKhac,NoiDung=NULL"
                        + " from TT_DongNuoc dn,TT_CTDongNuoc ctdn,TT_KQDongNuoc kqdn,HOADON hd,TT_NguoiDung nd"
                        + " where dn.MaDN=ctdn.MaDN and dn.MaDN=kqdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.MaNV_DongNuoc=nd.MaND and dn.Huy=0"
                        + " and MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and CAST(kqdn.NgayMN as date)>=@FromDate and CAST(kqdn.NgayMN as date)<=@ToDate) monuoc"
                        + " where nd.MaND=monuoc.MaND"
                        + " union all"
                        + " select nd.MaND as MaNV,nd.HoTen,nd.STT,phoihop.* from"
                        + " (select MaND,HoTen,STT from TT_NguoiDung where DongNuoc=1 and MaTo=" + MaTo + ") nd,"
                        + " (select distinct Loai=N'Phối Hợp',nd.MaND,phoihop.DanhBo,phoihop.HoTen,phoihop.DiaChi,NgayXuLy=CAST(phoihop.CreateDate as date),NiemChi=NULL,DongNuoc2='false',NgayXuLy1=NULL,NiemChi1=NULL,KhoaTu='false',KhoaKhac='false',NoiDung"
                        + " from TT_DongNuoc_PhoiHop phoihop,HOADON hd,TT_NguoiDung nd"
                        + " where MAY>=@TuCuonGCS and MAY<=@DenCuonGCS"
                        + " and CAST(phoihop.CreateDate as date)>=@FromDate and CAST(phoihop.CreateDate as date)<=@ToDate and phoihop.CreateBy=nd.MaND) phoihop"
                        + " where nd.MaND=phoihop.MaND"
                        + " order by nd.STT asc";

            return ExecuteQuery_DataTable(sql);
        }

        ///

        public DataTable getDSKQDongNuoc_ChuaDongPhi()
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemKQ.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.NGAYGIAITRACH != null && itemKQ.NgayDN != null && itemKQ.DongPhi == false && itemKQ.NgayMN == null && itemKQ.TroNgaiMN == false && itemHD.ChuyenNoKhoDoi == false
                        orderby itemKQ.TT_DongNuoc.CreateDate descending
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
                            CoDHN = itemKQ.Co,
                            itemKQ.GhiChuTroNgai,
                            itemKQ.TroNgaiMN,
                            MaNV_DongNuoc = itemtableND.HoTen,
                        };
            return LINQToDataTable(query.GroupBy(item => item.MaDN).Select(item => item.First()).ToList());
        }

        public DataTable getDSKQDongNuoc_ChuaDongPhi(DateTime FromNgayDN, DateTime ToNgayDN)
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemKQ.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemKQ.NgayDN.Value.Date >= FromNgayDN.Date && itemKQ.NgayDN.Value.Date <= ToNgayDN.Date
                        && itemHD.NGAYGIAITRACH != null && itemKQ.NgayDN != null && itemKQ.DongPhi == false && itemKQ.NgayMN == null && itemKQ.TroNgaiMN == false && itemHD.ChuyenNoKhoDoi == false
                        orderby itemKQ.TT_DongNuoc.CreateDate descending
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
                            CoDHN = itemKQ.Co,
                            itemKQ.GhiChuTroNgai,
                            itemKQ.TroNgaiMN,
                            MaNV_DongNuoc = itemtableND.HoTen,
                        };
            return LINQToDataTable(query.GroupBy(item => item.MaDN).Select(item => item.First()).ToList());
        }

        public DataTable getDSKQDongNuoc_CanMoNuoc()
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemKQ.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.NGAYGIAITRACH != null && itemKQ.NgayDN != null && itemKQ.DongPhi == true && itemKQ.NgayMN == null && itemKQ.TroNgaiMN == false && itemHD.ChuyenNoKhoDoi == false
                        orderby itemKQ.TT_DongNuoc.CreateDate descending
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
                            CoDHN = itemKQ.Co,
                            itemKQ.GhiChuTroNgai,
                            itemKQ.TroNgaiMN,
                            MaNV_DongNuoc = itemtableND.HoTen,
                        };
            return LINQToDataTable(query.GroupBy(item => item.MaDN).Select(item => item.First()).ToList());
        }

        public DataTable getDSKQDongNuoc_CanMoNuoc(DateTime FromNgayDN, DateTime ToNgayDN)
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemKQ.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemKQ.NgayDN.Value.Date >= FromNgayDN.Date && itemKQ.NgayDN.Value.Date <= ToNgayDN.Date
                        && itemHD.NGAYGIAITRACH != null && itemKQ.NgayDN != null && itemKQ.DongPhi == true && itemKQ.NgayMN == null && itemKQ.TroNgaiMN == false && itemHD.ChuyenNoKhoDoi == false
                        orderby itemKQ.TT_DongNuoc.CreateDate descending
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
                            CoDHN = itemKQ.Co,
                            itemKQ.GhiChuTroNgai,
                            itemKQ.TroNgaiMN,
                            MaNV_DongNuoc = itemtableND.HoTen,
                        };
            return LINQToDataTable(query.GroupBy(item => item.MaDN).Select(item => item.First()).ToList());
        }

        public DataTable getDSKQDongNuoc_TroNgaiMoNuoc()
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemKQ.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.NGAYGIAITRACH != null && itemKQ.NgayDN != null && itemKQ.DongPhi == true && itemKQ.NgayMN == null && itemKQ.TroNgaiMN == true && itemHD.ChuyenNoKhoDoi == false
                        orderby itemKQ.TT_DongNuoc.CreateDate descending
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
                            CoDHN = itemKQ.Co,
                            itemKQ.GhiChuTroNgai,
                            itemKQ.TroNgaiMN,
                            MaNV_DongNuoc = itemtableND.HoTen,
                        };
            return LINQToDataTable(query.GroupBy(item => item.MaDN).Select(item => item.First()).ToList());
        }

        public DataTable getDSKQDongNuoc_TroNgaiMoNuoc(DateTime FromNgayDN, DateTime ToNgayDN)
        {
            var query = from itemKQ in _db.TT_KQDongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemKQ.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemKQ.TT_DongNuoc.MaNV_DongNuoc equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemKQ.NgayDN.Value.Date >= FromNgayDN.Date && itemKQ.NgayDN.Value.Date <= ToNgayDN.Date
                        && itemHD.NGAYGIAITRACH != null && itemKQ.NgayDN != null && itemKQ.DongPhi == true && itemKQ.NgayMN == null && itemKQ.TroNgaiMN == true && itemHD.ChuyenNoKhoDoi == false
                        orderby itemKQ.TT_DongNuoc.CreateDate descending
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
                            CoDHN = itemKQ.Co,
                            itemKQ.GhiChuTroNgai,
                            itemKQ.TroNgaiMN,
                            MaNV_DongNuoc = itemtableND.HoTen,
                        };
            return LINQToDataTable(query.GroupBy(item => item.MaDN).Select(item => item.First()).ToList());
        }

        ///

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
                if (_db.HOADONs.FirstOrDefault(itemHD => itemHD.ID_HOADON == item.MaHD).NGAYGIAITRACH == null)
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

        public bool CheckExist_CTDongNuoc_Ton(string DanhBo, int Nam, int Ky)
        {
            var query = from itemDN in _db.TT_DongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemDN.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        where itemDN.Huy == false && itemHD.NGAYGIAITRACH == null && itemHD.DANHBA == DanhBo && itemHD.NAM == Nam && itemHD.KY == Ky
                        select new
                        {
                            itemHD.ID_HOADON,
                        };
            if (query.Count() > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool CheckPhiMoNuoc(string DanhBo)
        {
            return _db.TT_KQDongNuocs.Any(item => item.DanhBo == DanhBo && item.DongNuoc == true && item.MoNuoc == false && item.TroNgaiMN == false && item.TT_DongNuoc.Huy == false);
        }

        public int GetPhiMoNuoc(string DanhBo)
        {
            if (CheckPhiMoNuoc(DanhBo) == true)
                return _db.TT_KQDongNuocs.SingleOrDefault(item => item.DanhBo == DanhBo && item.DongNuoc == true && item.MoNuoc == false && item.TroNgaiMN == false && item.TT_DongNuoc.Huy == false).PhiMoNuoc.Value;
            else
                return 0;
        }

        public TT_DongNuoc GetDongNuocByMaDN(decimal MaDN)
        {
            return _db.TT_DongNuocs.SingleOrDefault(item => item.MaDN == MaDN);
        }

        public TT_DongNuoc GetDongNuocBySoHoaDon(string SoHoaDon)
        {
            return _db.TT_CTDongNuocs.SingleOrDefault(item => item.SoHoaDon == SoHoaDon && item.TT_DongNuoc.Huy == false).TT_DongNuoc;
        }

        public TT_DongNuoc getDongNuoc_MoiNhat_Ton(string DanhBo, int Nam, int Ky)
        {
            var query = from itemDN in _db.TT_DongNuocs
                        join itemCT in _db.TT_CTDongNuocs on itemDN.MaDN equals itemCT.MaDN
                        join itemHD in _db.HOADONs on itemCT.MaHD equals itemHD.ID_HOADON
                        where itemDN.Huy == false && itemHD.NGAYGIAITRACH == null && itemHD.DANHBA == DanhBo && (itemHD.NAM < Nam || (itemHD.NAM == Nam && itemHD.KY <= Ky))
                        orderby itemDN.CreateDate descending
                        select itemDN;
            return query.FirstOrDefault();
        }

        public TT_CTDongNuoc getCTDongNuoc(decimal MaDN, int MaHD)
        {
            return _db.TT_CTDongNuocs.SingleOrDefault(item => item.MaDN == MaDN && item.MaHD == MaHD);
        }

        public TT_KQDongNuoc GetKQDongNuocByMaKQDN(int MaKQDN)
        {
            return _db.TT_KQDongNuocs.SingleOrDefault(item => item.MaKQDN == MaKQDN);
        }

        public TT_KQDongNuoc GetKQDongNuocByMaDN(decimal MaDN)
        {
            return _db.TT_KQDongNuocs.SingleOrDefault(item => item.MaDN == MaDN);
        }

        public TT_KQDongNuoc GetKQDongNuocByDanhBo_Last(string DanhBo)
        {
            if (_db.TT_KQDongNuocs.Where(item => item.DanhBo == DanhBo && item.TT_DongNuoc.Huy == false).Count() > 0)
                return _db.TT_KQDongNuocs.Where(item => item.DanhBo == DanhBo && item.TT_DongNuoc.Huy == false).OrderByDescending(item => item.MaKQDN).First();
            else
                return null;
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

        public int GetPhiMoNuoc(int CoDHN)
        {
            return _db.TT_CacLoaiPhis.SingleOrDefault(item => item.CoDHN.Contains(CoDHN.ToString())).PhiMoNuoc.Value;
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

        //table hình đóng mở nước
        public TT_KQDongNuoc_Hinh getHinh(int ID)
        {
            return _db.TT_KQDongNuoc_Hinhs.SingleOrDefault(item => item.ID == ID);
        }
    }
}

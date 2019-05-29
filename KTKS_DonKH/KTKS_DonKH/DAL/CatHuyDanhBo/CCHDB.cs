using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.CatHuyDanhBo
{
    class CCHDB : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng CHDB & CHDB_ChiTietCatTam & CHDB_ChiTietCatHuy & YeuCauCHDB

        #region CHDB (Cắt Hủy Danh Bộ)

        public bool ThemCHDB(CHDB chdb)
        {
            try
            {
                if (db.CHDBs.Count() > 0)
                {
                    string ID = "MaCHDB";
                    string Table = "CHDB";
                    decimal MaCHDB = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    //decimal MaCHDB = db.CHDBs.Max(itemCHDB => itemCHDB.MaCHDB);
                    chdb.MaCHDB = getMaxNextIDTable(MaCHDB);
                }
                else
                    chdb.MaCHDB = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                chdb.CreateDate = DateTime.Now;
                chdb.CreateBy = CTaiKhoan.MaUser.ToString();
                db.CHDBs.InsertOnSubmit(chdb);
                db.SubmitChanges();
                //MessageBox.Show("Thành công Thêm CHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool SuaCHDB(CHDB chdb)
        {
            try
            {
                chdb.ModifyDate = DateTime.Now;
                chdb.ModifyBy = CTaiKhoan.MaUser.ToString();
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa CHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        /// <summary>
        /// Lấy Mã Cắt Hủy Danh Bộ lớn nhất hiện tại
        /// </summary>
        /// <returns></returns>
        public decimal getMaxMaCHDB()
        {
            try
            {
                return db.CHDBs.Max(itemCHDB => itemCHDB.MaCHDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public bool CheckExist_CHDB(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.CHDBs.Any(item => item.MaDon == MaDon);
                case "TXL":
                    return db.CHDBs.Any(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.CHDBs.Any(item => item.MaDonTBC == MaDon);
                default:
                    return false;
            }
        }

        public CHDB GetCHDB(decimal MaCHDB)
        {
            return db.CHDBs.SingleOrDefault(item => item.MaCHDB == MaCHDB);
        }

        public CHDB GetCHDB(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.CHDBs.SingleOrDefault(item => item.MaDon == MaDon);
                case "TXL":
                    return db.CHDBs.SingleOrDefault(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.CHDBs.SingleOrDefault(item => item.MaDonTBC == MaDon);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Kiểm tra Danh Bộ đã lập cắt tạm/cắt hủy nào trước đó chưa
        /// </summary>
        /// <param name="DanhBo"></param>
        /// <param name="ThongTin"></param>
        /// <returns></returns>
        public bool CheckCHDBbyDanhBo(string DanhBo, out string ThongTin)
        {
            ThongTin = "";
            try
            {
                if (db.CHDB_ChiTietCatTams.Any(itemCTCTDB => itemCTCTDB.DanhBo == DanhBo))
                {
                    ThongTin = "Cắt Tạm với Số Phiếu: " + db.CHDB_ChiTietCatTams.Where(itemCTCTDB => itemCTCTDB.DanhBo == DanhBo).ToList().LastOrDefault().MaCTCTDB.ToString().Insert(db.CHDB_ChiTietCatTams.Where(itemCTCTDB => itemCTCTDB.DanhBo == DanhBo).ToList().LastOrDefault().MaCTCTDB.ToString().Length - 2, "-");
                    return true;
                }
                else
                    if (db.CHDB_ChiTietCatHuys.Any(itemCTCHDB => itemCTCHDB.DanhBo == DanhBo))
                    {
                        ThongTin = "Cắt Hủy với Số Phiếu: " + db.CHDB_ChiTietCatHuys.Where(itemCTCHDB => itemCTCHDB.DanhBo == DanhBo).ToList().LastOrDefault().MaCTCHDB.ToString().Insert(db.CHDB_ChiTietCatHuys.Where(itemCTCHDB => itemCTCHDB.DanhBo == DanhBo).ToList().LastOrDefault().MaCTCHDB.ToString().Length - 2, "-");
                        return true;
                    }
                    else
                        return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckCHDBbyDanhBo(string DanhBo)
        {
            try
            {
                if (db.CHDB_ChiTietCatTams.Any(itemCTCTDB => itemCTCTDB.DanhBo == DanhBo))
                {
                    return true;
                }
                else
                    if (db.CHDB_ChiTietCatHuys.Any(itemCTCHDB => itemCTCHDB.DanhBo == DanhBo))
                    {
                        return true;
                    }
                    else
                        return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region CHDB_ChiTietCatTam (Chi Tiết Cắt Tạm Danh Bộ)

        public bool ThemCTCTDB(CHDB_ChiTietCatTam ctctdb)
        {
            try
            {
                if (db.CHDB_ChiTietCatTams.Count() > 0)
                {
                    string ID = "MaCTCTDB";
                    string Table = "CHDB_ChiTietCatTam";
                    decimal MaCTCTDB = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    //decimal MaCTCTDB = db.CHDB_ChiTietCatTams.Max(itemCTCTDB => itemCTCTDB.MaCTCTDB);
                    ctctdb.MaCTCTDB = getMaxNextIDTable(MaCTCTDB);
                }
                else
                    ctctdb.MaCTCTDB = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                ctctdb.CreateDate = DateTime.Now;
                ctctdb.CreateBy = CTaiKhoan.MaUser;
                db.CHDB_ChiTietCatTams.InsertOnSubmit(ctctdb);
                db.SubmitChanges();
                //MessageBox.Show("Thành công Thêm CHDB_ChiTietCatTam", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool SuaCTCTDB(CHDB_ChiTietCatTam ctctdb)
        {
            try
            {
                ctctdb.ModifyDate = DateTime.Now;
                ctctdb.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa CHDB_ChiTietCatTam", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool XoaCTCTDB(CHDB_ChiTietCatTam ctctdb)
        {
            try
            {
                decimal ID = ctctdb.MaCHDB.Value;
                db.CHDB_ChiTietCatTams.DeleteOnSubmit(ctctdb);
                db.SubmitChanges();
                if (db.CHDB_ChiTietCatTams.Any(item => item.MaCHDB == ID) == false && db.CHDB_ChiTietCatHuys.Any(item => item.MaCHDB == ID) == false && db.CHDB_Phieus.Any(item => item.MaCHDB == ID) == false)
                    db.CHDBs.DeleteOnSubmit(db.CHDBs.SingleOrDefault(item => item.MaCHDB == ID));
                db.SubmitChanges();
                //MessageBox.Show("Thành công Xóa CHDB_ChiTietCatTam", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool CheckExist_CTCTDB(decimal MaCTCTDB)
        {
            return db.CHDB_ChiTietCatTams.Any(item => item.MaCTCTDB == MaCTCTDB);
        }

        public bool CheckExist_CTCTDB(string Loai, decimal MaDon, string DanhBo)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.CHDB_ChiTietCatTams.Any(item => item.CHDB.MaDon == MaDon && item.DanhBo == DanhBo);
                case "TXL":
                    return db.CHDB_ChiTietCatTams.Any(item => item.CHDB.MaDonTXL == MaDon && item.DanhBo == DanhBo);
                case "TBC":
                    return db.CHDB_ChiTietCatTams.Any(item => item.CHDB.MaDonTBC == MaDon && item.DanhBo == DanhBo);
                default:
                    return false;
            }
        }

        public CHDB_ChiTietCatTam GetCTCTDB(decimal MaCTCTDB)
        {
            return db.CHDB_ChiTietCatTams.SingleOrDefault(item => item.MaCTCTDB == MaCTCTDB);
        }

        public decimal getMaxMaCTCTDB()
        {
            try
            {
                return db.CHDB_ChiTietCatTams.Max(itemCTCTDB => itemCTCTDB.MaCTCTDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Chi Tiết Cắt Tạm Danh Bộ
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSCTCTDB()
        {
            try
            {
                var query = from itemCTCTDB in db.CHDB_ChiTietCatTams
                            //where itemCTCTDB.CHDB.MaDon!=null
                            orderby itemCTCTDB.CreateDate descending
                            select new
                            {
                                In = false,
                                itemCTCTDB.PhieuDuocKy,
                                itemCTCTDB.DaLapPhieu,
                                itemCTCTDB.SoPhieu,
                                itemCTCTDB.ThongBaoDuocKy,
                                MaTB = itemCTCTDB.MaCTCTDB,
                                Ma = itemCTCTDB.MaCTCTDB,
                                itemCTCTDB.CreateDate,
                                itemCTCTDB.DanhBo,
                                itemCTCTDB.HoTen,
                                itemCTCTDB.DiaChi,
                                itemCTCTDB.LyDo,
                                itemCTCTDB.GhiChuLyDo,
                                itemCTCTDB.SoTien,
                                itemCTCTDB.NguoiKy,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDS_CatTam(string To, decimal MaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from item in db.CHDB_ChiTietCatTams
                                where item.CHDB.MaDon == MaDon
                                select new
                                {
                                    MaDon = "TKH" + item.CHDB.MaDon,
                                    item.PhieuDuocKy,
                                    item.DaLapPhieu,
                                    item.SoPhieu,
                                    item.ThongBaoDuocKy,
                                    ID = item.MaCTCTDB,
                                    item.CreateDate,
                                    item.DanhBo,
                                    item.HoTen,
                                    item.DiaChi,
                                    item.LyDo,
                                    item.GhiChuLyDo,
                                    item.SoTien,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from item in db.CHDB_ChiTietCatTams
                            where item.CHDB.MaDonTXL == MaDon
                            select new
                            {
                                MaDon = "TXL" + item.CHDB.MaDonTXL,
                                item.PhieuDuocKy,
                                item.DaLapPhieu,
                                item.SoPhieu,
                                item.ThongBaoDuocKy,
                                ID = item.MaCTCTDB,
                                item.CreateDate,
                                item.DanhBo,
                                item.HoTen,
                                item.DiaChi,
                                item.LyDo,
                                item.GhiChuLyDo,
                                item.SoTien,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from item in db.CHDB_ChiTietCatTams
                            where item.CHDB.MaDonTBC == MaDon
                            select new
                            {
                                MaDon = "TBC" + item.CHDB.MaDonTBC,
                                item.PhieuDuocKy,
                                item.DaLapPhieu,
                                item.SoPhieu,
                                item.ThongBaoDuocKy,
                                ID = item.MaCTCTDB,
                                item.CreateDate,
                                item.DanhBo,
                                item.HoTen,
                                item.DiaChi,
                                item.LyDo,
                                item.GhiChuLyDo,
                                item.SoTien,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.CHDB_ChiTietCatTams
                            where item.CHDB.MaDonMoi == MaDon
                            select new
                            {
                                MaDon= db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ?  item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT,
                                item.PhieuDuocKy,
                                item.DaLapPhieu,
                                item.SoPhieu,
                                item.ThongBaoDuocKy,
                                ID = item.MaCTCTDB,
                                item.CreateDate,
                                item.DanhBo,
                                item.HoTen,
                                item.DiaChi,
                                item.LyDo,
                                item.GhiChuLyDo,
                                item.SoTien,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_CatTam(decimal MaCTCTDB)
        {
            var query = from item in db.CHDB_ChiTietCatTams
                        where item.MaCTCTDB == MaCTCTDB
                        select new
                        {
                            MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
                                    : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            ID = item.MaCTCTDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                            item.NguoiKy
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_CatTam(decimal FromMaCTCTDB, decimal ToMaCTCTDB)
        {
            var query = from item in db.CHDB_ChiTietCatTams
                        where item.MaCTCTDB.ToString().Substring(item.MaCTCTDB.ToString().Length - 2, 2) == FromMaCTCTDB.ToString().Substring(FromMaCTCTDB.ToString().Length - 2, 2)
                            && item.MaCTCTDB.ToString().Substring(item.MaCTCTDB.ToString().Length - 2, 2) == ToMaCTCTDB.ToString().Substring(ToMaCTCTDB.ToString().Length - 2, 2)
                            && item.MaCTCTDB >= FromMaCTCTDB && item.MaCTCTDB <= ToMaCTCTDB
                        select new
                        {
                            MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
                                    : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            ID = item.MaCTCTDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_CatTam_DanhBo(string DanhBo)
        {
            var query = from item in db.CHDB_ChiTietCatTams
                        where item.DanhBo == DanhBo
                        select new
                        {
                            MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
                                    : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            ID = item.MaCTCTDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_CatTam_LyDo(string LyDo)
        {
            var query = from item in db.CHDB_ChiTietCatTams
                        where item.LyDo.Contains(LyDo)
                        select new
                        {
                            MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
                                    : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            ID = item.MaCTCTDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_CatTam(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.CHDB_ChiTietCatTams
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            ID = item.MaCTCTDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                            item.NoiDungXuLy,
                            item.NguoiKy
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_CatTam(string MaQuan,DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.CHDB_ChiTietCatTams
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        && item.Quan==MaQuan
                        select new
                        {
                            MaDon = item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            ID = item.MaCTCTDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                            item.NoiDungXuLy,
                            item.NguoiKy
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSCatTam_NgayLap_ChuaXuLy(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatTams.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.NgayXuLy == null).OrderBy(item => item.CreateDate).ToList());
        }

        public DataTable GetDSCatTam_NgayLap_LyDo_ChuaXuLy(DateTime FromCreateDate, DateTime ToCreateDate, string LyDo)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatTams.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.NgayXuLy == null && item.LyDo.Contains(LyDo)).OrderBy(item => item.CreateDate).ToList());
        }

        public DataTable GetDSCatTam_NgayLap_Quan_ChuaXuLy(DateTime FromCreateDate, DateTime ToCreateDate, string MaQuan)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatTams.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date &&item.Quan==MaQuan && item.NgayXuLy == null).OrderBy(item => item.CreateDate).ToList());
            //string sql = "select t1.*,t3.TenQuan from CHDB_ChiTietCatTam t1"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
            //            + " join SERVER8.CAPNUOCTANHOA.dbo.QUAN t3 on t2.QUAN=t3.MAQUAN"
            //            + " where CAST(t1.CreateDate as date)>='" + FromCreateDate.ToString("yyyy-MM-dd") + "' and CAST(t1.CreateDate as date)<='" + ToCreateDate.ToString("yyyy-MM-dd") + "' and NgayXuLy is null"
            //            + " and MaQuan=" + MaQuan + ""
            //            + " order by t1.CreateDate";

            //return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSCatTam_NgayLap_ChuaXuLy(DateTime FromCreateDate, DateTime ToCreateDate, string MaQuan, string LyDo)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatTams.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date&&item.Quan==MaQuan && item.NgayXuLy == null && item.LyDo.Contains(LyDo)).OrderBy(item => item.CreateDate).ToList());
            //string sql = "select t1.*,t3.TenQuan from CHDB_ChiTietCatTam t1"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
            //            + " join SERVER8.CAPNUOCTANHOA.dbo.QUAN t3 on t2.QUAN=t3.MAQUAN"
            //            + " where CAST(t1.CreateDate as date)>='" + FromCreateDate.ToString("yyyy-MM-dd") + "' and CAST(t1.CreateDate as date)<='" + ToCreateDate.ToString("yyyy-MM-dd") + "' and NgayXuLy is null and LyDo like N'%" + LyDo + "%'"
            //            + " and MaQuan=" + MaQuan + ""
            //            + " order by t1.CreateDate";

            //return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSCatTam_NgayLap_DaXuLy(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatTams.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.NgayXuLy != null).OrderBy(item => item.CreateDate).ToList());
        }

        public DataTable GetDSCatTam_NgayLap_LyDo_DaXuLy(DateTime FromCreateDate, DateTime ToCreateDate, string LyDo)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatTams.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.NgayXuLy != null && item.LyDo.Contains(LyDo)).OrderBy(item => item.CreateDate).ToList());
        }

        public DataTable GetDSCatTam_NgayLap_Quan_DaXuLy(DateTime FromCreateDate, DateTime ToCreateDate, string MaQuan)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatTams.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date &&item.Quan==MaQuan&& item.NgayXuLy != null).OrderBy(item => item.CreateDate).ToList());
            //string sql = "select t1.*,t3.TenQuan from CHDB_ChiTietCatTam t1"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
            //            + " join SERVER8.CAPNUOCTANHOA.dbo.QUAN t3 on t2.QUAN=t3.MAQUAN"
            //            + " where CAST(t1.CreateDate as date)>='" + FromCreateDate.ToString("yyyy-MM-dd") + "' and CAST(t1.CreateDate as date)<='" + ToCreateDate.ToString("yyyy-MM-dd") + "' and NgayXuLy is not null"
            //            + " and MaQuan=" + MaQuan + ""
            //            + " order by t1.CreateDate";

            //return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSCatTam_NgayLap_DaXuLy(DateTime FromCreateDate, DateTime ToCreateDate, string MaQuan, string LyDo)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatTams.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date &&item.Quan==MaQuan&& item.NgayXuLy != null && item.LyDo.Contains(LyDo)).OrderBy(item => item.CreateDate).ToList());
            //string sql = "select t1.*,t3.TenQuan from CHDB_ChiTietCatTam t1"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
            //            + " join SERVER8.CAPNUOCTANHOA.dbo.QUAN t3 on t2.QUAN=t3.MAQUAN"
            //            + " where CAST(t1.CreateDate as date)>='" + FromCreateDate.ToString("yyyy-MM-dd") + "' and CAST(t1.CreateDate as date)<='" + ToCreateDate.ToString("yyyy-MM-dd") + "' and NgayXuLy is not null and LyDo like N'%" + LyDo + "%'"
            //            + " and MaQuan=" + MaQuan + ""
            //            + " order by t1.CreateDate";

            //return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSCatTam_NgayXuLy_DaXuLy(DateTime FromNgayXuLy, DateTime ToNgayXuLy)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatTams.Where(item => item.NgayXuLy.Value.Date >= FromNgayXuLy.Date && item.NgayXuLy.Value.Date <= ToNgayXuLy.Date).OrderBy(item => item.CreateDate).ToList());
        }

        public DataTable GetDSCatTam_NgayXuLy_Quan_DaXuLy(DateTime FromNgayXuLy, DateTime ToNgayXuLy, string MaQuan)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatTams.Where(item => item.NgayXuLy.Value.Date >= FromNgayXuLy.Date && item.NgayXuLy.Value.Date <= ToNgayXuLy.Date&&item.Quan==MaQuan).OrderBy(item => item.CreateDate).ToList());
            //string sql = "select t1.*,t3.TenQuan from CHDB_ChiTietCatTam t1"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
            //            + " join SERVER8.CAPNUOCTANHOA.dbo.QUAN t3 on t2.QUAN=t3.MAQUAN"
            //            + " where CAST(t1.NgayXuLy as date)>='" + FromNgayXuLy.ToString("yyyy-MM-dd") + "' and CAST(t1.NgayXuLy as date)<='" + ToNgayXuLy.ToString("yyyy-MM-dd") + "'"
            //            + " and MaQuan=" + MaQuan + ""
            //            + " order by t1.CreateDate";

            //return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSCatTam_NgayXuLy_NoiDung_DaXuLy(DateTime FromNgayXuLy, DateTime ToNgayXuLy,string NoiDungXuLy)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatTams.Where(item => item.NgayXuLy.Value.Date >= FromNgayXuLy.Date && item.NgayXuLy.Value.Date <= ToNgayXuLy.Date && item.NoiDungXuLy == NoiDungXuLy).OrderBy(item => item.CreateDate).ToList());
        }

        public DataTable GetDSCatTam_NgayXuLy_DaXuLy(DateTime FromNgayXuLy, DateTime ToNgayXuLy, string MaQuan, string NoiDungXuLy)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatTams.Where(item => item.NgayXuLy.Value.Date >= FromNgayXuLy.Date && item.NgayXuLy.Value.Date <= ToNgayXuLy.Date &&item.Quan==MaQuan&& item.NoiDungXuLy == NoiDungXuLy).OrderBy(item => item.CreateDate).ToList());
            //string sql = "select t1.*,t3.TenQuan from CHDB_ChiTietCatTam t1"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
            //            + " join SERVER8.CAPNUOCTANHOA.dbo.QUAN t3 on t2.QUAN=t3.MAQUAN"
            //            + " where CAST(t1.NgayXuLy as date)>='" + FromNgayXuLy.ToString("yyyy-MM-dd") + "' and CAST(t1.NgayXuLy as date)<='" + ToNgayXuLy.ToString("yyyy-MM-dd") + "' and NoiDungXuLy like N'%" + NoiDungXuLy + "%'"
            //            + " and MaQuan=" + MaQuan + ""
            //            + " order by t1.CreateDate";

            //return ExecuteQuery_DataTable(sql);
        }

        public DataTable getCatTam_BaoCao(DateTime FromDate, DateTime ToDate)
        {
            string sql = "declare @FromDate datetime"
                        + " declare @ToDate datetime"
                        + " set @FromDate='" + FromDate.ToString("yyyyMMdd") + "'"
                        + " set @ToDate='" + ToDate.ToString("yyyyMMdd") + "'"
                        + " declare @LuyKe int"
                        + " declare @Nhan int"
                        + " declare @XuLy int"
                        + " set @LuyKe=(select COUNT(MaCTCTDB) from CHDB_ChiTietCatTam where CAST(CreateDate as date)<@FromDate and (NgayXuLy is null or CAST(NgayXuLy as date)>@ToDate))"
                        + " set @Nhan=(select COUNT(MaCTCTDB) from CHDB_ChiTietCatTam where CAST(CreateDate as date)>=@FromDate and CAST(CreateDate as date)<=@ToDate)"
                        + " set @XuLy=(select COUNT(MaCTCTDB) from CHDB_ChiTietCatTam where CAST(NgayXuLy as date)>=@FromDate and CAST(NgayXuLy as date)<=@ToDate)"
                        + " select LuyKe=@LuyKe,Nhan=@Nhan,XuLy=@XuLy,Ton=@LuyKe+@Nhan-@XuLy";
            return ExecuteQuery_DataTable(sql);
        }

        #endregion

        #region CHDB_ChiTietCatHuy (Chi Tiết Cắt Hủy Danh Bộ)

        public bool ThemCTCHDB(CHDB_ChiTietCatHuy ctchdb)
        {
            try
            {
                if (db.CHDB_ChiTietCatHuys.Count() > 0)
                {
                    string ID = "MaCTCHDB";
                    string Table = "CHDB_ChiTietCatHuy";
                    decimal MaCTCHDB = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    //decimal MaCTCHDB = db.CHDB_ChiTietCatHuys.Max(itemCTCHDB => itemCTCHDB.MaCTCHDB);
                    ctchdb.MaCTCHDB = getMaxNextIDTable(MaCTCHDB);
                }
                else
                    ctchdb.MaCTCHDB = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                ctchdb.CreateDate = DateTime.Now;
                ctchdb.CreateBy = CTaiKhoan.MaUser;
                db.CHDB_ChiTietCatHuys.InsertOnSubmit(ctchdb);
                db.SubmitChanges();
                //MessageBox.Show("Thành công Thêm CHDB_ChiTietCatHuy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool SuaCTCHDB(CHDB_ChiTietCatHuy ctchdb)
        {
            try
            {
                ctchdb.ModifyDate = DateTime.Now;
                ctchdb.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa CHDB_ChiTietCatHuy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool XoaCTCHDB(CHDB_ChiTietCatHuy ctchdb)
        {
            try
            {
                decimal ID = ctchdb.MaCHDB.Value;
                db.CHDB_ChiTietCatHuys.DeleteOnSubmit(ctchdb);
                db.SubmitChanges();
                if (db.CHDB_ChiTietCatTams.Any(item => item.MaCHDB == ID) == false && db.CHDB_ChiTietCatHuys.Any(item => item.MaCHDB == ID) == false && db.CHDB_Phieus.Any(item => item.MaCHDB == ID) == false)
                    db.CHDBs.DeleteOnSubmit(db.CHDBs.SingleOrDefault(item => item.MaCHDB == ID));
                db.SubmitChanges();
                //MessageBox.Show("Thành công Xóa CHDB_ChiTietCatHuy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool CheckExist_CTCHDB(decimal MaCTCHDB)
        {
            return db.CHDB_ChiTietCatHuys.Any(item => item.MaCTCHDB == MaCTCHDB);
        }

        public bool CheckExist_CTCHDB(string Loai, decimal MaDon, string DanhBo)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.CHDB_ChiTietCatHuys.Any(item => item.CHDB.MaDon == MaDon && item.DanhBo == DanhBo);
                case "TXL":
                    return db.CHDB_ChiTietCatHuys.Any(item => item.CHDB.MaDonTXL == MaDon && item.DanhBo == DanhBo);
                case "TBC":
                    return db.CHDB_ChiTietCatHuys.Any(item => item.CHDB.MaDonTBC == MaDon && item.DanhBo == DanhBo);
                default:
                    return false;
            }
        }

        public CHDB_ChiTietCatHuy GetCTCHDB(decimal MaCTCHDB)
        {
            return db.CHDB_ChiTietCatHuys.SingleOrDefault(item => item.MaCTCHDB == MaCTCHDB);
        }

        public decimal getMaxMaCTCHDB()
        {
            try
            {
                return db.CHDB_ChiTietCatHuys.Max(itemCTCHDB => itemCTCHDB.MaCTCHDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public DataTable getDS_CatHuy(string To, decimal MaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from item in db.CHDB_ChiTietCatHuys
                                where item.CHDB.MaDon == MaDon
                                select new
                                {
                                    MaDon = "TKH" + item.CHDB.MaDon,
                                    item.PhieuDuocKy,
                                    item.DaLapPhieu,
                                    item.SoPhieu,
                                    item.ThongBaoDuocKy,
                                    ID = item.MaCTCHDB,
                                    item.CreateDate,
                                    item.DanhBo,
                                    item.HoTen,
                                    item.DiaChi,
                                    item.LyDo,
                                    item.GhiChuLyDo,
                                    item.SoTien,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from item in db.CHDB_ChiTietCatHuys
                            where item.CHDB.MaDonTXL == MaDon
                            select new
                            {
                                MaDon = "TXL" + item.CHDB.MaDonTXL,
                                item.PhieuDuocKy,
                                item.DaLapPhieu,
                                item.SoPhieu,
                                item.ThongBaoDuocKy,
                                ID = item.MaCTCHDB,
                                item.CreateDate,
                                item.DanhBo,
                                item.HoTen,
                                item.DiaChi,
                                item.LyDo,
                                item.GhiChuLyDo,
                                item.SoTien,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from item in db.CHDB_ChiTietCatHuys
                            where item.CHDB.MaDonTBC == MaDon
                            select new
                            {
                                MaDon = "TBC" + item.CHDB.MaDonTBC,
                                item.PhieuDuocKy,
                                item.DaLapPhieu,
                                item.SoPhieu,
                                item.ThongBaoDuocKy,
                                ID = item.MaCTCHDB,
                                item.CreateDate,
                                item.DanhBo,
                                item.HoTen,
                                item.DiaChi,
                                item.LyDo,
                                item.GhiChuLyDo,
                                item.SoTien,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.CHDB_ChiTietCatHuys
                            where item.CHDB.MaDonMoi == MaDon
                            select new
                            {
                                MaDon = db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT,
                                item.PhieuDuocKy,
                                item.DaLapPhieu,
                                item.SoPhieu,
                                item.ThongBaoDuocKy,
                                ID = item.MaCTCHDB,
                                item.CreateDate,
                                item.DanhBo,
                                item.HoTen,
                                item.DiaChi,
                                item.LyDo,
                                item.GhiChuLyDo,
                                item.SoTien,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_CatHuy(decimal MaCTCHDB)
        {
            var query = from item in db.CHDB_ChiTietCatHuys
                        where item.MaCTCHDB == MaCTCHDB
                        select new
                        {
                            MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
                                    : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            ID = item.MaCTCHDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                            item.NguoiKy
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_CatHuy(decimal FromMaCTCHDB, decimal ToMaCTCHDB)
        {
            var query = from item in db.CHDB_ChiTietCatHuys
                        where item.MaCTCHDB.ToString().Substring(item.MaCTCHDB.ToString().Length - 2, 2) == FromMaCTCHDB.ToString().Substring(FromMaCTCHDB.ToString().Length - 2, 2)
                            && item.MaCTCHDB.ToString().Substring(item.MaCTCHDB.ToString().Length - 2, 2) == ToMaCTCHDB.ToString().Substring(ToMaCTCHDB.ToString().Length - 2, 2)
                            && item.MaCTCHDB >= FromMaCTCHDB && item.MaCTCHDB <= ToMaCTCHDB
                        select new
                        {
                            MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
                                    : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            ID = item.MaCTCHDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_CatHuy_DanhBo(string DanhBo)
        {
            var query = from item in db.CHDB_ChiTietCatHuys
                        where item.DanhBo == DanhBo
                        select new
                        {
                            MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
                                    : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            ID = item.MaCTCHDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_CatHuy_LyDo(string LyDo)
        {
            var query = from item in db.CHDB_ChiTietCatHuys
                        where item.LyDo.Contains(LyDo)
                        select new
                        {
                            MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
                                    : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            ID = item.MaCTCHDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_CatHuy(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.CHDB_ChiTietCatHuys
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
                                    : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            ID = item.MaCTCHDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                            item.NoiDungXuLy,
                            item.NguoiKy
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_CatHuy(string MaQuan,DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.CHDB_ChiTietCatHuys
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        && item.Quan==MaQuan
                        select new
                        {
                            MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
                                    : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            ID = item.MaCTCHDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                            item.NoiDungXuLy,
                            item.NguoiKy
                        };
            return LINQToDataTable(query);
        }

        ///// <summary>
        ///// Lấy Số Phiếu kế tiếp khi lập Cắt Hủy Danh Bộ
        ///// </summary>
        ///// <returns></returns>
        //public decimal getMaxNextSoPhieuCHDB()
        //{
        //    try
        //    {
        //        if (db.CHDB_ChiTietCatHuys.Count() > 0)
        //        {
        //            if (db.CHDB_ChiTietCatHuys.Max(itemCTCHDB => itemCTCHDB.SoPhieu) == null)
        //                return decimal.Parse("1" + DateTime.Now.ToString("yy"));
        //            else
        //                return getMaxNextIDTable(db.CHDB_ChiTietCatHuys.Max(itemCTCHDB => itemCTCHDB.SoPhieu).Value);
        //        }
        //        else
        //            return decimal.Parse("1" + DateTime.Now.ToString("yy"));
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return 0;
        //    }
        //}

        ///// <summary>
        ///// Kiểm Tra Cắt Hủy Danh Bộ đã lập Phiếu chưa
        ///// </summary>
        ///// <param name="MaCTCHDB"></param>
        ///// <returns></returns>
        //public bool CheckDaLapPhieuCHDB(decimal MaCTCHDB)
        //{
        //    try
        //    {
        //        return db.CHDB_ChiTietCatHuys.Any(itemCTCHDB => itemCTCHDB.MaCTCHDB == MaCTCHDB && itemCTCHDB.DaLapPhieu == true);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}

        public DataTable GetDSCatHuy_NgayLap_ChuaXuLy(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatHuys.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.NgayXuLy == null).OrderBy(item => item.CreateDate).ToList());
        }

        public DataTable GetDSCatHuy_NgayLap_LyDo_ChuaXuLy(DateTime FromCreateDate, DateTime ToCreateDate, string LyDo)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatHuys.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.NgayXuLy == null && item.LyDo.Contains(LyDo)).OrderBy(item => item.CreateDate).ToList());
        }

        public DataTable GetDSCatHuy_NgayLap_Quan_ChuaXuLy(DateTime FromCreateDate, DateTime ToCreateDate, string MaQuan)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatHuys.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date &&item.Quan==MaQuan&& item.NgayXuLy == null).OrderBy(item => item.CreateDate).ToList());
            //string sql = "select t1.*,t3.TenQuan from CHDB_ChiTietCatHuy t1"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
            //            + " join SERVER8.CAPNUOCTANHOA.dbo.QUAN t3 on t2.QUAN=t3.MAQUAN"
            //            + " where CAST(t1.CreateDate as date)>='" + FromCreateDate.ToString("yyyy-MM-dd") + "' and CAST(t1.CreateDate as date)<='" + ToCreateDate.ToString("yyyy-MM-dd") + "' and NgayXuLy is null"
            //            + " and MaQuan=" + MaQuan + ""
            //            + " order by t1.CreateDate";

            //return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSCatHuy_NgayLap_ChuaXuLy(DateTime FromCreateDate, DateTime ToCreateDate, string MaQuan, string LyDo)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatHuys.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date &&item.Quan==MaQuan && item.NgayXuLy == null && item.LyDo.Contains(LyDo)).OrderBy(item => item.CreateDate).ToList());
            //string sql = "select t1.*,t3.TenQuan from CHDB_ChiTietCatHuy t1"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
            //            + " join SERVER8.CAPNUOCTANHOA.dbo.QUAN t3 on t2.QUAN=t3.MAQUAN"
            //            + " where CAST(t1.CreateDate as date)>='" + FromCreateDate.ToString("yyyy-MM-dd") + "' and CAST(t1.CreateDate as date)<='" + ToCreateDate.ToString("yyyy-MM-dd") + "' and NgayXuLy is null and LyDo like N'%" + LyDo + "%'"
            //            + " and MaQuan=" + MaQuan + ""
            //            + " order by t1.CreateDate";

            //return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSCatHuy_NgayLap_DaXuLy(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatHuys.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.NgayXuLy != null).OrderBy(item => item.CreateDate).ToList());
        }

        public DataTable GetDSCatHuy_NgayLap_LyDo_DaXuLy(DateTime FromCreateDate, DateTime ToCreateDate, string LyDo)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatHuys.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.NgayXuLy != null && item.LyDo.Contains(LyDo)).OrderBy(item => item.CreateDate).ToList());
        }

        public DataTable GetDSCatHuy_NgayLap_Quan_DaXuLy(DateTime FromCreateDate, DateTime ToCreateDate, string MaQuan)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatHuys.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.Quan==MaQuan && item.NgayXuLy != null).OrderBy(item => item.CreateDate).ToList());
            //string sql = "select t1.*,t3.TenQuan from CHDB_ChiTietCatHuy t1"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
            //            + " join SERVER8.CAPNUOCTANHOA.dbo.QUAN t3 on t2.QUAN=t3.MAQUAN"
            //            + " where CAST(t1.CreateDate as date)>='" + FromCreateDate.ToString("yyyy-MM-dd") + "' and CAST(t1.CreateDate as date)<='" + ToCreateDate.ToString("yyyy-MM-dd") + "' and NgayXuLy is not null"
            //            + " and MaQuan=" + MaQuan + ""
            //            + " order by t1.CreateDate";

            //return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSCatHuy_NgayLap_DaXuLy(DateTime FromCreateDate, DateTime ToCreateDate, string MaQuan, string LyDo)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatHuys.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date &&item.Quan==MaQuan && item.NgayXuLy != null && item.LyDo.Contains(LyDo)).OrderBy(item => item.CreateDate).ToList());
            //string sql = "select t1.*,t3.TenQuan from CHDB_ChiTietCatHuy t1"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
            //            + " join SERVER8.CAPNUOCTANHOA.dbo.QUAN t3 on t2.QUAN=t3.MAQUAN"
            //            + " where CAST(t1.CreateDate as date)>='" + FromCreateDate.ToString("yyyy-MM-dd") + "' and CAST(t1.CreateDate as date)<='" + ToCreateDate.ToString("yyyy-MM-dd") + "' and NgayXuLy is not null and LyDo like N'%" + LyDo + "%'"
            //            + " and MaQuan=" + MaQuan + ""
            //            + " order by t1.CreateDate";

            //return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSCatHuy_NgayXuLy_DaXuLy(DateTime FromNgayXuLy, DateTime ToNgayXuLy)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatHuys.Where(item => item.NgayXuLy.Value.Date >= FromNgayXuLy.Date && item.NgayXuLy.Value.Date <= ToNgayXuLy.Date).OrderBy(item => item.CreateDate).ToList());
        }

        public DataTable GetDSCatHuy_NgayXuLy_Quan_DaXuLy(DateTime FromNgayXuLy, DateTime ToNgayXuLy,string MaQuan)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatHuys.Where(item => item.NgayXuLy.Value.Date >= FromNgayXuLy.Date && item.NgayXuLy.Value.Date <= ToNgayXuLy.Date && item.Quan==MaQuan).OrderBy(item => item.CreateDate).ToList());
            //string sql = "select t1.*,t3.TenQuan from CHDB_ChiTietCatHuy t1"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
            //            + " join SERVER8.CAPNUOCTANHOA.dbo.QUAN t3 on t2.QUAN=t3.MAQUAN"
            //            + " where CAST(t1.NgayXuLy as date)>='" + FromNgayXuLy.ToString("yyyy-MM-dd") + "' and CAST(t1.NgayXuLy as date)<='" + ToNgayXuLy.ToString("yyyy-MM-dd") + "'"
            //            + " and MaQuan=" + MaQuan + ""
            //            + " order by t1.CreateDate";

            //return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSCatHuy_NgayXuLy_NoiDung_DaXuLy(DateTime FromNgayXuLy, DateTime ToNgayXuLy, string NoiDungXuLy)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatHuys.Where(item => item.NgayXuLy.Value.Date >= FromNgayXuLy.Date && item.NgayXuLy.Value.Date <= ToNgayXuLy.Date && item.NoiDungXuLy == NoiDungXuLy).OrderBy(item => item.CreateDate).ToList());
        }

        public DataTable GetDSCatHuy_NgayXuLy_DaXuLy(DateTime FromNgayXuLy, DateTime ToNgayXuLy, string MaQuan, string NoiDungXuLy)
        {
            return LINQToDataTable(db.CHDB_ChiTietCatHuys.Where(item => item.NgayXuLy.Value.Date >= FromNgayXuLy.Date && item.NgayXuLy.Value.Date <= ToNgayXuLy.Date&&item.Quan==MaQuan && item.NoiDungXuLy == NoiDungXuLy).OrderBy(item => item.CreateDate).ToList());
            //string sql = "select t1.*,t3.TenQuan from CHDB_ChiTietCatHuy t1"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
            //            + " join SERVER8.CAPNUOCTANHOA.dbo.QUAN t3 on t2.QUAN=t3.MAQUAN"
            //            + " where CAST(t1.NgayXuLy as date)>='" + FromNgayXuLy.ToString("yyyy-MM-dd") + "' and CAST(t1.NgayXuLy as date)<='" + ToNgayXuLy.ToString("yyyy-MM-dd") + "' and NoiDungXuLy like N'%" + NoiDungXuLy + "%'"
            //            + " and MaQuan=" + MaQuan + ""
            //            + " order by t1.CreateDate";

            //return ExecuteQuery_DataTable(sql);
        }

        public DataTable getCatHuy_BaoCao(DateTime FromDate, DateTime ToDate)
        {
            string sql = "declare @FromDate datetime"
                        + " declare @ToDate datetime"
                        + " set @FromDate='" + FromDate.ToString("yyyyMMdd") + "'"
                        + " set @ToDate='" + ToDate.ToString("yyyyMMdd") + "'"
                        + " declare @LuyKe int"
                        + " declare @Nhan int"
                        + " declare @XuLy int"
                        + " set @LuyKe=(select COUNT(MaCTCTDB) from CHDB_ChiTietCatHuy where CAST(CreateDate as date)<@FromDate and (NgayXuLy is null or CAST(NgayXuLy as date)>@ToDate))"
                        + " set @Nhan=(select COUNT(MaCTCTDB) from CHDB_ChiTietCatHuy where CAST(CreateDate as date)>=@FromDate and CAST(CreateDate as date)<=@ToDate)"
                        + " set @XuLy=(select COUNT(MaCTCTDB) from CHDB_ChiTietCatHuy where CAST(NgayXuLy as date)>=@FromDate and CAST(NgayXuLy as date)<=@ToDate)"
                        + " select LuyKe=@LuyKe,Nhan=@Nhan,XuLy=@XuLy,Ton=@LuyKe+@Nhan-@XuLy";
            return ExecuteQuery_DataTable(sql);
        }

        #endregion

        #region YeuCauCHDB (Phiếu Yêu Cầu Cắt Hủy Danh Bộ)

        public bool ThemPhieuHuy(CHDB_Phieu ycchdb)
        {
            try
            {
                if (db.CHDB_Phieus.Count() > 0)
                {
                    string ID = "MaYCCHDB";
                    string Table = "CHDB_Phieu";
                    decimal MaYCCHDB = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    ycchdb.MaYCCHDB = getMaxNextIDTable(MaYCCHDB);
                }
                else
                    ycchdb.MaYCCHDB = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                ycchdb.CreateDate = DateTime.Now;
                ycchdb.CreateBy = CTaiKhoan.MaUser;
                db.CHDB_Phieus.InsertOnSubmit(ycchdb);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool SuaPhieuHuy(CHDB_Phieu ycchdb)
        {
            try
            {
                ycchdb.ModifyDate = DateTime.Now;
                ycchdb.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool XoaPhieuHuy(CHDB_Phieu ycchdb)
        {
            try
            {
                decimal ID = ycchdb.MaCHDB.Value;
                db.CHDB_Phieus.DeleteOnSubmit(ycchdb);
                db.SubmitChanges();
                if (db.CHDB_ChiTietCatTams.Any(item => item.MaCHDB == ID) == false && db.CHDB_ChiTietCatHuys.Any(item => item.MaCHDB == ID) == false && db.CHDB_Phieus.Any(item => item.MaCHDB == ID) == false)
                    db.CHDBs.DeleteOnSubmit(db.CHDBs.SingleOrDefault(item => item.MaCHDB == ID));
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra Thông Báo CTDB có được lấp Phiếu Yếu Cầu CHDB không
        /// </summary>
        /// <param name="MaCTCTDB"></param>
        /// <returns></returns>
        public bool CheckExist_PhieuHuyByMaCTCTDB(decimal MaCTCTDB)
        {
            try
            {
                return db.CHDB_Phieus.Any(itemYCCHDB => itemYCCHDB.MaCTCTDB == MaCTCTDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra Thông Báo CHDB có được lấp Phiếu Yếu Cầu CHDB không
        /// </summary>
        /// <param name="MaCTCHDB"></param>
        /// <returns></returns>
        public bool CheckExist_PhieuHuyByMaCTCHDB(decimal MaCTCHDB)
        {
            try
            {
                return db.CHDB_Phieus.Any(itemYCCHDB => itemYCCHDB.MaCTCHDB == MaCTCHDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist_PhieuHuy(decimal MaYCCHDB)
        {
            return db.CHDB_Phieus.Any(item => item.MaYCCHDB == MaYCCHDB);
        }

        public bool CheckExist_PhieuHuy(string Loai, decimal MaDon, string DanhBo)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.CHDB_Phieus.Any(item => item.MaDon == MaDon && item.DanhBo == DanhBo);
                case "TXL":
                    return db.CHDB_Phieus.Any(item => item.MaDonTXL == MaDon && item.DanhBo == DanhBo);
                case "TBC":
                    return db.CHDB_Phieus.Any(item => item.MaDonTBC == MaDon && item.DanhBo == DanhBo);
                default:
                    return false;
            }
        }

        public CHDB_Phieu GetPhieuHuy(decimal MaYCCHDB)
        {
            try
            {
                return db.CHDB_Phieus.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaYCCHDB == MaYCCHDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public CHDB_Phieu GetPhieuHuyByMaCTCTDB(decimal MaCTCTDB)
        {
            return db.CHDB_Phieus.Where(itemYCCHDB => itemYCCHDB.MaCTCTDB == MaCTCTDB).OrderBy(item => item.CreateDate).ToList().Last();
        }

        public CHDB_Phieu GetPhieuHuyByMaCTCHDB(decimal MaCTCHDB)
        {
            return db.CHDB_Phieus.Where(itemYCCHDB => itemYCCHDB.MaCTCHDB == MaCTCHDB).OrderBy(item => item.CreateDate).ToList().Last();
        }

        /// <summary>
        /// Lấy Danh Sách Yêu Cầu Cắt Hủy Danh Bộ trực tiếp không qua Thông Báo
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSYCCHDB()
        {
            try
            {
                var query = from itemYCCHDB in db.CHDB_Phieus
                            orderby itemYCCHDB.CreateDate descending
                            select new
                            {
                                In = false,
                                itemYCCHDB.PhieuDuocKy,
                                SoPhieu = itemYCCHDB.MaYCCHDB,
                                Ma = itemYCCHDB.MaYCCHDB,
                                itemYCCHDB.CreateDate,
                                itemYCCHDB.DanhBo,
                                itemYCCHDB.HoTen,
                                itemYCCHDB.DiaChi,
                                itemYCCHDB.LyDo,
                                itemYCCHDB.GhiChuLyDo,
                                itemYCCHDB.SoTien,
                                itemYCCHDB.NguoiKy,
                                itemYCCHDB.NgayCatTamNutBit,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDS_PhieuHuy(string To, decimal MaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from item in db.CHDB_Phieus
                                where item.CHDB.MaDon == MaDon
                                select new
                                {
                                    MaDon = "TKH" + item.CHDB.MaDon,
                                    item.PhieuDuocKy,
                                    ID = item.MaYCCHDB,
                                    item.CreateDate,
                                    item.DanhBo,
                                    item.HoTen,
                                    item.DiaChi,
                                    item.LyDo,
                                    item.GhiChuLyDo,
                                    item.SoTien,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from item in db.CHDB_Phieus
                            where item.CHDB.MaDonTXL == MaDon
                            select new
                            {
                                MaDon = "TXL" + item.CHDB.MaDonTXL,
                                item.PhieuDuocKy,
                                ID = item.MaYCCHDB,
                                item.CreateDate,
                                item.DanhBo,
                                item.HoTen,
                                item.DiaChi,
                                item.LyDo,
                                item.GhiChuLyDo,
                                item.SoTien,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from item in db.CHDB_Phieus
                            where item.CHDB.MaDonTBC == MaDon
                            select new
                            {
                                MaDon = "TBC" + item.CHDB.MaDonTBC,
                                item.PhieuDuocKy,
                                ID = item.MaYCCHDB,
                                item.CreateDate,
                                item.DanhBo,
                                item.HoTen,
                                item.DiaChi,
                                item.LyDo,
                                item.GhiChuLyDo,
                                item.SoTien,
                            };
                    return LINQToDataTable(query);
                default:
                   query = from item in db.CHDB_Phieus
                            where item.CHDB.MaDonMoi == MaDon
                            select new
                            {
                                MaDon = db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT,
                                item.PhieuDuocKy,
                                ID = item.MaYCCHDB,
                                item.CreateDate,
                                item.DanhBo,
                                item.HoTen,
                                item.DiaChi,
                                item.LyDo,
                                item.GhiChuLyDo,
                                item.SoTien,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_PhieuHuy(decimal MaYCCHDB)
        {
            var query = from item in db.CHDB_Phieus
                        where item.MaYCCHDB == MaYCCHDB
                        select new
                        {
                            MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
                                    : item.MaDon != null ? "TKH" + item.MaDon
                                    : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                    : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                            item.PhieuDuocKy,
                            ID = item.MaYCCHDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_PhieuHuy(decimal FromMaYCCHDB, decimal ToMaYCCHDB)
        {
            var query = from item in db.CHDB_Phieus
                        where item.MaYCCHDB.ToString().Substring(item.MaYCCHDB.ToString().Length - 2, 2) == FromMaYCCHDB.ToString().Substring(FromMaYCCHDB.ToString().Length - 2, 2)
                            && item.MaYCCHDB.ToString().Substring(item.MaYCCHDB.ToString().Length - 2, 2) == ToMaYCCHDB.ToString().Substring(ToMaYCCHDB.ToString().Length - 2, 2)
                            && item.MaYCCHDB >= FromMaYCCHDB && item.MaYCCHDB <= ToMaYCCHDB
                        select new
                        {
                            MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
                                    : item.MaDon != null ? "TKH" + item.MaDon
                                    : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                    : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                            item.PhieuDuocKy,
                            ID = item.MaYCCHDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_PhieuHuy(string DanhBo)
        {
            var query = from item in db.CHDB_Phieus
                        where item.DanhBo == DanhBo
                        select new
                        {
                            MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
                                    : item.MaDon != null ? "TKH" + item.MaDon
                                    : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                    : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                            item.PhieuDuocKy,
                            ID = item.MaYCCHDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_PhieuHuy(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.CHDB_Phieus
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
                                    : item.MaDon != null ? "TKH" + item.MaDon
                                    : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                    : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                            item.PhieuDuocKy,
                            ID = item.MaYCCHDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_PhieuHuy(string MaQuan,DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.CHDB_Phieus
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        && item.Quan==MaQuan
                        select new
                        {
                            MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
                                    : item.MaDon != null ? "TKH" + item.MaDon
                                    : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                    : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                            item.PhieuDuocKy,
                            ID = item.MaYCCHDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                        };
            return LINQToDataTable(query);
        }

        /// <summary>
        /// Lấy Danh Sách Yêu Cầu Cắt Hủy Danh Bộ trực tiếp không qua Thông Báo trong Ngày
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSYCCHDB_Don(DateTime TuNgay)
        {
            try
            {
                var query = from itemYCCHDB in db.CHDB_Phieus
                            where itemYCCHDB.CreateDate.Value.Date == TuNgay.Date //&& (itemYCCHDB.MaDon != null || itemYCCHDB.MaDonTXL != null)
                            select new
                            {
                                In = false,
                                itemYCCHDB.PhieuDuocKy,
                                ID = itemYCCHDB.MaYCCHDB,
                                itemYCCHDB.CreateDate,
                                itemYCCHDB.DanhBo,
                                itemYCCHDB.HoTen,
                                itemYCCHDB.DiaChi,
                                itemYCCHDB.LyDo,
                                itemYCCHDB.GhiChuLyDo,
                                itemYCCHDB.SoTien,
                                itemYCCHDB.NguoiKy,
                                itemYCCHDB.HieuLucKy,
                                itemYCCHDB.NoiDungTroNgai,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Yêu Cầu Cắt Hủy Danh Bộ trực tiếp không qua Thông Báo trong Khoảng Thời Gian
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSYCCHDB_Don(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                var query = from itemYCCHDB in db.CHDB_Phieus
                            where itemYCCHDB.CreateDate.Value.Date >= TuNgay.Date && itemYCCHDB.CreateDate.Value.Date <= DenNgay.Date //&& (itemYCCHDB.MaDon != null || itemYCCHDB.MaDonTXL != null)
                            select new
                            {
                                In = false,
                                itemYCCHDB.PhieuDuocKy,
                                ID = itemYCCHDB.MaYCCHDB,
                                itemYCCHDB.CreateDate,
                                itemYCCHDB.DanhBo,
                                itemYCCHDB.HoTen,
                                itemYCCHDB.DiaChi,
                                itemYCCHDB.LyDo,
                                itemYCCHDB.GhiChuLyDo,
                                itemYCCHDB.SoTien,
                                itemYCCHDB.NguoiKy,
                                itemYCCHDB.HieuLucKy,
                                itemYCCHDB.NoiDungTroNgai,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Yêu Cầu Cắt Hủy Danh Bộ bao gồm qua Thông Báo trong Ngày
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSYCCHDB(DateTime TuNgay)
        {
            try
            {
                var query = from itemYCCHDB in db.CHDB_Phieus
                            where itemYCCHDB.CreateDate.Value.Date == TuNgay.Date
                            select new
                            {
                                In = false,
                                itemYCCHDB.PhieuDuocKy,
                                ID = itemYCCHDB.MaYCCHDB,
                                itemYCCHDB.CreateDate,
                                itemYCCHDB.DanhBo,
                                itemYCCHDB.HoTen,
                                itemYCCHDB.DiaChi,
                                itemYCCHDB.LyDo,
                                itemYCCHDB.GhiChuLyDo,
                                itemYCCHDB.SoTien,
                                itemYCCHDB.NguoiKy,
                                itemYCCHDB.HieuLucKy,
                                itemYCCHDB.NgayCatTamNutBit,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Yêu Cầu Cắt Hủy Danh Bộ bao gồm qua Thông Báo trong Ngày
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSYCCHDB(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                var query = from itemYCCHDB in db.CHDB_Phieus
                            where itemYCCHDB.CreateDate.Value.Date >= TuNgay.Date && itemYCCHDB.CreateDate.Value.Date <= DenNgay.Date
                            select new
                            {
                                In = false,
                                itemYCCHDB.PhieuDuocKy,
                                ID = itemYCCHDB.MaYCCHDB,
                                itemYCCHDB.CreateDate,
                                itemYCCHDB.DanhBo,
                                itemYCCHDB.HoTen,
                                itemYCCHDB.DiaChi,
                                itemYCCHDB.LyDo,
                                itemYCCHDB.GhiChuLyDo,
                                itemYCCHDB.SoTien,
                                itemYCCHDB.NguoiKy,
                                itemYCCHDB.HieuLucKy,
                                itemYCCHDB.NgayCatTamNutBit,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion

        #region CHDB_GhiChu (GhiChu)

        public bool ThemGhiChu(CHDB_GhiChu item)
        {
            try
            {
                if (db.CHDB_GhiChus.Count() > 0)
                {
                    string ID = "ID";
                    string Table = "CHDB_GhiChu";
                    decimal MaCHDB = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    //decimal MaCHDB = db.CHDBs.Max(itemCHDB => itemCHDB.MaCHDB);
                    item.ID = getMaxNextIDTable(MaCHDB);
                }
                else
                    item.ID = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                item.CreateDate = DateTime.Now;
                item.CreateBy = CTaiKhoan.MaUser;
                db.CHDB_GhiChus.InsertOnSubmit(item);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SuaGhiChu(CHDB_GhiChu item)
        {
            try
            {
                item.ModifyDate = DateTime.Now;
                item.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaGhiChu(CHDB_GhiChu item)
        {
            try
            {
                db.CHDB_GhiChus.DeleteOnSubmit(item);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<CHDB_GhiChu> GetDSGhiChuByMaCTCTDB(decimal MaCTCTDB)
        {
            return db.CHDB_GhiChus.Where(item => item.MaCTCTDB == MaCTCTDB).OrderByDescending(item => item.NgayLap).ToList();
        }

        public List<CHDB_GhiChu> GetDSGhiChuByMaCTCHDB(decimal MaCTCHDB)
        {
            return db.CHDB_GhiChus.Where(item => item.MaCTCHDB == MaCTCHDB).OrderByDescending(item => item.NgayLap).ToList();
        }

        public CHDB_GhiChu GetGhiChuByID(decimal ID)
        {
            return db.CHDB_GhiChus.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetDSNoiDungGhiChu()
        {
            return LINQToDataTable(db.CHDB_GhiChus.Select(item => new { item.NoiDung }).ToList().Distinct());
        }

        public DataTable GetDSNoiNhanGhiChu()
        {
            return LINQToDataTable(db.CHDB_GhiChus.Select(item => new { item.NoiNhan }).ToList().Distinct());
        }

        #endregion

        public DataTable GetLichSuCHDB(string DanhBo)
        {
            DataTable dt = new DataTable();
            var queryCTDB = from itemCTCTDB in db.CHDB_ChiTietCatTams
                            where itemCTCTDB.DanhBo == DanhBo
                            select new
                            {
                                Loai = "Cắt Tạm",
                                Ma = itemCTCTDB.MaCTCTDB,
                                itemCTCTDB.CreateDate,
                                itemCTCTDB.NgayXuLy,
                                itemCTCTDB.DanhBo,
                                itemCTCTDB.LyDo,
                            };
            dt = LINQToDataTable(queryCTDB);

            var queryCHDB = from itemCTCHDB in db.CHDB_ChiTietCatHuys
                            where itemCTCHDB.DanhBo == DanhBo
                            select new
                            {
                                Loai = "Cắt Hủy",
                                Ma = itemCTCHDB.MaCTCHDB,
                                itemCTCHDB.CreateDate,
                                itemCTCHDB.NgayXuLy,
                                itemCTCHDB.DanhBo,
                                itemCTCHDB.LyDo,
                            };
            dt.Merge(LINQToDataTable(queryCHDB));

            var queryYCCHDB = from itemYCCHDB in db.CHDB_Phieus
                              where itemYCCHDB.DanhBo == DanhBo
                              select new
                              {
                                  Loai = "Phiếu Hủy",
                                  Ma = itemYCCHDB.MaYCCHDB,
                                  itemYCCHDB.CreateDate,
                                  itemYCCHDB.DanhBo,
                                  itemYCCHDB.LyDo,
                              };
            dt.Merge(LINQToDataTable(queryYCCHDB));

            if (dt.Rows.Count > 0)
                dt.DefaultView.Sort = "CreateDate DESC";
            return dt;
        }

        //MaDonMoi

        public bool checkExist(int MaDon)
        {
            return db.CHDBs.Any(item => item.MaDonMoi == MaDon);
        }

        public bool checkExist_CatTam(int MaDon, string DanhBo)
        {
            return db.CHDB_ChiTietCatTams.Any(item => item.CHDB.MaDonMoi == MaDon && item.DanhBo == DanhBo);
        }

        public bool checkExist_CatHuy(int MaDon, string DanhBo)
        {
            return db.CHDB_ChiTietCatHuys.Any(item => item.CHDB.MaDonMoi == MaDon && item.DanhBo == DanhBo);
        }

        public bool checkExist_PhieuHuy(int MaDon, string DanhBo)
        {
            return db.CHDB_Phieus.Any(item => item.CHDB.MaDonMoi == MaDon && item.DanhBo == DanhBo);
        }

        public CHDB get(int MaDon)
        {
            return db.CHDBs.SingleOrDefault(item => item.MaDonMoi == MaDon);
        }
    }
}

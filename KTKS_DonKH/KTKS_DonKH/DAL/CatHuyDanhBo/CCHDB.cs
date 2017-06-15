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
        ///Chứa hàm truy xuất dữ liệu từ bảng CHDB & CTCTDB & CTCHDB & YeuCauCHDB

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

        public bool XoaCHDB(CHDB chdb)
        {
            try
            {
                db.CHDBs.DeleteOnSubmit(chdb);
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
                if (db.CTCTDBs.Any(itemCTCTDB => itemCTCTDB.DanhBo == DanhBo))
                {
                    ThongTin = "Cắt Tạm với Số Phiếu: " + db.CTCTDBs.Where(itemCTCTDB => itemCTCTDB.DanhBo == DanhBo).ToList().LastOrDefault().MaCTCTDB.ToString().Insert(db.CTCTDBs.Where(itemCTCTDB => itemCTCTDB.DanhBo == DanhBo).ToList().LastOrDefault().MaCTCTDB.ToString().Length - 2, "-");
                    return true;
                }
                else
                    if (db.CTCHDBs.Any(itemCTCHDB => itemCTCHDB.DanhBo == DanhBo))
                    {
                        ThongTin = "Cắt Hủy với Số Phiếu: " + db.CTCHDBs.Where(itemCTCHDB => itemCTCHDB.DanhBo == DanhBo).ToList().LastOrDefault().MaCTCHDB.ToString().Insert(db.CTCHDBs.Where(itemCTCHDB => itemCTCHDB.DanhBo == DanhBo).ToList().LastOrDefault().MaCTCHDB.ToString().Length - 2, "-");
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
                if (db.CTCTDBs.Any(itemCTCTDB => itemCTCTDB.DanhBo == DanhBo))
                {
                    return true;
                }
                else
                    if (db.CTCHDBs.Any(itemCTCHDB => itemCTCHDB.DanhBo == DanhBo))
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

        #region CTCTDB (Chi Tiết Cắt Tạm Danh Bộ)

        public bool ThemCTCTDB(CTCTDB ctctdb)
        {
            try
            {
                if (db.CTCTDBs.Count() > 0)
                {
                    string ID = "MaCTCTDB";
                    string Table = "CTCTDB";
                    decimal MaCTCTDB = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    //decimal MaCTCTDB = db.CTCTDBs.Max(itemCTCTDB => itemCTCTDB.MaCTCTDB);
                    ctctdb.MaCTCTDB = getMaxNextIDTable(MaCTCTDB);
                }
                else
                    ctctdb.MaCTCTDB = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                ctctdb.CreateDate = DateTime.Now;
                ctctdb.CreateBy = CTaiKhoan.MaUser;
                db.CTCTDBs.InsertOnSubmit(ctctdb);
                db.SubmitChanges();
                //MessageBox.Show("Thành công Thêm CTCTDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool SuaCTCTDB(CTCTDB ctctdb)
        {
            try
            {
                ctctdb.ModifyDate = DateTime.Now;
                ctctdb.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa CTCTDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool XoaCTCTDB(CTCTDB ctctdb)
        {
            try
            {
                decimal ID = ctctdb.MaCHDB.Value;
                db.CTCTDBs.DeleteOnSubmit(ctctdb);
                if (db.CTCTDBs.Any(item => item.MaCHDB == ID) == false && db.CTCHDBs.Any(item => item.MaCHDB == ID) == false)
                    db.CHDBs.DeleteOnSubmit(db.CHDBs.SingleOrDefault(item => item.MaCHDB == ID));
                db.SubmitChanges();
                //MessageBox.Show("Thành công Xóa CTCTDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                return db.CTCTDBs.Any(item => item.MaCTCTDB == MaCTCTDB);
        }

        public bool CheckExist_CTCTDB(string Loai, decimal MaDon, string DanhBo)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.CTCTDBs.Any(item => item.CHDB.MaDon == MaDon && item.DanhBo == DanhBo);
                case "TXL":
                    return db.CTCTDBs.Any(item => item.CHDB.MaDonTXL == MaDon && item.DanhBo == DanhBo);
                case "TBC":
                    return db.CTCTDBs.Any(item => item.CHDB.MaDonTBC == MaDon && item.DanhBo == DanhBo);
                default:
                    return false;
            }
        }

        public CTCTDB GetCTCTDB(decimal MaCTCTDB)
        {
                return db.CTCTDBs.SingleOrDefault(item => item.MaCTCTDB == MaCTCTDB);
        }

        public decimal getMaxMaCTCTDB()
        {
            try
            {
                return db.CTCTDBs.Max(itemCTCTDB => itemCTCTDB.MaCTCTDB);
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
                var query = from itemCTCTDB in db.CTCTDBs
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

        public DataTable GetDSCatTam(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    var query = from item in db.CTCTDBs
                                where item.CHDB.MaDon == MaDon
                                select new
                                {
                                    MaDon = "TKH" + item.CHDB.MaDon,
                                    item.PhieuDuocKy,
                                    item.DaLapPhieu,
                                    item.SoPhieu,
                                    item.ThongBaoDuocKy,
                                    MaTB = item.MaCTCTDB,
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
                    query = from item in db.CTCTDBs
                            where item.CHDB.MaDonTXL == MaDon
                            select new
                            {
                                MaDon = "TXL" + item.CHDB.MaDonTXL,
                                item.PhieuDuocKy,
                                item.DaLapPhieu,
                                item.SoPhieu,
                                item.ThongBaoDuocKy,
                                MaTB = item.MaCTCTDB,
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
                    query = from item in db.CTCTDBs
                            where item.CHDB.MaDonTBC == MaDon
                            select new
                            {
                                MaDon = "TBC" + item.CHDB.MaDonTBC,
                                item.PhieuDuocKy,
                                item.DaLapPhieu,
                                item.SoPhieu,
                                item.ThongBaoDuocKy,
                                MaTB = item.MaCTCTDB,
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
                    return null;
            }
        }

        public DataTable GetDSCatTam(decimal MaCTCTDB)
        {
            var query = from item in db.CTCTDBs
                        where item.MaCTCTDB == MaCTCTDB
                        select new
                        {
                            MaDon = item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            MaTB = item.MaCTCTDB,
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

        public DataTable GetDSCatTam(decimal FromMaCTCTDB,decimal ToMaCTCTDB)
        {
            var query = from item in db.CTCTDBs
                        where item.MaCTCTDB.ToString().Substring(item.MaCTCTDB.ToString().Length - 2, 2) == FromMaCTCTDB.ToString().Substring(FromMaCTCTDB.ToString().Length - 2, 2)
                            && item.MaCTCTDB.ToString().Substring(item.MaCTCTDB.ToString().Length - 2, 2) == ToMaCTCTDB.ToString().Substring(ToMaCTCTDB.ToString().Length - 2, 2)
                            && item.MaCTCTDB >= FromMaCTCTDB && item.MaCTCTDB <= ToMaCTCTDB
                        select new
                        {
                            MaDon = item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            MaTB = item.MaCTCTDB,
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

        public DataTable GetDSCatTamByDanhBo(string DanhBo)
        {
            var query = from item in db.CTCTDBs
                        where item.DanhBo==DanhBo
                        select new
                        {
                            MaDon = item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            MaTB = item.MaCTCTDB,
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

        public DataTable GetDSCatTamByLyDo(string LyDo)
        {
            var query = from item in db.CTCTDBs
                        where item.LyDo.Contains(LyDo)
                        select new
                        {
                            MaDon = item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            MaTB = item.MaCTCTDB,
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

        public DataTable GetDSCatTam(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.CTCTDBs
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
                            MaTB = item.MaCTCTDB,
                            ID = item.MaCTCTDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                            item.NoiDungXuLy,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSCatTam_NgayLap_ChuaXuLy(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(db.CTCTDBs.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.NgayXuLy == null).OrderBy(item => item.CreateDate).ToList());
        }

        public DataTable GetDSCatTam_NgayLap_DaXuLy(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(db.CTCTDBs.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.NgayXuLy != null).OrderBy(item => item.CreateDate).ToList());
        }

        public DataTable GetDSCatTam_NgayXuLy_DaXuLy(DateTime FromNgayXuLy, DateTime ToNgayXuLy)
        {
            return LINQToDataTable(db.CTCTDBs.Where(item => item.NgayXuLy.Value.Date >= FromNgayXuLy.Date && item.NgayXuLy.Value.Date <= ToNgayXuLy.Date).OrderBy(item => item.NgayXuLy).ToList());
        }

        #endregion

        #region CTCHDB (Chi Tiết Cắt Hủy Danh Bộ)

        public bool ThemCTCHDB(CTCHDB ctchdb)
        {
            try
            {
                if (db.CTCHDBs.Count() > 0)
                {
                    string ID = "MaCTCHDB";
                    string Table = "CTCHDB";
                    decimal MaCTCHDB = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    //decimal MaCTCHDB = db.CTCHDBs.Max(itemCTCHDB => itemCTCHDB.MaCTCHDB);
                    ctchdb.MaCTCHDB = getMaxNextIDTable(MaCTCHDB);
                }
                else
                    ctchdb.MaCTCHDB = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                ctchdb.CreateDate = DateTime.Now;
                ctchdb.CreateBy = CTaiKhoan.MaUser;
                db.CTCHDBs.InsertOnSubmit(ctchdb);
                db.SubmitChanges();
                //MessageBox.Show("Thành công Thêm CTCHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool SuaCTCHDB(CTCHDB ctchdb)
        {
            try
            {
                ctchdb.ModifyDate = DateTime.Now;
                ctchdb.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa CTCHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool XoaCTCHDB(CTCHDB ctchdb)
        {
            try
            {
                decimal ID = ctchdb.MaCHDB.Value;
                db.CTCHDBs.DeleteOnSubmit(ctchdb);
                if (db.CTCTDBs.Any(item => item.MaCHDB == ID) == false && db.CTCHDBs.Any(item => item.MaCHDB == ID) == false)
                    db.CHDBs.DeleteOnSubmit(db.CHDBs.SingleOrDefault(item => item.MaCHDB == ID));
                db.SubmitChanges();
                //MessageBox.Show("Thành công Xóa CTCHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            return db.CTCHDBs.Any(item => item.MaCTCHDB == MaCTCHDB);
        }

        public bool CheckExist_CTCHDB(string Loai, decimal MaDon, string DanhBo)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.CTCHDBs.Any(item => item.CHDB.MaDon == MaDon && item.DanhBo == DanhBo);
                case "TXL":
                    return db.CTCHDBs.Any(item => item.CHDB.MaDonTXL == MaDon && item.DanhBo == DanhBo);
                case "TBC":
                    return db.CTCHDBs.Any(item => item.CHDB.MaDonTBC == MaDon && item.DanhBo == DanhBo);
                default:
                    return false;
            }
        }

        public CTCHDB GetCTCHDB(decimal MaCTCHDB)
        {
                return db.CTCHDBs.SingleOrDefault(item => item.MaCTCHDB == MaCTCHDB);
        }

        public decimal getMaxMaCTCHDB()
        {
            try
            {
                return db.CTCHDBs.Max(itemCTCHDB => itemCTCHDB.MaCTCHDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public DataTable GetDSCatHuy(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    var query = from item in db.CTCHDBs
                                where item.CHDB.MaDon == MaDon
                                select new
                                {
                                    MaDon = "TKH" + item.CHDB.MaDon,
                                    item.PhieuDuocKy,
                                    item.DaLapPhieu,
                                    item.SoPhieu,
                                    item.ThongBaoDuocKy,
                                    MaTB = item.MaCTCHDB,
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
                    query = from item in db.CTCHDBs
                            where item.CHDB.MaDonTXL == MaDon
                            select new
                            {
                                MaDon = "TXL" + item.CHDB.MaDonTXL,
                                item.PhieuDuocKy,
                                item.DaLapPhieu,
                                item.SoPhieu,
                                item.ThongBaoDuocKy,
                                MaTB = item.MaCTCHDB,
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
                    query = from item in db.CTCHDBs
                            where item.CHDB.MaDonTBC == MaDon
                            select new
                            {
                                MaDon = "TBC" + item.CHDB.MaDonTBC,
                                item.PhieuDuocKy,
                                item.DaLapPhieu,
                                item.SoPhieu,
                                item.ThongBaoDuocKy,
                                MaTB = item.MaCTCHDB,
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
                    return null;
            }
        }

        public DataTable GetDSCatHuy(decimal MaCTCHDB)
        {
            var query = from item in db.CTCHDBs
                        where item.MaCTCHDB == MaCTCHDB
                        select new
                        {
                            MaDon = item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            MaTB = item.MaCTCHDB,
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

        public DataTable GetDSCatHuy(decimal FromMaCTCHDB, decimal ToMaCTCHDB)
        {
            var query = from item in db.CTCHDBs
                        where item.MaCTCHDB.ToString().Substring(item.MaCTCHDB.ToString().Length - 2, 2) == FromMaCTCHDB.ToString().Substring(FromMaCTCHDB.ToString().Length - 2, 2)
                            && item.MaCTCHDB.ToString().Substring(item.MaCTCHDB.ToString().Length - 2, 2) == ToMaCTCHDB.ToString().Substring(ToMaCTCHDB.ToString().Length - 2, 2)
                            && item.MaCTCHDB >= FromMaCTCHDB && item.MaCTCHDB <= ToMaCTCHDB
                        select new
                        {
                            MaDon = item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            MaTB = item.MaCTCHDB,
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

        public DataTable GetDSCatHuyByDanhBo(string DanhBo)
        {
            var query = from item in db.CTCHDBs
                        where item.DanhBo == DanhBo
                        select new
                        {
                            MaDon = item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            MaTB = item.MaCTCHDB,
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

        public DataTable GetDSCatHuyByLyDo(string LyDo)
        {
            var query = from item in db.CTCHDBs
                        where item.LyDo.Contains(LyDo)
                        select new
                        {
                            MaDon = item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
                                    : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
                                    : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
                            item.PhieuDuocKy,
                            item.DaLapPhieu,
                            item.SoPhieu,
                            item.ThongBaoDuocKy,
                            MaTB = item.MaCTCHDB,
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

        public DataTable GetDSCatHuy(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.CTCHDBs
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
                            MaTB = item.MaCTCHDB,
                            ID = item.MaCTCHDB,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.LyDo,
                            item.GhiChuLyDo,
                            item.SoTien,
                            item.NoiDungXuLy,
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
        //        if (db.CTCHDBs.Count() > 0)
        //        {
        //            if (db.CTCHDBs.Max(itemCTCHDB => itemCTCHDB.SoPhieu) == null)
        //                return decimal.Parse("1" + DateTime.Now.ToString("yy"));
        //            else
        //                return getMaxNextIDTable(db.CTCHDBs.Max(itemCTCHDB => itemCTCHDB.SoPhieu).Value);
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
        //        return db.CTCHDBs.Any(itemCTCHDB => itemCTCHDB.MaCTCHDB == MaCTCHDB && itemCTCHDB.DaLapPhieu == true);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}

        public DataTable GetDSCatHuy_NgayLap_ChuaXuLy(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(db.CTCHDBs.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.NgayXuLy == null).OrderBy(item => item.CreateDate).ToList());
        }

        public DataTable GetDSCatHuy_NgayLap_DaXuLy(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(db.CTCHDBs.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.NgayXuLy != null).OrderBy(item => item.CreateDate).ToList());
        }

        public DataTable GetDSCatHuy_NgayXuLy_DaXuLy(DateTime FromNgayXuLy, DateTime ToNgayXuLy)
        {
            return LINQToDataTable(db.CTCHDBs.Where(item => item.NgayXuLy.Value.Date >= FromNgayXuLy.Date && item.NgayXuLy.Value.Date <= ToNgayXuLy.Date).OrderBy(item => item.NgayXuLy).ToList());
        }

        #endregion

        #region YeuCauCHDB (Phiếu Yêu Cầu Cắt Hủy Danh Bộ)

        public bool ThemPhieuHuy(PhieuCHDB ycchdb)
        {
            try
            {
                if (db.PhieuCHDBs.Count() > 0)
                {
                    string ID = "MaYCCHDB";
                    string Table = "PhieuCHDB";
                    decimal MaYCCHDB = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    ycchdb.MaYCCHDB = getMaxNextIDTable(MaYCCHDB);
                }
                else
                    ycchdb.MaYCCHDB = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                ycchdb.CreateDate = DateTime.Now;
                ycchdb.CreateBy = CTaiKhoan.MaUser;
                db.PhieuCHDBs.InsertOnSubmit(ycchdb);
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

        public bool SuaPhieuHuy(PhieuCHDB ycchdb)
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

        public bool XoaPhieuHuy(PhieuCHDB ycchdb)
        {
            try
            {
                db.PhieuCHDBs.DeleteOnSubmit(ycchdb);
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
                return db.PhieuCHDBs.Any(itemYCCHDB => itemYCCHDB.MaCTCTDB == MaCTCTDB);
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
                return db.PhieuCHDBs.Any(itemYCCHDB => itemYCCHDB.MaCTCHDB == MaCTCHDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist_PhieuHuy(decimal MaYCCHDB)
        {
            return db.PhieuCHDBs.Any(item => item.MaYCCHDB == MaYCCHDB);
        }

        public bool CheckExist_PhieuHuy(string Loai, decimal MaDon, string DanhBo)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.PhieuCHDBs.Any(item => item.MaDon == MaDon && item.DanhBo == DanhBo);
                case "TXL":
                    return db.PhieuCHDBs.Any(item => item.MaDonTXL == MaDon && item.DanhBo == DanhBo);
                case "TBC":
                    return db.PhieuCHDBs.Any(item => item.MaDonTBC == MaDon && item.DanhBo == DanhBo);
                default:
                    return false;
            }
        }

        public PhieuCHDB GetPhieuHuy(decimal MaYCCHDB)
        {
            try
            {
                return db.PhieuCHDBs.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaYCCHDB == MaYCCHDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public PhieuCHDB GetPhieuHuyByMaCTCTDB(decimal MaCTCTDB)
        {
                return db.PhieuCHDBs.Where(itemYCCHDB => itemYCCHDB.MaCTCTDB == MaCTCTDB).OrderBy(item => item.CreateDate).ToList().Last();
        }

        public PhieuCHDB GetPhieuHuyByMaCTCHDB(decimal MaCTCHDB)
        {
                return db.PhieuCHDBs.Where(itemYCCHDB => itemYCCHDB.MaCTCHDB == MaCTCHDB).OrderBy(item => item.CreateDate).ToList().Last();
        }
        
        /// <summary>
        /// Lấy Danh Sách Yêu Cầu Cắt Hủy Danh Bộ trực tiếp không qua Thông Báo
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSYCCHDB()
        {
            try
            {
                var query = from itemYCCHDB in db.PhieuCHDBs
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

        public DataTable GetDSPhieuHuy(string Loai,decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    var query = from item in db.PhieuCHDBs
                                where item.MaDon == MaDon
                                select new
                                {
                                    MaDon = "TKH" + item.MaDon,
                                    item.PhieuDuocKy,
                                    MaTB = item.MaYCCHDB,
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
                    query = from item in db.PhieuCHDBs
                            where item.MaDonTXL == MaDon
                            select new
                            {
                                MaDon = "TXL" + item.MaDonTXL,
                                item.PhieuDuocKy,
                                MaTB = item.MaYCCHDB,
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
                    query = from item in db.PhieuCHDBs
                            where item.MaDonTBC == MaDon
                            select new
                            {
                                MaDon = "TBC" + item.MaDonTBC,
                                item.PhieuDuocKy,
                                MaTB = item.MaYCCHDB,
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
                    return null;
            }
        }

        public DataTable GetDSPhieuHuy(decimal MaYCCHDB)
        {
            var query = from item in db.PhieuCHDBs
                        where item.MaYCCHDB == MaYCCHDB
                        select new
                        {
                            MaDon = item.MaDon != null ? "TKH" + item.MaDon
                                    : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                    : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                            item.PhieuDuocKy,
                            MaTB = item.MaYCCHDB,
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

        public DataTable GetDSPhieuHuy(decimal FromMaYCCHDB, decimal ToMaYCCHDB)
        {
            var query = from item in db.PhieuCHDBs
                        where item.MaYCCHDB.ToString().Substring(item.MaYCCHDB.ToString().Length - 2, 2) == FromMaYCCHDB.ToString().Substring(FromMaYCCHDB.ToString().Length - 2, 2)
                            && item.MaYCCHDB.ToString().Substring(item.MaYCCHDB.ToString().Length - 2, 2) == ToMaYCCHDB.ToString().Substring(ToMaYCCHDB.ToString().Length - 2, 2)
                            && item.MaYCCHDB >= FromMaYCCHDB && item.MaYCCHDB <= ToMaYCCHDB
                        select new
                        {
                            MaDon = item.MaDon != null ? "TKH" + item.MaDon
                                    : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                    : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                            item.PhieuDuocKy,
                            MaTB = item.MaYCCHDB,
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

        public DataTable GetDSPhieuHuy(string DanhBo)
        {
            var query = from item in db.PhieuCHDBs
                        where item.DanhBo == DanhBo
                        select new
                        {
                            MaDon = item.MaDon != null ? "TKH" + item.MaDon
                                    : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                    : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                            item.PhieuDuocKy,
                            MaTB = item.MaYCCHDB,
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

        public DataTable GetDSPhieuHuy(DateTime FromCreateDate,DateTime ToCreateDate)
        {
            var query = from item in db.PhieuCHDBs
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.MaDon != null ? "TKH" + item.MaDon
                                    : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                    : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                            item.PhieuDuocKy,
                            MaTB = item.MaYCCHDB,
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
                var query = from itemYCCHDB in db.PhieuCHDBs
                            where itemYCCHDB.CreateDate.Value.Date == TuNgay.Date //&& (itemYCCHDB.MaDon != null || itemYCCHDB.MaDonTXL != null)
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
                var query = from itemYCCHDB in db.PhieuCHDBs
                            where itemYCCHDB.CreateDate.Value.Date >= TuNgay.Date && itemYCCHDB.CreateDate.Value.Date <= DenNgay.Date //&& (itemYCCHDB.MaDon != null || itemYCCHDB.MaDonTXL != null)
                            select new
                            {
                                In = false,
                                itemYCCHDB.PhieuDuocKy,
                                SoPhieu = itemYCCHDB.MaYCCHDB,
                                Ma = itemYCCHDB.MaYCCHDB,
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
                var query = from itemYCCHDB in db.PhieuCHDBs
                            where itemYCCHDB.CreateDate.Value.Date == TuNgay.Date
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
                var query = from itemYCCHDB in db.PhieuCHDBs
                            where itemYCCHDB.CreateDate.Value.Date >= TuNgay.Date && itemYCCHDB.CreateDate.Value.Date <= DenNgay.Date
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

        #region GhiChuCHDB (GhiChu)

        public bool ThemGhiChu(GhiChuCHDB item)
        {
            try
            {
                if (db.GhiChuCHDBs.Count() > 0)
                {
                    string ID = "ID";
                    string Table = "GhiChuCHDB";
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
                db.GhiChuCHDBs.InsertOnSubmit(item);
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

        public bool SuaGhiChu(GhiChuCHDB item)
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

        public bool XoaGhiChu(GhiChuCHDB item)
        {
            try
            {
                db.GhiChuCHDBs.DeleteOnSubmit(item);
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

        public List<GhiChuCHDB> GetDSGhiChuByMaCTCTDB(decimal MaCTCTDB)
        {
            return db.GhiChuCHDBs.Where(item => item.MaCTCTDB == MaCTCTDB).OrderByDescending(item => item.NgayLap).ToList();
        }

        public List<GhiChuCHDB> GetDSGhiChuByMaCTCHDB(decimal MaCTCHDB)
        {
            return db.GhiChuCHDBs.Where(item => item.MaCTCHDB == MaCTCHDB).OrderByDescending(item => item.NgayLap).ToList();
        }

        public GhiChuCHDB GetGhiChuByID(decimal ID)
        {
            return db.GhiChuCHDBs.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetDSNoiDungGhiChu()
        {
            return LINQToDataTable(db.GhiChuCHDBs.Select(item => new { item.NoiDung }).ToList().Distinct());
        }

        public DataTable GetDSNoiNhanGhiChu()
        {
            return LINQToDataTable(db.GhiChuCHDBs.Select(item => new { item.NoiNhan }).ToList().Distinct());
        }

        #endregion

        public DataTable GetLichSuCHDB(string DanhBo)
        {
            DataTable dt = new DataTable();
            var queryCTDB = from itemCTCTDB in db.CTCTDBs
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

            var queryCHDB = from itemCTCHDB in db.CTCHDBs
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

            var queryYCCHDB = from itemYCCHDB in db.PhieuCHDBs
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
    }
}

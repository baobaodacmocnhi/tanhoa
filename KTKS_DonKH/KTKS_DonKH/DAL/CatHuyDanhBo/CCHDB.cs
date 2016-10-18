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
                db = new DB_KTKS_DonKHDataContext();
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
                db = new DB_KTKS_DonKHDataContext();
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
                db = new DB_KTKS_DonKHDataContext();
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

        public CHDB getCHDBbyID(decimal MaCHDB)
        {
            try
            {
                return db.CHDBs.SingleOrDefault(itemCHDB => itemCHDB.MaCHDB == MaCHDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Kiểm tra Đơn Khách Hàng có được CHDB xử lý hay chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns>true/có</returns>
        public bool CheckCHDBbyMaDon(decimal MaDon)
        {
            try
            {
                if (db.CHDBs.Any(itemCHDB => itemCHDB.MaDon == MaDon))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra Đơn Tổ Xử Lý có được CHDB xử lý hay chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns>true/có</returns>
        public bool CheckCHDBbyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                if (db.CHDBs.Any(itemCHDB => itemCHDB.MaDonTXL == MaDonTXL))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Lấy CHDB bằng MaDon
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns></returns>
        public CHDB getCHDBbyMaDon(decimal MaDon)
        {
            try
            {
                return db.CHDBs.SingleOrDefault(itemCHDB => itemCHDB.MaDon == MaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy CHDB bằng MaDon Tổ Xử Lý
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns></returns>
        public CHDB getCHDBbyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                return db.CHDBs.SingleOrDefault(itemCHDB => itemCHDB.MaDonTXL == MaDonTXL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Kiểm tra Danh Bộ đã lập cắt tạm/cắt hủy nào trước đó chưa
        /// </summary>
        /// <param name="DanhBo"></param>
        /// <param name="ThongTin"></param>
        /// <returns></returns>
        public bool CheckCHDBbyDanhBo(string DanhBo,out string ThongTin)
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
                db = new DB_KTKS_DonKHDataContext();
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
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool XoaCTCTDB(CTCTDB ctctdb)
        {
            try
            {
                    db.CTCTDBs.DeleteOnSubmit(ctctdb);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Xóa CTCTDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool CheckCTCTDBbyID(decimal MaCTCTDB)
        {
            try
            {
                return db.CTCTDBs.Any(itemCTCTDB => itemCTCTDB.MaCTCTDB == MaCTCTDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public CTCTDB getCTCTDBbyID(decimal MaCTCTDB)
        {
            try
            {
                return db.CTCTDBs.SingleOrDefault(itemCTCTDB => itemCTCTDB.MaCTCTDB == MaCTCTDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
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
                                    In=false,
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

        public DataTable LoadDSCTCTDBByMaDon(decimal MaDon)
        {
            try
            {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.CHDB.MaDon==MaDon||itemCTCTDB.CHDB.MaDonTXL==MaDon
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

        public DataTable LoadDSCTCTDBByMaTB(decimal MaTB)
        {
            try
            {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.MaCTCTDB==MaTB
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

        public DataTable LoadDSCTCTDBByMaTBs(decimal TuMaTB, decimal DenMaTB)
        {
            try
                {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.MaCTCTDB.ToString().Substring(itemCTCTDB.MaCTCTDB.ToString().Length - 2, 2) == TuMaTB.ToString().Substring(TuMaTB.ToString().Length - 2, 2)
                                && itemCTCTDB.MaCTCTDB.ToString().Substring(itemCTCTDB.MaCTCTDB.ToString().Length - 2, 2) == DenMaTB.ToString().Substring(DenMaTB.ToString().Length - 2, 2)
                                && itemCTCTDB.MaCTCTDB >= TuMaTB && itemCTCTDB.MaCTCTDB <= DenMaTB
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

        public DataTable LoadDSCTCTDBByDanhBo(string DanhBo)
        {
            try
            {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.DanhBo==DanhBo
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

        public DataTable LoadDSCTCTDBByLyDo(string LyDo)
        {
            try
            {
                var query = from itemCTCTDB in db.CTCTDBs
                            where itemCTCTDB.LyDo.Contains(LyDo)
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

        public DataTable LoadDSCTCTDBByDate(DateTime TuNgay)
        {
            try
            {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.CreateDate.Value.Date==TuNgay.Date
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

        public DataTable LoadDSCTCTDBByDates(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.CreateDate.Value.Date>=TuNgay.Date&&itemCTCTDB.CreateDate.Value.Date<=DenNgay.Date
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

        /// <summary>
        /// Lấy Danh Sách Chi Tiết Cắt Tạm Danh Bộ trong Ngày
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCTCTDB(DateTime TuNgay)
        {
            try
            {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.CreateDate.Value.Date == TuNgay.Date
                                select new
                                {
                                    In = false,
                                    itemCTCTDB.PhieuDuocKy,
                                    itemCTCTDB.DaLapPhieu,
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
                                    itemCTCTDB.TCTBXuLy,
                                    itemCTCTDB.TroNgai,
                                    itemCTCTDB.NguoiKy,
                                    itemCTCTDB.NoiDungXuLy,
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
        /// Lấy Danh Sách Chi Tiết Cắt Tạm Danh Bộ trong Khoảng Thời Gian
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCTCTDB(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.CreateDate.Value.Date >= TuNgay.Date && itemCTCTDB.CreateDate.Value.Date <= DenNgay.Date
                                select new
                                {
                                    In = false,
                                    itemCTCTDB.PhieuDuocKy,
                                    itemCTCTDB.DaLapPhieu,
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
                                    itemCTCTDB.TCTBXuLy,
                                    itemCTCTDB.TroNgai,
                                    itemCTCTDB.NguoiKy,
                                    itemCTCTDB.NoiDungXuLy,
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
        /// Lấy Danh Sách Chi Tiết Cắt Tạm Danh Bộ Tổ Xử Lý
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSCTCTDB_TXL()
        {
            try
            {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.CHDB.MaDonTXL != null
                                select new
                                {
                                    In=false,
                                    MaTB = itemCTCTDB.MaCTCTDB,
                                    itemCTCTDB.DanhBo,
                                    itemCTCTDB.HoTen,
                                    itemCTCTDB.DiaChi,
                                    itemCTCTDB.LyDo,
                                    itemCTCTDB.GhiChuLyDo,
                                    itemCTCTDB.SoTien,
                                    itemCTCTDB.ThongBaoDuocKy,
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
        /// Kiểm tra CTCTDB đã được tạo cho Mã Đơn KH và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTCTDBbyMaDonDanhBo(decimal MaDon, string DanhBo)
        {
            try
            {
                return db.CTCTDBs.Any(itemCTCTDB => itemCTCTDB.CHDB.MaDon == MaDon && itemCTCTDB.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra CTCTDB đã được tạo cho Mã Đơn TXL và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTCTDBbyMaDonDanhBo_TXL(decimal MaDonTXL, string DanhBo)
        {
            try
            {
                return db.CTCTDBs.Any(itemCTCTDB => itemCTCTDB.CHDB.MaDonTXL == MaDonTXL && itemCTCTDB.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable GetDSCatTam_NgayLap_ChuaXuLy(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(db.CTCTDBs.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.NgayXuLy == null).OrderBy(item=>item.CreateDate).ToList());
        }

        public DataTable GetDSCatTam_NgayLap_DaXuLy(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(db.CTCTDBs.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.NgayXuLy != null).OrderBy(item => item.CreateDate).ToList());
        }

        public DataTable GetDSCatTam_NgayXuLy_DaXuLy(DateTime FromNgayXuLy, DateTime ToNgayXuLy)
        {
            return LINQToDataTable(db.CTCTDBs.Where(item => item.NgayXuLy.Value.Date >= FromNgayXuLy.Date && item.NgayXuLy.Value.Date <= ToNgayXuLy.Date).OrderBy(item => item.CreateDate).ToList());
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
                db = new DB_KTKS_DonKHDataContext();
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
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool XoaCTCHDB(CTCHDB ctchdb)
        {
            try
            {
                    db.CTCHDBs.DeleteOnSubmit(ctchdb);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Xóa CTCHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public CTCHDB getCTCHDBbyID(decimal MaCTCHDB)
        {
            try
            {
                return db.CTCHDBs.SingleOrDefault(itemCTCHDB => itemCTCHDB.MaCTCHDB == MaCTCHDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
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

        /// <summary>
        /// Lấy Danh Sách Chi Tiết Cắt Hủy Danh Bộ
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSCTCHDB()
        {
            try
            {
                    var query = from itemCTCHDB in db.CTCHDBs
                                //where itemCTCHDB.CHDB.MaDon!=null
                                orderby itemCTCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCHDB.PhieuDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.SoPhieu,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    Ma = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.NguoiKy,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCHDBByMaDon(decimal MaDon)
        {
            try
            {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.CHDB.MaDon==MaDon||itemCTCHDB.CHDB.MaDonTXL==MaDon
                                orderby itemCTCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCHDB.PhieuDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.SoPhieu,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    Ma = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.NguoiKy,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCHDBByMaTB(decimal MaTB)
        {
            try
            {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.MaCTCHDB==MaTB
                                orderby itemCTCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCHDB.PhieuDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.SoPhieu,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    Ma = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.NguoiKy,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCHDBByMaTBs(decimal TuMaTB, decimal DenMaTB)
        {
            try
            {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.MaCTCHDB.ToString().Substring(itemCTCHDB.MaCTCHDB.ToString().Length - 2, 2) == TuMaTB.ToString().Substring(TuMaTB.ToString().Length - 2, 2)
                                && itemCTCHDB.MaCTCHDB.ToString().Substring(itemCTCHDB.MaCTCHDB.ToString().Length - 2, 2) == DenMaTB.ToString().Substring(DenMaTB.ToString().Length - 2, 2)
                                && itemCTCHDB.MaCTCHDB >= TuMaTB && itemCTCHDB.MaCTCHDB <= DenMaTB
                                orderby itemCTCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCHDB.PhieuDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.SoPhieu,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    Ma = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.NguoiKy,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCHDBByDanhBo(string DanhBo)
        {
            try
            {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.DanhBo==DanhBo
                                orderby itemCTCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCHDB.PhieuDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.SoPhieu,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    Ma = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.NguoiKy,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCHDBByLyDo(string LyDo)
        {
            try
            {
                var query = from itemCTCHDB in db.CTCHDBs
                            where itemCTCHDB.LyDo.Contains(LyDo)
                            orderby itemCTCHDB.CreateDate descending
                            select new
                            {
                                In = false,
                                itemCTCHDB.PhieuDuocKy,
                                itemCTCHDB.DaLapPhieu,
                                itemCTCHDB.SoPhieu,
                                itemCTCHDB.ThongBaoDuocKy,
                                MaTB = itemCTCHDB.MaCTCHDB,
                                Ma = itemCTCHDB.MaCTCHDB,
                                itemCTCHDB.CreateDate,
                                itemCTCHDB.DanhBo,
                                itemCTCHDB.HoTen,
                                itemCTCHDB.DiaChi,
                                itemCTCHDB.LyDo,
                                itemCTCHDB.GhiChuLyDo,
                                itemCTCHDB.SoTien,
                                itemCTCHDB.NguoiKy,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCHDBByDate(DateTime TuNgay)
        {
            try
            {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.CreateDate.Value.Date==TuNgay.Date
                                orderby itemCTCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCHDB.PhieuDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.SoPhieu,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    Ma = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.NguoiKy,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCHDBByDates(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.CreateDate.Value.Date>=TuNgay.Date&&itemCTCHDB.CreateDate.Value.Date<=DenNgay.Date
                                orderby itemCTCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCHDB.PhieuDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.SoPhieu,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    Ma = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.NguoiKy,
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
        /// Lấy Danh Sách Chi Tiết Cắt Hủy Danh Bộ trong Ngày
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCTCHDB(DateTime TuNgay)
        {
            try
            {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.CreateDate.Value.Date == TuNgay.Date
                                select new
                                {
                                    In = false,
                                    itemCTCHDB.PhieuDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    Ma = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.TCTBXuLy,
                                    itemCTCHDB.TroNgai,
                                    itemCTCHDB.NguoiKy,
                                    itemCTCHDB.NoiDungXuLy,
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
        /// Lấy Danh Sách Chi Tiết Cắt Hủy Danh Bộ trong Khoảng Thời Gian
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCTCHDB(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.CreateDate.Value.Date >= TuNgay.Date && itemCTCHDB.CreateDate.Value.Date <= DenNgay.Date
                                select new
                                {
                                    In = false,
                                    itemCTCHDB.PhieuDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    Ma = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.TCTBXuLy,
                                    itemCTCHDB.TroNgai,
                                    itemCTCHDB.NguoiKy,
                                    itemCTCHDB.NoiDungXuLy,
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
        /// Lấy Danh Sách Chi Tiết Cắt Hủy Danh Bộ Tổ Xử Lý
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSCTCHDB_TXL()
        {
            try
            {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.CHDB.MaDonTXL != null
                                select new
                                {
                                    In = false,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.PhieuDuocKy,
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
        /// Kiểm tra Cắt Hủy đã được lập trước đó chưa, trong record Cắt Hủy có column Mã Chi Tiết Cắt Tạm
        /// </summary>
        /// <param name="MaCTCTDB"></param>
        /// <returns></returns>
        public bool CheckCTCHDBbyCTCTDB(decimal MaCTCTDB)
        {
            try
            {
                return db.CTCHDBs.Any(itemCTCHDB => itemCTCHDB.MaCTCTDB == MaCTCTDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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

        /// <summary>
        /// Kiểm tra CTCHDB đã được tạo cho Mã Đơn Khách Hàng và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTCHDBbyMaDonDanhBo(decimal MaDon, string DanhBo)
        {
            try
            {
                return db.CTCHDBs.Any(itemCTCHDB => itemCTCHDB.CHDB.MaDon == MaDon && itemCTCHDB.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra CTCHDB đã được tạo cho Mã Đơn Tổ Xử Lý và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTCHDBbyMaDonDanhBo_TXL(decimal MaDonTXL, string DanhBo)
        {
            try
            {
                return db.CTCHDBs.Any(itemCTCHDB => itemCTCHDB.CHDB.MaDonTXL == MaDonTXL && itemCTCHDB.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

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
            return LINQToDataTable(db.CTCHDBs.Where(item => item.NgayXuLy.Value.Date >= FromNgayXuLy.Date && item.NgayXuLy.Value.Date <= ToNgayXuLy.Date).OrderBy(item => item.CreateDate).ToList());
        }

        #endregion

        #region YeuCauCHDB (Phiếu Yêu Cầu Cắt Hủy Danh Bộ)

        /// <summary>
        /// Kiểm tra Thông Báo CTDB có được lấp Phiếu Yếu Cầu CHDB không
        /// </summary>
        /// <param name="MaCTCTDB"></param>
        /// <returns></returns>
        public bool CheckYeuCauCHDBbyMaCTCTDB(decimal MaCTCTDB)
        {
            try
            {
                return db.PhieuCHDBs.Any(itemYCCHDB => itemYCCHDB.MaCTCTDB==MaCTCTDB);
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
        public bool CheckYeuCauCHDBbyMaCTCHDB(decimal MaCTCHDB)
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

        public bool ThemYeuCauCHDB(PhieuCHDB ycchdb)
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
                        //decimal MaYCCHDB = db.YeuCauCHDBs.Max(itemYCCHDB => itemYCCHDB.MaYCCHDB);
                        ycchdb.MaYCCHDB = getMaxNextIDTable(MaYCCHDB);
                    }
                    else
                        ycchdb.MaYCCHDB = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    ycchdb.CreateDate = DateTime.Now;
                    ycchdb.CreateBy = CTaiKhoan.MaUser;
                    db.PhieuCHDBs.InsertOnSubmit(ycchdb);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm YeuCauCHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool SuaYeuCauCHDB(PhieuCHDB ycchdb)
        {
            try
            {
                    ycchdb.ModifyDate = DateTime.Now;
                    ycchdb.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa YeuCauCHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool XoaYeuCauCHDB(PhieuCHDB ycchdb)
        {
            try
            {
                    db.PhieuCHDBs.DeleteOnSubmit(ycchdb);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa YeuCauCHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public PhieuCHDB getYeuCauCHDbyID(decimal MaYCCHDB)
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

        public PhieuCHDB getYeuCauCHDBbyMaCTCTDB(decimal MaCTCTDB)
        {
            try
            {
                return db.PhieuCHDBs.Where(itemYCCHDB => itemYCCHDB.MaCTCTDB == MaCTCTDB).OrderBy(item=>item.CreateDate).ToList().Last();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public PhieuCHDB getYeuCauCHDBbyMaCTCHDB(decimal MaCTCHDB)
        {
            try
            {
                return db.PhieuCHDBs.Where(itemYCCHDB => itemYCCHDB.MaCTCHDB == MaCTCHDB).OrderBy(item => item.CreateDate).ToList().Last();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Kiểm tra Đơn Khách Hàng có được YCCHDB xử lý hay chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="DanhBo"></param>
        /// <returns>true/có</returns>
        public bool CheckYCCHDBbyMaDonDanhBo(decimal MaDon,string DanhBo)
        {
            try
            {
                if (db.PhieuCHDBs.Any(itemYCCHDB => itemYCCHDB.MaDon == MaDon&& itemYCCHDB.DanhBo==DanhBo))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra Đơn Tổ Xử Lý có được YCCHDB xử lý hay chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <param name="DanhBo"></param>
        /// <returns>true/có</returns>
        public bool CheckYCCHDBbyMaDonDanhBo_TXL(decimal MaDonTXL,string DanhBo)
        {
            try
            {
                if (db.PhieuCHDBs.Any(itemYCCHDB => itemYCCHDB.MaDonTXL == MaDonTXL&&itemYCCHDB.DanhBo==DanhBo))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
                                    SoPhieu=itemYCCHDB.MaYCCHDB,
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

        public DataTable LoadDSYCCHDBByMaDon(decimal MaDon)
        {
            try
            {
                    var query = from itemYCCHDB in db.PhieuCHDBs
                                where itemYCCHDB.MaDon==MaDon ||itemYCCHDB.MaDonTXL==MaDon
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

        public DataTable LoadDSYCCHDBBySoPhieu(decimal SoPhieu)
        {
            try
            {
                    var query = from itemYCCHDB in db.PhieuCHDBs
                                where itemYCCHDB.MaYCCHDB==SoPhieu
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

        public DataTable LoadDSYCCHDBBySoPhieus(decimal TuSoPhieu, decimal DenSoPhieu)
        {
            try
            {
                    var query = from itemYCCHDB in db.PhieuCHDBs
                                where itemYCCHDB.MaYCCHDB >= TuSoPhieu && itemYCCHDB.MaYCCHDB <= DenSoPhieu
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

        public DataTable LoadDSYCCHDBByDanhBo(string DanhBo)
        {
            try
            {
                    var query = from itemYCCHDB in db.PhieuCHDBs
                                where itemYCCHDB.DanhBo==DanhBo
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

        public DataTable LoadDSYCCHDBByDate(DateTime TuNgay)
        {
            try
            {
                    var query = from itemYCCHDB in db.PhieuCHDBs
                                where itemYCCHDB.CreateDate.Value.Date==TuNgay.Date
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

        public DataTable LoadDSYCCHDBByDates(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                    var query = from itemYCCHDB in db.PhieuCHDBs
                                where itemYCCHDB.CreateDate.Value.Date>=TuNgay.Date&&itemYCCHDB.CreateDate.Value.Date<=DenNgay.Date
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
                                where itemYCCHDB.CreateDate.Value.Date==TuNgay.Date //&& (itemYCCHDB.MaDon != null || itemYCCHDB.MaDonTXL != null)
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
        public DataTable LoadDSYCCHDB_Don(DateTime TuNgay,DateTime DenNgay)
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
                db = new DB_KTKS_DonKHDataContext();
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
                db = new DB_KTKS_DonKHDataContext();
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
                db = new DB_KTKS_DonKHDataContext();
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
            return db.GhiChuCHDBs.Where(item => item.MaCTCHDB == MaCTCHDB).OrderByDescending(item=>item.NgayLap).ToList();
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
                                Loai="Cắt Tạm",
                                Ma=itemCTCTDB.MaCTCTDB,
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
            
            if(dt.Rows.Count>0)
            dt.DefaultView.Sort = "CreateDate DESC";
            return dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.CatHuyDanhBo
{
    class CCHDB : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng CHDB & CTCTDB & CTCHDB

        #region CHDB (Cắt Hủy Danh Bộ)

        public DataSet LoadDSCHDBDaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleCHDB)
                {
                    DataSet ds = new DataSet();
                    ///Table CHDB
                    var queryCHDB = from itemCHDB in db.CHDBs
                                    join itemDonKH in db.DonKHs on itemCHDB.MaDon equals itemDonKH.MaDon
                                    join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                    select new
                                    {
                                        itemDonKH.MaDon,
                                        itemLoaiDon.TenLD,
                                        itemDonKH.CreateDate,
                                        itemDonKH.DanhBo,
                                        itemDonKH.HoTen,
                                        itemDonKH.DiaChi,
                                        itemDonKH.NoiDung,
                                        MaNoiChuyenDen = itemCHDB.MaNoiChuyenDen,
                                        NoiChuyenDen = itemCHDB.NoiChuyenDen,
                                        LyDoChuyenDen = itemCHDB.LyDoChuyenDen,
                                        itemCHDB.MaCHDB,
                                        NgayXuLy = itemCHDB.CreateDate,
                                        itemCHDB.KetQua,
                                        itemCHDB.MaChuyen,
                                        LyDoChuyenDi = itemCHDB.LyDoChuyen
                                    };
                    DataTable dtCHDB = new DataTable();
                    dtCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCHDB);
                    dtCHDB.TableName = "CHDB";
                    ds.Tables.Add(dtCHDB);

                    ///Table CTCTDB
                    var queryCTCTDB = from itemCTCTDB in db.CTCTDBs
                                      select itemCTCTDB;

                    DataTable dtCTCTDB = new DataTable();
                    dtCTCTDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCTDB);
                    dtCTCTDB.TableName = "CTCTDB";
                    ds.Tables.Add(dtCTCTDB);

                    ///Table CTCHDB
                    var queryCTCHDB = from itemCTCHDB in db.CTCHDBs
                                      select itemCTCHDB;

                    DataTable dtCTCHDB = new DataTable();
                    dtCTCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCHDB);
                    dtCTCHDB.TableName = "CTCHDB";
                    ds.Tables.Add(dtCTCHDB);

                    if (dtCHDB.Rows.Count > 0 && dtCTCTDB.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Cắt Tạm Danh Bộ", ds.Tables["CHDB"].Columns["MaCHDB"], ds.Tables["CTCTDB"].Columns["MaCHDB"]);
                    if (dtCHDB.Rows.Count > 0 && dtCTCHDB.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Cắt Hủy Danh Bộ", ds.Tables["CHDB"].Columns["MaCHDB"], ds.Tables["CTCHDB"].Columns["MaCHDB"]);
                    return ds;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCHDBChuaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleCHDB)
                {
                    ///Bảng DonKH
                    var queryDonKH = from itemDonKH in db.DonKHs
                                     join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                     where itemDonKH.Nhan == false && itemDonKH.MaChuyen == "CTCHDB"
                                     select new
                                     {
                                         itemDonKH.MaDon,
                                         itemLoaiDon.TenLD,
                                         itemDonKH.CreateDate,
                                         itemDonKH.DanhBo,
                                         itemDonKH.HoTen,
                                         itemDonKH.DiaChi,
                                         itemDonKH.NoiDung,
                                         MaNoiChuyenDen = itemDonKH.MaDon,
                                         NoiChuyenDen = "Khách Hàng",
                                         LyDoChuyenDen = itemDonKH.LyDoChuyen,
                                         MaDCBD = "",
                                         NgayXuLy = "",
                                         KetQua = "",
                                         MaChuyen = "",
                                         LyDoChuyenDi = ""
                                     };
                    ///Bảng KTXM
                    var queryKTXM = from itemKTXM in db.KTXMs
                                    join itemDonKH in db.DonKHs on itemKTXM.MaDon equals itemDonKH.MaDon
                                    join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                    where itemKTXM.Nhan == false && itemKTXM.MaChuyen == "CTCHDB"
                                    select new
                                    {
                                        itemDonKH.MaDon,
                                        itemLoaiDon.TenLD,
                                        itemDonKH.CreateDate,
                                        itemDonKH.DanhBo,
                                        itemDonKH.HoTen,
                                        itemDonKH.DiaChi,
                                        itemDonKH.NoiDung,
                                        MaNoiChuyenDen = itemKTXM.MaKTXM,
                                        NoiChuyenDen = "Kiểm Tra Xác Minh",
                                        LyDoChuyenDen = itemKTXM.LyDoChuyen,
                                        MaDCBD = "",
                                        NgayXuLy = "",
                                        KetQua = "",
                                        MaChuyen = "",
                                        LyDoChuyenDi = ""
                                    };
                    //if (queryKTXM.Count() > 0)
                    //    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonKH.Union(queryKTXM));
                    //else
                    //    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonKH);
                    DataTable tableDonKH = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonKH);
                    DataTable tableKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM);
                    tableDonKH.Merge(tableKTXM);
                    return tableDonKH;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemCHDB(CHDB chdb)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB)
                {
                    if (db.CHDBs.Count() > 0)
                    {
                        decimal MaCHDB = db.CHDBs.Max(itemCHDB => itemCHDB.MaCHDB);
                        chdb.MaCHDB = getMaxNextIDTable(MaCHDB);
                    }
                    else
                        chdb.MaCHDB = decimal.Parse(DateTime.Now.Year + "1");
                    chdb.CreateDate = DateTime.Now;
                    chdb.CreateBy = CTaiKhoan.TaiKhoan;
                    db.CHDBs.InsertOnSubmit(chdb);
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Thêm CHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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
                if (CTaiKhoan.RoleCHDB)
                {

                    chdb.ModifyDate = DateTime.Now;
                    chdb.ModifyBy = CTaiKhoan.TaiKhoan;
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Sửa CHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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
                return db.CHDBs.Single(itemCHDB => itemCHDB.MaCHDB == MaCHDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion

        #region CTCTDB (Chi Tiết Cắt Tạm Danh Bộ)

        public bool ThemCTCTDB(CTCTDB ctctdb)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB)
                {
                    if (db.CTCTDBs.Count() > 0)
                    {
                        decimal MaCTCTDB = db.CTCTDBs.Max(itemCTCTDB => itemCTCTDB.MaCTCTDB);
                        ctctdb.MaCTCTDB = getMaxNextIDTable(MaCTCTDB);
                    }
                    else
                        ctctdb.MaCTCTDB = decimal.Parse(DateTime.Now.Year + "1");
                    ctctdb.CreateDate = DateTime.Now;
                    ctctdb.CreateBy = CTaiKhoan.TaiKhoan;
                    db.CTCTDBs.InsertOnSubmit(ctctdb);
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Thêm CTCTDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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
                if (CTaiKhoan.RoleCHDB)
                {
                    ctctdb.ModifyDate = DateTime.Now;
                    ctctdb.ModifyBy = CTaiKhoan.TaiKhoan;
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Sửa CTCTDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public CTCTDB getCTCTDBbyID(decimal MaCTCTDB)
        {
            try
            {
                return db.CTCTDBs.Single(itemCTCTDB => itemCTCTDB.MaCTCTDB == MaCTCTDB);
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
                if (CTaiKhoan.RoleCHDB)
                {
                    var query = from itemCTCTDB in db.CTCTDBs
                                select new
                                {
                                    MaTB = itemCTCTDB.MaCTCTDB,
                                    itemCTCTDB.DanhBo,
                                    itemCTCTDB.HoTen,
                                    itemCTCTDB.DiaChi,
                                    itemCTCTDB.LyDo,
                                    itemCTCTDB.GhiChuLyDo,
                                    itemCTCTDB.SoTien,
                                    itemCTCTDB.ThongBaoDuocKy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion

        #region CTCHDB (Chi Tiết Cắt Hủy Danh Bộ)

        public bool ThemCTCHDB(CTCHDB ctchdb)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB)
                {
                    if (db.CTCHDBs.Count() > 0)
                    {
                        decimal MaCTCHDB = db.CTCHDBs.Max(itemCTCHDB => itemCTCHDB.MaCTCHDB);
                        ctchdb.MaCTCHDB = getMaxNextIDTable(MaCTCHDB);
                    }
                    else
                        ctchdb.MaCTCHDB = decimal.Parse(DateTime.Now.Year + "1");
                    ctchdb.CreateDate = DateTime.Now;
                    ctchdb.CreateBy = CTaiKhoan.TaiKhoan;
                    db.CTCHDBs.InsertOnSubmit(ctchdb);
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Thêm CTCHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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
                if (CTaiKhoan.RoleCHDB)
                {
                    ctchdb.ModifyDate = DateTime.Now;
                    ctchdb.ModifyBy = CTaiKhoan.TaiKhoan;
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Sửa CTCHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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
                return db.CTCHDBs.Single(itemCTCHDB => itemCTCHDB.MaCTCHDB == MaCTCHDB);
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
                if (CTaiKhoan.RoleCHDB)
                {
                    var query = from itemCTCHDB in db.CTCHDBs
                                select new
                                {
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
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
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

        /// <summary>
        /// Lấy Số Phiếu kế tiếp khi lập Cắt Hủy Danh Bộ
        /// </summary>
        /// <returns></returns>
        public decimal getMaxNextSoPhieuCHDB()
        {
            try
            {
                if (db.CTCHDBs.Count() > 0)
                {
                    if (db.CTCHDBs.Max(itemCTCHDB => itemCTCHDB.SoPhieu) == null)
                        return decimal.Parse(DateTime.Now.Year + "1");
                    else
                        return getMaxNextIDTable(db.CTCHDBs.Max(itemCTCHDB => itemCTCHDB.SoPhieu).Value);
                }
                else
                    return decimal.Parse(DateTime.Now.Year + "1");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Kiểm Tra Cắt Hủy Danh Bộ đã lập Phiếu chưa
        /// </summary>
        /// <param name="MaCTCHDB"></param>
        /// <returns></returns>
        public bool CheckDaLapPhieuCHDB(decimal MaCTCHDB)
        {
            try
            {
                return db.CTCHDBs.Any(itemCTCHDB => itemCTCHDB.MaCTCHDB == MaCTCHDB && itemCTCHDB.DaLapPhieu == true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.DieuChinhBienDong
{
    class CDCBD : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng DCBD & CTDCBD & CTDCHD
        
        #region DCBD (Điều Chỉnh Biến Động)

        public DataSet LoadDSDCBDDaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    DataSet ds = new DataSet();
                    ///Table DCBD
                    var queryDCBD = from itemDCBD in db.DCBDs
                                join itemDonKH in db.DonKHs on itemDCBD.MaDon equals itemDonKH.MaDon
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
                                    MaNoiChuyenDen = itemDCBD.MaNoiChuyenDen,
                                    NoiChuyenDen = itemDCBD.NoiChuyenDen,
                                    LyDoChuyenDen = itemDCBD.LyDoChuyenDen,
                                    itemDCBD.MaDCBD,
                                    NgayXuLy = itemDCBD.CreateDate,
                                    itemDCBD.KetQua,
                                    itemDCBD.MaChuyen,
                                    LyDoChuyenDi = itemDCBD.LyDoChuyen
                                };
                    DataTable dtDCBD = new DataTable();
                    dtDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDCBD);
                    dtDCBD.TableName = "DCBD";
                    ds.Tables.Add(dtDCBD);

                    ///Table CTDCBD
                    var queryCTDCBD = from itemCTDCBD in db.CTDCBDs
                                 select itemCTDCBD;         

                    DataTable dtCTDCBD = new DataTable();
                    dtCTDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCBD);
                    dtCTDCBD.TableName = "CTDCBD";
                    ds.Tables.Add(dtCTDCBD);

                    ///Table CTDCHD
                    var queryCTDCHD = from itemCTDCHD in db.CTDCHDs
                                      select itemCTDCHD;

                    DataTable dtCTDCHD = new DataTable();
                    dtCTDCHD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCHD);
                    dtCTDCHD.TableName = "CTDCHD";
                    ds.Tables.Add(dtCTDCHD);

                    if (dtDCBD.Rows.Count > 0 && dtCTDCBD.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["DCBD"].Columns["MaDCBD"], ds.Tables["CTDCBD"].Columns["MaDCBD"]);
                    if (dtDCBD.Rows.Count > 0 && dtCTDCHD.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Điều Chỉnh Hóa Đơn", ds.Tables["DCBD"].Columns["MaDCBD"], ds.Tables["CTDCHD"].Columns["MaDCBD"]);
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

        public DataTable LoadDSDCBDChuaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    ///Bảng DonKH
                    var queryDonKH = from itemDonKH in db.DonKHs
                                 join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                 where itemDonKH.Nhan == false && itemDonKH.MaChuyen == "DCBD"
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
                                 where itemKTXM.Nhan == false && itemKTXM.MaChuyen == "DCBD"
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

        /// <summary>
        /// Kiểm tra Mã Điều Chỉnh Biến Động đã có hay chưa
        /// </summary>
        /// <param name="MaDCBD"></param>
        /// <returns>true/có</returns>
        public bool CheckDCBDbyID(decimal MaDCBD)
        {
            try
            {
                if (db.DCBDs.Any(itemDCBD => itemDCBD.MaDCBD == MaDCBD))
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

        public bool ThemDCBD(DCBD dcbd)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    if (db.DCBDs.Count() > 0)
                    {
                        decimal MaDCBD = db.DCBDs.Max(itemDCBD => itemDCBD.MaDCBD);
                        dcbd.MaDCBD = getMaxNextIDTable(MaDCBD);
                    }
                    else
                        dcbd.MaDCBD = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    dcbd.CreateDate = DateTime.Now;
                    dcbd.CreateBy = CTaiKhoan.TaiKhoan;
                    db.DCBDs.InsertOnSubmit(dcbd);
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Thêm DCBD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public bool SuaDCBD(DCBD dcbd)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    
                    dcbd.ModifyDate = DateTime.Now;
                    dcbd.ModifyBy = CTaiKhoan.TaiKhoan;
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Sửa DCBD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// Lấy Mã Điều Chỉnh Biến Động kế tiếp để thêm 1 DCBD mới
        /// </summary>
        /// <returns></returns>
        public decimal getMaxNextMaDCBD()
        {
            try
            {
                if (db.DCBDs.Count() > 0)
                {
                    decimal MaDCBD = db.DCBDs.Max(itemDCBD => itemDCBD.MaDCBD);
                    return getMaxNextIDTable(MaDCBD);
                }
                else
                    return decimal.Parse("1" + DateTime.Now.ToString("yy"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Lấy Mã Điều Chỉnh Biến Động lớn nhất hiện tại
        /// </summary>
        /// <returns></returns>
        public decimal getMaxMaDCBD()
        {
            try
            {
                return db.DCBDs.Max(itemDCBD => itemDCBD.MaDCBD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public DCBD getDCBDbyID(decimal MaDCBD)
        {
            try
            {
                return db.DCBDs.Single(itemDCBD => itemDCBD.MaDCBD == MaDCBD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Điều Chỉnh Biến Động & Hóa Đơn với Số Danh Bộ truyền vào
        /// </summary>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public DataTable LoadDSDCbyDanhBo(string DanhBo)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    ///Bảng CTDCBD
                    var queryCTDCBD = from itemCTDCBD in db.CTDCBDs
                                      where itemCTDCBD.DanhBo == DanhBo
                                      select new
                                      {
                                          MaDC = itemCTDCBD.MaCTDCBD,
                                          DieuChinh = "Biến Động",
                                          itemCTDCBD.CreateDate,
                                      };
                    ///Bảng CTDCHD
                    var queryCTDCHD = from itemCTDCHD in db.CTDCHDs
                                      where itemCTDCHD.DanhBo == DanhBo
                                      select new
                                      {
                                          MaDC = itemCTDCHD.MaCTDCHD,
                                          DieuChinh = "Hóa Đơn",
                                          itemCTDCHD.CreateDate,
                                      };
                    DataTable tableCTDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCBD);
                    DataTable tableCTDCHD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCHD);
                    tableCTDCBD.Merge(tableCTDCHD);
                    return tableCTDCBD;
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
        /// Kiểm tra Đơn KH có được DCBD xử lý hay chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns>true/có</returns>
        public bool CheckDCBDbyMaDon(decimal MaDon)
        {
            try
            {
                if (db.DCBDs.Any(itemDCBD => itemDCBD.MaDon == MaDon))
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
        /// Lấy DCBD bằng MaDon
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns></returns>
        public DCBD getDCBDbyMaDon(decimal MaDon)
        {
            try
            {
                return db.DCBDs.SingleOrDefault(itemDCBD => itemDCBD.MaDon == MaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion

        #region CTDCBD (Chi Tiết Điều Chỉnh Biến Động)

        public bool ThemCTDCBD(CTDCBD ctdcbd)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    if (db.CTDCBDs.Count() > 0)
                    {
                        decimal MaCTDCBD = db.CTDCBDs.Max(itemCTDCBD => itemCTDCBD.MaCTDCBD);
                        ctdcbd.MaCTDCBD = getMaxNextIDTable(MaCTDCBD);
                    }
                    else
                        ctdcbd.MaCTDCBD = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    ctdcbd.CreateDate = DateTime.Now;
                    ctdcbd.CreateBy = CTaiKhoan.TaiKhoan;
                    db.CTDCBDs.InsertOnSubmit(ctdcbd);
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Thêm CTDCBD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public bool SuaCTDCBD(CTDCBD ctdcbd)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    ctdcbd.ModifyDate = DateTime.Now;
                    ctdcbd.ModifyBy = CTaiKhoan.TaiKhoan;
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Sửa CTDCBD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public decimal getMaxMaCTDCBD()
        {
            try
            {
                return db.CTDCBDs.Max(itemCTDCBD => itemCTDCBD.MaCTDCBD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Điều Chỉnh Biến Động
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSDCBD()
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    var query = from itemCTDCBD in db.CTDCBDs
                                select new
                                {
                                    SoPhieu = itemCTDCBD.MaCTDCBD,
                                    itemCTDCBD.DanhBo,
                                    itemCTDCBD.HoTen,
                                    itemCTDCBD.HoTen_BD,
                                    itemCTDCBD.DiaChi,
                                    itemCTDCBD.DiaChi_BD,
                                    itemCTDCBD.MSThue,
                                    itemCTDCBD.MSThue_BD,
                                    itemCTDCBD.GiaBieu,
                                    itemCTDCBD.GiaBieu_BD,
                                    itemCTDCBD.DinhMuc,
                                    itemCTDCBD.DinhMuc_BD,
                                    itemCTDCBD.PhieuDuocKy,
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

        public CTDCBD getCTDCBDbyID(decimal MaCTDCBD)
        {
            try
            {
                return db.CTDCBDs.Single(itemCTDCBD => itemCTDCBD.MaCTDCBD == MaCTDCBD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion

        #region CTDCHD (Chi Tiết Điều Chỉnh Hóa Đơn)

        public bool ThemCTDCHD(CTDCHD ctdchd)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    if (db.CTDCHDs.Count() > 0)
                    {
                        decimal MaCTDCHD = db.CTDCHDs.Max(itemCTDCHD => itemCTDCHD.MaCTDCHD);
                        ctdchd.MaCTDCHD = getMaxNextIDTable(MaCTDCHD);
                    }
                    else
                        ctdchd.MaCTDCHD = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    ctdchd.CreateDate = DateTime.Now;
                    ctdchd.CreateBy = CTaiKhoan.TaiKhoan;
                    db.CTDCHDs.InsertOnSubmit(ctdchd);
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Thêm CTDCHD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public bool SuaCTDCHD(CTDCHD ctdchd)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    ctdchd.ModifyDate = DateTime.Now;
                    ctdchd.ModifyBy = CTaiKhoan.TaiKhoan;
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Sửa CTDCHD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public decimal getMaxMaCTDCHD()
        {
            try
            {
                return db.CTDCHDs.Max(itemCTDCHD => itemCTDCHD.MaCTDCHD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Điều Chỉnh Hóa Đơn
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSDCHD()
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    var query = from itemCTDCHD in db.CTDCHDs
                                select new
                                {
                                    SoPhieu = itemCTDCHD.MaCTDCHD,
                                    itemCTDCHD.DanhBo,
                                    itemCTDCHD.GiaBieu,
                                    itemCTDCHD.GiaBieu_BD,
                                    itemCTDCHD.DinhMuc,
                                    itemCTDCHD.DinhMuc_BD,
                                    itemCTDCHD.TieuThu,
                                    itemCTDCHD.TieuThu_BD,
                                    itemCTDCHD.TongCong_Start,
                                    itemCTDCHD.TongCong_End,
                                    itemCTDCHD.TongCong_BD,
                                    itemCTDCHD.TangGiam,
                                    itemCTDCHD.PhieuDuocKy,
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

        public CTDCHD getCTDCHDbyID(decimal MaCTDCHD)
        {
            try
            {
                return db.CTDCHDs.Single(itemCTDCHD => itemCTDCHD.MaCTDCHD == MaCTDCHD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion
    }
}

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
                if (CTaiKhoan.RoleDCBD_Xem||CTaiKhoan.RoleDCBD_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table DCBD
                    var queryDCBD_DonKH = from itemDCBD in db.DCBDs
                                //join itemDonKH in db.DonKHs on itemDCBD.MaDon equals itemDonKH.MaDon
                                //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                where itemDCBD.ToXuLy==false
                                select new
                                {
                                    itemDCBD.ToXuLy,
                                    itemDCBD.MaDon,
                                    itemDCBD.DonKH.LoaiDon.TenLD,
                                    itemDCBD.DonKH.CreateDate,
                                    itemDCBD.DonKH.DanhBo,
                                    itemDCBD.DonKH.HoTen,
                                    itemDCBD.DonKH.DiaChi,
                                    itemDCBD.DonKH.NoiDung,
                                    MaNoiChuyenDen = itemDCBD.MaNoiChuyenDen,
                                    NoiChuyenDen = itemDCBD.NoiChuyenDen,
                                    LyDoChuyenDen = itemDCBD.LyDoChuyenDen,
                                    itemDCBD.MaDCBD,
                                    NgayXuLy = itemDCBD.CreateDate,
                                    itemDCBD.KetQua,
                                    itemDCBD.MaChuyen,
                                    LyDoChuyenDi = itemDCBD.LyDoChuyen
                                };

                    var queryDCBD_DonTXL = from itemDCBD in db.DCBDs
                                          //join itemDonKH in db.DonKHs on itemDCBD.MaDon equals itemDonKH.MaDon
                                          //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                          where itemDCBD.ToXuLy == true
                                          select new
                                          {
                                              itemDCBD.ToXuLy,
                                              MaDon=itemDCBD.MaDonTXL,
                                              itemDCBD.DonTXL.LoaiDonTXL.TenLD,
                                              itemDCBD.DonTXL.CreateDate,
                                              itemDCBD.DonTXL.DanhBo,
                                              itemDCBD.DonTXL.HoTen,
                                              itemDCBD.DonTXL.DiaChi,
                                              itemDCBD.DonTXL.NoiDung,
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
                    dtDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDCBD_DonKH);
                    dtDCBD.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDCBD_DonTXL));
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
                if (CTaiKhoan.RoleDCBD_Xem || CTaiKhoan.RoleDCBD_CapNhat)
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
                if (CTaiKhoan.RoleDCBD_CapNhat)
                {
                    if (db.DCBDs.Count() > 0)
                    {
                        string ID = "MaDCBD";
                        string Table = "DCBD";
                        decimal MaDCBD = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //decimal MaDCBD = db.DCBDs.Max(itemDCBD => itemDCBD.MaDCBD);
                        dcbd.MaDCBD = getMaxNextIDTable(MaDCBD);
                    }
                    else
                        dcbd.MaDCBD = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    dcbd.CreateDate = DateTime.Now;
                    dcbd.CreateBy = CTaiKhoan.MaUser;
                    db.DCBDs.InsertOnSubmit(dcbd);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm DCBD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.DCBDs);
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
                if (CTaiKhoan.RoleDCBD_CapNhat)
                {
                    
                    dcbd.ModifyDate = DateTime.Now;
                    dcbd.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa DCBD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.DCBDs);
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
                return db.DCBDs.SingleOrDefault(itemDCBD => itemDCBD.MaDCBD == MaDCBD);
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
                if (CTaiKhoan.RoleDCBD_Xem || CTaiKhoan.RoleDCBD_CapNhat)
                {
                    ///Bảng CTDCBD
                    var queryCTDCBD = from itemCTDCBD in db.CTDCBDs
                                      where itemCTDCBD.DanhBo == DanhBo
                                      select new
                                      {
                                          MaDC = itemCTDCBD.MaCTDCBD,
                                          DieuChinh = "Biến Động",
                                          itemCTDCBD.HieuLucKy,
                                          itemCTDCBD.CreateDate,
                                          itemCTDCBD.ThongTin,
                                          itemCTDCBD.HoTen_BD,
                                          itemCTDCBD.DiaChi_BD,
                                          itemCTDCBD.MSThue_BD,
                                          itemCTDCBD.GiaBieu_BD,
                                          itemCTDCBD.DinhMuc_BD,
                                          itemCTDCBD.DCBD.MaDon,
                                      };
                    ///Bảng CTDCHD
                    var queryCTDCHD = from itemCTDCHD in db.CTDCHDs
                                      where itemCTDCHD.DanhBo == DanhBo
                                      select new
                                      {
                                          MaDC = itemCTDCHD.MaCTDCHD,
                                          DieuChinh = "Hóa Đơn",
                                          itemCTDCHD.CreateDate,
                                          itemCTDCHD.DCBD.MaDon,
                                      };
                    DataTable tableCTDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCBD);
                    DataTable tableCTDCHD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCHD);
                    tableCTDCBD.Merge(tableCTDCHD);
                    if (tableCTDCBD.Rows.Count > 0)
                        tableCTDCBD.DefaultView.Sort = "CreateDate DESC";

                    return tableCTDCBD.DefaultView.ToTable();
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
        /// Kiểm tra Đơn TXL có được DCBD xử lý hay chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns>true/có</returns>
        public bool CheckDCBDbyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                if (db.DCBDs.Any(itemDCBD => itemDCBD.MaDonTXL == MaDonTXL))
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
        /// Lấy DCBD bằng MaDon KH
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

        /// <summary>
        /// Lấy DCBD bằng MaDon TXL
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns></returns>
        public DCBD getDCBDbyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                return db.DCBDs.SingleOrDefault(itemDCBD => itemDCBD.MaDonTXL == MaDonTXL);
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
                if (CTaiKhoan.RoleDCBD_CapNhat)
                {
                    if (db.CTDCBDs.Count() > 0)
                    {
                        string ID = "MaCTDCBD";
                        string Table = "CTDCBD";
                        decimal MaCTDCBD = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //decimal MaCTDCBD = db.CTDCBDs.Max(itemCTDCBD => itemCTDCBD.MaCTDCBD);
                        ctdcbd.MaCTDCBD = getMaxNextIDTable(MaCTDCBD);
                    }
                    else
                        ctdcbd.MaCTDCBD = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    ctdcbd.CreateDate = DateTime.Now;
                    ctdcbd.CreateBy = CTaiKhoan.MaUser;
                    db.CTDCBDs.InsertOnSubmit(ctdcbd);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm CTDCBD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTDCBDs);
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
                if (CTaiKhoan.RoleDCBD_CapNhat)
                {
                    ctdcbd.ModifyDate = DateTime.Now;
                    ctdcbd.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa CTDCBD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTDCBDs);
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

        public bool XoaCTDCBD(CTDCBD ctdcbd)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD_CapNhat)
                {
                    db.CTDCBDs.DeleteOnSubmit(ctdcbd);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Xóa CTDCBD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTDCBDs);
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
        /// Lấy Danh Sách Tất cả Điều Chỉnh Biến Động
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSCTDCBD()
        {
            try
            {
                if (CTaiKhoan.RoleDCBD_Xem || CTaiKhoan.RoleDCBD_CapNhat)
                {
                    var query = from itemCTDCBD in db.CTDCBDs
                                orderby itemCTDCBD.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTDCBD.ChuyenDocSo,
                                    SoPhieu = itemCTDCBD.MaCTDCBD,
                                    DieuChinh="Biến Động",
                                    itemCTDCBD.CreateDate,
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
                                    itemCTDCBD.NguoiKy,
                                    itemCTDCBD.CreateBy,
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
        /// Lấy Danh Sách Điều Chỉnh Biến Động trong Ngày
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCTDCBD(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD_Xem || CTaiKhoan.RoleDCBD_CapNhat)
                {
                    var query = from itemCTDCBD in db.CTDCBDs
                                where itemCTDCBD.CreateDate.Value.Date==TuNgay.Date
                                select new
                                {
                                    In = false,
                                    itemCTDCBD.ChuyenDocSo,
                                    SoPhieu = itemCTDCBD.MaCTDCBD,
                                    Ma = itemCTDCBD.MaCTDCBD,
                                    DieuChinh = "Biến Động",
                                    itemCTDCBD.CreateDate,
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
                                    itemCTDCBD.SH_BD,
                                    itemCTDCBD.SX_BD,
                                    itemCTDCBD.DV_BD,
                                    itemCTDCBD.HCSN_BD,
                                    itemCTDCBD.NguoiKy,
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
        /// Lấy Danh Sách Điều Chỉnh Biến Động trong Khoảng Thời Gian
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCTDCBD(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD_Xem || CTaiKhoan.RoleDCBD_CapNhat)
                {
                    var query = from itemCTDCBD in db.CTDCBDs
                                where itemCTDCBD.CreateDate.Value.Date>=TuNgay.Date && itemCTDCBD.CreateDate.Value.Date<=DenNgay.Date
                                select new
                                {
                                    In = false,
                                    itemCTDCBD.ChuyenDocSo,
                                    SoPhieu = itemCTDCBD.MaCTDCBD,
                                    Ma = itemCTDCBD.MaCTDCBD,
                                    DieuChinh = "Biến Động",
                                    itemCTDCBD.CreateDate,
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
                                    itemCTDCBD.SH_BD,
                                    itemCTDCBD.SX_BD,
                                    itemCTDCBD.DV_BD,
                                    itemCTDCBD.HCSN_BD,
                                    itemCTDCBD.NguoiKy,
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
        /// Lấy Danh Sách CTDCBD theo ngày Chuyển Đọc Số
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCTDCBDbyNgayChuyenDocSo(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD_Xem || CTaiKhoan.RoleDCBD_CapNhat)
                {
                    var query = from itemCTDCBD in db.CTDCBDs
                                join itemUser in db.Users on itemCTDCBD.CreateBy equals itemUser.MaU
                                where itemCTDCBD.ChuyenDocSo==true && itemCTDCBD.NgayChuyenDocSo.Value.Date == TuNgay.Date
                                select new
                                {
                                    SoPhieu = itemCTDCBD.MaCTDCBD,
                                    itemCTDCBD.DanhBo,
                                    itemCTDCBD.HoTen,
                                    itemCTDCBD.DiaChi,
                                    itemCTDCBD.GiaBieu,
                                    itemCTDCBD.DinhMuc,
                                    itemCTDCBD.ThongTin,
                                    itemCTDCBD.HieuLucKy,
                                    CreateBy = itemUser.HoTen,
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
        /// Lấy Danh Sách CTDCBD theo khoảng thời gian Chuyển Đọc Số
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCTDCBDbyNgayChuyenDocSo(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD_Xem || CTaiKhoan.RoleDCBD_CapNhat)
                {
                    var query = from itemCTDCBD in db.CTDCBDs
                                join itemUser in db.Users on itemCTDCBD.CreateBy equals itemUser.MaU
                                where itemCTDCBD.ChuyenDocSo == true && itemCTDCBD.NgayChuyenDocSo.Value.Date >= TuNgay.Date && itemCTDCBD.NgayChuyenDocSo.Value.Date <= DenNgay.Date
                                select new
                                {
                                    SoPhieu = itemCTDCBD.MaCTDCBD,
                                    itemCTDCBD.DanhBo,
                                    itemCTDCBD.HoTen,
                                    itemCTDCBD.DiaChi,
                                    itemCTDCBD.GiaBieu,
                                    itemCTDCBD.DinhMuc,
                                    itemCTDCBD.ThongTin,
                                    itemCTDCBD.HieuLucKy,
                                    CreateBy = itemUser.HoTen,
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
                return db.CTDCBDs.SingleOrDefault(itemCTDCBD => itemCTDCBD.MaCTDCBD == MaCTDCBD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public CTDCBD getCTDCBDbyMaDon(decimal MaDon)
        {
            try
            {
                return db.CTDCBDs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == MaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool checkCTDCBDbyMaDon(decimal MaDon)
        {
            try
            {
                return db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == MaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra CTDCBD đã được tạo cho Mã Đơn KH và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTDCBDbyMaDonDanhBo(decimal MaDon, string DanhBo)
        {
            try
            {
                return db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == MaDon && itemCTDCBD.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra CTDCBD đã được tạo cho Mã Đơn TXL và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTDCBDbyMaDonDanhBo_TXL(decimal MaDonTXL, string DanhBo)
        {
            try
            {
                return db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDonTXL == MaDonTXL && itemCTDCBD.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra MaCTDCBD có hay không theo Danh Bộ & Ngày Tạo
        /// </summary>
        /// <param name="DanhBo"></param>
        /// <param name="CreateDate"></param>
        /// <returns></returns>
        public bool checkCTDCBDbyDanhBoCreateDate(string DanhBo, DateTime CreateDate)
        {
            try
            {
                return db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DanhBo == DanhBo && itemCTDCBD.CreateDate.Value.Date == CreateDate.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Lấy MaCTDCBD theo Danh Bộ & Ngày Tạo
        /// </summary>
        /// <param name="DanhBo"></param>
        /// <param name="CreateDate"></param>
        /// <returns></returns>
        public decimal getCTDCBDbyDanhBoCreateDate(string DanhBo,DateTime CreateDate)
        {
            try
            {
                return db.CTDCBDs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == DanhBo && itemCTDCBD.CreateDate.Value.Date == CreateDate.Date).MaCTDCBD;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        #endregion

        #region CTDCHD (Chi Tiết Điều Chỉnh Hóa Đơn)

        public bool ThemCTDCHD(CTDCHD ctdchd)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD_CapNhat)
                {
                    if (db.CTDCHDs.Count() > 0)
                    {
                        string ID = "MaCTDCHD";
                        string Table = "CTDCHD";
                        decimal MaCTDCHD = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //decimal MaCTDCHD = db.CTDCHDs.Max(itemCTDCHD => itemCTDCHD.MaCTDCHD);
                        ctdchd.MaCTDCHD = getMaxNextIDTable(MaCTDCHD);
                    }
                    else
                        ctdchd.MaCTDCHD = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    ctdchd.CreateDate = DateTime.Now;
                    ctdchd.CreateBy = CTaiKhoan.MaUser;
                    db.CTDCHDs.InsertOnSubmit(ctdchd);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm CTDCHD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTDCHDs);
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
                if (CTaiKhoan.RoleDCBD_CapNhat)
                {
                    ctdchd.ModifyDate = DateTime.Now;
                    ctdchd.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa CTDCHD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTDCHDs);
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

        public bool XoaCTDCHD(CTDCHD ctdchd)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD_CapNhat)
                {
                    db.CTDCHDs.DeleteOnSubmit(ctdchd);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Xóa CTDCHD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTDCHDs);
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
        public DataTable LoadDSCTDCHD()
        {
            try
            {
                if (CTaiKhoan.RoleDCBD_Xem || CTaiKhoan.RoleDCBD_CapNhat)
                {
                    var query = from itemCTDCHD in db.CTDCHDs
                                orderby itemCTDCHD.CreateDate descending
                                select new
                                {
                                    In = false,
                                    SoPhieu = itemCTDCHD.MaCTDCHD,
                                    DieuChinh = "Hóa Đơn",
                                    itemCTDCHD.CreateDate,
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
                                    itemCTDCHD.NguoiKy,
                                    itemCTDCHD.CreateBy,
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
        /// Lấy Danh Sách Điều Chỉnh Hóa Đơn trong Ngày
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSCTDCHD(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD_Xem || CTaiKhoan.RoleDCBD_CapNhat)
                {
                    var query = from itemCTDCHD in db.CTDCHDs
                                where itemCTDCHD.CreateDate.Value.Date==TuNgay.Date
                                select new
                                {
                                    In = false,
                                    SoPhieu = itemCTDCHD.MaCTDCHD,
                                    Ma = itemCTDCHD.MaCTDCHD,
                                    DieuChinh = "Hóa Đơn",
                                    itemCTDCHD.CreateDate,
                                    itemCTDCHD.DanhBo,
                                    itemCTDCHD.HoTen,
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
                                    itemCTDCHD.NguoiKy,
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
        /// Lấy Danh Sách Điều Chỉnh Hóa Đơn trong Khoảng Thời Gian
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSCTDCHD(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD_Xem || CTaiKhoan.RoleDCBD_CapNhat)
                {
                    var query = from itemCTDCHD in db.CTDCHDs
                                where itemCTDCHD.CreateDate.Value.Date >= TuNgay.Date && itemCTDCHD.CreateDate.Value.Date<=DenNgay.Date
                                select new
                                {
                                    In = false,
                                    SoPhieu = itemCTDCHD.MaCTDCHD,
                                    Ma = itemCTDCHD.MaCTDCHD,
                                    DieuChinh = "Hóa Đơn",
                                    itemCTDCHD.CreateDate,
                                    itemCTDCHD.DanhBo,
                                    itemCTDCHD.HoTen,
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
                                    itemCTDCHD.NguoiKy,
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
                return db.CTDCHDs.SingleOrDefault(itemCTDCHD => itemCTDCHD.MaCTDCHD == MaCTDCHD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Kiểm tra CTDCHD đã được tạo cho Mã Đơn KH và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTDCHDbyMaDonDanhBo(decimal MaDon, string DanhBo)
        {
            try
            {
                return db.CTDCHDs.Any(itemCTDCHD => itemCTDCHD.DCBD.MaDon == MaDon && itemCTDCHD.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra CTDCHD đã được tạo cho Mã Đơn TXL và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTDCHDbyMaDonDanhBo_TXL(decimal MaDonTXL, string DanhBo)
        {
            try
            {
                return db.CTDCHDs.Any(itemCTDCHD => itemCTDCHD.DCBD.MaDonTXL == MaDonTXL && itemCTDCHD.DanhBo == DanhBo);
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

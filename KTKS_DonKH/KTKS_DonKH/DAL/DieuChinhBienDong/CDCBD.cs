using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.DieuChinhBienDong
{
    class CDCBD : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng DCBD & CTDCBD & CTDCHD

        #region DCBD (Điều Chỉnh Biến Động)

        public bool Them(DCBD dcbd)
        {
            try
            {
                if (db.DCBDs.Count() > 0)
                {
                    string ID = "MaDCBD";
                    string Table = "DCBD";
                    decimal MaDCBD = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    dcbd.MaDCBD = getMaxNextIDTable(MaDCBD);
                }
                else
                    dcbd.MaDCBD = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                dcbd.CreateDate = DateTime.Now;
                dcbd.CreateBy = CTaiKhoan.MaUser;
                db.DCBDs.InsertOnSubmit(dcbd);
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

        public bool Sua(DCBD dcbd)
        {
            try
            {
                dcbd.ModifyDate = DateTime.Now;
                dcbd.ModifyBy = CTaiKhoan.MaUser;
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
        /// Kiểm tra Mã Điều Chỉnh Biến Động đã có hay chưa
        /// </summary>
        /// <param name="MaDCBD"></param>
        /// <returns>true/có</returns>
        public bool CheckExist(decimal MaDCBD)
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

        public DCBD Get(decimal MaDCBD)
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
                                      itemCTDCBD.DMGiuNguyen,
                                      itemCTDCBD.GiaHan,
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
                DataTable tableCTDCBD = LINQToDataTable(queryCTDCBD);
                DataTable tableCTDCHD = LINQToDataTable(queryCTDCHD);
                tableCTDCBD.Merge(tableCTDCHD);
                if (tableCTDCBD.Rows.Count > 0)
                    tableCTDCBD.DefaultView.Sort = "CreateDate DESC";

                return tableCTDCBD.DefaultView.ToTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool CheckExist(string Loai,decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.DCBDs.Any(item => item.MaDon == MaDon);
                case "TXL":
                    return db.DCBDs.Any(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.DCBDs.Any(item => item.MaDonTBC == MaDon);
                default:
                    return false;
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

        public DCBD Get(string Loai,decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.DCBDs.SingleOrDefault(item => item.MaDon == MaDon);
                case "TXL":
                    return db.DCBDs.SingleOrDefault(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.DCBDs.SingleOrDefault(item => item.MaDonTBC == MaDon);
                default:
                    return null;
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

        public bool ThemDCBD(CTDCBD ctdcbd)
        {
            try
            {
                if (db.CTDCBDs.Count() > 0)
                {
                    string ID = "MaCTDCBD";
                    string Table = "CTDCBD";
                    decimal MaCTDCBD = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    ctdcbd.MaCTDCBD = getMaxNextIDTable(MaCTDCBD);
                }
                else
                    ctdcbd.MaCTDCBD = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                ctdcbd.CreateDate = DateTime.Now;
                ctdcbd.CreateBy = CTaiKhoan.MaUser;
                db.CTDCBDs.InsertOnSubmit(ctdcbd);
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

        public bool SuaDCBD(CTDCBD ctdcbd)
        {
            try
            {
                ctdcbd.ModifyDate = DateTime.Now;
                ctdcbd.ModifyBy = CTaiKhoan.MaUser;
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

        public bool XoaDCBD(CTDCBD ctdcbd)
        {
            try
            {
                decimal ID = ctdcbd.MaDCBD.Value;
                db.CTDCBDs.DeleteOnSubmit(ctdcbd);
                if (db.CTDCBDs.Any(item => item.MaDCBD == ID) == false && db.CTDCHDs.Any(item => item.MaDCBD == ID) == false)
                    db.DCBDs.DeleteOnSubmit(db.DCBDs.SingleOrDefault(item => item.MaDCBD == ID));
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
                var query = from itemCTDCBD in db.CTDCBDs
                            orderby itemCTDCBD.CreateDate descending
                            select new
                            {
                                In = false,
                                itemCTDCBD.ChuyenDocSo,
                                SoPhieu = itemCTDCBD.MaCTDCBD,
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
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.CreateBy,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCBDByMaDon(decimal MaDon)
        {
            try
            {
                var query = from itemCTDCBD in db.CTDCBDs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.DCBD.MaDon == MaDon || itemCTDCBD.DCBD.MaDonTXL == MaDon
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                In = false,
                                itemCTDCBD.ChuyenDocSo,
                                SoPhieu = itemCTDCBD.MaCTDCBD,
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
                                itemCTDCBD.NguoiKy,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCBDByMaDon(int CreateBy, decimal MaDon)
        {
            try
            {
                var query = from itemCTDCBD in db.CTDCBDs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateBy == CreateBy && (itemCTDCBD.DCBD.MaDon == MaDon || itemCTDCBD.DCBD.MaDonTXL == MaDon)
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                In = false,
                                itemCTDCBD.ChuyenDocSo,
                                SoPhieu = itemCTDCBD.MaCTDCBD,
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
                                itemCTDCBD.NguoiKy,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCBDByMaDons(decimal TuMaDon, decimal DenMaDon)
        {
            try
            {
                var query = from itemCTDCBD in db.CTDCBDs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where ((itemCTDCBD.DCBD.MaDon.Value.ToString().Substring(itemCTDCBD.DCBD.MaDon.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCBD.DCBD.MaDon.Value.ToString().Substring(itemCTDCBD.DCBD.MaDon.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemCTDCBD.DCBD.MaDon >= TuMaDon && itemCTDCBD.DCBD.MaDon <= DenMaDon))
                            || ((itemCTDCBD.DCBD.MaDonTXL.Value.ToString().Substring(itemCTDCBD.DCBD.MaDonTXL.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCBD.DCBD.MaDonTXL.Value.ToString().Substring(itemCTDCBD.DCBD.MaDonTXL.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemCTDCBD.DCBD.MaDonTXL >= TuMaDon && itemCTDCBD.DCBD.MaDonTXL <= DenMaDon))
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                In = false,
                                itemCTDCBD.ChuyenDocSo,
                                SoPhieu = itemCTDCBD.MaCTDCBD,
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
                                itemCTDCBD.NguoiKy,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCBDByMaDons(int CreateBy, decimal TuMaDon, decimal DenMaDon)
        {
            try
            {
                var query = from itemCTDCBD in db.CTDCBDs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateBy == CreateBy && (((itemCTDCBD.DCBD.MaDon.Value.ToString().Substring(itemCTDCBD.DCBD.MaDon.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCBD.DCBD.MaDon.Value.ToString().Substring(itemCTDCBD.DCBD.MaDon.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemCTDCBD.DCBD.MaDon >= TuMaDon && itemCTDCBD.DCBD.MaDon <= DenMaDon))
                            || ((itemCTDCBD.DCBD.MaDonTXL.Value.ToString().Substring(itemCTDCBD.DCBD.MaDonTXL.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCBD.DCBD.MaDonTXL.Value.ToString().Substring(itemCTDCBD.DCBD.MaDonTXL.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemCTDCBD.DCBD.MaDonTXL >= TuMaDon && itemCTDCBD.DCBD.MaDonTXL <= DenMaDon)))
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                In = false,
                                itemCTDCBD.ChuyenDocSo,
                                SoPhieu = itemCTDCBD.MaCTDCBD,
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
                                itemCTDCBD.NguoiKy,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCBDBySoPhieu(decimal SoPhieu)
        {
            try
            {
                var query = from itemCTDCBD in db.CTDCBDs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.MaCTDCBD == SoPhieu
                            orderby itemCTDCBD.CreateDate ascending
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
                                itemCTDCBD.NguoiKy,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCBDBySoPhieu(int CreateBy, decimal SoPhieu)
        {
            try
            {
                var query = from itemCTDCBD in db.CTDCBDs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateBy == CreateBy && itemCTDCBD.MaCTDCBD == SoPhieu
                            orderby itemCTDCBD.CreateDate ascending
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
                                itemCTDCBD.NguoiKy,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCBDBySoPhieus(decimal TuSoPhieu, decimal DenSoPhieu)
        {
            try
            {
                var query = from itemCTDCBD in db.CTDCBDs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.MaCTDCBD.ToString().Substring(itemCTDCBD.MaCTDCBD.ToString().Length - 2, 2) == TuSoPhieu.ToString().Substring(TuSoPhieu.ToString().Length - 2, 2)
                            && itemCTDCBD.MaCTDCBD.ToString().Substring(itemCTDCBD.MaCTDCBD.ToString().Length - 2, 2) == DenSoPhieu.ToString().Substring(DenSoPhieu.ToString().Length - 2, 2)
                            && itemCTDCBD.MaCTDCBD >= TuSoPhieu && itemCTDCBD.MaCTDCBD <= DenSoPhieu
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                In = false,
                                itemCTDCBD.ChuyenDocSo,
                                SoPhieu = itemCTDCBD.MaCTDCBD,
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
                                itemCTDCBD.NguoiKy,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCBDBySoPhieus(int CreateBy, decimal TuSoPhieu, decimal DenSoPhieu)
        {
            try
            {
                var query = from itemCTDCBD in db.CTDCBDs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateBy == CreateBy && itemCTDCBD.MaCTDCBD.ToString().Substring(itemCTDCBD.MaCTDCBD.ToString().Length - 2, 2) == TuSoPhieu.ToString().Substring(TuSoPhieu.ToString().Length - 2, 2)
                            && itemCTDCBD.MaCTDCBD.ToString().Substring(itemCTDCBD.MaCTDCBD.ToString().Length - 2, 2) == DenSoPhieu.ToString().Substring(DenSoPhieu.ToString().Length - 2, 2)
                            && itemCTDCBD.MaCTDCBD >= TuSoPhieu && itemCTDCBD.MaCTDCBD <= DenSoPhieu
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                In = false,
                                itemCTDCBD.ChuyenDocSo,
                                SoPhieu = itemCTDCBD.MaCTDCBD,
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
                                itemCTDCBD.NguoiKy,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCBDByDanhBo(string DanhBo)
        {
            try
            {
                var query = from itemCTDCBD in db.CTDCBDs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.DanhBo == DanhBo
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                In = false,
                                itemCTDCBD.ChuyenDocSo,
                                SoPhieu = itemCTDCBD.MaCTDCBD,
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
                                itemCTDCBD.NguoiKy,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCBDByDanhBo(int CreateBy, string DanhBo)
        {
            try
            {
                var query = from itemCTDCBD in db.CTDCBDs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateBy == CreateBy && itemCTDCBD.DanhBo == DanhBo
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                In = false,
                                itemCTDCBD.ChuyenDocSo,
                                SoPhieu = itemCTDCBD.MaCTDCBD,
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
                                itemCTDCBD.NguoiKy,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCBDByDate(DateTime TuNgay)
        {
            try
            {
                var query = from itemCTDCBD in db.CTDCBDs
                            where itemCTDCBD.CreateDate.Value.Date == TuNgay.Date
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                In = false,
                                itemCTDCBD.ChuyenDocSo,
                                SoPhieu = itemCTDCBD.MaCTDCBD,
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
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.CreateBy,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCBDByDate(int CreateBy, DateTime TuNgay)
        {
            try
            {
                var query = from itemCTDCBD in db.CTDCBDs
                            where itemCTDCBD.CreateBy == CreateBy && itemCTDCBD.CreateDate.Value.Date == TuNgay.Date
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                In = false,
                                itemCTDCBD.ChuyenDocSo,
                                SoPhieu = itemCTDCBD.MaCTDCBD,
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
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.CreateBy,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCBDByDates(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                var query = from itemCTDCBD in db.CTDCBDs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateDate.Value.Date >= TuNgay.Date && itemCTDCBD.CreateDate.Value.Date <= DenNgay.Date
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                In = false,
                                itemCTDCBD.ChuyenDocSo,
                                SoPhieu = itemCTDCBD.MaCTDCBD,
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
                                itemCTDCBD.NguoiKy,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCBDByDates(int CreateBy, DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                var query = from itemCTDCBD in db.CTDCBDs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateBy == CreateBy && itemCTDCBD.CreateDate.Value.Date >= TuNgay.Date && itemCTDCBD.CreateDate.Value.Date <= DenNgay.Date
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                In = false,
                                itemCTDCBD.ChuyenDocSo,
                                SoPhieu = itemCTDCBD.MaCTDCBD,
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
                                itemCTDCBD.NguoiKy,
                                CreateBy = itemtableND.HoTen,
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
        /// Lấy Danh Sách Điều Chỉnh Biến Động trong Ngày
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCTDCBD(DateTime TuNgay)
        {
            try
            {
                var query = from itemCTDCBD in db.CTDCBDs
                            where itemCTDCBD.CreateDate.Value.Date == TuNgay.Date
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
                                itemCTDCBD.HieuLucKy,
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
        /// Lấy Danh Sách Điều Chỉnh Biến Động trong Khoảng Thời Gian
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCTDCBD(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                var query = from itemCTDCBD in db.CTDCBDs
                            where itemCTDCBD.CreateDate.Value.Date >= TuNgay.Date && itemCTDCBD.CreateDate.Value.Date <= DenNgay.Date
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
                                itemCTDCBD.HieuLucKy,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCBDSoCT(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                var query = from itemCTDCBD in db.CTDCBDs
                            join itemCTCT in db.CTChungTus on itemCTDCBD.DanhBo equals itemCTCT.DanhBo
                            join itemTTKH in dbThuTien.HOADONs.GroupBy(item => item.DANHBA).Select(item => item.OrderByDescending(itemB => itemB.CreateDate)).First() on itemCTDCBD.DanhBo equals itemTTKH.DANHBA
                            where itemCTCT.Cat == false && (itemCTCT.ChungTu.MaLCT == 2 || itemCTCT.ChungTu.MaLCT == 5 || itemCTCT.ChungTu.MaLCT == 6 || itemCTCT.ChungTu.MaLCT == 7)
                            && itemCTDCBD.CreateDate.Value.Date >= TuNgay.Date && itemCTDCBD.CreateDate.Value.Date <= DenNgay.Date
                            select new
                            {
                                itemCTDCBD.DanhBo,
                                itemCTCT.ChungTu.LoaiChungTu.MaLCT,
                                itemCTCT.SoNKDangKy,
                                itemTTKH.Quan,
                                itemTTKH.Phuong,
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
        /// Lấy Danh Sách CTDCBD theo ngày Chuyển Đọc Số
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCTDCBDbyNgayChuyenDocSo(DateTime TuNgay)
        {
            try
            {
                var query = from itemCTDCBD in db.CTDCBDs
                            join itemUser in db.Users on itemCTDCBD.CreateBy equals itemUser.MaU
                            where itemCTDCBD.ChuyenDocSo == true && itemCTDCBD.NgayChuyenDocSo.Value.Date == TuNgay.Date
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
                return LINQToDataTable(query);
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
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public CTDCBD GetDCBDByMaCTDCBD(decimal MaCTDCBD)
        {
                return db.CTDCBDs.SingleOrDefault(item => item.MaCTDCBD == MaCTDCBD);
        }

        public CTDCBD GetDCDBByMaDon(decimal MaDon)
        {
                return db.CTDCBDs.FirstOrDefault(item => item.DCBD.MaDon == MaDon);
        }

        public CTDCBD getLastCTDCBDbyDanhBo(string DanhBo)
        {
            try
            {
                if (db.CTDCBDs.Where(itemCTDCBD => itemCTDCBD.DanhBo == DanhBo && itemCTDCBD.PhieuDuocKy == true && itemCTDCBD.DinhMuc_BD != null).Count() > 0)
                    return db.CTDCBDs.Where(itemCTDCBD => itemCTDCBD.DanhBo == DanhBo && itemCTDCBD.PhieuDuocKy == true && itemCTDCBD.DinhMuc_BD != null).OrderByDescending(item => item.CreateDate).First();
                else
                    return null;
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

        public bool CheckExist_DCBD(string Loai,decimal MaDon, string DanhBo)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.CTDCBDs.Any(item => item.DCBD.MaDon == MaDon && item.DanhBo == DanhBo);
                case "TXL":
                    return db.CTDCBDs.Any(item => item.DCBD.MaDonTXL == MaDon && item.DanhBo == DanhBo);
                case "TBC":
                    return db.CTDCBDs.Any(item => item.DCBD.MaDonTBC == MaDon && item.DanhBo == DanhBo);
                default:
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
        public decimal getCTDCBDbyDanhBoCreateDate(string DanhBo, DateTime CreateDate)
        {
            try
            {
                return db.CTDCBDs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == DanhBo && itemCTDCBD.CreateDate.Value.Date == CreateDate.Date).MaCTDCBD;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public bool CheckExist_DCBD(decimal MaCTDCBD)
        {
            return db.CTDCBDs.Any(item => item.MaCTDCBD == MaCTDCBD);
        }

        #endregion

        #region CTDCHD (Chi Tiết Điều Chỉnh Hóa Đơn)

        public bool ThemDCHD(CTDCHD ctdchd)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool SuaDCHD(CTDCHD ctdchd)
        {
            try
            {
                ctdchd.ModifyDate = DateTime.Now;
                ctdchd.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa CTDCHD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool XoaDCHD(CTDCHD ctdchd)
        {
            try
            {
                decimal ID = ctdchd.MaDCBD;
                db.CTDCHDs.DeleteOnSubmit(ctdchd);
                if (db.CTDCBDs.Any(item => item.MaDCBD == ID) == false && db.CTDCHDs.Any(item => item.MaDCBD == ID) == false)
                    db.DCBDs.DeleteOnSubmit(db.DCBDs.SingleOrDefault(item => item.MaDCBD == ID));
                db.SubmitChanges();
                //MessageBox.Show("Thành công Xóa CTDCHD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
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
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCHDByMaDon(decimal MaDon)
        {
            try
            {
                var query = from itemCTDCHD in db.CTDCHDs
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.DCBD.MaDon == MaDon || itemCTDCHD.DCBD.MaDonTXL == MaDon
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                In = false,
                                SoPhieu = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
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
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCHDByMaDons(decimal TuMaDon, decimal DenMaDon)
        {
            try
            {
                var query = from itemCTDCHD in db.CTDCHDs
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where ((itemCTDCHD.DCBD.MaDon.Value.ToString().Substring(itemCTDCHD.DCBD.MaDon.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCHD.DCBD.MaDon.Value.ToString().Substring(itemCTDCHD.DCBD.MaDon.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemCTDCHD.DCBD.MaDon >= TuMaDon && itemCTDCHD.DCBD.MaDon <= DenMaDon))
                            || ((itemCTDCHD.DCBD.MaDonTXL.Value.ToString().Substring(itemCTDCHD.DCBD.MaDonTXL.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCHD.DCBD.MaDonTXL.Value.ToString().Substring(itemCTDCHD.DCBD.MaDonTXL.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemCTDCHD.DCBD.MaDonTXL >= TuMaDon && itemCTDCHD.DCBD.MaDonTXL <= DenMaDon))
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                In = false,
                                SoPhieu = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
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
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCHDBySoPhieu(decimal SoPhieu)
        {
            try
            {
                var query = from itemCTDCHD in db.CTDCHDs
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.MaCTDCHD == SoPhieu
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                In = false,
                                SoPhieu = itemCTDCHD.MaCTDCHD,
                                Ma = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
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
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCHDBySoPhieus(decimal TuSoPhieu, decimal DenSoPhieu)
        {
            try
            {
                var query = from itemCTDCHD in db.CTDCHDs
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.MaCTDCHD.ToString().Substring(itemCTDCHD.MaCTDCHD.ToString().Length - 2, 2) == TuSoPhieu.ToString().Substring(TuSoPhieu.ToString().Length - 2, 2)
                            && itemCTDCHD.MaCTDCHD.ToString().Substring(itemCTDCHD.MaCTDCHD.ToString().Length - 2, 2) == DenSoPhieu.ToString().Substring(DenSoPhieu.ToString().Length - 2, 2)
                            && itemCTDCHD.MaCTDCHD >= TuSoPhieu && itemCTDCHD.MaCTDCHD <= DenSoPhieu
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                In = false,
                                SoPhieu = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
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
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCHDByDanhBo(string DanhBo)
        {
            try
            {
                var query = from itemCTDCHD in db.CTDCHDs
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.DanhBo == DanhBo
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                In = false,
                                SoPhieu = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
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
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCHDByDate(DateTime TuNgay)
        {
            try
            {
                var query = from itemCTDCHD in db.CTDCHDs
                            where itemCTDCHD.CreateDate.Value.Date == TuNgay.Date
                            orderby itemCTDCHD.CreateDate ascending
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
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCHDByDates(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                var query = from itemCTDCHD in db.CTDCHDs
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateDate.Value.Date >= TuNgay.Date && itemCTDCHD.CreateDate.Value.Date <= DenNgay.Date
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                In = false,
                                SoPhieu = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
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
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCHDByMaDon(int CreateBy, decimal MaDon)
        {
            try
            {
                var query = from itemCTDCHD in db.CTDCHDs
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateBy == CreateBy && (itemCTDCHD.DCBD.MaDon == MaDon || itemCTDCHD.DCBD.MaDonTXL == MaDon)
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                In = false,
                                SoPhieu = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
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
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCHDByMaDons(int CreateBy, decimal TuMaDon, decimal DenMaDon)
        {
            try
            {
                var query = from itemCTDCHD in db.CTDCHDs
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateBy == CreateBy && (((itemCTDCHD.DCBD.MaDon.Value.ToString().Substring(itemCTDCHD.DCBD.MaDon.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCHD.DCBD.MaDon.Value.ToString().Substring(itemCTDCHD.DCBD.MaDon.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemCTDCHD.DCBD.MaDon >= TuMaDon && itemCTDCHD.DCBD.MaDon <= DenMaDon))
                            || ((itemCTDCHD.DCBD.MaDonTXL.Value.ToString().Substring(itemCTDCHD.DCBD.MaDonTXL.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCHD.DCBD.MaDonTXL.Value.ToString().Substring(itemCTDCHD.DCBD.MaDonTXL.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemCTDCHD.DCBD.MaDonTXL >= TuMaDon && itemCTDCHD.DCBD.MaDonTXL <= DenMaDon)))
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                In = false,
                                SoPhieu = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
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
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCHDBySoPhieu(int CreateBy, decimal SoPhieu)
        {
            try
            {
                var query = from itemCTDCHD in db.CTDCHDs
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateBy == CreateBy && itemCTDCHD.MaCTDCHD == SoPhieu
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                In = false,
                                SoPhieu = itemCTDCHD.MaCTDCHD,
                                Ma = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
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
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCHDBySoPhieus(int CreateBy, decimal TuSoPhieu, decimal DenSoPhieu)
        {
            try
            {
                var query = from itemCTDCHD in db.CTDCHDs
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateBy == CreateBy && itemCTDCHD.MaCTDCHD.ToString().Substring(itemCTDCHD.MaCTDCHD.ToString().Length - 2, 2) == TuSoPhieu.ToString().Substring(TuSoPhieu.ToString().Length - 2, 2)
                            && itemCTDCHD.MaCTDCHD.ToString().Substring(itemCTDCHD.MaCTDCHD.ToString().Length - 2, 2) == DenSoPhieu.ToString().Substring(DenSoPhieu.ToString().Length - 2, 2)
                            && itemCTDCHD.MaCTDCHD >= TuSoPhieu && itemCTDCHD.MaCTDCHD <= DenSoPhieu
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                In = false,
                                SoPhieu = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
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
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCHDByDanhBo(int CreateBy, string DanhBo)
        {
            try
            {
                var query = from itemCTDCHD in db.CTDCHDs
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateBy == CreateBy && itemCTDCHD.DanhBo == DanhBo
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                In = false,
                                SoPhieu = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
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
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCHDByDate(int CreateBy, DateTime TuNgay)
        {
            try
            {
                var query = from itemCTDCHD in db.CTDCHDs
                            where itemCTDCHD.CreateBy == CreateBy && itemCTDCHD.CreateDate.Value.Date == TuNgay.Date
                            orderby itemCTDCHD.CreateDate ascending
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
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCHDByDates(int CreateBy, DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                var query = from itemCTDCHD in db.CTDCHDs
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateBy == CreateBy && itemCTDCHD.CreateDate.Value.Date >= TuNgay.Date && itemCTDCHD.CreateDate.Value.Date <= DenNgay.Date
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                In = false,
                                SoPhieu = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
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
                                CreateBy = itemtableND.HoTen,
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
        /// Lấy Danh Sách Điều Chỉnh Hóa Đơn trong Ngày
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSCTDCHD(DateTime TuNgay)
        {
            try
            {
                var query = from itemCTDCHD in db.CTDCHDs
                            where itemCTDCHD.CreateDate.Value.Date == TuNgay.Date
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
                return LINQToDataTable(query);
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
        public DataTable LoadDSCTDCHD(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                var query = from itemCTDCHD in db.CTDCHDs
                            where itemCTDCHD.CreateDate.Value.Date >= TuNgay.Date && itemCTDCHD.CreateDate.Value.Date <= DenNgay.Date
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
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDCHD(string DanhBo, int Nam, int Ky)
        {
            try
            {
                return LINQToDataTable(db.CTDCHDs.Where(itemCTDCHD => itemCTDCHD.DanhBo == DanhBo && itemCTDCHD.Nam == Nam && itemCTDCHD.Ky == Ky).ToList());
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
        public bool CheckCTDCHDbyMaDonDanhBo(decimal MaDon, string DanhBo, string KyHD)
        {
            try
            {
                return db.CTDCHDs.Any(itemCTDCHD => itemCTDCHD.DCBD.MaDon == MaDon && itemCTDCHD.DanhBo == DanhBo && itemCTDCHD.KyHD == KyHD);
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
        public bool CheckCTDCHDbyMaDonDanhBo_TXL(decimal MaDonTXL, string DanhBo, string KyHD)
        {
            try
            {
                return db.CTDCHDs.Any(itemCTDCHD => itemCTDCHD.DCBD.MaDonTXL == MaDonTXL && itemCTDCHD.DanhBo == DanhBo && itemCTDCHD.KyHD == KyHD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist_DCHD(decimal MaCTDCHD)
        {
            return db.CTDCHDs.Any(item => item.MaCTDCHD == MaCTDCHD);
        }

        #endregion

    }
}

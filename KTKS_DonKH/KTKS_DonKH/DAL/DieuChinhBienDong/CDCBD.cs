using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.DAL.DieuChinhBienDong
{
    class CDCBD : CDAL
    {
        dbThuTienDataContext _dbThuTien = new dbThuTienDataContext();

        ///Chứa hàm truy xuất dữ liệu từ bảng DCBD & DCBD_ChiTietBienDong & DCBD_ChiTietHoaDon

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
        public DataTable getDSDCBD(string DanhBo)
        {
            try
            {
                ///Bảng DCBD_ChiTietBienDong
                var queryCTDCBD = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                                  where itemCTDCBD.DanhBo == DanhBo
                                  select new
                                  {
                                      MaDon = itemCTDCBD.DCBD.MaDonMoi != null ? itemCTDCBD.DCBD.DonTu.DonTu_ChiTiets.Count == 1 ? itemCTDCBD.DCBD.MaDonMoi.Value.ToString() : itemCTDCBD.DCBD.MaDonMoi.Value.ToString() + "." + itemCTDCBD.STT.Value.ToString()
                                      : itemCTDCBD.DCBD.MaDon != null ? "TKH" + itemCTDCBD.DCBD.MaDon
                                      : itemCTDCBD.DCBD.MaDonTXL != null ? "TXL" + itemCTDCBD.DCBD.MaDonTXL
                                      : itemCTDCBD.DCBD.MaDonTBC != null ? "TBC" + itemCTDCBD.DCBD.MaDonTBC : null,
                                      MaDC = itemCTDCBD.MaCTDCBD,
                                      DieuChinh = "Biến Động",
                                      itemCTDCBD.HieuLucKy,
                                      itemCTDCBD.CreateDate,
                                      itemCTDCBD.ThongTin,
                                      itemCTDCBD.CongDung,
                                      itemCTDCBD.HoTen_BD,
                                      itemCTDCBD.DiaChi_BD,
                                      itemCTDCBD.MSThue_BD,
                                      itemCTDCBD.GiaBieu_BD,
                                      itemCTDCBD.DinhMuc_BD,
                                      itemCTDCBD.DinhMucHN,
                                      itemCTDCBD.DinhMucHN_BD,
                                      itemCTDCBD.DMGiuNguyen,
                                      itemCTDCBD.GBGiuNguyen,
                                      GiaHan = itemCTDCBD.GiaHanKT3 == true ? true : itemCTDCBD.GiaHanNhapCu == true ? true : false,
                                      File = itemCTDCBD.DCBD_ChiTietBienDong_Hinhs.Count > 0 ? true : false,
                                      //itemCTDCBD.GiaHanKT3,
                                      //itemCTDCBD.GiaHanNhapCu,
                                  };
                ///Bảng DCBD_ChiTietHoaDon
                var queryCTDCHD = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                                  where itemCTDCHD.DanhBo == DanhBo
                                  select new
                                  {
                                      MaDon = itemCTDCHD.DCBD.MaDonMoi != null ? itemCTDCHD.DCBD.DonTu.DonTu_ChiTiets.Count == 1 ? itemCTDCHD.DCBD.MaDonMoi.Value.ToString() : itemCTDCHD.DCBD.MaDonMoi.Value.ToString() + "." + itemCTDCHD.STT.Value.ToString()
                                      : itemCTDCHD.DCBD.MaDon != null ? "TKH" + itemCTDCHD.DCBD.MaDon
                                      : itemCTDCHD.DCBD.MaDonTXL != null ? "TXL" + itemCTDCHD.DCBD.MaDonTXL
                                      : itemCTDCHD.DCBD.MaDonTBC != null ? "TBC" + itemCTDCHD.DCBD.MaDonTBC : null,
                                      MaDC = itemCTDCHD.MaCTDCHD,
                                      DieuChinh = "Hóa Đơn",
                                      itemCTDCHD.KyHD,
                                      itemCTDCHD.CreateDate,
                                      File = itemCTDCHD.DCBD_ChiTietHoaDon_Hinhs.Count > 0 ? true : false,
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

        public bool CheckExist(string Loai, decimal MaDon)
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

        public DCBD Get(string Loai, decimal MaDon)
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

        #region DCBD_ChiTietBienDong (Chi Tiết Điều Chỉnh Biến Động)

        public bool ThemDCBD(DCBD_ChiTietBienDong ctdcbd)
        {
            try
            {
                if (db.DCBD_ChiTietBienDongs.Count() > 0)
                {
                    string[] HieuLucKys = ctdcbd.HieuLucKy.Split('/');
                    //cùng năm
                    if (int.Parse(HieuLucKys[1]) == DateTime.Now.Year)
                    {
                        string ID = "MaCTDCBD";
                        string Table = "DCBD_ChiTietBienDong";
                        //decimal MaCTDCBD = db.ExecuteQuery<decimal>("declare @Ma int " +
                        //    "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        //    "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //ctdcbd.MaCTDCBD = getMaxNextIDTable(MaCTDCBD);
                        decimal result = (decimal)ExecuteQuery_ReturnOneValue("declare @Ma int"
                               + " set @Ma=" + HieuLucKys[1].ToString().Substring(HieuLucKys[1].ToString().Length - 2, 2)
                               + " select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma");
                        string Ma = result.ToString();
                        string nam = Ma.ToString().Substring(Ma.ToString().Length - 2, 2);
                        string stt = Ma.ToString().Substring(0, Ma.ToString().Length - 2);
                        stt = (decimal.Parse(stt) + 1).ToString();
                        ctdcbd.MaCTDCBD = decimal.Parse(stt + nam);
                    }
                    //khác năm
                    else
                    {
                        string ID = "MaCTDCBD";
                        string Table = "DCBD_ChiTietBienDong";
                        decimal MaCTDCBD = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        if (MaCTDCBD.ToString().Substring(MaCTDCBD.ToString().Length - 2, 2) == HieuLucKys[1].ToString().Substring(HieuLucKys[1].ToString().Length - 2, 2))
                        {
                            decimal result = (decimal)ExecuteQuery_ReturnOneValue("declare @Ma int"
                                + " set @Ma=" + HieuLucKys[1].ToString().Substring(HieuLucKys[1].ToString().Length - 2, 2)
                                + " select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma");
                            string Ma = result.ToString();
                            string nam = Ma.ToString().Substring(Ma.ToString().Length - 2, 2);
                            string stt = Ma.ToString().Substring(0, Ma.ToString().Length - 2);
                            stt = (decimal.Parse(stt) + 1).ToString();
                            ctdcbd.MaCTDCBD = decimal.Parse(stt + nam);
                        }
                        else
                            ctdcbd.MaCTDCBD = decimal.Parse("1" + HieuLucKys[1].ToString().Substring(HieuLucKys[1].ToString().Length - 2, 2));
                    }

                }
                else
                    ctdcbd.MaCTDCBD = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                ctdcbd.CreateDate = DateTime.Now;
                ctdcbd.CreateBy = CTaiKhoan.MaUser;
                db.DCBD_ChiTietBienDongs.InsertOnSubmit(ctdcbd);
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

        public bool SuaDCBD(DCBD_ChiTietBienDong ctdcbd)
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

        public bool XoaDCBD(DCBD_ChiTietBienDong ctdcbd)
        {
            try
            {
                CDonTu _cDonTu = new CDonTu();
                _cDonTu.Xoa_LichSu("DCBD_ChiTietBienDong", (int)ctdcbd.MaCTDCBD);
                decimal ID = ctdcbd.MaDCBD.Value;
                db.DCBD_ChiTietBienDong_Hinhs.DeleteAllOnSubmit(ctdcbd.DCBD_ChiTietBienDong_Hinhs.ToList());
                db.DCBD_ChiTietBienDongs.DeleteOnSubmit(ctdcbd);
                db.SubmitChanges();
                if (db.DCBD_ChiTietBienDongs.Any(item => item.MaDCBD == ID) == false && db.DCBD_ChiTietHoaDons.Any(item => item.MaDCBD == ID) == false)
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
                return db.DCBD_ChiTietBienDongs.Max(itemCTDCBD => itemCTDCBD.MaCTDCBD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public DCBD_ChiTietBienDong getBienDong(decimal MaCTDCBD)
        {
            return db.DCBD_ChiTietBienDongs.SingleOrDefault(item => item.MaCTDCBD == MaCTDCBD);
        }

        public DCBD_ChiTietBienDong getBienDongDinhMuc_Last(string DanhBo)
        {
            try
            {
                if (db.DCBD_ChiTietBienDongs.Where(itemCTDCBD => itemCTDCBD.DanhBo == DanhBo && itemCTDCBD.PhieuDuocKy == true && itemCTDCBD.DinhMuc_BD != null).Count() > 0)
                    return db.DCBD_ChiTietBienDongs.Where(itemCTDCBD => itemCTDCBD.DanhBo == DanhBo && itemCTDCBD.PhieuDuocKy == true && itemCTDCBD.DinhMuc_BD != null).OrderByDescending(item => item.CreateDate).First();
                else
                    return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DCBD_ChiTietBienDong getBienDong(string DanhBo, DateTime CreateDate)
        {
            return db.DCBD_ChiTietBienDongs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == DanhBo && itemCTDCBD.CreateDate.Value.Date == CreateDate.Date);
        }

        public decimal getMaBienDong(string DanhBo, DateTime CreateDate)
        {
            try
            {
                return db.DCBD_ChiTietBienDongs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == DanhBo && itemCTDCBD.CreateDate.Value.Date == CreateDate.Date).MaCTDCBD;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public bool checkExist_BienDong(decimal MaCTDCBD)
        {
            return db.DCBD_ChiTietBienDongs.Any(item => item.MaCTDCBD == MaCTDCBD);
        }

        public bool checkExist_BienDong(string DanhBo, DateTime CreateDate)
        {
            try
            {
                return db.DCBD_ChiTietBienDongs.Any(itemCTDCBD => itemCTDCBD.DanhBo == DanhBo && itemCTDCBD.CreateDate.Value.Date == CreateDate.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool checkExist_BienDong(string Loai, decimal MaDon, string DanhBo)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == MaDon && item.DanhBo == DanhBo);
                case "TXL":
                    return db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == MaDon && item.DanhBo == DanhBo);
                case "TBC":
                    return db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == MaDon && item.DanhBo == DanhBo);
                default:
                    return false;
            }
        }

        public string getDiaChiXuatHoaDon(string DanhBo)
        {
            DCBD_ChiTietBienDong dcbd = db.DCBD_ChiTietBienDongs.Where(item => item.DanhBo == DanhBo && item.DiaChi_BD != null).OrderByDescending(item => item.CreateDate).FirstOrDefault();
            if (dcbd != null && dcbd.DiaChi_BD.Contains("("))
            {
                return dcbd.DiaChi_BD.Substring(dcbd.DiaChi_BD.IndexOf("("), dcbd.DiaChi_BD.Length - dcbd.DiaChi_BD.IndexOf("("));
            }
            else
                return "";
        }

        public DataTable getDS_BienDong_MaDon(string To, decimal MaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                                join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemCTDCBD.DCBD.MaDon == MaDon
                                orderby itemCTDCBD.CreateDate ascending
                                select new
                                {
                                    itemCTDCBD.ChuyenDocSo,
                                    ID = itemCTDCBD.MaCTDCBD,
                                    DieuChinh = "Biến Động",
                                    itemCTDCBD.ThongTin,
                                    itemCTDCBD.CongDung,
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
                                    itemCTDCBD.DinhMucHN,
                                    itemCTDCBD.DinhMucHN_BD,
                                    itemCTDCBD.SH_BD,
                                    itemCTDCBD.SX_BD,
                                    itemCTDCBD.DV_BD,
                                    itemCTDCBD.HCSN_BD,
                                    itemCTDCBD.PhieuDuocKy,
                                    itemCTDCBD.NguoiKy,
                                    itemCTDCBD.HieuLucKy,
                                    CreateBy = itemtableND.HoTen,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.DCBD.MaDonTXL == MaDon
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.DCBD.MaDonTBC == MaDon
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.DCBD.MaDonMoi == MaDon
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_BienDong_MaDon(string To, decimal TuMaDon, decimal DenMaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                                join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where (itemCTDCBD.DCBD.MaDon.Value.ToString().Substring(itemCTDCBD.DCBD.MaDon.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCBD.DCBD.MaDon.Value.ToString().Substring(itemCTDCBD.DCBD.MaDon.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                                && (itemCTDCBD.DCBD.MaDon >= TuMaDon && itemCTDCBD.DCBD.MaDon <= DenMaDon)
                                orderby itemCTDCBD.CreateDate ascending
                                select new
                                {
                                    itemCTDCBD.ChuyenDocSo,
                                    ID = itemCTDCBD.MaCTDCBD,
                                    DieuChinh = "Biến Động",
                                    itemCTDCBD.ThongTin,
                                    itemCTDCBD.CongDung,
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
                                    itemCTDCBD.DinhMucHN,
                                    itemCTDCBD.DinhMucHN_BD,
                                    itemCTDCBD.SH_BD,
                                    itemCTDCBD.SX_BD,
                                    itemCTDCBD.DV_BD,
                                    itemCTDCBD.HCSN_BD,
                                    itemCTDCBD.PhieuDuocKy,
                                    itemCTDCBD.NguoiKy,
                                    itemCTDCBD.HieuLucKy,
                                    CreateBy = itemtableND.HoTen,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where (itemCTDCBD.DCBD.MaDonTXL.Value.ToString().Substring(itemCTDCBD.DCBD.MaDonTXL.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCBD.DCBD.MaDonTXL.Value.ToString().Substring(itemCTDCBD.DCBD.MaDonTXL.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemCTDCBD.DCBD.MaDonTXL >= TuMaDon && itemCTDCBD.DCBD.MaDonTXL <= DenMaDon)
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where ((itemCTDCBD.DCBD.MaDonTBC.Value.ToString().Substring(itemCTDCBD.DCBD.MaDonTBC.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCBD.DCBD.MaDonTBC.Value.ToString().Substring(itemCTDCBD.DCBD.MaDonTBC.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemCTDCBD.DCBD.MaDonTBC >= TuMaDon && itemCTDCBD.DCBD.MaDonTBC <= DenMaDon))
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.DCBD.MaDonMoi >= TuMaDon && itemCTDCBD.DCBD.MaDonMoi <= DenMaDon
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_BienDong_MaDon(string To, int CreateBy, decimal MaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                                join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemCTDCBD.CreateBy == CreateBy && itemCTDCBD.DCBD.MaDon == MaDon
                                orderby itemCTDCBD.CreateDate ascending
                                select new
                                {
                                    itemCTDCBD.ChuyenDocSo,
                                    ID = itemCTDCBD.MaCTDCBD,
                                    DieuChinh = "Biến Động",
                                    itemCTDCBD.ThongTin,
                                    itemCTDCBD.CongDung,
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
                                    itemCTDCBD.DinhMucHN,
                                    itemCTDCBD.DinhMucHN_BD,
                                    itemCTDCBD.SH_BD,
                                    itemCTDCBD.SX_BD,
                                    itemCTDCBD.DV_BD,
                                    itemCTDCBD.HCSN_BD,
                                    itemCTDCBD.PhieuDuocKy,
                                    itemCTDCBD.NguoiKy,
                                    itemCTDCBD.HieuLucKy,
                                    CreateBy = itemtableND.HoTen,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateBy == CreateBy && itemCTDCBD.DCBD.MaDonTXL == MaDon
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateBy == CreateBy && itemCTDCBD.DCBD.MaDonTBC == MaDon
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateBy == CreateBy && itemCTDCBD.DCBD.MaDonMoi == MaDon
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_BienDong_MaDon(string To, int CreateBy, decimal TuMaDon, decimal DenMaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                                join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemCTDCBD.CreateBy == CreateBy && ((itemCTDCBD.DCBD.MaDon.Value.ToString().Substring(itemCTDCBD.DCBD.MaDon.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCBD.DCBD.MaDon.Value.ToString().Substring(itemCTDCBD.DCBD.MaDon.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                                && (itemCTDCBD.DCBD.MaDon >= TuMaDon && itemCTDCBD.DCBD.MaDon <= DenMaDon))
                                orderby itemCTDCBD.CreateDate ascending
                                select new
                                {
                                    itemCTDCBD.ChuyenDocSo,
                                    ID = itemCTDCBD.MaCTDCBD,
                                    DieuChinh = "Biến Động",
                                    itemCTDCBD.ThongTin,
                                    itemCTDCBD.CongDung,
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
                                    itemCTDCBD.DinhMucHN,
                                    itemCTDCBD.DinhMucHN_BD,
                                    itemCTDCBD.SH_BD,
                                    itemCTDCBD.SX_BD,
                                    itemCTDCBD.DV_BD,
                                    itemCTDCBD.HCSN_BD,
                                    itemCTDCBD.PhieuDuocKy,
                                    itemCTDCBD.NguoiKy,
                                    itemCTDCBD.HieuLucKy,
                                    CreateBy = itemtableND.HoTen,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateBy == CreateBy && ((itemCTDCBD.DCBD.MaDonTXL.Value.ToString().Substring(itemCTDCBD.DCBD.MaDonTXL.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCBD.DCBD.MaDonTXL.Value.ToString().Substring(itemCTDCBD.DCBD.MaDonTXL.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemCTDCBD.DCBD.MaDonTXL >= TuMaDon && itemCTDCBD.DCBD.MaDonTXL <= DenMaDon))
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateBy == CreateBy && ((itemCTDCBD.DCBD.MaDonTBC.Value.ToString().Substring(itemCTDCBD.DCBD.MaDonTBC.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCBD.DCBD.MaDonTBC.Value.ToString().Substring(itemCTDCBD.DCBD.MaDonTBC.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemCTDCBD.DCBD.MaDonTBC >= TuMaDon && itemCTDCBD.DCBD.MaDonTBC <= DenMaDon))
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateBy == CreateBy && itemCTDCBD.DCBD.MaDonMoi >= TuMaDon && itemCTDCBD.DCBD.MaDonMoi <= DenMaDon
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_BienDong_SoPhieu(decimal SoPhieu)
        {
            try
            {
                var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.MaCTDCBD == SoPhieu
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
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

        public DataTable getDS_BienDong_SoPhieu(decimal TuSoPhieu, decimal DenSoPhieu)
        {
            try
            {
                var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.MaCTDCBD.ToString().Substring(itemCTDCBD.MaCTDCBD.ToString().Length - 2, 2) == TuSoPhieu.ToString().Substring(TuSoPhieu.ToString().Length - 2, 2)
                            && itemCTDCBD.MaCTDCBD.ToString().Substring(itemCTDCBD.MaCTDCBD.ToString().Length - 2, 2) == DenSoPhieu.ToString().Substring(DenSoPhieu.ToString().Length - 2, 2)
                            && itemCTDCBD.MaCTDCBD >= TuSoPhieu && itemCTDCBD.MaCTDCBD <= DenSoPhieu
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
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

        public DataTable getDS_BienDong_SoPhieu(int CreateBy, decimal SoPhieu)
        {
            try
            {
                var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateBy == CreateBy && itemCTDCBD.MaCTDCBD == SoPhieu
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
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

        public DataTable getDS_BienDong_SoPhieu(int CreateBy, decimal TuSoPhieu, decimal DenSoPhieu)
        {
            try
            {
                var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateBy == CreateBy && itemCTDCBD.MaCTDCBD.ToString().Substring(itemCTDCBD.MaCTDCBD.ToString().Length - 2, 2) == TuSoPhieu.ToString().Substring(TuSoPhieu.ToString().Length - 2, 2)
                            && itemCTDCBD.MaCTDCBD.ToString().Substring(itemCTDCBD.MaCTDCBD.ToString().Length - 2, 2) == DenSoPhieu.ToString().Substring(DenSoPhieu.ToString().Length - 2, 2)
                            && itemCTDCBD.MaCTDCBD >= TuSoPhieu && itemCTDCBD.MaCTDCBD <= DenSoPhieu
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
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

        public DataTable getDS_BienDong_DanhBo(string DanhBo)
        {
            try
            {
                var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.DanhBo == DanhBo
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
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

        public DataTable getDS_BienDong_DanhBo(int CreateBy, string DanhBo)
        {
            try
            {
                var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateBy == CreateBy && itemCTDCBD.DanhBo == DanhBo
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
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

        public DataTable getDS_BienDong_CreateDate(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            try
            {
                var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateDate.Value.Date >= FromCreateDate.Date && itemCTDCBD.CreateDate.Value.Date <= ToCreateDate.Date
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                SoCongVan = itemCTDCBD.DCBD.MaDonMoi != null ? itemCTDCBD.DCBD.DonTu.SoCongVan : itemCTDCBD.DCBD.MaDon != null ? itemCTDCBD.DCBD.DonKH.SoCongVan : itemCTDCBD.DCBD.MaDonTXL != null ? itemCTDCBD.DCBD.DonTXL.SoCongVan : itemCTDCBD.DCBD.MaDonTBC != null ? itemCTDCBD.DCBD.DonTBC.SoCongVan : "",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
                                itemCTDCBD.GhiChu,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
                //string sql = "select MaCTDCBD,DanhBo,HopDong,HoTen,DiaChi,MaQuanPhuong,MSThue,GiaBieu,DinhMuc,SH,SX,DV,HCSN,Dot,Ky,Nam"
                //            + " ,ThongTin,HoTen_BD,DiaChi_BD,MSThue_BD,GiaBieu_BD,DinhMuc_BD,SH_BD,SX_BD,DV_BD,HCSN_BD,HieuLucKy,CreateDate=convert(varchar(10),CreateDate,103)"
                //            + " from DCBD_ChiTietBienDong where cast(CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and cast(CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'"
                //            + " order by CreateDate asc";

                //return ExecuteQuery_SqlDataAdapter_DataTable(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDS_BienDong_CreateDate(bool SoCongVan, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            try
            {
                if (SoCongVan == true)
                {
                    var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                                join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where (itemCTDCBD.DCBD.MaDon != null ? itemCTDCBD.DCBD.DonKH.SoCongVan : itemCTDCBD.DCBD.MaDonTXL != null ? itemCTDCBD.DCBD.DonTXL.SoCongVan : itemCTDCBD.DCBD.MaDonTBC != null ? itemCTDCBD.DCBD.DonTBC.SoCongVan : "") != ""
                                    && itemCTDCBD.CreateDate.Value.Date >= FromCreateDate.Date && itemCTDCBD.CreateDate.Value.Date <= ToCreateDate.Date
                                orderby itemCTDCBD.CreateDate ascending
                                select new
                                {
                                    itemCTDCBD.ChuyenDocSo,
                                    ID = itemCTDCBD.MaCTDCBD,
                                    DieuChinh = "Biến Động",
                                    itemCTDCBD.ThongTin,
                                    itemCTDCBD.CongDung,
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
                                    itemCTDCBD.DinhMucHN,
                                    itemCTDCBD.DinhMucHN_BD,
                                    itemCTDCBD.SH_BD,
                                    itemCTDCBD.SX_BD,
                                    itemCTDCBD.DV_BD,
                                    itemCTDCBD.HCSN_BD,
                                    itemCTDCBD.PhieuDuocKy,
                                    itemCTDCBD.NguoiKy,
                                    itemCTDCBD.HieuLucKy,
                                    CreateBy = itemtableND.HoTen,
                                };
                    return LINQToDataTable(query);
                }
                else
                {
                    var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                                join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where (itemCTDCBD.DCBD.MaDon != null ? itemCTDCBD.DCBD.DonKH.SoCongVan : itemCTDCBD.DCBD.MaDonTXL != null ? itemCTDCBD.DCBD.DonTXL.SoCongVan : itemCTDCBD.DCBD.MaDonTBC != null ? itemCTDCBD.DCBD.DonTBC.SoCongVan : "") == ""
                                    && itemCTDCBD.CreateDate.Value.Date >= FromCreateDate.Date && itemCTDCBD.CreateDate.Value.Date <= ToCreateDate.Date
                                orderby itemCTDCBD.CreateDate ascending
                                select new
                                {
                                    itemCTDCBD.ChuyenDocSo,
                                    ID = itemCTDCBD.MaCTDCBD,
                                    DieuChinh = "Biến Động",
                                    itemCTDCBD.ThongTin,
                                    itemCTDCBD.CongDung,
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
                                    itemCTDCBD.DinhMucHN,
                                    itemCTDCBD.DinhMucHN_BD,
                                    itemCTDCBD.SH_BD,
                                    itemCTDCBD.SX_BD,
                                    itemCTDCBD.DV_BD,
                                    itemCTDCBD.HCSN_BD,
                                    itemCTDCBD.PhieuDuocKy,
                                    itemCTDCBD.NguoiKy,
                                    itemCTDCBD.HieuLucKy,
                                    CreateBy = itemtableND.HoTen,
                                };
                    return LINQToDataTable(query);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDS_BienDong_CreateDate(int CreateBy, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            try
            {
                var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateBy == CreateBy && itemCTDCBD.CreateDate.Value.Date >= FromCreateDate.Date && itemCTDCBD.CreateDate.Value.Date <= ToCreateDate.Date
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
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

        public DataTable getDS_BienDong_CreateDate(DateTime FromCreateDate, DateTime ToCreateDate, int MaQuan)
        {
            //string sql = "select t1.*,t3.TenQuan from DCBD_ChiTietBienDong t1"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.QUAN t3 on t2.QUAN=t3.MAQUAN"
            //            + " where CAST(t1.CreateDate as date)>='" + TuNgay.ToString("yyyy-MM-dd") + "' and CAST(t1.CreateDate as date)<='" + DenNgay.ToString("yyyy-MM-dd") + "'"
            //            + " and MaQuan=" + MaQuan;
            //return ExecuteQuery_DataTable(sql);
            try
            {
                var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateDate.Value.Date >= FromCreateDate.Date && itemCTDCBD.CreateDate.Value.Date <= ToCreateDate.Date && Convert.ToInt32(itemCTDCBD.Quan) == MaQuan
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                SoCongVan = itemCTDCBD.DCBD.MaDonMoi != null ? itemCTDCBD.DCBD.DonTu.SoCongVan : itemCTDCBD.DCBD.MaDon != null ? itemCTDCBD.DCBD.DonKH.SoCongVan : itemCTDCBD.DCBD.MaDonTXL != null ? itemCTDCBD.DCBD.DonTXL.SoCongVan : itemCTDCBD.DCBD.MaDonTBC != null ? itemCTDCBD.DCBD.DonTBC.SoCongVan : "",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
                                itemCTDCBD.GhiChu,
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

        public DataTable getDS_BienDong_CreateDate(DateTime FromCreateDate, DateTime ToCreateDate, int MaQuan, int MaPhuong)
        {
            //string sql = "select t1.*,t3.TenQuan,t4.TenPhuong from DCBD_ChiTietBienDong t1"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.QUAN t3 on t2.QUAN=t3.MAQUAN"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.PHUONG t4 on t2.PHUONG=t4.MAPHUONG and t2.QUAN=t4.MAQUAN"
            //            + " where CAST(t1.CreateDate as date)>='" + FromCreateDate.ToString("yyyy-MM-dd") + "' and CAST(t1.CreateDate as date)<='" + ToCreateDate.ToString("yyyy-MM-dd") + "'"
            //            + " and t4.MaQuan=" + MaQuan + " and t4.MaPhuong=" + MaPhuong;
            //return ExecuteQuery_DataTable(sql);
            try
            {
                var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.CreateDate.Value.Date >= FromCreateDate.Date && itemCTDCBD.CreateDate.Value.Date <= ToCreateDate.Date && Convert.ToInt32(itemCTDCBD.Quan) == MaQuan && Convert.ToInt32(itemCTDCBD.Phuong) == MaPhuong
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                SoCongVan = itemCTDCBD.DCBD.MaDonMoi != null ? itemCTDCBD.DCBD.DonTu.SoCongVan : itemCTDCBD.DCBD.MaDon != null ? itemCTDCBD.DCBD.DonKH.SoCongVan : itemCTDCBD.DCBD.MaDonTXL != null ? itemCTDCBD.DCBD.DonTXL.SoCongVan : itemCTDCBD.DCBD.MaDonTBC != null ? itemCTDCBD.DCBD.DonTBC.SoCongVan : "",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
                                itemCTDCBD.GhiChu,
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

        public DataTable getDS_BienDong_HieuLucKy(string HieuLucKy)
        {
            try
            {
                var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.HieuLucKy == HieuLucKy
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                SoCongVan = itemCTDCBD.DCBD.MaDonMoi != null ? itemCTDCBD.DCBD.DonTu.SoCongVan : itemCTDCBD.DCBD.MaDon != null ? itemCTDCBD.DCBD.DonKH.SoCongVan : itemCTDCBD.DCBD.MaDonTXL != null ? itemCTDCBD.DCBD.DonTXL.SoCongVan : itemCTDCBD.DCBD.MaDonTBC != null ? itemCTDCBD.DCBD.DonTBC.SoCongVan : "",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
                                itemCTDCBD.GhiChu,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
                //string sql = "select MaCTDCBD,DanhBo,HopDong,HoTen,DiaChi,MaQuanPhuong,MSThue,GiaBieu,DinhMuc,SH,SX,DV,HCSN,Dot,Ky,Nam"
                //            + " ,ThongTin,HoTen_BD,DiaChi_BD,MSThue_BD,GiaBieu_BD,DinhMuc_BD,SH_BD,SX_BD,DV_BD,HCSN_BD,HieuLucKy,CreateDate=convert(varchar(10),CreateDate,103)"
                //            + " from DCBD_ChiTietBienDong where cast(CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and cast(CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'"
                //            + " order by CreateDate asc";

                //return ExecuteQuery_SqlDataAdapter_DataTable(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDS_BienDong_HieuLucKy(string HieuLucKy, int MaQuan)
        {
            try
            {
                var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.HieuLucKy == HieuLucKy && Convert.ToInt32(itemCTDCBD.Quan) == MaQuan
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                SoCongVan = itemCTDCBD.DCBD.MaDonMoi != null ? itemCTDCBD.DCBD.DonTu.SoCongVan : itemCTDCBD.DCBD.MaDon != null ? itemCTDCBD.DCBD.DonKH.SoCongVan : itemCTDCBD.DCBD.MaDonTXL != null ? itemCTDCBD.DCBD.DonTXL.SoCongVan : itemCTDCBD.DCBD.MaDonTBC != null ? itemCTDCBD.DCBD.DonTBC.SoCongVan : "",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
                                itemCTDCBD.GhiChu,
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

        public DataTable getDS_BienDong_HieuLucKy(string HieuLucKy, int MaQuan, int MaPhuong)
        {
            try
            {
                var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemND in db.Users on itemCTDCBD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCBD.HieuLucKy == HieuLucKy && Convert.ToInt32(itemCTDCBD.Quan) == MaQuan && Convert.ToInt32(itemCTDCBD.Phuong) == MaPhuong
                            orderby itemCTDCBD.CreateDate ascending
                            select new
                            {
                                itemCTDCBD.ChuyenDocSo,
                                ID = itemCTDCBD.MaCTDCBD,
                                DieuChinh = "Biến Động",
                                SoCongVan = itemCTDCBD.DCBD.MaDonMoi != null ? itemCTDCBD.DCBD.DonTu.SoCongVan : itemCTDCBD.DCBD.MaDon != null ? itemCTDCBD.DCBD.DonKH.SoCongVan : itemCTDCBD.DCBD.MaDonTXL != null ? itemCTDCBD.DCBD.DonTXL.SoCongVan : itemCTDCBD.DCBD.MaDonTBC != null ? itemCTDCBD.DCBD.DonTBC.SoCongVan : "",
                                itemCTDCBD.ThongTin,
                                itemCTDCBD.CongDung,
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
                                itemCTDCBD.DinhMucHN,
                                itemCTDCBD.DinhMucHN_BD,
                                itemCTDCBD.SH_BD,
                                itemCTDCBD.SX_BD,
                                itemCTDCBD.DV_BD,
                                itemCTDCBD.HCSN_BD,
                                itemCTDCBD.PhieuDuocKy,
                                itemCTDCBD.NguoiKy,
                                itemCTDCBD.HieuLucKy,
                                itemCTDCBD.GhiChu,
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

        public DataTable LoadDSCTDCBDSoCT(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                            join itemCTCT in db.ChungTu_ChiTiets on itemCTDCBD.DanhBo equals itemCTCT.DanhBo
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
        /// Lấy Danh Sách DCBD_ChiTietBienDong theo khoảng thời gian Chuyển Đọc Số
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCTDCBDbyNgayChuyenDocSo(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                var query = from itemCTDCBD in db.DCBD_ChiTietBienDongs
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
                                itemCTDCBD.CongDung,
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


        #endregion

        #region DCBD_ChiTietHoaDon (Chi Tiết Điều Chỉnh Hóa Đơn)

        public bool ThemDCHD(DCBD_ChiTietHoaDon ctdchd)
        {
            try
            {
                if (db.DCBD_ChiTietHoaDons.Count() > 0)
                {
                    string ID = "MaCTDCHD";
                    string Table = "DCBD_ChiTietHoaDon";
                    decimal MaCTDCHD = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    ctdchd.MaCTDCHD = getMaxNextIDTable(MaCTDCHD);
                }
                else
                    ctdchd.MaCTDCHD = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                ctdchd.CreateDate = DateTime.Now;
                ctdchd.CreateBy = CTaiKhoan.MaUser;
                db.DCBD_ChiTietHoaDons.InsertOnSubmit(ctdchd);
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

        public bool SuaDCHD(DCBD_ChiTietHoaDon ctdchd)
        {
            try
            {
                ctdchd.ModifyDate = DateTime.Now;
                ctdchd.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa DCBD_ChiTietHoaDon", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool XoaDCHD(DCBD_ChiTietHoaDon ctdchd)
        {
            try
            {
                CDonTu _cDonTu = new CDonTu();
                _cDonTu.Xoa_LichSu("DCBD_ChiTietHoaDon", (int)ctdchd.MaCTDCHD);
                decimal ID = ctdchd.MaDCBD;
                db.DCBD_ChiTietHoaDon_Hinhs.DeleteAllOnSubmit(ctdchd.DCBD_ChiTietHoaDon_Hinhs.ToList());
                db.DCBD_ChiTietHoaDons.DeleteOnSubmit(ctdchd);
                db.SubmitChanges();
                if (db.DCBD_ChiTietBienDongs.Any(item => item.MaDCBD == ID) == false && db.DCBD_ChiTietHoaDons.Any(item => item.MaDCBD == ID) == false)
                    db.DCBDs.DeleteOnSubmit(db.DCBDs.SingleOrDefault(item => item.MaDCBD == ID));
                db.SubmitChanges();
                //MessageBox.Show("Thành công Xóa DCBD_ChiTietHoaDon", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                return db.DCBD_ChiTietHoaDons.Max(itemCTDCHD => itemCTDCHD.MaCTDCHD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public DCBD_ChiTietHoaDon getHoaDon(decimal MaCTDCHD)
        {
            try
            {
                return db.DCBD_ChiTietHoaDons.SingleOrDefault(itemCTDCHD => itemCTDCHD.MaCTDCHD == MaCTDCHD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool checkExist_HoaDon(decimal MaCTDCHD)
        {
            return db.DCBD_ChiTietHoaDons.Any(item => item.MaCTDCHD == MaCTDCHD);
        }

        public bool checkExist_HoaDon(string SoHoaDon)
        {
            return db.DCBD_ChiTietHoaDons.Any(item => item.SoHoaDon == SoHoaDon);
        }

        public bool checkExist_HoaDon(string DanhBo, int Nam, int Ky)
        {
            return db.DCBD_ChiTietHoaDons.Any(item => item.DanhBo == DanhBo && item.Nam == Nam && item.Ky == Ky);
        }

        public bool CheckExist_HoaDon(string Loai, decimal MaDon, string DanhBo, string KyHD)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.DCBD_ChiTietHoaDons.Any(item => item.DCBD.MaDon == MaDon && item.DanhBo == DanhBo && item.KyHD == KyHD);
                case "TXL":
                    return db.DCBD_ChiTietHoaDons.Any(item => item.DCBD.MaDonTXL == MaDon && item.DanhBo == DanhBo && item.KyHD == KyHD);
                case "TBC":
                    return db.DCBD_ChiTietHoaDons.Any(item => item.DCBD.MaDonTBC == MaDon && item.DanhBo == DanhBo && item.KyHD == KyHD);
                default:
                    return false;
            }
        }

        public DataTable getHoaDon_DataTable(decimal MaCTDCHD)
        {
            var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                        join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemCTDCHD.MaCTDCHD == MaCTDCHD
                        && (itemCTDCHD.Nam > 2020 || (itemCTDCHD.Nam == 2020 && itemCTDCHD.Ky >= 7)) && itemCTDCHD.PhieuDuocKy == true
                        orderby itemCTDCHD.CreateDate ascending
                        select new
                        {
                            itemCTDCHD.ChuyenThuTien,
                            ID = itemCTDCHD.MaCTDCHD,
                            DieuChinh = "Hóa Đơn",
                            itemCTDCHD.KyHD,
                            itemCTDCHD.ThongTin,
                            itemCTDCHD.LyDoDieuChinh,
                            itemCTDCHD.CreateDate,
                            itemCTDCHD.CodeF2,
                            itemCTDCHD.BaoCaoThue,
                            itemCTDCHD.DanhBo,
                            itemCTDCHD.GiaBieu,
                            itemCTDCHD.GiaBieu_BD,
                            itemCTDCHD.DinhMuc,
                            itemCTDCHD.DinhMuc_BD,
                            itemCTDCHD.DinhMucHN,
                            itemCTDCHD.DinhMucHN_BD,
                            itemCTDCHD.TieuThu,
                            itemCTDCHD.TieuThu_BD,
                            itemCTDCHD.TienNuoc_Start,
                            itemCTDCHD.TienNuoc_End,
                            itemCTDCHD.ThueGTGT_Start,
                            itemCTDCHD.ThueGTGT_End,
                            itemCTDCHD.PhiBVMT_Start,
                            itemCTDCHD.PhiBVMT_End,
                            itemCTDCHD.TongCong_Start,
                            itemCTDCHD.TongCong_End,
                            itemCTDCHD.TongCong_BD,
                            itemCTDCHD.TangGiam,
                            itemCTDCHD.PhieuDuocKy,
                            itemCTDCHD.NguoiKy,
                            CreateBy = itemtableND.HoTen,
                            itemCTDCHD.Dot,
                            itemCTDCHD.Ky,
                            itemCTDCHD.Nam,
                            SoPhatHanh = itemCTDCHD.SoHD,
                            itemCTDCHD.SoHoaDon,
                            itemCTDCHD.HoTen_BD,
                            itemCTDCHD.DiaChi_BD,
                            itemCTDCHD.MST_BD,
                            itemCTDCHD.ChiTietMoi,
                            itemCTDCHD.KhauTru,
                            itemCTDCHD.DieuChinhGia,
                            itemCTDCHD.DieuChinhGia2,
                        };
            return LINQToDataTable(query);
//            string sql = "select "
//         + "          dchd.ChuyenThuTien,"
//         + "       ID = dchd.MaCTDCHD,"
//         + "       DieuChinh = N'Hóa Đơn',"
//         + "       dchd.KyHD,"
//         + "       dchd.ThongTin,"
//         + "       dchd.LyDoDieuChinh,"
//         + "       dchd.CreateDate,"
//         + "       dchd.CodeF2,"
//         + "       BaoCaoThue='false',"
//         + "       dchd.DanhBo,"
//         + "       dchd.GiaBieu,"
//         + "       dchd.GiaBieu_BD,"
//         + "       dchd.DinhMuc,"
//         + "       dchd.DinhMuc_BD,"
//          + "      dchd.DinhMucHN,"
//         + "       dchd.DinhMucHN_BD,"
//         + "       dchd.TieuThu,"
//         + "       dchd.TieuThu_BD,"
//         + "       dchd.TienNuoc_Start,"
//         + "       dchd.TienNuoc_End,"
//         + "       dchd.ThueGTGT_Start,"
//         + "       dchd.ThueGTGT_End,"
//         + "       dchd.PhiBVMT_Start,"
//          + "      dchd.PhiBVMT_End,"
//         + "       dchd.TongCong_Start,"
//         + "       dchd.TongCong_End,"
//        + "        dchd.TongCong_BD,"
//        + "        dchd.TangGiam,"
//        + "        dchd.PhieuDuocKy,"
//       + "         dchd.NguoiKy,"
//       + "         dchd.Dot,"
//       + "         dchd.Ky,"
//       + "         dchd.Nam,"
//      + "          SoPhatHanh = dchd.SoHD,"
//      + "          dchd.SoHoaDon,"
//      + "          dchd.HoTen_BD,"
//       + "         dchd.DiaChi_BD,"
//      + "          dchd.MST_BD,"
//       + "         dchd.ChiTietMoi,"
//      + "          dchd.KhauTru,"
//     + "           dchd.DieuChinhGia,"
//     + "           dchd.DieuChinhGia2"
//+ " from DCBD_ChiTietHoaDon dchd where MaCTDCHD =" + MaCTDCHD;
//            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_HoaDon_MaDon(string To, decimal MaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                                join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemCTDCHD.DCBD.MaDon == MaDon
                                orderby itemCTDCHD.CreateDate ascending
                                select new
                                {
                                    itemCTDCHD.ChuyenThuTien,
                                    ID = itemCTDCHD.MaCTDCHD,
                                    DieuChinh = "Hóa Đơn",
                                    itemCTDCHD.KyHD,
                                    itemCTDCHD.ThongTin,
                                    itemCTDCHD.LyDoDieuChinh,
                                    itemCTDCHD.CreateDate,
                                    itemCTDCHD.CodeF2,
                                    itemCTDCHD.DanhBo,
                                    itemCTDCHD.GiaBieu,
                                    itemCTDCHD.GiaBieu_BD,
                                    itemCTDCHD.DinhMuc,
                                    itemCTDCHD.DinhMuc_BD,
                                    itemCTDCHD.DinhMucHN,
                                    itemCTDCHD.DinhMucHN_BD,
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
                case "TXL":
                    query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.DCBD.MaDonTXL == MaDon
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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
                case "TBC":
                    query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.DCBD.MaDonTBC == MaDon
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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
                default:
                    query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.DCBD.MaDonMoi == MaDon
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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
        }

        public DataTable getDS_HoaDon_MaDon(string To, decimal TuMaDon, decimal DenMaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                                join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where ((itemCTDCHD.DCBD.MaDon.Value.ToString().Substring(itemCTDCHD.DCBD.MaDon.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCHD.DCBD.MaDon.Value.ToString().Substring(itemCTDCHD.DCBD.MaDon.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                                && (itemCTDCHD.DCBD.MaDon >= TuMaDon && itemCTDCHD.DCBD.MaDon <= DenMaDon))
                                orderby itemCTDCHD.CreateDate ascending
                                select new
                                {
                                    itemCTDCHD.ChuyenThuTien,
                                    ID = itemCTDCHD.MaCTDCHD,
                                    DieuChinh = "Hóa Đơn",
                                    itemCTDCHD.KyHD,
                                    itemCTDCHD.ThongTin,
                                    itemCTDCHD.LyDoDieuChinh,
                                    itemCTDCHD.CreateDate,
                                    itemCTDCHD.CodeF2,
                                    itemCTDCHD.DanhBo,
                                    itemCTDCHD.GiaBieu,
                                    itemCTDCHD.GiaBieu_BD,
                                    itemCTDCHD.DinhMuc,
                                    itemCTDCHD.DinhMuc_BD,
                                    itemCTDCHD.DinhMucHN,
                                    itemCTDCHD.DinhMucHN_BD,
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
                case "TXL":
                    query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where ((itemCTDCHD.DCBD.MaDonTXL.Value.ToString().Substring(itemCTDCHD.DCBD.MaDonTXL.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCHD.DCBD.MaDonTXL.Value.ToString().Substring(itemCTDCHD.DCBD.MaDonTXL.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemCTDCHD.DCBD.MaDonTXL >= TuMaDon && itemCTDCHD.DCBD.MaDonTXL <= DenMaDon))
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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
                case "TBC":
                    query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where ((itemCTDCHD.DCBD.MaDonTBC.Value.ToString().Substring(itemCTDCHD.DCBD.MaDonTBC.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCHD.DCBD.MaDonTBC.Value.ToString().Substring(itemCTDCHD.DCBD.MaDonTBC.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemCTDCHD.DCBD.MaDonTBC >= TuMaDon && itemCTDCHD.DCBD.MaDonTBC <= DenMaDon))
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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
                default:
                    query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.DCBD.MaDonMoi >= TuMaDon && itemCTDCHD.DCBD.MaDonMoi <= DenMaDon
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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
        }

        public DataTable getDS_HoaDon_MaDon(string To, int CreateBy, decimal MaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                                join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemCTDCHD.CreateBy == CreateBy && itemCTDCHD.DCBD.MaDon == MaDon
                                orderby itemCTDCHD.CreateDate ascending
                                select new
                                {
                                    itemCTDCHD.ChuyenThuTien,
                                    ID = itemCTDCHD.MaCTDCHD,
                                    DieuChinh = "Hóa Đơn",
                                    itemCTDCHD.KyHD,
                                    itemCTDCHD.ThongTin,
                                    itemCTDCHD.LyDoDieuChinh,
                                    itemCTDCHD.CreateDate,
                                    itemCTDCHD.CodeF2,
                                    itemCTDCHD.DanhBo,
                                    itemCTDCHD.GiaBieu,
                                    itemCTDCHD.GiaBieu_BD,
                                    itemCTDCHD.DinhMuc,
                                    itemCTDCHD.DinhMuc_BD,
                                    itemCTDCHD.DinhMucHN,
                                    itemCTDCHD.DinhMucHN_BD,
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
                case "TXL":
                    query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateBy == CreateBy && itemCTDCHD.DCBD.MaDonTXL == MaDon
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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
                case "TBC":
                    query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateBy == CreateBy && itemCTDCHD.DCBD.MaDonTBC == MaDon
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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
                default:
                    query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateBy == CreateBy && itemCTDCHD.DCBD.MaDonMoi == MaDon
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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
        }

        public DataTable getDS_HoaDon_MaDon(string To, int CreateBy, decimal TuMaDon, decimal DenMaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                                join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemCTDCHD.CreateBy == CreateBy && ((itemCTDCHD.DCBD.MaDon.Value.ToString().Substring(itemCTDCHD.DCBD.MaDon.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCHD.DCBD.MaDon.Value.ToString().Substring(itemCTDCHD.DCBD.MaDon.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                                && (itemCTDCHD.DCBD.MaDon >= TuMaDon && itemCTDCHD.DCBD.MaDon <= DenMaDon))
                                orderby itemCTDCHD.CreateDate ascending
                                select new
                                {
                                    itemCTDCHD.ChuyenThuTien,
                                    ID = itemCTDCHD.MaCTDCHD,
                                    DieuChinh = "Hóa Đơn",
                                    itemCTDCHD.KyHD,
                                    itemCTDCHD.ThongTin,
                                    itemCTDCHD.LyDoDieuChinh,
                                    itemCTDCHD.CreateDate,
                                    itemCTDCHD.CodeF2,
                                    itemCTDCHD.DanhBo,
                                    itemCTDCHD.GiaBieu,
                                    itemCTDCHD.GiaBieu_BD,
                                    itemCTDCHD.DinhMuc,
                                    itemCTDCHD.DinhMuc_BD,
                                    itemCTDCHD.DinhMucHN,
                                    itemCTDCHD.DinhMucHN_BD,
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
                case "TXL":
                    query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateBy == CreateBy && ((itemCTDCHD.DCBD.MaDonTXL.Value.ToString().Substring(itemCTDCHD.DCBD.MaDonTXL.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCHD.DCBD.MaDonTXL.Value.ToString().Substring(itemCTDCHD.DCBD.MaDonTXL.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemCTDCHD.DCBD.MaDonTXL >= TuMaDon && itemCTDCHD.DCBD.MaDonTXL <= DenMaDon))
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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
                case "TBC":
                    query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateBy == CreateBy && ((itemCTDCHD.DCBD.MaDonTBC.Value.ToString().Substring(itemCTDCHD.DCBD.MaDonTBC.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemCTDCHD.DCBD.MaDonTBC.Value.ToString().Substring(itemCTDCHD.DCBD.MaDonTBC.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemCTDCHD.DCBD.MaDonTBC >= TuMaDon && itemCTDCHD.DCBD.MaDonTBC <= DenMaDon))
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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
                default:
                    query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateBy == CreateBy && itemCTDCHD.DCBD.MaDonMoi >= TuMaDon && itemCTDCHD.DCBD.MaDonMoi <= DenMaDon
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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
        }

        public DataTable getDS_HoaDon_SoPhieu(decimal SoPhieu)
        {
            try
            {
                var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.MaCTDCHD == SoPhieu
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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

        public DataTable getDS_HoaDon_SoPhieu(decimal TuSoPhieu, decimal DenSoPhieu)
        {
            try
            {
                var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.MaCTDCHD.ToString().Substring(itemCTDCHD.MaCTDCHD.ToString().Length - 2, 2) == TuSoPhieu.ToString().Substring(TuSoPhieu.ToString().Length - 2, 2)
                            && itemCTDCHD.MaCTDCHD.ToString().Substring(itemCTDCHD.MaCTDCHD.ToString().Length - 2, 2) == DenSoPhieu.ToString().Substring(DenSoPhieu.ToString().Length - 2, 2)
                            && itemCTDCHD.MaCTDCHD >= TuSoPhieu && itemCTDCHD.MaCTDCHD <= DenSoPhieu
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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

        public DataTable getDS_HoaDon_SoPhieu(int CreateBy, decimal SoPhieu)
        {
            try
            {
                var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateBy == CreateBy && itemCTDCHD.MaCTDCHD == SoPhieu
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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

        public DataTable getDS_HoaDon_SoPhieu(int CreateBy, decimal TuSoPhieu, decimal DenSoPhieu)
        {
            try
            {
                var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateBy == CreateBy && itemCTDCHD.MaCTDCHD.ToString().Substring(itemCTDCHD.MaCTDCHD.ToString().Length - 2, 2) == TuSoPhieu.ToString().Substring(TuSoPhieu.ToString().Length - 2, 2)
                            && itemCTDCHD.MaCTDCHD.ToString().Substring(itemCTDCHD.MaCTDCHD.ToString().Length - 2, 2) == DenSoPhieu.ToString().Substring(DenSoPhieu.ToString().Length - 2, 2)
                            && itemCTDCHD.MaCTDCHD >= TuSoPhieu && itemCTDCHD.MaCTDCHD <= DenSoPhieu
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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

        public DataTable getDS_HoaDon_DanhBo(string DanhBo)
        {
            try
            {
                var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.DanhBo == DanhBo
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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

        public DataTable getDS_HoaDon_DanhBo(int CreateBy, string DanhBo)
        {
            try
            {
                var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateBy == CreateBy && itemCTDCHD.DanhBo == DanhBo
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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

        public DataTable getDS_HoaDon_CreateDate(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            try
            {
                var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateDate.Value.Date >= FromCreateDate.Date && itemCTDCHD.CreateDate.Value.Date <= ToCreateDate.Date
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
                                itemCTDCHD.TieuThu,
                                itemCTDCHD.TieuThu_BD,
                                itemCTDCHD.TienNuoc_Start,
                                itemCTDCHD.TienNuoc_End,
                                itemCTDCHD.ThueGTGT_Start,
                                itemCTDCHD.ThueGTGT_End,
                                itemCTDCHD.PhiBVMT_Start,
                                itemCTDCHD.PhiBVMT_End,
                                itemCTDCHD.TongCong_Start,
                                itemCTDCHD.TongCong_End,
                                itemCTDCHD.TongCong_BD,
                                itemCTDCHD.TangGiam,
                                itemCTDCHD.PhieuDuocKy,
                                itemCTDCHD.NguoiKy,
                                CreateBy = itemtableND.HoTen,
                                itemCTDCHD.Dot,
                                itemCTDCHD.Ky,
                                itemCTDCHD.Nam,
                                SoPhatHanh = itemCTDCHD.SoHD,
                                itemCTDCHD.SoHoaDon,
                                itemCTDCHD.HoTen_BD,
                                itemCTDCHD.DiaChi_BD,
                                itemCTDCHD.MST_BD,
                                itemCTDCHD.ChiTietMoi,
                            };
                return LINQToDataTable(query);
//                string sql = "select "
//                               + " dchd.ChuyenThuTien,"
//                        + "        ID = dchd.MaCTDCHD,"
//                       + "         DieuChinh =N'Hóa Đơn',"
//                        + "        dchd.KyHD,"
//                        + "        dchd.ThongTin,"
//                           + "     dchd.LyDoDieuChinh,"
//                              + "  dchd.CreateDate,"
//                  + "              dchd.CodeF2,"
//                     + "           dchd.DanhBo,"
//                        + "        dchd.GiaBieu,"
//                           + "     dchd.GiaBieu_BD,"
//                    + "            dchd.DinhMuc,"
//                     + "           dchd.DinhMuc_BD,"
//                    + "            dchd.DinhMucHN,"
//                    + "            dchd.DinhMucHN_BD,"
//                    + "            dchd.TieuThu,"
//                    + "            dchd.TieuThu_BD,"
//                    + "            dchd.TienNuoc_Start,"
//                    + "            dchd.TienNuoc_End,"
//                    + "            dchd.ThueGTGT_Start,"
//                    + "            dchd.ThueGTGT_End,"
//                    + "            dchd.PhiBVMT_Start,"
//                    + "            dchd.PhiBVMT_End,"
//                    + "            dchd.TongCong_Start,"
//                    + "            dchd.TongCong_End,"
//                    + "            dchd.TongCong_BD,"
//                    + "            dchd.TangGiam,"
//                    + "            dchd.PhieuDuocKy,"
//                    + "            dchd.NguoiKy,"
//                    + "            dchd.Dot,"
//                    + "            dchd.Ky,"
//                    + "            dchd.Nam,"
//                   + "             SoPhatHanh = dchd.SoHD,"
//                   + "             dchd.SoHoaDon,"
//                    + "            dchd.HoTen_BD,"
//                    + "            dchd.DiaChi_BD,"
//                    + "            dchd.MST_BD,"
//                   + "             dchd.ChiTietMoi"
//+ " from DCBD_ChiTietHoaDon dchd,"
//+ " (select DANHBA,NAM,KY,dot from server9.HOADON_TA.dbo.HOADON where CAST(NGAYGIAITRACH as date)='20211230' and MaNV_DangNgan is not  null and BaoCaoThue=1)hd"
//+ " where dchd.Nam=hd.NAM and dchd.Ky=hd.KY and dchd.Dot=hd.dot and hd.DANHBA=dchd.DanhBo and dchd.MaCTDCHD not in (2269721,6921)"
//+ " order by DANHBA";
//                return ExecuteQuery_DataTable(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDS_HoaDon_CreateDate(DateTime FromCreateDate, DateTime ToCreateDate, string Ky)
        {
            try
            {
                var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateDate.Value.Date >= FromCreateDate.Date && itemCTDCHD.CreateDate.Value.Date <= ToCreateDate.Date
                            && itemCTDCHD.KyHD == Ky
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
                                itemCTDCHD.TieuThu,
                                itemCTDCHD.TieuThu_BD,
                                itemCTDCHD.TienNuoc_Start,
                                itemCTDCHD.TienNuoc_End,
                                itemCTDCHD.ThueGTGT_Start,
                                itemCTDCHD.ThueGTGT_End,
                                itemCTDCHD.PhiBVMT_Start,
                                itemCTDCHD.PhiBVMT_End,
                                itemCTDCHD.TongCong_Start,
                                itemCTDCHD.TongCong_End,
                                itemCTDCHD.TongCong_BD,
                                itemCTDCHD.TangGiam,
                                itemCTDCHD.PhieuDuocKy,
                                itemCTDCHD.NguoiKy,
                                CreateBy = itemtableND.HoTen,
                                itemCTDCHD.Dot,
                                itemCTDCHD.Ky,
                                itemCTDCHD.Nam,
                                SoPhatHanh = itemCTDCHD.SoHD,
                                itemCTDCHD.SoHoaDon,
                                itemCTDCHD.HoTen_BD,
                                itemCTDCHD.DiaChi_BD,
                                itemCTDCHD.MST_BD,
                                itemCTDCHD.ChiTietMoi,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDS_HoaDonDienTuExcel_CreateDate(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            try
            {
                var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateDate.Value.Date >= FromCreateDate.Date && itemCTDCHD.CreateDate.Value.Date <= ToCreateDate.Date
                            && (itemCTDCHD.Nam > 2020 || (itemCTDCHD.Nam == 2020 && itemCTDCHD.Ky >= 7)) && itemCTDCHD.PhieuDuocKy == true
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
                                itemCTDCHD.TieuThu,
                                itemCTDCHD.TieuThu_BD,
                                itemCTDCHD.TienNuoc_Start,
                                itemCTDCHD.TienNuoc_End,
                                itemCTDCHD.ThueGTGT_Start,
                                itemCTDCHD.ThueGTGT_End,
                                itemCTDCHD.PhiBVMT_Start,
                                itemCTDCHD.PhiBVMT_End,
                                itemCTDCHD.TongCong_Start,
                                itemCTDCHD.TongCong_End,
                                itemCTDCHD.TongCong_BD,
                                itemCTDCHD.TangGiam,
                                itemCTDCHD.PhieuDuocKy,
                                itemCTDCHD.NguoiKy,
                                CreateBy = itemtableND.HoTen,
                                itemCTDCHD.Dot,
                                itemCTDCHD.Ky,
                                itemCTDCHD.Nam,
                                SoPhatHanh = itemCTDCHD.SoHD,
                                itemCTDCHD.SoHoaDon,
                                itemCTDCHD.HoTen_BD,
                                itemCTDCHD.DiaChi_BD,
                                itemCTDCHD.MST_BD,
                                itemCTDCHD.ChiTietMoi,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDS_HoaDon_CreateDate(int CreateBy, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            try
            {
                var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateBy == CreateBy && itemCTDCHD.CreateDate.Value.Date >= FromCreateDate.Date && itemCTDCHD.CreateDate.Value.Date <= ToCreateDate.Date
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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

        public DataTable getDS_HoaDon_CreateDate(int CreateBy, DateTime FromCreateDate, DateTime ToCreateDate, string Ky)
        {
            try
            {
                var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateBy == CreateBy && itemCTDCHD.CreateDate.Value.Date >= FromCreateDate.Date && itemCTDCHD.CreateDate.Value.Date <= ToCreateDate.Date
                            && itemCTDCHD.KyHD == Ky
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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

        public DataTable getDS_HoaDon_CreateDate(DateTime FromCreateDate, DateTime ToCreateDate, int MaQuan)
        {
            //string sql = "select t1.*,t3.TenQuan from DCBD_ChiTietHoaDon t1"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.QUAN t3 on t2.QUAN=t3.MAQUAN"
            //            + " where CAST(t1.CreateDate as date)>='" + FromCreateDate.ToString("yyyy-MM-dd") + "' and CAST(t1.CreateDate as date)<='" + ToCreateDate.ToString("yyyy-MM-dd") + "'"
            //            + " and MaQuan=" + MaQuan;
            //return ExecuteQuery_DataTable(sql);
            try
            {
                var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateDate.Value.Date >= FromCreateDate.Date && itemCTDCHD.CreateDate.Value.Date <= ToCreateDate.Date && Convert.ToInt32(itemCTDCHD.Quan) == MaQuan
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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

        public DataTable getDS_HoaDon_CreateDate(DateTime FromCreateDate, DateTime ToCreateDate, int MaQuan, int MaPhuong)
        {
            //string sql = "select t1.*,t3.TenQuan from DCBD_ChiTietHoaDon t1"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.QUAN t3 on t2.QUAN=t3.MAQUAN"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.PHUONG t4 on t2.PHUONG=t4.MAPHUONG and t2.QUAN=t4.MAQUAN"
            //            + " where CAST(t1.CreateDate as date)>='" + TuNgay.ToString("yyyy-MM-dd") + "' and CAST(t1.CreateDate as date)<='" + DenNgay.ToString("yyyy-MM-dd") + "'"
            //            + " and t4.MaQuan=" + MaQuan + " and t4.MaPhuong=" + MaPhuong;
            //return ExecuteQuery_DataTable(sql);
            try
            {
                var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.CreateDate.Value.Date >= FromCreateDate.Date && itemCTDCHD.CreateDate.Value.Date <= ToCreateDate.Date && Convert.ToInt32(itemCTDCHD.Quan) == MaQuan && Convert.ToInt32(itemCTDCHD.Phuong) == MaPhuong
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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

        public DataTable getDS_HoaDon_HieuLucKy(string HieuLucKy)
        {
            try
            {
                var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.KyHD == HieuLucKy
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                itemCTDCHD.ChuyenThuTien,
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
                                itemCTDCHD.TieuThu,
                                itemCTDCHD.TieuThu_BD,
                                itemCTDCHD.TienNuoc_Start,
                                itemCTDCHD.TienNuoc_End,
                                itemCTDCHD.ThueGTGT_Start,
                                itemCTDCHD.ThueGTGT_End,
                                itemCTDCHD.PhiBVMT_Start,
                                itemCTDCHD.PhiBVMT_End,
                                itemCTDCHD.TongCong_Start,
                                itemCTDCHD.TongCong_End,
                                itemCTDCHD.TongCong_BD,
                                itemCTDCHD.TangGiam,
                                itemCTDCHD.PhieuDuocKy,
                                itemCTDCHD.NguoiKy,
                                CreateBy = itemtableND.HoTen,
                                itemCTDCHD.Dot,
                                itemCTDCHD.Ky,
                                itemCTDCHD.Nam,
                                SoPhatHanh = itemCTDCHD.SoHD,
                                itemCTDCHD.SoHoaDon,
                                itemCTDCHD.HoTen_BD,
                                itemCTDCHD.DiaChi_BD,
                                itemCTDCHD.MST_BD,
                                itemCTDCHD.ChiTietMoi,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDS_HoaDon_HieuLucKy(string HieuLucKy, int MaQuan)
        {
            try
            {
                var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.KyHD == HieuLucKy && Convert.ToInt32(itemCTDCHD.Quan) == MaQuan
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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

        public DataTable getDS_HoaDon_HieuLucKy(string HieuLucKy, int MaQuan, int MaPhuong)
        {
            try
            {
                var query = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                            join itemND in db.Users on itemCTDCHD.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemCTDCHD.KyHD == HieuLucKy && Convert.ToInt32(itemCTDCHD.Quan) == MaQuan && Convert.ToInt32(itemCTDCHD.Phuong) == MaPhuong
                            orderby itemCTDCHD.CreateDate ascending
                            select new
                            {
                                ID = itemCTDCHD.MaCTDCHD,
                                DieuChinh = "Hóa Đơn",
                                itemCTDCHD.KyHD,
                                itemCTDCHD.ThongTin,
                                itemCTDCHD.LyDoDieuChinh,
                                itemCTDCHD.CreateDate,
                                itemCTDCHD.CodeF2,
                                itemCTDCHD.DanhBo,
                                itemCTDCHD.GiaBieu,
                                itemCTDCHD.GiaBieu_BD,
                                itemCTDCHD.DinhMuc,
                                itemCTDCHD.DinhMuc_BD,
                                itemCTDCHD.DinhMucHN,
                                itemCTDCHD.DinhMucHN_BD,
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

        public DataTable getDS_HoaDon(string DanhBo, int Nam, int Ky)
        {
            return LINQToDataTable(db.DCBD_ChiTietHoaDons.Where(itemCTDCHD => itemCTDCHD.DanhBo == DanhBo && itemCTDCHD.Nam == Nam && itemCTDCHD.Ky == Ky).ToList());
        }

        public DataTable getDS_HoaDon_BaoCaoThue_DangNgan(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select ChuyenThuTien,"
                        + " ID = MaCTDCHD,"
                        + " DieuChinh = N'Hóa Đơn',"
                        + " KyHD,"
                        + " ThongTin,"
                        + " LyDoDieuChinh,"
                        + " dchd.CreateDate,"
                        + " CodeF2,"
                        + " DanhBo,"
                        + " GiaBieu,"
                        + " GiaBieu_BD,"
                        + " DinhMuc,"
                        + " DinhMuc_BD,"
                        + " dchd.DinhMucHN,"
                        + " DinhMucHN_BD,"
                        + " dchd.TieuThu,"
                        + " TieuThu_BD,"
                        + " TienNuoc_Start,"
                        + " TienNuoc_End,"
                        + " ThueGTGT_Start,"
                        + " ThueGTGT_End,"
                        + " PhiBVMT_Start,"
                        + " PhiBVMT_End,"
                        + " TongCong_Start,"
                        + " TongCong_End,"
                        + " TongCong_BD,"
                        + " TangGiam,"
                        + " PhieuDuocKy,"
                        + " NguoiKy,"
                        + " CreateBy = u.HoTen,"
                        + " dchd.Dot,"
                        + " dchd.Ky,"
                        + " dchd.Nam,"
                        + " SoPhatHanh = SoHD,"
                        + " dchd.SoHoaDon,"
                        + " HoTen_BD,"
                        + " DiaChi_BD,"
                        + " MST_BD,"
                        + " ChiTietMoi"
                + " from DCBD_ChiTietHoaDon dchd"
                + " left join Users u on dchd.CreateBy=u.MaU,"
                + " server9.HOADON_TA.dbo.HOADON hd"
                + " where CAST(NGAYGIAITRACH as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(NGAYGIAITRACH as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and hd.BaoCaoThue=1"
                + " and dchd.DanhBo=hd.DANHBA and dchd.Nam=hd.NAM and dchd.Ky=hd.KY"
                + " order by dchd.CreateDate asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DCBD_ChiTietHoaDon getHoaDon_Last(string DanhBo, int Nam, int Ky)
        {
            if (db.DCBD_ChiTietHoaDons.Any(itemCTDCHD => itemCTDCHD.DanhBo == DanhBo && itemCTDCHD.Nam == Nam && itemCTDCHD.Ky == Ky) == true)
                return db.DCBD_ChiTietHoaDons.Where(itemCTDCHD => itemCTDCHD.DanhBo == DanhBo && itemCTDCHD.Nam == Nam && itemCTDCHD.Ky == Ky).OrderByDescending(item => item.CreateDate).First();
            else
                return null;
        }

        #endregion

        //MaDonMoi

        public bool checkExist(int MaDon)
        {
            return db.DCBDs.Any(item => item.MaDonMoi == MaDon);
        }

        public DCBD get(int MaDon)
        {
            return db.DCBDs.SingleOrDefault(item => item.MaDonMoi == MaDon);
        }

        public bool checkExist_BienDong(int MaDon, string DanhBo)
        {
            return db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == MaDon && item.DanhBo == DanhBo);
        }

        public bool checkExist_HoaDon(int MaDon, string DanhBo, string KyHD)
        {
            return db.DCBD_ChiTietHoaDons.Any(item => item.DCBD.MaDonMoi == MaDon && item.DanhBo == DanhBo && item.KyHD == KyHD);
        }

        #region Hình

        public bool Them_Hinh(DCBD_ChiTietBienDong_Hinh en)
        {
            try
            {
                if (db.DCBD_ChiTietBienDong_Hinhs.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = db.DCBD_ChiTietBienDong_Hinhs.Max(item => item.ID) + 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.DCBD_ChiTietBienDong_Hinhs.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_Hinh(DCBD_ChiTietBienDong_Hinh en)
        {
            try
            {
                db.DCBD_ChiTietBienDong_Hinhs.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public DCBD_ChiTietBienDong_Hinh get_BienDong_Hinh(int ID)
        {
            return db.DCBD_ChiTietBienDong_Hinhs.SingleOrDefault(item => item.ID == ID);
        }

        //
        public bool Them_Hinh(DCBD_ChiTietHoaDon_Hinh en)
        {
            try
            {
                if (db.DCBD_ChiTietHoaDon_Hinhs.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = db.DCBD_ChiTietHoaDon_Hinhs.Max(item => item.ID) + 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.DCBD_ChiTietHoaDon_Hinhs.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_Hinh(DCBD_ChiTietHoaDon_Hinh en)
        {
            try
            {
                db.DCBD_ChiTietHoaDon_Hinhs.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public DCBD_ChiTietHoaDon_Hinh get_HoaDon_Hinh(int ID)
        {
            return db.DCBD_ChiTietHoaDon_Hinhs.SingleOrDefault(item => item.ID == ID);
        }
        #endregion
    }
}

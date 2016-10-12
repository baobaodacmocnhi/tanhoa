using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;
using System.Data;

namespace KTKS_DonKH.DAL.KhachHang
{
    class CDonKH : CDAL
    {
        /// <summary>
        /// Lấy Mã Đơn kế tiếp
        /// </summary>
        /// <returns></returns>
        public decimal getMaxNextID()
        {
            try
            {
                if (db.DonKHs.Count() > 0)
                {
                    string ID = "MaDon";
                    string Table = "DonKH";
                    decimal MaDon = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    return getMaxNextIDTable(MaDon);
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

        public DonKH getDonKHbyID(decimal MaDon)
        {
            try
            {
                return db.DonKHs.SingleOrDefault(itemDonKH => itemDonKH.MaDon == MaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemDonKH(DonKH donkh)
        {
            try
            {
                    donkh.CreateDate = DateTime.Now;
                    donkh.CreateBy = CTaiKhoan.MaUser;
                    db.DonKHs.InsertOnSubmit(donkh);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm DonKH", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public DataTable LoadDSDonKHByMaDon(decimal MaDon)
        {
            try
            {
                    var query = from itemDonKH in db.DonKHs
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                join itemUser in db.Users on itemDonKH.CreateBy equals itemUser.MaU
                                where itemDonKH.MaDon==MaDon
                                select new
                                {
                                    itemDonKH.MaDon,
                                    itemDonKH.MaLD,
                                    itemLoaiDon.TenLD,
                                    itemDonKH.CreateDate,
                                    itemDonKH.DanhBo,
                                    itemDonKH.HoTen,
                                    itemDonKH.DiaChi,
                                    itemDonKH.NoiDung,
                                    CreateBy = itemUser.HoTen,
                                    //itemDonKH.NVKiemTra,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonKHByMaDons(decimal FromMaDon, decimal ToMaDon)
        {
            try
            {
                    var query = from itemDonKH in db.DonKHs
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                join itemUser in db.Users on itemDonKH.CreateBy equals itemUser.MaU
                                where (((itemDonKH.MaDon.ToString().Substring(itemDonKH.MaDon.ToString().Length - 2, 2) == FromMaDon.ToString().Substring(FromMaDon.ToString().Length - 2, 2) && itemDonKH.MaDon.ToString().Substring(itemDonKH.MaDon.ToString().Length - 2, 2) == ToMaDon.ToString().Substring(ToMaDon.ToString().Length - 2, 2))
                                && (itemDonKH.MaDon >= FromMaDon && itemDonKH.MaDon <= ToMaDon)))
                                select new
                                {
                                    itemDonKH.MaDon,
                                    itemDonKH.MaLD,
                                    itemLoaiDon.TenLD,
                                    itemDonKH.CreateDate,
                                    itemDonKH.DanhBo,
                                    itemDonKH.HoTen,
                                    itemDonKH.DiaChi,
                                    itemDonKH.NoiDung,
                                    CreateBy = itemUser.HoTen,
                                    //itemDonKH.NVKiemTra,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonKHByDanhBo(string DanhBo)
        {
            try
            {
                    var query = from itemDonKH in db.DonKHs
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                join itemUser in db.Users on itemDonKH.CreateBy equals itemUser.MaU
                                where itemDonKH.DanhBo == DanhBo
                                //orderby itemDonKH.CreateDate ascending
                                select new
                                {
                                    itemDonKH.MaDon,
                                    itemDonKH.MaLD,
                                    itemLoaiDon.TenLD,
                                    itemDonKH.CreateDate,
                                    itemDonKH.DanhBo,
                                    itemDonKH.HoTen,
                                    itemDonKH.DiaChi,
                                    itemDonKH.NoiDung,
                                    CreateBy = itemUser.HoTen,
                                    //itemDonKH.NVKiemTra,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonKHBySoCongVan(string SoCongVan)
        {
            try
            {
                    var query = from itemDonKH in db.DonKHs
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                join itemUser in db.Users on itemDonKH.CreateBy equals itemUser.MaU
                                where itemDonKH.SoCongVan.Contains(SoCongVan)
                                //orderby itemDonKH.CreateDate ascending
                                select new
                                {
                                    itemDonKH.MaDon,
                                    itemDonKH.MaLD,
                                    itemLoaiDon.TenLD,
                                    itemDonKH.CreateDate,
                                    itemDonKH.DanhBo,
                                    itemDonKH.HoTen,
                                    itemDonKH.DiaChi,
                                    itemDonKH.NoiDung,
                                    itemDonKH.GhiChuChuyenKT,
                                    CreateBy = itemUser.HoTen,
                                    //itemDonKH.NVKiemTra,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonKHByDate(DateTime Ngay)
        {
            try
            {
                    var query = from itemDonKH in db.DonKHs
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                join itemUser in db.Users on itemDonKH.CreateBy equals itemUser.MaU
                                where itemDonKH.CreateDate.Value.Date == Ngay.Date
                                //orderby itemDonKH.CreateDate ascending
                                select new
                                {
                                    itemDonKH.MaDon,
                                    itemDonKH.MaLD,
                                    itemLoaiDon.TenLD,
                                    itemDonKH.CreateDate,
                                    itemDonKH.DanhBo,
                                    itemDonKH.HoTen,
                                    itemDonKH.DiaChi,
                                    itemDonKH.NoiDung,
                                    CreateBy = itemUser.HoTen,
                                    itemDonKH.TienTrinh,
                                    //itemDonKH.NVKiemTra,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonKHByDates(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                    var query = from itemDonKH in db.DonKHs
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                join itemUser in db.Users on itemDonKH.CreateBy equals itemUser.MaU
                                where itemDonKH.CreateDate.Value.Date >= TuNgay.Date && itemDonKH.CreateDate.Value.Date <= DenNgay.Date
                                //orderby itemDonKH.CreateDate ascending
                                select new
                                {
                                    itemDonKH.MaDon,
                                    itemDonKH.MaLD,
                                    itemLoaiDon.TenLD,
                                    itemDonKH.CreateDate,
                                    itemDonKH.DanhBo,
                                    itemDonKH.HoTen,
                                    itemDonKH.DiaChi,
                                    itemDonKH.NoiDung,
                                    CreateBy = itemUser.HoTen,
                                    itemDonKH.TienTrinh,
                                    //itemDonKH.NVKiemTra,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadBaoCaoDSDonKH(DateTime TuNgay)
        {
            try
            {
                    var query = from itemDonKH in db.DonKHs
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                where itemDonKH.CreateDate.Value.Date == TuNgay.Date
                                orderby itemDonKH.MaDon ascending
                                select new
                                {
                                    itemDonKH.MaDon,
                                    itemDonKH.MaLD,
                                    itemLoaiDon.TenLD,
                                    CapDM = itemDonKH.DangKyDM,
                                    itemDonKH.GiamDM,
                                    itemDonKH.CatChuyenDM,
                                    itemDonKH.KiemTraDHN,
                                    itemDonKH.MatDHN,
                                    itemDonKH.HuHongDHN,
                                    itemDonKH.ChiNiem,
                                    itemDonKH.TienNuoc,
                                    itemDonKH.ChiSoNuoc,
                                    DieuChinhSoNha = itemDonKH.DCSoNha,
                                    ThayDoiTenHopDong = itemDonKH.SangTen,
                                    itemDonKH.ThayDoiMST,
                                    ThayDoiGiaNuoc = itemDonKH.DonGiaNuoc,
                                    itemDonKH.TamNgung,
                                    itemDonKH.HuyHopDong,
                                    itemDonKH.MoNuoc,
                                    itemDonKH.LoaiKhac,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadBaoCaoDSDonKH(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                    var query = from itemDonKH in db.DonKHs
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                where itemDonKH.CreateDate.Value.Date >= TuNgay.Date && itemDonKH.CreateDate.Value.Date <= DenNgay.Date
                                orderby itemDonKH.MaDon ascending
                                select new
                                {
                                    itemDonKH.MaDon,
                                    itemDonKH.MaLD,
                                    itemLoaiDon.TenLD,
                                    CapDM = itemDonKH.DangKyDM,
                                    itemDonKH.GiamDM,
                                    itemDonKH.CatChuyenDM,
                                    itemDonKH.KiemTraDHN,
                                    itemDonKH.MatDHN,
                                    itemDonKH.HuHongDHN,
                                    itemDonKH.ChiNiem,
                                    itemDonKH.TienNuoc,
                                    itemDonKH.ChiSoNuoc,
                                    DieuChinhSoNha = itemDonKH.DCSoNha,
                                    ThayDoiTenHopDong = itemDonKH.SangTen,
                                    itemDonKH.ThayDoiMST,
                                    ThayDoiGiaNuoc = itemDonKH.DonGiaNuoc,
                                    itemDonKH.TamNgung,
                                    itemDonKH.HuyHopDong,
                                    itemDonKH.MoNuoc,
                                    itemDonKH.LoaiKhac,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool SuaDonKH(DonKH donkh)
        {
            try
            {
                    donkh.ModifyDate = DateTime.Now;
                    donkh.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa DonKH", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool SuaDonKH(DonKH donkh, bool inhertance)
        {
            try
            {
                if (inhertance)
                {
                    donkh.ModifyDate = DateTime.Now;
                    donkh.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa DonKH", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.DonKHs);
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

        public bool XoaDonKH(DonKH donkh)
        {
            try
            {
                    db.DonKHs.DeleteOnSubmit(donkh);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Xóa DonKH", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// Kiểm Tra đơn đó có được nhận hay chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns></returns>
        public bool CheckNhan(decimal MaDon)
        {
            try
            {
                if (db.DonKHs.Any(itemDonKH => itemDonKH.MaDon==MaDon && itemDonKH.Nhan == true))
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

        #region LichSuChuyenVanPhong

        public bool ThemLichSuChuyenVanPhong(LichSuChuyenVanPhong lichsuchuyenvanphong)
        {
            try
            {
                    if (db.LichSuChuyenVanPhongs.Count() > 0)
                    {
                        string ID = "MaLSChuyen";
                        string Table = "LichSuChuyenVanPhong";
                        decimal MaLSChuyen = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //decimal MaLSChuyenKT = db.LichSuChuyenKTs.Max(itemLSCKT => itemLSCKT.MaLSChuyenKT);
                        lichsuchuyenvanphong.MaLSChuyen = getMaxNextIDTable(MaLSChuyen);
                    }
                    else
                        lichsuchuyenvanphong.MaLSChuyen = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    lichsuchuyenvanphong.CreateDate = DateTime.Now;
                    lichsuchuyenvanphong.CreateBy = CTaiKhoan.MaUser;
                    db.LichSuChuyenVanPhongs.InsertOnSubmit(lichsuchuyenvanphong);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm TTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                db = new DB_KTKS_DonKHDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SuaLichSuChuyenVanPhong(LichSuChuyenVanPhong lichsuchuyenvanphong)
        {
            try
            {
                    lichsuchuyenvanphong.ModifyDate = DateTime.Now;
                    lichsuchuyenvanphong.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa TTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool XoaLichSuChuyenVanPhong(LichSuChuyenVanPhong lichsuchuyenvanphong)
        {
            try
            {
                    db.LichSuChuyenVanPhongs.DeleteOnSubmit(lichsuchuyenvanphong);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa TTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// Lấy Danh Sách Chuyển Kiểm Tra theo Mã Đơn TXL
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns></returns>
        public DataTable LoadDSLichSuChuyenVanPhongbyMaDonTXL(decimal MaDonTXL)
        {
            try
            {
                    var query = from itemLSCVP in db.LichSuChuyenVanPhongs
                                join itemUser in db.Users on itemLSCVP.NguoiDi equals itemUser.MaU
                                where itemLSCVP.MaDonTXL == MaDonTXL
                                select new
                                {
                                    Table = "LichSuChuyenVanPhong",
                                    itemLSCVP.MaLSChuyen,
                                    itemLSCVP.NgayChuyen,
                                    itemLSCVP.GhiChuChuyen,
                                    NguoiDi = itemUser.HoTen,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSLichSuChuyenVanPhongbyMaDonTKH(decimal MaDonKH)
        {
            try
            {
                    var query = from itemLSCVP in db.LichSuChuyenVanPhongs
                                join itemUser in db.Users on itemLSCVP.NguoiDi equals itemUser.MaU
                                where itemLSCVP.MaDon == MaDonKH
                                select new
                                {
                                    Table = "LichSuChuyenVanPhong",
                                    itemLSCVP.MaLSChuyen,
                                    itemLSCVP.NgayChuyen,
                                    LoaiChuyen = "Văn Phòng",
                                    itemLSCVP.GhiChuChuyen,
                                    NguoiDi = itemUser.HoTen,
                                    ChiTiet = "",
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public LichSuChuyenVanPhong getLichSuChuyenVanPhongbyID(decimal MaLSChuyenVanPhong)
        {
            try
            {
                return db.LichSuChuyenVanPhongs.SingleOrDefault(itemLSCVP => itemLSCVP.MaLSChuyen == MaLSChuyenVanPhong);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion

        #region LichSuChuyenBanDoiKhac

        public bool ThemLichSuChuyenBanDoiKhac(LichSuChuyenBanDoiKhac lichsuchuyenbandoikhac)
        {
            try
            {
                    if (db.LichSuChuyenBanDoiKhacs.Count() > 0)
                    {
                        string ID = "MaLSChuyen";
                        string Table = "LichSuChuyenBanDoiKhac";
                        decimal MaLSChuyen = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //decimal MaLSChuyenKT = db.LichSuChuyenKTs.Max(itemLSCKT => itemLSCKT.MaLSChuyenKT);
                        lichsuchuyenbandoikhac.MaLSChuyen = getMaxNextIDTable(MaLSChuyen);
                    }
                    else
                        lichsuchuyenbandoikhac.MaLSChuyen = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    lichsuchuyenbandoikhac.CreateDate = DateTime.Now;
                    lichsuchuyenbandoikhac.CreateBy = CTaiKhoan.MaUser;
                    db.LichSuChuyenBanDoiKhacs.InsertOnSubmit(lichsuchuyenbandoikhac);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm TTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                db = new DB_KTKS_DonKHDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SuaLichSuChuyenBanDoiKhac(LichSuChuyenBanDoiKhac lichsuchuyenbandoikhac)
        {
            try
            {
                    lichsuchuyenbandoikhac.ModifyDate = DateTime.Now;
                    lichsuchuyenbandoikhac.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa TTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool XoaLichSuChuyenBanDoiKhac(LichSuChuyenBanDoiKhac lichsuchuyenbandoikhac)
        {
            try
            {
                    db.LichSuChuyenBanDoiKhacs.DeleteOnSubmit(lichsuchuyenbandoikhac);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa TTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// Lấy Danh Sách Chuyển Kiểm Tra theo Mã Đơn TXL
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns></returns>
        public DataTable LoadDSLichSuChuyenBanDoiKhacbyMaDonTXL(decimal MaDonTXL)
        {
            try
            {
                    var query = from itemLSCVP in db.LichSuChuyenBanDoiKhacs
                                //join itemUser in db.Users on itemLSCVP.NguoiDi equals itemUser.MaU
                                where itemLSCVP.MaDonTXL == MaDonTXL
                                select new
                                {
                                    Table = "LichSuChuyenBanDoiKhac",
                                    itemLSCVP.MaLSChuyen,
                                    itemLSCVP.NgayChuyen,
                                    itemLSCVP.GhiChuChuyen,
                                    //NguoiDi = itemUser.HoTen,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSLichSuChuyenBanDoiKhacbyMaDonTKH(decimal MaDonKH)
        {
            try
            {
                    var query = from itemLSCVP in db.LichSuChuyenBanDoiKhacs
                                //join itemUser in db.Users on itemLSCVP.NguoiDi equals itemUser.MaU
                                where itemLSCVP.MaDon == MaDonKH
                                select new
                                {
                                    Table = "LichSuChuyenBanDoiKhac",
                                    itemLSCVP.MaLSChuyen,
                                    itemLSCVP.NgayChuyen,
                                    LoaiChuyen = "Tiến Trình Giải Quyết",
                                    itemLSCVP.GhiChuChuyen,
                                    NguoiDi = "",
                                    ChiTiet = "",
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public LichSuChuyenBanDoiKhac getLichSuChuyenBanDoiKhacbyID(decimal MaLSChuyen)
        {
            try
            {
                return db.LichSuChuyenBanDoiKhacs.SingleOrDefault(item => item.MaLSChuyen == MaLSChuyen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion

        #region LichSuChuyenKhac

        public bool ThemLichSuChuyenKhac(LichSuChuyenKhac lichsuchuyenkhac)
        {
            try
            {
                    if (db.LichSuChuyenKhacs.Count() > 0)
                    {
                        string ID = "MaLSChuyen";
                        string Table = "LichSuChuyenKhac";
                        decimal MaLSChuyen = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //decimal MaLSChuyenKT = db.LichSuChuyenKTs.Max(itemLSCKT => itemLSCKT.MaLSChuyenKT);
                        lichsuchuyenkhac.MaLSChuyen = getMaxNextIDTable(MaLSChuyen);
                    }
                    else
                        lichsuchuyenkhac.MaLSChuyen = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    lichsuchuyenkhac.CreateDate = DateTime.Now;
                    lichsuchuyenkhac.CreateBy = CTaiKhoan.MaUser;
                    db.LichSuChuyenKhacs.InsertOnSubmit(lichsuchuyenkhac);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm TTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                db = new DB_KTKS_DonKHDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SuaLichSuChuyenKhac(LichSuChuyenKhac lichsuchuyenkhac)
        {
            try
            {
                    lichsuchuyenkhac.ModifyDate = DateTime.Now;
                    lichsuchuyenkhac.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa TTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool XoaLichSuChuyenKhac(LichSuChuyenKhac lichsuchuyenkhac)
        {
            try
            {
                    db.LichSuChuyenKhacs.DeleteOnSubmit(lichsuchuyenkhac);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa TTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// Lấy Danh Sách Chuyển Kiểm Tra theo Mã Đơn TXL
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns></returns>
        public DataTable LoadDSLichSuChuyenKhacbyMaDonTXL(decimal MaDonTXL)
        {
            try
            {
                    var query = from itemLSCVP in db.LichSuChuyenKhacs
                                //join itemUser in db.Users on itemLSCVP.NguoiDi equals itemUser.MaU
                                where itemLSCVP.MaDonTXL == MaDonTXL
                                select new
                                {
                                    Table = "LichSuChuyenKhac",
                                    itemLSCVP.MaLSChuyen,
                                    itemLSCVP.NgayChuyen,
                                    itemLSCVP.GhiChuChuyen,
                                    //NguoiDi = itemUser.HoTen,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSLichSuChuyenKhacbyMaDonTKH(decimal MaDonKH)
        {
            try
            {
                    var query = from itemLSCVP in db.LichSuChuyenKhacs
                                //join itemUser in db.Users on itemLSCVP.NguoiDi equals itemUser.MaU
                                where itemLSCVP.MaDon == MaDonKH
                                select new
                                {
                                    Table = "LichSuChuyenKhac",
                                    itemLSCVP.MaLSChuyen,
                                    itemLSCVP.NgayChuyen,
                                    LoaiChuyen = "Khác",
                                    itemLSCVP.GhiChuChuyen,
                                    NguoiDi = "",
                                    ChiTiet = "",
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public LichSuChuyenKhac getLichSuChuyenKhacbyID(decimal MaLSChuyen)
        {
            try
            {
                return db.LichSuChuyenKhacs.SingleOrDefault(item => item.MaLSChuyen == MaLSChuyen);
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

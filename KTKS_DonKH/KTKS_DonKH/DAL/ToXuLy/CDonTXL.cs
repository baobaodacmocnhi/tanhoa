﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.ToXuLy
{
    class CDonTXL : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng CDonTXL & LichSuChuyenKT

        #region CDonTXL

        /// <summary>
        /// Lấy Mã Đơn kế tiếp
        /// </summary>
        /// <returns></returns>
        public decimal getMaxNextID()
        {
            try
            {
                if (db.DonTXLs.Count() > 0)
                {
                    string ID = "MaDon";
                    string Table = "DonTXL";
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

        public DonTXL getDonTXLbyID(decimal MaDon)
        {
            try
            {
                return db.DonTXLs.SingleOrDefault(itemDonTXL => itemDonTXL.MaDon == MaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Đơn Tổ Xử Lý kèm theo điều kiện Đơn được chuyến đến đúng Bộ Phận xử lý
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="MaChuyen"></param>
        /// <returns></returns>
        public DonTXL getDonTXLbyID(decimal MaDon, string MaChuyen)
        {
            try
            {
                return db.DonTXLs.SingleOrDefault(itemDonTXL => itemDonTXL.MaDon == MaDon && itemDonTXL.MaChuyen == MaChuyen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemDonTXL(DonTXL dontxl)
        {
            try
            {
                    dontxl.CreateDate = DateTime.Now;
                    dontxl.CreateBy = CTaiKhoan.MaUser;
                    db.DonTXLs.InsertOnSubmit(dontxl);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm DonKH", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(decimal MaDon)
        {
            return db.DonTXLs.Any(item => item.MaDon == MaDon);
        }

        public DataTable LoadDSAllDonTXL()
        {
            try
            {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                join itemUser in db.Users on itemDonTXL.CreateBy equals itemUser.MaU
                                orderby itemDonTXL.CreateDate descending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    CreateBy = itemUser.HoTen,
                                    itemDonTXL.NguoiDi,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTXLChuaChuyen()
        {
            try
            {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                join itemUser in db.Users on itemDonTXL.CreateBy equals itemUser.MaU
                                where itemDonTXL.ChuyenKT == false
                                orderby itemDonTXL.MaDon ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    CreateBy = itemUser.HoTen,
                                    itemDonTXL.NguoiDi,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTXLDaChuyen()
        {
            try
            {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                join itemUser in db.Users on itemDonTXL.CreateBy equals itemUser.MaU
                                where itemDonTXL.ChuyenKT == true
                                orderby itemDonTXL.CreateDate descending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    CreateBy = itemUser.HoTen,
                                    itemDonTXL.NguoiDi,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTXLByMaDon(decimal MaDon)
        {
            try
            {
                var query = from itemDonTXL in db.DonTXLs
                            join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                            join itemUser in db.Users on itemDonTXL.CreateBy equals itemUser.MaU
                            where itemDonTXL.MaDon == MaDon
                            select new
                            {
                                itemDonTXL.MaDon,
                                itemLoaiDonTXL.STT,
                                itemLoaiDonTXL.TenLD,
                                itemDonTXL.SoCongVan,
                                itemDonTXL.CreateDate,
                                itemDonTXL.DanhBo,
                                itemDonTXL.HoTen,
                                itemDonTXL.DiaChi,
                                itemDonTXL.NoiDung,
                                itemDonTXL.MaChuyen,
                                itemDonTXL.LyDoChuyen,
                                itemDonTXL.SoLuongDiaChi,
                                CreateBy = itemUser.HoTen,
                                itemDonTXL.NguoiDi,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTXLByDanhBo(string DanhBo)
        {
            try
            {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                join itemUser in db.Users on itemDonTXL.CreateBy equals itemUser.MaU
                                where itemDonTXL.DanhBo == DanhBo
                                //orderby itemDonTXL.CreateDate ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.STT,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    CreateBy = itemUser.HoTen,
                                    itemDonTXL.NguoiDi,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTXLByDiaChi(string DiaChi)
        {
            try
            {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                join itemUser in db.Users on itemDonTXL.CreateBy equals itemUser.MaU
                                where itemDonTXL.DiaChi.Contains(DiaChi)
                                //orderby itemDonTXL.CreateDate ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.STT,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    CreateBy = itemUser.HoTen,
                                    itemDonTXL.NguoiDi,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTXLBySoCongVan(string SoCongVan)
        {
            try
            {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                join itemUser in db.Users on itemDonTXL.CreateBy equals itemUser.MaU
                                where itemDonTXL.SoCongVan.Contains(SoCongVan)
                                //orderby itemDonTXL.CreateDate ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.STT,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    CreateBy = itemUser.HoTen,
                                    itemDonTXL.NguoiDi,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTXLByDate(DateTime TuNgay)
        {
            try
            {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                join itemUser in db.Users on itemDonTXL.CreateBy equals itemUser.MaU
                                where itemDonTXL.CreateDate.Value.Date == TuNgay.Date
                                //orderby itemDonTXL.CreateDate ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    CreateBy = itemUser.HoTen,
                                    itemDonTXL.NguoiDi,
                                    itemDonTXL.TienTrinh,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTXLByDates(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                join itemUser in db.Users on itemDonTXL.CreateBy equals itemUser.MaU
                                where itemDonTXL.CreateDate.Value.Date >= TuNgay.Date && itemDonTXL.CreateDate.Value.Date<=DenNgay.Date
                                //orderby itemDonTXL.CreateDate ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.STT,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    CreateBy = itemUser.HoTen,
                                    itemDonTXL.NguoiDi,
                                    itemDonTXL.TienTrinh,
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
        /// Lấy Danh Sách Thông Kê Đơn được chuyển cho những ai
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSDonTXLDaChuyenKT(DateTime TuNgay)
        {
            try
            {
                    var query = from itemLSCKT in db.LichSuChuyenKTs
                                join itemDonTXL in db.DonTXLs on itemLSCKT.MaDonTXL equals itemDonTXL.MaDon
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                join itemUser in db.Users on itemDonTXL.CreateBy equals itemUser.MaU
                                where itemLSCKT.MaDonTXL!=null&&itemLSCKT.NgayChuyen.Value.Date == TuNgay.Date
                                orderby itemDonTXL.MaDon ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    CreateBy = itemUser.HoTen,
                                    itemLSCKT.NguoiDi,
                                    GhiChuChuyenKT=itemLSCKT.GhiChuChuyen,
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
        /// Lấy Danh Sách Thông Kê Đơn được chuyển cho những ai
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSDonTXLDaChuyenKT(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                    var query = from itemLSCKT in db.LichSuChuyenKTs
                                join itemDonTXL in db.DonTXLs on itemLSCKT.MaDonTXL equals itemDonTXL.MaDon
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                join itemUser in db.Users on itemDonTXL.CreateBy equals itemUser.MaU
                                where itemLSCKT.MaDonTXL != null && itemLSCKT.NgayChuyen.Value.Date >= TuNgay.Date && itemLSCKT.NgayChuyen.Value.Date <= DenNgay.Date
                                orderby itemDonTXL.MaDon ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    CreateBy = itemUser.HoTen,
                                    itemLSCKT.NguoiDi,
                                    GhiChuChuyenKT = itemLSCKT.GhiChuChuyen,
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
        /// Lấy Danh Sách Thông Kê Đơn được chuyển cho những ai
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSDonTKHDaChuyenKT(DateTime TuNgay)
        {
            try
            {
                    var query = from itemLSCKT in db.LichSuChuyenKTs
                                join itemDonKH in db.DonKHs on itemLSCKT.MaDon equals itemDonKH.MaDon
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                join itemUser in db.Users on itemDonKH.CreateBy equals itemUser.MaU
                                where itemLSCKT.MaDon != null && itemLSCKT.NgayChuyen.Value.Date == TuNgay.Date
                                orderby itemDonKH.MaDon ascending
                                select new
                                {
                                    itemDonKH.MaDon,
                                    itemLoaiDon.TenLD,
                                    itemDonKH.SoCongVan,
                                    itemDonKH.CreateDate,
                                    itemDonKH.DanhBo,
                                    itemDonKH.HoTen,
                                    itemDonKH.DiaChi,
                                    itemDonKH.NoiDung,
                                    CreateBy = itemUser.HoTen,
                                    itemLSCKT.NguoiDi,
                                    itemDonKH.GhiChuChuyenKT,
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
        /// Lấy Danh Sách Thông Kê Đơn được chuyển cho những ai
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSDonTKHDaChuyenKT(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                    var query = from itemLSCKT in db.LichSuChuyenKTs
                                join itemDonKH in db.DonKHs on itemLSCKT.MaDon equals itemDonKH.MaDon
                                join itemLoaiDon in db.LoaiDonTXLs on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                join itemUser in db.Users on itemDonKH.CreateBy equals itemUser.MaU
                                where itemLSCKT.MaDon != null && itemLSCKT.NgayChuyen.Value.Date >= TuNgay.Date && itemLSCKT.NgayChuyen.Value.Date <= DenNgay.Date
                                orderby itemDonKH.MaDon ascending
                                select new
                                {
                                    itemDonKH.MaDon,
                                    itemLoaiDon.TenLD,
                                    itemDonKH.SoCongVan,
                                    itemDonKH.CreateDate,
                                    itemDonKH.DanhBo,
                                    itemDonKH.HoTen,
                                    itemDonKH.DiaChi,
                                    itemDonKH.NoiDung,
                                    CreateBy = itemUser.HoTen,
                                    itemLSCKT.NguoiDi,
                                    itemDonKH.GhiChuChuyenKT,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTKHDaChuyenKT(decimal FromMaDon, decimal ToMaDon)
        {
            try
            {
                    var query = from itemLSCKT in db.LichSuChuyenKTs
                                join itemDonKH in db.DonKHs on itemLSCKT.MaDon equals itemDonKH.MaDon
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                join itemUser in db.Users on itemDonKH.CreateBy equals itemUser.MaU
                                where itemLSCKT.MaDon != null
                                && (((itemDonKH.MaDon.ToString().Substring(itemDonKH.MaDon.ToString().Length - 2, 2) == FromMaDon.ToString().Substring(FromMaDon.ToString().Length - 2, 2) && itemDonKH.MaDon.ToString().Substring(itemDonKH.MaDon.ToString().Length - 2, 2) == ToMaDon.ToString().Substring(ToMaDon.ToString().Length - 2, 2))
                                && (itemDonKH.MaDon >= FromMaDon && itemDonKH.MaDon <= ToMaDon)))
                                orderby itemDonKH.MaDon ascending
                                select new
                                {
                                    itemDonKH.MaDon,
                                    itemLoaiDon.TenLD,
                                    itemDonKH.SoCongVan,
                                    itemDonKH.CreateDate,
                                    itemDonKH.DanhBo,
                                    itemDonKH.HoTen,
                                    itemDonKH.DiaChi,
                                    itemDonKH.NoiDung,
                                    CreateBy = itemUser.HoTen,
                                    itemLSCKT.NguoiDi,
                                    itemDonKH.GhiChuChuyenKT,
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
        /// Lấy Danh Sách Thông Kê Đơn được chuyển cho những ai theo Số Công Văn
        /// </summary>
        /// <param name="SoCongVan"></param>
        /// <returns></returns>
        public DataTable LoadDSDonTXLDaChuyenKTbySoCongVan(string SoCongVan)
        {
            try
            {
                    var query = from itemLSCKT in db.LichSuChuyenKTs
                                join itemDonTXL in db.DonTXLs on itemLSCKT.MaDonTXL equals itemDonTXL.MaDon
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                join itemUser in db.Users on itemDonTXL.CreateBy equals itemUser.MaU
                                where itemLSCKT.MaDonTXL!=null && itemDonTXL.SoCongVan.Contains(SoCongVan)
                                orderby itemDonTXL.MaDon ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    CreateBy = itemUser.HoTen,
                                    itemLSCKT.NguoiDi,
                                    GhiChuChuyenKT = itemLSCKT.GhiChuChuyen,
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
        /// Lấy Danh Sách Thông Kê Đơn được chuyển cho những ai theo Số Công Văn
        /// </summary>
        /// <param name="SoCongVan"></param>
        /// <returns></returns>
        public DataTable LoadDSDonTKHDaChuyenKTbySoCongVan(string SoCongVan)
        {
            try
            {
                    var query = from itemLSCKT in db.LichSuChuyenKTs
                                join itemDonKH in db.DonKHs on itemLSCKT.MaDon equals itemDonKH.MaDon
                                join itemLoaiDon in db.LoaiDonTXLs on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                join itemUser in db.Users on itemDonKH.CreateBy equals itemUser.MaU
                                where itemLSCKT.MaDon != null && itemDonKH.SoCongVan.Contains(SoCongVan)
                                orderby itemDonKH.MaDon ascending
                                select new
                                {
                                    itemDonKH.MaDon,
                                    itemLoaiDon.TenLD,
                                    itemDonKH.SoCongVan,
                                    itemDonKH.CreateDate,
                                    itemDonKH.DanhBo,
                                    itemDonKH.HoTen,
                                    itemDonKH.DiaChi,
                                    itemDonKH.NoiDung,
                                    CreateBy = itemUser.HoTen,
                                    itemLSCKT.NguoiDi,
                                    itemDonKH.GhiChuChuyenKT,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTKHDaChuyenTXL(DateTime TuNgay)
        {
            try
            {
                    var query = from itemDonKH in db.DonKHs
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                where itemDonKH.ChuyenToXuLy == true && itemDonKH.NgayChuyenToXuLy.Value.Date == TuNgay.Date
                                orderby itemDonKH.MaDon ascending
                                select new
                                {
                                    itemDonKH.MaDon,
                                    itemLoaiDon.TenLD,
                                    itemDonKH.SoCongVan,
                                    itemDonKH.CreateDate,
                                    itemDonKH.DanhBo,
                                    itemDonKH.HoTen,
                                    itemDonKH.DiaChi,
                                    itemDonKH.NoiDung,
                                    GhiChuChuyenKT = itemDonKH.GhiChuChuyenToXuLy,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTKHDaChuyenTXL(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                    var query = from itemDonKH in db.DonKHs
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                where itemDonKH.ChuyenToXuLy == true && itemDonKH.NgayChuyenToXuLy.Value.Date >= TuNgay.Date && itemDonKH.NgayChuyenToXuLy.Value.Date <= DenNgay.Date
                                orderby itemDonKH.MaDon ascending
                                select new
                                {
                                    itemDonKH.MaDon,
                                    itemLoaiDon.TenLD,
                                    itemDonKH.SoCongVan,
                                    itemDonKH.CreateDate,
                                    itemDonKH.DanhBo,
                                    itemDonKH.HoTen,
                                    itemDonKH.DiaChi,
                                    itemDonKH.NoiDung,
                                    GhiChuChuyenKT = itemDonKH.GhiChuChuyenToXuLy,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTKHDaChuyenTXLbySoCongVan(string SoCongVan)
        {
            try
            {
                    var query = from itemDonKH in db.DonKHs
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                where itemDonKH.ChuyenToXuLy == true && itemDonKH.SoCongVan==SoCongVan
                                orderby itemDonKH.MaDon ascending
                                select new
                                {
                                    itemDonKH.MaDon,
                                    itemLoaiDon.TenLD,
                                    itemDonKH.SoCongVan,
                                    itemDonKH.CreateDate,
                                    itemDonKH.DanhBo,
                                    itemDonKH.HoTen,
                                    itemDonKH.DiaChi,
                                    itemDonKH.NoiDung,
                                    GhiChuChuyenKT = itemDonKH.GhiChuChuyenToXuLy,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTXLDaChuyenTKHByDate(DateTime TuNgay)
        {
            try
            {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                where itemDonTXL.ChuyenToKhachHang == true && itemDonTXL.NgayChuyenToKhachHang.Value.Date == TuNgay.Date
                                orderby itemDonTXL.MaDon ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    GhiChuChuyenKT = itemDonTXL.GhiChuChuyenToKhachHang,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTXLDaChuyenTKHByDates(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                where itemDonTXL.ChuyenToKhachHang == true && itemDonTXL.NgayChuyenToKhachHang.Value.Date >= TuNgay.Date && itemDonTXL.NgayChuyenToKhachHang.Value.Date <= DenNgay.Date
                                orderby itemDonTXL.MaDon ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    GhiChuChuyenKT = itemDonTXL.GhiChuChuyenToKhachHang,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTXLDaChuyenTKHBySoCongVan(string SoCongVan)
        {
            try
            {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                where itemDonTXL.ChuyenToKhachHang == true && itemDonTXL.SoCongVan.Contains(SoCongVan)
                                orderby itemDonTXL.MaDon ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    GhiChuChuyenKT = itemDonTXL.GhiChuChuyenToKhachHang,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTXLDaChuyenBanDoiKhacByDate(DateTime TuNgay)
        {
            try
            {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                where itemDonTXL.ChuyenBanDoiKhac == true && itemDonTXL.NgayChuyenBanDoiKhac.Value.Date == TuNgay.Date
                                orderby itemDonTXL.MaDon ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    GhiChuChuyenKT = itemDonTXL.GhiChuChuyenBanDoiKhac,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTXLDaChuyenBanDoiKhacByDates(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                where itemDonTXL.ChuyenBanDoiKhac == true && itemDonTXL.NgayChuyenBanDoiKhac.Value.Date >= TuNgay.Date && itemDonTXL.NgayChuyenBanDoiKhac.Value.Date <= DenNgay.Date
                                orderby itemDonTXL.MaDon ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    GhiChuChuyenKT = itemDonTXL.GhiChuChuyenBanDoiKhac,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTXLDaChuyenBanDoiKhacBySoCongVan(string SoCongVan)
        {
            try
            {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                where itemDonTXL.ChuyenBanDoiKhac == true && itemDonTXL.SoCongVan.Contains(SoCongVan)
                                orderby itemDonTXL.MaDon ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    GhiChuChuyenKT = itemDonTXL.GhiChuChuyenBanDoiKhac,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTXLDaChuyenKhacByDate(DateTime TuNgay)
        {
            try
            {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                where itemDonTXL.ChuyenKhac == true && itemDonTXL.NgayChuyenKhac.Value.Date == TuNgay.Date
                                orderby itemDonTXL.MaDon ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    GhiChuChuyenKT = itemDonTXL.GhiChuChuyenKhac,
                                    itemDonTXL.ChiBoSung,
                                    itemDonTXL.GiuNguyen,
                                    itemDonTXL.DieuChinh,
                                    itemDonTXL.TruyThu,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTXLDaChuyenKhacByDates(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                where itemDonTXL.ChuyenKhac == true && itemDonTXL.NgayChuyenKhac.Value.Date >= TuNgay.Date && itemDonTXL.NgayChuyenKhac.Value.Date <= DenNgay.Date
                                orderby itemDonTXL.MaDon ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    GhiChuChuyenKT = itemDonTXL.GhiChuChuyenKhac,
                                    itemDonTXL.ChiBoSung,
                                    itemDonTXL.GiuNguyen,
                                    itemDonTXL.DieuChinh,
                                    itemDonTXL.TruyThu,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTXLDaChuyenKhacBySoCongVan(string SoCongVan)
        {
            try
            {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                where itemDonTXL.ChuyenKhac == true && itemDonTXL.SoCongVan.Contains(SoCongVan)
                                orderby itemDonTXL.MaDon ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.SoCongVan,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
                                    GhiChuChuyenKT = itemDonTXL.GhiChuChuyenKhac,
                                    itemDonTXL.ChiBoSung,
                                    itemDonTXL.GiuNguyen,
                                    itemDonTXL.DieuChinh,
                                    itemDonTXL.TruyThu,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool SuaDonTXL(DonTXL dontxl)
        {
            try
            {
                    dontxl.ModifyDate = DateTime.Now;
                    dontxl.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa DonTXL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool SuaDonTXL(DonTXL dontxl, bool inhertance)
        {
            try
            {
                if (inhertance)
                {
                    dontxl.ModifyDate = DateTime.Now;
                    dontxl.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa DonTXL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.DonTXLs);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool XoaDonTXL(DonTXL dontxl)
        {
            try
            {
                    db.DonTXLs.DeleteOnSubmit(dontxl);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Xóa DonTXL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// Kiểm Tra đơn đó có được nhận hay chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns></returns>
        public bool CheckNhan(decimal MaDon)
        {
            try
            {
                if (db.DonTXLs.Any(itemDonTXL => itemDonTXL.MaDon == MaDon && itemDonTXL.Nhan == true))
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

        public decimal getMaXepDonNext(int MaLD)
        {
            if (db.DonTXLs.Where(itemDonTXL => itemDonTXL.MaLD == MaLD).Max(itemDonTXL => itemDonTXL.MaXepDon) != null)
            {
                decimal a = getMaxNextIDTable(db.DonTXLs.Where(itemDonTXL => itemDonTXL.MaLD == MaLD).Max(itemDonTXL => itemDonTXL.MaXepDon).Value);
                return a;
            }
            else
                return decimal.Parse("1" + DateTime.Now.ToString("yy"));
        }

        /// <summary>
        /// Lấy thông tin Đơn Tổ Xử Lý
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="MaChuyen">nơi đơn được chuyến đến để xử lý</param>
        /// <param name="MaNoiChuyenDen"></param>
        /// <param name="NoiChuyenDen"></param>
        /// <param name="LyDoChuyenDen"></param>
        public void GetInfobyMaDon(decimal MaDon, string MaChuyen, out string MaNoiChuyenDen, out string NoiChuyenDen, out string LyDoChuyenDen)
        {
            MaNoiChuyenDen = "";
            NoiChuyenDen = "";
            LyDoChuyenDen = "";
            if (db.DonTXLs.Any(itemDonTXL => itemDonTXL.MaDon == MaDon && itemDonTXL.Nhan == false && itemDonTXL.MaChuyen == MaChuyen))
            {
                MaNoiChuyenDen = db.DonTXLs.SingleOrDefault(itemDonTXL => itemDonTXL.MaDon == MaDon && itemDonTXL.Nhan == false && itemDonTXL.MaChuyen == MaChuyen).MaDon.ToString();
                NoiChuyenDen = "Tổ Xử Lý";
                LyDoChuyenDen = db.DonTXLs.SingleOrDefault(itemDonTXL => itemDonTXL.MaDon == MaDon && itemDonTXL.Nhan == false && itemDonTXL.MaChuyen == MaChuyen).LyDoChuyen;
            }
            //if (db.KTXMs.Any(itemKTXM => itemKTXM.MaDon == MaDon && itemKTXM.Nhan == false && itemKTXM.MaChuyen == MaChuyen))
            //{
            //    MaNoiChuyenDen = db.KTXMs.SingleOrDefault(itemKTXM => itemKTXM.MaDon == MaDon && itemKTXM.Nhan == false && itemKTXM.MaChuyen == MaChuyen).MaKTXM.ToString();
            //    NoiChuyenDen = "Kiểm Tra Xác Minh";
            //    LyDoChuyenDen = db.KTXMs.SingleOrDefault(itemKTXM => itemKTXM.MaDon == MaDon && itemKTXM.Nhan == false && itemKTXM.MaChuyen == MaChuyen).LyDoChuyen;
            //}
        }

        #endregion

        #region LichSuChuyenKT

        

        /// <summary>
        /// Lấy Danh Sách Chuyển Kiểm Tra theo Mã Đơn TXL
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns></returns>
        public DataTable LoadDSLichSuChuyenKTbyMaDonTXL(decimal MaDonTXL)
        {
            try
            {
                    var query = from itemLSCKT in db.LichSuChuyenKTs
                                join itemUser in db.Users on itemLSCKT.NguoiDi equals itemUser.MaU
                                where itemLSCKT.MaDonTXL == MaDonTXL
                                select new
                                {
                                    Table = "LichSuChuyenKT",
                                    itemLSCKT.MaLSChuyen,
                                    itemLSCKT.NgayChuyen,
                                    itemLSCKT.GhiChuChuyen,
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

        public DataTable LoadDSLichSuChuyenKTbyMaDonTKH(decimal MaDonKH)
        {
            try
            {
                    var query = from itemLSCKT in db.LichSuChuyenKTs
                                join itemUser in db.Users on itemLSCKT.NguoiDi equals itemUser.MaU
                                where itemLSCKT.MaDon == MaDonKH
                                select new
                                {
                                    Table = "LichSuChuyenKT",
                                    itemLSCKT.MaLSChuyen,
                                    itemLSCKT.NgayChuyen,
                                    LoaiChuyen="Kiểm Tra",
                                    itemLSCKT.GhiChuChuyen,
                                    NguoiDi = itemUser.HoTen,
                                    ChiTiet="",
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
        /// Kiểm tra Đơn có được giải quyết bởi người được giao hay chưa
        /// </summary>
        /// <param name="MaU"></param>
        /// <param name="MaDonTXL"></param>
        /// <returns></returns>
        public bool CheckGiaiQuyetDonTXLbyUser(int MaU, decimal MaDonTXL,out string NgayGiaiQuyet)
        {
            NgayGiaiQuyet = "";
            if (db.CTKTXMs.Any(itemCTKTXM => itemCTKTXM.KTXM.MaDonTXL == MaDonTXL && itemCTKTXM.CreateBy == MaU))
            {
                NgayGiaiQuyet = db.CTKTXMs.FirstOrDefault(itemCTKTXM => itemCTKTXM.KTXM.MaDonTXL == MaDonTXL && itemCTKTXM.CreateBy == MaU).NgayKTXM.Value.ToString("dd/MM/yyyy");
                return true;
            }
            else
                if (db.CTBamChis.Any(itemCTBamChi => itemCTBamChi.BamChi.MaDonTXL == MaDonTXL && itemCTBamChi.CreateBy == MaU))
                {
                    NgayGiaiQuyet = db.CTBamChis.FirstOrDefault(itemCTBamChi => itemCTBamChi.BamChi.MaDonTXL == MaDonTXL && itemCTBamChi.CreateBy == MaU).NgayBC.Value.ToString("dd/MM/yyyy");
                    return true;
                }
                else
                    return false;
        }

        public bool CheckGiaiQuyetDonTXLbyUser(int MaU, decimal MaDonTXL)
        {
            if (db.CTKTXMs.Any(itemCTKTXM => itemCTKTXM.KTXM.MaDonTXL == MaDonTXL && itemCTKTXM.CreateBy == MaU))
                return true;
            else
                return db.CTBamChis.Any(itemCTBamChi => itemCTBamChi.BamChi.MaDonTXL == MaDonTXL && itemCTBamChi.CreateBy == MaU);
        }

        public bool CheckGiaiQuyetDonKHbyUser(int MaU, decimal MaDon, out string NgayGiaiQuyet)
        {
            NgayGiaiQuyet = "";
            if (db.CTKTXMs.Any(itemCTKTXM => itemCTKTXM.KTXM.MaDon == MaDon && itemCTKTXM.CreateBy == MaU))
            {
                NgayGiaiQuyet = db.CTKTXMs.FirstOrDefault(itemCTKTXM => itemCTKTXM.KTXM.MaDon == MaDon && itemCTKTXM.CreateBy == MaU).NgayKTXM.Value.ToString("dd/MM/yyyy");
                return true;
            }
            else
                if (db.CTBamChis.Any(itemCTBamChi => itemCTBamChi.BamChi.MaDon == MaDon && itemCTBamChi.CreateBy == MaU))
                {
                    NgayGiaiQuyet = db.CTBamChis.FirstOrDefault(itemCTBamChi => itemCTBamChi.BamChi.MaDon == MaDon && itemCTBamChi.CreateBy == MaU).NgayBC.Value.ToString("dd/MM/yyyy");
                    return true;
                }
                else
                    return false;
        }

        public bool CheckGiaiQuyetDonKHbyUser(int MaU, decimal MaDon)
        {
            if (db.CTKTXMs.Any(itemCTKTXM => itemCTKTXM.KTXM.MaDon == MaDon && itemCTKTXM.CreateBy == MaU))
                return true;
            else
                return db.CTBamChis.Any(itemCTBamChi => itemCTBamChi.BamChi.MaDon == MaDon && itemCTBamChi.CreateBy == MaU);
        }

        

        public string GetNVKiemTraDonKHbyMaDon(decimal MaDon)
        {
            string str = "";
            DataTable dt = new DataTable();

            var query = from itemLSCKT in db.LichSuChuyenKTs
                        join itemUser in db.Users on itemLSCKT.NguoiDi equals itemUser.MaU
                        where itemLSCKT.MaDon == MaDon
                        select new
                        {
                            itemLSCKT.CreateDate,
                            itemUser.HoTen,
                        };
            dt = LINQToDataTable(query);

            var queryVP = from itemLSCVP in db.LichSuChuyenVanPhongs
                          join itemUser in db.Users on itemLSCVP.NguoiDi equals itemUser.MaU
                          where itemLSCVP.MaDon == MaDon
                        select new
                        {
                            itemLSCVP.CreateDate,
                            itemUser.HoTen,
                        };
            dt.Merge(LINQToDataTable(queryVP));

            if (dt.Rows.Count > 0)
                dt.DefaultView.Sort = "CreateDate asc";

            foreach (DataRow item in dt.Rows)
            {
                str += item["HoTen"] + ", ";
            }

            return str;
        }

        #endregion
    }
}

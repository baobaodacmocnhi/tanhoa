using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;
using System.Data;

namespace KTKS_DonKH.DAL.ToKhachHang
{
    class CDonKH : CDAL
    {
        public bool Them(DonKH entity)
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
                    entity.MaDon = getMaxNextIDTable(MaDon);
                }
                else
                    entity.MaDon = decimal.Parse("1" + DateTime.Now.ToString("yy"));

                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.DonKHs.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(DonKH donkh)
        {
            try
            {
                donkh.ModifyDate = DateTime.Now;
                donkh.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(DonKH donkh)
        {
            try
            {
                db.DonKHs.DeleteOnSubmit(donkh);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(decimal MaDon)
        {
            return db.DonKHs.Any(item => item.MaDon == MaDon);
        }

        public bool CheckExist(string DanhBo,DateTime CreateDate)
        {
            return db.DonKHs.Any(item => item.DanhBo == DanhBo&&item.CreateDate.Value.Date==CreateDate.Date);
        }

        public bool checkKhongLienHe(string DanhBo)
        {
            return db.DonKHs.Any(item => item.DanhBo == DanhBo && item.KhongLienHe == true);
        }

        public DonKH Get(decimal MaDon)
        {
                return db.DonKHs.SingleOrDefault(item => item.MaDon == MaDon);
        }

        public DataTable GetDS(decimal MaDon)
        {
            var query = from itemDonKH in db.DonKHs
                        join itemUser in db.Users on itemDonKH.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                        from tmpUser in tmpUsers.DefaultIfEmpty()
                        where itemDonKH.MaDon==MaDon
                        select new
                        {
                            itemDonKH.MaDon,
                            itemDonKH.LoaiDon.TenLD,
                            itemDonKH.SoCongVan,
                            itemDonKH.CreateDate,
                            itemDonKH.DanhBo,
                            itemDonKH.HoTen,
                            itemDonKH.DiaChi,
                            itemDonKH.NoiDung,
                            NguoiDi_KTXM = tmpUser.HoTen,
                            GiaiQuyet = db.KTXM_ChiTiets.Any(item => item.KTXM.MaDon == itemDonKH.MaDon && item.CreateBy == itemDonKH.NguoiDi_KTXM) == true
                            ? true : db.BamChi_ChiTiets.Any(item => item.BamChi.MaDon == itemDonKH.MaDon && item.CreateBy == itemDonKH.NguoiDi_KTXM) == true
                            ? true : db.DCBDs.Any(item => item.MaDon == itemDonKH.MaDon)
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(decimal FromMaDon, decimal ToMaDon)
        {
            var query = from itemDonKH in db.DonKHs
                        join itemUser in db.Users on itemDonKH.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                        from tmpUser in tmpUsers.DefaultIfEmpty()
                        where (((itemDonKH.MaDon.ToString().Substring(itemDonKH.MaDon.ToString().Length - 2, 2) == FromMaDon.ToString().Substring(FromMaDon.ToString().Length - 2, 2)
                            && itemDonKH.MaDon.ToString().Substring(itemDonKH.MaDon.ToString().Length - 2, 2) == ToMaDon.ToString().Substring(ToMaDon.ToString().Length - 2, 2))
                            && (itemDonKH.MaDon >= FromMaDon && itemDonKH.MaDon <= ToMaDon)))
                            orderby itemDonKH.CreateDate descending
                        select new
                        {
                            itemDonKH.MaDon,
                            itemDonKH.LoaiDon.TenLD,
                            itemDonKH.SoCongVan,
                            itemDonKH.CreateDate,
                            itemDonKH.DanhBo,
                            itemDonKH.HoTen,
                            itemDonKH.DiaChi,
                            itemDonKH.NoiDung,
                            NguoiDi_KTXM = tmpUser.HoTen,
                            GiaiQuyet = db.KTXM_ChiTiets.Any(item => item.KTXM.MaDon == itemDonKH.MaDon && item.CreateBy == itemDonKH.NguoiDi_KTXM) == true
                            ? true : db.BamChi_ChiTiets.Any(item => item.BamChi.MaDon == itemDonKH.MaDon && item.CreateBy == itemDonKH.NguoiDi_KTXM) == true
                            ? true : db.DCBDs.Any(item => item.MaDon == itemDonKH.MaDon)
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSByDanhBo(string DanhBo)
        {
            var query = from itemDonKH in db.DonKHs
                        join itemUser in db.Users on itemDonKH.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                        from tmpUser in tmpUsers.DefaultIfEmpty()
                        where itemDonKH.DanhBo==DanhBo
                        orderby itemDonKH.CreateDate descending
                        select new
                        {
                            itemDonKH.MaDon,
                            itemDonKH.LoaiDon.TenLD,
                            itemDonKH.SoCongVan,
                            itemDonKH.CreateDate,
                            itemDonKH.DanhBo,
                            itemDonKH.HoTen,
                            itemDonKH.DiaChi,
                            itemDonKH.NoiDung,
                            NguoiDi_KTXM = tmpUser.HoTen,
                            GiaiQuyet = db.KTXM_ChiTiets.Any(item => item.KTXM.MaDon == itemDonKH.MaDon && item.CreateBy == itemDonKH.NguoiDi_KTXM) == true
                            ? true : db.BamChi_ChiTiets.Any(item => item.BamChi.MaDon == itemDonKH.MaDon && item.CreateBy == itemDonKH.NguoiDi_KTXM) == true
                            ? true : db.DCBDs.Any(item => item.MaDon == itemDonKH.MaDon)
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSBySoCongVan(string SoCongVan)
        {
            var query = from itemDonKH in db.DonKHs
                        join itemUser in db.Users on itemDonKH.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                        from tmpUser in tmpUsers.DefaultIfEmpty()
                        where itemDonKH.SoCongVan.Contains(SoCongVan)
                        orderby itemDonKH.CreateDate descending
                        select new
                        {
                            itemDonKH.MaDon,
                            itemDonKH.LoaiDon.TenLD,
                            itemDonKH.SoCongVan,
                            itemDonKH.CreateDate,
                            itemDonKH.DanhBo,
                            itemDonKH.HoTen,
                            itemDonKH.DiaChi,
                            itemDonKH.NoiDung,
                            NguoiDi_KTXM = tmpUser.HoTen,
                            GiaiQuyet = db.KTXM_ChiTiets.Any(item => item.KTXM.MaDon == itemDonKH.MaDon && item.CreateBy == itemDonKH.NguoiDi_KTXM) == true
                            ? true : db.BamChi_ChiTiets.Any(item => item.BamChi.MaDon == itemDonKH.MaDon && item.CreateBy == itemDonKH.NguoiDi_KTXM) == true
                            ? true : db.DCBDs.Any(item => item.MaDon == itemDonKH.MaDon)
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from itemDonKH in db.DonKHs
                        join itemUser in db.Users on itemDonKH.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                        from tmpUser in tmpUsers.DefaultIfEmpty()
                        where itemDonKH.CreateDate.Value.Date >= FromCreateDate.Date && itemDonKH.CreateDate.Value.Date <= ToCreateDate.Date
                        orderby itemDonKH.CreateDate descending
                        select new
                        {
                            itemDonKH.MaDon,
                            itemDonKH.LoaiDon.TenLD,
                            itemDonKH.SoCongVan,
                            itemDonKH.CreateDate,
                            itemDonKH.DanhBo,
                            itemDonKH.HoTen,
                            itemDonKH.DiaChi,
                            itemDonKH.NoiDung,
                            NguoiDi_KTXM = tmpUser.HoTen,
                            GiaiQuyet = db.KTXM_ChiTiets.Any(item => item.KTXM.MaDon == itemDonKH.MaDon && item.CreateBy == itemDonKH.NguoiDi_KTXM) == true
                            ? true : db.BamChi_ChiTiets.Any(item => item.BamChi.MaDon == itemDonKH.MaDon && item.CreateBy == itemDonKH.NguoiDi_KTXM) == true
                            ? true : db.DCBDs.Any(item => item.MaDon == itemDonKH.MaDon)
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(int MaLD,DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from itemDonKH in db.DonKHs
                        join itemUser in db.Users on itemDonKH.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                        from tmpUser in tmpUsers.DefaultIfEmpty()
                        where itemDonKH.MaLD==MaLD&&itemDonKH.CreateDate.Value.Date >= FromCreateDate.Date && itemDonKH.CreateDate.Value.Date <= ToCreateDate.Date
                        orderby itemDonKH.CreateDate descending
                        select new
                        {
                            itemDonKH.MaDon,
                            itemDonKH.LoaiDon.TenLD,
                            itemDonKH.SoCongVan,
                            itemDonKH.CreateDate,
                            itemDonKH.DanhBo,
                            itemDonKH.HoTen,
                            itemDonKH.DiaChi,
                            itemDonKH.NoiDung,
                            NguoiDi_KTXM = tmpUser.HoTen,
                            GiaiQuyet = db.KTXM_ChiTiets.Any(item => item.KTXM.MaDon == itemDonKH.MaDon && item.CreateBy == itemDonKH.NguoiDi_KTXM) == true
                            ? true : db.BamChi_ChiTiets.Any(item => item.BamChi.MaDon == itemDonKH.MaDon && item.CreateBy == itemDonKH.NguoiDi_KTXM) == true
                            ? true : db.DCBDs.Any(item => item.MaDon == itemDonKH.MaDon)
                        };
            return LINQToDataTable(query);
        }

        public DataTable BaoCao_ThongKeLoaiDon(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MaDon,TenLD,"
                    + " ChuyenTrucTiep=case when exists(select ID from LichSuDonTu where LichSuDonTu.MaDon=a.MaDon and ID_NoiChuyen=1) then 'false' else 'true' end,"
                    + " ChuyenKTXM=case when exists(select ID from LichSuDonTu where LichSuDonTu.MaDon=a.MaDon and ID_NoiChuyen=1) then 'true' else 'false' end,"
                    + " DaKTXM=case when exists(select ID from LichSuDonTu where LichSuDonTu.MaDon=a.MaDon and ID_NoiChuyen=1) then case when exists(select MaKTXM from KTXM where KTXM.MaDon=a.MaDon) then 'true' else 'false' end else 'false' end"
                    + " from DonKH a,LoaiDon b where CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyy-MM-dd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyy-MM-dd") + "' and a.MaLD=b.MaLD"
                    + " order by a.CreateDate asc";

            return ExecuteQuery_DataTable(sql);
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
                db = new dbKinhDoanhDataContext();
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
                db = new dbKinhDoanhDataContext();
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
                db = new dbKinhDoanhDataContext();
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
                db = new dbKinhDoanhDataContext();
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
                db = new dbKinhDoanhDataContext();
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
                db = new dbKinhDoanhDataContext();
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
                db = new dbKinhDoanhDataContext();
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
                db = new dbKinhDoanhDataContext();
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
                db = new dbKinhDoanhDataContext();
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

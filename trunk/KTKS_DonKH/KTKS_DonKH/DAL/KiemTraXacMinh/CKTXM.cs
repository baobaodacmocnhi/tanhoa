using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;
using KTKS_DonKH.DAL.HeThong;
using System.Data;

namespace KTKS_DonKH.DAL.KiemTraXacMinh
{
    class CKTXM : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng DCBD & CTDCBD & CTDCHD

        #region KTXM (Kiểm Tra Xác Minh)

        public bool ThemKTXM(KTXM ktxm)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM)
                {
                    if (db.KTXMs.Count() > 0)
                    {
                        decimal MaKTXM = db.KTXMs.Max(itemKTXM => itemKTXM.MaKTXM);
                        ktxm.MaKTXM = getMaxNextIDTable(MaKTXM);
                    }
                    else
                        ktxm.MaKTXM = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    ktxm.CreateDate = DateTime.Now;
                    ktxm.CreateBy = CTaiKhoan.TaiKhoan;
                    db.KTXMs.InsertOnSubmit(ktxm);
                    db.SubmitChanges();
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

        public bool SuaKTXM(KTXM ktxm)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM)
                {
                    ktxm.ModifyDate = DateTime.Now;
                    ktxm.ModifyBy = CTaiKhoan.TaiKhoan;
                    db.SubmitChanges();
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
        /// Hàm này được dùng trong nội bộ DAL
        /// </summary>
        /// <param name="ktxm"></param>
        /// <param name="inhertance">true</param>
        /// <returns></returns>
        public bool ThemKTXM(KTXM ktxm, bool inhertance)
        {
            try
            {
                if (inhertance)
                {
                    if (db.KTXMs.Count() > 0)
                    {
                        decimal MaKTXM = db.KTXMs.Max(itemKTXM => itemKTXM.MaKTXM);
                        ktxm.MaKTXM = getMaxNextIDTable(MaKTXM);
                    }
                    else
                        ktxm.MaKTXM = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    ktxm.CreateDate = DateTime.Now;
                    ktxm.CreateBy = CTaiKhoan.TaiKhoan;
                    db.KTXMs.InsertOnSubmit(ktxm);
                    db.SubmitChanges();
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
        /// Hàm này được dùng trong nội bộ DAL
        /// </summary>
        /// <param name="ktxm"></param>
        /// <param name="inhertance">true</param>
        /// <returns></returns>
        public bool SuaKTXM(KTXM ktxm, bool inhertance)
        {
            try
            {
                if (inhertance)
                {
                    ktxm.ModifyDate = DateTime.Now;
                    ktxm.ModifyBy = CTaiKhoan.TaiKhoan;
                    db.SubmitChanges();
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

        public DataTable LoadDSKTXMDaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM)
                {
                    var query = from itemKTXM in db.KTXMs
                                join itemDonKH in db.DonKHs on itemKTXM.MaKTXM equals itemDonKH.MaDon
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
                                    MaNoiChuyenDen = itemKTXM.MaNoiChuyenDen,
                                    NoiChuyenDen = itemKTXM.NoiChuyenDen,
                                    LyDoChuyenDen = itemKTXM.LyDoChuyenDen,
                                    itemKTXM.MaKTXM,
                                    NgayXuLy = itemKTXM.CreateDate,
                                    itemKTXM.KetQua,
                                    itemKTXM.MaChuyen,
                                    LyDoChuyenDi = itemKTXM.LyDoChuyen
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

        public DataTable LoadDSKTXMChuaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM)
                {
                    ///Bảng DonKH
                    var queryDonKH = from itemDonKH in db.DonKHs
                                     join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                     where itemDonKH.Nhan == false && itemDonKH.MaChuyen == "KTXM"
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
                                         MaKTXM = "",
                                         NgayXuLy = "",
                                         KetQua = "",
                                         MaChuyen = "",
                                         LyDoChuyenDi = ""
                                     };
                    ///Bảng DCBD
                    var queryDCBD = from itemDCBD in db.DCBDs
                                    join itemDonKH in db.DonKHs on itemDCBD.MaDCBD equals itemDonKH.MaDon
                                    join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                    where itemDCBD.Nhan == false && itemDCBD.MaChuyen == "KTXM"
                                    select new
                                    {
                                        itemDonKH.MaDon,
                                        itemLoaiDon.TenLD,
                                        itemDonKH.CreateDate,
                                        itemDonKH.DanhBo,
                                        itemDonKH.HoTen,
                                        itemDonKH.DiaChi,
                                        itemDonKH.NoiDung,
                                        MaNoiChuyenDen = itemDCBD.MaDCBD,
                                        NoiChuyenDen = "Điều Chỉnh Biến Động",
                                        LyDoChuyenDen = itemDCBD.LyDoChuyen,
                                        MaKTXM = "",
                                        NgayXuLy = "",
                                        KetQua = "",
                                        MaChuyen = "",
                                        LyDoChuyenDi = ""
                                    };
                    //if (queryDCBD.Count() > 0)
                    //    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonKH.Union(queryDCBD));
                    //else
                    //    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonKH);
                    DataTable tableDonKH = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonKH);
                    DataTable tableDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDCBD);
                    tableDonKH.Merge(tableDCBD);
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

        public KTXM getKTXMbyID(decimal MaKTXM)
        {
            try
            {
                return db.KTXMs.SingleOrDefault(itemKTXM => itemKTXM.MaKTXM == MaKTXM);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Kiểm tra Đơn KH có được chuyển qua cho KTXM xử lý hay chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns>true/có</returns>
        public bool CheckKTMXbyIDMaDon(decimal MaDon)
        {
            try
            {
                if (db.KTXMs.Any(itemKTXM => itemKTXM.MaDon == MaDon))
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
        /// Lấy KTXM bằng MaDon
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns></returns>
        public KTXM getKTXMbyIDMaDon(decimal MaDon)
        {
            try
            {
                return db.KTXMs.SingleOrDefault(itemKTXM => itemKTXM.MaDon == MaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy thông tin Đơn KH
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="MaNoiChuyenDen"></param>
        /// <param name="NoiChuyenDen"></param>
        /// <param name="LyDoChuyenDen"></param>
        public void GetInfobyMaDon(decimal MaDon, out string MaNoiChuyenDen, out string NoiChuyenDen, out string LyDoChuyenDen)
        {
            MaNoiChuyenDen = "";
            NoiChuyenDen = "";
            LyDoChuyenDen = "";
            if (db.DonKHs.Any(itemDonKH => itemDonKH.MaDon == MaDon && itemDonKH.Nhan == false))
            {
                MaNoiChuyenDen = db.DonKHs.SingleOrDefault(itemDonKH => itemDonKH.MaDon == MaDon && itemDonKH.Nhan == false).MaDon.ToString();
                NoiChuyenDen = "Khách Hàng";
                LyDoChuyenDen = db.DonKHs.SingleOrDefault(itemDonKH => itemDonKH.MaDon == MaDon && itemDonKH.Nhan == false).LyDoChuyen;
            }
        }

        #endregion

        #region CTKTXM (Chi Tiết Kiểm Tra Xác Minh)

        public DataTable LoadDSCTKTXM(decimal MaDon)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM || CTaiKhoan.RoleKTXM)
                {
                    var query = from itemCTKTXM in db.CTKTXMs
                                where itemCTKTXM.KTXM.MaDon == MaDon
                                select new
                                {
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.NoiDungKiemTra,
                                    NguoiDi = itemCTKTXM.CreateBy,
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

        public bool ThemCTKTXM(CTKTXM ctktxm)
        {
            try
            {
                if (CTaiKhoan.RoleKTXM)
                {
                    if (db.CTKTXMs.Count() > 0)
                    {
                        decimal MaCTKTXM = db.CTKTXMs.Max(itemCTKTXM => itemCTKTXM.MaCTKTXM);
                        ctktxm.MaCTKTXM = getMaxNextIDTable(MaCTKTXM);
                    }
                    else
                        ctktxm.MaCTKTXM = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    ctktxm.CreateDate = DateTime.Now;
                    ctktxm.CreateBy = CTaiKhoan.TaiKhoan;
                    db.CTKTXMs.InsertOnSubmit(ctktxm);
                    db.SubmitChanges();
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

        public bool SuaCTKTXM(CTKTXM ctktxm)
        {
            try
            {
                if (CTaiKhoan.RoleKTXM)
                {
                    ctktxm.ModifyDate = DateTime.Now;
                    ctktxm.ModifyBy = CTaiKhoan.TaiKhoan;
                    db.SubmitChanges();
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

        public CTKTXM getCTKTXMbyID(decimal MaCTKTXM)
        {
            try
            {
                return db.CTKTXMs.SingleOrDefault(itemCTKTXM => itemCTKTXM.MaCTKTXM == MaCTKTXM);
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

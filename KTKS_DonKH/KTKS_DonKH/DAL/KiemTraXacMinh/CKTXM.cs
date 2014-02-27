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
                if (CTaiKhoan.RoleQLKTXM || CTaiKhoan.RoleKTXM)
                {
                    if (db.KTXMs.Count() > 0)
                    {
                        decimal MaKTXM = db.KTXMs.Max(itemKTXM => itemKTXM.MaKTXM);
                        ktxm.MaKTXM = getMaxNextIDTable(MaKTXM);
                    }
                    else
                        ktxm.MaKTXM = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    ktxm.CreateDate = DateTime.Now;
                    ktxm.CreateBy = CTaiKhoan.MaUser;
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
                if (CTaiKhoan.RoleQLKTXM || CTaiKhoan.RoleKTXM)
                {
                    ktxm.ModifyDate = DateTime.Now;
                    ktxm.ModifyBy = CTaiKhoan.MaUser;
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
                    ktxm.CreateBy = CTaiKhoan.MaUser;
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
                    ktxm.ModifyBy = CTaiKhoan.MaUser;
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

        public DataTable LoadDSKTXMDaDuyet_Old()
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

        public DataSet LoadDSKTXMDaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM)
                {
                    DataSet ds = new DataSet();
                    ///Table KTXM
                    var queryKTXM = from itemKTXM in db.KTXMs
                                join itemDonKH in db.DonKHs on itemKTXM.MaDon equals itemDonKH.MaDon
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                orderby itemDonKH.MaDon ascending
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
                    DataTable dtKTXM = new DataTable();
                    dtKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM);
                    dtKTXM.TableName = "KTXM";
                    ds.Tables.Add(dtKTXM);

                    ///Table CTKTXM
                    var queryCTKTXM = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      select new
                                      {
                                          itemCTKTXM.MaKTXM,
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.CreateDate,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.NoiDungKiemTra,
                                          CreateBy = itemUser.HoTen,
                                      };

                    DataTable dtCTKTXM = new DataTable();
                    dtCTKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTKTXM);
                    dtCTKTXM.TableName = "CTKTXM";
                    ds.Tables.Add(dtCTKTXM);

                    if (dtKTXM.Rows.Count > 0 && dtCTKTXM.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["KTXM"].Columns["MaKTXM"], ds.Tables["CTKTXM"].Columns["MaKTXM"]);
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
                                     orderby itemDonKH.MaDon ascending
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
        /// Kiểm tra Đơn KH có được KTXM xử lý hay chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns>true/có</returns>
        public bool CheckKTMXbyMaDon(decimal MaDon)
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
        public KTXM getKTXMbyMaDon(decimal MaDon)
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

        public DataTable LoadDSCTKTXM()
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM || CTaiKhoan.RoleKTXM)
                {
                    var query = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                orderby itemCTKTXM.KTXM.MaDon ascending
                                select new
                                {
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NoiDungKiemTra,
                                    itemCTKTXM.CreateDate,
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

        public DataTable LoadDSCTKTXM(decimal MaDon)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM || CTaiKhoan.RoleKTXM)
                {
                    var query = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.MaDon == MaDon
                                orderby itemCTKTXM.KTXM.MaDon ascending
                                select new
                                {
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NoiDungKiemTra,
                                    itemCTKTXM.CreateDate,
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
        /// Lấy Danh Sách CTKTXM theo User
        /// </summary>
        /// <param name="MaUser"></param>
        /// <returns></returns>
        public DataTable LoadDSCTKTXM(int MaUser)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM || CTaiKhoan.RoleKTXM)
                {
                    var query = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.CreateBy == MaUser
                                orderby itemCTKTXM.KTXM.MaDon ascending
                                select new
                                {
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NoiDungKiemTra,
                                    itemCTKTXM.CreateDate,
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
        /// Lấy Danh Sách CTKTXM theo Mã Đơn & User
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="MaUser"></param>
        /// <returns></returns>
        public DataTable LoadDSCTKTXM(decimal MaDon, int MaUser)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM || CTaiKhoan.RoleKTXM)
                {
                    var query = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.MaDon == MaDon && itemCTKTXM.CreateBy == MaUser
                                orderby itemCTKTXM.KTXM.MaDon ascending
                                select new
                                {
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NoiDungKiemTra,
                                    itemCTKTXM.CreateDate,
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

        public bool ThemCTKTXM(CTKTXM ctktxm)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM || CTaiKhoan.RoleKTXM)
                {
                    if (db.CTKTXMs.Count() > 0)
                    {
                        decimal MaCTKTXM = db.CTKTXMs.Max(itemCTKTXM => itemCTKTXM.MaCTKTXM);
                        ctktxm.MaCTKTXM = getMaxNextIDTable(MaCTKTXM);
                    }
                    else
                        ctktxm.MaCTKTXM = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    ctktxm.CreateDate = DateTime.Now;
                    ctktxm.CreateBy = CTaiKhoan.MaUser;
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
                if (CTaiKhoan.RoleQLKTXM || CTaiKhoan.RoleKTXM)
                {
                    ctktxm.ModifyDate = DateTime.Now;
                    ctktxm.ModifyBy = CTaiKhoan.MaUser;
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

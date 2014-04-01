using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.BamChi
{
    class CBamChi : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng BamChi & CTBamChi

        #region BamChi (Bấm Chì)

        public bool ThemBamChi(LinQ.BamChi bamchi)
        {
            try
            {
                if (CTaiKhoan.RoleQLBamChi_CapNhat || CTaiKhoan.RoleBamChi_CapNhat)
                {
                    if (db.BamChis.Count() > 0)
                    {
                        decimal MaBC = db.BamChis.Max(itemBamChi => itemBamChi.MaBC);
                        bamchi.MaBC = getMaxNextIDTable(MaBC);
                    }
                    else
                        bamchi.MaBC = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    bamchi.CreateDate = DateTime.Now;
                    bamchi.CreateBy = CTaiKhoan.MaUser;
                    db.BamChis.InsertOnSubmit(bamchi);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.BamChis);
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

        public bool SuaBamChi(LinQ.BamChi bamchi)
        {
            try
            {
                if (CTaiKhoan.RoleQLBamChi_CapNhat || CTaiKhoan.RoleBamChi_CapNhat)
                {
                    bamchi.ModifyDate = DateTime.Now;
                    bamchi.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa BamChi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.BamChis);
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

        public LinQ.BamChi getBamChibyID(decimal MaBC)
        {
            try
            {
                return db.BamChis.SingleOrDefault(itemBamChi => itemBamChi.MaBC == MaBC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Kiểm tra Đơn KH có được BamChi xử lý hay chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns>true/có</returns>
        public bool CheckBamChibyMaDon(decimal MaDon)
        {
            try
            {
                if (db.BamChis.Any(itemBamChi => itemBamChi.MaDon == MaDon))
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
        /// Kiểm tra Đơn Tổ Xử Lý có được BamChi xử lý hay chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns>true/có</returns>
        public bool CheckBamChibyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                if (db.BamChis.Any(itemBamChi => itemBamChi.MaDonTXL == MaDonTXL))
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
        /// Lấy BamChi bằng MaDon
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns></returns>
        public LinQ.BamChi getBamChibyMaDon(decimal MaDon)
        {
            try
            {
                return db.BamChis.SingleOrDefault(itemBamChi => itemBamChi.MaDon == MaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy BamChi bằng MaDon Tổ Xử Lý
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns></returns>
        public LinQ.BamChi getBamChibyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                return db.BamChis.SingleOrDefault(itemBamChi => itemBamChi.MaDonTXL == MaDonTXL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion

        #region CTBamChi (Chi Tiết Bấm Chì)

        public bool ThemCTBamChi(CTBamChi ctbamchi)
        {
            try
            {
                if (CTaiKhoan.RoleQLBamChi_CapNhat || CTaiKhoan.RoleBamChi_CapNhat)
                {
                    if (db.CTBamChis.Count() > 0)
                    {
                        decimal MaCTBC = db.CTBamChis.Max(itemCTBamChi => itemCTBamChi.MaCTBC);
                        ctbamchi.MaCTBC = getMaxNextIDTable(MaCTBC);
                    }
                    else
                        ctbamchi.MaCTBC = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    ctbamchi.CreateDate = DateTime.Now;
                    ctbamchi.CreateBy = CTaiKhoan.MaUser;
                    db.CTBamChis.InsertOnSubmit(ctbamchi);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTBamChis);
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

        public bool SuaCTBamChi(CTBamChi ctbamchi)
        {
            try
            {
                if (CTaiKhoan.RoleQLBamChi_CapNhat)
                {
                    ctbamchi.ModifyDate = DateTime.Now;
                    ctbamchi.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    return true;
                }
                else
                    if (CTaiKhoan.RoleBamChi_CapNhat && ctbamchi.CreateBy == CTaiKhoan.MaUser)
                    {
                        ctbamchi.ModifyDate = DateTime.Now;
                        ctbamchi.ModifyBy = CTaiKhoan.MaUser;
                        db.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản này không có quyền hoặc CTBamChi này không thuộc của bạn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTBamChis);
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

        public bool XoaCTBamChi(CTBamChi ctbamchi)
        {
            try
            {
                if (CTaiKhoan.RoleQLBamChi_CapNhat)
                {
                    db.CTBamChis.DeleteOnSubmit(ctbamchi);
                    db.SubmitChanges();
                    return true;
                }
                else
                    if (CTaiKhoan.RoleBamChi_CapNhat && ctbamchi.CreateBy == CTaiKhoan.MaUser)
                    {
                        db.CTBamChis.DeleteOnSubmit(ctbamchi);
                        db.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản này không có quyền hoặc CTBamChi này không thuộc của bạn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTBamChis);
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

        public CTBamChi getCTBamChibyID(decimal MaCTBC)
        {
            try
            {
                return db.CTBamChis.SingleOrDefault(itemCTBamChi => itemCTBamChi.MaCTBC == MaCTBC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách CTBamChi theo Mã Đơn Khách Hàng & User
        /// Nếu User có quyền quản lý BamChi thì được xem hết CTBamChi của Mã Đơn
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="MaUser"></param>
        /// <returns></returns>
        public DataTable LoadDSCTBamChi(decimal MaDon, int MaUser)
        {
            try
            {
                if (CTaiKhoan.RoleQLBamChi_Xem || CTaiKhoan.RoleQLBamChi_CapNhat)
                {
                    var query = from itemCTBamChi in db.CTBamChis
                                join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                where itemCTBamChi.BamChi.MaDon == MaDon
                                orderby itemCTBamChi.BamChi.MaDon ascending
                                select new
                                {
                                    itemCTBamChi.MaBC,
                                    itemCTBamChi.BamChi.MaDon,
                                    itemCTBamChi.DanhBo,
                                    itemCTBamChi.HoTen,
                                    itemCTBamChi.DiaChi,
                                    itemCTBamChi.CreateDate,
                                    CreateBy = itemUser.HoTen,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                    if (CTaiKhoan.RoleBamChi_Xem || CTaiKhoan.RoleBamChi_CapNhat)
                    {
                        var query = from itemCTBamChi in db.CTBamChis
                                    join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                    where itemCTBamChi.BamChi.MaDon == MaDon && itemCTBamChi.CreateBy == MaUser
                                    orderby itemCTBamChi.BamChi.MaDon ascending
                                    select new
                                    {
                                        itemCTBamChi.MaBC,
                                        itemCTBamChi.BamChi.MaDon,
                                        itemCTBamChi.DanhBo,
                                        itemCTBamChi.HoTen,
                                        itemCTBamChi.DiaChi,
                                        itemCTBamChi.CreateDate,
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
        /// Lấy Danh Sách CTBamChi theo Mã Đơn Khách Hàng & User
        /// Nếu User có quyền quản lý BamChi thì được xem hết CTBamChi của Mã Đơn
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <param name="MaUser"></param>
        /// <returns></returns>
        public DataTable LoadDSCTBamChi_TXL(decimal MaDonTXL, int MaUser)
        {
            try
            {
                if (CTaiKhoan.RoleQLBamChi_Xem || CTaiKhoan.RoleQLBamChi_CapNhat)
                {
                    var query = from itemCTBamChi in db.CTBamChis
                                join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                where itemCTBamChi.BamChi.MaDonTXL == MaDonTXL
                                orderby itemCTBamChi.BamChi.MaDonTXL ascending
                                select new
                                {
                                    itemCTBamChi.MaBC,
                                    itemCTBamChi.BamChi.MaDonTXL,
                                    itemCTBamChi.DanhBo,
                                    itemCTBamChi.HoTen,
                                    itemCTBamChi.DiaChi,
                                    itemCTBamChi.CreateDate,
                                    CreateBy = itemUser.HoTen,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                    if (CTaiKhoan.RoleBamChi_Xem || CTaiKhoan.RoleBamChi_CapNhat)
                    {
                        var query = from itemCTBamChi in db.CTBamChis
                                    join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                    where itemCTBamChi.BamChi.MaDonTXL == MaDonTXL && itemCTBamChi.CreateBy == MaUser
                                    orderby itemCTBamChi.BamChi.MaDonTXL ascending
                                    select new
                                    {
                                        itemCTBamChi.MaBC,
                                        MaDon=itemCTBamChi.BamChi.MaDonTXL,
                                        itemCTBamChi.DanhBo,
                                        itemCTBamChi.HoTen,
                                        itemCTBamChi.DiaChi,
                                        itemCTBamChi.CreateDate,
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
        /// Kiểm tra CTBamChi đã được tạo cho Mã Đơn Tổ Khách Hàng, Danh Bộ
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTBamChibyMaDonDanhBo(decimal MaDon, string DanhBo)
        {
            try
            {
                return db.CTBamChis.Any(itemCTBamChi => itemCTBamChi.BamChi.MaDon == MaDon && itemCTBamChi.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra CTBamChi đã được tạo cho Mã Đơn Tổ Xử Lý, Danh Bộ
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTBamChibyMaDonDanhBo_TXL(decimal MaDonTXL, string DanhBo)
        {
            try
            {
                return db.CTBamChis.Any(itemCTBamChi => itemCTBamChi.BamChi.MaDonTXL == MaDonTXL && itemCTBamChi.DanhBo == DanhBo);
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

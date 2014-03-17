using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;
using System.Data;

namespace KTKS_DonKH.DAL.ToXuLy
{
    class CDonTXL : CDAL
    {
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
                    decimal MaDon = db.DonTXLs.Max(itemDonTXL => itemDonTXL.MaDon);
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
                if (CTaiKhoan.RoleQLKTXM_CapNhat || CTaiKhoan.RoleKTXM_CapNhat)
                {
                    dontxl.CreateDate = DateTime.Now;
                    dontxl.CreateBy = CTaiKhoan.MaUser;
                    db.DonTXLs.InsertOnSubmit(dontxl);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm DonKH", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public DataTable LoadDSAllDonTXL()
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_CapNhat || CTaiKhoan.RoleKTXM_CapNhat)
                {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                orderby itemDonTXL.MaDon ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
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

        public DataTable LoadDSDonTXLChuaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_CapNhat || CTaiKhoan.RoleKTXM_CapNhat)
                {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                where itemDonTXL.Nhan == false
                                orderby itemDonTXL.MaDon ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
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

        public DataTable LoadDSDonTXLDaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_CapNhat || CTaiKhoan.RoleKTXM_CapNhat)
                {
                    var query = from itemDonTXL in db.DonTXLs
                                join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                where itemDonTXL.Nhan == true
                                orderby itemDonTXL.MaDon ascending
                                select new
                                {
                                    itemDonTXL.MaDon,
                                    itemLoaiDonTXL.TenLD,
                                    itemDonTXL.CreateDate,
                                    itemDonTXL.DanhBo,
                                    itemDonTXL.HoTen,
                                    itemDonTXL.DiaChi,
                                    itemDonTXL.NoiDung,
                                    itemDonTXL.MaChuyen,
                                    itemDonTXL.LyDoChuyen,
                                    itemDonTXL.SoLuongDiaChi,
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

        public bool SuaDonTXL(DonTXL dontxl)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_CapNhat || CTaiKhoan.RoleKTXM_CapNhat)
                {
                    dontxl.ModifyDate = DateTime.Now;
                    dontxl.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa DonKH", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public bool SuaDonTXL(DonTXL dontxl, bool inhertance)
        {
            try
            {
                if (inhertance)
                {
                    dontxl.ModifyDate = DateTime.Now;
                    dontxl.ModifyBy = CTaiKhoan.MaUser;
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

        public bool XoaDonTXL(DonTXL dontxl)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_CapNhat || CTaiKhoan.RoleKTXM_CapNhat)
                {
                    db.DonTXLs.DeleteOnSubmit(dontxl);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Xóa DonKH", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}

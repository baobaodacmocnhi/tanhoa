using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;
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
                    decimal MaDon = db.DonKHs.Max(itemDonKH => itemDonKH.MaDon);
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

        /// <summary>
        /// Lấy Đơn Khách Hàng kèm theo điều kiện Đơn được chuyến đến đúng Bộ Phận xử lý
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="MaChuyen"></param>
        /// <returns></returns>
        public DonKH getDonKHbyID(decimal MaDon, string MaChuyen)
        {
            try
            {
                return db.DonKHs.SingleOrDefault(itemDonKH => itemDonKH.MaDon == MaDon && itemDonKH.MaChuyen == MaChuyen);
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
                if (CTaiKhoan.RoleNhanDonKH_CapNhat)
                {
                    donkh.CreateDate = DateTime.Now;
                    donkh.CreateBy = CTaiKhoan.MaUser;
                    db.DonKHs.InsertOnSubmit(donkh);
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

        public DataTable LoadDSAllDonKH()
        {
            try
            {
                if (CTaiKhoan.RoleQLDonKH_Xem||CTaiKhoan.RoleQLDonKH_CapNhat)
                {
                    var query = from itemDonKH in db.DonKHs
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                orderby itemDonKH.MaLD, itemDonKH.MaDon ascending
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
                                    itemDonKH.MaChuyen,
                                    itemDonKH.LyDoChuyen,
                                    itemDonKH.SoLuongDiaChi,
                                    itemDonKH.NVKiemTra,
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

        public DataTable LoadDSDonKHChuaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleQLDonKH_Xem || CTaiKhoan.RoleQLDonKH_CapNhat)
                {
                    var query = from itemDonKH in db.DonKHs
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                where itemDonKH.Nhan == false
                                orderby itemDonKH.MaLD, itemDonKH.MaDon ascending
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
                                    itemDonKH.MaChuyen,
                                    itemDonKH.LyDoChuyen,
                                    itemDonKH.SoLuongDiaChi,
                                    itemDonKH.NVKiemTra,
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

        public DataTable LoadDSDonKHDaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleQLDonKH_Xem || CTaiKhoan.RoleQLDonKH_CapNhat)
                {
                    var query = from itemDonKH in db.DonKHs
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                where itemDonKH.Nhan == true
                                orderby itemDonKH.MaLD, itemDonKH.MaDon ascending
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
                                    itemDonKH.MaChuyen,
                                    itemDonKH.LyDoChuyen,
                                    itemDonKH.SoLuongDiaChi,
                                    itemDonKH.NVKiemTra,
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

        public DataTable LoadDSDonKH(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleQLDonKH_Xem || CTaiKhoan.RoleQLDonKH_CapNhat)
                {
                    var query = from itemDonKH in db.DonKHs
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                where itemDonKH.CreateDate.Value.Date==TuNgay.Date
                                orderby itemDonKH.MaLD, itemDonKH.MaDon ascending
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
                                    itemDonKH.MaChuyen,
                                    itemDonKH.LyDoChuyen,
                                    itemDonKH.SoLuongDiaChi,
                                    itemDonKH.NVKiemTra,
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

        public DataTable LoadDSDonKH(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleQLDonKH_Xem || CTaiKhoan.RoleQLDonKH_CapNhat)
                {
                    var query = from itemDonKH in db.DonKHs
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                where itemDonKH.CreateDate.Value.Date >= TuNgay.Date && itemDonKH.CreateDate.Value.Date <= DenNgay.Date
                                orderby itemDonKH.MaLD, itemDonKH.MaDon ascending
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
                                    itemDonKH.MaChuyen,
                                    itemDonKH.LyDoChuyen,
                                    itemDonKH.SoLuongDiaChi,
                                    itemDonKH.NVKiemTra,
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

        public bool SuaDonKH(DonKH donkh)
        {
            try
            {
                if (CTaiKhoan.RoleQLDonKH_CapNhat)
                {
                    donkh.ModifyDate = DateTime.Now;
                    donkh.ModifyBy = CTaiKhoan.MaUser;
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
                if (CTaiKhoan.RoleQLDonKH_CapNhat)
                {
                    db.DonKHs.DeleteOnSubmit(donkh);
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

        public decimal getMaXepDonNext(int MaLD)
        {
            if (db.DonKHs.Where(itemDonKH => itemDonKH.MaLD == MaLD).Max(itemDonKH => itemDonKH.MaXepDon) != null)
            {
                decimal a = getMaxNextIDTable(db.DonKHs.Where(itemDonKH => itemDonKH.MaLD == MaLD).Max(itemDonKH => itemDonKH.MaXepDon).Value);
                return a;
            }
            else
                return decimal.Parse("1" + DateTime.Now.ToString("yy"));
        }

        /// <summary>
        /// Lấy thông tin Đơn KH
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="MaChuyen">nơi đơn được chuyến đến để xử lý</param>
        /// <param name="MaNoiChuyenDen"></param>
        /// <param name="NoiChuyenDen"></param>
        /// <param name="LyDoChuyenDen"></param>
        public void GetInfobyMaDon(decimal MaDon,string MaChuyen, out string MaNoiChuyenDen, out string NoiChuyenDen, out string LyDoChuyenDen)
        {
            MaNoiChuyenDen = "";
            NoiChuyenDen = "";
            LyDoChuyenDen = "";
            if (db.DonKHs.Any(itemDonKH => itemDonKH.MaDon == MaDon && itemDonKH.Nhan == false && itemDonKH.MaChuyen == MaChuyen))
            {
                MaNoiChuyenDen = db.DonKHs.SingleOrDefault(itemDonKH => itemDonKH.MaDon == MaDon && itemDonKH.Nhan == false && itemDonKH.MaChuyen == MaChuyen).MaDon.ToString();
                NoiChuyenDen = "Khách Hàng";
                LyDoChuyenDen = db.DonKHs.SingleOrDefault(itemDonKH => itemDonKH.MaDon == MaDon && itemDonKH.Nhan == false && itemDonKH.MaChuyen == MaChuyen).LyDoChuyen;
            }
            if (db.KTXMs.Any(itemKTXM => itemKTXM.MaDon == MaDon && itemKTXM.Nhan == false && itemKTXM.MaChuyen == MaChuyen))
            {
                MaNoiChuyenDen = db.KTXMs.SingleOrDefault(itemKTXM => itemKTXM.MaDon == MaDon && itemKTXM.Nhan == false && itemKTXM.MaChuyen == MaChuyen).MaKTXM.ToString();
                NoiChuyenDen = "Kiểm Tra Xác Minh";
                LyDoChuyenDen = db.KTXMs.SingleOrDefault(itemKTXM => itemKTXM.MaDon == MaDon && itemKTXM.Nhan == false && itemKTXM.MaChuyen == MaChuyen).LyDoChuyen;
            }
        }
    }
}

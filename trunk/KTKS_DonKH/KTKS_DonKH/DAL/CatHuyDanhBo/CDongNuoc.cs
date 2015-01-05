using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;
using System.Data;

namespace KTKS_DonKH.DAL.DongNuoc
{
    class CDongNuoc : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng DongNuoc & CTDongNuoc

        #region DongNuoc

        /// <summary>
        /// Kiểm tra Đơn Khách Hàng có được DongNuoc xử lý hay chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns>true/có</returns>
        public bool CheckDongNuocbyMaDon(decimal MaDon)
        {
            try
            {
                if (db.DongNuocs.Any(itemDongNuoc => itemDongNuoc.MaDon == MaDon))
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
        /// Kiểm tra Đơn Tổ Xử Lý có được DongNuoc xử lý hay chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns>true/có</returns>
        public bool CheckDongNuocbyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                if (db.DongNuocs.Any(itemDongNuoc => itemDongNuoc.MaDonTXL == MaDonTXL))
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

        public bool ThemDongNuoc(LinQ.DongNuoc dongnuoc)
        {
            try
            {
                if (CTaiKhoan.RoleDongNuoc_CapNhat)
                {
                    if (db.DongNuocs.Count() > 0)
                    {
                        string ID = "MaDN";
                        string Table = "DongNuoc";
                        decimal MaDN = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //decimal MaDN = db.DongNuocs.Max(itemDongNuoc => itemDongNuoc.MaDN);
                        dongnuoc.MaDN = getMaxNextIDTable(MaDN);
                    }
                    else
                        dongnuoc.MaDN = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    dongnuoc.CreateDate = DateTime.Now;
                    dongnuoc.CreateBy = CTaiKhoan.MaUser;
                    db.DongNuocs.InsertOnSubmit(dongnuoc);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm DongNuoc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.DongNuocs);
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

        public bool SuaDongNuoc(LinQ.DongNuoc dongnuoc)
        {
            try
            {
                if (CTaiKhoan.RoleDongNuoc_CapNhat)
                {

                    dongnuoc.ModifyDate = DateTime.Now;
                    dongnuoc.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa DongNuoc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.DongNuocs);
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
        /// Lấy DongNuoc bằng MaDon
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns></returns>
        public LinQ.DongNuoc getDongNuocbyMaDon(decimal MaDon)
        {
            try
            {
                return db.DongNuocs.SingleOrDefault(itemDongNuoc => itemDongNuoc.MaDon == MaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy DongNuoc bằng MaDon Tổ Xử Lý
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns></returns>
        public LinQ.DongNuoc getDongNuocbyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                return db.DongNuocs.SingleOrDefault(itemDongNuoc => itemDongNuoc.MaDonTXL == MaDonTXL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion

        #region CTDongNuoc

        /// <summary>
        /// Kiểm tra CTDongNuoc đã được tạo cho Mã Đơn Khách Hàng và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTDongNuocbyMaDonDanhBo(decimal MaDon, string DanhBo)
        {
            try
            {
                return db.CTDongNuocs.Any(itemCTDongNuoc => itemCTDongNuoc.DongNuoc.MaDon == MaDon && itemCTDongNuoc.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra CTDongNuoc đã được tạo cho Mã Đơn Tổ Xử Lý và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTDongNuocbyMaDonDanhBo_TXL(decimal MaDonTXL, string DanhBo)
        {
            try
            {
                return db.CTDongNuocs.Any(itemCTDongNuoc => itemCTDongNuoc.DongNuoc.MaDonTXL == MaDonTXL && itemCTDongNuoc.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ThemCTDongNuoc(CTDongNuoc ctdongnuoc)
        {
            try
            {
                if (CTaiKhoan.RoleDongNuoc_CapNhat)
                {
                    if (db.CTDongNuocs.Count() > 0)
                    {
                        string ID = "MaCTDN";
                        string Table = "CTDongNuoc";
                        decimal MaCTDN = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //decimal MaCTDN = db.CTDongNuocs.Max(itemCTDongNuoc => itemCTDongNuoc.MaCTDN);
                        ctdongnuoc.MaCTDN = getMaxNextIDTable(MaCTDN);
                    }
                    else
                        ctdongnuoc.MaCTDN = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    ctdongnuoc.CreateDate = DateTime.Now;
                    ctdongnuoc.CreateBy = CTaiKhoan.MaUser;
                    db.CTDongNuocs.InsertOnSubmit(ctdongnuoc);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm CTDongNuoc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTDongNuocs);
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

        public bool SuaCTDongNuoc(CTDongNuoc ctdongnuoc)
        {
            try
            {
                if (CTaiKhoan.RoleDongNuoc_CapNhat)
                {
                    ctdongnuoc.ModifyDate = DateTime.Now;
                    ctdongnuoc.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa CTDongNuoc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTDongNuocs);
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
        /// Lấy Mã Mở Nước kế tiếp cho Thông Báo Đóng Nước
        /// </summary>
        /// <returns></returns>
        public decimal getMaxNextMaCTMN()
        {
            try
            {
                if (db.CTDongNuocs.Count() > 0)
                {
                    if (db.CTDongNuocs.Max(itemCTDN => itemCTDN.MaCTMN) == null)
                        return decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    else
                        return getMaxNextIDTable(db.CTDongNuocs.Max(itemCTDN => itemCTDN.MaCTMN).Value);
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

        public CTDongNuoc getCTDongNuocbyID(decimal MaCTDN)
        {
            try
            {
                return db.CTDongNuocs.SingleOrDefault(itemCTDN => itemCTDN.MaCTDN == MaCTDN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public CTDongNuoc getCTMoNuocbyID(decimal MaCTMN)
        {
            try
            {
                return db.CTDongNuocs.SingleOrDefault(itemCTDN => itemCTDN.MaCTMN == MaCTMN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTDongNuoc()
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTDongNuoc in db.CTDongNuocs
                                select new
                                {
                                    In = false,
                                    PhieuDuocKy=itemCTDongNuoc.ThongBaoDuocKy_DN,
                                    SoPhieu = itemCTDongNuoc.MaCTDN,
                                    Ma = itemCTDongNuoc.MaCTDN,
                                    itemCTDongNuoc.CreateDate,
                                    itemCTDongNuoc.DanhBo,
                                    itemCTDongNuoc.HoTen,
                                    itemCTDongNuoc.DiaChi,
                                    NguoiKy=itemCTDongNuoc.NguoiKy_DN,
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

        public DataTable LoadDSCTDongNuoc(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTDongNuoc in db.CTDongNuocs
                                where itemCTDongNuoc.NgayDN.Value.Date==TuNgay.Date
                                select new
                                {
                                    In = false,
                                    PhieuDuocKy = itemCTDongNuoc.ThongBaoDuocKy_DN,
                                    SoPhieu = itemCTDongNuoc.MaCTDN,
                                    Ma = itemCTDongNuoc.MaCTDN,
                                    itemCTDongNuoc.CreateDate,
                                    itemCTDongNuoc.DanhBo,
                                    itemCTDongNuoc.HoTen,
                                    itemCTDongNuoc.DiaChi,
                                    NguoiKy = itemCTDongNuoc.NguoiKy_DN,
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

        public DataTable LoadDSCTDongNuoc(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTDongNuoc in db.CTDongNuocs
                                where itemCTDongNuoc.NgayDN.Value.Date>=TuNgay && itemCTDongNuoc.NgayDN.Value.Date<=DenNgay
                                select new
                                {
                                    In = false,
                                    PhieuDuocKy = itemCTDongNuoc.ThongBaoDuocKy_DN,
                                    SoPhieu = itemCTDongNuoc.MaCTDN,
                                    Ma = itemCTDongNuoc.MaCTDN,
                                    itemCTDongNuoc.CreateDate,
                                    itemCTDongNuoc.DanhBo,
                                    itemCTDongNuoc.HoTen,
                                    itemCTDongNuoc.DiaChi,
                                    NguoiKy = itemCTDongNuoc.NguoiKy_DN,
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

        public DataTable LoadDSCTMoNuoc()
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTDongNuoc in db.CTDongNuocs
                                where itemCTDongNuoc.MoNuoc==true
                                select new
                                {
                                    In = false,
                                    PhieuDuocKy = itemCTDongNuoc.ThongBaoDuocKy_MN,
                                    SoPhieu = itemCTDongNuoc.MaCTMN,
                                    Ma = itemCTDongNuoc.MaCTMN,
                                    itemCTDongNuoc.CreateDate,
                                    itemCTDongNuoc.DanhBo,
                                    itemCTDongNuoc.HoTen,
                                    itemCTDongNuoc.DiaChi,
                                    NguoiKy = itemCTDongNuoc.NguoiKy_MN,
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

        public DataTable LoadDSCTMoNuoc(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTDongNuoc in db.CTDongNuocs
                                where itemCTDongNuoc.MoNuoc==true&&itemCTDongNuoc.NgayMN.Value.Date == TuNgay.Date
                                select new
                                {
                                    In = false,
                                    PhieuDuocKy = itemCTDongNuoc.ThongBaoDuocKy_MN,
                                    SoPhieu = itemCTDongNuoc.MaCTMN,
                                    Ma = itemCTDongNuoc.MaCTMN,
                                    itemCTDongNuoc.CreateDate,
                                    itemCTDongNuoc.DanhBo,
                                    itemCTDongNuoc.HoTen,
                                    itemCTDongNuoc.DiaChi,
                                    NguoiKy = itemCTDongNuoc.NguoiKy_MN,
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

        public DataTable LoadDSCTMoNuoc(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTDongNuoc in db.CTDongNuocs
                                where itemCTDongNuoc.MoNuoc == true && itemCTDongNuoc.NgayMN.Value.Date >= TuNgay && itemCTDongNuoc.NgayMN.Value.Date <= DenNgay
                                select new
                                {
                                    In = false,
                                    PhieuDuocKy = itemCTDongNuoc.ThongBaoDuocKy_MN,
                                    SoPhieu = itemCTDongNuoc.MaCTMN,
                                    Ma = itemCTDongNuoc.MaCTMN,
                                    itemCTDongNuoc.CreateDate,
                                    itemCTDongNuoc.DanhBo,
                                    itemCTDongNuoc.HoTen,
                                    itemCTDongNuoc.DiaChi,
                                    NguoiKy = itemCTDongNuoc.NguoiKy_MN,
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

        #endregion
    }
}

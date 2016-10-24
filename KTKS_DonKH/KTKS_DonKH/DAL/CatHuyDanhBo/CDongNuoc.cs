using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
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
        public bool CheckByMaDon(decimal MaDon)
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
        public bool CheckByMaDon_TXL(decimal MaDonTXL)
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

        public bool Them(LinQ.DongNuoc dongnuoc)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool Sua(LinQ.DongNuoc dongnuoc)
        {
            try
            {
                    dongnuoc.ModifyDate = DateTime.Now;
                    dongnuoc.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa DongNuoc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool Xoa(LinQ.DongNuoc dongnuoc)
        {
            try
            {
                    db.DongNuocs.DeleteOnSubmit(dongnuoc);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa DongNuoc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// Lấy DongNuoc bằng MaDon
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns></returns>
        public LinQ.DongNuoc GetByMaDon(decimal MaDon)
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
        public LinQ.DongNuoc GetByMaDon_TXL(decimal MaDonTXL)
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
        public bool CheckCTByMaDonDanhBo(decimal MaDon, string DanhBo)
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
        public bool CheckCTByMaDonDanhBo_TXL(decimal MaDonTXL, string DanhBo)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool SuaCT(CTDongNuoc ctdongnuoc)
        {
            try
            {
                    ctdongnuoc.ModifyDate = DateTime.Now;
                    ctdongnuoc.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa CTDongNuoc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool XoaCT(CTDongNuoc ctdongnuoc)
        {
            try
            {
                    db.CTDongNuocs.DeleteOnSubmit(ctdongnuoc);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa CTDongNuoc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public CTDongNuoc GetCTByMaCTDN(decimal MaCTDN)
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

        public CTDongNuoc GetCTByMaCTMN(decimal MaCTMN)
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

        public DataTable GetDSCTDongNuoc()
        {
            try
            {
                    var query = from itemCTDongNuoc in db.CTDongNuocs
                                orderby itemCTDongNuoc.CreateDate descending
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
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSCTDongNuocByMaDon(decimal MaDon)
        {
            try
            {
                    var query = from itemCTDongNuoc in db.CTDongNuocs
                                where itemCTDongNuoc.DongNuoc.MaDon==MaDon||itemCTDongNuoc.DongNuoc.MaDonTXL==MaDon
                                orderby itemCTDongNuoc.CreateDate descending
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
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSCTDongNuocByMaTB(decimal MaTB)
        {
            try
            {
                    var query = from itemCTDongNuoc in db.CTDongNuocs
                                where itemCTDongNuoc.MaCTDN==MaTB
                                orderby itemCTDongNuoc.CreateDate descending
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
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSCTDongNuocByDanhBo(string DanhBo)
        {
            try
            {
                    var query = from itemCTDongNuoc in db.CTDongNuocs
                                where itemCTDongNuoc.DanhBo==DanhBo
                                orderby itemCTDongNuoc.CreateDate descending
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
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSCTDongNuocByDate(DateTime TuNgay)
        {
            try
            {
                    var query = from itemCTDongNuoc in db.CTDongNuocs
                                where itemCTDongNuoc.NgayDN.Value.Date==TuNgay.Date
                                orderby itemCTDongNuoc.CreateDate descending
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
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSCTDongNuocByDates(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                    var query = from itemCTDongNuoc in db.CTDongNuocs
                                where itemCTDongNuoc.NgayDN.Value.Date>=TuNgay.Date&&itemCTDongNuoc.NgayDN.Value.Date<=DenNgay.Date
                                orderby itemCTDongNuoc.CreateDate descending
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
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSCTDongNuoc(DateTime TuNgay)
        {
            try
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
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSCTDongNuoc(DateTime TuNgay,DateTime DenNgay)
        {
            try
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
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSCTMoNuoc()
        {
            try
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
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSCTMoNuocByMaDon(decimal MaDon)
        {
            try
            {
                    var query = from itemCTDongNuoc in db.CTDongNuocs
                                where itemCTDongNuoc.MoNuoc == true && (itemCTDongNuoc.DongNuoc.MaDon==MaDon ||itemCTDongNuoc.DongNuoc.MaDonTXL==MaDon)
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
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSCTMoNuocByMaTB(decimal MaTB)
        {
            try
            {
                    var query = from itemCTDongNuoc in db.CTDongNuocs
                                where itemCTDongNuoc.MoNuoc == true && itemCTDongNuoc.MaCTMN==MaTB
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
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSCTMoNuocByDanhBo(string DanhBo)
        {
            try
            {
                    var query = from itemCTDongNuoc in db.CTDongNuocs
                                where itemCTDongNuoc.MoNuoc == true && itemCTDongNuoc.DanhBo==DanhBo
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
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSCTMoNuocByDate(DateTime TuNgay)
        {
            try
            {
                    var query = from itemCTDongNuoc in db.CTDongNuocs
                                where itemCTDongNuoc.MoNuoc == true && itemCTDongNuoc.NgayMN.Value.Date==TuNgay.Date
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
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSCTMoNuocByDates(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                    var query = from itemCTDongNuoc in db.CTDongNuocs
                                where itemCTDongNuoc.MoNuoc == true && itemCTDongNuoc.NgayMN.Value.Date >= TuNgay.Date&& itemCTDongNuoc.NgayMN.Value.Date<=DenNgay.Date
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
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSCTMoNuoc(DateTime TuNgay)
        {
            try
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
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSCTMoNuoc(DateTime TuNgay, DateTime DenNgay)
        {
            try
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
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public int CountCT(decimal MaDN)
        {
            return db.CTDongNuocs.Count(item => item.MaDN == MaDN);
        }

        #endregion
    }
}

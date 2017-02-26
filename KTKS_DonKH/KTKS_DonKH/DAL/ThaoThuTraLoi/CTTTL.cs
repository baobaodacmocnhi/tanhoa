using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.ThaoThuTraLoi
{
    class CTTTL : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng TTTL & CTTTL

        #region TTTL (Thảo Thư Trả Lời)

        public bool Them(TTTL tttl)
        {
            try
            {
                if (db.TTTLs.Count() > 0)
                {
                    string ID = "MaTTTL";
                    string Table = "TTTL";
                    decimal MaTTTL = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    //decimal MaTTTL = db.TTTLs.Max(itemTTTL => itemTTTL.MaTTTL);
                    tttl.MaTTTL = getMaxNextIDTable(MaTTTL);
                }
                else
                    tttl.MaTTTL = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                tttl.CreateDate = DateTime.Now;
                tttl.CreateBy = CTaiKhoan.MaUser;
                db.TTTLs.InsertOnSubmit(tttl);
                db.SubmitChanges();
                //MessageBox.Show("Thành công Thêm TTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool Sua(TTTL tttl)
        {
            try
            {
                tttl.ModifyDate = DateTime.Now;
                tttl.ModifyBy = CTaiKhoan.MaUser;
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

        public TTTL Get(decimal MaTTTL)
        {
            try
            {
                return db.TTTLs.SingleOrDefault(itemTTTL => itemTTTL.MaTTTL == MaTTTL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Mã Thảo Thư Trả Lời lớn nhất hiện tại
        /// </summary>
        /// <returns></returns>
        public decimal GetMaxMaTTTL()
        {
            try
            {
                return db.TTTLs.Max(itemTTTL => itemTTTL.MaTTTL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public bool CheckExist(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.TTTLs.Any(item => item.MaDon == MaDon);
                case "TXL":
                    return db.TTTLs.Any(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.TTTLs.Any(item => item.MaDonTBC == MaDon);
                default:
                    return false;
            }
        }

        /// <summary>
        /// Kiểm tra Đơn KH có được TTTL xử lý hay chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns>true/có</returns>
        public bool CheckByMaDon(decimal MaDon)
        {
            try
            {
                if (db.TTTLs.Any(itemTTTL => itemTTTL.MaDon == MaDon))
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
        /// Kiểm tra Đơn Tổ Xử Lý có được TTTL xử lý hay chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns>true/có</returns>
        public bool CheckByMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                if (db.TTTLs.Any(itemTTTL => itemTTTL.MaDonTXL == MaDonTXL))
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
        /// Lấy TTTL bằng MaDon
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns></returns>
        public TTTL GetByMaDon(decimal MaDon)
        {
            try
            {
                return db.TTTLs.SingleOrDefault(itemTTTL => itemTTTL.MaDon == MaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy TTTL bằng MaDon Tổ Xử Lý
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns></returns>
        public TTTL GetByMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                return db.TTTLs.SingleOrDefault(itemTTTL => itemTTTL.MaDonTXL == MaDonTXL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public TTTL Get(string Loai,decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.TTTLs.SingleOrDefault(item => item.MaDon == MaDon);
                case "TXL":
                    return db.TTTLs.SingleOrDefault(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.TTTLs.SingleOrDefault(item => item.MaDonTBC == MaDon);
                default:
                    return null;
            }
        }

        #endregion

        #region CTTTTL (Chi Tiết Thảo Thư Trả Lời)

        public bool ThemCT(CTTTTL cttttl)
        {
            try
            {
                if (db.CTTTTLs.Count() > 0)
                {
                    string ID = "MaCTTTTL";
                    string Table = "CTTTTL";
                    decimal MaCTTTTL = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    //decimal MaCTTTTL = db.CTTTTLs.Max(itemCTTTTL => itemCTTTTL.MaCTTTTL);
                    cttttl.MaCTTTTL = getMaxNextIDTable(MaCTTTTL);
                }
                else
                    cttttl.MaCTTTTL = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                cttttl.CreateDate = DateTime.Now;
                cttttl.CreateBy = CTaiKhoan.MaUser;
                db.CTTTTLs.InsertOnSubmit(cttttl);
                db.SubmitChanges();
                //MessageBox.Show("Thành công Thêm CTTTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool SuaCT(CTTTTL cttttl)
        {
            try
            {
                cttttl.ModifyDate = DateTime.Now;
                cttttl.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa CTTTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool XoaCT(CTTTTL cttttl)
        {
            try
            {
                decimal ID = cttttl.MaTTTL;
                db.CTTTTLs.DeleteOnSubmit(cttttl);
                if (db.CTTTTLs.Any(item => item.MaTTTL == ID) == false)
                    db.TTTLs.DeleteOnSubmit(db.TTTLs.SingleOrDefault(item => item.MaTTTL == ID));
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa CTTTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public CTTTTL GetCT(decimal MaCTTTTL)
        {
            try
            {
                return db.CTTTTLs.SingleOrDefault(itemCTTTTL => itemCTTTTL.MaCTTTTL == MaCTTTTL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public decimal GetMaxMaCT()
        {
            try
            {
                return db.CTTTTLs.Max(itemCTTTTL => itemCTTTTL.MaCTTTTL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Chi Tiết Thảo Thư Trả Lời
        /// </summary>
        /// <returns></returns>
        public DataTable GetDS()
        {
            return LINQToDataTable(db.CTTTTLs.ToList());
        }

        public DataTable GetDSByMaDon(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    var query = from item in db.CTTTTLs
                                where item.TTTL.MaDon == MaDon
                                select new
                                {
                                    MaDon = "TKH" + item.TTTL.MaDon,
                                    item.CreateDate,
                                    item.DanhBo,
                                    item.VeViec,
                                    item.NoiDung,
                                    item.NoiNhan,
                                    item.ThuDuocKy,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from item in db.CTTTTLs
                            where item.TTTL.MaDonTXL == MaDon
                            select new
                            {
                                MaDon = "TXL" + item.TTTL.MaDonTBC,
                                item.CreateDate,
                                item.DanhBo,
                                item.VeViec,
                                item.NoiDung,
                                item.NoiNhan,
                                item.ThuDuocKy,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from item in db.CTTTTLs
                            where item.TTTL.MaDonTBC == MaDon
                            select new
                            {
                                MaDon =  "TBC" + item.TTTL.MaDonTBC,
                                item.CreateDate,
                                item.DanhBo,
                                item.VeViec,
                                item.NoiDung,
                                item.NoiNhan,
                                item.ThuDuocKy,
                            };
                    return LINQToDataTable(query);
                default:
                    return null;
            }
        }

        public DataTable GetDSByMaTB(decimal MaCTTTTL)
        {
            var query = from item in db.CTTTTLs
                        where item.MaCTTTTL == MaCTTTTL
                        select new
                        {
                            MaDon = item.TTTL.MaDon != null ? "TKH" + item.TTTL.MaDon
                                : item.TTTL.MaDonTXL != null ? "TXL" + item.TTTL.MaDonTXL
                                : item.TTTL.MaDonTBC != null ? "TBC" + item.TTTL.MaDonTBC : null,
                            item.CreateDate,
                            item.DanhBo,
                            item.VeViec,
                            item.NoiDung,
                            item.NoiNhan,
                            item.ThuDuocKy,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSByMaTBs(decimal TuMaCTTTTL, decimal DenMaCTTTTL)
        {
            var query = from item in db.CTTTTLs
                        where item.MaCTTTTL.ToString().Substring(item.MaCTTTTL.ToString().Length - 2, 2) == TuMaCTTTTL.ToString().Substring(TuMaCTTTTL.ToString().Length - 2, 2)
                                && item.MaCTTTTL.ToString().Substring(item.MaCTTTTL.ToString().Length - 2, 2) == DenMaCTTTTL.ToString().Substring(DenMaCTTTTL.ToString().Length - 2, 2)
                                && item.MaCTTTTL >= TuMaCTTTTL && item.MaCTTTTL <= DenMaCTTTTL
                        select new
                        {
                            MaDon = item.TTTL.MaDon != null ? "TKH" + item.TTTL.MaDon
                                : item.TTTL.MaDonTXL != null ? "TXL" + item.TTTL.MaDonTXL
                                : item.TTTL.MaDonTBC != null ? "TBC" + item.TTTL.MaDonTBC : null,
                            item.CreateDate,
                            item.DanhBo,
                            item.VeViec,
                            item.NoiDung,
                            item.NoiNhan,
                            item.ThuDuocKy,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSByDanhBo(string DanhBo)
        {
            var query = from item in db.CTTTTLs
                        where item.DanhBo == DanhBo
                        select new
                        {
                            MaDon = item.TTTL.MaDon != null ? "TKH" + item.TTTL.MaDon
                                : item.TTTL.MaDonTXL != null ? "TXL" + item.TTTL.MaDonTXL
                                : item.TTTL.MaDonTBC != null ? "TBC" + item.TTTL.MaDonTBC : null,
                            item.CreateDate,
                            item.DanhBo,
                            item.VeViec,
                            item.NoiDung,
                            item.NoiNhan,
                            item.ThuDuocKy,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSByCreateDate(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.CTTTTLs
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.TTTL.MaDon != null ? "TKH" + item.TTTL.MaDon
                                : item.TTTL.MaDonTXL != null ? "TXL" + item.TTTL.MaDonTXL
                                : item.TTTL.MaDonTBC != null ? "TBC" + item.TTTL.MaDonTBC : null,
                                item.CreateDate,
                                item.DanhBo,
                                item.VeViec,
                                item.NoiDung,
                                item.NoiNhan,
                                item.ThuDuocKy,
                        };
            return LINQToDataTable(query);
        }

        /// <summary>
        /// Kiểm tra Thư đã được tạo cho Mã Đơn và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTByMaDonDanhBo(decimal MaDon, string DanhBo, DateTime CreateDate)
        {
            try
            {
                return db.CTTTTLs.Any(itemCTTTTL => itemCTTTTL.TTTL.MaDon == MaDon && itemCTTTTL.DanhBo == DanhBo && itemCTTTTL.CreateDate.Value.Date == CreateDate.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra Thư đã được tạo cho Mã Đơn Tổ Xử Lý và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTByMaDonDanhBo_TXL(decimal MaDonTXL, string DanhBo, DateTime CreateDate)
        {
            try
            {
                return db.CTTTTLs.Any(itemCTTTTL => itemCTTTTL.TTTL.MaDonTXL == MaDonTXL && itemCTTTTL.DanhBo == DanhBo && itemCTTTTL.CreateDate.Value.Date == CreateDate.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExistCT(string Loai,decimal MaDon, string DanhBo, DateTime CreateDate)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.CTTTTLs.Any(item => item.TTTL.MaDon == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
                case "TXL":
                    return db.CTTTTLs.Any(item => item.TTTL.MaDonTXL == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
                case "TBC":
                    return db.CTTTTLs.Any(item => item.TTTL.MaDonTBC == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
                default:
                    return false;
            }
        }

        public bool CheckExist(decimal MaCTTTTL)
        {
            return db.CTTTTLs.Any(item => item.MaCTTTTL == MaCTTTTL);
        }

        public DataTable GetLichSuCTByDanhBo(string DanhBo)
        {
            var query = from item in db.CTTTTLs
                        where item.DanhBo == DanhBo
                        orderby item.CreateDate descending
                        select new
                        {
                            item.MaCTTTTL,
                            MaDon = item.TTTL.MaDon != null ? "TKH" + item.TTTL.MaDon
                                : item.TTTL.MaDonTXL != null ? "TXL" + item.TTTL.MaDonTXL
                                : item.TTTL.MaDonTBC != null ? "TBC" + item.TTTL.MaDonTBC : null,
                            item.VeViec,
                        };
            return LINQToDataTable(query);
        }

        #endregion
    }
}

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
        ///Chứa hàm truy xuất dữ liệu từ bảng DongNuoc & DongNuoc_ChiTiet

        #region DongNuoc

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
                    dongnuoc.MaDN = getMaxNextIDTable(MaDN);
                }
                else
                    dongnuoc.MaDN = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                dongnuoc.CreateDate = DateTime.Now;
                dongnuoc.CreateBy = CTaiKhoan.MaUser;
                db.DongNuocs.InsertOnSubmit(dongnuoc);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
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
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool Xoa(LinQ.DongNuoc dongnuoc)
        {
            try
            {
                db.DongNuocs.DeleteOnSubmit(dongnuoc);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool CheckExist(string Loai,decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.DongNuocs.Any(item => item.MaDon == MaDon);
                case "TXL":
                    return db.DongNuocs.Any(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.DongNuocs.Any(item => item.MaDonTBC == MaDon);
                default:
                    return false;
            }
        }

        public LinQ.DongNuoc Get(string Loai,decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.DongNuocs.SingleOrDefault(item => item.MaDon == MaDon);
                case "TXL":
                    return db.DongNuocs.SingleOrDefault(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.DongNuocs.SingleOrDefault(item => item.MaDonTBC == MaDon);
                default:
                    return null;
            }
        }

        #endregion

        #region DongNuoc_ChiTiet

        public bool ThemCT(DongNuoc_ChiTiet ctdongnuoc)
        {
            try
            {
                if (db.DongNuoc_ChiTiets.Count() > 0)
                {
                    string ID = "MaCTDN";
                    string Table = "DongNuoc_ChiTiet";
                    decimal MaCTDN = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    ctdongnuoc.MaCTDN = getMaxNextIDTable(MaCTDN);
                }
                else
                    ctdongnuoc.MaCTDN = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                ctdongnuoc.CreateDate = DateTime.Now;
                ctdongnuoc.CreateBy = CTaiKhoan.MaUser;
                db.DongNuoc_ChiTiets.InsertOnSubmit(ctdongnuoc);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool SuaCT(DongNuoc_ChiTiet ctdongnuoc)
        {
            try
            {
                ctdongnuoc.ModifyDate = DateTime.Now;
                ctdongnuoc.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool XoaCT(DongNuoc_ChiTiet ctdongnuoc)
        {
            try
            {
                decimal ID = ctdongnuoc.MaDN.Value;
                db.DongNuoc_ChiTiets.DeleteOnSubmit(ctdongnuoc);
                if (db.DongNuoc_ChiTiets.Any(item => item.MaDN == ID) == false)
                    db.DongNuocs.DeleteOnSubmit(db.DongNuocs.SingleOrDefault(item => item.MaDN == ID));
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool CheckExist_CT(string Loai,decimal MaDon, string DanhBo)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.DongNuoc_ChiTiets.Any(item => item.DongNuoc.MaDon == MaDon && item.DanhBo == DanhBo);
                case "TXL":
                    return db.DongNuoc_ChiTiets.Any(item => item.DongNuoc.MaDonTXL == MaDon && item.DanhBo == DanhBo);
                case "TBC":
                    return db.DongNuoc_ChiTiets.Any(item => item.DongNuoc.MaDonTBC == MaDon && item.DanhBo == DanhBo);
                default:
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
                if (db.DongNuoc_ChiTiets.Count() > 0)
                {
                    if (db.DongNuoc_ChiTiets.Max(itemCTDN => itemCTDN.MaCTMN) == null)
                        return decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    else
                        return getMaxNextIDTable(db.DongNuoc_ChiTiets.Max(itemCTDN => itemCTDN.MaCTMN).Value);
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

        public DongNuoc_ChiTiet GetCTByMaCTDN(decimal MaCTDN)
        {
            try
            {
                return db.DongNuoc_ChiTiets.SingleOrDefault(itemCTDN => itemCTDN.MaCTDN == MaCTDN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DongNuoc_ChiTiet GetCTByMaCTMN(decimal MaCTMN)
        {
            try
            {
                return db.DongNuoc_ChiTiets.SingleOrDefault(itemCTDN => itemCTDN.MaCTMN == MaCTMN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSDongNuoc(string To, decimal MaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from item in db.DongNuoc_ChiTiets
                                where item.DongNuoc.MaDon == MaDon
                                select new
                                {
                                    MaDon = "TKH" + item.DongNuoc.MaDon,
                                    PhieuDuocKy = item.ThongBaoDuocKy_DN,
                                    MaTB = item.MaCTDN,
                                    item.CreateDate,
                                    item.DanhBo,
                                    item.HoTen,
                                    item.DiaChi,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from item in db.DongNuoc_ChiTiets
                            where item.DongNuoc.MaDonTXL == MaDon
                            select new
                            {
                                MaDon = "TXL" + item.DongNuoc.MaDonTXL,
                                PhieuDuocKy = item.ThongBaoDuocKy_DN,
                                MaTB = item.MaCTDN,
                                item.CreateDate,
                                item.DanhBo,
                                item.HoTen,
                                item.DiaChi,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from item in db.DongNuoc_ChiTiets
                            where item.DongNuoc.MaDonTBC == MaDon
                            select new
                            {
                                MaDon = "TBC" + item.DongNuoc.MaDonTBC,
                                PhieuDuocKy = item.ThongBaoDuocKy_DN,
                                MaTB = item.MaCTDN,
                                item.CreateDate,
                                item.DanhBo,
                                item.HoTen,
                                item.DiaChi,
                            };
                    return LINQToDataTable(query);
                default:
                   query = from item in db.DongNuoc_ChiTiets
                            where item.DongNuoc.MaDonMoi == MaDon
                            select new
                            {
                                MaDon =  item.DongNuoc.MaDonMoi.Value.ToString(),
                                PhieuDuocKy = item.ThongBaoDuocKy_DN,
                                MaTB = item.MaCTDN,
                                item.CreateDate,
                                item.DanhBo,
                                item.HoTen,
                                item.DiaChi,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable GetDSDongNuoc(decimal MaCTDN)
        {
            var query = from item in db.DongNuoc_ChiTiets
                        where item.MaCTDN == MaCTDN
                        select new
                        {
                            MaDon = item.DongNuoc.MaDon != null ? "TKH" + item.DongNuoc.MaDon
                                : item.DongNuoc.MaDonTXL != null ? "TXL" + item.DongNuoc.MaDonTXL
                                : item.DongNuoc.MaDonTBC != null ? "TBC" + item.DongNuoc.MaDonTBC : null,
                            PhieuDuocKy = item.ThongBaoDuocKy_DN,
                            MaTB = item.MaCTDN,
                            ID = item.MaCTDN,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDongNuoc(string DanhBo)
        {
            var query = from item in db.DongNuoc_ChiTiets
                        where item.DanhBo==DanhBo
                        select new
                        {
                            MaDon = item.DongNuoc.MaDon != null ? "TKH" + item.DongNuoc.MaDon
                                : item.DongNuoc.MaDonTXL != null ? "TXL" + item.DongNuoc.MaDonTXL
                                : item.DongNuoc.MaDonTBC != null ? "TBC" + item.DongNuoc.MaDonTBC : null,
                            PhieuDuocKy = item.ThongBaoDuocKy_DN,
                            MaTB = item.MaCTDN,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDongNuocByNgayDN(DateTime FromNgayDN, DateTime ToNgayDN)
        {
            var query = from item in db.DongNuoc_ChiTiets
                        where item.NgayDN.Value.Date >= FromNgayDN.Date && item.NgayDN.Value.Date <= ToNgayDN.Date
                        select new
                        {
                            MaDon = item.DongNuoc.MaDon != null ? "TKH" + item.DongNuoc.MaDon
                                : item.DongNuoc.MaDonTXL != null ? "TXL" + item.DongNuoc.MaDonTXL
                                : item.DongNuoc.MaDonTBC != null ? "TBC" + item.DongNuoc.MaDonTBC : null,
                            PhieuDuocKy = item.ThongBaoDuocKy_DN,
                            MaTB = item.MaCTDN,
                            ID = item.MaCTDN,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDongNuocByCreateDate(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.DongNuoc_ChiTiets
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.DongNuoc.MaDon != null ? "TKH" + item.DongNuoc.MaDon
                                : item.DongNuoc.MaDonTXL != null ? "TXL" + item.DongNuoc.MaDonTXL
                                : item.DongNuoc.MaDonTBC != null ? "TBC" + item.DongNuoc.MaDonTBC : null,
                            PhieuDuocKy = item.ThongBaoDuocKy_DN,
                            MaTB = item.MaCTDN,
                            ID = item.MaCTDN,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSMoNuoc(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    var query = from item in db.DongNuoc_ChiTiets
                                where item.MoNuoc == true && item.DongNuoc.MaDon == MaDon
                                select new
                                {
                                    MaDon = "TKH" + item.DongNuoc.MaDon,
                                    PhieuDuocKy = item.ThongBaoDuocKy_MN,
                                    MaTB = item.MaCTMN,
                                    ID = item.MaCTMN,
                                    item.CreateDate,
                                    item.DanhBo,
                                    item.HoTen,
                                    item.DiaChi,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from item in db.DongNuoc_ChiTiets
                            where item.MoNuoc == true && item.DongNuoc.MaDonTXL == MaDon
                            select new
                            {
                                MaDon = "TXL" + item.DongNuoc.MaDonTXL,
                                PhieuDuocKy = item.ThongBaoDuocKy_MN,
                                MaTB = item.MaCTMN,
                                ID = item.MaCTMN,
                                item.CreateDate,
                                item.DanhBo,
                                item.HoTen,
                                item.DiaChi,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from item in db.DongNuoc_ChiTiets
                            where item.MoNuoc == true && item.DongNuoc.MaDonTBC == MaDon
                            select new
                            {
                                MaDon = "TBC" + item.DongNuoc.MaDonTBC,
                                PhieuDuocKy = item.ThongBaoDuocKy_MN,
                                MaTB = item.MaCTMN,
                                ID = item.MaCTMN,
                                item.CreateDate,
                                item.DanhBo,
                                item.HoTen,
                                item.DiaChi,
                            };
                    return LINQToDataTable(query);
                default:
                    return null;
            }
        }

        public DataTable GetDSMoNuoc(decimal MaCTMN)
        {
            var query = from item in db.DongNuoc_ChiTiets
                        where item.MoNuoc == true && item.MaCTMN == MaCTMN
                        select new
                        {
                            MaDon = item.DongNuoc.MaDon != null ? "TKH" + item.DongNuoc.MaDon
                            : item.DongNuoc.MaDonTXL != null ? "TXL" + item.DongNuoc.MaDonTXL
                            : item.DongNuoc.MaDonTBC != null ? "TBC" + item.DongNuoc.MaDonTBC : null,
                            PhieuDuocKy = item.ThongBaoDuocKy_MN,
                            MaTB = item.MaCTMN,
                            ID = item.MaCTMN,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSMoNuoc(string DanhBo)
        {
            var query = from item in db.DongNuoc_ChiTiets
                        where item.MoNuoc == true && item.DanhBo==DanhBo
                        select new
                        {
                            MaDon = item.DongNuoc.MaDon != null ? "TKH" + item.DongNuoc.MaDon
                            : item.DongNuoc.MaDonTXL != null ? "TXL" + item.DongNuoc.MaDonTXL
                            : item.DongNuoc.MaDonTBC != null ? "TBC" + item.DongNuoc.MaDonTBC : null,
                            PhieuDuocKy = item.ThongBaoDuocKy_MN,
                            MaTB = item.MaCTMN,
                            ID = item.MaCTMN,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSMoNuoc(DateTime FromNgayMN, DateTime ToNgayMN)
        {
                var query = from item in db.DongNuoc_ChiTiets
                            where item.MoNuoc == true && item.NgayMN.Value.Date >= FromNgayMN.Date && item.NgayMN.Value.Date <= ToNgayMN.Date
                            select new
                            {
                                MaDon = item.DongNuoc.MaDon != null ? "TKH" + item.DongNuoc.MaDon
                                : item.DongNuoc.MaDonTXL != null ? "TXL" + item.DongNuoc.MaDonTXL
                                : item.DongNuoc.MaDonTBC != null ? "TBC" + item.DongNuoc.MaDonTBC : null,
                                PhieuDuocKy = item.ThongBaoDuocKy_MN,
                                MaTB = item.MaCTMN,
                                ID = item.MaCTMN,
                                item.CreateDate,
                                item.DanhBo,
                                item.HoTen,
                                item.DiaChi,
                            };
                return LINQToDataTable(query);
        }

        #endregion

        //MaDonMoi

        public bool checkExist(int MaDon)
        {
                    return db.DongNuocs.Any(item => item.MaDonMoi == MaDon);
        }

        public bool checkExist_ChiTiet(int MaDon, string DanhBo)
        {
                    return db.DongNuoc_ChiTiets.Any(item => item.DongNuoc.MaDonMoi == MaDon && item.DanhBo == DanhBo);
        }

        public LinQ.DongNuoc get(int MaDon)
        {
                    return db.DongNuocs.SingleOrDefault(item => item.MaDonMoi == MaDon);
        }
    }
}

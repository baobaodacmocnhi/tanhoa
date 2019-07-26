using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.ThuTraLoi
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
                    tttl.MaTTTL = getMaxNextIDTable(MaTTTL);
                }
                else
                    tttl.MaTTTL = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                tttl.CreateDate = DateTime.Now;
                tttl.CreateBy = CTaiKhoan.MaUser;
                db.TTTLs.InsertOnSubmit(tttl);
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

        public bool Sua(TTTL tttl)
        {
            try
            {
                tttl.ModifyDate = DateTime.Now;
                tttl.ModifyBy = CTaiKhoan.MaUser;
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

        public TTTL Get(decimal MaTTTL)
        {
            return db.TTTLs.SingleOrDefault(itemTTTL => itemTTTL.MaTTTL == MaTTTL);
        }

        public TTTL Get(string Loai, decimal MaDon)
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

        #endregion

        #region TTTL_ChiTiet (Chi Tiết Thảo Thư Trả Lời)

        public bool ThemCT(TTTL_ChiTiet cttttl)
        {
            try
            {
                if (db.TTTL_ChiTiets.Count() > 0)
                {
                    string ID = "MaCTTTTL";
                    string Table = "TTTL_ChiTiet";
                    decimal MaCTTTTL = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    cttttl.MaCTTTTL = getMaxNextIDTable(MaCTTTTL);
                }
                else
                    cttttl.MaCTTTTL = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                cttttl.CreateDate = DateTime.Now;
                cttttl.CreateBy = CTaiKhoan.MaUser;
                db.TTTL_ChiTiets.InsertOnSubmit(cttttl);
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

        public bool SuaCT(TTTL_ChiTiet cttttl)
        {
            try
            {
                cttttl.ModifyDate = DateTime.Now;
                cttttl.ModifyBy = CTaiKhoan.MaUser;
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

        public bool XoaCT(TTTL_ChiTiet cttttl)
        {
            try
            {
                decimal ID = cttttl.MaTTTL;
                db.TTTL_ChiTiets.DeleteOnSubmit(cttttl);
                db.SubmitChanges();
                if (db.TTTL_ChiTiets.Any(item => item.MaTTTL == ID) == false)
                    db.TTTLs.DeleteOnSubmit(db.TTTLs.SingleOrDefault(item => item.MaTTTL == ID));
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

        public bool CheckExist_CT(string Loai, decimal MaDon, string DanhBo, DateTime CreateDate)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.TTTL_ChiTiets.Any(item => item.TTTL.MaDon == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
                case "TXL":
                    return db.TTTL_ChiTiets.Any(item => item.TTTL.MaDonTXL == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
                case "TBC":
                    return db.TTTL_ChiTiets.Any(item => item.TTTL.MaDonTBC == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
                default:
                    return false;
            }
        }

        public bool CheckExist_CT(decimal MaCTTTTL)
        {
            return db.TTTL_ChiTiets.Any(item => item.MaCTTTTL == MaCTTTTL);
        }

        public TTTL_ChiTiet GetCT(decimal MaCTTTTL)
        {
            return db.TTTL_ChiTiets.SingleOrDefault(itemCTTTTL => itemCTTTTL.MaCTTTTL == MaCTTTTL);
        }

        public DataTable GetDS()
        {
            return LINQToDataTable(db.TTTL_ChiTiets.ToList());
        }

        public DataTable GetDS(string To, decimal MaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from item in db.TTTL_ChiTiets
                                where item.TTTL.MaDon == MaDon
                                select new
                                {
                                    MaDon = "TKH" + item.TTTL.MaDon,
                                    item.MaCTTTTL,
                                    item.CreateDate,
                                    item.DanhBo,item.HoTen,item.DiaChi,
                                    item.VeViec,
                                    item.NoiDung,
                                    item.NoiNhan,
                                    item.ThuDuocKy,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from item in db.TTTL_ChiTiets
                            where item.TTTL.MaDonTXL == MaDon
                            select new
                            {
                                MaDon = "TXL" + item.TTTL.MaDonTBC,
                                item.MaCTTTTL,
                                item.CreateDate,
                                item.DanhBo,item.HoTen,item.DiaChi,
                                item.VeViec,
                                item.NoiDung,
                                item.NoiNhan,
                                item.ThuDuocKy,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from item in db.TTTL_ChiTiets
                            where item.TTTL.MaDonTBC == MaDon
                            select new
                            {
                                MaDon = "TBC" + item.TTTL.MaDonTBC,
                                item.MaCTTTTL,
                                item.CreateDate,
                                item.DanhBo,item.HoTen,item.DiaChi,
                                item.VeViec,
                                item.NoiDung,
                                item.NoiNhan,
                                item.ThuDuocKy,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.TTTL_ChiTiets
                            where item.TTTL.MaDonMoi == MaDon
                            select new
                            {
                                MaDon =  item.TTTL.MaDonMoi.Value.ToString(),
                                item.MaCTTTTL,
                                item.CreateDate,
                                item.DanhBo,item.HoTen,item.DiaChi,
                                item.VeViec,
                                item.NoiDung,
                                item.NoiNhan,
                                item.ThuDuocKy,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable GetDS(decimal MaCTTTTL)
        {
            var query = from item in db.TTTL_ChiTiets
                        where item.MaCTTTTL == MaCTTTTL
                        select new
                        {
                            MaDon = item.TTTL.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.TTTL.MaDonMoi).Count() == 1 ? item.TTTL.MaDonMoi.Value.ToString() : item.TTTL.MaDonMoi + "." + item.STT
                                : item.TTTL.MaDon != null ? "TKH" + item.TTTL.MaDon
                                : item.TTTL.MaDonTXL != null ? "TXL" + item.TTTL.MaDonTXL
                                : item.TTTL.MaDonTBC != null ? "TBC" + item.TTTL.MaDonTBC : null,
                            item.MaCTTTTL,
                            ID = item.MaCTTTTL,
                            item.CreateDate,
                            item.DanhBo,item.HoTen,item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                            item.NoiNhan,
                            item.ThuDuocKy,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(decimal TuMaCTTTTL, decimal DenMaCTTTTL)
        {
            var query = from item in db.TTTL_ChiTiets
                        where item.MaCTTTTL.ToString().Substring(item.MaCTTTTL.ToString().Length - 2, 2) == TuMaCTTTTL.ToString().Substring(TuMaCTTTTL.ToString().Length - 2, 2)
                                && item.MaCTTTTL.ToString().Substring(item.MaCTTTTL.ToString().Length - 2, 2) == DenMaCTTTTL.ToString().Substring(DenMaCTTTTL.ToString().Length - 2, 2)
                                && item.MaCTTTTL >= TuMaCTTTTL && item.MaCTTTTL <= DenMaCTTTTL
                        select new
                        {
                            MaDon = item.TTTL.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.TTTL.MaDonMoi).Count() == 1 ? item.TTTL.MaDonMoi.Value.ToString() : item.TTTL.MaDonMoi + "." + item.STT
                                : item.TTTL.MaDon != null ? "TKH" + item.TTTL.MaDon
                                : item.TTTL.MaDonTXL != null ? "TXL" + item.TTTL.MaDonTXL
                                : item.TTTL.MaDonTBC != null ? "TBC" + item.TTTL.MaDonTBC : null,
                            item.MaCTTTTL,
                            item.CreateDate,
                            item.DanhBo,item.HoTen,item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                            item.NoiNhan,
                            item.ThuDuocKy,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(string DanhBo)
        {
            var query = from item in db.TTTL_ChiTiets
                        where item.DanhBo == DanhBo
                        select new
                        {
                            MaDon = item.TTTL.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.TTTL.MaDonMoi).Count() == 1 ? item.TTTL.MaDonMoi.Value.ToString() : item.TTTL.MaDonMoi + "." + item.STT
                                : item.TTTL.MaDon != null ? "TKH" + item.TTTL.MaDon
                                : item.TTTL.MaDonTXL != null ? "TXL" + item.TTTL.MaDonTXL
                                : item.TTTL.MaDonTBC != null ? "TBC" + item.TTTL.MaDonTBC : null,
                            item.MaCTTTTL,
                            item.CreateDate,
                            item.DanhBo,item.HoTen,item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                            item.NoiNhan,
                            item.ThuDuocKy,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.TTTL_ChiTiets
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.TTTL.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.TTTL.MaDonMoi).Count() == 1 ? item.TTTL.MaDonMoi.Value.ToString() : item.TTTL.MaDonMoi + "." + item.STT
                                : item.TTTL.MaDon != null ? "TKH" + item.TTTL.MaDon
                                : item.TTTL.MaDonTXL != null ? "TXL" + item.TTTL.MaDonTXL
                                : item.TTTL.MaDonTBC != null ? "TBC" + item.TTTL.MaDonTBC : null,
                            item.MaCTTTTL,
                            ID = item.MaCTTTTL,
                            item.CreateDate,
                            item.DanhBo,item.HoTen,item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                            item.NoiNhan,
                            item.ThuDuocKy,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetLichSuCTByDanhBo(string DanhBo)
        {
            var query = from item in db.TTTL_ChiTiets
                        where item.DanhBo == DanhBo
                        orderby item.CreateDate descending
                        select new
                        {
                            item.MaCTTTTL,
                            MaDon = item.TTTL.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.TTTL.MaDonMoi).Count() == 1 ? item.TTTL.MaDonMoi.Value.ToString() : item.TTTL.MaDonMoi + "." + item.STT
                                : item.TTTL.MaDon != null ? "TKH" + item.TTTL.MaDon
                                : item.TTTL.MaDonTXL != null ? "TXL" + item.TTTL.MaDonTXL
                                : item.TTTL.MaDonTBC != null ? "TBC" + item.TTTL.MaDonTBC : null,
                            item.VeViec,
                        };
            return LINQToDataTable(query);
        }

        #endregion

        //MaDonMoi

        public bool checkExist(int MaDon)
        {
                    return db.TTTLs.Any(item => item.MaDonMoi == MaDon);
        }

        public bool checkExist_ChiTiet(int MaDon, string DanhBo, DateTime CreateDate)
        {
                    return db.TTTL_ChiTiets.Any(item => item.TTTL.MaDonMoi == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public TTTL get(int MaDon)
        {
                    return db.TTTLs.SingleOrDefault(item => item.MaDonMoi == MaDon);
        }

        #region Hình

        public bool Them_Hinh(TTTL_ChiTiet_Hinh en)
        {
            try
            {
                if (db.TTTL_ChiTiet_Hinhs.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = db.TTTL_ChiTiet_Hinhs.Max(item => item.ID) + 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.TTTL_ChiTiet_Hinhs.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_Hinh(TTTL_ChiTiet_Hinh en)
        {
            try
            {
                db.TTTL_ChiTiet_Hinhs.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public TTTL_ChiTiet_Hinh get_Hinh(int ID)
        {
            return db.TTTL_ChiTiet_Hinhs.SingleOrDefault(item => item.ID == ID);
        }

        #endregion
    }
}

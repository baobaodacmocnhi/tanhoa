using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.DAL.ThuTraLoi
{
    class CTTTL : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng ThuTraLoi & CTTTL

        #region ThuTraLoi (Thảo Thư Trả Lời)

        public bool Them(LinQ.ThuTraLoi tttl)
        {
            try
            {
                if (db.ThuTraLois.Count() > 0)
                {
                    string ID = "MaTTTL";
                    string Table = "ThuTraLoi";
                    decimal MaTTTL = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    tttl.MaTTTL = getMaxNextIDTable(MaTTTL);
                }
                else
                    tttl.MaTTTL = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                tttl.CreateDate = DateTime.Now;
                tttl.CreateBy = CTaiKhoan.MaUser;
                db.ThuTraLois.InsertOnSubmit(tttl);
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

        public bool Sua(LinQ.ThuTraLoi tttl)
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

        public LinQ.ThuTraLoi Get(decimal MaTTTL)
        {
            return db.ThuTraLois.SingleOrDefault(itemTTTL => itemTTTL.MaTTTL == MaTTTL);
        }

        public LinQ.ThuTraLoi Get(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.ThuTraLois.SingleOrDefault(item => item.MaDon == MaDon);
                case "TXL":
                    return db.ThuTraLois.SingleOrDefault(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.ThuTraLois.SingleOrDefault(item => item.MaDonTBC == MaDon);
                default:
                    return null;
            }
        }

        public bool CheckExist(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.ThuTraLois.Any(item => item.MaDon == MaDon);
                case "TXL":
                    return db.ThuTraLois.Any(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.ThuTraLois.Any(item => item.MaDonTBC == MaDon);
                default:
                    return false;
            }
        }

        #endregion

        #region ThuTraLoi_ChiTiet (Chi Tiết Thảo Thư Trả Lời)

        public bool ThemCT(ThuTraLoi_ChiTiet cttttl)
        {
            try
            {
                if (db.ThuTraLoi_ChiTiets.Count() > 0)
                {
                    string ID = "MaCTTTTL";
                    string Table = "ThuTraLoi_ChiTiet";
                    decimal MaCTTTTL = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    cttttl.MaCTTTTL = getMaxNextIDTable(MaCTTTTL);
                }
                else
                    cttttl.MaCTTTTL = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                cttttl.CreateDate = DateTime.Now;
                cttttl.CreateBy = CTaiKhoan.MaUser;
                db.ThuTraLoi_ChiTiets.InsertOnSubmit(cttttl);
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

        public bool SuaCT(ThuTraLoi_ChiTiet cttttl)
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

        public bool XoaCT(ThuTraLoi_ChiTiet cttttl)
        {
            try
            {
                CDonTu _cDonTu = new CDonTu();
                _cDonTu.Xoa_LichSu("ThuTraLoi_ChiTiet", (int)cttttl.MaCTTTTL);
                decimal ID = cttttl.MaTTTL;
                db.ThuTraLoi_ChiTiets.DeleteOnSubmit(cttttl);
                db.SubmitChanges();
                if (db.ThuTraLoi_ChiTiets.Any(item => item.MaTTTL == ID) == false)
                    db.ThuTraLois.DeleteOnSubmit(db.ThuTraLois.SingleOrDefault(item => item.MaTTTL == ID));
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
                    return db.ThuTraLoi_ChiTiets.Any(item => item.ThuTraLoi.MaDon == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
                case "TXL":
                    return db.ThuTraLoi_ChiTiets.Any(item => item.ThuTraLoi.MaDonTXL == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
                case "TBC":
                    return db.ThuTraLoi_ChiTiets.Any(item => item.ThuTraLoi.MaDonTBC == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
                default:
                    return false;
            }
        }

        public bool CheckExist_CT(decimal MaCTTTTL)
        {
            return db.ThuTraLoi_ChiTiets.Any(item => item.MaCTTTTL == MaCTTTTL);
        }

        public ThuTraLoi_ChiTiet GetCT(decimal MaCTTTTL)
        {
            return db.ThuTraLoi_ChiTiets.SingleOrDefault(itemCTTTTL => itemCTTTTL.MaCTTTTL == MaCTTTTL);
        }

        public DataTable GetDS()
        {
            return LINQToDataTable(db.ThuTraLoi_ChiTiets.ToList());
        }

        public DataTable GetDS(string To, decimal MaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from item in db.ThuTraLoi_ChiTiets
                                where item.ThuTraLoi.MaDon == MaDon
                                select new
                                {
                                    MaDon = "TKH" + item.ThuTraLoi.MaDon,
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
                    query = from item in db.ThuTraLoi_ChiTiets
                            where item.ThuTraLoi.MaDonTXL == MaDon
                            select new
                            {
                                MaDon = "TXL" + item.ThuTraLoi.MaDonTBC,
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
                    query = from item in db.ThuTraLoi_ChiTiets
                            where item.ThuTraLoi.MaDonTBC == MaDon
                            select new
                            {
                                MaDon = "TBC" + item.ThuTraLoi.MaDonTBC,
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
                    query = from item in db.ThuTraLoi_ChiTiets
                            where item.ThuTraLoi.MaDonMoi == MaDon
                            select new
                            {
                                MaDon =  item.ThuTraLoi.MaDonMoi.Value.ToString(),
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
            var query = from item in db.ThuTraLoi_ChiTiets
                        where item.MaCTTTTL == MaCTTTTL
                        select new
                        {
                            MaDon = item.ThuTraLoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuTraLoi.MaDonMoi).Count() == 1 ? item.ThuTraLoi.MaDonMoi.Value.ToString() : item.ThuTraLoi.MaDonMoi + "." + item.STT
                                : item.ThuTraLoi.MaDon != null ? "TKH" + item.ThuTraLoi.MaDon
                                : item.ThuTraLoi.MaDonTXL != null ? "TXL" + item.ThuTraLoi.MaDonTXL
                                : item.ThuTraLoi.MaDonTBC != null ? "TBC" + item.ThuTraLoi.MaDonTBC : null,
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
            var query = from item in db.ThuTraLoi_ChiTiets
                        where item.MaCTTTTL.ToString().Substring(item.MaCTTTTL.ToString().Length - 2, 2) == TuMaCTTTTL.ToString().Substring(TuMaCTTTTL.ToString().Length - 2, 2)
                                && item.MaCTTTTL.ToString().Substring(item.MaCTTTTL.ToString().Length - 2, 2) == DenMaCTTTTL.ToString().Substring(DenMaCTTTTL.ToString().Length - 2, 2)
                                && item.MaCTTTTL >= TuMaCTTTTL && item.MaCTTTTL <= DenMaCTTTTL
                        select new
                        {
                            MaDon = item.ThuTraLoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuTraLoi.MaDonMoi).Count() == 1 ? item.ThuTraLoi.MaDonMoi.Value.ToString() : item.ThuTraLoi.MaDonMoi + "." + item.STT
                                : item.ThuTraLoi.MaDon != null ? "TKH" + item.ThuTraLoi.MaDon
                                : item.ThuTraLoi.MaDonTXL != null ? "TXL" + item.ThuTraLoi.MaDonTXL
                                : item.ThuTraLoi.MaDonTBC != null ? "TBC" + item.ThuTraLoi.MaDonTBC : null,
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
            var query = from item in db.ThuTraLoi_ChiTiets
                        where item.DanhBo == DanhBo
                        select new
                        {
                            MaDon = item.ThuTraLoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuTraLoi.MaDonMoi).Count() == 1 ? item.ThuTraLoi.MaDonMoi.Value.ToString() : item.ThuTraLoi.MaDonMoi + "." + item.STT
                                : item.ThuTraLoi.MaDon != null ? "TKH" + item.ThuTraLoi.MaDon
                                : item.ThuTraLoi.MaDonTXL != null ? "TXL" + item.ThuTraLoi.MaDonTXL
                                : item.ThuTraLoi.MaDonTBC != null ? "TBC" + item.ThuTraLoi.MaDonTBC : null,
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
            var query = from item in db.ThuTraLoi_ChiTiets
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.ThuTraLoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuTraLoi.MaDonMoi).Count() == 1 ? item.ThuTraLoi.MaDonMoi.Value.ToString() : item.ThuTraLoi.MaDonMoi + "." + item.STT
                                : item.ThuTraLoi.MaDon != null ? "TKH" + item.ThuTraLoi.MaDon
                                : item.ThuTraLoi.MaDonTXL != null ? "TXL" + item.ThuTraLoi.MaDonTXL
                                : item.ThuTraLoi.MaDonTBC != null ? "TBC" + item.ThuTraLoi.MaDonTBC : null,
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
            var query = from item in db.ThuTraLoi_ChiTiets
                        where item.DanhBo == DanhBo
                        orderby item.CreateDate descending
                        select new
                        {
                            item.MaCTTTTL,
                            MaDon = item.ThuTraLoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuTraLoi.MaDonMoi).Count() == 1 ? item.ThuTraLoi.MaDonMoi.Value.ToString() : item.ThuTraLoi.MaDonMoi + "." + item.STT
                                : item.ThuTraLoi.MaDon != null ? "TKH" + item.ThuTraLoi.MaDon
                                : item.ThuTraLoi.MaDonTXL != null ? "TXL" + item.ThuTraLoi.MaDonTXL
                                : item.ThuTraLoi.MaDonTBC != null ? "TBC" + item.ThuTraLoi.MaDonTBC : null,
                            item.VeViec,
                        };
            return LINQToDataTable(query);
        }

        #endregion

        //MaDonMoi

        public bool checkExist(int MaDon)
        {
                    return db.ThuTraLois.Any(item => item.MaDonMoi == MaDon);
        }

        public bool checkExist_ChiTiet(int MaDon, string DanhBo, DateTime CreateDate)
        {
                    return db.ThuTraLoi_ChiTiets.Any(item => item.ThuTraLoi.MaDonMoi == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public LinQ.ThuTraLoi get(int MaDon)
        {
                    return db.ThuTraLois.SingleOrDefault(item => item.MaDonMoi == MaDon);
        }

        #region Hình

        public bool Them_Hinh(ThuTraLoi_ChiTiet_Hinh en)
        {
            try
            {
                if (db.ThuTraLoi_ChiTiet_Hinhs.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = db.ThuTraLoi_ChiTiet_Hinhs.Max(item => item.ID) + 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.ThuTraLoi_ChiTiet_Hinhs.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_Hinh(ThuTraLoi_ChiTiet_Hinh en)
        {
            try
            {
                db.ThuTraLoi_ChiTiet_Hinhs.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public ThuTraLoi_ChiTiet_Hinh get_Hinh(int ID)
        {
            return db.ThuTraLoi_ChiTiet_Hinhs.SingleOrDefault(item => item.ID == ID);
        }

        #endregion
    }
}

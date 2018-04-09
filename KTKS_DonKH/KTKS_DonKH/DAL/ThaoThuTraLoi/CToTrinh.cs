using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.ThaoThuTraLoi
{
    class CToTrinh:CDAL
    {
        #region ToTrinh (Tờ Trình)

        public bool Them(ToTrinh tt)
        {
            try
            {
                if (db.ToTrinhs.Count() > 0)
                {
                    string ID = "MaTT";
                    string Table = "ToTrinh";
                    decimal MaTT = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    tt.MaTT = getMaxNextIDTable(MaTT);
                }
                else
                    tt.MaTT = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                tt.CreateDate = DateTime.Now;
                tt.CreateBy = CTaiKhoan.MaUser;
                db.ToTrinhs.InsertOnSubmit(tt);
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

        public bool Sua(ToTrinh tt)
        {
            try
            {
                tt.ModifyDate = DateTime.Now;
                tt.ModifyBy = CTaiKhoan.MaUser;
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

        public ToTrinh Get(decimal MaTT)
        {
            return db.ToTrinhs.SingleOrDefault(itemTT => itemTT.MaTT == MaTT);
        }

        public ToTrinh Get(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.ToTrinhs.SingleOrDefault(item => item.MaDon == MaDon);
                case "TXL":
                    return db.ToTrinhs.SingleOrDefault(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.ToTrinhs.SingleOrDefault(item => item.MaDonTBC == MaDon);
                default:
                    return null;
            }
        }

        public bool CheckExist(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.ToTrinhs.Any(item => item.MaDon == MaDon);
                case "TXL":
                    return db.ToTrinhs.Any(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.ToTrinhs.Any(item => item.MaDonTBC == MaDon);
                default:
                    return false;
            }
        }

        #endregion

        #region CTToTrinh (Chi Tiết Tờ Trình)

        public bool ThemCT(CTToTrinh cttt)
        {
            try
            {
                if (db.CTToTrinhs.Count() > 0)
                {
                    string ID = "MaCTTT";
                    string Table = "CTToTrinh";
                    decimal MaCTTT = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    cttt.MaCTTT = getMaxNextIDTable(MaCTTT);
                }
                else
                    cttt.MaCTTT = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                cttt.CreateDate = DateTime.Now;
                cttt.CreateBy = CTaiKhoan.MaUser;
                db.CTToTrinhs.InsertOnSubmit(cttt);
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

        public bool SuaCT(CTToTrinh cttt)
        {
            try
            {
                cttt.ModifyDate = DateTime.Now;
                cttt.ModifyBy = CTaiKhoan.MaUser;
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

        public bool XoaCT(CTToTrinh cttt)
        {
            try
            {
                decimal ID = cttt.MaTT;
                db.CTToTrinhs.DeleteOnSubmit(cttt);
                if (db.CTToTrinhs.Any(item => item.MaTT == ID) == false)
                    db.ToTrinhs.DeleteOnSubmit(db.ToTrinhs.SingleOrDefault(item => item.MaTT == ID));
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

        public bool CheckExist_CT(decimal MaCTTT)
        {
            return db.CTToTrinhs.Any(item => item.MaCTTT == MaCTTT);
        }

        public bool CheckExist_CT(string Loai, decimal MaDon, string DanhBo, DateTime CreateDate)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.CTToTrinhs.Any(item => item.ToTrinh.MaDon == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
                case "TXL":
                    return db.CTToTrinhs.Any(item => item.ToTrinh.MaDonTXL == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
                case "TBC":
                    return db.CTToTrinhs.Any(item => item.ToTrinh.MaDonTBC == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
                default:
                    return false;
            }
        }

        public CTToTrinh GetCT(decimal MaCTTT)
        {
            return db.CTToTrinhs.SingleOrDefault(itemCTTT => itemCTTT.MaCTTT == MaCTTT);
        }

        public DataTable GetDS(decimal MaCTTT)
        {
            var query = from item in db.CTToTrinhs
                        where item.MaCTTT == MaCTTT
                        select new
                        {
                            MaDon = item.ToTrinh.MaDon != null ? "TKH" + item.ToTrinh.MaDon
                                : item.ToTrinh.MaDonTXL != null ? "TXL" + item.ToTrinh.MaDonTXL
                                : item.ToTrinh.MaDonTBC != null ? "TBC" + item.ToTrinh.MaDonTBC : null,
                            item.MaCTTT,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(string DanhBo)
        {
            var query = from item in db.CTToTrinhs
                        where item.DanhBo == DanhBo
                        select new
                        {
                            MaDon = item.ToTrinh.MaDon != null ? "TKH" + item.ToTrinh.MaDon
                                : item.ToTrinh.MaDonTXL != null ? "TXL" + item.ToTrinh.MaDonTXL
                                : item.ToTrinh.MaDonTBC != null ? "TBC" + item.ToTrinh.MaDonTBC : null,
                            item.MaCTTT,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime FromCreateDate,DateTime ToCreateDate)
        {
            var query = from item in db.CTToTrinhs
                        where item.CreateDate.Value.Date >=FromCreateDate.Date && item.CreateDate.Value.Date<=ToCreateDate.Date
                        select new
                        {
                            MaDon = item.ToTrinh.MaDon != null ? "TKH" + item.ToTrinh.MaDon
                                : item.ToTrinh.MaDonTXL != null ? "TXL" + item.ToTrinh.MaDonTXL
                                : item.ToTrinh.MaDonTBC != null ? "TBC" + item.ToTrinh.MaDonTBC : null,
                            item.MaCTTT,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.VeViec,
                            item.NoiDung,
                        };
            return LINQToDataTable(query);
        }

        #endregion
    }
}

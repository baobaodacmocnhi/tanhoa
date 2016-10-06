using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.ToXuLy
{
    class CTruyThuTienNuoc:CDAL
    {
        #region TruyThuTienNuoc

        public bool ThemTruyThuTienNuoc(TruyThuTienNuoc tttn)
        {
            try
            {
                    if (db.TruyThuTienNuocs.Count() > 0)
                    {
                        string ID = "MaTTTN";
                        string Table = "TruyThuTienNuoc";
                        decimal MaTTTN = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        tttn.MaTTTN = getMaxNextIDTable(MaTTTN);
                    }
                    else
                        tttn.MaTTTN = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    tttn.CreateDate = DateTime.Now;
                    tttn.CreateBy = CTaiKhoan.MaUser;
                    db.TruyThuTienNuocs.InsertOnSubmit(tttn);
                    db.SubmitChanges();
                    return true;
            }
            catch (Exception ex)
            {
                db = new DB_KTKS_DonKHDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SuaTruyThuTienNuoc(TruyThuTienNuoc tttn)
        {
            try
            {
                    tttn.ModifyDate = DateTime.Now;
                    tttn.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    return true;
            }
            catch (Exception ex)
            {
                db = new DB_KTKS_DonKHDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaTruyThuTienNuoc(TruyThuTienNuoc tttn)
        {
            try
            {
                    db.CTTruyThuTienNuocs.DeleteAllOnSubmit(tttn.CTTruyThuTienNuocs.ToList());
                    db.ThanhToanTruyThuTienNuocs.DeleteAllOnSubmit(tttn.ThanhToanTruyThuTienNuocs.ToList());
                    db.TruyThuTienNuocs.DeleteOnSubmit(tttn);
                    db.SubmitChanges();
                    return true;
            }
            catch (Exception ex)
            {
                db = new DB_KTKS_DonKHDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckTruyThuTienNuocbyMaDon(decimal MaDon)
        {
            try
            {
                if (db.TruyThuTienNuocs.Any(item => item.MaDon == MaDon))
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

        public bool CheckTruyThuTienNuocbyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                if (db.TruyThuTienNuocs.Any(item => item.MaDonTXL == MaDonTXL))
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

        public TruyThuTienNuoc getTruyThuTienNuocbyMaDon(decimal MaDon)
        {
            try
            {
                return db.TruyThuTienNuocs.SingleOrDefault(item => item.MaDon == MaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public TruyThuTienNuoc getTruyThuTienNuocbyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                return db.TruyThuTienNuocs.SingleOrDefault(item => item.MaDonTXL == MaDonTXL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public TruyThuTienNuoc getTruyThuTienNuocbyMaTTTN(decimal MaTTTN)
        {
            try
            {
                return db.TruyThuTienNuocs.SingleOrDefault(item => item.MaTTTN == MaTTTN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public List<TruyThuTienNuoc> LoadDSTruyThuTienNuocbySoPhieu(decimal SoPhieu)
        {
            return db.TruyThuTienNuocs.Where(item => item.MaTTTN == SoPhieu).ToList();
        }

        public List<TruyThuTienNuoc> LoadDSTruyThuTienNuocbyDanhBo(string DanhBo)
        {
            return db.TruyThuTienNuocs.Where(item => item.DanhBo == DanhBo).ToList();
        }

        public List<TruyThuTienNuoc> LoadDSTruyThuTienNuocbyCreateDate(DateTime TuNgay)
        {
            return db.TruyThuTienNuocs.Where(item => item.CreateDate.Value.Date == TuNgay.Date).ToList();
        }

        public List<TruyThuTienNuoc> LoadDSTruyThuTienNuocbyCreateDates(DateTime TuNgay, DateTime DenNgay)
        {
            return db.TruyThuTienNuocs.Where(item => item.CreateDate.Value.Date >= TuNgay.Date && item.CreateDate.Value.Date <= DenNgay.Date).ToList();
        }

        #endregion

        #region CTTruyThuTienNuoc

        public bool ThemCTTruyThuTienNuoc(CTTruyThuTienNuoc cttttn)
        {
            try
            {
                    if (db.CTTruyThuTienNuocs.Count() > 0)
                    {
                        cttttn.MaCTTTTN = db.CTTruyThuTienNuocs.Max(item => item.MaCTTTTN) + 1;
                    }
                    else
                        cttttn.MaCTTTTN = 1;
                    cttttn.CreateDate = DateTime.Now;
                    cttttn.CreateBy = CTaiKhoan.MaUser;
                    db.CTTruyThuTienNuocs.InsertOnSubmit(cttttn);
                    db.SubmitChanges();
                    return true;
            }
            catch (Exception ex)
            {
                db = new DB_KTKS_DonKHDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SuaCTTruyThuTienNuoc(CTTruyThuTienNuoc cttttn)
        {
            try
            {
                    cttttn.ModifyDate = DateTime.Now;
                    cttttn.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    return true;
            }
            catch (Exception ex)
            {
                db = new DB_KTKS_DonKHDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaCTTruyThuTienNuoc(CTTruyThuTienNuoc cttttn)
        {
            try
            {
                    db.CTTruyThuTienNuocs.DeleteOnSubmit(cttttn);
                    db.SubmitChanges();
                    return true;
            }
            catch (Exception ex)
            {
                db = new DB_KTKS_DonKHDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public CTTruyThuTienNuoc getCTTruyThuTienNuocbyMaCTTTTN(decimal MaCTTTTN)
        {
            try
            {
                return db.CTTruyThuTienNuocs.SingleOrDefault(item => item.MaCTTTTN == MaCTTTTN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public bool CheckCTTruyThuTienNuocbyKyNamMaTTTN(decimal MaTTTN, string Ky, string Nam)
        {
            return db.CTTruyThuTienNuocs.Any(item => item.MaTTTN == MaTTTN && item.Ky == Ky && item.Nam == Nam);
        }

        #endregion

        #region ThanhToanTruyThuTienNuoc

        public bool ThemThanhToanTruyThuTienNuoc(ThanhToanTruyThuTienNuoc tttttn)
        {
            try
            {
                    if (db.ThanhToanTruyThuTienNuocs.Count() > 0)
                    {
                        tttttn.MaTTTTTN = db.ThanhToanTruyThuTienNuocs.Max(item => item.MaTTTTTN) + 1;
                    }
                    else
                        tttttn.MaTTTTTN = 1;
                    tttttn.CreateDate = DateTime.Now;
                    tttttn.CreateBy = CTaiKhoan.MaUser;
                    db.ThanhToanTruyThuTienNuocs.InsertOnSubmit(tttttn);
                    db.SubmitChanges();
                    return true;
            }
            catch (Exception ex)
            {
                db = new DB_KTKS_DonKHDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SuaThanhToanTruyThuTienNuoc(ThanhToanTruyThuTienNuoc tttttn)
        {
            try
            {
                    tttttn.ModifyDate = DateTime.Now;
                    tttttn.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    return true;
            }
            catch (Exception ex)
            {
                db = new DB_KTKS_DonKHDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaThanhToanTruyThuTienNuoc(ThanhToanTruyThuTienNuoc tttttn)
        {
            try
            {
                    db.ThanhToanTruyThuTienNuocs.DeleteOnSubmit(tttttn);
                    db.SubmitChanges();
                    return true;
            }
            catch (Exception ex)
            {
                db = new DB_KTKS_DonKHDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public ThanhToanTruyThuTienNuoc getThanhToanTruyThuTienNuocbyMaTTTTTN(decimal MaTTTTTN)
        {
            try
            {
                return db.ThanhToanTruyThuTienNuocs.SingleOrDefault(item => item.MaTTTTTN == MaTTTTTN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        #endregion

        public int CountTongTienThanhToan(decimal MaTTTN)
        {
            try
            {
                if (db.CTTruyThuTienNuocs.Any(item => item.MaTTTN == MaTTTN))
                    return db.CTTruyThuTienNuocs.Where(item => item.MaTTTN == MaTTTN).Sum(item => item.TongCongMoi).Value - db.CTTruyThuTienNuocs.Where(item => item.MaTTTN == MaTTTN).Sum(item => item.TongCongCu).Value;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int CountTongm3(decimal MaTTTN)
        {
            try
            {
                if (db.CTTruyThuTienNuocs.Any(item => item.MaTTTN == MaTTTN))
                    return (db.CTTruyThuTienNuocs.Where(item => item.MaTTTN == MaTTTN).Sum(item => item.TongCongMoi).Value - db.CTTruyThuTienNuocs.Where(item => item.MaTTTN == MaTTTN).Sum(item => item.TongCongCu).Value) / 8546;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}

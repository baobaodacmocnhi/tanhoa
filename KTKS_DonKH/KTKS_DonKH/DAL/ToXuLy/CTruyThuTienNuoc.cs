using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;
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
                if (CTaiKhoan.RoleTruyThuTienNuoc_CapNhat)
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
                else
                {
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.TruyThuTienNuocs);
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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
                if (CTaiKhoan.RoleTruyThuTienNuoc_CapNhat)
                {
                    tttn.ModifyDate = DateTime.Now;
                    tttn.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.TruyThuTienNuocs);
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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
                if (CTaiKhoan.RoleTruyThuTienNuoc_CapNhat)
                {
                    db.TruyThuTienNuocs.DeleteOnSubmit(tttn);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.TruyThuTienNuocs);
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                db = new DB_KTKS_DonKHDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region CTTruyThuTienNuoc

        public bool ThemCTTruyThuTienNuoc(CTTruyThuTienNuoc cttttn)
        {
            try
            {
                if (CTaiKhoan.RoleTruyThuTienNuoc_CapNhat)
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
                else
                {
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTTruyThuTienNuocs);
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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
                if (CTaiKhoan.RoleTruyThuTienNuoc_CapNhat)
                {
                    cttttn.ModifyDate = DateTime.Now;
                    cttttn.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTTruyThuTienNuocs);
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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
                if (CTaiKhoan.RoleTruyThuTienNuoc_CapNhat)
                {
                    db.CTTruyThuTienNuocs.DeleteOnSubmit(cttttn);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTTruyThuTienNuocs);
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                db = new DB_KTKS_DonKHDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region ThanhToanTruyThuTienNuoc

        public bool ThemThanhToanTruyThuTienNuoc(ThanhToanTruyThuTienNuoc tttttn)
        {
            try
            {
                if (CTaiKhoan.RoleTruyThuTienNuoc_CapNhat)
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
                else
                {
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ThanhToanTruyThuTienNuocs);
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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
                if (CTaiKhoan.RoleTruyThuTienNuoc_CapNhat)
                {
                    tttttn.ModifyDate = DateTime.Now;
                    tttttn.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ThanhToanTruyThuTienNuocs);
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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
                if (CTaiKhoan.RoleTruyThuTienNuoc_CapNhat)
                {
                    db.ThanhToanTruyThuTienNuocs.DeleteOnSubmit(tttttn);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ThanhToanTruyThuTienNuocs);
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                db = new DB_KTKS_DonKHDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion
    }
}

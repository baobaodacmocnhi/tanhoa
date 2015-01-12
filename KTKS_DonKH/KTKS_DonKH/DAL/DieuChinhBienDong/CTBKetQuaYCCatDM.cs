using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.DieuChinhBienDong
{
    class CTBKetQuaYCCatDM:CDAL
    {
        public bool ThemTBKetQuaYCCatDM(TBKetQuaYCCatDM tb)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD_CapNhat)
                {
                    if (db.TBKetQuaYCCatDMs.Count() > 0)
                    {
                        string ID = "SoPhieu";
                        string Table = "TBKetQuaYCCatDM";
                        decimal SoPhieu = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //decimal MaDCBD = db.DCBDs.Max(itemDCBD => itemDCBD.MaDCBD);
                        tb.SoPhieu = getMaxNextIDTable(SoPhieu);
                    }
                    else
                        tb.SoPhieu = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    tb.CreateDate = DateTime.Now;
                    tb.CreateBy = CTaiKhoan.MaUser;
                    db.TBKetQuaYCCatDMs.InsertOnSubmit(tb);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm DCBD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.TBKetQuaYCCatDMs);
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

        public bool SuaTBKetQuaYCCatDM(TBKetQuaYCCatDM tb)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD_CapNhat)
                {
                    tb.ModifyDate = DateTime.Now;
                    tb.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa DCBD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.TBKetQuaYCCatDMs);
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

        public bool XoaTBKetQuaYCCatDM(TBKetQuaYCCatDM tb)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD_CapNhat)
                {
                    db.TBKetQuaYCCatDMs.DeleteOnSubmit(tb);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa DCBD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.TBKetQuaYCCatDMs);
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

        public List<TBKetQuaYCCatDM> LoadDSTBKetQuaYCCatDM()
        {
            try
            {
                if (CTaiKhoan.RoleDCBD_Xem || CTaiKhoan.RoleDCBD_CapNhat)
                {
                    return db.TBKetQuaYCCatDMs.OrderByDescending(item=>item.CreateDate).ToList();
                }
                else
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public TBKetQuaYCCatDM GetTBKetQuaYCCatDMByID(decimal SoPhieu)
        {
            try
            {
                return db.TBKetQuaYCCatDMs.SingleOrDefault(item => item.SoPhieu == SoPhieu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

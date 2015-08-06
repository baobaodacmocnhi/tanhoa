using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;

namespace ThuTien.DAL.Doi
{
    class CToTrinhCatHuy:CDAL
    {
        public bool ThemTT(TT_ToTrinhCatHuy totrinh)
        {
            try
            {
                if (_db.TT_ToTrinhCatHuys.Count() > 0)
                {
                    string ID = "MaTT";
                    string Table = "TT_ToTrinhCatHuy";
                    decimal MaTT = _db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    //decimal MaCHDB = db.CHDBs.Max(itemCHDB => itemCHDB.MaCHDB);
                    totrinh.MaTT = getMaxNextIDTable(MaTT);
                }
                else
                    totrinh.MaTT = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                totrinh.CreateDate = DateTime.Now;
                totrinh.CreateBy = CNguoiDung.MaND;
                _db.TT_ToTrinhCatHuys.InsertOnSubmit(totrinh);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaTT(TT_ToTrinhCatHuy totrinh)
        {
            try
            {
                _db.TT_ToTrinhCatHuys.DeleteOnSubmit(totrinh);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public List<TT_ToTrinhCatHuy> GetDSTT()
        {
           return _db.TT_ToTrinhCatHuys.ToList();
        }

        public TT_ToTrinhCatHuy GetTT(decimal MaTT)
        {
            return _db.TT_ToTrinhCatHuys.SingleOrDefault(item => item.MaTT == MaTT);
        }

        #region CT Tờ Trình

        public bool SuaCTTT(TT_CTToTrinhCatHuy cttotrinh)
        {
            try
            {
                cttotrinh.ModifyDate = DateTime.Now;
                cttotrinh.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaCT(TT_CTToTrinhCatHuy cttotrinh)
        {
            try
            {
                _db.TT_CTToTrinhCatHuys.DeleteOnSubmit(cttotrinh);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public List<TT_CTToTrinhCatHuy> GetDSCTTT(decimal MaTT)
        {
            return _db.TT_CTToTrinhCatHuys.Where(item=>item.MaTT==MaTT).ToList();
        }

        public TT_CTToTrinhCatHuy GetCT(int MaCTTT)
        {
            return _db.TT_CTToTrinhCatHuys.SingleOrDefault(item => item.MaCTTT == MaCTTT);
        }

        public int GetMaxMaCTTT()
        {
            if (_db.TT_CTToTrinhCatHuys.Count()==0)
                return 0;
            else
                return _db.TT_CTToTrinhCatHuys.Max(item => item.MaCTTT);
        }

        public int CountCTTT(decimal MaTT)
        {
            return _db.TT_CTToTrinhCatHuys.Count(item => item.MaTT == MaTT);
        }

        #endregion
    }
}

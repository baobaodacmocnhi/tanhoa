using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.ChuyenKhoan
{
    class CPhiMoNuoc:CDAL
    {
        public bool Them(TT_PhiMoNuoc phimonuoc)
        {
            try
            {
                if (_db.TT_PhiMoNuocs.Count() > 0)
                {
                    string ID = "MaPMN";
                    string Table = "TT_TT_PhiMoNuoc";
                    decimal MaTT = _db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    //decimal MaCHDB = db.CHDBs.Max(itemCHDB => itemCHDB.MaCHDB);
                    phimonuoc.MaPMN = getMaxNextIDTable(MaTT);
                }
                else
                    phimonuoc.MaPMN = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                phimonuoc.CreateDate = DateTime.Now;
                phimonuoc.CreateBy = CNguoiDung.MaND;
                _db.TT_PhiMoNuocs.InsertOnSubmit(phimonuoc);
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

        public bool Sua(TT_PhiMoNuoc phimonuoc)
        {
            try
            {
                phimonuoc.ModifyDate = DateTime.Now;
                phimonuoc.ModifyBy = CNguoiDung.MaND;
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

        public bool Xoa(TT_PhiMoNuoc phimonuoc)
        {
            try
            {
                _db.TT_PhiMoNuocs.DeleteOnSubmit(phimonuoc);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public TT_PhiMoNuoc Get(decimal MaPMN)
        {
            return _db.TT_PhiMoNuocs.SingleOrDefault(item => item.MaPMN == MaPMN);
        }

        public DataTable GetDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(_db.TT_PhiMoNuocs.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date).ToList());
        }
    }
}

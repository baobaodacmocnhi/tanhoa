using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;

namespace ThuTien.DAL.Quay
{
    class CTraGop : CDAL
    {
        public bool Them(TT_TraGop tragop)
        {
            try
            {
                if (_db.TT_TraGops.Count() > 0)
                {
                    string ID = "MaTG";
                    string Table = "TT_TraGop";
                    decimal MaTG = _db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    //decimal MaDCBD = db.DCBDs.Max(itemDCBD => itemDCBD.MaDCBD);
                    tragop.MaTG = getMaxNextIDTable(MaTG);
                }
                else
                    tragop.MaTG = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                tragop.CreateDate = DateTime.Now;
                tragop.CreateBy = CNguoiDung.MaND;
                _db.TT_TraGops.InsertOnSubmit(tragop);
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

        public bool Sua(TT_TraGop tragop)
        {
            try
            {
                tragop.ModifyDate = DateTime.Now;
                tragop.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(TT_TraGop tragop)
        {
            try
            {
                _db.TT_TraGops.DeleteOnSubmit(tragop);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public decimal GetNextSoPhieu()
        {
            if (_db.TT_TraGops.Max(item => item.SoPhieu) == null)
                return decimal.Parse("1" + DateTime.Now.ToString("yy"));
            else
            {
                string ID = "SoPhieu";
                string Table = "TT_TraGop";
                decimal SoPhieu = _db.ExecuteQuery<decimal>("declare @Ma int " +
                    "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                    "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                return getMaxNextIDTable(SoPhieu);
            }
        }

        public List<TT_TraGop> GetDSBySoHoaDon(string SoHoaDon)
        {
            return _db.TT_TraGops.Where(item => item.SoHoaDon == SoHoaDon).ToList();
        }

        public System.Data.DataTable GetDS()
        {
            return ExecuteQuery_SqlDataAdapter_DataTable("select distinct tg.SoHoaDon,SOPHATHANH,CAST(hd.KY as varchar)+'/'+CAST(hd.NAM as varchar) as Ky,DANHBA as DanhBo,hd.TENKH as HoTen,(hd.SO+' '+hd.DUONG) as DiaChi,MALOTRINH as MLT,TONGCONG from TT_TraGop tg,HOADON hd where tg.SoHoaDon=hd.SOHOADON");
        }
        public TT_TraGop GetByMaTG(int MaTG)
        {
            return _db.TT_TraGops.SingleOrDefault(item => item.MaTG == MaTG);
        }
    }
}

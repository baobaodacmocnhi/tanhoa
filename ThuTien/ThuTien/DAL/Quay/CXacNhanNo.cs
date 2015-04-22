using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;

namespace ThuTien.DAL.Quay
{
    class CXacNhanNo:CDAL
    {
        public bool Them(TT_XacNhanNo xacnhanno)
        {
            try
            {
                if (_db.TT_XacNhanNos.Count() > 0)
                {
                    string ID = "SoPhieu";
                    string Table = "TT_XacNhanNo";
                    decimal SoPhieu = _db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    //decimal MaDCBD = db.DCBDs.Max(itemDCBD => itemDCBD.MaDCBD);
                    xacnhanno.SoPhieu = getMaxNextIDTable(SoPhieu);
                }
                else
                    xacnhanno.SoPhieu = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                xacnhanno.CreateDate = DateTime.Now;
                xacnhanno.CreateBy = CNguoiDung.MaND;
                _db.TT_XacNhanNos.InsertOnSubmit(xacnhanno);
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

        public bool Sua(TT_XacNhanNo xacnhanno)
        {
            try
            {
                xacnhanno.ModifyDate = DateTime.Now;
                xacnhanno.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(TT_XacNhanNo xacnhanno)
        {
            try
            {
                _db.TT_XacNhanNos.DeleteOnSubmit(xacnhanno);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public TT_XacNhanNo GetBySoPhieu(decimal SoPhieu)
        {
            return _db.TT_XacNhanNos.SingleOrDefault(item => item.SoPhieu == SoPhieu);
        }

        public List<TT_XacNhanNo> GetDSByDates(int MaNV, DateTime TuNgay, DateTime DenNgay)
        {
            return _db.TT_XacNhanNos.Where(item => item.CreateBy == MaNV && item.CreateDate.Value.Date >= TuNgay.Date && item.CreateDate.Value.Date <= DenNgay.Date).ToList();
        }

        public bool CheckExistByDanhBoKy(string DanhBo, string Ky)
        {
            return _db.TT_XacNhanNos.Any(item => item.DanhBo == DanhBo && item.Ky == Ky);
        }
    }
}

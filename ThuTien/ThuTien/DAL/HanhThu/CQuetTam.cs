using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.HanhThu
{
    class CQuetTam:CDAL
    {
        public DataTable GetDSByMaNVCreatedDate(int MaNV, DateTime CreatedDate)
        {
            var query = from itemQT in _db.TT_QuetTams
                        join itemHD in _db.HOADONs on itemQT.SoHoaDon equals itemHD.SOHOADON
                        where itemQT.CreateDate.Value.Date == CreatedDate.Date && itemQT.CreateBy == MaNV
                        select new
                        {
                            itemQT.MaQT,
                            itemQT.SoHoaDon,
                            DanhBo=itemHD.DANHBA,
                            Ky=itemHD.KY+"/"+itemHD.NAM,
                            MLT=itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                        };
            return LINQToDataTable(query);
        }

        public bool Them(TT_QuetTam quettam)
        {
            try
            {
                if (_db.TT_QuetTams.Count() > 0)
                    quettam.MaQT = _db.TT_QuetTams.Max(item => item.MaQT) + 1;
                else
                    quettam.MaQT = 1;
                quettam.CreateDate = DateTime.Now;
                quettam.CreateBy = CNguoiDung.MaND;
                _db.TT_QuetTams.InsertOnSubmit(quettam);
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

        public bool Xoa(TT_QuetTam quettam)
        {
            try
            {
                _db.TT_QuetTams.DeleteOnSubmit(quettam);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public TT_QuetTam GetByMaQT(int MaQT)
        {
            return _db.TT_QuetTams.SingleOrDefault(item => item.MaQT == MaQT);
        }
    }
}

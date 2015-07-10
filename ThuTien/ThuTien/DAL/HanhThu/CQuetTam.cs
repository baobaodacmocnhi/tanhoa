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
        public bool Them(TT_QuetTam quettam)
        {
            try
            {
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

        public bool CheckExistByID(string SoHoaDon, int CreatBy)
        {
            return _db.TT_QuetTams.Any(item => item.SoHoaDon == SoHoaDon && item.CreateBy == CreatBy);
        }

        public TT_QuetTam GetByID(string SoHoaDon,int CreatBy)
        {
            return _db.TT_QuetTams.SingleOrDefault(item => item.SoHoaDon == SoHoaDon&&item.CreateBy==CreatBy);
        }

        public TT_QuetTam GetBySoHoaDon(string SoHoaDon)
        {
            return _db.TT_QuetTams.SingleOrDefault(item => item.SoHoaDon == SoHoaDon);
        }

        public DataTable GetDSByMaNVCreatedDate(string Loai, int MaNV, DateTime CreatedDate)
        {
            if (Loai == "TG")
            {
                var query = from itemQT in _db.TT_QuetTams
                            join itemHD in _db.HOADONs on itemQT.SoHoaDon equals itemHD.SOHOADON
                            where itemQT.CreateDate.Value.Date == CreatedDate.Date && itemQT.CreateBy == MaNV && itemHD.GB >= 11 && itemHD.GB <= 20
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                itemQT.CreateBy,
                                itemQT.SoHoaDon,
                                DanhBo = itemHD.DANHBA,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                MLT = itemHD.MALOTRINH,
                                itemHD.SOPHATHANH,
                                itemHD.TONGCONG,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemQT in _db.TT_QuetTams
                                join itemHD in _db.HOADONs on itemQT.SoHoaDon equals itemHD.SOHOADON
                                where itemQT.CreateDate.Value.Date == CreatedDate.Date && itemQT.CreateBy == MaNV && itemHD.GB > 20
                                orderby itemHD.MALOTRINH ascending
                                select new
                                {
                                    itemQT.CreateBy,
                                    itemQT.SoHoaDon,
                                    DanhBo = itemHD.DANHBA,
                                    Ky = itemHD.KY + "/" + itemHD.NAM,
                                    MLT = itemHD.MALOTRINH,
                                    itemHD.SOPHATHANH,
                                    itemHD.TONGCONG,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }
    }
}

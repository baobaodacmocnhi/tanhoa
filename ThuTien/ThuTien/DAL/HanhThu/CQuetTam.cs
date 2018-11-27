using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.HanhThu
{
    class CQuetTam : CDAL
    {
        public bool Them(TT_QuetTam quettam)
        {
            try
            {
                if (_db.TT_QuetTams.Count() > 0)
                    quettam.ID = _db.TT_QuetTams.Max(item => item.ID) + 1;
                else
                    quettam.ID = 1;
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

        public bool CheckExist(string SoHoaDon, int CreatBy, DateTime CreateDate)
        {
            return _db.TT_QuetTams.Any(item => item.SoHoaDon == SoHoaDon && item.CreateBy == CreatBy && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public TT_QuetTam Get(int ID)
        {
            return _db.TT_QuetTams.SingleOrDefault(item => item.ID == ID);
        }

        public TT_QuetTam Get(string SoHoaDon)
        {
            return _db.TT_QuetTams.SingleOrDefault(item => item.SoHoaDon == SoHoaDon);
        }

        public DataTable GetDSByMaNVCreatedDate(string Loai, int MaNV, DateTime CreatedDate)
        {
            if (Loai == "TG")
            {
                var query = from itemQT in _db.TT_QuetTams
                            join itemHD in _db.HOADONs on itemQT.MaHD equals itemHD.ID_HOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemQT.CreateDate.Value.Date == CreatedDate.Date && itemQT.CreateBy == MaNV && itemHD.GB >= 11 && itemHD.GB <= 20
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                itemQT.ID,
                                itemQT.CreateBy,
                                itemQT.SoHoaDon,
                                itemQT.SoPhieu,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                MLT = itemHD.MALOTRINH,
                                itemHD.SOPHATHANH,
                                itemHD.TONGCONG,
                                GiaBieu = itemHD.GB,
                                HanhThu = itemtableND.HoTen,
                                To = itemtableND.TT_To.TenTo,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemQT in _db.TT_QuetTams
                                join itemHD in _db.HOADONs on itemQT.SoHoaDon equals itemHD.SOHOADON
                                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemQT.CreateDate.Value.Date == CreatedDate.Date && itemQT.CreateBy == MaNV && itemHD.GB > 20
                                orderby itemHD.MALOTRINH ascending
                                select new
                                {
                                    itemQT.ID,
                                    itemQT.CreateBy,
                                    itemQT.SoHoaDon,
                                    itemQT.SoPhieu,
                                    DanhBo = itemHD.DANHBA,
                                    HoTen = itemHD.TENKH,
                                    DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                    Ky = itemHD.KY + "/" + itemHD.NAM,
                                    MLT = itemHD.MALOTRINH,
                                    itemHD.SOPHATHANH,
                                    itemHD.TONGCONG,
                                    GiaBieu = itemHD.GB,
                                    HanhThu = itemtableND.HoTen,
                                    To = itemtableND.TT_To.TenTo,
                                };
                    return LINQToDataTable(query);
                }
            return null;
        }

        public DataTable GetDSByMaNVCreatedDate(string Loai, int MaNV)
        {
            if (Loai == "TG")
            {
                var query = from itemQT in _db.TT_QuetTams
                            join itemHD in _db.HOADONs on itemQT.MaHD equals itemHD.ID_HOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemQT.CreateBy == MaNV && itemHD.GB >= 11 && itemHD.GB <= 20
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                itemQT.ID,
                                itemQT.CreateBy,
                                itemQT.SoHoaDon,
                                itemQT.SoPhieu,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                MLT = itemHD.MALOTRINH,
                                itemHD.SOPHATHANH,
                                itemHD.TONGCONG,
                                GiaBieu = itemHD.GB,
                                itemHD.HOPDONG,
                                HanhThu = itemtableND.HoTen,
                                To = itemtableND.TT_To.TenTo,
                                itemHD.NGAYGIAITRACH,
                            };
                return LINQToDataTable(query);
            }
            else
                if (Loai == "CQ")
                {
                    var query = from itemQT in _db.TT_QuetTams
                                join itemHD in _db.HOADONs on itemQT.SoHoaDon equals itemHD.SOHOADON
                                join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemQT.CreateBy == MaNV && itemHD.GB > 20
                                orderby itemHD.MALOTRINH ascending
                                select new
                                {
                                    itemQT.ID,
                                    itemQT.CreateBy,
                                    itemQT.SoHoaDon,
                                    itemQT.SoPhieu,
                                    DanhBo = itemHD.DANHBA,
                                    HoTen = itemHD.TENKH,
                                    DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                    Ky = itemHD.KY + "/" + itemHD.NAM,
                                    MLT = itemHD.MALOTRINH,
                                    itemHD.SOPHATHANH,
                                    itemHD.TONGCONG,
                                    GiaBieu = itemHD.GB,
                                    itemHD.HOPDONG,
                                    HanhThu = itemtableND.HoTen,
                                    To = itemtableND.TT_To.TenTo,
                                    itemHD.NGAYGIAITRACH,
                                };
                    return LINQToDataTable(query);
                }
                else
                    if (Loai == "")
                    {
                        var query = from itemQT in _db.TT_QuetTams
                                    join itemHD in _db.HOADONs on itemQT.SoHoaDon equals itemHD.SOHOADON
                                    join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                                    from itemtableND in tableND.DefaultIfEmpty()
                                    where itemQT.CreateBy == MaNV
                                    orderby itemHD.MALOTRINH ascending
                                    select new
                                    {
                                        itemQT.ID,
                                        itemQT.CreateBy,
                                        itemQT.SoHoaDon,
                                        itemQT.SoPhieu,
                                        DanhBo = itemHD.DANHBA,
                                        HoTen = itemHD.TENKH,
                                        DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                        Ky = itemHD.KY + "/" + itemHD.NAM,
                                        MLT = itemHD.MALOTRINH,
                                        itemHD.SOPHATHANH,
                                        itemHD.TONGCONG,
                                        GiaBieu = itemHD.GB,
                                        itemHD.HOPDONG,
                                        HanhThu = itemtableND.HoTen,
                                        To = itemtableND.TT_To.TenTo,
                                        itemHD.NGAYGIAITRACH,
                                    };
                        return LINQToDataTable(query);
                    }
            return null;
        }

        public DataTable GetDSByMaNVCreatedDate(int MaNV, DateTime CreatedDate)
        {
            var query = from itemQT in _db.TT_QuetTams
                        join itemHD in _db.HOADONs on itemQT.MaHD equals itemHD.ID_HOADON
                        where itemQT.CreateDate.Value.Date == CreatedDate.Date && itemQT.CreateBy == MaNV
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                        };
            return LINQToDataTable(query);
        }

        public int GetNextSoPhieu()
        {
            if (_db.TT_QuetTams.Max(item => item.SoPhieu) == null)
                return int.Parse("1" + DateTime.Now.ToString("yy"));
            else
            {
                string ID = "SoPhieu";
                string Table = "TT_QuetTam";
                decimal SoPhieu = _db.ExecuteQuery<int>("declare @Ma int " +
                    "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                    "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                return (int)getMaxNextIDTable(SoPhieu);
            }
        }
    }
}

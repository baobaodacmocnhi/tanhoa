using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using System.Data;
using ThuTien.DAL.QuanTri;

namespace ThuTien.DAL.TongHop
{
    class CChuyenNoKhoDoi : CDAL
    {
        public bool Them(TT_ChuyenNoKhoDoi cnkd)
        {
            try
            {
                cnkd.CreateDate = DateTime.Now;
                cnkd.CreateBy = CNguoiDung.MaND;
                _db.TT_ChuyenNoKhoDois.InsertOnSubmit(cnkd);
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

        public bool Xoa(TT_ChuyenNoKhoDoi cnkd)
        {
            try
            {
                _db.TT_ChuyenNoKhoDois.DeleteOnSubmit(cnkd);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(string SoHoaDon)
        {
            try
            {
                string sql = "";
                sql = "delete TT_ChuyenNoKhoDoi where SoHoaDon='" + SoHoaDon + "'";
                return ExecuteNonQuery_Transaction(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(string SoHoaDon)
        {
            return _db.TT_ChuyenNoKhoDois.Any(item => item.SoHoaDon == SoHoaDon);
        }

        public TT_ChuyenNoKhoDoi GetBySoHoaDon(string SoHoaDon)
        {
            return _db.TT_ChuyenNoKhoDois.SingleOrDefault(item => item.SoHoaDon == SoHoaDon);
        }

        public DataTable GetDSByCreatedDate(DateTime TuNgay)
        {
            var query = from itemCNKD in _db.TT_ChuyenNoKhoDois
                        join itemHD in _db.HOADONs on itemCNKD.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemCNKD.CreateDate.Value.Date == TuNgay.Date
                        select new
                        {
                            itemCNKD.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSByCreatedDates(DateTime TuNgay, DateTime DenNgay)
        {
            var query = from itemCNKD in _db.TT_ChuyenNoKhoDois
                        join itemHD in _db.HOADONs on itemCNKD.SoHoaDon equals itemHD.SOHOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemCNKD.CreateDate.Value.Date >= TuNgay.Date && itemCNKD.CreateDate.Value.Date <= DenNgay.Date
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemCNKD.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetTongHopDangNgan(string Loai, DateTime CreateDate)
        {
            if (Loai == "TG")
            {
                //var query = from itemCNKD in _db.TT_ChuyenNoKhoDois
                //            join itemHD in _db.HOADONs on itemCNKD.SoHoaDon equals itemHD.SOHOADON
                //            where itemCNKD.CreateDate.Value.Date == CreateDate.Date && itemHD.GB >= 11 && itemHD.GB <= 20
                //            group itemHD by itemHD.ID_HOADON into itemGroup
                //            select new
                //            {
                //                TongHD = itemGroup.Count(),
                //                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                //                TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                //                TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                //            };
                //return LINQToDataTable(query);

                string sql = "select COUNT(a.SoHoaDon) as TongHD,SUM(GIABAN) as TongGiaBan,SUM(THUE) as TongThueGTGT,SUM(PHI) as TongPhiBVMT from TT_ChuyenNoKhoDoi a,HOADON b"
                        + " where a.SoHoaDon=b.SOHOADON and GB>=11 and GB<=20 and CONVERT(varchar(10),a.CreateDate,103)='" + CreateDate.ToString("dd/MM/yyyy") + "'"
                        + " group by CONVERT(varchar(10),a.CreateDate,103)";

                return ExecuteQuery_SqlDataAdapter_DataTable(sql);
            }
            else
                if (Loai == "CQ")
                {
                    //var query = from itemCNKD in _db.TT_ChuyenNoKhoDois
                    //            join itemHD in _db.HOADONs on itemCNKD.SoHoaDon equals itemHD.SOHOADON
                    //            where itemCNKD.CreateDate.Value.Date == CreateDate.Date && itemHD.GB > 20
                    //            group itemHD by itemHD.ID_HOADON into itemGroup
                    //            select new
                    //            {
                    //                TongHD = itemGroup.Count(),
                    //                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
                    //                TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
                    //                TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
                    //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
                    //            };
                    //return LINQToDataTable(query);

                    string sql = "select COUNT(a.SoHoaDon) as TongHD,SUM(GIABAN) as TongGiaBan,SUM(THUE) as TongThueGTGT,SUM(PHI) as TongPhiBVMT from TT_ChuyenNoKhoDoi a,HOADON b"
                        + " where a.SoHoaDon=b.SOHOADON and GB>20 and CONVERT(varchar(10),a.CreateDate,103)='" + CreateDate.ToString("dd/MM/yyyy") + "'"
                        + " group by CONVERT(varchar(10),a.CreateDate,103)";

                    return ExecuteQuery_SqlDataAdapter_DataTable(sql);
                }
            return null;
        }

        public DataTable GetTongHopDangNgan(DateTime CreateDate)
        {
            //var query = from itemCNKD in _db.TT_ChuyenNoKhoDois
            //            join itemHD in _db.HOADONs on itemCNKD.SoHoaDon equals itemHD.SOHOADON
            //            where itemCNKD.CreateDate.Value.Date == CreateDate.Date
            //            group itemHD by itemHD.ID_HOADON into itemGroup
            //            select new
            //            {
            //                TongHD = itemGroup.Count(),
            //                TongGiaBan = itemGroup.Sum(groupItem => groupItem.GIABAN),
            //                TongThueGTGT = itemGroup.Sum(groupItem => groupItem.THUE),
            //                TongPhiBVMT = itemGroup.Sum(groupItem => groupItem.PHI),
            //                TongCong = itemGroup.Sum(groupItem => groupItem.TONGCONG),
            //            };
            //return LINQToDataTable(query);

            string sql = "select COUNT(a.SoHoaDon) as TongHD,SUM(GIABAN) as TongGiaBan,SUM(THUE) as TongThueGTGT,SUM(PHI) as TongPhiBVMT from TT_ChuyenNoKhoDoi a,HOADON b"
                        + " where a.SoHoaDon=b.SOHOADON and CONVERT(varchar(10),a.CreateDate,103)='" + CreateDate.ToString("dd/MM/yyyy") + "'"
                        + " group by CONVERT(varchar(10),a.CreateDate,103)";

            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

    }
}

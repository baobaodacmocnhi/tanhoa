using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.ChuyenKhoan
{
    class CBangKe_PhiMoNuoc : CDAL
    {
        public bool Them(TT_BangKe_PhiMoNuoc bangke)
        {
            try
            {
                if (_db.TT_BangKe_PhiMoNuocs.Count() == 0)
                    bangke.MaBK = 1;
                else
                    bangke.MaBK = _db.TT_BangKe_PhiMoNuocs.Max(item => item.MaBK) + 1;
                //bangke.CreateDate = DateTime.Now;
                //bangke.CreateBy = CNguoiDung.MaND;
                _db.TT_BangKe_PhiMoNuocs.InsertOnSubmit(bangke);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(TT_BangKe_PhiMoNuoc bangke)
        {
            try
            {
                bangke.ModifyDate = DateTime.Now;
                bangke.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(TT_BangKe_PhiMoNuoc bangke)
        {
            try
            {
                _db.TT_BangKe_PhiMoNuocs.DeleteOnSubmit(bangke);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool CheckExist(string DanhBo, DateTime CreateDate)
        {
            return _db.TT_BangKe_PhiMoNuocs.Any(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public TT_BangKe_PhiMoNuoc get(int MaBK)
        {
            return _db.TT_BangKe_PhiMoNuocs.SingleOrDefault(item => item.MaBK == MaBK);
        }

        public TT_BangKe_PhiMoNuoc get(string DanhBo, DateTime CreateDate)
        {
            return _db.TT_BangKe_PhiMoNuocs.Where(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date).FirstOrDefault();
        }

        public TT_BangKe_PhiMoNuoc getLast(string DanhBo)
        {
            if (_db.TT_BangKe_PhiMoNuocs.Any(item => item.DanhBo == DanhBo))
                return _db.TT_BangKe_PhiMoNuocs.Where(item => item.DanhBo == DanhBo).OrderByDescending(item => item.CreateDate).First();
            else
                return null;
        }

        public TT_BangKe_PhiMoNuoc getLast(string DanhBo, DateTime CreateDate)
        {
            if (_db.TT_BangKe_PhiMoNuocs.Any(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date <= CreateDate.Date) == true)
                return _db.TT_BangKe_PhiMoNuocs.Where(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date <= CreateDate.Date).OrderByDescending(item => item.CreateDate).First();
            else
                return null;
        }

        public DataTable GetDS()
        {
            var query = from itemBK in _db.TT_BangKe_PhiMoNuocs
                        join itemNH in _db.NGANHANGs on itemBK.MaNH equals itemNH.ID_NGANHANG into tableNH
                        from itemtableNH in tableNH.DefaultIfEmpty()
                        select new
                        {
                            itemBK.MaBK,
                            itemBK.DanhBo,
                            itemBK.SoTien,
                            itemBK.CreateDate,
                            TenNH = itemtableNH.NGANHANG1,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime TuNgay, DateTime DenNgay)
        {
            var query = from itemBK in _db.TT_BangKe_PhiMoNuocs
                        join itemNH in _db.NGANHANGs on itemBK.MaNH equals itemNH.ID_NGANHANG into tableNH
                        from itemtableNH in tableNH.DefaultIfEmpty()
                        where itemBK.CreateDate.Value.Date >= TuNgay.Date && itemBK.CreateDate.Value.Date <= DenNgay.Date
                        select new
                        {
                            itemBK.MaBK,
                            itemBK.DanhBo,
                            itemBK.SoTien,
                            itemBK.CreateDate,
                            TenNH = itemtableNH.NGANHANG1,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS_BangKe(DateTime CreateDate)
        {
            var query = from itemBK in _db.TT_BangKe_PhiMoNuocs
                        join itemNH in _db.NGANHANGs on itemBK.MaNH equals itemNH.ID_NGANHANG into tableNH
                        from itemtableNH in tableNH.DefaultIfEmpty()
                        where itemBK.CreateDate.Value.Date == CreateDate.Date
                        orderby itemBK.MaBK ascending
                        select new
                        {
                            itemBK.MaBK,
                            itemBK.DanhBo,
                            itemBK.SoTien,
                            itemBK.CreateDate,
                            MaNH = itemtableNH.ID_NGANHANG,
                            TenNH = itemtableNH.NGANHANG1,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS_BangKeLui5(DateTime CreateDate)
        {
            var query = from itemBK in _db.TT_BangKe_PhiMoNuocs
                        join itemNH in _db.NGANHANGs on itemBK.MaNH equals itemNH.ID_NGANHANG into tableNH
                        from itemtableNH in tableNH.DefaultIfEmpty()
                        where itemBK.CreateDate.Value.Date >= CreateDate.Date.AddDays(-5) && itemBK.CreateDate.Value.Date < CreateDate.Date
                        select new
                        {
                            itemBK.MaBK,
                            itemBK.DanhBo,
                            itemBK.SoTien,
                            itemBK.CreateDate,
                            MaNH = itemtableNH.ID_NGANHANG,
                            TenNH = itemtableNH.NGANHANG1,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS_BangKe_DangNgan(DateTime TuNgay, DateTime DenNgay)
        {
            string sql = "declare @FromNgayGiaiTrach date;"
                 + " declare @ToNgayGiaiTrach date;"
                 + " set @FromNgayGiaiTrach='" + TuNgay.ToString("yyyyMMdd") + "';"
                 + " set @ToNgayGiaiTrach='" + DenNgay.ToString("yyyyMMdd") + "';"
                 + " select * from"
                 + " (select MaBK,bk.DanhBo,SoTien,CreateDate,TenNH from"
                 + " (select MaBK,DanhBo,SoTien,MaNH,CreateDate from TT_BangKe_PhiMoNuoc where CAST(CreateDate as date)>=@FromNgayGiaiTrach and CAST(CreateDate as date)<=@ToNgayGiaiTrach) bk"
                 + " left join"
                 + " (select ID_NGANHANG,NGANHANG as TenNH from NGANHANG) nh on bk.MaNH=nh.ID_NGANHANG) as t1"
                 + " outer apply"
                 + " (select top 1 TENKH as HoTen from HOADON where DANHBA=t1.DanhBo order by ID_HOADON desc) as la"
                 + " order by MaBK asc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDS_Group(DateTime TuNgay, DateTime DenNgay)
        {
            var query = from itemBK in _db.TT_BangKe_PhiMoNuocs
                        join itemNH in _db.NGANHANGs on itemBK.MaNH equals itemNH.ID_NGANHANG into tableNH
                        from itemtableNH in tableNH.DefaultIfEmpty()
                        where itemBK.CreateDate.Value.Date >= TuNgay.Date && itemBK.CreateDate.Value.Date <= DenNgay.Date
                        group itemBK by itemtableNH.NGANHANG1 into itemGroup
                        select new
                        {
                            TenNH = itemGroup.Key,
                            SoLuong = itemGroup.Count(),
                            TongCong = itemGroup.Sum(groupItem => (long)groupItem.SoTien),
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS_Group3(DateTime TuNgay, DateTime DenNgay)
        {
            var query = from itemBK in _db.TT_BangKe_PhiMoNuocs
                        join itemNH in _db.NGANHANGs on itemBK.MaNH equals itemNH.ID_NGANHANG into tableNH
                        from itemtableNH in tableNH.DefaultIfEmpty()
                        where itemBK.CreateDate.Value.Date >= TuNgay.Date && itemBK.CreateDate.Value.Date <= DenNgay.Date
                        && (itemtableNH.ID_NGANHANG == 3 || itemtableNH.ID_NGANHANG == 4 || itemtableNH.ID_NGANHANG == 9 || itemtableNH.ID_NGANHANG == 10)
                        group itemBK by itemtableNH.NGANHANG1 into itemGroup
                        select new
                        {
                            TenNH = itemGroup.Key,
                            SoLuong = itemGroup.Count(),
                            TongCong = itemGroup.Sum(groupItem => (long)groupItem.SoTien),
                        };
            var queryAGR = from itemBK in _db.TT_BangKe_PhiMoNuocs
                           join itemNH in _db.NGANHANGs on itemBK.MaNH equals itemNH.ID_NGANHANG into tableNH
                           from itemtableNH in tableNH.DefaultIfEmpty()
                           where itemBK.CreateDate.Value.Date >= TuNgay.Date && itemBK.CreateDate.Value.Date <= DenNgay.Date
                           && itemtableNH.ID_NGANHANG != 3 && itemtableNH.ID_NGANHANG != 4 && itemtableNH.ID_NGANHANG != 9 && itemtableNH.ID_NGANHANG != 10
                           group itemBK by "AGR" into itemGroup
                           select new
                           {
                               TenNH = itemGroup.Key,
                               SoLuong = itemGroup.Count(),
                               TongCong = itemGroup.Sum(groupItem => (long)groupItem.SoTien),
                           };
            DataTable dt = LINQToDataTable(query);
            dt.Merge(LINQToDataTable(queryAGR));
            return dt;
        }

        public int getSoTien(string DanhBo, DateTime CreateDate)
        {
            if (_db.TT_BangKe_PhiMoNuocs.Any(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date))
                return _db.TT_BangKe_PhiMoNuocs.Where(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date).Sum(item => item.SoTien).Value;
            else
                return 0;
        }

        public string GetSoTK(string DanhBo, DateTime CreateDate)
        {
            if (_db.TT_BangKe_PhiMoNuocs.Any(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date))
                return _db.NGANHANGs.SingleOrDefault(itemB => itemB.ID_NGANHANG == _db.TT_BangKe_PhiMoNuocs.FirstOrDefault(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date).MaNH).SoTK;
            else
                return "";
        }

        public string GetBank(string DanhBo)
        {
            if (_db.TT_BangKe_PhiMoNuocs.Any(itemBK => itemBK.DanhBo == DanhBo && itemBK.MaNH != null))
                return _db.NGANHANGs.SingleOrDefault(itemB => itemB.ID_NGANHANG == _db.TT_BangKe_PhiMoNuocs.Where(itemBK => itemBK.DanhBo == DanhBo && itemBK.MaNH != null).OrderByDescending(item => item.MaBK).First().MaNH.Value).NGANHANG1;
            else
                return "";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.ChuyenKhoan
{
    class CBangKe : CDAL
    {
        public bool Them(TT_BangKe bangke)
        {
            try
            {
                if (_db.TT_BangKes.Count() == 0)
                    bangke.MaBK = 1;
                else
                    bangke.MaBK = _db.TT_BangKes.Max(item => item.MaBK) + 1;
                //bangke.CreateDate = DateTime.Now;
                //bangke.CreateBy = CNguoiDung.MaND;
                _db.TT_BangKes.InsertOnSubmit(bangke);
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

        public bool Sua(TT_BangKe bangke)
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
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(TT_BangKe bangke)
        {
            try
            {
                _db.TT_BangKes.DeleteOnSubmit(bangke);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(string DanhBo, DateTime CreateDate)
        {
            return _db.TT_BangKes.Any(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public TT_BangKe Get(int MaBK)
        {
            return _db.TT_BangKes.SingleOrDefault(item => item.MaBK == MaBK);
        }

        public TT_BangKe Get(string DanhBo)
        {
            if (_db.TT_BangKes.Any(item => item.DanhBo == DanhBo))
                return _db.TT_BangKes.Where(item => item.DanhBo == DanhBo).OrderByDescending(item => item.CreateDate).First();
            else
                return null;
        }

        public DataTable GetDS()
        {
            var query = from itemBK in _db.TT_BangKes
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
            var query = from itemBK in _db.TT_BangKes
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
            var query = from itemBK in _db.TT_BangKes
                        join itemNH in _db.NGANHANGs on itemBK.MaNH equals itemNH.ID_NGANHANG into tableNH
                        from itemtableNH in tableNH.DefaultIfEmpty()
                        where itemBK.CreateDate.Value.Date == CreateDate.Date
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
            var query = from itemBK in _db.TT_BangKes
                        join itemNH in _db.NGANHANGs on itemBK.MaNH equals itemNH.ID_NGANHANG into tableNH
                        from itemtableNH in tableNH.DefaultIfEmpty()
                        where itemBK.CreateDate.Value.Date >= CreateDate.Date.AddDays(-5) && itemBK.CreateDate.Value.Date <= CreateDate.Date
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
                + " set @FromNgayGiaiTrach='" + TuNgay.ToString("yyyy-MM-dd") + "';"
                + " set @ToNgayGiaiTrach='" + DenNgay.ToString("yyyy-MM-dd") + "';"
                + " select MaBK,bk.DanhBo,SoTien,Phi,CreateDate,TenNH,HoaDon,TongCong from"
                + " (select MaBK,DanhBo,SoTien,Phi,MaNH,CreateDate from TT_BangKe where CAST(CreateDate as date)>=@FromNgayGiaiTrach and CAST(CreateDate as date)<=@ToNgayGiaiTrach) bk"
                + " left join"
                + " (select ID_NGANHANG,NGANHANG as TenNH from NGANHANG) nh on bk.MaNH=nh.ID_NGANHANG"
                + " left join"
                + " (select DANHBA,COUNT(*) as HoaDon,SUM(TONGCONG) as TongCong from HOADON where DangNgan_ChuyenKhoan=1"
                + " and CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach group by DANHBA) dn on bk.DanhBo=dn.DANHBA";

            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetDS_BangKe_DangNgan1(DateTime TuNgay, DateTime DenNgay)
        {
            string sql = "declare @FromNgayGiaiTrach date;"
                + " declare @ToNgayGiaiTrach date;"
                + " set @FromNgayGiaiTrach='" + TuNgay.ToString("yyyy-MM-dd") + "';"
                + " set @ToNgayGiaiTrach='" + DenNgay.ToString("yyyy-MM-dd") + "';"
                + " select t1.* from"
                + " (select MaBK,bk.DanhBo,HoTen,GiaBieu,SoTien,Phi,CreateDate,TenNH,HoaDon,TongCong,row_number() over (partition by bk.DanhBo order by hd.ID_HOADON desc) as RowNumber from"
                + " (select MaBK,DanhBo,SoTien,Phi,MaNH,CreateDate from TT_BangKe where CAST(CreateDate as date)>=@FromNgayGiaiTrach and CAST(CreateDate as date)<=@ToNgayGiaiTrach) bk"
                + " left join"
                + " (select ID_NGANHANG,NGANHANG as TenNH from NGANHANG) nh on bk.MaNH=nh.ID_NGANHANG"
                + " left join"
                + " (select ID_HOADON,DANHBA,TENKH as HoTen,GB as GIABIEU from HOADON) hd on bk.DanhBo=hd.DANHBA"
                + " left join"
                + " (select DANHBA,COUNT(*) as HoaDon,SUM(TONGCONG) as TongCong from HOADON where DangNgan_ChuyenKhoan=1"
                + " and CAST(NGAYGIAITRACH as date)>=@FromNgayGiaiTrach and CAST(NGAYGIAITRACH as date)<=@ToNgayGiaiTrach group by DANHBA) dn on bk.DanhBo=dn.DANHBA) t1"
                + " where RowNumber=1";

            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetDS_Group(DateTime TuNgay, DateTime DenNgay)
        {
            var query = from itemBK in _db.TT_BangKes
                        join itemNH in _db.NGANHANGs on itemBK.MaNH equals itemNH.ID_NGANHANG into tableNH
                        from itemtableNH in tableNH.DefaultIfEmpty()
                        where itemBK.CreateDate.Value.Date >= TuNgay.Date && itemBK.CreateDate.Value.Date <= DenNgay.Date
                        group itemBK by itemtableNH.NGANHANG1 into itemGroup
                        select new
                        {
                            TenNH=itemGroup.Key,
                            SoLuong = itemGroup.Count(),
                            TongCong = itemGroup.Sum(groupItem => (long)groupItem.SoTien),
                        };
            return LINQToDataTable(query);
        }

        public int GetSoTien(string DanhBo, DateTime CreateDate)
        {
            if (_db.TT_BangKes.Any(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date))
                return _db.TT_BangKes.Where(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date).Sum(item => item.SoTien).Value;
            else
                return 0;
        }
    }
}

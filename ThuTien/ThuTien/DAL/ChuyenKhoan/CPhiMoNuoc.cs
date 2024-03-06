using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.ChuyenKhoan
{
    class CPhiMoNuoc : CDAL
    {
        public bool Them(TT_PhiMoNuoc phimonuoc, DateTime CreateDate)
        {
            try
            {
                if (_db.TT_PhiMoNuocs.Count() > 0)
                {
                    string ID = "MaPMN";
                    string Table = "TT_PhiMoNuoc";
                    decimal MaTT = _db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    phimonuoc.MaPMN = getMaxNextIDTable(MaTT);
                }
                else
                    phimonuoc.MaPMN = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                phimonuoc.CreateDate = CreateDate;
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

        public DataTable getDS_Chung(DateTime FromCreateDate, DateTime ToCreateDate, int FromDot, int ToDot)
        {
            //return LINQToDataTable(_db.TT_PhiMoNuocs.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date).ToList().OrderByDescending(item=>item.CreateDate));
            string sql = "select a.*,b.Co,MLT=ttkh.LOTRINH from TT_PhiMoNuoc a left join TT_KQDongNuoc b on a.MaKQDN=b.MaKQDN left join CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh on ttkh.DANHBO=b.DanhBo"
                        + " where CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and " + FromDot + "<=SUBSTRING(ttkh.LOTRINH,1,2) and SUBSTRING(ttkh.LOTRINH,1,2)<=" + ToDot
                        + " order by a.CreateDate desc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_Rieng(DateTime FromCreateDate, DateTime ToCreateDate, int FromDot, int ToDot)
        {
            //var query = from itemP in _db.TT_BangKe_PhiMoNuocs
            //            join itemKQ in _db.TT_KQDongNuocs on itemP.MaKQDN equals itemKQ.MaKQDN
            //            join itemND in _db.TT_NguoiDungs on itemKQ.CreateBy equals itemND.MaND
            //            where itemP.CreateDate.Value.Date >= FromCreateDate.Date && itemP.CreateDate.Value.Date <= ToCreateDate.Date
            //            && FromDot <= Convert.ToInt32(itemKQ.MLT.Substring(0, 2)) && Convert.ToInt32(itemKQ.MLT.Substring(0, 2)) <= ToDot
            //            select new
            //            {
            //                itemKQ.MaDN,
            //                itemKQ.MaKQDN,
            //                itemKQ.CreateDate,
            //                itemKQ.MLT,
            //                itemKQ.DanhBo,
            //                itemKQ.HoTen,
            //                itemKQ.DiaChi,
            //                itemKQ.NgayDN,
            //                itemKQ.PhiMoNuoc,
            //                itemKQ.DongPhi,
            //                itemKQ.NgayDongPhi,
            //                itemKQ.ChuyenKhoan,
            //                itemKQ.Co,
            //                itemKQ.Hieu,
            //                itemKQ.SoThan,
            //                itemKQ.ChiSoDN,
            //                itemKQ.LyDo,
            //                CreateBy = itemND.HoTen,
            //            };
            //return LINQToDataTable(query.ToList());
            return ExecuteQuery_DataTable("select CreateBy=(select HoTen from TT_NguoiDung where MaND=b.CreateBy),b.*,b.Co,MLT=ttkh.LOTRINH from TT_BangKe_PhiMoNuoc a left join TT_KQDongNuoc b on a.MaKQDN=b.MaKQDN left join CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh on ttkh.DANHBO=b.DanhBo"
                        + " where CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and " + FromDot + "<=SUBSTRING(ttkh.LOTRINH,1,2) and SUBSTRING(ttkh.LOTRINH,1,2)<=" + ToDot
                        + " order by a.CreateDate desc");
        }

        public int getPhiMoNuoc_Chot(bool Chot)
        {
            if (_db.TT_PhiMoNuocs.Any(item => item.Chot == Chot) == false)
                return 0;
            else
                return _db.TT_PhiMoNuocs.Where(item => item.Chot == Chot).Sum(item => item.PhiMoNuoc).Value;
        }

        public int getPhiMoNuoc_Chot(bool Chot, int FromDot, int ToDot)
        {
            if (_db.TT_PhiMoNuocs.Any(item => item.Chot == Chot && Convert.ToInt32(item.MLT.Substring(0, 2)) >= FromDot && Convert.ToInt32(item.MLT.Substring(0, 2)) <= ToDot) == false)
                return 0;
            else
                return _db.TT_PhiMoNuocs.Where(item => item.Chot == Chot && Convert.ToInt32(item.MLT.Substring(0, 2)) >= FromDot && Convert.ToInt32(item.MLT.Substring(0, 2)) <= ToDot).Sum(item => item.PhiMoNuoc).Value;
        }
    }
}

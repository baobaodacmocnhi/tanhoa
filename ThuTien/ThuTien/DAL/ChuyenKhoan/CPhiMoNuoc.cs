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

        public DataTable getDS_Chung(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            //return LINQToDataTable(_db.TT_PhiMoNuocs.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date).ToList().OrderByDescending(item=>item.CreateDate));
            string sql = "select a.*,CoDHN=b.Co from TT_PhiMoNuoc a left join TT_KQDongNuoc b on a.MaKQDN=b.MaKQDN"
                        + " where CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' order by a.CreateDate desc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_Rieng(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from itemP in _db.TT_BangKe_PhiMoNuocs
                        join itemKQ in _db.TT_KQDongNuocs on itemP.MaKQDN equals itemKQ.MaKQDN
                        join itemND in _db.TT_NguoiDungs on itemKQ.CreateBy equals itemND.CreateBy
                        where itemP.CreateDate.Value.Date >= FromCreateDate.Date && itemKQ.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            itemKQ.MaDN,
                            itemKQ.MaKQDN,
                            itemKQ.CreateDate,
                            itemKQ.DanhBo,
                            itemKQ.HoTen,
                            itemKQ.DiaChi,
                            itemKQ.NgayDN,
                            itemKQ.PhiMoNuoc,
                            itemKQ.DongPhi,
                            itemKQ.NgayDongPhi,
                            itemKQ.ChuyenKhoan,
                            itemKQ.Co,
                            itemKQ.Hieu,
                            itemKQ.SoThan,
                            itemKQ.ChiSoDN,
                            itemKQ.LyDo,
                            CreateBy=itemND.HoTen,
                        };
            return LINQToDataTable(query.GroupBy(item => item.MaDN).Select(item => item.First()).ToList());
        }

        public int getPhiMoNuoc_Chot(bool Chot)
        {
            if (_db.TT_PhiMoNuocs.Any(item => item.Chot == Chot) == false)
                return 0;
            else
                return _db.TT_PhiMoNuocs.Where(item => item.Chot == Chot).Sum(item => item.PhiMoNuoc).Value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.ToTruong
{
    class CTongHopNo:CDAL
    {
        public bool Them(TT_TongHopNo tonghopno)
        {
            try
            {
                if (_db.TT_TongHopNos.Count() > 0)
                {
                    string ID = "MaTHN";
                    string Table = "TT_TongHopNo";
                    decimal MaTT = _db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    tonghopno.MaTHN = getMaxNextIDTable(MaTT);
                }
                else
                    tonghopno.MaTHN = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                tonghopno.CreateDate = DateTime.Now;
                tonghopno.CreateBy = CNguoiDung.MaND;
                _db.TT_TongHopNos.InsertOnSubmit(tonghopno);
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

        public bool Xoa(TT_TongHopNo tonghopno)
        {
            try
            {
                _db.TT_TongHopNos.DeleteOnSubmit(tonghopno);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(string KinhGui,DateTime CreateDate)
        {
            return _db.TT_TongHopNos.Any(item => item.KinhGui == KinhGui && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public int GetNextID_CTTongHopNo()
        {
            if (_db.TT_CTTongHopNos.Count() > 0)
                return _db.TT_CTTongHopNos.Max(item => item.ID) + 1;
            else
                return 1;
        }

        public DataTable GetDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in _db.TT_TongHopNos
                        from itemHD in _db.HOADONs.Where(itemA => itemA.DANHBA == item.DanhBo).ToList().OrderByDescending(itemA => itemA.ID_HOADON).Take(1).DefaultIfEmpty()
                        where  item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new 
                        {
                            item.MaTHN,
                            item.DanhBo,
                            item.KinhGui,
                            TongCong=item.TT_CTTongHopNos.Sum(itemCT=>itemCT.TongCong),
                            item.ChiSoCu,
                            item.ChiSoMoi,
                            item.TieuThu,
                            item.DinhMuc,
                            item.NgayThanhToan,
                            item.CreateDate,
                            TieuThuHD = itemHD.TIEUTHU,
                            KyHD=itemHD.KY+"/"+itemHD.NAM,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS_To(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in _db.TT_TongHopNos
                        from itemHD in _db.HOADONs.Where(itemA => itemA.DANHBA == item.DanhBo).ToList().OrderByDescending(itemA => itemA.ID_HOADON).Take(1).DefaultIfEmpty()
                        where _db.TT_NguoiDungs.SingleOrDefault(itemND=>itemND.MaND==item.CreateBy.Value).MaTo == MaTo && item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            item.MaTHN,
                            item.DanhBo,
                            item.KinhGui,
                            TongCong = item.TT_CTTongHopNos.Sum(itemCT => itemCT.TongCong),
                            item.ChiSoCu,
                            item.ChiSoMoi,
                            item.TieuThu,
                            item.DinhMuc,
                            item.NgayThanhToan,
                            item.CreateDate,
                            TieuThuHD=itemHD.TIEUTHU,
                            KyHD = itemHD.KY + "/" + itemHD.NAM,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(int CreateBy,DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in _db.TT_TongHopNos
                        where item.CreateBy == CreateBy && item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            item.MaTHN,
                            item.DanhBo,
                            item.KinhGui,
                            TongCong = item.TT_CTTongHopNos.Sum(itemCT => itemCT.TongCong),
                            item.ChiSoCu,
                            item.ChiSoMoi,
                            item.TieuThu,
                            item.DinhMuc,
                            item.NgayThanhToan,
                            item.CreateDate,
                        };
            return LINQToDataTable(query);
        }

        public TT_TongHopNo Get(decimal MaTHN)
        {
            return _db.TT_TongHopNos.SingleOrDefault(item => item.MaTHN == MaTHN);
        }

    }
}

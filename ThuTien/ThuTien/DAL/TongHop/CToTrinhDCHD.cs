using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.TongHop
{
    class CToTrinhDCHD:CDAL
    {
        public bool Them(TT_ToTrinhDCHD en)
        {
            try
            {
                if (_db.TT_ToTrinhDCHDs.Count() > 0)
                {
                    string IDName = "ID";
                    string Table = "TT_ToTrinhDCHD";
                    int ID = _db.ExecuteQuery<int>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + IDName + "),LEN(CONVERT(nvarchar(50)," + IDName + "))-1,2)) from " + Table + " " +
                        "select MAX(" + IDName + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + IDName + "),LEN(CONVERT(nvarchar(50)," + IDName + "))-1,2)=@Ma").Single();
                    //decimal MaCHDB = db.CHDBs.Max(itemCHDB => itemCHDB.MaCHDB);
                    en.ID = (int)getMaxNextIDTable(ID);
                }
                else
                    en.ID = int.Parse("1" + DateTime.Now.ToString("yy"));
                en.CreateDate = DateTime.Now;
                en.CreateBy = CNguoiDung.MaND;
                _db.TT_ToTrinhDCHDs.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(TT_ToTrinhDCHD en)
        {
            try
            {
                en.ModifyDate = DateTime.Now;
                en.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(TT_ToTrinhDCHD en)
        {
            try
            {
                _db.TT_ToTrinhDCHDs.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public DataTable GetDS()
        {
            return LINQToDataTable(_db.TT_ToTrinhDCHDs.OrderByDescending(item => item.CreateDate).ToList());
        }

        public TT_ToTrinhDCHD Get(decimal ID)
        {
            return _db.TT_ToTrinhDCHDs.SingleOrDefault(item => item.ID == ID);
        }

        #region CT Tờ Trình

        public bool SuaCT(TT_ToTrinhDCHD_ChiTiet cttotrinh)
        {
            try
            {
                cttotrinh.ModifyDate = DateTime.Now;
                cttotrinh.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool XoaCT(TT_ToTrinhDCHD_ChiTiet cttotrinh)
        {
            try
            {
                _db.TT_ToTrinhDCHD_ChiTiets.DeleteOnSubmit(cttotrinh);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool CheckExist_CT(string SoHoaDon)
        {
            return _db.TT_ToTrinhDCHD_ChiTiets.Any(item => item.SoHoaDon == SoHoaDon);
        }

        public TT_ToTrinhDCHD_ChiTiet get_ChiTiet(int IDCT)
        {
            return _db.TT_ToTrinhDCHD_ChiTiets.SingleOrDefault(item => item.IDCT == IDCT);

        }

        public List<TT_ToTrinhDCHD_ChiTiet> GetListCT(int ID)
        {
            return _db.TT_ToTrinhDCHD_ChiTiets.Where(item => item.ID == ID).ToList();
        }

        public DataTable GetDSCT(int ID)
        {
            return LINQToDataTable(_db.TT_ToTrinhDCHD_ChiTiets.Where(item => item.ID == ID).ToList());
        }

        public int GetMaxIDCT()
        {
            if (_db.TT_ToTrinhDCHD_ChiTiets.Count() == 0)
                return 0;
            else
                return _db.TT_ToTrinhDCHD_ChiTiets.Max(item => item.IDCT);
        }

        public int CountCT(int ID)
        {
            return _db.TT_ToTrinhDCHD_ChiTiets.Count(item => item.ID == ID);
        }

        public int getMaTT(string SoHoaDon)
        {
            try
            {
                return _db.TT_ToTrinhDCHD_ChiTiets.Where(item => item.SoHoaDon.Contains(SoHoaDon)).OrderByDescending(item => item.CreateDate).First().ID.Value;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion
    }
}

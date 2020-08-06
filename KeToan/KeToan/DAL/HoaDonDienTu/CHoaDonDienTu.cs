using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeToan.DAL.QuanTri;
using System.Data;

namespace KeToan.DAL.HoaDonDienTu
{
    class CHoaDonDienTu : CDAL
    {
        public bool Them(LinQ.HoaDonDienTu en)
        {
            try
            {
                if (_db.HoaDonDienTus.Count() > 0)
                {
                    string Column = "ID";
                    string Table = "HoaDonDienTu";
                    int ID = _db.ExecuteQuery<int>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + Column + "),LEN(CONVERT(nvarchar(50)," + Column + "))-1,2)) from " + Table + " " +
                        "select MAX(" + Column + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + Column + "),LEN(CONVERT(nvarchar(50)," + Column + "))-1,2)=@Ma").Single();
                    en.ID = getMaxNextIDTable(ID);
                }
                else
                    en.ID = int.Parse("1" + DateTime.Now.ToString("yy")); ;
                en.CreateBy = CUser.MaUser;
                en.CreateDate = DateTime.Now;
                _db.HoaDonDienTus.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Them(LinQ.HoaDonDienTu en,DateTime CreateDate)
        {
            try
            {
                if (_db.HoaDonDienTus.Count() > 0)
                {
                    string Column = "ID";
                    string Table = "HoaDonDienTu";
                    int ID = _db.ExecuteQuery<int>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + Column + "),LEN(CONVERT(nvarchar(50)," + Column + "))-1,2)) from " + Table + " " +
                        "select MAX(" + Column + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + Column + "),LEN(CONVERT(nvarchar(50)," + Column + "))-1,2)=@Ma").Single();
                    en.ID = getMaxNextIDTable(ID);
                }
                else
                    en.ID = int.Parse("1" + DateTime.Now.ToString("yy")); ;
                en.CreateBy = CUser.MaUser;
                en.CreateDate = CreateDate;
                _db.HoaDonDienTus.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(LinQ.HoaDonDienTu en)
        {
            try
            {
                en.ModifyBy = CUser.MaUser;
                en.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Xoa(LinQ.HoaDonDienTu en)
        {
            try
            {
                _db.HoaDonDienTus.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist(string HoTen,string DiaChi,DateTime CreateDate)
        {
            return _db.HoaDonDienTus.Any(item => item.HoTen == HoTen && item.DiaChi == DiaChi&&item.CreateDate.Value.Date==CreateDate.Date);
        }

        public LinQ.HoaDonDienTu get(int ID)
        {
            return _db.HoaDonDienTus.SingleOrDefault(item => item.ID == ID);
        }

        public LinQ.HoaDonDienTu get(string HoTen, string DiaChi, DateTime CreateDate)
        {
            return _db.HoaDonDienTus.SingleOrDefault(item => item.HoTen == HoTen && item.DiaChi == DiaChi && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public DataTable getDS()
        {
            return LINQToDataTable(_db.HoaDonDienTus.OrderByDescending(item => item.CreateDate).ToList());
        }

        public DataTable getDS(DateTime FromCreateDate,DateTime ToCreateDate)
        {
            return LINQToDataTable(_db.HoaDonDienTus.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date).OrderByDescending(item=>item.CreateDate).ToList());
        }

        public DataTable getDS(string NoiDungTimKiem)
        {
            return LINQToDataTable(_db.HoaDonDienTus.Where(item => item.DanhBo.Contains(NoiDungTimKiem) || item.HoTen.Contains(NoiDungTimKiem) || item.DiaChi.Contains(NoiDungTimKiem)).OrderByDescending(item => item.CreateDate).ToList());
        }
    }
}

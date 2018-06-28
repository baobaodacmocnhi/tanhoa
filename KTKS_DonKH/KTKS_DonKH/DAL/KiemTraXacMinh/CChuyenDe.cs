using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.DAL.KiemTraXacMinh
{
    class CChuyenDe:CDAL
    {
        public bool them(ChuyenDe entity)
        {
            try
            {
                if (db.ChuyenDes.Count() > 0)
                {
                    string ID = "ID";
                    string Table = "ChuyenDe";
                    decimal Ma = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    entity.ID = (int)getMaxNextIDTable(Ma);
                }
                else
                    entity.ID = int.Parse("1" + DateTime.Now.ToString("yy"));
                entity.CreateBy = CTaiKhoan.MaUser;
                entity.CreateDate = DateTime.Now;
                db.ChuyenDes.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                return false;
                throw ex;
            }
        }

        public bool sua(ChuyenDe entity)
        {
            try
            {
                entity.ModifyBy = CTaiKhoan.MaUser;
                entity.ModifyDate = DateTime.Now; 
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                return false;
                throw ex;
            }
        }

        public bool xoa(ChuyenDe entity)
        {
            try
            {
                db.ChuyenDes.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                return false;
                throw ex;
            }
        }

        public bool checkExist(string DanhBo,string ChuyenDe)
        {
            return db.ChuyenDes.Any(item => item.DanhBo == DanhBo && item.Name == ChuyenDe);
        }

    }
}

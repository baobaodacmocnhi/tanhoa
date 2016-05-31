using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrangThietBi.LinQ;
using System.Data;
using System.Reflection;

namespace TrangThietBi.DAL
{
    class CDAL
    {
        dbTrangThietBiDataContext _db = new dbTrangThietBiDataContext();

        public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        public void SubmitChanges()
        {
            _db.SubmitChanges();
        }

        public List<PhongBan> GetDSPhongBan()
        {
            return _db.PhongBans.ToList();
        }

        public bool ThemThietBi(ThietBi item)
        {
            try
            {
                if (_db.ThietBis.Count() == 0)
                    item.MaTB = 1;
                else
                    item.MaTB = _db.ThietBis.Max(itemTB => itemTB.MaTB) + 1;
                item.CreateDate = DateTime.Now;
                _db.ThietBis.InsertOnSubmit(item);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SuaThietBi(ThietBi item)
        {
            try
            {
                item.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool XoaThietBi(ThietBi item)
        {
            try
            {
                _db.ThietBis.DeleteOnSubmit(item);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ThietBi GetThietBi(int MaTB)
        {
            return _db.ThietBis.SingleOrDefault(item => item.MaTB == MaTB);
        }

        public DataTable GetDSThietBi()
        {
            var query = from itemTB in _db.ThietBis
                        join itemPB in _db.PhongBans on itemTB.PhongBanNhan equals itemPB.ID into tablePB
                        from itemtablePB in tablePB.DefaultIfEmpty()
                        select new
                        {
                            itemTB,
                            itemtablePB.TenPhongBan,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetLichSuBanGiao(int MaTB)
        {
            return LINQToDataTable(_db.LichSuBanGiaos.Where(item => item.MaTB == MaTB));
        }

        public DataTable GetLichSuThuHoi(int MaTB)
        {
            return LINQToDataTable(_db.LichSuThuHois.Where(item => item.MaTB == MaTB));
        }

        public DataTable GetLichSuSuaChua(int MaTB)
        {
            return LINQToDataTable(_db.LichSuSuaChuas.Where(item => item.MaTB == MaTB));
        }

        public bool ThemPhanMem(PhanMem item)
        {
            try
            {
                if (_db.PhanMems.Count() == 0)
                    item.MaPM = 1;
                else
                    item.MaPM = _db.PhanMems.Max(itemPM => itemPM.MaPM) + 1;
                item.CreateDate = DateTime.Now;
                _db.PhanMems.InsertOnSubmit(item);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SuaPhanMem(PhanMem item)
        {
            try
            {
                item.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool XoaPhanMem(PhanMem item)
        {
            try
            {
                _db.PhanMems.DeleteOnSubmit(item);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public PhanMem GetPhanMem(int MaPM)
        {
            return _db.PhanMems.SingleOrDefault(item => item.MaPM == MaPM);
        }

        public DataTable GetDSPhanMem()
        {
            var query = from itemPM in _db.PhanMems
                        join itemPB in _db.PhongBans on itemPM.PhongBanNhan equals itemPB.ID into tablePB
                        from itemtablePB in tablePB.DefaultIfEmpty()
                        select new
                        {
                            itemPM,
                            itemtablePB.TenPhongBan,
                        };
            return LINQToDataTable(query);
        }

        #region LichSuBanGiao

        public bool ThemLichSuBanGiao(LichSuBanGiao item)
        {
            try
            {
                if (_db.ThietBis.Count() == 0)
                    item.ID = 1;
                else
                    item.ID = _db.LichSuBanGiaos.Max(itemTB => itemTB.ID) + 1;
                item.CreateDate = DateTime.Now;
                _db.LichSuBanGiaos.InsertOnSubmit(item);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region LichSuThuHoi

        public bool ThemLichSuThuHoi(LichSuThuHoi item)
        {
            try
            {
                if (_db.ThietBis.Count() == 0)
                    item.ID = 1;
                else
                    item.ID = _db.LichSuThuHois.Max(itemTB => itemTB.ID) + 1;
                item.CreateDate = DateTime.Now;
                _db.LichSuThuHois.InsertOnSubmit(item);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}

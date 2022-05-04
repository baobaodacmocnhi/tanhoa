using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.DieuChinhBienDong
{
    class CDangKyDinhMucCCCD : CDAL
    {
        public bool checkExists(string CCCD)
        {
            return db.DCBD_DKDM_CCCDs.Any(item => item.CCCD == CCCD && item.CreateBy != null);
        }

        public bool Them(DCBD_DKDM_DanhBo en, out string Thung)
        {
            try
            {
                if (db.DCBD_DKDM_DanhBos.Count() > 0)
                {
                    en.ID = db.DCBD_DKDM_DanhBos.Max(item => item.ID) + 1;
                }
                else
                    en.ID = 1;
                if (db.DCBD_DKDM_DanhBos.Where(item => item.Quan == en.Quan).Max(item => item.Thung) == null)
                {
                    en.Thung = 1;
                    en.STT = 1;
                }
                else
                {
                    en.Thung = db.DCBD_DKDM_DanhBos.Where(item => item.Quan == en.Quan).Max(item => item.Thung);
                    en.STT = db.DCBD_DKDM_DanhBos.Where(item => item.Quan == en.Quan && en.Thung == en.Thung).Max(item => item.STT) + 1;
                }
                en.CreateDate = DateTime.Now;
                en.CreateBy = CTaiKhoan.MaUser;
                db.DCBD_DKDM_DanhBos.InsertOnSubmit(en);
                db.SubmitChanges();
                Thung = "Thùng: " + en.Thung.Value.ToString() + "\nSTT: " + en.STT.Value.ToString();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(DCBD_DKDM_DanhBo en)
        {
            try
            {
                db.DCBD_DKDM_CCCDs.DeleteAllOnSubmit(en.DCBD_DKDM_CCCDs.ToList());
                db.DCBD_DKDM_DanhBos.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public DataTable getDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.DCBD_DKDM_DanhBos
                        join itemND in db.Users on item.CreateBy equals itemND.MaU into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.CreateDate.Date >= FromCreateDate.Date && item.CreateDate.Date <= ToCreateDate.Date && item.CreateBy != null
                        select new
                        {
                            item.DanhBo,
                            item.SDT,
                            item.Quan,
                            item.Thung,
                            item.STT,
                            item.CreateDate,
                            CreateBy = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS(int CreateBy, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.DCBD_DKDM_DanhBos
                        join itemND in db.Users on item.CreateBy equals itemND.MaU into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.CreateDate.Date >= FromCreateDate.Date && item.CreateDate.Date <= ToCreateDate.Date && item.CreateBy == CreateBy
                        select new
                        {
                            item.DanhBo,
                            item.SDT,
                            item.Quan,
                            item.Thung,
                            item.STT,
                            item.CreateDate,
                            CreateBy = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_Online(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.DCBD_DKDM_DanhBos
                        where item.CreateDate.Date >= FromCreateDate.Date && item.CreateDate.Date <= ToCreateDate.Date && item.CreateBy == null
                        select new
                        {
                            item.DanhBo,
                            item.SDT,
                            SoNK = item.DCBD_DKDM_CCCDs.Count,
                            item.CreateDate,
                        };
            return LINQToDataTable(query);
        }

    }
}

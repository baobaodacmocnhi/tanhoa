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
        public bool checkExists(string CCCD, out string Thung)
        {
            bool flag = db.DCBD_DKDM_CCCDs.Any(item => item.CCCD == CCCD && item.CreateBy != null);
            if (flag == true)
            {
                DCBD_DKDM_DanhBo en = db.DCBD_DKDM_DanhBos.SingleOrDefault(item => item.ID == db.DCBD_DKDM_CCCDs.SingleOrDefault(itemCT => itemCT.CCCD == CCCD && itemCT.CreateBy != null).IDDanhBo);
                Thung = "Danh Bộ: " + en.DanhBo + " - Thùng: " + en.Thung + " - STT: " + en.STT;
            }
            else
                Thung = "";
            return flag;
        }

        public bool checkExists(string DanhBo)
        {
            return db.DCBD_DKDM_DanhBos.Any(item => item.DanhBo == DanhBo && item.CreateBy != null);
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
                    int ThungMax = db.DCBD_DKDM_DanhBos.Where(item => item.Quan == en.Quan).Max(item => item.Thung).Value;
                    if (db.DCBD_DKDM_DanhBos.Where(item => item.Quan == en.Quan && item.Thung == ThungMax).Max(item => item.STT) == 350)
                    {
                        en.Thung = ThungMax + 1;
                        en.STT = 1;
                    }
                    else
                    {
                        en.Thung = ThungMax;
                        en.STT = db.DCBD_DKDM_DanhBos.Where(item => item.Quan == en.Quan && item.Thung == ThungMax).Max(item => item.STT) + 1;
                    }
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

        public bool Sua(DCBD_DKDM_DanhBo en)
        {
            try
            {
                en.ModifyDate = DateTime.Now;
                en.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(DCBD_DKDM_DanhBo en, out string Thung)
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
                    int ThungMax = db.DCBD_DKDM_DanhBos.Where(item => item.Quan == en.Quan).Max(item => item.Thung).Value;
                    if (db.DCBD_DKDM_DanhBos.Where(item => item.Quan == en.Quan && item.Thung == ThungMax).Max(item => item.STT) == 210)
                    {
                        en.Thung = ThungMax + 1;
                        en.STT = 1;
                    }
                    else
                    {
                        en.Thung = ThungMax;
                        en.STT = db.DCBD_DKDM_DanhBos.Where(item => item.Quan == en.Quan && item.Thung == ThungMax).Max(item => item.STT) + 1;
                    }
                }
                en.CreateDate = DateTime.Now;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate_Old = en.CreateDate;
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

        public bool XoaCT(DCBD_DKDM_CCCD en)
        {
            try
            {
                db.DCBD_DKDM_CCCDs.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public DCBD_DKDM_DanhBo get(int ID)
        {
            return db.DCBD_DKDM_DanhBos.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS(string DanhBo)
        {
            var query = from item in db.DCBD_DKDM_DanhBos
                        join itemND in db.Users on item.CreateBy equals itemND.MaU into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.DanhBo == DanhBo && item.CreateBy != null
                        select new
                        {
                            item.ID,
                            item.DanhBo,
                            item.SDT,
                            item.Quan,
                            item.Thung,
                            item.STT,
                            item.CreateDate,
                            DinhMucMoi = item.DCBD_DKDM_CCCDs.Count*4,
                            item.DCBD,
                            item.DCBD_MaDon,
                            item.DCBD_STT,
                            CreateBy = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_Quan(string Quan)
        {
            var query = from item in db.DCBD_DKDM_DanhBos
                        join itemND in db.Users on item.CreateBy equals itemND.MaU into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.Quan == Quan && item.CreateBy != null
                        select new
                        {
                            item.ID,
                            item.DanhBo,
                            item.SDT,
                            item.Quan,
                            item.Thung,
                            item.STT,
                            item.CreateDate,
                            DinhMucMoi = item.DCBD_DKDM_CCCDs.Count * 4,
                            item.DCBD,
                            item.DCBD_MaDon,
                            item.DCBD_STT,
                            CreateBy = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_Quan(int CreateBy, string Quan)
        {
            var query = from item in db.DCBD_DKDM_DanhBos
                        join itemND in db.Users on item.CreateBy equals itemND.MaU into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.Quan == Quan && item.CreateBy == CreateBy
                        select new
                        {
                            item.ID,
                            item.DanhBo,
                            item.SDT,
                            item.Quan,
                            item.Thung,
                            item.STT,
                            item.CreateDate,
                            DinhMucMoi = item.DCBD_DKDM_CCCDs.Count * 4,
                            item.DCBD,
                            item.DCBD_MaDon,
                            item.DCBD_STT,
                            CreateBy = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_Quan_Thung(string Quan, int Thung)
        {
            var query = from item in db.DCBD_DKDM_DanhBos
                        join itemND in db.Users on item.CreateBy equals itemND.MaU into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.Quan == Quan && item.Thung == Thung && item.CreateBy != null
                        orderby item.ID ascending
                        select new
                        {
                            item.ID,
                            item.DanhBo,
                            item.SDT,
                            item.Quan,
                            item.Thung,
                            item.STT,
                            item.CreateDate,
                            DinhMucMoi = item.DCBD_DKDM_CCCDs.Count * 4,
                            item.DCBD,
                            item.DCBD_MaDon,
                            item.DCBD_STT,
                            CreateBy = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_Quan_Thung(int CreateBy, string Quan, int Thung)
        {
            var query = from item in db.DCBD_DKDM_DanhBos
                        join itemND in db.Users on item.CreateBy equals itemND.MaU into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.Quan == Quan && item.Thung == Thung && item.CreateBy == CreateBy
                        orderby item.ID ascending
                        select new
                        {
                            item.ID,
                            item.DanhBo,
                            item.SDT,
                            item.Quan,
                            item.Thung,
                            item.STT,
                            item.CreateDate,
                            DinhMucMoi = item.DCBD_DKDM_CCCDs.Count * 4,
                            item.DCBD,
                            item.DCBD_MaDon,
                            item.DCBD_STT,
                            CreateBy = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.DCBD_DKDM_DanhBos
                        join itemND in db.Users on item.CreateBy equals itemND.MaU into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.CreateDate.Date >= FromCreateDate.Date && item.CreateDate.Date <= ToCreateDate.Date && item.CreateBy != null
                        orderby item.ID ascending
                        select new
                        {
                            item.ID,
                            item.DanhBo,
                            item.SDT,
                            item.Quan,
                            item.Thung,
                            item.STT,
                            item.CreateDate,
                            CreateBy = itemtableND.HoTen,
                            DinhMucMoi = item.DCBD_DKDM_CCCDs.Count * 4,
                            item.DCBD,
                            item.DCBD_MaDon,
                            item.DCBD_STT,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_KiemTra_Tang(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select ID,DanhBo,SDT,Quan,Thung,a.STT,a.CreateDate,CreateBy = b.HoTen,DCBD,DCBD_MaDon,DCBD_STT"
                        + " ,DinhMucCu=(select top 1 DM from server9.HOADON_TA.dbo.HOADON where DANHBA=a.DanhBo order by ID_HOADON desc)"
                        + " ,DinhMucMoi = (select COUNT(*) from DCBD_DKDM_CCCD where IDDanhBo=a.ID)*4"
                        + " from DCBD_DKDM_DanhBo a,Users b where a.CreateBy=b.MaU"
                        + " and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'"
                        + " and (select top 1 DM from server9.HOADON_TA.dbo.HOADON where DANHBA=a.DanhBo order by ID_HOADON desc)<(select COUNT(*) from DCBD_DKDM_CCCD where IDDanhBo=a.ID)*4"
                        + " order by a.ID asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_KiemTra_Giam(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select ID,DanhBo,SDT,Quan,Thung,a.STT,a.CreateDate,CreateBy = b.HoTen,DCBD,DCBD_MaDon,DCBD_STT"
                        + " ,DinhMucCu=(select top 1 DM from server9.HOADON_TA.dbo.HOADON where DANHBA=a.DanhBo order by ID_HOADON desc)"
                        + " ,DinhMucMoi = (select COUNT(*) from DCBD_DKDM_CCCD where IDDanhBo=a.ID)*4"
                        + " from DCBD_DKDM_DanhBo a,Users b where a.CreateBy=b.MaU"
                        + " and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'"
                        + " and (select top 1 DM from server9.HOADON_TA.dbo.HOADON where DANHBA=a.DanhBo order by ID_HOADON desc)>(select COUNT(*) from DCBD_DKDM_CCCD where IDDanhBo=a.ID)*4"
                        + " order by a.ID asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_KiemTra_GiuNguyen(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select ID,DanhBo,SDT,Quan,Thung,a.STT,a.CreateDate,CreateBy = b.HoTen,DCBD,DCBD_MaDon,DCBD_STT"
                        + " ,DinhMucCu=(select top 1 DM from server9.HOADON_TA.dbo.HOADON where DANHBA=a.DanhBo order by ID_HOADON desc)"
                        + " ,DinhMucMoi = (select COUNT(*) from DCBD_DKDM_CCCD where IDDanhBo=a.ID)*4"
                        + " from DCBD_DKDM_DanhBo a,Users b where a.CreateBy=b.MaU"
                        + " and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'"
                        + " and (select top 1 DM from server9.HOADON_TA.dbo.HOADON where DANHBA=a.DanhBo order by ID_HOADON desc)=(select COUNT(*) from DCBD_DKDM_CCCD where IDDanhBo=a.ID)*4"
                        + " order by a.ID asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS(int CreateBy, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.DCBD_DKDM_DanhBos
                        join itemND in db.Users on item.CreateBy equals itemND.MaU into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.CreateDate.Date >= FromCreateDate.Date && item.CreateDate.Date <= ToCreateDate.Date && item.CreateBy == CreateBy
                        orderby item.ID ascending
                        select new
                        {
                            item.ID,
                            item.DanhBo,
                            item.SDT,
                            item.Quan,
                            item.Thung,
                            item.STT,
                            item.CreateDate,
                            CreateBy = itemtableND.HoTen,
                            DinhMucMoi = item.DCBD_DKDM_CCCDs.Count * 4,
                            item.DCBD,
                            item.DCBD_MaDon,
                            item.DCBD_STT,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_Online(string DanhBo)
        {
            var query = from item in db.DCBD_DKDM_DanhBos
                        where item.DanhBo == DanhBo
                        orderby item.ID ascending
                        select new
                        {
                            item.ID,
                            item.DanhBo,
                            item.SDT,
                            SoNK = item.DCBD_DKDM_CCCDs.Count,
                            item.CreateDate,
                            CreateBy = item.CreateBy != null ? "Thương Vụ" : "Khách Hàng",
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_Online(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.DCBD_DKDM_DanhBos
                        where item.CreateDate.Date >= FromCreateDate.Date && item.CreateDate.Date <= ToCreateDate.Date && item.CreateBy == null
                        orderby item.ID ascending
                        select new
                        {
                            item.ID,
                            item.DanhBo,
                            item.SDT,
                            SoNK = item.DCBD_DKDM_CCCDs.Count,
                            item.CreateDate,
                            CreateBy = item.CreateBy != null ? "Thương Vụ" : "Khách Hàng",
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_NguoiLap()
        {
            return ExecuteQuery_DataTable("select Name=(select HoTen from Users where MaU=DCBD_DKDM_DanhBo.CreateBy),ID=CreateBy from DCBD_DKDM_DanhBo where CreateBy is not null group by CreateBy");
        }

    }
}

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
                    if (db.DCBD_DKDM_DanhBos.Where(item => item.Quan == en.Quan && item.Thung == ThungMax).Max(item => item.STT) == 300)
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
                if (db.DCBD_DKDM_DanhBos.Where(item => item.Quan == en.Quan).Max(item => item.Thung) == null)
                {
                    en.Thung = 1;
                    en.STT = 1;
                }
                else
                {
                    int ThungMax = db.DCBD_DKDM_DanhBos.Where(item => item.Quan == en.Quan).Max(item => item.Thung).Value;
                    if (db.DCBD_DKDM_DanhBos.Where(item => item.Quan == en.Quan && item.Thung == ThungMax).Max(item => item.STT) == 300)
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
                en.CreateDate_Old = en.CreateDate;
                en.CreateDate = DateTime.Now;
                en.CreateBy = CTaiKhoan.MaUser;

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
            //var query = from item in db.DCBD_DKDM_DanhBos
            //            join itemND in db.Users on item.CreateBy equals itemND.MaU into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            where item.DanhBo == DanhBo && item.CreateBy != null
            //            select new
            //            {
            //                item.ID,
            //                item.DanhBo,
            //                item.GiaBieu,
            //                item.DinhMuc,
            //                item.SDT,
            //                item.Quan,
            //                item.Thung,
            //                item.STT,
            //                item.CreateDate,
            //                DinhMucMoi = item.DCBD_DKDM_CCCDs.Count * 4,
            //                item.MaDon,
            //                item.DaXuLy,
            //                item.GhiChu,
            //                item.DCBD,
            //                item.DCBD_MaDon,
            //                item.DCBD_STT,
            //                CreateBy = itemtableND.HoTen,
            //                DiaChi = dbThuTien.HOADONs.Where(hd => hd.DANHBA == item.DanhBo).OrderByDescending(hd => hd.CreateDate).FirstOrDefault().SO + " " + dbThuTien.HOADONs.Where(hd => hd.DANHBA == item.DanhBo).OrderByDescending(hd => hd.CreateDate).FirstOrDefault().DUONG,
            //                Phuong = dbThuTien.HOADONs.Where(hd => hd.DANHBA == item.DanhBo).OrderByDescending(hd => hd.CreateDate).FirstOrDefault().Phuong
            //            };
            //return LINQToDataTable(query);
            return ExecuteQuery_DataTable("select CreateBy=s.HoTen,db.*,DinhMucMoi=(select count(*)*4 from DCBD_DKDM_CCCD where IDDanhBo=db.ID)"
+ " ,DiaChi=ttkh.SONHA+' '+ttkh.TENDUONG,ttkh.PHUONG"
+ " from DCBD_DKDM_DanhBo db left join Users s on s.MaU=db.CreateBy,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh"
+ " where db.DanhBo=ttkh.DANHBO and db.DanhBo='" + DanhBo + "' and db.CreateBy is not null");
        }

        public DataTable getDS_Quan(string Quan)
        {
            //var query = from item in db.DCBD_DKDM_DanhBos
            //            join itemND in db.Users on item.CreateBy equals itemND.MaU into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            where item.Quan == Quan && item.CreateBy != null
            //            select new
            //            {
            //                item.ID,
            //                item.DanhBo,
            //                item.GiaBieu,
            //                item.DinhMuc,
            //                item.SDT,
            //                item.Quan,
            //                item.Thung,
            //                item.STT,
            //                item.CreateDate,
            //                DinhMucMoi = item.DCBD_DKDM_CCCDs.Count * 4,
            //                item.MaDon,
            //                item.DaXuLy,
            //                item.GhiChu,
            //                item.DCBD,
            //                item.DCBD_MaDon,
            //                item.DCBD_STT,
            //                CreateBy = itemtableND.HoTen,
            //            };
            //return LINQToDataTable(query);
            return ExecuteQuery_DataTable("select CreateBy=s.HoTen,db.*,DinhMucMoi=(select count(*)*4 from DCBD_DKDM_CCCD where IDDanhBo=db.ID)"
+ " ,DiaChi=ttkh.SONHA+' '+ttkh.TENDUONG,ttkh.PHUONG"
+ " from DCBD_DKDM_DanhBo db left join Users s on s.MaU=db.CreateBy,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh"
+ " where db.DanhBo=ttkh.DANHBO and db.Quan='" + Quan + "' and db.CreateBy is not null");
        }

        public DataTable getDS_Quan(int CreateBy, string Quan)
        {
            //var query = from item in db.DCBD_DKDM_DanhBos
            //            join itemND in db.Users on item.CreateBy equals itemND.MaU into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            where item.Quan == Quan && item.CreateBy == CreateBy
            //            select new
            //            {
            //                item.ID,
            //                item.DanhBo,
            //                item.GiaBieu,
            //                item.DinhMuc,
            //                item.SDT,
            //                item.Quan,
            //                item.Thung,
            //                item.STT,
            //                item.CreateDate,
            //                DinhMucMoi = item.DCBD_DKDM_CCCDs.Count * 4,
            //                item.MaDon,
            //                item.DaXuLy,
            //                item.GhiChu,
            //                item.DCBD,
            //                item.DCBD_MaDon,
            //                item.DCBD_STT,
            //                CreateBy = itemtableND.HoTen,
            //            };
            //return LINQToDataTable(query);
            return ExecuteQuery_DataTable("select CreateBy=s.HoTen,db.*,DinhMucMoi=(select count(*)*4 from DCBD_DKDM_CCCD where IDDanhBo=db.ID)"
+ " ,DiaChi=ttkh.SONHA+' '+ttkh.TENDUONG,ttkh.PHUONG"
+ " from DCBD_DKDM_DanhBo db left join Users s on s.MaU=db.CreateBy,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh"
+ " where db.DanhBo=ttkh.DANHBO and db.Quan='" + Quan + "' and db.CreateBy=" + CreateBy);
        }

        public DataTable getDS_Quan_Thung(string Quan, int Thung)
        {
            //var query = from item in db.DCBD_DKDM_DanhBos
            //            join itemND in db.Users on item.CreateBy equals itemND.MaU into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            where item.Quan == Quan && item.Thung == Thung && item.CreateBy != null
            //            orderby item.ID ascending
            //            select new
            //            {
            //                item.ID,
            //                item.DanhBo,
            //                item.GiaBieu,
            //                item.DinhMuc,
            //                item.SDT,
            //                item.Quan,
            //                item.Thung,
            //                item.STT,
            //                item.CreateDate,
            //                DinhMucMoi = item.DCBD_DKDM_CCCDs.Count * 4,
            //                item.MaDon,
            //                item.DaXuLy,
            //                item.GhiChu,
            //                item.DCBD,
            //                item.DCBD_MaDon,
            //                item.DCBD_STT,
            //                CreateBy = itemtableND.HoTen,
            //            };
            //return LINQToDataTable(query);
            return ExecuteQuery_DataTable("select CreateBy=s.HoTen,db.*,DinhMucMoi=(select count(*)*4 from DCBD_DKDM_CCCD where IDDanhBo=db.ID)"
+ " ,DiaChi=ttkh.SONHA+' '+ttkh.TENDUONG,ttkh.PHUONG"
+ " from DCBD_DKDM_DanhBo db left join Users s on s.MaU=db.CreateBy,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh"
+ " where db.DanhBo=ttkh.DANHBO and db.Quan='" + Quan + "' and db.Thung=" + Thung + " and db.CreateBy is not null");
        }

        public DataTable getDS_Quan_Thung(int CreateBy, string Quan, int Thung)
        {
            //var query = from item in db.DCBD_DKDM_DanhBos
            //            join itemND in db.Users on item.CreateBy equals itemND.MaU into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            where item.Quan == Quan && item.Thung == Thung && item.CreateBy == CreateBy
            //            orderby item.ID ascending
            //            select new
            //            {
            //                item.ID,
            //                item.DanhBo,
            //                item.GiaBieu,
            //                item.DinhMuc,
            //                item.SDT,
            //                item.Quan,
            //                item.Thung,
            //                item.STT,
            //                item.CreateDate,
            //                DinhMucMoi = item.DCBD_DKDM_CCCDs.Count * 4,
            //                item.MaDon,
            //                item.DaXuLy,
            //                item.GhiChu,
            //                item.DCBD,
            //                item.DCBD_MaDon,
            //                item.DCBD_STT,
            //                CreateBy = itemtableND.HoTen,
            //            };
            //return LINQToDataTable(query);
            return ExecuteQuery_DataTable("select CreateBy=s.HoTen,db.*,DinhMucMoi=(select count(*)*4 from DCBD_DKDM_CCCD where IDDanhBo=db.ID)"
+ " ,DiaChi=ttkh.SONHA+' '+ttkh.TENDUONG,ttkh.PHUONG"
+ " from DCBD_DKDM_DanhBo db left join Users s on s.MaU=db.CreateBy,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh"
+ " where db.DanhBo=ttkh.DANHBO and db.Quan='" + Quan + "' and db.Thung=" + Thung + " and db.CreateBy=" + CreateBy);
        }

        public DataTable getDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            //var query = from item in db.DCBD_DKDM_DanhBos
            //            join itemND in db.Users on item.CreateBy equals itemND.MaU into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            where item.CreateDate.Date >= FromCreateDate.Date && item.CreateDate.Date <= ToCreateDate.Date && item.CreateBy != null
            //            orderby item.ID ascending
            //            select new
            //            {
            //                item.ID,
            //                item.DanhBo,
            //                item.GiaBieu,
            //                item.DinhMuc,
            //                item.SDT,
            //                item.Quan,
            //                item.Thung,
            //                item.STT,
            //                item.CreateDate,
            //                CreateBy = itemtableND.HoTen,
            //                DinhMucMoi = item.DCBD_DKDM_CCCDs.Count * 4,
            //                item.MaDon,
            //                item.DaXuLy,
            //                item.GhiChu,
            //                item.DCBD,
            //                item.DCBD_MaDon,
            //                item.DCBD_STT,
            //            };
            //return LINQToDataTable(query);
            return ExecuteQuery_DataTable("select CreateBy=s.HoTen,db.*,DinhMucMoi=(select count(*)*4 from DCBD_DKDM_CCCD where IDDanhBo=db.ID)"
+ " ,DiaChi=ttkh.SONHA+' '+ttkh.TENDUONG,ttkh.PHUONG"
+ " from DCBD_DKDM_DanhBo db left join Users s on s.MaU=db.CreateBy,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh"
+ " where db.DanhBo=ttkh.DANHBO and cast(db.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and cast(db.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and db.CreateBy is not null");
        }

        public DataTable getDS(int CreateBy, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            //var query = from item in db.DCBD_DKDM_DanhBos
            //            join itemND in db.Users on item.CreateBy equals itemND.MaU into tableND
            //            from itemtableND in tableND.DefaultIfEmpty()
            //            where item.CreateDate.Date >= FromCreateDate.Date && item.CreateDate.Date <= ToCreateDate.Date && item.CreateBy == CreateBy
            //            orderby item.ID ascending
            //            select new
            //            {
            //                item.ID,
            //                item.DanhBo,
            //                item.GiaBieu,
            //                item.DinhMuc,
            //                item.SDT,
            //                item.Quan,
            //                item.Thung,
            //                item.STT,
            //                item.CreateDate,
            //                CreateBy = itemtableND.HoTen,
            //                DinhMucMoi = item.DCBD_DKDM_CCCDs.Count * 4,
            //                item.DaXuLy,
            //                item.GhiChu,
            //                item.DCBD,
            //                item.DCBD_MaDon,
            //                item.DCBD_STT,
            //            };
            //return LINQToDataTable(query);
            return ExecuteQuery_DataTable("select CreateBy=s.HoTen,db.*,DinhMucMoi=(select count(*)*4 from DCBD_DKDM_CCCD where IDDanhBo=db.ID)"
+ " ,DiaChi=ttkh.SONHA+' '+ttkh.TENDUONG,ttkh.PHUONG"
+ " from DCBD_DKDM_DanhBo db left join Users s on s.MaU=db.CreateBy,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh"
+ " where db.DanhBo=ttkh.DANHBO and cast(db.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and cast(db.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and db.CreateBy=" + CreateBy);
        }

        public DataTable getDS_FileScan(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.DCBD_DKDM_DanhBos
                        join itemH in db.DCBD_DKDM_DanhBo_Hinhs on item.ID equals itemH.IDParent
                        join itemND in db.Users on item.CreateBy equals itemND.MaU into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemH.CreateDate.Value.Date >= FromCreateDate.Date && itemH.CreateDate.Value.Date <= ToCreateDate.Date && item.CreateBy != null
                        orderby item.ID ascending
                        select new
                        {
                            item.ID,
                            item.DanhBo,
                            item.GiaBieu,
                            item.DinhMuc,
                            item.SDT,
                            item.Quan,
                            item.Thung,
                            item.STT,
                            item.CreateDate,
                            CreateBy = itemtableND.HoTen,
                            DinhMucMoi = item.DCBD_DKDM_CCCDs.Count * 4,
                            item.MaDon,
                            item.DaXuLy,
                            item.GhiChu,
                            item.DCBD,
                            item.DCBD_MaDon,
                            item.DCBD_STT,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet(string IDDanhBo)
        {
            return ExecuteQuery_DataTable("select [ID],[IDDanhBo],[CCCD],[HoTen],[NgaySinh]=convert(char(10),NgaySinh,103)"
              + ",[DCThuongTru],[DCTamTru],[KhongKiemTra],[KhacDiaBan],[cmbChiNhanh],[ThuongTru],[TamTru]"
              + ",[NgayHetHan]=convert(char(10),[NgayHetHan],103) FROM [KTKS_DonKH].[dbo].[DCBD_DKDM_CCCD] where IDDanhBo=" + IDDanhBo);
        }

        public DataTable getDS_KiemTra_Tang(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select ID,DanhBo,SDT,Quan,Thung,a.STT,a.CreateDate,CreateBy = b.HoTen,MaDon,DaXuLy,DCBD,DCBD_MaDon,DCBD_STT,GhiChu"
                        + " ,DinhMucCu=(select top 1 DM from HOADON_TA.dbo.HOADON where DANHBA=a.DanhBo and cast(CreateDate as date)<=cast(a.CreateDate as date) order by ID_HOADON desc)"
                        + " ,DinhMucMoi = (select COUNT(*) from DCBD_DKDM_CCCD where IDDanhBo=a.ID)*4"
                        + " from DCBD_DKDM_DanhBo a,Users b where a.CreateBy=b.MaU"
                        + " and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'"
                        + " and (select top 1 DM from HOADON_TA.dbo.HOADON where DANHBA=a.DanhBo and cast(CreateDate as date)<=cast(a.CreateDate as date) order by ID_HOADON desc)<(select COUNT(*) from DCBD_DKDM_CCCD where IDDanhBo=a.ID)*4"
                        + " order by a.ID asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_KiemTra_Giam(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select ID,DanhBo,SDT,Quan,Thung,a.STT,a.CreateDate,CreateBy = b.HoTen,MaDon,DaXuLy,DCBD,DCBD_MaDon,DCBD_STT,GhiChu"
                        + " ,DinhMucCu=(select top 1 DM from HOADON_TA.dbo.HOADON where DANHBA=a.DanhBo and cast(CreateDate as date)<=cast(a.CreateDate as date) order by ID_HOADON desc)"
                        + " ,DinhMucMoi = (select COUNT(*) from DCBD_DKDM_CCCD where IDDanhBo=a.ID)*4"
                        + " from DCBD_DKDM_DanhBo a,Users b where a.CreateBy=b.MaU"
                        + " and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'"
                        + " and (select top 1 DM from HOADON_TA.dbo.HOADON where DANHBA=a.DanhBo and cast(CreateDate as date)<=cast(a.CreateDate as date) order by ID_HOADON desc)>(select COUNT(*) from DCBD_DKDM_CCCD where IDDanhBo=a.ID)*4"
                        + " order by a.ID asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_KiemTra_GiuNguyen(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select ID,DanhBo,SDT,Quan,Thung,a.STT,a.CreateDate,CreateBy = b.HoTen,MaDon,DaXuLy,DCBD,DCBD_MaDon,DCBD_STT,GhiChu"
                        + " ,DinhMucCu=(select top 1 DM from HOADON_TA.dbo.HOADON where DANHBA=a.DanhBo and cast(CreateDate as date)<=cast(a.CreateDate as date) order by ID_HOADON desc)"
                        + " ,DinhMucMoi = (select COUNT(*) from DCBD_DKDM_CCCD where IDDanhBo=a.ID)*4"
                        + " from DCBD_DKDM_DanhBo a,Users b where a.CreateBy=b.MaU"
                        + " and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'"
                        + " and (select top 1 DM from HOADON_TA.dbo.HOADON where DANHBA=a.DanhBo and cast(CreateDate as date)<=cast(a.CreateDate as date) order by ID_HOADON desc)=(select COUNT(*) from DCBD_DKDM_CCCD where IDDanhBo=a.ID)*4"
                        + " order by a.ID asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_KiemTra_All(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select ID,DanhBo,SDT,Quan,Thung,a.STT,a.CreateDate,CreateBy = b.HoTen,MaDon,DaXuLy,DCBD,DCBD_MaDon,DCBD_STT,GhiChu"
                        + " ,DinhMucCu=(select top 1 DM from HOADON_TA.dbo.HOADON where DANHBA=a.DanhBo and cast(CreateDate as date)<=cast(a.CreateDate as date) order by ID_HOADON desc)"
                        + " ,DinhMucMoi = (select COUNT(*) from DCBD_DKDM_CCCD where IDDanhBo=a.ID)*4"
                        + " from DCBD_DKDM_DanhBo a,Users b where a.CreateBy=b.MaU"
                        + " and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'"
                        + " order by a.ID asc";
            return ExecuteQuery_DataTable(sql);
        }


        public DataTable getDS_Online(string DanhBo)
        {
            return ExecuteQuery_DataTable("select 'In'='false',db.ID,Dot=SUBSTRING(ttkh.LOTRINH, 1, 2),ttkh.DANHBO,DiaChi=ttkh.SONHA+' '+ttkh.TENDUONG,db.GiaBieu,db.DinhMuc,db.SDT,SoNK=(select COUNT(*) from KTKS_DonKH.dbo.DCBD_DKDM_CCCD where IDDanhBo=db.ID)"
                + " ,db.CreateDate,CreateBy=case when db.CreateBy is not null then N'Thương Vụ' else N'Khách Hàng' end,db.DCBD,db.DaXuLy,db.HieuLucKy,dcbd.* from KTKS_DonKH.dbo.DCBD_DKDM_DanhBo db,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh"
                + " LEFT JOIN ("
                + " SELECT DCBD_SoPhieu=MaCTDCBD,DCBD_CreateDate=CONVERT(char(10),CreateDate,103),DCBD_ThongTin=ThongTin,DCBD_DinhMucBD=DinhMuc_BD,DanhBo, ROW_NUMBER() OVER (PARTITION BY DanhBo ORDER BY CreateDate desc) AS RowNum"
                + " FROM KTKS_DonKH.dbo.DCBD_ChiTietBienDong) dcbd ON ttkh.DANHBO = dcbd.DanhBo And RowNum = 1"
                + " where db.DanhBo=ttkh.DANHBO and ttkh.DANHBO='" + DanhBo + "' and db.CreateBy is null order by db.ID asc");
        }

        public DataTable getDS_Online(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return ExecuteQuery_DataTable("select 'In'='false',db.ID,Dot=SUBSTRING(ttkh.LOTRINH, 1, 2),ttkh.DANHBO,DiaChi=ttkh.SONHA+' '+ttkh.TENDUONG,db.GiaBieu,db.DinhMuc,db.SDT,SoNK=(select COUNT(*) from KTKS_DonKH.dbo.DCBD_DKDM_CCCD where IDDanhBo=db.ID)"
                + " ,db.CreateDate,CreateBy=case when db.CreateBy is not null then N'Thương Vụ' else N'Khách Hàng' end,db.DCBD,db.DaXuLy,db.HieuLucKy,dcbd.* from KTKS_DonKH.dbo.DCBD_DKDM_DanhBo db,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh"
                + " LEFT JOIN ("
                + " SELECT DCBD_SoPhieu=MaCTDCBD,DCBD_CreateDate=CONVERT(char(10),CreateDate,103),DCBD_ThongTin=ThongTin,DCBD_DinhMucBD=DinhMuc_BD,DanhBo, ROW_NUMBER() OVER (PARTITION BY DanhBo ORDER BY CreateDate desc) AS RowNum"
                + " FROM KTKS_DonKH.dbo.DCBD_ChiTietBienDong) dcbd ON ttkh.DANHBO = dcbd.DanhBo And RowNum = 1"
                + " where db.DanhBo=ttkh.DANHBO and CAST(db.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(db.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and db.CreateBy is null order by db.ID asc");
        }

        public DataTable getDS_NguoiLap()
        {
            return ExecuteQuery_DataTable("select Name=(select HoTen from Users where MaU=DCBD_DKDM_DanhBo.CreateBy),ID=CreateBy from DCBD_DKDM_DanhBo where CreateBy is not null group by CreateBy");
        }

        #region Hình

        public bool Them_Hinh(DCBD_DKDM_DanhBo_Hinh en)
        {
            try
            {
                if (db.DCBD_DKDM_DanhBo_Hinhs.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = db.DCBD_DKDM_DanhBo_Hinhs.Max(item => item.ID) + 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.DCBD_DKDM_DanhBo_Hinhs.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_Hinh(DCBD_DKDM_DanhBo_Hinh en)
        {
            try
            {
                db.DCBD_DKDM_DanhBo_Hinhs.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public DCBD_DKDM_DanhBo_Hinh get_Hinh(int ID)
        {
            return db.DCBD_DKDM_DanhBo_Hinhs.SingleOrDefault(item => item.ID == ID);
        }

        #endregion

    }
}

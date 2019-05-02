using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.DonTu
{
    class CDonTu : CDAL
    {
        public bool Them(LinQ.DonTu entity)
        {
            try
            {
                if (db.DonTus.Any(item => item.NamThang == DateTime.Now.ToString("yyMM")) == true)
                {
                    entity.STT = (int.Parse(db.DonTus.Where(item => item.NamThang == DateTime.Now.ToString("yyMM")).Max(item => item.STT)) + 1).ToString("0000");
                }
                else
                {
                    entity.STT = 1.ToString("0000");
                }
                entity.NamThang = DateTime.Now.ToString("yyMM");
                entity.MaDon = int.Parse(entity.NamThang + entity.STT);
                entity.CreateBy = CTaiKhoan.MaUser;
                entity.CreateDate = DateTime.Now;
                db.DonTus.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(LinQ.DonTu entity)
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
                throw ex;
            }
        }

        public bool Xoa(LinQ.DonTu entity)
        {
            try
            {
                db.DonTu_ChiTiets.DeleteAllOnSubmit(entity.DonTu_ChiTiets.ToList());
                db.DonTus.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist(int MaDon)
        {
            return db.DonTus.Any(item => item.MaDon == MaDon);
        }

        public LinQ.DonTu get(int MaDon)
        {
            return db.DonTus.SingleOrDefault(item => item.MaDon == MaDon);
        }

        public DataTable getDS(int MaDon)
        {
            var query = from item in db.DonTus
                        where item.MaDon == MaDon
                        select new
                        {
                            item.MaDon,
                            item.SoCongVan,
                            item.CreateDate,
                            DanhBo = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
                            HoTen = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
                            DiaChi = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DiaChi : "",
                            NoiDung = item.Name_NhomDon,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS(int FromMaDon, int ToMaDon)
        {
            var query = from item in db.DonTus
                        where item.MaDon >= FromMaDon && item.MaDon <= ToMaDon
                        select new
                        {
                            item.MaDon,
                            item.SoCongVan,
                            item.CreateDate,
                            DanhBo = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
                            HoTen = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
                            DiaChi = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DiaChi : "",
                            NoiDung = item.Name_NhomDon,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSBySoCongVan(string SoCongVan)
        {
            var query = from item in db.DonTus
                        where item.SoCongVan == SoCongVan
                        select new
                        {
                            item.MaDon,
                            item.SoCongVan,
                            item.CreateDate,
                            DanhBo = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
                            HoTen = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
                            DiaChi = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DiaChi : "",
                            NoiDung = item.Name_NhomDon,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.DonTus
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            item.MaDon,
                            item.SoCongVan,
                            item.CreateDate,
                            DanhBo = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
                            HoTen = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
                            DiaChi = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DiaChi : "",
                            NoiDung = item.Name_NhomDon,
                        };
            return LINQToDataTable(query);
        }

        // chi tiết

        public bool Them_ChiTiet(DonTu_ChiTiet en)
        {
            try
            {
                if (db.DonTu_ChiTiets.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = db.DonTu_ChiTiets.Max(item => item.ID) + 1;
                en.STT = db.DonTu_ChiTiets.Where(item => item.MaDon == en.MaDon).Max(item => item.STT) + 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.DonTu_ChiTiets.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_ChiTiet(DonTu_ChiTiet en)
        {
            try
            {
                db.DonTu_ChiTiets.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public int getMaxID_ChiTiet()
        {
            if (db.DonTu_ChiTiets.Count() == 0)
                return 0;
            else
                return db.DonTu_ChiTiets.Max(item => item.ID);
        }

        public bool checkExist_ChiTiet(string DanhBo, string HoTen, string DiaChi, DateTime CreateDate)
        {
            return db.DonTu_ChiTiets.Any(item => item.DanhBo == DanhBo && item.HoTen == HoTen && item.DiaChi == DiaChi && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public DonTu_ChiTiet get_ChiTiet(int ID)
        {
            return db.DonTu_ChiTiets.SingleOrDefault(item => item.ID == ID);
        }

        public DonTu_ChiTiet get_ChiTiet(int MaDon, int STT)
        {
            return db.DonTu_ChiTiets.SingleOrDefault(item => item.MaDon == MaDon && item.STT == STT);
        }

        public DataTable getDS_ChiTiet_ByDanhBo(string DanhBo)
        {
            var query = from item in db.DonTu_ChiTiets
                        where item.DanhBo == DanhBo
                        select new
                        {
                            item.MaDon,
                            item.DonTu.SoCongVan,
                            item.CreateDate,
                            DanhBo = item.DonTu.DonTu_ChiTiets.Count == 1 ? item.DonTu.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
                            HoTen = item.DonTu.DonTu_ChiTiets.Count == 1 ? item.DonTu.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
                            DiaChi = item.DonTu.DonTu_ChiTiets.Count == 1 ? item.DonTu.DonTu_ChiTiets.SingleOrDefault().DiaChi : "",
                            NoiDung = item.DonTu.Name_NhomDon,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ThongKeNhomDon(string TenTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            if (TenTo == "ToGD")
            {
                string sql = ";WITH dtls_temp AS"
                            + " ("
                            + " SELECT dtls.*,ROW_NUMBER() OVER (PARTITION BY dtls.MaDon,dtls.STT ORDER BY dtls.NgayChuyen asc,dtls.ID asc) AS rn"
                            + " FROM DonTu_ChiTiet dtct, DonTu_LichSu dtls"
                            + " where cast(dtct.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and cast(dtct.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and dtct.MaDon=dtls.MaDon and dtct.STT=dtls.STT"
                            + " )"
                            + " select dt.MaDon,NhomDon=dt.Name_NhomDon,dt.TongDB,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,"
                            + " MaDonChiTiet=case when dt.TongDB=0 then CONVERT(varchar(8),dtct.MaDon)"
                            + "            when dt.TongDB=1 then CONVERT(varchar(8),dtct.MaDon)"
                            + "            when dt.TongDB>=2 then CONVERT(varchar(8),dtct.MaDon)+'.'+CONVERT(varchar(3),dtct.STT) end,"
                            + " ChuyenToTP=case when exists(select ID from dtls_temp where rn=1 and dtls_temp.MaDon=dtct.MaDon and dtls_temp.STT=dtct.STT and ID_NoiNhan=2) then 'true' else 'false' end,"
                            + " ChuyenToTB=case when exists(select ID from dtls_temp where rn=1 and dtls_temp.MaDon=dtct.MaDon and dtls_temp.STT=dtct.STT and ID_NoiNhan=3) then 'true' else 'false' end,"
                            + " ChuyenToBC=case when exists(select ID from dtls_temp where rn=1 and dtls_temp.MaDon=dtct.MaDon and dtls_temp.STT=dtct.STT and ID_NoiNhan=4) then 'true' else 'false' end,"
                            + " ChuyenKhac=case when exists(select ID from dtls_temp where rn=1 and dtls_temp.MaDon=dtct.MaDon and dtls_temp.STT=dtct.STT and ID_NoiNhan!=2 and ID_NoiNhan!=3 and ID_NoiNhan!=4) then 'true' else 'false' end"
                            + " from DonTu dt,DonTu_ChiTiet dtct where CAST(dt.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(dt.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and dt.MaDon=dtct.MaDon"
                            + " order by dtct.MaDon,dtct.STT asc";
                return ExecuteQuery_DataTable(sql);
            }
            else
            {
                string sql = ";WITH dtls_temp AS"
                            + " ("
                            + " SELECT dtls.*,ROW_NUMBER() OVER (PARTITION BY dtls.MaDon,dtls.STT ORDER BY dtls.NgayChuyen asc,dtls.ID asc) AS rn"
                            + " FROM DonTu_ChiTiet dtct, DonTu_LichSu dtls"
                            + " where cast(dtct.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and cast(dtct.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and dtct.MaDon=dtls.MaDon and dtct.STT=dtls.STT"
                            + " )"
                            + " select dt.MaDon,NhomDon=dt.Name_NhomDon,dt.TongDB,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,"
                            + " MaDonChiTiet=case when dt.TongDB=0 then CONVERT(varchar(8),dtls_temp.MaDon)"
                            + " 		   when dt.TongDB=1 then CONVERT(varchar(8),dtls_temp.MaDon)"
                            + " 		   when dt.TongDB>=2 then CONVERT(varchar(8),dtls_temp.MaDon)+'.'+CONVERT(varchar(3),dtls_temp.STT) end,"
                            + " ChuyenTrucTiep=case when exists(select ID from DonTu_LichSu dtls where dtls.MaDon=dtls_temp.MaDon and dtls.STT=dtls_temp.STT and ID_NoiNhan=5) then 'false' else 'true' end,"
                            + " ChuyenKTXM=case when exists(select ID from DonTu_LichSu dtls where dtls.MaDon=dtls_temp.MaDon and dtls.STT=dtls_temp.STT and ID_NoiNhan=5) then 'true' else 'false' end,";
                switch (TenTo)
                {
                    case "ToTB":
                    case "ToTP":
                        sql += " DaKTXM=case when exists(select ID from DonTu_LichSu dtls where dtls.MaDon=dtls_temp.MaDon and dtls.STT=dtls_temp.STT and ID_NoiNhan=5) then"
                            + " case when exists(select ktxm.MaKTXM from KTXM ktxm, KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtls_temp.MaDon and ktxmct.STT=dtls_temp.STT) then 'true' else 'false' end else 'false' end";
                        break;
                    case "ToBC":
                        sql += " DaKTXM=case when exists(select ID from DonTu_LichSu dtls where dtls.MaDon=dtls_temp.MaDon and dtls.STT=dtls_temp.STT and ID_NoiNhan=5) then"
                            + " case when exists(select bc.MaBC from BamChi bc, BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtls_temp.MaDon and bcct.STT=dtls_temp.STT) then 'true'"
                            + " else case when exists(select ktxm.MaKTXM from KTXM ktxm, KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtls_temp.MaDon and ktxmct.STT=dtls_temp.STT) then 'true' else 'false' end end else 'false' end";
                        break;
                }
                sql += " from DonTu dt,DonTu_ChiTiet dtct,dtls_temp where dtls_temp.rn=1 and dt.MaDon=dtct.MaDon and dtct.MaDon=dtls_temp.MaDon and dtct.STT=dtls_temp.STT";
                switch (TenTo)
                {
                    case "ToTB":
                        sql += " and ID_NoiNhan=2";
                        break;
                    case "ToTP":
                        sql += " and ID_NoiNhan=3";
                        break;
                    case "ToBC":
                        sql += " and ID_NoiNhan=4";
                        break;
                }
                sql += " order by dtct.MaDon,dtct.STT asc";
                return ExecuteQuery_DataTable(sql);
            }
        }

        // lịch sử chuyển đơn

        public bool Them_LichSu(DonTu_LichSu entity)
        {
            try
            {
                if (db.DonTu_LichSus.Count() == 0)
                    entity.ID = 1;
                else
                    entity.ID = db.DonTu_LichSus.Max(item => item.ID) + 1;
                entity.CreateBy = CTaiKhoan.MaUser;
                entity.CreateDate = DateTime.Now;
                db.DonTu_LichSus.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Them_LichSu(string NoiChuyen, string NoiDung, int IDCT,int MaDon, int STT)
        {
            try
            {
                DonTu_LichSu entity = new DonTu_LichSu();
                entity.NgayChuyen = DateTime.Now;
                switch (NoiChuyen)
                {
                    case "KTXM":
                        entity.ID_NoiChuyen = 5;
                        entity.NoiChuyen = "Kiểm Tra";
                        entity.NoiDung = "Đã Kiểm Tra, " + NoiDung;
                        entity.TableName = "KTXM_ChiTiet";
                        entity.IDCT = IDCT;
                        entity.NgayChuyen = db.KTXM_ChiTiets.SingleOrDefault(item => item.MaCTKTXM == IDCT).NgayKTXM;
                        break;
                    case "BamChi":
                        entity.ID_NoiChuyen = 5;
                        entity.NoiChuyen = "Kiểm Tra";
                        entity.NoiDung = "Đã Bấm Chì, " + NoiDung;
                        entity.TableName = "BamChi_ChiTiet";
                        entity.IDCT = IDCT;
                        entity.NgayChuyen = db.BamChi_ChiTiets.SingleOrDefault(item => item.MaCTBC == IDCT).NgayBC;
                        break;
                    case "DCBD":
                        entity.ID_NoiChuyen = 6;
                        entity.NoiChuyen = "Điều Chỉnh";
                        entity.NoiDung = "Đã Điều Chỉnh Biến Động, " + NoiDung;
                        entity.TableName = "DCBD_ChiTietBienDong";
                        entity.IDCT = IDCT;
                        break;
                    case "DCHD":
                        entity.ID_NoiChuyen = 6;
                        entity.NoiChuyen = "Điều Chỉnh";
                        entity.NoiDung = "Đã Điều Chỉnh Hóa Đơn, " + NoiDung;
                        entity.TableName = "DCBD_ChiTietHoaDon";
                        entity.IDCT = IDCT;
                        break;
                    case "CTDB":
                        entity.ID_NoiChuyen = 7;
                        entity.NoiChuyen = "Cắt Hủy";
                        entity.NoiDung = "Đã Lập Thông Báo Cắt Tạm, " + NoiDung;
                        entity.TableName = "CHDB_ChiTietCatTam";
                        entity.IDCT = IDCT;
                        break;
                    case "CHDB":
                        entity.ID_NoiChuyen = 7;
                        entity.NoiChuyen = "Cắt Hủy";
                        entity.NoiDung = "Đã Lập Thông Báo Cắt Hủy, " + NoiDung;
                        entity.TableName = "CHDB_ChiTietCatHuy";
                        entity.IDCT = IDCT;
                        break;
                    case "PhieuCHDB":
                        entity.ID_NoiChuyen = 7;
                        entity.NoiChuyen = "Cắt Hủy";
                        entity.NoiDung = "Đã Lập Phiếu Hủy, " + NoiDung;
                        entity.TableName = "CHDB_Phieu";
                        entity.IDCT = IDCT;
                        break;
                    case "TruyThu":
                        entity.ID_NoiChuyen = 8;
                        entity.NoiChuyen = "Truy Thu";
                        entity.NoiDung = "Đã Lập Truy Thu, " + NoiDung;
                        entity.TableName = "TruyThuTienNuoc_ChiTiet";
                        entity.IDCT = IDCT;
                        break;
                    case "TruyThuThuMoi":
                        entity.ID_NoiChuyen = 8;
                        entity.NoiChuyen = "Truy Thu";
                        entity.NoiDung = "Đã Gửi Thư Mời, " + NoiDung;
                        entity.TableName = "TruyThuTienNuoc_ThuMoi";
                        entity.IDCT = IDCT;
                        break;
                    case "GianLan":
                        entity.ID_NoiChuyen = 8;
                        entity.NoiChuyen = "Truy Thu";
                        entity.NoiDung = "Đã Lập Gian Lận, " + NoiDung;
                        entity.TableName = "GianLan_ChiTiet";
                        entity.IDCT = IDCT;
                        break;
                    case "TTTL":
                        entity.ID_NoiChuyen = 9;
                        entity.NoiChuyen = "Thư Trả Lời";
                        entity.NoiDung = "Đã Gửi Thư Trả Lời, " + NoiDung;
                        entity.TableName = "TTTL_ChiTiet";
                        entity.IDCT = IDCT;
                        break;
                    case "ThuMoi":
                        entity.ID_NoiChuyen = 10;
                        entity.NoiChuyen = "Thư Mời";
                        entity.NoiDung = "Đã Gửi Thư Mời, " + NoiDung;
                        entity.TableName = "ThuMoi_ChiTiet";
                        entity.IDCT = IDCT;
                        break;
                    case "ToTrinh":
                        entity.ID_NoiChuyen = 11;
                        entity.NoiChuyen = "Tờ Trình";
                        entity.NoiDung = "Đã Lập Tờ Trình, " + NoiDung;
                        entity.TableName = "ToTrinh_ChiTiet";
                        entity.IDCT = IDCT;
                        break;
                    default:
                        break;
                }
                
                entity.MaDon = MaDon;
                entity.STT = STT;
                if (db.DonTu_LichSus.Count() == 0)
                    entity.ID = 1;
                else
                    entity.ID = db.DonTu_LichSus.Max(item => item.ID) + 1;
                entity.CreateBy = CTaiKhoan.MaUser;
                entity.CreateDate = DateTime.Now;
                db.DonTu_LichSus.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_LichSu(DonTu_LichSu entity)
        {
            try
            {
                db.DonTu_LichSus.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_LichSu(DonTu_LichSu entity,int CreateBy)
        {
            try
            {
                if (entity.CreateBy != CreateBy)
                    return false;
                db.DonTu_LichSus.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public DonTu_LichSu get_LichSu(int ID)
        {
            return db.DonTu_LichSus.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS_LichSu(int MaDon)
        {
            var query = from item in db.DonTu_LichSus
                        join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                        where item.MaDon == MaDon
                        orderby  item.NgayChuyen descending,item.ID descending
                        select new
                        {
                            item.ID,
                            item.NgayChuyen,
                            item.NoiChuyen,
                            item.NoiNhan,
                            item.KTXM,
                            item.NoiDung,
                            CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                            itemDon.MaDon,
                            itemDon.DanhBo,
                            itemDon.DiaChi,
                            NoiDungDon = itemDon.DonTu.Name_NhomDon,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_LichSu(int MaDon, int? STT)
        {
            var query = from item in db.DonTu_LichSus
                        join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                        where item.MaDon == MaDon && item.STT == STT
                        orderby  item.NgayChuyen descending,item.ID descending
                        select new
                        {
                            item.ID,
                            item.NgayChuyen,
                            item.NoiChuyen,
                            item.NoiNhan,
                            item.KTXM,
                            item.NoiDung,
                            CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                            itemDon.MaDon,
                            itemDon.DanhBo,
                            itemDon.DiaChi,
                            NoiDungDon = itemDon.DonTu.Name_NhomDon,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_LichSu(string TenTo, string SoCongVan)
        {
            switch (TenTo)
            {
                case "ToGD":
                    var query = from item in db.DonTu_LichSus
                                join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                                where item.ID_NoiChuyen == 1 && item.DonTu.SoCongVan.Contains(SoCongVan)
                                orderby  item.NgayChuyen descending,item.ID descending
                                select new
                                {
                                    item.ID,
                                    item.NgayChuyen,
                                    item.NoiChuyen,
                                    item.NoiNhan,
                                    item.KTXM,
                                    item.NoiDung,
                                    CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                    MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                    itemDon.DanhBo,
                                    itemDon.DiaChi,
                                    NoiDungDon = itemDon.DonTu.Name_NhomDon,
                                };
                    return LINQToDataTable(query);
                case "ToTB":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 2 && item.DonTu.SoCongVan.Contains(SoCongVan)
                            orderby  item.NgayChuyen descending,item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 3 && item.DonTu.SoCongVan.Contains(SoCongVan)
                            orderby  item.NgayChuyen descending,item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                case "ToBC":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 4 && item.DonTu.SoCongVan.Contains(SoCongVan)
                            orderby  item.NgayChuyen descending,item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.DonTu.SoCongVan.Contains(SoCongVan)
                            orderby  item.NgayChuyen descending,item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_LichSu(string TenTo, int CreateBy, string SoCongVan)
        {
            switch (TenTo)
            {
                case "ToGD":
                    var query = from item in db.DonTu_LichSus
                                join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                                where item.ID_NoiChuyen == 1 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.CreateBy == CreateBy
                                orderby  item.NgayChuyen descending,item.ID descending
                                select new
                                {
                                    item.ID,
                                    item.NgayChuyen,
                                    item.NoiChuyen,
                                    item.NoiNhan,
                                    item.KTXM,
                                    item.NoiDung,
                                    CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                    MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                    itemDon.DanhBo,
                                    itemDon.DiaChi,
                                    NoiDungDon = itemDon.DonTu.Name_NhomDon,
                                };
                    return LINQToDataTable(query);
                case "ToTB":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 2 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.CreateBy == CreateBy
                            orderby  item.NgayChuyen descending,item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 3 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.CreateBy == CreateBy
                            orderby  item.NgayChuyen descending,item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                case "ToBC":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 4 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.CreateBy == CreateBy
                            orderby  item.NgayChuyen descending,item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.DonTu.SoCongVan.Contains(SoCongVan) && item.CreateBy == CreateBy
                            orderby  item.NgayChuyen descending,item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_LichSu(string TenTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            switch (TenTo)
            {
                case "ToGD":
                    var query = from item in db.DonTu_LichSus
                                join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                                where item.ID_NoiChuyen == 1 && item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date
                                orderby item.NgayChuyen descending, item.ID descending
                                select new
                                {
                                    item.ID,
                                    item.NgayChuyen,
                                    item.NoiChuyen,
                                    item.NoiNhan,
                                    item.KTXM,
                                    item.NoiDung,
                                    CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                    MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                    itemDon.DanhBo,
                                    itemDon.DiaChi,
                                    NoiDungDon = itemDon.DonTu.Name_NhomDon,
                                };
                    return LINQToDataTable(query);
                case "ToTB":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 2 && item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 3 && item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                case "ToBC":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 4 && item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_LichSu(string TenTo, int CreateBy, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            switch (TenTo)
            {
                case "ToGD":
                    var query = from item in db.DonTu_LichSus
                                join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                                where (item.ID_NoiChuyen == 1 || item.CreateBy == CreateBy) && item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date
                                orderby item.NgayChuyen descending, item.ID descending
                                select new
                                {
                                    item.ID,
                                    item.NgayChuyen,
                                    item.NoiChuyen,
                                    item.NoiNhan,
                                    item.KTXM,
                                    item.NoiDung,
                                    CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                    MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                    itemDon.DanhBo,
                                    itemDon.DiaChi,
                                    NoiDungDon = itemDon.DonTu.Name_NhomDon,
                                };
                    return LINQToDataTable(query);
                case "ToTB":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where (item.ID_NoiChuyen == 2 || item.CreateBy == CreateBy) && item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where (item.ID_NoiChuyen == 3 || item.CreateBy == CreateBy) && item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                case "ToBC":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where (item.ID_NoiChuyen == 4 || item.CreateBy == CreateBy) && item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date && item.CreateBy == CreateBy
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_LichSu(string TenTo, string SoCongVan, int ID_NoiNhan)
        {
            switch (TenTo)
            {
                case "ToGD":
                    var query = from item in db.DonTu_LichSus
                                join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                                where item.ID_NoiChuyen == 1 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan
                                orderby  item.NgayChuyen descending,item.ID descending
                                select new
                                {
                                    item.ID,
                                    item.NgayChuyen,
                                    item.NoiChuyen,
                                    item.NoiNhan,
                                    item.KTXM,
                                    item.NoiDung,
                                    CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                    MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                    itemDon.DanhBo,
                                    itemDon.DiaChi,
                                    NoiDungDon = itemDon.DonTu.Name_NhomDon,
                                };
                    return LINQToDataTable(query);
                case "ToTB":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 2 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan
                            orderby  item.NgayChuyen descending,item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 3 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan
                            orderby  item.NgayChuyen descending,item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                case "ToBC":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 4 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan
                            orderby  item.NgayChuyen descending,item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan
                            orderby  item.NgayChuyen descending,item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_LichSu(string TenTo, int CreateBy, string SoCongVan, int ID_NoiNhan)
        {
            switch (TenTo)
            {
                case "ToGD":
                    var query = from item in db.DonTu_LichSus
                                join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                                where item.ID_NoiChuyen == 1 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                                orderby  item.NgayChuyen descending,item.ID descending
                                select new
                                {
                                    item.ID,
                                    item.NgayChuyen,
                                    item.NoiChuyen,
                                    item.NoiNhan,
                                    item.KTXM,
                                    item.NoiDung,
                                    CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                    MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                    itemDon.DanhBo,
                                    itemDon.DiaChi,
                                    NoiDungDon = itemDon.DonTu.Name_NhomDon,
                                };
                    return LINQToDataTable(query);
                case "ToTB":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 2 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                            orderby  item.NgayChuyen descending,item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 3 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                            orderby  item.NgayChuyen descending,item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                case "ToBC":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 4 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                            orderby  item.NgayChuyen descending,item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                            orderby  item.NgayChuyen descending,item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_LichSu(string TenTo, DateTime FromCreateDate, DateTime ToCreateDate, int ID_NoiNhan)
        {
            switch (TenTo)
            {
                case "ToGD":
                    var query = from item in db.DonTu_LichSus
                                join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                                where item.ID_NoiChuyen == 1 && item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date && item.ID_NoiNhan == ID_NoiNhan
                                orderby item.NgayChuyen descending, item.ID descending
                                select new
                                {
                                    item.ID,
                                    item.NgayChuyen,
                                    item.NoiChuyen,
                                    item.NoiNhan,
                                    item.KTXM,
                                    item.NoiDung,
                                    CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                    MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                    itemDon.DanhBo,
                                    itemDon.DiaChi,
                                    NoiDungDon = itemDon.DonTu.Name_NhomDon,
                                };
                    return LINQToDataTable(query);
                case "ToTB":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 2 && item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date && item.ID_NoiNhan == ID_NoiNhan
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 3 && item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date && item.ID_NoiNhan == ID_NoiNhan
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                case "ToBC":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 4 && item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date && item.ID_NoiNhan == ID_NoiNhan
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date && item.ID_NoiNhan == ID_NoiNhan
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_LichSu(string TenTo, int CreateBy, DateTime FromCreateDate, DateTime ToCreateDate, int ID_NoiNhan)
        {
            switch (TenTo)
            {
                case "ToGD":
                    var query = from item in db.DonTu_LichSus
                                join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                                where item.ID_NoiChuyen == 1 && item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                                orderby item.NgayChuyen descending, item.ID descending
                                select new
                                {
                                    item.ID,
                                    item.NgayChuyen,
                                    item.NoiChuyen,
                                    item.NoiNhan,
                                    item.KTXM,
                                    item.NoiDung,
                                    CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                    MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                    itemDon.DanhBo,
                                    itemDon.DiaChi,
                                    NoiDungDon = itemDon.DonTu.Name_NhomDon,
                                };
                    return LINQToDataTable(query);
                case "ToTB":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 2 && item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 3 && item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                case "ToBC":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 4 && item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_ChuyenKTXM(string TenTo, DateTime FromNgayChuyen, DateTime ToNgayChuyen)
        {
            DataTable dt = new DataTable();
            string sql = "select MaDon=case when (select COUNT(MaDon) from DonTu_ChiTiet where MaDon=dt.MaDon)=1 then convert(char(8),dtct.MaDon) else convert(char(8),dtct.MaDon)+'.'+convert(varchar(3),dtct.STT) end,"
                        + " dt.SoCongVan,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,NoiDung=dt.Name_NhomDon,dtls.NgayChuyen,GhiChu=dtls.NoiDung,"
                        + " GiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or ktxmct.NgayKTXM>=dtls.NgayChuyen))then 'true'"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and bcct.NgayBC>=dtls.NgayChuyen)then 'true' else 'false' end,"
                        + " NgayGiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or ktxmct.NgayKTXM>=dtls.NgayChuyen))then (select top 1 ktxmct.NgayKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or ktxmct.NgayKTXM>=dtls.NgayChuyen))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and bcct.NgayBC>=dtls.NgayChuyen)then (select top 1 bcct.NgayBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and bcct.NgayBC>=dtls.NgayChuyen) else null end,"
                        + " NguoiDi=(select HoTen from Users where MaU=dtls.ID_KTXM)"
                        + " from DonTu_LichSu dtls,DonTu_ChiTiet dtct,DonTu dt"
                        + " where dt.MaDon=dtct.MaDon and dtls.STT=dtct.STT and dtls.MaDon=dtct.MaDon and ID_NoiNhan=5";
            switch (TenTo)
            {
                case "ToTB":
                    sql += " and ID_NoiChuyen=2";
                    break;
                case "ToTP":
                    sql += " and ID_NoiChuyen=3";
                    break;
                case "ToBC":
                    sql += " and ID_NoiChuyen=4";
                    break;
            }
            sql += " and CAST(dtls.NgayChuyen as date)>='" + FromNgayChuyen.ToString("yyyyMMdd") + "' and CAST(dtls.NgayChuyen as date)<='" + ToNgayChuyen.ToString("yyyyMMdd") + "'";
            sql += " order by dtct.MaDon,dtct.STT";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ChuyenKTXM(string TenTo, string SoCongVan)
        {
            DataTable dt = new DataTable();
            string sql = "select MaDon=case when (select COUNT(MaDon) from DonTu_ChiTiet where MaDon=dt.MaDon)=1 then convert(char(8),dtct.MaDon) else convert(char(8),dtct.MaDon)+'.'+convert(varchar(3),dtct.STT) end,"
                        + " dt.SoCongVan,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,NoiDung=dt.Name_NhomDon,dtls.NgayChuyen,GhiChu=dtls.NoiDung,"
                        + " GiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or ktxmct.NgayKTXM>=dtls.NgayChuyen))then 'true'"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and bcct.NgayBC>=dtls.NgayChuyen)then 'true' else 'false' end,"
                        + " NgayGiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or ktxmct.NgayKTXM>=dtls.NgayChuyen))then (select top 1 ktxmct.NgayKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or ktxmct.NgayKTXM>=dtls.NgayChuyen))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and bcct.NgayBC>=dtls.NgayChuyen)then (select top 1 bcct.NgayBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and bcct.NgayBC>=dtls.NgayChuyen) else null end,"
                        + " NguoiDi=(select HoTen from Users where MaU=dtls.ID_KTXM)"
                        + " from DonTu_LichSu dtls,DonTu_ChiTiet dtct,DonTu dt"
                        + " where dt.MaDon=dtct.MaDon and dtls.STT=dtct.STT and dtls.MaDon=dtct.MaDon and ID_NoiNhan=5";
            switch (TenTo)
            {
                case "ToTB":
                    sql += " and ID_NoiChuyen=2";
                    break;
                case "ToTP":
                    sql += " and ID_NoiChuyen=3";
                    break;
                case "ToBC":
                    sql += " and ID_NoiChuyen=4";
                    break;
            }
            sql += " and dt.SoCongVan like N'%" + SoCongVan + "%'";
            sql += " order by dtct.MaDon,dtct.STT";
            return ExecuteQuery_DataTable(sql);
        }
    }
}

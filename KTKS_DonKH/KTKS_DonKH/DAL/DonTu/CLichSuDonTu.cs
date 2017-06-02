using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.DonTu
{
    class CLichSuDonTu : CDAL
    {
        public bool Them(LichSuDonTu entity)
        {
            try
            {
                if (db.LichSuDonTus.Count() == 0)
                    entity.ID = 1;
                else
                    entity.ID = db.LichSuDonTus.Max(item => item.ID) + 1;
                entity.CreateBy = CTaiKhoan.MaUser;
                entity.CreateDate = DateTime.Now;
                db.LichSuDonTus.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Xoa(LichSuDonTu entity)
        {
            try
            {
                db.LichSuDonTus.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckExist(DateTime NgayChuyen, int ID_NoiChuyen, int ID_NoiNhan)
        {
            return db.LichSuDonTus.Any(item => item.NgayChuyen.Value.Date == NgayChuyen.Date && item.ID_NoiChuyen == ID_NoiChuyen && item.ID_NoiNhan == ID_NoiNhan);
        }

        public LichSuDonTu Get(int ID)
        {
            return db.LichSuDonTus.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetDS(string Loai, Decimal MaDon)
        {
            DataTable dt = new DataTable();
            switch (Loai)
            {
                case "TKH":
                    dt = LINQToDataTable(db.LichSuDonTus.Where(item => item.MaDon.Value == MaDon).OrderByDescending(item => item.NgayChuyen).ThenByDescending(item => item.ID).ToList());
                    break;
                case "TXL":
                    dt = LINQToDataTable(db.LichSuDonTus.Where(item => item.MaDonTXL.Value == MaDon).OrderByDescending(item => item.NgayChuyen).ThenByDescending(item => item.ID).ToList());
                    break;
                case "TBC":
                    dt = LINQToDataTable(db.LichSuDonTus.Where(item => item.MaDonTBC.Value == MaDon).OrderByDescending(item => item.NgayChuyen).ThenByDescending(item => item.ID).ToList());
                    break;
            }
            return dt;
        }

        public DataTable GetDS(string Loai, DateTime FromNgayChuyen, DateTime ToNgayChuyen)
        {
            DataTable dt = new DataTable();
            switch (Loai)
            {
                case "TKH":
                    var query = from itemLichSuDon in db.LichSuDonTus
                                join itemDonKH in db.DonKHs on itemLichSuDon.MaDon equals itemDonKH.MaDon
                                where itemLichSuDon.MaDon != null && itemLichSuDon.NgayChuyen.Value.Date >= FromNgayChuyen.Date && itemLichSuDon.NgayChuyen.Value.Date <= ToNgayChuyen.Date
                                && itemLichSuDon.ID_NoiChuyen != 1
                                orderby itemLichSuDon.NgayChuyen ascending
                                select new
                                {
                                    itemDonKH.MaDon,
                                    itemDonKH.LoaiDon.TenLD,
                                    itemDonKH.DanhBo,
                                    itemDonKH.HoTen,
                                    itemDonKH.DiaChi,
                                    itemLichSuDon.NgayChuyen,
                                    itemLichSuDon.NoiChuyen,
                                    itemLichSuDon.NoiNhan,
                                    itemLichSuDon.GhiChu,
                                };
                    dt = LINQToDataTable(query.ToList());
                    break;
                case "TXL":
                    query = from itemLichSuDon in db.LichSuDonTus
                            join itemDonTXL in db.DonTXLs on itemLichSuDon.MaDonTXL equals itemDonTXL.MaDon
                            where itemLichSuDon.MaDonTXL != null && itemLichSuDon.NgayChuyen.Value.Date >= FromNgayChuyen.Date && itemLichSuDon.NgayChuyen.Value.Date <= ToNgayChuyen.Date
                            && itemLichSuDon.ID_NoiChuyen != 1
                            orderby itemLichSuDon.NgayChuyen ascending
                            select new
                            {
                                itemDonTXL.MaDon,
                                itemDonTXL.LoaiDonTXL.TenLD,
                                itemDonTXL.DanhBo,
                                itemDonTXL.HoTen,
                                itemDonTXL.DiaChi,
                                itemLichSuDon.NgayChuyen,
                                itemLichSuDon.NoiChuyen,
                                itemLichSuDon.NoiNhan,
                                itemLichSuDon.GhiChu,
                            };
                    dt = LINQToDataTable(query.ToList());
                    break;
                case "TBC":
                    query = from itemLichSuDon in db.LichSuDonTus
                            join itemDonTBC in db.DonTBCs on itemLichSuDon.MaDonTBC equals itemDonTBC.MaDon
                            where itemLichSuDon.MaDonTBC != null && itemLichSuDon.NgayChuyen.Value.Date >= FromNgayChuyen.Date && itemLichSuDon.NgayChuyen.Value.Date <= ToNgayChuyen.Date
                            && itemLichSuDon.ID_NoiChuyen != 1
                            orderby itemLichSuDon.NgayChuyen ascending
                            select new
                            {
                                itemDonTBC.MaDon,
                                itemDonTBC.LoaiDonTBC.TenLD,
                                itemDonTBC.DanhBo,
                                itemDonTBC.HoTen,
                                itemDonTBC.DiaChi,
                                itemLichSuDon.NgayChuyen,
                                itemLichSuDon.NoiChuyen,
                                itemLichSuDon.NoiNhan,
                                itemLichSuDon.GhiChu,
                            };
                    dt = LINQToDataTable(query.ToList());
                    break;
            }
            return dt;
        }

        public DataTable GetDS_3To(string DanhBo)
        {
            DataTable dt = new DataTable();

            var queryTKH = from itemDonTKH in db.DonKHs
                           where itemDonTKH.DanhBo == DanhBo
                           select new
                           {
                               MaDon = "TKH" + itemDonTKH.MaDon,
                               itemDonTKH.LoaiDon.TenLD,
                               itemDonTKH.CreateDate,
                               itemDonTKH.NoiDung,
                           };
            dt.Merge(LINQToDataTable(queryTKH));

            var queryTXL = from itemDonTXL in db.DonTXLs
                           where itemDonTXL.DanhBo == DanhBo
                           select new
                           {
                               MaDon = "TXL" + itemDonTXL.MaDon,
                               itemDonTXL.LoaiDonTXL.TenLD,
                               itemDonTXL.CreateDate,
                               itemDonTXL.NoiDung,
                           };
            dt.Merge(LINQToDataTable(queryTXL));

            var queryTBC = from itemDonTBC in db.DonTBCs
                           where itemDonTBC.DanhBo == DanhBo
                           select new
                           {
                               MaDon = "TBC" + itemDonTBC.MaDon,
                               itemDonTBC.LoaiDonTBC.TenLD,
                               itemDonTBC.CreateDate,
                               itemDonTBC.NoiDung,
                           };
            dt.Merge(LINQToDataTable(queryTBC));

            if (dt.Rows.Count > 0)
                dt.DefaultView.Sort = "CreateDate DESC";
            return dt.DefaultView.ToTable();
        }

        public bool Them(LichSuChuyenKTXM entity)
        {
            try
            {
                if (db.LichSuChuyenKTXMs.Count() > 0)
                {
                    string ID = "MaLSChuyen";
                    string Table = "LichSuChuyenKTXM";
                    decimal MaLSChuyen = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    entity.MaLSChuyen = getMaxNextIDTable(MaLSChuyen);
                }
                else
                    entity.MaLSChuyen = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.LichSuChuyenKTXMs.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                Refresh();
                return false;
            }
        }

        public bool Sua(LichSuChuyenKTXM entity)
        {
            try
            {
                entity.ModifyDate = DateTime.Now;
                entity.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                Refresh();
                return false;
            }
        }

        public bool Xoa(LichSuChuyenKTXM entity)
        {
            try
            {
                db.LichSuChuyenKTXMs.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                Refresh();
                return false;
            }
        }

        public LichSuChuyenKTXM Get(decimal MaLSChuyen)
        {
            try
            {
                return db.LichSuChuyenKTXMs.SingleOrDefault(item => item.MaLSChuyen == MaLSChuyen);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDSChuyen_KTXM(string Loai, DateTime FromNgayChuyen, DateTime ToNgayChuyen)
        {
            DataTable dt = new DataTable();
            switch (Loai)
            {
                case "TKH":
                    var query = from itemChuyenKTXM in db.LichSuDonTus
                                join itemDonTKH in db.DonKHs on itemChuyenKTXM.MaDon equals itemDonTKH.MaDon
                                join itemUser in db.Users on itemChuyenKTXM.ID_NoiNhan equals itemUser.MaU
                                where itemChuyenKTXM.MaDon != null && itemChuyenKTXM.NgayChuyen.Value.Date >= FromNgayChuyen.Date && itemChuyenKTXM.NgayChuyen.Value.Date <= ToNgayChuyen.Date
                                && itemChuyenKTXM.ID_NoiChuyen == 1
                                orderby itemDonTKH.CreateDate ascending
                                select new
                                {
                                    MaDon = "TKH" + itemDonTKH.MaDon,
                                    itemDonTKH.LoaiDon.TenLD,
                                    itemDonTKH.SoCongVan,
                                    itemDonTKH.DanhBo,
                                    itemDonTKH.HoTen,
                                    itemDonTKH.DiaChi,
                                    itemDonTKH.NoiDung,
                                    itemChuyenKTXM.NgayChuyen,
                                    NguoiDi = itemUser.HoTen,
                                    itemChuyenKTXM.GhiChu,
                                    GiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDon == itemDonTKH.MaDon && item.CreateBy == itemDonTKH.NguoiDi_KTXM) == true
                                    ? true : db.CTBamChis.Any(item => item.BamChi.MaDon == itemDonTKH.MaDon && item.CreateBy == itemDonTKH.NguoiDi_KTXM),
                                    NgayGiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDon == itemDonTKH.MaDon && item.CreateBy == itemDonTKH.NguoiDi_KTXM) == true
                                    ? db.CTKTXMs.FirstOrDefault(item => item.KTXM.MaDon == itemDonTKH.MaDon && item.CreateBy == itemDonTKH.NguoiDi_KTXM).NgayKTXM : db.CTBamChis.Any(item => item.BamChi.MaDon == itemDonTKH.MaDon && item.CreateBy == itemDonTKH.NguoiDi_KTXM) == true
                                    ? db.CTBamChis.FirstOrDefault(item => item.BamChi.MaDon == itemDonTKH.MaDon && item.CreateBy == itemDonTKH.NguoiDi_KTXM).NgayBC : null,
                                };
                    dt = LINQToDataTable(query.ToList());
                    break;
                case "TXL":
                    query = from itemChuyenKTXM in db.LichSuDonTus
                            join itemDonTXL in db.DonTXLs on itemChuyenKTXM.MaDonTXL equals itemDonTXL.MaDon
                            join itemUser in db.Users on itemChuyenKTXM.ID_NoiNhan equals itemUser.MaU
                            where itemChuyenKTXM.MaDonTXL != null && itemChuyenKTXM.NgayChuyen.Value.Date >= FromNgayChuyen.Date && itemChuyenKTXM.NgayChuyen.Value.Date <= ToNgayChuyen.Date
                            && itemChuyenKTXM.ID_NoiChuyen == 1
                            orderby itemDonTXL.CreateDate ascending
                            select new
                            {
                                MaDon = "TXL" + itemDonTXL.MaDon,
                                itemDonTXL.LoaiDonTXL.TenLD,
                                itemDonTXL.SoCongVan,
                                itemDonTXL.DanhBo,
                                itemDonTXL.HoTen,
                                itemDonTXL.DiaChi,
                                itemDonTXL.NoiDung,
                                itemChuyenKTXM.NgayChuyen,
                                NguoiDi = itemUser.HoTen,
                                itemChuyenKTXM.GhiChu,
                                GiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM) == true
                                ? true : db.CTBamChis.Any(item => item.BamChi.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM),
                                NgayGiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM) == true
                                ? db.CTKTXMs.FirstOrDefault(item => item.KTXM.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM).NgayKTXM : db.CTBamChis.Any(item => item.BamChi.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM) == true
                                ? db.CTBamChis.FirstOrDefault(item => item.BamChi.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM).NgayBC : null,
                            };
                    dt = LINQToDataTable(query.ToList());
                    break;
                case "TBC":
                    query = from itemChuyenKTXM in db.LichSuDonTus
                            join itemDonTBC in db.DonTBCs on itemChuyenKTXM.MaDonTBC equals itemDonTBC.MaDon
                            join itemUser in db.Users on itemChuyenKTXM.ID_NoiNhan equals itemUser.MaU
                            where itemChuyenKTXM.MaDonTBC != null && itemChuyenKTXM.NgayChuyen.Value.Date >= FromNgayChuyen.Date && itemChuyenKTXM.NgayChuyen.Value.Date <= ToNgayChuyen.Date
                            && itemChuyenKTXM.ID_NoiChuyen == 1
                            orderby itemDonTBC.CreateDate ascending
                            select new
                            {
                                MaDon = "TBC" + itemDonTBC.MaDon,
                                itemDonTBC.LoaiDonTBC.TenLD,
                                itemDonTBC.SoCongVan,
                                itemDonTBC.DanhBo,
                                itemDonTBC.HoTen,
                                itemDonTBC.DiaChi,
                                itemDonTBC.NoiDung,
                                itemChuyenKTXM.NgayChuyen,
                                NguoiDi = itemUser.HoTen,
                                itemChuyenKTXM.GhiChu,
                                GiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM) == true
                                ? true : db.CTBamChis.Any(item => item.BamChi.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM),
                                NgayGiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM) == true
                                ? db.CTKTXMs.FirstOrDefault(item => item.KTXM.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM).NgayKTXM : db.CTBamChis.Any(item => item.BamChi.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM) == true
                                ? db.CTBamChis.FirstOrDefault(item => item.BamChi.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM).NgayBC : null,
                            };
                    dt = LINQToDataTable(query.ToList());
                    break;
            }
            return dt;
        }

        public DataTable GetDSChuyen_KTXM(string Loai, string SoCongVan)
        {
            DataTable dt = new DataTable();
            switch (Loai)
            {
                case "TKH":
                    var query = from itemChuyenKTXM in db.LichSuDonTus
                                join itemDonTKH in db.DonKHs on itemChuyenKTXM.MaDon equals itemDonTKH.MaDon
                                join itemUser in db.Users on itemChuyenKTXM.ID_NoiNhan equals itemUser.MaU
                                where itemChuyenKTXM.MaDon != null && itemDonTKH.SoCongVan==(SoCongVan)
                                && itemChuyenKTXM.ID_NoiChuyen == 1
                                orderby itemDonTKH.CreateDate ascending
                                select new
                                {
                                    MaDon = "TKH" + itemDonTKH.MaDon,
                                    itemDonTKH.LoaiDon.TenLD,
                                    itemDonTKH.SoCongVan,
                                    itemDonTKH.DanhBo,
                                    itemDonTKH.HoTen,
                                    itemDonTKH.DiaChi,
                                    itemDonTKH.NoiDung,
                                    itemChuyenKTXM.NgayChuyen,
                                    NguoiDi = itemUser.HoTen,
                                    itemChuyenKTXM.GhiChu,
                                    GiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDon == itemDonTKH.MaDon && item.CreateBy == itemDonTKH.NguoiDi_KTXM) == true
                                    ? true : db.CTBamChis.Any(item => item.BamChi.MaDon == itemDonTKH.MaDon && item.CreateBy == itemDonTKH.NguoiDi_KTXM),
                                    NgayGiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDon == itemDonTKH.MaDon && item.CreateBy == itemDonTKH.NguoiDi_KTXM) == true
                                    ? db.CTKTXMs.FirstOrDefault(item => item.KTXM.MaDon == itemDonTKH.MaDon && item.CreateBy == itemDonTKH.NguoiDi_KTXM).NgayKTXM : db.CTBamChis.Any(item => item.BamChi.MaDon == itemDonTKH.MaDon && item.CreateBy == itemDonTKH.NguoiDi_KTXM) == true
                                    ? db.CTBamChis.FirstOrDefault(item => item.BamChi.MaDon == itemDonTKH.MaDon && item.CreateBy == itemDonTKH.NguoiDi_KTXM).NgayBC : null,
                                };
                    dt = LINQToDataTable(query.ToList());
                    break;
                case "TXL":
                    query = from itemChuyenKTXM in db.LichSuDonTus
                            join itemDonTXL in db.DonTXLs on itemChuyenKTXM.MaDonTXL equals itemDonTXL.MaDon
                            join itemUser in db.Users on itemChuyenKTXM.ID_NoiNhan equals itemUser.MaU
                            where itemChuyenKTXM.MaDonTXL != null && itemDonTXL.SoCongVan.Contains(SoCongVan)
                            && itemChuyenKTXM.ID_NoiChuyen == 1
                            orderby itemDonTXL.CreateDate ascending
                            select new
                            {
                                MaDon = "TXL" + itemDonTXL.MaDon,
                                itemDonTXL.LoaiDonTXL.TenLD,
                                itemDonTXL.SoCongVan,
                                itemDonTXL.DanhBo,
                                itemDonTXL.HoTen,
                                itemDonTXL.DiaChi,
                                itemDonTXL.NoiDung,
                                itemChuyenKTXM.NgayChuyen,
                                NguoiDi = itemUser.HoTen,
                                itemChuyenKTXM.GhiChu,
                                GiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM) == true
                                ? true : db.CTBamChis.Any(item => item.BamChi.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM),
                                NgayGiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM) == true
                                ? db.CTKTXMs.FirstOrDefault(item => item.KTXM.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM).NgayKTXM : db.CTBamChis.Any(item => item.BamChi.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM) == true
                                ? db.CTBamChis.FirstOrDefault(item => item.BamChi.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM).NgayBC : null,
                            };
                    dt = LINQToDataTable(query.ToList());
                    break;
                case "TBC":
                    query = from itemChuyenKTXM in db.LichSuDonTus
                            join itemDonTBC in db.DonTBCs on itemChuyenKTXM.MaDonTBC equals itemDonTBC.MaDon
                            join itemUser in db.Users on itemChuyenKTXM.ID_NoiNhan equals itemUser.MaU
                            where itemChuyenKTXM.MaDonTBC != null && itemDonTBC.SoCongVan.Contains(SoCongVan)
                            && itemChuyenKTXM.ID_NoiChuyen == 1
                            orderby itemDonTBC.CreateDate ascending
                            select new
                            {
                                MaDon = "TBC" + itemDonTBC.MaDon,
                                itemDonTBC.LoaiDonTBC.TenLD,
                                itemDonTBC.SoCongVan,
                                itemDonTBC.DanhBo,
                                itemDonTBC.HoTen,
                                itemDonTBC.DiaChi,
                                itemDonTBC.NoiDung,
                                itemChuyenKTXM.NgayChuyen,
                                NguoiDi = itemUser.HoTen,
                                itemChuyenKTXM.GhiChu,
                                GiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM) == true
                                ? true : db.CTBamChis.Any(item => item.BamChi.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM),
                                NgayGiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM) == true
                                ? db.CTKTXMs.FirstOrDefault(item => item.KTXM.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM).NgayKTXM : db.CTBamChis.Any(item => item.BamChi.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM) == true
                                ? db.CTBamChis.FirstOrDefault(item => item.BamChi.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM).NgayBC : null,
                            };
                    dt = LINQToDataTable(query.ToList());
                    break;
            }
            return dt;
        }

        public DataTable GetDS_Old(string Loai, Decimal MaDon)
        {
            DataTable dt = new DataTable();
            switch (Loai)
            {
                case "TKH":
                    var queryKTXM = from item in db.LichSuChuyenKTXMs
                                    join itemB in db.Users on item.NguoiDi equals itemB.MaU
                                    where item.MaDon == MaDon
                                    select new
                                    {
                                        NoiChuyen = "Kiểm Tra Xác Minh",
                                        item.NgayChuyen,
                                        GhiChu = item.GhiChuChuyen,
                                        NoiNhan = itemB.HoTen,
                                    };
                    dt.Merge(LINQToDataTable(queryKTXM));
                    var queryVanPhong = from item in db.DonKHs
                                        where item.MaDon == MaDon && item.ChuyenVanPhong == true
                                        select new
                                        {
                                            NoiChuyen = "Tổ Văn Phòng",
                                            NgayChuyen = item.NgayChuyenVanPhong,
                                            GhiChu = item.GhiChuChuyenVanPhong,
                                            NoiNhan = "",
                                        };
                    dt.Merge(LINQToDataTable(queryVanPhong));
                    var queryBanDoiKhac = from item in db.DonKHs
                                          where item.MaDon == MaDon && item.ChuyenBanDoiKhac == true
                                          select new
                                          {
                                              NoiChuyen = "Ban Đội Khác",
                                              NgayChuyen = item.NgayChuyenBanDoiKhac,
                                              GhiChu = item.GhiChuChuyenBanDoiKhac,
                                              NoiNhan = "",
                                          };
                    dt.Merge(LINQToDataTable(queryBanDoiKhac));
                    var queryTXL = from item in db.DonKHs
                                   where item.MaDon == MaDon && item.ChuyenToXuLy == true
                                   select new
                                   {
                                       NoiChuyen = "Tổ Xử Lý",
                                       NgayChuyen = item.NgayChuyenToXuLy,
                                       GhiChu = item.GhiChuChuyenToXuLy,
                                       NoiNhan = "",
                                   };
                    dt.Merge(LINQToDataTable(queryTXL));
                    var queryKhac = from item in db.DonKHs
                                    where item.MaDon == MaDon && item.ChuyenKhac == true
                                    select new
                                    {
                                        NoiChuyen = "Khác",
                                        NgayChuyen = item.NgayChuyenKhac,
                                        GhiChu = item.GhiChuChuyenKhac,
                                        NoiNhan = "",
                                    };
                    dt.Merge(LINQToDataTable(queryKhac));
                    break;
                case "TXL":
                    queryKTXM = from item in db.LichSuChuyenKTXMs
                                join itemB in db.Users on item.NguoiDi equals itemB.MaU
                                where item.MaDonTXL == MaDon
                                select new
                                {
                                    NoiChuyen = "Kiểm Tra Xác Minh",
                                    item.NgayChuyen,
                                    GhiChu = item.GhiChuChuyen,
                                    NoiNhan = itemB.HoTen,
                                };
                    dt.Merge(LINQToDataTable(queryKTXM));
                    queryBanDoiKhac = from item in db.DonTXLs
                                      where item.MaDon == MaDon && item.ChuyenBanDoiKhac == true
                                      select new
                                      {
                                          NoiChuyen = "Ban Đội Khác",
                                          NgayChuyen = item.NgayChuyenBanDoiKhac,
                                          GhiChu = item.GhiChuChuyenBanDoiKhac,
                                          NoiNhan = "",
                                      };
                    dt.Merge(LINQToDataTable(queryBanDoiKhac));
                    var queryTKH = from item in db.DonTXLs
                                   where item.MaDon == MaDon && item.ChuyenToKhachHang == true
                                   select new
                                   {
                                       NoiChuyen = "Tổ Khách Hàng",
                                       NgayChuyen = item.NgayChuyenToKhachHang,
                                       GhiChu = item.GhiChuChuyenToKhachHang,
                                       NoiNhan = "",
                                   };
                    dt.Merge(LINQToDataTable(queryTKH));
                    queryKhac = from item in db.DonTXLs
                                where item.MaDon == MaDon && item.ChuyenKhac == true
                                select new
                                {
                                    NoiChuyen = "Khác",
                                    NgayChuyen = item.NgayChuyenKhac,
                                    GhiChu = item.GhiChuChuyenKhac,
                                    NoiNhan = "",
                                };
                    dt.Merge(LINQToDataTable(queryKhac));
                    break;
                case "TBC":
                    break;
            }
            if(dt.Rows.Count>0)
            dt.DefaultView.Sort = "NgayChuyen DESC";
            return dt.DefaultView.ToTable();
        }
    }
}
